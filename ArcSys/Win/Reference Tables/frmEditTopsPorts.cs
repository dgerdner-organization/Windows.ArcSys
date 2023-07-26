using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CS2010.Common;
using CS2010.CommonWinCtrls;
using CS2010.ArcSys.Business;
using Janus.Windows.GridEX;

namespace CS2010.ArcSys.Win
{
    public partial class frmEditTopsPorts : frmChildBase 
    {
        private DataTable dtConfig;

        public frmEditTopsPorts() 
        {
            InitializeComponent();
            GetData();
        }

        protected void GetData()
        {
            dtConfig = ClsConfiguration.GetAll();
            grdMain.DataSource = dtConfig;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                grdMain.UpdateData();
                foreach (DataRow drow in grdMain.GetDataRowList())
                {
                    // Get the object from the grid
                    ClsConfiguration c = new ClsConfiguration(drow);

                    // See if it exists in the database
                    ClsConfiguration x = ClsConfiguration.GetUsingKey(c.Config_ID.GetValueOrDefault());

                    // If it does exist, just update it
                    if (x != null)
                    {
                        c.Update();
                        GetData();
                        continue;
                    }

                    // If it does not exist, insert it
                    c.Insert();
                    GetData();
                }
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            dtConfig.Rows.Add(null, null, null, null);
        }

        private void grdMain_ColumnButtonClick(object sender, ColumnActionEventArgs e)
        {
            if (MessageBox.Show("Delete this item?", "Confirm", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                object obj = grdMain.GetValue("config_id");
                Int64 id = ClsConvert.ToInt64(obj);
                ClsConfiguration c = ClsConfiguration.GetUsingKey(id);
                c.Delete();
                GetData();
            }
        }
    }
}
