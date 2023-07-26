using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CS2010.ArcSys.Business;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	partial class ClsStenaRouteSailing
	{
		private ClsStenaRouteSailing _PriorSailing;
		public ClsStenaRouteSailing PriorSailing
		{
			get
			{
				if (_PriorSailing != null)
					return _PriorSailing;
				_PriorSailing = GetPriorSailing();
				return _PriorSailing;
			}
			set
			{
				_PriorSailing = value;
			}
		}
		private ClsStenaRouteSailing _NextSailing;
		public ClsStenaRouteSailing NextSailing
		{
			get
			{
				if (_NextSailing == null)
					_NextSailing = GetNextSailing();
				return _NextSailing;
			}
			set { _NextSailing = value; }
		}

		public static DataTable GetStenaSailings(string sRoute)
		{
			return GetStenaSailings(sRoute, 1, 4);
		}
		public static DataTable GetStenaSailings(string sRoute, int iFrom, int iTo)
		{
			try
			{
				string sql = string.Format(@"
					select s.stena_route_sailing_id,
					  s.route_cd, s.sailing_dt,
					  s.vessel_nm,
					  sr.route_description,
					  sr.pol_location_cd, sr.pod_location_cd
					   from r_stena_route_sailing  s
					 inner join r_stena_route sr on sr.route_cd = s.route_cd
					 where s.route_cd = '{0}'
					  and sailing_dt between sysdate - {1} and sysdate + {2} 
					  order by sailing_dt",
					sRoute, iFrom, iTo);
				DataTable dt = Connection.GetDataTable(sql);
				return dt;
			}
			catch (Exception ex)
			{
				ClsErrorHandler.LogException(ex);
				return null;
			}
		}

		public ClsStenaRouteSailing GetPriorSailing()
		{
			//string sql = string.Format(@"
//				select *
//				 from r_stena_route_sailing
//				  where route_cd = '{1}'
//				   and vessel_nm like '{2}'
//				   and sailing_dt =
//				   (
//				select max(sailing_dt)
//				 from r_stena_route_sailing
//				 where route_cd = '{1}'
//				  and vessel_nm like '{2}'
//				   and sailing_dt < (select sailing_dt from r_stena_route_sailing where stena_route_sailing_id = {0}))",
//                    this.Stena_Route_Sailing_ID, this.Route_Cd, this.Vessel_Nm);
			string sql = string.Format(@"
				select *
				 from r_stena_route_sailing
				  where vessel_nm like '{1}'
				   and sailing_dt =
				   (
				select max(sailing_dt)
				 from r_stena_route_sailing
				 where vessel_nm like '{1}'
				   and sailing_dt < (select sailing_dt from r_stena_route_sailing where stena_route_sailing_id = {0}))",
					this.Stena_Route_Sailing_ID,  this.Vessel_Nm);

			DataRow drow = Connection.GetDataRow(sql);
			ClsStenaRouteSailing s = new ClsStenaRouteSailing(drow);
			return s;
		}
		public ClsStenaRouteSailing GetNextSailing()
		{
			string sql = string.Format(@"
				select *
				 from r_stena_route_sailing
				  where route_cd like '{1}'
				   and vessel_nm like '{2}'
				   and sailing_dt =
				   (
				select min(sailing_dt)
				 from r_stena_route_sailing
				 where route_cd like  '{1}'
				  and vessel_nm like '{2}'
				   and sailing_dt > (select sailing_dt from r_stena_route_sailing where stena_route_sailing_id = {0}))",
					this.Stena_Route_Sailing_ID, "%", this.Vessel_Nm);

			DataRow drow = Connection.GetDataRow(sql);
			ClsStenaRouteSailing s = new ClsStenaRouteSailing(drow);
			return s;
		}

	}
}
