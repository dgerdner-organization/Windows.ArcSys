using System;
using System.Data;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using CS2010.Common;
using CS2010.CommonWinCtrls;
using CS2010.CommonSecurity;
using CS2010.ArcSys.Business;
using Janus.Windows.GridEX;

namespace CS2010.ArcSys.Win
{
	public partial class frmSearchEstimate : frmChildBase, ISearchWindow
	{
		#region Fields

		private DataSet dsEstimates;
		private DataSet dsCharges;
		private frmSearchEstimateOptions SearchOptions;

		private DataTable dtEstimates
		{
			get
			{
				return (dsEstimates != null && dsEstimates.Tables.Count > 0)
					? dsEstimates.Tables[0] : null;
			}
		}

		private DataTable dtActivities
		{
			get
			{
				return (dsEstimates != null && dsEstimates.Tables.Count > 1)
					? dsEstimates.Tables[1] : null;
			}
		}

		private DataTable dtCharges
		{
			get
			{
				return (dsCharges != null && dsCharges.Tables.Count > 1)
					? dsCharges.Tables[1] : null;
			}
		}
		#endregion		// #region Fields

		#region Constructors/Initialization/Entry

		public frmSearchEstimate()
			: base()
		{
			InitializeComponent();

			AdjustForm(Program.MainWindow, true, null);

			SearchOptions = new frmSearchEstimateOptions();

			WindowHelper.InitAllGrids(this);

			ClsSecurityMaster.SetSecurity(this, ClsEnvironment.User_Id.Value);
		}

		public void ShowSearch(bool showOptions)
		{
			try
			{
				if (showOptions == true) SearchParameters();
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		public void RefreshResults()
		{
			throw new NotImplementedException();
		}

		private void frmSearchEstimate_Load(object sender, EventArgs e)
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
				DataSet ds = SearchOptions.Options.SearchExistingDS();
				DataSet ds2 = SearchOptions.Options.SearchChargesDS();
				TimeSpan time = DateTime.Now - start;
				lock (grdResults)
				{
					dsEstimates = ds;
					dsCharges = ds2;
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
						if (dsEstimates != null)
						{
							if (dsEstimates.Tables.Count > 0) dt = dsEstimates.Tables[0];
							if (dsEstimates.Relations.Count > 0) rel = dsEstimates.Relations[0];
						}

						grdResults.DataSource = dsEstimates;
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

				lock (grdChargesByEstimate)
				{
					try
					{
						DataTable dt = null;
						DataRelation rel = null;
						if (dsCharges != null)
						{
							if (dsCharges.Tables.Count > 0) dt = dsCharges.Tables[0];
							if (dsCharges.Relations.Count > 0) rel = dsCharges.Relations[0];
						}

						grdChargesByEstimate.DataSource = dsCharges;
						if (dt != null)
						{
							if (dt.Rows.Count > 0 && rel != null)
								grdChargesByEstimate.RootTable.ChildTables[0].DataMember = rel.RelationName;
							grdChargesByEstimate.DataMember = dt.TableName;
						}

						grdChargesByEstimate.RootTable.FilterCondition = null;
					}
					catch (Exception ex)
					{
						Program.ShowError(ex);
					}
				}

				lock (grdAllCharges)
				{
					grdAllCharges.DataSource = dtCharges;
					grdAllCharges.RootTable.FilterCondition = null;
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

				ViewItem(grdResults);
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

					ViewItem(grdResults);

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

		private void ViewItem(ucGridEx grd)
		{
			try
			{
				DataRow dr = grd.GetDataRow();
				if (dr == null) return;

				ClsEstimate est = new ClsEstimate(dr);
				ViewWindowManager.View(est);
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void grdResults_SelectionChanged(object sender, EventArgs e)
		{
			try
			{
				GridEXFormatCondition fc = grdResults.RootTable.FormatConditions["fmtLoss"];
				GridEXRow grow = grdResults.GetRow();
				Color c = SystemColors.HighlightText;
				if (grow != null && grow.RowType == RowType.Record && grow.Table == grdResults.RootTable)
				{
					if (fc.EvaluateRow(grow))
						c = Color.Red;
				}
				grdResults.SelectedFormatStyle.ForeColor = c;
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void grdChargesByEstimate_DoubleClick(object sender, EventArgs e)
		{
			try
			{
				GridArea ga = grdChargesByEstimate.HitTest();
				if (ga != GridArea.Cell) return;

				ViewEstimate(grdChargesByEstimate);
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void ViewEstimate(ucGridEx grd)
		{
			try
			{
				DataRow dr = grd.GetDataRow();
				if (dr == null || dr.Table.Columns.Contains("Estimate_ID") == false ) return;

				long? id = ClsConvert.ToInt64Nullable(dr["Estimate_ID"]);
				ClsEstimate est = ( id != null ) ? ClsEstimate.GetUsingKey(id.Value) : null;
				if( est != null ) ViewWindowManager.View(est);
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void grdChargesByEstimate_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				if (e.KeyCode == Keys.Enter)
				{
					GridEXRow gr = grdChargesByEstimate.GetRow();
					if (gr == null || gr.RowType != RowType.Record) return;

					ViewEstimate(grdChargesByEstimate);

					e.Handled = true;
				}
				else if (e.KeyCode == Keys.C && e.Control)
				{
					GridEXRow r = grdChargesByEstimate.GetRow();
					GridEXColumn c = grdChargesByEstimate.CurrentColumn;
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

		private void grdAllCharges_DoubleClick(object sender, EventArgs e)
		{
			try
			{
				GridArea ga = grdAllCharges.HitTest();
				if (ga != GridArea.Cell) return;

				ViewEstimate(grdAllCharges);
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}
		#endregion		// #region Grid Operations/Event Handlers

		#region Form Event Handlers

		private void tbbClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void frmSearchEstimate_FormClosing(object sender, FormClosingEventArgs e)
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