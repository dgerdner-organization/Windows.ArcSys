using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
    public class ClsConfigurationTable
    {
        private static ClsConnection Connection
        {
            get
            {
                return ClsConMgr.Manager["ArcSys"];
            }
        }
        public static bool CheckConfig(string sPurpose, string sCode, ref string sMessage)
        {
            string sql = string.Format(@"
                select * from r_configuration
                  where purpose_cd = '{0}' 
                    and config_01 = '{1}' ", sPurpose, sCode);

            DataTable dt = Connection.GetDataTable(sql);
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            sMessage = string.Format("Config not found for {0} Code {1}", sPurpose, sCode);
            return false;
        }

    }
}
