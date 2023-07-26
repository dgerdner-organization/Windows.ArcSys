using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsEdiTranslate : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ArcSys"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "R_EDI_TRANSLATE";
		public const int PrimaryKeyCount = 1;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] { "EDI_TRANSLATE_ID" };
		}

		public const string SelectSQL = @"SELECT * FROM R_EDI_TRANSLATE 
				INNER JOIN R_TRADING_PARTNER
				ON R_EDI_TRANSLATE.TRADING_PARTNER_CD=R_TRADING_PARTNER.TRADING_PARTNER_CD ";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Trading_Partner_CdMax = 10;
		public const int Segment_CdMax = 10;
		public const int Element_DscMax = 100;
		public const int Our_ValueMax = 100;
		public const int Partner_ValueMax = 100;
		public const int Direction_IndMax = 1;
		public const int Qualifier_CdMax = 10;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected Int64? _Edi_Translate_ID;
		protected string _Trading_Partner_Cd;
		protected string _Segment_Cd;
		protected Int64? _Element_No;
		protected string _Element_Dsc;
		protected string _Our_Value;
		protected string _Partner_Value;
		protected string _Direction_Ind;
		protected string _Qualifier_Cd;

		#endregion	// #region Column Fields

		#region Column Properties

		public Int64? Edi_Translate_ID
		{
			get { return _Edi_Translate_ID; }
			set
			{
				if( _Edi_Translate_ID == value ) return;
		
				_Edi_Translate_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Edi_Translate_ID");
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
		public string Segment_Cd
		{
			get { return _Segment_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Segment_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Segment_CdMax )
					_Segment_Cd = val.Substring(0, (int)Segment_CdMax);
				else
					_Segment_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Segment_Cd");
			}
		}
		public Int64? Element_No
		{
			get { return _Element_No; }
			set
			{
				if( _Element_No == value ) return;
		
				_Element_No = value;
				_IsDirty = true;
				NotifyPropertyChanged("Element_No");
			}
		}
		public string Element_Dsc
		{
			get { return _Element_Dsc; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Element_Dsc, val, false) == 0 ) return;
		
				if( val != null && val.Length > Element_DscMax )
					_Element_Dsc = val.Substring(0, (int)Element_DscMax);
				else
					_Element_Dsc = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Element_Dsc");
			}
		}
		public string Our_Value
		{
			get { return _Our_Value; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Our_Value, val, false) == 0 ) return;
		
				if( val != null && val.Length > Our_ValueMax )
					_Our_Value = val.Substring(0, (int)Our_ValueMax);
				else
					_Our_Value = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Our_Value");
			}
		}
		public string Partner_Value
		{
			get { return _Partner_Value; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Partner_Value, val, false) == 0 ) return;
		
				if( val != null && val.Length > Partner_ValueMax )
					_Partner_Value = val.Substring(0, (int)Partner_ValueMax);
				else
					_Partner_Value = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Partner_Value");
			}
		}
		public string Direction_Ind
		{
			get { return _Direction_Ind; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Direction_Ind, val, false) == 0 ) return;
		
				if( val != null && val.Length > Direction_IndMax )
					_Direction_Ind = val.Substring(0, (int)Direction_IndMax);
				else
					_Direction_Ind = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Direction_Ind");
			}
		}
		public string Qualifier_Cd
		{
			get { return _Qualifier_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Qualifier_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Qualifier_CdMax )
					_Qualifier_Cd = val.Substring(0, (int)Qualifier_CdMax);
				else
					_Qualifier_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Qualifier_Cd");
			}
		}

		#endregion	// #region Column Properties

		#region Foreign Key Fields



		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties



		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsEdiTranslate() : base() {}
		public ClsEdiTranslate(DataRow dr) : base(dr) {}
		public ClsEdiTranslate(ClsEdiTranslate src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Edi_Translate_ID = null;
			Trading_Partner_Cd = null;
			Segment_Cd = null;
			Element_No = null;
			Element_Dsc = null;
			Our_Value = null;
			Partner_Value = null;
			Direction_Ind = null;
			Qualifier_Cd = null;
		}

		public void CopyFrom(ClsEdiTranslate src)
		{
			Edi_Translate_ID = src._Edi_Translate_ID;
			Trading_Partner_Cd = src._Trading_Partner_Cd;
			Segment_Cd = src._Segment_Cd;
			Element_No = src._Element_No;
			Element_Dsc = src._Element_Dsc;
			Our_Value = src._Our_Value;
			Partner_Value = src._Partner_Value;
			Direction_Ind = src._Direction_Ind;
			Qualifier_Cd = src._Qualifier_Cd;
		}

		public override bool ReloadFromDB()
		{
			ClsEdiTranslate tmp = ClsEdiTranslate.GetUsingKey(Edi_Translate_ID.Value);
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
				("@TRADING_PARTNER_CD", Trading_Partner_Cd);
			p[1] = Connection.GetParameter
				("@SEGMENT_CD", Segment_Cd);
			p[2] = Connection.GetParameter
				("@ELEMENT_NO", Element_No);
			p[3] = Connection.GetParameter
				("@ELEMENT_DSC", Element_Dsc);
			p[4] = Connection.GetParameter
				("@OUR_VALUE", Our_Value);
			p[5] = Connection.GetParameter
				("@PARTNER_VALUE", Partner_Value);
			p[6] = Connection.GetParameter
				("@DIRECTION_IND", Direction_Ind);
			p[7] = Connection.GetParameter
				("@QUALIFIER_CD", Qualifier_Cd);
			p[8] = Connection.GetParameter
				("@EDI_TRANSLATE_ID", Edi_Translate_ID, ParameterDirection.Output, DbType.Int64, 0);

			const string sql = @"
				INSERT INTO R_EDI_TRANSLATE
					(EDI_TRANSLATE_ID, TRADING_PARTNER_CD, SEGMENT_CD,
					ELEMENT_NO, ELEMENT_DSC, OUR_VALUE,
					PARTNER_VALUE, DIRECTION_IND, QUALIFIER_CD)
				VALUES
					(EDI_TRANSLATE_ID_SEQ.NEXTVAL, @TRADING_PARTNER_CD, @SEGMENT_CD,
					@ELEMENT_NO, @ELEMENT_DSC, @OUR_VALUE,
					@PARTNER_VALUE, @DIRECTION_IND, @QUALIFIER_CD)
				RETURNING
					EDI_TRANSLATE_ID
				INTO
					@EDI_TRANSLATE_ID";
			int ret = Connection.RunSQL(sql, p);

			Edi_Translate_ID = ClsConvert.ToInt64Nullable(p[8].Value);
			return ret;
		}
		public override int Update()
		{
			DbParameter[] p = new DbParameter[9];

			p[0] = Connection.GetParameter
				("@TRADING_PARTNER_CD", Trading_Partner_Cd);
			p[1] = Connection.GetParameter
				("@SEGMENT_CD", Segment_Cd);
			p[2] = Connection.GetParameter
				("@ELEMENT_NO", Element_No);
			p[3] = Connection.GetParameter
				("@ELEMENT_DSC", Element_Dsc);
			p[4] = Connection.GetParameter
				("@OUR_VALUE", Our_Value);
			p[5] = Connection.GetParameter
				("@PARTNER_VALUE", Partner_Value);
			p[6] = Connection.GetParameter
				("@DIRECTION_IND", Direction_Ind);
			p[7] = Connection.GetParameter
				("@QUALIFIER_CD", Qualifier_Cd);
			p[8] = Connection.GetParameter
				("@EDI_TRANSLATE_ID", Edi_Translate_ID);

			const string sql = @"
				UPDATE R_EDI_TRANSLATE SET
					TRADING_PARTNER_CD = @TRADING_PARTNER_CD,
					SEGMENT_CD = @SEGMENT_CD,
					ELEMENT_NO = @ELEMENT_NO,
					ELEMENT_DSC = @ELEMENT_DSC,
					OUR_VALUE = @OUR_VALUE,
					PARTNER_VALUE = @PARTNER_VALUE,
					DIRECTION_IND = @DIRECTION_IND,
					QUALIFIER_CD = @QUALIFIER_CD
				WHERE
					EDI_TRANSLATE_ID = @EDI_TRANSLATE_ID
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
				("@EDI_TRANSLATE_ID", Edi_Translate_ID);

			const string sql = @"
				DELETE FROM R_EDI_TRANSLATE WHERE
				EDI_TRANSLATE_ID=@EDI_TRANSLATE_ID";
			return Connection.RunSQL(sql, p);
		}
		#endregion		// #region Insert, Update, Delete

		#region Conversion methods

		public override void LoadFromDataReader(DbDataReader dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataReader: DataReader parameter was null");

			Edi_Translate_ID = ClsConvert.ToInt64Nullable(dr["EDI_TRANSLATE_ID"]);
			Trading_Partner_Cd = ClsConvert.ToString(dr["TRADING_PARTNER_CD"]);
			Segment_Cd = ClsConvert.ToString(dr["SEGMENT_CD"]);
			Element_No = ClsConvert.ToInt64Nullable(dr["ELEMENT_NO"]);
			Element_Dsc = ClsConvert.ToString(dr["ELEMENT_DSC"]);
			Our_Value = ClsConvert.ToString(dr["OUR_VALUE"]);
			Partner_Value = ClsConvert.ToString(dr["PARTNER_VALUE"]);
			Direction_Ind = ClsConvert.ToString(dr["DIRECTION_IND"]);
			Qualifier_Cd = ClsConvert.ToString(dr["QUALIFIER_CD"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Edi_Translate_ID = ClsConvert.ToInt64Nullable(dr["EDI_TRANSLATE_ID", v]);
			Trading_Partner_Cd = ClsConvert.ToString(dr["TRADING_PARTNER_CD", v]);
			Segment_Cd = ClsConvert.ToString(dr["SEGMENT_CD", v]);
			Element_No = ClsConvert.ToInt64Nullable(dr["ELEMENT_NO", v]);
			Element_Dsc = ClsConvert.ToString(dr["ELEMENT_DSC", v]);
			Our_Value = ClsConvert.ToString(dr["OUR_VALUE", v]);
			Partner_Value = ClsConvert.ToString(dr["PARTNER_VALUE", v]);
			Direction_Ind = ClsConvert.ToString(dr["DIRECTION_IND", v]);
			Qualifier_Cd = ClsConvert.ToString(dr["QUALIFIER_CD", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["EDI_TRANSLATE_ID"] = ClsConvert.ToDbObject(Edi_Translate_ID);
			dr["TRADING_PARTNER_CD"] = ClsConvert.ToDbObject(Trading_Partner_Cd);
			dr["SEGMENT_CD"] = ClsConvert.ToDbObject(Segment_Cd);
			dr["ELEMENT_NO"] = ClsConvert.ToDbObject(Element_No);
			dr["ELEMENT_DSC"] = ClsConvert.ToDbObject(Element_Dsc);
			dr["OUR_VALUE"] = ClsConvert.ToDbObject(Our_Value);
			dr["PARTNER_VALUE"] = ClsConvert.ToDbObject(Partner_Value);
			dr["DIRECTION_IND"] = ClsConvert.ToDbObject(Direction_Ind);
			dr["QUALIFIER_CD"] = ClsConvert.ToDbObject(Qualifier_Cd);
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

		public static ClsEdiTranslate GetUsingKey(Int64 Edi_Translate_ID)
		{
			object[] vals = new object[] {Edi_Translate_ID};
			DataRow dr = Connection.GetDataRowUsingKey
				(TableName, GetPrimaryKeys(), vals);
			return ( dr == null ) ? null : new ClsEdiTranslate(dr);
		}
		public static DataTable GetAll(string Trading_Partner_Cd)
		{
			List<DbParameter> lst = new List<DbParameter>();	
			StringBuilder sb = new StringBuilder();
		
			if( string.IsNullOrEmpty(Trading_Partner_Cd) == false )
			{
				lst.Add(Connection.GetParameter("@TRADING_PARTNER_CD", Trading_Partner_Cd));
				sb.Append(" WHERE R_EDI_TRANSLATE.TRADING_PARTNER_CD=@TRADING_PARTNER_CD");
			}
			sb.Insert(0, SelectSQL);
			return Connection.GetDataTable(sb.ToString(), lst.ToArray());
		}
		#endregion		// #region Static Methods
	}
}