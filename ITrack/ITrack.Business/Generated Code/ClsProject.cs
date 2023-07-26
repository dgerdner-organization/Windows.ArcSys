using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace ASL.ITrack.Business
{
	public partial class ClsProject : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ITrack"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "R_PROJECT";
		public const int PrimaryKeyCount = 1;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] { "PROJECT_CD" };
		}

		public const string SelectSQL = "SELECT * FROM R_PROJECT";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Project_CdMax = 10;
		public const int Project_NmMax = 50;
		public const int Create_UserMax = 30;
		public const int Modify_UserMax = 30;
		public const int Active_FlgMax = 1;
		public const int Dev_Only_FlgMax = 1;
		public const int Next_Version_NoMax = 10;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected string _Project_Cd;
		protected string _Project_Nm;
		protected string _Create_User;
		protected DateTime? _Create_Dt;
		protected string _Modify_User;
		protected DateTime? _Modify_Dt;
		protected string _Active_Flg;
		protected string _Dev_Only_Flg;
		protected string _Next_Version_No;

		#endregion	// #region Column Fields

		#region Column Properties

		public string Project_Cd
		{
			get { return _Project_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Project_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Project_CdMax )
					_Project_Cd = val.Substring(0, (int)Project_CdMax);
				else
					_Project_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Project_Cd");
			}
		}
		public string Project_Nm
		{
			get { return _Project_Nm; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Project_Nm, val, false) == 0 ) return;
		
				if( val != null && val.Length > Project_NmMax )
					_Project_Nm = val.Substring(0, (int)Project_NmMax);
				else
					_Project_Nm = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Project_Nm");
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
		public string Dev_Only_Flg
		{
			get { return _Dev_Only_Flg; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Dev_Only_Flg, val, false) == 0 ) return;
		
				if( val != null && val.Length > Dev_Only_FlgMax )
					_Dev_Only_Flg = val.Substring(0, (int)Dev_Only_FlgMax);
				else
					_Dev_Only_Flg = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Dev_Only_Flg");
			}
		}
		public string Next_Version_No
		{
			get { return _Next_Version_No; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Next_Version_No, val, false) == 0 ) return;
		
				if( val != null && val.Length > Next_Version_NoMax )
					_Next_Version_No = val.Substring(0, (int)Next_Version_NoMax);
				else
					_Next_Version_No = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Next_Version_No");
			}
		}

		#endregion	// #region Column Properties

		#region Foreign Key Fields



		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties



		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsProject() : base() {}
		public ClsProject(DataRow dr) : base(dr) {}
		public ClsProject(ClsProject src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Project_Cd = null;
			Project_Nm = null;
			Create_User = null;
			Create_Dt = null;
			Modify_User = null;
			Modify_Dt = null;
			Active_Flg = null;
			Dev_Only_Flg = null;
			Next_Version_No = null;
		}

		public void CopyFrom(ClsProject src)
		{
			Project_Cd = src._Project_Cd;
			Project_Nm = src._Project_Nm;
			Create_User = src._Create_User;
			Create_Dt = src._Create_Dt;
			Modify_User = src._Modify_User;
			Modify_Dt = src._Modify_Dt;
			Active_Flg = src._Active_Flg;
			Dev_Only_Flg = src._Dev_Only_Flg;
			Next_Version_No = src._Next_Version_No;
		}

		public override bool ReloadFromDB()
		{
			ClsProject tmp = ClsProject.GetUsingKey(Project_Cd);
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

			DbParameter[] p = new DbParameter[9];

			p[0] = Connection.GetParameter
				("@PROJECT_CD", Project_Cd);
			p[1] = Connection.GetParameter
				("@PROJECT_NM", Project_Nm);
			p[2] = Connection.GetParameter
				("@ACTIVE_FLG", Active_Flg);
			p[3] = Connection.GetParameter
				("@DEV_ONLY_FLG", Dev_Only_Flg);
			p[4] = Connection.GetParameter
				("@NEXT_VERSION_NO", Next_Version_No);
			p[5] = Connection.GetParameter
				("@CREATE_USER", Create_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Create_UserMax);
			p[6] = Connection.GetParameter
				("@CREATE_DT", Create_Dt, ParameterDirection.Output, DbType.DateTime, 0);
			p[7] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);
			p[8] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.Output, DbType.DateTime, 0);

			const string sql = @"
				INSERT INTO R_PROJECT
					(PROJECT_CD, PROJECT_NM, ACTIVE_FLG,
					DEV_ONLY_FLG, NEXT_VERSION_NO)
				VALUES
					(@PROJECT_CD, @PROJECT_NM, @ACTIVE_FLG,
					@DEV_ONLY_FLG, @NEXT_VERSION_NO)
				RETURNING
					CREATE_USER, CREATE_DT, MODIFY_USER,
					MODIFY_DT
				INTO
					@CREATE_USER, @CREATE_DT, @MODIFY_USER,
					@MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

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
				("@PROJECT_NM", Project_Nm);
			p[1] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.InputOutput, DbType.DateTime, 0);
			p[2] = Connection.GetParameter
				("@ACTIVE_FLG", Active_Flg);
			p[3] = Connection.GetParameter
				("@DEV_ONLY_FLG", Dev_Only_Flg);
			p[4] = Connection.GetParameter
				("@NEXT_VERSION_NO", Next_Version_No);
			p[5] = Connection.GetParameter
				("@PROJECT_CD", Project_Cd);
			p[6] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);

			const string sql = @"
				UPDATE R_PROJECT SET
					PROJECT_NM = @PROJECT_NM,
					MODIFY_DT = @MODIFY_DT,
					ACTIVE_FLG = @ACTIVE_FLG,
					DEV_ONLY_FLG = @DEV_ONLY_FLG,
					NEXT_VERSION_NO = @NEXT_VERSION_NO
				WHERE
					PROJECT_CD = @PROJECT_CD
				RETURNING
					MODIFY_USER, MODIFY_DT
				INTO
					@MODIFY_USER, @MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Modify_Dt = ClsConvert.ToDateTimeNullable(p[1].Value);
			Modify_User = ClsConvert.ToString(p[6].Value);
			return ret;
		}
		public override int Delete()
		{
			DbParameter[] p = new DbParameter[1];

			p[0] = Connection.GetParameter
				("@PROJECT_CD", Project_Cd);

			const string sql = @"
				DELETE FROM R_PROJECT WHERE
				PROJECT_CD=@PROJECT_CD";
			return Connection.RunSQL(sql, p);
		}
		#endregion		// #region Insert, Update, Delete

		#region Conversion methods

		public override void LoadFromDataReader(DbDataReader dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataReader: DataReader parameter was null");

			Project_Cd = ClsConvert.ToString(dr["PROJECT_CD"]);
			Project_Nm = ClsConvert.ToString(dr["PROJECT_NM"]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER"]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT"]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER"]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT"]);
			Active_Flg = ClsConvert.ToString(dr["ACTIVE_FLG"]);
			Dev_Only_Flg = ClsConvert.ToString(dr["DEV_ONLY_FLG"]);
			Next_Version_No = ClsConvert.ToString(dr["NEXT_VERSION_NO"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Project_Cd = ClsConvert.ToString(dr["PROJECT_CD", v]);
			Project_Nm = ClsConvert.ToString(dr["PROJECT_NM", v]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER", v]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT", v]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER", v]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT", v]);
			Active_Flg = ClsConvert.ToString(dr["ACTIVE_FLG", v]);
			Dev_Only_Flg = ClsConvert.ToString(dr["DEV_ONLY_FLG", v]);
			Next_Version_No = ClsConvert.ToString(dr["NEXT_VERSION_NO", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["PROJECT_CD"] = ClsConvert.ToDbObject(Project_Cd);
			dr["PROJECT_NM"] = ClsConvert.ToDbObject(Project_Nm);
			dr["CREATE_USER"] = ClsConvert.ToDbObject(Create_User);
			dr["CREATE_DT"] = ClsConvert.ToDbObject(Create_Dt);
			dr["MODIFY_USER"] = ClsConvert.ToDbObject(Modify_User);
			dr["MODIFY_DT"] = ClsConvert.ToDbObject(Modify_Dt);
			dr["ACTIVE_FLG"] = ClsConvert.ToDbObject(Active_Flg);
			dr["DEV_ONLY_FLG"] = ClsConvert.ToDbObject(Dev_Only_Flg);
			dr["NEXT_VERSION_NO"] = ClsConvert.ToDbObject(Next_Version_No);
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

		public static ClsProject GetUsingKey(string Project_Cd)
		{
			object[] vals = new object[] {Project_Cd};
			DataRow dr = Connection.GetDataRowUsingKey
				(TableName, GetPrimaryKeys(), vals);
			return ( dr == null ) ? null : new ClsProject(dr);
		}

		#endregion		// #region Static Methods
	}
}