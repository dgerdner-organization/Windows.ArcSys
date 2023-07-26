using System;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;
using CS2010.Common;
using CS2010.CommonWinCtrls;
using ASL.ARC.EDISQLTools;
using Janus.Windows.GridEX;
using CrystalDecisions.Shared;
using CrystalDecisions.ReportSource;
using CrystalDecisions.CrystalReports.Engine;
using System.Reflection;


namespace CS2010.ArcSys.Win
{
	public partial class frmIALPOVTracking : frmChildBase
	{
		#region Fields/Properties
		public DataTable dtReport;
		protected ClsQueries theQueryMgr;
		#endregion		// #region Fields/Properties

		#region Constructors/Initialization/Entry/Cleanup

		public frmIALPOVTracking()
		{
			InitializeComponent();
			this.Activate();
			this.MdiParent = Program.MainWindow;
			this.WindowState = FormWindowState.Maximized;


            // 2018-03-31: JD - This is needed for the Battery Lookup ...
            Program.ConnectToLINE();

			// DropDowns
			DataTable dtLoc = ClsAcmsSQL.SelectLocations();
			cmbPLOR.DataSource = dtLoc;
			cmbPLOD.DataSource = dtLoc;
			cmbPOL.DataSource = dtLoc;
			cmbPOD.DataSource = dtLoc;
			InitParameters();
		}

		private void InitParameters()
		{
			txtVoyage.Text = "";
			cmbPLOR.SelectedIndex = -1;
			cmbPLOR.SelectedText = "";
			cmbPOL.SelectedIndex = cmbPOD.SelectedIndex = -1;
			cmbPOD.SelectedText = "";
			cmbPOL.SelectedText = "";
			cmbPLOD.SelectedText = "";
			cmbCargoStatus.Text = "All";

			theQueryMgr = new ClsQueries();
			theQueryMgr.sCargoStatus = cmbCargoStatus.Text;
			theQueryMgr.sPLOR = cmbPLOR.SelectedText;
			theQueryMgr.sPOL = cmbPOL.SelectedText;
			theQueryMgr.sPOD = cmbPOD.SelectedText;
			theQueryMgr.sPLOD = cmbPLOD.SelectedText;
		}

		private void PerformSearchx()
		{
			//string sStatus = cmbCargoStatus.Text;
			//string sPLOR = cmbPLOR.SelectedText;
			//string sPOL = cmbPOL.SelectedText;
			//string sPOD = cmbPOD.SelectedText;
			//string sPLOD = cmbPLOD.SelectedText;

			//dtReport = ClsQueries.IALCargoSearch
			//        (grpPOLDate.ValueRange, sStatus, txtVoyage.Text, txtVessel.Text,
			//         sPLOR, 
			////        sPOL, sPOD, sPLOD);
			//grdResults.DataSource = dtReport;
			//if( dtReport.Rows.Count < 1 )
			//{
			//    Program.Show("No cargo found.");
			//}
		}

		#endregion		// #region Constructors/Initialization/Entry/Cleanup

		#region Event Handlers
		private void tbbSearch_Click(object sender, EventArgs e)
		{
			PerformSearch();
		}

		#endregion		// #region Event Handlers

		private void tbbClear_Click(object sender, EventArgs e)
		{
			//txtVessel.Text = "";
			InitParameters();
		}

		private void btnSearch_Click(object sender, EventArgs e)
		{
			theQueryMgr.sCargoStatus = cmbCargoStatus.Text;
			theQueryMgr.sPLOR = cmbPLOR.SelectedText;
			theQueryMgr.sPOL = cmbPOL.SelectedLocationCD;
			theQueryMgr.sPOD = cmbPOD.SelectedLocationCD;
			theQueryMgr.sPLOD = cmbPLOD.SelectedText;
			theQueryMgr.sVoyage = txtVoyage.Text;
			theQueryMgr.sVessel = txtVessel.Text;
			theQueryMgr.dtPOL = grpPOLDate.ValueRange;
			PerformSearch();
		}

		private void btnClear_Click(object sender, EventArgs e)
		{
			InitParameters();
		}

		#region Asynch Methods
		private void sbbProgressCaption_Click(object sender, EventArgs e)
		{
			CancelAsynchronousProcess();
		}
		private void AdjustGUI(bool state)
		{
			try
			{
				lock (grdResults)
				{
					btnSearch.Enabled = btnClear.Enabled = pnlMain.Panel1.Enabled = state;

					sbrChild.Visible = sbbProgressCaption.Visible =
						sbbProgressMeter.Visible = sbbProgressMeter.Enabled = !state;
					grdResults.Enabled = state;
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}
		private void UpdateGrid()
		{
			try
			{
				AdjustGUI(true);

				lock (grdResults)
				{
					grdResults.DataSource = this.dtReport;
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

		private void StartSearch()
		{
			try
			{
				DateTime start = DateTime.Now;
				TimeSpan time = DateTime.Now - start;


				lock (grdResults)
				{
					dtReport = theQueryMgr.IALCargoSearch();

    				//grdResults.DataSource = dtReport;
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
		#endregion
	}
}

	