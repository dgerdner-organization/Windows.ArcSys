using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;
using CS2010.ACMS.Business;
using ASL.ARC.EDISQLTools;

namespace CS2010.ArcSys.Business
{
	public partial class ClsEdiInboundSi
	{
		public void DeleteSI()
		{
			string sql = string.Format("delete from t_edi_inbound_si where Edi_Inbound_Si_ID = {0}",
				this.Edi_Inbound_Si_ID);
			Connection.RunSQL(sql);
		}
		public static DataTable GetBookingSummary(int iDays)
		{
			string sql = string.Format(@"
				select si.booking_no, dtl.vehicle_type_cd, 
					  v.voyage_no, v.pol_location_cd, v.pod_location_cd,
					  count(si.booking_no) as ial_count,
					   case
						 when dtl.vehicle_type_cd like 'CAR%' then
						   (select count(*) from v_booking_cargo_line cl where cl.booking_no = si.booking_no and cl.model_cd like 'CAR%' and cl.serial_no is not null)
						 when dtl.vehicle_type_cd like 'VAN%' then 
							 (select count(*) from v_booking_cargo_line cl where cl.booking_no = si.booking_no and cl.model_cd like 'VAN%' and cl.serial_no is not null)
							 else 0 end as line_count,
						case
						  when dtl.vehicle_type_cd like 'CAR%' then               
						   (select count(*) from v_booking_cargo_line cl where cl.booking_no = si.booking_no and cl.model_cd like 'CAR%' and cl.serial_no is not null and cl.cargo_rcvd_dt is not null)
						   when dtl.vehicle_type_cd like 'VAN%' then
						   (select count(*) from v_booking_cargo_line cl where cl.booking_no = si.booking_no and cl.model_cd like 'VAN%' and cl.serial_no is not null and cl.cargo_rcvd_dt is not null)
						   else 0 end as rcvd_count,
                            'N' as invalid_cargo_type
						  from t_edi_inbound_si  si
						   left outer join t_edi_inbound_detail dtl
								on si.booking_no = dtl.booking_no and si.vin = dtl.vin
						   inner join t_booking_line v 
							  on v.booking_no = si.booking_no
						where si.modify_dt > sysdate - {0}
						 and si.processed_flg = 'N'
				 group by si.booking_no, dtl.vehicle_type_cd, v.voyage_no, v.pol_location_cd, v.pod_location_cd
				  order by si.booking_no, dtl.vehicle_type_cd", iDays);

            DataTable dt = Connection.GetDataTable(sql);
            foreach (DataRow dr in dt.Rows)
                if (ClsEdiInboundSi.CheckVinRecallBooking(dr[0].ToString(), dr[1].ToString())) dr[8] = "Y";

            return dt;
		}

        public static DataTable GetBookingSummaryWithRecallWarnings(int iDays)
        {
            //
            // This is for the IAL Dashboard SI tab
            //
               
            string sql = string.Format(@"
				select 
                    si.booking_no, 
                    dtl.vehicle_type_cd, 
					v.voyage_no, 
                    v.pol_location_cd, 
                    v.pod_location_cd,
					count(si.booking_no) as ial_count,
					case
					    when dtl.vehicle_type_cd like 'CAR%' then
						    (select count(*) from v_booking_cargo_line cl where cl.booking_no = si.booking_no and cl.model_cd like 'CAR%' and cl.serial_no is not null)
						when dtl.vehicle_type_cd like 'VAN%' then 
							(select count(*) from v_booking_cargo_line cl where cl.booking_no = si.booking_no and cl.model_cd like 'VAN%' and cl.serial_no is not null)
					    else 0 end as line_count,
					case
					    when dtl.vehicle_type_cd like 'CAR%' then               
						    (select count(*) from v_booking_cargo_line cl where cl.booking_no = si.booking_no and cl.model_cd like 'CAR%' and cl.serial_no is not null and cl.cargo_rcvd_dt is not null)
						when dtl.vehicle_type_cd like 'VAN%' then
						    (select count(*) from v_booking_cargo_line cl where cl.booking_no = si.booking_no and cl.model_cd like 'VAN%' and cl.serial_no is not null and cl.cargo_rcvd_dt is not null)
						else 0 end as rcvd_count,
                    'N' as invalid_cargo_type
				from t_edi_inbound_si  si
				    left outer join t_edi_inbound_detail dtl
					    on si.booking_no = dtl.booking_no and si.vin = dtl.vin
					inner join t_booking_line v 
					    on v.booking_no = si.booking_no
				where si.modify_dt > sysdate - {0}
				    and si.processed_flg = 'Y' 
				group by si.booking_no, dtl.vehicle_type_cd, v.voyage_no, v.pol_location_cd, v.pod_location_cd
			    order by si.booking_no, dtl.vehicle_type_cd", iDays);

			// DGERDNER DEC2017 - Updated this logic for performance
            // DGERDNER JAN2020 - subqueries join on cargo pkg_type_cd instead of model_cd
            //                    because starting with OCEAN bookings we store the actual
            //                    model in model_cd now.
            //  DGERDNER FEB2020 - Rever back to old code, because we are NOT going to store
            //                    the actual make/model in OCEAN, after all
//            sql = string.Format(@"
//			 select 
//						si.booking_no, 
//						dtl.vehicle_type_cd, 
//				v.voyage_no, 
//						v.pol_location_cd, 
//						v.pod_location_cd,
//				count(si.booking_no) as ial_count,
//				(select count(*)
//					from t_booking_line bl inner join t_cargo_line cl on cl.booking_line_id = bl.booking_line_id
//					where bl.booking_no = si.booking_no
//						and cl.pkg_type_cd like dtl.vehicle_type_cd || '%'
//						and cl.serial_no is not null) as line_count,
//				(select count(*)
//					from t_booking_line bl inner join t_cargo_line cl on cl.booking_line_id = bl.booking_line_id
//					where bl.booking_no = si.booking_no
//						and cl.pkg_type_cd like dtl.vehicle_type_cd || '%'
//						and cl.serial_no is not null) as rcvd_count,                 
//				'N' as invalid_cargo_type
//			from t_edi_inbound_si  si
//				left outer join t_edi_inbound_detail dtl
//					on si.booking_no = dtl.booking_no and si.vin = dtl.vin
//				inner join t_booking_line v 
//					on v.booking_no = si.booking_no
//			where si.modify_dt > sysdate - 90
//				and si.processed_flg = 'N'
//			group by si.booking_no, dtl.vehicle_type_cd, v.voyage_no, v.pol_location_cd, v.pod_location_cd
//				order by si.booking_no, dtl.vehicle_type_cd", iDays);

            DataTable dt = Connection.GetDataTable(sql);

            foreach (DataRow dr in dt.Rows)
                if (ClsEdiInboundSi.CheckVinRecallBooking(dr[0].ToString(), dr[1].ToString())) dr[8] = "Y";
            
            return dt;

        }


		public static DataTable GetUnprocessed(bool bShowAll,int iDays, string sBookingNo, string sVIN)
		{
			string sql = string.Format(@"select si.*, dtl.vehicle_type_cd,
					 case 
						   when dtl.edi_inbound_detail_id is null then '*Missing Detail*' else si.process_msg end as final_msg,
					v.cargo_rcvd_dt,
					case
						  when v.cargo_rcvd_dt is null
							then 'N' else 'Y' end as cargo_rcvd_flg,
				   (select count(*) from v_booking_cargo_line cl where cl.booking_no = si.booking_no and cl.item_no = 1 and cl.serial_no is not null) as line_car_cnt,
				   (select count(*) from v_booking_cargo_line cl where cl.booking_no = si.booking_no and cl.item_no = 2 and cl.serial_no is not null) as line_van_cnt
					from t_edi_inbound_si  si
					 left outer join t_edi_inbound_detail dtl
					      on si.booking_no = dtl.booking_no and si.vin = dtl.vin
					 left outer join v_booking_cargo_line v 
						  on v.booking_no = si.booking_no and v.serial_no = si.vin
				where si.modify_dt > sysdate - {0} 
				  ", iDays);
			if (!bShowAll)
				sql = sql + " and si.processed_flg = 'N' ";
			if (!string.IsNullOrEmpty(sBookingNo))
				sql = sql + string.Format(" and si.booking_no like '{0}' ", sBookingNo);
			if (!string.IsNullOrEmpty(sVIN))
				sql = sql + string.Format(" and si.vin like '{0}' ", sVIN);
			
			return Connection.GetDataTable(sql);

		}

		public static ClsEdiInboundSi GetByBookingVin(string sBookingNo, string sVIN)
		{
			string sql = string.Format
				(@"select * from t_edi_inbound_si 
					where booking_no = '{0}'  and vin = '{1}' ", sBookingNo, sVIN);
			DataRow drow = Connection.GetDataRow(sql);
			if (drow == null)
				return null;
			ClsEdiInboundSi si = new ClsEdiInboundSi(drow);
			return si;
		}

		public static DataTable MisMatchedVINS(ClsConnection conn)
		{
			string sql = string.Format(@"
				select si.booking_no, si.vin, si.last_nm as dsc_info, 'IAL Shipping Instruction with no detail' as error_msg
				 from t_edi_inbound_si si
				 where not exists
				 (select 1 from t_edi_inbound_detail dtl
				  where dtl.booking_no = si.booking_no and dtl.vin = si.vin)
				  union all
				select dtl.booking_no, dtl.vin, dtl.make, 'IAL Cargo Detail with no Shipping Instructions'
				 from t_edi_inbound_detail dtl
				 where not exists
				 (select 1 from t_edi_inbound_si si
				  where dtl.booking_no = si.booking_no and dtl.vin = si.vin) ");
			DataTable d = conn.GetDataTable(sql);
			return d;
		}

        public static DataTable ShippingInstructionsMissingAddress(ClsConnection conn)
        {
            string sql = @"
                Select si.booking_no, si.vin, si.first_nm, si.last_nm, si.processed_flg
                from T_EDI_INBOUND_SI si
                inner join t_booking_line bk on bk.booking_no = si.booking_no
                where 1=1
                and si.addr1 is null
                and bk.voyage_no like 'CB%'
                and si.create_dt > sysdate - 30
                ";

            return conn.GetDataTable(sql);

        }

        //public static void InspectShippingInstructions(ref DataTable dtShippingInstructions)
        //{
        //    DGERDNER March 2020
        //      Removed this because it appears not to be used, and because we should stop
        //      making calls directly to LINE database
        //
        //    // Review current shipping instructions for any problems
        //    foreach (DataRow drow in dtShippingInstructions.Rows)
        //    {
        //        ClsEdiInboundSi si = new ClsEdiInboundSi(drow);
        //        DataRow dr = ClsLineSQL.GetAvailableRoro(si.Booking_No, si.Vin, "%");
        //        if (dr != null)
        //            continue;
        //        si.Process_Msg = "* VIN not in LINE *";
        //        drow["process_msg"] = "* VIN Not In LINE *";
        //        //si.Update();
        //    }
        //}

		public static string Send304s()
		{
			bool bInTrans = Connection.IsInTransaction;
			if (!bInTrans)
				Connection.TransactionBegin();
			try
			{
				ClsTradingPartner tp = ClsTradingPartner.GetUsingKey("IAL");
				string sISA = tp.Outbound_Isa_Nbr.GetValueOrDefault().ToString();
				EdiInfo edi = new EdiInfo();
				StringBuilder sMsg = new StringBuilder();
				DataTable dt304IAL = ClsArcSQL.GetIAL304Out("%");

				sMsg.AppendLine("");
				sMsg.AppendFormat("{0} IAL Shipping Instructions to be transmitted to LINE", dt304IAL.Rows.Count);
				dt304IAL = ClsArcSQL.GetIAL304Out("W");
				if (dt304IAL.Rows.Count > 0)
				{
					edi = ClsMapsAndFTP.GetEDIInfo_IAL304_west();
					ClsMapsAndFTP.RunOutboundMap(edi, sISA);
				}
				dt304IAL = ClsArcSQL.GetIAL304Out("E");
				if (dt304IAL.Rows.Count > 0)
				{
					edi = ClsMapsAndFTP.GetEDIInfo_IAL304_east();
					ClsMapsAndFTP.RunOutboundMap(edi, sISA);
				}
				string sql = "delete from t_shipping_instructions_queue where booking_no like 'ARCA%'";
				Connection.RunSQL(sql);
				if (!bInTrans)
					Connection.TransactionCommit();
				return sMsg.ToString();
			}
			catch (Exception ex)
			{
				ClsErrorHandler.LogException(ex);
				if (!bInTrans)
					Connection.TransactionRollback();
				return ex.Message;
			}
		}

        /// <summary>
        /// This will check the VINS in the bookings selected and verify that the item in 
        /// LINE matches the item in ArcSys with respect to BATTERY DISCONNECTS (i.e. CAR->CARBD, VAN->VANBD)
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        public static List<string> CheckVinRecall(DataRow[] dr)
        {
            List<string> warnings = new List<string>();

            string BookingNo = string.Empty;
            List<string> Vins;

            foreach (DataRow d in dr)
            {
                BookingNo = d["booking_no"].ToString();
                Vins = ClsNhtsaRecall.GetVinsBatteryDisconnects(BookingNo);

                DataTable dt = ClsLineSQL.VINRecallsMismatched(BookingNo, Vins);

                if (dt.Rows.Count >= 1)
                    warnings.Add(string.Format("Vin '{0}' on Booking '{1}' has the cargo type of '{2}'.", 
                        dr[0].ToString(), 
                        dr[1].ToString(), 
                        dr[2].ToString()));  

            }

            return warnings;
        }

        public static bool CheckVinRecallBooking(string BookingNo)
        {
            List<string> warnings = new List<string>();

            List<string> Vins = ClsNhtsaRecall.GetVinsBatteryDisconnects(BookingNo);

            if (Vins.IsNull() || Vins.Count == 0) return false;

            DataTable dt = ClsLineSQL.VINRecallsMismatched(BookingNo, Vins);

            return (dt.Rows.Count >= 1);
        }

        public static bool CheckVinRecallBooking(string BookingNo, string CargoType)
        {
            List<string> warnings = new List<string>();

            List<string> Vins = ClsNhtsaRecall.GetVinsBatteryDisconnects(BookingNo, CargoType);

            if (Vins.IsNull() || Vins.Count == 0) return false;

            DataTable dt = ClsLineSQL.VINRecallsMismatched(BookingNo, Vins);

            return (dt.Rows.Count >= 1);
        }


		public static string PutInQueue(DataRow[] datarows)
		{
			bool bInTrans = Connection.IsInTransaction;
			if (!bInTrans)
				Connection.TransactionBegin();
			string sPrevious = "ZZZ";
			try
			{
				StringBuilder sbMsg = new StringBuilder();
				foreach (DataRow drow in datarows)
				{
					//ClsEdiInboundSi dtl = new ClsEdiInboundSi(drow);
					//if (dtl.Booking_No == sPrevious)
					//    continue;
					//sPrevious = dtl.Booking_No;
					//sbMsg.AppendLine(dtl.Booking_No);
					//ClsShippingInstructionsQueue q = new ClsShippingInstructionsQueue();
					//q.Booking_No = dtl.Booking_No;
					//q.Insert();
					string sBookingNo = drow["booking_no"].ToString();
					if (sBookingNo == sPrevious)
						continue;
					string sVehicleType = drow["vehicle_type_cd"].ToString();
					string sIAL = drow["ial_count"].ToString();
					string sLINE = drow["line_count"].ToString();
					string sRcvd = drow["rcvd_count"].ToString();
					sPrevious = sBookingNo;

					if (sVehicleType != "CAR" && sVehicleType != "VAN")
					{
						sbMsg.AppendLine("");
						sbMsg.AppendFormat("No Cargo Detail for {0}", sBookingNo);
						continue;
					}
					Int32? ial = ClsConvert.ToInt32Nullable(sIAL);
					Int32? line = ClsConvert.ToInt32Nullable(sLINE);
					Int32? rcvd = ClsConvert.ToInt32Nullable(sRcvd);
					if (ial.GetValueOrDefault() != line.GetValueOrDefault() ||
						ial.GetValueOrDefault() != rcvd.GetValueOrDefault() ||
						line.GetValueOrDefault() != rcvd.GetValueOrDefault())
					{
						sbMsg.AppendLine("");
						sbMsg.AppendFormat("Warning: IAL, LINE, and #Received do not match for {0}", sBookingNo);
					}
					sbMsg.AppendLine(sBookingNo);
					ClsShippingInstructionsQueue q = new ClsShippingInstructionsQueue();
					q.Booking_No = sBookingNo;
					q.Insert();
				}
				if (!bInTrans)
					Connection.TransactionCommit();
				string sMsg = string.Format("These bookings added to queue: {0}", sbMsg.ToString());
				return sMsg;
			}
			catch (Exception ex)
			{
				if (!bInTrans)
					Connection.TransactionRollback();
				return ex.Message;
			}
		}

		public static string UpdateLineBOLNo()
		{
			// 
			// This updates the BOL_NO in t_cargo_line with data received from 315's messages
			// that were received from LINE.  
			//
			bool bInTrans = Connection.IsInTransaction;
			if (!bInTrans)
				Connection.TransactionBegin();
			try
			{
				string sql = string.Format(@"
				update t_cargo_line 
				 set bol_no =
				 (
				select max(bill_of_lading_no)
				 from v_booking_activity_received bar
				  inner join t_booking_line bl on bl.booking_no = bar.booking_id
				  where bar.booking_id = bl.booking_no
				   and bar.item_identification = t_cargo_line.serial_no
				   and activity_cd = 'OB'
				   and processed_flg = 'N'
				)
				where cargo_line_id in
				 ( 
				 select cargo_line_id
				   from v_booking_cargo_line bcl
						inner join r_trading_partner_customer tpc on tpc.customer_cd = bcl.customer_cd 
															  and tpc.trading_partner_cd = 'IAL'
						inner join t_edi_inbound_si si on si.vin = bcl.serial_no
													  and si.booking_no = bcl.booking_no  
													  and si.processed_flg = 'Y'                                            
					where bcl.cargo_bol_no is null
					  and bcl.booking_dt > '01-JAN-2015'
					  and deleted_flg = 'N'
					)");
				int iRc = Connection.RunSQL(sql, CommandType.Text);
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
	}
}
