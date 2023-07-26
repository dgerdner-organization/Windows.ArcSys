using System;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;
using CS2010.Common;
using CS2010.CommonReports;
using CS2010.CommonWinCtrls;
using ASL.ARC.EDISQLTools;
using Janus.Windows.GridEX;
using CrystalDecisions.Shared;
using CrystalDecisions.ReportSource;
using CrystalDecisions.CrystalReports.Engine;
using System.Reflection;
using CS2010.ArcSys.Win;
using CS2010.ACMS.Business;


namespace ASL.ARC.EDITools
{
	public partial class frmRDDDoorMoves : frmChildBase
	{
		#region Fields/Properties
		public DataTable dtReport;
		#endregion		// #region Fields/Properties

		#region Constructors/Initialization/Entry/Cleanup

		public frmRDDDoorMoves()
		{
			InitializeComponent();
			this.Activate();
			this.MdiParent = Program.MainWindow;
			this.WindowState = FormWindowState.Maximized;
		}


		#endregion		// #region Constructors/Initialization/Entry/Cleanup

		#region Methods
		protected void StartSearch()
		{
			dtReport = ClsArcSQL.GetRDDDoorOutReport(txtVoyage.Text, "", cbxIncludeStena.Checked);
			string repName = @"ACMS\rptRPTDoorOutilms.rpt";
			ClsReportDocument report = ClsReportHandler.GetReport(repName);
			crystalReportViewer1.ReportSource = report;
			report.SetDataSource(dtReport);
			//ReportDocument rd = (ReportDocument)crystalReportViewer1.ReportSource;
			//rd.SetDataSource(dtReport);
			//crystalReportViewer1.ReportSource = rd;
			//PrintReport();
		}


		#endregion

		#region Event Handlers
		private void tbbSearch_Click(object sender, EventArgs e)
		{
			StartSearch();
		}

		private void crystalReportViewer1_Load(object sender, EventArgs e)
		{
			StartSearch();
		}
		#endregion		// #region Event Handlers

		private void tbbClear_Click(object sender, EventArgs e)
		{
			//txtVessel.Text = "";
			txtVoyage.Text = "";
			cbxIncludeStena.Checked = false;
		}
	
	}
}

	