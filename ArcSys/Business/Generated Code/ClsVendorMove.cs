using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsVendorMove : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ArcSys"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "T_VENDOR_MOVE";
		public const int PrimaryKeyCount = 1;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] { "VENDOR_MOVE_ID" };
		}

		public const string SelectSQL = @"SELECT * FROM T_VENDOR_MOVE 
				INNER JOIN R_VENDOR
				ON T_VENDOR_MOVE.VENDOR_CD=R_VENDOR.VENDOR_CD
				INNER JOIN R_LOCATION
				ON T_VENDOR_MOVE.ORIG_LOCATION_CD=R_LOCATION.LOCATION_CD
				INNER JOIN R_LOCATION r_loc2
				ON T_VENDOR_MOVE.DEST_LOCATION_CD=r_loc2.LOCATION_CD
				INNER JOIN T_MOVE
				ON T_VENDOR_MOVE.MOVE_ID=T_MOVE.MOVE_ID ";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Vendor_CdMax = 10;
		public const int Orig_Location_CdMax = 10;
		public const int Dest_Location_CdMax = 10;
		public const int Create_UserMax = 30;
		public const int Modify_UserMax = 30;
		public const int Active_FlgMax = 1;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected Int64? _Vendor_Move_ID;
		protected Int64? _Move_ID;
		protected string _Vendor_Cd;
		protected string _Orig_Location_Cd;
		protected string _Dest_Location_Cd;
		protected string _Create_User;
		protected DateTime? _Create_Dt;
		protected string _Modify_User;
		protected DateTime? _Modify_Dt;
		protected string _Active_Flg;
		protected Int16? _Allocated_Qty;
		protected Int16? _Used_Qty;
		protected Int16? _Futile_Qty;

		#endregion	// #region Column Fields

		#region Column Properties

		public Int64? Vendor_Move_ID
		{
			get { return _Vendor_Move_ID; }
			set
			{
				if( _Vendor_Move_ID == value ) return;
		
				_Vendor_Move_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Vendor_Move_ID");
			}
		}
		public Int64? Move_ID
		{
			get { return _Move_ID; }
			set
			{
				if( _Move_ID == value ) return;
		
				_Move_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Move_ID");
			}
		}
		public string Vendor_Cd
		{
			get { return _Vendor_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Vendor_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Vendor_CdMax )
					_Vendor_Cd = val.Substring(0, (int)Vendor_CdMax);
				else
					_Vendor_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Vendor_Cd");
			}
		}
		public string Orig_Location_Cd
		{
			get { return _Orig_Location_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Orig_Location_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Orig_Location_CdMax )
					_Orig_Location_Cd = val.Substring(0, (int)Orig_Location_CdMax);
				else
					_Orig_Location_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Orig_Location_Cd");
			}
		}
		public string Dest_Location_Cd
		{
			get { return _Dest_Location_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Dest_Location_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Dest_Location_CdMax )
					_Dest_Location_Cd = val.Substring(0, (int)Dest_Location_CdMax);
				else
					_Dest_Location_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Dest_Location_Cd");
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
		public Int16? Allocated_Qty
		{
			get { return _Allocated_Qty; }
			set
			{
				if( _Allocated_Qty == value ) return;
		
				_Allocated_Qty = value;
				_IsDirty = true;
				NotifyPropertyChanged("Allocated_Qty");
			}
		}
		public Int16? Used_Qty
		{
			get { return _Used_Qty; }
			set
			{
				if( _Used_Qty == value ) return;
		
				_Used_Qty = value;
				_IsDirty = true;
				NotifyPropertyChanged("Used_Qty");
			}
		}
		public Int16? Futile_Qty
		{
			get { return _Futile_Qty; }
			set
			{
				if( _Futile_Qty == value ) return;
		
				_Futile_Qty = value;
				_IsDirty = true;
				NotifyPropertyChanged("Futile_Qty");
			}
		}

		#endregion	// #region Column Properties

		#region Foreign Key Fields

		protected ClsVendor _Vendor;
		protected ClsLocation _Orig_Location;
		protected ClsLocation _Dest_Location;
		protected ClsMove _Move;

		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties

		public ClsVendor Vendor
		{
			get
			{
				if( Vendor_Cd == null )
					_Vendor = null;
				else if( _Vendor == null ||
					_Vendor.Vendor_Cd != Vendor_Cd )
					_Vendor = ClsVendor.GetUsingKey(Vendor_Cd);
				return _Vendor;
			}
			set
			{
				if( _Vendor == value ) return;
		
				_Vendor = value;
			}
		}
		public ClsLocation Orig_Location
		{
			get
			{
				if( Orig_Location_Cd == null )
					_Orig_Location = null;
				else if( _Orig_Location == null ||
					_Orig_Location.Location_Cd != Orig_Location_Cd )
					_Orig_Location = ClsLocation.GetUsingKey(Orig_Location_Cd);
				return _Orig_Location;
			}
			set
			{
				if( _Orig_Location == value ) return;
		
				_Orig_Location = value;
			}
		}
		public ClsLocation Dest_Location
		{
			get
			{
				if( Dest_Location_Cd == null )
					_Dest_Location = null;
				else if( _Dest_Location == null ||
					_Dest_Location.Location_Cd != Dest_Location_Cd )
					_Dest_Location = ClsLocation.GetUsingKey(Dest_Location_Cd);
				return _Dest_Location;
			}
			set
			{
				if( _Dest_Location == value ) return;
		
				_Dest_Location = value;
			}
		}
		public ClsMove Move
		{
			get
			{
				if( Move_ID == null )
					_Move = null;
				else if( _Move == null ||
					_Move.Move_ID != Move_ID )
					_Move = ClsMove.GetUsingKey(Move_ID.Value);
				return _Move;
			}
			set
			{
				if( _Move == value ) return;
		
				_Move = value;
			}
		}

		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsVendorMove() : base() {}
		public ClsVendorMove(DataRow dr) : base(dr) {}
		public ClsVendorMove(ClsVendorMove src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Vendor_Move_ID = null;
			Move_ID = null;
			Vendor_Cd = null;
			Orig_Location_Cd = null;
			Dest_Location_Cd = null;
			Create_User = null;
			Create_Dt = null;
			Modify_User = null;
			Modify_Dt = null;
			Active_Flg = null;
			Allocated_Qty = null;
			Used_Qty = null;
			Futile_Qty = null;
		}

		public void CopyFrom(ClsVendorMove src)
		{
			Vendor_Move_ID = src._Vendor_Move_ID;
			Move_ID = src._Move_ID;
			Vendor_Cd = src._Vendor_Cd;
			Orig_Location_Cd = src._Orig_Location_Cd;
			Dest_Location_Cd = src._Dest_Location_Cd;
			Create_User = src._Create_User;
			Create_Dt = src._Create_Dt;
			Modify_User = src._Modify_User;
			Modify_Dt = src._Modify_Dt;
			Active_Flg = src._Active_Flg;
			Allocated_Qty = src._Allocated_Qty;
			Used_Qty = src._Used_Qty;
			Futile_Qty = src._Futile_Qty;
		}

		public override bool ReloadFromDB()
		{
			ClsVendorMove tmp = ClsVendorMove.GetUsingKey(Vendor_Move_ID.Value);
			if( tmp != null ) CopyFrom(tmp);

			ResetFKs();
			OnReload();

			return ( tmp != null );
		}

		public override void ResetFKs()
		{
			_Vendor = null;
			_Orig_Location = null;
			_Dest_Location = null;
			_Move = null;
		}
		#endregion		// #region Init methods

		#region Insert, Update, Delete

		public override int Insert()
		{

			DbParameter[] p = new DbParameter[13];

			p[0] = Connection.GetParameter
				("@MOVE_ID", Move_ID);
			p[1] = Connection.GetParameter
				("@VENDOR_CD", Vendor_Cd);
			p[2] = Connection.GetParameter
				("@ORIG_LOCATION_CD", Orig_Location_Cd);
			p[3] = Connection.GetParameter
				("@DEST_LOCATION_CD", Dest_Location_Cd);
			p[4] = Connection.GetParameter
				("@ACTIVE_FLG", Active_Flg);
			p[5] = Connection.GetParameter
				("@ALLOCATED_QTY", Allocated_Qty);
			p[6] = Connection.GetParameter
				("@USED_QTY", Used_Qty);
			p[7] = Connection.GetParameter
				("@FUTILE_QTY", Futile_Qty);
			p[8] = Connection.GetParameter
				("@VENDOR_MOVE_ID", Vendor_Move_ID, ParameterDirection.Output, DbType.Int64, 0);
			p[9] = Connection.GetParameter
				("@CREATE_USER", Create_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Create_UserMax);
			p[10] = Connection.GetParameter
				("@CREATE_DT", Create_Dt, ParameterDirection.Output, DbType.DateTime, 0);
			p[11] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);
			p[12] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.Output, DbType.DateTime, 0);

			const string sql = @"
				INSERT INTO T_VENDOR_MOVE
					(VENDOR_MOVE_ID, MOVE_ID, VENDOR_CD,
					ORIG_LOCATION_CD, DEST_LOCATION_CD, ACTIVE_FLG,
					ALLOCATED_QTY, USED_QTY, FUTILE_QTY)
				VALUES
					(VENDOR_MOVE_ID_SEQ.NEXTVAL, @MOVE_ID, @VENDOR_CD,
					@ORIG_LOCATION_CD, @DEST_LOCATION_CD, @ACTIVE_FLG,
					@ALLOCATED_QTY, @USED_QTY, @FUTILE_QTY)
				RETURNING
					VENDOR_MOVE_ID, CREATE_USER, CREATE_DT,
					MODIFY_USER, MODIFY_DT
				INTO
					@VENDOR_MOVE_ID, @CREATE_USER, @CREATE_DT,
					@MODIFY_USER, @MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Vendor_Move_ID = ClsConvert.ToInt64Nullable(p[8].Value);
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
				("@MOVE_ID", Move_ID);
			p[1] = Connection.GetParameter
				("@VENDOR_CD", Vendor_Cd);
			p[2] = Connection.GetParameter
				("@ORIG_LOCATION_CD", Orig_Location_Cd);
			p[3] = Connection.GetParameter
				("@DEST_LOCATION_CD", Dest_Location_Cd);
			p[4] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.InputOutput, DbType.DateTime, 0);
			p[5] = Connection.GetParameter
				("@ACTIVE_FLG", Active_Flg);
			p[6] = Connection.GetParameter
				("@ALLOCATED_QTY", Allocated_Qty);
			p[7] = Connection.GetParameter
				("@USED_QTY", Used_Qty);
			p[8] = Connection.GetParameter
				("@FUTILE_QTY", Futile_Qty);
			p[9] = Connection.GetParameter
				("@VENDOR_MOVE_ID", Vendor_Move_ID);
			p[10] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);

			const string sql = @"
				UPDATE T_VENDOR_MOVE SET
					MOVE_ID = @MOVE_ID,
					VENDOR_CD = @VENDOR_CD,
					ORIG_LOCATION_CD = @ORIG_LOCATION_CD,
					DEST_LOCATION_CD = @DEST_LOCATION_CD,
					MODIFY_DT = @MODIFY_DT,
					ACTIVE_FLG = @ACTIVE_FLG,
					ALLOCATED_QTY = @ALLOCATED_QTY,
					USED_QTY = @USED_QTY,
					FUTILE_QTY = @FUTILE_QTY
				WHERE
					VENDOR_MOVE_ID = @VENDOR_MOVE_ID
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
				("@VENDOR_MOVE_ID", Vendor_Move_ID);

			const string sql = @"
				DELETE FROM T_VENDOR_MOVE WHERE
				VENDOR_MOVE_ID=@VENDOR_MOVE_ID";
			return Connection.RunSQL(sql, p);
		}
		#endregion		// #region Insert, Update, Delete

		#region Conversion methods

		public override void LoadFromDataReader(DbDataReader dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataReader: DataReader parameter was null");

			Vendor_Move_ID = ClsConvert.ToInt64Nullable(dr["VENDOR_MOVE_ID"]);
			Move_ID = ClsConvert.ToInt64Nullable(dr["MOVE_ID"]);
			Vendor_Cd = ClsConvert.ToString(dr["VENDOR_CD"]);
			Orig_Location_Cd = ClsConvert.ToString(dr["ORIG_LOCATION_CD"]);
			Dest_Location_Cd = ClsConvert.ToString(dr["DEST_LOCATION_CD"]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER"]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT"]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER"]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT"]);
			Active_Flg = ClsConvert.ToString(dr["ACTIVE_FLG"]);
			Allocated_Qty = ClsConvert.ToInt16Nullable(dr["ALLOCATED_QTY"]);
			Used_Qty = ClsConvert.ToInt16Nullable(dr["USED_QTY"]);
			Futile_Qty = ClsConvert.ToInt16Nullable(dr["FUTILE_QTY"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Vendor_Move_ID = ClsConvert.ToInt64Nullable(dr["VENDOR_MOVE_ID", v]);
			Move_ID = ClsConvert.ToInt64Nullable(dr["MOVE_ID", v]);
			Vendor_Cd = ClsConvert.ToString(dr["VENDOR_CD", v]);
			Orig_Location_Cd = ClsConvert.ToString(dr["ORIG_LOCATION_CD", v]);
			Dest_Location_Cd = ClsConvert.ToString(dr["DEST_LOCATION_CD", v]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER", v]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT", v]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER", v]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT", v]);
			Active_Flg = ClsConvert.ToString(dr["ACTIVE_FLG", v]);
			Allocated_Qty = ClsConvert.ToInt16Nullable(dr["ALLOCATED_QTY", v]);
			Used_Qty = ClsConvert.ToInt16Nullable(dr["USED_QTY", v]);
			Futile_Qty = ClsConvert.ToInt16Nullable(dr["FUTILE_QTY", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["VENDOR_MOVE_ID"] = ClsConvert.ToDbObject(Vendor_Move_ID);
			dr["MOVE_ID"] = ClsConvert.ToDbObject(Move_ID);
			dr["VENDOR_CD"] = ClsConvert.ToDbObject(Vendor_Cd);
			dr["ORIG_LOCATION_CD"] = ClsConvert.ToDbObject(Orig_Location_Cd);
			dr["DEST_LOCATION_CD"] = ClsConvert.ToDbObject(Dest_Location_Cd);
			dr["CREATE_USER"] = ClsConvert.ToDbObject(Create_User);
			dr["CREATE_DT"] = ClsConvert.ToDbObject(Create_Dt);
			dr["MODIFY_USER"] = ClsConvert.ToDbObject(Modify_User);
			dr["MODIFY_DT"] = ClsConvert.ToDbObject(Modify_Dt);
			dr["ACTIVE_FLG"] = ClsConvert.ToDbObject(Active_Flg);
			dr["ALLOCATED_QTY"] = ClsConvert.ToDbObject(Allocated_Qty);
			dr["USED_QTY"] = ClsConvert.ToDbObject(Used_Qty);
			dr["FUTILE_QTY"] = ClsConvert.ToDbObject(Futile_Qty);
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

		public static ClsVendorMove GetUsingKey(Int64 Vendor_Move_ID)
		{
			object[] vals = new object[] {Vendor_Move_ID};
			DataRow dr = Connection.GetDataRowUsingKey
				(TableName, GetPrimaryKeys(), vals);
			return ( dr == null ) ? null : new ClsVendorMove(dr);
		}
		public static DataTable GetAll(string Vendor_Cd, string Orig_Location_Cd,
			string Dest_Location_Cd, Int64? Move_ID)
		{
			List<DbParameter> lst = new List<DbParameter>();	
			StringBuilder sb = new StringBuilder();
		
			if( string.IsNullOrEmpty(Vendor_Cd) == false )
			{
				lst.Add(Connection.GetParameter("@VENDOR_CD", Vendor_Cd));
				sb.Append(" WHERE T_VENDOR_MOVE.VENDOR_CD=@VENDOR_CD");
			}
			if( string.IsNullOrEmpty(Orig_Location_Cd) == false )
			{
				lst.Add(Connection.GetParameter("@ORIG_LOCATION_CD", Orig_Location_Cd));
				sb.AppendFormat(" {0} T_VENDOR_MOVE.ORIG_LOCATION_CD=@ORIG_LOCATION_CD",
					sb.Length > 0 ? "AND" : "WHERE");
			}
			if( string.IsNullOrEmpty(Dest_Location_Cd) == false )
			{
				lst.Add(Connection.GetParameter("@DEST_LOCATION_CD", Dest_Location_Cd));
				sb.AppendFormat(" {0} T_VENDOR_MOVE.DEST_LOCATION_CD=@DEST_LOCATION_CD",
					sb.Length > 0 ? "AND" : "WHERE");
			}
			if( Move_ID != null && Move_ID > 0 )
			{
				lst.Add(Connection.GetParameter("@MOVE_ID", Move_ID));
				sb.AppendFormat(" {0} T_VENDOR_MOVE.MOVE_ID=@MOVE_ID",
					sb.Length > 0 ? "AND" : "WHERE");
			}
			sb.Insert(0, SelectSQL);
			return Connection.GetDataTable(sb.ToString(), lst.ToArray());
		}
		#endregion		// #region Static Methods
	}
}