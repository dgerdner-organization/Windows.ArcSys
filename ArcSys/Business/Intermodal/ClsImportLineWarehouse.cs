using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;
using CS2010.ArcSys.Business;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Linq;

namespace CS2010.ArcSys.Business
{
	public class ClsImportLineWarehouse
	{
		#region Fields
        private double InchesMultiplier = 0.393700787;
        private double PoundsMultiplier = 2.20462262;
		private bool _bAudit;
		public bool bAudit
		{ 
			get { return _bAudit; }
			set { _bAudit = value; }
		}


		//private decimal? CubeFt
		//{
		//    get
		//    {
		//        decimal? cf;
		//        cf = Length * Width * Height / 1728;
		//        if (!cf.HasValue)
		//            cf = 0;
		//        cf = Math.Round(cf.Value, 3);
		//        return cf;
		//    }
		//}
		//private decimal? MTon
		//{
		//    get
		//    {
		//        decimal? mt;
		//        mt = CubeFt / 40;
		//        mt = Math.Round(mt.Value, 3);
		//        return mt;
		//    }
		//}
		//private decimal? DimWeight
		//{
		//    get
		//    {
		//        decimal? dw;
		//        dw = Length * Width * Height;
		//        dw = dw / 166;
		//        dw = Math.Round(dw.Value, 2);
		//        if (dw > Weight)
		//            return dw;
		//        Weight = WeightRounding(Weight);
		//        return Weight;
		//    }
		//}

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
		ImportWarehouseResults results;

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
            //serialno = serialno.Replace("-", "");
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

		#region Find Deleted Cargo
		protected string sqlFindRoRo = @"
			select dba.car_head.cr1_manr
              from dba.car_head
            where dba.car_head.cr1_manr = @ID
              and dba.car_head.cr1_bumanr is not null";

		protected string sqlFindBB = @"
			SELECT bu14_itemdetail_id
			FROM dba.bu14_itemdetail where bu14_itemdetail_id = @ID ";

		protected string sqlFindCont = @"
		    select b.bu1bunr, c.bu4remgte
			 from dba.bu4_cont c
				 inner join dba.bu1_kopf b
				  on b.bu1bumanr = c.bu4bumanr
				 where b.bu1bunr = '@BKNO'
				  and bu4remgte = '@SERNO'";

		protected string sqlDeleteCargo = @"
			delete from t_cargo_line where cargo_line_id = @CLID ";

		#endregion

		#region Import LINE DataWarehouse

		#region BOL's
		protected string sqlSelectBOL = @"
			SELECT bl1blmanr as bol_id, 
				   null as create_user,
				   null as create_dt,
				   null as modify_user,
				   null as modify_dt,
				   bl1blnr as bol_no, 
				   bl1bumanr as booking_line_id, 
				   bl1bunr as booking_no, 
				   bl1status as bol_status, 
				   bl1finalmanifestkz as final_manifest_flg,
				   bl1voyage as voyage_no, 
				   bl1vessel as vessel_no,
				   bl1service as service_cd,
				   bl1loesch as deleted_flg,
				   bl1crtdt AS bol_create_dt, 
				   bl1creator AS bol_create_user
			FROM   dba.bl1_kopf
		   WHERE     (bl1crtdt > GETDATE() - 30)";

		#endregion

		#region Bookings Warehouse
		//
		//  Get bookings created within the last week
		//
		string sqlGetBookingsLINE = @"
			select * from v_LINE_bookings
			  where modify_dt > sysdate - @DAYS ";
		string sqlNewBookingAppend = @"	 and not exists (select 1 from t_booking_line where v_line_bookings.booking_line_id = t_booking_line.booking_line_id)  ";
		string sqlGetChangedBkLINE = @" select * from v_LINE_bk_changed WHERE modify_dt > sysdate - 14 ";
			
		
		string sqlGetBookings = @"
			SELECT		dba.bu1_kopf.bu1bumanr AS booking_id, 
					    dba.bu1_kopf.bu1bumanr AS booking_line_id,
						dba.bu1_kopf.bu1bunr AS booking_no, 
						dba.bu1_kopf.firma AS agent_cd, 
						dba.bu1_kopf.bu1createdat AS booking_dt, 
						dba.bu1_kopf.bu1verart AS cargo_type, 
						dba.bu1_kopf.bu1vessel AS vessel_cd, 
						dba.bu1_kopf.bu1voyage AS voyage_no, 
						dba.bu1_kopf.bu1plorcde AS plor_location_cd, 
						dba.bu1_kopf.bu1plofrec AS plor_dsc, 
						dba.bu1_kopf.bu1polcde AS pol_location_cd, 
						dba.bu1_kopf.bu1polbez AS pol_dsc, 
						dba.bu1_kopf.bu1polberth AS pol_berth, 
						dba.bu1_kopf.bu1podcde AS pod_location_cd, 
						dba.bu1_kopf.bu1podbez AS pod_dsc, 
						dba.bu1_kopf.bu1podberth AS pod_berth, 
						dba.bu1_kopf.bu1plodcde AS plod_location_cd, 
						dba.bu1_kopf.bu1plofdel AS plod_dsc, 
						dba.bu1_kopf.bu1status2 AS booking_status, 
						dba.bu1_kopf.bu1kdnr AS customer_cd, 
						dba.bu1_kopf.bu1kdmtc AS match_cd, 
						dba.kunde.kdname1 AS customer_nm, 
						dba.bu1_kopf.bu1loesch AS deleted_flg, 
						dba.bu1_kopf.bu1ediref AS edi_ref, 
						dba.bu1_kopf.bu1kdref AS  customer_ref, 
						dba.bu1_kopf.bu1vskond AS move_type_cd, 
						dba.bu1_kopf.bu1imdgkz AS imdg_flg, 
						dba.bu1_kopf.bu1kopcde AS kind_of_pkg_cd, 
						dba.bu1_kopf.bu1createuser AS create_user, 
						dba.bu1_kopf.bu1createdat AS create_dt, 
						dba.bu1_kopf.bu1changeuser AS modify_user, 
						dba.bu1_kopf.bu1aenddat AS modify_dt, 
						null as sail_dt,
						dba.vw_d_bu1_inout.POL_ets as pol_ets, 
						dba.vw_d_bu1_inout.POD_eta as pod_eta,
						dba.bu1_kopf.bu1status as booking_status_cd,
						null as bol_id,
						null as bol_no,
						'' as delivery_txt,
						'' as cargo_notes_txt,
						'' as booking_ref,
						null as rdd_dt,
						'N' as ilms_eligible_flg,
						dba.bu1_kopf.bu1tariffcat1 as tariff_cd
				FROM  dba.bu1_kopf INNER JOIN
                      dba.kunde ON dba.kunde.kdkdnr = dba.bu1_kopf.bu1kdnr AND dba.kunde.firma = dba.bu1_kopf.firma INNER JOIN
                      dba.vw_d_bu1_inout ON dba.bu1_kopf.bu1bumanr = dba.vw_d_bu1_inout.bu1bumanr
                where dba.bu1_kopf.firma = 'ARC'
                  and dba.bu1_kopf.bu1aenddat > getdate() - @DAYS";
		#endregion

