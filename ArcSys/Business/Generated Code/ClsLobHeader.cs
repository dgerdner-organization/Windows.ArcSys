using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsLobHeader : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
            get { return ClsConMgr.Manager["ArcSys"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "T_LOB_HEADER";
		public const int PrimaryKeyCount = 1;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] { "LOB_HEADER_ID" };
		}

		public const string SelectSQL = "SELECT * FROM T_LOB_HEADER";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Create_UserMax = 30;
		public const int Modify_UserMax = 30;
		public const int Voyage_NoMax = 10;
		public const int Vessel_NmMax = 50;
		public const int Military_Voyage_NoMax = 10;
		public const int Pol_Location_CdMax = 10;
		public const int Confirm_FlgMax = 1;
		public const int NotesMax = 100;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected Int64? _Lob_Header_ID;
		protected string _Create_User;
		protected DateTime? _Create_Dt;
		protected string _Modify_User;
		protected DateTime? _Modify_Dt;
		protected string _Voyage_No;
		protected string _Vessel_Nm;
		protected string _Military_Voyage_No;
		protected string _Pol_Location_Cd;
		protected string _Confirm_Flg;
		protected string _Notes;
		protected Int64? _Version_No;
		protected DateTime? _Transmit_Dt;
		protected DateTime? _Sail_Dt;

		#endregion	// #region Column Fields

		#region Column Properties

		public Int64? Lob_Header_ID
		{
			get { return _Lob_Header_ID; }
			set
			{
				if( _Lob_Header_ID == value ) return;
		
				_Lob_Header_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Lob_Header_ID");
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
		public string Vessel_Nm
		{
			get { return _Vessel_Nm; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Vessel_Nm, val, false) == 0 ) return;
		
				if( val != null && val.Length > Vessel_NmMax )
					_Vessel_Nm = val.Substring(0, (int)Vessel_NmMax);
				else
					_Vessel_Nm = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Vessel_Nm");
			}
		}
		public string Military_Voyage_No
		{
			get { return _Military_Voyage_No; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Military_Voyage_No, val, false) == 0 ) return;
		
				if( val != null && val.Length > Military_Voyage_NoMax )
					_Military_Voyage_No = val.Substring(0, (int)Military_Voyage_NoMax);
				else
					_Military_Voyage_No = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Military_Voyage_No");
			}
		}
		public string Pol_Location_Cd
		{
			get { return _Pol_Location_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Pol_Location_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Pol_Location_CdMax )
					_Pol_Location_Cd = val.Substring(0, (int)Pol_Location_CdMax);
				else
					_Pol_Location_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Pol_Location_Cd");
			}
		}
		public string Confirm_Flg
		{
			get { return _Confirm_Flg; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Confirm_Flg, val, false) == 0 ) return;
		
				if( val != null && val.Length > Confirm_FlgMax )
					_Confirm_Flg = val.Substring(0, (int)Confirm_FlgMax);
				else
					_Confirm_Flg = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Confirm_Flg");
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
		public Int64? Version_No
		{
			get { return _Version_No; }
			set
			{
				if( _Version_No == value ) return;
		
				_Version_No = value;
				_IsDirty = true;
				NotifyPropertyChanged("Version_No");
			}
		}
		public DateTime? Transmit_Dt
		{
			get { return _Transmit_Dt; }
			set
			{
				DateTime? val = ( value != null )
					? (DateTime?)value.Value.Date : null;
		
				if( _Transmit_Dt == val ) return;
		
				_Transmit_Dt = val;
				_IsDirty = true;
				NotifyPropertyChanged("Transmit_Dt");
			}
		}
		public DateTime? Sail_Dt
		{
			get { return _Sail_Dt; }
			set
			{
				DateTime? val = ( value != null )
					? (DateTime?)value.Value.Date : null;
		
				if( _Sail_Dt == val ) return;
		
				_Sail_Dt = val;
				_IsDirty = true;
				NotifyPropertyChanged("Sail_Dt");
			}
		}

		#endregion	// #region Column Properties

		#region Foreign Key Fields



		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties



		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsLobHeader() : base() {}
		public ClsLobHeader(DataRow dr) : base(dr) {}
		public ClsLobHeader(ClsLobHeader src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Lob_Header_ID = null;
			Create_User = null;
			Create_Dt = null;
			Modify_User = null;
			Modify_Dt = null;
			Voyage_No = null;
			Vessel_Nm = null;
			Military_Voyage_No = null;
			Pol_Location_Cd = null;
			Confirm_Flg = null;
			Notes = null;
			Version_No = null;
			Transmit_Dt = null;
			Sail_Dt = null;
		}

		public void CopyFrom(ClsLobHeader src)
		{
			Lob_Header_ID = src._Lob_Header_ID;
			Create_User = src._Create_User;
			Create_Dt = src._Create_Dt;
			Modify_User = src._Modify_User;
			Modify_Dt = src._Modify_Dt;
			Voyage_No = src._Voyage_No;
			Vessel_Nm = src._Vessel_Nm;
			Military_Voyage_No = src._Military_Voyage_No;
			Pol_Location_Cd = src._Pol_Location_Cd;
			Confirm_Flg = src._Confirm_Flg;
			Notes = src._Notes;
			Version_No = src._Version_No;
			Transmit_Dt = src._Transmit_Dt;
			Sail_Dt = src._Sail_Dt;
		}

		public override bool ReloadFromDB()
		{
			ClsLobHeader tmp = ClsLobHeader.GetUsingKey(Lob_Header_ID.Value);
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

			DbParameter[] p = new DbParameter[14];

			p[0] = Connection.GetParameter
				("@VOYAGE_NO", Voyage_No);
			p[1] = Connection.GetParameter
				("@VESSEL_NM", Vessel_Nm);
			p[2] = Connection.GetParameter
				("@MILITARY_VOYAGE_NO", Military_Voyage_No);
			p[3] = Connection.GetParameter
				("@POL_LOCATION_CD", Pol_Location_Cd);
			p[4] = Connection.GetParameter
				("@CONFIRM_FLG", Confirm_Flg);
			p[5] = Connection.GetParameter
				("@NOTES", Notes);
			p[6] = Connection.GetParameter
				("@VERSION_NO", Version_No);
			p[7] = Connection.GetParameter
				("@TRANSMIT_DT", Transmit_Dt);
			p[8] = Connection.GetParameter
				("@SAIL_DT", Sail_Dt);
			p[9] = Connection.GetParameter
				("@LOB_HEADER_ID", Lob_Header_ID, ParameterDirection.Output, DbType.Int64, 0);
			p[10] = Connection.GetParameter
				("@CREATE_USER", Create_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Create_UserMax);
			p[11] = Connection.GetParameter
				("@CREATE_DT", Create_Dt, ParameterDirection.Output, DbType.DateTime, 0);
			p[12] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);
			p[13] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.Output, DbType.DateTime, 0);

			const string sql = @"
				INSERT INTO T_LOB_HEADER
					(LOB_HEADER_ID, VOYAGE_NO, VESSEL_NM,
					MILITARY_VOYAGE_NO, POL_LOCATION_CD, CONFIRM_FLG,
					NOTES, VERSION_NO, TRANSMIT_DT,
					SAIL_DT)
				VALUES
					(LOB_HEADER_ID_SEQ.NEXTVAL, @VOYAGE_NO, @VESSEL_NM,
					@MILITARY_VOYAGE_NO, @POL_LOCATION_CD, @CONFIRM_FLG,
					@NOTES, @VERSION_NO, @TRANSMIT_DT,
					@SAIL_DT)
				RETURNING
					LOB_HEADER_ID, CREATE_USER, CREATE_DT,
					MODIFY_USER, MODIFY_DT
				INTO
					@LOB_HEADER_ID, @CREATE_USER, @CREATE_DT,
					@MODIFY_USER, @MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Lob_Header_ID = ClsConvert.ToInt64Nullable(p[9].Value);
			Create_User = ClsConvert.ToString(p[10].Value);
			Create_Dt = ClsConvert.ToDateTimeNullable(p[11].Value);
			Modify_User = ClsConvert.ToString(p[12].Value);
			Modify_Dt = ClsConvert.ToDateTimeNullable(p[13].Value);
			return ret;
		}
		public override int Update()
		{
			DbParameter[] p = new DbParameter[12];

			p[0] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.InputOutput, DbType.DateTime, 0);
			p[1] = Connection.GetParameter
				("@VOYAGE_NO", Voyage_No);
			p[2] = Connection.GetParameter
				("@VESSEL_NM", Vessel_Nm);
			p[3] = Connection.GetParameter
				("@MILITARY_VOYAGE_NO", Military_Voyage_No);
			p[4] = Connection.GetParameter
				("@POL_LOCATION_CD", Pol_Location_Cd);
			p[5] = Connection.GetParameter
				("@CONFIRM_FLG", Confirm_Flg);
			p[6] = Connection.GetParameter
				("@NOTES", Notes);
			p[7] = Connection.GetParameter
				("@VERSION_NO", Version_No);
			p[8] = Connection.GetParameter
				("@TRANSMIT_DT", Transmit_Dt);
			p[9] = Connection.GetParameter
				("@SAIL_DT", Sail_Dt);
			p[10] = Connection.GetParameter
				("@LOB_HEADER_ID", Lob_Header_ID);
			p[11] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);

			const string sql = @"
				UPDATE T_LOB_HEADER SET
					MODIFY_DT = @MODIFY_DT,
					VOYAGE_NO = @VOYAGE_NO,
					VESSEL_NM = @VESSEL_NM,
					MILITARY_VOYAGE_NO = @MILITARY_VOYAGE_NO,
					POL_LOCATION_CD = @POL_LOCATION_CD,
					CONFIRM_FLG = @CONFIRM_FLG,
					NOTES = @NOTES,
					VERSION_NO = @VERSION_NO,
					TRANSMIT_DT = @TRANSMIT_DT,
					SAIL_DT = @SAIL_DT
				WHERE
					LOB_HEADER_ID = @LOB_HEADER_ID
				RETURNING
					MODIFY_USER, MODIFY_DT
				INTO
					@MODIFY_USER, @MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Modify_Dt = ClsConvert.ToDateTimeNullable(p[0].Value);
			Modify_User = ClsConvert.ToString(p[11].Value);
			return ret;
		}
		public override int Delete()
		{
			DbParameter[] p = new DbParameter[1];

			p[0] = Connection.GetParameter
				("@LOB_HEADER_ID", Lob_Header_ID);

			const string sql = @"
				DELETE FROM T_LOB_HEADER WHERE
				LOB_HEADER_ID=@LOB_HEADER_ID";
			return Connection.RunSQL(sql, p);
		}
		#endregion		// #region Insert, Update, Delete

		#region Conversion methods

		public override void LoadFromDataReader(DbDataReader dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataReader: DataReader parameter was null");

			Lob_Header_ID = ClsConvert.ToInt64Nullable(dr["LOB_HEADER_ID"]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER"]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT"]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER"]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT"]);
			Voyage_No = ClsConvert.ToString(dr["VOYAGE_NO"]);
			Vessel_Nm = ClsConvert.ToString(dr["VESSEL_NM"]);
			Military_Voyage_No = ClsConvert.ToString(dr["MILITARY_VOYAGE_NO"]);
			Pol_Location_Cd = ClsConvert.ToString(dr["POL_LOCATION_CD"]);
			Confirm_Flg = ClsConvert.ToString(dr["CONFIRM_FLG"]);
			Notes = ClsConvert.ToString(dr["NOTES"]);
			Version_No = ClsConvert.ToInt64Nullable(dr["VERSION_NO"]);
			Transmit_Dt = ClsConvert.ToDateTimeNullable(dr["TRANSMIT_DT"]);
			Sail_Dt = ClsConvert.ToDateTimeNullable(dr["SAIL_DT"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Lob_Header_ID = ClsConvert.ToInt64Nullable(dr["LOB_HEADER_ID", v]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER", v]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT", v]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER", v]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT", v]);
			Voyage_No = ClsConvert.ToString(dr["VOYAGE_NO", v]);
			Vessel_Nm = ClsConvert.ToString(dr["VESSEL_NM", v]);
			Military_Voyage_No = ClsConvert.ToString(dr["MILITARY_VOYAGE_NO", v]);
			Pol_Location_Cd = ClsConvert.ToString(dr["POL_LOCATION_CD", v]);
			Confirm_Flg = ClsConvert.ToString(dr["CONFIRM_FLG", v]);
			Notes = ClsConvert.ToString(dr["NOTES", v]);
			Version_No = ClsConvert.ToInt64Nullable(dr["VERSION_NO", v]);
			Transmit_Dt = ClsConvert.ToDateTimeNullable(dr["TRANSMIT_DT", v]);
			Sail_Dt = ClsConvert.ToDateTimeNullable(dr["SAIL_DT", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["LOB_HEADER_ID"] = ClsConvert.ToDbObject(Lob_Header_ID);
			dr["CREATE_USER"] = ClsConvert.ToDbObject(Create_User);
			dr["CREATE_DT"] = ClsConvert.ToDbObject(Create_Dt);
			dr["MODIFY_USER"] = ClsConvert.ToDbObject(Modify_User);
			dr["MODIFY_DT"] = ClsConvert.ToDbObject(Modify_Dt);
			dr["VOYAGE_NO"] = ClsConvert.ToDbObject(Voyage_No);
			dr["VESSEL_NM"] = ClsConvert.ToDbObject(Vessel_Nm);
			dr["MILITARY_VOYAGE_NO"] = ClsConvert.ToDbObject(Military_Voyage_No);
			dr["POL_LOCATION_CD"] = ClsConvert.ToDbObject(Pol_Location_Cd);
			dr["CONFIRM_FLG"] = ClsConvert.ToDbObject(Confirm_Flg);
			dr["NOTES"] = ClsConvert.ToDbObject(Notes);
			dr["VERSION_NO"] = ClsConvert.ToDbObject(Version_No);
			dr["TRANSMIT_DT"] = ClsConvert.ToDbObject(Transmit_Dt);
			dr["SAIL_DT"] = ClsConvert.ToDbObject(Sail_Dt);
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

		public static ClsLobHeader GetUsingKey(Int64 Lob_Header_ID)
		{
			object[] vals = new object[] {Lob_Header_ID};
			DataRow dr = Connection.GetDataRowUsingKey
				(TableName, GetPrimaryKeys(), vals);
			return ( dr == null ) ? null : new ClsLobHeader(dr);
		}

		#endregion		// #region Static Methods
	}
}