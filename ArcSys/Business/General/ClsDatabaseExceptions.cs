using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public class ClsDatabaseExceptions
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ArcSys"]; }
		}
		#endregion		// #region Connection Manager

		#region Fields and constants

		private readonly string MismatchEstIDKey = "MismatchEstID";
		private readonly string TCNCountMismatchKey = "TCNCountMismatch";
		private readonly string TCNCountDetailMismatchKey = "TCNCountDetailMismatch";
		private readonly string BookingErrorsKey = "BookingErrors";
		private readonly string MissingSerialNoKey = "MissingSerialNo";
		private readonly string BookingInfoChangedKey = "BookingInfoChanged";
		private readonly string MissingLinehaulApKey = "MissingLinehaulAP";
		private readonly string MissingLinehaulArKey = "MissingLinehaulAR";
		private readonly string NonDoorEstimatesKey = "NonDoorEstimates";
		private readonly string CargoChangesKey = "CargoChanges";
		private readonly string UnimportedCargoKey = "UnimportedCargo";
		private readonly string DuplicateTCNKey = "DuplicateTCN";
		private readonly string DuplicateTCNEstKey = "DuplicateTCNEst";

		public ComboItem[] AvailableKeys { get; private set; }
		public ComboItem[] UserAvailableKeys { get; private set; }

		private delegate ClsReportObject SearchMethod();
		private Dictionary<string, SearchMethod> Methods;
		public string SearchKey { get; set; }
		public ClsDatabaseExceptions()
		{
			AvailableKeys = new ComboItem[]{
			new ComboItem(MismatchEstIDKey, "Missing or mistmatched Estimate ID"),//0
			new ComboItem(TCNCountMismatchKey, "TCN Count Mismatch"),//1
			new ComboItem(TCNCountDetailMismatchKey, "TCN Detail Count Mismatch"),//2
			new ComboItem(BookingErrorsKey, "Booking Errors"),//3
			new ComboItem(BookingInfoChangedKey, "Booking Information Changed"),//4
			new ComboItem(MissingSerialNoKey, "Missing Serial Numbers (No longer found in LINE)"),//5
			new ComboItem(MissingLinehaulApKey, "Cargo Missing Linehaul AP/Cost"),//6
			new ComboItem(MissingLinehaulArKey, "Cargo Missing Linehaul AR/Revenue"),//7
			new ComboItem(NonDoorEstimatesKey, "Estimates with F1-F4 cargo"),//8
			new ComboItem(CargoChangesKey, "Cargo Changes"),//9
			new ComboItem(UnimportedCargoKey, "Unimported Cargo"),//10
			new ComboItem(DuplicateTCNKey, "Duplicate TCNs"),//11 Dev only
			new ComboItem(DuplicateTCNEstKey, "Duplicate TCNs on Estimates")//12
			};

			if (ClsEnvironment.IsDeveloper)
				UserAvailableKeys = AvailableKeys;
			else
			{
				UserAvailableKeys = new ComboItem[]{AvailableKeys[4], AvailableKeys[5],
					AvailableKeys[6],AvailableKeys[7],AvailableKeys[8],AvailableKeys[9],
					AvailableKeys[10], AvailableKeys[12]};
			}

			Methods = new Dictionary<string, SearchMethod>();
			Methods.Add(MismatchEstIDKey, MismatchEstID);
			Methods.Add(TCNCountMismatchKey, TCNCountMismatch);
			Methods.Add(TCNCountDetailMismatchKey, TCNCountDetailMismatch);
			Methods.Add(BookingErrorsKey, BookingErrors);
			Methods.Add(MissingSerialNoKey, MissingSerialNumbers);
			//Methods.Add(MissingSerialNoKey, MissingCargoOLD);
			Methods.Add(BookingInfoChangedKey, BookingInfoChanged);
			Methods.Add(MissingLinehaulApKey, MissingLinehaulAp);
			Methods.Add(MissingLinehaulArKey, MissingLinehaulAr);
			Methods.Add(NonDoorEstimatesKey, NonDoorEstimates);
			Methods.Add(CargoChangesKey, CargoChanges);
			Methods.Add(UnimportedCargoKey, UnimportedCargo);
			Methods.Add(DuplicateTCNKey, DuplicateTCN);
			Methods.Add(DuplicateTCNEstKey, DuplicateTCNEst);
		}
		#endregion

		#region Report Methods
		
		public ClsReportObject Search()
		{
			if(!Methods.ContainsKey(SearchKey) )
				throw new Exception("Missing or invalid Search Key");

			SearchMethod method = Methods[SearchKey];
			return method();
		}

		public ClsReportObject MissingLinehaulAp()
		{
			return MissingLinehaul(ClsFinance.Codes.AP);
		}

		public ClsReportObject MissingLinehaulAr()
		{
			return MissingLinehaul(ClsFinance.Codes.AR);
		}

		public ClsReportObject MissingLinehaul(string finCd)
		{
			StringBuilder sb = new StringBuilder(@"
				SELECT	est.estimate_no, c.cargo_dsc, c.serial_no, c.commodity_cd, c.make_cd, c.model_cd,
						ca.cargo_activity_id, est.estimate_id, to_char(bk.sail_dt, 'YYYY-MM') AS accrual_month,
						NVL((
							SELECT	'Y'
							FROM	t_estimate_charge_dtl edt
									INNER JOIN t_estimate_charge echg	ON echg.estimate_charge_id = edt.estimate_charge_id
									INNER JOIN r_charge_type cht		ON cht.charge_type_cd = echg.charge_type_cd
							WHERE	echg.estimate_id = est.estimate_id AND
									edt.cargo_activity_id = ca.cargo_activity_id AND
									echg.finance_cd = 'AP' AND cht.charge_category_cd = 'LINEHAUL'
						), 'N') AS ap_lh_exists_flg,
						NVL((
							SELECT	'Y'
							FROM	t_estimate_charge_dtl edt
									INNER JOIN t_estimate_charge echg	ON echg.estimate_charge_id = edt.estimate_charge_id
									INNER JOIN r_charge_type cht		ON cht.charge_type_cd = echg.charge_type_cd
							WHERE	echg.estimate_id = est.estimate_id AND
									edt.cargo_activity_id = ca.cargo_activity_id AND
									echg.finance_cd = 'AR' AND cht.charge_category_cd = 'LINEHAUL'
						), 'N') AS ar_lh_exists_flg
				FROM	t_estimate est
						INNER JOIN t_cargo_activity ca	ON ca.estimate_id = est.estimate_id
						INNER JOIN t_cargo c			ON c.cargo_id = ca.cargo_id
						INNER JOIN t_booking bk			ON bk.booking_id = c.booking_id ");

			if( ClsFinance.Codes.IsAR(finCd) )
				sb.Append(@"
				WHERE	ca.billable_flg = 'Y'
				AND		NOT EXISTS
						(
							SELECT	'Y'
							FROM	t_estimate_charge_dtl edt
									INNER JOIN t_estimate_charge echg	ON echg.estimate_charge_id = edt.estimate_charge_id
									INNER JOIN r_charge_type cht		ON cht.charge_type_cd = echg.charge_type_cd
							WHERE	echg.estimate_id = est.estimate_id AND
									edt.cargo_activity_id = ca.cargo_activity_id AND
									echg.finance_cd = 'AR' AND cht.charge_category_cd = 'LINEHAUL'
						) ");
			else
				sb.Append(@"
				WHERE	ca.payable_flg = 'Y'
				AND		NOT EXISTS
						(
							SELECT	'Y'
							FROM	t_estimate_charge_dtl edt
									INNER JOIN t_estimate_charge echg	ON echg.estimate_charge_id = edt.estimate_charge_id
									INNER JOIN r_charge_type cht		ON cht.charge_type_cd = echg.charge_type_cd
							WHERE	echg.estimate_id = est.estimate_id AND
									edt.cargo_activity_id = ca.cargo_activity_id AND
									echg.finance_cd = 'AP' AND cht.charge_category_cd = 'LINEHAUL'
						) ");

			DataTable dt = Connection.GetDataTable(sb.ToString());

			ClsReportObject ro = new ClsReportObject();
			//ro.Crystal_File_Nm = "Abc.rpt";
			ro.Title = "Cargo Missing Linehaul " + finCd;
			ro.ReportDisplayType = PushType.Grid;
			ro.Company_Nm = "ARC";
			ro.Report_Data = dt;
			ro.IsTableCaptionVisible = true;
			ro.Parameters_Dsc = "Missing " + (ClsFinance.Codes.IsAR(finCd) ? "Revenue" : "Cost");

			ClsReportColumn rc = new ClsReportColumn("AP_LH_EXISTS_FLG", "AP Exists");
			rc.ColumnType = "Checkbox";
			rc.HeaderAlignment = "Center";
			rc.TextAlignment = "Center";
			ro.AddColumn(rc);

			ClsReportColumn rc2 = new ClsReportColumn("AR_LH_EXISTS_FLG", "AR Exists");
			rc2.ColumnType = "Checkbox";
			rc2.HeaderAlignment = "Center";
			rc2.TextAlignment = "Center";
			ro.AddColumn(rc2);

			ClsReportColumn rc3 = new ClsReportColumn("ESTIMATE_NO", "Estimate #");
			rc3.ColumnType = "Link";
			rc3.HideWhenGrouped = false;
			ro.AddColumn(rc3);

			ro.DefineGroups("ACCRUAL_MONTH", "ESTIMATE_NO");

			return ro;
		}

		public ClsReportObject MismatchEstID()
		{
			string sql = @"
			SELECT	edt.estimate_charge_dtl_id, edt.estimate_charge_id,
					echg.estimate_id AS chg_est_id, chgest.estimate_no AS charge_estimate_no,
					ca.cargo_activity_id, ca.cargo_id, ca.orig_location_cd, ca.dest_location_cd,
					ca.billable_flg, c.cargo_dsc, c.serial_no, ca.estimate_id AS act_est_id,
					caest.estimate_no AS act_estimate_no
			FROM	t_estimate_charge_dtl edt
				INNER JOIN t_cargo_activity ca		ON ca.cargo_activity_id = edt.cargo_activity_id
				INNER JOIN t_cargo c				ON c.cargo_id = ca.cargo_id
				INNER JOIN t_estimate_charge echg	ON echg.estimate_charge_id = edt.estimate_charge_id
				INNER JOIN t_estimate chgest		ON chgest.estimate_id = echg.estimate_id
				LEFT OUTER JOIN t_estimate caest	ON caest.estimate_id = ca.estimate_id
			WHERE	NVL(ca.estimate_id, -1) <> echg.estimate_id ";

			DataTable dt = Connection.GetDataTable(sql);

			ClsReportObject ro = new ClsReportObject();
			//ro.Crystal_File_Nm = "Abc.rpt";
			ro.Title = "Missing or mismatched Estimate ID";
			ro.ReportDisplayType = PushType.Grid;
			ro.Company_Nm = "ARC";
			ro.Report_Data = dt;

			//ro.DefineGroups("VESSEL_CD", "BOOKING_NO");
			//ClsReportColumn rc = new ClsReportColumn("ORDER_ID", "Order ID");
			//rc.FormatString = "0";
			//rc.HeaderAlignment = "Far";
			//rc.TextAlignment = "Center";
			//ro.AddColumn(rc);

			//ClsReportColumn rc2 = ro.AddColumn("RATE_AMT", "Order Amount", "Sum");
			//rc2.HeaderAlignment = "Center";
			//rc2.TextAlignment = "Far";
			return ro;
		}

		public ClsReportObject TCNCountMismatch()
		{
			string sql = @"
			SELECT	COUNT(DISTINCT ca.cargo_activity_id) AS cgo_tcns, echg.estimate_charge_id,
					echg.level_count, echg.tcn_count
			FROM t_estimate_charge echg
				INNER JOIN r_level_unit lvu				ON (lvu.level_unit_id = echg.level_unit_id AND lvu.level_cd = 'TCN')
				INNER JOIN t_estimate_charge_dtl edt	ON edt.estimate_charge_id = echg.estimate_charge_id
				INNER JOIN t_cargo_activity ca			ON ca.cargo_activity_id = edt.cargo_activity_id
				INNER JOIN t_cargo c					ON c.cargo_id = ca.cargo_id
				INNER JOIN t_booking bk					ON bk.booking_id = c.booking_id
			GROUP BY	echg.estimate_charge_id, echg.level_count, echg.tcn_count
			HAVING		COUNT(DISTINCT ca.cargo_activity_id) <> echg.level_count OR
						echg.level_count <> echg.tcn_count ";

			DataTable dt = Connection.GetDataTable(sql);

			ClsReportObject ro = new ClsReportObject();
			//ro.Crystal_File_Nm = "Abc.rpt";
			ro.Title = "TCN Count Mismatch";
			ro.ReportDisplayType = PushType.Grid;
			ro.Company_Nm = "ARC";
			ro.Report_Data = dt;

			//ro.DefineGroups("VESSEL_CD", "BOOKING_NO");
			//ClsReportColumn rc = new ClsReportColumn("ORDER_ID", "Order ID");
			//rc.FormatString = "0";
			//rc.HeaderAlignment = "Far";
			//rc.TextAlignment = "Center";
			//ro.AddColumn(rc);

			//ClsReportColumn rc2 = ro.AddColumn("RATE_AMT", "Order Amount", "Sum");
			//rc2.HeaderAlignment = "Center";
			//rc2.TextAlignment = "Far";
			return ro;
		}

		public ClsReportObject TCNCountDetailMismatch()
		{
			string sql = @"
			SELECT	COUNT(DISTINCT ca.cargo_activity_id) AS cgo_tcns, echg.estimate_charge_id,
					echg.tcn_count
			FROM	t_estimate_charge echg
				INNER JOIN r_level_unit lvu				ON (lvu.level_unit_id = echg.level_unit_id AND lvu.level_cd = 'TCN')
				INNER JOIN t_estimate_charge_dtl edt	ON edt.estimate_charge_id = echg.estimate_charge_id
				INNER JOIN t_cargo_activity ca			ON ca.cargo_activity_id = edt.cargo_activity_id
				INNER JOIN t_cargo c					ON c.cargo_id = ca.cargo_id
				INNER JOIN t_booking bk					ON bk.booking_id = c.booking_id
			GROUP BY	echg.estimate_charge_id, echg.tcn_count
			HAVING		COUNT(DISTINCT ca.cargo_activity_id) <> echg.tcn_count ";

			DataTable dt = Connection.GetDataTable(sql);

			ClsReportObject ro = new ClsReportObject();
			//ro.Crystal_File_Nm = "Abc.rpt";
			ro.Title = "TCN Count Detail Mismatches";
			ro.ReportDisplayType = PushType.Grid;
			ro.Company_Nm = "ARC";
			ro.Report_Data = dt;

			//ro.DefineGroups("VESSEL_CD", "BOOKING_NO");
			//ClsReportColumn rc = new ClsReportColumn("ORDER_ID", "Order ID");
			//rc.FormatString = "0";
			//rc.HeaderAlignment = "Far";
			//rc.TextAlignment = "Center";
			//ro.AddColumn(rc);

			//ClsReportColumn rc2 = ro.AddColumn("RATE_AMT", "Order Amount", "Sum");
			//rc2.HeaderAlignment = "Center";
			//rc2.TextAlignment = "Far";
			return ro;
		}

		public ClsReportObject MissingCargoOLD()
		{
			//
			// Cargo that is no longer in LINE
			//  OBSOLETE - new method uses the line warehouse

			// First, get all LINE cargo
			DataTable[] dtAll = new DataTable[3];
			ClsImportLine i = new ClsImportLine();
			dtAll = i.GetLineCargo("%", 180);
			DataTable dtLINECargo = new DataTable();
			dtLINECargo.Merge(dtAll[0]);
			dtLINECargo.Merge(dtAll[1]);
			dtLINECargo.Merge(dtAll[2]);

			ClsReportObject ro = new ClsReportObject();

			// Next, get all ILMS Cargo
			string sql = @"
				select  booking_no, serial_no, item_no, cargo_dsc,
				   length_nbr, width_nbr, height_nbr, 
				   make_cd, model_cd, commodity_cd,
				   container_no, 
				   ca.cargo_id, e.estimate_id, estimate_no
				 from t_cargo_activity ca
				 inner join t_cargo c on c.cargo_id = ca.cargo_id
				 inner join t_booking b on c.booking_id = b.booking_id
				 inner join t_estimate e on e.estimate_id = ca.estimate_id
				  where estimate_id is not null ";
			DataTable dtILMSCargo = Connection.GetDataTable(sql);

			DataTable dtMissing = dtILMSCargo.Clone();
			foreach (DataRow dr in dtILMSCargo.Rows)
			{
				string sSerialNo = dr["serial_no"].ToString();
				string sSelect = string.Format("tcn = '{0}'", sSerialNo);
				DataRow[] foundRows = dtLINECargo.Select(sSelect);
				if (foundRows.Length < 1)
				{
					dtMissing.ImportRow(dr);
				}
			}

			ro.Title = "Missing Serial Numbers (No longer found in LINE)";
			ro.ReportDisplayType = PushType.Grid;
			ro.Company_Nm = "ARC";
			ro.Report_Data = dtMissing;

			ClsReportColumn rc = new ClsReportColumn("estimate_no", "Estimate #");
			rc.ColumnType = "Link";
			ro.AddColumn(rc);

			ClsReportColumn rc2 = new ClsReportColumn("estimate_id", "Estimate");
			rc2.HeaderAlignment = "Center";
			rc2.TextAlignment = "Center";
			rc2.ColumnType = "Link";
			ro.AddColumn(rc2);

			return ro;
		}

		public ClsReportObject MissingSerialNumbers()
		{
			// October 2011 -- use the LINE warehouse now
//            string sql = @"
//				select  booking_no, serial_no, item_no, cargo_dsc,
//				   length_nbr, width_nbr, height_nbr, 
//				   make_cd, model_cd, commodity_cd,
//				   container_no, 
//				   cargo_activity_id, ca.cargo_id, estimate_id, estimate_no
//				 from t_cargo_activity ca
//				 inner join t_cargo c on c.cargo_id = ca.cargo_id
//				 inner join t_booking b on c.booking_id = b.booking_id
//				 inner join t_estimate e on e.estimate_id = ca.estimate_id
//				  where estimate_id is not null 
//					and cargo_key is not null
//				  and not exists
//				   (select 1
//				  from v_booking_cargo_line lc
//				   where c.cargo_key = lc.cargo_key)";

			string sql = @"
				select m.*
				from v_missing_serial_no m ";

			DataTable dt = Connection.GetDataTable(sql);
			ClsReportObject ro = new ClsReportObject();
			ro.Title = "Missing Serial Numbers (No longer found in LINE)";
			ro.ReportDisplayType = PushType.Grid;
			ro.Company_Nm = "ARC";
			ro.Report_Data = dt;

			ClsReportColumn rc = new ClsReportColumn("estimate_no", "Estimate #");
			rc.ColumnType = "Link";
			ro.AddColumn(rc);

			ClsReportColumn rc2 = new ClsReportColumn("estimate_id", "Estimate");
			rc2.HeaderAlignment = "Center";
			rc2.TextAlignment = "Center";
			rc2.ColumnType = "Link";
			ro.AddColumn(rc2);

			return ro;
		}

		public ClsReportObject BookingErrors()
		{
			string sql = @"
			SELECT	bk.booking_id, bk.plor_location_cd AS plor, bk.pol_location_cd AS pol,
					bk.pod_location_cd AS pod, bk.plod_location_cd AS plod, bk.booking_no,
					bk.customer_ref AS pcfn, bk.booking_ref, bk.edi_ref, bk.vessel_cd, bk.voyage_no,
					bk.sail_dt, bk.delivery_txt, bk.cargo_notes_txt
			FROM	t_booking bk
			WHERE	bk.plor_location_cd IS NULL OR
					bk.pol_location_cd IS NULL OR
					bk.pod_location_cd IS NULL OR
					bk.plod_location_cd IS NULL OR
					bk.booking_no IS NULL OR
					bk.sail_dt IS NULL OR
					regexp_instr(bk.customer_ref, '[,? ]') > 0 ";

			DataTable dt = Connection.GetDataTable(sql);

			ClsReportObject ro = new ClsReportObject();
			//ro.Crystal_File_Nm = "Abc.rpt";
			ro.Title = "Booking Errors (missing locations, invalid pcfn/booking numbers)";
			ro.ReportDisplayType = PushType.Grid;
			ro.Company_Nm = "ARC";
			ro.Report_Data = dt;

			//ro.DefineGroups("VESSEL_CD", "BOOKING_NO");
			//ClsReportColumn rc = new ClsReportColumn("ORDER_ID", "Order ID");
			//rc.FormatString = "0";
			//rc.HeaderAlignment = "Far";
			//rc.TextAlignment = "Center";
			//ro.AddColumn(rc);

			//ClsReportColumn rc2 = ro.AddColumn("RATE_AMT", "Order Amount", "Sum");
			//rc2.HeaderAlignment = "Center";
			//rc2.TextAlignment = "Far";
			return ro;
		}

		public ClsReportObject BookingInfoChanged()
		{
			string sql = @"
				select e.estimate_id, e.estimate_no,
					   b.booking_no, b.voyage_no, 
					   b.vessel_cd, 
					   ca.orig_location_cd as booking_origin, 
					   ca.dest_location_cd as booking_destination,
					   e.voyage_no as estimate_voyage_no, 
					   e.orig_location_cd as estimate_origin, 
					   e.dest_location_cd as estimate_destination
				 from t_cargo c
				  inner join t_cargo_activity ca on c.cargo_id = ca.cargo_id
				  inner join t_estimate e on e.estimate_id = ca.estimate_id
				  inner join t_booking b on b.booking_id = c.booking_id
				 where (ca.orig_location_cd <> e.orig_location_cd or
					   ca.dest_location_cd <> e.dest_location_cd or
					   b.voyage_no <> e.voyage_no)
				group by e.estimate_id, e.estimate_no,
						b.booking_no, b.voyage_no, b.vessel_cd, ca.orig_location_cd, ca.dest_location_cd,
						e.voyage_no, e.orig_location_cd, e.dest_location_cd ";
			DataTable dt = Connection.GetDataTable(sql);
			ClsReportObject ro = new ClsReportObject();
			ro.Title = "Booking information in line does not match the estimate";
			ro.ReportDisplayType = PushType.Grid;
			ro.Company_Nm = "ARC";
			ro.Report_Data = dt;

			ClsReportColumn rc = new ClsReportColumn("estimate_id", "Estimate");
			rc.HeaderAlignment = "Center";
			rc.TextAlignment = "Center";
			rc.SetVisibility(true, false, false, false);
			rc.ColumnType = "Link";
			ro.AddColumn(rc);

			ClsReportColumn rc2 = new ClsReportColumn("estimate_no", "Estimate#");
			rc2.HeaderAlignment = "Center";
			rc2.TextAlignment = "Center";
			rc2.ColumnType = "Link";
			ro.AddColumn(rc2);


			return ro;
		 }

		public ClsReportObject NonDoorEstimates()
		{
			string sql = @"
			SELECT	est.estimate_id, est.estimate_no, eoloc.location_dsc AS orig_location_dsc,
					edloc.location_dsc AS dest_location_dsc, bk.booking_no, bk.vessel_cd,
					bk.voyage_no, count(distinct c.cargo_id) AS piece_cnt
			FROM	t_estimate est
				INNER JOIN t_cargo_activity ca	ON ca.estimate_id = est.estimate_id
				INNER JOIN t_cargo c			ON c.cargo_id = ca.cargo_id
				INNER JOIN t_booking bk			ON bk.booking_id = c.booking_id
				INNER JOIN r_location eoloc		ON eoloc.location_cd = est.orig_location_cd
				INNER JOIN r_location edloc		ON edloc.location_cd = est.dest_location_cd
			WHERE	c.move_type_cd IN ('F1', 'F2', 'F3', 'F4')
			GROUP BY	est.estimate_id, est.estimate_no, eoloc.location_dsc, edloc.location_dsc,
						bk.booking_no, bk.vessel_cd, bk.voyage_no";

			DataTable dt = Connection.GetDataTable(sql);

			ClsReportObject ro = new ClsReportObject();
			//ro.Crystal_File_Nm = "Abc.rpt";
			ro.Title = "Estimates with F1-F4 Cargo";
			ro.ReportDisplayType = PushType.Grid;
			ro.Company_Nm = "ARC";
			ro.Report_Data = dt;

			ClsReportColumn rc = new ClsReportColumn("ESTIMATE_ID", "Estimate ID");
			rc.SetVisibility(true, false, false, true);
			ro.AddColumn(rc);

			rc = new ClsReportColumn("ESTIMATE_No", "Estimate #");
			rc.ColumnType = "Link";
			ro.AddColumn(rc);

			rc = ro.AddColumn("Orig_Location_Dsc", "Inland Orig", null);
			ro.AddColumn(rc);

			rc = ro.AddColumn("Dest_Location_Dsc", "Inland Dest", null);
			ro.AddColumn(rc);

			rc = ro.AddColumn("Piece_Cnt", "Pieces", "Sum");
			rc.HeaderAlignment = "Center";
			rc.TextAlignment = "Far";
			ro.AddColumn(rc);

			return ro;
		}

		public ClsReportObject CargoChanges()
		{
			string sql = @"
			SELECT	est.estimate_no, cc.serial_no, cc.column_nm, cc.old_value, cc.new_value,
					cc.estimate_id, cc.cargo_activity_id
			FROM	t_cargo_change cc
				INNER JOIN t_estimate est		ON est.estimate_id = cc.estimate_id
			GROUP BY	est.estimate_no, cc.serial_no, cc.column_nm, cc.old_value, cc.new_value,
						cc.estimate_id, cc.cargo_activity_id
			ORDER BY	est.estimate_no, cc.serial_no, cc.column_nm ";

			DataTable dt = Connection.GetDataTable(sql);

			ClsReportObject ro = new ClsReportObject();
			//ro.Crystal_File_Nm = "Abc.rpt";
			ro.Title = "Cargo Changes";
			ro.ReportDisplayType = PushType.Grid;
			ro.Company_Nm = "ARC";
			ro.Report_Data = dt;

			ClsReportColumn rc = new ClsReportColumn("ESTIMATE_ID", "Estimate ID");
			rc.SetVisibility(true, false, false, true);
			ro.AddColumn(rc);

			rc = new ClsReportColumn("ESTIMATE_NO", "Estimate #");
			rc.ColumnType = "Link";
			ro.AddColumn(rc);

			rc = new ClsReportColumn("CARGO_ACTIVITY_ID", "Cargo Activity ID");
			rc.SetVisibility(true, false, false, true);
			ro.AddColumn(rc);

			return ro;
		}

		public ClsReportObject UnimportedCargo()
		{
			DataTable dt = ImportNotes();
			ClsReportObject ro = new ClsReportObject();
			//ro.Crystal_File_Nm = "Abc.rpt";
			ro.Title = "Unimported Cargo";
			ro.ReportDisplayType = PushType.Grid;
			ro.Company_Nm = "ARC";
			ro.Report_Data = dt;

			ro.AddGroups("booking_no");
			return ro;
		}

		public DataTable ImportNotes()
		{
//            string sql = @"
//               select serial_no,
//                      booking_no,
//                      voyage_no,
//                      vessel_cd,
//                      plor_location_cd,
//                      plod_location_cd,
//                      move_type_cd,
//                      sail_dt,
//                      import_notes
//                       from s_line_cargo 
//                  where import_notes is not null
//                    and move_type_cd > 'F4'
//                    and deleted_flg = 'N'
//               order by booking_no, serial_no";
			string sql = @"
			   select serial_no,
					  booking_no1,
					  booking_no2,
					  voyage_no,
					  vessel_cd,
					  plor_location_cd,
					  plod_location_cd,
					  move_type_cd,
					  sail_dt,
					  import_notes_txt
					   from v_unimported_cargo_warehouse 
			  where not exists 
			   (select 1 from t_exception_override x
				  where booking_no1 = x.booking_no)
			   order by booking_no1, serial_no";
			DataTable dt = Connection.GetDataTable(sql);
			return dt;
		}

		public ClsReportObject DuplicateTCN()
		{
			string sql = @"
			SELECT	v.*
			FROM	v_exception_duplicates v
			ORDER BY v.serial_no, v.mv_orig, v.mv_dest, v.booking_no, v.estimate_no ";

			DataTable dt = Connection.GetDataTable(sql);
			if (dt != null)
			{
				ClsImportLine iline = new ClsImportLine();
				foreach (DataRow dr in dt.Rows)
				{
					string tcn = ClsConvert.ToString(dr["serial_no"]);
					if (tcn.IsNullOrWhiteSpace()) continue;

					DataTable dtLine = iline.QueryLINEData("%", "%", tcn, false);
					if (dtLine == null || dtLine.Rows.Count <= 0)
					{
						dr["Line_Flg"] = ClsConvert.ToDbObject("N");
						dr.SetColumnError("Line_Flg", "Serial # does not exist in LINE");
						continue;
					}

					string plor = ClsConvert.ToString(dr["plor_cd"]);
					string pol = ClsConvert.ToString(dr["pol_cd"]);
					string pod = ClsConvert.ToString(dr["pod_cd"]);
					string plod = ClsConvert.ToString(dr["plod_cd"]);
					string bkNo = ClsConvert.ToString(dr["booking_no"]);
					string voyNo = ClsConvert.ToString(dr["voyage_no"]);

					bool exactMatch = false;
					StringBuilder sb = new StringBuilder();
					foreach (DataRow drLine in dtLine.Rows)
					{
						string lineplor = ClsConvert.ToString(drLine["plor"]);
						string linepol = ClsConvert.ToString(drLine["pol"]);
						string linepod = ClsConvert.ToString(drLine["pod"]);
						string lineplod = ClsConvert.ToString(drLine["plod"]);
						string linebkNo = ClsConvert.ToString(drLine["booking_no"]);
						string linevoyNo = ClsConvert.ToString(drLine["voyage_no"]);

						bool bookMatch = (string.Compare(linebkNo, bkNo, true) == 0);
						bool voyageMatch = (string.Compare(linevoyNo, voyNo, true) == 0);
						bool toPortMatch = (string.Compare(lineplod, plod, true) == 0 &&
							string.Compare(linepol, pol, true) == 0);
						bool fromPortMatch = (string.Compare(linepod, pod, true) == 0 &&
							string.Compare(lineplod, plod, true) == 0);
						if (toPortMatch && fromPortMatch && voyageMatch && bookMatch)
						{
							exactMatch = true;
							break;
						}

						sb.AppendFormat("Bk {0} Voy {1} {2}-{3}-{4}-{5}\r\n",
							linebkNo, linevoyNo, lineplor, linepol, linepod, lineplod);
					}

					if (exactMatch) continue;

					sb.Insert(0, "Serial # exists but booking info does not match LINE\r\n");
					dr["Line_Flg"] = ClsConvert.ToDbObject("N");
					dr.SetColumnError("Line_Flg", sb.ToString());
				}
			}

			ClsReportObject ro = new ClsReportObject();
			ro.Title = "Duplicate TCNs";
			ro.ReportDisplayType = PushType.Grid;
			ro.Company_Nm = "ARC";
			ro.Report_Data = dt;

			ClsReportColumn rc = new ClsReportColumn("ESTIMATE_No", "Estimate #");
			rc.ColumnType = "Link";
			ro.AddColumn(rc);

			rc = ro.AddColumn("Tcn_Occurs", "TCN Occurs", null);
			rc.HeaderAlignment = "Center";
			rc.TextAlignment = "Far";
			ro.AddColumn(rc);

			rc = ro.AddColumn("Line_Flg", "In LINE", null);
			rc.HeaderAlignment = "Center";
			rc.TextAlignment = "Center";
			rc.CheckboxFalseValue = "N";
			rc.CheckboxTrueValue = "Y";
			rc.ColumnType = "Checkbox";
			ro.AddColumn(rc);

			rc = ro.AddColumn("Billable_Flg", "Billable", null);
			rc.HeaderAlignment = "Center";
			rc.TextAlignment = "Center";
			rc.CheckboxFalseValue = "N";
			rc.CheckboxTrueValue = "Y";
			rc.ColumnType = "Checkbox";
			ro.AddColumn(rc);

			rc = ro.AddColumn("Payable_Flg", "Payable", null);
			rc.HeaderAlignment = "Center";
			rc.TextAlignment = "Center";
			rc.CheckboxFalseValue = "N";
			rc.CheckboxTrueValue = "Y";
			rc.ColumnType = "Checkbox";
			ro.AddColumn(rc);

			rc = ro.AddColumn("Plor_Cd", "PLOR Cd", null);
			rc.SetVisibility(true, false, true, true);
			ro.AddColumn(rc);

			rc = ro.AddColumn("Pol_Cd", "POL Cd", null);
			rc.SetVisibility(true, false, true, true);
			ro.AddColumn(rc);

			rc = ro.AddColumn("Pod_Cd", "POD Cd", null);
			rc.SetVisibility(true, false, true, true);
			ro.AddColumn(rc);

			rc = ro.AddColumn("Plod_Cd", "PLOD Cd", null);
			rc.SetVisibility(true, false, true, true);
			ro.AddColumn(rc);

			ro.DefineGroups("SAIL_DT");

			return ro;
		}

		public ClsReportObject DuplicateTCNEst()
		{
			string sql = @"
			SELECT	v.*
			FROM	v_exception_dup_est v
			ORDER BY v.serial_no, v.sail_dt, v.mv_orig, v.mv_dest, v.booking_no, v.estimate_no ";

			DataTable dt = Connection.GetDataTable(sql);
			if (dt != null)
			{
				ClsImportLine iline = new ClsImportLine();
				foreach (DataRow dr in dt.Rows)
				{
					string tcn = ClsConvert.ToString(dr["serial_no"]);
					if (tcn.IsNullOrWhiteSpace()) continue;

					DataTable dtLine = iline.QueryLINEData("%", "%", tcn, false);
					if (dtLine == null || dtLine.Rows.Count <= 0)
					{
						dr["Line_Flg"] = ClsConvert.ToDbObject("N");
						dr.SetColumnError("Line_Flg", "Serial # does not exist in LINE");
						continue;
					}

					string plor = ClsConvert.ToString(dr["plor_cd"]);
					string pol = ClsConvert.ToString(dr["pol_cd"]);
					string pod = ClsConvert.ToString(dr["pod_cd"]);
					string plod = ClsConvert.ToString(dr["plod_cd"]);
					string bkNo = ClsConvert.ToString(dr["booking_no"]);
					string voyNo = ClsConvert.ToString(dr["voyage_no"]);

					bool exactMatch = false;
					StringBuilder sb = new StringBuilder();
					foreach (DataRow drLine in dtLine.Rows)
					{
						string lineplor = ClsConvert.ToString(drLine["plor"]);
						string linepol = ClsConvert.ToString(drLine["pol"]);
						string linepod = ClsConvert.ToString(drLine["pod"]);
						string lineplod = ClsConvert.ToString(drLine["plod"]);
						string linebkNo = ClsConvert.ToString(drLine["booking_no"]);
						string linevoyNo = ClsConvert.ToString(drLine["voyage_no"]);

						bool bookMatch = (string.Compare(linebkNo, bkNo, true) == 0);
						bool voyageMatch = (string.Compare(linevoyNo, voyNo, true) == 0);
						bool toPortMatch = (string.Compare(lineplod, plod, true) == 0 &&
							string.Compare(linepol, pol, true) == 0);
						bool fromPortMatch = (string.Compare(linepod, pod, true) == 0 &&
							string.Compare(lineplod, plod, true) == 0);
						if (toPortMatch && fromPortMatch && voyageMatch && bookMatch)
						{
							exactMatch = true;
							break;
						}

						sb.AppendFormat("Bk {0} Voy {1} {2}-{3}-{4}-{5}\r\n",
							linebkNo, linevoyNo, lineplor, linepol, linepod, lineplod);
					}

					if (exactMatch) continue;

					sb.Insert(0, "Serial # exists but booking info does not match LINE\r\n");
					dr["Line_Flg"] = ClsConvert.ToDbObject("N");
					dr.SetColumnError("Line_Flg", sb.ToString());
				}
			}

			ClsReportObject ro = new ClsReportObject();
			ro.Title = "Duplicate TCNs";
			ro.ReportDisplayType = PushType.Grid;
			ro.Company_Nm = "ARC";
			ro.Report_Data = dt;

			ClsReportColumn rc = new ClsReportColumn("ESTIMATE_No", "Estimate #");
			rc.ColumnType = "Link";
			ro.AddColumn(rc);

			rc = ro.AddColumn("Tcn_Occurs", "TCN Occurs", null);
			rc.HeaderAlignment = "Center";
			rc.TextAlignment = "Far";
			ro.AddColumn(rc);

			rc = ro.AddColumn("Line_Flg", "In LINE", null);
			rc.HeaderAlignment = "Center";
			rc.TextAlignment = "Center";
			rc.CheckboxFalseValue = "N";
			rc.CheckboxTrueValue = "Y";
			rc.ColumnType = "Checkbox";
			ro.AddColumn(rc);

			rc = ro.AddColumn("Billable_Flg", "Billable", null);
			rc.HeaderAlignment = "Center";
			rc.TextAlignment = "Center";
			rc.CheckboxFalseValue = "N";
			rc.CheckboxTrueValue = "Y";
			rc.ColumnType = "Checkbox";
			ro.AddColumn(rc);

			rc = ro.AddColumn("Payable_Flg", "Payable", null);
			rc.HeaderAlignment = "Center";
			rc.TextAlignment = "Center";
			rc.CheckboxFalseValue = "N";
			rc.CheckboxTrueValue = "Y";
			rc.ColumnType = "Checkbox";
			ro.AddColumn(rc);

			rc = ro.AddColumn("Plor_Cd", "PLOR Cd", null);
			rc.SetVisibility(true, false, true, true);
			ro.AddColumn(rc);

			rc = ro.AddColumn("Pol_Cd", "POL Cd", null);
			rc.SetVisibility(true, false, true, true);
			ro.AddColumn(rc);

			rc = ro.AddColumn("Pod_Cd", "POD Cd", null);
			rc.SetVisibility(true, false, true, true);
			ro.AddColumn(rc);

			rc = ro.AddColumn("Plod_Cd", "PLOD Cd", null);
			rc.SetVisibility(true, false, true, true);
			ro.AddColumn(rc);

			//ro.DefineGroups("SAIL_DT");

			return ro;
		}
		#endregion

		#region UPdate Port Type Stuff
		public static DataTable GetPortChangeLog()
		{
			string sql = string.Format(@"
				select * from A_VOYAGE_PORT_CHANGE t
					order by datestamp desc ");
			return Connection.GetDataTable(sql);
		}
		public static void LogPortTypeChange(
			string sManr, string sSeqno,
			string sVoyage, string sPort, string sType,
			string sNewVoyage, string sNewPort, string sNewType,
			string sUser
			)
		{
			string sql = string.Format(@"
				insert into a_voyage_port_change
				(
				 datestamp, userstamp, rhrmanr, rhseqno,
				 prev_voyage, prev_port, prev_type,
				 new_voyage, new_port, new_type)
				 values
				 (
				  sysdate, '{0}', {1},{2},
				  '{3}','{4}','{5}', '{6}','{7}','{8}'
				  )", sUser, sManr, sSeqno, sVoyage, sPort, sType,
					sNewVoyage, sNewPort, sNewType);

			Connection.RunSQL(sql);
		}
		#endregion
	}
}