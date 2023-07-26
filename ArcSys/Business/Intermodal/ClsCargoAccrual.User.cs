using System;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;
using System.Text;

namespace CS2010.ArcSys.Business
{
	public partial class ClsCargoAccrual
	{
		#region Constructors/Initialization

		public ClsCargoAccrual(ClsEstimateChargeDtl edt)
		{
			Estimate_Charge_ID = edt.Estimate_Charge_ID;
			Cargo_Activity_ID = edt.Cargo_Activity_ID;
			Activity_Amt = edt.Activity_Amt;
			Activity_Unit_Qty = edt.Activity_Unit_Qty;

			Customer_Ref = edt.Customer_Ref;
			Booking_No = edt.Booking_No;
			Vessel_Cd = edt.Vessel_Cd;
			Voyage_No = edt.Voyage_No;
			Sail_Dt = edt.Sail_Dt;
			Plor_Location_Cd = edt.Plor_Location_Cd;
			Pol_Location_Cd = edt.Pol_Location_Cd;
			Pod_Location_Cd = edt.Pod_Location_Cd;
			Plod_Location_Cd = edt.Plod_Location_Cd;

			Serial_No = edt.Serial_No;
			Move_Type_Cd = edt.Move_Type_Cd;
			Container_No = edt.Container_No;
			Cargo_Key = edt.Cargo_Key;

			Length_Nbr = edt.Length_Nbr;
			Width_Nbr = edt.Width_Nbr;
			Height_Nbr = edt.Height_Nbr;
			Cube_Ft = edt.Cube_Ft;
			M_Tons = edt.M_Tons;
			Weight_Nbr = edt.Weight_Nbr;
			Dim_Weight_Nbr = edt.Dim_Weight_Nbr;

			ClsEstimateCharge echg = edt.Estimate_Charge;
			ClsEstimate est = echg.Estimate;

			Estimate_No = est.Estimate_No;
			Est_Orig_Location_Cd = est.Orig_Location_Cd;
			Est_Dest_Location_Cd = est.Dest_Location_Cd;

			Charge_Type_Cd = echg.Charge_Type_Cd;
			Level_Unit_ID = echg.Level_Unit_ID;
			Rate_Amt = echg.Rate_Amt;
			Level_Count = echg.Level_Count;
			Unit_Qty = echg.Unit_Qty;
			Total_Amt = echg.Total_Amt;
			Tcn_Count = echg.Tcn_Count;
			Vendor_Cd = echg.Vendor_Cd;
		}
		public override void SetDefaults()
		{
			ResetColumns();
		}
		#endregion		// #region Constructors/Initialization

		#region ToString Overrides

		public override string ToString()
		{
			return string.Format("{0}: CargoActID {1}, EstChgID {2}, Bk {3}  Accrued/Submitted {4}/{5}",
				Cargo_Accrual_ID, Cargo_Activity_ID, Estimate_Charge_ID, Booking_No, Sail_Dt, Submitted_Dt);
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
			if (Cargo_Activity_ID == null )
				_Errors["Cargo_Activity_ID"] = "Missing cargo activity ID";
			if (Estimate_Charge_ID == null)
				_Errors["Estimate_Charge_ID"] = "Missing estimate charge ID";

			if (Activity_Amt == null)
				_Errors["Activity_Amt"] = "Missing activity amount";
			else
			{	// 2013-01-14: Allow negatives
				/*if (Activity_Amt < 0)
					_Errors["Activity_Amt"] = "Activity amount must be greater than or equal to zero";*/
			}
		}
		#endregion		// #region Validation
	}

	#region Static Properties/Methods

	partial class ClsCargoAccrual
	{
		public static ClsCargoAccrual GetUsingDetail(long cargoActID, long estChargeID)
		{
			string sql = @"
			SELECT	acc.*
			FROM	t_cargo_accrual acc
			WHERE	acc.cargo_activity_ID = @CACT_ID and acc.estimate_charge_id = @CHG_ID";

			DbParameter[] p = new DbParameter[2];
			p[0] = Connection.GetParameter("@CACT_ID", cargoActID);
			p[1] = Connection.GetParameter("@CHG_ID", estChargeID);

			DataRow dr = Connection.GetDataRow(sql, p);
			return (dr != null) ? new ClsCargoAccrual(dr) : null;
		}

