using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CS2010.CommonSecurity;
using CS2010.CommonWinCtrls;
using CS2010.Common;
using CS2010.ACMS.Business;
using Janus.Data;
using Janus.Windows.GridEX;

namespace CS2010.ArcSys.Win
{
	public partial class frmSearchVoyages : frmChildBase
	{
		protected string parmVoyageNo;
		protected string CurrentVoyageNo
		{
			get
			{
				DataRow drow = grdVoyages.GetDataRow();
				if (drow == null)
					return "";
				string sVoyageCd = drow["voyage_cd"].ToString();
				return sVoyageCd;
			}
		}
		//public frmSearchVoyages()
		//{
		//    InitializeComponent();
		//    parmVoyageNo = "%";
		//    ClsSecurityMaster.SetSecurity(this);
		//    SetupGrid(grdDetail);
		//    SetupGrid(grdVoyages);
		//    Search();
		//}
		public frmSearchVoyages(string sVoyageNo)
		{
			InitializeComponent();

			if (string.IsNullOrEmpty(sVoyageNo))
			{
				this.MdiParent = Program.MainWindow;
				this.WindowState = FormWindowState.Maximized;
			}
			parmVoyageNo = sVoyageNo;
			//this.MdiParent = Program.MainWindow;
			//this.WindowState = FormWindowState.Maximized;
			ClsSecurityMaster.SetSecurity(this);
			txtVoyage.Text = parmVoyageNo;
			this.Text = parmVoyageNo;
			SetupGrid(grdDetail);
			SetupGrid(grdVoyages);
			Search();
		}

		protected void SetupGrid(ucGridEx grd)
		{
			foreach (GridEXColumn col in grd.Tables[0].Columns)
			{
				col.Selectable = false;
				col.AllowSort = false;
			}
		}
		protected void Search()
		{
			DataTable dt = ClsACMSQueries.GetVoyage(txtVoyage.Text);
			grdVoyages.DataSource = dt;
			this.Text = txtVoyage.Text;
		}

		private void btnSearch_Click(object sender, EventArgs e)
		{
			Search();
		}

		private void grdVoyages_SelectionChanged(object sender, EventArgs e)
		{
			this.Text = CurrentVoyageNo;
			string sVoyageNo = CurrentVoyageNo;
			if (string.IsNullOrEmpty(sVoyageNo))
				return;
			DataTable dt = ClsACMSQueries.GetVoyageDetail(sVoyageNo);
			grdDetail.DataSource = dt;
		}


		private void grdVoyages_LinkClicked(object sender, ColumnActionEventArgs e)
		{
			try
			{
				if (e.Column.Key.ToLower() == "mmsi")
				{
					DataRow drow = grdVoyages.GetDataRow();
					if (drow == null)
						return;
					string sMMSI = drow["mmsi"].ToString();
					string sURL = drow["tracking_url"].ToString();
					sURL = sURL + sMMSI;
					System.Diagnostics.Process.Start(sURL);
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

	}
}
