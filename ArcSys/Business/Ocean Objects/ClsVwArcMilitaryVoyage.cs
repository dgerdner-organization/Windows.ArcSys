using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsVwArcMilitaryVoyage : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["OCEAN"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "vw_arc_military_voyage";
		public const int PrimaryKeyCount = 0;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] {  };
		}

		public const string SelectSQL = "SELECT * FROM vw_arc_military_voyage";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int VoydocMax = 10;
		public const int Voyage_NoMax = 10;
		public const int Active_FlgMax = 1;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected Int32? _Voydoc_ID;
		protected string _Voydoc;
		protected string _Voyage_No;
		protected string _Active_Flg;
		protected Int32? _Voyageid;

		#endregion	// #region Column Fields

		#region Column Properties

		public Int32? Voydoc_ID
		{
			get { return _Voydoc_ID; }
			set
			{
				if( _Voydoc_ID == value ) return;
		
				_Voydoc_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Voydoc_ID");
			}
		}
		public string Voydoc
		{
			get { return _Voydoc; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Voydoc, val, false) == 0 ) return;
		
				if( val != null && val.Length > VoydocMax )
					_Voydoc = val.Substring(0, (int)VoydocMax);
				else
					_Voydoc = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Voydoc");
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
		public Int32? Voyageid
		{
			get { return _Voyageid; }
			set
			{
				if( _Voyageid == value ) return;
		
				_Voyageid = value;
				_IsDirty = true;
				NotifyPropertyChanged("Voyageid");
			}
		}

		#endregion	// #region Column Properties

		#region Foreign Key Fields



		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties



		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsVwArcMilitaryVoyage() : base() {}
		public ClsVwArcMilitaryVoyage(DataRow dr) : base(dr) {}
		public ClsVwArcMilitaryVoyage(ClsVwArcMilitaryVoyage src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Voydoc_ID = null;
			Voydoc = null;
			Voyage_No = null;
			Active_Flg = null;
			Voyageid = null;
		}

		public void CopyFrom(ClsVwArcMilitaryVoyage src)
		{
			Voydoc_ID = src._Voydoc_ID;
			Voydoc = src._Voydoc;
			Voyage_No = src._Voyage_No;
			Active_Flg = src._Active_Flg;
			Voyageid = src._Voyageid;
		}

		public override bool ReloadFromDB()
		{
			ClsVwArcMilitaryVoyage tmp = null;	//No primary key can't refresh;
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

			DbParameter[] p = new DbParameter[5];

			p[0] = Connection.GetParameter
				("@voydoc_Id", Voydoc_ID);
			p[1] = Connection.GetParameter
				("@voydoc", Voydoc);
			p[2] = Connection.GetParameter
				("@voyage_no", Voyage_No);
			p[3] = Connection.GetParameter
				("@active_flg", Active_Flg);
			p[4] = Connection.GetParameter
				("@VoyageId", Voyageid);

			const string sql = @"INSERT INTO vw_arc_military_voyage VALUES
				(@voydoc_Id,@voydoc,@voyage_no
				,@active_flg,@VoyageId)";
			int ret = Connection.RunSQL(sql, p);


			return ret;
		}
		public override int Update()
		{
			DbParameter[] p = new DbParameter[0];

			if( p.Length == 0 )
				throw new Exception
					("Cannot update table because there is no primary key");

			return -1;

__cs__PostUpdate
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

			Voydoc_ID = ClsConvert.ToInt32Nullable(dr["voydoc_Id"]);
			Voydoc = ClsConvert.ToString(dr["voydoc"]);
			Voyage_No = ClsConvert.ToString(dr["voyage_no"]);
			Active_Flg = ClsConvert.ToString(dr["active_flg"]);
			Voyageid = ClsConvert.ToInt32Nullable(dr["VoyageId"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Voydoc_ID = ClsConvert.ToInt32Nullable(dr["voydoc_Id", v]);
			Voydoc = ClsConvert.ToString(dr["voydoc", v]);
			Voyage_No = ClsConvert.ToString(dr["voyage_no", v]);
			Active_Flg = ClsConvert.ToString(dr["active_flg", v]);
			Voyageid = ClsConvert.ToInt32Nullable(dr["VoyageId", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["voydoc_Id"] = ClsConvert.ToDbObject(Voydoc_ID);
			dr["voydoc"] = ClsConvert.ToDbObject(Voydoc);
			dr["voyage_no"] = ClsConvert.ToDbObject(Voyage_No);
			dr["active_flg"] = ClsConvert.ToDbObject(Active_Flg);
			dr["VoyageId"] = ClsConvert.ToDbObject(Voyageid);
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