using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsCargoActivity
	{

		#region Properties

		#region Estimate AP

		public DataTable dtEstimateAPCharges
		{
			get
			{
				return GetEstimateCharges("AP");
			}
		}

		#endregion

		#region Estimate AR

		public DataTable dtEstimateARCharges
		{
			get
			{
				return GetEstimateCharges("AR");
			}
		}

		#endregion

		#region Actual AP

		#endregion

		#region Actual AR

		#endregion

		#endregion

		#region Private Methods

		private DataTable GetEstimateCharges(string finance_cd)
		{
			try
			{
				StringBuilder sb = new StringBuilder();

				sb.AppendFormat(@"
					SELECT 
					ec.charge_type_cd,
					ct.charge_type_dsc,
					ec.level_cd,
					ec.vendor_cd,
					cd.activity_amt
					FROM
					t_estimate_charge_dtl cd
					INNER JOIN t_estimate_charge ec ON ec.estimate_charge_id = cd.estimate_charge_id
					INNER JOIN r_charge_type ct ON ct.charge_type_cd = ec.charge_type_cd
					WHERE 
					cd.cargo_activity_id = {0}
					AND 
					ec.finance_cd = '{1}'", Cargo_Activity_ID, finance_cd);

				return Connection.GetDataTable(sb.ToString());
			}
			catch (Exception ex)
			{
				ClsErrorHandler.LogException(ex);
				return null;
			}
		}

		#endregion

		#region Public Methods

		public static void DeleteUnassignedActivity(string sql)
		{
			bool bInTrans = Connection.IsInTransaction;
			if (!bInTrans)
				Connection.TransactionBegin();
			try
			{
				Connection.RunSQL(sql);
				if (!bInTrans)
					Connection.TransactionCommit();
				return;
			}
			catch (Exception ex)
			{
				if (!bInTrans)
					Connection.TransactionRollback();
				return;
			}
		}

		public static ClsCargoActivity GetByTCNVoyagePorts
			(string TCN,
			 string VoyageNo,
			 string Origin,
			 string Destination)
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendFormat(@"
					select * from T_CARGO_ACTIVITY a
					 inner join t_cargo c on a.cargo_id = c.cargo_id
					 inner join t_booking b on c.booking_id = b.booking_id
					  where voyage_no like '{0}'
					  and serial_no = '{1}' 
					  and orig_location_cd = '{2}'
					  and dest_location_cd = '{3}'",
				VoyageNo, TCN, Origin, Destination );
			DataRow dr = Connection.GetDataRow(sb.ToString());
			if (dr == null)
				return null;

			ClsCargoActivity act = new ClsCargoActivity(dr);
			return act;
		}
		#endregion

	}

	#region Static Methods/Properties of ClsCargoActivity

	partial class ClsCargoActivity
	{
		public static bool DeleteCargoActivities(DataRow[] cargoActRows, out string error)
		{
			error = null;
			if (cargoActRows == null)
			{
				error = "No rows provided to be deleted";
				return false;
			}

			StringBuilder sb = new StringBuilder();
			List<ClsCargoActivity> lstCA = new List<ClsCargoActivity>();
			foreach (DataRow dr in cargoActRows)
			{
				dr.ClearErrors();
				long? caID = ClsConvert.ToInt64Nullable(dr["Cargo_Activity_ID"]);
				ClsCargoActivity ca = (caID != null)
					? ClsCargoActivity.GetUsingKey(caID.Value) : null;
				if (ca == null) continue;

				if (!ca.ValidateDelete())
				{
					sb.AppendFormat("Error Attempting Delete, Cargo Activity {0}: {1} {2}\r\n",
						ca.Cargo_Activity_ID, ca.Cargo.Serial_No, ca.Error);
					continue;
				}

				lstCA.Add(ca);		// OK, add it to list
			}

			if (sb.Length > 0)
			{
				error = sb.ToString();
				return false;
			}

			if (lstCA.Count <= 0)
			{
				error = "No cargo activities provided to be deleted";
				return false;
			}

			bool newTx = !Connection.IsInTransaction;
			try
			{
				if (newTx == true) Connection.TransactionBegin();

				foreach (ClsCargoActivity ca in lstCA)
				{
					ClsCargo c = ca.Cargo;
					ca.Delete();

					// If no cargo activities left, delete cargo as well
					DataTable dtActs = c.GetCargoActivities(false);
					if (dtActs == null || dtActs.Rows.Count <= 0)
						c.Delete();
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

		public static bool SetBillablePayable(DataRow[] cargoActRows, bool updateBill,
			string bill_flg, bool updatePay, string pay_flg, out string error)
		{
			error = null;
			if (cargoActRows == null)
			{
				error = "No rows provided";
				return false;
			}

			StringBuilder sb = new StringBuilder();
			List<ClsCargoActivity> lstCA = new List<ClsCargoActivity>();
			foreach (DataRow dr in cargoActRows)
			{
				dr.ClearErrors();
				long? caID = ClsConvert.ToInt64Nullable(dr["Cargo_Activity_ID"]);
				ClsCargoActivity ca = (caID != null)
					? ClsCargoActivity.GetUsingKey(caID.Value) : null;
				if (ca == null) continue;

				if( updateBill ) ca.Billable_Flg = bill_flg;
				if( updatePay ) ca.Payable_Flg = pay_flg;
				if (!ca.ValidateUpdate())
				{
					sb.AppendFormat("Error updating billable/payable, Cargo Activity {0}: {1} {2}\r\n",
						ca.Cargo_Activity_ID, ca.Cargo.Serial_No, ca.Error);
					continue;
				}

				lstCA.Add(ca);		// OK, add it to list
			}

			if (sb.Length > 0)
			{
				error = sb.ToString();
				return false;
			}

			if (lstCA.Count <= 0)
			{
				error = "No cargo activities provided";
				return false;
			}

			bool newTx = !Connection.IsInTransaction;
			try
			{
				if (newTx == true) Connection.TransactionBegin();

				foreach (ClsCargoActivity ca in lstCA)
				{
					ClsCargo c = ca.Cargo;
					ca.Update();
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
	}

	#endregion		// #region Static Methods/Properties of ClsCargoActivity
}