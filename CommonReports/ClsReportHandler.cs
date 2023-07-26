using System;
using System.IO;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using System.Drawing.Printing;
using CS2010.Common;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;

namespace CS2010.CommonReports
{
	public class ClsReportHandler
	{
		#region Print Dialog

		private static PrintDialog dlgPrint;
		public static PrintDialog thePrintDialog
		{
			get
			{
				if (dlgPrint == null) PrintDialogCreate();

				return dlgPrint;
			}
		}

		public static void PrintDialogCreate()
		{
			PrintDialogReset();

			dlgPrint = new PrintDialog();
			dlgPrint.AllowCurrentPage = dlgPrint.AllowSelection =
				dlgPrint.ShowHelp = dlgPrint.ShowNetwork = dlgPrint.UseEXDialog = false;

			dlgPrint.AllowPrintToFile = true;
		}

		public static void PrintDialogReset()
		{
			if (dlgPrint != null)
			{
				dlgPrint.Dispose();
				dlgPrint = null;
			}
		}
		#endregion		// #region Print Dialog

		#region Constructors/Initialization/Cleanup

		static ClsReportHandler()
		{
			PrintDialogCreate();
		}

		public static void CrystalInitialization(DataTable dt)
		{
			using (ReportDocument rd = GetReport("CrystalInitialization.rpt"))
			{
				rd.SetDataSource(dt);

				using (frmCrystalPreview f = new frmCrystalPreview())
				{
					f.LoadDocument(rd, "Crystal Initialization", false);
				}
			}
		}
		#endregion		// #region Constructors/Initialization/Cleanup

		#region Get/Create Report

		public static ClsReportDocument GetReport(string repObjName)
		{
			Assembly asm = Assembly.GetExecutingAssembly();
			if (asm != null)
			{
				string path = Path.GetDirectoryName(asm.Location);
				string fileName = Path.Combine(path, repObjName);
				try
				{
					ClsReportDocument rd = new ClsReportDocument();
					rd.Load(fileName);

					return rd;
				}
				catch
				{
					ClsErrorHandler.LogError("Load Report Failed Path {0} Report {1}\r\nFile: {2}",
						path, repObjName, fileName);
					throw;
				}
			}
			return null;
		}

		private static ClsReportDocument CrystalDocument;

		public static ClsReportDocument CreateReport(ClsReportObject r)
		{
			CrystalDocument = GetReport(r.Crystal_File_Nm);
			CrystalDocument.SetDataSource(r.Report_Data);
			if (r.Parameters != null && r.Parameters.Count > 0)
			{
				foreach (string s in r.Parameters.Keys)
				{
					if (string.IsNullOrEmpty(s) || !s.StartsWith("P_")) continue;

					ParameterField pf = CrystalDocument.ParameterFields.Find(s, null);
					if (pf == null) continue;

					pf.CurrentValues.AddValue(r.Parameters[s]);
				}
			}

			// Sets Up Title and Company Information for each header
			ReportDefinition repdef = CrystalDocument.ReportDefinition;
			foreach (Section sec in repdef.Sections)
			{
				foreach (ReportObject obj in sec.ReportObjects)
				{
					CrystalDecisions.CrystalReports.Engine.TextObject tObj =
						obj as CrystalDecisions.CrystalReports.Engine.TextObject;
					CrystalDecisions.CrystalReports.Engine.FieldObject sObj =
						obj as FieldObject;
					if (tObj != null)
					{
						switch (obj.Name)
						{
							case "txtTitle":
								tObj.Text = r.Title;
								tObj.ObjectFormat.HorizontalAlignment = Alignment.HorizontalCenterAlign;
								tObj.Height = 500;
								tObj.ApplyFont(new Font("Times New Roman", 20, tObj.Font.Style));
								if (!r.IsTitleStatic)
								{
									tObj.Top = 50;
									tObj.Left = 500;
									tObj.Width = 10000;
								}
								break;
							case "txtCompany":
								tObj.Text = ClsConvert.ToProperCase(r.Company_Nm);
								tObj.ObjectFormat.HorizontalAlignment = Alignment.HorizontalCenterAlign;
								tObj.Height = 350;
								tObj.ApplyFont(new Font("Times New Roman", 14, tObj.Font.Style));
								if (!r.IsTitleStatic)
								{
									tObj.Top = 550;
									tObj.Left = 500;
									tObj.Width = 10000;
								}
								break;
							case "txtParams":
								tObj.Text = r.Parameters_Dsc;
								tObj.ObjectFormat.HorizontalAlignment = Alignment.HorizontalCenterAlign;
								tObj.ApplyFont(new Font("Times New Roman", 8, tObj.Font.Style));
								if (!r.IsTitleStatic)
								{
									tObj.Top = 900;
									tObj.Left = 500;
									tObj.Width = 10000;
								}
								break;
						}
					}
					if (sObj != null)
					{
						switch (obj.Name)
						{
							case "PageNofM1":
								sObj.ApplyFont(new Font("Times New Roman", 8, sObj.Font.Style));
								if (!r.IsTitleStatic)
								{
									sObj.ObjectFormat.HorizontalAlignment = Alignment.LeftAlign;
									sObj.Height = 350;
									sObj.Width = 1500;
									sObj.Left = 50;
									sObj.Top = 100;
								}
								break;
							case "PrintDate1":
								sObj.ApplyFont(new Font("Times New Roman", 8, sObj.Font.Style));
								if (!r.IsTitleStatic)
								{
									sObj.ObjectFormat.HorizontalAlignment = Alignment.RightAlign;
									sObj.Height = 350;
									sObj.Width = 1000;
									sObj.Left = 10000;
									sObj.Top = 100;
								}
								break;
						}
					}
				}
			}
			return CrystalDocument;
		}
		#endregion		// #region Get/Create Report

