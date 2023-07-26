using System;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;

namespace CS2010.CommonReports
{
	public class ClsReportDocument : ReportDocument
	{
		public int GetTotalPages()
		{
			ReportPageRequestContext ctx = new ReportPageRequestContext();
			return FormatEngine.GetLastPageNumber(ctx);
		}
	}
}