		public static bool AccrualExists(DateRange dates)
		{
			StringBuilder sb = new StringBuilder(@"
			SELECT	COUNT(acc.cargo_accrual_id)
			FROM	t_cargo_accrual acc ");

			List<DbParameter> p = new List<DbParameter>();
			Connection.AppendDateClause(sb, p, "WHERE", "acc.sail_dt", "@SL_FR", "@SL_TO", dates);

			object o = Connection.GetScalar(sb.ToString(), p.ToArray());
			long? accRows = ClsConvert.ToInt64Nullable(o);

			return accRows.GetValueOrDefault(0) > 0;
		}

		public static bool AccrueCharges(DataTable dt, DateRange accDates, out string errorMsg, out string warnMsg)
		{
			warnMsg = null;
			errorMsg = null;

			if (AccrualExists(accDates))
			{
				errorMsg = string.Format("Accrual already submitted for {0}",
					accDates.FromDate.ToString("MMMM yyyy"));
				return false;
			}

			StringBuilder sb = new StringBuilder(), sbWarn = new StringBuilder();

			List<ClsCargoAccrual> lst = new List<ClsCargoAccrual>();
			DateTime submitted = DateTime.Now;
			foreach (DataRow dr in dt.Rows)
			{
				ClsEstimateChargeDtl edt = new ClsEstimateChargeDtl(dr);
				ClsCargoAccrual acc = new ClsCargoAccrual(edt);
				acc.Submitted_Dt = submitted;

				if (!acc.ValidateInsert())
					sb.AppendFormat("CargoActID {0}, EstChgID {1}, Bk {2}, {3}\r\n",
						acc.Cargo_Activity_ID, acc.Estimate_Charge_ID, acc.Booking_No, acc.Error);
				else if (acc.Sail_Dt == null)
				{
					acc = null;
					sb.AppendFormat("CargoActID {0}, EstChgID {1}, Bk {2}, Missing Accrual Date\r\n",
						acc.Cargo_Activity_ID, acc.Estimate_Charge_ID, acc.Booking_No);
				}
				else
				{
					ClsCargoAccrual prevAcc = ClsCargoAccrual.GetUsingDetail(
						acc.Cargo_Activity_ID.Value, acc.Estimate_Charge_ID.Value);
					if (prevAcc != null)
					{
						acc = null;
						sbWarn.AppendFormat("{0}: {1}, {2}: {3} accrued for booking {4}, estimate {5} on {6}, submitted {7}\r\n",
							prevAcc.Cargo_Activity_ID, prevAcc.Cargo_Activity.Cargo.Serial_No,
							prevAcc.Estimate_Charge_ID, prevAcc.Estimate_Charge.Charge_Type_Cd,
							prevAcc.Booking_No, prevAcc.Estimate_Charge.Estimate.Estimate_No,
							ClsConfig.FormatDate(prevAcc.Sail_Dt),
							ClsConfig.FormatDate(prevAcc.Submitted_Dt));
					}
				}
				if( acc != null ) lst.Add(acc);
			}

			if (sbWarn.Length > 0) warnMsg = sbWarn.ToString();

			if (sb.Length > 0)
			{
				errorMsg = sb.ToString();
				return false;
			}

			bool newTx = !Connection.IsInTransaction;
			try
			{
				if (newTx == true) Connection.TransactionBegin();

				foreach (ClsCargoAccrual acc in lst) acc.Insert();

				if (newTx == true) Connection.TransactionCommit();

				return true;
			}
			catch
			{
				if (newTx == true) Connection.TransactionRollback();
				throw;
			}
		}
	}
	#endregion		// #region Static Properties/Methods
}