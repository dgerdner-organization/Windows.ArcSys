using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CS2010.ArcSys.Business
{
	public partial class ClsItvActivityCode
	{
		#region Properties
		#endregion

		#region Public Methods
		#endregion

		#region Private Methods
		#endregion

		#region Public Static Methods
		public static DataTable GetForPartner(string sPartnerCd)
		{
			string sql = string.Format(@"
				 select a.* 
				  from r_itv_activity_code a
				 where a.activity_cd not in
				 (select b.activity_cd
				   from r_itv_activity_code_partner b
					where b.trading_partner_cd = '{0}')    
					order by activity_cd ", sPartnerCd);
			DataTable dt = Connection.GetDataTable(sql);
			return dt;
		}
		#endregion
	}
}
