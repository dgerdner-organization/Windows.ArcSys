using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsShippingInstructionsQueue : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ArcSys"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "T_SHIPPING_INSTRUCTIONS_QUEUE";
		public const int PrimaryKeyCount = 1;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] { "BOOKING_NO" };
		}

		public const string SelectSQL = "SELECT * FROM T_SHIPPING_INSTRUCTIONS_QUEUE";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Booking_NoMax = 20;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected string _Booking_No;

		#endregion	// #region Column Fields

		#region Column Properties

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

		#endregion	// #region Column Properties

		#region Foreign Key Fields



		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties



		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsShippingInstructionsQueue() : base() {}
		public ClsShippingInstructionsQueue(DataRow dr) : base(dr) {}
		public ClsShippingInstructionsQueue(ClsShippingInstructionsQueue src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Booking_No = null;
		}

		public void CopyFrom(ClsShippingInstructionsQueue src)
		{
			Booking_No = src._Booking_No;
		}

		public override bool ReloadFromDB()
		{
			ClsShippingInstructionsQueue tmp = ClsShippingInstructionsQueue.GetUsingKey(Booking_No);
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

			DbParameter[] p = new DbParameter[1];

			p[0] = Connection.GetParameter
				("@BOOKING_NO", Booking_No);

			const string sql = @"
				INSERT INTO T_SHIPPING_INSTRUCTIONS_QUEUE
					(BOOKING_NO)
				VALUES
					(@BOOKING_NO)

					";
			int ret = Connection.RunSQL(sql, p);


			return ret;
		}
		public override int Update()
		{
			DbParameter[] p = new DbParameter[1];

			p[0] = Connection.GetParameter
				("@BOOKING_NO", Booking_No);

			const string sql = @"
				UPDATE T_SHIPPING_INSTRUCTIONS_QUEUE SET
					
				WHERE
					BOOKING_NO = @BOOKING_NO
				RETURNING
					
				INTO
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

			Booking_No = ClsConvert.ToString(dr["BOOKING_NO"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Booking_No = ClsConvert.ToString(dr["BOOKING_NO", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["BOOKING_NO"] = ClsConvert.ToDbObject(Booking_No);
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

		public static ClsShippingInstructionsQueue GetUsingKey(string Booking_No)
		{
			object[] vals = new object[] {Booking_No};
			DataRow dr = Connection.GetDataRowUsingKey
				(TableName, GetPrimaryKeys(), vals);
			return ( dr == null ) ? null : new ClsShippingInstructionsQueue(dr);
		}

		#endregion		// #region Static Methods
	}
}