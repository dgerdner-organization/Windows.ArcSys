using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsNhtsaRecallHistory : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ArcSys"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "T_NHTSA_RECALL_HISTORY";
		public const int PrimaryKeyCount = 2;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] { "NHTSA_RECALL_HISTORY_ID", "NHTSA_RECALL_ID" };
		}

		public const string SelectSQL = @"SELECT * FROM T_NHTSA_RECALL_HISTORY 
				LEFT OUTER JOIN R_RECALL_STATUS
				ON T_NHTSA_RECALL_HISTORY.RECALL_STATUS_CD=R_RECALL_STATUS.RECALL_STATUS_CD
				INNER JOIN T_NHTSA_RECALL
				ON T_NHTSA_RECALL_HISTORY.NHTSA_RECALL_ID=T_NHTSA_RECALL.NHTSA_RECALL_ID
				LEFT OUTER JOIN R_RECALL_RISK
				ON T_NHTSA_RECALL_HISTORY.RECALL_RISK_CD=R_RECALL_RISK.RECALL_RISK_CD ";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Create_UserMax = 30;
		public const int Modify_UserMax = 30;
		public const int Recall_Status_CdMax = 5;
		public const int Recall_Risk_CdMax = 5;
		public const int Note_TextMax = 1000;
		public const int Remark_FlgMax = 1;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected Int64? _Nhtsa_Recall_History_ID;
		protected string _Create_User;
		protected DateTime? _Create_Dt;
		protected string _Modify_User;
		protected DateTime? _Modify_Dt;
		protected Int64? _Nhtsa_Recall_ID;
		protected string _Recall_Status_Cd;
		protected string _Recall_Risk_Cd;
		protected string _Note_Text;
		protected string _Remark_Flg;

		#endregion	// #region Column Fields

		#region Column Properties

		public Int64? Nhtsa_Recall_History_ID
		{
			get { return _Nhtsa_Recall_History_ID; }
			set
			{
				if( _Nhtsa_Recall_History_ID == value ) return;
		
				_Nhtsa_Recall_History_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Nhtsa_Recall_History_ID");
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
		public Int64? Nhtsa_Recall_ID
		{
			get { return _Nhtsa_Recall_ID; }
			set
			{
				if( _Nhtsa_Recall_ID == value ) return;
		
				_Nhtsa_Recall_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Nhtsa_Recall_ID");
			}
		}
		public string Recall_Status_Cd
		{
			get { return _Recall_Status_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Recall_Status_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Recall_Status_CdMax )
					_Recall_Status_Cd = val.Substring(0, (int)Recall_Status_CdMax);
				else
					_Recall_Status_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Recall_Status_Cd");
			}
		}
		public string Recall_Risk_Cd
		{
			get { return _Recall_Risk_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Recall_Risk_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Recall_Risk_CdMax )
					_Recall_Risk_Cd = val.Substring(0, (int)Recall_Risk_CdMax);
				else
					_Recall_Risk_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Recall_Risk_Cd");
			}
		}
		public string Note_Text
		{
			get { return _Note_Text; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Note_Text, val, false) == 0 ) return;
		
				if( val != null && val.Length > Note_TextMax )
					_Note_Text = val.Substring(0, (int)Note_TextMax);
				else
					_Note_Text = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Note_Text");
			}
		}
		public string Remark_Flg
		{
			get { return _Remark_Flg; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Remark_Flg, val, false) == 0 ) return;
		
				if( val != null && val.Length > Remark_FlgMax )
					_Remark_Flg = val.Substring(0, (int)Remark_FlgMax);
				else
					_Remark_Flg = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Remark_Flg");
			}
		}

		#endregion	// #region Column Properties

		#region Foreign Key Fields

		protected ClsRecallStatus _Recall_Status;
		protected ClsNhtsaRecall _Nhtsa_Recall;
		protected ClsRecallRisk _Recall_Risk;

		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties

		public ClsRecallStatus Recall_Status
		{
			get
			{
				if( Recall_Status_Cd == null )
					_Recall_Status = null;
				else if( _Recall_Status == null ||
					_Recall_Status.Recall_Status_Cd != Recall_Status_Cd )
					_Recall_Status = ClsRecallStatus.GetUsingKey(Recall_Status_Cd);
				return _Recall_Status;
			}
			set
			{
				if( _Recall_Status == value ) return;
		
				_Recall_Status = value;
			}
		}
		public ClsNhtsaRecall Nhtsa_Recall
		{
			get
			{
				if( Nhtsa_Recall_ID == null )
					_Nhtsa_Recall = null;
				else if( _Nhtsa_Recall == null ||
					_Nhtsa_Recall.Nhtsa_Recall_ID != Nhtsa_Recall_ID )
					_Nhtsa_Recall = ClsNhtsaRecall.GetUsingKey(Nhtsa_Recall_ID.Value);
				return _Nhtsa_Recall;
			}
			set
			{
				if( _Nhtsa_Recall == value ) return;
		
				_Nhtsa_Recall = value;
			}
		}
		public ClsRecallRisk Recall_Risk
		{
			get
			{
				if( Recall_Risk_Cd == null )
					_Recall_Risk = null;
				else if( _Recall_Risk == null ||
					_Recall_Risk.Recall_Risk_Cd != Recall_Risk_Cd )
					_Recall_Risk = ClsRecallRisk.GetUsingKey(Recall_Risk_Cd);
				return _Recall_Risk;
			}
			set
			{
				if( _Recall_Risk == value ) return;
		
				_Recall_Risk = value;
			}
		}

		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsNhtsaRecallHistory() : base() {}
		public ClsNhtsaRecallHistory(DataRow dr) : base(dr) {}
		public ClsNhtsaRecallHistory(ClsNhtsaRecallHistory src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Nhtsa_Recall_History_ID = null;
			Create_User = null;
			Create_Dt = null;
			Modify_User = null;
			Modify_Dt = null;
			Nhtsa_Recall_ID = null;
			Recall_Status_Cd = null;
			Recall_Risk_Cd = null;
			Note_Text = null;
			Remark_Flg = null;
		}

		public void CopyFrom(ClsNhtsaRecallHistory src)
		{
			Nhtsa_Recall_History_ID = src._Nhtsa_Recall_History_ID;
			Create_User = src._Create_User;
			Create_Dt = src._Create_Dt;
			Modify_User = src._Modify_User;
			Modify_Dt = src._Modify_Dt;
			Nhtsa_Recall_ID = src._Nhtsa_Recall_ID;
			Recall_Status_Cd = src._Recall_Status_Cd;
			Recall_Risk_Cd = src._Recall_Risk_Cd;
			Note_Text = src._Note_Text;
			Remark_Flg = src._Remark_Flg;
		}

		public override bool ReloadFromDB()
		{
			ClsNhtsaRecallHistory tmp = ClsNhtsaRecallHistory.GetUsingKey(Nhtsa_Recall_History_ID.Value, Nhtsa_Recall_ID.Value);
			if( tmp != null ) CopyFrom(tmp);

			ResetFKs();
			OnReload();

			return ( tmp != null );
		}

		public override void ResetFKs()
		{
			_Recall_Status = null;
			_Nhtsa_Recall = null;
			_Recall_Risk = null;
		}
		#endregion		// #region Init methods

		#region Insert, Update, Delete

		public override int Insert()
		{

            DbParameter[] p = new DbParameter[10];

            p[0] = Connection.GetParameter
                ("@NHTSA_RECALL_ID", Nhtsa_Recall_ID);
            p[1] = Connection.GetParameter
                ("@RECALL_STATUS_CD", Recall_Status_Cd);
            p[2] = Connection.GetParameter
                ("@RECALL_RISK_CD", Recall_Risk_Cd);
            p[3] = Connection.GetParameter
                ("@NOTE_TEXT", Note_Text);
            p[4] = Connection.GetParameter
                ("@REMARK_FLG", Remark_Flg);
            p[5] = Connection.GetParameter
                ("@NHTSA_RECALL_HISTORY_ID", Nhtsa_Recall_History_ID, ParameterDirection.Output, DbType.Int64, 0);
            p[6] = Connection.GetParameter
                ("@CREATE_USER", Create_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Create_UserMax);
            p[7] = Connection.GetParameter
                ("@CREATE_DT", Create_Dt, ParameterDirection.Output, DbType.DateTime, 0);
            p[8] = Connection.GetParameter
                ("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);
            p[9] = Connection.GetParameter
                ("@MODIFY_DT", Modify_Dt, ParameterDirection.Output, DbType.DateTime, 0);

            const string sql = @"
				INSERT INTO T_NHTSA_RECALL_HISTORY
					(NHTSA_RECALL_HISTORY_ID, NHTSA_RECALL_ID, RECALL_STATUS_CD,
					RECALL_RISK_CD, NOTE_TEXT, REMARK_FLG)
				VALUES
					(NHTSA_RECALL_HISTORY_ID_SEQ.NEXTVAL, @NHTSA_RECALL_ID, @RECALL_STATUS_CD,
					@RECALL_RISK_CD, @NOTE_TEXT, @REMARK_FLG)
				RETURNING
                    NHTSA_RECALL_HISTORY_ID,
					CREATE_USER, CREATE_DT, MODIFY_USER,
					MODIFY_DT
				INTO
                    @NHTSA_RECALL_HISTORY_ID,
					@CREATE_USER, @CREATE_DT, @MODIFY_USER,
					@MODIFY_DT";
            int ret = Connection.RunSQL(sql, p);

            Nhtsa_Recall_History_ID = ClsConvert.ToInt64Nullable(p[5].Value);
            Create_User = ClsConvert.ToString(p[6].Value);
            Create_Dt = ClsConvert.ToDateTimeNullable(p[7].Value);
            Modify_User = ClsConvert.ToString(p[8].Value);
            Modify_Dt = ClsConvert.ToDateTimeNullable(p[9].Value);
            return ret;

		}
		public override int Update()
		{
			DbParameter[] p = new DbParameter[8];

			p[0] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.InputOutput, DbType.DateTime, 0);
			p[1] = Connection.GetParameter
				("@RECALL_STATUS_CD", Recall_Status_Cd);
			p[2] = Connection.GetParameter
				("@RECALL_RISK_CD", Recall_Risk_Cd);
			p[3] = Connection.GetParameter
				("@NOTE_TEXT", Note_Text);
			p[4] = Connection.GetParameter
				("@REMARK_FLG", Remark_Flg);
			p[5] = Connection.GetParameter
				("@NHTSA_RECALL_HISTORY_ID", Nhtsa_Recall_History_ID);
			p[6] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);
			p[7] = Connection.GetParameter
				("@NHTSA_RECALL_ID", Nhtsa_Recall_ID);

			const string sql = @"
				UPDATE T_NHTSA_RECALL_HISTORY SET
					MODIFY_DT = @MODIFY_DT,
					RECALL_STATUS_CD = @RECALL_STATUS_CD,
					RECALL_RISK_CD = @RECALL_RISK_CD,
					NOTE_TEXT = @NOTE_TEXT,
					REMARK_FLG = @REMARK_FLG
				WHERE
					NHTSA_RECALL_HISTORY_ID = @NHTSA_RECALL_HISTORY_ID AND
					NHTSA_RECALL_ID = @NHTSA_RECALL_ID
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

			Nhtsa_Recall_History_ID = ClsConvert.ToInt64Nullable(dr["NHTSA_RECALL_HISTORY_ID"]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER"]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT"]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER"]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT"]);
			Nhtsa_Recall_ID = ClsConvert.ToInt64Nullable(dr["NHTSA_RECALL_ID"]);
			Recall_Status_Cd = ClsConvert.ToString(dr["RECALL_STATUS_CD"]);
			Recall_Risk_Cd = ClsConvert.ToString(dr["RECALL_RISK_CD"]);
			Note_Text = ClsConvert.ToString(dr["NOTE_TEXT"]);
			Remark_Flg = ClsConvert.ToString(dr["REMARK_FLG"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Nhtsa_Recall_History_ID = ClsConvert.ToInt64Nullable(dr["NHTSA_RECALL_HISTORY_ID", v]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER", v]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT", v]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER", v]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT", v]);
			Nhtsa_Recall_ID = ClsConvert.ToInt64Nullable(dr["NHTSA_RECALL_ID", v]);
			Recall_Status_Cd = ClsConvert.ToString(dr["RECALL_STATUS_CD", v]);
			Recall_Risk_Cd = ClsConvert.ToString(dr["RECALL_RISK_CD", v]);
			Note_Text = ClsConvert.ToString(dr["NOTE_TEXT", v]);
			Remark_Flg = ClsConvert.ToString(dr["REMARK_FLG", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["NHTSA_RECALL_HISTORY_ID"] = ClsConvert.ToDbObject(Nhtsa_Recall_History_ID);
			dr["CREATE_USER"] = ClsConvert.ToDbObject(Create_User);
			dr["CREATE_DT"] = ClsConvert.ToDbObject(Create_Dt);
			dr["MODIFY_USER"] = ClsConvert.ToDbObject(Modify_User);
			dr["MODIFY_DT"] = ClsConvert.ToDbObject(Modify_Dt);
			dr["NHTSA_RECALL_ID"] = ClsConvert.ToDbObject(Nhtsa_Recall_ID);
			dr["RECALL_STATUS_CD"] = ClsConvert.ToDbObject(Recall_Status_Cd);
			dr["RECALL_RISK_CD"] = ClsConvert.ToDbObject(Recall_Risk_Cd);
			dr["NOTE_TEXT"] = ClsConvert.ToDbObject(Note_Text);
			dr["REMARK_FLG"] = ClsConvert.ToDbObject(Remark_Flg);
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

		public static ClsNhtsaRecallHistory GetUsingKey(Int64 Nhtsa_Recall_History_ID, Int64 Nhtsa_Recall_ID)
		{
			object[] vals = new object[] {Nhtsa_Recall_History_ID, Nhtsa_Recall_ID};
			DataRow dr = Connection.GetDataRowUsingKey
				(TableName, GetPrimaryKeys(), vals);
			return ( dr == null ) ? null : new ClsNhtsaRecallHistory(dr);
		}
		public static DataTable GetAll(string Recall_Status_Cd, Int64? Nhtsa_Recall_ID,
			string Recall_Risk_Cd)
		{
			List<DbParameter> lst = new List<DbParameter>();	
			StringBuilder sb = new StringBuilder();
		
			if( string.IsNullOrEmpty(Recall_Status_Cd) == false )
			{
				lst.Add(Connection.GetParameter("@RECALL_STATUS_CD", Recall_Status_Cd));
				sb.Append(" WHERE T_NHTSA_RECALL_HISTORY.RECALL_STATUS_CD=@RECALL_STATUS_CD");
			}
			if( Nhtsa_Recall_ID != null && Nhtsa_Recall_ID > 0 )
			{
				lst.Add(Connection.GetParameter("@NHTSA_RECALL_ID", Nhtsa_Recall_ID));
				sb.AppendFormat(" {0} T_NHTSA_RECALL_HISTORY.NHTSA_RECALL_ID=@NHTSA_RECALL_ID",
					sb.Length > 0 ? "AND" : "WHERE");
			}
			if( string.IsNullOrEmpty(Recall_Risk_Cd) == false )
			{
				lst.Add(Connection.GetParameter("@RECALL_RISK_CD", Recall_Risk_Cd));
				sb.AppendFormat(" {0} T_NHTSA_RECALL_HISTORY.RECALL_RISK_CD=@RECALL_RISK_CD",
					sb.Length > 0 ? "AND" : "WHERE");
			}
			sb.Insert(0, SelectSQL);
			return Connection.GetDataTable(sb.ToString(), lst.ToArray());
		}
		#endregion		// #region Static Methods
	}
}