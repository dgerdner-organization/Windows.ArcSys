using System;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;
using CS2010.Common;
using CS2010.CommonWinCtrls;
using ASL.ARC.EDISQLTools;
using Janus.Windows.GridEX;
using CrystalDecisions.Shared;
using CrystalDecisions.ReportSource;
using CrystalDecisions.CrystalReports.Engine;
using System.Reflection;
using CS2010.ArcSys.Business;

/* Needed for Excel */
using System.ComponentModel;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;


namespace CS2010.ArcSys.Win
{
	public partial class frmSDDCInvoicing : frmChildBase
	{
		#region Fields/Properties
		public DataTable dtHeader;
		public DataTable dtItemLevel;
		public DataTable dtCargoLevel;
		public DataTable dtAll;
		protected DataTable dtInvoiceOut;
		public List<SddcInvoiceInput> sddcList;


		public const string sOriginal = "BL VALUES";
		public const string sCorrections = "corrections";
		public const string HeaderTag = "1 HEADER";
		public const string ItemTag = "2 ITEM";
		public const string CargoTag = "3 CARGO";
		//public const string _tsNewInvoice = "tsNewInvoice";
		//public const string _tsExportExcel = "tsExportExcel";

		protected string sVoyage
		{
			get { return txtVoyage.Text; }
		}
		protected string sPCFN
		{
			get
			{
				string s = txtPCFN.Text;
				if (string.IsNullOrEmpty(s))
					return null;
				else
					return s;
			}
		}

		protected string sPCFNShort
		{
			get
			{
				string s = sPCFN;
				if (s.Length > 7)
					return s.Substring(1, 6);
				return s;
			}
		}
		protected string sType
		{
			get
			{
				if (cmbCode.SelectedIndex < 0)
					return "%";
				DataRowView drv = (DataRowView) cmbCode.SelectedItem;
				string s = drv["blvanfo"].ToString();
				return s;
			}
		}
		protected string CurrentInvoice
		{
			get
			{
				if (dtAll.Rows.Count < 1)
					return null;

				string s = dtInvoiceOut.Rows[0]["invoice_no"].ToString();
				return s;
			}
		}

		#region Required for Excel import/export
		//int iGlobalRow = 0;
		//int iGlobalCol = 0;
		StringBuilder sbErrorLog;
		//string sAudit = "Start";
		string StartFolder = "c:";
		string OutputFolder;
		//string OutputExtension;
		//string ArchiveFolder;
		protected string InputFileName;
		protected string InputFileNameFull;
		int colCount = 50;
		//int errorCount = 0;
		//int errorMax = 10;
		protected int copyRowCount = 0;

		bool bGridHasColumns = false;

		string[] columnName = new string[] 
			{ "row_type", "bol_no", "customer_ref_cd", "edi_ref", 
			  "service_cd", "bol_id", "vessel_cd", "voyage_no"
			};

		string[] duplicateCols = new string[] { "booking_no", "bol_id", "bol_no", "booking_id"};
		#endregion

		#endregion		// #region Fields/Properties1

		#region Constructors/Initialization/Entry/Cleanup

		public frmSDDCInvoicing()
		{
			InitializeComponent();
			this.Activate();
			this.MdiParent = Program.MainWindow;
			this.WindowState = FormWindowState.Maximized;

			// Connect to LINE
            if (ClsConMgr.Manager["LINE"] == null)
            {
				Program.ConnectToLINE();
	        }

			// DropDowns
			DataTable dtLoc = ClsAcmsSQL.SelectLocations();
			DataTable dtPerCodes = ClsQueries.LINEChargePerCodes();
			cmbTwo.DataSource = dtPerCodes;
			InitParameters();
		}

		private void InitParameters()
		{
		}
		#endregion

		#region Search Methods
		private void PerformSearch()
		{
			try
			{
				progressBar1.Visible = true;
				int rCount = 40;
				progressBar1.Maximum = rCount + 10;
				dtHeader = ClsQueries.GetSDDCInvoicingData(sPCFN, sVoyage);

				progressBar1.Value = 10;
				grdMain.DataSource = dtHeader;
				if (dtHeader.Rows.Count < 1)
				{
					Program.Show("No cargo found.");
					return;
				}

				// Scroll through datarows, convert to class object
				sddcList = new List<SddcInvoiceInput>();

				foreach (DataRow drow in dtHeader.Rows)
				{
					PopulateWithACMSData(drow);

					string s = drow["customer_ref_cd"].ToString();
					if (string.IsNullOrEmpty(s))
						s = drow["edi_ref"].ToString();

					progressBar1.Value = 20;
					// Item level data
					DataTable dtI = ClsQueries.GetSDDCInvoiceItemData(s, sType);
					progressBar1.Value = 30;
					dtI = CargoComputedFields(dtI);
					if (dtItemLevel == null)
						dtItemLevel = dtI.Copy();
					else
						dtItemLevel.Merge(dtI);
					grdItemLevel.DataSource = dtItemLevel;

					// Cargo level data
					GetCargoData(dtI, s);
					progressBar1.Value = 40;
					//dtCargoLevel = CargoComputedFields(dtCargoLevel);
					progressBar1.Value = 45;
					grdCargoLevel.DataSource = dtCargoLevel;
				}
				dtCargoLevel = CargoComputedFields(dtCargoLevel);

				//progressBar1.Value = 20;
				//// Item level data
				//dtItemLevel = ClsQueries.GetSDDCInvoiceItemData(sPCFN, sType);
				//progressBar1.Value = 30;
				//dtItemLevel = CargoComputedFields(dtItemLevel);
				//grdItemLevel.DataSource = dtItemLevel;

				//// Cargo level data
				//GetCargoData();
				//progressBar1.Value = 40;
				//dtCargoLevel = CargoComputedFields(dtCargoLevel);
				//progressBar1.Value = 45;
				//grdCargoLevel.DataSource = dtCargoLevel;
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}

		}

		#endregion		// #region Constructors/Initialization/Entry/Cleanup

