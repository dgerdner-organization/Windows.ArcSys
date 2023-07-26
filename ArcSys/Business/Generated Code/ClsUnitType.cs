using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsUnitType : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ArcSys"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "R_UNIT_TYPE";
		public const int PrimaryKeyCount = 1;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] { "UNIT_TYPE_CD" };
		}

		public const string SelectSQL = "SELECT * FROM R_UNIT_TYPE";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Unit_Type_CdMax = 10;
		public const int Create_UserMax = 30;
		public const int Modify_UserMax = 30;
		public const int Unit_Type_DscMax = 50;
		public const int Active_FlgMax = 1;
		public const int Units_Required_FlgMax = 1;
		public const int Grid_Column_DscMax = 20;
		public const int Db_Column_NmMax = 25;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected string _Unit_Type_Cd;
		protected string _Create_User;
		protected DateTime? _Create_Dt;
		protected string _Modify_User;
		protected DateTime? _Modify_Dt;
		protected string _Unit_Type_Dsc;
		protected string _Active_Flg;
		protected string _Units_Required_Flg;
		protected string _Grid_Column_Dsc;
		protected string _Db_Column_Nm;

		#endregion	// #region Column Fields

		#region Column Properties

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
		public string Unit_Type_Dsc
		{
			get { return _Unit_Type_Dsc; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Unit_Type_Dsc, val, false) == 0 ) return;
		
				if( val != null && val.Length > Unit_Type_DscMax )
					_Unit_Type_Dsc = val.Substring(0, (int)Unit_Type_DscMax);
				else
					_Unit_Type_Dsc = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Unit_Type_Dsc");
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
		public string Units_Required_Flg
		{
			get { return _Units_Required_Flg; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Units_Required_Flg, val, false) == 0 ) return;
		
				if( val != null && val.Length > Units_Required_FlgMax )
					_Units_Required_Flg = val.Substring(0, (int)Units_Required_FlgMax);
				else
					_Units_Required_Flg = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Units_Required_Flg");
			}
		}
		public string Grid_Column_Dsc
		{
			get { return _Grid_Column_Dsc; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Grid_Column_Dsc, val, false) == 0 ) return;
		
				if( val != null && val.Length > Grid_Column_DscMax )
					_Grid_Column_Dsc = val.Substring(0, (int)Grid_Column_DscMax);
				else
					_Grid_Column_Dsc = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Grid_Column_Dsc");
			}
		}
		public string Db_Column_Nm
		{
			get { return _Db_Column_Nm; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Db_Column_Nm, val, false) == 0 ) return;
		
				if( val != null && val.Length > Db_Column_NmMax )
					_Db_Column_Nm = val.Substring(0, (int)Db_Column_NmMax);
				else
					_Db_Column_Nm = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Db_Column_Nm");
			}
		}

		#endregion	// #region Column Properties

		#region Foreign Key Fields



		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties



		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsUnitType() : base() {}
		public ClsUnitType(DataRow dr) : base(dr) {}
		public ClsUnitType(ClsUnitType src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Unit_Type_Cd = null;
			Create_User = null;
			Create_Dt = null;
			Modify_User = null;
			Modify_Dt = null;
			Unit_Type_Dsc = null;
			Active_Flg = null;
			Units_Required_Flg = null;
			Grid_Column_Dsc = null;
			Db_Column_Nm = null;
		}

		public void CopyFrom(ClsUnitType src)
		{
			Unit_Type_Cd = src._Unit_Type_Cd;
			Create_User = src._Create_User;
			Create_Dt = src._Create_Dt;
			Modify_User = src._Modify_User;
			Modify_Dt = src._Modify_Dt;
			Unit_Type_Dsc = src._Unit_Type_Dsc;
			Active_Flg = src._Active_Flg;
			Units_Required_Flg = src._Units_Required_Flg;
			Grid_Column_Dsc = src._Grid_Column_Dsc;
			Db_Column_Nm = src._Db_Column_Nm;
		}

		public override bool ReloadFromDB()
		{
			ClsUnitType tmp = ClsUnitType.GetUsingKey(Unit_Type_Cd);
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

			DbParameter[] p = new DbParameter[10];

			p[0] = Connection.GetParameter
				("@UNIT_TYPE_CD", Unit_Type_Cd);
			p[1] = Connection.GetParameter
				("@UNIT_TYPE_DSC", Unit_Type_Dsc);
			p[2] = Connection.GetParameter
				("@ACTIVE_FLG", Active_Flg);
			p[3] = Connection.GetParameter
				("@UNITS_REQUIRED_FLG", Units_Required_Flg);
			p[4] = Connection.GetParameter
				("@GRID_COLUMN_DSC", Grid_Column_Dsc);
			p[5] = Connection.GetParameter
				("@DB_COLUMN_NM", Db_Column_Nm);
			p[6] = Connection.GetParameter
				("@CREATE_USER", Create_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Create_UserMax);
			p[7] = Connection.GetParameter
				("@CREATE_DT", Create_Dt, ParameterDirection.Output, DbType.DateTime, 0);
			p[8] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);
			p[9] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.Output, DbType.DateTime, 0);

			const string sql = @"
				INSERT INTO R_UNIT_TYPE
					(UNIT_TYPE_CD, UNIT_TYPE_DSC, ACTIVE_FLG,
					UNITS_REQUIRED_FLG, GRID_COLUMN_DSC, DB_COLUMN_NM)
				VALUES
					(@UNIT_TYPE_CD, @UNIT_TYPE_DSC, @ACTIVE_FLG,
					@UNITS_REQUIRED_FLG, @GRID_COLUMN_DSC, @DB_COLUMN_NM)
				RETURNING
					CREATE_USER, CREATE_DT, MODIFY_USER,
					MODIFY_DT
				INTO
					@CREATE_USER, @CREATE_DT, @MODIFY_USER,
					@MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

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
				("@UNIT_TYPE_DSC", Unit_Type_Dsc);
			p[2] = Connection.GetParameter
				("@ACTIVE_FLG", Active_Flg);
			p[3] = Connection.GetParameter
				("@UNITS_REQUIRED_FLG", Units_Required_Flg);
			p[4] = Connection.GetParameter
				("@GRID_COLUMN_DSC", Grid_Column_Dsc);
			p[5] = Connection.GetParameter
				("@DB_COLUMN_NM", Db_Column_Nm);
			p[6] = Connection.GetParameter
				("@UNIT_TYPE_CD", Unit_Type_Cd);
			p[7] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);

			const string sql = @"
				UPDATE R_UNIT_TYPE SET
					MODIFY_DT = @MODIFY_DT,
					UNIT_TYPE_DSC = @UNIT_TYPE_DSC,
					ACTIVE_FLG = @ACTIVE_FLG,
					UNITS_REQUIRED_FLG = @UNITS_REQUIRED_FLG,
					GRID_COLUMN_DSC = @GRID_COLUMN_DSC,
					DB_COLUMN_NM = @DB_COLUMN_NM
				WHERE
					UNIT_TYPE_CD = @UNIT_TYPE_CD
				RETURNING
					MODIFY_USER, MODIFY_DT
				INTO
					@MODIFY_USER, @MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Modify_Dt = ClsConvert.ToDateTimeNullable(p[0].Value);
			Modify_User = ClsConvert.ToString(p[7].Value);
			return ret;
		}
		public override int Delete()
		{
			DbParameter[] p = new DbParameter[1];

			p[0] = Connection.GetParameter
				("@UNIT_TYPE_CD", Unit_Type_Cd);

			const string sql = @"
				DELETE FROM R_UNIT_TYPE WHERE
				UNIT_TYPE_CD=@UNIT_TYPE_CD";
			return Connection.RunSQL(sql, p);
		}
		#endregion		// #region Insert, Update, Delete

		#region Conversion methods

		public override void LoadFromDataReader(DbDataReader dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataReader: DataReader parameter was null");

			Unit_Type_Cd = ClsConvert.ToString(dr["UNIT_TYPE_CD"]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER"]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT"]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER"]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT"]);
			Unit_Type_Dsc = ClsConvert.ToString(dr["UNIT_TYPE_DSC"]);
			Active_Flg = ClsConvert.ToString(dr["ACTIVE_FLG"]);
			Units_Required_Flg = ClsConvert.ToString(dr["UNITS_REQUIRED_FLG"]);
			Grid_Column_Dsc = ClsConvert.ToString(dr["GRID_COLUMN_DSC"]);
			Db_Column_Nm = ClsConvert.ToString(dr["DB_COLUMN_NM"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Unit_Type_Cd = ClsConvert.ToString(dr["UNIT_TYPE_CD", v]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER", v]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT", v]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER", v]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT", v]);
			Unit_Type_Dsc = ClsConvert.ToString(dr["UNIT_TYPE_DSC", v]);
			Active_Flg = ClsConvert.ToString(dr["ACTIVE_FLG", v]);
			Units_Required_Flg = ClsConvert.ToString(dr["UNITS_REQUIRED_FLG", v]);
			Grid_Column_Dsc = ClsConvert.ToString(dr["GRID_COLUMN_DSC", v]);
			Db_Column_Nm = ClsConvert.ToString(dr["DB_COLUMN_NM", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["UNIT_TYPE_CD"] = ClsConvert.ToDbObject(Unit_Type_Cd);
			dr["CREATE_USER"] = ClsConvert.ToDbObject(Create_User);
			dr["CREATE_DT"] = ClsConvert.ToDbObject(Create_Dt);
			dr["MODIFY_USER"] = ClsConvert.ToDbObject(Modify_User);
			dr["MODIFY_DT"] = ClsConvert.ToDbObject(Modify_Dt);
			dr["UNIT_TYPE_DSC"] = ClsConvert.ToDbObject(Unit_Type_Dsc);
			dr["ACTIVE_FLG"] = ClsConvert.ToDbObject(Active_Flg);
			dr["UNITS_REQUIRED_FLG"] = ClsConvert.ToDbObject(Units_Required_Flg);
			dr["GRID_COLUMN_DSC"] = ClsConvert.ToDbObject(Grid_Column_Dsc);
			dr["DB_COLUMN_NM"] = ClsConvert.ToDbObject(Db_Column_Nm);
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

		public static ClsUnitType GetUsingKey(string Unit_Type_Cd)
		{
			object[] vals = new object[] {Unit_Type_Cd};
			DataRow dr = Connection.GetDataRowUsingKey
				(TableName, GetPrimaryKeys(), vals);
			return ( dr == null ) ? null : new ClsUnitType(dr);
		}

		#endregion		// #region Static Methods
	}
}