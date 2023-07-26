using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ACMS.Business
{
	public partial class ClsBookingRequestError
	{
		public static DataTable GetByISA(long? sCtlNo, long? sSeqNo)
		{
			string sql = string.Format(@"
				select * from t_booking_request_error
					where trans_ctl_no = {0}
					  and trans_seq_no = {1}
				   order by trans_seq_no ", sCtlNo, sSeqNo);
			return Connection.GetDataTable(sql);
		}

		public static void SetNotes(long ltrans_ctl_no, long ltrans_seq_no, string sNotes)
		{
			string sql = string.Format( @"Update t_booking_request_error
							  set error_notes = '{2}',
								  error_user = '{3}'
						   where trans_ctl_no = {0}
						     and trans_seq_no = {1} ",
							ltrans_ctl_no, ltrans_seq_no, sNotes, ClsEnvironment.UserName);
			Connection.RunSQL(sql);

		}
	}
}
