using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsEdi301Party : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ArcSys"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "T_EDI301_PARTY";
		public const int PrimaryKeyCount = 1;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] { "EDI301_PARTY_ID" };
		}

		public const string SelectSQL = @"SELECT * FROM T_EDI301_PARTY 
				INNER JOIN T_EDI301
				ON T_EDI301_PARTY.EDI301_ID=T_EDI301.EDI301_ID ";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Create_UserMax = 30;
		public const int Modify_UserMax = 30;
		public const int Party_Type_CdMax = 10;
		public const int Party_NameMax = 100;
		public const int AddressMax = 100;
		public const int CityMax = 50;
		public const int StateMax = 10;
		public const int Zip_CdMax = 10;
		public const int Contact_NameMax = 100;
		public const int Voice_PhoneMax = 50;
		public const int Fax_PhoneMax = 50;
		public const int DodaacMax = 200;
		public const int EmailMax = 200;
		public const int Country_CdMax = 3;
		public const int Party_NoMax = 20;
		public const int Party_Qualifier_CdMax = 20;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected decimal? _Edi301_Party_ID;
		protected Int64? _Edi301_ID;
		protected DateTime? _Create_Dt;
		protected string _Create_User;
		protected DateTime? _Modify_Dt;
		protected string _Modify_User;
		protected string _Party_Type_Cd;
		protected string _Party_Name;
		protected string _Address;
		protected string _City;
		protected string _State;
		protected string _Zip_Cd;
		protected string _Contact_Name;
		protected string _Voice_Phone;
		protected string _Fax_Phone;
		protected string _Dodaac;
		protected string _Email;
		protected string _Country_Cd;
		protected string _Party_No;
		protected string _Party_Qualifier_Cd;

		#endregion	// #region Column Fields

		#region Column Properties

		public decimal? Edi301_Party_ID
		{
			get { return _Edi301_Party_ID; }
			set
			{
				if( _Edi301_Party_ID == value ) return;
		
				_Edi301_Party_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Edi301_Party_ID");
			}
		}
		public Int64? Edi301_ID
		{
			get { return _Edi301_ID; }
			set
			{
				if( _Edi301_ID == value ) return;
		
				_Edi301_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Edi301_ID");
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
		public string Party_Type_Cd
		{
			get { return _Party_Type_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Party_Type_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Party_Type_CdMax )
					_Party_Type_Cd = val.Substring(0, (int)Party_Type_CdMax);
				else
					_Party_Type_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Party_Type_Cd");
			}
		}
		public string Party_Name
		{
			get { return _Party_Name; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Party_Name, val, false) == 0 ) return;
		
				if( val != null && val.Length > Party_NameMax )
					_Party_Name = val.Substring(0, (int)Party_NameMax);
				else
					_Party_Name = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Party_Name");
			}
		}
		public string Address
		{
			get { return _Address; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Address, val, false) == 0 ) return;
		
				if( val != null && val.Length > AddressMax )
					_Address = val.Substring(0, (int)AddressMax);
				else
					_Address = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Address");
			}
		}
		public string City
		{
			get { return _City; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_City, val, false) == 0 ) return;
		
				if( val != null && val.Length > CityMax )
					_City = val.Substring(0, (int)CityMax);
				else
					_City = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("City");
			}
		}
		public string State
		{
			get { return _State; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_State, val, false) == 0 ) return;
		
				if( val != null && val.Length > StateMax )
					_State = val.Substring(0, (int)StateMax);
				else
					_State = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("State");
			}
		}
		public string Zip_Cd
		{
			get { return _Zip_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Zip_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Zip_CdMax )
					_Zip_Cd = val.Substring(0, (int)Zip_CdMax);
				else
					_Zip_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Zip_Cd");
			}
		}
		public string Contact_Name
		{
			get { return _Contact_Name; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Contact_Name, val, false) == 0 ) return;
		
				if( val != null && val.Length > Contact_NameMax )
					_Contact_Name = val.Substring(0, (int)Contact_NameMax);
				else
					_Contact_Name = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Contact_Name");
			}
		}
		public string Voice_Phone
		{
			get { return _Voice_Phone; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Voice_Phone, val, false) == 0 ) return;
		
				if( val != null && val.Length > Voice_PhoneMax )
					_Voice_Phone = val.Substring(0, (int)Voice_PhoneMax);
				else
					_Voice_Phone = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Voice_Phone");
			}
		}
		public string Fax_Phone
		{
			get { return _Fax_Phone; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Fax_Phone, val, false) == 0 ) return;
		
				if( val != null && val.Length > Fax_PhoneMax )
					_Fax_Phone = val.Substring(0, (int)Fax_PhoneMax);
				else
					_Fax_Phone = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Fax_Phone");
			}
		}
		public string Dodaac
		{
			get { return _Dodaac; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Dodaac, val, false) == 0 ) return;
		
				if( val != null && val.Length > DodaacMax )
					_Dodaac = val.Substring(0, (int)DodaacMax);
				else
					_Dodaac = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Dodaac");
			}
		}
		public string Email
		{
			get { return _Email; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Email, val, false) == 0 ) return;
		
				if( val != null && val.Length > EmailMax )
					_Email = val.Substring(0, (int)EmailMax);
				else
					_Email = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Email");
			}
		}
		public string Country_Cd
		{
			get { return _Country_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Country_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Country_CdMax )
					_Country_Cd = val.Substring(0, (int)Country_CdMax);
				else
					_Country_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Country_Cd");
			}
		}
		public string Party_No
		{
			get { return _Party_No; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Party_No, val, false) == 0 ) return;
		
				if( val != null && val.Length > Party_NoMax )
					_Party_No = val.Substring(0, (int)Party_NoMax);
				else
					_Party_No = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Party_No");
			}
		}
		public string Party_Qualifier_Cd
		{
			get { return _Party_Qualifier_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Party_Qualifier_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Party_Qualifier_CdMax )
					_Party_Qualifier_Cd = val.Substring(0, (int)Party_Qualifier_CdMax);
				else
					_Party_Qualifier_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Party_Qualifier_Cd");
			}
		}

		#endregion	// #region Column Properties

		#region Foreign Key Fields

		protected ClsEdi301 _Edi301;

		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties

		public ClsEdi301 Edi301
		{
			get
			{
				if( Edi301_ID == null )
					_Edi301 = null;
				else if( _Edi301 == null ||
					_Edi301.Edi301_ID != Edi301_ID )
					_Edi301 = ClsEdi301.GetUsingKey(Edi301_ID.Value);
				return _Edi301;
			}
			set
			{
				if( _Edi301 == value ) return;
		
				_Edi301 = value;
			}
		}

		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsEdi301Party() : base() {}
		public ClsEdi301Party(DataRow dr) : base(dr) {}
		public ClsEdi301Party(ClsEdi301Party src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Edi301_Party_ID = null;
			Edi301_ID = null;
			Create_Dt = null;
			Create_User = null;
			Modify_Dt = null;
			Modify_User = null;
			Party_Type_Cd = null;
			Party_Name = null;
			Address = null;
			City = null;
			State = null;
			Zip_Cd = null;
			Contact_Name = null;
			Voice_Phone = null;
			Fax_Phone = null;
			Dodaac = null;
			Email = null;
			Country_Cd = null;
			Party_No = null;
			Party_Qualifier_Cd = null;
		}

		public void CopyFrom(ClsEdi301Party src)
		{
			Edi301_Party_ID = src._Edi301_Party_ID;
			Edi301_ID = src._Edi301_ID;
			Create_Dt = src._Create_Dt;
			Create_User = src._Create_User;
			Modify_Dt = src._Modify_Dt;
			Modify_User = src._Modify_User;
			Party_Type_Cd = src._Party_Type_Cd;
			Party_Name = src._Party_Name;
			Address = src._Address;
			City = src._City;
			State = src._State;
			Zip_Cd = src._Zip_Cd;
			Contact_Name = src._Contact_Name;
			Voice_Phone = src._Voice_Phone;
			Fax_Phone = src._Fax_Phone;
			Dodaac = src._Dodaac;
			Email = src._Email;
			Country_Cd = src._Country_Cd;
			Party_No = src._Party_No;
			Party_Qualifier_Cd = src._Party_Qualifier_Cd;
		}

		public override bool ReloadFromDB()
		{
			ClsEdi301Party tmp = ClsEdi301Party.GetUsingKey(Edi301_Party_ID.Value);
			if( tmp != null ) CopyFrom(tmp);

			ResetFKs();
			OnReload();

			return ( tmp != null );
		}

		public override void ResetFKs()
		{
			_Edi301 = null;
		}
		#endregion		// #region Init methods

		#region Insert, Update, Delete

		public override int Insert()
		{

			DbParameter[] p = new DbParameter[20];

			p[0] = Connection.GetParameter
				("@EDI301_ID", Edi301_ID);
			p[1] = Connection.GetParameter
				("@PARTY_TYPE_CD", Party_Type_Cd);
			p[2] = Connection.GetParameter
				("@PARTY_NAME", Party_Name);
			p[3] = Connection.GetParameter
				("@ADDRESS", Address);
			p[4] = Connection.GetParameter
				("@CITY", City);
			p[5] = Connection.GetParameter
				("@STATE", State);
			p[6] = Connection.GetParameter
				("@ZIP_CD", Zip_Cd);
			p[7] = Connection.GetParameter
				("@CONTACT_NAME", Contact_Name);
			p[8] = Connection.GetParameter
				("@VOICE_PHONE", Voice_Phone);
			p[9] = Connection.GetParameter
				("@FAX_PHONE", Fax_Phone);
			p[10] = Connection.GetParameter
				("@DODAAC", Dodaac);
			p[11] = Connection.GetParameter
				("@EMAIL", Email);
			p[12] = Connection.GetParameter
				("@COUNTRY_CD", Country_Cd);
			p[13] = Connection.GetParameter
				("@PARTY_NO", Party_No);
			p[14] = Connection.GetParameter
				("@PARTY_QUALIFIER_CD", Party_Qualifier_Cd);
			p[15] = Connection.GetParameter
				("@EDI301_PARTY_ID", Edi301_Party_ID, ParameterDirection.Output, DbType.Decimal, 0);
			p[16] = Connection.GetParameter
				("@CREATE_DT", Create_Dt, ParameterDirection.Output, DbType.DateTime, 0);
			p[17] = Connection.GetParameter
				("@CREATE_USER", Create_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Create_UserMax);
			p[18] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.Output, DbType.DateTime, 0);
			p[19] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);

			const string sql = @"
				INSERT INTO T_EDI301_PARTY
					(EDI301_PARTY_ID, EDI301_ID, PARTY_TYPE_CD,
					PARTY_NAME, ADDRESS, CITY,
					STATE, ZIP_CD, CONTACT_NAME,
					VOICE_PHONE, FAX_PHONE, DODAAC,
					EMAIL, COUNTRY_CD, PARTY_NO,
					PARTY_QUALIFIER_CD)
				VALUES
					(EDI301_PARTY_ID_SEQ.NEXTVAL, @EDI301_ID, @PARTY_TYPE_CD,
					@PARTY_NAME, @ADDRESS, @CITY,
					@STATE, @ZIP_CD, @CONTACT_NAME,
					@VOICE_PHONE, @FAX_PHONE, @DODAAC,
					@EMAIL, @COUNTRY_CD, @PARTY_NO,
					@PARTY_QUALIFIER_CD)
				RETURNING
					EDI301_PARTY_ID, CREATE_DT, CREATE_USER,
					MODIFY_DT, MODIFY_USER
				INTO
					@EDI301_PARTY_ID, @CREATE_DT, @CREATE_USER,
					@MODIFY_DT, @MODIFY_USER";
			int ret = Connection.RunSQL(sql, p);

			Edi301_Party_ID = ClsConvert.ToDecimalNullable(p[15].Value);
			Create_Dt = ClsConvert.ToDateTimeNullable(p[16].Value);
			Create_User = ClsConvert.ToString(p[17].Value);
			Modify_Dt = ClsConvert.ToDateTimeNullable(p[18].Value);
			Modify_User = ClsConvert.ToString(p[19].Value);
			return ret;
		}
		public override int Update()
		{
			DbParameter[] p = new DbParameter[18];

			p[0] = Connection.GetParameter
				("@EDI301_ID", Edi301_ID);
			p[1] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.InputOutput, DbType.DateTime, 0);
			p[2] = Connection.GetParameter
				("@PARTY_TYPE_CD", Party_Type_Cd);
			p[3] = Connection.GetParameter
				("@PARTY_NAME", Party_Name);
			p[4] = Connection.GetParameter
				("@ADDRESS", Address);
			p[5] = Connection.GetParameter
				("@CITY", City);
			p[6] = Connection.GetParameter
				("@STATE", State);
			p[7] = Connection.GetParameter
				("@ZIP_CD", Zip_Cd);
			p[8] = Connection.GetParameter
				("@CONTACT_NAME", Contact_Name);
			p[9] = Connection.GetParameter
				("@VOICE_PHONE", Voice_Phone);
			p[10] = Connection.GetParameter
				("@FAX_PHONE", Fax_Phone);
			p[11] = Connection.GetParameter
				("@DODAAC", Dodaac);
			p[12] = Connection.GetParameter
				("@EMAIL", Email);
			p[13] = Connection.GetParameter
				("@COUNTRY_CD", Country_Cd);
			p[14] = Connection.GetParameter
				("@PARTY_NO", Party_No);
			p[15] = Connection.GetParameter
				("@PARTY_QUALIFIER_CD", Party_Qualifier_Cd);
			p[16] = Connection.GetParameter
				("@EDI301_PARTY_ID", Edi301_Party_ID);
			p[17] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);

			const string sql = @"
				UPDATE T_EDI301_PARTY SET
					EDI301_ID = @EDI301_ID,
					MODIFY_DT = @MODIFY_DT,
					PARTY_TYPE_CD = @PARTY_TYPE_CD,
					PARTY_NAME = @PARTY_NAME,
					ADDRESS = @ADDRESS,
					CITY = @CITY,
					STATE = @STATE,
					ZIP_CD = @ZIP_CD,
					CONTACT_NAME = @CONTACT_NAME,
					VOICE_PHONE = @VOICE_PHONE,
					FAX_PHONE = @FAX_PHONE,
					DODAAC = @DODAAC,
					EMAIL = @EMAIL,
					COUNTRY_CD = @COUNTRY_CD,
					PARTY_NO = @PARTY_NO,
					PARTY_QUALIFIER_CD = @PARTY_QUALIFIER_CD
				WHERE
					EDI301_PARTY_ID = @EDI301_PARTY_ID
				RETURNING
					MODIFY_DT, MODIFY_USER
				INTO
					@MODIFY_DT, @MODIFY_USER";
			int ret = Connection.RunSQL(sql, p);

			Modify_Dt = ClsConvert.ToDateTimeNullable(p[1].Value);
			Modify_User = ClsConvert.ToString(p[17].Value);
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

			Edi301_Party_ID = ClsConvert.ToDecimalNullable(dr["EDI301_PARTY_ID"]);
			Edi301_ID = ClsConvert.ToInt64Nullable(dr["EDI301_ID"]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT"]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER"]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT"]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER"]);
			Party_Type_Cd = ClsConvert.ToString(dr["PARTY_TYPE_CD"]);
			Party_Name = ClsConvert.ToString(dr["PARTY_NAME"]);
			Address = ClsConvert.ToString(dr["ADDRESS"]);
			City = ClsConvert.ToString(dr["CITY"]);
			State = ClsConvert.ToString(dr["STATE"]);
			Zip_Cd = ClsConvert.ToString(dr["ZIP_CD"]);
			Contact_Name = ClsConvert.ToString(dr["CONTACT_NAME"]);
			Voice_Phone = ClsConvert.ToString(dr["VOICE_PHONE"]);
			Fax_Phone = ClsConvert.ToString(dr["FAX_PHONE"]);
			Dodaac = ClsConvert.ToString(dr["DODAAC"]);
			Email = ClsConvert.ToString(dr["EMAIL"]);
			Country_Cd = ClsConvert.ToString(dr["COUNTRY_CD"]);
			Party_No = ClsConvert.ToString(dr["PARTY_NO"]);
			Party_Qualifier_Cd = ClsConvert.ToString(dr["PARTY_QUALIFIER_CD"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Edi301_Party_ID = ClsConvert.ToDecimalNullable(dr["EDI301_PARTY_ID", v]);
			Edi301_ID = ClsConvert.ToInt64Nullable(dr["EDI301_ID", v]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT", v]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER", v]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT", v]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER", v]);
			Party_Type_Cd = ClsConvert.ToString(dr["PARTY_TYPE_CD", v]);
			Party_Name = ClsConvert.ToString(dr["PARTY_NAME", v]);
			Address = ClsConvert.ToString(dr["ADDRESS", v]);
			City = ClsConvert.ToString(dr["CITY", v]);
			State = ClsConvert.ToString(dr["STATE", v]);
			Zip_Cd = ClsConvert.ToString(dr["ZIP_CD", v]);
			Contact_Name = ClsConvert.ToString(dr["CONTACT_NAME", v]);
			Voice_Phone = ClsConvert.ToString(dr["VOICE_PHONE", v]);
			Fax_Phone = ClsConvert.ToString(dr["FAX_PHONE", v]);
			Dodaac = ClsConvert.ToString(dr["DODAAC", v]);
			Email = ClsConvert.ToString(dr["EMAIL", v]);
			Country_Cd = ClsConvert.ToString(dr["COUNTRY_CD", v]);
			Party_No = ClsConvert.ToString(dr["PARTY_NO", v]);
			Party_Qualifier_Cd = ClsConvert.ToString(dr["PARTY_QUALIFIER_CD", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["EDI301_PARTY_ID"] = ClsConvert.ToDbObject(Edi301_Party_ID);
			dr["EDI301_ID"] = ClsConvert.ToDbObject(Edi301_ID);
			dr["CREATE_DT"] = ClsConvert.ToDbObject(Create_Dt);
			dr["CREATE_USER"] = ClsConvert.ToDbObject(Create_User);
			dr["MODIFY_DT"] = ClsConvert.ToDbObject(Modify_Dt);
			dr["MODIFY_USER"] = ClsConvert.ToDbObject(Modify_User);
			dr["PARTY_TYPE_CD"] = ClsConvert.ToDbObject(Party_Type_Cd);
			dr["PARTY_NAME"] = ClsConvert.ToDbObject(Party_Name);
			dr["ADDRESS"] = ClsConvert.ToDbObject(Address);
			dr["CITY"] = ClsConvert.ToDbObject(City);
			dr["STATE"] = ClsConvert.ToDbObject(State);
			dr["ZIP_CD"] = ClsConvert.ToDbObject(Zip_Cd);
			dr["CONTACT_NAME"] = ClsConvert.ToDbObject(Contact_Name);
			dr["VOICE_PHONE"] = ClsConvert.ToDbObject(Voice_Phone);
			dr["FAX_PHONE"] = ClsConvert.ToDbObject(Fax_Phone);
			dr["DODAAC"] = ClsConvert.ToDbObject(Dodaac);
			dr["EMAIL"] = ClsConvert.ToDbObject(Email);
			dr["COUNTRY_CD"] = ClsConvert.ToDbObject(Country_Cd);
			dr["PARTY_NO"] = ClsConvert.ToDbObject(Party_No);
			dr["PARTY_QUALIFIER_CD"] = ClsConvert.ToDbObject(Party_Qualifier_Cd);
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

		public static ClsEdi301Party GetUsingKey(decimal Edi301_Party_ID)
		{
			object[] vals = new object[] {Edi301_Party_ID};
			DataRow dr = Connection.GetDataRowUsingKey
				(TableName, GetPrimaryKeys(), vals);
			return ( dr == null ) ? null : new ClsEdi301Party(dr);
		}
		public static DataTable GetAll(Int64? Edi301_ID)
		{
			List<DbParameter> lst = new List<DbParameter>();	
			StringBuilder sb = new StringBuilder();
		
			if( Edi301_ID != null && Edi301_ID > 0 )
			{
				lst.Add(Connection.GetParameter("@EDI301_ID", Edi301_ID));
				sb.Append(" WHERE T_EDI301_PARTY.EDI301_ID=@EDI301_ID");
			}
			sb.Insert(0, SelectSQL);
			return Connection.GetDataTable(sb.ToString(), lst.ToArray());
		}
		#endregion		// #region Static Methods
	}
}