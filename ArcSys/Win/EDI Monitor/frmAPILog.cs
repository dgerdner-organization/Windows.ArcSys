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
	public partial class frmAPILog : frmChildBase, ISearchWindow
	{
		#region Fields


		string BookingNo { get { return txtBookingNo.Text; } }

		string SerialNo { get { return txtSerialNo.Text; } }
 
		private DataTable dtPartners;
        private DataTable dtApiLog;
		private DataTable dtMapTypes;

        ClsApiLog currentAPI
        {
            get
            {
                DataRow drow = grdMain.GetDataRow();
                if (drow == null)
                    return null;
                ClsApiLog al = new ClsApiLog(drow);
                return al;
            }
        }
		#endregion		// #region Fields

		#region Constructors/Initialization/Entry

		public frmAPILog()
			: base()
		{
			InitializeComponent();

            dtPartners = ClsApiLog.GetPartnersDropdown();
			cmbPartner.DataSource = dtPartners;
            dtMapTypes = ClsApiLog.GetAPINameDropdown();
			cmbMapTypes.DataSource = dtMapTypes;

			AdjustForm(Program.MainWindow, true, null);

			WindowHelper.InitAllGrids(this);
			ClsSecurityMaster.SetSecurity(this, ClsEnvironment.User_Id.Value);
            SetDefaults();
            //SearchParameters();
		}

		public void ShowSearch(bool showOptions)
		{
			try
			{
                //WindowHelper.InitAllGrids(this, false);
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
                APILogSearchParms parms = new APILogSearchParms();

                // Map /Type
                int ix = cmbMapTypes.SelectedIndex;
                if (ix < 0)
                {
                    parms.APIName = "";
                }
                else
                {
                    DataRow dr = dtMapTypes.Rows[ix];
                    parms.APIName = dr[0].ToString();

                }

                // BookingNumber
                parms.DocumentNo = BookingNo;

                // Trading Partner
                ix = cmbPartner.SelectedIndex;
                if (ix < 0)
                {
                    parms.TradingPartner = "";
                }
                else
                {
                    DataRow dr = dtPartners.Rows[ix];
                    parms.TradingPartner = dr[0].ToString();
                }

                parms.JustFails = cbxUnprocessed.Checked;
                parms.SerialNo = SerialNo;
                parms.DaysHistory = ClsConvert.ToInt32(txtDays.Text);;
               
                
				TimeSpan time = DateTime.Now - start;
				lock (grdMain)
				{
                    dtApiLog = ClsApiLog.SearchApiLog(parms);
                    //grdMain.DataSource = dtApiLog;
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
				//GetDetail();
			}
		}

		private void UpdateGrid()
		{
			try
			{
				AdjustGUI(true);

				lock (grdMain)
				{
                    grdMain.DataSource = dtApiLog;
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

		#region Other Methods


		private void SetDefaults()
		{
			SetDefaults(true);
		}

		private void SetDefaults(bool bInitial)
		{
			WindowHelper.ClearAllControls(this);

			txtDays.Text = "7";
            cmbDayPicker.SelectedIndex = 1;
			cmbMapTypes.SelectedIndex = -1;
			txtBookingNo.Text = "";

			txtSerialNo.Text = "";

            cbxUnprocessed.Checked = true;
			if (bInitial)
				return;
			cmbPartner.SelectedIndex = 0;
		}


        private void GetDetail()
        {
            if (!AsynchronousProcessComplete)
                return;
            try
            {
                if (currentAPI == null)
                    return;
                txtJson.Text = currentAPI.Json_Sent;
                txtMessage.Text = currentAPI.Api_Msg;
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }

        private void ClearLog()
        {
            DialogResult dr = MessageBox.Show("Clear all Failed entries?", "Confirm", MessageBoxButtons.OKCancel);
            if (dr == DialogResult.Cancel)
                return;

            ClsApiLog.ClearLog();
            
            //foreach (DataRow drow in grdMain.GetCheckedDataRows())
            //{
            //    ClsApiLog log = new ClsApiLog(drow);
            //    if (log.Success_Cd.ToUpper() != "FAIL")
            //    {
            //        iSkipped++;
            //        continue;
            //    }
            //    log.DeleteRow();
            //    iCounter++;
            //}
            //PerformSearch();
            //string sMsg = string.Format(@"{0} rows were removed from the API Log", iCounter);
            //Program.Show(sMsg);
            //if (iSkipped > 0)
                Program.Show("Note: All Failed entries and those over six months were deleted. ");
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
			SetDefaults(false);
		}


        private void cmbDayPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtDays.Text = cmbDayPicker.SelectedItem.ToString();
        }

        private void grdMain_ColumnButtonClick(object sender, ColumnActionEventArgs e)
        {
            GetDetail();
        }

        private void ucButton1_Click(object sender, EventArgs e)
        {
            ClearLog();
        }

        private void grdMain_SelectionChanged(object sender, EventArgs e)
        {
            if (AsynchronousProcessComplete)
                GetDetail();
        }

        
		#endregion		// #region Form Event Handlers










	}
}