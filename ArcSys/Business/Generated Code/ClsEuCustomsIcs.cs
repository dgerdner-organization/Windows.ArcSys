using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsEuCustomsIcs : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ArcSys"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "T_EU_CUSTOMS_ICS";
		public const int PrimaryKeyCount = 1;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] { "EU_CUSTOMS_ICS_ID" };
		}

		public const string SelectSQL = @"SELECT * FROM T_EU_CUSTOMS_ICS 
				LEFT OUTER JOIN R_TRADING_PARTNER
				ON T_EU_CUSTOMS_ICS.TRADING_PARTNER_CD=R_TRADING_PARTNER.TRADING_PARTNER_CD ";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int File_NmMax = 200;
		public const int Bol_NoMax = 20;
		public const int Message_IDMax = 20;
		public const int First_Port_Of_Entry_CdMax = 20;
		public const int MrnMax = 20;
		public const int Trading_Partner_CdMax = 20;
		public const int Message_ActionMax = 20;
		public const int Create_UserMax = 30;
		public const int Modify_UserMax = 30;
		public const int File_PathMax = 500;
		public const int Message_TypeMax = 10;
		public const int RecipientMax = 10;
		public const int XmldateMax = 30;
		public const int File_ContentMax = 1000;
		public const int Processed_FlgMax = 1;
		public const int Process_MsgMax = 500;
		public const int Acknowledged_FlgMax = 1;
		public const int Acknowledged_UserMax = 30;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected Int64? _Eu_Customs_Ics_ID;
		protected string _File_Nm;
		protected string _Bol_No;
		protected string _Message_ID;
		protected string _First_Port_Of_Entry_Cd;
		protected string _Mrn;
		protected DateTime? _Process_Dt;
		protected string _Trading_Partner_Cd;
		protected string _Message_Action;
		protected string _Create_User;
		protected DateTime? _Create_Dt;
		protected string _Modify_User;
		protected DateTime? _Modify_Dt;
		protected string _File_Path;
		protected string _Message_Type;
		protected string _Recipient;
		protected string _Xmldate;
		protected string _File_Content;
		protected string _Processed_Flg;
		protected string _Process_Msg;
		protected string _Acknowledged_Flg;
		protected string _Acknowledged_User;
		protected DateTime? _Acknowledged_Dt;
		protected DateTime? _File_Dt;

		#endregion	// #region Column Fields

		#region Column Properties

		public Int64? Eu_Customs_Ics_ID
		{
			get { return _Eu_Customs_Ics_ID; }
			set
			{
				if( _Eu_Customs_Ics_ID == value ) return;
		
				_Eu_Customs_Ics_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Eu_Customs_Ics_ID");
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
		public string Message_ID
		{
			get { return _Message_ID; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Message_ID, val, false) == 0 ) return;
		
				if( val != null && val.Length > Message_IDMax )
					_Message_ID = val.Substring(0, (int)Message_IDMax);
				else
					_Message_ID = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Message_ID");
			}
		}
		public string First_Port_Of_Entry_Cd
		{
			get { return _First_Port_Of_Entry_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_First_Port_Of_Entry_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > First_Port_Of_Entry_CdMax )
					_First_Port_Of_Entry_Cd = val.Substring(0, (int)First_Port_Of_Entry_CdMax);
				else
					_First_Port_Of_Entry_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("First_Port_Of_Entry_Cd");
			}
		}
		public string Mrn
		{
			get { return _Mrn; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Mrn, val, false) == 0 ) return;
		
				if( val != null && val.Length > MrnMax )
					_Mrn = val.Substring(0, (int)MrnMax);
				else
					_Mrn = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Mrn");
			}
		}
		public DateTime? Process_Dt
		{
			get { return _Process_Dt; }
			set
			{
				if( _Process_Dt == value ) return;
		
				_Process_Dt = value;
				_IsDirty = true;
				NotifyPropertyChanged("Process_Dt");
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
		public string Message_Action
		{
			get { return _Message_Action; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Message_Action, val, false) == 0 ) return;
		
				if( val != null && val.Length > Message_ActionMax )
					_Message_Action = val.Substring(0, (int)Message_ActionMax);
				else
					_Message_Action = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Message_Action");
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
		public string File_Path
		{
			get { return _File_Path; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_File_Path, val, false) == 0 ) return;
		
				if( val != null && val.Length > File_PathMax )
					_File_Path = val.Substring(0, (int)File_PathMax);
				else
					_File_Path = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("File_Path");
			}
		}
		public string Message_Type
		{
			get { return _Message_Type; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Message_Type, val, false) == 0 ) return;
		
				if( val != null && val.Length > Message_TypeMax )
					_Message_Type = val.Substring(0, (int)Message_TypeMax);
				else
					_Message_Type = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Message_Type");
			}
		}
		public string Recipient
		{
			get { return _Recipient; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Recipient, val, false) == 0 ) return;
		
				if( val != null && val.Length > RecipientMax )
					_Recipient = val.Substring(0, (int)RecipientMax);
				else
					_Recipient = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Recipient");
			}
		}
		public string Xmldate
		{
			get { return _Xmldate; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Xmldate, val, false) == 0 ) return;
		
				if( val != null && val.Length > XmldateMax )
					_Xmldate = val.Substring(0, (int)XmldateMax);
				else
					_Xmldate = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Xmldate");
			}
		}
		public string File_Content
		{
			get { return _File_Content; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_File_Content, val, false) == 0 ) return;
		
				if( val != null && val.Length > File_ContentMax )
					_File_Content = val.Substring(0, (int)File_ContentMax);
				else
					_File_Content = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("File_Content");
			}
		}
		public string Processed_Flg
		{
			get { return _Processed_Flg; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Processed_Flg, val, false) == 0 ) return;
		
				if( val != null && val.Length > Processed_FlgMax )
					_Processed_Flg = val.Substring(0, (int)Processed_FlgMax);
				else
					_Processed_Flg = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Processed_Flg");
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
		public string Acknowledged_Flg
		{
			get { return _Acknowledged_Flg; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Acknowledged_Flg, val, false) == 0 ) return;
		
				if( val != null && val.Length > Acknowledged_FlgMax )
					_Acknowledged_Flg = val.Substring(0, (int)Acknowledged_FlgMax);
				else
					_Acknowledged_Flg = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Acknowledged_Flg");
			}
		}
		public string Acknowledged_User
		{
			get { return _Acknowledged_User; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Acknowledged_User, val, false) == 0 ) return;
		
				if( val != null && val.Length > Acknowledged_UserMax )
					_Acknowledged_User = val.Substring(0, (int)Acknowledged_UserMax);
				else
					_Acknowledged_User = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Acknowledged_User");
			}
		}
		public DateTime? Acknowledged_Dt
		{
			get { return _Acknowledged_Dt; }
			set
			{
				if( _Acknowledged_Dt == value ) return;
		
				_Acknowledged_Dt = value;
				_IsDirty = true;
				NotifyPropertyChanged("Acknowledged_Dt");
			}
		}
		public DateTime? File_Dt
		{
			get { return _File_Dt; }
			set
			{
				if( _File_Dt == value ) return;
		
				_File_Dt = value;
				_IsDirty = true;
				NotifyPropertyChanged("File_Dt");
			}
		}

		#endregion	// #region Column Properties

		#region Foreign Key Fields



		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties



		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsEuCustomsIcs() : base() {}
		public ClsEuCustomsIcs(DataRow dr) : base(dr) {}
		public ClsEuCustomsIcs(ClsEuCustomsIcs src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Eu_Customs_Ics_ID = null;
			File_Nm = null;
			Bol_No = null;
			Message_ID = null;
			First_Port_Of_Entry_Cd = null;
			Mrn = null;
			Process_Dt = null;
			Trading_Partner_Cd = null;
			Message_Action = null;
			Create_User = null;
			Create_Dt = null;
			Modify_User = null;
			Modify_Dt = null;
			File_Path = null;
			Message_Type = null;
			Recipient = null;
			Xmldate = null;
			File_Content = null;
			Processed_Flg = null;
			Process_Msg = null;
			Acknowledged_Flg = null;
			Acknowledged_User = null;
			Acknowledged_Dt = null;
			File_Dt = null;
		}

		public void CopyFrom(ClsEuCustomsIcs src)
		{
			Eu_Customs_Ics_ID = src._Eu_Customs_Ics_ID;
			File_Nm = src._File_Nm;
			Bol_No = src._Bol_No;
			Message_ID = src._Message_ID;
			First_Port_Of_Entry_Cd = src._First_Port_Of_Entry_Cd;
			Mrn = src._Mrn;
			Process_Dt = src._Process_Dt;
			Trading_Partner_Cd = src._Trading_Partner_Cd;
			Message_Action = src._Message_Action;
			Create_User = src._Create_User;
			Create_Dt = src._Create_Dt;
			Modify_User = src._Modify_User;
			Modify_Dt = src._Modify_Dt;
			File_Path = src._File_Path;
			Message_Type = src._Message_Type;
			Recipient = src._Recipient;
			Xmldate = src._Xmldate;
			File_Content = src._File_Content;
			Processed_Flg = src._Processed_Flg;
			Process_Msg = src._Process_Msg;
			Acknowledged_Flg = src._Acknowledged_Flg;
			Acknowledged_User = src._Acknowledged_User;
			Acknowledged_Dt = src._Acknowledged_Dt;
			File_Dt = src._File_Dt;
		}

		public override bool ReloadFromDB()
		{
			ClsEuCustomsIcs tmp = ClsEuCustomsIcs.GetUsingKey(Eu_Customs_Ics_ID.Value);
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

			DbParameter[] p = new DbParameter[24];

			p[0] = Connection.GetParameter
				("@FILE_NM", File_Nm);
			p[1] = Connection.GetParameter
				("@BOL_NO", Bol_No);
			p[2] = Connection.GetParameter
				("@MESSAGE_ID", Message_ID);
			p[3] = Connection.GetParameter
				("@FIRST_PORT_OF_ENTRY_CD", First_Port_Of_Entry_Cd);
			p[4] = Connection.GetParameter
				("@MRN", Mrn);
			p[5] = Connection.GetParameter
				("@PROCESS_DT", Process_Dt);
			p[6] = Connection.GetParameter
				("@TRADING_PARTNER_CD", Trading_Partner_Cd);
			p[7] = Connection.GetParameter
				("@MESSAGE_ACTION", Message_Action);
			p[8] = Connection.GetParameter
				("@FILE_PATH", File_Path);
			p[9] = Connection.GetParameter
				("@MESSAGE_TYPE", Message_Type);
			p[10] = Connection.GetParameter
				("@RECIPIENT", Recipient);
			p[11] = Connection.GetParameter
				("@XMLDATE", Xmldate);
			p[12] = Connection.GetParameter
				("@FILE_CONTENT", File_Content);
			p[13] = Connection.GetParameter
				("@PROCESSED_FLG", Processed_Flg);
			p[14] = Connection.GetParameter
				("@PROCESS_MSG", Process_Msg);
			p[15] = Connection.GetParameter
				("@ACKNOWLEDGED_FLG", Acknowledged_Flg);
			p[16] = Connection.GetParameter
				("@ACKNOWLEDGED_USER", Acknowledged_User);
			p[17] = Connection.GetParameter
				("@ACKNOWLEDGED_DT", Acknowledged_Dt);
			p[18] = Connection.GetParameter
				("@FILE_DT", File_Dt);
			p[19] = Connection.GetParameter
				("@EU_CUSTOMS_ICS_ID", Eu_Customs_Ics_ID, ParameterDirection.Output, DbType.Int64, 0);
			p[20] = Connection.GetParameter
				("@CREATE_USER", Create_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Create_UserMax);
			p[21] = Connection.GetParameter
				("@CREATE_DT", Create_Dt, ParameterDirection.Output, DbType.DateTime, 0);
			p[22] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);
			p[23] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.Output, DbType.DateTime, 0);

			const string sql = @"
				INSERT INTO T_EU_CUSTOMS_ICS
					(EU_CUSTOMS_ICS_ID, FILE_NM, BOL_NO,
					MESSAGE_ID, FIRST_PORT_OF_ENTRY_CD, MRN,
					PROCESS_DT, TRADING_PARTNER_CD, MESSAGE_ACTION,
					FILE_PATH, MESSAGE_TYPE, RECIPIENT,
					XMLDATE, FILE_CONTENT, PROCESSED_FLG,
					PROCESS_MSG, ACKNOWLEDGED_FLG, ACKNOWLEDGED_USER,
					ACKNOWLEDGED_DT, FILE_DT)
				VALUES
					(EU_CUSTOMS_ICS_ID_SEQ.NEXTVAL, @FILE_NM, @BOL_NO,
					@MESSAGE_ID, @FIRST_PORT_OF_ENTRY_CD, @MRN,
					@PROCESS_DT, @TRADING_PARTNER_CD, @MESSAGE_ACTION,
					@FILE_PATH, @MESSAGE_TYPE, @RECIPIENT,
					@XMLDATE, @FILE_CONTENT, @PROCESSED_FLG,
					@PROCESS_MSG, @ACKNOWLEDGED_FLG, @ACKNOWLEDGED_USER,
					@ACKNOWLEDGED_DT, @FILE_DT)
				RETURNING
					EU_CUSTOMS_ICS_ID, CREATE_USER, CREATE_DT,
					MODIFY_USER, MODIFY_DT
				INTO
					@EU_CUSTOMS_ICS_ID, @CREATE_USER, @CREATE_DT,
					@MODIFY_USER, @MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Eu_Customs_Ics_ID = ClsConvert.ToInt64Nullable(p[19].Value);
			Create_User = ClsConvert.ToString(p[20].Value);
			Create_Dt = ClsConvert.ToDateTimeNullable(p[21].Value);
			Modify_User = ClsConvert.ToString(p[22].Value);
			Modify_Dt = ClsConvert.ToDateTimeNullable(p[23].Value);
			return ret;
		}
		public override int Update()
		{
			DbParameter[] p = new DbParameter[22];

			p[0] = Connection.GetParameter
				("@FILE_NM", File_Nm);
			p[1] = Connection.GetParameter
				("@BOL_NO", Bol_No);
			p[2] = Connection.GetParameter
				("@MESSAGE_ID", Message_ID);
			p[3] = Connection.GetParameter
				("@FIRST_PORT_OF_ENTRY_CD", First_Port_Of_Entry_Cd);
			p[4] = Connection.GetParameter
				("@MRN", Mrn);
			p[5] = Connection.GetParameter
				("@PROCESS_DT", Process_Dt);
			p[6] = Connection.GetParameter
				("@TRADING_PARTNER_CD", Trading_Partner_Cd);
			p[7] = Connection.GetParameter
				("@MESSAGE_ACTION", Message_Action);
			p[8] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.InputOutput, DbType.DateTime, 0);
			p[9] = Connection.GetParameter
				("@FILE_PATH", File_Path);
			p[10] = Connection.GetParameter
				("@MESSAGE_TYPE", Message_Type);
			p[11] = Connection.GetParameter
				("@RECIPIENT", Recipient);
			p[12] = Connection.GetParameter
				("@XMLDATE", Xmldate);
			p[13] = Connection.GetParameter
				("@FILE_CONTENT", File_Content);
			p[14] = Connection.GetParameter
				("@PROCESSED_FLG", Processed_Flg);
			p[15] = Connection.GetParameter
				("@PROCESS_MSG", Process_Msg);
			p[16] = Connection.GetParameter
				("@ACKNOWLEDGED_FLG", Acknowledged_Flg);
			p[17] = Connection.GetParameter
				("@ACKNOWLEDGED_USER", Acknowledged_User);
			p[18] = Connection.GetParameter
				("@ACKNOWLEDGED_DT", Acknowledged_Dt);
			p[19] = Connection.GetParameter
				("@FILE_DT", File_Dt);
			p[20] = Connection.GetParameter
				("@EU_CUSTOMS_ICS_ID", Eu_Customs_Ics_ID);
			p[21] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);

			const string sql = @"
				UPDATE T_EU_CUSTOMS_ICS SET
					FILE_NM = @FILE_NM,
					BOL_NO = @BOL_NO,
					MESSAGE_ID = @MESSAGE_ID,
					FIRST_PORT_OF_ENTRY_CD = @FIRST_PORT_OF_ENTRY_CD,
					MRN = @MRN,
					PROCESS_DT = @PROCESS_DT,
					TRADING_PARTNER_CD = @TRADING_PARTNER_CD,
					MESSAGE_ACTION = @MESSAGE_ACTION,
					MODIFY_DT = @MODIFY_DT,
					FILE_PATH = @FILE_PATH,
					MESSAGE_TYPE = @MESSAGE_TYPE,
					RECIPIENT = @RECIPIENT,
					XMLDATE = @XMLDATE,
					FILE_CONTENT = @FILE_CONTENT,
					PROCESSED_FLG = @PROCESSED_FLG,
					PROCESS_MSG = @PROCESS_MSG,
					ACKNOWLEDGED_FLG = @ACKNOWLEDGED_FLG,
					ACKNOWLEDGED_USER = @ACKNOWLEDGED_USER,
					ACKNOWLEDGED_DT = @ACKNOWLEDGED_DT,
					FILE_DT = @FILE_DT
				WHERE
					EU_CUSTOMS_ICS_ID = @EU_CUSTOMS_ICS_ID
				RETURNING
					MODIFY_USER, MODIFY_DT
				INTO
					@MODIFY_USER, @MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Modify_Dt = ClsConvert.ToDateTimeNullable(p[8].Value);
			Modify_User = ClsConvert.ToString(p[21].Value);
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

			Eu_Customs_Ics_ID = ClsConvert.ToInt64Nullable(dr["EU_CUSTOMS_ICS_ID"]);
			File_Nm = ClsConvert.ToString(dr["FILE_NM"]);
			Bol_No = ClsConvert.ToString(dr["BOL_NO"]);
			Message_ID = ClsConvert.ToString(dr["MESSAGE_ID"]);
			First_Port_Of_Entry_Cd = ClsConvert.ToString(dr["FIRST_PORT_OF_ENTRY_CD"]);
			Mrn = ClsConvert.ToString(dr["MRN"]);
			Process_Dt = ClsConvert.ToDateTimeNullable(dr["PROCESS_DT"]);
			Trading_Partner_Cd = ClsConvert.ToString(dr["TRADING_PARTNER_CD"]);
			Message_Action = ClsConvert.ToString(dr["MESSAGE_ACTION"]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER"]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT"]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER"]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT"]);
			File_Path = ClsConvert.ToString(dr["FILE_PATH"]);
			Message_Type = ClsConvert.ToString(dr["MESSAGE_TYPE"]);
			Recipient = ClsConvert.ToString(dr["RECIPIENT"]);
			Xmldate = ClsConvert.ToString(dr["XMLDATE"]);
			File_Content = ClsConvert.ToString(dr["FILE_CONTENT"]);
			Processed_Flg = ClsConvert.ToString(dr["PROCESSED_FLG"]);
			Process_Msg = ClsConvert.ToString(dr["PROCESS_MSG"]);
			Acknowledged_Flg = ClsConvert.ToString(dr["ACKNOWLEDGED_FLG"]);
			Acknowledged_User = ClsConvert.ToString(dr["ACKNOWLEDGED_USER"]);
			Acknowledged_Dt = ClsConvert.ToDateTimeNullable(dr["ACKNOWLEDGED_DT"]);
			File_Dt = ClsConvert.ToDateTimeNullable(dr["FILE_DT"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Eu_Customs_Ics_ID = ClsConvert.ToInt64Nullable(dr["EU_CUSTOMS_ICS_ID", v]);
			File_Nm = ClsConvert.ToString(dr["FILE_NM", v]);
			Bol_No = ClsConvert.ToString(dr["BOL_NO", v]);
			Message_ID = ClsConvert.ToString(dr["MESSAGE_ID", v]);
			First_Port_Of_Entry_Cd = ClsConvert.ToString(dr["FIRST_PORT_OF_ENTRY_CD", v]);
			Mrn = ClsConvert.ToString(dr["MRN", v]);
			Process_Dt = ClsConvert.ToDateTimeNullable(dr["PROCESS_DT", v]);
			Trading_Partner_Cd = ClsConvert.ToString(dr["TRADING_PARTNER_CD", v]);
			Message_Action = ClsConvert.ToString(dr["MESSAGE_ACTION", v]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER", v]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT", v]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER", v]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT", v]);
			File_Path = ClsConvert.ToString(dr["FILE_PATH", v]);
			Message_Type = ClsConvert.ToString(dr["MESSAGE_TYPE", v]);
			Recipient = ClsConvert.ToString(dr["RECIPIENT", v]);
			Xmldate = ClsConvert.ToString(dr["XMLDATE", v]);
			File_Content = ClsConvert.ToString(dr["FILE_CONTENT", v]);
			Processed_Flg = ClsConvert.ToString(dr["PROCESSED_FLG", v]);
			Process_Msg = ClsConvert.ToString(dr["PROCESS_MSG", v]);
			Acknowledged_Flg = ClsConvert.ToString(dr["ACKNOWLEDGED_FLG", v]);
			Acknowledged_User = ClsConvert.ToString(dr["ACKNOWLEDGED_USER", v]);
			Acknowledged_Dt = ClsConvert.ToDateTimeNullable(dr["ACKNOWLEDGED_DT", v]);
			File_Dt = ClsConvert.ToDateTimeNullable(dr["FILE_DT", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["EU_CUSTOMS_ICS_ID"] = ClsConvert.ToDbObject(Eu_Customs_Ics_ID);
			dr["FILE_NM"] = ClsConvert.ToDbObject(File_Nm);
			dr["BOL_NO"] = ClsConvert.ToDbObject(Bol_No);
			dr["MESSAGE_ID"] = ClsConvert.ToDbObject(Message_ID);
			dr["FIRST_PORT_OF_ENTRY_CD"] = ClsConvert.ToDbObject(First_Port_Of_Entry_Cd);
			dr["MRN"] = ClsConvert.ToDbObject(Mrn);
			dr["PROCESS_DT"] = ClsConvert.ToDbObject(Process_Dt);
			dr["TRADING_PARTNER_CD"] = ClsConvert.ToDbObject(Trading_Partner_Cd);
			dr["MESSAGE_ACTION"] = ClsConvert.ToDbObject(Message_Action);
			dr["CREATE_USER"] = ClsConvert.ToDbObject(Create_User);
			dr["CREATE_DT"] = ClsConvert.ToDbObject(Create_Dt);
			dr["MODIFY_USER"] = ClsConvert.ToDbObject(Modify_User);
			dr["MODIFY_DT"] = ClsConvert.ToDbObject(Modify_Dt);
			dr["FILE_PATH"] = ClsConvert.ToDbObject(File_Path);
			dr["MESSAGE_TYPE"] = ClsConvert.ToDbObject(Message_Type);
			dr["RECIPIENT"] = ClsConvert.ToDbObject(Recipient);
			dr["XMLDATE"] = ClsConvert.ToDbObject(Xmldate);
			dr["FILE_CONTENT"] = ClsConvert.ToDbObject(File_Content);
			dr["PROCESSED_FLG"] = ClsConvert.ToDbObject(Processed_Flg);
			dr["PROCESS_MSG"] = ClsConvert.ToDbObject(Process_Msg);
			dr["ACKNOWLEDGED_FLG"] = ClsConvert.ToDbObject(Acknowledged_Flg);
			dr["ACKNOWLEDGED_USER"] = ClsConvert.ToDbObject(Acknowledged_User);
			dr["ACKNOWLEDGED_DT"] = ClsConvert.ToDbObject(Acknowledged_Dt);
			dr["FILE_DT"] = ClsConvert.ToDbObject(File_Dt);
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

		public static ClsEuCustomsIcs GetUsingKey(Int64 Eu_Customs_Ics_ID)
		{
			object[] vals = new object[] {Eu_Customs_Ics_ID};
			DataRow dr = Connection.GetDataRowUsingKey
				(TableName, GetPrimaryKeys(), vals);
			return ( dr == null ) ? null : new ClsEuCustomsIcs(dr);
		}
		public static DataTable GetAll(string Trading_Partner_Cd)
		{
			List<DbParameter> lst = new List<DbParameter>();	
			StringBuilder sb = new StringBuilder();
		
			if( string.IsNullOrEmpty(Trading_Partner_Cd) == false )
			{
				lst.Add(Connection.GetParameter("@TRADING_PARTNER_CD", Trading_Partner_Cd));
				sb.Append(" WHERE T_EU_CUSTOMS_ICS.TRADING_PARTNER_CD=@TRADING_PARTNER_CD");
			}
			sb.Insert(0, SelectSQL);
			return Connection.GetDataTable(sb.ToString(), lst.ToArray());
		}
		#endregion		// #region Static Methods
	}
}