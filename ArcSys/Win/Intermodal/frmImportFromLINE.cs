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
using CS2010.CommonSecurity;

namespace CS2010.ArcSys.Win
{
    public partial class frmImportFromLINE : frmChildBase
    {
       public frmImportFromLINE()
        {
            InitializeComponent();
        }
		//protected ClsImportLine import;
		//protected ClsImportLine.ImportProcessResults results;
	   protected ClsImportLineWarehouse import;
	   protected ClsImportLineWarehouse.ImportWarehouseResults results;

       public void ShowForm()
       {
           this.Show();
           this.WindowState = FormWindowState.Maximized;
           ClsSecurityMaster.SetSecurity(this, ClsEnvironment.User_Id.Value);

       }
       private void PreImport()
       {
			//     import = new ClsImportLine();
           txtSuccess.Text = txtPurged.Text = txtNewBookings.Text = txtNewCargoActivity.Text = txtNewCargo.Text = "";
       }
       private void PostImport()
       {
           txtSuccess.Text = results.bSuccess.ToString();
           txtPurged.Text = results.iPurgeResults.ToString();
           txtNewBookings.Text = results.iNewBookings.ToString();
           txtNewCargo.Text = results.iNewCargo.ToString();
           txtNewCargoActivity.Text = results.iNewCargoActivity.ToString();
           txtNewLocations.Text = results.iNewLocations.ToString();
           txtError.Text = results.ErrorMsg + " @" + results.ErrorLocation;
           txtTempTime.Text = results.TempTime.ToString();
           txtLiveTime.Text = results.LiveTime.ToString();
		   txtLastSQL.Text = results.sLastSQL;

           ClsDatabaseExceptions de = new ClsDatabaseExceptions();
           DataTable dt = de.ImportNotes();
           if (dt.Rows.Count > 0)
           {
               frmImportExceptions frm = new frmImportExceptions();
               frm.MdiParent = this.MdiParent;
               WindowHelper.ShowChildWindow(frm);
               frm.SetDataSource(dt);
           }
       }
       private void ImportLINE()
        {
           PreImport();
           //results = import.ImportLineProcess(txtVoyage.Text, 90);
		   results = import.ImportLineWarehouse(false, txtVoyage.Text);
           PostImport();
        }
       private void RefreshTempTable()
       {
		   Program.Show("Not implemented");
		   //PreImport();
		   //results = import.ImportTempTable(txtVoyage.Text, 90);
		   //PostImport();
       }
       private void UpdateCargo()
       {
           PreImport();
           //results = import.ImportLiveTables(txtVoyage.Text);
           PostImport();
       }

        private void btnImport_Click(object sender, EventArgs e)
        {
            ImportLINE();
        }

        private void frmImportFromLINE_Load(object sender, EventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshTempTable();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateCargo();
        }

        private void txtPurged_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
