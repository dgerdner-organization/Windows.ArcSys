using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsApInvoice : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ArcSys"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "T_AP_INVOICE";
		public const int PrimaryKeyCount = 1;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] { "AP_INVOICE_ID" };
		}

		public const string SelectSQL = @"SELECT * FROM T_AP_INVOICE 
				INNER JOIN R_VENDOR
				ON T_AP_INVOICE.VENDOR_CD=R_VENDOR.VENDOR_CD ";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Invoice_NoMax = 10;
		public const int Vendor_CdMax = 10;
		public const int Create_UserMax = 30;
		public const int Modify_UserMax = 30;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected Int64? _Ap_Invoice_ID;
		protected string _Invoice_No;
		protected string _Vendor_Cd;
		protected string _Create_User;
		protected DateTime? _Create_Dt;
		protected string _Modify_User;
		protected DateTime? _Modify_Dt;
		protected DateTime? _Invoice_Dt;

		#endregion	// #region Column Fields

		#region Column Properties

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
		public string Invoice_No
		{
			get { return _Invoice_No; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Invoice_No, val, false) == 0 ) return;
		
				if( val != null && val.Length > Invoice_NoMax )
					_Invoice_No = val.Substring(0, (int)Invoice_NoMax);
				else
					_Invoice_No = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Invoice_No");
			}
		}
		public string Vendor_Cd
		{
			get { return _Vendor_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Vendor_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Vendor_CdMax )
					_Vendor_Cd = val.Substring(0, (int)Vendor_CdMax);
				else
					_Vendor_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Vendor_Cd");
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
		public DateTime? Invoice_Dt
		{
			get { return _Invoice_Dt; }
			set
			{
				DateTime? val = ( value != null )
					? (DateTime?)value.Value.Date : null;
		
				if( _Invoice_Dt == val ) return;
		
				_Invoice_Dt = val;
				_IsDirty = true;
				NotifyPropertyChanged("Invoice_Dt");
			}
		}

		#endregion	// #region Column Properties

		#region Foreign Key Fields

		protected ClsVendor _Vendor;

		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties

		public ClsVendor Vendor
		{
			get
			{
				if( Vendor_Cd == null )
					_Vendor = null;
				else if( _Vendor == null ||
					_Vendor.Vendor_Cd != Vendor_Cd )
					_Vendor = ClsVendor.GetUsingKey(Vendor_Cd);
				return _Vendor;
			}
			set
			{
				if( _Vendor == value ) return;
		
				_Vendor = value;
			}
		}

		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsApInvoice() : base() {}
		public ClsApInvoice(DataRow dr) : base(dr) {}
		public ClsApInvoice(ClsApInvoice src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Ap_Invoice_ID = null;
			Invoice_No = null;
			Vendor_Cd = null;
			Create_User = null;
			Create_Dt = null;
			Modify_User = null;
			Modify_Dt = null;
			Invoice_Dt = null;
		}

		public void CopyFrom(ClsApInvoice src)
		{
			Ap_Invoice_ID = src._Ap_Invoice_ID;
			Invoice_No = src._Invoice_No;
			Vendor_Cd = src._Vendor_Cd;
			Create_User = src._Create_User;
			Create_Dt = src._Create_Dt;
			Modify_User = src._Modify_User;
			Modify_Dt = src._Modify_Dt;
			Invoice_Dt = src._Invoice_Dt;
		}

		public override bool ReloadFromDB()
		{
			ClsApInvoice tmp = ClsApInvoice.GetUsingKey(Ap_Invoice_ID.Value);
			if( tmp != null ) CopyFrom(tmp);

			ResetFKs();
			OnReload();

			return ( tmp != null );
		}

		public override void ResetFKs()
		{
			_Vendor = null;
		}
		#endregion		// #region Init methods

		#region Insert, Update, Delete

		public override int Insert()
		{

			DbParameter[] p = new DbParameter[8];

			p[0] = Connection.GetParameter
				("@INVOICE_NO", Invoice_No);
			p[1] = Connection.GetParameter
				("@VENDOR_CD", Vendor_Cd);
			p[2] = Connection.GetParameter
				("@INVOICE_DT", Invoice_Dt);
			p[3] = Connection.GetParameter
				("@AP_INVOICE_ID", Ap_Invoice_ID, ParameterDirection.Output, DbType.Int64, 0);
			p[4] = Connection.GetParameter
				("@CREATE_USER", Create_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Create_UserMax);
			p[5] = Connection.GetParameter
				("@CREATE_DT", Create_Dt, ParameterDirection.Output, DbType.DateTime, 0);
			p[6] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);
			p[7] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.Output, DbType.DateTime, 0);

			const string sql = @"
				INSERT INTO T_AP_INVOICE
					(AP_INVOICE_ID, INVOICE_NO, VENDOR_CD,
					INVOICE_DT)
				VALUES
					(AP_INVOICE_ID_SEQ.NEXTVAL, @INVOICE_NO, @VENDOR_CD,
					@INVOICE_DT)
				RETURNING
					AP_INVOICE_ID, CREATE_USER, CREATE_DT,
					MODIFY_USER, MODIFY_DT
				INTO
					@AP_INVOICE_ID, @CREATE_USER, @CREATE_DT,
					@MODIFY_USER, @MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Ap_Invoice_ID = ClsConvert.ToInt64Nullable(p[3].Value);
			Create_User = ClsConvert.ToString(p[4].Value);
			Create_Dt = ClsConvert.ToDateTimeNullable(p[5].Value);
			Modify_User = ClsConvert.ToString(p[6].Value);
			Modify_Dt = ClsConvert.ToDateTimeNullable(p[7].Value);
			return ret;
		}
		public override int Update()
		{
			DbParameter[] p = new DbParameter[6];

			p[0] = Connection.GetParameter
				("@INVOICE_NO", Invoice_No);
			p[1] = Connection.GetParameter
				("@VENDOR_CD", Vendor_Cd);
			p[2] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.InputOutput, DbType.DateTime, 0);
			p[3] = Connection.GetParameter
				("@INVOICE_DT", Invoice_Dt);
			p[4] = Connection.GetParameter
				("@AP_INVOICE_ID", Ap_Invoice_ID);
			p[5] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);

			const string sql = @"
				UPDATE T_AP_INVOICE SET
					INVOICE_NO = @INVOICE_NO,
					VENDOR_CD = @VENDOR_CD,
					MODIFY_DT = @MODIFY_DT,
					INVOICE_DT = @INVOICE_DT
				WHERE
					AP_INVOICE_ID = @AP_INVOICE_ID
				RETURNING
					MODIFY_USER, MODIFY_DT
				INTO
					@MODIFY_USER, @MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Modify_Dt = ClsConvert.ToDateTimeNullable(p[2].Value);
			Modify_User = ClsConvert.ToString(p[5].Value);
			return ret;
		}
		public override int Delete()
		{
			DbParameter[] p = new DbParameter[1];

			p[0] = Connection.GetParameter
				("@AP_INVOICE_ID", Ap_Invoice_ID);

			const string sql = @"
				DELETE FROM T_AP_INVOICE WHERE
				AP_INVOICE_ID=@AP_INVOICE_ID";
			return Connection.RunSQL(sql, p);
		}
		#endregion		// #region Insert, Update, Delete

		#region Conversion methods

		public override void LoadFromDataReader(DbDataReader dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataReader: DataReader parameter was null");

			Ap_Invoice_ID = ClsConvert.ToInt64Nullable(dr["AP_INVOICE_ID"]);
			Invoice_No = ClsConvert.ToString(dr["INVOICE_NO"]);
			Vendor_Cd = ClsConvert.ToString(dr["VENDOR_CD"]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER"]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT"]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER"]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT"]);
			Invoice_Dt = ClsConvert.ToDateTimeNullable(dr["INVOICE_DT"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Ap_Invoice_ID = ClsConvert.ToInt64Nullable(dr["AP_INVOICE_ID", v]);
			Invoice_No = ClsConvert.ToString(dr["INVOICE_NO", v]);
			Vendor_Cd = ClsConvert.ToString(dr["VENDOR_CD", v]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER", v]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT", v]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER", v]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT", v]);
			Invoice_Dt = ClsConvert.ToDateTimeNullable(dr["INVOICE_DT", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["AP_INVOICE_ID"] = ClsConvert.ToDbObject(Ap_Invoice_ID);
			dr["INVOICE_NO"] = ClsConvert.ToDbObject(Invoice_No);
			dr["VENDOR_CD"] = ClsConvert.ToDbObject(Vendor_Cd);
			dr["CREATE_USER"] = ClsConvert.ToDbObject(Create_User);
			dr["CREATE_DT"] = ClsConvert.ToDbObject(Create_Dt);
			dr["MODIFY_USER"] = ClsConvert.ToDbObject(Modify_User);
			dr["MODIFY_DT"] = ClsConvert.ToDbObject(Modify_Dt);
			dr["INVOICE_DT"] = ClsConvert.ToDbObject(Invoice_Dt);
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

		public static ClsApInvoice GetUsingKey(Int64 Ap_Invoice_ID)
		{
			object[] vals = new object[] {Ap_Invoice_ID};
			DataRow dr = Connection.GetDataRowUsingKey
				(TableName, GetPrimaryKeys(), vals);
			return ( dr == null ) ? null : new ClsApInvoice(dr);
		}
		public static DataTable GetAll(string Vendor_Cd)
		{
			List<DbParameter> lst = new List<DbParameter>();	
			StringBuilder sb = new StringBuilder();
		
			if( string.IsNullOrEmpty(Vendor_Cd) == false )
			{
				lst.Add(Connection.GetParameter("@VENDOR_CD", Vendor_Cd));
				sb.Append(" WHERE T_AP_INVOICE.VENDOR_CD=@VENDOR_CD");
			}
			sb.Insert(0, SelectSQL);
			return Connection.GetDataTable(sb.ToString(), lst.ToArray());
		}
		#endregion		// #region Static Methods
	}
}