using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;
using CS2010.ArcSys.Business;
using System.Data.SqlClient;
using System.Configuration;

namespace CS2010.ArcSys.Business
{
	public class ClsImportLine
	{
		#region Fields
        private double InchesMultiplier = 0.393700787;
        private double PoundsMultiplier = 2.20462262;
        private string ItemNo;
		private string SerialNo;
		private string DeletedFlg;
		private string BookingNo;
		private string EDIRefNo;
		private string CustomerRefNo;
		private string BOLNo;
		private string VoyageNo;
		private string VesselCd;
        private string Plor;
        private string PlorDescription;
		private string POL;
        private string POLDescription;
		private string POD;
        private string PODDescription;
		private string Plod;
        private string PlodDescription;
		private string MakeCd;
		private string ModelCd;
		private string CommodityCd;
		private string CargoDsc;
		private decimal? Length;
		private decimal? Width;
		private decimal? Height;
		private decimal? Weight;
		private string MoveTypeCd;
        private string CargoTypeCd;
        private string ContainerNo;
        private string Seal1;
        private string Seal2;
        private string Seal3;
        private string CustomerNo;
        private string MatchCd;
        private string CustomerNm;
        private string CargoKey;
        private string CargoRcvdDt;

        private string sDeliveryDsc;
        private string sNotes;
        private string sACMSBookingID;
        private string sACMSBookingSub;

        private string DepartureDt;

        private decimal? CubeFt
        {
            get
            {
                decimal? cf;
                cf = Length * Width * Height / 1728;
                if (!cf.HasValue)
                    cf = 0;
				cf = Math.Round(cf.Value, 3);
                return cf;
            }
        }
        private decimal? MTon
        {
            get
            {
                decimal? mt;
                mt = CubeFt / 40;
				mt = Math.Round(mt.Value, 3);
                return mt;
            }
        }
        private decimal? DimWeight
        {
            get
            {
                decimal? dw;
                dw = Length * Width * Height;
                dw = dw / 166;
				dw = Math.Round(dw.Value, 2);
                if (dw > Weight)
                    return dw;
                Weight = WeightRounding(Weight);
                return Weight;
            }
        }

        private bool isDoorIn(string sMoveType)
        {
            switch (sMoveType)
            {
                case "F5":
                case "F6":
                case "F9":
                    return true;
            }
            return false;
        }
        private bool isDoorOut(string sMoveType)
        {
            switch (sMoveType)
            {
                case "F7":
                case "F8":
                case "F9":
                    return true;
            }
            return false;
        }
		ImportProcessResults results;

        public int QueryTotal;
        public int QueryCounter;
        public bool QueryInProgress = false;

		#endregion

        #region Helper Methods
        private static decimal? WeightRounding(decimal? w)
        {
            if (w == null)
                return 0;
            decimal wt = (decimal)w;
            if (wt > 10)
                wt = decimal.Round(wt, 2);
            else
                wt = decimal.Round(wt, 0);
            w = wt;
            return w;
        }

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

        public decimal CentimetersToInches(decimal? dOrig)
        {
            double d = Convert.ToDouble(dOrig) * InchesMultiplier;
            decimal dRtn = Convert.ToDecimal(d);
            return dRtn;
        }
        public decimal FeetToInches(decimal? dOrig)
        {
            double d = Convert.ToDouble(dOrig) * 12;
            decimal dRtn = Convert.ToDecimal(d);
            return dRtn;
        }

        public decimal KGToPounds(decimal? dOrig)
        {
            double d = Convert.ToDouble(dOrig) * PoundsMultiplier;
            decimal dRtn = Convert.ToDecimal(d);
            return dRtn;
        }

        #endregion

        #region SQL

		#region Import LINE DataWarehouse

//        #region Bookings Warehouse
//        //
//        //  Get bookings created within the last week
//        //
//        string sqlGetBookings = @"
//			SELECT		dba.bu1_kopf.bu1bumanr AS booking_id, 
//					    dba.bu1_kopf.bu1bumanr AS booking_line_id,
//						dba.bu1_kopf.bu1bunr AS booking_no, 
//						dba.bu1_kopf.firma AS agent_cd, 
//						dba.bu1_kopf.bu1budate AS booking_dt, 
//						dba.bu1_kopf.bu1verart AS cargo_type, 
//						dba.bu1_kopf.bu1vessel AS vessel_cd, 
//						dba.bu1_kopf.bu1voyage AS voyage_no, 
//						dba.bu1_kopf.bu1plorcde AS plor_location_cd, 
//						dba.bu1_kopf.bu1plofrec AS plor_dsc, 
//						dba.bu1_kopf.bu1polcde AS pol_location_cd, 
//						dba.bu1_kopf.bu1polbez AS pol_dsc, 
//						dba.bu1_kopf.bu1polberth AS pol_berth, 
//						dba.bu1_kopf.bu1podcde AS pod_location_cd, 
//						dba.bu1_kopf.bu1podbez AS pod_dsc, 
//						dba.bu1_kopf.bu1podberth AS pod_berth, 
//						dba.bu1_kopf.bu1plodcde AS plod_location_cd, 
//						dba.bu1_kopf.bu1plofdel AS plod_dsc, 
//						dba.bu1_kopf.bu1status2 AS booking_status, 
//						dba.bu1_kopf.bu1kdnr AS customer_cd, 
//						dba.bu1_kopf.bu1kdmtc AS match_cd, 
//						dba.kunde.kdname1 AS customer_nm, 
//						dba.bu1_kopf.bu1loesch AS deleted_flg, 
//						dba.bu1_kopf.bu1ediref AS edi_ref, 
//						dba.bu1_kopf.bu1kdref AS  customer_ref, 
//						dba.bu1_kopf.bu1vskond AS move_type_cd, 
//						dba.bu1_kopf.bu1imdgkz AS imdg_flg, 
//						dba.bu1_kopf.bu1kopcde AS kind_of_pkg_cd, 
//						dba.bu1_kopf.bu1createuser AS create_user, 
//						dba.bu1_kopf.bu1createdat AS create_dt, 
//						dba.bu1_kopf.bu1changeuser AS modify_user, 
//						dba.bu1_kopf.bu1aenddat AS modify_dt, 
//						null as sail_dt,
//						dba.vw_d_bu1_inout.POL_ets as pol_ets, 
//						dba.vw_d_bu1_inout.POD_eta as pod_eta,
//						dba.bu1_kopf.bu1status as booking_status_cd,
//						null as bol_id,
//						null as bol_no,
//						'' as delivery_txt,
//						'' as cargo_notes_txt,
//						'' as booking_ref,
//						null as rdd_dt,
//						'N' as ilms_eligible_flg
//				FROM  dba.bu1_kopf INNER JOIN
//                      dba.kunde ON dba.kunde.kdkdnr = dba.bu1_kopf.bu1kdnr AND dba.kunde.firma = dba.bu1_kopf.firma INNER JOIN
//                      dba.vw_d_bu1_inout ON dba.bu1_kopf.bu1bumanr = dba.vw_d_bu1_inout.bu1bumanr
//                where dba.bu1_kopf.firma = 'ARC'
//                  and dba.bu1_kopf.bu1aenddat > getdate() - @DAYS";
//        #endregion

//        #region   BreakBulk Warehouse
//        //
//        // Breakbulk within the last Six months
//        //
//        //  Takes about 30 minutes
//        protected string sqlSelectBB = @"
//            SELECT  
//                    null as cargo_line_id,
//					'BREAKBULK' + CAST(dba.bu14_itemdetail.bu14_itemdetail_id AS varchar(10)) as cargo_key,
//					dba.bu1_kopf.bu1bumanr as booking_line_id,
//					dba.bu14_itemdetail.bu14trackingref as serial_no,
//                    bu14lfnr as item_no,
//					dba.bu1_kopf.bu1createuser AS create_user, 
//					dba.bu1_kopf.bu1createdat AS create_dt, 
//					dba.bu1_kopf.bu1changeuser AS modify_user, 
//					dba.bu1_kopf.bu1aenddat AS modify_dt, 
//					dba.bu3_item.bu3comcde as commodity_cd,
//                    dba.bu3_item.bu3kopcde as pkg_type_cd,
//                    CAST(bu14length AS numeric(13, 4)) AS length_nbr, 
//                    cast(dba.bu14_itemdetail.bu14height as numeric(13,4)) as height_nbr,
//                    cast(isnull(dba.bu14_itemdetail.bu14width, 0) as numeric (13,4)) as width_nbr,
//                    cast(isnull(dba.bu14_itemdetail.bu14weight, 0)as numeric(13,4)) as weight_nbr,
//					0 as dim_weight_nbr,
//					0 as cube_ft,
//					0 as m_tons,
//                    dba.bu1_kopf.bu1vskond as move_type_cd,
//					dba.bu3_item.bu3desofg as cargo_dsc,
//					null as vessel_load_dt,
//					null as contract_mod_id,
//					null as container_no,
//                    '' as seal1, '' as seal2, '' as seal3,
//                    '' as make_cd,
//                    '' as model_cd,
//                    convert(varchar(20),dba.bu14_itemdetail.bu14cargorecvdate, 106)AS cargo_rcvd_dt
//            FROM    dba.bu1_kopf INNER JOIN
//                    dba.bu3_item ON dba.bu1_kopf.bu1bumanr = dba.bu3_item.bu3bumanr INNER JOIN
//                    dba.bu14_itemdetail ON dba.bu3_item.bu3bumanr = dba.bu14_itemdetail.bu14manr AND 
//                    dba.bu3_item.bu3bulfnr = dba.bu14_itemdetail.bu14lfnr 
//                  INNER JOIN dba.kunde on dba.kunde.kdkdnr = dba.bu1_kopf.bu1kdnr AND dba.kunde.firma = dba.bu1_kopf.firma
//                where dba.bu1_kopf.firma = 'ARC'
//                  and dba.bu1_kopf.bu1aenddat > getdate() - @DAYS";

//        protected string sqlBBFilter = @"
//              and (dba.bu14_itemdetail.bu14trackingref IS NOT NULL) ";
//        #endregion

//        #region RoRo Warehouse
//        //
//        // roRo changed in the last 60 days
//        //
//        //   NOTE:  60 days takes about 5 minutes
//        protected string sqlSelectRR = @"
//			SELECT  
//				null as cargo_line_id,
//				'RORO' + CAST(dba.car_head.cr1_manr AS varchar(10)) as cargo_key,
//				dba.bu1_kopf.bu1bumanr as booking_line_id,
//				dba.car_head.CR1_VIN as serial_no, 
//                dba.car_head.cr1_buitem as item_no,
//				dba.car_head.cr1_create_user AS create_user, 
//				dba.car_head.cr1_create_date AS create_dt, 
//				dba.car_head.cr1_change_user AS modify_user, 
//				dba.car_head.cr1_change_date AS modify_dt, 
//				' ' as commodity_cd,
//                ' ' as pkg_type_cd,
//				cast(dba.car_head.cr1_length as numeric(13,4)) as length_nbr, 
//				cast(dba.car_head.cr1_height as numeric(13,4)) as height_nbr, 
//                cast(dba.car_head.cr1_width as numeric(13,4)) as width_nbr,
//				cast(dba.car_head.cr1_weight as numeric(13,4)) as weight_nbr, 
//				0 as dim_weight_nbr,
//				0 as cube_ft,
//				0 as m_tons,
//                dba.bu1_kopf.bu1vskond as move_type_cd,
//				dba.car_head.cr1_modelname as cargo_dsc,
//				null as vessel_load_dt,
//				null as contract_mod_id,
//				null as container_no,
//                '' as seal1, '' as seal2, '' as seal3,
//				dba.car_head.cr1_manufacturer as make_cd, 
//				dba.car_head.cr1_model as model_cd, 
//				dba.car_head.cr1_manufactur_ref as mfr_ref, 
//                0 as container_wt,
//                convert(varchar(20),dba.car_head.cr1_cargorecvdate,106) AS cargo_rcvd_dt
//			FROM  dba.car_head LEFT OUTER JOIN
//				  dba.bu1_kopf ON dba.car_head.cr1_bumanr = dba.bu1_kopf.bu1bumanr 
//                  INNER JOIN dba.kunde on dba.kunde.kdkdnr = dba.bu1_kopf.bu1kdnr AND dba.kunde.firma = dba.bu1_kopf.firma
//             WHERE dba.car_head.cr1_change_date > getdate() - @DAYS
//                ";

//        #endregion

