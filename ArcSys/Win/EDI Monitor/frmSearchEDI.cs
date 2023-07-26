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
	public partial class frmSearchEDI : frmChildBase, ISearchWindow
    {
        #region Conneciton
        private static ClsConnection Connection
		{
			get
			{
				// "ArcSys" is the normal connecton string.  However, at least
				// one of our applications (SDDCEDI) uses "AROF" instead.
				if (ClsConMgr.Manager["AROF"] == null)
					return ClsConMgr.Manager["ArcSys"];
				return ClsConMgr.Manager["AROF"];
			}
		}
		#endregion

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
		//string sDays
		//{
		//    get
		//    {
		//        int ix = cmbDays.SelectedIndex;
		//        if (ix < 0)
		//            return "1";
		//        return cmbDays.SelectedText;

		//    }
		//}
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
		string MapType
		{
			get
			{
				int ix = cmbMapTypes.SelectedIndex;
				if (ix < 0)
					return  "(All)";
				DataRow dr = dtMapTypes.Rows[ix];
				return dr[0].ToString();
			}
		}
		private DataTable dtPartners;
		private DataTable dtITVHistory;
		private DataTable dtITVDetail;
		private DataTable dtStatusCodes;
		private DataTable dtMapTypes;

		private ClsIsa currentISA
		{
			get
			{
                    DataRow drow = grdMain.GetDataRow();
                    if (drow == null)
                        return null;
                    string s = drow["isa_id"].ToString();
                    Int64? i = ClsConvert.ToInt64Nullable(s);
                    ClsIsa isa = ClsIsa.GetUsingKey(i.GetValueOrDefault());
                    return isa;
			}
		}

        private string currentType
        {
            get
            {
                DataRow drow = grdMain.GetDataRow();
                if (drow == null)
                    return null;
                string s = drow["edi_type"].ToString();
                return s;
            }

        }
        private string currentFileNm
        {
            get
            {
                DataRow drow = grdMain.GetDataRow();
                if (drow == null)
                    return null;
                string s = drow["file_nm"].ToString();
                return s;
            }

        }
		#endregion		// #region Fields

		#region Constructors/Initialization/Entry

		public frmSearchEDI()
			: base()
		{
			InitializeComponent();

			//dtPartners = ClsTradingPartner.GetUserPartnersWithAll();
            dtPartners = ClsTradingPartner.GetAllActiveTradingPartners();
			cmbPartner.DataSource = dtPartners;
			dtStatusCodes = ClsItvActivityCode.GetAll();
			dtStatusCodes.Rows.Add("OB", "Bill of Lading", null, null, null, null);
			cmbStatusCodes.DataSource = dtStatusCodes;
			dtMapTypes = ClsTradingPartnerEdi.GetMapTypes(true);
			cmbMapTypes.DataSource = dtMapTypes;

			AdjustForm(Program.MainWindow, true, null);

			WindowHelper.InitAllGrids(this);
			ClsSecurityMaster.SetSecurity(this, ClsEnvironment.User_Id.Value);
            SetDefaults();
            SearchParameters();
		}

		public void ShowSearch(bool showOptions)
		{
			try
			{
                if (showOptions)
				    SearchParameters();
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


		private TimeSpan ElapsedTime;

        private void SearchParameters()
        {
            try
            {
                btnProcess.Enabled = cbxUnprocessed.Checked;
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
		private void StartSearch()
		{
			try
			{
				DateTime start = DateTime.Now;
				ClsEDIUtilities util = new ClsEDIUtilities();

				util.BookingNo = BookingNo;
				util.SerialNo = SerialNo;
				util.PartnerCd = TradingPartnerCd;
				util.VoyageNo = VoyageNo;
				util.PCFN = PCFN;
				util.ActionCd = StatusCode;
				util.MapType = MapType;
				util.PolCd = POL;
				util.PodCd = POD;
				util.Days = ClsConvert.ToInt32Nullable(txtDays.Text);
				util.VoyageNo = POD;
                util.UnprocessedOnly = false;
                if (cbxUnprocessed.Checked)
                    util.UnprocessedOnly = true;
                lock (grdMain)
                {
                    dtITVHistory = util.EDIMainQuery();
                    grdDetail.DataSource = null;
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

					grdMain.DataSource = dtITVHistory;
					grdMain.RootTable.FilterCondition = null;
					grdMain.Focus();
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


		#endregion		// #region Search Methods

		#region Other Methods

        private void DisplayLinkMessage(string sCol)
        {
            switch (sCol.ToUpper())
            {
                case "PCFN":
                case "PCFN_NO":
                case "REQUEST_CD":
                    {
                        Program.Show("This will open the ACMS Booking Request Window");
                        break;
                    }
                case "BOOKING_NO":
                    {
                        Program.Show("This will show you the Data Warehouse data for this booking");
                        break;
                    }
            }
        }
		private void OpenFile()
		{
			string sFile = grdMain.GetDataRow()["file_nm"].ToString();
			string sPartner = grdMain.GetDataRow()["trading_partner_cd"].ToString();
			string sMapNm =  grdMain.GetDataRow()["map_nm"].ToString();
            string sArk = grdMain.GetDataRow()["folder_nm"].ToString();
			string sFullFileName = sFile;
			if (!string.IsNullOrEmpty(sMapNm))
			{
				ClsTradingPartnerEdi tpe = ClsTradingPartnerEdi.GetByMap(sPartner, sMapNm);
                if (tpe != null)
                {
                    sFullFileName = tpe.Archive_Path + "\\" + sFile;

                    if (!File.Exists(sFullFileName))
                    {
                        if (ClsOpenEDIFile.OpenFileFromRootFolder(tpe.Archive_Path, sFile))
                        {
                            return;
                        }
                    }
                }
			}

            if (!File.Exists(sFullFileName))
            {
                if (ClsOpenEDIFile.OpenFileFromRootFolder(sArk, sFile))
                    return;
                Program.Show("The file {0} could not be found in folder {1} ", sFile, sArk);
            }
            System.Diagnostics.Process.Start("notepad.exe", sFullFileName);						
		}

		private void SetDefaults()
		{
			SetDefaults(true);
		}

		private void SetDefaults(bool bInitial)
		{
			WindowHelper.ClearAllControls(this);
			cmbPOD.SelectedIndex = -1;
			cmbPOL.SelectedIndex = -1;
			cmbStatusCodes.SelectedIndex = -1;
			txtDays.Text = "7";
            cmbDayPicker.SelectedIndex = 1;
			cmbMapTypes.SelectedIndex = -1;
			txtBookingNo.Text = "";
			txtPCFN.Text = "";
			txtSerialNo.Text = "";
			txtVoyage.Text = "";
            cbxUnprocessed.Checked = false;
            if (bInitial)
            {
                cbxUnprocessed.Checked = true;
                return;
            }
			cmbPartner.SelectedIndex = 0;
		}

        private ClsIsa GetISARow(DataRow drow)
        {
            // Given a drow from the main gride, find the corresponding t_isa object
            if (drow == null)
                return null;
            string s = drow["isa_id"].ToString();
            Int64? i = ClsConvert.ToInt64Nullable(s);
            ClsIsa isa = ClsIsa.GetUsingKey(i.GetValueOrDefault());
            return isa;
        }

        private void GetDetail()
        {
            try
            {
                ClsEDIUtilities u = new ClsEDIUtilities();
                ClsIsa isa = currentISA;
                if (isa == null)
                {
                    GetDetailAlternate();
                    return;
                }
                grdDetail.CurrentLayout = grdDetail.Layouts["layoutDefault"];
                if (isa.Edi_Type == "315" )
                    grdDetail.CurrentLayout = grdDetail.Layouts["layout315"];
                dtITVDetail = u.EDIisaQuery(isa);
                grdDetail.DataSource = dtITVDetail;
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }

        private void GetDetailAlternate()
        {
            // This is for non-edi files that are stored somewhere other than our t_isa, t_edixxx infrastructure
            try
            {
                string sType = currentType;
                if (sType == "ITV")
                {
                    GetIALITVDetail();
                }
                if (sType == "DTL")
                {
                    grdDetail.CurrentLayout = grdDetail.Layouts["layoutCargoDetail"];
                    GetIALCargoDetail();
                }

            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }

        private void GetIALITVDetail()
        {
            string sFileNm = currentFileNm;
            if (sFileNm.IsNullOrWhiteSpace())
                return;
            ClsEDIUtilities util = new ClsEDIUtilities();
            dtITVDetail = util.EDIisaIALQuery(sFileNm);
            grdDetail.DataSource = dtITVDetail;
        }

        private void GetIALCargoDetail()
        {
            string sFileNm = currentFileNm;
            if (sFileNm.IsNullOrWhiteSpace())
                return;
            ClsEDIUtilities util = new ClsEDIUtilities();
            DataTable dtDetail = util.EDIIALCargoDetail(sFileNm);
            grdDetail.DataSource = dtDetail;
        }

        private void ArchiveSelected()
        {
            DataRow[] drows = grdMain.GetCheckedDataRows();
            foreach (DataRow drow in drows)
            {
                ClsIsa isa = GetISARow(drow);
                if (isa.IsNull())
                    continue;
                List<DbParameter> p = new List<DbParameter>();
                p.Add(Connection.GetParameter("isaID", isa.Isa_ID));
                p.Add(Connection.GetParameter("ediType", isa.Edi_Type));

                string sql = string.Format(@"p_set_isa_processed");
                Connection.RunSQL(sql, CommandType.StoredProcedure, p.ToArray());
            }
            Program.Show("Selected items were archived");
            SearchParameters();

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



		#endregion		// #region Grid Operations/Event Handlers

		#region Form Event Handlers
        private void grdMain_LinkClicked(object sender, ColumnActionEventArgs e)
        {
            try
            {
                if (e.Column.Key.ToLower() == "file_nm")
                {
                    OpenFile();
                    return;
                }

                DisplayLinkMessage(e.Column.Key);
                Program.LinkHandler.HandleLink(grdMain.CurrentRow, e.Column.Key);
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }

        private void cmbDayPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtDays.Text = cmbDayPicker.SelectedItem.ToString();
        }

        private void grdMain_SelectionChanged(object sender, EventArgs e)
        {
            GetDetail();
        }

        private void grdDetail_LinkClicked(object sender, ColumnActionEventArgs e)
        {
            try
            {
                DisplayLinkMessage(e.Column.Key);
                Program.LinkHandler.HandleLink(grdDetail.CurrentRow, e.Column.Key);
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }

        }

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
			SetDefaults(false);
		}
        
        private void cbxUnprocessed_CheckStateChanged(object sender, EventArgs e)
        {
            //btnProcess.Enabled = cbxUnprocessed.Checked;
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            ArchiveSelected();
        }
        
        private void ucButton1_Click(object sender, EventArgs e)
        {
            SetDefaults(false);
            grdMain.RemoveFilters();
            cmbMapTypes.SelectedText = "301";
            cmbPartner.SelectedIndex = -1;
            cmbPartner.SelectedText = "TOPS";
            cbxUnprocessed.Checked = false;
            SearchParameters();

        }

        private void ucButton2_Click(object sender, EventArgs e)
        {
            SetDefaults(false);
            grdMain.RemoveFilters();
            cmbPartner.SelectedIndex = -1;
            cmbMapTypes.SelectedText = "HHG";
            cmbPartner.SelectedText = "USCRW";
            cbxUnprocessed.Checked = false;
            SearchParameters();
        }

        private void ucButton3_Click(object sender, EventArgs e)
        {
            SetDefaults(false);
            grdMain.RemoveFilters();
            cmbPartner.SelectedIndex = -1;
            cmbMapTypes.SelectedText = "310";
            cmbPartner.SelectedText = "TOPS";
            cbxUnprocessed.Checked = false;
            SearchParameters();
        }

        private void btnIALITV_Click(object sender, EventArgs e)
        {
            grdMain.RemoveFilters();
            SetDefaults(false);
            cmbMapTypes.SelectedText = "ITV";
            cmbPartner.SelectedIndex = -1;
            cmbPartner.SelectedText = "IAL";
            cbxUnprocessed.Checked = false;
            SearchParameters();
        }

        private void btnIALBOL_Click(object sender, EventArgs e)
        {
            grdMain.RemoveFilters();
            SetDefaults(false);
            cmbMapTypes.SelectedText = "OB";
            cmbPartner.SelectedIndex = -1;
            cmbPartner.SelectedText = "IAL";
            cbxUnprocessed.Checked = false;
            SearchParameters();
        }
		#endregion		// #region Form Event Handlers

        private void btnSDDC301_Click(object sender, EventArgs e)
        {
            grdMain.RemoveFilters();
            SetDefaults(false);
            cmbMapTypes.SelectedText = "301";
            cmbPartner.SelectedIndex = -1;
            cmbPartner.SelectedText = "SDDC";
            cbxUnprocessed.Checked = false;
            cmbDayPicker.SelectedIndex = 2;
            txtDays.Text = "360";
        }


	}
}