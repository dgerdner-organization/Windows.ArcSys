using System;
using System.Data;
using System.Windows.Forms;
using CS2010.Common;
using CS2010.CommonWinCtrls;
using CS2010.ACMS.Business;
using Janus.Windows.GridEX;

namespace CS2010.ArcSys.Win
{
	public partial class frmLocationTerminalMaintenance : frmChildBase
	{
		#region Fields/Properties

		private DataSet dsLocations;
		private DataTable dtLocations
		{
			get
			{
				return (dsLocations != null && dsLocations.Tables.Count > 0)
					? dsLocations.Tables[0] : null;
			}
		}

		private DataTable dtTerminals
		{
			get
			{
				return (dsLocations != null && dsLocations.Tables.Count > 1)
					? dsLocations.Tables[1] : null;
			}
		}

		private DataRelation relLocationTerminal
		{
			get
			{
				return (dsLocations != null && dsLocations.Relations.Count > 0)
					? dsLocations.Relations[0] : null;
			}
		}
		#endregion		// #region Fields/Properties

		#region Constructors/Initialization/Entry/Cleanup

		public frmLocationTerminalMaintenance() : base()
		{
			InitializeComponent();

			AdjustForm(Program.MainWindow, true, null);

			WindowHelper.InitAllGrids(this);
		}

		/// <summary>Used by the static entry methods to ensure that no more than one of these
		/// windows is visible at any given time</summary>
		private static frmLocationTerminalMaintenance theWindow;

