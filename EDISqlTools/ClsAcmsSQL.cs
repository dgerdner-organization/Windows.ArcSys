using System;
using System.Collections.Generic;
using System.Text;
using CS2010.Common;
using System.Data;
using System.Data.Common;

namespace ASL.ARC.EDISQLTools
{
	static public class ClsAcmsSQL
	{
		#region Connections
		private static ClsConnection Connection
		{
			get
			{
				//if (ClsConMgr.Manager["ACMS"] == null)
				//{
				//    ConnectToACMS();
				//}
				return ClsConMgr.Manager["ACMS"];
			}
		}

		private static bool ConnectToACMS()
		{
			string sConnect = "Data Source=ACMSP;Persist Security Info=True;User ID=ediuser;;password=montvale123;";

            /* Temporary while testing Jan 2020 */
            //sConnect = "Data Source=ACMST;Persist Security Info=True;User ID=ediuser;;password=tacoma;";
			ClsConnection acms = new ClsConnection(sConnect, "Oracle.DataAccess.Client");
			acms.DbConnectionKey = "ACMS";
			ClsConMgr.Manager.AddConnection(acms);
			return true;
		}
		#endregion

		#region Fields and Properties
		private static string _ErrorMsg;
		public static string ErrorMsg
		{
			get { return _ErrorMsg; }
			set { _ErrorMsg = value; }
		}
		#endregion

		#region Helper Methods
		private static string CleanSerialNo(string serialno)
		{
			//  Removes extraneous and invalid data from a serial#
			serialno = serialno.Replace("'", "");
			serialno = serialno.Replace("+", "");
			serialno = serialno.Replace("-", "");
			serialno = serialno.Replace("_", "");
			serialno = serialno.Trim();
			return serialno;
		}
		#endregion

		#region Misc Selects
		public static DataTable SelectITVHistory(string pcfn, string tcn)
		{
			/*  OBSOLTE -- now use SearchITVHistory */

			StringBuilder sql = new StringBuilder();
			sql.AppendFormat(@"
				select itv.activity_id, itv.activity_code, a.activity_code || ' - ' || activity_dsc as activity_dsc,itv.booking_id, itv.voyage_no, 
				confirm_cd, tcn, trans_ctl_no, activity_dt, u.partner_request_cd,
				  u.poe_location_cd, u.pod_location_cd, adj_rdd_dt, shipper_name, booker_name,
				  activity_user
				 from t_booking_itv itv
				 inner join t_booking_unit u on itv.booking_id = u.booking_id 
					    and nvl(itv.booking_sub,' ') =  nvl(u.booking_id_sub,' ') 
					   and itv.item_no = u.item_no
				 inner join t_booking b on b.partner_request_cd = u.partner_request_cd   
				 inner join r_activity_code a on a.activity_code = itv.activity_code
				 where u.partner_request_cd = '{0}'
                   and u.tcn = '{1}'",
				 pcfn, tcn);
			DataTable dt = Connection.GetDataTable(sql.ToString());
			return dt;
		}

		public static DataTable SearchITVHistory(
				string sVoyage, string sBooking, string sTCN, 
				string sActivityCd, bool bUnsent,string sPCFN, 
				string sVoyDoc, string sPOL, string sPOD, string sISA)
		{
			StringBuilder sql = new StringBuilder();
			
			sql.AppendFormat(@"
				select itv.activity_id, u.partner_cd, u.item_no, activity_code, a.activity_code || ' - ' || activity_dsc as activity_dsc, itv.booking_id, itv.voyage_no, confirm_cd, 
				 tcn, trans_ctl_no, activity_dt, u.partner_request_cd,
				  u.poe_location_cd, u.pod_location_cd, adj_rdd_dt, shipper_name, booker_name,
				  activity_user, itv.voyage_no, u.vessel_cd, itv.booking_sub,
					b.location_plor_cd as plor, b.location_plod_cd as plod,
					itv.location_cd as activity_location_cd, trans_dt as trx_dt,
					b.shipper_city, b.rcvr_city,
					ts.final_booking_no || ' ' ||
					ts.voyage_no || ' ' ||
					ts.pol_location_cd || '-' ||
					ts.pod_location_cd as transInfo,
					itv.create_dt, itv.modify_dt, itv.modify_user,
					 round((create_dt-activity_dt) * 24,0) as create_delay,
					round((trans_dt-activity_dt) * 24 ,0) as transmit_delay
				 from t_booking_itv itv
				 inner join t_booking_unit u on itv.booking_id = u.booking_id 
					  /* and trim(nvl(itv.booking_sub,'A')) = trim(nvl(u.booking_id_sub,'A'))*/
					   and itv.item_no = u.item_no
				 inner join t_booking b on b.partner_request_cd = u.partner_request_cd   
				  inner join r_activity_code a on trim(a.activity_code) = trim(itv.activity_code)
				 left outer join t_edi_activity_ftp f on f.trans_ctl_no = itv.trans_ctl_no
				   and f.trading_partner_cd = u.partner_cd
				   and f.edi_type like '315OUT%'
				 left outer join t_transshipment ts on ts.booking_no = u.booking_id
				 where u.booking_id like '{0}'
                   and u.tcn like '{1}'
				   and u.voyage_no like '{2}'
				   and itv.activity_code like '{3}'
				   and u.partner_request_cd like '{4}'
				   and u.mil_voyage_no like '{5}'
				   and u.poe_location_cd like '{6}'
				   and u.pod_location_cd like '{7}'",
				 sBooking, sTCN, sVoyage, sActivityCd, sPCFN, sVoyDoc, sPOL, sPOD);

			if( bUnsent )
			{
				sql.AppendFormat(@" and itv.confirm_cd = 'N' ");
			}
			if( !string.IsNullOrEmpty(sISA) && sISA != "%")
			{
				sql.AppendFormat(@" and itv.trans_ctl_no = {0} ", sISA);
			}
			DataTable dt = Connection.GetDataTable(sql.ToString());
			return dt;
		}

		public static DataTable SearchITVHistory(
				string sVoyage, string sBooking, string sTCN,
				string sActivityCd, bool bUnsent, string sPCFN,
				string sVoyDoc, string sPOL, string sPOD, string sISA,
				bool bIncludeDRAP, bool bJustLate, DateRange drActivity)
		{
			StringBuilder sql = new StringBuilder();

			sql.AppendFormat(@"
				select itv.activity_id, u.partner_cd, u.item_no, activity_code, a.activity_code || ' - ' || activity_dsc as activity_dsc, itv.booking_id, itv.voyage_no, confirm_cd, 
				 tcn, trans_ctl_no, activity_dt, u.partner_request_cd,
				  u.poe_location_cd, u.pod_location_cd, adj_rdd_dt, shipper_name, booker_name,
				  activity_user, itv.voyage_no, u.vessel_cd, itv.booking_sub,
					b.location_plor_cd as plor, b.location_plod_cd as plod,
					itv.location_cd as activity_location_cd, 
					case
						when i.create_dt is null then trans_dt 
						else i.create_dt
					end as trx_dt,
					b.shipper_city, b.rcvr_city,
					 case
						when ts.final_booking_no is null then ''
						when ts.final_booking_no = u.booking_id then 'Final Leg'
				         else 'First Leg' end
							as leg_type,
					ts.final_booking_no || ' ' ||
					ts.voyage_no || ' ' ||
					ts.pol_location_cd || '-' ||
					ts.pod_location_cd as transInfo,
					itv.create_dt, itv.modify_dt, itv.modify_user,
					trunc(itv.create_dt) - trunc(activity_dt) as create_delay,
					case
						when i.create_dt is null then
							 trunc(trans_dt)-trunc(activity_dt)
						else trunc(i.create_dt) - trunc(activity_dt)
					end as transmit_delay,
					itv.notes, 'N' as edit_flg,
					f.table_dsc,
					f.edi_type,
					itv.sub_tcn as original_tcn
				 from t_booking_itv itv
				 inner join t_booking_unit u on itv.booking_id = u.booking_id 
					  /* and trim(nvl(itv.booking_sub,'A')) = trim(nvl(u.booking_id_sub,'A'))*/
					   and itv.sub_tcn = u.tcn
				 inner join t_booking b on b.partner_request_cd = u.partner_request_cd   
				  inner join r_activity_code a on trim(a.activity_code) = trim(itv.activity_code)
				 left outer join t_edi_activity_ftp f on f.trans_ctl_no = itv.trans_ctl_no
				   and f.trading_partner_cd = u.partner_cd
				   and f.edi_type like '315OUT%'
				   and f.in_out = 'O'
				 left outer join t_transshipment ts on ts.booking_no = u.booking_id
				 left outer join t_isa<DBLINK>arcsys i on i.isa_no = trans_ctl_no
											   and i.trading_partner_cd = 'SDDC'
											   and i.in_out = 'O'
											   and i.edi_type = '315'
				 where u.booking_id like '{0}'
                   and (u.tcn like '{1}' or itv.sub_tcn like '{1}')
				   and u.voyage_no like '{2}'
				   and itv.activity_code like '{3}'
				   and u.partner_request_cd like '{4}'
				   and u.mil_voyage_no like '{5}'
				   and u.poe_location_cd like '{6}'
				   and u.pod_location_cd like '{7}'",
				 sBooking, sTCN, sVoyage, sActivityCd, sPCFN, sVoyDoc, sPOL, sPOD);

			if (bUnsent)
			{
				sql.AppendFormat(@" and itv.confirm_cd = 'N' ");
			}
			if (!string.IsNullOrEmpty(sISA) && sISA != "%")
			{
				sql.AppendFormat(@" and itv.trans_ctl_no = {0} ", sISA);
			}
			if (!bIncludeDRAP)
			{
				sql.AppendFormat(@" and itv.activity_code not in ('SD','BD','HR','HG','A1','A2') ");
			}
			if (bJustLate)
			{
				sql.AppendFormat(@" and trunc(trans_dt) - trunc(activity_dt) > 1 ");
			}
			List<DbParameter> p = new List<DbParameter>();

			if (!drActivity.IsEmpty)
				Connection.AppendDateClause(sql, p, "AND", "activity_dt", "@FROMDT", "@TODT", drActivity);

			string s = sql.ToString();
			DataTable dt = Connection.GetDataTable(s, p.ToArray());
			return dt;
		}
		public static DataTable SelectLocations()
		{
			string sql = @" select location_cd, location_cd || ' - ' || location_dsc as descr,
						location_dsc from r_location order by location_cd ";
			DataTable dt = Connection.GetDataTable(sql);
			return dt;
		}

