using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsLevelUnit : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ArcSys"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "R_LEVEL_UNIT";
		public const int PrimaryKeyCount = 1;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] { "LEVEL_UNIT_ID" };
		}

		public const string SelectSQL = @"SELECT * FROM R_LEVEL_UNIT 
				INNER JOIN R_LEVEL
				ON R_LEVEL_UNIT.LEVEL_CD=R_LEVEL.LEVEL_CD
				INNER JOIN R_UNIT_TYPE
				ON R_LEVEL_UNIT.UNIT_TYPE_CD=R_UNIT_TYPE.UNIT_TYPE_CD ";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Level_Unit_DscMax = 50;
		public const int Create_UserMax = 30;
		public const int Modify_UserMax = 30;
		public const int Active_FlgMax = 1;
		public const int Average_FlgMax = 1;
		public const int Level_CdMax = 10;
		public const int Unit_Type_CdMax = 10;
		public const int Level_Count_DscMax = 20;
		public const int Unit_Qty_DscMax = 20;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected Int64? _Level_Unit_ID;
		protected string _Level_Unit_Dsc;
		protected string _Create_User;
		protected DateTime? _Create_Dt;
		protected string _Modify_User;
		protected DateTime? _Modify_Dt;
		protected string _Active_Flg;
		protected string _Average_Flg;
		protected string _Level_Cd;
		protected string _Unit_Type_Cd;
		protected string _Level_Count_Dsc;
		protected string _Unit_Qty_Dsc;

		#endregion	// #region Column Fields

		#region Column Properties

		public Int64? Level_Unit_ID
		{
			get { return _Level_Unit_ID; }
			set
			{
				if( _Level_Unit_ID == value ) return;
		
				_Level_Unit_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Level_Unit_ID");
			}
		}
		public string Level_Unit_Dsc
		{
			get { return _Level_Unit_Dsc; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Level_Unit_Dsc, val, false) == 0 ) return;
		
				if( val != null && val.Length > Level_Unit_DscMax )
					_Level_Unit_Dsc = val.Substring(0, (int)Level_Unit_DscMax);
				else
					_Level_Unit_Dsc = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Level_Unit_Dsc");
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
		public string Average_Flg
		{
			get { return _Average_Flg; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Average_Flg, val, false) == 0 ) return;
		
				if( val != null && val.Length > Average_FlgMax )
					_Average_Flg = val.Substring(0, (int)Average_FlgMax);
				else
					_Average_Flg = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Average_Flg");
			}
		}
		public string Level_Cd
		{
			get { return _Level_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Level_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Level_CdMax )
					_Level_Cd = val.Substring(0, (int)Level_CdMax);
				else
					_Level_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Level_Cd");
			}
		}
		public string Unit_Type_Cd
		{
			get { return _Unit_Type_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Unit_Type_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Unit_Type_CdMax )
					_Unit_Type_Cd = val.Substring(0, (int)Unit_Type_CdMax);
				else
					_Unit_Type_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Unit_Type_Cd");
			}
		}
		public string Level_Count_Dsc
		{
			get { return _Level_Count_Dsc; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Level_Count_Dsc, val, false) == 0 ) return;
		
				if( val != null && val.Length > Level_Count_DscMax )
					_Level_Count_Dsc = val.Substring(0, (int)Level_Count_DscMax);
				else
					_Level_Count_Dsc = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Level_Count_Dsc");
			}
		}
		public string Unit_Qty_Dsc
		{
			get { return _Unit_Qty_Dsc; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Unit_Qty_Dsc, val, false) == 0 ) return;
		
				if( val != null && val.Length > Unit_Qty_DscMax )
					_Unit_Qty_Dsc = val.Substring(0, (int)Unit_Qty_DscMax);
				else
					_Unit_Qty_Dsc = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Unit_Qty_Dsc");
			}
		}

		#endregion	// #region Column Properties

		#region Foreign Key Fields

		protected ClsLevel _Level;
		protected ClsUnitType _Unit_Type;

		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties

		public ClsLevel Level
		{
			get
			{
				if( Level_Cd == null )
					_Level = null;
				else if( _Level == null ||
					_Level.Level_Cd != Level_Cd )
					_Level = ClsLevel.GetUsingKey(Level_Cd);
				return _Level;
			}
			set
			{
				if( _Level == value ) return;
		
				_Level = value;
			}
		}
		public ClsUnitType Unit_Type
		{
			get
			{
				if( Unit_Type_Cd == null )
					_Unit_Type = null;
				else if( _Unit_Type == null ||
					_Unit_Type.Unit_Type_Cd != Unit_Type_Cd )
					_Unit_Type = ClsUnitType.GetUsingKey(Unit_Type_Cd);
				return _Unit_Type;
			}
			set
			{
				if( _Unit_Type == value ) return;
		
				_Unit_Type = value;
			}
		}

		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsLevelUnit() : base() {}
		public ClsLevelUnit(DataRow dr) : base(dr) {}
		public ClsLevelUnit(ClsLevelUnit src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Level_Unit_ID = null;
			Level_Unit_Dsc = null;
			Create_User = null;
			Create_Dt = null;
			Modify_User = null;
			Modify_Dt = null;
			Active_Flg = null;
			Average_Flg = null;
			Level_Cd = null;
			Unit_Type_Cd = null;
			Level_Count_Dsc = null;
			Unit_Qty_Dsc = null;
		}

		public void CopyFrom(ClsLevelUnit src)
		{
			Level_Unit_ID = src._Level_Unit_ID;
			Level_Unit_Dsc = src._Level_Unit_Dsc;
			Create_User = src._Create_User;
			Create_Dt = src._Create_Dt;
			Modify_User = src._Modify_User;
			Modify_Dt = src._Modify_Dt;
			Active_Flg = src._Active_Flg;
			Average_Flg = src._Average_Flg;
			Level_Cd = src._Level_Cd;
			Unit_Type_Cd = src._Unit_Type_Cd;
			Level_Count_Dsc = src._Level_Count_Dsc;
			Unit_Qty_Dsc = src._Unit_Qty_Dsc;
		}

		public override bool ReloadFromDB()
		{
			ClsLevelUnit tmp = ClsLevelUnit.GetUsingKey(Level_Unit_ID.Value);
			if( tmp != null ) CopyFrom(tmp);

			ResetFKs();
			OnReload();

			return ( tmp != null );
		}

		public override void ResetFKs()
		{
			_Level = null;
			_Unit_Type = null;
		}
		#endregion		// #region Init methods

		#region Insert, Update, Delete

		public override int Insert()
		{

			DbParameter[] p = new DbParameter[12];

			p[0] = Connection.GetParameter
				("@LEVEL_UNIT_DSC", Level_Unit_Dsc);
			p[1] = Connection.GetParameter
				("@ACTIVE_FLG", Active_Flg);
			p[2] = Connection.GetParameter
				("@AVERAGE_FLG", Average_Flg);
			p[3] = Connection.GetParameter
				("@LEVEL_CD", Level_Cd);
			p[4] = Connection.GetParameter
				("@UNIT_TYPE_CD", Unit_Type_Cd);
			p[5] = Connection.GetParameter
				("@LEVEL_COUNT_DSC", Level_Count_Dsc);
			p[6] = Connection.GetParameter
				("@UNIT_QTY_DSC", Unit_Qty_Dsc);
			p[7] = Connection.GetParameter
				("@LEVEL_UNIT_ID", Level_Unit_ID, ParameterDirection.Output, DbType.Int64, 0);
			p[8] = Connection.GetParameter
				("@CREATE_USER", Create_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Create_UserMax);
			p[9] = Connection.GetParameter
				("@CREATE_DT", Create_Dt, ParameterDirection.Output, DbType.DateTime, 0);
			p[10] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);
			p[11] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.Output, DbType.DateTime, 0);

			const string sql = @"
				INSERT INTO R_LEVEL_UNIT
					(LEVEL_UNIT_ID, LEVEL_UNIT_DSC, ACTIVE_FLG,
					AVERAGE_FLG, LEVEL_CD, UNIT_TYPE_CD,
					LEVEL_COUNT_DSC, UNIT_QTY_DSC)
				VALUES
					(LEVEL_UNIT_ID_SEQ.NEXTVAL, @LEVEL_UNIT_DSC, @ACTIVE_FLG,
					@AVERAGE_FLG, @LEVEL_CD, @UNIT_TYPE_CD,
					@LEVEL_COUNT_DSC, @UNIT_QTY_DSC)
				RETURNING
					LEVEL_UNIT_ID, CREATE_USER, CREATE_DT,
					MODIFY_USER, MODIFY_DT
				INTO
					@LEVEL_UNIT_ID, @CREATE_USER, @CREATE_DT,
					@MODIFY_USER, @MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Level_Unit_ID = ClsConvert.ToInt64Nullable(p[7].Value);
			Create_User = ClsConvert.ToString(p[8].Value);
			Create_Dt = ClsConvert.ToDateTimeNullable(p[9].Value);
			Modify_User = ClsConvert.ToString(p[10].Value);
			Modify_Dt = ClsConvert.ToDateTimeNullable(p[11].Value);
			return ret;
		}
		public override int Update()
		{
			DbParameter[] p = new DbParameter[10];

			p[0] = Connection.GetParameter
				("@LEVEL_UNIT_DSC", Level_Unit_Dsc);
			p[1] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.InputOutput, DbType.DateTime, 0);
			p[2] = Connection.GetParameter
				("@ACTIVE_FLG", Active_Flg);
			p[3] = Connection.GetParameter
				("@AVERAGE_FLG", Average_Flg);
			p[4] = Connection.GetParameter
				("@LEVEL_CD", Level_Cd);
			p[5] = Connection.GetParameter
				("@UNIT_TYPE_CD", Unit_Type_Cd);
			p[6] = Connection.GetParameter
				("@LEVEL_COUNT_DSC", Level_Count_Dsc);
			p[7] = Connection.GetParameter
				("@UNIT_QTY_DSC", Unit_Qty_Dsc);
			p[8] = Connection.GetParameter
				("@LEVEL_UNIT_ID", Level_Unit_ID);
			p[9] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);

			const string sql = @"
				UPDATE R_LEVEL_UNIT SET
					LEVEL_UNIT_DSC = @LEVEL_UNIT_DSC,
					MODIFY_DT = @MODIFY_DT,
					ACTIVE_FLG = @ACTIVE_FLG,
					AVERAGE_FLG = @AVERAGE_FLG,
					LEVEL_CD = @LEVEL_CD,
					UNIT_TYPE_CD = @UNIT_TYPE_CD,
					LEVEL_COUNT_DSC = @LEVEL_COUNT_DSC,
					UNIT_QTY_DSC = @UNIT_QTY_DSC
				WHERE
					LEVEL_UNIT_ID = @LEVEL_UNIT_ID
				RETURNING
					MODIFY_USER, MODIFY_DT
				INTO
					@MODIFY_USER, @MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Modify_Dt = ClsConvert.ToDateTimeNullable(p[1].Value);
			Modify_User = ClsConvert.ToString(p[9].Value);
			return ret;
		}
		public override int Delete()
		{
			DbParameter[] p = new DbParameter[1];

			p[0] = Connection.GetParameter
				("@LEVEL_UNIT_ID", Level_Unit_ID);

			const string sql = @"
				DELETE FROM R_LEVEL_UNIT WHERE
				LEVEL_UNIT_ID=@LEVEL_UNIT_ID";
			return Connection.RunSQL(sql, p);
		}
		#endregion		// #region Insert, Update, Delete

		#region Conversion methods

		public override void LoadFromDataReader(DbDataReader dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataReader: DataReader parameter was null");

			Level_Unit_ID = ClsConvert.ToInt64Nullable(dr["LEVEL_UNIT_ID"]);
			Level_Unit_Dsc = ClsConvert.ToString(dr["LEVEL_UNIT_DSC"]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER"]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT"]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER"]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT"]);
			Active_Flg = ClsConvert.ToString(dr["ACTIVE_FLG"]);
			Average_Flg = ClsConvert.ToString(dr["AVERAGE_FLG"]);
			Level_Cd = ClsConvert.ToString(dr["LEVEL_CD"]);
			Unit_Type_Cd = ClsConvert.ToString(dr["UNIT_TYPE_CD"]);
			Level_Count_Dsc = ClsConvert.ToString(dr["LEVEL_COUNT_DSC"]);
			Unit_Qty_Dsc = ClsConvert.ToString(dr["UNIT_QTY_DSC"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Level_Unit_ID = ClsConvert.ToInt64Nullable(dr["LEVEL_UNIT_ID", v]);
			Level_Unit_Dsc = ClsConvert.ToString(dr["LEVEL_UNIT_DSC", v]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER", v]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT", v]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER", v]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT", v]);
			Active_Flg = ClsConvert.ToString(dr["ACTIVE_FLG", v]);
			Average_Flg = ClsConvert.ToString(dr["AVERAGE_FLG", v]);
			Level_Cd = ClsConvert.ToString(dr["LEVEL_CD", v]);
			Unit_Type_Cd = ClsConvert.ToString(dr["UNIT_TYPE_CD", v]);
			Level_Count_Dsc = ClsConvert.ToString(dr["LEVEL_COUNT_DSC", v]);
			Unit_Qty_Dsc = ClsConvert.ToString(dr["UNIT_QTY_DSC", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["LEVEL_UNIT_ID"] = ClsConvert.ToDbObject(Level_Unit_ID);
			dr["LEVEL_UNIT_DSC"] = ClsConvert.ToDbObject(Level_Unit_Dsc);
			dr["CREATE_USER"] = ClsConvert.ToDbObject(Create_User);
			dr["CREATE_DT"] = ClsConvert.ToDbObject(Create_Dt);
			dr["MODIFY_USER"] = ClsConvert.ToDbObject(Modify_User);
			dr["MODIFY_DT"] = ClsConvert.ToDbObject(Modify_Dt);
			dr["ACTIVE_FLG"] = ClsConvert.ToDbObject(Active_Flg);
			dr["AVERAGE_FLG"] = ClsConvert.ToDbObject(Average_Flg);
			dr["LEVEL_CD"] = ClsConvert.ToDbObject(Level_Cd);
			dr["UNIT_TYPE_CD"] = ClsConvert.ToDbObject(Unit_Type_Cd);
			dr["LEVEL_COUNT_DSC"] = ClsConvert.ToDbObject(Level_Count_Dsc);
			dr["UNIT_QTY_DSC"] = ClsConvert.ToDbObject(Unit_Qty_Dsc);
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

		public static ClsLevelUnit GetUsingKey(Int64 Level_Unit_ID)
		{
			object[] vals = new object[] {Level_Unit_ID};
			DataRow dr = Connection.GetDataRowUsingKey
				(TableName, GetPrimaryKeys(), vals);
			return ( dr == null ) ? null : new ClsLevelUnit(dr);
		}
		public static DataTable GetAll(string Level_Cd, string Unit_Type_Cd)
		{
			List<DbParameter> lst = new List<DbParameter>();	
			StringBuilder sb = new StringBuilder();
		
			if( string.IsNullOrEmpty(Level_Cd) == false )
			{
				lst.Add(Connection.GetParameter("@LEVEL_CD", Level_Cd));
				sb.Append(" WHERE R_LEVEL_UNIT.LEVEL_CD=@LEVEL_CD");
			}
			if( string.IsNullOrEmpty(Unit_Type_Cd) == false )
			{
				lst.Add(Connection.GetParameter("@UNIT_TYPE_CD", Unit_Type_Cd));
				sb.AppendFormat(" {0} R_LEVEL_UNIT.UNIT_TYPE_CD=@UNIT_TYPE_CD",
					sb.Length > 0 ? "AND" : "WHERE");
			}
			sb.Insert(0, SelectSQL);
			return Connection.GetDataTable(sb.ToString(), lst.ToArray());
		}
		#endregion		// #region Static Methods
	}
}