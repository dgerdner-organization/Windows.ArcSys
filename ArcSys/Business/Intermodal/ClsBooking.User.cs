using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsBooking
	{
		#region Fields/Properties

		public string Customer_Match_Cd { get { return Customer_Cd + " - " + Match_Cd; } }

		public string Voyage_Vessel
		{
			get
			{
				string vesNm = (Vessel != null) ? Vessel.Vessel_Nm : "<Vessel Not Found>";
				return string.Format("{0} - {1}", Voyage_No, vesNm);
			}
		}

		public string Voyage_Sail_Vessel
		{
			get
			{
				string vesNm = (Vessel != null) ? Vessel.Vessel_Nm : "<Vessel Not Found>";
				return string.Format("{0} - {1} - {2}", Voyage_No, ClsConfig.FormatDate(Sail_Dt),
					vesNm);
			}
		}
		#endregion		// #region Fields/Properties

		#region Public Static Methods

		public static ClsBooking FindByBookingNo(string bookingNo)
		{
			string SQL = string.Format("SELECT * FROM t_booking b WHERE b.booking_no = '{0}'", bookingNo.Trim());

			DataRow dr = Connection.GetDataRow(SQL);

			if (dr == null) return null;

			return new ClsBooking(dr);

		}

        public static bool FixBrokenIntermodalData(ref string sError)
        {
            Connection.TransactionBegin();
            try
            {
                string sql = @"update t_cargo_move
                     set cargo_activity_id = 
                      (select max(cargo_activity_id) from 
                              t_cargo_activity inner join t_cargo on t_cargo.cargo_id = t_cargo_activity.cargo_id
                       where t_cargo.serial_no = t_cargo_move.serial_no)
                    where create_dt > sysdate - 120
                      and cargo_activity_id not in
                      (select cargo_activity_id from t_cargo_activity)
                            ";
                Connection.RunSQL(sql);
                Connection.TransactionCommit();
                return true;
            }
            catch (Exception ex)
            {
                sError = ex.Message;
                Connection.TransactionRollback();
                return false;
            }
        }
		#endregion
	}
}