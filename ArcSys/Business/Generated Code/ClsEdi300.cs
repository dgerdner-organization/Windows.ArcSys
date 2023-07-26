using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsEdi300 : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ArcSys"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "T_EDI300";
		public const int PrimaryKeyCount = 1;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] { "EDI300_ID" };
		}

		public const string SelectSQL = @"SELECT * FROM T_EDI300 
				LEFT OUTER JOIN T_ISA
				ON T_EDI300.ISA_ID=T_ISA.ISA_ID ";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Create_UserMax = 30;
		public const int Modify_UserMax = 30;
		public const int Trading_Partner_CdMax = 10;
		public const int Request_CdMax = 10;
		public const int Project_CdMax = 30;
		public const int Contract_NoMax = 30;
		public const int Tac_NoMax = 30;
		public const int Fms_Case_NoMax = 30;
		public const int Vessel_QualifierMax = 2;
		public const int Vessel_CdMax = 10;
		public const int Vessel_DscMax = 30;
		public const int Partner_Voyage_NoMax = 10;
		public const int Pol_QualifierMax = 2;
		public const int Pol_CdMax = 10;
		public const int Pol_DscMax = 30;
		public const int Pod_QualifierMax = 2;
		public const int Pod_CdMax = 10;
		public const int Pod_DscMax = 30;
		public const int Delivery_DscMax = 120;
		public const int Delivery_Dsc2Max = 120;
		public const int Cargo_CdMax = 2;
		public const int Iso_Eqp_Type_CdMax = 2;
		public const int Orig_Terms_CdMax = 10;
		public const int Dest_Terms_CdMax = 10;
		public const int Rcvr_CountryMax = 2;
		public const int Hazmat_CdMax = 10;
		public const int Hazmat_Cd_QualifierMax = 2;
		public const int Hazmat_Class_CdMax = 10;
		public const int Hazmat_DscMax = 50;
		public const int Hazmat_ContactMax = 50;
		public const int Special_Handling_CdMax = 250;
		public const int Move_Type_CdMax = 5;
		public const int Sea_Air_FlgMax = 1;
		public const int Voyage_NoMax = 10;
		public const int Pod_Location_CdMax = 10;
		public const int Pol_Location_CdMax = 10;
		public const int Handling_NotesMax = 200;
		public const int Processed_FlgMax = 1;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected Int64? _Edi300_ID;
		protected Int64? _Isa_ID;
		protected DateTime? _Create_Dt;
		protected string _Create_User;
		protected DateTime? _Modify_Dt;
		protected string _Modify_User;
		protected Int64? _Isa_Nbr;
		protected string _Trading_Partner_Cd;
		protected string _Request_Cd;
		protected DateTime? _Request_Dt;
		protected string _Project_Cd;
		protected string _Contract_No;
		protected string _Tac_No;
		protected string _Fms_Case_No;
		protected string _Vessel_Qualifier;
		protected string _Vessel_Cd;
		protected string _Vessel_Dsc;
		protected string _Partner_Voyage_No;
		protected DateTime? _Sail_Dt;
		protected string _Pol_Qualifier;
		protected string _Pol_Cd;
		protected string _Pol_Dsc;
		protected string _Pod_Qualifier;
		protected string _Pod_Cd;
		protected string _Pod_Dsc;
		protected DateTime? _Cargo_Avail_Dt;
		protected DateTime? _Rdd_Dt;
		protected string _Delivery_Dsc;
		protected string _Delivery_Dsc2;
		protected Int32? _Ship_Units_Nbr;
		protected string _Cargo_Cd;
		protected string _Iso_Eqp_Type_Cd;
		protected string _Orig_Terms_Cd;
		protected string _Dest_Terms_Cd;
		protected Int32? _Totals_Stopoffs_Nbr;
		protected string _Rcvr_Country;
		protected string _Hazmat_Cd;
		protected string _Hazmat_Cd_Qualifier;
		protected string _Hazmat_Class_Cd;
		protected string _Hazmat_Dsc;
		protected string _Hazmat_Contact;
		protected string _Special_Handling_Cd;
		protected string _Move_Type_Cd;
		protected string _Sea_Air_Flg;
		protected string _Voyage_No;
		protected string _Pod_Location_Cd;
		protected string _Pol_Location_Cd;
		protected string _Handling_Notes;
		protected string _Processed_Flg;

		#endregion	// #region Column Fields

		#region Column Properties

		public Int64? Edi300_ID
		{
			get { return _Edi300_ID; }
			set
			{
				if( _Edi300_ID == value ) return;
		
				_Edi300_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Edi300_ID");
			}
		}
		public Int64? Isa_ID
		{
			get { return _Isa_ID; }
			set
			{
				if( _Isa_ID == value ) return;
		
				_Isa_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Isa_ID");
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
		public Int64? Isa_Nbr
		{
			get { return _Isa_Nbr; }
			set
			{
				if( _Isa_Nbr == value ) return;
		
				_Isa_Nbr = value;
				_IsDirty = true;
				NotifyPropertyChanged("Isa_Nbr");
			}
		}
		public string Trading_Partner_Cd
		{
			get { return _Trading_Partner_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Trading_Partner_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Trading_Partner_CdMax )
					_Trading_Partner_Cd = val.Substring(0, (int)Trading_Partner_CdMax);
				else
					_Trading_Partner_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Trading_Partner_Cd");
			}
		}
		public string Request_Cd
		{
			get { return _Request_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Request_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Request_CdMax )
					_Request_Cd = val.Substring(0, (int)Request_CdMax);
				else
					_Request_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Request_Cd");
			}
		}
		public DateTime? Request_Dt
		{
			get { return _Request_Dt; }
			set
			{
				DateTime? val = ( value != null )
					? (DateTime?)value.Value.Date : null;
		
				if( _Request_Dt == val ) return;
		
				_Request_Dt = val;
				_IsDirty = true;
				NotifyPropertyChanged("Request_Dt");
			}
		}
		public string Project_Cd
		{
			get { return _Project_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Project_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Project_CdMax )
					_Project_Cd = val.Substring(0, (int)Project_CdMax);
				else
					_Project_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Project_Cd");
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
		public string Tac_No
		{
			get { return _Tac_No; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Tac_No, val, false) == 0 ) return;
		
				if( val != null && val.Length > Tac_NoMax )
					_Tac_No = val.Substring(0, (int)Tac_NoMax);
				else
					_Tac_No = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Tac_No");
			}
		}
		public string Fms_Case_No
		{
			get { return _Fms_Case_No; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Fms_Case_No, val, false) == 0 ) return;
		
				if( val != null && val.Length > Fms_Case_NoMax )
					_Fms_Case_No = val.Substring(0, (int)Fms_Case_NoMax);
				else
					_Fms_Case_No = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Fms_Case_No");
			}
		}
		public string Vessel_Qualifier
		{
			get { return _Vessel_Qualifier; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Vessel_Qualifier, val, false) == 0 ) return;
		
				if( val != null && val.Length > Vessel_QualifierMax )
					_Vessel_Qualifier = val.Substring(0, (int)Vessel_QualifierMax);
				else
					_Vessel_Qualifier = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Vessel_Qualifier");
			}
		}
		public string Vessel_Cd
		{
			get { return _Vessel_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Vessel_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Vessel_CdMax )
					_Vessel_Cd = val.Substring(0, (int)Vessel_CdMax);
				else
					_Vessel_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Vessel_Cd");
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
		public string Partner_Voyage_No
		{
			get { return _Partner_Voyage_No; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Partner_Voyage_No, val, false) == 0 ) return;
		
				if( val != null && val.Length > Partner_Voyage_NoMax )
					_Partner_Voyage_No = val.Substring(0, (int)Partner_Voyage_NoMax);
				else
					_Partner_Voyage_No = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Partner_Voyage_No");
			}
		}
		public DateTime? Sail_Dt
		{
			get { return _Sail_Dt; }
			set
			{
				DateTime? val = ( value != null )
					? (DateTime?)value.Value.Date : null;
		
				if( _Sail_Dt == val ) return;
		
				_Sail_Dt = val;
				_IsDirty = true;
				NotifyPropertyChanged("Sail_Dt");
			}
		}
		public string Pol_Qualifier
		{
			get { return _Pol_Qualifier; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Pol_Qualifier, val, false) == 0 ) return;
		
				if( val != null && val.Length > Pol_QualifierMax )
					_Pol_Qualifier = val.Substring(0, (int)Pol_QualifierMax);
				else
					_Pol_Qualifier = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Pol_Qualifier");
			}
		}
		public string Pol_Cd
		{
			get { return _Pol_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Pol_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Pol_CdMax )
					_Pol_Cd = val.Substring(0, (int)Pol_CdMax);
				else
					_Pol_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Pol_Cd");
			}
		}
		public string Pol_Dsc
		{
			get { return _Pol_Dsc; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Pol_Dsc, val, false) == 0 ) return;
		
				if( val != null && val.Length > Pol_DscMax )
					_Pol_Dsc = val.Substring(0, (int)Pol_DscMax);
				else
					_Pol_Dsc = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Pol_Dsc");
			}
		}
		public string Pod_Qualifier
		{
			get { return _Pod_Qualifier; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Pod_Qualifier, val, false) == 0 ) return;
		
				if( val != null && val.Length > Pod_QualifierMax )
					_Pod_Qualifier = val.Substring(0, (int)Pod_QualifierMax);
				else
					_Pod_Qualifier = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Pod_Qualifier");
			}
		}
		public string Pod_Cd
		{
			get { return _Pod_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Pod_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Pod_CdMax )
					_Pod_Cd = val.Substring(0, (int)Pod_CdMax);
				else
					_Pod_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Pod_Cd");
			}
		}
		public string Pod_Dsc
		{
			get { return _Pod_Dsc; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Pod_Dsc, val, false) == 0 ) return;
		
				if( val != null && val.Length > Pod_DscMax )
					_Pod_Dsc = val.Substring(0, (int)Pod_DscMax);
				else
					_Pod_Dsc = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Pod_Dsc");
			}
		}
		public DateTime? Cargo_Avail_Dt
		{
			get { return _Cargo_Avail_Dt; }
			set
			{
				DateTime? val = ( value != null )
					? (DateTime?)value.Value.Date : null;
		
				if( _Cargo_Avail_Dt == val ) return;
		
				_Cargo_Avail_Dt = val;
				_IsDirty = true;
				NotifyPropertyChanged("Cargo_Avail_Dt");
			}
		}
		public DateTime? Rdd_Dt
		{
			get { return _Rdd_Dt; }
			set
			{
				DateTime? val = ( value != null )
					? (DateTime?)value.Value.Date : null;
		
				if( _Rdd_Dt == val ) return;
		
				_Rdd_Dt = val;
				_IsDirty = true;
				NotifyPropertyChanged("Rdd_Dt");
			}
		}
		public string Delivery_Dsc
		{
			get { return _Delivery_Dsc; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Delivery_Dsc, val, false) == 0 ) return;
		
				if( val != null && val.Length > Delivery_DscMax )
					_Delivery_Dsc = val.Substring(0, (int)Delivery_DscMax);
				else
					_Delivery_Dsc = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Delivery_Dsc");
			}
		}
		public string Delivery_Dsc2
		{
			get { return _Delivery_Dsc2; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Delivery_Dsc2, val, false) == 0 ) return;
		
				if( val != null && val.Length > Delivery_Dsc2Max )
					_Delivery_Dsc2 = val.Substring(0, (int)Delivery_Dsc2Max);
				else
					_Delivery_Dsc2 = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Delivery_Dsc2");
			}
		}
		public Int32? Ship_Units_Nbr
		{
			get { return _Ship_Units_Nbr; }
			set
			{
				if( _Ship_Units_Nbr == value ) return;
		
				_Ship_Units_Nbr = value;
				_IsDirty = true;
				NotifyPropertyChanged("Ship_Units_Nbr");
			}
		}
		public string Cargo_Cd
		{
			get { return _Cargo_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Cargo_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Cargo_CdMax )
					_Cargo_Cd = val.Substring(0, (int)Cargo_CdMax);
				else
					_Cargo_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Cargo_Cd");
			}
		}
		public string Iso_Eqp_Type_Cd
		{
			get { return _Iso_Eqp_Type_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Iso_Eqp_Type_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Iso_Eqp_Type_CdMax )
					_Iso_Eqp_Type_Cd = val.Substring(0, (int)Iso_Eqp_Type_CdMax);
				else
					_Iso_Eqp_Type_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Iso_Eqp_Type_Cd");
			}
		}
		public string Orig_Terms_Cd
		{
			get { return _Orig_Terms_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Orig_Terms_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Orig_Terms_CdMax )
					_Orig_Terms_Cd = val.Substring(0, (int)Orig_Terms_CdMax);
				else
					_Orig_Terms_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Orig_Terms_Cd");
			}
		}
		public string Dest_Terms_Cd
		{
			get { return _Dest_Terms_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Dest_Terms_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Dest_Terms_CdMax )
					_Dest_Terms_Cd = val.Substring(0, (int)Dest_Terms_CdMax);
				else
					_Dest_Terms_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Dest_Terms_Cd");
			}
		}
		public Int32? Totals_Stopoffs_Nbr
		{
			get { return _Totals_Stopoffs_Nbr; }
			set
			{
				if( _Totals_Stopoffs_Nbr == value ) return;
		
				_Totals_Stopoffs_Nbr = value;
				_IsDirty = true;
				NotifyPropertyChanged("Totals_Stopoffs_Nbr");
			}
		}
		public string Rcvr_Country
		{
			get { return _Rcvr_Country; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Rcvr_Country, val, false) == 0 ) return;
		
				if( val != null && val.Length > Rcvr_CountryMax )
					_Rcvr_Country = val.Substring(0, (int)Rcvr_CountryMax);
				else
					_Rcvr_Country = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Rcvr_Country");
			}
		}
		public string Hazmat_Cd
		{
			get { return _Hazmat_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Hazmat_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Hazmat_CdMax )
					_Hazmat_Cd = val.Substring(0, (int)Hazmat_CdMax);
				else
					_Hazmat_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Hazmat_Cd");
			}
		}
		public string Hazmat_Cd_Qualifier
		{
			get { return _Hazmat_Cd_Qualifier; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Hazmat_Cd_Qualifier, val, false) == 0 ) return;
		
				if( val != null && val.Length > Hazmat_Cd_QualifierMax )
					_Hazmat_Cd_Qualifier = val.Substring(0, (int)Hazmat_Cd_QualifierMax);
				else
					_Hazmat_Cd_Qualifier = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Hazmat_Cd_Qualifier");
			}
		}
		public string Hazmat_Class_Cd
		{
			get { return _Hazmat_Class_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Hazmat_Class_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Hazmat_Class_CdMax )
					_Hazmat_Class_Cd = val.Substring(0, (int)Hazmat_Class_CdMax);
				else
					_Hazmat_Class_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Hazmat_Class_Cd");
			}
		}
		public string Hazmat_Dsc
		{
			get { return _Hazmat_Dsc; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Hazmat_Dsc, val, false) == 0 ) return;
		
				if( val != null && val.Length > Hazmat_DscMax )
					_Hazmat_Dsc = val.Substring(0, (int)Hazmat_DscMax);
				else
					_Hazmat_Dsc = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Hazmat_Dsc");
			}
		}
		public string Hazmat_Contact
		{
			get { return _Hazmat_Contact; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Hazmat_Contact, val, false) == 0 ) return;
		
				if( val != null && val.Length > Hazmat_ContactMax )
					_Hazmat_Contact = val.Substring(0, (int)Hazmat_ContactMax);
				else
					_Hazmat_Contact = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Hazmat_Contact");
			}
		}
		public string Special_Handling_Cd
		{
			get { return _Special_Handling_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Special_Handling_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Special_Handling_CdMax )
					_Special_Handling_Cd = val.Substring(0, (int)Special_Handling_CdMax);
				else
					_Special_Handling_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Special_Handling_Cd");
			}
		}
		public string Move_Type_Cd
		{
			get { return _Move_Type_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Move_Type_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Move_Type_CdMax )
					_Move_Type_Cd = val.Substring(0, (int)Move_Type_CdMax);
				else
					_Move_Type_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Move_Type_Cd");
			}
		}
		public string Sea_Air_Flg
		{
			get { return _Sea_Air_Flg; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Sea_Air_Flg, val, false) == 0 ) return;
		
				if( val != null && val.Length > Sea_Air_FlgMax )
					_Sea_Air_Flg = val.Substring(0, (int)Sea_Air_FlgMax);
				else
					_Sea_Air_Flg = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Sea_Air_Flg");
			}
		}
		public string Voyage_No
		{
			get { return _Voyage_No; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Voyage_No, val, false) == 0 ) return;
		
				if( val != null && val.Length > Voyage_NoMax )
					_Voyage_No = val.Substring(0, (int)Voyage_NoMax);
				else
					_Voyage_No = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Voyage_No");
			}
		}
		public string Pod_Location_Cd
		{
			get { return _Pod_Location_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Pod_Location_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Pod_Location_CdMax )
					_Pod_Location_Cd = val.Substring(0, (int)Pod_Location_CdMax);
				else
					_Pod_Location_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Pod_Location_Cd");
			}
		}
		public string Pol_Location_Cd
		{
			get { return _Pol_Location_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Pol_Location_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Pol_Location_CdMax )
					_Pol_Location_Cd = val.Substring(0, (int)Pol_Location_CdMax);
				else
					_Pol_Location_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Pol_Location_Cd");
			}
		}
		public string Handling_Notes
		{
			get { return _Handling_Notes; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Handling_Notes, val, false) == 0 ) return;
		
				if( val != null && val.Length > Handling_NotesMax )
					_Handling_Notes = val.Substring(0, (int)Handling_NotesMax);
				else
					_Handling_Notes = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Handling_Notes");
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

		#endregion	// #region Column Properties

		#region Foreign Key Fields



		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties



		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsEdi300() : base() {}
		public ClsEdi300(DataRow dr) : base(dr) {}
		public ClsEdi300(ClsEdi300 src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Edi300_ID = null;
			Isa_ID = null;
			Create_Dt = null;
			Create_User = null;
			Modify_Dt = null;
			Modify_User = null;
			Isa_Nbr = null;
			Trading_Partner_Cd = null;
			Request_Cd = null;
			Request_Dt = null;
			Project_Cd = null;
			Contract_No = null;
			Tac_No = null;
			Fms_Case_No = null;
			Vessel_Qualifier = null;
			Vessel_Cd = null;
			Vessel_Dsc = null;
			Partner_Voyage_No = null;
			Sail_Dt = null;
			Pol_Qualifier = null;
			Pol_Cd = null;
			Pol_Dsc = null;
			Pod_Qualifier = null;
			Pod_Cd = null;
			Pod_Dsc = null;
			Cargo_Avail_Dt = null;
			Rdd_Dt = null;
			Delivery_Dsc = null;
			Delivery_Dsc2 = null;
			Ship_Units_Nbr = null;
			Cargo_Cd = null;
			Iso_Eqp_Type_Cd = null;
			Orig_Terms_Cd = null;
			Dest_Terms_Cd = null;
			Totals_Stopoffs_Nbr = null;
			Rcvr_Country = null;
			Hazmat_Cd = null;
			Hazmat_Cd_Qualifier = null;
			Hazmat_Class_Cd = null;
			Hazmat_Dsc = null;
			Hazmat_Contact = null;
			Special_Handling_Cd = null;
			Move_Type_Cd = null;
			Sea_Air_Flg = null;
			Voyage_No = null;
			Pod_Location_Cd = null;
			Pol_Location_Cd = null;
			Handling_Notes = null;
			Processed_Flg = null;
		}

		public void CopyFrom(ClsEdi300 src)
		{
			Edi300_ID = src._Edi300_ID;
			Isa_ID = src._Isa_ID;
			Create_Dt = src._Create_Dt;
			Create_User = src._Create_User;
			Modify_Dt = src._Modify_Dt;
			Modify_User = src._Modify_User;
			Isa_Nbr = src._Isa_Nbr;
			Trading_Partner_Cd = src._Trading_Partner_Cd;
			Request_Cd = src._Request_Cd;
			Request_Dt = src._Request_Dt;
			Project_Cd = src._Project_Cd;
			Contract_No = src._Contract_No;
			Tac_No = src._Tac_No;
			Fms_Case_No = src._Fms_Case_No;
			Vessel_Qualifier = src._Vessel_Qualifier;
			Vessel_Cd = src._Vessel_Cd;
			Vessel_Dsc = src._Vessel_Dsc;
			Partner_Voyage_No = src._Partner_Voyage_No;
			Sail_Dt = src._Sail_Dt;
			Pol_Qualifier = src._Pol_Qualifier;
			Pol_Cd = src._Pol_Cd;
			Pol_Dsc = src._Pol_Dsc;
			Pod_Qualifier = src._Pod_Qualifier;
			Pod_Cd = src._Pod_Cd;
			Pod_Dsc = src._Pod_Dsc;
			Cargo_Avail_Dt = src._Cargo_Avail_Dt;
			Rdd_Dt = src._Rdd_Dt;
			Delivery_Dsc = src._Delivery_Dsc;
			Delivery_Dsc2 = src._Delivery_Dsc2;
			Ship_Units_Nbr = src._Ship_Units_Nbr;
			Cargo_Cd = src._Cargo_Cd;
			Iso_Eqp_Type_Cd = src._Iso_Eqp_Type_Cd;
			Orig_Terms_Cd = src._Orig_Terms_Cd;
			Dest_Terms_Cd = src._Dest_Terms_Cd;
			Totals_Stopoffs_Nbr = src._Totals_Stopoffs_Nbr;
			Rcvr_Country = src._Rcvr_Country;
			Hazmat_Cd = src._Hazmat_Cd;
			Hazmat_Cd_Qualifier = src._Hazmat_Cd_Qualifier;
			Hazmat_Class_Cd = src._Hazmat_Class_Cd;
			Hazmat_Dsc = src._Hazmat_Dsc;
			Hazmat_Contact = src._Hazmat_Contact;
			Special_Handling_Cd = src._Special_Handling_Cd;
			Move_Type_Cd = src._Move_Type_Cd;
			Sea_Air_Flg = src._Sea_Air_Flg;
			Voyage_No = src._Voyage_No;
			Pod_Location_Cd = src._Pod_Location_Cd;
			Pol_Location_Cd = src._Pol_Location_Cd;
			Handling_Notes = src._Handling_Notes;
			Processed_Flg = src._Processed_Flg;
		}

		public override bool ReloadFromDB()
		{
			ClsEdi300 tmp = ClsEdi300.GetUsingKey(Edi300_ID.Value);
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

			DbParameter[] p = new DbParameter[49];

			p[0] = Connection.GetParameter
				("@ISA_ID", Isa_ID);
			p[1] = Connection.GetParameter
				("@ISA_NBR", Isa_Nbr);
			p[2] = Connection.GetParameter
				("@TRADING_PARTNER_CD", Trading_Partner_Cd);
			p[3] = Connection.GetParameter
				("@REQUEST_CD", Request_Cd);
			p[4] = Connection.GetParameter
				("@REQUEST_DT", Request_Dt);
			p[5] = Connection.GetParameter
				("@PROJECT_CD", Project_Cd);
			p[6] = Connection.GetParameter
				("@CONTRACT_NO", Contract_No);
			p[7] = Connection.GetParameter
				("@TAC_NO", Tac_No);
			p[8] = Connection.GetParameter
				("@FMS_CASE_NO", Fms_Case_No);
			p[9] = Connection.GetParameter
				("@VESSEL_QUALIFIER", Vessel_Qualifier);
			p[10] = Connection.GetParameter
				("@VESSEL_CD", Vessel_Cd);
			p[11] = Connection.GetParameter
				("@VESSEL_DSC", Vessel_Dsc);
			p[12] = Connection.GetParameter
				("@PARTNER_VOYAGE_NO", Partner_Voyage_No);
			p[13] = Connection.GetParameter
				("@SAIL_DT", Sail_Dt);
			p[14] = Connection.GetParameter
				("@POL_QUALIFIER", Pol_Qualifier);
			p[15] = Connection.GetParameter
				("@POL_CD", Pol_Cd);
			p[16] = Connection.GetParameter
				("@POL_DSC", Pol_Dsc);
			p[17] = Connection.GetParameter
				("@POD_QUALIFIER", Pod_Qualifier);
			p[18] = Connection.GetParameter
				("@POD_CD", Pod_Cd);
			p[19] = Connection.GetParameter
				("@POD_DSC", Pod_Dsc);
			p[20] = Connection.GetParameter
				("@CARGO_AVAIL_DT", Cargo_Avail_Dt);
			p[21] = Connection.GetParameter
				("@RDD_DT", Rdd_Dt);
			p[22] = Connection.GetParameter
				("@DELIVERY_DSC", Delivery_Dsc);
			p[23] = Connection.GetParameter
				("@DELIVERY_DSC2", Delivery_Dsc2);
			p[24] = Connection.GetParameter
				("@SHIP_UNITS_NBR", Ship_Units_Nbr);
			p[25] = Connection.GetParameter
				("@CARGO_CD", Cargo_Cd);
			p[26] = Connection.GetParameter
				("@ISO_EQP_TYPE_CD", Iso_Eqp_Type_Cd);
			p[27] = Connection.GetParameter
				("@ORIG_TERMS_CD", Orig_Terms_Cd);
			p[28] = Connection.GetParameter
				("@DEST_TERMS_CD", Dest_Terms_Cd);
			p[29] = Connection.GetParameter
				("@TOTALS_STOPOFFS_NBR", Totals_Stopoffs_Nbr);
			p[30] = Connection.GetParameter
				("@RCVR_COUNTRY", Rcvr_Country);
			p[31] = Connection.GetParameter
				("@HAZMAT_CD", Hazmat_Cd);
			p[32] = Connection.GetParameter
				("@HAZMAT_CD_QUALIFIER", Hazmat_Cd_Qualifier);
			p[33] = Connection.GetParameter
				("@HAZMAT_CLASS_CD", Hazmat_Class_Cd);
			p[34] = Connection.GetParameter
				("@HAZMAT_DSC", Hazmat_Dsc);
			p[35] = Connection.GetParameter
				("@HAZMAT_CONTACT", Hazmat_Contact);
			p[36] = Connection.GetParameter
				("@SPECIAL_HANDLING_CD", Special_Handling_Cd);
			p[37] = Connection.GetParameter
				("@MOVE_TYPE_CD", Move_Type_Cd);
			p[38] = Connection.GetParameter
				("@SEA_AIR_FLG", Sea_Air_Flg);
			p[39] = Connection.GetParameter
				("@VOYAGE_NO", Voyage_No);
			p[40] = Connection.GetParameter
				("@POD_LOCATION_CD", Pod_Location_Cd);
			p[41] = Connection.GetParameter
				("@POL_LOCATION_CD", Pol_Location_Cd);
			p[42] = Connection.GetParameter
				("@HANDLING_NOTES", Handling_Notes);
			p[43] = Connection.GetParameter
				("@PROCESSED_FLG", Processed_Flg);
			p[44] = Connection.GetParameter
				("@EDI300_ID", Edi300_ID, ParameterDirection.Output, DbType.Int64, 0);
			p[45] = Connection.GetParameter
				("@CREATE_DT", Create_Dt, ParameterDirection.Output, DbType.DateTime, 0);
			p[46] = Connection.GetParameter
				("@CREATE_USER", Create_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Create_UserMax);
			p[47] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.Output, DbType.DateTime, 0);
			p[48] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);

			const string sql = @"
				INSERT INTO T_EDI300
					(EDI300_ID, ISA_ID, ISA_NBR,
					TRADING_PARTNER_CD, REQUEST_CD, REQUEST_DT,
					PROJECT_CD, CONTRACT_NO, TAC_NO,
					FMS_CASE_NO, VESSEL_QUALIFIER, VESSEL_CD,
					VESSEL_DSC, PARTNER_VOYAGE_NO, SAIL_DT,
					POL_QUALIFIER, POL_CD, POL_DSC,
					POD_QUALIFIER, POD_CD, POD_DSC,
					CARGO_AVAIL_DT, RDD_DT, DELIVERY_DSC,
					DELIVERY_DSC2, SHIP_UNITS_NBR, CARGO_CD,
					ISO_EQP_TYPE_CD, ORIG_TERMS_CD, DEST_TERMS_CD,
					TOTALS_STOPOFFS_NBR, RCVR_COUNTRY, HAZMAT_CD,
					HAZMAT_CD_QUALIFIER, HAZMAT_CLASS_CD, HAZMAT_DSC,
					HAZMAT_CONTACT, SPECIAL_HANDLING_CD, MOVE_TYPE_CD,
					SEA_AIR_FLG, VOYAGE_NO, POD_LOCATION_CD,
					POL_LOCATION_CD, HANDLING_NOTES, PROCESSED_FLG)
				VALUES
					(EDI300_ID_SEQ.NEXTVAL, @ISA_ID, @ISA_NBR,
					@TRADING_PARTNER_CD, @REQUEST_CD, @REQUEST_DT,
					@PROJECT_CD, @CONTRACT_NO, @TAC_NO,
					@FMS_CASE_NO, @VESSEL_QUALIFIER, @VESSEL_CD,
					@VESSEL_DSC, @PARTNER_VOYAGE_NO, @SAIL_DT,
					@POL_QUALIFIER, @POL_CD, @POL_DSC,
					@POD_QUALIFIER, @POD_CD, @POD_DSC,
					@CARGO_AVAIL_DT, @RDD_DT, @DELIVERY_DSC,
					@DELIVERY_DSC2, @SHIP_UNITS_NBR, @CARGO_CD,
					@ISO_EQP_TYPE_CD, @ORIG_TERMS_CD, @DEST_TERMS_CD,
					@TOTALS_STOPOFFS_NBR, @RCVR_COUNTRY, @HAZMAT_CD,
					@HAZMAT_CD_QUALIFIER, @HAZMAT_CLASS_CD, @HAZMAT_DSC,
					@HAZMAT_CONTACT, @SPECIAL_HANDLING_CD, @MOVE_TYPE_CD,
					@SEA_AIR_FLG, @VOYAGE_NO, @POD_LOCATION_CD,
					@POL_LOCATION_CD, @HANDLING_NOTES, @PROCESSED_FLG)
				RETURNING
					EDI300_ID, CREATE_DT, CREATE_USER,
					MODIFY_DT, MODIFY_USER
				INTO
					@EDI300_ID, @CREATE_DT, @CREATE_USER,
					@MODIFY_DT, @MODIFY_USER";
			int ret = Connection.RunSQL(sql, p);

			Edi300_ID = ClsConvert.ToInt64Nullable(p[44].Value);
			Create_Dt = ClsConvert.ToDateTimeNullable(p[45].Value);
			Create_User = ClsConvert.ToString(p[46].Value);
			Modify_Dt = ClsConvert.ToDateTimeNullable(p[47].Value);
			Modify_User = ClsConvert.ToString(p[48].Value);
			return ret;
		}
		public override int Update()
		{
			DbParameter[] p = new DbParameter[47];

			p[0] = Connection.GetParameter
				("@ISA_ID", Isa_ID);
			p[1] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.InputOutput, DbType.DateTime, 0);
			p[2] = Connection.GetParameter
				("@ISA_NBR", Isa_Nbr);
			p[3] = Connection.GetParameter
				("@TRADING_PARTNER_CD", Trading_Partner_Cd);
			p[4] = Connection.GetParameter
				("@REQUEST_CD", Request_Cd);
			p[5] = Connection.GetParameter
				("@REQUEST_DT", Request_Dt);
			p[6] = Connection.GetParameter
				("@PROJECT_CD", Project_Cd);
			p[7] = Connection.GetParameter
				("@CONTRACT_NO", Contract_No);
			p[8] = Connection.GetParameter
				("@TAC_NO", Tac_No);
			p[9] = Connection.GetParameter
				("@FMS_CASE_NO", Fms_Case_No);
			p[10] = Connection.GetParameter
				("@VESSEL_QUALIFIER", Vessel_Qualifier);
			p[11] = Connection.GetParameter
				("@VESSEL_CD", Vessel_Cd);
			p[12] = Connection.GetParameter
				("@VESSEL_DSC", Vessel_Dsc);
			p[13] = Connection.GetParameter
				("@PARTNER_VOYAGE_NO", Partner_Voyage_No);
			p[14] = Connection.GetParameter
				("@SAIL_DT", Sail_Dt);
			p[15] = Connection.GetParameter
				("@POL_QUALIFIER", Pol_Qualifier);
			p[16] = Connection.GetParameter
				("@POL_CD", Pol_Cd);
			p[17] = Connection.GetParameter
				("@POL_DSC", Pol_Dsc);
			p[18] = Connection.GetParameter
				("@POD_QUALIFIER", Pod_Qualifier);
			p[19] = Connection.GetParameter
				("@POD_CD", Pod_Cd);
			p[20] = Connection.GetParameter
				("@POD_DSC", Pod_Dsc);
			p[21] = Connection.GetParameter
				("@CARGO_AVAIL_DT", Cargo_Avail_Dt);
			p[22] = Connection.GetParameter
				("@RDD_DT", Rdd_Dt);
			p[23] = Connection.GetParameter
				("@DELIVERY_DSC", Delivery_Dsc);
			p[24] = Connection.GetParameter
				("@DELIVERY_DSC2", Delivery_Dsc2);
			p[25] = Connection.GetParameter
				("@SHIP_UNITS_NBR", Ship_Units_Nbr);
			p[26] = Connection.GetParameter
				("@CARGO_CD", Cargo_Cd);
			p[27] = Connection.GetParameter
				("@ISO_EQP_TYPE_CD", Iso_Eqp_Type_Cd);
			p[28] = Connection.GetParameter
				("@ORIG_TERMS_CD", Orig_Terms_Cd);
			p[29] = Connection.GetParameter
				("@DEST_TERMS_CD", Dest_Terms_Cd);
			p[30] = Connection.GetParameter
				("@TOTALS_STOPOFFS_NBR", Totals_Stopoffs_Nbr);
			p[31] = Connection.GetParameter
				("@RCVR_COUNTRY", Rcvr_Country);
			p[32] = Connection.GetParameter
				("@HAZMAT_CD", Hazmat_Cd);
			p[33] = Connection.GetParameter
				("@HAZMAT_CD_QUALIFIER", Hazmat_Cd_Qualifier);
			p[34] = Connection.GetParameter
				("@HAZMAT_CLASS_CD", Hazmat_Class_Cd);
			p[35] = Connection.GetParameter
				("@HAZMAT_DSC", Hazmat_Dsc);
			p[36] = Connection.GetParameter
				("@HAZMAT_CONTACT", Hazmat_Contact);
			p[37] = Connection.GetParameter
				("@SPECIAL_HANDLING_CD", Special_Handling_Cd);
			p[38] = Connection.GetParameter
				("@MOVE_TYPE_CD", Move_Type_Cd);
			p[39] = Connection.GetParameter
				("@SEA_AIR_FLG", Sea_Air_Flg);
			p[40] = Connection.GetParameter
				("@VOYAGE_NO", Voyage_No);
			p[41] = Connection.GetParameter
				("@POD_LOCATION_CD", Pod_Location_Cd);
			p[42] = Connection.GetParameter
				("@POL_LOCATION_CD", Pol_Location_Cd);
			p[43] = Connection.GetParameter
				("@HANDLING_NOTES", Handling_Notes);
			p[44] = Connection.GetParameter
				("@PROCESSED_FLG", Processed_Flg);
			p[45] = Connection.GetParameter
				("@EDI300_ID", Edi300_ID);
			p[46] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);

			const string sql = @"
				UPDATE T_EDI300 SET
					ISA_ID = @ISA_ID,
					MODIFY_DT = @MODIFY_DT,
					ISA_NBR = @ISA_NBR,
					TRADING_PARTNER_CD = @TRADING_PARTNER_CD,
					REQUEST_CD = @REQUEST_CD,
					REQUEST_DT = @REQUEST_DT,
					PROJECT_CD = @PROJECT_CD,
					CONTRACT_NO = @CONTRACT_NO,
					TAC_NO = @TAC_NO,
					FMS_CASE_NO = @FMS_CASE_NO,
					VESSEL_QUALIFIER = @VESSEL_QUALIFIER,
					VESSEL_CD = @VESSEL_CD,
					VESSEL_DSC = @VESSEL_DSC,
					PARTNER_VOYAGE_NO = @PARTNER_VOYAGE_NO,
					SAIL_DT = @SAIL_DT,
					POL_QUALIFIER = @POL_QUALIFIER,
					POL_CD = @POL_CD,
					POL_DSC = @POL_DSC,
					POD_QUALIFIER = @POD_QUALIFIER,
					POD_CD = @POD_CD,
					POD_DSC = @POD_DSC,
					CARGO_AVAIL_DT = @CARGO_AVAIL_DT,
					RDD_DT = @RDD_DT,
					DELIVERY_DSC = @DELIVERY_DSC,
					DELIVERY_DSC2 = @DELIVERY_DSC2,
					SHIP_UNITS_NBR = @SHIP_UNITS_NBR,
					CARGO_CD = @CARGO_CD,
					ISO_EQP_TYPE_CD = @ISO_EQP_TYPE_CD,
					ORIG_TERMS_CD = @ORIG_TERMS_CD,
					DEST_TERMS_CD = @DEST_TERMS_CD,
					TOTALS_STOPOFFS_NBR = @TOTALS_STOPOFFS_NBR,
					RCVR_COUNTRY = @RCVR_COUNTRY,
					HAZMAT_CD = @HAZMAT_CD,
					HAZMAT_CD_QUALIFIER = @HAZMAT_CD_QUALIFIER,
					HAZMAT_CLASS_CD = @HAZMAT_CLASS_CD,
					HAZMAT_DSC = @HAZMAT_DSC,
					HAZMAT_CONTACT = @HAZMAT_CONTACT,
					SPECIAL_HANDLING_CD = @SPECIAL_HANDLING_CD,
					MOVE_TYPE_CD = @MOVE_TYPE_CD,
					SEA_AIR_FLG = @SEA_AIR_FLG,
					VOYAGE_NO = @VOYAGE_NO,
					POD_LOCATION_CD = @POD_LOCATION_CD,
					POL_LOCATION_CD = @POL_LOCATION_CD,
					HANDLING_NOTES = @HANDLING_NOTES,
					PROCESSED_FLG = @PROCESSED_FLG
				WHERE
					EDI300_ID = @EDI300_ID
				RETURNING
					MODIFY_DT, MODIFY_USER
				INTO
					@MODIFY_DT, @MODIFY_USER";
			int ret = Connection.RunSQL(sql, p);

			Modify_Dt = ClsConvert.ToDateTimeNullable(p[1].Value);
			Modify_User = ClsConvert.ToString(p[46].Value);
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

			Edi300_ID = ClsConvert.ToInt64Nullable(dr["EDI300_ID"]);
			Isa_ID = ClsConvert.ToInt64Nullable(dr["ISA_ID"]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT"]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER"]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT"]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER"]);
			Isa_Nbr = ClsConvert.ToInt64Nullable(dr["ISA_NBR"]);
			Trading_Partner_Cd = ClsConvert.ToString(dr["TRADING_PARTNER_CD"]);
			Request_Cd = ClsConvert.ToString(dr["REQUEST_CD"]);
			Request_Dt = ClsConvert.ToDateTimeNullable(dr["REQUEST_DT"]);
			Project_Cd = ClsConvert.ToString(dr["PROJECT_CD"]);
			Contract_No = ClsConvert.ToString(dr["CONTRACT_NO"]);
			Tac_No = ClsConvert.ToString(dr["TAC_NO"]);
			Fms_Case_No = ClsConvert.ToString(dr["FMS_CASE_NO"]);
			Vessel_Qualifier = ClsConvert.ToString(dr["VESSEL_QUALIFIER"]);
			Vessel_Cd = ClsConvert.ToString(dr["VESSEL_CD"]);
			Vessel_Dsc = ClsConvert.ToString(dr["VESSEL_DSC"]);
			Partner_Voyage_No = ClsConvert.ToString(dr["PARTNER_VOYAGE_NO"]);
			Sail_Dt = ClsConvert.ToDateTimeNullable(dr["SAIL_DT"]);
			Pol_Qualifier = ClsConvert.ToString(dr["POL_QUALIFIER"]);
			Pol_Cd = ClsConvert.ToString(dr["POL_CD"]);
			Pol_Dsc = ClsConvert.ToString(dr["POL_DSC"]);
			Pod_Qualifier = ClsConvert.ToString(dr["POD_QUALIFIER"]);
			Pod_Cd = ClsConvert.ToString(dr["POD_CD"]);
			Pod_Dsc = ClsConvert.ToString(dr["POD_DSC"]);
			Cargo_Avail_Dt = ClsConvert.ToDateTimeNullable(dr["CARGO_AVAIL_DT"]);
			Rdd_Dt = ClsConvert.ToDateTimeNullable(dr["RDD_DT"]);
			Delivery_Dsc = ClsConvert.ToString(dr["DELIVERY_DSC"]);
			Delivery_Dsc2 = ClsConvert.ToString(dr["DELIVERY_DSC2"]);
			Ship_Units_Nbr = ClsConvert.ToInt32Nullable(dr["SHIP_UNITS_NBR"]);
			Cargo_Cd = ClsConvert.ToString(dr["CARGO_CD"]);
			Iso_Eqp_Type_Cd = ClsConvert.ToString(dr["ISO_EQP_TYPE_CD"]);
			Orig_Terms_Cd = ClsConvert.ToString(dr["ORIG_TERMS_CD"]);
			Dest_Terms_Cd = ClsConvert.ToString(dr["DEST_TERMS_CD"]);
			Totals_Stopoffs_Nbr = ClsConvert.ToInt32Nullable(dr["TOTALS_STOPOFFS_NBR"]);
			Rcvr_Country = ClsConvert.ToString(dr["RCVR_COUNTRY"]);
			Hazmat_Cd = ClsConvert.ToString(dr["HAZMAT_CD"]);
			Hazmat_Cd_Qualifier = ClsConvert.ToString(dr["HAZMAT_CD_QUALIFIER"]);
			Hazmat_Class_Cd = ClsConvert.ToString(dr["HAZMAT_CLASS_CD"]);
			Hazmat_Dsc = ClsConvert.ToString(dr["HAZMAT_DSC"]);
			Hazmat_Contact = ClsConvert.ToString(dr["HAZMAT_CONTACT"]);
			Special_Handling_Cd = ClsConvert.ToString(dr["SPECIAL_HANDLING_CD"]);
			Move_Type_Cd = ClsConvert.ToString(dr["MOVE_TYPE_CD"]);
			Sea_Air_Flg = ClsConvert.ToString(dr["SEA_AIR_FLG"]);
			Voyage_No = ClsConvert.ToString(dr["VOYAGE_NO"]);
			Pod_Location_Cd = ClsConvert.ToString(dr["POD_LOCATION_CD"]);
			Pol_Location_Cd = ClsConvert.ToString(dr["POL_LOCATION_CD"]);
			Handling_Notes = ClsConvert.ToString(dr["HANDLING_NOTES"]);
			Processed_Flg = ClsConvert.ToString(dr["PROCESSED_FLG"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Edi300_ID = ClsConvert.ToInt64Nullable(dr["EDI300_ID", v]);
			Isa_ID = ClsConvert.ToInt64Nullable(dr["ISA_ID", v]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT", v]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER", v]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT", v]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER", v]);
			Isa_Nbr = ClsConvert.ToInt64Nullable(dr["ISA_NBR", v]);
			Trading_Partner_Cd = ClsConvert.ToString(dr["TRADING_PARTNER_CD", v]);
			Request_Cd = ClsConvert.ToString(dr["REQUEST_CD", v]);
			Request_Dt = ClsConvert.ToDateTimeNullable(dr["REQUEST_DT", v]);
			Project_Cd = ClsConvert.ToString(dr["PROJECT_CD", v]);
			Contract_No = ClsConvert.ToString(dr["CONTRACT_NO", v]);
			Tac_No = ClsConvert.ToString(dr["TAC_NO", v]);
			Fms_Case_No = ClsConvert.ToString(dr["FMS_CASE_NO", v]);
			Vessel_Qualifier = ClsConvert.ToString(dr["VESSEL_QUALIFIER", v]);
			Vessel_Cd = ClsConvert.ToString(dr["VESSEL_CD", v]);
			Vessel_Dsc = ClsConvert.ToString(dr["VESSEL_DSC", v]);
			Partner_Voyage_No = ClsConvert.ToString(dr["PARTNER_VOYAGE_NO", v]);
			Sail_Dt = ClsConvert.ToDateTimeNullable(dr["SAIL_DT", v]);
			Pol_Qualifier = ClsConvert.ToString(dr["POL_QUALIFIER", v]);
			Pol_Cd = ClsConvert.ToString(dr["POL_CD", v]);
			Pol_Dsc = ClsConvert.ToString(dr["POL_DSC", v]);
			Pod_Qualifier = ClsConvert.ToString(dr["POD_QUALIFIER", v]);
			Pod_Cd = ClsConvert.ToString(dr["POD_CD", v]);
			Pod_Dsc = ClsConvert.ToString(dr["POD_DSC", v]);
			Cargo_Avail_Dt = ClsConvert.ToDateTimeNullable(dr["CARGO_AVAIL_DT", v]);
			Rdd_Dt = ClsConvert.ToDateTimeNullable(dr["RDD_DT", v]);
			Delivery_Dsc = ClsConvert.ToString(dr["DELIVERY_DSC", v]);
			Delivery_Dsc2 = ClsConvert.ToString(dr["DELIVERY_DSC2", v]);
			Ship_Units_Nbr = ClsConvert.ToInt32Nullable(dr["SHIP_UNITS_NBR", v]);
			Cargo_Cd = ClsConvert.ToString(dr["CARGO_CD", v]);
			Iso_Eqp_Type_Cd = ClsConvert.ToString(dr["ISO_EQP_TYPE_CD", v]);
			Orig_Terms_Cd = ClsConvert.ToString(dr["ORIG_TERMS_CD", v]);
			Dest_Terms_Cd = ClsConvert.ToString(dr["DEST_TERMS_CD", v]);
			Totals_Stopoffs_Nbr = ClsConvert.ToInt32Nullable(dr["TOTALS_STOPOFFS_NBR", v]);
			Rcvr_Country = ClsConvert.ToString(dr["RCVR_COUNTRY", v]);
			Hazmat_Cd = ClsConvert.ToString(dr["HAZMAT_CD", v]);
			Hazmat_Cd_Qualifier = ClsConvert.ToString(dr["HAZMAT_CD_QUALIFIER", v]);
			Hazmat_Class_Cd = ClsConvert.ToString(dr["HAZMAT_CLASS_CD", v]);
			Hazmat_Dsc = ClsConvert.ToString(dr["HAZMAT_DSC", v]);
			Hazmat_Contact = ClsConvert.ToString(dr["HAZMAT_CONTACT", v]);
			Special_Handling_Cd = ClsConvert.ToString(dr["SPECIAL_HANDLING_CD", v]);
			Move_Type_Cd = ClsConvert.ToString(dr["MOVE_TYPE_CD", v]);
			Sea_Air_Flg = ClsConvert.ToString(dr["SEA_AIR_FLG", v]);
			Voyage_No = ClsConvert.ToString(dr["VOYAGE_NO", v]);
			Pod_Location_Cd = ClsConvert.ToString(dr["POD_LOCATION_CD", v]);
			Pol_Location_Cd = ClsConvert.ToString(dr["POL_LOCATION_CD", v]);
			Handling_Notes = ClsConvert.ToString(dr["HANDLING_NOTES", v]);
			Processed_Flg = ClsConvert.ToString(dr["PROCESSED_FLG", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["EDI300_ID"] = ClsConvert.ToDbObject(Edi300_ID);
			dr["ISA_ID"] = ClsConvert.ToDbObject(Isa_ID);
			dr["CREATE_DT"] = ClsConvert.ToDbObject(Create_Dt);
			dr["CREATE_USER"] = ClsConvert.ToDbObject(Create_User);
			dr["MODIFY_DT"] = ClsConvert.ToDbObject(Modify_Dt);
			dr["MODIFY_USER"] = ClsConvert.ToDbObject(Modify_User);
			dr["ISA_NBR"] = ClsConvert.ToDbObject(Isa_Nbr);
			dr["TRADING_PARTNER_CD"] = ClsConvert.ToDbObject(Trading_Partner_Cd);
			dr["REQUEST_CD"] = ClsConvert.ToDbObject(Request_Cd);
			dr["REQUEST_DT"] = ClsConvert.ToDbObject(Request_Dt);
			dr["PROJECT_CD"] = ClsConvert.ToDbObject(Project_Cd);
			dr["CONTRACT_NO"] = ClsConvert.ToDbObject(Contract_No);
			dr["TAC_NO"] = ClsConvert.ToDbObject(Tac_No);
			dr["FMS_CASE_NO"] = ClsConvert.ToDbObject(Fms_Case_No);
			dr["VESSEL_QUALIFIER"] = ClsConvert.ToDbObject(Vessel_Qualifier);
			dr["VESSEL_CD"] = ClsConvert.ToDbObject(Vessel_Cd);
			dr["VESSEL_DSC"] = ClsConvert.ToDbObject(Vessel_Dsc);
			dr["PARTNER_VOYAGE_NO"] = ClsConvert.ToDbObject(Partner_Voyage_No);
			dr["SAIL_DT"] = ClsConvert.ToDbObject(Sail_Dt);
			dr["POL_QUALIFIER"] = ClsConvert.ToDbObject(Pol_Qualifier);
			dr["POL_CD"] = ClsConvert.ToDbObject(Pol_Cd);
			dr["POL_DSC"] = ClsConvert.ToDbObject(Pol_Dsc);
			dr["POD_QUALIFIER"] = ClsConvert.ToDbObject(Pod_Qualifier);
			dr["POD_CD"] = ClsConvert.ToDbObject(Pod_Cd);
			dr["POD_DSC"] = ClsConvert.ToDbObject(Pod_Dsc);
			dr["CARGO_AVAIL_DT"] = ClsConvert.ToDbObject(Cargo_Avail_Dt);
			dr["RDD_DT"] = ClsConvert.ToDbObject(Rdd_Dt);
			dr["DELIVERY_DSC"] = ClsConvert.ToDbObject(Delivery_Dsc);
			dr["DELIVERY_DSC2"] = ClsConvert.ToDbObject(Delivery_Dsc2);
			dr["SHIP_UNITS_NBR"] = ClsConvert.ToDbObject(Ship_Units_Nbr);
			dr["CARGO_CD"] = ClsConvert.ToDbObject(Cargo_Cd);
			dr["ISO_EQP_TYPE_CD"] = ClsConvert.ToDbObject(Iso_Eqp_Type_Cd);
			dr["ORIG_TERMS_CD"] = ClsConvert.ToDbObject(Orig_Terms_Cd);
			dr["DEST_TERMS_CD"] = ClsConvert.ToDbObject(Dest_Terms_Cd);
			dr["TOTALS_STOPOFFS_NBR"] = ClsConvert.ToDbObject(Totals_Stopoffs_Nbr);
			dr["RCVR_COUNTRY"] = ClsConvert.ToDbObject(Rcvr_Country);
			dr["HAZMAT_CD"] = ClsConvert.ToDbObject(Hazmat_Cd);
			dr["HAZMAT_CD_QUALIFIER"] = ClsConvert.ToDbObject(Hazmat_Cd_Qualifier);
			dr["HAZMAT_CLASS_CD"] = ClsConvert.ToDbObject(Hazmat_Class_Cd);
			dr["HAZMAT_DSC"] = ClsConvert.ToDbObject(Hazmat_Dsc);
			dr["HAZMAT_CONTACT"] = ClsConvert.ToDbObject(Hazmat_Contact);
			dr["SPECIAL_HANDLING_CD"] = ClsConvert.ToDbObject(Special_Handling_Cd);
			dr["MOVE_TYPE_CD"] = ClsConvert.ToDbObject(Move_Type_Cd);
			dr["SEA_AIR_FLG"] = ClsConvert.ToDbObject(Sea_Air_Flg);
			dr["VOYAGE_NO"] = ClsConvert.ToDbObject(Voyage_No);
			dr["POD_LOCATION_CD"] = ClsConvert.ToDbObject(Pod_Location_Cd);
			dr["POL_LOCATION_CD"] = ClsConvert.ToDbObject(Pol_Location_Cd);
			dr["HANDLING_NOTES"] = ClsConvert.ToDbObject(Handling_Notes);
			dr["PROCESSED_FLG"] = ClsConvert.ToDbObject(Processed_Flg);
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

		public static ClsEdi300 GetUsingKey(Int64 Edi300_ID)
		{
			object[] vals = new object[] {Edi300_ID};
			DataRow dr = Connection.GetDataRowUsingKey
				(TableName, GetPrimaryKeys(), vals);
			return ( dr == null ) ? null : new ClsEdi300(dr);
		}
		public static DataTable GetAll(Int64? Isa_ID)
		{
			List<DbParameter> lst = new List<DbParameter>();	
			StringBuilder sb = new StringBuilder();
		
			if( Isa_ID != null && Isa_ID > 0 )
			{
				lst.Add(Connection.GetParameter("@ISA_ID", Isa_ID));
				sb.Append(" WHERE T_EDI300.ISA_ID=@ISA_ID");
			}
			sb.Insert(0, SelectSQL);
			return Connection.GetDataTable(sb.ToString(), lst.ToArray());
		}
		#endregion		// #region Static Methods
	}
}