using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsIsa : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ArcSys"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "T_ISA";
		public const int PrimaryKeyCount = 1;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] { "ISA_ID" };
		}

		public const string SelectSQL = @"SELECT * FROM T_ISA 
				LEFT OUTER JOIN R_TRADING_PARTNER
				ON T_ISA.TRADING_PARTNER_CD=R_TRADING_PARTNER.TRADING_PARTNER_CD ";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Create_UserMax = 30;
		public const int Modify_UserMax = 30;
		public const int In_OutMax = 1;
		public const int Trading_Partner_CdMax = 10;
		public const int Map_NmMax = 20;
		public const int Edi_TypeMax = 10;
		public const int File_NmMax = 200;
		public const int Folder_NmMax = 200;
		public const int Error_FlgMax = 1;
		public const int Error_MsgMax = 500;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected Int64? _Isa_ID;
		protected DateTime? _Create_Dt;
		protected string _Create_User;
		protected DateTime? _Modify_Dt;
		protected string _Modify_User;
		protected Int64? _Isa_No;
		protected string _In_Out;
		protected string _Trading_Partner_Cd;
		protected string _Map_Nm;
		protected string _Edi_Type;
		protected string _File_Nm;
		protected string _Folder_Nm;
		protected string _Error_Flg;
		protected string _Error_Msg;
		protected DateTime? _Isa_Dt;

		#endregion	// #region Column Fields

		#region Column Properties

		public Int64? Isa_ID
		{
			get { return _Isa_ID; }
			set
			{
				if( _Isa_ID == value ) return;
		
				_Isa_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Isa_ID");
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
		public Int64? Isa_No
		{
			get { return _Isa_No; }
			set
			{
				if( _Isa_No == value ) return;
		
				_Isa_No = value;
				_IsDirty = true;
				NotifyPropertyChanged("Isa_No");
			}
		}
		public string In_Out
		{
			get { return _In_Out; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_In_Out, val, false) == 0 ) return;
		
				if( val != null && val.Length > In_OutMax )
					_In_Out = val.Substring(0, (int)In_OutMax);
				else
					_In_Out = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("In_Out");
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
		public string Map_Nm
		{
			get { return _Map_Nm; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Map_Nm, val, false) == 0 ) return;
		
				if( val != null && val.Length > Map_NmMax )
					_Map_Nm = val.Substring(0, (int)Map_NmMax);
				else
					_Map_Nm = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Map_Nm");
			}
		}
		public string Edi_Type
		{
			get { return _Edi_Type; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Edi_Type, val, false) == 0 ) return;
		
				if( val != null && val.Length > Edi_TypeMax )
					_Edi_Type = val.Substring(0, (int)Edi_TypeMax);
				else
					_Edi_Type = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Edi_Type");
			}
		}
		public string File_Nm
		{
			get { return _File_Nm; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_File_Nm, val, false) == 0 ) return;
		
				if( val != null && val.Length > File_NmMax )
					_File_Nm = val.Substring(0, (int)File_NmMax);
				else
					_File_Nm = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("File_Nm");
			}
		}
		public string Folder_Nm
		{
			get { return _Folder_Nm; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Folder_Nm, val, false) == 0 ) return;
		
				if( val != null && val.Length > Folder_NmMax )
					_Folder_Nm = val.Substring(0, (int)Folder_NmMax);
				else
					_Folder_Nm = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Folder_Nm");
			}
		}
		public string Error_Flg
		{
			get { return _Error_Flg; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Error_Flg, val, false) == 0 ) return;
		
				if( val != null && val.Length > Error_FlgMax )
					_Error_Flg = val.Substring(0, (int)Error_FlgMax);
				else
					_Error_Flg = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Error_Flg");
			}
		}
		public string Error_Msg
		{
			get { return _Error_Msg; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Error_Msg, val, false) == 0 ) return;
		
				if( val != null && val.Length > Error_MsgMax )
					_Error_Msg = val.Substring(0, (int)Error_MsgMax);
				else
					_Error_Msg = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Error_Msg");
			}
		}
		public DateTime? Isa_Dt
		{
			get { return _Isa_Dt; }
			set
			{
				if( _Isa_Dt == value ) return;
		
				_Isa_Dt = value;
				_IsDirty = true;
				NotifyPropertyChanged("Isa_Dt");
			}
		}

		#endregion	// #region Column Properties

		#region Foreign Key Fields



		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties



		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsIsa() : base() {}
		public ClsIsa(DataRow dr) : base(dr) {}
		public ClsIsa(ClsIsa src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Isa_ID = null;
			Create_Dt = null;
			Create_User = null;
			Modify_Dt = null;
			Modify_User = null;
			Isa_No = null;
			In_Out = null;
			Trading_Partner_Cd = null;
			Map_Nm = null;
			Edi_Type = null;
			File_Nm = null;
			Folder_Nm = null;
			Error_Flg = null;
			Error_Msg = null;
			Isa_Dt = null;
		}

		public void CopyFrom(ClsIsa src)
		{
			Isa_ID = src._Isa_ID;
			Create_Dt = src._Create_Dt;
			Create_User = src._Create_User;
			Modify_Dt = src._Modify_Dt;
			Modify_User = src._Modify_User;
			Isa_No = src._Isa_No;
			In_Out = src._In_Out;
			Trading_Partner_Cd = src._Trading_Partner_Cd;
			Map_Nm = src._Map_Nm;
			Edi_Type = src._Edi_Type;
			File_Nm = src._File_Nm;
			Folder_Nm = src._Folder_Nm;
			Error_Flg = src._Error_Flg;
			Error_Msg = src._Error_Msg;
			Isa_Dt = src._Isa_Dt;
		}

		public override bool ReloadFromDB()
		{
			ClsIsa tmp = ClsIsa.GetUsingKey(Isa_ID.Value);
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

			DbParameter[] p = new DbParameter[15];

			p[0] = Connection.GetParameter
				("@ISA_NO", Isa_No);
			p[1] = Connection.GetParameter
				("@IN_OUT", In_Out);
			p[2] = Connection.GetParameter
				("@TRADING_PARTNER_CD", Trading_Partner_Cd);
			p[3] = Connection.GetParameter
				("@MAP_NM", Map_Nm);
			p[4] = Connection.GetParameter
				("@EDI_TYPE", Edi_Type);
			p[5] = Connection.GetParameter
				("@FILE_NM", File_Nm);
			p[6] = Connection.GetParameter
				("@FOLDER_NM", Folder_Nm);
			p[7] = Connection.GetParameter
				("@ERROR_FLG", Error_Flg);
			p[8] = Connection.GetParameter
				("@ERROR_MSG", Error_Msg);
			p[9] = Connection.GetParameter
				("@ISA_DT", Isa_Dt);
			p[10] = Connection.GetParameter
				("@ISA_ID", Isa_ID, ParameterDirection.Output, DbType.Int64, 0);
			p[11] = Connection.GetParameter
				("@CREATE_DT", Create_Dt, ParameterDirection.Output, DbType.DateTime, 0);
			p[12] = Connection.GetParameter
				("@CREATE_USER", Create_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Create_UserMax);
			p[13] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.Output, DbType.DateTime, 0);
			p[14] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);

			const string sql = @"
				INSERT INTO T_ISA
					(ISA_ID, ISA_NO, IN_OUT,
					TRADING_PARTNER_CD, MAP_NM, EDI_TYPE,
					FILE_NM, FOLDER_NM, ERROR_FLG,
					ERROR_MSG, ISA_DT)
				VALUES
					(ISA_ID_SEQ.NEXTVAL, @ISA_NO, @IN_OUT,
					@TRADING_PARTNER_CD, @MAP_NM, @EDI_TYPE,
					@FILE_NM, @FOLDER_NM, @ERROR_FLG,
					@ERROR_MSG, @ISA_DT)
				RETURNING
					ISA_ID, CREATE_DT, CREATE_USER,
					MODIFY_DT, MODIFY_USER
				INTO
					@ISA_ID, @CREATE_DT, @CREATE_USER,
					@MODIFY_DT, @MODIFY_USER";
			int ret = Connection.RunSQL(sql, p);

			Isa_ID = ClsConvert.ToInt64Nullable(p[10].Value);
			Create_Dt = ClsConvert.ToDateTimeNullable(p[11].Value);
			Create_User = ClsConvert.ToString(p[12].Value);
			Modify_Dt = ClsConvert.ToDateTimeNullable(p[13].Value);
			Modify_User = ClsConvert.ToString(p[14].Value);
			return ret;
		}
		public override int Update()
		{
			DbParameter[] p = new DbParameter[13];

			p[0] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.InputOutput, DbType.DateTime, 0);
			p[1] = Connection.GetParameter
				("@ISA_NO", Isa_No);
			p[2] = Connection.GetParameter
				("@IN_OUT", In_Out);
			p[3] = Connection.GetParameter
				("@TRADING_PARTNER_CD", Trading_Partner_Cd);
			p[4] = Connection.GetParameter
				("@MAP_NM", Map_Nm);
			p[5] = Connection.GetParameter
				("@EDI_TYPE", Edi_Type);
			p[6] = Connection.GetParameter
				("@FILE_NM", File_Nm);
			p[7] = Connection.GetParameter
				("@FOLDER_NM", Folder_Nm);
			p[8] = Connection.GetParameter
				("@ERROR_FLG", Error_Flg);
			p[9] = Connection.GetParameter
				("@ERROR_MSG", Error_Msg);
			p[10] = Connection.GetParameter
				("@ISA_DT", Isa_Dt);
			p[11] = Connection.GetParameter
				("@ISA_ID", Isa_ID);
			p[12] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);

			const string sql = @"
				UPDATE T_ISA SET
					MODIFY_DT = @MODIFY_DT,
					ISA_NO = @ISA_NO,
					IN_OUT = @IN_OUT,
					TRADING_PARTNER_CD = @TRADING_PARTNER_CD,
					MAP_NM = @MAP_NM,
					EDI_TYPE = @EDI_TYPE,
					FILE_NM = @FILE_NM,
					FOLDER_NM = @FOLDER_NM,
					ERROR_FLG = @ERROR_FLG,
					ERROR_MSG = @ERROR_MSG,
					ISA_DT = @ISA_DT
				WHERE
					ISA_ID = @ISA_ID
				RETURNING
					MODIFY_DT, MODIFY_USER
				INTO
					@MODIFY_DT, @MODIFY_USER";
			int ret = Connection.RunSQL(sql, p);

			Modify_Dt = ClsConvert.ToDateTimeNullable(p[0].Value);
			Modify_User = ClsConvert.ToString(p[12].Value);
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

			Isa_ID = ClsConvert.ToInt64Nullable(dr["ISA_ID"]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT"]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER"]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT"]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER"]);
			Isa_No = ClsConvert.ToInt64Nullable(dr["ISA_NO"]);
			In_Out = ClsConvert.ToString(dr["IN_OUT"]);
			Trading_Partner_Cd = ClsConvert.ToString(dr["TRADING_PARTNER_CD"]);
			Map_Nm = ClsConvert.ToString(dr["MAP_NM"]);
			Edi_Type = ClsConvert.ToString(dr["EDI_TYPE"]);
			File_Nm = ClsConvert.ToString(dr["FILE_NM"]);
			Folder_Nm = ClsConvert.ToString(dr["FOLDER_NM"]);
			Error_Flg = ClsConvert.ToString(dr["ERROR_FLG"]);
			Error_Msg = ClsConvert.ToString(dr["ERROR_MSG"]);
			Isa_Dt = ClsConvert.ToDateTimeNullable(dr["ISA_DT"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Isa_ID = ClsConvert.ToInt64Nullable(dr["ISA_ID", v]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT", v]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER", v]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT", v]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER", v]);
			Isa_No = ClsConvert.ToInt64Nullable(dr["ISA_NO", v]);
			In_Out = ClsConvert.ToString(dr["IN_OUT", v]);
			Trading_Partner_Cd = ClsConvert.ToString(dr["TRADING_PARTNER_CD", v]);
			Map_Nm = ClsConvert.ToString(dr["MAP_NM", v]);
			Edi_Type = ClsConvert.ToString(dr["EDI_TYPE", v]);
			File_Nm = ClsConvert.ToString(dr["FILE_NM", v]);
			Folder_Nm = ClsConvert.ToString(dr["FOLDER_NM", v]);
			Error_Flg = ClsConvert.ToString(dr["ERROR_FLG", v]);
			Error_Msg = ClsConvert.ToString(dr["ERROR_MSG", v]);
			Isa_Dt = ClsConvert.ToDateTimeNullable(dr["ISA_DT", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["ISA_ID"] = ClsConvert.ToDbObject(Isa_ID);
			dr["CREATE_DT"] = ClsConvert.ToDbObject(Create_Dt);
			dr["CREATE_USER"] = ClsConvert.ToDbObject(Create_User);
			dr["MODIFY_DT"] = ClsConvert.ToDbObject(Modify_Dt);
			dr["MODIFY_USER"] = ClsConvert.ToDbObject(Modify_User);
			dr["ISA_NO"] = ClsConvert.ToDbObject(Isa_No);
			dr["IN_OUT"] = ClsConvert.ToDbObject(In_Out);
			dr["TRADING_PARTNER_CD"] = ClsConvert.ToDbObject(Trading_Partner_Cd);
			dr["MAP_NM"] = ClsConvert.ToDbObject(Map_Nm);
			dr["EDI_TYPE"] = ClsConvert.ToDbObject(Edi_Type);
			dr["FILE_NM"] = ClsConvert.ToDbObject(File_Nm);
			dr["FOLDER_NM"] = ClsConvert.ToDbObject(Folder_Nm);
			dr["ERROR_FLG"] = ClsConvert.ToDbObject(Error_Flg);
			dr["ERROR_MSG"] = ClsConvert.ToDbObject(Error_Msg);
			dr["ISA_DT"] = ClsConvert.ToDbObject(Isa_Dt);
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

		public static ClsIsa GetUsingKey(Int64 Isa_ID)
		{
			object[] vals = new object[] {Isa_ID};
			DataRow dr = Connection.GetDataRowUsingKey
				(TableName, GetPrimaryKeys(), vals);
			return ( dr == null ) ? null : new ClsIsa(dr);
		}
		public static DataTable GetAll(string Trading_Partner_Cd)
		{
			List<DbParameter> lst = new List<DbParameter>();	
			StringBuilder sb = new StringBuilder();
		
			if( string.IsNullOrEmpty(Trading_Partner_Cd) == false )
			{
				lst.Add(Connection.GetParameter("@TRADING_PARTNER_CD", Trading_Partner_Cd));
				sb.Append(" WHERE T_ISA.TRADING_PARTNER_CD=@TRADING_PARTNER_CD");
			}
			sb.Insert(0, SelectSQL);
			return Connection.GetDataTable(sb.ToString(), lst.ToArray());
		}
		#endregion		// #region Static Methods
	}
}