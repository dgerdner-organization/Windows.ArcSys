using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ACMS.Business
{
	public partial class ClsPartnerEmailList : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ACMS"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "R_PARTNER_EMAIL_LIST";
		public const int PrimaryKeyCount = 2;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] { "PARTNER_CD", "EMAIL_LIST_CD" };
		}

		public const string SelectSQL = "SELECT * FROM R_PARTNER_EMAIL_LIST";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Partner_CdMax = 15;
		public const int Email_List_CdMax = 5;
		public const int List_DscMax = 30;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected string _Partner_Cd;
		protected string _Email_List_Cd;
		protected string _List_Dsc;

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
		public string Email_List_Cd
		{
			get { return _Email_List_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Email_List_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Email_List_CdMax )
					_Email_List_Cd = val.Substring(0, (int)Email_List_CdMax);
				else
					_Email_List_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Email_List_Cd");
			}
		}
		public string List_Dsc
		{
			get { return _List_Dsc; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_List_Dsc, val, false) == 0 ) return;
		
				if( val != null && val.Length > List_DscMax )
					_List_Dsc = val.Substring(0, (int)List_DscMax);
				else
					_List_Dsc = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("List_Dsc");
			}
		}

		#endregion	// #region Column Properties

		#region Foreign Key Fields



		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties



		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsPartnerEmailList() : base() {}
		public ClsPartnerEmailList(DataRow dr) : base(dr) {}
		public ClsPartnerEmailList(ClsPartnerEmailList src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Partner_Cd = null;
			Email_List_Cd = null;
			List_Dsc = null;
		}

		public void CopyFrom(ClsPartnerEmailList src)
		{
			Partner_Cd = src._Partner_Cd;
			Email_List_Cd = src._Email_List_Cd;
			List_Dsc = src._List_Dsc;
		}

		public override bool ReloadFromDB()
		{
			ClsPartnerEmailList tmp = ClsPartnerEmailList.GetUsingKey(Partner_Cd, Email_List_Cd);
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
				("@EMAIL_LIST_CD", Email_List_Cd);
			p[2] = Connection.GetParameter
				("@LIST_DSC", List_Dsc);

			const string sql = @"
				INSERT INTO R_PARTNER_EMAIL_LIST
					(PARTNER_CD, EMAIL_LIST_CD, LIST_DSC)
				VALUES
					(@PARTNER_CD, @EMAIL_LIST_CD, @LIST_DSC)
				RETURNING
					
				INTO
					";
			int ret = Connection.RunSQL(sql, p);


			return ret;
		}
		public override int Update()
		{
			DbParameter[] p = new DbParameter[3];

			p[0] = Connection.GetParameter
				("@LIST_DSC", List_Dsc);
			p[1] = Connection.GetParameter
				("@PARTNER_CD", Partner_Cd);
			p[2] = Connection.GetParameter
				("@EMAIL_LIST_CD", Email_List_Cd);

			const string sql = @"
				UPDATE R_PARTNER_EMAIL_LIST SET
					LIST_DSC = @LIST_DSC
				WHERE
					PARTNER_CD = @PARTNER_CD AND
					EMAIL_LIST_CD = @EMAIL_LIST_CD
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
				("@PARTNER_CD", Partner_Cd);
			p[1] = Connection.GetParameter
				("@EMAIL_LIST_CD", Email_List_Cd);

			const string sql = @"
				DELETE FROM R_PARTNER_EMAIL_LIST WHERE
				PARTNER_CD=@PARTNER_CD AND EMAIL_LIST_CD=@EMAIL_LIST_CD";
			return Connection.RunSQL(sql, p);
		}
		#endregion		// #region Insert, Update, Delete

		#region Conversion methods

		public override void LoadFromDataReader(DbDataReader dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataReader: DataReader parameter was null");

			Partner_Cd = ClsConvert.ToString(dr["PARTNER_CD"]);
			Email_List_Cd = ClsConvert.ToString(dr["EMAIL_LIST_CD"]);
			List_Dsc = ClsConvert.ToString(dr["LIST_DSC"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Partner_Cd = ClsConvert.ToString(dr["PARTNER_CD", v]);
			Email_List_Cd = ClsConvert.ToString(dr["EMAIL_LIST_CD", v]);
			List_Dsc = ClsConvert.ToString(dr["LIST_DSC", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["PARTNER_CD"] = ClsConvert.ToDbObject(Partner_Cd);
			dr["EMAIL_LIST_CD"] = ClsConvert.ToDbObject(Email_List_Cd);
			dr["LIST_DSC"] = ClsConvert.ToDbObject(List_Dsc);
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

		public static ClsPartnerEmailList GetUsingKey(string Partner_Cd, string Email_List_Cd)
		{
			object[] vals = new object[] {Partner_Cd, Email_List_Cd};
			DataRow dr = Connection.GetDataRowUsingKey
				(TableName, GetPrimaryKeys(), vals);
			return ( dr == null ) ? null : new ClsPartnerEmailList(dr);
		}

		#endregion		// #region Static Methods
	}
}