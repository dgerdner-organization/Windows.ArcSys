using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CS2010.ArcSys.Business
{
	public partial class ClsItv
	{
		#region Properties
		private ClsBookingLine _Booking;
		public ClsBookingLine Booking
		{
			get
			{
				if (_Booking != null)
					return _Booking;
				_Booking = ClsBookingLine.GetByBookingNo(this.Booking_No);
				return _Booking;
			}
		}
		#endregion

		#region Public Methods
		public bool SetActualArriveFlg()
		{
			if (Booking == null)
				return false;
			string sFlg = "N";
			string sSQL = string.Format(@"select f_voyage_actual_flg('{0}', '{1}', '{2}', 'D') from dual",
				this.Voyage_No, this.Pod_Location_Cd, this.Booking.Pod_Berth);
			sFlg = Connection.GetScalar(sSQL).ToString();
			this.Actual_Arrival_Flg = sFlg;
			return true;
		}
		public bool SetActualDepartFlg()
		{
			if (Booking == null)
				return false;
			string sFlg = "N";
			string sSQL = string.Format(@"select f_voyage_actual_flg('{0}', '{1}', '{2}', 'L') from dual",
				this.Voyage_No, this.Pol_Location_Cd, this.Booking.Pol_Berth);
			sFlg = Connection.GetScalar(sSQL).ToString();
			this._Actual_Departure_Flg = sFlg;
			return true;
		}
		public bool SetArriveDt()
		{
			if (Booking == null)
				return false;
			string sql = string.Format(@"select f_voyage_dt('{0}', '{1}', '{2}', 'D') from dual",
				this.Voyage_No, this.Pod_Location_Cd, this.Booking.Pod_Berth);
			object oDate = Connection.GetScalar(sql);
			if (oDate == null)
				return false;
			DateTime? dDate = Convert.ToDateTime(oDate);
			if (!dDate.HasValue)
				return false;
			this.Arrival_Dt = dDate;
			return true;
		}
		public bool SetDepartDt()
		{
			if (Booking == null)
				return false;
			string sql = string.Format(@"select f_voyage_dt('{0}', '{1}', '{2}', 'L') from dual",
				this.Voyage_No, this.Pol_Location_Cd, this.Booking.Pol_Berth);
			object oDate = Connection.GetScalar(sql);
			if (oDate == null)
				return false;
			DateTime? dDate = Convert.ToDateTime(oDate);
			if (!dDate.HasValue)
				return false;

			this.Departure_Dt = dDate;
			return true;
		}

		#endregion

		#region Private Methods
		#endregion

		#region Public Static Methods

		#endregion
	}
}
