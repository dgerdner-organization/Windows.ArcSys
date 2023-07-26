using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ACMS.Business
{
	public partial class ClsAcmsStatus : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ACMS"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "R_ACMS_STATUS";
		public const int PrimaryKeyCount = 1;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] { "ACMS_STATUS_CD" };
		}

		public const string SelectSQL = "SELECT * FROM R_ACMS_STATUS";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Acms_Status_CdMax = 2;
		public const int Acms_Status_DscMax = 30;
		public const int Processed_CdMax = 1;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected string _Acms_Status_Cd;
		protected string _Acms_Status_Dsc;
		protected string _Processed_Cd;

		#endregion	// #region Column Fields

		#region Column Properties

		public string Acms_Status_Cd
		{
			get { return _Acms_Status_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Acms_Status_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Acms_Status_CdMax )
					_Acms_Status_Cd = val.Substring(0, (int)Acms_Status_CdMax);
				else
					_Acms_Status_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Acms_Status_Cd");
			}
		}
		public string Acms_Status_Dsc
		{
			get { return _Acms_Status_Dsc; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Acms_Status_Dsc, val, false) == 0 ) return;
		
				if( val != null && val.Length > Acms_Status_DscMax )
					_Acms_Status_Dsc = val.Substring(0, (int)Acms_Status_DscMax);
				else
					_Acms_Status_Dsc = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Acms_Status_Dsc");
			}
		}
		public string Processed_Cd
		{
			get { return _Processed_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Processed_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Processed_CdMax )
					_Processed_Cd = val.Substring(0, (int)Processed_CdMax);
				else
					_Processed_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Processed_Cd");
			}
		}

		#endregion	// #region Column Properties

		#region Foreign Key Fields



		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties



		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsAcmsStatus() : base() {}
		public ClsAcmsStatus(DataRow dr) : base(dr) {}
		public ClsAcmsStatus(ClsAcmsStatus src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Acms_Status_Cd = null;
			Acms_Status_Dsc = null;
			Processed_Cd = null;
		}

		public void CopyFrom(ClsAcmsStatus src)
		{
			Acms_Status_Cd = src._Acms_Status_Cd;
			Acms_Status_Dsc = src._Acms_Status_Dsc;
			Processed_Cd = src._Processed_Cd;
		}

		public override bool ReloadFromDB()
		{
			ClsAcmsStatus tmp = ClsAcmsStatus.GetUsingKey(Acms_Status_Cd);
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

			DbParameter[] p = new DbParameter[3];

			p[0] = Connection.GetParameter
				("@ACMS_STATUS_CD", Acms_Status_Cd);
			p[1] = Connection.GetParameter
				("@ACMS_STATUS_DSC", Acms_Status_Dsc);
			p[2] = Connection.GetParameter
				("@PROCESSED_CD", Processed_Cd);

			const string sql = @"
				INSERT INTO R_ACMS_STATUS
					(ACMS_STATUS_CD, ACMS_STATUS_DSC, PROCESSED_CD)
				VALUES
					(@ACMS_STATUS_CD, @ACMS_STATUS_DSC, @PROCESSED_CD)
				RETURNING
					
				INTO
					";
			int ret = Connection.RunSQL(sql, p);


			return ret;
		}
		public override int Update()
		{
			DbParameter[] p = new DbParameter[3];

			p[0] = Connection.GetParameter
				("@ACMS_STATUS_DSC", Acms_Status_Dsc);
			p[1] = Connection.GetParameter
				("@PROCESSED_CD", Processed_Cd);
			p[2] = Connection.GetParameter
				("@ACMS_STATUS_CD", Acms_Status_Cd);

			const string sql = @"
				UPDATE R_ACMS_STATUS SET
					ACMS_STATUS_DSC = @ACMS_STATUS_DSC,
					PROCESSED_CD = @PROCESSED_CD
				WHERE
					ACMS_STATUS_CD = @ACMS_STATUS_CD
				RETURNING
					
				INTO
					";
			int ret = Connection.RunSQL(sql, p);


			return ret;
		}
		public override int Delete()
		{
			DbParameter[] p = new DbParameter[1];

			p[0] = Connection.GetParameter
				("@ACMS_STATUS_CD", Acms_Status_Cd);

			const string sql = @"
				DELETE FROM R_ACMS_STATUS WHERE
				ACMS_STATUS_CD=@ACMS_STATUS_CD";
			return Connection.RunSQL(sql, p);
		}
		#endregion		// #region Insert, Update, Delete

		#region Conversion methods

		public override void LoadFromDataReader(DbDataReader dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataReader: DataReader parameter was null");

			Acms_Status_Cd = ClsConvert.ToString(dr["ACMS_STATUS_CD"]);
			Acms_Status_Dsc = ClsConvert.ToString(dr["ACMS_STATUS_DSC"]);
			Processed_Cd = ClsConvert.ToString(dr["PROCESSED_CD"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Acms_Status_Cd = ClsConvert.ToString(dr["ACMS_STATUS_CD", v]);
			Acms_Status_Dsc = ClsConvert.ToString(dr["ACMS_STATUS_DSC", v]);
			Processed_Cd = ClsConvert.ToString(dr["PROCESSED_CD", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["ACMS_STATUS_CD"] = ClsConvert.ToDbObject(Acms_Status_Cd);
			dr["ACMS_STATUS_DSC"] = ClsConvert.ToDbObject(Acms_Status_Dsc);
			dr["PROCESSED_CD"] = ClsConvert.ToDbObject(Processed_Cd);
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

		public static ClsAcmsStatus GetUsingKey(string Acms_Status_Cd)
		{
			object[] vals = new object[] {Acms_Status_Cd};
			DataRow dr = Connection.GetDataRowUsingKey
				(TableName, GetPrimaryKeys(), vals);
			return ( dr == null ) ? null : new ClsAcmsStatus(dr);
		}

		#endregion		// #region Static Methods
	}
}