using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using CS2010.Common;
using CS2010.ArcSys.Business;


namespace CS2010.ArcSys.Business
{
    public partial class ClsTradingPartner : ClsBaseTable
    {
        public static DataTable GetUserPartners()
        {
            try
            {
                string sql = string.Format(@"
			select * from v_trading_partner ");
                return Connection.GetDataTable(sql);
            }
            catch (Exception ex)
            {
                ClsErrorHandler.LogException(ex);
                return null;
            }
        }
        public static DataTable GetUserPartnersWithAll()
        {
            string sql = string.Format(@"
      select trading_partner_cd, partner_dsc, outbound_isa_nbr, active_flg
        from v_trading_partner
        union all
         select '%', 'All', 0, 'Y' from dual
          order by 1");
            return Connection.GetDataTable(sql);
        }
        public static DataTable GetUserPartnersAll()
        {
            string sql = "select * from r_user_trading_partner ";
            return Connection.GetDataTable(sql);
        }

        public static DataTable GetAllActiveTradingPartners()
        {
            string sql = "select * from r_trading_partner where active_flg = 'Y' order by trading_partner_cd ";
            return Connection.GetDataTable(sql);
        }
    }
}
