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
	public partial class frmSearchEDIHistory : frmChildBase, ISearchWindow
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
		ClsLocation locationPOL
		{
			get
			{
				int ix = cmbPOL.SelectedIndex;
				if (ix < 0)
					return null;
				//DataRow dr = dtLocations.Rows[ix];
				//ClsLocation loc = new ClsLocation(dr);
				//return loc;
				return cmbPOL.SelectedLocation;
			}
		}
		ClsLocation locationPOD
		{
			get 
			{
				if (cmbPOD.SelectedIndex < 0)
					return null;
				return cmbPOD.SelectedLocation; 
			}
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

		string BookingNo { get { return txtBookingNo.Text; } }
		string SerialNo { get { return txtSerialNo.Text; } }
		string VoyageNo { get { return txtVoyage.Text; } }
		string PCFN { get { return txtPCFN.Text; } }
		string POL { get 
		{
			if (locationPOL == null)
				return null;
			return  locationPOL.Location_Cd; 
		} }
		string POD { get 
		{
			if (locationPOD == null)
				return null;
			return locationPOD.Location_Cd; 
		} }

		private DataTable dtTransmissions;
		private DataTable dtPartners;
		private DataTable dtITVHistory;
		private DataTable dtITVSummary;
		private DataTable dtStatusCodes;

		#endregion		// #region Fields

		#region Constructors/Initialization/Entry

		public frmSearchEDIHistory()
			: base()
		{
			InitializeComponent();

			dtPartners = ClsTradingPartner.GetUserPartners();
			cmbPartner.DataSource = dtPartners;
			dtStatusCodes = ClsItvActivityCode.GetAll();
			dtStatusCodes.Rows.Add("OB", "Bill of Lading", null, null, null, null);
			cmbStatusCodes.DataSource = dtStatusCodes;
			SetDefaults();

			AdjustForm(Program.MainWindow, true, null);

			WindowHelper.InitAllGrids(this);
			ClsSecurityMaster.SetSecurity(this, ClsEnvironment.User_Id.Value);
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
				if (dtPartners.Rows.Count > 0)
					cmbPartner.SelectedIndex = 0;
				else
				{
					Program.Show("You have no Trading Partners assigned.  Contact support.");
					btnSearch.Enabled = false;
				}
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

		private TimeSpan ElapsedTime;

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
				parms.ActivityCd = StatusCode;
				parms.POLCd = POL;
				parms.PODCd = POD;
				parms.iDays = ClsConvert.ToInt32Nullable(txtDays.Text);
				//dtTransmissions = ClsCommercialEDIQueries.SearchEDIHistory(parms);
				dtITVHistory = ClsCommercialEDIQueries.SearchITVHistory(parms);
				//dtITVSummary = ClsCommercialEDIQueries.SearchCargo(parms, true);
				TimeSpan time = DateTime.Now - start;
				lock (grdResults)
				{
					grdResults.DataSource = dtTransmissions;
					ElapsedTime = time;
				}
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
				lock (grdITVSummary)
				{
					grdITVSummary.DataSource = dtITVSummary;
					grdITVSummary.RootTable.FilterCondition = null;
				}
				lock (grdResults)
				{
					grdResults.DataSource = dtTransmissions;
					grdResults.RootTable.FilterCondition = null;
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
				lock (grdResults)
				{
					sbrChild.Visible = sbbProgressCaption.Visible =
						sbbProgressMeter.Visible = !state;
					grdResults.Enabled = state;
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

		#region Other Methods
		private void EditFile()
		{
			DataRow dr = grdResults.GetDataRow();
			ClsEdiOutboundLog log = new ClsEdiOutboundLog(dr);
			ClsTradingPartnerEdi tpe = new ClsTradingPartnerEdi(dr);

			string sFullFileName = tpe.Archive_Path + "\\" + log.File_Nm;
			System.Diagnostics.Process.Start(sFullFileName);
		}

		private void OpenFile()
		{
			string sFile = grdMain.GetDataRow()["file_nm"].ToString();
			string sPartner = grdMain.GetDataRow()["trading_partner_cd"].ToString();
			string sMapNm =  grdMain.GetDataRow()["map_nm"].ToString();
			string sFullFileName = sFile;
			if (!string.IsNullOrEmpty(sMapNm))
			{
				ClsTradingPartnerEdi tpe = ClsTradingPartnerEdi.GetByMap(sPartner, sMapNm);
				sFullFileName = tpe.Archive_Path + "\\" + sFile;
			}
			System.Diagnostics.Process.Start(sFullFileName);						
			//ClsOpenEDIFile.OpenFile(sFile, sPartner, sMapNm);
		}

        private void ResendFile()
        {
            bool bBOL = false;
            if (MessageBox.Show("Resend selected files?", "Confirm", MessageBoxButtons.YesNo)
                != DialogResult.Yes) return;

            DataRow[] drows = grdMain.GetCheckedDataRows();
            foreach (DataRow dr in drows)
            {
                string sCode = dr["activity_cd"].ToString();
                string sPartner = dr["trading_partner_cd"].ToString();
                string sBOL = dr["bol_no"].ToString();
                if (sCode == "OB" && sPartner == "IAL")
                {
                    bBOL = true;
                    ResendIalBol(sBOL);
                }
                else
                {
                    string s = dr["itv_id"].ToString();
                    int i = ClsConvert.ToInt32(s);
                    ClsItv itv = ClsItv.GetUsingKey(i);
                    itv.Isa_Nbr = 1;
                    itv.Update();
                }
            }
        }

		private void ResendITV()
		{
			bool bBOL = false;
			if (MessageBox.Show("Resend selected cargo?", "Confirm", MessageBoxButtons.YesNo)
				!= DialogResult.Yes) return;
			try
			{
				DataRow[] drows = grdMain.GetCheckedDataRows();
				foreach (DataRow dr in drows)
				{
					string sCode = dr["activity_cd"].ToString();
					string sPartner = dr["trading_partner_cd"].ToString();
					string sBOL = dr["bol_no"].ToString();
					if (sCode == "OB" && sPartner == "IAL")
					{
						bBOL = true;
						ResendIalBol(sBOL);
					}
					else
					{
						string s = dr["itv_id"].ToString();
						int i = ClsConvert.ToInt32(s);
						ClsItv itv = ClsItv.GetUsingKey(i);
                        itv.Isa_Nbr = 1;
						itv.Update();
					}
				}
				if (bBOL)
				{
					Program.Show("BOLs have been flagged to be resent");
					int iCount = ClsVIalBolOut.GetAll().Rows.Count;
					string sMsg = string.Format("{0} bill(s) will be sent to IAL within the next few minutes.", iCount);
					Program.Show(sMsg);
				}
				else
					Program.Show("Cargo ITV has been flagged to resend.");
				SearchParameters();
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void ResendIalBol(string sBOL)
		{
			ClsEdiOutboundBol.Resend(sBOL);
		}

		private void MoveFiles()
		{
			/* OBSOLETE FOR NOW */
			try
			{
				if (MessageBox.Show("Move Selected Files?", "Confirm", MessageBoxButtons.YesNo)
					!= DialogResult.Yes) return;

				DataRow dr = grdResults.GetDataRow();
				ClsEdiOutboundLog log = new ClsEdiOutboundLog(dr);
				ClsTradingPartnerEdi tpe = new ClsTradingPartnerEdi(dr);

				string sFullFileName = tpe.Archive_Path + "\\" + log.File_Nm;
				string sDestination = tpe.File_Path + "\\" + log.File_Nm;
				File.Move(sFullFileName, sDestination);
				Program.Show("File has been moved to staging area so it will be re-sent to trading partner");
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void SetDefaults()
		{
			WindowHelper.ClearAllControls(this);
			cmbPOD.SelectedIndex = -1;
			cmbPOL.SelectedIndex = -1;
			cmbStatusCodes.SelectedIndex = -1;
			txtDays.Text = "30";
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

		private void cnuGridEditMod_Click(object sender, EventArgs e)
		{
			//EditAPInvoice();
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
			SearchParameters();
		}

		private void btnClear_Click(object sender, EventArgs e)
		{
			SetDefaults();
		}
		#endregion		// #region Form Event Handlers

		private void ucGridToolStrip1_ClickEdit(object sender, EventArgs e)
		{
			EditFile();
		}


		private void grdResults_LinkClicked(object sender, ColumnActionEventArgs e)
		{
			switch (e.Column.Key)
			{
				case "file_nm":
				case "isa_nbr":
					EditFile();
					break;
				default:
					Program.LinkHandler.HandleLink(grdResults.CurrentRow, e.Column.Key);
					break;
			}

		}

		private void grdMain_LinkClicked(object sender, ColumnActionEventArgs e)
		{
			try
			{
				if (e.Column.Key.ToLower() == "file_nm")
				{
					OpenFile();
					return;
				}
				if (e.Column.Key.ToLower() == "isa_nbr")
				{
					OpenFile();
					return;
				}
				Program.LinkHandler.HandleLink(grdResults.CurrentRow, e.Column.Key);
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void btnResend_Click(object sender, EventArgs e)
		{
			ResendITV();
		}


	}
}