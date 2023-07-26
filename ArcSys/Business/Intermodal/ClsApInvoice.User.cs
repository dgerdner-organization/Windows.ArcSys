using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsApInvoice
	{
		#region Static Methods
		public static DataTable SearchApInvoice(string sVendorCd, string sInvoiceNo)
		{
			StringBuilder sql = new StringBuilder();
			sql.AppendFormat(@"
				select * from T_AP_INVOICE t
				 inner join r_vendor v on v.vendor_cd = t.vendor_cd
				where 1 = 1 ");
			if (!string.IsNullOrEmpty(sVendorCd))
			{
				sql.AppendFormat(" and t.vendor_cd like '{0}' ", sVendorCd);
			}
			if (!string.IsNullOrEmpty(sInvoiceNo))
			{
				sql.AppendFormat(" and t.invoice_no like '{0}' ", sInvoiceNo + "%");
			}
			DataTable dt = Connection.GetDataTable(sql.ToString());
			return dt;
		}
		#endregion

	}


}
