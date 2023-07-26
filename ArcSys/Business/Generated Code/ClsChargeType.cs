using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsChargeType : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ArcSys"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "R_CHARGE_TYPE";
		public const int PrimaryKeyCount = 1;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] { "CHARGE_TYPE_CD" };
		}

		public const string SelectSQL = @"SELECT * FROM R_CHARGE_TYPE 
				LEFT OUTER JOIN R_CHARGE_CATEGORY
				ON R_CHARGE_TYPE.CHARGE_CATEGORY_CD=R_CHARGE_CATEGORY.CHARGE_CATEGORY_CD
				LEFT OUTER JOIN R_LEVEL_UNIT
				ON R_CHARGE_TYPE.AP_LEVEL_UNIT_ID=R_LEVEL_UNIT.LEVEL_UNIT_ID
				LEFT OUTER JOIN R_LEVEL_UNIT r_lev2
				ON R_CHARGE_TYPE.AR_LEVEL_UNIT_ID=r_lev2.LEVEL_UNIT_ID ";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Charge_Type_CdMax = 10;
		public const int Create_UserMax = 30;
		public const int Modify_UserMax = 30;
		public const int Charge_Type_DscMax = 50;
		public const int Active_FlgMax = 1;
		public const int Charge_Category_CdMax = 10;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected string _Charge_Type_Cd;
		protected string _Create_User;
		protected DateTime? _Create_Dt;
		protected string _Modify_User;
		protected DateTime? _Modify_Dt;
		protected string _Charge_Type_Dsc;
		protected string _Active_Flg;
		protected string _Charge_Category_Cd;
		protected Int64? _Ap_Level_Unit_ID;
		protected Int64? _Ar_Level_Unit_ID;

		#endregion	// #region Column Fields

		#region Column Properties

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
		public string Charge_Type_Dsc
		{
			get { return _Charge_Type_Dsc; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Charge_Type_Dsc, val, false) == 0 ) return;
		
				if( val != null && val.Length > Charge_Type_DscMax )
					_Charge_Type_Dsc = val.Substring(0, (int)Charge_Type_DscMax);
				else
					_Charge_Type_Dsc = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Charge_Type_Dsc");
			}
		}
		public string Active_Flg
		{
			get { return _Active_Flg; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Active_Flg, val, false) == 0 ) return;
		
				if( val != null && val.Length > Active_FlgMax )
					_Active_Flg = val.Substring(0, (int)Active_FlgMax);
				else
					_Active_Flg = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Active_Flg");
			}
		}
		public string Charge_Category_Cd
		{
			get { return _Charge_Category_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Charge_Category_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Charge_Category_CdMax )
					_Charge_Category_Cd = val.Substring(0, (int)Charge_Category_CdMax);
				else
					_Charge_Category_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Charge_Category_Cd");
			}
		}
		public Int64? Ap_Level_Unit_ID
		{
			get { return _Ap_Level_Unit_ID; }
			set
			{
				if( _Ap_Level_Unit_ID == value ) return;
		
				_Ap_Level_Unit_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Ap_Level_Unit_ID");
			}
		}
		public Int64? Ar_Level_Unit_ID
		{
			get { return _Ar_Level_Unit_ID; }
			set
			{
				if( _Ar_Level_Unit_ID == value ) return;
		
				_Ar_Level_Unit_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Ar_Level_Unit_ID");
			}
		}

		#endregion	// #region Column Properties

		#region Foreign Key Fields

		protected ClsChargeCategory _Charge_Category;
		protected ClsLevelUnit _Ap_Level_Unit;
		protected ClsLevelUnit _Ar_Level_Unit;

		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties

		public ClsChargeCategory Charge_Category
		{
			get
			{
				if( Charge_Category_Cd == null )
					_Charge_Category = null;
				else if( _Charge_Category == null ||
					_Charge_Category.Charge_Category_Cd != Charge_Category_Cd )
					_Charge_Category = ClsChargeCategory.GetUsingKey(Charge_Category_Cd);
				return _Charge_Category;
			}
			set
			{
				if( _Charge_Category == value ) return;
		
				_Charge_Category = value;
			}
		}
		public ClsLevelUnit Ap_Level_Unit
		{
			get
			{
				if( Ap_Level_Unit_ID == null )
					_Ap_Level_Unit = null;
				else if( _Ap_Level_Unit == null ||
					_Ap_Level_Unit.Level_Unit_ID != Ap_Level_Unit_ID )
					_Ap_Level_Unit = ClsLevelUnit.GetUsingKey(Ap_Level_Unit_ID.Value);
				return _Ap_Level_Unit;
			}
			set
			{
				if( _Ap_Level_Unit == value ) return;
		
				_Ap_Level_Unit = value;
			}
		}
		public ClsLevelUnit Ar_Level_Unit
		{
			get
			{
				if( Ar_Level_Unit_ID == null )
					_Ar_Level_Unit = null;
				else if( _Ar_Level_Unit == null ||
					_Ar_Level_Unit.Level_Unit_ID != Ar_Level_Unit_ID )
					_Ar_Level_Unit = ClsLevelUnit.GetUsingKey(Ar_Level_Unit_ID.Value);
				return _Ar_Level_Unit;
			}
			set
			{
				if( _Ar_Level_Unit == value ) return;
		
				_Ar_Level_Unit = value;
			}
		}

		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsChargeType() : base() {}
		public ClsChargeType(DataRow dr) : base(dr) {}
		public ClsChargeType(ClsChargeType src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Charge_Type_Cd = null;
			Create_User = null;
			Create_Dt = null;
			Modify_User = null;
			Modify_Dt = null;
			Charge_Type_Dsc = null;
			Active_Flg = null;
			Charge_Category_Cd = null;
			Ap_Level_Unit_ID = null;
			Ar_Level_Unit_ID = null;
		}

		public void CopyFrom(ClsChargeType src)
		{
			Charge_Type_Cd = src._Charge_Type_Cd;
			Create_User = src._Create_User;
			Create_Dt = src._Create_Dt;
			Modify_User = src._Modify_User;
			Modify_Dt = src._Modify_Dt;
			Charge_Type_Dsc = src._Charge_Type_Dsc;
			Active_Flg = src._Active_Flg;
			Charge_Category_Cd = src._Charge_Category_Cd;
			Ap_Level_Unit_ID = src._Ap_Level_Unit_ID;
			Ar_Level_Unit_ID = src._Ar_Level_Unit_ID;
		}

		public override bool ReloadFromDB()
		{
			ClsChargeType tmp = ClsChargeType.GetUsingKey(Charge_Type_Cd);
			if( tmp != null ) CopyFrom(tmp);

			ResetFKs();
			OnReload();

			return ( tmp != null );
		}

		public override void ResetFKs()
		{
			_Charge_Category = null;
			_Ap_Level_Unit = null;
			_Ar_Level_Unit = null;
		}
		#endregion		// #region Init methods

		#region Insert, Update, Delete

		public override int Insert()
		{

			DbParameter[] p = new DbParameter[10];

			p[0] = Connection.GetParameter
				("@CHARGE_TYPE_CD", Charge_Type_Cd);
			p[1] = Connection.GetParameter
				("@CHARGE_TYPE_DSC", Charge_Type_Dsc);
			p[2] = Connection.GetParameter
				("@ACTIVE_FLG", Active_Flg);
			p[3] = Connection.GetParameter
				("@CHARGE_CATEGORY_CD", Charge_Category_Cd);
			p[4] = Connection.GetParameter
				("@AP_LEVEL_UNIT_ID", Ap_Level_Unit_ID);
			p[5] = Connection.GetParameter
				("@AR_LEVEL_UNIT_ID", Ar_Level_Unit_ID);
			p[6] = Connection.GetParameter
				("@CREATE_USER", Create_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Create_UserMax);
			p[7] = Connection.GetParameter
				("@CREATE_DT", Create_Dt, ParameterDirection.Output, DbType.DateTime, 0);
			p[8] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);
			p[9] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.Output, DbType.DateTime, 0);

			const string sql = @"
				INSERT INTO R_CHARGE_TYPE
					(CHARGE_TYPE_CD, CHARGE_TYPE_DSC, ACTIVE_FLG,
					CHARGE_CATEGORY_CD, AP_LEVEL_UNIT_ID, AR_LEVEL_UNIT_ID)
				VALUES
					(@CHARGE_TYPE_CD, @CHARGE_TYPE_DSC, @ACTIVE_FLG,
					@CHARGE_CATEGORY_CD, @AP_LEVEL_UNIT_ID, @AR_LEVEL_UNIT_ID)
				RETURNING
					CREATE_USER, CREATE_DT, MODIFY_USER,
					MODIFY_DT
				INTO
					@CREATE_USER, @CREATE_DT, @MODIFY_USER,
					@MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Create_User = ClsConvert.ToString(p[6].Value);
			Create_Dt = ClsConvert.ToDateTimeNullable(p[7].Value);
			Modify_User = ClsConvert.ToString(p[8].Value);
			Modify_Dt = ClsConvert.ToDateTimeNullable(p[9].Value);
			return ret;
		}
		public override int Update()
		{
			DbParameter[] p = new DbParameter[8];

			p[0] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.InputOutput, DbType.DateTime, 0);
			p[1] = Connection.GetParameter
				("@CHARGE_TYPE_DSC", Charge_Type_Dsc);
			p[2] = Connection.GetParameter
				("@ACTIVE_FLG", Active_Flg);
			p[3] = Connection.GetParameter
				("@CHARGE_CATEGORY_CD", Charge_Category_Cd);
			p[4] = Connection.GetParameter
				("@AP_LEVEL_UNIT_ID", Ap_Level_Unit_ID);
			p[5] = Connection.GetParameter
				("@AR_LEVEL_UNIT_ID", Ar_Level_Unit_ID);
			p[6] = Connection.GetParameter
				("@CHARGE_TYPE_CD", Charge_Type_Cd);
			p[7] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);

			const string sql = @"
				UPDATE R_CHARGE_TYPE SET
					MODIFY_DT = @MODIFY_DT,
					CHARGE_TYPE_DSC = @CHARGE_TYPE_DSC,
					ACTIVE_FLG = @ACTIVE_FLG,
					CHARGE_CATEGORY_CD = @CHARGE_CATEGORY_CD,
					AP_LEVEL_UNIT_ID = @AP_LEVEL_UNIT_ID,
					AR_LEVEL_UNIT_ID = @AR_LEVEL_UNIT_ID
				WHERE
					CHARGE_TYPE_CD = @CHARGE_TYPE_CD
				RETURNING
					MODIFY_USER, MODIFY_DT
				INTO
					@MODIFY_USER, @MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Modify_Dt = ClsConvert.ToDateTimeNullable(p[0].Value);
			Modify_User = ClsConvert.ToString(p[7].Value);
			return ret;
		}
		public override int Delete()
		{
			DbParameter[] p = new DbParameter[1];

			p[0] = Connection.GetParameter
				("@CHARGE_TYPE_CD", Charge_Type_Cd);

			const string sql = @"
				DELETE FROM R_CHARGE_TYPE WHERE
				CHARGE_TYPE_CD=@CHARGE_TYPE_CD";
			return Connection.RunSQL(sql, p);
		}
		#endregion		// #region Insert, Update, Delete

		#region Conversion methods

		public override void LoadFromDataReader(DbDataReader dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataReader: DataReader parameter was null");

			Charge_Type_Cd = ClsConvert.ToString(dr["CHARGE_TYPE_CD"]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER"]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT"]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER"]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT"]);
			Charge_Type_Dsc = ClsConvert.ToString(dr["CHARGE_TYPE_DSC"]);
			Active_Flg = ClsConvert.ToString(dr["ACTIVE_FLG"]);
			Charge_Category_Cd = ClsConvert.ToString(dr["CHARGE_CATEGORY_CD"]);
			Ap_Level_Unit_ID = ClsConvert.ToInt64Nullable(dr["AP_LEVEL_UNIT_ID"]);
			Ar_Level_Unit_ID = ClsConvert.ToInt64Nullable(dr["AR_LEVEL_UNIT_ID"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Charge_Type_Cd = ClsConvert.ToString(dr["CHARGE_TYPE_CD", v]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER", v]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT", v]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER", v]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT", v]);
			Charge_Type_Dsc = ClsConvert.ToString(dr["CHARGE_TYPE_DSC", v]);
			Active_Flg = ClsConvert.ToString(dr["ACTIVE_FLG", v]);
			Charge_Category_Cd = ClsConvert.ToString(dr["CHARGE_CATEGORY_CD", v]);
			Ap_Level_Unit_ID = ClsConvert.ToInt64Nullable(dr["AP_LEVEL_UNIT_ID", v]);
			Ar_Level_Unit_ID = ClsConvert.ToInt64Nullable(dr["AR_LEVEL_UNIT_ID", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["CHARGE_TYPE_CD"] = ClsConvert.ToDbObject(Charge_Type_Cd);
			dr["CREATE_USER"] = ClsConvert.ToDbObject(Create_User);
			dr["CREATE_DT"] = ClsConvert.ToDbObject(Create_Dt);
			dr["MODIFY_USER"] = ClsConvert.ToDbObject(Modify_User);
			dr["MODIFY_DT"] = ClsConvert.ToDbObject(Modify_Dt);
			dr["CHARGE_TYPE_DSC"] = ClsConvert.ToDbObject(Charge_Type_Dsc);
			dr["ACTIVE_FLG"] = ClsConvert.ToDbObject(Active_Flg);
			dr["CHARGE_CATEGORY_CD"] = ClsConvert.ToDbObject(Charge_Category_Cd);
			dr["AP_LEVEL_UNIT_ID"] = ClsConvert.ToDbObject(Ap_Level_Unit_ID);
			dr["AR_LEVEL_UNIT_ID"] = ClsConvert.ToDbObject(Ar_Level_Unit_ID);
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

		public static ClsChargeType GetUsingKey(string Charge_Type_Cd)
		{
			object[] vals = new object[] {Charge_Type_Cd};
			DataRow dr = Connection.GetDataRowUsingKey
				(TableName, GetPrimaryKeys(), vals);
			return ( dr == null ) ? null : new ClsChargeType(dr);
		}
		public static DataTable GetAll(string Charge_Category_Cd, Int64? Ap_Level_Unit_ID,
			Int64? Ar_Level_Unit_ID)
		{
			List<DbParameter> lst = new List<DbParameter>();	
			StringBuilder sb = new StringBuilder();
		
			if( string.IsNullOrEmpty(Charge_Category_Cd) == false )
			{
				lst.Add(Connection.GetParameter("@CHARGE_CATEGORY_CD", Charge_Category_Cd));
				sb.Append(" WHERE R_CHARGE_TYPE.CHARGE_CATEGORY_CD=@CHARGE_CATEGORY_CD");
			}
			if( Ap_Level_Unit_ID != null && Ap_Level_Unit_ID > 0 )
			{
				lst.Add(Connection.GetParameter("@AP_LEVEL_UNIT_ID", Ap_Level_Unit_ID));
				sb.AppendFormat(" {0} R_CHARGE_TYPE.AP_LEVEL_UNIT_ID=@AP_LEVEL_UNIT_ID",
					sb.Length > 0 ? "AND" : "WHERE");
			}
			if( Ar_Level_Unit_ID != null && Ar_Level_Unit_ID > 0 )
			{
				lst.Add(Connection.GetParameter("@AR_LEVEL_UNIT_ID", Ar_Level_Unit_ID));
				sb.AppendFormat(" {0} R_CHARGE_TYPE.AR_LEVEL_UNIT_ID=@AR_LEVEL_UNIT_ID",
					sb.Length > 0 ? "AND" : "WHERE");
			}
			sb.Insert(0, SelectSQL);
			return Connection.GetDataTable(sb.ToString(), lst.ToArray());
		}
		#endregion		// #region Static Methods
	}
}