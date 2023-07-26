using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ACMS.Business
{
	public partial class ClsVNitelyPortBerthMismatch
	{
		public static DataTable GetAll(ClsConnection conn)
		{
			string sql = "select * from v_nitely_port_berth_mismatch";
			return conn.GetDataTable(sql);
		}
	}
}
