using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsChargeCategory : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ArcSys"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "R_CHARGE_CATEGORY";
		public const int PrimaryKeyCount = 1;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] { "CHARGE_CATEGORY_CD" };
		}

		public const string SelectSQL = "SELECT * FROM R_CHARGE_CATEGORY";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Charge_Category_CdMax = 10;
		public const int Create_UserMax = 30;
		public const int Modify_UserMax = 30;
		public const int Charge_Category_DscMax = 50;
		public const int Active_FlgMax = 1;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected string _Charge_Category_Cd;
		protected string _Create_User;
		protected DateTime? _Create_Dt;
		protected string _Modify_User;
		protected DateTime? _Modify_Dt;
		protected string _Charge_Category_Dsc;
		protected string _Active_Flg;

		#endregion	// #region Column Fields

		#region Column Properties

		public string Charge_Category_Cd
		{
			get { return _Charge_Category_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Charge_Category_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Charge_Category_CdMax )
					_Charge_Category_Cd = val.Substring(0, (int)Charge_Category_CdMax);
				else
					_Charge_Category_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Charge_Category_Cd");
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
		public string Charge_Category_Dsc
		{
			get { return _Charge_Category_Dsc; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Charge_Category_Dsc, val, false) == 0 ) return;
		
				if( val != null && val.Length > Charge_Category_DscMax )
					_Charge_Category_Dsc = val.Substring(0, (int)Charge_Category_DscMax);
				else
					_Charge_Category_Dsc = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Charge_Category_Dsc");
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

		#endregion	// #region Column Properties

		#region Foreign Key Fields



		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties



		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsChargeCategory() : base() {}
		public ClsChargeCategory(DataRow dr) : base(dr) {}
		public ClsChargeCategory(ClsChargeCategory src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Charge_Category_Cd = null;
			Create_User = null;
			Create_Dt = null;
			Modify_User = null;
			Modify_Dt = null;
			Charge_Category_Dsc = null;
			Active_Flg = null;
		}

		public void CopyFrom(ClsChargeCategory src)
		{
			Charge_Category_Cd = src._Charge_Category_Cd;
			Create_User = src._Create_User;
			Create_Dt = src._Create_Dt;
			Modify_User = src._Modify_User;
			Modify_Dt = src._Modify_Dt;
			Charge_Category_Dsc = src._Charge_Category_Dsc;
			Active_Flg = src._Active_Flg;
		}

		public override bool ReloadFromDB()
		{
			ClsChargeCategory tmp = ClsChargeCategory.GetUsingKey(Charge_Category_Cd);
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
				("@CHARGE_CATEGORY_CD", Charge_Category_Cd);
			p[1] = Connection.GetParameter
				("@CHARGE_CATEGORY_DSC", Charge_Category_Dsc);
			p[2] = Connection.GetParameter
				("@ACTIVE_FLG", Active_Flg);
			p[3] = Connection.GetParameter
				("@CREATE_USER", Create_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Create_UserMax);
			p[4] = Connection.GetParameter
				("@CREATE_DT", Create_Dt, ParameterDirection.Output, DbType.DateTime, 0);
			p[5] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);
			p[6] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.Output, DbType.DateTime, 0);

			const string sql = @"
				INSERT INTO R_CHARGE_CATEGORY
					(CHARGE_CATEGORY_CD, CHARGE_CATEGORY_DSC, ACTIVE_FLG)
				VALUES
					(@CHARGE_CATEGORY_CD, @CHARGE_CATEGORY_DSC, @ACTIVE_FLG)
				RETURNING
					CREATE_USER, CREATE_DT, MODIFY_USER,
					MODIFY_DT
				INTO
					@CREATE_USER, @CREATE_DT, @MODIFY_USER,
					@MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Create_User = ClsConvert.ToString(p[3].Value);
			Create_Dt = ClsConvert.ToDateTimeNullable(p[4].Value);
			Modify_User = ClsConvert.ToString(p[5].Value);
			Modify_Dt = ClsConvert.ToDateTimeNullable(p[6].Value);
			return ret;
		}
		public override int Update()
		{
			DbParameter[] p = new DbParameter[5];

			p[0] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.InputOutput, DbType.DateTime, 0);
			p[1] = Connection.GetParameter
				("@CHARGE_CATEGORY_DSC", Charge_Category_Dsc);
			p[2] = Connection.GetParameter
				("@ACTIVE_FLG", Active_Flg);
			p[3] = Connection.GetParameter
				("@CHARGE_CATEGORY_CD", Charge_Category_Cd);
			p[4] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);

			const string sql = @"
				UPDATE R_CHARGE_CATEGORY SET
					MODIFY_DT = @MODIFY_DT,
					CHARGE_CATEGORY_DSC = @CHARGE_CATEGORY_DSC,
					ACTIVE_FLG = @ACTIVE_FLG
				WHERE
					CHARGE_CATEGORY_CD = @CHARGE_CATEGORY_CD
				RETURNING
					MODIFY_USER, MODIFY_DT
				INTO
					@MODIFY_USER, @MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Modify_Dt = ClsConvert.ToDateTimeNullable(p[0].Value);
			Modify_User = ClsConvert.ToString(p[4].Value);
			return ret;
		}
		public override int Delete()
		{
			DbParameter[] p = new DbParameter[1];

			p[0] = Connection.GetParameter
				("@CHARGE_CATEGORY_CD", Charge_Category_Cd);

			const string sql = @"
				DELETE FROM R_CHARGE_CATEGORY WHERE
				CHARGE_CATEGORY_CD=@CHARGE_CATEGORY_CD";
			return Connection.RunSQL(sql, p);
		}
		#endregion		// #region Insert, Update, Delete

		#region Conversion methods

		public override void LoadFromDataReader(DbDataReader dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataReader: DataReader parameter was null");

			Charge_Category_Cd = ClsConvert.ToString(dr["CHARGE_CATEGORY_CD"]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER"]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT"]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER"]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT"]);
			Charge_Category_Dsc = ClsConvert.ToString(dr["CHARGE_CATEGORY_DSC"]);
			Active_Flg = ClsConvert.ToString(dr["ACTIVE_FLG"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Charge_Category_Cd = ClsConvert.ToString(dr["CHARGE_CATEGORY_CD", v]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER", v]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT", v]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER", v]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT", v]);
			Charge_Category_Dsc = ClsConvert.ToString(dr["CHARGE_CATEGORY_DSC", v]);
			Active_Flg = ClsConvert.ToString(dr["ACTIVE_FLG", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["CHARGE_CATEGORY_CD"] = ClsConvert.ToDbObject(Charge_Category_Cd);
			dr["CREATE_USER"] = ClsConvert.ToDbObject(Create_User);
			dr["CREATE_DT"] = ClsConvert.ToDbObject(Create_Dt);
			dr["MODIFY_USER"] = ClsConvert.ToDbObject(Modify_User);
			dr["MODIFY_DT"] = ClsConvert.ToDbObject(Modify_Dt);
			dr["CHARGE_CATEGORY_DSC"] = ClsConvert.ToDbObject(Charge_Category_Dsc);
			dr["ACTIVE_FLG"] = ClsConvert.ToDbObject(Active_Flg);
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

		public static ClsChargeCategory GetUsingKey(string Charge_Category_Cd)
		{
			object[] vals = new object[] {Charge_Category_Cd};
			DataRow dr = Connection.GetDataRowUsingKey
				(TableName, GetPrimaryKeys(), vals);
			return ( dr == null ) ? null : new ClsChargeCategory(dr);
		}

		#endregion		// #region Static Methods
	}
}