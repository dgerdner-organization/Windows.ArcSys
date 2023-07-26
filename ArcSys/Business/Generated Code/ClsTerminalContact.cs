using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsTerminalContact : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ArcSys"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "R_TERMINAL_CONTACT";
		public const int PrimaryKeyCount = 1;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] { "TERMINAL_CONTACT_ID" };
		}

		public const string SelectSQL = @"SELECT * FROM R_TERMINAL_CONTACT 
				INNER JOIN R_TERMINAL
				ON R_TERMINAL_CONTACT.TERMINAL_CD=R_TERMINAL.TERMINAL_CD
				INNER JOIN R_TERMINAL_SECTION
				ON R_TERMINAL_CONTACT.TERMINAL_SECTION_CD=R_TERMINAL_SECTION.TERMINAL_SECTION_CD ";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Terminal_CdMax = 10;
		public const int Terminal_Section_CdMax = 10;
		public const int Phone_DscMax = 50;
		public const int PhoneMax = 25;
		public const int Create_UserMax = 30;
		public const int Modify_UserMax = 30;
		public const int Active_FlgMax = 1;
		public const int Phone_ExtMax = 5;
		public const int Contact_NmMax = 50;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected Int64? _Terminal_Contact_ID;
		protected string _Terminal_Cd;
		protected string _Terminal_Section_Cd;
		protected string _Phone_Dsc;
		protected string _Phone;
		protected string _Create_User;
		protected DateTime? _Create_Dt;
		protected string _Modify_User;
		protected DateTime? _Modify_Dt;
		protected string _Active_Flg;
		protected Int16? _Sequence_Nbr;
		protected string _Phone_Ext;
		protected string _Contact_Nm;

		#endregion	// #region Column Fields

		#region Column Properties

		public Int64? Terminal_Contact_ID
		{
			get { return _Terminal_Contact_ID; }
			set
			{
				if( _Terminal_Contact_ID == value ) return;
		
				_Terminal_Contact_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Terminal_Contact_ID");
			}
		}
		public string Terminal_Cd
		{
			get { return _Terminal_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Terminal_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Terminal_CdMax )
					_Terminal_Cd = val.Substring(0, (int)Terminal_CdMax);
				else
					_Terminal_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Terminal_Cd");
			}
		}
		public string Terminal_Section_Cd
		{
			get { return _Terminal_Section_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Terminal_Section_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Terminal_Section_CdMax )
					_Terminal_Section_Cd = val.Substring(0, (int)Terminal_Section_CdMax);
				else
					_Terminal_Section_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Terminal_Section_Cd");
			}
		}
		public string Phone_Dsc
		{
			get { return _Phone_Dsc; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Phone_Dsc, val, false) == 0 ) return;
		
				if( val != null && val.Length > Phone_DscMax )
					_Phone_Dsc = val.Substring(0, (int)Phone_DscMax);
				else
					_Phone_Dsc = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Phone_Dsc");
			}
		}
		public string Phone
		{
			get { return _Phone; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Phone, val, false) == 0 ) return;
		
				if( val != null && val.Length > PhoneMax )
					_Phone = val.Substring(0, (int)PhoneMax);
				else
					_Phone = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Phone");
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
		public string Active_Flg
		{
			get { return _Active_Flg; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Active_Flg, val, false) == 0 ) return;
		
				if( val != null && val.Length > Active_FlgMax )
					_Active_Flg = val.Substring(0, (int)Active_FlgMax);
				else
					_Active_Flg = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Active_Flg");
			}
		}
		public Int16? Sequence_Nbr
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
		public string Phone_Ext
		{
			get { return _Phone_Ext; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Phone_Ext, val, false) == 0 ) return;
		
				if( val != null && val.Length > Phone_ExtMax )
					_Phone_Ext = val.Substring(0, (int)Phone_ExtMax);
				else
					_Phone_Ext = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Phone_Ext");
			}
		}
		public string Contact_Nm
		{
			get { return _Contact_Nm; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Contact_Nm, val, false) == 0 ) return;
		
				if( val != null && val.Length > Contact_NmMax )
					_Contact_Nm = val.Substring(0, (int)Contact_NmMax);
				else
					_Contact_Nm = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Contact_Nm");
			}
		}

		#endregion	// #region Column Properties

		#region Foreign Key Fields

		protected ClsTerminal _Terminal;
		protected ClsTerminalSection _Terminal_Section;

		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties

		public ClsTerminal Terminal
		{
			get
			{
				if( Terminal_Cd == null )
					_Terminal = null;
				else if( _Terminal == null ||
					_Terminal.Terminal_Cd != Terminal_Cd )
					_Terminal = ClsTerminal.GetUsingKey(Terminal_Cd);
				return _Terminal;
			}
			set
			{
				if( _Terminal == value ) return;
		
				_Terminal = value;
			}
		}
		public ClsTerminalSection Terminal_Section
		{
			get
			{
				if( Terminal_Section_Cd == null )
					_Terminal_Section = null;
				else if( _Terminal_Section == null ||
					_Terminal_Section.Terminal_Section_Cd != Terminal_Section_Cd )
					_Terminal_Section = ClsTerminalSection.GetUsingKey(Terminal_Section_Cd);
				return _Terminal_Section;
			}
			set
			{
				if( _Terminal_Section == value ) return;
		
				_Terminal_Section = value;
			}
		}

		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsTerminalContact() : base() {}
		public ClsTerminalContact(DataRow dr) : base(dr) {}
		public ClsTerminalContact(ClsTerminalContact src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Terminal_Contact_ID = null;
			Terminal_Cd = null;
			Terminal_Section_Cd = null;
			Phone_Dsc = null;
			Phone = null;
			Create_User = null;
			Create_Dt = null;
			Modify_User = null;
			Modify_Dt = null;
			Active_Flg = null;
			Sequence_Nbr = null;
			Phone_Ext = null;
			Contact_Nm = null;
		}

		public void CopyFrom(ClsTerminalContact src)
		{
			Terminal_Contact_ID = src._Terminal_Contact_ID;
			Terminal_Cd = src._Terminal_Cd;
			Terminal_Section_Cd = src._Terminal_Section_Cd;
			Phone_Dsc = src._Phone_Dsc;
			Phone = src._Phone;
			Create_User = src._Create_User;
			Create_Dt = src._Create_Dt;
			Modify_User = src._Modify_User;
			Modify_Dt = src._Modify_Dt;
			Active_Flg = src._Active_Flg;
			Sequence_Nbr = src._Sequence_Nbr;
			Phone_Ext = src._Phone_Ext;
			Contact_Nm = src._Contact_Nm;
		}

		public override bool ReloadFromDB()
		{
			ClsTerminalContact tmp = ClsTerminalContact.GetUsingKey(Terminal_Contact_ID.Value);
			if( tmp != null ) CopyFrom(tmp);

			ResetFKs();
			OnReload();

			return ( tmp != null );
		}

		public override void ResetFKs()
		{
			_Terminal = null;
			_Terminal_Section = null;
		}
		#endregion		// #region Init methods

		#region Insert, Update, Delete

		public override int Insert()
		{

			DbParameter[] p = new DbParameter[13];

			p[0] = Connection.GetParameter
				("@TERMINAL_CD", Terminal_Cd);
			p[1] = Connection.GetParameter
				("@TERMINAL_SECTION_CD", Terminal_Section_Cd);
			p[2] = Connection.GetParameter
				("@PHONE_DSC", Phone_Dsc);
			p[3] = Connection.GetParameter
				("@PHONE", Phone);
			p[4] = Connection.GetParameter
				("@ACTIVE_FLG", Active_Flg);
			p[5] = Connection.GetParameter
				("@SEQUENCE_NBR", Sequence_Nbr);
			p[6] = Connection.GetParameter
				("@PHONE_EXT", Phone_Ext);
			p[7] = Connection.GetParameter
				("@CONTACT_NM", Contact_Nm);
			p[8] = Connection.GetParameter
				("@TERMINAL_CONTACT_ID", Terminal_Contact_ID, ParameterDirection.Output, DbType.Int64, 0);
			p[9] = Connection.GetParameter
				("@CREATE_USER", Create_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Create_UserMax);
			p[10] = Connection.GetParameter
				("@CREATE_DT", Create_Dt, ParameterDirection.Output, DbType.DateTime, 0);
			p[11] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);
			p[12] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.Output, DbType.DateTime, 0);

			const string sql = @"
				INSERT INTO R_TERMINAL_CONTACT
					(TERMINAL_CONTACT_ID, TERMINAL_CD, TERMINAL_SECTION_CD,
					PHONE_DSC, PHONE, ACTIVE_FLG,
					SEQUENCE_NBR, PHONE_EXT, CONTACT_NM)
				VALUES
					(TERMINAL_CONTACT_ID_SEQ.NEXTVAL, @TERMINAL_CD, @TERMINAL_SECTION_CD,
					@PHONE_DSC, @PHONE, @ACTIVE_FLG,
					@SEQUENCE_NBR, @PHONE_EXT, @CONTACT_NM)
				RETURNING
					TERMINAL_CONTACT_ID, CREATE_USER, CREATE_DT,
					MODIFY_USER, MODIFY_DT
				INTO
					@TERMINAL_CONTACT_ID, @CREATE_USER, @CREATE_DT,
					@MODIFY_USER, @MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Terminal_Contact_ID = ClsConvert.ToInt64Nullable(p[8].Value);
			Create_User = ClsConvert.ToString(p[9].Value);
			Create_Dt = ClsConvert.ToDateTimeNullable(p[10].Value);
			Modify_User = ClsConvert.ToString(p[11].Value);
			Modify_Dt = ClsConvert.ToDateTimeNullable(p[12].Value);
			return ret;
		}
		public override int Update()
		{
			DbParameter[] p = new DbParameter[11];

			p[0] = Connection.GetParameter
				("@TERMINAL_CD", Terminal_Cd);
			p[1] = Connection.GetParameter
				("@TERMINAL_SECTION_CD", Terminal_Section_Cd);
			p[2] = Connection.GetParameter
				("@PHONE_DSC", Phone_Dsc);
			p[3] = Connection.GetParameter
				("@PHONE", Phone);
			p[4] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.InputOutput, DbType.DateTime, 0);
			p[5] = Connection.GetParameter
				("@ACTIVE_FLG", Active_Flg);
			p[6] = Connection.GetParameter
				("@SEQUENCE_NBR", Sequence_Nbr);
			p[7] = Connection.GetParameter
				("@PHONE_EXT", Phone_Ext);
			p[8] = Connection.GetParameter
				("@CONTACT_NM", Contact_Nm);
			p[9] = Connection.GetParameter
				("@TERMINAL_CONTACT_ID", Terminal_Contact_ID);
			p[10] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);

			const string sql = @"
				UPDATE R_TERMINAL_CONTACT SET
					TERMINAL_CD = @TERMINAL_CD,
					TERMINAL_SECTION_CD = @TERMINAL_SECTION_CD,
					PHONE_DSC = @PHONE_DSC,
					PHONE = @PHONE,
					MODIFY_DT = @MODIFY_DT,
					ACTIVE_FLG = @ACTIVE_FLG,
					SEQUENCE_NBR = @SEQUENCE_NBR,
					PHONE_EXT = @PHONE_EXT,
					CONTACT_NM = @CONTACT_NM
				WHERE
					TERMINAL_CONTACT_ID = @TERMINAL_CONTACT_ID
				RETURNING
					MODIFY_USER, MODIFY_DT
				INTO
					@MODIFY_USER, @MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Modify_Dt = ClsConvert.ToDateTimeNullable(p[4].Value);
			Modify_User = ClsConvert.ToString(p[10].Value);
			return ret;
		}
		public override int Delete()
		{
			DbParameter[] p = new DbParameter[1];

			p[0] = Connection.GetParameter
				("@TERMINAL_CONTACT_ID", Terminal_Contact_ID);

			const string sql = @"
				DELETE FROM R_TERMINAL_CONTACT WHERE
				TERMINAL_CONTACT_ID=@TERMINAL_CONTACT_ID";
			return Connection.RunSQL(sql, p);
		}
		#endregion		// #region Insert, Update, Delete

		#region Conversion methods

		public override void LoadFromDataReader(DbDataReader dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataReader: DataReader parameter was null");

			Terminal_Contact_ID = ClsConvert.ToInt64Nullable(dr["TERMINAL_CONTACT_ID"]);
			Terminal_Cd = ClsConvert.ToString(dr["TERMINAL_CD"]);
			Terminal_Section_Cd = ClsConvert.ToString(dr["TERMINAL_SECTION_CD"]);
			Phone_Dsc = ClsConvert.ToString(dr["PHONE_DSC"]);
			Phone = ClsConvert.ToString(dr["PHONE"]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER"]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT"]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER"]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT"]);
			Active_Flg = ClsConvert.ToString(dr["ACTIVE_FLG"]);
			Sequence_Nbr = ClsConvert.ToInt16Nullable(dr["SEQUENCE_NBR"]);
			Phone_Ext = ClsConvert.ToString(dr["PHONE_EXT"]);
			Contact_Nm = ClsConvert.ToString(dr["CONTACT_NM"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Terminal_Contact_ID = ClsConvert.ToInt64Nullable(dr["TERMINAL_CONTACT_ID", v]);
			Terminal_Cd = ClsConvert.ToString(dr["TERMINAL_CD", v]);
			Terminal_Section_Cd = ClsConvert.ToString(dr["TERMINAL_SECTION_CD", v]);
			Phone_Dsc = ClsConvert.ToString(dr["PHONE_DSC", v]);
			Phone = ClsConvert.ToString(dr["PHONE", v]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER", v]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT", v]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER", v]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT", v]);
			Active_Flg = ClsConvert.ToString(dr["ACTIVE_FLG", v]);
			Sequence_Nbr = ClsConvert.ToInt16Nullable(dr["SEQUENCE_NBR", v]);
			Phone_Ext = ClsConvert.ToString(dr["PHONE_EXT", v]);
			Contact_Nm = ClsConvert.ToString(dr["CONTACT_NM", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["TERMINAL_CONTACT_ID"] = ClsConvert.ToDbObject(Terminal_Contact_ID);
			dr["TERMINAL_CD"] = ClsConvert.ToDbObject(Terminal_Cd);
			dr["TERMINAL_SECTION_CD"] = ClsConvert.ToDbObject(Terminal_Section_Cd);
			dr["PHONE_DSC"] = ClsConvert.ToDbObject(Phone_Dsc);
			dr["PHONE"] = ClsConvert.ToDbObject(Phone);
			dr["CREATE_USER"] = ClsConvert.ToDbObject(Create_User);
			dr["CREATE_DT"] = ClsConvert.ToDbObject(Create_Dt);
			dr["MODIFY_USER"] = ClsConvert.ToDbObject(Modify_User);
			dr["MODIFY_DT"] = ClsConvert.ToDbObject(Modify_Dt);
			dr["ACTIVE_FLG"] = ClsConvert.ToDbObject(Active_Flg);
			dr["SEQUENCE_NBR"] = ClsConvert.ToDbObject(Sequence_Nbr);
			dr["PHONE_EXT"] = ClsConvert.ToDbObject(Phone_Ext);
			dr["CONTACT_NM"] = ClsConvert.ToDbObject(Contact_Nm);
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

		public static ClsTerminalContact GetUsingKey(Int64 Terminal_Contact_ID)
		{
			object[] vals = new object[] {Terminal_Contact_ID};
			DataRow dr = Connection.GetDataRowUsingKey
				(TableName, GetPrimaryKeys(), vals);
			return ( dr == null ) ? null : new ClsTerminalContact(dr);
		}
		public static DataTable GetAll(string Terminal_Cd, string Terminal_Section_Cd)
		{
			List<DbParameter> lst = new List<DbParameter>();	
			StringBuilder sb = new StringBuilder();
		
			if( string.IsNullOrEmpty(Terminal_Cd) == false )
			{
				lst.Add(Connection.GetParameter("@TERMINAL_CD", Terminal_Cd));
				sb.Append(" WHERE R_TERMINAL_CONTACT.TERMINAL_CD=@TERMINAL_CD");
			}
			if( string.IsNullOrEmpty(Terminal_Section_Cd) == false )
			{
				lst.Add(Connection.GetParameter("@TERMINAL_SECTION_CD", Terminal_Section_Cd));
				sb.AppendFormat(" {0} R_TERMINAL_CONTACT.TERMINAL_SECTION_CD=@TERMINAL_SECTION_CD",
					sb.Length > 0 ? "AND" : "WHERE");
			}
			sb.Insert(0, SelectSQL);
			return Connection.GetDataTable(sb.ToString(), lst.ToArray());
		}
		#endregion		// #region Static Methods
	}
}