using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CS2010.CommonWinCtrls;
using CS2010.Common;
using CS2010.ArcSys.Business;
using CS2010.CommonSecurity;
using Janus.Windows.GridEX;

namespace CS2010.ArcSys.Win
{
    public partial class frmActualvsBudget : frmChildBase
    {
        private delegate void SearchCompleteDelegate(SearchEventArgs e, bool Success);
        private SearchCompleteDelegate LineSearchCompleteDelegate;
        private SearchCompleteDelegate WWLSearchCompleteDelegate;

        private sql_line_actual_vs_budget sql_Line = new sql_line_actual_vs_budget();
        private sql_wwl_actual_vs_budget sql_WWL = new sql_wwl_actual_vs_budget();

        private DataTable dt_Line;
        private DataTable dt_WWL;
        private DataTable dt_AvB;

        private ActualVsBudgetParams avbp;

        private manager_actual_vs_budget mgr_avb = new manager_actual_vs_budget();

        private int QuerysReturned;

        private enum SearchStatus
        {
            SearchingLine,
            SearchingWWL,
            MergingData,
            SearchComplete,
            SearchOff,
            Aborted
        };

        #region Public Methods

        public frmActualvsBudget()
        {
            InitializeComponent();

            AdjustForm(Program.MainWindow, true, null);

            ClsSecurityMaster.SetSecurity(this, ClsEnvironment.User_Id.Value);

        }

        public void ShowForm()
        {
            if (mgr_avb.TestLineConnection() == false)
            {
                MessageBox.Show("Cannot connect to LINE.  Please contact your system administrator");
                return;
            }

            if (mgr_avb.TestWWLConnection() == false)
            {
                MessageBox.Show("Cannot connect to WWL (ODS).  Please contact your system administrator");
                return;
            }

            FormState(SearchStatus.SearchOff);
            this.Show();
        }

        #endregion

        #region Private Methods

