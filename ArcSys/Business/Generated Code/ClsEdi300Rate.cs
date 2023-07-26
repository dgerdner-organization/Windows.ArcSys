using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsEdi300Rate : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["OCEAN"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "T_EDI300_RATE";
		public const int PrimaryKeyCount = 1;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] { "EDI300_RATE_ID" };
		}

		public const string SelectSQL = @"SELECT * FROM T_EDI300_RATE 
				LEFT OUTER JOIN T_EDI300
				ON T_EDI300_RATE.EDI300_ID=T_EDI300.EDI300_ID ";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Create_UserMax = 30;
		public const int Modify_UserMax = 30;
		public const int Transmission_KeyMax = 50;
		public const int B102_Bkg_NoMax = 30;
		public const int Lx01_Item_NbrMax = 10;
		public const int L108_Special_Charge_CdMax = 10;
		public const int L102_Rate_AmtMax = 20;
		public const int L103_Rate_Type_CdMax = 10;
		public const int L104_Charge_AmtMax = 20;
		public const int L105_Advance_AmtMax = 20;
		public const int L106_Prepaid_AmtMax = 20;
		public const int L107_Combo_CdMax = 10;
		public const int L109_Rate_Class_CdMax = 10;
		public const int L110_Entitlement_CdMax = 10;
		public const int L111_Payment_Mth_CdMax = 10;
		public const int L112_Special_Charge_DscMax = 100;
		public const int L113_Tariff_CdMax = 10;
		public const int L114_Declared_Val_AmtMax = 20;
		public const int L115_Rate_Qual_CdMax = 10;
		public const int L116_Liability_Limit_CdMax = 10;
		public const int L117_Rate_Basis_AmtMax = 20;
		public const int L118_Rate_Basis_Qual_CdMax = 10;
		public const int L119_Pct_AmtMax = 20;
		public const int L120_Currency_CdMax = 10;
		public const int L121_Tot_AmtMax = 20;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected Int64? _Edi300_Rate_ID;
		protected Int64? _Edi300_ID;
		protected DateTime? _Create_Dt;
		protected string _Create_User;
		protected DateTime? _Modify_Dt;
		protected string _Modify_User;
		protected string _Transmission_Key;
		protected string _B102_Bkg_No;
		protected string _Lx01_Item_Nbr;
		protected string _L108_Special_Charge_Cd;
		protected string _L102_Rate_Amt;
		protected string _L103_Rate_Type_Cd;
		protected string _L104_Charge_Amt;
		protected string _L105_Advance_Amt;
		protected string _L106_Prepaid_Amt;
		protected string _L107_Combo_Cd;
		protected string _L109_Rate_Class_Cd;
		protected string _L110_Entitlement_Cd;
		protected string _L111_Payment_Mth_Cd;
		protected string _L112_Special_Charge_Dsc;
		protected string _L113_Tariff_Cd;
		protected string _L114_Declared_Val_Amt;
		protected string _L115_Rate_Qual_Cd;
		protected string _L116_Liability_Limit_Cd;
		protected string _L117_Rate_Basis_Amt;
		protected string _L118_Rate_Basis_Qual_Cd;
		protected string _L119_Pct_Amt;
		protected string _L120_Currency_Cd;
		protected string _L121_Tot_Amt;

		#endregion	// #region Column Fields

		#region Column Properties

		public Int64? Edi300_Rate_ID
		{
			get { return _Edi300_Rate_ID; }
			set
			{
				if( _Edi300_Rate_ID == value ) return;
		
				_Edi300_Rate_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Edi300_Rate_ID");
			}
		}
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
		public string Transmission_Key
		{
			get { return _Transmission_Key; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Transmission_Key, val, false) == 0 ) return;
		
				if( val != null && val.Length > Transmission_KeyMax )
					_Transmission_Key = val.Substring(0, (int)Transmission_KeyMax);
				else
					_Transmission_Key = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Transmission_Key");
			}
		}
		public string B102_Bkg_No
		{
			get { return _B102_Bkg_No; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_B102_Bkg_No, val, false) == 0 ) return;
		
				if( val != null && val.Length > B102_Bkg_NoMax )
					_B102_Bkg_No = val.Substring(0, (int)B102_Bkg_NoMax);
				else
					_B102_Bkg_No = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("B102_Bkg_No");
			}
		}
		public string Lx01_Item_Nbr
		{
			get { return _Lx01_Item_Nbr; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Lx01_Item_Nbr, val, false) == 0 ) return;
		
				if( val != null && val.Length > Lx01_Item_NbrMax )
					_Lx01_Item_Nbr = val.Substring(0, (int)Lx01_Item_NbrMax);
				else
					_Lx01_Item_Nbr = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Lx01_Item_Nbr");
			}
		}
		public string L108_Special_Charge_Cd
		{
			get { return _L108_Special_Charge_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_L108_Special_Charge_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > L108_Special_Charge_CdMax )
					_L108_Special_Charge_Cd = val.Substring(0, (int)L108_Special_Charge_CdMax);
				else
					_L108_Special_Charge_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("L108_Special_Charge_Cd");
			}
		}
		public string L102_Rate_Amt
		{
			get { return _L102_Rate_Amt; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_L102_Rate_Amt, val, false) == 0 ) return;
		
				if( val != null && val.Length > L102_Rate_AmtMax )
					_L102_Rate_Amt = val.Substring(0, (int)L102_Rate_AmtMax);
				else
					_L102_Rate_Amt = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("L102_Rate_Amt");
			}
		}
		public string L103_Rate_Type_Cd
		{
			get { return _L103_Rate_Type_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_L103_Rate_Type_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > L103_Rate_Type_CdMax )
					_L103_Rate_Type_Cd = val.Substring(0, (int)L103_Rate_Type_CdMax);
				else
					_L103_Rate_Type_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("L103_Rate_Type_Cd");
			}
		}
		public string L104_Charge_Amt
		{
			get { return _L104_Charge_Amt; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_L104_Charge_Amt, val, false) == 0 ) return;
		
				if( val != null && val.Length > L104_Charge_AmtMax )
					_L104_Charge_Amt = val.Substring(0, (int)L104_Charge_AmtMax);
				else
					_L104_Charge_Amt = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("L104_Charge_Amt");
			}
		}
		public string L105_Advance_Amt
		{
			get { return _L105_Advance_Amt; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_L105_Advance_Amt, val, false) == 0 ) return;
		
				if( val != null && val.Length > L105_Advance_AmtMax )
					_L105_Advance_Amt = val.Substring(0, (int)L105_Advance_AmtMax);
				else
					_L105_Advance_Amt = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("L105_Advance_Amt");
			}
		}
		public string L106_Prepaid_Amt
		{
			get { return _L106_Prepaid_Amt; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_L106_Prepaid_Amt, val, false) == 0 ) return;
		
				if( val != null && val.Length > L106_Prepaid_AmtMax )
					_L106_Prepaid_Amt = val.Substring(0, (int)L106_Prepaid_AmtMax);
				else
					_L106_Prepaid_Amt = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("L106_Prepaid_Amt");
			}
		}
		public string L107_Combo_Cd
		{
			get { return _L107_Combo_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_L107_Combo_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > L107_Combo_CdMax )
					_L107_Combo_Cd = val.Substring(0, (int)L107_Combo_CdMax);
				else
					_L107_Combo_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("L107_Combo_Cd");
			}
		}
		public string L109_Rate_Class_Cd
		{
			get { return _L109_Rate_Class_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_L109_Rate_Class_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > L109_Rate_Class_CdMax )
					_L109_Rate_Class_Cd = val.Substring(0, (int)L109_Rate_Class_CdMax);
				else
					_L109_Rate_Class_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("L109_Rate_Class_Cd");
			}
		}
		public string L110_Entitlement_Cd
		{
			get { return _L110_Entitlement_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_L110_Entitlement_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > L110_Entitlement_CdMax )
					_L110_Entitlement_Cd = val.Substring(0, (int)L110_Entitlement_CdMax);
				else
					_L110_Entitlement_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("L110_Entitlement_Cd");
			}
		}
		public string L111_Payment_Mth_Cd
		{
			get { return _L111_Payment_Mth_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_L111_Payment_Mth_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > L111_Payment_Mth_CdMax )
					_L111_Payment_Mth_Cd = val.Substring(0, (int)L111_Payment_Mth_CdMax);
				else
					_L111_Payment_Mth_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("L111_Payment_Mth_Cd");
			}
		}
		public string L112_Special_Charge_Dsc
		{
			get { return _L112_Special_Charge_Dsc; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_L112_Special_Charge_Dsc, val, false) == 0 ) return;
		
				if( val != null && val.Length > L112_Special_Charge_DscMax )
					_L112_Special_Charge_Dsc = val.Substring(0, (int)L112_Special_Charge_DscMax);
				else
					_L112_Special_Charge_Dsc = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("L112_Special_Charge_Dsc");
			}
		}
		public string L113_Tariff_Cd
		{
			get { return _L113_Tariff_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_L113_Tariff_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > L113_Tariff_CdMax )
					_L113_Tariff_Cd = val.Substring(0, (int)L113_Tariff_CdMax);
				else
					_L113_Tariff_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("L113_Tariff_Cd");
			}
		}
		public string L114_Declared_Val_Amt
		{
			get { return _L114_Declared_Val_Amt; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_L114_Declared_Val_Amt, val, false) == 0 ) return;
		
				if( val != null && val.Length > L114_Declared_Val_AmtMax )
					_L114_Declared_Val_Amt = val.Substring(0, (int)L114_Declared_Val_AmtMax);
				else
					_L114_Declared_Val_Amt = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("L114_Declared_Val_Amt");
			}
		}
		public string L115_Rate_Qual_Cd
		{
			get { return _L115_Rate_Qual_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_L115_Rate_Qual_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > L115_Rate_Qual_CdMax )
					_L115_Rate_Qual_Cd = val.Substring(0, (int)L115_Rate_Qual_CdMax);
				else
					_L115_Rate_Qual_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("L115_Rate_Qual_Cd");
			}
		}
		public string L116_Liability_Limit_Cd
		{
			get { return _L116_Liability_Limit_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_L116_Liability_Limit_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > L116_Liability_Limit_CdMax )
					_L116_Liability_Limit_Cd = val.Substring(0, (int)L116_Liability_Limit_CdMax);
				else
					_L116_Liability_Limit_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("L116_Liability_Limit_Cd");
			}
		}
		public string L117_Rate_Basis_Amt
		{
			get { return _L117_Rate_Basis_Amt; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_L117_Rate_Basis_Amt, val, false) == 0 ) return;
		
				if( val != null && val.Length > L117_Rate_Basis_AmtMax )
					_L117_Rate_Basis_Amt = val.Substring(0, (int)L117_Rate_Basis_AmtMax);
				else
					_L117_Rate_Basis_Amt = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("L117_Rate_Basis_Amt");
			}
		}
		public string L118_Rate_Basis_Qual_Cd
		{
			get { return _L118_Rate_Basis_Qual_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_L118_Rate_Basis_Qual_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > L118_Rate_Basis_Qual_CdMax )
					_L118_Rate_Basis_Qual_Cd = val.Substring(0, (int)L118_Rate_Basis_Qual_CdMax);
				else
					_L118_Rate_Basis_Qual_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("L118_Rate_Basis_Qual_Cd");
			}
		}
		public string L119_Pct_Amt
		{
			get { return _L119_Pct_Amt; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_L119_Pct_Amt, val, false) == 0 ) return;
		
				if( val != null && val.Length > L119_Pct_AmtMax )
					_L119_Pct_Amt = val.Substring(0, (int)L119_Pct_AmtMax);
				else
					_L119_Pct_Amt = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("L119_Pct_Amt");
			}
		}
		public string L120_Currency_Cd
		{
			get { return _L120_Currency_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_L120_Currency_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > L120_Currency_CdMax )
					_L120_Currency_Cd = val.Substring(0, (int)L120_Currency_CdMax);
				else
					_L120_Currency_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("L120_Currency_Cd");
			}
		}
		public string L121_Tot_Amt
		{
			get { return _L121_Tot_Amt; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_L121_Tot_Amt, val, false) == 0 ) return;
		
				if( val != null && val.Length > L121_Tot_AmtMax )
					_L121_Tot_Amt = val.Substring(0, (int)L121_Tot_AmtMax);
				else
					_L121_Tot_Amt = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("L121_Tot_Amt");
			}
		}

		#endregion	// #region Column Properties

		#region Foreign Key Fields

		protected ClsEdi300 _Edi300;

		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties

		public ClsEdi300 Edi300
		{
			get
			{
				if( Edi300_ID == null )
					_Edi300 = null;
				else if( _Edi300 == null ||
					_Edi300.Edi300_ID != Edi300_ID )
					_Edi300 = ClsEdi300.GetUsingKey(Edi300_ID.Value);
				return _Edi300;
			}
			set
			{
				if( _Edi300 == value ) return;
		
				_Edi300 = value;
			}
		}

		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsEdi300Rate() : base() {}
		public ClsEdi300Rate(DataRow dr) : base(dr) {}
		public ClsEdi300Rate(ClsEdi300Rate src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Edi300_Rate_ID = null;
			Edi300_ID = null;
			Create_Dt = null;
			Create_User = null;
			Modify_Dt = null;
			Modify_User = null;
			Transmission_Key = null;
			B102_Bkg_No = null;
			Lx01_Item_Nbr = null;
			L108_Special_Charge_Cd = null;
			L102_Rate_Amt = null;
			L103_Rate_Type_Cd = null;
			L104_Charge_Amt = null;
			L105_Advance_Amt = null;
			L106_Prepaid_Amt = null;
			L107_Combo_Cd = null;
			L109_Rate_Class_Cd = null;
			L110_Entitlement_Cd = null;
			L111_Payment_Mth_Cd = null;
			L112_Special_Charge_Dsc = null;
			L113_Tariff_Cd = null;
			L114_Declared_Val_Amt = null;
			L115_Rate_Qual_Cd = null;
			L116_Liability_Limit_Cd = null;
			L117_Rate_Basis_Amt = null;
			L118_Rate_Basis_Qual_Cd = null;
			L119_Pct_Amt = null;
			L120_Currency_Cd = null;
			L121_Tot_Amt = null;
		}

		public void CopyFrom(ClsEdi300Rate src)
		{
			Edi300_Rate_ID = src._Edi300_Rate_ID;
			Edi300_ID = src._Edi300_ID;
			Create_Dt = src._Create_Dt;
			Create_User = src._Create_User;
			Modify_Dt = src._Modify_Dt;
			Modify_User = src._Modify_User;
			Transmission_Key = src._Transmission_Key;
			B102_Bkg_No = src._B102_Bkg_No;
			Lx01_Item_Nbr = src._Lx01_Item_Nbr;
			L108_Special_Charge_Cd = src._L108_Special_Charge_Cd;
			L102_Rate_Amt = src._L102_Rate_Amt;
			L103_Rate_Type_Cd = src._L103_Rate_Type_Cd;
			L104_Charge_Amt = src._L104_Charge_Amt;
			L105_Advance_Amt = src._L105_Advance_Amt;
			L106_Prepaid_Amt = src._L106_Prepaid_Amt;
			L107_Combo_Cd = src._L107_Combo_Cd;
			L109_Rate_Class_Cd = src._L109_Rate_Class_Cd;
			L110_Entitlement_Cd = src._L110_Entitlement_Cd;
			L111_Payment_Mth_Cd = src._L111_Payment_Mth_Cd;
			L112_Special_Charge_Dsc = src._L112_Special_Charge_Dsc;
			L113_Tariff_Cd = src._L113_Tariff_Cd;
			L114_Declared_Val_Amt = src._L114_Declared_Val_Amt;
			L115_Rate_Qual_Cd = src._L115_Rate_Qual_Cd;
			L116_Liability_Limit_Cd = src._L116_Liability_Limit_Cd;
			L117_Rate_Basis_Amt = src._L117_Rate_Basis_Amt;
			L118_Rate_Basis_Qual_Cd = src._L118_Rate_Basis_Qual_Cd;
			L119_Pct_Amt = src._L119_Pct_Amt;
			L120_Currency_Cd = src._L120_Currency_Cd;
			L121_Tot_Amt = src._L121_Tot_Amt;
		}

		public override bool ReloadFromDB()
		{
			ClsEdi300Rate tmp = ClsEdi300Rate.GetUsingKey(Edi300_Rate_ID.Value);
			if( tmp != null ) CopyFrom(tmp);

			ResetFKs();
			OnReload();

			return ( tmp != null );
		}

		public override void ResetFKs()
		{
			_Edi300 = null;
		}
		#endregion		// #region Init methods

		#region Insert, Update, Delete

		public override int Insert()
		{

			DbParameter[] p = new DbParameter[29];

			p[0] = Connection.GetParameter
				("@EDI300_ID", Edi300_ID);
			p[1] = Connection.GetParameter
				("@TRANSMISSION_KEY", Transmission_Key);
			p[2] = Connection.GetParameter
				("@B102_BKG_NO", B102_Bkg_No);
			p[3] = Connection.GetParameter
				("@LX01_ITEM_NBR", Lx01_Item_Nbr);
			p[4] = Connection.GetParameter
				("@L108_SPECIAL_CHARGE_CD", L108_Special_Charge_Cd);
			p[5] = Connection.GetParameter
				("@L102_RATE_AMT", L102_Rate_Amt);
			p[6] = Connection.GetParameter
				("@L103_RATE_TYPE_CD", L103_Rate_Type_Cd);
			p[7] = Connection.GetParameter
				("@L104_CHARGE_AMT", L104_Charge_Amt);
			p[8] = Connection.GetParameter
				("@L105_ADVANCE_AMT", L105_Advance_Amt);
			p[9] = Connection.GetParameter
				("@L106_PREPAID_AMT", L106_Prepaid_Amt);
			p[10] = Connection.GetParameter
				("@L107_COMBO_CD", L107_Combo_Cd);
			p[11] = Connection.GetParameter
				("@L109_RATE_CLASS_CD", L109_Rate_Class_Cd);
			p[12] = Connection.GetParameter
				("@L110_ENTITLEMENT_CD", L110_Entitlement_Cd);
			p[13] = Connection.GetParameter
				("@L111_PAYMENT_MTH_CD", L111_Payment_Mth_Cd);
			p[14] = Connection.GetParameter
				("@L112_SPECIAL_CHARGE_DSC", L112_Special_Charge_Dsc);
			p[15] = Connection.GetParameter
				("@L113_TARIFF_CD", L113_Tariff_Cd);
			p[16] = Connection.GetParameter
				("@L114_DECLARED_VAL_AMT", L114_Declared_Val_Amt);
			p[17] = Connection.GetParameter
				("@L115_RATE_QUAL_CD", L115_Rate_Qual_Cd);
			p[18] = Connection.GetParameter
				("@L116_LIABILITY_LIMIT_CD", L116_Liability_Limit_Cd);
			p[19] = Connection.GetParameter
				("@L117_RATE_BASIS_AMT", L117_Rate_Basis_Amt);
			p[20] = Connection.GetParameter
				("@L118_RATE_BASIS_QUAL_CD", L118_Rate_Basis_Qual_Cd);
			p[21] = Connection.GetParameter
				("@L119_PCT_AMT", L119_Pct_Amt);
			p[22] = Connection.GetParameter
				("@L120_CURRENCY_CD", L120_Currency_Cd);
			p[23] = Connection.GetParameter
				("@L121_TOT_AMT", L121_Tot_Amt);
			p[24] = Connection.GetParameter
				("@EDI300_RATE_ID", Edi300_Rate_ID, ParameterDirection.Output, DbType.Int64, 0);
			p[25] = Connection.GetParameter
				("@CREATE_DT", Create_Dt, ParameterDirection.Output, DbType.DateTime, 0);
			p[26] = Connection.GetParameter
				("@CREATE_USER", Create_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Create_UserMax);
			p[27] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.Output, DbType.DateTime, 0);
			p[28] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);

			const string sql = @"
				INSERT INTO T_EDI300_RATE
					(EDI300_RATE_ID, EDI300_ID, TRANSMISSION_KEY,
					B102_BKG_NO, LX01_ITEM_NBR, L108_SPECIAL_CHARGE_CD,
					L102_RATE_AMT, L103_RATE_TYPE_CD, L104_CHARGE_AMT,
					L105_ADVANCE_AMT, L106_PREPAID_AMT, L107_COMBO_CD,
					L109_RATE_CLASS_CD, L110_ENTITLEMENT_CD, L111_PAYMENT_MTH_CD,
					L112_SPECIAL_CHARGE_DSC, L113_TARIFF_CD, L114_DECLARED_VAL_AMT,
					L115_RATE_QUAL_CD, L116_LIABILITY_LIMIT_CD, L117_RATE_BASIS_AMT,
					L118_RATE_BASIS_QUAL_CD, L119_PCT_AMT, L120_CURRENCY_CD,
					L121_TOT_AMT)
				VALUES
					(EDI300_RATE_ID_SEQ.NEXTVAL, @EDI300_ID, @TRANSMISSION_KEY,
					@B102_BKG_NO, @LX01_ITEM_NBR, @L108_SPECIAL_CHARGE_CD,
					@L102_RATE_AMT, @L103_RATE_TYPE_CD, @L104_CHARGE_AMT,
					@L105_ADVANCE_AMT, @L106_PREPAID_AMT, @L107_COMBO_CD,
					@L109_RATE_CLASS_CD, @L110_ENTITLEMENT_CD, @L111_PAYMENT_MTH_CD,
					@L112_SPECIAL_CHARGE_DSC, @L113_TARIFF_CD, @L114_DECLARED_VAL_AMT,
					@L115_RATE_QUAL_CD, @L116_LIABILITY_LIMIT_CD, @L117_RATE_BASIS_AMT,
					@L118_RATE_BASIS_QUAL_CD, @L119_PCT_AMT, @L120_CURRENCY_CD,
					@L121_TOT_AMT)
				RETURNING
					EDI300_RATE_ID, CREATE_DT, CREATE_USER,
					MODIFY_DT, MODIFY_USER
				INTO
					@EDI300_RATE_ID, @CREATE_DT, @CREATE_USER,
					@MODIFY_DT, @MODIFY_USER";
			int ret = Connection.RunSQL(sql, p);

			Edi300_Rate_ID = ClsConvert.ToInt64Nullable(p[24].Value);
			Create_Dt = ClsConvert.ToDateTimeNullable(p[25].Value);
			Create_User = ClsConvert.ToString(p[26].Value);
			Modify_Dt = ClsConvert.ToDateTimeNullable(p[27].Value);
			Modify_User = ClsConvert.ToString(p[28].Value);
			return ret;
		}
		public override int Update()
		{
			DbParameter[] p = new DbParameter[27];

			p[0] = Connection.GetParameter
				("@EDI300_ID", Edi300_ID);
			p[1] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.InputOutput, DbType.DateTime, 0);
			p[2] = Connection.GetParameter
				("@TRANSMISSION_KEY", Transmission_Key);
			p[3] = Connection.GetParameter
				("@B102_BKG_NO", B102_Bkg_No);
			p[4] = Connection.GetParameter
				("@LX01_ITEM_NBR", Lx01_Item_Nbr);
			p[5] = Connection.GetParameter
				("@L108_SPECIAL_CHARGE_CD", L108_Special_Charge_Cd);
			p[6] = Connection.GetParameter
				("@L102_RATE_AMT", L102_Rate_Amt);
			p[7] = Connection.GetParameter
				("@L103_RATE_TYPE_CD", L103_Rate_Type_Cd);
			p[8] = Connection.GetParameter
				("@L104_CHARGE_AMT", L104_Charge_Amt);
			p[9] = Connection.GetParameter
				("@L105_ADVANCE_AMT", L105_Advance_Amt);
			p[10] = Connection.GetParameter
				("@L106_PREPAID_AMT", L106_Prepaid_Amt);
			p[11] = Connection.GetParameter
				("@L107_COMBO_CD", L107_Combo_Cd);
			p[12] = Connection.GetParameter
				("@L109_RATE_CLASS_CD", L109_Rate_Class_Cd);
			p[13] = Connection.GetParameter
				("@L110_ENTITLEMENT_CD", L110_Entitlement_Cd);
			p[14] = Connection.GetParameter
				("@L111_PAYMENT_MTH_CD", L111_Payment_Mth_Cd);
			p[15] = Connection.GetParameter
				("@L112_SPECIAL_CHARGE_DSC", L112_Special_Charge_Dsc);
			p[16] = Connection.GetParameter
				("@L113_TARIFF_CD", L113_Tariff_Cd);
			p[17] = Connection.GetParameter
				("@L114_DECLARED_VAL_AMT", L114_Declared_Val_Amt);
			p[18] = Connection.GetParameter
				("@L115_RATE_QUAL_CD", L115_Rate_Qual_Cd);
			p[19] = Connection.GetParameter
				("@L116_LIABILITY_LIMIT_CD", L116_Liability_Limit_Cd);
			p[20] = Connection.GetParameter
				("@L117_RATE_BASIS_AMT", L117_Rate_Basis_Amt);
			p[21] = Connection.GetParameter
				("@L118_RATE_BASIS_QUAL_CD", L118_Rate_Basis_Qual_Cd);
			p[22] = Connection.GetParameter
				("@L119_PCT_AMT", L119_Pct_Amt);
			p[23] = Connection.GetParameter
				("@L120_CURRENCY_CD", L120_Currency_Cd);
			p[24] = Connection.GetParameter
				("@L121_TOT_AMT", L121_Tot_Amt);
			p[25] = Connection.GetParameter
				("@EDI300_RATE_ID", Edi300_Rate_ID);
			p[26] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);

			const string sql = @"
				UPDATE T_EDI300_RATE SET
					EDI300_ID = @EDI300_ID,
					MODIFY_DT = @MODIFY_DT,
					TRANSMISSION_KEY = @TRANSMISSION_KEY,
					B102_BKG_NO = @B102_BKG_NO,
					LX01_ITEM_NBR = @LX01_ITEM_NBR,
					L108_SPECIAL_CHARGE_CD = @L108_SPECIAL_CHARGE_CD,
					L102_RATE_AMT = @L102_RATE_AMT,
					L103_RATE_TYPE_CD = @L103_RATE_TYPE_CD,
					L104_CHARGE_AMT = @L104_CHARGE_AMT,
					L105_ADVANCE_AMT = @L105_ADVANCE_AMT,
					L106_PREPAID_AMT = @L106_PREPAID_AMT,
					L107_COMBO_CD = @L107_COMBO_CD,
					L109_RATE_CLASS_CD = @L109_RATE_CLASS_CD,
					L110_ENTITLEMENT_CD = @L110_ENTITLEMENT_CD,
					L111_PAYMENT_MTH_CD = @L111_PAYMENT_MTH_CD,
					L112_SPECIAL_CHARGE_DSC = @L112_SPECIAL_CHARGE_DSC,
					L113_TARIFF_CD = @L113_TARIFF_CD,
					L114_DECLARED_VAL_AMT = @L114_DECLARED_VAL_AMT,
					L115_RATE_QUAL_CD = @L115_RATE_QUAL_CD,
					L116_LIABILITY_LIMIT_CD = @L116_LIABILITY_LIMIT_CD,
					L117_RATE_BASIS_AMT = @L117_RATE_BASIS_AMT,
					L118_RATE_BASIS_QUAL_CD = @L118_RATE_BASIS_QUAL_CD,
					L119_PCT_AMT = @L119_PCT_AMT,
					L120_CURRENCY_CD = @L120_CURRENCY_CD,
					L121_TOT_AMT = @L121_TOT_AMT
				WHERE
					EDI300_RATE_ID = @EDI300_RATE_ID
				RETURNING
					MODIFY_DT, MODIFY_USER
				INTO
					@MODIFY_DT, @MODIFY_USER";
			int ret = Connection.RunSQL(sql, p);

			Modify_Dt = ClsConvert.ToDateTimeNullable(p[1].Value);
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

			Edi300_Rate_ID = ClsConvert.ToInt64Nullable(dr["EDI300_RATE_ID"]);
			Edi300_ID = ClsConvert.ToInt64Nullable(dr["EDI300_ID"]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT"]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER"]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT"]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER"]);
			Transmission_Key = ClsConvert.ToString(dr["TRANSMISSION_KEY"]);
			B102_Bkg_No = ClsConvert.ToString(dr["B102_BKG_NO"]);
			Lx01_Item_Nbr = ClsConvert.ToString(dr["LX01_ITEM_NBR"]);
			L108_Special_Charge_Cd = ClsConvert.ToString(dr["L108_SPECIAL_CHARGE_CD"]);
			L102_Rate_Amt = ClsConvert.ToString(dr["L102_RATE_AMT"]);
			L103_Rate_Type_Cd = ClsConvert.ToString(dr["L103_RATE_TYPE_CD"]);
			L104_Charge_Amt = ClsConvert.ToString(dr["L104_CHARGE_AMT"]);
			L105_Advance_Amt = ClsConvert.ToString(dr["L105_ADVANCE_AMT"]);
			L106_Prepaid_Amt = ClsConvert.ToString(dr["L106_PREPAID_AMT"]);
			L107_Combo_Cd = ClsConvert.ToString(dr["L107_COMBO_CD"]);
			L109_Rate_Class_Cd = ClsConvert.ToString(dr["L109_RATE_CLASS_CD"]);
			L110_Entitlement_Cd = ClsConvert.ToString(dr["L110_ENTITLEMENT_CD"]);
			L111_Payment_Mth_Cd = ClsConvert.ToString(dr["L111_PAYMENT_MTH_CD"]);
			L112_Special_Charge_Dsc = ClsConvert.ToString(dr["L112_SPECIAL_CHARGE_DSC"]);
			L113_Tariff_Cd = ClsConvert.ToString(dr["L113_TARIFF_CD"]);
			L114_Declared_Val_Amt = ClsConvert.ToString(dr["L114_DECLARED_VAL_AMT"]);
			L115_Rate_Qual_Cd = ClsConvert.ToString(dr["L115_RATE_QUAL_CD"]);
			L116_Liability_Limit_Cd = ClsConvert.ToString(dr["L116_LIABILITY_LIMIT_CD"]);
			L117_Rate_Basis_Amt = ClsConvert.ToString(dr["L117_RATE_BASIS_AMT"]);
			L118_Rate_Basis_Qual_Cd = ClsConvert.ToString(dr["L118_RATE_BASIS_QUAL_CD"]);
			L119_Pct_Amt = ClsConvert.ToString(dr["L119_PCT_AMT"]);
			L120_Currency_Cd = ClsConvert.ToString(dr["L120_CURRENCY_CD"]);
			L121_Tot_Amt = ClsConvert.ToString(dr["L121_TOT_AMT"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Edi300_Rate_ID = ClsConvert.ToInt64Nullable(dr["EDI300_RATE_ID", v]);
			Edi300_ID = ClsConvert.ToInt64Nullable(dr["EDI300_ID", v]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT", v]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER", v]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT", v]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER", v]);
			Transmission_Key = ClsConvert.ToString(dr["TRANSMISSION_KEY", v]);
			B102_Bkg_No = ClsConvert.ToString(dr["B102_BKG_NO", v]);
			Lx01_Item_Nbr = ClsConvert.ToString(dr["LX01_ITEM_NBR", v]);
			L108_Special_Charge_Cd = ClsConvert.ToString(dr["L108_SPECIAL_CHARGE_CD", v]);
			L102_Rate_Amt = ClsConvert.ToString(dr["L102_RATE_AMT", v]);
			L103_Rate_Type_Cd = ClsConvert.ToString(dr["L103_RATE_TYPE_CD", v]);
			L104_Charge_Amt = ClsConvert.ToString(dr["L104_CHARGE_AMT", v]);
			L105_Advance_Amt = ClsConvert.ToString(dr["L105_ADVANCE_AMT", v]);
			L106_Prepaid_Amt = ClsConvert.ToString(dr["L106_PREPAID_AMT", v]);
			L107_Combo_Cd = ClsConvert.ToString(dr["L107_COMBO_CD", v]);
			L109_Rate_Class_Cd = ClsConvert.ToString(dr["L109_RATE_CLASS_CD", v]);
			L110_Entitlement_Cd = ClsConvert.ToString(dr["L110_ENTITLEMENT_CD", v]);
			L111_Payment_Mth_Cd = ClsConvert.ToString(dr["L111_PAYMENT_MTH_CD", v]);
			L112_Special_Charge_Dsc = ClsConvert.ToString(dr["L112_SPECIAL_CHARGE_DSC", v]);
			L113_Tariff_Cd = ClsConvert.ToString(dr["L113_TARIFF_CD", v]);
			L114_Declared_Val_Amt = ClsConvert.ToString(dr["L114_DECLARED_VAL_AMT", v]);
			L115_Rate_Qual_Cd = ClsConvert.ToString(dr["L115_RATE_QUAL_CD", v]);
			L116_Liability_Limit_Cd = ClsConvert.ToString(dr["L116_LIABILITY_LIMIT_CD", v]);
			L117_Rate_Basis_Amt = ClsConvert.ToString(dr["L117_RATE_BASIS_AMT", v]);
			L118_Rate_Basis_Qual_Cd = ClsConvert.ToString(dr["L118_RATE_BASIS_QUAL_CD", v]);
			L119_Pct_Amt = ClsConvert.ToString(dr["L119_PCT_AMT", v]);
			L120_Currency_Cd = ClsConvert.ToString(dr["L120_CURRENCY_CD", v]);
			L121_Tot_Amt = ClsConvert.ToString(dr["L121_TOT_AMT", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["EDI300_RATE_ID"] = ClsConvert.ToDbObject(Edi300_Rate_ID);
			dr["EDI300_ID"] = ClsConvert.ToDbObject(Edi300_ID);
			dr["CREATE_DT"] = ClsConvert.ToDbObject(Create_Dt);
			dr["CREATE_USER"] = ClsConvert.ToDbObject(Create_User);
			dr["MODIFY_DT"] = ClsConvert.ToDbObject(Modify_Dt);
			dr["MODIFY_USER"] = ClsConvert.ToDbObject(Modify_User);
			dr["TRANSMISSION_KEY"] = ClsConvert.ToDbObject(Transmission_Key);
			dr["B102_BKG_NO"] = ClsConvert.ToDbObject(B102_Bkg_No);
			dr["LX01_ITEM_NBR"] = ClsConvert.ToDbObject(Lx01_Item_Nbr);
			dr["L108_SPECIAL_CHARGE_CD"] = ClsConvert.ToDbObject(L108_Special_Charge_Cd);
			dr["L102_RATE_AMT"] = ClsConvert.ToDbObject(L102_Rate_Amt);
			dr["L103_RATE_TYPE_CD"] = ClsConvert.ToDbObject(L103_Rate_Type_Cd);
			dr["L104_CHARGE_AMT"] = ClsConvert.ToDbObject(L104_Charge_Amt);
			dr["L105_ADVANCE_AMT"] = ClsConvert.ToDbObject(L105_Advance_Amt);
			dr["L106_PREPAID_AMT"] = ClsConvert.ToDbObject(L106_Prepaid_Amt);
			dr["L107_COMBO_CD"] = ClsConvert.ToDbObject(L107_Combo_Cd);
			dr["L109_RATE_CLASS_CD"] = ClsConvert.ToDbObject(L109_Rate_Class_Cd);
			dr["L110_ENTITLEMENT_CD"] = ClsConvert.ToDbObject(L110_Entitlement_Cd);
			dr["L111_PAYMENT_MTH_CD"] = ClsConvert.ToDbObject(L111_Payment_Mth_Cd);
			dr["L112_SPECIAL_CHARGE_DSC"] = ClsConvert.ToDbObject(L112_Special_Charge_Dsc);
			dr["L113_TARIFF_CD"] = ClsConvert.ToDbObject(L113_Tariff_Cd);
			dr["L114_DECLARED_VAL_AMT"] = ClsConvert.ToDbObject(L114_Declared_Val_Amt);
			dr["L115_RATE_QUAL_CD"] = ClsConvert.ToDbObject(L115_Rate_Qual_Cd);
			dr["L116_LIABILITY_LIMIT_CD"] = ClsConvert.ToDbObject(L116_Liability_Limit_Cd);
			dr["L117_RATE_BASIS_AMT"] = ClsConvert.ToDbObject(L117_Rate_Basis_Amt);
			dr["L118_RATE_BASIS_QUAL_CD"] = ClsConvert.ToDbObject(L118_Rate_Basis_Qual_Cd);
			dr["L119_PCT_AMT"] = ClsConvert.ToDbObject(L119_Pct_Amt);
			dr["L120_CURRENCY_CD"] = ClsConvert.ToDbObject(L120_Currency_Cd);
			dr["L121_TOT_AMT"] = ClsConvert.ToDbObject(L121_Tot_Amt);
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

		public static ClsEdi300Rate GetUsingKey(Int64 Edi300_Rate_ID)
		{
			object[] vals = new object[] {Edi300_Rate_ID};
			DataRow dr = Connection.GetDataRowUsingKey
				(TableName, GetPrimaryKeys(), vals);
			return ( dr == null ) ? null : new ClsEdi300Rate(dr);
		}
		public static DataTable GetAll(Int64? Edi300_ID)
		{
			List<DbParameter> lst = new List<DbParameter>();	
			StringBuilder sb = new StringBuilder();
		
			if( Edi300_ID != null && Edi300_ID > 0 )
			{
				lst.Add(Connection.GetParameter("@EDI300_ID", Edi300_ID));
				sb.Append(" WHERE T_EDI300_RATE.EDI300_ID=@EDI300_ID");
			}
			sb.Insert(0, SelectSQL);
			return Connection.GetDataTable(sb.ToString(), lst.ToArray());
		}
		#endregion		// #region Static Methods
	}
}