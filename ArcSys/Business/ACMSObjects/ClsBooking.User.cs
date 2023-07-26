using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ACMS.Business
{
	public partial class ClsBooking : ClsBaseTable
	{
		public ClsBookingRequest BookingRequest
		{
			get
			{
				string sql = string.Format(@"
					select * from t_booking_request 
                         where partner_cd = '{0}'
                          and partner_request_cd = '{1}'
                          and acms_status_cd in ('B','C') ",

					this.Partner_Cd, this.Partner_Request_Cd);

				DataTable dt = Connection.GetDataTable(sql);
				if (dt.Rows.Count < 1)
					return null;
				ClsBookingRequest bk = new ClsBookingRequest(dt.Rows[0]);
				return bk;
			}
		}

		private DataTable _RDDLog;
		public DataTable RDDLog
		{
			get
			{
				if (_RDDLog != null)
					return _RDDLog;
				_RDDLog = ClsBookingRdd.GetForBooking(this.Booking_ID);
				return _RDDLog;
			}
			set
			{
				_RDDLog = value;
			}
		}
		public bool HazardousGoods
		{
			get
			{
				bool bHzd = false;
				if (BookingRequest == null)
					return false;

				if (!string.IsNullOrEmpty(BookingRequest.Hazmat_Cd))
					bHzd = true;
				return bHzd;
			}
		}

		public override bool ValidateUpdate()
		{
			_Errors.Clear();
			if (this.Adj_Rdd_Dt != this.Rdd_Dt &&
				string.IsNullOrEmpty(this.Adj_Rdd_Reason))
			{
				_Errors.Add("RDD", "You must enter a reason for adjusting the RDD");
				return false;
			}
			return true;
		}
		public void UpdateBookingData(ClsBookingUnit b)
		{
			// When user updates key booking fields on a piece of carg, go
			// back and update the booking itself.
			_Errors.Clear();
			try
			{
				// Copies the booking-level data from one piece of cargo to this one
				this.Voyage_No = b.Voyage_No;
				this.Vessel_Cd = b.Vessel_Cd;
				this.Location_Poe_Cd = b.Poe_Location_Cd;
				this.Poe_Terminal_Cd = b.Poe_Terminal_Cd;
				this.Location_Pod_Cd = b.Pod_Location_Cd;
				this.Pod_Terminal_Cd = b.Pod_Terminal_Cd;
				this.Update();
			}
			catch (Exception ex)
			{
				ClsErrorHandler.LogException(ex);
				_Errors.Add("Save", ex.Message);
			}
		}
	}
}
