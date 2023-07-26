using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CS2010.ArcSys.Business;
using CS2010.Common;
using Janus.Windows.GridEX;

namespace CS2010.ArcSys.Win
{
	public partial class frmITVDiagnostics : CS2010.CommonWinCtrls.frmChildBase
	{
		public frmITVDiagnostics()
		{
			InitializeComponent();
		}
		private DataTable dtDiagnostics;
		private DataTable dtUntransmitted;

		public void ShowForm()
		{
			RefreshAll();
			this.Show();
			this.WindowState = FormWindowState.Maximized;
		}
		private void RefreshAll()
		{
			dtDiagnostics = ClsCommercialEDIQueries.EDIDiagnostics();
			grdDiagnostics.DataSource = dtDiagnostics;

			dtUntransmitted = ClsCommercialEDIQueries.ITVUntransmitted();
			grdUntransmitted.DataSource = dtUntransmitted;
		}

		private void GetSummary()
		{
			DataTable dtSummary = ClsCommercialEDIQueries.EDISummary();
			grdEDISummary.DataSource = dtSummary;
		}

		private void tsDiagRefresh_Click(object sender, EventArgs e)
		{
			RefreshAll();
		}

		private void btnSearchSummary_Click(object sender, EventArgs e)
		{
			GetSummary();
		}

		private void grdDiagnostics_LinkClicked(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
		{
			Program.LinkHandler.HandleLink(grdDiagnostics.CurrentRow, e.Column.Key);
		}

		private void grdEDISummary_LinkClicked(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
		{
			//Program.LinkHandler.HandleLink(grdEDISummary.CurrentRow, e.Column.Key);
			ViewBookingLINE(grdEDISummary.CurrentRow);
		}
		private void ViewBookingLINE(GridEXRow grow)
		{
			try
			{
				long booking_line_id = 0;
				string booking_no = null;
				ClsBookingLine bl = null;
				if (grow.Table.Columns.Contains("booking_no"))
					booking_no = ClsConvert.ToString(grow.Cells["booking_no"].Value);
				if (grow.Table.Columns.Contains("booking_line_id"))
					booking_line_id = ClsConvert.ToInt64(grow.Cells["booking_line_id"].Value);
				if (booking_line_id == 0)
					bl = ClsBookingLine.GetByBookingNo(booking_no);
				else
					bl = ClsBookingLine.GetUsingKey(booking_line_id);
				ViewWindowManager.View(bl);
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}
	}
}
