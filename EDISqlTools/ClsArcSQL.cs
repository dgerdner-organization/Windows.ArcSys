using System;
using System.Collections.Generic;
using System.Text;
using CS2010.Common;
using System.Data;
using System.Data.Common;

namespace ASL.ARC.EDISQLTools
{
	static public class ClsArcSQL
	{
		#region Connections
		private static ClsConnection Connection
		{
			get
			{
				// "ArcSys" is the normal connecton string.  However, at least
				// one of our applications (SDDCEDI) uses "AROF" instead.
				if (ClsConMgr.Manager["AROF"] == null)
					return ClsConMgr.Manager["ArcSys"];
				return ClsConMgr.Manager["AROF"]; }
		}
		#endregion

		#region Properties
		public static bool IsITVUser(string UserNm)
		{
			//
			// Looks for the object in the security tables
			//

			//List<ClsSecurityGroup> grpList
			// = ClsSecurityGroup.GetGroupByUser(UserNm);
			//if( grpList.Count < 1 )
			//    return false;
			//ClsSecurityGroup grp = grpList[0];
			//bool bVisible = grp.CheckForObject("EDIM", "mnuITVActivity");
			//return bVisible;

			//
			// OLd hard-coded version
			//

			string s = UserNm.ToLower();
			return (
				string.Compare(s, "ssandianna", true) == 0 ||
				string.Compare(s, "dleon", true) == 0 ||
				string.Compare(s, "sroberts", true) == 0 ||
				string.Compare(s, "dmatan", true) == 0 ||
				string.Compare(s, "jwhittemore", true) == 0 ||
				string.Compare(s, "lfranco", true) == 0 ||
				string.Compare(s, "cbrunache", true) == 0 ||
				string.Compare(s, "clantz", true) == 0 ||
				string.Compare(s, "dgerdner", true) == 0 ||
				string.Compare(s, "jcamero", true) == 0 ||
				string.Compare(s, "joommen", true) == 0 ||
				string.Compare(s, "jespejon", true) == 0 ||
				string.Compare(s, "meerden", true) == 0 ||
				string.Compare(s, "tsalmon", true) == 0);
		}
		#endregion

		#region Reports
		public static DataTable GetRDDReport(string sVessel, string sVoyage, string sMoveType, string sPOL, string sPOD, string sPLOD, string sPCFN, DateRange drDates)
		{
			string BaseSQL = @"
				select v.vessel_nm, s.voyage_no, s.partner_request_cd as pcfn, s.tcn, s.booking_id as booking_no,
				 s.move_type_cd, bl.cargo_dsc, bl.cargo_bol_no as bol_no, bl.length_nbr * 2.54 as length_nbr, 
				 bl.width_nbr * 2.54 as width_nbr, bl.height_nbr * 2.54 as height_nbr, bl.weight_nbr * 0.453592 as weight_nbr, 
				f_voyage_dt(s.voyage_no, s.pod_location_cd, s.pod_berth, 'D') as pod_eta, s.rdd_dt, s.va_dt, s.oa_dt, s.x1_dt,
				s.*, bl.pod_dsc, bl.plod_dsc
				 from v_sddc_itv_summary s
				  inner join r_vessel v on v.vessel_cd = s.vessel_cd
				  left outer join v_booking_cargo_line bl on bl.booking_no = s.booking_id and bl.serial_no = s.tcn 
                 where 1 = 1";
			StringBuilder sql = new StringBuilder();
			sql.Append(BaseSQL);
			List<DbParameter> p = new List<DbParameter>();

			//Connection.AppendLikeClause(sql, p, "AND", "s.voyage_no", "@VOYNO", sVoyage);
			//DataTable dt = Connection.GetDataTable(sql.ToString(), p.ToArray());
			if (!string.IsNullOrEmpty(sVoyage))
				sql.AppendFormat(" and s.voyage_no in ({0})", sVoyage);
			if (!string.IsNullOrEmpty(sPCFN))
			{
				sql.AppendFormat(" and s.partner_request_cd in ({0})", sPCFN);
			}
			if (!string.IsNullOrEmpty(sMoveType))
				sql.AppendFormat(" and s.move_type_cd in ({0})", sMoveType);
			if (!string.IsNullOrEmpty(sPOL))
				sql.AppendFormat(" and s.pol_location_cd in ({0})", sPOL);
			if (!string.IsNullOrEmpty(sPOD))
				sql.AppendFormat(" and s.pod_location_cd in ({0})", sPOD);
			if (!string.IsNullOrEmpty(sPLOD))
				sql.AppendFormat(" and s.plod_location_cd in ({0})", sPLOD);
			if (!string.IsNullOrEmpty(sVessel))
				sql.AppendFormat(" and s.vessel_cd = {0} ", sVessel);

			Connection.AppendDateClause(sql, p, "AND", "s.rdd_dt", "@RDDFROM", "@RDDTO", drDates);
			string s = sql.ToString();
			DataTable dt = Connection.GetDataTable(s, p.ToArray());
			return dt;
		}

