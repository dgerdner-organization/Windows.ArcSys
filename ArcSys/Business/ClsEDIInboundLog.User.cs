using System;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;

namespace CS2010.ArcSys.Business
{
	public partial class ClsEdiInboundLog
	{
		public static DataTable GetEDIInboundLog()
		{
			string sql = string.Format(@"
				select l.*,
				 r.booking_no,
				 r.serial_no,
				 r.receipt_no,
				 r.cargo_rcvd_dt,
				 trunc(l.create_dt) as log_date,
				 trunc(r.cargo_rcvd_dt) as rcvd_date
				 from T_EDI_INBOUND_LOG l
				 inner join t_edi_inbound_322 r
				  on l.edi_inbound_log_id = r.edi_inbound_log_id ");

			return Connection.GetDataTable(sql);
		}
	}
}
