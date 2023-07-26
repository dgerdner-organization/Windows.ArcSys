using System;
using System.Data;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using CS2010.Common;
using CS2010.CommonWinCtrls;
using CS2010.ArcSys.Business;
using Janus.Windows.GridEX;

namespace CS2010.ArcSys.Win
{
	public partial class frmSearchTerminals : frmChildBase, ISearchWindow
	{
		#region Fields

		private DataSet dsTerminals;
		private frmSearchTerminalsOptions SearchOptions;

		private DataTable dtTerminals
		{
			get
			{
				return (dsTerminals != null && dsTerminals.Tables.Count > 0)
					? dsTerminals.Tables[0] : null;
			}
		}

		private DataTable dtAdresses
		{
			get
			{
				return (dsTerminals != null && dsTerminals.Tables.Count > 1)
					? dsTerminals.Tables[1] : null;
			}
		}

		private DataTable dtContacts
		{
			get
			{
				return (dsTerminals != null && dsTerminals.Tables.Count > 1)
					? dsTerminals.Tables[2] : null;
			}
		}

		private DataTable dtLinks
		{
			get
			{
				return (dsTerminals != null && dsTerminals.Tables.Count > 1)
					? dsTerminals.Tables[3] : null;
			}
		}
		#endregion		// #region Fields

		#region Constructors/Initialization/Entry

		public frmSearchTerminals()
			: base()
		{
			InitializeComponent();

			AdjustForm(Program.MainWindow, true, null);

			SearchOptions = new frmSearchTerminalsOptions();

			WindowHelper.InitAllGrids(this);
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

		private void frmSearchTerminals_Load(object sender, EventArgs e)
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

		private void tbbMainSearch_Click(object sender, EventArgs e)
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
				DataSet ds = SearchOptions.Options.SearchTerminalDS();
				TimeSpan time = DateTime.Now - start;
				lock (grdResults)
				{
					dsTerminals = ds;
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
						if (dsTerminals != null)
						{
							if (dsTerminals.Tables.Count > 0) dt = dsTerminals.Tables[0];
							if (dsTerminals.Relations.Count > 0) rel = dsTerminals.Relations[0];
						}

						grdResults.DataSource = dsTerminals;
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
					tbbMainSearch.Enabled = grdResults.Enabled = state;
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

				ClsTerminal aTerm = new ClsTerminal(dr);
				using (frmEditTerminal f = new frmEditTerminal())
				{
					if (!f.EditTerminal(aTerm)) return;
				}

				RefreshRow();
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}
		#endregion		// #region Grid Operations/Event Handlers

		#region Menu/Toolbar Actions

		private void tbbMainNewTerminal_Click(object sender, EventArgs e)
		{
			try
			{
				using (frmEditTerminal f = new frmEditTerminal())
				{
					ClsTerminal term = f.AddTerminal();
					if (term == null) return;
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

		private void frmSearchTerminals_FormClosing(object sender, FormClosingEventArgs e)
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