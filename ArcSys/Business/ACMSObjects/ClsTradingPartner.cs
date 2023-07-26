using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ACMS.Business
{
	public partial class ClsTradingPartner : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ACMS"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "R_TRADING_PARTNER";
		public const int PrimaryKeyCount = 1;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] { "PARTNER_CD" };
		}

		public const string SelectSQL = "SELECT * FROM R_TRADING_PARTNER";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Partner_CdMax = 15;
		public const int Partner_DscMax = 50;
		public const int Delete_FlMax = 1;
		public const int ScacMax = 10;
		public const int Contact_NmMax = 50;
		public const int Contact_PhoneMax = 20;
		public const int Outlook_NameMax = 30;
		public const int Contact_EmailMax = 30;
		public const int Default_FlMax = 1;
		public const int Edi_Input_PathMax = 50;
		public const int Edi_Output_PathMax = 50;
		public const int Edi_Report_PathMax = 50;
		public const int Edi_Control_StdMax = 1;
		public const int Edi_Control_VersionMax = 5;
		public const int Edi_TestMax = 1;
		public const int Edi_VersionMax = 6;
		public const int Edi_Partner_Xchg_QualifierMax = 2;
		public const int Edi_Partner_Xchg_CdMax = 15;
		public const int Edi_Partner_Gs03Max = 15;
		public const int Edi_Attachment_PathMax = 50;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected string _Partner_Cd;
		protected string _Partner_Dsc;
		protected string _Delete_Fl;
		protected string _Scac;
		protected string _Contact_Nm;
		protected string _Contact_Phone;
		protected string _Outlook_Name;
		protected string _Contact_Email;
		protected string _Default_Fl;
		protected string _Edi_Input_Path;
		protected string _Edi_Output_Path;
		protected string _Edi_Report_Path;
		protected string _Edi_Control_Std;
		protected string _Edi_Control_Version;
		protected string _Edi_Test;
		protected string _Edi_Version;
		protected string _Edi_Partner_Xchg_Qualifier;
		protected string _Edi_Partner_Xchg_Cd;
		protected string _Edi_Partner_Gs03;
		protected string _Edi_Attachment_Path;

		#endregion	// #region Column Fields

		#region Column Properties

		public string Partner_Cd
		{
			get { return _Partner_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Partner_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Partner_CdMax )
					_Partner_Cd = val.Substring(0, (int)Partner_CdMax);
				else
					_Partner_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Partner_Cd");
			}
		}
		public string Partner_Dsc
		{
			get { return _Partner_Dsc; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Partner_Dsc, val, false) == 0 ) return;
		
				if( val != null && val.Length > Partner_DscMax )
					_Partner_Dsc = val.Substring(0, (int)Partner_DscMax);
				else
					_Partner_Dsc = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Partner_Dsc");
			}
		}
		public string Delete_Fl
		{
			get { return _Delete_Fl; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Delete_Fl, val, false) == 0 ) return;
		
				if( val != null && val.Length > Delete_FlMax )
					_Delete_Fl = val.Substring(0, (int)Delete_FlMax);
				else
					_Delete_Fl = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Delete_Fl");
			}
		}
		public string Scac
		{
			get { return _Scac; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Scac, val, false) == 0 ) return;
		
				if( val != null && val.Length > ScacMax )
					_Scac = val.Substring(0, (int)ScacMax);
				else
					_Scac = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Scac");
			}
		}
		public string Contact_Nm
		{
			get { return _Contact_Nm; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Contact_Nm, val, false) == 0 ) return;
		
				if( val != null && val.Length > Contact_NmMax )
					_Contact_Nm = val.Substring(0, (int)Contact_NmMax);
				else
					_Contact_Nm = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Contact_Nm");
			}
		}
		public string Contact_Phone
		{
			get { return _Contact_Phone; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Contact_Phone, val, false) == 0 ) return;
		
				if( val != null && val.Length > Contact_PhoneMax )
					_Contact_Phone = val.Substring(0, (int)Contact_PhoneMax);
				else
					_Contact_Phone = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Contact_Phone");
			}
		}
		public string Outlook_Name
		{
			get { return _Outlook_Name; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Outlook_Name, val, false) == 0 ) return;
		
				if( val != null && val.Length > Outlook_NameMax )
					_Outlook_Name = val.Substring(0, (int)Outlook_NameMax);
				else
					_Outlook_Name = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Outlook_Name");
			}
		}
		public string Contact_Email
		{
			get { return _Contact_Email; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Contact_Email, val, false) == 0 ) return;
		
				if( val != null && val.Length > Contact_EmailMax )
					_Contact_Email = val.Substring(0, (int)Contact_EmailMax);
				else
					_Contact_Email = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Contact_Email");
			}
		}
		public string Default_Fl
		{
			get { return _Default_Fl; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Default_Fl, val, false) == 0 ) return;
		
				if( val != null && val.Length > Default_FlMax )
					_Default_Fl = val.Substring(0, (int)Default_FlMax);
				else
					_Default_Fl = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Default_Fl");
			}
		}
		public string Edi_Input_Path
		{
			get { return _Edi_Input_Path; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Edi_Input_Path, val, false) == 0 ) return;
		
				if( val != null && val.Length > Edi_Input_PathMax )
					_Edi_Input_Path = val.Substring(0, (int)Edi_Input_PathMax);
				else
					_Edi_Input_Path = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Edi_Input_Path");
			}
		}
		public string Edi_Output_Path
		{
			get { return _Edi_Output_Path; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Edi_Output_Path, val, false) == 0 ) return;
		
				if( val != null && val.Length > Edi_Output_PathMax )
					_Edi_Output_Path = val.Substring(0, (int)Edi_Output_PathMax);
				else
					_Edi_Output_Path = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Edi_Output_Path");
			}
		}
		public string Edi_Report_Path
		{
			get { return _Edi_Report_Path; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Edi_Report_Path, val, false) == 0 ) return;
		
				if( val != null && val.Length > Edi_Report_PathMax )
					_Edi_Report_Path = val.Substring(0, (int)Edi_Report_PathMax);
				else
					_Edi_Report_Path = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Edi_Report_Path");
			}
		}
		public string Edi_Control_Std
		{
			get { return _Edi_Control_Std; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Edi_Control_Std, val, false) == 0 ) return;
		
				if( val != null && val.Length > Edi_Control_StdMax )
					_Edi_Control_Std = val.Substring(0, (int)Edi_Control_StdMax);
				else
					_Edi_Control_Std = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Edi_Control_Std");
			}
		}
		public string Edi_Control_Version
		{
			get { return _Edi_Control_Version; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Edi_Control_Version, val, false) == 0 ) return;
		
				if( val != null && val.Length > Edi_Control_VersionMax )
					_Edi_Control_Version = val.Substring(0, (int)Edi_Control_VersionMax);
				else
					_Edi_Control_Version = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Edi_Control_Version");
			}
		}
		public string Edi_Test
		{
			get { return _Edi_Test; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Edi_Test, val, false) == 0 ) return;
		
				if( val != null && val.Length > Edi_TestMax )
					_Edi_Test = val.Substring(0, (int)Edi_TestMax);
				else
					_Edi_Test = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Edi_Test");
			}
		}
		public string Edi_Version
		{
			get { return _Edi_Version; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Edi_Version, val, false) == 0 ) return;
		
				if( val != null && val.Length > Edi_VersionMax )
					_Edi_Version = val.Substring(0, (int)Edi_VersionMax);
				else
					_Edi_Version = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Edi_Version");
			}
		}
		public string Edi_Partner_Xchg_Qualifier
		{
			get { return _Edi_Partner_Xchg_Qualifier; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Edi_Partner_Xchg_Qualifier, val, false) == 0 ) return;
		
				if( val != null && val.Length > Edi_Partner_Xchg_QualifierMax )
					_Edi_Partner_Xchg_Qualifier = val.Substring(0, (int)Edi_Partner_Xchg_QualifierMax);
				else
					_Edi_Partner_Xchg_Qualifier = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Edi_Partner_Xchg_Qualifier");
			}
		}
		public string Edi_Partner_Xchg_Cd
		{
			get { return _Edi_Partner_Xchg_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Edi_Partner_Xchg_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Edi_Partner_Xchg_CdMax )
					_Edi_Partner_Xchg_Cd = val.Substring(0, (int)Edi_Partner_Xchg_CdMax);
				else
					_Edi_Partner_Xchg_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Edi_Partner_Xchg_Cd");
			}
		}
		public string Edi_Partner_Gs03
		{
			get { return _Edi_Partner_Gs03; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Edi_Partner_Gs03, val, false) == 0 ) return;
		
				if( val != null && val.Length > Edi_Partner_Gs03Max )
					_Edi_Partner_Gs03 = val.Substring(0, (int)Edi_Partner_Gs03Max);
				else
					_Edi_Partner_Gs03 = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Edi_Partner_Gs03");
			}
		}
		public string Edi_Attachment_Path
		{
			get { return _Edi_Attachment_Path; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Edi_Attachment_Path, val, false) == 0 ) return;
		
				if( val != null && val.Length > Edi_Attachment_PathMax )
					_Edi_Attachment_Path = val.Substring(0, (int)Edi_Attachment_PathMax);
				else
					_Edi_Attachment_Path = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Edi_Attachment_Path");
			}
		}

		#endregion	// #region Column Properties

		#region Foreign Key Fields



		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties



		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsTradingPartner() : base() {}
		public ClsTradingPartner(DataRow dr) : base(dr) {}
		public ClsTradingPartner(ClsTradingPartner src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Partner_Cd = null;
			Partner_Dsc = null;
			Delete_Fl = null;
			Scac = null;
			Contact_Nm = null;
			Contact_Phone = null;
			Outlook_Name = null;
			Contact_Email = null;
			Default_Fl = null;
			Edi_Input_Path = null;
			Edi_Output_Path = null;
			Edi_Report_Path = null;
			Edi_Control_Std = null;
			Edi_Control_Version = null;
			Edi_Test = null;
			Edi_Version = null;
			Edi_Partner_Xchg_Qualifier = null;
			Edi_Partner_Xchg_Cd = null;
			Edi_Partner_Gs03 = null;
			Edi_Attachment_Path = null;
		}

		public void CopyFrom(ClsTradingPartner src)
		{
			Partner_Cd = src._Partner_Cd;
			Partner_Dsc = src._Partner_Dsc;
			Delete_Fl = src._Delete_Fl;
			Scac = src._Scac;
			Contact_Nm = src._Contact_Nm;
			Contact_Phone = src._Contact_Phone;
			Outlook_Name = src._Outlook_Name;
			Contact_Email = src._Contact_Email;
			Default_Fl = src._Default_Fl;
			Edi_Input_Path = src._Edi_Input_Path;
			Edi_Output_Path = src._Edi_Output_Path;
			Edi_Report_Path = src._Edi_Report_Path;
			Edi_Control_Std = src._Edi_Control_Std;
			Edi_Control_Version = src._Edi_Control_Version;
			Edi_Test = src._Edi_Test;
			Edi_Version = src._Edi_Version;
			Edi_Partner_Xchg_Qualifier = src._Edi_Partner_Xchg_Qualifier;
			Edi_Partner_Xchg_Cd = src._Edi_Partner_Xchg_Cd;
			Edi_Partner_Gs03 = src._Edi_Partner_Gs03;
			Edi_Attachment_Path = src._Edi_Attachment_Path;
		}

		public override bool ReloadFromDB()
		{
			ClsTradingPartner tmp = ClsTradingPartner.GetUsingKey(Partner_Cd);
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

			DbParameter[] p = new DbParameter[20];

			p[0] = Connection.GetParameter
				("@PARTNER_CD", Partner_Cd);
			p[1] = Connection.GetParameter
				("@PARTNER_DSC", Partner_Dsc);
			p[2] = Connection.GetParameter
				("@DELETE_FL", Delete_Fl);
			p[3] = Connection.GetParameter
				("@SCAC", Scac);
			p[4] = Connection.GetParameter
				("@CONTACT_NM", Contact_Nm);
			p[5] = Connection.GetParameter
				("@CONTACT_PHONE", Contact_Phone);
			p[6] = Connection.GetParameter
				("@OUTLOOK_NAME", Outlook_Name);
			p[7] = Connection.GetParameter
				("@CONTACT_EMAIL", Contact_Email);
			p[8] = Connection.GetParameter
				("@DEFAULT_FL", Default_Fl);
			p[9] = Connection.GetParameter
				("@EDI_INPUT_PATH", Edi_Input_Path);
			p[10] = Connection.GetParameter
				("@EDI_OUTPUT_PATH", Edi_Output_Path);
			p[11] = Connection.GetParameter
				("@EDI_REPORT_PATH", Edi_Report_Path);
			p[12] = Connection.GetParameter
				("@EDI_CONTROL_STD", Edi_Control_Std);
			p[13] = Connection.GetParameter
				("@EDI_CONTROL_VERSION", Edi_Control_Version);
			p[14] = Connection.GetParameter
				("@EDI_TEST", Edi_Test);
			p[15] = Connection.GetParameter
				("@EDI_VERSION", Edi_Version);
			p[16] = Connection.GetParameter
				("@EDI_PARTNER_XCHG_QUALIFIER", Edi_Partner_Xchg_Qualifier);
			p[17] = Connection.GetParameter
				("@EDI_PARTNER_XCHG_CD", Edi_Partner_Xchg_Cd);
			p[18] = Connection.GetParameter
				("@EDI_PARTNER_GS03", Edi_Partner_Gs03);
			p[19] = Connection.GetParameter
				("@EDI_ATTACHMENT_PATH", Edi_Attachment_Path);

			const string sql = @"
				INSERT INTO R_TRADING_PARTNER
					(PARTNER_CD, PARTNER_DSC, DELETE_FL,
					SCAC, CONTACT_NM, CONTACT_PHONE,
					OUTLOOK_NAME, CONTACT_EMAIL, DEFAULT_FL,
					EDI_INPUT_PATH, EDI_OUTPUT_PATH, EDI_REPORT_PATH,
					EDI_CONTROL_STD, EDI_CONTROL_VERSION, EDI_TEST,
					EDI_VERSION, EDI_PARTNER_XCHG_QUALIFIER, EDI_PARTNER_XCHG_CD,
					EDI_PARTNER_GS03, EDI_ATTACHMENT_PATH)
				VALUES
					(@PARTNER_CD, @PARTNER_DSC, @DELETE_FL,
					@SCAC, @CONTACT_NM, @CONTACT_PHONE,
					@OUTLOOK_NAME, @CONTACT_EMAIL, @DEFAULT_FL,
					@EDI_INPUT_PATH, @EDI_OUTPUT_PATH, @EDI_REPORT_PATH,
					@EDI_CONTROL_STD, @EDI_CONTROL_VERSION, @EDI_TEST,
					@EDI_VERSION, @EDI_PARTNER_XCHG_QUALIFIER, @EDI_PARTNER_XCHG_CD,
					@EDI_PARTNER_GS03, @EDI_ATTACHMENT_PATH)
				RETURNING
					
				INTO
					";
			int ret = Connection.RunSQL(sql, p);


			return ret;
		}
		public override int Update()
		{
			DbParameter[] p = new DbParameter[20];

			p[0] = Connection.GetParameter
				("@PARTNER_DSC", Partner_Dsc);
			p[1] = Connection.GetParameter
				("@DELETE_FL", Delete_Fl);
			p[2] = Connection.GetParameter
				("@SCAC", Scac);
			p[3] = Connection.GetParameter
				("@CONTACT_NM", Contact_Nm);
			p[4] = Connection.GetParameter
				("@CONTACT_PHONE", Contact_Phone);
			p[5] = Connection.GetParameter
				("@OUTLOOK_NAME", Outlook_Name);
			p[6] = Connection.GetParameter
				("@CONTACT_EMAIL", Contact_Email);
			p[7] = Connection.GetParameter
				("@DEFAULT_FL", Default_Fl);
			p[8] = Connection.GetParameter
				("@EDI_INPUT_PATH", Edi_Input_Path);
			p[9] = Connection.GetParameter
				("@EDI_OUTPUT_PATH", Edi_Output_Path);
			p[10] = Connection.GetParameter
				("@EDI_REPORT_PATH", Edi_Report_Path);
			p[11] = Connection.GetParameter
				("@EDI_CONTROL_STD", Edi_Control_Std);
			p[12] = Connection.GetParameter
				("@EDI_CONTROL_VERSION", Edi_Control_Version);
			p[13] = Connection.GetParameter
				("@EDI_TEST", Edi_Test);
			p[14] = Connection.GetParameter
				("@EDI_VERSION", Edi_Version);
			p[15] = Connection.GetParameter
				("@EDI_PARTNER_XCHG_QUALIFIER", Edi_Partner_Xchg_Qualifier);
			p[16] = Connection.GetParameter
				("@EDI_PARTNER_XCHG_CD", Edi_Partner_Xchg_Cd);
			p[17] = Connection.GetParameter
				("@EDI_PARTNER_GS03", Edi_Partner_Gs03);
			p[18] = Connection.GetParameter
				("@EDI_ATTACHMENT_PATH", Edi_Attachment_Path);
			p[19] = Connection.GetParameter
				("@PARTNER_CD", Partner_Cd);

			const string sql = @"
				UPDATE R_TRADING_PARTNER SET
					PARTNER_DSC = @PARTNER_DSC,
					DELETE_FL = @DELETE_FL,
					SCAC = @SCAC,
					CONTACT_NM = @CONTACT_NM,
					CONTACT_PHONE = @CONTACT_PHONE,
					OUTLOOK_NAME = @OUTLOOK_NAME,
					CONTACT_EMAIL = @CONTACT_EMAIL,
					DEFAULT_FL = @DEFAULT_FL,
					EDI_INPUT_PATH = @EDI_INPUT_PATH,
					EDI_OUTPUT_PATH = @EDI_OUTPUT_PATH,
					EDI_REPORT_PATH = @EDI_REPORT_PATH,
					EDI_CONTROL_STD = @EDI_CONTROL_STD,
					EDI_CONTROL_VERSION = @EDI_CONTROL_VERSION,
					EDI_TEST = @EDI_TEST,
					EDI_VERSION = @EDI_VERSION,
					EDI_PARTNER_XCHG_QUALIFIER = @EDI_PARTNER_XCHG_QUALIFIER,
					EDI_PARTNER_XCHG_CD = @EDI_PARTNER_XCHG_CD,
					EDI_PARTNER_GS03 = @EDI_PARTNER_GS03,
					EDI_ATTACHMENT_PATH = @EDI_ATTACHMENT_PATH
				WHERE
					PARTNER_CD = @PARTNER_CD
				RETURNING
					
				INTO
					";
			int ret = Connection.RunSQL(sql, p);


			return ret;
		}
		public override int Delete()
		{
			DbParameter[] p = new DbParameter[1];

			p[0] = Connection.GetParameter
				("@PARTNER_CD", Partner_Cd);

			const string sql = @"
				DELETE FROM R_TRADING_PARTNER WHERE
				PARTNER_CD=@PARTNER_CD";
			return Connection.RunSQL(sql, p);
		}
		#endregion		// #region Insert, Update, Delete

		#region Conversion methods

		public override void LoadFromDataReader(DbDataReader dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataReader: DataReader parameter was null");

			Partner_Cd = ClsConvert.ToString(dr["PARTNER_CD"]);
			Partner_Dsc = ClsConvert.ToString(dr["PARTNER_DSC"]);
			Delete_Fl = ClsConvert.ToString(dr["DELETE_FL"]);
			Scac = ClsConvert.ToString(dr["SCAC"]);
			Contact_Nm = ClsConvert.ToString(dr["CONTACT_NM"]);
			Contact_Phone = ClsConvert.ToString(dr["CONTACT_PHONE"]);
			Outlook_Name = ClsConvert.ToString(dr["OUTLOOK_NAME"]);
			Contact_Email = ClsConvert.ToString(dr["CONTACT_EMAIL"]);
			Default_Fl = ClsConvert.ToString(dr["DEFAULT_FL"]);
			Edi_Input_Path = ClsConvert.ToString(dr["EDI_INPUT_PATH"]);
			Edi_Output_Path = ClsConvert.ToString(dr["EDI_OUTPUT_PATH"]);
			Edi_Report_Path = ClsConvert.ToString(dr["EDI_REPORT_PATH"]);
			Edi_Control_Std = ClsConvert.ToString(dr["EDI_CONTROL_STD"]);
			Edi_Control_Version = ClsConvert.ToString(dr["EDI_CONTROL_VERSION"]);
			Edi_Test = ClsConvert.ToString(dr["EDI_TEST"]);
			Edi_Version = ClsConvert.ToString(dr["EDI_VERSION"]);
			Edi_Partner_Xchg_Qualifier = ClsConvert.ToString(dr["EDI_PARTNER_XCHG_QUALIFIER"]);
			Edi_Partner_Xchg_Cd = ClsConvert.ToString(dr["EDI_PARTNER_XCHG_CD"]);
			Edi_Partner_Gs03 = ClsConvert.ToString(dr["EDI_PARTNER_GS03"]);
			Edi_Attachment_Path = ClsConvert.ToString(dr["EDI_ATTACHMENT_PATH"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Partner_Cd = ClsConvert.ToString(dr["PARTNER_CD", v]);
			Partner_Dsc = ClsConvert.ToString(dr["PARTNER_DSC", v]);
			Delete_Fl = ClsConvert.ToString(dr["DELETE_FL", v]);
			Scac = ClsConvert.ToString(dr["SCAC", v]);
			Contact_Nm = ClsConvert.ToString(dr["CONTACT_NM", v]);
			Contact_Phone = ClsConvert.ToString(dr["CONTACT_PHONE", v]);
			Outlook_Name = ClsConvert.ToString(dr["OUTLOOK_NAME", v]);
			Contact_Email = ClsConvert.ToString(dr["CONTACT_EMAIL", v]);
			Default_Fl = ClsConvert.ToString(dr["DEFAULT_FL", v]);
			Edi_Input_Path = ClsConvert.ToString(dr["EDI_INPUT_PATH", v]);
			Edi_Output_Path = ClsConvert.ToString(dr["EDI_OUTPUT_PATH", v]);
			Edi_Report_Path = ClsConvert.ToString(dr["EDI_REPORT_PATH", v]);
			Edi_Control_Std = ClsConvert.ToString(dr["EDI_CONTROL_STD", v]);
			Edi_Control_Version = ClsConvert.ToString(dr["EDI_CONTROL_VERSION", v]);
			Edi_Test = ClsConvert.ToString(dr["EDI_TEST", v]);
			Edi_Version = ClsConvert.ToString(dr["EDI_VERSION", v]);
			Edi_Partner_Xchg_Qualifier = ClsConvert.ToString(dr["EDI_PARTNER_XCHG_QUALIFIER", v]);
			Edi_Partner_Xchg_Cd = ClsConvert.ToString(dr["EDI_PARTNER_XCHG_CD", v]);
			Edi_Partner_Gs03 = ClsConvert.ToString(dr["EDI_PARTNER_GS03", v]);
			Edi_Attachment_Path = ClsConvert.ToString(dr["EDI_ATTACHMENT_PATH", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["PARTNER_CD"] = ClsConvert.ToDbObject(Partner_Cd);
			dr["PARTNER_DSC"] = ClsConvert.ToDbObject(Partner_Dsc);
			dr["DELETE_FL"] = ClsConvert.ToDbObject(Delete_Fl);
			dr["SCAC"] = ClsConvert.ToDbObject(Scac);
			dr["CONTACT_NM"] = ClsConvert.ToDbObject(Contact_Nm);
			dr["CONTACT_PHONE"] = ClsConvert.ToDbObject(Contact_Phone);
			dr["OUTLOOK_NAME"] = ClsConvert.ToDbObject(Outlook_Name);
			dr["CONTACT_EMAIL"] = ClsConvert.ToDbObject(Contact_Email);
			dr["DEFAULT_FL"] = ClsConvert.ToDbObject(Default_Fl);
			dr["EDI_INPUT_PATH"] = ClsConvert.ToDbObject(Edi_Input_Path);
			dr["EDI_OUTPUT_PATH"] = ClsConvert.ToDbObject(Edi_Output_Path);
			dr["EDI_REPORT_PATH"] = ClsConvert.ToDbObject(Edi_Report_Path);
			dr["EDI_CONTROL_STD"] = ClsConvert.ToDbObject(Edi_Control_Std);
			dr["EDI_CONTROL_VERSION"] = ClsConvert.ToDbObject(Edi_Control_Version);
			dr["EDI_TEST"] = ClsConvert.ToDbObject(Edi_Test);
			dr["EDI_VERSION"] = ClsConvert.ToDbObject(Edi_Version);
			dr["EDI_PARTNER_XCHG_QUALIFIER"] = ClsConvert.ToDbObject(Edi_Partner_Xchg_Qualifier);
			dr["EDI_PARTNER_XCHG_CD"] = ClsConvert.ToDbObject(Edi_Partner_Xchg_Cd);
			dr["EDI_PARTNER_GS03"] = ClsConvert.ToDbObject(Edi_Partner_Gs03);
			dr["EDI_ATTACHMENT_PATH"] = ClsConvert.ToDbObject(Edi_Attachment_Path);
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

		public static ClsTradingPartner GetUsingKey(string Partner_Cd)
		{
			object[] vals = new object[] {Partner_Cd};
			DataRow dr = Connection.GetDataRowUsingKey
				(TableName, GetPrimaryKeys(), vals);
			return ( dr == null ) ? null : new ClsTradingPartner(dr);
		}

		#endregion		// #region Static Methods
	}
}