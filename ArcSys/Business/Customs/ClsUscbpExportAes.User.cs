using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
    public partial class ClsUscbpExportAes
    {

        private static ClsUscbpExportAes GetByBOL(string BOL)
        {
            string sql = "Select * from t_uscbp_export_aes usc where usc.Bol_No = @BOL";

            List<DbParameter> p = new List<DbParameter>();
            p.Add(  Connection.GetParameter("@BOL", BOL));
            DataRow dr = Connection.GetDataRow(sql, p.ToArray());
            return (dr.IsNull()) ? null : new ClsUscbpExportAes(dr);
        }

        public static ClsUscbpExportAes GetByBOLandRegionCode(string BOL, string region_code)
        {
            string sql = "Select * from t_uscbp_export_aes usc where usc.Bol_No = @BOL and usc.REGION_CD = @region_code";
            List<DbParameter> p = new List<DbParameter>();
            p.Add(Connection.GetParameter("@BOL", BOL));
            p.Add(Connection.GetParameter("@REGION_CD", region_code));
            DataRow dr = Connection.GetDataRow(sql, p.ToArray());
            return (dr.IsNull()) ? null : new ClsUscbpExportAes(dr);
        }

        public static DataTable GetByRegionCode(string region_code)
        {
            string sql = "Select * from t_uscbp_export_aes usc where usc.region_cd = @region_code";
            List<DbParameter> p = new List<DbParameter>();
            p.Add(Connection.GetParameter("@region_code", region_code));
            return Connection.GetDataTable(sql, p.ToArray());
        }
    }
}
