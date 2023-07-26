using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsVwArcBookingContact : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ArcSys"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "vw_arc_booking_contact";
		public const int PrimaryKeyCount = 0;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] {  };
		}

		public const string SelectSQL = "SELECT * FROM vw_arc_booking_contact";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Booking_NoMax = 50;
		public const int Contact_TypeMax = 50;
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
		public const int Country_NmMax = 50;
		public const int Country_DscMax = 100;
		public const int Country_2cdMax = 2;
		public const int Country_3cdMax = 3;
		public const int Country_5cdMax = 5;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected Int32? _Contact_ID;
		protected Int32? _Bookingid;
		protected string _Booking_No;
		protected Int32? _Contacttypeid;
		protected Int32? _Addressid;
		protected string _Contact_Type;
		protected string _Companyname;
		protected string _Fullname;
		protected string _Fullnamedetails;
		protected string _Phonedesk;
		protected string _Phonemobile;
		protected string _Emailaddress;
		protected string _Departmentofdefenseactivityaddresscode;
		protected string _Fax;
		protected string _Remarks;
		protected string _Addressline1;
		protected string _Addressline2;
		protected string _Addressline3;
		protected string _City;
		protected string _State;
		protected string _Zipcode;
		protected string _Country_Nm;
		protected string _Country_Dsc;
		protected string _Country_2cd;
		protected string _Country_3cd;
		protected string _Country_5cd;

		#endregion	// #region Column Fields

		#region Column Properties

		public Int32? Contact_ID
		{
			get { return _Contact_ID; }
			set
			{
				if( _Contact_ID == value ) return;
		
				_Contact_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Contact_ID");
			}
		}
		public Int32? Bookingid
		{
			get { return _Bookingid; }
			set
			{
				if( _Bookingid == value ) return;
		
				_Bookingid = value;
				_IsDirty = true;
				NotifyPropertyChanged("Bookingid");
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
		public Int32? Contacttypeid
		{
			get { return _Contacttypeid; }
			set
			{
				if( _Contacttypeid == value ) return;
		
				_Contacttypeid = value;
				_IsDirty = true;
				NotifyPropertyChanged("Contacttypeid");
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
		public string Contact_Type
		{
			get { return _Contact_Type; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Contact_Type, val, false) == 0 ) return;
		
				if( val != null && val.Length > Contact_TypeMax )
					_Contact_Type = val.Substring(0, (int)Contact_TypeMax);
				else
					_Contact_Type = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Contact_Type");
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
		public string Country_Nm
		{
			get { return _Country_Nm; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Country_Nm, val, false) == 0 ) return;
		
				if( val != null && val.Length > Country_NmMax )
					_Country_Nm = val.Substring(0, (int)Country_NmMax);
				else
					_Country_Nm = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Country_Nm");
			}
		}
		public string Country_Dsc
		{
			get { return _Country_Dsc; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Country_Dsc, val, false) == 0 ) return;
		
				if( val != null && val.Length > Country_DscMax )
					_Country_Dsc = val.Substring(0, (int)Country_DscMax);
				else
					_Country_Dsc = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Country_Dsc");
			}
		}
		public string Country_2cd
		{
			get { return _Country_2cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Country_2cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Country_2cdMax )
					_Country_2cd = val.Substring(0, (int)Country_2cdMax);
				else
					_Country_2cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Country_2cd");
			}
		}
		public string Country_3cd
		{
			get { return _Country_3cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Country_3cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Country_3cdMax )
					_Country_3cd = val.Substring(0, (int)Country_3cdMax);
				else
					_Country_3cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Country_3cd");
			}
		}
		public string Country_5cd
		{
			get { return _Country_5cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Country_5cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Country_5cdMax )
					_Country_5cd = val.Substring(0, (int)Country_5cdMax);
				else
					_Country_5cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Country_5cd");
			}
		}

		#endregion	// #region Column Properties

		#region Foreign Key Fields



		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties



		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsVwArcBookingContact() : base() {}
		public ClsVwArcBookingContact(DataRow dr) : base(dr) {}
		public ClsVwArcBookingContact(ClsVwArcBookingContact src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Contact_ID = null;
			Bookingid = null;
			Booking_No = null;
			Contacttypeid = null;
			Addressid = null;
			Contact_Type = null;
			Companyname = null;
			Fullname = null;
			Fullnamedetails = null;
			Phonedesk = null;
			Phonemobile = null;
			Emailaddress = null;
			Departmentofdefenseactivityaddresscode = null;
			Fax = null;
			Remarks = null;
			Addressline1 = null;
			Addressline2 = null;
			Addressline3 = null;
			City = null;
			State = null;
			Zipcode = null;
			Country_Nm = null;
			Country_Dsc = null;
			Country_2cd = null;
			Country_3cd = null;
			Country_5cd = null;
		}

		public void CopyFrom(ClsVwArcBookingContact src)
		{
			Contact_ID = src._Contact_ID;
			Bookingid = src._Bookingid;
			Booking_No = src._Booking_No;
			Contacttypeid = src._Contacttypeid;
			Addressid = src._Addressid;
			Contact_Type = src._Contact_Type;
			Companyname = src._Companyname;
			Fullname = src._Fullname;
			Fullnamedetails = src._Fullnamedetails;
			Phonedesk = src._Phonedesk;
			Phonemobile = src._Phonemobile;
			Emailaddress = src._Emailaddress;
			Departmentofdefenseactivityaddresscode = src._Departmentofdefenseactivityaddresscode;
			Fax = src._Fax;
			Remarks = src._Remarks;
			Addressline1 = src._Addressline1;
			Addressline2 = src._Addressline2;
			Addressline3 = src._Addressline3;
			City = src._City;
			State = src._State;
			Zipcode = src._Zipcode;
			Country_Nm = src._Country_Nm;
			Country_Dsc = src._Country_Dsc;
			Country_2cd = src._Country_2cd;
			Country_3cd = src._Country_3cd;
			Country_5cd = src._Country_5cd;
		}

		public override bool ReloadFromDB()
		{
			ClsVwArcBookingContact tmp = null;	//No primary key can't refresh;
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
				("@Contact_ID", Contact_ID);
			p[1] = Connection.GetParameter
				("@BookingId", Bookingid);
			p[2] = Connection.GetParameter
				("@Booking_No", Booking_No);
			p[3] = Connection.GetParameter
				("@ContactTypeID", Contacttypeid);
			p[4] = Connection.GetParameter
				("@AddressId", Addressid);
			p[5] = Connection.GetParameter
				("@Contact_Type", Contact_Type);
			p[6] = Connection.GetParameter
				("@CompanyName", Companyname);
			p[7] = Connection.GetParameter
				("@FullName", Fullname);
			p[8] = Connection.GetParameter
				("@FullNameDetails", Fullnamedetails);
			p[9] = Connection.GetParameter
				("@PhoneDesk", Phonedesk);
			p[10] = Connection.GetParameter
				("@PhoneMobile", Phonemobile);
			p[11] = Connection.GetParameter
				("@EmailAddress", Emailaddress);
			p[12] = Connection.GetParameter
				("@DepartmentOfDefenseActivityAddressCode", Departmentofdefenseactivityaddresscode);
			p[13] = Connection.GetParameter
				("@Fax", Fax);
			p[14] = Connection.GetParameter
				("@Remarks", Remarks);
			p[15] = Connection.GetParameter
				("@AddressLine1", Addressline1);
			p[16] = Connection.GetParameter
				("@AddressLine2", Addressline2);
			p[17] = Connection.GetParameter
				("@AddressLine3", Addressline3);
			p[18] = Connection.GetParameter
				("@City", City);
			p[19] = Connection.GetParameter
				("@State", State);
			p[20] = Connection.GetParameter
				("@ZipCode", Zipcode);
			p[21] = Connection.GetParameter
				("@Country_Nm", Country_Nm);
			p[22] = Connection.GetParameter
				("@Country_Dsc", Country_Dsc);
			p[23] = Connection.GetParameter
				("@Country_2Cd", Country_2cd);
			p[24] = Connection.GetParameter
				("@Country_3Cd", Country_3cd);
			p[25] = Connection.GetParameter
				("@Country_5Cd", Country_5cd);

			const string sql = @"INSERT INTO vw_arc_booking_contact VALUES
				(@Contact_ID,@BookingId,@Booking_No
				,@ContactTypeID,@AddressId,@Contact_Type
				,@CompanyName,@FullName,@FullNameDetails
				,@PhoneDesk,@PhoneMobile,@EmailAddress
				,@DepartmentOfDefenseActivityAddressCode,@Fax,@Remarks
				,@AddressLine1,@AddressLine2,@AddressLine3
				,@City,@State,@ZipCode
				,@Country_Nm,@Country_Dsc,@Country_2Cd
				,@Country_3Cd,@Country_5Cd)";
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

			Contact_ID = ClsConvert.ToInt32Nullable(dr["Contact_ID"]);
			Bookingid = ClsConvert.ToInt32Nullable(dr["BookingId"]);
			Booking_No = ClsConvert.ToString(dr["Booking_No"]);
			Contacttypeid = ClsConvert.ToInt32Nullable(dr["ContactTypeID"]);
			Addressid = ClsConvert.ToInt32Nullable(dr["AddressId"]);
			Contact_Type = ClsConvert.ToString(dr["Contact_Type"]);
			Companyname = ClsConvert.ToString(dr["CompanyName"]);
			Fullname = ClsConvert.ToString(dr["FullName"]);
			Fullnamedetails = ClsConvert.ToString(dr["FullNameDetails"]);
			Phonedesk = ClsConvert.ToString(dr["PhoneDesk"]);
			Phonemobile = ClsConvert.ToString(dr["PhoneMobile"]);
			Emailaddress = ClsConvert.ToString(dr["EmailAddress"]);
			Departmentofdefenseactivityaddresscode = ClsConvert.ToString(dr["DepartmentOfDefenseActivityAddressCode"]);
			Fax = ClsConvert.ToString(dr["Fax"]);
			Remarks = ClsConvert.ToString(dr["Remarks"]);
			Addressline1 = ClsConvert.ToString(dr["AddressLine1"]);
			Addressline2 = ClsConvert.ToString(dr["AddressLine2"]);
			Addressline3 = ClsConvert.ToString(dr["AddressLine3"]);
			City = ClsConvert.ToString(dr["City"]);
			State = ClsConvert.ToString(dr["State"]);
			Zipcode = ClsConvert.ToString(dr["ZipCode"]);
			Country_Nm = ClsConvert.ToString(dr["Country_Nm"]);
			Country_Dsc = ClsConvert.ToString(dr["Country_Dsc"]);
			Country_2cd = ClsConvert.ToString(dr["Country_2Cd"]);
			Country_3cd = ClsConvert.ToString(dr["Country_3Cd"]);
			Country_5cd = ClsConvert.ToString(dr["Country_5Cd"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Contact_ID = ClsConvert.ToInt32Nullable(dr["Contact_ID", v]);
			Bookingid = ClsConvert.ToInt32Nullable(dr["BookingId", v]);
			Booking_No = ClsConvert.ToString(dr["Booking_No", v]);
			Contacttypeid = ClsConvert.ToInt32Nullable(dr["ContactTypeID", v]);
			Addressid = ClsConvert.ToInt32Nullable(dr["AddressId", v]);
			Contact_Type = ClsConvert.ToString(dr["Contact_Type", v]);
			Companyname = ClsConvert.ToString(dr["CompanyName", v]);
			Fullname = ClsConvert.ToString(dr["FullName", v]);
			Fullnamedetails = ClsConvert.ToString(dr["FullNameDetails", v]);
			Phonedesk = ClsConvert.ToString(dr["PhoneDesk", v]);
			Phonemobile = ClsConvert.ToString(dr["PhoneMobile", v]);
			Emailaddress = ClsConvert.ToString(dr["EmailAddress", v]);
			Departmentofdefenseactivityaddresscode = ClsConvert.ToString(dr["DepartmentOfDefenseActivityAddressCode", v]);
			Fax = ClsConvert.ToString(dr["Fax", v]);
			Remarks = ClsConvert.ToString(dr["Remarks", v]);
			Addressline1 = ClsConvert.ToString(dr["AddressLine1", v]);
			Addressline2 = ClsConvert.ToString(dr["AddressLine2", v]);
			Addressline3 = ClsConvert.ToString(dr["AddressLine3", v]);
			City = ClsConvert.ToString(dr["City", v]);
			State = ClsConvert.ToString(dr["State", v]);
			Zipcode = ClsConvert.ToString(dr["ZipCode", v]);
			Country_Nm = ClsConvert.ToString(dr["Country_Nm", v]);
			Country_Dsc = ClsConvert.ToString(dr["Country_Dsc", v]);
			Country_2cd = ClsConvert.ToString(dr["Country_2Cd", v]);
			Country_3cd = ClsConvert.ToString(dr["Country_3Cd", v]);
			Country_5cd = ClsConvert.ToString(dr["Country_5Cd", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["Contact_ID"] = ClsConvert.ToDbObject(Contact_ID);
			dr["BookingId"] = ClsConvert.ToDbObject(Bookingid);
			dr["Booking_No"] = ClsConvert.ToDbObject(Booking_No);
			dr["ContactTypeID"] = ClsConvert.ToDbObject(Contacttypeid);
			dr["AddressId"] = ClsConvert.ToDbObject(Addressid);
			dr["Contact_Type"] = ClsConvert.ToDbObject(Contact_Type);
			dr["CompanyName"] = ClsConvert.ToDbObject(Companyname);
			dr["FullName"] = ClsConvert.ToDbObject(Fullname);
			dr["FullNameDetails"] = ClsConvert.ToDbObject(Fullnamedetails);
			dr["PhoneDesk"] = ClsConvert.ToDbObject(Phonedesk);
			dr["PhoneMobile"] = ClsConvert.ToDbObject(Phonemobile);
			dr["EmailAddress"] = ClsConvert.ToDbObject(Emailaddress);
			dr["DepartmentOfDefenseActivityAddressCode"] = ClsConvert.ToDbObject(Departmentofdefenseactivityaddresscode);
			dr["Fax"] = ClsConvert.ToDbObject(Fax);
			dr["Remarks"] = ClsConvert.ToDbObject(Remarks);
			dr["AddressLine1"] = ClsConvert.ToDbObject(Addressline1);
			dr["AddressLine2"] = ClsConvert.ToDbObject(Addressline2);
			dr["AddressLine3"] = ClsConvert.ToDbObject(Addressline3);
			dr["City"] = ClsConvert.ToDbObject(City);
			dr["State"] = ClsConvert.ToDbObject(State);
			dr["ZipCode"] = ClsConvert.ToDbObject(Zipcode);
			dr["Country_Nm"] = ClsConvert.ToDbObject(Country_Nm);
			dr["Country_Dsc"] = ClsConvert.ToDbObject(Country_Dsc);
			dr["Country_2Cd"] = ClsConvert.ToDbObject(Country_2cd);
			dr["Country_3Cd"] = ClsConvert.ToDbObject(Country_3cd);
			dr["Country_5Cd"] = ClsConvert.ToDbObject(Country_5cd);
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