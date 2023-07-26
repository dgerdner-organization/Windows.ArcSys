using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ACMS.Business
{
	public partial class ClsBookingRequestNote
	{
		public string NotesFormatted
		{
			get
			{
				string s = string.Format("{0} {1} {2} {3} {4} {5} {6} {7} ",
					this.Note_Cd1, Note_Cd2, Note_Cd3, Note_Cd4, Note_Cd5, Note_Cd6, Note_Cd7, Note_Cd8);
				s = s.Trim();
				return s;
			}
		}

		public static DataTable GetForPCFN(string sPartnerCd, string sPCFN)
		{
			// Puts the newest note on the top
			string sql = string.Format(@"
				select * from t_booking_request_note
                   where partner_cd = '{0}' and partner_request_cd = '{1}'
						order by note_dt desc",
					sPartnerCd, sPCFN);
			DataTable dt = Connection.GetDataTable(sql);
			return dt;
		}
	}
}
