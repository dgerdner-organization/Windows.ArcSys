using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsTradingPartner : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ArcSys"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "R_TRADING_PARTNER";
		public const int PrimaryKeyCount = 1;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] { "TRADING_PARTNER_CD" };
		}

		public const string SelectSQL = "SELECT * FROM R_TRADING_PARTNER";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Trading_Partner_CdMax = 10;
		public const int Partner_DscMax = 50;
		public const int Active_FlgMax = 1;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected string _Trading_Partner_Cd;
		protected string _Partner_Dsc;
		protected decimal? _Outbound_Isa_Nbr;
		protected string _Active_Flg;

		#endregion	// #region Column Fields

		#region Column Properties

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
		public string Partner_Dsc
		{
			get { return _Partner_Dsc; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Partner_Dsc, val, false) == 0 ) return;
		
				if( val != null && val.Length > Partner_DscMax )
					_Partner_Dsc = val.Substring(0, (int)Partner_DscMax);
				else
					_Partner_Dsc = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Partner_Dsc");
			}
		}
		public decimal? Outbound_Isa_Nbr
		{
			get { return _Outbound_Isa_Nbr; }
			set
			{
				if( _Outbound_Isa_Nbr == value ) return;
		
				_Outbound_Isa_Nbr = value;
				_IsDirty = true;
				NotifyPropertyChanged("Outbound_Isa_Nbr");
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

		#endregion	// #region Column Properties

		#region Foreign Key Fields



		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties



		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsTradingPartner() : base() {}
		public ClsTradingPartner(DataRow dr) : base(dr) {}
		public ClsTradingPartner(ClsTradingPartner src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Trading_Partner_Cd = null;
			Partner_Dsc = null;
			Outbound_Isa_Nbr = null;
			Active_Flg = null;
		}

		public void CopyFrom(ClsTradingPartner src)
		{
			Trading_Partner_Cd = src._Trading_Partner_Cd;
			Partner_Dsc = src._Partner_Dsc;
			Outbound_Isa_Nbr = src._Outbound_Isa_Nbr;
			Active_Flg = src._Active_Flg;
		}

		public override bool ReloadFromDB()
		{
			ClsTradingPartner tmp = ClsTradingPartner.GetUsingKey(Trading_Partner_Cd);
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

			DbParameter[] p = new DbParameter[4];

			p[0] = Connection.GetParameter
				("@TRADING_PARTNER_CD", Trading_Partner_Cd);
			p[1] = Connection.GetParameter
				("@PARTNER_DSC", Partner_Dsc);
			p[2] = Connection.GetParameter
				("@OUTBOUND_ISA_NBR", Outbound_Isa_Nbr);
			p[3] = Connection.GetParameter
				("@ACTIVE_FLG", Active_Flg);

			const string sql = @"
				INSERT INTO R_TRADING_PARTNER
					(TRADING_PARTNER_CD, PARTNER_DSC, OUTBOUND_ISA_NBR,
					ACTIVE_FLG)
				VALUES
					(@TRADING_PARTNER_CD, @PARTNER_DSC, @OUTBOUND_ISA_NBR,
					@ACTIVE_FLG)
				RETURNING
					
				INTO
					";
			int ret = Connection.RunSQL(sql, p);


			return ret;
		}
		public override int Update()
		{
			DbParameter[] p = new DbParameter[4];

			p[0] = Connection.GetParameter
				("@PARTNER_DSC", Partner_Dsc);
			p[1] = Connection.GetParameter
				("@OUTBOUND_ISA_NBR", Outbound_Isa_Nbr);
			p[2] = Connection.GetParameter
				("@ACTIVE_FLG", Active_Flg);
			p[3] = Connection.GetParameter
				("@TRADING_PARTNER_CD", Trading_Partner_Cd);

			const string sql = @"
				UPDATE R_TRADING_PARTNER SET
					PARTNER_DSC = @PARTNER_DSC,
					OUTBOUND_ISA_NBR = @OUTBOUND_ISA_NBR,
					ACTIVE_FLG = @ACTIVE_FLG
				WHERE
					TRADING_PARTNER_CD = @TRADING_PARTNER_CD
					";
			int ret = Connection.RunSQL(sql, p);


			return ret;
		}
		public override int Delete()
		{
			DbParameter[] p = new DbParameter[1];

			p[0] = Connection.GetParameter
				("@TRADING_PARTNER_CD", Trading_Partner_Cd);

			const string sql = @"
				DELETE FROM R_TRADING_PARTNER WHERE
				TRADING_PARTNER_CD=@TRADING_PARTNER_CD";
			return Connection.RunSQL(sql, p);
		}
		#endregion		// #region Insert, Update, Delete

		#region Conversion methods

		public override void LoadFromDataReader(DbDataReader dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataReader: DataReader parameter was null");

			Trading_Partner_Cd = ClsConvert.ToString(dr["TRADING_PARTNER_CD"]);
			Partner_Dsc = ClsConvert.ToString(dr["PARTNER_DSC"]);
			Outbound_Isa_Nbr = ClsConvert.ToDecimalNullable(dr["OUTBOUND_ISA_NBR"]);
			Active_Flg = ClsConvert.ToString(dr["ACTIVE_FLG"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Trading_Partner_Cd = ClsConvert.ToString(dr["TRADING_PARTNER_CD", v]);
			Partner_Dsc = ClsConvert.ToString(dr["PARTNER_DSC", v]);
			Outbound_Isa_Nbr = ClsConvert.ToDecimalNullable(dr["OUTBOUND_ISA_NBR", v]);
			Active_Flg = ClsConvert.ToString(dr["ACTIVE_FLG", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["TRADING_PARTNER_CD"] = ClsConvert.ToDbObject(Trading_Partner_Cd);
			dr["PARTNER_DSC"] = ClsConvert.ToDbObject(Partner_Dsc);
			dr["OUTBOUND_ISA_NBR"] = ClsConvert.ToDbObject(Outbound_Isa_Nbr);
			dr["ACTIVE_FLG"] = ClsConvert.ToDbObject(Active_Flg);
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

		public static ClsTradingPartner GetUsingKey(string Trading_Partner_Cd)
		{
			object[] vals = new object[] {Trading_Partner_Cd};
			DataRow dr = Connection.GetDataRowUsingKey
				(TableName, GetPrimaryKeys(), vals);
			return ( dr == null ) ? null : new ClsTradingPartner(dr);
		}

		#endregion		// #region Static Methods
	}
}