		#region Container Warehouse
		//
		// All containers (because there aren't that many)
		//
		//   NOTE:  Takes about 2/3 minutes
		//
//        private static string sqlSelectCont = @"
//				SELECT 
//					null as cargo_line_id,
//                    'CONT' + CAST(bu4bumanr AS varchar(10)) + ' ' + CAST(bu4bulfnr AS varchar(5)) + ' ' + CAST(bu4cnlfnr AS varchar(5)) AS cargo_key,
//					dba.bu1_kopf.bu1bumanr as booking_line_id,
//					dba.bu4_cont.bu4remgte as serial_no,
//                    dba.bu4_cont.bu4bulfnr as item_no,
//                    dba.bu1_kopf.bu1vskond as move_type_cd,
//                    bu4kopcde as pkg_type_cd, 
//                    bu4comcde as commodity_cd, 
//                    '' as make_cd,
//                    '' as model_cd,
//                    '' as mfr_ref,
//                    bu4kopbez as cargo_dsc, 
//					dba.bu1_kopf.bu1createuser AS create_user, 
//					dba.bu1_kopf.bu1createdat AS create_dt, 
//					dba.bu1_kopf.bu1changeuser AS modify_user, 
//					dba.bu1_kopf.bu1aenddat AS modify_dt, 
//                    isnull(cast(dba.containerart.cttcontsz as numeric(14,3)),0) as length_nbr, 
//                    isnull(cast(dba.containerart.cttconthg as numeric(14,3)),0) as height_nbr, 
//                    isnull(cast(dba.containerart.cttcontwd as numeric(14,3)),0) as width_nbr,
//                    cast(bu4unitgrw as numeric(13,4)) as weight_nbr,
//					0 as dim_weight_nbr,
//					0 as cube_ft,
//					0 as m_tons,
//					null as vessel_load_dt,
//					null as contract_mod_id,
//                    bu4contnr as container_no,
//                    bu4seal1 as seal1, bu4seal2 as seal2, bu4seal3 as seal3,
//                    0 as container_wt,
//                    convert(varchar(20),dba.bu4_cont.bu4cargorecvdate,106) AS cargo_rcvd_dt
//					FROM dba.bu4_cont INNER JOIN
//						dba.bu1_kopf ON dba.bu4_cont.bu4bumanr = dba.bu1_kopf.bu1bumanr INNER JOIN
//                        dba.containerart ON dba.bu4_cont.firma = dba.containerart.firma AND 
//                          dba.bu4_cont.bu4contart = dba.containerart.cttcontart 
//                        INNER JOIN dba.kunde on dba.kunde.kdkdnr = dba.bu1_kopf.bu1kdnr AND dba.kunde.firma = dba.bu1_kopf.firma
//					WHERE dba.bu1_kopf.bu1aenddat > getdate() - @DAYS";

		#endregion

		#endregion

		#region Purge Statements
		protected string sqlPurgeTempTable = @"delete from s_line_cargo ";

        protected string sqlPurgeCargoActivity = @"
            delete from t_cargo_activity ca
             where estimate_id is null
                 and exists
                ( select 1
                  from t_cargo c
                  inner join t_booking b 
                     on b.booking_id = c.booking_id
                    and b.voyage_no like '{0}'
                 where c.cargo_id = ca.cargo_id)
                 and not exists
                (select 1
                   from t_estimate_charge_dtl d
                    where d.cargo_activity_id = ca.cargo_activity_id) 
                 and not exists
                 (select 1
                    from t_cargo_accrual acr
                     where acr.cargo_activity_id = ca.cargo_activity_id)
                    ";

        protected string sqlPurgeCargo = @"
            delete from t_cargo
             where not exists
              (select 1 from t_cargo_activity ca
               where ca.cargo_id = t_cargo.cargo_id)";

        protected string sqlPurgeBooking = @"
            delete from t_booking b
             where not exists
              (select 1 from t_cargo c
               where c.booking_id = b.booking_id)";

        #endregion

        #region Import Errors
        string sqlDuplicates = @"
            update s_line_cargo
             set import_notes = 'Duplicate Serial#/TCN'
              where serial_no in
              (
            select  serial_no
             from s_line_cargo
              group by serial_no 
              having count(serial_no) > 1
                )";

//        string sqlNonLandPLOR = @"
//             update s_line_cargo
//              set import_notes = 'Door In cargo has a PORT PLOR'
//              where serial_no in
//              (
//             select serial_no
//              from s_line_cargo l
//              left outer join r_location loc
//                on l.plor_location_cd = loc.location_cd
//              where move_type_cd in ('F5','F6','F9')
//               and location_type_cd <> 'LAND'
//               )";

//        string sqlNonLandPLOD = @"
//             update s_line_cargo
//              set import_notes = 'Door OUT cargo has a PORT PLOD'
//              where serial_no in
//              (
//             select serial_no
//              from s_line_cargo l
//              left outer join r_location loc
//                on l.plod_location_cd = loc.location_cd
//              where move_type_cd in ('F7','F8','F9')
//               and location_type_cd <> 'LAND'
//               )";

        string sqlNoSailDate = @"
             update s_line_cargo
              set import_notes = 'No Sail Date for this voyage/port'
              where sail_dt is null";

        #endregion

        #region Gather LINE data
        #region   Misc SQL Addendums
        private static string sqlJoinSchedule = @"
				INNER JOIN dba.reise_hafen 
                   ON dba.bu1_kopf.bu1vessel = dba.reise_hafen.rhvessel 
				  AND dba.bu1_kopf.bu1voyage = dba.reise_hafen.rhreise 
				  AND dba.bu1_kopf.bu1polcde = dba.reise_hafen.rhhafen 
				  AND dba.bu1_kopf.bu1polseqno = dba.reise_hafen.rhseqno
                  AND rhetseta > '05/31/2011'";

