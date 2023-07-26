using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsVwArcBookingHeader : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ArcSys"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "vw_arc_booking_header";
		public const int PrimaryKeyCount = 0;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] {  };
		}

		public const string SelectSQL = "SELECT * FROM vw_arc_booking_header";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int ScacMax = 4;
		public const int Booking_NoMax = 50;
		public const int AlternatenumberMax = 50;
		public const int Voyage_NoMax = 10;
		public const int Vessel_CdMax = 5;
		public const int Vessel_NmMax = 30;
		public const int Lloyds_NumberMax = 7;
		public const int Imo_NoMax = 7;
		public const int IrcsMax = 7;
		public const int Plor_CdMax = 5;
		public const int Pol_CdMax = 5;
		public const int Pol_Berth_CdMax = 7;
		public const int Pod_CdMax = 5;
		public const int Pod_Berth_CdMax = 7;
		public const int Plod_CdMax = 5;
		public const int MatchcodeMax = 15;
		public const int Customer_NoMax = 6;
		public const int Customer_NameMax = 50;
		public const int Status_CdMax = 30;
		public const int MovetypecdMax = 8;
		public const int Rev_CdMax = 8;
		public const int PcfnMax = 8;
		public const int EdireferenceMax = 40;
		public const int RddMax = 27;
		public const int CreateddateMax = 27;
		public const int UpdateddateMax = 27;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected Int32? _Booking_Ocean_ID;
		protected string _Scac;
		protected string _Booking_No;
		protected string _Alternatenumber;
		protected string _Voyage_No;
		protected string _Vessel_Cd;
		protected string _Vessel_Nm;
		protected string _Lloyds_Number;
		protected string _Imo_No;
		protected string _Ircs;
		protected string _Plor_Cd;
		protected string _Pol_Cd;
		protected string _Pol_Berth_Cd;
		protected string _Pod_Cd;
		protected string _Pod_Berth_Cd;
		protected string _Plod_Cd;
		protected string _Matchcode;
		protected string _Customer_No;
		protected string _Customer_Name;
		protected string _Status_Cd;
		protected string _Movetypecd;
		protected string _Rev_Cd;
		protected string _Pcfn;
		protected string _Edireference;
		protected Int32? _Transhipmenttype;
		protected string _Rdd;
		protected string _Createddate;
		protected string _Updateddate;

		#endregion	// #region Column Fields

		#region Column Properties

		public Int32? Booking_Ocean_ID
		{
			get { return _Booking_Ocean_ID; }
			set
			{
				if( _Booking_Ocean_ID == value ) return;
		
				_Booking_Ocean_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Booking_Ocean_ID");
			}
		}
		public string Scac
		{
			get { return _Scac; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Scac, val, false) == 0 ) return;
		
				if( val != null && val.Length > ScacMax )
					_Scac = val.Substring(0, (int)ScacMax);
				else
					_Scac = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Scac");
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
		public string Alternatenumber
		{
			get { return _Alternatenumber; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Alternatenumber, val, false) == 0 ) return;
		
				if( val != null && val.Length > AlternatenumberMax )
					_Alternatenumber = val.Substring(0, (int)AlternatenumberMax);
				else
					_Alternatenumber = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Alternatenumber");
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
		public string Lloyds_Number
		{
			get { return _Lloyds_Number; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Lloyds_Number, val, false) == 0 ) return;
		
				if( val != null && val.Length > Lloyds_NumberMax )
					_Lloyds_Number = val.Substring(0, (int)Lloyds_NumberMax);
				else
					_Lloyds_Number = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Lloyds_Number");
			}
		}
		public string Imo_No
		{
			get { return _Imo_No; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Imo_No, val, false) == 0 ) return;
		
				if( val != null && val.Length > Imo_NoMax )
					_Imo_No = val.Substring(0, (int)Imo_NoMax);
				else
					_Imo_No = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Imo_No");
			}
		}
		public string Ircs
		{
			get { return _Ircs; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Ircs, val, false) == 0 ) return;
		
				if( val != null && val.Length > IrcsMax )
					_Ircs = val.Substring(0, (int)IrcsMax);
				else
					_Ircs = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Ircs");
			}
		}
		public string Plor_Cd
		{
			get { return _Plor_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Plor_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Plor_CdMax )
					_Plor_Cd = val.Substring(0, (int)Plor_CdMax);
				else
					_Plor_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Plor_Cd");
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
		public string Pol_Berth_Cd
		{
			get { return _Pol_Berth_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Pol_Berth_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Pol_Berth_CdMax )
					_Pol_Berth_Cd = val.Substring(0, (int)Pol_Berth_CdMax);
				else
					_Pol_Berth_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Pol_Berth_Cd");
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
		public string Pod_Berth_Cd
		{
			get { return _Pod_Berth_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Pod_Berth_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Pod_Berth_CdMax )
					_Pod_Berth_Cd = val.Substring(0, (int)Pod_Berth_CdMax);
				else
					_Pod_Berth_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Pod_Berth_Cd");
			}
		}
		public string Plod_Cd
		{
			get { return _Plod_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Plod_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Plod_CdMax )
					_Plod_Cd = val.Substring(0, (int)Plod_CdMax);
				else
					_Plod_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Plod_Cd");
			}
		}
		public string Matchcode
		{
			get { return _Matchcode; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Matchcode, val, false) == 0 ) return;
		
				if( val != null && val.Length > MatchcodeMax )
					_Matchcode = val.Substring(0, (int)MatchcodeMax);
				else
					_Matchcode = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Matchcode");
			}
		}
		public string Customer_No
		{
			get { return _Customer_No; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Customer_No, val, false) == 0 ) return;
		
				if( val != null && val.Length > Customer_NoMax )
					_Customer_No = val.Substring(0, (int)Customer_NoMax);
				else
					_Customer_No = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Customer_No");
			}
		}
		public string Customer_Name
		{
			get { return _Customer_Name; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Customer_Name, val, false) == 0 ) return;
		
				if( val != null && val.Length > Customer_NameMax )
					_Customer_Name = val.Substring(0, (int)Customer_NameMax);
				else
					_Customer_Name = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Customer_Name");
			}
		}
		public string Status_Cd
		{
			get { return _Status_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Status_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Status_CdMax )
					_Status_Cd = val.Substring(0, (int)Status_CdMax);
				else
					_Status_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Status_Cd");
			}
		}
		public string Movetypecd
		{
			get { return _Movetypecd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Movetypecd, val, false) == 0 ) return;
		
				if( val != null && val.Length > MovetypecdMax )
					_Movetypecd = val.Substring(0, (int)MovetypecdMax);
				else
					_Movetypecd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Movetypecd");
			}
		}
		public string Rev_Cd
		{
			get { return _Rev_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Rev_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Rev_CdMax )
					_Rev_Cd = val.Substring(0, (int)Rev_CdMax);
				else
					_Rev_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Rev_Cd");
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
		public string Edireference
		{
			get { return _Edireference; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Edireference, val, false) == 0 ) return;
		
				if( val != null && val.Length > EdireferenceMax )
					_Edireference = val.Substring(0, (int)EdireferenceMax);
				else
					_Edireference = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Edireference");
			}
		}
		public Int32? Transhipmenttype
		{
			get { return _Transhipmenttype; }
			set
			{
				if( _Transhipmenttype == value ) return;
		
				_Transhipmenttype = value;
				_IsDirty = true;
				NotifyPropertyChanged("Transhipmenttype");
			}
		}
		public string Rdd
		{
			get { return _Rdd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Rdd, val, false) == 0 ) return;
		
				if( val != null && val.Length > RddMax )
					_Rdd = val.Substring(0, (int)RddMax);
				else
					_Rdd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Rdd");
			}
		}
		public string Createddate
		{
			get { return _Createddate; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Createddate, val, false) == 0 ) return;
		
				if( val != null && val.Length > CreateddateMax )
					_Createddate = val.Substring(0, (int)CreateddateMax);
				else
					_Createddate = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Createddate");
			}
		}
		public string Updateddate
		{
			get { return _Updateddate; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Updateddate, val, false) == 0 ) return;
		
				if( val != null && val.Length > UpdateddateMax )
					_Updateddate = val.Substring(0, (int)UpdateddateMax);
				else
					_Updateddate = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Updateddate");
			}
		}

		#endregion	// #region Column Properties

		#region Foreign Key Fields



		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties



		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsVwArcBookingHeader() : base() {}
		public ClsVwArcBookingHeader(DataRow dr) : base(dr) {}
		public ClsVwArcBookingHeader(ClsVwArcBookingHeader src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Booking_Ocean_ID = null;
			Scac = null;
			Booking_No = null;
			Alternatenumber = null;
			Voyage_No = null;
			Vessel_Cd = null;
			Vessel_Nm = null;
			Lloyds_Number = null;
			Imo_No = null;
			Ircs = null;
			Plor_Cd = null;
			Pol_Cd = null;
			Pol_Berth_Cd = null;
			Pod_Cd = null;
			Pod_Berth_Cd = null;
			Plod_Cd = null;
			Matchcode = null;
			Customer_No = null;
			Customer_Name = null;
			Status_Cd = null;
			Movetypecd = null;
			Rev_Cd = null;
			Pcfn = null;
			Edireference = null;
			Transhipmenttype = null;
			Rdd = null;
			Createddate = null;
			Updateddate = null;
		}

		public void CopyFrom(ClsVwArcBookingHeader src)
		{
			Booking_Ocean_ID = src._Booking_Ocean_ID;
			Scac = src._Scac;
			Booking_No = src._Booking_No;
			Alternatenumber = src._Alternatenumber;
			Voyage_No = src._Voyage_No;
			Vessel_Cd = src._Vessel_Cd;
			Vessel_Nm = src._Vessel_Nm;
			Lloyds_Number = src._Lloyds_Number;
			Imo_No = src._Imo_No;
			Ircs = src._Ircs;
			Plor_Cd = src._Plor_Cd;
			Pol_Cd = src._Pol_Cd;
			Pol_Berth_Cd = src._Pol_Berth_Cd;
			Pod_Cd = src._Pod_Cd;
			Pod_Berth_Cd = src._Pod_Berth_Cd;
			Plod_Cd = src._Plod_Cd;
			Matchcode = src._Matchcode;
			Customer_No = src._Customer_No;
			Customer_Name = src._Customer_Name;
			Status_Cd = src._Status_Cd;
			Movetypecd = src._Movetypecd;
			Rev_Cd = src._Rev_Cd;
			Pcfn = src._Pcfn;
			Edireference = src._Edireference;
			Transhipmenttype = src._Transhipmenttype;
			Rdd = src._Rdd;
			Createddate = src._Createddate;
			Updateddate = src._Updateddate;
		}

		public override bool ReloadFromDB()
		{
			ClsVwArcBookingHeader tmp = null;	//No primary key can't refresh;
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

			DbParameter[] p = new DbParameter[28];

			p[0] = Connection.GetParameter
				("@booking_ocean_id", Booking_Ocean_ID);
			p[1] = Connection.GetParameter
				("@scac", Scac);
			p[2] = Connection.GetParameter
				("@booking_no", Booking_No);
			p[3] = Connection.GetParameter
				("@AlternateNumber", Alternatenumber);
			p[4] = Connection.GetParameter
				("@voyage_no", Voyage_No);
			p[5] = Connection.GetParameter
				("@vessel_cd", Vessel_Cd);
			p[6] = Connection.GetParameter
				("@vessel_nm", Vessel_Nm);
			p[7] = Connection.GetParameter
				("@lloyds_number", Lloyds_Number);
			p[8] = Connection.GetParameter
				("@IMO_no", Imo_No);
			p[9] = Connection.GetParameter
				("@ircs", Ircs);
			p[10] = Connection.GetParameter
				("@plor_cd", Plor_Cd);
			p[11] = Connection.GetParameter
				("@pol_cd", Pol_Cd);
			p[12] = Connection.GetParameter
				("@pol_berth_cd", Pol_Berth_Cd);
			p[13] = Connection.GetParameter
				("@pod_cd", Pod_Cd);
			p[14] = Connection.GetParameter
				("@pod_berth_cd", Pod_Berth_Cd);
			p[15] = Connection.GetParameter
				("@plod_cd", Plod_Cd);
			p[16] = Connection.GetParameter
				("@MatchCode", Matchcode);
			p[17] = Connection.GetParameter
				("@Customer_No", Customer_No);
			p[18] = Connection.GetParameter
				("@customer_name", Customer_Name);
			p[19] = Connection.GetParameter
				("@status_cd", Status_Cd);
			p[20] = Connection.GetParameter
				("@MoveTypeCd", Movetypecd);
			p[21] = Connection.GetParameter
				("@Rev_cd", Rev_Cd);
			p[22] = Connection.GetParameter
				("@pcfn", Pcfn);
			p[23] = Connection.GetParameter
				("@EdiReference", Edireference);
			p[24] = Connection.GetParameter
				("@TranshipmentType", Transhipmenttype);
			p[25] = Connection.GetParameter
				("@rdd", Rdd);
			p[26] = Connection.GetParameter
				("@CreatedDate", Createddate);
			p[27] = Connection.GetParameter
				("@UpdatedDate", Updateddate);

			const string sql = @"INSERT INTO vw_arc_booking_header VALUES
				(@booking_ocean_id,@scac,@booking_no
				,@AlternateNumber,@voyage_no,@vessel_cd
				,@vessel_nm,@lloyds_number,@IMO_no
				,@ircs,@plor_cd,@pol_cd
				,@pol_berth_cd,@pod_cd,@pod_berth_cd
				,@plod_cd,@MatchCode,@Customer_No
				,@customer_name,@status_cd,@MoveTypeCd
				,@Rev_cd,@pcfn,@EdiReference
				,@TranshipmentType,@rdd,@CreatedDate
				,@UpdatedDate)";
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

			Booking_Ocean_ID = ClsConvert.ToInt32Nullable(dr["booking_ocean_id"]);
			Scac = ClsConvert.ToString(dr["scac"]);
			Booking_No = ClsConvert.ToString(dr["booking_no"]);
			Alternatenumber = ClsConvert.ToString(dr["AlternateNumber"]);
			Voyage_No = ClsConvert.ToString(dr["voyage_no"]);
			Vessel_Cd = ClsConvert.ToString(dr["vessel_cd"]);
			Vessel_Nm = ClsConvert.ToString(dr["vessel_nm"]);
			Lloyds_Number = ClsConvert.ToString(dr["lloyds_number"]);
			Imo_No = ClsConvert.ToString(dr["IMO_no"]);
			Ircs = ClsConvert.ToString(dr["ircs"]);
			Plor_Cd = ClsConvert.ToString(dr["plor_cd"]);
			Pol_Cd = ClsConvert.ToString(dr["pol_cd"]);
			Pol_Berth_Cd = ClsConvert.ToString(dr["pol_berth_cd"]);
			Pod_Cd = ClsConvert.ToString(dr["pod_cd"]);
			Pod_Berth_Cd = ClsConvert.ToString(dr["pod_berth_cd"]);
			Plod_Cd = ClsConvert.ToString(dr["plod_cd"]);
			Matchcode = ClsConvert.ToString(dr["MatchCode"]);
			Customer_No = ClsConvert.ToString(dr["Customer_No"]);
			Customer_Name = ClsConvert.ToString(dr["customer_name"]);
			Status_Cd = ClsConvert.ToString(dr["status_cd"]);
			Movetypecd = ClsConvert.ToString(dr["MoveTypeCd"]);
			Rev_Cd = ClsConvert.ToString(dr["Rev_cd"]);
			Pcfn = ClsConvert.ToString(dr["pcfn"]);
			Edireference = ClsConvert.ToString(dr["EdiReference"]);
			Transhipmenttype = ClsConvert.ToInt32Nullable(dr["TranshipmentType"]);
			Rdd = ClsConvert.ToString(dr["rdd"]);
			Createddate = ClsConvert.ToString(dr["CreatedDate"]);
			Updateddate = ClsConvert.ToString(dr["UpdatedDate"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Booking_Ocean_ID = ClsConvert.ToInt32Nullable(dr["booking_ocean_id", v]);
			Scac = ClsConvert.ToString(dr["scac", v]);
			Booking_No = ClsConvert.ToString(dr["booking_no", v]);
			Alternatenumber = ClsConvert.ToString(dr["AlternateNumber", v]);
			Voyage_No = ClsConvert.ToString(dr["voyage_no", v]);
			Vessel_Cd = ClsConvert.ToString(dr["vessel_cd", v]);
			Vessel_Nm = ClsConvert.ToString(dr["vessel_nm", v]);
			Lloyds_Number = ClsConvert.ToString(dr["lloyds_number", v]);
			Imo_No = ClsConvert.ToString(dr["IMO_no", v]);
			Ircs = ClsConvert.ToString(dr["ircs", v]);
			Plor_Cd = ClsConvert.ToString(dr["plor_cd", v]);
			Pol_Cd = ClsConvert.ToString(dr["pol_cd", v]);
			Pol_Berth_Cd = ClsConvert.ToString(dr["pol_berth_cd", v]);
			Pod_Cd = ClsConvert.ToString(dr["pod_cd", v]);
			Pod_Berth_Cd = ClsConvert.ToString(dr["pod_berth_cd", v]);
			Plod_Cd = ClsConvert.ToString(dr["plod_cd", v]);
			Matchcode = ClsConvert.ToString(dr["MatchCode", v]);
			Customer_No = ClsConvert.ToString(dr["Customer_No", v]);
			Customer_Name = ClsConvert.ToString(dr["customer_name", v]);
			Status_Cd = ClsConvert.ToString(dr["status_cd", v]);
			Movetypecd = ClsConvert.ToString(dr["MoveTypeCd", v]);
			Rev_Cd = ClsConvert.ToString(dr["Rev_cd", v]);
			Pcfn = ClsConvert.ToString(dr["pcfn", v]);
			Edireference = ClsConvert.ToString(dr["EdiReference", v]);
			Transhipmenttype = ClsConvert.ToInt32Nullable(dr["TranshipmentType", v]);
			Rdd = ClsConvert.ToString(dr["rdd", v]);
			Createddate = ClsConvert.ToString(dr["CreatedDate", v]);
			Updateddate = ClsConvert.ToString(dr["UpdatedDate", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["booking_ocean_id"] = ClsConvert.ToDbObject(Booking_Ocean_ID);
			dr["scac"] = ClsConvert.ToDbObject(Scac);
			dr["booking_no"] = ClsConvert.ToDbObject(Booking_No);
			dr["AlternateNumber"] = ClsConvert.ToDbObject(Alternatenumber);
			dr["voyage_no"] = ClsConvert.ToDbObject(Voyage_No);
			dr["vessel_cd"] = ClsConvert.ToDbObject(Vessel_Cd);
			dr["vessel_nm"] = ClsConvert.ToDbObject(Vessel_Nm);
			dr["lloyds_number"] = ClsConvert.ToDbObject(Lloyds_Number);
			dr["IMO_no"] = ClsConvert.ToDbObject(Imo_No);
			dr["ircs"] = ClsConvert.ToDbObject(Ircs);
			dr["plor_cd"] = ClsConvert.ToDbObject(Plor_Cd);
			dr["pol_cd"] = ClsConvert.ToDbObject(Pol_Cd);
			dr["pol_berth_cd"] = ClsConvert.ToDbObject(Pol_Berth_Cd);
			dr["pod_cd"] = ClsConvert.ToDbObject(Pod_Cd);
			dr["pod_berth_cd"] = ClsConvert.ToDbObject(Pod_Berth_Cd);
			dr["plod_cd"] = ClsConvert.ToDbObject(Plod_Cd);
			dr["MatchCode"] = ClsConvert.ToDbObject(Matchcode);
			dr["Customer_No"] = ClsConvert.ToDbObject(Customer_No);
			dr["customer_name"] = ClsConvert.ToDbObject(Customer_Name);
			dr["status_cd"] = ClsConvert.ToDbObject(Status_Cd);
			dr["MoveTypeCd"] = ClsConvert.ToDbObject(Movetypecd);
			dr["Rev_cd"] = ClsConvert.ToDbObject(Rev_Cd);
			dr["pcfn"] = ClsConvert.ToDbObject(Pcfn);
			dr["EdiReference"] = ClsConvert.ToDbObject(Edireference);
			dr["TranshipmentType"] = ClsConvert.ToDbObject(Transhipmenttype);
			dr["rdd"] = ClsConvert.ToDbObject(Rdd);
			dr["CreatedDate"] = ClsConvert.ToDbObject(Createddate);
			dr["UpdatedDate"] = ClsConvert.ToDbObject(Updateddate);
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