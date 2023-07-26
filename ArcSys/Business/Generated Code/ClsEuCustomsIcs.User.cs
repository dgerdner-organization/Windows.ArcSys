using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsEuCustomsIcs : ClsBaseTable
	{
        #region Static Methods
        
        public static DataTable Search(clsEuCustomsIcsParms parms)
        {
            StringBuilder sb = new StringBuilder(string.Format("select * from T_EU_CUSTOMS_ICS where NVL(ACKNOWLEDGED_FLG,0) = @ACKNOWLEDGED_FLG  ",
                                       parms.AcknowledgedFlg));

            List<DbParameter> p = new List<DbParameter>();
            p.Add(Connection.GetParameter("@ACKNOWLEDGED_FLG", parms.AcknowledgedFlg));
            if (parms.WithDateRange)
            {
                sb.Append(" and File_DT between @DateFrom and @DateTo ");
                p.Add(Connection.GetParameter("@DateFrom", parms.DateFrom));
                p.Add(Connection.GetParameter("@DateTo", parms.DateTo));
            }
            if (!parms.Bol_No.IsNullOrWhiteSpace())
            {
                sb.Append(" and bol_no = @bol_no ");
                p.Add(Connection.GetParameter("@bol_no", parms.Bol_No));
            }
            sb.Append(" order by file_dt desc ");
            return Connection.GetDataTable(sb.ToString(), p.ToArray());
        }

        public static int GetUnacknowledgedCount()
        {
          return Int32.Parse((Connection.GetScalar("select count(*) from T_EU_CUSTOMS_ICS where NVL(ACKNOWLEDGED_FLG,0) = 0")).ToString());
        }

       
        #endregion Static Methods
    }

    public class clsEuCustomsIcsParms
    {
        public string Bol_No;
        public bool WithDateRange;
        public DateTime? DateFrom;
        public DateTime? DateTo;
        public string AcknowledgedFlg;
    }
  
}
