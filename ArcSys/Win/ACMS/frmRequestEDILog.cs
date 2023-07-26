using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CS2010.ACMS.Business;
using CS2010.ArcSys.Business;
using CS2010.CommonSecurity;
using CS2010.CommonWinCtrls;
using System.Configuration;
using System.IO;

namespace CS2010.ArcSys.Win
{
	public partial class frmRequestEDILog : frmChildBase
	{
		public frmRequestEDILog()
		{
			InitializeComponent();
		}

		public void ShowForm(ClsBookingRequest request)
		{
			this.Activate();
			this.MdiParent = Program.MainWindow;
			this.WindowState = FormWindowState.Maximized;
			ClsSecurityMaster.SetSecurity(this);
			grdEDILog.DataSource = request.EDILog;
			grdArcEDILog.DataSource = request.EDIArcSysLog;
			DataTable api01 = ClsApiLog.GetForDocument(request.Partner_Request_Cd);
            DataTable api02 = new DataTable();
            if (request.Booking_ID.IsNotNull())
            {
                api02 = ClsApiLog.GetForDocument(request.Booking_ID);
                api01.Merge(api02);
            }

			grdOceanAPI.DataSource = api01;
			this.Text = this.Text + " " + request.Partner_Request_Cd;
			this.Show();
			if (request.EDILog.Rows.Count > 0)
				grdEDILog.Row = 0;

		}

		private void DisplayEDIFile()
		{
			try
			{
				//DataRow drow = grdEDILog.GetDataRow();
				//if (drow == null)
				//    return;
				//string sFile = drow["table_dsc"].ToString().Trim();
				//string sType = drow["edi_type"].ToString().ToUpper().Trim();
				//string sPartner = drow["trading_partner_cd"].ToString().ToUpper().Trim():
				//sType = "SDDC" + sType + "Path";
				//string sPath = ConfigurationManager.AppSettings[sType];
				//sFile = sPath + sFile;
				//string sContent = File.ReadAllText(sFile);
				//txtEDIFile.Text = sContent;
			}
			catch (Exception ex)
			{
				Program.Show("Cannot Display File");
				Program.Show(ex.Message);
			}
		}
		private void grdEDILog_SelectionChanged(object sender, EventArgs e)
		{
			DisplayEDIFile();
		}

		private void grdEDILog_DoubleClick(object sender, EventArgs e)
		{

		}

		private void grdEDILog_LinkClicked(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
		{
			try
			{
				DataRow drow = grdEDILog.GetDataRow();
				string sFile = drow["table_dsc"].ToString().Trim();
				string sType = drow["edi_type"].ToString().Trim();
				string sPartner = drow["trading_partner_cd"].ToString().ToUpper().Trim();
				ClsOpenEDIFile.OpenFile(sFile, sPartner, sType);
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void grdArcEDILog_LinkClicked(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
		{
			try
			{
				DataRow drow = grdArcEDILog.GetDataRow();
				string sFile = drow["table_dsc"].ToString().Trim();
				string sType = drow["edi_type"].ToString().Trim();
				string sPartner = drow["trading_partner_cd"].ToString().ToUpper().Trim();
				//ClsOpenEDIFile.OpenFile(sFile, sPartner, sType);
				ClsOpenEDIFile.OpenFileWithFullName(sFile);
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void grdEDILog_FormattingRow(object sender, Janus.Windows.GridEX.RowLoadEventArgs e)
		{

		}
	}
}