		#region Display Report

		public static bool LoadReportData(ClsReportObject r)
		{
			switch( r.ReportDisplayType )
			{
				case PushType.Grid:
					frmGridPreview f = new frmGridPreview();
					f.ShowData(r);
					break;

				case PushType.Crystal:
					PreviewReport(r);
					break;

				case PushType.Print:
					return PrintReport(r);

				case PushType.None:
				default:
					break;
			}

			return true;
		}

		public static ClsReportDocument PreviewReport(ClsReportObject r)
		{
			CreateReport(r);

			frmCrystalPreview.ShowReport(r, CrystalDocument, false);

			return CrystalDocument;
		}

		public static ClsReportDocument PresentReport(ClsReportObject r, bool preview)
		{
			if( preview )
				PreviewReport(r);
			else
				PrintReport(r);
			return CrystalDocument;
		}

		private static void ExpandCollapse(ClsReportObject r)
		{
			ReportDocument doc = CrystalDocument;
			ReportDefinition rd = doc.ReportDefinition;
			foreach( Section sec in rd.Sections )
			{
				if( sec.Kind == CrystalDecisions.Shared.AreaSectionKind.Detail )
					sec.SectionFormat.EnableSuppress = r.IsCrystalCollapsed;
			}
		}

		public static bool PrintReport(ClsReportObject r)
		{
			CreateReport(r);

			ExpandCollapse(r);

			try
			{
				PrintDialog dlg = thePrintDialog;

				dlg.Document = new PrintDocument();
				dlg.Document.DocumentName = r.Title;

				if (CrystalDocument != null)
				{
					int max = CrystalDocument.GetTotalPages();
					if (max > 1)
					{
						dlg.AllowSomePages = true;
						dlg.PrinterSettings.MinimumPage = 0;
						dlg.PrinterSettings.MaximumPage = max;
						dlg.PrinterSettings.FromPage = 1;
						dlg.PrinterSettings.ToPage = max;
					}
				}

				dlg.PrinterSettings.PrinterName =
					ClsEnvironment.GetLastPrinter(r.Title);

				dlg.PrinterSettings.DefaultPageSettings.Landscape =
					(CrystalDocument.PrintOptions.PaperOrientation == PaperOrientation.Landscape);

				if (dlg.ShowDialog() != DialogResult.OK) return false;

				CrystalDocument.PrintOptions.PrinterName = dlg.PrinterSettings.PrinterName;
				ClsEnvironment.UpdateLastPrinter(r.Title,
					dlg.PrinterSettings.PrinterName);

				PageSettings pgs = new PageSettings(dlg.PrinterSettings);
				pgs.Landscape = dlg.PrinterSettings.DefaultPageSettings.Landscape;

				CrystalDocument.PrintToPrinter(dlg.PrinterSettings, pgs, true);
			}
			finally
			{
				CrystalDocument.Dispose();
			}
			return true;
		}
		#endregion		// #region Display Report
	}
}