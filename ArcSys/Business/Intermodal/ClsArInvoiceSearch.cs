using System;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;
using System.Text;

namespace CS2010.ArcSys.Business
{
	public class ClsArInvoiceSearch
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ArcSys"]; }
		}
		#endregion		// #region Connection Manager

		#region Fields

		public long? Ar_Invoice_ID;
		public string csvArInvoiceID;

		public string Ar_Invoice_No;
		public string Booking_No;
		public string Customer_Cd;
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

		public ClsArInvoiceSearch()
		{
			Clear();
		}

		public ClsArInvoiceSearch(ClsArInvoiceSearch aSearch)
		{
			Clear();
			CopyFrom(aSearch);
		}

		public void CopyFrom(ClsArInvoiceSearch aSearch)
		{
			Ar_Invoice_ID = aSearch.Ar_Invoice_ID;
			csvArInvoiceID = aSearch.csvArInvoiceID;

			Ar_Invoice_No = aSearch.Ar_Invoice_No;
			Booking_No = aSearch.Booking_No;
			Customer_Cd = aSearch.Customer_Cd;
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
				Customer_Cd = MoveTypeCDs = POL_CDs = POD_CDs = PLOR_CDs = PLOD_CDs =
				Act_Orig_CDs = Act_Dest_CDs = Serial_No = Ar_Invoice_No = csvArInvoiceID = null;

			IncludeNonDoor = false;
			Ar_Invoice_ID = null;

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

			if (!string.IsNullOrEmpty(Ar_Invoice_No)) sb.AppendFormat(" AR Invoice # {0} ", Ar_Invoice_No);
			if (!string.IsNullOrEmpty(Booking_No)) sb.AppendFormat(" Booking # {0} ", Booking_No);
			if (!string.IsNullOrEmpty(Customer_Cd)) sb.AppendFormat(" Customer {0} ", Customer_Cd);
			if (!string.IsNullOrEmpty(PCFN)) sb.AppendFormat(" PCFN {0} ", PCFN);
			if (!string.IsNullOrEmpty(Serial_No)) sb.AppendFormat(" Serial # {0} ", Serial_No);
			if (!string.IsNullOrEmpty(PLOR_CDs)) sb.AppendFormat(" PLOR {0} ", PLOR_CDs);
			if (!string.IsNullOrEmpty(POL_CDs)) sb.AppendFormat(" POL {0} ", POL_CDs);
			if( !string.IsNullOrEmpty(POD_CDs) ) sb.AppendFormat(" POD {0} ", POD_CDs);
			if (!string.IsNullOrEmpty(PLOD_CDs)) sb.AppendFormat(" PLOD {0} ", PLOD_CDs);
			if (!string.IsNullOrEmpty(Act_Orig_CDs)) sb.AppendFormat(" Act Orig {0} ", Act_Orig_CDs);
			if (!string.IsNullOrEmpty(Act_Dest_CDs)) sb.AppendFormat(" Act Dest {0} ", Act_Dest_CDs);
			if (!string.IsNullOrEmpty(Vessel)) sb.AppendFormat(" Vessel {0} ", Vessel);
			if( !string.IsNullOrEmpty(VoyageNo) ) sb.AppendFormat(" VoyageNo {0} ", VoyageNo);
			if( !string.IsNullOrEmpty(StatusCDs) ) sb.AppendFormat(" ACMS Status {0} ", StatusCDs);
			if( !string.IsNullOrEmpty(MoveTypeCDs) ) sb.AppendFormat(" Move Type {0} ", MoveTypeCDs);
			if (IncludeNonDoor) sb.Append(" Including F1-F4 ");

			if (Ar_Invoice_ID.GetValueOrDefault(0) > 0) sb.AppendFormat(" ArInv ID {0} ", Ar_Invoice_ID);
			if (!string.IsNullOrEmpty(csvArInvoiceID)) sb.AppendFormat(" ArInv IDs {0} ", csvArInvoiceID);

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

			DataTable dtArInvoices = SearchAvailableGroups();
			ds.Tables.Add(dtArInvoices);

			if (dtArInvoices.Rows.Count > 0)
			{
				DataTable dtActivity = SearchAvailableActivities();
				ds.Tables.Add(dtActivity);

				DataColumn[] dcPK = new DataColumn[3];
				dcPK[0] = dtArInvoices.Columns["BK_VOYAGE_NO"];
				dcPK[1] = dtArInvoices.Columns["PORT_LOCATION_CD"];
				dcPK[2] = dtArInvoices.Columns["DIRECTION_IND"];

				DataColumn[] dcFK = new DataColumn[3];
				dcFK[0] = dtActivity.Columns["BK_VOYAGE_NO"];
				dcFK[1] = dtActivity.Columns["PORT_LOCATION_CD"];
				dcFK[2] = dtActivity.Columns["DIRECTION_IND"];

				ds.Relations.Add("ArInvoiceActivities", dcPK, dcFK, false);
			}

			return ds;
		}

		public DataTable SearchAvailableGroups()
		{
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
							(	select	count( arinv.ar_invoice_id)
								from	t_ar_invoice arinv
								where	 arinv.voyage_no = bk.voyage_no and
										 arinv.orig_location_cd = ca.orig_location_cd and
										 arinv.dest_location_cd = ca.dest_location_cd) > 0
							then 'Y'
						else	'N'
					end as exists_flg
			from	t_cargo_activity ca
					INNER JOIN t_conveyance cnv	on cnv.conveyance_id = ca.conveyance_id
					INNER JOIN t_cargo c		on c.cargo_id = ca.cargo_id
					INNER JOIN t_booking bk		on bk.booking_id = c.booking_id
					INNER JOIN r_location oloc	on oloc.location_cd = ca.orig_location_cd
					INNER JOIN r_location dloc	on dloc.location_cd = ca.dest_location_cd
		where cnv.ar_invoice_id is null ");

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

			DataTable dt = Connection.GetDataTable(sb.ToString(), p.ToArray());
			if (dt != null) dt.TableName = "ArInvoice";
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
						'UNKNOWN') as direction_txt
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
			WHERE ca.ar_invoice_id is null ");

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
				"bk.customer_cd", "@CUST_CD", ClsConvert.AddQuotes(Customer_Cd));
			Connection.AppendInClause(sb, p, "AND",
				"bk.customer_ref", "@PCSV", ClsConvert.AddQuotes(csvPCFN));
			Connection.AppendInClause(sb, p, "AND",
				"bk.booking_no", "@BK_CSV", ClsConvert.AddQuotes(csvBooking));
			Connection.AppendDateClause(sb, p, "AND",
				"bk.sail_dt", "@SAIL_FR", "@SAIL_TO", Vessel_Sail_Dt);

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

			DataTable dtArInvoices = SearchExistingArInvoices();
			ds.Tables.Add(dtArInvoices);

			if (dtArInvoices.Rows.Count > 0)
			{
				DataTable dtActivity = SearchExistingActivities();
				ds.Tables.Add(dtActivity);

				DataColumn[] dcPK = new DataColumn[1];
				dcPK[0] = dtArInvoices.Columns["AR_INVOICE_ID"];

				DataColumn[] dcFK = new DataColumn[1];
				dcFK[0] = dtActivity.Columns["AR_INVOICE_ID"];

				ds.Relations.Add("ArInvoiceActivities", dcPK, dcFK, false);
			}

			return ds;
		}

		public DataTable SearchExistingArInvoices()
		{
			/*
					decode( arinv.orig_location_cd, bk.plor_location_cd, 'DOOR TO PORT',
						bk.pod_location_cd, 'PORT TO DOOR', 'UNKNOWN') as direction_txt,
			*/
			List<DbParameter> p = new List<DbParameter>();
			StringBuilder sb = new StringBuilder(@"
			select	 arinv.ar_invoice_id,  arinv.create_user,  arinv.create_dt,  arinv.modify_user,  arinv.modify_dt,
					 arinv.invoice_no,  arinv.voyage_no,  arinv.orig_location_cd,
					oloc.location_dsc AS orig_location_dsc,  arinv.dest_location_cd,
					dloc.location_dsc AS dest_location_dsc,
					 arinv.invoice_dt,  arinv.accrued_dt,  arinv.mileage,
					 arinv.ap_status_cd,  arinv.ar_status_cd,  arinv.line_status_cd,
					decode(oloc.conus_flg, 'Y', 'CONUS', 'N', 'OCONUS', '?') as conus_txt,
					DECODE(oloc.location_type_cd, 'LAND', 'DOOR', 'PORT', 'PORT', 'UNKNOWN') ||
						' TO ' || DECODE(dloc.location_type_cd, 'LAND', 'DOOR', 'PORT', 'PORT',
						'UNKNOWN') as direction_txt,
					sum(decode(ca.orig_location_cd, null, 0,  arinv.orig_location_cd, 0, 1)) as mismatch_orig_count,
					sum(decode(ca.dest_location_cd, null, 0,  arinv.dest_location_cd, 0, 1)) as mismatch_dest_count,
					sum(decode(bk.voyage_no, null, 0,  arinv.voyage_no, 0, 1)) as mismatch_voy_count,
					(select count(ca2.cargo_activity_id) from t_cargo_activity ca2
						where ca2.ar_invoice_id =  arinv.ar_invoice_id) as act_count,
					nvl((select sum(total_amt) from t_ar_charge c1
						where c1.ar_invoice_id = arinv.ar_invoice_id), 0) as ar_inv_amt
			from	t_ar_invoice arinv
					INNER JOIN r_location oloc	on oloc.location_cd =  arinv.orig_location_cd
					INNER JOIN r_location dloc	on dloc.location_cd =  arinv.dest_location_cd
					left outer join t_cargo_activity ca
						INNER JOIN t_cargo c			on c.cargo_id = ca.cargo_id
						INNER JOIN t_booking bk			on bk.booking_id = c.booking_id
														on ca.ar_invoice_id =  arinv.ar_invoice_id
			where	1 = 1 ");

			AppendWhereExisting(sb, p, true);

			sb.Append(@"
			group by	 arinv.ar_invoice_id,  arinv.create_user,  arinv.create_dt,  arinv.modify_user,  arinv.modify_dt,
						 arinv.invoice_no,  arinv.voyage_no,  arinv.orig_location_cd, oloc.location_dsc,
						 arinv.dest_location_cd, dloc.location_dsc,
						 arinv.invoice_dt,  arinv.accrued_dt,  arinv.mileage,
						 arinv.ap_status_cd,  arinv.ar_status_cd,  arinv.line_status_cd,
						decode(oloc.conus_flg, 'Y', 'CONUS', 'N', 'OCONUS', '?'),
						DECODE(oloc.location_type_cd, 'LAND', 'DOOR', 'PORT', 'PORT', 'UNKNOWN') ||
							' TO ' || DECODE(dloc.location_type_cd, 'LAND', 'DOOR', 'PORT', 'PORT',
							'UNKNOWN')
			order by	 arinv.voyage_no, direction_txt, oloc.location_dsc, dloc.location_dsc ");

			DataTable dt = Connection.GetDataTable(sb.ToString(), p.ToArray());
			if (dt != null)
			{
				dt.TableName = "ArInvoice";
			}
			return dt;
		}

		/*
					decode( arinv.orig_location_cd, bk.plor_location_cd, 'DOOR TO PORT',
						bk.pod_location_cd, 'PORT TO DOOR', 'UNKNOWN') as direction_txt,
		*/
		public readonly string SqlExistingActs = @"
			select	ca.*,  arinv.*, c.item_no, c.cube_ft, c.m_tons, c.dim_weight_nbr,
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
					decode(ca.orig_location_cd, null, 0,  arinv.orig_location_cd, 0, 1) as mismatch_orig,
					decode(ca.dest_location_cd, null, 0,  arinv.dest_location_cd, 0, 1) as mismatch_dest,
					decode(bk.voyage_no, null, 0,  arinv.voyage_no, 0, 1) as mismatch_voy,
					decode(ploc.conus_flg, 'Y', 'CONUS', 'N', 'OCONUS', '?') as conus_txt,
					arinv.direction_ind as direction_txt,
					cmod.mod_no, cmod.attachment_nm,
					DECODE(cmod.contract_mod_id, NULL, NULL, cmod.mod_no || ' - ' ||
						NVL(cmod.attachment_nm, '<No Attachment>')) AS mod_no_attachment_nm,
					nvl((select sum(ardtl.activity_amt) from t_ar_charge_dtl ardtl
							INNER JOIN t_ar_charge archg on archg.ar_charge_id = ardtl.ar_charge_id
							where ardtl.cargo_activity_id = ca.cargo_activity_id), 0) as ar_total_amt
			from	t_ar_invoice arinv
					INNER JOIN r_location ploc			ON ploc.location_cd = arinv.port_location_cd
					INNER JOIN t_cargo_activity ca		ON ca.ar_invoice_id =  arinv.ar_invoice_id
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

			AppendWhereExisting(sb, p, false);

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

		public DataTable SearchExistingActivities(long? archgID, bool exists)
		{
			List<DbParameter> p = new List<DbParameter>();
			StringBuilder sb = new StringBuilder(SqlExistingActs);

			AppendWhereExisting(sb, p, false);

			if (archgID != null)
			{
				sb.AppendFormat(@"AND
				{0} EXISTS (
					SELECT	'X'
					FROM	t_ar_charge_dtl ardtl
					WHERE	ardtl.cargo_activity_id = ca.cargo_activity_id AND
							ardtl.ar_charge_id = {1}
						) ", (exists ? null : "NOT"), archgID.Value);
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

		public DataTable SearchExistingActivitiesChargeType(long? archgID, string chgCd, string catCd,
			bool exists)
		{
			List<DbParameter> p = new List<DbParameter>();
			StringBuilder sb = new StringBuilder(SqlExistingActs);

			AppendWhereExisting(sb, p, false);

			if (archgID != null || string.IsNullOrEmpty(chgCd) == false)
			{
				sb.AppendFormat(@"AND
				{0} EXISTS (
					SELECT	'X'
					FROM	t_ar_charge_dtl ardtl
							INNER JOIN t_ar_charge archg	ON archg.ar_charge_id = ardtl.ar_charge_id
							INNER JOIN r_charge_type cht		ON cht.charge_type_cd = archg.charge_type_cd
					WHERE	ardtl.cargo_activity_id = ca.cargo_activity_id AND
							(", (exists ? null : "NOT"));

				Connection.AppendEqualClause(sb, p, null, "ardtl.ar_charge_id", "@CHG_ID", archgID);
				string logType = (archgID != null) ? "OR" : null;
				Connection.AppendEqualClause(sb, p, logType, "archg.charge_type_cd", "@CHT_CD", chgCd);
				logType = (archgID != null || string.IsNullOrEmpty(chgCd) == false) ? "OR" : null;
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
			SELECT	ardtl.*, archg.charge_type_cd, cht.charge_type_dsc, cht.charge_category_cd,
					archg.tcn_count, archg.rate_amt, archg.total_amt, archg.memo,
					archg.finance_cd, lvu.level_unit_dsc, lvu.level_cd, lvu.unit_type_cd,
					lvu.level_count_dsc, lvu.unit_qty_dsc, lvu.average_flg, ut.units_required_flg,
					decode(lvu.average_flg, 'N', null,
						archg.level_count || ' ' || lvu.level_count_dsc) AS level_disp,
					decode(ut.units_required_flg, 'Y', archg.unit_qty || ' ' || ut.grid_column_dsc,
						null) AS unit_disp,
					decode(lvu.average_flg, 'N', nvl(ardtl.activity_unit_qty, 0) ||
						decode(ut.units_required_flg, 'Y', ' ' || ut.grid_column_dsc, null),
						null) AS act_unit_disp,
					ardtl.activity_amt AS adj_activity_amt
			FROM	t_ar_charge_dtl ardtl
					INNER JOIN t_ar_charge archg	ON archg.ar_charge_id = ardtl.ar_charge_id
					INNER JOIN r_charge_type cht		ON cht.charge_type_cd = archg.charge_type_cd
					INNER JOIN r_level_unit lvu			ON lvu.level_unit_id = archg.level_unit_id
					INNER JOIN r_unit_type ut			ON ut.unit_type_cd = lvu.unit_type_cd
			WHERE	archg.ar_invoice_id = @AR_INV_ID");

			List<DbParameter> p = new List<DbParameter>();
			p.Add(Connection.GetParameter("@AR_INV_ID", Ar_Invoice_ID.GetValueOrDefault(-1)));

			sb.Append(@"
			order by archg.ar_invoice_id, cht.charge_category_cd, cht.charge_type_dsc ");

			DataTable dt = Connection.GetDataTable(sb.ToString(), p.ToArray());
			if (dt != null)
			{
				dt.TableName = "ActivityCharges";
			}
			return dt;
		}

		public void AppendWhereExisting(StringBuilder sb, List<DbParameter> p, bool isParent)
		{
			if (Ar_Invoice_ID != null)
				Connection.AppendEqualClause(sb, p, "AND", " arinv.ar_invoice_id", "@AR_INV_ID", Ar_Invoice_ID);
			else
				Connection.AppendInClause(sb, p, "AND", " arinv.ar_invoice_id", "@AR_INV_CSV", csvArInvoiceID);

			Connection.AppendLikeClause(sb, p, "AND",
				" arinv.invoice_no", "@AR_INV_NO", Ar_Invoice_No);
			Connection.AppendLikeClause(sb, p, "AND",
				" arinv.voyage_no", "@VOY_NO", VoyageNo);
			Connection.AppendInClause(sb, p, "AND",
				" arinv.orig_location_cd", "@ACT_ORIG_CD", ClsConvert.AddQuotes(Act_Orig_CDs));
			Connection.AppendInClause(sb, p, "AND",
				" arinv.dest_location_cd", "@ACT_DEST_CD", ClsConvert.AddQuotes(Act_Dest_CDs));

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

			DataTable dtArInvoices = SearchChargeGroups();
			ds.Tables.Add(dtArInvoices);

			if (dtArInvoices.Rows.Count > 0)
			{
				DataTable dtChg = SearchChargeDetail();
				ds.Tables.Add(dtChg);

				DataColumn[] dcPK = new DataColumn[1];
				dcPK[0] = dtArInvoices.Columns["AR_INVOICE_ID"];

				DataColumn[] dcFK = new DataColumn[1];
				dcFK[0] = dtChg.Columns["AR_INVOICE_ID"];

				ds.Relations.Add("ArInvoiceCharges", dcPK, dcFK, false);
			}

			return ds;
		}

		public DataTable SearchChargeGroups()
		{
			/*
					decode( arinv.orig_location_cd, bk.plor_location_cd, 'DOOR TO PORT',
						bk.pod_location_cd, 'PORT TO DOOR', 'UNKNOWN') as direction_txt,
			*/
			List<DbParameter> p = new List<DbParameter>();
			StringBuilder sb = new StringBuilder(@"
			select	nvl((select sum(total_amt) from t_ar_charge c1 where c1.ar_invoice_id =  arinv.ar_invoice_id
						), 0) as ar_inv_amt,
					 arinv.ar_invoice_id,  arinv.create_user,  arinv.create_dt,  arinv.modify_user,  arinv.modify_dt,
					 arinv.invoice_no,  arinv.voyage_no,  arinv.orig_location_cd,  arinv.dest_location_cd,
					 arinv.invoice_dt,  arinv.accrued_dt,  arinv.mileage,
					oloc.location_dsc AS orig_location_dsc,
					dloc.location_dsc AS dest_location_dsc,
					decode(oloc.conus_flg, 'Y', 'CONUS', 'N', 'OCONUS', '?') as conus_txt,
					DECODE(oloc.location_type_cd, 'LAND', 'DOOR', 'PORT', 'PORT', 'UNKNOWN') ||
						' TO ' || DECODE(dloc.location_type_cd, 'LAND', 'DOOR', 'PORT', 'PORT',
						'UNKNOWN') as direction_txt,
					count(distinct ca.cargo_activity_id) as act_count,
					count(distinct archg.ar_charge_id) as chg_count
			from	t_ar_invoice arinv
					INNER JOIN r_location oloc				on oloc.location_cd =  arinv.orig_location_cd
					INNER JOIN r_location dloc				on dloc.location_cd =  arinv.dest_location_cd
					left outer join t_ar_charge archg	on archg.ar_invoice_id =  arinv.ar_invoice_id
					left outer join t_cargo_activity ca
						INNER JOIN t_cargo c				on c.cargo_id = ca.cargo_id
						INNER JOIN t_booking bk				on bk.booking_id = c.booking_id
															on ca.ar_invoice_id =  arinv.ar_invoice_id
			where	1 = 1 ");

			AppendWhereExisting(sb, p, true);

			sb.Append(@"
			group by	 arinv.ar_invoice_id,  arinv.create_user,  arinv.create_dt,  arinv.modify_user,  arinv.modify_dt,
						 arinv.invoice_no,  arinv.voyage_no,  arinv.orig_location_cd,  arinv.dest_location_cd,
						 arinv.invoice_dt,  arinv.accrued_dt,  arinv.mileage,
						oloc.location_dsc, dloc.location_dsc,
						decode(oloc.conus_flg, 'Y', 'CONUS', 'N', 'OCONUS', '?'),
						DECODE(oloc.location_type_cd, 'LAND', 'DOOR', 'PORT', 'PORT', 'UNKNOWN') ||
							' TO ' || DECODE(dloc.location_type_cd, 'LAND', 'DOOR', 'PORT', 'PORT',
							'UNKNOWN')
			order by	 arinv.voyage_no, direction_txt,  arinv.orig_location_cd,  arinv.dest_location_cd ");

			DataTable dt = Connection.GetDataTable(sb.ToString(), p.ToArray());
			if (dt != null)
			{
				dt.TableName = "ArInvoice";
			}
			return dt;
		}

		public DataTable SearchChargeDetail()
		{
			List<DbParameter> p = new List<DbParameter>();
			StringBuilder sb = new StringBuilder(@"
			select	decode(archg.finance_cd, 'AR', archg.total_amt, -archg.total_amt) as signed_total_amt,
					archg.*, cht.charge_category_cd,
					lvu.level_unit_dsc, lvu.level_cd, lvu.unit_type_cd, lvu.level_count_dsc,
					lvu.unit_qty_dsc, lvu.average_flg, ut.units_required_flg,
					decode(lvu.average_flg, 'N', null,
						archg.level_count || ' ' || lvu.level_count_dsc) AS level_disp,
					decode(ut.units_required_flg, 'Y', archg.unit_qty || ' ' || ut.grid_column_dsc,
						null) as unit_disp,
					arinv2.voyage_no, arinv2.orig_location_cd, arinv2.dest_location_cd, arinv2.ar_invoice_id,
					arinv2.invoice_no,
					ploc.location_dsc as port_location_dsc,
					decode(ploc.conus_flg, 'Y', 'CONUS', 'N', 'OCONUS', '?') as conus_txt
			from	t_ar_charge archg
					INNER JOIN r_charge_type cht	on cht.charge_type_cd = archg.charge_type_cd
					INNER JOIN r_level_unit lvu		on lvu.level_unit_id = archg.level_unit_id 
					INNER JOIN r_unit_type ut		on ut.unit_type_cd = lvu.unit_type_cd
					INNER JOIN t_ar_invoice arinv2	on arinv2.ar_invoice_id = archg.ar_invoice_id
					INNER JOIN r_location ploc		on ploc.location_cd = arinv2.port_location_cd ");


			StringBuilder sbWhere = new StringBuilder();
			AppendWhereCharges(sbWhere, p);
			if( sbWhere.Length > 0 )
			{
				StringBuilder sbWith = new StringBuilder(@"
			WITH ar_inv_hdr AS
				(
					select	 arinv.ar_invoice_id
					from	t_ar_invoice arinv
						left outer join t_cargo_activity ca
							INNER JOIN t_cargo c			on c.cargo_id = ca.cargo_id
							INNER JOIN t_booking bk			on bk.booking_id = c.booking_id
															on ca.ar_invoice_id =  arinv.ar_invoice_id
					WHERE 1 = 1 ");
				sbWith.Append(sbWhere);
				sbWith.Append(@"
					group by  arinv.ar_invoice_id
				)");
				sb.Insert(0, sbWith);
				sb.Append(@"
					INNER JOIN ar_inv_hdr mh on mh.ar_invoice_id = arinv2.ar_invoice_id");
			}

			sb.Append(@"
			order by	arinv2.voyage_no, arinv2.orig_location_cd, arinv2.dest_location_cd,
						archg.finance_cd, cht.charge_category_cd, lvu.level_cd, archg.charge_type_cd,
						lvu.unit_type_cd, archg.total_amt ");

			DataTable dt = Connection.GetDataTable(sb.ToString(), p.ToArray());
			if (dt != null)
			{
				dt.TableName = "Charges";
			}
			return dt;
		}

		public void AppendWhereCharges(StringBuilder sb, List<DbParameter> p)
		{
			if (Ar_Invoice_ID != null)
				Connection.AppendEqualClause(sb, p, "AND", " arinv.ar_invoice_id", "@AR_INV_ID", Ar_Invoice_ID);
			else
				Connection.AppendInClause(sb, p, "AND", " arinv.ar_invoice_id", "@AR_INV_CSV", csvArInvoiceID);

			Connection.AppendLikeClause(sb, p, "AND",
				" arinv.invoice_no", "@AR_INV_NO", Ar_Invoice_No);
			Connection.AppendLikeClause(sb, p, "AND",
				" arinv.voyage_no", "@VOY_NO", VoyageNo);
			Connection.AppendInClause(sb, p, "AND",
				" arinv.orig_location_cd", "@ACT_ORIG_CD", ClsConvert.AddQuotes(Act_Orig_CDs));
			Connection.AppendInClause(sb, p, "AND",
				" arinv.dest_location_cd", "@ACT_DEST_CD", ClsConvert.AddQuotes(Act_Dest_CDs));

			Connection.AppendLikeClause(sb, p, "AND",
				"bk.customer_ref", "@PCFN", PCFN);
			Connection.AppendLikeClause(sb, p, "AND",
				"bk.booking_no", "@BK_NO", Booking_No);
			Connection.AppendInClause(sb, p, "AND",
				"bk.customer_ref", "@PCSV", ClsConvert.AddQuotes(csvPCFN));
			Connection.AppendInClause(sb, p, "AND",
				"bk.booking_no", "@BK_CSV", ClsConvert.AddQuotes(csvBooking));

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
	}
}