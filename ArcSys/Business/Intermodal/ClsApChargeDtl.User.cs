using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsApChargeDtl
	{

		#region Static Methods
		public static DataTable GetForInvoice(ClsApInvoice api)
		{
			StringBuilder sql = new StringBuilder();
			sql.AppendFormat(@"
				select dtl.*,
				 v.vendor_nm,
				 ct.charge_type_dsc,
				 ca.orig_location_cd,
				 ca.dest_location_cd,
				 ca.billable_flg,
				 c.serial_no,
				 c.length_nbr,
				 c.width_nbr,
				 c.height_nbr,
				 c.weight_nbr,
				 c.dim_weight_nbr,
				 c.m_tons,
				 b.booking_no,
				 trk.truck_no,
				 trk.conveyance_dt,
				 (select min(activity_dt) from v_acms_booking_itv itv
				  where b.booking_no = itv.booking_id
					and c.serial_no = itv.tcn
					and itv.activity_code = 'X1') as x1_dt
			 from t_Ap_Charge_Dtl dtl
				 inner join t_ap_invoice i on i.ap_invoice_id = dtl.ap_invoice_id
				 inner join r_vendor v on v.vendor_cd = i.vendor_cd
				 inner join r_charge_type ct on ct.charge_type_cd = dtl.charge_type_cd
				 inner join t_cargo_activity ca on ca.cargo_activity_id = dtl.cargo_activity_id
				 inner join t_cargo c on c.cargo_id = ca.cargo_id
				 inner join t_booking b on c.booking_id = b.booking_id
				 inner join t_conveyance trk on trk.conveyance_id = ca.conveyance_id
			  where 1 = 1
                and dtl.ap_invoice_id = {0}", api.Ap_Invoice_ID);

			DataTable dt = Connection.GetDataTable(sql.ToString());
			return dt;
		}

		#endregion
	}
}
