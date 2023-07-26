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
	public partial class frmSearchCargoFormoves : frmChildBase
	{
		#region Properties
		protected DataTable dtCargo;

		protected ClsTradingPartner currentShipper
		{
			get
			{
				DataRowView drv = cmbPartner.SelectedItem as DataRowView;
				string s = drv.Row["trading_partner_cd"].ToString();
				ClsTradingPartner tp = ClsTradingPartner.GetUsingKey(s);
				return tp;
			}
		}

		protected List<ClsCargoActivity> selectedCargo
		{
			get
			{
				return grdCargo.GetCheckedList<ClsCargoActivity>();
			}
		}
		#endregion

		#region Init
		public frmSearchCargoFormoves()
		{
			InitializeComponent();
		}
		
		public void ShowForm()
		{
			this.Show();
			this.WindowState = FormWindowState.Maximized;
			InitForm();
		}

		public void InitForm()
		{
			try
			{
				ClsSecurityMaster.SetSecurity(this, ClsEnvironment.User_Id.Value);
				DataTable dt = ClsTradingPartner.GetAll();
				cmbPartner.DataSource = dt;
				cmbPartner.SelectedIndex = 1;
				cmbConus.SelectedIndex = 0;
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}
		#endregion

		#region Methods
		private void Search()
		{
			string sConusOconus = cmbConus.SelectedItem.ToString();
			dtCargo = ClsCargo.GetAvailableForMove(
				currentShipper.Trading_Partner_Cd,"%","%",sConusOconus, (int)numDays.Value);
			grdCargo.DataSource = dtCargo;
		}

		private void AssignVendor()
		{
			if (!VerifyChecked())
				return;
			try
			{
				frmAssignVendor av = new frmAssignVendor();
				av.Setup(currentShipper, selectedCargo);
				av.ShowDialog();
				ClsVendorMove vm = av.newVendorMove;
				if (av.DialogResult != DialogResult.OK) return;
				Program.MainWindow.ShowCreateMove(vm);
				Search();
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private bool VerifyChecked()
		{
			string sOrig = "";
			string sDest = "";
			foreach(ClsCargoActivity ca in selectedCargo)
			{
				if (sOrig == "")
					sOrig = ca.Orig_Location_Cd;
				if (sOrig != ca.Orig_Location_Cd)
				{
					Program.Show("You can only select a single origin.  You have selected {0} and {1}.", sOrig, ca.Orig_Location_Cd);
					return false;
				}

				if (sDest == "")
					sDest = ca.Dest_Location_Cd;
				if (sDest != ca.Dest_Location_Cd)
				{
					Program.Show("You can only select a single destination.  You have selected {0} and {1}.", sDest, ca.Dest_Location_Cd);
					return false;
				}

			}
			return true;

		}
		#endregion

		#region Events
		private void btnSearch_Click(object sender, EventArgs e)
		{
			Search();
		}

		private void tsAssignVendor_Click(object sender, EventArgs e)
		{
			AssignVendor();
		}
		#endregion

		private void grdCargo_FormattingRow(object sender, Janus.Windows.GridEX.RowLoadEventArgs e)
		{

		}



	}
}
