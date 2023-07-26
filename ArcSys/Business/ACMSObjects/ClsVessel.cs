using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ACMS.Business
{
	public partial class ClsVessel : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ACMS"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "R_VESSEL";
		public const int PrimaryKeyCount = 1;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] { "VESSEL_CD" };
		}

		public const string SelectSQL = "SELECT * FROM R_VESSEL";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Vessel_CdMax = 4;
		public const int Vessel_DscMax = 50;
		public const int FlagMax = 10;
		public const int Delete_FlMax = 1;
		public const int IrcsMax = 15;
		public const int NationalityMax = 20;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected string _Vessel_Cd;
		protected string _Vessel_Dsc;
		protected decimal? _Max_Wt;
		protected decimal? _Max_Ht;
		protected string _Flag;
		protected string _Delete_Fl;
		protected decimal? _Year_Built;
		protected string _Ircs;
		protected string _Nationality;

		#endregion	// #region Column Fields

		#region Column Properties

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
		public string Vessel_Dsc
		{
			get { return _Vessel_Dsc; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Vessel_Dsc, val, false) == 0 ) return;
		
				if( val != null && val.Length > Vessel_DscMax )
					_Vessel_Dsc = val.Substring(0, (int)Vessel_DscMax);
				else
					_Vessel_Dsc = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Vessel_Dsc");
			}
		}
		public decimal? Max_Wt
		{
			get { return _Max_Wt; }
			set
			{
				if( _Max_Wt == value ) return;
		
				_Max_Wt = value;
				_IsDirty = true;
				NotifyPropertyChanged("Max_Wt");
			}
		}
		public decimal? Max_Ht
		{
			get { return _Max_Ht; }
			set
			{
				if( _Max_Ht == value ) return;
		
				_Max_Ht = value;
				_IsDirty = true;
				NotifyPropertyChanged("Max_Ht");
			}
		}
		public string Flag
		{
			get { return _Flag; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Flag, val, false) == 0 ) return;
		
				if( val != null && val.Length > FlagMax )
					_Flag = val.Substring(0, (int)FlagMax);
				else
					_Flag = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Flag");
			}
		}
		public string Delete_Fl
		{
			get { return _Delete_Fl; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Delete_Fl, val, false) == 0 ) return;
		
				if( val != null && val.Length > Delete_FlMax )
					_Delete_Fl = val.Substring(0, (int)Delete_FlMax);
				else
					_Delete_Fl = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Delete_Fl");
			}
		}
		public decimal? Year_Built
		{
			get { return _Year_Built; }
			set
			{
				if( _Year_Built == value ) return;
		
				_Year_Built = value;
				_IsDirty = true;
				NotifyPropertyChanged("Year_Built");
			}
		}
		public string Ircs
		{
			get { return _Ircs; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Ircs, val, false) == 0 ) return;
		
				if( val != null && val.Length > IrcsMax )
					_Ircs = val.Substring(0, (int)IrcsMax);
				else
					_Ircs = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Ircs");
			}
		}
		public string Nationality
		{
			get { return _Nationality; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Nationality, val, false) == 0 ) return;
		
				if( val != null && val.Length > NationalityMax )
					_Nationality = val.Substring(0, (int)NationalityMax);
				else
					_Nationality = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Nationality");
			}
		}

		#endregion	// #region Column Properties

		#region Foreign Key Fields



		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties



		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsVessel() : base() {}
		public ClsVessel(DataRow dr) : base(dr) {}
		public ClsVessel(ClsVessel src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Vessel_Cd = null;
			Vessel_Dsc = null;
			Max_Wt = null;
			Max_Ht = null;
			Flag = null;
			Delete_Fl = null;
			Year_Built = null;
			Ircs = null;
			Nationality = null;
		}

		public void CopyFrom(ClsVessel src)
		{
			Vessel_Cd = src._Vessel_Cd;
			Vessel_Dsc = src._Vessel_Dsc;
			Max_Wt = src._Max_Wt;
			Max_Ht = src._Max_Ht;
			Flag = src._Flag;
			Delete_Fl = src._Delete_Fl;
			Year_Built = src._Year_Built;
			Ircs = src._Ircs;
			Nationality = src._Nationality;
		}

		public override bool ReloadFromDB()
		{
			ClsVessel tmp = ClsVessel.GetUsingKey(Vessel_Cd);
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
				("@VESSEL_CD", Vessel_Cd);
			p[1] = Connection.GetParameter
				("@VESSEL_DSC", Vessel_Dsc);
			p[2] = Connection.GetParameter
				("@MAX_WT", Max_Wt);
			p[3] = Connection.GetParameter
				("@MAX_HT", Max_Ht);
			p[4] = Connection.GetParameter
				("@FLAG", Flag);
			p[5] = Connection.GetParameter
				("@DELETE_FL", Delete_Fl);
			p[6] = Connection.GetParameter
				("@YEAR_BUILT", Year_Built);
			p[7] = Connection.GetParameter
				("@IRCS", Ircs);
			p[8] = Connection.GetParameter
				("@NATIONALITY", Nationality);

			const string sql = @"
				INSERT INTO R_VESSEL
					(VESSEL_CD, VESSEL_DSC, MAX_WT,
					MAX_HT, FLAG, DELETE_FL,
					YEAR_BUILT, IRCS, NATIONALITY)
				VALUES
					(@VESSEL_CD, @VESSEL_DSC, @MAX_WT,
					@MAX_HT, @FLAG, @DELETE_FL,
					@YEAR_BUILT, @IRCS, @NATIONALITY)
					";
			int ret = Connection.RunSQL(sql, p);


			return ret;
		}
		public override int Update()
		{
			DbParameter[] p = new DbParameter[9];

			p[0] = Connection.GetParameter
				("@VESSEL_DSC", Vessel_Dsc);
			p[1] = Connection.GetParameter
				("@MAX_WT", Max_Wt);
			p[2] = Connection.GetParameter
				("@MAX_HT", Max_Ht);
			p[3] = Connection.GetParameter
				("@FLAG", Flag);
			p[4] = Connection.GetParameter
				("@DELETE_FL", Delete_Fl);
			p[5] = Connection.GetParameter
				("@YEAR_BUILT", Year_Built);
			p[6] = Connection.GetParameter
				("@IRCS", Ircs);
			p[7] = Connection.GetParameter
				("@NATIONALITY", Nationality);
			p[8] = Connection.GetParameter
				("@VESSEL_CD", Vessel_Cd);

			const string sql = @"
				UPDATE R_VESSEL SET
					VESSEL_DSC = @VESSEL_DSC,
					MAX_WT = @MAX_WT,
					MAX_HT = @MAX_HT,
					FLAG = @FLAG,
					DELETE_FL = @DELETE_FL,
					YEAR_BUILT = @YEAR_BUILT,
					IRCS = @IRCS,
					NATIONALITY = @NATIONALITY
				WHERE
					VESSEL_CD = @VESSEL_CD
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

			Vessel_Cd = ClsConvert.ToString(dr["VESSEL_CD"]);
			Vessel_Dsc = ClsConvert.ToString(dr["VESSEL_DSC"]);
			Max_Wt = ClsConvert.ToDecimalNullable(dr["MAX_WT"]);
			Max_Ht = ClsConvert.ToDecimalNullable(dr["MAX_HT"]);
			Flag = ClsConvert.ToString(dr["FLAG"]);
			Delete_Fl = ClsConvert.ToString(dr["DELETE_FL"]);
			Year_Built = ClsConvert.ToDecimalNullable(dr["YEAR_BUILT"]);
			Ircs = ClsConvert.ToString(dr["IRCS"]);
			Nationality = ClsConvert.ToString(dr["NATIONALITY"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Vessel_Cd = ClsConvert.ToString(dr["VESSEL_CD", v]);
			Vessel_Dsc = ClsConvert.ToString(dr["VESSEL_DSC", v]);
			Max_Wt = ClsConvert.ToDecimalNullable(dr["MAX_WT", v]);
			Max_Ht = ClsConvert.ToDecimalNullable(dr["MAX_HT", v]);
			Flag = ClsConvert.ToString(dr["FLAG", v]);
			Delete_Fl = ClsConvert.ToString(dr["DELETE_FL", v]);
			Year_Built = ClsConvert.ToDecimalNullable(dr["YEAR_BUILT", v]);
			Ircs = ClsConvert.ToString(dr["IRCS", v]);
			Nationality = ClsConvert.ToString(dr["NATIONALITY", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["VESSEL_CD"] = ClsConvert.ToDbObject(Vessel_Cd);
			dr["VESSEL_DSC"] = ClsConvert.ToDbObject(Vessel_Dsc);
			dr["MAX_WT"] = ClsConvert.ToDbObject(Max_Wt);
			dr["MAX_HT"] = ClsConvert.ToDbObject(Max_Ht);
			dr["FLAG"] = ClsConvert.ToDbObject(Flag);
			dr["DELETE_FL"] = ClsConvert.ToDbObject(Delete_Fl);
			dr["YEAR_BUILT"] = ClsConvert.ToDbObject(Year_Built);
			dr["IRCS"] = ClsConvert.ToDbObject(Ircs);
			dr["NATIONALITY"] = ClsConvert.ToDbObject(Nationality);
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

		public static ClsVessel GetUsingKey(string Vessel_Cd)
		{
			object[] vals = new object[] {Vessel_Cd};
			DataRow dr = Connection.GetDataRowUsingKey
				(TableName, GetPrimaryKeys(), vals);
			return ( dr == null ) ? null : new ClsVessel(dr);
		}

		#endregion		// #region Static Methods
	}
}