		#region Helper Methods
		#region BOL Level
		protected void PopulateWithACMSData(DataRow dr)
		{
			string sP = dr["customer_ref_cd"].ToString();
			string sType = dr["row_type"].ToString();
			string sVesselCd = dr["vessel_cd"].ToString();

			ClsBookingLine bl = ClsBookingLine.GetByBookingNo(dr["booking_no"].ToString());
			dr["acmsvoydoc"] = ClsAcmsSQL.GetVoyDoc(sP);
			DataRow drVmVoyage = ClsQueries.GetMvVoyage(bl.Voyage_No);
			dr["route_id"] = drVmVoyage["route_cd"].ToString();
			string sVesselNm = ClsAcmsSQL.GetVesselName(sVesselCd);
			dr["vessel_nm"] = sVesselNm;

			string sLoc = dr["pol_location_cd"].ToString();
			string sSDDCCd = SDDCLocationCd(sLoc);
			dr["pol_sddc_cd"] = sSDDCCd;
			sLoc = dr["pod_location_cd"].ToString();
			sSDDCCd = SDDCLocationCd(sLoc);
			dr["pod_sddc_cd"] = sSDDCCd;

			//GetPartyData(ref dr);
			DataTable dtParty = ClsAcmsSQL.GetBookingParty(sP, "CN");
			if (dtParty.Rows.Count < 1)
				return;
			dr["consignor_sddc_cd"] = dtParty.Rows[0]["DODAAC"].ToString();
			string sAddr = dtParty.Rows[0]["party_name"].ToString();
			dr["consignor_addr"] = sAddr;

			dtParty = ClsAcmsSQL.GetBookingParty(sP, "CI");
			dr["consignee_sddc_cd"] = dtParty.Rows[0]["DODAAC"].ToString();
			sAddr = dtParty.Rows[0]["party_name"].ToString();
			dr["consignee_addr"] = sAddr;

			//SddcInvoiceInput si = DataRowToInvoice(dr);
			//return si;
		}

		protected string SDDCLocationCd(string sLoc)
		{
			DataTable dt = ClsQueries.GetSDDCLocation(sLoc);
			if (dt == null) return "na";
			if (dt.Rows.Count < 1) return "na";
			return dt.Rows[0]["other1_cd"].ToString();
		}

		protected void GetPartyData(ref DataRow dr)
		{

			string sP = dr["customer_ref_cd"].ToString();
			DataTable dtParty = ClsAcmsSQL.GetBookingParty(sP, "CN");
			if (dtParty.Rows.Count < 1)
				return;
			dr["consignor_sddc_cd"] = dtParty.Rows[0]["DODAAC"].ToString();
			string sAddr = dtParty.Rows[0]["party_name"].ToString();
			dr["consignor_addr"] = sAddr;

			dtParty = ClsAcmsSQL.GetBookingParty(sP, "CI");
			dr["consignee_sddc_cd"] = dtParty.Rows[0]["DODAAC"].ToString();
			sAddr = dtParty.Rows[0]["party_name"].ToString();
			dr["consignee_addr"] = sAddr;
		}

		//protected SddcInvoiceInput DataRowToInvoice(DataRow dr)
		//{
		//    SddcInvoiceInput si = new SddcInvoiceInput();
		//    si._Row_Type = dr["row_type"].ToString();
		//    si._Bol_No = dr["bol_no"].ToString();
		//    si._Booking_No = dr["booking_no"].ToString();
		//    si._Customer_Ref_Cd = dr["customer_ref_cd"].ToString();
		//    si._Service_Cd = dr["service_cd"].ToString();
		//    si._Vessel_Cd = dr["vessel_cd"].ToString();
		//    si._Voyage_No = dr["voyage_no"].ToString();
		//    si._Plor_Location_Cd = dr["plor_location_cd"].ToString();
		//    si._Plod_Location_Cd = dr["plod_location_cd"].ToString();
		//    si._Pol_Location_Cd = dr["pol_location_cd"].ToString();
		//    si._Pol_Berth = dr["pol_berth"].ToString();
		//    si._Pod_Location_Cd = dr["pod_location_cd"].ToString();
		//    si._Pod_Berth = dr["pod_berth"].ToString();
		//    si._Tariff_Cd = dr["tariff_cd"].ToString();
		//    si._Move_Type_Cd = dr["move_type_cd"].ToString();
		//    si._SCAC = dr["SCAC"].ToString();
		//    si.Consignor_Cd = dr["consignor_cd"].ToString();
		//    si.Consignor_Addr = dr["consignor_addr"].ToString();
		//    si.Consignee_Cd = dr["consignee_cd"].ToString();
		//    si.Consignee_Addr = dr["consignee_addr"].ToString();

		//    ClsBookingLine bl = ClsBookingLine.GetByBookingNo(si.Booking_No);
		//    si._Sail_Dt = bl.Sail_Dt.GetValueOrDefault();
		//    si._ACMSvoydoc = ClsAcmsSQL.GetVoyDoc(sPCFN);
		//    si.Consignor_SDDC_Cd = "RC";
		//    si.Consignee_SDDC_Cd = "EC";


		//    return si;
		//}
		#endregion

		#region Item Level

		protected DataTable CargoComputedFields(DataTable dt)
		{
			/*
			   Populates the computed fields at the Item Level
			 */
			foreach (DataRow dr in dt.Rows)
			{
				/* Dimensions */
				string sType = dr["row_type"].ToString();
				decimal dLength = GetDecimalColumn(dr, "length_cm");
				decimal dWidth = GetDecimalColumn(dr, "width_cm");
				decimal dHeight = GetDecimalColumn(dr, "height_cm");
				string sChargePer = dr["charge_per_unit"].ToString();
				decimal dCFT_Line = GetDecimalColumn(dr, "cft_line");
				decimal dCFT40_Line = GetDecimalColumn(dr, "cft40_line");
				decimal dMton_Line = GetDecimalColumn(dr, "m3_line");

				int iCFT = ClsQueries.CubeSDDC(dLength, dWidth, dHeight);
				decimal dCFT40 = ClsQueries.Cube40SDDC(dLength, dWidth, dHeight, sChargePer);
				decimal dMton = ClsQueries.M3SDDC(dLength, dWidth, dHeight);

				// If the item does not have dimensions, use LINE's fields
				// for the computed fields.
				dr["cft_computed"] = dLength == 0 ? dCFT_Line : iCFT ;
				dr["cft40_computed"] = dLength == 0 ? dCFT40_Line : dCFT40;
				dr["m3_computed"] = dLength == 0 ? dMton_Line : dMton;


				// Charges
				decimal dChargeRate = GetDecimalColumn(dr, "charge_rate");
				decimal dCharge = 0;
				switch (sChargePer)
				{
					case "40FT3":
						dCharge = Math.Round(dChargeRate * dCFT40,2);
						break;
					default:
						dCharge = dChargeRate;
						break;
				}
				dr["charge_total"] = dCharge;
				
				// Get Delivery Date
				if (sType.ToUpper() == CargoTag)
				{
					DateTime? dtX1;
					string sVoyageNo = dr["voyage_no"].ToString();
					string sTCN = dr["serial_no"].ToString();

					DataTable dtITV = ClsAcmsSQL.SearchITVHistory(sVoyageNo, "%", sTCN, "X1", false, "%", "%", "%", "%", "%");
					if (dtITV.Rows.Count < 1)
						dtX1 = null;
					else
						dtX1 = dtITV.Rows[0]["activity_dt"].ToDateTime();
					//dr["x1_dt"] = dtX1;
					PopulateCargoWithACMSData(dr);
				}

				//// Translations
				//string sChargeCd = dr["surcharge_cd"].ToString();
				//sChargePer = dr["charge_per_unit"].ToString();
				//sChargeCd = XlateChargeCd(sChargeCd);
				//sChargePer = XlateUM(sChargePer);
				//dr["surcharge_cd"] = sChargeCd;
				//dr["charge_per_unit"] = sChargePer;

			}

			return dt;
		}


