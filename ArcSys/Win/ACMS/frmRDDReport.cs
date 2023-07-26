using System;
using System.Data;
using System.Data.Common;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using CS2010.Common;
using CS2010.CommonWinCtrls;
using CS2010.CommonSecurity;
using CS2010.ArcSys.Business;
using Janus.Windows.GridEX;
using System.IO;
using System.Collections.Generic;
using ASL.ARC.EDISQLTools;

namespace CS2010.ArcSys.Win
{
	public partial class frmRDDReport : frmChildBase, ISearchWindow
	{
		#region Fields

		//string locationPOD
		//{
		//    get 
		//    {
		//        return cmbPOD.Values.ToString();
		//    }
		//}

		string VesselCd 
		{ 
			get 
			{
				string s = cmbVessel.SelectedVesselCD;
				if (!string.IsNullOrEmpty(s))
					return "'" + s + "'";
				return s;
			} 
		}
		string VoyageNo 
		{ 
			get 
			{
				return cmbVoyages.VoyageCDs;
			} 
		}
		string PCFN 
		{ 
			get 
			{ 
				return AddQuotes(txtPCFN.Text); 
			} 
		}
		string POL
		{
			get
			{
				string s = cmbPOL.LocationCDs;
				return s;
			}
		}
		string POD
		{
			get
			{
				string s = cmbPOD.LocationCDs;
				//s = AddQuotes(s);
				return s;
			}
		}
		string PLOD
		{
			get
			{
				return cmbPLOD.LocationCDs;
			}
		}
		private DataTable dtITVHistory;

		#endregion		// #region Fields

		#region Constructors/Initialization/Entry

		public frmRDDReport()
			: base()
		{
			InitializeComponent();

			cmbMoveType.SetTableSource(false);
			cmbPOL.ButtonEnabled = true;
			cmbPOL.ButtonOKText = "OK";
			cmbPOL.ButtonCancelText = "Cancel";
			cmbPOL.DropDownButtonsVisible = true;

			cmbPOD.ButtonEnabled = true;
			cmbPOD.ButtonOKText = "OK";
			cmbPOD.ButtonCancelText = "Cancel";
			cmbPOD.DropDownButtonsVisible = true;
			cmbPLOD.DropDownButtonsVisible = true;
			cmbMoveType.DropDownButtonsVisible = true;
			cmbVoyages.ButtonEnabled = true;
			cmbVoyages.DropDownButtonsVisible = true;
			SetDefaults();

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
				ClsCommercialEDIQueries.EDIQueryParms parms = new ClsCommercialEDIQueries.EDIQueryParms();
				parms.VoyageNo = VoyageNo;
				parms.PCFN = PCFN;
				parms.POLCd = POL;
				parms.PODCd = POD;
				parms.MoveTypeCd = cmbMoveType.MoveTypeCDs;
				parms.PLODCd = cmbPLOD.LocationCDs;
				parms.VesselCd = VesselCd;
				DateRange dr = dateRDDRange.ValueRange;
				if (!dateRDDRange.CheckBoxChecked)
					dr = new DateRange();
					
				dtITVHistory = ClsArcSQL.GetRDDReport(parms.VesselCd, parms.VoyageNo, parms.MoveTypeCd, parms.POLCd, parms.PODCd, parms.PLODCd, parms.PCFN, dateRDDRange.ValueRange);
				TimeSpan time = DateTime.Now - start;
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

				lock (grdMain)
				{
					grdMain.DataSource = dtITVHistory;
					grdMain.RootTable.FilterCondition = null;
					grdMain.Focus();
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
				lock (grdMain)
				{
					sbrChild.Visible = sbbProgressCaption.Visible =
						sbbProgressMeter.Visible = !state;
					grdMain.Enabled = state;
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

		#region Other Methods

		private string AddQuotes(string sInput)
		{
			if (string.IsNullOrEmpty(sInput))
				return sInput;
			string[] sItems = sInput.Split(',');
			if (sItems.Length < 2)
			{
				return sInput;
			}
			string sOutput = "";
			int ix = 0;
			foreach (string sItem in sItems)
			{
				sOutput = sOutput + string.Format("'{0}',", sItem);
				ix++;
			}
			// Remove the last comma
			sOutput = sOutput.Substring(0, sOutput.Length - 1);
			return sOutput;
		}

		private void SetDefaults()
		{
			WindowHelper.ClearAllControls(this);
			cmbPOD.UncheckAll();
			cmbPLOD.UncheckAll();
			cmbMoveType.UncheckAll();
			cmbVessel.SelectedIndex = -1;
			txtPCFN.Text = "";
			dateRDDRange.Enabled = true;
			dateRDDRange.CheckBoxChecked = true;
			dateRDDRange.CheckBoxChecked = false;
			DateRange dr = new DateRange();
			dr.From = DateTime.Today.AddYears(-1);
			dr.To = DateTime.Today.AddMonths(6);
			dateRDDRange.ValueRange = dr;
			cmbVoyages.SortType = ComboSortType.Code;

			cmbVoyages.Filter = null;

		}
		#endregion

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
				//GridArea ga = grdResults.HitTest();
				//if (ga != GridArea.Cell) return;

				//EditAPInvoice();
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
				//if (e.KeyCode == Keys.Enter)
				//{
				//    GridEXRow gr = grdResults.GetRow();
				//    if (gr == null || gr.RowType != RowType.Record) return;

				//    EditAPInvoice();

				//    e.Handled = true;
				//}
				//else if (e.KeyCode == Keys.C && e.Control)
				//{
				//    GridEXRow r = grdResults.GetRow();
				//    GridEXColumn c = grdResults.CurrentColumn;
				//    if (r == null || c == null || string.IsNullOrEmpty(c.DataMember)) return;

				//    string s = ClsConvert.ToString(r.Cells[c].Text);
				//    if (!string.IsNullOrEmpty(s)) Clipboard.SetText(s);
				//}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void cnuGridEditMod_Click(object sender, EventArgs e)
		{
			//EditAPInvoice();
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
			SetDefaults();
		}
		#endregion		// #region Form Event Handlers

		private void cmbVessel_ValueChanged(object sender, EventArgs e)
		{
			if (cmbVessel.SelectedIndex > -1)
			{
				string sFilter = string.Format("vessel_cd = '{0}'", cmbVessel.SelectedVesselCD);
				cmbVoyages.Filter = sFilter;
			}
			else
			{
				cmbVoyages.Filter = null;
			}
		}

		private void grdMain_LinkClicked(object sender, ColumnActionEventArgs e)
		{
			ClsLinkHandler h = new ClsLinkHandler();
			GridEXRow grow = grdMain.CurrentRow;
			Program.LinkHandler.HandleLink(grow, e.Column.Key);
		}

	}
}