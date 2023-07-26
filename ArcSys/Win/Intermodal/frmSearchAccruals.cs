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
using System.Collections.Generic;

namespace CS2010.ArcSys.Win
{
	public partial class frmSearchAccruals : frmChildBase, ISearchWindow
	{
		#region Fields

		private ClsCargoAccrualSearch AccrualOptions;

		private GridEXTable ComputedChargeDetailGridTab;
		private GridEXTable ExistingChargeDetailGridTab;

		private DataSet dsApComputedAccrual;

		private DataTable dtApComputedSummary
		{
			get
			{
				return (dsApComputedAccrual != null && dsApComputedAccrual.Tables.Count > 0)
					? dsApComputedAccrual.Tables[0] : null;
			}
		}

		private DataTable dtApComputedByCharge
		{
			get
			{
				return (dsApComputedAccrual != null && dsApComputedAccrual.Tables.Count > 1)
					? dsApComputedAccrual.Tables["AccrualSummaryCharges"] : null;
			}
		}

		private DataRelation relApComputedByCharge
		{
			get
			{
				return (dsApComputedAccrual != null && dsApComputedAccrual.Relations.Count > 0)
					? dsApComputedAccrual.Relations["AccrualSummaryCharges"] : null;
			}
		}

		private DataTable dtApComputedByCargo
		{
			get
			{
				return (dsApComputedAccrual != null && dsApComputedAccrual.Tables.Count > 1)
					? dsApComputedAccrual.Tables["AccrualSummaryCargo"] : null;
			}
		}

		private DataTable dtApComputedActivityChargeDetail
		{
			get
			{
				return (dsApComputedAccrual != null && dsApComputedAccrual.Tables.Count > 2)
					? dsApComputedAccrual.Tables["AccrualActivityChargeDetail"] : null;
			}
		}

		private DataSet dsApExistingAccrual;

		private DataTable dtApExistingSummary
		{
			get
			{
				return (dsApExistingAccrual != null && dsApExistingAccrual.Tables.Count > 0)
					? dsApExistingAccrual.Tables[0] : null;
			}
		}

		private DataTable dtApExistingByCharge
		{
			get
			{
				return (dsApExistingAccrual != null && dsApExistingAccrual.Tables.Count > 1)
					? dsApExistingAccrual.Tables["AccrualSummaryCharges"] : null;
			}
		}

		private DataRelation relApExistingByCharge
		{
			get
			{
				return (dsApExistingAccrual != null && dsApExistingAccrual.Relations.Count > 0)
					? dsApExistingAccrual.Relations["AccrualSummaryCharges"] : null;
			}
		}

		private DataTable dtApExistingByCargo
		{
			get
			{
				return (dsApExistingAccrual != null && dsApExistingAccrual.Tables.Count > 1)
					? dsApExistingAccrual.Tables["AccrualSummaryCargo"] : null;
			}
		}

		private DataTable dtApExistingActivityChargeDetail
		{
			get
			{
				return (dsApExistingAccrual != null && dsApExistingAccrual.Tables.Count > 2)
					? dsApExistingAccrual.Tables["AccrualActivityChargeDetail"] : null;
			}
		}

		private DataSet dsApComputedDifferences;

		private DataTable dtApComputedSummaryDiff
		{
			get
			{
				return (dsApComputedDifferences != null && dsApComputedDifferences.Tables.Count > 0)
					? dsApComputedDifferences.Tables[0] : null;
			}
		}

		private DataTable dtApComputedByChargeDiff
		{
			get
			{
				return (dsApComputedDifferences != null && dsApComputedDifferences.Tables.Count > 1)
					? dsApComputedDifferences.Tables["AccrualSummaryCharges"] : null;
			}
		}

		private DataRelation relApComputedByChargeDiff
		{
			get
			{
				return (dsApComputedDifferences != null && dsApComputedDifferences.Relations.Count > 0)
					? dsApComputedDifferences.Relations["AccrualSummaryCharges"] : null;
			}
		}

		private DataTable dtApComputedByCargoDiff
		{
			get
			{
				return (dsApComputedDifferences != null && dsApComputedDifferences.Tables.Count > 1)
					? dsApComputedDifferences.Tables["AccrualSummaryCargo"] : null;
			}
		}

		private DataTable dtApComputedChgDtlDiff
		{
			get
			{
				return (dsApComputedDifferences != null && dsApComputedDifferences.Tables.Count > 2)
					? dsApComputedDifferences.Tables["AccrualActivityChargeDetail"] : null;
			}
		}

		private DataSet dsApExistingDifferences;

