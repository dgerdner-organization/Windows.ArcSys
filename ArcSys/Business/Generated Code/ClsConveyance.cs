using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsConveyance : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ArcSys"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "T_CONVEYANCE";
		public const int PrimaryKeyCount = 1;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] { "CONVEYANCE_ID" };
		}

		public const string SelectSQL = @"SELECT * FROM T_CONVEYANCE 
				INNER JOIN T_VENDOR_MOVE
				ON T_CONVEYANCE.VENDOR_MOVE_ID=T_VENDOR_MOVE.VENDOR_MOVE_ID
				LEFT OUTER JOIN T_AP_INVOICE
				ON T_CONVEYANCE.AP_INVOICE_ID=T_AP_INVOICE.AP_INVOICE_ID
				LEFT OUTER JOIN T_AR_INVOICE
				ON T_CONVEYANCE.AR_INVOICE_ID=T_AR_INVOICE.AR_INVOICE_ID
				LEFT OUTER JOIN R_CONVEYANCE_TYPE
				ON T_CONVEYANCE.CONVEYANCE_TYPE_CD=R_CONVEYANCE_TYPE.CONVEYANCE_TYPE_CD ";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Conveyance_NoMax = 20;
		public const int Truck_NoMax = 10;
		public const int Create_UserMax = 30;
		public const int Modify_UserMax = 30;
		public const int Futile_FlgMax = 1;
		public const int DriverMax = 50;
		public const int Conveyance_Type_CdMax = 10;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected Int64? _Conveyance_ID;
		protected Int64? _Vendor_Move_ID;
		protected string _Conveyance_No;
		protected string _Truck_No;
		protected string _Create_User;
		protected DateTime? _Create_Dt;
		protected string _Modify_User;
		protected DateTime? _Modify_Dt;
		protected string _Futile_Flg;
		protected string _Driver;
		protected string _Conveyance_Type_Cd;
		protected Int64? _Ap_Invoice_ID;
		protected Int64? _Ar_Invoice_ID;
		protected DateTime? _Conveyance_Dt;
		protected Int32? _Sequence_Nbr;

		#endregion	// #region Column Fields

		#region Column Properties

		public Int64? Conveyance_ID
		{
			get { return _Conveyance_ID; }
			set
			{
				if( _Conveyance_ID == value ) return;
		
				_Conveyance_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Conveyance_ID");
			}
		}
		public Int64? Vendor_Move_ID
		{
			get { return _Vendor_Move_ID; }
			set
			{
				if( _Vendor_Move_ID == value ) return;
		
				_Vendor_Move_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Vendor_Move_ID");
			}
		}
		public string Conveyance_No
		{
			get { return _Conveyance_No; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Conveyance_No, val, false) == 0 ) return;
		
				if( val != null && val.Length > Conveyance_NoMax )
					_Conveyance_No = val.Substring(0, (int)Conveyance_NoMax);
				else
					_Conveyance_No = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Conveyance_No");
			}
		}
		public string Truck_No
		{
			get { return _Truck_No; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Truck_No, val, false) == 0 ) return;
		
				if( val != null && val.Length > Truck_NoMax )
					_Truck_No = val.Substring(0, (int)Truck_NoMax);
				else
					_Truck_No = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Truck_No");
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
		public string Futile_Flg
		{
			get { return _Futile_Flg; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Futile_Flg, val, false) == 0 ) return;
		
				if( val != null && val.Length > Futile_FlgMax )
					_Futile_Flg = val.Substring(0, (int)Futile_FlgMax);
				else
					_Futile_Flg = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Futile_Flg");
			}
		}
		public string Driver
		{
			get { return _Driver; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Driver, val, false) == 0 ) return;
		
				if( val != null && val.Length > DriverMax )
					_Driver = val.Substring(0, (int)DriverMax);
				else
					_Driver = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Driver");
			}
		}
		public string Conveyance_Type_Cd
		{
			get { return _Conveyance_Type_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Conveyance_Type_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Conveyance_Type_CdMax )
					_Conveyance_Type_Cd = val.Substring(0, (int)Conveyance_Type_CdMax);
				else
					_Conveyance_Type_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Conveyance_Type_Cd");
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
		public Int64? Ar_Invoice_ID
		{
			get { return _Ar_Invoice_ID; }
			set
			{
				if( _Ar_Invoice_ID == value ) return;
		
				_Ar_Invoice_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Ar_Invoice_ID");
			}
		}
		public DateTime? Conveyance_Dt
		{
			get { return _Conveyance_Dt; }
			set
			{
				DateTime? val = ( value != null )
					? (DateTime?)value.Value.Date : null;
		
				if( _Conveyance_Dt == val ) return;
		
				_Conveyance_Dt = val;
				_IsDirty = true;
				NotifyPropertyChanged("Conveyance_Dt");
			}
		}
		public Int32? Sequence_Nbr
		{
			get { return _Sequence_Nbr; }
			set
			{
				if( _Sequence_Nbr == value ) return;
		
				_Sequence_Nbr = value;
				_IsDirty = true;
				NotifyPropertyChanged("Sequence_Nbr");
			}
		}

		#endregion	// #region Column Properties

		#region Foreign Key Fields

		protected ClsVendorMove _Vendor_Move;
		protected ClsApInvoice _Ap_Invoice;
		protected ClsArInvoice _Ar_Invoice;
		protected ClsConveyanceType _Conveyance_Type;

		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties

		public ClsVendorMove Vendor_Move
		{
			get
			{
				if( Vendor_Move_ID == null )
					_Vendor_Move = null;
				else if( _Vendor_Move == null ||
					_Vendor_Move.Vendor_Move_ID != Vendor_Move_ID )
					_Vendor_Move = ClsVendorMove.GetUsingKey(Vendor_Move_ID.Value);
				return _Vendor_Move;
			}
			set
			{
				if( _Vendor_Move == value ) return;
		
				_Vendor_Move = value;
			}
		}
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
		public ClsArInvoice Ar_Invoice
		{
			get
			{
				if( Ar_Invoice_ID == null )
					_Ar_Invoice = null;
				else if( _Ar_Invoice == null ||
					_Ar_Invoice.Ar_Invoice_ID != Ar_Invoice_ID )
					_Ar_Invoice = ClsArInvoice.GetUsingKey(Ar_Invoice_ID.Value);
				return _Ar_Invoice;
			}
			set
			{
				if( _Ar_Invoice == value ) return;
		
				_Ar_Invoice = value;
			}
		}
		public ClsConveyanceType Conveyance_Type
		{
			get
			{
				if( Conveyance_Type_Cd == null )
					_Conveyance_Type = null;
				else if( _Conveyance_Type == null ||
					_Conveyance_Type.Conveyance_Type_Cd != Conveyance_Type_Cd )
					_Conveyance_Type = ClsConveyanceType.GetUsingKey(Conveyance_Type_Cd);
				return _Conveyance_Type;
			}
			set
			{
				if( _Conveyance_Type == value ) return;
		
				_Conveyance_Type = value;
			}
		}

		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsConveyance() : base() {}
		public ClsConveyance(DataRow dr) : base(dr) {}
		public ClsConveyance(ClsConveyance src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Conveyance_ID = null;
			Vendor_Move_ID = null;
			Conveyance_No = null;
			Truck_No = null;
			Create_User = null;
			Create_Dt = null;
			Modify_User = null;
			Modify_Dt = null;
			Futile_Flg = null;
			Driver = null;
			Conveyance_Type_Cd = null;
			Ap_Invoice_ID = null;
			Ar_Invoice_ID = null;
			Conveyance_Dt = null;
			Sequence_Nbr = null;
		}

		public void CopyFrom(ClsConveyance src)
		{
			Conveyance_ID = src._Conveyance_ID;
			Vendor_Move_ID = src._Vendor_Move_ID;
			Conveyance_No = src._Conveyance_No;
			Truck_No = src._Truck_No;
			Create_User = src._Create_User;
			Create_Dt = src._Create_Dt;
			Modify_User = src._Modify_User;
			Modify_Dt = src._Modify_Dt;
			Futile_Flg = src._Futile_Flg;
			Driver = src._Driver;
			Conveyance_Type_Cd = src._Conveyance_Type_Cd;
			Ap_Invoice_ID = src._Ap_Invoice_ID;
			Ar_Invoice_ID = src._Ar_Invoice_ID;
			Conveyance_Dt = src._Conveyance_Dt;
			Sequence_Nbr = src._Sequence_Nbr;
		}

		public override bool ReloadFromDB()
		{
			ClsConveyance tmp = ClsConveyance.GetUsingKey(Conveyance_ID.Value);
			if( tmp != null ) CopyFrom(tmp);

			ResetFKs();
			OnReload();

			return ( tmp != null );
		}

		public override void ResetFKs()
		{
			_Vendor_Move = null;
			_Ap_Invoice = null;
			_Ar_Invoice = null;
			_Conveyance_Type = null;
		}
		#endregion		// #region Init methods

		#region Insert, Update, Delete

		public override int Insert()
		{

			DbParameter[] p = new DbParameter[15];

			p[0] = Connection.GetParameter
				("@VENDOR_MOVE_ID", Vendor_Move_ID);
			p[1] = Connection.GetParameter
				("@CONVEYANCE_NO", Conveyance_No);
			p[2] = Connection.GetParameter
				("@TRUCK_NO", Truck_No);
			p[3] = Connection.GetParameter
				("@FUTILE_FLG", Futile_Flg);
			p[4] = Connection.GetParameter
				("@DRIVER", Driver);
			p[5] = Connection.GetParameter
				("@CONVEYANCE_TYPE_CD", Conveyance_Type_Cd);
			p[6] = Connection.GetParameter
				("@AP_INVOICE_ID", Ap_Invoice_ID);
			p[7] = Connection.GetParameter
				("@AR_INVOICE_ID", Ar_Invoice_ID);
			p[8] = Connection.GetParameter
				("@CONVEYANCE_DT", Conveyance_Dt);
			p[9] = Connection.GetParameter
				("@SEQUENCE_NBR", Sequence_Nbr);
			p[10] = Connection.GetParameter
				("@CONVEYANCE_ID", Conveyance_ID, ParameterDirection.Output, DbType.Int64, 0);
			p[11] = Connection.GetParameter
				("@CREATE_USER", Create_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Create_UserMax);
			p[12] = Connection.GetParameter
				("@CREATE_DT", Create_Dt, ParameterDirection.Output, DbType.DateTime, 0);
			p[13] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);
			p[14] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.Output, DbType.DateTime, 0);

			const string sql = @"
				INSERT INTO T_CONVEYANCE
					(CONVEYANCE_ID, VENDOR_MOVE_ID, CONVEYANCE_NO,
					TRUCK_NO, FUTILE_FLG, DRIVER,
					CONVEYANCE_TYPE_CD, AP_INVOICE_ID, AR_INVOICE_ID,
					CONVEYANCE_DT, SEQUENCE_NBR)
				VALUES
					(CONVEYANCE_ID_SEQ.NEXTVAL, @VENDOR_MOVE_ID, @CONVEYANCE_NO,
					@TRUCK_NO, @FUTILE_FLG, @DRIVER,
					@CONVEYANCE_TYPE_CD, @AP_INVOICE_ID, @AR_INVOICE_ID,
					@CONVEYANCE_DT, @SEQUENCE_NBR)
				RETURNING
					CONVEYANCE_ID, CREATE_USER, CREATE_DT,
					MODIFY_USER, MODIFY_DT
				INTO
					@CONVEYANCE_ID, @CREATE_USER, @CREATE_DT,
					@MODIFY_USER, @MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Conveyance_ID = ClsConvert.ToInt64Nullable(p[10].Value);
			Create_User = ClsConvert.ToString(p[11].Value);
			Create_Dt = ClsConvert.ToDateTimeNullable(p[12].Value);
			Modify_User = ClsConvert.ToString(p[13].Value);
			Modify_Dt = ClsConvert.ToDateTimeNullable(p[14].Value);
			return ret;
		}
		public override int Update()
		{
			DbParameter[] p = new DbParameter[13];

			p[0] = Connection.GetParameter
				("@VENDOR_MOVE_ID", Vendor_Move_ID);
			p[1] = Connection.GetParameter
				("@CONVEYANCE_NO", Conveyance_No);
			p[2] = Connection.GetParameter
				("@TRUCK_NO", Truck_No);
			p[3] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.InputOutput, DbType.DateTime, 0);
			p[4] = Connection.GetParameter
				("@FUTILE_FLG", Futile_Flg);
			p[5] = Connection.GetParameter
				("@DRIVER", Driver);
			p[6] = Connection.GetParameter
				("@CONVEYANCE_TYPE_CD", Conveyance_Type_Cd);
			p[7] = Connection.GetParameter
				("@AP_INVOICE_ID", Ap_Invoice_ID);
			p[8] = Connection.GetParameter
				("@AR_INVOICE_ID", Ar_Invoice_ID);
			p[9] = Connection.GetParameter
				("@CONVEYANCE_DT", Conveyance_Dt);
			p[10] = Connection.GetParameter
				("@SEQUENCE_NBR", Sequence_Nbr);
			p[11] = Connection.GetParameter
				("@CONVEYANCE_ID", Conveyance_ID);
			p[12] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);

			const string sql = @"
				UPDATE T_CONVEYANCE SET
					VENDOR_MOVE_ID = @VENDOR_MOVE_ID,
					CONVEYANCE_NO = @CONVEYANCE_NO,
					TRUCK_NO = @TRUCK_NO,
					MODIFY_DT = @MODIFY_DT,
					FUTILE_FLG = @FUTILE_FLG,
					DRIVER = @DRIVER,
					CONVEYANCE_TYPE_CD = @CONVEYANCE_TYPE_CD,
					AP_INVOICE_ID = @AP_INVOICE_ID,
					AR_INVOICE_ID = @AR_INVOICE_ID,
					CONVEYANCE_DT = @CONVEYANCE_DT,
					SEQUENCE_NBR = @SEQUENCE_NBR
				WHERE
					CONVEYANCE_ID = @CONVEYANCE_ID
				RETURNING
					MODIFY_USER, MODIFY_DT
				INTO
					@MODIFY_USER, @MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Modify_Dt = ClsConvert.ToDateTimeNullable(p[3].Value);
			Modify_User = ClsConvert.ToString(p[12].Value);
			return ret;
		}
		public override int Delete()
		{
			DbParameter[] p = new DbParameter[1];

			p[0] = Connection.GetParameter
				("@CONVEYANCE_ID", Conveyance_ID);

			const string sql = @"
				DELETE FROM T_CONVEYANCE WHERE
				CONVEYANCE_ID=@CONVEYANCE_ID";
			return Connection.RunSQL(sql, p);
		}
		#endregion		// #region Insert, Update, Delete

		#region Conversion methods

		public override void LoadFromDataReader(DbDataReader dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataReader: DataReader parameter was null");

			Conveyance_ID = ClsConvert.ToInt64Nullable(dr["CONVEYANCE_ID"]);
			Vendor_Move_ID = ClsConvert.ToInt64Nullable(dr["VENDOR_MOVE_ID"]);
			Conveyance_No = ClsConvert.ToString(dr["CONVEYANCE_NO"]);
			Truck_No = ClsConvert.ToString(dr["TRUCK_NO"]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER"]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT"]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER"]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT"]);
			Futile_Flg = ClsConvert.ToString(dr["FUTILE_FLG"]);
			Driver = ClsConvert.ToString(dr["DRIVER"]);
			Conveyance_Type_Cd = ClsConvert.ToString(dr["CONVEYANCE_TYPE_CD"]);
			Ap_Invoice_ID = ClsConvert.ToInt64Nullable(dr["AP_INVOICE_ID"]);
			Ar_Invoice_ID = ClsConvert.ToInt64Nullable(dr["AR_INVOICE_ID"]);
			Conveyance_Dt = ClsConvert.ToDateTimeNullable(dr["CONVEYANCE_DT"]);
			Sequence_Nbr = ClsConvert.ToInt32Nullable(dr["SEQUENCE_NBR"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Conveyance_ID = ClsConvert.ToInt64Nullable(dr["CONVEYANCE_ID", v]);
			Vendor_Move_ID = ClsConvert.ToInt64Nullable(dr["VENDOR_MOVE_ID", v]);
			Conveyance_No = ClsConvert.ToString(dr["CONVEYANCE_NO", v]);
			Truck_No = ClsConvert.ToString(dr["TRUCK_NO", v]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER", v]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT", v]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER", v]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT", v]);
			Futile_Flg = ClsConvert.ToString(dr["FUTILE_FLG", v]);
			Driver = ClsConvert.ToString(dr["DRIVER", v]);
			Conveyance_Type_Cd = ClsConvert.ToString(dr["CONVEYANCE_TYPE_CD", v]);
			Ap_Invoice_ID = ClsConvert.ToInt64Nullable(dr["AP_INVOICE_ID", v]);
			Ar_Invoice_ID = ClsConvert.ToInt64Nullable(dr["AR_INVOICE_ID", v]);
			Conveyance_Dt = ClsConvert.ToDateTimeNullable(dr["CONVEYANCE_DT", v]);
			Sequence_Nbr = ClsConvert.ToInt32Nullable(dr["SEQUENCE_NBR", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["CONVEYANCE_ID"] = ClsConvert.ToDbObject(Conveyance_ID);
			dr["VENDOR_MOVE_ID"] = ClsConvert.ToDbObject(Vendor_Move_ID);
			dr["CONVEYANCE_NO"] = ClsConvert.ToDbObject(Conveyance_No);
			dr["TRUCK_NO"] = ClsConvert.ToDbObject(Truck_No);
			dr["CREATE_USER"] = ClsConvert.ToDbObject(Create_User);
			dr["CREATE_DT"] = ClsConvert.ToDbObject(Create_Dt);
			dr["MODIFY_USER"] = ClsConvert.ToDbObject(Modify_User);
			dr["MODIFY_DT"] = ClsConvert.ToDbObject(Modify_Dt);
			dr["FUTILE_FLG"] = ClsConvert.ToDbObject(Futile_Flg);
			dr["DRIVER"] = ClsConvert.ToDbObject(Driver);
			dr["CONVEYANCE_TYPE_CD"] = ClsConvert.ToDbObject(Conveyance_Type_Cd);
			dr["AP_INVOICE_ID"] = ClsConvert.ToDbObject(Ap_Invoice_ID);
			dr["AR_INVOICE_ID"] = ClsConvert.ToDbObject(Ar_Invoice_ID);
			dr["CONVEYANCE_DT"] = ClsConvert.ToDbObject(Conveyance_Dt);
			dr["SEQUENCE_NBR"] = ClsConvert.ToDbObject(Sequence_Nbr);
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

		public static ClsConveyance GetUsingKey(Int64 Conveyance_ID)
		{
			object[] vals = new object[] {Conveyance_ID};
			DataRow dr = Connection.GetDataRowUsingKey
				(TableName, GetPrimaryKeys(), vals);
			return ( dr == null ) ? null : new ClsConveyance(dr);
		}
		public static DataTable GetAll(Int64? Vendor_Move_ID, Int64? Ap_Invoice_ID,
			Int64? Ar_Invoice_ID, string Conveyance_Type_Cd)
		{
			List<DbParameter> lst = new List<DbParameter>();	
			StringBuilder sb = new StringBuilder();
		
			if( Vendor_Move_ID != null && Vendor_Move_ID > 0 )
			{
				lst.Add(Connection.GetParameter("@VENDOR_MOVE_ID", Vendor_Move_ID));
				sb.Append(" WHERE T_CONVEYANCE.VENDOR_MOVE_ID=@VENDOR_MOVE_ID");
			}
			if( Ap_Invoice_ID != null && Ap_Invoice_ID > 0 )
			{
				lst.Add(Connection.GetParameter("@AP_INVOICE_ID", Ap_Invoice_ID));
				sb.AppendFormat(" {0} T_CONVEYANCE.AP_INVOICE_ID=@AP_INVOICE_ID",
					sb.Length > 0 ? "AND" : "WHERE");
			}
			if( Ar_Invoice_ID != null && Ar_Invoice_ID > 0 )
			{
				lst.Add(Connection.GetParameter("@AR_INVOICE_ID", Ar_Invoice_ID));
				sb.AppendFormat(" {0} T_CONVEYANCE.AR_INVOICE_ID=@AR_INVOICE_ID",
					sb.Length > 0 ? "AND" : "WHERE");
			}
			if( string.IsNullOrEmpty(Conveyance_Type_Cd) == false )
			{
				lst.Add(Connection.GetParameter("@CONVEYANCE_TYPE_CD", Conveyance_Type_Cd));
				sb.AppendFormat(" {0} T_CONVEYANCE.CONVEYANCE_TYPE_CD=@CONVEYANCE_TYPE_CD",
					sb.Length > 0 ? "AND" : "WHERE");
			}
			sb.Insert(0, SelectSQL);
			return Connection.GetDataTable(sb.ToString(), lst.ToArray());
		}
		#endregion		// #region Static Methods
	}
}