using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsEdi300Hazard : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ArcSys"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "T_EDI300_HAZARD";
		public const int PrimaryKeyCount = 1;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] { "EDI300_HAZARD_ID" };
		}

		public const string SelectSQL = @"SELECT * FROM T_EDI300_HAZARD 
				INNER JOIN T_EDI301_CARGO
				ON T_EDI300_HAZARD.EDI300_CARGO_ID=T_EDI301_CARGO.EDI301_CARGO_ID ";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Create_UserMax = 30;
		public const int Modify_UserMax = 30;
		public const int Transmission_KeyMax = 50;
		public const int B102_Bkg_NoMax = 30;
		public const int Lx01_Item_NbrMax = 10;
		public const int H101_Haz_CdMax = 10;
		public const int H102_Haz_Class_CdMax = 10;
		public const int H103_Haz_Qual_CdMax = 10;
		public const int H104_Haz_DscMax = 50;
		public const int H105_Haz_ContactMax = 50;
		public const int H106_Un_Page_NbrMax = 10;
		public const int H107_FlashpointMax = 10;
		public const int H108_Meas_Basis_CdMax = 10;
		public const int H109_Danger_CdMax = 10;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected decimal? _Edi300_Hazard_ID;
		protected Int64? _Edi300_Cargo_ID;
		protected DateTime? _Create_Dt;
		protected string _Create_User;
		protected DateTime? _Modify_Dt;
		protected string _Modify_User;
		protected string _Transmission_Key;
		protected string _B102_Bkg_No;
		protected string _Lx01_Item_Nbr;
		protected string _H101_Haz_Cd;
		protected string _H102_Haz_Class_Cd;
		protected string _H103_Haz_Qual_Cd;
		protected string _H104_Haz_Dsc;
		protected string _H105_Haz_Contact;
		protected string _H106_Un_Page_Nbr;
		protected string _H107_Flashpoint;
		protected string _H108_Meas_Basis_Cd;
		protected string _H109_Danger_Cd;

		#endregion	// #region Column Fields

		#region Column Properties

		public decimal? Edi300_Hazard_ID
		{
			get { return _Edi300_Hazard_ID; }
			set
			{
				if( _Edi300_Hazard_ID == value ) return;
		
				_Edi300_Hazard_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Edi300_Hazard_ID");
			}
		}
		public Int64? Edi300_Cargo_ID
		{
			get { return _Edi300_Cargo_ID; }
			set
			{
				if( _Edi300_Cargo_ID == value ) return;
		
				_Edi300_Cargo_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Edi300_Cargo_ID");
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
		public string Transmission_Key
		{
			get { return _Transmission_Key; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Transmission_Key, val, false) == 0 ) return;
		
				if( val != null && val.Length > Transmission_KeyMax )
					_Transmission_Key = val.Substring(0, (int)Transmission_KeyMax);
				else
					_Transmission_Key = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Transmission_Key");
			}
		}
		public string B102_Bkg_No
		{
			get { return _B102_Bkg_No; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_B102_Bkg_No, val, false) == 0 ) return;
		
				if( val != null && val.Length > B102_Bkg_NoMax )
					_B102_Bkg_No = val.Substring(0, (int)B102_Bkg_NoMax);
				else
					_B102_Bkg_No = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("B102_Bkg_No");
			}
		}
		public string Lx01_Item_Nbr
		{
			get { return _Lx01_Item_Nbr; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Lx01_Item_Nbr, val, false) == 0 ) return;
		
				if( val != null && val.Length > Lx01_Item_NbrMax )
					_Lx01_Item_Nbr = val.Substring(0, (int)Lx01_Item_NbrMax);
				else
					_Lx01_Item_Nbr = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Lx01_Item_Nbr");
			}
		}
		public string H101_Haz_Cd
		{
			get { return _H101_Haz_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_H101_Haz_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > H101_Haz_CdMax )
					_H101_Haz_Cd = val.Substring(0, (int)H101_Haz_CdMax);
				else
					_H101_Haz_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("H101_Haz_Cd");
			}
		}
		public string H102_Haz_Class_Cd
		{
			get { return _H102_Haz_Class_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_H102_Haz_Class_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > H102_Haz_Class_CdMax )
					_H102_Haz_Class_Cd = val.Substring(0, (int)H102_Haz_Class_CdMax);
				else
					_H102_Haz_Class_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("H102_Haz_Class_Cd");
			}
		}
		public string H103_Haz_Qual_Cd
		{
			get { return _H103_Haz_Qual_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_H103_Haz_Qual_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > H103_Haz_Qual_CdMax )
					_H103_Haz_Qual_Cd = val.Substring(0, (int)H103_Haz_Qual_CdMax);
				else
					_H103_Haz_Qual_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("H103_Haz_Qual_Cd");
			}
		}
		public string H104_Haz_Dsc
		{
			get { return _H104_Haz_Dsc; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_H104_Haz_Dsc, val, false) == 0 ) return;
		
				if( val != null && val.Length > H104_Haz_DscMax )
					_H104_Haz_Dsc = val.Substring(0, (int)H104_Haz_DscMax);
				else
					_H104_Haz_Dsc = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("H104_Haz_Dsc");
			}
		}
		public string H105_Haz_Contact
		{
			get { return _H105_Haz_Contact; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_H105_Haz_Contact, val, false) == 0 ) return;
		
				if( val != null && val.Length > H105_Haz_ContactMax )
					_H105_Haz_Contact = val.Substring(0, (int)H105_Haz_ContactMax);
				else
					_H105_Haz_Contact = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("H105_Haz_Contact");
			}
		}
		public string H106_Un_Page_Nbr
		{
			get { return _H106_Un_Page_Nbr; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_H106_Un_Page_Nbr, val, false) == 0 ) return;
		
				if( val != null && val.Length > H106_Un_Page_NbrMax )
					_H106_Un_Page_Nbr = val.Substring(0, (int)H106_Un_Page_NbrMax);
				else
					_H106_Un_Page_Nbr = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("H106_Un_Page_Nbr");
			}
		}
		public string H107_Flashpoint
		{
			get { return _H107_Flashpoint; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_H107_Flashpoint, val, false) == 0 ) return;
		
				if( val != null && val.Length > H107_FlashpointMax )
					_H107_Flashpoint = val.Substring(0, (int)H107_FlashpointMax);
				else
					_H107_Flashpoint = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("H107_Flashpoint");
			}
		}
		public string H108_Meas_Basis_Cd
		{
			get { return _H108_Meas_Basis_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_H108_Meas_Basis_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > H108_Meas_Basis_CdMax )
					_H108_Meas_Basis_Cd = val.Substring(0, (int)H108_Meas_Basis_CdMax);
				else
					_H108_Meas_Basis_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("H108_Meas_Basis_Cd");
			}
		}
		public string H109_Danger_Cd
		{
			get { return _H109_Danger_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_H109_Danger_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > H109_Danger_CdMax )
					_H109_Danger_Cd = val.Substring(0, (int)H109_Danger_CdMax);
				else
					_H109_Danger_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("H109_Danger_Cd");
			}
		}

		#endregion	// #region Column Properties

		#region Foreign Key Fields



		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties



		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsEdi300Hazard() : base() {}
		public ClsEdi300Hazard(DataRow dr) : base(dr) {}
		public ClsEdi300Hazard(ClsEdi300Hazard src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Edi300_Hazard_ID = null;
			Edi300_Cargo_ID = null;
			Create_Dt = null;
			Create_User = null;
			Modify_Dt = null;
			Modify_User = null;
			Transmission_Key = null;
			B102_Bkg_No = null;
			Lx01_Item_Nbr = null;
			H101_Haz_Cd = null;
			H102_Haz_Class_Cd = null;
			H103_Haz_Qual_Cd = null;
			H104_Haz_Dsc = null;
			H105_Haz_Contact = null;
			H106_Un_Page_Nbr = null;
			H107_Flashpoint = null;
			H108_Meas_Basis_Cd = null;
			H109_Danger_Cd = null;
		}

		public void CopyFrom(ClsEdi300Hazard src)
		{
			Edi300_Hazard_ID = src._Edi300_Hazard_ID;
			Edi300_Cargo_ID = src._Edi300_Cargo_ID;
			Create_Dt = src._Create_Dt;
			Create_User = src._Create_User;
			Modify_Dt = src._Modify_Dt;
			Modify_User = src._Modify_User;
			Transmission_Key = src._Transmission_Key;
			B102_Bkg_No = src._B102_Bkg_No;
			Lx01_Item_Nbr = src._Lx01_Item_Nbr;
			H101_Haz_Cd = src._H101_Haz_Cd;
			H102_Haz_Class_Cd = src._H102_Haz_Class_Cd;
			H103_Haz_Qual_Cd = src._H103_Haz_Qual_Cd;
			H104_Haz_Dsc = src._H104_Haz_Dsc;
			H105_Haz_Contact = src._H105_Haz_Contact;
			H106_Un_Page_Nbr = src._H106_Un_Page_Nbr;
			H107_Flashpoint = src._H107_Flashpoint;
			H108_Meas_Basis_Cd = src._H108_Meas_Basis_Cd;
			H109_Danger_Cd = src._H109_Danger_Cd;
		}

		public override bool ReloadFromDB()
		{
			ClsEdi300Hazard tmp = ClsEdi300Hazard.GetUsingKey(Edi300_Hazard_ID.Value);
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

			DbParameter[] p = new DbParameter[18];

			p[0] = Connection.GetParameter
				("@EDI300_CARGO_ID", Edi300_Cargo_ID);
			p[1] = Connection.GetParameter
				("@TRANSMISSION_KEY", Transmission_Key);
			p[2] = Connection.GetParameter
				("@B102_BKG_NO", B102_Bkg_No);
			p[3] = Connection.GetParameter
				("@LX01_ITEM_NBR", Lx01_Item_Nbr);
			p[4] = Connection.GetParameter
				("@H101_HAZ_CD", H101_Haz_Cd);
			p[5] = Connection.GetParameter
				("@H102_HAZ_CLASS_CD", H102_Haz_Class_Cd);
			p[6] = Connection.GetParameter
				("@H103_HAZ_QUAL_CD", H103_Haz_Qual_Cd);
			p[7] = Connection.GetParameter
				("@H104_HAZ_DSC", H104_Haz_Dsc);
			p[8] = Connection.GetParameter
				("@H105_HAZ_CONTACT", H105_Haz_Contact);
			p[9] = Connection.GetParameter
				("@H106_UN_PAGE_NBR", H106_Un_Page_Nbr);
			p[10] = Connection.GetParameter
				("@H107_FLASHPOINT", H107_Flashpoint);
			p[11] = Connection.GetParameter
				("@H108_MEAS_BASIS_CD", H108_Meas_Basis_Cd);
			p[12] = Connection.GetParameter
				("@H109_DANGER_CD", H109_Danger_Cd);
			p[13] = Connection.GetParameter
				("@EDI300_HAZARD_ID", Edi300_Hazard_ID, ParameterDirection.Output, DbType.Decimal, 0);
			p[14] = Connection.GetParameter
				("@CREATE_DT", Create_Dt, ParameterDirection.Output, DbType.DateTime, 0);
			p[15] = Connection.GetParameter
				("@CREATE_USER", Create_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Create_UserMax);
			p[16] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.Output, DbType.DateTime, 0);
			p[17] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);

			const string sql = @"
				INSERT INTO T_EDI300_HAZARD
					(EDI300_HAZARD_ID, EDI300_CARGO_ID, TRANSMISSION_KEY,
					B102_BKG_NO, LX01_ITEM_NBR, H101_HAZ_CD,
					H102_HAZ_CLASS_CD, H103_HAZ_QUAL_CD, H104_HAZ_DSC,
					H105_HAZ_CONTACT, H106_UN_PAGE_NBR, H107_FLASHPOINT,
					H108_MEAS_BASIS_CD, H109_DANGER_CD)
				VALUES
					(EDI300_HAZARD_ID_SEQ.NEXTVAL, @EDI300_CARGO_ID, @TRANSMISSION_KEY,
					@B102_BKG_NO, @LX01_ITEM_NBR, @H101_HAZ_CD,
					@H102_HAZ_CLASS_CD, @H103_HAZ_QUAL_CD, @H104_HAZ_DSC,
					@H105_HAZ_CONTACT, @H106_UN_PAGE_NBR, @H107_FLASHPOINT,
					@H108_MEAS_BASIS_CD, @H109_DANGER_CD)
				RETURNING
					EDI300_HAZARD_ID, CREATE_DT, CREATE_USER,
					MODIFY_DT, MODIFY_USER
				INTO
					@EDI300_HAZARD_ID, @CREATE_DT, @CREATE_USER,
					@MODIFY_DT, @MODIFY_USER";
			int ret = Connection.RunSQL(sql, p);

			Edi300_Hazard_ID = ClsConvert.ToDecimalNullable(p[13].Value);
			Create_Dt = ClsConvert.ToDateTimeNullable(p[14].Value);
			Create_User = ClsConvert.ToString(p[15].Value);
			Modify_Dt = ClsConvert.ToDateTimeNullable(p[16].Value);
			Modify_User = ClsConvert.ToString(p[17].Value);
			return ret;
		}
		public override int Update()
		{
			DbParameter[] p = new DbParameter[16];

			p[0] = Connection.GetParameter
				("@EDI300_CARGO_ID", Edi300_Cargo_ID);
			p[1] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.InputOutput, DbType.DateTime, 0);
			p[2] = Connection.GetParameter
				("@TRANSMISSION_KEY", Transmission_Key);
			p[3] = Connection.GetParameter
				("@B102_BKG_NO", B102_Bkg_No);
			p[4] = Connection.GetParameter
				("@LX01_ITEM_NBR", Lx01_Item_Nbr);
			p[5] = Connection.GetParameter
				("@H101_HAZ_CD", H101_Haz_Cd);
			p[6] = Connection.GetParameter
				("@H102_HAZ_CLASS_CD", H102_Haz_Class_Cd);
			p[7] = Connection.GetParameter
				("@H103_HAZ_QUAL_CD", H103_Haz_Qual_Cd);
			p[8] = Connection.GetParameter
				("@H104_HAZ_DSC", H104_Haz_Dsc);
			p[9] = Connection.GetParameter
				("@H105_HAZ_CONTACT", H105_Haz_Contact);
			p[10] = Connection.GetParameter
				("@H106_UN_PAGE_NBR", H106_Un_Page_Nbr);
			p[11] = Connection.GetParameter
				("@H107_FLASHPOINT", H107_Flashpoint);
			p[12] = Connection.GetParameter
				("@H108_MEAS_BASIS_CD", H108_Meas_Basis_Cd);
			p[13] = Connection.GetParameter
				("@H109_DANGER_CD", H109_Danger_Cd);
			p[14] = Connection.GetParameter
				("@EDI300_HAZARD_ID", Edi300_Hazard_ID);
			p[15] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);

			const string sql = @"
				UPDATE T_EDI300_HAZARD SET
					EDI300_CARGO_ID = @EDI300_CARGO_ID,
					MODIFY_DT = @MODIFY_DT,
					TRANSMISSION_KEY = @TRANSMISSION_KEY,
					B102_BKG_NO = @B102_BKG_NO,
					LX01_ITEM_NBR = @LX01_ITEM_NBR,
					H101_HAZ_CD = @H101_HAZ_CD,
					H102_HAZ_CLASS_CD = @H102_HAZ_CLASS_CD,
					H103_HAZ_QUAL_CD = @H103_HAZ_QUAL_CD,
					H104_HAZ_DSC = @H104_HAZ_DSC,
					H105_HAZ_CONTACT = @H105_HAZ_CONTACT,
					H106_UN_PAGE_NBR = @H106_UN_PAGE_NBR,
					H107_FLASHPOINT = @H107_FLASHPOINT,
					H108_MEAS_BASIS_CD = @H108_MEAS_BASIS_CD,
					H109_DANGER_CD = @H109_DANGER_CD
				WHERE
					EDI300_HAZARD_ID = @EDI300_HAZARD_ID
				RETURNING
					MODIFY_DT, MODIFY_USER
				INTO
					@MODIFY_DT, @MODIFY_USER";
			int ret = Connection.RunSQL(sql, p);

			Modify_Dt = ClsConvert.ToDateTimeNullable(p[1].Value);
			Modify_User = ClsConvert.ToString(p[15].Value);
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

			Edi300_Hazard_ID = ClsConvert.ToDecimalNullable(dr["EDI300_HAZARD_ID"]);
			Edi300_Cargo_ID = ClsConvert.ToInt64Nullable(dr["EDI300_CARGO_ID"]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT"]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER"]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT"]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER"]);
			Transmission_Key = ClsConvert.ToString(dr["TRANSMISSION_KEY"]);
			B102_Bkg_No = ClsConvert.ToString(dr["B102_BKG_NO"]);
			Lx01_Item_Nbr = ClsConvert.ToString(dr["LX01_ITEM_NBR"]);
			H101_Haz_Cd = ClsConvert.ToString(dr["H101_HAZ_CD"]);
			H102_Haz_Class_Cd = ClsConvert.ToString(dr["H102_HAZ_CLASS_CD"]);
			H103_Haz_Qual_Cd = ClsConvert.ToString(dr["H103_HAZ_QUAL_CD"]);
			H104_Haz_Dsc = ClsConvert.ToString(dr["H104_HAZ_DSC"]);
			H105_Haz_Contact = ClsConvert.ToString(dr["H105_HAZ_CONTACT"]);
			H106_Un_Page_Nbr = ClsConvert.ToString(dr["H106_UN_PAGE_NBR"]);
			H107_Flashpoint = ClsConvert.ToString(dr["H107_FLASHPOINT"]);
			H108_Meas_Basis_Cd = ClsConvert.ToString(dr["H108_MEAS_BASIS_CD"]);
			H109_Danger_Cd = ClsConvert.ToString(dr["H109_DANGER_CD"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Edi300_Hazard_ID = ClsConvert.ToDecimalNullable(dr["EDI300_HAZARD_ID", v]);
			Edi300_Cargo_ID = ClsConvert.ToInt64Nullable(dr["EDI300_CARGO_ID", v]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT", v]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER", v]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT", v]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER", v]);
			Transmission_Key = ClsConvert.ToString(dr["TRANSMISSION_KEY", v]);
			B102_Bkg_No = ClsConvert.ToString(dr["B102_BKG_NO", v]);
			Lx01_Item_Nbr = ClsConvert.ToString(dr["LX01_ITEM_NBR", v]);
			H101_Haz_Cd = ClsConvert.ToString(dr["H101_HAZ_CD", v]);
			H102_Haz_Class_Cd = ClsConvert.ToString(dr["H102_HAZ_CLASS_CD", v]);
			H103_Haz_Qual_Cd = ClsConvert.ToString(dr["H103_HAZ_QUAL_CD", v]);
			H104_Haz_Dsc = ClsConvert.ToString(dr["H104_HAZ_DSC", v]);
			H105_Haz_Contact = ClsConvert.ToString(dr["H105_HAZ_CONTACT", v]);
			H106_Un_Page_Nbr = ClsConvert.ToString(dr["H106_UN_PAGE_NBR", v]);
			H107_Flashpoint = ClsConvert.ToString(dr["H107_FLASHPOINT", v]);
			H108_Meas_Basis_Cd = ClsConvert.ToString(dr["H108_MEAS_BASIS_CD", v]);
			H109_Danger_Cd = ClsConvert.ToString(dr["H109_DANGER_CD", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["EDI300_HAZARD_ID"] = ClsConvert.ToDbObject(Edi300_Hazard_ID);
			dr["EDI300_CARGO_ID"] = ClsConvert.ToDbObject(Edi300_Cargo_ID);
			dr["CREATE_DT"] = ClsConvert.ToDbObject(Create_Dt);
			dr["CREATE_USER"] = ClsConvert.ToDbObject(Create_User);
			dr["MODIFY_DT"] = ClsConvert.ToDbObject(Modify_Dt);
			dr["MODIFY_USER"] = ClsConvert.ToDbObject(Modify_User);
			dr["TRANSMISSION_KEY"] = ClsConvert.ToDbObject(Transmission_Key);
			dr["B102_BKG_NO"] = ClsConvert.ToDbObject(B102_Bkg_No);
			dr["LX01_ITEM_NBR"] = ClsConvert.ToDbObject(Lx01_Item_Nbr);
			dr["H101_HAZ_CD"] = ClsConvert.ToDbObject(H101_Haz_Cd);
			dr["H102_HAZ_CLASS_CD"] = ClsConvert.ToDbObject(H102_Haz_Class_Cd);
			dr["H103_HAZ_QUAL_CD"] = ClsConvert.ToDbObject(H103_Haz_Qual_Cd);
			dr["H104_HAZ_DSC"] = ClsConvert.ToDbObject(H104_Haz_Dsc);
			dr["H105_HAZ_CONTACT"] = ClsConvert.ToDbObject(H105_Haz_Contact);
			dr["H106_UN_PAGE_NBR"] = ClsConvert.ToDbObject(H106_Un_Page_Nbr);
			dr["H107_FLASHPOINT"] = ClsConvert.ToDbObject(H107_Flashpoint);
			dr["H108_MEAS_BASIS_CD"] = ClsConvert.ToDbObject(H108_Meas_Basis_Cd);
			dr["H109_DANGER_CD"] = ClsConvert.ToDbObject(H109_Danger_Cd);
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

		public static ClsEdi300Hazard GetUsingKey(decimal Edi300_Hazard_ID)
		{
			object[] vals = new object[] {Edi300_Hazard_ID};
			DataRow dr = Connection.GetDataRowUsingKey
				(TableName, GetPrimaryKeys(), vals);
			return ( dr == null ) ? null : new ClsEdi300Hazard(dr);
		}
		public static DataTable GetAll(Int64? Edi300_Cargo_ID)
		{
			List<DbParameter> lst = new List<DbParameter>();	
			StringBuilder sb = new StringBuilder();
		
			if( Edi300_Cargo_ID != null && Edi300_Cargo_ID > 0 )
			{
				lst.Add(Connection.GetParameter("@EDI300_CARGO_ID", Edi300_Cargo_ID));
				sb.Append(" WHERE T_EDI300_HAZARD.EDI300_CARGO_ID=@EDI300_CARGO_ID");
			}
			sb.Insert(0, SelectSQL);
			return Connection.GetDataTable(sb.ToString(), lst.ToArray());
		}
		#endregion		// #region Static Methods
	}
}