		public static DataTable SelectLocations(string sBookingNo)
		{
			StringBuilder sql = new StringBuilder();
//            sql.AppendFormat(@"
//				select l.location_cd, l.location_cd || ' - ' || l.location_dsc as descr 
//				 from r_location l
//				 inner join mv_voyage_route_detail vd on vd.location_cd = l.location_cd
//				 inner join t_booking_request r on vd.voyage_cd = r.voyage_no
//				where r.booking_id = '{0}' 
//				 order by l.location_cd ", sBookingNo);
			sql.AppendFormat(@"
			  select distinct 2 as seq_no, l.location_cd, l.location_cd || ' - ' || l.location_dsc as descr 
					 from r_location l
					 inner join mv_voyage_route_detail vd on vd.location_cd = l.location_cd
					 inner join t_booking_request r on vd.voyage_cd = r.voyage_no
					where r.booking_id = '{0}' 
					 union all
			select  1 as seq_no, location_plor_cd, location_plor_cd || ' - ' || l.location_dsc
			  from t_booking b
			   inner join r_location l on b.location_plor_cd = l.location_cd
			   where b.booking_id = '{0}'          
				 union all
			select 3 as seq_no, location_plod_cd, location_plod_cd || ' - ' || l.location_dsc
			  from t_booking b
			   inner join r_location l on b.location_plod_cd = l.location_cd
			   where b.booking_id = '{0}'        
			   order by seq_no ", sBookingNo);


			DataTable dt = Connection.GetDataTable(sql.ToString());
			return dt;
		}
		public static DataTable SelectLocationsByVoyage(string sVoyageNo)
		{
			StringBuilder sql = new StringBuilder();
			sql.AppendFormat(@"
				select l.location_cd, l.location_cd || ' - ' || l.location_dsc as descr 
				 from r_location l
				 inner join mv_voyage_route_detail vd on vd.location_cd = l.location_cd
				where vd.voyage_cd = '{0}' 
				 order by l.location_cd ", sVoyageNo);
			DataTable dt = Connection.GetDataTable(sql.ToString());
			return dt;
		}


		public static DataTable SelectActivityCodes()
		{
			string sql = @" select activity_code, 
				activity_code || ' - ' || activity_dsc as activity_dsc
			from r_activity_code 
			  order by activity_code";
			DataTable dt = Connection.GetDataTable(sql);
			return dt;
		}


		public static DataTable SelectACMSStatusCodes()
		{
			string sql = @" select acms_status_cd, acms_status_dsc
			from r_acms_status
			  order by acms_status_cd";
			DataTable dt = Connection.GetDataTable(sql);
			return dt;
		}

		public static DataTable SelectTerminals(string sPort)
		{
			StringBuilder sql = new StringBuilder();
			sql.AppendFormat(@" select terminal_cd, terminal_cd || ' - ' || terminal_dsc as descr 
				  from r_location_terminal
				   where location_cd = '{0}'
				   order by terminal_cd ", sPort);
			DataTable dt = Connection.GetDataTable(sql.ToString());
			return dt;
		}

		public static string GetVoyDoc(string sPCFN)
		{
			string s;
			string sql = string.Format(@"
 
				select max(v.military_voyage_cd) from t_booking b
				 left outer join mv_voyage v
				   on v.voyage_cd = b.voyage_no 
				 where partner_request_cd like '{0}' ",
					sPCFN);

			object o = Connection.GetScalar(sql);
			s = o.ToString();

			return s;
		}

		public static string GetVesselName(string sVesselCd)
		{
			string s;
			string sql = string.Format(@"
 
				select vessel_dsc from r_vessel
				 where vessel_cd = '{0}' ",
					sVesselCd);

			object o = Connection.GetScalar(sql);
			s = o.ToString();

			return s;
		}
		public static DataTable GetBookingParty(string sPCFN, string sType)
		{
			string sql = string.Format(@"
				select * from t_booking_party
				 where partner_request_cd = '{0}'
				     and party_type_cd = '{1}'", sPCFN, sType);

			return Connection.GetDataTable(sql);
		}

		public static DataTable GetPartners()
		{
			return GetPartners(false);
		}
		public static DataTable GetPartners(bool bWithAll)
		{
			string sql = "select * from r_trading_partner ";
			sql = sql + "order by default_fl desc ";
			return Connection.GetDataTable(sql);
		}
		#endregion

		#region Get Individual ACMS Data (ad-hoc)
		public static long ActivityCount(string sBooking, string sVoyageno, string sSerialNo, string sCode)
		{
			sSerialNo = CleanSerialNo(sSerialNo);
			StringBuilder sb = new StringBuilder();
			sb.AppendFormat(@"
					select count(*)
					  from t_booking_itv itv
					  inner join t_booking_unit bu on bu.booking_id = itv.booking_id
												  and bu.booking_id_sub = itv.booking_sub
												  and bu.item_no = itv.item_no
					 and itv.booking_id like '{0}%'     
					 and tcn = '{1}'                       
					 and trim(activity_code) = '{2}'",
					 sBooking, sSerialNo, sCode);
			string i = Connection.GetScalar(sb.ToString()).ToString(); 
			if( i == null )
				i = "0";

			if( i == "0" )
			{
				i = ActivityCount(sVoyageno, sSerialNo, sCode);
			}
			return ClsConvert.ToInt32(i);
		}

		public static string ActivityCount(string sVoyageno, string sSerialNo, string sCode)
		{

			sSerialNo = CleanSerialNo(sSerialNo);

			StringBuilder sb = new StringBuilder();
			sb.AppendFormat(@"
					select count(*)
					  from t_booking_itv itv
					  inner join t_booking_unit bu on bu.booking_id = itv.booking_id
											/*and nvl(bu.booking_id_sub,' ') = nvl(itv.booking_sub,' ')*/
											and bu.item_no = itv.item_no
					 where tcn = '{1}'                       
					 and activity_dt > sysdate - 1000
					 /*and activity_id < 1020833*/
					 and substr(itv.voyage_no,0,5) = '{0}'
					 and trim(activity_code) = '{2}'
					 and sub_tcn is null",
					 sVoyageno, sSerialNo, sCode);
			string i = Connection.GetScalar(sb.ToString()).ToString();
			if( i == null )
				return "0";
			return i;
		}

		public static ACMSBookingData GetACMSDataBooking(string sBookingNo, string sSerialNo)
		{
			ErrorMsg = "";
			ACMSBookingData acms = new ACMSBookingData();
			try
			{
				StringBuilder sb = new StringBuilder();
				sSerialNo = CleanSerialNo(sSerialNo);
				sb.AppendFormat(@"
				select b.adj_rdd_dt,
					 b.partner_request_cd, 
					 bu.booking_id,
					 bu.booking_id_sub,
					 bu.voyage_no,
					 bu.item_no,
					 bu.poe_location_cd,
					 bu.poe_terminal_cd,
					 ts.pod_location_cd,
					 ts.pod_terminal_cd,
					 f_get_avss_atd_dt(substr(bu.voyage_no,0,5), bu.poe_terminal_cd) as depart_dt,
				     f_get_avss_ata_dt(substr(ts.voyage_no,0,5), ts.pod_terminal_cd) as arrive_dt,					 rdd_dt
				  from t_transshipment ts
				   inner join t_booking_unit bu on bu.booking_id = ts.booking_no
				   inner join t_booking b on b.partner_cd = bu.partner_cd
					 and b.partner_request_cd = bu.partner_request_cd
				  where ts.final_booking_no = '{0}'
					and bu.tcn = '{1}'", sBookingNo, sSerialNo
				);

				DataTable dt = Connection.GetDataTable(sb.ToString());
				if( dt.Rows.Count > 0 )
				{
					acms.sBooking = dt.Rows[0]["booking_id"].ToString();
					acms.sBookingSub = dt.Rows[0]["booking_id_sub"].ToString();
					acms.sPCFN = dt.Rows[0]["partner_request_cd"].ToString();
					string sRDD = dt.Rows[0]["adj_rdd_dt"].ToString();
					acms.dtRDD = Convert.ToDateTime(sRDD);
					acms.sVoyageNo = dt.Rows[0]["voyage_no"].ToString();
					acms.sPODLocation = dt.Rows[0]["pod_location_cd"].ToString();
					acms.sPODTerminal = dt.Rows[0]["pod_terminal_cd"].ToString();
					acms.sPOELocation = dt.Rows[0]["poe_location_cd"].ToString();
					acms.sPOETerminal = dt.Rows[0]["poe_terminal_cd"].ToString();
					acms.lItemNo = ClsConvert.ToInt32(dt.Rows[0]["item_no"].ToString());
					string sArriveDt = dt.Rows[0]["arrive_dt"].ToString();
					string sDepartDt = dt.Rows[0]["depart_dt"].ToString();
					//acms.dtArriveDt = ClsConvert.ToDateTime(sArriveDt);
					if( !string.IsNullOrEmpty(sDepartDt) )
					{
						acms.dtDepartureDt = ClsConvert.ToDateTime(sDepartDt);
					}
					if( !string.IsNullOrEmpty(sArriveDt) )
					{
						acms.dtArriveDt = ClsConvert.ToDateTime(sArriveDt);
					}

				}
				return acms;
			}
			catch( Exception ex )
			{
				ErrorMsg = string.Format("Error gathering ACMS data from {0} {1} {2}",
					sBookingNo, sSerialNo, ex.Message);
				ClsErrorHandler.LogException(ex);
				return new ACMSBookingData();
			}

		}
		public static DataTable Get304s()
		{
			string sql = string.Format(@"
				select * from V_304_OUTPUT_WWL ");
			return Connection.GetDataTable(sql);
		}

		public static ACMSBookingData GetACMSData(string sVoyageno, string sSerialNo)
		{
			ErrorMsg = "";
			try
			{
				StringBuilder sb = new StringBuilder();


				sSerialNo = CleanSerialNo(sSerialNo);

				sb.AppendFormat(@"
				select b.adj_rdd_dt,
					   b.partner_request_cd, 
					   bu.booking_id,
					   bu.booking_id_sub,
					   bu.voyage_no,
					   bu.item_no,
                       bu.poe_location_cd,
					   bu.poe_terminal_cd,
                       bu.pod_location_cd,
					   bu.pod_terminal_cd,
 					   f_get_avss_atd_dt(substr(bu.voyage_no,0,5), bu.poe_terminal_cd) as depart_dt,
					   f_get_avss_ata_dt(substr(bu.voyage_no,0,5), bu.pod_terminal_cd) as arrive_dt,
					   rdd_dt
				  from t_booking_unit bu
					inner join t_booking b
					 on b.partner_cd = bu.partner_cd
					 and b.partner_request_cd = bu.partner_request_cd
					 and rdd_dt > sysdate - 900
				  where tcn = '{0}'
				   and substr(bu.voyage_no,0,5) like '{1}'
                   order by rdd_dt desc",
					  sSerialNo,
					  sVoyageno);
				DataTable dt = Connection.GetDataTable(sb.ToString());
				ACMSBookingData acms = new ACMSBookingData();
				if( dt.Rows.Count > 0 )
				{
					acms.sBooking = dt.Rows[0]["booking_id"].ToString();
					acms.sBookingSub = dt.Rows[0]["booking_id_sub"].ToString();
					acms.sPCFN = dt.Rows[0]["partner_request_cd"].ToString();
					string sRDD = dt.Rows[0]["adj_rdd_dt"].ToString();
					acms.dtRDD = Convert.ToDateTime(sRDD);
					acms.sVoyageNo = dt.Rows[0]["voyage_no"].ToString();
					acms.sPODLocation = dt.Rows[0]["pod_location_cd"].ToString();
					acms.sPODTerminal = dt.Rows[0]["pod_terminal_cd"].ToString();
					acms.sPOELocation = dt.Rows[0]["poe_location_cd"].ToString();
					acms.sPOETerminal = dt.Rows[0]["poe_terminal_cd"].ToString();
					acms.lItemNo = ClsConvert.ToInt32(dt.Rows[0]["item_no"].ToString());
					string sArriveDt = dt.Rows[0]["arrive_dt"].ToString();
					string sDepartDt = dt.Rows[0]["depart_dt"].ToString();
					//acms.dtArriveDt = ClsConvert.ToDateTime(sArriveDt);
					if( !string.IsNullOrEmpty(sDepartDt) )
					{
						acms.dtDepartureDt = ClsConvert.ToDateTime(sDepartDt);
					}
					if( !string.IsNullOrEmpty(sArriveDt) )
					{
						acms.dtArriveDt = ClsConvert.ToDateTime(sArriveDt);
					}

				}
				return acms;
			}
			catch( Exception ex )
			{
				ErrorMsg = string.Format("Error gathering ACMS data from {0} {1} {2}",
					sVoyageno, sSerialNo, ex.Message);
				return new ACMSBookingData();
			}
		}

		public static DateTime? GetRDD(string sSerialNo)
		{
			sSerialNo = CleanSerialNo(sSerialNo);
			StringBuilder sb = new StringBuilder();
			sb.AppendFormat(@"
				select b.adj_rdd_dt
				  from t_booking_unit bu
					inner join t_booking b
					 on b.partner_cd = bu.partner_cd
					 and b.partner_request_cd = bu.partner_request_cd
				  where tcn like '{0}%'
				   and b.adj_rdd_dt > sysdate - 90",
				  sSerialNo);
			object oRDD = Connection.GetScalar(sb.ToString());
			DateTime? dtRDD = (DateTime?)oRDD;
			return dtRDD;
		}

		public static long GetNextActivityID()
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendFormat(@"");
			return 1;
			
		}
		#endregion

		#region ACMS Sub Cargo Stuff

		public static long ActivitySubCount(string sBooking, string sVoyageno, string sSerialNo, string sCode)
		{
			sSerialNo = CleanSerialNo(sSerialNo);
			StringBuilder sb = new StringBuilder();
			sb.AppendFormat(@"
					select count(*)
					  from t_booking_itv itv
					  inner join t_booking_unit bu on bu.booking_id = itv.booking_id
												  and bu.booking_id_sub = itv.booking_sub
												  and bu.item_no = itv.item_no
					 and itv.booking_id like '{0}%'     
					 and sub_tcn = '{1}'                       
					 and trim(activity_code) = '{2}'",
					 sBooking, sSerialNo, sCode);
			string i = Connection.GetScalar(sb.ToString()).ToString();
			if( i == null )
				i = "0";

			if( i == "0" )
			{
				i = ActivityCount(sVoyageno, sSerialNo, sCode);
			}
			return ClsConvert.ToInt32(i);
		}

		public static void CreateClone(string sPartnerCd, string sPCFN, string sItemNo, string sTCN)
		{
			string sql = string.Format(@"
					insert into t_booking_unit_sub
					   (partner_cd, partner_request_cd, item_no, tcn)
					values ('{0}', '{1}', {2}, '{3}') ",
				sPartnerCd, sPCFN, sItemNo, sTCN);

			Connection.RunSQL(sql);
		}

		public static void DeleteClone(string sPartnerCd, string sPCFN, string sItemNo, string sTCN)
		{
			string sql = string.Format(@"
					delete from t_booking_unit_sub
					  where partner_cd = '{0}'
                        and partner_request_cd = '{1}'
                        and item_no = {2}
                        and tcn = '{3}' ",
				sPartnerCd, sPCFN, sItemNo, sTCN);

			Connection.RunSQL(sql);
		}

		public static void UpdateClone(string sPartnerCd, string sPCFN, string sItemNo, string sOldTCN, string sNewTCN)
		{
			string sql = string.Format(@"
				  update t_booking_unit_sub
                    set tcn = '{4}'
				   where partner_cd = '{0}'
                     and partner_request_cd = '{1}'
				     and item_no = {2}
                     and tcn = '{3}' ",
				sPartnerCd, sPCFN, sItemNo, sOldTCN, sNewTCN);

			Connection.RunSQL(sql);
		}
		public static DataTable GetCargoByBooking(string sBookingNo)
		{
			string sql = string.Format(@"
				select u.*,
				  (select count(*) from t_booking_unit_sub us
                     where us.partner_cd = u.partner_cd
                       and us.partner_request_cd = u.partner_request_cd
                       and us.item_no = u.item_no) as sub_count
					from t_booking_unit u
                        where u.booking_id = '{0}' ",
					sBookingNo);

			DataTable dt = Connection.GetDataTable(sql);
			return dt;
		}

		public static DataTable GetCargoSubByUnit(string sPartner, string sPCFN, string sItemNo)
		{
			string sql = string.Format(@"
				select * from t_booking_unit_sub
                  where partner_cd = '{0}'
                    and partner_request_cd = '{1}'
                    and item_no = {2} ",
			sPartner, sPCFN, sItemNo);
			DataTable dt = Connection.GetDataTable(sql);
			return dt;
		}
		public static DataTable GetSubCargoQuery(List<ClsLoadedCargo> listCargo)
		{
			// Finds all of the sub TCN's for a list of cargo
			DataTable dt = new DataTable();
			foreach( ClsLoadedCargo lst in listCargo )
			{
				StringBuilder sql = new StringBuilder();
				sql.AppendFormat(@"
				select sub.partner_request_cd,
                       bu.booking_id,
					   bu.booking_id_sub,
                       sub.item_no,
					   sub.tcn,
					   bu.voyage_no,
             (select count(*)
                from t_booking_itv i
                where i.booking_id = bu.booking_id
                  and i.booking_sub = bu.booking_id_sub
                  and i.item_no = bu.item_no
                  and i.sub_tcn = sub.tcn
                  and i.activity_code = 'EE') as ee_count,
             (select count(*)
                from t_booking_itv i
                where i.booking_id = bu.booking_id
                  and i.booking_sub = bu.booking_id_sub
                  and i.item_no = bu.item_no
                  and i.sub_tcn = sub.tcn
                  and i.activity_code = 'W') as w_count,
             (select count(*)
                from t_booking_itv i
                where i.booking_id = bu.booking_id
                  and i.booking_sub = bu.booking_id_sub
                  and i.item_no = bu.item_no
                  and i.sub_tcn = sub.tcn
                  and i.activity_code = 'I') as i_count,
             (select count(*)
                from t_booking_itv i
                where i.booking_id = bu.booking_id
                  and i.booking_sub = bu.booking_id_sub
                  and i.item_no = bu.item_no
                  and i.sub_tcn = sub.tcn
                  and i.activity_code = 'AE') as ae_count,
             (select count(*)
                from t_booking_itv i
                where i.booking_id = bu.booking_id
                  and i.booking_sub = bu.booking_id_sub
                  and i.item_no = bu.item_no
                  and i.sub_tcn = sub.tcn
                  and i.activity_code = 'VD') as vd_count,
             (select count(*)
                from t_booking_itv i
                where i.booking_id = bu.booking_id
                  and i.booking_sub = bu.booking_id_sub
                  and i.item_no = bu.item_no
                  and i.sub_tcn = sub.tcn
                  and i.activity_code = 'VA') as va_count,
             (select count(*)
                from t_booking_itv i
                where i.booking_id = bu.booking_id
                  and i.booking_sub = bu.booking_id_sub
                  and i.item_no = bu.item_no
                  and i.sub_tcn = sub.tcn
                  and i.activity_code = 'UV') as uv_count,
             (select count(*)
                from t_booking_itv i
                where i.booking_id = bu.booking_id
                  and i.booking_sub = bu.booking_id_sub
                  and i.item_no = bu.item_no
                  and i.sub_tcn = sub.tcn
                  and i.activity_code = 'OA') as oa_count,
             (select count(*)
                from t_booking_itv i
                where i.booking_id = bu.booking_id
                  and i.booking_sub = bu.booking_id_sub
                  and i.item_no = bu.item_no
                  and i.sub_tcn = sub.tcn
                  and i.activity_code = 'AV') as av_count,
             (select count(*)
                from t_booking_itv i
                where i.booking_id = bu.booking_id
                  and i.booking_sub = bu.booking_id_sub
                  and i.item_no = bu.item_no
                  and i.sub_tcn = sub.tcn
                  and i.activity_code = 'x1') as x1_count,
             (select count(*)
                from t_booking_itv i
                where i.booking_id = bu.booking_id
                  and i.booking_sub = bu.booking_id_sub
                  and i.item_no = bu.item_no
                  and i.sub_tcn = sub.tcn
                  and i.activity_code = 'EC') as ec_count,
             (select count(*)
                from t_booking_itv i
                where i.booking_id = bu.booking_id
                  and i.booking_sub = bu.booking_id_sub
                  and i.item_no = bu.item_no
                  and i.sub_tcn = sub.tcn
                  and i.activity_code = 'RD') as rd_count
				   from t_booking_unit_sub sub
                  inner join t_booking_request b 
					 on sub.partner_cd = b.partner_cd
                    and sub.partner_request_cd = b.partner_request_cd
                    and b.acms_status_cd in ('B','C')
				    and b.partner_cd like 'MTM%'
                  inner join t_booking_unit bu
                     on bu.partner_cd = sub.partner_cd
                     and bu.partner_request_cd = sub.partner_request_cd
                     and bu.item_no = sub.item_no
					where bu.partner_request_cd = '{0}'
                      and bu.tcn = '{1}'",
					lst.PCFN, lst.TCN);
				DataTable dtOne = Connection.GetDataTable(sql.ToString());
				dt.Merge(dtOne);
			}

			return dt;
		}

		#endregion

		#region Queries
		public static DataTable UnsentITV()
		{
			// ****  OBSOLETE ****
			// Currently not used.  See clsLIne
			StringBuilder sb = new StringBuilder();

			sb.Append(@"
				select bu.booking_id, bu.partner_request_cd, bu.item_no, bu.booking_id_sub, bu.voyage_no, bu.poe_location_cd, bu.pod_location_cd, bu.pod_terminal_cd, bu.tcn, vrd.arrival_dt, itv.activity_code, itv.confirm_cd
				from t_booking_unit bu
				 inner join t_booking b on b.partner_request_cd = bu.partner_request_cd
				 inner join t_booking_request br on b.partner_request_cd = br.partner_request_cd 
				   and br.acms_status_cd in ( 'B', 'BC')
				 inner join t_voyage_route_detail vrd
				   on vrd.voyage_cd = bu.voyage_no
				   and vrd.location_cd = bu.pod_location_cd
				   and vrd.terminal_cd = bu.pod_terminal_cd
				 left outer join t_booking_itv itv
				  on itv.booking_id = bu.booking_id
				  and itv.item_no = bu.item_no   
				  and itv.activity_code = 'X1' 
				where vrd.arrival_dt between sysdate-30 and sysdate-2
				 and actual_arrival_fl = 'Y'
				 and b.partner_cd like 'MTM%'
				 and itv.activity_code is null
				  order by b.partner_request_cd, bu.item_no");

			DataTable dt = Connection.GetDataTable(sb.ToString());
			return dt;
		}

		public static DataTable MissingVDITV()
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendFormat(@"
				select voyage_cd, location_cd, max(departure_dt) as departure_dt, adj_rdd_dt,  partner_request_cd, booking_id, tcn, item_no, vd_count, ae_count
				from
				(
				select v.voyage_cd, v.location_cd, b.adj_rdd_dt, v.departure_dt, bu.partner_request_cd, bu.booking_id, bu.tcn, bu.item_no,
				 (select count(*)
					from t_booking_itv itv
					where itv.booking_id = bu.booking_id
					 and itv.booking_sub =bu.booking_id_sub
					 and itv.item_no = bu.item_no
					 and itv.activity_code = 'VD') as vd_count,
				(select count(*)
					from t_booking_itv itv
					where itv.booking_id = bu.booking_id
					 and itv.booking_sub =bu.booking_id_sub
					 and itv.item_no = bu.item_no
					 and itv.activity_code = 'AE') as ae_count
				from mv_voyage_route_detail v
				 inner join t_booking_unit bu
				  on bu.voyage_no = v.voyage_cd
				 and bu.poe_location_cd = v.location_cd
				  inner join t_booking_request br
					on bu.partner_cd = br.partner_cd
					and bu.partner_request_cd = br.partner_request_cd
					and br.acms_status_cd = ('B','C')
				  inner join t_booking b
					on bu.partner_cd = b.partner_cd
					and bu.partner_request_cd = b.partner_request_cd
				 where pol_pod = 'L'
				  and actual_departure_fl = 'Y'
				  and departure_dt between sysdate - 60 and sysdate - 2
				  and bu.partner_cd like 'MT%'
				)
				 where vd_count = 0 or  ae_count = 0  
				 group by voyage_cd, location_cd, adj_rdd_dt, partner_request_cd, booking_id, tcn, vd_count, ae_count, item_no
				  order by voyage_cd, location_cd, booking_id, partner_request_cd, item_no");

			DataTable dt = Connection.GetDataTable(sb.ToString());
			return dt;

		}

		public static DataTable ITVbyDate()
		{
			return ITVbyDate("I");
		}

		public static DataTable ITVbyDate(string ActivityCd)
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendFormat(@"
			 select 
				  to_char(activity_dt, 'YYYY/MM/DD') as recdate,
				  i.voyage_no as voyageno,
				  i.booking_id as booking_no,
				  bu.partner_request_cd as pcfn,
				  activity_code,
				  bu.tcn,
				  confirm_cd,
				  0 as diff_status
			  from t_booking_itv i 
			   left outer join t_booking_unit bu on bu.item_no = i.item_no
					and bu.booking_id = i.booking_id
					and nvl(i.booking_sub, '  ') = nvl(bu.booking_id_sub, '  ')
			   where activity_dt > sysdate - 14
			     and activity_code in ('{0}')
			   group by
				  to_char(activity_dt, 'YYYY/MM/DD'),
				  i.voyage_no,
				  i.booking_id,
				  activity_code,bu.partner_request_cd,
				  bu.tcn,
				  confirm_cd ", ActivityCd);
			DataTable dt = Connection.GetDataTable(sb.ToString());
			return dt;
		}

		public static DataTable ITVbyVoyage(string VoyageNo, string Port, string ArriveDepart)
		{
			string sCode = "VA";
			VoyageNo = ClsLineSQL.VoyageNoStripped(VoyageNo);
			if( ArriveDepart.ToLower() == "depart" )
			{
				sCode = "VD";
			}
			StringBuilder sb = new StringBuilder();
			sb.AppendFormat(@"
			 select 
				  to_char(activity_dt, 'YYYY/MM/DD') as recdate,
				  i.voyage_no as voyageno,
				  i.booking_id as booking_no,
				  bu.partner_request_cd as pcfn,
				  activity_code,
				  bu.tcn,
				  confirm_cd,
				  0 as diff_status,
				  i.location_cd,
				  i.terminal_cd
			  from t_booking_itv i 
			   left outer join t_booking_unit bu on bu.item_no = i.item_no
					and bu.booking_id = i.booking_id
					and nvl(i.booking_sub, '  ') = nvl(bu.booking_id_sub, '  ')
			   where activity_dt > sysdate - 90
				 and substr(i.voyage_no,1,5) = '{0}'
				 and i.location_cd = '{1}'
			     and activity_code in ('{2}')
			   group by
				  to_char(activity_dt, 'YYYY/MM/DD'),
				  i.voyage_no,
				  i.booking_id,
				  activity_code,bu.partner_request_cd,
				  bu.tcn,
				  confirm_cd, i.location_cd, i.terminal_cd
				", VoyageNo, Port, sCode);
			DataTable dt = Connection.GetDataTable(sb.ToString());
			return dt;
		}
//        public static DataTable GetArriveDepartSchedule(string sPartner, int iFrom, int iTo, string sVoyageNo, bool bOnlyProblems)
//        {
//            return GetArriveDepartSchedule(Connection, sPartner, iFrom, iTo, sVoyageNo, bOnlyProblems);
//        }
//        public static DataTable GetArriveDepartSchedule(ClsConnection conn, string sPartner, int iFrom, int iTo, string sVoyageNo, bool bOnlyProblems)
//        {
//            // March2014 DG: It did not used to consider terminal_cd when computing the cargo_count
//            // for voyages.  I have changed this, so the report is more accurate.
//            //
//            // Note we used to ignore it because I didn't want any cargo to "slip through the cracks".  However
//            // Those should all be caught in our diagnostics reports, so we are now going to make this query
//            // 100% correct, which should make it easier to work with.
//            StringBuilder sb = new StringBuilder();
//            sb.AppendFormat(@"
//				select * from
//				(
//				select arrive.voyage_cd as voyageno, 
//				  vessel_cd,
//				  'Arrive' as ArriveDepart, 
//				  location_cd, 
//				  arrive.terminal_cd,
//				  min(arrival_dt) as voyagedate, 
//				  actual_arrival_fl as actual_flg,
//				 (select count(*)
//				  from t_booking_itv itv 
//				  where itv.voyage_no = arrive.voyage_cd
//				   and itv.activity_code = 'VA'
//				   and itv.location_cd = arrive.location_cd
//				   and itv.terminal_cd = arrive.terminal_cd
//				   ) as itv_count,
//					 (select count(*)
//				  from t_booking_unit bu
//				  inner join t_booking_request b on b.partner_request_cd = bu.partner_request_cd
//					and b.acms_status_cd in ( 'B', 'C')
//					and b.partner_cd = '{2}'
//				   where bu.voyage_no = arrive.voyage_cd
//					and bu.pod_location_cd = arrive.location_cd
//					and bu.pod_terminal_cd = arrive.terminal_cd
//					) as unit_count  
//				 from mv_voyage_route_detail arrive
//				  inner join mv_voyage v on v.voyage_cd = arrive.voyage_cd
//				 where (arrival_dt between sysdate - {0} and sysdate + {1})
//				  and pol_pod = 'D'
//				group by arrive.voyage_cd, vessel_cd, actual_arrival_fl, location_cd, terminal_cd
//				union all
//				select depart.voyage_cd, vessel_cd, 'Depart', 
//				  location_cd, terminal_cd,
//				  min(departure_dt), 
//				  actual_departure_fl,
//				 (select count(*)
//				  from t_booking_itv itv 
//				  where itv.voyage_no = depart.voyage_cd
//				   and itv.location_cd = depart.location_cd
//				   and itv.terminal_cd = depart.terminal_cd
//				   and itv.activity_code = 'VD') as itv_count,
//				  (select count(*)
//				  from t_booking_unit bu
//				  inner join t_booking_request b on b.partner_request_cd = bu.partner_request_cd
//					and b.acms_status_cd in ( 'B', 'C' )
//					and b.partner_cd like '{2}%'    
//				   where bu.voyage_no = depart.voyage_cd
//					and bu.poe_location_cd = depart.location_cd
//					and bu.poe_terminal_cd = depart.terminal_cd 
//						) as unit_count    
//				 from mv_voyage_route_detail depart
//				  inner join mv_voyage v on v.voyage_cd = depart.voyage_cd
//				 where (departure_dt between sysdate - {0} and sysdate + {1})
//				  and pol_pod = 'L'
//				 group by depart.voyage_cd, vessel_cd, location_cd, actual_departure_fl, terminal_cd )				
//					where unit_count > 0", 
//                    iFrom, iTo, sPartner);
//            if (bOnlyProblems)
//            {
//                sb.Append(" and itv_count <> unit_count ");
//            }
//            if (!string.IsNullOrEmpty(sVoyageNo))
//            {
//                sb.AppendFormat(" and voyageno like '{0}' ", sVoyageNo);
//            }
//            string sql = sb.ToString();
//            DataTable dt = conn.GetDataTable(sql);
//            return dt;
//        }

		public static DataTable GetCargoByVoyage(string VoyageNo, string Port, string ArriveDepart)
		{
			StringBuilder sb = new StringBuilder();
			VoyageNo = ClsLineSQL.VoyageNoStripped(VoyageNo);
			sb.AppendFormat(@"
				select bu.partner_request_cd, bu.booking_id, tcn, bu.voyage_no,
				   bu.pod_location_cd, bu.pod_terminal_cd,
				   bu.poe_location_cd, bu.poe_terminal_cd, 0 as Diff_Status,
				   (select count(*)
					  from t_booking_itv itv
					   where itv.booking_id = bu.booking_id
						and itv.booking_sub = bu.booking_id_sub
						and itv.item_no = bu.item_no
						and itv.activity_code = 'VD') as vd_count,
				   (select count(*)
					  from t_booking_itv itv
					   where itv.booking_id = bu.booking_id
						and itv.booking_sub = bu.booking_id_sub
						and itv.item_no = bu.item_no
						and itv.activity_code = 'VA') as va_count
					  from t_booking_unit bu
					  inner join t_booking_request b on b.partner_request_cd = bu.partner_request_cd
						and b.acms_status_cd in ('B','C')
						and b.partner_cd like 'MTM%'
					   where substr(bu.voyage_no,1,5) = '{0}' ",
				   VoyageNo);

			if( ArriveDepart.ToLower() == "arrive" )
			{
				sb.AppendFormat(@" and bu.pod_location_cd = '{0}' ", Port);
			}
			else
			{
				sb.AppendFormat(@" and bu.poe_location_cd = '{0}' ", Port);
			}

			DataTable dt = Connection.GetDataTable(sb.ToString());
			return dt;
		}

		public static DataTable GetCargoByReceivedDt(int days)
		{
			StringBuilder sql = new StringBuilder();
			sql.AppendFormat(@"
				select 
					 b.request_dt,
					 b.partner_request_cd, 
					 bu.booking_id,
					 bu.voyage_no,
					 bu.vessel_cd,
					 bu.item_no,
					 bu.tcn,
					 bu.poe_location_cd as pol,
					 bu.poe_terminal_cd as pol_berth,
					 bu.pod_location_cd as pod,
					 bu.pod_terminal_cd as pod_berth,
					 (select count(*) from t_booking_itv itv 
							where itv.booking_id = bu.booking_id
							  and itv.booking_sub = bu.booking_id_sub
							  and itv.item_no = bu.item_no
							  and itv.activity_code = 'I') as i_count,
					 (select count(*) from t_booking_itv itv 
							where itv.booking_id = bu.booking_id
							  and itv.booking_sub = bu.booking_id_sub
							  and itv.item_no = bu.item_no
							  and itv.activity_code = 'VD') as vd_count
				  from t_booking_unit bu
				  inner join t_booking_request b
				   on b.partner_cd = bu.partner_cd
				   and b.partner_request_cd = bu.partner_request_cd
				   and b.acms_status_cd in ('B','C')          
				  where b.request_dt > sysdate - {0}
				   and b.partner_cd like 'MTM%' ", days);
			DataTable dt = Connection.GetDataTable(sql.ToString());

			// Remove all that have ingates & departs
			dt = GetCargoByReceivedDt(dt);
			return dt;
		}

		public static DataTable GetCargoByReceivedDt(DataTable dt)
		{
			// Add needed columsn
			dt.Columns.Add("line_voyage");
			dt.Columns.Add("line_pol");
			dt.Columns.Add("line_pod");
			dt.Columns.Add("line_deleted");
			dt.Columns.Add("line_count");

			foreach (DataRow drACMS in dt.Rows)
			{
				// If it already has ITV data, delete and continue
				string s1 = drACMS["i_count"].ToString();
				string s2 = drACMS["vd_count"].ToString();
				if( s1 != "0" && s2 != "0" )
				{
					drACMS.Delete();
					continue;
				}

				string tcn = drACMS["tcn"].ToString();
				tcn = CleanSerialNo(tcn);
				string voyage = drACMS["voyage_no"].ToString();
				voyage = ClsLineSQL.VoyageNoStripped(voyage);
				string pol = drACMS["pol"].ToString();
				string pod = drACMS["pod"].ToString();
				string booking = drACMS["booking_id"].ToString();

				DataTable dtLINE = ClsLineSQL.GatherLINEData(tcn);

				// If no match in LINE, keep this row and continue
				if( dtLINE == null )
				{
					continue;
				}
				if (dtLINE.Rows.Count == 0)
				{
					continue;
				}
				// If more than one match in LINE, indicate this
				// and continue
				if( dtLINE.Rows.Count > 1 )
				{
					drACMS["line_count"] = dt.Rows.Count.ToString();
					continue;
				}

				// If exactly one row found in LINE, check to see
				// if everything matches.
				DataRow drLINE = dtLINE.Rows[0];
				string line_voyage = drLINE["voyageno"].ToString();
				string line_pol = drLINE["pol"].ToString();
				string line_pod = drLINE["pod"].ToString();
				string line_deleted = drLINE["deleted"].ToString();

				// If all pertinent data matches, delete the row 
				
				if( voyage == line_voyage &&
					pol == line_pol &&
					pod == line_pod &&
					line_deleted == "N")
				{
					drACMS.Delete();
					continue;
				}
				drACMS["line_voyage"] = line_voyage;
				drACMS["line_pol"] = line_pol;
				drACMS["line_pod"] = line_pod;
				drACMS["line_deleted"] = line_deleted;
				drACMS["line_count"] = "1";
			}
			return dt;
		}

		public static DataTable GetRDDDoorMovesReport(string sVoyage, string sVessel)
		{
			if( string.IsNullOrEmpty(sVoyage) )
				sVoyage = "%";
			if( string.IsNullOrEmpty(sVessel) )
				sVessel = "%";
			StringBuilder sb = new StringBuilder();
			sb.AppendFormat(@"
				SELECT *
					from v_booking_door_out
                   where voyage_no like '{0}'
                     and vessel_cd like '{1}'
				order by voyage_no, location_pod_cd, plod_cd, adj_rdd_dt ",
				  sVoyage, sVessel);
			DataTable dt = Connection.GetDataTable(sb.ToString());
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

		public static DataTable GetRDDPortMovesReport()
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendFormat(@"
				select v.route_cd,
				   u.voyage_no,
				   u.pod_location_cd,
				   adj_rdd_dt,
				   rd.eta_dt,
				   rd.actual_fl,
				   count(u.voyage_no) as cargo_count
				 from t_booking_unit u
				inner join v_voyage_route v on v.voyage_cd = u.voyage_no
				inner join mv_voyage_route_detail rd on
					 rd.voyage_cd = u.voyage_no
				   and rd.location_cd = u.pod_location_cd
				   and rd.terminal_cd = u.pod_terminal_cd
				inner join t_booking_request r
				  on u.partner_cd = r.partner_cd and
					 u.partner_request_cd = r.partner_request_cd and
					 r.acms_status_cd in ('B','C') and
					 r.partner_cd like 'MT%' 
					  and r.move_type_cd in ('F1','F2','F3','F4','F5','F6')
				inner join t_booking b on
					r.partner_cd = b.partner_cd and
					r.partner_request_cd = b.partner_request_cd   
				inner join r_location l on
					u.pod_location_cd = l.location_cd      
				 where 1 = 1
				   and adj_rdd_dt > sysdate - 120
				 group by v.route_cd, u.voyage_no,   u.pod_location_cd,
				   rd.eta_dt,   adj_rdd_dt, rd.actual_fl
					order by 
						  v.route_cd,
						  u.voyage_no,
						  rd.eta_dt,
						  u.pod_location_cd,
						  adj_rdd_dt");
			DataTable dt = Connection.GetDataTable(sb.ToString());
			return dt;
		}

		public static DataTable GetVesselErrors(ClsConnection conn)
		{
			//  First it will load any missing vessels from AVSS into ACMS
			//  Then it will display all vessels in ACMS that are missing the FLAG (country)
			//  because we don't carry that in AVSS so the users must enter it themselves.
			try
			{
				string sql = string.Format(@"
				insert into r_vessel
				 (vessel_cd, vessel_dsc, delete_fl, ircs)
				select vessel_cd, vessel_nm, 'N', ircs_cd
				 from v_vessel_avss
				  where create_dt > sysdate - 60
                  and length(vessel_cd) < 5
				  and vessel_cd not in
				  (select vessel_cd from r_vessel  ) ");
				conn.RunSQL(sql, CommandType.Text);

				string sqlb = string.Format(@"
				select * from r_vessel where flag is null ");
				DataTable dt = conn.GetDataTable(sqlb);
				return dt;
			}
			catch (Exception ex)
			{
				string sMsg = string.Format(@"clsACMSsql.GetVesselErrors: {0} ", ex.Message);
				ClsErrorHandler.LogError(sMsg);
				return null;
			}
		}

		public static DataTable GetDashboardLinerOutRDD(ClsConnection conn)
		{
			string sql = string.Format(@"
				select b.partner_cd, b.booking_id, b.partner_request_cd, b.voyage_no, b.vessel_cd, b.poe_location_cd, b.pod_location_cd, count(b.booking_id) as missing_count,
				   (select count(*) from t_booking_unit u where u.booking_id = b.booking_id and u.partner_cd = b.partner_cd) as booking_count,
				   s.adj_rdd_dt
				   from v_sddc_itv_summary s
				   inner join t_booking_request b on b.booking_id = s.booking_id and b.partner_cd = s.partner_cd and b.acms_status_cd in ('B','C')
				   where s.adj_rdd_dt between trunc(sysdate - 60) and trunc(sysdate) + 3
				  and (oa_dt is null or x1_dt is null)
				  and b.move_type_cd in ('F2','F3','F6')
				  group by b.partner_cd, b.booking_id, b.partner_request_cd, b.voyage_no, b.vessel_cd, b.poe_location_cd, b.pod_location_cd, s.adj_rdd_dt ");
			DataTable dt = conn.GetDataTable(sql);
			return dt;
		}
		#endregion

		#region ACMS Data Structure
		public struct ACMSBookingData
		{
			public DateTime? dtRDD;
			public string sBooking;
			public string sBookingSub;
			public string sPCFN;
			public string sVoyageNo;
			public long lItemNo;
			public string sPOELocation;
			public string sPOETerminal;
			public string sPODLocation;
			public string sPODTerminal;
			public DateTime? dtDepartureDt;
			public DateTime? dtArriveDt;
		}
		#endregion

		#region Updates
		public static int CreateITV(List<ClsLoadedCargo> cargo)
		{
			int i = 0;
			foreach(ClsLoadedCargo c in cargo)
			{
				if( c.I_InGateCount == 0 )
				{
					CreateITV(c, "I", "EDIrcvd");
					i++;
				}
				if( c.W_PickupCount == 0 )
				{
					CreateITV(c, "W", "EDIrcvd");
					i++;
				}
			}
			return i;
		}
		public static void CreateITV(ClsLoadedCargo c, string sCode, string sUser)
		{
			if (string.IsNullOrEmpty(c.BookingNo))
			{
				return;
			}
			List<DbParameter> p = new List<DbParameter>();
			p.Add(Connection.GetParameter("@RDATE", c.ReceivedDate));
			StringBuilder sb = new StringBuilder();
			sb.AppendFormat(@"
				insert into t_booking_itv   
				 (activity_id, booking_id, booking_sub, activity_code, 
					activity_dt, activity_user,  confirm_cd, voyage_no, 
					location_cd, item_no, terminal_cd, trans_ctl_no)
				  select (select max(activity_id)+ 1 from t_booking_itv),
					  '{0}', '{1}', '{2}', @RDATE, 
					  '{7}', 'N', '{3}', '{4}', {5}, '{6}', 0
					   from dual",
				  c.BookingNo,
				  c.BookingNoSub,
				  sCode,
				  c.ACMSVoyageNo,
				  c.POE,
				  c.ItemNo,
				  c.POETerminal,
				  sUser);
			Connection.RunSQL(sb.ToString(), CommandType.Text, p.ToArray());
		}

		public static int CreateITVDeparts(List<ClsLoadedCargo> cargo, string sUser)
		{
			int i = 0;
			foreach( ClsLoadedCargo c in cargo )
			{
				if( c.VD_DepartCount == 0 )
				{
					CreateITVDeparts(c, "VD", sUser);
					i++;
				}
				if( c.AE_LoadCount == 0 )
				{
					CreateITVDeparts(c, "AE", sUser);
					i++;
				}
			}
			return i;
		}
		
		public static void CreateITVDeparts(ClsLoadedCargo c, string sCode, string sUser)
		{
			if( string.IsNullOrEmpty(c.BookingNo) )
			{
				return;
			}
			List<DbParameter> p = new List<DbParameter>();
			p.Add(Connection.GetParameter("@DDATE", c.ACMSDepartDt));
			StringBuilder sb = new StringBuilder();
			sb.AppendFormat(@"
				insert into t_booking_itv   
				 (activity_id, booking_id, booking_sub, activity_code, 
					activity_dt, activity_user,  confirm_cd, voyage_no, 
					location_cd, item_no, terminal_cd, trans_ctl_no)
				  select (select max(activity_id)+ 1 from t_booking_itv),
					  '{0}', '{1}', '{2}', @DDATE, 
					  '{7}', 'N', '{3}', '{4}', {5}, '{6}', 0
					   from dual",
				  c.BookingNo,
				  c.BookingNoSub,
				  sCode,
				  c.ACMSVoyageNo,
				  c.POE,
				  c.ItemNo,
				  c.POETerminal,
				  sUser);
			Connection.RunSQL(sb.ToString(), CommandType.Text,p.ToArray());
		}

		public static int CreateITVArrives(List<ClsLoadedCargo> cargo)
		{
			int i = 0;
			foreach( ClsLoadedCargo c in cargo )
			{
				if( c.VA_ArriveCount == 0 )
				{
					CreateITVArrives(c, "VA", "EDIva");
					i++;
				}
				if( c.UV_DischargeCount == 0 )
				{
					CreateITVArrives(c, "UV", "EDIva");
					i++;
				}
				// Unless it's a Door Out, we'll automatically 
				// deliver the cargo.
				if( !c.IsDoorOut )
				{
					// However, if this is the first leg of a transhipment
					// we will not deliver it.
					if( c.isFirstLegTransshipment )
					{
						continue;
					}
					if( c.OA_OutgateCount == 0 )
					{
						CreateITVArrives(c, "OA", "EDIva");
						i++;
					}
					if( c.X1_DeliveredCount == 0 )
					{
						CreateITVArrives(c, "X1", "EDIva");
						i++;
					}
				}
			}
			return i;
		}

		public static void CreateITVArrives(ClsLoadedCargo c, string sCode, string sUser)
		{
			CreateITVMessage(c, sCode, c.ACMSArriveDt, sUser);
		}

		public static void CreateITVMessage(ClsLoadedCargo c, string sCode, DateTime? dtDate, string sUser)
		{
			if( string.IsNullOrEmpty(c.BookingNo) )
			{
				return;
			}
			CreateITVMessage(c, sCode, dtDate, c.POD, c.PODTerminal, sUser);
			return;
		}

		public static void CreateITVMessage(ClsLoadedCargo c, string sCode, DateTime? dtDate, string sPort, string sberth, string sUser)
		{
			if( string.IsNullOrEmpty(c.BookingNo) )
			{
				return;
			}
			List<DbParameter> p = new List<DbParameter>();
			//p.Add(Connection.GetParameter("@DDATE", c.ACMSArriveDt));
			p.Add(Connection.GetParameter("@DDATE", dtDate));
			StringBuilder sb = new StringBuilder();
			sb.AppendFormat(@"
				insert into t_booking_itv   
				 (activity_id, booking_id, booking_sub, activity_code, 
					activity_dt, activity_user,  confirm_cd, voyage_no, 
					location_cd, item_no, terminal_cd, trans_ctl_no)
				  select (select max(activity_id)+ 1 from t_booking_itv),
					  '{0}', '{1}', '{2}', @DDATE, 
					  '{3}', 'N', '{4}', '{5}', {6}, '{7}', 0
					   from dual",
				  c.BookingNo,
				  c.BookingNoSub,
				  sCode,
				  sUser,
				  c.ACMSVoyageNo,
				  sPort,
				  c.ItemNo,
				  sberth);
			Connection.RunSQL(sb.ToString(), CommandType.Text, p.ToArray());
		}
		public static void CreateITVSubMessage(string sBookingNo, string sBookingNoSub,
			  string sCode, string sUser, string sVoyageNo, string sPort, 
			  string sItemNo, string sBerth, DateTime? dtDate, string sSubTCN)
		{
			List<DbParameter> p = new List<DbParameter>();
			p.Add(Connection.GetParameter("@DDATE", dtDate));
			StringBuilder sb = new StringBuilder();
			sb.AppendFormat(@"
				insert into t_booking_itv   
				 (activity_id, booking_id, booking_sub, activity_code, 
					activity_dt, activity_user,  confirm_cd, voyage_no, 
					location_cd, item_no, terminal_cd, trans_ctl_no, sub_tcn)
				  select (select max(activity_id)+ 1 from t_booking_itv),
					  '{0}', '{1}', '{2}', @DDATE, 
					  '{3}', 'Y', '{4}', '{5}', {6}, '{7}', 0, '{8}'
					   from dual",
				  sBookingNo,
				  sBookingNoSub,
				  sCode,
				  sUser,
				  sVoyageNo,
				  sPort,
				  sItemNo,
				  sBerth,
				  sSubTCN);
			Connection.RunSQL(sb.ToString(), CommandType.Text, p.ToArray());

		}

		public static void CreateITVMessage(
			string sCode, DateTime? dtDate, string sPort, string sberth,
			string sBookingNo, string sBookingSub, string sVoyageNo, string sItemNo,
			string sTCN, string sUser)
		{
			if (string.IsNullOrEmpty(sBookingNo))
			{
				return;
			}
			List<DbParameter> p = new List<DbParameter>();
			//p.Add(Connection.GetParameter("@DDATE", c.ACMSArriveDt));
			p.Add(Connection.GetParameter("@DDATE", dtDate));
			StringBuilder sb = new StringBuilder();
			sb.AppendFormat(@"
				insert into t_booking_itv   
				 (activity_id, booking_id, booking_sub, activity_code, 
					activity_dt, activity_user,  confirm_cd, voyage_no, 
					location_cd, item_no, terminal_cd, trans_ctl_no, sub_tcn)
				  select (select max(activity_id)+ 1 from t_booking_itv),
					  '{0}', '{1}', '{2}', @DDATE, 
					  '{3}', 'N', '{4}', '{5}', {6}, '{7}', 0, '{8}' 
					   from dual",
				  sBookingNo,
				  sBookingSub,
				  sCode,
				  sUser,
				  sVoyageNo,
				  sPort,
				  sItemNo,
				  sberth,
				  sTCN);
			Connection.RunSQL(sb.ToString(), CommandType.Text, p.ToArray());
		}
		public static void UpdateITV(
				int ActivityID, 
				string LocationCd, 
				string ConfirmCD,
				string Notes)
		{
			try
			{
				string sql = string.Format(@"
					update t_booking_itv
					   set confirm_cd = '{0}',
						location_cd = '{1}',
						notes = '{3}'
				    where activity_id = {2} ",
					  ConfirmCD, LocationCd, ActivityID, Notes);

				Connection.RunSQL(sql);
			}
			catch( Exception ex )
			{
				throw ex;
			}
		}

		public static void UpdateITVtcn()
		{
			// Added November 2015.  This will place the TCN from t_booking_unit into all corresponding
			// ITV rows.  This is because the key has always been item_no, but sometimes ITV is sent
			// for one TCN, then later the TCN is changed.  When that happens we lost the audit trail
			// of what had actually been sent.  Now we'll log the actual TCN that was sent in the ITV.
			//
			// This needs to go hand-in-hand with updating the ITV query window(s) so they look at the
			// TCN that was actuallly sent instead of (in additon to?) what is there now.
			string sql = string.Format(@"
				update t_booking_itv
				 set sub_tcn = 
				  (select max(tcn) from t_booking_unit bu
				   where bu.booking_id = t_booking_itv.booking_id
					and bu.item_no = t_booking_itv.item_no)
				  where create_dt > sysdate - 180
				   and sub_tcn is null");
			Connection.RunSQL(sql);
		}

		public static void FixITVVoyages()
		{
			bool bInTrans = Connection.IsInTransaction;
			if (!bInTrans)
				Connection.TransactionBegin();
			try
			{
				// Sometimes ITV is created with an incorrect voyage.  When the user corrects the voyage in the booking (t_booking_unit)
				// it does not automatically cascade to the corresponding ITV.
				//
				//  This query will look for ITV that has failed to be sent because of "No Military Voyage".  It will then look to see
				//  If the voyage_no for the ITV matches the voyage_no for the cargo (t_booking_bu).  If not, it will synchronize the
				//  voyage number (update t_booking_itv.voyage_no to match t_booking_unit.voyage_no) which will usually resolve the
				// "No Military Voyage" problem.  
				string sql = string.Format(@"
					update t_booking_itv itv
						set voyage_no = (select max(voyage_no) from t_booking_unit bu where bu.booking_id = itv.booking_id
														and bu.item_no = itv.item_no)
						where itv.activity_id in
						(
					select i.activity_id from v_itv_not_sent i
						inner join t_booking_unit bu
						on bu.booking_id = i.booking_id
						and bu.item_no = i.item_no 
						where reason_msg like 'No military%'
						and i.voyage_no <> bu.voyage_no )");
				Connection.RunSQL(sql);
				if (!bInTrans)
					Connection.TransactionCommit();
			}
			catch (Exception ex)
			{
				if (!bInTrans)
					Connection.TransactionRollback();
				throw;
			}
		}
				
		#endregion

		#region Transshipments Stuff
		public static void RefreshTransshipments(DataTable dtIn)
		{
			// We do this in a single transaction, because if any
			// of it fails the whole thing must fail
			if (Connection == null)
				ConnectToACMS();
			Connection.TransactionBegin();

			try
			{
				// Start by clearing all data
				string sqlClear = string.Format(@"
						update t_transshipment 
							set final_booking_no = null,
								vessel_cd = null, pol_location_cd = null,
								pod_location_cd = null, plod_location_cd = null,
								voyage_no = null 
                        where f_ocean_system_voyage(voyage_no) = 'LINE'");
				Connection.RunSQL(sqlClear);

				// Go through each row and either update or insert
				foreach( DataRow dr in dtIn.Rows )
				{
					string BookingNo = dr["booking_no"].ToString();
					string FinalBookingNo = dr["final_booking_no"].ToString();
					string VoyageNo = dr["voyage_no"].ToString();
					string VesselNo = dr["vessel_no"].ToString();
					string PolLocationCd = dr["pol_location_cd"].ToString();
					string PodLocationCd = dr["pod_location_cd"].ToString();
					string PlodLocationCd = dr["plod_location_cd"].ToString();
					string MoveTypeCd = dr["move_type_cd"].ToString();
					string PODTerminalCd = dr["pod_terminal_cd"].ToString();

					string sqlInsert = string.Format(@"
					Insert into t_transshipment
					 (booking_no, final_booking_no, voyage_no, vessel_cd,
                      pol_location_cd, pod_location_cd, plod_location_cd, move_type_cd, pod_terminal_cd)
					select '{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}'
                      from dual
                    where not exists (select 1 from t_transshipment where booking_no = '{0}' )",
						BookingNo, FinalBookingNo, VoyageNo, VesselNo, PolLocationCd, PodLocationCd,
						PlodLocationCd, MoveTypeCd, PODTerminalCd);
					Connection.RunSQL(sqlInsert);

					string sqlUpdate = string.Format(@"
					update t_transshipment
                       set final_booking_no = '{1}',
						   voyage_no = '{2}',
							vessel_cd = '{3}',
							pol_location_cd = '{4}',
							pod_location_cd = '{5}',
							plod_location_cd = '{6}',
							move_type_cd = '{7}',
						    pod_terminal_cd = '{8}'
						where booking_no = '{0}' ",
							BookingNo, FinalBookingNo, VoyageNo, VesselNo, PolLocationCd, PodLocationCd,
							PlodLocationCd, MoveTypeCd, PODTerminalCd);

					Connection.RunSQL(sqlUpdate);
				}

				// Finally, purge all rows that no longer have a voyage
				string sqlPurge = string.Format(@"
						delete from t_transshipment 
                            where final_booking_no is null 
                             and f_ocean_system_voyage(voyage_no) = 'LINE'");
				Connection.RunSQL(sqlPurge);

				// Commit all
				Connection.TransactionCommit();
			}
			catch( Exception ex )
			{
				Connection.TransactionRollback();
				throw ex;
			}
		}

		#endregion

		#region 301 Processing stuff (replacement for wwldemon)

		public static string Post301HouseKeeping()
		{
			bool bInTrans = Connection.IsInTransaction;
			if (!bInTrans)
				Connection.TransactionBegin();
			StringBuilder sMsg = new StringBuilder();
			sMsg.AppendLine("Post 301 Housekeeping: ");
			try
			{
				string sql = "delete from t_edi_activity_ftp where trans_ctl_no is null";
				Connection.RunSQL(sql);

				sql = "select 1 from t_booking_confirmation where process_flag = 'N' ";
				DataTable dt = Connection.GetDataTable(sql);
				if (dt.Rows.Count == 0)
				{
					// No new confirmations, we can bail out
					sMsg.Append(" No new booking confirmations ");
					return sMsg.ToString();
				}

				// Look for AAL Booking Confirmations
				// 
				sql = @"select count(*) 
								from t_booking_confirmation
								  where process_flag = 'N'
								   and substr(partner_request_cd,1,1) = 'A' ";
				dt = Connection.GetDataTable(sql);
				sql = @"select count(*) 
							 from t_booking_confirmation
							  where process_flag = 'N'
							   and substr(partner_request_cd,1,1) = 'W' ";
				dt = Connection.GetDataTable(sql);
				// NOTE Above:Formerlly sent an email regardin confirmations.  Check
				// to see if this is still needed.  If so probably need
				// move these to separate functions and call from Program


				// For all confirmations, Update status to booked
				// for any confirmations that have been received
				UpdateBookingRequest("PB", "B", "A");
				UpdateBookingRequest("PC", "C", "A");
				UpdateBookingRequest("PB", "W", "W");
				UpdateBookingRequest("PC", "WC", "W");

				// For all unprocessed confirmations, update the booking number with
				// the booking number supplied by the confirmation
				sql = @"update t_booking
						 set booking_id = 
							(select max(booking_id)  
							   from t_booking_confirmation
							  where t_booking.partner_request_cd = t_booking_confirmation.partner_request_cd
							    and process_flag = 'N')
						where  exists (
							select * from t_booking_confirmation
						   where t_booking.partner_request_cd = t_booking_confirmation.partner_request_cd
							 and process_flag = 'N') ";
				Connection.RunSQL(sql);

				// ...Then update the t_booking_unit table, as well.
				sql = @"update t_booking_unit
						 set booking_id = 
							(select max(booking_id)  from t_booking_confirmation
							  where t_booking_unit.partner_request_cd = t_booking_confirmation.partner_request_cd
							    and process_flag = 'N')
						  where exists (
							select * from t_booking_confirmation
						   where t_booking_unit.partner_request_cd = t_booking_confirmation.partner_request_cd
							 and process_flag = 'N') ";
				Connection.RunSQL(sql);

				//	Update for AAL (Confirm flag should be 'Yes' because the confirmation is sent
				//		directly to AAL's database
				sql = @"update t_booking_request
						  set confirm_cd = 'Y'
						 where partner_cd like 'AAL%'
						   and confirm_cd = 'N'
							and acms_status_cd in ('B','C','W') ";
				Connection.RunSQL(sql);
				//of_log ("AAL Requests are set to confirmed. " + string(sqlca.sqlnrows) + " Rows.")

				////	Check for duplicate bookings
				////  DGERDNER: FEB2013 - Not going to bring this into C# because I don't
				////  think it's relevant any more.
				//select count(*) into :ll_ecnt from (          
				//select a.partner_request_cd
				//  from t_booking_confirmation a
				//   where a.partner_request_cd > 'A65683'
				//  group by a.partner_request_cd
				//   having min(a.booking_id) <> max(a.booking_id));
				//commit;
				//if ll_ecnt > 0 then
				//    of_log ("Confirmations were received that created a duplicate booking.  Contact System Support.", true)
				//end if

				sql = @"update t_booking_confirmation
					  set process_flag = 'Y'
					   where process_flag = 'N' ";
				Connection.RunSQL(sql);

				if (!bInTrans)
					Connection.TransactionCommit();
				return sMsg.ToString();
			}
			catch (Exception ex)
			{
				if (!bInTrans)
					Connection.TransactionRollback();
				sMsg.AppendLine(ex.Message);
				return sMsg.ToString();
			}
		}

		private static void UpdateBookingRequest(string oldStatus, string newStatus, string confirmCode)
		{
			string sql = string.Format(@"update t_booking_request
							 set acms_status_cd = '{0}',
 								  confirm_cd = 'N',
							  booking_id = (select max(booking_id)  from t_booking_confirmation
							   where t_booking_request.partner_request_cd = t_booking_confirmation.partner_request_cd
								  and process_flag = 'N')
							 where acms_status_cd in ('{1}')
							 and exists(
							  select * from t_booking_confirmation
							   where t_booking_request.partner_request_cd = t_booking_confirmation.partner_request_cd
								  and t_booking_confirmation.confirm_status_cd in ( '{2}')
								  and process_flag = 'N') ", newStatus, oldStatus, confirmCode);
			Connection.RunSQL(sql);
		}

		public static string WriteFTPLog(string sFile, string sFullFile)
		{
			bool bInTrans = Connection.IsInTransaction;
			if (!bInTrans)
				Connection.TransactionBegin();
			try
			{
				string sql = string.Format(@"
 				insert into t_ftp_history
				 select '{0}', '{1}', 0, 0, sysdate from dual ",
						sFile, sFullFile);
				Connection.RunSQL(sql);
				if (!bInTrans)
					Connection.TransactionCommit();
				return "";

			}
			catch (Exception ex)
			{
				if (!bInTrans)
					Connection.TransactionRollback();
				ClsErrorHandler.LogException(ex);
				return ex.Message;
			}
		}

		public static string UpdateFTPFlagAll()
		{
			bool bInTrans = Connection.IsInTransaction;
			if (!bInTrans)
				Connection.TransactionBegin();

			try
			{
				// Temporary.  Until the normal Update FTP Flag works propertly
				string sql = @"
				 update t_edi_activity_ftp
				 set ftp_success_cd = 'Y'
				 where ftp_success_cd = 'N' or ftp_success_cd is null ";
				Connection.RunSQL(sql);

				if (!bInTrans)
					Connection.TransactionCommit();
				return "";
			}
			catch (Exception ex)
			{
				ClsErrorHandler.LogException(ex);
				if (!bInTrans)
					Connection.TransactionRollback();
				return ex.Message;
			}
		}
		#endregion

		#region ACMS Re-write methods
//        public static DataTable SearchBookingRequests(
//            string sPartner,
//            string sVoyage,
//            int iDays,
//            string sPCFN,
//            string sBookingNo,
//            string sPOL, string sPOD,
//            string sSerialNo,
//            bool bJustStena,
//            bool bJustUnprocessed
//            )
//        {
//            StringBuilder sb = new StringBuilder();
//            sb.AppendFormat(@"
//				  SELECT 'N' as c_check,
//						 T_BOOKING_REQUEST.PARTNER_REQUEST_CD,   
//						 T_BOOKING_REQUEST.REQUEST_DT,   
//						 T_BOOKING_REQUEST.PROJECT_CD,   
//						 T_BOOKING_REQUEST.CONTRACT_NO,   
//						 T_BOOKING_REQUEST.TAC_NO,   
//						 T_BOOKING_REQUEST.FMS_CASE_NO,   
//						 T_BOOKING_REQUEST.VESSEL_IRCC,   
//						 T_BOOKING_REQUEST.VESSEL_DSC,   
//						 T_BOOKING_REQUEST.VOYAGE_NO,   
//						 T_BOOKING_REQUEST.MIL_VOYAGE_NO,   
//						 T_BOOKING_REQUEST.SAIL_DT,   
//						 T_BOOKING_REQUEST.POE_CD,   
//						 T_BOOKING_REQUEST.POE_LOCATION_CD,
//						 T_BOOKING_REQUEST.POE_DSC,   
//						 T_BOOKING_REQUEST.POD_CD,   
//						 T_BOOKING_REQUEST.POD_LOCATION_CD,
//						 T_BOOKING_REQUEST.POD_DSC,   
//						 T_BOOKING_REQUEST.CARGO_AVAIL_DT,   
//						 T_BOOKING_REQUEST.RDD_DT,   
//						 T_BOOKING_REQUEST.DELIVERY_DSC,   
//						 T_BOOKING_REQUEST.SHIP_UNITS_NBR,   
//						 T_BOOKING_REQUEST.CARGO_CD,   
//						 T_BOOKING_REQUEST.ISO_EQP_TYPE_CD,   
//						 T_BOOKING_REQUEST.ORIG_TERMS_CD,   
//						 T_BOOKING_REQUEST.DEST_TERMS_CD,   
//						 T_BOOKING_REQUEST.TOTALS_STOPOFFS_NBR,   
//						 T_BOOKING_REQUEST.REQ_NAME,   
//						 T_BOOKING_REQUEST.REQ_ADDRESS,   
//						 T_BOOKING_REQUEST.REQ_CITY,   
//						 T_BOOKING_REQUEST.REQ_STATE,   
//						 T_BOOKING_REQUEST.REQ_ZIP,   
//						 T_BOOKING_REQUEST.SHIPPER_NAME,   
//						 T_BOOKING_REQUEST.SHIPPER_ADDRESS,   
//						 T_BOOKING_REQUEST.SHIPPER_CITY,   
//						 T_BOOKING_REQUEST.SHIPPER_STATE,   
//						 T_BOOKING_REQUEST.SHIPPER_ZIP,   
//						 T_BOOKING_REQUEST.SHIPPER_CONTACT,   
//						 T_BOOKING_REQUEST.SHIPPER_PHONE,   
//						 T_BOOKING_REQUEST.SHIPPER_FAX,   
//						 T_BOOKING_REQUEST.SHIPPER_EMAIL,   
//						 T_BOOKING_REQUEST.BOOKER_NAME,   
//						 T_BOOKING_REQUEST.BOOKER_ADDRESS,   
//						 T_BOOKING_REQUEST.BOOKER_CITY,   
//						 T_BOOKING_REQUEST.BOOKER_STATE,   
//						 T_BOOKING_REQUEST.BOOKER_ZIP,   
//						 T_BOOKING_REQUEST.BOOKER_PHONE,   
//						 T_BOOKING_REQUEST.BOOKER_FAX,   
//						 T_BOOKING_REQUEST.BOOKER_EMAIL,   
//						 T_BOOKING_REQUEST.RCVR_NAME,   
//						 T_BOOKING_REQUEST.RCVR_ADDRESS,   
//						 T_BOOKING_REQUEST.RCVR_CITY,   
//						 T_BOOKING_REQUEST.RCVR_STATE,   
//						 T_BOOKING_REQUEST.RCVR_ZIP,   
//						 T_BOOKING_REQUEST.RCVR_PHONE,   
//						 T_BOOKING_REQUEST.RCVR_FAX,   
//						 T_BOOKING_REQUEST.RCVR_EMAIL,   
//						 T_BOOKING_REQUEST.ACMS_STATUS_CD,   
//						 T_BOOKING_REQUEST.CONFIRM_CD,   
//						 T_BOOKING_REQUEST.PARTNER_CD,   
//						 T_BOOKING_REQUEST.BOOKING_ID,   
//						 ' ' as c_select,   
//						 '              ' as c_warning,   
//						 T_BOOKING_REQUEST.TRANS_CTL_NO,   
//						 T_BOOKING_REQUEST.TRANS_SEQ_NO,   
//						 (select count(*) from t_booking_request_error a where a.trans_ctl_no = t_booking_request.trans_ctl_no and a.trans_seq_no = t_booking_request.trans_seq_no)  as c_error,   
//						 ' ' as c_dummy,   
//						 R_ACMS_STATUS.PROCESSED_CD,  
//						 R_ACMS_STATUS.ACMS_STATUS_DSC, 
//							special_handling_cd,
//							case
//								when confirm_cd = 'N' then 0
//								when t_booking_request.acms_status_cd like 'P%' then 0
//								else 1
//							end sort_key,
//							(select count(*) from t_booking_unit where
//									t_booking_request.partner_request_cd = t_booking_unit.partner_request_cd) c_detail_count,
//						(select count(*)
//						  from t_booking_itv
//						  where t_booking_request.booking_id = t_booking_itv.booking_id
//							  and activity_code = 'I') as ingates,
//								  (select count(*)
//						  from t_booking_itv
//						  where t_booking_request.booking_id = t_booking_itv.booking_id
//							  and activity_code = 'VD') as departs,
//								  (select count(*)
//						  from t_booking_itv
//						  where t_booking_request.booking_id = t_booking_itv.booking_id
//							  and activity_code = 'VA') as arrives,
//						  t_booking_request.move_type_cd,
//					  (select count(*) from t_booking_request b2
//						where b2.partner_request_cd = t_booking.partner_request_cd) as pcfn_count,
//						adj_rdd_dt,
//						f_get_avss_eta_dt(substr(t_booking.voyage_no,1,5), t_booking.pod_terminal_cd) as est_date,
//						t_booking.sea_air_flg,
//						t_booking.voyage_no,
//						t_booking_request.vessel_cd,
//						(select max(vessel_cd) from t_voyage where t_booking.voyage_no = t_voyage.voyage_cd) as bk_vessel_cd,
//						xs.final_booking_no,
//						xs.voyage_no,
//						xs.pol_location_cd,
//						xs.pod_location_cd,
//						t_booking_request.voyage_no || '-' || t_booking_request.vessel_cd as request_voyves,
//					    t_booking.voyage_no || '-' || t_booking.vessel_cd as booked_voyves,
//						t_booking.location_poe_cd as booked_poe_cd,
//					    t_booking.location_pod_cd as booked_pod_cd,
//						t_booking.location_plor_cd,
//					    t_booking.location_plod_cd,
//						t_booking.poe_terminal_cd,
//						t_booking.pod_terminal_cd,
//						t_booking.voyage_no as booked_voyage_no,
//						case when xs.voyage_no is null then 'N' else 'Y' end as xs_flg,
//									case when hazmat_class_cd like '%7%' then 'RadioActive.jpg' else '' end as rx_jpg,
//						nvl(trunc(adj_rdd_dt) - trunc(f_get_avss_eta_dt(substr(t_booking.voyage_no,1,5), t_booking.pod_terminal_cd)),0)
//							as due_eta_diff
//
//					FROM T_BOOKING_REQUEST 
//						left outer join R_ACMS_STATUS on t_booking_request.acms_status_cd = r_acms_status.acms_status_cd 
//						inner join t_booking on t_booking_request.partner_cd = t_booking.partner_cd and
//		 							  t_booking_request.partner_request_cd = t_booking.partner_request_cd
//						left outer join t_transshipment xs on t_booking_request.booking_id = xs.booking_no "
//                    );

//                        if (bJustStena)
//            {
//                sb.AppendFormat(@" inner join r_stena_route sr on
//                                      sr.pol_location_cd = t_booking.location_poe_cd and
//                                      sr.pod_location_cd = t_booking.location_pod_cd ");
//            }
//            sb.AppendFormat (@"
//				   WHERE 
//						 trim(T_BOOKING_REQUEST.PARTNER_CD) like '{0}'  AND  
//						 T_BOOKING_REQUEST.PARTNER_REQUEST_CD like '{1}' and
//						 t_booking_request.request_dt > sysdate - {2}  and
//						 nvl(trim(t_booking_request.booking_id),'$') like '{3}' and
//						 T_BOOKING_REQUEST.VOYAGE_NO like '{4}' and
//						 NVL(T_BOOKING.LOCATION_POE_CD,'$') like '{5}' and
//						 NVL(T_BOOKING.LOCATION_POD_CD,'$') like '{6}'
//						 /*
//						 (NVL(T_BOOKING_REQUEST.VESSEL_DSC,'$') like :as_vessel_cd ) AND  
//						 NVL(T_BOOKING_REQUEST.POD_LOCATION_CD,'$') like :as_pod AND  
//						 NVL(T_BOOKING_REQUEST.POE_LOCATION_CD,'$') like :as_poe AND  
//							t_booking_request.confirm_cd like :as_confirmed AND
//							t_booking.location_poe_cd like :as_booked_poe and
//							t_booking.location_pod_cd like :as_booked_pod 
//						  */
//						 ",
//                          sPartner, sPCFN, iDays, sBookingNo, sVoyage, sPOL, sPOD);

//            if (sSerialNo != "%" && !string.IsNullOrEmpty(sSerialNo))
//            {
//                sb.AppendFormat(@"
//					and exists (
//						select 1 from t_booking_unit bu
//							where tcn like '{0}' 
//                              and bu.partner_request_cd = t_booking_request.partner_request_cd )",
//                       sSerialNo);
//            }

//            if (bJustUnprocessed)
//            {
//                sb.AppendFormat(@" and 'N' in (R_ACMS_STATUS.PROCESSED_CD, t_booking_request.confirm_cd) ");
//            }
//            string sql = sb.ToString();
//            DataTable dt =	Connection.GetDataTable(sql);
//            return dt;
//        }

		public static DataRow GetBooking(string sPartnerCd, string sPartnerRequestCd)
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendFormat(@"
				select b.*
                  FROM T_BOOKING b
                   where b.partner_cd = '{0}'
                     and b.partner_request_cd = '{1}' ",
				sPartnerCd, sPartnerRequestCd);
			string sql = sb.ToString();
			DataTable dt = Connection.GetDataTable(sql);
			if (dt.Rows.Count < 1)
				return null;
			return dt.Rows[0];
		}

		public static DataTable SelectVoyageVessesl(int Days)
		{
			string sql = string.Format(@"
			select voyage_cd || '-' || vessel_cd as voyage_vessel from mv_voyage
				where sail_dt > sysdate - {0} ", Days);
			return Connection.GetDataTable(sql);
		}
		#endregion

	}

}
