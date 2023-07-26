using System;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;

namespace CS2010.ArcSys.Business
{
	public partial class ClsEdiOutboundBol
	{
		public static void Resend(string sBOL)
		{
			string sql = string.Format(@"
				delete from t_edi_outbound_bol where bol_no = '{0}'", sBOL);
			Connection.RunSQL(sql);
		}
		public static int BOLQueue()
		{
			DataTable dt = Connection.GetDataTable("select * from v_ial_bol_out");
			return dt.Rows.Count;
		}
	}
}
