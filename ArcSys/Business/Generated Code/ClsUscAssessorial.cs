using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsUscAssessorial : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ArcSys"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "T_USC_ASSESSORIAL";
		public const int PrimaryKeyCount = 1;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] { "USC_ASSESSORIAL_ID" };
		}

		public const string SelectSQL = @"SELECT * FROM T_USC_ASSESSORIAL 
				LEFT OUTER JOIN T_CONTRACT_MOD
				ON T_USC_ASSESSORIAL.CONTRACT_MOD_ID=T_CONTRACT_MOD.CONTRACT_MOD_ID ";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Create_UserMax = 30;
		public const int Modify_UserMax = 30;
		public const int Active_FlgMax = 1;
		public const int Oto_FlgMax = 1;
		public const int RfpMax = 10;
		public const int ServiceMax = 10;
		public const int Assessorial_TypeMax = 100;
		public const int RouteMax = 300;
		public const int OriginMax = 100;
		public const int DestinationMax = 100;
		public const int CommodityMax = 100;
		public const int Container_TypeMax = 100;
		public const int Container_SizeMax = 100;
		public const int Carrier_CdMax = 30;
		public const int Unit_TypeMax = 100;
		public const int ViaMax = 100;
		public const int Value_TypeMax = 10;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected Int64? _Usc_Assessorial_ID;
		protected string _Create_User;
		protected DateTime? _Create_Dt;
		protected string _Modify_User;
		protected DateTime? _Modify_Dt;
		protected string _Active_Flg;
		protected string _Oto_Flg;
		protected string _Rfp;
		protected string _Service;
		protected string _Assessorial_Type;
		protected string _Route;
		protected string _Origin;
		protected string _Destination;
		protected string _Commodity;
		protected string _Container_Type;
		protected string _Container_Size;
		protected string _Carrier_Cd;
		protected string _Unit_Type;
		protected string _Via;
		protected string _Value_Type;
		protected decimal? _Rate_Amt;
		protected DateTime? _Effective_Dt;
		protected DateTime? _Expire_Dt;
		protected Int64? _Contract_Mod_ID;

		#endregion	// #region Column Fields

		#region Column Properties

		public Int64? Usc_Assessorial_ID
		{
			get { return _Usc_Assessorial_ID; }
			set
			{
				if( _Usc_Assessorial_ID == value ) return;
		
				_Usc_Assessorial_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Usc_Assessorial_ID");
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
		public string Rfp
		{
			get { return _Rfp; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Rfp, val, false) == 0 ) return;
		
				if( val != null && val.Length > RfpMax )
					_Rfp = val.Substring(0, (int)RfpMax);
				else
					_Rfp = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Rfp");
			}
		}
		public string Service
		{
			get { return _Service; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Service, val, false) == 0 ) return;
		
				if( val != null && val.Length > ServiceMax )
					_Service = val.Substring(0, (int)ServiceMax);
				else
					_Service = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Service");
			}
		}
		public string Assessorial_Type
		{
			get { return _Assessorial_Type; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Assessorial_Type, val, false) == 0 ) return;
		
				if( val != null && val.Length > Assessorial_TypeMax )
					_Assessorial_Type = val.Substring(0, (int)Assessorial_TypeMax);
				else
					_Assessorial_Type = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Assessorial_Type");
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
		public string Origin
		{
			get { return _Origin; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Origin, val, false) == 0 ) return;
		
				if( val != null && val.Length > OriginMax )
					_Origin = val.Substring(0, (int)OriginMax);
				else
					_Origin = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Origin");
			}
		}
		public string Destination
		{
			get { return _Destination; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Destination, val, false) == 0 ) return;
		
				if( val != null && val.Length > DestinationMax )
					_Destination = val.Substring(0, (int)DestinationMax);
				else
					_Destination = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Destination");
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
		public string Container_Type
		{
			get { return _Container_Type; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Container_Type, val, false) == 0 ) return;
		
				if( val != null && val.Length > Container_TypeMax )
					_Container_Type = val.Substring(0, (int)Container_TypeMax);
				else
					_Container_Type = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Container_Type");
			}
		}
		public string Container_Size
		{
			get { return _Container_Size; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Container_Size, val, false) == 0 ) return;
		
				if( val != null && val.Length > Container_SizeMax )
					_Container_Size = val.Substring(0, (int)Container_SizeMax);
				else
					_Container_Size = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Container_Size");
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
		public string Unit_Type
		{
			get { return _Unit_Type; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Unit_Type, val, false) == 0 ) return;
		
				if( val != null && val.Length > Unit_TypeMax )
					_Unit_Type = val.Substring(0, (int)Unit_TypeMax);
				else
					_Unit_Type = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Unit_Type");
			}
		}
		public string Via
		{
			get { return _Via; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Via, val, false) == 0 ) return;
		
				if( val != null && val.Length > ViaMax )
					_Via = val.Substring(0, (int)ViaMax);
				else
					_Via = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Via");
			}
		}
		public string Value_Type
		{
			get { return _Value_Type; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Value_Type, val, false) == 0 ) return;
		
				if( val != null && val.Length > Value_TypeMax )
					_Value_Type = val.Substring(0, (int)Value_TypeMax);
				else
					_Value_Type = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Value_Type");
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

		public ClsUscAssessorial() : base() {}
		public ClsUscAssessorial(DataRow dr) : base(dr) {}
		public ClsUscAssessorial(ClsUscAssessorial src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Usc_Assessorial_ID = null;
			Create_User = null;
			Create_Dt = null;
			Modify_User = null;
			Modify_Dt = null;
			Active_Flg = null;
			Oto_Flg = null;
			Rfp = null;
			Service = null;
			Assessorial_Type = null;
			Route = null;
			Origin = null;
			Destination = null;
			Commodity = null;
			Container_Type = null;
			Container_Size = null;
			Carrier_Cd = null;
			Unit_Type = null;
			Via = null;
			Value_Type = null;
			Rate_Amt = null;
			Effective_Dt = null;
			Expire_Dt = null;
			Contract_Mod_ID = null;
		}

		public void CopyFrom(ClsUscAssessorial src)
		{
			Usc_Assessorial_ID = src._Usc_Assessorial_ID;
			Create_User = src._Create_User;
			Create_Dt = src._Create_Dt;
			Modify_User = src._Modify_User;
			Modify_Dt = src._Modify_Dt;
			Active_Flg = src._Active_Flg;
			Oto_Flg = src._Oto_Flg;
			Rfp = src._Rfp;
			Service = src._Service;
			Assessorial_Type = src._Assessorial_Type;
			Route = src._Route;
			Origin = src._Origin;
			Destination = src._Destination;
			Commodity = src._Commodity;
			Container_Type = src._Container_Type;
			Container_Size = src._Container_Size;
			Carrier_Cd = src._Carrier_Cd;
			Unit_Type = src._Unit_Type;
			Via = src._Via;
			Value_Type = src._Value_Type;
			Rate_Amt = src._Rate_Amt;
			Effective_Dt = src._Effective_Dt;
			Expire_Dt = src._Expire_Dt;
			Contract_Mod_ID = src._Contract_Mod_ID;
		}

		public override bool ReloadFromDB()
		{
			ClsUscAssessorial tmp = ClsUscAssessorial.GetUsingKey(Usc_Assessorial_ID.Value);
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

			DbParameter[] p = new DbParameter[24];

			p[0] = Connection.GetParameter
				("@ACTIVE_FLG", Active_Flg);
			p[1] = Connection.GetParameter
				("@OTO_FLG", Oto_Flg);
			p[2] = Connection.GetParameter
				("@RFP", Rfp);
			p[3] = Connection.GetParameter
				("@SERVICE", Service);
			p[4] = Connection.GetParameter
				("@ASSESSORIAL_TYPE", Assessorial_Type);
			p[5] = Connection.GetParameter
				("@ROUTE", Route);
			p[6] = Connection.GetParameter
				("@ORIGIN", Origin);
			p[7] = Connection.GetParameter
				("@DESTINATION", Destination);
			p[8] = Connection.GetParameter
				("@COMMODITY", Commodity);
			p[9] = Connection.GetParameter
				("@CONTAINER_TYPE", Container_Type);
			p[10] = Connection.GetParameter
				("@CONTAINER_SIZE", Container_Size);
			p[11] = Connection.GetParameter
				("@CARRIER_CD", Carrier_Cd);
			p[12] = Connection.GetParameter
				("@UNIT_TYPE", Unit_Type);
			p[13] = Connection.GetParameter
				("@VIA", Via);
			p[14] = Connection.GetParameter
				("@VALUE_TYPE", Value_Type);
			p[15] = Connection.GetParameter
				("@RATE_AMT", Rate_Amt);
			p[16] = Connection.GetParameter
				("@EFFECTIVE_DT", Effective_Dt);
			p[17] = Connection.GetParameter
				("@EXPIRE_DT", Expire_Dt);
			p[18] = Connection.GetParameter
				("@CONTRACT_MOD_ID", Contract_Mod_ID);
			p[19] = Connection.GetParameter
				("@USC_ASSESSORIAL_ID", Usc_Assessorial_ID, ParameterDirection.Output, DbType.Int64, 0);
			p[20] = Connection.GetParameter
				("@CREATE_USER", Create_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Create_UserMax);
			p[21] = Connection.GetParameter
				("@CREATE_DT", Create_Dt, ParameterDirection.Output, DbType.DateTime, 0);
			p[22] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);
			p[23] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.Output, DbType.DateTime, 0);

			const string sql = @"
				INSERT INTO T_USC_ASSESSORIAL
					(USC_ASSESSORIAL_ID, ACTIVE_FLG, OTO_FLG,
					RFP, SERVICE, ASSESSORIAL_TYPE,
					ROUTE, ORIGIN, DESTINATION,
					COMMODITY, CONTAINER_TYPE, CONTAINER_SIZE,
					CARRIER_CD, UNIT_TYPE, VIA,
					VALUE_TYPE, RATE_AMT, EFFECTIVE_DT,
					EXPIRE_DT, CONTRACT_MOD_ID)
				VALUES
					(USC_ASSESSORIAL_ID_SEQ.NEXTVAL, @ACTIVE_FLG, @OTO_FLG,
					@RFP, @SERVICE, @ASSESSORIAL_TYPE,
					@ROUTE, @ORIGIN, @DESTINATION,
					@COMMODITY, @CONTAINER_TYPE, @CONTAINER_SIZE,
					@CARRIER_CD, @UNIT_TYPE, @VIA,
					@VALUE_TYPE, @RATE_AMT, @EFFECTIVE_DT,
					@EXPIRE_DT, @CONTRACT_MOD_ID)
				RETURNING
					USC_ASSESSORIAL_ID, CREATE_USER, CREATE_DT,
					MODIFY_USER, MODIFY_DT
				INTO
					@USC_ASSESSORIAL_ID, @CREATE_USER, @CREATE_DT,
					@MODIFY_USER, @MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Usc_Assessorial_ID = ClsConvert.ToInt64Nullable(p[19].Value);
			Create_User = ClsConvert.ToString(p[20].Value);
			Create_Dt = ClsConvert.ToDateTimeNullable(p[21].Value);
			Modify_User = ClsConvert.ToString(p[22].Value);
			Modify_Dt = ClsConvert.ToDateTimeNullable(p[23].Value);
			return ret;
		}
		public override int Update()
		{
			DbParameter[] p = new DbParameter[22];

			p[0] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.InputOutput, DbType.DateTime, 0);
			p[1] = Connection.GetParameter
				("@ACTIVE_FLG", Active_Flg);
			p[2] = Connection.GetParameter
				("@OTO_FLG", Oto_Flg);
			p[3] = Connection.GetParameter
				("@RFP", Rfp);
			p[4] = Connection.GetParameter
				("@SERVICE", Service);
			p[5] = Connection.GetParameter
				("@ASSESSORIAL_TYPE", Assessorial_Type);
			p[6] = Connection.GetParameter
				("@ROUTE", Route);
			p[7] = Connection.GetParameter
				("@ORIGIN", Origin);
			p[8] = Connection.GetParameter
				("@DESTINATION", Destination);
			p[9] = Connection.GetParameter
				("@COMMODITY", Commodity);
			p[10] = Connection.GetParameter
				("@CONTAINER_TYPE", Container_Type);
			p[11] = Connection.GetParameter
				("@CONTAINER_SIZE", Container_Size);
			p[12] = Connection.GetParameter
				("@CARRIER_CD", Carrier_Cd);
			p[13] = Connection.GetParameter
				("@UNIT_TYPE", Unit_Type);
			p[14] = Connection.GetParameter
				("@VIA", Via);
			p[15] = Connection.GetParameter
				("@VALUE_TYPE", Value_Type);
			p[16] = Connection.GetParameter
				("@RATE_AMT", Rate_Amt);
			p[17] = Connection.GetParameter
				("@EFFECTIVE_DT", Effective_Dt);
			p[18] = Connection.GetParameter
				("@EXPIRE_DT", Expire_Dt);
			p[19] = Connection.GetParameter
				("@CONTRACT_MOD_ID", Contract_Mod_ID);
			p[20] = Connection.GetParameter
				("@USC_ASSESSORIAL_ID", Usc_Assessorial_ID);
			p[21] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);

			const string sql = @"
				UPDATE T_USC_ASSESSORIAL SET
					MODIFY_DT = @MODIFY_DT,
					ACTIVE_FLG = @ACTIVE_FLG,
					OTO_FLG = @OTO_FLG,
					RFP = @RFP,
					SERVICE = @SERVICE,
					ASSESSORIAL_TYPE = @ASSESSORIAL_TYPE,
					ROUTE = @ROUTE,
					ORIGIN = @ORIGIN,
					DESTINATION = @DESTINATION,
					COMMODITY = @COMMODITY,
					CONTAINER_TYPE = @CONTAINER_TYPE,
					CONTAINER_SIZE = @CONTAINER_SIZE,
					CARRIER_CD = @CARRIER_CD,
					UNIT_TYPE = @UNIT_TYPE,
					VIA = @VIA,
					VALUE_TYPE = @VALUE_TYPE,
					RATE_AMT = @RATE_AMT,
					EFFECTIVE_DT = @EFFECTIVE_DT,
					EXPIRE_DT = @EXPIRE_DT,
					CONTRACT_MOD_ID = @CONTRACT_MOD_ID
				WHERE
					USC_ASSESSORIAL_ID = @USC_ASSESSORIAL_ID
				RETURNING
					MODIFY_USER, MODIFY_DT
				INTO
					@MODIFY_USER, @MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Modify_Dt = ClsConvert.ToDateTimeNullable(p[0].Value);
			Modify_User = ClsConvert.ToString(p[21].Value);
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

			Usc_Assessorial_ID = ClsConvert.ToInt64Nullable(dr["USC_ASSESSORIAL_ID"]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER"]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT"]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER"]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT"]);
			Active_Flg = ClsConvert.ToString(dr["ACTIVE_FLG"]);
			Oto_Flg = ClsConvert.ToString(dr["OTO_FLG"]);
			Rfp = ClsConvert.ToString(dr["RFP"]);
			Service = ClsConvert.ToString(dr["SERVICE"]);
			Assessorial_Type = ClsConvert.ToString(dr["ASSESSORIAL_TYPE"]);
			Route = ClsConvert.ToString(dr["ROUTE"]);
			Origin = ClsConvert.ToString(dr["ORIGIN"]);
			Destination = ClsConvert.ToString(dr["DESTINATION"]);
			Commodity = ClsConvert.ToString(dr["COMMODITY"]);
			Container_Type = ClsConvert.ToString(dr["CONTAINER_TYPE"]);
			Container_Size = ClsConvert.ToString(dr["CONTAINER_SIZE"]);
			Carrier_Cd = ClsConvert.ToString(dr["CARRIER_CD"]);
			Unit_Type = ClsConvert.ToString(dr["UNIT_TYPE"]);
			Via = ClsConvert.ToString(dr["VIA"]);
			Value_Type = ClsConvert.ToString(dr["VALUE_TYPE"]);
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

			Usc_Assessorial_ID = ClsConvert.ToInt64Nullable(dr["USC_ASSESSORIAL_ID", v]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER", v]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT", v]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER", v]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT", v]);
			Active_Flg = ClsConvert.ToString(dr["ACTIVE_FLG", v]);
			Oto_Flg = ClsConvert.ToString(dr["OTO_FLG", v]);
			Rfp = ClsConvert.ToString(dr["RFP", v]);
			Service = ClsConvert.ToString(dr["SERVICE", v]);
			Assessorial_Type = ClsConvert.ToString(dr["ASSESSORIAL_TYPE", v]);
			Route = ClsConvert.ToString(dr["ROUTE", v]);
			Origin = ClsConvert.ToString(dr["ORIGIN", v]);
			Destination = ClsConvert.ToString(dr["DESTINATION", v]);
			Commodity = ClsConvert.ToString(dr["COMMODITY", v]);
			Container_Type = ClsConvert.ToString(dr["CONTAINER_TYPE", v]);
			Container_Size = ClsConvert.ToString(dr["CONTAINER_SIZE", v]);
			Carrier_Cd = ClsConvert.ToString(dr["CARRIER_CD", v]);
			Unit_Type = ClsConvert.ToString(dr["UNIT_TYPE", v]);
			Via = ClsConvert.ToString(dr["VIA", v]);
			Value_Type = ClsConvert.ToString(dr["VALUE_TYPE", v]);
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

			dr["USC_ASSESSORIAL_ID"] = ClsConvert.ToDbObject(Usc_Assessorial_ID);
			dr["CREATE_USER"] = ClsConvert.ToDbObject(Create_User);
			dr["CREATE_DT"] = ClsConvert.ToDbObject(Create_Dt);
			dr["MODIFY_USER"] = ClsConvert.ToDbObject(Modify_User);
			dr["MODIFY_DT"] = ClsConvert.ToDbObject(Modify_Dt);
			dr["ACTIVE_FLG"] = ClsConvert.ToDbObject(Active_Flg);
			dr["OTO_FLG"] = ClsConvert.ToDbObject(Oto_Flg);
			dr["RFP"] = ClsConvert.ToDbObject(Rfp);
			dr["SERVICE"] = ClsConvert.ToDbObject(Service);
			dr["ASSESSORIAL_TYPE"] = ClsConvert.ToDbObject(Assessorial_Type);
			dr["ROUTE"] = ClsConvert.ToDbObject(Route);
			dr["ORIGIN"] = ClsConvert.ToDbObject(Origin);
			dr["DESTINATION"] = ClsConvert.ToDbObject(Destination);
			dr["COMMODITY"] = ClsConvert.ToDbObject(Commodity);
			dr["CONTAINER_TYPE"] = ClsConvert.ToDbObject(Container_Type);
			dr["CONTAINER_SIZE"] = ClsConvert.ToDbObject(Container_Size);
			dr["CARRIER_CD"] = ClsConvert.ToDbObject(Carrier_Cd);
			dr["UNIT_TYPE"] = ClsConvert.ToDbObject(Unit_Type);
			dr["VIA"] = ClsConvert.ToDbObject(Via);
			dr["VALUE_TYPE"] = ClsConvert.ToDbObject(Value_Type);
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

		public static ClsUscAssessorial GetUsingKey(Int64 Usc_Assessorial_ID)
		{
			object[] vals = new object[] {Usc_Assessorial_ID};
			DataRow dr = Connection.GetDataRowUsingKey
				(TableName, GetPrimaryKeys(), vals);
			return ( dr == null ) ? null : new ClsUscAssessorial(dr);
		}
		public static DataTable GetAll(Int64? Contract_Mod_ID)
		{
			List<DbParameter> lst = new List<DbParameter>();	
			StringBuilder sb = new StringBuilder();
		
			if( Contract_Mod_ID != null && Contract_Mod_ID > 0 )
			{
				lst.Add(Connection.GetParameter("@CONTRACT_MOD_ID", Contract_Mod_ID));
				sb.Append(" WHERE T_USC_ASSESSORIAL.CONTRACT_MOD_ID=@CONTRACT_MOD_ID");
			}
			sb.Insert(0, SelectSQL);
			return Connection.GetDataTable(sb.ToString(), lst.ToArray());
		}
		#endregion		// #region Static Methods
	}
}