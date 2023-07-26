using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CS2010.Common;
using System.Data;

namespace CS2010.ArcSys.Business
{
    public partial class ClsOceanCargoActivity
    {
        #region Extended Attributes
        public string ArcStatusCode
        {
            get
            {
                return CargoStatusCodes.TranslateCode(this.Ocean_Status_Cd);
            }
        }
        #endregion

        #region static Methods
        public static Int64 GetLastActivityID()
        {
            string sql = "select max(ocean_activity_id) from t_ocean_cargo_activity ";
            string sResult = Connection.GetScalar(sql).ToString();
            if (string.IsNullOrEmpty(sResult))
                sResult = "0";
            Int64 iID = ClsConvert.ToInt64(sResult);
            return iID;
        }

        public static List<ClsOceanCargoActivity> GetUnprocessedCargoStatus()
        {
            List<ClsOceanCargoActivity> caList = new List<ClsOceanCargoActivity>();
            string sql = string.Format(@"
                select * from t_ocean_cargo_activity
                     where processed_warehouse_flg = 'N'
                       and ocean_status_cd <> 'BO'
                       and serial_no is not null 
                        order by ocean_activity_id");
            DataTable dt = Connection.GetDataTable(sql);
            foreach (DataRow drow in dt.Rows)
            {
                ClsOceanCargoActivity ca = new ClsOceanCargoActivity(drow);
                caList.Add(ca);
            }
            return caList;
        }
        #endregion
    }
}
