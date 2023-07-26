using System;
using System.IO;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;
using CS2010.Common;
using CS2010.CommonWinCtrls;
using CS2010.CommonSecurity;
using CS2010.ArcSys.Business;
using Janus.Windows.GridEX;
using System.Drawing;

namespace CS2010.ArcSys.Win
{
	public partial class frmCargo : frmChildBase, IViewWindow
	{
		#region Fields/Properties

		private ClsCargo _Cargo;

		#endregion		// #region Fields/Properties

		#region Constructors/Initialization/Entry

		public frmCargo() : base(Program.MainWindow, true)
		{
			InitializeComponent();
		}

		public frmCargo(bool showModal) : base()
		{
			InitializeComponent();

			if (showModal == true)
			{
				MergeToolbar = null;
				MaximizeBox = false;
				ShowInTaskbar = false;
				FormBorderStyle = FormBorderStyle.FixedDialog;
			}
			else
				AdjustForm(Program.MainWindow, true, null);

			InitWindow();
		}

		private void InitWindow()
		{
			try
			{
				//WindowHelper.InitAllGrids(this);

				ClsSecurityMaster.SetSecurity(this, ClsEnvironment.User_Id.Value);
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		public void ViewCargo(ClsCargo c)
		{
			try
			{
				_Cargo = (c != null && c.Cargo_ID != null)
					? ClsCargo.GetUsingKey(c.Cargo_ID.Value) : null;
				if (_Cargo == null)
				{
					Program.ShowError("No cargo provided");
					return;
				}

				if (MdiParent == null)
					ShowDialog();
				else
					Show();
			}
			catch (Exception ex)
			{
				Program.ShowError(ex, _Cargo);
			}
		}

		private void frmCargo_Load(object sender, EventArgs e)
		{
			try
			{
				UpdateDisplay();
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		public void UpdateDisplay()
		{
			try
			{
				List<ClsCargo> lst = new List<ClsCargo>();
				lst.Add(_Cargo);
				grdCargo.DataSource = lst;

				LoadActivities();
				DisplayTitle();

				LoadLINE();

				grdActivities.Focus();
				ActiveControl = grdActivities;
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void LoadActivities()
		{
			try
			{
				grdActivities.DataSource = _Cargo.GetCargoActivities(true);
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void DisplayTitle()
		{
			try
			{
				Text = string.Format("Cargo: Serial # {0}", _Cargo.Serial_No);
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void LoadLINE()
		{
			try
			{
				ClsImportLine imp = new ClsImportLine();
				DataTable dt = imp.QueryLINEData(_Cargo.Booking.Voyage_No, _Cargo.Booking.Booking_No,
					_Cargo.Serial_No, false);
				grdLINE.DataSource = dt;
				grdLINE.RetrieveStructure();
				grdLINE.GroupByBoxVisible = false;
				grdLINE.AllowEdit = InheritableBoolean.False;
				Infragistics.Win.UltraWinDock.DockableControlPane linePane =
					infCargoDock.ControlPanes[grdLINE];
				if (dt == null || dt.Rows.Count <= 0)
				{
					grdLINE.BuiltInTexts[GridEXBuiltInText.EmptyGridInfo] =
						string.Format("Serial # {0} not found in LINE for booking {1}, voyage {2}",
						_Cargo.Serial_No, _Cargo.Booking.Booking_No, _Cargo.Booking.Voyage_No);
					System.Drawing.Font f = new System.Drawing.Font(grdLINE.Font.FontFamily, 12,
						System.Drawing.FontStyle.Bold);
					grdLINE.RowFormatStyle.Font = f;
					grdLINE.RowFormatStyle.ForeColor = Color.Red;

					linePane.Text = "Serial # not found in LINE";

					linePane.Settings.TabAppearance.BackColor = Color.Red;
				}
				else
				{
					grdLINE.BuiltInTexts[GridEXBuiltInText.EmptyGridInfo] = null;
					System.Drawing.Font f = new System.Drawing.Font(grdLINE.Font.FontFamily,
						grdLINE.Font.Size, System.Drawing.FontStyle.Regular);
					grdLINE.RowFormatStyle.Font = f;
					grdLINE.RowFormatStyle.ForeColor = Color.Black;
					linePane.Text = "Click here to view LINE data";
					linePane.Settings.TabAppearance.BackColor = Color.Empty;
				}

				//linePane.Settings.CaptionAppearance.BackColor =
					//linePane.Settings.ActiveCaptionAppearance.BackColor =
					//linePane.Settings.TabAppearance.BackColor;
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}
		#endregion		// #region Constructors/Initialization/Entry

		#region IViewWindow Interface Implementation

		public ClsBaseTable TableObject
		{
			get { return _Cargo; }
		}

		public void ViewObject(ClsBaseTable bizObject)
		{
			ViewCargo(bizObject as ClsCargo);
		}
		#endregion		// #region IViewWindow Interface Implementation

		#region Menu/Toolbar Actions

		private void tsbClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void tsmiViewBooking_Click(object sender, EventArgs e)
		{
		}

		private void tsmiViewChangeHistory_Click(object sender, EventArgs e)
		{
			ViewChangeHistory();
		}

		private void ViewChangeHistory()
		{
			Program.MainWindow.ViewChangeHistory(_Cargo);
		}
		#endregion		// #region Menu/Toolbar Actions

		#region Form/Grid Event Handlers

		private void grd_LinkClicked(object sender, ColumnActionEventArgs e)
		{
			try
			{
				ucGridEx grd = sender as ucGridEx;
				if (grd == null) return;

				if (string.Compare(e.Column.Key, "Serial_No", true) == 0)
				{
					ViewChangeHistory();
					return;
				}

				Program.LinkHandler.HandleLink(grd.CurrentRow, e.Column.Key);
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void grdActivities_SelectionChanged(object sender, EventArgs e)
		{
			ViewCargoCharges();
		}

		private void ViewCargoCharges()
		{
			try
			{
				DataRow dr = grdActivities.GetDataRow();
				long? caID = (dr != null )
					? ClsConvert.ToInt64Nullable(dr["cargo_activity_id"]) : null;
				if( caID == null ) return;

				DataTable dt = ClsEstimateChargeDtl.GetActivityDetail(caID.Value);
				DataView dvAP = new DataView(dt);
				dvAP.RowFilter = "Finance_Cd = 'AP'";
				DataView dvAR = new DataView(dt);
				dvAR.RowFilter = "Finance_Cd = 'AR'";

				grdEstAP.DataSource = dvAP;
				grdEstAR.DataSource = dvAR;

				// Add Actual AP
				// Add Actual AR
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void grpEst_Resize(object sender, EventArgs e)
		{
			try
			{
				if (!splEstAR.Collapsed)
					grdEstAR.Width = grpEst.Panel.Width / 2;
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}

		}
		#endregion		// #region Form/Grid Event Handlers
	}
}