using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsBolLine : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ArcSys"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "T_BOL_LINE";
		public const int PrimaryKeyCount = 1;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] { "BOL_ID" };
		}

		public const string SelectSQL = "SELECT * FROM T_BOL_LINE";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Create_UserMax = 30;
		public const int Modify_UserMax = 30;
		public const int Bol_NoMax = 20;
		public const int Booking_NoMax = 20;
		public const int Bol_StatusMax = 10;
		public const int Final_Manifest_FlgMax = 1;
		public const int Voyage_NoMax = 10;
		public const int Vessel_NoMax = 10;
		public const int Service_CdMax = 10;
		public const int Deleted_FlgMax = 1;
		public const int Bol_Create_UserMax = 20;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected Int64? _Bol_ID;
		protected string _Create_User;
		protected DateTime? _Create_Dt;
		protected string _Modify_User;
		protected DateTime? _Modify_Dt;
		protected string _Bol_No;
		protected Int64? _Booking_Line_ID;
		protected string _Booking_No;
		protected string _Bol_Status;
		protected string _Final_Manifest_Flg;
		protected string _Voyage_No;
		protected string _Vessel_No;
		protected string _Service_Cd;
		protected string _Deleted_Flg;
		protected DateTime? _Bol_Create_Dt;
		protected string _Bol_Create_User;

		#endregion	// #region Column Fields

		#region Column Properties

		public Int64? Bol_ID
		{
			get { return _Bol_ID; }
			set
			{
				if( _Bol_ID == value ) return;
		
				_Bol_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Bol_ID");
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
		public string Bol_No
		{
			get { return _Bol_No; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Bol_No, val, false) == 0 ) return;
		
				if( val != null && val.Length > Bol_NoMax )
					_Bol_No = val.Substring(0, (int)Bol_NoMax);
				else
					_Bol_No = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Bol_No");
			}
		}
		public Int64? Booking_Line_ID
		{
			get { return _Booking_Line_ID; }
			set
			{
				if( _Booking_Line_ID == value ) return;
		
				_Booking_Line_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Booking_Line_ID");
			}
		}
		public string Booking_No
		{
			get { return _Booking_No; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Booking_No, val, false) == 0 ) return;
		
				if( val != null && val.Length > Booking_NoMax )
					_Booking_No = val.Substring(0, (int)Booking_NoMax);
				else
					_Booking_No = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Booking_No");
			}
		}
		public string Bol_Status
		{
			get { return _Bol_Status; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Bol_Status, val, false) == 0 ) return;
		
				if( val != null && val.Length > Bol_StatusMax )
					_Bol_Status = val.Substring(0, (int)Bol_StatusMax);
				else
					_Bol_Status = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Bol_Status");
			}
		}
		public string Final_Manifest_Flg
		{
			get { return _Final_Manifest_Flg; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Final_Manifest_Flg, val, false) == 0 ) return;
		
				if( val != null && val.Length > Final_Manifest_FlgMax )
					_Final_Manifest_Flg = val.Substring(0, (int)Final_Manifest_FlgMax);
				else
					_Final_Manifest_Flg = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Final_Manifest_Flg");
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
		public string Vessel_No
		{
			get { return _Vessel_No; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Vessel_No, val, false) == 0 ) return;
		
				if( val != null && val.Length > Vessel_NoMax )
					_Vessel_No = val.Substring(0, (int)Vessel_NoMax);
				else
					_Vessel_No = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Vessel_No");
			}
		}
		public string Service_Cd
		{
			get { return _Service_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Service_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Service_CdMax )
					_Service_Cd = val.Substring(0, (int)Service_CdMax);
				else
					_Service_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Service_Cd");
			}
		}
		public string Deleted_Flg
		{
			get { return _Deleted_Flg; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Deleted_Flg, val, false) == 0 ) return;
		
				if( val != null && val.Length > Deleted_FlgMax )
					_Deleted_Flg = val.Substring(0, (int)Deleted_FlgMax);
				else
					_Deleted_Flg = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Deleted_Flg");
			}
		}
		public DateTime? Bol_Create_Dt
		{
			get { return _Bol_Create_Dt; }
			set
			{
				DateTime? val = ( value != null )
					? (DateTime?)value.Value.Date : null;
		
				if( _Bol_Create_Dt == val ) return;
		
				_Bol_Create_Dt = val;
				_IsDirty = true;
				NotifyPropertyChanged("Bol_Create_Dt");
			}
		}
		public string Bol_Create_User
		{
			get { return _Bol_Create_User; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Bol_Create_User, val, false) == 0 ) return;
		
				if( val != null && val.Length > Bol_Create_UserMax )
					_Bol_Create_User = val.Substring(0, (int)Bol_Create_UserMax);
				else
					_Bol_Create_User = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Bol_Create_User");
			}
		}

		#endregion	// #region Column Properties

		#region Foreign Key Fields



		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties



		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsBolLine() : base() {}
		public ClsBolLine(DataRow dr) : base(dr) {}
		public ClsBolLine(ClsBolLine src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Bol_ID = null;
			Create_User = null;
			Create_Dt = null;
			Modify_User = null;
			Modify_Dt = null;
			Bol_No = null;
			Booking_Line_ID = null;
			Booking_No = null;
			Bol_Status = null;
			Final_Manifest_Flg = null;
			Voyage_No = null;
			Vessel_No = null;
			Service_Cd = null;
			Deleted_Flg = null;
			Bol_Create_Dt = null;
			Bol_Create_User = null;
		}

		public void CopyFrom(ClsBolLine src)
		{
			Bol_ID = src._Bol_ID;
			Create_User = src._Create_User;
			Create_Dt = src._Create_Dt;
			Modify_User = src._Modify_User;
			Modify_Dt = src._Modify_Dt;
			Bol_No = src._Bol_No;
			Booking_Line_ID = src._Booking_Line_ID;
			Booking_No = src._Booking_No;
			Bol_Status = src._Bol_Status;
			Final_Manifest_Flg = src._Final_Manifest_Flg;
			Voyage_No = src._Voyage_No;
			Vessel_No = src._Vessel_No;
			Service_Cd = src._Service_Cd;
			Deleted_Flg = src._Deleted_Flg;
			Bol_Create_Dt = src._Bol_Create_Dt;
			Bol_Create_User = src._Bol_Create_User;
		}

		public override bool ReloadFromDB()
		{
			ClsBolLine tmp = ClsBolLine.GetUsingKey(Bol_ID.Value);
			if( tmp != null ) CopyFrom(tmp);

			ResetFKs();
			OnReload();

			return ( tmp != null );
		}

		public override void ResetFKs()
		{

		}
		#endregion		// #region Init methods

		#region Insert, Update, Delete

		public override int Insert()
		{

			DbParameter[] p = new DbParameter[16];

			p[0] = Connection.GetParameter
				("@BOL_ID", Bol_ID);
			p[1] = Connection.GetParameter
				("@BOL_NO", Bol_No);
			p[2] = Connection.GetParameter
				("@BOOKING_LINE_ID", Booking_Line_ID);
			p[3] = Connection.GetParameter
				("@BOOKING_NO", Booking_No);
			p[4] = Connection.GetParameter
				("@BOL_STATUS", Bol_Status);
			p[5] = Connection.GetParameter
				("@FINAL_MANIFEST_FLG", Final_Manifest_Flg);
			p[6] = Connection.GetParameter
				("@VOYAGE_NO", Voyage_No);
			p[7] = Connection.GetParameter
				("@VESSEL_NO", Vessel_No);
			p[8] = Connection.GetParameter
				("@SERVICE_CD", Service_Cd);
			p[9] = Connection.GetParameter
				("@DELETED_FLG", Deleted_Flg);
			p[10] = Connection.GetParameter
				("@BOL_CREATE_DT", Bol_Create_Dt);
			p[11] = Connection.GetParameter
				("@BOL_CREATE_USER", Bol_Create_User);
			p[12] = Connection.GetParameter
				("@CREATE_USER", Create_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Create_UserMax);
			p[13] = Connection.GetParameter
				("@CREATE_DT", Create_Dt, ParameterDirection.Output, DbType.DateTime, 0);
			p[14] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);
			p[15] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.Output, DbType.DateTime, 0);

			const string sql = @"
				INSERT INTO T_BOL_LINE
					(BOL_ID, BOL_NO, BOOKING_LINE_ID,
					BOOKING_NO, BOL_STATUS, FINAL_MANIFEST_FLG,
					VOYAGE_NO, VESSEL_NO, SERVICE_CD,
					DELETED_FLG, BOL_CREATE_DT, BOL_CREATE_USER)
				VALUES
					(@BOL_ID, @BOL_NO, @BOOKING_LINE_ID,
					@BOOKING_NO, @BOL_STATUS, @FINAL_MANIFEST_FLG,
					@VOYAGE_NO, @VESSEL_NO, @SERVICE_CD,
					@DELETED_FLG, @BOL_CREATE_DT, @BOL_CREATE_USER)
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
				("@MODIFY_DT", Modify_Dt, ParameterDirection.InputOutput, DbType.DateTime, 0);
			p[1] = Connection.GetParameter
				("@BOL_NO", Bol_No);
			p[2] = Connection.GetParameter
				("@BOOKING_LINE_ID", Booking_Line_ID);
			p[3] = Connection.GetParameter
				("@BOOKING_NO", Booking_No);
			p[4] = Connection.GetParameter
				("@BOL_STATUS", Bol_Status);
			p[5] = Connection.GetParameter
				("@FINAL_MANIFEST_FLG", Final_Manifest_Flg);
			p[6] = Connection.GetParameter
				("@VOYAGE_NO", Voyage_No);
			p[7] = Connection.GetParameter
				("@VESSEL_NO", Vessel_No);
			p[8] = Connection.GetParameter
				("@SERVICE_CD", Service_Cd);
			p[9] = Connection.GetParameter
				("@DELETED_FLG", Deleted_Flg);
			p[10] = Connection.GetParameter
				("@BOL_CREATE_DT", Bol_Create_Dt);
			p[11] = Connection.GetParameter
				("@BOL_CREATE_USER", Bol_Create_User);
			p[12] = Connection.GetParameter
				("@BOL_ID", Bol_ID);
			p[13] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);

			const string sql = @"
				UPDATE T_BOL_LINE SET
					MODIFY_DT = @MODIFY_DT,
					BOL_NO = @BOL_NO,
					BOOKING_LINE_ID = @BOOKING_LINE_ID,
					BOOKING_NO = @BOOKING_NO,
					BOL_STATUS = @BOL_STATUS,
					FINAL_MANIFEST_FLG = @FINAL_MANIFEST_FLG,
					VOYAGE_NO = @VOYAGE_NO,
					VESSEL_NO = @VESSEL_NO,
					SERVICE_CD = @SERVICE_CD,
					DELETED_FLG = @DELETED_FLG,
					BOL_CREATE_DT = @BOL_CREATE_DT,
					BOL_CREATE_USER = @BOL_CREATE_USER
				WHERE
					BOL_ID = @BOL_ID
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
				("@BOL_ID", Bol_ID);

			const string sql = @"
				DELETE FROM T_BOL_LINE WHERE
				BOL_ID=@BOL_ID";
			return Connection.RunSQL(sql, p);
		}
		#endregion		// #region Insert, Update, Delete

		#region Conversion methods

		public override void LoadFromDataReader(DbDataReader dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataReader: DataReader parameter was null");

			Bol_ID = ClsConvert.ToInt64Nullable(dr["BOL_ID"]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER"]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT"]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER"]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT"]);
			Bol_No = ClsConvert.ToString(dr["BOL_NO"]);
			Booking_Line_ID = ClsConvert.ToInt64Nullable(dr["BOOKING_LINE_ID"]);
			Booking_No = ClsConvert.ToString(dr["BOOKING_NO"]);
			Bol_Status = ClsConvert.ToString(dr["BOL_STATUS"]);
			Final_Manifest_Flg = ClsConvert.ToString(dr["FINAL_MANIFEST_FLG"]);
			Voyage_No = ClsConvert.ToString(dr["VOYAGE_NO"]);
			Vessel_No = ClsConvert.ToString(dr["VESSEL_NO"]);
			Service_Cd = ClsConvert.ToString(dr["SERVICE_CD"]);
			Deleted_Flg = ClsConvert.ToString(dr["DELETED_FLG"]);
			Bol_Create_Dt = ClsConvert.ToDateTimeNullable(dr["BOL_CREATE_DT"]);
			Bol_Create_User = ClsConvert.ToString(dr["BOL_CREATE_USER"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Bol_ID = ClsConvert.ToInt64Nullable(dr["BOL_ID", v]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER", v]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT", v]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER", v]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT", v]);
			Bol_No = ClsConvert.ToString(dr["BOL_NO", v]);
			Booking_Line_ID = ClsConvert.ToInt64Nullable(dr["BOOKING_LINE_ID", v]);
			Booking_No = ClsConvert.ToString(dr["BOOKING_NO", v]);
			Bol_Status = ClsConvert.ToString(dr["BOL_STATUS", v]);
			Final_Manifest_Flg = ClsConvert.ToString(dr["FINAL_MANIFEST_FLG", v]);
			Voyage_No = ClsConvert.ToString(dr["VOYAGE_NO", v]);
			Vessel_No = ClsConvert.ToString(dr["VESSEL_NO", v]);
			Service_Cd = ClsConvert.ToString(dr["SERVICE_CD", v]);
			Deleted_Flg = ClsConvert.ToString(dr["DELETED_FLG", v]);
			Bol_Create_Dt = ClsConvert.ToDateTimeNullable(dr["BOL_CREATE_DT", v]);
			Bol_Create_User = ClsConvert.ToString(dr["BOL_CREATE_USER", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["BOL_ID"] = ClsConvert.ToDbObject(Bol_ID);
			dr["CREATE_USER"] = ClsConvert.ToDbObject(Create_User);
			dr["CREATE_DT"] = ClsConvert.ToDbObject(Create_Dt);
			dr["MODIFY_USER"] = ClsConvert.ToDbObject(Modify_User);
			dr["MODIFY_DT"] = ClsConvert.ToDbObject(Modify_Dt);
			dr["BOL_NO"] = ClsConvert.ToDbObject(Bol_No);
			dr["BOOKING_LINE_ID"] = ClsConvert.ToDbObject(Booking_Line_ID);
			dr["BOOKING_NO"] = ClsConvert.ToDbObject(Booking_No);
			dr["BOL_STATUS"] = ClsConvert.ToDbObject(Bol_Status);
			dr["FINAL_MANIFEST_FLG"] = ClsConvert.ToDbObject(Final_Manifest_Flg);
			dr["VOYAGE_NO"] = ClsConvert.ToDbObject(Voyage_No);
			dr["VESSEL_NO"] = ClsConvert.ToDbObject(Vessel_No);
			dr["SERVICE_CD"] = ClsConvert.ToDbObject(Service_Cd);
			dr["DELETED_FLG"] = ClsConvert.ToDbObject(Deleted_Flg);
			dr["BOL_CREATE_DT"] = ClsConvert.ToDbObject(Bol_Create_Dt);
			dr["BOL_CREATE_USER"] = ClsConvert.ToDbObject(Bol_Create_User);
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

		public static ClsBolLine GetUsingKey(Int64 Bol_ID)
		{
			object[] vals = new object[] {Bol_ID};
			DataRow dr = Connection.GetDataRowUsingKey
				(TableName, GetPrimaryKeys(), vals);
			return ( dr == null ) ? null : new ClsBolLine(dr);
		}

		#endregion		// #region Static Methods
	}
}