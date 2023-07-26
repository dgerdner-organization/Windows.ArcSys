using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsTerminalAddress : ClsBaseTable, IAddress
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ArcSys"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "R_TERMINAL_ADDRESS";
		public const int PrimaryKeyCount = 1;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] { "TERMINAL_ADDRESS_ID" };
		}

		public const string SelectSQL = @"SELECT * FROM R_TERMINAL_ADDRESS 
				INNER JOIN R_TERMINAL
				ON R_TERMINAL_ADDRESS.TERMINAL_CD=R_TERMINAL.TERMINAL_CD
				INNER JOIN R_TERMINAL_SECTION
				ON R_TERMINAL_ADDRESS.TERMINAL_SECTION_CD=R_TERMINAL_SECTION.TERMINAL_SECTION_CD ";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Terminal_CdMax = 10;
		public const int Terminal_Section_CdMax = 10;
		public const int Create_UserMax = 30;
		public const int Modify_UserMax = 30;
		public const int Active_FlgMax = 1;
		public const int Addressee_NmMax = 100;
		public const int Addr1Max = 100;
		public const int Addr2Max = 100;
		public const int Addr3Max = 50;
		public const int CityMax = 50;
		public const int State_Prov_CdMax = 10;
		public const int Postal_CdMax = 20;
		public const int Country_CdMax = 10;
		public const int Contact_NmMax = 50;
		public const int Contact_DscMax = 50;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected Int64? _Terminal_Address_ID;
		protected string _Terminal_Cd;
		protected string _Terminal_Section_Cd;
		protected string _Create_User;
		protected DateTime? _Create_Dt;
		protected string _Modify_User;
		protected DateTime? _Modify_Dt;
		protected string _Active_Flg;
		protected string _Addressee_Nm;
		protected string _Addr1;
		protected string _Addr2;
		protected string _Addr3;
		protected string _City;
		protected string _State_Prov_Cd;
		protected string _Postal_Cd;
		protected string _Country_Cd;
		protected string _Contact_Nm;
		protected string _Contact_Dsc;

		#endregion	// #region Column Fields

		#region Column Properties

		public Int64? Terminal_Address_ID
		{
			get { return _Terminal_Address_ID; }
			set
			{
				if( _Terminal_Address_ID == value ) return;
		
				_Terminal_Address_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Terminal_Address_ID");
			}
		}
		public string Terminal_Cd
		{
			get { return _Terminal_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Terminal_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Terminal_CdMax )
					_Terminal_Cd = val.Substring(0, (int)Terminal_CdMax);
				else
					_Terminal_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Terminal_Cd");
			}
		}
		public string Terminal_Section_Cd
		{
			get { return _Terminal_Section_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Terminal_Section_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Terminal_Section_CdMax )
					_Terminal_Section_Cd = val.Substring(0, (int)Terminal_Section_CdMax);
				else
					_Terminal_Section_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Terminal_Section_Cd");
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
		public string Addressee_Nm
		{
			get { return _Addressee_Nm; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Addressee_Nm, val, false) == 0 ) return;
		
				if( val != null && val.Length > Addressee_NmMax )
					_Addressee_Nm = val.Substring(0, (int)Addressee_NmMax);
				else
					_Addressee_Nm = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Addressee_Nm");
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
		public string Contact_Dsc
		{
			get { return _Contact_Dsc; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Contact_Dsc, val, false) == 0 ) return;
		
				if( val != null && val.Length > Contact_DscMax )
					_Contact_Dsc = val.Substring(0, (int)Contact_DscMax);
				else
					_Contact_Dsc = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Contact_Dsc");
			}
		}

		#endregion	// #region Column Properties

		#region Foreign Key Fields

		protected ClsTerminal _Terminal;
		protected ClsTerminalSection _Terminal_Section;

		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties

		public ClsTerminal Terminal
		{
			get
			{
				if( Terminal_Cd == null )
					_Terminal = null;
				else if( _Terminal == null ||
					_Terminal.Terminal_Cd != Terminal_Cd )
					_Terminal = ClsTerminal.GetUsingKey(Terminal_Cd);
				return _Terminal;
			}
			set
			{
				if( _Terminal == value ) return;
		
				_Terminal = value;
			}
		}
		public ClsTerminalSection Terminal_Section
		{
			get
			{
				if( Terminal_Section_Cd == null )
					_Terminal_Section = null;
				else if( _Terminal_Section == null ||
					_Terminal_Section.Terminal_Section_Cd != Terminal_Section_Cd )
					_Terminal_Section = ClsTerminalSection.GetUsingKey(Terminal_Section_Cd);
				return _Terminal_Section;
			}
			set
			{
				if( _Terminal_Section == value ) return;
		
				_Terminal_Section = value;
			}
		}

		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsTerminalAddress() : base() {}
		public ClsTerminalAddress(DataRow dr) : base(dr) {}
		public ClsTerminalAddress(ClsTerminalAddress src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Terminal_Address_ID = null;
			Terminal_Cd = null;
			Terminal_Section_Cd = null;
			Create_User = null;
			Create_Dt = null;
			Modify_User = null;
			Modify_Dt = null;
			Active_Flg = null;
			Addressee_Nm = null;
			Addr1 = null;
			Addr2 = null;
			Addr3 = null;
			City = null;
			State_Prov_Cd = null;
			Postal_Cd = null;
			Country_Cd = null;
			Contact_Nm = null;
			Contact_Dsc = null;
		}

		public void CopyFrom(ClsTerminalAddress src)
		{
			Terminal_Address_ID = src._Terminal_Address_ID;
			Terminal_Cd = src._Terminal_Cd;
			Terminal_Section_Cd = src._Terminal_Section_Cd;
			Create_User = src._Create_User;
			Create_Dt = src._Create_Dt;
			Modify_User = src._Modify_User;
			Modify_Dt = src._Modify_Dt;
			Active_Flg = src._Active_Flg;
			Addressee_Nm = src._Addressee_Nm;
			Addr1 = src._Addr1;
			Addr2 = src._Addr2;
			Addr3 = src._Addr3;
			City = src._City;
			State_Prov_Cd = src._State_Prov_Cd;
			Postal_Cd = src._Postal_Cd;
			Country_Cd = src._Country_Cd;
			Contact_Nm = src._Contact_Nm;
			Contact_Dsc = src._Contact_Dsc;
		}

		public override bool ReloadFromDB()
		{
			ClsTerminalAddress tmp = ClsTerminalAddress.GetUsingKey(Terminal_Address_ID.Value);
			if( tmp != null ) CopyFrom(tmp);

			ResetFKs();
			OnReload();

			return ( tmp != null );
		}

		public override void ResetFKs()
		{
			_Terminal = null;
			_Terminal_Section = null;
		}
		#endregion		// #region Init methods

		#region Insert, Update, Delete

		public override int Insert()
		{

			DbParameter[] p = new DbParameter[18];

			p[0] = Connection.GetParameter
				("@TERMINAL_CD", Terminal_Cd);
			p[1] = Connection.GetParameter
				("@TERMINAL_SECTION_CD", Terminal_Section_Cd);
			p[2] = Connection.GetParameter
				("@ACTIVE_FLG", Active_Flg);
			p[3] = Connection.GetParameter
				("@ADDRESSEE_NM", Addressee_Nm);
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
				("@CONTACT_DSC", Contact_Dsc);
			p[13] = Connection.GetParameter
				("@TERMINAL_ADDRESS_ID", Terminal_Address_ID, ParameterDirection.Output, DbType.Int64, 0);
			p[14] = Connection.GetParameter
				("@CREATE_USER", Create_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Create_UserMax);
			p[15] = Connection.GetParameter
				("@CREATE_DT", Create_Dt, ParameterDirection.Output, DbType.DateTime, 0);
			p[16] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);
			p[17] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.Output, DbType.DateTime, 0);

			const string sql = @"
				INSERT INTO R_TERMINAL_ADDRESS
					(TERMINAL_ADDRESS_ID, TERMINAL_CD, TERMINAL_SECTION_CD,
					ACTIVE_FLG, ADDRESSEE_NM, ADDR1,
					ADDR2, ADDR3, CITY,
					STATE_PROV_CD, POSTAL_CD, COUNTRY_CD,
					CONTACT_NM, CONTACT_DSC)
				VALUES
					(TERMINAL_ADDRESS_ID_SEQ.NEXTVAL, @TERMINAL_CD, @TERMINAL_SECTION_CD,
					@ACTIVE_FLG, @ADDRESSEE_NM, @ADDR1,
					@ADDR2, @ADDR3, @CITY,
					@STATE_PROV_CD, @POSTAL_CD, @COUNTRY_CD,
					@CONTACT_NM, @CONTACT_DSC)
				RETURNING
					TERMINAL_ADDRESS_ID, CREATE_USER, CREATE_DT,
					MODIFY_USER, MODIFY_DT
				INTO
					@TERMINAL_ADDRESS_ID, @CREATE_USER, @CREATE_DT,
					@MODIFY_USER, @MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Terminal_Address_ID = ClsConvert.ToInt64Nullable(p[13].Value);
			Create_User = ClsConvert.ToString(p[14].Value);
			Create_Dt = ClsConvert.ToDateTimeNullable(p[15].Value);
			Modify_User = ClsConvert.ToString(p[16].Value);
			Modify_Dt = ClsConvert.ToDateTimeNullable(p[17].Value);
			return ret;
		}
		public override int Update()
		{
			DbParameter[] p = new DbParameter[16];

			p[0] = Connection.GetParameter
				("@TERMINAL_CD", Terminal_Cd);
			p[1] = Connection.GetParameter
				("@TERMINAL_SECTION_CD", Terminal_Section_Cd);
			p[2] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.InputOutput, DbType.DateTime, 0);
			p[3] = Connection.GetParameter
				("@ACTIVE_FLG", Active_Flg);
			p[4] = Connection.GetParameter
				("@ADDRESSEE_NM", Addressee_Nm);
			p[5] = Connection.GetParameter
				("@ADDR1", Addr1);
			p[6] = Connection.GetParameter
				("@ADDR2", Addr2);
			p[7] = Connection.GetParameter
				("@ADDR3", Addr3);
			p[8] = Connection.GetParameter
				("@CITY", City);
			p[9] = Connection.GetParameter
				("@STATE_PROV_CD", State_Prov_Cd);
			p[10] = Connection.GetParameter
				("@POSTAL_CD", Postal_Cd);
			p[11] = Connection.GetParameter
				("@COUNTRY_CD", Country_Cd);
			p[12] = Connection.GetParameter
				("@CONTACT_NM", Contact_Nm);
			p[13] = Connection.GetParameter
				("@CONTACT_DSC", Contact_Dsc);
			p[14] = Connection.GetParameter
				("@TERMINAL_ADDRESS_ID", Terminal_Address_ID);
			p[15] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);

			const string sql = @"
				UPDATE R_TERMINAL_ADDRESS SET
					TERMINAL_CD = @TERMINAL_CD,
					TERMINAL_SECTION_CD = @TERMINAL_SECTION_CD,
					MODIFY_DT = @MODIFY_DT,
					ACTIVE_FLG = @ACTIVE_FLG,
					ADDRESSEE_NM = @ADDRESSEE_NM,
					ADDR1 = @ADDR1,
					ADDR2 = @ADDR2,
					ADDR3 = @ADDR3,
					CITY = @CITY,
					STATE_PROV_CD = @STATE_PROV_CD,
					POSTAL_CD = @POSTAL_CD,
					COUNTRY_CD = @COUNTRY_CD,
					CONTACT_NM = @CONTACT_NM,
					CONTACT_DSC = @CONTACT_DSC
				WHERE
					TERMINAL_ADDRESS_ID = @TERMINAL_ADDRESS_ID
				RETURNING
					MODIFY_USER, MODIFY_DT
				INTO
					@MODIFY_USER, @MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Modify_Dt = ClsConvert.ToDateTimeNullable(p[2].Value);
			Modify_User = ClsConvert.ToString(p[15].Value);
			return ret;
		}
		public override int Delete()
		{
			DbParameter[] p = new DbParameter[1];

			p[0] = Connection.GetParameter
				("@TERMINAL_ADDRESS_ID", Terminal_Address_ID);

			const string sql = @"
				DELETE FROM R_TERMINAL_ADDRESS WHERE
				TERMINAL_ADDRESS_ID=@TERMINAL_ADDRESS_ID";
			return Connection.RunSQL(sql, p);
		}
		#endregion		// #region Insert, Update, Delete

		#region Conversion methods

		public override void LoadFromDataReader(DbDataReader dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataReader: DataReader parameter was null");

			Terminal_Address_ID = ClsConvert.ToInt64Nullable(dr["TERMINAL_ADDRESS_ID"]);
			Terminal_Cd = ClsConvert.ToString(dr["TERMINAL_CD"]);
			Terminal_Section_Cd = ClsConvert.ToString(dr["TERMINAL_SECTION_CD"]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER"]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT"]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER"]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT"]);
			Active_Flg = ClsConvert.ToString(dr["ACTIVE_FLG"]);
			Addressee_Nm = ClsConvert.ToString(dr["ADDRESSEE_NM"]);
			Addr1 = ClsConvert.ToString(dr["ADDR1"]);
			Addr2 = ClsConvert.ToString(dr["ADDR2"]);
			Addr3 = ClsConvert.ToString(dr["ADDR3"]);
			City = ClsConvert.ToString(dr["CITY"]);
			State_Prov_Cd = ClsConvert.ToString(dr["STATE_PROV_CD"]);
			Postal_Cd = ClsConvert.ToString(dr["POSTAL_CD"]);
			Country_Cd = ClsConvert.ToString(dr["COUNTRY_CD"]);
			Contact_Nm = ClsConvert.ToString(dr["CONTACT_NM"]);
			Contact_Dsc = ClsConvert.ToString(dr["CONTACT_DSC"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Terminal_Address_ID = ClsConvert.ToInt64Nullable(dr["TERMINAL_ADDRESS_ID", v]);
			Terminal_Cd = ClsConvert.ToString(dr["TERMINAL_CD", v]);
			Terminal_Section_Cd = ClsConvert.ToString(dr["TERMINAL_SECTION_CD", v]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER", v]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT", v]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER", v]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT", v]);
			Active_Flg = ClsConvert.ToString(dr["ACTIVE_FLG", v]);
			Addressee_Nm = ClsConvert.ToString(dr["ADDRESSEE_NM", v]);
			Addr1 = ClsConvert.ToString(dr["ADDR1", v]);
			Addr2 = ClsConvert.ToString(dr["ADDR2", v]);
			Addr3 = ClsConvert.ToString(dr["ADDR3", v]);
			City = ClsConvert.ToString(dr["CITY", v]);
			State_Prov_Cd = ClsConvert.ToString(dr["STATE_PROV_CD", v]);
			Postal_Cd = ClsConvert.ToString(dr["POSTAL_CD", v]);
			Country_Cd = ClsConvert.ToString(dr["COUNTRY_CD", v]);
			Contact_Nm = ClsConvert.ToString(dr["CONTACT_NM", v]);
			Contact_Dsc = ClsConvert.ToString(dr["CONTACT_DSC", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["TERMINAL_ADDRESS_ID"] = ClsConvert.ToDbObject(Terminal_Address_ID);
			dr["TERMINAL_CD"] = ClsConvert.ToDbObject(Terminal_Cd);
			dr["TERMINAL_SECTION_CD"] = ClsConvert.ToDbObject(Terminal_Section_Cd);
			dr["CREATE_USER"] = ClsConvert.ToDbObject(Create_User);
			dr["CREATE_DT"] = ClsConvert.ToDbObject(Create_Dt);
			dr["MODIFY_USER"] = ClsConvert.ToDbObject(Modify_User);
			dr["MODIFY_DT"] = ClsConvert.ToDbObject(Modify_Dt);
			dr["ACTIVE_FLG"] = ClsConvert.ToDbObject(Active_Flg);
			dr["ADDRESSEE_NM"] = ClsConvert.ToDbObject(Addressee_Nm);
			dr["ADDR1"] = ClsConvert.ToDbObject(Addr1);
			dr["ADDR2"] = ClsConvert.ToDbObject(Addr2);
			dr["ADDR3"] = ClsConvert.ToDbObject(Addr3);
			dr["CITY"] = ClsConvert.ToDbObject(City);
			dr["STATE_PROV_CD"] = ClsConvert.ToDbObject(State_Prov_Cd);
			dr["POSTAL_CD"] = ClsConvert.ToDbObject(Postal_Cd);
			dr["COUNTRY_CD"] = ClsConvert.ToDbObject(Country_Cd);
			dr["CONTACT_NM"] = ClsConvert.ToDbObject(Contact_Nm);
			dr["CONTACT_DSC"] = ClsConvert.ToDbObject(Contact_Dsc);
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

		public static ClsTerminalAddress GetUsingKey(Int64 Terminal_Address_ID)
		{
			object[] vals = new object[] {Terminal_Address_ID};
			DataRow dr = Connection.GetDataRowUsingKey
				(TableName, GetPrimaryKeys(), vals);
			return ( dr == null ) ? null : new ClsTerminalAddress(dr);
		}
		public static DataTable GetAll(string Terminal_Cd, string Terminal_Section_Cd)
		{
			List<DbParameter> lst = new List<DbParameter>();	
			StringBuilder sb = new StringBuilder();
		
			if( string.IsNullOrEmpty(Terminal_Cd) == false )
			{
				lst.Add(Connection.GetParameter("@TERMINAL_CD", Terminal_Cd));
				sb.Append(" WHERE R_TERMINAL_ADDRESS.TERMINAL_CD=@TERMINAL_CD");
			}
			if( string.IsNullOrEmpty(Terminal_Section_Cd) == false )
			{
				lst.Add(Connection.GetParameter("@TERMINAL_SECTION_CD", Terminal_Section_Cd));
				sb.AppendFormat(" {0} R_TERMINAL_ADDRESS.TERMINAL_SECTION_CD=@TERMINAL_SECTION_CD",
					sb.Length > 0 ? "AND" : "WHERE");
			}
			sb.Insert(0, SelectSQL);
			return Connection.GetDataTable(sb.ToString(), lst.ToArray());
		}
		#endregion		// #region Static Methods
	}
}