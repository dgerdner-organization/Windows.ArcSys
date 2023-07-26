using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsCargoAction : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ArcSys"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "T_CARGO_ACTION";
		public const int PrimaryKeyCount = 1;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] { "CARGO_ACTION_ID" };
		}

		public const string SelectSQL = @"SELECT * FROM T_CARGO_ACTION 
				INNER JOIN T_CARGO_MOVE
				ON T_CARGO_ACTION.CARGO_MOVE_ID=T_CARGO_MOVE.CARGO_MOVE_ID
				INNER JOIN R_ACTION
				ON T_CARGO_ACTION.ACTION_CD=R_ACTION.ACTION_CD
				INNER JOIN R_LOCATION
				ON T_CARGO_ACTION.LOCATION_CD=R_LOCATION.LOCATION_CD ";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Action_CdMax = 10;
		public const int Location_CdMax = 10;
		public const int Create_UserMax = 30;
		public const int Modify_UserMax = 30;
		public const int Active_FlgMax = 1;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected Int64? _Cargo_Action_ID;
		protected Int64? _Cargo_Move_ID;
		protected string _Action_Cd;
		protected string _Location_Cd;
		protected string _Create_User;
		protected DateTime? _Create_Dt;
		protected string _Modify_User;
		protected DateTime? _Modify_Dt;
		protected string _Active_Flg;
		protected DateTime? _Action_Dt;
		protected DateTime? _Edi_Sent_Dt;

		#endregion	// #region Column Fields

		#region Column Properties

		public Int64? Cargo_Action_ID
		{
			get { return _Cargo_Action_ID; }
			set
			{
				if( _Cargo_Action_ID == value ) return;
		
				_Cargo_Action_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Cargo_Action_ID");
			}
		}
		public Int64? Cargo_Move_ID
		{
			get { return _Cargo_Move_ID; }
			set
			{
				if( _Cargo_Move_ID == value ) return;
		
				_Cargo_Move_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Cargo_Move_ID");
			}
		}
		public string Action_Cd
		{
			get { return _Action_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Action_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Action_CdMax )
					_Action_Cd = val.Substring(0, (int)Action_CdMax);
				else
					_Action_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Action_Cd");
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
		public DateTime? Action_Dt
		{
			get { return _Action_Dt; }
			set
			{
				DateTime? val = ( value != null )
					? (DateTime?)value.Value.Date : null;
		
				if( _Action_Dt == val ) return;
		
				_Action_Dt = val;
				_IsDirty = true;
				NotifyPropertyChanged("Action_Dt");
			}
		}
		public DateTime? Edi_Sent_Dt
		{
			get { return _Edi_Sent_Dt; }
			set
			{
				DateTime? val = ( value != null )
					? (DateTime?)value.Value.Date : null;
		
				if( _Edi_Sent_Dt == val ) return;
		
				_Edi_Sent_Dt = val;
				_IsDirty = true;
				NotifyPropertyChanged("Edi_Sent_Dt");
			}
		}

		#endregion	// #region Column Properties

		#region Foreign Key Fields

		protected ClsCargoMove _Cargo_Move;
		protected ClsAction _Action;
		protected ClsLocation _Location;

		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties

		public ClsCargoMove Cargo_Move
		{
			get
			{
				if( Cargo_Move_ID == null )
					_Cargo_Move = null;
				else if( _Cargo_Move == null ||
					_Cargo_Move.Cargo_Move_ID != Cargo_Move_ID )
					_Cargo_Move = ClsCargoMove.GetUsingKey(Cargo_Move_ID.Value);
				return _Cargo_Move;
			}
			set
			{
				if( _Cargo_Move == value ) return;
		
				_Cargo_Move = value;
			}
		}
		public ClsAction Action
		{
			get
			{
				if( Action_Cd == null )
					_Action = null;
				else if( _Action == null ||
					_Action.Action_Cd != Action_Cd )
					_Action = ClsAction.GetUsingKey(Action_Cd);
				return _Action;
			}
			set
			{
				if( _Action == value ) return;
		
				_Action = value;
			}
		}
		public ClsLocation Location
		{
			get
			{
				if( Location_Cd == null )
					_Location = null;
				else if( _Location == null ||
					_Location.Location_Cd != Location_Cd )
					_Location = ClsLocation.GetUsingKey(Location_Cd);
				return _Location;
			}
			set
			{
				if( _Location == value ) return;
		
				_Location = value;
			}
		}

		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsCargoAction() : base() {}
		public ClsCargoAction(DataRow dr) : base(dr) {}
		public ClsCargoAction(ClsCargoAction src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Cargo_Action_ID = null;
			Cargo_Move_ID = null;
			Action_Cd = null;
			Location_Cd = null;
			Create_User = null;
			Create_Dt = null;
			Modify_User = null;
			Modify_Dt = null;
			Active_Flg = null;
			Action_Dt = null;
			Edi_Sent_Dt = null;
		}

		public void CopyFrom(ClsCargoAction src)
		{
			Cargo_Action_ID = src._Cargo_Action_ID;
			Cargo_Move_ID = src._Cargo_Move_ID;
			Action_Cd = src._Action_Cd;
			Location_Cd = src._Location_Cd;
			Create_User = src._Create_User;
			Create_Dt = src._Create_Dt;
			Modify_User = src._Modify_User;
			Modify_Dt = src._Modify_Dt;
			Active_Flg = src._Active_Flg;
			Action_Dt = src._Action_Dt;
			Edi_Sent_Dt = src._Edi_Sent_Dt;
		}

		public override bool ReloadFromDB()
		{
			ClsCargoAction tmp = ClsCargoAction.GetUsingKey(Cargo_Action_ID.Value);
			if( tmp != null ) CopyFrom(tmp);

			ResetFKs();
			OnReload();

			return ( tmp != null );
		}

		public override void ResetFKs()
		{
			_Cargo_Move = null;
			_Action = null;
			_Location = null;
		}
		#endregion		// #region Init methods

		#region Insert, Update, Delete

		public override int Insert()
		{

			DbParameter[] p = new DbParameter[11];

			p[0] = Connection.GetParameter
				("@CARGO_MOVE_ID", Cargo_Move_ID);
			p[1] = Connection.GetParameter
				("@ACTION_CD", Action_Cd);
			p[2] = Connection.GetParameter
				("@LOCATION_CD", Location_Cd);
			p[3] = Connection.GetParameter
				("@ACTIVE_FLG", Active_Flg);
			p[4] = Connection.GetParameter
				("@ACTION_DT", Action_Dt);
			p[5] = Connection.GetParameter
				("@EDI_SENT_DT", Edi_Sent_Dt);
			p[6] = Connection.GetParameter
				("@CARGO_ACTION_ID", Cargo_Action_ID, ParameterDirection.Output, DbType.Int64, 0);
			p[7] = Connection.GetParameter
				("@CREATE_USER", Create_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Create_UserMax);
			p[8] = Connection.GetParameter
				("@CREATE_DT", Create_Dt, ParameterDirection.Output, DbType.DateTime, 0);
			p[9] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);
			p[10] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.Output, DbType.DateTime, 0);

			const string sql = @"
				INSERT INTO T_CARGO_ACTION
					(CARGO_ACTION_ID, CARGO_MOVE_ID, ACTION_CD,
					LOCATION_CD, ACTIVE_FLG, ACTION_DT,
					EDI_SENT_DT)
				VALUES
					(CARGO_ACTION_ID_SEQ.NEXTVAL, @CARGO_MOVE_ID, @ACTION_CD,
					@LOCATION_CD, @ACTIVE_FLG, @ACTION_DT,
					@EDI_SENT_DT)
				RETURNING
					CARGO_ACTION_ID, CREATE_USER, CREATE_DT,
					MODIFY_USER, MODIFY_DT
				INTO
					@CARGO_ACTION_ID, @CREATE_USER, @CREATE_DT,
					@MODIFY_USER, @MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Cargo_Action_ID = ClsConvert.ToInt64Nullable(p[6].Value);
			Create_User = ClsConvert.ToString(p[7].Value);
			Create_Dt = ClsConvert.ToDateTimeNullable(p[8].Value);
			Modify_User = ClsConvert.ToString(p[9].Value);
			Modify_Dt = ClsConvert.ToDateTimeNullable(p[10].Value);
			return ret;
		}
		public override int Update()
		{
			DbParameter[] p = new DbParameter[9];

			p[0] = Connection.GetParameter
				("@CARGO_MOVE_ID", Cargo_Move_ID);
			p[1] = Connection.GetParameter
				("@ACTION_CD", Action_Cd);
			p[2] = Connection.GetParameter
				("@LOCATION_CD", Location_Cd);
			p[3] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.InputOutput, DbType.DateTime, 0);
			p[4] = Connection.GetParameter
				("@ACTIVE_FLG", Active_Flg);
			p[5] = Connection.GetParameter
				("@ACTION_DT", Action_Dt);
			p[6] = Connection.GetParameter
				("@EDI_SENT_DT", Edi_Sent_Dt);
			p[7] = Connection.GetParameter
				("@CARGO_ACTION_ID", Cargo_Action_ID);
			p[8] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);

			const string sql = @"
				UPDATE T_CARGO_ACTION SET
					CARGO_MOVE_ID = @CARGO_MOVE_ID,
					ACTION_CD = @ACTION_CD,
					LOCATION_CD = @LOCATION_CD,
					MODIFY_DT = @MODIFY_DT,
					ACTIVE_FLG = @ACTIVE_FLG,
					ACTION_DT = @ACTION_DT,
					EDI_SENT_DT = @EDI_SENT_DT
				WHERE
					CARGO_ACTION_ID = @CARGO_ACTION_ID
				RETURNING
					MODIFY_USER, MODIFY_DT
				INTO
					@MODIFY_USER, @MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Modify_Dt = ClsConvert.ToDateTimeNullable(p[3].Value);
			Modify_User = ClsConvert.ToString(p[8].Value);
			return ret;
		}
		public override int Delete()
		{
            DbParameter[] p = new DbParameter[1];

            p[0] = Connection.GetParameter
                ("@CARGO_ACTION_ID", Cargo_Action_ID);

            const string sql = @"
				DELETE FROM T_CARGO_ACTION WHERE
				CARGO_ACTION_ID=@CARGO_ACTION_ID";
            return Connection.RunSQL(sql, p);
		}
		#endregion		// #region Insert, Update, Delete

		#region Conversion methods

		public override void LoadFromDataReader(DbDataReader dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataReader: DataReader parameter was null");

			Cargo_Action_ID = ClsConvert.ToInt64Nullable(dr["CARGO_ACTION_ID"]);
			Cargo_Move_ID = ClsConvert.ToInt64Nullable(dr["CARGO_MOVE_ID"]);
			Action_Cd = ClsConvert.ToString(dr["ACTION_CD"]);
			Location_Cd = ClsConvert.ToString(dr["LOCATION_CD"]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER"]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT"]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER"]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT"]);
			Active_Flg = ClsConvert.ToString(dr["ACTIVE_FLG"]);
			Action_Dt = ClsConvert.ToDateTimeNullable(dr["ACTION_DT"]);
			Edi_Sent_Dt = ClsConvert.ToDateTimeNullable(dr["EDI_SENT_DT"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Cargo_Action_ID = ClsConvert.ToInt64Nullable(dr["CARGO_ACTION_ID", v]);
			Cargo_Move_ID = ClsConvert.ToInt64Nullable(dr["CARGO_MOVE_ID", v]);
			Action_Cd = ClsConvert.ToString(dr["ACTION_CD", v]);
			Location_Cd = ClsConvert.ToString(dr["LOCATION_CD", v]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER", v]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT", v]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER", v]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT", v]);
			Active_Flg = ClsConvert.ToString(dr["ACTIVE_FLG", v]);
			Action_Dt = ClsConvert.ToDateTimeNullable(dr["ACTION_DT", v]);
			Edi_Sent_Dt = ClsConvert.ToDateTimeNullable(dr["EDI_SENT_DT", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["CARGO_ACTION_ID"] = ClsConvert.ToDbObject(Cargo_Action_ID);
			dr["CARGO_MOVE_ID"] = ClsConvert.ToDbObject(Cargo_Move_ID);
			dr["ACTION_CD"] = ClsConvert.ToDbObject(Action_Cd);
			dr["LOCATION_CD"] = ClsConvert.ToDbObject(Location_Cd);
			dr["CREATE_USER"] = ClsConvert.ToDbObject(Create_User);
			dr["CREATE_DT"] = ClsConvert.ToDbObject(Create_Dt);
			dr["MODIFY_USER"] = ClsConvert.ToDbObject(Modify_User);
			dr["MODIFY_DT"] = ClsConvert.ToDbObject(Modify_Dt);
			dr["ACTIVE_FLG"] = ClsConvert.ToDbObject(Active_Flg);
			dr["ACTION_DT"] = ClsConvert.ToDbObject(Action_Dt);
			dr["EDI_SENT_DT"] = ClsConvert.ToDbObject(Edi_Sent_Dt);
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

		public static ClsCargoAction GetUsingKey(Int64 Cargo_Action_ID)
		{
			object[] vals = new object[] {Cargo_Action_ID};
			DataRow dr = Connection.GetDataRowUsingKey
				(TableName, GetPrimaryKeys(), vals);
			return ( dr == null ) ? null : new ClsCargoAction(dr);
		}
		public static DataTable GetAll(Int64? Cargo_Move_ID, string Action_Cd,
			string Location_Cd)
		{
			List<DbParameter> lst = new List<DbParameter>();	
			StringBuilder sb = new StringBuilder();
		
			if( Cargo_Move_ID != null && Cargo_Move_ID > 0 )
			{
				lst.Add(Connection.GetParameter("@CARGO_MOVE_ID", Cargo_Move_ID));
				sb.Append(" WHERE T_CARGO_ACTION.CARGO_MOVE_ID=@CARGO_MOVE_ID");
			}
			if( string.IsNullOrEmpty(Action_Cd) == false )
			{
				lst.Add(Connection.GetParameter("@ACTION_CD", Action_Cd));
				sb.AppendFormat(" {0} T_CARGO_ACTION.ACTION_CD=@ACTION_CD",
					sb.Length > 0 ? "AND" : "WHERE");
			}
			if( string.IsNullOrEmpty(Location_Cd) == false )
			{
				lst.Add(Connection.GetParameter("@LOCATION_CD", Location_Cd));
				sb.AppendFormat(" {0} T_CARGO_ACTION.LOCATION_CD=@LOCATION_CD",
					sb.Length > 0 ? "AND" : "WHERE");
			}
			sb.Insert(0, SelectSQL);
			return Connection.GetDataTable(sb.ToString(), lst.ToArray());
		}
		#endregion		// #region Static Methods
	}
}