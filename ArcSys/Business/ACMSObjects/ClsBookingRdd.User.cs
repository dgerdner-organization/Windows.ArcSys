using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ACMS.Business
{
	public partial class ClsBookingRdd
	{
		public static DataTable GetForBooking(string sBookingNo)
		{
			string sql = string.Format(@"
				select * from t_booking_rdd
                     where booking_id = '{0}' ", sBookingNo);

			return Connection.GetDataTable(sql);
		}
	}
}
