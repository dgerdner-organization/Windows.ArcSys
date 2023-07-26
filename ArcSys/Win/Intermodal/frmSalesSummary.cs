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

namespace CS2010.ArcSys.Win
{
    public partial class frmSalesSummary : frmChildBase, ISearchWindow
    {
        #region Main Region
        private DataTable dtCargo;
        private DataTable dtLINE;
        private frmSalesSummaryOptions SearchOptions;
        private bool ExcludeOcean
        {
            get
            { return tsExcludeOcean.Checked; }
        }
        private StringBuilder BookingList;

        public frmSalesSummary() : base()
        {
            InitializeComponent();
            AdjustForm(Program.MainWindow, true, null);
            SearchOptions = new frmSalesSummaryOptions();
            WindowHelper.InitAllGrids(this);
            ClsSecurityMaster.SetSecurity(this, ClsEnvironment.User_Id.Value);

        }

        public void ShowSearch(bool showOptions)
        {
            try
            {
                if (showOptions == true) SearchParameters();
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

        #endregion

        #region Search Methods

        private void SearchParameters()
        {
            try
            {
                if (SearchOptions.GetSearchCriteria() == false) return;

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
                // Retrieve ArcSys data
                DateTime start = DateTime.Now;
                dtCargo = SearchOptions.Options.GetSalesSummaryARC();
                TimeSpan time = DateTime.Now - start;
                lock (grdCargo)
                {
                     ElapsedTime = time;
                }

                // Get list of bookings
                BookingList = new StringBuilder();
                foreach (DataRow drow in dtCargo.Rows)
                {
                    string sBookingNo = drow["booking_no"].ToString();
                    if (BookingList.ToString().IndexOf(sBookingNo) < 0)
                    {
                        if (BookingList.Length > 1)
                        {
                            BookingList.Append(",");
                        }
                        BookingList.Append(sBookingNo);
                    }
                }

				if (BookingList.Length > 0)
				{
					AsynchConnectionKey = "LINE";
					start = DateTime.Now;
					dtLINE = SearchOptions.Options.GetSalesSummaryLINE(BookingList.ToString());
					time = DateTime.Now - start;
					lock (grdLINE)
					{
						ElapsedTime = time;
					}
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

                lock (grdCargo)
                {
                    try
                    {
                         grdCargo.DataSource = dtCargo;
                        //lblParams.Text = string.Format("{0} Row(s) in {1:0.00} sec {2}",
                        //    grdResults.RecordCount, ElapsedTime.TotalSeconds, SearchOptions.Options);
                        //lblParams.MaximumSize = new Size(pnlTop.Width - 20, 0);
                        //pnlTop.Height = lblParams.Height + 10;

                        grdCargo.Focus();
                    }
                    catch (Exception ex)
                    {
                        Program.ShowError(ex);
                    }
                }
                lock (grdLINE)
                {
                    try
                    {
                        grdLINE.DataSource = dtLINE;
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
                lock (grdCargo)
                {
                    tsSearchCargo.Enabled =  grdCargo.Enabled = state;
                    sbrChild.Visible = sbbProgressCaption.Visible =
                        sbbProgressMeter.Visible = !state;
                    grdCargo.Enabled = state;
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
            SearchParameters();
        }

        private void grdCargo_LinkClicked(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
        {
            GridEXRow grow = grdCargo.CurrentRow;
            Program.LinkHandler.HandleLink(grow, e.Column.Key);
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
            SearchOptions = null;
        }

        #endregion

        private void tsExcludeOcean_CheckStateChanged(object sender, EventArgs e)
        {
            if (ExcludeOcean)
            {
                dtLINE.DefaultView.RowFilter =
                    string.Format("charge_type_cd not in ('NTFR','LTOR','LTDE','BAF')");
            }
            else
            {
                dtLINE.DefaultView.RowFilter = "";
            }
        }

       

 
    }
}