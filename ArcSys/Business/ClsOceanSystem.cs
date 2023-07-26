using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
    public class ClsOceanSystem
    {
        #region Connection Manager

        protected static ClsConnection Connection
        {
            get { return ClsConMgr.Manager["ArcSys"]; }
        }
        #endregion		// #region Connection Manager

        public static string OceanSystem(string sBookingNo)
        {
            string sql = string.Format("select f_ocean_system('{0}') from dual",sBookingNo);
            string sSystem = Connection.GetScalar(sql).ToString();
            return sSystem;
        }

    }
}
