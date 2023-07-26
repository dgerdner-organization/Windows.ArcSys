using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsVendorGeoRegion : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ArcSys"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "R_VENDOR_GEO_REGION";
		public const int PrimaryKeyCount = 1;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] { "VENDOR_GEO_REGION_ID" };
		}

		public const string SelectSQL = @"SELECT * FROM R_VENDOR_GEO_REGION 
				INNER JOIN R_GEO_REGION
				ON R_VENDOR_GEO_REGION.GEO_REGION_CD=R_GEO_REGION.GEO_REGION_CD
				INNER JOIN R_VENDOR
				ON R_VENDOR_GEO_REGION.VENDOR_CD=R_VENDOR.VENDOR_CD ";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Vendor_CdMax = 10;
		public const int Geo_Region_CdMax = 10;
		public const int Create_UserMax = 30;
		public const int Modify_UserMax = 30;
		public const int Active_FlgMax = 1;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected Int64? _Vendor_Geo_Region_ID;
		protected string _Vendor_Cd;
		protected string _Geo_Region_Cd;
		protected string _Create_User;
		protected DateTime? _Create_Dt;
		protected string _Modify_User;
		protected DateTime? _Modify_Dt;
		protected string _Active_Flg;

		#endregion	// #region Column Fields

		#region Column Properties

		public Int64? Vendor_Geo_Region_ID
		{
			get { return _Vendor_Geo_Region_ID; }
			set
			{
				if( _Vendor_Geo_Region_ID == value ) return;
		
				_Vendor_Geo_Region_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Vendor_Geo_Region_ID");
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

		#endregion	// #region Column Properties

		#region Foreign Key Fields

		protected ClsGeoRegion _Geo_Region;
		protected ClsVendor _Vendor;

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

		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsVendorGeoRegion() : base() {}
		public ClsVendorGeoRegion(DataRow dr) : base(dr) {}
		public ClsVendorGeoRegion(ClsVendorGeoRegion src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Vendor_Geo_Region_ID = null;
			Vendor_Cd = null;
			Geo_Region_Cd = null;
			Create_User = null;
			Create_Dt = null;
			Modify_User = null;
			Modify_Dt = null;
			Active_Flg = null;
		}

		public void CopyFrom(ClsVendorGeoRegion src)
		{
			Vendor_Geo_Region_ID = src._Vendor_Geo_Region_ID;
			Vendor_Cd = src._Vendor_Cd;
			Geo_Region_Cd = src._Geo_Region_Cd;
			Create_User = src._Create_User;
			Create_Dt = src._Create_Dt;
			Modify_User = src._Modify_User;
			Modify_Dt = src._Modify_Dt;
			Active_Flg = src._Active_Flg;
		}

		public override bool ReloadFromDB()
		{
			ClsVendorGeoRegion tmp = ClsVendorGeoRegion.GetUsingKey(Vendor_Geo_Region_ID.Value);
			if( tmp != null ) CopyFrom(tmp);

			ResetFKs();
			OnReload();

			return ( tmp != null );
		}

		public override void ResetFKs()
		{
			_Geo_Region = null;
			_Vendor = null;
		}
		#endregion		// #region Init methods

		#region Insert, Update, Delete

		public override int Insert()
		{

			DbParameter[] p = new DbParameter[8];

			p[0] = Connection.GetParameter
				("@VENDOR_CD", Vendor_Cd);
			p[1] = Connection.GetParameter
				("@GEO_REGION_CD", Geo_Region_Cd);
			p[2] = Connection.GetParameter
				("@ACTIVE_FLG", Active_Flg);
			p[3] = Connection.GetParameter
				("@VENDOR_GEO_REGION_ID", Vendor_Geo_Region_ID, ParameterDirection.Output, DbType.Int64, 0);
			p[4] = Connection.GetParameter
				("@CREATE_USER", Create_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Create_UserMax);
			p[5] = Connection.GetParameter
				("@CREATE_DT", Create_Dt, ParameterDirection.Output, DbType.DateTime, 0);
			p[6] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);
			p[7] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.Output, DbType.DateTime, 0);

			const string sql = @"
				INSERT INTO R_VENDOR_GEO_REGION
					(VENDOR_GEO_REGION_ID, VENDOR_CD, GEO_REGION_CD,
					ACTIVE_FLG)
				VALUES
					(VENDOR_GEO_REGION_ID_SEQ.NEXTVAL, @VENDOR_CD, @GEO_REGION_CD,
					@ACTIVE_FLG)
				RETURNING
					VENDOR_GEO_REGION_ID, CREATE_USER, CREATE_DT,
					MODIFY_USER, MODIFY_DT
				INTO
					@VENDOR_GEO_REGION_ID, @CREATE_USER, @CREATE_DT,
					@MODIFY_USER, @MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Vendor_Geo_Region_ID = ClsConvert.ToInt64Nullable(p[3].Value);
			Create_User = ClsConvert.ToString(p[4].Value);
			Create_Dt = ClsConvert.ToDateTimeNullable(p[5].Value);
			Modify_User = ClsConvert.ToString(p[6].Value);
			Modify_Dt = ClsConvert.ToDateTimeNullable(p[7].Value);
			return ret;
		}
		public override int Update()
		{
			DbParameter[] p = new DbParameter[6];

			p[0] = Connection.GetParameter
				("@VENDOR_CD", Vendor_Cd);
			p[1] = Connection.GetParameter
				("@GEO_REGION_CD", Geo_Region_Cd);
			p[2] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.InputOutput, DbType.DateTime, 0);
			p[3] = Connection.GetParameter
				("@ACTIVE_FLG", Active_Flg);
			p[4] = Connection.GetParameter
				("@VENDOR_GEO_REGION_ID", Vendor_Geo_Region_ID);
			p[5] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);

			const string sql = @"
				UPDATE R_VENDOR_GEO_REGION SET
					VENDOR_CD = @VENDOR_CD,
					GEO_REGION_CD = @GEO_REGION_CD,
					MODIFY_DT = @MODIFY_DT,
					ACTIVE_FLG = @ACTIVE_FLG
				WHERE
					VENDOR_GEO_REGION_ID = @VENDOR_GEO_REGION_ID
				RETURNING
					MODIFY_USER, MODIFY_DT
				INTO
					@MODIFY_USER, @MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Modify_Dt = ClsConvert.ToDateTimeNullable(p[2].Value);
			Modify_User = ClsConvert.ToString(p[5].Value);
			return ret;
		}
		public override int Delete()
		{
			DbParameter[] p = new DbParameter[1];

			p[0] = Connection.GetParameter
				("@VENDOR_GEO_REGION_ID", Vendor_Geo_Region_ID);

			const string sql = @"
				DELETE FROM R_VENDOR_GEO_REGION WHERE
				VENDOR_GEO_REGION_ID=@VENDOR_GEO_REGION_ID";
			return Connection.RunSQL(sql, p);
		}
		#endregion		// #region Insert, Update, Delete

		#region Conversion methods

		public override void LoadFromDataReader(DbDataReader dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataReader: DataReader parameter was null");

			Vendor_Geo_Region_ID = ClsConvert.ToInt64Nullable(dr["VENDOR_GEO_REGION_ID"]);
			Vendor_Cd = ClsConvert.ToString(dr["VENDOR_CD"]);
			Geo_Region_Cd = ClsConvert.ToString(dr["GEO_REGION_CD"]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER"]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT"]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER"]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT"]);
			Active_Flg = ClsConvert.ToString(dr["ACTIVE_FLG"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Vendor_Geo_Region_ID = ClsConvert.ToInt64Nullable(dr["VENDOR_GEO_REGION_ID", v]);
			Vendor_Cd = ClsConvert.ToString(dr["VENDOR_CD", v]);
			Geo_Region_Cd = ClsConvert.ToString(dr["GEO_REGION_CD", v]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER", v]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT", v]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER", v]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT", v]);
			Active_Flg = ClsConvert.ToString(dr["ACTIVE_FLG", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["VENDOR_GEO_REGION_ID"] = ClsConvert.ToDbObject(Vendor_Geo_Region_ID);
			dr["VENDOR_CD"] = ClsConvert.ToDbObject(Vendor_Cd);
			dr["GEO_REGION_CD"] = ClsConvert.ToDbObject(Geo_Region_Cd);
			dr["CREATE_USER"] = ClsConvert.ToDbObject(Create_User);
			dr["CREATE_DT"] = ClsConvert.ToDbObject(Create_Dt);
			dr["MODIFY_USER"] = ClsConvert.ToDbObject(Modify_User);
			dr["MODIFY_DT"] = ClsConvert.ToDbObject(Modify_Dt);
			dr["ACTIVE_FLG"] = ClsConvert.ToDbObject(Active_Flg);
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

		public static ClsVendorGeoRegion GetUsingKey(Int64 Vendor_Geo_Region_ID)
		{
			object[] vals = new object[] {Vendor_Geo_Region_ID};
			DataRow dr = Connection.GetDataRowUsingKey
				(TableName, GetPrimaryKeys(), vals);
			return ( dr == null ) ? null : new ClsVendorGeoRegion(dr);
		}
		public static DataTable GetAll(string Geo_Region_Cd, string Vendor_Cd)
		{
			List<DbParameter> lst = new List<DbParameter>();	
			StringBuilder sb = new StringBuilder();
		
			if( string.IsNullOrEmpty(Geo_Region_Cd) == false )
			{
				lst.Add(Connection.GetParameter("@GEO_REGION_CD", Geo_Region_Cd));
				sb.Append(" WHERE R_VENDOR_GEO_REGION.GEO_REGION_CD=@GEO_REGION_CD");
			}
			if( string.IsNullOrEmpty(Vendor_Cd) == false )
			{
				lst.Add(Connection.GetParameter("@VENDOR_CD", Vendor_Cd));
				sb.AppendFormat(" {0} R_VENDOR_GEO_REGION.VENDOR_CD=@VENDOR_CD",
					sb.Length > 0 ? "AND" : "WHERE");
			}
			sb.Insert(0, SelectSQL);
			return Connection.GetDataTable(sb.ToString(), lst.ToArray());
		}
		#endregion		// #region Static Methods
	}
}