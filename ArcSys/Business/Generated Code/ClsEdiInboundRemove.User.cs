using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	partial class ClsEdiInboundRemove
	{
		#region Methods
		public bool SetProcessed(bool bProcessed)
		{
			Connection.TransactionBegin();
			if (bProcessed)
				this.Processed_Flg = "Y";
			else
				this.Processed_Flg = "N";
			this.Update();
			Connection.TransactionCommit();
			return true;
		}
		#endregion
		#region Static Methods
		public static DataTable GetUnprocessed()
		{
			return GetUnprocessed(Connection);
		}
		public static DataTable GetUnprocessed(ClsConnection conn)
		{
			string sql = string.Format(@"
				select r.*,
				 (select max(d.booking_no)
				  from t_edi_inbound_detail d
				   where d.vin = r.vin
					 and d.processed_flg = 'Y'
					 ) as booking_no_current
				from t_edi_inbound_remove r 
				where r.processed_flg = 'N'");

			return conn.GetDataTable(sql);
		}
		public static DataTable GetByQuery(string sBooking, string sVin, string sProcessed)
		{
			string sql = string.Format(@"
				select * from t_edi_inbound_remove 
					where booking_no = '{0}'
                       and vin = '{1}'
                       and processed_flg = '{2}' ", sBooking, sVin, sProcessed);
			return Connection.GetDataTable(sql);
		}
		#endregion
	}
}
