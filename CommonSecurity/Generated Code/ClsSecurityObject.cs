using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.CommonSecurity
{
	public partial class ClsSecurityObject : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["Security"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "SECURITY.R_SECURITY_OBJECT";
		public const int PrimaryKeyCount = 1;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] { "OBJECT_ID" };
		}

		public const string SelectSQL = "SELECT * FROM SECURITY.R_SECURITY_OBJECT";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Object_DscMax = 50;
		public const int Parent_DscMax = 50;
		public const int Create_UserMax = 30;
		public const int Modify_UserMax = 30;
		public const int Default_Enabled_FlgMax = 1;
		public const int Default_Visible_FlgMax = 1;
		public const int Vendor_Control_FlgMax = 1;
		public const int Finance_FlgMax = 1;
		public const int Object_NmMax = 75;
		public const int Parent_NmMax = 75;
		public const int Collection_DscMax = 50;
		public const int Object_TypeMax = 50;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected Int64? _Object_ID;
		protected string _Object_Dsc;
		protected string _Parent_Dsc;
		protected string _Create_User;
		protected DateTime? _Create_Dt;
		protected string _Modify_User;
		protected DateTime? _Modify_Dt;
		protected string _Default_Enabled_Flg;
		protected string _Default_Visible_Flg;
		protected string _Vendor_Control_Flg;
		protected string _Finance_Flg;
		protected string _Object_Nm;
		protected string _Parent_Nm;
		protected string _Collection_Dsc;
		protected string _Object_Type;

		#endregion	// #region Column Fields

		#region Column Properties

		public Int64? Object_ID
		{
			get { return _Object_ID; }
			set
			{
				if( _Object_ID == value ) return;
		
				_Object_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Object_ID");
			}
		}
		public string Object_Dsc
		{
			get { return _Object_Dsc; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Object_Dsc, val, false) == 0 ) return;
		
				if( val != null && val.Length > Object_DscMax )
					_Object_Dsc = val.Substring(0, (int)Object_DscMax);
				else
					_Object_Dsc = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Object_Dsc");
			}
		}
		public string Parent_Dsc
		{
			get { return _Parent_Dsc; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Parent_Dsc, val, false) == 0 ) return;
		
				if( val != null && val.Length > Parent_DscMax )
					_Parent_Dsc = val.Substring(0, (int)Parent_DscMax);
				else
					_Parent_Dsc = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Parent_Dsc");
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
		public string Default_Enabled_Flg
		{
			get { return _Default_Enabled_Flg; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Default_Enabled_Flg, val, false) == 0 ) return;
		
				if( val != null && val.Length > Default_Enabled_FlgMax )
					_Default_Enabled_Flg = val.Substring(0, (int)Default_Enabled_FlgMax);
				else
					_Default_Enabled_Flg = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Default_Enabled_Flg");
			}
		}
		public string Default_Visible_Flg
		{
			get { return _Default_Visible_Flg; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Default_Visible_Flg, val, false) == 0 ) return;
		
				if( val != null && val.Length > Default_Visible_FlgMax )
					_Default_Visible_Flg = val.Substring(0, (int)Default_Visible_FlgMax);
				else
					_Default_Visible_Flg = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Default_Visible_Flg");
			}
		}
		public string Vendor_Control_Flg
		{
			get { return _Vendor_Control_Flg; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Vendor_Control_Flg, val, false) == 0 ) return;
		
				if( val != null && val.Length > Vendor_Control_FlgMax )
					_Vendor_Control_Flg = val.Substring(0, (int)Vendor_Control_FlgMax);
				else
					_Vendor_Control_Flg = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Vendor_Control_Flg");
			}
		}
		public string Finance_Flg
		{
			get { return _Finance_Flg; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Finance_Flg, val, false) == 0 ) return;
		
				if( val != null && val.Length > Finance_FlgMax )
					_Finance_Flg = val.Substring(0, (int)Finance_FlgMax);
				else
					_Finance_Flg = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Finance_Flg");
			}
		}
		public string Object_Nm
		{
			get { return _Object_Nm; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Object_Nm, val, false) == 0 ) return;
		
				if( val != null && val.Length > Object_NmMax )
					_Object_Nm = val.Substring(0, (int)Object_NmMax);
				else
					_Object_Nm = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Object_Nm");
			}
		}
		public string Parent_Nm
		{
			get { return _Parent_Nm; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Parent_Nm, val, false) == 0 ) return;
		
				if( val != null && val.Length > Parent_NmMax )
					_Parent_Nm = val.Substring(0, (int)Parent_NmMax);
				else
					_Parent_Nm = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Parent_Nm");
			}
		}
		public string Collection_Dsc
		{
			get { return _Collection_Dsc; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Collection_Dsc, val, false) == 0 ) return;
		
				if( val != null && val.Length > Collection_DscMax )
					_Collection_Dsc = val.Substring(0, (int)Collection_DscMax);
				else
					_Collection_Dsc = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Collection_Dsc");
			}
		}
		public string Object_Type
		{
			get { return _Object_Type; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Object_Type, val, false) == 0 ) return;
		
				if( val != null && val.Length > Object_TypeMax )
					_Object_Type = val.Substring(0, (int)Object_TypeMax);
				else
					_Object_Type = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Object_Type");
			}
		}

		#endregion	// #region Column Properties

		#region Foreign Key Fields



		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties



		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsSecurityObject() : base() {}
		public ClsSecurityObject(DataRow dr) : base(dr) {}
		public ClsSecurityObject(ClsSecurityObject src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Object_ID = null;
			Object_Dsc = null;
			Parent_Dsc = null;
			Create_User = null;
			Create_Dt = null;
			Modify_User = null;
			Modify_Dt = null;
			Default_Enabled_Flg = null;
			Default_Visible_Flg = null;
			Vendor_Control_Flg = null;
			Finance_Flg = null;
			Object_Nm = null;
			Parent_Nm = null;
			Collection_Dsc = null;
			Object_Type = null;
		}

		public void CopyFrom(ClsSecurityObject src)
		{
			Object_ID = src._Object_ID;
			Object_Dsc = src._Object_Dsc;
			Parent_Dsc = src._Parent_Dsc;
			Create_User = src._Create_User;
			Create_Dt = src._Create_Dt;
			Modify_User = src._Modify_User;
			Modify_Dt = src._Modify_Dt;
			Default_Enabled_Flg = src._Default_Enabled_Flg;
			Default_Visible_Flg = src._Default_Visible_Flg;
			Vendor_Control_Flg = src._Vendor_Control_Flg;
			Finance_Flg = src._Finance_Flg;
			Object_Nm = src._Object_Nm;
			Parent_Nm = src._Parent_Nm;
			Collection_Dsc = src._Collection_Dsc;
			Object_Type = src._Object_Type;
		}

		public override bool ReloadFromDB()
		{
			ClsSecurityObject tmp = ClsSecurityObject.GetUsingKey(Object_ID.Value);
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

			DbParameter[] p = new DbParameter[15];

			p[0] = Connection.GetParameter
				("@OBJECT_DSC", Object_Dsc);
			p[1] = Connection.GetParameter
				("@PARENT_DSC", Parent_Dsc);
			p[2] = Connection.GetParameter
				("@DEFAULT_ENABLED_FLG", Default_Enabled_Flg);
			p[3] = Connection.GetParameter
				("@DEFAULT_VISIBLE_FLG", Default_Visible_Flg);
			p[4] = Connection.GetParameter
				("@VENDOR_CONTROL_FLG", Vendor_Control_Flg);
			p[5] = Connection.GetParameter
				("@FINANCE_FLG", Finance_Flg);
			p[6] = Connection.GetParameter
				("@OBJECT_NM", Object_Nm);
			p[7] = Connection.GetParameter
				("@PARENT_NM", Parent_Nm);
			p[8] = Connection.GetParameter
				("@COLLECTION_DSC", Collection_Dsc);
			p[9] = Connection.GetParameter
				("@OBJECT_TYPE", Object_Type);
			p[10] = Connection.GetParameter
				("@OBJECT_ID", Object_ID, ParameterDirection.Output, DbType.Int64, 0);
			p[11] = Connection.GetParameter
				("@CREATE_USER", Create_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Create_UserMax);
			p[12] = Connection.GetParameter
				("@CREATE_DT", Create_Dt, ParameterDirection.Output, DbType.DateTime, 0);
			p[13] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);
			p[14] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.Output, DbType.DateTime, 0);

			const string sql = @"
				INSERT INTO SECURITY.R_SECURITY_OBJECT
					(OBJECT_ID, OBJECT_DSC, PARENT_DSC,
					DEFAULT_ENABLED_FLG, DEFAULT_VISIBLE_FLG, VENDOR_CONTROL_FLG,
					FINANCE_FLG, OBJECT_NM, PARENT_NM,
					COLLECTION_DSC, OBJECT_TYPE)
				VALUES
					(OBJECT_ID_SEQ.NEXTVAL, @OBJECT_DSC, @PARENT_DSC,
					@DEFAULT_ENABLED_FLG, @DEFAULT_VISIBLE_FLG, @VENDOR_CONTROL_FLG,
					@FINANCE_FLG, @OBJECT_NM, @PARENT_NM,
					@COLLECTION_DSC, @OBJECT_TYPE)
				RETURNING
					OBJECT_ID, CREATE_USER, CREATE_DT,
					MODIFY_USER, MODIFY_DT
				INTO
					@OBJECT_ID, @CREATE_USER, @CREATE_DT,
					@MODIFY_USER, @MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Object_ID = ClsConvert.ToInt64Nullable(p[10].Value);
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
				("@OBJECT_DSC", Object_Dsc);
			p[1] = Connection.GetParameter
				("@PARENT_DSC", Parent_Dsc);
			p[2] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.InputOutput, DbType.DateTime, 0);
			p[3] = Connection.GetParameter
				("@DEFAULT_ENABLED_FLG", Default_Enabled_Flg);
			p[4] = Connection.GetParameter
				("@DEFAULT_VISIBLE_FLG", Default_Visible_Flg);
			p[5] = Connection.GetParameter
				("@VENDOR_CONTROL_FLG", Vendor_Control_Flg);
			p[6] = Connection.GetParameter
				("@FINANCE_FLG", Finance_Flg);
			p[7] = Connection.GetParameter
				("@OBJECT_NM", Object_Nm);
			p[8] = Connection.GetParameter
				("@PARENT_NM", Parent_Nm);
			p[9] = Connection.GetParameter
				("@COLLECTION_DSC", Collection_Dsc);
			p[10] = Connection.GetParameter
				("@OBJECT_TYPE", Object_Type);
			p[11] = Connection.GetParameter
				("@OBJECT_ID", Object_ID);
			p[12] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);

			const string sql = @"
				UPDATE SECURITY.R_SECURITY_OBJECT SET
					OBJECT_DSC = @OBJECT_DSC,
					PARENT_DSC = @PARENT_DSC,
					MODIFY_DT = @MODIFY_DT,
					DEFAULT_ENABLED_FLG = @DEFAULT_ENABLED_FLG,
					DEFAULT_VISIBLE_FLG = @DEFAULT_VISIBLE_FLG,
					VENDOR_CONTROL_FLG = @VENDOR_CONTROL_FLG,
					FINANCE_FLG = @FINANCE_FLG,
					OBJECT_NM = @OBJECT_NM,
					PARENT_NM = @PARENT_NM,
					COLLECTION_DSC = @COLLECTION_DSC,
					OBJECT_TYPE = @OBJECT_TYPE
				WHERE
					OBJECT_ID = @OBJECT_ID
				RETURNING
					MODIFY_USER, MODIFY_DT
				INTO
					@MODIFY_USER, @MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Modify_Dt = ClsConvert.ToDateTimeNullable(p[2].Value);
			Modify_User = ClsConvert.ToString(p[12].Value);
			return ret;
		}
		public override int Delete()
		{
			DbParameter[] p = new DbParameter[1];

			p[0] = Connection.GetParameter
				("@OBJECT_ID", Object_ID);

			const string sql = @"
				DELETE FROM SECURITY.R_SECURITY_OBJECT WHERE
				OBJECT_ID=@OBJECT_ID";
			return Connection.RunSQL(sql, p);
		}
		#endregion		// #region Insert, Update, Delete

		#region Conversion methods

		public override void LoadFromDataReader(DbDataReader dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataReader: DataReader parameter was null");

			Object_ID = ClsConvert.ToInt64Nullable(dr["OBJECT_ID"]);
			Object_Dsc = ClsConvert.ToString(dr["OBJECT_DSC"]);
			Parent_Dsc = ClsConvert.ToString(dr["PARENT_DSC"]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER"]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT"]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER"]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT"]);
			Default_Enabled_Flg = ClsConvert.ToString(dr["DEFAULT_ENABLED_FLG"]);
			Default_Visible_Flg = ClsConvert.ToString(dr["DEFAULT_VISIBLE_FLG"]);
			Vendor_Control_Flg = ClsConvert.ToString(dr["VENDOR_CONTROL_FLG"]);
			Finance_Flg = ClsConvert.ToString(dr["FINANCE_FLG"]);
			Object_Nm = ClsConvert.ToString(dr["OBJECT_NM"]);
			Parent_Nm = ClsConvert.ToString(dr["PARENT_NM"]);
			Collection_Dsc = ClsConvert.ToString(dr["COLLECTION_DSC"]);
			Object_Type = ClsConvert.ToString(dr["OBJECT_TYPE"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Object_ID = ClsConvert.ToInt64Nullable(dr["OBJECT_ID", v]);
			Object_Dsc = ClsConvert.ToString(dr["OBJECT_DSC", v]);
			Parent_Dsc = ClsConvert.ToString(dr["PARENT_DSC", v]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER", v]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT", v]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER", v]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT", v]);
			Default_Enabled_Flg = ClsConvert.ToString(dr["DEFAULT_ENABLED_FLG", v]);
			Default_Visible_Flg = ClsConvert.ToString(dr["DEFAULT_VISIBLE_FLG", v]);
			Vendor_Control_Flg = ClsConvert.ToString(dr["VENDOR_CONTROL_FLG", v]);
			Finance_Flg = ClsConvert.ToString(dr["FINANCE_FLG", v]);
			Object_Nm = ClsConvert.ToString(dr["OBJECT_NM", v]);
			Parent_Nm = ClsConvert.ToString(dr["PARENT_NM", v]);
			Collection_Dsc = ClsConvert.ToString(dr["COLLECTION_DSC", v]);
			Object_Type = ClsConvert.ToString(dr["OBJECT_TYPE", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["OBJECT_ID"] = ClsConvert.ToDbObject(Object_ID);
			dr["OBJECT_DSC"] = ClsConvert.ToDbObject(Object_Dsc);
			dr["PARENT_DSC"] = ClsConvert.ToDbObject(Parent_Dsc);
			dr["CREATE_USER"] = ClsConvert.ToDbObject(Create_User);
			dr["CREATE_DT"] = ClsConvert.ToDbObject(Create_Dt);
			dr["MODIFY_USER"] = ClsConvert.ToDbObject(Modify_User);
			dr["MODIFY_DT"] = ClsConvert.ToDbObject(Modify_Dt);
			dr["DEFAULT_ENABLED_FLG"] = ClsConvert.ToDbObject(Default_Enabled_Flg);
			dr["DEFAULT_VISIBLE_FLG"] = ClsConvert.ToDbObject(Default_Visible_Flg);
			dr["VENDOR_CONTROL_FLG"] = ClsConvert.ToDbObject(Vendor_Control_Flg);
			dr["FINANCE_FLG"] = ClsConvert.ToDbObject(Finance_Flg);
			dr["OBJECT_NM"] = ClsConvert.ToDbObject(Object_Nm);
			dr["PARENT_NM"] = ClsConvert.ToDbObject(Parent_Nm);
			dr["COLLECTION_DSC"] = ClsConvert.ToDbObject(Collection_Dsc);
			dr["OBJECT_TYPE"] = ClsConvert.ToDbObject(Object_Type);
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

		public static ClsSecurityObject GetUsingKey(Int64 Object_ID)
		{
			object[] vals = new object[] {Object_ID};
			DataRow dr = Connection.GetDataRowUsingKey
				(TableName, GetPrimaryKeys(), vals);
			return ( dr == null ) ? null : new ClsSecurityObject(dr);
		}

		#endregion		// #region Static Methods
	}
}