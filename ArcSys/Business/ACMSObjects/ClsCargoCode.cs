using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ACMS.Business
{
	public partial class ClsCargoCode : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ACMS"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "R_CARGO_CODE";
		public const int PrimaryKeyCount = 1;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] { "CARGO_ID" };
		}

		public const string SelectSQL = "SELECT * FROM R_CARGO_CODE";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Delete_FlgMax = 1;
		public const int Cargo_DscMax = 25;
		public const int Cargo_CodeMax = 10;
		public const int Make_CodeMax = 20;
		public const int Model_CodeMax = 50;
		public const int Cargo_TypeMax = 15;
		public const int External_Cargo_TypeMax = 10;
		public const int Stena_Vehicle_Type_CdMax = 10;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected decimal? _Cargo_ID;
		protected string _Delete_Flg;
		protected string _Cargo_Dsc;
		protected string _Cargo_Code;
		protected string _Make_Code;
		protected string _Model_Code;
		protected decimal? _Length;
		protected decimal? _Width;
		protected decimal? _Height;
		protected decimal? _Weight;
		protected decimal? _Cargo_Year;
		protected string _Cargo_Type;
		protected string _External_Cargo_Type;
		protected string _Stena_Vehicle_Type_Cd;

		#endregion	// #region Column Fields

		#region Column Properties

		public decimal? Cargo_ID
		{
			get { return _Cargo_ID; }
			set
			{
				if( _Cargo_ID == value ) return;
		
				_Cargo_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Cargo_ID");
			}
		}
		public string Delete_Flg
		{
			get { return _Delete_Flg; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Delete_Flg, val, false) == 0 ) return;
		
				if( val != null && val.Length > Delete_FlgMax )
					_Delete_Flg = val.Substring(0, (int)Delete_FlgMax);
				else
					_Delete_Flg = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Delete_Flg");
			}
		}
		public string Cargo_Dsc
		{
			get { return _Cargo_Dsc; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Cargo_Dsc, val, false) == 0 ) return;
		
				if( val != null && val.Length > Cargo_DscMax )
					_Cargo_Dsc = val.Substring(0, (int)Cargo_DscMax);
				else
					_Cargo_Dsc = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Cargo_Dsc");
			}
		}
		public string Cargo_Code
		{
			get { return _Cargo_Code; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Cargo_Code, val, false) == 0 ) return;
		
				if( val != null && val.Length > Cargo_CodeMax )
					_Cargo_Code = val.Substring(0, (int)Cargo_CodeMax);
				else
					_Cargo_Code = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Cargo_Code");
			}
		}
		public string Make_Code
		{
			get { return _Make_Code; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Make_Code, val, false) == 0 ) return;
		
				if( val != null && val.Length > Make_CodeMax )
					_Make_Code = val.Substring(0, (int)Make_CodeMax);
				else
					_Make_Code = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Make_Code");
			}
		}
		public string Model_Code
		{
			get { return _Model_Code; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Model_Code, val, false) == 0 ) return;
		
				if( val != null && val.Length > Model_CodeMax )
					_Model_Code = val.Substring(0, (int)Model_CodeMax);
				else
					_Model_Code = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Model_Code");
			}
		}
		public decimal? Length
		{
			get { return _Length; }
			set
			{
				if( _Length == value ) return;
		
				_Length = value;
				_IsDirty = true;
				NotifyPropertyChanged("Length");
			}
		}
		public decimal? Width
		{
			get { return _Width; }
			set
			{
				if( _Width == value ) return;
		
				_Width = value;
				_IsDirty = true;
				NotifyPropertyChanged("Width");
			}
		}
		public decimal? Height
		{
			get { return _Height; }
			set
			{
				if( _Height == value ) return;
		
				_Height = value;
				_IsDirty = true;
				NotifyPropertyChanged("Height");
			}
		}
		public decimal? Weight
		{
			get { return _Weight; }
			set
			{
				if( _Weight == value ) return;
		
				_Weight = value;
				_IsDirty = true;
				NotifyPropertyChanged("Weight");
			}
		}
		public decimal? Cargo_Year
		{
			get { return _Cargo_Year; }
			set
			{
				if( _Cargo_Year == value ) return;
		
				_Cargo_Year = value;
				_IsDirty = true;
				NotifyPropertyChanged("Cargo_Year");
			}
		}
		public string Cargo_Type
		{
			get { return _Cargo_Type; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Cargo_Type, val, false) == 0 ) return;
		
				if( val != null && val.Length > Cargo_TypeMax )
					_Cargo_Type = val.Substring(0, (int)Cargo_TypeMax);
				else
					_Cargo_Type = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Cargo_Type");
			}
		}
		public string External_Cargo_Type
		{
			get { return _External_Cargo_Type; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_External_Cargo_Type, val, false) == 0 ) return;
		
				if( val != null && val.Length > External_Cargo_TypeMax )
					_External_Cargo_Type = val.Substring(0, (int)External_Cargo_TypeMax);
				else
					_External_Cargo_Type = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("External_Cargo_Type");
			}
		}
		public string Stena_Vehicle_Type_Cd
		{
			get { return _Stena_Vehicle_Type_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Stena_Vehicle_Type_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Stena_Vehicle_Type_CdMax )
					_Stena_Vehicle_Type_Cd = val.Substring(0, (int)Stena_Vehicle_Type_CdMax);
				else
					_Stena_Vehicle_Type_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Stena_Vehicle_Type_Cd");
			}
		}

		#endregion	// #region Column Properties

		#region Foreign Key Fields



		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties



		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsCargoCode() : base() {}
		public ClsCargoCode(DataRow dr) : base(dr) {}
		public ClsCargoCode(ClsCargoCode src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Cargo_ID = null;
			Delete_Flg = null;
			Cargo_Dsc = null;
			Cargo_Code = null;
			Make_Code = null;
			Model_Code = null;
			Length = null;
			Width = null;
			Height = null;
			Weight = null;
			Cargo_Year = null;
			Cargo_Type = null;
			External_Cargo_Type = null;
			Stena_Vehicle_Type_Cd = null;
		}

		public void CopyFrom(ClsCargoCode src)
		{
			Cargo_ID = src._Cargo_ID;
			Delete_Flg = src._Delete_Flg;
			Cargo_Dsc = src._Cargo_Dsc;
			Cargo_Code = src._Cargo_Code;
			Make_Code = src._Make_Code;
			Model_Code = src._Model_Code;
			Length = src._Length;
			Width = src._Width;
			Height = src._Height;
			Weight = src._Weight;
			Cargo_Year = src._Cargo_Year;
			Cargo_Type = src._Cargo_Type;
			External_Cargo_Type = src._External_Cargo_Type;
			Stena_Vehicle_Type_Cd = src._Stena_Vehicle_Type_Cd;
		}

		public override bool ReloadFromDB()
		{
			ClsCargoCode tmp = ClsCargoCode.GetUsingKey(Cargo_ID.Value);
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

			DbParameter[] p = new DbParameter[14];

			p[0] = Connection.GetParameter
				("@CARGO_ID", Cargo_ID);
			p[1] = Connection.GetParameter
				("@DELETE_FLG", Delete_Flg);
			p[2] = Connection.GetParameter
				("@CARGO_DSC", Cargo_Dsc);
			p[3] = Connection.GetParameter
				("@CARGO_CODE", Cargo_Code);
			p[4] = Connection.GetParameter
				("@MAKE_CODE", Make_Code);
			p[5] = Connection.GetParameter
				("@MODEL_CODE", Model_Code);
			p[6] = Connection.GetParameter
				("@LENGTH", Length);
			p[7] = Connection.GetParameter
				("@WIDTH", Width);
			p[8] = Connection.GetParameter
				("@HEIGHT", Height);
			p[9] = Connection.GetParameter
				("@WEIGHT", Weight);
			p[10] = Connection.GetParameter
				("@CARGO_YEAR", Cargo_Year);
			p[11] = Connection.GetParameter
				("@CARGO_TYPE", Cargo_Type);
			p[12] = Connection.GetParameter
				("@EXTERNAL_CARGO_TYPE", External_Cargo_Type);
			p[13] = Connection.GetParameter
				("@STENA_VEHICLE_TYPE_CD", Stena_Vehicle_Type_Cd);

			const string sql = @"
				INSERT INTO R_CARGO_CODE
					(CARGO_ID, DELETE_FLG, CARGO_DSC,
					CARGO_CODE, MAKE_CODE, MODEL_CODE,
					LENGTH, WIDTH, HEIGHT,
					WEIGHT, CARGO_YEAR, CARGO_TYPE,
					EXTERNAL_CARGO_TYPE, STENA_VEHICLE_TYPE_CD)
				VALUES
					(@CARGO_ID, @DELETE_FLG, @CARGO_DSC,
					@CARGO_CODE, @MAKE_CODE, @MODEL_CODE,
					@LENGTH, @WIDTH, @HEIGHT,
					@WEIGHT, @CARGO_YEAR, @CARGO_TYPE,
					@EXTERNAL_CARGO_TYPE, @STENA_VEHICLE_TYPE_CD)

					";
			int ret = Connection.RunSQL(sql, p);


			return ret;
		}
		public override int Update()
		{
			DbParameter[] p = new DbParameter[14];

			p[0] = Connection.GetParameter
				("@DELETE_FLG", Delete_Flg);
			p[1] = Connection.GetParameter
				("@CARGO_DSC", Cargo_Dsc);
			p[2] = Connection.GetParameter
				("@CARGO_CODE", Cargo_Code);
			p[3] = Connection.GetParameter
				("@MAKE_CODE", Make_Code);
			p[4] = Connection.GetParameter
				("@MODEL_CODE", Model_Code);
			p[5] = Connection.GetParameter
				("@LENGTH", Length);
			p[6] = Connection.GetParameter
				("@WIDTH", Width);
			p[7] = Connection.GetParameter
				("@HEIGHT", Height);
			p[8] = Connection.GetParameter
				("@WEIGHT", Weight);
			p[9] = Connection.GetParameter
				("@CARGO_YEAR", Cargo_Year);
			p[10] = Connection.GetParameter
				("@CARGO_TYPE", Cargo_Type);
			p[11] = Connection.GetParameter
				("@EXTERNAL_CARGO_TYPE", External_Cargo_Type);
			p[12] = Connection.GetParameter
				("@STENA_VEHICLE_TYPE_CD", Stena_Vehicle_Type_Cd);
			p[13] = Connection.GetParameter
				("@CARGO_ID", Cargo_ID);

			const string sql = @"
				UPDATE R_CARGO_CODE SET
					DELETE_FLG = @DELETE_FLG,
					CARGO_DSC = @CARGO_DSC,
					CARGO_CODE = @CARGO_CODE,
					MAKE_CODE = @MAKE_CODE,
					MODEL_CODE = @MODEL_CODE,
					LENGTH = @LENGTH,
					WIDTH = @WIDTH,
					HEIGHT = @HEIGHT,
					WEIGHT = @WEIGHT,
					CARGO_YEAR = @CARGO_YEAR,
					CARGO_TYPE = @CARGO_TYPE,
					EXTERNAL_CARGO_TYPE = @EXTERNAL_CARGO_TYPE,
					STENA_VEHICLE_TYPE_CD = @STENA_VEHICLE_TYPE_CD
				WHERE
					CARGO_ID = @CARGO_ID

					";
			int ret = Connection.RunSQL(sql, p);


			return ret;
		}
		public override int Delete()
		{
			DbParameter[] p = new DbParameter[1];

			p[0] = Connection.GetParameter
				("@CARGO_ID", Cargo_ID);

			const string sql = @"
				DELETE FROM R_CARGO_CODE WHERE
				CARGO_ID=@CARGO_ID";
			return Connection.RunSQL(sql, p);
		}
		#endregion		// #region Insert, Update, Delete

		#region Conversion methods

		public override void LoadFromDataReader(DbDataReader dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataReader: DataReader parameter was null");

			Cargo_ID = ClsConvert.ToDecimalNullable(dr["CARGO_ID"]);
			Delete_Flg = ClsConvert.ToString(dr["DELETE_FLG"]);
			Cargo_Dsc = ClsConvert.ToString(dr["CARGO_DSC"]);
			Cargo_Code = ClsConvert.ToString(dr["CARGO_CODE"]);
			Make_Code = ClsConvert.ToString(dr["MAKE_CODE"]);
			Model_Code = ClsConvert.ToString(dr["MODEL_CODE"]);
			Length = ClsConvert.ToDecimalNullable(dr["LENGTH"]);
			Width = ClsConvert.ToDecimalNullable(dr["WIDTH"]);
			Height = ClsConvert.ToDecimalNullable(dr["HEIGHT"]);
			Weight = ClsConvert.ToDecimalNullable(dr["WEIGHT"]);
			Cargo_Year = ClsConvert.ToDecimalNullable(dr["CARGO_YEAR"]);
			Cargo_Type = ClsConvert.ToString(dr["CARGO_TYPE"]);
			External_Cargo_Type = ClsConvert.ToString(dr["EXTERNAL_CARGO_TYPE"]);
			Stena_Vehicle_Type_Cd = ClsConvert.ToString(dr["STENA_VEHICLE_TYPE_CD"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Cargo_ID = ClsConvert.ToDecimalNullable(dr["CARGO_ID", v]);
			Delete_Flg = ClsConvert.ToString(dr["DELETE_FLG", v]);
			Cargo_Dsc = ClsConvert.ToString(dr["CARGO_DSC", v]);
			Cargo_Code = ClsConvert.ToString(dr["CARGO_CODE", v]);
			Make_Code = ClsConvert.ToString(dr["MAKE_CODE", v]);
			Model_Code = ClsConvert.ToString(dr["MODEL_CODE", v]);
			Length = ClsConvert.ToDecimalNullable(dr["LENGTH", v]);
			Width = ClsConvert.ToDecimalNullable(dr["WIDTH", v]);
			Height = ClsConvert.ToDecimalNullable(dr["HEIGHT", v]);
			Weight = ClsConvert.ToDecimalNullable(dr["WEIGHT", v]);
			Cargo_Year = ClsConvert.ToDecimalNullable(dr["CARGO_YEAR", v]);
			Cargo_Type = ClsConvert.ToString(dr["CARGO_TYPE", v]);
			External_Cargo_Type = ClsConvert.ToString(dr["EXTERNAL_CARGO_TYPE", v]);
			Stena_Vehicle_Type_Cd = ClsConvert.ToString(dr["STENA_VEHICLE_TYPE_CD", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["CARGO_ID"] = ClsConvert.ToDbObject(Cargo_ID);
			dr["DELETE_FLG"] = ClsConvert.ToDbObject(Delete_Flg);
			dr["CARGO_DSC"] = ClsConvert.ToDbObject(Cargo_Dsc);
			dr["CARGO_CODE"] = ClsConvert.ToDbObject(Cargo_Code);
			dr["MAKE_CODE"] = ClsConvert.ToDbObject(Make_Code);
			dr["MODEL_CODE"] = ClsConvert.ToDbObject(Model_Code);
			dr["LENGTH"] = ClsConvert.ToDbObject(Length);
			dr["WIDTH"] = ClsConvert.ToDbObject(Width);
			dr["HEIGHT"] = ClsConvert.ToDbObject(Height);
			dr["WEIGHT"] = ClsConvert.ToDbObject(Weight);
			dr["CARGO_YEAR"] = ClsConvert.ToDbObject(Cargo_Year);
			dr["CARGO_TYPE"] = ClsConvert.ToDbObject(Cargo_Type);
			dr["EXTERNAL_CARGO_TYPE"] = ClsConvert.ToDbObject(External_Cargo_Type);
			dr["STENA_VEHICLE_TYPE_CD"] = ClsConvert.ToDbObject(Stena_Vehicle_Type_Cd);
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

		public static ClsCargoCode GetUsingKey(decimal Cargo_ID)
		{
			object[] vals = new object[] {Cargo_ID};
			DataRow dr = Connection.GetDataRowUsingKey
				(TableName, GetPrimaryKeys(), vals);
			return ( dr == null ) ? null : new ClsCargoCode(dr);
		}

		#endregion		// #region Static Methods
	}
}