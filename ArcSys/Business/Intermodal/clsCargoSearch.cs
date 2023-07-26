using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CS2010.Common;
using System.Data;
using System.Data.Common;

namespace CS2010.ArcSys
{
	public static class clsCargoSearch
	{

		#region Connection Manager

		private static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ArcSys"]; }
		}
		#endregion		// #region Connection Manager

		public static DataTable SearchCargo(clsCargoParameters CP)
		{

			StringBuilder SQL = new StringBuilder(@"
				SELECT 
				* 
				FROM T_CARGO C
				INNER JOIN T_BOOKING B 
				ON B.BOOKING_ID = C.BOOKING_ID
				WHERE 1=1
			");

			if (CP.SERIAL_NO.IsNotNull()) SQL.AppendFormat(" AND C.SERIAL_NO = '{0}'", CP.SERIAL_NO);

			if (CP.MOVE_TYPE_CD.IsNotNull()) SQL.AppendFormat(" AND C.MOVE_TYPE_CD = '{0}'", CP.MOVE_TYPE_CD);

			if (CP.PLOR.IsNotNull()) SQL.AppendFormat(" AND B.PLOR_LOCATION_CD = '{0}'", CP.PLOR);

			if (CP.POL.IsNotNull()) SQL.AppendFormat(" AND B.POL_LOCATION_CD = '{0}'", CP.POL);

			if (CP.POD.IsNotNull()) SQL.AppendFormat(" AND B.POD_LOCATION_CD = '{0}'", CP.POD);

			if (CP.PLOD.IsNotNull()) SQL.AppendFormat(" AND B.PLOD_LOCATION_CD = '{0}'", CP.PLOD);

			if (CP.BOOKING_NO.IsNotNull()) SQL.AppendFormat(" AND B.BOOKING_NO = '{0}'", CP.BOOKING_NO);

			if (CP.BOOKING_REF.IsNotNull()) SQL.AppendFormat(" AND B.BOOKING_REF = '{0}'", CP.BOOKING_REF);

			if (CP.BOL_NO.IsNotNull()) SQL.AppendFormat(" AND B.BOL_NO = '{0}'", CP.BOL_NO);

			if (CP.EDI_REF.IsNotNull()) SQL.AppendFormat(" AND B.EDI_REF = '{0}'", CP.EDI_REF);

			if (CP.CUSTOMER_REF.IsNotNull()) SQL.AppendFormat(" AND B.CUSTOMER_REF = '{0}'", CP.CUSTOMER_REF);

			if (CP.VESSEL_CD.IsNotNull()) SQL.AppendFormat(" AND B.VESSEL_CD = '{0}'", CP.VESSEL_CD);

			if (CP.VOYAGE_NO.IsNotNull()) SQL.AppendFormat(" AND B.VOYAGE_NO = '{0}'", CP.VOYAGE_NO);

			return Connection.GetDataTable(SQL.ToString());

		}

		public static DataSet SearchCargoDS(clsCargoParameters cp)
		{
			DataSet ds = new DataSet();

			DataTable dtCargo = SearchCargoDT(cp);
			ds.Tables.Add(dtCargo);

			if (dtCargo.Rows.Count > 0)
			{
				DataTable dtCharges = SearchCharges(cp);
				ds.Tables.Add(dtCharges);

				DataColumn[] dcPK = new DataColumn[1];
				dcPK[0] = dtCargo.Columns["CARGO_ID"];

				DataColumn[] dcFK = new DataColumn[1];
				dcFK[0] = dtCharges.Columns["CARGO_ID"];

				ds.Relations.Add("CargoCharges", dcPK, dcFK, false);
			}

			return ds;
		}

		public static DataTable SearchCargoDT(clsCargoParameters cp)
		{
			List<DbParameter> p = new List<DbParameter>();
			StringBuilder sb = new StringBuilder(@"
			SELECT	c.cargo_id, c.create_user, c.create_dt, c.modify_user, c.modify_dt, c.booking_id,
					c.serial_no, c.item_no, c.commodity_cd, c.pkg_type_cd, c.length_nbr, c.width_nbr,
					c.height_nbr, c.weight_nbr, c.dim_weight_nbr, c.cube_ft, c.m_tons, c.move_type_cd,
					c.cargo_dsc, c.vessel_load_dt, c.contract_mod_id, c.container_no, c.seal1, c.seal2,
					c.seal3, c.make_cd, c.model_cd, c.cargo_key, c.cargo_rcvd_dt, c.rdd_dt,
					bk.booking_no, bk.booking_ref, bk.plor_location_cd, bk.pol_location_cd, bk.pod_location_cd,
					bk.plod_location_cd, plor.location_dsc AS plor_location_dsc,
					pol.location_dsc AS pol_location_dsc, pod.location_dsc AS pod_location_dsc,
					plod.location_dsc AS plod_location_dsc, bk.bol_no, bk.edi_ref, bk.customer_ref,
					bk.customer_cd, bk.match_cd, bk.vessel_cd, ves.vessel_nm, bk.voyage_no as bk_voyage_no,
					bk.sail_dt, bk.delivery_txt, bk.cargo_notes_txt, cust.customer_nm,
					bk.booking_no || ' -' || to_char(c.item_no, '00') as bk_item_no,
					c.length_nbr || ' x ' || c.width_nbr || ' x ' || c.height_nbr || ' - ' ||
						bk.booking_no || ' Item Group' || to_char(c.item_no, '00') as lwh_bk_item_no,
					c.cargo_dsc || ' ' || c.length_nbr || ' x ' || c.width_nbr || ' x ' ||
					c.height_nbr as cargo_dsc_lwh,
					c.length_nbr || ' x ' || c.width_nbr || ' x ' || c.height_nbr as len_wid_hgt,
					cmod.mod_no, cmod.attachment_nm, 
					DECODE(cmod.contract_mod_id, NULL, NULL, cmod.mod_no || ' - ' ||
					NVL(cmod.attachment_nm, '<No Attachment>')) AS mod_no_attachment_nm,
					NVL((SELECT SUM(apedt.activity_amt) FROM t_estimate_charge_dtl apedt
						INNER JOIN t_estimate_charge echg ON echg.estimate_charge_id = apedt.estimate_charge_id
						INNER JOIN t_cargo_activity ca2 ON ca2.cargo_activity_id = apedt.cargo_activity_id
						WHERE ca2.cargo_id = c.cargo_id and echg.finance_cd = 'AP'
						), 0) AS ap_total_amt,
					NVL((SELECT SUM(aredt.activity_amt) FROM t_estimate_charge_dtl aredt
						INNER JOIN t_estimate_charge echg ON echg.estimate_charge_id = aredt.estimate_charge_id
						INNER JOIN t_cargo_activity ca2 ON ca2.cargo_activity_id = aredt.cargo_activity_id
						WHERE ca2.cargo_id = c.cargo_id and echg.finance_cd = 'AR'
						), 0) as ar_total_amt,
					COUNT(ca.cargo_activity_id) AS act_cnt
			FROM	t_cargo c
				INNER JOIN t_booking bk				ON bk.booking_id = c.booking_id
				INNER JOIN r_location plor			ON plor.location_cd = bk.plor_location_cd
				INNER JOIN r_location pol			ON pol.location_cd = bk.pol_location_cd
				INNER JOIN r_location pod			ON pod.location_cd = bk.pod_location_cd
				INNER JOIN r_location plod			ON plod.location_cd = bk.plod_location_cd
				INNER JOIN r_vessel ves				ON ves.vessel_cd = bk.vessel_cd
				LEFT OUTER JOIN t_cargo_activity ca	ON ca.cargo_id = c.cargo_id
				LEFT OUTER JOIN r_customer cust		ON cust.customer_cd = bk.customer_cd
				LEFT OUTER JOIN t_contract_mod cmod ON cmod.contract_mod_id = c.contract_mod_id
			WHERE	1 = 1 ");

			AppendWhereExisting(cp, sb, p, true);

			sb.Append(@"
			GROUP BY
				c.cargo_id, c.create_user, c.create_dt, c.modify_user, c.modify_dt, c.booking_id,
				c.serial_no, c.item_no, c.commodity_cd, c.pkg_type_cd, c.length_nbr, c.width_nbr,
				c.height_nbr, c.weight_nbr, c.dim_weight_nbr, c.cube_ft, c.m_tons, c.move_type_cd,
				c.cargo_dsc, c.vessel_load_dt, c.contract_mod_id, c.container_no, c.seal1, c.seal2,
				c.seal3, c.make_cd, c.model_cd, c.cargo_key, c.cargo_rcvd_dt, c.rdd_dt,
				bk.booking_no, bk.booking_ref, bk.plor_location_cd, bk.pol_location_cd, bk.pod_location_cd,
				bk.plod_location_cd, plor.location_dsc, pol.location_dsc, pod.location_dsc,
				plod.location_dsc, bk.bol_no, bk.edi_ref, bk.customer_ref,
				bk.customer_cd, bk.match_cd, bk.vessel_cd, ves.vessel_nm, bk.voyage_no,
				bk.sail_dt, bk.delivery_txt, bk.cargo_notes_txt, cust.customer_nm,
				cmod.mod_no, cmod.attachment_nm, cmod.contract_mod_id
			ORDER BY	bk.booking_no, c.serial_no ");

			DataTable dt = Connection.GetDataTable(sb.ToString(), p.ToArray());
			if (dt != null)
			{
				dt.TableName = "Cargo";
				dt.Columns.Add("ar_ap_diff", typeof(decimal), "ar_total_amt - ap_total_amt");
			}
			return dt;
		}

		public static DataTable SearchCharges(clsCargoParameters cp)
		{
			StringBuilder sb = new StringBuilder(@"
			SELECT	c.cargo_id, c.create_user, c.create_dt, c.modify_user, c.modify_dt, c.booking_id,
					c.serial_no, c.item_no, c.commodity_cd, c.pkg_type_cd, c.length_nbr, c.width_nbr,
					c.height_nbr, c.weight_nbr, c.dim_weight_nbr, c.cube_ft, c.m_tons, c.move_type_cd,
					c.cargo_dsc, c.vessel_load_dt, c.contract_mod_id, c.container_no, c.seal1, c.seal2,
					c.seal3, c.make_cd, c.model_cd, c.cargo_key, c.cargo_rcvd_dt, c.rdd_dt,
					bk.booking_no, bk.booking_ref, bk.plor_location_cd, bk.pol_location_cd, bk.pod_location_cd,
					bk.plod_location_cd, plor.location_dsc AS plor_location_dsc,
					pol.location_dsc AS pol_location_dsc, pod.location_dsc AS pod_location_dsc,
					plod.location_dsc AS plod_location_dsc, bk.bol_no, bk.edi_ref, bk.customer_ref,
					bk.customer_cd, bk.match_cd, bk.vessel_cd, ves.vessel_nm, bk.voyage_no as bk_voyage_no,
					bk.sail_dt, bk.delivery_txt, bk.cargo_notes_txt, cust.customer_nm,
					bk.booking_no || ' -' || to_char(c.item_no, '00') as bk_item_no,
					c.length_nbr || ' x ' || c.width_nbr || ' x ' || c.height_nbr || ' - ' ||
						bk.booking_no || ' Item Group' || to_char(c.item_no, '00') as lwh_bk_item_no,
					c.cargo_dsc || ' ' || c.length_nbr || ' x ' || c.width_nbr || ' x ' ||
					c.height_nbr as cargo_dsc_lwh,
					c.length_nbr || ' x ' || c.width_nbr || ' x ' || c.height_nbr as len_wid_hgt,
					cmod.mod_no, cmod.attachment_nm,
					DECODE(cmod.contract_mod_id, NULL, NULL, cmod.mod_no || ' - ' ||
					NVL(cmod.attachment_nm, '<No Attachment>')) AS mod_no_attachment_nm,
					edt.estimate_charge_id, edt.activity_amt, edt.activity_unit_qty,
					echg.charge_type_cd, cht.charge_type_dsc, cht.charge_category_cd,
					echg.vendor_cd, echg.tcn_count, echg.rate_amt, echg.total_amt, echg.memo,
					echg.finance_cd, lvu.level_unit_dsc, lvu.level_cd, lvu.unit_type_cd,
					lvu.level_count_dsc, lvu.unit_qty_dsc, lvu.average_flg, ut.units_required_flg,
					decode(lvu.average_flg, 'N', null,
						echg.level_count || ' ' || lvu.level_count_dsc) AS level_disp,
					decode(ut.units_required_flg, 'Y', echg.unit_qty || ' ' || ut.grid_column_dsc,
						null) AS unit_disp,
					decode(lvu.average_flg, 'N', nvl(edt.activity_unit_qty, 0) ||
						decode(ut.units_required_flg, 'Y', ' ' || ut.grid_column_dsc, null),
						null) AS act_unit_disp,
					decode(echg.finance_cd, 'AR', edt.activity_amt, -edt.activity_amt) AS adj_activity_amt,
					echg.estimate_id, est.estimate_no,
					estoloc.location_dsc as orig_location_dsc, estdloc.location_dsc as dest_location_dsc
			FROM	t_cargo c
				INNER JOIN t_booking bk						ON bk.booking_id = c.booking_id
				INNER JOIN r_location plor					ON plor.location_cd = bk.plor_location_cd
				INNER JOIN r_location pol					ON pol.location_cd = bk.pol_location_cd
				INNER JOIN r_location pod					ON pod.location_cd = bk.pod_location_cd
				INNER JOIN r_location plod					ON plod.location_cd = bk.plod_location_cd
				INNER JOIN r_vessel ves						ON ves.vessel_cd = bk.vessel_cd
				LEFT OUTER JOIN t_cargo_activity ca
					INNER JOIN t_estimate_charge_dtl edt	ON edt.cargo_activity_id = ca.cargo_activity_id
					INNER JOIN t_estimate_charge echg		ON echg.estimate_charge_id = edt.estimate_charge_id
					INNER JOIN t_estimate est				ON est.estimate_id = echg.estimate_id
					INNER JOIN r_location estoloc			ON estoloc.location_cd = est.orig_location_cd
					INNER JOIN r_location estdloc			ON estdloc.location_cd = est.dest_location_cd
					INNER JOIN r_charge_type cht			ON cht.charge_type_cd = echg.charge_type_cd
					INNER JOIN r_level_unit lvu				ON lvu.level_unit_id = echg.level_unit_id
					INNER JOIN r_unit_type ut				ON ut.unit_type_cd = lvu.unit_type_cd
															ON ca.cargo_id = c.cargo_id
				LEFT OUTER JOIN r_customer cust				ON cust.customer_cd = bk.customer_cd
				LEFT OUTER JOIN t_contract_mod cmod 		ON cmod.contract_mod_id = c.contract_mod_id
			WHERE	1 = 1 ");

			List<DbParameter> p = new List<DbParameter>();
			AppendWhereExisting(cp, sb, p, false);

			sb.Append(@"
			order by bk.booking_no, c.serial_no, est.estimate_no, cht.charge_type_dsc ");

			DataTable dt = Connection.GetDataTable(sb.ToString(), p.ToArray());
			if (dt != null)
			{
				dt.TableName = "CargoCharges";
			}
			return dt;
		}

		private static void AppendWhereExisting(clsCargoParameters cp, StringBuilder sb,
			List<DbParameter> p, bool isParent)
		{
			Connection.AppendLikeClause(sb, p, "AND",
				"bk.voyage_no", "@VOY_NO", cp.VOYAGE_NO);
			Connection.AppendLikeClause(sb, p, "AND",
				"bk.customer_ref", "@PCFN", cp.CUSTOMER_REF);
			Connection.AppendLikeClause(sb, p, "AND",
				"bk.booking_no", "@BK_NO", cp.BOOKING_NO);
			Connection.AppendLikeClause(sb, p, "AND",
				"bk.bol_no", "@BL_NO", cp.BOL_NO);
			Connection.AppendLikeClause(sb, p, "AND",
				"bk.booking_ref", "@BK_REF", cp.BOOKING_REF);
			Connection.AppendLikeClause(sb, p, "AND",
				"bk.edi_ref", "@ED_REF", cp.EDI_REF);
			//Connection.AppendInClause(sb, p, "AND",
			//    "bk.customer_ref", "@PCSV", ClsConvert.AddQuotes(cp.csvPCFN));
			//Connection.AppendInClause(sb, p, "AND",
			//    "bk.booking_no", "@BK_CSV", ClsConvert.AddQuotes(cp.csvBooking));
			Connection.AppendInClause(sb, p, "AND",
				"bk.plor_location_cd", "@PLOR_CD", ClsConvert.AddQuotes(cp.PLOR));
			Connection.AppendInClause(sb, p, "AND",
				"bk.pol_location_cd", "@POL_CD", ClsConvert.AddQuotes(cp.POL));
			Connection.AppendInClause(sb, p, "AND",
				"bk.pod_location_cd", "@POD_CD", ClsConvert.AddQuotes(cp.POD));
			Connection.AppendInClause(sb, p, "AND",
				"bk.plod_location_cd", "@PLOD_CD", ClsConvert.AddQuotes(cp.PLOD));

			Connection.AppendInClause(sb, p, "AND",
				"c.move_type_cd", "@MV_TP", ClsConvert.AddQuotes(cp.MOVE_TYPE_CD));
			Connection.AppendLikeClause(sb, p, "AND",
				"c.serial_no", "@SER_NO", cp.SERIAL_NO);

			Connection.AppendInClause(sb, p, "AND",
				"bk.vessel_cd", "@VES_CD", ClsConvert.AddQuotes(cp.VESSEL_CD));
			Connection.AppendDateClause(sb, p, "AND",
				"bk.sail_dt", "@SAIL_FR", "@SAIL_TO", cp.Sail_Dt);
		}
	}

	public class clsCargoParameters
	{

		private string _SERIAL_NO;

		public string SERIAL_NO 
		{ 
			get
			{
				return _SERIAL_NO;
			}
			
			set
			{
				_SERIAL_NO = value;
			}
		}

		private string _MOVE_TYPE_CD;

		public string MOVE_TYPE_CD 
		{ 
			get
			{
				return _MOVE_TYPE_CD;
			}
			
			set
			{
				_MOVE_TYPE_CD = value;
			}
		}


		private string _PLOR;

		public string PLOR 
		{ 
			get
			{
				return _PLOR;
			}
			
			set
			{
				_PLOR = value;
			}
		}


		private string _POL;

		public string POL 
		{ 
			get
			{
				return _POL;
			}
			
			set
			{
				_POL = value;
			}
		}

		private string _POD;

		public string POD 
		{ 
			get
			{
				return _POD;
			}
			
			set
			{
				_POD = value;
			}
		}


		private string _PLOD;

		public string PLOD 
		{ 
			get
			{
				return _PLOD;
			}
			
			set
			{
				_PLOD = value;
			}
		}


		private string _BOOKING_NO;

		public string BOOKING_NO 
		{ 
			get
			{
				return _BOOKING_NO;
			}
			
			set
			{
				_BOOKING_NO = value;
			}
		}

		private string _BOOKING_REF;

		public string BOOKING_REF 
		{ 
			get
			{
				return _BOOKING_REF;
			}
			
			set
			{
				_BOOKING_REF = value;
			}
		}


		private string _BOL_NO;

		public string BOL_NO 
		{ 
			get
			{
				return _BOL_NO;
			}
			
			set
			{
				_BOL_NO = value;
			}
		}

		private string _EDI_REF;

		public string EDI_REF 
		{ 
			get
			{
				return _EDI_REF;
			}
			
			set
			{
				_EDI_REF = value;
			}
		}

		private string _CUSTOMER_REF;

		public string CUSTOMER_REF 
		{ 
			get
			{
				return _CUSTOMER_REF;
			}
			
			set
			{
				_CUSTOMER_REF = value;
			}
		}


		private string _VESSEL_CD;

		public string VESSEL_CD 
		{ 
			get
			{
				return _VESSEL_CD;
			}
			
			set
			{
				_VESSEL_CD = value;
			}
		}


		private string _VOYAGE_NO;

		public string VOYAGE_NO 
		{ 
			get
			{
				return _VOYAGE_NO;
			}
			
			set
			{
				_VOYAGE_NO = value;
			}
		}

		public DateRange Sail_Dt { get; set; }
	}
	
}
