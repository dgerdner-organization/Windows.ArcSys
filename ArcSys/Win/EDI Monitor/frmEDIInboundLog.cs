using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CS2010.CommonWinCtrls;
using CS2010.ArcSys.Business;

namespace CS2010.ArcSys.Win
{
	public partial class frmEDIInboundLog : frmChildBase
	{
		public frmEDIInboundLog()
		{
			InitializeComponent();
			ShowForm();
		}

		public void ShowForm()
		{
			this.Show();
			this.WindowState = FormWindowState.Maximized;
			Search();
			//InitForm();
			//this.AcceptButton = btnSearch;
		}

		public void Search()
		{
			DataTable dt = ClsEdiInboundLog.GetEDIInboundLog();
			grdMain.DataSource = dt;
		}

		private void grdMain_LinkClicked(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
		{
			if (e.Column.Key.ToLower() == "file_nm")
			{
				DataRow drow = grdMain.GetDataRow();
				string sFile = drow["file_nm"].ToString().Trim();
				ClsOpenEDIFile.OpenFile(sFile, "USCRW", "HHGIN");
			}
		}
	}
}
