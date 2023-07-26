using System;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;
using System.Text;

namespace CS2010.ArcSys.Business
{
	public class ClsCargoTracking
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ArcSys"]; }
		}
		#endregion		// #region Connection Manager

		#region Fields

		public long? Cargo_Move_ID;
		public string csvCargoMoveID;

		public string Serial_No;
		public string Orig_CDs;
		public string Dest_CDs;
		public string Orig_DSCs;
		public string Dest_DSCs;
		public string Last_Loc_CDs;
		public string Last_Loc_DSCs;
		public string Move_Dsc;
		public string Voyage_No;
		public string Vessel_CDs;
		public string Booking_No;
		public string Customer_Ref;

		public string Vendor_Cd;

		public string Cargo_Status_DSCs;

		public short? Days_RDD;
		public short? Days_Inactive;

		public DateRange Vessel_Sail_Dt;

		#endregion		// #region Fields

		#region Constructors/Initialization

		public ClsCargoTracking()
		{
			Clear();
		}

		public void Clear()
		{
			Orig_CDs = Dest_CDs = Serial_No = Move_Dsc = csvCargoMoveID =
				Orig_DSCs = Dest_DSCs = Vendor_Cd = Cargo_Status_DSCs = Last_Loc_CDs =
				Last_Loc_DSCs = Voyage_No = Vessel_CDs = Booking_No = Customer_Ref = null;

			Cargo_Move_ID = null;

			Days_Inactive = Days_RDD = null;

			Vessel_Sail_Dt.Clear();
		}
		#endregion		// #region Constructors/Initialization

		#region ToString Overrides

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();

			if (!string.IsNullOrEmpty(Move_Dsc)) sb.AppendFormat(" Move {0} ", Move_Dsc);
			if (!string.IsNullOrEmpty(Serial_No)) sb.AppendFormat(" Serial # {0} ", Serial_No);
			if (!string.IsNullOrEmpty(Booking_No)) sb.AppendFormat(" Booking # {0} ", Booking_No);
			if (!string.IsNullOrEmpty(Customer_Ref)) sb.AppendFormat(" PCFN # {0} ", Customer_Ref);
			if (!string.IsNullOrEmpty(Orig_CDs)) sb.AppendFormat(" Orig {0} ", Orig_DSCs);
			if (!string.IsNullOrEmpty(Dest_CDs)) sb.AppendFormat(" Dest {0} ", Dest_DSCs);
			if (!string.IsNullOrEmpty(Last_Loc_CDs)) sb.AppendFormat(" Last Loc {0} ", Last_Loc_DSCs);
			if (!string.IsNullOrEmpty(Voyage_No)) sb.AppendFormat(" Voyage {0} ", Voyage_No);
			if (!string.IsNullOrEmpty(Vessel_CDs)) sb.AppendFormat(" Vessel {0} ", Vessel_CDs);
			if (Cargo_Move_ID.GetValueOrDefault(0) > 0) sb.AppendFormat(" ID {0} ", Cargo_Move_ID);
			if (!string.IsNullOrEmpty(csvCargoMoveID)) sb.AppendFormat(" IDs {0} ", csvCargoMoveID);

			if (!string.IsNullOrEmpty(Cargo_Status_DSCs)) sb.AppendFormat(" Status {0} ", Cargo_Status_DSCs);

			if (Days_RDD.GetValueOrDefault(0) > 0) sb.AppendFormat(" Days to RDD {0} ", Days_RDD);
			if (Days_Inactive.GetValueOrDefault(0) > 0) sb.AppendFormat(" Days since last action {0} ", Days_Inactive);
			if (!Vessel_Sail_Dt.IsEmpty) sb.AppendFormat(" Sailed {0} ", Vessel_Sail_Dt);

			return sb.ToString();
		}
		#endregion		// #region ToString Overrides

		#region Search Existing Methods

		public DataSet SearchCargoPlusActions()
		{
			DataSet ds = new DataSet();

			DataTable dtCargo = SearchCargo();
			ds.Tables.Add(dtCargo);

			if (dtCargo.Rows.Count > 0)
			{
				DataTable dtActions = SearchActions();
				ds.Tables.Add(dtActions);

				DataColumn[] dcPK = new DataColumn[1];
				dcPK[0] = dtCargo.Columns["CARGO_MOVE_ID"];

				DataColumn[] dcFK = new DataColumn[1];
				dcFK[0] = dtActions.Columns["CARGO_MOVE_ID"];

				ds.Relations.Add("CargoActions", dcPK, dcFK, false);
			}

			return ds;
		}

		public DataTable SearchCargo()
		{
			List<DbParameter> p = new List<DbParameter>();
			StringBuilder sb = new StringBuilder(@"
			SELECT	mv.trading_partner_cd, tp.partner_dsc, mv.move_dsc, vmv.vendor_cd, ven.vendor_nm,
					vmv.orig_location_cd, oloc.location_dsc AS orig_location_dsc,
					vmv.dest_location_cd, dloc.location_dsc AS dest_location_dsc,
					cnv.conveyance_no, cnv.driver,
					cnv.truck_no, cnv.conveyance_type_cd, cnvt.conveyance_type_dsc,
					nvl(cnv.futile_flg, 'N') AS futile_flg,
					NVL2(cmv.conveyance_id, 1, 0) AS truck_order,
					cmv.*,
					CASE
						WHEN cmv.container_no IS NULL THEN ''
						ELSE cmv.container_no || '  Seals:' || NVL(cmv.seal1, '') ||
							CASE WHEN cmv.seal2 IS NULL THEN '' ELSE ' / ' || cmv.seal2 END || 
							CASE WHEN cmv.seal3 IS NULL THEN '' else ' / ' || cmv.seal3 END
					END AS container_info,
					cmv.length_nbr || ' x ' || cmv.width_nbr || ' x ' || cmv.height_nbr as len_wid_hgt,
					lga.action_cd AS last_log_action_cd, 
					nvl(lgac.action_dsc, 'Assigned to Vendor') AS last_log_action_dsc,
					nvl(lga.location_cd, oloc.location_cd) AS last_log_location_cd,
					nvl(lgloc.location_dsc, oloc.location_dsc) AS last_log_location_dsc,
					nvl(lga.action_dt, cmv.create_dt) AS last_log_action_dt,
					(TRUNC(cmv.required_dlvy_dt) - TRUNC(nvl(cmv.move_end_dt, sysdate))) AS rdd_days,
					(trunc(nvl(cmv.move_start_dt, SYSDATE)) - trunc(cmv.create_dt)) AS days_at_origin,
					(trunc(nvl(cmv.move_end_dt, SYSDATE)) - trunc(cmv.move_start_dt)) AS days_moving,
					(trunc(NVL(cmv.in_gate_dt, nvl2(cmv.delivery_dt, NULL, SYSDATE))) - trunc(cmv.move_end_dt)) AS days_to_ingate,
					(trunc(nvl(cmv.delivery_dt, SYSDATE)) - trunc(NVL(cmv.in_gate_dt, cmv.move_end_dt))) AS days_to_delivery,
					(trunc(nvl(cmv.in_gate_dt, nvl2(cmv.delivery_dt, NULL, SYSDATE))) - trunc(cmv.move_start_dt)) AS tot_days_to_ingate,
					(trunc(nvl(cmv.delivery_dt, SYSDATE)) - trunc(cmv.move_start_dt)) AS tot_days_to_delivery,
					(trunc(nvl(cmv.delivery_dt, SYSDATE)) - trunc(cmv.create_dt)) AS tot_days_with_vendor,
					(TRUNC(sysdate) - TRUNC(lga.action_dt)) AS days_since_log_action,
					DECODE(lgac.start_flg, NULL, 'No Action', 'Y', 'Moving', 'N', 'Waiting', 'UNKNOWN') AS days_since_log_dsc,
					(TRUNC(sysdate) - TRUNC(cact.action_dt)) AS days_since_any_action,
					cactac.action_dsc AS last_admin_action_dsc, cact.action_dt AS last_admin_action_dt,
					CASE
						WHEN 	cmv.move_start_dt IS NULL
								THEN 'At Origin'
						WHEN 	cmv.move_start_dt IS NOT NULL AND
								cmv.move_end_dt IS NULL AND
								lgac.start_flg = 'Y'
								THEN 'In Transit'
						WHEN 	cmv.move_start_dt IS NOT NULL AND
								cmv.move_end_dt IS NULL AND
								lgac.end_flg = 'Y'
								THEN 'At Checkpoint'
						WHEN 	cmv.move_start_dt IS NOT NULL AND
								cmv.move_end_dt IS NOT NULL AND
								cmv.in_gate_dt IS NULL AND
								cmv.delivery_dt IS NULL AND
								vmv.orig_location_cd = cmv.plor_location_cd
								THEN 'At POL'
						WHEN 	cmv.move_start_dt IS NOT NULL AND
								cmv.move_end_dt IS NOT NULL AND
								cmv.in_gate_dt IS NULL AND
								cmv.delivery_dt IS NULL AND
								vmv.dest_location_cd = cmv.plod_location_cd
								THEN 'At Final Destination'
						WHEN 	cmv.move_start_dt IS NOT NULL AND
								cmv.move_end_dt IS NOT NULL AND
								cmv.in_gate_dt IS NOT NULL AND
								cmv.delivery_dt IS NULL
								THEN 'In Gate'
						WHEN 	cmv.move_start_dt IS NOT NULL AND
								cmv.move_end_dt IS NOT NULL AND
								cmv.delivery_dt IS NOT NULL AND
								vmv.dest_location_cd = cmv.plod_location_cd
								THEN 'Delivered to Customer'
						WHEN 	cmv.move_start_dt IS NOT NULL AND
								cmv.move_end_dt IS NOT NULL AND
								cmv.delivery_dt IS NOT NULL AND
								vmv.orig_location_cd = cmv.plor_location_cd AND
								cmv.move_type_cd IN ('F5', 'F6')
								THEN 'Delivered to Port (F5, F6)'
						WHEN 	cmv.move_start_dt IS NOT NULL AND
								cmv.move_end_dt IS NOT NULL AND
								cmv.delivery_dt IS NOT NULL AND
								vmv.orig_location_cd = cmv.plor_location_cd AND
								cmv.move_type_cd NOT IN ('F5', 'F6')
								THEN 'Moved to POL (F7, F8, F9)'
						ELSE	'Unknown Status'
					END AS cargo_status,
					CASE
						WHEN 	cmv.move_start_dt IS NULL
								THEN 1
						WHEN 	cmv.move_start_dt IS NOT NULL AND
								cmv.move_end_dt IS NULL AND
								lgac.start_flg = 'Y'
								THEN 2
						WHEN 	cmv.move_start_dt IS NOT NULL AND
								cmv.move_end_dt IS NULL AND
								lgac.end_flg = 'Y'
								THEN 3
						WHEN 	cmv.move_start_dt IS NOT NULL AND
								cmv.move_end_dt IS NOT NULL AND
								cmv.in_gate_dt IS NULL AND
								cmv.delivery_dt IS NULL AND
								vmv.orig_location_cd = cmv.plor_location_cd
								THEN 4
						WHEN 	cmv.move_start_dt IS NOT NULL AND
								cmv.move_end_dt IS NOT NULL AND
								cmv.in_gate_dt IS NULL AND
								cmv.delivery_dt IS NULL AND
								vmv.dest_location_cd = cmv.plod_location_cd
								THEN 8
						WHEN 	cmv.move_start_dt IS NOT NULL AND
								cmv.move_end_dt IS NOT NULL AND
								cmv.in_gate_dt IS NOT NULL AND
								cmv.delivery_dt IS NULL
								THEN 5
						WHEN 	cmv.move_start_dt IS NOT NULL AND
								cmv.move_end_dt IS NOT NULL AND
								cmv.delivery_dt IS NOT NULL AND
								vmv.dest_location_cd = cmv.plod_location_cd
								THEN 9
						WHEN 	cmv.move_start_dt IS NOT NULL AND
								cmv.move_end_dt IS NOT NULL AND
								cmv.delivery_dt IS NOT NULL AND
								vmv.orig_location_cd = cmv.plor_location_cd AND
								cmv.move_type_cd IN ('F5', 'F6')
								THEN 7
						WHEN 	cmv.move_start_dt IS NOT NULL AND
								cmv.move_end_dt IS NOT NULL AND
								cmv.delivery_dt IS NOT NULL AND
								vmv.orig_location_cd = cmv.plor_location_cd AND
								cmv.move_type_cd NOT IN ('F5', 'F6')
								THEN 6
						ELSE	0
					END AS cargo_status_order,
					CASE
						WHEN	oloc.location_type_cd = 'LAND' AND dloc.location_type_cd = 'PORT'
								THEN 'IN'
						WHEN	oloc.location_type_cd = 'PORT' AND dloc.location_type_cd = 'LAND'
								THEN 'OUT'
						ELSE	''
					END AS mv_direction,
					ves.vessel_nm,
					plor.location_dsc AS plor_location_dsc, pol.location_dsc AS pol_location_dsc,
					pod.location_dsc AS pod_location_dsc, plod.location_dsc AS plod_location_dsc,
					(	SELECT	MIN(activity_dt)
						FROM	t_booking_unit<DBLINK>acmsp bu
								INNER JOIN t_booking_itv<DBLINK>acmsp itv	ON (itv.item_no = bu.item_no AND
																				RTRIM(itv.activity_code) = 'W' AND
																				itv.booking_id = bu.booking_id)
						WHERE	SUBSTR(bu.voyage_no, 0, 5) = SUBSTR(cmv.voyage_no, 0, 5)
						AND		cmv.serial_no = bu.tcn
					) AS w_activity_dt,
					(	SELECT	MIN(activity_dt)
						FROM	t_booking_unit<DBLINK>acmsp bu
								INNER JOIN t_booking_itv<DBLINK>acmsp itv	ON (itv.item_no = bu.item_no AND
																		RTRIM(itv.activity_code) = 'X1' AND
																		itv.booking_id = bu.booking_id)
						WHERE	SUBSTR(bu.voyage_no, 0, 5) = SUBSTR(cmv.voyage_no, 0, 5)
						AND		cmv.serial_no = bu.tcn
					) AS x1_activity_dt,
					(	SELECT	MIN(itv.create_dt)
						FROM	t_booking_unit<DBLINK>acmsp bu
								INNER JOIN t_booking_itv<DBLINK>acmsp itv	ON (itv.item_no = bu.item_no AND
																		RTRIM(itv.activity_code) = 'W' AND
																		itv.booking_id = bu.booking_id)
						WHERE	SUBSTR(bu.voyage_no, 0, 5) = SUBSTR(cmv.voyage_no, 0, 5)
						AND		cmv.serial_no = bu.tcn
					) AS w_create_dt,
					(	SELECT	MIN(itv.create_dt)
						FROM	t_booking_unit<DBLINK>acmsp bu
								INNER JOIN t_booking_itv<DBLINK>acmsp itv	ON (itv.item_no = bu.item_no AND
																		RTRIM(itv.activity_code) = 'X1' AND
																		itv.booking_id = bu.booking_id)
						WHERE	SUBSTR(bu.voyage_no, 0, 5) = SUBSTR(cmv.voyage_no, 0, 5)
						AND		cmv.serial_no = bu.tcn
					) AS x1_create_dt,
					DECODE(cmv.plor_location_cd, vmv.orig_location_cd, 'Y', 'N') AS w_required_flg,
					DECODE(cmv.plod_location_cd, vmv.dest_location_cd, 'Y', 'N') AS x1_required_flg,
					CASE
						WHEN vmv.orig_location_cd = cmv.plor_location_cd THEN 'TO PORT'
						WHEN vmv.dest_location_cd = cmv.plod_location_cd THEN 'FROM PORT'
						ELSE 'UNKNOWN'
					END AS direction_info
			FROM t_cargo_move cmv
				INNER JOIN v_vendor_move vmv 			ON vmv.vendor_move_id = cmv.vendor_move_id
				INNER JOIN t_move mv					ON mv.move_id = vmv.move_id
				INNER JOIN v_vendor_location oloc		ON oloc.location_cd = vmv.orig_location_cd
				INNER JOIN v_vendor_location dloc		ON dloc.location_cd = vmv.dest_location_cd
				INNER JOIN r_trading_partner tp			ON tp.trading_partner_cd = mv.trading_partner_cd
				INNER JOIN v_vendor ven					ON ven.vendor_cd = vmv.vendor_cd
				LEFT OUTER JOIN r_vessel ves			ON ves.vessel_cd = cmv.vessel_cd
				LEFT OUTER JOIN r_location plor			ON plor.location_cd = cmv.plor_location_cd
				LEFT OUTER JOIN r_location pol			ON pol.location_cd = cmv.pol_location_cd
				LEFT OUTER JOIN r_location pod			ON pod.location_cd = cmv.pod_location_cd
				LEFT OUTER JOIN r_location plod			ON plod.location_cd = cmv.plod_location_cd
				LEFT OUTER JOIN t_conveyance cnv		ON cnv.conveyance_id = cmv.conveyance_id
				LEFT OUTER JOIN r_conveyance_type cnvt	ON cnvt.conveyance_type_cd = cnv.conveyance_type_cd
				LEFT OUTER JOIN t_cargo_action lga
					INNER JOIN r_action lgac			ON lgac.action_cd = lga.action_cd
					INNER JOIN r_location lgloc			ON lgloc.location_cd = lga.location_cd
														ON lga.cargo_action_id = cmv.last_logistic_action_id
				LEFT OUTER JOIN t_cargo_action cact
					INNER JOIN r_action cactac			ON cactac.action_cd = cact.action_cd
														ON cact.cargo_action_id = cmv.last_cargo_action_id
			WHERE 1=1");

			AppendWhereExisting(sb, p, true);

			sb.Append(@"
			order by	cargo_status_order, last_log_location_dsc, serial_no, mv_direction, partner_dsc, move_dsc, orig_location_dsc, dest_location_dsc,
						truck_order, truck_no NULLS FIRST, conveyance_id, vendor_nm ");

			DataTable dt = Connection.GetDataTable(sb.ToString(), p.ToArray());
			if (dt != null)
			{
				dt.TableName = "Cargo";
			}
			return dt;
		}

		public DataTable SearchActions()
		{
			List<DbParameter> p = new List<DbParameter>();
			StringBuilder sb = new StringBuilder(@"
			SELECT	vmv.vendor_cd, ven.vendor_nm,
					vmv.orig_location_cd, oloc.location_dsc AS orig_location_dsc,
					vmv.dest_location_cd, dloc.location_dsc AS dest_location_dsc,
					cnv.truck_no, cnv.conveyance_type_cd, cnvt.conveyance_type_dsc,
					nvl(cnv.futile_flg, 'N') AS futile_flg,
					NVL2(cmv.conveyance_id, 1, 0) AS truck_order,
					cmv.cargo_move_id, cmv.serial_no, ac.action_dsc, actloc.location_dsc,
					cact.*
			FROM t_cargo_move cmv
				INNER JOIN v_vendor_move vmv 			ON vmv.vendor_move_id = cmv.vendor_move_id
				INNER JOIN t_move mv					ON mv.move_id = vmv.move_id
				INNER JOIN r_location oloc				ON oloc.location_cd = vmv.orig_location_cd
				INNER JOIN r_location dloc				ON dloc.location_cd = vmv.dest_location_cd
				INNER JOIN r_trading_partner tp			ON tp.trading_partner_cd = mv.trading_partner_cd
				INNER JOIN v_vendor ven					ON ven.vendor_cd = vmv.vendor_cd
				INNER JOIN t_cargo_action cact			ON cact.cargo_move_id = cmv.cargo_move_id
				INNER JOIN r_action ac					ON ac.action_cd = cact.action_cd
				INNER JOIN r_location actloc			ON actloc.location_cd = cact.location_cd
				LEFT OUTER JOIN r_vessel ves			ON ves.vessel_cd = cmv.vessel_cd
				LEFT OUTER JOIN r_location plor			ON plor.location_cd = cmv.plor_location_cd
				LEFT OUTER JOIN r_location pol			ON pol.location_cd = cmv.pol_location_cd
				LEFT OUTER JOIN r_location pod			ON pod.location_cd = cmv.pod_location_cd
				LEFT OUTER JOIN r_location plod			ON plod.location_cd = cmv.plod_location_cd
				LEFT OUTER JOIN t_conveyance cnv		ON cnv.conveyance_id = cmv.conveyance_id
				LEFT OUTER JOIN r_conveyance_type cnvt	ON cnvt.conveyance_type_cd = cnv.conveyance_type_cd
			WHERE 1=1");

			AppendWhereExisting(sb, p, false);

			sb.Append(@"
			order by	truck_order, partner_dsc, move_dsc, orig_location_dsc, dest_location_dsc,
						truck_no NULLS FIRST, conveyance_id, vendor_nm, serial_no ");

			DataTable dt = Connection.GetDataTable(sb.ToString(), p.ToArray());
			if (dt != null)
			{
				dt.TableName = "CargoActions";
			}
			return dt;
		}

		public void AppendWhereExisting(StringBuilder sb, List<DbParameter> p, bool parent)
		{
			Connection.AppendEqualClause(sb, p, "AND", "vmv.vendor_cd", "@VEN_CD", Vendor_Cd);
			Connection.AppendLikeClause(sb, p, "AND", "mv.move_dsc", "@MV_DSC", Move_Dsc);
			Connection.AppendInClause(sb, p, "AND", "vmv.orig_location_cd", "@ORIG_CD", Orig_CDs);
			Connection.AppendInClause(sb, p, "AND", "vmv.dest_location_cd", "@DEST_CD", Dest_CDs);
			Connection.AppendInClause(sb, p, "AND", "cmv.vessel_cd", "@VESS_CD", Vessel_CDs);
			Connection.AppendLikeClause(sb, p, "AND", "cmv.voyage_no", "@VY_NO", Voyage_No);
			Connection.AppendLikeClause(sb, p, "AND", "cmv.serial_no", "@SER_NO", Serial_No);
			Connection.AppendLikeClause(sb, p, "AND", "cmv.booking_no", "@BK_NO", Booking_No);
			Connection.AppendLikeClause(sb, p, "AND", "cmv.customer_ref", "@PCFN_NO", Customer_Ref);
			Connection.AppendDateClause(sb, p, "AND",
				"cmv.sail_dt", "@SAIL_FT", "@SAIL_TO", Vessel_Sail_Dt);

			if (Days_RDD != null)
			{
				if (Days_RDD < 0)
				{
					sb.Append(@"
				AND (TRUNC(cmv.required_dlvy_dt) - TRUNC(NVL(cmv.move_end_dt, sysdate))) < 0");
				}
				else
				{
					//Connection.OpenParentheses(sb, "AND");
					//sb.Append(" cmv.required_dlvy_dt IS NOT NULL ");
					//string rddSql = "(TRUNC(cmv.required_dlvy_dt) - TRUNC(NVL(cmv.move_end_dt, sysdate))) ";
					//Connection.AppendLTClause(sb, p, "AND", rddSql, "@RDD_DYS", Days_RDD, true);
					sb.Append(@"
					AND cmv.move_end_dt IS NULL ");
					string rddSql = "(TRUNC(cmv.required_dlvy_dt) - TRUNC(sysdate)) ";
					Connection.AppendRangeClause(sb, p, "AND", rddSql, "@RD_DAY_FR", "@RD_DAY_TO", 0, Days_RDD);
					//Connection.CloseParentheses(sb);
				}
			}

			if (parent)
			{
				if (!string.IsNullOrWhiteSpace(Cargo_Status_DSCs))
				{
					string statusClause = @"
					CASE
						WHEN 	cmv.move_start_dt IS NULL
								THEN 'At Origin'
						WHEN 	cmv.move_start_dt IS NOT NULL AND
								cmv.move_end_dt IS NULL AND
								lgac.start_flg = 'Y'
								THEN 'In Transit'
						WHEN 	cmv.move_start_dt IS NOT NULL AND
								cmv.move_end_dt IS NULL AND
								lgac.end_flg = 'Y'
								THEN 'At Checkpoint'
						WHEN 	cmv.move_start_dt IS NOT NULL AND
								cmv.move_end_dt IS NOT NULL AND
								cmv.in_gate_dt IS NULL AND
								cmv.delivery_dt IS NULL
								THEN 'At Destination'
						WHEN 	cmv.move_start_dt IS NOT NULL AND
								cmv.move_end_dt IS NOT NULL AND
								cmv.in_gate_dt IS NOT NULL AND
								cmv.delivery_dt IS NULL
								THEN 'In Gate'
						WHEN 	cmv.move_start_dt IS NOT NULL AND
								cmv.move_end_dt IS NOT NULL AND
								cmv.delivery_dt IS NOT NULL AND
								lgloc.location_type_cd = 'LAND'
								THEN 'Delivered to Customer'
						WHEN 	cmv.move_start_dt IS NOT NULL AND
								cmv.move_end_dt IS NOT NULL AND
								cmv.delivery_dt IS NOT NULL AND
								lgloc.location_type_cd = 'PORT' AND
								cmv.move_type_cd IN ('F5', 'F6')
								THEN 'Delivered to Port'
						WHEN 	cmv.move_start_dt IS NOT NULL AND
								cmv.move_end_dt IS NOT NULL AND
								cmv.delivery_dt IS NOT NULL AND
								lgloc.location_type_cd = 'PORT' AND
								cmv.move_type_cd NOT IN ('F5', 'F6')
								THEN 'With Ocean Carrier'
						ELSE	'Unknown Status'
					END ";
					Connection.AppendInClause(sb, p, "AND", statusClause, "@CR_ST_DSC", Cargo_Status_DSCs);
				}

				Connection.AppendInClause(sb, p, "AND",
					"nvl(lga.location_cd, oloc.location_cd)", "@LST_LOC_CD", Last_Loc_CDs);

				if (Days_Inactive.GetValueOrDefault(0) >= 0)
				{
					string inactSql = "(TRUNC(sysdate) - TRUNC(nvl(lga.action_dt, cmv.create_dt))) ";
					Connection.AppendLTClause(sb, p, "AND", inactSql, "@INAC_DYS", Days_Inactive, true);
				}
			}
		}
		#endregion		// #region Search Methods
	}
}