using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ACMS.Business
{
	public partial class ClsPartnerEmail : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ACMS"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "R_PARTNER_EMAIL";
		public const int PrimaryKeyCount = 3;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] { "PARTNER_CD", "OUTLOOK_NAME", "EMAIL_LIST_CD" };
		}

		public const string SelectSQL = "SELECT * FROM R_PARTNER_EMAIL";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Partner_CdMax = 15;
		public const int Outlook_NameMax = 50;
		public const int Outlook_EmailMax = 150;
		public const int Email_List_CdMax = 5;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected string _Partner_Cd;
		protected string _Outlook_Name;
		protected string _Outlook_Email;
		protected string _Email_List_Cd;

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
		public string Outlook_Name
		{
			get { return _Outlook_Name; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Outlook_Name, val, false) == 0 ) return;
		
				if( val != null && val.Length > Outlook_NameMax )
					_Outlook_Name = val.Substring(0, (int)Outlook_NameMax);
				else
					_Outlook_Name = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Outlook_Name");
			}
		}
		public string Outlook_Email
		{
			get { return _Outlook_Email; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Outlook_Email, val, false) == 0 ) return;
		
				if( val != null && val.Length > Outlook_EmailMax )
					_Outlook_Email = val.Substring(0, (int)Outlook_EmailMax);
				else
					_Outlook_Email = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Outlook_Email");
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

		#endregion	// #region Column Properties

		#region Foreign Key Fields



		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties



		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsPartnerEmail() : base() {}
		public ClsPartnerEmail(DataRow dr) : base(dr) {}
		public ClsPartnerEmail(ClsPartnerEmail src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Partner_Cd = null;
			Outlook_Name = null;
			Outlook_Email = null;
			Email_List_Cd = null;
		}

		public void CopyFrom(ClsPartnerEmail src)
		{
			Partner_Cd = src._Partner_Cd;
			Outlook_Name = src._Outlook_Name;
			Outlook_Email = src._Outlook_Email;
			Email_List_Cd = src._Email_List_Cd;
		}

		public override bool ReloadFromDB()
		{
			ClsPartnerEmail tmp = ClsPartnerEmail.GetUsingKey(Partner_Cd, Outlook_Name, Email_List_Cd);
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

			DbParameter[] p = new DbParameter[4];

			p[0] = Connection.GetParameter
				("@PARTNER_CD", Partner_Cd);
			p[1] = Connection.GetParameter
				("@OUTLOOK_NAME", Outlook_Name);
			p[2] = Connection.GetParameter
				("@OUTLOOK_EMAIL", Outlook_Email);
			p[3] = Connection.GetParameter
				("@EMAIL_LIST_CD", Email_List_Cd);

			const string sql = @"
				INSERT INTO R_PARTNER_EMAIL
					(PARTNER_CD, OUTLOOK_NAME, OUTLOOK_EMAIL,
					EMAIL_LIST_CD)
				VALUES
					(@PARTNER_CD, @OUTLOOK_NAME, @OUTLOOK_EMAIL,
					@EMAIL_LIST_CD)

					";
			int ret = Connection.RunSQL(sql, p);


			return ret;
		}
		public override int Update()
		{
			DbParameter[] p = new DbParameter[4];

			p[0] = Connection.GetParameter
				("@OUTLOOK_EMAIL", Outlook_Email);
			p[1] = Connection.GetParameter
				("@PARTNER_CD", Partner_Cd);
			p[2] = Connection.GetParameter
				("@OUTLOOK_NAME", Outlook_Name);
			p[3] = Connection.GetParameter
				("@EMAIL_LIST_CD", Email_List_Cd);

			const string sql = @"
				UPDATE R_PARTNER_EMAIL SET
					OUTLOOK_EMAIL = @OUTLOOK_EMAIL
				WHERE
					PARTNER_CD = @PARTNER_CD AND
					OUTLOOK_NAME = @OUTLOOK_NAME AND
					EMAIL_LIST_CD = @EMAIL_LIST_CD
					";
			int ret = Connection.RunSQL(sql, p);


			return ret;
		}
		public override int Delete()
		{
			DbParameter[] p = new DbParameter[3];

			p[0] = Connection.GetParameter
				("@PARTNER_CD", Partner_Cd);
			p[1] = Connection.GetParameter
				("@OUTLOOK_NAME", Outlook_Name);
			p[2] = Connection.GetParameter
				("@EMAIL_LIST_CD", Email_List_Cd);

			const string sql = @"
				DELETE FROM R_PARTNER_EMAIL WHERE
				PARTNER_CD=@PARTNER_CD AND OUTLOOK_NAME=@OUTLOOK_NAME
				 AND EMAIL_LIST_CD=@EMAIL_LIST_CD";
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
			Outlook_Name = ClsConvert.ToString(dr["OUTLOOK_NAME"]);
			Outlook_Email = ClsConvert.ToString(dr["OUTLOOK_EMAIL"]);
			Email_List_Cd = ClsConvert.ToString(dr["EMAIL_LIST_CD"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Partner_Cd = ClsConvert.ToString(dr["PARTNER_CD", v]);
			Outlook_Name = ClsConvert.ToString(dr["OUTLOOK_NAME", v]);
			Outlook_Email = ClsConvert.ToString(dr["OUTLOOK_EMAIL", v]);
			Email_List_Cd = ClsConvert.ToString(dr["EMAIL_LIST_CD", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["PARTNER_CD"] = ClsConvert.ToDbObject(Partner_Cd);
			dr["OUTLOOK_NAME"] = ClsConvert.ToDbObject(Outlook_Name);
			dr["OUTLOOK_EMAIL"] = ClsConvert.ToDbObject(Outlook_Email);
			dr["EMAIL_LIST_CD"] = ClsConvert.ToDbObject(Email_List_Cd);
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

		public static ClsPartnerEmail GetUsingKey(string Partner_Cd, string Outlook_Name, string Email_List_Cd)
		{
			object[] vals = new object[] {Partner_Cd, Outlook_Name, Email_List_Cd};
			DataRow dr = Connection.GetDataRowUsingKey
				(TableName, GetPrimaryKeys(), vals);
			return ( dr == null ) ? null : new ClsPartnerEmail(dr);
		}

		#endregion		// #region Static Methods
	}
}