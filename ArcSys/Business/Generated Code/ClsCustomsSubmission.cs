using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.AVSS.Business
{
	public partial class ClsCustomsSubmission : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["AVSS"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "T_CUSTOMS_SUBMISSION";
		public const int PrimaryKeyCount = 0;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] {  };
		}

		public const string SelectSQL = @"SELECT * FROM T_CUSTOMS_SUBMISSION 
				INNER JOIN R_PORT
				ON T_CUSTOMS_SUBMISSION.PORT_CD=R_PORT.PORT_CD
				INNER JOIN T_VESSEL_BERTH_ACTIVITY
				ON T_CUSTOMS_SUBMISSION.VESSEL_BERTH_ACTIVITY_ID=T_VESSEL_BERTH_ACTIVITY.VESSEL_BERTH_ACTIVITY_ID
				LEFT OUTER JOIN R_BERTH
				ON T_CUSTOMS_SUBMISSION.BERTH_CD=R_BERTH.BERTH_CD
				INNER JOIN R_VESSEL
				ON T_CUSTOMS_SUBMISSION.VESSEL_CD=R_VESSEL.VESSEL_CD ";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Create_UserMax = 30;
		public const int Modify_UserMax = 30;
		public const int Vessel_CdMax = 10;
		public const int Voyage_NoMax = 10;
		public const int Port_CdMax = 10;
		public const int Berth_CdMax = 10;
		public const int Submitted_UserMax = 30;
		public const int Customs_CategoryMax = 30;
		public const int Customs_Req_FlgMax = 1;
		public const int NotesMax = 500;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected Int64? _Vessel_Berth_Activity_ID;
		protected string _Create_User;
		protected DateTime? _Create_Dt;
		protected string _Modify_User;
		protected DateTime? _Modify_Dt;
		protected string _Vessel_Cd;
		protected string _Voyage_No;
		protected string _Port_Cd;
		protected string _Berth_Cd;
		protected DateTime? _Port_Dt;
		protected DateTime? _Submitted_Dt;
		protected string _Submitted_User;
		protected string _Customs_Category;
		protected string _Customs_Req_Flg;
		protected string _Notes;

		#endregion	// #region Column Fields

		#region Column Properties

		public Int64? Vessel_Berth_Activity_ID
		{
			get { return _Vessel_Berth_Activity_ID; }
			set
			{
				if( _Vessel_Berth_Activity_ID == value ) return;
		
				_Vessel_Berth_Activity_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Vessel_Berth_Activity_ID");
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
		public string Vessel_Cd
		{
			get { return _Vessel_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Vessel_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Vessel_CdMax )
					_Vessel_Cd = val.Substring(0, (int)Vessel_CdMax);
				else
					_Vessel_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Vessel_Cd");
			}
		}
		public string Voyage_No
		{
			get { return _Voyage_No; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Voyage_No, val, false) == 0 ) return;
		
				if( val != null && val.Length > Voyage_NoMax )
					_Voyage_No = val.Substring(0, (int)Voyage_NoMax);
				else
					_Voyage_No = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Voyage_No");
			}
		}
		public string Port_Cd
		{
			get { return _Port_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Port_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Port_CdMax )
					_Port_Cd = val.Substring(0, (int)Port_CdMax);
				else
					_Port_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Port_Cd");
			}
		}
		public string Berth_Cd
		{
			get { return _Berth_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Berth_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Berth_CdMax )
					_Berth_Cd = val.Substring(0, (int)Berth_CdMax);
				else
					_Berth_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Berth_Cd");
			}
		}
		public DateTime? Port_Dt
		{
			get { return _Port_Dt; }
			set
			{
				DateTime? val = ( value != null )
					? (DateTime?)value.Value.Date : null;
		
				if( _Port_Dt == val ) return;
		
				_Port_Dt = val;
				_IsDirty = true;
				NotifyPropertyChanged("Port_Dt");
			}
		}
		public DateTime? Submitted_Dt
		{
			get { return _Submitted_Dt; }
			set
			{
				DateTime? val = ( value != null )
					? (DateTime?)value.Value.Date : null;
		
				if( _Submitted_Dt == val ) return;
		
				_Submitted_Dt = val;
				_IsDirty = true;
				NotifyPropertyChanged("Submitted_Dt");
			}
		}
		public string Submitted_User
		{
			get { return _Submitted_User; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Submitted_User, val, false) == 0 ) return;
		
				if( val != null && val.Length > Submitted_UserMax )
					_Submitted_User = val.Substring(0, (int)Submitted_UserMax);
				else
					_Submitted_User = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Submitted_User");
			}
		}
		public string Customs_Category
		{
			get { return _Customs_Category; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Customs_Category, val, false) == 0 ) return;
		
				if( val != null && val.Length > Customs_CategoryMax )
					_Customs_Category = val.Substring(0, (int)Customs_CategoryMax);
				else
					_Customs_Category = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Customs_Category");
			}
		}
		public string Customs_Req_Flg
		{
			get { return _Customs_Req_Flg; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Customs_Req_Flg, val, false) == 0 ) return;
		
				if( val != null && val.Length > Customs_Req_FlgMax )
					_Customs_Req_Flg = val.Substring(0, (int)Customs_Req_FlgMax);
				else
					_Customs_Req_Flg = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Customs_Req_Flg");
			}
		}
		public string Notes
		{
			get { return _Notes; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Notes, val, false) == 0 ) return;
		
				if( val != null && val.Length > NotesMax )
					_Notes = val.Substring(0, (int)NotesMax);
				else
					_Notes = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Notes");
			}
		}

		#endregion	// #region Column Properties

		#region Foreign Key Fields

		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties

		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsCustomsSubmission() : base() {}
		public ClsCustomsSubmission(DataRow dr) : base(dr) {}
		public ClsCustomsSubmission(ClsCustomsSubmission src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Vessel_Berth_Activity_ID = null;
			Create_User = null;
			Create_Dt = null;
			Modify_User = null;
			Modify_Dt = null;
			Vessel_Cd = null;
			Voyage_No = null;
			Port_Cd = null;
			Berth_Cd = null;
			Port_Dt = null;
			Submitted_Dt = null;
			Submitted_User = null;
			Customs_Category = null;
			Customs_Req_Flg = null;
			Notes = null;
		}

		public void CopyFrom(ClsCustomsSubmission src)
		{
			Vessel_Berth_Activity_ID = src._Vessel_Berth_Activity_ID;
			Create_User = src._Create_User;
			Create_Dt = src._Create_Dt;
			Modify_User = src._Modify_User;
			Modify_Dt = src._Modify_Dt;
			Vessel_Cd = src._Vessel_Cd;
			Voyage_No = src._Voyage_No;
			Port_Cd = src._Port_Cd;
			Berth_Cd = src._Berth_Cd;
			Port_Dt = src._Port_Dt;
			Submitted_Dt = src._Submitted_Dt;
			Submitted_User = src._Submitted_User;
			Customs_Category = src._Customs_Category;
			Customs_Req_Flg = src._Customs_Req_Flg;
			Notes = src._Notes;
		}

		public override bool ReloadFromDB()
		{
			ClsCustomsSubmission tmp = null;	//No primary key can't refresh;
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
				("@VESSEL_BERTH_ACTIVITY_ID", Vessel_Berth_Activity_ID);
			p[1] = Connection.GetParameter
				("@VESSEL_CD", Vessel_Cd);
			p[2] = Connection.GetParameter
				("@VOYAGE_NO", Voyage_No);
			p[3] = Connection.GetParameter
				("@PORT_CD", Port_Cd);
			p[4] = Connection.GetParameter
				("@BERTH_CD", Berth_Cd);
			p[5] = Connection.GetParameter
				("@PORT_DT", Port_Dt);
			p[6] = Connection.GetParameter
				("@SUBMITTED_DT", Submitted_Dt);
			p[7] = Connection.GetParameter
				("@SUBMITTED_USER", Submitted_User);
			p[8] = Connection.GetParameter
				("@CUSTOMS_CATEGORY", Customs_Category);
			p[9] = Connection.GetParameter
				("@CUSTOMS_REQ_FLG", Customs_Req_Flg);
			p[10] = Connection.GetParameter
				("@NOTES", Notes);
			p[11] = Connection.GetParameter
				("@CREATE_USER", Create_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Create_UserMax);
			p[12] = Connection.GetParameter
				("@CREATE_DT", Create_Dt, ParameterDirection.Output, DbType.DateTime, 0);
			p[13] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);
			p[14] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.Output, DbType.DateTime, 0);

			const string sql = @"
				INSERT INTO T_CUSTOMS_SUBMISSION
					(VESSEL_BERTH_ACTIVITY_ID, VESSEL_CD, VOYAGE_NO,
					PORT_CD, BERTH_CD, PORT_DT,
					SUBMITTED_DT, SUBMITTED_USER, CUSTOMS_CATEGORY,
					CUSTOMS_REQ_FLG, NOTES)
				VALUES
					(@VESSEL_BERTH_ACTIVITY_ID, @VESSEL_CD, @VOYAGE_NO,
					@PORT_CD, @BERTH_CD, @PORT_DT,
					@SUBMITTED_DT, @SUBMITTED_USER, @CUSTOMS_CATEGORY,
					@CUSTOMS_REQ_FLG, @NOTES)
				RETURNING
					CREATE_USER, CREATE_DT, MODIFY_USER,
					MODIFY_DT
				INTO
					@CREATE_USER, @CREATE_DT, @MODIFY_USER,
					@MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Create_User = ClsConvert.ToString(p[11].Value);
			Create_Dt = ClsConvert.ToDateTimeNullable(p[12].Value);
			Modify_User = ClsConvert.ToString(p[13].Value);
			Modify_Dt = ClsConvert.ToDateTimeNullable(p[14].Value);
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

			Vessel_Berth_Activity_ID = ClsConvert.ToInt64Nullable(dr["VESSEL_BERTH_ACTIVITY_ID"]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER"]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT"]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER"]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT"]);
			Vessel_Cd = ClsConvert.ToString(dr["VESSEL_CD"]);
			Voyage_No = ClsConvert.ToString(dr["VOYAGE_NO"]);
			Port_Cd = ClsConvert.ToString(dr["PORT_CD"]);
			Berth_Cd = ClsConvert.ToString(dr["BERTH_CD"]);
			Port_Dt = ClsConvert.ToDateTimeNullable(dr["PORT_DT"]);
			Submitted_Dt = ClsConvert.ToDateTimeNullable(dr["SUBMITTED_DT"]);
			Submitted_User = ClsConvert.ToString(dr["SUBMITTED_USER"]);
			Customs_Category = ClsConvert.ToString(dr["CUSTOMS_CATEGORY"]);
			Customs_Req_Flg = ClsConvert.ToString(dr["CUSTOMS_REQ_FLG"]);
			Notes = ClsConvert.ToString(dr["NOTES"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Vessel_Berth_Activity_ID = ClsConvert.ToInt64Nullable(dr["VESSEL_BERTH_ACTIVITY_ID", v]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER", v]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT", v]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER", v]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT", v]);
			Vessel_Cd = ClsConvert.ToString(dr["VESSEL_CD", v]);
			Voyage_No = ClsConvert.ToString(dr["VOYAGE_NO", v]);
			Port_Cd = ClsConvert.ToString(dr["PORT_CD", v]);
			Berth_Cd = ClsConvert.ToString(dr["BERTH_CD", v]);
			Port_Dt = ClsConvert.ToDateTimeNullable(dr["PORT_DT", v]);
			Submitted_Dt = ClsConvert.ToDateTimeNullable(dr["SUBMITTED_DT", v]);
			Submitted_User = ClsConvert.ToString(dr["SUBMITTED_USER", v]);
			Customs_Category = ClsConvert.ToString(dr["CUSTOMS_CATEGORY", v]);
			Customs_Req_Flg = ClsConvert.ToString(dr["CUSTOMS_REQ_FLG", v]);
			Notes = ClsConvert.ToString(dr["NOTES", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["VESSEL_BERTH_ACTIVITY_ID"] = ClsConvert.ToDbObject(Vessel_Berth_Activity_ID);
			dr["CREATE_USER"] = ClsConvert.ToDbObject(Create_User);
			dr["CREATE_DT"] = ClsConvert.ToDbObject(Create_Dt);
			dr["MODIFY_USER"] = ClsConvert.ToDbObject(Modify_User);
			dr["MODIFY_DT"] = ClsConvert.ToDbObject(Modify_Dt);
			dr["VESSEL_CD"] = ClsConvert.ToDbObject(Vessel_Cd);
			dr["VOYAGE_NO"] = ClsConvert.ToDbObject(Voyage_No);
			dr["PORT_CD"] = ClsConvert.ToDbObject(Port_Cd);
			dr["BERTH_CD"] = ClsConvert.ToDbObject(Berth_Cd);
			dr["PORT_DT"] = ClsConvert.ToDbObject(Port_Dt);
			dr["SUBMITTED_DT"] = ClsConvert.ToDbObject(Submitted_Dt);
			dr["SUBMITTED_USER"] = ClsConvert.ToDbObject(Submitted_User);
			dr["CUSTOMS_CATEGORY"] = ClsConvert.ToDbObject(Customs_Category);
			dr["CUSTOMS_REQ_FLG"] = ClsConvert.ToDbObject(Customs_Req_Flg);
			dr["NOTES"] = ClsConvert.ToDbObject(Notes);
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


		public static DataTable GetAll(string Port_Cd, Int64? Vessel_Berth_Activity_ID,
			string Berth_Cd, string Vessel_Cd)
		{
			List<DbParameter> lst = new List<DbParameter>();	
			StringBuilder sb = new StringBuilder();
		
			if( string.IsNullOrEmpty(Port_Cd) == false )
			{
				lst.Add(Connection.GetParameter("@PORT_CD", Port_Cd));
				sb.Append(" WHERE T_CUSTOMS_SUBMISSION.PORT_CD=@PORT_CD");
			}
			if( Vessel_Berth_Activity_ID != null && Vessel_Berth_Activity_ID > 0 )
			{
				lst.Add(Connection.GetParameter("@VESSEL_BERTH_ACTIVITY_ID", Vessel_Berth_Activity_ID));
				sb.AppendFormat(" {0} T_CUSTOMS_SUBMISSION.VESSEL_BERTH_ACTIVITY_ID=@VESSEL_BERTH_ACTIVITY_ID",
					sb.Length > 0 ? "AND" : "WHERE");
			}
			if( string.IsNullOrEmpty(Berth_Cd) == false )
			{
				lst.Add(Connection.GetParameter("@BERTH_CD", Berth_Cd));
				sb.AppendFormat(" {0} T_CUSTOMS_SUBMISSION.BERTH_CD=@BERTH_CD",
					sb.Length > 0 ? "AND" : "WHERE");
			}
			if( string.IsNullOrEmpty(Vessel_Cd) == false )
			{
				lst.Add(Connection.GetParameter("@VESSEL_CD", Vessel_Cd));
				sb.AppendFormat(" {0} T_CUSTOMS_SUBMISSION.VESSEL_CD=@VESSEL_CD",
					sb.Length > 0 ? "AND" : "WHERE");
			}
			sb.Insert(0, SelectSQL);
			return Connection.GetDataTable(sb.ToString(), lst.ToArray());
		}
		#endregion		// #region Static Methods
	}
}