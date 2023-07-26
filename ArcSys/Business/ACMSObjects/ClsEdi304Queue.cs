using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ACMS.Business
{
	public partial class ClsEdi304Queue : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ACMS"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "T_EDI_304_QUEUE";
		public const int PrimaryKeyCount = 2;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] { "PARTNER_CD", "PARTNER_REQUEST_CD" };
		}

		public const string SelectSQL = "SELECT * FROM T_EDI_304_QUEUE";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Partner_CdMax = 20;
		public const int Partner_Request_CdMax = 20;
		public const int Confirm_FlgMax = 1;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected string _Partner_Cd;
		protected string _Partner_Request_Cd;
		protected string _Confirm_Flg;

		#endregion	// #region Column Fields

		#region Column Properties

		public string Partner_Cd
		{
			get { return _Partner_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Partner_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Partner_CdMax )
					_Partner_Cd = val.Substring(0, (int)Partner_CdMax);
				else
					_Partner_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Partner_Cd");
			}
		}
		public string Partner_Request_Cd
		{
			get { return _Partner_Request_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Partner_Request_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Partner_Request_CdMax )
					_Partner_Request_Cd = val.Substring(0, (int)Partner_Request_CdMax);
				else
					_Partner_Request_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Partner_Request_Cd");
			}
		}
		public string Confirm_Flg
		{
			get { return _Confirm_Flg; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Confirm_Flg, val, false) == 0 ) return;
		
				if( val != null && val.Length > Confirm_FlgMax )
					_Confirm_Flg = val.Substring(0, (int)Confirm_FlgMax);
				else
					_Confirm_Flg = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Confirm_Flg");
			}
		}

		#endregion	// #region Column Properties

		#region Foreign Key Fields



		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties



		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsEdi304Queue() : base() {}
		public ClsEdi304Queue(DataRow dr) : base(dr) {}
		public ClsEdi304Queue(ClsEdi304Queue src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Partner_Cd = null;
			Partner_Request_Cd = null;
			Confirm_Flg = null;
		}

		public void CopyFrom(ClsEdi304Queue src)
		{
			Partner_Cd = src._Partner_Cd;
			Partner_Request_Cd = src._Partner_Request_Cd;
			Confirm_Flg = src._Confirm_Flg;
		}

		public override bool ReloadFromDB()
		{
			ClsEdi304Queue tmp = ClsEdi304Queue.GetUsingKey(Partner_Cd, Partner_Request_Cd);
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

			DbParameter[] p = new DbParameter[3];

			p[0] = Connection.GetParameter
				("@PARTNER_CD", Partner_Cd);
			p[1] = Connection.GetParameter
				("@PARTNER_REQUEST_CD", Partner_Request_Cd);
			p[2] = Connection.GetParameter
				("@CONFIRM_FLG", Confirm_Flg);

			const string sql = @"
				INSERT INTO T_EDI_304_QUEUE
					(PARTNER_CD, PARTNER_REQUEST_CD, CONFIRM_FLG)
				VALUES
					(@PARTNER_CD, @PARTNER_REQUEST_CD, @CONFIRM_FLG)

					";
			int ret = Connection.RunSQL(sql, p);


			return ret;
		}
		public override int Update()
		{
			DbParameter[] p = new DbParameter[3];

			p[0] = Connection.GetParameter
				("@CONFIRM_FLG", Confirm_Flg);
			p[1] = Connection.GetParameter
				("@PARTNER_CD", Partner_Cd);
			p[2] = Connection.GetParameter
				("@PARTNER_REQUEST_CD", Partner_Request_Cd);

			const string sql = @"
				UPDATE T_EDI_304_QUEUE SET
					CONFIRM_FLG = @CONFIRM_FLG
				WHERE
					PARTNER_CD = @PARTNER_CD AND
					PARTNER_REQUEST_CD = @PARTNER_REQUEST_CD
					";
			int ret = Connection.RunSQL(sql, p);


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

			Partner_Cd = ClsConvert.ToString(dr["PARTNER_CD"]);
			Partner_Request_Cd = ClsConvert.ToString(dr["PARTNER_REQUEST_CD"]);
			Confirm_Flg = ClsConvert.ToString(dr["CONFIRM_FLG"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Partner_Cd = ClsConvert.ToString(dr["PARTNER_CD", v]);
			Partner_Request_Cd = ClsConvert.ToString(dr["PARTNER_REQUEST_CD", v]);
			Confirm_Flg = ClsConvert.ToString(dr["CONFIRM_FLG", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["PARTNER_CD"] = ClsConvert.ToDbObject(Partner_Cd);
			dr["PARTNER_REQUEST_CD"] = ClsConvert.ToDbObject(Partner_Request_Cd);
			dr["CONFIRM_FLG"] = ClsConvert.ToDbObject(Confirm_Flg);
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

		public static ClsEdi304Queue GetUsingKey(string Partner_Cd, string Partner_Request_Cd)
		{
			object[] vals = new object[] {Partner_Cd, Partner_Request_Cd};
			DataRow dr = Connection.GetDataRowUsingKey
				(TableName, GetPrimaryKeys(), vals);
			return ( dr == null ) ? null : new ClsEdi304Queue(dr);
		}

		#endregion		// #region Static Methods
	}
}