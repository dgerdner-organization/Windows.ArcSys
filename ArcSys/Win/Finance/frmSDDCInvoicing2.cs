using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CS2010.CommonWinCtrls;
using CS2010.CommonSecurity;
using CS2010.Common;
using CS2010.LINE.Business;

namespace CS2010.ArcSys.Win
{
    public partial class frmSDDCInvoicing2 : frmChildBase
    {
        public frmSDDCInvoicing2()
        {
            InitializeComponent();
            AdjustForm(Program.MainWindow, true, null);
            ClsSecurityMaster.SetSecurity(this, ClsEnvironment.User_Id.Value);
        }

        #region Private Methods

        private void Search()
        {
            try
            {
                //if (txtVoyage.Text.IsNull())
                //{
                //    MessageBox.Show("Please enter a voyage number and try again.");
                //    return;
                //}

                if (txtPCFN.Text.IsNull())
                {
                    MessageBox.Show("Please enter a PCFN and try again.");
                    return;
                }

                clsSddcInvoicing2 si = new clsSddcInvoicing2();

                //grdData.DataSource = si.GetSDDCInvoicing(txtVoyage.Text);

                DataTable dt = si.GetSDDCInvoicing2(txtPCFN.Text.Trim());

                if (dt.IsNull())
                {
                    MessageBox.Show("No Data.");
                    grdData2.DataSource = null;
                    return;
                }

                grdData2.DataSource = dt;
                grdData2.RetrieveStructure();

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
                txtVoyage.Text = string.Empty;
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
                grdData.Export(true, true);
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }

        #endregion

        #region Event Handlers

        private void tsbSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void tsbClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void tsbExport_Click(object sender, EventArgs e)
        {
            Export();
        }

        #endregion
    }
}