		/// <summary>Static entry point used to display this window to ensure that no
		/// more than 1 of this type of window is visible at any given time</summary>
		public static frmLocationTerminalMaintenance ShowMaintenance()
		{
			return ShowMaintenance(null);
		}
		public static frmLocationTerminalMaintenance ShowMaintenance(string sLocationCd)
		{
			try
			{
				if (theWindow == null)
				{
					theWindow = new frmLocationTerminalMaintenance();
					theWindow.InitWindow();
				}

				WindowHelper.ShowChildWindow(theWindow);

				if (!string.IsNullOrEmpty(sLocationCd))
				{
					GridEXColumn col = theWindow.grdLocation.RootTable.Columns["location_cd"];
					GridEXFilterCondition filter = new GridEXFilterCondition(col, ConditionOperator.Equal, sLocationCd);
					theWindow.grdLocation.RootTable.FilterCondition = filter;
					theWindow.grdLocation.RootTable.ApplyFilter(filter);
				}

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

		private void frmLocationTerminalMaintenance_Load(object sender, EventArgs e)
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
				grdLocation.DataSource = null;
				if (dsLocations != null)
				{
					dsLocations.Dispose();
					dsLocations = null;
				}
				dsLocations = ClsLocation.GetLocationPlusTerminals();
				DataTable dt = dtLocations;
				DataRelation rel = relLocationTerminal;

				grdLocation.DataSource = dsLocations;
				if (dt != null)
				{
					if (dt.Rows.Count > 0 && rel != null)
						grdLocation.RootTable.ChildTables[0].DataMember = rel.RelationName;
					grdLocation.DataMember = dt.TableName;
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

		private void frmLocationTerminalMaintenance_FormClosed(object sender, FormClosedEventArgs e)
		{
			theWindow = null;
		}
		#endregion		// #region Constructors/Initialization/Entry/Cleanup

		#region Grid/Toolbar Actions

		private void tbbAddLocation_Click(object sender, EventArgs e)
		{
			AddLocation();
		}

		private void grdLocation_DoubleClick(object sender, EventArgs e)
		{
			try
			{
				GridArea ga = grdLocation.HitTest();
				if (ga != GridArea.Cell) return;

				DataRow dr = grdLocation.GetDataRow();
				if (dr == null) return;

				if (dr.Table.Columns.Contains("Terminal_Cd"))
					EditTerminal(dr);
				else
					EditLocation(dr);
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void grdLocation_ColumnButtonClick(object sender, ColumnActionEventArgs e)
		{
			try
			{
				DataRow dr = grdLocation.GetDataRow();
				if (dr == null) return;

				if (string.Compare(e.Column.Key, "DeleteTerminal", true) == 0)
					DeleteTerminal(dr);
				else if (string.Compare(e.Column.Key, "EditTerminal", true) == 0)
					EditTerminal(dr);
				else if (string.Compare(e.Column.Key, "AddTerminal", true) == 0)
					AddTerminal(dr);
				else if (string.Compare(e.Column.Key, "DeleteLocation", true) == 0)
					DeleteLocation(dr);
				else if (string.Compare(e.Column.Key, "EditLocation", true) == 0)
					EditLocation(dr);
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void grdLocation_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				if (e.KeyCode == Keys.Enter)
				{
					GridEXRow gr = grdLocation.GetRow();
					if (gr == null || gr.RowType != RowType.Record) return;

					DataRow dr = grdLocation.GetDataRow();
					if (dr == null) return;

					if (dr.Table.Columns.Contains("Terminal_Cd"))
						EditTerminal(dr);
					else
						EditLocation(dr);

					e.Handled = true;
				}
				else if (e.KeyCode == Keys.C && e.Control)
				{
					GridEXRow r = grdLocation.GetRow();
					GridEXColumn c = grdLocation.CurrentColumn;
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

		private void frmLocationTerminalMaintenance_KeyDown(object sender, KeyEventArgs e)
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
						AddLocation();
					}
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void cnuGridOps_Opening(object sender, System.ComponentModel.CancelEventArgs e)
		{
			try
			{
				DataRow dr = grdLocation.GetDataRow();
				string loc = null, term = null;
				if (dr != null)
				{
					if (dr.Table.Columns.Contains("Terminal_Cd"))
					{
						term = ClsConvert.ToString(dr["Terminal_Cd"]);
						loc = ClsConvert.ToString(dr["Location_Cd"]);
					}
					else if (dr.Table.Columns.Contains("Location_Cd"))
					{
						term = null;
						loc = ClsConvert.ToString(dr["Location_Cd"]);
					}
				}

				cnuGridOpsEditTerm.Text = "Edit Terminal " + term;
				cnuGridOpsEditTerm.Visible = !string.IsNullOrWhiteSpace(term);

				cnuGridOpsEditLoc.Text = "Edit Location " + loc;
				cnuGridOpsEditLoc.Visible = !string.IsNullOrWhiteSpace(loc);

				cnuGridOpsAddTerm.Text = "Add New Terminal to Location " + loc;
				cnuGridOpsAddTerm.Visible = !string.IsNullOrWhiteSpace(loc);
			}
			catch (Exception ex)
			{
				ClsErrorHandler.LogException(ex);
			}
		}

		private void cnuGridOpsAddTerm_Click(object sender, EventArgs e)
		{
			try
			{
				DataRow dr = grdLocation.GetDataRow();
				if (dr == null) return;

				if (dr.Table.Columns.Contains("Terminal_Cd"))
				{
					DataRow drParent = dr.GetParentRow(relLocationTerminal);
					if (drParent != null)
						AddTerminal(drParent);
				}
				else
					AddTerminal(dr);
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}
		#endregion		// #region Grid/Toolbar Actions

		#region Insert/Update/Delete

		private void AddLocation()
		{
			try
			{
				ClsLocation loc = null;
				using (frmLocationEdit f = new frmLocationEdit())
				{
					loc = f.AddLocation();
				}
				if (loc == null) return;

				Program.Show("Location Added");

				DataRow dr = dtLocations.NewRow();
				loc.CopyToDataRow(dr);
				dtLocations.Rows.Add(dr);

				GridEXRow grow = grdLocation.GetRow(dr);
				if (grow != null)
				{
					grdLocation.Row = grow.Position;
					grdLocation.EnsureVisible(grow.Position);
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void AddTerminal(DataRow dr)
		{
			try
			{
				if (dr == null) return;

				GridEXRow gParent = grdLocation.GetRow(dr);

				ClsLocation loc = new ClsLocation(dr);
				ClsLocationTerminal term = null;
				using (frmLocationTerminalEdit f = new frmLocationTerminalEdit())
				{
					term = f.AddTerminal(loc);
				}
				if (term == null) return;

				Program.Show("Terminal Added");

				if (gParent != null) gParent.Expanded = true;

				DataRow drTerm = dtTerminals.NewRow();
				term.CopyToDataRow(drTerm);
				dtTerminals.Rows.Add(drTerm);

				GridEXRow grow = grdLocation.GetRow(drTerm);
				if (grow != null)
				{
					grdLocation.Row = grow.Position;
					grdLocation.EnsureVisible(grow.Position);
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void EditTerminal(DataRow dr)
		{
			try
			{
				if (dr == null) return;

				ClsLocationTerminal term = new ClsLocationTerminal(dr);
				using (frmLocationTerminalEdit f = new frmLocationTerminalEdit())
				{
					if (!f.EditTerminal(term)) return;
				}

				Program.Show("Terminal Updated");

				term.CopyToDataRow(dr);
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void EditLocation(DataRow dr)
		{
			try
			{
				if (dr == null) return;

				ClsLocation loc = new ClsLocation(dr);
				using (frmLocationEdit f = new frmLocationEdit())
				{
					if (!f.EditLocation(loc)) return;
				}

				Program.Show("Location Updated");

				loc.CopyToDataRow(dr);
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void DeleteTerminal(DataRow dr)
		{
			try
			{
				if (dr == null) return;

				ClsLocationTerminal term = new ClsLocationTerminal(dr);
				if (!Display.Ask("Confirm", "Delete terminal {0} - {1} from location {2}?",
					term.Terminal_Cd, term.Terminal_Dsc, term.Location_Cd)) return;

				term.Delete();

				Program.Show("Terminal Deleted");
				dtTerminals.Rows.Remove(dr);
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void DeleteLocation(DataRow dr)
		{
			try
			{
				if (dr == null) return;


				ClsLocation loc = new ClsLocation(dr);
				if (!loc.ValidateDelete())
				{
					Program.ShowError(loc.Error);
					return;
				}

				if (!Display.Ask("Confirm", "Delete location {0} - {1}?",
					loc.Location_Cd, loc.Location_Dsc)) return;

				loc.Delete();

				Program.Show("Location Deleted");
				dtLocations.Rows.Remove(dr);
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}
		#endregion		// #region Insert/Update/Delete

		private void tbbShowAll_Click(object sender, EventArgs e)
		{
			grdLocation.RootTable.FilterCondition = null;
		}
	}
}