        private static string sqlSelectSchedule = @"
                ,rheta as ETA, rhetseta as ETS, 
                DATEDIFF([day], rhetseta, GETDATE()) AS days ";
                
        protected string sqlMainFilter = @"
             WHERE (dba.bu1_kopf.bu1loesch = 'N' ) ";

        protected string sqlDoorInFilter = @"
            and (dba.bu1_kopf.bu1vskond in ('F5','F6','F9')) ";

        protected string sqlDoorOutFilter = @"
            and (dba.bu1_kopf.bu1vskond in ('F7','F8','F9')) ";

        protected string sqlDoorFilter = @"
           and (move_type_cd in ('F5','F6','F7','F8','F9')) ";

        protected string _sqlImportFilter = @"
              /*AND (dba.bu1_kopf.bu1kdmtc LIKE '%SDDC%') */
              AND (dba.bu1_kopf.bu1status2 = 'C') 
              and (dba.bu1_kopf.bu1voyage like '@VOYAGE' )
              AND (dba.bu1_kopf.bu1createdat > GETDATE() - @DAYS)";

        protected string sqlImportFilter(string VoyageNo, int Days)
        {
            string sql = _sqlImportFilter;
            sql = sql.Replace("@VOYAGE", VoyageNo);
            sql = sql.Replace("@DAYS", Days.ToString());
            return sql;
        }
        #endregion

        #region   BreakBulk
        protected string sqlSelectBreakBulk = @"
            SELECT  dba.bu14_itemdetail.bu14trackingref as tcn,
                    bu14lfnr as item_no,
                    dba.bu1_kopf.bu1status2 as booking_status,
                    dba.bu1_kopf.bu1kdnr as customer_no,
                    dba.bu1_kopf.bu1kdmtc as match_cd,
                    dba.kunde.kdname1 as customer_nm,
                    dba.bu1_kopf.bu1loesch as deleted_flg,
                    dba.bu1_kopf.bu1bunr as booking_no,
                    dba.bu1_kopf.bu1ediref as pcfn,
                    dba.bu1_kopf.bu1kdref as user_pcfn,
                    NULL AS bol, 
                    dba.bu1_kopf.bu1voyage as voyage_no,
                    dba.bu1_kopf.bu1vessel as vessel,
                    dba.bu1_kopf.bu1plorcde as plor,
                    dba.bu1_kopf.bu1polcde as pol,
                    dba.bu1_kopf.bu1podcde as pod,
                    dba.bu1_kopf.bu1plodcde as plod,
                    dba.bu1_kopf.bu1vskond as move_type,
                    'BREAKBULK' as cargo_type,
                    dba.bu1_kopf.bu1polbez as pol_dsc,
                    dba.bu1_kopf.bu1podbez as pod_dsc,
                    bu1plofrec as plor_dsc,
                    bu1plofdel as plod_dsc,
                    dba.bu3_item.bu3kopcde as kind_pkg,
                    dba.bu3_item.bu3comcde as commodity_cd,
                    '' as make,
                    '' as model,
                   '' as mfr_ref,
                    dba.bu3_item.bu3desofg as dogs,
                    CAST(bu14length AS numeric(13, 4)) AS length, 
                    cast(dba.bu14_itemdetail.bu14height as numeric(13,4)) as height,
                    cast(isnull(dba.bu14_itemdetail.bu14width, 0) as numeric (13,4)) as width,
                    cast(isnull(dba.bu14_itemdetail.bu14weight, 0)as numeric(13,4)) as weight,
                    '' as container_no,
                    '' as seal1, '' as seal2, '' as seal3,
                    0 as container_wt, 
                    'BREAKBULK' + CAST(dba.bu14_itemdetail.bu14_itemdetail_id AS varchar(10)) as cargo_key,
                    convert(varchar(20),dba.bu14_itemdetail.bu14cargorecvdate, 106)AS cargo_rcvd_dt,
					dba.bu14_itemdetail.bu14status as status_cd,
					dba.bu1_kopf.bu1nrofpa as pkg_count_nbr,
					dba.bu1_kopf.bu1tariffcat1 as tariff_cd,
					dba.bu1_kopf.bu1prcets as ets_dt ";

        protected string sqlFromBreakBulk = @"
            FROM    dba.bu1_kopf INNER JOIN
                        dba.bu3_item ON dba.bu1_kopf.bu1bumanr = dba.bu3_item.bu3bumanr INNER JOIN
                        dba.bu14_itemdetail ON dba.bu3_item.bu3bumanr = dba.bu14_itemdetail.bu14manr AND 
                        dba.bu3_item.bu3bulfnr = dba.bu14_itemdetail.bu14lfnr 
                    INNER JOIN dba.kunde on dba.kunde.kdkdnr = dba.bu1_kopf.bu1kdnr AND dba.kunde.firma = dba.bu1_kopf.firma";

        protected string sqlBreakBulkFilter = @"
              and (dba.bu14_itemdetail.bu14trackingref IS NOT NULL) ";
        #endregion

        #region   RoRo
        protected string sqlSelectRoRo = @"
			SELECT     dba.car_head.CR1_VIN as tcn, 
                dba.car_head.cr1_buitem as item_no,
                dba.bu1_kopf.bu1status2 as booking_status,
                dba.bu1_kopf.bu1kdnr as customer_no,
                dba.bu1_kopf.bu1kdmtc as match_cd,
                dba.kunde.kdname1 as customer_nm,
				dba.bu1_kopf.bu1loesch as deleted_flg, 
				dba.bu1_kopf.bu1bunr as booking_no, 
				dba.bu1_kopf.bu1ediref as pcfn, 
				dba.bu1_kopf.bu1kdref as user_pcfn, 
				null as bol, 
				dba.car_head.cr1_voyage as voyage_no, 
				dba.car_head.cr1_vessel as vessel, 
                    dba.bu1_kopf.bu1plorcde as plor,
                    dba.bu1_kopf.bu1polcde as pol,
                    dba.bu1_kopf.bu1podcde as pod,
                    dba.bu1_kopf.bu1plodcde as plod,
    			dba.bu1_kopf.bu1vskond as move_type,
                'RORO' as cargo_type,
                dba.bu1_kopf.bu1polbez as pol_dsc, 
                dba.bu1_kopf.bu1podbez as pod_dsc,
                bu1plofrec as plor_dsc, 
                bu1plofdel as plod_dsc,
                '' as kind_pkg,
                '' as commodity_cd,
				dba.car_head.cr1_manufacturer as make, 
				dba.car_head.cr1_model as model, 
				dba.car_head.cr1_manufactur_ref as mfr_ref, 
                dba.car_head.cr1_modelname as dogs,
				cast(dba.car_head.cr1_length as numeric(13,4)) as length, 
				cast(dba.car_head.cr1_height as numeric(13,4)) as height, 
                cast(dba.car_head.cr1_width as numeric(13,4)) as width,
				cast(dba.car_head.cr1_weight as numeric(13,4)) as weight, 
                '' as container_no,
                '' as seal1, '' as seal2, '' as seal3,
                0 as container_wt,
                'RORO' + CAST(dba.car_head.cr1_manr AS varchar(10)) as cargo_key,
                convert(varchar(20),dba.car_head.cr1_cargorecvdate,106) AS cargo_rcvd_dt,
				dba.car_head.cr1_ecstatus as status_cd,
					dba.bu1_kopf.bu1nrofpa as pkg_count_nbr,
					dba.bu1_kopf.bu1tariffcat1 as tariff_cd,
					dba.bu1_kopf.bu1prcets as ets_dt ";

        protected string sqlFromRoRo =@"
			FROM  dba.car_head LEFT OUTER JOIN
				  dba.bu1_kopf ON dba.car_head.cr1_bumanr = dba.bu1_kopf.bu1bumanr 
                  INNER JOIN dba.kunde on dba.kunde.kdkdnr = dba.bu1_kopf.bu1kdnr AND dba.kunde.firma = dba.bu1_kopf.firma";

        protected string sqlRoRoFilter = @"
                    AND (dba.car_head.CR1_VIN IS NOT NULL) ";

        #endregion

