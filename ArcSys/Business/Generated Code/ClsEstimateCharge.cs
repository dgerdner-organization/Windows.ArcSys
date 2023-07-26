using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsEstimateCharge : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ArcSys"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "T_ESTIMATE_CHARGE";
		public const int PrimaryKeyCount = 1;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] { "ESTIMATE_CHARGE_ID" };
		}

		public const string SelectSQL = @"SELECT * FROM T_ESTIMATE_CHARGE 
				LEFT OUTER JOIN R_CUSTOMER
				ON T_ESTIMATE_CHARGE.CUSTOMER_CD=R_CUSTOMER.CUSTOMER_CD
				LEFT OUTER JOIN T_CONTRACT_MOD
				ON T_ESTIMATE_CHARGE.CONTRACT_MOD_ID=T_CONTRACT_MOD.CONTRACT_MOD_ID
				LEFT OUTER JOIN R_VENDOR
				ON T_ESTIMATE_CHARGE.VENDOR_CD=R_VENDOR.VENDOR_CD
				INNER JOIN R_FINANCE
				ON T_ESTIMATE_CHARGE.FINANCE_CD=R_FINANCE.FINANCE_CD
				INNER JOIN R_CHARGE_TYPE
				ON T_ESTIMATE_CHARGE.CHARGE_TYPE_CD=R_CHARGE_TYPE.CHARGE_TYPE_CD
				INNER JOIN T_ESTIMATE
				ON T_ESTIMATE_CHARGE.ESTIMATE_ID=T_ESTIMATE.ESTIMATE_ID
				INNER JOIN R_LEVEL_UNIT
				ON T_ESTIMATE_CHARGE.LEVEL_UNIT_ID=R_LEVEL_UNIT.LEVEL_UNIT_ID ";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Create_UserMax = 30;
		public const int Modify_UserMax = 30;
		public const int Charge_Type_CdMax = 10;
		public const int Finance_CdMax = 2;
		public const int Vendor_CdMax = 10;
		public const int Customer_CdMax = 10;
		public const int MemoMax = 50;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected Int64? _Estimate_Charge_ID;
		protected Int64? _Estimate_ID;
		protected string _Create_User;
		protected DateTime? _Create_Dt;
		protected string _Modify_User;
		protected DateTime? _Modify_Dt;
		protected string _Charge_Type_Cd;
		protected Int64? _Level_Unit_ID;
		protected decimal? _Rate_Amt;
		protected Int64? _Level_Count;
		protected decimal? _Unit_Qty;
		protected decimal? _Total_Amt;
		protected string _Finance_Cd;
		protected Int64? _Tcn_Count;
		protected Int64? _Pcs_Per_Conveyance;
		protected Int64? _Contract_Mod_ID;
		protected string _Vendor_Cd;
		protected string _Customer_Cd;
		protected string _Memo;

		#endregion	// #region Column Fields

		#region Column Properties

		public Int64? Estimate_Charge_ID
		{
			get { return _Estimate_Charge_ID; }
			set
			{
				if( _Estimate_Charge_ID == value ) return;
		
				_Estimate_Charge_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Estimate_Charge_ID");
			}
		}
		public Int64? Estimate_ID
		{
			get { return _Estimate_ID; }
			set
			{
				if( _Estimate_ID == value ) return;
		
				_Estimate_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Estimate_ID");
			}
		}
		public string Create_User
		{
			get { return _Create_User; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Create_User, val, false) == 0 ) return;
		
				if( val != null && val.Length > Create_UserMax )
					_Create_User = val.Substring(0, (int)Create_UserMax);
				else
					_Create_User = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Create_User");
			}
		}
		public DateTime? Create_Dt
		{
			get { return _Create_Dt; }
			set
			{
				if( _Create_Dt == value ) return;
		
				_Create_Dt = value;
				_IsDirty = true;
				NotifyPropertyChanged("Create_Dt");
			}
		}
		public string Modify_User
		{
			get { return _Modify_User; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Modify_User, val, false) == 0 ) return;
		
				if( val != null && val.Length > Modify_UserMax )
					_Modify_User = val.Substring(0, (int)Modify_UserMax);
				else
					_Modify_User = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Modify_User");
			}
		}
		public DateTime? Modify_Dt
		{
			get { return _Modify_Dt; }
			set
			{
				if( _Modify_Dt == value ) return;
		
				_Modify_Dt = value;
				_IsDirty = true;
				NotifyPropertyChanged("Modify_Dt");
			}
		}
		public string Charge_Type_Cd
		{
			get { return _Charge_Type_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Charge_Type_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Charge_Type_CdMax )
					_Charge_Type_Cd = val.Substring(0, (int)Charge_Type_CdMax);
				else
					_Charge_Type_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Charge_Type_Cd");
			}
		}
		public Int64? Level_Unit_ID
		{
			get { return _Level_Unit_ID; }
			set
			{
				if( _Level_Unit_ID == value ) return;
		
				_Level_Unit_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Level_Unit_ID");
			}
		}
		public decimal? Rate_Amt
		{
			get { return _Rate_Amt; }
			set
			{
				if( _Rate_Amt == value ) return;
		
				_Rate_Amt = value;
				_IsDirty = true;
				NotifyPropertyChanged("Rate_Amt");
			}
		}
		public Int64? Level_Count
		{
			get { return _Level_Count; }
			set
			{
				if( _Level_Count == value ) return;
		
				_Level_Count = value;
				_IsDirty = true;
				NotifyPropertyChanged("Level_Count");
			}
		}
		public decimal? Unit_Qty
		{
			get { return _Unit_Qty; }
			set
			{
				if( _Unit_Qty == value ) return;
		
				_Unit_Qty = value;
				_IsDirty = true;
				NotifyPropertyChanged("Unit_Qty");
			}
		}
		public decimal? Total_Amt
		{
			get { return _Total_Amt; }
			set
			{
				if( _Total_Amt == value ) return;
		
				_Total_Amt = value;
				_IsDirty = true;
				NotifyPropertyChanged("Total_Amt");
			}
		}
		public string Finance_Cd
		{
			get { return _Finance_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Finance_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Finance_CdMax )
					_Finance_Cd = val.Substring(0, (int)Finance_CdMax);
				else
					_Finance_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Finance_Cd");
			}
		}
		public Int64? Tcn_Count
		{
			get { return _Tcn_Count; }
			set
			{
				if( _Tcn_Count == value ) return;
		
				_Tcn_Count = value;
				_IsDirty = true;
				NotifyPropertyChanged("Tcn_Count");
			}
		}
		public Int64? Pcs_Per_Conveyance
		{
			get { return _Pcs_Per_Conveyance; }
			set
			{
				if( _Pcs_Per_Conveyance == value ) return;
		
				_Pcs_Per_Conveyance = value;
				_IsDirty = true;
				NotifyPropertyChanged("Pcs_Per_Conveyance");
			}
		}
		public Int64? Contract_Mod_ID
		{
			get { return _Contract_Mod_ID; }
			set
			{
				if( _Contract_Mod_ID == value ) return;
		
				_Contract_Mod_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Contract_Mod_ID");
			}
		}
		public string Vendor_Cd
		{
			get { return _Vendor_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Vendor_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Vendor_CdMax )
					_Vendor_Cd = val.Substring(0, (int)Vendor_CdMax);
				else
					_Vendor_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Vendor_Cd");
			}
		}
		public string Customer_Cd
		{
			get { return _Customer_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Customer_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Customer_CdMax )
					_Customer_Cd = val.Substring(0, (int)Customer_CdMax);
				else
					_Customer_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Customer_Cd");
			}
		}
		public string Memo
		{
			get { return _Memo; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Memo, val, false) == 0 ) return;
		
				if( val != null && val.Length > MemoMax )
					_Memo = val.Substring(0, (int)MemoMax);
				else
					_Memo = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Memo");
			}
		}

		#endregion	// #region Column Properties

		#region Foreign Key Fields

		protected ClsCustomer _Customer;
		protected ClsContractMod _Contract_Mod;
		protected ClsVendor _Vendor;
		protected ClsFinance _Finance;
		protected ClsChargeType _Charge_Type;
		protected ClsEstimate _Estimate;
		protected ClsLevelUnit _Level_Unit;

		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties

		public ClsCustomer Customer
		{
			get
			{
				if( Customer_Cd == null )
					_Customer = null;
				else if( _Customer == null ||
					_Customer.Customer_Cd != Customer_Cd )
					_Customer = ClsCustomer.GetUsingKey(Customer_Cd);
				return _Customer;
			}
			set
			{
				if( _Customer == value ) return;
		
				_Customer = value;
			}
		}
		public ClsContractMod Contract_Mod
		{
			get
			{
				if( Contract_Mod_ID == null )
					_Contract_Mod = null;
				else if( _Contract_Mod == null ||
					_Contract_Mod.Contract_Mod_ID != Contract_Mod_ID )
					_Contract_Mod = ClsContractMod.GetUsingKey(Contract_Mod_ID.Value);
				return _Contract_Mod;
			}
			set
			{
				if( _Contract_Mod == value ) return;
		
				_Contract_Mod = value;
			}
		}
		public ClsVendor Vendor
		{
			get
			{
				if( Vendor_Cd == null )
					_Vendor = null;
				else if( _Vendor == null ||
					_Vendor.Vendor_Cd != Vendor_Cd )
					_Vendor = ClsVendor.GetUsingKey(Vendor_Cd);
				return _Vendor;
			}
			set
			{
				if( _Vendor == value ) return;
		
				_Vendor = value;
			}
		}
		public ClsFinance Finance
		{
			get
			{
				if( Finance_Cd == null )
					_Finance = null;
				else if( _Finance == null ||
					_Finance.Finance_Cd != Finance_Cd )
					_Finance = ClsFinance.GetUsingKey(Finance_Cd);
				return _Finance;
			}
			set
			{
				if( _Finance == value ) return;
		
				_Finance = value;
			}
		}
		public ClsChargeType Charge_Type
		{
			get
			{
				if( Charge_Type_Cd == null )
					_Charge_Type = null;
				else if( _Charge_Type == null ||
					_Charge_Type.Charge_Type_Cd != Charge_Type_Cd )
					_Charge_Type = ClsChargeType.GetUsingKey(Charge_Type_Cd);
				return _Charge_Type;
			}
			set
			{
				if( _Charge_Type == value ) return;
		
				_Charge_Type = value;
			}
		}
		public ClsEstimate Estimate
		{
			get
			{
				if( Estimate_ID == null )
					_Estimate = null;
				else if( _Estimate == null ||
					_Estimate.Estimate_ID != Estimate_ID )
					_Estimate = ClsEstimate.GetUsingKey(Estimate_ID.Value);
				return _Estimate;
			}
			set
			{
				if( _Estimate == value ) return;
		
				_Estimate = value;
			}
		}
		public ClsLevelUnit Level_Unit
		{
			get
			{
				if( Level_Unit_ID == null )
					_Level_Unit = null;
				else if( _Level_Unit == null ||
					_Level_Unit.Level_Unit_ID != Level_Unit_ID )
					_Level_Unit = ClsLevelUnit.GetUsingKey(Level_Unit_ID.Value);
				return _Level_Unit;
			}
			set
			{
				if( _Level_Unit == value ) return;
		
				_Level_Unit = value;
			}
		}

		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsEstimateCharge() : base() {}
		public ClsEstimateCharge(DataRow dr) : base(dr) {}
		public ClsEstimateCharge(ClsEstimateCharge src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Estimate_Charge_ID = null;
			Estimate_ID = null;
			Create_User = null;
			Create_Dt = null;
			Modify_User = null;
			Modify_Dt = null;
			Charge_Type_Cd = null;
			Level_Unit_ID = null;
			Rate_Amt = null;
			Level_Count = null;
			Unit_Qty = null;
			Total_Amt = null;
			Finance_Cd = null;
			Tcn_Count = null;
			Pcs_Per_Conveyance = null;
			Contract_Mod_ID = null;
			Vendor_Cd = null;
			Customer_Cd = null;
			Memo = null;
		}

		public void CopyFrom(ClsEstimateCharge src)
		{
			Estimate_Charge_ID = src._Estimate_Charge_ID;
			Estimate_ID = src._Estimate_ID;
			Create_User = src._Create_User;
			Create_Dt = src._Create_Dt;
			Modify_User = src._Modify_User;
			Modify_Dt = src._Modify_Dt;
			Charge_Type_Cd = src._Charge_Type_Cd;
			Level_Unit_ID = src._Level_Unit_ID;
			Rate_Amt = src._Rate_Amt;
			Level_Count = src._Level_Count;
			Unit_Qty = src._Unit_Qty;
			Total_Amt = src._Total_Amt;
			Finance_Cd = src._Finance_Cd;
			Tcn_Count = src._Tcn_Count;
			Pcs_Per_Conveyance = src._Pcs_Per_Conveyance;
			Contract_Mod_ID = src._Contract_Mod_ID;
			Vendor_Cd = src._Vendor_Cd;
			Customer_Cd = src._Customer_Cd;
			Memo = src._Memo;
		}

		public override bool ReloadFromDB()
		{
			ClsEstimateCharge tmp = ClsEstimateCharge.GetUsingKey(Estimate_Charge_ID.Value);
			if( tmp != null ) CopyFrom(tmp);

			ResetFKs();
			OnReload();

			return ( tmp != null );
		}

		public override void ResetFKs()
		{
			_Customer = null;
			_Contract_Mod = null;
			_Vendor = null;
			_Finance = null;
			_Charge_Type = null;
			_Estimate = null;
			_Level_Unit = null;
		}
		#endregion		// #region Init methods

		#region Insert, Update, Delete

		public override int Insert()
		{

			DbParameter[] p = new DbParameter[19];

			p[0] = Connection.GetParameter
				("@ESTIMATE_ID", Estimate_ID);
			p[1] = Connection.GetParameter
				("@CHARGE_TYPE_CD", Charge_Type_Cd);
			p[2] = Connection.GetParameter
				("@LEVEL_UNIT_ID", Level_Unit_ID);
			p[3] = Connection.GetParameter
				("@RATE_AMT", Rate_Amt);
			p[4] = Connection.GetParameter
				("@LEVEL_COUNT", Level_Count);
			p[5] = Connection.GetParameter
				("@UNIT_QTY", Unit_Qty);
			p[6] = Connection.GetParameter
				("@TOTAL_AMT", Total_Amt);
			p[7] = Connection.GetParameter
				("@FINANCE_CD", Finance_Cd);
			p[8] = Connection.GetParameter
				("@TCN_COUNT", Tcn_Count);
			p[9] = Connection.GetParameter
				("@PCS_PER_CONVEYANCE", Pcs_Per_Conveyance);
			p[10] = Connection.GetParameter
				("@CONTRACT_MOD_ID", Contract_Mod_ID);
			p[11] = Connection.GetParameter
				("@VENDOR_CD", Vendor_Cd);
			p[12] = Connection.GetParameter
				("@CUSTOMER_CD", Customer_Cd);
			p[13] = Connection.GetParameter
				("@MEMO", Memo);
			p[14] = Connection.GetParameter
				("@ESTIMATE_CHARGE_ID", Estimate_Charge_ID, ParameterDirection.Output, DbType.Int64, 0);
			p[15] = Connection.GetParameter
				("@CREATE_USER", Create_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Create_UserMax);
			p[16] = Connection.GetParameter
				("@CREATE_DT", Create_Dt, ParameterDirection.Output, DbType.DateTime, 0);
			p[17] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);
			p[18] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.Output, DbType.DateTime, 0);

			const string sql = @"
				INSERT INTO T_ESTIMATE_CHARGE
					(ESTIMATE_CHARGE_ID, ESTIMATE_ID, CHARGE_TYPE_CD,
					LEVEL_UNIT_ID, RATE_AMT, LEVEL_COUNT,
					UNIT_QTY, TOTAL_AMT, FINANCE_CD,
					TCN_COUNT, PCS_PER_CONVEYANCE, CONTRACT_MOD_ID,
					VENDOR_CD, CUSTOMER_CD, MEMO)
				VALUES
					(ESTIMATE_CHARGE_ID_SEQ.NEXTVAL, @ESTIMATE_ID, @CHARGE_TYPE_CD,
					@LEVEL_UNIT_ID, @RATE_AMT, @LEVEL_COUNT,
					@UNIT_QTY, @TOTAL_AMT, @FINANCE_CD,
					@TCN_COUNT, @PCS_PER_CONVEYANCE, @CONTRACT_MOD_ID,
					@VENDOR_CD, @CUSTOMER_CD, @MEMO)
				RETURNING
					ESTIMATE_CHARGE_ID, CREATE_USER, CREATE_DT,
					MODIFY_USER, MODIFY_DT
				INTO
					@ESTIMATE_CHARGE_ID, @CREATE_USER, @CREATE_DT,
					@MODIFY_USER, @MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Estimate_Charge_ID = ClsConvert.ToInt64Nullable(p[14].Value);
			Create_User = ClsConvert.ToString(p[15].Value);
			Create_Dt = ClsConvert.ToDateTimeNullable(p[16].Value);
			Modify_User = ClsConvert.ToString(p[17].Value);
			Modify_Dt = ClsConvert.ToDateTimeNullable(p[18].Value);
			return ret;
		}
		public override int Update()
		{
			DbParameter[] p = new DbParameter[17];

			p[0] = Connection.GetParameter
				("@ESTIMATE_ID", Estimate_ID);
			p[1] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.InputOutput, DbType.DateTime, 0);
			p[2] = Connection.GetParameter
				("@CHARGE_TYPE_CD", Charge_Type_Cd);
			p[3] = Connection.GetParameter
				("@LEVEL_UNIT_ID", Level_Unit_ID);
			p[4] = Connection.GetParameter
				("@RATE_AMT", Rate_Amt);
			p[5] = Connection.GetParameter
				("@LEVEL_COUNT", Level_Count);
			p[6] = Connection.GetParameter
				("@UNIT_QTY", Unit_Qty);
			p[7] = Connection.GetParameter
				("@TOTAL_AMT", Total_Amt);
			p[8] = Connection.GetParameter
				("@FINANCE_CD", Finance_Cd);
			p[9] = Connection.GetParameter
				("@TCN_COUNT", Tcn_Count);
			p[10] = Connection.GetParameter
				("@PCS_PER_CONVEYANCE", Pcs_Per_Conveyance);
			p[11] = Connection.GetParameter
				("@CONTRACT_MOD_ID", Contract_Mod_ID);
			p[12] = Connection.GetParameter
				("@VENDOR_CD", Vendor_Cd);
			p[13] = Connection.GetParameter
				("@CUSTOMER_CD", Customer_Cd);
			p[14] = Connection.GetParameter
				("@MEMO", Memo);
			p[15] = Connection.GetParameter
				("@ESTIMATE_CHARGE_ID", Estimate_Charge_ID);
			p[16] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);

			const string sql = @"
				UPDATE T_ESTIMATE_CHARGE SET
					ESTIMATE_ID = @ESTIMATE_ID,
					MODIFY_DT = @MODIFY_DT,
					CHARGE_TYPE_CD = @CHARGE_TYPE_CD,
					LEVEL_UNIT_ID = @LEVEL_UNIT_ID,
					RATE_AMT = @RATE_AMT,
					LEVEL_COUNT = @LEVEL_COUNT,
					UNIT_QTY = @UNIT_QTY,
					TOTAL_AMT = @TOTAL_AMT,
					FINANCE_CD = @FINANCE_CD,
					TCN_COUNT = @TCN_COUNT,
					PCS_PER_CONVEYANCE = @PCS_PER_CONVEYANCE,
					CONTRACT_MOD_ID = @CONTRACT_MOD_ID,
					VENDOR_CD = @VENDOR_CD,
					CUSTOMER_CD = @CUSTOMER_CD,
					MEMO = @MEMO
				WHERE
					ESTIMATE_CHARGE_ID = @ESTIMATE_CHARGE_ID
				RETURNING
					MODIFY_USER, MODIFY_DT
				INTO
					@MODIFY_USER, @MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Modify_Dt = ClsConvert.ToDateTimeNullable(p[1].Value);
			Modify_User = ClsConvert.ToString(p[16].Value);
			return ret;
		}
		public override int Delete()
		{
			DbParameter[] p = new DbParameter[1];

			p[0] = Connection.GetParameter
				("@ESTIMATE_CHARGE_ID", Estimate_Charge_ID);

			const string sql = @"
				DELETE FROM T_ESTIMATE_CHARGE WHERE
				ESTIMATE_CHARGE_ID=@ESTIMATE_CHARGE_ID";
			return Connection.RunSQL(sql, p);
		}
		#endregion		// #region Insert, Update, Delete

		#region Conversion methods

		public override void LoadFromDataReader(DbDataReader dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataReader: DataReader parameter was null");

			Estimate_Charge_ID = ClsConvert.ToInt64Nullable(dr["ESTIMATE_CHARGE_ID"]);
			Estimate_ID = ClsConvert.ToInt64Nullable(dr["ESTIMATE_ID"]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER"]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT"]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER"]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT"]);
			Charge_Type_Cd = ClsConvert.ToString(dr["CHARGE_TYPE_CD"]);
			Level_Unit_ID = ClsConvert.ToInt64Nullable(dr["LEVEL_UNIT_ID"]);
			Rate_Amt = ClsConvert.ToDecimalNullable(dr["RATE_AMT"]);
			Level_Count = ClsConvert.ToInt64Nullable(dr["LEVEL_COUNT"]);
			Unit_Qty = ClsConvert.ToDecimalNullable(dr["UNIT_QTY"]);
			Total_Amt = ClsConvert.ToDecimalNullable(dr["TOTAL_AMT"]);
			Finance_Cd = ClsConvert.ToString(dr["FINANCE_CD"]);
			Tcn_Count = ClsConvert.ToInt64Nullable(dr["TCN_COUNT"]);
			Pcs_Per_Conveyance = ClsConvert.ToInt64Nullable(dr["PCS_PER_CONVEYANCE"]);
			Contract_Mod_ID = ClsConvert.ToInt64Nullable(dr["CONTRACT_MOD_ID"]);
			Vendor_Cd = ClsConvert.ToString(dr["VENDOR_CD"]);
			Customer_Cd = ClsConvert.ToString(dr["CUSTOMER_CD"]);
			Memo = ClsConvert.ToString(dr["MEMO"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Estimate_Charge_ID = ClsConvert.ToInt64Nullable(dr["ESTIMATE_CHARGE_ID", v]);
			Estimate_ID = ClsConvert.ToInt64Nullable(dr["ESTIMATE_ID", v]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER", v]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT", v]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER", v]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT", v]);
			Charge_Type_Cd = ClsConvert.ToString(dr["CHARGE_TYPE_CD", v]);
			Level_Unit_ID = ClsConvert.ToInt64Nullable(dr["LEVEL_UNIT_ID", v]);
			Rate_Amt = ClsConvert.ToDecimalNullable(dr["RATE_AMT", v]);
			Level_Count = ClsConvert.ToInt64Nullable(dr["LEVEL_COUNT", v]);
			Unit_Qty = ClsConvert.ToDecimalNullable(dr["UNIT_QTY", v]);
			Total_Amt = ClsConvert.ToDecimalNullable(dr["TOTAL_AMT", v]);
			Finance_Cd = ClsConvert.ToString(dr["FINANCE_CD", v]);
			Tcn_Count = ClsConvert.ToInt64Nullable(dr["TCN_COUNT", v]);
			Pcs_Per_Conveyance = ClsConvert.ToInt64Nullable(dr["PCS_PER_CONVEYANCE", v]);
			Contract_Mod_ID = ClsConvert.ToInt64Nullable(dr["CONTRACT_MOD_ID", v]);
			Vendor_Cd = ClsConvert.ToString(dr["VENDOR_CD", v]);
			Customer_Cd = ClsConvert.ToString(dr["CUSTOMER_CD", v]);
			Memo = ClsConvert.ToString(dr["MEMO", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["ESTIMATE_CHARGE_ID"] = ClsConvert.ToDbObject(Estimate_Charge_ID);
			dr["ESTIMATE_ID"] = ClsConvert.ToDbObject(Estimate_ID);
			dr["CREATE_USER"] = ClsConvert.ToDbObject(Create_User);
			dr["CREATE_DT"] = ClsConvert.ToDbObject(Create_Dt);
			dr["MODIFY_USER"] = ClsConvert.ToDbObject(Modify_User);
			dr["MODIFY_DT"] = ClsConvert.ToDbObject(Modify_Dt);
			dr["CHARGE_TYPE_CD"] = ClsConvert.ToDbObject(Charge_Type_Cd);
			dr["LEVEL_UNIT_ID"] = ClsConvert.ToDbObject(Level_Unit_ID);
			dr["RATE_AMT"] = ClsConvert.ToDbObject(Rate_Amt);
			dr["LEVEL_COUNT"] = ClsConvert.ToDbObject(Level_Count);
			dr["UNIT_QTY"] = ClsConvert.ToDbObject(Unit_Qty);
			dr["TOTAL_AMT"] = ClsConvert.ToDbObject(Total_Amt);
			dr["FINANCE_CD"] = ClsConvert.ToDbObject(Finance_Cd);
			dr["TCN_COUNT"] = ClsConvert.ToDbObject(Tcn_Count);
			dr["PCS_PER_CONVEYANCE"] = ClsConvert.ToDbObject(Pcs_Per_Conveyance);
			dr["CONTRACT_MOD_ID"] = ClsConvert.ToDbObject(Contract_Mod_ID);
			dr["VENDOR_CD"] = ClsConvert.ToDbObject(Vendor_Cd);
			dr["CUSTOMER_CD"] = ClsConvert.ToDbObject(Customer_Cd);
			dr["MEMO"] = ClsConvert.ToDbObject(Memo);
		}
		#endregion		// #region Conversion methods

		#region Static Methods

		public static DataTable GetAll()
		{
			return Connection.GetTable(TableName);
		}

		public static DataTable GetAll(bool withJoins)
		{
			if( withJoins == false ) return Connection.GetTable(TableName);

			return Connection.GetDataTable(SelectSQL);
		}

		public static ClsEstimateCharge GetUsingKey(Int64 Estimate_Charge_ID)
		{
			object[] vals = new object[] {Estimate_Charge_ID};
			DataRow dr = Connection.GetDataRowUsingKey
				(TableName, GetPrimaryKeys(), vals);
			return ( dr == null ) ? null : new ClsEstimateCharge(dr);
		}
		public static DataTable GetAll(string Customer_Cd, Int64? Contract_Mod_ID,
			string Vendor_Cd, string Finance_Cd,
			string Charge_Type_Cd, Int64? Estimate_ID,
			Int64? Level_Unit_ID)
		{
			List<DbParameter> lst = new List<DbParameter>();	
			StringBuilder sb = new StringBuilder();
		
			if( string.IsNullOrEmpty(Customer_Cd) == false )
			{
				lst.Add(Connection.GetParameter("@CUSTOMER_CD", Customer_Cd));
				sb.Append(" WHERE T_ESTIMATE_CHARGE.CUSTOMER_CD=@CUSTOMER_CD");
			}
			if( Contract_Mod_ID != null && Contract_Mod_ID > 0 )
			{
				lst.Add(Connection.GetParameter("@CONTRACT_MOD_ID", Contract_Mod_ID));
				sb.AppendFormat(" {0} T_ESTIMATE_CHARGE.CONTRACT_MOD_ID=@CONTRACT_MOD_ID",
					sb.Length > 0 ? "AND" : "WHERE");
			}
			if( string.IsNullOrEmpty(Vendor_Cd) == false )
			{
				lst.Add(Connection.GetParameter("@VENDOR_CD", Vendor_Cd));
				sb.AppendFormat(" {0} T_ESTIMATE_CHARGE.VENDOR_CD=@VENDOR_CD",
					sb.Length > 0 ? "AND" : "WHERE");
			}
			if( string.IsNullOrEmpty(Finance_Cd) == false )
			{
				lst.Add(Connection.GetParameter("@FINANCE_CD", Finance_Cd));
				sb.AppendFormat(" {0} T_ESTIMATE_CHARGE.FINANCE_CD=@FINANCE_CD",
					sb.Length > 0 ? "AND" : "WHERE");
			}
			if( string.IsNullOrEmpty(Charge_Type_Cd) == false )
			{
				lst.Add(Connection.GetParameter("@CHARGE_TYPE_CD", Charge_Type_Cd));
				sb.AppendFormat(" {0} T_ESTIMATE_CHARGE.CHARGE_TYPE_CD=@CHARGE_TYPE_CD",
					sb.Length > 0 ? "AND" : "WHERE");
			}
			if( Estimate_ID != null && Estimate_ID > 0 )
			{
				lst.Add(Connection.GetParameter("@ESTIMATE_ID", Estimate_ID));
				sb.AppendFormat(" {0} T_ESTIMATE_CHARGE.ESTIMATE_ID=@ESTIMATE_ID",
					sb.Length > 0 ? "AND" : "WHERE");
			}
			if( Level_Unit_ID != null && Level_Unit_ID > 0 )
			{
				lst.Add(Connection.GetParameter("@LEVEL_UNIT_ID", Level_Unit_ID));
				sb.AppendFormat(" {0} T_ESTIMATE_CHARGE.LEVEL_UNIT_ID=@LEVEL_UNIT_ID",
					sb.Length > 0 ? "AND" : "WHERE");
			}
			sb.Insert(0, SelectSQL);
			return Connection.GetDataTable(sb.ToString(), lst.ToArray());
		}
		#endregion		// #region Static Methods
	}
}