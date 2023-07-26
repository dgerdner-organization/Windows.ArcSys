using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CS2010.CommonSecurity;
using CS2010.CommonWinCtrls;
using CS2010.ACMS.Business;
using System.Configuration;
using CS2010.Common;
using ASL.ARC.EDISQLTools;

namespace CS2010.ArcSys.Win
{
	public partial class frmEDILog : frmChildBase
	{
		public frmEDILog()
		{
			InitializeComponent();
			AsynchConnectionKey = "ACMS";
		}
		protected DataTable dtPartners;
		protected DataTable dtEDILog;
		protected int iDays;

		public void ShowForm()
		{
			this.Show();
			this.WindowState = FormWindowState.Maximized;
			InitForm();
		}

		public void InitForm()
		{
			dtPartners = ClsAcmsSQL.GetPartners();
			cmbPartnerz.DataSource = dtPartners;
			cmbInOut.SelectedIndex = 0;

		}

		protected void Search()
		{
			DateTime dtStart = DateTime.Now;
			string sPartner = null;
			if (cmbPartnerz.SelectedIndex > -1)
			{
				DataRowView drv = (DataRowView) cmbPartnerz.SelectedItem;
				sPartner = drv.Row["partner_cd"].ToString();
			}

			string sInOut = cmbInOut.SelectedItem.ToString();
			if (sInOut.ToLower() == "incoming")
				sInOut = "I";
			if (sInOut.ToLower() == "outgoing")
				sInOut = "O";
			if (sInOut.ToLower() == "all")
				sInOut = null;

			if (rb360.Checked)
				iDays = 360;

			dtEDILog = ClsEdiActivityFtp.Search(sPartner, sInOut, null, iDays);
			grdLog.DataSource = dtEDILog;
			if (dtEDILog.Rows.Count > 0)
				grdLog.Row = 1;

			if ((DateTime.Now - dtStart).Seconds > 3) 
				Program.Show("Done");
		}

		protected void OpenFile()
		{
			try
			{
				DataRow drow = grdLog.GetDataRow();
				string sFile = drow["table_dsc"].ToString().Trim();
				string sType = drow["edi_type"].ToString().ToUpper().Trim();
				string sPartner = drow["trading_partner_cd"].ToString().ToUpper().Trim();
				ClsOpenEDIFile.OpenFile(sFile, sPartner, sType);
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void btnSearch_Click(object sender, EventArgs e)
		{
			Search();
		}

		private void grdLog_LinkClicked(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
		{
			if (e.Column.DataMember.ToUpper() == "TABLE_DSC")
			{
				OpenFile();
			}
		}

		private void grdLog_SortKeysChanged(object sender, EventArgs e)
		{
			grdLog.Row = 0;
		}

		private void grdLog_ColumnButtonClick(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
		{
			try
			{
				string sKey = e.Column.Key;
				DataRow drow = grdLog.GetDataRow();
				if (sKey.ToLower() == "ftp_success_cd")
				{
					ClsACMSUtil.SetLogFTPSuccess(drow, "Y");
				}
				Search();
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}
	}
}
