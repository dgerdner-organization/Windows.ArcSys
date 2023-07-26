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
    public partial class frmLINEImport : frmChildBase
    {
       public frmLINEImport()
        {
            InitializeComponent();
        }
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
           import = new ClsImportLineWarehouse();
       }
       private void PostImport()
       {
           txtSuccess.Text = results.bSuccess.ToString();
           txtNewBookings.Text = results.iNewBookings.ToString();
		   txtBookingUpds.Text = results.iUpdatedBookings.ToString();
           txtNewCargo.Text = results.iNewCargo.ToString();
		   txtCargoUpds.Text = results.iUpdatedCargo.ToString();
		   txtNewActivity.Text = results.iNewCargoActivity.ToString();
           txtNewLocations.Text = results.iNewLocations.ToString();
           txtError.Text = results.ErrorMsg + " @" + results.ErrorLocation;
		   txtTempTime.Text = (results.TempTime + results.LiveTime).ToString();
		   txtLastSQL.Text = results.sLastSQL;
		   txtBookingCount.Text = results.iBookingCount.ToString();
		   txtCargoCount.Text = results.iCargoCount.ToString();
		   txtVessels.Text = results.inewVessels.ToString();
		   txtNewCustomers.Text = results.iNewCustomer.ToString();

		   //ClsDatabaseExceptions de = new ClsDatabaseExceptions();
		   //DataTable dt = de.ImportNotes();
		   //if (dt.Rows.Count > 0)
		   //{
		   //    frmImportExceptions frm = new frmImportExceptions();
		   //    frm.MdiParent = this.MdiParent;
		   //    WindowHelper.ShowChildWindow(frm);
		   //    frm.SetDataSource(dt);
		   //}
       }
	   private void RefreshAll()
	   {
		   // Performs every step in the refresh process.
		   // This refreshs the LINE Warehouse, then updates
		   // ILMS tables with new/changed bookings and cargo
		   //
		   PreImport();
		   bool bFullRefresh = cbxFull.Checked;
		   //import.RefreshAll(bFullRefresh);

	   }
       private void ImportLINE()
        {
			bool bFullRefresh = cbxFull.Checked;
		   if (string.IsNullOrEmpty(txtVoyage.Text))
		   {
			   Program.Show("You must enter a voyage");
			   return;
		   }
		   DialogResult dr = MessageBox.Show("This couild take five or ten minutes to complete. You will be unable to perform other work until then.", "Warning", MessageBoxButtons.OKCancel);
		   if (dr == DialogResult.Cancel)
			   return;
			PreImport();
			DateTime dtStart = DateTime.Now;
			results = import.ImportLineWarehouse(bFullRefresh, txtVoyage.Text);
			DateTime dtEnd = DateTime.Now;
			double iSeconds = (dtEnd - dtStart).TotalSeconds;
			PostImport();
			txtTempTime.Text = iSeconds.ToString();
        }

       private void UpdateCargo()
       {
		   // Adds new bookings, locations, cargo, etc to ILMS
		   // tables.  This does not perform updates to bookings
		   // and cargo that have changed; it only add new.
           PreImport();
           results = import.ImportILMSTables(txtVoyage.Text);
           PostImport();
       }

	   private void UpdateILMS()
	   {
		   // Updates cargo and booking changes in ILMS
		   ClsImportLineWarehouse imp = new ClsImportLineWarehouse();
		   imp.UpdateChangedCargo();

		   // Updates cargo whose cargokey has changed
		   imp.UpdateMovedCargo();
	   }

	   private void Deletes()
	   {
		   ClsImportLineWarehouse imp = new ClsImportLineWarehouse();
		   results = imp.RemoveDeletedCargo(false);
		   txtDeletedCargo.Text = results.iDeletedCargo.ToString();
	   }

        private void btnImport_Click(object sender, EventArgs e)
        {
            ImportLINE();
        }

		private void btnUpdate_Click(object sender, EventArgs e)
		{
			UpdateCargo();
		}

		private void btnUpdateILMS_Click(object sender, EventArgs e)
		{
			UpdateILMS();
		}

		private void btnDeleteCargo_Click(object sender, EventArgs e)
		{
			Deletes();
		}

		private void btnRefreshAll_Click(object sender, EventArgs e)
		{
			RefreshAll();
		}

		private void ucButton1_Click(object sender, EventArgs e)
		{
		   ClsImportLineWarehouse imp = new ClsImportLineWarehouse();
		   imp.FindDeletedCargo();
		}

		private void ucButton2_Click(object sender, EventArgs e)
		{
			ClsImportLineWarehouse imp = new ClsImportLineWarehouse();
			imp.InsertHazardous();
		}

    }
}