        #region Containers
        private static string sqlSelectContainers = @"
				SELECT 
					dba.bu4_cont.bu4remgte as tcn,
                    dba.bu4_cont.bu4bulfnr as item_no,
                    dba.bu1_kopf.bu1status2 as booking_status,
                    dba.bu1_kopf.bu1kdnr as customer_no,
                    dba.bu1_kopf.bu1kdmtc as match_cd,
                    dba.kunde.kdname1 as customer_nm,
                    dba.bu1_kopf.bu1loesch as deleted_flg,
                    dba.bu1_kopf.bu1bunr as booking_no,
                    dba.bu1_kopf.bu1ediref as pcfn,
                    dba.bu1_kopf.bu1kdref as user_pcfn,
                    NULL AS bol, 
                    dba.bu1_kopf.bu1voyage as voyage_no,
                    dba.bu1_kopf.bu1vessel as vessel,
                    dba.bu1_kopf.bu1plorcde as plor,
                    dba.bu1_kopf.bu1polcde as pol,
                    dba.bu1_kopf.bu1podcde as pod,
                    dba.bu1_kopf.bu1plodcde as plod,
                    dba.bu1_kopf.bu1vskond as move_type,
                    'CONTAINER' as cargo_type,
                    dba.bu1_kopf.bu1polbez as pol_dsc,
                    dba.bu1_kopf.bu1podbez as pod_dsc,
                    bu1plofrec as plor_dsc,
                    bu1plofdel as plod_dsc,
                    bu4kopcde as kind_pkg, 
                    bu4comcde as commodity_cd, 
                    '' as make,
                    '' as model,
                    '' as mfr_ref,
                    bu4kopbez as dogs, 
                    isnull(cast(dba.containerart.cttcontsz as numeric(14,3)),0) as length, 
                    isnull(cast(dba.containerart.cttconthg as numeric(14,3)),0) as height, 
                    isnull(cast(dba.containerart.cttcontwd as numeric(14,3)),0) as width,
                    cast(bu4unitgrw as numeric(13,4)) as weight,
                    bu4contnr as container_no,
                    bu4seal1 as seal1, bu4seal2 as seal2, bu4seal3 as seal3,
                    0 as container_wt,
                    'CONT' + CAST(bu4bumanr AS varchar(10)) + ' ' + CAST(bu4bulfnr AS varchar(5)) + ' ' + CAST(bu4cnlfnr AS varchar(5)) AS cargo_key,
                    convert(varchar(20),dba.bu4_cont.bu4cargorecvdate,106) AS cargo_rcvd_dt,
					dba.bu4_cont.bu4ecstatus as status_cd,
					dba.bu1_kopf.bu1nrofpa as pkg_count_nbr,
					dba.bu1_kopf.bu1tariffcat1 as tariff_cd,
					dba.bu1_kopf.bu1prcets as ets_dt ";

        private static string sqlFromContainers = @"
					FROM dba.bu4_cont INNER JOIN
						dba.bu1_kopf ON dba.bu4_cont.bu4bumanr = dba.bu1_kopf.bu1bumanr INNER JOIN
                        dba.containerart ON dba.bu4_cont.firma = dba.containerart.firma AND 
                          dba.bu4_cont.bu4contart = dba.containerart.cttcontart 
                        INNER JOIN dba.kunde on dba.kunde.kdkdnr = dba.bu1_kopf.bu1kdnr AND dba.kunde.firma = dba.bu1_kopf.firma";

        private static string sqlContainersFilter = @"
              and (dba.bu4_cont.bu4remgte IS NOT NULL) ";

        #endregion

        #endregion

        #region Gather ACMS data
        protected string sqlGetACMSBookingData = @"
            select bu.partner_cd, bu.partner_request_cd,
             bu.booking_id, bu.booking_id_sub, br.delivery_dsc, 
                bn.note_cd1 || ' ' || bn.note_cd2 || ' ' || bn.note_cd3 || ' ' || bn.note_cd4 ||
                bn.note_cd5 || ' ' || bn.note_cd6 || ' ' || bn.note_cd7 || ' ' || bn.note_cd8 as ACMSNotes,
                bu.voyage_no, bu.poe_location_cd
             from t_booking_unit bu 
              inner join t_booking_request br on br.partner_cd = bu.partner_cd
                and br.partner_request_cd = bu.partner_request_cd
                and br.acms_status_cd in ( 'B', 'BC')
                and br.request_dt > sysdate - 120
              left outer join t_booking_request_note bn on bn.partner_cd = bu.partner_cd
                and bn.partner_request_cd = bu.partner_request_cd    
             group by bu.partner_cd, bu.partner_request_cd,
             bu.booking_id, bu.booking_id_sub, br.delivery_dsc,
              bn.note_cd1, bn.note_cd2, bn.note_cd3, bn.note_cd4,
              bn.note_cd5, bn.note_cd6, bn.note_cd7, bn.note_cd8,
               bu.voyage_no, bu.poe_location_cd";

        protected string sqlGetACMSVoyageData = @"
            select  location_cd, 
                    terminal_cd, 
                    to_char(arrival_dt, 'DD-MON-YYYY') as arrival_dt,
                    to_char(departure_dt, 'DD-MON-YYYY') as departure_dt,
                    actual_arrival_fl, 
                    actual_departure_fl,
                    to_char(sail_dt, 'DD-MON-YYYY') as sail_dt
             from mv_voyage_route_detail  
            inner join mv_voyage on mv_voyage.voyage_cd = mv_voyage_route_detail.voyage_cd
             where substr(mv_voyage.voyage_cd,0,5) = '@VOYNO'            
               and location_cd = '@LOC'
              order by departure_dt";

        #endregion

        #region Insert Statements
        protected string sqlInsertPLOR = @"
			insert into r_location
			 (location_cd, location_type_cd, location_dsc)
              select upper(plor_location_cd), 
                      min(case  
                        when mt.door_in_flg = 'Y' then 'LAND'
                          else 'PORT'
                       end), 
                       min(upper(plor_location_dsc))
               from s_line_cargo lc
                left outer join r_move_type mt on mt.move_type_cd = lc.move_type_cd
			  where plor_location_cd is not null and
                not exists
			   (select * from r_location l
				where l.location_cd = lc.plor_location_cd)
                group by plor_location_cd";

		protected string sqlInsertPLOD = @"
          insert into r_location
			     (location_cd, location_type_cd, location_dsc)
                      select upper(plod_location_cd), 
                              min(case  
                                when mt.door_out_flg = 'Y' then 'LAND'
                                  else 'PORT'
                               end), 
                               min(upper(plod_location_dsc))
                       from s_line_cargo lc
                       left outer join r_move_type mt on mt.move_type_cd = lc.move_type_cd
			      where plod_location_cd is not null and not exists
			       (select * from r_location l
				    where l.location_cd = lc.plod_location_cd)  
             group by plod_location_cd ";

		protected string sqlInsertPOL = @"
			insert into r_location
			 (location_cd, location_type_cd, location_dsc)
			select upper(pol_location_cd), 'PORT', min(pol_location_dsc)
			 from s_line_cargo lc
			  where not exists
			   (select * from r_location l
				where l.location_cd = lc.pol_location_cd) 
                group by pol_location_cd";

		protected string sqlInsertPOD = @"
			insert into r_location
			 (location_cd, location_type_cd, location_dsc)
			select upper(pod_location_cd), 'PORT', min(pod_location_dsc)
			 from s_line_cargo lc
			  where not exists
			   (select * from r_location l
				where l.location_cd = lc.pod_location_cd)
                group by pod_location_cd ";

		//
        // This will only insert bookings where there are no
        // import notes on ANY of the cargo
        //
        protected string sqlInsertBookings = @"
			insert into t_booking
			select booking_id_seq.NextVal,
				   null,null,null, null,
				   a.* 
			 from
					(select distinct
						   plor_location_cd, pol_location_cd,
						   pod_location_cd, plod_location_cd,
						   booking_no, null as bkref, null as bolno, 
                           edi_ref_no, substr(customer_ref_no,0,25),
                           customer_cd, match_cd,
						   vessel_cd, voyage_no, delivery_dsc, cargo_notes, 
                           sail_dt
                      from s_line_cargo lc
                            where not exists
                                   (select 1 from t_booking b
                                     where b.booking_no = lc.booking_no)
                                     and (move_type_cd in ('F5','F6','F7','F8','F9'))
                                and booking_no not in
                                   (select distinct booking_no
                                      from s_line_cargo 
                                     where import_notes is not null)                             
                                     ) a";

		//!!! Needs to be changed.
		//  In the "not exists" clause, ignore booking, and instead
		//  look only for cargo created with in the last 90 (?) days.
		protected string sqlInsertCargo = @"
			insert into t_cargo
			 (cargo_id, booking_id, serial_no, item_no, commodity_cd, length_nbr,
			  width_nbr, height_nbr, cube_ft, m_tons, dim_weight_nbr, weight_nbr, move_type_cd, cargo_dsc,
              container_no, seal1, seal2, seal3, make_cd, model_cd, cargo_key, cargo_rcvd_dt) 
			select cargo_id_seq.NextVal,
				   booking_id,
				   serial_no,
                   item_no,
				   commodity_cd,
				   length_nbr,
				   cast(width_nbr as decimal(10,4)),
				   height_nbr,
                   cube_ft,
                   m_tons,
                   dim_weight_nbr,
				   weight_nbr,
				   move_type_cd,
				   cargo_dsc,
                   container_no,
                   seal1, seal2, seal3,
                   make_cd, model_cd,
				   cargo_key, cargo_rcvd_dt
			from
			(
			select booking_id,
				   serial_no,
                   item_no,
				   commodity_cd, 
				   length_nbr,
				   width_nbr,
				   height_nbr,
                   cube_ft,
                   m_tons,
                   dim_weight_nbr,
				   cast(weight_nbr as decimal(10,4)) as weight_nbr,
				   move_type_cd,
				   cargo_dsc,
                   container_no,
                   seal1, seal2, seal3,
                   make_cd, model_cd,
				   cargo_key, cargo_rcvd_dt
			 from s_line_cargo a
			  inner join t_booking b on a.booking_no = b.booking_no
			   where import_notes is null
                 and not exists
				(select 1 from t_cargo c
				 where b.booking_id = c.booking_id
				   and a.serial_no = c.serial_no )) ";

