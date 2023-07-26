using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsArCharge : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ArcSys"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "T_AR_CHARGE";
		public const int PrimaryKeyCount = 1;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] { "AR_CHARGE_ID" };
		}

		public const string SelectSQL = @"SELECT * FROM T_AR_CHARGE 
				LEFT OUTER JOIN T_CONTRACT_MOD
				ON T_AR_CHARGE.CONTRACT_MOD_ID=T_CONTRACT_MOD.CONTRACT_MOD_ID
				INNER JOIN R_LEVEL_UNIT
				ON T_AR_CHARGE.LEVEL_UNIT_ID=R_LEVEL_UNIT.LEVEL_UNIT_ID
				INNER JOIN T_AR_INVOICE
				ON T_AR_CHARGE.AR_INVOICE_ID=T_AR_INVOICE.AR_INVOICE_ID
				INNER JOIN R_CHARGE_TYPE
				ON T_AR_CHARGE.CHARGE_TYPE_CD=R_CHARGE_TYPE.CHARGE_TYPE_CD ";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Charge_Type_CdMax = 10;
		public const int Create_UserMax = 30;
		public const int Modify_UserMax = 30;
		public const int MemoMax = 100;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected Int64? _Ar_Charge_ID;
		protected Int64? _Ar_Invoice_ID;
		protected string _Charge_Type_Cd;
		protected Int64? _Level_Unit_ID;
		protected decimal? _Rate_Amt;
		protected Int64? _Level_Count;
		protected decimal? _Unit_Qty;
		protected decimal? _Total_Amt;
		protected Int64? _Tcn_Count;
		protected string _Create_User;
		protected DateTime? _Create_Dt;
		protected string _Modify_User;
		protected DateTime? _Modify_Dt;
		protected Int64? _Pcs_Per_Conveyance;
		protected Int64? _Contract_Mod_ID;
		protected string _Memo;

		#endregion	// #region Column Fields

		#region Column Properties

		public Int64? Ar_Charge_ID
		{
			get { return _Ar_Charge_ID; }
			set
			{
				if( _Ar_Charge_ID == value ) return;
		
				_Ar_Charge_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Ar_Charge_ID");
			}
		}
		public Int64? Ar_Invoice_ID
		{
			get { return _Ar_Invoice_ID; }
			set
			{
				if( _Ar_Invoice_ID == value ) return;
		
				_Ar_Invoice_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Ar_Invoice_ID");
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

		protected ClsContractMod _Contract_Mod;
		protected ClsLevelUnit _Level_Unit;
		protected ClsArInvoice _Ar_Invoice;
		protected ClsChargeType _Charge_Type;

		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties

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
		public ClsArInvoice Ar_Invoice
		{
			get
			{
				if( Ar_Invoice_ID == null )
					_Ar_Invoice = null;
				else if( _Ar_Invoice == null ||
					_Ar_Invoice.Ar_Invoice_ID != Ar_Invoice_ID )
					_Ar_Invoice = ClsArInvoice.GetUsingKey(Ar_Invoice_ID.Value);
				return _Ar_Invoice;
			}
			set
			{
				if( _Ar_Invoice == value ) return;
		
				_Ar_Invoice = value;
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

		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsArCharge() : base() {}
		public ClsArCharge(DataRow dr) : base(dr) {}
		public ClsArCharge(ClsArCharge src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Ar_Charge_ID = null;
			Ar_Invoice_ID = null;
			Charge_Type_Cd = null;
			Level_Unit_ID = null;
			Rate_Amt = null;
			Level_Count = null;
			Unit_Qty = null;
			Total_Amt = null;
			Tcn_Count = null;
			Create_User = null;
			Create_Dt = null;
			Modify_User = null;
			Modify_Dt = null;
			Pcs_Per_Conveyance = null;
			Contract_Mod_ID = null;
			Memo = null;
		}

		public void CopyFrom(ClsArCharge src)
		{
			Ar_Charge_ID = src._Ar_Charge_ID;
			Ar_Invoice_ID = src._Ar_Invoice_ID;
			Charge_Type_Cd = src._Charge_Type_Cd;
			Level_Unit_ID = src._Level_Unit_ID;
			Rate_Amt = src._Rate_Amt;
			Level_Count = src._Level_Count;
			Unit_Qty = src._Unit_Qty;
			Total_Amt = src._Total_Amt;
			Tcn_Count = src._Tcn_Count;
			Create_User = src._Create_User;
			Create_Dt = src._Create_Dt;
			Modify_User = src._Modify_User;
			Modify_Dt = src._Modify_Dt;
			Pcs_Per_Conveyance = src._Pcs_Per_Conveyance;
			Contract_Mod_ID = src._Contract_Mod_ID;
			Memo = src._Memo;
		}

		public override bool ReloadFromDB()
		{
			ClsArCharge tmp = ClsArCharge.GetUsingKey(Ar_Charge_ID.Value);
			if( tmp != null ) CopyFrom(tmp);

			ResetFKs();
			OnReload();

			return ( tmp != null );
		}

		public override void ResetFKs()
		{
			_Contract_Mod = null;
			_Level_Unit = null;
			_Ar_Invoice = null;
			_Charge_Type = null;
		}
		#endregion		// #region Init methods

		#region Insert, Update, Delete

		public override int Insert()
		{

			DbParameter[] p = new DbParameter[16];

			p[0] = Connection.GetParameter
				("@AR_INVOICE_ID", Ar_Invoice_ID);
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
				("@TCN_COUNT", Tcn_Count);
			p[8] = Connection.GetParameter
				("@PCS_PER_CONVEYANCE", Pcs_Per_Conveyance);
			p[9] = Connection.GetParameter
				("@CONTRACT_MOD_ID", Contract_Mod_ID);
			p[10] = Connection.GetParameter
				("@MEMO", Memo);
			p[11] = Connection.GetParameter
				("@AR_CHARGE_ID", Ar_Charge_ID, ParameterDirection.Output, DbType.Int64, 0);
			p[12] = Connection.GetParameter
				("@CREATE_USER", Create_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Create_UserMax);
			p[13] = Connection.GetParameter
				("@CREATE_DT", Create_Dt, ParameterDirection.Output, DbType.DateTime, 0);
			p[14] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);
			p[15] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.Output, DbType.DateTime, 0);

			const string sql = @"
				INSERT INTO T_AR_CHARGE
					(AR_CHARGE_ID, AR_INVOICE_ID, CHARGE_TYPE_CD,
					LEVEL_UNIT_ID, RATE_AMT, LEVEL_COUNT,
					UNIT_QTY, TOTAL_AMT, TCN_COUNT,
					PCS_PER_CONVEYANCE, CONTRACT_MOD_ID, MEMO)
				VALUES
					(AR_CHARGE_ID_SEQ.NEXTVAL, @AR_INVOICE_ID, @CHARGE_TYPE_CD,
					@LEVEL_UNIT_ID, @RATE_AMT, @LEVEL_COUNT,
					@UNIT_QTY, @TOTAL_AMT, @TCN_COUNT,
					@PCS_PER_CONVEYANCE, @CONTRACT_MOD_ID, @MEMO)
				RETURNING
					AR_CHARGE_ID, CREATE_USER, CREATE_DT,
					MODIFY_USER, MODIFY_DT
				INTO
					@AR_CHARGE_ID, @CREATE_USER, @CREATE_DT,
					@MODIFY_USER, @MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Ar_Charge_ID = ClsConvert.ToInt64Nullable(p[11].Value);
			Create_User = ClsConvert.ToString(p[12].Value);
			Create_Dt = ClsConvert.ToDateTimeNullable(p[13].Value);
			Modify_User = ClsConvert.ToString(p[14].Value);
			Modify_Dt = ClsConvert.ToDateTimeNullable(p[15].Value);
			return ret;
		}
		public override int Update()
		{
			DbParameter[] p = new DbParameter[14];

			p[0] = Connection.GetParameter
				("@AR_INVOICE_ID", Ar_Invoice_ID);
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
				("@TCN_COUNT", Tcn_Count);
			p[8] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.InputOutput, DbType.DateTime, 0);
			p[9] = Connection.GetParameter
				("@PCS_PER_CONVEYANCE", Pcs_Per_Conveyance);
			p[10] = Connection.GetParameter
				("@CONTRACT_MOD_ID", Contract_Mod_ID);
			p[11] = Connection.GetParameter
				("@MEMO", Memo);
			p[12] = Connection.GetParameter
				("@AR_CHARGE_ID", Ar_Charge_ID);
			p[13] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);

			const string sql = @"
				UPDATE T_AR_CHARGE SET
					AR_INVOICE_ID = @AR_INVOICE_ID,
					CHARGE_TYPE_CD = @CHARGE_TYPE_CD,
					LEVEL_UNIT_ID = @LEVEL_UNIT_ID,
					RATE_AMT = @RATE_AMT,
					LEVEL_COUNT = @LEVEL_COUNT,
					UNIT_QTY = @UNIT_QTY,
					TOTAL_AMT = @TOTAL_AMT,
					TCN_COUNT = @TCN_COUNT,
					MODIFY_DT = @MODIFY_DT,
					PCS_PER_CONVEYANCE = @PCS_PER_CONVEYANCE,
					CONTRACT_MOD_ID = @CONTRACT_MOD_ID,
					MEMO = @MEMO
				WHERE
					AR_CHARGE_ID = @AR_CHARGE_ID
				RETURNING
					MODIFY_USER, MODIFY_DT
				INTO
					@MODIFY_USER, @MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Modify_Dt = ClsConvert.ToDateTimeNullable(p[8].Value);
			Modify_User = ClsConvert.ToString(p[13].Value);
			return ret;
		}
		public override int Delete()
		{
			DbParameter[] p = new DbParameter[1];

			p[0] = Connection.GetParameter
				("@AR_CHARGE_ID", Ar_Charge_ID);

			const string sql = @"
				DELETE FROM T_AR_CHARGE WHERE
				AR_CHARGE_ID=@AR_CHARGE_ID";
			return Connection.RunSQL(sql, p);
		}
		#endregion		// #region Insert, Update, Delete

		#region Conversion methods

		public override void LoadFromDataReader(DbDataReader dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataReader: DataReader parameter was null");

			Ar_Charge_ID = ClsConvert.ToInt64Nullable(dr["AR_CHARGE_ID"]);
			Ar_Invoice_ID = ClsConvert.ToInt64Nullable(dr["AR_INVOICE_ID"]);
			Charge_Type_Cd = ClsConvert.ToString(dr["CHARGE_TYPE_CD"]);
			Level_Unit_ID = ClsConvert.ToInt64Nullable(dr["LEVEL_UNIT_ID"]);
			Rate_Amt = ClsConvert.ToDecimalNullable(dr["RATE_AMT"]);
			Level_Count = ClsConvert.ToInt64Nullable(dr["LEVEL_COUNT"]);
			Unit_Qty = ClsConvert.ToDecimalNullable(dr["UNIT_QTY"]);
			Total_Amt = ClsConvert.ToDecimalNullable(dr["TOTAL_AMT"]);
			Tcn_Count = ClsConvert.ToInt64Nullable(dr["TCN_COUNT"]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER"]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT"]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER"]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT"]);
			Pcs_Per_Conveyance = ClsConvert.ToInt64Nullable(dr["PCS_PER_CONVEYANCE"]);
			Contract_Mod_ID = ClsConvert.ToInt64Nullable(dr["CONTRACT_MOD_ID"]);
			Memo = ClsConvert.ToString(dr["MEMO"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Ar_Charge_ID = ClsConvert.ToInt64Nullable(dr["AR_CHARGE_ID", v]);
			Ar_Invoice_ID = ClsConvert.ToInt64Nullable(dr["AR_INVOICE_ID", v]);
			Charge_Type_Cd = ClsConvert.ToString(dr["CHARGE_TYPE_CD", v]);
			Level_Unit_ID = ClsConvert.ToInt64Nullable(dr["LEVEL_UNIT_ID", v]);
			Rate_Amt = ClsConvert.ToDecimalNullable(dr["RATE_AMT", v]);
			Level_Count = ClsConvert.ToInt64Nullable(dr["LEVEL_COUNT", v]);
			Unit_Qty = ClsConvert.ToDecimalNullable(dr["UNIT_QTY", v]);
			Total_Amt = ClsConvert.ToDecimalNullable(dr["TOTAL_AMT", v]);
			Tcn_Count = ClsConvert.ToInt64Nullable(dr["TCN_COUNT", v]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER", v]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT", v]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER", v]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT", v]);
			Pcs_Per_Conveyance = ClsConvert.ToInt64Nullable(dr["PCS_PER_CONVEYANCE", v]);
			Contract_Mod_ID = ClsConvert.ToInt64Nullable(dr["CONTRACT_MOD_ID", v]);
			Memo = ClsConvert.ToString(dr["MEMO", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["AR_CHARGE_ID"] = ClsConvert.ToDbObject(Ar_Charge_ID);
			dr["AR_INVOICE_ID"] = ClsConvert.ToDbObject(Ar_Invoice_ID);
			dr["CHARGE_TYPE_CD"] = ClsConvert.ToDbObject(Charge_Type_Cd);
			dr["LEVEL_UNIT_ID"] = ClsConvert.ToDbObject(Level_Unit_ID);
			dr["RATE_AMT"] = ClsConvert.ToDbObject(Rate_Amt);
			dr["LEVEL_COUNT"] = ClsConvert.ToDbObject(Level_Count);
			dr["UNIT_QTY"] = ClsConvert.ToDbObject(Unit_Qty);
			dr["TOTAL_AMT"] = ClsConvert.ToDbObject(Total_Amt);
			dr["TCN_COUNT"] = ClsConvert.ToDbObject(Tcn_Count);
			dr["CREATE_USER"] = ClsConvert.ToDbObject(Create_User);
			dr["CREATE_DT"] = ClsConvert.ToDbObject(Create_Dt);
			dr["MODIFY_USER"] = ClsConvert.ToDbObject(Modify_User);
			dr["MODIFY_DT"] = ClsConvert.ToDbObject(Modify_Dt);
			dr["PCS_PER_CONVEYANCE"] = ClsConvert.ToDbObject(Pcs_Per_Conveyance);
			dr["CONTRACT_MOD_ID"] = ClsConvert.ToDbObject(Contract_Mod_ID);
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

		public static ClsArCharge GetUsingKey(Int64 Ar_Charge_ID)
		{
			object[] vals = new object[] {Ar_Charge_ID};
			DataRow dr = Connection.GetDataRowUsingKey
				(TableName, GetPrimaryKeys(), vals);
			return ( dr == null ) ? null : new ClsArCharge(dr);
		}
		public static DataTable GetAll(Int64? Contract_Mod_ID, Int64? Level_Unit_ID,
			Int64? Ar_Invoice_ID, string Charge_Type_Cd)
		{
			List<DbParameter> lst = new List<DbParameter>();	
			StringBuilder sb = new StringBuilder();
		
			if( Contract_Mod_ID != null && Contract_Mod_ID > 0 )
			{
				lst.Add(Connection.GetParameter("@CONTRACT_MOD_ID", Contract_Mod_ID));
				sb.Append(" WHERE T_AR_CHARGE.CONTRACT_MOD_ID=@CONTRACT_MOD_ID");
			}
			if( Level_Unit_ID != null && Level_Unit_ID > 0 )
			{
				lst.Add(Connection.GetParameter("@LEVEL_UNIT_ID", Level_Unit_ID));
				sb.AppendFormat(" {0} T_AR_CHARGE.LEVEL_UNIT_ID=@LEVEL_UNIT_ID",
					sb.Length > 0 ? "AND" : "WHERE");
			}
			if( Ar_Invoice_ID != null && Ar_Invoice_ID > 0 )
			{
				lst.Add(Connection.GetParameter("@AR_INVOICE_ID", Ar_Invoice_ID));
				sb.AppendFormat(" {0} T_AR_CHARGE.AR_INVOICE_ID=@AR_INVOICE_ID",
					sb.Length > 0 ? "AND" : "WHERE");
			}
			if( string.IsNullOrEmpty(Charge_Type_Cd) == false )
			{
				lst.Add(Connection.GetParameter("@CHARGE_TYPE_CD", Charge_Type_Cd));
				sb.AppendFormat(" {0} T_AR_CHARGE.CHARGE_TYPE_CD=@CHARGE_TYPE_CD",
					sb.Length > 0 ? "AND" : "WHERE");
			}
			sb.Insert(0, SelectSQL);
			return Connection.GetDataTable(sb.ToString(), lst.ToArray());
		}
		#endregion		// #region Static Methods
	}
}