		public static DataTable GetRDDDoorOutReport(string sVoyage, string sVessle, bool bIncludeStena)
		{
			string sql = "select * from v_rdd_door_out where 1 = 1";
			if (!bIncludeStena)
				sql = sql + " and route_description is null ";
			if (!string.IsNullOrEmpty(sVoyage))
				sql = sql + string.Format(" and voyage_no like '{0}' ", sVoyage);

			DataTable dt = Connection.GetDataTable(sql);
			return dt;
		}

		public static DataTable GetITVSummaryReport(string sVoyage, string sVessel, string sTCN)
		{
			if( string.IsNullOrEmpty(sVoyage) )
				sVoyage = "%";
			if( string.IsNullOrEmpty(sVessel) )
				sVessel = "%";
			if( string.IsNullOrEmpty(sTCN) )
				sTCN = "%";
			StringBuilder sb = new StringBuilder();
			sb.AppendFormat(@"
				SELECT *
					from v_sddc_itv_summary
                   where voyage_no like '{0}'
                     and vessel_cd like '{1}'
					 and tcn like '{2}'
				order by voyage_no, tcn ",
				  sVoyage, sVessel, sTCN);
			DataTable dt = Connection.GetDataTable(sb.ToString());
			return dt;
		}

		public static DataTable GetRDDPortOutReport(string sVoyage, string sVessle, bool bIncludeStena)
		{
			string sql = "select * from v_rdd_port_out where 1 = 1 ";
			if (!bIncludeStena)
				sql = sql + " and route_description is null ";
			if (!string.IsNullOrEmpty(sVoyage))
				sql = sql + string.Format(" and voyage_no like '{0}' ", sVoyage);

			DataTable dt = Connection.GetDataTable(sql);
			return dt;
		}

