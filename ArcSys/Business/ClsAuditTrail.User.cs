using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
    public class ClsAuditTrail
    {
        protected static ClsConnection Connection
        {
            get { return ClsConMgr.Manager["ArcSys"]; }
        }

        public static DataTable GetForTable(string sTable)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(@"
                select * from a_audit_trail
                  where table_nm like '{0}' ", sTable);
            DataTable dt = Connection.GetDataTable(sb.ToString());
            return dt;
        }
    }
}
