using System;
using System.Data;
using System.Text;
using System.Drawing;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;
using CS2010.ArcSys.Business;

namespace CS2010.ACMS.Business
{
	partial class ClsBookingUnit
	{
		#region Properties
		private ClsBooking _Booking;
		public ClsBooking Booking
		{
			get
			{
				if (_Booking == null)
					_Booking = ClsBooking.GetUsingKey(this.Partner_Cd, this.Partner_Request_Cd);
				return _Booking;
			}

		}
		private ClsVVoyage _Voyage;
		public ClsVVoyage Voyage
		{
			get
			{
				if (_Voyage != null)
					return _Voyage;
				_Voyage = GetVoyage(this.Voyage_No);
				return _Voyage;
			}
			set
			{
				_Voyage = value;
			}
		}
		private ClsLocation _POL;
		public ClsLocation POL
		{
			get
			{
				if (_POL != null)
					return _POL;
				if (POLTerminal == null)
					return _POL;
				_POL = ClsLocation.GetUsingKey(POLTerminal.Location_Cd);
				return _POL;
			}
		}
		private ClsLocationTerminal _POLTerminal;
		public ClsLocationTerminal POLTerminal
		{
			get
			{
				if (_POLTerminal != null)
					return _POLTerminal;
				_POLTerminal = ClsLocationTerminal.GetUsingKey(this.Poe_Terminal_Cd);
				return _POLTerminal;
			}
		}
		private ClsLocation _POD;
		public ClsLocation POD
		{
			get
			{
				if (_POD != null)
					return _POD;
				if (PODTerminal == null)
					return null;
				_POD = ClsLocation.GetUsingKey(PODTerminal.Location_Cd);
				return _POD;
			}
		}
		private ClsLocationTerminal _PODTerminal;
		public ClsLocationTerminal PODTerminal
		{
			get
			{
				if (_PODTerminal != null)
					return _PODTerminal;
				_PODTerminal = ClsLocationTerminal.GetUsingKey(this.Pod_Terminal_Cd);
				return _PODTerminal;
			}
		}
		private DataTable _StenaRoute;
		public DataTable StenaRoute
		{
			get
			{
				if (_StenaRoute != null)
					return _StenaRoute;
				_StenaRoute = GetStenaRoute();
				return _StenaRoute;
			}
		}
		public bool IsStenaBooking
		{
			get
			{
				if (StenaRoute == null)
					return false;
				if (StenaRoute.Rows.Count < 1)
					return false;
				return true;
			}
		}
		#endregion

		#region Methods
		public bool BookingLevelChanged(ClsBookingUnit oldUnit)
		{
			// If the user changes any of these columns, it suggest
			// that perhaps they want to change the information at the booking
			// level.
			if (this.Cargo_ID != oldUnit.Cargo_ID ||
				this.Commodity_Cd != oldUnit.Commodity_Cd ||
				this.Rev_Cd != oldUnit.Rev_Cd ||
				this.Wt_Nbr != oldUnit.Wt_Nbr ||
				this.Width_Nbr != oldUnit.Width_Nbr ||
				this.Length_Nbr != oldUnit.Length_Nbr ||
				this.Height_Nbr != oldUnit.Height_Nbr ||
				this.Voyage_No != oldUnit.Voyage_No ||
				this.Pod_Location_Cd != oldUnit.Pod_Location_Cd ||
				this.Pod_Terminal_Cd != oldUnit.Pod_Terminal_Cd ||
				this.Poe_Location_Cd != oldUnit.Poe_Location_Cd ||
				this.Poe_Terminal_Cd != oldUnit.Poe_Terminal_Cd)
				return true;

			return false;
		}