		#region   BreakBulk Warehouse
		//
		// Breakbulk within the last Six months
		//
		//  Takes about 30 minutes
		protected string sqlSelectBB = @"
            SELECT  
                    null as cargo_line_id,
					'BREAKBULK' + CAST(dba.bu14_itemdetail.bu14_itemdetail_id AS varchar(10)) as cargo_key,
					dba.bu1_kopf.bu1bumanr as booking_line_id,
					dba.bu14_itemdetail.bu14trackingref as serial_no,
                    bu14lfnr as item_no,
					dba.bu1_kopf.bu1createuser AS create_user, 
					dba.bu1_kopf.bu1createdat AS create_dt, 
					dba.bu1_kopf.bu1changeuser AS modify_user, 
					dba.bu1_kopf.bu1aenddat AS modify_dt, 
					dba.bu3_item.bu3comcde as commodity_cd,
                    dba.bu3_item.bu3kopcde as pkg_type_cd,
                    CAST(bu14length AS numeric(13, 4)) AS length_nbr, 
                    cast(dba.bu14_itemdetail.bu14height as numeric(13,4)) as height_nbr,
                    cast(isnull(dba.bu14_itemdetail.bu14width, 0) as numeric (13,4)) as width_nbr,
                    cast(isnull(dba.bu14_itemdetail.bu14weight, 0)as numeric(13,4)) as weight_nbr,
					0 as dim_weight_nbr,
					0 as cube_ft,
					0 as m_tons,
                    dba.bu1_kopf.bu1vskond as move_type_cd,
					dba.bu3_item.bu3desofg as cargo_dsc,
					null as vessel_load_dt,
					null as contract_mod_id,
					null as container_no,
                    '' as seal1, '' as seal2, '' as seal3,
                    '' as make_cd,
                    '' as model_cd,
                    convert(varchar(20),dba.bu14_itemdetail.bu14cargorecvdate, 106)AS cargo_rcvd_dt,
					'' as import_notes_txt,
					'BKBK' AS cargo_type_cd, 
					dba.bu14_itemdetail.bu14status AS cargo_status, 
					dba.bl1_kopf.bl1blnr AS bol_no, 
                    dba.bl1_kopf.bl1status AS bol_status,
					null as rdd_dt,
					dba.bu14_itemdetail.bu14ecncrn as ecn_rcn, 
					dba.bu14_itemdetail.bu14statusdatetime cargo_status_dt, 
                    dba.bu14_itemdetail.bu14rownr as seq_no
			     FROM dba.bu1_kopf INNER JOIN
				      dba.bu3_item ON dba.bu1_kopf.bu1bumanr = dba.bu3_item.bu3bumanr INNER JOIN
                      dba.bu14_itemdetail ON dba.bu3_item.bu3bumanr = dba.bu14_itemdetail.bu14manr AND 
                      dba.bu3_item.bu3bulfnr = dba.bu14_itemdetail.bu14lfnr INNER JOIN
                      dba.kunde ON dba.kunde.kdkdnr = dba.bu1_kopf.bu1kdnr AND dba.kunde.firma = dba.bu1_kopf.firma 
					LEFT OUTER JOIN  dba.bl1_kopf 
						ON dba.kunde.firma = dba.bl1_kopf.firma 
						AND dba.kunde.kdkdnr = dba.bl1_kopf.bl1kdnr 
						AND dba.bu1_kopf.bu1bumanr = dba.bl1_kopf.bl1bumanr
                where dba.bu1_kopf.firma = 'ARC'
                  and dba.bu1_kopf.bu1aenddat > getdate() - @DAYS
				  and dba.bu14_itemdetail.bu14trackingref is not null";

		protected string sqlBBFilter = @"
              and (dba.bu14_itemdetail.bu14trackingref IS NOT NULL) ";
		#endregion

		#region RoRo Warehouse
		//
		// roRo changed in the last 60 days
		//
		//   NOTE:  60 days takes about 5 minutes
		protected string sqlSelectRR = @"
			SELECT  
				null as cargo_line_id,
				'RORO' + CAST(dba.car_head.cr1_manr AS varchar(10)) as cargo_key,
				dba.bu1_kopf.bu1bumanr as booking_line_id,
				dba.car_head.CR1_VIN as serial_no, 
                dba.car_head.cr1_buitem as item_no,
				dba.car_head.cr1_create_user AS create_user, 
				dba.car_head.cr1_create_date AS create_dt, 
				dba.car_head.cr1_change_user AS modify_user, 
				dba.car_head.cr1_change_date AS modify_dt, 
				' ' as commodity_cd,
                ' ' as pkg_type_cd,
				cast(dba.car_head.cr1_length as numeric(13,4)) as length_nbr, 
				cast(dba.car_head.cr1_height as numeric(13,4)) as height_nbr, 
                cast(dba.car_head.cr1_width as numeric(13,4)) as width_nbr,
				cast(dba.car_head.cr1_weight as numeric(13,4)) as weight_nbr, 
				0 as dim_weight_nbr,
				0 as cube_ft,
				0 as m_tons,
                dba.bu1_kopf.bu1vskond as move_type_cd,
				dba.car_head.cr1_modelname as cargo_dsc,
				null as vessel_load_dt,
				null as contract_mod_id,
				null as container_no,
                '' as seal1, '' as seal2, '' as seal3,
				dba.car_head.cr1_manufacturer as make_cd, 
				dba.car_head.cr1_model as model_cd, 
				dba.car_head.cr1_manufactur_ref as mfr_ref, 
                0 as container_wt,
                convert(varchar(20),dba.car_head.cr1_cargorecvdate,106) AS cargo_rcvd_dt,
				'' as import_notes_txt,
				'RORO' AS cargo_type_cd, 
				dba.car_head.cr1_ecstatus AS cargo_status, 
				dba.bl1_kopf.bl1blnr as bol_no, 
				dba.bl1_kopf.bl1status as bol_status,
				null as rdd_dt, 
				dba.car_head.cr1_ecncrn AS ecn_rcn, 
				dba.car_head.cr1_ecstatusdatetime AS cargo_status_dt, 
                dba.car_head.cr1_buitem_seqno AS seq_no
			FROM  dba.car_head LEFT OUTER JOIN
				  dba.bu1_kopf ON dba.car_head.cr1_bumanr = dba.bu1_kopf.bu1bumanr 
                  INNER JOIN dba.kunde on dba.kunde.kdkdnr = dba.bu1_kopf.bu1kdnr AND dba.kunde.firma = dba.bu1_kopf.firma
				  LEFT OUTER JOIN dba.bl1_kopf ON dba.car_head.firma = dba.bl1_kopf.firma AND dba.car_head.cr1_blmanr = dba.bl1_kopf.bl1blmanr
             WHERE dba.car_head.cr1_change_date > getdate() - @DAYS
			   AND dba.bu1_kopf.firma = 'ARC'
		
                ";

		#endregion

		#region Container Warehouse
		//
		// All containers (because there aren't that many)
		//
		//   NOTE:  Takes about 2/3 minutes
		//
		private static string sqlSelectCont = @"
				SELECT 
					null as cargo_line_id,
                    'CONT' + CAST(bu4bumanr AS varchar(10)) + ' ' + CAST(bu4bulfnr AS varchar(5)) + ' ' + CAST(bu4cnlfnr AS varchar(5)) AS cargo_key,
					dba.bu1_kopf.bu1bumanr as booking_line_id,
					dba.bu4_cont.bu4remgte as serial_no,
                    dba.bu4_cont.bu4bulfnr as item_no,
                    dba.bu1_kopf.bu1vskond as move_type_cd,
                    bu4kopcde as pkg_type_cd, 
                    bu4comcde as commodity_cd, 
                    '' as make_cd,
                    '' as model_cd,
                    '' as mfr_ref,
                    bu4kopbez as cargo_dsc, 
					dba.bu1_kopf.bu1createuser AS create_user, 
					dba.bu1_kopf.bu1createdat AS create_dt, 
					dba.bu1_kopf.bu1changeuser AS modify_user, 
					dba.bu1_kopf.bu1aenddat AS modify_dt, 
                    isnull(cast(dba.containerart.cttcontsz as numeric(14,3)),0) as length_nbr, 
                    isnull(cast(dba.containerart.cttconthg as numeric(14,3)),0) as height_nbr, 
                    isnull(cast(dba.containerart.cttcontwd as numeric(14,3)),0) as width_nbr,
                    cast(bu4unitgrw as numeric(13,4)) as weight_nbr,
					0 as dim_weight_nbr,
					0 as cube_ft,
					0 as m_tons,
					null as vessel_load_dt,
					null as contract_mod_id,
                    bu4contnr as container_no,
                    bu4seal1 as seal1, bu4seal2 as seal2, bu4seal3 as seal3,
                    0 as container_wt,
                    convert(varchar(20),dba.bu4_cont.bu4cargorecvdate,106) AS cargo_rcvd_dt,
					'' as import_notes_txt,
				    'CONT' as cargo_type_cd,
					dba.bu4_cont.bu4ecstatus as cargo_status,
					dba.bl1_kopf.bl1blnr as bol_no, 
					dba.bl1_kopf.bl1status as bol_status,
					null as rdd_dt, 
					dba.bu4_cont.bu4ecncrn AS ecn_rcn, 
					dba.bu4_cont.bu4ecstatusdatetime AS cargo_status_dt, 
                    0 AS seq_no
				FROM dba.bl1_kopf INNER JOIN
                     dba.bl_bu_cont_link ON dba.bl1_kopf.bl1blmanr = dba.bl_bu_cont_link.bbcblmanr AND 
                     dba.bl1_kopf.bl1bumanr = dba.bl_bu_cont_link.bbcbumanr RIGHT OUTER JOIN
                     dba.bu4_cont INNER JOIN
                     dba.bu1_kopf ON dba.bu4_cont.bu4bumanr = dba.bu1_kopf.bu1bumanr INNER JOIN
                      dba.containerart ON dba.bu4_cont.firma = dba.containerart.firma AND dba.bu4_cont.bu4contart = dba.containerart.cttcontart INNER JOIN
                      dba.kunde ON dba.kunde.kdkdnr = dba.bu1_kopf.bu1kdnr AND dba.kunde.firma = dba.bu1_kopf.firma ON 
                      dba.bl_bu_cont_link.bbcbumanr = dba.bu4_cont.bu4bumanr AND dba.bl_bu_cont_link.bbcbulfnr = dba.bu4_cont.bu4bulfnr AND 
                      dba.bl_bu_cont_link.bbcbucnlfnr = dba.bu4_cont.bu4cnlfnr
					WHERE dba.bu1_kopf.bu1aenddat > getdate() - @DAYS
					  AND dba.bu1_kopf.firma = 'ARC'";

