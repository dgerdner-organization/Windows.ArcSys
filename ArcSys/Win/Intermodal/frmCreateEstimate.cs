using System;
using System.Data;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using CS2010.Common;
using CS2010.CommonWinCtrls;
using CS2010.CommonSecurity;
using Janus.Windows.GridEX;
using CS2010.ArcSys.Business;
using System.Collections.Generic;

namespace CS2010.ArcSys.Win
{
	public partial class frmCreateEstimate : frmChildBase
	{
		#region Fields

		private DataSet dsAvailable;
		private frmCreateEstimateOptions SearchOptions;

		private DataTable dtGroups
		{
			get
			{
				return (dsAvailable != null && dsAvailable.Tables.Count > 0)
					? dsAvailable.Tables[0] : null;
			}
		}

		private DataTable dtActivities
		{
			get
			{
				return (dsAvailable != null && dsAvailable.Tables.Count > 1)
					? dsAvailable.Tables[1] : null;
			}
		}

		#endregion		// #region Fields

		#region Constructors/Initialization/Entry

		public frmCreateEstimate() : base()
		{
			InitializeComponent();

			AdjustForm(Program.MainWindow, true, null);

			SearchOptions = new frmCreateEstimateOptions();
			SearchOptions.SetDefaults();

			WindowHelper.InitAllGrids(this);

			ClsSecurityMaster.SetSecurity(this, ClsEnvironment.User_Id.Value);
		}

		/// <summary>Used by the static Search method to ensure that no more than
		/// one frmCreateEstimate window is visible at any given time</summary>
		private static frmCreateEstimate SearchWindow;

		/// <summary>Main entry point into this window ensuring that no more than 1
		/// frmCreateEstimate window is visible at any given time</summary>
		public static frmCreateEstimate Search(bool showOptions, bool performDefaultSearch)
		{
			try
			{
				if (SearchWindow == null)
					SearchWindow = new frmCreateEstimate();
				else
					performDefaultSearch = false;

				WindowHelper.ShowChildWindow(SearchWindow);

				if (performDefaultSearch)
					SearchWindow.DefaultSearch();
				else if (showOptions)
					SearchWindow.SearchParameters();

				return SearchWindow;
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
				return null;
			}
		}

