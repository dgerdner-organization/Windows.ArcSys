using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsUscInlandBb : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ArcSys"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "T_USC_INLAND_BB";
		public const int PrimaryKeyCount = 1;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] { "USC_INLAND_BB_ID" };
		}

		public const string SelectSQL = @"SELECT * FROM T_USC_INLAND_BB 
				LEFT OUTER JOIN T_CONTRACT_MOD
				ON T_USC_INLAND_BB.CONTRACT_MOD_ID=T_CONTRACT_MOD.CONTRACT_MOD_ID ";

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
		public const int Inland_TypeMax = 30;
		public const int ServiceMax = 10;
		public const int RegionMax = 30;
		public const int CountryMax = 100;
		public const int PointMax = 100;
		public const int PortMax = 100;
		public const int CommodityMax = 30;
		public const int ContainerMax = 30;
		public const int Unit_TypeMax = 30;
		public const int Carrier_CdMax = 30;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected Int64? _Usc_Inland_Bb_ID;
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
		protected string _Inland_Type;
		protected string _Service;
		protected string _Region;
		protected string _Country;
		protected string _Point;
		protected string _Port;
		protected string _Commodity;
		protected string _Container;
		protected string _Unit_Type;
		protected string _Carrier_Cd;
		protected decimal? _Rate_Amt;
		protected DateTime? _Effective_Dt;
		protected DateTime? _Expire_Dt;
		protected Int64? _Contract_Mod_ID;

		#endregion	// #region Column Fields

		#region Column Properties

		public Int64? Usc_Inland_Bb_ID
		{
			get { return _Usc_Inland_Bb_ID; }
			set
			{
				if( _Usc_Inland_Bb_ID == value ) return;
		
				_Usc_Inland_Bb_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Usc_Inland_Bb_ID");
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
		public string Inland_Type
		{
			get { return _Inland_Type; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Inland_Type, val, false) == 0 ) return;
		
				if( val != null && val.Length > Inland_TypeMax )
					_Inland_Type = val.Substring(0, (int)Inland_TypeMax);
				else
					_Inland_Type = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Inland_Type");
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
		public string Region
		{
			get { return _Region; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Region, val, false) == 0 ) return;
		
				if( val != null && val.Length > RegionMax )
					_Region = val.Substring(0, (int)RegionMax);
				else
					_Region = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Region");
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
		public string Point
		{
			get { return _Point; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Point, val, false) == 0 ) return;
		
				if( val != null && val.Length > PointMax )
					_Point = val.Substring(0, (int)PointMax);
				else
					_Point = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Point");
			}
		}
		public string Port
		{
			get { return _Port; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Port, val, false) == 0 ) return;
		
				if( val != null && val.Length > PortMax )
					_Port = val.Substring(0, (int)PortMax);
				else
					_Port = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Port");
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
		public string Container
		{
			get { return _Container; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Container, val, false) == 0 ) return;
		
				if( val != null && val.Length > ContainerMax )
					_Container = val.Substring(0, (int)ContainerMax);
				else
					_Container = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Container");
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

		public ClsUscInlandBb() : base() {}
		public ClsUscInlandBb(DataRow dr) : base(dr) {}
		public ClsUscInlandBb(ClsUscInlandBb src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Usc_Inland_Bb_ID = null;
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
			Inland_Type = null;
			Service = null;
			Region = null;
			Country = null;
			Point = null;
			Port = null;
			Commodity = null;
			Container = null;
			Unit_Type = null;
			Carrier_Cd = null;
			Rate_Amt = null;
			Effective_Dt = null;
			Expire_Dt = null;
			Contract_Mod_ID = null;
		}

		public void CopyFrom(ClsUscInlandBb src)
		{
			Usc_Inland_Bb_ID = src._Usc_Inland_Bb_ID;
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
			Inland_Type = src._Inland_Type;
			Service = src._Service;
			Region = src._Region;
			Country = src._Country;
			Point = src._Point;
			Port = src._Port;
			Commodity = src._Commodity;
			Container = src._Container;
			Unit_Type = src._Unit_Type;
			Carrier_Cd = src._Carrier_Cd;
			Rate_Amt = src._Rate_Amt;
			Effective_Dt = src._Effective_Dt;
			Expire_Dt = src._Expire_Dt;
			Contract_Mod_ID = src._Contract_Mod_ID;
		}

		public override bool ReloadFromDB()
		{
			ClsUscInlandBb tmp = ClsUscInlandBb.GetUsingKey(Usc_Inland_Bb_ID.Value);
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

			DbParameter[] p = new DbParameter[25];

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
				("@INLAND_TYPE", Inland_Type);
			p[7] = Connection.GetParameter
				("@SERVICE", Service);
			p[8] = Connection.GetParameter
				("@REGION", Region);
			p[9] = Connection.GetParameter
				("@COUNTRY", Country);
			p[10] = Connection.GetParameter
				("@POINT", Point);
			p[11] = Connection.GetParameter
				("@PORT", Port);
			p[12] = Connection.GetParameter
				("@COMMODITY", Commodity);
			p[13] = Connection.GetParameter
				("@CONTAINER", Container);
			p[14] = Connection.GetParameter
				("@UNIT_TYPE", Unit_Type);
			p[15] = Connection.GetParameter
				("@CARRIER_CD", Carrier_Cd);
			p[16] = Connection.GetParameter
				("@RATE_AMT", Rate_Amt);
			p[17] = Connection.GetParameter
				("@EFFECTIVE_DT", Effective_Dt);
			p[18] = Connection.GetParameter
				("@EXPIRE_DT", Expire_Dt);
			p[19] = Connection.GetParameter
				("@CONTRACT_MOD_ID", Contract_Mod_ID);
			p[20] = Connection.GetParameter
				("@USC_INLAND_BB_ID", Usc_Inland_Bb_ID, ParameterDirection.Output, DbType.Int64, 0);
			p[21] = Connection.GetParameter
				("@CREATE_USER", Create_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Create_UserMax);
			p[22] = Connection.GetParameter
				("@CREATE_DT", Create_Dt, ParameterDirection.Output, DbType.DateTime, 0);
			p[23] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);
			p[24] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.Output, DbType.DateTime, 0);

			const string sql = @"
				INSERT INTO T_USC_INLAND_BB
					(USC_INLAND_BB_ID, ACTIVE_FLG, FLATBED_FLG,
					DOUBLE_DROP_FLG, OOG_FLG, OTO_FLG,
					RFP, INLAND_TYPE, SERVICE,
					REGION, COUNTRY, POINT,
					PORT, COMMODITY, CONTAINER,
					UNIT_TYPE, CARRIER_CD, RATE_AMT,
					EFFECTIVE_DT, EXPIRE_DT, CONTRACT_MOD_ID)
				VALUES
					(USC_INLAND_BB_ID_SEQ.NEXTVAL, @ACTIVE_FLG, @FLATBED_FLG,
					@DOUBLE_DROP_FLG, @OOG_FLG, @OTO_FLG,
					@RFP, @INLAND_TYPE, @SERVICE,
					@REGION, @COUNTRY, @POINT,
					@PORT, @COMMODITY, @CONTAINER,
					@UNIT_TYPE, @CARRIER_CD, @RATE_AMT,
					@EFFECTIVE_DT, @EXPIRE_DT, @CONTRACT_MOD_ID)
				RETURNING
					USC_INLAND_BB_ID, CREATE_USER, CREATE_DT,
					MODIFY_USER, MODIFY_DT
				INTO
					@USC_INLAND_BB_ID, @CREATE_USER, @CREATE_DT,
					@MODIFY_USER, @MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Usc_Inland_Bb_ID = ClsConvert.ToInt64Nullable(p[20].Value);
			Create_User = ClsConvert.ToString(p[21].Value);
			Create_Dt = ClsConvert.ToDateTimeNullable(p[22].Value);
			Modify_User = ClsConvert.ToString(p[23].Value);
			Modify_Dt = ClsConvert.ToDateTimeNullable(p[24].Value);
			return ret;
		}
		public override int Update()
		{
			DbParameter[] p = new DbParameter[23];

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
				("@INLAND_TYPE", Inland_Type);
			p[8] = Connection.GetParameter
				("@SERVICE", Service);
			p[9] = Connection.GetParameter
				("@REGION", Region);
			p[10] = Connection.GetParameter
				("@COUNTRY", Country);
			p[11] = Connection.GetParameter
				("@POINT", Point);
			p[12] = Connection.GetParameter
				("@PORT", Port);
			p[13] = Connection.GetParameter
				("@COMMODITY", Commodity);
			p[14] = Connection.GetParameter
				("@CONTAINER", Container);
			p[15] = Connection.GetParameter
				("@UNIT_TYPE", Unit_Type);
			p[16] = Connection.GetParameter
				("@CARRIER_CD", Carrier_Cd);
			p[17] = Connection.GetParameter
				("@RATE_AMT", Rate_Amt);
			p[18] = Connection.GetParameter
				("@EFFECTIVE_DT", Effective_Dt);
			p[19] = Connection.GetParameter
				("@EXPIRE_DT", Expire_Dt);
			p[20] = Connection.GetParameter
				("@CONTRACT_MOD_ID", Contract_Mod_ID);
			p[21] = Connection.GetParameter
				("@USC_INLAND_BB_ID", Usc_Inland_Bb_ID);
			p[22] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);

			const string sql = @"
				UPDATE T_USC_INLAND_BB SET
					MODIFY_DT = @MODIFY_DT,
					ACTIVE_FLG = @ACTIVE_FLG,
					FLATBED_FLG = @FLATBED_FLG,
					DOUBLE_DROP_FLG = @DOUBLE_DROP_FLG,
					OOG_FLG = @OOG_FLG,
					OTO_FLG = @OTO_FLG,
					RFP = @RFP,
					INLAND_TYPE = @INLAND_TYPE,
					SERVICE = @SERVICE,
					REGION = @REGION,
					COUNTRY = @COUNTRY,
					POINT = @POINT,
					PORT = @PORT,
					COMMODITY = @COMMODITY,
					CONTAINER = @CONTAINER,
					UNIT_TYPE = @UNIT_TYPE,
					CARRIER_CD = @CARRIER_CD,
					RATE_AMT = @RATE_AMT,
					EFFECTIVE_DT = @EFFECTIVE_DT,
					EXPIRE_DT = @EXPIRE_DT,
					CONTRACT_MOD_ID = @CONTRACT_MOD_ID
				WHERE
					USC_INLAND_BB_ID = @USC_INLAND_BB_ID
				RETURNING
					MODIFY_USER, MODIFY_DT
				INTO
					@MODIFY_USER, @MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Modify_Dt = ClsConvert.ToDateTimeNullable(p[0].Value);
			Modify_User = ClsConvert.ToString(p[22].Value);
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

			Usc_Inland_Bb_ID = ClsConvert.ToInt64Nullable(dr["USC_INLAND_BB_ID"]);
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
			Inland_Type = ClsConvert.ToString(dr["INLAND_TYPE"]);
			Service = ClsConvert.ToString(dr["SERVICE"]);
			Region = ClsConvert.ToString(dr["REGION"]);
			Country = ClsConvert.ToString(dr["COUNTRY"]);
			Point = ClsConvert.ToString(dr["POINT"]);
			Port = ClsConvert.ToString(dr["PORT"]);
			Commodity = ClsConvert.ToString(dr["COMMODITY"]);
			Container = ClsConvert.ToString(dr["CONTAINER"]);
			Unit_Type = ClsConvert.ToString(dr["UNIT_TYPE"]);
			Carrier_Cd = ClsConvert.ToString(dr["CARRIER_CD"]);
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

			Usc_Inland_Bb_ID = ClsConvert.ToInt64Nullable(dr["USC_INLAND_BB_ID", v]);
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
			Inland_Type = ClsConvert.ToString(dr["INLAND_TYPE", v]);
			Service = ClsConvert.ToString(dr["SERVICE", v]);
			Region = ClsConvert.ToString(dr["REGION", v]);
			Country = ClsConvert.ToString(dr["COUNTRY", v]);
			Point = ClsConvert.ToString(dr["POINT", v]);
			Port = ClsConvert.ToString(dr["PORT", v]);
			Commodity = ClsConvert.ToString(dr["COMMODITY", v]);
			Container = ClsConvert.ToString(dr["CONTAINER", v]);
			Unit_Type = ClsConvert.ToString(dr["UNIT_TYPE", v]);
			Carrier_Cd = ClsConvert.ToString(dr["CARRIER_CD", v]);
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

			dr["USC_INLAND_BB_ID"] = ClsConvert.ToDbObject(Usc_Inland_Bb_ID);
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
			dr["INLAND_TYPE"] = ClsConvert.ToDbObject(Inland_Type);
			dr["SERVICE"] = ClsConvert.ToDbObject(Service);
			dr["REGION"] = ClsConvert.ToDbObject(Region);
			dr["COUNTRY"] = ClsConvert.ToDbObject(Country);
			dr["POINT"] = ClsConvert.ToDbObject(Point);
			dr["PORT"] = ClsConvert.ToDbObject(Port);
			dr["COMMODITY"] = ClsConvert.ToDbObject(Commodity);
			dr["CONTAINER"] = ClsConvert.ToDbObject(Container);
			dr["UNIT_TYPE"] = ClsConvert.ToDbObject(Unit_Type);
			dr["CARRIER_CD"] = ClsConvert.ToDbObject(Carrier_Cd);
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

		public static ClsUscInlandBb GetUsingKey(Int64 Usc_Inland_Bb_ID)
		{
			object[] vals = new object[] {Usc_Inland_Bb_ID};
			DataRow dr = Connection.GetDataRowUsingKey
				(TableName, GetPrimaryKeys(), vals);
			return ( dr == null ) ? null : new ClsUscInlandBb(dr);
		}
		public static DataTable GetAll(Int64? Contract_Mod_ID)
		{
			List<DbParameter> lst = new List<DbParameter>();	
			StringBuilder sb = new StringBuilder();
		
			if( Contract_Mod_ID != null && Contract_Mod_ID > 0 )
			{
				lst.Add(Connection.GetParameter("@CONTRACT_MOD_ID", Contract_Mod_ID));
				sb.Append(" WHERE T_USC_INLAND_BB.CONTRACT_MOD_ID=@CONTRACT_MOD_ID");
			}
			sb.Insert(0, SelectSQL);
			return Connection.GetDataTable(sb.ToString(), lst.ToArray());
		}
		#endregion		// #region Static Methods
	}
}