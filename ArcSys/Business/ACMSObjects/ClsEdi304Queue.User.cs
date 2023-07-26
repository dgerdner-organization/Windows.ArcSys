using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ACMS.Business
{
	public partial class ClsEdi304Queue
	{
		public static DataTable GetUnsent(bool bIncludeSent)
		{
			string sql = string.Format(@"
				select * from t_edi_304_queue
				 where 1 = 1 ");
			if (!bIncludeSent)
				sql = sql + " and confirm_flg = 'N' ";
			return Connection.GetDataTable(sql);
		}

		public static List<ClsEdi304Queue> GetUnsentList(bool bIncludeSent)
		{
			List<ClsEdi304Queue> qList = new List<ClsEdi304Queue>();
			DataTable dt = GetUnsent(bIncludeSent);
			foreach (DataRow drow in dt.Rows)
			{
				ClsEdi304Queue q = new ClsEdi304Queue(drow);
				qList.Add(q);
			}
			return qList;
		}

		public static void Send304(string sPartnerCd, string sRequestCd)
		{
			// Delete record of all 304's that have been sent for this item
			string sql = string.Format(@"
				update t_304_sent 
					set delete_fl = 'Y'
				   where partner_cd = '{0}'
					  and partner_request_cd = '{1}' ", sPartnerCd, sRequestCd);
			Connection.RunSQL(sql);

			// Add a row to the 304 Queue.  If a row already exists,
			// set the xmit flag to "N"
			ClsEdi304Queue q = ClsEdi304Queue.GetUsingKey(sPartnerCd, sRequestCd);
			if (q == null)
			{
				q = new ClsEdi304Queue();
				q.Partner_Cd = sPartnerCd;
				q.Partner_Request_Cd = sRequestCd;
				q.Confirm_Flg = "N";
				q.Insert();
				return;
			}
			q.Confirm_Flg = "N";
			q.Update();
		}

		public static void DoNotSend(string sPartnerCd, string sRequestCd)
		{
			string sql = string.Format(@"
				insert into t_304_sent
					select '{0}', '{1}', '{2}', sysdate, null, 'N' from dual",
					sPartnerCd, sRequestCd, "WLWH");
			Connection.RunSQL(sql);
		}
	}
}
