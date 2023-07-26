using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ACMS.Business
{
	public partial class ClsPartnerEmail
	{
		public int CustomUpdate(ClsPartnerEmail org, string sName, string sEmail)
		{
			string sql = string.Format(@"
				update r_partner_email
					set outlook_name = '{0}',
						outlook_email = '{1}'
					where outlook_name = '{2}'
                      and partner_cd = '{3}'
					  and email_list_cd = '{4}' ",
					sName, sEmail, org.Outlook_Name, org.Partner_Cd, org.Email_List_Cd);

			int ret = Connection.RunSQL(sql);
			return ret;
		}

		public static DataTable GetEmailList(string sListCd)
		{
			string sql = string.Format(@"
				select * from R_PARTNER_EMAIL  
				 where email_list_cd = '{0}' ",
				sListCd);
			return Connection.GetDataTable(sql);
		}
	}
}
