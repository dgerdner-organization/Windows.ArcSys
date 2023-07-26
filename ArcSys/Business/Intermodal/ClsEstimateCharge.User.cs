using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsEstimateCharge
	{
		#region Fields/Properties

		public string ChargeHeader(bool includeMode, bool includeFinance, bool includeEst, bool includeID)
		{
			StringBuilder sb = new StringBuilder();
			if (includeMode)
				sb.Append((Estimate_Charge_ID == null) ? "Add" : "Edit");
			if (includeFinance)
				sb.AppendFormat("{0}{1}", (sb.Length > 0 ? " " : null), Finance.FinanceText);
			if( includeEst )
				sb.AppendFormat("{0}Estimate", (sb.Length > 0 ? " " : null));
			if (includeID)
			{
				if (Estimate_Charge_ID != null)
					sb.AppendFormat("{0}Charge ID: {1}",
						(sb.Length > 0 ? " " : null), Estimate_Charge_ID);
			}
			return sb.ToString();
		}
		#endregion		// #region Fields/Properties

		#region Constructors/Initialization

		public override void SetDefaults()
		{
			ResetColumns();

			Tcn_Count = 0;
		}
		#endregion		// #region Constructors/Initialization

		#region ToString Overrides

		public override string ToString()
		{
			string rbas = null;
			try
			{
				if (Level_Unit != null) rbas = Level_Unit.Level_Unit_Dsc;
			}
			catch (Exception ex)
			{
				ClsErrorHandler.LogException(ex);
			}
			return string.Format("ID {0}: {1} {2} {3} x {4} x {5} = {6:c} {7} Est ID {8}",
				Estimate_Charge_ID, Charge_Type_Cd, rbas, Rate_Amt, Level_Count,
				Unit_Qty, Total_Amt, Finance_Cd, Estimate_ID);
		}
		#endregion		// #region ToString Overrides

		#region Validation

		public override bool ValidateInsert()
		{
			_Errors.Clear();

			CommonValidation();

			return _Errors.Count == 0;
		}

		public override bool ValidateUpdate()
		{
			_Errors.Clear();

			CommonValidation();

			return _Errors.Count == 0;
		}

		private void CommonValidation()
		{
			if (string.IsNullOrEmpty(Charge_Type_Cd) == true)
				_Errors["Charge_Type_Cd"] = "Missing or invalid charge type";
			if (Level_Unit_ID == null)
				_Errors["Level_Unit_ID"] = "Missing rate basis";
			else if( Level_Unit == null )
				_Errors["Level_Unit_ID"] = "Invalid rate basis";
			else
			{
				ClsLevel lev = Level_Unit.Level;
				if (lev.IsConveyance)
				{
					ClsChargeType cht = (!string.IsNullOrEmpty(Charge_Type_Cd))
						? ClsChargeType.GetUsingKey(Charge_Type_Cd) : null;
					bool isLH = (cht != null && cht.IsLineHaul);
					if (isLH)
					{
						if (Pcs_Per_Conveyance == null)
							_Errors["Pcs_Per_Conveyance"] = "Missing pieces per conveyance";
						else if (Pcs_Per_Conveyance <= 0)
							_Errors["Pcs_Per_Conveyance"] = "Pieces per conveyance should be greater than zero";
					}
				}
			}

			if (string.IsNullOrEmpty(Finance_Cd))
				_Errors["Finance_Cd"] = "Missing finance code (AR/AP)";

			if (Rate_Amt == null)
				_Errors["Rate_Amt"] = "Missing rate amount";
			else
			{	// 2013-01-14: Allow negatives
				/*if( Rate_Amt < 0 )
					_Errors["Rate_Amt"] = "Rate amount must be greater than or equal to zero";*/
			}

			if (Level_Count == null)
				_Errors["Level_Count"] = "Missing level count";
			else
			{
				if (Level_Count < 0)
					_Errors["Level_Count"] = "Level count must be greater than or equal to zero";
			}

			if (Unit_Qty == null)
				_Errors["Unit_Qty"] = "Missing units";
			else
			{
				if (Unit_Qty < 0)
					_Errors["Unit_Qty"] = "Units must be greater than or equal to zero";
			}

			if (Total_Amt == null)
				_Errors["Total_Amt"] = "Missing total amount";
			else
			{	// 2013-01-14: Allow negatives
				/*if (Total_Amt < 0)
					_Errors["Total_Amt"] = "Total amount must be greater than or equal to zero";*/
			}

			if (Tcn_Count == null)
				_Errors["Tcn_Count"] = "Missing TCN count";
			else
			{
				if (Tcn_Count < 0)
					_Errors["Tcn_Count"] = "TCN count must be greater than or equal to zero";
			}

			if( Estimate_ID == null )
				_Errors["Estimate_ID"] = "Missing estimate ID";
		}
		#endregion		// #region Validation

		public List<ClsEstimateChargeDtl> GetDetail()
		{
			if( Estimate_Charge_ID == null )
				return new List<ClsEstimateChargeDtl>();

			string sql = @"
			SELECT * FROM t_estimate_charge_dtl edt where edt.estimate_charge_id = @ECHG_ID";

			DbParameter[] p = new DbParameter[1];
			p[0] = Connection.GetParameter("@ECHG_ID", Estimate_Charge_ID);

			return Connection.GetList<ClsEstimateChargeDtl>(sql, p);
		}

		public bool SaveChanges(DataTable dtNewDetail)
		{
			if (Estimate_Charge_ID == null)
			{
				if (!ValidateInsert()) return false;
			}
			else
			{
				if (!ValidateUpdate()) return false;
			}

			StringBuilder sbErr = new StringBuilder(), sbWarn = new StringBuilder();
			List<ClsEstimateChargeDtl>
				inserts = new List<ClsEstimateChargeDtl>(),
				updates = new List<ClsEstimateChargeDtl>(),
				deletes = new List<ClsEstimateChargeDtl>();
			if (Estimate_Charge_ID == null)
			{
				foreach (DataRow dr in dtNewDetail.Rows)
				{
					decimal? amt = ClsConvert.ToDecimalNullable(dr["Activity_Amt"]);
					decimal? qty = ClsConvert.ToDecimalNullable(dr["Activity_Unit_Qty"]);
					long? cactID = ClsConvert.ToInt64Nullable(dr["Cargo_Activity_ID"]);
					if (cactID == null)
					{
						sbErr.Append("One or more rows missing cargo activity ID\r\n");
						break;
					}

					ClsEstimateChargeDtl edt =
						ClsEstimateChargeDtl.GetDuplicateDetail(this, cactID.Value, true);
					if (edt != null)
					{
						sbErr.AppendFormat("{0} {1} already has a charge for type {2} or category {3}\r\n",
							edt.Cargo_Activity.Cargo.Cargo_Dsc, edt.Cargo_Activity.Cargo.Serial_No,
							Charge_Type_Cd, Charge_Type.Charge_Category_Cd);
						continue;
					}

					edt = new ClsEstimateChargeDtl();
					edt.SetDefaults();
					edt.Cargo_Activity_ID = cactID;
					edt.Activity_Amt = amt;
					edt.Activity_Unit_Qty = qty;

					edt.Booking_No = ClsConvert.ToString(dr["booking_no"]);
					edt.Customer_Ref = ClsConvert.ToString(dr["customer_ref"]);
					edt.Vessel_Cd = ClsConvert.ToString(dr["vessel_cd"]);
					edt.Voyage_No = ClsConvert.ToString(dr["voyage_no"]);
					edt.Sail_Dt = ClsConvert.ToDateTimeNullable(dr["sail_dt"]);
					edt.Plor_Location_Cd = ClsConvert.ToString(dr["Plor_Location_Cd"]);
					edt.Pol_Location_Cd = ClsConvert.ToString(dr["Pol_Location_Cd"]);
					edt.Pod_Location_Cd = ClsConvert.ToString(dr["Pod_Location_Cd"]);
					edt.Plod_Location_Cd = ClsConvert.ToString(dr["Plod_Location_Cd"]);
					edt.Serial_No = ClsConvert.ToString(dr["Serial_No"]);
					edt.Move_Type_Cd = ClsConvert.ToString(dr["Move_Type_Cd"]);
					edt.Container_No = ClsConvert.ToString(dr["Container_No"]);
					edt.Cargo_Key = ClsConvert.ToString(dr["Cargo_Key"]);
					edt.Length_Nbr = ClsConvert.ToDecimalNullable(dr["length_nbr"]);
					edt.Width_Nbr = ClsConvert.ToDecimalNullable(dr["width_nbr"]);
					edt.Height_Nbr = ClsConvert.ToDecimalNullable(dr["height_nbr"]);
					edt.Weight_Nbr = ClsConvert.ToDecimalNullable(dr["weight_nbr"]);
					edt.Dim_Weight_Nbr = ClsConvert.ToDecimalNullable(dr["dim_weight_nbr"]);
					edt.Cube_Ft = ClsConvert.ToDecimalNullable(dr["cube_ft"]);
					edt.M_Tons = ClsConvert.ToDecimalNullable(dr["m_tons"]);

					if (!edt.ValidateInsert(true))
					{
						sbErr.AppendFormat("{0} {1}: {2}\r\n", edt.Cargo_Activity.Cargo.Cargo_Dsc,
							edt.Cargo_Activity.Cargo.Serial_No, edt.Error);
						continue;
					}

					if (edt.HasWarnings)
						sbWarn.AppendFormat("{0} {1}: {2}\r\n", edt.Cargo_Activity.Cargo.Cargo_Dsc,
							edt.Cargo_Activity.Cargo.Serial_No, edt.Warning);

					inserts.Add(edt);
				}
			}
			else
			{
				List<ClsEstimateChargeDtl> lstDetail = GetDetail();
				if (lstDetail != null)		// Build a list of detail to be deleted
				{
					foreach (ClsEstimateChargeDtl edt in lstDetail)
					{
						string sel = string.Format("Estimate_Charge_Dtl_ID = {0}",
							edt.Estimate_Charge_Dtl_ID);
						DataRow[] rows = dtNewDetail.Select(sel);
						if (rows != null && rows.Length > 0) continue;

						if (!edt.ValidateDelete())
						{
							sbErr.AppendFormat("{0} {1}: {2}\r\n", edt.Cargo_Activity.Cargo.Cargo_Dsc,
								edt.Cargo_Activity.Cargo.Serial_No, edt.Error);
							continue;
						}
						deletes.Add(edt);
					}
				}

				// Then we may have to insert a row for cargo added, or update a row
				foreach (DataRow dr in dtNewDetail.Rows)
				{
					long? edtID = ClsConvert.ToInt64Nullable(dr["Estimate_Charge_Dtl_ID"]);
					decimal? amt = ClsConvert.ToDecimalNullable(dr["Activity_Amt"]);
					decimal? qty = ClsConvert.ToDecimalNullable(dr["Activity_Unit_Qty"]);
					if (edtID == null) // no detail ID then new cargo, insert
					{
						long? cactID = ClsConvert.ToInt64Nullable(dr["Cargo_Activity_ID"]);
						if (cactID == null)
						{
							sbErr.Append("One or more rows missing cargo activity ID\r\n");
							break;
						}

						ClsEstimateChargeDtl edt =
							ClsEstimateChargeDtl.GetDuplicateDetail(this, cactID.Value, true);
						if (edt != null)
						{
							sbErr.AppendFormat("{0} {1} already has a charge for type {2} or category {3}\r\n",
								edt.Cargo_Activity.Cargo.Cargo_Dsc, edt.Cargo_Activity.Cargo.Serial_No,
								Charge_Type_Cd, Charge_Type.Charge_Category_Cd);
							continue;
						}

						edt = new ClsEstimateChargeDtl();
						edt.SetDefaults();
						edt.Estimate_Charge_ID = Estimate_Charge_ID;
						edt.Cargo_Activity_ID = cactID;
						edt.Activity_Amt = amt;
						edt.Activity_Unit_Qty = qty;

						edt.Booking_No = ClsConvert.ToString(dr["booking_no"]);
						edt.Customer_Ref = ClsConvert.ToString(dr["customer_ref"]);
						edt.Vessel_Cd = ClsConvert.ToString(dr["vessel_cd"]);
						edt.Voyage_No = ClsConvert.ToString(dr["voyage_no"]);
						edt.Sail_Dt = ClsConvert.ToDateTimeNullable(dr["sail_dt"]);
						edt.Plor_Location_Cd = ClsConvert.ToString(dr["Plor_Location_Cd"]);
						edt.Pol_Location_Cd = ClsConvert.ToString(dr["Pol_Location_Cd"]);
						edt.Pod_Location_Cd = ClsConvert.ToString(dr["Pod_Location_Cd"]);
						edt.Plod_Location_Cd = ClsConvert.ToString(dr["Plod_Location_Cd"]);
						edt.Serial_No = ClsConvert.ToString(dr["Serial_No"]);
						edt.Move_Type_Cd = ClsConvert.ToString(dr["Move_Type_Cd"]);
						edt.Container_No = ClsConvert.ToString(dr["Container_No"]);
						edt.Cargo_Key = ClsConvert.ToString(dr["Cargo_Key"]);
						edt.Length_Nbr = ClsConvert.ToDecimalNullable(dr["length_nbr"]);
						edt.Width_Nbr = ClsConvert.ToDecimalNullable(dr["width_nbr"]);
						edt.Height_Nbr = ClsConvert.ToDecimalNullable(dr["height_nbr"]);
						edt.Weight_Nbr = ClsConvert.ToDecimalNullable(dr["weight_nbr"]);
						edt.Dim_Weight_Nbr = ClsConvert.ToDecimalNullable(dr["dim_weight_nbr"]);
						edt.Cube_Ft = ClsConvert.ToDecimalNullable(dr["cube_ft"]);
						edt.M_Tons = ClsConvert.ToDecimalNullable(dr["m_tons"]);

						if (!edt.ValidateInsert())
						{
							sbErr.AppendFormat("{0} {1}: {2}\r\n", edt.Cargo_Activity.Cargo.Cargo_Dsc,
								edt.Cargo_Activity.Cargo.Serial_No, edt.Error);
							continue;
						}

						if (edt.HasWarnings)
							sbWarn.AppendFormat("{0} {1}: {2}\r\n", edt.Cargo_Activity.Cargo.Cargo_Dsc,
								edt.Cargo_Activity.Cargo.Serial_No, edt.Warning);

						inserts.Add(edt);
					}
					else
					{
						ClsEstimateChargeDtl edt = ClsEstimateChargeDtl.GetUsingKey(edtID.Value);

						edt.Activity_Amt = amt;
						edt.Activity_Unit_Qty = qty;

						edt.Booking_No = ClsConvert.ToString(dr["booking_no"]);
						edt.Customer_Ref = ClsConvert.ToString(dr["customer_ref"]);
						edt.Vessel_Cd = ClsConvert.ToString(dr["vessel_cd"]);
						edt.Voyage_No = ClsConvert.ToString(dr["voyage_no"]);
						edt.Sail_Dt = ClsConvert.ToDateTimeNullable(dr["sail_dt"]);
						edt.Plor_Location_Cd = ClsConvert.ToString(dr["Plor_Location_Cd"]);
						edt.Pol_Location_Cd = ClsConvert.ToString(dr["Pol_Location_Cd"]);
						edt.Pod_Location_Cd = ClsConvert.ToString(dr["Pod_Location_Cd"]);
						edt.Plod_Location_Cd = ClsConvert.ToString(dr["Plod_Location_Cd"]);
						edt.Serial_No = ClsConvert.ToString(dr["Serial_No"]);
						edt.Move_Type_Cd = ClsConvert.ToString(dr["Move_Type_Cd"]);
						edt.Container_No = ClsConvert.ToString(dr["Container_No"]);
						edt.Cargo_Key = ClsConvert.ToString(dr["Cargo_Key"]);
						edt.Length_Nbr = ClsConvert.ToDecimalNullable(dr["length_nbr"]);
						edt.Width_Nbr = ClsConvert.ToDecimalNullable(dr["width_nbr"]);
						edt.Height_Nbr = ClsConvert.ToDecimalNullable(dr["height_nbr"]);
						edt.Weight_Nbr = ClsConvert.ToDecimalNullable(dr["weight_nbr"]);
						edt.Dim_Weight_Nbr = ClsConvert.ToDecimalNullable(dr["dim_weight_nbr"]);
						edt.Cube_Ft = ClsConvert.ToDecimalNullable(dr["cube_ft"]);
						edt.M_Tons = ClsConvert.ToDecimalNullable(dr["m_tons"]);

						if (!edt.ValidateUpdate())
						{
							sbErr.AppendFormat("{0} {1}: {2}\r\n", edt.Cargo_Activity.Cargo.Cargo_Dsc,
								edt.Cargo_Activity.Cargo.Serial_No, edt.Error);
							continue;
						}

						if (edt.HasWarnings)
							sbWarn.AppendFormat("{0} {1}: {2}\r\n", edt.Cargo_Activity.Cargo.Cargo_Dsc,
								edt.Cargo_Activity.Cargo.Serial_No, edt.Warning);

						updates.Add(edt);
					}
				}
			}

			if (sbWarn.Length > 0) AddWarning(sbWarn.ToString());

			if (sbErr.Length > 0)
			{
				_Errors["Save"] = sbErr.ToString();
				return false;
			}

			bool newTx = !Connection.IsInTransaction;
			try
			{
				if (newTx == true) Connection.TransactionBegin();

				if (Estimate_Charge_ID == null)
				{								// For new charges, insert charge, insert detail
					Insert();
					foreach (ClsEstimateChargeDtl edt in inserts)
					{
						edt.Estimate_Charge_ID = Estimate_Charge_ID;
						edt.Insert();
					}
				}
				else
				{							// For existing charge
					Update();				// Update it

					foreach (ClsEstimateChargeDtl edt in deletes)
						edt.Delete();

					foreach (ClsEstimateChargeDtl edt in updates)
						edt.Update();

					foreach (ClsEstimateChargeDtl edt in inserts)
						edt.Insert();
				}

				if (newTx == true) Connection.TransactionCommit();

				return true;
			}
			catch
			{
				if (newTx == true) Connection.TransactionRollback();
				throw;
			}
		}

		public bool DeleteChargePlusDetail()
		{
			if (!ValidateDelete()) return false;

			bool newTx = !Connection.IsInTransaction;
			try
			{
				if (newTx == true) Connection.TransactionBegin();

				List<ClsEstimateChargeDtl> lstDetail = GetDetail();
				foreach (ClsEstimateChargeDtl edt in lstDetail)
					edt.Delete();
				Delete();

				if (newTx == true) Connection.TransactionCommit();
				return true;
			}
			catch
			{
				if (newTx == true) Connection.TransactionRollback();
				throw;
			}
		}
		public DataSet GetActivitiesPlusCharges()
		{
			DataSet ds = new DataSet();

			DataTable dtCargo = GetChargeActivities();
			ds.Tables.Add(dtCargo);

			//if (dtCargo.Rows.Count > 0)
			//{
				DataTable dtCharges = GetActivityCharges(true);
				ds.Tables.Add(dtCharges);

				DataColumn[] dcPK = new DataColumn[1];
				dcPK[0] = dtCargo.Columns["CARGO_ACTIVITY_ID"];

				DataColumn[] dcFK = new DataColumn[1];
				dcFK[0] = dtCharges.Columns["CARGO_ACTIVITY_ID"];

				ds.Relations.Add("ChargeActivitiesCharges", dcPK, dcFK, false);
			//}

			return ds;
		}

		public DataTable GetChargeActivities()
		{
			//if (_Estimate_Charge_ID == null) return null;
			/*
					decode(est.orig_location_cd, bk.plor_location_cd, 'DOOR TO PORT',
						bk.pod_location_cd, 'PORT TO DOOR', 'UNKNOWN') as direction_txt,
			*/
			string sql = @"
			SELECT	ca.*, est.*, c.item_no, c.dim_weight_nbr, c.cube_ft, c.m_tons,
					oloc.location_dsc as orig_location_dsc, dloc.location_dsc as dest_location_dsc,
					c.booking_id, c.serial_no, c.commodity_cd, c.pkg_type_cd,
					c.length_nbr, c.width_nbr, c.height_nbr, c.weight_nbr, c.move_type_cd,
					c.cargo_dsc, c.container_no, c.seal1, c.seal2, c.seal3, c.vessel_load_dt,
					c.make_cd, c.model_cd, c.contract_mod_id, c.cargo_key, bk.booking_no,
					bk.booking_ref, bk.plor_location_cd, bk.pol_location_cd, bk.pod_location_cd,
					bk.plod_location_cd, bk.bol_no, bk.edi_ref, bk.customer_ref,
					bk.vessel_cd, ves.vessel_nm, bk.voyage_no as bk_voyage_no, bk.sail_dt,
					bk.delivery_txt, bk.cargo_notes_txt, bk.customer_cd, bk.match_cd, cust.customer_nm,
					bk.booking_no || ' -' || to_char(c.item_no, '00') as bk_item_no,
					c.length_nbr || ' x ' || c.width_nbr || ' x ' || c.height_nbr || ' - ' ||
						bk.booking_no || ' Item Group' || to_char(c.item_no, '00') as lwh_bk_item_no,
					c.length_nbr || ' x ' || c.width_nbr || ' x ' || c.height_nbr as len_wid_hgt,
					c.cargo_dsc || ' ' || c.length_nbr || ' x ' || c.width_nbr || ' x ' ||
						c.height_nbr as cargo_dsc_lwh,
					decode(ca.orig_location_cd, null, 0, est.orig_location_cd, 0, 1) as mismatch_orig,
					decode(ca.dest_location_cd, null, 0, est.dest_location_cd, 0, 1) as mismatch_dest,
					decode(bk.voyage_no, null, 0, est.voyage_no, 0, 1) as mismatch_voy,
					decode(estoloc.conus_flg, 'Y', 'CONUS', 'N', 'OCONUS', '?') as conus_txt,
					DECODE(oloc.location_type_cd, 'LAND', 'DOOR', 'PORT', 'PORT', 'UNKNOWN') ||
						' TO ' || DECODE(dloc.location_type_cd, 'LAND', 'DOOR', 'PORT', 'PORT',
						'UNKNOWN') as direction_txt,
					cmod.mod_no, cmod.attachment_nm,
					DECODE(cmod.contract_mod_id, NULL, NULL, cmod.mod_no || ' - ' ||
						NVL(cmod.attachment_nm, '<No Attachment>')) AS mod_no_attachment_nm,
					edt.estimate_charge_dtl_id, edt.estimate_charge_id, edt.activity_amt,
					edt.activity_unit_qty,
					decode(lvu.average_flg, 'N', nvl(edt.activity_unit_qty, 0) ||
						decode(ut.units_required_flg, 'Y', ' ' || ut.grid_column_dsc, null),
						null) AS act_unit_disp
			FROM	t_estimate_charge_dtl edt
				INNER JOIN t_estimate_charge echg	ON echg.estimate_charge_id = edt.estimate_charge_id
				INNER JOIN r_level_unit lvu			ON lvu.level_unit_id = echg.level_unit_id
				INNER JOIN r_unit_type ut			ON ut.unit_type_cd = lvu.unit_type_cd
				INNER JOIN t_cargo_activity ca		ON ca.cargo_activity_id = edt.cargo_activity_id
				INNER JOIN t_cargo c				ON c.cargo_id = ca.cargo_id
				INNER JOIN t_booking bk				ON bk.booking_id = c.booking_id
				INNER JOIN r_location oloc			ON oloc.location_cd = ca.orig_location_cd
				INNER JOIN r_location dloc			ON dloc.location_cd = ca.dest_location_cd
				INNER JOIN r_vessel ves				ON ves.vessel_cd = bk.vessel_cd
				LEFT OUTER JOIN t_estimate est
					INNER JOIN r_location estoloc	ON estoloc.location_cd = est.orig_location_cd
					INNER JOIN r_location estdloc	ON estdloc.location_cd = est.dest_location_cd
													ON est.estimate_id = ca.estimate_id
				LEFT OUTER JOIN r_customer cust		ON cust.customer_cd = bk.customer_cd
				LEFT OUTER JOIN t_contract_mod cmod ON cmod.contract_mod_id = c.contract_mod_id
			WHERE	edt.estimate_charge_id = @ECHG_ID
			ORDER BY	c.cargo_dsc, c.serial_no";

			DbParameter[] p = new DbParameter[1];
			p[0] = Connection.GetParameter("@ECHG_ID", Estimate_Charge_ID.GetValueOrDefault(-1));

			DataTable dt = Connection.GetDataTable(sql, p);
			if (dt != null)
			{
				dt.TableName = "ChargeActivities";
				//dt.Columns.Add("Cubic_Ft", typeof(int), "(length_nbr * width_nbr * height_nbr) / 1728");
				//dt.Columns.Add("MTons", typeof(int), "(length_nbr * width_nbr * height_nbr) / 1728 / 40");
			}
			return dt;
		}

		public DataTable GetActivityCharges(bool isOnCharge)
		{
			//if (_Estimate_Charge_ID == null) return null;

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
						null) AS act_unit_disp
			FROM	t_estimate_charge_dtl edt
					INNER JOIN t_estimate_charge echg	ON echg.estimate_charge_id = edt.estimate_charge_id
					INNER JOIN r_charge_type cht		ON cht.charge_type_cd = echg.charge_type_cd
					INNER JOIN r_level_unit lvu			ON lvu.level_unit_id = echg.level_unit_id
					INNER JOIN r_unit_type ut			ON ut.unit_type_cd = lvu.unit_type_cd
			WHERE	echg.estimate_id = @EST_ID AND
					echg.finance_cd = @FIN_CD ");

			List<DbParameter> p = new List<DbParameter>();
			p.Add(Connection.GetParameter("@EST_ID", Estimate_ID.GetValueOrDefault(-1)));
			p.Add(Connection.GetParameter("@FIN_CD", Finance_Cd));

			if (isOnCharge)
				Connection.AppendEqualClause(sb, p, "AND",
					"edt.estimate_charge_id", "@ECHG_ID", Estimate_Charge_ID.GetValueOrDefault(-1));
			else
				Connection.AppendNotEqualClause(sb, p, "AND",
					"edt.estimate_charge_id", "@ECHG_ID", Estimate_Charge_ID);

			sb.Append(@"
			order by echg.estimate_id, cht.charge_category_cd, echg.charge_type_cd ");

			DataTable dt = Connection.GetDataTable(sb.ToString(), p.ToArray());
			if (dt != null)
			{
				dt.TableName = "ActivityCharges";
			}
			return dt;
		}

		public DataSet GetAvailableActivitiesPlusCharges()
		{
			DataSet ds = new DataSet();

			DataTable dtCargo = GetAvailableActivities();
			ds.Tables.Add(dtCargo);

			//if (dtCargo.Rows.Count > 0)
			//{
				DataTable dtCharges = GetActivityCharges(false);
				ds.Tables.Add(dtCharges);

				DataColumn[] dcPK = new DataColumn[1];
				dcPK[0] = dtCargo.Columns["CARGO_ACTIVITY_ID"];

				DataColumn[] dcFK = new DataColumn[1];
				dcFK[0] = dtCharges.Columns["CARGO_ACTIVITY_ID"];

				ds.Relations.Add("AvailableActivitiesCharges", dcPK, dcFK, false);
			//}

			return ds;
		}

		public DataTable GetAvailableActivities()
		{
			ClsEstimateSearch search = new ClsEstimateSearch();
			search.Estimate_ID = Estimate_ID;
			if (Finance.IsAP)
			{
				search.Billable_Flg = null;
				search.Payable_Flg = "Y";
			}
			else if (Finance.IsAR)
			{
				search.Billable_Flg = "Y";
				search.Payable_Flg = null;
			}
			
			DataTable dt = search.SearchEstimateAvailableActivities(Estimate_Charge_ID, false);
			if (dt != null)
			{
				dt.TableName = "AvailableActivities";
			}
			return dt;
		}

		public bool HasAmtChanges { get; set; }
		public bool Compare(ClsEstimateCharge origChg)
		{
			HasAmtChanges = false;

			if (origChg.Level_Count != this.Level_Count)
				HasAmtChanges = true;
			else if (origChg.Rate_Amt != this.Rate_Amt)
				HasAmtChanges = true;
			else if (origChg.Tcn_Count != this.Tcn_Count)
				HasAmtChanges = true;
			else if (origChg.Total_Amt != this.Total_Amt)
				HasAmtChanges = true;
			else if (origChg.Unit_Qty != this.Unit_Qty)
				HasAmtChanges = true;

			return HasAmtChanges;
		}
	}

	#region Static Methods/Properties of ClsEstimateCharge

	partial class ClsEstimateCharge
	{
		public static decimal GetSum(long? est_id, string finCd)
		{
			StringBuilder sb = new StringBuilder(@"
			select	sum(echg.total_amt) as total_amt
			from	t_estimate_charge echg
			where	1=1 ");

			List<DbParameter> p = new List<DbParameter>();
			Connection.AppendEqualClause(sb, p, "AND",
				"echg.estimate_id", "@EST_ID", est_id);
			Connection.AppendEqualClause(sb, p, "AND",
				"echg.finance_cd", "@APR_IND", finCd);

			object oSum = Connection.GetScalar(sb.ToString(), p.ToArray());
			decimal? sum = ClsConvert.ToDecimalNullable(oSum);
			return sum.GetValueOrDefault(0);
		}

		public static DataTable GetChargesDT(long? est_id, string finCd)
		{
			//TODO: JROMAN to replace level_count column with a string
			// like 1 Truck(s), 2 PCFNs, 10 TCNs, etc. everywhere there is
			// a grid with the level/units shown (cargo tab, search windows, etc.)
			StringBuilder sb = new StringBuilder(@"
			select	echg.*, cht.charge_category_cd,
					lvu.level_unit_dsc, lvu.level_cd, lvu.unit_type_cd, lvu.level_count_dsc,
					lvu.unit_qty_dsc, lvu.average_flg, ut.units_required_flg,
					decode(lvu.average_flg, 'N', null,
						echg.level_count || ' ' || lvu.level_count_dsc) AS level_disp,
					decode(ut.units_required_flg, 'Y', echg.unit_qty || ' ' || ut.grid_column_dsc,
						null) as unit_disp
			from	t_estimate_charge echg
				inner join r_charge_type cht	on cht.charge_type_cd = echg.charge_type_cd
				inner join r_level_unit lvu		on lvu.level_unit_id = echg.level_unit_id
				inner join r_unit_type ut		on ut.unit_type_cd = lvu.unit_type_cd

			where	1=1 ");

			List<DbParameter> p = new List<DbParameter>();
			Connection.AppendEqualClause(sb, p, "AND",
				"echg.estimate_id", "@EST_ID", est_id);
			Connection.AppendEqualClause(sb, p, "AND",
				"echg.finance_cd", "@APR_IND", finCd);

			sb.Append(@"
			order by echg.estimate_id, lvu.level_cd, cht.charge_category_cd, echg.charge_type_cd ");

			return Connection.GetDataTable(sb.ToString(), p.ToArray());
		}

		public static List<ClsEstimateCharge> GetChargesList(long? est_id, string finCd)
		{
			StringBuilder sb = new StringBuilder(@"
			select	echg.*
			from	t_estimate_charge echg
				inner join r_charge_type cht on cht.charge_type_cd = echg.charge_type_cd
				inner join r_level_unit lvu on lvu.level_unit_id = echg.level_unit_id
			where	1=1 ");

			List<DbParameter> p = new List<DbParameter>();
			Connection.AppendEqualClause(sb, p, "AND",
				"echg.estimate_id", "@EST_ID", est_id);
			Connection.AppendEqualClause(sb, p, "AND",
				"echg.finance_cd", "@APR_IND", finCd);

			sb.Append(@"
			order by echg.estimate_id, lvu.level_cd, cht.charge_category_cd, echg.charge_type_cd ");

			return Connection.GetList<ClsEstimateCharge>(sb.ToString(), p.ToArray());
		}

		public static List<ClsEstimateCharge> GetDistinctChargeList(long est_id, string csvCA)
		{
			StringBuilder sb = new StringBuilder(@"
			SELECT	echg.estimate_charge_id, echg.estimate_id, echg.create_user, echg.create_dt,
					echg.modify_user, echg.modify_dt, echg.charge_type_cd, echg.level_unit_id,
					echg.rate_amt, echg.level_count, echg.unit_qty, echg.total_amt, echg.finance_cd,
					echg.tcn_count, echg.pcs_per_conveyance, echg.contract_mod_id, echg.vendor_cd,
					echg.customer_cd, echg.memo
			FROM	t_estimate_charge_dtl edt
				INNER JOIN t_estimate_charge echg ON echg.estimate_charge_id = edt.estimate_charge_id
			WHERE	1 = 1 ");

			List<DbParameter> p = new List<DbParameter>();
			Connection.AppendEqualClause(sb, p, "AND", "echg.estimate_id", "@EST_ID", est_id);
			Connection.AppendInClause(sb, p, "AND", "edt.cargo_activity_id", "@CA_ID", csvCA);

			sb.Append(@"
			GROUP BY
					echg.estimate_charge_id, echg.estimate_id, echg.create_user, echg.create_dt,
					echg.modify_user, echg.modify_dt, echg.charge_type_cd, echg.level_unit_id,
					echg.rate_amt, echg.level_count, echg.unit_qty, echg.total_amt, echg.finance_cd,
					echg.tcn_count, echg.pcs_per_conveyance, echg.contract_mod_id, echg.vendor_cd,
					echg.customer_cd, echg.memo ");

			return Connection.GetList<ClsEstimateCharge>(sb.ToString(), p.ToArray());
		}

		public static bool ModifyCharges(ClsEstimate anEstimate, DataTable dtCharges, out string extraInfo)
		{
			extraInfo = null;
			if (dtCharges == null)
				throw new ClsException(true, "No data table provided");

			int errors = 0;
			Dictionary<ClsEstimateCharge, DataRowState> Charges = new Dictionary<ClsEstimateCharge, DataRowState>();
			foreach (DataRow dr in dtCharges.Rows)
			{
				if (dr.RowState == DataRowState.Detached || dr.RowState == DataRowState.Unchanged)
					continue;

				dr.ClearErrors();
				ClsEstimateCharge echg = null;
				if (dr.RowState == DataRowState.Deleted)
				{
					long? id = ClsConvert.ToInt64Nullable(dr["Estimate_Charge_ID", DataRowVersion.Original]);
					echg = ClsEstimateCharge.GetUsingKey(id.Value);
					if (!echg.ValidateDelete())
					{
						errors++;
						echg.FillError(dr);
						dr.RowError = echg.Error;
					}
				}
				else if (dr.RowState == DataRowState.Modified)
				{
					echg = new ClsEstimateCharge(dr);
					if (!echg.ValidateUpdate())
					{
						errors++;
						echg.FillError(dr);
						dr.RowError = echg.Error;
					}
				}
				else
				{
					echg = new ClsEstimateCharge(dr);
					echg.Estimate_ID = anEstimate.Estimate_ID;
					if (!echg.ValidateInsert())
					{
						errors++;
						echg.FillError(dr);
						dr.RowError = echg.Error;
					}
				}
				if (!dr.HasErrors) Charges.Add(echg, dr.RowState);
			}

			if (errors > 0) return false;

			bool newTx = !Connection.IsInTransaction;
			try
			{
				StringBuilder sb = new StringBuilder();
				if (newTx == true) Connection.TransactionBegin();
				foreach (ClsEstimateCharge echg in Charges.Keys)
				{
					DataRowState state = Charges[echg];
					if (state == DataRowState.Deleted)
						echg.Delete();
					else if (state == DataRowState.Modified)
						echg.Update();
					else if (state == DataRowState.Added)
						echg.Insert();
					sb.AppendFormat("{0} - {1}\r\n", state, echg);
				}
				if (newTx == true) Connection.TransactionCommit();

				extraInfo = sb.ToString();
				return true;
			}
			catch
			{
				if (newTx == true) Connection.TransactionRollback();
				throw;
			}
		}
	}
	#endregion		// #region Static Methods/Properties of ClsEstimateCharge
}