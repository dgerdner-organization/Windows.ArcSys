using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsApiLog : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ArcSys"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "T_API_LOG";
		public const int PrimaryKeyCount = 1;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] { "API_LOG_ID" };
		}

		public const string SelectSQL = "SELECT * FROM T_API_LOG";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Create_UserMax = 30;
		public const int Modify_UserMax = 30;
		public const int Trading_Partner_CdMax = 10;
		public const int Api_NmMax = 20;
		public const int Success_CdMax = 10;
		public const int Api_MsgMax = 1000;
		public const int Json_SentMax = 4000;
		public const int Message_CdMax = 10;
		public const int Document_NoMax = 50;
		public const int Serial_NoMax = 50;
		public const int Action_CdMax = 10;
		public const int ParametersMax = 200;
		public const int Caller_IDMax = 100;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected Int64? _Api_Log_ID;
		protected DateTime? _Create_Dt;
		protected string _Create_User;
		protected DateTime? _Modify_Dt;
		protected string _Modify_User;
		protected Int64? _Batch_No;
		protected string _Trading_Partner_Cd;
		protected string _Api_Nm;
		protected string _Success_Cd;
		protected string _Api_Msg;
		protected string _Json_Sent;
		protected string _Message_Cd;
		protected string _Document_No;
		protected string _Serial_No;
		protected string _Action_Cd;
		protected string _Parameters;
		protected string _Caller_ID;

		#endregion	// #region Column Fields

		#region Column Properties

		public Int64? Api_Log_ID
		{
			get { return _Api_Log_ID; }
			set
			{
				if( _Api_Log_ID == value ) return;
		
				_Api_Log_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Api_Log_ID");
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
		public Int64? Batch_No
		{
			get { return _Batch_No; }
			set
			{
				if( _Batch_No == value ) return;
		
				_Batch_No = value;
				_IsDirty = true;
				NotifyPropertyChanged("Batch_No");
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
		public string Api_Nm
		{
			get { return _Api_Nm; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Api_Nm, val, false) == 0 ) return;
		
				if( val != null && val.Length > Api_NmMax )
					_Api_Nm = val.Substring(0, (int)Api_NmMax);
				else
					_Api_Nm = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Api_Nm");
			}
		}
		public string Success_Cd
		{
			get { return _Success_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Success_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Success_CdMax )
					_Success_Cd = val.Substring(0, (int)Success_CdMax);
				else
					_Success_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Success_Cd");
			}
		}
		public string Api_Msg
		{
			get { return _Api_Msg; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Api_Msg, val, false) == 0 ) return;
		
				if( val != null && val.Length > Api_MsgMax )
					_Api_Msg = val.Substring(0, (int)Api_MsgMax);
				else
					_Api_Msg = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Api_Msg");
			}
		}
		public string Json_Sent
		{
			get { return _Json_Sent; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Json_Sent, val, false) == 0 ) return;
		
				if( val != null && val.Length > Json_SentMax )
					_Json_Sent = val.Substring(0, (int)Json_SentMax);
				else
					_Json_Sent = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Json_Sent");
			}
		}
		public string Message_Cd
		{
			get { return _Message_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Message_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Message_CdMax )
					_Message_Cd = val.Substring(0, (int)Message_CdMax);
				else
					_Message_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Message_Cd");
			}
		}
		public string Document_No
		{
			get { return _Document_No; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Document_No, val, false) == 0 ) return;
		
				if( val != null && val.Length > Document_NoMax )
					_Document_No = val.Substring(0, (int)Document_NoMax);
				else
					_Document_No = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Document_No");
			}
		}
		public string Serial_No
		{
			get { return _Serial_No; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Serial_No, val, false) == 0 ) return;
		
				if( val != null && val.Length > Serial_NoMax )
					_Serial_No = val.Substring(0, (int)Serial_NoMax);
				else
					_Serial_No = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Serial_No");
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
		public string Parameters
		{
			get { return _Parameters; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Parameters, val, false) == 0 ) return;
		
				if( val != null && val.Length > ParametersMax )
					_Parameters = val.Substring(0, (int)ParametersMax);
				else
					_Parameters = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Parameters");
			}
		}
		public string Caller_ID
		{
			get { return _Caller_ID; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Caller_ID, val, false) == 0 ) return;
		
				if( val != null && val.Length > Caller_IDMax )
					_Caller_ID = val.Substring(0, (int)Caller_IDMax);
				else
					_Caller_ID = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Caller_ID");
			}
		}

		#endregion	// #region Column Properties

		#region Foreign Key Fields



		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties



		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsApiLog() : base() {}
		public ClsApiLog(DataRow dr) : base(dr) {}
		public ClsApiLog(ClsApiLog src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Api_Log_ID = null;
			Create_Dt = null;
			Create_User = null;
			Modify_Dt = null;
			Modify_User = null;
			Batch_No = null;
			Trading_Partner_Cd = null;
			Api_Nm = null;
			Success_Cd = null;
			Api_Msg = null;
			Json_Sent = null;
			Message_Cd = null;
			Document_No = null;
			Serial_No = null;
			Action_Cd = null;
			Parameters = null;
			Caller_ID = null;
		}

		public void CopyFrom(ClsApiLog src)
		{
			Api_Log_ID = src._Api_Log_ID;
			Create_Dt = src._Create_Dt;
			Create_User = src._Create_User;
			Modify_Dt = src._Modify_Dt;
			Modify_User = src._Modify_User;
			Batch_No = src._Batch_No;
			Trading_Partner_Cd = src._Trading_Partner_Cd;
			Api_Nm = src._Api_Nm;
			Success_Cd = src._Success_Cd;
			Api_Msg = src._Api_Msg;
			Json_Sent = src._Json_Sent;
			Message_Cd = src._Message_Cd;
			Document_No = src._Document_No;
			Serial_No = src._Serial_No;
			Action_Cd = src._Action_Cd;
			Parameters = src._Parameters;
			Caller_ID = src._Caller_ID;
		}

		public override bool ReloadFromDB()
		{
			ClsApiLog tmp = ClsApiLog.GetUsingKey(Api_Log_ID.Value);
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

			DbParameter[] p = new DbParameter[17];

			p[0] = Connection.GetParameter
				("@BATCH_NO", Batch_No);
			p[1] = Connection.GetParameter
				("@TRADING_PARTNER_CD", Trading_Partner_Cd);
			p[2] = Connection.GetParameter
				("@API_NM", Api_Nm);
			p[3] = Connection.GetParameter
				("@SUCCESS_CD", Success_Cd);
			p[4] = Connection.GetParameter
				("@API_MSG", Api_Msg);
			p[5] = Connection.GetParameter
				("@JSON_SENT", Json_Sent);
			p[6] = Connection.GetParameter
				("@MESSAGE_CD", Message_Cd);
			p[7] = Connection.GetParameter
				("@DOCUMENT_NO", Document_No);
			p[8] = Connection.GetParameter
				("@SERIAL_NO", Serial_No);
			p[9] = Connection.GetParameter
				("@ACTION_CD", Action_Cd);
			p[10] = Connection.GetParameter
				("@PARAMETERS", Parameters);
			p[11] = Connection.GetParameter
				("@CALLER_ID", Caller_ID);
			p[12] = Connection.GetParameter
				("@API_LOG_ID", Api_Log_ID, ParameterDirection.Output, DbType.Int64, 0);
			p[13] = Connection.GetParameter
				("@CREATE_DT", Create_Dt, ParameterDirection.Output, DbType.DateTime, 0);
			p[14] = Connection.GetParameter
				("@CREATE_USER", Create_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Create_UserMax);
			p[15] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.Output, DbType.DateTime, 0);
			p[16] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);

			const string sql = @"
				INSERT INTO T_API_LOG
					(API_LOG_ID, BATCH_NO, TRADING_PARTNER_CD,
					API_NM, SUCCESS_CD, API_MSG,
					JSON_SENT, MESSAGE_CD, DOCUMENT_NO,
					SERIAL_NO, ACTION_CD, PARAMETERS,
					CALLER_ID)
				VALUES
					(API_LOG_ID_SEQ.NEXTVAL, @BATCH_NO, @TRADING_PARTNER_CD,
					@API_NM, @SUCCESS_CD, @API_MSG,
					@JSON_SENT, @MESSAGE_CD, @DOCUMENT_NO,
					@SERIAL_NO, @ACTION_CD, @PARAMETERS,
					@CALLER_ID)
				RETURNING
					API_LOG_ID, CREATE_DT, CREATE_USER,
					MODIFY_DT, MODIFY_USER
				INTO
					@API_LOG_ID, @CREATE_DT, @CREATE_USER,
					@MODIFY_DT, @MODIFY_USER";
			int ret = Connection.RunSQL(sql, p);

			Api_Log_ID = ClsConvert.ToInt64Nullable(p[12].Value);
			Create_Dt = ClsConvert.ToDateTimeNullable(p[13].Value);
			Create_User = ClsConvert.ToString(p[14].Value);
			Modify_Dt = ClsConvert.ToDateTimeNullable(p[15].Value);
			Modify_User = ClsConvert.ToString(p[16].Value);
			return ret;
		}
		public override int Update()
		{
			DbParameter[] p = new DbParameter[15];

			p[0] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.InputOutput, DbType.DateTime, 0);
			p[1] = Connection.GetParameter
				("@BATCH_NO", Batch_No);
			p[2] = Connection.GetParameter
				("@TRADING_PARTNER_CD", Trading_Partner_Cd);
			p[3] = Connection.GetParameter
				("@API_NM", Api_Nm);
			p[4] = Connection.GetParameter
				("@SUCCESS_CD", Success_Cd);
			p[5] = Connection.GetParameter
				("@API_MSG", Api_Msg);
			p[6] = Connection.GetParameter
				("@JSON_SENT", Json_Sent);
			p[7] = Connection.GetParameter
				("@MESSAGE_CD", Message_Cd);
			p[8] = Connection.GetParameter
				("@DOCUMENT_NO", Document_No);
			p[9] = Connection.GetParameter
				("@SERIAL_NO", Serial_No);
			p[10] = Connection.GetParameter
				("@ACTION_CD", Action_Cd);
			p[11] = Connection.GetParameter
				("@PARAMETERS", Parameters);
			p[12] = Connection.GetParameter
				("@CALLER_ID", Caller_ID);
			p[13] = Connection.GetParameter
				("@API_LOG_ID", Api_Log_ID);
			p[14] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);

			const string sql = @"
				UPDATE T_API_LOG SET
					MODIFY_DT = @MODIFY_DT,
					BATCH_NO = @BATCH_NO,
					TRADING_PARTNER_CD = @TRADING_PARTNER_CD,
					API_NM = @API_NM,
					SUCCESS_CD = @SUCCESS_CD,
					API_MSG = @API_MSG,
					JSON_SENT = @JSON_SENT,
					MESSAGE_CD = @MESSAGE_CD,
					DOCUMENT_NO = @DOCUMENT_NO,
					SERIAL_NO = @SERIAL_NO,
					ACTION_CD = @ACTION_CD,
					PARAMETERS = @PARAMETERS,
					CALLER_ID = @CALLER_ID
				WHERE
					API_LOG_ID = @API_LOG_ID
				RETURNING
					MODIFY_DT, MODIFY_USER
				INTO
					@MODIFY_DT, @MODIFY_USER";
			int ret = Connection.RunSQL(sql, p);

			Modify_Dt = ClsConvert.ToDateTimeNullable(p[0].Value);
			Modify_User = ClsConvert.ToString(p[14].Value);
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

			Api_Log_ID = ClsConvert.ToInt64Nullable(dr["API_LOG_ID"]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT"]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER"]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT"]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER"]);
			Batch_No = ClsConvert.ToInt64Nullable(dr["BATCH_NO"]);
			Trading_Partner_Cd = ClsConvert.ToString(dr["TRADING_PARTNER_CD"]);
			Api_Nm = ClsConvert.ToString(dr["API_NM"]);
			Success_Cd = ClsConvert.ToString(dr["SUCCESS_CD"]);
			Api_Msg = ClsConvert.ToString(dr["API_MSG"]);
			Json_Sent = ClsConvert.ToString(dr["JSON_SENT"]);
			Message_Cd = ClsConvert.ToString(dr["MESSAGE_CD"]);
			Document_No = ClsConvert.ToString(dr["DOCUMENT_NO"]);
			Serial_No = ClsConvert.ToString(dr["SERIAL_NO"]);
			Action_Cd = ClsConvert.ToString(dr["ACTION_CD"]);
			Parameters = ClsConvert.ToString(dr["PARAMETERS"]);
			Caller_ID = ClsConvert.ToString(dr["CALLER_ID"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Api_Log_ID = ClsConvert.ToInt64Nullable(dr["API_LOG_ID", v]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT", v]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER", v]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT", v]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER", v]);
			Batch_No = ClsConvert.ToInt64Nullable(dr["BATCH_NO", v]);
			Trading_Partner_Cd = ClsConvert.ToString(dr["TRADING_PARTNER_CD", v]);
			Api_Nm = ClsConvert.ToString(dr["API_NM", v]);
			Success_Cd = ClsConvert.ToString(dr["SUCCESS_CD", v]);
			Api_Msg = ClsConvert.ToString(dr["API_MSG", v]);
			Json_Sent = ClsConvert.ToString(dr["JSON_SENT", v]);
			Message_Cd = ClsConvert.ToString(dr["MESSAGE_CD", v]);
			Document_No = ClsConvert.ToString(dr["DOCUMENT_NO", v]);
			Serial_No = ClsConvert.ToString(dr["SERIAL_NO", v]);
			Action_Cd = ClsConvert.ToString(dr["ACTION_CD", v]);
			Parameters = ClsConvert.ToString(dr["PARAMETERS", v]);
			Caller_ID = ClsConvert.ToString(dr["CALLER_ID", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["API_LOG_ID"] = ClsConvert.ToDbObject(Api_Log_ID);
			dr["CREATE_DT"] = ClsConvert.ToDbObject(Create_Dt);
			dr["CREATE_USER"] = ClsConvert.ToDbObject(Create_User);
			dr["MODIFY_DT"] = ClsConvert.ToDbObject(Modify_Dt);
			dr["MODIFY_USER"] = ClsConvert.ToDbObject(Modify_User);
			dr["BATCH_NO"] = ClsConvert.ToDbObject(Batch_No);
			dr["TRADING_PARTNER_CD"] = ClsConvert.ToDbObject(Trading_Partner_Cd);
			dr["API_NM"] = ClsConvert.ToDbObject(Api_Nm);
			dr["SUCCESS_CD"] = ClsConvert.ToDbObject(Success_Cd);
			dr["API_MSG"] = ClsConvert.ToDbObject(Api_Msg);
			dr["JSON_SENT"] = ClsConvert.ToDbObject(Json_Sent);
			dr["MESSAGE_CD"] = ClsConvert.ToDbObject(Message_Cd);
			dr["DOCUMENT_NO"] = ClsConvert.ToDbObject(Document_No);
			dr["SERIAL_NO"] = ClsConvert.ToDbObject(Serial_No);
			dr["ACTION_CD"] = ClsConvert.ToDbObject(Action_Cd);
			dr["PARAMETERS"] = ClsConvert.ToDbObject(Parameters);
			dr["CALLER_ID"] = ClsConvert.ToDbObject(Caller_ID);
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

		public static ClsApiLog GetUsingKey(Int64 Api_Log_ID)
		{
			object[] vals = new object[] {Api_Log_ID};
			DataRow dr = Connection.GetDataRowUsingKey
				(TableName, GetPrimaryKeys(), vals);
			return ( dr == null ) ? null : new ClsApiLog(dr);
		}

		#endregion		// #region Static Methods
	}
}