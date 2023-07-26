using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsMove : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ArcSys"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "T_MOVE";
		public const int PrimaryKeyCount = 1;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] { "MOVE_ID" };
		}

		public const string SelectSQL = @"SELECT * FROM T_MOVE 
				INNER JOIN R_TRADING_PARTNER
				ON T_MOVE.TRADING_PARTNER_CD=R_TRADING_PARTNER.TRADING_PARTNER_CD ";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Move_DscMax = 50;
		public const int Trading_Partner_CdMax = 10;
		public const int Create_UserMax = 30;
		public const int Modify_UserMax = 30;
		public const int Active_FlgMax = 1;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected Int64? _Move_ID;
		protected string _Move_Dsc;
		protected string _Trading_Partner_Cd;
		protected string _Create_User;
		protected DateTime? _Create_Dt;
		protected string _Modify_User;
		protected DateTime? _Modify_Dt;
		protected string _Active_Flg;
		protected DateTime? _End_Dt;

		#endregion	// #region Column Fields

		#region Column Properties

		public Int64? Move_ID
		{
			get { return _Move_ID; }
			set
			{
				if( _Move_ID == value ) return;
		
				_Move_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Move_ID");
			}
		}
		public string Move_Dsc
		{
			get { return _Move_Dsc; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Move_Dsc, val, false) == 0 ) return;
		
				if( val != null && val.Length > Move_DscMax )
					_Move_Dsc = val.Substring(0, (int)Move_DscMax);
				else
					_Move_Dsc = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Move_Dsc");
			}
		}
		public string Trading_Partner_Cd
		{
			get { return _Trading_Partner_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Trading_Partner_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Trading_Partner_CdMax )
					_Trading_Partner_Cd = val.Substring(0, (int)Trading_Partner_CdMax);
				else
					_Trading_Partner_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Trading_Partner_Cd");
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
		public DateTime? End_Dt
		{
			get { return _End_Dt; }
			set
			{
				DateTime? val = ( value != null )
					? (DateTime?)value.Value.Date : null;
		
				if( _End_Dt == val ) return;
		
				_End_Dt = val;
				_IsDirty = true;
				NotifyPropertyChanged("End_Dt");
			}
		}

		#endregion	// #region Column Properties

		#region Foreign Key Fields

		protected ClsTradingPartner _Trading_Partner;

		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties

		public ClsTradingPartner Trading_Partner
		{
			get
			{
				if( Trading_Partner_Cd == null )
					_Trading_Partner = null;
				else if( _Trading_Partner == null ||
					_Trading_Partner.Trading_Partner_Cd != Trading_Partner_Cd )
					_Trading_Partner = ClsTradingPartner.GetUsingKey(Trading_Partner_Cd);
				return _Trading_Partner;
			}
			set
			{
				if( _Trading_Partner == value ) return;
		
				_Trading_Partner = value;
			}
		}

		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsMove() : base() {}
		public ClsMove(DataRow dr) : base(dr) {}
		public ClsMove(ClsMove src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Move_ID = null;
			Move_Dsc = null;
			Trading_Partner_Cd = null;
			Create_User = null;
			Create_Dt = null;
			Modify_User = null;
			Modify_Dt = null;
			Active_Flg = null;
			End_Dt = null;
		}

		public void CopyFrom(ClsMove src)
		{
			Move_ID = src._Move_ID;
			Move_Dsc = src._Move_Dsc;
			Trading_Partner_Cd = src._Trading_Partner_Cd;
			Create_User = src._Create_User;
			Create_Dt = src._Create_Dt;
			Modify_User = src._Modify_User;
			Modify_Dt = src._Modify_Dt;
			Active_Flg = src._Active_Flg;
			End_Dt = src._End_Dt;
		}

		public override bool ReloadFromDB()
		{
			ClsMove tmp = ClsMove.GetUsingKey(Move_ID.Value);
			if( tmp != null ) CopyFrom(tmp);

			ResetFKs();
			OnReload();

			return ( tmp != null );
		}

		public override void ResetFKs()
		{
			_Trading_Partner = null;
		}
		#endregion		// #region Init methods

		#region Insert, Update, Delete

		public override int Insert()
		{

			DbParameter[] p = new DbParameter[9];

			p[0] = Connection.GetParameter
				("@MOVE_DSC", Move_Dsc);
			p[1] = Connection.GetParameter
				("@TRADING_PARTNER_CD", Trading_Partner_Cd);
			p[2] = Connection.GetParameter
				("@ACTIVE_FLG", Active_Flg);
			p[3] = Connection.GetParameter
				("@END_DT", End_Dt);
			p[4] = Connection.GetParameter
				("@MOVE_ID", Move_ID, ParameterDirection.Output, DbType.Int64, 0);
			p[5] = Connection.GetParameter
				("@CREATE_USER", Create_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Create_UserMax);
			p[6] = Connection.GetParameter
				("@CREATE_DT", Create_Dt, ParameterDirection.Output, DbType.DateTime, 0);
			p[7] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);
			p[8] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.Output, DbType.DateTime, 0);

			const string sql = @"
				INSERT INTO T_MOVE
					(MOVE_ID, MOVE_DSC, TRADING_PARTNER_CD,
					ACTIVE_FLG, END_DT)
				VALUES
					(MOVE_ID_SEQ.NEXTVAL, @MOVE_DSC, @TRADING_PARTNER_CD,
					@ACTIVE_FLG, @END_DT)
				RETURNING
					MOVE_ID, CREATE_USER, CREATE_DT,
					MODIFY_USER, MODIFY_DT
				INTO
					@MOVE_ID, @CREATE_USER, @CREATE_DT,
					@MODIFY_USER, @MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Move_ID = ClsConvert.ToInt64Nullable(p[4].Value);
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
				("@MOVE_DSC", Move_Dsc);
			p[1] = Connection.GetParameter
				("@TRADING_PARTNER_CD", Trading_Partner_Cd);
			p[2] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.InputOutput, DbType.DateTime, 0);
			p[3] = Connection.GetParameter
				("@ACTIVE_FLG", Active_Flg);
			p[4] = Connection.GetParameter
				("@END_DT", End_Dt);
			p[5] = Connection.GetParameter
				("@MOVE_ID", Move_ID);
			p[6] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);

			const string sql = @"
				UPDATE T_MOVE SET
					MOVE_DSC = @MOVE_DSC,
					TRADING_PARTNER_CD = @TRADING_PARTNER_CD,
					MODIFY_DT = @MODIFY_DT,
					ACTIVE_FLG = @ACTIVE_FLG,
					END_DT = @END_DT
				WHERE
					MOVE_ID = @MOVE_ID
				RETURNING
					MODIFY_USER, MODIFY_DT
				INTO
					@MODIFY_USER, @MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Modify_Dt = ClsConvert.ToDateTimeNullable(p[2].Value);
			Modify_User = ClsConvert.ToString(p[6].Value);
			return ret;
		}
		public override int Delete()
		{
			DbParameter[] p = new DbParameter[1];

			p[0] = Connection.GetParameter
				("@MOVE_ID", Move_ID);

			const string sql = @"
				DELETE FROM T_MOVE WHERE
				MOVE_ID=@MOVE_ID";
			return Connection.RunSQL(sql, p);
		}
		#endregion		// #region Insert, Update, Delete

		#region Conversion methods

		public override void LoadFromDataReader(DbDataReader dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataReader: DataReader parameter was null");

			Move_ID = ClsConvert.ToInt64Nullable(dr["MOVE_ID"]);
			Move_Dsc = ClsConvert.ToString(dr["MOVE_DSC"]);
			Trading_Partner_Cd = ClsConvert.ToString(dr["TRADING_PARTNER_CD"]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER"]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT"]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER"]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT"]);
			Active_Flg = ClsConvert.ToString(dr["ACTIVE_FLG"]);
			End_Dt = ClsConvert.ToDateTimeNullable(dr["END_DT"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Move_ID = ClsConvert.ToInt64Nullable(dr["MOVE_ID", v]);
			Move_Dsc = ClsConvert.ToString(dr["MOVE_DSC", v]);
			Trading_Partner_Cd = ClsConvert.ToString(dr["TRADING_PARTNER_CD", v]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER", v]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT", v]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER", v]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT", v]);
			Active_Flg = ClsConvert.ToString(dr["ACTIVE_FLG", v]);
			End_Dt = ClsConvert.ToDateTimeNullable(dr["END_DT", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["MOVE_ID"] = ClsConvert.ToDbObject(Move_ID);
			dr["MOVE_DSC"] = ClsConvert.ToDbObject(Move_Dsc);
			dr["TRADING_PARTNER_CD"] = ClsConvert.ToDbObject(Trading_Partner_Cd);
			dr["CREATE_USER"] = ClsConvert.ToDbObject(Create_User);
			dr["CREATE_DT"] = ClsConvert.ToDbObject(Create_Dt);
			dr["MODIFY_USER"] = ClsConvert.ToDbObject(Modify_User);
			dr["MODIFY_DT"] = ClsConvert.ToDbObject(Modify_Dt);
			dr["ACTIVE_FLG"] = ClsConvert.ToDbObject(Active_Flg);
			dr["END_DT"] = ClsConvert.ToDbObject(End_Dt);
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

		public static ClsMove GetUsingKey(Int64 Move_ID)
		{
			object[] vals = new object[] {Move_ID};
			DataRow dr = Connection.GetDataRowUsingKey
				(TableName, GetPrimaryKeys(), vals);
			return ( dr == null ) ? null : new ClsMove(dr);
		}
		public static DataTable GetAll(string Trading_Partner_Cd)
		{
			List<DbParameter> lst = new List<DbParameter>();	
			StringBuilder sb = new StringBuilder();
		
			if( string.IsNullOrEmpty(Trading_Partner_Cd) == false )
			{
				lst.Add(Connection.GetParameter("@TRADING_PARTNER_CD", Trading_Partner_Cd));
				sb.Append(" WHERE T_MOVE.TRADING_PARTNER_CD=@TRADING_PARTNER_CD");
			}
			sb.Insert(0, SelectSQL);
			return Connection.GetDataTable(sb.ToString(), lst.ToArray());
		}
		#endregion		// #region Static Methods
	}
}