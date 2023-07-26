using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using CS2010.ArcSys.Business;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsCargoExtend
	{
		private ClsBookingLine _BookingLine;
		public ClsBookingLine BookingLine
		{
			get
			{
				if (_BookingLine == null)
				{
					_BookingLine = ClsBookingLine.GetByBookingNo(this.Booking_No);
				}
				return _BookingLine;
			}
		}
		public  string AuditTrailString
		{
			get
			{
				DataTable dt = GetAuditTrail(this.Cargo_Key);
				StringBuilder sb = new StringBuilder();
				foreach (DataRow dr in dt.Rows)
				{
					string sOld = dr["old_value"].ToString();
					string sNew = dr["new_value"].ToString();
					string sUser = dr["modify_user"].ToString();
					string sDate = dr["modify_dt"].ToString();
					sb.AppendLine();
					sb.AppendFormat("Old:{0} \t New:{1} \t Changed:{2} \t {3}", sOld, sNew, sUser, sDate);
				}
				return sb.ToString();
			}
			
		}
		public static DataTable GetAuditTrail(string sKey)
		{
			string sql = string.Format(@"
 			select c.booking_no, a.voyage_no, a.vessel_cd, c.pol_dsc, c.item_no, a.serial_no, a.modify_user, a.modify_dt, a.old_value, a.new_value, c.seq_no
			 from a_cargo_extend a
			  inner join v_booking_cargo_line c on c.cargo_key = primary_key   
			  where table_nm = 'T_CARGO_EXTEND'
			   and operation_cd = 'A'
			   and primary_key = '{0}'
			   and column_nm = 'DIM_VGM_NBR'
			union all
   
			select c.booking_no, a.voyage_no, a.vessel_cd, c.pol_dsc, c.item_no, a.serial_no, a.modify_user, a.modify_dt, a.old_value, a.new_value, c.seq_no
			 from a_cargo_extend a
			  inner join v_booking_cargo_line c on c.cargo_key = primary_key   
			  where table_nm = 'T_CARGO_EXTEND'
			   and operation_cd = 'U'
			   and primary_key = '{0}'
			   and column_nm = 'DIM_VGM_NBR' ", sKey);

			return Connection.GetDataTable(sql);
			
		}
	}
}