		#endregion

		#region Hazardous
		private static string sqlPurgeHazardous = @"
			delete from t_line_imdg";

		private static string sqlGetHazardous = @"
			select 
			dg1dgmanr as imdg_id,
			dg1agtref as ref_no,
			dg1level as level_cd,
			dg1imdgkl as imdg_class,
			dg1unnr as un_cd,
			dg1techbez as imdg_dsc,
			dg1ntw as net_wt,
			dg1grw as gross_wt,
			dg1kopop1 as type_dsc
			from dba.dg1_anfrage
			where firma <> 'TST'
			and dg1credat > getdate() - 360";

		#endregion

		#endregion

		#region Purge Statements

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
		string sqlRemoveNotes = @"
				update t_cargo_line
				 set import_notes_txt = null
				 where import_notes_txt is not null";

		string sqlDuplicates = @"
			update t_cargo_line
			 set import_notes_txt = 'Duplicate Serial Number'
			  where serial_no in
			  (
						select  serial_no
						 from t_cargo_line c
						  inner join t_booking_line b on c.booking_line_id = b.booking_line_id
						  where booking_dt > sysdate - 90
							and deleted_flg = 'N'
                            and booking_status <> 'P'
							and cargo_status not like 'DELET%'
						  group by serial_no, voyage_no
						  having count(serial_no) > 1 )";


//        string sqlNonLandPLOR = @"
//             update t_cargo_line
//              set import_notes_txt = 'Door In cargo has a PORT PLOR'
//              where cargo_key in
//              (
//             select cargo_key
//              from t_cargo_line l
//               inner join t_booking_line bl on l.booking_line_id = bl.booking_line_id
//              left outer join r_location loc
//                on bl.plor_location_cd = loc.location_cd
//              where bl.move_type_cd in ('F5','F6','F9')
//               and location_type_cd <> 'LAND'
//               and bl.deleted_flg = 'N'
//               and bl.booking_dt > sysdate - 90
//			   and bl.booking_status <> 'P'
//			   and bl.booking_no not in ('ARCA11008382', 'ARCA11008383','ARCA11008571')
//			   and bl.booking_no not in ('ARCA12000465','ARCA12000467','ARCA12000468','ARCA12000469','ARCA12001859')
//			   and bl.booking_no not in (
//					select booking_no from t_exception_override 
//                       where override_cd = 'O' )
//               )";

		string sqlMissingPLOR = @"
             update t_cargo_line
              set import_notes_txt = 'Door In booking missing the PORT PLOR'
              where serial_no in
              (
             select serial_no
              from t_cargo_line l
               inner join t_booking_line bl on l.booking_line_id = bl.booking_line_id
              left outer join r_location loc
                on bl.plor_location_cd = loc.location_cd
              where bl.move_type_cd in ('F5','F6','F9')
               and location_type_cd is null
               and bl.deleted_flg = 'N'
               and bl.booking_dt > sysdate - 90
         and bl.booking_status <> 'P'
               )";

//        string sqlNonLandPLOD = @"
//             update t_cargo_line
//              set import_notes_txt = 'Door OUT cargo has a PORT PLOD'
//              where cargo_key in
//              (
//             select cargo_key
//              from t_cargo_line l
//              inner join t_booking_line bl on bl.booking_line_id = l.booking_line_id
//              left outer join r_location loc
//                on bl.plod_location_cd = loc.location_cd
//              where bl.move_type_cd in ('F7','F8','F9')
//               and location_type_cd <> 'LAND'
//               and bl.deleted_flg = 'N'
//               and bl.booking_dt > sysdate - 90
//               and bl.booking_status <> 'P'
//               )";

		string sqlMissingPLOD = @"
             update t_cargo_line
              set import_notes_txt = 'Door In booking missing the PORT PLOD'
              where serial_no in
              (
             select serial_no
              from t_cargo_line l
               inner join t_booking_line bl on l.booking_line_id = bl.booking_line_id
              left outer join r_location loc
                on bl.plod_location_cd = loc.location_cd
              where bl.move_type_cd in ('F7','F8','F9')
               and location_type_cd is null
               and bl.deleted_flg = 'N'
               and bl.booking_dt > sysdate - 90
         and bl.booking_status <> 'P'
               )";

		string sqlPending = @"
			update t_cargo_line c
			 set import_notes_txt = 'Booking is Pending'
			 where exists
			 (select 1 from t_booking_line b
			  where c.booking_line_id = b.booking_line_id
			   and b.booking_status = 'P')";

//        string sqlNoSailDateOld= @"
//			update t_cargo_line c
//			 set import_notes_txt = 'No Sail Date for this voyage/port'
//			  where exists   
//			  (
//			  select * from t_booking_line b
//				where b.booking_line_id = c.booking_line_id 
//				  and b.sail_dt is null
//				  and b.deleted_flg = 'N'
//				  and b.booking_status <> 'P'
//				  and b.booking_dt > sysdate - 90 )";

//        string sqlNoSailDate = @"
//			update t_cargo_line c
//			 set import_notes_txt = 'No Sail Date for this voyage/port'
//                where c.booking_line_id in
//                (select booking_line_id 
//                   from t_booking_line b where b.sail_dt is null)";

		string sqlDeletedBookings = @"
        update t_cargo_line c
       set import_notes_txt = 'Booking has been deleted in LINE'
			where exists   
			  (select * from t_booking_line b
				where b.booking_line_id = c.booking_line_id 
				  and b.deleted_flg = 'Y')";

		string sqlDeletedCargo = @"
             update t_cargo_line c
			 set import_notes_txt = 'Cargo has been deleted in LINE'
               where cargo_status = 'DELETE'";

//        string sqlBookingTooOld = @"
//			update t_cargo_line c
//			 set import_notes_txt = 'Booking was created too long ago'
//			  where exists   
//			  (select * from t_booking_line b
//				where b.booking_line_id = c.booking_line_id 
//				  and b.booking_dt < sysdate-150) ";



        #endregion

        #region Gather ACMS data
		// OBSOLTE
        protected string sqlGetACMSBookingData = @"
            select bu.partner_cd, bu.partner_request_cd,
             bu.booking_id, bu.booking_id_sub, br.delivery_dsc, 
                bn.note_cd1 || ' ' || bn.note_cd2 || ' ' || bn.note_cd3 || ' ' || bn.note_cd4 ||
                bn.note_cd5 || ' ' || bn.note_cd6 || ' ' || bn.note_cd7 || ' ' || bn.note_cd8 || 
				bn.note_cd9 || ' ' || bn.note_cd10 || ' ' || bn.note_cd11 || ' ' || bn.note_cd12 || 
				bn.note_cd13 || ' ' || bn.note_cd14 || ' ' || bn.note_cd15 || ' ' || bn.note_cd16 ||
				bn.note_cd17 || ' ' || bn.note_cd18 || ' ' || bn.note_cd19 || ' ' || bn.note_cd20 as ACMSNotes,
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

        // OBSOLETE
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

		// Clears the 'No Sail Date' error message
		public string sqlClearSailDtMsg = @"
			update t_cargo_line
			 set import_notes_txt = ''
			  where import_notes_txt like 'No Sail%'
			 and exists
			 (select 1 from t_booking_line b
			  where b.booking_line_id = t_cargo_line.booking_line_id 
			   and b.sail_dt is not null) ";

		// For Warehouse; updates entire table every time (takes 10-15 seconds)
		public string sqlUpdateSailDt = @"
			update t_booking_line
			 set sail_dt = 
			 (select min(to_char(v.departure_dt, 'DD-MON-YYYY'))
			   from mv_voyage_route_detail v
				where substr(v.voyage_cd,0,5) = t_booking_line.voyage_no
				 and v.location_cd = t_booking_line.pol_location_cd
				 and v.pol_pod = 'L'
				/* and v.actual_departure_fl = 'Y'*/) ";

		public string sqlUpdateDelivery = @"
			update t_booking_line 
			 set delivery_txt = 
			 (select max(delivery_dsc)
			   from v_acms_booking_notes   
			   where t_booking_line.booking_no = v_acms_booking_notes.booking_id) ";

		public string sqlUpdateCargoNotes = @"
			update t_booking_line 
			 set cargo_notes_txt = 
			 (select max(acmsnotes)
			   from v_acms_booking_notes   
			   where t_booking_line.booking_no = v_acms_booking_notes.booking_id)  ";

		public string sqlUpdateRDD = @"p_update_line_rdd ";

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
							   min(upper(plor_dsc))
					   from t_cargo_line lc
						left outer join r_move_type mt on mt.move_type_cd = lc.move_type_cd
						inner join t_booking_line lb on lc.booking_line_id = lb.booking_line_id
				where plor_location_cd is not null and
						not exists
				 (select * from r_location l
				where l.location_cd =  upper(lb.plor_location_cd))
						group by plor_location_cd";

