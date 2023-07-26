using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace ASL.ARC.EDISQLTools
{
	public class ClsVinMatch
	{
		public static ClsConnection cnLINE
		{
			get { return ClsConMgr.Manager["LINE"]; }
		}

		public static ClsConnection cnCLASS
		{
			get { return ClsConMgr.Manager["CLASS"]; }
		}

		public static ClsConnection cnArcSys
		{
			get { return ClsConMgr.Manager["ArcSys"]; }
		}

		public static DataTable GetLineVins(VinParameters vps)
		{
			StringBuilder sb = new StringBuilder(@"
			SELECT	ltrim(rtrim(dba.car_head.CR1_VIN)) AS VIN,
					ltrim(rtrim(dba.car_head.cr1_bunr)) AS booking_no,
					ltrim(rtrim(dba.car_head.cr1_voyage)) as voyage,
					ltrim(rtrim(dba.car_head.cr1_vessel)) as vessel,
					ltrim(rtrim(dba.car_head.cr1_manufacturer)) as manufacturer,
					ltrim(rtrim(dba.car_head.cr1_modelname)) as modelname,
					ltrim(rtrim(dba.car_head.cr1_desofg)) as yr_make_model,
					dba.car_head.cr1_length, dba.car_head.cr1_width, dba.car_head.cr1_height,
					dba.car_head.cr1_weight,
					ltrim(rtrim(dba.car_head.cr1_polcde)) as POL,
					ltrim(rtrim(dba.car_head.cr1_podcde)) as POD,
					ltrim(rtrim(dba.car_head.cr1_blnr)) as bol_no,
					dba.car_head.cr1_buitem, dba.car_head.cr1_buitem_seqno,
					dba.car_head.cr1_blitem_seqno,
					RIGHT('000' + CONVERT(varchar(3), dba.car_head.cr1_buitem), 3) + ' ' +
					RIGHT('000' + CONVERT(varchar(3), dba.car_head.cr1_buitem_seqno), 3) AS item_link,
					dba.car_head.cr1_create_date, dba.car_head.cr1_change_date,
					ltrim(rtrim(dba.car_head.cr1_create_user)) as cr1_create_user,
					ltrim(rtrim(dba.car_head.cr1_change_user)) as cr1_change_user,
					ltrim(rtrim(dba.car_head.cr1_ublstatus)) as cr1_ublstatus,
					ltrim(rtrim(dba.car_head.cr1_ecstatus)) as cr1_ecstatus,
					ltrim(rtrim(dba.car_head.cr1_ecstatususer)) as cr1_ecstatususer,
					dba.car_head.cr1_ecstatusdatetime,
					ltrim(rtrim(dba.car_head.cr1_ecncrn)) as cr1_ecncrn,
					dba.car_head.cr1_cargorecvdate, 0 as diff_status,
                    dba.car_head.cr1_type, dba.car_head.firma, dba.car_head.cr1_manr,
					0 as vehicle_id, '' as class_vin, 0 as vin_mapped,
					ltrim(rtrim(dba.bu1_kopf.bu1ediref)) as bu1ediref
			FROM	dba.car_head
					left outer join dba.bu1_kopf ON dba.car_head.cr1_bumanr = dba.bu1_kopf.bu1bumanr
			WHERE	dba.car_head.cr1_vin is not null ");

			List<DbParameter> p = new List<DbParameter>();
			AppendhereLINE(sb, p, vps);

			sb.Append("ORDER BY cr1_bunr, CR1_VIN");
			return cnLINE.GetDataTable(sb.ToString(), p.ToArray());
		}

		public static void AppendhereLINE(StringBuilder sb, List<DbParameter> p,
			VinParameters vps)
		{
			cnLINE.AppendLikeClause(sb, p, "AND",
				"ltrim(rtrim(CR1_VIN))", "@VN_NO", vps.VIN);

			cnLINE.AppendDateClauseSqlServer(sb, p, "AND",
				"cr1_create_date", "@CR_FR", "@CR_TO", vps.Create_Dt);
			cnLINE.AppendDateClauseSqlServer(sb, p, "AND",
				"cr1_change_date", "@MD_FR", "@MD_TO", vps.Modify_Dt);
			cnLINE.AppendDateClauseSqlServer(sb, p, "AND",
				"cr1_ecstatusdatetime", "@EC_FR", "@EC_TO", vps.EC_Status_Dt);
			cnLINE.AppendDateClauseSqlServer(sb, p, "AND",
				"cr1_cargorecvdate", "@CRG_FR", "@CRG_TO", vps.Cargo_Rcvd_Dt);

			cnLINE.AppendInOrLike(sb, p, "AND",
				"ltrim(rtrim(cr1_bunr))", "@BU_NO", vps.Booking_No);
			cnLINE.AppendInOrLike(sb, p, "AND",
				"ltrim(rtrim(cr1_blnr))", "@BU_NO", vps.Bol_No);
			cnLINE.AppendInOrLike(sb, p, "AND",
				"ltrim(rtrim(cr1_vessel))", "@VESS", vps.Vessel);
			cnLINE.AppendInOrLike(sb, p, "AND",
				"ltrim(rtrim(cr1_voyage))", "@VOY_NO", vps.Voyage);
			cnLINE.AppendInOrLike(sb, p, "AND",
				"ltrim(rtrim(cr1_polcde))", "@PL_CD", vps.POL_CDs);
			cnLINE.AppendInOrLike(sb, p, "AND",
				"ltrim(rtrim(cr1_podcde))", "@PD_CD", vps.POD_CDs);

			if (vps.OnlyAAL)
				cnLINE.AppendInOrLike(sb, p, "AND", "ltrim(rtrim(bu1ediref))", "@ED_RF", "A%");
		}
		
		public static DataTable GetClassVins(VinParameters vps)
		{
			StringBuilder sb = new StringBuilder(@"
			SELECT	oa.order_activity_id, o.order_id, o.order_no, bol.bol_no,
					pov.vehicle_id, pov.vin, pov.vehicle_length, pov.vehicle_width,
					pov.vehicle_height, pov.vehicle_weight, pov.vehicle_year, pov.vehicle_make,
					pov.vehicle_model, pov.vehicle_cube_ft, pov.vehicle_m_tons,
					pov.cargo_dimension_cd, bk.booking_id, bk.booking_no, bk.vessel_cd,
					bk.voyage_no, bk.pol_location_cd, bk.pod_location_cd,
					oc.location_cd as curr_location_cd, oc.order_activity_id as curr_act_id,
					0 as diff_status, 0 as vin_mapped
			FROM	t_vehicle pov
				INNER  JOIN t_master_order mo			ON mo.vehicle_id = pov.vehicle_id
				INNER JOIN t_order o					ON o.master_order_id = mo.master_order_id
				INNER JOIN t_order_current oc			ON oc.order_id = o.order_id
				INNER JOIN t_order_activity oa			ON (oa.order_id = o.order_id AND
															oa.order_activity_type_cd = 'OCEAN' AND
															oa.active_flg = 'Y')
				LEFT OUTER JOIN t_booking_detail bkd
					INNER JOIN t_booking bk				ON bk.booking_id = bkd.booking_id
														ON bkd.booking_detail_id = oa.booking_detail_id
				LEFT OUTER JOIN t_bol bol				ON bol.bol_id = oa.bol_id");

			sb.Append(" WHERE	1 = 1");

			List<DbParameter> p = new List<DbParameter>();
			AppendWhereCLASS(sb, p, vps);

			sb.Append("ORDER BY bk.booking_no, pov.vin");
			return cnCLASS.GetDataTable(sb.ToString(), p.ToArray());
		}

		public static void AppendWhereCLASS(StringBuilder sb, List<DbParameter> p,
			VinParameters vps)
		{
			cnCLASS.AppendLikeClause(sb, p, "AND",
				"pov.vin", "@VN_NO", vps.VIN);

			cnCLASS.AppendInOrLike(sb, p, "AND",
				"bk.booking_no", "@BU_NO", vps.Booking_No);

			cnCLASS.AppendInOrLike(sb, p, "AND",
				"bol.bol_no", "@BU_NO", vps.Bol_No);
			cnCLASS.AppendInOrLike(sb, p, "AND",
				"bk.vessel_cd", "@VESS", vps.Vessel);
			cnCLASS.AppendInOrLike(sb, p, "AND",
				"bk.voyage_no", "@VOY_NO", vps.Voyage);
			cnCLASS.AppendInOrLike(sb, p, "AND",
				"bk.pol_location_cd", "@PL_CD", vps.POL_CDs);
			cnCLASS.AppendInOrLike(sb, p, "AND",
				"bk.pod_location_cd", "@PD_CD", vps.POD_CDs);

			if (vps.AtPort)
			{
				sb.Append(@" AND
				(oc.location_cd = bk.pol_location_cd AND
				oc.order_activity_id = oa.order_activity_id) ");
			}
		}

		public static DataTable GetIALVins(VinParameters vps)
		{
			StringBuilder sb = new StringBuilder(@"
			SELECT si.edi_inbound_si_id, 
					si.vin, si.booking_no, si.processed_flg,
					0 as diff_status, 0 as vin_mapped
			FROM	t_edi_inbound_si si");

			sb.Append(" WHERE	1 = 1");

			List<DbParameter> p = new List<DbParameter>();
			AppendWhereIAL(sb, p, vps);

			sb.Append("ORDER BY si.booking_no, si.vin");
			return cnArcSys.GetDataTable(sb.ToString(), p.ToArray());
		}

		public static void AppendWhereIAL(StringBuilder sb, List<DbParameter> p,
			VinParameters vps)
		{
			cnArcSys.AppendLikeClause(sb, p, "AND",
				"si.vin", "@VN_NO", vps.VIN);

			cnArcSys.AppendInOrLike(sb, p, "AND",
				"si.booking_no", "@BU_NO", vps.Booking_No);

		}


		public void UpdateSql(ClsConnection cn, DataRow drLINE, string sBookingNo, string sNewVIN )
		{
			string IAL_VIN = drLINE["vin"].ToString();
			string Manr_cd = drLINE["cr1_manr"].ToString();
			int? iManr_cd = ClsConvert.ToInt32Nullable(Manr_cd);
			List<DbParameter> p = new List<DbParameter>();
			StringBuilder sb = new StringBuilder();
			sb.AppendFormat(@"
			update	dba.car_head
			set		cr1_vin = @CL_NW_VIN
			where	firma = @FRM_CD and
					cr1_manr = @MANR_CD and
					ltrim(rtrim(cr1_bunr)) = @BK_NO and
					ltrim(rtrim(CR1_VIN)) = @LN_OLD_VIN ");

			p.Add(cn.GetParameter("@CL_NW_VIN", sNewVIN));
			p.Add(cn.GetParameter("@FRM_CD", "ARC"));
			p.Add(cn.GetParameter("@MANR_CD", iManr_cd.GetValueOrDefault()));
			p.Add(cn.GetParameter("@BK_NO", sBookingNo));
			p.Add(cn.GetParameter("@LN_OLD_VIN", IAL_VIN));
		}
		#region VIN Parameters

		public class VinParameters
		{
			public string VIN;

			public DateRange Create_Dt;
			public DateRange Modify_Dt;
			public DateRange EC_Status_Dt;
			public DateRange Cargo_Rcvd_Dt;

			public string Booking_No;
			public string Bol_No;
			public string Vessel;
			public string Voyage;
			public string POL_CDs;
			public string POD_CDs;

			public bool AtPort;
			public bool OnlyAAL;

			public VinParameters()
			{
				Clear();
			}

			public void Clear()
			{
				AtPort = true;			// Default set to true
				OnlyAAL = true;			// Default set to true

				Create_Dt.Clear();
				Modify_Dt.Clear();
				EC_Status_Dt.Clear();
				Cargo_Rcvd_Dt.Clear();

				VIN = Booking_No = Bol_No = Vessel = Voyage = POL_CDs = POD_CDs = null;
			}

			public bool NoneSelected
			{
				get
				{
					return string.IsNullOrEmpty(Booking_No) && string.IsNullOrEmpty(Bol_No) &&
						string.IsNullOrEmpty(VIN) && string.IsNullOrEmpty(Voyage);
				}
			}
		}
		#endregion		// #region VIN Parameters

	}
}