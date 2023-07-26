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
    public partial class frmLINECharges : frmChildBase, ISearchWindow
    {
        #region Vars and Props

        private DataTable _dtIntermodalCharges;
        private DataTable _dtLineCharges;
        private frmLINEChargesSearch _LineChargeSearch;

        public frmLINECharges() : base()
        {
            InitializeComponent();
            AdjustForm(Program.MainWindow, true, null);
            WindowHelper.InitAllGrids(this);
            ClsSecurityMaster.SetSecurity(this, ClsEnvironment.User_Id.Value);
        }

        public void RefreshResults()
        {
            if (_LineChargeSearch == null) return;
            if (_LineChargeSearch.BOOKING_NO.IsNull()) return;

            PerformSearch();
        }

        #endregion

        #region Public Methods

        public void EntryPoint()
        {
            this.Show();
            Search();
        }

        public void ShowSearch(bool showOptions)
        {
            try
            {
                if (showOptions == true) Search();
            }
            catch (Exception ex) 
            {
                Program.ShowError(ex);
            }
        }

        #endregion

        #region Private Methods

        private void Search()
        {
            try
            {
                if (_LineChargeSearch == null) _LineChargeSearch = new frmLINEChargesSearch();
                _LineChargeSearch.EntryPoint();
                if (_LineChargeSearch.DialogResult == DialogResult.Cancel) return;
                ClearHeader();
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
                DateTime start = DateTime.Now;

                ClsLineCharges lc = new ClsLineCharges();
                _dtIntermodalCharges = lc.EstimatedLineCharges(_LineChargeSearch.BOOKING_NO);
                lc = null;

                TimeSpan time = DateTime.Now - start;
                lock (grdIntermodalCharges)
                {
                     ElapsedTime = time;
                }

                AsynchConnectionKey = "LINE";

                ClsSalesSummary ss = new ClsSalesSummary();
                _dtLineCharges = ss.GetSalesSummaryLINE(_LineChargeSearch.BOOKING_NO);
                _dtLineCharges.DefaultView.RowFilter = "charge_type_cd not in ('NTFR','LTOR','LTDE','BAF')";
                ss = null;

                time = DateTime.Now - start;
                lock (grdLINECharges)
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

        private void ClearHeader()
        {
            grdIntermodalCharges.DataSource = null;
            grdLINECharges.DataSource = null;

            txtBookingNo.Text =
                txtARStatus.Text =
                txtLINEStatus.Text =
                txtPLOR.Text =
                txtPOL.Text =
                txtPOD.Text =
                txtPLOD.Text =
                txtElapsedTime.Text = string.Empty;
        }

        private void PopulateHeader()
        {
            txtBookingNo.Text = _dtIntermodalCharges.Rows[0]["booking_no"].ToString();
            txtVesselCd.Text = _dtIntermodalCharges.Rows[0]["vessel_cd"].ToString();
            txtVoyageNo.Text = _dtIntermodalCharges.Rows[0]["voyage_no"].ToString();
            txtARStatus.Text = _dtIntermodalCharges.Rows[0]["ar_status_cd"].ToString();
            txtLINEStatus.Text = _dtIntermodalCharges.Rows[0]["line_status_cd"].ToString();
            txtPLOR.Text = _dtIntermodalCharges.Rows[0]["plor_dsc"].ToString();
            txtPOL.Text = _dtIntermodalCharges.Rows[0]["pol_dsc"].ToString();
            txtPOD.Text = _dtIntermodalCharges.Rows[0]["pod_dsc"].ToString();
            txtPLOD.Text = _dtIntermodalCharges.Rows[0]["plod_dsc"].ToString();
            txtElapsedTime.Text = ElapsedTime.ToString();

            tsbRefresh.Enabled = true;
        }

        private void UpdateGrid()
        {
            try
            {
                AdjustGUI(true);

                lock (grdIntermodalCharges)
                {
                    try
                    {                       
                        grdIntermodalCharges.DataSource = _dtIntermodalCharges;
                        grdLINECharges.DataSource = _dtLineCharges;

                        if (grdIntermodalCharges != null)
                            if (grdIntermodalCharges.RowCount > 0)
                                PopulateHeader();

                        grdIntermodalCharges.Focus();

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
                lock (grdIntermodalCharges)
                {
                    tsMenu.Enabled = grdIntermodalCharges.Enabled = state;
                    sbrChild.Visible = sbbProgressCaption.Visible =
                        sbbProgressMeter.Visible = !state;
                    grdIntermodalCharges.Enabled = state;
                }

                lock (grdLINECharges)
                {
                    grdLINECharges.Enabled = state;
                }

            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }
        #endregion

        #region Event Handlers

        private void sbbProgressCaption_Click(object sender, EventArgs e)
        {
            CancelAsynchronousProcess();
        }

        private void frmLINECharges_FormClosing(object sender, FormClosingEventArgs e)
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

        private void frmLINECharges_FormClosed(object sender, FormClosedEventArgs e)
        {
            _LineChargeSearch = null;
        }

        private void tsbSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void tsbRefresh_Click(object sender, EventArgs e)
        {
            RefreshResults();
        }

        #endregion
    }
}