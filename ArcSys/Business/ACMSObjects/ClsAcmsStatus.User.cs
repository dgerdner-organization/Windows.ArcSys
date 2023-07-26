using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ACMS.Business
{
	partial class ClsAcmsStatus
	{
		public struct StatusCodes
		{
			public const string Booked = "B";
			public const string PendingBooking = "PB";
			public const string PendingCorrections = "P";
			public const string Canceled = "X";
			public const string Ammended = "A";
			public const string BookedCounter = "C";
			public const string Declined = "D";
			public const string PendingBookingCounter = "PC";
			public const string Received = "R";
			public const string WaitListed = "W";
			public const string WaitListedCounter = "WC";
		}


	}
}
