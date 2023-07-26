using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsEstimate : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ArcSys"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "T_ESTIMATE";
		public const int PrimaryKeyCount = 1;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] { "ESTIMATE_ID" };
		}

		public const string SelectSQL = @"SELECT * FROM T_ESTIMATE 
				INNER JOIN R_ESTIMATE_STATUS
				ON T_ESTIMATE.AP_STATUS_CD=R_ESTIMATE_STATUS.ESTIMATE_STATUS_CD
				INNER JOIN R_LOCATION
				ON T_ESTIMATE.DEST_LOCATION_CD=R_LOCATION.LOCATION_CD
				INNER JOIN R_LOCATION r_loc2
				ON T_ESTIMATE.ORIG_LOCATION_CD=r_loc2.LOCATION_CD
				INNER JOIN R_ESTIMATE_STATUS r_est2
				ON T_ESTIMATE.LINE_STATUS_CD=r_est2.ESTIMATE_STATUS_CD
				LEFT OUTER JOIN T_ESTIMATE t_est2
				ON T_ESTIMATE.ORIG_ESTIMATE_ID=t_est2.ESTIMATE_ID
				INNER JOIN R_ESTIMATE_STATUS r_est3
				ON T_ESTIMATE.AR_STATUS_CD=r_est3.ESTIMATE_STATUS_CD ";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Create_UserMax = 30;
		public const int Modify_UserMax = 30;
		public const int Voyage_NoMax = 10;
		public const int Orig_Location_CdMax = 10;
		public const int Dest_Location_CdMax = 10;
		public const int Estimate_NoMax = 10;
		public const int Ap_Status_CdMax = 10;
		public const int Ar_Status_CdMax = 10;
		public const int Line_Status_CdMax = 10;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected Int64? _Estimate_ID;
		protected string _Create_User;
		protected DateTime? _Create_Dt;
		protected string _Modify_User;
		protected DateTime? _Modify_Dt;
		protected string _Voyage_No;
		protected string _Orig_Location_Cd;
		protected string _Dest_Location_Cd;
		protected string _Estimate_No;
		protected string _Ap_Status_Cd;
		protected string _Ar_Status_Cd;
		protected string _Line_Status_Cd;
		protected DateTime? _Estimate_Dt;
		protected DateTime? _Accrued_Dt;
		protected Int64? _Mileage;
		protected Int64? _Orig_Estimate_ID;

		#endregion	// #region Column Fields

		#region Column Properties

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
		public string Voyage_No
		{
			get { return _Voyage_No; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Voyage_No, val, false) == 0 ) return;
		
				if( val != null && val.Length > Voyage_NoMax )
					_Voyage_No = val.Substring(0, (int)Voyage_NoMax);
				else
					_Voyage_No = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Voyage_No");
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
		public string Estimate_No
		{
			get { return _Estimate_No; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Estimate_No, val, false) == 0 ) return;
		
				if( val != null && val.Length > Estimate_NoMax )
					_Estimate_No = val.Substring(0, (int)Estimate_NoMax);
				else
					_Estimate_No = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Estimate_No");
			}
		}
		public string Ap_Status_Cd
		{
			get { return _Ap_Status_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Ap_Status_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Ap_Status_CdMax )
					_Ap_Status_Cd = val.Substring(0, (int)Ap_Status_CdMax);
				else
					_Ap_Status_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Ap_Status_Cd");
			}
		}
		public string Ar_Status_Cd
		{
			get { return _Ar_Status_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Ar_Status_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Ar_Status_CdMax )
					_Ar_Status_Cd = val.Substring(0, (int)Ar_Status_CdMax);
				else
					_Ar_Status_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Ar_Status_Cd");
			}
		}
		public string Line_Status_Cd
		{
			get { return _Line_Status_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Line_Status_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Line_Status_CdMax )
					_Line_Status_Cd = val.Substring(0, (int)Line_Status_CdMax);
				else
					_Line_Status_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Line_Status_Cd");
			}
		}
		public DateTime? Estimate_Dt
		{
			get { return _Estimate_Dt; }
			set
			{
				DateTime? val = ( value != null )
					? (DateTime?)value.Value.Date : null;
		
				if( _Estimate_Dt == val ) return;
		
				_Estimate_Dt = val;
				_IsDirty = true;
				NotifyPropertyChanged("Estimate_Dt");
			}
		}
		public DateTime? Accrued_Dt
		{
			get { return _Accrued_Dt; }
			set
			{
				DateTime? val = ( value != null )
					? (DateTime?)value.Value.Date : null;
		
				if( _Accrued_Dt == val ) return;
		
				_Accrued_Dt = val;
				_IsDirty = true;
				NotifyPropertyChanged("Accrued_Dt");
			}
		}
		public Int64? Mileage
		{
			get { return _Mileage; }
			set
			{
				if( _Mileage == value ) return;
		
				_Mileage = value;
				_IsDirty = true;
				NotifyPropertyChanged("Mileage");
			}
		}
		public Int64? Orig_Estimate_ID
		{
			get { return _Orig_Estimate_ID; }
			set
			{
				if( _Orig_Estimate_ID == value ) return;
		
				_Orig_Estimate_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Orig_Estimate_ID");
			}
		}

		#endregion	// #region Column Properties

		#region Foreign Key Fields

		protected ClsEstimateStatus _Ap_Status;
		protected ClsLocation _Dest_Location;
		protected ClsLocation _Orig_Location;
		protected ClsEstimateStatus _Line_Status;
		protected ClsEstimate _Orig_Estimate;
		protected ClsEstimateStatus _Ar_Status;

		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties

		public ClsEstimateStatus Ap_Status
		{
			get
			{
				if( Ap_Status_Cd == null )
					_Ap_Status = null;
				else if( _Ap_Status == null ||
					_Ap_Status.Estimate_Status_Cd != Ap_Status_Cd )
					_Ap_Status = ClsEstimateStatus.GetUsingKey(Ap_Status_Cd);
				return _Ap_Status;
			}
			set
			{
				if( _Ap_Status == value ) return;
		
				_Ap_Status = value;
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
		public ClsEstimateStatus Line_Status
		{
			get
			{
				if( Line_Status_Cd == null )
					_Line_Status = null;
				else if( _Line_Status == null ||
					_Line_Status.Estimate_Status_Cd != Line_Status_Cd )
					_Line_Status = ClsEstimateStatus.GetUsingKey(Line_Status_Cd);
				return _Line_Status;
			}
			set
			{
				if( _Line_Status == value ) return;
		
				_Line_Status = value;
			}
		}
		public ClsEstimate Orig_Estimate
		{
			get
			{
				if( Orig_Estimate_ID == null )
					_Orig_Estimate = null;
				else if( _Orig_Estimate == null ||
					_Orig_Estimate.Estimate_ID != Orig_Estimate_ID )
					_Orig_Estimate = ClsEstimate.GetUsingKey(Orig_Estimate_ID.Value);
				return _Orig_Estimate;
			}
			set
			{
				if( _Orig_Estimate == value ) return;
		
				_Orig_Estimate = value;
			}
		}
		public ClsEstimateStatus Ar_Status
		{
			get
			{
				if( Ar_Status_Cd == null )
					_Ar_Status = null;
				else if( _Ar_Status == null ||
					_Ar_Status.Estimate_Status_Cd != Ar_Status_Cd )
					_Ar_Status = ClsEstimateStatus.GetUsingKey(Ar_Status_Cd);
				return _Ar_Status;
			}
			set
			{
				if( _Ar_Status == value ) return;
		
				_Ar_Status = value;
			}
		}

		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsEstimate() : base() {}
		public ClsEstimate(DataRow dr) : base(dr) {}
		public ClsEstimate(ClsEstimate src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Estimate_ID = null;
			Create_User = null;
			Create_Dt = null;
			Modify_User = null;
			Modify_Dt = null;
			Voyage_No = null;
			Orig_Location_Cd = null;
			Dest_Location_Cd = null;
			Estimate_No = null;
			Ap_Status_Cd = null;
			Ar_Status_Cd = null;
			Line_Status_Cd = null;
			Estimate_Dt = null;
			Accrued_Dt = null;
			Mileage = null;
			Orig_Estimate_ID = null;
		}

		public void CopyFrom(ClsEstimate src)
		{
			Estimate_ID = src._Estimate_ID;
			Create_User = src._Create_User;
			Create_Dt = src._Create_Dt;
			Modify_User = src._Modify_User;
			Modify_Dt = src._Modify_Dt;
			Voyage_No = src._Voyage_No;
			Orig_Location_Cd = src._Orig_Location_Cd;
			Dest_Location_Cd = src._Dest_Location_Cd;
			Estimate_No = src._Estimate_No;
			Ap_Status_Cd = src._Ap_Status_Cd;
			Ar_Status_Cd = src._Ar_Status_Cd;
			Line_Status_Cd = src._Line_Status_Cd;
			Estimate_Dt = src._Estimate_Dt;
			Accrued_Dt = src._Accrued_Dt;
			Mileage = src._Mileage;
			Orig_Estimate_ID = src._Orig_Estimate_ID;
		}

		public override bool ReloadFromDB()
		{
			ClsEstimate tmp = ClsEstimate.GetUsingKey(Estimate_ID.Value);
			if( tmp != null ) CopyFrom(tmp);

			ResetFKs();
			OnReload();

			return ( tmp != null );
		}

		public override void ResetFKs()
		{
			_Ap_Status = null;
			_Dest_Location = null;
			_Orig_Location = null;
			_Line_Status = null;
			_Orig_Estimate = null;
			_Ar_Status = null;
		}
		#endregion		// #region Init methods

		#region Insert, Update, Delete

		public override int Insert()
		{

			DbParameter[] p = new DbParameter[16];

			p[0] = Connection.GetParameter
				("@VOYAGE_NO", Voyage_No);
			p[1] = Connection.GetParameter
				("@ORIG_LOCATION_CD", Orig_Location_Cd);
			p[2] = Connection.GetParameter
				("@DEST_LOCATION_CD", Dest_Location_Cd);
			p[3] = Connection.GetParameter
				("@ESTIMATE_NO", Estimate_No);
			p[4] = Connection.GetParameter
				("@AP_STATUS_CD", Ap_Status_Cd);
			p[5] = Connection.GetParameter
				("@AR_STATUS_CD", Ar_Status_Cd);
			p[6] = Connection.GetParameter
				("@LINE_STATUS_CD", Line_Status_Cd);
			p[7] = Connection.GetParameter
				("@ESTIMATE_DT", Estimate_Dt);
			p[8] = Connection.GetParameter
				("@ACCRUED_DT", Accrued_Dt);
			p[9] = Connection.GetParameter
				("@MILEAGE", Mileage);
			p[10] = Connection.GetParameter
				("@ORIG_ESTIMATE_ID", Orig_Estimate_ID);
			p[11] = Connection.GetParameter
				("@ESTIMATE_ID", Estimate_ID, ParameterDirection.Output, DbType.Int64, 0);
			p[12] = Connection.GetParameter
				("@CREATE_USER", Create_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Create_UserMax);
			p[13] = Connection.GetParameter
				("@CREATE_DT", Create_Dt, ParameterDirection.Output, DbType.DateTime, 0);
			p[14] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);
			p[15] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.Output, DbType.DateTime, 0);

			const string sql = @"
				INSERT INTO T_ESTIMATE
					(ESTIMATE_ID, VOYAGE_NO, ORIG_LOCATION_CD,
					DEST_LOCATION_CD, ESTIMATE_NO, AP_STATUS_CD,
					AR_STATUS_CD, LINE_STATUS_CD, ESTIMATE_DT,
					ACCRUED_DT, MILEAGE, ORIG_ESTIMATE_ID)
				VALUES
					(ESTIMATE_ID_SEQ.NEXTVAL, @VOYAGE_NO, @ORIG_LOCATION_CD,
					@DEST_LOCATION_CD, @ESTIMATE_NO, @AP_STATUS_CD,
					@AR_STATUS_CD, @LINE_STATUS_CD, @ESTIMATE_DT,
					@ACCRUED_DT, @MILEAGE, @ORIG_ESTIMATE_ID)
				RETURNING
					ESTIMATE_ID, CREATE_USER, CREATE_DT,
					MODIFY_USER, MODIFY_DT
				INTO
					@ESTIMATE_ID, @CREATE_USER, @CREATE_DT,
					@MODIFY_USER, @MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Estimate_ID = ClsConvert.ToInt64Nullable(p[11].Value);
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
				("@VOYAGE_NO", Voyage_No);
			p[2] = Connection.GetParameter
				("@ORIG_LOCATION_CD", Orig_Location_Cd);
			p[3] = Connection.GetParameter
				("@DEST_LOCATION_CD", Dest_Location_Cd);
			p[4] = Connection.GetParameter
				("@ESTIMATE_NO", Estimate_No);
			p[5] = Connection.GetParameter
				("@AP_STATUS_CD", Ap_Status_Cd);
			p[6] = Connection.GetParameter
				("@AR_STATUS_CD", Ar_Status_Cd);
			p[7] = Connection.GetParameter
				("@LINE_STATUS_CD", Line_Status_Cd);
			p[8] = Connection.GetParameter
				("@ESTIMATE_DT", Estimate_Dt);
			p[9] = Connection.GetParameter
				("@ACCRUED_DT", Accrued_Dt);
			p[10] = Connection.GetParameter
				("@MILEAGE", Mileage);
			p[11] = Connection.GetParameter
				("@ORIG_ESTIMATE_ID", Orig_Estimate_ID);
			p[12] = Connection.GetParameter
				("@ESTIMATE_ID", Estimate_ID);
			p[13] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);

			const string sql = @"
				UPDATE T_ESTIMATE SET
					MODIFY_DT = @MODIFY_DT,
					VOYAGE_NO = @VOYAGE_NO,
					ORIG_LOCATION_CD = @ORIG_LOCATION_CD,
					DEST_LOCATION_CD = @DEST_LOCATION_CD,
					ESTIMATE_NO = @ESTIMATE_NO,
					AP_STATUS_CD = @AP_STATUS_CD,
					AR_STATUS_CD = @AR_STATUS_CD,
					LINE_STATUS_CD = @LINE_STATUS_CD,
					ESTIMATE_DT = @ESTIMATE_DT,
					ACCRUED_DT = @ACCRUED_DT,
					MILEAGE = @MILEAGE,
					ORIG_ESTIMATE_ID = @ORIG_ESTIMATE_ID
				WHERE
					ESTIMATE_ID = @ESTIMATE_ID
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
			DbParameter[] p = new DbParameter[1];

			p[0] = Connection.GetParameter
				("@ESTIMATE_ID", Estimate_ID);

			const string sql = @"
				DELETE FROM T_ESTIMATE WHERE
				ESTIMATE_ID=@ESTIMATE_ID";
			return Connection.RunSQL(sql, p);
		}
		#endregion		// #region Insert, Update, Delete

		#region Conversion methods

		public override void LoadFromDataReader(DbDataReader dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataReader: DataReader parameter was null");

			Estimate_ID = ClsConvert.ToInt64Nullable(dr["ESTIMATE_ID"]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER"]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT"]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER"]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT"]);
			Voyage_No = ClsConvert.ToString(dr["VOYAGE_NO"]);
			Orig_Location_Cd = ClsConvert.ToString(dr["ORIG_LOCATION_CD"]);
			Dest_Location_Cd = ClsConvert.ToString(dr["DEST_LOCATION_CD"]);
			Estimate_No = ClsConvert.ToString(dr["ESTIMATE_NO"]);
			Ap_Status_Cd = ClsConvert.ToString(dr["AP_STATUS_CD"]);
			Ar_Status_Cd = ClsConvert.ToString(dr["AR_STATUS_CD"]);
			Line_Status_Cd = ClsConvert.ToString(dr["LINE_STATUS_CD"]);
			Estimate_Dt = ClsConvert.ToDateTimeNullable(dr["ESTIMATE_DT"]);
			Accrued_Dt = ClsConvert.ToDateTimeNullable(dr["ACCRUED_DT"]);
			Mileage = ClsConvert.ToInt64Nullable(dr["MILEAGE"]);
			Orig_Estimate_ID = ClsConvert.ToInt64Nullable(dr["ORIG_ESTIMATE_ID"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Estimate_ID = ClsConvert.ToInt64Nullable(dr["ESTIMATE_ID", v]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER", v]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT", v]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER", v]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT", v]);
			Voyage_No = ClsConvert.ToString(dr["VOYAGE_NO", v]);
			Orig_Location_Cd = ClsConvert.ToString(dr["ORIG_LOCATION_CD", v]);
			Dest_Location_Cd = ClsConvert.ToString(dr["DEST_LOCATION_CD", v]);
			Estimate_No = ClsConvert.ToString(dr["ESTIMATE_NO", v]);
			Ap_Status_Cd = ClsConvert.ToString(dr["AP_STATUS_CD", v]);
			Ar_Status_Cd = ClsConvert.ToString(dr["AR_STATUS_CD", v]);
			Line_Status_Cd = ClsConvert.ToString(dr["LINE_STATUS_CD", v]);
			Estimate_Dt = ClsConvert.ToDateTimeNullable(dr["ESTIMATE_DT", v]);
			Accrued_Dt = ClsConvert.ToDateTimeNullable(dr["ACCRUED_DT", v]);
			Mileage = ClsConvert.ToInt64Nullable(dr["MILEAGE", v]);
			Orig_Estimate_ID = ClsConvert.ToInt64Nullable(dr["ORIG_ESTIMATE_ID", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["ESTIMATE_ID"] = ClsConvert.ToDbObject(Estimate_ID);
			dr["CREATE_USER"] = ClsConvert.ToDbObject(Create_User);
			dr["CREATE_DT"] = ClsConvert.ToDbObject(Create_Dt);
			dr["MODIFY_USER"] = ClsConvert.ToDbObject(Modify_User);
			dr["MODIFY_DT"] = ClsConvert.ToDbObject(Modify_Dt);
			dr["VOYAGE_NO"] = ClsConvert.ToDbObject(Voyage_No);
			dr["ORIG_LOCATION_CD"] = ClsConvert.ToDbObject(Orig_Location_Cd);
			dr["DEST_LOCATION_CD"] = ClsConvert.ToDbObject(Dest_Location_Cd);
			dr["ESTIMATE_NO"] = ClsConvert.ToDbObject(Estimate_No);
			dr["AP_STATUS_CD"] = ClsConvert.ToDbObject(Ap_Status_Cd);
			dr["AR_STATUS_CD"] = ClsConvert.ToDbObject(Ar_Status_Cd);
			dr["LINE_STATUS_CD"] = ClsConvert.ToDbObject(Line_Status_Cd);
			dr["ESTIMATE_DT"] = ClsConvert.ToDbObject(Estimate_Dt);
			dr["ACCRUED_DT"] = ClsConvert.ToDbObject(Accrued_Dt);
			dr["MILEAGE"] = ClsConvert.ToDbObject(Mileage);
			dr["ORIG_ESTIMATE_ID"] = ClsConvert.ToDbObject(Orig_Estimate_ID);
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

		public static ClsEstimate GetUsingKey(Int64 Estimate_ID)
		{
			object[] vals = new object[] {Estimate_ID};
			DataRow dr = Connection.GetDataRowUsingKey
				(TableName, GetPrimaryKeys(), vals);
			return ( dr == null ) ? null : new ClsEstimate(dr);
		}
		public static DataTable GetAll(string Ap_Status_Cd, string Dest_Location_Cd,
			string Orig_Location_Cd, string Line_Status_Cd,
			Int64? Orig_Estimate_ID, string Ar_Status_Cd)
		{
			List<DbParameter> lst = new List<DbParameter>();	
			StringBuilder sb = new StringBuilder();
		
			if( string.IsNullOrEmpty(Ap_Status_Cd) == false )
			{
				lst.Add(Connection.GetParameter("@AP_STATUS_CD", Ap_Status_Cd));
				sb.Append(" WHERE T_ESTIMATE.AP_STATUS_CD=@AP_STATUS_CD");
			}
			if( string.IsNullOrEmpty(Dest_Location_Cd) == false )
			{
				lst.Add(Connection.GetParameter("@DEST_LOCATION_CD", Dest_Location_Cd));
				sb.AppendFormat(" {0} T_ESTIMATE.DEST_LOCATION_CD=@DEST_LOCATION_CD",
					sb.Length > 0 ? "AND" : "WHERE");
			}
			if( string.IsNullOrEmpty(Orig_Location_Cd) == false )
			{
				lst.Add(Connection.GetParameter("@ORIG_LOCATION_CD", Orig_Location_Cd));
				sb.AppendFormat(" {0} T_ESTIMATE.ORIG_LOCATION_CD=@ORIG_LOCATION_CD",
					sb.Length > 0 ? "AND" : "WHERE");
			}
			if( string.IsNullOrEmpty(Line_Status_Cd) == false )
			{
				lst.Add(Connection.GetParameter("@LINE_STATUS_CD", Line_Status_Cd));
				sb.AppendFormat(" {0} T_ESTIMATE.LINE_STATUS_CD=@LINE_STATUS_CD",
					sb.Length > 0 ? "AND" : "WHERE");
			}
			if( Orig_Estimate_ID != null && Orig_Estimate_ID > 0 )
			{
				lst.Add(Connection.GetParameter("@ORIG_ESTIMATE_ID", Orig_Estimate_ID));
				sb.AppendFormat(" {0} T_ESTIMATE.ORIG_ESTIMATE_ID=@ORIG_ESTIMATE_ID",
					sb.Length > 0 ? "AND" : "WHERE");
			}
			if( string.IsNullOrEmpty(Ar_Status_Cd) == false )
			{
				lst.Add(Connection.GetParameter("@AR_STATUS_CD", Ar_Status_Cd));
				sb.AppendFormat(" {0} T_ESTIMATE.AR_STATUS_CD=@AR_STATUS_CD",
					sb.Length > 0 ? "AND" : "WHERE");
			}
			sb.Insert(0, SelectSQL);
			return Connection.GetDataTable(sb.ToString(), lst.ToArray());
		}
		#endregion		// #region Static Methods
	}
}