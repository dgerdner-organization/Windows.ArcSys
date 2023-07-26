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
        public ClsVessel Vessel
        {
            get
            {
                ClsVessel v = ClsVessel.GetUsingKey(this.Vessel_Cd);
                return v;
            }
        }
        public static DataTable GetCurrentVoyages()
		{
			string sql = @"
					select distinct voyage_cd, vessel_cd 
						from v_voyage where sail_dt > sysdate - 700
						order by voyage_cd ";

				DataTable dt = Connection.GetDataTable(sql);
				return dt;
		}

        public static ClsVVoyage GetByVoyageNo(string sVoyageNo)
        {
            ClsVVoyage v = GetByVoyageNo(sVoyageNo, true);
            return v;
        }
        public static ClsVVoyage GetByVoyageNo(string sVoyageNo, bool bCheckVoyDoc)
        {
            // December 2021 
            // Added bCheckVoyDoc parameter.  By default it is true.  If calling
            // uses false, it will return the voyage even if there is no VoyDoc.
            // 
            string sql = string.Format(@"
				select * from v_voyage
				 where voyage_cd = '{0}'
				  and military_voyage_cd is not null ", sVoyageNo);
            if (!bCheckVoyDoc)
            {
                sql = string.Format(@"
				select * from v_voyage
				 where voyage_cd = '{0}'", sVoyageNo);
            }
            DataTable dt = Connection.GetDataTable(sql);
            ClsVVoyage v = null;
            if (dt.Rows.Count > 0)
                v = new ClsVVoyage(dt.Rows[0]);
            return v;
        }
        public string Direction
        {
            get
            {
                string sql = string.Format(@"SELECT f_voyage_dir('{0}') from dual", this.Voyage_Cd);

                var oResult = Connection.GetScalar(sql);
                return oResult.ToString();
            }
        }
    }
}
