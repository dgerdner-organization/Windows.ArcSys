using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
    public class ClsLineCharges
    {

        #region Connection Manager

        private static ClsConnection Connection
        {
            get { return ClsConMgr.Manager["ArcSys"]; }
        }

        #endregion		// #region Connection Manager

        public DataTable EstimatedLineCharges(string BookingNo)
        {

            string SQL = string.Format(@"
                Select 
                * 
                from v_line_charges 
                where booking_no = '{0}'", BookingNo);

            return Connection.GetDataTable(SQL);

        }
    }
}
