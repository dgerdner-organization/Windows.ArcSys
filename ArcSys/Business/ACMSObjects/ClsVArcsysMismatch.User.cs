using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ACMS.Business
{
	public partial class ClsVArcsysMismatch
	{
		public static DataTable GetAll(ClsConnection conn)
		{
			string sql = "select * from v_arcsys_mismatch ";
			return conn.GetDataTable(sql);
		}
	}
}
