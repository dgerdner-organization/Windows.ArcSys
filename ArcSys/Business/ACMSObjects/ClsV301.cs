using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ACMS.Business
{
	public partial class ClsV301 : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ACMS"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "V_301";
		public const int PrimaryKeyCount = 0;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] {  };
		}

		public const string SelectSQL = "SELECT * FROM V_301";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Partner_CdMax = 15;
		public const int Partner_Request_CdMax = 30;
		public const int Contract_NoMax = 30;
		public const int Vessel_IrccMax = 20;
		public const int Vessel_DscMax = 30;
		public const int Req_NameMax = 30;
		public const int Req_AddressMax = 30;
		public const int Req_StateMax = 30;
		public const int Req_ZipMax = 20;
		public const int Shipper_NameMax = 30;
		public const int Shipper_AddressMax = 30;
		public const int Shipper_StateMax = 30;
		public const int Shipper_ZipMax = 20;
		public const int Booker_NameMax = 30;
		public const int Booker_AddressMax = 30;
		public const int Booker_StateMax = 30;
		public const int Booker_ZipMax = 20;
		public const int Rcvr_NameMax = 30;
		public const int Rcvr_AddressMax = 30;
		public const int Rcvr_StateMax = 30;
		public const int Rcvr_ZipMax = 20;
		public const int TcnMax = 30;
		public const int Commodity_CdMax = 30;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected Int64? _Trans_Ctl_No;
		protected Int64? _Trans_Seq_No;
		protected string _Partner_Cd;
		protected string _Partner_Request_Cd;
		protected string _Contract_No;
		protected string _Vessel_Ircc;
		protected string _Vessel_Dsc;
		protected string _Req_Name;
		protected string _Req_Address;
		protected string _Req_State;
		protected string _Req_Zip;
		protected string _Shipper_Name;
		protected string _Shipper_Address;
		protected string _Shipper_State;
		protected string _Shipper_Zip;
		protected string _Booker_Name;
		protected string _Booker_Address;
		protected string _Booker_State;
		protected string _Booker_Zip;
		protected string _Rcvr_Name;
		protected string _Rcvr_Address;
		protected string _Rcvr_State;
		protected string _Rcvr_Zip;
		protected decimal? _Item_No;
		protected string _Tcn;
		protected string _Commodity_Cd;

		#endregion	// #region Column Fields

		#region Column Properties

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
		public Int64? Trans_Seq_No
		{
			get { return _Trans_Seq_No; }
			set
			{
				if( _Trans_Seq_No == value ) return;
		
				_Trans_Seq_No = value;
				_IsDirty = true;
				NotifyPropertyChanged("Trans_Seq_No");
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
		public string Contract_No
		{
			get { return _Contract_No; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Contract_No, val, false) == 0 ) return;
		
				if( val != null && val.Length > Contract_NoMax )
					_Contract_No = val.Substring(0, (int)Contract_NoMax);
				else
					_Contract_No = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Contract_No");
			}
		}
		public string Vessel_Ircc
		{
			get { return _Vessel_Ircc; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Vessel_Ircc, val, false) == 0 ) return;
		
				if( val != null && val.Length > Vessel_IrccMax )
					_Vessel_Ircc = val.Substring(0, (int)Vessel_IrccMax);
				else
					_Vessel_Ircc = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Vessel_Ircc");
			}
		}
		public string Vessel_Dsc
		{
			get { return _Vessel_Dsc; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Vessel_Dsc, val, false) == 0 ) return;
		
				if( val != null && val.Length > Vessel_DscMax )
					_Vessel_Dsc = val.Substring(0, (int)Vessel_DscMax);
				else
					_Vessel_Dsc = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Vessel_Dsc");
			}
		}
		public string Req_Name
		{
			get { return _Req_Name; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Req_Name, val, false) == 0 ) return;
		
				if( val != null && val.Length > Req_NameMax )
					_Req_Name = val.Substring(0, (int)Req_NameMax);
				else
					_Req_Name = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Req_Name");
			}
		}
		public string Req_Address
		{
			get { return _Req_Address; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Req_Address, val, false) == 0 ) return;
		
				if( val != null && val.Length > Req_AddressMax )
					_Req_Address = val.Substring(0, (int)Req_AddressMax);
				else
					_Req_Address = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Req_Address");
			}
		}
		public string Req_State
		{
			get { return _Req_State; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Req_State, val, false) == 0 ) return;
		
				if( val != null && val.Length > Req_StateMax )
					_Req_State = val.Substring(0, (int)Req_StateMax);
				else
					_Req_State = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Req_State");
			}
		}
		public string Req_Zip
		{
			get { return _Req_Zip; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Req_Zip, val, false) == 0 ) return;
		
				if( val != null && val.Length > Req_ZipMax )
					_Req_Zip = val.Substring(0, (int)Req_ZipMax);
				else
					_Req_Zip = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Req_Zip");
			}
		}
		public string Shipper_Name
		{
			get { return _Shipper_Name; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Shipper_Name, val, false) == 0 ) return;
		
				if( val != null && val.Length > Shipper_NameMax )
					_Shipper_Name = val.Substring(0, (int)Shipper_NameMax);
				else
					_Shipper_Name = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Shipper_Name");
			}
		}
		public string Shipper_Address
		{
			get { return _Shipper_Address; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Shipper_Address, val, false) == 0 ) return;
		
				if( val != null && val.Length > Shipper_AddressMax )
					_Shipper_Address = val.Substring(0, (int)Shipper_AddressMax);
				else
					_Shipper_Address = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Shipper_Address");
			}
		}
		public string Shipper_State
		{
			get { return _Shipper_State; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Shipper_State, val, false) == 0 ) return;
		
				if( val != null && val.Length > Shipper_StateMax )
					_Shipper_State = val.Substring(0, (int)Shipper_StateMax);
				else
					_Shipper_State = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Shipper_State");
			}
		}
		public string Shipper_Zip
		{
			get { return _Shipper_Zip; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Shipper_Zip, val, false) == 0 ) return;
		
				if( val != null && val.Length > Shipper_ZipMax )
					_Shipper_Zip = val.Substring(0, (int)Shipper_ZipMax);
				else
					_Shipper_Zip = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Shipper_Zip");
			}
		}
		public string Booker_Name
		{
			get { return _Booker_Name; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Booker_Name, val, false) == 0 ) return;
		
				if( val != null && val.Length > Booker_NameMax )
					_Booker_Name = val.Substring(0, (int)Booker_NameMax);
				else
					_Booker_Name = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Booker_Name");
			}
		}
		public string Booker_Address
		{
			get { return _Booker_Address; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Booker_Address, val, false) == 0 ) return;
		
				if( val != null && val.Length > Booker_AddressMax )
					_Booker_Address = val.Substring(0, (int)Booker_AddressMax);
				else
					_Booker_Address = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Booker_Address");
			}
		}
		public string Booker_State
		{
			get { return _Booker_State; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Booker_State, val, false) == 0 ) return;
		
				if( val != null && val.Length > Booker_StateMax )
					_Booker_State = val.Substring(0, (int)Booker_StateMax);
				else
					_Booker_State = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Booker_State");
			}
		}
		public string Booker_Zip
		{
			get { return _Booker_Zip; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Booker_Zip, val, false) == 0 ) return;
		
				if( val != null && val.Length > Booker_ZipMax )
					_Booker_Zip = val.Substring(0, (int)Booker_ZipMax);
				else
					_Booker_Zip = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Booker_Zip");
			}
		}
		public string Rcvr_Name
		{
			get { return _Rcvr_Name; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Rcvr_Name, val, false) == 0 ) return;
		
				if( val != null && val.Length > Rcvr_NameMax )
					_Rcvr_Name = val.Substring(0, (int)Rcvr_NameMax);
				else
					_Rcvr_Name = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Rcvr_Name");
			}
		}
		public string Rcvr_Address
		{
			get { return _Rcvr_Address; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Rcvr_Address, val, false) == 0 ) return;
		
				if( val != null && val.Length > Rcvr_AddressMax )
					_Rcvr_Address = val.Substring(0, (int)Rcvr_AddressMax);
				else
					_Rcvr_Address = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Rcvr_Address");
			}
		}
		public string Rcvr_State
		{
			get { return _Rcvr_State; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Rcvr_State, val, false) == 0 ) return;
		
				if( val != null && val.Length > Rcvr_StateMax )
					_Rcvr_State = val.Substring(0, (int)Rcvr_StateMax);
				else
					_Rcvr_State = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Rcvr_State");
			}
		}
		public string Rcvr_Zip
		{
			get { return _Rcvr_Zip; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Rcvr_Zip, val, false) == 0 ) return;
		
				if( val != null && val.Length > Rcvr_ZipMax )
					_Rcvr_Zip = val.Substring(0, (int)Rcvr_ZipMax);
				else
					_Rcvr_Zip = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Rcvr_Zip");
			}
		}
		public decimal? Item_No
		{
			get { return _Item_No; }
			set
			{
				if( _Item_No == value ) return;
		
				_Item_No = value;
				_IsDirty = true;
				NotifyPropertyChanged("Item_No");
			}
		}
		public string Tcn
		{
			get { return _Tcn; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Tcn, val, false) == 0 ) return;
		
				if( val != null && val.Length > TcnMax )
					_Tcn = val.Substring(0, (int)TcnMax);
				else
					_Tcn = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Tcn");
			}
		}
		public string Commodity_Cd
		{
			get { return _Commodity_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Commodity_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Commodity_CdMax )
					_Commodity_Cd = val.Substring(0, (int)Commodity_CdMax);
				else
					_Commodity_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Commodity_Cd");
			}
		}

		#endregion	// #region Column Properties

		#region Foreign Key Fields



		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties



		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsV301() : base() {}
		public ClsV301(DataRow dr) : base(dr) {}
		public ClsV301(ClsV301 src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Trans_Ctl_No = null;
			Trans_Seq_No = null;
			Partner_Cd = null;
			Partner_Request_Cd = null;
			Contract_No = null;
			Vessel_Ircc = null;
			Vessel_Dsc = null;
			Req_Name = null;
			Req_Address = null;
			Req_State = null;
			Req_Zip = null;
			Shipper_Name = null;
			Shipper_Address = null;
			Shipper_State = null;
			Shipper_Zip = null;
			Booker_Name = null;
			Booker_Address = null;
			Booker_State = null;
			Booker_Zip = null;
			Rcvr_Name = null;
			Rcvr_Address = null;
			Rcvr_State = null;
			Rcvr_Zip = null;
			Item_No = null;
			Tcn = null;
			Commodity_Cd = null;
		}

		public void CopyFrom(ClsV301 src)
		{
			Trans_Ctl_No = src._Trans_Ctl_No;
			Trans_Seq_No = src._Trans_Seq_No;
			Partner_Cd = src._Partner_Cd;
			Partner_Request_Cd = src._Partner_Request_Cd;
			Contract_No = src._Contract_No;
			Vessel_Ircc = src._Vessel_Ircc;
			Vessel_Dsc = src._Vessel_Dsc;
			Req_Name = src._Req_Name;
			Req_Address = src._Req_Address;
			Req_State = src._Req_State;
			Req_Zip = src._Req_Zip;
			Shipper_Name = src._Shipper_Name;
			Shipper_Address = src._Shipper_Address;
			Shipper_State = src._Shipper_State;
			Shipper_Zip = src._Shipper_Zip;
			Booker_Name = src._Booker_Name;
			Booker_Address = src._Booker_Address;
			Booker_State = src._Booker_State;
			Booker_Zip = src._Booker_Zip;
			Rcvr_Name = src._Rcvr_Name;
			Rcvr_Address = src._Rcvr_Address;
			Rcvr_State = src._Rcvr_State;
			Rcvr_Zip = src._Rcvr_Zip;
			Item_No = src._Item_No;
			Tcn = src._Tcn;
			Commodity_Cd = src._Commodity_Cd;
		}

		public override bool ReloadFromDB()
		{
			ClsV301 tmp = null;	//No primary key can't refresh;
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
				("@TRANS_CTL_NO", Trans_Ctl_No);
			p[1] = Connection.GetParameter
				("@TRANS_SEQ_NO", Trans_Seq_No);
			p[2] = Connection.GetParameter
				("@PARTNER_CD", Partner_Cd);
			p[3] = Connection.GetParameter
				("@PARTNER_REQUEST_CD", Partner_Request_Cd);
			p[4] = Connection.GetParameter
				("@CONTRACT_NO", Contract_No);
			p[5] = Connection.GetParameter
				("@VESSEL_IRCC", Vessel_Ircc);
			p[6] = Connection.GetParameter
				("@VESSEL_DSC", Vessel_Dsc);
			p[7] = Connection.GetParameter
				("@REQ_NAME", Req_Name);
			p[8] = Connection.GetParameter
				("@REQ_ADDRESS", Req_Address);
			p[9] = Connection.GetParameter
				("@REQ_STATE", Req_State);
			p[10] = Connection.GetParameter
				("@REQ_ZIP", Req_Zip);
			p[11] = Connection.GetParameter
				("@SHIPPER_NAME", Shipper_Name);
			p[12] = Connection.GetParameter
				("@SHIPPER_ADDRESS", Shipper_Address);
			p[13] = Connection.GetParameter
				("@SHIPPER_STATE", Shipper_State);
			p[14] = Connection.GetParameter
				("@SHIPPER_ZIP", Shipper_Zip);
			p[15] = Connection.GetParameter
				("@BOOKER_NAME", Booker_Name);
			p[16] = Connection.GetParameter
				("@BOOKER_ADDRESS", Booker_Address);
			p[17] = Connection.GetParameter
				("@BOOKER_STATE", Booker_State);
			p[18] = Connection.GetParameter
				("@BOOKER_ZIP", Booker_Zip);
			p[19] = Connection.GetParameter
				("@RCVR_NAME", Rcvr_Name);
			p[20] = Connection.GetParameter
				("@RCVR_ADDRESS", Rcvr_Address);
			p[21] = Connection.GetParameter
				("@RCVR_STATE", Rcvr_State);
			p[22] = Connection.GetParameter
				("@RCVR_ZIP", Rcvr_Zip);
			p[23] = Connection.GetParameter
				("@ITEM_NO", Item_No);
			p[24] = Connection.GetParameter
				("@TCN", Tcn);
			p[25] = Connection.GetParameter
				("@COMMODITY_CD", Commodity_Cd);

			const string sql = @"
				INSERT INTO V_301
					(TRANS_CTL_NO, TRANS_SEQ_NO, PARTNER_CD,
					PARTNER_REQUEST_CD, CONTRACT_NO, VESSEL_IRCC,
					VESSEL_DSC, REQ_NAME, REQ_ADDRESS,
					REQ_STATE, REQ_ZIP, SHIPPER_NAME,
					SHIPPER_ADDRESS, SHIPPER_STATE, SHIPPER_ZIP,
					BOOKER_NAME, BOOKER_ADDRESS, BOOKER_STATE,
					BOOKER_ZIP, RCVR_NAME, RCVR_ADDRESS,
					RCVR_STATE, RCVR_ZIP, ITEM_NO,
					TCN, COMMODITY_CD)
				VALUES
					(@TRANS_CTL_NO, @TRANS_SEQ_NO, @PARTNER_CD,
					@PARTNER_REQUEST_CD, @CONTRACT_NO, @VESSEL_IRCC,
					@VESSEL_DSC, @REQ_NAME, @REQ_ADDRESS,
					@REQ_STATE, @REQ_ZIP, @SHIPPER_NAME,
					@SHIPPER_ADDRESS, @SHIPPER_STATE, @SHIPPER_ZIP,
					@BOOKER_NAME, @BOOKER_ADDRESS, @BOOKER_STATE,
					@BOOKER_ZIP, @RCVR_NAME, @RCVR_ADDRESS,
					@RCVR_STATE, @RCVR_ZIP, @ITEM_NO,
					@TCN, @COMMODITY_CD)
				RETURNING
					
				INTO
					";
			int ret = Connection.RunSQL(sql, p);


			return ret;
		}
		public override int Update()
		{
			DbParameter[] p = new DbParameter[0];

			if( p.Length == 0 )
				throw new Exception
					("Cannot update table because there is no primary key");

			int ret = -1;


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

			Trans_Ctl_No = ClsConvert.ToInt64Nullable(dr["TRANS_CTL_NO"]);
			Trans_Seq_No = ClsConvert.ToInt64Nullable(dr["TRANS_SEQ_NO"]);
			Partner_Cd = ClsConvert.ToString(dr["PARTNER_CD"]);
			Partner_Request_Cd = ClsConvert.ToString(dr["PARTNER_REQUEST_CD"]);
			Contract_No = ClsConvert.ToString(dr["CONTRACT_NO"]);
			Vessel_Ircc = ClsConvert.ToString(dr["VESSEL_IRCC"]);
			Vessel_Dsc = ClsConvert.ToString(dr["VESSEL_DSC"]);
			Req_Name = ClsConvert.ToString(dr["REQ_NAME"]);
			Req_Address = ClsConvert.ToString(dr["REQ_ADDRESS"]);
			Req_State = ClsConvert.ToString(dr["REQ_STATE"]);
			Req_Zip = ClsConvert.ToString(dr["REQ_ZIP"]);
			Shipper_Name = ClsConvert.ToString(dr["SHIPPER_NAME"]);
			Shipper_Address = ClsConvert.ToString(dr["SHIPPER_ADDRESS"]);
			Shipper_State = ClsConvert.ToString(dr["SHIPPER_STATE"]);
			Shipper_Zip = ClsConvert.ToString(dr["SHIPPER_ZIP"]);
			Booker_Name = ClsConvert.ToString(dr["BOOKER_NAME"]);
			Booker_Address = ClsConvert.ToString(dr["BOOKER_ADDRESS"]);
			Booker_State = ClsConvert.ToString(dr["BOOKER_STATE"]);
			Booker_Zip = ClsConvert.ToString(dr["BOOKER_ZIP"]);
			Rcvr_Name = ClsConvert.ToString(dr["RCVR_NAME"]);
			Rcvr_Address = ClsConvert.ToString(dr["RCVR_ADDRESS"]);
			Rcvr_State = ClsConvert.ToString(dr["RCVR_STATE"]);
			Rcvr_Zip = ClsConvert.ToString(dr["RCVR_ZIP"]);
			Item_No = ClsConvert.ToDecimalNullable(dr["ITEM_NO"]);
			Tcn = ClsConvert.ToString(dr["TCN"]);
			Commodity_Cd = ClsConvert.ToString(dr["COMMODITY_CD"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Trans_Ctl_No = ClsConvert.ToInt64Nullable(dr["TRANS_CTL_NO", v]);
			Trans_Seq_No = ClsConvert.ToInt64Nullable(dr["TRANS_SEQ_NO", v]);
			Partner_Cd = ClsConvert.ToString(dr["PARTNER_CD", v]);
			Partner_Request_Cd = ClsConvert.ToString(dr["PARTNER_REQUEST_CD", v]);
			Contract_No = ClsConvert.ToString(dr["CONTRACT_NO", v]);
			Vessel_Ircc = ClsConvert.ToString(dr["VESSEL_IRCC", v]);
			Vessel_Dsc = ClsConvert.ToString(dr["VESSEL_DSC", v]);
			Req_Name = ClsConvert.ToString(dr["REQ_NAME", v]);
			Req_Address = ClsConvert.ToString(dr["REQ_ADDRESS", v]);
			Req_State = ClsConvert.ToString(dr["REQ_STATE", v]);
			Req_Zip = ClsConvert.ToString(dr["REQ_ZIP", v]);
			Shipper_Name = ClsConvert.ToString(dr["SHIPPER_NAME", v]);
			Shipper_Address = ClsConvert.ToString(dr["SHIPPER_ADDRESS", v]);
			Shipper_State = ClsConvert.ToString(dr["SHIPPER_STATE", v]);
			Shipper_Zip = ClsConvert.ToString(dr["SHIPPER_ZIP", v]);
			Booker_Name = ClsConvert.ToString(dr["BOOKER_NAME", v]);
			Booker_Address = ClsConvert.ToString(dr["BOOKER_ADDRESS", v]);
			Booker_State = ClsConvert.ToString(dr["BOOKER_STATE", v]);
			Booker_Zip = ClsConvert.ToString(dr["BOOKER_ZIP", v]);
			Rcvr_Name = ClsConvert.ToString(dr["RCVR_NAME", v]);
			Rcvr_Address = ClsConvert.ToString(dr["RCVR_ADDRESS", v]);
			Rcvr_State = ClsConvert.ToString(dr["RCVR_STATE", v]);
			Rcvr_Zip = ClsConvert.ToString(dr["RCVR_ZIP", v]);
			Item_No = ClsConvert.ToDecimalNullable(dr["ITEM_NO", v]);
			Tcn = ClsConvert.ToString(dr["TCN", v]);
			Commodity_Cd = ClsConvert.ToString(dr["COMMODITY_CD", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["TRANS_CTL_NO"] = ClsConvert.ToDbObject(Trans_Ctl_No);
			dr["TRANS_SEQ_NO"] = ClsConvert.ToDbObject(Trans_Seq_No);
			dr["PARTNER_CD"] = ClsConvert.ToDbObject(Partner_Cd);
			dr["PARTNER_REQUEST_CD"] = ClsConvert.ToDbObject(Partner_Request_Cd);
			dr["CONTRACT_NO"] = ClsConvert.ToDbObject(Contract_No);
			dr["VESSEL_IRCC"] = ClsConvert.ToDbObject(Vessel_Ircc);
			dr["VESSEL_DSC"] = ClsConvert.ToDbObject(Vessel_Dsc);
			dr["REQ_NAME"] = ClsConvert.ToDbObject(Req_Name);
			dr["REQ_ADDRESS"] = ClsConvert.ToDbObject(Req_Address);
			dr["REQ_STATE"] = ClsConvert.ToDbObject(Req_State);
			dr["REQ_ZIP"] = ClsConvert.ToDbObject(Req_Zip);
			dr["SHIPPER_NAME"] = ClsConvert.ToDbObject(Shipper_Name);
			dr["SHIPPER_ADDRESS"] = ClsConvert.ToDbObject(Shipper_Address);
			dr["SHIPPER_STATE"] = ClsConvert.ToDbObject(Shipper_State);
			dr["SHIPPER_ZIP"] = ClsConvert.ToDbObject(Shipper_Zip);
			dr["BOOKER_NAME"] = ClsConvert.ToDbObject(Booker_Name);
			dr["BOOKER_ADDRESS"] = ClsConvert.ToDbObject(Booker_Address);
			dr["BOOKER_STATE"] = ClsConvert.ToDbObject(Booker_State);
			dr["BOOKER_ZIP"] = ClsConvert.ToDbObject(Booker_Zip);
			dr["RCVR_NAME"] = ClsConvert.ToDbObject(Rcvr_Name);
			dr["RCVR_ADDRESS"] = ClsConvert.ToDbObject(Rcvr_Address);
			dr["RCVR_STATE"] = ClsConvert.ToDbObject(Rcvr_State);
			dr["RCVR_ZIP"] = ClsConvert.ToDbObject(Rcvr_Zip);
			dr["ITEM_NO"] = ClsConvert.ToDbObject(Item_No);
			dr["TCN"] = ClsConvert.ToDbObject(Tcn);
			dr["COMMODITY_CD"] = ClsConvert.ToDbObject(Commodity_Cd);
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