		private void frmCreateEstimate_Load(object sender, EventArgs e)
		{
			try
			{
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}
		#endregion		// #region Constructors/Initialization/Entry

		#region Search Methods

		private void DefaultSearch()
		{
			try
			{
				SearchOptions.Options.IncludeBlankTCNs = false;
				SearchOptions.Options.IncludeNonDoor = false;
				SearchOptions.Options.IncludeTransShip = false;
				SearchOptions.Options.IncludeNonBillPay = false;
				SearchOptions.Options.Vessel_Sail_Dt = SearchOptions.GetDefaultDate();

				PerformSearch();
			}
			catch (Exception ex)
			{
				Program.ShowError(ex.Message);
			}
		}

		private void tbbSearch_Click(object sender, EventArgs e)
		{
			SearchParameters(); 
		}

		private void SearchParameters()
		{
			try
			{
				if (SearchOptions.GetSearchCriteria() == false) return;

				PerformSearch();
			}
			catch (Exception ex)
			{
				Program.ShowError(ex.Message);
			}
		}

		private void PerformSearch()
		{
			try
			{
				Program.MainWindow.SetMainMenuStatus(false);

				AdjustGUI(false);

				StartAsynchronousProcess(StartSearch, UpdateGrid, ResetCounter);
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private TimeSpan ElapsedTime;

		private void StartSearch()
		{
			try
			{
				DateTime start = DateTime.Now;
				DataSet ds = SearchOptions.Options.SearchAvailableDS();
				TimeSpan time = DateTime.Now - start;
				lock (grdResults)
				{
					dsAvailable = ds;
					ElapsedTime = time;
				}
			}
			catch (Exception ex)
			{
				if (ex.Message.
					IndexOf("Cancel", StringComparison.InvariantCultureIgnoreCase) < 0)
					Program.ShowError(ex);
				else
					Program.ShowError("Search cancelled by user");
			}
			finally
			{
				AsynchronousProcessComplete = true;
			}
		}

		private void UpdateGrid()
		{
			try
			{
				AdjustGUI(true);

				lock (grdResults)
				{
					try
					{
						DataTable dt = null;
						DataRelation rel = null;
						if (dsAvailable != null)
						{
							if (dsAvailable.Tables.Count > 0) dt = dsAvailable.Tables[0];
							if (dsAvailable.Relations.Count > 0) rel = dsAvailable.Relations[0];
						}

						grdResults.DataSource = dsAvailable;
						if (dt != null)
						{
							if (dt.Rows.Count > 0 && rel != null)
								grdResults.RootTable.ChildTables[0].DataMember = rel.RelationName;
							grdResults.DataMember = dt.TableName;
						}

						grdResults.RootTable.FilterCondition = null;

						lblParams.Text = string.Format("{0} Row(s) in {1:0.00} sec {2}",
							grdResults.RecordCount, ElapsedTime.TotalSeconds, SearchOptions.Options);
						lblParams.MaximumSize = new Size(pnlTop.Width - 20, 0);
						pnlTop.Height = lblParams.Height + 10;

						grdResults.Focus();
					}
					catch (Exception ex)
					{
						Program.ShowError(ex);
					}
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
			finally
			{
				Program.MainWindow.SetMainMenuStatus(true);
			}
		}

		private void ResetCounter()
		{
			try
			{
				AdjustGUI(true);
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
			finally
			{
				Program.MainWindow.SetMainMenuStatus(true);
			}
		}

		private void AdjustGUI(bool state)
		{
			try
			{
				lock (grdResults)
				{
					tbbSearch.Enabled = tbbOptions.Enabled = grdResults.Enabled = state;
					sbrChild.Visible = sbbProgressCaption.Visible =
						sbbProgressMeter.Visible = !state;
					grdResults.Enabled = state;
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void sbbProgressCaption_Click(object sender, EventArgs e)
		{
			CancelAsynchronousProcess();
		}
		#endregion		// #region Search Methods

		#region Grid Operations/Event Handlers

		public static void RefreshRow()
		{
			try
			{
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void grdResults_DoubleClick(object sender, EventArgs e)
		{
			try
			{
				GridArea ga = grdResults.HitTest();
				if (ga != GridArea.Cell) return;

				ViewItem();
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void grdResults_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				if (e.KeyCode == Keys.Enter)
				{
					GridEXRow gr = grdResults.GetRow();
					if (gr == null || gr.RowType != RowType.Record) return;

					ViewItem();

					e.Handled = true;
				}
				else if (e.KeyCode == Keys.C && e.Control)
				{
					GridEXRow r = grdResults.GetRow();
					GridEXColumn c = grdResults.CurrentColumn;
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

		private ClsEstimate GetCurrentEstimate()
		{
			try
			{
				DataRow dr = grdResults.GetDataRow();
				if (dr == null) return null;

				string vy = ClsConvert.ToString(dr["BK_Voyage_No"]);
				string orig = ClsConvert.ToString(dr["Orig_Location_Cd"]);
				string dest = ClsConvert.ToString(dr["Dest_Location_Cd"]);
				if (string.IsNullOrEmpty(vy) || string.IsNullOrEmpty(orig) ||
					string.IsNullOrEmpty(dest)) return null;

				ClsEstimate est = ClsEstimate.GetEstimate(vy, orig, dest);
				return est;
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
				return null;
			}
		}

		private void ViewItem()
		{
			try
			{
				ClsEstimate est = GetCurrentEstimate();
				if (est != null) ViewWindowManager.View(est);
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}
		#endregion		// #region Grid Operations/Event Handlers

		#region Menu/Toolbar Actions

		private void cnuOptionsCreateEstimate_Click(object sender, EventArgs e)
		{
			CreateEstimate();
		}

		private void CreateEstimate()
		{
			try
			{
				DataRow[] rows = grdResults.GetCheckedDataRows();
				if (rows == null || rows.Length <= 0)
				{
					Program.ShowError("No rows checked");
					return;
				}

				List<ClsCargoActivity> lstActs = new List<ClsCargoActivity>();
				string voyage_no = null, orig_location_cd = null, dest_location_cd = null,
					origDsc = null, destDsc = null;
				foreach (DataRow dr in rows)
				{
					string vy = ClsConvert.ToString(dr["BK_Voyage_No"]);
					if (string.IsNullOrEmpty(voyage_no))
						voyage_no = vy;
					else
					{
						if (string.Compare(voyage_no, vy, true) != 0)
						{
							Program.ShowError("Cannot mix voyages when creating an estimate");
							return;
						}
					}
					string orig = ClsConvert.ToString(dr["Orig_Location_Cd"]);
					origDsc = ClsConvert.ToString(dr["Orig_Location_Dsc"]);
					if (string.IsNullOrEmpty(orig_location_cd))
						orig_location_cd = orig;
					else
					{
						if (string.Compare(orig_location_cd, orig, true) != 0)
						{
							Program.ShowError("Cannot mix origin locations when creating an estimate");
							return;
						}
					}
					string dest = ClsConvert.ToString(dr["Dest_Location_Cd"]);
					destDsc = ClsConvert.ToString(dr["Dest_Location_Dsc"]);
					if (string.IsNullOrEmpty(dest_location_cd))
						dest_location_cd = dest;
					else
					{
						if (string.Compare(dest_location_cd, dest, true) != 0)
						{
							Program.ShowError("Cannot mix destination locations when creating an estimate");
							return;
						}
					}

					lstActs.Add(new ClsCargoActivity(dr));
				}

				if (!Display.Ask("Confirm", "Create Estimate for {0} {1} ({2}) to {3} ({4})",
					voyage_no, orig_location_cd, origDsc, dest_location_cd, destDsc)) return;

				string error = null;
				ClsEstimate est = ClsEstimate.CreateEstimate(voyage_no, orig_location_cd, dest_location_cd,
					lstActs, out error);
				if (est == null)
				{
					Program.ShowError(error);
					return;
				}

				RemoveRows(rows);

				ViewWindowManager.View(est);
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void tbbOptions_DropDownOpening(object sender, EventArgs e)
		{
			try
			{
				ClsEstimate est = GetCurrentEstimate();
				if (est == null)
				{
					cnuOptionsViewEstimate.Enabled = false;
					cnuOptionsViewEstimate.Text = "View Estimate";
				}
				else
				{
					cnuOptionsViewEstimate.Enabled = true;
					cnuOptionsViewEstimate.Text = string.Format("View Estimate {0}", est);
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void cnuOptionsViewEstimate_Click(object sender, EventArgs e)
		{
			ViewItem();
		}

		private void cnuOptionsDeleteCargo_Click(object sender, EventArgs e)
		{
			try
			{
				DataRow[] rows = grdResults.GetCheckedDataRows();
				if (rows == null || rows.Length <= 0)
				{
					Program.ShowError("No rows checked");
					return;
				}

				if (!Display.Ask("Confirm", "Delete {0} cargo row(s)?", rows.Length)) return;

				string error = null;
				if( !ClsCargoActivity.DeleteCargoActivities(rows, out error) )
				{
					Program.ShowError(error);
					return;
				}

				RemoveRows(rows);

				grdResults.UnCheckAllRecords();
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void cnuOptionsNonBillable_Click(object sender, EventArgs e)
		{
			try
			{
				DataRow[] rows = grdResults.GetCheckedDataRows();
				if (rows == null || rows.Length <= 0)
				{
					Program.ShowError("No rows checked");
					return;
				}

				if (!Display.Ask("Confirm", "Set {0} row(s) to non-billable?", rows.Length)) return;

				string error = null;
				if (!ClsCargoActivity.SetBillablePayable(rows, true, "N", false, null, out error))
				{
					Program.ShowError(error);
					return;
				}

				List<DataRow> remove = new List<DataRow>();
				DataTable dt = dtActivities;
				for (int i = rows.Length - 1; i >= 0; i--)
				{
					DataRow dr = rows[i];
					string pay = ClsConvert.ToString(dr["Payable_Flg"]);
					if (pay == "N")				// If payable is N then both pay and
						remove.Add(dr);			// bill are N, so we can remove the row
					else
						dr["Billable_Flg"] = ClsConvert.ToDbObject("N");	// Otherwise update row
				}

				RemoveRows(remove.ToArray());

				grdResults.UnCheckAllRecords();
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void cnuOptionsNonPayable_Click(object sender, EventArgs e)
		{
			try
			{
				DataRow[] rows = grdResults.GetCheckedDataRows();
				if (rows == null || rows.Length <= 0)
				{
					Program.ShowError("No rows checked");
					return;
				}

				if (!Display.Ask("Confirm", "Set {0} row(s) to non-payable?", rows.Length)) return;

				string error = null;
				if (!ClsCargoActivity.SetBillablePayable(rows, false, null, true, "N", out error))
				{
					Program.ShowError(error);
					return;
				}

				List<DataRow> remove = new List<DataRow>();
				DataTable dt = dtActivities;
				for (int i = rows.Length - 1; i >= 0; i--)
				{
					DataRow dr = rows[i];
					string bill = ClsConvert.ToString(dr["Billable_Flg"]);
					if (bill == "N")			// If billable is N then both bill and
						remove.Add(dr);			// pay are N, so we can remove the row
					else
						dr["Payable_Flg"] = ClsConvert.ToDbObject("N");	// Otherwise update the row
				}

				RemoveRows(remove.ToArray());

				grdResults.UnCheckAllRecords();
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void cnuOptionsNonBillPay_Click(object sender, EventArgs e)
		{
			try
			{
				DataRow[] rows = grdResults.GetCheckedDataRows();
				if (rows == null || rows.Length <= 0)
				{
					Program.ShowError("No rows checked");
					return;
				}

				if (!Display.Ask("Confirm",
					"This will set {0} row(s) to non-billable and non-payable.\r\n" +
					"Any activities selected will no longer be available to be added\r\n" +
					"to an estimate. Continue?", rows.Length)) return;

				string error = null;
				if (!ClsCargoActivity.SetBillablePayable(rows, true, "N", true, "N", out error))
				{
					Program.ShowError(error);
					return;
				}

				RemoveRows(rows);

				grdResults.UnCheckAllRecords();
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void RemoveRows(DataRow[] rows)
		{
			try
			{
				if (rows == null || rows.Length <= 0) return;

				DataRelation rel = (dsAvailable != null) ? dsAvailable.Relations[0] : null;
				List<DataRow> parentRows = new List<DataRow>();
				DataTable dt = dtActivities;
				for (int i = rows.Length - 1; i >= 0; i--)
				{
					if (rel != null)
					{
						DataRow parent = rows[i].GetParentRow(rel);
						if (parent != null)
						{
							if (!parentRows.Contains(parent))
								parentRows.Add(parent);
						}
					}
					dtActivities.Rows.Remove(rows[i]);
				}

				if (parentRows.Count > 0 && rel != null)
				{
					foreach (DataRow dr in parentRows)
					{
						DataRow[] childRows = dr.GetChildRows(rel);
						int count = (childRows != null) ? childRows.Length : 0;
						dr["Act_Count"] = ClsConvert.ToDbObject(count);
					}
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}
		#endregion		// #region Menu/Toolbar Actions

		#region Form Event Handlers

		private void tbbClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void frmCreateEstimate_FormClosing(object sender, FormClosingEventArgs e)
		{
			try
			{
				if (e.CloseReason == CloseReason.WindowsShutDown) return;

				if (IsRunning)
				{
					e.Cancel = true;
					Program.Show("Cancel the search before closing the window");
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void frmCreateEstimate_FormClosed(object sender, FormClosedEventArgs e)
		{
			SearchWindow = null;
		}

		private void pnlTop_Resize(object sender, EventArgs e)
		{
			try
			{
				lblParams.MaximumSize = new Size(pnlTop.Width - 20, 0);
				pnlTop.Height = lblParams.Height + 10;
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}
		#endregion		// #region Form Event Handlers
	}
}