using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;
using CS2010.ArcSys.Business;

namespace CS2010.ArcSys.Business
{
	public partial class ClsVVoyage 
	{
		public static DataTable GetCurrentVoyages()
		{
			string sql = @"
					select distinct voyage_cd, vessel_cd 
						from v_voyage where sail_dt > sysdate - 700
						order by voyage_cd ";

				DataTable dt = Connection.GetDataTable(sql);
				return dt;
		}
	}
}
