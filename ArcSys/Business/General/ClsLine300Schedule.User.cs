using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;
using CS2010.ArcSys.Business;

namespace CS2010.ArcSys.Business
{
	public partial class ClsLine300Schedule : ClsBaseTable
	{
		public static List<ClsLine300Schedule> GetUnprocessed()
		{
			string sql = "select * from T_LINE_300_SCHEDULE  where status_flg = 'N' ";
			return Connection.GetList<ClsLine300Schedule>(sql);
		}
	}
}
