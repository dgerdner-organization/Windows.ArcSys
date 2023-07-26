using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsArCharge
	{
		#region Fields/Properties

		public string ChargeHeader(bool includeMode, bool includeFinance, bool includeInv, bool includeID)
		{
			StringBuilder sb = new StringBuilder();
			if (includeMode)
				sb.Append((Ar_Charge_ID == null) ? "Add" : "Edit");
			if (includeFinance)
				sb.AppendFormat("{0}{1}", (sb.Length > 0 ? " " : null),
					ClsFinance.Codes.ToText("AR", 0));
			if( includeInv )
				sb.AppendFormat("{0}Invoice", (sb.Length > 0 ? " " : null));
			if (includeID)
			{
				if (Ar_Charge_ID != null)
					sb.AppendFormat("{0}Charge ID: {1}",
						(sb.Length > 0 ? " " : null), Ar_Charge_ID);
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
			return string.Format("ID {0}: {1} {2} {3} x {4} x {5} = {6:c} Inv ID {7}",
				Ar_Charge_ID, Charge_Type_Cd, rbas, Rate_Amt, Level_Count, Unit_Qty, Total_Amt,
				Ar_Invoice_ID);
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

			if( Ar_Invoice_ID == null )
				_Errors["Ar_Invoice_ID"] = "Missing ar invoice ID";
		}
		#endregion		// #region Validation

		public List<ClsArChargeDtl> GetDetail()
		{
			if( Ar_Charge_ID == null )
				return new List<ClsArChargeDtl>();

			string sql = @"
			SELECT * FROM t_ar_charge_dtl ardtl where ardtl.ar_charge_id = @ARCHG_ID";

			DbParameter[] p = new DbParameter[1];
			p[0] = Connection.GetParameter("@ARCHG_ID", Ar_Charge_ID);

			return Connection.GetList<ClsArChargeDtl>(sql, p);
		}

		public bool SaveChanges(DataTable dtNewDetail)
		{
			if (Ar_Charge_ID == null)
			{
				if (!ValidateInsert()) return false;
			}
			else
			{
				if (!ValidateUpdate()) return false;
			}

			StringBuilder sbErr = new StringBuilder(), sbWarn = new StringBuilder();
			List<ClsArChargeDtl>
				inserts = new List<ClsArChargeDtl>(),
				updates = new List<ClsArChargeDtl>(),
				deletes = new List<ClsArChargeDtl>();
			if (Ar_Charge_ID == null)
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

					ClsArChargeDtl ardtl =
						ClsArChargeDtl.GetDuplicateDetail(this, cactID.Value, true);
					if (ardtl != null)
					{
						sbErr.AppendFormat("{0} {1} already has a charge for type {2} or category {3}\r\n",
							ardtl.Cargo_Activity.Cargo.Cargo_Dsc, ardtl.Cargo_Activity.Cargo.Serial_No,
							Charge_Type_Cd, Charge_Type.Charge_Category_Cd);
						continue;
					}

					ardtl = new ClsArChargeDtl();
					ardtl.SetDefaults();
					ardtl.Cargo_Activity_ID = cactID;
					ardtl.Activity_Amt = amt;
					ardtl.Activity_Unit_Qty = qty;

					ardtl.Booking_No = ClsConvert.ToString(dr["booking_no"]);
					ardtl.Customer_Ref = ClsConvert.ToString(dr["customer_ref"]);
					ardtl.Vessel_Cd = ClsConvert.ToString(dr["vessel_cd"]);
					ardtl.Voyage_No = ClsConvert.ToString(dr["voyage_no"]);
					ardtl.Sail_Dt = ClsConvert.ToDateTimeNullable(dr["sail_dt"]);
					ardtl.Plor_Location_Cd = ClsConvert.ToString(dr["Plor_Location_Cd"]);
					ardtl.Pol_Location_Cd = ClsConvert.ToString(dr["Pol_Location_Cd"]);
					ardtl.Pod_Location_Cd = ClsConvert.ToString(dr["Pod_Location_Cd"]);
					ardtl.Plod_Location_Cd = ClsConvert.ToString(dr["Plod_Location_Cd"]);
					ardtl.Serial_No = ClsConvert.ToString(dr["Serial_No"]);
					ardtl.Move_Type_Cd = ClsConvert.ToString(dr["Move_Type_Cd"]);
					ardtl.Container_No = ClsConvert.ToString(dr["Container_No"]);
					ardtl.Cargo_Key = ClsConvert.ToString(dr["Cargo_Key"]);
					ardtl.Length_Nbr = ClsConvert.ToDecimalNullable(dr["length_nbr"]);
					ardtl.Width_Nbr = ClsConvert.ToDecimalNullable(dr["width_nbr"]);
					ardtl.Height_Nbr = ClsConvert.ToDecimalNullable(dr["height_nbr"]);
					ardtl.Weight_Nbr = ClsConvert.ToDecimalNullable(dr["weight_nbr"]);
					ardtl.Dim_Weight_Nbr = ClsConvert.ToDecimalNullable(dr["dim_weight_nbr"]);
					ardtl.Cube_Ft = ClsConvert.ToDecimalNullable(dr["cube_ft"]);
					ardtl.M_Tons = ClsConvert.ToDecimalNullable(dr["m_tons"]);

					if (!ardtl.ValidateInsert(true))
					{
						sbErr.AppendFormat("{0} {1}: {2}\r\n", ardtl.Cargo_Activity.Cargo.Cargo_Dsc,
							ardtl.Cargo_Activity.Cargo.Serial_No, ardtl.Error);
						continue;
					}

					if (ardtl.HasWarnings)
						sbWarn.AppendFormat("{0} {1}: {2}\r\n", ardtl.Cargo_Activity.Cargo.Cargo_Dsc,
							ardtl.Cargo_Activity.Cargo.Serial_No, ardtl.Warning);

					inserts.Add(ardtl);
				}
			}
			else
			{
				List<ClsArChargeDtl> lstDetail = GetDetail();
				if (lstDetail != null)		// Build a list of detail to be deleted
				{
					foreach (ClsArChargeDtl ardtl in lstDetail)
					{
						string sel = string.Format("Ar_Charge_Dtl_ID = {0}",
							ardtl.Ar_Charge_Dtl_ID);
						DataRow[] rows = dtNewDetail.Select(sel);
						if (rows != null && rows.Length > 0) continue;

						if (!ardtl.ValidateDelete())
						{
							sbErr.AppendFormat("{0} {1}: {2}\r\n", ardtl.Cargo_Activity.Cargo.Cargo_Dsc,
								ardtl.Cargo_Activity.Cargo.Serial_No, ardtl.Error);
							continue;
						}
						deletes.Add(ardtl);
					}
				}

				// Then we may have to insert a row for cargo added, or update a row
				foreach (DataRow dr in dtNewDetail.Rows)
				{
					long? ardtlID = ClsConvert.ToInt64Nullable(dr["Ar_Charge_Dtl_ID"]);
					decimal? amt = ClsConvert.ToDecimalNullable(dr["Activity_Amt"]);
					decimal? qty = ClsConvert.ToDecimalNullable(dr["Activity_Unit_Qty"]);
					if (ardtlID == null) // no detail ID then new cargo, insert
					{
						long? cactID = ClsConvert.ToInt64Nullable(dr["Cargo_Activity_ID"]);
						if (cactID == null)
						{
							sbErr.Append("One or more rows missing cargo activity ID\r\n");
							break;
						}

						ClsArChargeDtl ardtl =
							ClsArChargeDtl.GetDuplicateDetail(this, cactID.Value, true);
						if (ardtl != null)
						{
							sbErr.AppendFormat("{0} {1} already has a charge for type {2} or category {3}\r\n",
								ardtl.Cargo_Activity.Cargo.Cargo_Dsc, ardtl.Cargo_Activity.Cargo.Serial_No,
								Charge_Type_Cd, Charge_Type.Charge_Category_Cd);
							continue;
						}

						ardtl = new ClsArChargeDtl();
						ardtl.SetDefaults();
						ardtl.Ar_Charge_ID = Ar_Charge_ID;
						ardtl.Cargo_Activity_ID = cactID;
						ardtl.Activity_Amt = amt;
						ardtl.Activity_Unit_Qty = qty;

						ardtl.Booking_No = ClsConvert.ToString(dr["booking_no"]);
						ardtl.Customer_Ref = ClsConvert.ToString(dr["customer_ref"]);
						ardtl.Vessel_Cd = ClsConvert.ToString(dr["vessel_cd"]);
						ardtl.Voyage_No = ClsConvert.ToString(dr["voyage_no"]);
						ardtl.Sail_Dt = ClsConvert.ToDateTimeNullable(dr["sail_dt"]);
						ardtl.Plor_Location_Cd = ClsConvert.ToString(dr["Plor_Location_Cd"]);
						ardtl.Pol_Location_Cd = ClsConvert.ToString(dr["Pol_Location_Cd"]);
						ardtl.Pod_Location_Cd = ClsConvert.ToString(dr["Pod_Location_Cd"]);
						ardtl.Plod_Location_Cd = ClsConvert.ToString(dr["Plod_Location_Cd"]);
						ardtl.Serial_No = ClsConvert.ToString(dr["Serial_No"]);
						ardtl.Move_Type_Cd = ClsConvert.ToString(dr["Move_Type_Cd"]);
						ardtl.Container_No = ClsConvert.ToString(dr["Container_No"]);
						ardtl.Cargo_Key = ClsConvert.ToString(dr["Cargo_Key"]);
						ardtl.Length_Nbr = ClsConvert.ToDecimalNullable(dr["length_nbr"]);
						ardtl.Width_Nbr = ClsConvert.ToDecimalNullable(dr["width_nbr"]);
						ardtl.Height_Nbr = ClsConvert.ToDecimalNullable(dr["height_nbr"]);
						ardtl.Weight_Nbr = ClsConvert.ToDecimalNullable(dr["weight_nbr"]);
						ardtl.Dim_Weight_Nbr = ClsConvert.ToDecimalNullable(dr["dim_weight_nbr"]);
						ardtl.Cube_Ft = ClsConvert.ToDecimalNullable(dr["cube_ft"]);
						ardtl.M_Tons = ClsConvert.ToDecimalNullable(dr["m_tons"]);

						if (!ardtl.ValidateInsert())
						{
							sbErr.AppendFormat("{0} {1}: {2}\r\n", ardtl.Cargo_Activity.Cargo.Cargo_Dsc,
								ardtl.Cargo_Activity.Cargo.Serial_No, ardtl.Error);
							continue;
						}

						if (ardtl.HasWarnings)
							sbWarn.AppendFormat("{0} {1}: {2}\r\n", ardtl.Cargo_Activity.Cargo.Cargo_Dsc,
								ardtl.Cargo_Activity.Cargo.Serial_No, ardtl.Warning);

						inserts.Add(ardtl);
					}
					else
					{
						ClsArChargeDtl ardtl = ClsArChargeDtl.GetUsingKey(ardtlID.Value);

						ardtl.Activity_Amt = amt;
						ardtl.Activity_Unit_Qty = qty;

						ardtl.Booking_No = ClsConvert.ToString(dr["booking_no"]);
						ardtl.Customer_Ref = ClsConvert.ToString(dr["customer_ref"]);
						ardtl.Vessel_Cd = ClsConvert.ToString(dr["vessel_cd"]);
						ardtl.Voyage_No = ClsConvert.ToString(dr["voyage_no"]);
						ardtl.Sail_Dt = ClsConvert.ToDateTimeNullable(dr["sail_dt"]);
						ardtl.Plor_Location_Cd = ClsConvert.ToString(dr["Plor_Location_Cd"]);
						ardtl.Pol_Location_Cd = ClsConvert.ToString(dr["Pol_Location_Cd"]);
						ardtl.Pod_Location_Cd = ClsConvert.ToString(dr["Pod_Location_Cd"]);
						ardtl.Plod_Location_Cd = ClsConvert.ToString(dr["Plod_Location_Cd"]);
						ardtl.Serial_No = ClsConvert.ToString(dr["Serial_No"]);
						ardtl.Move_Type_Cd = ClsConvert.ToString(dr["Move_Type_Cd"]);
						ardtl.Container_No = ClsConvert.ToString(dr["Container_No"]);
						ardtl.Cargo_Key = ClsConvert.ToString(dr["Cargo_Key"]);
						ardtl.Length_Nbr = ClsConvert.ToDecimalNullable(dr["length_nbr"]);
						ardtl.Width_Nbr = ClsConvert.ToDecimalNullable(dr["width_nbr"]);
						ardtl.Height_Nbr = ClsConvert.ToDecimalNullable(dr["height_nbr"]);
						ardtl.Weight_Nbr = ClsConvert.ToDecimalNullable(dr["weight_nbr"]);
						ardtl.Dim_Weight_Nbr = ClsConvert.ToDecimalNullable(dr["dim_weight_nbr"]);
						ardtl.Cube_Ft = ClsConvert.ToDecimalNullable(dr["cube_ft"]);
						ardtl.M_Tons = ClsConvert.ToDecimalNullable(dr["m_tons"]);

						if (!ardtl.ValidateUpdate())
						{
							sbErr.AppendFormat("{0} {1}: {2}\r\n", ardtl.Cargo_Activity.Cargo.Cargo_Dsc,
								ardtl.Cargo_Activity.Cargo.Serial_No, ardtl.Error);
							continue;
						}

						if (ardtl.HasWarnings)
							sbWarn.AppendFormat("{0} {1}: {2}\r\n", ardtl.Cargo_Activity.Cargo.Cargo_Dsc,
								ardtl.Cargo_Activity.Cargo.Serial_No, ardtl.Warning);

						updates.Add(ardtl);
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

				if (Ar_Charge_ID == null)
				{								// For new charges, insert charge, insert detail
					Insert();
					foreach (ClsArChargeDtl ardtl in inserts)
					{
						ardtl.Ar_Charge_ID = Ar_Charge_ID;
						ardtl.Insert();
					}
				}
				else
				{							// For existing charge
					Update();				// Update it

					foreach (ClsArChargeDtl ardtl in deletes)
						ardtl.Delete();

					foreach (ClsArChargeDtl ardtl in updates)
						ardtl.Update();

					foreach (ClsArChargeDtl ardtl in inserts)
						ardtl.Insert();
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

				List<ClsArChargeDtl> lstDetail = GetDetail();
				foreach (ClsArChargeDtl ardtl in lstDetail)
					ardtl.Delete();
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
		// TODO: JROMAN handle arinv.orig_location and mismatches (not just port, port and direction)
		// also handle other mismatches, voyage, booking, vessel, etc.
		public DataTable GetChargeActivities()
		{
			string sql = @"
			SELECT	ca.*, arinv.*, c.item_no, c.dim_weight_nbr, c.cube_ft, c.m_tons,
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
					decode(ca.orig_location_cd, null, 0, arinv.port_location_cd, 0, 1) as mismatch_orig,
					decode(ca.dest_location_cd, null, 0, arinv.port_location_cd, 0, 1) as mismatch_dest,
					decode(bk.voyage_no, null, 0, arinv.voyage_no, 0, 1) as mismatch_voy,
					decode(ploc.conus_flg, 'Y', 'CONUS', 'N', 'OCONUS', '?') as conus_txt,
					DECODE(oloc.location_type_cd, 'LAND', 'DOOR', 'PORT', 'PORT', 'UNKNOWN') ||
						' TO ' || DECODE(dloc.location_type_cd, 'LAND', 'DOOR', 'PORT', 'PORT',
						'UNKNOWN') as direction_txt,
					cmod.mod_no, cmod.attachment_nm,
					DECODE(cmod.contract_mod_id, NULL, NULL, cmod.mod_no || ' - ' ||
						NVL(cmod.attachment_nm, '<No Attachment>')) AS mod_no_attachment_nm,
					ardtl.ar_charge_dtl_id, ardtl.ar_charge_id, ardtl.activity_amt,
					ardtl.activity_unit_qty,
					decode(lvu.average_flg, 'N', nvl(ardtl.activity_unit_qty, 0) ||
						decode(ut.units_required_flg, 'Y', ' ' || ut.grid_column_dsc, null),
						null) AS act_unit_disp
			FROM	t_ar_charge_dtl ardtl
				INNER JOIN t_ar_charge archg		ON archg.ar_charge_id = ardtl.ar_charge_id
				INNER JOIN r_level_unit lvu			ON lvu.level_unit_id = archg.level_unit_id
				INNER JOIN r_unit_type ut			ON ut.unit_type_cd = lvu.unit_type_cd
				INNER JOIN t_cargo_activity ca		ON ca.cargo_activity_id = ardtl.cargo_activity_id
				INNER JOIN t_cargo c				ON c.cargo_id = ca.cargo_id
				INNER JOIN t_booking bk				ON bk.booking_id = c.booking_id
				INNER JOIN r_location oloc			ON oloc.location_cd = ca.orig_location_cd
				INNER JOIN r_location dloc			ON dloc.location_cd = ca.dest_location_cd
				INNER JOIN r_vessel ves				ON ves.vessel_cd = bk.vessel_cd
				LEFT OUTER JOIN t_ar_invoice arinv
					INNER JOIN r_location ploc		ON ploc.location_cd = arinv.port_location_cd
													ON arinv.ar_invoice_id = ca.ar_invoice_id
				LEFT OUTER JOIN r_customer cust		ON cust.customer_cd = bk.customer_cd
				LEFT OUTER JOIN t_contract_mod cmod ON cmod.contract_mod_id = c.contract_mod_id
			WHERE	ardtl.ar_charge_id = @ARCHG_ID
			ORDER BY	c.cargo_dsc, c.serial_no";

			DbParameter[] p = new DbParameter[1];
			p[0] = Connection.GetParameter("@ARCHG_ID", Ar_Charge_ID.GetValueOrDefault(-1));

			DataTable dt = Connection.GetDataTable(sql, p);
			if (dt != null)
			{
				dt.TableName = "ChargeActivities";
			}
			return dt;
		}

		public DataTable GetActivityCharges(bool isOnCharge)
		{
			StringBuilder sb = new StringBuilder(@"
			SELECT	ardtl.*, archg.charge_type_cd, cht.charge_type_dsc, cht.charge_category_cd,
					archg.tcn_count, archg.rate_amt, archg.total_amt, archg.memo,
					lvu.level_unit_dsc, lvu.level_cd, lvu.unit_type_cd,
					lvu.level_count_dsc, lvu.unit_qty_dsc, lvu.average_flg, ut.units_required_flg,
					decode(lvu.average_flg, 'N', null,
						archg.level_count || ' ' || lvu.level_count_dsc) AS level_disp,
					decode(ut.units_required_flg, 'Y', archg.unit_qty || ' ' || ut.grid_column_dsc,
						null) AS unit_disp,
					decode(lvu.average_flg, 'N', nvl(ardtl.activity_unit_qty, 0) ||
						decode(ut.units_required_flg, 'Y', ' ' || ut.grid_column_dsc, null),
						null) AS act_unit_disp
			FROM	t_ar_charge_dtl ardtl
					INNER JOIN t_ar_charge archg		ON archg.ar_charge_id = ardtl.ar_charge_id
					INNER JOIN r_charge_type cht		ON cht.charge_type_cd = archg.charge_type_cd
					INNER JOIN r_level_unit lvu			ON lvu.level_unit_id = archg.level_unit_id
					INNER JOIN r_unit_type ut			ON ut.unit_type_cd = lvu.unit_type_cd
			WHERE	archg.ar_invoice_id = @ARINV_ID ");

			List<DbParameter> p = new List<DbParameter>();
			p.Add(Connection.GetParameter("@ARINV_ID", Ar_Invoice_ID.GetValueOrDefault(-1)));

			if (isOnCharge)
				Connection.AppendEqualClause(sb, p, "AND",
					"ardtl.ar_charge_id", "@ARCHG_ID", Ar_Charge_ID.GetValueOrDefault(-1));
			else
				Connection.AppendNotEqualClause(sb, p, "AND",
					"ardtl.ar_charge_id", "@ARCHG_ID", Ar_Charge_ID);

			sb.Append(@"
			order by archg.ar_invoice_id, cht.charge_category_cd, archg.charge_type_cd ");

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
			ClsArInvoiceSearch search = new ClsArInvoiceSearch();
			search.Ar_Invoice_ID = Ar_Invoice_ID;
			DataTable dt = search.SearchExistingActivities(Ar_Charge_ID, false);
			if (dt != null)
			{
				dt.TableName = "AvailableActivities";
			}
			return dt;
		}

		public bool HasAmtChanges { get; set; }
		public bool Compare(ClsArCharge origChg)
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

	#region Static Methods/Properties of ClsArCharge

	partial class ClsArCharge
	{
		public static decimal GetSum(long? arinv_id)
		{
			StringBuilder sb = new StringBuilder(@"
			select	sum(archg.total_amt) as total_amt
			from	t_ar_charge archg
			where	1=1 ");

			List<DbParameter> p = new List<DbParameter>();
			Connection.AppendEqualClause(sb, p, "AND",
				"archg.ar_invoice_id", "@ARINV_ID", arinv_id);

			object oSum = Connection.GetScalar(sb.ToString(), p.ToArray());
			decimal? sum = ClsConvert.ToDecimalNullable(oSum);
			return sum.GetValueOrDefault(0);
		}

		public static DataTable GetChargesDT(long? arinv_id)
		{
			//TODO: JROMAN to replace level_count column with a string
			// like 1 Truck(s), 2 PCFNs, 10 TCNs, etc. everywhere there is
			// a grid with the level/units shown (cargo tab, search windows, etc.)
			StringBuilder sb = new StringBuilder(@"
			select	archg.*, cht.charge_category_cd,
					lvu.level_unit_dsc, lvu.level_cd, lvu.unit_type_cd, lvu.level_count_dsc,
					lvu.unit_qty_dsc, lvu.average_flg, ut.units_required_flg,
					decode(lvu.average_flg, 'N', null,
						archg.level_count || ' ' || lvu.level_count_dsc) AS level_disp,
					decode(ut.units_required_flg, 'Y', archg.unit_qty || ' ' || ut.grid_column_dsc,
						null) as unit_disp
			from	t_ar_charge archg
				inner join r_charge_type cht	on cht.charge_type_cd = archg.charge_type_cd
				inner join r_level_unit lvu		on lvu.level_unit_id = archg.level_unit_id
				inner join r_unit_type ut		on ut.unit_type_cd = lvu.unit_type_cd

			where	1=1 ");

			List<DbParameter> p = new List<DbParameter>();
			Connection.AppendEqualClause(sb, p, "AND",
				"archg.ar_invoice_id", "@ARINV_ID", arinv_id);

			sb.Append(@"
			order by archg.ar_invoice_id, lvu.level_cd, cht.charge_category_cd, archg.charge_type_cd ");

			return Connection.GetDataTable(sb.ToString(), p.ToArray());
		}

		public static List<ClsArCharge> GetChargesList(long? arinv_id)
		{
			StringBuilder sb = new StringBuilder(@"
			select	archg.*
			from	t_ar_charge archg
				inner join r_charge_type cht on cht.charge_type_cd = archg.charge_type_cd
				inner join r_level_unit lvu on lvu.level_unit_id = archg.level_unit_id
			where	1=1 ");

			List<DbParameter> p = new List<DbParameter>();
			Connection.AppendEqualClause(sb, p, "AND",
				"archg.ar_invoice_id", "@ARINV_ID", arinv_id);

			sb.Append(@"
			order by archg.ar_invoice_id, lvu.level_cd, cht.charge_category_cd, archg.charge_type_cd ");

			return Connection.GetList<ClsArCharge>(sb.ToString(), p.ToArray());
		}

		public static List<ClsArCharge> GetDistinctChargeList(long arinv_id, string csvCA)
		{
			StringBuilder sb = new StringBuilder(@"
			SELECT	archg.ar_charge_id, archg.ar_invoice_id, archg.create_user, archg.create_dt,
					archg.modify_user, archg.modify_dt, archg.charge_type_cd, archg.level_unit_id,
					archg.rate_amt, archg.level_count, archg.unit_qty, archg.total_amt,
					archg.tcn_count, archg.pcs_per_conveyance, archg.contract_mod_id,
					archg.memo
			FROM	t_ar_charge_dtl ardtl
				INNER JOIN t_ar_charge archg ON archg.ar_charge_id = ardtl.ar_charge_id
			WHERE	1 = 1 ");

			List<DbParameter> p = new List<DbParameter>();
			Connection.AppendEqualClause(sb, p, "AND", "archg.ar_invoice_id", "@ARINV_ID", arinv_id);
			Connection.AppendInClause(sb, p, "AND", "ardtl.cargo_activity_id", "@CA_ID", csvCA);

			sb.Append(@"
			GROUP BY
					archg.ar_charge_id, archg.ar_invoice_id, archg.create_user, archg.create_dt,
					archg.modify_user, archg.modify_dt, archg.charge_type_cd, archg.level_unit_id,
					archg.rate_amt, archg.level_count, archg.unit_qty, archg.total_amt,
					archg.tcn_count, archg.pcs_per_conveyance, archg.contract_mod_id,
					archg.memo ");

			return Connection.GetList<ClsArCharge>(sb.ToString(), p.ToArray());
		}

		public static bool ModifyCharges(ClsArInvoice anInvoice, DataTable dtCharges, out string extraInfo)
		{
			extraInfo = null;
			if (dtCharges == null)
				throw new ClsException(true, "No data table provided");

			int errors = 0;
			Dictionary<ClsArCharge, DataRowState> Charges = new Dictionary<ClsArCharge, DataRowState>();
			foreach (DataRow dr in dtCharges.Rows)
			{
				if (dr.RowState == DataRowState.Detached || dr.RowState == DataRowState.Unchanged)
					continue;

				dr.ClearErrors();
				ClsArCharge archg = null;
				if (dr.RowState == DataRowState.Deleted)
				{
					long? id = ClsConvert.ToInt64Nullable(dr["Ar_Charge_ID", DataRowVersion.Original]);
					archg = ClsArCharge.GetUsingKey(id.Value);
					if (!archg.ValidateDelete())
					{
						errors++;
						archg.FillError(dr);
						dr.RowError = archg.Error;
					}
				}
				else if (dr.RowState == DataRowState.Modified)
				{
					archg = new ClsArCharge(dr);
					if (!archg.ValidateUpdate())
					{
						errors++;
						archg.FillError(dr);
						dr.RowError = archg.Error;
					}
				}
				else
				{
					archg = new ClsArCharge(dr);
					archg.Ar_Invoice_ID = anInvoice.Ar_Invoice_ID;
					if (!archg.ValidateInsert())
					{
						errors++;
						archg.FillError(dr);
						dr.RowError = archg.Error;
					}
				}
				if (!dr.HasErrors) Charges.Add(archg, dr.RowState);
			}

			if (errors > 0) return false;

			bool newTx = !Connection.IsInTransaction;
			try
			{
				StringBuilder sb = new StringBuilder();
				if (newTx == true) Connection.TransactionBegin();
				foreach (ClsArCharge archg in Charges.Keys)
				{
					DataRowState state = Charges[archg];
					if (state == DataRowState.Deleted)
						archg.Delete();
					else if (state == DataRowState.Modified)
						archg.Update();
					else if (state == DataRowState.Added)
						archg.Insert();
					sb.AppendFormat("{0} - {1}\r\n", state, archg);
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
	#endregion		// #region Static Methods/Properties of ClsArCharge
}