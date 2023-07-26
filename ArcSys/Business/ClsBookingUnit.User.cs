using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using CS2010.ArcSys.Business;
using CS2010.Common;

namespace CS2010.ACMS.Business
{
	public partial class ClsBookingUnit
	{
		#region Properties

		private DataRow _mvDepart;
		private DataRow mvDepart
		{
			get
			{
				if (_mvDepart != null)
					return _mvDepart;
				_mvDepart = GetMvDepart();
				return _mvDepart;
			}
		}
		//private DataRow mvArrive;
		private DateTime? _DepartDt;
		public DateTime? DepartDt
		{
			get
			{
				if (_DepartDt != null)
				{
					return _DepartDt;
				}
				if (mvDepart == null)
					return null;

				string s = mvDepart["mv_dt"].ToString();
				_DepartDt = ClsConvert.ToDateTimeNullable(s);
				return _DepartDt;

			}
		}
		private ClsStenaBooking _StenaBooking;
		public ClsStenaBooking StenaBooking
		{
			get
			{
				if (_StenaBooking != null)
					return _StenaBooking;
				GetStenaBooking();
				return _StenaBooking;
			}
			set
			{
				_StenaBooking = value;
			}
		}
		public ClsStenaBooking GetStenaBooking()
		{
			_StenaBooking = null;
			_StenaBooking = ClsStenaBooking.GetUsingKey(this.Booking_ID, this.Tcn);
			return _StenaBooking;
		}

		protected DataRow GetMvDepart()
		{
			try
			{
				string sql = string.Format(@"
					select min(Departure_dt) as mv_dt
					 from mv_voyage_route_detail
					 where voyage_cd = '{0}'
					  and location_cd like '{1}'
					  and pol_pod = '{2}' ",
					this.Voyage_No, this.Poe_Location_Cd, "L");
				return Connection.GetDataRow(sql);
			}
			catch (Exception ex)
			{
				ClsErrorHandler.LogException(ex);
				return null;
			}
		}

		private ClsCargoCode _CargoCode;
		public ClsCargoCode CargoCode
		{
			get
			{
				if (_CargoCode != null)
					return _CargoCode;
				GetCargoCode();
				return _CargoCode;
			}
		}
		public void GetCargoCode()
		{
			_CargoCode = ClsCargoCode.GetUsingKey(this.Cargo_ID.GetValueOrDefault());
		}

		private DataRow _ExtendedData;
		private DataRow ExtendedData
		{
			get
			{
				if (_ExtendedData != null)
					return _ExtendedData;
				_ExtendedData = GetExtendedData(this.Partner_Cd, this.Partner_Request_Cd, this.Item_No.ToString());
				return _ExtendedData;
			}
		}
		public string StenaRoutecd
		{
			get { return ExtendedData["stena_route_cd"].ToString(); }
		}
		private DateTime? _StenaProposedDt;
		public DateTime StenaProposedDepartDt
		{
			get
			{
				if (_StenaProposedDt != null)
					return _StenaProposedDt.GetValueOrDefault();
				string s = ExtendedData["stena_depart_dt"].ToString();
				DateTime? dt = DateTime.MinValue;
				if (!string.IsNullOrEmpty(s))
				{
					dt = ClsConvert.ToDateTimeNullable(s);
				}
				_StenaProposedDt = dt.GetValueOrDefault();
				return _StenaProposedDt.GetValueOrDefault();
			}
		}

		public DataTable StenaAuditTrail
		{
			get
			{
				if (this.StenaBooking == null)
					return null;

				string sql = string.Format(@"select * from t_stena_booking_audit 
							   where booking_no = '{0}'
								 and trailer_no = '{1}' ",
							    this.Booking_ID, this.StenaBooking.Trailer_No);

				DataTable dt = Connection.GetDataTable(sql);
				return dt;
			}
		}

		private ClsBookingRequest _BookingRequest;
		public ClsBookingRequest BookingRequest
		{
			get
			{
				if (_BookingRequest == null)
					GetBookingRequest();
				return _BookingRequest;
			}
		}

