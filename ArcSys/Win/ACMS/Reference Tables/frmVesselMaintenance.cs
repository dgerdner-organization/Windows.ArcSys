using System;
using System.Data;
using System.Windows.Forms;
using CS2010.Common;
using CS2010.CommonWinCtrls;
using CS2010.ACMS.Business;
using Janus.Windows.GridEX;

namespace CS2010.ArcSys.Win
{
	public partial class frmVesselMaintenance : frmChildBase
	{
		#region Fields/Properties

		private DataTable dtVessels;
		public string sVesselCd;

		#endregion		// #region Fields/Properties

		#region Constructors/Initialization/Entry/Cleanup

		public frmVesselMaintenance()
			: base()
		{
			InitializeComponent();

			AdjustForm(Program.MainWindow, true, null);

			WindowHelper.InitAllGrids(this);
		}

		/// <summary>Used by the static entry methods to ensure that no more than one of these
		/// windows is visible at any given time</summary>
		private static frmVesselMaintenance theWindow;

		/// <summary>Static entry point used to display this window to ensure that no
		/// more than 1 of this type of window is visible at any given time</summary>
		public static frmVesselMaintenance ShowMaintenance()
		{
			return ShowMaintenance(null);
		}
		public static frmVesselMaintenance ShowMaintenance(string sVessel)
		{
			try
			{
				if (theWindow == null)
				{
					theWindow = new frmVesselMaintenance();
					theWindow.InitWindow();
				}
				theWindow.sVesselCd = sVessel;
				WindowHelper.ShowChildWindow(theWindow);

				return theWindow;
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
				return null;
			}
		}

		private void InitWindow()
		{
			try
			{
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void frmVesselMaintenance_Load(object sender, EventArgs e)
		{
			LoadData();
		}

		private void tbbRefresh_Click(object sender, EventArgs e)
		{
			LoadData();
		}

		private void LoadData()
		{
			try
			{
				grdVessels.DataSource = null;
				if (dtVessels != null)
				{
					dtVessels.Dispose();
					dtVessels = null;
				}
				dtVessels = ClsVessel.GetAllVessels();
				grdVessels.DataSource = dtVessels;
				if (grdVessels.RootTable != null)
					grdVessels.RootTable.Caption = "Vessels: " + grdVessels.RecordCount;
				if (!string.IsNullOrEmpty(this.sVesselCd))
				{
					int iRow = 0;
					foreach (GridEXRow grow in grdVessels.GetRows())
					{
						string sX = grow.Cells[0].Value.ToString();
						if (sX == this.sVesselCd)
							grdVessels.Row = iRow;
						iRow++;
					}
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void tbbClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void frmVesselMaintenance_FormClosed(object sender, FormClosedEventArgs e)
		{
			theWindow = null;
		}
		#endregion		// #region Constructors/Initialization/Entry/Cleanup

		#region Grid/Toolbar Actions

		private void tbbAddVessel_Click(object sender, EventArgs e)
		{
			AddVessel();
		}

		private void grdVessel_DoubleClick(object sender, EventArgs e)
		{
			try
			{
				GridArea ga = grdVessels.HitTest();
				if (ga != GridArea.Cell) return;

				DataRow dr = grdVessels.GetDataRow();
				if (dr == null) return;

				EditVessel(dr);
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void grdVessel_ColumnButtonClick(object sender, ColumnActionEventArgs e)
		{
			try
			{
				DataRow dr = grdVessels.GetDataRow();
				if (dr == null) return;

				if (string.Compare(e.Column.Key, "EditVessel", true) == 0)
					EditVessel(dr);
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void grdVessel_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				if (e.KeyCode == Keys.Enter)
				{
					GridEXRow gr = grdVessels.GetRow();
					if (gr == null || gr.RowType != RowType.Record) return;

					DataRow dr = grdVessels.GetDataRow();
					if (dr == null) return;

					EditVessel(dr);

					e.Handled = true;
				}
				else if (e.KeyCode == Keys.C && e.Control)
				{
					GridEXRow r = grdVessels.GetRow();
					GridEXColumn c = grdVessels.CurrentColumn;
					if (r == null || c == null || string.IsNullOrEmpty(c.DataMember)) return;

					string s = ClsConvert.ToString(r.Cells[c].Text);
					if (!string.IsNullOrEmpty(s)) Clipboard.SetText(s);
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void frmVesselMaintenance_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				if (e.KeyCode == Keys.F5)
				{
					e.Handled = true;
					LoadData();
					return;
				}

				if (e.Control)
				{
					if (e.KeyCode == Keys.N)
					{
						e.Handled = true;
						AddVessel();
					}
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}
		#endregion		// #region Grid/Toolbar Actions

		#region Insert/Update

		private void AddVessel()
		{
			try
			{
				ClsVessel newItem = null;
				using (frmVesselEdit f = new frmVesselEdit())
				{
					newItem = f.AddVessel();
				}
				if (newItem == null) return;

				Program.Show("Vessel Added");

				DataRow dr = dtVessels.NewRow();
				newItem.CopyToDataRow(dr);
				dtVessels.Rows.Add(dr);

				GridEXRow grow = grdVessels.GetRow(dr);
				if (grow != null)
				{
					grdVessels.Row = grow.Position;
					grdVessels.EnsureVisible(grow.Position);
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void EditVessel(DataRow dr)
		{
			try
			{
				if (dr == null) return;

				ClsVessel anItem = new ClsVessel(dr);
				using (frmVesselEdit f = new frmVesselEdit())
				{
					if (!f.EditVessel(anItem)) return;
				}

				Program.Show("Vessel Updated");

				anItem.CopyToDataRow(dr);
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}
		#endregion		// #region Insert/Update

		private void grdVessels_LinkClicked(object sender, ColumnActionEventArgs e)
		{
			string sFindURL = "http://www.marinetraffic.com/en/ais/index/ships/range/shipname:";
			string sValue = grdVessels.GetRow().Cells[e.Column].Value.ToString();
			string IRCS = grdVessels.GetRow().Cells[e.Column].Value.ToString();
			string sURL = string.Format("{0}{1}", sFindURL, sValue);
			System.Diagnostics.Process.Start(sURL);
		}
	}
}