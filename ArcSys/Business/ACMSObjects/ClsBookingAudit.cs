using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ACMS.Business
{
	public partial class ClsBookingAudit : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ArcSys"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "T_BOOKING_AUDIT";
		public const int PrimaryKeyCount = 0;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] {  };
		}

		public const string SelectSQL = "SELECT * FROM T_BOOKING_AUDIT";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Partner_CdMax = 15;
		public const int Partner_Request_CdMax = 30;
		public const int Column_DscMax = 30;
		public const int Old_DataMax = 50;
		public const int New_DataMax = 50;
		public const int Audit_UserMax = 15;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected string _Partner_Cd;
		protected string _Partner_Request_Cd;
		protected Double? _Item_No;
		protected string _Column_Dsc;
		protected string _Old_Data;
		protected string _New_Data;
		protected DateTime? _Audit_Dt;
		protected string _Audit_User;

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
		public Double? Item_No
		{
			get { return _Item_No; }
			set
			{
				if( _Item_No == value ) return;
		
				_Item_No = value;
				_IsDirty = true;
				NotifyPropertyChanged("Item_No");
			}
		}
		public string Column_Dsc
		{
			get { return _Column_Dsc; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Column_Dsc, val, false) == 0 ) return;
		
				if( val != null && val.Length > Column_DscMax )
					_Column_Dsc = val.Substring(0, (int)Column_DscMax);
				else
					_Column_Dsc = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Column_Dsc");
			}
		}
		public string Old_Data
		{
			get { return _Old_Data; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Old_Data, val, false) == 0 ) return;
		
				if( val != null && val.Length > Old_DataMax )
					_Old_Data = val.Substring(0, (int)Old_DataMax);
				else
					_Old_Data = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Old_Data");
			}
		}
		public string New_Data
		{
			get { return _New_Data; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_New_Data, val, false) == 0 ) return;
		
				if( val != null && val.Length > New_DataMax )
					_New_Data = val.Substring(0, (int)New_DataMax);
				else
					_New_Data = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("New_Data");
			}
		}
		public DateTime? Audit_Dt
		{
			get { return _Audit_Dt; }
			set
			{
				if( _Audit_Dt == value ) return;
		
				_Audit_Dt = value;
				_IsDirty = true;
				NotifyPropertyChanged("Audit_Dt");
			}
		}
		public string Audit_User
		{
			get { return _Audit_User; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Audit_User, val, false) == 0 ) return;
		
				if( val != null && val.Length > Audit_UserMax )
					_Audit_User = val.Substring(0, (int)Audit_UserMax);
				else
					_Audit_User = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Audit_User");
			}
		}

		#endregion	// #region Column Properties

		#region Foreign Key Fields



		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties



		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsBookingAudit() : base() {}
		public ClsBookingAudit(DataRow dr) : base(dr) {}
		public ClsBookingAudit(ClsBookingAudit src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Partner_Cd = null;
			Partner_Request_Cd = null;
			Item_No = null;
			Column_Dsc = null;
			Old_Data = null;
			New_Data = null;
			Audit_Dt = null;
			Audit_User = null;
		}

		public void CopyFrom(ClsBookingAudit src)
		{
			Partner_Cd = src._Partner_Cd;
			Partner_Request_Cd = src._Partner_Request_Cd;
			Item_No = src._Item_No;
			Column_Dsc = src._Column_Dsc;
			Old_Data = src._Old_Data;
			New_Data = src._New_Data;
			Audit_Dt = src._Audit_Dt;
			Audit_User = src._Audit_User;
		}

		public override bool ReloadFromDB()
		{
			ClsBookingAudit tmp = null;	//No primary key can't refresh;
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

			DbParameter[] p = new DbParameter[8];

			p[0] = Connection.GetParameter
				("@PARTNER_CD", Partner_Cd);
			p[1] = Connection.GetParameter
				("@PARTNER_REQUEST_CD", Partner_Request_Cd);
			p[2] = Connection.GetParameter
				("@ITEM_NO", Item_No);
			p[3] = Connection.GetParameter
				("@COLUMN_DSC", Column_Dsc);
			p[4] = Connection.GetParameter
				("@OLD_DATA", Old_Data);
			p[5] = Connection.GetParameter
				("@NEW_DATA", New_Data);
			p[6] = Connection.GetParameter
				("@AUDIT_DT", Audit_Dt);
			p[7] = Connection.GetParameter
				("@AUDIT_USER", Audit_User);

			const string sql = @"
				INSERT INTO T_BOOKING_AUDIT
					(PARTNER_CD, PARTNER_REQUEST_CD, ITEM_NO,
					COLUMN_DSC, OLD_DATA, NEW_DATA,
					AUDIT_DT, AUDIT_USER)
				VALUES
					(@PARTNER_CD, @PARTNER_REQUEST_CD, @ITEM_NO,
					@COLUMN_DSC, @OLD_DATA, @NEW_DATA,
					@AUDIT_DT, @AUDIT_USER)
				RETURNING
					
				INTO
					";
			int ret = Connection.RunSQL(sql, p);


			return ret;
		}
		public override int Update()
		{
			DbParameter[] p = new DbParameter[0];

			if( p.Length == 0 )
				throw new Exception
					("Cannot update table because there is no primary key");

			int ret = -1;


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
			Item_No = ClsConvert.ToDoubleNullable(dr["ITEM_NO"]);
			Column_Dsc = ClsConvert.ToString(dr["COLUMN_DSC"]);
			Old_Data = ClsConvert.ToString(dr["OLD_DATA"]);
			New_Data = ClsConvert.ToString(dr["NEW_DATA"]);
			Audit_Dt = ClsConvert.ToDateTimeNullable(dr["AUDIT_DT"]);
			Audit_User = ClsConvert.ToString(dr["AUDIT_USER"]);
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
			Item_No = ClsConvert.ToDoubleNullable(dr["ITEM_NO", v]);
			Column_Dsc = ClsConvert.ToString(dr["COLUMN_DSC", v]);
			Old_Data = ClsConvert.ToString(dr["OLD_DATA", v]);
			New_Data = ClsConvert.ToString(dr["NEW_DATA", v]);
			Audit_Dt = ClsConvert.ToDateTimeNullable(dr["AUDIT_DT", v]);
			Audit_User = ClsConvert.ToString(dr["AUDIT_USER", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["PARTNER_CD"] = ClsConvert.ToDbObject(Partner_Cd);
			dr["PARTNER_REQUEST_CD"] = ClsConvert.ToDbObject(Partner_Request_Cd);
			dr["ITEM_NO"] = ClsConvert.ToDbObject(Item_No);
			dr["COLUMN_DSC"] = ClsConvert.ToDbObject(Column_Dsc);
			dr["OLD_DATA"] = ClsConvert.ToDbObject(Old_Data);
			dr["NEW_DATA"] = ClsConvert.ToDbObject(New_Data);
			dr["AUDIT_DT"] = ClsConvert.ToDbObject(Audit_Dt);
			dr["AUDIT_USER"] = ClsConvert.ToDbObject(Audit_User);
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



		#endregion		// #region Static Methods
	}
}