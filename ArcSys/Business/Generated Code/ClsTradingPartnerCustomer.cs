using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsTradingPartnerCustomer : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ArcSys"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "R_TRADING_PARTNER_CUSTOMER";
		public const int PrimaryKeyCount = 2;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] { "TRADING_PARTNER_CD", "CUSTOMER_CD" };
		}

		public const string SelectSQL = @"SELECT * FROM R_TRADING_PARTNER_CUSTOMER 
				INNER JOIN R_TRADING_PARTNER
				ON R_TRADING_PARTNER_CUSTOMER.TRADING_PARTNER_CD=R_TRADING_PARTNER.TRADING_PARTNER_CD
				INNER JOIN R_CUSTOMER
				ON R_TRADING_PARTNER_CUSTOMER.CUSTOMER_CD=R_CUSTOMER.CUSTOMER_CD ";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Trading_Partner_CdMax = 10;
		public const int Customer_CdMax = 10;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected string _Trading_Partner_Cd;
		protected string _Customer_Cd;

		#endregion	// #region Column Fields

		#region Column Properties

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

		#endregion	// #region Column Properties

		#region Foreign Key Fields

		protected ClsTradingPartner _Trading_Partner;
		protected ClsCustomer _Customer;

		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties

		public ClsTradingPartner Trading_Partner
		{
			get
			{
				if( Trading_Partner_Cd == null )
					_Trading_Partner = null;
				else if( _Trading_Partner == null ||
					_Trading_Partner.Trading_Partner_Cd != Trading_Partner_Cd )
					_Trading_Partner = ClsTradingPartner.GetUsingKey(Trading_Partner_Cd);
				return _Trading_Partner;
			}
			set
			{
				if( _Trading_Partner == value ) return;
		
				_Trading_Partner = value;
			}
		}
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

		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsTradingPartnerCustomer() : base() {}
		public ClsTradingPartnerCustomer(DataRow dr) : base(dr) {}
		public ClsTradingPartnerCustomer(ClsTradingPartnerCustomer src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Trading_Partner_Cd = null;
			Customer_Cd = null;
		}

		public void CopyFrom(ClsTradingPartnerCustomer src)
		{
			Trading_Partner_Cd = src._Trading_Partner_Cd;
			Customer_Cd = src._Customer_Cd;
		}

		public override bool ReloadFromDB()
		{
			ClsTradingPartnerCustomer tmp = ClsTradingPartnerCustomer.GetUsingKey(Trading_Partner_Cd, Customer_Cd);
			if( tmp != null ) CopyFrom(tmp);

			ResetFKs();
			OnReload();

			return ( tmp != null );
		}

		public override void ResetFKs()
		{
			_Trading_Partner = null;
			_Customer = null;
		}
		#endregion		// #region Init methods

		#region Insert, Update, Delete

		public override int Insert()
		{

			DbParameter[] p = new DbParameter[2];

			p[0] = Connection.GetParameter
				("@TRADING_PARTNER_CD", Trading_Partner_Cd);
			p[1] = Connection.GetParameter
				("@CUSTOMER_CD", Customer_Cd);

			const string sql = @"
				INSERT INTO R_TRADING_PARTNER_CUSTOMER
					(TRADING_PARTNER_CD, CUSTOMER_CD)
				VALUES
					(@TRADING_PARTNER_CD, @CUSTOMER_CD)
				RETURNING
					
				INTO
					";
			int ret = Connection.RunSQL(sql, p);


			return ret;
		}
		public override int Update()
		{
			DbParameter[] p = new DbParameter[2];

			p[0] = Connection.GetParameter
				("@TRADING_PARTNER_CD", Trading_Partner_Cd);
			p[1] = Connection.GetParameter
				("@CUSTOMER_CD", Customer_Cd);

			const string sql = @"
				UPDATE R_TRADING_PARTNER_CUSTOMER SET
					
				WHERE
					TRADING_PARTNER_CD = @TRADING_PARTNER_CD AND
					CUSTOMER_CD = @CUSTOMER_CD
				RETURNING
					
				INTO
					";
			int ret = Connection.RunSQL(sql, p);


			return ret;
		}
		public override int Delete()
		{
			DbParameter[] p = new DbParameter[2];

			p[0] = Connection.GetParameter
				("@TRADING_PARTNER_CD", Trading_Partner_Cd);
			p[1] = Connection.GetParameter
				("@CUSTOMER_CD", Customer_Cd);

			const string sql = @"
				DELETE FROM R_TRADING_PARTNER_CUSTOMER WHERE
				TRADING_PARTNER_CD=@TRADING_PARTNER_CD AND CUSTOMER_CD=@CUSTOMER_CD";
			return Connection.RunSQL(sql, p);
		}
		#endregion		// #region Insert, Update, Delete

		#region Conversion methods

		public override void LoadFromDataReader(DbDataReader dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataReader: DataReader parameter was null");

			Trading_Partner_Cd = ClsConvert.ToString(dr["TRADING_PARTNER_CD"]);
			Customer_Cd = ClsConvert.ToString(dr["CUSTOMER_CD"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Trading_Partner_Cd = ClsConvert.ToString(dr["TRADING_PARTNER_CD", v]);
			Customer_Cd = ClsConvert.ToString(dr["CUSTOMER_CD", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["TRADING_PARTNER_CD"] = ClsConvert.ToDbObject(Trading_Partner_Cd);
			dr["CUSTOMER_CD"] = ClsConvert.ToDbObject(Customer_Cd);
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

		public static ClsTradingPartnerCustomer GetUsingKey(string Trading_Partner_Cd, string Customer_Cd)
		{
			object[] vals = new object[] {Trading_Partner_Cd, Customer_Cd};
			DataRow dr = Connection.GetDataRowUsingKey
				(TableName, GetPrimaryKeys(), vals);
			return ( dr == null ) ? null : new ClsTradingPartnerCustomer(dr);
		}
		public static DataTable GetAll(string Trading_Partner_Cd, string Customer_Cd)
		{
			List<DbParameter> lst = new List<DbParameter>();	
			StringBuilder sb = new StringBuilder();
		
			if( string.IsNullOrEmpty(Trading_Partner_Cd) == false )
			{
				lst.Add(Connection.GetParameter("@TRADING_PARTNER_CD", Trading_Partner_Cd));
				sb.Append(" WHERE R_TRADING_PARTNER_CUSTOMER.TRADING_PARTNER_CD=@TRADING_PARTNER_CD");
			}
			if( string.IsNullOrEmpty(Customer_Cd) == false )
			{
				lst.Add(Connection.GetParameter("@CUSTOMER_CD", Customer_Cd));
				sb.AppendFormat(" {0} R_TRADING_PARTNER_CUSTOMER.CUSTOMER_CD=@CUSTOMER_CD",
					sb.Length > 0 ? "AND" : "WHERE");
			}
			sb.Insert(0, SelectSQL);
			return Connection.GetDataTable(sb.ToString(), lst.ToArray());
		}
		#endregion		// #region Static Methods
	}
}