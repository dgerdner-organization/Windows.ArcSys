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
	public partial class frmEditStenaRoutes : frmChildBase
	{
		protected DataTable dtRoutes;

		private ClsStenaRoute _currentRoute;
		protected ClsStenaRoute currentRoute
		{
			get
			{
				if (_currentRoute != null)
					return _currentRoute;
				DataRow dr = grdMain.GetDataRow();
				if (dr == null)
					return null;
				_currentRoute = new ClsStenaRoute(dr);
				return _currentRoute;
			}
		}

		protected string currentMode;
		private struct ModeType
		{
			public const string EditMode = "edit";
			public const string ViewMode = "view";
			public const string AddMode = "add";
		}

		public frmEditStenaRoutes()
		{
			InitializeComponent();
		}
		public void RefreshCurrentRoute()
		{
			_currentRoute = null;
		}

		public void ShowWindow()
		{
			this.MdiParent = Program.MainWindow;
			this.Activate();
			this.Show();
			this.WindowState = FormWindowState.Maximized;
			this.Search();
		}

		public void Search()
		{
			dtRoutes = ClsStenaRoute.GetAll();
			grdMain.DataSource = dtRoutes;
			RefreshCurrentRoute();
			SetEditMode(false);
		}

		public void SetEditMode(bool bEdit)
		{
			if (bEdit)
				currentMode = ModeType.ViewMode;
			btnEdit.Enabled = btnNew.Enabled = !bEdit;
			btnCancel.Enabled = bEdit;
			btnSave.Enabled = bEdit;
			cmbPOD.ReadOnly = cmbPOL.ReadOnly = txtDescription.ReadOnly = txtRouteCd.ReadOnly = !bEdit;
		}

		protected void RowSelectionChanged()
		{
			RefreshCurrentRoute();
			BindHelper.Bind(cmbPOL, currentRoute, "pol_location_cd");
			BindHelper.Bind(cmbPOD, currentRoute, "pod_location_cd");
			BindHelper.Bind(txtRouteCd, currentRoute, "route_cd");
			BindHelper.Bind(txtDescription, currentRoute, "route_description");
		}

		private void grdMain_SelectionChanged(object sender, EventArgs e)
		{
			RowSelectionChanged();
		}

		private void btnEdit_Click(object sender, EventArgs e)
		{
			SetEditMode(true);
			currentMode = ModeType.EditMode;
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			try
			{
				ClsStenaRoute r = currentRoute;
				r.Update();
				SetEditMode(false);
				RowSelectionChanged();
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			SetEditMode(false);
			RefreshCurrentRoute();
			RowSelectionChanged();
		}

		private void btnNew_Click(object sender, EventArgs e)
		{
			Program.Show("Not yet implemented");
		}
	}
}
