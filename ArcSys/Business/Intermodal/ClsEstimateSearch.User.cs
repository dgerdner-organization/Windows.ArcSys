using System;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;
using System.Text;

namespace CS2010.ArcSys.Business
{
	public class ClsEstimateSearch
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

		public string Customer_CDs;
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

		public string Payable_Flg;
		public string Billable_Flg;
		public bool IncludeNonBillPay;
		public bool IncludeBlankTCNs;
		public bool IncludeTransShip;

        public bool RegionAll;
        public bool RegionConus;
        public bool RegionOConus;

		public DataTable dtCargoErrors;

		#endregion		// #region Fields

		#region Constructors/Initialization

		public ClsEstimateSearch()
		{
			Clear();
		}

		public ClsEstimateSearch(ClsEstimateSearch aSearch)
		{
			Clear();
			CopyFrom(aSearch);
		}

		public void CopyFrom(ClsEstimateSearch aSearch)
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
			Customer_CDs = aSearch.Customer_CDs;
			PLOR_CDs = aSearch.PLOR_CDs;
			POL_CDs = aSearch.POL_CDs;
			POD_CDs = aSearch.POD_CDs;
			PLOD_CDs = aSearch.PLOD_CDs;
			Act_Orig_CDs = aSearch.Act_Orig_CDs;
			Act_Dest_CDs = aSearch.Act_Dest_CDs;
			Serial_No = aSearch.Serial_No;
			Payable_Flg = aSearch.Payable_Flg;
			Billable_Flg = aSearch.Billable_Flg;
			IncludeNonBillPay = aSearch.IncludeNonBillPay;
			IncludeBlankTCNs = aSearch.IncludeBlankTCNs;
			IncludeTransShip = aSearch.IncludeTransShip;

			ETD = aSearch.ETD;
			RDD = aSearch.RDD;
			Created = aSearch.Created;
			Modified = aSearch.Modified;
			Vessel_Sail_Dt = aSearch.Vessel_Sail_Dt;