		public static DataTable GetPortChangeLog()
		{
			string sql = string.Format(@"
				select * from A_VOYAGE_PORT_CHANGE t
					order by datestamp desc ");
			return Connection.GetDataTable(sql);
		}

		public static DataTable GetTShipmentDiagnostics()
		{
			// OBSOLTE -- Should use the one in ACMS now.
			return GetTShipmentDiagnostics(Connection);
		}
		public static DataTable GetTShipmentDiagnostics(ClsConnection conn)
		{
			String sql = string.Format(@"
				select * from v_nitely_transship_diag ");
			return conn.GetDataTable(sql);
		}

		#endregion

		#region Methods
		public static void LogPortTypeChange(
			string sManr, string sSeqno, 
			string sVoyage, string sPort, string sType,
			string sNewVoyage, string sNewPort, string sNewType,
			string sUser
			)
		{
			string sql = string.Format(@"
				insert into a_voyage_port_change
				(
				 datestamp, userstamp, rhrmanr, rhseqno,
				 prev_voyage, prev_port, prev_type,
				 new_voyage, new_port, new_type)
				 values
				 (
				  sysdate, '{0}', {1},{2},
				  '{3}','{4}','{5}', '{6}','{7}','{8}'
				  )", sUser, sManr, sSeqno, sVoyage, sPort, sType,
					sNewVoyage, sNewPort, sNewType);

			Connection.RunSQL(sql);
		}

		public static bool UpdateVoyageSailDate(int? iVBAid, DateTime dtSailDt)
		{
			try
			{
				string sql = string.Format(@"
				exec p_update_sail_dt ({0}, '{1}') ",
							iVBAid, dtSailDt);
				string s = sql;
				Connection.RunSQL(sql);
				return true;
			}
			catch (Exception ex)
			{
				ClsErrorHandler.LogException(ex);
				return false;
			}
		}
		#endregion

		#region Queries
		public static DataTable GetCargoListForVAD(string sBooking, string sVoyage,
		string sVessel, string sTCN, string sPCFN, string sPOL, string sPOD, string sAD)
		{
			if (string.IsNullOrEmpty(sBooking))
				sBooking = "%";
			if (string.IsNullOrEmpty(sVoyage))
				sVoyage = "%";
			else
			{
				sVoyage = sVoyage.Substring(0, Math.Min(sVoyage.Length, 5)) + "%";
				//sVoyage = sVoyage.Trim() + "%";
			}
			if (string.IsNullOrEmpty(sVessel))
				sVessel = "%";
			if (string.IsNullOrEmpty(sTCN))
				sTCN = "%";
			if (string.IsNullOrEmpty(sPCFN))
				sPCFN = "%";
			if (string.IsNullOrEmpty(sPOL))
				sPOL = "%";
			if (string.IsNullOrEmpty(sPOD))
				sPOD = "%";
			StringBuilder sb = new StringBuilder();

			// APR2013 DGERDNER
			// Added a NVL to the partner_request_cd in the WHERE clause,
			// because it was not returning any rows if it could not find
			// a match in ACMS.
			sb.AppendFormat(@"
					select a.voyage_no, a.booking_id as booking_no,
					vessel_cd, pol_location_cd, pod_location_cd,
						tcn, cargo_type_cd, cargo_status,
					nvl(partner_request_cd,'Manual') as create_source,
					'' as diff_status,
					plor_location_cd, plod_location_cd,
					pol_berth, pod_berth, partner_request_cd, trans_info,
					@DIRBERTH, booking_status
					 from v_sddc_itv_presummary a
					 where a.voyage_no like '{0}'
	                     and vessel_cd like '{1}'
						 and tcn like '{2}'
						 and booking_id like '{3}'
						 and nvl(partner_request_cd,'A') like '{4}'
						 and pol_location_cd like '{5}'
						 and pod_location_cd like '{6}'",
					  sVoyage, sVessel, sTCN, sBooking, sPCFN, sPOL, sPOD);
			sb.AppendFormat("	order by voyage_no, booking_id, tcn ");
			switch (sAD.ToLower())
			{
				case "arrive":
					sb.Replace("@DIRBERTH", "pod_berth as itv_berth ");
					break;
				case "depart":
					sb.Replace("@DIRBERTH", "pol_berth as itv_berth ");
					break;
				default:
					sb.Replace("@DIRBERTH", " ' ' as itv_berth ");
					break;
			}

			DataTable dt = Connection.GetDataTable(sb.ToString());
			return dt;
		}

		public static DataTable GetCargoList(string sBooking, string sVoyage,
				string sVessel, string sTCN, string sPCFN, string sPOL, string sPOD, bool bIncludeMemos, bool bIncludeBooked)
		{
			if (string.IsNullOrEmpty(sBooking))
				sBooking = "%";
			if (string.IsNullOrEmpty(sVoyage))
				sVoyage = "%";
			else
				sVoyage = sVoyage.Substring(0, Math.Min(sVoyage.Length, 5)) + "%";
			if (string.IsNullOrEmpty(sVessel))
				sVessel = "%";
			if (string.IsNullOrEmpty(sTCN))
				sTCN = "%";
			if (string.IsNullOrEmpty(sPCFN))
				sPCFN = "%";
			if (string.IsNullOrEmpty(sPOL))
				sPOL = "%";
			if (string.IsNullOrEmpty(sPOD))
				sPOD = "%";
			StringBuilder sb = new StringBuilder();

			sb.AppendFormat(@"
					select a.*,
					nvl(partner_request_cd,'Manual') as create_source
					 from v_sddc_itv_summary a
					 where a.voyage_no like '{0}'
	                     and vessel_cd like '{1}'
						 and tcn like '{2}'
						 and booking_id like '{3}'
						 and nvl(partner_request_cd,'A') like '{4}'
						 and pol_location_cd like '{5}'
						 and pod_location_cd like '{6}'",
					  sVoyage, sVessel, sTCN, sBooking, sPCFN, sPOL, sPOD);
			if (!bIncludeMemos)
				sb.AppendFormat(" and tariff_cd not like '%MEMO%' ");
			if (!bIncludeBooked)
				sb.AppendFormat(" and cargo_status not like 'BOOK%' ");
			sb.AppendFormat("	order by voyage_no, booking_id, tcn ");

			string sql = sb.ToString();
			DataTable dt = Connection.GetDataTable(sb.ToString());
			return dt;
		}

		public static DataTable GetCargoListIncludePending(string sBooking, string sVoyage,
			/* DGERDNER Added this for Create ITV; uses the presummery view because it includes
			    Pending bookings */
		string sVessel, string sTCN, string sPCFN, string sPOL, string sPOD, bool bIncludeMemos, bool bIncludeBooked)
		{
			if (string.IsNullOrEmpty(sBooking))
				sBooking = "%";
			if (string.IsNullOrEmpty(sVoyage))
				sVoyage = "%";
			else
				sVoyage = sVoyage.Substring(0, Math.Min(sVoyage.Length, 5)) + "%";
			if (string.IsNullOrEmpty(sVessel))
				sVessel = "%";
			if (string.IsNullOrEmpty(sTCN))
				sTCN = "%";
			if (string.IsNullOrEmpty(sPCFN))
				sPCFN = "%";
			if (string.IsNullOrEmpty(sPOL))
				sPOL = "%";
			if (string.IsNullOrEmpty(sPOD))
				sPOD = "%";
			StringBuilder sb = new StringBuilder();

			sb.AppendFormat(@"
					select a.*,
					nvl(partner_request_cd,'Manual') as create_source
					 from v_sddc_itv_presummary a
					 where a.voyage_no like '{0}'
	                     and vessel_cd like '{1}'
						 and tcn like '{2}'
						 and booking_id like '{3}'
						 and nvl(partner_request_cd,'A') like '{4}'
						 and pol_location_cd like '{5}'
						 and pod_location_cd like '{6}'",
					  sVoyage, sVessel, sTCN, sBooking, sPCFN, sPOL, sPOD);
			if (!bIncludeMemos)
				sb.AppendFormat(" and tariff_cd not like '%MEMO%' ");
			if (!bIncludeBooked)
				sb.AppendFormat(" and cargo_status not like 'BOOK%' ");
			sb.AppendFormat("	order by voyage_no, booking_id, tcn ");

			string sql = sb.ToString();
			DataTable dt = Connection.GetDataTable(sb.ToString());
			return dt;
		}
		public static DataTable GetStenaMismatch()
		{
			return GetStenaMismatch(Connection);
		}

		public static DataTable GetStenaMismatch(ClsConnection conn)
		{
//            string sql = string.Format(@"
//				select vessel_berth_activity_id, sr.route_cd, sr.route_description, 
//						vrd.voyage_cd, vrd.location_cd, vrd.pol_pod, vrd.departure_dt, rs.sailing_dt,
//				 (select min(x.sailing_dt) from r_stena_route_sailing x
//				  where trunc(x.sailing_dt) = trunc(vrd.departure_dt) and x.route_cd = sr.route_cd) as first_sailing_dt,
//				 (select max(x.sailing_dt) from r_stena_route_sailing x
//				  where trunc(x.sailing_dt) = trunc(vrd.departure_dt) and x.route_cd = sr.route_cd) as last_sailing_dt
//				 from v_voyage_route_detail vrd
//				  inner join r_stena_route sr
//				   on sr.pol_location_cd = vrd.location_cd and vrd.pol_pod = 'D'
//					  and departure_dt > sysdate - 1
//					  and departure_dt < sysdate + 21
//				  left outer join r_stena_route_sailing rs
//					on rs.route_cd = sr.route_cd
//					and sailing_dt = vrd.DEPARTURE_DT      
//				where rs.route_cd is null    
//				  order by vrd.DEPARTURE_DT ");
			string sql = string.Format(@"
				select * from v_voyage_route_detail_pod vd
				 inner join r_stena_route sr on sr.pol_location_cd = vd.location_cd and sr.pod_location_cd = vd.pod
				 left outer join r_stena_route_sailing srs on srs.route_cd = sr.route_cd and srs.sailing_dt = vd.departure_dt
				 where eta_dt between sysdate - 1 and sysdate + 20
				 and srs.route_cd is null");

			DataTable dt = conn.GetDataTable(sql);
			return dt;

		}

		public static DataTable GetBadLocationList(ClsConnection conn, int iDays)
		{
			string sql = string.Format(@"
					select m.cargo_move_id as pk_id, booking_no, serial_no, plor_location_cd as location_cd, 'Invalid PLOR on Cargo Move' as error_msg
					 from t_cargo_move m
					 left outer join r_location l1 on l1.location_cd = plor_location_cd
					 where m.create_dt > sysdate - {0}
					  and l1.location_cd = 'USFGB'
					union all   
					select m.cargo_move_id as pk_id, booking_no, serial_no, plod_location_cd, 'Invalid PLOD on Cargo Move'
					 from t_cargo_move m
					 left outer join r_location l1 on l1.location_cd = plod_location_cd
					 where m.create_dt > sysdate - {0}
					  and (l1.active_flg = 'N' or l1.active_flg is null)
					union all
					select m.cargo_move_id as pk_id, booking_no, serial_no, pol_location_cd, 'Invalid POL on Cargo Move'
					 from t_cargo_move m
					 left outer join r_location l1 on l1.location_cd = pol_location_cd
					 where m.create_dt > sysdate - {0}
					  and (l1.active_flg = 'N' or l1.active_flg is null)
					  union all
					  select m.cargo_move_id as pk_id, booking_no, serial_no, pod_location_cd, 'Invalid POD on Cargo Move'
					 from t_cargo_move m
					 left outer join r_location l1 on l1.location_cd = pod_location_cd
					 where m.create_dt > sysdate - {0}
					  and (l1.active_flg = 'N' or l1.active_flg is null)
					union all
					select ca.cargo_activity_id, booking_no, serial_no, orig_location_cd, 'Invalid Origin on Cargo Activity'
					 from t_cargo_activity ca
					 left outer join r_location l on l.location_cd = ca.orig_location_cd
					 left outer join t_cargo c on ca.cargo_id = c.cargo_id
					 left outer join t_booking b on c.booking_id = b.booking_id
					  where  ca.create_dt > sysdate - {0}
					  and (l.location_cd is null or l.active_flg = 'N')
					union all
					select ca.cargo_activity_id, booking_no, serial_no, dest_location_cd, 'Invalid Destination on Cargo Activity'
					 from t_cargo_activity ca
					 left outer join r_location l on l.location_cd = ca.dest_location_cd
					 left outer join t_cargo c on ca.cargo_id = c.cargo_id
					 left outer join t_booking b on c.booking_id = b.booking_id
					  where  ca.create_dt > sysdate - {0}
					  and (l.location_cd is null or l.active_flg = 'N')
					union all
					select vendor_move_id as pk_id, 'All' as booking_no, 'All' as serial_no, orig_location_cd as location_cd, 'Invalid Origin on Vendor Move' as error_msg
						from t_vendor_move vm
						 left outer join t_move m on m.move_id = vm.move_id
						 left outer join r_location l on l.location_cd = vm.orig_location_cd
					 where  vm.create_dt > sysdate - {0}
					   and (l.location_cd is null or l.active_flg = 'N')
					   and m.active_flg = 'Y'
					   and vm.active_flg = 'Y'
					union all
					select vendor_move_id as pk_id, 'All' as booking_no, 'All' as serial_no, dest_location_cd as location_cd, 'Invalid Destination on Vendor Move' as error_msg
						from t_vendor_move vm
						 left outer join t_move m on m.move_id = vm.move_id
						 left outer join r_location l on l.location_cd = vm.dest_location_cd
					 where  vm.create_dt > sysdate - {0}
					   and (l.location_cd is null or l.active_flg = 'N')
					   and m.active_flg = 'Y'
					   and vm.active_flg = 'Y'
							", iDays);

			DataTable dt = conn.GetDataTable(sql);
			return dt;
		}

		public static DataTable GetIAL304Out(string sDirection)
		{
			string sql = string.Format("select * from V_IAL_304_OUT t where east_or_west like '{0}'", sDirection);
			return Connection.GetDataTable(sql);
		}
		#endregion

		#region DropDowns
//        public static DataTable CurrentVoyageList()
//        {
//            return VoyageList(30);
//        }
//        public static DataTable FullVoyageList()
//        {
//            return VoyageList(700);
//        }
//        public static DataTable VoyageList(int iDays)
//        {
//            string sql = string.Format(@"
//				select v.*, voyage_cd || '-' || vessel_cd as voyagevessel
//				  from mv_voyage v
//				 where sail_dt > sysdate - {0}
//				  order by voyage_cd ", iDays);
//            return Connection.GetDataTable(sql);
//        }
		#endregion
	}
}
