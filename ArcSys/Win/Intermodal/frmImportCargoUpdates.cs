using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CS2010.CommonWinCtrls;
using CS2010.ArcSys.Business;
using CS2010.Common;
using CS2010.CommonSecurity;
using Janus.Windows.GridEX;

namespace CS2010.ArcSys.Win
{
    public partial class frmImportCargoUpdates : frmChildBase
    {
       public frmImportCargoUpdates()
        {
            InitializeComponent();
        }
        protected ClsImportLine import;
        protected ClsImportLine.ImportProcessResults results;
        protected DataTable dtChangedCargo;

       public void ShowForm(bool AutoRetrieve)
       {
           this.Show();
           this.WindowState = FormWindowState.Maximized;
           ClsSecurityMaster.SetSecurity(this, ClsEnvironment.User_Id.Value);
           if (AutoRetrieve)
           { Search(); }
       }

       protected void Search()
       {
           dtChangedCargo = ClsImportLine.GetChangedCargo();
           grdCargoChanged.DataSource = dtChangedCargo;
       }

       protected void UpdateCargo()
       {
           try
           {
               if (MessageBox.Show("Update the selected cargo information?  You may need to re-do your estimate(s)!", "Confirm",
                    MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                   return;
               ClsImportLine.UpdateChangedCargo(dtChangedCargo);
               Search();
           }
           catch (Exception ex)
           {
               ClsErrorHandler.LogException(ex);
               Program.ShowError("Database error during update. " + ex.Message);
           }
       }

       private void tsSearch_Click(object sender, EventArgs e)
       {
           Search();
       }

       private void tsUpdate_Click(object sender, EventArgs e)
       {
           UpdateCargo();
       }

       private void grdCargoChanged_LinkClicked(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
       {
           GridEXRow grow = grdCargoChanged.CurrentRow;
           Program.LinkHandler.HandleLink(grow, e.Column.Key);
       }
    }
}
