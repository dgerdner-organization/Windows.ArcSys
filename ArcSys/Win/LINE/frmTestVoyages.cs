using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Timers;
using CS2010.Common;
using CS2010.CommonSecurity;
using CS2010.CommonWinCtrls;
using CS2010.ArcSys.Business;
using Janus.Windows.GridEX;
using ASL.ARC.EDISQLTools;

namespace CS2010.ArcSys.Win
{
    public partial class frmTestVoyages : frmChildBase, ISearchWindow
    {
        #region Main Region
		private DataTable dtMain;
        private string VoyageNo
        {
            get
            {
                if (string.IsNullOrEmpty(txtVoyage.Text))
                    return "%";
                return txtVoyage.Text;
            }
        }
		private string Vessel
		{
			get { return cmbVessel.SelectedVesselCD; }
		}

        public frmTestVoyages()
            : base()
        {
            InitializeComponent();
            AdjustForm(Program.MainWindow, true, null);
            WindowHelper.InitAllGrids(this);
            ClsSecurityMaster.SetSecurity(this, ClsEnvironment.User_Id.Value);
        }

		public frmTestVoyages(string sBookingNo)
			: base()
		{
			InitializeComponent();
			AdjustForm(Program.MainWindow, true, null);
			WindowHelper.InitAllGrids(this);
			ClsSecurityMaster.SetSecurity(this, ClsEnvironment.User_Id.Value);
			PerformSearch();
		}

        public void RefreshResults()
        {
            throw new NotImplementedException();
        }

        public void ShowSearch(bool showOptions)
        {
            return;
        }

        #endregion

        #region Search Methods

        private void PerformSearch()
        {
            try
            {
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
                AsynchConnectionKey = "LINE";
                DateTime start = DateTime.Now;
                ClsImportLine q = new ClsImportLine();
                //dtCargo = q.QueryLINEData(VoyageNo, BookingNo, txtTCN.Text, cbxExceptions.Checked, POL, POD);
				dtMain = ClsQueries.SearchVoyages(Vessel, VoyageNo);

                TimeSpan time = DateTime.Now - start;
                lock (grdMain)
                {
                     ElapsedTime = time;
                }
 
            }
            catch (Exception ex)
            {
                if (ex.Message.
                    IndexOf("Cancel", StringComparison.InvariantCultureIgnoreCase) < 0 &&
                    ex.Message.IndexOf("should be discarded", StringComparison.InvariantCultureIgnoreCase) < 0)
                    Program.ShowError(ex);
                else
                    Program.ShowError("Search cancelled by user");
            }
            finally
            {
                AsynchronousProcessComplete = true;
                AsynchConnectionKey = null;
            }
        }

        private void UpdateGrid()
        {
            try
            {
                AdjustGUI(true);

                lock (grdMain)
                {
                    try
                    {
                        grdMain.DataSource = dtMain;
                        grdMain.Focus();
                    }
                    catch (Exception ex)
                    {
                        Program.ShowError(ex);
                    }
                }
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
            finally
            {
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
                Program.MainWindow.SetMainMenuStatus(true);
            }
        }

        private void AdjustGUI(bool state)
        {
            try
            {
                lock (grdMain)
                {
					ClsGridExUtils.SetFormats(grdMain);
                    tsSearchCargo.Enabled =  grdMain.Enabled = state;
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

        #region Events
        private void tsSearchCargo_Click(object sender, EventArgs e)
        {
            //SearchParameters();
            PerformSearch();
        }


		private void sbbProgressCaption_Click(object sender, EventArgs e)
		{
			CancelAsynchronousProcess();
		}

		private void frmSalesSummary_FormClosing(object sender, FormClosingEventArgs e)
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

		private void frmSalesSummary_FormClosed(object sender, FormClosedEventArgs e)
		{
			//SearchOptions = null;
		}

		private void btnSearch_Click(object sender, EventArgs e)
		{
			PerformSearch();
		}
        #endregion
		 
    }
}