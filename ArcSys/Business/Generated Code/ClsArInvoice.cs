using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsArInvoice : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ArcSys"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "T_AR_INVOICE";
		public const int PrimaryKeyCount = 1;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] { "AR_INVOICE_ID" };
		}

		public const string SelectSQL = @"SELECT * FROM T_AR_INVOICE 
				INNER JOIN R_CUSTOMER
				ON T_AR_INVOICE.CUSTOMER_CD=R_CUSTOMER.CUSTOMER_CD
				INNER JOIN R_LOCATION
				ON T_AR_INVOICE.PORT_LOCATION_CD=R_LOCATION.LOCATION_CD ";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Invoice_NoMax = 10;
		public const int Customer_CdMax = 10;
		public const int Voyage_NoMax = 10;
		public const int Create_UserMax = 30;
		public const int Modify_UserMax = 30;
		public const int Port_Location_CdMax = 10;
		public const int Direction_IndMax = 1;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected Int64? _Ar_Invoice_ID;
		protected string _Invoice_No;
		protected string _Customer_Cd;
		protected string _Voyage_No;
		protected string _Create_User;
		protected DateTime? _Create_Dt;
		protected string _Modify_User;
		protected DateTime? _Modify_Dt;
		protected string _Port_Location_Cd;
		protected string _Direction_Ind;
		protected DateTime? _Invoice_Dt;

		#endregion	// #region Column Fields

		#region Column Properties

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
		public string Customer_Cd
		{
			get { return _Customer_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Customer_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Customer_CdMax )
					_Customer_Cd = val.Substring(0, (int)Customer_CdMax);
				else
					_Customer_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Customer_Cd");
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
		public string Port_Location_Cd
		{
			get { return _Port_Location_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Port_Location_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Port_Location_CdMax )
					_Port_Location_Cd = val.Substring(0, (int)Port_Location_CdMax);
				else
					_Port_Location_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Port_Location_Cd");
			}
		}
		public string Direction_Ind
		{
			get { return _Direction_Ind; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Direction_Ind, val, false) == 0 ) return;
		
				if( val != null && val.Length > Direction_IndMax )
					_Direction_Ind = val.Substring(0, (int)Direction_IndMax);
				else
					_Direction_Ind = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Direction_Ind");
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

		protected ClsCustomer _Customer;
		protected ClsLocation _Port_Location;

		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties

		public ClsCustomer Customer
		{
			get
			{
				if( Customer_Cd == null )
					_Customer = null;
				else if( _Customer == null ||
					_Customer.Customer_Cd != Customer_Cd )
					_Customer = ClsCustomer.GetUsingKey(Customer_Cd);
				return _Customer;
			}
			set
			{
				if( _Customer == value ) return;
		
				_Customer = value;
			}
		}
		public ClsLocation Port_Location
		{
			get
			{
				if( Port_Location_Cd == null )
					_Port_Location = null;
				else if( _Port_Location == null ||
					_Port_Location.Location_Cd != Port_Location_Cd )
					_Port_Location = ClsLocation.GetUsingKey(Port_Location_Cd);
				return _Port_Location;
			}
			set
			{
				if( _Port_Location == value ) return;
		
				_Port_Location = value;
			}
		}

		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsArInvoice() : base() {}
		public ClsArInvoice(DataRow dr) : base(dr) {}
		public ClsArInvoice(ClsArInvoice src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Ar_Invoice_ID = null;
			Invoice_No = null;
			Customer_Cd = null;
			Voyage_No = null;
			Create_User = null;
			Create_Dt = null;
			Modify_User = null;
			Modify_Dt = null;
			Port_Location_Cd = null;
			Direction_Ind = null;
			Invoice_Dt = null;
		}

		public void CopyFrom(ClsArInvoice src)
		{
			Ar_Invoice_ID = src._Ar_Invoice_ID;
			Invoice_No = src._Invoice_No;
			Customer_Cd = src._Customer_Cd;
			Voyage_No = src._Voyage_No;
			Create_User = src._Create_User;
			Create_Dt = src._Create_Dt;
			Modify_User = src._Modify_User;
			Modify_Dt = src._Modify_Dt;
			Port_Location_Cd = src._Port_Location_Cd;
			Direction_Ind = src._Direction_Ind;
			Invoice_Dt = src._Invoice_Dt;
		}

		public override bool ReloadFromDB()
		{
			ClsArInvoice tmp = ClsArInvoice.GetUsingKey(Ar_Invoice_ID.Value);
			if( tmp != null ) CopyFrom(tmp);

			ResetFKs();
			OnReload();

			return ( tmp != null );
		}

		public override void ResetFKs()
		{
			_Customer = null;
			_Port_Location = null;
		}
		#endregion		// #region Init methods

		#region Insert, Update, Delete

		public override int Insert()
		{

			DbParameter[] p = new DbParameter[11];

			p[0] = Connection.GetParameter
				("@INVOICE_NO", Invoice_No);
			p[1] = Connection.GetParameter
				("@CUSTOMER_CD", Customer_Cd);
			p[2] = Connection.GetParameter
				("@VOYAGE_NO", Voyage_No);
			p[3] = Connection.GetParameter
				("@PORT_LOCATION_CD", Port_Location_Cd);
			p[4] = Connection.GetParameter
				("@DIRECTION_IND", Direction_Ind);
			p[5] = Connection.GetParameter
				("@INVOICE_DT", Invoice_Dt);
			p[6] = Connection.GetParameter
				("@AR_INVOICE_ID", Ar_Invoice_ID, ParameterDirection.Output, DbType.Int64, 0);
			p[7] = Connection.GetParameter
				("@CREATE_USER", Create_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Create_UserMax);
			p[8] = Connection.GetParameter
				("@CREATE_DT", Create_Dt, ParameterDirection.Output, DbType.DateTime, 0);
			p[9] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);
			p[10] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.Output, DbType.DateTime, 0);

			const string sql = @"
				INSERT INTO T_AR_INVOICE
					(AR_INVOICE_ID, INVOICE_NO, CUSTOMER_CD,
					VOYAGE_NO, PORT_LOCATION_CD, DIRECTION_IND,
					INVOICE_DT)
				VALUES
					(AR_INVOICE_ID_SEQ.NEXTVAL, @INVOICE_NO, @CUSTOMER_CD,
					@VOYAGE_NO, @PORT_LOCATION_CD, @DIRECTION_IND,
					@INVOICE_DT)
				RETURNING
					AR_INVOICE_ID, CREATE_USER, CREATE_DT,
					MODIFY_USER, MODIFY_DT
				INTO
					@AR_INVOICE_ID, @CREATE_USER, @CREATE_DT,
					@MODIFY_USER, @MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Ar_Invoice_ID = ClsConvert.ToInt64Nullable(p[6].Value);
			Create_User = ClsConvert.ToString(p[7].Value);
			Create_Dt = ClsConvert.ToDateTimeNullable(p[8].Value);
			Modify_User = ClsConvert.ToString(p[9].Value);
			Modify_Dt = ClsConvert.ToDateTimeNullable(p[10].Value);
			return ret;
		}
		public override int Update()
		{
			DbParameter[] p = new DbParameter[9];

			p[0] = Connection.GetParameter
				("@INVOICE_NO", Invoice_No);
			p[1] = Connection.GetParameter
				("@CUSTOMER_CD", Customer_Cd);
			p[2] = Connection.GetParameter
				("@VOYAGE_NO", Voyage_No);
			p[3] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.InputOutput, DbType.DateTime, 0);
			p[4] = Connection.GetParameter
				("@PORT_LOCATION_CD", Port_Location_Cd);
			p[5] = Connection.GetParameter
				("@DIRECTION_IND", Direction_Ind);
			p[6] = Connection.GetParameter
				("@INVOICE_DT", Invoice_Dt);
			p[7] = Connection.GetParameter
				("@AR_INVOICE_ID", Ar_Invoice_ID);
			p[8] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);

			const string sql = @"
				UPDATE T_AR_INVOICE SET
					INVOICE_NO = @INVOICE_NO,
					CUSTOMER_CD = @CUSTOMER_CD,
					VOYAGE_NO = @VOYAGE_NO,
					MODIFY_DT = @MODIFY_DT,
					PORT_LOCATION_CD = @PORT_LOCATION_CD,
					DIRECTION_IND = @DIRECTION_IND,
					INVOICE_DT = @INVOICE_DT
				WHERE
					AR_INVOICE_ID = @AR_INVOICE_ID
				RETURNING
					MODIFY_USER, MODIFY_DT
				INTO
					@MODIFY_USER, @MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Modify_Dt = ClsConvert.ToDateTimeNullable(p[3].Value);
			Modify_User = ClsConvert.ToString(p[8].Value);
			return ret;
		}
		public override int Delete()
		{
			DbParameter[] p = new DbParameter[1];

			p[0] = Connection.GetParameter
				("@AR_INVOICE_ID", Ar_Invoice_ID);

			const string sql = @"
				DELETE FROM T_AR_INVOICE WHERE
				AR_INVOICE_ID=@AR_INVOICE_ID";
			return Connection.RunSQL(sql, p);
		}
		#endregion		// #region Insert, Update, Delete

		#region Conversion methods

		public override void LoadFromDataReader(DbDataReader dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataReader: DataReader parameter was null");

			Ar_Invoice_ID = ClsConvert.ToInt64Nullable(dr["AR_INVOICE_ID"]);
			Invoice_No = ClsConvert.ToString(dr["INVOICE_NO"]);
			Customer_Cd = ClsConvert.ToString(dr["CUSTOMER_CD"]);
			Voyage_No = ClsConvert.ToString(dr["VOYAGE_NO"]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER"]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT"]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER"]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT"]);
			Port_Location_Cd = ClsConvert.ToString(dr["PORT_LOCATION_CD"]);
			Direction_Ind = ClsConvert.ToString(dr["DIRECTION_IND"]);
			Invoice_Dt = ClsConvert.ToDateTimeNullable(dr["INVOICE_DT"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Ar_Invoice_ID = ClsConvert.ToInt64Nullable(dr["AR_INVOICE_ID", v]);
			Invoice_No = ClsConvert.ToString(dr["INVOICE_NO", v]);
			Customer_Cd = ClsConvert.ToString(dr["CUSTOMER_CD", v]);
			Voyage_No = ClsConvert.ToString(dr["VOYAGE_NO", v]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER", v]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT", v]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER", v]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT", v]);
			Port_Location_Cd = ClsConvert.ToString(dr["PORT_LOCATION_CD", v]);
			Direction_Ind = ClsConvert.ToString(dr["DIRECTION_IND", v]);
			Invoice_Dt = ClsConvert.ToDateTimeNullable(dr["INVOICE_DT", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["AR_INVOICE_ID"] = ClsConvert.ToDbObject(Ar_Invoice_ID);
			dr["INVOICE_NO"] = ClsConvert.ToDbObject(Invoice_No);
			dr["CUSTOMER_CD"] = ClsConvert.ToDbObject(Customer_Cd);
			dr["VOYAGE_NO"] = ClsConvert.ToDbObject(Voyage_No);
			dr["CREATE_USER"] = ClsConvert.ToDbObject(Create_User);
			dr["CREATE_DT"] = ClsConvert.ToDbObject(Create_Dt);
			dr["MODIFY_USER"] = ClsConvert.ToDbObject(Modify_User);
			dr["MODIFY_DT"] = ClsConvert.ToDbObject(Modify_Dt);
			dr["PORT_LOCATION_CD"] = ClsConvert.ToDbObject(Port_Location_Cd);
			dr["DIRECTION_IND"] = ClsConvert.ToDbObject(Direction_Ind);
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

		public static ClsArInvoice GetUsingKey(Int64 Ar_Invoice_ID)
		{
			object[] vals = new object[] {Ar_Invoice_ID};
			DataRow dr = Connection.GetDataRowUsingKey
				(TableName, GetPrimaryKeys(), vals);
			return ( dr == null ) ? null : new ClsArInvoice(dr);
		}
		public static DataTable GetAll(string Customer_Cd, string Port_Location_Cd)
		{
			List<DbParameter> lst = new List<DbParameter>();	
			StringBuilder sb = new StringBuilder();
		
			if( string.IsNullOrEmpty(Customer_Cd) == false )
			{
				lst.Add(Connection.GetParameter("@CUSTOMER_CD", Customer_Cd));
				sb.Append(" WHERE T_AR_INVOICE.CUSTOMER_CD=@CUSTOMER_CD");
			}
			if( string.IsNullOrEmpty(Port_Location_Cd) == false )
			{
				lst.Add(Connection.GetParameter("@PORT_LOCATION_CD", Port_Location_Cd));
				sb.AppendFormat(" {0} T_AR_INVOICE.PORT_LOCATION_CD=@PORT_LOCATION_CD",
					sb.Length > 0 ? "AND" : "WHERE");
			}
			sb.Insert(0, SelectSQL);
			return Connection.GetDataTable(sb.ToString(), lst.ToArray());
		}
		#endregion		// #region Static Methods
	}
}