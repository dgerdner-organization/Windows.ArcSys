using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsTradingPartnerEdi
	{
		public static DataTable GetMapTypes(bool bIncludeAll)
		{
			string sql = string.Format(@"
			select distinct map_set from R_TRADING_PARTNER_EDI t
			 where map_set is not null and map_set <> 'na' ");

			if (bIncludeAll)
				sql = sql + " union all select '(All)' from dual ";

			sql = sql + " order by 1";
			DataTable dt = Connection.GetDataTable(sql);
			return dt;
		}

        public static List<ClsTradingPartnerEdi> GetAllList()
        {
            DataTable dt = ClsTradingPartnerEdi.GetAll();
            List<ClsTradingPartnerEdi> l = new List<ClsTradingPartnerEdi>();
            foreach (DataRow drow in dt.Rows)
            {
                ClsTradingPartnerEdi p = new ClsTradingPartnerEdi(drow);
                l.Add(p);
            }
            return l;
        }
	}
}