		private DataTable dtApExistingSummaryDiff
		{
			get
			{
				return (dsApExistingDifferences != null && dsApExistingDifferences.Tables.Count > 0)
					? dsApExistingDifferences.Tables[0] : null;
			}
		}

		private DataTable dtApExistingByChargeDiff
		{
			get
			{
				return (dsApExistingDifferences != null && dsApExistingDifferences.Tables.Count > 1)
					? dsApExistingDifferences.Tables["AccrualSummaryCharges"] : null;
			}
		}

		private DataRelation relApExistingByChargeDiff
		{
			get
			{
				return (dsApExistingDifferences != null && dsApExistingDifferences.Relations.Count > 0)
					? dsApExistingDifferences.Relations["AccrualSummaryCharges"] : null;
			}
		}

		private DataTable dtApExistingByCargoDiff
		{
			get
			{
				return (dsApExistingDifferences != null && dsApExistingDifferences.Tables.Count > 1)
					? dsApExistingDifferences.Tables["AccrualSummaryCargo"] : null;
			}
		}

		private DataTable dtApExistingChgDtlDiff
		{
			get
			{
				return (dsApExistingDifferences != null && dsApExistingDifferences.Tables.Count > 2)
					? dsApExistingDifferences.Tables["AccrualActivityChargeDetail"] : null;
			}
		}
		#endregion		// #region Fields

		#region Constructors/Initialization/Entry

		public frmSearchAccruals()
			: base()
		{
			InitializeComponent();

			AdjustForm(Program.MainWindow, true, null);

			AccrualOptions = new ClsCargoAccrualSearch();

			ComputedChargeDetailGridTab =
				grdApComputedAccrual.RootTable.ChildTables[0].ChildTables[0];
			ExistingChargeDetailGridTab =
				grdApExistingAccrual.RootTable.ChildTables[0].ChildTables[0];

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

		private void frmSearchAccruals_Load(object sender, EventArgs e)
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
				if (GetSearchCriteria() == false) return;

				PerformSearch();
			}
			catch (Exception ex)
			{
				Program.ShowError(ex.Message);
			}
		}

		private bool GetSearchCriteria()
		{
			try
			{
				DateTime now = DateTime.Now;
				DateTime prevMonth = now.AddMonths(-1);
				DateTime initialMonth = new DateTime(prevMonth.Year, prevMonth.Month, 1);
				if (AccrualOptions.Vessel_Sail_Dt.From != null)
					initialMonth = AccrualOptions.Vessel_Sail_Dt.FromDate;
				using (frmDateSelector f = new frmDateSelector())
				{
					if (!f.GetDate(initialMonth, now)) return false;

					DateTime accDate = f.SelectedDate;
					DateTime from = new DateTime(accDate.Year, accDate.Month, 1);
					DateTime nextMonth = from.AddMonths(1);
					DateTime to = nextMonth.AddDays(-1);
					AccrualOptions.Clear();
					AccrualOptions.Vessel_Sail_Dt.From = from;
					AccrualOptions.Vessel_Sail_Dt.To = to;
					return true;
				}
			}
			catch (Exception ex)
			{
				return Program.ShowError(ex);
			}
		}