		protected string sqlInsertPLOD = @"
          insert into r_location
           (location_cd, location_type_cd, location_dsc)
                      select upper(plod_location_cd), 
                              min(case  
                                when mt.door_out_flg = 'Y' then 'LAND'
                                  else 'PORT'
                               end), 
                               min(upper(plod_dsc))
                       from t_cargo_line lc
                        inner join t_booking_line lb on lc.booking_line_id = lb.booking_line_id
                       left outer join r_move_type mt on mt.move_type_cd = lc.move_type_cd
            where plod_location_cd is not null and not exists
             (select * from r_location l
            where l.location_cd = upper(plod_location_cd) ) 
             group by plod_location_cd ";

		protected string sqlInsertPOL = @"
			  insert into r_location
			   (location_cd, location_type_cd, location_dsc)
			  select upper(pol_location_cd), 'PORT', min(pol_dsc)
			   from t_cargo_line lc
				inner join t_booking_line lb on lb.booking_line_id = lc.booking_line_id
				where not exists
				 (select * from r_location l
				where l.location_cd = upper(lb.pol_location_cd)) 
						group by pol_location_cd";

		protected string sqlInsertPOD = @"
			  insert into r_location
			   (location_cd, location_type_cd, location_dsc)
			  select upper(pod_location_cd), 'PORT', min(pod_dsc)
			   from t_cargo_line lc
				inner join t_booking_line lb on lb.booking_line_id = lc.booking_line_id
				where not exists
				 (select * from r_location l
				where l.location_cd = upper(pod_location_cd))
						group by pod_location_cd ";

		protected string sqlInsertPLOD2 = @"
				insert into r_location
				 (location_cd, location_dsc, location_type_cd, active_flg, conus_flg, gate_flg, border_flg, hold_area_flg, checkpoint_flg)
				select distinct plod_location_cd, plod_location_cd,
				 'LAND','Y','Y','N','N','N','N'
				 from t_booking_line
				 where plod_location_cd not in
				  (select location_cd from r_location) ";

		protected string sqlInsertPLOR2 = @"
				insert into r_location
				 (location_cd, location_dsc, location_type_cd, active_flg, conus_flg, gate_flg, border_flg, hold_area_flg, checkpoint_flg)
				select distinct plor_location_cd, plor_location_cd,
				 'LAND','Y','Y','N','N','N','N'
				 from t_booking_line
				 where plor_location_cd not in
				  (select location_cd from r_location) ";


		//
        // This will only insert bookings where there are no
        // import notes on ANY of the cargo
        //
        protected string sqlInsertBookings = @"
			  insert into t_booking
			  select booking_id_seq.NextVal,
				   null,null,null, null,
				   plor_location_cd,
				   pol_location_cd,
				   pod_location_cd,
				   plod_location_cd,
				   booking_no,
				   booking_ref,
				   bol_no,
				   edi_ref,
				   customer_ref,
				   customer_cd,
				   match_cd,
				   vessel_cd,
				   voyage_no,
				   delivery_txt,
				   cargo_notes_txt,
				   sail_dt,
				   null,
				   null
			   from
				  (
				  select distinct
					   plor_location_cd, pol_location_cd,
					   pod_location_cd, plod_location_cd,
					   booking_no, null as booking_ref, null as bol_no, 
					   edi_ref, substr(customer_ref,0,25) as customer_ref,
					   customer_cd, match_cd,
					   vessel_cd, voyage_no, delivery_txt, cargo_notes_txt, 
								   sail_dt
							  from   t_booking_line lb inner join
									 t_cargo_line lc on lc.booking_line_id = lb.booking_line_id
									where not exists
										   (select 1 from t_booking b
											 where b.booking_no = lb.booking_no)
											 and (lb.move_type_cd in ('F5','F6','F7','F8','F9'))
									and import_notes_txt is null
								 ) ";

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
				   cargo_key, 
				   cargo_rcvd_dt
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
				   bl.move_type_cd,
				   cargo_dsc,
				   container_no,
				   seal1, seal2, seal3,
				   make_cd, model_cd,
				   cargo_key, cargo_rcvd_dt
			   from t_cargo_line a
				inner join t_booking_line bl on a.booking_line_id = bl.booking_line_id
				inner join t_booking b on bl.booking_no = b.booking_no
				 where import_notes_txt is null
				   and not exists
				(select 1 from t_cargo c
				 where b.booking_id = c.booking_id
				   and a.serial_no = c.serial_no )
				   and not exists
				(select * from t_cargo cx
				 where a.cargo_key = cx.cargo_key)
						   ) ";

