using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using Janus.Windows;
using Janus.Data;
using Janus.Windows.GridEX;
using CS2010.AVSS.Business;
using CS2010.AVSS.Win;
using CS2010.AVSS.WinCtrls;
using CS2010.Common;
using CS2010.CommonWinCtrls;
using CS2010.CommonSecurity;

namespace CS2010.AVSS.Win
{
	public partial class frmManageMilitaryVoyages : CS2010.CommonWinCtrls.frmChildBase
	{
		protected int SelectedAge
		{
			get
			{
				if (rb180.Checked)
					return 180;
				if (rb360.Checked)
					return 360;
				if (rb720.Checked)
					return 720;
				if (rbAll.Checked)
					return 99999;
				return 99999;
			}
		}
		public frmManageMilitaryVoyages()
		{
			InitializeComponent();

			ClsSecurityMaster.SetSecurity(this, ClsEnvironment.User_Id.Value);
		}
		private DataTable berthActivities;
		
		private void FormLoad()
		{
			this.WindowState = FormWindowState.Maximized;
			SearchVoyages();
		}
		private void SearchVoyages()
		{
			berthActivities = ClsVesselBerthActivity.GetNoMilitaryVoyage(SelectedAge);
			grdUnassigned.DataSource = berthActivities;
			grdUnassigned.Row = 0;
		}
		private void UpdateMilitaryVoyage()
		{
			string s = grdUnassigned.CurrentRow.Cells[0].Value.ToString();
			frmUpdateMilitaryVoyage frm = new frmUpdateMilitaryVoyage();
			frm.MdiParent = this.MdiParent;
			frm.UpdateVoyage(s);
		}

		private void frmUpdateMilitaryVoyage_Load(object sender, EventArgs e)
		{
			FormLoad();
		}

		private void grdPortCalls_DoubleClick(object sender, EventArgs e)
		{
			UpdateMilitaryVoyage();
		}

		private void ucLabel1_Click(object sender, EventArgs e)
		{

		}

		private void rb360_CheckedChanged(object sender, EventArgs e)
		{
			SearchVoyages();
		}

		private void rb720_CheckedChanged(object sender, EventArgs e)
		{
			SearchVoyages();
		}

		private void rbAll_CheckedChanged(object sender, EventArgs e)
		{
			SearchVoyages();
		}

		private void radioButton1_CheckedChanged(object sender, EventArgs e)
		{
			SearchVoyages();
		}


	}
}