        private void FormState(SearchStatus s)
        {
            try
            {
                switch (s)
                {
                    case SearchStatus.SearchingLine:
                        foreach (ToolStripItem tsi in ts.Items) tsi.Visible = false;
                        tsbMsg.Text = "Searching Line ...";
                        grpSearch.Enabled = grdAvB.Enabled = false;
                        tsbCancelSearch.Visible = tsProgress.Visible = tsbMsg.Visible = true;
                        grdAvB.RootTable.Caption = string.Empty;
                        break;
                    case SearchStatus.SearchingWWL:
                        foreach (ToolStripItem tsi in ts.Items) tsi.Visible = false;
                        tsbMsg.Text = "Searching WWL ...";
                        grpSearch.Enabled = grdAvB.Enabled = false;
                        tsbCancelSearch.Visible = tsProgress.Visible = tsbMsg.Visible = true;
                        grdAvB.RootTable.Caption = string.Empty;
                        break;
                    case SearchStatus.MergingData:
                        foreach (ToolStripItem tsi in ts.Items) tsi.Visible = false;
                        tsbMsg.Text = "Merging Data ...";
                        tsbMsg.Visible = true;
                        grpSearch.Enabled = grdAvB.Enabled = tsbCancelSearch.Visible = tsProgress.Visible = false;
                        grdAvB.RootTable.Caption = string.Empty;
                        break;
                    case SearchStatus.SearchComplete:
                        foreach (ToolStripItem tsi in ts.Items) tsi.Visible = true;
                        grpSearch.Enabled = grdAvB.Enabled = tsbMsg.Visible = true;
                        tsbCancelSearch.Visible = tsProgress.Visible = false;
                        tsbMsg.Text = string.Format("LINE: {0}         WWL: {1}", sql_Line.Message_RowsAffectedElapsedTime, sql_WWL.Message_RowsAffectedElapsedTime);
                        break;
                    case SearchStatus.SearchOff:
                        foreach (ToolStripItem tsi in ts.Items) tsi.Visible = true;
                        grpSearch.Enabled = grdAvB.Enabled = true;
                        tsbMsg.Text = string.Empty;
                        tsbCancelSearch.Visible = tsProgress.Visible = false ;
                        grdAvB.RootTable.Caption = string.Empty;
                        break;
                    case SearchStatus.Aborted:
                        foreach (ToolStripItem tsi in ts.Items) tsi.Visible = true;
                        grpSearch.Enabled = grdAvB.Enabled = true;
                        tsbMsg.Text = string.Empty;
                        tsbMsg.Visible = true;
                        tsbCancelSearch.Visible = tsProgress.Visible = false ;
                        grdAvB.RootTable.Caption = string.Empty;
                        break;
                }
                this.Refresh();
                Application.DoEvents();
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }

        private void SearchLine()
        {
            FormState(SearchStatus.SearchingLine);
            QuerysReturned = 0;
            //sql_Line = new sql_line_actual_vs_budget();
            sql_Line.Clear();
            sql_Line.Run(avbp);
        }

        private void SearchWWL()
        {
            FormState(SearchStatus.SearchingWWL);
            QuerysReturned = 0;
            //sql_WWL = new sql_wwl_actual_vs_budget();
            sql_WWL.Clear();
            sql_WWL.Run(avbp);
        }

        private void Search()
        {
            try
            {
                avbp = new ActualVsBudgetParams();

                // Forces search filter controls to lose focus and therefore update ... (this is needed for Date Group Box)
                grpSearch.Focus();             

                if (rbEastbound.Checked) avbp.DirectionInd = "E";
                if (rbWestbound.Checked) avbp.DirectionInd = "W";
                if (rbBoth.Checked) avbp.DirectionInd = "B";
                if (rbOther.Checked) avbp.DirectionInd = "O";

                avbp.StartDt = dtSailDates.FromDate;
                avbp.EndDt = dtSailDates.ToDate;

                avbp.Voyage = txtVoyage.Text;
                avbp.Bol = txtBOL.Text;

                // For WWL
                if (rbEurope.Checked) avbp.ServiceInd = "E";
                if (rbMiddleEast.Checked) avbp.ServiceInd = "M";

                // For LINE
                avbp.LineService = cmbLineService.ServiceCDs;

                SearchLine();
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }

        private void Clear()
        {
            try
            {
                dtSailDates.Clear();
                rbBoth.Checked = true;
                rbAll.Checked = true;
                txtVoyage.Text = string.Empty;
                txtBOL.Text = string.Empty;
                cmbLineService.Clear();
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }

        private void Abort()
        {
            try
            {
                sql_Line.Abort();
                sql_WWL.Abort();
                FormState(SearchStatus.Aborted);
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }

        private void Print()
        {
            try
            {
                if (dt_AvB == null) return;

                string FileName = string.Format( "{0}\\{1}\\{2}",
                    Application.StartupPath,
                    "ActualvsBudget",
                    "ActualVsBudget.rpt");

                frmReportViewer rv = new frmReportViewer();

                rv.ShowReport(dt_AvB, FileName, avbp.FilterText);
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }

        #endregion

        #region Search / SQL Base Methods

        private void LineSearchComplete(SearchEventArgs e, bool Success)
        {
            QuerysReturned++;
            dt_Line = e.Data;

            SearchWWL();
        }

        private void WWLSearchComplete(SearchEventArgs e, bool Success)
        {
            QuerysReturned++;
            dt_WWL = e.Data;

            FormState(SearchStatus.MergingData);

            dt_AvB = mgr_avb.MergeActualVsBudgetReport(dt_Line, dt_WWL, avbp);

            grdAvB.DataSource = null;
            grdAvBPortFlowSummary.DataSource = null;
            grdAvBPortPairSummary.DataSource = null;
            grdAvBSummary.DataSource = null;

            grdAvB.DataSource = dt_AvB;
            grdAvBSummary.DataSource = mgr_avb.GetSummary(dt_AvB);
            grdAvBPortPairSummary.DataSource = mgr_avb.GetPortPairSummary(dt_AvB);
            grdAvBPortFlowSummary.DataSource = mgr_avb.GetPortFlowSummary(dt_AvB);

            FormState(SearchStatus.SearchComplete);

        }

        private void LineSearchStatus(object o, SearchEventArgs e)
        {
            Invoke(LineSearchCompleteDelegate, new object[] { e, (e.Status == SearchStatusCd.Complete) });
        }

        private void WWLSearchStatus(object o, SearchEventArgs e)
        {
            Invoke(WWLSearchCompleteDelegate, new object[] { e, (e.Status == SearchStatusCd.Complete) });
        }

        #endregion

        #region Event Handlers

        private void tsbCancelSearch_Click(object sender, EventArgs e)
        {
            Abort();
        }

        private void frmActualvsBudget_Load(object sender, EventArgs e)
        {
            LineSearchCompleteDelegate = new SearchCompleteDelegate(LineSearchComplete);
            WWLSearchCompleteDelegate = new SearchCompleteDelegate(WWLSearchComplete);

            sql_Line.SearchStatus += new sql_base.SearchEventHandler(LineSearchStatus);
            sql_WWL.SearchStatus += new sql_base.SearchEventHandler(WWLSearchStatus);
        }

        private void frmActualvsBudget_FormClosing(object sender, FormClosingEventArgs e)
        {
            sql_Line.SearchStatus -= new sql_base.SearchEventHandler(LineSearchStatus);
            sql_WWL.SearchStatus -= new sql_base.SearchEventHandler(WWLSearchStatus);
        }

        private void tsbSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void tsbClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void tsbPrint_Click(object sender, EventArgs e)
        {
            Print();
        }        

        #endregion

        private void utcAvB_SelectedTabChanged(object sender, Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs e)
        {

        }

    }
}
