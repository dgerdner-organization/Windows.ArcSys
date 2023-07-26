using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsLine300Schedule : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ArcSys"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "T_LINE_300_SCHEDULE";
		public const int PrimaryKeyCount = 1;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] { "LINE_300_SCHEDULE_ID" };
		}

		public const string SelectSQL = "SELECT * FROM T_LINE_300_SCHEDULE";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Booking_NoMax = 20;
		public const int Date_TxtMax = 20;
		public const int From_TxtMax = 200;
		public const int Subject_TxtMax = 200;
		public const int File_NmMax = 200;
		public const int Status_FlgMax = 3;
		public const int Status_DscMax = 200;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected decimal? _Line_300_Schedule_ID;
		protected string _Booking_No;
		protected Int64? _Booking_ID;
		protected string _Date_Txt;
		protected string _From_Txt;
		protected string _Subject_Txt;
		protected string _File_Nm;
		protected string _Status_Flg;
		protected string _Status_Dsc;

		#endregion	// #region Column Fields

		#region Column Properties

		public decimal? Line_300_Schedule_ID
		{
			get { return _Line_300_Schedule_ID; }
			set
			{
				if( _Line_300_Schedule_ID == value ) return;
		
				_Line_300_Schedule_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Line_300_Schedule_ID");
			}
		}
		public string Booking_No
		{
			get { return _Booking_No; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Booking_No, val, false) == 0 ) return;
		
				if( val != null && val.Length > Booking_NoMax )
					_Booking_No = val.Substring(0, (int)Booking_NoMax);
				else
					_Booking_No = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Booking_No");
			}
		}
		public Int64? Booking_ID
		{
			get { return _Booking_ID; }
			set
			{
				if( _Booking_ID == value ) return;
		
				_Booking_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Booking_ID");
			}
		}
		public string Date_Txt
		{
			get { return _Date_Txt; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Date_Txt, val, false) == 0 ) return;
		
				if( val != null && val.Length > Date_TxtMax )
					_Date_Txt = val.Substring(0, (int)Date_TxtMax);
				else
					_Date_Txt = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Date_Txt");
			}
		}
		public string From_Txt
		{
			get { return _From_Txt; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_From_Txt, val, false) == 0 ) return;
		
				if( val != null && val.Length > From_TxtMax )
					_From_Txt = val.Substring(0, (int)From_TxtMax);
				else
					_From_Txt = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("From_Txt");
			}
		}
		public string Subject_Txt
		{
			get { return _Subject_Txt; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Subject_Txt, val, false) == 0 ) return;
		
				if( val != null && val.Length > Subject_TxtMax )
					_Subject_Txt = val.Substring(0, (int)Subject_TxtMax);
				else
					_Subject_Txt = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Subject_Txt");
			}
		}
		public string File_Nm
		{
			get { return _File_Nm; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_File_Nm, val, false) == 0 ) return;
		
				if( val != null && val.Length > File_NmMax )
					_File_Nm = val.Substring(0, (int)File_NmMax);
				else
					_File_Nm = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("File_Nm");
			}
		}
		public string Status_Flg
		{
			get { return _Status_Flg; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Status_Flg, val, false) == 0 ) return;
		
				if( val != null && val.Length > Status_FlgMax )
					_Status_Flg = val.Substring(0, (int)Status_FlgMax);
				else
					_Status_Flg = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Status_Flg");
			}
		}
		public string Status_Dsc
		{
			get { return _Status_Dsc; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Status_Dsc, val, false) == 0 ) return;
		
				if( val != null && val.Length > Status_DscMax )
					_Status_Dsc = val.Substring(0, (int)Status_DscMax);
				else
					_Status_Dsc = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Status_Dsc");
			}
		}

		#endregion	// #region Column Properties

		#region Foreign Key Fields



		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties



		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsLine300Schedule() : base() {}
		public ClsLine300Schedule(DataRow dr) : base(dr) {}
		public ClsLine300Schedule(ClsLine300Schedule src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Line_300_Schedule_ID = null;
			Booking_No = null;
			Booking_ID = null;
			Date_Txt = null;
			From_Txt = null;
			Subject_Txt = null;
			File_Nm = null;
			Status_Flg = null;
			Status_Dsc = null;
		}

		public void CopyFrom(ClsLine300Schedule src)
		{
			Line_300_Schedule_ID = src._Line_300_Schedule_ID;
			Booking_No = src._Booking_No;
			Booking_ID = src._Booking_ID;
			Date_Txt = src._Date_Txt;
			From_Txt = src._From_Txt;
			Subject_Txt = src._Subject_Txt;
			File_Nm = src._File_Nm;
			Status_Flg = src._Status_Flg;
			Status_Dsc = src._Status_Dsc;
		}

		public override bool ReloadFromDB()
		{
			ClsLine300Schedule tmp = ClsLine300Schedule.GetUsingKey(Line_300_Schedule_ID.Value);
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

			DbParameter[] p = new DbParameter[9];

			p[0] = Connection.GetParameter
				("@BOOKING_NO", Booking_No);
			p[1] = Connection.GetParameter
				("@BOOKING_ID", Booking_ID);
			p[2] = Connection.GetParameter
				("@DATE_TXT", Date_Txt);
			p[3] = Connection.GetParameter
				("@FROM_TXT", From_Txt);
			p[4] = Connection.GetParameter
				("@SUBJECT_TXT", Subject_Txt);
			p[5] = Connection.GetParameter
				("@FILE_NM", File_Nm);
			p[6] = Connection.GetParameter
				("@STATUS_FLG", Status_Flg);
			p[7] = Connection.GetParameter
				("@STATUS_DSC", Status_Dsc);
			p[8] = Connection.GetParameter
				("@LINE_300_SCHEDULE_ID", Line_300_Schedule_ID, ParameterDirection.Output, DbType.Decimal, 0);

			const string sql = @"
				INSERT INTO T_LINE_300_SCHEDULE
					(LINE_300_SCHEDULE_ID, BOOKING_NO, BOOKING_ID,
					DATE_TXT, FROM_TXT, SUBJECT_TXT,
					FILE_NM, STATUS_FLG, STATUS_DSC)
				VALUES
					(LINE_300_SCHEDULE_ID_SEQ.NEXTVAL, @BOOKING_NO, @BOOKING_ID,
					@DATE_TXT, @FROM_TXT, @SUBJECT_TXT,
					@FILE_NM, @STATUS_FLG, @STATUS_DSC)
				RETURNING
					LINE_300_SCHEDULE_ID
				INTO
					@LINE_300_SCHEDULE_ID";
			int ret = Connection.RunSQL(sql, p);

			Line_300_Schedule_ID = ClsConvert.ToDecimalNullable(p[8].Value);
			return ret;
		}
		public override int Update()
		{
			DbParameter[] p = new DbParameter[9];

			p[0] = Connection.GetParameter
				("@BOOKING_NO", Booking_No);
			p[1] = Connection.GetParameter
				("@BOOKING_ID", Booking_ID);
			p[2] = Connection.GetParameter
				("@DATE_TXT", Date_Txt);
			p[3] = Connection.GetParameter
				("@FROM_TXT", From_Txt);
			p[4] = Connection.GetParameter
				("@SUBJECT_TXT", Subject_Txt);
			p[5] = Connection.GetParameter
				("@FILE_NM", File_Nm);
			p[6] = Connection.GetParameter
				("@STATUS_FLG", Status_Flg);
			p[7] = Connection.GetParameter
				("@STATUS_DSC", Status_Dsc);
			p[8] = Connection.GetParameter
				("@LINE_300_SCHEDULE_ID", Line_300_Schedule_ID);

			const string sql = @"
				UPDATE T_LINE_300_SCHEDULE SET
					BOOKING_NO = @BOOKING_NO,
					BOOKING_ID = @BOOKING_ID,
					DATE_TXT = @DATE_TXT,
					FROM_TXT = @FROM_TXT,
					SUBJECT_TXT = @SUBJECT_TXT,
					FILE_NM = @FILE_NM,
					STATUS_FLG = @STATUS_FLG,
					STATUS_DSC = @STATUS_DSC
				WHERE
					LINE_300_SCHEDULE_ID = @LINE_300_SCHEDULE_ID

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

			Line_300_Schedule_ID = ClsConvert.ToDecimalNullable(dr["LINE_300_SCHEDULE_ID"]);
			Booking_No = ClsConvert.ToString(dr["BOOKING_NO"]);
			Booking_ID = ClsConvert.ToInt64Nullable(dr["BOOKING_ID"]);
			Date_Txt = ClsConvert.ToString(dr["DATE_TXT"]);
			From_Txt = ClsConvert.ToString(dr["FROM_TXT"]);
			Subject_Txt = ClsConvert.ToString(dr["SUBJECT_TXT"]);
			File_Nm = ClsConvert.ToString(dr["FILE_NM"]);
			Status_Flg = ClsConvert.ToString(dr["STATUS_FLG"]);
			Status_Dsc = ClsConvert.ToString(dr["STATUS_DSC"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Line_300_Schedule_ID = ClsConvert.ToDecimalNullable(dr["LINE_300_SCHEDULE_ID", v]);
			Booking_No = ClsConvert.ToString(dr["BOOKING_NO", v]);
			Booking_ID = ClsConvert.ToInt64Nullable(dr["BOOKING_ID", v]);
			Date_Txt = ClsConvert.ToString(dr["DATE_TXT", v]);
			From_Txt = ClsConvert.ToString(dr["FROM_TXT", v]);
			Subject_Txt = ClsConvert.ToString(dr["SUBJECT_TXT", v]);
			File_Nm = ClsConvert.ToString(dr["FILE_NM", v]);
			Status_Flg = ClsConvert.ToString(dr["STATUS_FLG", v]);
			Status_Dsc = ClsConvert.ToString(dr["STATUS_DSC", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["LINE_300_SCHEDULE_ID"] = ClsConvert.ToDbObject(Line_300_Schedule_ID);
			dr["BOOKING_NO"] = ClsConvert.ToDbObject(Booking_No);
			dr["BOOKING_ID"] = ClsConvert.ToDbObject(Booking_ID);
			dr["DATE_TXT"] = ClsConvert.ToDbObject(Date_Txt);
			dr["FROM_TXT"] = ClsConvert.ToDbObject(From_Txt);
			dr["SUBJECT_TXT"] = ClsConvert.ToDbObject(Subject_Txt);
			dr["FILE_NM"] = ClsConvert.ToDbObject(File_Nm);
			dr["STATUS_FLG"] = ClsConvert.ToDbObject(Status_Flg);
			dr["STATUS_DSC"] = ClsConvert.ToDbObject(Status_Dsc);
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

		public static ClsLine300Schedule GetUsingKey(decimal Line_300_Schedule_ID)
		{
			object[] vals = new object[] {Line_300_Schedule_ID};
			DataRow dr = Connection.GetDataRowUsingKey
				(TableName, GetPrimaryKeys(), vals);
			return ( dr == null ) ? null : new ClsLine300Schedule(dr);
		}

		#endregion		// #region Static Methods
	}
}