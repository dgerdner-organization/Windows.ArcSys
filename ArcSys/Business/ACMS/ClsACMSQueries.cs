using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CS2010.Common;
using ASL.ARC.EDISQLTools;

namespace CS2010.ACMS.Business
{
	public static class ClsACMSQueries
	{
		#region Connection Manager

		private static ClsConnection Connection
		{
			get 
			{ 
				return ClsConMgr.Manager["ACMS"]; 
			}
		}
		#endregion		// #region Connection Manager

		public static DataTable GetUnprocessedEDIFiles()
		{
			return GetUnprocessedEDIFiles(Connection);
		}
		public static DataTable GetUnprocessedEDIFiles(ClsConnection conn)
		{
			string sql = string.Format(@"
				select rtrim(table_dsc) as table_dsc, trans_dt, trading_partner_cd
				 from t_edi_activity_ftp
				 where edi_type = '300IN'
				  and trans_dt > sysdate - 7
				   and trans_ctl_no not in
				   (select trans_ctl_no
					from t_booking_request)
				union all
				select 
				  rtrim(filename) as table_dsc,
				  datestamp,
				  'MTMCIBSD'
				   from t_ftp_history h
				 where datestamp > sysdate - 7
				  and filename is not null
				  and filename not like '315E%'
				  and filename not like '301E%'
				  and not exists
				  (select * from t_edi_activity_ftp f
				   where trim(f.table_dsc) = trim(h.filename)) ");
			DataTable dt = conn.GetDataTable(sql);
			return dt;
		}

		public static DataTable GetUnsentConfirmations()
		{
			string sql = string.Format(@"
				 select partner_cd, partner_request_cd, request_dt
				 from t_booking_request 
					where acms_status_cd = 'B'
				 and request_dt > sysdate - 30
				and partner_cd = 'MTMCIBSD'
				 and partner_request_cd not in
				 (
				select a.partner_request_cd
				from t_booking_request a  
				 inner join t_booking_edi_activity b
				  on a.partner_request_cd = b.partner_request_cd
				  and a.partner_cd = b.partner_cd
				 inner join t_edi_activity_ftp c
				  on b.out_trans_ctl_no = c.trans_ctl_no 
				  and substr(edi_type,1,3) = '301'
				 where acms_status_cd = 'B'
				 and a.request_dt > sysdate - 60
				 and a.partner_cd = 'MTMCIBSD'
				 ) 
				 order by request_dt");
			return Connection.GetDataTable(sql);
		}

		public static DataTable GetITVNotSent(ClsConnection conn)
		{
			return GetITVNotSent(conn, null, null);
		}
		public static DataTable GetITVNotSent()
		{
			return GetITVNotSent(Connection, null, null);
		}
		public static DataTable GetITVNotSent(string sBookingNo, string sTCN)
		{
			return GetITVNotSent(Connection, sBookingNo, sTCN);
		}
		public static DataTable GetITVNotSent(ClsConnection conn, string sBookingNo, string sTCN)
		{
			string s = string.Format(@"
				update
				 t_booking
				  set rcvr_city = (select location_dsc from r_location where location_cd = location_pod_cd)
				  where location_plod_cd is null 
				  and booking_id in
				  (
				select distinct booking_id
				 from v_itv_not_sent
				  where reason_msg like 'PLOD city is blank'
				  )
				  ");
			conn.RunSQL(s);

			StringBuilder sql = new StringBuilder();
			sql.AppendFormat(@" 
			select 'ITV Not Sent' as problem_dsc, t.*
				   from V_ITV_NOT_SENT t
				 where create_dt < sysdate - .1 ");

			if (!string.IsNullOrEmpty(sBookingNo))
				sql.AppendFormat(" and booking_Id = '{0}' ", sBookingNo);
			if (!string.IsNullOrEmpty(sTCN))
				sql.AppendFormat(" and tcn = '{0}' ", sTCN);

			s = sql.ToString();
			return conn.GetDataTable(s);
		}

		public static DataTable GetAllProblems()
		{
			return GetAllProblems(Connection);
		}
		public static DataTable GetAllProblems(ClsConnection conn)
		{
			try
			{
				//  DGERDNER JULY 2018
				//  Updated to use View; which in turn uses the new ArcSys tables
				//  instead of the old ACMS tables.
				string sql = string.Format(@"select * from v_unsent_confirmations");
				DataTable dt = conn.GetDataTable(sql);
				return dt;
			}
			catch (Exception ex)
			{
				string s = ex.Message;
				return null;
			}
				
		}

		public static DataTable GetRequestsWithNoCargo()
		{
			return GetRequestsWithNoCargo(Connection);
		}
		public static DataTable GetRequestsWithNoCargo(ClsConnection conn)
		{
			// Look for new booking request from AAL where nothing has been requested.  These
			// bookings have to be manually adjusted in ACMS.
			StringBuilder sb = new StringBuilder();
			sb.AppendFormat(@"
					select distinct r.partner_request_cd, r.partner_cd
					 from t_booking_request r
					 left outer join t_booking_unit u
					  on r.partner_cd = u.partner_cd
					  and r.partner_request_cd = u.partner_request_cd
					  where r.partner_request_cd like 'A%'
					   and u.partner_request_cd is null
						and request_dt > sysdate - 15
						 and acms_status_cd in ('R','P', 'PB', 'PC') ");
			string sql = sb.ToString();
			DataTable dtVoids = conn.GetDataTable(sql);
			return dtVoids;
		}

		/// <summary>
		/// Looks for all new booking requests
		/// </summary>
		/// <returns></returns>
		public static DataTable GetNewBookingRequests()
		{
			DateRange dr = new DateRange();
			DataTable dt = ClsBookingRequest.SearchBookingRequests("%", "%", null, "%", 30, "%", "%", "%", "%",
							"%", null, false, true, false, null, null, null, null, null, "", "%","%", false );
			return dt;
		}
		public static DataTable GetVoyage(string sVoyageNo)
		{
			if (string.IsNullOrEmpty(sVoyageNo))
				sVoyageNo = "%";
			else
				sVoyageNo = sVoyageNo.Trim() + "%";

			string sql = string.Format(@"
				select mv_voyage.*, c.ircs, c.imo, c.mmsi, c.tracking_url, v.vessel_dsc 
				from mv_voyage
					left outer join r_vessel_code c on c.vessel_cd = mv_voyage.vessel_cd
					left outer join r_vessel v on v.vessel_cd = mv_voyage.vessel_cd
				 where voyage_cd like '{0}' ",
					sVoyageNo);

			DataTable dt = Connection.GetDataTable(sql);
			return dt;
		}

		public static DataTable GetMissingVessel()
		{
			return GetMissingVessel(Connection);
		}
		public static DataTable GetMissingVessel(ClsConnection conn)
		{
			// Find all booking requests where the vessel does not exist in the ACMS database
			string sql = string.Format(@"
				select bu.partner_request_cd, v.voyage_cd, v.vessel_cd
				 from mv_voyage v
				  inner join t_booking_unit bu
				   on bu.voyage_no = v.voyage_cd
				  inner join t_booking_request br on br.partner_request_cd = bu.partner_request_cd
				   and br.acms_status_cd not in ('X','A')
				   and br.request_dt > sysdate - 60
				 where bu.vessel_cd not in
				 (select vessel_cd from r_vessel) ");
			return conn.GetDataTable(sql);
		}

		public static DataTable GetMismatchDims()
		{
			return GetMismatchDims(Connection);
		}

		public static DataTable GetMismatchDims(ClsConnection conn)
		{
            string sql = string.Format(@"
					select * from v_arcsys_dim_mismatch
                      order by booking_no, serial_no");
				DataTable dt = conn.GetDataTable(sql);
			return dt;
		}

		public static DataTable GetVoyageDetail(string sVoyageNo)
		{
			string sql = string.Format(@"
				select vrd.*, l.location_dsc
				 from mv_voyage_route_detail vrd
				  left outer join r_location l
				   on l.location_cd = vrd.location_cd
				 where voyage_cd = '{0}' ",
					sVoyageNo);

			DataTable dt = Connection.GetDataTable(sql);
			return dt;
		}

		public static DataTable GetLocationProblems(ClsConnection conn)
		{
			string sql = string.Format(@"
				  select 'Census Type is not defined' as error_msg, location_cd, location_dsc
				   from r_location
				   where census_type is null
					and delete_fl = 'N'
					union all
					  select 'City or Country is not defined', location_cd, location_dsc
				   from r_location
				   where (city is null or  country_cd is null ) 
					and delete_fl = 'N'");
			DataTable dt = conn.GetDataTable(sql);
			return dt;
		}

		public static DataTable GetArriveDepartSchedule(string sPartner, int iFrom, double iTo, string sVoyageNo, bool bOnlyProblems)
		{
			return GetArriveDepartSchedule(Connection, sPartner, iFrom, iTo, sVoyageNo, bOnlyProblems);
		}
		public static DataTable GetArriveDepartSchedule(ClsConnection conn, string sPartner, int iFrom, double iTo, string sVoyageNo, bool bOnlyProblems)
		{
			// March2014 DG: It did not used to consider terminal_cd when computing the cargo_count
			// for voyages.  I have changed this, so the report is more accurate.
			//
			// Note we used to ignore it because I didn't want any cargo to "slip through the cracks".  However
			// Those should all be caught in our diagnostics reports, so we are now going to make this query
			// 100% correct, which should make it easier to work with.
			StringBuilder sb = new StringBuilder();
			sb.AppendFormat(@"
				select * from
				(
				select arrive.voyage_cd as voyageno, 
				  vessel_cd,
				  'Arrive' as ArriveDepart, 
				  location_cd, 
				  arrive.terminal_cd,
				  min(arrival_dt) as voyagedate, 
				  actual_arrival_fl as actual_flg,
				 (select count(*)
				  from t_booking_itv itv 
				  where itv.voyage_no = arrive.voyage_cd
				   and itv.activity_code = 'VA'
				   and itv.location_cd = arrive.location_cd
				   and itv.terminal_cd = arrive.terminal_cd
				   ) as itv_count,
					 (select count(*)
				  from t_booking_unit bu
				  inner join t_booking_request b on b.partner_request_cd = bu.partner_request_cd
					and b.acms_status_cd in ( 'B', 'C')
					and b.partner_cd = '{2}'
				   where bu.voyage_no = arrive.voyage_cd
					and bu.pod_location_cd = arrive.location_cd
					and bu.pod_terminal_cd = arrive.terminal_cd
					) as unit_count  
				 from mv_voyage_route_detail arrive
				  inner join mv_voyage v on v.voyage_cd = arrive.voyage_cd
				 where (arrival_dt between sysdate - {0} and sysdate + {1})
				  and pol_pod = 'D'
				group by arrive.voyage_cd, vessel_cd, actual_arrival_fl, location_cd, terminal_cd
				union all
				select depart.voyage_cd, vessel_cd, 'Depart', 
				  location_cd, terminal_cd,
				  min(departure_dt), 
				  actual_departure_fl,
				 (select count(*)
				  from t_booking_itv itv 
				  where itv.voyage_no = depart.voyage_cd
				   and itv.location_cd = depart.location_cd
				   and itv.terminal_cd = depart.terminal_cd
				   and itv.activity_code = 'VD') as itv_count,
				  (select count(*)
				  from t_booking_unit bu
				  inner join t_booking_request b on b.partner_request_cd = bu.partner_request_cd
					and b.acms_status_cd in ( 'B', 'C' )
					and b.partner_cd like '{2}%'    
				   where bu.voyage_no = depart.voyage_cd
					and bu.poe_location_cd = depart.location_cd
					and bu.poe_terminal_cd = depart.terminal_cd 
						) as unit_count    
				 from mv_voyage_route_detail depart
				  inner join mv_voyage v on v.voyage_cd = depart.voyage_cd
				 where (departure_dt between sysdate - {0} and sysdate + {1})
				  and pol_pod = 'L'
				 group by depart.voyage_cd, vessel_cd, location_cd, actual_departure_fl, terminal_cd )				
					where unit_count > 0",
					iFrom, iTo, sPartner);
			if (bOnlyProblems)
			{
				sb.Append(" and itv_count < unit_count ");
			}
			if (!string.IsNullOrEmpty(sVoyageNo))
			{
				sb.AppendFormat(" and voyageno like '{0}' ", sVoyageNo);
			}
			string sql = sb.ToString();
			DataTable dt = conn.GetDataTable(sql);
			return dt;
		}

		public static DataTable GetTShipmentDiagnostics()
		{
			return GetTShipmentDiagnostics(Connection);
		}
		public static DataTable GetTShipmentDiagnostics(ClsConnection conn)
		{
			String sql = string.Format(@"
				select * from v_nitely_transship_diag ");
			return conn.GetDataTable(sql);
		}

		public static List<ClsVShippingInstructionList> GetShippingInstructionList(string sVoyageNo, string sPCFN, string sBookingNo)
		{
			DataTable dt = GetShippingInstructions(sVoyageNo, sPCFN, sBookingNo);
			DataTable dtTrans = GetShippingInstructionsTS(sVoyageNo, sPCFN, sBookingNo);
			dt.Merge(dtTrans);
			List<ClsVShippingInstructionList> vList = new List<ClsVShippingInstructionList>();
			foreach (DataRow drow in dt.Rows)
			{
				ClsVShippingInstructionList vl = new ClsVShippingInstructionList(drow);
				string sBookingID = vl.Booking_ID;
				int iLines = ClsLineSQL.GetLineDetailCount(sBookingID, "%");
				int iBooked = ClsLineSQL.GetLineDetailCount(sBookingID, "BOOK");
                //int iRcvd = iLines - iBooked;
                //vl.Liner_Count = iLines;
                //vl.Rcvd_Count = iRcvd;
				vList.Add(vl);
			}
			return vList;
		}

		public static DataTable GetShippingInstructions(string sVoyageNo, string sPCFN, string sBookingNo)
		{
			string sql = string.Format(@"
				select * from v_shipping_instruction_list where liner_count > 0 ");

			if (!string.IsNullOrEmpty(sVoyageNo))
				sql = string.Format("{0} and voyage_vessel like '{1}%' ", sql, sVoyageNo);

			if (!string.IsNullOrEmpty(sPCFN))
			{
				sPCFN = sPCFN + "%";
				sql = string.Format("{0} and partner_request_cd like '{1}' ", sql, sPCFN);
			}
			if (!string.IsNullOrEmpty(sBookingNo))
				sql = string.Format("{0} and booking_id like '{1}' ", sql, sBookingNo);

			DataTable dt = Connection.GetDataTable(sql);
			return dt;
		}
		public static DataTable GetShippingInstructionsTS(string sVoyageNo, string sPCFN, string sBookingNo)
		{
			string sql = string.Format(@"
				select * from v_shipping_instruction_ts where liner_count > 0 ");

			if (!string.IsNullOrEmpty(sVoyageNo))
				sql = string.Format("{0} and voyage_vessel like '{1}%' ", sql, sVoyageNo);

			if (!string.IsNullOrEmpty(sPCFN))
			{
				sPCFN = sPCFN + "%";
				sql = string.Format("{0} and partner_request_cd like '{1}' ", sql, sPCFN);
			}
			if (!string.IsNullOrEmpty(sBookingNo))
				sql = string.Format("{0} and booking_id like '{1}' ", sql, sBookingNo);

			DataTable dt = Connection.GetDataTable(sql);
			return dt;
		}

		public static DataTable GetRDDMissed()
		{
			string sql = @"
				select * from v_missed_rdd order by voyage_no, pod_location_cd, booking_id, item_no ";
			return Connection.GetDataTable(sql);
		}

		public static DataTable GetCancels(int iDays)
		{
			string sql = string.Format(@"
				select trans_ctl_no, trans_seq_no, trim(partner_cd) as partner_cd, 
					substr(partner_request_cd,1,6) as partner_request_cd, request_dt, cancel_fl
					from t_booking_cancel where request_dt > sysdate - {0} 
					order by request_dt desc, partner_request_cd", iDays);
			DataTable dt = Connection.GetDataTable(sql);
			return dt;
		}

	}
}
