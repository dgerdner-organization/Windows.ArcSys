using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using CS2010.Common;
using CS2010.ArcSys.Business;
using System.Diagnostics;
using System.IO;

namespace CS2010.ArcSys.Business
{
	public class ClsCommercialEDICreate
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ArcSys"]; }
		}
		#endregion		// #region Connection Manager

		#region Attributes
		protected static string sqlCatchAll = string.Format(@"
				insert into t_itv
				select 
				 itv_id_seq.nextval, sysdate, 'EDIADMIN', sysdate, 'EDIADMIN',
				 isa_nbr, trading_partner_cd, cargo_key, cargo_line_id,
				 serial_no, activity_dt + @TIMEDIFF, '@INSCODE', booking_no, bol_no,
				 location_cd, voyage_no, vessel_cd, departure_dt, arrival_dt,
				 plor_location_cd, pol_location_cd, pod_location_cd, plod_location_cd,
				 actual_departure_flg, actual_arrival_flg
				 from t_itv itv
				 where trading_partner_cd = '@PARTNER'
				  and activity_cd = '@DEPCODE'
				  and not exists
				   (select 1
					 from t_itv i2
					  where i2.cargo_key = itv.cargo_key
						and i2.activity_cd = '@INSCODE'
						and i2.trading_partner_cd = '@PARTNER'
					  )");

		#endregion

		#region Methods
		public static void CreateITV(string sPartner)
		{
			switch (sPartner)
			{
				case "CAT":
					CreateITV_CAT();
					break;
				case "NAC":
				case "IAL":
				case "AAL":
					CreateITV_Commercial(sPartner);
					Create_DoorMoveITV();
					break;
			}
		}

		private static void CreateITV_CAT()
		{
			//
			// This is specific to CAT, because we have to resend all 315's
			// if anything about the booking or cargo has changed.
			//
			StringBuilder sb = new StringBuilder();
			sb.AppendFormat(@"
				insert into t_itv
				select 
					itv_id_seq.nextval,
					sysdate,
					'DGERDNER',
					sysdate,
					'DGERDNER',
					null as isa_no,
					tpc.trading_partner_cd,
					c.cargo_key,
					c.cargo_line_id,
					c.serial_no,
					@ACTIVITYDT,
					'@ACTCD',
					b.booking_no,
					b.bol_no,
					@LOCCD,
					b.voyage_no,
					b.vessel_cd,
					rd_load.DEPARTURE_DT,
					rd_dis.arrival_dt,
					b.plor_location_cd,
					b.pol_location_cd,
					b.pod_location_cd,
					b.plod_location_cd,
					rd_load.ACTUAL_DEPARTURE_FL,
					rd_dis.ACTUAL_ARRIVAL_FL
				from t_booking_line b
					inner join r_trading_partner_customer tpc
					  on b.customer_cd = tpc.customer_cd
					inner join t_cargo_line c
					  on b.booking_line_id = c.booking_line_id
					left outer join mv_voyage_route_detail rd_load
					  on b.voyage_no = rd_load.VOYAGE_CD
					  and b.pol_location_cd = rd_load.LOCATION_CD and rd_load.pol_pod = 'L'   
					left outer join mv_voyage_route_detail rd_dis
					  on b.voyage_no = rd_dis.VOYAGE_CD
					  and b.pod_location_cd = rd_dis.LOCATION_CD and rd_dis.pol_pod = 'D'   
				where tpc.trading_partner_cd = 'CAT'
				  and deleted_flg = 'N'
				  and cargo_rcvd_dt is not null
				  and rd_load.DEPARTURE_DT is not null
                  and rd_dis.arrival_dt is not null
				  and voyage_no not in 
						(select voyage_no from t_edi_voyage_exclude where trading_partner_cd = 'CAT')
				  and (c.serial_no is not null or c.container_no is not null) 
					@WHERECLAUSE
				and not exists
				(select 1 from t_itv i
					where  i.cargo_line_id = c.cargo_line_id
					and i.activity_cd = '@ACTCD'
					and i.booking_no = b.booking_no
					and i.location_cd = @LOCCD
					and i.voyage_no = b.voyage_no
					and i.vessel_cd = b.vessel_cd
					and i.plor_location_cd = b.plor_location_cd
					and i.pol_location_cd = b.pol_location_cd
					and i.pod_location_cd = b.pod_location_cd
					and i.plod_location_cd = b.plod_location_cd
					and i.serial_no = c.serial_no
					)");

			// In Gate
			StringBuilder sqlInGate = new StringBuilder(sb.ToString());
			sqlInGate = sqlInGate.Replace("@ACTCD", "CO");
			sqlInGate = sqlInGate.Replace("@LOCCD", "b.pol_location_cd");
			//sqlInGate = sqlInGate.Replace("@ACTIVITYDT", "cargo_rcvd_dt");
			sqlInGate = sqlInGate.Replace("@ACTIVITYDT", "cargo_rcvd_dt");
			sqlInGate = sqlInGate.Replace("@WHERECLAUSE", " and cargo_rcvd_dt is not null ");
			string s = sqlInGate.ToString();
			int iRC = Connection.RunSQL(s, CommandType.Text);

			// Vessel Depart
			StringBuilder sqlVD = new StringBuilder(sb.ToString());
			sqlVD = sqlVD.Replace("@ACTCD", "VD");
			sqlVD = sqlVD.Replace("@LOCCD", "b.pol_location_cd");
			sqlVD = sqlVD.Replace("@ACTIVITYDT", "rd_load.DEPARTURE_DT");
			//sqlVD = sqlVD.Replace("@ACTIVITYDT", "sysdate");
			sqlVD = sqlVD.Replace("@WHERECLAUSE", " and rd_load.actual_departure_fl = 'Y' ");
			s = sqlVD.ToString();
			iRC = Connection.RunSQL(s, CommandType.Text);

			// Vessel Arrive
			StringBuilder sqlVA = new StringBuilder(sb.ToString());
			sqlVA = sqlVA.Replace("@WHERECLAUSE", " and rd_dis.actual_arrival_fl = 'Y' ");
			sqlVA = sqlVA.Replace("@ACTIVITYDT", "rd_dis.arrival_dt");
			//sqlVA = sqlVA.Replace("@ACTIVITYDT", "sysdate");
			sqlVA = sqlVA.Replace("@ACTCD", "VA");
			sqlVA = sqlVA.Replace("@LOCCD", "b.pod_location_cd");
			s = sqlVA.ToString();
			iRC = Connection.RunSQL(s, CommandType.Text);

			// Vessel Discharge
			StringBuilder sqlUV = new StringBuilder(sb.ToString());
			sqlUV = sqlUV.Replace("@WHERECLAUSE", " and rd_dis.actual_arrival_fl = 'Y' ");
			sqlUV = sqlUV.Replace("@ACTIVITYDT", "rd_dis.arrival_dt");
			//sqlUV = sqlUV.Replace("@ACTIVITYDT", "sysdate");
			sqlUV = sqlUV.Replace("@ACTCD", "UV");
			sqlUV = sqlUV.Replace("@LOCCD", "b.pod_location_cd");
			s = sqlUV.ToString();
			iRC = Connection.RunSQL(s, CommandType.Text);

			// Release
			StringBuilder sqlCR = new StringBuilder(sb.ToString());
			sqlCR = sqlCR.Replace("@WHERECLAUSE", " and bol_status = 'L' ");
			sqlCR = sqlCR.Replace("@ACTIVITYDT", "rd_dis.arrival_dt");
			//sqlCR = sqlCR.Replace("@ACTIVITYDT", "sysdate");
			sqlCR = sqlCR.Replace("@ACTCD", "CR");
			sqlCR = sqlCR.Replace("@LOCCD", "b.pod_location_cd");
			s = sqlCR.ToString();
			iRC = Connection.RunSQL(s, CommandType.Text);
		}

		private static void CreateITV_Commercial(string sPartner)
		{
			//
			// This is a generic build for any commercial partner
			//
			// !Need to change where clause for SDDC->NAC
			// and probably remove tariff_cd check.
			// !Also remove sysdate > 30 check
			// !Also stop using test sequence
			StringBuilder sb = new StringBuilder();
//            sb.AppendFormat(@"
//				insert into t_itv
//				select 
//				  /*row_number() over (order by cargo_line_id asc) + 1000000,*/
//				  itv_id_seq.nextval,
//				  sysdate,
//				  'EDIAdmin',
//				  sysdate,
//				  'EDIAdmin',
//				  null as isa_no,
//				  tpc.trading_partner_cd,
//				  c.cargo_key,
//				  c.cargo_line_id,
//				  c.serial_no,
//				  @ACTIVITYDT,
//				  '@ACTCD',
//				  b.booking_no,
//				  b.bol_no,
//				  @LOCCD,
//				  b.voyage_no,
//				  b.vessel_cd,
//				  f_voyage_dt(b.voyage_no, b.pol_location_cd, b.pol_berth, 'L') as DEPARTURE_DT,
//				  f_voyage_dt(b.voyage_no, b.pod_location_cd, b.pod_berth, 'D') as arrival_dt,
//				  b.plor_location_cd,
//				  b.pol_location_cd,
//				  b.pod_location_cd,
//				  b.plod_location_cd,
//				  f_voyage_actual_flg(b.voyage_no, b.pol_location_cd, b.pol_berth, 'L')as ACTUAL_DEPARTURE_FL,
//				  f_voyage_actual_flg(b.voyage_no, b.pod_location_cd, b.pod_berth, 'D') as ACTUAL_ARRIVAL_FL
//				from t_booking_line b
//				  inner join r_trading_partner_customer tpc
//					on b.customer_cd = tpc.customer_cd
//				  inner join t_cargo_line c
//					on b.booking_line_id = c.booking_line_id
//				where tpc.trading_partner_cd = '@PARTNERCD'
//				  /*and tariff_cd = 'RMOEF'*/
//				  and deleted_flg = 'N'
//				  and cargo_rcvd_dt is not null
//				  and f_voyage_dt(b.voyage_no, b.pol_location_cd, b.pol_berth, 'L') is not null
//				  and f_voyage_dt(b.voyage_no, b.pod_location_cd, b.pod_berth, 'D') is not null
//				  and voyage_no not in 
//					(select voyage_no from t_edi_voyage_exclude where trading_partner_cd = tpc.trading_partner_cd)
//				  and (c.serial_no is not null or c.container_no is not null) 
//				  and cargo_rcvd_dt > sysdate - 120
//					@WHERECLAUSE
//				  and not exists
//						(select 1 from t_itv i
//							where  i.cargo_line_id = c.cargo_line_id
//							and i.activity_cd = '@ACTCD'
//							and i.booking_no = b.booking_no
//							/*and i.location_cd = @LOCCD*/
//							and i.voyage_no = b.voyage_no
//							and i.vessel_cd = b.vessel_cd
//							and i.serial_no = c.serial_no
//							)
//				");
			// April 2016 DGERDNER - Changed this for performance.  Join to the voyage table and get actual flag and 
			//    dates directly from there, rather than using the functions.
			sb.AppendFormat(@"
				insert into t_itv
				select 
				  /*row_number() over (order by cargo_line_id asc) + 1000000,*/
				  itv_id_seq.nextval,
				  sysdate,
				  'EDIAdmin',
				  sysdate,
				  'EDIAdmin',
				  null as isa_no,
				  tpc.trading_partner_cd,
				  c.cargo_key,
				  c.cargo_line_id,
				  c.serial_no,
				  @ACTIVITYDT,
				  '@ACTCD',
				  b.booking_no,
				  b.bol_no,
				  @LOCCD,
				  b.voyage_no,
				  b.vessel_cd,
				  f_voyage_dt(b.voyage_no, b.pol_location_cd, b.pol_berth, 'L') as DEPARTURE_DT,
				  f_voyage_dt(b.voyage_no, b.pod_location_cd, b.pod_berth, 'D') as arrival_dt,
				  b.plor_location_cd,
				  b.pol_location_cd,
				  b.pod_location_cd,
				  b.plod_location_cd,
				  f_voyage_actual_flg(b.voyage_no, b.pol_location_cd, b.pol_berth, 'L')as ACTUAL_DEPARTURE_FL,
				  f_voyage_actual_flg(b.voyage_no, b.pod_location_cd, b.pod_berth, 'D') as ACTUAL_ARRIVAL_FL
				from t_booking_line b
				  inner join r_trading_partner_customer tpc
					on b.customer_cd = tpc.customer_cd
				  inner join t_cargo_line c
					on b.booking_line_id = c.booking_line_id
				 left outer join mv_voyage_route_detail rd_load
				    on substr(b.voyage_no,0,5)= substr(rd_load.VOYAGE_CD,0,5)
				        /*and b.pol_location_cd = rd_load.LOCATION_CD and rd_load.pol_pod = 'L'*/
                        and b.pol_berth = rd_load.terminal_cd and rd_load.pol_pod = 'L'
				 left join mv_voyage_route_detail rd_dis
				    on substr(b.voyage_no,0,5) = substr(rd_dis.VOYAGE_CD,0,5)
					    and b.pod_location_cd = rd_dis.LOCATION_CD and rd_dis.pol_pod = 'D'  
				where tpc.trading_partner_cd = '@PARTNERCD'
				  and deleted_flg = 'N'
				  and cargo_rcvd_dt is not null
				   and cargo_rcvd_dt is not null 
				   and rd_load.etd_dt is not null
				  and voyage_no not in 
					(select voyage_no from t_edi_voyage_exclude where trading_partner_cd = tpc.trading_partner_cd)
				  and (c.serial_no is not null or c.container_no is not null) 
				  and cargo_rcvd_dt > sysdate - 180
					@WHERECLAUSE
				  and not exists
						(select 1 from t_itv i
							where  i.cargo_line_id = c.cargo_line_id
							and i.activity_cd = '@ACTCD'
							and i.booking_no = b.booking_no
							/*and i.location_cd = @LOCCD*/
							and i.voyage_no = b.voyage_no
							and i.vessel_cd = b.vessel_cd
							and i.serial_no = c.serial_no
							)
				");
			sb.Replace("@PARTNERCD", sPartner);

			// In Gate
			//  Happens whenever the "cargo received date" is not empty
			StringBuilder sqlInGate = new StringBuilder(sb.ToString());
			sqlInGate = sqlInGate.Replace("@ACTCD", "I");
			sqlInGate = sqlInGate.Replace("@LOCCD", "b.pol_location_cd");
			sqlInGate = sqlInGate.Replace("@ACTIVITYDT", "cargo_rcvd_dt");
			//sqlInGate = sqlInGate.Replace("@ACTIVITYDT", "sysdate");
			sqlInGate = sqlInGate.Replace("@WHERECLAUSE", " and cargo_rcvd_dt is not null ");
			string s = sqlInGate.ToString();
			int iRC = Connection.RunSQL(s, CommandType.Text);
			
			// Loaded on Vessel (AE)
			//  Happens whenever the vessel_load_dt is not null
			//  ! Need to revisit this, because the vessel load dt is always null now
			StringBuilder sqlLoad = new StringBuilder(sb.ToString());
			sqlLoad = sqlLoad.Replace("@ACTCD", "AE");
			sqlLoad = sqlLoad.Replace("@LOCCD", "b.pol_location_cd");
			sqlLoad = sqlLoad.Replace("@ACTIVITYDT", "vessel_load_dt");
			sqlLoad = sqlLoad.Replace("@WHERECLAUSE", " and vessel_load_dt is not null ");
			string sAE = sqlLoad.ToString();
			iRC = Connection.RunSQL(sAE, CommandType.Text);

			// Vessel Depart
			//  Happens when the pol actual flag is "Y" (from AVSS)
			StringBuilder sqlVD = new StringBuilder(sb.ToString());
			sqlVD = sqlVD.Replace("@ACTCD", "VD");
			sqlVD = sqlVD.Replace("@LOCCD", "b.pol_location_cd");
			sqlVD = sqlVD.Replace("@ACTIVITYDT", "f_voyage_dt(b.voyage_no, b.pol_location_cd, b.pol_berth, 'L')");
			//sqlVD = sqlVD.Replace("@ACTIVITYDT", "sysdate");
			sqlVD = sqlVD.Replace("@WHERECLAUSE", " and rd_load.actual_departure_fl = 'Y' ");
			string sVD = sqlVD.ToString();
			iRC = Connection.RunSQL(sVD, CommandType.Text);

			// Loaded on Vessel Catch All (AE)
			//   When a vessel departs, add an "AE" for all cargo
			//   that has not yet had an AE sent.
			StringBuilder sqlAE = new StringBuilder();
			sqlAE.AppendFormat(sqlCatchAll);
			sqlAE.Replace("@PARTNER", sPartner);
			sqlAE.Replace("@INSCODE", "AE");
			sqlAE.Replace("@DEPCODE", "VD");
			sqlAE.Replace("@TIMEDIFF", "-.1");
			sAE = sqlAE.ToString();
			iRC = Connection.RunSQL(sAE, CommandType.Text);
		
			
			// Vessel Arrive
			StringBuilder sqlVA = new StringBuilder(sb.ToString());
			sqlVA = sqlVA.Replace("@WHERECLAUSE", " and rd_dis.actual_arrival_fl = 'Y' ");
			sqlVA = sqlVA.Replace("@ACTIVITYDT", "f_voyage_dt(b.voyage_no, b.pod_location_cd, b.pod_berth, 'D')");
			sqlVA = sqlVA.Replace("@ACTCD", "VA");
			sqlVA = sqlVA.Replace("@LOCCD", "b.pod_location_cd");
			s = sqlVA.ToString();
			iRC = Connection.RunSQL(s, CommandType.Text);

			
			// Vessel Discharge
			StringBuilder sqlUV = new StringBuilder(sb.ToString());
			sqlUV = sqlUV.Replace("@WHERECLAUSE", " and rd_dis.actual_arrival_fl = 'Y' ");
			sqlUV = sqlUV.Replace("@ACTIVITYDT", "f_voyage_dt(b.voyage_no, b.pod_location_cd, b.pod_berth, 'D') + .1");
			sqlUV = sqlUV.Replace("@ACTCD", "UV");
			sqlUV = sqlUV.Replace("@LOCCD", "b.pod_location_cd");
			s = sqlUV.ToString();
			iRC = Connection.RunSQL(s, CommandType.Text);

			// Outgate at POD (Exactly the same as Vessel Discharge;
			//   except not for Door Our moves
			StringBuilder sqlOA = new StringBuilder(sb.ToString());
			sqlOA = sqlOA.Replace("@WHERECLAUSE", " and rd_dis.actual_arrival_fl = 'Y' ");
			sqlOA = sqlOA.Replace("@ACTIVITYDT", "f_voyage_dt(b.voyage_no, b.pod_location_cd, b.pod_berth, 'D') + .1");
			sqlOA = sqlOA.Replace("@ACTCD", "OA");
			sqlOA = sqlOA.Replace("@LOCCD", "b.pod_location_cd");
			sqlOA = sqlOA.AppendFormat(" and c.move_type_cd not in ('F7','F8','F9') ");
			s = sqlOA.ToString();
			iRC = Connection.RunSQL(s, CommandType.Text);

			// Available (Exactly the same as Vessel Discharge;
			//   except not for Door Our moves
			StringBuilder sqlAV = new StringBuilder(sb.ToString());
			sqlAV = sqlAV.Replace("@WHERECLAUSE", " and rd_dis.actual_arrival_fl = 'Y' ");
			sqlAV = sqlAV.Replace("@ACTIVITYDT", "f_voyage_dt(b.voyage_no, b.pod_location_cd, b.pod_berth, 'D') + .1");
			sqlAV = sqlAV.Replace("@ACTCD", "AV");
			sqlAV = sqlAV.Replace("@LOCCD", "b.pod_location_cd");
			sqlAV = sqlAV.AppendFormat(" and c.move_type_cd not in ('F7','F8','F9') ");
			s = sqlAV.ToString();
			iRC = Connection.RunSQL(s, CommandType.Text);

			// Delivered (Exactly the same as OA)
			StringBuilder sqlX1 = new StringBuilder(sb.ToString());
			sqlX1 = sqlX1.Replace("@WHERECLAUSE", " and rd_dis.actual_arrival_fl = 'Y' ");
			sqlX1 = sqlX1.Replace("@ACTIVITYDT", "f_voyage_dt(b.voyage_no, b.pod_location_cd, b.pod_berth, 'D') + .1");
			sqlX1 = sqlX1.Replace("@ACTCD", "X1");
			sqlX1 = sqlX1.Replace("@LOCCD", "b.pod_location_cd");
			sqlX1 = sqlX1.AppendFormat(" and c.move_type_cd not in ('F7','F8','F9') ");
			s = sqlX1.ToString();
			iRC = Connection.RunSQL(s, CommandType.Text);


		}

		private static void Create_DoorMoveITV()
		{
			try
			{
				List<DbParameter> p = new List<DbParameter>();
				p.Add(Connection.GetParameter("IN_DAYS", 180));

				Connection.RunSQL("ARC_OWNER.P_INTERMODAL_ITV_COMMERCIAL",
					CommandType.StoredProcedure, p.ToArray());
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public static void RunMap(string sPartner, string sMap)
		{
			//
			// Expand upon this in the future to use configuration
			// setup in the db.
			//
			ClsTradingPartner tp = ClsTradingPartner.GetUsingKey(sPartner);

			ClsTradingPartnerEdi ediInfo =
				ClsTradingPartnerEdi.GetByMap(tp.Trading_Partner_Cd, sMap);

			string sMercatorEXE = "\\\\guardianedge\\acms\\edi\\mercator\\Mercator6.5\\mercnt.exe";
			string sMapPath = "\\\\guardianedge\\acms\\CommercialEDI\\maps\\CAT\\";
			string sMapFile = "315Outbound_cat.mmc";
			string sOutPath = "\\\\commserver01\\in_out\\CAT315_Exp\\out\\";
			string sPrefix = "315OUT_";
			string sScriptPath = "\\\\guardianedge\\acms\\CommercialEDI\\scripts\\CAT\\";

			sMapPath = ediInfo.Map_Path;
			sMapFile = ediInfo.Map_File_Nm;
			sOutPath = ediInfo.File_Path;
			sPrefix = ediInfo.Prefix;
			sScriptPath = ediInfo.Script_Path;

			string sISA = tp.Outbound_Isa_Nbr.ToString();
			string sSuffix = ".txt";
			string sScriptName = sMap + ".bat";

			StringBuilder sbCommand = new StringBuilder();
			sbCommand.AppendFormat(@"{0} {1}{2} -B -OF1 {3}{4}{5}{6} ",
				sMercatorEXE, sMapPath, sMapFile, sOutPath, sPrefix, sISA, sSuffix);

			string sCmd = sbCommand.ToString();

			string sFullScriptPath = sScriptPath + sScriptName;
			StreamWriter strm = new StreamWriter(sFullScriptPath, false);
			strm.WriteLine(sCmd);
			strm.Close();

			using (Process mapMaprocess = Process.Start(sFullScriptPath))
			{
				mapMaprocess.WaitForExit();
			}


		}
		#endregion
	}
}
