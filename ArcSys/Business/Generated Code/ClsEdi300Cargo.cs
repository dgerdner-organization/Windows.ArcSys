using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsEdi300Cargo : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ArcSys"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "T_EDI300_CARGO";
		public const int PrimaryKeyCount = 1;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] { "EDI300_CARGO_ID" };
		}

		public const string SelectSQL = @"SELECT * FROM T_EDI300_CARGO 
				LEFT OUTER JOIN T_EDI300
				ON T_EDI300_CARGO.EDI300_ID=T_EDI300.EDI300_ID ";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Create_UserMax = 30;
		public const int Modify_UserMax = 30;
		public const int Wt_QualifierMax = 2;
		public const int Volume_QualifierMax = 2;
		public const int Packaging_Form_CdMax = 5;
		public const int Wt_Unit_CdMax = 2;
		public const int Item_DscMax = 50;
		public const int Commodity_CdMax = 30;
		public const int Commodity_QualifierMax = 2;
		public const int Type_Pack_CdMax = 3;
		public const int TcnMax = 30;
		public const int Measure_Unit_QualifierMax = 2;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected Int64? _Edi300_Cargo_ID;
		protected Int64? _Edi300_ID;
		protected DateTime? _Create_Dt;
		protected string _Create_User;
		protected DateTime? _Modify_Dt;
		protected string _Modify_User;
		protected decimal? _Item_No;
		protected decimal? _Wt_Nbr;
		protected string _Wt_Qualifier;
		protected decimal? _Volume_Nbr;
		protected string _Volume_Qualifier;
		protected decimal? _Lading_Qty_Nbr;
		protected string _Packaging_Form_Cd;
		protected string _Wt_Unit_Cd;
		protected string _Item_Dsc;
		protected string _Commodity_Cd;
		protected string _Commodity_Qualifier;
		protected string _Type_Pack_Cd;
		protected string _Tcn;
		protected decimal? _Length_Nbr;
		protected decimal? _Width_Nbr;
		protected decimal? _Height_Nbr;
		protected string _Measure_Unit_Qualifier;
		protected decimal? _Units_Nbr;

		#endregion	// #region Column Fields

		#region Column Properties

		public Int64? Edi300_Cargo_ID
		{
			get { return _Edi300_Cargo_ID; }
			set
			{
				if( _Edi300_Cargo_ID == value ) return;
		
				_Edi300_Cargo_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Edi300_Cargo_ID");
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
		public decimal? Wt_Nbr
		{
			get { return _Wt_Nbr; }
			set
			{
				if( _Wt_Nbr == value ) return;
		
				_Wt_Nbr = value;
				_IsDirty = true;
				NotifyPropertyChanged("Wt_Nbr");
			}
		}
		public string Wt_Qualifier
		{
			get { return _Wt_Qualifier; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Wt_Qualifier, val, false) == 0 ) return;
		
				if( val != null && val.Length > Wt_QualifierMax )
					_Wt_Qualifier = val.Substring(0, (int)Wt_QualifierMax);
				else
					_Wt_Qualifier = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Wt_Qualifier");
			}
		}
		public decimal? Volume_Nbr
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
		public decimal? Lading_Qty_Nbr
		{
			get { return _Lading_Qty_Nbr; }
			set
			{
				if( _Lading_Qty_Nbr == value ) return;
		
				_Lading_Qty_Nbr = value;
				_IsDirty = true;
				NotifyPropertyChanged("Lading_Qty_Nbr");
			}
		}
		public string Packaging_Form_Cd
		{
			get { return _Packaging_Form_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Packaging_Form_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Packaging_Form_CdMax )
					_Packaging_Form_Cd = val.Substring(0, (int)Packaging_Form_CdMax);
				else
					_Packaging_Form_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Packaging_Form_Cd");
			}
		}
		public string Wt_Unit_Cd
		{
			get { return _Wt_Unit_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Wt_Unit_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Wt_Unit_CdMax )
					_Wt_Unit_Cd = val.Substring(0, (int)Wt_Unit_CdMax);
				else
					_Wt_Unit_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Wt_Unit_Cd");
			}
		}
		public string Item_Dsc
		{
			get { return _Item_Dsc; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Item_Dsc, val, false) == 0 ) return;
		
				if( val != null && val.Length > Item_DscMax )
					_Item_Dsc = val.Substring(0, (int)Item_DscMax);
				else
					_Item_Dsc = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Item_Dsc");
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
		public string Commodity_Qualifier
		{
			get { return _Commodity_Qualifier; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Commodity_Qualifier, val, false) == 0 ) return;
		
				if( val != null && val.Length > Commodity_QualifierMax )
					_Commodity_Qualifier = val.Substring(0, (int)Commodity_QualifierMax);
				else
					_Commodity_Qualifier = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Commodity_Qualifier");
			}
		}
		public string Type_Pack_Cd
		{
			get { return _Type_Pack_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Type_Pack_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Type_Pack_CdMax )
					_Type_Pack_Cd = val.Substring(0, (int)Type_Pack_CdMax);
				else
					_Type_Pack_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Type_Pack_Cd");
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
		public decimal? Length_Nbr
		{
			get { return _Length_Nbr; }
			set
			{
				if( _Length_Nbr == value ) return;
		
				_Length_Nbr = value;
				_IsDirty = true;
				NotifyPropertyChanged("Length_Nbr");
			}
		}
		public decimal? Width_Nbr
		{
			get { return _Width_Nbr; }
			set
			{
				if( _Width_Nbr == value ) return;
		
				_Width_Nbr = value;
				_IsDirty = true;
				NotifyPropertyChanged("Width_Nbr");
			}
		}
		public decimal? Height_Nbr
		{
			get { return _Height_Nbr; }
			set
			{
				if( _Height_Nbr == value ) return;
		
				_Height_Nbr = value;
				_IsDirty = true;
				NotifyPropertyChanged("Height_Nbr");
			}
		}
		public string Measure_Unit_Qualifier
		{
			get { return _Measure_Unit_Qualifier; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Measure_Unit_Qualifier, val, false) == 0 ) return;
		
				if( val != null && val.Length > Measure_Unit_QualifierMax )
					_Measure_Unit_Qualifier = val.Substring(0, (int)Measure_Unit_QualifierMax);
				else
					_Measure_Unit_Qualifier = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Measure_Unit_Qualifier");
			}
		}
		public decimal? Units_Nbr
		{
			get { return _Units_Nbr; }
			set
			{
				if( _Units_Nbr == value ) return;
		
				_Units_Nbr = value;
				_IsDirty = true;
				NotifyPropertyChanged("Units_Nbr");
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

		public ClsEdi300Cargo() : base() {}
		public ClsEdi300Cargo(DataRow dr) : base(dr) {}
		public ClsEdi300Cargo(ClsEdi300Cargo src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Edi300_Cargo_ID = null;
			Edi300_ID = null;
			Create_Dt = null;
			Create_User = null;
			Modify_Dt = null;
			Modify_User = null;
			Item_No = null;
			Wt_Nbr = null;
			Wt_Qualifier = null;
			Volume_Nbr = null;
			Volume_Qualifier = null;
			Lading_Qty_Nbr = null;
			Packaging_Form_Cd = null;
			Wt_Unit_Cd = null;
			Item_Dsc = null;
			Commodity_Cd = null;
			Commodity_Qualifier = null;
			Type_Pack_Cd = null;
			Tcn = null;
			Length_Nbr = null;
			Width_Nbr = null;
			Height_Nbr = null;
			Measure_Unit_Qualifier = null;
			Units_Nbr = null;
		}

		public void CopyFrom(ClsEdi300Cargo src)
		{
			Edi300_Cargo_ID = src._Edi300_Cargo_ID;
			Edi300_ID = src._Edi300_ID;
			Create_Dt = src._Create_Dt;
			Create_User = src._Create_User;
			Modify_Dt = src._Modify_Dt;
			Modify_User = src._Modify_User;
			Item_No = src._Item_No;
			Wt_Nbr = src._Wt_Nbr;
			Wt_Qualifier = src._Wt_Qualifier;
			Volume_Nbr = src._Volume_Nbr;
			Volume_Qualifier = src._Volume_Qualifier;
			Lading_Qty_Nbr = src._Lading_Qty_Nbr;
			Packaging_Form_Cd = src._Packaging_Form_Cd;
			Wt_Unit_Cd = src._Wt_Unit_Cd;
			Item_Dsc = src._Item_Dsc;
			Commodity_Cd = src._Commodity_Cd;
			Commodity_Qualifier = src._Commodity_Qualifier;
			Type_Pack_Cd = src._Type_Pack_Cd;
			Tcn = src._Tcn;
			Length_Nbr = src._Length_Nbr;
			Width_Nbr = src._Width_Nbr;
			Height_Nbr = src._Height_Nbr;
			Measure_Unit_Qualifier = src._Measure_Unit_Qualifier;
			Units_Nbr = src._Units_Nbr;
		}

		public override bool ReloadFromDB()
		{
			ClsEdi300Cargo tmp = ClsEdi300Cargo.GetUsingKey(Edi300_Cargo_ID.Value);
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

			DbParameter[] p = new DbParameter[24];

			p[0] = Connection.GetParameter
				("@EDI300_ID", Edi300_ID);
			p[1] = Connection.GetParameter
				("@ITEM_NO", Item_No);
			p[2] = Connection.GetParameter
				("@WT_NBR", Wt_Nbr);
			p[3] = Connection.GetParameter
				("@WT_QUALIFIER", Wt_Qualifier);
			p[4] = Connection.GetParameter
				("@VOLUME_NBR", Volume_Nbr);
			p[5] = Connection.GetParameter
				("@VOLUME_QUALIFIER", Volume_Qualifier);
			p[6] = Connection.GetParameter
				("@LADING_QTY_NBR", Lading_Qty_Nbr);
			p[7] = Connection.GetParameter
				("@PACKAGING_FORM_CD", Packaging_Form_Cd);
			p[8] = Connection.GetParameter
				("@WT_UNIT_CD", Wt_Unit_Cd);
			p[9] = Connection.GetParameter
				("@ITEM_DSC", Item_Dsc);
			p[10] = Connection.GetParameter
				("@COMMODITY_CD", Commodity_Cd);
			p[11] = Connection.GetParameter
				("@COMMODITY_QUALIFIER", Commodity_Qualifier);
			p[12] = Connection.GetParameter
				("@TYPE_PACK_CD", Type_Pack_Cd);
			p[13] = Connection.GetParameter
				("@TCN", Tcn);
			p[14] = Connection.GetParameter
				("@LENGTH_NBR", Length_Nbr);
			p[15] = Connection.GetParameter
				("@WIDTH_NBR", Width_Nbr);
			p[16] = Connection.GetParameter
				("@HEIGHT_NBR", Height_Nbr);
			p[17] = Connection.GetParameter
				("@MEASURE_UNIT_QUALIFIER", Measure_Unit_Qualifier);
			p[18] = Connection.GetParameter
				("@UNITS_NBR", Units_Nbr);
			p[19] = Connection.GetParameter
				("@EDI300_CARGO_ID", Edi300_Cargo_ID, ParameterDirection.Output, DbType.Int64, 0);
			p[20] = Connection.GetParameter
				("@CREATE_DT", Create_Dt, ParameterDirection.Output, DbType.DateTime, 0);
			p[21] = Connection.GetParameter
				("@CREATE_USER", Create_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Create_UserMax);
			p[22] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.Output, DbType.DateTime, 0);
			p[23] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);

			const string sql = @"
				INSERT INTO T_EDI300_CARGO
					(EDI300_CARGO_ID, EDI300_ID, ITEM_NO,
					WT_NBR, WT_QUALIFIER, VOLUME_NBR,
					VOLUME_QUALIFIER, LADING_QTY_NBR, PACKAGING_FORM_CD,
					WT_UNIT_CD, ITEM_DSC, COMMODITY_CD,
					COMMODITY_QUALIFIER, TYPE_PACK_CD, TCN,
					LENGTH_NBR, WIDTH_NBR, HEIGHT_NBR,
					MEASURE_UNIT_QUALIFIER, UNITS_NBR)
				VALUES
					(EDI300_CARGO_ID_SEQ.NEXTVAL, @EDI300_ID, @ITEM_NO,
					@WT_NBR, @WT_QUALIFIER, @VOLUME_NBR,
					@VOLUME_QUALIFIER, @LADING_QTY_NBR, @PACKAGING_FORM_CD,
					@WT_UNIT_CD, @ITEM_DSC, @COMMODITY_CD,
					@COMMODITY_QUALIFIER, @TYPE_PACK_CD, @TCN,
					@LENGTH_NBR, @WIDTH_NBR, @HEIGHT_NBR,
					@MEASURE_UNIT_QUALIFIER, @UNITS_NBR)
				RETURNING
					EDI300_CARGO_ID, CREATE_DT, CREATE_USER,
					MODIFY_DT, MODIFY_USER
				INTO
					@EDI300_CARGO_ID, @CREATE_DT, @CREATE_USER,
					@MODIFY_DT, @MODIFY_USER";
			int ret = Connection.RunSQL(sql, p);

			Edi300_Cargo_ID = ClsConvert.ToInt64Nullable(p[19].Value);
			Create_Dt = ClsConvert.ToDateTimeNullable(p[20].Value);
			Create_User = ClsConvert.ToString(p[21].Value);
			Modify_Dt = ClsConvert.ToDateTimeNullable(p[22].Value);
			Modify_User = ClsConvert.ToString(p[23].Value);
			return ret;
		}
		public override int Update()
		{
			DbParameter[] p = new DbParameter[22];

			p[0] = Connection.GetParameter
				("@EDI300_ID", Edi300_ID);
			p[1] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.InputOutput, DbType.DateTime, 0);
			p[2] = Connection.GetParameter
				("@ITEM_NO", Item_No);
			p[3] = Connection.GetParameter
				("@WT_NBR", Wt_Nbr);
			p[4] = Connection.GetParameter
				("@WT_QUALIFIER", Wt_Qualifier);
			p[5] = Connection.GetParameter
				("@VOLUME_NBR", Volume_Nbr);
			p[6] = Connection.GetParameter
				("@VOLUME_QUALIFIER", Volume_Qualifier);
			p[7] = Connection.GetParameter
				("@LADING_QTY_NBR", Lading_Qty_Nbr);
			p[8] = Connection.GetParameter
				("@PACKAGING_FORM_CD", Packaging_Form_Cd);
			p[9] = Connection.GetParameter
				("@WT_UNIT_CD", Wt_Unit_Cd);
			p[10] = Connection.GetParameter
				("@ITEM_DSC", Item_Dsc);
			p[11] = Connection.GetParameter
				("@COMMODITY_CD", Commodity_Cd);
			p[12] = Connection.GetParameter
				("@COMMODITY_QUALIFIER", Commodity_Qualifier);
			p[13] = Connection.GetParameter
				("@TYPE_PACK_CD", Type_Pack_Cd);
			p[14] = Connection.GetParameter
				("@TCN", Tcn);
			p[15] = Connection.GetParameter
				("@LENGTH_NBR", Length_Nbr);
			p[16] = Connection.GetParameter
				("@WIDTH_NBR", Width_Nbr);
			p[17] = Connection.GetParameter
				("@HEIGHT_NBR", Height_Nbr);
			p[18] = Connection.GetParameter
				("@MEASURE_UNIT_QUALIFIER", Measure_Unit_Qualifier);
			p[19] = Connection.GetParameter
				("@UNITS_NBR", Units_Nbr);
			p[20] = Connection.GetParameter
				("@EDI300_CARGO_ID", Edi300_Cargo_ID);
			p[21] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);

			const string sql = @"
				UPDATE T_EDI300_CARGO SET
					EDI300_ID = @EDI300_ID,
					MODIFY_DT = @MODIFY_DT,
					ITEM_NO = @ITEM_NO,
					WT_NBR = @WT_NBR,
					WT_QUALIFIER = @WT_QUALIFIER,
					VOLUME_NBR = @VOLUME_NBR,
					VOLUME_QUALIFIER = @VOLUME_QUALIFIER,
					LADING_QTY_NBR = @LADING_QTY_NBR,
					PACKAGING_FORM_CD = @PACKAGING_FORM_CD,
					WT_UNIT_CD = @WT_UNIT_CD,
					ITEM_DSC = @ITEM_DSC,
					COMMODITY_CD = @COMMODITY_CD,
					COMMODITY_QUALIFIER = @COMMODITY_QUALIFIER,
					TYPE_PACK_CD = @TYPE_PACK_CD,
					TCN = @TCN,
					LENGTH_NBR = @LENGTH_NBR,
					WIDTH_NBR = @WIDTH_NBR,
					HEIGHT_NBR = @HEIGHT_NBR,
					MEASURE_UNIT_QUALIFIER = @MEASURE_UNIT_QUALIFIER,
					UNITS_NBR = @UNITS_NBR
				WHERE
					EDI300_CARGO_ID = @EDI300_CARGO_ID
				RETURNING
					MODIFY_DT, MODIFY_USER
				INTO
					@MODIFY_DT, @MODIFY_USER";
			int ret = Connection.RunSQL(sql, p);

			Modify_Dt = ClsConvert.ToDateTimeNullable(p[1].Value);
			Modify_User = ClsConvert.ToString(p[21].Value);
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

			Edi300_Cargo_ID = ClsConvert.ToInt64Nullable(dr["EDI300_CARGO_ID"]);
			Edi300_ID = ClsConvert.ToInt64Nullable(dr["EDI300_ID"]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT"]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER"]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT"]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER"]);
			Item_No = ClsConvert.ToDecimalNullable(dr["ITEM_NO"]);
			Wt_Nbr = ClsConvert.ToDecimalNullable(dr["WT_NBR"]);
			Wt_Qualifier = ClsConvert.ToString(dr["WT_QUALIFIER"]);
			Volume_Nbr = ClsConvert.ToDecimalNullable(dr["VOLUME_NBR"]);
			Volume_Qualifier = ClsConvert.ToString(dr["VOLUME_QUALIFIER"]);
			Lading_Qty_Nbr = ClsConvert.ToDecimalNullable(dr["LADING_QTY_NBR"]);
			Packaging_Form_Cd = ClsConvert.ToString(dr["PACKAGING_FORM_CD"]);
			Wt_Unit_Cd = ClsConvert.ToString(dr["WT_UNIT_CD"]);
			Item_Dsc = ClsConvert.ToString(dr["ITEM_DSC"]);
			Commodity_Cd = ClsConvert.ToString(dr["COMMODITY_CD"]);
			Commodity_Qualifier = ClsConvert.ToString(dr["COMMODITY_QUALIFIER"]);
			Type_Pack_Cd = ClsConvert.ToString(dr["TYPE_PACK_CD"]);
			Tcn = ClsConvert.ToString(dr["TCN"]);
			Length_Nbr = ClsConvert.ToDecimalNullable(dr["LENGTH_NBR"]);
			Width_Nbr = ClsConvert.ToDecimalNullable(dr["WIDTH_NBR"]);
			Height_Nbr = ClsConvert.ToDecimalNullable(dr["HEIGHT_NBR"]);
			Measure_Unit_Qualifier = ClsConvert.ToString(dr["MEASURE_UNIT_QUALIFIER"]);
			Units_Nbr = ClsConvert.ToDecimalNullable(dr["UNITS_NBR"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Edi300_Cargo_ID = ClsConvert.ToInt64Nullable(dr["EDI300_CARGO_ID", v]);
			Edi300_ID = ClsConvert.ToInt64Nullable(dr["EDI300_ID", v]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT", v]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER", v]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT", v]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER", v]);
			Item_No = ClsConvert.ToDecimalNullable(dr["ITEM_NO", v]);
			Wt_Nbr = ClsConvert.ToDecimalNullable(dr["WT_NBR", v]);
			Wt_Qualifier = ClsConvert.ToString(dr["WT_QUALIFIER", v]);
			Volume_Nbr = ClsConvert.ToDecimalNullable(dr["VOLUME_NBR", v]);
			Volume_Qualifier = ClsConvert.ToString(dr["VOLUME_QUALIFIER", v]);
			Lading_Qty_Nbr = ClsConvert.ToDecimalNullable(dr["LADING_QTY_NBR", v]);
			Packaging_Form_Cd = ClsConvert.ToString(dr["PACKAGING_FORM_CD", v]);
			Wt_Unit_Cd = ClsConvert.ToString(dr["WT_UNIT_CD", v]);
			Item_Dsc = ClsConvert.ToString(dr["ITEM_DSC", v]);
			Commodity_Cd = ClsConvert.ToString(dr["COMMODITY_CD", v]);
			Commodity_Qualifier = ClsConvert.ToString(dr["COMMODITY_QUALIFIER", v]);
			Type_Pack_Cd = ClsConvert.ToString(dr["TYPE_PACK_CD", v]);
			Tcn = ClsConvert.ToString(dr["TCN", v]);
			Length_Nbr = ClsConvert.ToDecimalNullable(dr["LENGTH_NBR", v]);
			Width_Nbr = ClsConvert.ToDecimalNullable(dr["WIDTH_NBR", v]);
			Height_Nbr = ClsConvert.ToDecimalNullable(dr["HEIGHT_NBR", v]);
			Measure_Unit_Qualifier = ClsConvert.ToString(dr["MEASURE_UNIT_QUALIFIER", v]);
			Units_Nbr = ClsConvert.ToDecimalNullable(dr["UNITS_NBR", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["EDI300_CARGO_ID"] = ClsConvert.ToDbObject(Edi300_Cargo_ID);
			dr["EDI300_ID"] = ClsConvert.ToDbObject(Edi300_ID);
			dr["CREATE_DT"] = ClsConvert.ToDbObject(Create_Dt);
			dr["CREATE_USER"] = ClsConvert.ToDbObject(Create_User);
			dr["MODIFY_DT"] = ClsConvert.ToDbObject(Modify_Dt);
			dr["MODIFY_USER"] = ClsConvert.ToDbObject(Modify_User);
			dr["ITEM_NO"] = ClsConvert.ToDbObject(Item_No);
			dr["WT_NBR"] = ClsConvert.ToDbObject(Wt_Nbr);
			dr["WT_QUALIFIER"] = ClsConvert.ToDbObject(Wt_Qualifier);
			dr["VOLUME_NBR"] = ClsConvert.ToDbObject(Volume_Nbr);
			dr["VOLUME_QUALIFIER"] = ClsConvert.ToDbObject(Volume_Qualifier);
			dr["LADING_QTY_NBR"] = ClsConvert.ToDbObject(Lading_Qty_Nbr);
			dr["PACKAGING_FORM_CD"] = ClsConvert.ToDbObject(Packaging_Form_Cd);
			dr["WT_UNIT_CD"] = ClsConvert.ToDbObject(Wt_Unit_Cd);
			dr["ITEM_DSC"] = ClsConvert.ToDbObject(Item_Dsc);
			dr["COMMODITY_CD"] = ClsConvert.ToDbObject(Commodity_Cd);
			dr["COMMODITY_QUALIFIER"] = ClsConvert.ToDbObject(Commodity_Qualifier);
			dr["TYPE_PACK_CD"] = ClsConvert.ToDbObject(Type_Pack_Cd);
			dr["TCN"] = ClsConvert.ToDbObject(Tcn);
			dr["LENGTH_NBR"] = ClsConvert.ToDbObject(Length_Nbr);
			dr["WIDTH_NBR"] = ClsConvert.ToDbObject(Width_Nbr);
			dr["HEIGHT_NBR"] = ClsConvert.ToDbObject(Height_Nbr);
			dr["MEASURE_UNIT_QUALIFIER"] = ClsConvert.ToDbObject(Measure_Unit_Qualifier);
			dr["UNITS_NBR"] = ClsConvert.ToDbObject(Units_Nbr);
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

		public static ClsEdi300Cargo GetUsingKey(Int64 Edi300_Cargo_ID)
		{
			object[] vals = new object[] {Edi300_Cargo_ID};
			DataRow dr = Connection.GetDataRowUsingKey
				(TableName, GetPrimaryKeys(), vals);
			return ( dr == null ) ? null : new ClsEdi300Cargo(dr);
		}
		public static DataTable GetAll(Int64? Edi300_ID)
		{
			List<DbParameter> lst = new List<DbParameter>();	
			StringBuilder sb = new StringBuilder();
		
			if( Edi300_ID != null && Edi300_ID > 0 )
			{
				lst.Add(Connection.GetParameter("@EDI300_ID", Edi300_ID));
				sb.Append(" WHERE T_EDI300_CARGO.EDI300_ID=@EDI300_ID");
			}
			sb.Insert(0, SelectSQL);
			return Connection.GetDataTable(sb.ToString(), lst.ToArray());
		}
		#endregion		// #region Static Methods
	}
}