		private DataRow PopulateCargoWithACMSData(DataRow dr)
		{
			GetPartyData(ref dr);
			return dr;
		}

		#endregion

		#region Cargo Level
		protected void GetCargoData(DataTable dtI, string sP)
		{
			DataTable dtCargoWorking = new DataTable();

			foreach (DataRow drow in dtI.Rows)
			{
				string sCargoType = drow["cargo_type"].ToString();
				string sItemNo = drow["item_no"].ToString();
				string sChargeCd = drow["surcharge_cd"].ToString();
				string sRate = drow["charge_rate"].ToString();
				string sBolID = drow["bol_id"].ToString();
				string sChargePer = drow["charge_per_unit"].ToString();

				// Get all of the cargo data

				dtCargoWorking = ClsQueries.GetSDDCInvoiceCargoAll(sBolID, sItemNo, sChargeCd, sP);

				// Get delivery date
				if (dtCargoLevel == null)
					dtCargoLevel = dtCargoWorking.Copy();
				else
					dtCargoLevel.Merge(dtCargoWorking);

				// For the Freight charges, we need to plug in the default Rate (because
				// the query returns zero for charge "NTFR".
				if (sChargeCd.Trim() == "NTFR")
				{
					foreach (DataRow dr in dtCargoLevel.Rows)
					{
						dr["charge_rate"] = ClsConvert.ToDecimal(sRate);
						dr["charge_per_unit"] = sChargePer;
					}
				}

				//// Translations
				//foreach (DataRow dr in dtCargoLevel.Rows)
				//{
				//    sChargeCd = dr["surcharge_cd"].ToString();
				//    sChargePer = dr["charge_per_unit"].ToString();
				//    sChargeCd = XlateChargeCd(sChargeCd);
				//    sChargePer = XlateUM(sChargePer);
				//    dr["surcharge_cd"] = sChargeCd;
				//    dr["charge_per_unit"] = sChargePer;
				//}

			}
			//dtCargoLevel.DefaultView.Sort = "item_no, line_link_no, surcharge_cd";
			grdCargoLevel.DataSource = dtCargoLevel;
		}
		protected void GetCargoData()
		{
			DataTable dtCargoWorking = new DataTable();
			dtCargoLevel = new DataTable();
			//foreach (DataRow drow in dtHeader.Rows)
			//{
			//    string sBolID= drow["bol_id"].ToString();
			//    dtCargoWorking = ClsQueries.GetSDDCInvoiceCargoAll(sBolID);
			//    if (dtCargoLevel == null)
			//       dtCargoLevel = dtCargoWorking.Copy();
			//    else
			//       dtCargoLevel.Merge(dtCargoWorking);
			//}
			foreach (DataRow drow in dtItemLevel.Rows)
			{
				//DateTime dtX1;
				string sCargoType = drow["cargo_type"].ToString();
				string sItemNo = drow["item_no"].ToString();
				string sChargeCd = drow["surcharge_cd"].ToString();
				string sRate = drow["charge_rate"].ToString();
				string sBolID = drow["bol_id"].ToString();
				string sChargePer = drow["charge_per_unit"].ToString();
				string sP = drow["customer_ref_cd"].ToString();

				// Get all of the cargo data
				dtCargoWorking = ClsQueries.GetSDDCInvoiceCargoAll(sBolID, sItemNo, sChargeCd, sP);

				// Get delivery date
				if (dtCargoLevel == null)
					dtCargoLevel = dtCargoWorking.Copy();
				else
					dtCargoLevel.Merge(dtCargoWorking);

				// For the Freight charges, we need to plug in the default Rate (because
				// the query returns zero for charge "NTFR".
				if (sChargeCd.Trim() == "NTFR")
				{
					foreach (DataRow dr in dtCargoLevel.Rows)
					{
						dr["charge_rate"] = ClsConvert.ToDecimal(sRate);
						dr["charge_per_unit"] = sChargePer;
					}
				}

				//// Translations
				//foreach (DataRow dr in dtCargoLevel.Rows)
				//{
				//    sChargeCd = dr["surcharge_cd"].ToString();
				//    sChargePer = dr["charge_per_unit"].ToString();
				//    sChargeCd = XlateChargeCd(sChargeCd);
				//    sChargePer = XlateUM(sChargePer);
				//    dr["surcharge_cd"] = sChargeCd;
				//    dr["charge_per_unit"] = sChargePer;
				//}

			}
			dtCargoLevel.DefaultView.Sort = "item_no, line_link_no, surcharge_cd";
			grdCargoLevel.DataSource = dtCargoLevel;
		}

		#endregion


		#endregion

		#region Conversions Etc
		protected decimal GetDecimalColumn(DataRow drow, string sColumnName)
		{
			string sCol = drow[sColumnName].ToString();
			decimal? dResult = ClsConvert.ToDecimalNullable(sCol);
			return dResult.GetValueOrDefault();
		}

		protected string XlateChargeCd(string sCode)
		{
			sCode = sCode.Trim();
			ClsSddcSurcharge SDDC = ClsSddcSurcharge.GetUsingKey(sCode);
			if (SDDC == null)
				return sCode;
			if (string.IsNullOrEmpty(SDDC.Sddc_Charge_Cd))
				return sCode;
			return SDDC.Sddc_Charge_Cd;
		}

