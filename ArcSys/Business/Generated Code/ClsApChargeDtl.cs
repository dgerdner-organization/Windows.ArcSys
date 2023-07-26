using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsApChargeDtl : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ArcSys"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "T_AP_CHARGE_DTL";
		public const int PrimaryKeyCount = 1;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] { "AP_CHARGE_DTL_ID" };
		}

		public const string SelectSQL = @"SELECT * FROM T_AP_CHARGE_DTL 
				INNER JOIN T_AP_INVOICE
				ON T_AP_CHARGE_DTL.AP_INVOICE_ID=T_AP_INVOICE.AP_INVOICE_ID
				INNER JOIN R_LEVEL_UNIT
				ON T_AP_CHARGE_DTL.LEVEL_UNIT_ID=R_LEVEL_UNIT.LEVEL_UNIT_ID
				INNER JOIN R_CHARGE_TYPE
				ON T_AP_CHARGE_DTL.CHARGE_TYPE_CD=R_CHARGE_TYPE.CHARGE_TYPE_CD
				INNER JOIN T_CARGO_ACTIVITY
				ON T_AP_CHARGE_DTL.CARGO_ACTIVITY_ID=T_CARGO_ACTIVITY.CARGO_ACTIVITY_ID ";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Create_UserMax = 30;
		public const int Modify_UserMax = 30;
		public const int Charge_Type_CdMax = 10;
		public const int MemoMax = 50;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected Int64? _Ap_Charge_Dtl_ID;
		protected Int64? _Ap_Invoice_ID;
		protected Int64? _Cargo_Activity_ID;
		protected string _Create_User;
		protected DateTime? _Create_Dt;
		protected string _Modify_User;
		protected DateTime? _Modify_Dt;
		protected decimal? _Activity_Amt;
		protected string _Charge_Type_Cd;
		protected Int64? _Level_Unit_ID;
		protected decimal? _Rate_Amt;
		protected Int64? _Level_Count;
		protected decimal? _Unit_Qty;
		protected decimal? _Total_Amt;
		protected string _Memo;
		protected decimal? _Activity_Unit_Qty;
		protected decimal? _Length_Nbr;
		protected decimal? _Width_Nbr;
		protected decimal? _Height_Nbr;
		protected decimal? _Weight_Nbr;
		protected decimal? _Dim_Weight_Nbr;
		protected decimal? _Cube_Ft;
		protected decimal? _M_Tons;

		#endregion	// #region Column Fields

		#region Column Properties

		public Int64? Ap_Charge_Dtl_ID
		{
			get { return _Ap_Charge_Dtl_ID; }
			set
			{
				if( _Ap_Charge_Dtl_ID == value ) return;
		
				_Ap_Charge_Dtl_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Ap_Charge_Dtl_ID");
			}
		}
		public Int64? Ap_Invoice_ID
		{
			get { return _Ap_Invoice_ID; }
			set
			{
				if( _Ap_Invoice_ID == value ) return;
		
				_Ap_Invoice_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Ap_Invoice_ID");
			}
		}
		public Int64? Cargo_Activity_ID
		{
			get { return _Cargo_Activity_ID; }
			set
			{
				if( _Cargo_Activity_ID == value ) return;
		
				_Cargo_Activity_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Cargo_Activity_ID");
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
		public decimal? Activity_Amt
		{
			get { return _Activity_Amt; }
			set
			{
				if( _Activity_Amt == value ) return;
		
				_Activity_Amt = value;
				_IsDirty = true;
				NotifyPropertyChanged("Activity_Amt");
			}
		}
		public string Charge_Type_Cd
		{
			get { return _Charge_Type_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Charge_Type_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Charge_Type_CdMax )
					_Charge_Type_Cd = val.Substring(0, (int)Charge_Type_CdMax);
				else
					_Charge_Type_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Charge_Type_Cd");
			}
		}
		public Int64? Level_Unit_ID
		{
			get { return _Level_Unit_ID; }
			set
			{
				if( _Level_Unit_ID == value ) return;
		
				_Level_Unit_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Level_Unit_ID");
			}
		}
		public decimal? Rate_Amt
		{
			get { return _Rate_Amt; }
			set
			{
				if( _Rate_Amt == value ) return;
		
				_Rate_Amt = value;
				_IsDirty = true;
				NotifyPropertyChanged("Rate_Amt");
			}
		}
		public Int64? Level_Count
		{
			get { return _Level_Count; }
			set
			{
				if( _Level_Count == value ) return;
		
				_Level_Count = value;
				_IsDirty = true;
				NotifyPropertyChanged("Level_Count");
			}
		}
		public decimal? Unit_Qty
		{
			get { return _Unit_Qty; }
			set
			{
				if( _Unit_Qty == value ) return;
		
				_Unit_Qty = value;
				_IsDirty = true;
				NotifyPropertyChanged("Unit_Qty");
			}
		}
		public decimal? Total_Amt
		{
			get { return _Total_Amt; }
			set
			{
				if( _Total_Amt == value ) return;
		
				_Total_Amt = value;
				_IsDirty = true;
				NotifyPropertyChanged("Total_Amt");
			}
		}
		public string Memo
		{
			get { return _Memo; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Memo, val, false) == 0 ) return;
		
				if( val != null && val.Length > MemoMax )
					_Memo = val.Substring(0, (int)MemoMax);
				else
					_Memo = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Memo");
			}
		}
		public decimal? Activity_Unit_Qty
		{
			get { return _Activity_Unit_Qty; }
			set
			{
				if( _Activity_Unit_Qty == value ) return;
		
				_Activity_Unit_Qty = value;
				_IsDirty = true;
				NotifyPropertyChanged("Activity_Unit_Qty");
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
		public decimal? Weight_Nbr
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
		public decimal? Dim_Weight_Nbr
		{
			get { return _Dim_Weight_Nbr; }
			set
			{
				if( _Dim_Weight_Nbr == value ) return;
		
				_Dim_Weight_Nbr = value;
				_IsDirty = true;
				NotifyPropertyChanged("Dim_Weight_Nbr");
			}
		}
		public decimal? Cube_Ft
		{
			get { return _Cube_Ft; }
			set
			{
				if( _Cube_Ft == value ) return;
		
				_Cube_Ft = value;
				_IsDirty = true;
				NotifyPropertyChanged("Cube_Ft");
			}
		}
		public decimal? M_Tons
		{
			get { return _M_Tons; }
			set
			{
				if( _M_Tons == value ) return;
		
				_M_Tons = value;
				_IsDirty = true;
				NotifyPropertyChanged("M_Tons");
			}
		}

		#endregion	// #region Column Properties

		#region Foreign Key Fields

		protected ClsApInvoice _Ap_Invoice;
		protected ClsLevelUnit _Level_Unit;
		protected ClsChargeType _Charge_Type;
		protected ClsCargoActivity _Cargo_Activity;

		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties

		public ClsApInvoice Ap_Invoice
		{
			get
			{
				if( Ap_Invoice_ID == null )
					_Ap_Invoice = null;
				else if( _Ap_Invoice == null ||
					_Ap_Invoice.Ap_Invoice_ID != Ap_Invoice_ID )
					_Ap_Invoice = ClsApInvoice.GetUsingKey(Ap_Invoice_ID.Value);
				return _Ap_Invoice;
			}
			set
			{
				if( _Ap_Invoice == value ) return;
		
				_Ap_Invoice = value;
			}
		}
		public ClsLevelUnit Level_Unit
		{
			get
			{
				if( Level_Unit_ID == null )
					_Level_Unit = null;
				else if( _Level_Unit == null ||
					_Level_Unit.Level_Unit_ID != Level_Unit_ID )
					_Level_Unit = ClsLevelUnit.GetUsingKey(Level_Unit_ID.Value);
				return _Level_Unit;
			}
			set
			{
				if( _Level_Unit == value ) return;
		
				_Level_Unit = value;
			}
		}
		public ClsChargeType Charge_Type
		{
			get
			{
				if( Charge_Type_Cd == null )
					_Charge_Type = null;
				else if( _Charge_Type == null ||
					_Charge_Type.Charge_Type_Cd != Charge_Type_Cd )
					_Charge_Type = ClsChargeType.GetUsingKey(Charge_Type_Cd);
				return _Charge_Type;
			}
			set
			{
				if( _Charge_Type == value ) return;
		
				_Charge_Type = value;
			}
		}
		public ClsCargoActivity Cargo_Activity
		{
			get
			{
				if( Cargo_Activity_ID == null )
					_Cargo_Activity = null;
				else if( _Cargo_Activity == null ||
					_Cargo_Activity.Cargo_Activity_ID != Cargo_Activity_ID )
					_Cargo_Activity = ClsCargoActivity.GetUsingKey(Cargo_Activity_ID.Value);
				return _Cargo_Activity;
			}
			set
			{
				if( _Cargo_Activity == value ) return;
		
				_Cargo_Activity = value;
			}
		}

		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsApChargeDtl() : base() {}
		public ClsApChargeDtl(DataRow dr) : base(dr) {}
		public ClsApChargeDtl(ClsApChargeDtl src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Ap_Charge_Dtl_ID = null;
			Ap_Invoice_ID = null;
			Cargo_Activity_ID = null;
			Create_User = null;
			Create_Dt = null;
			Modify_User = null;
			Modify_Dt = null;
			Activity_Amt = null;
			Charge_Type_Cd = null;
			Level_Unit_ID = null;
			Rate_Amt = null;
			Level_Count = null;
			Unit_Qty = null;
			Total_Amt = null;
			Memo = null;
			Activity_Unit_Qty = null;
			Length_Nbr = null;
			Width_Nbr = null;
			Height_Nbr = null;
			Weight_Nbr = null;
			Dim_Weight_Nbr = null;
			Cube_Ft = null;
			M_Tons = null;
		}

		public void CopyFrom(ClsApChargeDtl src)
		{
			Ap_Charge_Dtl_ID = src._Ap_Charge_Dtl_ID;
			Ap_Invoice_ID = src._Ap_Invoice_ID;
			Cargo_Activity_ID = src._Cargo_Activity_ID;
			Create_User = src._Create_User;
			Create_Dt = src._Create_Dt;
			Modify_User = src._Modify_User;
			Modify_Dt = src._Modify_Dt;
			Activity_Amt = src._Activity_Amt;
			Charge_Type_Cd = src._Charge_Type_Cd;
			Level_Unit_ID = src._Level_Unit_ID;
			Rate_Amt = src._Rate_Amt;
			Level_Count = src._Level_Count;
			Unit_Qty = src._Unit_Qty;
			Total_Amt = src._Total_Amt;
			Memo = src._Memo;
			Activity_Unit_Qty = src._Activity_Unit_Qty;
			Length_Nbr = src._Length_Nbr;
			Width_Nbr = src._Width_Nbr;
			Height_Nbr = src._Height_Nbr;
			Weight_Nbr = src._Weight_Nbr;
			Dim_Weight_Nbr = src._Dim_Weight_Nbr;
			Cube_Ft = src._Cube_Ft;
			M_Tons = src._M_Tons;
		}

		public override bool ReloadFromDB()
		{
			ClsApChargeDtl tmp = ClsApChargeDtl.GetUsingKey(Ap_Charge_Dtl_ID.Value);
			if( tmp != null ) CopyFrom(tmp);

			ResetFKs();
			OnReload();

			return ( tmp != null );
		}

		public override void ResetFKs()
		{
			_Ap_Invoice = null;
			_Level_Unit = null;
			_Charge_Type = null;
			_Cargo_Activity = null;
		}
		#endregion		// #region Init methods

		#region Insert, Update, Delete

		public override int Insert()
		{

			DbParameter[] p = new DbParameter[23];

			p[0] = Connection.GetParameter
				("@AP_INVOICE_ID", Ap_Invoice_ID);
			p[1] = Connection.GetParameter
				("@CARGO_ACTIVITY_ID", Cargo_Activity_ID);
			p[2] = Connection.GetParameter
				("@ACTIVITY_AMT", Activity_Amt);
			p[3] = Connection.GetParameter
				("@CHARGE_TYPE_CD", Charge_Type_Cd);
			p[4] = Connection.GetParameter
				("@LEVEL_UNIT_ID", Level_Unit_ID);
			p[5] = Connection.GetParameter
				("@RATE_AMT", Rate_Amt);
			p[6] = Connection.GetParameter
				("@LEVEL_COUNT", Level_Count);
			p[7] = Connection.GetParameter
				("@UNIT_QTY", Unit_Qty);
			p[8] = Connection.GetParameter
				("@TOTAL_AMT", Total_Amt);
			p[9] = Connection.GetParameter
				("@MEMO", Memo);
			p[10] = Connection.GetParameter
				("@ACTIVITY_UNIT_QTY", Activity_Unit_Qty);
			p[11] = Connection.GetParameter
				("@LENGTH_NBR", Length_Nbr);
			p[12] = Connection.GetParameter
				("@WIDTH_NBR", Width_Nbr);
			p[13] = Connection.GetParameter
				("@HEIGHT_NBR", Height_Nbr);
			p[14] = Connection.GetParameter
				("@WEIGHT_NBR", Weight_Nbr);
			p[15] = Connection.GetParameter
				("@DIM_WEIGHT_NBR", Dim_Weight_Nbr);
			p[16] = Connection.GetParameter
				("@CUBE_FT", Cube_Ft);
			p[17] = Connection.GetParameter
				("@M_TONS", M_Tons);
			p[18] = Connection.GetParameter
				("@AP_CHARGE_DTL_ID", Ap_Charge_Dtl_ID, ParameterDirection.Output, DbType.Int64, 0);
			p[19] = Connection.GetParameter
				("@CREATE_USER", Create_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Create_UserMax);
			p[20] = Connection.GetParameter
				("@CREATE_DT", Create_Dt, ParameterDirection.Output, DbType.DateTime, 0);
			p[21] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);
			p[22] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.Output, DbType.DateTime, 0);

			const string sql = @"
				INSERT INTO T_AP_CHARGE_DTL
					(AP_CHARGE_DTL_ID, AP_INVOICE_ID, CARGO_ACTIVITY_ID,
					ACTIVITY_AMT, CHARGE_TYPE_CD, LEVEL_UNIT_ID,
					RATE_AMT, LEVEL_COUNT, UNIT_QTY,
					TOTAL_AMT, MEMO, ACTIVITY_UNIT_QTY,
					LENGTH_NBR, WIDTH_NBR, HEIGHT_NBR,
					WEIGHT_NBR, DIM_WEIGHT_NBR, CUBE_FT,
					M_TONS)
				VALUES
					(AP_CHARGE_DTL_ID_SEQ.NEXTVAL, @AP_INVOICE_ID, @CARGO_ACTIVITY_ID,
					@ACTIVITY_AMT, @CHARGE_TYPE_CD, @LEVEL_UNIT_ID,
					@RATE_AMT, @LEVEL_COUNT, @UNIT_QTY,
					@TOTAL_AMT, @MEMO, @ACTIVITY_UNIT_QTY,
					@LENGTH_NBR, @WIDTH_NBR, @HEIGHT_NBR,
					@WEIGHT_NBR, @DIM_WEIGHT_NBR, @CUBE_FT,
					@M_TONS)
				RETURNING
					AP_CHARGE_DTL_ID, CREATE_USER, CREATE_DT,
					MODIFY_USER, MODIFY_DT
				INTO
					@AP_CHARGE_DTL_ID, @CREATE_USER, @CREATE_DT,
					@MODIFY_USER, @MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Ap_Charge_Dtl_ID = ClsConvert.ToInt64Nullable(p[18].Value);
			Create_User = ClsConvert.ToString(p[19].Value);
			Create_Dt = ClsConvert.ToDateTimeNullable(p[20].Value);
			Modify_User = ClsConvert.ToString(p[21].Value);
			Modify_Dt = ClsConvert.ToDateTimeNullable(p[22].Value);
			return ret;
		}
		public override int Update()
		{
			DbParameter[] p = new DbParameter[21];

			p[0] = Connection.GetParameter
				("@AP_INVOICE_ID", Ap_Invoice_ID);
			p[1] = Connection.GetParameter
				("@CARGO_ACTIVITY_ID", Cargo_Activity_ID);
			p[2] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.InputOutput, DbType.DateTime, 0);
			p[3] = Connection.GetParameter
				("@ACTIVITY_AMT", Activity_Amt);
			p[4] = Connection.GetParameter
				("@CHARGE_TYPE_CD", Charge_Type_Cd);
			p[5] = Connection.GetParameter
				("@LEVEL_UNIT_ID", Level_Unit_ID);
			p[6] = Connection.GetParameter
				("@RATE_AMT", Rate_Amt);
			p[7] = Connection.GetParameter
				("@LEVEL_COUNT", Level_Count);
			p[8] = Connection.GetParameter
				("@UNIT_QTY", Unit_Qty);
			p[9] = Connection.GetParameter
				("@TOTAL_AMT", Total_Amt);
			p[10] = Connection.GetParameter
				("@MEMO", Memo);
			p[11] = Connection.GetParameter
				("@ACTIVITY_UNIT_QTY", Activity_Unit_Qty);
			p[12] = Connection.GetParameter
				("@LENGTH_NBR", Length_Nbr);
			p[13] = Connection.GetParameter
				("@WIDTH_NBR", Width_Nbr);
			p[14] = Connection.GetParameter
				("@HEIGHT_NBR", Height_Nbr);
			p[15] = Connection.GetParameter
				("@WEIGHT_NBR", Weight_Nbr);
			p[16] = Connection.GetParameter
				("@DIM_WEIGHT_NBR", Dim_Weight_Nbr);
			p[17] = Connection.GetParameter
				("@CUBE_FT", Cube_Ft);
			p[18] = Connection.GetParameter
				("@M_TONS", M_Tons);
			p[19] = Connection.GetParameter
				("@AP_CHARGE_DTL_ID", Ap_Charge_Dtl_ID);
			p[20] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);

			const string sql = @"
				UPDATE T_AP_CHARGE_DTL SET
					AP_INVOICE_ID = @AP_INVOICE_ID,
					CARGO_ACTIVITY_ID = @CARGO_ACTIVITY_ID,
					MODIFY_DT = @MODIFY_DT,
					ACTIVITY_AMT = @ACTIVITY_AMT,
					CHARGE_TYPE_CD = @CHARGE_TYPE_CD,
					LEVEL_UNIT_ID = @LEVEL_UNIT_ID,
					RATE_AMT = @RATE_AMT,
					LEVEL_COUNT = @LEVEL_COUNT,
					UNIT_QTY = @UNIT_QTY,
					TOTAL_AMT = @TOTAL_AMT,
					MEMO = @MEMO,
					ACTIVITY_UNIT_QTY = @ACTIVITY_UNIT_QTY,
					LENGTH_NBR = @LENGTH_NBR,
					WIDTH_NBR = @WIDTH_NBR,
					HEIGHT_NBR = @HEIGHT_NBR,
					WEIGHT_NBR = @WEIGHT_NBR,
					DIM_WEIGHT_NBR = @DIM_WEIGHT_NBR,
					CUBE_FT = @CUBE_FT,
					M_TONS = @M_TONS
				WHERE
					AP_CHARGE_DTL_ID = @AP_CHARGE_DTL_ID
				RETURNING
					MODIFY_USER, MODIFY_DT
				INTO
					@MODIFY_USER, @MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Modify_Dt = ClsConvert.ToDateTimeNullable(p[2].Value);
			Modify_User = ClsConvert.ToString(p[20].Value);
			return ret;
		}
		public override int Delete()
		{
			DbParameter[] p = new DbParameter[1];

			p[0] = Connection.GetParameter
				("@AP_CHARGE_DTL_ID", Ap_Charge_Dtl_ID);

			const string sql = @"
				DELETE FROM T_AP_CHARGE_DTL WHERE
				AP_CHARGE_DTL_ID=@AP_CHARGE_DTL_ID";
			return Connection.RunSQL(sql, p);
		}
		#endregion		// #region Insert, Update, Delete

		#region Conversion methods

		public override void LoadFromDataReader(DbDataReader dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataReader: DataReader parameter was null");

			Ap_Charge_Dtl_ID = ClsConvert.ToInt64Nullable(dr["AP_CHARGE_DTL_ID"]);
			Ap_Invoice_ID = ClsConvert.ToInt64Nullable(dr["AP_INVOICE_ID"]);
			Cargo_Activity_ID = ClsConvert.ToInt64Nullable(dr["CARGO_ACTIVITY_ID"]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER"]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT"]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER"]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT"]);
			Activity_Amt = ClsConvert.ToDecimalNullable(dr["ACTIVITY_AMT"]);
			Charge_Type_Cd = ClsConvert.ToString(dr["CHARGE_TYPE_CD"]);
			Level_Unit_ID = ClsConvert.ToInt64Nullable(dr["LEVEL_UNIT_ID"]);
			Rate_Amt = ClsConvert.ToDecimalNullable(dr["RATE_AMT"]);
			Level_Count = ClsConvert.ToInt64Nullable(dr["LEVEL_COUNT"]);
			Unit_Qty = ClsConvert.ToDecimalNullable(dr["UNIT_QTY"]);
			Total_Amt = ClsConvert.ToDecimalNullable(dr["TOTAL_AMT"]);
			Memo = ClsConvert.ToString(dr["MEMO"]);
			Activity_Unit_Qty = ClsConvert.ToDecimalNullable(dr["ACTIVITY_UNIT_QTY"]);
			Length_Nbr = ClsConvert.ToDecimalNullable(dr["LENGTH_NBR"]);
			Width_Nbr = ClsConvert.ToDecimalNullable(dr["WIDTH_NBR"]);
			Height_Nbr = ClsConvert.ToDecimalNullable(dr["HEIGHT_NBR"]);
			Weight_Nbr = ClsConvert.ToDecimalNullable(dr["WEIGHT_NBR"]);
			Dim_Weight_Nbr = ClsConvert.ToDecimalNullable(dr["DIM_WEIGHT_NBR"]);
			Cube_Ft = ClsConvert.ToDecimalNullable(dr["CUBE_FT"]);
			M_Tons = ClsConvert.ToDecimalNullable(dr["M_TONS"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Ap_Charge_Dtl_ID = ClsConvert.ToInt64Nullable(dr["AP_CHARGE_DTL_ID", v]);
			Ap_Invoice_ID = ClsConvert.ToInt64Nullable(dr["AP_INVOICE_ID", v]);
			Cargo_Activity_ID = ClsConvert.ToInt64Nullable(dr["CARGO_ACTIVITY_ID", v]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER", v]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT", v]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER", v]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT", v]);
			Activity_Amt = ClsConvert.ToDecimalNullable(dr["ACTIVITY_AMT", v]);
			Charge_Type_Cd = ClsConvert.ToString(dr["CHARGE_TYPE_CD", v]);
			Level_Unit_ID = ClsConvert.ToInt64Nullable(dr["LEVEL_UNIT_ID", v]);
			Rate_Amt = ClsConvert.ToDecimalNullable(dr["RATE_AMT", v]);
			Level_Count = ClsConvert.ToInt64Nullable(dr["LEVEL_COUNT", v]);
			Unit_Qty = ClsConvert.ToDecimalNullable(dr["UNIT_QTY", v]);
			Total_Amt = ClsConvert.ToDecimalNullable(dr["TOTAL_AMT", v]);
			Memo = ClsConvert.ToString(dr["MEMO", v]);
			Activity_Unit_Qty = ClsConvert.ToDecimalNullable(dr["ACTIVITY_UNIT_QTY", v]);
			Length_Nbr = ClsConvert.ToDecimalNullable(dr["LENGTH_NBR", v]);
			Width_Nbr = ClsConvert.ToDecimalNullable(dr["WIDTH_NBR", v]);
			Height_Nbr = ClsConvert.ToDecimalNullable(dr["HEIGHT_NBR", v]);
			Weight_Nbr = ClsConvert.ToDecimalNullable(dr["WEIGHT_NBR", v]);
			Dim_Weight_Nbr = ClsConvert.ToDecimalNullable(dr["DIM_WEIGHT_NBR", v]);
			Cube_Ft = ClsConvert.ToDecimalNullable(dr["CUBE_FT", v]);
			M_Tons = ClsConvert.ToDecimalNullable(dr["M_TONS", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["AP_CHARGE_DTL_ID"] = ClsConvert.ToDbObject(Ap_Charge_Dtl_ID);
			dr["AP_INVOICE_ID"] = ClsConvert.ToDbObject(Ap_Invoice_ID);
			dr["CARGO_ACTIVITY_ID"] = ClsConvert.ToDbObject(Cargo_Activity_ID);
			dr["CREATE_USER"] = ClsConvert.ToDbObject(Create_User);
			dr["CREATE_DT"] = ClsConvert.ToDbObject(Create_Dt);
			dr["MODIFY_USER"] = ClsConvert.ToDbObject(Modify_User);
			dr["MODIFY_DT"] = ClsConvert.ToDbObject(Modify_Dt);
			dr["ACTIVITY_AMT"] = ClsConvert.ToDbObject(Activity_Amt);
			dr["CHARGE_TYPE_CD"] = ClsConvert.ToDbObject(Charge_Type_Cd);
			dr["LEVEL_UNIT_ID"] = ClsConvert.ToDbObject(Level_Unit_ID);
			dr["RATE_AMT"] = ClsConvert.ToDbObject(Rate_Amt);
			dr["LEVEL_COUNT"] = ClsConvert.ToDbObject(Level_Count);
			dr["UNIT_QTY"] = ClsConvert.ToDbObject(Unit_Qty);
			dr["TOTAL_AMT"] = ClsConvert.ToDbObject(Total_Amt);
			dr["MEMO"] = ClsConvert.ToDbObject(Memo);
			dr["ACTIVITY_UNIT_QTY"] = ClsConvert.ToDbObject(Activity_Unit_Qty);
			dr["LENGTH_NBR"] = ClsConvert.ToDbObject(Length_Nbr);
			dr["WIDTH_NBR"] = ClsConvert.ToDbObject(Width_Nbr);
			dr["HEIGHT_NBR"] = ClsConvert.ToDbObject(Height_Nbr);
			dr["WEIGHT_NBR"] = ClsConvert.ToDbObject(Weight_Nbr);
			dr["DIM_WEIGHT_NBR"] = ClsConvert.ToDbObject(Dim_Weight_Nbr);
			dr["CUBE_FT"] = ClsConvert.ToDbObject(Cube_Ft);
			dr["M_TONS"] = ClsConvert.ToDbObject(M_Tons);
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

		public static ClsApChargeDtl GetUsingKey(Int64 Ap_Charge_Dtl_ID)
		{
			object[] vals = new object[] {Ap_Charge_Dtl_ID};
			DataRow dr = Connection.GetDataRowUsingKey
				(TableName, GetPrimaryKeys(), vals);
			return ( dr == null ) ? null : new ClsApChargeDtl(dr);
		}
		public static DataTable GetAll(Int64? Ap_Invoice_ID, Int64? Level_Unit_ID,
			string Charge_Type_Cd, Int64? Cargo_Activity_ID)
		{
			List<DbParameter> lst = new List<DbParameter>();	
			StringBuilder sb = new StringBuilder();
		
			if( Ap_Invoice_ID != null && Ap_Invoice_ID > 0 )
			{
				lst.Add(Connection.GetParameter("@AP_INVOICE_ID", Ap_Invoice_ID));
				sb.Append(" WHERE T_AP_CHARGE_DTL.AP_INVOICE_ID=@AP_INVOICE_ID");
			}
			if( Level_Unit_ID != null && Level_Unit_ID > 0 )
			{
				lst.Add(Connection.GetParameter("@LEVEL_UNIT_ID", Level_Unit_ID));
				sb.AppendFormat(" {0} T_AP_CHARGE_DTL.LEVEL_UNIT_ID=@LEVEL_UNIT_ID",
					sb.Length > 0 ? "AND" : "WHERE");
			}
			if( string.IsNullOrEmpty(Charge_Type_Cd) == false )
			{
				lst.Add(Connection.GetParameter("@CHARGE_TYPE_CD", Charge_Type_Cd));
				sb.AppendFormat(" {0} T_AP_CHARGE_DTL.CHARGE_TYPE_CD=@CHARGE_TYPE_CD",
					sb.Length > 0 ? "AND" : "WHERE");
			}
			if( Cargo_Activity_ID != null && Cargo_Activity_ID > 0 )
			{
				lst.Add(Connection.GetParameter("@CARGO_ACTIVITY_ID", Cargo_Activity_ID));
				sb.AppendFormat(" {0} T_AP_CHARGE_DTL.CARGO_ACTIVITY_ID=@CARGO_ACTIVITY_ID",
					sb.Length > 0 ? "AND" : "WHERE");
			}
			sb.Insert(0, SelectSQL);
			return Connection.GetDataTable(sb.ToString(), lst.ToArray());
		}
		#endregion		// #region Static Methods
	}
}