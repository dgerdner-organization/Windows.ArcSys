using System;
using System.Data;
using System.Data.Common;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using CS2010.Common;
using CS2010.CommonWinCtrls;
using CS2010.CommonSecurity;
using CS2010.ArcSys.Business;
using Janus.Windows.GridEX;
using System.IO;
using System.Collections.Generic;

namespace CS2010.ArcSys.Win
{
	public partial class frmManualITV : frmChildBase, ISearchWindow
	{
		#region Fields
		string TradingPartnerCd
		{
			get 
			{
				int ix = cmbPartner.SelectedIndex;
				if (ix < 0)
					return "";
				DataRow dr = dtPartners.Rows[ix];
				ClsTradingPartner tp = new ClsTradingPartner(dr);
				return tp.Trading_Partner_Cd;
			}
		}
		string BookingNo { get { return txtBookingNo.Text; } }
		string SerialNo { get { return txtSerialNo.Text; } }
		string VoyageNo { get { return txtVoyage.Text; } }
		string PCFN { get { return txtPCFN.Text; } }

		ClsLocation currentLocation
		{
			get
			{
				int ix = cmbLocation.SelectedIndex;
				if (ix < 0)
					return null;
				DataRow dr = dtLocations.Rows[ix];
				ClsLocation loc = new ClsLocation(dr);
				return loc;
			}
		}
		string LocationCd
		{
			get
			{
				if (currentLocation == null)
					return "";
				return currentLocation.Location_Cd;
			}
		}
		string TerminalCd
		{
			get
			{
				if (cmbTerminal.SelectedIndex < 0)
					return null;
				object obj = cmbTerminal.SelectedItem;
				DataRowView drv = (DataRowView)obj;
				DataRow dr = drv.Row;
				string s = dr["terminal_cd"].ToString();
				return s;
			}
		}
		DateTime ActivityDate
		{
			get { return calActivityDate.DateTime; }
		}
		string StatusCode
		{
			get
			{
				int ix = cmbStatusCodes.SelectedIndex;
				if (ix < 0)
					return "";
				DataRow dr = dtStatusCodes.Rows[ix];
				ClsItvActivityCode sc = new ClsItvActivityCode(dr);
				return sc.Activity_Cd;
			}
		}
		string LocationType
		{
			get
			{
				if (rbLand.Checked)
					return "LAND";
				return "PORT";
			}
		}
			
		private DataTable dtPartners;
		private DataTable dtITVHistory;
		private DataTable dtLocations;
		private DataTable dtTerminals;
		private DataTable dtStatusCodes;

		#endregion		// #region Fields

		#region Constructors/Initialization/Entry

		public frmManualITV()
			: base()
		{
			InitializeComponent();

			AdjustForm(Program.MainWindow, true, null);

			WindowHelper.InitAllGrids(this);

			ClsSecurityMaster.SetSecurity(this, ClsEnvironment.User_Id.Value);
			dtStatusCodes = ClsItvActivityCode.GetAll();
			cmbStatusCodes.DataSource = dtStatusCodes;
			dtPartners = ClsTradingPartner.GetUserPartners();
			cmbPartner.DataSource = dtPartners;

			ResetForm();
		}

