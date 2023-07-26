using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ACMS.Business
{
	public partial class ClsRevenueCode : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ACMS"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "R_REVENUE_CODE";
		public const int PrimaryKeyCount = 1;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] { "REV_CD" };
		}

		public const string SelectSQL = "SELECT * FROM R_REVENUE_CODE";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Rev_CdMax = 10;
		public const int Rev_DscMax = 50;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected string _Rev_Cd;
		protected string _Rev_Dsc;

		#endregion	// #region Column Fields

		#region Column Properties

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
		public string Rev_Dsc
		{
			get { return _Rev_Dsc; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Rev_Dsc, val, false) == 0 ) return;
		
				if( val != null && val.Length > Rev_DscMax )
					_Rev_Dsc = val.Substring(0, (int)Rev_DscMax);
				else
					_Rev_Dsc = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Rev_Dsc");
			}
		}

		#endregion	// #region Column Properties

		#region Foreign Key Fields



		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties



		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsRevenueCode() : base() {}
		public ClsRevenueCode(DataRow dr) : base(dr) {}
		public ClsRevenueCode(ClsRevenueCode src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Rev_Cd = null;
			Rev_Dsc = null;
		}

		public void CopyFrom(ClsRevenueCode src)
		{
			Rev_Cd = src._Rev_Cd;
			Rev_Dsc = src._Rev_Dsc;
		}

		public override bool ReloadFromDB()
		{
			ClsRevenueCode tmp = ClsRevenueCode.GetUsingKey(Rev_Cd);
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

			DbParameter[] p = new DbParameter[2];

			p[0] = Connection.GetParameter
				("@REV_CD", Rev_Cd);
			p[1] = Connection.GetParameter
				("@REV_DSC", Rev_Dsc);

			const string sql = @"
				INSERT INTO R_REVENUE_CODE
					(REV_CD, REV_DSC)
				VALUES
					(@REV_CD, @REV_DSC)
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
				("@REV_DSC", Rev_Dsc);
			p[1] = Connection.GetParameter
				("@REV_CD", Rev_Cd);

			const string sql = @"
				UPDATE R_REVENUE_CODE SET
					REV_DSC = @REV_DSC
				WHERE
					REV_CD = @REV_CD
				RETURNING
					
				INTO
					";
			int ret = Connection.RunSQL(sql, p);


			return ret;
		}
		public override int Delete()
		{
			DbParameter[] p = new DbParameter[1];

			p[0] = Connection.GetParameter
				("@REV_CD", Rev_Cd);

			const string sql = @"
				DELETE FROM R_REVENUE_CODE WHERE
				REV_CD=@REV_CD";
			return Connection.RunSQL(sql, p);
		}
		#endregion		// #region Insert, Update, Delete

		#region Conversion methods

		public override void LoadFromDataReader(DbDataReader dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataReader: DataReader parameter was null");

			Rev_Cd = ClsConvert.ToString(dr["REV_CD"]);
			Rev_Dsc = ClsConvert.ToString(dr["REV_DSC"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Rev_Cd = ClsConvert.ToString(dr["REV_CD", v]);
			Rev_Dsc = ClsConvert.ToString(dr["REV_DSC", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["REV_CD"] = ClsConvert.ToDbObject(Rev_Cd);
			dr["REV_DSC"] = ClsConvert.ToDbObject(Rev_Dsc);
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

		public static ClsRevenueCode GetUsingKey(string Rev_Cd)
		{
			object[] vals = new object[] {Rev_Cd};
			DataRow dr = Connection.GetDataRowUsingKey
				(TableName, GetPrimaryKeys(), vals);
			return ( dr == null ) ? null : new ClsRevenueCode(dr);
		}

		#endregion		// #region Static Methods
	}
}