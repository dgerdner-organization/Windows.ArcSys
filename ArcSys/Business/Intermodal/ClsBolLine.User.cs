using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CS2010.ArcSys.Business
{
	public partial class ClsBolLine
	{

		#region Public Methods
		public bool IsEqual(ClsBolLine compare)
		{
			if (
				this.Bol_ID != compare.Bol_ID ||
				this.Bol_No != compare.Bol_No ||
				this.Deleted_Flg != compare.Deleted_Flg ||
				this.Booking_No != compare.Booking_No ||
				this.Vessel_No != compare.Vessel_No ||
				this.Voyage_No != compare.Voyage_No ||
				this.Bol_Status != compare.Bol_Status ||
				this.Final_Manifest_Flg != compare.Final_Manifest_Flg ||
				this.Service_Cd != compare.Service_Cd ||
				this.Booking_Line_ID != compare.Booking_Line_ID
				)
				return false;
			return true;

		}
		#endregion

		#region Private Methods
		#endregion

		#region Public Static Methods
		#endregion
	}
}

