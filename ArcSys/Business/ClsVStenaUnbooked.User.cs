using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsVStenaUnbooked
	{
		public static DataTable GetAll(ClsConnection conn)
		{
			string sql = string.Format(@"
				select * from v_stena_unbooked ");
			DataTable dt = conn.GetDataTable (sql);
			return dt;
		}
	}
}
