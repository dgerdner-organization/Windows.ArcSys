using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CS2010.ArcSys.Business;
using CS2010.CommonWinCtrls;
using CS2010.Common;
using ASL.ARC.EDITools;
using CS2010.ACMS.Business;
using STENA;
using System.Threading;

namespace CS2010.ArcSys.Win
{
	public partial class frmViewStenaBookings : frmChildBase
	{
		protected List<clsBookingInfo> listBookings;


		public frmViewStenaBookings()
		{
			InitializeComponent();
		}

		public void ShowWindow()
		{
			this.MdiParent = Program.MainWindow;
			cmbRoutes.DataSource = ClsStenaRoute.GetAll();
			ClearSearch();
			this.Activate();
			this.Show();
			this.AcceptButton = btnSearch;
			this.WindowState = FormWindowState.Maximized;
		}

		public void Search()
		{
			string sMsg = "";
			string sRoute = "";
			object objRoute = cmbRoutes.SelectedItem;
			sRoute = cmbRoutes.SelectedText;
			listBookings = ClsSTENAservice.SearchBookings(ref sMsg, txtStenaID.Text, txtBookingNo.Text, sRoute, ucFromDays.Value.ToInt(), ucToDays.Value.ToInt());
			grdMain.DataSource = listBookings;
			if (!string.IsNullOrEmpty(sMsg))
			{
				Program.Show(sMsg);
			}
		}

		public void ClearSearch()
		{
			txtBookingNo.Text = "";
			txtStenaID.Text = "";
			ucFromDays.Value = -7;
			ucToDays.Value = 7;
			cmbRoutes.SelectedIndex = -1;

		}

		protected void RowSelectionChanged()
		{

		}

		private void grdMain_SelectionChanged(object sender, EventArgs e)
		{
			RowSelectionChanged();
		}

		private void btnSearch_Click(object sender, EventArgs e)
		{
			Search();
		}

		private void btnClear_Click(object sender, EventArgs e)
		{
			ClearSearch();
		}

		private void ucLabel5_Click(object sender, EventArgs e)
		{

		}

	}
}
