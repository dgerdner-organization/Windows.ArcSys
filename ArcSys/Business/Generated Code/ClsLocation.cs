using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsLocation : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ArcSys"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "R_LOCATION";
		public const int PrimaryKeyCount = 1;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] { "LOCATION_CD" };
		}

		public const string SelectSQL = @"SELECT * FROM R_LOCATION 
				LEFT OUTER JOIN R_GEO_REGION
				ON R_LOCATION.GEO_REGION_CD=R_GEO_REGION.GEO_REGION_CD
				INNER JOIN R_LOCATION_TYPE
				ON R_LOCATION.LOCATION_TYPE_CD=R_LOCATION_TYPE.LOCATION_TYPE_CD ";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Location_CdMax = 10;
		public const int Location_DscMax = 50;
		public const int Create_UserMax = 30;
		public const int Modify_UserMax = 30;
		public const int Location_Type_CdMax = 10;
		public const int Active_FlgMax = 1;
		public const int Conus_FlgMax = 1;
		public const int Gate_FlgMax = 1;
		public const int Border_FlgMax = 1;
		public const int Hold_Area_FlgMax = 1;
		public const int Checkpoint_FlgMax = 1;
		public const int Geo_Region_CdMax = 10;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected string _Location_Cd;
		protected string _Location_Dsc;
		protected string _Create_User;
		protected DateTime? _Create_Dt;
		protected string _Modify_User;
		protected DateTime? _Modify_Dt;
		protected string _Location_Type_Cd;
		protected string _Active_Flg;
		protected string _Conus_Flg;
		protected string _Gate_Flg;
		protected string _Border_Flg;
		protected string _Hold_Area_Flg;
		protected string _Checkpoint_Flg;
		protected decimal? _Latitude_Nbr;
		protected decimal? _Longitude_Nbr;
		protected string _Geo_Region_Cd;

		#endregion	// #region Column Fields

		#region Column Properties

		public string Location_Cd
		{
			get { return _Location_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Location_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Location_CdMax )
					_Location_Cd = val.Substring(0, (int)Location_CdMax);
				else
					_Location_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Location_Cd");
			}
		}
		public string Location_Dsc
		{
			get { return _Location_Dsc; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Location_Dsc, val, false) == 0 ) return;
		
				if( val != null && val.Length > Location_DscMax )
					_Location_Dsc = val.Substring(0, (int)Location_DscMax);
				else
					_Location_Dsc = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Location_Dsc");
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
		public string Location_Type_Cd
		{
			get { return _Location_Type_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Location_Type_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Location_Type_CdMax )
					_Location_Type_Cd = val.Substring(0, (int)Location_Type_CdMax);
				else
					_Location_Type_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Location_Type_Cd");
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
		public string Conus_Flg
		{
			get { return _Conus_Flg; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Conus_Flg, val, false) == 0 ) return;
		
				if( val != null && val.Length > Conus_FlgMax )
					_Conus_Flg = val.Substring(0, (int)Conus_FlgMax);
				else
					_Conus_Flg = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Conus_Flg");
			}
		}
		public string Gate_Flg
		{
			get { return _Gate_Flg; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Gate_Flg, val, false) == 0 ) return;
		
				if( val != null && val.Length > Gate_FlgMax )
					_Gate_Flg = val.Substring(0, (int)Gate_FlgMax);
				else
					_Gate_Flg = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Gate_Flg");
			}
		}
		public string Border_Flg
		{
			get { return _Border_Flg; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Border_Flg, val, false) == 0 ) return;
		
				if( val != null && val.Length > Border_FlgMax )
					_Border_Flg = val.Substring(0, (int)Border_FlgMax);
				else
					_Border_Flg = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Border_Flg");
			}
		}
		public string Hold_Area_Flg
		{
			get { return _Hold_Area_Flg; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Hold_Area_Flg, val, false) == 0 ) return;
		
				if( val != null && val.Length > Hold_Area_FlgMax )
					_Hold_Area_Flg = val.Substring(0, (int)Hold_Area_FlgMax);
				else
					_Hold_Area_Flg = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Hold_Area_Flg");
			}
		}
		public string Checkpoint_Flg
		{
			get { return _Checkpoint_Flg; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Checkpoint_Flg, val, false) == 0 ) return;
		
				if( val != null && val.Length > Checkpoint_FlgMax )
					_Checkpoint_Flg = val.Substring(0, (int)Checkpoint_FlgMax);
				else
					_Checkpoint_Flg = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Checkpoint_Flg");
			}
		}
		public decimal? Latitude_Nbr
		{
			get { return _Latitude_Nbr; }
			set
			{
				if( _Latitude_Nbr == value ) return;
		
				_Latitude_Nbr = value;
				_IsDirty = true;
				NotifyPropertyChanged("Latitude_Nbr");
			}
		}
		public decimal? Longitude_Nbr
		{
			get { return _Longitude_Nbr; }
			set
			{
				if( _Longitude_Nbr == value ) return;
		
				_Longitude_Nbr = value;
				_IsDirty = true;
				NotifyPropertyChanged("Longitude_Nbr");
			}
		}
		public string Geo_Region_Cd
		{
			get { return _Geo_Region_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Geo_Region_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Geo_Region_CdMax )
					_Geo_Region_Cd = val.Substring(0, (int)Geo_Region_CdMax);
				else
					_Geo_Region_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Geo_Region_Cd");
			}
		}

		#endregion	// #region Column Properties

		#region Foreign Key Fields

		protected ClsGeoRegion _Geo_Region;
		protected ClsLocationType _Location_Type;

		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties

		public ClsGeoRegion Geo_Region
		{
			get
			{
				if( Geo_Region_Cd == null )
					_Geo_Region = null;
				else if( _Geo_Region == null ||
					_Geo_Region.Geo_Region_Cd != Geo_Region_Cd )
					_Geo_Region = ClsGeoRegion.GetUsingKey(Geo_Region_Cd);
				return _Geo_Region;
			}
			set
			{
				if( _Geo_Region == value ) return;
		
				_Geo_Region = value;
			}
		}
		public ClsLocationType Location_Type
		{
			get
			{
				if( Location_Type_Cd == null )
					_Location_Type = null;
				else if( _Location_Type == null ||
					_Location_Type.Location_Type_Cd != Location_Type_Cd )
					_Location_Type = ClsLocationType.GetUsingKey(Location_Type_Cd);
				return _Location_Type;
			}
			set
			{
				if( _Location_Type == value ) return;
		
				_Location_Type = value;
			}
		}

		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsLocation() : base() {}
		public ClsLocation(DataRow dr) : base(dr) {}
		public ClsLocation(ClsLocation src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Location_Cd = null;
			Location_Dsc = null;
			Create_User = null;
			Create_Dt = null;
			Modify_User = null;
			Modify_Dt = null;
			Location_Type_Cd = null;
			Active_Flg = null;
			Conus_Flg = null;
			Gate_Flg = null;
			Border_Flg = null;
			Hold_Area_Flg = null;
			Checkpoint_Flg = null;
			Latitude_Nbr = null;
			Longitude_Nbr = null;
			Geo_Region_Cd = null;
		}

		public void CopyFrom(ClsLocation src)
		{
			Location_Cd = src._Location_Cd;
			Location_Dsc = src._Location_Dsc;
			Create_User = src._Create_User;
			Create_Dt = src._Create_Dt;
			Modify_User = src._Modify_User;
			Modify_Dt = src._Modify_Dt;
			Location_Type_Cd = src._Location_Type_Cd;
			Active_Flg = src._Active_Flg;
			Conus_Flg = src._Conus_Flg;
			Gate_Flg = src._Gate_Flg;
			Border_Flg = src._Border_Flg;
			Hold_Area_Flg = src._Hold_Area_Flg;
			Checkpoint_Flg = src._Checkpoint_Flg;
			Latitude_Nbr = src._Latitude_Nbr;
			Longitude_Nbr = src._Longitude_Nbr;
			Geo_Region_Cd = src._Geo_Region_Cd;
		}

		public override bool ReloadFromDB()
		{
			ClsLocation tmp = ClsLocation.GetUsingKey(Location_Cd);
			if( tmp != null ) CopyFrom(tmp);

			ResetFKs();
			OnReload();

			return ( tmp != null );
		}

		public override void ResetFKs()
		{
			_Geo_Region = null;
			_Location_Type = null;
		}
		#endregion		// #region Init methods

		#region Insert, Update, Delete

		public override int Insert()
		{

			DbParameter[] p = new DbParameter[16];

			p[0] = Connection.GetParameter
				("@LOCATION_CD", Location_Cd);
			p[1] = Connection.GetParameter
				("@LOCATION_DSC", Location_Dsc);
			p[2] = Connection.GetParameter
				("@LOCATION_TYPE_CD", Location_Type_Cd);
			p[3] = Connection.GetParameter
				("@ACTIVE_FLG", Active_Flg);
			p[4] = Connection.GetParameter
				("@CONUS_FLG", Conus_Flg);
			p[5] = Connection.GetParameter
				("@GATE_FLG", Gate_Flg);
			p[6] = Connection.GetParameter
				("@BORDER_FLG", Border_Flg);
			p[7] = Connection.GetParameter
				("@HOLD_AREA_FLG", Hold_Area_Flg);
			p[8] = Connection.GetParameter
				("@CHECKPOINT_FLG", Checkpoint_Flg);
			p[9] = Connection.GetParameter
				("@LATITUDE_NBR", Latitude_Nbr);
			p[10] = Connection.GetParameter
				("@LONGITUDE_NBR", Longitude_Nbr);
			p[11] = Connection.GetParameter
				("@GEO_REGION_CD", Geo_Region_Cd);
			p[12] = Connection.GetParameter
				("@CREATE_USER", Create_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Create_UserMax);
			p[13] = Connection.GetParameter
				("@CREATE_DT", Create_Dt, ParameterDirection.Output, DbType.DateTime, 0);
			p[14] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);
			p[15] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.Output, DbType.DateTime, 0);

			const string sql = @"
				INSERT INTO R_LOCATION
					(LOCATION_CD, LOCATION_DSC, LOCATION_TYPE_CD,
					ACTIVE_FLG, CONUS_FLG, GATE_FLG,
					BORDER_FLG, HOLD_AREA_FLG, CHECKPOINT_FLG,
					LATITUDE_NBR, LONGITUDE_NBR, GEO_REGION_CD)
				VALUES
					(@LOCATION_CD, @LOCATION_DSC, @LOCATION_TYPE_CD,
					@ACTIVE_FLG, @CONUS_FLG, @GATE_FLG,
					@BORDER_FLG, @HOLD_AREA_FLG, @CHECKPOINT_FLG,
					@LATITUDE_NBR, @LONGITUDE_NBR, @GEO_REGION_CD)
				RETURNING
					CREATE_USER, CREATE_DT, MODIFY_USER,
					MODIFY_DT
				INTO
					@CREATE_USER, @CREATE_DT, @MODIFY_USER,
					@MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

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
				("@LOCATION_DSC", Location_Dsc);
			p[1] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.InputOutput, DbType.DateTime, 0);
			p[2] = Connection.GetParameter
				("@LOCATION_TYPE_CD", Location_Type_Cd);
			p[3] = Connection.GetParameter
				("@ACTIVE_FLG", Active_Flg);
			p[4] = Connection.GetParameter
				("@CONUS_FLG", Conus_Flg);
			p[5] = Connection.GetParameter
				("@GATE_FLG", Gate_Flg);
			p[6] = Connection.GetParameter
				("@BORDER_FLG", Border_Flg);
			p[7] = Connection.GetParameter
				("@HOLD_AREA_FLG", Hold_Area_Flg);
			p[8] = Connection.GetParameter
				("@CHECKPOINT_FLG", Checkpoint_Flg);
			p[9] = Connection.GetParameter
				("@LATITUDE_NBR", Latitude_Nbr);
			p[10] = Connection.GetParameter
				("@LONGITUDE_NBR", Longitude_Nbr);
			p[11] = Connection.GetParameter
				("@GEO_REGION_CD", Geo_Region_Cd);
			p[12] = Connection.GetParameter
				("@LOCATION_CD", Location_Cd);
			p[13] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);

			const string sql = @"
				UPDATE R_LOCATION SET
					LOCATION_DSC = @LOCATION_DSC,
					MODIFY_DT = @MODIFY_DT,
					LOCATION_TYPE_CD = @LOCATION_TYPE_CD,
					ACTIVE_FLG = @ACTIVE_FLG,
					CONUS_FLG = @CONUS_FLG,
					GATE_FLG = @GATE_FLG,
					BORDER_FLG = @BORDER_FLG,
					HOLD_AREA_FLG = @HOLD_AREA_FLG,
					CHECKPOINT_FLG = @CHECKPOINT_FLG,
					LATITUDE_NBR = @LATITUDE_NBR,
					LONGITUDE_NBR = @LONGITUDE_NBR,
					GEO_REGION_CD = @GEO_REGION_CD
				WHERE
					LOCATION_CD = @LOCATION_CD
				RETURNING
					MODIFY_USER, MODIFY_DT
				INTO
					@MODIFY_USER, @MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Modify_Dt = ClsConvert.ToDateTimeNullable(p[1].Value);
			Modify_User = ClsConvert.ToString(p[13].Value);
			return ret;
		}
		public override int Delete()
		{
			DbParameter[] p = new DbParameter[1];

			p[0] = Connection.GetParameter
				("@LOCATION_CD", Location_Cd);

			const string sql = @"
				DELETE FROM R_LOCATION WHERE
				LOCATION_CD=@LOCATION_CD";
			return Connection.RunSQL(sql, p);
		}
		#endregion		// #region Insert, Update, Delete

		#region Conversion methods

		public override void LoadFromDataReader(DbDataReader dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataReader: DataReader parameter was null");

			Location_Cd = ClsConvert.ToString(dr["LOCATION_CD"]);
			Location_Dsc = ClsConvert.ToString(dr["LOCATION_DSC"]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER"]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT"]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER"]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT"]);
			Location_Type_Cd = ClsConvert.ToString(dr["LOCATION_TYPE_CD"]);
			Active_Flg = ClsConvert.ToString(dr["ACTIVE_FLG"]);
			Conus_Flg = ClsConvert.ToString(dr["CONUS_FLG"]);
			Gate_Flg = ClsConvert.ToString(dr["GATE_FLG"]);
			Border_Flg = ClsConvert.ToString(dr["BORDER_FLG"]);
			Hold_Area_Flg = ClsConvert.ToString(dr["HOLD_AREA_FLG"]);
			Checkpoint_Flg = ClsConvert.ToString(dr["CHECKPOINT_FLG"]);
			Latitude_Nbr = ClsConvert.ToDecimalNullable(dr["LATITUDE_NBR"]);
			Longitude_Nbr = ClsConvert.ToDecimalNullable(dr["LONGITUDE_NBR"]);
			Geo_Region_Cd = ClsConvert.ToString(dr["GEO_REGION_CD"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Location_Cd = ClsConvert.ToString(dr["LOCATION_CD", v]);
			Location_Dsc = ClsConvert.ToString(dr["LOCATION_DSC", v]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER", v]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT", v]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER", v]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT", v]);
			Location_Type_Cd = ClsConvert.ToString(dr["LOCATION_TYPE_CD", v]);
			Active_Flg = ClsConvert.ToString(dr["ACTIVE_FLG", v]);
			Conus_Flg = ClsConvert.ToString(dr["CONUS_FLG", v]);
			Gate_Flg = ClsConvert.ToString(dr["GATE_FLG", v]);
			Border_Flg = ClsConvert.ToString(dr["BORDER_FLG", v]);
			Hold_Area_Flg = ClsConvert.ToString(dr["HOLD_AREA_FLG", v]);
			Checkpoint_Flg = ClsConvert.ToString(dr["CHECKPOINT_FLG", v]);
			Latitude_Nbr = ClsConvert.ToDecimalNullable(dr["LATITUDE_NBR", v]);
			Longitude_Nbr = ClsConvert.ToDecimalNullable(dr["LONGITUDE_NBR", v]);
			Geo_Region_Cd = ClsConvert.ToString(dr["GEO_REGION_CD", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["LOCATION_CD"] = ClsConvert.ToDbObject(Location_Cd);
			dr["LOCATION_DSC"] = ClsConvert.ToDbObject(Location_Dsc);
			dr["CREATE_USER"] = ClsConvert.ToDbObject(Create_User);
			dr["CREATE_DT"] = ClsConvert.ToDbObject(Create_Dt);
			dr["MODIFY_USER"] = ClsConvert.ToDbObject(Modify_User);
			dr["MODIFY_DT"] = ClsConvert.ToDbObject(Modify_Dt);
			dr["LOCATION_TYPE_CD"] = ClsConvert.ToDbObject(Location_Type_Cd);
			dr["ACTIVE_FLG"] = ClsConvert.ToDbObject(Active_Flg);
			dr["CONUS_FLG"] = ClsConvert.ToDbObject(Conus_Flg);
			dr["GATE_FLG"] = ClsConvert.ToDbObject(Gate_Flg);
			dr["BORDER_FLG"] = ClsConvert.ToDbObject(Border_Flg);
			dr["HOLD_AREA_FLG"] = ClsConvert.ToDbObject(Hold_Area_Flg);
			dr["CHECKPOINT_FLG"] = ClsConvert.ToDbObject(Checkpoint_Flg);
			dr["LATITUDE_NBR"] = ClsConvert.ToDbObject(Latitude_Nbr);
			dr["LONGITUDE_NBR"] = ClsConvert.ToDbObject(Longitude_Nbr);
			dr["GEO_REGION_CD"] = ClsConvert.ToDbObject(Geo_Region_Cd);
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

		public static ClsLocation GetUsingKey(string Location_Cd)
		{
			object[] vals = new object[] {Location_Cd};
			DataRow dr = Connection.GetDataRowUsingKey
				(TableName, GetPrimaryKeys(), vals);
			return ( dr == null ) ? null : new ClsLocation(dr);
		}
		public static DataTable GetAll(string Geo_Region_Cd, string Location_Type_Cd)
		{
			List<DbParameter> lst = new List<DbParameter>();	
			StringBuilder sb = new StringBuilder();
		
			if( string.IsNullOrEmpty(Geo_Region_Cd) == false )
			{
				lst.Add(Connection.GetParameter("@GEO_REGION_CD", Geo_Region_Cd));
				sb.Append(" WHERE R_LOCATION.GEO_REGION_CD=@GEO_REGION_CD");
			}
			if( string.IsNullOrEmpty(Location_Type_Cd) == false )
			{
				lst.Add(Connection.GetParameter("@LOCATION_TYPE_CD", Location_Type_Cd));
				sb.AppendFormat(" {0} R_LOCATION.LOCATION_TYPE_CD=@LOCATION_TYPE_CD",
					sb.Length > 0 ? "AND" : "WHERE");
			}
			sb.Insert(0, SelectSQL);
			return Connection.GetDataTable(sb.ToString(), lst.ToArray());
		}
		#endregion		// #region Static Methods
	}
}