		protected string XlateUM(string sCode)
		{
			string sUM = "EA";
			switch (sCode)
			{
				case "40FT3":
					sUM = "MTON";
					break;
				default:
					return "EA";
			}
			return sUM;
		}
		#endregion

		#region Event Handlers

		private void btnSearch_Click(object sender, EventArgs e)
		{
			PerformSearch();
			ExportAll();

			tsExportExcel.Enabled = true;
			tsImportFromExcel.Enabled = false;
			tsGenerateInvoice.Enabled = true;
		}

		private void tbbClear_Click(object sender, EventArgs e)
		{
			//txtVessel.Text = "";
			InitParameters();
		}

		private void btnBindObject_Click(object sender, EventArgs e)
		{
			grdMain.DataSource = sddcList;
		}

		private void grdMain_FormattingRow(object sender, RowLoadEventArgs e)
		{

		}

		private void tsExportExcel_Click(object sender, EventArgs e)
		{
			ExportCurrentData();
		}
		#endregion		// #region Event Handlers

		#region Excel Stuff
		private void releaseObject(object obj)
		{
			try
			{
				System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
				obj = null;
			}
			catch (Exception ex)
			{
				obj = null;
				MessageBox.Show("Unable to release the Object " + ex.ToString());
			}
			finally
			{
				GC.Collect();
			}
		}

		protected bool ExportAll()
		{
			/*
				This takes all three datatables (header, item, detail) and exports them to 
			    a single datatable, then exports that datatable to an Excel Spreadsheet.
			*/
			try
			{
				progressBar1.Visible = true;
				progressBar1.Value = 1;
				int iCounter = 1;
				int rCount = dtHeader.Rows.Count + dtItemLevel.Rows.Count + dtCargoLevel.Rows.Count;
				progressBar1.Maximum = rCount + 1;
				/* 
				  Create new datatable and add columns
				  from all 3 datatables
				 */
				dtAll = dtHeader.Copy();
				OutputFolder = "u:\\" + ClsEnvironment.UserName + "\\";
				foreach (DataColumn dc in dtItemLevel.Columns)
				{
					try
					{
						dtAll.Columns.Add(dc.ColumnName, dc.DataType);
					}
					catch (Exception ex)
					{
						Program.Show(ex.Message);
					}
				}
				foreach (DataColumn dc in dtCargoLevel.Columns)
				{
					try
					{
						string s = dc.ColumnName;
						dtAll.Columns.Add(dc.ColumnName, dc.DataType);
					}
					catch (Exception ex)
					{
						Program.Show(ex.Message);
					}
				}

				/* Add rows from second datatable */
				foreach (DataRow drI in dtItemLevel.Rows)
				{
					iCounter++;
					progressBar1.Value = iCounter;
					DataRow drNew = dtAll.NewRow();
					foreach (DataColumn dc in dtItemLevel.Columns)
					{
						string sColName = dc.ColumnName;
						drNew[sColName] = drI[sColName].ToString();
					}
					dtAll.Rows.Add(drNew);
				}

				/* Add rows from the third (cargo level) datatable */
				foreach (DataRow drC in dtCargoLevel.Rows)
				{
					iCounter++;
					progressBar1.Value = iCounter;
					DataRow drNew = dtAll.NewRow();
					foreach (DataColumn dc in dtCargoLevel.Columns)
					{
						string sColName = dc.ColumnName;
						drNew[sColName] = drC[sColName].ToString();
					}
					dtAll.Rows.Add(drNew);
				}

				dtAll.DefaultView.Sort = "row_type, bol_no, item_no, line_link_no, surcharge_cd";
				dtAll.DefaultView.ApplyDefaultSort = true;
				progressBar1.Visible = false;
				grdWorkFormat.DataSource = dtAll;

				return true;
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
				return false;
			}
		}


		protected bool ExportCurrentData()
		{
			try
			{

				int i = GetRandom();
				string sRdm = i.ToString();
				grdWorkFormat.DataSource = dtAll;
				string sOut = OutputFolder + "SDDC_Worksheet_" + sPCFN + "_" + sRdm + ".xls";
				grdWorkFormat.ExportExcel(sOut);
				//sOut = OutputFolder + "SDDC_Invoice_" + sPCFN + ".csv";
				//grdWorkFormat.ExportCSV(sOut);
				return true;
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
				return false;
			}
		}

		private static Random _r = new Random();
		private static int GetRandom()
		{
			int n = _r.Next(9999);
			return n;
		}

		//protected bool ExportExcel(DataTable dt)
		//{
		//    if (dt.Rows.Count < 1)
		//    {
		//        Program.Show("No invoices to export");
		//        return false;
		//    }
		//    int rRows = dt.Rows.Count + dtItemLevel.Rows.Count + dtCargoLevel.Rows.Count;

		//    progressBar1.Maximum = rRows;
		//    progressBar1.Value = 1;
		//    try
		//    {
		//        if (dt == null || dt.Rows.Count == 0) return false;
		//        Microsoft.Office.Interop.Excel.Application xlApp =
		//           new Microsoft.Office.Interop.Excel.Application();

		//        if (xlApp == null)
		//        {
		//            return false;
		//        }
		//        System.Globalization.CultureInfo CurrentCI =
		//           System.Threading.Thread.CurrentThread.CurrentCulture;
		//        System.Threading.Thread.CurrentThread.CurrentCulture =
		//               new System.Globalization.CultureInfo("en-US");
		//        Microsoft.Office.Interop.Excel.Workbooks workbooks = xlApp.Workbooks;
		//        Microsoft.Office.Interop.Excel.Workbook workbook =
		//               workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
		//        Microsoft.Office.Interop.Excel.Worksheet worksheet =
		//           (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1];
		//        Microsoft.Office.Interop.Excel.Range range;
		//        long totalCount = rRows;
		//        long rowRead = iGlobalRow = 0;
		//        float percent = 0;

