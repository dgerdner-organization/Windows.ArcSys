using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsUscbpExportAes : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ArcSys"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "T_USCBP_EXPORT_AES";
		public const int PrimaryKeyCount = 1;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] { "USCBP_EXPORT_AES_ID" };
		}

		public const string SelectSQL = @"SELECT * FROM T_USCBP_EXPORT_AES 
				INNER JOIN R_TRADING_PARTNER
				ON T_USCBP_EXPORT_AES.TRADING_PARTNER_CD=R_TRADING_PARTNER.TRADING_PARTNER_CD ";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Create_UserMax = 30;
		public const int Modify_UserMax = 30;
		public const int Bol_NoMax = 20;
		public const int Trading_Partner_CdMax = 10;
		public const int File_NmMax = 120;
		public const int Region_CdMax = 5;
		public const int Process_MsgMax = 500;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected Int64? _Uscbp_Export_Aes_ID;
		protected string _Create_User;
		protected DateTime? _Create_Dt;
		protected string _Modify_User;
		protected DateTime? _Modify_Dt;
		protected string _Bol_No;
		protected Int64? _Status_Ind;
		protected string _Trading_Partner_Cd;
		protected string _File_Nm;
		protected Int64? _Exempt_Ind;
		protected string _Region_Cd;
		protected string _Process_Msg;

		#endregion	// #region Column Fields

		#region Column Properties

		public Int64? Uscbp_Export_Aes_ID
		{
			get { return _Uscbp_Export_Aes_ID; }
			set
			{
				if( _Uscbp_Export_Aes_ID == value ) return;
		
				_Uscbp_Export_Aes_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Uscbp_Export_Aes_ID");
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
		public string Bol_No
		{
			get { return _Bol_No; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Bol_No, val, false) == 0 ) return;
		
				if( val != null && val.Length > Bol_NoMax )
					_Bol_No = val.Substring(0, (int)Bol_NoMax);
				else
					_Bol_No = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Bol_No");
			}
		}
		public Int64? Status_Ind
		{
			get { return _Status_Ind; }
			set
			{
				if( _Status_Ind == value ) return;
		
				_Status_Ind = value;
				_IsDirty = true;
				NotifyPropertyChanged("Status_Ind");
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
		public Int64? Exempt_Ind
		{
			get { return _Exempt_Ind; }
			set
			{
				if( _Exempt_Ind == value ) return;
		
				_Exempt_Ind = value;
				_IsDirty = true;
				NotifyPropertyChanged("Exempt_Ind");
			}
		}
		public string Region_Cd
		{
			get { return _Region_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Region_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Region_CdMax )
					_Region_Cd = val.Substring(0, (int)Region_CdMax);
				else
					_Region_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Region_Cd");
			}
		}
		public string Process_Msg
		{
			get { return _Process_Msg; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Process_Msg, val, false) == 0 ) return;
		
				if( val != null && val.Length > Process_MsgMax )
					_Process_Msg = val.Substring(0, (int)Process_MsgMax);
				else
					_Process_Msg = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Process_Msg");
			}
		}

		#endregion	// #region Column Properties

		#region Foreign Key Fields



		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties



		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsUscbpExportAes() : base() {}
		public ClsUscbpExportAes(DataRow dr) : base(dr) {}
		public ClsUscbpExportAes(ClsUscbpExportAes src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Uscbp_Export_Aes_ID = null;
			Create_User = null;
			Create_Dt = null;
			Modify_User = null;
			Modify_Dt = null;
			Bol_No = null;
			Status_Ind = null;
			Trading_Partner_Cd = null;
			File_Nm = null;
			Exempt_Ind = null;
			Region_Cd = null;
			Process_Msg = null;
		}

		public void CopyFrom(ClsUscbpExportAes src)
		{
			Uscbp_Export_Aes_ID = src._Uscbp_Export_Aes_ID;
			Create_User = src._Create_User;
			Create_Dt = src._Create_Dt;
			Modify_User = src._Modify_User;
			Modify_Dt = src._Modify_Dt;
			Bol_No = src._Bol_No;
			Status_Ind = src._Status_Ind;
			Trading_Partner_Cd = src._Trading_Partner_Cd;
			File_Nm = src._File_Nm;
			Exempt_Ind = src._Exempt_Ind;
			Region_Cd = src._Region_Cd;
			Process_Msg = src._Process_Msg;
		}

		public override bool ReloadFromDB()
		{
			ClsUscbpExportAes tmp = ClsUscbpExportAes.GetUsingKey(Uscbp_Export_Aes_ID.Value);
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

			DbParameter[] p = new DbParameter[12];

			p[0] = Connection.GetParameter
				("@BOL_NO", Bol_No);
			p[1] = Connection.GetParameter
				("@STATUS_IND", Status_Ind);
			p[2] = Connection.GetParameter
				("@TRADING_PARTNER_CD", Trading_Partner_Cd);
			p[3] = Connection.GetParameter
				("@FILE_NM", File_Nm);
			p[4] = Connection.GetParameter
				("@EXEMPT_IND", Exempt_Ind);
			p[5] = Connection.GetParameter
				("@REGION_CD", Region_Cd);
			p[6] = Connection.GetParameter
				("@PROCESS_MSG", Process_Msg);
			p[7] = Connection.GetParameter
				("@USCBP_EXPORT_AES_ID", Uscbp_Export_Aes_ID, ParameterDirection.Output, DbType.Int64, 0);
			p[8] = Connection.GetParameter
				("@CREATE_USER", Create_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Create_UserMax);
			p[9] = Connection.GetParameter
				("@CREATE_DT", Create_Dt, ParameterDirection.Output, DbType.DateTime, 0);
			p[10] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);
			p[11] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.Output, DbType.DateTime, 0);

			const string sql = @"
				INSERT INTO T_USCBP_EXPORT_AES
					(USCBP_EXPORT_AES_ID, BOL_NO, STATUS_IND,
					TRADING_PARTNER_CD, FILE_NM, EXEMPT_IND,
					REGION_CD, PROCESS_MSG)
				VALUES
					(USCBP_EXPORT_AES_ID_SEQ.NEXTVAL, @BOL_NO, @STATUS_IND,
					@TRADING_PARTNER_CD, @FILE_NM, @EXEMPT_IND,
					@REGION_CD, @PROCESS_MSG)
				RETURNING
					USCBP_EXPORT_AES_ID, CREATE_USER, CREATE_DT,
					MODIFY_USER, MODIFY_DT
				INTO
					@USCBP_EXPORT_AES_ID, @CREATE_USER, @CREATE_DT,
					@MODIFY_USER, @MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Uscbp_Export_Aes_ID = ClsConvert.ToInt64Nullable(p[7].Value);
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
				("@MODIFY_DT", Modify_Dt, ParameterDirection.InputOutput, DbType.DateTime, 0);
			p[1] = Connection.GetParameter
				("@BOL_NO", Bol_No);
			p[2] = Connection.GetParameter
				("@STATUS_IND", Status_Ind);
			p[3] = Connection.GetParameter
				("@TRADING_PARTNER_CD", Trading_Partner_Cd);
			p[4] = Connection.GetParameter
				("@FILE_NM", File_Nm);
			p[5] = Connection.GetParameter
				("@EXEMPT_IND", Exempt_Ind);
			p[6] = Connection.GetParameter
				("@REGION_CD", Region_Cd);
			p[7] = Connection.GetParameter
				("@PROCESS_MSG", Process_Msg);
			p[8] = Connection.GetParameter
				("@USCBP_EXPORT_AES_ID", Uscbp_Export_Aes_ID);
			p[9] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);

			const string sql = @"
				UPDATE T_USCBP_EXPORT_AES SET
					MODIFY_DT = @MODIFY_DT,
					BOL_NO = @BOL_NO,
					STATUS_IND = @STATUS_IND,
					TRADING_PARTNER_CD = @TRADING_PARTNER_CD,
					FILE_NM = @FILE_NM,
					EXEMPT_IND = @EXEMPT_IND,
					REGION_CD = @REGION_CD,
					PROCESS_MSG = @PROCESS_MSG
				WHERE
					USCBP_EXPORT_AES_ID = @USCBP_EXPORT_AES_ID
				RETURNING
					MODIFY_USER, MODIFY_DT
				INTO
					@MODIFY_USER, @MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Modify_Dt = ClsConvert.ToDateTimeNullable(p[0].Value);
			Modify_User = ClsConvert.ToString(p[9].Value);
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

			Uscbp_Export_Aes_ID = ClsConvert.ToInt64Nullable(dr["USCBP_EXPORT_AES_ID"]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER"]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT"]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER"]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT"]);
			Bol_No = ClsConvert.ToString(dr["BOL_NO"]);
			Status_Ind = ClsConvert.ToInt64Nullable(dr["STATUS_IND"]);
			Trading_Partner_Cd = ClsConvert.ToString(dr["TRADING_PARTNER_CD"]);
			File_Nm = ClsConvert.ToString(dr["FILE_NM"]);
			Exempt_Ind = ClsConvert.ToInt64Nullable(dr["EXEMPT_IND"]);
			Region_Cd = ClsConvert.ToString(dr["REGION_CD"]);
			Process_Msg = ClsConvert.ToString(dr["PROCESS_MSG"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Uscbp_Export_Aes_ID = ClsConvert.ToInt64Nullable(dr["USCBP_EXPORT_AES_ID", v]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER", v]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT", v]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER", v]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT", v]);
			Bol_No = ClsConvert.ToString(dr["BOL_NO", v]);
			Status_Ind = ClsConvert.ToInt64Nullable(dr["STATUS_IND", v]);
			Trading_Partner_Cd = ClsConvert.ToString(dr["TRADING_PARTNER_CD", v]);
			File_Nm = ClsConvert.ToString(dr["FILE_NM", v]);
			Exempt_Ind = ClsConvert.ToInt64Nullable(dr["EXEMPT_IND", v]);
			Region_Cd = ClsConvert.ToString(dr["REGION_CD", v]);
			Process_Msg = ClsConvert.ToString(dr["PROCESS_MSG", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["USCBP_EXPORT_AES_ID"] = ClsConvert.ToDbObject(Uscbp_Export_Aes_ID);
			dr["CREATE_USER"] = ClsConvert.ToDbObject(Create_User);
			dr["CREATE_DT"] = ClsConvert.ToDbObject(Create_Dt);
			dr["MODIFY_USER"] = ClsConvert.ToDbObject(Modify_User);
			dr["MODIFY_DT"] = ClsConvert.ToDbObject(Modify_Dt);
			dr["BOL_NO"] = ClsConvert.ToDbObject(Bol_No);
			dr["STATUS_IND"] = ClsConvert.ToDbObject(Status_Ind);
			dr["TRADING_PARTNER_CD"] = ClsConvert.ToDbObject(Trading_Partner_Cd);
			dr["FILE_NM"] = ClsConvert.ToDbObject(File_Nm);
			dr["EXEMPT_IND"] = ClsConvert.ToDbObject(Exempt_Ind);
			dr["REGION_CD"] = ClsConvert.ToDbObject(Region_Cd);
			dr["PROCESS_MSG"] = ClsConvert.ToDbObject(Process_Msg);
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

		public static ClsUscbpExportAes GetUsingKey(Int64 Uscbp_Export_Aes_ID)
		{
			object[] vals = new object[] {Uscbp_Export_Aes_ID};
			DataRow dr = Connection.GetDataRowUsingKey
				(TableName, GetPrimaryKeys(), vals);
			return ( dr == null ) ? null : new ClsUscbpExportAes(dr);
		}
		public static DataTable GetAll(string Trading_Partner_Cd)
		{
			List<DbParameter> lst = new List<DbParameter>();	
			StringBuilder sb = new StringBuilder();
		
			if( string.IsNullOrEmpty(Trading_Partner_Cd) == false )
			{
				lst.Add(Connection.GetParameter("@TRADING_PARTNER_CD", Trading_Partner_Cd));
				sb.Append(" WHERE T_USCBP_EXPORT_AES.TRADING_PARTNER_CD=@TRADING_PARTNER_CD");
			}
			sb.Insert(0, SelectSQL);
			return Connection.GetDataTable(sb.ToString(), lst.ToArray());
		}
		#endregion		// #region Static Methods
	}
}