		protected string sqlInsertCargoActivity1 = @"
					insert into t_cargo_activity
					(cargo_activity_id, cargo_id, activity_type_cd,
					 billable_flg, orig_location_cd, dest_location_cd)
					select cargo_activity_id_seq.NextVal,
					 cargo_id, 'LHAUL', 'Y', plor_location_cd, pol_location_cd
					from
					(
					select
					 cargo_id,
					 plor_location_cd,
					 pol_location_cd
					from t_booking  b
					 inner join t_cargo c  
					  on b.booking_id = c.booking_id
                     inner join r_location l on l.location_cd = plor_location_cd 
                       and l.location_type_cd = 'LAND'
					where not exists
					(select 1 from t_cargo_activity ca
						where ca.cargo_id = c.cargo_id
						  and ca.orig_location_cd = b.plor_location_cd
						  and ca.dest_location_cd = b.pol_location_cd)
					 ) ";

		protected string sqlInsertCargoActivity2 = @"
					insert into t_cargo_activity
					(cargo_activity_id, cargo_id, activity_type_cd,
					 billable_flg, orig_location_cd, dest_location_cd)
					select cargo_activity_id_seq.NextVal,
					 cargo_id, 'LHAUL', 'Y', pod_location_cd, plod_location_cd
					from
					(
					select
					 cargo_id,
					 pod_location_cd,
					 plod_location_cd
					from t_booking  b
					 inner join t_cargo c  
					  on b.booking_id = c.booking_id
                     inner join r_location l on l.location_cd = plod_location_cd 
                       and l.location_type_cd = 'LAND'
					where not exists
					(select 1 from t_cargo_activity ca
						where ca.cargo_id = c.cargo_id
						  and ca.orig_location_cd = b.pod_location_cd
						  and ca.dest_location_cd = b.plod_location_cd)
					 ) ";

        protected string sqlInsertCustomer = @"
                insert into r_customer
                 (customer_cd, customer_nm, active_flg)
                 select customer_cd, max(customer_nm), 'Y'
                  from s_line_cargo
                where s_line_cargo.customer_cd not in
                 (select customer_cd from r_customer 
                  where r_customer.customer_cd = s_line_cargo.customer_cd)
                 group by customer_cd  ";

        protected string sqlInsertVessels = @"
            insert into r_vessel
             (vessel_cd, vessel_nm, active_flg)
             select vessel_cd, vessel_cd, 'Y'
              from s_line_cargo
                where not exists
                (select 1 from r_vessel
                 where r_vessel.vessel_cd = s_line_cargo.vessel_cd)
               group by vessel_cd  ";

        #endregion


        #endregion

        #region Connections
        protected static ClsConnection ConnectionLine
		{
			get 
            {
                if (ClsConMgr.Manager["LINE"] == null)
                {
                    ConnectToLINE();
                }
                return ClsConMgr.Manager["LINE"]; 
            }
		}

        private static bool ConnectToLINE()
        {
			string sConnect = "packet size=4096;user id=line-edi-user;password=dg20100512;data source=SQLCLUSTER;persist security info=True;initial catalog=Line_cs;";
            ClsConnection line = new ClsConnection(sConnect, "System.Data.SqlClient");
            line.DbConnectionKey = "LINE";
            ClsConMgr.Manager.AddConnection(line);
            return true;
        }

        protected static ClsConnection ConnectionACMS
        {
            get
            {
                if (ClsConMgr.Manager["ACMS"] == null)
                {
                    ConnectToACMS();
                }
                return ClsConMgr.Manager["ACMS"];
            }
        }

        private static bool ConnectToACMS()
        {
            string sConnect = "Data Source=ACMSP;Persist Security Info=True;User ID=ediuser;;password=montvale123;";
            ClsConnection acms = new ClsConnection(sConnect, "Oracle.DataAccess.Client");
            acms.DbConnectionKey = "ACMS";
            ClsConMgr.Manager.AddConnection(acms);
            return true;
        }
		protected static ClsConnection ConnectionARCImport
		{
			get { return ClsConMgr.Manager["ArcImport"]; }
		}

		#endregion

		#region IMPORT Methods
		public struct ImportProcessResults
		{
			public int iPurgeResults;
			public int iGatherRoRoResults;
            public int iGatherBreakBulkResults;
            public int iGatherContainerResults;
			public int iNewLocations;
			public int iBookingCount;
			public int iNewBookings;
			public int iUpdatedBookings;
			public int iCargoCount;
			public int iNewCargo;
			public int iUpdatedCargo;
			public int iNewCargoActivity;
            public int iNewCustomer;
            public int inewVessels;
			public string ErrorMsg;
			public bool bSuccess;
            public string ErrorLocation;
            public string sLastSQL;
            public double TempTime;
            public double LiveTime;
			public string sProblems;
		}

        public ImportProcessResults ImportLineProcess(string VoyageNo, int Days)
        {
            try
            {
                if (string.IsNullOrEmpty(VoyageNo)) { VoyageNo = "%"; }
                results.bSuccess = true;

                ImportTempTable(VoyageNo, Days);

                if (results.bSuccess)
                    ImportLiveTables(VoyageNo);

                if (results.bSuccess)
                {
                    DataTable dt = GetChangedCargo();
                    UpdateChangedCargo(dt);
                }
                return results;
            }
            catch (Exception ex)
            {
                results.ErrorMsg = ex.Message;
                results.bSuccess = false;
                return results;
            }
        }

		public ImportProcessResults ImportLiveTables(string VoyageNo)
		{
			try
			{
                if (string.IsNullOrEmpty(VoyageNo))  {VoyageNo = "%";}

                DateTime StartTime = DateTime.Now;
				// Purge tables
                ConnectionARCImport.RunSQL(sqlPurgeCargoActivity.Replace("{0}",VoyageNo));
                ConnectionARCImport.RunSQL(sqlPurgeCargo);
                ConnectionARCImport.RunSQL(sqlPurgeBooking);

                // Add any new locations
                InsertNewLocations();

                // Add any new vessels
                InsertNewVessels();

                // Add any new customers
                InsertNewCustomers();

                // Add new bookings
                InsertNewBookings();

                // Add new Cargo
                InsertNewCargo();

                // Add new Cargo Activity
                InsertNewCargoActivity();

				results.bSuccess = true; ;
				results.ErrorMsg = "Data was successfully imported from LINE";
                DateTime EndTime = DateTime.Now;
                TimeSpan t = EndTime.Subtract(StartTime);
                results.LiveTime = t.TotalSeconds;

                return results;
			}
			catch( Exception ex )
			{
				results.ErrorMsg = ex.Message;
				results.bSuccess = false;
				return results;
			}
		}

        public ImportProcessResults ImportTempTable(string VoyageNo, int Days)
        {
            //
            // This method only purges and re-populates the temporary cargo table
            //
            try
            {
                results.bSuccess = true;
                DateTime StartTime = DateTime.Now;

                if (string.IsNullOrEmpty(VoyageNo)) { VoyageNo = "%"; }

                // Purge the temp table
                results.iPurgeResults = ConnectionARCImport.RunSQL(sqlPurgeTempTable);


				// New 
				DataTable[] dtCargo = new DataTable[3];
				dtCargo = GetLineCargo(VoyageNo, Days);

				//   Roro
				DataTable dtRoRo = dtCargo[0];
				results.iGatherRoRoResults = dtRoRo.Rows.Count;
				GatherFromDataTables(dtRoRo);
				//  BreakBulk
				DataTable dtBreakBulk = dtCargo[1];
				results.iGatherBreakBulkResults = dtBreakBulk.Rows.Count;
				GatherFromDataTables(dtBreakBulk);
				// Containers
				DataTable dtContainer = dtCargo[2];
				results.iGatherContainerResults = dtContainer.Rows.Count;
				GatherFromDataTables(dtContainer);
				
				//// (OLD) Repopulate holding table
				////   Roro
				//StringBuilder sbRoRo = new StringBuilder(sqlSelectRoRo);
				//sbRoRo.Append(sqlFromRoRo);
				//sbRoRo.Append(sqlMainFilter);
				//sbRoRo.Append(sqlImportFilter(VoyageNo,Days));
				//sbRoRo.Append(sqlRoRoFilter);
				//DataTable dtRoRo = ConnectionLine.GetDataTable(sbRoRo.ToString());
				//results.iGatherRoRoResults = dtRoRo.Rows.Count;
				//GatherFromDataTables(dtRoRo);

				////  BreakBulk
				//StringBuilder sbBB = new StringBuilder(sqlSelectBreakBulk);
				//sbBB.Append(sqlFromBreakBulk);
				//sbBB.Append(sqlMainFilter);
				//sbBB.Append(sqlImportFilter(VoyageNo, Days));
				//sbBB.Append(sqlBreakBulkFilter);
				//DataTable dtBreakBulk = ConnectionLine.GetDataTable(sbBB.ToString());
				//results.iGatherBreakBulkResults = dtBreakBulk.Rows.Count;
				//GatherFromDataTables(dtBreakBulk);

				//// Containers
				//StringBuilder sbCont = new StringBuilder(sqlSelectContainers);
				//sbCont.Append(sqlFromContainers);
				//sbCont.Append(sqlMainFilter);
				//sbCont.Append(sqlImportFilter(VoyageNo, Days));
				//sbCont.Append(sqlContainersFilter);
				//DataTable dtContainer = ConnectionLine.GetDataTable(sbCont.ToString());
				//results.iGatherContainerResults = dtContainer.Rows.Count;
				//GatherFromDataTables(dtContainer);

                // Gather ACMS data
                DataTable dtACMSNotes = ConnectionACMS.GetDataTable(sqlGetACMSBookingData);
                UpdateWithACMSData(dtACMSNotes);

                // Tag cargo that should not be imported
                ConnectionARCImport.RunSQL(sqlDuplicates);
				// May 2012 - no longer check for correct move type
                //ConnectionARCImport.RunSQL(sqlNonLandPLOD);
                //ConnectionARCImport.RunSQL(sqlNonLandPLOR);
                ConnectionARCImport.RunSQL(sqlNoSailDate);

                // Compute the time it took for the import to process
                DateTime EndTime = DateTime.Now;
                TimeSpan t = EndTime.Subtract(StartTime);
                results.TempTime = t.TotalSeconds;
                return results;
            }
            catch (Exception ex)
            {
                results.ErrorMsg = ex.Message;
                results.bSuccess = false;
                return results;
            }
        }

