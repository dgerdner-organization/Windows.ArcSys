using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using CS2010.Common;
using CS2010.ArcSys.Business;

namespace CS2010.ArcSys.Business
{
	public class ClsCommercialEDIQueries
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ArcSys"]; }
		}
		#endregion		// #region Connection Manager

		#region General Methods
		public static DataTable TradingPartnerCustomers(string sPartnerCd)
		{
			string sql = @"
				select tp.trading_partner_cd, tp.partner_dsc, outbound_isa_nbr,
				 tpc.customer_cd, c.customer_nm
				 from r_trading_partner tp
				  inner join r_trading_partner_customer tpc on tpc.trading_partner_cd = tp.trading_partner_cd
				  inner join r_customer c on tpc.customer_cd = c.customer_cd";
			DataTable dt = Connection.GetDataTable(sql);
			return dt;
		}

		public static DataTable TradingPartnerEdiConfig(string sPartnerCd)
		{
			string sql = @"
				select * from r_trading_partner_edi ";
			DataTable dt = Connection.GetDataTable(sql);
			return dt;
		}

		#endregion

		#region ITV Methods
		public static DataTable EDIDiagnostics()
		{
			string sql = "select * from v_edi_diagnostics ";
			DataTable dt = Connection.GetDataTable(sql);
			return dt;
		}

		public static DataTable ITVActivitySummary()
		{
			string sql = @"
					select tpc.trading_partner_cd, bl.booking_no, c.cargo_line_id, c.serial_no, bl.voyage_no,  bl.voyage_no, bl.vessel_cd,
					 f_count_activity(c.cargo_line_id, 'CO') as count_received,
					 f_count_activity(c.cargo_line_id, 'VD') as count_depart,
					 f_count_activity(c.cargo_line_id, 'VA') as count_arrive,
					  f_count_activity(c.cargo_line_id, 'CR') as count_released,
					  f_count_activity(c.cargo_line_id, 'UV') as count_discharged
					 from t_booking_line bl 
					  inner join t_cargo_line c
						on c.booking_line_id = bl.booking_line_id
					 inner join r_trading_partner_customer tpc
					   on bl.customer_cd = tpc.customer_cd ";

			return Connection.GetDataTable(sql);
		}

		public static DataTable ReadyToTransmitMsg(string sPartner)
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendFormat(@"
				select count(*) || ' ""' || activity_cd || '"" messages ready to be transmitted for ' || trading_partner_cd as msg
				 from t_itv
				 where trading_partner_cd = '{0}'
				  and isa_nbr is null
						and voyage_no not in
						(select voyage_no from t_edi_voyage_exclude
						  where trading_partner_cd = '{1}' and message_no = '315')
				  group by activity_cd, trading_partner_cd ", sPartner, sPartner);

			string sql = sb.ToString();
			DataTable dt = Connection.GetDataTable(sql);
			return dt;
		}

		public static DataTable DashboardArriveDepart(ClsConnection conn)
		{
            try
            {
			    DataTable dtLineArriveDepart = ClsCommercialEDIQueries.searchVesselArriveDepart("CAT", 6, 0, conn);
                if (dtLineArriveDepart == null) return null;
                if ((dtLineArriveDepart.Select("itv_count < unit_count").Count<DataRow>() == 0)) return null; 
                return dtLineArriveDepart.Select("itv_count < unit_count").CopyToDataTable(); 
            }
            catch 
            {
                return null;
            }
		}

		public static DataTable SearchCargo(EDIQueryParms parms, bool wDates)
		{
			string PartnerCd = parms.PartnerCd;
			string BookingNo = parms.BookingNo;
			string SerialNo = parms.SerialNo;
			string VoyageNo = parms.VoyageNo;
			string PCFN = parms.PCFN;
			string POLCd = parms.POLCd;
			string PODCd = parms.PODCd;

			List<DbParameter> p = new List<DbParameter>();

			StringBuilder sql = new StringBuilder();
			sql.AppendFormat(@"select b.*, c.*, tpc.* ");

			if (wDates)
			{
				sql.AppendFormat(@"
					,f_activity_dt(cargo_line_id, '@IG@') as iDate,
					f_activity_dt(cargo_line_id, 'W') as wDate,
					f_activity_dt(cargo_line_id, 'AE') as aeDate,
					f_activity_dt(cargo_line_id, 'VD') as vdDate,
					f_activity_dt(cargo_line_id, 'VA') as VADate,
					f_activity_dt(cargo_line_id, 'OA') as oaDate,
					f_activity_dt(cargo_line_id, 'UV') as uvDate,
					f_activity_dt(cargo_line_id, 'AV') as AVDate,
					f_activity_dt(cargo_line_id, 'X1') as X1Date ");

				if (PartnerCd == "CAT")
					sql = sql.Replace("@IG@", "CO");
				else
					sql = sql.Replace("@IG@", "I");
			}
			sql.AppendFormat(@"
					 from t_booking_line b
					  inner join t_cargo_line c on c.booking_line_id = b.booking_line_id
					  /*inner join t_cargo cc on cc.cargo_key = c.cargo_key*/
					  inner join r_trading_partner_customer tpc on tpc.customer_cd = b.customer_cd
				 where b.deleted_flg = 'N' ");

			if (!string.IsNullOrEmpty(PartnerCd))
				Connection.AppendLikeClause(sql, p, "AND", "tpc.trading_partner_cd", "@PARTCD", PartnerCd);
			if (!string.IsNullOrEmpty(BookingNo))
				Connection.AppendLikeClause(sql, p, "AND", "b.booking_no", "@BOOKNO", BookingNo);
			if (!string.IsNullOrEmpty(VoyageNo))
				Connection.AppendLikeClause(sql, p, "AND", "substr(b.voyage_no,1,5)", "@VOYAGENO", VoyageNo.Substring(0,5));
			if (!string.IsNullOrEmpty(SerialNo))
				Connection.AppendLikeClause(sql, p, "AND", "c.serial_no", "@SERIALNO", SerialNo);
			if (!string.IsNullOrEmpty(PCFN))
				Connection.AppendLikeClause(sql, p, "AND", "b.customer_ref", "@PCFN", PCFN);
			if (!string.IsNullOrEmpty(parms.POLCd))
				Connection.AppendLikeClause(sql, p, "AND", "b.pol_location_cd", "@POLCD", parms.POLCd);
			if (!string.IsNullOrEmpty(parms.PODCd))
				Connection.AppendLikeClause(sql, p, "AND", "b.pod_location_cd", "@PODCD", parms.PODCd);

			sql.AppendFormat(" order by b.booking_no, c.item_no, c.seq_no ");

			string s = sql.ToString();

			DataTable dt = Connection.GetDataTable(s, p.ToArray());
			return dt;
		}

		public static DataTable searchVesselArriveDepart(string sPartner, int iFrom, int iTo)
		{
			return searchVesselArriveDepart(sPartner, iFrom, iTo, Connection);
		}
		public static DataTable searchVesselArriveDepart(string sPartner, int iFrom, int iTo, ClsConnection conn)
		{
			string sql = string.Format(@"
				select * from (
				select arrive.voyage_cd as voyageno, 
				  vessel_cd,
				  'Arrive' as ArriveDepart, 
				  location_cd, 
				  arrive.terminal_cd,
				  min(arrival_dt) as voyagedate, 
				  actual_arrival_fl as actual_flg,
				 (select count(*)
				  from t_itv itv 
				  where substr(itv.voyage_no,1,5) = substr(arrive.voyage_cd,1,5)
				   and itv.activity_cd = 'VA'
				   and itv.location_cd = arrive.location_cd
				   and itv.trading_partner_cd = '{2}'
				   ) as itv_count,
           
					 (select count(*)
				  from v_booking_cargo_line bu
					inner join r_trading_partner_customer tpc on tpc.customer_cd = bu.customer_cd
						  and tpc.trading_partner_cd = '{2}'
				   where substr(bu.voyage_no,1,5) = substr(arrive.voyage_cd,1,5)
					and bu.pod_location_cd = arrive.location_cd
					and import_notes_txt is null
					) as unit_count  
            
				 from mv_voyage_route_detail arrive
				  inner join mv_voyage v on substr(v.voyage_cd,1,5) = substr(arrive.voyage_cd,1,5)
				 where (arrival_dt between sysdate - {0} and sysdate + {1})
				  and pol_pod = 'D'
				group by arrive.voyage_cd, vessel_cd, actual_arrival_fl, location_cd, terminal_cd

				union all
				select depart.voyage_cd, vessel_cd, 'Depart', 
				  location_cd, terminal_cd,
				  min(departure_dt), 
				  actual_departure_fl,
				 (select count(*)
				  from t_itv itv 
				  where substr(itv.voyage_no,1,5) = substr(depart.voyage_cd,1,5)
				   and itv.location_cd = depart.location_cd
				   and itv.activity_cd = 'VD'
					and itv.trading_partner_cd = '{2}'
					) as itv_count,
           
				  (select count(*)
					from  v_booking_cargo_line b 
						inner join r_trading_partner_customer tpc on tpc.customer_cd = b.customer_cd
														  and tpc.trading_partner_cd = '{2}'
					 where substr(b.voyage_no,1,5) = substr(depart.voyage_cd,1,5)
					  and b.pol_location_cd = depart.location_cd
						and import_notes_txt is null) as unit_count    
				 from mv_voyage_route_detail depart
				  inner join mv_voyage v on substr(v.voyage_cd,1,5) = substr(depart.voyage_cd,1,5)
				 where (departure_dt between sysdate - {0} and sysdate + {1})
				  and pol_pod = 'L'
				 group by depart.voyage_cd, vessel_cd, location_cd, actual_departure_fl, terminal_cd 
					)
				where unit_count > 0",
					iFrom, iTo, sPartner);

			DataTable dt = conn.GetDataTable(sql);
			return dt;
		}

		public static DataTable SearchEDIHistory(EDIQueryParms parms)
		{
			string PartnerCd = parms.PartnerCd;
			string BookingNo = parms.BookingNo;
			string SerialNo = parms.SerialNo;
			string VoyageNo = parms.VoyageNo;

			List<DbParameter> p = new List<DbParameter>();

			StringBuilder sql = new StringBuilder();
			sql.AppendFormat(@"
					  select log.*,
						p.partner_dsc,
						itv.*,
						itv.create_dt as itv_create_dt,
						itv.create_user as itv_create_user,
						a.activity_dsc,
						tpe.*,
						bl.booking_line_id
					from t_itv itv
					left outer join t_edi_outbound_log log on log.trading_partner_cd = itv.trading_partner_cd
														and log.isa_nbr = itv.isa_nbr
					inner join r_trading_partner p on p.trading_partner_cd = itv.trading_partner_cd
					left outer join r_trading_partner_edi tpe on tpe.trading_partner_cd = p.trading_partner_cd and
										tpe.map_nm = log.map_nm
					left outer join r_itv_activity_code a on a.activity_cd = itv.activity_cd
					inner join t_booking_line bl on bl.booking_no = itv.booking_no
					inner join t_cargo_line c on c.cargo_key = itv.cargo_key
					/*inner join r_user_trading_partner utp on utp.trading_partner_cd = p.trading_partner_cd
                    and utp.user_login = user*/
					   where 1 = 1
					 ");

			if (!string.IsNullOrEmpty(PartnerCd))
				Connection.AppendLikeClause(sql, p, "AND", "itv.trading_partner_cd", "@PARTCD", PartnerCd);
			if (!string.IsNullOrEmpty(BookingNo))
				Connection.AppendLikeClause(sql, p, "AND", "itv.booking_no", "@BOOKNO", BookingNo);
			if (!string.IsNullOrEmpty(parms.ActivityCd))
				Connection.AppendLikeClause(sql, p, "AND", "itv.activity_cd", "@ACTCD", parms.ActivityCd);
			if (!string.IsNullOrEmpty(parms.POLCd))
				Connection.AppendLikeClause(sql, p, "AND", "bl.pol_location_cd", "@POLCD", parms.POLCd);
			if (!string.IsNullOrEmpty(parms.PODCd))
				Connection.AppendLikeClause(sql, p, "AND", "bl.pod_location_cd", "@PODCD", parms.PODCd);


			string s = sql.ToString();

			DataTable dt = Connection.GetDataTable(s, p.ToArray());
			return dt;

		}

		public static DataTable SearchITVHistory(EDIQueryParms parms)
		{
			//
			// This gets all ITV data, whether or not it's been
			// transmitted.
			//
			string PartnerCd = parms.PartnerCd;
			string BookingNo = parms.BookingNo;
			string SerialNo = parms.SerialNo;
			string VoyageNo = parms.VoyageNo;;
			if (!string.IsNullOrEmpty(parms.VoyageNo))
				VoyageNo = parms.VoyageNo.Substring(0, 5);
			string PCFN = parms.PCFN;
			long? iDays = parms.iDays;


			List<DbParameter> p = new List<DbParameter>();
			StringBuilder sql = new StringBuilder();
//            sql.AppendFormat(@"
//			select itv.itv_id, itv.trading_partner_cd,
//				   itv.activity_cd,
//				   a.activity_dsc,
//				   itv.activity_dt,
//				   itv.location_cd as activity_location_cd,
//				   itv.create_dt as itv_create_dt,
//				   itv.create_user as itv_create_user,
//				   itv.isa_nbr,
//				   loc.location_dsc,
//				   replace(log.file_nm,'ftpout','archive') as file_nm,
//				   log.map_nm,
//				   bl.*,
//				   cl.*
//			 from t_itv itv
//				  left outer join r_itv_activity_code a on a.activity_cd = itv.activity_cd
//				  inner join t_booking_line bl on bl.booking_no = itv.booking_no
//				  inner join t_cargo_line cl on itv.cargo_line_id = cl.cargo_line_id
//				  left outer join r_location loc on loc.location_cd = itv.location_cd
//				  left outer join t_edi_outbound_log log on log.trading_partner_cd = itv.trading_partner_cd
//                                                        and log.isa_nbr = itv.isa_nbr
//				  inner join r_user_trading_partner utp on utp.trading_partner_cd = itv.trading_partner_cd
//					and utp.user_login = user
//			 where 1 = 1 ");

			sql.AppendFormat(@"
				select *
				 from
				 (
				   select distinct itv.itv_id, itv.trading_partner_cd,
						   itv.activity_cd,
						   a.activity_dsc,
						   itv.activity_dt,
						   itv.location_cd as activity_location_cd,
						   itv.create_dt as itv_create_dt,
						   itv.create_user as itv_create_user,
						   itv.isa_nbr,
						   loc.location_dsc,
						   log.file_nm,
						   log.map_nm,
						   bl.vessel_cd, bl.voyage_no, bl.move_type_cd, bl.plor_location_cd, bl.pol_location_cd, bl.pod_location_cd, bl.plod_location_cd, cl.cargo_type_cd, pod_eta,
						   item_no, seq_no, cargo_dsc, serial_no, booking_no, cl.bol_no, pol_ets
					   from t_itv itv
						  left outer join r_itv_activity_code a on a.activity_cd = itv.activity_cd
						  inner join t_booking_line bl on bl.booking_no = itv.booking_no
						  inner join t_cargo_line cl on itv.cargo_line_id = cl.cargo_line_id
						  left outer join r_location loc on loc.location_cd = itv.location_cd
						  left outer join t_edi_outbound_log log on log.trading_partner_cd = itv.trading_partner_cd
																		and log.isa_nbr = itv.isa_nbr
						  inner join r_user_trading_partner utp on utp.trading_partner_cd = itv.trading_partner_cd
						  and utp.user_login = user
						where itv.activity_dt > sysdate - {0}
						  and itv.trading_partner_cd = '{1}'
				   union all
				   select 0 as itv_id, bol.trading_partner_cd, 'OB' as activity_cd, 'Bill of Lading' as activity_dsc, bol.modify_dt as activity_dt, 
					  bl.pol_location_cd as activity_location_cd, bol.create_dt as itv_create_dt, bol.create_user as itv_create_user,
						bol.isa_nbr, loc.location_dsc as location_dsc, replace(log.file_nm, 'ftpout', 'archive') as file_nm, log.map_nm,
						   bl.vessel_cd, bl.voyage_no, bl.move_type_cd, bl.plor_location_cd, bl.pol_location_cd, bl.pod_location_cd, bl.plod_location_cd, cl.cargo_type_cd, pod_eta,
						   0 as item_no, 0 as seq_no, '' as cargo_dsc, count(serial_no)  || ' items' as serial_no, booking_no, bol.bol_no, pol_ets
						from t_edi_outbound_bol bol
						 inner join t_edi_outbound_log log
						  on bol.isa_nbr = log.isa_nbr and bol.trading_partner_cd = log.trading_partner_cd
						 inner join t_cargo_line cl on cl.bol_no = bol.bol_no     
						 inner join t_booking_line bl on cl.booking_line_id = bl.booking_line_id     
					     inner join r_location loc on loc.location_cd = bl.pol_location_cd
					  where bol.modify_dt > sysdate - {0}
                        and bol.trading_partner_cd = '{1}'
						group by bol.trading_partner_cd,  bol.modify_dt, bol.create_dt, bol.create_user,
						bol.isa_nbr, file_nm, log.map_nm, bl.vessel_cd, bl.voyage_no, bl.move_type_cd, 
						bl.plor_location_cd, bl.pol_location_cd, bl.pod_location_cd, bl.plod_location_cd, cl.cargo_type_cd, pod_eta,
						booking_no, bol.bol_no, pol_ets, loc.location_dsc
				)
				where activity_dt > sysdate - 360", iDays, PartnerCd);

			if (!string.IsNullOrEmpty(PartnerCd))
				Connection.AppendLikeClause(sql, p, "AND", "trading_partner_cd", "@PARTCD", PartnerCd);
			if (!string.IsNullOrEmpty(BookingNo))
				Connection.AppendLikeClause(sql, p, "AND", "booking_no", "@BOOKNO", BookingNo);
			if (!string.IsNullOrEmpty(VoyageNo))
				Connection.AppendLikeClause(sql, p, "AND", "substr(voyage_no,1,5)", "@VOYAGENO", VoyageNo);
			if (!string.IsNullOrEmpty(SerialNo))
				Connection.AppendLikeClause(sql, p, "AND", "serial_no", "@SERIALNO", SerialNo);
			if (!string.IsNullOrEmpty(PCFN))
				Connection.AppendLikeClause(sql, p, "AND", "customer_ref", "@PCFN", PCFN);
			if (!string.IsNullOrEmpty(parms.ActivityCd))
				Connection.AppendLikeClause(sql, p, "AND", "activity_cd", "@ACTCD", parms.ActivityCd);
			if (!string.IsNullOrEmpty(parms.POLCd))
				Connection.AppendLikeClause(sql, p, "AND", "pol_location_cd", "@POLCD", parms.POLCd);
			if (!string.IsNullOrEmpty(parms.PODCd))
				Connection.AppendLikeClause(sql, p, "AND", "pod_location_cd", "@PODCD", parms.PODCd);


			sql.AppendFormat(" order by booking_no, serial_no, activity_dt ");
			string s = sql.ToString();

			DataTable dt = Connection.GetDataTable(s, p.ToArray());

			//  Add Bill of Lading to results
			//
			return dt;
		}

		public static DataTable ITVUntransmitted()
		{
			// Returns a list of ITV that has not been transmitted.  This
			// suggests that the Mercator Map failed.
			//
			string sql = @"
				select * from t_itv i
				 inner join r_trading_partner tp on i.trading_partner_cd = tp.trading_partner_cd
												and tp.active_flg = 'Y'
				 where isa_nbr is null
				  and create_dt < sysdate - .1
			      and create_dt > sysdate - 30
				  and tp.trading_partner_cd = 'CAT'
				  and voyage_no not in
					(select voyage_no from t_edi_voyage_exclude x
					  where x.trading_partner_cd = tp.active_flg and message_no = '315')";
			DataTable dt = Connection.GetDataTable(sql);
			return dt;
		}

		public static DataTable EDISummary()
		{
			string sql = string.Format(@"
				select * from v_edi_summary ");
			DataTable dt = Connection.GetDataTable(sql);
			return dt;
		}
		#endregion

		#region 323 Methods
		public static DataTable ReadyToTransmit323()
		{
			string sql = "select distinct voyage_cd from v_cat_323_totransmit ";
			DataTable dt = Connection.GetDataTable(sql);
			return dt;
		}
		#endregion

		#region structure for queries
		public struct EDIQueryParms
		{
			public string PartnerCd;
			public string BookingNo;
			public string VoyageNo;
			public string SerialNo;
			public string PCFN;
			public string ActivityCd;
			public string ArriveDepartCd;
			public string POLCd;
			public string PODCd;
			public long? iDays;
			public string MoveTypeCd;
			public string PLODCd;
			public string VesselCd;
		}
		#endregion
	}
}
