using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CS2010.Common;
using System.Configuration;
using System.Data;

namespace CS2010.ArcSys.Business
{
    public class conTranshipmentReport
    {

        public bool TestSAGAEDIConnection()
        {
            if (ClsConMgr.Manager["SAGAEDI"] == null)
            {
                ConnectionStringSettings cns = ConfigurationManager.ConnectionStrings["SAGAEDI"];

                ClsConMgr.Manager.AddConnection(
                    "SAGAEDI",
                    cns.ProviderName,
                    cns.ConnectionString,
                    "avss",
                    "friday13th",
                    null);
            }

            ClsConnection cn = ClsConMgr.Manager["SAGAEDI"];
            string sql = "Select SYSDATE from DUAL";
            if (cn.GetScalar(sql) == null) return false;

            return true;
        }

    }
}
