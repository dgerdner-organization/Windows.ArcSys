using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsEdiInboundDetail
	{
		public static DataTable GetUnprocessed(ClsConnection conn, bool bAll, int iDays, string sBookingNo, string sVIN, string sSystem)
		{
			// DGERDNER July 2019
			// Filter by trading partner
			// Note this one is hardcoded to connect to LINE, so it really can't be used for OCEAN
			//
            // DGERDNER September 2020
            //  Removed the join to LINE.
//            string sql = string.Format(@"select d.*, c.*, f_ocean_system(d.booking_no) as ocean_system
//						from t_edi_inbound_detail d
//							 left outer join dba.car_head<DBLINK>SQL01 c
//							  on ""cr1_bunr"" = booking_no and cr1_vin = vin
//						where modify_dt > sysdate - {0} ", iDays);
            string sql = string.Format(@"select d.*, f_ocean_system(d.booking_no) as ocean_system
						from t_edi_inbound_detail d
						where modify_dt > sysdate - {0} ", iDays);
            if (!bAll)
                sql = sql + " and processed_flg = 'N' ";
            sql = sql + " and f_ocean_system(d.booking_no) like '" + sSystem + "' ";
            if (!string.IsNullOrEmpty(sBookingNo))
                sql = sql + string.Format(" and booking_no like '{0}' ", sBookingNo);
            if (!string.IsNullOrEmpty(sVIN))
                sql = sql + string.Format(" and vin like '{0}' ", sVIN);
                                     
                         
            return conn.GetDataTable(sql);


		}
		public static DataTable GetUnprocessed(bool bAll, int iDays, string sBookingNo, string sVin, string sSystem)
		{
			return GetUnprocessed(Connection, bAll, iDays, sBookingNo, sVin, sSystem);
		}

        public static DataTable GetAllUnprocessed(int iDays)
        {
            // April 2020.  Added this because other ones only refer to LINE bookings.  Currenly
            // use this in the Dashboard, but might need it in other places later.
            string sql = string.Format(@"select * from t_edi_inbound_detail d
                                    where modify_dt > sysdate - {0} and processed_flg = 'N' ",
                                       iDays);
            DataTable dt = Connection.GetDataTable(sql);
            return dt;
        }
        public static DataTable GetAllDashboard(int iDays)
        {
            // August 2021
            // This will look for Unprocessed IAL Cargo Detail data that is more than a couple hours old, for 
            // display on the dashboard.  This is in response to an issue where brand new IAL Cargo
            // detail is showing on the Dashboard because it has not yet processed.
            // Note: it the dashboar window, it now calls this instead of GetAllUnprocessed()
            string sql = string.Format(@"select * from t_edi_inbound_detail d
                                    where modify_dt > sysdate - {0} 
                                       and create_dt > sysdate - .1
                                      and processed_flg = 'N' ",
                                       iDays);
            DataTable dt = Connection.GetDataTable(sql);
            return dt;
        }
		public static ClsEdiInboundDetail GetByBookingVin(string sBookingNo, string sVIN)
		{
			string sql = string.Format
				(@"select * from t_edi_inbound_detail 
					where booking_no = '{0}'  and vin = '{1}' ", sBookingNo, sVIN);

			DataRow drow = Connection.GetDataRow(sql);
			if (drow == null)
				return null;
			ClsEdiInboundDetail dtl = new ClsEdiInboundDetail(drow);
			return dtl;
		}

		public bool DeleteCargo()
		{
			// Find the VIN in LINE to see if it's received
			string sStatus = ClsLineSQL.GetBookingStatus(this.Booking_No, this.Vin);
			if (string.IsNullOrEmpty(sStatus))
				sStatus = "";
			if (sStatus.ToUpper().StartsWith("EX"))
			{
				// If it's already received, we can't delete it
				return false;
			}

			// Removes cargo from the edi inbout tables
			string sql = string.Format
				(@"delete from t_edi_inbound_detail
				where booking_no = '{0}'  and vin = '{1}' ", this.Booking_No, this.Vin);
			Connection.RunSQL(sql);

			sql = string.Format
				(@"delete from t_edi_inbound_si
				where booking_no = '{0}'  and vin = '{1}' ", this.Booking_No, this.Vin);
			Connection.RunSQL(sql);

			// Find the VIN in LINE to see if it's received
			//DataRow roro = ClsLineSQL.GetAvailableRoro(this.Booking_No, this.Vin, this.Vehicle_Type_Cd);
			//ClsLineSQL.UpdateRoro(roro, "");

			return true;
		}

		public static bool UpdateTOPS()
		{
			// This will look for bookings that have had new detail sent in the last 24 hours,
			// and force a 300 to be sent to TOPS.  This will ensure that TOPS will receive all
			// new VINS.
			// DGERDNER JUNE 2015: Not needed; these are automatically being sent when I update
			// the VIN in LINE.
			return true;
		}
	}
}
