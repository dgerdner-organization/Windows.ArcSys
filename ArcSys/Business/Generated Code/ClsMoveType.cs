using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsMoveType : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ArcSys"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "R_MOVE_TYPE";
		public const int PrimaryKeyCount = 1;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] { "MOVE_TYPE_CD" };
		}

		public const string SelectSQL = "SELECT * FROM R_MOVE_TYPE";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Move_Type_CdMax = 10;
		public const int Move_Type_DscMax = 50;
		public const int Create_UserMax = 30;
		public const int Modify_UserMax = 30;
		public const int Active_FlgMax = 1;
		public const int Door_In_FlgMax = 1;
		public const int Door_Out_FlgMax = 1;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected string _Move_Type_Cd;
		protected string _Move_Type_Dsc;
		protected string _Create_User;
		protected DateTime? _Create_Dt;
		protected string _Modify_User;
		protected DateTime? _Modify_Dt;
		protected string _Active_Flg;
		protected string _Door_In_Flg;
		protected string _Door_Out_Flg;

		#endregion	// #region Column Fields

		#region Column Properties

		public string Move_Type_Cd
		{
			get { return _Move_Type_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Move_Type_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Move_Type_CdMax )
					_Move_Type_Cd = val.Substring(0, (int)Move_Type_CdMax);
				else
					_Move_Type_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Move_Type_Cd");
			}
		}
		public string Move_Type_Dsc
		{
			get { return _Move_Type_Dsc; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Move_Type_Dsc, val, false) == 0 ) return;
		
				if( val != null && val.Length > Move_Type_DscMax )
					_Move_Type_Dsc = val.Substring(0, (int)Move_Type_DscMax);
				else
					_Move_Type_Dsc = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Move_Type_Dsc");
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
		public string Door_In_Flg
		{
			get { return _Door_In_Flg; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Door_In_Flg, val, false) == 0 ) return;
		
				if( val != null && val.Length > Door_In_FlgMax )
					_Door_In_Flg = val.Substring(0, (int)Door_In_FlgMax);
				else
					_Door_In_Flg = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Door_In_Flg");
			}
		}
		public string Door_Out_Flg
		{
			get { return _Door_Out_Flg; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Door_Out_Flg, val, false) == 0 ) return;
		
				if( val != null && val.Length > Door_Out_FlgMax )
					_Door_Out_Flg = val.Substring(0, (int)Door_Out_FlgMax);
				else
					_Door_Out_Flg = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Door_Out_Flg");
			}
		}

		#endregion	// #region Column Properties

		#region Foreign Key Fields



		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties



		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsMoveType() : base() {}
		public ClsMoveType(DataRow dr) : base(dr) {}
		public ClsMoveType(ClsMoveType src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Move_Type_Cd = null;
			Move_Type_Dsc = null;
			Create_User = null;
			Create_Dt = null;
			Modify_User = null;
			Modify_Dt = null;
			Active_Flg = null;
			Door_In_Flg = null;
			Door_Out_Flg = null;
		}

		public void CopyFrom(ClsMoveType src)
		{
			Move_Type_Cd = src._Move_Type_Cd;
			Move_Type_Dsc = src._Move_Type_Dsc;
			Create_User = src._Create_User;
			Create_Dt = src._Create_Dt;
			Modify_User = src._Modify_User;
			Modify_Dt = src._Modify_Dt;
			Active_Flg = src._Active_Flg;
			Door_In_Flg = src._Door_In_Flg;
			Door_Out_Flg = src._Door_Out_Flg;
		}

		public override bool ReloadFromDB()
		{
			ClsMoveType tmp = ClsMoveType.GetUsingKey(Move_Type_Cd);
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
				("@MOVE_TYPE_CD", Move_Type_Cd);
			p[1] = Connection.GetParameter
				("@MOVE_TYPE_DSC", Move_Type_Dsc);
			p[2] = Connection.GetParameter
				("@ACTIVE_FLG", Active_Flg);
			p[3] = Connection.GetParameter
				("@DOOR_IN_FLG", Door_In_Flg);
			p[4] = Connection.GetParameter
				("@DOOR_OUT_FLG", Door_Out_Flg);
			p[5] = Connection.GetParameter
				("@CREATE_USER", Create_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Create_UserMax);
			p[6] = Connection.GetParameter
				("@CREATE_DT", Create_Dt, ParameterDirection.Output, DbType.DateTime, 0);
			p[7] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);
			p[8] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.Output, DbType.DateTime, 0);

			const string sql = @"
				INSERT INTO R_MOVE_TYPE
					(MOVE_TYPE_CD, MOVE_TYPE_DSC, ACTIVE_FLG,
					DOOR_IN_FLG, DOOR_OUT_FLG)
				VALUES
					(@MOVE_TYPE_CD, @MOVE_TYPE_DSC, @ACTIVE_FLG,
					@DOOR_IN_FLG, @DOOR_OUT_FLG)
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
				("@MOVE_TYPE_DSC", Move_Type_Dsc);
			p[1] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.InputOutput, DbType.DateTime, 0);
			p[2] = Connection.GetParameter
				("@ACTIVE_FLG", Active_Flg);
			p[3] = Connection.GetParameter
				("@DOOR_IN_FLG", Door_In_Flg);
			p[4] = Connection.GetParameter
				("@DOOR_OUT_FLG", Door_Out_Flg);
			p[5] = Connection.GetParameter
				("@MOVE_TYPE_CD", Move_Type_Cd);
			p[6] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);

			const string sql = @"
				UPDATE R_MOVE_TYPE SET
					MOVE_TYPE_DSC = @MOVE_TYPE_DSC,
					MODIFY_DT = @MODIFY_DT,
					ACTIVE_FLG = @ACTIVE_FLG,
					DOOR_IN_FLG = @DOOR_IN_FLG,
					DOOR_OUT_FLG = @DOOR_OUT_FLG
				WHERE
					MOVE_TYPE_CD = @MOVE_TYPE_CD
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
				("@MOVE_TYPE_CD", Move_Type_Cd);

			const string sql = @"
				DELETE FROM R_MOVE_TYPE WHERE
				MOVE_TYPE_CD=@MOVE_TYPE_CD";
			return Connection.RunSQL(sql, p);
		}
		#endregion		// #region Insert, Update, Delete

		#region Conversion methods

		public override void LoadFromDataReader(DbDataReader dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataReader: DataReader parameter was null");

			Move_Type_Cd = ClsConvert.ToString(dr["MOVE_TYPE_CD"]);
			Move_Type_Dsc = ClsConvert.ToString(dr["MOVE_TYPE_DSC"]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER"]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT"]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER"]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT"]);
			Active_Flg = ClsConvert.ToString(dr["ACTIVE_FLG"]);
			Door_In_Flg = ClsConvert.ToString(dr["DOOR_IN_FLG"]);
			Door_Out_Flg = ClsConvert.ToString(dr["DOOR_OUT_FLG"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Move_Type_Cd = ClsConvert.ToString(dr["MOVE_TYPE_CD", v]);
			Move_Type_Dsc = ClsConvert.ToString(dr["MOVE_TYPE_DSC", v]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER", v]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT", v]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER", v]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT", v]);
			Active_Flg = ClsConvert.ToString(dr["ACTIVE_FLG", v]);
			Door_In_Flg = ClsConvert.ToString(dr["DOOR_IN_FLG", v]);
			Door_Out_Flg = ClsConvert.ToString(dr["DOOR_OUT_FLG", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["MOVE_TYPE_CD"] = ClsConvert.ToDbObject(Move_Type_Cd);
			dr["MOVE_TYPE_DSC"] = ClsConvert.ToDbObject(Move_Type_Dsc);
			dr["CREATE_USER"] = ClsConvert.ToDbObject(Create_User);
			dr["CREATE_DT"] = ClsConvert.ToDbObject(Create_Dt);
			dr["MODIFY_USER"] = ClsConvert.ToDbObject(Modify_User);
			dr["MODIFY_DT"] = ClsConvert.ToDbObject(Modify_Dt);
			dr["ACTIVE_FLG"] = ClsConvert.ToDbObject(Active_Flg);
			dr["DOOR_IN_FLG"] = ClsConvert.ToDbObject(Door_In_Flg);
			dr["DOOR_OUT_FLG"] = ClsConvert.ToDbObject(Door_Out_Flg);
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

		public static ClsMoveType GetUsingKey(string Move_Type_Cd)
		{
			object[] vals = new object[] {Move_Type_Cd};
			DataRow dr = Connection.GetDataRowUsingKey
				(TableName, GetPrimaryKeys(), vals);
			return ( dr == null ) ? null : new ClsMoveType(dr);
		}

		#endregion		// #region Static Methods
	}
}