		public void ResetForm()
		{
			WindowHelper.ClearAllControls(this);
			SetSearchMode(true);
			//grdMain.UnCheckAllRecords();
			SetLocationSource();
		}
		public void ShowSearch(bool showOptions)
		{
			try
			{
				//if (showOptions == true) SearchParameters();
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		public void RefreshResults()
		{
			throw new NotImplementedException();
		}

		private void frmSearchContractMod_Load(object sender, EventArgs e)
		{
			try
			{
				btnSearch.Focus();
				ActiveControl = btnSearch;
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}
		#endregion		// #region Constructors/Initialization/Entry

		#region Search Methods

		private void SearchParameters()
		{
			try
			{

				PerformSearch();
			}
			catch (Exception ex)
			{
				Program.ShowError(ex.Message);
			}
		}

		private void PerformSearch()
		{
			try
			{
				if (Program.MainWindow != null)
					Program.MainWindow.SetMainMenuStatus(false);

				AdjustGUI(false);

				StartAsynchronousProcess(StartSearch, UpdateGrid, ResetCounter);
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		//private TimeSpan ElapsedTime;

		private void StartSearch()
		{
			try
			{
				DateTime start = DateTime.Now;
				ClsCommercialEDIQueries.EDIQueryParms parms = new ClsCommercialEDIQueries.EDIQueryParms();
				parms.BookingNo = BookingNo;
				parms.SerialNo = SerialNo;
				parms.PartnerCd = TradingPartnerCd;
				parms.VoyageNo = VoyageNo;
				parms.PCFN = PCFN;
				parms.POLCd = txtPOL.Text;
				parms.PODCd = txtPOD.Text;
				dtITVHistory = ClsCommercialEDIQueries.SearchCargo(parms, true);
				dtStatusCodes = ClsItvActivityCode.GetForPartner(TradingPartnerCd);
				cmbStatusCodes.DataSource = dtStatusCodes;
				TimeSpan time = DateTime.Now - start;
			}
			catch (Exception ex)
			{
				if (ex.Message.
					IndexOf("Cancel", StringComparison.InvariantCultureIgnoreCase) < 0)
					Program.ShowError(ex);
				else
					Program.ShowError("Search cancelled by user");
			}
			finally
			{
				AsynchronousProcessComplete = true;
			}
		}

		private void UpdateGrid()
		{
			try
			{
				AdjustGUI(true);

				lock (grdMain)
				{
					grdMain.DataSource = dtITVHistory;
					grdMain.RootTable.FilterCondition = null;
					grdMain.Focus();
				}

			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
			finally
			{
				if (Program.MainWindow != null)	
					Program.MainWindow.SetMainMenuStatus(true);
			}
		}

		private void ResetCounter()
		{
			try
			{
				AdjustGUI(true);
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
			finally
			{
				if (Program.MainWindow != null)	
					Program.MainWindow.SetMainMenuStatus(true);
			}
		}

		private void AdjustGUI(bool state)
		{
			try
			{
				lock (grdMain)
				{
					sbrChild.Visible = sbbProgressCaption.Visible =
						sbbProgressMeter.Visible = !state;
					grdMain.Enabled = state;
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void sbbProgressCaption_Click(object sender, EventArgs e)
		{
			CancelAsynchronousProcess();
		}
		#endregion		// #region Search Methods

		#region Create Methods
		protected void CreateITV()
		{
			try
			{
				if (string.IsNullOrEmpty(TradingPartnerCd))
				{
					Program.Show("You must select a trading partner");
					return;
				}
				if (string.IsNullOrEmpty(StatusCode))
				{
					Program.Show("Activity Code is required");
					return;
				}
				if (ActivityDate.IsNull())
				{
					Program.Show("Date is quired");
					return;
				}
				if (ActivityDate.Date > DateTime.Today)
				{
					Program.Show("Date cannot be in the future");
					return;
				}
				if (string.IsNullOrEmpty(LocationCd))
				{
					Program.Show("Location is required");
					return;
				}
				if (grdMain.GetCheckedDataRows() == null)
				{
					Program.Show("You must select at least one piece of cargo");
					return;
				}

				int iCount = 0;
				foreach (DataRow drow in grdMain.GetCheckedDataRows())
				{
					string sVoyageNo = drow["voyage_no"].ToString();
					string sBookingNo = drow["booking_no"].ToString();
					string sBOLNo = drow["bol_no"].ToString();
					string sTerminalCd = TerminalCd;

					ClsItv itv = new ClsItv();
					itv.Trading_Partner_Cd = TradingPartnerCd;
					itv.Activity_Cd = StatusCode;
					itv.Activity_Dt = ActivityDate;
					itv.Bol_No = "ZZZ";
					itv.Booking_No = sBookingNo;
					itv.Cargo_Key = drow["cargo_key"].ToString();
					itv.Cargo_Line_ID = ClsConvert.ToDecimalNullable( drow["cargo_line_id"].ToString());
					itv.Location_Cd = LocationCd;
					itv.Plor_Location_Cd = drow["plor_location_cd"].ToString();
					itv.Plod_Location_Cd = drow["plod_location_cd"].ToString();
					itv.Pol_Location_Cd = drow["pol_location_cd"].ToString();
					itv.Pod_Location_Cd = drow["pod_location_cd"].ToString();
					itv.Serial_No = drow["serial_no"].ToString();
					itv.Vessel_Cd = drow["vessel_cd"].ToString();
					itv.Voyage_No = sVoyageNo;
					itv.Create_Dt = Program.CurrentDate;
					itv.Modify_Dt = Program.CurrentDate;
					itv.Create_User = ClsUser.CurrentUser.User_Login;
					itv.Modify_User = ClsUser.CurrentUser.User_Login;
					itv.SetActualArriveFlg();
					itv.SetActualDepartFlg();

					if (TradingPartnerCd == "NAC")
						CustomNAC(ref itv);

					// Validate voyage/location/terminal
					if (!ValidateLocation(sVoyageNo))
					{
						string sMsg = string.Format("Error on Booking {3} : {0}/{1} is not on voyage {2} ",
							LocationCd, TerminalCd, sVoyageNo, sBookingNo);
						DialogResult dResult = MessageBox.Show(sMsg, "Warning", MessageBoxButtons.OKCancel);
						//Program.Show("Error on Booking {3} : {0}/{1} is not on voyage {2} ",
						//	LocationCd, TerminalCd, sVoyageNo, sBookingNo);
						if (dResult == DialogResult.Cancel)
							return;
						continue;
					}
					if (!itv.SetArriveDt())
					{
						MessageBox.Show("Error setting estimated arrival date");
						continue;
					}
					if (!itv.SetDepartDt())
					{
						MessageBox.Show("Error setting estimated Depart date");
						continue;
					}

					iCount++;
					itv.Insert();
				}
				Program.Show("{0} ITV activities created", iCount);
				if (iCount > 0)
					ResetForm();
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void CustomNAC(ref ClsItv itv)
		{
			itv.Isa_Nbr = 999999;
		}

		private bool ValidateLocation(string sVoy)
		{
			if (!currentLocation.IsPort)
				return true;
			DataTable dtVRD = ClsLocation.GetVoyageRouteDetails(sVoy, LocationCd, TerminalCd);
			if (dtVRD == null)
				return false;
			if (dtVRD.Rows.Count < 1)
				return false;
			return true;
		}
		#endregion

		#region Other Methods
		protected void SetSearchMode(bool bSearch)
		{
			pnlSearchCreate.Panel1.Enabled = bSearch;
			pnlSearchCreate.Panel2.Enabled = !bSearch;
		}
		protected void SetLocationSource()
		{
			dtLocations = ClsLocation.GetLocationsByType(LocationType);
			cmbLocation.DataSource = dtLocations;
			cmbLocation.SelectedIndex = -1;
		}
		protected void SetLocationDefault()
		{
			DataRow drow;
			DataRow[] drs = grdMain.GetCheckedDataRows();
			List<DataRow> drows = grdMain.GetDataRowList();
			if (drs != null && drs.Length > 0)
				drow = drs[0];
			else
			{
				if (drows.Count > 0)
					drow = drows[0];
				else
					return;
			}

			string sPOL = drow["pol_location_cd"].ToString();
			string sPOD = drow["pod_location_cd"].ToString();
			string sPLOD = drow["plod_location_cd"].ToString();
			string sPLOR = drow["plor_location_cd"].ToString();
			// Certain locations defult based on activity
			if (StatusCode == "VD" || StatusCode == "AE" || StatusCode == "I")
			{
				rbPorts.Checked = true;
				cmbLocation.Text = sPOL;
			}
			if (StatusCode == "VA" || StatusCode == "OA" || StatusCode == "UV")
			{
				rbPorts.Checked = true;
				cmbLocation.Text = sPOD;
			}
			if (StatusCode == "X1")
			{
				SetPortLand(sPLOD);
				cmbLocation.Text = sPLOD;
			}
			if (StatusCode == "W")
			{
				SetPortLand(sPLOR);
				cmbLocation.Text = sPLOR;
			}
		}

		protected void SetPortLand(string sLoc)
		{
			// Set the port/land radiobutton based on 
			// the default location
			ClsLocation loc = ClsLocation.GetUsingKey(sLoc);
			if (loc.IsLand)
				rbLand.Checked = true;
			else
				rbPorts.Checked = true;
		}
		#endregion

		#region Grid Operations/Event Handlers

		public static void RefreshRow()
		{
			try
			{
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}
		
		private void grdResults_DoubleClick(object sender, EventArgs e)
		{
			try
			{
				//GridArea ga = grdResults.HitTest();
				//if (ga != GridArea.Cell) return;

				//EditAPInvoice();
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void grdResults_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				//if (e.KeyCode == Keys.Enter)
				//{
				//    GridEXRow gr = grdResults.GetRow();
				//    if (gr == null || gr.RowType != RowType.Record) return;

				//    EditAPInvoice();

				//    e.Handled = true;
				//}
				//else if (e.KeyCode == Keys.C && e.Control)
				//{
				//    GridEXRow r = grdResults.GetRow();
				//    GridEXColumn c = grdResults.CurrentColumn;
				//    if (r == null || c == null || string.IsNullOrEmpty(c.DataMember)) return;

				//    string s = ClsConvert.ToString(r.Cells[c].Text);
				//    if (!string.IsNullOrEmpty(s)) Clipboard.SetText(s);
				//}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}
				
		private void grdResults_ColumnButtonClick(object sender, ColumnActionEventArgs e)
		{
			try
			{

			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		#endregion		// #region Grid Operations/Event Handlers

		#region Form Event Handlers

		private void frmSearchContractMod_FormClosing(object sender, FormClosingEventArgs e)
		{
			try
			{
				if (e.CloseReason == CloseReason.WindowsShutDown) return;

				if (IsRunning)
				{
					e.Cancel = true;
					Program.Show("Cancel the search before closing the window");
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void btnSearch_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(TradingPartnerCd))
			{
				Program.Show("You must specify a trading partner");
				return;
			}
			SearchParameters();
			grdMain.UnCheckAllRecords();
		}

		private void btnClear_Click(object sender, EventArgs e)
		{
			WindowHelper.ClearAllControls(this);
			txtBookingNo.Text = "";
			txtPCFN.Text = "";
			txtSerialNo.Text = "";
			txtVoyage.Text = "";
			txtPOL.Text = "";
			txtPOD.Text = "";
		}


		private void pnlSearchCreate_SplitterMoved(object sender, SplitterEventArgs e)
		{

		}

		private void btnOpenCreate_Click(object sender, EventArgs e)
		{
			SetSearchMode(false);
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			SetSearchMode(true);

		}

		private void cmbLocation_ValueChanged(object sender, EventArgs e)
		{
			dtTerminals = ClsLocation.GetTerminals(LocationCd);
			cmbTerminal.DataSource = dtTerminals;
			if (dtTerminals.Rows.Count > 0)
				cmbTerminal.SelectedIndex = 0;
			else
				cmbTerminal.SelectedIndex = -1;
		}

		private void btnCreateSave_Click(object sender, EventArgs e)
		{
			CreateITV();
		}

		private void rbPorts_CheckedChanged(object sender, EventArgs e)
		{
			SetLocationSource();
		}

		private void rbLand_CheckedChanged(object sender, EventArgs e)
		{
			SetLocationSource();
		}

		private void cmbStatusCodes_ValueChanged(object sender, EventArgs e)
		{
			SetLocationDefault();
		}
		#endregion		// #region Form Event Handlers

		private void ucLabel1_Click(object sender, EventArgs e)
		{

		}

		private void ultraButton1_Click(object sender, EventArgs e)
		{
			cmbStatusCodes.SelectedIndex = -1;
			cmbLocation.SelectedIndex = -1;
			cmbTerminal.SelectedIndex = -1;
			calActivityDate.DateTime = DateTime.Today;
		}

	}
}