		public DataTable GetStenaRoute()
		{
			try
			{
				string sql = string.Format(@"
				select sr.* 
				from v_stena_route sr
				 inner join t_booking_unit bu
				  on sr.pol_location_cd = bu.poe_location_cd
				  and sr.pod_location_cd = bu.pod_location_cd
				   where bu.partner_request_cd like '{0}' ", this.Partner_Request_Cd);
				DataTable dt = Connection.GetDataTable(sql);
				return dt;
			}
			catch (Exception ex)
			{
				ClsErrorHandler.LogException(ex);
				return null;
			}
		}

		public override bool ValidateUpdate()
		{
			// First update dependent fields
			if (this.Voyage != null)
				this.Vessel_Cd = Voyage.Vessel_Cd;
			_POD = null;
			_POL = null;
			if (POL != null)
				this.Poe_Location_Cd = POL.Location_Cd;
			if (POD !=null)
				this.Pod_Location_Cd = POD.Location_Cd;
			return true;
		}

		public void UpdateBookingData(ClsBookingUnit bu)
		{
			_Errors.Clear();
			try
			{
				// Copies the booking-level data from one piece of cargo to this one
				this.Width_Nbr = bu.Width_Nbr;
				this.Wt_Nbr = bu.Wt_Nbr;
				this.Length_Nbr = bu.Length_Nbr;
				this.Width_Nbr = bu.Width_Nbr;
				this.Height_Nbr = bu.Height_Nbr;
				this.Rev_Cd = bu.Rev_Cd;
				this.Commodity_Cd = bu.Commodity_Cd;
				this.Cargo_ID = bu.Cargo_ID;
				this.Voyage_No = bu.Voyage_No;
				this.Vessel_Cd = bu.Vessel_Cd;
				this.Poe_Location_Cd = bu.Poe_Location_Cd;
				this.Poe_Terminal_Cd = bu.Poe_Terminal_Cd;
				this.Pod_Location_Cd = bu.Pod_Location_Cd;
				this.Pod_Terminal_Cd = bu.Pod_Terminal_Cd;
				this.Update();
				this.PostUpdate();
			}
			catch (Exception ex)
			{
				ClsErrorHandler.LogException(ex);
				_Errors.Add("Save", ex.Message);
			}
		}

		public void PostUpdate()
		{
			// Temporary
			// Fudges the id_sub to always include a space.  This is because
			// the code generator automatically trims spaces away.
			string sql = string.Format(@"
					update t_booking_unit
					 set booking_id_sub = ' '
					 where booking_id like '{0}'
					   and tcn = '{1}'
					   and length(booking_id_sub) is null ",
						this.Booking_ID, this.Tcn);
			Connection.RunSQL(sql);
			sql = string.Format(@"
				update t_booking_unit
				 set volume_nbr = ediuser.f_cube_ft (length_nbr, width_nbr, height_nbr)
				  where partner_request_cd like '%16'
				 and abs(volume_nbr - ediuser.f_cube_ft (length_nbr, width_nbr, height_nbr)) > 5
				 and booking_id = '{0}' ", this.Booking_ID);
			Connection.RunSQL(sql);
		}

		public bool SaveUnit()
		{
			// This is just needed so the Update and PostUpdate can be called within a single transaction
			bool bInTrans = Connection.IsInTransaction;
			if (!bInTrans)
				Connection.TransactionStart();
			try
			{
				this.Update();
				this.PostUpdate();
				if (!bInTrans)
				{
					Connection.TransactionCommit();
				}
				return true;
			}
			catch (Exception ex)
			{
				if (!bInTrans)
					Connection.TransactionRollback();
				throw;
			}

		}
		public void AALPreFills()
		{
			// For AAL, if the cargo_id and rev_cd have not already been filled-in, do it now.
			if (this.Partner_Cd != "AAL")
				return;
			bool bChanged = false;
			if (string.IsNullOrEmpty(this.Rev_Cd))
			{
				this.Rev_Cd = "AAL";
				bChanged = true;
			}
			if (this.Cargo_ID == null)
			{
				bChanged = true;
				switch (this.Item_Dsc)
				{
					case "A":
						this.Cargo_ID = 26;
						break;
					case "B":
						this.Cargo_ID = 24;
						break;
					case "C":
						this.Cargo_ID = 49;
						break;
				}
				if (!bChanged)
					return;
				this.Update();
			}
			
		}

		public bool CloneCargo(Int32 iCopies)
		{
			this._Errors.Clear();
			bool bInTrans = Connection.IsInTransaction;
			if (!bInTrans)
				Connection.TransactionStart();
			try
			{
				if (iCopies < 1)
				{
					_Errors.Add("Clone", "You must specify a quantity of at least 1");
					if (!bInTrans)
						Connection.TransactionRollback();
					return false;
				}
				int iCount = 0;
				Int32 iSeqNo = this.BookingRequest.LastCargoItemNo + 1;
				while (iCount < iCopies)
				{
					DataRow drow = this.BookingRequest.BookingUnits.Rows[0];
					this.CopyToDataRow(drow);
					ClsBookingUnit buNew = new ClsBookingUnit(drow);
					buNew.Item_No = iSeqNo;
					buNew.Tcn = "NA";
					buNew.Insert();
					iSeqNo++;
					iCount++;
				}
				if (!bInTrans)
					Connection.TransactionCommit();
				return true;
			}
			catch (Exception ex)
			{
				ClsErrorHandler.LogException(ex);
				_Errors.Add("Clone", ex.Message);
				if (!bInTrans)
					Connection.TransactionRollback();
				return false;
			}

		}

		public bool DeleteCargo()
		{
			_Errors.Clear();
			try
			{
				string sql = string.Format(@"
				delete from t_booking_unit
					where booking_id = '{0}'
					  and item_no = {1} ", this.Booking_ID, this.Item_No);
				Connection.RunSQL(sql);
				return true;
			}
			catch (Exception ex)
			{
				ClsErrorHandler.LogException(ex);
				_Errors.Add("Delete", ex.Message);
				return false;
			}
		}

		#endregion

		#region Static Methods

		public static ClsVVoyage GetVoyage(string sVoyage)
		{
			string sql = string.Format(@"
				select * from t_voyage where voyage_cd = '{0}' ", sVoyage);
			DataRow dr = Connection.GetDataRow(sql);
			if (dr == null)
				return null;
			ClsVVoyage v = new ClsVVoyage(dr);
			return v;
		}

		public static DataTable GetLoadList(string voyageNo, string[] pcfns)
		{
			StringBuilder sb = new StringBuilder(@"
			SELECT	DISTINCT '' AS ""VAN TYPE"", 
					bu.tcn, 
					sbk.trailer_no AS ""CONTAINER NUMBER"",
					 (select max(dodaac)
					  from t_booking_party p where p.partner_cd = bu.partner_cd
											   and p.partner_request_cd = bu.partner_request_cd
											   and p.party_type_cd = 'CI') as ""CONSIGNOR DODAAC"",
					SUBSTR(vyg.voyage_Cd, 1, 5) AS ""COMM VSLVOY"",
					NVL(tpod.other1_cd, pod.other1_cd) AS POD,
					bu.booking_id AS ""COMMERCIAL BOOKING NUMBER"",
					SUBSTR(bk.partner_request_cd, 1, 6) AS pcfn,
					brq.move_type_cd AS ""VESSEL STATUS"", 
					 (select max(dodaac)
					  from t_booking_party p where p.partner_cd = bu.partner_cd
											   and p.partner_request_cd = bu.partner_request_cd
											   and p.party_type_cd = 'CN') as ""CONSIGNEE DODAAC"",
					item_dsc AS ""CARGO DESCRIPTION"",
					ediuser.f_cube_ft(bu.length_nbr, bu.width_nbr, bu.height_nbr) AS CUBE,
					bu.LENGTH_NBR AS length, bu.WIDTH_NBR AS width,	bu.HEIGHT_NBR AS height, 
					bu.WT_NBR AS weight,
					/*ROUND(ediuser.f_cube_ft(bu.length_nbr, bu.width_nbr, bu.height_nbr) / 40, 3) AS MTON, */
					ediuser.f_mton(bu.length_nbr, bu.width_nbr, bu.height_nbr) as MTON,
					CASE
						WHEN bu.booking_id IS NULL THEN 'N'
						ELSE 'Y'
					END AS ""IS BOOKED (Y/N)"",
					'Y' AS ""HAS SI (Y/N)"", 
					bl.cargo_bol_no as "" Ocean Bill of Lading"",
					'' AS ""COMMENT ONE"", 
					'' AS ""COMMENT TWO"",
					to_char(f_get_arrive_dt(bu.voyage_no,bu.pod_terminal_cd),'mm-dd-yyyy') as ""DATE OF POD ARRIVAL"",
					/*to_char(f_get_arrive_dt(bu.voyage_no,bu.pod_terminal_cd),'hh:mm')*/ '' as ""TIME OF POD ARRIVAL"",
					v.vessel_dsc as ""NAME OF POD VESSEL"",
					NVL(tpod.other1_cd, pod.other1_cd) AS ""POD COMMERCIAL VOYAGE NUMBER"",
					'' as ""SEAL NUMBER"",
					commodity_cd AS COMMODITY,
					to_char(bu.adj_rdd_dt, 'mm-dd-yyyy') AS ""Rdd Dt"",
					to_char((	SELECT	MAX(etd_dt)
						FROM	t_voyage_route_detail
						WHERE	voyage_cd = bu.voyage_no AND location_cd = location_poe_cd),'MM-DD-YY') AS ""Lift On"",
					bu.UNITS_NBR AS ""Pcs"",
					NVL(tpoe.other1_cd, poe.other1_cd) AS POL,
					bu.poe_terminal_cd AS ""Terminal"",
					f_original_pod_location_cd(brq.partner_request_cd) AS ""ReqPOD"",
					bk.location_plod_cd AS PLOD, volume_nbr AS ""SDDC cbft"",
					(	SELECT	MAX(move_type_cd)
						FROM 	t_booking_request 
						WHERE	t_booking_request.partner_request_cd = bk.partner_request_cd
						AND		t_booking_request.partner_cd = bk.partner_cd) AS ""move type cd""
			FROM	t_booking_unit bu
					INNER JOIN t_voyage vyg								ON (bu.voyage_no = vyg.voyage_cd)
					inner join r_vessel v on v.vessel_cd = vyg.vessel_cd
					INNER JOIN t_booking bk								ON (bu.partner_request_cd = bk.partner_request_cd)
					INNER JOIN t_booking_request brq					ON (bu.partner_request_cd = brq.partner_request_cd AND
																			acms_status_cd not in ('D','A','X'))
					INNER JOIN r_location poe							ON (bu.poe_location_cd = poe.location_cd)
					INNER JOIN r_location_terminal tpoe					ON (poe.location_cd = tpoe.location_cd AND
																			tpoe.terminal_cd = bu.poe_terminal_cd)
					INNER JOIN r_location pod							ON (bu.pod_location_cd = pod.location_cd)
					inner join r_location_terminal tpod on (pod.location_cd = tpod.location_cd) and (bu.pod_terminal_cd = tpod.terminal_cd)
					left outer JOIN v_booking_cargo_line<DBLINK>ArcSys bl on (UPPER(TRIM(bl.booking_no)) = UPPER(TRIM(bu.booking_ID)) AND
																	    UPPER(TRIM(bl.serial_no)) = UPPER(TRIM(bu.tcn)))
					LEFT OUTER JOIN t_stena_booking<DBLINK>ARCSYS sbk	ON (UPPER(TRIM(sbk.booking_no)) =
																			UPPER(TRIM(bu.booking_id))AND
																			UPPER(TRIM(sbk.serial_no)) =
																			UPPER(TRIM(bu.tcn)))
			WHERE	1 = 1
			");

			List<DbParameter> p = new List<DbParameter>();
			Connection.AppendLikeClause(sb, p, "AND", "bu.voyage_no", "@VYGNO", ClsConvert.AddWildCard(voyageNo));
			Connection.AppendInClause3(sb, p, "AND", "bu.partner_request_cd", "@PCFNV", pcfns);
			string sql = sb.ToString();
			DataTable dt = Connection.GetDataTable(sql, p.ToArray());

            foreach (DataRow drow in dt.Rows)
            {
                string sPOD = drow["POD"].ToString();
                string sReqPOD = drow["ReqPOD"].ToString();

                if (sPOD == "JF1" && sReqPOD == "KF3")
                {
                    drow["POD"] = "KF3";
                }
                if (sPOD == "JF1" && sReqPOD == "JA9")
                {
                    drow["POD"] = "JA9";
                }
                if (sPOD == "JF1" && sReqPOD == "LD1")
                {
                    drow["POD"] = "LD1";
                }

            }
			return dt;
		}

		public static DataTable GetLoadListPAT(string voyageNo, string[] pcfns)
		{
			StringBuilder sb = new StringBuilder(@"
			SELECT	DISTINCT '' AS van_type, 
					bu.tcn, 
					sbk.trailer_no AS container_no,
					req_dodaac AS consignor_dodaac,
					vyg.voyage_Cd voyage_no,
					/*pod.other1_cd AS POD_location_cd, */
					NVL(tpod.other1_cd, pod.other1_cd) AS POD_location_cd,
					bu.booking_id AS booking_no,
					SUBSTR(bk.partner_request_cd, 1, 6) AS pcfn,
					brq.move_type_cd AS vessel_status_cd,
					rcvr_dodaac AS consignee_dodaac,
					bu.item_dsc AS cargo_dsc,
					ediuser.f_cube_ft(length_nbr, width_nbr, height_nbr) AS CUBE_nbr,
					bu.LENGTH_NBR AS length_nbr, 
					bu.WIDTH_NBR AS width_nbr,	
					bu.HEIGHT_NBR AS height_nbr, 
					bu.WT_NBR AS weight_nbr,
					/*ROUND(ediuser.f_cube_ft(length_nbr, width_nbr, height_nbr) / 40, 3) AS MTON_nbr,*/
					ediuser.f_mton(bu.length_nbr, bu.width_nbr, bu.height_nbr) as MTON_nbr,
					CASE
						WHEN bu.booking_id IS NULL THEN 'N'
						ELSE 'Y'
					END AS booked_flg,
					'Y' AS si_flg,
					'' AS comment_one, 
					'' AS comment_two,
					bu.commodity_cd as commodity_cd,
					bu.adj_rdd_dt AS rdd_dt,
					(	SELECT	MAX(etd_dt)
						FROM	t_voyage_route_detail
						WHERE	voyage_cd = bu.voyage_no AND location_cd = location_poe_cd) AS lifton_dt,
					bu.UNITS_NBR AS pcs_nbr,
					NVL(tpoe.other1_cd, poe.other1_cd) AS POL_location_cd,
					bu.poe_terminal_cd AS pol_berth_cd,
					f_original_pod_location_cd(brq.partner_request_cd) AS req_pod_location_cd,
					bk.location_plod_cd AS PLOD, volume_nbr AS SDDC_cbft,
					(	SELECT	MAX(move_type_cd)
						FROM 	t_booking_request 
						WHERE	t_booking_request.partner_request_cd = bk.partner_request_cd
						AND		t_booking_request.partner_cd = bk.partner_cd) AS move_type_cd,
					null as lob_detail_id,
					null as lob_header_id,
					'N' as manifested_flg,
					null as create_user,
					null as create_dt,
					null as modify_user,
					null as modify_dt,
					 case
						 when f_activity_dt(bu.booking_id, bu.item_no,'VD') is null then 'N'
						   else 'Y' end as vd_flg,
					brq.move_type_cd as vessel_status_cd,
					cl.cargo_status, 
					cl.bol_no as cargo_bol_no,
                    vyg.vessel_cd
			FROM	t_booking_unit bu
					INNER JOIN t_voyage vyg								ON (bu.voyage_no = vyg.voyage_cd)
					inner join r_vessel v on v.vessel_cd = vyg.vessel_cd
					INNER JOIN t_booking bk								ON (bu.partner_request_cd = bk.partner_request_cd)
					INNER JOIN t_booking_request brq					ON (bu.partner_request_cd = brq.partner_request_cd AND
																			acms_status_cd not in ('D','A','X'))
					INNER JOIN r_location poe							ON (bu.poe_location_cd = poe.location_cd)
					INNER JOIN r_location_terminal tpoe					ON (poe.location_cd = tpoe.location_cd AND
																			tpoe.terminal_cd = bu.poe_terminal_cd)
					INNER JOIN r_location pod							ON (bu.pod_location_cd = pod.location_cd)
					inner join r_location_terminal tpod on (pod.location_cd = tpod.location_cd) and (bu.pod_terminal_cd = tpod.terminal_cd)
         INNER JOIN t_booking_line<DBLINK>ArcSys bl on bl.booking_no = bu.booking_id
         inner join t_cargo_line<DBLINK>ArcSys cl on bl.booking_line_id = cl.booking_line_id 
            and cl.serial_no = bu.tcn

					LEFT OUTER JOIN t_stena_booking<DBLINK>ARCSYS sbk	ON (UPPER(TRIM(sbk.booking_no)) =
																			UPPER(TRIM(bu.booking_id))AND
																			UPPER(TRIM(sbk.serial_no)) =
																			UPPER(TRIM(bu.tcn)))
			WHERE	1 = 1
			  and 	bu.voyage_no like '@VOYAGENO'
			  and   bu.partner_request_cd in (@PCFN) 
			  and cl.bol_no is not null
			");

			sb.Replace("@VOYAGENO", voyageNo);
			List<DbParameter> p = new List<DbParameter>();
			//Connection.AppendLikeClause(sb, p, "AND", "bu.voyage_no", "@VYGNO", ClsConvert.AddWildCard(voyageNo));
			StringBuilder sbPcfns = new StringBuilder();
			int iCount = 0;
			foreach (string x in pcfns)
			{
				string z = "'" + x + "'";
				sbPcfns.Append(z);
				iCount++;
				if (iCount != pcfns.Length)
					sbPcfns.Append(",");
			}
			//Connection.AppendInClause3(sb, p, "AND", "bu.partner_request_cd", "@PCFNV", pcfns);
			sb.Replace("@PCFN", sbPcfns.ToString());
			string sql = sb.ToString();
			DataTable dt = Connection.GetDataTable(sql, p.ToArray());
			return dt;
		}

		public static ClsReportObject LoadList(string voyageNo, string[] pcfns)
		{
			DataTable dt = GetLoadList(voyageNo, pcfns);

			ClsReportObject ro = new ClsReportObject();
			ro.Title = "Load List Voyage " + voyageNo;
			ro.ReportDisplayType = PushType.Grid;
			ro.Company_Nm = "ARC";
			ro.Report_Data = dt;
			ro.IsTableCaptionVisible = true;
			ro.Parameters_Dsc = string.Format("Voyage: {0}, PCFNs: {1}",
				voyageNo, string.Join(",", pcfns));

			ClsReportColumn rcol = new ClsReportColumn("CUBE");
			rcol.FormatString = null;
			rcol.HeaderAlignment = "Center";
			rcol.TextAlignment = "Far";
			ro.AddColumn(rcol);

			rcol = new ClsReportColumn("length");
			rcol.FormatString = null;
			rcol.HeaderAlignment = "Center";
			rcol.TextAlignment = "Far";
			ro.AddColumn(rcol);

			rcol = new ClsReportColumn("width");
			rcol.FormatString = null;
			rcol.HeaderAlignment = "Center";
			rcol.TextAlignment = "Far";
			ro.AddColumn(rcol);

			rcol = new ClsReportColumn("height");
			rcol.FormatString = null;
			rcol.HeaderAlignment = "Center";
			rcol.TextAlignment = "Far";
			ro.AddColumn(rcol);

			rcol = new ClsReportColumn("weight");
			rcol.FormatString = null;
			rcol.HeaderAlignment = "Center";
			rcol.TextAlignment = "Far";
			ro.AddColumn(rcol);

			rcol = new ClsReportColumn("MTON");
			rcol.FormatString = null;
			rcol.HeaderAlignment = "Center";
			rcol.TextAlignment = "Far";
			ro.AddColumn(rcol);

			rcol = new ClsReportColumn("Pcs");
			rcol.FormatString = null;
			rcol.HeaderAlignment = "Center";
			rcol.TextAlignment = "Far";
			ro.AddColumn(rcol);

			rcol = new ClsReportColumn("SDDC cbft");
			rcol.FormatString = null;
			rcol.HeaderAlignment = "Center";
			rcol.TextAlignment = "Far";
			ro.AddColumn(rcol);

			rcol = new ClsReportColumn("Rdd Dt");
			rcol.FormatString = "MM/dd/yyyy";
			rcol.HeaderAlignment = "Center";
			rcol.TextAlignment = "Far";
			ro.AddColumn(rcol);

			rcol = new ClsReportColumn("Lift On");
			rcol.FormatString = "MM/dd/yyyy";
			rcol.HeaderAlignment = "Center";
			rcol.TextAlignment = "Far";
			ro.AddColumn(rcol);

			rcol = new ClsReportColumn("move_type_cd", "Move Type");
			rcol.FormatString = null;
			rcol.HeaderAlignment = "Center";
			rcol.TextAlignment = "Center";
			rcol.SetVisibility(true, false, false, true);
			ro.AddColumn(rcol);

			//rcol = new ClsReportColumn("ocean_bill_of_lading", "Ocean Bill of Lading");
			//rcol.FormatString = null;
			//rcol.HeaderAlignment = "Center";
			//rcol.TextAlignment = "Center";
			//ro.AddColumn(rcol);

			ro.Add2ColCondition("CUBE", "NotEqual", "SDDC cbft", true, false);
			ro.Add2ColCondition("POD", "NotEqual", "ReqPOD", true, false);
			

			return ro;
		}

		public static ClsReportObject TenPlusTwo(string[] pcfns)
		{
			/*round(length_nbr * width_nbr / 1728) as c_cft,*/
			/*volume_nbr as c_cft, */
			/* Jun2013 DG : changed to use a new function to perform computation */
			/* May2013 DG : changed /3 to /40 per Stacy Roberts */

			StringBuilder sb = new StringBuilder(@"
			SELECT	DISTINCT
					'  ' AS ""OBL"", rcvr_dodaac AS ""Consignee DODAAC"",
					shipper_dodaac AS ""Consignor DODAAC"", vyg.VESSEL_CD AS ""Vessel"",
					vyg.sail_dt AS ""Sail Dt"",
					'-' || poe.other1_cd || '-' AS ""POE"", '-' || pod.other1_cd || '-' AS ""POD"",
					'  ' AS ""Equipment"", bu.BOOKING_ID AS ""Carrier Booking"",
					bu.UNITS_NBR AS ""Pcs"", bk.PARTNER_REQUEST_CD AS ""PCFN"", bu.TCN AS ""TCN"",
					'  ' AS ""Van"", bu.ITEM_DSC AS ""General Description"",
					bk.REQ_NAME AS ""Shipper"", brq.req_dodaac AS ""DODAAC"",
					bu.WT_NBR AS ""Wt"",
					ediuser.f_cube_ft(length_nbr, width_nbr, height_nbr) AS ""CUBE"",
					commodity_cd AS ""Commodity"",
					bk.rcvr_city AS ""Place of Delivery City"",
					poe.location_dsc AS ""POE City"",
					pod.location_dsc AS ""Final Discharge Port City"",
					bu.LENGTH_NBR AS ""Len"", bu.WIDTH_NBR AS ""Wid"", bu.HEIGHT_NBR AS ""Ht"",
					ROUND((length_nbr * width_nbr * height_nbr / 1728) / 40, 0) AS ""MT"",
					bk.adj_rdd_dt AS ""RDD"",
					(
						SELECT MAX(move_type_cd)
						FROM	t_booking_request rq2
						WHERE	rq2.partner_request_cd = bk.partner_request_cd
						AND		rq2.partner_cd = bk.partner_cd
					) AS ""Move Type"",
					'  ' AS ""Remarks"",
					(
						SELECT	MAX(etd_dt)
						FROM	t_voyage_route_detail vrtd
						WHERE	vrtd.voyage_cd = bu.voyage_no
						AND		vrtd.location_cd = bk.location_poe_cd
					) AS lift_on,
					vyg.MILITARY_VOYAGE_CD AS ""Mil Voy Doc"", vyg.scac_cd AS ""SCAC Code"",
					poe.other1_cd || '-' || pod.other1_cd || '-' || bk.PARTNER_REQUEST_CD ||
						'-' || bu.BOOKING_ID AS ""POE POD PCFN Booking""
			FROM	t_booking_unit bu
					INNER JOIN t_voyage vyg				ON (bu.voyage_no = vyg.voyage_cd)
					INNER JOIN t_booking bk				ON (bu.partner_request_cd = bk.partner_request_cd)
					INNER JOIN t_booking_request brq	ON (bu.partner_request_cd = brq.partner_request_cd AND
															acms_status_cd NOT IN ('D','A','X'))
					INNER JOIN r_location poe			ON bu.poe_location_cd = poe.location_cd  
					INNER JOIN r_location pod			ON bu.pod_location_cd = pod.location_cd
			WHERE	1 = 1 ");

			List<DbParameter> p = new List<DbParameter>();
			Connection.AppendInClause3(sb, p, "AND", "bu.partner_request_cd", "@PCFNV", pcfns);
			DataTable dt = Connection.GetDataTable(sb.ToString(), p.ToArray());

			ClsReportObject ro = new ClsReportObject();
			ro.Title = "10 + 2";
			ro.ReportDisplayType = PushType.Grid;
			ro.Company_Nm = "ARC";
			ro.Report_Data = dt;
			ro.IsTableCaptionVisible = true;
			ro.Parameters_Dsc = string.Format("PCFNs: {0}", string.Join(",", pcfns));

			ClsReportColumn rcol = new ClsReportColumn("CUBE");
			rcol.FormatString = null;
			rcol.HeaderAlignment = "Center";
			rcol.TextAlignment = "Far";
			rcol.AggregateType = "SUM";
			ro.AddColumn(rcol);

			rcol = new ClsReportColumn("Len");
			rcol.FormatString = null;
			rcol.HeaderAlignment = "Center";
			rcol.TextAlignment = "Far";
			ro.AddColumn(rcol);

			rcol = new ClsReportColumn("Wid");
			rcol.FormatString = null;
			rcol.HeaderAlignment = "Center";
			rcol.TextAlignment = "Far";
			ro.AddColumn(rcol);

			rcol = new ClsReportColumn("Ht");
			rcol.FormatString = null;
			rcol.HeaderAlignment = "Center";
			rcol.TextAlignment = "Far";
			ro.AddColumn(rcol);

			rcol = new ClsReportColumn("Wt");
			rcol.FormatString = null;
			rcol.HeaderAlignment = "Center";
			rcol.TextAlignment = "Far";
			ro.AddColumn(rcol);

			rcol = new ClsReportColumn("MT");
			rcol.FormatString = null;
			rcol.HeaderAlignment = "Center";
			rcol.TextAlignment = "Far";
			rcol.AggregateType = "SUM";
			ro.AddColumn(rcol);

			rcol = new ClsReportColumn("Pcs");
			rcol.FormatString = null;
			rcol.HeaderAlignment = "Center";
			rcol.TextAlignment = "Far";
			rcol.AggregateType = "SUM";
			ro.AddColumn(rcol);

			rcol = new ClsReportColumn("RDD");
			rcol.FormatString = "dd/MM/yyyy";
			rcol.HeaderAlignment = "Center";
			rcol.TextAlignment = "Far";
			ro.AddColumn(rcol);

			rcol = new ClsReportColumn("Sail Dt");
			rcol.FormatString = "dd-MMM-yy";
			rcol.HeaderAlignment = "Center";
			ro.AddColumn(rcol);

			rcol = new ClsReportColumn("Move Type");
			rcol.FormatString = null;
			rcol.HeaderAlignment = "Center";
			rcol.TextAlignment = "Center";
			rcol.SetVisibility(true, false, false, true);
			ro.AddColumn(rcol);

			rcol = new ClsReportColumn("PCFN");
			rcol.FormatString = null;
			rcol.ColumnType = "Link";
			ro.AddColumn(rcol);

			rcol = new ClsReportColumn("Carrier Booking");
			rcol.FormatString = null;
			rcol.ColumnType = "Link";
			ro.AddColumn(rcol);

			rcol = new ClsReportColumn("POE POD PCFN Booking", "Group");
			rcol.FormatString = null;
			rcol.SetVisibility(true, false, false, true);
			rcol.CollapseWhenGrouped = false;
			ro.AddColumn(rcol);

			ro.AddGroups("POE POD PCFN Booking");

			return ro;
		}

        public static void ImportRowFromOcean(string BookingId, string TCN, string PCFN, int ItemNo)
        {
            
            string sql = string.Format(@"
            insert into t_booking_unit
            (partner_cd, partner_request_cd, item_no, wt_nbr, wt_qualifier, volume_nbr,lading_qty_nbr,
             packaging_form_cd, wt_unit_cd, item_dsc, commodity_cd, commodity_qualifier, type_pack_cd,
             tcn, length_nbr, width_nbr, height_nbr, measure_unit_qualifier, units_nbr,
             vessel_cd, poe_location_cd, pod_location_cd, voyage_no, mil_voyage_no, booking_id, booking_id_sub,
             poe_terminal_cd, pod_terminal_cd, cargo_id, rev_cd, adj_rdd_dt,volume_qualifier
             )
            select 'MTMCIBSD', '{2}', {3}, cast(weight_nbr as int), 'E', cast(cube_ft as int), 1,
             'PCS', 'L', cargo_dsc, 'commodity_cd', 'I', 'PCS',
              serial_no, cast(length_nbr as int), cast(width_nbr as int), cast(height_nbr as int), 'N', 1,
              vessel_cd, pol_location_cd, pod_location_cd, voyage_no, null, booking_no, '  ',
              pol_berth, pod_berth, null, ltrim(tariff_cd,'R') as revcd, rdd_dt, 'E'
             from v_booking_cargo_line<DBLINK>arcsys
             where booking_no = '{0}'
              and serial_no = '{1}' ", BookingId, TCN, PCFN, ItemNo);

            Connection.RunSQL(sql);

        }
		#endregion
	}
}