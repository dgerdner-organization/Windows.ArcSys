using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsUscOceanRoute : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ArcSys"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "T_USC_OCEAN_ROUTE";
		public const int PrimaryKeyCount = 1;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] { "USC_OCEAN_ROUTE_ID" };
		}

		public const string SelectSQL = @"SELECT * FROM T_USC_OCEAN_ROUTE 
				LEFT OUTER JOIN T_CONTRACT_MOD
				ON T_USC_OCEAN_ROUTE.CONTRACT_MOD_ID=T_CONTRACT_MOD.CONTRACT_MOD_ID ";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Create_UserMax = 30;
		public const int Modify_UserMax = 30;
		public const int Active_FlgMax = 1;
		public const int Oto_FlgMax = 1;
		public const int RouteMax = 100;
		public const int From_ToMax = 200;
		public const int CommodityMax = 50;
		public const int Carrier_CdMax = 30;
		public const int Rate_TypeMax = 40;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected Int64? _Usc_Ocean_Route_ID;
		protected string _Create_User;
		protected DateTime? _Create_Dt;
		protected string _Modify_User;
		protected DateTime? _Modify_Dt;
		protected string _Active_Flg;
		protected string _Oto_Flg;
		protected string _Route;
		protected string _From_To;
		protected string _Commodity;
		protected string _Carrier_Cd;
		protected string _Rate_Type;
		protected decimal? _Rate_Amt;
		protected DateTime? _Effective_Dt;
		protected DateTime? _Expire_Dt;
		protected Int64? _Contract_Mod_ID;

		#endregion	// #region Column Fields

		#region Column Properties

		public Int64? Usc_Ocean_Route_ID
		{
			get { return _Usc_Ocean_Route_ID; }
			set
			{
				if( _Usc_Ocean_Route_ID == value ) return;
		
				_Usc_Ocean_Route_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Usc_Ocean_Route_ID");
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
		public string Oto_Flg
		{
			get { return _Oto_Flg; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Oto_Flg, val, false) == 0 ) return;
		
				if( val != null && val.Length > Oto_FlgMax )
					_Oto_Flg = val.Substring(0, (int)Oto_FlgMax);
				else
					_Oto_Flg = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Oto_Flg");
			}
		}
		public string Route
		{
			get { return _Route; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Route, val, false) == 0 ) return;
		
				if( val != null && val.Length > RouteMax )
					_Route = val.Substring(0, (int)RouteMax);
				else
					_Route = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Route");
			}
		}
		public string From_To
		{
			get { return _From_To; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_From_To, val, false) == 0 ) return;
		
				if( val != null && val.Length > From_ToMax )
					_From_To = val.Substring(0, (int)From_ToMax);
				else
					_From_To = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("From_To");
			}
		}
		public string Commodity
		{
			get { return _Commodity; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Commodity, val, false) == 0 ) return;
		
				if( val != null && val.Length > CommodityMax )
					_Commodity = val.Substring(0, (int)CommodityMax);
				else
					_Commodity = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Commodity");
			}
		}
		public string Carrier_Cd
		{
			get { return _Carrier_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Carrier_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Carrier_CdMax )
					_Carrier_Cd = val.Substring(0, (int)Carrier_CdMax);
				else
					_Carrier_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Carrier_Cd");
			}
		}
		public string Rate_Type
		{
			get { return _Rate_Type; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Rate_Type, val, false) == 0 ) return;
		
				if( val != null && val.Length > Rate_TypeMax )
					_Rate_Type = val.Substring(0, (int)Rate_TypeMax);
				else
					_Rate_Type = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Rate_Type");
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
		public DateTime? Effective_Dt
		{
			get { return _Effective_Dt; }
			set
			{
				DateTime? val = ( value != null )
					? (DateTime?)value.Value.Date : null;
		
				if( _Effective_Dt == val ) return;
		
				_Effective_Dt = val;
				_IsDirty = true;
				NotifyPropertyChanged("Effective_Dt");
			}
		}
		public DateTime? Expire_Dt
		{
			get { return _Expire_Dt; }
			set
			{
				DateTime? val = ( value != null )
					? (DateTime?)value.Value.Date : null;
		
				if( _Expire_Dt == val ) return;
		
				_Expire_Dt = val;
				_IsDirty = true;
				NotifyPropertyChanged("Expire_Dt");
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

		#endregion	// #region Column Properties

		#region Foreign Key Fields

		protected ClsContractMod _Contract_Mod;

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

		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsUscOceanRoute() : base() {}
		public ClsUscOceanRoute(DataRow dr) : base(dr) {}
		public ClsUscOceanRoute(ClsUscOceanRoute src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Usc_Ocean_Route_ID = null;
			Create_User = null;
			Create_Dt = null;
			Modify_User = null;
			Modify_Dt = null;
			Active_Flg = null;
			Oto_Flg = null;
			Route = null;
			From_To = null;
			Commodity = null;
			Carrier_Cd = null;
			Rate_Type = null;
			Rate_Amt = null;
			Effective_Dt = null;
			Expire_Dt = null;
			Contract_Mod_ID = null;
		}

		public void CopyFrom(ClsUscOceanRoute src)
		{
			Usc_Ocean_Route_ID = src._Usc_Ocean_Route_ID;
			Create_User = src._Create_User;
			Create_Dt = src._Create_Dt;
			Modify_User = src._Modify_User;
			Modify_Dt = src._Modify_Dt;
			Active_Flg = src._Active_Flg;
			Oto_Flg = src._Oto_Flg;
			Route = src._Route;
			From_To = src._From_To;
			Commodity = src._Commodity;
			Carrier_Cd = src._Carrier_Cd;
			Rate_Type = src._Rate_Type;
			Rate_Amt = src._Rate_Amt;
			Effective_Dt = src._Effective_Dt;
			Expire_Dt = src._Expire_Dt;
			Contract_Mod_ID = src._Contract_Mod_ID;
		}

		public override bool ReloadFromDB()
		{
			ClsUscOceanRoute tmp = ClsUscOceanRoute.GetUsingKey(Usc_Ocean_Route_ID.Value);
			if( tmp != null ) CopyFrom(tmp);

			ResetFKs();
			OnReload();

			return ( tmp != null );
		}

		public override void ResetFKs()
		{
			_Contract_Mod = null;
		}
		#endregion		// #region Init methods

		#region Insert, Update, Delete

		public override int Insert()
		{

			DbParameter[] p = new DbParameter[16];

			p[0] = Connection.GetParameter
				("@ACTIVE_FLG", Active_Flg);
			p[1] = Connection.GetParameter
				("@OTO_FLG", Oto_Flg);
			p[2] = Connection.GetParameter
				("@ROUTE", Route);
			p[3] = Connection.GetParameter
				("@FROM_TO", From_To);
			p[4] = Connection.GetParameter
				("@COMMODITY", Commodity);
			p[5] = Connection.GetParameter
				("@CARRIER_CD", Carrier_Cd);
			p[6] = Connection.GetParameter
				("@RATE_TYPE", Rate_Type);
			p[7] = Connection.GetParameter
				("@RATE_AMT", Rate_Amt);
			p[8] = Connection.GetParameter
				("@EFFECTIVE_DT", Effective_Dt);
			p[9] = Connection.GetParameter
				("@EXPIRE_DT", Expire_Dt);
			p[10] = Connection.GetParameter
				("@CONTRACT_MOD_ID", Contract_Mod_ID);
			p[11] = Connection.GetParameter
				("@USC_OCEAN_ROUTE_ID", Usc_Ocean_Route_ID, ParameterDirection.Output, DbType.Int64, 0);
			p[12] = Connection.GetParameter
				("@CREATE_USER", Create_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Create_UserMax);
			p[13] = Connection.GetParameter
				("@CREATE_DT", Create_Dt, ParameterDirection.Output, DbType.DateTime, 0);
			p[14] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);
			p[15] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.Output, DbType.DateTime, 0);

			const string sql = @"
				INSERT INTO T_USC_OCEAN_ROUTE
					(USC_OCEAN_ROUTE_ID, ACTIVE_FLG, OTO_FLG,
					ROUTE, FROM_TO, COMMODITY,
					CARRIER_CD, RATE_TYPE, RATE_AMT,
					EFFECTIVE_DT, EXPIRE_DT, CONTRACT_MOD_ID)
				VALUES
					(USC_OCEAN_ROUTE_ID_SEQ.NEXTVAL, @ACTIVE_FLG, @OTO_FLG,
					@ROUTE, @FROM_TO, @COMMODITY,
					@CARRIER_CD, @RATE_TYPE, @RATE_AMT,
					@EFFECTIVE_DT, @EXPIRE_DT, @CONTRACT_MOD_ID)
				RETURNING
					USC_OCEAN_ROUTE_ID, CREATE_USER, CREATE_DT,
					MODIFY_USER, MODIFY_DT
				INTO
					@USC_OCEAN_ROUTE_ID, @CREATE_USER, @CREATE_DT,
					@MODIFY_USER, @MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Usc_Ocean_Route_ID = ClsConvert.ToInt64Nullable(p[11].Value);
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
				("@MODIFY_DT", Modify_Dt, ParameterDirection.InputOutput, DbType.DateTime, 0);
			p[1] = Connection.GetParameter
				("@ACTIVE_FLG", Active_Flg);
			p[2] = Connection.GetParameter
				("@OTO_FLG", Oto_Flg);
			p[3] = Connection.GetParameter
				("@ROUTE", Route);
			p[4] = Connection.GetParameter
				("@FROM_TO", From_To);
			p[5] = Connection.GetParameter
				("@COMMODITY", Commodity);
			p[6] = Connection.GetParameter
				("@CARRIER_CD", Carrier_Cd);
			p[7] = Connection.GetParameter
				("@RATE_TYPE", Rate_Type);
			p[8] = Connection.GetParameter
				("@RATE_AMT", Rate_Amt);
			p[9] = Connection.GetParameter
				("@EFFECTIVE_DT", Effective_Dt);
			p[10] = Connection.GetParameter
				("@EXPIRE_DT", Expire_Dt);
			p[11] = Connection.GetParameter
				("@CONTRACT_MOD_ID", Contract_Mod_ID);
			p[12] = Connection.GetParameter
				("@USC_OCEAN_ROUTE_ID", Usc_Ocean_Route_ID);
			p[13] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);

			const string sql = @"
				UPDATE T_USC_OCEAN_ROUTE SET
					MODIFY_DT = @MODIFY_DT,
					ACTIVE_FLG = @ACTIVE_FLG,
					OTO_FLG = @OTO_FLG,
					ROUTE = @ROUTE,
					FROM_TO = @FROM_TO,
					COMMODITY = @COMMODITY,
					CARRIER_CD = @CARRIER_CD,
					RATE_TYPE = @RATE_TYPE,
					RATE_AMT = @RATE_AMT,
					EFFECTIVE_DT = @EFFECTIVE_DT,
					EXPIRE_DT = @EXPIRE_DT,
					CONTRACT_MOD_ID = @CONTRACT_MOD_ID
				WHERE
					USC_OCEAN_ROUTE_ID = @USC_OCEAN_ROUTE_ID
				RETURNING
					MODIFY_USER, MODIFY_DT
				INTO
					@MODIFY_USER, @MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Modify_Dt = ClsConvert.ToDateTimeNullable(p[0].Value);
			Modify_User = ClsConvert.ToString(p[13].Value);
			return ret;
		}
		public override int Delete()
		{
			DbParameter[] p = new DbParameter[0];

			if( p.Length == 0 )
				throw new Exception
					("Cannot delete rows from this table");

			return -1;
		}
		#endregion		// #region Insert, Update, Delete

		#region Conversion methods

		public override void LoadFromDataReader(DbDataReader dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataReader: DataReader parameter was null");

			Usc_Ocean_Route_ID = ClsConvert.ToInt64Nullable(dr["USC_OCEAN_ROUTE_ID"]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER"]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT"]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER"]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT"]);
			Active_Flg = ClsConvert.ToString(dr["ACTIVE_FLG"]);
			Oto_Flg = ClsConvert.ToString(dr["OTO_FLG"]);
			Route = ClsConvert.ToString(dr["ROUTE"]);
			From_To = ClsConvert.ToString(dr["FROM_TO"]);
			Commodity = ClsConvert.ToString(dr["COMMODITY"]);
			Carrier_Cd = ClsConvert.ToString(dr["CARRIER_CD"]);
			Rate_Type = ClsConvert.ToString(dr["RATE_TYPE"]);
			Rate_Amt = ClsConvert.ToDecimalNullable(dr["RATE_AMT"]);
			Effective_Dt = ClsConvert.ToDateTimeNullable(dr["EFFECTIVE_DT"]);
			Expire_Dt = ClsConvert.ToDateTimeNullable(dr["EXPIRE_DT"]);
			Contract_Mod_ID = ClsConvert.ToInt64Nullable(dr["CONTRACT_MOD_ID"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Usc_Ocean_Route_ID = ClsConvert.ToInt64Nullable(dr["USC_OCEAN_ROUTE_ID", v]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER", v]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT", v]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER", v]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT", v]);
			Active_Flg = ClsConvert.ToString(dr["ACTIVE_FLG", v]);
			Oto_Flg = ClsConvert.ToString(dr["OTO_FLG", v]);
			Route = ClsConvert.ToString(dr["ROUTE", v]);
			From_To = ClsConvert.ToString(dr["FROM_TO", v]);
			Commodity = ClsConvert.ToString(dr["COMMODITY", v]);
			Carrier_Cd = ClsConvert.ToString(dr["CARRIER_CD", v]);
			Rate_Type = ClsConvert.ToString(dr["RATE_TYPE", v]);
			Rate_Amt = ClsConvert.ToDecimalNullable(dr["RATE_AMT", v]);
			Effective_Dt = ClsConvert.ToDateTimeNullable(dr["EFFECTIVE_DT", v]);
			Expire_Dt = ClsConvert.ToDateTimeNullable(dr["EXPIRE_DT", v]);
			Contract_Mod_ID = ClsConvert.ToInt64Nullable(dr["CONTRACT_MOD_ID", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["USC_OCEAN_ROUTE_ID"] = ClsConvert.ToDbObject(Usc_Ocean_Route_ID);
			dr["CREATE_USER"] = ClsConvert.ToDbObject(Create_User);
			dr["CREATE_DT"] = ClsConvert.ToDbObject(Create_Dt);
			dr["MODIFY_USER"] = ClsConvert.ToDbObject(Modify_User);
			dr["MODIFY_DT"] = ClsConvert.ToDbObject(Modify_Dt);
			dr["ACTIVE_FLG"] = ClsConvert.ToDbObject(Active_Flg);
			dr["OTO_FLG"] = ClsConvert.ToDbObject(Oto_Flg);
			dr["ROUTE"] = ClsConvert.ToDbObject(Route);
			dr["FROM_TO"] = ClsConvert.ToDbObject(From_To);
			dr["COMMODITY"] = ClsConvert.ToDbObject(Commodity);
			dr["CARRIER_CD"] = ClsConvert.ToDbObject(Carrier_Cd);
			dr["RATE_TYPE"] = ClsConvert.ToDbObject(Rate_Type);
			dr["RATE_AMT"] = ClsConvert.ToDbObject(Rate_Amt);
			dr["EFFECTIVE_DT"] = ClsConvert.ToDbObject(Effective_Dt);
			dr["EXPIRE_DT"] = ClsConvert.ToDbObject(Expire_Dt);
			dr["CONTRACT_MOD_ID"] = ClsConvert.ToDbObject(Contract_Mod_ID);
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

		public static ClsUscOceanRoute GetUsingKey(Int64 Usc_Ocean_Route_ID)
		{
			object[] vals = new object[] {Usc_Ocean_Route_ID};
			DataRow dr = Connection.GetDataRowUsingKey
				(TableName, GetPrimaryKeys(), vals);
			return ( dr == null ) ? null : new ClsUscOceanRoute(dr);
		}
		public static DataTable GetAll(Int64? Contract_Mod_ID)
		{
			List<DbParameter> lst = new List<DbParameter>();	
			StringBuilder sb = new StringBuilder();
		
			if( Contract_Mod_ID != null && Contract_Mod_ID > 0 )
			{
				lst.Add(Connection.GetParameter("@CONTRACT_MOD_ID", Contract_Mod_ID));
				sb.Append(" WHERE T_USC_OCEAN_ROUTE.CONTRACT_MOD_ID=@CONTRACT_MOD_ID");
			}
			sb.Insert(0, SelectSQL);
			return Connection.GetDataTable(sb.ToString(), lst.ToArray());
		}
		#endregion		// #region Static Methods
	}
}