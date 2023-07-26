using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsCargoActivity : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ArcSys"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "T_CARGO_ACTIVITY";
		public const int PrimaryKeyCount = 1;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] { "CARGO_ACTIVITY_ID" };
		}

		public const string SelectSQL = @"SELECT * FROM T_CARGO_ACTIVITY 
				INNER JOIN T_CARGO
				ON T_CARGO_ACTIVITY.CARGO_ID=T_CARGO.CARGO_ID
				INNER JOIN R_LOCATION
				ON T_CARGO_ACTIVITY.ORIG_LOCATION_CD=R_LOCATION.LOCATION_CD
				INNER JOIN R_LOCATION r_loc2
				ON T_CARGO_ACTIVITY.DEST_LOCATION_CD=r_loc2.LOCATION_CD
				LEFT OUTER JOIN T_CONVEYANCE
				ON T_CARGO_ACTIVITY.CONVEYANCE_ID=T_CONVEYANCE.CONVEYANCE_ID
				LEFT OUTER JOIN R_VENDOR
				ON T_CARGO_ACTIVITY.VENDOR_CD=R_VENDOR.VENDOR_CD
				LEFT OUTER JOIN T_ESTIMATE
				ON T_CARGO_ACTIVITY.ESTIMATE_ID=T_ESTIMATE.ESTIMATE_ID ";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Create_UserMax = 30;
		public const int Modify_UserMax = 30;
		public const int Activity_Type_CdMax = 10;
		public const int Orig_Location_CdMax = 10;
		public const int Dest_Location_CdMax = 10;
		public const int Io_IndMax = 1;
		public const int Payable_FlgMax = 1;
		public const int Billable_FlgMax = 1;
		public const int Vendor_CdMax = 10;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected Int64? _Cargo_Activity_ID;
		protected string _Create_User;
		protected DateTime? _Create_Dt;
		protected string _Modify_User;
		protected DateTime? _Modify_Dt;
		protected Int64? _Cargo_ID;
		protected string _Activity_Type_Cd;
		protected string _Orig_Location_Cd;
		protected string _Dest_Location_Cd;
		protected string _Io_Ind;
		protected string _Payable_Flg;
		protected string _Billable_Flg;
		protected Int64? _Estimate_ID;
		protected Int64? _Conveyance_ID;
		protected string _Vendor_Cd;

		#endregion	// #region Column Fields

		#region Column Properties

		public Int64? Cargo_Activity_ID
		{
			get { return _Cargo_Activity_ID; }
			set
			{
				if( _Cargo_Activity_ID == value ) return;
		
				_Cargo_Activity_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Cargo_Activity_ID");
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
		public Int64? Cargo_ID
		{
			get { return _Cargo_ID; }
			set
			{
				if( _Cargo_ID == value ) return;
		
				_Cargo_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Cargo_ID");
			}
		}
		public string Activity_Type_Cd
		{
			get { return _Activity_Type_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Activity_Type_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Activity_Type_CdMax )
					_Activity_Type_Cd = val.Substring(0, (int)Activity_Type_CdMax);
				else
					_Activity_Type_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Activity_Type_Cd");
			}
		}
		public string Orig_Location_Cd
		{
			get { return _Orig_Location_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Orig_Location_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Orig_Location_CdMax )
					_Orig_Location_Cd = val.Substring(0, (int)Orig_Location_CdMax);
				else
					_Orig_Location_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Orig_Location_Cd");
			}
		}
		public string Dest_Location_Cd
		{
			get { return _Dest_Location_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Dest_Location_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Dest_Location_CdMax )
					_Dest_Location_Cd = val.Substring(0, (int)Dest_Location_CdMax);
				else
					_Dest_Location_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Dest_Location_Cd");
			}
		}
		public string Io_Ind
		{
			get { return _Io_Ind; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Io_Ind, val, false) == 0 ) return;
		
				if( val != null && val.Length > Io_IndMax )
					_Io_Ind = val.Substring(0, (int)Io_IndMax);
				else
					_Io_Ind = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Io_Ind");
			}
		}
		public string Payable_Flg
		{
			get { return _Payable_Flg; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Payable_Flg, val, false) == 0 ) return;
		
				if( val != null && val.Length > Payable_FlgMax )
					_Payable_Flg = val.Substring(0, (int)Payable_FlgMax);
				else
					_Payable_Flg = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Payable_Flg");
			}
		}
		public string Billable_Flg
		{
			get { return _Billable_Flg; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Billable_Flg, val, false) == 0 ) return;
		
				if( val != null && val.Length > Billable_FlgMax )
					_Billable_Flg = val.Substring(0, (int)Billable_FlgMax);
				else
					_Billable_Flg = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Billable_Flg");
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
		public Int64? Conveyance_ID
		{
			get { return _Conveyance_ID; }
			set
			{
				if( _Conveyance_ID == value ) return;
		
				_Conveyance_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Conveyance_ID");
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

		#endregion	// #region Column Properties

		#region Foreign Key Fields

		protected ClsCargo _Cargo;
		protected ClsLocation _Orig_Location;
		protected ClsLocation _Dest_Location;
		protected ClsConveyance _Conveyance;
		protected ClsVendor _Vendor;
		protected ClsEstimate _Estimate;

		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties

		public ClsCargo Cargo
		{
			get
			{
				if( Cargo_ID == null )
					_Cargo = null;
				else if( _Cargo == null ||
					_Cargo.Cargo_ID != Cargo_ID )
					_Cargo = ClsCargo.GetUsingKey(Cargo_ID.Value);
				return _Cargo;
			}
			set
			{
				if( _Cargo == value ) return;
		
				_Cargo = value;
			}
		}
		public ClsLocation Orig_Location
		{
			get
			{
				if( Orig_Location_Cd == null )
					_Orig_Location = null;
				else if( _Orig_Location == null ||
					_Orig_Location.Location_Cd != Orig_Location_Cd )
					_Orig_Location = ClsLocation.GetUsingKey(Orig_Location_Cd);
				return _Orig_Location;
			}
			set
			{
				if( _Orig_Location == value ) return;
		
				_Orig_Location = value;
			}
		}
		public ClsLocation Dest_Location
		{
			get
			{
				if( Dest_Location_Cd == null )
					_Dest_Location = null;
				else if( _Dest_Location == null ||
					_Dest_Location.Location_Cd != Dest_Location_Cd )
					_Dest_Location = ClsLocation.GetUsingKey(Dest_Location_Cd);
				return _Dest_Location;
			}
			set
			{
				if( _Dest_Location == value ) return;
		
				_Dest_Location = value;
			}
		}
		public ClsConveyance Conveyance
		{
			get
			{
				if( Conveyance_ID == null )
					_Conveyance = null;
				else if( _Conveyance == null ||
					_Conveyance.Conveyance_ID != Conveyance_ID )
					_Conveyance = ClsConveyance.GetUsingKey(Conveyance_ID.Value);
				return _Conveyance;
			}
			set
			{
				if( _Conveyance == value ) return;
		
				_Conveyance = value;
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

		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsCargoActivity() : base() {}
		public ClsCargoActivity(DataRow dr) : base(dr) {}
		public ClsCargoActivity(ClsCargoActivity src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Cargo_Activity_ID = null;
			Create_User = null;
			Create_Dt = null;
			Modify_User = null;
			Modify_Dt = null;
			Cargo_ID = null;
			Activity_Type_Cd = null;
			Orig_Location_Cd = null;
			Dest_Location_Cd = null;
			Io_Ind = null;
			Payable_Flg = null;
			Billable_Flg = null;
			Estimate_ID = null;
			Conveyance_ID = null;
			Vendor_Cd = null;
		}

		public void CopyFrom(ClsCargoActivity src)
		{
			Cargo_Activity_ID = src._Cargo_Activity_ID;
			Create_User = src._Create_User;
			Create_Dt = src._Create_Dt;
			Modify_User = src._Modify_User;
			Modify_Dt = src._Modify_Dt;
			Cargo_ID = src._Cargo_ID;
			Activity_Type_Cd = src._Activity_Type_Cd;
			Orig_Location_Cd = src._Orig_Location_Cd;
			Dest_Location_Cd = src._Dest_Location_Cd;
			Io_Ind = src._Io_Ind;
			Payable_Flg = src._Payable_Flg;
			Billable_Flg = src._Billable_Flg;
			Estimate_ID = src._Estimate_ID;
			Conveyance_ID = src._Conveyance_ID;
			Vendor_Cd = src._Vendor_Cd;
		}

		public override bool ReloadFromDB()
		{
			ClsCargoActivity tmp = ClsCargoActivity.GetUsingKey(Cargo_Activity_ID.Value);
			if( tmp != null ) CopyFrom(tmp);

			ResetFKs();
			OnReload();

			return ( tmp != null );
		}

		public override void ResetFKs()
		{
			_Cargo = null;
			_Orig_Location = null;
			_Dest_Location = null;
			_Conveyance = null;
			_Vendor = null;
			_Estimate = null;
		}
		#endregion		// #region Init methods

		#region Insert, Update, Delete

		public override int Insert()
		{

			DbParameter[] p = new DbParameter[15];

			p[0] = Connection.GetParameter
				("@CARGO_ID", Cargo_ID);
			p[1] = Connection.GetParameter
				("@ACTIVITY_TYPE_CD", Activity_Type_Cd);
			p[2] = Connection.GetParameter
				("@ORIG_LOCATION_CD", Orig_Location_Cd);
			p[3] = Connection.GetParameter
				("@DEST_LOCATION_CD", Dest_Location_Cd);
			p[4] = Connection.GetParameter
				("@IO_IND", Io_Ind);
			p[5] = Connection.GetParameter
				("@PAYABLE_FLG", Payable_Flg);
			p[6] = Connection.GetParameter
				("@BILLABLE_FLG", Billable_Flg);
			p[7] = Connection.GetParameter
				("@ESTIMATE_ID", Estimate_ID);
			p[8] = Connection.GetParameter
				("@CONVEYANCE_ID", Conveyance_ID);
			p[9] = Connection.GetParameter
				("@VENDOR_CD", Vendor_Cd);
			p[10] = Connection.GetParameter
				("@CARGO_ACTIVITY_ID", Cargo_Activity_ID, ParameterDirection.Output, DbType.Int64, 0);
			p[11] = Connection.GetParameter
				("@CREATE_USER", Create_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Create_UserMax);
			p[12] = Connection.GetParameter
				("@CREATE_DT", Create_Dt, ParameterDirection.Output, DbType.DateTime, 0);
			p[13] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);
			p[14] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.Output, DbType.DateTime, 0);

			const string sql = @"
				INSERT INTO T_CARGO_ACTIVITY
					(CARGO_ACTIVITY_ID, CARGO_ID, ACTIVITY_TYPE_CD,
					ORIG_LOCATION_CD, DEST_LOCATION_CD, IO_IND,
					PAYABLE_FLG, BILLABLE_FLG, ESTIMATE_ID,
					CONVEYANCE_ID, VENDOR_CD)
				VALUES
					(CARGO_ACTIVITY_ID_SEQ.NEXTVAL, @CARGO_ID, @ACTIVITY_TYPE_CD,
					@ORIG_LOCATION_CD, @DEST_LOCATION_CD, @IO_IND,
					@PAYABLE_FLG, @BILLABLE_FLG, @ESTIMATE_ID,
					@CONVEYANCE_ID, @VENDOR_CD)
				RETURNING
					CARGO_ACTIVITY_ID, CREATE_USER, CREATE_DT,
					MODIFY_USER, MODIFY_DT
				INTO
					@CARGO_ACTIVITY_ID, @CREATE_USER, @CREATE_DT,
					@MODIFY_USER, @MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Cargo_Activity_ID = ClsConvert.ToInt64Nullable(p[10].Value);
			Create_User = ClsConvert.ToString(p[11].Value);
			Create_Dt = ClsConvert.ToDateTimeNullable(p[12].Value);
			Modify_User = ClsConvert.ToString(p[13].Value);
			Modify_Dt = ClsConvert.ToDateTimeNullable(p[14].Value);
			return ret;
		}
		public override int Update()
		{
			DbParameter[] p = new DbParameter[13];

			p[0] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.InputOutput, DbType.DateTime, 0);
			p[1] = Connection.GetParameter
				("@CARGO_ID", Cargo_ID);
			p[2] = Connection.GetParameter
				("@ACTIVITY_TYPE_CD", Activity_Type_Cd);
			p[3] = Connection.GetParameter
				("@ORIG_LOCATION_CD", Orig_Location_Cd);
			p[4] = Connection.GetParameter
				("@DEST_LOCATION_CD", Dest_Location_Cd);
			p[5] = Connection.GetParameter
				("@IO_IND", Io_Ind);
			p[6] = Connection.GetParameter
				("@PAYABLE_FLG", Payable_Flg);
			p[7] = Connection.GetParameter
				("@BILLABLE_FLG", Billable_Flg);
			p[8] = Connection.GetParameter
				("@ESTIMATE_ID", Estimate_ID);
			p[9] = Connection.GetParameter
				("@CONVEYANCE_ID", Conveyance_ID);
			p[10] = Connection.GetParameter
				("@VENDOR_CD", Vendor_Cd);
			p[11] = Connection.GetParameter
				("@CARGO_ACTIVITY_ID", Cargo_Activity_ID);
			p[12] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);

			const string sql = @"
				UPDATE T_CARGO_ACTIVITY SET
					MODIFY_DT = @MODIFY_DT,
					CARGO_ID = @CARGO_ID,
					ACTIVITY_TYPE_CD = @ACTIVITY_TYPE_CD,
					ORIG_LOCATION_CD = @ORIG_LOCATION_CD,
					DEST_LOCATION_CD = @DEST_LOCATION_CD,
					IO_IND = @IO_IND,
					PAYABLE_FLG = @PAYABLE_FLG,
					BILLABLE_FLG = @BILLABLE_FLG,
					ESTIMATE_ID = @ESTIMATE_ID,
					CONVEYANCE_ID = @CONVEYANCE_ID,
					VENDOR_CD = @VENDOR_CD
				WHERE
					CARGO_ACTIVITY_ID = @CARGO_ACTIVITY_ID
				RETURNING
					MODIFY_USER, MODIFY_DT
				INTO
					@MODIFY_USER, @MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Modify_Dt = ClsConvert.ToDateTimeNullable(p[0].Value);
			Modify_User = ClsConvert.ToString(p[12].Value);
			return ret;
		}
		public override int Delete()
		{
			DbParameter[] p = new DbParameter[1];

			p[0] = Connection.GetParameter
				("@CARGO_ACTIVITY_ID", Cargo_Activity_ID);

			const string sql = @"
				DELETE FROM T_CARGO_ACTIVITY WHERE
				CARGO_ACTIVITY_ID=@CARGO_ACTIVITY_ID";
			return Connection.RunSQL(sql, p);
		}
		#endregion		// #region Insert, Update, Delete

		#region Conversion methods

		public override void LoadFromDataReader(DbDataReader dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataReader: DataReader parameter was null");

			Cargo_Activity_ID = ClsConvert.ToInt64Nullable(dr["CARGO_ACTIVITY_ID"]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER"]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT"]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER"]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT"]);
			Cargo_ID = ClsConvert.ToInt64Nullable(dr["CARGO_ID"]);
			Activity_Type_Cd = ClsConvert.ToString(dr["ACTIVITY_TYPE_CD"]);
			Orig_Location_Cd = ClsConvert.ToString(dr["ORIG_LOCATION_CD"]);
			Dest_Location_Cd = ClsConvert.ToString(dr["DEST_LOCATION_CD"]);
			Io_Ind = ClsConvert.ToString(dr["IO_IND"]);
			Payable_Flg = ClsConvert.ToString(dr["PAYABLE_FLG"]);
			Billable_Flg = ClsConvert.ToString(dr["BILLABLE_FLG"]);
			Estimate_ID = ClsConvert.ToInt64Nullable(dr["ESTIMATE_ID"]);
			Conveyance_ID = ClsConvert.ToInt64Nullable(dr["CONVEYANCE_ID"]);
			Vendor_Cd = ClsConvert.ToString(dr["VENDOR_CD"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Cargo_Activity_ID = ClsConvert.ToInt64Nullable(dr["CARGO_ACTIVITY_ID", v]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER", v]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT", v]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER", v]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT", v]);
			Cargo_ID = ClsConvert.ToInt64Nullable(dr["CARGO_ID", v]);
			Activity_Type_Cd = ClsConvert.ToString(dr["ACTIVITY_TYPE_CD", v]);
			Orig_Location_Cd = ClsConvert.ToString(dr["ORIG_LOCATION_CD", v]);
			Dest_Location_Cd = ClsConvert.ToString(dr["DEST_LOCATION_CD", v]);
			Io_Ind = ClsConvert.ToString(dr["IO_IND", v]);
			Payable_Flg = ClsConvert.ToString(dr["PAYABLE_FLG", v]);
			Billable_Flg = ClsConvert.ToString(dr["BILLABLE_FLG", v]);
			Estimate_ID = ClsConvert.ToInt64Nullable(dr["ESTIMATE_ID", v]);
			Conveyance_ID = ClsConvert.ToInt64Nullable(dr["CONVEYANCE_ID", v]);
			Vendor_Cd = ClsConvert.ToString(dr["VENDOR_CD", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["CARGO_ACTIVITY_ID"] = ClsConvert.ToDbObject(Cargo_Activity_ID);
			dr["CREATE_USER"] = ClsConvert.ToDbObject(Create_User);
			dr["CREATE_DT"] = ClsConvert.ToDbObject(Create_Dt);
			dr["MODIFY_USER"] = ClsConvert.ToDbObject(Modify_User);
			dr["MODIFY_DT"] = ClsConvert.ToDbObject(Modify_Dt);
			dr["CARGO_ID"] = ClsConvert.ToDbObject(Cargo_ID);
			dr["ACTIVITY_TYPE_CD"] = ClsConvert.ToDbObject(Activity_Type_Cd);
			dr["ORIG_LOCATION_CD"] = ClsConvert.ToDbObject(Orig_Location_Cd);
			dr["DEST_LOCATION_CD"] = ClsConvert.ToDbObject(Dest_Location_Cd);
			dr["IO_IND"] = ClsConvert.ToDbObject(Io_Ind);
			dr["PAYABLE_FLG"] = ClsConvert.ToDbObject(Payable_Flg);
			dr["BILLABLE_FLG"] = ClsConvert.ToDbObject(Billable_Flg);
			dr["ESTIMATE_ID"] = ClsConvert.ToDbObject(Estimate_ID);
			dr["CONVEYANCE_ID"] = ClsConvert.ToDbObject(Conveyance_ID);
			dr["VENDOR_CD"] = ClsConvert.ToDbObject(Vendor_Cd);
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

		public static ClsCargoActivity GetUsingKey(Int64 Cargo_Activity_ID)
		{
			object[] vals = new object[] {Cargo_Activity_ID};
			DataRow dr = Connection.GetDataRowUsingKey
				(TableName, GetPrimaryKeys(), vals);
			return ( dr == null ) ? null : new ClsCargoActivity(dr);
		}
		public static DataTable GetAll(Int64? Cargo_ID, string Orig_Location_Cd,
			string Dest_Location_Cd, Int64? Conveyance_ID,
			string Vendor_Cd, Int64? Estimate_ID)
		{
			List<DbParameter> lst = new List<DbParameter>();	
			StringBuilder sb = new StringBuilder();
		
			if( Cargo_ID != null && Cargo_ID > 0 )
			{
				lst.Add(Connection.GetParameter("@CARGO_ID", Cargo_ID));
				sb.Append(" WHERE T_CARGO_ACTIVITY.CARGO_ID=@CARGO_ID");
			}
			if( string.IsNullOrEmpty(Orig_Location_Cd) == false )
			{
				lst.Add(Connection.GetParameter("@ORIG_LOCATION_CD", Orig_Location_Cd));
				sb.AppendFormat(" {0} T_CARGO_ACTIVITY.ORIG_LOCATION_CD=@ORIG_LOCATION_CD",
					sb.Length > 0 ? "AND" : "WHERE");
			}
			if( string.IsNullOrEmpty(Dest_Location_Cd) == false )
			{
				lst.Add(Connection.GetParameter("@DEST_LOCATION_CD", Dest_Location_Cd));
				sb.AppendFormat(" {0} T_CARGO_ACTIVITY.DEST_LOCATION_CD=@DEST_LOCATION_CD",
					sb.Length > 0 ? "AND" : "WHERE");
			}
			if( Conveyance_ID != null && Conveyance_ID > 0 )
			{
				lst.Add(Connection.GetParameter("@CONVEYANCE_ID", Conveyance_ID));
				sb.AppendFormat(" {0} T_CARGO_ACTIVITY.CONVEYANCE_ID=@CONVEYANCE_ID",
					sb.Length > 0 ? "AND" : "WHERE");
			}
			if( string.IsNullOrEmpty(Vendor_Cd) == false )
			{
				lst.Add(Connection.GetParameter("@VENDOR_CD", Vendor_Cd));
				sb.AppendFormat(" {0} T_CARGO_ACTIVITY.VENDOR_CD=@VENDOR_CD",
					sb.Length > 0 ? "AND" : "WHERE");
			}
			if( Estimate_ID != null && Estimate_ID > 0 )
			{
				lst.Add(Connection.GetParameter("@ESTIMATE_ID", Estimate_ID));
				sb.AppendFormat(" {0} T_CARGO_ACTIVITY.ESTIMATE_ID=@ESTIMATE_ID",
					sb.Length > 0 ? "AND" : "WHERE");
			}
			sb.Insert(0, SelectSQL);
			return Connection.GetDataTable(sb.ToString(), lst.ToArray());
		}
		#endregion		// #region Static Methods
	}
}