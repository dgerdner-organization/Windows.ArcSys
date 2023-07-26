using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsNhtsaRecall : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ArcSys"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "T_NHTSA_RECALL";
		public const int PrimaryKeyCount = 1;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] { "NHTSA_RECALL_ID" };
		}

		public const string SelectSQL = @"SELECT * FROM T_NHTSA_RECALL 
				INNER JOIN R_RECALL_STATUS
				ON T_NHTSA_RECALL.RECALL_STATUS_CD=R_RECALL_STATUS.RECALL_STATUS_CD
				INNER JOIN R_RECALL_RISK
				ON T_NHTSA_RECALL.RECALL_RISK_CD=R_RECALL_RISK.RECALL_RISK_CD ";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Create_UserMax = 30;
		public const int Modify_UserMax = 30;
		public const int VesselMax = 30;
		public const int VoyageMax = 10;
		public const int PolMax = 30;
		public const int PodMax = 30;
		public const int Booking_NoMax = 30;
		public const int Bol_NoMax = 30;
		public const int VinMax = 30;
		public const int Customer_NmMax = 25;
		public const int Car_MakeMax = 30;
		public const int Car_ModelMax = 30;
		public const int Recall_Status_CdMax = 5;
		public const int Recall_Risk_CdMax = 5;
		public const int Recall_KeywordsMax = 500;
		public const int Detail_UrlMax = 200;
		public const int Recall_UrlMax = 198;
		public const int Found_FlgMax = 1;
		public const int Detail_ResponseMax = 2147483647;
		public const int Recall_ResponseMax = 2147483647;
		public const int Recall_Response_FormattedMax = 2147483647;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected Int64? _Nhtsa_Recall_ID;
		protected string _Create_User;
		protected DateTime? _Create_Dt;
		protected string _Modify_User;
		protected DateTime? _Modify_Dt;
		protected string _Vessel;
		protected string _Voyage;
		protected string _Pol;
		protected string _Pod;
		protected DateTime? _Arrive_Dt;
		protected string _Booking_No;
		protected string _Bol_No;
		protected string _Vin;
		protected Int64? _Line_Booking_ID;
		protected decimal? _Line_Bol_ID;
		protected string _Customer_Nm;
		protected Int16? _Car_Year;
		protected string _Car_Make;
		protected string _Car_Model;
		protected string _Recall_Status_Cd;
		protected string _Recall_Risk_Cd;
		protected string _Recall_Keywords;
		protected string _Detail_Url;
		protected string _Recall_Url;
		protected string _Found_Flg;
		protected Int64? _Prev_Nhtsa_Recall_ID;
		protected string _Detail_Response;
		protected string _Recall_Response;
		protected string _Recall_Response_Formatted;

		#endregion	// #region Column Fields

		#region Column Properties

		public Int64? Nhtsa_Recall_ID
		{
			get { return _Nhtsa_Recall_ID; }
			set
			{
				if( _Nhtsa_Recall_ID == value ) return;
		
				_Nhtsa_Recall_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Nhtsa_Recall_ID");
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
		public string Vessel
		{
			get { return _Vessel; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Vessel, val, false) == 0 ) return;
		
				if( val != null && val.Length > VesselMax )
					_Vessel = val.Substring(0, (int)VesselMax);
				else
					_Vessel = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Vessel");
			}
		}
		public string Voyage
		{
			get { return _Voyage; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Voyage, val, false) == 0 ) return;
		
				if( val != null && val.Length > VoyageMax )
					_Voyage = val.Substring(0, (int)VoyageMax);
				else
					_Voyage = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Voyage");
			}
		}
		public string Pol
		{
			get { return _Pol; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Pol, val, false) == 0 ) return;
		
				if( val != null && val.Length > PolMax )
					_Pol = val.Substring(0, (int)PolMax);
				else
					_Pol = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Pol");
			}
		}
		public string Pod
		{
			get { return _Pod; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Pod, val, false) == 0 ) return;
		
				if( val != null && val.Length > PodMax )
					_Pod = val.Substring(0, (int)PodMax);
				else
					_Pod = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Pod");
			}
		}
		public DateTime? Arrive_Dt
		{
			get { return _Arrive_Dt; }
			set
			{
				if( _Arrive_Dt == value ) return;
		
				_Arrive_Dt = value;
				_IsDirty = true;
				NotifyPropertyChanged("Arrive_Dt");
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
		public Int64? Line_Booking_ID
		{
			get { return _Line_Booking_ID; }
			set
			{
				if( _Line_Booking_ID == value ) return;
		
				_Line_Booking_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Line_Booking_ID");
			}
		}
		public decimal? Line_Bol_ID
		{
			get { return _Line_Bol_ID; }
			set
			{
				if( _Line_Bol_ID == value ) return;
		
				_Line_Bol_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Line_Bol_ID");
			}
		}
		public string Customer_Nm
		{
			get { return _Customer_Nm; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Customer_Nm, val, false) == 0 ) return;
		
				if( val != null && val.Length > Customer_NmMax )
					_Customer_Nm = val.Substring(0, (int)Customer_NmMax);
				else
					_Customer_Nm = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Customer_Nm");
			}
		}
		public Int16? Car_Year
		{
			get { return _Car_Year; }
			set
			{
				if( _Car_Year == value ) return;
		
				_Car_Year = value;
				_IsDirty = true;
				NotifyPropertyChanged("Car_Year");
			}
		}
		public string Car_Make
		{
			get { return _Car_Make; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Car_Make, val, false) == 0 ) return;
		
				if( val != null && val.Length > Car_MakeMax )
					_Car_Make = val.Substring(0, (int)Car_MakeMax);
				else
					_Car_Make = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Car_Make");
			}
		}
		public string Car_Model
		{
			get { return _Car_Model; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Car_Model, val, false) == 0 ) return;
		
				if( val != null && val.Length > Car_ModelMax )
					_Car_Model = val.Substring(0, (int)Car_ModelMax);
				else
					_Car_Model = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Car_Model");
			}
		}
		public string Recall_Status_Cd
		{
			get { return _Recall_Status_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Recall_Status_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Recall_Status_CdMax )
					_Recall_Status_Cd = val.Substring(0, (int)Recall_Status_CdMax);
				else
					_Recall_Status_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Recall_Status_Cd");
			}
		}
		public string Recall_Risk_Cd
		{
			get { return _Recall_Risk_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Recall_Risk_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Recall_Risk_CdMax )
					_Recall_Risk_Cd = val.Substring(0, (int)Recall_Risk_CdMax);
				else
					_Recall_Risk_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Recall_Risk_Cd");
			}
		}
		public string Recall_Keywords
		{
			get { return _Recall_Keywords; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Recall_Keywords, val, false) == 0 ) return;
		
				if( val != null && val.Length > Recall_KeywordsMax )
					_Recall_Keywords = val.Substring(0, (int)Recall_KeywordsMax);
				else
					_Recall_Keywords = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Recall_Keywords");
			}
		}
		public string Detail_Url
		{
			get { return _Detail_Url; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Detail_Url, val, false) == 0 ) return;
		
				if( val != null && val.Length > Detail_UrlMax )
					_Detail_Url = val.Substring(0, (int)Detail_UrlMax);
				else
					_Detail_Url = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Detail_Url");
			}
		}
		public string Recall_Url
		{
			get { return _Recall_Url; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Recall_Url, val, false) == 0 ) return;
		
				if( val != null && val.Length > Recall_UrlMax )
					_Recall_Url = val.Substring(0, (int)Recall_UrlMax);
				else
					_Recall_Url = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Recall_Url");
			}
		}
		public string Found_Flg
		{
			get { return _Found_Flg; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Found_Flg, val, false) == 0 ) return;
		
				if( val != null && val.Length > Found_FlgMax )
					_Found_Flg = val.Substring(0, (int)Found_FlgMax);
				else
					_Found_Flg = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Found_Flg");
			}
		}
		public Int64? Prev_Nhtsa_Recall_ID
		{
			get { return _Prev_Nhtsa_Recall_ID; }
			set
			{
				if( _Prev_Nhtsa_Recall_ID == value ) return;
		
				_Prev_Nhtsa_Recall_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Prev_Nhtsa_Recall_ID");
			}
		}
		public string Detail_Response
		{
			get { return _Detail_Response; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Detail_Response, val, false) == 0 ) return;
		
				if( val != null && val.Length > Detail_ResponseMax )
					_Detail_Response = val.Substring(0, (int)Detail_ResponseMax);
				else
					_Detail_Response = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Detail_Response");
			}
		}
		public string Recall_Response
		{
			get { return _Recall_Response; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Recall_Response, val, false) == 0 ) return;
		
				if( val != null && val.Length > Recall_ResponseMax )
					_Recall_Response = val.Substring(0, (int)Recall_ResponseMax);
				else
					_Recall_Response = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Recall_Response");
			}
		}
		public string Recall_Response_Formatted
		{
			get { return _Recall_Response_Formatted; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Recall_Response_Formatted, val, false) == 0 ) return;
		
				if( val != null && val.Length > Recall_Response_FormattedMax )
					_Recall_Response_Formatted = val.Substring(0, (int)Recall_Response_FormattedMax);
				else
					_Recall_Response_Formatted = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Recall_Response_Formatted");
			}
		}

		#endregion	// #region Column Properties

		#region Foreign Key Fields

		protected ClsRecallStatus _Recall_Status;
		protected ClsRecallRisk _Recall_Risk;

		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties

		public ClsRecallStatus Recall_Status
		{
			get
			{
				if( Recall_Status_Cd == null )
					_Recall_Status = null;
				else if( _Recall_Status == null ||
					_Recall_Status.Recall_Status_Cd != Recall_Status_Cd )
					_Recall_Status = ClsRecallStatus.GetUsingKey(Recall_Status_Cd);
				return _Recall_Status;
			}
			set
			{
				if( _Recall_Status == value ) return;
		
				_Recall_Status = value;
			}
		}
		public ClsRecallRisk Recall_Risk
		{
			get
			{
				if( Recall_Risk_Cd == null )
					_Recall_Risk = null;
				else if( _Recall_Risk == null ||
					_Recall_Risk.Recall_Risk_Cd != Recall_Risk_Cd )
					_Recall_Risk = ClsRecallRisk.GetUsingKey(Recall_Risk_Cd);
				return _Recall_Risk;
			}
			set
			{
				if( _Recall_Risk == value ) return;
		
				_Recall_Risk = value;
			}
		}

		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsNhtsaRecall() : base() {}
		public ClsNhtsaRecall(DataRow dr) : base(dr) {}
		public ClsNhtsaRecall(ClsNhtsaRecall src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Nhtsa_Recall_ID = null;
			Create_User = null;
			Create_Dt = null;
			Modify_User = null;
			Modify_Dt = null;
			Vessel = null;
			Voyage = null;
			Pol = null;
			Pod = null;
			Arrive_Dt = null;
			Booking_No = null;
			Bol_No = null;
			Vin = null;
			Line_Booking_ID = null;
			Line_Bol_ID = null;
			Customer_Nm = null;
			Car_Year = null;
			Car_Make = null;
			Car_Model = null;
			Recall_Status_Cd = null;
			Recall_Risk_Cd = null;
			Recall_Keywords = null;
			Detail_Url = null;
			Recall_Url = null;
			Found_Flg = null;
			Prev_Nhtsa_Recall_ID = null;
			Detail_Response = null;
			Recall_Response = null;
			Recall_Response_Formatted = null;
		}

		public void CopyFrom(ClsNhtsaRecall src)
		{
			Nhtsa_Recall_ID = src._Nhtsa_Recall_ID;
			Create_User = src._Create_User;
			Create_Dt = src._Create_Dt;
			Modify_User = src._Modify_User;
			Modify_Dt = src._Modify_Dt;
			Vessel = src._Vessel;
			Voyage = src._Voyage;
			Pol = src._Pol;
			Pod = src._Pod;
			Arrive_Dt = src._Arrive_Dt;
			Booking_No = src._Booking_No;
			Bol_No = src._Bol_No;
			Vin = src._Vin;
			Line_Booking_ID = src._Line_Booking_ID;
			Line_Bol_ID = src._Line_Bol_ID;
			Customer_Nm = src._Customer_Nm;
			Car_Year = src._Car_Year;
			Car_Make = src._Car_Make;
			Car_Model = src._Car_Model;
			Recall_Status_Cd = src._Recall_Status_Cd;
			Recall_Risk_Cd = src._Recall_Risk_Cd;
			Recall_Keywords = src._Recall_Keywords;
			Detail_Url = src._Detail_Url;
			Recall_Url = src._Recall_Url;
			Found_Flg = src._Found_Flg;
			Prev_Nhtsa_Recall_ID = src._Prev_Nhtsa_Recall_ID;
			Detail_Response = src._Detail_Response;
			Recall_Response = src._Recall_Response;
			Recall_Response_Formatted = src._Recall_Response_Formatted;
		}

		public override bool ReloadFromDB()
		{
			ClsNhtsaRecall tmp = ClsNhtsaRecall.GetUsingKey(Nhtsa_Recall_ID.Value);
			if( tmp != null ) CopyFrom(tmp);

			ResetFKs();
			OnReload();

			return ( tmp != null );
		}

		public override void ResetFKs()
		{
			_Recall_Status = null;
			_Recall_Risk = null;
		}
		#endregion		// #region Init methods

		#region Insert, Update, Delete

		public override int Insert()
		{

			DbParameter[] p = new DbParameter[29];

			p[0] = Connection.GetParameter
				("@VESSEL", Vessel);
			p[1] = Connection.GetParameter
				("@VOYAGE", Voyage);
			p[2] = Connection.GetParameter
				("@POL", Pol);
			p[3] = Connection.GetParameter
				("@POD", Pod);
			p[4] = Connection.GetParameter
				("@ARRIVE_DT", Arrive_Dt);
			p[5] = Connection.GetParameter
				("@BOOKING_NO", Booking_No);
			p[6] = Connection.GetParameter
				("@BOL_NO", Bol_No);
			p[7] = Connection.GetParameter
				("@VIN", Vin);
			p[8] = Connection.GetParameter
				("@LINE_BOOKING_ID", Line_Booking_ID);
			p[9] = Connection.GetParameter
				("@LINE_BOL_ID", Line_Bol_ID);
			p[10] = Connection.GetParameter
				("@CUSTOMER_NM", Customer_Nm);
			p[11] = Connection.GetParameter
				("@CAR_YEAR", Car_Year);
			p[12] = Connection.GetParameter
				("@CAR_MAKE", Car_Make);
			p[13] = Connection.GetParameter
				("@CAR_MODEL", Car_Model);
			p[14] = Connection.GetParameter
				("@RECALL_STATUS_CD", Recall_Status_Cd);
			p[15] = Connection.GetParameter
				("@RECALL_RISK_CD", Recall_Risk_Cd);
			p[16] = Connection.GetParameter
				("@RECALL_KEYWORDS", Recall_Keywords);
			p[17] = Connection.GetParameter
				("@DETAIL_URL", Detail_Url);
			p[18] = Connection.GetParameter
				("@RECALL_URL", Recall_Url);
			p[19] = Connection.GetParameter
				("@FOUND_FLG", Found_Flg);
			p[20] = Connection.GetParameter
				("@PREV_NHTSA_RECALL_ID", Prev_Nhtsa_Recall_ID);
			p[21] = Connection.GetParameter
				("@DETAIL_RESPONSE", Detail_Response);
			p[22] = Connection.GetParameter
				("@RECALL_RESPONSE", Recall_Response);
			p[23] = Connection.GetParameter
				("@RECALL_RESPONSE_FORMATTED", Recall_Response_Formatted);
			p[24] = Connection.GetParameter
				("@NHTSA_RECALL_ID", Nhtsa_Recall_ID, ParameterDirection.Output, DbType.Int64, 0);
			p[25] = Connection.GetParameter
				("@CREATE_USER", Create_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Create_UserMax);
			p[26] = Connection.GetParameter
				("@CREATE_DT", Create_Dt, ParameterDirection.Output, DbType.DateTime, 0);
			p[27] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);
			p[28] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.Output, DbType.DateTime, 0);

			const string sql = @"
				INSERT INTO T_NHTSA_RECALL
					(NHTSA_RECALL_ID, VESSEL, VOYAGE,
					POL, POD, ARRIVE_DT,
					BOOKING_NO, BOL_NO, VIN,
					LINE_BOOKING_ID, LINE_BOL_ID, CUSTOMER_NM,
					CAR_YEAR, CAR_MAKE, CAR_MODEL,
					RECALL_STATUS_CD, RECALL_RISK_CD, RECALL_KEYWORDS,
					DETAIL_URL, RECALL_URL, FOUND_FLG,
					PREV_NHTSA_RECALL_ID, DETAIL_RESPONSE, RECALL_RESPONSE,
					RECALL_RESPONSE_FORMATTED)
				VALUES
					(NHTSA_RECALL_ID_SEQ.NEXTVAL, @VESSEL, @VOYAGE,
					@POL, @POD, @ARRIVE_DT,
					@BOOKING_NO, @BOL_NO, @VIN,
					@LINE_BOOKING_ID, @LINE_BOL_ID, @CUSTOMER_NM,
					@CAR_YEAR, @CAR_MAKE, @CAR_MODEL,
					@RECALL_STATUS_CD, @RECALL_RISK_CD, @RECALL_KEYWORDS,
					@DETAIL_URL, @RECALL_URL, @FOUND_FLG,
					@PREV_NHTSA_RECALL_ID, @DETAIL_RESPONSE, @RECALL_RESPONSE,
					@RECALL_RESPONSE_FORMATTED)
				RETURNING
					NHTSA_RECALL_ID, CREATE_USER, CREATE_DT,
					MODIFY_USER, MODIFY_DT
				INTO
					@NHTSA_RECALL_ID, @CREATE_USER, @CREATE_DT,
					@MODIFY_USER, @MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Nhtsa_Recall_ID = ClsConvert.ToInt64Nullable(p[24].Value);
			Create_User = ClsConvert.ToString(p[25].Value);
			Create_Dt = ClsConvert.ToDateTimeNullable(p[26].Value);
			Modify_User = ClsConvert.ToString(p[27].Value);
			Modify_Dt = ClsConvert.ToDateTimeNullable(p[28].Value);
			return ret;
		}
		public override int Update()
		{
			DbParameter[] p = new DbParameter[27];

			p[0] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.InputOutput, DbType.DateTime, 0);
			p[1] = Connection.GetParameter
				("@VESSEL", Vessel);
			p[2] = Connection.GetParameter
				("@VOYAGE", Voyage);
			p[3] = Connection.GetParameter
				("@POL", Pol);
			p[4] = Connection.GetParameter
				("@POD", Pod);
			p[5] = Connection.GetParameter
				("@ARRIVE_DT", Arrive_Dt);
			p[6] = Connection.GetParameter
				("@BOOKING_NO", Booking_No);
			p[7] = Connection.GetParameter
				("@BOL_NO", Bol_No);
			p[8] = Connection.GetParameter
				("@VIN", Vin);
			p[9] = Connection.GetParameter
				("@LINE_BOOKING_ID", Line_Booking_ID);
			p[10] = Connection.GetParameter
				("@LINE_BOL_ID", Line_Bol_ID);
			p[11] = Connection.GetParameter
				("@CUSTOMER_NM", Customer_Nm);
			p[12] = Connection.GetParameter
				("@CAR_YEAR", Car_Year);
			p[13] = Connection.GetParameter
				("@CAR_MAKE", Car_Make);
			p[14] = Connection.GetParameter
				("@CAR_MODEL", Car_Model);
			p[15] = Connection.GetParameter
				("@RECALL_STATUS_CD", Recall_Status_Cd);
			p[16] = Connection.GetParameter
				("@RECALL_RISK_CD", Recall_Risk_Cd);
			p[17] = Connection.GetParameter
				("@RECALL_KEYWORDS", Recall_Keywords);
			p[18] = Connection.GetParameter
				("@DETAIL_URL", Detail_Url);
			p[19] = Connection.GetParameter
				("@RECALL_URL", Recall_Url);
			p[20] = Connection.GetParameter
				("@FOUND_FLG", Found_Flg);
			p[21] = Connection.GetParameter
				("@PREV_NHTSA_RECALL_ID", Prev_Nhtsa_Recall_ID);
			p[22] = Connection.GetParameter
				("@DETAIL_RESPONSE", Detail_Response);
			p[23] = Connection.GetParameter
				("@RECALL_RESPONSE", Recall_Response);
			p[24] = Connection.GetParameter
				("@RECALL_RESPONSE_FORMATTED", Recall_Response_Formatted);
			p[25] = Connection.GetParameter
				("@NHTSA_RECALL_ID", Nhtsa_Recall_ID);
			p[26] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);

			const string sql = @"
				UPDATE T_NHTSA_RECALL SET
					MODIFY_DT = @MODIFY_DT,
					VESSEL = @VESSEL,
					VOYAGE = @VOYAGE,
					POL = @POL,
					POD = @POD,
					ARRIVE_DT = @ARRIVE_DT,
					BOOKING_NO = @BOOKING_NO,
					BOL_NO = @BOL_NO,
					VIN = @VIN,
					LINE_BOOKING_ID = @LINE_BOOKING_ID,
					LINE_BOL_ID = @LINE_BOL_ID,
					CUSTOMER_NM = @CUSTOMER_NM,
					CAR_YEAR = @CAR_YEAR,
					CAR_MAKE = @CAR_MAKE,
					CAR_MODEL = @CAR_MODEL,
					RECALL_STATUS_CD = @RECALL_STATUS_CD,
					RECALL_RISK_CD = @RECALL_RISK_CD,
					RECALL_KEYWORDS = @RECALL_KEYWORDS,
					DETAIL_URL = @DETAIL_URL,
					RECALL_URL = @RECALL_URL,
					FOUND_FLG = @FOUND_FLG,
					PREV_NHTSA_RECALL_ID = @PREV_NHTSA_RECALL_ID,
					DETAIL_RESPONSE = @DETAIL_RESPONSE,
					RECALL_RESPONSE = @RECALL_RESPONSE,
					RECALL_RESPONSE_FORMATTED = @RECALL_RESPONSE_FORMATTED
				WHERE
					NHTSA_RECALL_ID = @NHTSA_RECALL_ID
				RETURNING
					MODIFY_USER, MODIFY_DT
				INTO
					@MODIFY_USER, @MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Modify_Dt = ClsConvert.ToDateTimeNullable(p[0].Value);
			Modify_User = ClsConvert.ToString(p[26].Value);
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

			Nhtsa_Recall_ID = ClsConvert.ToInt64Nullable(dr["NHTSA_RECALL_ID"]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER"]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT"]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER"]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT"]);
			Vessel = ClsConvert.ToString(dr["VESSEL"]);
			Voyage = ClsConvert.ToString(dr["VOYAGE"]);
			Pol = ClsConvert.ToString(dr["POL"]);
			Pod = ClsConvert.ToString(dr["POD"]);
			Arrive_Dt = ClsConvert.ToDateTimeNullable(dr["ARRIVE_DT"]);
			Booking_No = ClsConvert.ToString(dr["BOOKING_NO"]);
			Bol_No = ClsConvert.ToString(dr["BOL_NO"]);
			Vin = ClsConvert.ToString(dr["VIN"]);
			Line_Booking_ID = ClsConvert.ToInt64Nullable(dr["LINE_BOOKING_ID"]);
			Line_Bol_ID = ClsConvert.ToDecimalNullable(dr["LINE_BOL_ID"]);
			Customer_Nm = ClsConvert.ToString(dr["CUSTOMER_NM"]);
			Car_Year = ClsConvert.ToInt16Nullable(dr["CAR_YEAR"]);
			Car_Make = ClsConvert.ToString(dr["CAR_MAKE"]);
			Car_Model = ClsConvert.ToString(dr["CAR_MODEL"]);
			Recall_Status_Cd = ClsConvert.ToString(dr["RECALL_STATUS_CD"]);
			Recall_Risk_Cd = ClsConvert.ToString(dr["RECALL_RISK_CD"]);
			Recall_Keywords = ClsConvert.ToString(dr["RECALL_KEYWORDS"]);
			Detail_Url = ClsConvert.ToString(dr["DETAIL_URL"]);
			Recall_Url = ClsConvert.ToString(dr["RECALL_URL"]);
			Found_Flg = ClsConvert.ToString(dr["FOUND_FLG"]);
			Prev_Nhtsa_Recall_ID = ClsConvert.ToInt64Nullable(dr["PREV_NHTSA_RECALL_ID"]);
			Detail_Response = ClsConvert.ToString(dr["DETAIL_RESPONSE"]);
			Recall_Response = ClsConvert.ToString(dr["RECALL_RESPONSE"]);
			Recall_Response_Formatted = ClsConvert.ToString(dr["RECALL_RESPONSE_FORMATTED"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Nhtsa_Recall_ID = ClsConvert.ToInt64Nullable(dr["NHTSA_RECALL_ID", v]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER", v]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT", v]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER", v]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT", v]);
			Vessel = ClsConvert.ToString(dr["VESSEL", v]);
			Voyage = ClsConvert.ToString(dr["VOYAGE", v]);
			Pol = ClsConvert.ToString(dr["POL", v]);
			Pod = ClsConvert.ToString(dr["POD", v]);
			Arrive_Dt = ClsConvert.ToDateTimeNullable(dr["ARRIVE_DT", v]);
			Booking_No = ClsConvert.ToString(dr["BOOKING_NO", v]);
			Bol_No = ClsConvert.ToString(dr["BOL_NO", v]);
			Vin = ClsConvert.ToString(dr["VIN", v]);
			Line_Booking_ID = ClsConvert.ToInt64Nullable(dr["LINE_BOOKING_ID", v]);
			Line_Bol_ID = ClsConvert.ToDecimalNullable(dr["LINE_BOL_ID", v]);
			Customer_Nm = ClsConvert.ToString(dr["CUSTOMER_NM", v]);
			Car_Year = ClsConvert.ToInt16Nullable(dr["CAR_YEAR", v]);
			Car_Make = ClsConvert.ToString(dr["CAR_MAKE", v]);
			Car_Model = ClsConvert.ToString(dr["CAR_MODEL", v]);
			Recall_Status_Cd = ClsConvert.ToString(dr["RECALL_STATUS_CD", v]);
			Recall_Risk_Cd = ClsConvert.ToString(dr["RECALL_RISK_CD", v]);
			Recall_Keywords = ClsConvert.ToString(dr["RECALL_KEYWORDS", v]);
			Detail_Url = ClsConvert.ToString(dr["DETAIL_URL", v]);
			Recall_Url = ClsConvert.ToString(dr["RECALL_URL", v]);
			Found_Flg = ClsConvert.ToString(dr["FOUND_FLG", v]);
			Prev_Nhtsa_Recall_ID = ClsConvert.ToInt64Nullable(dr["PREV_NHTSA_RECALL_ID", v]);
			Detail_Response = ClsConvert.ToString(dr["DETAIL_RESPONSE", v]);
			Recall_Response = ClsConvert.ToString(dr["RECALL_RESPONSE", v]);
			Recall_Response_Formatted = ClsConvert.ToString(dr["RECALL_RESPONSE_FORMATTED", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["NHTSA_RECALL_ID"] = ClsConvert.ToDbObject(Nhtsa_Recall_ID);
			dr["CREATE_USER"] = ClsConvert.ToDbObject(Create_User);
			dr["CREATE_DT"] = ClsConvert.ToDbObject(Create_Dt);
			dr["MODIFY_USER"] = ClsConvert.ToDbObject(Modify_User);
			dr["MODIFY_DT"] = ClsConvert.ToDbObject(Modify_Dt);
			dr["VESSEL"] = ClsConvert.ToDbObject(Vessel);
			dr["VOYAGE"] = ClsConvert.ToDbObject(Voyage);
			dr["POL"] = ClsConvert.ToDbObject(Pol);
			dr["POD"] = ClsConvert.ToDbObject(Pod);
			dr["ARRIVE_DT"] = ClsConvert.ToDbObject(Arrive_Dt);
			dr["BOOKING_NO"] = ClsConvert.ToDbObject(Booking_No);
			dr["BOL_NO"] = ClsConvert.ToDbObject(Bol_No);
			dr["VIN"] = ClsConvert.ToDbObject(Vin);
			dr["LINE_BOOKING_ID"] = ClsConvert.ToDbObject(Line_Booking_ID);
			dr["LINE_BOL_ID"] = ClsConvert.ToDbObject(Line_Bol_ID);
			dr["CUSTOMER_NM"] = ClsConvert.ToDbObject(Customer_Nm);
			dr["CAR_YEAR"] = ClsConvert.ToDbObject(Car_Year);
			dr["CAR_MAKE"] = ClsConvert.ToDbObject(Car_Make);
			dr["CAR_MODEL"] = ClsConvert.ToDbObject(Car_Model);
			dr["RECALL_STATUS_CD"] = ClsConvert.ToDbObject(Recall_Status_Cd);
			dr["RECALL_RISK_CD"] = ClsConvert.ToDbObject(Recall_Risk_Cd);
			dr["RECALL_KEYWORDS"] = ClsConvert.ToDbObject(Recall_Keywords);
			dr["DETAIL_URL"] = ClsConvert.ToDbObject(Detail_Url);
			dr["RECALL_URL"] = ClsConvert.ToDbObject(Recall_Url);
			dr["FOUND_FLG"] = ClsConvert.ToDbObject(Found_Flg);
			dr["PREV_NHTSA_RECALL_ID"] = ClsConvert.ToDbObject(Prev_Nhtsa_Recall_ID);
			dr["DETAIL_RESPONSE"] = ClsConvert.ToDbObject(Detail_Response);
			dr["RECALL_RESPONSE"] = ClsConvert.ToDbObject(Recall_Response);
			dr["RECALL_RESPONSE_FORMATTED"] = ClsConvert.ToDbObject(Recall_Response_Formatted);
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

		public static ClsNhtsaRecall GetUsingKey(Int64 Nhtsa_Recall_ID)
		{
			object[] vals = new object[] {Nhtsa_Recall_ID};
			DataRow dr = Connection.GetDataRowUsingKey
				(TableName, GetPrimaryKeys(), vals);
			return ( dr == null ) ? null : new ClsNhtsaRecall(dr);
		}
		public static DataTable GetAll(string Recall_Status_Cd, string Recall_Risk_Cd)
		{
			List<DbParameter> lst = new List<DbParameter>();	
			StringBuilder sb = new StringBuilder();
		
			if( string.IsNullOrEmpty(Recall_Status_Cd) == false )
			{
				lst.Add(Connection.GetParameter("@RECALL_STATUS_CD", Recall_Status_Cd));
				sb.Append(" WHERE T_NHTSA_RECALL.RECALL_STATUS_CD=@RECALL_STATUS_CD");
			}
			if( string.IsNullOrEmpty(Recall_Risk_Cd) == false )
			{
				lst.Add(Connection.GetParameter("@RECALL_RISK_CD", Recall_Risk_Cd));
				sb.AppendFormat(" {0} T_NHTSA_RECALL.RECALL_RISK_CD=@RECALL_RISK_CD",
					sb.Length > 0 ? "AND" : "WHERE");
			}
			sb.Insert(0, SelectSQL);
			return Connection.GetDataTable(sb.ToString(), lst.ToArray());
		}
		#endregion		// #region Static Methods
	}
}