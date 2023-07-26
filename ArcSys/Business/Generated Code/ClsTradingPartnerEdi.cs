using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsTradingPartnerEdi : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ArcSys"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "R_TRADING_PARTNER_EDI";
		public const int PrimaryKeyCount = 1;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] { "TRADING_PARTNER_EDI_ID" };
		}

		public const string SelectSQL = @"SELECT * FROM R_TRADING_PARTNER_EDI 
				LEFT OUTER JOIN R_TRADING_PARTNER
				ON R_TRADING_PARTNER_EDI.TRADING_PARTNER_CD=R_TRADING_PARTNER.TRADING_PARTNER_CD ";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Trading_Partner_CdMax = 10;
		public const int Map_NmMax = 20;
		public const int In_Out_CdMax = 10;
		public const int Map_File_NmMax = 50;
		public const int Map_PathMax = 250;
		public const int Script_PathMax = 250;
		public const int File_PathMax = 250;
		public const int PrefixMax = 10;
		public const int Archive_PathMax = 250;
		public const int Receiver_IDMax = 20;
		public const int Receiver_QualifierMax = 2;
		public const int Control_StandardMax = 20;
		public const int Control_Version_NoMax = 20;
		public const int Control_Version_No_GsMax = 20;
		public const int Map_SetMax = 10;
		public const int Error_PathMax = 250;
		public const int Notify_EmailMax = 1000;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected decimal? _Trading_Partner_Edi_ID;
		protected string _Trading_Partner_Cd;
		protected string _Map_Nm;
		protected string _In_Out_Cd;
		protected string _Map_File_Nm;
		protected string _Map_Path;
		protected string _Script_Path;
		protected string _File_Path;
		protected string _Prefix;
		protected string _Archive_Path;
		protected string _Receiver_ID;
		protected string _Receiver_Qualifier;
		protected string _Control_Standard;
		protected string _Control_Version_No;
		protected string _Control_Version_No_Gs;
		protected decimal? _Outbound_Isa_Nbr;
		protected string _Map_Set;
		protected string _Error_Path;
		protected string _Notify_Email;

		#endregion	// #region Column Fields

		#region Column Properties

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
		public string In_Out_Cd
		{
			get { return _In_Out_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_In_Out_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > In_Out_CdMax )
					_In_Out_Cd = val.Substring(0, (int)In_Out_CdMax);
				else
					_In_Out_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("In_Out_Cd");
			}
		}
		public string Map_File_Nm
		{
			get { return _Map_File_Nm; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Map_File_Nm, val, false) == 0 ) return;
		
				if( val != null && val.Length > Map_File_NmMax )
					_Map_File_Nm = val.Substring(0, (int)Map_File_NmMax);
				else
					_Map_File_Nm = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Map_File_Nm");
			}
		}
		public string Map_Path
		{
			get { return _Map_Path; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Map_Path, val, false) == 0 ) return;
		
				if( val != null && val.Length > Map_PathMax )
					_Map_Path = val.Substring(0, (int)Map_PathMax);
				else
					_Map_Path = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Map_Path");
			}
		}
		public string Script_Path
		{
			get { return _Script_Path; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Script_Path, val, false) == 0 ) return;
		
				if( val != null && val.Length > Script_PathMax )
					_Script_Path = val.Substring(0, (int)Script_PathMax);
				else
					_Script_Path = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Script_Path");
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
		public string Prefix
		{
			get { return _Prefix; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Prefix, val, false) == 0 ) return;
		
				if( val != null && val.Length > PrefixMax )
					_Prefix = val.Substring(0, (int)PrefixMax);
				else
					_Prefix = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Prefix");
			}
		}
		public string Archive_Path
		{
			get { return _Archive_Path; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Archive_Path, val, false) == 0 ) return;
		
				if( val != null && val.Length > Archive_PathMax )
					_Archive_Path = val.Substring(0, (int)Archive_PathMax);
				else
					_Archive_Path = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Archive_Path");
			}
		}
		public string Receiver_ID
		{
			get { return _Receiver_ID; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Receiver_ID, val, false) == 0 ) return;
		
				if( val != null && val.Length > Receiver_IDMax )
					_Receiver_ID = val.Substring(0, (int)Receiver_IDMax);
				else
					_Receiver_ID = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Receiver_ID");
			}
		}
		public string Receiver_Qualifier
		{
			get { return _Receiver_Qualifier; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Receiver_Qualifier, val, false) == 0 ) return;
		
				if( val != null && val.Length > Receiver_QualifierMax )
					_Receiver_Qualifier = val.Substring(0, (int)Receiver_QualifierMax);
				else
					_Receiver_Qualifier = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Receiver_Qualifier");
			}
		}
		public string Control_Standard
		{
			get { return _Control_Standard; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Control_Standard, val, false) == 0 ) return;
		
				if( val != null && val.Length > Control_StandardMax )
					_Control_Standard = val.Substring(0, (int)Control_StandardMax);
				else
					_Control_Standard = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Control_Standard");
			}
		}
		public string Control_Version_No
		{
			get { return _Control_Version_No; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Control_Version_No, val, false) == 0 ) return;
		
				if( val != null && val.Length > Control_Version_NoMax )
					_Control_Version_No = val.Substring(0, (int)Control_Version_NoMax);
				else
					_Control_Version_No = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Control_Version_No");
			}
		}
		public string Control_Version_No_Gs
		{
			get { return _Control_Version_No_Gs; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Control_Version_No_Gs, val, false) == 0 ) return;
		
				if( val != null && val.Length > Control_Version_No_GsMax )
					_Control_Version_No_Gs = val.Substring(0, (int)Control_Version_No_GsMax);
				else
					_Control_Version_No_Gs = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Control_Version_No_Gs");
			}
		}
		public decimal? Outbound_Isa_Nbr
		{
			get { return _Outbound_Isa_Nbr; }
			set
			{
				if( _Outbound_Isa_Nbr == value ) return;
		
				_Outbound_Isa_Nbr = value;
				_IsDirty = true;
				NotifyPropertyChanged("Outbound_Isa_Nbr");
			}
		}
		public string Map_Set
		{
			get { return _Map_Set; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Map_Set, val, false) == 0 ) return;
		
				if( val != null && val.Length > Map_SetMax )
					_Map_Set = val.Substring(0, (int)Map_SetMax);
				else
					_Map_Set = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Map_Set");
			}
		}
		public string Error_Path
		{
			get { return _Error_Path; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Error_Path, val, false) == 0 ) return;
		
				if( val != null && val.Length > Error_PathMax )
					_Error_Path = val.Substring(0, (int)Error_PathMax);
				else
					_Error_Path = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Error_Path");
			}
		}
		public string Notify_Email
		{
			get { return _Notify_Email; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Notify_Email, val, false) == 0 ) return;
		
				if( val != null && val.Length > Notify_EmailMax )
					_Notify_Email = val.Substring(0, (int)Notify_EmailMax);
				else
					_Notify_Email = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Notify_Email");
			}
		}

		#endregion	// #region Column Properties

		#region Foreign Key Fields

		protected ClsTradingPartner _Trading_Partner;

		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties

		public ClsTradingPartner Trading_Partner
		{
			get
			{
				if( Trading_Partner_Cd == null )
					_Trading_Partner = null;
				else if( _Trading_Partner == null ||
					_Trading_Partner.Trading_Partner_Cd != Trading_Partner_Cd )
					_Trading_Partner = ClsTradingPartner.GetUsingKey(Trading_Partner_Cd);
				return _Trading_Partner;
			}
			set
			{
				if( _Trading_Partner == value ) return;
		
				_Trading_Partner = value;
			}
		}

		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsTradingPartnerEdi() : base() {}
		public ClsTradingPartnerEdi(DataRow dr) : base(dr) {}
		public ClsTradingPartnerEdi(ClsTradingPartnerEdi src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Trading_Partner_Edi_ID = null;
			Trading_Partner_Cd = null;
			Map_Nm = null;
			In_Out_Cd = null;
			Map_File_Nm = null;
			Map_Path = null;
			Script_Path = null;
			File_Path = null;
			Prefix = null;
			Archive_Path = null;
			Receiver_ID = null;
			Receiver_Qualifier = null;
			Control_Standard = null;
			Control_Version_No = null;
			Control_Version_No_Gs = null;
			Outbound_Isa_Nbr = null;
			Map_Set = null;
			Error_Path = null;
			Notify_Email = null;
		}

		public void CopyFrom(ClsTradingPartnerEdi src)
		{
			Trading_Partner_Edi_ID = src._Trading_Partner_Edi_ID;
			Trading_Partner_Cd = src._Trading_Partner_Cd;
			Map_Nm = src._Map_Nm;
			In_Out_Cd = src._In_Out_Cd;
			Map_File_Nm = src._Map_File_Nm;
			Map_Path = src._Map_Path;
			Script_Path = src._Script_Path;
			File_Path = src._File_Path;
			Prefix = src._Prefix;
			Archive_Path = src._Archive_Path;
			Receiver_ID = src._Receiver_ID;
			Receiver_Qualifier = src._Receiver_Qualifier;
			Control_Standard = src._Control_Standard;
			Control_Version_No = src._Control_Version_No;
			Control_Version_No_Gs = src._Control_Version_No_Gs;
			Outbound_Isa_Nbr = src._Outbound_Isa_Nbr;
			Map_Set = src._Map_Set;
			Error_Path = src._Error_Path;
			Notify_Email = src._Notify_Email;
		}

		public override bool ReloadFromDB()
		{
			ClsTradingPartnerEdi tmp = ClsTradingPartnerEdi.GetUsingKey(Trading_Partner_Edi_ID.Value);
			if( tmp != null ) CopyFrom(tmp);

			ResetFKs();
			OnReload();

			return ( tmp != null );
		}

		public override void ResetFKs()
		{
			_Trading_Partner = null;
		}
		#endregion		// #region Init methods

		#region Insert, Update, Delete

		public override int Insert()
		{

			DbParameter[] p = new DbParameter[19];

			p[0] = Connection.GetParameter
				("@TRADING_PARTNER_CD", Trading_Partner_Cd);
			p[1] = Connection.GetParameter
				("@MAP_NM", Map_Nm);
			p[2] = Connection.GetParameter
				("@IN_OUT_CD", In_Out_Cd);
			p[3] = Connection.GetParameter
				("@MAP_FILE_NM", Map_File_Nm);
			p[4] = Connection.GetParameter
				("@MAP_PATH", Map_Path);
			p[5] = Connection.GetParameter
				("@SCRIPT_PATH", Script_Path);
			p[6] = Connection.GetParameter
				("@FILE_PATH", File_Path);
			p[7] = Connection.GetParameter
				("@PREFIX", Prefix);
			p[8] = Connection.GetParameter
				("@ARCHIVE_PATH", Archive_Path);
			p[9] = Connection.GetParameter
				("@RECEIVER_ID", Receiver_ID);
			p[10] = Connection.GetParameter
				("@RECEIVER_QUALIFIER", Receiver_Qualifier);
			p[11] = Connection.GetParameter
				("@CONTROL_STANDARD", Control_Standard);
			p[12] = Connection.GetParameter
				("@CONTROL_VERSION_NO", Control_Version_No);
			p[13] = Connection.GetParameter
				("@CONTROL_VERSION_NO_GS", Control_Version_No_Gs);
			p[14] = Connection.GetParameter
				("@OUTBOUND_ISA_NBR", Outbound_Isa_Nbr);
			p[15] = Connection.GetParameter
				("@MAP_SET", Map_Set);
			p[16] = Connection.GetParameter
				("@ERROR_PATH", Error_Path);
			p[17] = Connection.GetParameter
				("@NOTIFY_EMAIL", Notify_Email);
			p[18] = Connection.GetParameter
				("@TRADING_PARTNER_EDI_ID", Trading_Partner_Edi_ID, ParameterDirection.Output, DbType.Decimal, 0);

			const string sql = @"
				INSERT INTO R_TRADING_PARTNER_EDI
					(TRADING_PARTNER_EDI_ID, TRADING_PARTNER_CD, MAP_NM,
					IN_OUT_CD, MAP_FILE_NM, MAP_PATH,
					SCRIPT_PATH, FILE_PATH, PREFIX,
					ARCHIVE_PATH, RECEIVER_ID, RECEIVER_QUALIFIER,
					CONTROL_STANDARD, CONTROL_VERSION_NO, CONTROL_VERSION_NO_GS,
					OUTBOUND_ISA_NBR, MAP_SET, ERROR_PATH,
					NOTIFY_EMAIL)
				VALUES
					(TRADING_PARTNER_EDI_ID_SEQ.NEXTVAL, @TRADING_PARTNER_CD, @MAP_NM,
					@IN_OUT_CD, @MAP_FILE_NM, @MAP_PATH,
					@SCRIPT_PATH, @FILE_PATH, @PREFIX,
					@ARCHIVE_PATH, @RECEIVER_ID, @RECEIVER_QUALIFIER,
					@CONTROL_STANDARD, @CONTROL_VERSION_NO, @CONTROL_VERSION_NO_GS,
					@OUTBOUND_ISA_NBR, @MAP_SET, @ERROR_PATH,
					@NOTIFY_EMAIL)
				RETURNING
					TRADING_PARTNER_EDI_ID
				INTO
					@TRADING_PARTNER_EDI_ID";
			int ret = Connection.RunSQL(sql, p);

			Trading_Partner_Edi_ID = ClsConvert.ToDecimalNullable(p[18].Value);
			return ret;
		}
		public override int Update()
		{
			DbParameter[] p = new DbParameter[19];

			p[0] = Connection.GetParameter
				("@TRADING_PARTNER_CD", Trading_Partner_Cd);
			p[1] = Connection.GetParameter
				("@MAP_NM", Map_Nm);
			p[2] = Connection.GetParameter
				("@IN_OUT_CD", In_Out_Cd);
			p[3] = Connection.GetParameter
				("@MAP_FILE_NM", Map_File_Nm);
			p[4] = Connection.GetParameter
				("@MAP_PATH", Map_Path);
			p[5] = Connection.GetParameter
				("@SCRIPT_PATH", Script_Path);
			p[6] = Connection.GetParameter
				("@FILE_PATH", File_Path);
			p[7] = Connection.GetParameter
				("@PREFIX", Prefix);
			p[8] = Connection.GetParameter
				("@ARCHIVE_PATH", Archive_Path);
			p[9] = Connection.GetParameter
				("@RECEIVER_ID", Receiver_ID);
			p[10] = Connection.GetParameter
				("@RECEIVER_QUALIFIER", Receiver_Qualifier);
			p[11] = Connection.GetParameter
				("@CONTROL_STANDARD", Control_Standard);
			p[12] = Connection.GetParameter
				("@CONTROL_VERSION_NO", Control_Version_No);
			p[13] = Connection.GetParameter
				("@CONTROL_VERSION_NO_GS", Control_Version_No_Gs);
			p[14] = Connection.GetParameter
				("@OUTBOUND_ISA_NBR", Outbound_Isa_Nbr);
			p[15] = Connection.GetParameter
				("@MAP_SET", Map_Set);
			p[16] = Connection.GetParameter
				("@ERROR_PATH", Error_Path);
			p[17] = Connection.GetParameter
				("@NOTIFY_EMAIL", Notify_Email);
			p[18] = Connection.GetParameter
				("@TRADING_PARTNER_EDI_ID", Trading_Partner_Edi_ID);

			const string sql = @"
				UPDATE R_TRADING_PARTNER_EDI SET
					TRADING_PARTNER_CD = @TRADING_PARTNER_CD,
					MAP_NM = @MAP_NM,
					IN_OUT_CD = @IN_OUT_CD,
					MAP_FILE_NM = @MAP_FILE_NM,
					MAP_PATH = @MAP_PATH,
					SCRIPT_PATH = @SCRIPT_PATH,
					FILE_PATH = @FILE_PATH,
					PREFIX = @PREFIX,
					ARCHIVE_PATH = @ARCHIVE_PATH,
					RECEIVER_ID = @RECEIVER_ID,
					RECEIVER_QUALIFIER = @RECEIVER_QUALIFIER,
					CONTROL_STANDARD = @CONTROL_STANDARD,
					CONTROL_VERSION_NO = @CONTROL_VERSION_NO,
					CONTROL_VERSION_NO_GS = @CONTROL_VERSION_NO_GS,
					OUTBOUND_ISA_NBR = @OUTBOUND_ISA_NBR,
					MAP_SET = @MAP_SET,
					ERROR_PATH = @ERROR_PATH,
					NOTIFY_EMAIL = @NOTIFY_EMAIL
				WHERE
					TRADING_PARTNER_EDI_ID = @TRADING_PARTNER_EDI_ID

					";
			int ret = Connection.RunSQL(sql, p);


			return ret;
		}
		public override int Delete()
		{
			DbParameter[] p = new DbParameter[1];

			p[0] = Connection.GetParameter
				("@TRADING_PARTNER_EDI_ID", Trading_Partner_Edi_ID);

			const string sql = @"
				DELETE FROM R_TRADING_PARTNER_EDI WHERE
				TRADING_PARTNER_EDI_ID=@TRADING_PARTNER_EDI_ID";
			return Connection.RunSQL(sql, p);
		}
		#endregion		// #region Insert, Update, Delete

		#region Conversion methods

		public override void LoadFromDataReader(DbDataReader dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataReader: DataReader parameter was null");

			Trading_Partner_Edi_ID = ClsConvert.ToDecimalNullable(dr["TRADING_PARTNER_EDI_ID"]);
			Trading_Partner_Cd = ClsConvert.ToString(dr["TRADING_PARTNER_CD"]);
			Map_Nm = ClsConvert.ToString(dr["MAP_NM"]);
			In_Out_Cd = ClsConvert.ToString(dr["IN_OUT_CD"]);
			Map_File_Nm = ClsConvert.ToString(dr["MAP_FILE_NM"]);
			Map_Path = ClsConvert.ToString(dr["MAP_PATH"]);
			Script_Path = ClsConvert.ToString(dr["SCRIPT_PATH"]);
			File_Path = ClsConvert.ToString(dr["FILE_PATH"]);
			Prefix = ClsConvert.ToString(dr["PREFIX"]);
			Archive_Path = ClsConvert.ToString(dr["ARCHIVE_PATH"]);
			Receiver_ID = ClsConvert.ToString(dr["RECEIVER_ID"]);
			Receiver_Qualifier = ClsConvert.ToString(dr["RECEIVER_QUALIFIER"]);
			Control_Standard = ClsConvert.ToString(dr["CONTROL_STANDARD"]);
			Control_Version_No = ClsConvert.ToString(dr["CONTROL_VERSION_NO"]);
			Control_Version_No_Gs = ClsConvert.ToString(dr["CONTROL_VERSION_NO_GS"]);
			Outbound_Isa_Nbr = ClsConvert.ToDecimalNullable(dr["OUTBOUND_ISA_NBR"]);
			Map_Set = ClsConvert.ToString(dr["MAP_SET"]);
			Error_Path = ClsConvert.ToString(dr["ERROR_PATH"]);
			Notify_Email = ClsConvert.ToString(dr["NOTIFY_EMAIL"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Trading_Partner_Edi_ID = ClsConvert.ToDecimalNullable(dr["TRADING_PARTNER_EDI_ID", v]);
			Trading_Partner_Cd = ClsConvert.ToString(dr["TRADING_PARTNER_CD", v]);
			Map_Nm = ClsConvert.ToString(dr["MAP_NM", v]);
			In_Out_Cd = ClsConvert.ToString(dr["IN_OUT_CD", v]);
			Map_File_Nm = ClsConvert.ToString(dr["MAP_FILE_NM", v]);
			Map_Path = ClsConvert.ToString(dr["MAP_PATH", v]);
			Script_Path = ClsConvert.ToString(dr["SCRIPT_PATH", v]);
			File_Path = ClsConvert.ToString(dr["FILE_PATH", v]);
			Prefix = ClsConvert.ToString(dr["PREFIX", v]);
			Archive_Path = ClsConvert.ToString(dr["ARCHIVE_PATH", v]);
			Receiver_ID = ClsConvert.ToString(dr["RECEIVER_ID", v]);
			Receiver_Qualifier = ClsConvert.ToString(dr["RECEIVER_QUALIFIER", v]);
			Control_Standard = ClsConvert.ToString(dr["CONTROL_STANDARD", v]);
			Control_Version_No = ClsConvert.ToString(dr["CONTROL_VERSION_NO", v]);
			Control_Version_No_Gs = ClsConvert.ToString(dr["CONTROL_VERSION_NO_GS", v]);
			Outbound_Isa_Nbr = ClsConvert.ToDecimalNullable(dr["OUTBOUND_ISA_NBR", v]);
			Map_Set = ClsConvert.ToString(dr["MAP_SET", v]);
			Error_Path = ClsConvert.ToString(dr["ERROR_PATH", v]);
			Notify_Email = ClsConvert.ToString(dr["NOTIFY_EMAIL", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["TRADING_PARTNER_EDI_ID"] = ClsConvert.ToDbObject(Trading_Partner_Edi_ID);
			dr["TRADING_PARTNER_CD"] = ClsConvert.ToDbObject(Trading_Partner_Cd);
			dr["MAP_NM"] = ClsConvert.ToDbObject(Map_Nm);
			dr["IN_OUT_CD"] = ClsConvert.ToDbObject(In_Out_Cd);
			dr["MAP_FILE_NM"] = ClsConvert.ToDbObject(Map_File_Nm);
			dr["MAP_PATH"] = ClsConvert.ToDbObject(Map_Path);
			dr["SCRIPT_PATH"] = ClsConvert.ToDbObject(Script_Path);
			dr["FILE_PATH"] = ClsConvert.ToDbObject(File_Path);
			dr["PREFIX"] = ClsConvert.ToDbObject(Prefix);
			dr["ARCHIVE_PATH"] = ClsConvert.ToDbObject(Archive_Path);
			dr["RECEIVER_ID"] = ClsConvert.ToDbObject(Receiver_ID);
			dr["RECEIVER_QUALIFIER"] = ClsConvert.ToDbObject(Receiver_Qualifier);
			dr["CONTROL_STANDARD"] = ClsConvert.ToDbObject(Control_Standard);
			dr["CONTROL_VERSION_NO"] = ClsConvert.ToDbObject(Control_Version_No);
			dr["CONTROL_VERSION_NO_GS"] = ClsConvert.ToDbObject(Control_Version_No_Gs);
			dr["OUTBOUND_ISA_NBR"] = ClsConvert.ToDbObject(Outbound_Isa_Nbr);
			dr["MAP_SET"] = ClsConvert.ToDbObject(Map_Set);
			dr["ERROR_PATH"] = ClsConvert.ToDbObject(Error_Path);
			dr["NOTIFY_EMAIL"] = ClsConvert.ToDbObject(Notify_Email);
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

		public static ClsTradingPartnerEdi GetUsingKey(decimal Trading_Partner_Edi_ID)
		{
			object[] vals = new object[] {Trading_Partner_Edi_ID};
			DataRow dr = Connection.GetDataRowUsingKey
				(TableName, GetPrimaryKeys(), vals);
			return ( dr == null ) ? null : new ClsTradingPartnerEdi(dr);
		}
		public static DataTable GetAll(string Trading_Partner_Cd)
		{
			List<DbParameter> lst = new List<DbParameter>();	
			StringBuilder sb = new StringBuilder();
		
			if( string.IsNullOrEmpty(Trading_Partner_Cd) == false )
			{
				lst.Add(Connection.GetParameter("@TRADING_PARTNER_CD", Trading_Partner_Cd));
				sb.Append(" WHERE R_TRADING_PARTNER_EDI.TRADING_PARTNER_CD=@TRADING_PARTNER_CD");
			}
			sb.Insert(0, SelectSQL);
			return Connection.GetDataTable(sb.ToString(), lst.ToArray());
		}
		#endregion		// #region Static Methods
	}
}