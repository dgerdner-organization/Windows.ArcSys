using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsBookingLine
	{
//        public static ClsBookingLine GetByBookingNo(string sBookingNo)
//        {
//            string sql = string.Format(@"
//				select * from t_booking_line
//					where booking_no = '{0}' ", sBookingNo);
//            DataTable dt = Connection.GetDataTable(sql);
//            if (dt.Rows.Count < 1)
//                return null;
//            ClsBookingLine b = new ClsBookingLine(dt.Rows[0]);
//            return b;
//        }

		private DataRow _drLINEBooking;
		public DataRow drLINEBooking
		{
			get
			{
				if (_drLINEBooking == null)
				{
					DataTable dt = ClsLineSQL.GetByBookingNo(this.Booking_No);
					if (dt.Rows.Count > 0)
						_drLINEBooking = dt.Rows[0];
				}
				return _drLINEBooking;
			}
		}

		public void UpdateSPSLog()
		{
			// This will add a row to the SPS Log for this booking; but only if it does not already exist
			string sManr = this.drLINEBooking["bu1bumanr"].ToString();
			string sService = this.drLINEBooking["bu1service"].ToString();
			string sVoyManr = this.drLINEBooking["bu1rmanr"].ToString();

			// Skip if there's already an unprocessed row for this booking
			DataTable dt = ClsLineSQL.FindSPSLog(sManr, sVoyManr);
			if (dt.Rows.Count > 0)
				return;

			ClsLineSQL.UpdateSPSLog(sManr, sVoyManr, sService);

		}
	}
}
