using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ACMS.Business
{
	public partial class ClsBookingParty : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ACMS"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "T_BOOKING_PARTY";
		public const int PrimaryKeyCount = 1;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] { "PARTY_ID" };
		}

		public const string SelectSQL = "SELECT * FROM T_BOOKING_PARTY";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Partner_CdMax = 15;
		public const int Partner_Request_CdMax = 30;
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

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected decimal? _Party_ID;
		protected string _Partner_Cd;
		protected string _Partner_Request_Cd;
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

		#endregion	// #region Column Fields

		#region Column Properties

		public decimal? Party_ID
		{
			get { return _Party_ID; }
			set
			{
				if( _Party_ID == value ) return;
		
				_Party_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Party_ID");
			}
		}
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
		public string Partner_Request_Cd
		{
			get { return _Partner_Request_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Partner_Request_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Partner_Request_CdMax )
					_Partner_Request_Cd = val.Substring(0, (int)Partner_Request_CdMax);
				else
					_Partner_Request_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Partner_Request_Cd");
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

		#endregion	// #region Column Properties

		#region Foreign Key Fields



		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties



		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsBookingParty() : base() {}
		public ClsBookingParty(DataRow dr) : base(dr) {}
		public ClsBookingParty(ClsBookingParty src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Party_ID = null;
			Partner_Cd = null;
			Partner_Request_Cd = null;
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
		}

		public void CopyFrom(ClsBookingParty src)
		{
			Party_ID = src._Party_ID;
			Partner_Cd = src._Partner_Cd;
			Partner_Request_Cd = src._Partner_Request_Cd;
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
		}

		public override bool ReloadFromDB()
		{
			ClsBookingParty tmp = ClsBookingParty.GetUsingKey(Party_ID.Value);
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

			DbParameter[] p = new DbParameter[15];

			p[0] = Connection.GetParameter
				("@PARTY_ID", Party_ID);
			p[1] = Connection.GetParameter
				("@PARTNER_CD", Partner_Cd);
			p[2] = Connection.GetParameter
				("@PARTNER_REQUEST_CD", Partner_Request_Cd);
			p[3] = Connection.GetParameter
				("@PARTY_TYPE_CD", Party_Type_Cd);
			p[4] = Connection.GetParameter
				("@PARTY_NAME", Party_Name);
			p[5] = Connection.GetParameter
				("@ADDRESS", Address);
			p[6] = Connection.GetParameter
				("@CITY", City);
			p[7] = Connection.GetParameter
				("@STATE", State);
			p[8] = Connection.GetParameter
				("@ZIP_CD", Zip_Cd);
			p[9] = Connection.GetParameter
				("@CONTACT_NAME", Contact_Name);
			p[10] = Connection.GetParameter
				("@VOICE_PHONE", Voice_Phone);
			p[11] = Connection.GetParameter
				("@FAX_PHONE", Fax_Phone);
			p[12] = Connection.GetParameter
				("@DODAAC", Dodaac);
			p[13] = Connection.GetParameter
				("@EMAIL", Email);
			p[14] = Connection.GetParameter
				("@COUNTRY_CD", Country_Cd);

			const string sql = @"
				INSERT INTO T_BOOKING_PARTY
					(PARTY_ID, PARTNER_CD, PARTNER_REQUEST_CD,
					PARTY_TYPE_CD, PARTY_NAME, ADDRESS,
					CITY, STATE, ZIP_CD,
					CONTACT_NAME, VOICE_PHONE, FAX_PHONE,
					DODAAC, EMAIL, COUNTRY_CD)
				VALUES
					(@PARTY_ID, @PARTNER_CD, @PARTNER_REQUEST_CD,
					@PARTY_TYPE_CD, @PARTY_NAME, @ADDRESS,
					@CITY, @STATE, @ZIP_CD,
					@CONTACT_NAME, @VOICE_PHONE, @FAX_PHONE,
					@DODAAC, @EMAIL, @COUNTRY_CD)
				RETURNING
					
				INTO
					";
			int ret = Connection.RunSQL(sql, p);


			return ret;
		}
		public override int Update()
		{
			DbParameter[] p = new DbParameter[15];

			p[0] = Connection.GetParameter
				("@PARTNER_CD", Partner_Cd);
			p[1] = Connection.GetParameter
				("@PARTNER_REQUEST_CD", Partner_Request_Cd);
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
				("@PARTY_ID", Party_ID);

			const string sql = @"
				UPDATE T_BOOKING_PARTY SET
					PARTNER_CD = @PARTNER_CD,
					PARTNER_REQUEST_CD = @PARTNER_REQUEST_CD,
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
					COUNTRY_CD = @COUNTRY_CD
				WHERE
					PARTY_ID = @PARTY_ID
				RETURNING
					
				INTO
					";
			int ret = Connection.RunSQL(sql, p);


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

			Party_ID = ClsConvert.ToDecimalNullable(dr["PARTY_ID"]);
			Partner_Cd = ClsConvert.ToString(dr["PARTNER_CD"]);
			Partner_Request_Cd = ClsConvert.ToString(dr["PARTNER_REQUEST_CD"]);
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
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Party_ID = ClsConvert.ToDecimalNullable(dr["PARTY_ID", v]);
			Partner_Cd = ClsConvert.ToString(dr["PARTNER_CD", v]);
			Partner_Request_Cd = ClsConvert.ToString(dr["PARTNER_REQUEST_CD", v]);
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
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["PARTY_ID"] = ClsConvert.ToDbObject(Party_ID);
			dr["PARTNER_CD"] = ClsConvert.ToDbObject(Partner_Cd);
			dr["PARTNER_REQUEST_CD"] = ClsConvert.ToDbObject(Partner_Request_Cd);
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

		public static ClsBookingParty GetUsingKey(decimal Party_ID)
		{
			object[] vals = new object[] {Party_ID};
			DataRow dr = Connection.GetDataRowUsingKey
				(TableName, GetPrimaryKeys(), vals);
			return ( dr == null ) ? null : new ClsBookingParty(dr);
		}

		#endregion		// #region Static Methods
	}
}