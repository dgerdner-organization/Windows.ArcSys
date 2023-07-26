using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.OCEAN.Business
{
	public partial class ClsVwArcVoyageDetail : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["OCEAN"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "vw_arc_voyage_detail";
		public const int PrimaryKeyCount = 0;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] {  };
		}

		public const string SelectSQL = "SELECT * FROM vw_arc_voyage_detail";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int VoynoMax = 10;
		public const int TraderouteMax = 20;
		public const int VesselcdMax = 5;
		public const int VesselownerMax = 30;
		public const int LocationcdMax = 7;
		public const int ActiveflgMax = 1;
		public const int ActivitytypeMax = 20;
		public const int EtaMax = 27;
		public const int EtdMax = 27;
		public const int AtaMax = 27;
		public const int AtdMax = 27;
		public const int FinalmanifesteddateMax = 27;
		public const int PortpaircloseddateMax = 27;
		public const int ArrivedtMax = 27;
		public const int DeparturedtMax = 27;
		public const int ArrivedMax = 1;
		public const int DepartedMax = 1;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected string _Voyno;
		protected string _Traderoute;
		protected string _Vesselcd;
		protected string _Vesselowner;
		protected string _Locationcd;
		protected string _Activeflg;
		protected string _Activitytype;
		protected string _Eta;
		protected string _Etd;
		protected string _Ata;
		protected string _Atd;
		protected string _Finalmanifesteddate;
		protected string _Portpaircloseddate;
		protected string _Arrivedt;
		protected string _Departuredt;
		protected string _Arrived;
		protected string _Departed;

		#endregion	// #region Column Fields

		#region Column Properties

		public string Voyno
		{
			get { return _Voyno; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Voyno, val, false) == 0 ) return;
		
				if( val != null && val.Length > VoynoMax )
					_Voyno = val.Substring(0, (int)VoynoMax);
				else
					_Voyno = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Voyno");
			}
		}
		public string Traderoute
		{
			get { return _Traderoute; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Traderoute, val, false) == 0 ) return;
		
				if( val != null && val.Length > TraderouteMax )
					_Traderoute = val.Substring(0, (int)TraderouteMax);
				else
					_Traderoute = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Traderoute");
			}
		}
		public string Vesselcd
		{
			get { return _Vesselcd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Vesselcd, val, false) == 0 ) return;
		
				if( val != null && val.Length > VesselcdMax )
					_Vesselcd = val.Substring(0, (int)VesselcdMax);
				else
					_Vesselcd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Vesselcd");
			}
		}
		public string Vesselowner
		{
			get { return _Vesselowner; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Vesselowner, val, false) == 0 ) return;
		
				if( val != null && val.Length > VesselownerMax )
					_Vesselowner = val.Substring(0, (int)VesselownerMax);
				else
					_Vesselowner = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Vesselowner");
			}
		}
		public string Locationcd
		{
			get { return _Locationcd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Locationcd, val, false) == 0 ) return;
		
				if( val != null && val.Length > LocationcdMax )
					_Locationcd = val.Substring(0, (int)LocationcdMax);
				else
					_Locationcd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Locationcd");
			}
		}
		public string Activeflg
		{
			get { return _Activeflg; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Activeflg, val, false) == 0 ) return;
		
				if( val != null && val.Length > ActiveflgMax )
					_Activeflg = val.Substring(0, (int)ActiveflgMax);
				else
					_Activeflg = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Activeflg");
			}
		}
		public string Activitytype
		{
			get { return _Activitytype; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Activitytype, val, false) == 0 ) return;
		
				if( val != null && val.Length > ActivitytypeMax )
					_Activitytype = val.Substring(0, (int)ActivitytypeMax);
				else
					_Activitytype = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Activitytype");
			}
		}
		public string Eta
		{
			get { return _Eta; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Eta, val, false) == 0 ) return;
		
				if( val != null && val.Length > EtaMax )
					_Eta = val.Substring(0, (int)EtaMax);
				else
					_Eta = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Eta");
			}
		}
		public string Etd
		{
			get { return _Etd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Etd, val, false) == 0 ) return;
		
				if( val != null && val.Length > EtdMax )
					_Etd = val.Substring(0, (int)EtdMax);
				else
					_Etd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Etd");
			}
		}
		public string Ata
		{
			get { return _Ata; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Ata, val, false) == 0 ) return;
		
				if( val != null && val.Length > AtaMax )
					_Ata = val.Substring(0, (int)AtaMax);
				else
					_Ata = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Ata");
			}
		}
		public string Atd
		{
			get { return _Atd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Atd, val, false) == 0 ) return;
		
				if( val != null && val.Length > AtdMax )
					_Atd = val.Substring(0, (int)AtdMax);
				else
					_Atd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Atd");
			}
		}
		public string Finalmanifesteddate
		{
			get { return _Finalmanifesteddate; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Finalmanifesteddate, val, false) == 0 ) return;
		
				if( val != null && val.Length > FinalmanifesteddateMax )
					_Finalmanifesteddate = val.Substring(0, (int)FinalmanifesteddateMax);
				else
					_Finalmanifesteddate = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Finalmanifesteddate");
			}
		}
		public string Portpaircloseddate
		{
			get { return _Portpaircloseddate; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Portpaircloseddate, val, false) == 0 ) return;
		
				if( val != null && val.Length > PortpaircloseddateMax )
					_Portpaircloseddate = val.Substring(0, (int)PortpaircloseddateMax);
				else
					_Portpaircloseddate = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Portpaircloseddate");
			}
		}
		public string Arrivedt
		{
			get { return _Arrivedt; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Arrivedt, val, false) == 0 ) return;
		
				if( val != null && val.Length > ArrivedtMax )
					_Arrivedt = val.Substring(0, (int)ArrivedtMax);
				else
					_Arrivedt = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Arrivedt");
			}
		}
		public string Departuredt
		{
			get { return _Departuredt; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Departuredt, val, false) == 0 ) return;
		
				if( val != null && val.Length > DeparturedtMax )
					_Departuredt = val.Substring(0, (int)DeparturedtMax);
				else
					_Departuredt = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Departuredt");
			}
		}
		public string Arrived
		{
			get { return _Arrived; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Arrived, val, false) == 0 ) return;
		
				if( val != null && val.Length > ArrivedMax )
					_Arrived = val.Substring(0, (int)ArrivedMax);
				else
					_Arrived = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Arrived");
			}
		}
		public string Departed
		{
			get { return _Departed; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Departed, val, false) == 0 ) return;
		
				if( val != null && val.Length > DepartedMax )
					_Departed = val.Substring(0, (int)DepartedMax);
				else
					_Departed = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Departed");
			}
		}

		#endregion	// #region Column Properties

		#region Foreign Key Fields



		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties



		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsVwArcVoyageDetail() : base() {}
		public ClsVwArcVoyageDetail(DataRow dr) : base(dr) {}
		public ClsVwArcVoyageDetail(ClsVwArcVoyageDetail src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Voyno = null;
			Traderoute = null;
			Vesselcd = null;
			Vesselowner = null;
			Locationcd = null;
			Activeflg = null;
			Activitytype = null;
			Eta = null;
			Etd = null;
			Ata = null;
			Atd = null;
			Finalmanifesteddate = null;
			Portpaircloseddate = null;
			Arrivedt = null;
			Departuredt = null;
			Arrived = null;
			Departed = null;
		}

		public void CopyFrom(ClsVwArcVoyageDetail src)
		{
			Voyno = src._Voyno;
			Traderoute = src._Traderoute;
			Vesselcd = src._Vesselcd;
			Vesselowner = src._Vesselowner;
			Locationcd = src._Locationcd;
			Activeflg = src._Activeflg;
			Activitytype = src._Activitytype;
			Eta = src._Eta;
			Etd = src._Etd;
			Ata = src._Ata;
			Atd = src._Atd;
			Finalmanifesteddate = src._Finalmanifesteddate;
			Portpaircloseddate = src._Portpaircloseddate;
			Arrivedt = src._Arrivedt;
			Departuredt = src._Departuredt;
			Arrived = src._Arrived;
			Departed = src._Departed;
		}

		public override bool ReloadFromDB()
		{
			ClsVwArcVoyageDetail tmp = null;	//No primary key can't refresh;
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

			DbParameter[] p = new DbParameter[17];

			p[0] = Connection.GetParameter
				("@VoyNo", Voyno);
			p[1] = Connection.GetParameter
				("@TradeRoute", Traderoute);
			p[2] = Connection.GetParameter
				("@VesselCd", Vesselcd);
			p[3] = Connection.GetParameter
				("@VesselOwner", Vesselowner);
			p[4] = Connection.GetParameter
				("@LocationCd", Locationcd);
			p[5] = Connection.GetParameter
				("@ActiveFlg", Activeflg);
			p[6] = Connection.GetParameter
				("@ActivityType", Activitytype);
			p[7] = Connection.GetParameter
				("@Eta", Eta);
			p[8] = Connection.GetParameter
				("@Etd", Etd);
			p[9] = Connection.GetParameter
				("@Ata", Ata);
			p[10] = Connection.GetParameter
				("@Atd", Atd);
			p[11] = Connection.GetParameter
				("@FinalManifestedDate", Finalmanifesteddate);
			p[12] = Connection.GetParameter
				("@PortPairClosedDate", Portpaircloseddate);
			p[13] = Connection.GetParameter
				("@ArriveDt", Arrivedt);
			p[14] = Connection.GetParameter
				("@DepartureDt", Departuredt);
			p[15] = Connection.GetParameter
				("@Arrived", Arrived);
			p[16] = Connection.GetParameter
				("@Departed", Departed);

			const string sql = @"INSERT INTO vw_arc_voyage_detail VALUES
				(@VoyNo,@TradeRoute,@VesselCd
				,@VesselOwner,@LocationCd,@ActiveFlg
				,@ActivityType,@Eta,@Etd
				,@Ata,@Atd,@FinalManifestedDate
				,@PortPairClosedDate,@ArriveDt,@DepartureDt
				,@Arrived,@Departed)";
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

			Voyno = ClsConvert.ToString(dr["VoyNo"]);
			Traderoute = ClsConvert.ToString(dr["TradeRoute"]);
			Vesselcd = ClsConvert.ToString(dr["VesselCd"]);
			Vesselowner = ClsConvert.ToString(dr["VesselOwner"]);
			Locationcd = ClsConvert.ToString(dr["LocationCd"]);
			Activeflg = ClsConvert.ToString(dr["ActiveFlg"]);
			Activitytype = ClsConvert.ToString(dr["ActivityType"]);
			Eta = ClsConvert.ToString(dr["Eta"]);
			Etd = ClsConvert.ToString(dr["Etd"]);
			Ata = ClsConvert.ToString(dr["Ata"]);
			Atd = ClsConvert.ToString(dr["Atd"]);
			Finalmanifesteddate = ClsConvert.ToString(dr["FinalManifestedDate"]);
			Portpaircloseddate = ClsConvert.ToString(dr["PortPairClosedDate"]);
			Arrivedt = ClsConvert.ToString(dr["ArriveDt"]);
			Departuredt = ClsConvert.ToString(dr["DepartureDt"]);
			Arrived = ClsConvert.ToString(dr["Arrived"]);
			Departed = ClsConvert.ToString(dr["Departed"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Voyno = ClsConvert.ToString(dr["VoyNo", v]);
			Traderoute = ClsConvert.ToString(dr["TradeRoute", v]);
			Vesselcd = ClsConvert.ToString(dr["VesselCd", v]);
			Vesselowner = ClsConvert.ToString(dr["VesselOwner", v]);
			Locationcd = ClsConvert.ToString(dr["LocationCd", v]);
			Activeflg = ClsConvert.ToString(dr["ActiveFlg", v]);
			Activitytype = ClsConvert.ToString(dr["ActivityType", v]);
			Eta = ClsConvert.ToString(dr["Eta", v]);
			Etd = ClsConvert.ToString(dr["Etd", v]);
			Ata = ClsConvert.ToString(dr["Ata", v]);
			Atd = ClsConvert.ToString(dr["Atd", v]);
			Finalmanifesteddate = ClsConvert.ToString(dr["FinalManifestedDate", v]);
			Portpaircloseddate = ClsConvert.ToString(dr["PortPairClosedDate", v]);
			Arrivedt = ClsConvert.ToString(dr["ArriveDt", v]);
			Departuredt = ClsConvert.ToString(dr["DepartureDt", v]);
			Arrived = ClsConvert.ToString(dr["Arrived", v]);
			Departed = ClsConvert.ToString(dr["Departed", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["VoyNo"] = ClsConvert.ToDbObject(Voyno);
			dr["TradeRoute"] = ClsConvert.ToDbObject(Traderoute);
			dr["VesselCd"] = ClsConvert.ToDbObject(Vesselcd);
			dr["VesselOwner"] = ClsConvert.ToDbObject(Vesselowner);
			dr["LocationCd"] = ClsConvert.ToDbObject(Locationcd);
			dr["ActiveFlg"] = ClsConvert.ToDbObject(Activeflg);
			dr["ActivityType"] = ClsConvert.ToDbObject(Activitytype);
			dr["Eta"] = ClsConvert.ToDbObject(Eta);
			dr["Etd"] = ClsConvert.ToDbObject(Etd);
			dr["Ata"] = ClsConvert.ToDbObject(Ata);
			dr["Atd"] = ClsConvert.ToDbObject(Atd);
			dr["FinalManifestedDate"] = ClsConvert.ToDbObject(Finalmanifesteddate);
			dr["PortPairClosedDate"] = ClsConvert.ToDbObject(Portpaircloseddate);
			dr["ArriveDt"] = ClsConvert.ToDbObject(Arrivedt);
			dr["DepartureDt"] = ClsConvert.ToDbObject(Departuredt);
			dr["Arrived"] = ClsConvert.ToDbObject(Arrived);
			dr["Departed"] = ClsConvert.ToDbObject(Departed);
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