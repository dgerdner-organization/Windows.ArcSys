using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsBookingParty
	{
		public static DataTable GetPartiesForRequest(string sPartnerCd, string sRequestCd)
		{
			string sql = string.Format(@"
				select p.*,
				   case 
					 when party_type_cd = 'SH' then 'Shipper'
					 when party_type_cd =  'CN' then 'Receiver'
					 when party_type_cd =  'CI' then 'Requester'
					 when party_type_cd =  'IC' then 'Booker'
					 else party_type_cd
				   end as party_type_dsc 
				  from t_booking_party p
					where partner_cd = '{0}'
                      and partner_request_cd = '{1}' ",
				   sPartnerCd, sRequestCd);
			DataTable dt = Connection.GetDataTable(sql);
			return dt;
		}

	}
}
