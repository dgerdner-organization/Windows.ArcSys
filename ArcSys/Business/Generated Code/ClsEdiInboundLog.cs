using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsEdiInboundLog : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ArcSys"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "T_EDI_INBOUND_LOG";
		public const int PrimaryKeyCount = 1;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] { "EDI_INBOUND_LOG_ID" };
		}

		public const string SelectSQL = "SELECT * FROM T_EDI_INBOUND_LOG";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Trading_Partner_CdMax = 10;
		public const int Create_UserMax = 30;
		public const int Modify_UserMax = 30;
		public const int File_NmMax = 250;
		public const int Edi_Message_NoMax = 20;
		public const int Map_NmMax = 20;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected Int64? _Edi_Inbound_Log_ID;
		protected string _Trading_Partner_Cd;
		protected Int64? _Isa_Nbr;
		protected string _Create_User;
		protected DateTime? _Create_Dt;
		protected string _Modify_User;
		protected DateTime? _Modify_Dt;
		protected string _File_Nm;
		protected string _Edi_Message_No;
		protected DateTime? _Log_Dt;
		protected string _Map_Nm;

		#endregion	// #region Column Fields

		#region Column Properties

		public Int64? Edi_Inbound_Log_ID
		{
			get { return _Edi_Inbound_Log_ID; }
			set
			{
				if( _Edi_Inbound_Log_ID == value ) return;
		
				_Edi_Inbound_Log_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Edi_Inbound_Log_ID");
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
		public Int64? Isa_Nbr
		{
			get { return _Isa_Nbr; }
			set
			{
				if( _Isa_Nbr == value ) return;
		
				_Isa_Nbr = value;
				_IsDirty = true;
				NotifyPropertyChanged("Isa_Nbr");
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
		public string Edi_Message_No
		{
			get { return _Edi_Message_No; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Edi_Message_No, val, false) == 0 ) return;
		
				if( val != null && val.Length > Edi_Message_NoMax )
					_Edi_Message_No = val.Substring(0, (int)Edi_Message_NoMax);
				else
					_Edi_Message_No = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Edi_Message_No");
			}
		}
		public DateTime? Log_Dt
		{
			get { return _Log_Dt; }
			set
			{
				DateTime? val = ( value != null )
					? (DateTime?)value.Value.Date : null;
		
				if( _Log_Dt == val ) return;
		
				_Log_Dt = val;
				_IsDirty = true;
				NotifyPropertyChanged("Log_Dt");
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

		#endregion	// #region Column Properties

		#region Foreign Key Fields



		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties



		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsEdiInboundLog() : base() {}
		public ClsEdiInboundLog(DataRow dr) : base(dr) {}
		public ClsEdiInboundLog(ClsEdiInboundLog src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Edi_Inbound_Log_ID = null;
			Trading_Partner_Cd = null;
			Isa_Nbr = null;
			Create_User = null;
			Create_Dt = null;
			Modify_User = null;
			Modify_Dt = null;
			File_Nm = null;
			Edi_Message_No = null;
			Log_Dt = null;
			Map_Nm = null;
		}

		public void CopyFrom(ClsEdiInboundLog src)
		{
			Edi_Inbound_Log_ID = src._Edi_Inbound_Log_ID;
			Trading_Partner_Cd = src._Trading_Partner_Cd;
			Isa_Nbr = src._Isa_Nbr;
			Create_User = src._Create_User;
			Create_Dt = src._Create_Dt;
			Modify_User = src._Modify_User;
			Modify_Dt = src._Modify_Dt;
			File_Nm = src._File_Nm;
			Edi_Message_No = src._Edi_Message_No;
			Log_Dt = src._Log_Dt;
			Map_Nm = src._Map_Nm;
		}

		public override bool ReloadFromDB()
		{
			ClsEdiInboundLog tmp = ClsEdiInboundLog.GetUsingKey(Edi_Inbound_Log_ID.Value);
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

			DbParameter[] p = new DbParameter[11];

			p[0] = Connection.GetParameter
				("@TRADING_PARTNER_CD", Trading_Partner_Cd);
			p[1] = Connection.GetParameter
				("@ISA_NBR", Isa_Nbr);
			p[2] = Connection.GetParameter
				("@FILE_NM", File_Nm);
			p[3] = Connection.GetParameter
				("@EDI_MESSAGE_NO", Edi_Message_No);
			p[4] = Connection.GetParameter
				("@LOG_DT", Log_Dt);
			p[5] = Connection.GetParameter
				("@MAP_NM", Map_Nm);
			p[6] = Connection.GetParameter
				("@EDI_INBOUND_LOG_ID", Edi_Inbound_Log_ID, ParameterDirection.Output, DbType.Decimal, 0);
			p[7] = Connection.GetParameter
				("@CREATE_USER", Create_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Create_UserMax);
			p[8] = Connection.GetParameter
				("@CREATE_DT", Create_Dt, ParameterDirection.Output, DbType.DateTime, 0);
			p[9] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);
			p[10] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.Output, DbType.DateTime, 0);

			const string sql = @"
				INSERT INTO T_EDI_INBOUND_LOG
					(EDI_INBOUND_LOG_ID, TRADING_PARTNER_CD, ISA_NBR,
					FILE_NM, EDI_MESSAGE_NO, LOG_DT,
					MAP_NM)
				VALUES
					(EDI_INBOUND_LOG_ID_SEQ.NEXTVAL, @TRADING_PARTNER_CD, @ISA_NBR,
					@FILE_NM, @EDI_MESSAGE_NO, @LOG_DT,
					@MAP_NM)
				RETURNING
					EDI_INBOUND_LOG_ID, CREATE_USER, CREATE_DT,
					MODIFY_USER, MODIFY_DT
				INTO
					@EDI_INBOUND_LOG_ID, @CREATE_USER, @CREATE_DT,
					@MODIFY_USER, @MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Edi_Inbound_Log_ID = ClsConvert.ToInt64Nullable(p[6].Value);
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
				("@TRADING_PARTNER_CD", Trading_Partner_Cd);
			p[1] = Connection.GetParameter
				("@ISA_NBR", Isa_Nbr);
			p[2] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.InputOutput, DbType.DateTime, 0);
			p[3] = Connection.GetParameter
				("@FILE_NM", File_Nm);
			p[4] = Connection.GetParameter
				("@EDI_MESSAGE_NO", Edi_Message_No);
			p[5] = Connection.GetParameter
				("@LOG_DT", Log_Dt);
			p[6] = Connection.GetParameter
				("@MAP_NM", Map_Nm);
			p[7] = Connection.GetParameter
				("@EDI_INBOUND_LOG_ID", Edi_Inbound_Log_ID);
			p[8] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);

			const string sql = @"
				UPDATE T_EDI_INBOUND_LOG SET
					TRADING_PARTNER_CD = @TRADING_PARTNER_CD,
					ISA_NBR = @ISA_NBR,
					MODIFY_DT = @MODIFY_DT,
					FILE_NM = @FILE_NM,
					EDI_MESSAGE_NO = @EDI_MESSAGE_NO,
					LOG_DT = @LOG_DT,
					MAP_NM = @MAP_NM
				WHERE
					EDI_INBOUND_LOG_ID = @EDI_INBOUND_LOG_ID
				RETURNING
					MODIFY_USER, MODIFY_DT
				INTO
					@MODIFY_USER, @MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Modify_Dt = ClsConvert.ToDateTimeNullable(p[2].Value);
			Modify_User = ClsConvert.ToString(p[8].Value);
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

			Edi_Inbound_Log_ID = ClsConvert.ToInt64Nullable(dr["EDI_INBOUND_LOG_ID"]);
			Trading_Partner_Cd = ClsConvert.ToString(dr["TRADING_PARTNER_CD"]);
			Isa_Nbr = ClsConvert.ToInt64Nullable( dr["ISA_NBR"]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER"]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT"]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER"]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT"]);
			File_Nm = ClsConvert.ToString(dr["FILE_NM"]);
			Edi_Message_No = ClsConvert.ToString(dr["EDI_MESSAGE_NO"]);
			Log_Dt = ClsConvert.ToDateTimeNullable(dr["LOG_DT"]);
			Map_Nm = ClsConvert.ToString(dr["MAP_NM"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Edi_Inbound_Log_ID = ClsConvert.ToInt64Nullable(dr["EDI_INBOUND_LOG_ID", v]);
			Trading_Partner_Cd = ClsConvert.ToString(dr["TRADING_PARTNER_CD", v]);
			Isa_Nbr = ClsConvert.ToInt64Nullable(dr["ISA_NBR", v]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER", v]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT", v]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER", v]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT", v]);
			File_Nm = ClsConvert.ToString(dr["FILE_NM", v]);
			Edi_Message_No = ClsConvert.ToString(dr["EDI_MESSAGE_NO", v]);
			Log_Dt = ClsConvert.ToDateTimeNullable(dr["LOG_DT", v]);
			Map_Nm = ClsConvert.ToString(dr["MAP_NM", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["EDI_INBOUND_LOG_ID"] = ClsConvert.ToDbObject(Edi_Inbound_Log_ID);
			dr["TRADING_PARTNER_CD"] = ClsConvert.ToDbObject(Trading_Partner_Cd);
			dr["ISA_NBR"] = ClsConvert.ToDbObject(Isa_Nbr);
			dr["CREATE_USER"] = ClsConvert.ToDbObject(Create_User);
			dr["CREATE_DT"] = ClsConvert.ToDbObject(Create_Dt);
			dr["MODIFY_USER"] = ClsConvert.ToDbObject(Modify_User);
			dr["MODIFY_DT"] = ClsConvert.ToDbObject(Modify_Dt);
			dr["FILE_NM"] = ClsConvert.ToDbObject(File_Nm);
			dr["EDI_MESSAGE_NO"] = ClsConvert.ToDbObject(Edi_Message_No);
			dr["LOG_DT"] = ClsConvert.ToDbObject(Log_Dt);
			dr["MAP_NM"] = ClsConvert.ToDbObject(Map_Nm);
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

		public static ClsEdiInboundLog GetUsingKey(decimal Edi_Inbound_Log_ID)
		{
			object[] vals = new object[] {Edi_Inbound_Log_ID};
			DataRow dr = Connection.GetDataRowUsingKey
				(TableName, GetPrimaryKeys(), vals);
			return ( dr == null ) ? null : new ClsEdiInboundLog(dr);
		}

		#endregion		// #region Static Methods
	}
}