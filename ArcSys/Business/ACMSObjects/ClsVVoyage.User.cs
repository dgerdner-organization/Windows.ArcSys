using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ACMS.Business
{
	public partial class ClsVVoyage 
	{ 
		public ClsVessel Vessel
		{
			get
			{
				ClsVessel v = ClsVessel.GetUsingKey(this.Vessel_Cd);
				return v;
			}
		}
		public static DataTable GetVoyages(int days)
		{
			// Get voyages that have sailed within the last "days" number of days
			string sql = string.Format(@"
				select voyage_cd, sail_dt,  voyage_cd || '-' || vessel_cd as voyage_dsc
				from mv_voyage
				 where sail_dt > sysdate - {0} ", days);
			DataTable dt = Connection.GetDataTable(sql);
			return dt;
		}

		public static DataTable GetVoyagesImmediate(int days)
		{
			// Get voyages that have sailed within the last "days" number of days
			string sql = string.Format(@"
				select voyage_cd, sail_dt,  voyage_cd || '-' || vessel_cd as voyage_dsc
				from v_voyage_immediate
				 where sail_dt > sysdate - {0} ", days);
			DataTable dt = Connection.GetDataTable(sql);
			return dt;
		}
		public static ClsVVoyage GetByVoyageNo(string sVoyageNo)
		{
			string sql = string.Format(@"
				select * from t_voyage
				 where voyage_cd = '{0}'
				  and military_voyage_cd is not null ", sVoyageNo);
			DataTable dt = Connection.GetDataTable(sql);
			ClsVVoyage v = null;
			if (dt.Rows.Count > 0)
				v = new ClsVVoyage(dt.Rows[0]);
			return v;
		}
	}
}
