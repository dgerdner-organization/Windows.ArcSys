using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ACMS.Business
{
	public partial class ClsBookingItv : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ACMS"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "T_BOOKING_ITV";
		public const int PrimaryKeyCount = 1;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] { "ACTIVITY_ID" };
		}

		public const string SelectSQL = "SELECT * FROM T_BOOKING_ITV";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Booking_IDMax = 30;
		public const int Booking_SubMax = 5;
		public const int Activity_CodeMax = 2;
		public const int Activity_UserMax = 30;
		public const int Confirm_CdMax = 2;
		public const int Voyage_NoMax = 10;
		public const int Location_CdMax = 10;
		public const int Terminal_CdMax = 10;
		public const int Sub_TcnMax = 30;
		public const int Modify_UserMax = 20;
		public const int NotesMax = 1000;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected Int64? _Activity_ID;
		protected string _Booking_ID;
		protected string _Booking_Sub;
		protected string _Activity_Code;
		protected DateTime? _Activity_Dt;
		protected string _Activity_User;
		protected string _Confirm_Cd;
		protected string _Voyage_No;
		protected string _Location_Cd;
		protected Int64? _Item_No;
		protected string _Terminal_Cd;
		protected Int64? _Trans_Ctl_No;
		protected string _Sub_Tcn;
		protected DateTime? _Create_Dt;
		protected string _Modify_User;
		protected DateTime? _Modify_Dt;
		protected string _Notes;

		#endregion	// #region Column Fields

		#region Column Properties

		public Int64? Activity_ID
		{
			get { return _Activity_ID; }
			set
			{
				if( _Activity_ID == value ) return;
		
				_Activity_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Activity_ID");
			}
		}
		public string Booking_ID
		{
			get { return _Booking_ID; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Booking_ID, val, false) == 0 ) return;
		
				if( val != null && val.Length > Booking_IDMax )
					_Booking_ID = val.Substring(0, (int)Booking_IDMax);
				else
					_Booking_ID = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Booking_ID");
			}
		}
		public string Booking_Sub
		{
			get { return _Booking_Sub; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Booking_Sub, val, false) == 0 ) return;
		
				if( val != null && val.Length > Booking_SubMax )
					_Booking_Sub = val.Substring(0, (int)Booking_SubMax);
				else
					_Booking_Sub = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Booking_Sub");
			}
		}
		public string Activity_Code
		{
			get { return _Activity_Code; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Activity_Code, val, false) == 0 ) return;
		
				if( val != null && val.Length > Activity_CodeMax )
					_Activity_Code = val.Substring(0, (int)Activity_CodeMax);
				else
					_Activity_Code = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Activity_Code");
			}
		}
		public DateTime? Activity_Dt
		{
			get { return _Activity_Dt; }
			set
			{
				if( _Activity_Dt == value ) return;
		
				_Activity_Dt = value;
				_IsDirty = true;
				NotifyPropertyChanged("Activity_Dt");
			}
		}
		public string Activity_User
		{
			get { return _Activity_User; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Activity_User, val, false) == 0 ) return;
		
				if( val != null && val.Length > Activity_UserMax )
					_Activity_User = val.Substring(0, (int)Activity_UserMax);
				else
					_Activity_User = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Activity_User");
			}
		}
		public string Confirm_Cd
		{
			get { return _Confirm_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Confirm_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Confirm_CdMax )
					_Confirm_Cd = val.Substring(0, (int)Confirm_CdMax);
				else
					_Confirm_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Confirm_Cd");
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
		public Int64? Item_No
		{
			get { return _Item_No; }
			set
			{
				if( _Item_No == value ) return;
		
				_Item_No = value;
				_IsDirty = true;
				NotifyPropertyChanged("Item_No");
			}
		}
		public string Terminal_Cd
		{
			get { return _Terminal_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Terminal_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Terminal_CdMax )
					_Terminal_Cd = val.Substring(0, (int)Terminal_CdMax);
				else
					_Terminal_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Terminal_Cd");
			}
		}
		public Int64? Trans_Ctl_No
		{
			get { return _Trans_Ctl_No; }
			set
			{
				if( _Trans_Ctl_No == value ) return;
		
				_Trans_Ctl_No = value;
				_IsDirty = true;
				NotifyPropertyChanged("Trans_Ctl_No");
			}
		}
		public string Sub_Tcn
		{
			get { return _Sub_Tcn; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Sub_Tcn, val, false) == 0 ) return;
		
				if( val != null && val.Length > Sub_TcnMax )
					_Sub_Tcn = val.Substring(0, (int)Sub_TcnMax);
				else
					_Sub_Tcn = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Sub_Tcn");
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
		public string Notes
		{
			get { return _Notes; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Notes, val, false) == 0 ) return;
		
				if( val != null && val.Length > NotesMax )
					_Notes = val.Substring(0, (int)NotesMax);
				else
					_Notes = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Notes");
			}
		}

		#endregion	// #region Column Properties

		#region Foreign Key Fields



		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties



		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsBookingItv() : base() {}
		public ClsBookingItv(DataRow dr) : base(dr) {}
		public ClsBookingItv(ClsBookingItv src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Activity_ID = null;
			Booking_ID = null;
			Booking_Sub = null;
			Activity_Code = null;
			Activity_Dt = null;
			Activity_User = null;
			Confirm_Cd = null;
			Voyage_No = null;
			Location_Cd = null;
			Item_No = null;
			Terminal_Cd = null;
			Trans_Ctl_No = null;
			Sub_Tcn = null;
			Create_Dt = null;
			Modify_User = null;
			Modify_Dt = null;
			Notes = null;
		}

		public void CopyFrom(ClsBookingItv src)
		{
			Activity_ID = src._Activity_ID;
			Booking_ID = src._Booking_ID;
			Booking_Sub = src._Booking_Sub;
			Activity_Code = src._Activity_Code;
			Activity_Dt = src._Activity_Dt;
			Activity_User = src._Activity_User;
			Confirm_Cd = src._Confirm_Cd;
			Voyage_No = src._Voyage_No;
			Location_Cd = src._Location_Cd;
			Item_No = src._Item_No;
			Terminal_Cd = src._Terminal_Cd;
			Trans_Ctl_No = src._Trans_Ctl_No;
			Sub_Tcn = src._Sub_Tcn;
			Create_Dt = src._Create_Dt;
			Modify_User = src._Modify_User;
			Modify_Dt = src._Modify_Dt;
			Notes = src._Notes;
		}

		public override bool ReloadFromDB()
		{
			ClsBookingItv tmp = ClsBookingItv.GetUsingKey(Activity_ID.Value);
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

			DbParameter[] p = new DbParameter[17];

			p[0] = Connection.GetParameter
				("@ACTIVITY_ID", Activity_ID);
			p[1] = Connection.GetParameter
				("@BOOKING_ID", Booking_ID);
			p[2] = Connection.GetParameter
				("@BOOKING_SUB", Booking_Sub);
			p[3] = Connection.GetParameter
				("@ACTIVITY_CODE", Activity_Code);
			p[4] = Connection.GetParameter
				("@ACTIVITY_DT", Activity_Dt);
			p[5] = Connection.GetParameter
				("@ACTIVITY_USER", Activity_User);
			p[6] = Connection.GetParameter
				("@CONFIRM_CD", Confirm_Cd);
			p[7] = Connection.GetParameter
				("@VOYAGE_NO", Voyage_No);
			p[8] = Connection.GetParameter
				("@LOCATION_CD", Location_Cd);
			p[9] = Connection.GetParameter
				("@ITEM_NO", Item_No);
			p[10] = Connection.GetParameter
				("@TERMINAL_CD", Terminal_Cd);
			p[11] = Connection.GetParameter
				("@TRANS_CTL_NO", Trans_Ctl_No);
			p[12] = Connection.GetParameter
				("@SUB_TCN", Sub_Tcn);
			p[13] = Connection.GetParameter
				("@NOTES", Notes);
			p[14] = Connection.GetParameter
				("@CREATE_DT", Create_Dt, ParameterDirection.Output, DbType.DateTime, 0);
			p[15] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);
			p[16] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.Output, DbType.DateTime, 0);

			const string sql = @"
				INSERT INTO T_BOOKING_ITV
					(ACTIVITY_ID, BOOKING_ID, BOOKING_SUB,
					ACTIVITY_CODE, ACTIVITY_DT, ACTIVITY_USER,
					CONFIRM_CD, VOYAGE_NO, LOCATION_CD,
					ITEM_NO, TERMINAL_CD, TRANS_CTL_NO,
					SUB_TCN, NOTES)
				VALUES
					(@ACTIVITY_ID, @BOOKING_ID, @BOOKING_SUB,
					@ACTIVITY_CODE, @ACTIVITY_DT, @ACTIVITY_USER,
					@CONFIRM_CD, @VOYAGE_NO, @LOCATION_CD,
					@ITEM_NO, @TERMINAL_CD, @TRANS_CTL_NO,
					@SUB_TCN, @NOTES)
				RETURNING
					CREATE_DT, MODIFY_USER, MODIFY_DT
				INTO
					@CREATE_DT, @MODIFY_USER, @MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Create_Dt = ClsConvert.ToDateTimeNullable(p[14].Value);
			Modify_User = ClsConvert.ToString(p[15].Value);
			Modify_Dt = ClsConvert.ToDateTimeNullable(p[16].Value);
			return ret;
		}
		public override int Update()
		{
			DbParameter[] p = new DbParameter[16];

			p[0] = Connection.GetParameter
				("@BOOKING_ID", Booking_ID);
			p[1] = Connection.GetParameter
				("@BOOKING_SUB", Booking_Sub);
			p[2] = Connection.GetParameter
				("@ACTIVITY_CODE", Activity_Code);
			p[3] = Connection.GetParameter
				("@ACTIVITY_DT", Activity_Dt);
			p[4] = Connection.GetParameter
				("@ACTIVITY_USER", Activity_User);
			p[5] = Connection.GetParameter
				("@CONFIRM_CD", Confirm_Cd);
			p[6] = Connection.GetParameter
				("@VOYAGE_NO", Voyage_No);
			p[7] = Connection.GetParameter
				("@LOCATION_CD", Location_Cd);
			p[8] = Connection.GetParameter
				("@ITEM_NO", Item_No);
			p[9] = Connection.GetParameter
				("@TERMINAL_CD", Terminal_Cd);
			p[10] = Connection.GetParameter
				("@TRANS_CTL_NO", Trans_Ctl_No);
			p[11] = Connection.GetParameter
				("@SUB_TCN", Sub_Tcn);
			p[12] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.InputOutput, DbType.DateTime, 0);
			p[13] = Connection.GetParameter
				("@NOTES", Notes);
			p[14] = Connection.GetParameter
				("@ACTIVITY_ID", Activity_ID);
			p[15] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);

			const string sql = @"
				UPDATE T_BOOKING_ITV SET
					BOOKING_ID = @BOOKING_ID,
					BOOKING_SUB = @BOOKING_SUB,
					ACTIVITY_CODE = @ACTIVITY_CODE,
					ACTIVITY_DT = @ACTIVITY_DT,
					ACTIVITY_USER = @ACTIVITY_USER,
					CONFIRM_CD = @CONFIRM_CD,
					VOYAGE_NO = @VOYAGE_NO,
					LOCATION_CD = @LOCATION_CD,
					ITEM_NO = @ITEM_NO,
					TERMINAL_CD = @TERMINAL_CD,
					TRANS_CTL_NO = @TRANS_CTL_NO,
					SUB_TCN = @SUB_TCN,
					MODIFY_DT = @MODIFY_DT,
					NOTES = @NOTES
				WHERE
					ACTIVITY_ID = @ACTIVITY_ID
				RETURNING
					MODIFY_USER, MODIFY_DT
				INTO
					@MODIFY_USER, @MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Modify_Dt = ClsConvert.ToDateTimeNullable(p[12].Value);
			Modify_User = ClsConvert.ToString(p[15].Value);
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

			Activity_ID = ClsConvert.ToInt64Nullable(dr["ACTIVITY_ID"]);
			Booking_ID = ClsConvert.ToString(dr["BOOKING_ID"]);
			Booking_Sub = ClsConvert.ToString(dr["BOOKING_SUB"]);
			Activity_Code = ClsConvert.ToString(dr["ACTIVITY_CODE"]);
			Activity_Dt = ClsConvert.ToDateTimeNullable(dr["ACTIVITY_DT"]);
			Activity_User = ClsConvert.ToString(dr["ACTIVITY_USER"]);
			Confirm_Cd = ClsConvert.ToString(dr["CONFIRM_CD"]);
			Voyage_No = ClsConvert.ToString(dr["VOYAGE_NO"]);
			Location_Cd = ClsConvert.ToString(dr["LOCATION_CD"]);
			Item_No = ClsConvert.ToInt64Nullable(dr["ITEM_NO"]);
			Terminal_Cd = ClsConvert.ToString(dr["TERMINAL_CD"]);
			Trans_Ctl_No = ClsConvert.ToInt64Nullable(dr["TRANS_CTL_NO"]);
			Sub_Tcn = ClsConvert.ToString(dr["SUB_TCN"]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT"]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER"]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT"]);
			Notes = ClsConvert.ToString(dr["NOTES"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Activity_ID = ClsConvert.ToInt64Nullable(dr["ACTIVITY_ID", v]);
			Booking_ID = ClsConvert.ToString(dr["BOOKING_ID", v]);
			Booking_Sub = ClsConvert.ToString(dr["BOOKING_SUB", v]);
			Activity_Code = ClsConvert.ToString(dr["ACTIVITY_CODE", v]);
			Activity_Dt = ClsConvert.ToDateTimeNullable(dr["ACTIVITY_DT", v]);
			Activity_User = ClsConvert.ToString(dr["ACTIVITY_USER", v]);
			Confirm_Cd = ClsConvert.ToString(dr["CONFIRM_CD", v]);
			Voyage_No = ClsConvert.ToString(dr["VOYAGE_NO", v]);
			Location_Cd = ClsConvert.ToString(dr["LOCATION_CD", v]);
			Item_No = ClsConvert.ToInt64Nullable(dr["ITEM_NO", v]);
			Terminal_Cd = ClsConvert.ToString(dr["TERMINAL_CD", v]);
			Trans_Ctl_No = ClsConvert.ToInt64Nullable(dr["TRANS_CTL_NO", v]);
			Sub_Tcn = ClsConvert.ToString(dr["SUB_TCN", v]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT", v]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER", v]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT", v]);
			Notes = ClsConvert.ToString(dr["NOTES", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["ACTIVITY_ID"] = ClsConvert.ToDbObject(Activity_ID);
			dr["BOOKING_ID"] = ClsConvert.ToDbObject(Booking_ID);
			dr["BOOKING_SUB"] = ClsConvert.ToDbObject(Booking_Sub);
			dr["ACTIVITY_CODE"] = ClsConvert.ToDbObject(Activity_Code);
			dr["ACTIVITY_DT"] = ClsConvert.ToDbObject(Activity_Dt);
			dr["ACTIVITY_USER"] = ClsConvert.ToDbObject(Activity_User);
			dr["CONFIRM_CD"] = ClsConvert.ToDbObject(Confirm_Cd);
			dr["VOYAGE_NO"] = ClsConvert.ToDbObject(Voyage_No);
			dr["LOCATION_CD"] = ClsConvert.ToDbObject(Location_Cd);
			dr["ITEM_NO"] = ClsConvert.ToDbObject(Item_No);
			dr["TERMINAL_CD"] = ClsConvert.ToDbObject(Terminal_Cd);
			dr["TRANS_CTL_NO"] = ClsConvert.ToDbObject(Trans_Ctl_No);
			dr["SUB_TCN"] = ClsConvert.ToDbObject(Sub_Tcn);
			dr["CREATE_DT"] = ClsConvert.ToDbObject(Create_Dt);
			dr["MODIFY_USER"] = ClsConvert.ToDbObject(Modify_User);
			dr["MODIFY_DT"] = ClsConvert.ToDbObject(Modify_Dt);
			dr["NOTES"] = ClsConvert.ToDbObject(Notes);
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

		public static ClsBookingItv GetUsingKey(Int64 Activity_ID)
		{
			object[] vals = new object[] {Activity_ID};
			DataRow dr = Connection.GetDataRowUsingKey
				(TableName, GetPrimaryKeys(), vals);
			return ( dr == null ) ? null : new ClsBookingItv(dr);
		}

		#endregion		// #region Static Methods
	}
}