		public DataTable[] GetLineCargo(string VoyageNo, int Days)
		{
			// Repopulate holding table
			//   Roro
			DataTable[] dtCargo = new DataTable[3];

			StringBuilder sbRoRo = new StringBuilder(sqlSelectRoRo);
			sbRoRo.Append(sqlFromRoRo);
			sbRoRo.Append(sqlMainFilter);
			sbRoRo.Append(sqlImportFilter(VoyageNo, Days));
			sbRoRo.Append(sqlRoRoFilter);
			DataTable dtRoRo = ConnectionLine.GetDataTable(sbRoRo.ToString());

			//  BreakBulk
			StringBuilder sbBB = new StringBuilder(sqlSelectBreakBulk);
			sbBB.Append(sqlFromBreakBulk);
			sbBB.Append(sqlMainFilter);
			sbBB.Append(sqlImportFilter(VoyageNo, Days));
			sbBB.Append(sqlBreakBulkFilter);
			DataTable dtBreakBulk = ConnectionLine.GetDataTable(sbBB.ToString());

			// Containers
			StringBuilder sbCont = new StringBuilder(sqlSelectContainers);
			sbCont.Append(sqlFromContainers);
			sbCont.Append(sqlMainFilter);
			sbCont.Append(sqlImportFilter(VoyageNo, Days));
			sbCont.Append(sqlContainersFilter);
			DataTable dtContainer = ConnectionLine.GetDataTable(sbCont.ToString());

			dtCargo[0] = dtRoRo;
			dtCargo[1] = dtBreakBulk;
			dtCargo[2] = dtContainer;
			return dtCargo;
		}
		public void InsertNewLocations()
		{
			ConnectionARCImport.TransactionBegin();
			try
			{
                int i = 0;
                i = ConnectionARCImport.RunSQL(sqlInsertPLOR);
                i = i + ConnectionARCImport.RunSQL(sqlInsertPOL);
                i = i + ConnectionARCImport.RunSQL(sqlInsertPOD);
                i = i + ConnectionARCImport.RunSQL(sqlInsertPLOD);
                results.iNewLocations = i;
                ConnectionARCImport.TransactionCommit();
			}
			catch( Exception ex )
			{
                ConnectionARCImport.TransactionRollback();
				throw ex;
			}
		}

        public void InsertNewCustomers()
        {
            ConnectionARCImport.TransactionBegin();
            try
            {
                int i = 0;
                i = ConnectionARCImport.RunSQL(sqlInsertCustomer);
                results.iNewCustomer = i;
                ConnectionARCImport.TransactionCommit();
            }
            catch (Exception ex)
            {
                ConnectionARCImport.TransactionRollback();
                throw ex;
            }
        }
        public void InsertNewVessels()
        {
            ConnectionARCImport.TransactionBegin();
            try
            {
                int i = 0;
                i = ConnectionARCImport.RunSQL(sqlInsertVessels);
                results.inewVessels = i;
                ConnectionARCImport.TransactionCommit();
            }
            catch (Exception ex)
            {
                ConnectionARCImport.TransactionRollback();
                throw ex;
            }
        }

        public void GatherFromDataTables(DataTable dt)
        {
            int iCount = 0;
            ConnectionARCImport.TransactionBegin();
            try
            {
                foreach (DataRow dr in dt.Rows)
                {
                    iCount++;
                    SerialNo = dr["tcn"].ToString().Trim();
                    ItemNo = dr["item_no"].ToString();
                    DeletedFlg = dr["deleted_flg"].ToString();
                    BookingNo = dr["booking_no"].ToString().Trim();
                    EDIRefNo = dr["pcfn"].ToString().Trim();
                    CustomerRefNo = dr["user_pcfn"].ToString().Trim();
                    BOLNo = dr["bol"].ToString().Trim();
                    VoyageNo = dr["voyage_no"].ToString();
                    VesselCd = dr["vessel"].ToString();
                    Plor = dr["plor"].ToString();
                    POL = dr["pol"].ToString().Trim();
                    PODDescription = dr["pod_dsc"].ToString().Trim();
                    POD = dr["pod"].ToString().Trim();
                    POLDescription = dr["pol_dsc"].ToString();
                    PlorDescription = dr["plor_dsc"].ToString();
                    PlodDescription = dr["plod_dsc"].ToString();
                    Plod = dr["plod"].ToString();
                    MoveTypeCd = dr["move_type"].ToString();
                    CargoTypeCd = dr["cargo_type"].ToString();
                    CommodityCd = dr["commodity_cd"].ToString();
                    CargoDsc = dr["dogs"].ToString();
                    CargoDsc = CargoDsc.Replace("'", " ");
                    ContainerNo = dr["container_no"].ToString().Trim();
                    Seal1 = dr["seal1"].ToString().Trim();
                    Seal2 = dr["seal2"].ToString().Trim();
                    Seal3 = dr["seal3"].ToString().Trim();
                    MakeCd = dr["make"].ToString().Trim();
                    ModelCd = dr["model"].ToString().Trim();
                    CustomerNo = dr["customer_no"].ToString().Trim();
                    MatchCd = dr["match_cd"].ToString().Trim();
                    CustomerNm = dr["customer_nm"].ToString().Trim();
                    CargoRcvdDt = dr["cargo_rcvd_dt"].ToString().Trim();
                    CargoKey = dr["cargo_key"].ToString().Trim();

                    // Adjustments 
                    if (string.IsNullOrEmpty(Plor))
                    {
                        Plor = POL;
                        PlorDescription = POLDescription;
                    }
                    if (string.IsNullOrEmpty(Plod))
                    {
                        Plod = POD;
                        PlodDescription = PODDescription;
                    }


                    Length = Height = Width = Weight = 0;
                    string sLength = dr["length"].ToString();
                    string sWidth = dr["width"].ToString();
                    string sHeight = dr["height"].ToString();
                    string sWeight = dr["weight"].ToString();
                    if (!string.IsNullOrEmpty(sLength))
                        Length = ClsConvert.ToDecimalNullable(sLength);
                    if (!string.IsNullOrEmpty(sWidth))
                        Width = ClsConvert.ToDecimalNullable(sWidth);
                    if (!string.IsNullOrEmpty(sHeight))
                        Height = ClsConvert.ToDecimalNullable(sHeight);
                    if (!string.IsNullOrEmpty(sWeight))
                        Weight = ClsConvert.ToDecimalNullable(sWeight);

                    // Convert to inches (not for containers)
                    if (CargoTypeCd != "CONTAINER")
                    {
                        Length = CentimetersToInches(Length);
                        Height = CentimetersToInches(Height);
                        Width = CentimetersToInches(Width);
                        Weight = KGToPounds(Weight);
                    }
                    else
                    {
                        Length = FeetToInches(Length);
                        Height = FeetToInches(Height);
                        Width = FeetToInches(Width);
                    }

                    Weight = WeightRounding(Weight);
                    if (string.IsNullOrEmpty(SerialNo))
                        SerialNo = "na";

                    InsertLineCargo();
                }
                ConnectionARCImport.TransactionCommit();
            }

            catch (Exception ex)
            {
                results.ErrorMsg = ex.Message;
                ConnectionARCImport.TransactionRollback();
                throw;
            }
            finally
            {
                string sMsg = SerialNo;
            }
        }

