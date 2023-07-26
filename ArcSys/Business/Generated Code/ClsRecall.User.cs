using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsRecall : ClsBaseTable
	{
		public static bool CheckRecall(short iYear, string sMake, string sModel)
		{
			string sql = string.Format(@"
				select *
				 from r_recall
				  where vehicle_year = {0}
				   and vehicle_make = '{1}'
				   and vehicle_model = '{2}'
				   and active_flg = 'Y' ", iYear, sMake, sModel);

			DataTable dt = Connection.GetDataTable(sql);
			if (dt.Rows.Count > 0)
				return true;
			return false;
		}
	}
}
