using System;
using System.Collections.Generic;
using System.Text;
using CS2010.Common;
using System.Data;
using System.Data.Common;

namespace ASL.ARC.EDISQLTools
{
	public static class clsClassSQL
	{
		#region Connections
		private static ClsConnection Connection
		{
			get
			{
				if (ClsConMgr.Manager["CLASS"] == null)
					return null;
				return ClsConMgr.Manager["CLASS"];
			}
		}
		#endregion

		#region Methods
		public static DataTable Get304s()
		{
			string sql = string.Format(@"
				select * from v_wwl_304 ");
			return Connection.GetDataTable(sql);
		}

		#endregion


	}
}
