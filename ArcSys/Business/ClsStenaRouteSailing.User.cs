using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsStenaRouteSailing
	{
		public static DataTable GetSailings(string sRoute, int iStart, int iEnd)
		{
			string sql = string.Format(@"
			select srs.*, vd.voyage_cd as arc_voyage_no, v.vessel_cd, sr.pol_location_cd, sr.pod_location_cd
				from r_stena_route_sailing srs
               inner join r_stena_route sr on sr.route_cd = srs.route_cd
				  left outer join v_voyage_route_detail_pod vd
				   on vd.location_cd = sr.pol_location_cd
				   and vd.pod = sr.pod_location_cd
				   and vd.departure_dt = srs.sailing_dt
				left outer join r_vessel v on v.vessel_nm = srs.vessel_nm
			 where srs.sailing_dt > sysdate + {1}
               and srs.sailing_dt < sysdate + {2}
			  and srs.route_cd like '{0}' ", sRoute, iStart, iEnd);
			DataTable dt = Connection.GetDataTable(sql);
			return dt;
		}

	}
}