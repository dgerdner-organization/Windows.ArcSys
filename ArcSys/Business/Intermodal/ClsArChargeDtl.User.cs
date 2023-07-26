using System;
using System.Data;
using System.Text;
using System.Reflection;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsArChargeDtl
	{
		#region Constructors/Initialization

		public override void SetDefaults()
		{
			ResetColumns();
		}
		#endregion		// #region Constructors/Initialization

		#region ToString Overrides

		public override string ToString()
		{
			return string.Format("DTL ID {0}, ACT ID: {1} {2}, {3} {4} {5} {6}",
				Ar_Charge_Dtl_ID, Cargo_Activity_ID, Activity_Amt, Ar_Charge,
				Booking_No, Vessel_Cd, Voyage_No);
		}

		public string ToString(string fmt)
		{
			switch (fmt)
			{
				case "d":
				case "D":
					return string.Format("DTL ID {0}, ACT ID: {1} Amt {2} Qty {3}",
						Ar_Charge_Dtl_ID, Cargo_Activity_ID, Activity_Amt, Activity_Unit_Qty);
				default: return ToString();
			}
		}
		#endregion		// #region ToString Overrides

		#region Validation

		public override bool ValidateInsert()
		{
			_Errors.Clear();

			CommonValidation(false);

			return _Errors.Count == 0;
		}

		public bool ValidateInsert(bool doNotCheckChargeID)
		{
			_Errors.Clear();
			ResetWarnings();

			CommonValidation(doNotCheckChargeID);

			return _Errors.Count == 0;
		}

		public override bool ValidateUpdate()
		{
			_Errors.Clear();
			ResetWarnings();

			CommonValidation(false);

			return _Errors.Count == 0;
		}

		private void CommonValidation(bool doNotCheckChargeID)
		{
			if (doNotCheckChargeID == false)
			{
				if (Ar_Charge_ID == null)
					_Errors["Ar_Charge_ID"] = "Missing AR charge ID";
			}
			if (Cargo_Activity_ID == null)
				_Errors["Cargo_Activity_ID"] = "Missing cargo activity ID";
			if (Activity_Amt == null)
				_Errors["Activity_Amt"] = "Missing activity amount";
			else
			{	// 2013-01-14: Allow negatives
				/*if (Activity_Amt < 0)
					_Errors["Activity_Amt"] = "Activity amount must be greater than or equal to zero";*/
			}

			if (string.IsNullOrWhiteSpace(Booking_No)) AddWarning("Missing booking #");
			if (string.IsNullOrWhiteSpace(Customer_Ref)) AddWarning("Missing PCFN");
			if (string.IsNullOrWhiteSpace(Vessel_Cd)) AddWarning("Missing vessel code");
			if (string.IsNullOrWhiteSpace(Voyage_No)) AddWarning("Missing voyage");
			if (string.IsNullOrWhiteSpace(Plor_Location_Cd)) AddWarning("Missing PLOR");
			if (string.IsNullOrWhiteSpace(Pol_Location_Cd)) AddWarning("Missing POL");
			if (string.IsNullOrWhiteSpace(Pod_Location_Cd)) AddWarning("Missing POD");
			if (string.IsNullOrWhiteSpace(Plod_Location_Cd)) AddWarning("Missing PLOD");
			if (string.IsNullOrWhiteSpace(Serial_No)) AddWarning("Missing serial #");
			if (string.IsNullOrWhiteSpace(Move_Type_Cd)) AddWarning("Missing move type");
			//container is optional if (string.IsNullOrWhiteSpace(Container_No)) AddWarning("Missing container");
			if (string.IsNullOrWhiteSpace(Cargo_Key)) AddWarning("Missing cargo key");
			if (Sail_Dt == null) AddWarning("Missing sail date");
			if (Length_Nbr == null) AddWarning("Missing length");
			if (Width_Nbr == null) AddWarning("Missing width");
			if (Height_Nbr == null) AddWarning("Missing height");
			if (Weight_Nbr == null) AddWarning("Missing weight");
			if (Dim_Weight_Nbr == null) AddWarning("Missing dim weight");
			if (Cube_Ft == null) AddWarning("Missing CFt");
			if (M_Tons == null) AddWarning("Missing MT");
		}
		#endregion		// #region Validation

		public bool HasAmtChanges { get; set; }
		public bool HasDimChanges { get; set; }
		public bool HasCargoChanges { get; set; }		// cargo changes other than dimensions
		public bool HasBookingChanges { get; set; }

		public bool RefreshFromBookingCargo(out string info)
		{
			info = null;
			HasDimChanges = false;
			HasCargoChanges = false;
			HasBookingChanges = false;

			ClsCargo c = Cargo_Activity.Cargo;
			ClsBooking bk = c.Booking;
			StringBuilder sbArdtlChanges = new StringBuilder();
			if (string.Compare(Customer_Ref, bk.Customer_Ref, true) != 0)
			{
				sbArdtlChanges.AppendFormat("PCFN {0} to {1} ", Customer_Ref, bk.Customer_Ref);
				HasBookingChanges = true;
			}
			if (string.Compare(Booking_No, bk.Booking_No, true) != 0)
			{
				sbArdtlChanges.AppendFormat("Booking {0} to {1} ", Booking_No, bk.Booking_No);
				HasBookingChanges = true;
			}
			if (string.Compare(Vessel_Cd, bk.Vessel_Cd, true) != 0)
			{
				sbArdtlChanges.AppendFormat("Vessel {0} to {1} ", Vessel_Cd, bk.Vessel_Cd);
				HasBookingChanges = true;
			}
			if (string.Compare(Voyage_No, bk.Voyage_No, true) != 0)
			{
				sbArdtlChanges.AppendFormat("Voyage {0} to {1} ", Voyage_No, bk.Voyage_No);
				HasBookingChanges = true;
			}
			if (Sail_Dt != bk.Sail_Dt)
			{
				sbArdtlChanges.AppendFormat("Sail Date {0} to {1} ",
					ClsConfig.FormatDate(Sail_Dt), ClsConfig.FormatDate(bk.Sail_Dt));
				HasBookingChanges = true;
			}
			if (string.Compare(Plor_Location_Cd, bk.Plor_Location_Cd, true) != 0)
			{
				sbArdtlChanges.AppendFormat("PLOR {0} to {1} ", Plor_Location_Cd, bk.Plor_Location_Cd);
				HasBookingChanges = true;
			}
			if (string.Compare(Pol_Location_Cd, bk.Pol_Location_Cd, true) != 0)
			{
				sbArdtlChanges.AppendFormat("POL {0} to {1} ", Pol_Location_Cd, bk.Pol_Location_Cd);
				HasBookingChanges = true;
			}
			if (string.Compare(Pod_Location_Cd, bk.Pod_Location_Cd, true) != 0)
			{
				sbArdtlChanges.AppendFormat("POD {0} to {1} ", Pod_Location_Cd, bk.Pod_Location_Cd);
				HasBookingChanges = true;
			}
			if (string.Compare(Plod_Location_Cd, bk.Plod_Location_Cd, true) != 0)
			{
				sbArdtlChanges.AppendFormat("PLOD {0} to {1} ", Plod_Location_Cd, bk.Plod_Location_Cd);
				HasBookingChanges = true;
			}

			Customer_Ref = bk.Customer_Ref;
			Booking_No = bk.Booking_No;
			Vessel_Cd = bk.Vessel_Cd;
			Voyage_No = bk.Voyage_No;
			Sail_Dt = bk.Sail_Dt;
			Plor_Location_Cd = bk.Plor_Location_Cd;
			Pol_Location_Cd = bk.Pol_Location_Cd;
			Pod_Location_Cd = bk.Pod_Location_Cd;
			Plod_Location_Cd = bk.Plod_Location_Cd;

			if (string.Compare(Serial_No, c.Serial_No, true) != 0)
			{
				sbArdtlChanges.AppendFormat("Serial# {0} to {1} ", Serial_No, c.Serial_No);
				HasCargoChanges = true;
			}
			if (string.Compare(Move_Type_Cd, c.Move_Type_Cd, true) != 0)
			{
				sbArdtlChanges.AppendFormat("MoveType {0} to {1} ", Move_Type_Cd, c.Move_Type_Cd);
				HasCargoChanges = true;
			}
			if (string.Compare(Container_No, c.Container_No, true) != 0)
			{
				sbArdtlChanges.AppendFormat("Container# {0} to {1} ", Container_No, c.Container_No);
				HasCargoChanges = true;
			}
			if (string.Compare(Cargo_Key, c.Cargo_Key, true) != 0)
			{
				sbArdtlChanges.AppendFormat("CargoKey {0} to {1} ", Cargo_Key, c.Cargo_Key);
				HasCargoChanges = true;
			}

			Serial_No = c.Serial_No;
			Move_Type_Cd = c.Move_Type_Cd;
			Container_No = c.Container_No;
			Cargo_Key = c.Cargo_Key;

			if (Length_Nbr != c.Length_Nbr)
			{
				sbArdtlChanges.AppendFormat("Length {0} to {1} ", Length_Nbr, c.Length_Nbr);
				HasDimChanges = true;
			}
			if (Width_Nbr != c.Width_Nbr)
			{
				sbArdtlChanges.AppendFormat("Width {0} to {1} ", Width_Nbr, c.Width_Nbr);
				HasDimChanges = true;
			}
			if (Height_Nbr != c.Height_Nbr)
			{
				sbArdtlChanges.AppendFormat("Height {0} to {1} ", Height_Nbr, c.Height_Nbr);
				HasDimChanges = true;
			}
			if (Weight_Nbr != c.Weight_Nbr)
			{
				sbArdtlChanges.AppendFormat("Weight {0} to {1} ", Weight_Nbr, c.Weight_Nbr);
				HasDimChanges = true;
			}
			if (Dim_Weight_Nbr != c.Dim_Weight_Nbr)
			{
				sbArdtlChanges.AppendFormat("DWgt {0} to {1} ", Dim_Weight_Nbr, c.Dim_Weight_Nbr);
				HasDimChanges = true;
			}
			if (Cube_Ft != c.Cube_Ft)
			{
				sbArdtlChanges.AppendFormat("CFt {0} to {1} ", Cube_Ft, c.Cube_Ft);
				HasDimChanges = true;
			}
			if (M_Tons != c.M_Tons)
			{
				sbArdtlChanges.AppendFormat("MTons {0} to {1} ", M_Tons, c.M_Tons);
				HasDimChanges = true;
			}

			Length_Nbr = c.Length_Nbr;
			Width_Nbr = c.Width_Nbr;
			Height_Nbr = c.Height_Nbr;
			Weight_Nbr = c.Weight_Nbr;
			Dim_Weight_Nbr = c.Dim_Weight_Nbr;
			Cube_Ft = c.Cube_Ft;
			M_Tons = c.M_Tons;

			if (sbArdtlChanges.Length > 0) info = sbArdtlChanges.ToString();

			return (HasBookingChanges || HasDimChanges || HasCargoChanges);
		}

		public decimal? GetPropertyValue(PropertyInfo pi)
		{
			object o = pi.GetValue(this, null);
			return ClsConvert.ToDecimalNullable(o);
		}

		public bool RefreshAmounts(decimal? rateAmt, PropertyInfo pi, out string info)
		{
			info = null;
			HasAmtChanges = false;

			decimal? uQty = GetPropertyValue(pi);
			decimal tAmt = rateAmt.GetValueOrDefault(0) * uQty.GetValueOrDefault(0);
			decimal tcnAmt = Math.Round(tAmt, 2, MidpointRounding.AwayFromZero);

			StringBuilder sbArdtlChanges = new StringBuilder();
			if (Activity_Unit_Qty != uQty)
			{
				sbArdtlChanges.AppendFormat("Act Unit Qty {0} to {1} ", Activity_Unit_Qty, uQty);
				HasAmtChanges = true;
				Activity_Unit_Qty = uQty;
			}
			if (Activity_Amt != tcnAmt)
			{
				sbArdtlChanges.AppendFormat("Act Amt {0} to {1} ", Activity_Amt, tcnAmt);
				HasAmtChanges = true;
				Activity_Amt = tcnAmt;
			}

			if (sbArdtlChanges.Length > 0) info = sbArdtlChanges.ToString();

			return HasAmtChanges;
		}

		public bool RefreshAmounts(decimal? tcnAmt, out string info)
		{
			info = null;
			HasAmtChanges = false;

			StringBuilder sbArdtlChanges = new StringBuilder();
			if (Activity_Unit_Qty != null)
			{
				sbArdtlChanges.AppendFormat("Act Unit Qty {0} to blank ", Activity_Unit_Qty);
				HasAmtChanges = true;
				Activity_Unit_Qty = null;
			}
			if (Activity_Amt != tcnAmt)
			{
				sbArdtlChanges.AppendFormat("Act Amt {0} to {1} ", Activity_Amt, tcnAmt);
				HasAmtChanges = true;
				Activity_Amt = tcnAmt;
			}

			if (sbArdtlChanges.Length > 0) info = sbArdtlChanges.ToString();

			return HasAmtChanges;
		}
	}

	#region Static Methods/Properties of ClsArChargeDtl

	partial class ClsArChargeDtl
	{
		public static PropertyInfo GetProperty(string colName)
		{
			Type et = typeof(ClsArChargeDtl);

			PropertyInfo[] pis = et.GetProperties();
			foreach (PropertyInfo pi in pis)
			{
				if (string.Compare(colName, pi.Name, true) == 0) return pi;
			}
			return null;
		}

		public static ClsArChargeDtl GetDuplicateDetail(ClsArCharge archg, long caID,
			bool ignoreChargeID)
		{
			StringBuilder sb = new StringBuilder(@"
			SELECT	ardtl.*
			FROM	t_ar_charge_dtl ardtl
				INNER JOIN t_ar_charge archg	ON archg.ar_charge_id = ardtl.ar_charge_id
				INNER JOIN r_charge_type cht	ON cht.charge_type_cd = archg.charge_type_cd
			WHERE	ardtl.cargo_activity_id = @CA_ID AND
					(
						archg.charge_type_cd = @CHG_CD OR
						cht.charge_category_cd = @CAT_CD
					)");

			List<DbParameter> p = new List<DbParameter>();
			p.Add(Connection.GetParameter("@CA_ID", caID));
			p.Add(Connection.GetParameter("@CHG_CD", archg.Charge_Type_Cd));
			p.Add(Connection.GetParameter("@CAT_CD", archg.Charge_Type.Charge_Category_Cd));

			if( !ignoreChargeID )
				Connection.AppendNotEqualClause(sb, p, "AND",
					"ardtl.ar_charge_id", "@CH_ID", archg.Ar_Charge_ID);

			DataRow dr = Connection.GetDataRow(sb.ToString(), p.ToArray());
			return (dr != null) ? new ClsArChargeDtl(dr) : null;
		}

		public static DataTable GetActivityDetail(long caID)
		{
			string sql = @"
			SELECT	ardtl.*, archg.charge_type_cd, cht.charge_type_dsc, cht.charge_category_cd,
					archg.customer_cd, archg.tcn_count, archg.rate_amt, archg.total_amt,
					archg.memo, lvu.level_unit_dsc, lvu.level_cd, lvu.unit_type_cd,
					lvu.level_count_dsc, lvu.unit_qty_dsc, lvu.average_flg, ut.units_required_flg,
					decode(lvu.average_flg, 'N', null,
						archg.level_count || ' ' || lvu.level_count_dsc) AS level_disp,
					decode(ut.units_required_flg, 'Y', archg.unit_qty || ' ' || ut.grid_column_dsc,
						null) AS unit_disp,
					decode(lvu.average_flg, 'N', nvl(ardtl.activity_unit_qty, 0) ||
						decode(ut.units_required_flg, 'Y', ' ' || ut.grid_column_dsc, null),
						null) AS act_unit_disp,
					oloc.location_dsc AS orig_location_dsc, dloc.location_dsc AS dest_location_dsc,
					oloc.location_dsc || ' to ' || dloc.location_dsc AS orig_dest_location_dsc,
					arinv.invoice_no
			FROM	t_ar_charge_dtl ardtl
					INNER JOIN t_cargo_activity ca		ON ca.cargo_activity_id = ardtl.cargo_activity_id
					INNER JOIN t_ar_charge archg		ON archg.ar_charge_id = ardtl.ar_charge_id
					INNER JOIN t_ar_invoice arinv		ON arinv.ar_invoice_id = archg.ar_invoice_id
					INNER JOIN r_charge_type cht		ON cht.charge_type_cd = archg.charge_type_cd
					INNER JOIN r_level_unit lvu			ON lvu.level_unit_id = archg.level_unit_id
					INNER JOIN r_unit_type ut			ON ut.unit_type_cd = lvu.unit_type_cd
					INNER JOIN r_location oloc			ON oloc.location_cd = ca.orig_location_cd
					INNER JOIN r_location dloc			ON dloc.location_cd = ca.dest_location_cd
			WHERE	ardtl.cargo_activity_id = @CA_ID ";

			DbParameter[] p = new DbParameter[1];
			p[0] = Connection.GetParameter("@CA_ID", caID);

			return Connection.GetDataTable(sql, p);
		}

		public static DataTable GetCargoDetail(long cargoID)
		{
			string sql = @"
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
						null) AS act_unit_disp,
					oloc.location_dsc AS orig_location_dsc, dloc.location_dsc AS dest_location_dsc,
					oloc.location_dsc || ' to ' || dloc.location_dsc AS orig_dest_location_dsc,
					ardtl.activity_amt AS adj_activity_amt,
					ardtl.activity_amt AS adj_total_amt,
					arinv.invoice_no, arinv.customer_cd
			FROM	t_ar_charge_dtl ardtl
					INNER JOIN t_cargo_activity ca		ON ca.cargo_activity_id = ardtl.cargo_activity_id
					INNER JOIN t_ar_charge archg	ON archg.ar_charge_id = ardtl.ar_charge_id
					INNER JOIN t_ar_invoice arinv			ON arinv.ar_invoice_id = archg.ar_invoice_id
					INNER JOIN r_charge_type cht		ON cht.charge_type_cd = archg.charge_type_cd
					INNER JOIN r_level_unit lvu			ON lvu.level_unit_id = archg.level_unit_id
					INNER JOIN r_unit_type ut			ON ut.unit_type_cd = lvu.unit_type_cd
					INNER JOIN r_location oloc			ON oloc.location_cd = ca.orig_location_cd
					INNER JOIN r_location dloc			ON dloc.location_cd = ca.dest_location_cd
			WHERE	ca.cargo_id = @CGO_ID ";

			DbParameter[] p = new DbParameter[1];
			p[0] = Connection.GetParameter("@CGO_ID", cargoID);

			return Connection.GetDataTable(sql, p);
		}
	}
	#endregion		// #region Static Methods/Properties of ClsArChargeDtl
}