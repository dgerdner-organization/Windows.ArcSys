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
using Janus.Windows.GridEX;

namespace CS2010.ArcSys.Win
{
    public partial class frmCustomerServiceLhaulCharges : frmChildBase, ISearchWindow
    {
        private delegate void SearchCompleteDelegate(SearchEventArgs e, bool Success);

        private SearchCompleteDelegate LhaulChargesSearchCompleteDelegate;

        private sql_lhaul_charges charges = new sql_lhaul_charges();

        public frmCustomerServiceLhaulCharges()
        {
            InitializeComponent();
        }

        private void frmCustomerServiceLhaulCharges_Load(object sender, EventArgs e)
        {
            LhaulChargesSearchCompleteDelegate = new SearchCompleteDelegate(SearchComplete);
            charges.SearchStatus += new sql_base.SearchEventHandler(ChargesSearchStatus);

            FormStateNormal();
        }

        private void frmCustomerServiceLhaulCharges_FormClosing(object sender, FormClosingEventArgs e)
        {
            charges.SearchStatus += new sql_base.SearchEventHandler(ChargesSearchStatus);
        }

        public void ShowForm()
        {
            this.Show();
        }

        public void ShowSearch(bool showOptions)
        {
            throw new NotImplementedException();
        }

        public void RefreshResults()
        {
            throw new NotImplementedException();
        }

        #region Private Methods

        private void Search()
        {
            try
            {
                if (txtBooking.Text.IsNull())
                {
                    MessageBox.Show("Please enter a booking number.");
                    return;
                }

                charges.Run(txtBooking.Text);
                FormStateSearch();

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
                txtBooking.Text = string.Empty;
                txtBooking.Focus();
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
                if (!DoesGridHaveData()) return;

                PrintDialog pd = grdCharges.PrinterSetup(false, false, false);
                if (pd.IsNotNull()) grdCharges.Print(false, false, pd);
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }

        private void Export()
        {
            try
            {
                if (!DoesGridHaveData()) return;
                
                grdCharges.Export(true, true);
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }

        private bool DoesGridHaveData()
        {
            try 
	        {
                if (grdCharges.DataSource.IsNull())
                {
                    MessageBox.Show("No Data.");
                    return false;
                }

                DataTable dt = (DataTable)grdCharges.DataSource;
                if (dt.Rows.Count <= 0)
                {
                    MessageBox.Show("No Data.");
                    return false;
                }

                return true;
	        }
	        catch (Exception ex)
	        {
                Program.ShowError(ex);
                return false;
	        }
        }

        private void FormStateNormal()
        {
            tsbCancel.Visible = 
            tsProgressBar.Visible = false;

            tsbPrint.Visible =
                tsbExport.Visible =
                gbSearch.Enabled =
                grdCharges.Enabled = true;

        }

        private void FormStateSearch()
        {
            tsbCancel.Visible =
            tsProgressBar.Visible = true;

            tsbPrint.Visible =
                tsbExport.Visible =
                gbSearch.Enabled =
                grdCharges.Enabled = false;
        }

        #endregion

        #region Search / SQL Base Methods

        private void ChargesSearchStatus(object o, SearchEventArgs e)
        {
            Invoke(LhaulChargesSearchCompleteDelegate, new object[] { e, (e.Status == SearchStatusCd.Complete) });
        }

        private void SearchComplete(SearchEventArgs e, bool Success)
        {
            FormStateNormal();
            grdCharges.DataSource = e.Data;
            lblResults.Text = e.Message_RowsAffectedElapsedTime;
        }

        private void Abort()
        {
            try
            {
                FormStateNormal();
                charges.Abort();
                lblResults.Text = "Query aborted ...";
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }

        #endregion

        #region Event Handlers

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void tsbPrint_Click(object sender, EventArgs e)
        {
            Print();
        }

        private void tsbExport_Click(object sender, EventArgs e)
        {
            Export();
        }

        private void tsbCancel_Click(object sender, EventArgs e)
        {
            Abort();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void grdCharges_LinkClicked(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
        {
            GridEXRow grow = grdCharges.CurrentRow;
            Program.LinkHandler.HandleLink(grow, e.Column.Key);
        }

        #endregion
    }
}