		protected string sqlInsertCargoActivity1 = @"
					insert into t_cargo_activity
					(cargo_activity_id, cargo_id, activity_type_cd,
					 billable_flg, orig_location_cd, dest_location_cd,
					 io_ind, payable_flg)
					select cargo_activity_id_seq.NextVal,
					 cargo_id, 'LHAUL', 'Y', plor_location_cd, pol_location_cd,
						'I', 'Y'
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
                       /* and l.location_type_cd = 'LAND' */
				  where c.move_type_cd in ('F6','F5','F9')
				  and not exists
					(select 1 from t_cargo_activity ca
						where ca.cargo_id = c.cargo_id
						  and ca.io_ind = 'I')
					 ) ";

		protected string sqlInsertCargoActivity2 = @"
					insert into t_cargo_activity
					(cargo_activity_id, cargo_id, activity_type_cd,
					 billable_flg, orig_location_cd, dest_location_cd,
						io_ind, payable_flg)
					select cargo_activity_id_seq.NextVal,
					 cargo_id, 'LHAUL', 'Y', pod_location_cd, plod_location_cd,
						'O', 'Y'
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
                       /*and l.location_type_cd = 'LAND' */
				   where c.move_type_cd in ('F7','F8','F9')
					and not exists
					(select 1 from t_cargo_activity ca
						where ca.cargo_id = c.cargo_id
						  and ca.io_ind = 'O')
					 ) ";

        protected string sqlInsertCustomer = @"
                insert into r_customer
                 (customer_cd, customer_nm, active_flg)
                 select customer_cd, max(customer_nm), 'Y'
                  from t_booking_line
                where t_booking_line.customer_cd not in
                 (select customer_cd from r_customer 
                  where r_customer.customer_cd = t_booking_line.customer_cd)
                 group by customer_cd  ";

        protected string sqlInsertVessels = @"
            insert into r_vessel
             (vessel_cd, vessel_nm, active_flg)
             select vessel_cd, vessel_cd, 'Y'
              from t_booking_line
                where not exists
                (select 1 from r_vessel
                 where r_vessel.vessel_cd = t_booking_line.vessel_cd)
               group by vessel_cd  ";

        #endregion

		#region Update ILMS statements

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
			get { return ClsConMgr.Manager["ArcSys"]; }
		}

		#endregion

		#region IMPORT LINE Warehouse Methods
		public ImportWarehouseResults RefreshAll(bool bFullRefresh, string sVoyageNo)
		{
			// Performs every step in the refresh process.
			// This refreshs the LINE Warehouse, then updates
			// ILMS tables with new/changed bookings and cargo
			//
			try
			{
				WriteAudit( "**************", "");
				WriteAudit("* Import to LINE warehouse", "");
				WriteAudit("  Full Refresh: ", bFullRefresh.ToString());
				results = ImportLineWarehouse(bFullRefresh, sVoyageNo);
				WriteAudit( "  Success: ", results.bSuccess.ToString());
				if (!results.bSuccess)
					WriteAudit( "  Error: ", results.ErrorMsg);

				WriteAudit( "  New Cargo: ", results.iNewCargo.ToString());
				WriteAudit( "  New Bookings: ", results.iNewBookings.ToString());
				WriteAudit("* Import new cargo from warehouse to ILMS", "");
				if (string.IsNullOrEmpty(sVoyageNo))
					results = ImportILMSTables("%");
				else
					results = ImportILMSTables(sVoyageNo);
				WriteAudit( "  Success: ", results.bSuccess.ToString());
				if (!results.bSuccess)
					WriteAudit( "  Error: ", results.ErrorMsg, true);

				WriteAudit( "  New Locations: ", results.iNewLocations.ToString());
				WriteAudit( "  New Customers", results.iNewCustomer.ToString());

				WriteAudit("* Update Changed Cargo ", "");
				results = UpdateChangedCargo();
				WriteAudit( "  Success: ", results.bSuccess.ToString());
				if (!results.bSuccess)
					WriteAudit( "  Error: ", results.ErrorMsg, true);
				WriteAudit( "  Updated ILMS Cargo", results.iUpdatedCargo.ToString());

				WriteAudit("* Update Moved Cargo...", "");
				results = UpdateMovedCargo();
				WriteAudit( "  Success: ", results.bSuccess.ToString());

				WriteAudit("* Find cargo that no longer exists in LINE...", "");
				results = FindDeletedCargo();
				WriteAudit(" Success: ", results.bSuccess.ToString());

				WriteAudit("  Remove Deleted Cargo...", "");
				results = RemoveDeletedCargo(bFullRefresh);
				WriteAudit( "  Success: ", results.bSuccess.ToString());
				if (!results.bSuccess)
					WriteAudit( "  Error: ", results.ErrorMsg, true);

				WriteAudit( "  Deleted Cago: ", results.iDeletedCargo.ToString());
				return results;
			}
			catch (Exception ex)
			{
				WriteAudit( ex.Message, "", true);
				return results;
			}
			finally
			{
				WriteAudit( "  Successful?", results.bSuccess.ToString());
				WriteAudit( "* Refresh All Done.", "");
				WriteAudit( "", "");

			}
		}

		private void WriteAudit(string sText, string sParm)
		{
			WriteAudit(sText, sParm, false);
		}
		private void WriteAudit(string sText, string sParm, bool bError)
		{
			string sMsg = string.Format("{0} {1}",
				sText,
				sParm);

			string sql = string.Format(@"
				insert into a_refresh_line
                  (audit_dt, audit_msg)
                 select systimestamp, '{0}' from dual ", sMsg);

			// Only write the audit if required
			if (bAudit)
				ConnectionARCImport.RunSQL(sql, CommandType.Text);
			if (bError)
				ClsJobError.LogError("LINE Import", sMsg);
		}

		public ImportWarehouseResults FindDeletedCargo()
		{
			//
			// Gets ALL cargo from LINE, then looks to see if anything
			// in the Warehouse no longer exists in LINE.  Updates
			// cargo status to "DELETED"
			//
			ImportWarehouseResults results = new ImportWarehouseResults();
			results.bSuccess = true;

			try
			{

				return results;
			}
			catch (Exception ex)
			{
				results.ErrorMsg = ex.Message;
				return results;
			}
		}

		private void InsertLineCargoAll(DataTable dt)
		{
			foreach (DataRow dr in dt.Rows)
			{
				ClsCargoLine cargo = new ClsCargoLine(dr);
				string sCargoKey = cargo.Cargo_Key;
				string sCargoStatus = cargo.Cargo_Status;
				string sql = string.Format(@"
					insert into s_line_cargo_all
                      select '{0}', '{1}' from dual ", sCargoKey, sCargoStatus);
				ConnectionARCImport.RunSQL(sql);
			}
		}

		public ImportWarehouseResults ImportLineWarehouse(bool bFullRefresh, string sVoyageNo)
		{
			//
			// Full Refresh goes back at least one year.  Partial only
			// goes back:
			//    7 days for Bookings and RoRo; because we have the
			//        last date changed for those.
			//    7 days for BreakBulk and Contains; because we do 
			//        not have the date changed for those.  We use
			//        the Create Date of the booking and look at cargo
			//        for all bookings changed within the last 7 days.
			//
			//		  JULY 2012 DGERDNER: Formerlly we went back 90 
			//         days for BB and Containers, but further inspection
			//         revealed that if you change anything of the cargo
			//         the "update date" on the booking itself is also
			//		   updated.
			//
			ImportWarehouseResults results = new ImportWarehouseResults(); 
			results.bSuccess = true;
			DateTime StartTime = DateTime.Now;
			//if (results.bSuccess)
			//    return results;

			int bookingDays = 14;
			int roroDays = 14;
			int bbDays = 14;
			int contDays = 14;

			if (bFullRefresh)
			{
				bookingDays = 90;
				roroDays = 90;
				bbDays = 90;
				contDays = 90;
			}
			int iCounter = 0;
			sqlGetBookings = sqlGetBookings.Replace("@DAYS", bookingDays.ToString());
			string sNewBookings = sqlGetBookingsLINE.Replace("@DAYS", bookingDays.ToString());
			//sNewBookings = sNewBookings + " " + sqlNewBookingAppend;
			sqlGetChangedBkLINE = sqlGetChangedBkLINE.Replace("@DAYS", bookingDays.ToString());
			sqlSelectBB = sqlSelectBB.Replace("@DAYS", bbDays.ToString());
			sqlSelectRR = sqlSelectRR.Replace("@DAYS", roroDays.ToString());
			sqlSelectCont = sqlSelectCont.Replace("@DAYS", contDays.ToString());

			if (!string.IsNullOrEmpty(sVoyageNo))
			{
				sqlGetBookings = sqlGetBookings + " and dba.bu1_kopf.bu1voyage like '@VOYAGE%' ";
				sqlGetBookings = sqlGetBookings.Replace("@VOYAGE", sVoyageNo);
				sqlSelectBB = sqlSelectBB + " and dba.bu1_kopf.bu1voyage like '@VOYAGE%' ";
				sqlSelectBB = sqlSelectBB.Replace("@VOYAGE", sVoyageNo);
				sqlSelectRR = sqlSelectRR + " and dba.bu1_kopf.bu1voyage like '@VOYAGE%' ";
				sqlSelectRR = sqlSelectRR.Replace("@VOYAGE", sVoyageNo);
				sqlSelectCont = sqlSelectCont + " and dba.bu1_kopf.bu1voyage like '@VOYAGE%' ";
				sqlSelectCont = sqlSelectCont.Replace("@VOYAGE", sVoyageNo);
				sqlSelectBOL = sqlSelectBOL + " and dba.bl1_kopf.bl1voyage like '@VOYAGE%' ";
				sqlSelectBOL = sqlSelectBOL.Replace("@VOYAGE", sVoyageNo);
			}

			StartTime = DateTime.Now;
			DateTime EndTime = StartTime;
			TimeSpan t = EndTime.Subtract(StartTime);
			try
			{

				// JUNE 14 2016 - dgerdner
				// Use new SQL Server LINK to get new bookings and add to t_booking_line
				sNewBookings = sNewBookings + " " + sqlNewBookingAppend;
				try
				{
					DataTable dtNewBookings = ConnectionARCImport.GetDataTable(sNewBookings);
					foreach (DataRow dr in dtNewBookings.Rows)
					{
						string sbooking = dr["booking_no"].ToString();
						if (sbooking == "ARCA16006300")
						{
							string a = "a";
						}
						ClsBookingLine bl = new ClsBookingLine(dr);
						bl.SetILMSEligibleFlg();
						bl.Insert();
						results.iNewBookings++;
					}
					// Update elapsed time
					EndTime = DateTime.Now;
					t = EndTime.Subtract(StartTime);
					results.TempTime = t.TotalSeconds;
				}
				catch (Exception ex)
				{
					ClsErrorHandler.LogException(ex);
					WriteAudit("Error adding new bookings : {0}", ex.Message, true);
				}

				//// JUNE 14 
				//// Use new SQL Server LINK to get changed bookings and update t_booking_line
				try
				{
					StartTime = DateTime.Now;
					DataTable dtChangedBookings = ConnectionARCImport.GetDataTable(sqlGetChangedBkLINE);
					foreach (DataRow dr in dtChangedBookings.Rows)
					{
						ClsBookingLine b = new ClsBookingLine(dr);
						ClsBookingLine bl = ClsBookingLine.GetUsingKey(b.Booking_Line_ID.GetValueOrDefault());
						results.iUpdatedBookings++;
						bl.IsEqual(b);
						b.Update();
					}
					// Update elapsed time
					EndTime = DateTime.Now;
					t = EndTime.Subtract(StartTime);
					results.TempTime = t.TotalSeconds;
				}
				catch (Exception ex)
				{
					ClsErrorHandler.LogException(ex);
					WriteAudit("Error updating changed bookings : {0}", ex.Message, true);
				}
				// This is the old method update add/update bookings
				#region Bookings OBSOLETE
				//StartTime = DateTime.Now;
				//DataTable dtBookings = ConnectionLine.GetDataTable(sqlGetBookings);
				//foreach (DataRow dr in dtBookings.Rows)
				//{
				//    iCounter++;

				//    string sBookingNo = dr["booking_no"].ToString();
				//    if (sBookingNo == "ARCA16005645")
				//        iCounter++;
	
				//    // Turn this datarow into a class object
				//    ClsBookingLine bl = new ClsBookingLine(dr);
				//    bl.SetILMSEligibleFlg();

				//    // Get the ID
				//    long blID = bl.Booking_Line_ID.GetValueOrDefault();
				//    if (blID == 43116)
				//        iCounter++;

				//    // See if it already exists;
				//    ClsBookingLine blCheck = ClsBookingLine.GetUsingKey(blID);

				//    //// If it does not exist, add it.
				//    //// otherwise update it.
				//    if (blCheck == null)
				//    {
				//        bl.Insert();
				//        results.iNewBookings++;
				//    }
				//    else
				//    {

				//        if (!bl.IsEqual(blCheck))
				//        {
				//            results.iUpdatedBookings++;
				//            bl.Update();
				//        }
				//    }
				//}
				#endregion

				//results.iBookingCount = dtBookings.Rows.Count;
				results.iCargoCount = 0;
				// Update elapsed time
				EndTime = DateTime.Now;
				t = EndTime.Subtract(StartTime);
				results.TempTime = t.TotalSeconds;

				//// Break Bulk
				try
				{
					StartTime = DateTime.Now;
					List<ClsCargoLine> lCargo = new List<ClsCargoLine>();
					DataTable dtCargoBB = ConnectionLine.GetDataTable(sqlSelectBB);
					foreach (DataRow dr in dtCargoBB.Rows)
					{
						InsertUpdateCargo(dr, ref results);
					}
					//Update elapsed time
					EndTime = DateTime.Now;
					t = EndTime.Subtract(StartTime);
					results.TempTime = t.TotalSeconds;
				}
				catch (Exception ex)
				{
					ClsErrorHandler.LogException(ex);
					WriteAudit("Error updating BreakBulk : {0}", ex.Message, true);
				}

				//// RoRo
				try
				{
					StartTime = DateTime.Now;
					List<ClsCargoLine> lCargoRoRo = new List<ClsCargoLine>();
					DataTable dtCargoRR = ConnectionLine.GetDataTable(sqlSelectRR);
					foreach (DataRow dr in dtCargoRR.Rows)
					{
						InsertUpdateCargo(dr, ref results);
					}
					EndTime = DateTime.Now;
					t = EndTime.Subtract(StartTime);
					results.TempTime = t.TotalSeconds;
				}
				catch (Exception ex)
				{
					ClsErrorHandler.LogException(ex);
					WriteAudit("Error updating RoRo : {0}", ex.Message, true);
				}

				//// Container
				try
				{
					StartTime = DateTime.Now;
					List<ClsCargoLine> lCargoCont = new List<ClsCargoLine>();
					DataTable dtCargoCont = ConnectionLine.GetDataTable(sqlSelectCont);
					foreach (DataRow dr in dtCargoCont.Rows)
					{
						InsertUpdateCargo(dr, ref results);
					}
					EndTime = DateTime.Now;
					t = EndTime.Subtract(StartTime);
					results.TempTime = t.TotalSeconds;
				}
				catch (Exception ex)
				{
					ClsErrorHandler.LogException(ex);
					WriteAudit("Error updating Containers : {0}", ex.Message, true);
				}

				//// BOL's
				try
				{
					StartTime = DateTime.Now;
					DataTable dtBOL = ConnectionLine.GetDataTable(sqlSelectBOL);
					foreach (DataRow dr in dtBOL.Rows)
					{
						string sBOL = dr["bol_id"].ToString();
						if (sBOL == "132232")
						{
							string a = "1";
						}
						InsertUpdateBOL(dr, ref results);
					}
					EndTime = DateTime.Now;
					t = EndTime.Subtract(StartTime);
					results.TempTime = t.TotalSeconds;
				}
				catch (Exception ex)
				{
					ClsErrorHandler.LogException(ex);
					WriteAudit("Error updating Bills of Lading : {0}", ex.Message, true);
				}

				// Update elapsed time
				EndTime = DateTime.Now;
				t = EndTime.Subtract(StartTime);
				results.TempTime = t.TotalSeconds;

				results.bSuccess = true;
				return results;
			}

			catch (Exception ex)
			{
				results.ErrorMsg = ex.Message;
				return results;
			}
			finally
			{
				EndTime = DateTime.Now;
				t = EndTime.Subtract(StartTime);
				results.TempTime = t.TotalSeconds;
			}
		}

		private void InsertUpdateCargo(DataRow dr, ref ImportWarehouseResults rs)
		{
			try
			{
				rs.iCargoCount++;
				// Turn current row into a biz object
				ClsCargoLine cargo = new ClsCargoLine(dr);

				if (cargo.Serial_No == "W800TM51600124XXX")
				{
					string x = "a";
				}

				ConvertUnits(cargo);

				// Get the Cargo Key
				string sCargoKey = cargo.Cargo_Key;
				ClsCargoLine cargoCheck = cargo.GetByCargoKey(sCargoKey);

				// If it does not exist, add it.
				// Otherwise update it.
				if (cargoCheck == null)
				{
					cargo.Insert();
					rs.iNewCargo++;
				}
				else
				{
					if (!cargo.IsEqual(cargoCheck))
					{
						rs.iUpdatedCargo++;
						cargo.Cargo_Line_ID = cargoCheck.Cargo_Line_ID;
						cargo.Update();
					}
				}
			}
			catch (Exception ex)
			{
				ClsErrorHandler.LogException(ex);
			}
		}

		private void ConvertUnits(ClsCargoLine c)
		{
			if (!c.Cargo_Key.StartsWith("CONT"))
			{
				c.Length_Nbr = CentimetersToInches(c.Length_Nbr);
				c.Height_Nbr = CentimetersToInches(c.Height_Nbr);
				c.Width_Nbr = CentimetersToInches(c.Width_Nbr);
				c.Weight_Nbr = KGToPounds(c.Weight_Nbr);
			}
			else
			{
				c.Length_Nbr = FeetToInches(c.Length_Nbr);
				c.Height_Nbr = FeetToInches(c.Height_Nbr);
				c.Width_Nbr = FeetToInches(c.Width_Nbr);
				//c.Weight_Nbr = KGToPounds(c.Weight_Nbr);
			}
			c.Weight_Nbr = WeightRounding(c.Weight_Nbr);
			c.Length_Nbr = Math.Round(c.Length_Nbr.Value, 4);
			c.Width_Nbr = Math.Round(c.Width_Nbr.Value, 4);
			c.Height_Nbr = Math.Round(c.Height_Nbr.Value, 4);

			c.Cube_Ft = c.CalcCubeFt;
			c.Dim_Weight_Nbr = c.CalcDimWeight;
			c.M_Tons = c.CalcMTon;
		}

		private void InsertUpdateBOL(DataRow dr, ref ImportWarehouseResults rs)
		{
			//rs.iCargoCount++
			try
			{
				// Turn current row into a biz object
				ClsBolLine bol = new ClsBolLine(dr);

				// See if it already exists
				ClsBolLine bolCheck = ClsBolLine.GetUsingKey((long)bol.Bol_ID);

				// If it does not exist, add it.
				// Otherwise update it.
				if (bolCheck == null)
				{
					if (!string.IsNullOrEmpty(bol.Bol_Status))
					{
						bol.Insert();
						rs.iNewBOL++;
					}
				}
				else
				{
					if (!bol.IsEqual(bolCheck))
					{
						rs.iUpdatedBOL++;
						bol.Update();
					}
				}
			}
			catch (Exception ex)
			{
				string s = ex.Message;
				ClsErrorHandler.LogException(ex);
			}
		}

		public void InsertHazardous()
		{
			ConnectionARCImport.RunSQL(sqlPurgeHazardous);
			DataTable dtIMDG = ConnectionLine.GetDataTable(sqlGetHazardous);
			foreach (DataRow drow in dtIMDG.Rows)
			{

			}

		}

		#endregion

		#region Deleted Cargo
		public ImportWarehouseResults RemoveDeletedCargo(bool bFull)
		{
			// These methods look for all cargo in the line warehouse
			// that no longer exists in LINE
			ImportWarehouseResults r = new ImportWarehouseResults();

			r.iDeletedCargo = r.iDeltedBookings = 0;
			DeletedBookings();

			if (bFull)
			{
				r.iDeletedCargo = r.iDeletedCargo + DeletedCont();
				r.iDeletedCargo = r.iDeletedCargo + DeletedRoRo();
				r.iDeletedCargo = r.iDeletedCargo + DeletedBreakBulk();
			}
			r.bSuccess = true;
			return r;
		}

		private void DeletedBookings()
		{
			//
			// Removes cargo from the line warehouse
			// if the booking has been deleted.  Note
			// it currently only removes it if there is
			// an estimate assigned, because it's okay 
			// to carry these otherwise.
			//
			string sql = @"
				delete
				 from t_cargo_line 
				  where booking_line_id in
				  (
				select bl.booking_line_id
				 from t_booking_line bl
				 inner join t_cargo_line cl on cl.booking_line_id = bl.booking_line_id
				 inner join t_cargo c on cl.cargo_key = c.cargo_key
				 inner join t_cargo_activity ca on ca.cargo_id = c.cargo_id
				 where deleted_flg = 'Y'
				 ) ";
			ConnectionARCImport.RunSQL(sql);
		}

		private int DeletedCont()
		{
			int iDeleted = 0;

			// Get a list of all LINE ID's and warehouse Line ID's for
			// Container cargo in the warehouse
			string sql = @"
				select booking_no, serial_no, cargo_line_id
                from v_booking_cargo_line
                where cargo_key like 'CONT%'
				and modify_dt > sysdate - 360
				and deleted_flg = 'N'
				and serial_no is not null
				  order by cargo_line_id      ";

			DataTable dt = ConnectionARCImport.GetDataTable(sql);

			// Make a call to LINE SqlServer database to see if we
			// can find this piece of cargo.
			foreach (DataRow dr in dt.Rows)
			{
				string sBookingNo = dr["Booking_No"].ToString();
				string sSerialNo = dr["serial_no"].ToString();
				string sILMSID = dr["cargo_line_id"].ToString();

				string sFind = sqlFindCont;
				sFind = sFind.Replace("@BKNO", sBookingNo);
				sFind = sFind.Replace("@SERNO", sSerialNo);
				DataRow drLine = ConnectionLine.GetDataRow(sFind);

				// If it is not found, delte it from the warehouse
				if (drLine == null)
				{
					string sDelete = sqlDeleteCargo.Replace("@CLID", sILMSID);
					ConnectionARCImport.RunSQL(sDelete);
					iDeleted++;
				}
			}

			return iDeleted;
		}

		private int DeletedRoRo()
		{
			//
			// Get a list of all Line ID's and warehouse Line ID's for
			// RoRo cargo in the warehouse
			//
			string sql = @"
				select  substr(cargo_key,5,length(cargo_key)-4) as line_id,
						cargo_line_id
				 from t_cargo_line cl
				 inner join t_booking_line bl
				  on cl.booking_line_id = bl.booking_line_id
				   where booking_dt > sysdate - 180
				and cargo_key like 'RO%' ";
			DataTable dt = ConnectionARCImport.GetDataTable(sql);

			int iTotal = 0;
			int iDeleted = 0;
			foreach (DataRow dr in dt.Rows)
			{
				// Make a call to the LINE SQLServer database
				// to see if we can find this ID in the roro table.
				iTotal++;
				string sLineID = dr["line_id"].ToString();
				string sILMSID = dr["cargo_line_id"].ToString();
				string sFind = sqlFindRoRo.Replace("@ID", sLineID);
				DataRow drLine = ConnectionLine.GetDataRow(sFind);
				if (drLine == null)
				{
					// If the row cannot be found in LINE
					// Delete it.
					string sDelete = sqlDeleteCargo.Replace("@CLID", sILMSID);
					ConnectionARCImport.RunSQL(sDelete);
					iDeleted++;
				}
			}
			return iDeleted;
		}

		private int DeletedBreakBulk()
		{
			string sql = @"
				select  substr(cargo_key,10,length(cargo_key)-9) as line_id,
					cargo_line_id,
					cargo_key
				 from t_cargo_line cl
				 inner join t_booking_line bl
				  on cl.booking_line_id = bl.booking_line_id
				   where booking_dt > sysdate - 180
				and cargo_key like 'BRE%' ";
			DataTable dt = ConnectionARCImport.GetDataTable(sql);

			int iTotal = 0;
			int iDeleted = 0;
			foreach (DataRow dr in dt.Rows)
			{
				iTotal++;
				string sLineID = dr["line_id"].ToString();
				string sILMSID = dr["cargo_line_id"].ToString();
				string sFind = sqlFindBB.Replace("@ID", sLineID);

				DataRow drLine = ConnectionLine.GetDataRow(sFind);
				if (drLine == null)
				{
					string sDelete = sqlDeleteCargo.Replace("@CLID", sILMSID);
					ConnectionARCImport.RunSQL(sDelete);
					iDeleted++;
				}
			}
			return iDeleted;
		}

		#region Changes Methods
		public bool FindChanges()
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

		public DataTable GetChangedCargo()
		{
			StringBuilder sql = new StringBuilder();
			sql.AppendFormat(@"
                select v_all_changes_warehouse.*, estimate_no from v_all_changes_warehouse 
                  inner join t_estimate on v_all_changes_warehouse.estimate_id = t_estimate.estimate_id
               order by booking_no, serial_no ");

			DataTable dt = ConnectionARCImport.GetDataTable(sql.ToString());
			return dt;
		}

		public ImportWarehouseResults UpdateChangedCargo()
		{
			bool InTrans = ConnectionARCImport.IsInTransaction;
			ImportWarehouseResults results = new ImportWarehouseResults();
			results.bSuccess = true;
			int iCounter = 0;
			try
			{
				if (!InTrans)
				{
					ConnectionARCImport.TransactionBegin();
				}
				DataTable dt = GetChangedCargo();

				results.iUpdatedCargo = dt.Rows.Count;
				foreach (DataRow dr in dt.Rows)
				{
					iCounter++;
					string sEstimateID = dr["estimate_id"].ToString();
					string sSerialNo = dr["serial_no"].ToString();
					sSerialNo = CleanSerialNo(sSerialNo);
					string sColumn = dr["descr"].ToString();
					string sOld = dr["old"].ToString();
					sOld = CleanSerialNo(sOld);
					string sNew = dr["new"].ToString();
					sNew = CleanSerialNo(sNew);
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
							results.sLastSQL = sqlCargoNbr.ToString();
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
							results.sLastSQL = sqlCargoTxt.ToString();
							ConnectionARCImport.RunSQL(sqlCargoTxt.ToString());
							break;
					}

					StringBuilder sqlAudit = new StringBuilder();
					sqlAudit.AppendFormat(@"
                    insert into t_cargo_change 
                    select arc_owner.cargo_change_id_seq.nextval,
                        {0}, null, null, null, null, '{1}', '{2}', '{3}', '{4}', '{5}' from dual",
						 sEstimateID, sActivityID, sSerialNo, sColumn, sOld, sNew);
					results.sLastSQL = sqlAudit.ToString();
					ConnectionARCImport.RunSQL(sqlAudit.ToString());
				}
				if (!InTrans)
				{
					ConnectionARCImport.TransactionCommit();
				}
				return results;
			}
			catch (Exception ex)
			{
				ClsErrorHandler.LogException(ex);
				results.bSuccess = false;
				results.ErrorMsg = ex.Message;
				if (!InTrans)
				{
					ConnectionARCImport.TransactionRollback();
				}
				return results;
			}
		}

		public ImportWarehouseResults UpdateMovedCargo()
		{
			// For cargo whose cargo key changed but it is still
			// on the same booking or same voyage.
			ImportWarehouseResults results = new ImportWarehouseResults();
			results.bSuccess = false;
			try
			{
				string s = "select * from v_cargokey_changed";
				DataTable dt = ConnectionARCImport.GetDataTable(s);

				string sqlUpdateCargoKey = @"
				update t_cargo
				 set cargo_key = 
				 (select max(x.new_cargo_key)
				from v_cargokey_changed x
				 where x.cargo_id = t_cargo.cargo_id)
				where exists
				 (select 1 from v_cargokey_changed z
				   where z.cargo_id = t_cargo.cargo_id)";

				string sql = sqlUpdateCargoKey;
				ConnectionARCImport.RunSQL(sql);
				results.bSuccess = true;
				return results;
			}
			catch (Exception ex)
			{
				ClsErrorHandler.LogException(ex);
				results.ErrorMsg = ex.Message;
				return results;
			}
		}

		#endregion

		#endregion

		#region IMPORT ILMS Methods
		public struct ImportWarehouseResults
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
			public int iDeltedBookings;
			public int iDeletedCargo;
			public string ErrorMsg;
			public bool bSuccess;
            public string ErrorLocation;
            public string sLastSQL;
            public double TempTime;
            public double LiveTime;
			public string sProblems;
			public int iNewBOL;
			public int iUpdatedBOL;
			public List<string> sLog;
		}

		public ImportWarehouseResults ImportILMSTables(string VoyageNo)
		{
			try
			{
				// Adds new bookings, locations, cargo, etc to ILMS
				// tables.  This does not perform updates to bookings
				// and cargo that have changed; it only add new.
                if (string.IsNullOrEmpty(VoyageNo))  {VoyageNo = "%";}
				results.sLog = new List<string>();

                DateTime StartTime = DateTime.Now;
				// Purge tables
				//   First purges all cargo activity that is not assigned
				//   to an estimate.
				//
				//   Then purges all cargo that has no activity.
				//
				//   Then purges all bookings that have no cargo.
				//
				WriteAudit("* Start purge Cargo Activity", "");
				string sqlPurgeCargoActvity = sqlPurgeCargoActivity.Replace("{0}", VoyageNo);
				//ConnectionARCImport.RunSQL(sqlPurgeCargoActvity);
				ClsCargoActivity.DeleteUnassignedActivity(sqlPurgeCargoActivity);

				WriteAudit("* Start purge Cargo", "");
                ConnectionARCImport.RunSQL(sqlPurgeCargo);
				WriteAudit("* Start purge Booking", "");
                ConnectionARCImport.RunSQL(sqlPurgeBooking);
				WriteAudit("* End purge Booking", "");

                // Add any new locations
				WriteAudit("* New Locations", "");
                InsertNewLocationsFromLine();
				InsertNewLocations();

				//// Add any new vessels
				WriteAudit("* New Vessels", "");
				InsertNewVessels();

				//// Add any new customers
				WriteAudit("* New Customers", "");
				InsertNewCustomers();

				////// Gather ACMS data
				//UpdateWithACMSData();

				// Tag cargo that should not be imported
				ConnectionARCImport.RunSQL(sqlRemoveNotes);
				ConnectionARCImport.RunSQL(sqlDuplicates);
				//ConnectionARCImport.RunSQL(sqlNonLandPLOD);
				//ConnectionARCImport.RunSQL(sqlNonLandPLOR);
				ConnectionARCImport.RunSQL(sqlMissingPLOD);
				ConnectionARCImport.RunSQL(sqlMissingPLOR);
				// Move "no sail date" to after gathering acms data
				//ConnectionARCImport.RunSQL(sqlNoSailDate);
				ConnectionARCImport.RunSQL(sqlPending);
				//ConnectionARCImport.RunSQL(sqlBookingTooOld);
				results.sLastSQL = sqlDeletedBookings;
				ConnectionARCImport.RunSQL(sqlDeletedBookings);
				ConnectionARCImport.RunSQL(sqlDeletedCargo);

				//// Add new bookings
				WriteAudit("* New Bookings", "");
				InsertNewBookings();

				//// Add new Cargo
				WriteAudit("* New Cargo", "");
				InsertNewCargo();

				//// Add new Cargo Activity
				WriteAudit("* New Cargo Activity", "");
				InsertNewCargoActivity();

				//// May 2012 dgerdner; move this to AFTER inserting new rows
				//// Gather ACMS data
				WriteAudit("* Update with ACMS Data", "");
				UpdateWithACMSData();
				WriteAudit("* ACMS Update complete", "");
				//ConnectionARCImport.RunSQL(sqlNoSailDate);

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
				WriteAudit("Error in the ILMS section {0}", ex.Message, true);
				return results;
			}
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
				i = i + ConnectionARCImport.RunSQL(sqlInsertPLOD2);
				i = i + ConnectionARCImport.RunSQL(sqlInsertPLOR2);
                results.iNewLocations = i;
                ConnectionARCImport.TransactionCommit();
			}
			catch( Exception ex )
			{
                ConnectionARCImport.TransactionRollback();
				throw ex;
			}
		}

		public void InsertNewLocationsFromLine()
		{
			bool bInTrans = ConnectionACMS.IsInTransaction;
			if (!bInTrans)
				ConnectionACMS.TransactionBegin();
			try
			{
				int i = 0;
				DataTable dtLoc = ClsLineSQL.GetLocations();
				foreach(DataRow dr in dtLoc.Rows)
				{
					string sLocationCd = dr["lccode"].ToString();
					string sLocationNm = dr["lcname"].ToString();
					string sCountryCd = dr["lcland"].ToString();
					string sDefaultBerth = dr["lcdefslcode"].ToString();
					string sCensusType = "K";
					if (sCountryCd == "US")
						sCensusType = "F";

					/* See if this location already exists in ACMS */
					string sql = string.Format(@"
						select * from r_location where location_cd = '{0}' ",
						sLocationCd);
					DataTable dtCheck = ConnectionACMS.GetDataTable(sql);
					if (dtCheck.Rows.Count > 0)
						continue;

					if (sLocationNm.IndexOf("NOT USE") > 0)
						continue;

					/* If it does not already exist, add it */
					sql = string.Format(@"
						insert into r_location
						 (location_cd, location_dsc, delete_fl, country_cd, census_type, city, other2_cd)
						 select '{0}', '{1}', 'N', '{2}', '{3}', '{4}', '{0}'
						  from dual ", sLocationCd, sLocationNm, sCountryCd, sCensusType, sLocationNm);
					//ConnectionACMS.RunSQL(sql);
					i++;
				}
				results.iNewLocations = i;
				if (!bInTrans)
					ConnectionACMS.TransactionCommit();
			}
			catch( Exception ex )
			{
				if (!bInTrans)
					ConnectionACMS.TransactionRollback();
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
	
        public void UpdateWithACMSData()
        {
			try
			{
				//
				// Populate t_booking_line with data from ACMS
				// This can then be shared with ILMS t_booking

				// Sail Dt
				// NOV2013 DG Don't need this any longer because sail date is updated
				// in p_update_rdd
				WriteAudit("*   Sail Date", "");
				ConnectionARCImport.RunSQL(sqlClearSailDtMsg);
				//ConnectionARCImport.RunSQL(sqlUpdateSailDt);

				// Delivery Notes
				WriteAudit("*   Delivery Notes", "");
				ConnectionARCImport.RunSQL(sqlUpdateDelivery);

				// Cargo Notes
				WriteAudit("*   Cargo Notes", "");
				ConnectionARCImport.RunSQL(sqlUpdateCargoNotes);

				// RDD Date
				WriteAudit("*   RDD", "");
				ConnectionARCImport.RunSQL(sqlUpdateRDD, CommandType.StoredProcedure);
			}
			catch (Exception ex)
			{
				throw ex;
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
				int r2 = ConnectionARCImport.RunSQL(sqlInsertCargoActivity2);
				results.iNewCargoActivity = results.iNewCargoActivity + r2;
                     
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

		#region Refresh Cargo Status Section

		public void RefreshCargoStatus()
		{
			try
			{
				string sql = @"
				select *
				 from v_booking_cargo_line
				  where cargo_status != 'DELV'
				   and deleted_flg = 'N'
				   and booking_status = 'C'
				   and (match_cd like 'SDDC%' or match_cd like 'CAT%')
					and booking_dt > sysdate - 180";
				DataTable dtBooked = ConnectionARCImport.GetDataTable(sql);
				foreach (DataRow drow in dtBooked.Rows)
				{
					string sCargoType = drow["cargo_type_cd"].ToString();
					string sKey = drow["cargo_key"].ToString();
					string sID = drow["cargo_line_id"].ToString();
					int iCargoID = ClsConvert.ToInt32(sID);
					if (sCargoType.ToLower() == "roro")
						RefreshRoroCargo(sKey, iCargoID);
					if (sCargoType.ToLower() == "bkbk")
						RefreshBkBkCargo(sKey, iCargoID);

				}
			}
			catch (Exception ex)
			{
				ClsErrorHandler.LogException(ex);
			}
		}
		private void RefreshRoroCargo(string sCargoKey, int iCargoID)
		{
			sCargoKey = sCargoKey.Replace("RORO", "");
			string sql = string.Format(@"select * from dba.car_head where cr1_manr = {0} ", sCargoKey);
			DataTable dtCargo = ConnectionLine.GetDataTable(sql);
			if (dtCargo.Rows.Count < 1)
				return;
			DataRow drow = dtCargo.Rows[0];

			string sStatus = drow["cr1_ecstatus"].ToString();
			string sRcvdDate = drow["cr1_cargorecvdate"].ToString();
			string sActivityDate = drow["cr1_ecstatusdatetime"].ToString();
			// If cargo is still in "Book" status, there's nothing to update.
			if (sStatus.ToUpper() == "BOOK")
				return;
			DateTime dtRcvdDate = ClsConvert.ToDateTime(sRcvdDate);
			DateTime dtActivityDate = ClsConvert.ToDateTime(sActivityDate);
			UpdateCargoLine(dtRcvdDate, dtActivityDate, sStatus, iCargoID);
		}

		private void RefreshBkBkCargo(string sCargoKey, int iCargoID)
		{
			sCargoKey = sCargoKey.Replace("BREAKBULK", "");
			string sql = string.Format(@"select * from dba.bu14_itemdetail where bu14_itemdetail_id = {0} ", sCargoKey);
			DataTable dtCargo = ConnectionLine.GetDataTable(sql);
			if (dtCargo.Rows.Count < 1)
				return;
			DataRow drow = dtCargo.Rows[0];

			string sStatus = drow["bu14status"].ToString();
			string sRcvdDate = drow["bu14cargorecvdate"].ToString();
			string sActivityDate = drow["bu14statusdatetime"].ToString();
			if (sStatus.ToUpper() == "BOOK")
				return;
			DateTime dtRcvdDate = ClsConvert.ToDateTime(sRcvdDate);
			DateTime dtActivityDate = ClsConvert.ToDateTime(sActivityDate);
			UpdateCargoLine(dtRcvdDate, dtActivityDate, sStatus, iCargoID);
		}

		private void UpdateCargoLine(DateTime dtRcvdDate, DateTime dtActivityDate, string sStatus, int iCargoID)
		{

			DbParameter[] p = new DbParameter[4];
			p[0] = ConnectionARCImport.GetParameter
				("@STATUS", sStatus);
			p[1] = ConnectionARCImport.GetParameter
				("@RVDATE", dtRcvdDate);
			p[2] = ConnectionARCImport.GetParameter
				("@ACTDT", dtActivityDate);
			p[3] = ConnectionARCImport.GetParameter
				("@ID", iCargoID);


			string sql = string.Format(@"update t_cargo_line 
									set cargo_status = @STATUS,
										cargo_rcvd_dt = @RVDATE,
										cargo_status_dt = @ACTDT
								   where cargo_line_id = @ID");
			ConnectionARCImport.RunSQL(sql, p);
		}
		#endregion
	}
}