		public void GetBookingRequest()
		{
			// This will retrieve all booking requests for the current request code.
			// It use the latest one as the "current" booking request.
			string sql = string.Format(@"
				select * from t_booking_request br
                    where br.partner_request_cd = '{0}'
                      and br.partner_cd = '{1}'
                      /*and br.acms_status_cd in ('B','C','W', 'P') */",
				this.Partner_Request_Cd, this.Partner_Cd);

			DataTable dt = Connection.GetDataTable(sql);
			if (dt.Rows.Count > 0)
			{
				DataRow dr = dt.Rows[0];
				_BookingRequest = new ClsBookingRequest(dr);
			}
		}
		#endregion

		#region Methods
		public DataTable GetStenaSailings()
		{
			DataTable dt1 = ClsStenaRouteSailing.GetStenaSailings(this.StenaRoutecd);
			return dt1;
		}
		#endregion
		#region Statics
		public static DataTable SearchBookingUnits(
					string sPartner,
					string sVoyage,
					int iDays,
					string sPCFN,
					string sBookingNo,
					string sPOL, string sPOD,
					string sSerialNo,
					bool bJustStena
					)
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendFormat(@"
				  SELECT bu.*, 
						st.trailer_no, 
						st.stena_id, 
						st.sailing_dt,
						t_booking_request.trans_ctl_no,
						t_booking_request.trans_seq_no,
						case when st.booking_no is null then 'N' else 'Y' end as stena_flg,
						case when st.booking_no is not null and st.stena_id is null then 'Y' else 'N' end as stena_unbooked_flg,
						f_voyage_dt(bu.voyage_no, bu.poe_location_cd, bu.poe_terminal_cd, 'L') as stena_depart_dt, 
						f_voyage_dt(bu.voyage_no, bu.poe_location_cd, bu.poe_terminal_cd, 'L') as est_depart_dt, 
						f_voyage_dt(bu.voyage_no, bu.pod_location_cd, bu.pod_terminal_cd, 'D') as est_arrive_dt
                             
					FROM T_BOOKING_REQUEST 
						left outer join R_ACMS_STATUS on t_booking_request.acms_status_cd = r_acms_status.acms_status_cd 
						inner join t_booking on t_booking_request.partner_cd = t_booking.partner_cd and
		 							  t_booking_request.partner_request_cd = t_booking.partner_request_cd
						inner join t_booking_unit bu on bu.partner_cd = t_booking.partner_cd and
                                                        bu.partner_request_cd = t_booking.partner_request_cd 
					    left outer join v_stena_booking st on st.booking_no = bu.booking_id
                                                           and st.serial_no = bu.tcn "

					);

			if (bJustStena)
			{
				sb.AppendFormat(@" inner join r_stena_route sr on
                                      sr.pol_location_cd = t_booking.location_poe_cd and
                                      sr.pod_location_cd = t_booking.location_pod_cd ");
			}
			sb.AppendFormat(@"
				   WHERE 
						 trim(T_BOOKING_REQUEST.PARTNER_CD) like '{0}'  AND  
						 T_BOOKING_REQUEST.PARTNER_REQUEST_CD like '{1}' and
						 t_booking_request.modify_dt > sysdate - {2}  and
						 nvl(trim(t_booking_request.booking_id),'$') like '{3}' and
						 T_BOOKING_REQUEST.VOYAGE_NO like '{4}' and
						 NVL(T_BOOKING.LOCATION_POE_CD,'$') like '{5}' and
						 NVL(T_BOOKING.LOCATION_POD_CD,'$') like '{6}'
						 and t_booking_request.acms_status_cd in ('B','C') 
						 ",
						  sPartner, sPCFN, iDays, sBookingNo, sVoyage, sPOL, sPOD);

			if (sSerialNo != "%" && !string.IsNullOrEmpty(sSerialNo))
			{
				sb.AppendFormat(@"
					and exists (
						select 1 from t_booking_unit bu
							where tcn like '{0}' 
                              and bu.partner_request_cd = t_booking_request.partner_request_cd )",
					   sSerialNo);
			}

			string sql = sb.ToString();
			DataTable dt = Connection.GetDataTable(sql);
			return dt;
		}