		public void InsertLineCargo()
		{
            try
            {
				// First, clean up some of the data
                SerialNo = SerialNo.Replace("'", "");
                if (string.IsNullOrEmpty(SerialNo))
                    return;
                if (SerialNo.ToLower() == "na")
                    return;

				Length = Math.Round(Length.Value, 4);
				Width = Math.Round(Width.Value, 4);
				Height = Math.Round(Height.Value, 4);
				Weight = Math.Round(Weight.Value, 4);
				
                DataRow dr = GatherVoyageData(VoyageNo, POL);
                DepartureDt = null;
                if (dr != null)
                {
                    DepartureDt = dr["departure_dt"].ToString();
                    //DepartureDt = dr["sail_dt"].ToString();
                }

                // TEMPORARY!
                if (Convert.ToDateTime(DepartureDt) < Convert.ToDateTime("05/20/2011"))
                    if (DepartureDt != null)
                        return;

                StringBuilder sql = new StringBuilder();
                sql.AppendFormat(@"
				insert into s_line_cargo 
                  (serial_no, deleted_flg, booking_no, edi_ref_no,
				   customer_ref_no, bol_no, voyage_no, vessel_cd,
					plor_location_cd, pol_location_cd, pod_location_cd, plod_location_cd, 
						move_type_cd, make_cd, model_cd, commodity_cd,
						length_nbr, width_nbr, height_nbr, weight_nbr, cargo_dsc, sail_dt,
                        pol_location_dsc, pod_location_dsc, plor_location_dsc, plod_location_dsc,
                        container_no, seal1, seal2, seal3, cargo_type,
                        dim_weight_nbr, cube_ft, m_tons, item_no, customer_cd, 
                        match_cd, customer_nm,
                        cargo_rcvd_dt, cargo_key)
				  select '{0}', '{1}', '{2}', '{3}',
						 '{4}', '{5}', '{6}', '{7}',
						 '{8}', '{9}', '{10}', '{11}',
						 '{12}', '{13}', '{14}', '{15}',
						 {16}, {17}, {18}, {19}, '{20}', '{21}', 
                         '{22}', '{23}', '{24}', '{25}',
                         '{26}', '{27}', '{28}', '{29}', '{30}',
                         {31}, {32}, {33}, {34}, '{35}', '{36}', '{37}',
                         '{38}','{39}'
                         from dual ",
                        SerialNo, DeletedFlg, BookingNo.ToUpper(), EDIRefNo,
                        CustomerRefNo, BOLNo, VoyageNo.ToUpper(), VesselCd.ToUpper(),
                        Plor.ToUpper(), POL.ToUpper(), POD.ToUpper(), Plod.ToUpper(),
                        MoveTypeCd, MakeCd, ModelCd, CommodityCd,
                        Length, Width, Height, Weight, CargoDsc, DepartureDt,
                        POLDescription, PODDescription,
                        PlorDescription, PlodDescription,
                        ContainerNo, Seal1, Seal2, Seal3, CargoTypeCd,
                        DimWeight, CubeFt, MTon, ItemNo, CustomerNo,
                        MatchCd, CustomerNm,
                        CargoRcvdDt, CargoKey);

                results.sLastSQL = sql.ToString() + ' ' + SerialNo;

                ConnectionARCImport.RunSQL(sql.ToString());
            }
            catch (Exception ex)
            {
                string sMsg = ex.Message;
                throw;
            }
		}

        public DataRow GatherVoyageData(string sVoyage, string sLocation)
        {
            string s = sqlGetACMSVoyageData;
            s = s.Replace("@VOYNO", sVoyage);
            s = s.Replace("@LOC", sLocation).ToUpper();

            DataTable dt = ConnectionACMS.GetDataTable(s);
            if (dt.Rows.Count < 1)
            {
                return null;
            }
            return dt.Rows[0];
        }

        public void UpdateWithACMSData(DataTable dtACMS)
        {
            foreach (DataRow drow in dtACMS.Rows)
            {
                sACMSBookingID = drow["booking_id"].ToString();
                sACMSBookingSub = drow["booking_id_sub"].ToString();
                sDeliveryDsc = drow["delivery_dsc"].ToString();
                sNotes = drow["ACMSNotes"].ToString();
                UpdateCargo();
            }
        }

        public void UpdateCargo()
        {
            ConnectionARCImport.TransactionBegin();
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat(@"
                     update s_line_cargo
                     set delivery_dsc = '{0}',
                         cargo_notes = '{1}'
                      where booking_no = '{2}'",
                    sDeliveryDsc, sNotes, sACMSBookingID);
                ConnectionARCImport.RunSQL(sb.ToString());
                ConnectionARCImport.TransactionCommit();
            }
            catch (Exception ex)
            {
                string sMsg = ex.Message;
                ConnectionARCImport.TransactionRollback();
                throw;
            }
        }

		public void InsertNewBookings()
		{
            ConnectionARCImport.TransactionBegin(); ;
			try
			{
                results.iNewBookings = ConnectionARCImport.RunSQL(sqlInsertBookings);
                ConnectionARCImport.TransactionCommit();
			}
			catch( Exception ex )
			{
                ConnectionARCImport.TransactionRollback();
				throw ex;
			}
		}

		public void InsertNewCargo()
		{
            ConnectionARCImport.TransactionBegin(); ;
			try
			{
                results.iNewCargo = ConnectionARCImport.RunSQL(sqlInsertCargo);
                ConnectionARCImport.TransactionCommit();
			}
			catch( Exception ex )
			{
                ConnectionARCImport.TransactionRollback();
				throw ex;
			}
		}

		public void InsertNewCargoActivity()
		{
            ConnectionARCImport.TransactionBegin(); ;
            try
            {
                results.iNewCargoActivity = ConnectionARCImport.RunSQL(sqlInsertCargoActivity1);
                results.iNewCargoActivity = results.iNewCargoActivity +
                     ConnectionARCImport.RunSQL(sqlInsertCargoActivity2);
                ConnectionARCImport.TransactionCommit();
            }
            catch (SqlException ex)
            {
                ConnectionARCImport.TransactionRollback();
                throw ex;
            }
            catch (Exception ex)
            {
                ConnectionARCImport.TransactionRollback();
                throw ex;
            }
		}
			#endregion

        #region Changes Methods
        public static bool FindChanges()
        {
            //
            // This will look to see if changes have been found to 
            // cargo activity that is assigned to an estimate.
            //
            DataTable dt = GetChangedCargo();
            if (dt.Rows.Count > 0)
                return true;
            return false;
        }

        public static DataTable GetChangedCargo()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat(@"
                select v_all_changes.*, estimate_no from v_all_changes 
                  inner join t_estimate on v_all_changes.estimate_id = t_estimate.estimate_id
               order by booking_no, serial_no ");
            DataTable dt = ConnectionARCImport.GetDataTable(sql.ToString());
            return dt;
        }

        public static void UpdateChangedCargo(DataTable dt)
        {
            bool InTrans = ConnectionARCImport.IsInTransaction;

            try
            {
                if (!InTrans)
                {
                    ConnectionARCImport.TransactionBegin();
                }
                foreach (DataRow dr in dt.Rows)
                {
                    string sEstimateID = dr["estimate_id"].ToString();
                    string sSerialNo = dr["serial_no"].ToString();
                    string sColumn = dr["descr"].ToString();
                    string sOld = dr["old"].ToString();
                    string sNew = dr["new"].ToString();
                    string sPrimaryID = dr["primary_id"].ToString();
                    string sColumnType = dr["column_type"].ToString();
                    string sActivityID = dr["cargo_activity_id"].ToString();
                    string[] BookingColumns =
                        new string[9] {"vessel_cd", "voyage_no", "plor_location_cd",
                        "pol_location_cd", "pod_location_cd", "plod_location_cd", "sail_dt",
						"customer_cd", "match_cd"};

                    string sPrimaryColumn = "cargo_id";
                    string sTable = "t_cargo";
                    if (Array.IndexOf(BookingColumns, sColumn) > -1)
                    {
                        sTable = "t_booking";
                        sPrimaryColumn = "booking_ID";
                    }

                    switch (sColumnType)
                    {
                        case "N":
                            // Cargo Numeric column updates
                            StringBuilder sqlCargoNbr = new StringBuilder();
                            sqlCargoNbr.AppendFormat(@"
                        update {3} 
                            set {0} = {1}
                          where {4} = {2}",
                              sColumn, sNew, sPrimaryID, sTable, sPrimaryColumn);
                            ConnectionARCImport.RunSQL(sqlCargoNbr.ToString());
                            break;
                        case "C":
                        case "D":
                            // Cargo Character column updates
                            StringBuilder sqlCargoTxt = new StringBuilder();
                            sqlCargoTxt.AppendFormat(@"
                        update {3} 
                            set {0} = '{1}'
                          where {4} = {2}",
                              sColumn, sNew, sPrimaryID, sTable, sPrimaryColumn);
                            ConnectionARCImport.RunSQL(sqlCargoTxt.ToString());
                            break;
                    }
                    StringBuilder sqlAudit = new StringBuilder();
                    sqlAudit.AppendFormat(@"
                    insert into t_cargo_change 
                    select arc_owner.cargo_change_id_seq.nextval,
                        {0}, null, null, null, null, '{1}', '{2}', '{3}', '{4}', '{5}' from dual",
                         sEstimateID, sActivityID, sSerialNo, sColumn, sOld, sNew);
                    ConnectionARCImport.RunSQL(sqlAudit.ToString());

                }
                if (!InTrans)
                {
                    ConnectionARCImport.TransactionCommit();
                }
            }
            catch (Exception ex)
            {
                ClsErrorHandler.LogException(ex);
                if (!InTrans)
                {
                    ConnectionARCImport.TransactionRollback();
                }
                throw;
            }
        }

