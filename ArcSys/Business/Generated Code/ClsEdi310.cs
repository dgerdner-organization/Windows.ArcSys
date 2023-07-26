using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsEdi310 : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ArcSys"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "T_EDI310";
		public const int PrimaryKeyCount = 1;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] { "EDI310_ID" };
		}

		public const string SelectSQL = @"SELECT * FROM T_EDI310 
				LEFT OUTER JOIN T_ISA
				ON T_EDI310.ISA_ID=T_ISA.ISA_ID ";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Create_UserMax = 30;
		public const int Modify_UserMax = 30;
		public const int Bol_NoMax = 30;
		public const int Booking_NoMax = 30;
		public const int Voyage_NoMax = 10;
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
		public const int Move_Type_CdMax = 5;
		public const int Pod_Location_CdMax = 10;
		public const int Pol_Location_CdMax = 10;
		public const int Processed_FlgMax = 1;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected Int64? _Edi310_ID;
		protected Int64? _Isa_ID;
		protected DateTime? _Create_Dt;
		protected string _Create_User;
		protected DateTime? _Modify_Dt;
		protected string _Modify_User;
		protected Int64? _Isa_Nbr;
		protected string _Bol_No;
		protected string _Booking_No;
		protected string _Voyage_No;
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
		protected DateTime? _Rdd_Dt;
		protected string _Move_Type_Cd;
		protected string _Pod_Location_Cd;
		protected string _Pol_Location_Cd;
		protected string _Processed_Flg;

		#endregion	// #region Column Fields

		#region Column Properties

		public Int64? Edi310_ID
		{
			get { return _Edi310_ID; }
			set
			{
				if( _Edi310_ID == value ) return;
		
				_Edi310_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Edi310_ID");
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

		public ClsEdi310() : base() {}
		public ClsEdi310(DataRow dr) : base(dr) {}
		public ClsEdi310(ClsEdi310 src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Edi310_ID = null;
			Isa_ID = null;
			Create_Dt = null;
			Create_User = null;
			Modify_Dt = null;
			Modify_User = null;
			Isa_Nbr = null;
			Bol_No = null;
			Booking_No = null;
			Voyage_No = null;
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
			Rdd_Dt = null;
			Move_Type_Cd = null;
			Pod_Location_Cd = null;
			Pol_Location_Cd = null;
			Processed_Flg = null;
		}

		public void CopyFrom(ClsEdi310 src)
		{
			Edi310_ID = src._Edi310_ID;
			Isa_ID = src._Isa_ID;
			Create_Dt = src._Create_Dt;
			Create_User = src._Create_User;
			Modify_Dt = src._Modify_Dt;
			Modify_User = src._Modify_User;
			Isa_Nbr = src._Isa_Nbr;
			Bol_No = src._Bol_No;
			Booking_No = src._Booking_No;
			Voyage_No = src._Voyage_No;
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
			Rdd_Dt = src._Rdd_Dt;
			Move_Type_Cd = src._Move_Type_Cd;
			Pod_Location_Cd = src._Pod_Location_Cd;
			Pol_Location_Cd = src._Pol_Location_Cd;
			Processed_Flg = src._Processed_Flg;
		}

		public override bool ReloadFromDB()
		{
			ClsEdi310 tmp = ClsEdi310.GetUsingKey(Edi310_ID.Value);
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
				("@EDI310_ID", Edi310_ID);
			p[1] = Connection.GetParameter
				("@ISA_ID", Isa_ID);
			p[2] = Connection.GetParameter
				("@ISA_NBR", Isa_Nbr);
			p[3] = Connection.GetParameter
				("@BOL_NO", Bol_No);
			p[4] = Connection.GetParameter
				("@BOOKING_NO", Booking_No);
			p[5] = Connection.GetParameter
				("@VOYAGE_NO", Voyage_No);
			p[6] = Connection.GetParameter
				("@VESSEL_QUALIFIER", Vessel_Qualifier);
			p[7] = Connection.GetParameter
				("@VESSEL_CD", Vessel_Cd);
			p[8] = Connection.GetParameter
				("@VESSEL_DSC", Vessel_Dsc);
			p[9] = Connection.GetParameter
				("@PARTNER_VOYAGE_NO", Partner_Voyage_No);
			p[10] = Connection.GetParameter
				("@SAIL_DT", Sail_Dt);
			p[11] = Connection.GetParameter
				("@POL_QUALIFIER", Pol_Qualifier);
			p[12] = Connection.GetParameter
				("@POL_CD", Pol_Cd);
			p[13] = Connection.GetParameter
				("@POL_DSC", Pol_Dsc);
			p[14] = Connection.GetParameter
				("@POD_QUALIFIER", Pod_Qualifier);
			p[15] = Connection.GetParameter
				("@POD_CD", Pod_Cd);
			p[16] = Connection.GetParameter
				("@POD_DSC", Pod_Dsc);
			p[17] = Connection.GetParameter
				("@RDD_DT", Rdd_Dt);
			p[18] = Connection.GetParameter
				("@MOVE_TYPE_CD", Move_Type_Cd);
			p[19] = Connection.GetParameter
				("@POD_LOCATION_CD", Pod_Location_Cd);
			p[20] = Connection.GetParameter
				("@POL_LOCATION_CD", Pol_Location_Cd);
			p[21] = Connection.GetParameter
				("@PROCESSED_FLG", Processed_Flg);
			p[22] = Connection.GetParameter
				("@CREATE_DT", Create_Dt, ParameterDirection.Output, DbType.DateTime, 0);
			p[23] = Connection.GetParameter
				("@CREATE_USER", Create_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Create_UserMax);
			p[24] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.Output, DbType.DateTime, 0);
			p[25] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);

			const string sql = @"
				INSERT INTO T_EDI310
					(EDI310_ID, ISA_ID, ISA_NBR,
					BOL_NO, BOOKING_NO, VOYAGE_NO,
					VESSEL_QUALIFIER, VESSEL_CD, VESSEL_DSC,
					PARTNER_VOYAGE_NO, SAIL_DT, POL_QUALIFIER,
					POL_CD, POL_DSC, POD_QUALIFIER,
					POD_CD, POD_DSC, RDD_DT,
					MOVE_TYPE_CD, POD_LOCATION_CD, POL_LOCATION_CD,
					PROCESSED_FLG)
				VALUES
					(@EDI310_ID, @ISA_ID, @ISA_NBR,
					@BOL_NO, @BOOKING_NO, @VOYAGE_NO,
					@VESSEL_QUALIFIER, @VESSEL_CD, @VESSEL_DSC,
					@PARTNER_VOYAGE_NO, @SAIL_DT, @POL_QUALIFIER,
					@POL_CD, @POL_DSC, @POD_QUALIFIER,
					@POD_CD, @POD_DSC, @RDD_DT,
					@MOVE_TYPE_CD, @POD_LOCATION_CD, @POL_LOCATION_CD,
					@PROCESSED_FLG)
				RETURNING
					CREATE_DT, CREATE_USER, MODIFY_DT,
					MODIFY_USER
				INTO
					@CREATE_DT, @CREATE_USER, @MODIFY_DT,
					@MODIFY_USER";
			int ret = Connection.RunSQL(sql, p);

			Create_Dt = ClsConvert.ToDateTimeNullable(p[22].Value);
			Create_User = ClsConvert.ToString(p[23].Value);
			Modify_Dt = ClsConvert.ToDateTimeNullable(p[24].Value);
			Modify_User = ClsConvert.ToString(p[25].Value);
			return ret;
		}
		public override int Update()
		{
			DbParameter[] p = new DbParameter[24];

			p[0] = Connection.GetParameter
				("@ISA_ID", Isa_ID);
			p[1] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.InputOutput, DbType.DateTime, 0);
			p[2] = Connection.GetParameter
				("@ISA_NBR", Isa_Nbr);
			p[3] = Connection.GetParameter
				("@BOL_NO", Bol_No);
			p[4] = Connection.GetParameter
				("@BOOKING_NO", Booking_No);
			p[5] = Connection.GetParameter
				("@VOYAGE_NO", Voyage_No);
			p[6] = Connection.GetParameter
				("@VESSEL_QUALIFIER", Vessel_Qualifier);
			p[7] = Connection.GetParameter
				("@VESSEL_CD", Vessel_Cd);
			p[8] = Connection.GetParameter
				("@VESSEL_DSC", Vessel_Dsc);
			p[9] = Connection.GetParameter
				("@PARTNER_VOYAGE_NO", Partner_Voyage_No);
			p[10] = Connection.GetParameter
				("@SAIL_DT", Sail_Dt);
			p[11] = Connection.GetParameter
				("@POL_QUALIFIER", Pol_Qualifier);
			p[12] = Connection.GetParameter
				("@POL_CD", Pol_Cd);
			p[13] = Connection.GetParameter
				("@POL_DSC", Pol_Dsc);
			p[14] = Connection.GetParameter
				("@POD_QUALIFIER", Pod_Qualifier);
			p[15] = Connection.GetParameter
				("@POD_CD", Pod_Cd);
			p[16] = Connection.GetParameter
				("@POD_DSC", Pod_Dsc);
			p[17] = Connection.GetParameter
				("@RDD_DT", Rdd_Dt);
			p[18] = Connection.GetParameter
				("@MOVE_TYPE_CD", Move_Type_Cd);
			p[19] = Connection.GetParameter
				("@POD_LOCATION_CD", Pod_Location_Cd);
			p[20] = Connection.GetParameter
				("@POL_LOCATION_CD", Pol_Location_Cd);
			p[21] = Connection.GetParameter
				("@PROCESSED_FLG", Processed_Flg);
			p[22] = Connection.GetParameter
				("@EDI310_ID", Edi310_ID);
			p[23] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);

			const string sql = @"
				UPDATE T_EDI310 SET
					ISA_ID = @ISA_ID,
					MODIFY_DT = @MODIFY_DT,
					ISA_NBR = @ISA_NBR,
					BOL_NO = @BOL_NO,
					BOOKING_NO = @BOOKING_NO,
					VOYAGE_NO = @VOYAGE_NO,
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
					RDD_DT = @RDD_DT,
					MOVE_TYPE_CD = @MOVE_TYPE_CD,
					POD_LOCATION_CD = @POD_LOCATION_CD,
					POL_LOCATION_CD = @POL_LOCATION_CD,
					PROCESSED_FLG = @PROCESSED_FLG
				WHERE
					EDI310_ID = @EDI310_ID
				RETURNING
					MODIFY_DT, MODIFY_USER
				INTO
					@MODIFY_DT, @MODIFY_USER";
			int ret = Connection.RunSQL(sql, p);

			Modify_Dt = ClsConvert.ToDateTimeNullable(p[1].Value);
			Modify_User = ClsConvert.ToString(p[23].Value);
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

			Edi310_ID = ClsConvert.ToInt64Nullable(dr["EDI310_ID"]);
			Isa_ID = ClsConvert.ToInt64Nullable(dr["ISA_ID"]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT"]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER"]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT"]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER"]);
			Isa_Nbr = ClsConvert.ToInt64Nullable(dr["ISA_NBR"]);
			Bol_No = ClsConvert.ToString(dr["BOL_NO"]);
			Booking_No = ClsConvert.ToString(dr["BOOKING_NO"]);
			Voyage_No = ClsConvert.ToString(dr["VOYAGE_NO"]);
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
			Rdd_Dt = ClsConvert.ToDateTimeNullable(dr["RDD_DT"]);
			Move_Type_Cd = ClsConvert.ToString(dr["MOVE_TYPE_CD"]);
			Pod_Location_Cd = ClsConvert.ToString(dr["POD_LOCATION_CD"]);
			Pol_Location_Cd = ClsConvert.ToString(dr["POL_LOCATION_CD"]);
			Processed_Flg = ClsConvert.ToString(dr["PROCESSED_FLG"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Edi310_ID = ClsConvert.ToInt64Nullable(dr["EDI310_ID", v]);
			Isa_ID = ClsConvert.ToInt64Nullable(dr["ISA_ID", v]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT", v]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER", v]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT", v]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER", v]);
			Isa_Nbr = ClsConvert.ToInt64Nullable(dr["ISA_NBR", v]);
			Bol_No = ClsConvert.ToString(dr["BOL_NO", v]);
			Booking_No = ClsConvert.ToString(dr["BOOKING_NO", v]);
			Voyage_No = ClsConvert.ToString(dr["VOYAGE_NO", v]);
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
			Rdd_Dt = ClsConvert.ToDateTimeNullable(dr["RDD_DT", v]);
			Move_Type_Cd = ClsConvert.ToString(dr["MOVE_TYPE_CD", v]);
			Pod_Location_Cd = ClsConvert.ToString(dr["POD_LOCATION_CD", v]);
			Pol_Location_Cd = ClsConvert.ToString(dr["POL_LOCATION_CD", v]);
			Processed_Flg = ClsConvert.ToString(dr["PROCESSED_FLG", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["EDI310_ID"] = ClsConvert.ToDbObject(Edi310_ID);
			dr["ISA_ID"] = ClsConvert.ToDbObject(Isa_ID);
			dr["CREATE_DT"] = ClsConvert.ToDbObject(Create_Dt);
			dr["CREATE_USER"] = ClsConvert.ToDbObject(Create_User);
			dr["MODIFY_DT"] = ClsConvert.ToDbObject(Modify_Dt);
			dr["MODIFY_USER"] = ClsConvert.ToDbObject(Modify_User);
			dr["ISA_NBR"] = ClsConvert.ToDbObject(Isa_Nbr);
			dr["BOL_NO"] = ClsConvert.ToDbObject(Bol_No);
			dr["BOOKING_NO"] = ClsConvert.ToDbObject(Booking_No);
			dr["VOYAGE_NO"] = ClsConvert.ToDbObject(Voyage_No);
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
			dr["RDD_DT"] = ClsConvert.ToDbObject(Rdd_Dt);
			dr["MOVE_TYPE_CD"] = ClsConvert.ToDbObject(Move_Type_Cd);
			dr["POD_LOCATION_CD"] = ClsConvert.ToDbObject(Pod_Location_Cd);
			dr["POL_LOCATION_CD"] = ClsConvert.ToDbObject(Pol_Location_Cd);
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

		public static ClsEdi310 GetUsingKey(Int64 Edi310_ID)
		{
			object[] vals = new object[] {Edi310_ID};
			DataRow dr = Connection.GetDataRowUsingKey
				(TableName, GetPrimaryKeys(), vals);
			return ( dr == null ) ? null : new ClsEdi310(dr);
		}
		public static DataTable GetAll(Int64? Isa_ID)
		{
			List<DbParameter> lst = new List<DbParameter>();	
			StringBuilder sb = new StringBuilder();
		
			if( Isa_ID != null && Isa_ID > 0 )
			{
				lst.Add(Connection.GetParameter("@ISA_ID", Isa_ID));
				sb.Append(" WHERE T_EDI310.ISA_ID=@ISA_ID");
			}
			sb.Insert(0, SelectSQL);
			return Connection.GetDataTable(sb.ToString(), lst.ToArray());
		}
		#endregion		// #region Static Methods
	}
}