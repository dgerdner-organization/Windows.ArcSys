using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;
using CS2010.ArcSys.Business;

namespace CS2010.ArcSys.Business
{
	public partial class ClsVBookingCargoLine
    {
        #region Extended Attributes
        private string _OceanSystem;
        public string OceanSystem
        {
            get
            {
                if (_OceanSystem != null)
                    return _OceanSystem;

                string s = string.Format("select f_ocean_system('{0}') from dual", this.Booking_No);
                _OceanSystem = Connection.GetScalar(s).ToString();
                return _OceanSystem;
            }
        }
       

        #endregion

        public static ClsVBookingCargoLine GetByBookingSerialNo(string sBooking, string sSerialNo)
		{
			string sql = string.Format(@"
				select * from v_booking_cargo_line where booking_no like '{0}' and serial_no like '{1}' ", sBooking, sSerialNo);

			DataTable dt = Connection.GetDataTable(sql);
			if (dt.Rows.Count < 1)
				return null;
			ClsVBookingCargoLine c = new ClsVBookingCargoLine(dt.Rows[0]);
			return c;
		}
		public static DataTable GetByBooking(string sBooking)
		{
			string sql = string.Format(@"
				select cl.*, 
                    serial_no as vin, 
                    0 as diff_status
                from v_booking_cargo_line cl where booking_no like '{0}' ", sBooking);

			DataTable dt = Connection.GetDataTable(sql);
			if (dt.Rows.Count < 1)
				return null;
			return dt;
		}
        public static DataTable GetByBookingView(string sBooking)
        {
            // This retrieves cargo with columns matching the old LINE system
            // It can be used to replace former direct queries to car_head for
            // when we transfer to the new OCEAN system
            string sql = string.Format(@"
				select cl.*, 
                    serial_no as vin, 
                    0 as diff_status,
                    cargo_status as cr1_ecstatus
                from v_booking_cargo_line cl where booking_no like '{0}' ", sBooking);

            DataTable dt = Connection.GetDataTable(sql);
            if (dt.Rows.Count < 1)
                return null;
            return dt;
        }
	}
}
