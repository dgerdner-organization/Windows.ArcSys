using System;
using System.Data;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Configuration;
using System.Collections.Generic;
using CS2010.Common;
using CS2010.CommonWinCtrls;
using CS2010.CommonSecurity;
using CS2010.ArcSys.Business;
using CS2010.AVSS.Business;
using Janus.Windows.GridEX;

namespace CS2010.ArcSys.Win
{
	public partial class frmCustomsSubmission : frmChildBase
	{
		#region Fields

		private CustomsMgr theMgr;

		private DataTable dtAvailable;
		private DataTable dtHistory;

		#endregion		// #region Fields

		#region Constructors/Initialization/Entry

		public frmCustomsSubmission()
			: base()
		{
			InitializeComponent();

			AdjustForm(Program.MainWindow, true, null);

			WindowHelper.InitAllGrids(this);

			theMgr = new CustomsMgr();

			ClsSecurityMaster.SetSecurity(this, ClsEnvironment.User_Id.Value);
		}

		/// <summary>Used by the static Search method to ensure that no more than
		/// one of this window is visible at any given time</summary>
		private static frmCustomsSubmission theWindow;

		/// <summary>Main entry point into this window ensuring that no more than 1
		/// of this window is visible at any given time</summary>
		public static frmCustomsSubmission ShowWindow(bool performDefaultSearch)
		{
			try
			{
				if (theWindow == null)
					theWindow = new frmCustomsSubmission();
				else
					performDefaultSearch = false;

				WindowHelper.ShowChildWindow(theWindow);

				if (performDefaultSearch)
					theWindow.DefaultSearch();

				return theWindow;
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
				return null;
			}
		}

		private void frmCustomsSubmission_Load(object sender, EventArgs e)
		{
			try
			{
				ConnectAVSS();
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		public void ConnectAVSS()
		{
			if (ClsConMgr.Manager["AVSS"] == null)
			{
				ConnectionStringSettings cns = ConfigurationManager.ConnectionStrings["AVSS"];
				ClsConMgr.Manager.AddConnection("AVSS", cns.ProviderName,
					cns.ConnectionString, ClsEnvironment.UserName, "cluele55", null);

				try
				{
					ClsCustomsSubmission.GetUsingVessBerthActID(1);
					return;
				}
				catch
				{
					Program.ShowError(ClsErrorHandler.LogError(
						"Unable to connect to AVSS with user {0}, using AVSS default",
						ClsEnvironment.UserName));
				}
				ClsConMgr.Manager.RemoveConnection("AVSS");
				ClsConMgr.Manager.AddConnection("AVSS", cns.ProviderName, cns.ConnectionString,
					"avss", "friday13th", null);
			}
		}
		#endregion		// #region Constructors/Initialization/Entry

		#region Search Methods

		private void DefaultSearch()
		{
			try
			{
				//SearchOptions.Options.IncludeBlankTCNs = false;
				//SearchOptions.Options.IncludeNonDoor = false;
				//SearchOptions.Options.IncludeTransShip = false;
				//SearchOptions.Options.IncludeNonBillPay = false;
				//SearchOptions.Options.Vessel_Sail_Dt = SearchOptions.GetDefaultDate();

				PerformSearch();
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
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
				//if (SearchOptions.GetSearchCriteria() == false) return;

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
				DataTable dt1 = theMgr.SearchAvailable();
				DataTable dt2 = theMgr.SearchHistory();
				TimeSpan time = DateTime.Now - start;
				lock (grdAvail)
				{
					dtAvailable = dt1;
					dtHistory = dt2;
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

				lock (grdAvail)
				{
					try
					{
						grdAvail.DataSource = dtAvailable;
						grdAvail.RootTable.FilterCondition = null;
						grdAvail.RootTable.Caption = "Rows: " + grdAvail.RecordCount;

						grdHist.DataSource = dtHistory;
						grdHist.RootTable.FilterCondition = null;
						grdHist.RootTable.Caption = "Rows: " + grdHist.RecordCount;

						grdAvail.Focus();
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
				lock (grdAvail)
				{
					tbbSearch.Enabled = tbbSubmit.Enabled =
						grdAvail.Enabled = grdHist.Enabled = state;
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

		private void grdResults_DoubleClick(object sender, EventArgs e)
		{
			try
			{
				GridArea ga = grdAvail.HitTest();
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
					GridEXRow gr = grdAvail.GetRow();
					if (gr == null || gr.RowType != RowType.Record) return;

					ViewItem();

					e.Handled = true;
				}
				else if (e.KeyCode == Keys.C && e.Control)
				{
					GridEXRow r = grdAvail.GetRow();
					GridEXColumn c = grdAvail.CurrentColumn;
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

		private void ViewItem()
		{
			try
			{
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}
		#endregion		// #region Grid Operations/Event Handlers

		#region Menu/Toolbar Actions

		private void tbbSubmit_Click(object sender, EventArgs e)
		{
			try
			{
				DataRow[] rows = grdAvail.GetCheckedDataRows();
				if (rows == null || rows.Length <= 0)
				{
					Program.ShowError("No rows checked");
					return;
				}

				string subUser = null;
				DateTime? subDt = null;
				string subNotes = null;
				using (frmCustomsSubInfo f = new frmCustomsSubInfo())
				{
					if (!f.GetSubmissionInfo(Program.CurrentDate,
						Program.CurrentDate.AddDays(-30), Program.CurrentDate.AddDays(1))) return;

					subDt = f.SubDate;
					subUser = f.SubUser;
					subNotes = f.SubNotes;
				}

				if (!theMgr.Submit(rows, subUser, subDt, true, subNotes))
				{
					Program.ShowError(theMgr.Error);
					return;
				}

				Program.Show("Customs submission recorded. Press OK to reload history");

				RemoveAvailableRows(rows);
				RefreshHistory();
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void tbbIgnore_Click(object sender, EventArgs e)
		{
			try
			{
				DataRow[] rows = grdAvail.GetCheckedDataRows();
				if (rows == null || rows.Length <= 0)
				{
					Program.ShowError("No rows checked");
					return;
				}

				string subNotes = null;
				using (frmMemo f = new frmMemo())
				{
					if (!f.AddMemo("Customs not required", null)) return;

					subNotes = f.InputText;
				}

				string subUser = ClsEnvironment.UserName;
				if (!theMgr.Ignore(rows, subUser, subNotes))
				{
					Program.ShowError(theMgr.Error);
					return;
				}

				Program.Show("Customs information updated. Press OK to reload history");

				RemoveAvailableRows(rows);
				RefreshHistory();
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void RemoveAvailableRows(DataRow[] rows)
		{
			try
			{
				if (rows == null || rows.Length <= 0) return;

				DataTable dt = dtAvailable;
				for (int i = rows.Length - 1; i >= 0; i--)
					dt.Rows.Remove(rows[i]);
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void RefreshHistory()
		{
			try
			{
				dtHistory = theMgr.SearchHistory();
				grdHist.DataSource = dtHistory;
				grdHist.RootTable.FilterCondition = null;
				grdHist.RootTable.Caption = "Rows: " + grdHist.RecordCount;
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

		private void frmCustomsSubmission_FormClosing(object sender, FormClosingEventArgs e)
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

		private void frmCustomsSubmission_FormClosed(object sender, FormClosedEventArgs e)
		{
			try
			{
				theWindow = null;
				if (ClsConMgr.Manager["AVSS"] != null)
					ClsConMgr.Manager.RemoveConnection("AVSS");
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}
		#endregion		// #region Form Event Handlers
	}
}