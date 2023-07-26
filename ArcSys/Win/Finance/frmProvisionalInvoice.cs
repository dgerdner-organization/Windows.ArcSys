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
	public partial class frmProvisionalInvoice : frmChildBase
	{
		#region Fields/Properties
		public DataTable dtReport;
		#endregion		// #region Fields/Properties

		#region Constructors/Initialization/Entry/Cleanup

		public frmProvisionalInvoice()
		{
			InitializeComponent();
			this.Activate();
			this.MdiParent = Program.MainWindow;
			this.WindowState = FormWindowState.Maximized;

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
			cmbPOD.SelectedText = "";
			cmbPOL.SelectedText = "";
			cmbPLOD.SelectedText = "";
			cmbCargoStatus.Text = "All";
		}

		private void PerformSearch()
		{
			string sStatus = cmbCargoStatus.Text;
			string sPLOR = cmbPLOR.SelectedText;
			string sPOL = cmbPOL.SelectedText;
			string sPOD = cmbPOD.SelectedText;
			string sPLOD = cmbPLOD.SelectedText;

			dtReport = ClsQueries.GetProvisionalInvoicing
					(grpPOLDate.ValueRange, sStatus, txtVoyage.Text,
					txtPCFN.Text, sPLOR, 
					sPOL, sPOD, sPLOD);
			grdResults.DataSource = dtReport;
			if( dtReport.Rows.Count < 1 )
			{
				Program.Show("No cargo found.");
			}
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

	
	}
}

	