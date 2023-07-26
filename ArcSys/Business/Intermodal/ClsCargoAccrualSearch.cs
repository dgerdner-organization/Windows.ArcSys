using System;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;
using System.Text;

namespace CS2010.ArcSys.Business
{
	public class ClsCargoAccrualSearch
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ArcSys"]; }
		}
		#endregion		// #region Connection Manager

		#region Fields

		public long? Estimate_ID;
		public string csvEstimateID;

		public string Estimate_No;
		public string Booking_No;
		public string PCFN;
		public string Serial_No;

		public string PLOR_CDs;
		public string POL_CDs;
		public string POD_CDs;
		public string PLOD_CDs;

		public string Act_Orig_CDs;
		public string Act_Dest_CDs;

		public string StatusCDs;
		public string MoveTypeCDs;
		public bool IncludeNonDoor;

		public string csvBooking;
		public string csvPCFN;

		public string Vessel;
		public string VoyageNo;

		public DateRange ETD;
		public DateRange RDD;
		public DateRange Created;
		public DateRange Modified;
		public DateRange Vessel_Sail_Dt;

		#endregion		// #region Fields

		#region Constructors/Initialization

		public ClsCargoAccrualSearch()
		{
			Clear();
		}

		public ClsCargoAccrualSearch(ClsCargoAccrualSearch aSearch)
		{
			Clear();
			CopyFrom(aSearch);
		}

		public void CopyFrom(ClsCargoAccrualSearch aSearch)
		{
			Estimate_ID = aSearch.Estimate_ID;
			csvEstimateID = aSearch.csvEstimateID;

			Estimate_No = aSearch.Estimate_No;
			Booking_No = aSearch.Booking_No;
			PCFN = aSearch.PCFN;
			csvPCFN = aSearch.csvPCFN;
			csvBooking = aSearch.csvBooking;
			Vessel = aSearch.Vessel;
			VoyageNo = aSearch.VoyageNo;
			StatusCDs = aSearch.StatusCDs;
			MoveTypeCDs = aSearch.MoveTypeCDs;
			IncludeNonDoor = aSearch.IncludeNonDoor;
			PLOR_CDs = aSearch.PLOR_CDs;
			POL_CDs = aSearch.POL_CDs;
			POD_CDs = aSearch.POD_CDs;
			PLOD_CDs = aSearch.PLOD_CDs;
			Act_Orig_CDs = aSearch.Act_Orig_CDs;
			Act_Dest_CDs = aSearch.Act_Dest_CDs;
			Serial_No = aSearch.Serial_No;

			ETD = aSearch.ETD;
			RDD = aSearch.RDD;
			Created = aSearch.Created;
			Modified = aSearch.Modified;
			Vessel_Sail_Dt = aSearch.Vessel_Sail_Dt;
		}

		public void Clear()
		{
			Booking_No = PCFN = csvPCFN = csvBooking = Vessel = VoyageNo = StatusCDs =
				MoveTypeCDs = POL_CDs = POD_CDs = PLOR_CDs = PLOD_CDs = Act_Orig_CDs =
				Act_Dest_CDs = Serial_No = Estimate_No = csvEstimateID = null;

			IncludeNonDoor = false;
			Estimate_ID = null;

			ETD.Clear();
			RDD.Clear();
			Created.Clear();
			Modified.Clear();
			Vessel_Sail_Dt.Clear();
		}
		#endregion		// #region Constructors/Initialization

		#region ToString Overrides

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();

			if (!string.IsNullOrEmpty(Estimate_No)) sb.AppendFormat(" Estimate # {0} ", Estimate_No);
			if (!string.IsNullOrEmpty(Booking_No)) sb.AppendFormat(" Booking # {0} ", Booking_No);
			if( !string.IsNullOrEmpty(PCFN) ) sb.AppendFormat(" PCFN {0} ", PCFN);
			if (!string.IsNullOrEmpty(Serial_No)) sb.AppendFormat(" Serial # {0} ", Serial_No);
			if (!string.IsNullOrEmpty(PLOR_CDs)) sb.AppendFormat(" PLOR {0} ", PLOR_CDs);
			if (!string.IsNullOrEmpty(POL_CDs)) sb.AppendFormat(" POL {0} ", POL_CDs);
			if( !string.IsNullOrEmpty(POD_CDs) ) sb.AppendFormat(" POD {0} ", POD_CDs);
			if (!string.IsNullOrEmpty(PLOD_CDs)) sb.AppendFormat(" PLOD {0} ", PLOD_CDs);
			if (!string.IsNullOrEmpty(Act_Orig_CDs)) sb.AppendFormat(" Est Orig {0} ", Act_Orig_CDs);
			if (!string.IsNullOrEmpty(Act_Dest_CDs)) sb.AppendFormat(" Est Dest {0} ", Act_Dest_CDs);
			if (!string.IsNullOrEmpty(Vessel)) sb.AppendFormat(" Vessel {0} ", Vessel);
			if( !string.IsNullOrEmpty(VoyageNo) ) sb.AppendFormat(" VoyageNo {0} ", VoyageNo);
			if( !string.IsNullOrEmpty(StatusCDs) ) sb.AppendFormat(" ACMS Status {0} ", StatusCDs);
			if( !string.IsNullOrEmpty(MoveTypeCDs) ) sb.AppendFormat(" Move Type {0} ", MoveTypeCDs);
			if (IncludeNonDoor) sb.Append(" Including F1-F4 ");

			if (Estimate_ID.GetValueOrDefault(0) > 0) sb.AppendFormat(" Est ID {0} ", Estimate_ID);
			if (!string.IsNullOrEmpty(csvEstimateID)) sb.AppendFormat(" Est IDs {0} ", csvEstimateID);

			if (!ETD.IsEmpty) sb.AppendFormat(" ETD {0} ", ETD);
			if( !RDD.IsEmpty ) sb.AppendFormat(" RDD {0} ", RDD);
			if( !Created.IsEmpty ) sb.AppendFormat(" Created {0} ", Created);
			if( !Modified.IsEmpty ) sb.AppendFormat(" Modified {0} ", Modified);
			if (!Vessel_Sail_Dt.IsEmpty) sb.AppendFormat(" Sail Date {0} ", Vessel_Sail_Dt);

			return sb.ToString();
		}
		#endregion		// #region ToString Overrides

		#region Estimate AP Accrual for Accounting

		#region Queries for Computing AP Accruals

        /* 
          
         * In Select 
          
            nvl(BK_FIN.booking_no,bk.booking_no) as FINANCIAL_BOOKING,
            nvl(BK_FIN.voyage_no,bk.voyage_no) as FINANCIAL_VOYAGE
          
         * In From 
          
          left outer join v_transshipments BK_TRAN on bk.booking_no = BK_TRAN.linked_booking_no
          left outer join t_booking BK_FIN on BK_FIN.booking_no = nvl(BK_TRAN.booking_no,bk.booking_no)
          
         * Group By
          
            nvl(BK_FIN.booking_no,bk.booking_no),
            nvl(BK_FIN.voyage_no,bk.voyage_no)
          
         */


        public const string SqlComputeApAccrualSelect = @"
		SELECT	edt.vessel_cd, edt.voyage_no AS edt_voyage_no, bk.voyage_no AS bk_voyage_no,
				est.voyage_no AS est_voyage_no, bk.vessel_cd as bk_vessel_cd,
				DECODE(est.voyage_no, bk.voyage_no, 'N', 'Y') AS voy_est_bk_err_flg,
				DECODE(edt.voyage_no, bk.voyage_no, 'N', 'Y') AS voy_edt_bk_err_flg,
				DECODE(edt.vessel_cd, bk.vessel_cd, 'N', 'Y') AS ves_edt_bk_err_flg,
				est.estimate_id, est.estimate_no, est.orig_location_cd, eoloc.location_dsc AS orig_location_dsc,
				est.dest_location_cd, edloc.location_dsc AS dest_location_dsc, echg.vendor_cd, ven.vendor_nm,
				CASE
					WHEN est.dest_location_cd = bk.pol_location_cd	THEN edloc.location_dsc
					WHEN est.orig_location_cd = bk.pod_location_cd	THEN eoloc.location_dsc
					ELSE 'UNKNOWN'
				END AS port_location_dsc,
				CASE
					WHEN est.dest_location_cd = bk.pol_location_cd	THEN 'FROM'
					WHEN est.orig_location_cd = bk.pod_location_cd	THEN 'TO'
					ELSE 'UNKNOWN'
				END AS direction_info,
				CASE
					WHEN est.dest_location_cd = bk.pol_location_cd	THEN eoloc.location_dsc
					WHEN est.orig_location_cd = bk.pod_location_cd	THEN edloc.location_dsc
					ELSE 'UNKNOWN'
				END AS from_or_to_location_dsc,
                
                nvl(BK_FIN.booking_no,bk.booking_no) as FINANCIAL_BOOKING,
                nvl(BK_FIN.voyage_no,bk.voyage_no) as FINANCIAL_VOYAGE ";

		public const string SqlComputeApAccrualFrom = @"
		FROM	t_estimate_charge_dtl edt
			INNER JOIN t_cargo_activity ca			ON ca.cargo_activity_id = edt.cargo_activity_id
			INNER JOIN t_cargo c					ON c.cargo_id = ca.cargo_id
			INNER JOIN t_booking bk					ON bk.booking_id = c.booking_id
			INNER JOIN t_estimate_charge echg		ON (echg.estimate_charge_id = edt.estimate_charge_id AND
														echg.finance_cd = 'AP')
			INNER JOIN r_charge_type cht			ON cht.charge_type_cd = echg.charge_type_cd
			INNER JOIN r_level_unit lvu				ON lvu.level_unit_id = echg.level_unit_id
			INNER JOIN t_estimate est				ON est.estimate_id = echg.estimate_id
			INNER JOIN r_location eoloc				ON eoloc.location_cd = est.orig_location_cd
			INNER JOIN r_location edloc				ON edloc.location_cd = est.dest_location_cd
			LEFT OUTER JOIN r_vendor ven			ON ven.vendor_cd = echg.vendor_cd 

            left outer join (select distinct booking_no, linked_booking_NO, first_booking_no from v_transshipments) BK_TRAN on bk.booking_no = BK_TRAN.linked_booking_no
            left outer join t_booking BK_FIN on BK_FIN.booking_no = nvl(BK_TRAN.first_booking_no,bk.booking_no)"; 

		public const string SqlComputeApAccrualGroupBy = @"
		GROUP BY
				edt.vessel_cd, edt.voyage_no, est.voyage_no, bk.vessel_cd, bk.voyage_no,
				est.estimate_id, est.estimate_no, est.orig_location_cd, eoloc.location_dsc,
				est.dest_location_cd, edloc.location_dsc, echg.vendor_cd, ven.vendor_nm,
				CASE
					WHEN est.dest_location_cd = bk.pol_location_cd	THEN edloc.location_dsc
					WHEN est.orig_location_cd = bk.pod_location_cd	THEN eoloc.location_dsc
					ELSE 'UNKNOWN'
				END,
				CASE
					WHEN est.dest_location_cd = bk.pol_location_cd	THEN 'FROM'
					WHEN est.orig_location_cd = bk.pod_location_cd	THEN 'TO'
					ELSE 'UNKNOWN'
				END,
				CASE
					WHEN est.dest_location_cd = bk.pol_location_cd	THEN eoloc.location_dsc
					WHEN est.orig_location_cd = bk.pod_location_cd	THEN edloc.location_dsc
					ELSE 'UNKNOWN'
				END,
                nvl(BK_FIN.booking_no,bk.booking_no),
                nvl(BK_FIN.voyage_no,bk.voyage_no) ";

		public const string SqlComputeApAccrualSummaryColumns = @",
				SUM(CASE WHEN	nvl(est.orig_location_cd, '~DUMMY~') =
								nvl(ca.orig_location_cd, '~DUMMY~')
							THEN 0 ELSE 1 END) as mismatch_orig_count,
				SUM(CASE WHEN	nvl(est.dest_location_cd, '~DUMMY~') =
								nvl(ca.dest_location_cd, '~DUMMY~')
					THEN 0 ELSE 1 END) as mismatch_dest_count,
				SUM(CASE WHEN	nvl(bk.booking_no, '~DUMMY~') = nvl(edt.booking_no, '~DUMMY~')
					THEN 0 ELSE 1 END) as mismatch_bk_count,
				SUM(CASE WHEN	nvl(bk.customer_ref, '~DUMMY~') = nvl(edt.customer_ref, '~DUMMY~')
					THEN 0 ELSE 1 END) as mismatch_pcfn_count,
				SUM(CASE WHEN	TO_CHAR(nvl(bk.sail_dt, DATE'1950-01-01'), 'MM-YYYY') =
								TO_CHAR(nvl(edt.sail_dt, DATE'1950-01-01'), 'MM-YYYY')
					THEN 0 ELSE 1 END) as mismatch_sail_count,
				SUM(CASE WHEN	nvl(trunc(c.length_nbr, 2), -1950) = nvl(edt.length_nbr, -1950)
					THEN 0 ELSE 1 END) as mismatch_len_count,
				SUM(CASE WHEN	nvl(trunc(c.width_nbr, 2), -1950) = nvl(edt.width_nbr, -1950)
					THEN 0 ELSE 1 END) as mismatch_wid_count,
				SUM(CASE WHEN	nvl(trunc(c.height_nbr, 2), -1950) = nvl(edt.height_nbr, -1950)
					THEN 0 ELSE 1 END) as mismatch_hgt_count,
				SUM(CASE WHEN	nvl(c.weight_nbr, -1950) = nvl(edt.weight_nbr, -1950)
					THEN 0 ELSE 1 END) as mismatch_wgt_count,
				SUM(CASE WHEN	nvl(c.dim_weight_nbr, -1950) = nvl(edt.dim_weight_nbr, -1950)
					THEN 0 ELSE 1 END) as mismatch_dwt_count,
				SUM(CASE WHEN	nvl(c.cube_ft, -1950) = nvl(edt.cube_ft, -1950)
					THEN 0 ELSE 1 END) as mismatch_cft_count,
				SUM(CASE WHEN	nvl(c.m_tons, -1950) = nvl(edt.m_tons, -1950)
					THEN 0 ELSE 1 END) as mismatch_mt_count,
				SUM(edt.activity_amt) AS ap_accrual_amt,
				COUNT(DISTINCT c.cargo_id) AS piece_cnt,
				SUM(DECODE(echg.charge_type_cd, 'EITV', edt.activity_amt, 0)) AS eitv_amt,
				COUNT(DECODE(echg.charge_type_cd, 'EITV', edt.cargo_activity_id, NULL)) AS eitv_cnt ";
		// removed since it is no longer possible to reliably recreate the estimate total after
		// accrual is submitted since we now set the FKs to cargo act, and estimate charge to null
		// on delete. It's usefulness was questionable anyway.
		/*(	SELECT	SUM(ec1.total_amt)
					FROM	t_estimate e1
						INNER JOIN t_estimate_charge ec1 ON ec1.estimate_id = e1.estimate_id
					WHERE e1.estimate_id = est.estimate_id AND ec1.finance_cd = 'AP'
				) AS tot_ap_est_amt, 
		*/

		public const string SqlComputeApAccrualSelectSummary =
			SqlComputeApAccrualSelect + SqlComputeApAccrualSummaryColumns;

		public const string SqlComputeApAccrualSelectByCharge = SqlComputeApAccrualSelect + @",
				echg.charge_type_cd, cht.charge_type_dsc, lvu.level_unit_dsc " +
				SqlComputeApAccrualSummaryColumns;

		public const string SqlComputeApAccrualGroupByCharge = SqlComputeApAccrualGroupBy + @",
			echg.charge_type_cd, cht.charge_type_dsc, lvu.level_unit_dsc ";

		public const string SqlComputeApAccrualSelectByCargo = SqlComputeApAccrualSelect + @",
				c.cargo_key, edt.serial_no, edt.booking_no " +
				SqlComputeApAccrualSummaryColumns + @",
				COUNT(DISTINCT ca.cargo_activity_id) AS activity_cnt ";

		public const string SqlComputeApAccrualGroupByCargo = SqlComputeApAccrualGroupBy + @",
			c.cargo_key, edt.serial_no, edt.booking_no ";

		public const string SqlComputeApAccrualSelectByDtl = SqlComputeApAccrualSelect + @",
			CASE WHEN nvl(est.orig_location_cd, '~DUMMY~') = nvl(ca.orig_location_cd, '~DUMMY~')
				THEN 0 ELSE 1 END as mismatch_orig_count,
			CASE WHEN nvl(est.dest_location_cd, '~DUMMY~') = nvl(ca.dest_location_cd, '~DUMMY~')
					THEN 0 ELSE 1 END as mismatch_dest_count,
			CASE WHEN nvl(bk.booking_no, '~DUMMY~') = nvl(edt.booking_no, '~DUMMY~')
				THEN 0 ELSE 1 END as mismatch_bk_count,
			CASE WHEN nvl(bk.customer_ref, '~DUMMY~') = nvl(edt.customer_ref, '~DUMMY~')
				THEN 0 ELSE 1 END as mismatch_pcfn_count,
			CASE WHEN	TO_CHAR(nvl(bk.sail_dt, DATE'1950-01-01'), 'MM-YYYY') =
						TO_CHAR(nvl(edt.sail_dt, DATE'1950-01-01'), 'MM-YYYY')
				THEN 0 ELSE 1 END as mismatch_sail_count,
			CASE WHEN nvl(trunc(c.length_nbr, 2), -1950) = nvl(edt.length_nbr, -1950)
				THEN 0 ELSE 1 END as mismatch_len_count,
			CASE WHEN nvl(trunc(c.width_nbr, 2), -1950) = nvl(edt.width_nbr, -1950)
				THEN 0 ELSE 1 END as mismatch_wid_count,
			CASE WHEN nvl(trunc(c.height_nbr, 2), -1950) = nvl(edt.height_nbr, -1950)
				THEN 0 ELSE 1 END as mismatch_hgt_count,
			CASE WHEN nvl(c.weight_nbr, -1950) = nvl(edt.weight_nbr, -1950)
				THEN 0 ELSE 1 END as mismatch_wgt_count,
			CASE WHEN nvl(c.dim_weight_nbr, -1950) = nvl(edt.dim_weight_nbr, -1950)
				THEN 0 ELSE 1 END as mismatch_dwt_count,
			CASE WHEN nvl(c.cube_ft, -1950) = nvl(edt.cube_ft, -1950)
				THEN 0 ELSE 1 END as mismatch_cft_count,
			CASE WHEN nvl(c.m_tons, -1950) = nvl(edt.m_tons, -1950)
				THEN 0 ELSE 1 END as mismatch_mt_count,
			edt.serial_no, echg.charge_type_cd, cht.charge_type_dsc, lvu.level_unit_dsc,
			edt.estimate_charge_dtl_id, edt.create_user, edt.create_dt, edt.modify_user, edt.modify_dt,
			edt.estimate_charge_id, edt.cargo_activity_id, edt.activity_amt, edt.activity_unit_qty,
			edt.booking_no, edt.customer_ref, edt.vessel_cd, edt.voyage_no, edt.sail_dt,
			edt.plor_location_cd, edt.pol_location_cd, edt.pod_location_cd, edt.plod_location_cd,
			edt.move_type_cd, edt.container_no, edt.cargo_key, edt.length_nbr,
			edt.width_nbr, edt.height_nbr, edt.weight_nbr, edt.dim_weight_nbr, edt.cube_ft, edt.m_tons,
			edt.length_nbr || ' x ' || edt.width_nbr || ' x ' || edt.height_nbr as len_wid_hgt,
			c.length_nbr || ' x ' || c.width_nbr || ' x ' || c.height_nbr as bk_len_wid_hgt,
			c.weight_nbr as bk_weight_nbr, c.dim_weight_nbr as bk_dim_weight_nbr,
			c.cube_ft as bk_cube_ft, c.m_tons as bk_m_tons, bk.booking_no as bk_booking_no,
			bk.customer_ref as bk_customer_ref, bk.sail_dt as bk_sail_dt,
			bk.plor_location_cd as bk_plor_location_cd, bk.pol_location_cd as bk_pol_location_cd,
			bk.pod_location_cd as bk_pod_location_cd, bk.plod_location_cd as bk_plod_location_cd,
			c.serial_no as bk_serial_no, c.move_type_cd as bk_move_type_cd,
			c.container_no as bk_container_no, c.cargo_key as bk_cargo_key,
			est.orig_location_cd, est.dest_location_cd,
			ca.orig_location_cd as ca_orig_location_cd,
			ca.dest_location_cd as ca_dest_location_cd,
            
            nvl(BK_FIN.booking_no,bk.booking_no) as FINANCIAL_BOOKING,
            nvl(BK_FIN.voyage_no,bk.voyage_no) as FINANCIAL_VOYAGE ";

		#endregion		// #region Queries for Computing AP Accruals

		#region Query Existing AP Accruals

		public const string SqlExistApAccrualSelect = @"
		SELECT	acc.vessel_cd, acc.voyage_no AS edt_voyage_no, bk.voyage_no AS bk_voyage_no,
				acc.voyage_no AS est_voyage_no, bk.vessel_cd as bk_vessel_cd,
				CASE WHEN	est.voyage_no is null or bk.voyage_no is null or
							est.voyage_no = bk.voyage_no
					THEN 'N' ELSE 'Y' END as voy_est_bk_err_flg,
				CASE WHEN	bk.voyage_no is null or acc.voyage_no = bk.voyage_no
					THEN 'N' ELSE 'Y' END as voy_edt_bk_err_flg,
				CASE WHEN	bk.vessel_cd is null or acc.vessel_cd = bk.vessel_cd
					THEN 'N' ELSE 'Y' END as ves_edt_bk_err_flg,
				est.estimate_id, acc.estimate_no, acc.est_orig_location_cd as orig_location_cd,
				eoloc.location_dsc AS orig_location_dsc, acc.est_dest_location_cd as dest_location_cd,
				edloc.location_dsc AS dest_location_dsc, acc.vendor_cd, ven.vendor_nm,
				CASE
					WHEN acc.est_dest_location_cd = acc.pol_location_cd	THEN edloc.location_dsc
					WHEN acc.est_orig_location_cd = acc.pod_location_cd	THEN eoloc.location_dsc
					ELSE 'UNKNOWN'
				END AS port_location_dsc,
				CASE
					WHEN acc.est_dest_location_cd = acc.pol_location_cd	THEN 'FROM'
					WHEN acc.est_orig_location_cd = acc.pod_location_cd	THEN 'TO'
					ELSE 'UNKNOWN'
				END AS direction_info,
				CASE
					WHEN acc.est_dest_location_cd = acc.pol_location_cd	THEN eoloc.location_dsc
					WHEN acc.est_orig_location_cd = acc.pod_location_cd	THEN edloc.location_dsc
					ELSE 'UNKNOWN'
				END AS from_or_to_location_dsc,

                nvl(BK_FIN.booking_no,bk.booking_no) as FINANCIAL_BOOKING,
                nvl(BK_FIN.voyage_no,bk.voyage_no) as FINANCIAL_VOYAGE ";

		public const string SqlExistApAccrualFrom = @"
		FROM	t_cargo_accrual acc
			LEFT OUTER JOIN r_charge_type cht		ON cht.charge_type_cd = acc.charge_type_cd
			LEFT OUTER JOIN r_level_unit lvu		ON lvu.level_unit_id = acc.level_unit_id
			LEFT OUTER JOIN r_location eoloc		ON eoloc.location_cd = acc.est_orig_location_cd
			LEFT OUTER JOIN r_location edloc		ON edloc.location_cd = acc.est_dest_location_cd
			LEFT OUTER JOIN r_vendor ven			ON ven.vendor_cd = acc.vendor_cd
			LEFT OUTER JOIN t_cargo_activity ca
				INNER JOIN t_cargo c				ON c.cargo_id = ca.cargo_id
				INNER JOIN t_booking bk				ON bk.booking_id = c.booking_id
													ON ca.cargo_activity_id = acc.cargo_activity_id
			LEFT OUTER JOIN t_estimate_charge echg
				INNER JOIN t_estimate est			ON est.estimate_id = echg.estimate_id
													ON echg.estimate_charge_id = acc.estimate_charge_id

            left outer join (select distinct booking_no, linked_booking_NO, first_booking_no from v_transshipments) BK_TRAN on bk.booking_no = BK_TRAN.linked_booking_no
            left outer join t_booking BK_FIN on BK_FIN.booking_no = nvl(BK_TRAN.first_booking_no,bk.booking_no) ";

		public const string SqlExistApAccrualGroupBy = @"
		GROUP BY
				acc.vessel_cd, acc.voyage_no, est.voyage_no, bk.vessel_cd, bk.voyage_no,
				est.estimate_id, acc.estimate_no, acc.est_orig_location_cd, eoloc.location_dsc,
				acc.est_dest_location_cd, edloc.location_dsc, acc.vendor_cd, ven.vendor_nm,
				CASE
					WHEN acc.est_dest_location_cd = acc.pol_location_cd	THEN edloc.location_dsc
					WHEN acc.est_orig_location_cd = acc.pod_location_cd	THEN eoloc.location_dsc
					ELSE 'UNKNOWN'
				END,
				CASE
					WHEN acc.est_dest_location_cd = acc.pol_location_cd	THEN 'FROM'
					WHEN acc.est_orig_location_cd = acc.pod_location_cd	THEN 'TO'
					ELSE 'UNKNOWN'
				END,
				CASE
					WHEN acc.est_dest_location_cd = acc.pol_location_cd	THEN eoloc.location_dsc
					WHEN acc.est_orig_location_cd = acc.pod_location_cd	THEN edloc.location_dsc
					ELSE 'UNKNOWN'
				END,
                
                nvl(BK_FIN.booking_no,bk.booking_no),
                nvl(BK_FIN.voyage_no,bk.voyage_no) ";

		public const string SqlExistApAccrualSummaryColumns = @",
			SUM(CASE WHEN est.estimate_id IS NULL OR nvl(est.orig_location_cd, '~DUMMY~') =
													nvl(acc.est_orig_location_cd, '~DUMMY~')
						THEN 0 ELSE 1 END) as mismatch_orig_count,
			SUM(CASE WHEN est.estimate_id IS NULL OR nvl(est.dest_location_cd, '~DUMMY~') =
														nvl(acc.est_dest_location_cd, '~DUMMY~')
				THEN 0 ELSE 1 END) as mismatch_dest_count,
			SUM(CASE WHEN bk.booking_id IS NULL OR nvl(bk.booking_no, '~DUMMY~') =
													nvl(acc.booking_no, '~DUMMY~')
				THEN 0 ELSE 1 END) as mismatch_bk_count,
			SUM(CASE WHEN bk.booking_id IS NULL OR nvl(bk.customer_ref, '~DUMMY~') =
													nvl(acc.customer_ref, '~DUMMY~')
				THEN 0 ELSE 1 END) as mismatch_pcfn_count,
			SUM(CASE WHEN	TO_CHAR(nvl(bk.sail_dt, DATE'1950-01-01'), 'MM-YYYY') =
							TO_CHAR(nvl(acc.sail_dt, DATE'1950-01-01'), 'MM-YYYY')
				THEN 0 ELSE 1 END) as mismatch_sail_count,
			SUM(CASE WHEN c.cargo_id IS NULL OR nvl(trunc(c.length_nbr, 2), -1950) =
												nvl(acc.length_nbr, -1950)
				THEN 0 ELSE 1 END) as mismatch_len_count,
			SUM(CASE WHEN c.cargo_id IS NULL OR nvl(trunc(c.width_nbr, 2), -1950) =
												nvl(acc.width_nbr, -1950)
				THEN 0 ELSE 1 END) as mismatch_wid_count,
			SUM(CASE WHEN c.cargo_id IS NULL OR nvl(trunc(c.height_nbr, 2), -1950) =
												nvl(acc.height_nbr, -1950)
				THEN 0 ELSE 1 END) as mismatch_hgt_count,
			SUM(CASE WHEN c.cargo_id IS NULL OR nvl(c.weight_nbr, -1950) =
												nvl(acc.weight_nbr, -1950)
				THEN 0 ELSE 1 END) as mismatch_wgt_count,
			SUM(CASE WHEN c.cargo_id IS NULL OR nvl(c.dim_weight_nbr, -1950) =
												nvl(acc.dim_weight_nbr, -1950)
				THEN 0 ELSE 1 END) as mismatch_dwt_count,
			SUM(CASE WHEN c.cargo_id IS NULL OR nvl(c.cube_ft, -1950) =
												nvl(acc.cube_ft, -1950)
				THEN 0 ELSE 1 END) as mismatch_cft_count,
			SUM(CASE WHEN c.cargo_id IS NULL OR nvl(c.m_tons, -1950) =
												nvl(acc.m_tons, -1950)
				THEN 0 ELSE 1 END) as mismatch_mt_count,
			SUM(acc.activity_amt) AS ap_accrual_amt,
			COUNT(DISTINCT acc.cargo_key) AS piece_cnt,
			SUM(DECODE(echg.charge_type_cd, 'EITV', acc.activity_amt, 0)) AS eitv_amt,
			COUNT(DECODE(echg.charge_type_cd, 'EITV', acc.cargo_activity_id, NULL)) AS eitv_cnt ";

		// removed since it is no longer possible to reliably recreate the estimate total after
		// accrual is submitted since we now set the FKs to cargo act, and estimate charge to null
		// on delete. It's usefulness was questionable anyway.
		/*(	SELECT	SUM(acc2.activity_amt)
				FROM	t_cargo_accrual acc2
				WHERE	acc2.estimate_no = acc.estimate_no
			) AS tot_ap_est_amt,*/

		public const string SqlExistApAccrualSelectSummary =
			SqlExistApAccrualSelect + SqlExistApAccrualSummaryColumns;

		public const string SqlExistApAccrualSelectByCharge = SqlExistApAccrualSelect + @",
			acc.charge_type_cd, cht.charge_type_dsc, lvu.level_unit_dsc " +
			SqlExistApAccrualSummaryColumns;

		public const string SqlExistApAccrualGroupByCharge = SqlExistApAccrualGroupBy + @",
			acc.charge_type_cd, cht.charge_type_dsc, lvu.level_unit_dsc ";

		public const string SqlExistApAccrualSelectByCargo = SqlExistApAccrualSelect + @",
			acc.cargo_key, acc.serial_no, acc.booking_no" +
			SqlExistApAccrualSummaryColumns + @",
			COUNT(DISTINCT ca.cargo_activity_id) AS activity_cnt ";

		public const string SqlExistApAccrualGroupByCargo = SqlExistApAccrualGroupBy + @",
			acc.cargo_key, acc.serial_no, acc.booking_no ";

		public const string SqlExistApAccrualSelectByDtl = SqlExistApAccrualSelect + @",
			CASE WHEN est.estimate_id IS NULL OR nvl(est.orig_location_cd, '~DUMMY~') =
													nvl(acc.est_orig_location_cd, '~DUMMY~')
						THEN 0 ELSE 1 END as mismatch_orig_count,
			CASE WHEN est.estimate_id IS NULL OR nvl(est.dest_location_cd, '~DUMMY~') =
														nvl(acc.est_dest_location_cd, '~DUMMY~')
				THEN 0 ELSE 1 END as mismatch_dest_count,
			CASE WHEN bk.booking_id IS NULL OR nvl(bk.booking_no, '~DUMMY~') =
													nvl(acc.booking_no, '~DUMMY~')
				THEN 0 ELSE 1 END as mismatch_bk_count,
			CASE WHEN bk.booking_id IS NULL OR nvl(bk.customer_ref, '~DUMMY~') =
													nvl(acc.customer_ref, '~DUMMY~')
				THEN 0 ELSE 1 END as mismatch_pcfn_count,
			CASE WHEN	TO_CHAR(nvl(bk.sail_dt, DATE'1950-01-01'), 'MM-YYYY') =
						TO_CHAR(nvl(acc.sail_dt, DATE'1950-01-01'), 'MM-YYYY')
				THEN 0 ELSE 1 END as mismatch_sail_count,
			CASE WHEN c.cargo_id IS NULL OR nvl(trunc(c.length_nbr, 2), -1950) =
												nvl(acc.length_nbr, -1950)
				THEN 0 ELSE 1 END as mismatch_len_count,
			CASE WHEN c.cargo_id IS NULL OR nvl(trunc(c.width_nbr, 2), -1950) =
												nvl(acc.width_nbr, -1950)
				THEN 0 ELSE 1 END as mismatch_wid_count,
			CASE WHEN c.cargo_id IS NULL OR nvl(trunc(c.height_nbr, 2), -1950) =
												nvl(acc.height_nbr, -1950)
				THEN 0 ELSE 1 END as mismatch_hgt_count,
			CASE WHEN c.cargo_id IS NULL OR nvl(c.weight_nbr, -1950) =
												nvl(acc.weight_nbr, -1950)
				THEN 0 ELSE 1 END as mismatch_wgt_count,
			CASE WHEN c.cargo_id IS NULL OR nvl(c.dim_weight_nbr, -1950) =
												nvl(acc.dim_weight_nbr, -1950)
				THEN 0 ELSE 1 END as mismatch_dwt_count,
			CASE WHEN c.cargo_id IS NULL OR nvl(c.cube_ft, -1950) =
												nvl(acc.cube_ft, -1950)
				THEN 0 ELSE 1 END as mismatch_cft_count,
			CASE WHEN c.cargo_id IS NULL OR nvl(c.m_tons, -1950) =
												nvl(acc.m_tons, -1950)
				THEN 0 ELSE 1 END as mismatch_mt_count,
			acc.serial_no, acc.charge_type_cd, cht.charge_type_dsc, lvu.level_unit_dsc,
			acc.cargo_accrual_id, acc.create_user, acc.create_dt, acc.modify_user, acc.modify_dt,
			acc.estimate_charge_id, acc.cargo_activity_id, acc.activity_amt, acc.activity_unit_qty,
			acc.booking_no, acc.customer_ref, acc.vessel_cd, acc.voyage_no, acc.sail_dt,
			acc.plor_location_cd, acc.pol_location_cd, acc.pod_location_cd, acc.plod_location_cd,
			acc.move_type_cd, acc.container_no, acc.cargo_key, acc.length_nbr,
			acc.width_nbr, acc.height_nbr, acc.weight_nbr, acc.dim_weight_nbr, acc.cube_ft, acc.m_tons,
			acc.length_nbr || ' x ' || acc.width_nbr || ' x ' || acc.height_nbr as len_wid_hgt,
			c.length_nbr || ' x ' || c.width_nbr || ' x ' || c.height_nbr as bk_len_wid_hgt,
			c.weight_nbr as bk_weight_nbr, c.dim_weight_nbr as bk_dim_weight_nbr,
			c.cube_ft as bk_cube_ft, c.m_tons as bk_m_tons, bk.booking_no as bk_booking_no,
			bk.customer_ref as bk_customer_ref, bk.sail_dt as bk_sail_dt,
			bk.plor_location_cd as bk_plor_location_cd, bk.pol_location_cd as bk_pol_location_cd,
			bk.pod_location_cd as bk_pod_location_cd, bk.plod_location_cd as bk_plod_location_cd,
			c.serial_no as bk_serial_no, c.move_type_cd as bk_move_type_cd,
			c.container_no as bk_container_no, c.cargo_key as bk_cargo_key,
			est.orig_location_cd, est.dest_location_cd,
			ca.orig_location_cd as ca_orig_location_cd,
			ca.dest_location_cd as ca_dest_location_cd,

            nvl(BK_FIN.booking_no,bk.booking_no) as FINANCIAL_BOOKING,
            nvl(BK_FIN.voyage_no,bk.voyage_no) as FINANCIAL_VOYAGE ";

		#endregion		// #region Query Existing AP Accruals

		private string SqlApSelectSummary(bool existing)
		{
			return existing ? SqlExistApAccrualSelectSummary : SqlComputeApAccrualSelectSummary;
		}

		private string SqlApAccrualFrom(bool existing)
		{
			return existing ? SqlExistApAccrualFrom : SqlComputeApAccrualFrom;
		}

		private string SqlApAccrualGroupBy(bool existing)
		{
			return existing ? SqlExistApAccrualGroupBy : SqlComputeApAccrualGroupBy;
		}

		private string SqlApAccrualSelectByCharge(bool existing)
		{
			return existing ? SqlExistApAccrualSelectByCharge : SqlComputeApAccrualSelectByCharge;
		}

		private string SqlApAccrualGroupByCharge(bool existing)
		{
			return existing ? SqlExistApAccrualGroupByCharge : SqlComputeApAccrualGroupByCharge;
		}

		private string SqlApAccrualSelectByCargo(bool existing)
		{
			return existing ? SqlExistApAccrualSelectByCargo : SqlComputeApAccrualSelectByCargo;
		}

		private string SqlApAccrualGroupByCargo(bool existing)
		{
			return existing ? SqlExistApAccrualGroupByCargo : SqlComputeApAccrualGroupByCargo;
		}

		private string SqlApAccrualSelectByDtl(bool existing)
		{
			return existing ? SqlExistApAccrualSelectByDtl : SqlComputeApAccrualSelectByDtl;
		}

		public DataSet SearchApComputeAccrualsDS()
		{
			return SearchApAccrualsDS(false);
		}

		public DataSet SearchApExistingAccrualsDS()
		{
			return SearchApAccrualsDS(true);
		}

		private DataSet SearchApAccrualsDS(bool existing)
		{
			DataSet ds = new DataSet(); 

			DataTable dtSummary = SearchApAccrualSummary(existing);
			ds.Tables.Add(dtSummary);

			if (dtSummary != null && dtSummary.Rows.Count > 0)
			{
				DataTable dtByCharge = SearchApAccrualByCharge(existing);

				if (dtByCharge != null)
				{
					ds.Tables.Add(dtByCharge);

					DataColumn[] dcPK = new DataColumn[8];
					dcPK[0] = dtSummary.Columns["EDT_VOYAGE_NO"];
					dcPK[1] = dtSummary.Columns["VESSEL_CD"];
					dcPK[2] = dtSummary.Columns["BK_VESSEL_CD"];
					dcPK[3] = dtSummary.Columns["ESTIMATE_NO"];
					dcPK[4] = dtSummary.Columns["PORT_LOCATION_DSC"];
					dcPK[5] = dtSummary.Columns["DIRECTION_INFO"];
					dcPK[6] = dtSummary.Columns["FROM_OR_TO_LOCATION_DSC"];
					dcPK[7] = dtSummary.Columns["VENDOR_NM"];

					DataColumn[] dcFK = new DataColumn[8];
					dcFK[0] = dtByCharge.Columns["EDT_VOYAGE_NO"];
					dcFK[1] = dtByCharge.Columns["VESSEL_CD"];
					dcFK[2] = dtByCharge.Columns["BK_VESSEL_CD"];
					dcFK[3] = dtByCharge.Columns["ESTIMATE_NO"];
					dcFK[4] = dtByCharge.Columns["PORT_LOCATION_DSC"];
					dcFK[5] = dtByCharge.Columns["DIRECTION_INFO"];
					dcFK[6] = dtByCharge.Columns["FROM_OR_TO_LOCATION_DSC"];
					dcFK[7] = dtByCharge.Columns["VENDOR_NM"];

					ds.Relations.Add("AccrualSummaryCharges", dcPK, dcFK, false);

					if (dtByCharge.Rows.Count > 0)
					{
						DataTable dtActChgDtl = SearchApAccrualChgDtl(existing);

						if (dtActChgDtl != null)
						{
							ds.Tables.Add(dtActChgDtl);

							dcPK = new DataColumn[9];
							dcPK[0] = dtByCharge.Columns["EDT_VOYAGE_NO"];
							dcPK[1] = dtByCharge.Columns["VESSEL_CD"];
							dcPK[2] = dtByCharge.Columns["BK_VESSEL_CD"];
							dcPK[3] = dtByCharge.Columns["ESTIMATE_NO"];
							dcPK[4] = dtByCharge.Columns["PORT_LOCATION_DSC"];
							dcPK[5] = dtByCharge.Columns["DIRECTION_INFO"];
							dcPK[6] = dtByCharge.Columns["FROM_OR_TO_LOCATION_DSC"];
							dcPK[7] = dtByCharge.Columns["VENDOR_NM"];
							dcPK[8] = dtByCharge.Columns["CHARGE_TYPE_CD"];

							dcFK = new DataColumn[9];
							dcFK[0] = dtActChgDtl.Columns["EDT_VOYAGE_NO"];
							dcFK[1] = dtActChgDtl.Columns["VESSEL_CD"];
							dcFK[2] = dtActChgDtl.Columns["BK_VESSEL_CD"];
							dcFK[3] = dtActChgDtl.Columns["ESTIMATE_NO"];
							dcFK[4] = dtActChgDtl.Columns["PORT_LOCATION_DSC"];
							dcFK[5] = dtActChgDtl.Columns["DIRECTION_INFO"];
							dcFK[6] = dtActChgDtl.Columns["FROM_OR_TO_LOCATION_DSC"];
							dcFK[7] = dtActChgDtl.Columns["VENDOR_NM"];
							dcFK[8] = dtActChgDtl.Columns["CHARGE_TYPE_CD"];

							ds.Relations.Add("AccrualActiviyChargeDetail", dcPK, dcFK, false);
						}
					}
				}

				DataTable dtByCargo = SearchApAccrualByCargo(existing);

				if (dtByCargo != null)
				{
					ds.Tables.Add(dtByCargo);

					DataColumn[] dcPK = new DataColumn[8];
					dcPK[0] = dtSummary.Columns["EDT_VOYAGE_NO"];
					dcPK[1] = dtSummary.Columns["VESSEL_CD"];
					dcPK[2] = dtSummary.Columns["BK_VESSEL_CD"];
					dcPK[3] = dtSummary.Columns["ESTIMATE_NO"];
					dcPK[4] = dtSummary.Columns["PORT_LOCATION_DSC"];
					dcPK[5] = dtSummary.Columns["DIRECTION_INFO"];
					dcPK[6] = dtSummary.Columns["FROM_OR_TO_LOCATION_DSC"];
					dcPK[7] = dtSummary.Columns["VENDOR_NM"];

					DataColumn[] dcFK = new DataColumn[8];
					dcFK[0] = dtByCargo.Columns["EDT_VOYAGE_NO"];
					dcFK[1] = dtByCargo.Columns["VESSEL_CD"];
					dcFK[2] = dtByCargo.Columns["BK_VESSEL_CD"];
					dcFK[3] = dtByCargo.Columns["ESTIMATE_NO"];
					dcFK[4] = dtByCargo.Columns["PORT_LOCATION_DSC"];
					dcFK[5] = dtByCargo.Columns["DIRECTION_INFO"];
					dcFK[6] = dtByCargo.Columns["FROM_OR_TO_LOCATION_DSC"];
					dcFK[7] = dtByCargo.Columns["VENDOR_NM"];

					ds.Relations.Add("AccrualSummaryCargo", dcPK, dcFK, false);
				}
			}

			return ds;
		}

		private DataTable SearchApAccrualSummary(bool existing)
		{
			List<DbParameter> p = new List<DbParameter>();
			StringBuilder sb = new StringBuilder(SqlApSelectSummary(existing) +
				SqlApAccrualFrom(existing) + @"
			WHERE 1 = 1");

			AppendWhereAccruals(existing, sb, p);

			sb.Append(SqlApAccrualGroupBy(existing));
			sb.Append(@"
			ORDER BY	edt_voyage_no, port_location_dsc, from_or_to_location_dsc, estimate_no ");

			DataTable dt = Connection.GetDataTable(sb.ToString(), p.ToArray());
			if (dt != null)
			{
				dt.TableName = "AccrualSummary";
				//dt.Columns.Add("Percent", typeof(decimal),
					//"IIF(tot_ap_est_amt <> 0, ap_accrual_amt / tot_ap_est_amt, 0)");
			}
			return dt;
		}

		public DataTable SearchApAccrualByCharge(bool existing)
		{
			List<DbParameter> p = new List<DbParameter>();
			StringBuilder sb = new StringBuilder(SqlApAccrualSelectByCharge(existing) +
				SqlApAccrualFrom(existing) + @"
			WHERE 1 = 1");

			AppendWhereAccruals(existing, sb, p);

			sb.Append(SqlApAccrualGroupByCharge(existing));
			sb.Append(@"
			ORDER BY	edt_voyage_no, port_location_dsc, from_or_to_location_dsc, estimate_no,
						charge_type_cd");

			DataTable dt = Connection.GetDataTable(sb.ToString(), p.ToArray());
			if (dt != null)
			{
				dt.TableName = "AccrualSummaryCharges";
				//dt.Columns.Add("Percent", typeof(decimal),
					//"IIF(tot_ap_est_amt <> 0, ap_accrual_amt / tot_ap_est_amt, 0)");
			}
			return dt;
		}

		public DataTable SearchApAccrualByCargo(bool existing)
		{
			List<DbParameter> p = new List<DbParameter>();
			StringBuilder sb = new StringBuilder(SqlApAccrualSelectByCargo(existing) +
				SqlApAccrualFrom(existing) + @"
			WHERE 1 = 1");

			AppendWhereAccruals(existing, sb, p);

			sb.Append(SqlApAccrualGroupByCargo(existing));
			sb.Append(@"
			ORDER BY	edt_voyage_no, port_location_dsc, from_or_to_location_dsc, estimate_no,
						booking_no, serial_no, cargo_key ");

			DataTable dt = Connection.GetDataTable(sb.ToString(), p.ToArray());
			if (dt != null)
			{
				dt.TableName = "AccrualSummaryCargo";
				//dt.Columns.Add("Percent", typeof(decimal),
					//"IIF(tot_ap_est_amt <> 0, ap_accrual_amt / tot_ap_est_amt, 0)");
			}
			return dt;
		}

		public DataTable SearchApAccrualChgDtl(bool existing)
		{
			List<DbParameter> p = new List<DbParameter>();
			StringBuilder sb = new StringBuilder(SqlApAccrualSelectByDtl(existing) +
				SqlApAccrualFrom(existing) + @"
			WHERE 1 = 1");

			AppendWhereAccruals(existing, sb, p);

			sb.Append(@"
			ORDER BY	edt_voyage_no, port_location_dsc, from_or_to_location_dsc, estimate_no,
						serial_no");

			DataTable dt = Connection.GetDataTable(sb.ToString(), p.ToArray());
			if (dt != null)
			{
				dt.TableName = "AccrualActivityChargeDetail";
			}
			return dt;
		}

		public void AppendWhereAccruals(bool existing, StringBuilder sb, List<DbParameter> p)
		{
			if (existing)
				AppendWhereExist(sb, p);
			else
				AppendWhereCompute(sb, p);
		}

		public void AppendWhereCompute(StringBuilder sb, List<DbParameter> p)
		{
			if (Estimate_ID != null)
				Connection.AppendEqualClause(sb, p, "AND", "est.estimate_id", "@EST_ID", Estimate_ID);
			else
				Connection.AppendInClause(sb, p, "AND", "est.estimate_id", "@EST_CSV", csvEstimateID);

			Connection.AppendLikeClause(sb, p, "AND",
				"est.estimate_no", "@EST_NO", Estimate_No);
			Connection.AppendLikeClause(sb, p, "AND",
				"est.voyage_no", "@VOY_NO", VoyageNo);
			Connection.AppendInClause(sb, p, "AND",
				"est.orig_location_cd", "@ACT_ORIG_CD", ClsConvert.AddQuotes(Act_Orig_CDs));
			Connection.AppendInClause(sb, p, "AND",
				"est.dest_location_cd", "@ACT_DEST_CD", ClsConvert.AddQuotes(Act_Dest_CDs));

			Connection.AppendLikeClause(sb, p, "AND",
				"edt.customer_ref", "@PCFN", PCFN);
			Connection.AppendLikeClause(sb, p, "AND",
				"edt.booking_no", "@BK_NO", Booking_No);
			Connection.AppendInClause(sb, p, "AND",
				"edt.customer_ref", "@PCSV", ClsConvert.AddQuotes(csvPCFN));
			Connection.AppendInClause(sb, p, "AND",
				"edt.booking_no", "@BK_CSV", ClsConvert.AddQuotes(csvBooking));

			Connection.AppendInClause(sb, p, "AND",
				"edt.plor_location_cd", "@PLOR_CD", ClsConvert.AddQuotes(PLOR_CDs));
			Connection.AppendInClause(sb, p, "AND",
				"edt.pol_location_cd", "@POL_CD", ClsConvert.AddQuotes(POL_CDs));
			Connection.AppendInClause(sb, p, "AND",
				"edt.pod_location_cd", "@POD_CD", ClsConvert.AddQuotes(POD_CDs));
			Connection.AppendInClause(sb, p, "AND",
				"edt.plod_location_cd", "@PLOD_CD", ClsConvert.AddQuotes(PLOD_CDs));

			Connection.AppendInClause(sb, p, "AND",
				"edt.move_type_cd", "@MV_TP", ClsConvert.AddQuotes(MoveTypeCDs));
			Connection.AppendLikeClause(sb, p, "AND",
				"edt.serial_no", "@SER_NO", Serial_No);

			Connection.AppendInClause(sb, p, "AND",
				"edt.vessel_cd", "@VES_CD", ClsConvert.AddQuotes(Vessel));

            // JD - Adding a sub-query that returns a list of all bookings that should be in the Accural for a given month
            // 3 UNIONS
            // 1 - Bookings that are not associated with a Transshipment
            // 2 - Bookings that are the first leg of a transshipment
            // 3 - Bookings that are the second leg of a transshipment
            // DG - May2021: first filter on booking Sail Date
            sb.AppendFormat(@" 
                    and bk.sail_dt between '{0:dd-MMM-yy}' and '{1:dd-MMM-yy}'  
                    and edt.booking_no in 
                (
                Select distinct ecd.booking_no
                from t_estimate_charge_dtl ecd 
                where 1=1
                and (ecd.booking_no not in (Select t1.booking_no from v_transshipments t1 ))
                and ecd.sail_dt between '{0:dd-MMM-yy}' and '{1:dd-MMM-yy}' 
                UNION

                Select distinct tra.first_booking_no
                from t_estimate_charge_dtl ecd2 
                inner join v_transshipments tra on ((tra.first_booking_no = ecd2.booking_no) and (tra.leg_type = 'First Leg'))
                where 1=1 
                and ecd2.sail_dt between '{2:dd-MMM-yy}' and '{3:dd-MMM-yy}'

                UNION
                Select distinct tra.booking_no
                from t_booking b9  
                inner join v_transshipments tra on ((tra.first_booking_no = b9.booking_no) and (tra.leg_type = 'Final Leg')
                )
                where 1=1 
                and b9.sail_dt between '{4:dd-MMM-yy}' and '{5:dd-MMM-yy}' 

                )", 
                    Vessel_Sail_Dt.FromDate.Date, Vessel_Sail_Dt.ToDate.Date,
                    Vessel_Sail_Dt.FromDate.Date, Vessel_Sail_Dt.ToDate.Date, 
                    Vessel_Sail_Dt.FromDate.Date, Vessel_Sail_Dt.ToDate.Date);


            // JD - Replace statement ... 

            //            UNION
            //Select distinct tra.booking_no
            //from t_estimate_charge_dtl ecd3 
            //inner join v_transshipments tra on ((tra.first_booking_no = ecd3.booking_no) and (tra.leg_type = 'Final Leg'))
            //where 1=1 
            //and ecd3.sail_dt between '{4:dd-MMM-yy}' and '{5:dd-MMM-yy}' 



            // JD - Replace statement ...
            //Connection.AppendDateClause(sb, p, "AND",
            //    "edt.sail_dt", "@SAIL_FR", "@SAIL_TO", Vessel_Sail_Dt);
		}

		public void AppendWhereExist(StringBuilder sb, List<DbParameter> p)
		{
			if (Estimate_ID != null)
				Connection.AppendEqualClause(sb, p, "AND", "est.estimate_id", "@EST_ID", Estimate_ID);
			else
				Connection.AppendInClause(sb, p, "AND", "est.estimate_id", "@EST_CSV", csvEstimateID);

			Connection.AppendLikeClause(sb, p, "AND",
				"acc.estimate_no", "@EST_NO", Estimate_No);
			Connection.AppendLikeClause(sb, p, "AND",
				"acc.voyage_no", "@VOY_NO", VoyageNo);
			Connection.AppendInClause(sb, p, "AND",
				"acc.est_orig_location_cd", "@ACT_ORIG_CD", ClsConvert.AddQuotes(Act_Orig_CDs));
			Connection.AppendInClause(sb, p, "AND",
				"acc.est_dest_location_cd", "@ACT_DEST_CD", ClsConvert.AddQuotes(Act_Dest_CDs));

			Connection.AppendLikeClause(sb, p, "AND",
				"acc.customer_ref", "@PCFN", PCFN);
			Connection.AppendLikeClause(sb, p, "AND",
				"acc.booking_no", "@BK_NO", Booking_No);
			Connection.AppendInClause(sb, p, "AND",
				"acc.customer_ref", "@PCSV", ClsConvert.AddQuotes(csvPCFN));
			Connection.AppendInClause(sb, p, "AND",
				"acc.booking_no", "@BK_CSV", ClsConvert.AddQuotes(csvBooking));

			Connection.AppendInClause(sb, p, "AND",
				"acc.plor_location_cd", "@PLOR_CD", ClsConvert.AddQuotes(PLOR_CDs));
			Connection.AppendInClause(sb, p, "AND",
				"acc.pol_location_cd", "@POL_CD", ClsConvert.AddQuotes(POL_CDs));
			Connection.AppendInClause(sb, p, "AND",
				"acc.pod_location_cd", "@POD_CD", ClsConvert.AddQuotes(POD_CDs));
			Connection.AppendInClause(sb, p, "AND",
				"acc.plod_location_cd", "@PLOD_CD", ClsConvert.AddQuotes(PLOD_CDs));

			Connection.AppendInClause(sb, p, "AND",
				"acc.move_type_cd", "@MV_TP", ClsConvert.AddQuotes(MoveTypeCDs));
			Connection.AppendLikeClause(sb, p, "AND",
				"acc.serial_no", "@SER_NO", Serial_No);

			Connection.AppendInClause(sb, p, "AND",
				"acc.vessel_cd", "@VES_CD", ClsConvert.AddQuotes(Vessel));
			Connection.AppendDateClause(sb, p, "AND",
				"bk.sail_dt", "@SAIL_FR", "@SAIL_TO", Vessel_Sail_Dt);
		}

		public DataSet SearchApComputedDiffDS()
		{
			return SearchApDiffDS(false);
		}

		public DataSet SearchApExistingDiffDS()
		{
			return SearchApDiffDS(true);
		}

		private DataSet SearchApDiffDS(bool existing)
		{
			DataSet ds = new DataSet();

			DataTable dtSummary = SearchApAccrualSummaryDiff(existing);
			ds.Tables.Add(dtSummary);

			if (dtSummary != null && dtSummary.Rows.Count > 0)
			{
				DataTable dtByCharge = SearchApAccrualByChargeDiff(existing);

				if (dtByCharge != null)
				{
					ds.Tables.Add(dtByCharge);

					DataColumn[] dcPK = new DataColumn[8];
					dcPK[0] = dtSummary.Columns["EDT_VOYAGE_NO"];
					dcPK[1] = dtSummary.Columns["VESSEL_CD"];
					dcPK[2] = dtSummary.Columns["BK_VESSEL_CD"];
					dcPK[3] = dtSummary.Columns["ESTIMATE_NO"];
					dcPK[4] = dtSummary.Columns["PORT_LOCATION_DSC"];
					dcPK[5] = dtSummary.Columns["DIRECTION_INFO"];
					dcPK[6] = dtSummary.Columns["FROM_OR_TO_LOCATION_DSC"];
					dcPK[7] = dtSummary.Columns["VENDOR_NM"];
					//dcPK[8] = dtSummary.Columns["ROW_DSC"];

					DataColumn[] dcFK = new DataColumn[8];
					dcFK[0] = dtByCharge.Columns["EDT_VOYAGE_NO"];
					dcFK[1] = dtByCharge.Columns["VESSEL_CD"];
					dcFK[2] = dtByCharge.Columns["BK_VESSEL_CD"];
					dcFK[3] = dtByCharge.Columns["ESTIMATE_NO"];
					dcFK[4] = dtByCharge.Columns["PORT_LOCATION_DSC"];
					dcFK[5] = dtByCharge.Columns["DIRECTION_INFO"];
					dcFK[6] = dtByCharge.Columns["FROM_OR_TO_LOCATION_DSC"];
					dcFK[7] = dtByCharge.Columns["VENDOR_NM"];
					//dcFK[8] = dtByCharge.Columns["ROW_DSC"];

					ds.Relations.Add("AccrualSummaryCharges", dcPK, dcFK, false);

					if (dtByCharge.Rows.Count > 0)
					{
						DataTable dtActChgDtl = SearchApActivityChgDtlDiff(existing);

						if (dtActChgDtl != null)
						{
							ds.Tables.Add(dtActChgDtl);

							dcPK = new DataColumn[9];
							dcPK[0] = dtByCharge.Columns["EDT_VOYAGE_NO"];
							dcPK[1] = dtByCharge.Columns["VESSEL_CD"];
							dcPK[2] = dtByCharge.Columns["BK_VESSEL_CD"];
							dcPK[3] = dtByCharge.Columns["ESTIMATE_NO"];
							dcPK[4] = dtByCharge.Columns["PORT_LOCATION_DSC"];
							dcPK[5] = dtByCharge.Columns["DIRECTION_INFO"];
							dcPK[6] = dtByCharge.Columns["FROM_OR_TO_LOCATION_DSC"];
							dcPK[7] = dtByCharge.Columns["VENDOR_NM"];
							//dcPK[8] = dtByCharge.Columns["ROW_DSC"];
							dcPK[8] = dtByCharge.Columns["CHARGE_TYPE_CD"];

							dcFK = new DataColumn[9];
							dcFK[0] = dtActChgDtl.Columns["EDT_VOYAGE_NO"];
							dcFK[1] = dtActChgDtl.Columns["VESSEL_CD"];
							dcFK[2] = dtActChgDtl.Columns["BK_VESSEL_CD"];
							dcFK[3] = dtActChgDtl.Columns["ESTIMATE_NO"];
							dcFK[4] = dtActChgDtl.Columns["PORT_LOCATION_DSC"];
							dcFK[5] = dtActChgDtl.Columns["DIRECTION_INFO"];
							dcFK[6] = dtActChgDtl.Columns["FROM_OR_TO_LOCATION_DSC"];
							dcFK[7] = dtActChgDtl.Columns["VENDOR_NM"];
							//dcFK[8] = dtActChgDtl.Columns["ROW_DSC"];
							dcFK[8] = dtActChgDtl.Columns["CHARGE_TYPE_CD"];

							ds.Relations.Add("AccrualActiviyChargeDetail", dcPK, dcFK, false);
						}
					}
				}

				DataTable dtByCargo = SearchApAccrualByCargoDiff(existing);

				if (dtByCargo != null)
				{
					ds.Tables.Add(dtByCargo);

					DataColumn[] dcPK = new DataColumn[8];
					dcPK[0] = dtSummary.Columns["EDT_VOYAGE_NO"];
					dcPK[1] = dtSummary.Columns["VESSEL_CD"];
					dcPK[2] = dtSummary.Columns["BK_VESSEL_CD"];
					dcPK[3] = dtSummary.Columns["ESTIMATE_NO"];
					dcPK[4] = dtSummary.Columns["PORT_LOCATION_DSC"];
					dcPK[5] = dtSummary.Columns["DIRECTION_INFO"];
					dcPK[6] = dtSummary.Columns["FROM_OR_TO_LOCATION_DSC"];
					dcPK[7] = dtSummary.Columns["VENDOR_NM"];
					//dcPK[8] = dtSummary.Columns["ROW_DSC"];

					DataColumn[] dcFK = new DataColumn[8];
					dcFK[0] = dtByCargo.Columns["EDT_VOYAGE_NO"];
					dcFK[1] = dtByCargo.Columns["VESSEL_CD"];
					dcFK[2] = dtByCargo.Columns["BK_VESSEL_CD"];
					dcFK[3] = dtByCargo.Columns["ESTIMATE_NO"];
					dcFK[4] = dtByCargo.Columns["PORT_LOCATION_DSC"];
					dcFK[5] = dtByCargo.Columns["DIRECTION_INFO"];
					dcFK[6] = dtByCargo.Columns["FROM_OR_TO_LOCATION_DSC"];
					dcFK[7] = dtByCargo.Columns["VENDOR_NM"];
					//dcFK[8] = dtByCargo.Columns["ROW_DSC"];

					ds.Relations.Add("AccrualSummaryCargo", dcPK, dcFK, false);
				}
			}

			return ds;
		}

		private DataTable SearchApAccrualSummaryDiff(bool existing)
		{
			List<DbParameter> p = new List<DbParameter>();
			StringBuilder sb = new StringBuilder("( " + SqlApSelectSummary(existing) +
				SqlApAccrualFrom(existing) + @"
			WHERE 1 = 1");

			AppendWhereAccruals(existing, sb, p);

			sb.Append(SqlApAccrualGroupBy(existing));

			sb.Append(" ) MINUS ( " + SqlApSelectSummary(!existing) +
				SqlApAccrualFrom(!existing) + @"
			WHERE 1 = 1");

			AppendWhereAccruals(!existing, sb, p);

			sb.Append(SqlApAccrualGroupBy(!existing));

			sb.Append(@" )
			ORDER BY	edt_voyage_no, port_location_dsc, from_or_to_location_dsc, estimate_no ");

			DataTable dt = Connection.GetDataTable(sb.ToString(), p.ToArray());
			if (dt != null)
			{
				dt.TableName = "AccrualSummary";
				//dt.Columns.Add("Percent", typeof(decimal),
					//"IIF(tot_ap_est_amt <> 0, ap_accrual_amt / tot_ap_est_amt, 0)");
			}
			return dt;
		}

		public DataTable SearchApAccrualByChargeDiff(bool existing)
		{
			List<DbParameter> p = new List<DbParameter>();
			StringBuilder sb = new StringBuilder("( " + SqlApAccrualSelectByCharge(existing) +
				SqlApAccrualFrom(existing) + @"
			WHERE 1 = 1");

			AppendWhereAccruals(existing, sb, p);

			sb.Append(SqlApAccrualGroupByCharge(existing));

			sb.Append(" ) MINUS ( " + SqlApAccrualSelectByCharge(!existing) +
				SqlApAccrualFrom(!existing) + @"
			WHERE 1 = 1");

			AppendWhereAccruals(!existing, sb, p);

			sb.Append(SqlApAccrualGroupByCharge(!existing));

			sb.Append(@" )
			ORDER BY	edt_voyage_no, port_location_dsc, from_or_to_location_dsc, estimate_no,
						charge_type_cd");

			DataTable dt = Connection.GetDataTable(sb.ToString(), p.ToArray());
			if (dt != null)
			{
				dt.TableName = "AccrualSummaryCharges";
				//dt.Columns.Add("Percent", typeof(decimal),
					//"IIF(tot_ap_est_amt <> 0, ap_accrual_amt / tot_ap_est_amt, 0)");
			}
			return dt;
		}

		public DataTable SearchApAccrualByCargoDiff(bool existing)
		{
			List<DbParameter> p = new List<DbParameter>();
			StringBuilder sb = new StringBuilder("( " + SqlApAccrualSelectByCargo(existing) +
				SqlApAccrualFrom(existing) + @"
			WHERE 1 = 1");

			AppendWhereAccruals(existing, sb, p);

			sb.Append(SqlApAccrualGroupByCargo(existing));

			sb.Append(" ) MINUS ( " + SqlApAccrualSelectByCargo(!existing) +
				SqlApAccrualFrom(!existing) + @"
			WHERE 1 = 1");

			AppendWhereAccruals(!existing, sb, p);

			sb.Append(SqlApAccrualGroupByCargo(!existing));

			sb.Append(@" )
			ORDER BY	edt_voyage_no, port_location_dsc, from_or_to_location_dsc, estimate_no,
						booking_no, serial_no, cargo_key ");

			DataTable dt = Connection.GetDataTable(sb.ToString(), p.ToArray());
			if (dt != null)
			{
				dt.TableName = "AccrualSummaryCargo";
				//dt.Columns.Add("Percent", typeof(decimal),
					//"IIF(tot_ap_est_amt <> 0, ap_accrual_amt / tot_ap_est_amt, 0)");
			}
			return dt;
		}

		public DataTable SearchApActivityChgDtlDiff(bool existing)
		{
			List<DbParameter> p = new List<DbParameter>();
			StringBuilder sb = new StringBuilder("( " + SqlApAccrualSelectByDtl(existing) +
				SqlApAccrualFrom(existing) + @"
			WHERE 1 = 1");

			AppendWhereAccruals(existing, sb, p);

			sb.Append(" ) MINUS ( " + SqlApAccrualSelectByDtl(!existing) +
				SqlApAccrualFrom(!existing) + @"
			WHERE 1 = 1");

			AppendWhereAccruals(!existing, sb, p);

			sb.Append(@" )
			ORDER BY	edt_voyage_no, port_location_dsc, from_or_to_location_dsc, estimate_no,
						serial_no");

			DataTable dt = Connection.GetDataTable(sb.ToString(), p.ToArray());
			if (dt != null)
			{
				dt.TableName = "AccrualActivityChargeDetail";
			}
			return dt;
		}
		#endregion		// #region Estimate AP Accrual for Accounting
	}
}