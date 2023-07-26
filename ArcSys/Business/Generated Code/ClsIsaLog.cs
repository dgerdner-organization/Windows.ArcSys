using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsIsaLog : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ArcSys"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "T_ISA_LOG";
		public const int PrimaryKeyCount = 1;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] { "ISA_LOG_ID" };
		}

		public const string SelectSQL = @"SELECT * FROM T_ISA_LOG 
				LEFT OUTER JOIN R_TRADING_PARTNER_EDI
				ON T_ISA_LOG.TRADING_PARTNER_EDI_ID=R_TRADING_PARTNER_EDI.TRADING_PARTNER_EDI_ID ";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Create_UserMax = 30;
		public const int Modify_UserMax = 30;
		public const int Log_MessageMax = 500;
		public const int Data_KeyMax = 50;
		public const int Data_Key_DscMax = 50;
		public const int Log_Message_DtlMax = 500;
		public const int Data_KeybMax = 50;
		public const int Data_Keyb_DscMax = 50;
		public const int File_NmMax = 500;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected Int64? _Isa_Log_ID;
		protected Int64? _Isa_ID;
		protected DateTime? _Create_Dt;
		protected string _Create_User;
		protected DateTime? _Modify_Dt;
		protected string _Modify_User;
		protected string _Log_Message;
		protected string _Data_Key;
		protected string _Data_Key_Dsc;
		protected string _Log_Message_Dtl;
		protected string _Data_Keyb;
		protected string _Data_Keyb_Dsc;
		protected string _File_Nm;
		protected decimal? _Trading_Partner_Edi_ID;

		#endregion	// #region Column Fields

		#region Column Properties

		public Int64? Isa_Log_ID
		{
			get { return _Isa_Log_ID; }
			set
			{
				if( _Isa_Log_ID == value ) return;
		
				_Isa_Log_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Isa_Log_ID");
			}
		}
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
		public string Log_Message
		{
			get { return _Log_Message; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Log_Message, val, false) == 0 ) return;
		
				if( val != null && val.Length > Log_MessageMax )
					_Log_Message = val.Substring(0, (int)Log_MessageMax);
				else
					_Log_Message = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Log_Message");
			}
		}
		public string Data_Key
		{
			get { return _Data_Key; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Data_Key, val, false) == 0 ) return;
		
				if( val != null && val.Length > Data_KeyMax )
					_Data_Key = val.Substring(0, (int)Data_KeyMax);
				else
					_Data_Key = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Data_Key");
			}
		}
		public string Data_Key_Dsc
		{
			get { return _Data_Key_Dsc; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Data_Key_Dsc, val, false) == 0 ) return;
		
				if( val != null && val.Length > Data_Key_DscMax )
					_Data_Key_Dsc = val.Substring(0, (int)Data_Key_DscMax);
				else
					_Data_Key_Dsc = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Data_Key_Dsc");
			}
		}
		public string Log_Message_Dtl
		{
			get { return _Log_Message_Dtl; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Log_Message_Dtl, val, false) == 0 ) return;
		
				if( val != null && val.Length > Log_Message_DtlMax )
					_Log_Message_Dtl = val.Substring(0, (int)Log_Message_DtlMax);
				else
					_Log_Message_Dtl = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Log_Message_Dtl");
			}
		}
		public string Data_Keyb
		{
			get { return _Data_Keyb; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Data_Keyb, val, false) == 0 ) return;
		
				if( val != null && val.Length > Data_KeybMax )
					_Data_Keyb = val.Substring(0, (int)Data_KeybMax);
				else
					_Data_Keyb = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Data_Keyb");
			}
		}
		public string Data_Keyb_Dsc
		{
			get { return _Data_Keyb_Dsc; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Data_Keyb_Dsc, val, false) == 0 ) return;
		
				if( val != null && val.Length > Data_Keyb_DscMax )
					_Data_Keyb_Dsc = val.Substring(0, (int)Data_Keyb_DscMax);
				else
					_Data_Keyb_Dsc = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Data_Keyb_Dsc");
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
		public decimal? Trading_Partner_Edi_ID
		{
			get { return _Trading_Partner_Edi_ID; }
			set
			{
				if( _Trading_Partner_Edi_ID == value ) return;
		
				_Trading_Partner_Edi_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Trading_Partner_Edi_ID");
			}
		}

		#endregion	// #region Column Properties

		#region Foreign Key Fields

		protected ClsTradingPartnerEdi _Trading_Partner_Edi;

		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties

		public ClsTradingPartnerEdi Trading_Partner_Edi
		{
			get
			{
				if( Trading_Partner_Edi_ID == null )
					_Trading_Partner_Edi = null;
				else if( _Trading_Partner_Edi == null ||
					_Trading_Partner_Edi.Trading_Partner_Edi_ID != Trading_Partner_Edi_ID )
					_Trading_Partner_Edi = ClsTradingPartnerEdi.GetUsingKey(Trading_Partner_Edi_ID.Value);
				return _Trading_Partner_Edi;
			}
			set
			{
				if( _Trading_Partner_Edi == value ) return;
		
				_Trading_Partner_Edi = value;
			}
		}

		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsIsaLog() : base() {}
		public ClsIsaLog(DataRow dr) : base(dr) {}
		public ClsIsaLog(ClsIsaLog src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Isa_Log_ID = null;
			Isa_ID = null;
			Create_Dt = null;
			Create_User = null;
			Modify_Dt = null;
			Modify_User = null;
			Log_Message = null;
			Data_Key = null;
			Data_Key_Dsc = null;
			Log_Message_Dtl = null;
			Data_Keyb = null;
			Data_Keyb_Dsc = null;
			File_Nm = null;
			Trading_Partner_Edi_ID = null;
		}

		public void CopyFrom(ClsIsaLog src)
		{
			Isa_Log_ID = src._Isa_Log_ID;
			Isa_ID = src._Isa_ID;
			Create_Dt = src._Create_Dt;
			Create_User = src._Create_User;
			Modify_Dt = src._Modify_Dt;
			Modify_User = src._Modify_User;
			Log_Message = src._Log_Message;
			Data_Key = src._Data_Key;
			Data_Key_Dsc = src._Data_Key_Dsc;
			Log_Message_Dtl = src._Log_Message_Dtl;
			Data_Keyb = src._Data_Keyb;
			Data_Keyb_Dsc = src._Data_Keyb_Dsc;
			File_Nm = src._File_Nm;
			Trading_Partner_Edi_ID = src._Trading_Partner_Edi_ID;
		}

		public override bool ReloadFromDB()
		{
			ClsIsaLog tmp = ClsIsaLog.GetUsingKey(Isa_Log_ID.Value);
			if( tmp != null ) CopyFrom(tmp);

			ResetFKs();
			OnReload();

			return ( tmp != null );
		}

		public override void ResetFKs()
		{
			_Trading_Partner_Edi = null;
		}
		#endregion		// #region Init methods

		#region Insert, Update, Delete

		public override int Insert()
		{

			DbParameter[] p = new DbParameter[14];

			p[0] = Connection.GetParameter
				("@ISA_ID", Isa_ID);
			p[1] = Connection.GetParameter
				("@LOG_MESSAGE", Log_Message);
			p[2] = Connection.GetParameter
				("@DATA_KEY", Data_Key);
			p[3] = Connection.GetParameter
				("@DATA_KEY_DSC", Data_Key_Dsc);
			p[4] = Connection.GetParameter
				("@LOG_MESSAGE_DTL", Log_Message_Dtl);
			p[5] = Connection.GetParameter
				("@DATA_KEYB", Data_Keyb);
			p[6] = Connection.GetParameter
				("@DATA_KEYB_DSC", Data_Keyb_Dsc);
			p[7] = Connection.GetParameter
				("@FILE_NM", File_Nm);
			p[8] = Connection.GetParameter
				("@TRADING_PARTNER_EDI_ID", Trading_Partner_Edi_ID);
			p[9] = Connection.GetParameter
				("@ISA_LOG_ID", Isa_Log_ID, ParameterDirection.Output, DbType.Int64, 0);
			p[10] = Connection.GetParameter
				("@CREATE_DT", Create_Dt, ParameterDirection.Output, DbType.DateTime, 0);
			p[11] = Connection.GetParameter
				("@CREATE_USER", Create_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Create_UserMax);
			p[12] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.Output, DbType.DateTime, 0);
			p[13] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);

			const string sql = @"
				INSERT INTO T_ISA_LOG
					(ISA_LOG_ID, ISA_ID, LOG_MESSAGE,
					DATA_KEY, DATA_KEY_DSC, LOG_MESSAGE_DTL,
					DATA_KEYB, DATA_KEYB_DSC, FILE_NM,
					TRADING_PARTNER_EDI_ID)
				VALUES
					(ISA_LOG_ID_SEQ.NEXTVAL, @ISA_ID, @LOG_MESSAGE,
					@DATA_KEY, @DATA_KEY_DSC, @LOG_MESSAGE_DTL,
					@DATA_KEYB, @DATA_KEYB_DSC, @FILE_NM,
					@TRADING_PARTNER_EDI_ID)
				RETURNING
					ISA_LOG_ID, CREATE_DT, CREATE_USER,
					MODIFY_DT, MODIFY_USER
				INTO
					@ISA_LOG_ID, @CREATE_DT, @CREATE_USER,
					@MODIFY_DT, @MODIFY_USER";
			int ret = Connection.RunSQL(sql, p);

			Isa_Log_ID = ClsConvert.ToInt64Nullable(p[9].Value);
			Create_Dt = ClsConvert.ToDateTimeNullable(p[10].Value);
			Create_User = ClsConvert.ToString(p[11].Value);
			Modify_Dt = ClsConvert.ToDateTimeNullable(p[12].Value);
			Modify_User = ClsConvert.ToString(p[13].Value);
			return ret;
		}
		public override int Update()
		{
			DbParameter[] p = new DbParameter[12];

			p[0] = Connection.GetParameter
				("@ISA_ID", Isa_ID);
			p[1] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.InputOutput, DbType.DateTime, 0);
			p[2] = Connection.GetParameter
				("@LOG_MESSAGE", Log_Message);
			p[3] = Connection.GetParameter
				("@DATA_KEY", Data_Key);
			p[4] = Connection.GetParameter
				("@DATA_KEY_DSC", Data_Key_Dsc);
			p[5] = Connection.GetParameter
				("@LOG_MESSAGE_DTL", Log_Message_Dtl);
			p[6] = Connection.GetParameter
				("@DATA_KEYB", Data_Keyb);
			p[7] = Connection.GetParameter
				("@DATA_KEYB_DSC", Data_Keyb_Dsc);
			p[8] = Connection.GetParameter
				("@FILE_NM", File_Nm);
			p[9] = Connection.GetParameter
				("@TRADING_PARTNER_EDI_ID", Trading_Partner_Edi_ID);
			p[10] = Connection.GetParameter
				("@ISA_LOG_ID", Isa_Log_ID);
			p[11] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);

			const string sql = @"
				UPDATE T_ISA_LOG SET
					ISA_ID = @ISA_ID,
					MODIFY_DT = @MODIFY_DT,
					LOG_MESSAGE = @LOG_MESSAGE,
					DATA_KEY = @DATA_KEY,
					DATA_KEY_DSC = @DATA_KEY_DSC,
					LOG_MESSAGE_DTL = @LOG_MESSAGE_DTL,
					DATA_KEYB = @DATA_KEYB,
					DATA_KEYB_DSC = @DATA_KEYB_DSC,
					FILE_NM = @FILE_NM,
					TRADING_PARTNER_EDI_ID = @TRADING_PARTNER_EDI_ID
				WHERE
					ISA_LOG_ID = @ISA_LOG_ID
				RETURNING
					MODIFY_DT, MODIFY_USER
				INTO
					@MODIFY_DT, @MODIFY_USER";
			int ret = Connection.RunSQL(sql, p);

			Modify_Dt = ClsConvert.ToDateTimeNullable(p[1].Value);
			Modify_User = ClsConvert.ToString(p[11].Value);
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

			Isa_Log_ID = ClsConvert.ToInt64Nullable(dr["ISA_LOG_ID"]);
			Isa_ID = ClsConvert.ToInt64Nullable(dr["ISA_ID"]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT"]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER"]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT"]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER"]);
			Log_Message = ClsConvert.ToString(dr["LOG_MESSAGE"]);
			Data_Key = ClsConvert.ToString(dr["DATA_KEY"]);
			Data_Key_Dsc = ClsConvert.ToString(dr["DATA_KEY_DSC"]);
			Log_Message_Dtl = ClsConvert.ToString(dr["LOG_MESSAGE_DTL"]);
			Data_Keyb = ClsConvert.ToString(dr["DATA_KEYB"]);
			Data_Keyb_Dsc = ClsConvert.ToString(dr["DATA_KEYB_DSC"]);
			File_Nm = ClsConvert.ToString(dr["FILE_NM"]);
			Trading_Partner_Edi_ID = ClsConvert.ToDecimalNullable(dr["TRADING_PARTNER_EDI_ID"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Isa_Log_ID = ClsConvert.ToInt64Nullable(dr["ISA_LOG_ID", v]);
			Isa_ID = ClsConvert.ToInt64Nullable(dr["ISA_ID", v]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT", v]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER", v]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT", v]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER", v]);
			Log_Message = ClsConvert.ToString(dr["LOG_MESSAGE", v]);
			Data_Key = ClsConvert.ToString(dr["DATA_KEY", v]);
			Data_Key_Dsc = ClsConvert.ToString(dr["DATA_KEY_DSC", v]);
			Log_Message_Dtl = ClsConvert.ToString(dr["LOG_MESSAGE_DTL", v]);
			Data_Keyb = ClsConvert.ToString(dr["DATA_KEYB", v]);
			Data_Keyb_Dsc = ClsConvert.ToString(dr["DATA_KEYB_DSC", v]);
			File_Nm = ClsConvert.ToString(dr["FILE_NM", v]);
			Trading_Partner_Edi_ID = ClsConvert.ToDecimalNullable(dr["TRADING_PARTNER_EDI_ID", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["ISA_LOG_ID"] = ClsConvert.ToDbObject(Isa_Log_ID);
			dr["ISA_ID"] = ClsConvert.ToDbObject(Isa_ID);
			dr["CREATE_DT"] = ClsConvert.ToDbObject(Create_Dt);
			dr["CREATE_USER"] = ClsConvert.ToDbObject(Create_User);
			dr["MODIFY_DT"] = ClsConvert.ToDbObject(Modify_Dt);
			dr["MODIFY_USER"] = ClsConvert.ToDbObject(Modify_User);
			dr["LOG_MESSAGE"] = ClsConvert.ToDbObject(Log_Message);
			dr["DATA_KEY"] = ClsConvert.ToDbObject(Data_Key);
			dr["DATA_KEY_DSC"] = ClsConvert.ToDbObject(Data_Key_Dsc);
			dr["LOG_MESSAGE_DTL"] = ClsConvert.ToDbObject(Log_Message_Dtl);
			dr["DATA_KEYB"] = ClsConvert.ToDbObject(Data_Keyb);
			dr["DATA_KEYB_DSC"] = ClsConvert.ToDbObject(Data_Keyb_Dsc);
			dr["FILE_NM"] = ClsConvert.ToDbObject(File_Nm);
			dr["TRADING_PARTNER_EDI_ID"] = ClsConvert.ToDbObject(Trading_Partner_Edi_ID);
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

		public static ClsIsaLog GetUsingKey(Int64 Isa_Log_ID)
		{
			object[] vals = new object[] {Isa_Log_ID};
			DataRow dr = Connection.GetDataRowUsingKey
				(TableName, GetPrimaryKeys(), vals);
			return ( dr == null ) ? null : new ClsIsaLog(dr);
		}
		public static DataTable GetAll(decimal? Trading_Partner_Edi_ID)
		{
			List<DbParameter> lst = new List<DbParameter>();	
			StringBuilder sb = new StringBuilder();
		
			if( Trading_Partner_Edi_ID != null && Trading_Partner_Edi_ID > 0 )
			{
				lst.Add(Connection.GetParameter("@TRADING_PARTNER_EDI_ID", Trading_Partner_Edi_ID));
				sb.Append(" WHERE T_ISA_LOG.TRADING_PARTNER_EDI_ID=@TRADING_PARTNER_EDI_ID");
			}
			sb.Insert(0, SelectSQL);
			return Connection.GetDataTable(sb.ToString(), lst.ToArray());
		}
		#endregion		// #region Static Methods
	}
}