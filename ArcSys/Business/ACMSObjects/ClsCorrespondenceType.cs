using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ACMS.Business
{
	public partial class ClsCorrespondenceType : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ACMS"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "R_CORRESPONDENCE_TYPE";
		public const int PrimaryKeyCount = 1;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] { "CORR_CD" };
		}

		public const string SelectSQL = "SELECT * FROM R_CORRESPONDENCE_TYPE";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Corr_CdMax = 5;
		public const int Corr_DscMax = 30;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected string _Corr_Cd;
		protected string _Corr_Dsc;

		#endregion	// #region Column Fields

		#region Column Properties

		public string Corr_Cd
		{
			get { return _Corr_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Corr_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Corr_CdMax )
					_Corr_Cd = val.Substring(0, (int)Corr_CdMax);
				else
					_Corr_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Corr_Cd");
			}
		}
		public string Corr_Dsc
		{
			get { return _Corr_Dsc; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Corr_Dsc, val, false) == 0 ) return;
		
				if( val != null && val.Length > Corr_DscMax )
					_Corr_Dsc = val.Substring(0, (int)Corr_DscMax);
				else
					_Corr_Dsc = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Corr_Dsc");
			}
		}

		#endregion	// #region Column Properties

		#region Foreign Key Fields



		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties



		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsCorrespondenceType() : base() {}
		public ClsCorrespondenceType(DataRow dr) : base(dr) {}
		public ClsCorrespondenceType(ClsCorrespondenceType src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Corr_Cd = null;
			Corr_Dsc = null;
		}

		public void CopyFrom(ClsCorrespondenceType src)
		{
			Corr_Cd = src._Corr_Cd;
			Corr_Dsc = src._Corr_Dsc;
		}

		public override bool ReloadFromDB()
		{
			ClsCorrespondenceType tmp = ClsCorrespondenceType.GetUsingKey(Corr_Cd);
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

			DbParameter[] p = new DbParameter[2];

			p[0] = Connection.GetParameter
				("@CORR_CD", Corr_Cd);
			p[1] = Connection.GetParameter
				("@CORR_DSC", Corr_Dsc);

			const string sql = @"
				INSERT INTO R_CORRESPONDENCE_TYPE
					(CORR_CD, CORR_DSC)
				VALUES
					(@CORR_CD, @CORR_DSC)
				RETURNING
					
				INTO
					";
			int ret = Connection.RunSQL(sql, p);


			return ret;
		}
		public override int Update()
		{
			DbParameter[] p = new DbParameter[2];

			p[0] = Connection.GetParameter
				("@CORR_DSC", Corr_Dsc);
			p[1] = Connection.GetParameter
				("@CORR_CD", Corr_Cd);

			const string sql = @"
				UPDATE R_CORRESPONDENCE_TYPE SET
					CORR_DSC = @CORR_DSC
				WHERE
					CORR_CD = @CORR_CD
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
				("@CORR_CD", Corr_Cd);

			const string sql = @"
				DELETE FROM R_CORRESPONDENCE_TYPE WHERE
				CORR_CD=@CORR_CD";
			return Connection.RunSQL(sql, p);
		}
		#endregion		// #region Insert, Update, Delete

		#region Conversion methods

		public override void LoadFromDataReader(DbDataReader dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataReader: DataReader parameter was null");

			Corr_Cd = ClsConvert.ToString(dr["CORR_CD"]);
			Corr_Dsc = ClsConvert.ToString(dr["CORR_DSC"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Corr_Cd = ClsConvert.ToString(dr["CORR_CD", v]);
			Corr_Dsc = ClsConvert.ToString(dr["CORR_DSC", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["CORR_CD"] = ClsConvert.ToDbObject(Corr_Cd);
			dr["CORR_DSC"] = ClsConvert.ToDbObject(Corr_Dsc);
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

		public static ClsCorrespondenceType GetUsingKey(string Corr_Cd)
		{
			object[] vals = new object[] {Corr_Cd};
			DataRow dr = Connection.GetDataRowUsingKey
				(TableName, GetPrimaryKeys(), vals);
			return ( dr == null ) ? null : new ClsCorrespondenceType(dr);
		}

		#endregion		// #region Static Methods
	}
}