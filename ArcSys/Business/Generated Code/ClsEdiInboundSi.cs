using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsEdiInboundSi : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ArcSys"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "T_EDI_INBOUND_SI";
		public const int PrimaryKeyCount = 1;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] { "EDI_INBOUND_SI_ID" };
		}

		public const string SelectSQL = "SELECT * FROM T_EDI_INBOUND_SI";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Create_UserMax = 30;
		public const int Modify_UserMax = 30;
		public const int Booking_NoMax = 20;
		public const int VinMax = 30;
		public const int First_NmMax = 40;
		public const int Last_NmMax = 40;
		public const int Addr1Max = 100;
		public const int Addr2Max = 100;
		public const int Addr3Max = 100;
		public const int CityMax = 50;
		public const int State_CdMax = 2;
		public const int Country_CdMax = 3;
		public const int Zip_CdMax = 10;
		public const int Processed_FlgMax = 1;
		public const int Process_MsgMax = 500;
		public const int Source_FileMax = 200;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected Int64? _Edi_Inbound_Si_ID;
		protected string _Create_User;
		protected DateTime? _Create_Dt;
		protected string _Modify_User;
		protected DateTime? _Modify_Dt;
		protected Int64? _Trans_Ctl_No;
		protected string _Booking_No;
		protected string _Vin;
		protected string _First_Nm;
		protected string _Last_Nm;
		protected string _Addr1;
		protected string _Addr2;
		protected string _Addr3;
		protected string _City;
		protected string _State_Cd;
		protected string _Country_Cd;
		protected string _Zip_Cd;
		protected string _Processed_Flg;
		protected string _Process_Msg;
		protected string _Source_File;

		#endregion	// #region Column Fields

		#region Column Properties

		public Int64? Edi_Inbound_Si_ID
		{
			get { return _Edi_Inbound_Si_ID; }
			set
			{
				if( _Edi_Inbound_Si_ID == value ) return;
		
				_Edi_Inbound_Si_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Edi_Inbound_Si_ID");
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
		public Int64? Trans_Ctl_No
		{
			get { return _Trans_Ctl_No; }
			set
			{
				if( _Trans_Ctl_No == value ) return;
		
				_Trans_Ctl_No = value;
				_IsDirty = true;
				NotifyPropertyChanged("Trans_Ctl_No");
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
		public string Vin
		{
			get { return _Vin; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Vin, val, false) == 0 ) return;
		
				if( val != null && val.Length > VinMax )
					_Vin = val.Substring(0, (int)VinMax);
				else
					_Vin = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Vin");
			}
		}
		public string First_Nm
		{
			get { return _First_Nm; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_First_Nm, val, false) == 0 ) return;
		
				if( val != null && val.Length > First_NmMax )
					_First_Nm = val.Substring(0, (int)First_NmMax);
				else
					_First_Nm = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("First_Nm");
			}
		}
		public string Last_Nm
		{
			get { return _Last_Nm; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Last_Nm, val, false) == 0 ) return;
		
				if( val != null && val.Length > Last_NmMax )
					_Last_Nm = val.Substring(0, (int)Last_NmMax);
				else
					_Last_Nm = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Last_Nm");
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
		public string State_Cd
		{
			get { return _State_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_State_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > State_CdMax )
					_State_Cd = val.Substring(0, (int)State_CdMax);
				else
					_State_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("State_Cd");
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
		public string Source_File
		{
			get { return _Source_File; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Source_File, val, false) == 0 ) return;
		
				if( val != null && val.Length > Source_FileMax )
					_Source_File = val.Substring(0, (int)Source_FileMax);
				else
					_Source_File = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Source_File");
			}
		}

		#endregion	// #region Column Properties

		#region Foreign Key Fields



		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties



		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsEdiInboundSi() : base() {}
		public ClsEdiInboundSi(DataRow dr) : base(dr) {}
		public ClsEdiInboundSi(ClsEdiInboundSi src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Edi_Inbound_Si_ID = null;
			Create_User = null;
			Create_Dt = null;
			Modify_User = null;
			Modify_Dt = null;
			Trans_Ctl_No = null;
			Booking_No = null;
			Vin = null;
			First_Nm = null;
			Last_Nm = null;
			Addr1 = null;
			Addr2 = null;
			Addr3 = null;
			City = null;
			State_Cd = null;
			Country_Cd = null;
			Zip_Cd = null;
			Processed_Flg = null;
			Process_Msg = null;
			Source_File = null;
		}

		public void CopyFrom(ClsEdiInboundSi src)
		{
			Edi_Inbound_Si_ID = src._Edi_Inbound_Si_ID;
			Create_User = src._Create_User;
			Create_Dt = src._Create_Dt;
			Modify_User = src._Modify_User;
			Modify_Dt = src._Modify_Dt;
			Trans_Ctl_No = src._Trans_Ctl_No;
			Booking_No = src._Booking_No;
			Vin = src._Vin;
			First_Nm = src._First_Nm;
			Last_Nm = src._Last_Nm;
			Addr1 = src._Addr1;
			Addr2 = src._Addr2;
			Addr3 = src._Addr3;
			City = src._City;
			State_Cd = src._State_Cd;
			Country_Cd = src._Country_Cd;
			Zip_Cd = src._Zip_Cd;
			Processed_Flg = src._Processed_Flg;
			Process_Msg = src._Process_Msg;
			Source_File = src._Source_File;
		}

		public override bool ReloadFromDB()
		{
			ClsEdiInboundSi tmp = ClsEdiInboundSi.GetUsingKey(Edi_Inbound_Si_ID.Value);
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
				("@TRANS_CTL_NO", Trans_Ctl_No);
			p[1] = Connection.GetParameter
				("@BOOKING_NO", Booking_No);
			p[2] = Connection.GetParameter
				("@VIN", Vin);
			p[3] = Connection.GetParameter
				("@FIRST_NM", First_Nm);
			p[4] = Connection.GetParameter
				("@LAST_NM", Last_Nm);
			p[5] = Connection.GetParameter
				("@ADDR1", Addr1);
			p[6] = Connection.GetParameter
				("@ADDR2", Addr2);
			p[7] = Connection.GetParameter
				("@ADDR3", Addr3);
			p[8] = Connection.GetParameter
				("@CITY", City);
			p[9] = Connection.GetParameter
				("@STATE_CD", State_Cd);
			p[10] = Connection.GetParameter
				("@COUNTRY_CD", Country_Cd);
			p[11] = Connection.GetParameter
				("@ZIP_CD", Zip_Cd);
			p[12] = Connection.GetParameter
				("@PROCESSED_FLG", Processed_Flg);
			p[13] = Connection.GetParameter
				("@PROCESS_MSG", Process_Msg);
			p[14] = Connection.GetParameter
				("@SOURCE_FILE", Source_File);
			p[15] = Connection.GetParameter
				("@EDI_INBOUND_SI_ID", Edi_Inbound_Si_ID, ParameterDirection.Output, DbType.Int64, 0);
			p[16] = Connection.GetParameter
				("@CREATE_USER", Create_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Create_UserMax);
			p[17] = Connection.GetParameter
				("@CREATE_DT", Create_Dt, ParameterDirection.Output, DbType.DateTime, 0);
			p[18] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);
			p[19] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.Output, DbType.DateTime, 0);

			const string sql = @"
				INSERT INTO T_EDI_INBOUND_SI
					(EDI_INBOUND_SI_ID, TRANS_CTL_NO, BOOKING_NO,
					VIN, FIRST_NM, LAST_NM,
					ADDR1, ADDR2, ADDR3,
					CITY, STATE_CD, COUNTRY_CD,
					ZIP_CD, PROCESSED_FLG, PROCESS_MSG,
					SOURCE_FILE)
				VALUES
					(EDI_INBOUND_SI_ID_SEQ.NEXTVAL, @TRANS_CTL_NO, @BOOKING_NO,
					@VIN, @FIRST_NM, @LAST_NM,
					@ADDR1, @ADDR2, @ADDR3,
					@CITY, @STATE_CD, @COUNTRY_CD,
					@ZIP_CD, @PROCESSED_FLG, @PROCESS_MSG,
					@SOURCE_FILE)
				RETURNING
					EDI_INBOUND_SI_ID, CREATE_USER, CREATE_DT,
					MODIFY_USER, MODIFY_DT
				INTO
					@EDI_INBOUND_SI_ID, @CREATE_USER, @CREATE_DT,
					@MODIFY_USER, @MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Edi_Inbound_Si_ID = ClsConvert.ToInt64Nullable(p[15].Value);
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
				("@TRANS_CTL_NO", Trans_Ctl_No);
			p[2] = Connection.GetParameter
				("@BOOKING_NO", Booking_No);
			p[3] = Connection.GetParameter
				("@VIN", Vin);
			p[4] = Connection.GetParameter
				("@FIRST_NM", First_Nm);
			p[5] = Connection.GetParameter
				("@LAST_NM", Last_Nm);
			p[6] = Connection.GetParameter
				("@ADDR1", Addr1);
			p[7] = Connection.GetParameter
				("@ADDR2", Addr2);
			p[8] = Connection.GetParameter
				("@ADDR3", Addr3);
			p[9] = Connection.GetParameter
				("@CITY", City);
			p[10] = Connection.GetParameter
				("@STATE_CD", State_Cd);
			p[11] = Connection.GetParameter
				("@COUNTRY_CD", Country_Cd);
			p[12] = Connection.GetParameter
				("@ZIP_CD", Zip_Cd);
			p[13] = Connection.GetParameter
				("@PROCESSED_FLG", Processed_Flg);
			p[14] = Connection.GetParameter
				("@PROCESS_MSG", Process_Msg);
			p[15] = Connection.GetParameter
				("@SOURCE_FILE", Source_File);
			p[16] = Connection.GetParameter
				("@EDI_INBOUND_SI_ID", Edi_Inbound_Si_ID);
			p[17] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);

			const string sql = @"
				UPDATE T_EDI_INBOUND_SI SET
					MODIFY_DT = @MODIFY_DT,
					TRANS_CTL_NO = @TRANS_CTL_NO,
					BOOKING_NO = @BOOKING_NO,
					VIN = @VIN,
					FIRST_NM = @FIRST_NM,
					LAST_NM = @LAST_NM,
					ADDR1 = @ADDR1,
					ADDR2 = @ADDR2,
					ADDR3 = @ADDR3,
					CITY = @CITY,
					STATE_CD = @STATE_CD,
					COUNTRY_CD = @COUNTRY_CD,
					ZIP_CD = @ZIP_CD,
					PROCESSED_FLG = @PROCESSED_FLG,
					PROCESS_MSG = @PROCESS_MSG,
					SOURCE_FILE = @SOURCE_FILE
				WHERE
					EDI_INBOUND_SI_ID = @EDI_INBOUND_SI_ID
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

			Edi_Inbound_Si_ID = ClsConvert.ToInt64Nullable(dr["EDI_INBOUND_SI_ID"]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER"]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT"]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER"]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT"]);
			Trans_Ctl_No = ClsConvert.ToInt64Nullable(dr["TRANS_CTL_NO"]);
			Booking_No = ClsConvert.ToString(dr["BOOKING_NO"]);
			Vin = ClsConvert.ToString(dr["VIN"]);
			First_Nm = ClsConvert.ToString(dr["FIRST_NM"]);
			Last_Nm = ClsConvert.ToString(dr["LAST_NM"]);
			Addr1 = ClsConvert.ToString(dr["ADDR1"]);
			Addr2 = ClsConvert.ToString(dr["ADDR2"]);
			Addr3 = ClsConvert.ToString(dr["ADDR3"]);
			City = ClsConvert.ToString(dr["CITY"]);
			State_Cd = ClsConvert.ToString(dr["STATE_CD"]);
			Country_Cd = ClsConvert.ToString(dr["COUNTRY_CD"]);
			Zip_Cd = ClsConvert.ToString(dr["ZIP_CD"]);
			Processed_Flg = ClsConvert.ToString(dr["PROCESSED_FLG"]);
			Process_Msg = ClsConvert.ToString(dr["PROCESS_MSG"]);
			Source_File = ClsConvert.ToString(dr["SOURCE_FILE"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Edi_Inbound_Si_ID = ClsConvert.ToInt64Nullable(dr["EDI_INBOUND_SI_ID", v]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER", v]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT", v]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER", v]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT", v]);
			Trans_Ctl_No = ClsConvert.ToInt64Nullable(dr["TRANS_CTL_NO", v]);
			Booking_No = ClsConvert.ToString(dr["BOOKING_NO", v]);
			Vin = ClsConvert.ToString(dr["VIN", v]);
			First_Nm = ClsConvert.ToString(dr["FIRST_NM", v]);
			Last_Nm = ClsConvert.ToString(dr["LAST_NM", v]);
			Addr1 = ClsConvert.ToString(dr["ADDR1", v]);
			Addr2 = ClsConvert.ToString(dr["ADDR2", v]);
			Addr3 = ClsConvert.ToString(dr["ADDR3", v]);
			City = ClsConvert.ToString(dr["CITY", v]);
			State_Cd = ClsConvert.ToString(dr["STATE_CD", v]);
			Country_Cd = ClsConvert.ToString(dr["COUNTRY_CD", v]);
			Zip_Cd = ClsConvert.ToString(dr["ZIP_CD", v]);
			Processed_Flg = ClsConvert.ToString(dr["PROCESSED_FLG", v]);
			Process_Msg = ClsConvert.ToString(dr["PROCESS_MSG", v]);
			Source_File = ClsConvert.ToString(dr["SOURCE_FILE", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["EDI_INBOUND_SI_ID"] = ClsConvert.ToDbObject(Edi_Inbound_Si_ID);
			dr["CREATE_USER"] = ClsConvert.ToDbObject(Create_User);
			dr["CREATE_DT"] = ClsConvert.ToDbObject(Create_Dt);
			dr["MODIFY_USER"] = ClsConvert.ToDbObject(Modify_User);
			dr["MODIFY_DT"] = ClsConvert.ToDbObject(Modify_Dt);
			dr["TRANS_CTL_NO"] = ClsConvert.ToDbObject(Trans_Ctl_No);
			dr["BOOKING_NO"] = ClsConvert.ToDbObject(Booking_No);
			dr["VIN"] = ClsConvert.ToDbObject(Vin);
			dr["FIRST_NM"] = ClsConvert.ToDbObject(First_Nm);
			dr["LAST_NM"] = ClsConvert.ToDbObject(Last_Nm);
			dr["ADDR1"] = ClsConvert.ToDbObject(Addr1);
			dr["ADDR2"] = ClsConvert.ToDbObject(Addr2);
			dr["ADDR3"] = ClsConvert.ToDbObject(Addr3);
			dr["CITY"] = ClsConvert.ToDbObject(City);
			dr["STATE_CD"] = ClsConvert.ToDbObject(State_Cd);
			dr["COUNTRY_CD"] = ClsConvert.ToDbObject(Country_Cd);
			dr["ZIP_CD"] = ClsConvert.ToDbObject(Zip_Cd);
			dr["PROCESSED_FLG"] = ClsConvert.ToDbObject(Processed_Flg);
			dr["PROCESS_MSG"] = ClsConvert.ToDbObject(Process_Msg);
			dr["SOURCE_FILE"] = ClsConvert.ToDbObject(Source_File);
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

		public static ClsEdiInboundSi GetUsingKey(Int64 Edi_Inbound_Si_ID)
		{
			object[] vals = new object[] {Edi_Inbound_Si_ID};
			DataRow dr = Connection.GetDataRowUsingKey
				(TableName, GetPrimaryKeys(), vals);
			return ( dr == null ) ? null : new ClsEdiInboundSi(dr);
		}

		#endregion		// #region Static Methods
	}
}