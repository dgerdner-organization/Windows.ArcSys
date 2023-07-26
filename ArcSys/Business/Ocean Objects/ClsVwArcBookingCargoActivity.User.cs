using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
    public partial class ClsVwArcBookingCargoActivity
    {
        #region Extended Attributes
        public string ArcStatusCode
        {
            get
            {
                string a = CargoStatusCodes.TranslateCode(this.Status_Code);
                return a;
            }
        }
        #endregion

        #region Static Methods
        public static List<ClsVwArcBookingCargoActivity> GetNewActivity()
        {
            List<ClsVwArcBookingCargoActivity> aList = new List<ClsVwArcBookingCargoActivity>();

            // Find the last ID that has been logged
            Int64 iLastID = ClsOceanCargoActivity.GetLastActivityID();

            // Get all activity that came after the last one
            string sql = string.Format(@"
                select * from vw_arc_booking_cargo_activity where id > {0} order by id 
                ", iLastID);
            DataTable dt = Connection.GetDataTable(sql);
            foreach (DataRow drow in dt.Rows)
            {
                ClsVwArcBookingCargoActivity a = new ClsVwArcBookingCargoActivity(drow);
                aList.Add(a);
            }
            return aList;
        }
        #endregion
    }
}
