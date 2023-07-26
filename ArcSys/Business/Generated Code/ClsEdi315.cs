using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsEdi315 : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ArcSys"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "T_EDI315";
		public const int PrimaryKeyCount = 1;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] { "EDI315_ID" };
		}

		public const string SelectSQL = @"SELECT * FROM T_EDI315 
				INNER JOIN T_ISA
				ON T_EDI315.ISA_ID=T_ISA.ISA_ID
				INNER JOIN T_ITV
				ON T_EDI315.ITV_ID=T_ITV.ITV_ID ";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Create_UserMax = 30;
		public const int Modify_UserMax = 30;
		public const int Cargo_KeyMax = 30;
		public const int Serial_NoMax = 50;
		public const int Activity_CdMax = 10;
		public const int Booking_NoMax = 30;
		public const int Bol_NoMax = 30;
		public const int Location_CdMax = 10;
		public const int Voyage_NoMax = 10;
		public const int Vessel_CdMax = 10;
		public const int Plor_Location_CdMax = 10;
		public const int Pol_Location_CdMax = 10;
		public const int Pod_Location_CdMax = 10;
		public const int Plod_Location_CdMax = 10;
		public const int Actual_Departure_FlgMax = 1;
		public const int Actual_Arrival_FlgMax = 1;
		public const int Plor_QualifierMax = 2;
		public const int Plor_Static_IDMax = 30;
		public const int Plor_NameMax = 30;
		public const int Plor_TerminalMax = 30;
		public const int Plor_Date_QualifierMax = 3;
		public const int Plor_DateMax = 10;
		public const int Plor_TimeMax = 10;
		public const int Pol_QualifierMax = 2;
		public const int Pol_Static_IDMax = 10;
		public const int Pol_NameMax = 30;
		public const int Pol_TerminalMax = 30;
		public const int Pol_Date_QualifierMax = 3;
		public const int Pol_DateMax = 10;
		public const int Pol_TimeMax = 10;
		public const int Pod_QualifierMax = 3;
		public const int Pod_Static_IDMax = 10;
		public const int Pod_NameMax = 30;
		public const int Pod_TerminalMax = 30;
		public const int Pod_Date_QualifierMax = 3;
		public const int Pod_DateMax = 10;
		public const int Pod_TimeMax = 10;
		public const int Plod_QualifierMax = 2;
		public const int Plod_Static_IDMax = 10;
		public const int Plod_NameMax = 30;
		public const int Plod_TerminalMax = 30;
		public const int Plod_Date_QualifierMax = 3;
		public const int Plod_DateMax = 10;
		public const int Plod_TimeMax = 10;
		public const int PcfnMax = 10;
		public const int Booking_SubMax = 10;
		public const int Military_Voyage_NoMax = 10;
		public const int Weight_Unit_CdMax = 10;
		public const int Volume_QualifierMax = 2;
		public const int Vessel_QualifierMax = 2;
		public const int Activity_Static_LocationMax = 30;
		public const int Activity_Location_QualifierMax = 2;
		public const int Vessel_NmMax = 30;
		public const int MsgMax = 250;
		public const int Processed_FlgMax = 1;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected Int64? _Edi315_ID;
		protected Int64? _Isa_ID;
		protected Int64? _Itv_ID;
		protected DateTime? _Create_Dt;
		protected string _Create_User;
		protected DateTime? _Modify_Dt;
		protected string _Modify_User;
		protected Int64? _Isa_Nbr;
		protected string _Cargo_Key;
		protected Int64? _Cargo_Line_ID;
		protected string _Serial_No;
		protected DateTime? _Activity_Dt;
		protected string _Activity_Cd;
		protected string _Booking_No;
		protected string _Bol_No;
		protected string _Location_Cd;
		protected string _Voyage_No;
		protected string _Vessel_Cd;
		protected DateTime? _Departure_Dt;
		protected DateTime? _Arrival_Dt;
		protected string _Plor_Location_Cd;
		protected string _Pol_Location_Cd;
		protected string _Pod_Location_Cd;
		protected string _Plod_Location_Cd;
		protected string _Actual_Departure_Flg;
		protected string _Actual_Arrival_Flg;
		protected string _Plor_Qualifier;
		protected string _Plor_Static_ID;
		protected string _Plor_Name;
		protected string _Plor_Terminal;
		protected string _Plor_Date_Qualifier;
		protected string _Plor_Date;
		protected string _Plor_Time;
		protected string _Pol_Qualifier;
		protected string _Pol_Static_ID;
		protected string _Pol_Name;
		protected string _Pol_Terminal;
		protected string _Pol_Date_Qualifier;
		protected string _Pol_Date;
		protected string _Pol_Time;
		protected string _Pod_Qualifier;
		protected string _Pod_Static_ID;
		protected string _Pod_Name;
		protected string _Pod_Terminal;
		protected string _Pod_Date_Qualifier;
		protected string _Pod_Date;
		protected string _Pod_Time;
		protected string _Plod_Qualifier;
		protected string _Plod_Static_ID;
		protected string _Plod_Name;
		protected string _Plod_Terminal;
		protected string _Plod_Date_Qualifier;
		protected string _Plod_Date;
		protected string _Plod_Time;
		protected string _Pcfn;
		protected string _Booking_Sub;
		protected string _Military_Voyage_No;
		protected Int64? _Lading_Qty_No;
		protected string _Weight_Unit_Cd;
		protected Int64? _Weight_Nbr;
		protected string _Volume_Qualifier;
		protected Int64? _Volume_Nbr;
		protected string _Vessel_Qualifier;
		protected string _Activity_Static_Location;
		protected string _Activity_Location_Qualifier;
		protected string _Vessel_Nm;
		protected string _Msg;
		protected string _Processed_Flg;
		protected Int64? _Acms_Activity_ID;

		#endregion	// #region Column Fields

		#region Column Properties

		public Int64? Edi315_ID
		{
			get { return _Edi315_ID; }
			set
			{
				if( _Edi315_ID == value ) return;
		
				_Edi315_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Edi315_ID");
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
		public Int64? Itv_ID
		{
			get { return _Itv_ID; }
			set
			{
				if( _Itv_ID == value ) return;
		
				_Itv_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Itv_ID");
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
		public string Cargo_Key
		{
			get { return _Cargo_Key; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Cargo_Key, val, false) == 0 ) return;
		
				if( val != null && val.Length > Cargo_KeyMax )
					_Cargo_Key = val.Substring(0, (int)Cargo_KeyMax);
				else
					_Cargo_Key = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Cargo_Key");
			}
		}
		public Int64? Cargo_Line_ID
		{
			get { return _Cargo_Line_ID; }
			set
			{
				if( _Cargo_Line_ID == value ) return;
		
				_Cargo_Line_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Cargo_Line_ID");
			}
		}
		public string Serial_No
		{
			get { return _Serial_No; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Serial_No, val, false) == 0 ) return;
		
				if( val != null && val.Length > Serial_NoMax )
					_Serial_No = val.Substring(0, (int)Serial_NoMax);
				else
					_Serial_No = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Serial_No");
			}
		}
		public DateTime? Activity_Dt
		{
			get { return _Activity_Dt; }
			set
			{
				if( _Activity_Dt == value ) return;
		
				_Activity_Dt = value;
				_IsDirty = true;
				NotifyPropertyChanged("Activity_Dt");
			}
		}
		public string Activity_Cd
		{
			get { return _Activity_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Activity_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Activity_CdMax )
					_Activity_Cd = val.Substring(0, (int)Activity_CdMax);
				else
					_Activity_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Activity_Cd");
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
		public string Location_Cd
		{
			get { return _Location_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Location_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Location_CdMax )
					_Location_Cd = val.Substring(0, (int)Location_CdMax);
				else
					_Location_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Location_Cd");
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
		public DateTime? Departure_Dt
		{
			get { return _Departure_Dt; }
			set
			{
				if( _Departure_Dt == value ) return;
		
				_Departure_Dt = value;
				_IsDirty = true;
				NotifyPropertyChanged("Departure_Dt");
			}
		}
		public DateTime? Arrival_Dt
		{
			get { return _Arrival_Dt; }
			set
			{
				if( _Arrival_Dt == value ) return;
		
				_Arrival_Dt = value;
				_IsDirty = true;
				NotifyPropertyChanged("Arrival_Dt");
			}
		}
		public string Plor_Location_Cd
		{
			get { return _Plor_Location_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Plor_Location_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Plor_Location_CdMax )
					_Plor_Location_Cd = val.Substring(0, (int)Plor_Location_CdMax);
				else
					_Plor_Location_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Plor_Location_Cd");
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
		public string Plod_Location_Cd
		{
			get { return _Plod_Location_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Plod_Location_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Plod_Location_CdMax )
					_Plod_Location_Cd = val.Substring(0, (int)Plod_Location_CdMax);
				else
					_Plod_Location_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Plod_Location_Cd");
			}
		}
		public string Actual_Departure_Flg
		{
			get { return _Actual_Departure_Flg; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Actual_Departure_Flg, val, false) == 0 ) return;
		
				if( val != null && val.Length > Actual_Departure_FlgMax )
					_Actual_Departure_Flg = val.Substring(0, (int)Actual_Departure_FlgMax);
				else
					_Actual_Departure_Flg = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Actual_Departure_Flg");
			}
		}
		public string Actual_Arrival_Flg
		{
			get { return _Actual_Arrival_Flg; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Actual_Arrival_Flg, val, false) == 0 ) return;
		
				if( val != null && val.Length > Actual_Arrival_FlgMax )
					_Actual_Arrival_Flg = val.Substring(0, (int)Actual_Arrival_FlgMax);
				else
					_Actual_Arrival_Flg = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Actual_Arrival_Flg");
			}
		}
		public string Plor_Qualifier
		{
			get { return _Plor_Qualifier; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Plor_Qualifier, val, false) == 0 ) return;
		
				if( val != null && val.Length > Plor_QualifierMax )
					_Plor_Qualifier = val.Substring(0, (int)Plor_QualifierMax);
				else
					_Plor_Qualifier = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Plor_Qualifier");
			}
		}
		public string Plor_Static_ID
		{
			get { return _Plor_Static_ID; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Plor_Static_ID, val, false) == 0 ) return;
		
				if( val != null && val.Length > Plor_Static_IDMax )
					_Plor_Static_ID = val.Substring(0, (int)Plor_Static_IDMax);
				else
					_Plor_Static_ID = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Plor_Static_ID");
			}
		}
		public string Plor_Name
		{
			get { return _Plor_Name; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Plor_Name, val, false) == 0 ) return;
		
				if( val != null && val.Length > Plor_NameMax )
					_Plor_Name = val.Substring(0, (int)Plor_NameMax);
				else
					_Plor_Name = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Plor_Name");
			}
		}
		public string Plor_Terminal
		{
			get { return _Plor_Terminal; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Plor_Terminal, val, false) == 0 ) return;
		
				if( val != null && val.Length > Plor_TerminalMax )
					_Plor_Terminal = val.Substring(0, (int)Plor_TerminalMax);
				else
					_Plor_Terminal = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Plor_Terminal");
			}
		}
		public string Plor_Date_Qualifier
		{
			get { return _Plor_Date_Qualifier; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Plor_Date_Qualifier, val, false) == 0 ) return;
		
				if( val != null && val.Length > Plor_Date_QualifierMax )
					_Plor_Date_Qualifier = val.Substring(0, (int)Plor_Date_QualifierMax);
				else
					_Plor_Date_Qualifier = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Plor_Date_Qualifier");
			}
		}
		public string Plor_Date
		{
			get { return _Plor_Date; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Plor_Date, val, false) == 0 ) return;
		
				if( val != null && val.Length > Plor_DateMax )
					_Plor_Date = val.Substring(0, (int)Plor_DateMax);
				else
					_Plor_Date = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Plor_Date");
			}
		}
		public string Plor_Time
		{
			get { return _Plor_Time; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Plor_Time, val, false) == 0 ) return;
		
				if( val != null && val.Length > Plor_TimeMax )
					_Plor_Time = val.Substring(0, (int)Plor_TimeMax);
				else
					_Plor_Time = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Plor_Time");
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
		public string Pol_Static_ID
		{
			get { return _Pol_Static_ID; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Pol_Static_ID, val, false) == 0 ) return;
		
				if( val != null && val.Length > Pol_Static_IDMax )
					_Pol_Static_ID = val.Substring(0, (int)Pol_Static_IDMax);
				else
					_Pol_Static_ID = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Pol_Static_ID");
			}
		}
		public string Pol_Name
		{
			get { return _Pol_Name; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Pol_Name, val, false) == 0 ) return;
		
				if( val != null && val.Length > Pol_NameMax )
					_Pol_Name = val.Substring(0, (int)Pol_NameMax);
				else
					_Pol_Name = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Pol_Name");
			}
		}
		public string Pol_Terminal
		{
			get { return _Pol_Terminal; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Pol_Terminal, val, false) == 0 ) return;
		
				if( val != null && val.Length > Pol_TerminalMax )
					_Pol_Terminal = val.Substring(0, (int)Pol_TerminalMax);
				else
					_Pol_Terminal = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Pol_Terminal");
			}
		}
		public string Pol_Date_Qualifier
		{
			get { return _Pol_Date_Qualifier; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Pol_Date_Qualifier, val, false) == 0 ) return;
		
				if( val != null && val.Length > Pol_Date_QualifierMax )
					_Pol_Date_Qualifier = val.Substring(0, (int)Pol_Date_QualifierMax);
				else
					_Pol_Date_Qualifier = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Pol_Date_Qualifier");
			}
		}
		public string Pol_Date
		{
			get { return _Pol_Date; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Pol_Date, val, false) == 0 ) return;
		
				if( val != null && val.Length > Pol_DateMax )
					_Pol_Date = val.Substring(0, (int)Pol_DateMax);
				else
					_Pol_Date = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Pol_Date");
			}
		}
		public string Pol_Time
		{
			get { return _Pol_Time; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Pol_Time, val, false) == 0 ) return;
		
				if( val != null && val.Length > Pol_TimeMax )
					_Pol_Time = val.Substring(0, (int)Pol_TimeMax);
				else
					_Pol_Time = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Pol_Time");
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
		public string Pod_Static_ID
		{
			get { return _Pod_Static_ID; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Pod_Static_ID, val, false) == 0 ) return;
		
				if( val != null && val.Length > Pod_Static_IDMax )
					_Pod_Static_ID = val.Substring(0, (int)Pod_Static_IDMax);
				else
					_Pod_Static_ID = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Pod_Static_ID");
			}
		}
		public string Pod_Name
		{
			get { return _Pod_Name; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Pod_Name, val, false) == 0 ) return;
		
				if( val != null && val.Length > Pod_NameMax )
					_Pod_Name = val.Substring(0, (int)Pod_NameMax);
				else
					_Pod_Name = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Pod_Name");
			}
		}
		public string Pod_Terminal
		{
			get { return _Pod_Terminal; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Pod_Terminal, val, false) == 0 ) return;
		
				if( val != null && val.Length > Pod_TerminalMax )
					_Pod_Terminal = val.Substring(0, (int)Pod_TerminalMax);
				else
					_Pod_Terminal = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Pod_Terminal");
			}
		}
		public string Pod_Date_Qualifier
		{
			get { return _Pod_Date_Qualifier; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Pod_Date_Qualifier, val, false) == 0 ) return;
		
				if( val != null && val.Length > Pod_Date_QualifierMax )
					_Pod_Date_Qualifier = val.Substring(0, (int)Pod_Date_QualifierMax);
				else
					_Pod_Date_Qualifier = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Pod_Date_Qualifier");
			}
		}
		public string Pod_Date
		{
			get { return _Pod_Date; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Pod_Date, val, false) == 0 ) return;
		
				if( val != null && val.Length > Pod_DateMax )
					_Pod_Date = val.Substring(0, (int)Pod_DateMax);
				else
					_Pod_Date = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Pod_Date");
			}
		}
		public string Pod_Time
		{
			get { return _Pod_Time; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Pod_Time, val, false) == 0 ) return;
		
				if( val != null && val.Length > Pod_TimeMax )
					_Pod_Time = val.Substring(0, (int)Pod_TimeMax);
				else
					_Pod_Time = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Pod_Time");
			}
		}
		public string Plod_Qualifier
		{
			get { return _Plod_Qualifier; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Plod_Qualifier, val, false) == 0 ) return;
		
				if( val != null && val.Length > Plod_QualifierMax )
					_Plod_Qualifier = val.Substring(0, (int)Plod_QualifierMax);
				else
					_Plod_Qualifier = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Plod_Qualifier");
			}
		}
		public string Plod_Static_ID
		{
			get { return _Plod_Static_ID; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Plod_Static_ID, val, false) == 0 ) return;
		
				if( val != null && val.Length > Plod_Static_IDMax )
					_Plod_Static_ID = val.Substring(0, (int)Plod_Static_IDMax);
				else
					_Plod_Static_ID = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Plod_Static_ID");
			}
		}
		public string Plod_Name
		{
			get { return _Plod_Name; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Plod_Name, val, false) == 0 ) return;
		
				if( val != null && val.Length > Plod_NameMax )
					_Plod_Name = val.Substring(0, (int)Plod_NameMax);
				else
					_Plod_Name = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Plod_Name");
			}
		}
		public string Plod_Terminal
		{
			get { return _Plod_Terminal; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Plod_Terminal, val, false) == 0 ) return;
		
				if( val != null && val.Length > Plod_TerminalMax )
					_Plod_Terminal = val.Substring(0, (int)Plod_TerminalMax);
				else
					_Plod_Terminal = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Plod_Terminal");
			}
		}
		public string Plod_Date_Qualifier
		{
			get { return _Plod_Date_Qualifier; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Plod_Date_Qualifier, val, false) == 0 ) return;
		
				if( val != null && val.Length > Plod_Date_QualifierMax )
					_Plod_Date_Qualifier = val.Substring(0, (int)Plod_Date_QualifierMax);
				else
					_Plod_Date_Qualifier = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Plod_Date_Qualifier");
			}
		}
		public string Plod_Date
		{
			get { return _Plod_Date; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Plod_Date, val, false) == 0 ) return;
		
				if( val != null && val.Length > Plod_DateMax )
					_Plod_Date = val.Substring(0, (int)Plod_DateMax);
				else
					_Plod_Date = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Plod_Date");
			}
		}
		public string Plod_Time
		{
			get { return _Plod_Time; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Plod_Time, val, false) == 0 ) return;
		
				if( val != null && val.Length > Plod_TimeMax )
					_Plod_Time = val.Substring(0, (int)Plod_TimeMax);
				else
					_Plod_Time = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Plod_Time");
			}
		}
		public string Pcfn
		{
			get { return _Pcfn; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Pcfn, val, false) == 0 ) return;
		
				if( val != null && val.Length > PcfnMax )
					_Pcfn = val.Substring(0, (int)PcfnMax);
				else
					_Pcfn = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Pcfn");
			}
		}
		public string Booking_Sub
		{
			get { return _Booking_Sub; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Booking_Sub, val, false) == 0 ) return;
		
				if( val != null && val.Length > Booking_SubMax )
					_Booking_Sub = val.Substring(0, (int)Booking_SubMax);
				else
					_Booking_Sub = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Booking_Sub");
			}
		}
		public string Military_Voyage_No
		{
			get { return _Military_Voyage_No; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Military_Voyage_No, val, false) == 0 ) return;
		
				if( val != null && val.Length > Military_Voyage_NoMax )
					_Military_Voyage_No = val.Substring(0, (int)Military_Voyage_NoMax);
				else
					_Military_Voyage_No = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Military_Voyage_No");
			}
		}
		public Int64? Lading_Qty_No
		{
			get { return _Lading_Qty_No; }
			set
			{
				if( _Lading_Qty_No == value ) return;
		
				_Lading_Qty_No = value;
				_IsDirty = true;
				NotifyPropertyChanged("Lading_Qty_No");
			}
		}
		public string Weight_Unit_Cd
		{
			get { return _Weight_Unit_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Weight_Unit_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Weight_Unit_CdMax )
					_Weight_Unit_Cd = val.Substring(0, (int)Weight_Unit_CdMax);
				else
					_Weight_Unit_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Weight_Unit_Cd");
			}
		}
		public Int64? Weight_Nbr
		{
			get { return _Weight_Nbr; }
			set
			{
				if( _Weight_Nbr == value ) return;
		
				_Weight_Nbr = value;
				_IsDirty = true;
				NotifyPropertyChanged("Weight_Nbr");
			}
		}
		public string Volume_Qualifier
		{
			get { return _Volume_Qualifier; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Volume_Qualifier, val, false) == 0 ) return;
		
				if( val != null && val.Length > Volume_QualifierMax )
					_Volume_Qualifier = val.Substring(0, (int)Volume_QualifierMax);
				else
					_Volume_Qualifier = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Volume_Qualifier");
			}
		}
		public Int64? Volume_Nbr
		{
			get { return _Volume_Nbr; }
			set
			{
				if( _Volume_Nbr == value ) return;
		
				_Volume_Nbr = value;
				_IsDirty = true;
				NotifyPropertyChanged("Volume_Nbr");
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
		public string Activity_Static_Location
		{
			get { return _Activity_Static_Location; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Activity_Static_Location, val, false) == 0 ) return;
		
				if( val != null && val.Length > Activity_Static_LocationMax )
					_Activity_Static_Location = val.Substring(0, (int)Activity_Static_LocationMax);
				else
					_Activity_Static_Location = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Activity_Static_Location");
			}
		}
		public string Activity_Location_Qualifier
		{
			get { return _Activity_Location_Qualifier; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Activity_Location_Qualifier, val, false) == 0 ) return;
		
				if( val != null && val.Length > Activity_Location_QualifierMax )
					_Activity_Location_Qualifier = val.Substring(0, (int)Activity_Location_QualifierMax);
				else
					_Activity_Location_Qualifier = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Activity_Location_Qualifier");
			}
		}
		public string Vessel_Nm
		{
			get { return _Vessel_Nm; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Vessel_Nm, val, false) == 0 ) return;
		
				if( val != null && val.Length > Vessel_NmMax )
					_Vessel_Nm = val.Substring(0, (int)Vessel_NmMax);
				else
					_Vessel_Nm = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Vessel_Nm");
			}
		}
		public string Msg
		{
			get { return _Msg; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Msg, val, false) == 0 ) return;
		
				if( val != null && val.Length > MsgMax )
					_Msg = val.Substring(0, (int)MsgMax);
				else
					_Msg = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Msg");
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
		public Int64? Acms_Activity_ID
		{
			get { return _Acms_Activity_ID; }
			set
			{
				if( _Acms_Activity_ID == value ) return;
		
				_Acms_Activity_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Acms_Activity_ID");
			}
		}

		#endregion	// #region Column Properties

		#region Foreign Key Fields



		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties



		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsEdi315() : base() {}
		public ClsEdi315(DataRow dr) : base(dr) {}
		public ClsEdi315(ClsEdi315 src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Edi315_ID = null;
			Isa_ID = null;
			Itv_ID = null;
			Create_Dt = null;
			Create_User = null;
			Modify_Dt = null;
			Modify_User = null;
			Isa_Nbr = null;
			Cargo_Key = null;
			Cargo_Line_ID = null;
			Serial_No = null;
			Activity_Dt = null;
			Activity_Cd = null;
			Booking_No = null;
			Bol_No = null;
			Location_Cd = null;
			Voyage_No = null;
			Vessel_Cd = null;
			Departure_Dt = null;
			Arrival_Dt = null;
			Plor_Location_Cd = null;
			Pol_Location_Cd = null;
			Pod_Location_Cd = null;
			Plod_Location_Cd = null;
			Actual_Departure_Flg = null;
			Actual_Arrival_Flg = null;
			Plor_Qualifier = null;
			Plor_Static_ID = null;
			Plor_Name = null;
			Plor_Terminal = null;
			Plor_Date_Qualifier = null;
			Plor_Date = null;
			Plor_Time = null;
			Pol_Qualifier = null;
			Pol_Static_ID = null;
			Pol_Name = null;
			Pol_Terminal = null;
			Pol_Date_Qualifier = null;
			Pol_Date = null;
			Pol_Time = null;
			Pod_Qualifier = null;
			Pod_Static_ID = null;
			Pod_Name = null;
			Pod_Terminal = null;
			Pod_Date_Qualifier = null;
			Pod_Date = null;
			Pod_Time = null;
			Plod_Qualifier = null;
			Plod_Static_ID = null;
			Plod_Name = null;
			Plod_Terminal = null;
			Plod_Date_Qualifier = null;
			Plod_Date = null;
			Plod_Time = null;
			Pcfn = null;
			Booking_Sub = null;
			Military_Voyage_No = null;
			Lading_Qty_No = null;
			Weight_Unit_Cd = null;
			Weight_Nbr = null;
			Volume_Qualifier = null;
			Volume_Nbr = null;
			Vessel_Qualifier = null;
			Activity_Static_Location = null;
			Activity_Location_Qualifier = null;
			Vessel_Nm = null;
			Msg = null;
			Processed_Flg = null;
			Acms_Activity_ID = null;
		}

		public void CopyFrom(ClsEdi315 src)
		{
			Edi315_ID = src._Edi315_ID;
			Isa_ID = src._Isa_ID;
			Itv_ID = src._Itv_ID;
			Create_Dt = src._Create_Dt;
			Create_User = src._Create_User;
			Modify_Dt = src._Modify_Dt;
			Modify_User = src._Modify_User;
			Isa_Nbr = src._Isa_Nbr;
			Cargo_Key = src._Cargo_Key;
			Cargo_Line_ID = src._Cargo_Line_ID;
			Serial_No = src._Serial_No;
			Activity_Dt = src._Activity_Dt;
			Activity_Cd = src._Activity_Cd;
			Booking_No = src._Booking_No;
			Bol_No = src._Bol_No;
			Location_Cd = src._Location_Cd;
			Voyage_No = src._Voyage_No;
			Vessel_Cd = src._Vessel_Cd;
			Departure_Dt = src._Departure_Dt;
			Arrival_Dt = src._Arrival_Dt;
			Plor_Location_Cd = src._Plor_Location_Cd;
			Pol_Location_Cd = src._Pol_Location_Cd;
			Pod_Location_Cd = src._Pod_Location_Cd;
			Plod_Location_Cd = src._Plod_Location_Cd;
			Actual_Departure_Flg = src._Actual_Departure_Flg;
			Actual_Arrival_Flg = src._Actual_Arrival_Flg;
			Plor_Qualifier = src._Plor_Qualifier;
			Plor_Static_ID = src._Plor_Static_ID;
			Plor_Name = src._Plor_Name;
			Plor_Terminal = src._Plor_Terminal;
			Plor_Date_Qualifier = src._Plor_Date_Qualifier;
			Plor_Date = src._Plor_Date;
			Plor_Time = src._Plor_Time;
			Pol_Qualifier = src._Pol_Qualifier;
			Pol_Static_ID = src._Pol_Static_ID;
			Pol_Name = src._Pol_Name;
			Pol_Terminal = src._Pol_Terminal;
			Pol_Date_Qualifier = src._Pol_Date_Qualifier;
			Pol_Date = src._Pol_Date;
			Pol_Time = src._Pol_Time;
			Pod_Qualifier = src._Pod_Qualifier;
			Pod_Static_ID = src._Pod_Static_ID;
			Pod_Name = src._Pod_Name;
			Pod_Terminal = src._Pod_Terminal;
			Pod_Date_Qualifier = src._Pod_Date_Qualifier;
			Pod_Date = src._Pod_Date;
			Pod_Time = src._Pod_Time;
			Plod_Qualifier = src._Plod_Qualifier;
			Plod_Static_ID = src._Plod_Static_ID;
			Plod_Name = src._Plod_Name;
			Plod_Terminal = src._Plod_Terminal;
			Plod_Date_Qualifier = src._Plod_Date_Qualifier;
			Plod_Date = src._Plod_Date;
			Plod_Time = src._Plod_Time;
			Pcfn = src._Pcfn;
			Booking_Sub = src._Booking_Sub;
			Military_Voyage_No = src._Military_Voyage_No;
			Lading_Qty_No = src._Lading_Qty_No;
			Weight_Unit_Cd = src._Weight_Unit_Cd;
			Weight_Nbr = src._Weight_Nbr;
			Volume_Qualifier = src._Volume_Qualifier;
			Volume_Nbr = src._Volume_Nbr;
			Vessel_Qualifier = src._Vessel_Qualifier;
			Activity_Static_Location = src._Activity_Static_Location;
			Activity_Location_Qualifier = src._Activity_Location_Qualifier;
			Vessel_Nm = src._Vessel_Nm;
			Msg = src._Msg;
			Processed_Flg = src._Processed_Flg;
			Acms_Activity_ID = src._Acms_Activity_ID;
		}

		public override bool ReloadFromDB()
		{
			ClsEdi315 tmp = ClsEdi315.GetUsingKey(Edi315_ID.Value);
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

			DbParameter[] p = new DbParameter[69];

			p[0] = Connection.GetParameter
				("@ISA_ID", Isa_ID);
			p[1] = Connection.GetParameter
				("@ITV_ID", Itv_ID);
			p[2] = Connection.GetParameter
				("@ISA_NBR", Isa_Nbr);
			p[3] = Connection.GetParameter
				("@CARGO_KEY", Cargo_Key);
			p[4] = Connection.GetParameter
				("@CARGO_LINE_ID", Cargo_Line_ID);
			p[5] = Connection.GetParameter
				("@SERIAL_NO", Serial_No);
			p[6] = Connection.GetParameter
				("@ACTIVITY_DT", Activity_Dt);
			p[7] = Connection.GetParameter
				("@ACTIVITY_CD", Activity_Cd);
			p[8] = Connection.GetParameter
				("@BOOKING_NO", Booking_No);
			p[9] = Connection.GetParameter
				("@BOL_NO", Bol_No);
			p[10] = Connection.GetParameter
				("@LOCATION_CD", Location_Cd);
			p[11] = Connection.GetParameter
				("@VOYAGE_NO", Voyage_No);
			p[12] = Connection.GetParameter
				("@VESSEL_CD", Vessel_Cd);
			p[13] = Connection.GetParameter
				("@DEPARTURE_DT", Departure_Dt);
			p[14] = Connection.GetParameter
				("@ARRIVAL_DT", Arrival_Dt);
			p[15] = Connection.GetParameter
				("@PLOR_LOCATION_CD", Plor_Location_Cd);
			p[16] = Connection.GetParameter
				("@POL_LOCATION_CD", Pol_Location_Cd);
			p[17] = Connection.GetParameter
				("@POD_LOCATION_CD", Pod_Location_Cd);
			p[18] = Connection.GetParameter
				("@PLOD_LOCATION_CD", Plod_Location_Cd);
			p[19] = Connection.GetParameter
				("@ACTUAL_DEPARTURE_FLG", Actual_Departure_Flg);
			p[20] = Connection.GetParameter
				("@ACTUAL_ARRIVAL_FLG", Actual_Arrival_Flg);
			p[21] = Connection.GetParameter
				("@PLOR_QUALIFIER", Plor_Qualifier);
			p[22] = Connection.GetParameter
				("@PLOR_STATIC_ID", Plor_Static_ID);
			p[23] = Connection.GetParameter
				("@PLOR_NAME", Plor_Name);
			p[24] = Connection.GetParameter
				("@PLOR_TERMINAL", Plor_Terminal);
			p[25] = Connection.GetParameter
				("@PLOR_DATE_QUALIFIER", Plor_Date_Qualifier);
			p[26] = Connection.GetParameter
				("@PLOR_DATE", Plor_Date);
			p[27] = Connection.GetParameter
				("@PLOR_TIME", Plor_Time);
			p[28] = Connection.GetParameter
				("@POL_QUALIFIER", Pol_Qualifier);
			p[29] = Connection.GetParameter
				("@POL_STATIC_ID", Pol_Static_ID);
			p[30] = Connection.GetParameter
				("@POL_NAME", Pol_Name);
			p[31] = Connection.GetParameter
				("@POL_TERMINAL", Pol_Terminal);
			p[32] = Connection.GetParameter
				("@POL_DATE_QUALIFIER", Pol_Date_Qualifier);
			p[33] = Connection.GetParameter
				("@POL_DATE", Pol_Date);
			p[34] = Connection.GetParameter
				("@POL_TIME", Pol_Time);
			p[35] = Connection.GetParameter
				("@POD_QUALIFIER", Pod_Qualifier);
			p[36] = Connection.GetParameter
				("@POD_STATIC_ID", Pod_Static_ID);
			p[37] = Connection.GetParameter
				("@POD_NAME", Pod_Name);
			p[38] = Connection.GetParameter
				("@POD_TERMINAL", Pod_Terminal);
			p[39] = Connection.GetParameter
				("@POD_DATE_QUALIFIER", Pod_Date_Qualifier);
			p[40] = Connection.GetParameter
				("@POD_DATE", Pod_Date);
			p[41] = Connection.GetParameter
				("@POD_TIME", Pod_Time);
			p[42] = Connection.GetParameter
				("@PLOD_QUALIFIER", Plod_Qualifier);
			p[43] = Connection.GetParameter
				("@PLOD_STATIC_ID", Plod_Static_ID);
			p[44] = Connection.GetParameter
				("@PLOD_NAME", Plod_Name);
			p[45] = Connection.GetParameter
				("@PLOD_TERMINAL", Plod_Terminal);
			p[46] = Connection.GetParameter
				("@PLOD_DATE_QUALIFIER", Plod_Date_Qualifier);
			p[47] = Connection.GetParameter
				("@PLOD_DATE", Plod_Date);
			p[48] = Connection.GetParameter
				("@PLOD_TIME", Plod_Time);
			p[49] = Connection.GetParameter
				("@PCFN", Pcfn);
			p[50] = Connection.GetParameter
				("@BOOKING_SUB", Booking_Sub);
			p[51] = Connection.GetParameter
				("@MILITARY_VOYAGE_NO", Military_Voyage_No);
			p[52] = Connection.GetParameter
				("@LADING_QTY_NO", Lading_Qty_No);
			p[53] = Connection.GetParameter
				("@WEIGHT_UNIT_CD", Weight_Unit_Cd);
			p[54] = Connection.GetParameter
				("@WEIGHT_NBR", Weight_Nbr);
			p[55] = Connection.GetParameter
				("@VOLUME_QUALIFIER", Volume_Qualifier);
			p[56] = Connection.GetParameter
				("@VOLUME_NBR", Volume_Nbr);
			p[57] = Connection.GetParameter
				("@VESSEL_QUALIFIER", Vessel_Qualifier);
			p[58] = Connection.GetParameter
				("@ACTIVITY_STATIC_LOCATION", Activity_Static_Location);
			p[59] = Connection.GetParameter
				("@ACTIVITY_LOCATION_QUALIFIER", Activity_Location_Qualifier);
			p[60] = Connection.GetParameter
				("@VESSEL_NM", Vessel_Nm);
			p[61] = Connection.GetParameter
				("@MSG", Msg);
			p[62] = Connection.GetParameter
				("@PROCESSED_FLG", Processed_Flg);
			p[63] = Connection.GetParameter
				("@ACMS_ACTIVITY_ID", Acms_Activity_ID);
			p[64] = Connection.GetParameter
				("@EDI315_ID", Edi315_ID, ParameterDirection.Output, DbType.Int64, 0);
			p[65] = Connection.GetParameter
				("@CREATE_DT", Create_Dt, ParameterDirection.Output, DbType.DateTime, 0);
			p[66] = Connection.GetParameter
				("@CREATE_USER", Create_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Create_UserMax);
			p[67] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.Output, DbType.DateTime, 0);
			p[68] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);

			const string sql = @"
				INSERT INTO T_EDI315
					(EDI315_ID, ISA_ID, ITV_ID,
					ISA_NBR, CARGO_KEY, CARGO_LINE_ID,
					SERIAL_NO, ACTIVITY_DT, ACTIVITY_CD,
					BOOKING_NO, BOL_NO, LOCATION_CD,
					VOYAGE_NO, VESSEL_CD, DEPARTURE_DT,
					ARRIVAL_DT, PLOR_LOCATION_CD, POL_LOCATION_CD,
					POD_LOCATION_CD, PLOD_LOCATION_CD, ACTUAL_DEPARTURE_FLG,
					ACTUAL_ARRIVAL_FLG, PLOR_QUALIFIER, PLOR_STATIC_ID,
					PLOR_NAME, PLOR_TERMINAL, PLOR_DATE_QUALIFIER,
					PLOR_DATE, PLOR_TIME, POL_QUALIFIER,
					POL_STATIC_ID, POL_NAME, POL_TERMINAL,
					POL_DATE_QUALIFIER, POL_DATE, POL_TIME,
					POD_QUALIFIER, POD_STATIC_ID, POD_NAME,
					POD_TERMINAL, POD_DATE_QUALIFIER, POD_DATE,
					POD_TIME, PLOD_QUALIFIER, PLOD_STATIC_ID,
					PLOD_NAME, PLOD_TERMINAL, PLOD_DATE_QUALIFIER,
					PLOD_DATE, PLOD_TIME, PCFN,
					BOOKING_SUB, MILITARY_VOYAGE_NO, LADING_QTY_NO,
					WEIGHT_UNIT_CD, WEIGHT_NBR, VOLUME_QUALIFIER,
					VOLUME_NBR, VESSEL_QUALIFIER, ACTIVITY_STATIC_LOCATION,
					ACTIVITY_LOCATION_QUALIFIER, VESSEL_NM, MSG,
					PROCESSED_FLG, ACMS_ACTIVITY_ID)
				VALUES
					(EDI315_ID_SEQ.NEXTVAL, @ISA_ID, @ITV_ID,
					@ISA_NBR, @CARGO_KEY, @CARGO_LINE_ID,
					@SERIAL_NO, @ACTIVITY_DT, @ACTIVITY_CD,
					@BOOKING_NO, @BOL_NO, @LOCATION_CD,
					@VOYAGE_NO, @VESSEL_CD, @DEPARTURE_DT,
					@ARRIVAL_DT, @PLOR_LOCATION_CD, @POL_LOCATION_CD,
					@POD_LOCATION_CD, @PLOD_LOCATION_CD, @ACTUAL_DEPARTURE_FLG,
					@ACTUAL_ARRIVAL_FLG, @PLOR_QUALIFIER, @PLOR_STATIC_ID,
					@PLOR_NAME, @PLOR_TERMINAL, @PLOR_DATE_QUALIFIER,
					@PLOR_DATE, @PLOR_TIME, @POL_QUALIFIER,
					@POL_STATIC_ID, @POL_NAME, @POL_TERMINAL,
					@POL_DATE_QUALIFIER, @POL_DATE, @POL_TIME,
					@POD_QUALIFIER, @POD_STATIC_ID, @POD_NAME,
					@POD_TERMINAL, @POD_DATE_QUALIFIER, @POD_DATE,
					@POD_TIME, @PLOD_QUALIFIER, @PLOD_STATIC_ID,
					@PLOD_NAME, @PLOD_TERMINAL, @PLOD_DATE_QUALIFIER,
					@PLOD_DATE, @PLOD_TIME, @PCFN,
					@BOOKING_SUB, @MILITARY_VOYAGE_NO, @LADING_QTY_NO,
					@WEIGHT_UNIT_CD, @WEIGHT_NBR, @VOLUME_QUALIFIER,
					@VOLUME_NBR, @VESSEL_QUALIFIER, @ACTIVITY_STATIC_LOCATION,
					@ACTIVITY_LOCATION_QUALIFIER, @VESSEL_NM, @MSG,
					@PROCESSED_FLG, @ACMS_ACTIVITY_ID)
				RETURNING
					EDI315_ID, CREATE_DT, CREATE_USER,
					MODIFY_DT, MODIFY_USER
				INTO
					@EDI315_ID, @CREATE_DT, @CREATE_USER,
					@MODIFY_DT, @MODIFY_USER";
			int ret = Connection.RunSQL(sql, p);

			Edi315_ID = ClsConvert.ToInt64Nullable(p[64].Value);
			Create_Dt = ClsConvert.ToDateTimeNullable(p[65].Value);
			Create_User = ClsConvert.ToString(p[66].Value);
			Modify_Dt = ClsConvert.ToDateTimeNullable(p[67].Value);
			Modify_User = ClsConvert.ToString(p[68].Value);
			return ret;
		}
		public override int Update()
		{
			DbParameter[] p = new DbParameter[67];

			p[0] = Connection.GetParameter
				("@ISA_ID", Isa_ID);
			p[1] = Connection.GetParameter
				("@ITV_ID", Itv_ID);
			p[2] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.InputOutput, DbType.DateTime, 0);
			p[3] = Connection.GetParameter
				("@ISA_NBR", Isa_Nbr);
			p[4] = Connection.GetParameter
				("@CARGO_KEY", Cargo_Key);
			p[5] = Connection.GetParameter
				("@CARGO_LINE_ID", Cargo_Line_ID);
			p[6] = Connection.GetParameter
				("@SERIAL_NO", Serial_No);
			p[7] = Connection.GetParameter
				("@ACTIVITY_DT", Activity_Dt);
			p[8] = Connection.GetParameter
				("@ACTIVITY_CD", Activity_Cd);
			p[9] = Connection.GetParameter
				("@BOOKING_NO", Booking_No);
			p[10] = Connection.GetParameter
				("@BOL_NO", Bol_No);
			p[11] = Connection.GetParameter
				("@LOCATION_CD", Location_Cd);
			p[12] = Connection.GetParameter
				("@VOYAGE_NO", Voyage_No);
			p[13] = Connection.GetParameter
				("@VESSEL_CD", Vessel_Cd);
			p[14] = Connection.GetParameter
				("@DEPARTURE_DT", Departure_Dt);
			p[15] = Connection.GetParameter
				("@ARRIVAL_DT", Arrival_Dt);
			p[16] = Connection.GetParameter
				("@PLOR_LOCATION_CD", Plor_Location_Cd);
			p[17] = Connection.GetParameter
				("@POL_LOCATION_CD", Pol_Location_Cd);
			p[18] = Connection.GetParameter
				("@POD_LOCATION_CD", Pod_Location_Cd);
			p[19] = Connection.GetParameter
				("@PLOD_LOCATION_CD", Plod_Location_Cd);
			p[20] = Connection.GetParameter
				("@ACTUAL_DEPARTURE_FLG", Actual_Departure_Flg);
			p[21] = Connection.GetParameter
				("@ACTUAL_ARRIVAL_FLG", Actual_Arrival_Flg);
			p[22] = Connection.GetParameter
				("@PLOR_QUALIFIER", Plor_Qualifier);
			p[23] = Connection.GetParameter
				("@PLOR_STATIC_ID", Plor_Static_ID);
			p[24] = Connection.GetParameter
				("@PLOR_NAME", Plor_Name);
			p[25] = Connection.GetParameter
				("@PLOR_TERMINAL", Plor_Terminal);
			p[26] = Connection.GetParameter
				("@PLOR_DATE_QUALIFIER", Plor_Date_Qualifier);
			p[27] = Connection.GetParameter
				("@PLOR_DATE", Plor_Date);
			p[28] = Connection.GetParameter
				("@PLOR_TIME", Plor_Time);
			p[29] = Connection.GetParameter
				("@POL_QUALIFIER", Pol_Qualifier);
			p[30] = Connection.GetParameter
				("@POL_STATIC_ID", Pol_Static_ID);
			p[31] = Connection.GetParameter
				("@POL_NAME", Pol_Name);
			p[32] = Connection.GetParameter
				("@POL_TERMINAL", Pol_Terminal);
			p[33] = Connection.GetParameter
				("@POL_DATE_QUALIFIER", Pol_Date_Qualifier);
			p[34] = Connection.GetParameter
				("@POL_DATE", Pol_Date);
			p[35] = Connection.GetParameter
				("@POL_TIME", Pol_Time);
			p[36] = Connection.GetParameter
				("@POD_QUALIFIER", Pod_Qualifier);
			p[37] = Connection.GetParameter
				("@POD_STATIC_ID", Pod_Static_ID);
			p[38] = Connection.GetParameter
				("@POD_NAME", Pod_Name);
			p[39] = Connection.GetParameter
				("@POD_TERMINAL", Pod_Terminal);
			p[40] = Connection.GetParameter
				("@POD_DATE_QUALIFIER", Pod_Date_Qualifier);
			p[41] = Connection.GetParameter
				("@POD_DATE", Pod_Date);
			p[42] = Connection.GetParameter
				("@POD_TIME", Pod_Time);
			p[43] = Connection.GetParameter
				("@PLOD_QUALIFIER", Plod_Qualifier);
			p[44] = Connection.GetParameter
				("@PLOD_STATIC_ID", Plod_Static_ID);
			p[45] = Connection.GetParameter
				("@PLOD_NAME", Plod_Name);
			p[46] = Connection.GetParameter
				("@PLOD_TERMINAL", Plod_Terminal);
			p[47] = Connection.GetParameter
				("@PLOD_DATE_QUALIFIER", Plod_Date_Qualifier);
			p[48] = Connection.GetParameter
				("@PLOD_DATE", Plod_Date);
			p[49] = Connection.GetParameter
				("@PLOD_TIME", Plod_Time);
			p[50] = Connection.GetParameter
				("@PCFN", Pcfn);
			p[51] = Connection.GetParameter
				("@BOOKING_SUB", Booking_Sub);
			p[52] = Connection.GetParameter
				("@MILITARY_VOYAGE_NO", Military_Voyage_No);
			p[53] = Connection.GetParameter
				("@LADING_QTY_NO", Lading_Qty_No);
			p[54] = Connection.GetParameter
				("@WEIGHT_UNIT_CD", Weight_Unit_Cd);
			p[55] = Connection.GetParameter
				("@WEIGHT_NBR", Weight_Nbr);
			p[56] = Connection.GetParameter
				("@VOLUME_QUALIFIER", Volume_Qualifier);
			p[57] = Connection.GetParameter
				("@VOLUME_NBR", Volume_Nbr);
			p[58] = Connection.GetParameter
				("@VESSEL_QUALIFIER", Vessel_Qualifier);
			p[59] = Connection.GetParameter
				("@ACTIVITY_STATIC_LOCATION", Activity_Static_Location);
			p[60] = Connection.GetParameter
				("@ACTIVITY_LOCATION_QUALIFIER", Activity_Location_Qualifier);
			p[61] = Connection.GetParameter
				("@VESSEL_NM", Vessel_Nm);
			p[62] = Connection.GetParameter
				("@MSG", Msg);
			p[63] = Connection.GetParameter
				("@PROCESSED_FLG", Processed_Flg);
			p[64] = Connection.GetParameter
				("@ACMS_ACTIVITY_ID", Acms_Activity_ID);
			p[65] = Connection.GetParameter
				("@EDI315_ID", Edi315_ID);
			p[66] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);

			const string sql = @"
				UPDATE T_EDI315 SET
					ISA_ID = @ISA_ID,
					ITV_ID = @ITV_ID,
					MODIFY_DT = @MODIFY_DT,
					ISA_NBR = @ISA_NBR,
					CARGO_KEY = @CARGO_KEY,
					CARGO_LINE_ID = @CARGO_LINE_ID,
					SERIAL_NO = @SERIAL_NO,
					ACTIVITY_DT = @ACTIVITY_DT,
					ACTIVITY_CD = @ACTIVITY_CD,
					BOOKING_NO = @BOOKING_NO,
					BOL_NO = @BOL_NO,
					LOCATION_CD = @LOCATION_CD,
					VOYAGE_NO = @VOYAGE_NO,
					VESSEL_CD = @VESSEL_CD,
					DEPARTURE_DT = @DEPARTURE_DT,
					ARRIVAL_DT = @ARRIVAL_DT,
					PLOR_LOCATION_CD = @PLOR_LOCATION_CD,
					POL_LOCATION_CD = @POL_LOCATION_CD,
					POD_LOCATION_CD = @POD_LOCATION_CD,
					PLOD_LOCATION_CD = @PLOD_LOCATION_CD,
					ACTUAL_DEPARTURE_FLG = @ACTUAL_DEPARTURE_FLG,
					ACTUAL_ARRIVAL_FLG = @ACTUAL_ARRIVAL_FLG,
					PLOR_QUALIFIER = @PLOR_QUALIFIER,
					PLOR_STATIC_ID = @PLOR_STATIC_ID,
					PLOR_NAME = @PLOR_NAME,
					PLOR_TERMINAL = @PLOR_TERMINAL,
					PLOR_DATE_QUALIFIER = @PLOR_DATE_QUALIFIER,
					PLOR_DATE = @PLOR_DATE,
					PLOR_TIME = @PLOR_TIME,
					POL_QUALIFIER = @POL_QUALIFIER,
					POL_STATIC_ID = @POL_STATIC_ID,
					POL_NAME = @POL_NAME,
					POL_TERMINAL = @POL_TERMINAL,
					POL_DATE_QUALIFIER = @POL_DATE_QUALIFIER,
					POL_DATE = @POL_DATE,
					POL_TIME = @POL_TIME,
					POD_QUALIFIER = @POD_QUALIFIER,
					POD_STATIC_ID = @POD_STATIC_ID,
					POD_NAME = @POD_NAME,
					POD_TERMINAL = @POD_TERMINAL,
					POD_DATE_QUALIFIER = @POD_DATE_QUALIFIER,
					POD_DATE = @POD_DATE,
					POD_TIME = @POD_TIME,
					PLOD_QUALIFIER = @PLOD_QUALIFIER,
					PLOD_STATIC_ID = @PLOD_STATIC_ID,
					PLOD_NAME = @PLOD_NAME,
					PLOD_TERMINAL = @PLOD_TERMINAL,
					PLOD_DATE_QUALIFIER = @PLOD_DATE_QUALIFIER,
					PLOD_DATE = @PLOD_DATE,
					PLOD_TIME = @PLOD_TIME,
					PCFN = @PCFN,
					BOOKING_SUB = @BOOKING_SUB,
					MILITARY_VOYAGE_NO = @MILITARY_VOYAGE_NO,
					LADING_QTY_NO = @LADING_QTY_NO,
					WEIGHT_UNIT_CD = @WEIGHT_UNIT_CD,
					WEIGHT_NBR = @WEIGHT_NBR,
					VOLUME_QUALIFIER = @VOLUME_QUALIFIER,
					VOLUME_NBR = @VOLUME_NBR,
					VESSEL_QUALIFIER = @VESSEL_QUALIFIER,
					ACTIVITY_STATIC_LOCATION = @ACTIVITY_STATIC_LOCATION,
					ACTIVITY_LOCATION_QUALIFIER = @ACTIVITY_LOCATION_QUALIFIER,
					VESSEL_NM = @VESSEL_NM,
					MSG = @MSG,
					PROCESSED_FLG = @PROCESSED_FLG,
					ACMS_ACTIVITY_ID = @ACMS_ACTIVITY_ID
				WHERE
					EDI315_ID = @EDI315_ID
				RETURNING
					MODIFY_DT, MODIFY_USER
				INTO
					@MODIFY_DT, @MODIFY_USER";
			int ret = Connection.RunSQL(sql, p);

			Modify_Dt = ClsConvert.ToDateTimeNullable(p[2].Value);
			Modify_User = ClsConvert.ToString(p[66].Value);
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

			Edi315_ID = ClsConvert.ToInt64Nullable(dr["EDI315_ID"]);
			Isa_ID = ClsConvert.ToInt64Nullable(dr["ISA_ID"]);
			Itv_ID = ClsConvert.ToInt64Nullable(dr["ITV_ID"]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT"]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER"]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT"]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER"]);
			Isa_Nbr = ClsConvert.ToInt64Nullable(dr["ISA_NBR"]);
			Cargo_Key = ClsConvert.ToString(dr["CARGO_KEY"]);
			Cargo_Line_ID = ClsConvert.ToInt64Nullable(dr["CARGO_LINE_ID"]);
			Serial_No = ClsConvert.ToString(dr["SERIAL_NO"]);
			Activity_Dt = ClsConvert.ToDateTimeNullable(dr["ACTIVITY_DT"]);
			Activity_Cd = ClsConvert.ToString(dr["ACTIVITY_CD"]);
			Booking_No = ClsConvert.ToString(dr["BOOKING_NO"]);
			Bol_No = ClsConvert.ToString(dr["BOL_NO"]);
			Location_Cd = ClsConvert.ToString(dr["LOCATION_CD"]);
			Voyage_No = ClsConvert.ToString(dr["VOYAGE_NO"]);
			Vessel_Cd = ClsConvert.ToString(dr["VESSEL_CD"]);
			Departure_Dt = ClsConvert.ToDateTimeNullable(dr["DEPARTURE_DT"]);
			Arrival_Dt = ClsConvert.ToDateTimeNullable(dr["ARRIVAL_DT"]);
			Plor_Location_Cd = ClsConvert.ToString(dr["PLOR_LOCATION_CD"]);
			Pol_Location_Cd = ClsConvert.ToString(dr["POL_LOCATION_CD"]);
			Pod_Location_Cd = ClsConvert.ToString(dr["POD_LOCATION_CD"]);
			Plod_Location_Cd = ClsConvert.ToString(dr["PLOD_LOCATION_CD"]);
			Actual_Departure_Flg = ClsConvert.ToString(dr["ACTUAL_DEPARTURE_FLG"]);
			Actual_Arrival_Flg = ClsConvert.ToString(dr["ACTUAL_ARRIVAL_FLG"]);
			Plor_Qualifier = ClsConvert.ToString(dr["PLOR_QUALIFIER"]);
			Plor_Static_ID = ClsConvert.ToString(dr["PLOR_STATIC_ID"]);
			Plor_Name = ClsConvert.ToString(dr["PLOR_NAME"]);
			Plor_Terminal = ClsConvert.ToString(dr["PLOR_TERMINAL"]);
			Plor_Date_Qualifier = ClsConvert.ToString(dr["PLOR_DATE_QUALIFIER"]);
			Plor_Date = ClsConvert.ToString(dr["PLOR_DATE"]);
			Plor_Time = ClsConvert.ToString(dr["PLOR_TIME"]);
			Pol_Qualifier = ClsConvert.ToString(dr["POL_QUALIFIER"]);
			Pol_Static_ID = ClsConvert.ToString(dr["POL_STATIC_ID"]);
			Pol_Name = ClsConvert.ToString(dr["POL_NAME"]);
			Pol_Terminal = ClsConvert.ToString(dr["POL_TERMINAL"]);
			Pol_Date_Qualifier = ClsConvert.ToString(dr["POL_DATE_QUALIFIER"]);
			Pol_Date = ClsConvert.ToString(dr["POL_DATE"]);
			Pol_Time = ClsConvert.ToString(dr["POL_TIME"]);
			Pod_Qualifier = ClsConvert.ToString(dr["POD_QUALIFIER"]);
			Pod_Static_ID = ClsConvert.ToString(dr["POD_STATIC_ID"]);
			Pod_Name = ClsConvert.ToString(dr["POD_NAME"]);
			Pod_Terminal = ClsConvert.ToString(dr["POD_TERMINAL"]);
			Pod_Date_Qualifier = ClsConvert.ToString(dr["POD_DATE_QUALIFIER"]);
			Pod_Date = ClsConvert.ToString(dr["POD_DATE"]);
			Pod_Time = ClsConvert.ToString(dr["POD_TIME"]);
			Plod_Qualifier = ClsConvert.ToString(dr["PLOD_QUALIFIER"]);
			Plod_Static_ID = ClsConvert.ToString(dr["PLOD_STATIC_ID"]);
			Plod_Name = ClsConvert.ToString(dr["PLOD_NAME"]);
			Plod_Terminal = ClsConvert.ToString(dr["PLOD_TERMINAL"]);
			Plod_Date_Qualifier = ClsConvert.ToString(dr["PLOD_DATE_QUALIFIER"]);
			Plod_Date = ClsConvert.ToString(dr["PLOD_DATE"]);
			Plod_Time = ClsConvert.ToString(dr["PLOD_TIME"]);
			Pcfn = ClsConvert.ToString(dr["PCFN"]);
			Booking_Sub = ClsConvert.ToString(dr["BOOKING_SUB"]);
			Military_Voyage_No = ClsConvert.ToString(dr["MILITARY_VOYAGE_NO"]);
			Lading_Qty_No = ClsConvert.ToInt64Nullable(dr["LADING_QTY_NO"]);
			Weight_Unit_Cd = ClsConvert.ToString(dr["WEIGHT_UNIT_CD"]);
			Weight_Nbr = ClsConvert.ToInt64Nullable(dr["WEIGHT_NBR"]);
			Volume_Qualifier = ClsConvert.ToString(dr["VOLUME_QUALIFIER"]);
			Volume_Nbr = ClsConvert.ToInt64Nullable(dr["VOLUME_NBR"]);
			Vessel_Qualifier = ClsConvert.ToString(dr["VESSEL_QUALIFIER"]);
			Activity_Static_Location = ClsConvert.ToString(dr["ACTIVITY_STATIC_LOCATION"]);
			Activity_Location_Qualifier = ClsConvert.ToString(dr["ACTIVITY_LOCATION_QUALIFIER"]);
			Vessel_Nm = ClsConvert.ToString(dr["VESSEL_NM"]);
			Msg = ClsConvert.ToString(dr["MSG"]);
			Processed_Flg = ClsConvert.ToString(dr["PROCESSED_FLG"]);
			Acms_Activity_ID = ClsConvert.ToInt64Nullable(dr["ACMS_ACTIVITY_ID"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Edi315_ID = ClsConvert.ToInt64Nullable(dr["EDI315_ID", v]);
			Isa_ID = ClsConvert.ToInt64Nullable(dr["ISA_ID", v]);
			Itv_ID = ClsConvert.ToInt64Nullable(dr["ITV_ID", v]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT", v]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER", v]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT", v]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER", v]);
			Isa_Nbr = ClsConvert.ToInt64Nullable(dr["ISA_NBR", v]);
			Cargo_Key = ClsConvert.ToString(dr["CARGO_KEY", v]);
			Cargo_Line_ID = ClsConvert.ToInt64Nullable(dr["CARGO_LINE_ID", v]);
			Serial_No = ClsConvert.ToString(dr["SERIAL_NO", v]);
			Activity_Dt = ClsConvert.ToDateTimeNullable(dr["ACTIVITY_DT", v]);
			Activity_Cd = ClsConvert.ToString(dr["ACTIVITY_CD", v]);
			Booking_No = ClsConvert.ToString(dr["BOOKING_NO", v]);
			Bol_No = ClsConvert.ToString(dr["BOL_NO", v]);
			Location_Cd = ClsConvert.ToString(dr["LOCATION_CD", v]);
			Voyage_No = ClsConvert.ToString(dr["VOYAGE_NO", v]);
			Vessel_Cd = ClsConvert.ToString(dr["VESSEL_CD", v]);
			Departure_Dt = ClsConvert.ToDateTimeNullable(dr["DEPARTURE_DT", v]);
			Arrival_Dt = ClsConvert.ToDateTimeNullable(dr["ARRIVAL_DT", v]);
			Plor_Location_Cd = ClsConvert.ToString(dr["PLOR_LOCATION_CD", v]);
			Pol_Location_Cd = ClsConvert.ToString(dr["POL_LOCATION_CD", v]);
			Pod_Location_Cd = ClsConvert.ToString(dr["POD_LOCATION_CD", v]);
			Plod_Location_Cd = ClsConvert.ToString(dr["PLOD_LOCATION_CD", v]);
			Actual_Departure_Flg = ClsConvert.ToString(dr["ACTUAL_DEPARTURE_FLG", v]);
			Actual_Arrival_Flg = ClsConvert.ToString(dr["ACTUAL_ARRIVAL_FLG", v]);
			Plor_Qualifier = ClsConvert.ToString(dr["PLOR_QUALIFIER", v]);
			Plor_Static_ID = ClsConvert.ToString(dr["PLOR_STATIC_ID", v]);
			Plor_Name = ClsConvert.ToString(dr["PLOR_NAME", v]);
			Plor_Terminal = ClsConvert.ToString(dr["PLOR_TERMINAL", v]);
			Plor_Date_Qualifier = ClsConvert.ToString(dr["PLOR_DATE_QUALIFIER", v]);
			Plor_Date = ClsConvert.ToString(dr["PLOR_DATE", v]);
			Plor_Time = ClsConvert.ToString(dr["PLOR_TIME", v]);
			Pol_Qualifier = ClsConvert.ToString(dr["POL_QUALIFIER", v]);
			Pol_Static_ID = ClsConvert.ToString(dr["POL_STATIC_ID", v]);
			Pol_Name = ClsConvert.ToString(dr["POL_NAME", v]);
			Pol_Terminal = ClsConvert.ToString(dr["POL_TERMINAL", v]);
			Pol_Date_Qualifier = ClsConvert.ToString(dr["POL_DATE_QUALIFIER", v]);
			Pol_Date = ClsConvert.ToString(dr["POL_DATE", v]);
			Pol_Time = ClsConvert.ToString(dr["POL_TIME", v]);
			Pod_Qualifier = ClsConvert.ToString(dr["POD_QUALIFIER", v]);
			Pod_Static_ID = ClsConvert.ToString(dr["POD_STATIC_ID", v]);
			Pod_Name = ClsConvert.ToString(dr["POD_NAME", v]);
			Pod_Terminal = ClsConvert.ToString(dr["POD_TERMINAL", v]);
			Pod_Date_Qualifier = ClsConvert.ToString(dr["POD_DATE_QUALIFIER", v]);
			Pod_Date = ClsConvert.ToString(dr["POD_DATE", v]);
			Pod_Time = ClsConvert.ToString(dr["POD_TIME", v]);
			Plod_Qualifier = ClsConvert.ToString(dr["PLOD_QUALIFIER", v]);
			Plod_Static_ID = ClsConvert.ToString(dr["PLOD_STATIC_ID", v]);
			Plod_Name = ClsConvert.ToString(dr["PLOD_NAME", v]);
			Plod_Terminal = ClsConvert.ToString(dr["PLOD_TERMINAL", v]);
			Plod_Date_Qualifier = ClsConvert.ToString(dr["PLOD_DATE_QUALIFIER", v]);
			Plod_Date = ClsConvert.ToString(dr["PLOD_DATE", v]);
			Plod_Time = ClsConvert.ToString(dr["PLOD_TIME", v]);
			Pcfn = ClsConvert.ToString(dr["PCFN", v]);
			Booking_Sub = ClsConvert.ToString(dr["BOOKING_SUB", v]);
			Military_Voyage_No = ClsConvert.ToString(dr["MILITARY_VOYAGE_NO", v]);
			Lading_Qty_No = ClsConvert.ToInt64Nullable(dr["LADING_QTY_NO", v]);
			Weight_Unit_Cd = ClsConvert.ToString(dr["WEIGHT_UNIT_CD", v]);
			Weight_Nbr = ClsConvert.ToInt64Nullable(dr["WEIGHT_NBR", v]);
			Volume_Qualifier = ClsConvert.ToString(dr["VOLUME_QUALIFIER", v]);
			Volume_Nbr = ClsConvert.ToInt64Nullable(dr["VOLUME_NBR", v]);
			Vessel_Qualifier = ClsConvert.ToString(dr["VESSEL_QUALIFIER", v]);
			Activity_Static_Location = ClsConvert.ToString(dr["ACTIVITY_STATIC_LOCATION", v]);
			Activity_Location_Qualifier = ClsConvert.ToString(dr["ACTIVITY_LOCATION_QUALIFIER", v]);
			Vessel_Nm = ClsConvert.ToString(dr["VESSEL_NM", v]);
			Msg = ClsConvert.ToString(dr["MSG", v]);
			Processed_Flg = ClsConvert.ToString(dr["PROCESSED_FLG", v]);
			Acms_Activity_ID = ClsConvert.ToInt64Nullable(dr["ACMS_ACTIVITY_ID", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["EDI315_ID"] = ClsConvert.ToDbObject(Edi315_ID);
			dr["ISA_ID"] = ClsConvert.ToDbObject(Isa_ID);
			dr["ITV_ID"] = ClsConvert.ToDbObject(Itv_ID);
			dr["CREATE_DT"] = ClsConvert.ToDbObject(Create_Dt);
			dr["CREATE_USER"] = ClsConvert.ToDbObject(Create_User);
			dr["MODIFY_DT"] = ClsConvert.ToDbObject(Modify_Dt);
			dr["MODIFY_USER"] = ClsConvert.ToDbObject(Modify_User);
			dr["ISA_NBR"] = ClsConvert.ToDbObject(Isa_Nbr);
			dr["CARGO_KEY"] = ClsConvert.ToDbObject(Cargo_Key);
			dr["CARGO_LINE_ID"] = ClsConvert.ToDbObject(Cargo_Line_ID);
			dr["SERIAL_NO"] = ClsConvert.ToDbObject(Serial_No);
			dr["ACTIVITY_DT"] = ClsConvert.ToDbObject(Activity_Dt);
			dr["ACTIVITY_CD"] = ClsConvert.ToDbObject(Activity_Cd);
			dr["BOOKING_NO"] = ClsConvert.ToDbObject(Booking_No);
			dr["BOL_NO"] = ClsConvert.ToDbObject(Bol_No);
			dr["LOCATION_CD"] = ClsConvert.ToDbObject(Location_Cd);
			dr["VOYAGE_NO"] = ClsConvert.ToDbObject(Voyage_No);
			dr["VESSEL_CD"] = ClsConvert.ToDbObject(Vessel_Cd);
			dr["DEPARTURE_DT"] = ClsConvert.ToDbObject(Departure_Dt);
			dr["ARRIVAL_DT"] = ClsConvert.ToDbObject(Arrival_Dt);
			dr["PLOR_LOCATION_CD"] = ClsConvert.ToDbObject(Plor_Location_Cd);
			dr["POL_LOCATION_CD"] = ClsConvert.ToDbObject(Pol_Location_Cd);
			dr["POD_LOCATION_CD"] = ClsConvert.ToDbObject(Pod_Location_Cd);
			dr["PLOD_LOCATION_CD"] = ClsConvert.ToDbObject(Plod_Location_Cd);
			dr["ACTUAL_DEPARTURE_FLG"] = ClsConvert.ToDbObject(Actual_Departure_Flg);
			dr["ACTUAL_ARRIVAL_FLG"] = ClsConvert.ToDbObject(Actual_Arrival_Flg);
			dr["PLOR_QUALIFIER"] = ClsConvert.ToDbObject(Plor_Qualifier);
			dr["PLOR_STATIC_ID"] = ClsConvert.ToDbObject(Plor_Static_ID);
			dr["PLOR_NAME"] = ClsConvert.ToDbObject(Plor_Name);
			dr["PLOR_TERMINAL"] = ClsConvert.ToDbObject(Plor_Terminal);
			dr["PLOR_DATE_QUALIFIER"] = ClsConvert.ToDbObject(Plor_Date_Qualifier);
			dr["PLOR_DATE"] = ClsConvert.ToDbObject(Plor_Date);
			dr["PLOR_TIME"] = ClsConvert.ToDbObject(Plor_Time);
			dr["POL_QUALIFIER"] = ClsConvert.ToDbObject(Pol_Qualifier);
			dr["POL_STATIC_ID"] = ClsConvert.ToDbObject(Pol_Static_ID);
			dr["POL_NAME"] = ClsConvert.ToDbObject(Pol_Name);
			dr["POL_TERMINAL"] = ClsConvert.ToDbObject(Pol_Terminal);
			dr["POL_DATE_QUALIFIER"] = ClsConvert.ToDbObject(Pol_Date_Qualifier);
			dr["POL_DATE"] = ClsConvert.ToDbObject(Pol_Date);
			dr["POL_TIME"] = ClsConvert.ToDbObject(Pol_Time);
			dr["POD_QUALIFIER"] = ClsConvert.ToDbObject(Pod_Qualifier);
			dr["POD_STATIC_ID"] = ClsConvert.ToDbObject(Pod_Static_ID);
			dr["POD_NAME"] = ClsConvert.ToDbObject(Pod_Name);
			dr["POD_TERMINAL"] = ClsConvert.ToDbObject(Pod_Terminal);
			dr["POD_DATE_QUALIFIER"] = ClsConvert.ToDbObject(Pod_Date_Qualifier);
			dr["POD_DATE"] = ClsConvert.ToDbObject(Pod_Date);
			dr["POD_TIME"] = ClsConvert.ToDbObject(Pod_Time);
			dr["PLOD_QUALIFIER"] = ClsConvert.ToDbObject(Plod_Qualifier);
			dr["PLOD_STATIC_ID"] = ClsConvert.ToDbObject(Plod_Static_ID);
			dr["PLOD_NAME"] = ClsConvert.ToDbObject(Plod_Name);
			dr["PLOD_TERMINAL"] = ClsConvert.ToDbObject(Plod_Terminal);
			dr["PLOD_DATE_QUALIFIER"] = ClsConvert.ToDbObject(Plod_Date_Qualifier);
			dr["PLOD_DATE"] = ClsConvert.ToDbObject(Plod_Date);
			dr["PLOD_TIME"] = ClsConvert.ToDbObject(Plod_Time);
			dr["PCFN"] = ClsConvert.ToDbObject(Pcfn);
			dr["BOOKING_SUB"] = ClsConvert.ToDbObject(Booking_Sub);
			dr["MILITARY_VOYAGE_NO"] = ClsConvert.ToDbObject(Military_Voyage_No);
			dr["LADING_QTY_NO"] = ClsConvert.ToDbObject(Lading_Qty_No);
			dr["WEIGHT_UNIT_CD"] = ClsConvert.ToDbObject(Weight_Unit_Cd);
			dr["WEIGHT_NBR"] = ClsConvert.ToDbObject(Weight_Nbr);
			dr["VOLUME_QUALIFIER"] = ClsConvert.ToDbObject(Volume_Qualifier);
			dr["VOLUME_NBR"] = ClsConvert.ToDbObject(Volume_Nbr);
			dr["VESSEL_QUALIFIER"] = ClsConvert.ToDbObject(Vessel_Qualifier);
			dr["ACTIVITY_STATIC_LOCATION"] = ClsConvert.ToDbObject(Activity_Static_Location);
			dr["ACTIVITY_LOCATION_QUALIFIER"] = ClsConvert.ToDbObject(Activity_Location_Qualifier);
			dr["VESSEL_NM"] = ClsConvert.ToDbObject(Vessel_Nm);
			dr["MSG"] = ClsConvert.ToDbObject(Msg);
			dr["PROCESSED_FLG"] = ClsConvert.ToDbObject(Processed_Flg);
			dr["ACMS_ACTIVITY_ID"] = ClsConvert.ToDbObject(Acms_Activity_ID);
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

		public static ClsEdi315 GetUsingKey(Int64 Edi315_ID)
		{
			object[] vals = new object[] {Edi315_ID};
			DataRow dr = Connection.GetDataRowUsingKey
				(TableName, GetPrimaryKeys(), vals);
			return ( dr == null ) ? null : new ClsEdi315(dr);
		}
		public static DataTable GetAll(Int64? Isa_ID, Int64? Itv_ID)
		{
			List<DbParameter> lst = new List<DbParameter>();	
			StringBuilder sb = new StringBuilder();
		
			if( Isa_ID != null && Isa_ID > 0 )
			{
				lst.Add(Connection.GetParameter("@ISA_ID", Isa_ID));
				sb.Append(" WHERE T_EDI315.ISA_ID=@ISA_ID");
			}
			if( Itv_ID != null && Itv_ID > 0 )
			{
				lst.Add(Connection.GetParameter("@ITV_ID", Itv_ID));
				sb.AppendFormat(" {0} T_EDI315.ITV_ID=@ITV_ID",
					sb.Length > 0 ? "AND" : "WHERE");
			}
			sb.Insert(0, SelectSQL);
			return Connection.GetDataTable(sb.ToString(), lst.ToArray());
		}
		#endregion		// #region Static Methods
	}
}