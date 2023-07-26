using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ACMS.Business
{
	public partial class ClsEdiActivityFtp : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ACMS"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "T_EDI_ACTIVITY_FTP";
		public const int PrimaryKeyCount = 0;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] {  };
		}

		public const string SelectSQL = "SELECT * FROM T_EDI_ACTIVITY_FTP";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Table_DscMax = 50;
		public const int In_OutMax = 1;
		public const int Trading_Partner_CdMax = 30;
		public const int Ftp_Success_CdMax = 1;
		public const int Map_Success_CdMax = 1;
		public const int Edi_TypeMax = 10;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected string _Table_Dsc;
		protected string _In_Out;
		protected string _Trading_Partner_Cd;
		protected DateTime? _Trans_Dt;
		protected string _Ftp_Success_Cd;
		protected string _Map_Success_Cd;
		protected Double? _Trans_Ctl_No;
		protected string _Edi_Type;

		#endregion	// #region Column Fields

		#region Column Properties

		public string Table_Dsc
		{
			get { return _Table_Dsc; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Table_Dsc, val, false) == 0 ) return;
		
				if( val != null && val.Length > Table_DscMax )
					_Table_Dsc = val.Substring(0, (int)Table_DscMax);
				else
					_Table_Dsc = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Table_Dsc");
			}
		}
		public string In_Out
		{
			get { return _In_Out; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_In_Out, val, false) == 0 ) return;
		
				if( val != null && val.Length > In_OutMax )
					_In_Out = val.Substring(0, (int)In_OutMax);
				else
					_In_Out = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("In_Out");
			}
		}
		public string Trading_Partner_Cd
		{
			get { return _Trading_Partner_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Trading_Partner_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Trading_Partner_CdMax )
					_Trading_Partner_Cd = val.Substring(0, (int)Trading_Partner_CdMax);
				else
					_Trading_Partner_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Trading_Partner_Cd");
			}
		}
		public DateTime? Trans_Dt
		{
			get { return _Trans_Dt; }
			set
			{
				if( _Trans_Dt == value ) return;
		
				_Trans_Dt = value;
				_IsDirty = true;
				NotifyPropertyChanged("Trans_Dt");
			}
		}
		public string Ftp_Success_Cd
		{
			get { return _Ftp_Success_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Ftp_Success_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Ftp_Success_CdMax )
					_Ftp_Success_Cd = val.Substring(0, (int)Ftp_Success_CdMax);
				else
					_Ftp_Success_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Ftp_Success_Cd");
			}
		}
		public string Map_Success_Cd
		{
			get { return _Map_Success_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Map_Success_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Map_Success_CdMax )
					_Map_Success_Cd = val.Substring(0, (int)Map_Success_CdMax);
				else
					_Map_Success_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Map_Success_Cd");
			}
		}
		public Double? Trans_Ctl_No
		{
			get { return _Trans_Ctl_No; }
			set
			{
				if( _Trans_Ctl_No == value ) return;
		
				_Trans_Ctl_No = value;
				_IsDirty = true;
				NotifyPropertyChanged("Trans_Ctl_No");
			}
		}
		public string Edi_Type
		{
			get { return _Edi_Type; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Edi_Type, val, false) == 0 ) return;
		
				if( val != null && val.Length > Edi_TypeMax )
					_Edi_Type = val.Substring(0, (int)Edi_TypeMax);
				else
					_Edi_Type = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Edi_Type");
			}
		}

		#endregion	// #region Column Properties

		#region Foreign Key Fields



		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties



		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsEdiActivityFtp() : base() {}
		public ClsEdiActivityFtp(DataRow dr) : base(dr) {}
		public ClsEdiActivityFtp(ClsEdiActivityFtp src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Table_Dsc = null;
			In_Out = null;
			Trading_Partner_Cd = null;
			Trans_Dt = null;
			Ftp_Success_Cd = null;
			Map_Success_Cd = null;
			Trans_Ctl_No = null;
			Edi_Type = null;
		}

		public void CopyFrom(ClsEdiActivityFtp src)
		{
			Table_Dsc = src._Table_Dsc;
			In_Out = src._In_Out;
			Trading_Partner_Cd = src._Trading_Partner_Cd;
			Trans_Dt = src._Trans_Dt;
			Ftp_Success_Cd = src._Ftp_Success_Cd;
			Map_Success_Cd = src._Map_Success_Cd;
			Trans_Ctl_No = src._Trans_Ctl_No;
			Edi_Type = src._Edi_Type;
		}

		public override bool ReloadFromDB()
		{
			ClsEdiActivityFtp tmp = null;	//No primary key can't refresh;
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
				("@TABLE_DSC", Table_Dsc);
			p[1] = Connection.GetParameter
				("@IN_OUT", In_Out);
			p[2] = Connection.GetParameter
				("@TRADING_PARTNER_CD", Trading_Partner_Cd);
			p[3] = Connection.GetParameter
				("@TRANS_DT", Trans_Dt);
			p[4] = Connection.GetParameter
				("@FTP_SUCCESS_CD", Ftp_Success_Cd);
			p[5] = Connection.GetParameter
				("@MAP_SUCCESS_CD", Map_Success_Cd);
			p[6] = Connection.GetParameter
				("@TRANS_CTL_NO", Trans_Ctl_No);
			p[7] = Connection.GetParameter
				("@EDI_TYPE", Edi_Type);

			const string sql = @"
				INSERT INTO T_EDI_ACTIVITY_FTP
					(TABLE_DSC, IN_OUT, TRADING_PARTNER_CD,
					TRANS_DT, FTP_SUCCESS_CD, MAP_SUCCESS_CD,
					TRANS_CTL_NO, EDI_TYPE)
				VALUES
					(@TABLE_DSC, @IN_OUT, @TRADING_PARTNER_CD,
					@TRANS_DT, @FTP_SUCCESS_CD, @MAP_SUCCESS_CD,
					@TRANS_CTL_NO, @EDI_TYPE)
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

			Table_Dsc = ClsConvert.ToString(dr["TABLE_DSC"]);
			In_Out = ClsConvert.ToString(dr["IN_OUT"]);
			Trading_Partner_Cd = ClsConvert.ToString(dr["TRADING_PARTNER_CD"]);
			Trans_Dt = ClsConvert.ToDateTimeNullable(dr["TRANS_DT"]);
			Ftp_Success_Cd = ClsConvert.ToString(dr["FTP_SUCCESS_CD"]);
			Map_Success_Cd = ClsConvert.ToString(dr["MAP_SUCCESS_CD"]);
			Trans_Ctl_No = ClsConvert.ToDoubleNullable(dr["TRANS_CTL_NO"]);
			Edi_Type = ClsConvert.ToString(dr["EDI_TYPE"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Table_Dsc = ClsConvert.ToString(dr["TABLE_DSC", v]);
			In_Out = ClsConvert.ToString(dr["IN_OUT", v]);
			Trading_Partner_Cd = ClsConvert.ToString(dr["TRADING_PARTNER_CD", v]);
			Trans_Dt = ClsConvert.ToDateTimeNullable(dr["TRANS_DT", v]);
			Ftp_Success_Cd = ClsConvert.ToString(dr["FTP_SUCCESS_CD", v]);
			Map_Success_Cd = ClsConvert.ToString(dr["MAP_SUCCESS_CD", v]);
			Trans_Ctl_No = ClsConvert.ToDoubleNullable(dr["TRANS_CTL_NO", v]);
			Edi_Type = ClsConvert.ToString(dr["EDI_TYPE", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["TABLE_DSC"] = ClsConvert.ToDbObject(Table_Dsc);
			dr["IN_OUT"] = ClsConvert.ToDbObject(In_Out);
			dr["TRADING_PARTNER_CD"] = ClsConvert.ToDbObject(Trading_Partner_Cd);
			dr["TRANS_DT"] = ClsConvert.ToDbObject(Trans_Dt);
			dr["FTP_SUCCESS_CD"] = ClsConvert.ToDbObject(Ftp_Success_Cd);
			dr["MAP_SUCCESS_CD"] = ClsConvert.ToDbObject(Map_Success_Cd);
			dr["TRANS_CTL_NO"] = ClsConvert.ToDbObject(Trans_Ctl_No);
			dr["EDI_TYPE"] = ClsConvert.ToDbObject(Edi_Type);
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