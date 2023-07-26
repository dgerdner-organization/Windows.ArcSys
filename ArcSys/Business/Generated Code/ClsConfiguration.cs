using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsConfiguration : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ArcSys"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "R_CONFIGURATION";
		public const int PrimaryKeyCount = 1;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] { "CONFIG_ID" };
		}

		public const string SelectSQL = "SELECT * FROM R_CONFIGURATION";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Purpose_CdMax = 10;
		public const int Config_01Max = 50;
		public const int Config_02Max = 50;
		public const int Config_03Max = 50;
		public const int Config_04Max = 50;
		public const int Comment_TxtMax = 200;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected Int64? _Config_ID;
		protected string _Purpose_Cd;
		protected string _Config_01;
		protected string _Config_02;
		protected string _Config_03;
		protected string _Config_04;
		protected string _Comment_Txt;

		#endregion	// #region Column Fields

		#region Column Properties

		public Int64? Config_ID
		{
			get { return _Config_ID; }
			set
			{
				if( _Config_ID == value ) return;
		
				_Config_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Config_ID");
			}
		}
		public string Purpose_Cd
		{
			get { return _Purpose_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Purpose_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Purpose_CdMax )
					_Purpose_Cd = val.Substring(0, (int)Purpose_CdMax);
				else
					_Purpose_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Purpose_Cd");
			}
		}
		public string Config_01
		{
			get { return _Config_01; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Config_01, val, false) == 0 ) return;
		
				if( val != null && val.Length > Config_01Max )
					_Config_01 = val.Substring(0, (int)Config_01Max);
				else
					_Config_01 = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Config_01");
			}
		}
		public string Config_02
		{
			get { return _Config_02; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Config_02, val, false) == 0 ) return;
		
				if( val != null && val.Length > Config_02Max )
					_Config_02 = val.Substring(0, (int)Config_02Max);
				else
					_Config_02 = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Config_02");
			}
		}
		public string Config_03
		{
			get { return _Config_03; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Config_03, val, false) == 0 ) return;
		
				if( val != null && val.Length > Config_03Max )
					_Config_03 = val.Substring(0, (int)Config_03Max);
				else
					_Config_03 = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Config_03");
			}
		}
		public string Config_04
		{
			get { return _Config_04; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Config_04, val, false) == 0 ) return;
		
				if( val != null && val.Length > Config_04Max )
					_Config_04 = val.Substring(0, (int)Config_04Max);
				else
					_Config_04 = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Config_04");
			}
		}
		public string Comment_Txt
		{
			get { return _Comment_Txt; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Comment_Txt, val, false) == 0 ) return;
		
				if( val != null && val.Length > Comment_TxtMax )
					_Comment_Txt = val.Substring(0, (int)Comment_TxtMax);
				else
					_Comment_Txt = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Comment_Txt");
			}
		}

		#endregion	// #region Column Properties

		#region Foreign Key Fields



		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties



		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsConfiguration() : base() {}
		public ClsConfiguration(DataRow dr) : base(dr) {}
		public ClsConfiguration(ClsConfiguration src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Config_ID = null;
			Purpose_Cd = null;
			Config_01 = null;
			Config_02 = null;
			Config_03 = null;
			Config_04 = null;
			Comment_Txt = null;
		}

		public void CopyFrom(ClsConfiguration src)
		{
			Config_ID = src._Config_ID;
			Purpose_Cd = src._Purpose_Cd;
			Config_01 = src._Config_01;
			Config_02 = src._Config_02;
			Config_03 = src._Config_03;
			Config_04 = src._Config_04;
			Comment_Txt = src._Comment_Txt;
		}

		public override bool ReloadFromDB()
		{
			ClsConfiguration tmp = ClsConfiguration.GetUsingKey(Config_ID.Value);
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

			DbParameter[] p = new DbParameter[7];

			p[0] = Connection.GetParameter
				("@CONFIG_ID", Config_ID);
			p[1] = Connection.GetParameter
				("@PURPOSE_CD", Purpose_Cd);
			p[2] = Connection.GetParameter
				("@CONFIG_01", Config_01);
			p[3] = Connection.GetParameter
				("@CONFIG_02", Config_02);
			p[4] = Connection.GetParameter
				("@CONFIG_03", Config_03);
			p[5] = Connection.GetParameter
				("@CONFIG_04", Config_04);
			p[6] = Connection.GetParameter
				("@COMMENT_TXT", Comment_Txt);

			const string sql = @"
				INSERT INTO R_CONFIGURATION
					(CONFIG_ID, PURPOSE_CD, CONFIG_01,
					CONFIG_02, CONFIG_03, CONFIG_04,
					COMMENT_TXT)
				VALUES
					(@CONFIG_ID, @PURPOSE_CD, @CONFIG_01,
					@CONFIG_02, @CONFIG_03, @CONFIG_04,
					@COMMENT_TXT)

					";
			int ret = Connection.RunSQL(sql, p);


			return ret;
		}
		public override int Update()
		{
			DbParameter[] p = new DbParameter[7];

			p[0] = Connection.GetParameter
				("@PURPOSE_CD", Purpose_Cd);
			p[1] = Connection.GetParameter
				("@CONFIG_01", Config_01);
			p[2] = Connection.GetParameter
				("@CONFIG_02", Config_02);
			p[3] = Connection.GetParameter
				("@CONFIG_03", Config_03);
			p[4] = Connection.GetParameter
				("@CONFIG_04", Config_04);
			p[5] = Connection.GetParameter
				("@COMMENT_TXT", Comment_Txt);
			p[6] = Connection.GetParameter
				("@CONFIG_ID", Config_ID);

			const string sql = @"
				UPDATE R_CONFIGURATION SET
					PURPOSE_CD = @PURPOSE_CD,
					CONFIG_01 = @CONFIG_01,
					CONFIG_02 = @CONFIG_02,
					CONFIG_03 = @CONFIG_03,
					CONFIG_04 = @CONFIG_04,
					COMMENT_TXT = @COMMENT_TXT
				WHERE
					CONFIG_ID = @CONFIG_ID
					";
			int ret = Connection.RunSQL(sql, p);


			return ret;
		}
		public override int Delete()
		{
			DbParameter[] p = new DbParameter[1];

			p[0] = Connection.GetParameter
				("@CONFIG_ID", Config_ID);

			const string sql = @"
				DELETE FROM R_CONFIGURATION WHERE
				CONFIG_ID=@CONFIG_ID";
			return Connection.RunSQL(sql, p);
		}
		#endregion		// #region Insert, Update, Delete

		#region Conversion methods

		public override void LoadFromDataReader(DbDataReader dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataReader: DataReader parameter was null");

			Config_ID = ClsConvert.ToInt64Nullable(dr["CONFIG_ID"]);
			Purpose_Cd = ClsConvert.ToString(dr["PURPOSE_CD"]);
			Config_01 = ClsConvert.ToString(dr["CONFIG_01"]);
			Config_02 = ClsConvert.ToString(dr["CONFIG_02"]);
			Config_03 = ClsConvert.ToString(dr["CONFIG_03"]);
			Config_04 = ClsConvert.ToString(dr["CONFIG_04"]);
			Comment_Txt = ClsConvert.ToString(dr["COMMENT_TXT"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Config_ID = ClsConvert.ToInt64Nullable(dr["CONFIG_ID", v]);
			Purpose_Cd = ClsConvert.ToString(dr["PURPOSE_CD", v]);
			Config_01 = ClsConvert.ToString(dr["CONFIG_01", v]);
			Config_02 = ClsConvert.ToString(dr["CONFIG_02", v]);
			Config_03 = ClsConvert.ToString(dr["CONFIG_03", v]);
			Config_04 = ClsConvert.ToString(dr["CONFIG_04", v]);
			Comment_Txt = ClsConvert.ToString(dr["COMMENT_TXT", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["CONFIG_ID"] = ClsConvert.ToDbObject(Config_ID);
			dr["PURPOSE_CD"] = ClsConvert.ToDbObject(Purpose_Cd);
			dr["CONFIG_01"] = ClsConvert.ToDbObject(Config_01);
			dr["CONFIG_02"] = ClsConvert.ToDbObject(Config_02);
			dr["CONFIG_03"] = ClsConvert.ToDbObject(Config_03);
			dr["CONFIG_04"] = ClsConvert.ToDbObject(Config_04);
			dr["COMMENT_TXT"] = ClsConvert.ToDbObject(Comment_Txt);
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

		public static ClsConfiguration GetUsingKey(Int64 Config_ID)
		{
			object[] vals = new object[] {Config_ID};
			DataRow dr = Connection.GetDataRowUsingKey
				(TableName, GetPrimaryKeys(), vals);
			return ( dr == null ) ? null : new ClsConfiguration(dr);
		}

		#endregion		// #region Static Methods
	}
}