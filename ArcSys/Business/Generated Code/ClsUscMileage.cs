using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsUscMileage : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ArcSys"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "T_USC_MILEAGE";
		public const int PrimaryKeyCount = 1;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] { "USC_MILEAGE_ID" };
		}

		public const string SelectSQL = @"SELECT * FROM T_USC_MILEAGE 
				LEFT OUTER JOIN T_CONTRACT_MOD
				ON T_USC_MILEAGE.CONTRACT_MOD_ID=T_CONTRACT_MOD.CONTRACT_MOD_ID ";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Create_UserMax = 30;
		public const int Modify_UserMax = 30;
		public const int Active_FlgMax = 1;
		public const int Flatbed_FlgMax = 1;
		public const int Double_Drop_FlgMax = 1;
		public const int Oog_FlgMax = 1;
		public const int Oto_FlgMax = 1;
		public const int RfpMax = 10;
		public const int ServiceMax = 30;
		public const int CountryMax = 100;
		public const int Mileage_BandMax = 50;
		public const int CommodityMax = 30;
		public const int Container_TypeMax = 30;
		public const int Container_SizeMax = 100;
		public const int Carrier_CdMax = 10;
		public const int Unit_TypeMax = 100;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected Int64? _Usc_Mileage_ID;
		protected string _Create_User;
		protected DateTime? _Create_Dt;
		protected string _Modify_User;
		protected DateTime? _Modify_Dt;
		protected string _Active_Flg;
		protected string _Flatbed_Flg;
		protected string _Double_Drop_Flg;
		protected string _Oog_Flg;
		protected string _Oto_Flg;
		protected string _Rfp;
		protected string _Service;
		protected string _Country;
		protected string _Mileage_Band;
		protected string _Commodity;
		protected string _Container_Type;
		protected string _Container_Size;
		protected string _Carrier_Cd;
		protected decimal? _Rate_Amt;
		protected string _Unit_Type;
		protected DateTime? _Effective_Dt;
		protected DateTime? _Expire_Dt;
		protected Int64? _Contract_Mod_ID;

		#endregion	// #region Column Fields

		#region Column Properties

		public Int64? Usc_Mileage_ID
		{
			get { return _Usc_Mileage_ID; }
			set
			{
				if( _Usc_Mileage_ID == value ) return;
		
				_Usc_Mileage_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Usc_Mileage_ID");
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
		public string Flatbed_Flg
		{
			get { return _Flatbed_Flg; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Flatbed_Flg, val, false) == 0 ) return;
		
				if( val != null && val.Length > Flatbed_FlgMax )
					_Flatbed_Flg = val.Substring(0, (int)Flatbed_FlgMax);
				else
					_Flatbed_Flg = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Flatbed_Flg");
			}
		}
		public string Double_Drop_Flg
		{
			get { return _Double_Drop_Flg; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Double_Drop_Flg, val, false) == 0 ) return;
		
				if( val != null && val.Length > Double_Drop_FlgMax )
					_Double_Drop_Flg = val.Substring(0, (int)Double_Drop_FlgMax);
				else
					_Double_Drop_Flg = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Double_Drop_Flg");
			}
		}
		public string Oog_Flg
		{
			get { return _Oog_Flg; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Oog_Flg, val, false) == 0 ) return;
		
				if( val != null && val.Length > Oog_FlgMax )
					_Oog_Flg = val.Substring(0, (int)Oog_FlgMax);
				else
					_Oog_Flg = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Oog_Flg");
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
		public string Country
		{
			get { return _Country; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Country, val, false) == 0 ) return;
		
				if( val != null && val.Length > CountryMax )
					_Country = val.Substring(0, (int)CountryMax);
				else
					_Country = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Country");
			}
		}
		public string Mileage_Band
		{
			get { return _Mileage_Band; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Mileage_Band, val, false) == 0 ) return;
		
				if( val != null && val.Length > Mileage_BandMax )
					_Mileage_Band = val.Substring(0, (int)Mileage_BandMax);
				else
					_Mileage_Band = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Mileage_Band");
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

		public ClsUscMileage() : base() {}
		public ClsUscMileage(DataRow dr) : base(dr) {}
		public ClsUscMileage(ClsUscMileage src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Usc_Mileage_ID = null;
			Create_User = null;
			Create_Dt = null;
			Modify_User = null;
			Modify_Dt = null;
			Active_Flg = null;
			Flatbed_Flg = null;
			Double_Drop_Flg = null;
			Oog_Flg = null;
			Oto_Flg = null;
			Rfp = null;
			Service = null;
			Country = null;
			Mileage_Band = null;
			Commodity = null;
			Container_Type = null;
			Container_Size = null;
			Carrier_Cd = null;
			Rate_Amt = null;
			Unit_Type = null;
			Effective_Dt = null;
			Expire_Dt = null;
			Contract_Mod_ID = null;
		}

		public void CopyFrom(ClsUscMileage src)
		{
			Usc_Mileage_ID = src._Usc_Mileage_ID;
			Create_User = src._Create_User;
			Create_Dt = src._Create_Dt;
			Modify_User = src._Modify_User;
			Modify_Dt = src._Modify_Dt;
			Active_Flg = src._Active_Flg;
			Flatbed_Flg = src._Flatbed_Flg;
			Double_Drop_Flg = src._Double_Drop_Flg;
			Oog_Flg = src._Oog_Flg;
			Oto_Flg = src._Oto_Flg;
			Rfp = src._Rfp;
			Service = src._Service;
			Country = src._Country;
			Mileage_Band = src._Mileage_Band;
			Commodity = src._Commodity;
			Container_Type = src._Container_Type;
			Container_Size = src._Container_Size;
			Carrier_Cd = src._Carrier_Cd;
			Rate_Amt = src._Rate_Amt;
			Unit_Type = src._Unit_Type;
			Effective_Dt = src._Effective_Dt;
			Expire_Dt = src._Expire_Dt;
			Contract_Mod_ID = src._Contract_Mod_ID;
		}

		public override bool ReloadFromDB()
		{
			ClsUscMileage tmp = ClsUscMileage.GetUsingKey(Usc_Mileage_ID.Value);
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

			DbParameter[] p = new DbParameter[23];

			p[0] = Connection.GetParameter
				("@ACTIVE_FLG", Active_Flg);
			p[1] = Connection.GetParameter
				("@FLATBED_FLG", Flatbed_Flg);
			p[2] = Connection.GetParameter
				("@DOUBLE_DROP_FLG", Double_Drop_Flg);
			p[3] = Connection.GetParameter
				("@OOG_FLG", Oog_Flg);
			p[4] = Connection.GetParameter
				("@OTO_FLG", Oto_Flg);
			p[5] = Connection.GetParameter
				("@RFP", Rfp);
			p[6] = Connection.GetParameter
				("@SERVICE", Service);
			p[7] = Connection.GetParameter
				("@COUNTRY", Country);
			p[8] = Connection.GetParameter
				("@MILEAGE_BAND", Mileage_Band);
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
				("@EFFECTIVE_DT", Effective_Dt);
			p[16] = Connection.GetParameter
				("@EXPIRE_DT", Expire_Dt);
			p[17] = Connection.GetParameter
				("@CONTRACT_MOD_ID", Contract_Mod_ID);
			p[18] = Connection.GetParameter
				("@USC_MILEAGE_ID", Usc_Mileage_ID, ParameterDirection.Output, DbType.Int64, 0);
			p[19] = Connection.GetParameter
				("@CREATE_USER", Create_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Create_UserMax);
			p[20] = Connection.GetParameter
				("@CREATE_DT", Create_Dt, ParameterDirection.Output, DbType.DateTime, 0);
			p[21] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);
			p[22] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.Output, DbType.DateTime, 0);

			const string sql = @"
				INSERT INTO T_USC_MILEAGE
					(USC_MILEAGE_ID, ACTIVE_FLG, FLATBED_FLG,
					DOUBLE_DROP_FLG, OOG_FLG, OTO_FLG,
					RFP, SERVICE, COUNTRY,
					MILEAGE_BAND, COMMODITY, CONTAINER_TYPE,
					CONTAINER_SIZE, CARRIER_CD, RATE_AMT,
					UNIT_TYPE, EFFECTIVE_DT, EXPIRE_DT,
					CONTRACT_MOD_ID)
				VALUES
					(USC_MILEAGE_ID_SEQ.NEXTVAL, @ACTIVE_FLG, @FLATBED_FLG,
					@DOUBLE_DROP_FLG, @OOG_FLG, @OTO_FLG,
					@RFP, @SERVICE, @COUNTRY,
					@MILEAGE_BAND, @COMMODITY, @CONTAINER_TYPE,
					@CONTAINER_SIZE, @CARRIER_CD, @RATE_AMT,
					@UNIT_TYPE, @EFFECTIVE_DT, @EXPIRE_DT,
					@CONTRACT_MOD_ID)
				RETURNING
					USC_MILEAGE_ID, CREATE_USER, CREATE_DT,
					MODIFY_USER, MODIFY_DT
				INTO
					@USC_MILEAGE_ID, @CREATE_USER, @CREATE_DT,
					@MODIFY_USER, @MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Usc_Mileage_ID = ClsConvert.ToInt64Nullable(p[18].Value);
			Create_User = ClsConvert.ToString(p[19].Value);
			Create_Dt = ClsConvert.ToDateTimeNullable(p[20].Value);
			Modify_User = ClsConvert.ToString(p[21].Value);
			Modify_Dt = ClsConvert.ToDateTimeNullable(p[22].Value);
			return ret;
		}
		public override int Update()
		{
			DbParameter[] p = new DbParameter[21];

			p[0] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.InputOutput, DbType.DateTime, 0);
			p[1] = Connection.GetParameter
				("@ACTIVE_FLG", Active_Flg);
			p[2] = Connection.GetParameter
				("@FLATBED_FLG", Flatbed_Flg);
			p[3] = Connection.GetParameter
				("@DOUBLE_DROP_FLG", Double_Drop_Flg);
			p[4] = Connection.GetParameter
				("@OOG_FLG", Oog_Flg);
			p[5] = Connection.GetParameter
				("@OTO_FLG", Oto_Flg);
			p[6] = Connection.GetParameter
				("@RFP", Rfp);
			p[7] = Connection.GetParameter
				("@SERVICE", Service);
			p[8] = Connection.GetParameter
				("@COUNTRY", Country);
			p[9] = Connection.GetParameter
				("@MILEAGE_BAND", Mileage_Band);
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
				("@EFFECTIVE_DT", Effective_Dt);
			p[17] = Connection.GetParameter
				("@EXPIRE_DT", Expire_Dt);
			p[18] = Connection.GetParameter
				("@CONTRACT_MOD_ID", Contract_Mod_ID);
			p[19] = Connection.GetParameter
				("@USC_MILEAGE_ID", Usc_Mileage_ID);
			p[20] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);

			const string sql = @"
				UPDATE T_USC_MILEAGE SET
					MODIFY_DT = @MODIFY_DT,
					ACTIVE_FLG = @ACTIVE_FLG,
					FLATBED_FLG = @FLATBED_FLG,
					DOUBLE_DROP_FLG = @DOUBLE_DROP_FLG,
					OOG_FLG = @OOG_FLG,
					OTO_FLG = @OTO_FLG,
					RFP = @RFP,
					SERVICE = @SERVICE,
					COUNTRY = @COUNTRY,
					MILEAGE_BAND = @MILEAGE_BAND,
					COMMODITY = @COMMODITY,
					CONTAINER_TYPE = @CONTAINER_TYPE,
					CONTAINER_SIZE = @CONTAINER_SIZE,
					CARRIER_CD = @CARRIER_CD,
					RATE_AMT = @RATE_AMT,
					UNIT_TYPE = @UNIT_TYPE,
					EFFECTIVE_DT = @EFFECTIVE_DT,
					EXPIRE_DT = @EXPIRE_DT,
					CONTRACT_MOD_ID = @CONTRACT_MOD_ID
				WHERE
					USC_MILEAGE_ID = @USC_MILEAGE_ID
				RETURNING
					MODIFY_USER, MODIFY_DT
				INTO
					@MODIFY_USER, @MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Modify_Dt = ClsConvert.ToDateTimeNullable(p[0].Value);
			Modify_User = ClsConvert.ToString(p[20].Value);
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

			Usc_Mileage_ID = ClsConvert.ToInt64Nullable(dr["USC_MILEAGE_ID"]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER"]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT"]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER"]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT"]);
			Active_Flg = ClsConvert.ToString(dr["ACTIVE_FLG"]);
			Flatbed_Flg = ClsConvert.ToString(dr["FLATBED_FLG"]);
			Double_Drop_Flg = ClsConvert.ToString(dr["DOUBLE_DROP_FLG"]);
			Oog_Flg = ClsConvert.ToString(dr["OOG_FLG"]);
			Oto_Flg = ClsConvert.ToString(dr["OTO_FLG"]);
			Rfp = ClsConvert.ToString(dr["RFP"]);
			Service = ClsConvert.ToString(dr["SERVICE"]);
			Country = ClsConvert.ToString(dr["COUNTRY"]);
			Mileage_Band = ClsConvert.ToString(dr["MILEAGE_BAND"]);
			Commodity = ClsConvert.ToString(dr["COMMODITY"]);
			Container_Type = ClsConvert.ToString(dr["CONTAINER_TYPE"]);
			Container_Size = ClsConvert.ToString(dr["CONTAINER_SIZE"]);
			Carrier_Cd = ClsConvert.ToString(dr["CARRIER_CD"]);
			Rate_Amt = ClsConvert.ToDecimalNullable(dr["RATE_AMT"]);
			Unit_Type = ClsConvert.ToString(dr["UNIT_TYPE"]);
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

			Usc_Mileage_ID = ClsConvert.ToInt64Nullable(dr["USC_MILEAGE_ID", v]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER", v]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT", v]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER", v]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT", v]);
			Active_Flg = ClsConvert.ToString(dr["ACTIVE_FLG", v]);
			Flatbed_Flg = ClsConvert.ToString(dr["FLATBED_FLG", v]);
			Double_Drop_Flg = ClsConvert.ToString(dr["DOUBLE_DROP_FLG", v]);
			Oog_Flg = ClsConvert.ToString(dr["OOG_FLG", v]);
			Oto_Flg = ClsConvert.ToString(dr["OTO_FLG", v]);
			Rfp = ClsConvert.ToString(dr["RFP", v]);
			Service = ClsConvert.ToString(dr["SERVICE", v]);
			Country = ClsConvert.ToString(dr["COUNTRY", v]);
			Mileage_Band = ClsConvert.ToString(dr["MILEAGE_BAND", v]);
			Commodity = ClsConvert.ToString(dr["COMMODITY", v]);
			Container_Type = ClsConvert.ToString(dr["CONTAINER_TYPE", v]);
			Container_Size = ClsConvert.ToString(dr["CONTAINER_SIZE", v]);
			Carrier_Cd = ClsConvert.ToString(dr["CARRIER_CD", v]);
			Rate_Amt = ClsConvert.ToDecimalNullable(dr["RATE_AMT", v]);
			Unit_Type = ClsConvert.ToString(dr["UNIT_TYPE", v]);
			Effective_Dt = ClsConvert.ToDateTimeNullable(dr["EFFECTIVE_DT", v]);
			Expire_Dt = ClsConvert.ToDateTimeNullable(dr["EXPIRE_DT", v]);
			Contract_Mod_ID = ClsConvert.ToInt64Nullable(dr["CONTRACT_MOD_ID", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["USC_MILEAGE_ID"] = ClsConvert.ToDbObject(Usc_Mileage_ID);
			dr["CREATE_USER"] = ClsConvert.ToDbObject(Create_User);
			dr["CREATE_DT"] = ClsConvert.ToDbObject(Create_Dt);
			dr["MODIFY_USER"] = ClsConvert.ToDbObject(Modify_User);
			dr["MODIFY_DT"] = ClsConvert.ToDbObject(Modify_Dt);
			dr["ACTIVE_FLG"] = ClsConvert.ToDbObject(Active_Flg);
			dr["FLATBED_FLG"] = ClsConvert.ToDbObject(Flatbed_Flg);
			dr["DOUBLE_DROP_FLG"] = ClsConvert.ToDbObject(Double_Drop_Flg);
			dr["OOG_FLG"] = ClsConvert.ToDbObject(Oog_Flg);
			dr["OTO_FLG"] = ClsConvert.ToDbObject(Oto_Flg);
			dr["RFP"] = ClsConvert.ToDbObject(Rfp);
			dr["SERVICE"] = ClsConvert.ToDbObject(Service);
			dr["COUNTRY"] = ClsConvert.ToDbObject(Country);
			dr["MILEAGE_BAND"] = ClsConvert.ToDbObject(Mileage_Band);
			dr["COMMODITY"] = ClsConvert.ToDbObject(Commodity);
			dr["CONTAINER_TYPE"] = ClsConvert.ToDbObject(Container_Type);
			dr["CONTAINER_SIZE"] = ClsConvert.ToDbObject(Container_Size);
			dr["CARRIER_CD"] = ClsConvert.ToDbObject(Carrier_Cd);
			dr["RATE_AMT"] = ClsConvert.ToDbObject(Rate_Amt);
			dr["UNIT_TYPE"] = ClsConvert.ToDbObject(Unit_Type);
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

		public static ClsUscMileage GetUsingKey(Int64 Usc_Mileage_ID)
		{
			object[] vals = new object[] {Usc_Mileage_ID};
			DataRow dr = Connection.GetDataRowUsingKey
				(TableName, GetPrimaryKeys(), vals);
			return ( dr == null ) ? null : new ClsUscMileage(dr);
		}
		public static DataTable GetAll(Int64? Contract_Mod_ID)
		{
			List<DbParameter> lst = new List<DbParameter>();	
			StringBuilder sb = new StringBuilder();
		
			if( Contract_Mod_ID != null && Contract_Mod_ID > 0 )
			{
				lst.Add(Connection.GetParameter("@CONTRACT_MOD_ID", Contract_Mod_ID));
				sb.Append(" WHERE T_USC_MILEAGE.CONTRACT_MOD_ID=@CONTRACT_MOD_ID");
			}
			sb.Insert(0, SelectSQL);
			return Connection.GetDataTable(sb.ToString(), lst.ToArray());
		}
		#endregion		// #region Static Methods
	}
}