		public static DataTable GetUnitsForRequest(string sPartnerCd, string sRequestCd)
		{
			string sql = string.Format(@"
			  SELECT bu.*,
					 'ITV' as c_click,   
						c.model_code,
					 f_voydoc(bu.voyage_no) as voydoc,
					 (select activity_code from t_booking_itv where activity_id = (select max(activity_id) 
						from t_booking_itv where booking_id = bu.booking_id and 
												 booking_sub = bu.booking_id_sub and sub_tcn = bu.tcn)) 
							as last_activity,   
						sb.stena_id,
						f_voyage_dt(bu.voyage_no, bu.poe_location_cd, bu.poe_terminal_cd, 'L') as stena_depart_dt, 
						f_voyage_dt(bu.voyage_no, bu.poe_location_cd, bu.poe_terminal_cd, 'L') as est_depart_dt, 
						f_voyage_dt(bu.voyage_no, bu.pod_location_cd, bu.pod_terminal_cd, 'D') as est_arrive_dt, 
						sr.route_cd as stena_route_cd,
						sb.trailer_no,
						sb.sailing_dt,
						rc.rev_dsc,
						nvl(pol.other1_cd, l.other1_cd) as pol_milstamp,
						nvl(pod.other1_cd, d.other1_cd) as pod_milstamp,
						F_CUBE_FT(length_nbr, width_nbr, height_nbr) as calc_cube_ft,
						F_CUBE_FT(length_nbr, width_nbr, height_nbr) - bu.volume_nbr as cube_diff,
                        f_ocean_system_voyage(bu.voyage_no) as liner_system
				FROM T_BOOKING_UNIT bu
		      left outer join r_cargo_code c on c.cargo_id = bu.cargo_id
			  left outer join r_commodity_dsc cd on bu.commodity_cd = cd.commodity_cd
              left outer join r_revenue_code rc on bu.rev_cd = rc.rev_cd
			  left outer join v_stena_booking sb on sb.serial_no = bu.tcn
			  left outer join r_location_terminal pol on pol.terminal_cd = bu.poe_terminal_cd
			  left outer join r_location l on l.location_cd = pol.location_cd
			  left outer join r_location_terminal pod on pod.terminal_cd = bu.pod_terminal_cd
			  left outer join r_location d on d.location_cd = pod.location_cd
			  left outer join r_stena_route sr on 
					sr.pol_location_cd = bu.poe_location_cd and sr.pod_location_cd = bu.pod_location_cd
				where partner_cd = '{0}' and partner_request_cd = '{1}' 
				order by item_no",
				   sPartnerCd, sRequestCd);
			DataTable dt = Connection.GetDataTable(sql);
			return dt;
		}

		public static DataRow GetExtendedData(string sPartnerCd, string sRequestCd, string sItemNo)
		{
			string sql = string.Format(@"
			  SELECT bu.*,
					c.model_code,
					 (select activity_code from t_booking_itv where activity_id = (select max(activity_id) 
						from t_booking_itv where booking_id = bu.booking_id and 
												 booking_sub = bu.booking_id_sub and item_no = bu.item_no)) 
							as last_activity,   
						sb.stena_id,
						f_voyage_dt(bu.voyage_no, bu.poe_location_cd, bu.poe_terminal_cd, 'L') as stena_depart_dt, 
						sr.route_cd as stena_route_cd
				FROM T_BOOKING_UNIT bu
		      left outer join r_cargo_code c on c.cargo_id = bu.cargo_id
			  left outer join v_stena_booking sb on sb.serial_no = bu.tcn
			  left outer join r_stena_route sr on 
					sr.pol_location_cd = bu.poe_location_cd and sr.pod_location_cd = bu.pod_location_cd
				where partner_cd = '{0}' and partner_request_cd = '{1}' ",
					sPartnerCd, sRequestCd);
			DataTable dt = Connection.GetDataTable(sql);
			if (dt.Rows.Count < 1)
				return null;
			return dt.Rows[0];
		}
		public static ClsBookingUnit GetByTCN(string sBookingNo, string sTCN)
		{
			string sql = string.Format(@"
				select * from t_booking_unit bu
				  where bu.booking_id = '{0}'
                    and bu.tcn = '{1}' ", sBookingNo, sTCN);
			DataTable dt = Connection.GetDataTable(sql);
			if (dt.Rows.Count < 1)
				return null;
			DataRow drow = dt.Rows[0];
			ClsBookingUnit bu = new ClsBookingUnit(drow);
			return bu;
		}
		#endregion
	}
}
