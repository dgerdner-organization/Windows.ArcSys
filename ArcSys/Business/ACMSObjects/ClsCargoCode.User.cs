using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ACMS.Business
{
	public partial class ClsCargoCode 
	{
		public static DataTable GetAllActive()
		{
			string sql = string.Format(@"
				select * from r_cargo_code where delete_flg = 'N' ");
			return Connection.GetDataTable(sql);
		}
	}
}
