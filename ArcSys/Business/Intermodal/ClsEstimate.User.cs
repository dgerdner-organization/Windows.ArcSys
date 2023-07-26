using System;
using System.Data;
using System.Text;
using System.Reflection;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsEstimate
	{
		#region Fields/Properties

		public string EstimateUniqueConstraint { get { return "UK_ESTIMATE_ESTIMATE_NO"; } }

		private List<ClsCargoActivity> _Activities;
		private List<ClsCargoActivity> _AvailableActivities;

		private List<ClsEstimateCharge> _AllCharges;
		private List<ClsEstimateCharge> _ArCharges;
		private List<ClsEstimateCharge> _ApCharges;

		public bool IsAccrued { get { return Accrued_Dt != null; } }

		#endregion		// #region Fields/Properties

		#region Constructors/Initialization

		public override void SetDefaults()
		{
			ResetColumns();

			Ap_Status_Cd = ClsEstimateStatus.Codes.InComplete;
			Ar_Status_Cd = ClsEstimateStatus.Codes.InComplete;
			Line_Status_Cd = ClsEstimateStatus.Codes.InComplete;
		}

		protected override void OnReload()
		{
			if (_AllCharges != null) _AllCharges.Clear();
			_AllCharges = null;

			if (_ArCharges != null) _ArCharges.Clear();
			_ArCharges = null;

			if (_ApCharges != null) _ApCharges.Clear();
			_ApCharges = null;

			if (_Activities != null) _Activities.Clear();
			_Activities = null;

			if (_AvailableActivities != null) _AvailableActivities.Clear();
			_AvailableActivities = null;
		}
		#endregion		// #region Constructors/Initialization

		#region ToString Overrides

		public override string ToString()
		{
			return string.Format("{0}: {1} {2} {3} - {4}",
				Estimate_ID, Estimate_No, Voyage_No, Orig_Location_Cd, Dest_Location_Cd);
		}

		public string ToString(string detailStr)
		{
			if( detailStr.Contains("e") )
				return string.Format("ID {0}: {1} - {2} to {3}",
					Estimate_ID, Voyage_No,
					(Orig_Location != null ? Orig_Location.Location_Dsc : Orig_Location_Cd),
					(Dest_Location != null ? Dest_Location.Location_Dsc : Dest_Location_Cd));
			return ToString();
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
			if (string.IsNullOrEmpty(Voyage_No) == true)
				_Errors["Voyage_No"] = "Missing or invalid voyage number";
			if (string.IsNullOrEmpty(Orig_Location_Cd) == true)
				_Errors["Orig_Location_Cd"] = "Missing or invalid origin location";
			if (string.IsNullOrEmpty(Dest_Location_Cd) == true)
				_Errors["Dest_Location_Cd"] = "Missing or invalid destination location";
		}

		public override bool ValidateDelete()
		{
			_Errors.Clear();

			if (Estimate_ID == null)
			{
				_Errors["Estimate_ID"] = "No estimate ID provided";
				return false;
			}

			DataTable dt = GetAccrualData();
			if (dt != null && dt.Rows.Count > 0)
				_Errors["Accrual"] = "Estimate cannot be deleted, accrual data has been submitted";

			dt = GetChanges();
			if (dt != null && dt.Rows.Count > 0)
				_Errors["Changes"] = "Cargo changes must be dismissed before attempting delete";

			dt = GetActivities();
			if (dt != null && dt.Rows.Count > 0)
				_Errors["Activities"] = "All cargo must be removed from estimate before attempting delete";

			dt = GetApChargesDT();
			if (dt != null && dt.Rows.Count > 0)
				_Errors["AP"] = "All AP charges must be removed before attempting delete";

			dt = GetArChargesDT();
			if (dt != null && dt.Rows.Count > 0)
				_Errors["AR"] = "All AR charges must be removed before attempting delete";

			// Eventually need to add a search where Orig_Estimate_ID and for estimate notes
			return _Errors.Count == 0;
		}

		public bool ValidateVoyageChange(string voyNo)
		{
			_Errors.Clear();

			if (Estimate_ID == null)
			{
				_Errors["Estimate_ID"] = "No estimate ID provided";
				return false;
			}

			if( string.Compare(voyNo, Voyage_No, true) == 0 )
			{
				_Errors["Voyage_No"] = "Estimate is already for voyage " + voyNo;
				return false;
			}

			string sql = @"
			SELECT	bk.voyage_no
			FROM	t_cargo_activity ca
				INNER JOIN t_cargo c	ON c.cargo_id = ca.cargo_id
				INNER JOIN t_booking bk	ON bk.booking_id = c.booking_id
			WHERE ca.estimate_id = @EST_ID
			GROUP BY bk.voyage_no ";

			DbParameter[] p = new DbParameter[1];
			p[0] = Connection.GetParameter("@EST_ID", Estimate_ID.Value);

			DataTable dt = Connection.GetDataTable(sql, p);
			if (dt != null && dt.Rows.Count > 1)
			{
				_Errors["Voyage_No"] = "Cannot change voyage when multiple voyages exist on the estimate";
				return false;
			}

			DataRow dr = dt.Rows[0];
			string cargoVoyage = ClsConvert.ToString(dr["voyage_no"]);
			if (string.Compare(voyNo, cargoVoyage, true) != 0)
			{
				_Errors["Voyage_No"] = string.Format(
					"Specified voyage {0} does not match cargo {1}",
					voyNo, cargoVoyage);
				return false;
			}

			ClsEstimate est = ClsEstimate.GetEstimate(voyNo, Orig_Location_Cd, Dest_Location_Cd);
			if( est != null )
			{
				_Errors["Voyage_No"] = string.Format(
					"Cannot change voyage, an estimate ({0}) already exists for {1}, {2} to {3}",
					est.Estimate_No, est.Voyage_No, est.Orig_Location.Location_Dsc,
					est.Dest_Location.Location_Dsc);
				return false;
			}

			return true;
		}
		#endregion		// #region Validation

		#region Voyage

		public bool ChangeVoyage(string newVoy)
		{
			if (!ValidateVoyageChange(newVoy)) return false;

			Voyage_No = newVoy;
			Update();
			return true;
		}
		#endregion		// #region Voyage

		#region Charges

		public List<ClsEstimateCharge> AllCharges
		{
			get
			{
				if (_AllCharges == null) LoadAllCharges();
				return _AllCharges;
			}
		}

		public void LoadAllCharges()
		{
			if (Estimate_ID == null)
			{
				if (_AllCharges == null)
					_AllCharges = new List<ClsEstimateCharge>();
				else
					_AllCharges.Clear();
				return;
			}

			if (_AllCharges != null) _AllCharges.Clear();

			_AllCharges = ClsEstimateCharge.GetChargesList(Estimate_ID, null);
		}

		public List<ClsEstimateCharge> ArCharges
		{
			get
			{
				if (_ArCharges == null) LoadArChargesList();
				return _ArCharges;
			}
		}

		public DataTable GetArChargesDT()
		{
			return (Estimate_ID != null)
				? ClsEstimateCharge.GetChargesDT(Estimate_ID, ClsFinance.Codes.AR) : null;
		}

		public void LoadArChargesList()
		{
			if (Estimate_ID == null)
			{
				if (_ArCharges == null)
					_ArCharges = new List<ClsEstimateCharge>();
				else
					_ArCharges.Clear();
				return;
			}

			if (_ArCharges != null) _ArCharges.Clear();

			_ArCharges = ClsEstimateCharge.GetChargesList(Estimate_ID, ClsFinance.Codes.AR);
		}

		public List<ClsEstimateCharge> ApCharges
		{
			get
			{
				if (_ApCharges == null) LoadApChargesList();
				return _ApCharges;
			}
		}

		public DataTable GetApChargesDT()
		{
			return (Estimate_ID != null)
				? ClsEstimateCharge.GetChargesDT(Estimate_ID, ClsFinance.Codes.AP) : null;
		}

		public void LoadApChargesList()
		{
			if (Estimate_ID == null)
			{
				if (_ApCharges == null)
					_ApCharges = new List<ClsEstimateCharge>();
				else
					_ApCharges.Clear();
				return;
			}

			if (_ApCharges != null) _ApCharges.Clear();

			_ApCharges = ClsEstimateCharge.GetChargesList(Estimate_ID, ClsFinance.Codes.AP);
		}

		public decimal GetArChargeSum()
		{
			return (Estimate_ID != null)
				? ClsEstimateCharge.GetSum(Estimate_ID, ClsFinance.Codes.AR) : 0;
		}

		public decimal GetApChargeSum()
		{
			return (Estimate_ID != null)
				? ClsEstimateCharge.GetSum(Estimate_ID, ClsFinance.Codes.AP) : 0;
		}

		public decimal GetEstimateDiff()
		{
			decimal arSum = GetArChargeSum();
			decimal apSum = GetApChargeSum();
			return arSum - apSum;
		}
		#endregion		// #region Charges

		#region Cargo Activity

		public List<ClsCargoActivity> Activities
		{
			get
			{
				if (_Activities == null) LoadActivities();
				return _Activities;
			}
		}

		public DataTable GetActivities()
		{
			if (Estimate_ID == null) return null;

			ClsEstimateSearch search = new ClsEstimateSearch();
			search.Estimate_ID = Estimate_ID;
			return search.SearchExistingActivities();
		}

		public DataSet GetActivitiesPlusCharges()
		{
			if (Estimate_ID == null) return null;

			ClsEstimateSearch search = new ClsEstimateSearch();
			search.Estimate_ID = Estimate_ID;
            search.RegionConus = (Orig_Location.Conus_Flg == "Y");
			return search.SearchActivitiesPlusCharges();
		}

		public void LoadActivities()
		{
			if (_Activities == null)
				_Activities = new List<ClsCargoActivity>();
			else
				_Activities.Clear();

			if (Estimate_ID == null) return;

			string sql = @"
			SELECT	ca.*
			FROM	t_cargo_activity ca
			WHERE	ca.estimate_id = @EST_ID ";

			DbParameter[] p = new DbParameter[1];
			p[0] = Connection.GetParameter("@EST_ID", Estimate_ID.Value);

			DataTable dt = Connection.GetDataTable(sql, p);
			if (dt == null) return;

			foreach (DataRow dr in dt.Rows)
			{
				ClsCargoActivity ca = new ClsCargoActivity(dr);
				_Activities.Add(ca);
			}
		}

		public List<ClsCargoActivity> AvailableActivities
		{
			get
			{
				if (_AvailableActivities == null) LoadAvailableActivities();
				return _AvailableActivities;
			}
		}

		public DataTable GetAvailableActivities()
		{
			if (string.IsNullOrEmpty(Voyage_No) || string.IsNullOrEmpty(Orig_Location_Cd) ||
				string.IsNullOrEmpty(Dest_Location_Cd)) return null;

			ClsEstimateSearch search = new ClsEstimateSearch();
			search.VoyageNo = Voyage_No;
			search.Act_Orig_CDs = Orig_Location_Cd;
			search.Act_Dest_CDs = Dest_Location_Cd;
			search.IncludeBlankTCNs = search.IncludeNonBillPay = search.IncludeNonDoor = false;
			search.IncludeTransShip = true;
			return search.SearchAvailableActivities();
		}

		public void LoadAvailableActivities()
		{
			if (_AvailableActivities == null)
				_AvailableActivities = new List<ClsCargoActivity>();
			else
				_AvailableActivities.Clear();

			if (string.IsNullOrEmpty(Voyage_No) || string.IsNullOrEmpty(Orig_Location_Cd) ||
				string.IsNullOrEmpty(Dest_Location_Cd)) return;

			ClsEstimateSearch search = new ClsEstimateSearch();
			search.VoyageNo = Voyage_No;
			search.Act_Orig_CDs = Orig_Location_Cd;
			search.Act_Dest_CDs = Dest_Location_Cd;
			DataTable dt = search.SearchAvailableActivities();
			if (dt == null) return;

			foreach (DataRow dr in dt.Rows)
			{
				ClsCargoActivity ca = new ClsCargoActivity(dr);
				_AvailableActivities.Add(ca);
			}
		}

		public DataTable GetChanges()
		{
			if( Estimate_ID == null ) return null;

			string sql = @"
			SELECT	cc.*, ca.orig_location_cd, ca.dest_location_cd,
					oloc.location_dsc as orig_location_dsc, dloc.location_dsc as dest_location_dsc,
					c.booking_id, c.serial_no, c.commodity_cd, c.pkg_type_cd, 
					c.length_nbr, c.width_nbr, c.height_nbr, c.weight_nbr, c.move_type_cd,
					c.cargo_dsc, c.container_no, c.seal1, c.seal2, c.seal3, c.vessel_load_dt,
					c.contract_mod_id, c.cargo_key, bk.booking_no, bk.booking_ref,
					bk.plor_location_cd, bk.pol_location_cd, bk.pod_location_cd,
					bk.plod_location_cd, plor.location_dsc AS plor_location_dsc,
					pol.location_dsc AS pol_location_dsc, pod.location_dsc AS pod_location_dsc,
					plod.location_dsc AS plod_location_dsc,bk.bol_no, bk.edi_ref, bk.customer_ref,
					bk.vessel_cd, ves.vessel_nm, bk.voyage_no as bk_voyage_no, bk.sail_dt,
					bk.delivery_txt, bk.cargo_notes_txt,
					c.length_nbr || ' x ' || c.width_nbr || ' x ' || c.height_nbr as len_wid_hgt,
					cmod.mod_no, cmod.attachment_nm,
					nvl((select sum(apedt.activity_amt) from t_estimate_charge_dtl apedt
							inner join t_estimate_charge echg on echg.estimate_charge_id = apedt.estimate_charge_id
							where apedt.cargo_activity_id = ca.cargo_activity_id and echg.finance_cd = 'AP'
						), 0) as ap_total_amt,
					nvl((select sum(aredt.activity_amt) from t_estimate_charge_dtl aredt
							inner join t_estimate_charge echg on echg.estimate_charge_id = aredt.estimate_charge_id
							where aredt.cargo_activity_id = ca.cargo_activity_id and echg.finance_cd = 'AR'
						), 0) as ar_total_amt
			FROM	T_CARGO_CHANGE cc
				INNER JOIN t_cargo_activity ca		ON ca.cargo_activity_id = cc.cargo_activity_id
				INNER JOIN t_cargo c				ON c.cargo_id = ca.cargo_id
				INNER JOIN t_booking bk				ON bk.booking_id = c.booking_id
				INNER JOIN r_location oloc			ON oloc.location_cd = ca.orig_location_cd
				INNER JOIN r_location dloc			ON dloc.location_cd = ca.dest_location_cd
				INNER JOIN r_location plor			ON plor.location_cd = bk.plor_location_cd
				INNER JOIN r_location pol			ON pol.location_cd = bk.pol_location_cd
				INNER JOIN r_location pod			ON pod.location_cd = bk.pod_location_cd
				INNER JOIN r_location plod			ON plod.location_cd = bk.plod_location_cd
				INNER JOIN r_vessel ves				ON ves.vessel_cd = bk.vessel_cd
				LEFT OUTER JOIN t_contract_mod cmod ON cmod.contract_mod_id = c.contract_mod_id
			WHERE	cc.estimate_id = @EST_ID ";

			DbParameter[] p = new DbParameter[1];
			p[0] = Connection.GetParameter("@EST_ID", Estimate_ID.Value);

			return Connection.GetDataTable(sql, p);
		}

		public DataTable GetAccrualData()
		{
			if (Estimate_ID == null) return null;

			string sql = @"
			SELECT	acc.*, c.serial_no as cgo_serial_no
			FROM	T_CARGO_ACCRUAL acc
				INNER JOIN t_estimate_charge echg	ON echg.estimate_charge_id = acc.estimate_charge_id
				INNER JOIN t_cargo_activity ca		ON ca.cargo_activity_id = acc.cargo_activity_id
				INNER JOIN t_cargo c				ON c.cargo_id = ca.cargo_id
			WHERE	echg.estimate_id = @EST_ID ";

			DbParameter[] p = new DbParameter[1];
			p[0] = Connection.GetParameter("@EST_ID", Estimate_ID.Value);

			return Connection.GetDataTable(sql, p);
		}

		public bool AddCargo(DataRow[] cargoActRows)
		{
			ResetErrors();
			if (cargoActRows == null)
			{
				_Errors["Ca_Count"] = "No rows provided to be added";
				return false;
			}

			List<ClsCargoActivity> existingActs = Activities;
			StringBuilder sb = new StringBuilder();
			List<ClsCargoActivity> lstCA = new List<ClsCargoActivity>();
			foreach (DataRow dr in cargoActRows)
			{
				dr.ClearErrors();
				long? caID = ClsConvert.ToInt64Nullable(dr["Cargo_Activity_ID"]);
				ClsCargoActivity ca = (caID != null)
					? ClsCargoActivity.GetUsingKey(caID.Value) : null;
				if (ca == null) continue;

				if (ca.Estimate_ID != null)
				{
					if (ca.Estimate_ID == Estimate_ID)
					{
						sb.AppendFormat("Cargo Activity {0}: {1} is already assigned to this estimate\r\n",
							ca.Cargo_Activity_ID, ca.Cargo.Serial_No);
						continue;
					}
					else
					{
						sb.AppendFormat("Cargo Activity {0}: {1} is already assigned to an estimate {2}\r\n",
							ca.Cargo_Activity_ID, ca.Cargo.Serial_No, ca.Estimate);
						continue;
					}
				}

				if (ca.Cargo.Serial_No.IsNullOrWhiteSpace())
				{
					sb.AppendFormat("Cargo Activity {0}: Blank serial # cannot be added to an estimate\r\n",
						ca.Cargo_Activity_ID);
					continue;
				}

				bool tcnExists = existingActs.Exists(delegate(ClsCargoActivity exAct)
				{
					return string.Compare(exAct.Cargo.Serial_No, ca.Cargo.Serial_No, true) == 0;
				});

				if (tcnExists)
				{
					sb.AppendFormat("Serial # {0} is already assigned to the estimate\r\n",
						ca.Cargo.Serial_No);
					continue;
				}

				if (ca.Billable_Flg == "N" && ca.Payable_Flg == "N")
				{
					sb.AppendFormat("Serial # {0} is flagged as non-billable and non-payable\r\n",
						ca.Cargo.Serial_No);
					continue;
				}

				ca.Estimate_ID = Estimate_ID;
				if (!ca.ValidateUpdate())
				{
					sb.AppendFormat("Error Adding Cargo Activity {0}: {1} {2}\r\n",
						ca.Cargo_Activity_ID, ca.Cargo.Serial_No, ca.Error);
					continue;
				}

				lstCA.Add(ca);		// OK, add it to list
			}

			if (sb.Length > 0)
			{
				_Errors["Estimate_ID"] = sb.ToString();
				return false;
			}

			if (lstCA.Count <= 0)
			{
				_Errors["Ca_Count"] = "No cargo activities provided to be added";
				return false;
			}

			bool newTx = !Connection.IsInTransaction;
			try
			{
				if (newTx == true) Connection.TransactionBegin();

				foreach (ClsCargoActivity ca in lstCA) ca.Update();

				if (newTx == true) Connection.TransactionCommit();

				return true;
			}
			catch
			{
				if (newTx == true) Connection.TransactionRollback();
				throw;
			}
		}

		public bool RemoveCargo(DataRow[] cargoActRows)
		{
			ResetErrors();
			if (cargoActRows == null)
			{
				_Errors["Ca_Count"] = "No rows provided to be removed";
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

				if (ca.Estimate_ID == null)
				{
					sb.AppendFormat("Cargo Activity {0}: {1} is not assigned to an estimate\r\n",
						ca.Cargo_Activity_ID, ca.Cargo.Serial_No);
					continue;
				}
				else if (ca.Estimate_ID != Estimate_ID)
				{
					sb.AppendFormat("Cargo Activity {0}: {1} is assigned to a different estimate {2}\r\n",
						ca.Cargo_Activity_ID, ca.Cargo.Serial_No, ca.Estimate);
					continue;
				}

				DataTable dt = ClsEstimateChargeDtl.GetActivityDetail(ca.Cargo_Activity_ID.Value);
				if (dt != null && dt.Rows.Count > 0)
				{
					sb.AppendFormat("Cargo Activity {0}: {1} has charges assigned to it. Remove it from all estimate charges then try again.\r\n",
						ca.Cargo_Activity_ID, ca.Cargo.Serial_No, ca.Estimate);
					foreach (DataRow drDetail in dt.Rows)
					{
						ClsEstimateChargeDtl edt = new ClsEstimateChargeDtl(drDetail);
						sb.AppendFormat(" Estimate {0}, Charge {1}: {2}\r\n",
							edt.Estimate_Charge.Estimate_ID, edt.Estimate_Charge_ID,
							edt.Estimate_Charge.Charge_Type_Cd);
					}
				}

				ca.Estimate_ID = null;
				if (!ca.ValidateUpdate())
				{
					sb.AppendFormat("Error Removing Cargo Activity {0}: {1} {2}\r\n",
						ca.Cargo_Activity_ID, ca.Cargo.Serial_No, ca.Error);
					continue;
				}

				lstCA.Add(ca);		// OK, add it to list
			}

			if (sb.Length > 0)
			{
				_Errors["Estimate_ID"] = sb.ToString();
				return false;
			}

			if (lstCA.Count <= 0)
			{
				_Errors["Ca_Count"] = "No cargo activities provided to be removed";
				return false;
			}

			bool newTx = !Connection.IsInTransaction;
			try
			{
				if (newTx == true) Connection.TransactionBegin();

				foreach (ClsCargoActivity ca in lstCA) ca.Update();

				if (newTx == true) Connection.TransactionCommit();

				return true;
			}
			catch
			{
				if (newTx == true) Connection.TransactionRollback();
				throw;
			}
		}

		public bool CargoWithoutLineHaulExists()
		{
			string sql = @"
			SELECT	COUNT(ca.cargo_activity_id) AS ca_cnt
			FROM	t_cargo_activity ca
			WHERE	ca.estimate_id = @EST_ID AND
			NOT EXISTS (
				SELECT	'X'
				FROM	t_estimate_charge_dtl edt
					INNER JOIN t_estimate_charge echg	ON echg.estimate_charge_id = edt.estimate_charge_id
					INNER JOIN r_charge_type cht		ON cht.charge_type_cd = echg.charge_type_cd
				WHERE	edt.cargo_activity_id = ca.cargo_activity_id AND
						cht.charge_category_cd = 'LINEHAUL' AND echg.estimate_id = ca.estimate_id
					)";
			DbParameter[] p = new DbParameter[1];
			p[0] = Connection.GetParameter("@EST_ID", Estimate_ID.GetValueOrDefault(-1));

			object oCount = Connection.GetScalar(sql, p);
			long? count = ClsConvert.ToInt64Nullable(oCount);
			return (count.GetValueOrDefault(0) > 0);
		}

		public bool AddVendor(DataRow[] cargoActRows, string vendor_cd)
		{
			ResetErrors();
			if (cargoActRows == null)
			{
				_Errors["Ca_Count"] = "No rows provided to assign to a vendor";
				return false;
			}
			if (string.IsNullOrEmpty(vendor_cd))
			{
				_Errors["Vendor_Cd"] = "No vendor provided";
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

				if (!string.IsNullOrEmpty(ca.Vendor_Cd))
				{
					if (string.Compare(ca.Vendor_Cd, vendor_cd, true) == 0)
					{
						sb.AppendFormat("Cargo Activity {0}: {1} is already assigned to this vendor\r\n",
							ca.Cargo_Activity_ID, ca.Cargo.Serial_No);
						continue;
					}
					else
					{
						sb.AppendFormat("Cargo Activity {0}: {1} is already assigned to a vendor {2}\r\n",
							ca.Cargo_Activity_ID, ca.Cargo.Serial_No, ca.Vendor_Cd);
						continue;
					}
				}

				ca.Vendor_Cd = vendor_cd;
				if (!ca.ValidateUpdate())
				{
					sb.AppendFormat("Error Adding Vendor to Cargo Activity {0}: {1} {2}\r\n",
						ca.Cargo_Activity_ID, ca.Cargo.Serial_No, ca.Error);
					continue;
				}

				lstCA.Add(ca);		// OK, add it to list
			}

			if (sb.Length > 0)
			{
				_Errors["Vendor_Cd"] = sb.ToString();
				return false;
			}

			if (lstCA.Count <= 0)
			{
				_Errors["Ca_Count"] = "No cargo activities provided to be assigned";
				return false;
			}

			bool newTx = !Connection.IsInTransaction;
			try
			{
				if (newTx == true) Connection.TransactionBegin();

				foreach (ClsCargoActivity ca in lstCA) ca.Update();

				if (newTx == true) Connection.TransactionCommit();

				return true;
			}
			catch
			{
				if (newTx == true) Connection.TransactionRollback();
				throw;
			}
		}

		public bool RemoveVendor(DataRow[] cargoActRows)
		{
			ResetErrors();
			if (cargoActRows == null)
			{
				_Errors["Ca_Count"] = "No rows provided to remove vendor";
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

				if (string.IsNullOrEmpty(ca.Vendor_Cd))
				{
					sb.AppendFormat("Cargo Activity {0}: {1} does not have a vendor assigned\r\n",
						ca.Cargo_Activity_ID, ca.Cargo.Serial_No);
					continue;
				}

				ca.Vendor_Cd = null;
				if (!ca.ValidateUpdate())
				{
					sb.AppendFormat("Error Removing Vendor from Cargo Activity {0}: {1} {2}\r\n",
						ca.Cargo_Activity_ID, ca.Cargo.Serial_No, ca.Error);
					continue;
				}

				lstCA.Add(ca);		// OK, add it to list
			}

			if (sb.Length > 0)
			{
				_Errors["Vendor_Cd"] = sb.ToString();
				return false;
			}

			if (lstCA.Count <= 0)
			{
				_Errors["Ca_Count"] = "No cargo activities provided";
				return false;
			}

			bool newTx = !Connection.IsInTransaction;
			try
			{
				if (newTx == true) Connection.TransactionBegin();

				foreach (ClsCargoActivity ca in lstCA) ca.Update();

				if (newTx == true) Connection.TransactionCommit();

				return true;
			}
			catch
			{
				if (newTx == true) Connection.TransactionRollback();
				throw;
			}
		}

		public bool RemoveMod(DataRow[] cargoActRows)
		{
			ResetErrors();
			if (cargoActRows == null)
			{
				_Errors["Ca_Count"] = "No rows provided to remove contract mod";
				return false;
			}

			StringBuilder sb = new StringBuilder();
			List<ClsCargo> lstCargo = new List<ClsCargo>();
			foreach (DataRow dr in cargoActRows)
			{
				dr.ClearErrors();
				long? caID = ClsConvert.ToInt64Nullable(dr["Cargo_Activity_ID"]);
				ClsCargoActivity ca = (caID != null)
					? ClsCargoActivity.GetUsingKey(caID.Value) : null;
				ClsCargo c = (ca != null) ? ca.Cargo : null;
				if (c == null) continue;

				if (c.Contract_Mod_ID == null )
				{
					sb.AppendFormat("Cargo {0} {1} does not have a mod assigned\r\n",
						c.Cargo_Dsc, c.Serial_No);
					continue;
				}

				c.Contract_Mod_ID = null;
				if (!c.ValidateUpdate())
				{
					sb.AppendFormat("Error Removing Mod from Cargo {0} {1} {2}\r\n",
						c.Cargo_Dsc, c.Serial_No, c.Error);
					continue;
				}

				if (!lstCargo.Exists(delegate(ClsCargo cgo) { return cgo.Cargo_ID == c.Cargo_ID; }))
					lstCargo.Add(c);		// OK, add it to list
			}

			if (sb.Length > 0)
			{
				_Errors["Contract_Mod"] = sb.ToString();
				return false;
			}

			if (lstCargo.Count <= 0)
			{
				_Errors["C_Count"] = "No cargo provided";
				return false;
			}

			bool newTx = !Connection.IsInTransaction;
			try
			{
				if (newTx == true) Connection.TransactionBegin();

				foreach (ClsCargo c in lstCargo) c.Update();

				if (newTx == true) Connection.TransactionCommit();

				return true;
			}
			catch
			{
				if (newTx == true) Connection.TransactionRollback();
				throw;
			}
		}

		public bool DismissChanges(DataRow[] cargoChangeRows)
		{
			ResetErrors();
			if (cargoChangeRows == null)
			{
				_Errors["Ca_Count"] = "No rows provided to be removed";
				return false;
			}

			StringBuilder sb = new StringBuilder();
			List<ClsCargoChange> lstChange = new List<ClsCargoChange>();
			foreach (DataRow dr in cargoChangeRows)
			{
				dr.ClearErrors();
				long? changeID = ClsConvert.ToInt64Nullable(dr["Cargo_Change_ID"]);
				ClsCargoChange cc = (changeID != null)
					? ClsCargoChange.GetUsingKey(changeID.Value) : null;
				if (cc == null) continue;

				if (!cc.ValidateDelete())
				{
					sb.AppendFormat("Error Removing Cargo Activity Notification {0}: {1} {2} {3}\r\n",
						cc.Cargo_Change_ID, cc.Cargo_Activity_ID, cc.Serial_No, cc.Error);
					continue;
				}

				lstChange.Add(cc);		// OK, add it to list
			}

			if (sb.Length > 0)
			{
				_Errors["Estimate_ID"] = sb.ToString();
				return false;
			}

			if (lstChange.Count <= 0)
			{
				_Errors["Ca_Count"] = "No changes provided";
				return false;
			}

			bool newTx = !Connection.IsInTransaction;
			try
			{
				if (newTx == true) Connection.TransactionBegin();

				foreach (ClsCargoChange cc in lstChange) cc.Delete();

				if (newTx == true) Connection.TransactionCommit();

				return true;
			}
			catch
			{
				if (newTx == true) Connection.TransactionRollback();
				throw;
			}
		}
		#endregion		// #region Cargo Activity

		#region Booking Information

		public DataTable GetComments()
		{
			if (Estimate_ID == null) return null;

			string sql = @"
			select bk.booking_id, bk.booking_no, bk.customer_ref, bk.delivery_txt, bk.cargo_notes_txt
from t_estimate est
inner join t_cargo_activity ca on ca.estimate_id = est.estimate_id
inner join t_cargo c on c.cargo_id = ca.cargo_id
inner join t_booking bk on bk.booking_id = c.booking_id
where est.estimate_id = @EST_ID
group by
bk.booking_id, bk.booking_no, bk.customer_ref, bk.delivery_txt, bk.cargo_notes_txt
order by bk.customer_ref, bk.booking_no";

			DbParameter[] p = new DbParameter[1];
			p[0] = Connection.GetParameter("@EST_ID", Estimate_ID);

			return Connection.GetDataTable(sql, p);
		}

		public string GetCommentText()
		{
			DataTable dt = GetComments();
			if (dt == null || dt.Rows.Count <= 0) return null;

			StringBuilder sb = new StringBuilder();
			foreach (DataRow dr in dt.Rows)
			{
				string bkNo = ClsConvert.ToString(dr["Booking_No"]);
				string pcfn = ClsConvert.ToString(dr["Customer_Ref"]);

				string delTxt = ClsConvert.ToString(dr["Delivery_Txt"]);
				string cargoTxt = ClsConvert.ToString(dr["Cargo_Notes_Txt"]);
				if (string.IsNullOrWhiteSpace(delTxt) &&
					string.IsNullOrWhiteSpace(cargoTxt)) continue;

				sb.AppendFormat("{0}-{1}: {2}\r\n{3}\r\n", pcfn, bkNo, delTxt, cargoTxt);
			}

			return (sb.Length > 0) ? sb.ToString() : null;
		}
		#endregion		// #region Booking Information

		#region Recompute Charges

		public delegate bool PromptHandler(string info);
		public delegate void ProgressHandler(string caption, string info);

		public event PromptHandler ConfirmChanges;
		public event ProgressHandler ProgressUpdate;

		public bool RefreshAllCharges(out string info)
		{
			ReloadFromDB();

			info = null;
			ResetErrors();
			ResetWarnings();
			List<ClsCargoActivity> lstCA = Activities;
			if (lstCA == null || lstCA.Count <= 0)
			{
				_Errors["Ca_Count"] = "No cargo found";
				return false;
			}

			List<ClsEstimateCharge> lstCharges = AllCharges;
			if (lstCharges.Count <= 0)
			{
				_Errors["Chg_Count"] = "No charges found";
				return false;
			}

			StringBuilder sbError = new StringBuilder(), sbCA = new StringBuilder(),
				sbChanges = new StringBuilder();
			List<ClsCargoActivity> lstActRemove = new List<ClsCargoActivity>();
			ClsImportLine iline = new ClsImportLine();
			if (ProgressUpdate != null)
				ProgressUpdate("Scanning LINE for cargo",
					"Checking for cargo that no longer exists in LINE...\r\n");
			for (int i = 0; i < lstCA.Count; i++)
			{
				sbCA.Length = 0;
				ClsCargoActivity ca = lstCA[i];
				ClsCargo c = ca.Cargo;
				ClsBooking bk = c.Booking;
				DataTable dt = iline.QueryLINEData("%", "%", c.Serial_No, false);
				if (dt == null || dt.Rows.Count <= 0)
				{
					lstActRemove.Add(ca);
					sbCA.AppendFormat(
						"{0} {1} {2} will be removed from estimate, it no longer exists in LINE.\r\n",
						c.Serial_No, bk.Voyage_No, bk.Booking_No);
				}
				else if (string.Compare(ca.Orig_Location_Cd, Orig_Location_Cd, true) != 0 ||
					string.Compare(ca.Dest_Location_Cd, Dest_Location_Cd, true) != 0 ||
					string.Compare(bk.Voyage_No, Voyage_No, true) != 0)
				{
					lstActRemove.Add(ca);
					sbCA.AppendFormat(
						"{0} will be removed. {1}: {2} to {3} no longer matches estimate info {4}: {5} to {6}\r\n",
						c.Serial_No, bk.Voyage_No, ca.Orig_Location.Location_Dsc,
						ca.Dest_Location.Location_Dsc, Voyage_No, Orig_Location.Location_Dsc,
						Dest_Location.Location_Dsc);
				}
				else if ((
					string.Compare(bk.Plor_Location_Cd, ca.Orig_Location_Cd, true) != 0 ||
					string.Compare(bk.Pol_Location_Cd, ca.Dest_Location_Cd, true) != 0)
					&& (
					string.Compare(bk.Pod_Location_Cd, ca.Orig_Location_Cd, true) != 0 ||
					string.Compare(bk.Plod_Location_Cd, ca.Dest_Location_Cd, true) != 0)
					)
				{
					lstActRemove.Add(ca);
					sbCA.AppendFormat(
						"{0} will be removed. Booking info {1}-{2} or {3}-{4} no longer matches estimate info {5}-{6}\r\n",
						c.Serial_No, bk.Plor_Location.Location_Dsc, bk.Pol_Location.Location_Dsc,
						bk.Pod_Location.Location_Dsc, bk.Plod_Location.Location_Dsc,
						Orig_Location.Location_Dsc, Dest_Location.Location_Dsc);
				}
				else
				{
					string plor = null, pol = null, pod = null, plod = null, voyNo = null;
					bool foundMatch = false;
					foreach (DataRow drLINE in dt.Rows)
					{
						plor = ClsConvert.ToString(drLINE["plor"]);
						pol = ClsConvert.ToString(drLINE["pol"]);
						pod = ClsConvert.ToString(drLINE["pod"]);
						plod = ClsConvert.ToString(drLINE["plod"]);
						voyNo = ClsConvert.ToString(drLINE["voyage_no"]);
						if (string.Compare(Voyage_No, voyNo, true) != 0) continue;

						if ((
							string.Compare(plor, Orig_Location_Cd, true) == 0 &&
							string.Compare(pol, Dest_Location_Cd, true) == 0)
						|| (
							string.Compare(pod, Orig_Location_Cd, true) == 0 &&
							string.Compare(plod, Dest_Location_Cd, true) == 0))
						{
							foundMatch = true;
							break;
						}
					}

					if (!foundMatch)
					{
						lstActRemove.Add(ca);
						sbCA.AppendFormat(
							"{0} will be removed. Booking info {1} {2}-{3} or {4}-{5} no longer matches estimate info {6} {7}-{8}\r\n",
							c.Serial_No, voyNo, plor, pol, pod, plod, Voyage_No, Orig_Location_Cd, Dest_Location_Cd);
					}
				}

				if (sbCA.Length > 0) sbChanges.Append(sbCA.ToString());

				if (ProgressUpdate != null)
					ProgressUpdate(string.Format("Scanning LINE for cargo. Processed {0} of {1}",
						i + 1, lstCA.Count), sbCA.ToString());
			}

			if (ProgressUpdate != null)
				ProgressUpdate("Examining Charges",
					"\r\nChecking for charges that need to be updated...\r\n");

			List<ClsEstimateChargeDtl> deletes = new List<ClsEstimateChargeDtl>(),
				updates = new List<ClsEstimateChargeDtl>();
			List<ClsEstimateCharge> chgUpdates = new List<ClsEstimateCharge>();
			for (int i = 0; i < lstCharges.Count; i++)		// Modify each charge
			{
				ClsEstimateCharge echg = lstCharges[i];
				ClsEstimateCharge origChg = new ClsEstimateCharge(echg);
				StringBuilder sbChargeChanges = new StringBuilder();
				List<ClsEstimateChargeDtl> lstDtl = echg.GetDetail();
				if (lstDtl.Count > 0)
				{
					List<string> pcfns = new List<string>();
					List<ClsEstimateChargeDtl> lstRemoveDtl = new List<ClsEstimateChargeDtl>();
					foreach (ClsEstimateChargeDtl edt in lstDtl)
					{
						// Build list of detail items that will need to be removed by checking to see
						// if the cargo activity ID associated with this detail item exists in lstActRemove
						bool deleteCA = lstActRemove.Exists(delegate(ClsCargoActivity lca)
						{ return lca.Cargo_Activity_ID == edt.Cargo_Activity_ID; });
						if (deleteCA)
						{
							lstRemoveDtl.Add(edt);
							sbChargeChanges.AppendFormat("Deleted {0} {1}\r\n",
								edt.Cargo_Activity.Cargo.Serial_No, edt.ToString("d"));
							continue;
						}

						string refreshInfo = null;
						if (edt.RefreshFromBookingCargo(out refreshInfo))
							sbChargeChanges.AppendFormat("{0} Changes: {1}\r\n",
								edt.Cargo_Activity.Cargo.Serial_No, refreshInfo);

						string pcfn = edt.Customer_Ref != null ? edt.Customer_Ref.ToUpper().Trim() : null;
						if (!string.IsNullOrWhiteSpace(pcfn) && !pcfns.Contains(pcfn)) pcfns.Add(pcfn);
					}
					deletes.AddRange(lstRemoveDtl);

					// Adjust the original detail list to take out the items that will be removed
					lstRemoveDtl.ForEach(delegate(ClsEstimateChargeDtl ldet)
					{ lstDtl.Remove(ldet); });
					echg.Tcn_Count = lstDtl.Count;

					ClsLevelUnit basis = echg.Level_Unit;
					if (basis.IsComputeExact == false)
					{	// When we are computing an exact TCN amount, the Level_Count field defaults to 1
						// and we do not need to adjust it, otherwise we need to attemp the following...
						if (basis.IsPCFN)	// If PCFN based, assign the total number of PCFNs
						{
							echg.Level_Count = pcfns.Count;
						}
						else if (basis.IsTCN)	// If TCN based, Level_Count will equel Tcn_Count
						{
							echg.Level_Count = echg.Tcn_Count;
						}
						else if (basis.IsConveyance && echg.Charge_Type.IsLineHaul)
						{
							long ppc = echg.Pcs_Per_Conveyance.GetValueOrDefault(0);
							long tcount = echg.Tcn_Count.GetValueOrDefault(0);
							if (ppc <= 0 || tcount <= 0)	// If pcs per or tcn count is less than or
							{								// equal to 0, we can't compute level count
								echg.Level_Count = 0;
							}
							else
							{										// divide
								long cnvys = tcount / ppc;
								if (tcount % ppc != 0) cnvys++;		// then account for any remainder
								echg.Level_Count = cnvys;
							}
						}
						// otherwise the value is either a default of 1 (Level=ALL) or the user has
						// entered a value that we cannot or do not compute (Level=CONVOYs)
					}

					if (lstDtl.Count <= 0)
						sbChargeChanges.AppendFormat("All TCNs removed from charge\r\n");
					if (basis.IsComputeExact)
					{
						PropertyInfo pi =
							ClsEstimateChargeDtl.GetProperty(basis.CargoAttributeColName);

						decimal totalAmt = 0, totalQty = 0;
						foreach (ClsEstimateChargeDtl edt in lstDtl)	// Now recompute each that remains
						{
							string refreshInfo = null;
							if (edt.RefreshAmounts(echg.Rate_Amt, pi, out refreshInfo))
								sbChargeChanges.AppendFormat("{0} Amount Changes: {1}\r\n",
									edt.Cargo_Activity.Cargo.Serial_No, refreshInfo);

							totalQty += edt.Activity_Unit_Qty.GetValueOrDefault(0);
							totalAmt += edt.Activity_Amt.GetValueOrDefault(0);

						}
						echg.Unit_Qty = totalQty;
						echg.Total_Amt = totalAmt;
					}
					else
					{
						if (echg.Level_Count != origChg.Level_Count || echg.Unit_Qty != origChg.Unit_Qty)
						{
							echg.Total_Amt = echg.Rate_Amt.GetValueOrDefault(0) *
								echg.Level_Count.GetValueOrDefault(0) * echg.Unit_Qty.GetValueOrDefault(0);

							if (lstDtl.Count > 0)
							{
								int extraItems = 0;
								decimal perTcnAmt = 0M, extraAmt = 0.01M;
								ClsConvert.DivideCurrencyEvenly(echg.Total_Amt.GetValueOrDefault(0),
									lstDtl.Count, out perTcnAmt, out extraItems);
								foreach (ClsEstimateChargeDtl edt in lstDtl)
								{
									decimal tcnAmt = perTcnAmt;
									if (extraItems > 0)
									{
										tcnAmt += extraAmt;
										extraItems--;
									}

									string refreshInfo = null;
									if (edt.RefreshAmounts(tcnAmt, out refreshInfo))
										sbChargeChanges.AppendFormat("{0} Amount Changes: {1}\r\n",
											edt.Cargo_Activity.Cargo.Serial_No, refreshInfo);
								}
							}
						}
					}

					foreach (ClsEstimateChargeDtl edt in lstDtl)
					{
						if (edt.HasAmtChanges || edt.HasBookingChanges || edt.HasDimChanges ||
							edt.HasCargoChanges)
							updates.Add(edt);
					}

					if (sbChargeChanges.Length > 0)
					{
						chgUpdates.Add(echg);
						sbChargeChanges.Insert(0,
							string.Format("Begin Changes for {0}\r\n", origChg.ToString()));
						sbChargeChanges.AppendFormat("End Changes ID {0}\r\n\r\n", echg.ToString());
						sbChanges.Append(sbChargeChanges.ToString());
					}
					else
					{
						if (echg.Compare(origChg))
						{
							chgUpdates.Add(echg);
							sbChargeChanges.AppendFormat("Begin Changes for {0}\r\n", origChg.ToString());
							sbChargeChanges.AppendFormat("End Changes ID {0}\r\n\r\n", echg.ToString());
							sbChanges.Append(sbChargeChanges.ToString());
						}
					}
				}

				if (ProgressUpdate != null)
					ProgressUpdate(string.Format("Examining Charge {0} of {1}",
						i + 1, lstCharges.Count), sbChargeChanges.ToString());
			}

			if (ProgressUpdate != null)
				ProgressUpdate(string.Format("Examining complete",
					lstCharges.Count, lstCharges.Count), "-------\r\n\r\n");

			info = sbChanges.ToString();

			if (sbError.Length > 0)
			{
				if (ProgressUpdate != null)
					ProgressUpdate("Examination complete. Errors were found",
						"Error Information\r\n" + sbError.ToString());
				_Errors["AdjustError"] = sbError.ToString();
				return false;
			}

			if (deletes.Count <= 0 && lstActRemove.Count <= 0 && updates.Count <= 0 &&
				chgUpdates.Count <= 0 && string.IsNullOrEmpty(info))
			{
				_Errors["No Changes"] = "No changes pending for this estimate";
				return false;
			}

			if (ConfirmChanges != null)
			{
				if (!ConfirmChanges(info))
				{
					_Errors["UserCancel"] = "Refresh cancelled by user";
					return false;
				}
			}

			bool newTx = !Connection.IsInTransaction;
			try
			{
				if (newTx == true) Connection.TransactionBegin();

				foreach (ClsEstimateChargeDtl edt in deletes) edt.Delete();

				bool ok = true;
				foreach (ClsCargoActivity ca in lstActRemove)
				{
					DataTable dt = ClsEstimateChargeDtl.GetActivityDetail(ca.Cargo_Activity_ID.Value);
					if (dt != null && dt.Rows.Count > 0)
					{
						ok = false;
						sbError.AppendFormat("Unable to remove {0}, charges are still assigned to it\r\n",
							ca.Cargo.Serial_No);
					}
				}

				if (ok)
				{
					foreach (ClsCargoActivity ca in lstActRemove)
					{
						ca.Estimate_ID = null;
						ca.Update();
					}

					foreach (ClsEstimateChargeDtl edt in updates) edt.Update();

					foreach (ClsEstimateCharge echg in chgUpdates) echg.Update();
				}

				if (newTx == true) Connection.TransactionEnd(ok);

				return ok;
			}
			catch
			{
				if (newTx == true) Connection.TransactionRollback();
				throw;
			}
		}

		// TODO: JROMAN For now this method just removes the cargo, but it does not attempt to
		// get the dimensions if they have changed. Revisit this method and revise it so that it
		// checks if dimensions have changed and recalculates based on new value.
		public bool RemoveCargoFromCharges(DataRow[] cargoActRows, out string info)
		{
			info = null;
			ResetErrors();
			if (cargoActRows == null)
			{
				_Errors["Ca_Count"] = "No rows provided to be removed";
				return false;
			}

			StringBuilder sbError = new StringBuilder(), sbCA = new StringBuilder();
			List<ClsCargoActivity> lstCA = new List<ClsCargoActivity>();
			foreach (DataRow dr in cargoActRows)
			{
				long? caID = ClsConvert.ToInt64Nullable(dr["Cargo_Activity_ID"]);
				ClsCargoActivity ca = (caID != null)
					? ClsCargoActivity.GetUsingKey(caID.Value) : null;
				if (ca == null || ca.Cargo_Activity_ID == null) continue;

				lstCA.Add(ca);		// OK, add it to list, and add to comma separated string
				sbCA.AppendFormat("{0}{1}",
					(sbCA.Length > 0 ? ", " : null), ca.Cargo_Activity_ID.Value);
			}

			if (lstCA.Count <= 0)
			{
				_Errors["Ca_Count"] = "No cargo activities provided to be removed";
				return false;
			}

			// Get all charges that are associated with the given cargo activities
			List<ClsEstimateCharge> lstCharges =
				ClsEstimateCharge.GetDistinctChargeList(Estimate_ID.Value, sbCA.ToString());
			if (lstCharges.Count <= 0)
			{
				_Errors["Chg_Count"] = "No charges found for selected cargo";
				return false;
			}

			StringBuilder sbChanges = new StringBuilder();
			List<ClsEstimateChargeDtl> deletes = new List<ClsEstimateChargeDtl>(),
				updates = new List<ClsEstimateChargeDtl>();
			foreach (ClsEstimateCharge echg in lstCharges)		// Modify each charge
			{
				sbChanges.AppendLine(echg.ToString());
				List<ClsEstimateChargeDtl> lstDtl = echg.GetDetail();
				List<string> pcfns = new List<string>();
				List<ClsEstimateChargeDtl> lstRemove = new List<ClsEstimateChargeDtl>();
				foreach (ClsEstimateChargeDtl edt in lstDtl)
				{
					// Build list of detail items that will need to be removed by checking to see
					// if the cargo activity ID associated with this detail item exists in lstCA
					if (lstCA.Exists(delegate(ClsCargoActivity lca)
					{ return lca.Cargo_Activity_ID == edt.Cargo_Activity_ID; }))
					{
						lstRemove.Add(edt);
						sbChanges.AppendFormat("Deleted {0}\r\n", edt.ToString("d"));
					}
					else
					{
						string pcfn = edt.Customer_Ref != null ? edt.Customer_Ref.ToUpper().Trim() : null;
						if (!string.IsNullOrWhiteSpace(pcfn) && !pcfns.Contains(pcfn)) pcfns.Add(pcfn);
					}
				}

				// Decrement the tcn_count in the charge by the number of activities found
				// Error exists if tcn_count goes negative or if number of activities was 0
				if (lstRemove == null || lstRemove.Count <= 0 || lstRemove.Count > echg.Tcn_Count)
				{
					sbError.AppendFormat("Error adjusting TCN count for charge {0}\r\n", echg);
					continue;
				}

				echg.Tcn_Count -= lstRemove.Count;
				deletes.AddRange(lstRemove);

				ClsLevelUnit basis = echg.Level_Unit;
				if (basis.IsComputeExact == false)
				{	// When we are computing an exact TCN amount, the Level_Count field defaults to 1
					// and we do not need to adjust it, otherwise we need to attemp the following...
					if (basis.IsPCFN)	// If PCFN based, assign the total number of PCFNs
					{
						echg.Level_Count = pcfns.Count;
					}
					else if (basis.IsTCN)	// If TCN based, Level_Count will equel Tcn_Count
					{
						echg.Level_Count = echg.Tcn_Count;
					}
					else if (basis.IsConveyance && echg.Charge_Type.IsLineHaul)
					{
						long ppc = echg.Pcs_Per_Conveyance.GetValueOrDefault(0);
						long tcount = echg.Tcn_Count.GetValueOrDefault(0);
						if (ppc <= 0 || tcount <= 0)	// If pcs per or tcn count is less than or
						{								// equal to 0, we can't compute level count
							echg.Level_Count = 0;
						}
						else
						{										// divide
							long cnvys = tcount / ppc;
							if (tcount % ppc != 0) cnvys++;		// then account for any remainder
							echg.Level_Count = cnvys;
						}
					}
					// otherwise the value is either a default of 1 (Level=ALL) or the user has
					// entered a value that we cannot or do not compute (Level=CONVOYs)
				}

				// Adjust the original detail list to take out the items that will be removed
				lstRemove.ForEach(delegate(ClsEstimateChargeDtl ldet)
				{ lstDtl.Remove(ldet); });
				if (lstDtl.Count <= 0)
				{
					sbChanges.AppendFormat("All TCNs removed from charge\r\n");
				}
				else
				{
					if (basis.IsComputeExact)
					{
						decimal totalAmt = 0, totalQty = 0;
						foreach (ClsEstimateChargeDtl edt in lstDtl)	// Now recompute each that remains
						{	// Since we are computing exact we do not need to compute the activity
							// amt again, because we are not refreshing the dimensions (yet).
							totalAmt += edt.Activity_Amt.GetValueOrDefault(0);
							totalQty += edt.Activity_Unit_Qty.GetValueOrDefault(0);
						}
						echg.Unit_Qty = totalQty;
						echg.Total_Amt = totalAmt;
					}
					else
					{
						echg.Total_Amt = echg.Rate_Amt.GetValueOrDefault(0) *
							echg.Level_Count.GetValueOrDefault(0) * echg.Unit_Qty.GetValueOrDefault(0);

						int extraItems = 0;
						decimal perTcnAmt = 0M, extraAmt = 0.01M;
						ClsConvert.DivideCurrencyEvenly(echg.Total_Amt.GetValueOrDefault(0),
							lstDtl.Count, out perTcnAmt, out extraItems);
						sbChanges.AppendFormat("Each TCN amount is now {0} for Charge {1} {2}\r\n",
							perTcnAmt, echg.Estimate_Charge_ID, echg.Charge_Type.Charge_Type_Dsc);
						foreach (ClsEstimateChargeDtl edt in lstDtl)
						{
							decimal tcnAmt = perTcnAmt;
							if (extraItems > 0)
							{
								tcnAmt += extraAmt;
								extraItems--;
							}
							edt.Activity_Amt = tcnAmt;
							edt.Activity_Unit_Qty = echg.Unit_Qty;
							updates.Add(edt);
						}
					}
				}

				sbChanges.AppendFormat("{0}\r\n\r\n", echg.ToString());
			}

			info = sbChanges.ToString();

			bool newTx = !Connection.IsInTransaction;
			try
			{
				if (newTx == true) Connection.TransactionBegin();

				foreach (ClsEstimateChargeDtl edt in deletes) edt.Delete();

				foreach (ClsEstimateChargeDtl edt in updates) edt.Update();

				foreach (ClsEstimateCharge echg in lstCharges) echg.Update();

				if (newTx == true) Connection.TransactionCommit();

				return true;
			}
			catch
			{
				if (newTx == true) Connection.TransactionRollback();
				throw;
			}
		}
		#endregion		// #region Recompute Charges
	}

	#region Static Methods/Properties of ClsEstimate

	partial class ClsEstimate
	{
		public static ClsEstimate GetUsingEstimateNo(string estNo)
		{
			string sql = @"
			SELECT	est.*
			FROM	t_estimate est
			WHERE	est.estimate_no = @EST_NO ";

			DbParameter[] p = new DbParameter[1];
			p[0] = Connection.GetParameter("@EST_NO", estNo);

			DataRow dr = Connection.GetDataRow(sql, p);
			return (dr != null) ? new ClsEstimate(dr) : null;
		}

		public static ClsEstimate GetEstimate(string voyage_no, string orig_cd, string dest_cd)
		{
			if (string.IsNullOrEmpty(voyage_no) || string.IsNullOrEmpty(orig_cd) ||
				string.IsNullOrEmpty(dest_cd)) return null;
			string sql = @"
			SELECT	est.*
			FROM	t_estimate est
			WHERE	est.voyage_no = @VY_NO AND est.orig_location_cd = @ORIG_CD AND
					est.dest_location_cd = @DEST_CD ";
			DbParameter[] p = new DbParameter[3];
			p[0] = Connection.GetParameter("@VY_NO", voyage_no);
			p[1] = Connection.GetParameter("@ORIG_CD", orig_cd);
			p[2] = Connection.GetParameter("@DEST_CD", dest_cd);

			DataRow dr = Connection.GetDataRow(sql, p);
			return (dr != null) ? new ClsEstimate(dr) : null;
		}

		public static ClsEstimate CreateEstimate(string voyage_no, string orig_cd, string dest_cd, List<ClsCargoActivity> lstActs, out string error)
		{
			error = null;
			if (string.IsNullOrEmpty(voyage_no))
			{
				error = "Missing voyage #";
				return null;
			}
			if (string.IsNullOrEmpty(orig_cd))
			{
				error = "Missing origin";
				return null;
			}
			if (string.IsNullOrEmpty(dest_cd))
			{
				error = "Missing destination";
				return null;
			}

			ClsEstimate est = GetEstimate(voyage_no, orig_cd, dest_cd);
			if (est != null)
			{
				error = string.Format("Estimate {0}:{1} already exists for {2} {3} - {4}",
					est.Estimate_ID, est.Estimate_No, voyage_no, orig_cd, dest_cd);
				return null;
			}

			est = new ClsEstimate();
			est.SetDefaults();
			est.Orig_Location_Cd = orig_cd;
			est.Dest_Location_Cd = dest_cd;
			est.Voyage_No = voyage_no;
			if (!est.ValidateInsert())
			{
				error = est.Error;
				return null;
			}

			StringBuilder sb = new StringBuilder();
			Dictionary<string, int> tcns = new Dictionary<string, int>();
			foreach (ClsCargoActivity ca in lstActs)
			{
				string tcn = ca.Cargo.Serial_No.NullTrimUpper();
				if (tcn.IsNullOrWhiteSpace())
				{
					sb.AppendFormat("Cargo Activity {0} is missing a serial #\r\n",
						ca.Cargo_Activity_ID);
					continue;
				}

				if (ca.Billable_Flg == "N" && ca.Payable_Flg == "N")
				{
					sb.AppendFormat("Serial # {0} is flagged as non-billable and non-payable\r\n",
						ca.Cargo.Serial_No);
					continue;
				}

				if (tcns.ContainsKey(tcn))
					tcns[tcn] = tcns[tcn] + 1;
				else
					tcns[tcn] = 1;
			}

			foreach (string tcn in tcns.Keys)
			{
				int count = tcns[tcn];
				if( count > 1 )
					sb.AppendFormat("Duplicate serial # {0} not allowed \r\n", tcn);
			}

			if (sb.Length > 0)
			{
				error = sb.ToString();
				return null;
			}

			bool newTx = !Connection.IsInTransaction;
			try
			{
				if (newTx == true) Connection.TransactionBegin();

				ClsEstimate.AttemptInsert(est, "EST");
				foreach (ClsCargoActivity ca in lstActs)
				{
					ca.Estimate_ID = est.Estimate_ID;
					ca.Update();
				}

				if (newTx == true) Connection.TransactionCommit();
			}
			catch (Exception ex)
			{
				if (newTx == true) Connection.TransactionRollback();
				error = ex.ToString();
				return null;
			}
			return est;
		}

		public static void AttemptInsert(ClsEstimate theEstimate, string startsWith)
		{
			bool insertOK = false;
			byte maxAttempts = ClsConfig.MaxInsertAttempts;
			for (int i = 0; i < maxAttempts; i++)
			{
				theEstimate.Estimate_No = Connection.GetMaxNo(ClsEstimate.TableName,
					"ESTIMATE_NO", startsWith, (char)0, (char)0);
				try
				{
					theEstimate.Insert();				// then add the estimate
					insertOK = true;
				}
				catch (Exception ex)
				{
					insertOK = false;

					// If it is not the unique constraint on the estimate #, throw it again
					if (ex.Message.IndexOf(theEstimate.EstimateUniqueConstraint,
						StringComparison.InvariantCultureIgnoreCase) < 0)
						throw;

					// otherwise, log it as a warning and try again
					ClsErrorHandler.LogWarning(ex.Message);
				}

				if (insertOK) break;
			}

			if (!insertOK)
				throw new ClsException(false, "Error saving estimate, please attempt to create again");
		}
	}
	#endregion		// #region Static Methods/Properties of ClsEstimate
}