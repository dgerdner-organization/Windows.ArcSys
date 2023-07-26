using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CS2010.Common;
using CS2010.ACMS.Business;

namespace CS2010.ArcSys.Win
{
	public partial class frmRDDMissed : CS2010.CommonWinCtrls.frmChildBase
	{
		public frmRDDMissed()
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
			DataTable dtMain = ClsACMSQueries.GetRDDMissed();
			grdMain.DataSource = dtMain;
		}

		private void grdMain_LinkClicked(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
		{
			Program.LinkHandler.HandleLink(grdMain.CurrentRow, e.Column.Key.ToLower());
			//if (e.Column.Key.ToLower() == "booking_id")
			//    Program.LinkHandler.HandleLink(grdMain.CurrentRow, e.Column.Key.ToLower());
			//if (e.Column.Key.ToLower() == "partner_request_cd") 
			//    Program.LinkHandler.HandleLink(grdMain.CurrentRow, e.Column.Key.ToLower());
		}
	}
}
