using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CS2010.Common;
using System.Data;
using System.Data.Common;

namespace CS2010.ArcSys.Business
{
	public class ClsLINEWarehouseSearch
	{
		#region Connection Manager

		private static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ArcSys"]; }
		}
		#endregion		// #region Connection Manager

		public List<ClsVBookingCargoLine> GeneralViewSearch(
			string VoyageNo,
			string VesselCd,
			string BookingNo,
			string PCFN,
			string TCN)
		{
			DataTable dt = GeneralSearch(VoyageNo, VesselCd, BookingNo, PCFN, TCN,null,null,false,false);
			List<ClsVBookingCargoLine> cargoList = new List<ClsVBookingCargoLine>();
			foreach (DataRow drow in dt.Rows)
			{
				ClsVBookingCargoLine x = new ClsVBookingCargoLine(drow);
				cargoList.Add(x);
			}
			return cargoList;
		}

		public DataTable GeneralSearch(
			string VoyageNo,
			string VesselCd,
			string BookingNo,
			string PCFN,
			string TCN,
			string POL,
			string POD,
			bool bJustContainers,
			bool bJustVGM)
		{
			
			StringBuilder sb = new StringBuilder();

//            sb.AppendFormat(@"
//				select * from t_booking_line b
//                 inner join t_cargo_line c
//                    on b.booking_line_id = c.booking_line_id 
//                 where 1 = 1");
			sb.AppendFormat(@"
				select b.*,  c.*,
						case
							   when cx.dim_vgm_nbr is null then   c.weight_nbr * 0.453592 
								 else c.weight_nbr
								   end as weight_kgs_nbr,
                      cx.dim_vgm_nbr,
					  nvl(cx.original_weight_nbr, c.weight_nbr * 0.453592) as original_weight_nbr,
					  cx.modify_user || ' ' || to_char (cx.modify_dt, 'MM/DD/YY HH:MI AM') as vgm_modified,
                        c.bol_no as cargo_bol_no
				from t_booking_line b
				  left outer join t_cargo_line c on c.booking_line_id = b.booking_line_id
                  left outer join t_cargo_extend cx on cx.cargo_key = c.cargo_key
                 where 1 = 1");

			if (!string.IsNullOrEmpty(VoyageNo))
				sb.AppendFormat(" and voyage_no like '{0}%'", VoyageNo);
			if (!string.IsNullOrEmpty(BookingNo))
				sb.AppendFormat(" and b.booking_no like '{0}%'", BookingNo);
			if (!string.IsNullOrEmpty(TCN))
				sb.AppendFormat(" and c.serial_no like '{0}%'", TCN);
			if (!string.IsNullOrEmpty(PCFN))
				if (PCFN != "%")
					sb.AppendFormat(" and edi_ref like '{0}%'", PCFN);
			if (!string.IsNullOrEmpty(POL))
				sb.AppendFormat(" and pol_location_cd = '{0}'", POL);
			if (!string.IsNullOrEmpty(POD))
				sb.AppendFormat(" and pod_location_cd = '{0}'", POD);
			if (bJustContainers)
				sb.AppendFormat(" and c.commodity_cd in ('100003','100004') ");
			if (bJustVGM)
				sb.AppendFormat(" and cx.dim_vgm_nbr is not null ");


			string s = sb.ToString();
			DataTable dt = Connection.GetDataTable(s);
			return dt;
		}
	}
}