            RegionAll = aSearch.RegionAll;
            RegionConus = aSearch.RegionConus;
            RegionOConus = aSearch.RegionOConus;

		}

		public void Clear()
		{
			Booking_No = PCFN = csvPCFN = csvBooking = Vessel = VoyageNo = StatusCDs =
				MoveTypeCDs = POL_CDs = POD_CDs = PLOR_CDs = PLOD_CDs = Act_Orig_CDs =
				Act_Dest_CDs = Serial_No = Estimate_No = csvEstimateID = Payable_Flg =
				Billable_Flg = Customer_CDs = null;

			IncludeNonDoor = IncludeNonBillPay = IncludeBlankTCNs = IncludeTransShip = false;
			Estimate_ID = null;

            RegionConus = RegionOConus = true;

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
			if (!string.IsNullOrEmpty(Customer_CDs)) sb.AppendFormat(" Customer {0} ", Customer_CDs);
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

			if (!string.IsNullOrEmpty(Billable_Flg)) sb.AppendFormat(" Billable {0} ", Billable_Flg);
			if (!string.IsNullOrEmpty(Payable_Flg)) sb.AppendFormat(" Payable {0} ", Payable_Flg);
			if (IncludeNonBillPay) sb.Append(" Including Non-Billable/Payable ");
			if (IncludeBlankTCNs) sb.Append(" Including Blank TCNs ");
			if (IncludeTransShip) sb.Append(" Including TransShipment Final Leg ");

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

		#region Search Available Methods

		public DataSet SearchAvailableDS()
		{
			DataSet ds = new DataSet();

			DataTable dtEstimates = SearchAvailableGroups();
			ds.Tables.Add(dtEstimates);

			if (dtEstimates.Rows.Count > 0)
			{
				DataTable dtActivity = SearchAvailableActivities();
				ds.Tables.Add(dtActivity);

				DataColumn[] dcPK = new DataColumn[4];
				dcPK[0] = dtEstimates.Columns["BK_VOYAGE_NO"];
				dcPK[1] = dtEstimates.Columns["ORIG_LOCATION_CD"];
				dcPK[2] = dtEstimates.Columns["DEST_LOCATION_CD"];
				dcPK[3] = dtEstimates.Columns["SAIL_DT"];

				DataColumn[] dcFK = new DataColumn[4];
				dcFK[0] = dtActivity.Columns["BK_VOYAGE_NO"];
				dcFK[1] = dtActivity.Columns["ORIG_LOCATION_CD"];
				dcFK[2] = dtActivity.Columns["DEST_LOCATION_CD"];
				dcFK[3] = dtActivity.Columns["SAIL_DT"];

				ds.Relations.Add("EstimateActivities", dcPK, dcFK, false);
			}

			return ds;
		}

		public DataTable SearchAvailableGroups()
		{
			/*
					decode(ca.orig_location_cd, bk.plor_location_cd, 'DOOR TO PORT',
						bk.pod_location_cd, 'PORT TO DOOR', 'UNKNOWN') as direction_txt,
			*/
			List<DbParameter> p = new List<DbParameter>();
			StringBuilder sb = new StringBuilder(@"
			select	bk.voyage_no as bk_voyage_no, bk.sail_dt,
					ca.orig_location_cd, ca.dest_location_cd,
					oloc.location_dsc as orig_location_dsc,
					dloc.location_dsc as dest_location_dsc,
					decode(oloc.conus_flg, 'Y', 'CONUS', 'N', 'OCONUS', '?') as conus_txt,
					DECODE(oloc.location_type_cd, 'LAND', 'DOOR', 'PORT', 'PORT', 'UNKNOWN') ||
						' TO ' || DECODE(dloc.location_type_cd, 'LAND', 'DOOR', 'PORT', 'PORT',
						'UNKNOWN') as direction_txt,
					count(ca.cargo_activity_id) as act_count,
					case
						when
							(	select	count(est.estimate_id)
								from	t_estimate est
								where	est.voyage_no = bk.voyage_no and
										est.orig_location_cd = ca.orig_location_cd and
										est.dest_location_cd = ca.dest_location_cd) > 0
							then 'Y'
						else	'N'
					end as exists_flg
			from	t_cargo_activity ca
					INNER JOIN t_cargo c		on c.cargo_id = ca.cargo_id
					INNER JOIN t_booking bk		on bk.booking_id = c.booking_id
					INNER JOIN r_location oloc	on oloc.location_cd = ca.orig_location_cd
					INNER JOIN r_location dloc	on dloc.location_cd = ca.dest_location_cd
			left outer join v_trans_booking tbk on tbk.booking_no = bk.booking_no
		where ca.estimate_id is null ");

			AppendWhereAvailable(sb, p);

			sb.Append(@"
			group by	bk.voyage_no, bk.sail_dt, ca.orig_location_cd, ca.dest_location_cd,
						oloc.location_dsc, dloc.location_dsc,
						decode(oloc.conus_flg, 'Y', 'CONUS', 'N', 'OCONUS', '?'),
						DECODE(oloc.location_type_cd, 'LAND', 'DOOR', 'PORT', 'PORT', 'UNKNOWN') ||
							' TO ' || DECODE(dloc.location_type_cd, 'LAND', 'DOOR', 'PORT', 'PORT',
							'UNKNOWN')
			order by	bk.voyage_no, direction_txt,
						ca.orig_location_cd, ca.dest_location_cd ");

			string sql = sb.ToString();
			DataTable dt = Connection.GetDataTable(sql, p.ToArray());
			if (dt != null) dt.TableName = "Estimate";
			return dt;
		}

		public DataTable SearchAvailableActivities()
		{
			/*
					decode(ca.orig_location_cd, bk.plor_location_cd, 'DOOR TO PORT',
						bk.pod_location_cd, 'PORT TO DOOR', 'UNKNOWN') as direction_txt
			*/
			List<DbParameter> p = new List<DbParameter>();
			StringBuilder sb = new StringBuilder(@"
			SELECT	ca.*,
					oloc.location_dsc as orig_location_dsc, dloc.location_dsc as dest_location_dsc,
					c.booking_id, c.item_no, c.serial_no, c.commodity_cd, c.pkg_type_cd,
					c.length_nbr, c.width_nbr, c.height_nbr, c.weight_nbr, c.move_type_cd,
					c.cargo_dsc, c.container_no, c.seal1, c.seal2, c.seal3, c.vessel_load_dt,
					c.cargo_key, bk.booking_no, bk.booking_ref,
					bk.plor_location_cd, bk.pol_location_cd, bk.pod_location_cd,
					bk.plod_location_cd, plor.location_dsc AS plor_location_dsc,
					pol.location_dsc AS pol_location_dsc, pod.location_dsc AS pod_location_dsc,
					plod.location_dsc AS plod_location_dsc, bk.bol_no, bk.edi_ref, bk.customer_ref,
					bk.vessel_cd, ves.vessel_nm, bk.voyage_no as bk_voyage_no, bk.sail_dt,
					bk.delivery_txt, bk.cargo_notes_txt, bk.customer_cd, bk.match_cd, cust.customer_nm,
					c.length_nbr || ' x ' || c.width_nbr || ' x ' || c.height_nbr as len_wid_hgt,
					decode(oloc.conus_flg, 'Y', 'CONUS', 'N', 'OCONUS', '?') as conus_txt,
					DECODE(oloc.location_type_cd, 'LAND', 'DOOR', 'PORT', 'PORT', 'UNKNOWN') ||
						' TO ' || DECODE(dloc.location_type_cd, 'LAND', 'DOOR', 'PORT', 'PORT',
						'UNKNOWN') as direction_txt,
					tbk.leg_type, tbk.linked_booking_no
			FROM	t_cargo_activity ca
					INNER JOIN t_cargo c			ON c.cargo_id = ca.cargo_id
					INNER JOIN t_booking bk			ON bk.booking_id = c.booking_id
					INNER JOIN r_location oloc		ON oloc.location_cd = ca.orig_location_cd
					INNER JOIN r_location dloc		ON dloc.location_cd = ca.dest_location_cd
					INNER JOIN r_location plor		ON plor.location_cd = bk.plor_location_cd
					INNER JOIN r_location pol		ON pol.location_cd = bk.pol_location_cd
					INNER JOIN r_location pod		ON pod.location_cd = bk.pod_location_cd
					INNER JOIN r_location plod		ON plod.location_cd = bk.plod_location_cd
					INNER JOIN r_vessel ves			ON ves.vessel_cd = bk.vessel_cd
					LEFT OUTER JOIN r_customer cust	ON cust.customer_cd = bk.customer_cd
				  left outer join v_trans_booking tbk on tbk.booking_no = bk.booking_no
			WHERE ca.estimate_id is null ");
			AppendWhereAvailable(sb, p);

			sb.Append(@"
			order by	bk.voyage_no, direction_txt, bk.booking_no,
						ca.orig_location_cd, ca.dest_location_cd, c.cargo_dsc, c.item_no, c.serial_no ");

			string sql = sb.ToString();
			DataTable dt = Connection.GetDataTable(sql, p.ToArray());
			if (dt != null)
			{
				dt.TableName = "Activities";
				//dt.Columns.Add("Cubic_Ft", typeof(int), "(length_nbr * width_nbr * height_nbr) / 1728");
				//dt.Columns.Add("M_Tons", typeof(int), "(length_nbr * width_nbr * height_nbr) / 1728 / 40");
			}
			return dt;
		}
		public DataTable SearchAvailableActivitiesOLD()
		{
			/*
					decode(ca.orig_location_cd, bk.plor_location_cd, 'DOOR TO PORT',
						bk.pod_location_cd, 'PORT TO DOOR', 'UNKNOWN') as direction_txt
			*/
			List<DbParameter> p = new List<DbParameter>();
			StringBuilder sb = new StringBuilder(@"
			SELECT	ca.*,
					oloc.location_dsc as orig_location_dsc, dloc.location_dsc as dest_location_dsc,
					c.booking_id, c.item_no, c.serial_no, c.commodity_cd, c.pkg_type_cd,
					c.length_nbr, c.width_nbr, c.height_nbr, c.weight_nbr, c.move_type_cd,
					c.cargo_dsc, c.container_no, c.seal1, c.seal2, c.seal3, c.vessel_load_dt,
					c.cargo_key, bk.booking_no, bk.booking_ref,
					bk.plor_location_cd, bk.pol_location_cd, bk.pod_location_cd,
					bk.plod_location_cd, plor.location_dsc AS plor_location_dsc,
					pol.location_dsc AS pol_location_dsc, pod.location_dsc AS pod_location_dsc,
					plod.location_dsc AS plod_location_dsc, bk.bol_no, bk.edi_ref, bk.customer_ref,
					bk.vessel_cd, ves.vessel_nm, bk.voyage_no as bk_voyage_no, bk.sail_dt,
					bk.delivery_txt, bk.cargo_notes_txt, bk.customer_cd, bk.match_cd, cust.customer_nm,
					c.length_nbr || ' x ' || c.width_nbr || ' x ' || c.height_nbr as len_wid_hgt,
					decode(oloc.conus_flg, 'Y', 'CONUS', 'N', 'OCONUS', '?') as conus_txt,
					DECODE(oloc.location_type_cd, 'LAND', 'DOOR', 'PORT', 'PORT', 'UNKNOWN') ||
						' TO ' || DECODE(dloc.location_type_cd, 'LAND', 'DOOR', 'PORT', 'PORT',
						'UNKNOWN') as direction_txt,
					(SELECT	MIN(vts.leg_type)
					FROM	v_trans_booking vts
					WHERE	vts.booking_no = bk.booking_no) AS trans_leg,
					(SELECT	MIN(vts.linked_booking_no)
					FROM	v_trans_booking vts
					WHERE	vts.booking_no = bk.booking_no) AS linked_booking_no
			FROM	t_cargo_activity ca
					INNER JOIN t_cargo c			ON c.cargo_id = ca.cargo_id
					INNER JOIN t_booking bk			ON bk.booking_id = c.booking_id
					INNER JOIN r_location oloc		ON oloc.location_cd = ca.orig_location_cd
					INNER JOIN r_location dloc		ON dloc.location_cd = ca.dest_location_cd
					INNER JOIN r_location plor		ON plor.location_cd = bk.plor_location_cd
					INNER JOIN r_location pol		ON pol.location_cd = bk.pol_location_cd
					INNER JOIN r_location pod		ON pod.location_cd = bk.pod_location_cd
					INNER JOIN r_location plod		ON plod.location_cd = bk.plod_location_cd
					INNER JOIN r_vessel ves			ON ves.vessel_cd = bk.vessel_cd
					LEFT OUTER JOIN r_customer cust	ON cust.customer_cd = bk.customer_cd
			WHERE ca.estimate_id is null ");
			AppendWhereAvailable(sb, p);

			sb.Append(@"
			order by	bk.voyage_no, direction_txt, bk.booking_no,
						ca.orig_location_cd, ca.dest_location_cd, c.cargo_dsc, c.item_no, c.serial_no ");

			DataTable dt = Connection.GetDataTable(sb.ToString(), p.ToArray());
			if (dt != null)
			{
				dt.TableName = "Activities";
				//dt.Columns.Add("Cubic_Ft", typeof(int), "(length_nbr * width_nbr * height_nbr) / 1728");
				//dt.Columns.Add("M_Tons", typeof(int), "(length_nbr * width_nbr * height_nbr) / 1728 / 40");
			}
			return dt;
		}
		public void AppendWhereAvailable(StringBuilder sb, List<DbParameter> p)
		{
			Connection.AppendLikeClause(sb, p, "AND",
				"bk.customer_ref", "@PCFN", PCFN);
			Connection.AppendLikeClause(sb, p, "AND",
				"bk.booking_no", "@BK_NO", Booking_No);
			Connection.AppendInClause(sb, p, "AND",
				"bk.customer_ref", "@PCSV", ClsConvert.AddQuotes(csvPCFN));
			Connection.AppendInClause(sb, p, "AND",
				"bk.booking_no", "@BK_CSV", ClsConvert.AddQuotes(csvBooking));
			Connection.AppendDateClause(sb, p, "AND",
				"bk.sail_dt", "@SAIL_FR", "@SAIL_TO", Vessel_Sail_Dt);

			Connection.AppendInClause(sb, p, "AND",
				"bk.customer_cd", "@CUST_CD", ClsConvert.AddQuotes(Customer_CDs));
			Connection.AppendInClause(sb, p, "AND",
				"bk.plor_location_cd", "@PLOR_CD", ClsConvert.AddQuotes(PLOR_CDs));
			Connection.AppendInClause(sb, p, "AND",
				"bk.pol_location_cd", "@POL_CD", ClsConvert.AddQuotes(POL_CDs));
			Connection.AppendInClause(sb, p, "AND",
				"bk.pod_location_cd", "@POD_CD", ClsConvert.AddQuotes(POD_CDs));
			Connection.AppendInClause(sb, p, "AND",
				"bk.plod_location_cd", "@PLOD_CD", ClsConvert.AddQuotes(PLOD_CDs));

			Connection.AppendInClause(sb, p, "AND",
				"ca.orig_location_cd", "@ACT_ORIG_CD", ClsConvert.AddQuotes(Act_Orig_CDs));
			Connection.AppendInClause(sb, p, "AND",
				"ca.dest_location_cd", "@ACT_DEST_CD", ClsConvert.AddQuotes(Act_Dest_CDs));

			//Connection.AppendInClause(sb, p, "AND",
			//				"v.acms_status_cd", "@AC_ST", ClsConvert.AddQuotes(StatusCDs));

			if (IncludeNonBillPay == false)
			{
				sb.Append(@"
				AND (ca.billable_flg = 'Y' OR ca.payable_flg = 'Y') ");
			}

			if (IncludeBlankTCNs == false)
			{
				sb.Append(@"
				AND c.serial_no IS NOT NULL ");
			}

			if (IncludeNonDoor == false)
			{
				Connection.AppendNotInClause(sb, p, "AND", "c.move_type_cd", "@EX_MV_TY", "'F1', 'F2', 'F3', 'F4'");
			}

			Connection.AppendInClause(sb, p, "AND",
				"c.move_type_cd", "@MV_TP", ClsConvert.AddQuotes(MoveTypeCDs));

			Connection.AppendLikeClause(sb, p, "AND",
				"c.serial_no", "@SER_NO", Serial_No);


			//Connection.AppendDateClause(sb, p, "AND",
			//				"nvl(v.poe_atd, v.poe_etd)", "@ET_FR", "@ET_TO", ETD);
			//Connection.AppendDateClause(sb, p, "AND", "v.adj_rdd_dt", "@RD_FR", "@RD_TO", RDD);

			Connection.AppendInClause(sb, p, "AND",
				"bk.vessel_cd", "@VES_CD", ClsConvert.AddQuotes(Vessel));
			Connection.AppendLikeClause(sb, p, "AND",
				"bk.voyage_no", "@VOY_NO", VoyageNo);

			sb.AppendFormat(@"
				and (leg_type is null or (leg_type like 'First%' and io_ind = 'I') or (leg_type like 'Final%' and io_ind = 'O'))");
		}
		public void AppendWhereAvailableOLD(StringBuilder sb, List<DbParameter> p)
		{
			Connection.AppendLikeClause(sb, p, "AND",
				"bk.customer_ref", "@PCFN", PCFN);
			Connection.AppendLikeClause(sb, p, "AND",
				"bk.booking_no", "@BK_NO", Booking_No);
			Connection.AppendInClause(sb, p, "AND",
				"bk.customer_ref", "@PCSV", ClsConvert.AddQuotes(csvPCFN));
			Connection.AppendInClause(sb, p, "AND",
				"bk.booking_no", "@BK_CSV", ClsConvert.AddQuotes(csvBooking));
			Connection.AppendDateClause(sb, p, "AND",
				"bk.sail_dt", "@SAIL_FR", "@SAIL_TO", Vessel_Sail_Dt);

			Connection.AppendInClause(sb, p, "AND",
				"bk.customer_cd", "@CUST_CD", ClsConvert.AddQuotes(Customer_CDs));
			Connection.AppendInClause(sb, p, "AND",
				"bk.plor_location_cd", "@PLOR_CD", ClsConvert.AddQuotes(PLOR_CDs));
			Connection.AppendInClause(sb, p, "AND",
				"bk.pol_location_cd", "@POL_CD", ClsConvert.AddQuotes(POL_CDs));
			Connection.AppendInClause(sb, p, "AND",
				"bk.pod_location_cd", "@POD_CD", ClsConvert.AddQuotes(POD_CDs));
			Connection.AppendInClause(sb, p, "AND",
				"bk.plod_location_cd", "@PLOD_CD", ClsConvert.AddQuotes(PLOD_CDs));

			Connection.AppendInClause(sb, p, "AND",
				"ca.orig_location_cd", "@ACT_ORIG_CD", ClsConvert.AddQuotes(Act_Orig_CDs));
			Connection.AppendInClause(sb, p, "AND",
				"ca.dest_location_cd", "@ACT_DEST_CD", ClsConvert.AddQuotes(Act_Dest_CDs));

			//Connection.AppendInClause(sb, p, "AND",
//				"v.acms_status_cd", "@AC_ST", ClsConvert.AddQuotes(StatusCDs));

			if (IncludeNonBillPay == false)
			{
				sb.Append(@"
				AND (ca.billable_flg = 'Y' OR ca.payable_flg = 'Y') ");
			}

			if (IncludeBlankTCNs == false)
			{
				sb.Append(@"
				AND c.serial_no IS NOT NULL ");
			}

			if (IncludeTransShip == false)
			{
				sb.Append(@"
				AND 	NOT EXISTS (
						SELECT	'X'
						FROM	v_trans_booking vtsw
						WHERE	vtsw.booking_no = bk.booking_no
						AND		UPPER(vtsw.leg_type) LIKE '%FIN%') ");
			}

			if (IncludeNonDoor == false)
			{
				Connection.AppendNotInClause(sb, p, "AND", "c.move_type_cd", "@EX_MV_TY", "'F1', 'F2', 'F3', 'F4'");
			}

			Connection.AppendInClause(sb, p, "AND",
				"c.move_type_cd", "@MV_TP", ClsConvert.AddQuotes(MoveTypeCDs));

			Connection.AppendLikeClause(sb, p, "AND",
				"c.serial_no", "@SER_NO", Serial_No);


			//Connection.AppendDateClause(sb, p, "AND",
//				"nvl(v.poe_atd, v.poe_etd)", "@ET_FR", "@ET_TO", ETD);
			//Connection.AppendDateClause(sb, p, "AND", "v.adj_rdd_dt", "@RD_FR", "@RD_TO", RDD);

			Connection.AppendInClause(sb, p, "AND",
				"bk.vessel_cd", "@VES_CD", ClsConvert.AddQuotes(Vessel));
			Connection.AppendLikeClause(sb, p, "AND",
				"bk.voyage_no", "@VOY_NO", VoyageNo);
		}
		#endregion		// #region Search Available Methods

		#region Search Existing Methods

		public DataSet SearchExistingDS()
		{
			DataSet ds = new DataSet();

			DataTable dtEstimates = SearchExistingEstimates();
			ds.Tables.Add(dtEstimates);

			if (dtEstimates.Rows.Count > 0)
			{
				DataTable dtActivity = SearchExistingActivities();
				ds.Tables.Add(dtActivity);

				DataColumn[] dcPK = new DataColumn[1];
				dcPK[0] = dtEstimates.Columns["ESTIMATE_ID"];

				DataColumn[] dcFK = new DataColumn[1];
				dcFK[0] = dtActivity.Columns["ESTIMATE_ID"];

				ds.Relations.Add("EstimateActivities", dcPK, dcFK, false);
			}

			return ds;
		}

		public DataTable SearchExistingEstimates()
		{
			/*
					decode(est.orig_location_cd, bk.plor_location_cd, 'DOOR TO PORT',
						bk.pod_location_cd, 'PORT TO DOOR', 'UNKNOWN') as direction_txt,
			*/
			List<DbParameter> p = new List<DbParameter>();
			StringBuilder sb = new StringBuilder(@"
			select	est.estimate_id, est.create_user, est.create_dt, est.modify_user, est.modify_dt,
					est.estimate_no, est.voyage_no, est.orig_location_cd,
					oloc.location_dsc AS orig_location_dsc, est.dest_location_cd,
					dloc.location_dsc AS dest_location_dsc,
					est.estimate_dt, est.accrued_dt, est.mileage, est.orig_estimate_id,
					est.ap_status_cd, est.ar_status_cd, est.line_status_cd,
					decode(oloc.conus_flg, 'Y', 'CONUS', 'N', 'OCONUS', '?') as conus_txt,
					DECODE(oloc.location_type_cd, 'LAND', 'DOOR', 'PORT', 'PORT', 'UNKNOWN') ||
						' TO ' || DECODE(dloc.location_type_cd, 'LAND', 'DOOR', 'PORT', 'PORT',
						'UNKNOWN') as direction_txt,
					sum(decode(ca.orig_location_cd, null, 0, est.orig_location_cd, 0, 1)) as mismatch_orig_count,
					sum(decode(ca.dest_location_cd, null, 0, est.dest_location_cd, 0, 1)) as mismatch_dest_count,
					sum(decode(bk.voyage_no, null, 0, est.voyage_no, 0, 1)) as mismatch_voy_count,
					(select count(ca2.cargo_activity_id) from t_cargo_activity ca2
						where ca2.estimate_id = est.estimate_id) as act_count,
					nvl((select sum(total_amt) from t_estimate_charge c1 where c1.estimate_id = est.estimate_id
						and c1.finance_cd = 'AR'), 0) as est_ar_amt,
					nvl((select sum(total_amt) from t_estimate_charge c1 where c1.estimate_id = est.estimate_id
						and c1.finance_cd = 'AP'), 0) as est_ap_amt
			from	t_estimate est
					INNER JOIN r_location oloc	on oloc.location_cd = est.orig_location_cd
					INNER JOIN r_location dloc	on dloc.location_cd = est.dest_location_cd
					left outer join t_cargo_activity ca
						INNER JOIN t_cargo c			on c.cargo_id = ca.cargo_id
						INNER JOIN t_booking bk			on bk.booking_id = c.booking_id
														on ca.estimate_id = est.estimate_id
			where	1 = 1 ");

			AppendWhereExisting(sb, p, true);

			sb.Append(@"
			group by	est.estimate_id, est.create_user, est.create_dt, est.modify_user, est.modify_dt,
						est.estimate_no, est.voyage_no, est.orig_location_cd, oloc.location_dsc,
						est.dest_location_cd, dloc.location_dsc,
						est.estimate_dt, est.accrued_dt, est.mileage, est.orig_estimate_id,
						est.ap_status_cd, est.ar_status_cd, est.line_status_cd,
						decode(oloc.conus_flg, 'Y', 'CONUS', 'N', 'OCONUS', '?'),
						DECODE(oloc.location_type_cd, 'LAND', 'DOOR', 'PORT', 'PORT', 'UNKNOWN') ||
							' TO ' || DECODE(dloc.location_type_cd, 'LAND', 'DOOR', 'PORT', 'PORT',
							'UNKNOWN')
			order by	est.voyage_no, direction_txt, oloc.location_dsc, dloc.location_dsc ");

			DataTable dt = Connection.GetDataTable(sb.ToString(), p.ToArray());
			if (dt != null)
			{
				dt.TableName = "Estimate";
				dt.Columns.Add("est_ar_ap_diff", typeof(decimal), "est_ar_amt - est_ap_amt");
			}
			return dt;
		}

		/*
					decode(est.orig_location_cd, bk.plor_location_cd, 'DOOR TO PORT',
						bk.pod_location_cd, 'PORT TO DOOR', 'UNKNOWN') as direction_txt,
		*/
		public readonly string SqlExistingActs = @"
			select	ca.*, est.*, c.item_no, c.cube_ft, c.m_tons, c.dim_weight_nbr,
					oloc.location_dsc as orig_location_dsc, dloc.location_dsc as dest_location_dsc,
					c.booking_id, c.serial_no, c.commodity_cd, c.pkg_type_cd,
					c.length_nbr, c.width_nbr, c.height_nbr, c.weight_nbr, c.move_type_cd,
					c.cargo_dsc, c.container_no, c.seal1, c.seal2, c.seal3, c.vessel_load_dt,
					c.make_cd, c.model_cd, c.contract_mod_id, c.cargo_key, bk.booking_no,
					bk.booking_ref, bk.plor_location_cd, bk.pol_location_cd, bk.pod_location_cd,
					bk.plod_location_cd, plor.location_dsc AS plor_location_dsc,
					pol.location_dsc AS pol_location_dsc, pod.location_dsc AS pod_location_dsc,
					plod.location_dsc AS plod_location_dsc,bk.bol_no, bk.edi_ref, bk.customer_ref,
					bk.vessel_cd, ves.vessel_nm, bk.voyage_no as bk_voyage_no, bk.sail_dt,
					bk.delivery_txt, bk.cargo_notes_txt, bk.customer_cd, bk.match_cd, cust.customer_nm,
					bk.booking_no || ' -' || to_char(c.item_no, '00') as bk_item_no,
					c.length_nbr || ' x ' || c.width_nbr || ' x ' || c.height_nbr || ' - ' ||
						bk.booking_no || ' Item Group' || to_char(c.item_no, '00') as lwh_bk_item_no,
					c.cargo_dsc || ' ' || c.length_nbr || ' x ' || c.width_nbr || ' x ' ||
						c.height_nbr as cargo_dsc_lwh,
					c.length_nbr || ' x ' || c.width_nbr || ' x ' || c.height_nbr as len_wid_hgt,
					decode(ca.orig_location_cd, null, 0, est.orig_location_cd, 0, 1) as mismatch_orig,
					decode(ca.dest_location_cd, null, 0, est.dest_location_cd, 0, 1) as mismatch_dest,
					decode(bk.voyage_no, null, 0, est.voyage_no, 0, 1) as mismatch_voy,
					decode(estoloc.conus_flg, 'Y', 'CONUS', 'N', 'OCONUS', '?') as conus_txt,
					DECODE(estoloc.location_type_cd, 'LAND', 'DOOR', 'PORT', 'PORT', 'UNKNOWN') ||
						' TO ' || DECODE(estdloc.location_type_cd, 'LAND', 'DOOR', 'PORT', 'PORT',
						'UNKNOWN') as direction_txt,
					cmod.mod_no, cmod.attachment_nm,
					DECODE(cmod.contract_mod_id, NULL, NULL, cmod.mod_no || ' - ' ||
						NVL(cmod.attachment_nm, '<No Attachment>')) AS mod_no_attachment_nm,
					nvl((select sum(apedt.activity_amt) from t_estimate_charge_dtl apedt
							INNER JOIN t_estimate_charge echg on echg.estimate_charge_id = apedt.estimate_charge_id
							where apedt.cargo_activity_id = ca.cargo_activity_id and echg.finance_cd = 'AP'
						), 0) as ap_total_amt,
					nvl((select sum(aredt.activity_amt) from t_estimate_charge_dtl aredt
							INNER JOIN t_estimate_charge echg on echg.estimate_charge_id = aredt.estimate_charge_id
							where aredt.cargo_activity_id = ca.cargo_activity_id and echg.finance_cd = 'AR'
						), 0) as ar_total_amt,
					(SELECT	MIN(vts.leg_type)
					FROM	v_trans_booking vts
					WHERE	vts.booking_no = bk.booking_no) AS trans_leg,
					(SELECT	MIN(vts.linked_booking_no)
					FROM	v_trans_booking vts
					WHERE	vts.booking_no = bk.booking_no) AS linked_booking_no
			from	t_estimate est
					INNER JOIN r_location estoloc		ON estoloc.location_cd = est.orig_location_cd
					INNER JOIN r_location estdloc		ON estdloc.location_cd = est.dest_location_cd
					INNER JOIN t_cargo_activity ca		ON ca.estimate_id = est.estimate_id
					INNER JOIN t_cargo c				ON c.cargo_id = ca.cargo_id
					INNER JOIN t_booking bk				ON bk.booking_id = c.booking_id
					INNER JOIN r_location oloc			ON oloc.location_cd = ca.orig_location_cd
					INNER JOIN r_location dloc			ON dloc.location_cd = ca.dest_location_cd
					INNER JOIN r_location plor			ON plor.location_cd = bk.plor_location_cd
					INNER JOIN r_location pol			ON pol.location_cd = bk.pol_location_cd
					INNER JOIN r_location pod			ON pod.location_cd = bk.pod_location_cd
					INNER JOIN r_location plod			ON plod.location_cd = bk.plod_location_cd
					INNER JOIN r_vessel ves				ON ves.vessel_cd = bk.vessel_cd
					LEFT OUTER JOIN r_customer cust		ON cust.customer_cd = bk.customer_cd
					LEFT OUTER JOIN t_contract_mod cmod ON cmod.contract_mod_id = c.contract_mod_id
			where	1 = 1 ";

		public DataTable SearchExistingActivities()
		{
			List<DbParameter> p = new List<DbParameter>();
			StringBuilder sb = new StringBuilder(SqlExistingActs);

			// DGERDNER Feb2015 - change last parameter to true so it will filter based on the search
			//  parameters.  Otherwise it's getting all charges every time, which is a huge performance hit.
			AppendWhereExisting(sb, p, true);

			sb.Append(@"
			order by	bk.voyage_no, direction_txt, ca.orig_location_cd, ca.dest_location_cd, c.cargo_dsc, c.serial_no ");

			DataTable dt = Connection.GetDataTable(sb.ToString(), p.ToArray());
			if (dt != null)
			{
				dt.TableName = "Activities";
				//dt.Columns.Add("Cubic_Ft", typeof(int), "(length_nbr * width_nbr * height_nbr) / 1728");
				//dt.Columns.Add("M_Tons", typeof(int), "(length_nbr * width_nbr * height_nbr) / 1728 / 40");
			}
			return dt;
		}

		public DataTable SearchEstimateAvailableActivities(long? echgID, bool exists)
		{
			List<DbParameter> p = new List<DbParameter>();
			StringBuilder sb = new StringBuilder(SqlExistingActs);

			AppendWhereExisting(sb, p, false);

			Connection.AppendEqualClause(sb, p, "AND", "ca.payable_flg", "@PAY_FLG", Payable_Flg);
			Connection.AppendEqualClause(sb, p, "AND", "ca.billable_flg", "@BILL_FLG", Billable_Flg);

			if (echgID != null)
			{
				sb.AppendFormat(@"AND
				{0} EXISTS (
					SELECT	'X'
					FROM	t_estimate_charge_dtl edt
					WHERE	edt.cargo_activity_id = ca.cargo_activity_id AND
							edt.estimate_charge_id = {1}
						) ", (exists ? null : "NOT"), echgID.Value);
			}

			sb.Append(@"
			order by	bk.voyage_no, direction_txt, bk.booking_no, ca.orig_location_cd, ca.dest_location_cd, c.cargo_dsc, c.item_no, c.serial_no ");

			DataTable dt = Connection.GetDataTable(sb.ToString(), p.ToArray());
			if (dt != null)
			{
				dt.TableName = "Activities";
				//dt.Columns.Add("Cubic_Ft", typeof(int), "(length_nbr * width_nbr * height_nbr) / 1728");
				//dt.Columns.Add("MTons", typeof(int), "(length_nbr * width_nbr * height_nbr) / 1728 / 40");
			}
			return dt;
		}

		public DataTable SearchExistingActivitiesChargeType(long? echgID, string chgCd, string catCd,
			bool exists)
		{
			List<DbParameter> p = new List<DbParameter>();
			StringBuilder sb = new StringBuilder(SqlExistingActs);

			AppendWhereExisting(sb, p, false);

			if (echgID != null || string.IsNullOrEmpty(chgCd) == false)
			{
				sb.AppendFormat(@"AND
				{0} EXISTS (
					SELECT	'X'
					FROM	t_estimate_charge_dtl edt
							INNER JOIN t_estimate_charge echg	ON echg.estimate_charge_id = edt.estimate_charge_id
							INNER JOIN r_charge_type cht		ON cht.charge_type_cd = echg.charge_type_cd
					WHERE	edt.cargo_activity_id = ca.cargo_activity_id AND
							(", (exists ? null : "NOT"));

				Connection.AppendEqualClause(sb, p, null, "edt.estimate_charge_id", "@CHG_ID", echgID);
				string logType = (echgID != null) ? "OR" : null;
				Connection.AppendEqualClause(sb, p, logType, "echg.charge_type_cd", "@CHT_CD", chgCd);
				logType = (echgID != null || string.IsNullOrEmpty(chgCd) == false) ? "OR" : null;
				Connection.AppendEqualClause(sb, p, logType, "cht.charge_category_cd", "@CAT_CD", catCd);
				sb.Append("))"); // close the OR section, then close the EXISTS section
			}

			sb.Append(@"
			order by	bk.voyage_no, direction_txt, ca.orig_location_cd, ca.dest_location_cd, c.serial_no ");

			DataTable dt = Connection.GetDataTable(sb.ToString(), p.ToArray());
			if (dt != null)
			{
				dt.TableName = "Activities";
				//dt.Columns.Add("Cubic_Ft", typeof(int), "(length_nbr * width_nbr * height_nbr) / 1728");
				//dt.Columns.Add("M_Tons", typeof(int), "(length_nbr * width_nbr * height_nbr) / 1728 / 40");
			}
			return dt;
		}

		public DataSet SearchActivitiesPlusCharges()
		{
			DataSet ds = new DataSet();

			DataTable dtCargo = SearchExistingActivities();
			ds.Tables.Add(dtCargo);

			if (dtCargo.Rows.Count > 0)
			{
				DataTable dtCharges = GetActivityCharges();
				ds.Tables.Add(dtCharges);

				DataColumn[] dcPK = new DataColumn[1];
				dcPK[0] = dtCargo.Columns["CARGO_ACTIVITY_ID"];

				DataColumn[] dcFK = new DataColumn[1];
				dcFK[0] = dtCharges.Columns["CARGO_ACTIVITY_ID"];

				ds.Relations.Add("ChargeActivitiesCharges", dcPK, dcFK, false);
			}

			return ds;
		}

		public DataTable GetActivityCharges()
		{
			StringBuilder sb = new StringBuilder(@"
			SELECT	edt.*, echg.charge_type_cd, cht.charge_type_dsc, cht.charge_category_cd,
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
					decode(echg.finance_cd, 'AR', edt.activity_amt, -edt.activity_amt) AS adj_activity_amt
			FROM	t_estimate_charge_dtl edt
					INNER JOIN t_estimate_charge echg	ON echg.estimate_charge_id = edt.estimate_charge_id
					INNER JOIN r_charge_type cht		ON cht.charge_type_cd = echg.charge_type_cd
					INNER JOIN r_level_unit lvu			ON lvu.level_unit_id = echg.level_unit_id
					INNER JOIN r_unit_type ut			ON ut.unit_type_cd = lvu.unit_type_cd
			WHERE	echg.estimate_id = @EST_ID");

			List<DbParameter> p = new List<DbParameter>();
			p.Add(Connection.GetParameter("@EST_ID", Estimate_ID.GetValueOrDefault(-1)));

			sb.Append(@"
			order by echg.estimate_id, cht.charge_category_cd, cht.charge_type_dsc ");

			DataTable dt = Connection.GetDataTable(sb.ToString(), p.ToArray());
			if (dt != null)
			{
				dt.TableName = "ActivityCharges";
			}
			return dt;
		}

		public void AppendWhereExisting(StringBuilder sb, List<DbParameter> p, bool isParent)
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

            // 2017-05-30 - JD: COMMENTING OUT - AS THIS IS CAUSING PROBLEMS 
            //WITH ALL OF THE ESTIMATE REPORTING ... 
            // For Region - Conus or Oconus oloc.conus_flg = 'Y' / 'N'
            //if (!RegionAll)
            //    Connection.AppendEqualClause(
            //        sb,
            //        p,
            //        "AND",
            //        "oloc.conus_flg",
            //        "@REGION",
            //        (RegionConus) ? "Y" : "N");

			if (isParent)
			{
				Connection.AppendLikeClause(sb, p, "AND",
					"bk.customer_ref", "@PCFN", PCFN);
				Connection.AppendLikeClause(sb, p, "AND",
					"bk.booking_no", "@BK_NO", Booking_No);
				Connection.AppendInClause(sb, p, "AND",
					"bk.customer_ref", "@PCSV", ClsConvert.AddQuotes(csvPCFN));
				Connection.AppendInClause(sb, p, "AND",
					"bk.booking_no", "@BK_CSV", ClsConvert.AddQuotes(csvBooking));

				Connection.AppendInClause(sb, p, "AND",
					"bk.customer_cd", "@CUST_CD", ClsConvert.AddQuotes(Customer_CDs));
				Connection.AppendInClause(sb, p, "AND",
					"bk.plor_location_cd", "@PLOR_CD", ClsConvert.AddQuotes(PLOR_CDs));
				Connection.AppendInClause(sb, p, "AND",
					"bk.pol_location_cd", "@POL_CD", ClsConvert.AddQuotes(POL_CDs));
				Connection.AppendInClause(sb, p, "AND",
					"bk.pod_location_cd", "@POD_CD", ClsConvert.AddQuotes(POD_CDs));
				Connection.AppendInClause(sb, p, "AND",
					"bk.plod_location_cd", "@PLOD_CD", ClsConvert.AddQuotes(PLOD_CDs));

				Connection.AppendInClause(sb, p, "AND",
					"c.move_type_cd", "@MV_TP", ClsConvert.AddQuotes(MoveTypeCDs));
				Connection.AppendLikeClause(sb, p, "AND",
					"c.serial_no", "@SER_NO", Serial_No);

				Connection.AppendInClause(sb, p, "AND",
					"bk.vessel_cd", "@VES_CD", ClsConvert.AddQuotes(Vessel));
				Connection.AppendDateClause(sb, p, "AND",
					"bk.sail_dt", "@SAIL_FR", "@SAIL_TO", Vessel_Sail_Dt);


			}
		}
		#endregion		// #region Search Methods

		#region Search Charges

		public DataSet SearchChargesDS()
		{
			DataSet ds = new DataSet();

			DataTable dtEstimates = SearchChargeGroups();
			ds.Tables.Add(dtEstimates);

			if (dtEstimates.Rows.Count > 0)
			{
				DataTable dtChg = SearchChargeDetail();
				ds.Tables.Add(dtChg);

				DataColumn[] dcPK = new DataColumn[1];
				dcPK[0] = dtEstimates.Columns["ESTIMATE_ID"];

				DataColumn[] dcFK = new DataColumn[1];
				dcFK[0] = dtChg.Columns["ESTIMATE_ID"];

				ds.Relations.Add("EstimateCharges", dcPK, dcFK, false);
			}

			return ds;
		}

		public DataTable SearchChargeGroups()
		{
			/*
					decode(est.orig_location_cd, bk.plor_location_cd, 'DOOR TO PORT',
						bk.pod_location_cd, 'PORT TO DOOR', 'UNKNOWN') as direction_txt,
			*/
			List<DbParameter> p = new List<DbParameter>();
			StringBuilder sb = new StringBuilder(@"
			select	nvl((select sum(total_amt) from t_estimate_charge c1 where c1.estimate_id = est.estimate_id
						and c1.finance_cd = 'AR'), 0) as est_ar_amt,
					nvl((select sum(total_amt) from t_estimate_charge c1 where c1.estimate_id = est.estimate_id
						and c1.finance_cd = 'AP'), 0) as est_ap_amt,
					est.estimate_id, est.create_user, est.create_dt, est.modify_user, est.modify_dt,
					est.estimate_no, est.voyage_no, est.orig_location_cd, est.dest_location_cd,
					est.estimate_dt, est.accrued_dt, est.mileage, est.orig_estimate_id,
					oloc.location_dsc AS orig_location_dsc,
					dloc.location_dsc AS dest_location_dsc,
					decode(oloc.conus_flg, 'Y', 'CONUS', 'N', 'OCONUS', '?') as conus_txt,
					DECODE(oloc.location_type_cd, 'LAND', 'DOOR', 'PORT', 'PORT', 'UNKNOWN') ||
						' TO ' || DECODE(dloc.location_type_cd, 'LAND', 'DOOR', 'PORT', 'PORT',
						'UNKNOWN') as direction_txt,
					count(distinct ca.cargo_activity_id) as act_count,
					count(distinct echg.estimate_charge_id) as chg_count
			from	t_estimate est
					INNER JOIN r_location oloc				on oloc.location_cd = est.orig_location_cd
					INNER JOIN r_location dloc				on dloc.location_cd = est.dest_location_cd
					left outer join t_estimate_charge echg	on echg.estimate_id = est.estimate_id
					left outer join t_cargo_activity ca
						INNER JOIN t_cargo c				on c.cargo_id = ca.cargo_id
						INNER JOIN t_booking bk				on bk.booking_id = c.booking_id
															on ca.estimate_id = est.estimate_id
			where	1 = 1 ");

			AppendWhereExisting(sb, p, true);

			sb.Append(@"
			group by	est.estimate_id, est.create_user, est.create_dt, est.modify_user, est.modify_dt,
						est.estimate_no, est.voyage_no, est.orig_location_cd, est.dest_location_cd,
						est.estimate_dt, est.accrued_dt, est.mileage, est.orig_estimate_id,
						oloc.location_dsc, dloc.location_dsc,
						decode(oloc.conus_flg, 'Y', 'CONUS', 'N', 'OCONUS', '?'),
						DECODE(oloc.location_type_cd, 'LAND', 'DOOR', 'PORT', 'PORT', 'UNKNOWN') ||
							' TO ' || DECODE(dloc.location_type_cd, 'LAND', 'DOOR', 'PORT', 'PORT',
							'UNKNOWN')
			order by	est.voyage_no, direction_txt, est.orig_location_cd, est.dest_location_cd ");

			DataTable dt = Connection.GetDataTable(sb.ToString(), p.ToArray());
			if (dt != null)
			{
				dt.TableName = "Estimate";
				dt.Columns.Add("est_ar_ap_diff", typeof(decimal), "est_ar_amt - est_ap_amt");
			}
			return dt;
		}

		public DataTable SearchChargeDetail()
		{
			List<DbParameter> p = new List<DbParameter>();
			StringBuilder sb = new StringBuilder(@"
			select	decode(echg.finance_cd, 'AR', echg.total_amt, -echg.total_amt) as signed_total_amt,
					echg.*, cht.charge_category_cd,
					lvu.level_unit_dsc, lvu.level_cd, lvu.unit_type_cd, lvu.level_count_dsc,
					lvu.unit_qty_dsc, lvu.average_flg, ut.units_required_flg,
					decode(lvu.average_flg, 'N', null,
						echg.level_count || ' ' || lvu.level_count_dsc) AS level_disp,
					decode(ut.units_required_flg, 'Y', echg.unit_qty || ' ' || ut.grid_column_dsc,
						null) as unit_disp,
					est2.voyage_no, est2.orig_location_cd, est2.dest_location_cd, est2.estimate_id,
					est2.estimate_no,
					estoloc.location_dsc as orig_location_dsc, estdloc.location_dsc as dest_location_dsc,
					decode(estoloc.conus_flg, 'Y', 'CONUS', 'N', 'OCONUS', '?') as conus_txt
			from	t_estimate_charge echg
					INNER JOIN r_charge_type cht	on cht.charge_type_cd = echg.charge_type_cd
					INNER JOIN r_level_unit lvu		on lvu.level_unit_id = echg.level_unit_id 
					INNER JOIN r_unit_type ut		on ut.unit_type_cd = lvu.unit_type_cd
					INNER JOIN t_estimate est2		on est2.estimate_id = echg.estimate_id
					INNER JOIN r_location estoloc	on estoloc.location_cd = est2.orig_location_cd
					INNER JOIN r_location estdloc	on estdloc.location_cd = est2.dest_location_cd ");


			StringBuilder sbWhere = new StringBuilder();
			AppendWhereCharges(sbWhere, p);
			if( sbWhere.Length > 0 )
			{
				StringBuilder sbWith = new StringBuilder(@"
			WITH est_hdr AS
				(
					select	est.estimate_id
					from	t_estimate est
						left outer join t_cargo_activity ca
							INNER JOIN t_cargo c			on c.cargo_id = ca.cargo_id
							INNER JOIN t_booking bk			on bk.booking_id = c.booking_id
															on ca.estimate_id = est.estimate_id
					WHERE 1 = 1 ");
				sbWith.Append(sbWhere);
				sbWith.Append(@"
					group by est.estimate_id
				)");
				sb.Insert(0, sbWith);
				sb.Append(@"
					INNER JOIN est_hdr mh on mh.estimate_id = est2.estimate_id");
			}

			sb.Append(@"
			order by	est2.voyage_no, est2.orig_location_cd, est2.dest_location_cd,
						echg.finance_cd, cht.charge_category_cd, lvu.level_cd, echg.charge_type_cd,
						lvu.unit_type_cd, echg.total_amt ");

			DataTable dt = Connection.GetDataTable(sb.ToString(), p.ToArray());
			if (dt != null)
			{
				dt.TableName = "Charges";
			}
			return dt;
		}

		public void AppendWhereCharges(StringBuilder sb, List<DbParameter> p)
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
				"bk.customer_ref", "@PCFN", PCFN);
			Connection.AppendLikeClause(sb, p, "AND",
				"bk.booking_no", "@BK_NO", Booking_No);
			Connection.AppendInClause(sb, p, "AND",
				"bk.customer_ref", "@PCSV", ClsConvert.AddQuotes(csvPCFN));
			Connection.AppendInClause(sb, p, "AND",
				"bk.booking_no", "@BK_CSV", ClsConvert.AddQuotes(csvBooking));

			Connection.AppendInClause(sb, p, "AND",
				"bk.customer_cd", "@CUST_CD", ClsConvert.AddQuotes(Customer_CDs));
			Connection.AppendInClause(sb, p, "AND",
				"bk.plor_location_cd", "@PLOR_CD", ClsConvert.AddQuotes(PLOR_CDs));
			Connection.AppendInClause(sb, p, "AND",
				"bk.pol_location_cd", "@POL_CD", ClsConvert.AddQuotes(POL_CDs));
			Connection.AppendInClause(sb, p, "AND",
				"bk.pod_location_cd", "@POD_CD", ClsConvert.AddQuotes(POD_CDs));
			Connection.AppendInClause(sb, p, "AND",
				"bk.plod_location_cd", "@PLOD_CD", ClsConvert.AddQuotes(PLOD_CDs));


			Connection.AppendInClause(sb, p, "AND",
				"c.move_type_cd", "@MV_TP", ClsConvert.AddQuotes(MoveTypeCDs));
			Connection.AppendLikeClause(sb, p, "AND",
				"c.serial_no", "@SER_NO", Serial_No);

			Connection.AppendInClause(sb, p, "AND",
				"bk.vessel_cd", "@VES_CD", ClsConvert.AddQuotes(Vessel));
			Connection.AppendDateClause(sb, p, "AND",
				"bk.sail_dt", "@SAIL_FR", "@SAIL_TO", Vessel_Sail_Dt);
		}
		#endregion		// #region Search Charges

		#region Investigate Why Booking Not Availabel for Estimate
		public string EstimateInvestigate(string sBooking, string sInOut)
		{
            StringBuilder sReason = new StringBuilder();
            try
            {
                //
                // First, look for reason that apply to the booking regardless of 
                // whether it's inbound or outbound.
                //
                dtCargoErrors = null;
                ClsBookingLine BookingLine = ClsBookingLine.GetByBookingNo(sBooking);
                if (BookingLine == null)
                {
                    sReason.AppendLine("Booking has not been imported into ArcSys (t_booking_line)");
                    sReason.AppendLine();
                }
                if (!BookingLine.MoveType.IsDoorMove)
                {
                    sReason.AppendLine(string.Format("Booking is not a door move.  Move type is {0}", BookingLine.Move_Type_Cd));
                    sReason.AppendLine();
                }
                if (BookingLine.Sail_Dt < DateTime.Today.AddDays(-90))
                {
                    sReason.AppendLine(string.Format("Sail date ({0}) is out of range. Manually search, removing the sail date filter.", BookingLine.Sail_Dt));
                    sReason.AppendLine();
                }
                if (BookingLine.Sail_Dt == null)
                {
                    sReason.AppendLine(string.Format("Sail date is null."));
                    sReason.AppendLine();
                }
                if (BookingLine.Rdd_Dt == null)
                {
                    sReason.AppendLine(string.Format("RDD date is blank.  Discuss with software support"));
                    sReason.AppendLine();
                }
                if (BookingLine.Booking_Status != "C")
                {
                    sReason.AppendLine("Check the booking status in OCEAN.  It may not be a confirmed booking and therefor not in the Intermodal system.");
                    sReason.AppendLine();
                }
                ClsBooking bk = ClsBooking.FindByBookingNo(sBooking);
                if (bk == null)
                {
                    dtCargoErrors = CargoWithErrors(BookingLine);
                    sReason.AppendLine("Booking is not in the Intermodal system.  Check with support, and review detail below.");
                    sReason.AppendLine();
                    return sReason.ToString();
                }


                string s1 = CheckExistingEstimates(bk, sInOut);
                if (!string.IsNullOrEmpty(s1))
                    sReason.AppendLine(s1);
                s1 = CheckCorrectLeg(bk, sInOut);
                if (!string.IsNullOrEmpty(s1))
                    sReason.AppendLine(s1);

                ClsBooking b = ClsBooking.FindByBookingNo(bk.Booking_No);
                if (b != null)
                    if (b.Required_Dlvy_Dt == null)
                        return "RDD is blank for the booking";

                //
                // Next, look for inbound problems
                //
                if (sInOut == "I")
                {
                    string x = InboundProblems(BookingLine);
                    if (!string.IsNullOrEmpty(x))
                        sReason.AppendLine(x);
                    x = CheckExistingEstimates(bk, sInOut);
                    if (!string.IsNullOrEmpty(x))
                        sReason.AppendLine(x);
                }
                //
                // Next, look for outbound problems
                //
                if (sInOut == "O")
                {
                    string x = OutboundProblems(BookingLine);
                    if (!string.IsNullOrEmpty(x))
                        sReason.AppendLine(x);
                }
                s1 = CheckLegExists(BookingLine, sInOut);
                if (!string.IsNullOrEmpty(s1))
                {
                    sReason.AppendLine(s1);
                    sReason.AppendLine();
                }

                // If null, then no reason has been found.  Rats.
                if (string.IsNullOrEmpty(sReason.ToString()))
                    return "Reason is unknown.";
                return sReason.ToString();
            }
            catch (Exception ex)
            {
                string x = string.Format("* An error was encountered.  Report this to IT.   {0} ", ex.Message);
                sReason.AppendLine(x);
                return sReason.ToString();
            }
		}
		
		public string InboundProblems(ClsBookingLine booking)
		{
			if (booking.MoveType.Door_In_Flg == "N")
				return string.Format("{0} - This is not a Door In Move Type", booking.Move_Type_Cd);
			return "";
		}
		public string OutboundProblems(ClsBookingLine booking)
		{
			if (booking.MoveType.Door_Out_Flg == "N")
				return string.Format("{0} - This is not a Door Out Move Type", booking.Move_Type_Cd);
			ClsBooking b = ClsBooking.FindByBookingNo(booking.Booking_No);
			if (b != null)
				if (b.Required_Dlvy_Dt == null)
					return string.Format("RDD is empty for the booking");
			return "";
		}

		public string CheckLegExists(ClsBookingLine bk, string inout)
		{
			string sql = string.Format(@"
				select estimate_id,leg_type, ca.*
					  from  t_cargo_activity ca
						  INNER JOIN t_cargo c    on c.cargo_id = ca.cargo_id
						  INNER JOIN t_booking bk    on bk.booking_id = c.booking_id
						  INNER JOIN r_location oloc  on oloc.location_cd = ca.orig_location_cd
						  INNER JOIN r_location dloc  on dloc.location_cd = ca.dest_location_cd
					  left outer join v_trans_booking tbk on tbk.booking_no = bk.booking_no
					where bk.booking_no = '{0}'
					 and io_ind = '{1}'", bk.Booking_No, inout);

			DataTable dt = Connection.GetDataTable(sql);
			if (dt.Rows.Count < 1)
			{
				dtCargoErrors = CargoWithErrors(bk);
				if (inout == "I")
					return "No inbound activities were imported into the Intermodal system.  Check with software dev support, and review details below.";
				else
					return "No outbound activities were imported into the Intermodal system.  Check with software dev support, and review details below";
			}
			return "";
		}

		public DataTable CargoWithErrors(ClsBookingLine booking)
		{
			string sql = string.Format(@"
			 select * from v_booking_cargo_line bc
			  where bc.import_notes_txt is not null
			   and booking_no like '{0}%'
			   and move_type_cd > 'F5' ", booking.Booking_No);
			return Connection.GetDataTable(sql);
		}
		public string CheckExistingEstimates(ClsBooking bk, string inout)
		{
			string sql = string.Format(@"
				select *
					  from  t_cargo_activity ca
						  INNER JOIN t_cargo c    on c.cargo_id = ca.cargo_id
						  INNER JOIN t_booking bk    on bk.booking_id = c.booking_id
						  INNER JOIN r_location oloc  on oloc.location_cd = ca.orig_location_cd
						  INNER JOIN r_location dloc  on dloc.location_cd = ca.dest_location_cd
					  left outer join v_trans_booking tbk on tbk.booking_no = bk.booking_no
					where bk.booking_no = '{0}'
					 and io_ind = '{1}'
					 and estimate_id is not null ", bk.Booking_No, inout);
			DataTable dt = Connection.GetDataTable(sql);
			if (dt.Rows.Count > 0)
				return "An estimate already exists for this booking.";
			return "";
		}

		public string CheckCorrectLeg(ClsBooking bk, string inout)
		{
			// sLegType, at first glance, appears to be swapped ("I" s/b "First" and "O" s/b "Final").  However, in this case
			// we're looking for cases where things are backwards.
			string sLegType = "FINAL";
			if (inout == "O")
				sLegType = "FIRST";
            StringBuilder sError = new StringBuilder();
			string sql = string.Format(@"
			select estimate_id,leg_type, ca.*, tbk.linked_booking_no
				  from  t_cargo_activity ca
					  INNER JOIN t_cargo c    on c.cargo_id = ca.cargo_id
					  INNER JOIN t_booking bk    on bk.booking_id = c.booking_id
					  INNER JOIN r_location oloc  on oloc.location_cd = ca.orig_location_cd
					  INNER JOIN r_location dloc  on dloc.location_cd = ca.dest_location_cd
				  left outer join v_trans_booking tbk on tbk.booking_no = bk.booking_no
				where bk.booking_no = '{2}'
				 and io_ind = '{0}'
				 and leg_type is not null
				 and  upper(leg_type) like '{1}%' ", inout, sLegType, bk.Booking_No);
			DataTable dt = Connection.GetDataTable(sql);
			if (dt.Rows.Count > 0)
				if (inout == "I")
				{
                    sError.AppendLine("This is the final leg of a transshipment, the inbound move does not apply.");
                    string sBk = dt.Rows[0]["linked_booking_no"].ToString();
                    sError.AppendLine(string.Format("  * Check booking {0} instead.", sBk));
				}
				else
				{
                    sError.AppendLine("This is the first leg of a transshipment, the outbound move does not apply.");
                    string sBk = dt.Rows[0]["linked_booking_no"].ToString();
                    sError.AppendLine(string.Format("  * Check booking {0} instead.", sBk));
				}
            return sError.ToString();
		}
		#endregion
	}
}