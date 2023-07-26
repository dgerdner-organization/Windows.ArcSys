using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace ASL.ITrack.Business
{
	public partial class ClsIssueNote : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ITrack"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "T_ISSUE_NOTE";
		public const int PrimaryKeyCount = 1;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] { "ISSUE_NOTE_ID" };
		}

		public const string SelectSQL = @"SELECT * FROM T_ISSUE_NOTE 
				INNER JOIN T_ISSUE
				ON T_ISSUE_NOTE.ISSUE_ID=T_ISSUE.ISSUE_ID ";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Create_UserMax = 30;
		public const int Modify_UserMax = 30;
		public const int Version_NoMax = 10;
		public const int Developer_FlgMax = 1;
		public const int Note_TxtMax = 2000;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected Int64? _Issue_Note_ID;
		protected string _Create_User;
		protected DateTime? _Create_Dt;
		protected string _Modify_User;
		protected DateTime? _Modify_Dt;
		protected Int64? _Issue_ID;
		protected string _Version_No;
		protected string _Developer_Flg;
		protected string _Note_Txt;

		#endregion	// #region Column Fields

		#region Column Properties

		public Int64? Issue_Note_ID
		{
			get { return _Issue_Note_ID; }
			set
			{
				if( _Issue_Note_ID == value ) return;
		
				_Issue_Note_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Issue_Note_ID");
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
		public Int64? Issue_ID
		{
			get { return _Issue_ID; }
			set
			{
				if( _Issue_ID == value ) return;
		
				_Issue_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Issue_ID");
			}
		}
		public string Version_No
		{
			get { return _Version_No; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Version_No, val, false) == 0 ) return;
		
				if( val != null && val.Length > Version_NoMax )
					_Version_No = val.Substring(0, (int)Version_NoMax);
				else
					_Version_No = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Version_No");
			}
		}
		public string Developer_Flg
		{
			get { return _Developer_Flg; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Developer_Flg, val, false) == 0 ) return;
		
				if( val != null && val.Length > Developer_FlgMax )
					_Developer_Flg = val.Substring(0, (int)Developer_FlgMax);
				else
					_Developer_Flg = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Developer_Flg");
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

		#endregion	// #region Column Properties

		#region Foreign Key Fields

		protected ClsIssue _Issue;

		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties

		public ClsIssue Issue
		{
			get
			{
				if( Issue_ID == null )
					_Issue = null;
				else if( _Issue == null ||
					_Issue.Issue_ID != Issue_ID )
					_Issue = ClsIssue.GetUsingKey(Issue_ID.Value);
				return _Issue;
			}
			set
			{
				if( _Issue == value ) return;
		
				_Issue = value;
			}
		}

		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsIssueNote() : base() {}
		public ClsIssueNote(DataRow dr) : base(dr) {}
		public ClsIssueNote(ClsIssueNote src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Issue_Note_ID = null;
			Create_User = null;
			Create_Dt = null;
			Modify_User = null;
			Modify_Dt = null;
			Issue_ID = null;
			Version_No = null;
			Developer_Flg = null;
			Note_Txt = null;
		}

		public void CopyFrom(ClsIssueNote src)
		{
			Issue_Note_ID = src._Issue_Note_ID;
			Create_User = src._Create_User;
			Create_Dt = src._Create_Dt;
			Modify_User = src._Modify_User;
			Modify_Dt = src._Modify_Dt;
			Issue_ID = src._Issue_ID;
			Version_No = src._Version_No;
			Developer_Flg = src._Developer_Flg;
			Note_Txt = src._Note_Txt;
		}

		public override bool ReloadFromDB()
		{
			ClsIssueNote tmp = ClsIssueNote.GetUsingKey(Issue_Note_ID.Value);
			if( tmp != null ) CopyFrom(tmp);

			ResetFKs();
			OnReload();

			return ( tmp != null );
		}

		public override void ResetFKs()
		{
			_Issue = null;
		}
		#endregion		// #region Init methods

		#region Insert, Update, Delete

		public override int Insert()
		{

			DbParameter[] p = new DbParameter[9];

			p[0] = Connection.GetParameter
				("@ISSUE_ID", Issue_ID);
			p[1] = Connection.GetParameter
				("@VERSION_NO", Version_No);
			p[2] = Connection.GetParameter
				("@DEVELOPER_FLG", Developer_Flg);
			p[3] = Connection.GetParameter
				("@NOTE_TXT", Note_Txt);
			p[4] = Connection.GetParameter
				("@ISSUE_NOTE_ID", Issue_Note_ID, ParameterDirection.Output, DbType.Int64, 0);
			p[5] = Connection.GetParameter
				("@CREATE_USER", Create_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Create_UserMax);
			p[6] = Connection.GetParameter
				("@CREATE_DT", Create_Dt, ParameterDirection.Output, DbType.DateTime, 0);
			p[7] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);
			p[8] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.Output, DbType.DateTime, 0);

			const string sql = @"
				INSERT INTO T_ISSUE_NOTE
					(ISSUE_NOTE_ID, ISSUE_ID, VERSION_NO,
					DEVELOPER_FLG, NOTE_TXT)
				VALUES
					(ISSUE_NOTE_ID_SEQ.NEXTVAL, @ISSUE_ID, @VERSION_NO,
					@DEVELOPER_FLG, @NOTE_TXT)
				RETURNING
					ISSUE_NOTE_ID, CREATE_USER, CREATE_DT,
					MODIFY_USER, MODIFY_DT
				INTO
					@ISSUE_NOTE_ID, @CREATE_USER, @CREATE_DT,
					@MODIFY_USER, @MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Issue_Note_ID = ClsConvert.ToInt64Nullable(p[4].Value);
			Create_User = ClsConvert.ToString(p[5].Value);
			Create_Dt = ClsConvert.ToDateTimeNullable(p[6].Value);
			Modify_User = ClsConvert.ToString(p[7].Value);
			Modify_Dt = ClsConvert.ToDateTimeNullable(p[8].Value);
			return ret;
		}
		public override int Update()
		{
			DbParameter[] p = new DbParameter[7];

			p[0] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.InputOutput, DbType.DateTime, 0);
			p[1] = Connection.GetParameter
				("@ISSUE_ID", Issue_ID);
			p[2] = Connection.GetParameter
				("@VERSION_NO", Version_No);
			p[3] = Connection.GetParameter
				("@DEVELOPER_FLG", Developer_Flg);
			p[4] = Connection.GetParameter
				("@NOTE_TXT", Note_Txt);
			p[5] = Connection.GetParameter
				("@ISSUE_NOTE_ID", Issue_Note_ID);
			p[6] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);

			const string sql = @"
				UPDATE T_ISSUE_NOTE SET
					MODIFY_DT = @MODIFY_DT,
					ISSUE_ID = @ISSUE_ID,
					VERSION_NO = @VERSION_NO,
					DEVELOPER_FLG = @DEVELOPER_FLG,
					NOTE_TXT = @NOTE_TXT
				WHERE
					ISSUE_NOTE_ID = @ISSUE_NOTE_ID
				RETURNING
					MODIFY_USER, MODIFY_DT
				INTO
					@MODIFY_USER, @MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Modify_Dt = ClsConvert.ToDateTimeNullable(p[0].Value);
			Modify_User = ClsConvert.ToString(p[6].Value);
			return ret;
		}
		public override int Delete()
		{
			DbParameter[] p = new DbParameter[1];

			p[0] = Connection.GetParameter
				("@ISSUE_NOTE_ID", Issue_Note_ID);

			const string sql = @"
				DELETE FROM T_ISSUE_NOTE WHERE
				ISSUE_NOTE_ID=@ISSUE_NOTE_ID";
			return Connection.RunSQL(sql, p);
		}
		#endregion		// #region Insert, Update, Delete

		#region Conversion methods

		public override void LoadFromDataReader(DbDataReader dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataReader: DataReader parameter was null");

			Issue_Note_ID = ClsConvert.ToInt64Nullable(dr["ISSUE_NOTE_ID"]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER"]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT"]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER"]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT"]);
			Issue_ID = ClsConvert.ToInt64Nullable(dr["ISSUE_ID"]);
			Version_No = ClsConvert.ToString(dr["VERSION_NO"]);
			Developer_Flg = ClsConvert.ToString(dr["DEVELOPER_FLG"]);
			Note_Txt = ClsConvert.ToString(dr["NOTE_TXT"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Issue_Note_ID = ClsConvert.ToInt64Nullable(dr["ISSUE_NOTE_ID", v]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER", v]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT", v]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER", v]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT", v]);
			Issue_ID = ClsConvert.ToInt64Nullable(dr["ISSUE_ID", v]);
			Version_No = ClsConvert.ToString(dr["VERSION_NO", v]);
			Developer_Flg = ClsConvert.ToString(dr["DEVELOPER_FLG", v]);
			Note_Txt = ClsConvert.ToString(dr["NOTE_TXT", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["ISSUE_NOTE_ID"] = ClsConvert.ToDbObject(Issue_Note_ID);
			dr["CREATE_USER"] = ClsConvert.ToDbObject(Create_User);
			dr["CREATE_DT"] = ClsConvert.ToDbObject(Create_Dt);
			dr["MODIFY_USER"] = ClsConvert.ToDbObject(Modify_User);
			dr["MODIFY_DT"] = ClsConvert.ToDbObject(Modify_Dt);
			dr["ISSUE_ID"] = ClsConvert.ToDbObject(Issue_ID);
			dr["VERSION_NO"] = ClsConvert.ToDbObject(Version_No);
			dr["DEVELOPER_FLG"] = ClsConvert.ToDbObject(Developer_Flg);
			dr["NOTE_TXT"] = ClsConvert.ToDbObject(Note_Txt);
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

		public static ClsIssueNote GetUsingKey(Int64 Issue_Note_ID)
		{
			object[] vals = new object[] {Issue_Note_ID};
			DataRow dr = Connection.GetDataRowUsingKey
				(TableName, GetPrimaryKeys(), vals);
			return ( dr == null ) ? null : new ClsIssueNote(dr);
		}
		public static DataTable GetAll(Int64? Issue_ID)
		{
			List<DbParameter> lst = new List<DbParameter>();	
			StringBuilder sb = new StringBuilder();
		
			if( Issue_ID != null && Issue_ID > 0 )
			{
				lst.Add(Connection.GetParameter("@ISSUE_ID", Issue_ID));
				sb.Append(" WHERE T_ISSUE_NOTE.ISSUE_ID=@ISSUE_ID");
			}
			sb.Insert(0, SelectSQL);
			return Connection.GetDataTable(sb.ToString(), lst.ToArray());
		}
		#endregion		// #region Static Methods
	}
}