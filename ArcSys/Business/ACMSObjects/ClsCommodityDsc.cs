using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ACMS.Business
{
	public partial class ClsCommodityDsc : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ACMS"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "R_COMMODITY_DSC";
		public const int PrimaryKeyCount = 1;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] { "COMMODITY_CD" };
		}

		public const string SelectSQL = "SELECT * FROM R_COMMODITY_DSC";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Commodity_CdMax = 30;
		public const int Commodity_DscMax = 50;
		public const int Delete_FlMax = 1;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected string _Commodity_Cd;
		protected string _Commodity_Dsc;
		protected string _Delete_Fl;
		protected Double? _Default_Wt;
		protected Double? _Default_Ht;
		protected Double? _Default_Length;
		protected Double? _Default_Width;
		protected Double? _Default_Volume;

		#endregion	// #region Column Fields

		#region Column Properties

		public string Commodity_Cd
		{
			get { return _Commodity_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Commodity_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Commodity_CdMax )
					_Commodity_Cd = val.Substring(0, (int)Commodity_CdMax);
				else
					_Commodity_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Commodity_Cd");
			}
		}
		public string Commodity_Dsc
		{
			get { return _Commodity_Dsc; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Commodity_Dsc, val, false) == 0 ) return;
		
				if( val != null && val.Length > Commodity_DscMax )
					_Commodity_Dsc = val.Substring(0, (int)Commodity_DscMax);
				else
					_Commodity_Dsc = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Commodity_Dsc");
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
		public Double? Default_Wt
		{
			get { return _Default_Wt; }
			set
			{
				if( _Default_Wt == value ) return;
		
				_Default_Wt = value;
				_IsDirty = true;
				NotifyPropertyChanged("Default_Wt");
			}
		}
		public Double? Default_Ht
		{
			get { return _Default_Ht; }
			set
			{
				if( _Default_Ht == value ) return;
		
				_Default_Ht = value;
				_IsDirty = true;
				NotifyPropertyChanged("Default_Ht");
			}
		}
		public Double? Default_Length
		{
			get { return _Default_Length; }
			set
			{
				if( _Default_Length == value ) return;
		
				_Default_Length = value;
				_IsDirty = true;
				NotifyPropertyChanged("Default_Length");
			}
		}
		public Double? Default_Width
		{
			get { return _Default_Width; }
			set
			{
				if( _Default_Width == value ) return;
		
				_Default_Width = value;
				_IsDirty = true;
				NotifyPropertyChanged("Default_Width");
			}
		}
		public Double? Default_Volume
		{
			get { return _Default_Volume; }
			set
			{
				if( _Default_Volume == value ) return;
		
				_Default_Volume = value;
				_IsDirty = true;
				NotifyPropertyChanged("Default_Volume");
			}
		}

		#endregion	// #region Column Properties

		#region Foreign Key Fields



		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties



		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsCommodityDsc() : base() {}
		public ClsCommodityDsc(DataRow dr) : base(dr) {}
		public ClsCommodityDsc(ClsCommodityDsc src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Commodity_Cd = null;
			Commodity_Dsc = null;
			Delete_Fl = null;
			Default_Wt = null;
			Default_Ht = null;
			Default_Length = null;
			Default_Width = null;
			Default_Volume = null;
		}

		public void CopyFrom(ClsCommodityDsc src)
		{
			Commodity_Cd = src._Commodity_Cd;
			Commodity_Dsc = src._Commodity_Dsc;
			Delete_Fl = src._Delete_Fl;
			Default_Wt = src._Default_Wt;
			Default_Ht = src._Default_Ht;
			Default_Length = src._Default_Length;
			Default_Width = src._Default_Width;
			Default_Volume = src._Default_Volume;
		}

		public override bool ReloadFromDB()
		{
			ClsCommodityDsc tmp = ClsCommodityDsc.GetUsingKey(Commodity_Cd);
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
				("@COMMODITY_CD", Commodity_Cd);
			p[1] = Connection.GetParameter
				("@COMMODITY_DSC", Commodity_Dsc);
			p[2] = Connection.GetParameter
				("@DELETE_FL", Delete_Fl);
			p[3] = Connection.GetParameter
				("@DEFAULT_WT", Default_Wt);
			p[4] = Connection.GetParameter
				("@DEFAULT_HT", Default_Ht);
			p[5] = Connection.GetParameter
				("@DEFAULT_LENGTH", Default_Length);
			p[6] = Connection.GetParameter
				("@DEFAULT_WIDTH", Default_Width);
			p[7] = Connection.GetParameter
				("@DEFAULT_VOLUME", Default_Volume);

			const string sql = @"
				INSERT INTO R_COMMODITY_DSC
					(COMMODITY_CD, COMMODITY_DSC, DELETE_FL,
					DEFAULT_WT, DEFAULT_HT, DEFAULT_LENGTH,
					DEFAULT_WIDTH, DEFAULT_VOLUME)
				VALUES
					(@COMMODITY_CD, @COMMODITY_DSC, @DELETE_FL,
					@DEFAULT_WT, @DEFAULT_HT, @DEFAULT_LENGTH,
					@DEFAULT_WIDTH, @DEFAULT_VOLUME)

					";
			int ret = Connection.RunSQL(sql, p);


			return ret;
		}
		public override int Update()
		{
			DbParameter[] p = new DbParameter[8];

			p[0] = Connection.GetParameter
				("@COMMODITY_DSC", Commodity_Dsc);
			p[1] = Connection.GetParameter
				("@DELETE_FL", Delete_Fl);
			p[2] = Connection.GetParameter
				("@DEFAULT_WT", Default_Wt);
			p[3] = Connection.GetParameter
				("@DEFAULT_HT", Default_Ht);
			p[4] = Connection.GetParameter
				("@DEFAULT_LENGTH", Default_Length);
			p[5] = Connection.GetParameter
				("@DEFAULT_WIDTH", Default_Width);
			p[6] = Connection.GetParameter
				("@DEFAULT_VOLUME", Default_Volume);
			p[7] = Connection.GetParameter
				("@COMMODITY_CD", Commodity_Cd);

			const string sql = @"
				UPDATE R_COMMODITY_DSC SET
					COMMODITY_DSC = @COMMODITY_DSC,
					DELETE_FL = @DELETE_FL,
					DEFAULT_WT = @DEFAULT_WT,
					DEFAULT_HT = @DEFAULT_HT,
					DEFAULT_LENGTH = @DEFAULT_LENGTH,
					DEFAULT_WIDTH = @DEFAULT_WIDTH,
					DEFAULT_VOLUME = @DEFAULT_VOLUME
				WHERE
					COMMODITY_CD = @COMMODITY_CD

					";
			int ret = Connection.RunSQL(sql, p);


			return ret;
		}
		public override int Delete()
		{
			DbParameter[] p = new DbParameter[1];

			p[0] = Connection.GetParameter
				("@COMMODITY_CD", Commodity_Cd);

			const string sql = @"
				DELETE FROM R_COMMODITY_DSC WHERE
				COMMODITY_CD=@COMMODITY_CD";
			return Connection.RunSQL(sql, p);
		}
		#endregion		// #region Insert, Update, Delete

		#region Conversion methods

		public override void LoadFromDataReader(DbDataReader dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataReader: DataReader parameter was null");

			Commodity_Cd = ClsConvert.ToString(dr["COMMODITY_CD"]);
			Commodity_Dsc = ClsConvert.ToString(dr["COMMODITY_DSC"]);
			Delete_Fl = ClsConvert.ToString(dr["DELETE_FL"]);
			Default_Wt = ClsConvert.ToDoubleNullable(dr["DEFAULT_WT"]);
			Default_Ht = ClsConvert.ToDoubleNullable(dr["DEFAULT_HT"]);
			Default_Length = ClsConvert.ToDoubleNullable(dr["DEFAULT_LENGTH"]);
			Default_Width = ClsConvert.ToDoubleNullable(dr["DEFAULT_WIDTH"]);
			Default_Volume = ClsConvert.ToDoubleNullable(dr["DEFAULT_VOLUME"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Commodity_Cd = ClsConvert.ToString(dr["COMMODITY_CD", v]);
			Commodity_Dsc = ClsConvert.ToString(dr["COMMODITY_DSC", v]);
			Delete_Fl = ClsConvert.ToString(dr["DELETE_FL", v]);
			Default_Wt = ClsConvert.ToDoubleNullable(dr["DEFAULT_WT", v]);
			Default_Ht = ClsConvert.ToDoubleNullable(dr["DEFAULT_HT", v]);
			Default_Length = ClsConvert.ToDoubleNullable(dr["DEFAULT_LENGTH", v]);
			Default_Width = ClsConvert.ToDoubleNullable(dr["DEFAULT_WIDTH", v]);
			Default_Volume = ClsConvert.ToDoubleNullable(dr["DEFAULT_VOLUME", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["COMMODITY_CD"] = ClsConvert.ToDbObject(Commodity_Cd);
			dr["COMMODITY_DSC"] = ClsConvert.ToDbObject(Commodity_Dsc);
			dr["DELETE_FL"] = ClsConvert.ToDbObject(Delete_Fl);
			dr["DEFAULT_WT"] = ClsConvert.ToDbObject(Default_Wt);
			dr["DEFAULT_HT"] = ClsConvert.ToDbObject(Default_Ht);
			dr["DEFAULT_LENGTH"] = ClsConvert.ToDbObject(Default_Length);
			dr["DEFAULT_WIDTH"] = ClsConvert.ToDbObject(Default_Width);
			dr["DEFAULT_VOLUME"] = ClsConvert.ToDbObject(Default_Volume);
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

		public static ClsCommodityDsc GetUsingKey(string Commodity_Cd)
		{
			object[] vals = new object[] {Commodity_Cd};
			DataRow dr = Connection.GetDataRowUsingKey
				(TableName, GetPrimaryKeys(), vals);
			return ( dr == null ) ? null : new ClsCommodityDsc(dr);
		}

		#endregion		// #region Static Methods
	}
}