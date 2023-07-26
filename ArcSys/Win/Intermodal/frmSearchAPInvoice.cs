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
using System.IO;

namespace CS2010.ArcSys.Win
{
	public partial class frmSearchAPInvoice : frmChildBase, ISearchWindow
	{
		#region Fields
		string VendorCd
		{
			get {return ucVendorCombo.SelectedVendorCD;}
		}
		string InvoiceNo
		{
			get { return txtInvoiceNo.Text; }
		}

		private DataTable dtAPInvoices;

		#endregion		// #region Fields

		#region Constructors/Initialization/Entry

		public frmSearchAPInvoice()
			: base()
		{
			InitializeComponent();

			AdjustForm(Program.MainWindow, true, null);

			WindowHelper.InitAllGrids(this);

			ClsSecurityMaster.SetSecurity(this, ClsEnvironment.User_Id.Value);
		}

		public void ShowSearch(bool showOptions)
		{
			try
			{
				//if (showOptions == true) SearchParameters();
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

		private void frmSearchContractMod_Load(object sender, EventArgs e)
		{
			try
			{
				btnSearch.Focus();
				ActiveControl = btnSearch;
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}
		#endregion		// #region Constructors/Initialization/Entry

		#region Search Methods

		private void SearchParameters()
		{
			try
			{

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
				if (Program.MainWindow != null)
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
				DataTable dt = ClsApInvoice.SearchApInvoice(VendorCd, InvoiceNo);
				TimeSpan time = DateTime.Now - start;
				lock (grdResults)
				{
					dtAPInvoices = dt;
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
					DataTable dt = dtAPInvoices;
					grdResults.DataSource = dtAPInvoices;

					grdResults.RootTable.FilterCondition = null;

					grdResults.Focus();
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
			finally
			{
				if (Program.MainWindow != null)	
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
				if (Program.MainWindow != null)	
					Program.MainWindow.SetMainMenuStatus(true);
			}
		}

		private void AdjustGUI(bool state)
		{
			try
			{
				lock (grdResults)
				{
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

				EditAPInvoice();
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

					EditAPInvoice();

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

		private void cnuGridEditMod_Click(object sender, EventArgs e)
		{
			EditAPInvoice();
		}

		private void EditAPInvoice()
		{
			try
			{
				DataRow dr = grdResults.GetDataRow();
				ClsApInvoice api = new ClsApInvoice(dr);
				if (dr == null) return;

				using (frmViewAPInvoice f = new frmViewAPInvoice())
				{
					ViewWindowManager.View(api);
					//f.ViewAPInvoice(api);
				}

				//if (dr.Table.Columns.Contains("Estimate_ID"))
				//{
				//    long? estID = ClsConvert.ToInt64Nullable(dr["Estimate_ID"]);
				//    ClsEstimate est = (estID != null) ? ClsEstimate.GetUsingKey(estID.Value) : null;
				//    if (est != null) ViewWindowManager.View(est);
				//}
				//else
				//{
				//    ClsContractMod cmod = new ClsContractMod(dr);
				//    using (frmCreateContractMod f = new frmCreateContractMod())
				//    {
				//        if (!f.EditMod(cmod)) return;
				//        cmod.Update();
				//        cmod.CopyToDataRow(dr);
				//    }
				//}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void grdResults_ColumnButtonClick(object sender, ColumnActionEventArgs e)
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

		#region Form Event Handlers

		private void frmSearchContractMod_FormClosing(object sender, FormClosingEventArgs e)
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

		private void btnSearch_Click(object sender, EventArgs e)
		{
			SearchParameters();
		}

		private void btnClear_Click(object sender, EventArgs e)
		{
			WindowHelper.ClearAllControls(this);
		}
		#endregion		// #region Form Event Handlers
	}
}