		private void PerformSearch()
		{
			try
			{
				Program.MainWindow.SetMainMenuStatus(false);

				AdjustGUI(false);

				StartAsynchronousProcess(StartSearch, UpdateResults, ResetCounter);
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
				DataSet ds2 = AccrualOptions.SearchApComputeAccrualsDS();
				DataSet ds3 = AccrualOptions.SearchApExistingAccrualsDS();
				DataSet ds4 = AccrualOptions.SearchApComputedDiffDS();
				DataSet ds5 = AccrualOptions.SearchApExistingDiffDS();
				TimeSpan time = DateTime.Now - start;
				lock (grdApComputedAccrual)
				{
					dsApComputedAccrual = ds2;
					dsApExistingAccrual = ds3;
					dsApComputedDifferences = ds4;
					dsApExistingDifferences = ds5;
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

		private void UpdateGridDS(ucGridEx grd, DataSet ds, DataTable dt, DataRelation rel,
			string caption)
		{
			try
			{
				lock (grd)
				{
					grd.DataSource = ds;
					grd.Hierarchical = true;
					grd.RootTable.FilterCondition = null;
					if (dt != null)
					{
						grd.DataMember = dt.TableName;
						if( rel != null )
							grd.RootTable.ChildTables[0].DataMember = rel.RelationName;
					}

					grd.RootTable.Caption = string.Format("{0} {1} Rows {2}",
						caption, grd.RecordCount, AccrualOptions);
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void UpdateGridDT(ucGridEx grd, DataTable dt, string caption)
		{
			try
			{
				lock (grd)
				{
					grd.DataSource = dt;
					grd.Hierarchical = false;
					grd.RootTable.FilterCondition = null;
					grd.RootTable.Caption = string.Format("{0} {1} Rows {2}",
						caption, grd.RecordCount, AccrualOptions);
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void UpdateGrids()
		{
			try
			{
				bool showDiff = tbbShowDiff.Checked;
				if (showDiff)
				{
					UpdateGridDS(grdApComputedAccrual, dsApComputedDifferences,
						dtApComputedSummaryDiff, relApComputedByChargeDiff, "Computed Accrual");
					UpdateGridDS(grdApExistingAccrual, dsApExistingDifferences,
						dtApExistingSummaryDiff, relApExistingByChargeDiff, "Saved Accrual");
					UpdateGridDT(grdApComputedByCargo, dtApComputedByCargoDiff, "Computed Accrual");
					UpdateGridDT(grdApExistingByCargo, dtApExistingByCargoDiff, "Saved Accrual");
				}
				else
				{
					UpdateGridDS(grdApComputedAccrual, dsApComputedAccrual,
						dtApComputedSummary, relApComputedByCharge, "Computed Accrual");
					UpdateGridDS(grdApExistingAccrual, dsApExistingAccrual,
						dtApExistingSummary, relApExistingByCharge, "Saved Accrual");
					UpdateGridDT(grdApComputedByCargo, dtApComputedByCargo, "Computed Accrual");
					UpdateGridDT(grdApExistingByCargo, dtApExistingByCargo, "Saved Accrual");
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}
		private void UpdateResults()
		{
			try
			{
				AdjustGUI(true);

				UpdateGrids();

				lock (grdApComputedAccrual)
				{
					lblParams.Text = string.Format("{0} Row(s) in {1:0.00} sec {2}",
						grdApComputedAccrual.RecordCount, ElapsedTime.TotalSeconds, AccrualOptions);
					lblParams.MaximumSize = new Size(pnlTop.Width - 20, 0);
					pnlTop.Height = lblParams.Height + 10;

					grdApComputedAccrual.Focus();

					splAccruals.Collapsed = (dtApExistingSummary == null ||
						dtApExistingSummary.Rows.Count <= 0);
					splAccrualByTCN.Collapsed = (dtApExistingByCargo == null ||
						dtApExistingByCargo.Rows.Count <= 0);
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
				lock (grdApComputedAccrual)
				{
					tbrMain.Enabled = state;
					sbrChild.Visible = sbbProgressCaption.Visible =
						sbbProgressMeter.Visible = !state;
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

		private void grd_LinkClicked(object sender, ColumnActionEventArgs e)
		{
			try
			{
				GridEX grd = sender as GridEX;
				if (grd == null) return;

				GridEXRow grow = grd.CurrentRow;
				Program.LinkHandler.HandleLink(grow, e.Column.Key);
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

		private void frmSearchAccruals_FormClosing(object sender, FormClosingEventArgs e)
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

		private void tpgAccrualSummary_Resize(object sender, EventArgs e)
		{
			try
			{
				grdApExistingAccrual.Height = tpgAccrualSummary.Height / 2;
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void tpgApAccrualByCargo_Resize(object sender, EventArgs e)
		{
			try
			{
				grdApExistingByCargo.Height = tpgApAccrualByCargo.Height / 2;
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void tabAccruals_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				bool vis = (tabAccruals.SelectedTab == tpgAccrualSummary);
				tbbHideDetailTable.Visible = vis;
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}
		#endregion		// #region Form Event Handlers

		#region Menu/Toolbar Actions

		private void tbbExcessColumns_Click(object sender, EventArgs e)
		{
			try
			{
				string[] nonAcctColumnsNew =
				{ "Est_Voyage_No", "Voy_Err_Flg", "Percent", "Tot_Ap_Est_Amt", "Estimate_No",
					"Orig_Location_Dsc", "Dest_Location_Dsc", "Bk_Voyage_No", "Voy_Est_Bk_Err_Flg",
					"Voy_Edt_Bk_Err_Flg", "Ves_Edt_Bk_Err_Flg", "Bk_Vessel_Cd", "Mismatch_Orig_Count",
					"Mismatch_Dest_Count", "Mismatch_Bk_Count", "Mismatch_Pcfn_Count",
					"Mismatch_Sail_Count", "Mismatch_Len_Count", "Mismatch_Wid_Count", "Mismatch_Hgt_Count",
					"Mismatch_Wgt_Count", "Mismatch_Dwt_Count", "Mismatch_Cft_Count", "Mismatch_Mt_Count"};
				bool colVisible = !tbbExcessColumns.Checked;
				foreach (string colName in nonAcctColumnsNew)
				{
					if (grdApComputedAccrual.RootTable.Columns.Contains(colName))
						grdApComputedAccrual.RootTable.Columns[colName].Visible = colVisible;
					if (grdApComputedAccrual.Tables[1].Columns.Contains(colName))
						grdApComputedAccrual.Tables[1].Columns[colName].Visible = colVisible;
					if (grdApExistingAccrual.RootTable.Columns.Contains(colName))
						grdApExistingAccrual.RootTable.Columns[colName].Visible = colVisible;
					if (grdApExistingAccrual.Tables[1].Columns.Contains(colName))
						grdApExistingAccrual.Tables[1].Columns[colName].Visible = colVisible;
					if (ComputedChargeDetailGridTab.Columns.Contains(colName))
						ComputedChargeDetailGridTab.Columns[colName].Visible = colVisible;
					if (ExistingChargeDetailGridTab.Columns.Contains(colName))
						ExistingChargeDetailGridTab.Columns[colName].Visible = colVisible;
					if (grdApComputedByCargo.RootTable.Columns.Contains(colName))
						grdApComputedByCargo.RootTable.Columns[colName].Visible = colVisible;
					if (grdApExistingByCargo.RootTable.Columns.Contains(colName))
						grdApExistingByCargo.RootTable.Columns[colName].Visible = colVisible;
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void tbbHideDetailTable_Click(object sender, EventArgs e)
		{
			try
			{
				bool tabVisible = !tbbHideDetailTable.Checked;
				if (tabVisible)
				{
					if (grdApComputedAccrual.Tables.Count < 3)
						grdApComputedAccrual.RootTable.ChildTables[0].ChildTables.
							Add(ComputedChargeDetailGridTab);
					if (grdApExistingAccrual.Tables.Count < 3)
						grdApExistingAccrual.RootTable.ChildTables[0].ChildTables.
							Add(ExistingChargeDetailGridTab);
				}
				else
				{
					grdApComputedAccrual.RootTable.ChildTables[0].ChildTables.RemoveAt(0);
					grdApExistingAccrual.RootTable.ChildTables[0].ChildTables.RemoveAt(0);
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void tbbAccrue_Click(object sender, EventArgs e)
		{
			AccrueCharges();
		}

		private void AccrueCharges()
		{
			try
			{
				DataTable dt = dtApComputedActivityChargeDetail;
				if (dt == null || dt.Rows.Count <= 0)
				{
					Program.ShowError("Nothing to accrue");
					return;
				}

				if (!Display.Ask("Confirm",
					"This will save the accrual information to the database. Continue?")) return;

				AdjustGuiAccruing(true);

				string errMsg = null, warnMsg = null;
				if (!ClsCargoAccrual.AccrueCharges(dt, AccrualOptions.Vessel_Sail_Dt, out errMsg, out warnMsg))
				{
					string msg = string.Format("{0}{1}{2}", errMsg,
						(string.IsNullOrWhiteSpace(warnMsg) ? null : "\r\nWarnings\r\n"),
						warnMsg);
					using (frmMemo f = new frmMemo())
					{
						f.ViewTextFull("Error Information", msg, "Close");
					}
				}
				else
				{
					if (string.IsNullOrWhiteSpace(warnMsg))
						Program.Show("Accrual saved. After clicking OK, the search operation will run.");
					else
					{
						string msg = "Accrual saved but there were warnings.\r\n" +
							"After closing this window, the search operation will run.\r\n\r\n" +
							warnMsg;
						using (frmMemo f = new frmMemo())
						{
							f.ViewTextFull("Accrual Information", msg, "Close");
						}
					}

					PerformSearch();
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
			finally
			{
				AdjustGuiAccruing(false);
			}
		}

		private void AdjustGuiAccruing(bool accrualStart)
		{
			try
			{
				tbrMain.Enabled = tabAccruals.Enabled = !accrualStart;
				tbbAccrue.Text = ( accrualStart ) ? "Saving Accrual..." : "Accrue";
				Program.MainWindow.SetMainMenuStatus(!accrualStart);
				Application.DoEvents();
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void tbbShowDiff_Click(object sender, EventArgs e)
		{
			UpdateGrids();
		}
		#endregion		// #region Menu/Toolbar Actions

        private void grdApExistingAccrual_FormattingRow(object sender, RowLoadEventArgs e)
        {

        }
	}
}