using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsEstimateNote : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ArcSys"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "T_ESTIMATE_NOTE";
		public const int PrimaryKeyCount = 1;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] { "ESTIMATE_NOTE_ID" };
		}

		public const string SelectSQL = @"SELECT * FROM T_ESTIMATE_NOTE 
				LEFT OUTER JOIN R_ESTIMATE_STATUS
				ON T_ESTIMATE_NOTE.ESTIMATE_STATUS_CD=R_ESTIMATE_STATUS.ESTIMATE_STATUS_CD
				INNER JOIN T_ESTIMATE
				ON T_ESTIMATE_NOTE.ESTIMATE_ID=T_ESTIMATE.ESTIMATE_ID ";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Create_UserMax = 30;
		public const int Modify_UserMax = 30;
		public const int Note_TxtMax = 500;
		public const int Estimate_Status_CdMax = 10;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected Int64? _Estimate_Note_ID;
		protected Int64? _Estimate_ID;
		protected string _Create_User;
		protected DateTime? _Create_Dt;
		protected string _Modify_User;
		protected DateTime? _Modify_Dt;
		protected string _Note_Txt;
		protected string _Estimate_Status_Cd;

		#endregion	// #region Column Fields

		#region Column Properties

		public Int64? Estimate_Note_ID
		{
			get { return _Estimate_Note_ID; }
			set
			{
				if( _Estimate_Note_ID == value ) return;
		
				_Estimate_Note_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Estimate_Note_ID");
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
		public string Note_Txt
		{
			get { return _Note_Txt; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Note_Txt, val, false) == 0 ) return;
		
				if( val != null && val.Length > Note_TxtMax )
					_Note_Txt = val.Substring(0, (int)Note_TxtMax);
				else
					_Note_Txt = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Note_Txt");
			}
		}
		public string Estimate_Status_Cd
		{
			get { return _Estimate_Status_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Estimate_Status_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Estimate_Status_CdMax )
					_Estimate_Status_Cd = val.Substring(0, (int)Estimate_Status_CdMax);
				else
					_Estimate_Status_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Estimate_Status_Cd");
			}
		}

		#endregion	// #region Column Properties

		#region Foreign Key Fields

		protected ClsEstimateStatus _Estimate_Status;
		protected ClsEstimate _Estimate;

		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties

		public ClsEstimateStatus Estimate_Status
		{
			get
			{
				if( Estimate_Status_Cd == null )
					_Estimate_Status = null;
				else if( _Estimate_Status == null ||
					_Estimate_Status.Estimate_Status_Cd != Estimate_Status_Cd )
					_Estimate_Status = ClsEstimateStatus.GetUsingKey(Estimate_Status_Cd);
				return _Estimate_Status;
			}
			set
			{
				if( _Estimate_Status == value ) return;
		
				_Estimate_Status = value;
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

		public ClsEstimateNote() : base() {}
		public ClsEstimateNote(DataRow dr) : base(dr) {}
		public ClsEstimateNote(ClsEstimateNote src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Estimate_Note_ID = null;
			Estimate_ID = null;
			Create_User = null;
			Create_Dt = null;
			Modify_User = null;
			Modify_Dt = null;
			Note_Txt = null;
			Estimate_Status_Cd = null;
		}

		public void CopyFrom(ClsEstimateNote src)
		{
			Estimate_Note_ID = src._Estimate_Note_ID;
			Estimate_ID = src._Estimate_ID;
			Create_User = src._Create_User;
			Create_Dt = src._Create_Dt;
			Modify_User = src._Modify_User;
			Modify_Dt = src._Modify_Dt;
			Note_Txt = src._Note_Txt;
			Estimate_Status_Cd = src._Estimate_Status_Cd;
		}

		public override bool ReloadFromDB()
		{
			ClsEstimateNote tmp = ClsEstimateNote.GetUsingKey(Estimate_Note_ID.Value);
			if( tmp != null ) CopyFrom(tmp);

			ResetFKs();
			OnReload();

			return ( tmp != null );
		}

		public override void ResetFKs()
		{
			_Estimate_Status = null;
			_Estimate = null;
		}
		#endregion		// #region Init methods

		#region Insert, Update, Delete

		public override int Insert()
		{

			DbParameter[] p = new DbParameter[8];

			p[0] = Connection.GetParameter
				("@ESTIMATE_ID", Estimate_ID);
			p[1] = Connection.GetParameter
				("@NOTE_TXT", Note_Txt);
			p[2] = Connection.GetParameter
				("@ESTIMATE_STATUS_CD", Estimate_Status_Cd);
			p[3] = Connection.GetParameter
				("@ESTIMATE_NOTE_ID", Estimate_Note_ID, ParameterDirection.Output, DbType.Int64, 0);
			p[4] = Connection.GetParameter
				("@CREATE_USER", Create_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Create_UserMax);
			p[5] = Connection.GetParameter
				("@CREATE_DT", Create_Dt, ParameterDirection.Output, DbType.DateTime, 0);
			p[6] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);
			p[7] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.Output, DbType.DateTime, 0);

			const string sql = @"
				INSERT INTO T_ESTIMATE_NOTE
					(ESTIMATE_NOTE_ID, ESTIMATE_ID, NOTE_TXT,
					ESTIMATE_STATUS_CD)
				VALUES
					(ESTIMATE_NOTE_ID_SEQ.NEXTVAL, @ESTIMATE_ID, @NOTE_TXT,
					@ESTIMATE_STATUS_CD)
				RETURNING
					ESTIMATE_NOTE_ID, CREATE_USER, CREATE_DT,
					MODIFY_USER, MODIFY_DT
				INTO
					@ESTIMATE_NOTE_ID, @CREATE_USER, @CREATE_DT,
					@MODIFY_USER, @MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Estimate_Note_ID = ClsConvert.ToInt64Nullable(p[3].Value);
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
				("@ESTIMATE_ID", Estimate_ID);
			p[1] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.InputOutput, DbType.DateTime, 0);
			p[2] = Connection.GetParameter
				("@NOTE_TXT", Note_Txt);
			p[3] = Connection.GetParameter
				("@ESTIMATE_STATUS_CD", Estimate_Status_Cd);
			p[4] = Connection.GetParameter
				("@ESTIMATE_NOTE_ID", Estimate_Note_ID);
			p[5] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);

			const string sql = @"
				UPDATE T_ESTIMATE_NOTE SET
					ESTIMATE_ID = @ESTIMATE_ID,
					MODIFY_DT = @MODIFY_DT,
					NOTE_TXT = @NOTE_TXT,
					ESTIMATE_STATUS_CD = @ESTIMATE_STATUS_CD
				WHERE
					ESTIMATE_NOTE_ID = @ESTIMATE_NOTE_ID
				RETURNING
					MODIFY_USER, MODIFY_DT
				INTO
					@MODIFY_USER, @MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Modify_Dt = ClsConvert.ToDateTimeNullable(p[1].Value);
			Modify_User = ClsConvert.ToString(p[5].Value);
			return ret;
		}
		public override int Delete()
		{
			DbParameter[] p = new DbParameter[1];

			p[0] = Connection.GetParameter
				("@ESTIMATE_NOTE_ID", Estimate_Note_ID);

			const string sql = @"
				DELETE FROM T_ESTIMATE_NOTE WHERE
				ESTIMATE_NOTE_ID=@ESTIMATE_NOTE_ID";
			return Connection.RunSQL(sql, p);
		}
		#endregion		// #region Insert, Update, Delete

		#region Conversion methods

		public override void LoadFromDataReader(DbDataReader dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataReader: DataReader parameter was null");

			Estimate_Note_ID = ClsConvert.ToInt64Nullable(dr["ESTIMATE_NOTE_ID"]);
			Estimate_ID = ClsConvert.ToInt64Nullable(dr["ESTIMATE_ID"]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER"]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT"]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER"]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT"]);
			Note_Txt = ClsConvert.ToString(dr["NOTE_TXT"]);
			Estimate_Status_Cd = ClsConvert.ToString(dr["ESTIMATE_STATUS_CD"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Estimate_Note_ID = ClsConvert.ToInt64Nullable(dr["ESTIMATE_NOTE_ID", v]);
			Estimate_ID = ClsConvert.ToInt64Nullable(dr["ESTIMATE_ID", v]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER", v]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT", v]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER", v]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT", v]);
			Note_Txt = ClsConvert.ToString(dr["NOTE_TXT", v]);
			Estimate_Status_Cd = ClsConvert.ToString(dr["ESTIMATE_STATUS_CD", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["ESTIMATE_NOTE_ID"] = ClsConvert.ToDbObject(Estimate_Note_ID);
			dr["ESTIMATE_ID"] = ClsConvert.ToDbObject(Estimate_ID);
			dr["CREATE_USER"] = ClsConvert.ToDbObject(Create_User);
			dr["CREATE_DT"] = ClsConvert.ToDbObject(Create_Dt);
			dr["MODIFY_USER"] = ClsConvert.ToDbObject(Modify_User);
			dr["MODIFY_DT"] = ClsConvert.ToDbObject(Modify_Dt);
			dr["NOTE_TXT"] = ClsConvert.ToDbObject(Note_Txt);
			dr["ESTIMATE_STATUS_CD"] = ClsConvert.ToDbObject(Estimate_Status_Cd);
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

		public static ClsEstimateNote GetUsingKey(Int64 Estimate_Note_ID)
		{
			object[] vals = new object[] {Estimate_Note_ID};
			DataRow dr = Connection.GetDataRowUsingKey
				(TableName, GetPrimaryKeys(), vals);
			return ( dr == null ) ? null : new ClsEstimateNote(dr);
		}
		public static DataTable GetAll(string Estimate_Status_Cd, Int64? Estimate_ID)
		{
			List<DbParameter> lst = new List<DbParameter>();	
			StringBuilder sb = new StringBuilder();
		
			if( string.IsNullOrEmpty(Estimate_Status_Cd) == false )
			{
				lst.Add(Connection.GetParameter("@ESTIMATE_STATUS_CD", Estimate_Status_Cd));
				sb.Append(" WHERE T_ESTIMATE_NOTE.ESTIMATE_STATUS_CD=@ESTIMATE_STATUS_CD");
			}
			if( Estimate_ID != null && Estimate_ID > 0 )
			{
				lst.Add(Connection.GetParameter("@ESTIMATE_ID", Estimate_ID));
				sb.AppendFormat(" {0} T_ESTIMATE_NOTE.ESTIMATE_ID=@ESTIMATE_ID",
					sb.Length > 0 ? "AND" : "WHERE");
			}
			sb.Insert(0, SelectSQL);
			return Connection.GetDataTable(sb.ToString(), lst.ToArray());
		}
		#endregion		// #region Static Methods
	}
}