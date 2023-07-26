using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsVendor : ClsBaseTable, IAddress
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ArcSys"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "R_VENDOR";
		public const int PrimaryKeyCount = 1;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] { "VENDOR_CD" };
		}

		public const string SelectSQL = "SELECT * FROM R_VENDOR";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Vendor_CdMax = 10;
		public const int Create_UserMax = 30;
		public const int Modify_UserMax = 30;
		public const int Vendor_NmMax = 50;
		public const int Active_FlgMax = 1;
		public const int Conus_FlgMax = 1;
		public const int Addr1Max = 100;
		public const int Addr2Max = 100;
		public const int Addr3Max = 50;
		public const int CityMax = 50;
		public const int State_Prov_CdMax = 10;
		public const int Postal_CdMax = 20;
		public const int Country_CdMax = 10;
		public const int Contact_NmMax = 50;
		public const int PhoneMax = 25;
		public const int Phone_ExtMax = 4;
		public const int EmailMax = 50;
		public const int FaxMax = 25;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected string _Vendor_Cd;
		protected string _Create_User;
		protected DateTime? _Create_Dt;
		protected string _Modify_User;
		protected DateTime? _Modify_Dt;
		protected string _Vendor_Nm;
		protected string _Active_Flg;
		protected string _Conus_Flg;
		protected string _Addr1;
		protected string _Addr2;
		protected string _Addr3;
		protected string _City;
		protected string _State_Prov_Cd;
		protected string _Postal_Cd;
		protected string _Country_Cd;
		protected string _Contact_Nm;
		protected string _Phone;
		protected string _Phone_Ext;
		protected string _Email;
		protected string _Fax;

		#endregion	// #region Column Fields

		#region Column Properties

		public string Vendor_Cd
		{
			get { return _Vendor_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Vendor_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Vendor_CdMax )
					_Vendor_Cd = val.Substring(0, (int)Vendor_CdMax);
				else
					_Vendor_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Vendor_Cd");
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
		public string Vendor_Nm
		{
			get { return _Vendor_Nm; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Vendor_Nm, val, false) == 0 ) return;
		
				if( val != null && val.Length > Vendor_NmMax )
					_Vendor_Nm = val.Substring(0, (int)Vendor_NmMax);
				else
					_Vendor_Nm = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Vendor_Nm");
			}
		}
		public string Active_Flg
		{
			get { return _Active_Flg; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Active_Flg, val, false) == 0 ) return;
		
				if( val != null && val.Length > Active_FlgMax )
					_Active_Flg = val.Substring(0, (int)Active_FlgMax);
				else
					_Active_Flg = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Active_Flg");
			}
		}
		public string Conus_Flg
		{
			get { return _Conus_Flg; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Conus_Flg, val, false) == 0 ) return;
		
				if( val != null && val.Length > Conus_FlgMax )
					_Conus_Flg = val.Substring(0, (int)Conus_FlgMax);
				else
					_Conus_Flg = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Conus_Flg");
			}
		}
		public string Addr1
		{
			get { return _Addr1; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Addr1, val, false) == 0 ) return;
		
				if( val != null && val.Length > Addr1Max )
					_Addr1 = val.Substring(0, (int)Addr1Max);
				else
					_Addr1 = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Addr1");
			}
		}
		public string Addr2
		{
			get { return _Addr2; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Addr2, val, false) == 0 ) return;
		
				if( val != null && val.Length > Addr2Max )
					_Addr2 = val.Substring(0, (int)Addr2Max);
				else
					_Addr2 = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Addr2");
			}
		}
		public string Addr3
		{
			get { return _Addr3; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Addr3, val, false) == 0 ) return;
		
				if( val != null && val.Length > Addr3Max )
					_Addr3 = val.Substring(0, (int)Addr3Max);
				else
					_Addr3 = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Addr3");
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
		public string State_Prov_Cd
		{
			get { return _State_Prov_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_State_Prov_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > State_Prov_CdMax )
					_State_Prov_Cd = val.Substring(0, (int)State_Prov_CdMax);
				else
					_State_Prov_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("State_Prov_Cd");
			}
		}
		public string Postal_Cd
		{
			get { return _Postal_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Postal_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Postal_CdMax )
					_Postal_Cd = val.Substring(0, (int)Postal_CdMax);
				else
					_Postal_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Postal_Cd");
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
		public string Phone
		{
			get { return _Phone; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Phone, val, false) == 0 ) return;
		
				if( val != null && val.Length > PhoneMax )
					_Phone = val.Substring(0, (int)PhoneMax);
				else
					_Phone = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Phone");
			}
		}
		public string Phone_Ext
		{
			get { return _Phone_Ext; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Phone_Ext, val, false) == 0 ) return;
		
				if( val != null && val.Length > Phone_ExtMax )
					_Phone_Ext = val.Substring(0, (int)Phone_ExtMax);
				else
					_Phone_Ext = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Phone_Ext");
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

		#endregion	// #region Column Properties

		#region Foreign Key Fields



		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties



		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsVendor() : base() {}
		public ClsVendor(DataRow dr) : base(dr) {}
		public ClsVendor(ClsVendor src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Vendor_Cd = null;
			Create_User = null;
			Create_Dt = null;
			Modify_User = null;
			Modify_Dt = null;
			Vendor_Nm = null;
			Active_Flg = null;
			Conus_Flg = null;
			Addr1 = null;
			Addr2 = null;
			Addr3 = null;
			City = null;
			State_Prov_Cd = null;
			Postal_Cd = null;
			Country_Cd = null;
			Contact_Nm = null;
			Phone = null;
			Phone_Ext = null;
			Email = null;
			Fax = null;
		}

		public void CopyFrom(ClsVendor src)
		{
			Vendor_Cd = src._Vendor_Cd;
			Create_User = src._Create_User;
			Create_Dt = src._Create_Dt;
			Modify_User = src._Modify_User;
			Modify_Dt = src._Modify_Dt;
			Vendor_Nm = src._Vendor_Nm;
			Active_Flg = src._Active_Flg;
			Conus_Flg = src._Conus_Flg;
			Addr1 = src._Addr1;
			Addr2 = src._Addr2;
			Addr3 = src._Addr3;
			City = src._City;
			State_Prov_Cd = src._State_Prov_Cd;
			Postal_Cd = src._Postal_Cd;
			Country_Cd = src._Country_Cd;
			Contact_Nm = src._Contact_Nm;
			Phone = src._Phone;
			Phone_Ext = src._Phone_Ext;
			Email = src._Email;
			Fax = src._Fax;
		}

		public override bool ReloadFromDB()
		{
			ClsVendor tmp = ClsVendor.GetUsingKey(Vendor_Cd);
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
				("@VENDOR_CD", Vendor_Cd);
			p[1] = Connection.GetParameter
				("@VENDOR_NM", Vendor_Nm);
			p[2] = Connection.GetParameter
				("@ACTIVE_FLG", Active_Flg);
			p[3] = Connection.GetParameter
				("@CONUS_FLG", Conus_Flg);
			p[4] = Connection.GetParameter
				("@ADDR1", Addr1);
			p[5] = Connection.GetParameter
				("@ADDR2", Addr2);
			p[6] = Connection.GetParameter
				("@ADDR3", Addr3);
			p[7] = Connection.GetParameter
				("@CITY", City);
			p[8] = Connection.GetParameter
				("@STATE_PROV_CD", State_Prov_Cd);
			p[9] = Connection.GetParameter
				("@POSTAL_CD", Postal_Cd);
			p[10] = Connection.GetParameter
				("@COUNTRY_CD", Country_Cd);
			p[11] = Connection.GetParameter
				("@CONTACT_NM", Contact_Nm);
			p[12] = Connection.GetParameter
				("@PHONE", Phone);
			p[13] = Connection.GetParameter
				("@PHONE_EXT", Phone_Ext);
			p[14] = Connection.GetParameter
				("@EMAIL", Email);
			p[15] = Connection.GetParameter
				("@FAX", Fax);
			p[16] = Connection.GetParameter
				("@CREATE_USER", Create_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Create_UserMax);
			p[17] = Connection.GetParameter
				("@CREATE_DT", Create_Dt, ParameterDirection.Output, DbType.DateTime, 0);
			p[18] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);
			p[19] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.Output, DbType.DateTime, 0);

			const string sql = @"
				INSERT INTO R_VENDOR
					(VENDOR_CD, VENDOR_NM, ACTIVE_FLG,
					CONUS_FLG, ADDR1, ADDR2,
					ADDR3, CITY, STATE_PROV_CD,
					POSTAL_CD, COUNTRY_CD, CONTACT_NM,
					PHONE, PHONE_EXT, EMAIL,
					FAX)
				VALUES
					(@VENDOR_CD, @VENDOR_NM, @ACTIVE_FLG,
					@CONUS_FLG, @ADDR1, @ADDR2,
					@ADDR3, @CITY, @STATE_PROV_CD,
					@POSTAL_CD, @COUNTRY_CD, @CONTACT_NM,
					@PHONE, @PHONE_EXT, @EMAIL,
					@FAX)
				RETURNING
					CREATE_USER, CREATE_DT, MODIFY_USER,
					MODIFY_DT
				INTO
					@CREATE_USER, @CREATE_DT, @MODIFY_USER,
					@MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Create_User = ClsConvert.ToString(p[16].Value);
			Create_Dt = ClsConvert.ToDateTimeNullable(p[17].Value);
			Modify_User = ClsConvert.ToString(p[18].Value);
			Modify_Dt = ClsConvert.ToDateTimeNullable(p[19].Value);
			return ret;
		}
		public override int Update()
		{
			DbParameter[] p = new DbParameter[18];

			p[0] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.InputOutput, DbType.DateTime, 0);
			p[1] = Connection.GetParameter
				("@VENDOR_NM", Vendor_Nm);
			p[2] = Connection.GetParameter
				("@ACTIVE_FLG", Active_Flg);
			p[3] = Connection.GetParameter
				("@CONUS_FLG", Conus_Flg);
			p[4] = Connection.GetParameter
				("@ADDR1", Addr1);
			p[5] = Connection.GetParameter
				("@ADDR2", Addr2);
			p[6] = Connection.GetParameter
				("@ADDR3", Addr3);
			p[7] = Connection.GetParameter
				("@CITY", City);
			p[8] = Connection.GetParameter
				("@STATE_PROV_CD", State_Prov_Cd);
			p[9] = Connection.GetParameter
				("@POSTAL_CD", Postal_Cd);
			p[10] = Connection.GetParameter
				("@COUNTRY_CD", Country_Cd);
			p[11] = Connection.GetParameter
				("@CONTACT_NM", Contact_Nm);
			p[12] = Connection.GetParameter
				("@PHONE", Phone);
			p[13] = Connection.GetParameter
				("@PHONE_EXT", Phone_Ext);
			p[14] = Connection.GetParameter
				("@EMAIL", Email);
			p[15] = Connection.GetParameter
				("@FAX", Fax);
			p[16] = Connection.GetParameter
				("@VENDOR_CD", Vendor_Cd);
			p[17] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);

			const string sql = @"
				UPDATE R_VENDOR SET
					MODIFY_DT = @MODIFY_DT,
					VENDOR_NM = @VENDOR_NM,
					ACTIVE_FLG = @ACTIVE_FLG,
					CONUS_FLG = @CONUS_FLG,
					ADDR1 = @ADDR1,
					ADDR2 = @ADDR2,
					ADDR3 = @ADDR3,
					CITY = @CITY,
					STATE_PROV_CD = @STATE_PROV_CD,
					POSTAL_CD = @POSTAL_CD,
					COUNTRY_CD = @COUNTRY_CD,
					CONTACT_NM = @CONTACT_NM,
					PHONE = @PHONE,
					PHONE_EXT = @PHONE_EXT,
					EMAIL = @EMAIL,
					FAX = @FAX
				WHERE
					VENDOR_CD = @VENDOR_CD
				RETURNING
					MODIFY_USER, MODIFY_DT
				INTO
					@MODIFY_USER, @MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Modify_Dt = ClsConvert.ToDateTimeNullable(p[0].Value);
			Modify_User = ClsConvert.ToString(p[17].Value);
			return ret;
		}
		public override int Delete()
		{
			DbParameter[] p = new DbParameter[1];

			p[0] = Connection.GetParameter
				("@VENDOR_CD", Vendor_Cd);

			const string sql = @"
				DELETE FROM R_VENDOR WHERE
				VENDOR_CD=@VENDOR_CD";
			return Connection.RunSQL(sql, p);
		}
		#endregion		// #region Insert, Update, Delete

		#region Conversion methods

		public override void LoadFromDataReader(DbDataReader dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataReader: DataReader parameter was null");

			Vendor_Cd = ClsConvert.ToString(dr["VENDOR_CD"]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER"]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT"]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER"]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT"]);
			Vendor_Nm = ClsConvert.ToString(dr["VENDOR_NM"]);
			Active_Flg = ClsConvert.ToString(dr["ACTIVE_FLG"]);
			Conus_Flg = ClsConvert.ToString(dr["CONUS_FLG"]);
			Addr1 = ClsConvert.ToString(dr["ADDR1"]);
			Addr2 = ClsConvert.ToString(dr["ADDR2"]);
			Addr3 = ClsConvert.ToString(dr["ADDR3"]);
			City = ClsConvert.ToString(dr["CITY"]);
			State_Prov_Cd = ClsConvert.ToString(dr["STATE_PROV_CD"]);
			Postal_Cd = ClsConvert.ToString(dr["POSTAL_CD"]);
			Country_Cd = ClsConvert.ToString(dr["COUNTRY_CD"]);
			Contact_Nm = ClsConvert.ToString(dr["CONTACT_NM"]);
			Phone = ClsConvert.ToString(dr["PHONE"]);
			Phone_Ext = ClsConvert.ToString(dr["PHONE_EXT"]);
			Email = ClsConvert.ToString(dr["EMAIL"]);
			Fax = ClsConvert.ToString(dr["FAX"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Vendor_Cd = ClsConvert.ToString(dr["VENDOR_CD", v]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER", v]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT", v]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER", v]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT", v]);
			Vendor_Nm = ClsConvert.ToString(dr["VENDOR_NM", v]);
			Active_Flg = ClsConvert.ToString(dr["ACTIVE_FLG", v]);
			Conus_Flg = ClsConvert.ToString(dr["CONUS_FLG", v]);
			Addr1 = ClsConvert.ToString(dr["ADDR1", v]);
			Addr2 = ClsConvert.ToString(dr["ADDR2", v]);
			Addr3 = ClsConvert.ToString(dr["ADDR3", v]);
			City = ClsConvert.ToString(dr["CITY", v]);
			State_Prov_Cd = ClsConvert.ToString(dr["STATE_PROV_CD", v]);
			Postal_Cd = ClsConvert.ToString(dr["POSTAL_CD", v]);
			Country_Cd = ClsConvert.ToString(dr["COUNTRY_CD", v]);
			Contact_Nm = ClsConvert.ToString(dr["CONTACT_NM", v]);
			Phone = ClsConvert.ToString(dr["PHONE", v]);
			Phone_Ext = ClsConvert.ToString(dr["PHONE_EXT", v]);
			Email = ClsConvert.ToString(dr["EMAIL", v]);
			Fax = ClsConvert.ToString(dr["FAX", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["VENDOR_CD"] = ClsConvert.ToDbObject(Vendor_Cd);
			dr["CREATE_USER"] = ClsConvert.ToDbObject(Create_User);
			dr["CREATE_DT"] = ClsConvert.ToDbObject(Create_Dt);
			dr["MODIFY_USER"] = ClsConvert.ToDbObject(Modify_User);
			dr["MODIFY_DT"] = ClsConvert.ToDbObject(Modify_Dt);
			dr["VENDOR_NM"] = ClsConvert.ToDbObject(Vendor_Nm);
			dr["ACTIVE_FLG"] = ClsConvert.ToDbObject(Active_Flg);
			dr["CONUS_FLG"] = ClsConvert.ToDbObject(Conus_Flg);
			dr["ADDR1"] = ClsConvert.ToDbObject(Addr1);
			dr["ADDR2"] = ClsConvert.ToDbObject(Addr2);
			dr["ADDR3"] = ClsConvert.ToDbObject(Addr3);
			dr["CITY"] = ClsConvert.ToDbObject(City);
			dr["STATE_PROV_CD"] = ClsConvert.ToDbObject(State_Prov_Cd);
			dr["POSTAL_CD"] = ClsConvert.ToDbObject(Postal_Cd);
			dr["COUNTRY_CD"] = ClsConvert.ToDbObject(Country_Cd);
			dr["CONTACT_NM"] = ClsConvert.ToDbObject(Contact_Nm);
			dr["PHONE"] = ClsConvert.ToDbObject(Phone);
			dr["PHONE_EXT"] = ClsConvert.ToDbObject(Phone_Ext);
			dr["EMAIL"] = ClsConvert.ToDbObject(Email);
			dr["FAX"] = ClsConvert.ToDbObject(Fax);
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

		public static ClsVendor GetUsingKey(string Vendor_Cd)
		{
			object[] vals = new object[] {Vendor_Cd};
			DataRow dr = Connection.GetDataRowUsingKey
				(TableName, GetPrimaryKeys(), vals);
			return ( dr == null ) ? null : new ClsVendor(dr);
		}

		#endregion		// #region Static Methods
	}
}