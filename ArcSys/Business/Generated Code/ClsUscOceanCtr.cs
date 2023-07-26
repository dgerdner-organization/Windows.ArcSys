using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsUscOceanCtr : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ArcSys"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "T_USC_OCEAN_CTR";
		public const int PrimaryKeyCount = 1;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] { "USC_OCEAN_CTR_ID" };
		}

		public const string SelectSQL = @"SELECT * FROM T_USC_OCEAN_CTR 
				LEFT OUTER JOIN T_CONTRACT_MOD
				ON T_USC_OCEAN_CTR.CONTRACT_MOD_ID=T_CONTRACT_MOD.CONTRACT_MOD_ID ";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Create_UserMax = 30;
		public const int Modify_UserMax = 30;
		public const int Active_FlgMax = 1;
		public const int Oto_FlgMax = 1;
		public const int RfpMax = 10;
		public const int Ocean_TypeMax = 40;
		public const int ServiceMax = 10;
		public const int RouteMax = 100;
		public const int DirectionMax = 30;
		public const int OriginMax = 100;
		public const int DestinationMax = 100;
		public const int CommodityMax = 30;
		public const int Container_TypeMax = 30;
		public const int Container_SizeMax = 30;
		public const int Carrier_CdMax = 30;
		public const int Unit_TypeMax = 40;
		public const int Bv_RankMax = 20;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected Int64? _Usc_Ocean_Ctr_ID;
		protected string _Create_User;
		protected DateTime? _Create_Dt;
		protected string _Modify_User;
		protected DateTime? _Modify_Dt;
		protected string _Active_Flg;
		protected string _Oto_Flg;
		protected string _Rfp;
		protected string _Ocean_Type;
		protected string _Service;
		protected string _Route;
		protected string _Direction;
		protected string _Origin;
		protected string _Destination;
		protected string _Commodity;
		protected string _Container_Type;
		protected string _Container_Size;
		protected string _Carrier_Cd;
		protected decimal? _Rate_Amt;
		protected string _Unit_Type;
		protected string _Bv_Rank;
		protected DateTime? _Effective_Dt;
		protected DateTime? _Expire_Dt;
		protected Int64? _Contract_Mod_ID;

		#endregion	// #region Column Fields

		#region Column Properties

		public Int64? Usc_Ocean_Ctr_ID
		{
			get { return _Usc_Ocean_Ctr_ID; }
			set
			{
				if( _Usc_Ocean_Ctr_ID == value ) return;
		
				_Usc_Ocean_Ctr_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Usc_Ocean_Ctr_ID");
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
		public string Ocean_Type
		{
			get { return _Ocean_Type; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Ocean_Type, val, false) == 0 ) return;
		
				if( val != null && val.Length > Ocean_TypeMax )
					_Ocean_Type = val.Substring(0, (int)Ocean_TypeMax);
				else
					_Ocean_Type = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Ocean_Type");
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
		public string Direction
		{
			get { return _Direction; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Direction, val, false) == 0 ) return;
		
				if( val != null && val.Length > DirectionMax )
					_Direction = val.Substring(0, (int)DirectionMax);
				else
					_Direction = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Direction");
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
		public string Bv_Rank
		{
			get { return _Bv_Rank; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Bv_Rank, val, false) == 0 ) return;
		
				if( val != null && val.Length > Bv_RankMax )
					_Bv_Rank = val.Substring(0, (int)Bv_RankMax);
				else
					_Bv_Rank = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Bv_Rank");
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

		public ClsUscOceanCtr() : base() {}
		public ClsUscOceanCtr(DataRow dr) : base(dr) {}
		public ClsUscOceanCtr(ClsUscOceanCtr src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Usc_Ocean_Ctr_ID = null;
			Create_User = null;
			Create_Dt = null;
			Modify_User = null;
			Modify_Dt = null;
			Active_Flg = null;
			Oto_Flg = null;
			Rfp = null;
			Ocean_Type = null;
			Service = null;
			Route = null;
			Direction = null;
			Origin = null;
			Destination = null;
			Commodity = null;
			Container_Type = null;
			Container_Size = null;
			Carrier_Cd = null;
			Rate_Amt = null;
			Unit_Type = null;
			Bv_Rank = null;
			Effective_Dt = null;
			Expire_Dt = null;
			Contract_Mod_ID = null;
		}

		public void CopyFrom(ClsUscOceanCtr src)
		{
			Usc_Ocean_Ctr_ID = src._Usc_Ocean_Ctr_ID;
			Create_User = src._Create_User;
			Create_Dt = src._Create_Dt;
			Modify_User = src._Modify_User;
			Modify_Dt = src._Modify_Dt;
			Active_Flg = src._Active_Flg;
			Oto_Flg = src._Oto_Flg;
			Rfp = src._Rfp;
			Ocean_Type = src._Ocean_Type;
			Service = src._Service;
			Route = src._Route;
			Direction = src._Direction;
			Origin = src._Origin;
			Destination = src._Destination;
			Commodity = src._Commodity;
			Container_Type = src._Container_Type;
			Container_Size = src._Container_Size;
			Carrier_Cd = src._Carrier_Cd;
			Rate_Amt = src._Rate_Amt;
			Unit_Type = src._Unit_Type;
			Bv_Rank = src._Bv_Rank;
			Effective_Dt = src._Effective_Dt;
			Expire_Dt = src._Expire_Dt;
			Contract_Mod_ID = src._Contract_Mod_ID;
		}

		public override bool ReloadFromDB()
		{
			ClsUscOceanCtr tmp = ClsUscOceanCtr.GetUsingKey(Usc_Ocean_Ctr_ID.Value);
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
				("@OCEAN_TYPE", Ocean_Type);
			p[4] = Connection.GetParameter
				("@SERVICE", Service);
			p[5] = Connection.GetParameter
				("@ROUTE", Route);
			p[6] = Connection.GetParameter
				("@DIRECTION", Direction);
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
				("@RATE_AMT", Rate_Amt);
			p[14] = Connection.GetParameter
				("@UNIT_TYPE", Unit_Type);
			p[15] = Connection.GetParameter
				("@BV_RANK", Bv_Rank);
			p[16] = Connection.GetParameter
				("@EFFECTIVE_DT", Effective_Dt);
			p[17] = Connection.GetParameter
				("@EXPIRE_DT", Expire_Dt);
			p[18] = Connection.GetParameter
				("@CONTRACT_MOD_ID", Contract_Mod_ID);
			p[19] = Connection.GetParameter
				("@USC_OCEAN_CTR_ID", Usc_Ocean_Ctr_ID, ParameterDirection.Output, DbType.Int64, 0);
			p[20] = Connection.GetParameter
				("@CREATE_USER", Create_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Create_UserMax);
			p[21] = Connection.GetParameter
				("@CREATE_DT", Create_Dt, ParameterDirection.Output, DbType.DateTime, 0);
			p[22] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);
			p[23] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.Output, DbType.DateTime, 0);

			const string sql = @"
				INSERT INTO T_USC_OCEAN_CTR
					(USC_OCEAN_CTR_ID, ACTIVE_FLG, OTO_FLG,
					RFP, OCEAN_TYPE, SERVICE,
					ROUTE, DIRECTION, ORIGIN,
					DESTINATION, COMMODITY, CONTAINER_TYPE,
					CONTAINER_SIZE, CARRIER_CD, RATE_AMT,
					UNIT_TYPE, BV_RANK, EFFECTIVE_DT,
					EXPIRE_DT, CONTRACT_MOD_ID)
				VALUES
					(USC_OCEAN_CTR_ID_SEQ.NEXTVAL, @ACTIVE_FLG, @OTO_FLG,
					@RFP, @OCEAN_TYPE, @SERVICE,
					@ROUTE, @DIRECTION, @ORIGIN,
					@DESTINATION, @COMMODITY, @CONTAINER_TYPE,
					@CONTAINER_SIZE, @CARRIER_CD, @RATE_AMT,
					@UNIT_TYPE, @BV_RANK, @EFFECTIVE_DT,
					@EXPIRE_DT, @CONTRACT_MOD_ID)
				RETURNING
					USC_OCEAN_CTR_ID, CREATE_USER, CREATE_DT,
					MODIFY_USER, MODIFY_DT
				INTO
					@USC_OCEAN_CTR_ID, @CREATE_USER, @CREATE_DT,
					@MODIFY_USER, @MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Usc_Ocean_Ctr_ID = ClsConvert.ToInt64Nullable(p[19].Value);
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
				("@OCEAN_TYPE", Ocean_Type);
			p[5] = Connection.GetParameter
				("@SERVICE", Service);
			p[6] = Connection.GetParameter
				("@ROUTE", Route);
			p[7] = Connection.GetParameter
				("@DIRECTION", Direction);
			p[8] = Connection.GetParameter
				("@ORIGIN", Origin);
			p[9] = Connection.GetParameter
				("@DESTINATION", Destination);
			p[10] = Connection.GetParameter
				("@COMMODITY", Commodity);
			p[11] = Connection.GetParameter
				("@CONTAINER_TYPE", Container_Type);
			p[12] = Connection.GetParameter
				("@CONTAINER_SIZE", Container_Size);
			p[13] = Connection.GetParameter
				("@CARRIER_CD", Carrier_Cd);
			p[14] = Connection.GetParameter
				("@RATE_AMT", Rate_Amt);
			p[15] = Connection.GetParameter
				("@UNIT_TYPE", Unit_Type);
			p[16] = Connection.GetParameter
				("@BV_RANK", Bv_Rank);
			p[17] = Connection.GetParameter
				("@EFFECTIVE_DT", Effective_Dt);
			p[18] = Connection.GetParameter
				("@EXPIRE_DT", Expire_Dt);
			p[19] = Connection.GetParameter
				("@CONTRACT_MOD_ID", Contract_Mod_ID);
			p[20] = Connection.GetParameter
				("@USC_OCEAN_CTR_ID", Usc_Ocean_Ctr_ID);
			p[21] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);

			const string sql = @"
				UPDATE T_USC_OCEAN_CTR SET
					MODIFY_DT = @MODIFY_DT,
					ACTIVE_FLG = @ACTIVE_FLG,
					OTO_FLG = @OTO_FLG,
					RFP = @RFP,
					OCEAN_TYPE = @OCEAN_TYPE,
					SERVICE = @SERVICE,
					ROUTE = @ROUTE,
					DIRECTION = @DIRECTION,
					ORIGIN = @ORIGIN,
					DESTINATION = @DESTINATION,
					COMMODITY = @COMMODITY,
					CONTAINER_TYPE = @CONTAINER_TYPE,
					CONTAINER_SIZE = @CONTAINER_SIZE,
					CARRIER_CD = @CARRIER_CD,
					RATE_AMT = @RATE_AMT,
					UNIT_TYPE = @UNIT_TYPE,
					BV_RANK = @BV_RANK,
					EFFECTIVE_DT = @EFFECTIVE_DT,
					EXPIRE_DT = @EXPIRE_DT,
					CONTRACT_MOD_ID = @CONTRACT_MOD_ID
				WHERE
					USC_OCEAN_CTR_ID = @USC_OCEAN_CTR_ID
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

			Usc_Ocean_Ctr_ID = ClsConvert.ToInt64Nullable(dr["USC_OCEAN_CTR_ID"]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER"]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT"]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER"]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT"]);
			Active_Flg = ClsConvert.ToString(dr["ACTIVE_FLG"]);
			Oto_Flg = ClsConvert.ToString(dr["OTO_FLG"]);
			Rfp = ClsConvert.ToString(dr["RFP"]);
			Ocean_Type = ClsConvert.ToString(dr["OCEAN_TYPE"]);
			Service = ClsConvert.ToString(dr["SERVICE"]);
			Route = ClsConvert.ToString(dr["ROUTE"]);
			Direction = ClsConvert.ToString(dr["DIRECTION"]);
			Origin = ClsConvert.ToString(dr["ORIGIN"]);
			Destination = ClsConvert.ToString(dr["DESTINATION"]);
			Commodity = ClsConvert.ToString(dr["COMMODITY"]);
			Container_Type = ClsConvert.ToString(dr["CONTAINER_TYPE"]);
			Container_Size = ClsConvert.ToString(dr["CONTAINER_SIZE"]);
			Carrier_Cd = ClsConvert.ToString(dr["CARRIER_CD"]);
			Rate_Amt = ClsConvert.ToDecimalNullable(dr["RATE_AMT"]);
			Unit_Type = ClsConvert.ToString(dr["UNIT_TYPE"]);
			Bv_Rank = ClsConvert.ToString(dr["BV_RANK"]);
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

			Usc_Ocean_Ctr_ID = ClsConvert.ToInt64Nullable(dr["USC_OCEAN_CTR_ID", v]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER", v]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT", v]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER", v]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT", v]);
			Active_Flg = ClsConvert.ToString(dr["ACTIVE_FLG", v]);
			Oto_Flg = ClsConvert.ToString(dr["OTO_FLG", v]);
			Rfp = ClsConvert.ToString(dr["RFP", v]);
			Ocean_Type = ClsConvert.ToString(dr["OCEAN_TYPE", v]);
			Service = ClsConvert.ToString(dr["SERVICE", v]);
			Route = ClsConvert.ToString(dr["ROUTE", v]);
			Direction = ClsConvert.ToString(dr["DIRECTION", v]);
			Origin = ClsConvert.ToString(dr["ORIGIN", v]);
			Destination = ClsConvert.ToString(dr["DESTINATION", v]);
			Commodity = ClsConvert.ToString(dr["COMMODITY", v]);
			Container_Type = ClsConvert.ToString(dr["CONTAINER_TYPE", v]);
			Container_Size = ClsConvert.ToString(dr["CONTAINER_SIZE", v]);
			Carrier_Cd = ClsConvert.ToString(dr["CARRIER_CD", v]);
			Rate_Amt = ClsConvert.ToDecimalNullable(dr["RATE_AMT", v]);
			Unit_Type = ClsConvert.ToString(dr["UNIT_TYPE", v]);
			Bv_Rank = ClsConvert.ToString(dr["BV_RANK", v]);
			Effective_Dt = ClsConvert.ToDateTimeNullable(dr["EFFECTIVE_DT", v]);
			Expire_Dt = ClsConvert.ToDateTimeNullable(dr["EXPIRE_DT", v]);
			Contract_Mod_ID = ClsConvert.ToInt64Nullable(dr["CONTRACT_MOD_ID", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["USC_OCEAN_CTR_ID"] = ClsConvert.ToDbObject(Usc_Ocean_Ctr_ID);
			dr["CREATE_USER"] = ClsConvert.ToDbObject(Create_User);
			dr["CREATE_DT"] = ClsConvert.ToDbObject(Create_Dt);
			dr["MODIFY_USER"] = ClsConvert.ToDbObject(Modify_User);
			dr["MODIFY_DT"] = ClsConvert.ToDbObject(Modify_Dt);
			dr["ACTIVE_FLG"] = ClsConvert.ToDbObject(Active_Flg);
			dr["OTO_FLG"] = ClsConvert.ToDbObject(Oto_Flg);
			dr["RFP"] = ClsConvert.ToDbObject(Rfp);
			dr["OCEAN_TYPE"] = ClsConvert.ToDbObject(Ocean_Type);
			dr["SERVICE"] = ClsConvert.ToDbObject(Service);
			dr["ROUTE"] = ClsConvert.ToDbObject(Route);
			dr["DIRECTION"] = ClsConvert.ToDbObject(Direction);
			dr["ORIGIN"] = ClsConvert.ToDbObject(Origin);
			dr["DESTINATION"] = ClsConvert.ToDbObject(Destination);
			dr["COMMODITY"] = ClsConvert.ToDbObject(Commodity);
			dr["CONTAINER_TYPE"] = ClsConvert.ToDbObject(Container_Type);
			dr["CONTAINER_SIZE"] = ClsConvert.ToDbObject(Container_Size);
			dr["CARRIER_CD"] = ClsConvert.ToDbObject(Carrier_Cd);
			dr["RATE_AMT"] = ClsConvert.ToDbObject(Rate_Amt);
			dr["UNIT_TYPE"] = ClsConvert.ToDbObject(Unit_Type);
			dr["BV_RANK"] = ClsConvert.ToDbObject(Bv_Rank);
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

		public static ClsUscOceanCtr GetUsingKey(Int64 Usc_Ocean_Ctr_ID)
		{
			object[] vals = new object[] {Usc_Ocean_Ctr_ID};
			DataRow dr = Connection.GetDataRowUsingKey
				(TableName, GetPrimaryKeys(), vals);
			return ( dr == null ) ? null : new ClsUscOceanCtr(dr);
		}
		public static DataTable GetAll(Int64? Contract_Mod_ID)
		{
			List<DbParameter> lst = new List<DbParameter>();	
			StringBuilder sb = new StringBuilder();
		
			if( Contract_Mod_ID != null && Contract_Mod_ID > 0 )
			{
				lst.Add(Connection.GetParameter("@CONTRACT_MOD_ID", Contract_Mod_ID));
				sb.Append(" WHERE T_USC_OCEAN_CTR.CONTRACT_MOD_ID=@CONTRACT_MOD_ID");
			}
			sb.Insert(0, SelectSQL);
			return Connection.GetDataTable(sb.ToString(), lst.ToArray());
		}
		#endregion		// #region Static Methods
	}
}