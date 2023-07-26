using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
    public partial class ClsEdi304
    {
        public static ClsEdi304 GetByBOL(string BOL)
        {
            string sql = "Select * from t_Edi304 usc where usc.Bol_No = @BOL order by edi304_id desc";

            List<DbParameter> p = new List<DbParameter>();
            p.Add(Connection.GetParameter("@BOL", BOL));
            DataRow dr = Connection.GetDataRow(sql, p.ToArray());
            return (dr.IsNull()) ? null : new ClsEdi304(dr);
        }

        public static ClsEdi304 GetByBOLandRegionCode(string BOL, string region_code)
        {
            string sql = "Select * from t_Edi304 usc where usc.Bol_No = @BOL and usc.MAP_NM = @map_nm order by edi304_id desc";
            List<DbParameter> p = new List<DbParameter>();
            p.Add(Connection.GetParameter("@BOL", BOL));
            p.Add(Connection.GetParameter("@map_nm", region_code));
            DataRow dr = Connection.GetDataRow(sql, p.ToArray());
            return (dr.IsNull()) ? null : new ClsEdi304(dr);
        }

        public static DataTable GetByRegionCode(string region_code)
        {
            string sql = "Select * from t_Edi304 usc where usc.map_nm = @map_nm order by edi304_id desc";
            List<DbParameter> p = new List<DbParameter>();
            p.Add(Connection.GetParameter("@map_nm", region_code));
            return Connection.GetDataTable(sql, p.ToArray());
        }
        public static DataTable GetByRegionCodeVoyage(string region_code, string voyage)
        {
            string sql = "Select * from t_Edi304 usc where usc.map_nm = @map_nm  and usc.voyage = @voyage order by edi304_id desc";
            List<DbParameter> p = new List<DbParameter>();
            p.Add(Connection.GetParameter("@map_nm", region_code));
            p.Add(Connection.GetParameter("@voyage", voyage));
            return Connection.GetDataTable(sql, p.ToArray());
        }
        public static List<ClsEdi304> GetUnProcessed(string mapNm)
        {
            List<ClsEdi304> list = new List<ClsEdi304>();
            string sql = string.Format("select * from T_EDI304 where processed_flg='N' and Map_nm='{0}'", mapNm);
            DataTable dt = Connection.GetDataTable(sql);
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new ClsEdi304(row));
            }
            return list;
        }

        public int UpdateFlg()
        {
            string sql = string.Format("update T_EDI304 set processed_flg='{0}', isa_id = {1}, isa_nbr={2}, Msg= '{3}' where edi304_id = {4}",
                               Processed_Flg, Isa_ID, Isa_Nbr, Msg, Edi304_ID);
            return Connection.RunSQL(sql);
        }
    }
}