        #endregion

        #region UnassignedCargo
        public DataTable GetUnassignedCargoFromLINE()
        {
            // First, get Door-In
            //
            StringBuilder sb = BuildUnassignedString(
                    sqlSelectBreakBulk, sqlFromBreakBulk, sqlDoorInFilter);
            DataTable dtBBIn = ConnectionLine.GetDataTable(sb.ToString());
            sb = BuildUnassignedString(sqlSelectRoRo, sqlFromRoRo, sqlDoorInFilter);
            DataTable dtRoRoIn = ConnectionLine.GetDataTable(sb.ToString());
            sb = BuildUnassignedString(sqlSelectContainers, sqlFromContainers, sqlDoorInFilter);
            DataTable dtContIn = ConnectionLine.GetDataTable(sb.ToString());

            // Append the Door-Out
            sb = BuildUnassignedString(sqlSelectBreakBulk, sqlFromBreakBulk, sqlDoorOutFilter);
            DataTable dtBBOut = ConnectionLine.GetDataTable(sb.ToString());
            sb = BuildUnassignedString(sqlSelectRoRo, sqlFromRoRo, sqlDoorOutFilter);
            DataTable dtRoRoOut = ConnectionLine.GetDataTable(sb.ToString());
            sb = BuildUnassignedString(sqlSelectContainers, sqlFromContainers, sqlDoorOutFilter);

            // Merge all datatables together
            DataTable dtCargo = new DataTable();
            dtCargo.Merge(dtBBIn);
            dtCargo.Merge(dtRoRoIn);
            dtCargo.Merge(dtBBOut);
            dtCargo.Merge(dtRoRoOut);
            QueryCounter = 0;
            QueryTotal = dtCargo.Rows.Count;
            QueryInProgress = true;
            dtCargo = AppendARCData(dtCargo);
            return dtCargo;
        }

        public StringBuilder BuildUnassignedString(string sqlSelect, string sqlFrom, string sqlDoorFilter)
        {
            StringBuilder sb = new StringBuilder(sqlSelect);
            sb.Append(sqlSelectSchedule);
            if (sqlDoorFilter == sqlDoorInFilter)
                sb.Append(", 'Door In' as DoorType ");
            else
                sb.Append(", 'Door Out' as DoorType ");
            sb.Append(sqlFrom);
            sb = sb.Replace("as plor", "as Origin");
            sb = sb.Replace("as plor_dsc", "as origin_dsc");
            sb = sb.Replace("as pol", "as Destination");
            sb = sb.Replace("as pol_dsc", "as Destination_dsc");
            sb.Append(sqlJoinSchedule);
            sb.Append(sqlMainFilter);
            sb.AppendFormat(@"
                  /*AND (dba.bu1_kopf.bu1kdmtc LIKE '%SDDC%') */
                  AND (dba.bu1_kopf.bu1status2 = 'C') 
                  and (dba.bu1_kopf.bu1voyage like '{0}' )
                  AND (dba.bu1_kopf.bu1createdat > GETDATE() - 30) ",
                      "%");
            sb.Append(sqlDoorFilter);
            return sb;
        }

        public DataTable AppendARCData(DataTable dt)
        {
            try
            {
                dt.Columns.Add("estimate_no");

                foreach (DataRow dr in dt.Rows)
                {
                    QueryCounter++;
                    string sVoyage = dr["voyage_no"].ToString();
                    string sTCN = dr["tcn"].ToString();
                    sTCN = CleanSerialNo(sTCN);
                    string sOrigin = dr["origin"].ToString();
                    string sDestination = dr["destination"].ToString();
                    ClsCargoActivity act = ClsCargoActivity.GetByTCNVoyagePorts(
                        sTCN, sVoyage, sOrigin, sDestination);

                    dr["estimate_no"] = "none";
                    if (act != null)
                    {
                        if (act.Estimate != null)
                        {
                            dr["estimate_no"] = act.Estimate.Estimate_No;
                        }
                    }
                }
                return dt;
            }
            catch (Exception ex)
            {
                ClsErrorHandler.LogException(ex);
                return null;
            }
            finally
            {
                QueryInProgress = false;
            }
        }
        
        #endregion

        #region UnassignedCargo from ARC database
        public DataTable GetUnassignedCargo()
        {
            string sqlIn = @"
                select booking_no,
                       plor_location_cd as Origin, plor_location_dsc as origin_dsc,
                       pol_location_cd as destination, pol_location_dsc as destination_dsc,
                       serial_no as tcn,
                       move_type_cd as move_type,
                       'Door In' as DoorType,
                       voyage_no, 
                       vessel_cd,
                       sail_dt
                from S_LINE_CARGO t
                    where sail_dt > sysdate - 90
                      and move_type_cd in ('F5','F6','F9') ";
            DataTable dtIn = ConnectionARCImport.GetDataTable(sqlIn);

            string sqlOut = @"
                select booking_no,
                       pod_location_cd as Origin, pod_location_dsc as origin_dsc,
                       plod_location_cd as destination, plod_location_dsc as destination_dsc,
                       serial_no as tcn,
                       move_type_cd as move_type,
                       'Door Out' as DoorType,
                       voyage_no, 
                       vessel_cd,
                       sail_dt
                from S_LINE_CARGO t
                    where sail_dt > sysdate - 90
                      and move_type_cd in ('F7','F8','F9') ";
            DataTable dtOut = ConnectionARCImport.GetDataTable(sqlOut);

            dtIn.Merge(dtOut);
            return dtIn;
        }
        #endregion

        #region LINE Query
		public DataTable QueryLINEData(string VoyageNo, string BookingNo, string TCN, bool bExceptions)
		{
			return QueryLINEData(VoyageNo, BookingNo, TCN, bExceptions, null, null);
		}

        public DataTable QueryLINEData(string VoyageNo, string BookingNo, string TCN, bool bExceptions, string sPOL, string sPOD)
        {
            // Get Breakbulk cargo
			StringBuilder sql = new StringBuilder(sqlSelectBreakBulk);
            sql.Append(sqlFromBreakBulk);
            sql.Append(sqlMainFilter);
            sql.Append(sqlQueryFilter(VoyageNo, BookingNo, bExceptions, sPOL, sPOD));
			if (!string.IsNullOrEmpty(TCN))
			{
				sql.AppendFormat(" and dba.bu14_itemdetail.bu14trackingref = '{0}' ", TCN);
			}
			string s = sql.ToString();
            DataTable dtBB = ConnectionLine.GetDataTable(sql.ToString());

			// Get Roro cargo
            sql = new StringBuilder(sqlSelectRoRo);
            sql.Append(sqlFromRoRo);
            sql.Append(sqlMainFilter);
            sql.Append(sqlQueryFilter(VoyageNo, BookingNo, bExceptions, sPOL, sPOD));
			if (!string.IsNullOrEmpty(TCN))
			{
				sql.AppendFormat(" and dba.car_head.cr1_vin = '{0}' ", TCN);
			}
            DataTable dtRR = ConnectionLine.GetDataTable(sql.ToString());

			// Get Container cargo
            sql = new StringBuilder(sqlSelectContainers);
            sql.Append(sqlFromContainers);
            sql.Append(sqlMainFilter);
            sql.Append(sqlQueryFilter(VoyageNo, BookingNo, bExceptions, sPOL, sPOD));
			if (!string.IsNullOrEmpty(TCN))
			{
				sql.AppendFormat(" and dba.bu4_cont.bu4remgte = '{0}' ", TCN);
			}
            DataTable dtCn = ConnectionLine.GetDataTable(sql.ToString());

			// Merge all three types of cargo into a single datatable
            DataTable dt = new DataTable();
            dt.Merge(dtRR);
            dt.Merge(dtBB);
            dt.Merge(dtCn);

            int r = dtRR.Columns.Count;
            int b = dtBB.Columns.Count;
            int c = dtCn.Columns.Count;

            return dt;
        }

        protected string _sqlQueryFilter = @"
              and (dba.bu1_kopf.bu1voyage like '@VOYAGE' )
              and (dba.bu1_kopf.bu1bunr like '@BOOKNO' )
              ";

        protected string sqlQueryFilter(string VoyageNo, string BookingNo, bool bExceptions, string POL, string POD)
        {
            string sql = _sqlQueryFilter;
            sql = sql.Replace("@VOYAGE", VoyageNo);
            sql = sql.Replace("@BOOKNO", BookingNo);
			if (!string.IsNullOrEmpty(POL))
				sql = sql + string.Format(" and dba.bu1_kopf.bu1polcde = '{0}' ", POL);
			if (!string.IsNullOrEmpty(POD))
				sql = sql + string.Format(" and dba.bu1_kopf.bu1podcde = '{0}' ", POD);
            if (bExceptions)
            {
                sql = sql + "and ( ";
                //sql = sql + " (dba.bu1_kopf.bu1kdmtc NOT LIKE '%SDDC%') OR ";
                sql = sql + " (dba.bu1_kopf.bu1status2 <>  'C') OR ";
                sql = sql + " (dba.bu1_kopf.bu1loesch = 'Y' ) ";
                sql = sql + ")";
            }
            return sql;
        }
        #endregion

    }
}