		//        /* Create the columns */
		//        /*for (int i = 0; i < dt.Columns.Count; i++)*/
		//        for (int i=0; i < 8; i++)
		//        {
		//            iGlobalCol = i;
		//            worksheet.Cells[1, i + 1] = columnName[i];
		//            range = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[1, i + 1];
		//            range.Interior.ColorIndex = 15;
		//            range.Font.Bold = true;
		//        }
		//        for (int r = 0; r < dt.Rows.Count; r++)
		//        {
		//            iGlobalRow = r;
		//            progressBar1.Value = r;
		//            for (int i = 0; i < 8; i++)
		//            {
		//                worksheet.Cells[r + 2, i + 1] = dt.Rows[r][i].ToString();
		//            }
		//            rowRead++;
		//            percent = ((float)(100 * rowRead)) / totalCount;
		//        }
		//        //string sOutputFileName = InputFileName.Replace(".", OutputExtension);
		//        //sOutputFileName = OutputFolder + "\\" + sOutputFileName;
		//        //workbook.SaveAs(sOutputFileName,
		//        //        Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal);
		//        workbook.Close(false);
		//        xlApp.Quit();
		//        //Program.Show("File created: {0}", sOutputFileName);
		//        //this.Close();
		//        return true;
		//    }
		//    catch (Exception ex)
		//    {
		//        string s = ex.Message;
		//        if (s == "Exception from HRESULT: 0x800A03EC")
		//        {
		//            Program.Show("File was not created per user request");
		//            return false;
		//        }
		//        s = string.Format("Row:{0} Col:{1}  Audit:{2}  ", iGlobalRow, iGlobalCol, sAudit);
		//        s = s + ex.Message;
		//        Program.ShowError(s);
		//        return false;
		//    }
		//}

		//private void ArchiveFile()
		//{
		//    // Archives the input filde upon completion
		//    try
		//    {
		//        //string sArchiveName = ArchiveFolder + "\\" + InputFileName;
		//        //File.Move(InputFileNameFull, sArchiveName);
		//    }
		//    catch (Exception ex)
		//    {
		//        Program.ShowError(ex);
		//        Program.Show("The process was completed successfully, but the input file was not archived.");
		//    }
		//}

