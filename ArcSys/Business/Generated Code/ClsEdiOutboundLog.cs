using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsEdiOutboundLog : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ArcSys"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "T_EDI_OUTBOUND_LOG";
		public const int PrimaryKeyCount = 4;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] { "TRADING_PARTNER_CD", "ISA_NBR", "EDI_MESSAGE_NO", "MAP_NM" };
		}

		public const string SelectSQL = "SELECT * FROM T_EDI_OUTBOUND_LOG";

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

		protected string _Trading_Partner_Cd;
		protected decimal? _Isa_Nbr;
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
		public decimal? Isa_Nbr
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

		public ClsEdiOutboundLog() : base() {}
		public ClsEdiOutboundLog(DataRow dr) : base(dr) {}
		public ClsEdiOutboundLog(ClsEdiOutboundLog src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
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

		public void CopyFrom(ClsEdiOutboundLog src)
		{
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
			ClsEdiOutboundLog tmp = ClsEdiOutboundLog.GetUsingKey(Trading_Partner_Cd, Isa_Nbr.Value, Edi_Message_No, Map_Nm);
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
				("@CREATE_USER", Create_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Create_UserMax);
			p[7] = Connection.GetParameter
				("@CREATE_DT", Create_Dt, ParameterDirection.Output, DbType.DateTime, 0);
			p[8] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);
			p[9] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.Output, DbType.DateTime, 0);

			const string sql = @"
				INSERT INTO T_EDI_OUTBOUND_LOG
					(TRADING_PARTNER_CD, ISA_NBR, FILE_NM,
					EDI_MESSAGE_NO, LOG_DT, MAP_NM)
				VALUES
					(@TRADING_PARTNER_CD, @ISA_NBR, @FILE_NM,
					@EDI_MESSAGE_NO, @LOG_DT, @MAP_NM)
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
				("@FILE_NM", File_Nm);
			p[2] = Connection.GetParameter
				("@LOG_DT", Log_Dt);
			p[3] = Connection.GetParameter
				("@TRADING_PARTNER_CD", Trading_Partner_Cd);
			p[4] = Connection.GetParameter
				("@ISA_NBR", Isa_Nbr);
			p[5] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);
			p[6] = Connection.GetParameter
				("@EDI_MESSAGE_NO", Edi_Message_No);
			p[7] = Connection.GetParameter
				("@MAP_NM", Map_Nm);

			const string sql = @"
				UPDATE T_EDI_OUTBOUND_LOG SET
					MODIFY_DT = @MODIFY_DT,
					FILE_NM = @FILE_NM,
					LOG_DT = @LOG_DT
				WHERE
					TRADING_PARTNER_CD = @TRADING_PARTNER_CD AND
					ISA_NBR = @ISA_NBR AND
					EDI_MESSAGE_NO = @EDI_MESSAGE_NO AND
					MAP_NM = @MAP_NM
				RETURNING
					MODIFY_USER, MODIFY_DT
				INTO
					@MODIFY_USER, @MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Modify_Dt = ClsConvert.ToDateTimeNullable(p[0].Value);
			Modify_User = ClsConvert.ToString(p[5].Value);
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

			Trading_Partner_Cd = ClsConvert.ToString(dr["TRADING_PARTNER_CD"]);
			Isa_Nbr = ClsConvert.ToDecimalNullable(dr["ISA_NBR"]);
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

			Trading_Partner_Cd = ClsConvert.ToString(dr["TRADING_PARTNER_CD", v]);
			Isa_Nbr = ClsConvert.ToDecimalNullable(dr["ISA_NBR", v]);
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

		public static ClsEdiOutboundLog GetUsingKey(string Trading_Partner_Cd, decimal Isa_Nbr, string Edi_Message_No, string Map_Nm)
		{
			object[] vals = new object[] {Trading_Partner_Cd, Isa_Nbr, Edi_Message_No, Map_Nm};
			DataRow dr = Connection.GetDataRowUsingKey
				(TableName, GetPrimaryKeys(), vals);
			return ( dr == null ) ? null : new ClsEdiOutboundLog(dr);
		}

		#endregion		// #region Static Methods
	}
}