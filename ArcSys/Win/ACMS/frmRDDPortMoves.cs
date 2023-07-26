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
using CS2010.ArcSys.Win;
using CS2010.ACMS.Business;
using CS2010.CommonReports;
namespace ASL.ARC.EDITools
{
	public partial class frmRDDPortMoves : frmChildBase
	{
		#region Fields/Properties

		public DataTable dtReport;


		private ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ACMS"]; }
		}
		#endregion		// #region Fields/Properties

		#region Constructors/Initialization/Entry/Cleanup

		public frmRDDPortMoves()
		{
			InitializeComponent();
			this.Activate();
			this.MdiParent = Program.MainWindow;
			this.WindowState = FormWindowState.Maximized;
		}

		#endregion		// #region Constructors/Initialization/Entry/Cleanup

		#region Methods

		private void tbbSearch_Click(object sender, EventArgs e)
		{
			StartSearch();
		}


		private void StartSearch()
		{
			try
			{
				dtReport = ClsArcSQL.GetRDDPortOutReport(txtVoyage.Text, "", cbxIncludeStena.Checked);
				string repName = @"ACMS\rptRDDPortMoves.rpt";
				ClsReportDocument report = ClsReportHandler.GetReport(repName);
				crystalReportViewer1.ReportSource = report;
				report.SetDataSource(dtReport);

				//dtReport = ClsArcSQL.GetRDDPortOutReport(txtVoyage.Text, "", cbxIncludeStena.Checked);
				//ReportDocument rd = (ReportDocument)crystalReportViewer1.ReportSource;
				//rd.SetDataSource(dtReport);
				//crystalReportViewer1.ReportSource = rd;
			}
			catch( Exception ex )
			{
				Program.ShowError(ex);
			}
		}


		#endregion		// #region Search Methods


		#region Event Handlers

		private void tbbClear_Click(object sender, EventArgs e)
		{
		}

		#endregion		// #region Event Handlers

		private void crystalReportViewer1_Load(object sender, EventArgs e)
		{
			// Initial retrieve 
			//dtReport = ClsArcSQL.GetRDDPortOutReport();
			//ReportDocument rd = (ReportDocument)crystalReportViewer1.ReportSource;
			//rd.SetDataSource(dtReport);
			//crystalReportViewer1.ReportSource = rd;
			StartSearch();
		}
	}
	}

	