		private void txImportFromExcel_Click(object sender, EventArgs e)
		{
			/* Opening an output file to be merged*/
			dtAll = new DataTable();
			try
			{
				dtAll = new DataTable();
				if (ReadExcel(ref dtAll, grdWorkFormat, false) == false)
					return;
				grdWorkFormat.DataSource = dtAll;
				progressBar1.Value = 0;
				tsNewInvoice.Enabled = false;
				tsGenerateInvoice.Enabled = true;
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private bool ReadExcel(ref System.Data.DataTable dt, ucGridEx dGrid, bool bInput)
		{
			/* 
			 * Reads the user's spreadsheet file into the DataGrid
			 */
			try
			{

				// Initialize a new error log
				sbErrorLog = new StringBuilder();
				//pnlErrorLog.Visible = false;

				// Open the file
				this.openFileDialog1.InitialDirectory = StartFolder;
				if (!bInput)
					this.openFileDialog1.InitialDirectory = OutputFolder;

				this.openFileDialog1.FileName = "*.xls";
				this.openFileDialog1.ShowDialog();

				// If no file was selected, bail-out
				// Otherwise, if the user selected an input file save
				// the file name; which will later be used to help
				// name the output file
				if (openFileDialog1.SafeFileName.Length < 6)
					return false;
				if (bInput)
				{
					InputFileNameFull = openFileDialog1.FileName;
					InputFileName = openFileDialog1.SafeFileName;
				}

				// Setup the spreadsheet
				Microsoft.Office.Interop.Excel.Application xlApp;
				Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
				Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
				Microsoft.Office.Interop.Excel.Range rnge;

				string str;
				int rCnt = 0;
				int cCnt = 0;

				xlApp = new Microsoft.Office.Interop.Excel.Application();
				xlWorkBook = xlApp.Workbooks.Open(openFileDialog1.FileName, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
				xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

				//dtInput = new System.Data.DataTable();

				rnge = xlWorkSheet.UsedRange;
				DataRow dr = dt.NewRow();

				//ClsImportActualColumn column = new ClsImportActualColumn("");

				// Compute Row Count
				int rCount = 10000;
				if (rnge.Rows.Count < rCount)
				{
					rCount = rnge.Rows.Count;
				}
				progressBar1.Maximum = rCount + 2;

				// Compute Column Count
				if (rnge.Columns.Count < colCount)
				{
					colCount = rnge.Columns.Count;
				}

				//  Loop through all rows
				for (rCnt = 1; rCnt <= rCount; rCnt++)
				{
					progressBar1.Value = rCnt;
					// Loop through all columns
					for (cCnt = 1; cCnt <= colCount; cCnt++)
					{
						// This is the current index
						int colIndex = cCnt - 1;

						//  Get the  value in the current cell
						str = ClsConvert.ToString((rnge.Cells[rCnt, cCnt] as Microsoft.Office.Interop.Excel.Range).Value2);

						if (!string.IsNullOrEmpty(str))
							str = str.Trim();

						// The first row is the column header row
						if (rCnt == 1)
						{
							if (str == null)
							{
								colCount = colCount - 1;
								continue;
							}
							CreateColumn(dt, dGrid, str, rCnt);
							continue;
						}

						// If we're reading the first column on a row,
						// create a new datarow for the datatable
						if (cCnt == 1 && rCnt > 1)
						{
							// Crate a new datarow
							dr = dt.NewRow();
							dt.Rows.Add(dr);
							int i = dt.Columns.Count;

						}
						dr[colIndex] = str;
					}
				}
				//dt.Rows[0].Delete();

				// Cleanup Excel
				xlWorkBook.Close(true, null, null);
				xlApp.Quit();
				releaseObject(xlWorkSheet);
				releaseObject(xlWorkBook);
				releaseObject(xlApp);
				return true;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				sbErrorLog.AppendLine(ex.Message);
				return false;
				//progressBar.Visible = false;
			}
		}

		private void CreateColumn(System.Data.DataTable dt, ucGridEx dGrid, string sCol, int rCnt)
		{
			dt.Columns.Add(sCol);
			if (!bGridHasColumns)
			{
				dGrid.Tables[0].Columns.Add(sCol);
				dGrid.Tables[0].Columns[sCol].AllowSort = false;
			}
		}

		#endregion

		#region Create Invoice
		private void CreateSDDCInvoice()
		{
			try
			{


				// Extract just the "CARGO" rows
				var results = from myRow in dtAll.AsEnumerable()
							  where myRow.Field<string>("row_type") == CargoTag
							  select myRow;

				dtInvoiceOut = results.CopyToDataTable();
				grdInvoiceOut.DataSource = dtInvoiceOut;

				// Extract the "Header" rows
				var vHeader = from myRow in dtAll.AsEnumerable()
							  where myRow.Field<string>("row_type") == HeaderTag
							  select myRow;
				DataTable dtInvoiceHeader = vHeader.CopyToDataTable();

				grdWorkFormat.DataSource = dtAll;
				string sOut = string.Format("OI{0:yyyyMMddHHmmss}_OCT.txt", DateTime.Now);
				OutputFolder = "u:\\" + ClsEnvironment.UserName + "\\";
				string sInvoiceFile = OutputFolder + sOut;

				// Allow the user to override the default InvoiceNumber
				frmGetInvoiceNo dlg = new frmGetInvoiceNo();
				dlg.InvoiceNo = CurrentInvoice;
				DialogResult dResult = dlg.ShowDialog(this);
				if (dResult == DialogResult.Cancel)
				{
					Program.Show("Procedure cancelled by user");
					return;
				}
				string sInvoice = dlg.InvoiceNo;

				using (System.IO.StreamWriter file = new System.IO.StreamWriter(sInvoiceFile))
				{
					file.WriteLine("1...5....0....5....0....5....0....5....0....5....0....5....0....5....0....5....0....5....0....5....0....5....0....5....0....5....0");
					foreach (DataRow dr in dtInvoiceOut.Rows)
					{
						DataRow drHdr = dtInvoiceHeader.Rows[0];
						StringBuilder s = new StringBuilder();

						// Get Detail data
						s.Append("DTL");
						//string x = dr["invoice_no"].ToString();
						string x = sInvoice;

						s.Append(PadTrim(x,30));
						x = FormatDateToEight(DateTime.Now.ToString());
						s.Append(PadTrim(x, 8));
						s.Append("AROF");
						x = sPCFNShort;
						s.Append(PadTrim(x,6));
						x = drHdr["sail_dt"].ToString();
						x = FormatDateToEight(x);
						s.Append(x);
						s.Append(x);
						x = dr["serial_no"].ToString();
						s.Append(PadTrim(x, 17));						
						x = drHdr["pol_sddc_cd"].ToString();
						s.Append(PadTrim(x,3));
						x = drHdr["pod_sddc_cd"].ToString();
						s.Append(PadTrim(x,3));
						x = drHdr["consignor_sddc_cd"].ToString();
						s.Append(PadTrim(x,6));
						x = drHdr["consignee_sddc_cd"].ToString();
						s.Append(PadTrim(x,6));
						x = dr["surcharge_cd"].ToString();
						s.Append(PadTrim(x, 3));
						// Note above - we need to convert to EDI codes

						x = dr["charge_rate"].ToString();
						x = FormatNumeric_8d2(x);
						s.Append(x);

						x = dr["charge_total"].ToString();
						x = FormatNumeric_9d2(x);
						s.Append(x);

						s.Append("UM");								/* Unit of Measure */

						s.Append(PadTrim("",8));					/* TCON				*/

						x = dr["cft40_computed"].ToString();		/* MTON				*/
						x = FormatNumeric_8d2(x);					
						s.Append(x);

						s.Append(PadTrim("1", 10));					/* Pieces */
						
						x = dr["weight_lbs"].ToString();
						x = FormatNumeric_10(x);
						s.Append(x);

						x = dr["cft_computed"].ToString();			/* Cubic Inches)*/
						decimal dCft = ClsConvert.ToDecimal(x);
						long iCinches =  (long) Math.Round(dCft * 1728M, 0);
						x = iCinches.ToString("0:0000000000000");
						s.Append(x);

						s.Append(PadTrim("",2));					/* Container Size Code */
						s.Append(PadTrim("",1));					/* Container Type Code */
						s.Append(PadTrim("", 2));					/* Van Type Pack */
						s.Append(PadTrim("", 2));					/* Vessel Status */

						x =  drHdr["route_id"].ToString();				/* Route */
						s.Append(PadTrim(x, 4));				

						x = drHdr["vessel_nm"].ToString();				/* Vessel name */
						s.Append(PadTrim(x, 80));

						x = drHdr["acmsvoydoc"].ToString();			/* VoyDoc */
						s.Append(PadTrim(x, 5));
						
						s.Append(PadTrim("", 19));				    /* Pallet ID */

						s.Append(PadTrim("", 8));					/* Delivery Date*/

						file.WriteLine(s.ToString());
					}
				}
				Program.Show("Invoice created: {0} ", sInvoiceFile);
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void CreateSDDCInvoiceExcel()
		{
			try
			{

				// Extract just the "CARGO" rows
				var results = from myRow in dtAll.AsEnumerable()
							  where myRow.Field<string>("row_type") == CargoTag
							  select myRow;


				dtInvoiceOut = results.CopyToDataTable();
				grdInvoiceOut.DataSource = dtInvoiceOut;

				// Extract the "Header" rows
				var vHeader = from myRow in dtAll.AsEnumerable()
							  where myRow.Field<string>("row_type") == HeaderTag
							  select myRow;
				DataTable dtInvoiceHeader = vHeader.CopyToDataTable();
				
				grdWorkFormat.DataSource = dtAll;
				string sOut = string.Format("OI{0:yyyyMMddHHmmss}_OCT.csv", DateTime.Now);
				OutputFolder = "u:\\" + ClsEnvironment.UserName + "\\";
				string sInvoiceFile = OutputFolder + sOut;

				// Allow the user to override the default InvoiceNumber
				frmGetInvoiceNo dlg = new frmGetInvoiceNo();
				dlg.InvoiceNo = CurrentInvoice;
				DialogResult dResult = dlg.ShowDialog(this);
				if (dResult == DialogResult.Cancel)
				{
					Program.Show("Procedure cancelled by user");
					return;
				}
				string sInvoice = dlg.InvoiceNo;

				StringBuilder sbRow = new StringBuilder();
				StringBuilder sbH1 = new StringBuilder();
				StringBuilder sbH2 = new StringBuilder();

				//
				//  HEADER
				//
				sbH1.Append(CSV("TRANSACTION IDENTIFIER CODE"));
				sbH1.Append(CSV("SUBCONTRACT_NR"));
				sbH1.Append(CSV("INVOICE TYPE"));
				sbH1.Append(CSV("INVOICE NR"));
				sbH1.Append(CSV("INVOICE DATE"));
				sbH1.Append(CSV("CARRIER CD (SCAC)"));
				sbH1.Append(CSV("INVOICE TOTAL"));
				sbH1.Append(CSV("ADVANCE INVOICE NUMBER"));
				sbH1.Append(CSV(""));
				sbH1.Append(CSV("PCFN"));
				sbH1.Append(CSV("ACTIVITY DATE"));

				DataRow drHdr = dtInvoiceHeader.Rows[0];
				sbH2.Append(CSV("HDR"));
				sbH2.Append(CSV("HTC711-12-D-W004"));
				sbH2.Append(CSV("STANDARD"));
				sbH2.Append(CSV(sInvoice));
				string x = DateTime.Today.ToString();
				x = FormatDateToEight(x);
				sbH2.Append(CSV(x));
				sbH2.Append(CSV("AROF"));
				decimal dInvoiceTotal = GetInvoiceTotal(dtInvoiceOut);
				sbH2.Append(CSV(dInvoiceTotal.ToString()));
				sbH2.Append(CSV(""));
				sbH2.Append(CSV(""));
				sbH2.Append(CSV(sPCFNShort));
				x = drHdr["sail_dt"].ToString();
				x = FormatDateToEight(x);
				sbH2.Append(CSV(x));

				sbRow.AppendFormat(CSV("TRANS IDENTIFIER CODE"));
				sbRow.AppendFormat(CSV("BB CONTAINER IND"));
				sbRow.AppendFormat(CSV("PCFN"));
				sbRow.AppendFormat(CSV("LIFT DATE"));
				sbRow.AppendFormat(CSV("SAIL DATE"));
				sbRow.AppendFormat(CSV("SCAC"));
				sbRow.Append(CSV("TCN"));
				sbRow.Append(CSV("ADVANCE INVOICE NUMBER"));
				sbRow.Append(CSV("POD"));
				sbRow.Append(CSV("POE"));
				sbRow.Append(CSV("CONSIGNOR"));
				sbRow.Append(CSV("CONSIGNEE"));
				sbRow.Append(CSV("RATE TYPE"));
				sbRow.Append(CSV("PAYMENT RATE"));
				sbRow.Append(CSV("PAYMENT AMOUNT"));
				sbRow.Append(CSV("UNIT OF MEASURE"));
				sbRow.Append(CSV("TCON"));
				sbRow.Append(CSV("MTON"));
				sbRow.Append(CSV("QTY/PIECE"));
				sbRow.Append(CSV("WT"));
				sbRow.Append(CSV("VAN SIZE CD"));
				sbRow.Append(CSV("LENGTH"));
				sbRow.Append(CSV("WIDTH"));
				sbRow.Append(CSV("HEIGHT"));
				sbRow.Append(CSV("CUBE"));
				sbRow.Append(CSV("VAN TYPE CD"));
				sbRow.Append(CSV("VAN TYPE PACK"));
				sbRow.Append(CSV("VSTAT"));
				sbRow.Append(CSV("ROUTE ID"));
				sbRow.Append(CSV("VESSEL_NAME"));
				sbRow.Append(CSV("VOYDOC"));
				
				
				using (System.IO.StreamWriter file = new System.IO.StreamWriter(sInvoiceFile))
				{
					file.WriteLine(sbH1.ToString());
					file.WriteLine(sbH2.ToString());
					file.WriteLine(sbRow.ToString());
					foreach (DataRow dr in dtInvoiceOut.Rows)
					{
						StringBuilder s = new StringBuilder();

						// Get Detail data
						s.Append(CSV("DTL"));

						x = dr["cargo_type"].ToString();		/* Cargo Type */
						s.Append(CSV(x));

						s.Append(CSV(sPCFNShort));			/* PCFN		*/

						x = drHdr["sail_dt"].ToString();
						x = FormatDateToEight(x);
						s.Append(CSV(x));						/* Lift Date */
						s.Append(CSV(x));						/* Saile Date */

						s.Append(CSV("AROF"));

						x = dr["serial_no"].ToString();				/* Serial Number */
						s.Append(CSV(x));

						s.Append(CSV(" "));

						//////////////////////////////////////////////////////////////////////
						// I question the order of these.  I think it should be pod/pol.  But
						// I've switched them to match Robin's examples.
						x = drHdr["pol_sddc_cd"].ToString();
						s.Append(CSV(x));

						x = drHdr["pod_sddc_cd"].ToString();
						s.Append(CSV(x));
						//////////////////////////////////////////////////////////////////////

						x = drHdr["consignor_sddc_cd"].ToString();
						s.Append(CSV(x));

						x = drHdr["consignee_sddc_cd"].ToString();
						s.Append(CSV(x));

						x = dr["surcharge_cd"].ToString();
						x = XlateChargeCd(x);
						s.Append(CSV(x));

						x = dr["charge_rate"].ToString();
						s.Append(CSV(x));

						x = dr["charge_total"].ToString();
						s.Append(CSV(x));

						x = dr["charge_per_unit"].ToString();
						x = XlateUM(x);
						s.Append(CSV(x));							/*  unit of measure */

						s.Append(CSV(""));
						
						x = dr["cft40_computed"].ToString();		/* MTON				*/
						s.Append(CSV(x));

						s.Append(CSV("1"));							/* Pieces */

						x = dr["weight_lbs"].ToString();
						s.Append(CSV(x));

						s.Append(CSV(""));

						x = dr["length_in"].ToString();
						s.Append(CSV(x));
						x = dr["width_in"].ToString();
						s.Append(CSV(x));
						x = dr["height_in"].ToString();
						s.Append(CSV(x));
						
						x = dr["cft_computed"].ToString();			/* Cubic Inches)*/
						s.Append(CSV(x));
						//decimal dCft = ClsConvert.ToDecimal(x);
						//long iCinches = (long)Math.Round(dCft * 1728M, 0);
						//x = iCinches.ToString("0:0000000000000");
						//s.Append(x);

						s.Append(CSV("Z"));							/* Van Type Cd */

						s.Append(CSV("VO"));						/* Van Type Pack */

						x = drHdr["move_type_cd"].ToString();
						s.Append(CSV(x));

						x = drHdr["route_id"].ToString();				/* Route */
						s.Append(CSV(x));

						x = drHdr["vessel_nm"].ToString();				/* Vessel name */
						s.Append(CSV(x));

						x = drHdr["acmsvoydoc"].ToString();			/* VoyDoc */
						s.Append(CSV(x));

						//s.Append(PadTrim("", 19));				    /* Pallet ID */

						//s.Append(PadTrim("", 8));					/* Delivery Date*/

						file.WriteLine(s.ToString());
					}
				}
				Program.Show("Invoice created: {0} ", sInvoiceFile);
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		protected decimal GetInvoiceTotal(DataTable dt)
		{
			decimal dTotal = 0;
			foreach (DataRow dr in dtInvoiceOut.Rows)
			{
				string sType = dr["trans_id_cd"].ToString();
				if (sType != "DTL")
					continue;
				string sAmt = dr["charge_total"].ToString();
				decimal? dAmt = ClsConvert.ToDecimalNullable(sAmt);
				dTotal = dTotal + dAmt.GetValueOrDefault();
			}
			return dTotal;
		}

		protected string CSV(string sString)
		{
			return '"' + sString + '"' + "\t";
		}
		protected string PadTrim(string sString, int iLength)
		{
			// Pad or Trim a string as required to make it a specific length.
			string x = sString.Trim();
			if (x.Length < iLength)
				x = x.PadRight(iLength);
			if (x.Length > iLength)
				x = x.Substring(0, iLength);
			return x;
		}

		protected string FormatNumeric_8d2(string sString)
		{
			string sBlank = "00000000.00";
			decimal? dString = ClsConvert.ToDecimalNullable(sString);
			if (dString == null)
				return sBlank;
			string x = String.Format("{0:00000000.00}", dString);
			return x;
		}

		protected string FormatNumeric_9d2(string sString)
		{
			string sBlank = "000000000.00";
			decimal? dString = ClsConvert.ToDecimalNullable(sString);
			if (dString == null)
				return sBlank;
			string x = String.Format("{0:000000000.00}", dString);
			return x;
		}

		protected string FormatNumeric_10(string sString)
		{
			string sBlank = "00000000000";
			decimal? dString = ClsConvert.ToDecimalNullable(sString);
			if (dString == null)
				return sBlank;
			string x = String.Format("{0:00000000000}", dString);
			return x;
		}

		protected string FormatDateToEight(string sDate)
		{
			// Expects date as 'mm/dd/yyyy hh:mm' string and converts to
			// eight-character YYYYMMDD string.
			string sBlank = "        ";
			try
			{
				string sFormat = "yyyyMMdd"; 
				DateTime? dt = ClsConvert.ToDateTime(sDate);
				if (dt == DateTime.MinValue)
					return sBlank;
				string x = dt.GetValueOrDefault().ToString(sFormat);
				return x;
			}
			catch
			{
				// If it cannot convert to date, return blanks
				return sBlank;
			}
		}
		
		private void grdWorkFormat_FormattingRow(object sender, RowLoadEventArgs e)
		{

		}

		private void tsGenerateInvoice_Click(object sender, EventArgs e)
		{
			CreateSDDCInvoiceExcel();
		}

		private void tsQueryLINE_Click(object sender, EventArgs e)
		{
			panelSearch.Visible = true;

		}
		#endregion


	}
	#region Invoice Class
	public class SddcInvoiceInput
	{
		public string _Row_Type;
		public string _Bol_No;
		public string _Customer_Ref_Cd;
		public string _Service_Cd;
		public string _Vessel_Cd;
		public string _Voyage_No;
		public string _ACMSvoydoc;
		public string _Route_ID;
		public string _Plor_Location_Cd;
		public string _Pol_Location_Cd;
		public string _Pol_Berth;
		public string _Pol_SDDC_Cd;
		public string _Pod_Location_Cd;
		public string _Pod_Berth;
		public string _Pod_SDDC_Cd;
		public string _Plod_Location_Cd;
		public string _Tariff_Cd;
		public string _Move_Type_Cd;
		public string _Booking_No;
		//public DateTime _Sail_Dt;
		public string _Sail_Dt;
		public string _SCAC;
		public string _Associated_BOLs;
		private string _Consignor_cd;
		private string _Consignor_SDDC_Cd;
		private string _Consignor_Addr;
		private string _Consignee_cd;
		private string _Consignee_SDDC_Cd;
		private string _Consignee_Addr;


		public string Row_Type		{			get { return _Row_Type; }		}
		public string Bol_No { get { return _Bol_No; } }
		public string Customer_Ref_Cd { get { return _Customer_Ref_Cd; } }
		public string Service_Cd { get { return _Service_Cd; } }
		public string Vessel_Cd { get { return _Vessel_Cd; } }
		public string Voyage_No { get { return _Voyage_No; } }
		public string ACMSvoydoc { get { return _ACMSvoydoc; } }
		public string Route_ID { get { return _Route_ID; } }
		public string Plor_Location_Cd { get { return _Plor_Location_Cd; } }
		public string Pol_Location_Cd { get { return _Pol_Location_Cd; } }
		public string Pol_Berth { get { return _Pol_Berth; } }
		public string Pol_SDDC_Cd { get { return _Pol_SDDC_Cd; } }
		public string Pod_Location_Cd { get { return _Pod_Location_Cd; } }
		public string Pod_Berth { get { return _Pod_Berth; } }
		public string Pod_SDDC_Cd { get { return _Pod_SDDC_Cd; } }
		public string Plod_Location_Cd { get { return _Plod_Location_Cd; } }
		public string Tariff_Cd { get { return _Tariff_Cd; } }
		public string Move_Type_Cd { get { return _Move_Type_Cd; } }
		public string Booking_No { get { return _Booking_No; } }
		public string Sail_Dt { get { return _Sail_Dt; } }
		public string SCAC { get { return _SCAC; } }
		public string Associated_BOLs { get { return _Associated_BOLs; } }
		public string Consignor_Cd
		{
			get { return _Consignor_cd; }
			set { _Consignor_cd = value; }
		}
		public string Consignor_SDDC_Cd
		{
			get { return _Consignor_SDDC_Cd; }
			set { _Consignor_SDDC_Cd = value; }
		}
		public string Consignor_Addr
		{
			get { return _Consignor_Addr; }
			set { _Consignor_Addr = value; }
		}

		public string Consignee_Cd
		{
			get { return _Consignee_cd; }
			set { _Consignee_cd = value; }
		}
		public string Consignee_SDDC_Cd
		{
			get { return _Consignee_SDDC_Cd; }
			set { _Consignee_SDDC_Cd = value; }
		}
		public string Consignee_Addr
		{
			get { return _Consignee_Addr; }
			set { _Consignee_Addr = value; }
		}
	}
	#endregion
}

	