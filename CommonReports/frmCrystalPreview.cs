using System;
using System.Windows.Forms;
using CS2010.Common;
using CS2010.CommonWinCtrls;
using CrystalDecisions.CrystalReports.Engine;

namespace CS2010.CommonReports
{
	public partial class frmCrystalPreview : Form
	{
		#region Fields/Properties

		private ClsReportObject theReport;

		private ReportDocument theDocument
		{
			get { return MainViewer.ReportSource as ReportDocument; }
		}
		#endregion		// #region Fields/Properties

		#region Constructor/Initialization/Entry

		public frmCrystalPreview()
		{
			InitializeComponent();
		}

		public static frmCrystalPreview ShowReport(ClsReportObject aReport,
			ClsReportDocument CrystalDocument, bool applyFormula)
		{
			try
			{
				frmCrystalPreview f = new frmCrystalPreview();
				f.theReport = aReport;

				f.Text = aReport.Title;
				f.MainViewer.ReportSource = CrystalDocument;
				if( applyFormula )
					f.MainViewer.SelectionFormula = CrystalDocument.RecordSelectionFormula;

				f.Show();

				return f;
			}
			catch( Exception ex )
			{
				Display.ShowError("Report", ex, null, aReport.ToString());
				return null;
			}
		}

		public void LoadDocument(ReportDocument aDoc, string title, bool applyFormula)
		{
			try
			{
				Text = title;
				MainViewer.ReportSource = aDoc;
				if( applyFormula )
					MainViewer.SelectionFormula = aDoc.RecordSelectionFormula;
			}
			catch( Exception ex )
			{
				Display.ShowError("Reports", ex);
			}
		}

		private void frmReportViewer_Load(object sender, EventArgs e)
		{
			FormLoad();
		}

		private void FormLoad()
		{
			try
			{
				SetExpandCollapse();
			}
			catch( Exception ex )
			{
				Display.ShowError("Reports", ex, null, theReport.ToString());
			}
		}

		private void frmReportViewer_FormClosed(object sender, FormClosedEventArgs e)
		{
			try
			{
				ClsReportDocument report = MainViewer.ReportSource as ClsReportDocument;
				if( report == null ) return;

				MainViewer.ReportSource = null;
				report.Dispose();
				report = null;
			}
			catch( Exception ex )
			{
				Display.ShowError("Reports", ex, null, theReport.ToString());
			}
		}
		#endregion		// #region Constructors/Initialization/Entry

		#region Expanding/Collapsing

		private void SetExpandCollapse()
		{
			try
			{
				ReportDefinition rd = theDocument.ReportDefinition;

				// If there aren't any groups, then the "Collapse" button is not needed
				bool bGroupsExist = false;
				foreach( Section sec in rd.Sections )
				{
					if( sec.Kind == CrystalDecisions.Shared.AreaSectionKind.GroupFooter ||
						sec.Kind == CrystalDecisions.Shared.AreaSectionKind.GroupHeader )
					{
						if( !sec.SectionFormat.EnableSuppress )
							bGroupsExist = true;
					}
				}
				btnCollapse.Visible = bGroupsExist;

				if( bGroupsExist && theReport != null && theReport.IsCrystalCollapsed )
					ExpandCollapse();

				// If the report has defined the button invisible, hide it
				if( theReport != null && theReport.IsExpandCollapseVisible == false )
					btnCollapse.Visible = false;
			}
			catch( Exception ex )
			{
				Display.ShowError("Reports", ex, null, theReport.ToString());
			}
		}

		private void btnCollapse_Click(object sender, EventArgs e)
		{
			ExpandCollapse();
		}

		private void ExpandCollapse()
		{
			try
			{
				ReportDocument doc = theDocument;
				ReportDefinition rd = doc.ReportDefinition;
				foreach( Section sec in rd.Sections )
				{
					if( sec.Kind == CrystalDecisions.Shared.AreaSectionKind.Detail )
					{
						if( btnCollapse.Text == "Collapse" )
						{
							sec.SectionFormat.EnableSuppress = true;
						}
						else
						{
							sec.SectionFormat.EnableSuppress = false;
						}
					}
				}

				if( btnCollapse.Text == "Collapse" )
					btnCollapse.Text = "Expand";
				else
					btnCollapse.Text = "Collapse";

				MainViewer.ReportSource = doc;
			}
			catch( Exception ex )
			{
				Display.ShowError("Reports", ex, null, theReport.ToString());
			}
		}
		#endregion		// #region Expanding/Collapsing
	}
}