using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsVwArcBolContact : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["OCEAN"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "vw_arc_bol_contact";
		public const int PrimaryKeyCount = 0;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] {  };
		}

		public const string SelectSQL = "SELECT * FROM vw_arc_bol_contact";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Bol_NoMax = 50;
		public const int Booking_NoMax = 50;
		public const int TypenameMax = 50;
		public const int CompanynameMax = 50;
		public const int FullnameMax = 50;
		public const int FullnamedetailsMax = 50;
		public const int PhonedeskMax = 30;
		public const int PhonemobileMax = 30;
		public const int EmailaddressMax = 50;
		public const int DepartmentofdefenseactivityaddresscodeMax = 20;
		public const int FaxMax = 30;
		public const int RemarksMax = 500;
		public const int Addressline1Max = 50;
		public const int Addressline2Max = 50;
		public const int Addressline3Max = 50;
		public const int CityMax = 30;
		public const int StateMax = 30;
		public const int ZipcodeMax = 12;
		public const int NameMax = 50;
		public const int DescriptionMax = 100;
		public const int Iso2codeMax = 2;
		public const int Iso3codeMax = 3;
		public const int Iso5codeMax = 5;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected string _Bol_No;
		protected string _Booking_No;
		protected Int32? _Typeid;
		protected string _Typename;
		protected string _Companyname;
		protected string _Fullname;
		protected string _Fullnamedetails;
		protected string _Phonedesk;
		protected string _Phonemobile;
		protected string _Emailaddress;
		protected string _Departmentofdefenseactivityaddresscode;
		protected string _Fax;
		protected string _Remarks;
		protected Int32? _Addressid;
		protected string _Addressline1;
		protected string _Addressline2;
		protected string _Addressline3;
		protected string _City;
		protected string _State;
		protected string _Zipcode;
		protected Int32? _Countryid;
		protected string _Name;
		protected string _Description;
		protected string _Iso2code;
		protected string _Iso3code;
		protected string _Iso5code;

		#endregion	// #region Column Fields

		#region Column Properties

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
		public string Booking_No
		{
			get { return _Booking_No; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Booking_No, val, false) == 0 ) return;
		
				if( val != null && val.Length > Booking_NoMax )
					_Booking_No = val.Substring(0, (int)Booking_NoMax);
				else
					_Booking_No = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Booking_No");
			}
		}
		public Int32? Typeid
		{
			get { return _Typeid; }
			set
			{
				if( _Typeid == value ) return;
		
				_Typeid = value;
				_IsDirty = true;
				NotifyPropertyChanged("Typeid");
			}
		}
		public string Typename
		{
			get { return _Typename; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Typename, val, false) == 0 ) return;
		
				if( val != null && val.Length > TypenameMax )
					_Typename = val.Substring(0, (int)TypenameMax);
				else
					_Typename = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Typename");
			}
		}
		public string Companyname
		{
			get { return _Companyname; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Companyname, val, false) == 0 ) return;
		
				if( val != null && val.Length > CompanynameMax )
					_Companyname = val.Substring(0, (int)CompanynameMax);
				else
					_Companyname = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Companyname");
			}
		}
		public string Fullname
		{
			get { return _Fullname; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Fullname, val, false) == 0 ) return;
		
				if( val != null && val.Length > FullnameMax )
					_Fullname = val.Substring(0, (int)FullnameMax);
				else
					_Fullname = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Fullname");
			}
		}
		public string Fullnamedetails
		{
			get { return _Fullnamedetails; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Fullnamedetails, val, false) == 0 ) return;
		
				if( val != null && val.Length > FullnamedetailsMax )
					_Fullnamedetails = val.Substring(0, (int)FullnamedetailsMax);
				else
					_Fullnamedetails = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Fullnamedetails");
			}
		}
		public string Phonedesk
		{
			get { return _Phonedesk; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Phonedesk, val, false) == 0 ) return;
		
				if( val != null && val.Length > PhonedeskMax )
					_Phonedesk = val.Substring(0, (int)PhonedeskMax);
				else
					_Phonedesk = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Phonedesk");
			}
		}
		public string Phonemobile
		{
			get { return _Phonemobile; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Phonemobile, val, false) == 0 ) return;
		
				if( val != null && val.Length > PhonemobileMax )
					_Phonemobile = val.Substring(0, (int)PhonemobileMax);
				else
					_Phonemobile = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Phonemobile");
			}
		}
		public string Emailaddress
		{
			get { return _Emailaddress; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Emailaddress, val, false) == 0 ) return;
		
				if( val != null && val.Length > EmailaddressMax )
					_Emailaddress = val.Substring(0, (int)EmailaddressMax);
				else
					_Emailaddress = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Emailaddress");
			}
		}
		public string Departmentofdefenseactivityaddresscode
		{
			get { return _Departmentofdefenseactivityaddresscode; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Departmentofdefenseactivityaddresscode, val, false) == 0 ) return;
		
				if( val != null && val.Length > DepartmentofdefenseactivityaddresscodeMax )
					_Departmentofdefenseactivityaddresscode = val.Substring(0, (int)DepartmentofdefenseactivityaddresscodeMax);
				else
					_Departmentofdefenseactivityaddresscode = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Departmentofdefenseactivityaddresscode");
			}
		}
		public string Fax
		{
			get { return _Fax; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Fax, val, false) == 0 ) return;
		
				if( val != null && val.Length > FaxMax )
					_Fax = val.Substring(0, (int)FaxMax);
				else
					_Fax = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Fax");
			}
		}
		public string Remarks
		{
			get { return _Remarks; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Remarks, val, false) == 0 ) return;
		
				if( val != null && val.Length > RemarksMax )
					_Remarks = val.Substring(0, (int)RemarksMax);
				else
					_Remarks = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Remarks");
			}
		}
		public Int32? Addressid
		{
			get { return _Addressid; }
			set
			{
				if( _Addressid == value ) return;
		
				_Addressid = value;
				_IsDirty = true;
				NotifyPropertyChanged("Addressid");
			}
		}
		public string Addressline1
		{
			get { return _Addressline1; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Addressline1, val, false) == 0 ) return;
		
				if( val != null && val.Length > Addressline1Max )
					_Addressline1 = val.Substring(0, (int)Addressline1Max);
				else
					_Addressline1 = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Addressline1");
			}
		}
		public string Addressline2
		{
			get { return _Addressline2; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Addressline2, val, false) == 0 ) return;
		
				if( val != null && val.Length > Addressline2Max )
					_Addressline2 = val.Substring(0, (int)Addressline2Max);
				else
					_Addressline2 = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Addressline2");
			}
		}
		public string Addressline3
		{
			get { return _Addressline3; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Addressline3, val, false) == 0 ) return;
		
				if( val != null && val.Length > Addressline3Max )
					_Addressline3 = val.Substring(0, (int)Addressline3Max);
				else
					_Addressline3 = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Addressline3");
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
		public string Zipcode
		{
			get { return _Zipcode; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Zipcode, val, false) == 0 ) return;
		
				if( val != null && val.Length > ZipcodeMax )
					_Zipcode = val.Substring(0, (int)ZipcodeMax);
				else
					_Zipcode = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Zipcode");
			}
		}
		public Int32? Countryid
		{
			get { return _Countryid; }
			set
			{
				if( _Countryid == value ) return;
		
				_Countryid = value;
				_IsDirty = true;
				NotifyPropertyChanged("Countryid");
			}
		}
		public string Name
		{
			get { return _Name; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Name, val, false) == 0 ) return;
		
				if( val != null && val.Length > NameMax )
					_Name = val.Substring(0, (int)NameMax);
				else
					_Name = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Name");
			}
		}
		public string Description
		{
			get { return _Description; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Description, val, false) == 0 ) return;
		
				if( val != null && val.Length > DescriptionMax )
					_Description = val.Substring(0, (int)DescriptionMax);
				else
					_Description = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Description");
			}
		}
		public string Iso2code
		{
			get { return _Iso2code; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Iso2code, val, false) == 0 ) return;
		
				if( val != null && val.Length > Iso2codeMax )
					_Iso2code = val.Substring(0, (int)Iso2codeMax);
				else
					_Iso2code = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Iso2code");
			}
		}
		public string Iso3code
		{
			get { return _Iso3code; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Iso3code, val, false) == 0 ) return;
		
				if( val != null && val.Length > Iso3codeMax )
					_Iso3code = val.Substring(0, (int)Iso3codeMax);
				else
					_Iso3code = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Iso3code");
			}
		}
		public string Iso5code
		{
			get { return _Iso5code; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Iso5code, val, false) == 0 ) return;
		
				if( val != null && val.Length > Iso5codeMax )
					_Iso5code = val.Substring(0, (int)Iso5codeMax);
				else
					_Iso5code = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Iso5code");
			}
		}

		#endregion	// #region Column Properties

		#region Foreign Key Fields



		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties



		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsVwArcBolContact() : base() {}
		public ClsVwArcBolContact(DataRow dr) : base(dr) {}
		public ClsVwArcBolContact(ClsVwArcBolContact src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Bol_No = null;
			Booking_No = null;
			Typeid = null;
			Typename = null;
			Companyname = null;
			Fullname = null;
			Fullnamedetails = null;
			Phonedesk = null;
			Phonemobile = null;
			Emailaddress = null;
			Departmentofdefenseactivityaddresscode = null;
			Fax = null;
			Remarks = null;
			Addressid = null;
			Addressline1 = null;
			Addressline2 = null;
			Addressline3 = null;
			City = null;
			State = null;
			Zipcode = null;
			Countryid = null;
			Name = null;
			Description = null;
			Iso2code = null;
			Iso3code = null;
			Iso5code = null;
		}

		public void CopyFrom(ClsVwArcBolContact src)
		{
			Bol_No = src._Bol_No;
			Booking_No = src._Booking_No;
			Typeid = src._Typeid;
			Typename = src._Typename;
			Companyname = src._Companyname;
			Fullname = src._Fullname;
			Fullnamedetails = src._Fullnamedetails;
			Phonedesk = src._Phonedesk;
			Phonemobile = src._Phonemobile;
			Emailaddress = src._Emailaddress;
			Departmentofdefenseactivityaddresscode = src._Departmentofdefenseactivityaddresscode;
			Fax = src._Fax;
			Remarks = src._Remarks;
			Addressid = src._Addressid;
			Addressline1 = src._Addressline1;
			Addressline2 = src._Addressline2;
			Addressline3 = src._Addressline3;
			City = src._City;
			State = src._State;
			Zipcode = src._Zipcode;
			Countryid = src._Countryid;
			Name = src._Name;
			Description = src._Description;
			Iso2code = src._Iso2code;
			Iso3code = src._Iso3code;
			Iso5code = src._Iso5code;
		}

		public override bool ReloadFromDB()
		{
			ClsVwArcBolContact tmp = null;	//No primary key can't refresh;
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

			DbParameter[] p = new DbParameter[26];

			p[0] = Connection.GetParameter
				("@Bol_No", Bol_No);
			p[1] = Connection.GetParameter
				("@Booking_no", Booking_No);
			p[2] = Connection.GetParameter
				("@TypeId", Typeid);
			p[3] = Connection.GetParameter
				("@TypeName", Typename);
			p[4] = Connection.GetParameter
				("@CompanyName", Companyname);
			p[5] = Connection.GetParameter
				("@FullName", Fullname);
			p[6] = Connection.GetParameter
				("@FullNameDetails", Fullnamedetails);
			p[7] = Connection.GetParameter
				("@PhoneDesk", Phonedesk);
			p[8] = Connection.GetParameter
				("@PhoneMobile", Phonemobile);
			p[9] = Connection.GetParameter
				("@EmailAddress", Emailaddress);
			p[10] = Connection.GetParameter
				("@DepartmentOfDefenseActivityAddressCode", Departmentofdefenseactivityaddresscode);
			p[11] = Connection.GetParameter
				("@Fax", Fax);
			p[12] = Connection.GetParameter
				("@Remarks", Remarks);
			p[13] = Connection.GetParameter
				("@AddressId", Addressid);
			p[14] = Connection.GetParameter
				("@AddressLine1", Addressline1);
			p[15] = Connection.GetParameter
				("@AddressLine2", Addressline2);
			p[16] = Connection.GetParameter
				("@AddressLine3", Addressline3);
			p[17] = Connection.GetParameter
				("@City", City);
			p[18] = Connection.GetParameter
				("@State", State);
			p[19] = Connection.GetParameter
				("@ZipCode", Zipcode);
			p[20] = Connection.GetParameter
				("@CountryId", Countryid);
			p[21] = Connection.GetParameter
				("@Name", Name);
			p[22] = Connection.GetParameter
				("@Description", Description);
			p[23] = Connection.GetParameter
				("@Iso2Code", Iso2code);
			p[24] = Connection.GetParameter
				("@Iso3Code", Iso3code);
			p[25] = Connection.GetParameter
				("@Iso5Code", Iso5code);

			const string sql = @"INSERT INTO vw_arc_bol_contact VALUES
				(@Bol_No,@Booking_no,@TypeId
				,@TypeName,@CompanyName,@FullName
				,@FullNameDetails,@PhoneDesk,@PhoneMobile
				,@EmailAddress,@DepartmentOfDefenseActivityAddressCode,@Fax
				,@Remarks,@AddressId,@AddressLine1
				,@AddressLine2,@AddressLine3,@City
				,@State,@ZipCode,@CountryId
				,@Name,@Description,@Iso2Code
				,@Iso3Code,@Iso5Code)";
			int ret = Connection.RunSQL(sql, p);


			return ret;
		}
		public override int Update()
		{
			DbParameter[] p = new DbParameter[0];

			if( p.Length == 0 )
				throw new Exception
					("Cannot update table because there is no primary key");

			return -1;

__cs__PostUpdate
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

			Bol_No = ClsConvert.ToString(dr["Bol_No"]);
			Booking_No = ClsConvert.ToString(dr["Booking_no"]);
			Typeid = ClsConvert.ToInt32Nullable(dr["TypeId"]);
			Typename = ClsConvert.ToString(dr["TypeName"]);
			Companyname = ClsConvert.ToString(dr["CompanyName"]);
			Fullname = ClsConvert.ToString(dr["FullName"]);
			Fullnamedetails = ClsConvert.ToString(dr["FullNameDetails"]);
			Phonedesk = ClsConvert.ToString(dr["PhoneDesk"]);
			Phonemobile = ClsConvert.ToString(dr["PhoneMobile"]);
			Emailaddress = ClsConvert.ToString(dr["EmailAddress"]);
			Departmentofdefenseactivityaddresscode = ClsConvert.ToString(dr["DepartmentOfDefenseActivityAddressCode"]);
			Fax = ClsConvert.ToString(dr["Fax"]);
			Remarks = ClsConvert.ToString(dr["Remarks"]);
			Addressid = ClsConvert.ToInt32Nullable(dr["AddressId"]);
			Addressline1 = ClsConvert.ToString(dr["AddressLine1"]);
			Addressline2 = ClsConvert.ToString(dr["AddressLine2"]);
			Addressline3 = ClsConvert.ToString(dr["AddressLine3"]);
			City = ClsConvert.ToString(dr["City"]);
			State = ClsConvert.ToString(dr["State"]);
			Zipcode = ClsConvert.ToString(dr["ZipCode"]);
			Countryid = ClsConvert.ToInt32Nullable(dr["CountryId"]);
			Name = ClsConvert.ToString(dr["Name"]);
			Description = ClsConvert.ToString(dr["Description"]);
			Iso2code = ClsConvert.ToString(dr["Iso2Code"]);
			Iso3code = ClsConvert.ToString(dr["Iso3Code"]);
			Iso5code = ClsConvert.ToString(dr["Iso5Code"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Bol_No = ClsConvert.ToString(dr["Bol_No", v]);
			Booking_No = ClsConvert.ToString(dr["Booking_no", v]);
			Typeid = ClsConvert.ToInt32Nullable(dr["TypeId", v]);
			Typename = ClsConvert.ToString(dr["TypeName", v]);
			Companyname = ClsConvert.ToString(dr["CompanyName", v]);
			Fullname = ClsConvert.ToString(dr["FullName", v]);
			Fullnamedetails = ClsConvert.ToString(dr["FullNameDetails", v]);
			Phonedesk = ClsConvert.ToString(dr["PhoneDesk", v]);
			Phonemobile = ClsConvert.ToString(dr["PhoneMobile", v]);
			Emailaddress = ClsConvert.ToString(dr["EmailAddress", v]);
			Departmentofdefenseactivityaddresscode = ClsConvert.ToString(dr["DepartmentOfDefenseActivityAddressCode", v]);
			Fax = ClsConvert.ToString(dr["Fax", v]);
			Remarks = ClsConvert.ToString(dr["Remarks", v]);
			Addressid = ClsConvert.ToInt32Nullable(dr["AddressId", v]);
			Addressline1 = ClsConvert.ToString(dr["AddressLine1", v]);
			Addressline2 = ClsConvert.ToString(dr["AddressLine2", v]);
			Addressline3 = ClsConvert.ToString(dr["AddressLine3", v]);
			City = ClsConvert.ToString(dr["City", v]);
			State = ClsConvert.ToString(dr["State", v]);
			Zipcode = ClsConvert.ToString(dr["ZipCode", v]);
			Countryid = ClsConvert.ToInt32Nullable(dr["CountryId", v]);
			Name = ClsConvert.ToString(dr["Name", v]);
			Description = ClsConvert.ToString(dr["Description", v]);
			Iso2code = ClsConvert.ToString(dr["Iso2Code", v]);
			Iso3code = ClsConvert.ToString(dr["Iso3Code", v]);
			Iso5code = ClsConvert.ToString(dr["Iso5Code", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["Bol_No"] = ClsConvert.ToDbObject(Bol_No);
			dr["Booking_no"] = ClsConvert.ToDbObject(Booking_No);
			dr["TypeId"] = ClsConvert.ToDbObject(Typeid);
			dr["TypeName"] = ClsConvert.ToDbObject(Typename);
			dr["CompanyName"] = ClsConvert.ToDbObject(Companyname);
			dr["FullName"] = ClsConvert.ToDbObject(Fullname);
			dr["FullNameDetails"] = ClsConvert.ToDbObject(Fullnamedetails);
			dr["PhoneDesk"] = ClsConvert.ToDbObject(Phonedesk);
			dr["PhoneMobile"] = ClsConvert.ToDbObject(Phonemobile);
			dr["EmailAddress"] = ClsConvert.ToDbObject(Emailaddress);
			dr["DepartmentOfDefenseActivityAddressCode"] = ClsConvert.ToDbObject(Departmentofdefenseactivityaddresscode);
			dr["Fax"] = ClsConvert.ToDbObject(Fax);
			dr["Remarks"] = ClsConvert.ToDbObject(Remarks);
			dr["AddressId"] = ClsConvert.ToDbObject(Addressid);
			dr["AddressLine1"] = ClsConvert.ToDbObject(Addressline1);
			dr["AddressLine2"] = ClsConvert.ToDbObject(Addressline2);
			dr["AddressLine3"] = ClsConvert.ToDbObject(Addressline3);
			dr["City"] = ClsConvert.ToDbObject(City);
			dr["State"] = ClsConvert.ToDbObject(State);
			dr["ZipCode"] = ClsConvert.ToDbObject(Zipcode);
			dr["CountryId"] = ClsConvert.ToDbObject(Countryid);
			dr["Name"] = ClsConvert.ToDbObject(Name);
			dr["Description"] = ClsConvert.ToDbObject(Description);
			dr["Iso2Code"] = ClsConvert.ToDbObject(Iso2code);
			dr["Iso3Code"] = ClsConvert.ToDbObject(Iso3code);
			dr["Iso5Code"] = ClsConvert.ToDbObject(Iso5code);
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



		#endregion		// #region Static Methods
	}
}