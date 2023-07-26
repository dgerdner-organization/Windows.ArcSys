using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsStenaVehicleType : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ArcSys"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "R_STENA_VEHICLE_TYPE";
		public const int PrimaryKeyCount = 1;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] { "VEHICLE_TYPE_CD" };
		}

		public const string SelectSQL = "SELECT * FROM R_STENA_VEHICLE_TYPE";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Vehicle_Type_CdMax = 10;
		public const int Vehicle_Type_DscMax = 100;
		public const int Create_User_CdMax = 30;
		public const int Modify_User_CdMax = 30;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected string _Vehicle_Type_Cd;
		protected string _Vehicle_Type_Dsc;
		protected string _Create_User_Cd;
		protected DateTime? _Create_Dt;
		protected string _Modify_User_Cd;
		protected DateTime? _Modify_Dt;
		protected decimal? _Width_Nbr;
		protected decimal? _Height_Nbr;
		protected decimal? _Weight_Nbr;
		protected decimal? _Min_Length_Nbr;
		protected decimal? _Max_Length_Nbr;

		#endregion	// #region Column Fields

		#region Column Properties

		public string Vehicle_Type_Cd
		{
			get { return _Vehicle_Type_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Vehicle_Type_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Vehicle_Type_CdMax )
					_Vehicle_Type_Cd = val.Substring(0, (int)Vehicle_Type_CdMax);
				else
					_Vehicle_Type_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Vehicle_Type_Cd");
			}
		}
		public string Vehicle_Type_Dsc
		{
			get { return _Vehicle_Type_Dsc; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Vehicle_Type_Dsc, val, false) == 0 ) return;
		
				if( val != null && val.Length > Vehicle_Type_DscMax )
					_Vehicle_Type_Dsc = val.Substring(0, (int)Vehicle_Type_DscMax);
				else
					_Vehicle_Type_Dsc = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Vehicle_Type_Dsc");
			}
		}
		public string Create_User_Cd
		{
			get { return _Create_User_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Create_User_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Create_User_CdMax )
					_Create_User_Cd = val.Substring(0, (int)Create_User_CdMax);
				else
					_Create_User_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Create_User_Cd");
			}
		}
		public DateTime? Create_Dt
		{
			get { return _Create_Dt; }
			set
			{
				if( _Create_Dt == value ) return;
		
				_Create_Dt = value;
				_IsDirty = true;
				NotifyPropertyChanged("Create_Dt");
			}
		}
		public string Modify_User_Cd
		{
			get { return _Modify_User_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Modify_User_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Modify_User_CdMax )
					_Modify_User_Cd = val.Substring(0, (int)Modify_User_CdMax);
				else
					_Modify_User_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Modify_User_Cd");
			}
		}
		public DateTime? Modify_Dt
		{
			get { return _Modify_Dt; }
			set
			{
				if( _Modify_Dt == value ) return;
		
				_Modify_Dt = value;
				_IsDirty = true;
				NotifyPropertyChanged("Modify_Dt");
			}
		}
		public decimal? Width_Nbr
		{
			get { return _Width_Nbr; }
			set
			{
				if( _Width_Nbr == value ) return;
		
				_Width_Nbr = value;
				_IsDirty = true;
				NotifyPropertyChanged("Width_Nbr");
			}
		}
		public decimal? Height_Nbr
		{
			get { return _Height_Nbr; }
			set
			{
				if( _Height_Nbr == value ) return;
		
				_Height_Nbr = value;
				_IsDirty = true;
				NotifyPropertyChanged("Height_Nbr");
			}
		}
		public decimal? Weight_Nbr
		{
			get { return _Weight_Nbr; }
			set
			{
				if( _Weight_Nbr == value ) return;
		
				_Weight_Nbr = value;
				_IsDirty = true;
				NotifyPropertyChanged("Weight_Nbr");
			}
		}
		public decimal? Min_Length_Nbr
		{
			get { return _Min_Length_Nbr; }
			set
			{
				if( _Min_Length_Nbr == value ) return;
		
				_Min_Length_Nbr = value;
				_IsDirty = true;
				NotifyPropertyChanged("Min_Length_Nbr");
			}
		}
		public decimal? Max_Length_Nbr
		{
			get { return _Max_Length_Nbr; }
			set
			{
				if( _Max_Length_Nbr == value ) return;
		
				_Max_Length_Nbr = value;
				_IsDirty = true;
				NotifyPropertyChanged("Max_Length_Nbr");
			}
		}

		#endregion	// #region Column Properties

		#region Foreign Key Fields



		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties



		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsStenaVehicleType() : base() {}
		public ClsStenaVehicleType(DataRow dr) : base(dr) {}
		public ClsStenaVehicleType(ClsStenaVehicleType src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Vehicle_Type_Cd = null;
			Vehicle_Type_Dsc = null;
			Create_User_Cd = null;
			Create_Dt = null;
			Modify_User_Cd = null;
			Modify_Dt = null;
			Width_Nbr = null;
			Height_Nbr = null;
			Weight_Nbr = null;
			Min_Length_Nbr = null;
			Max_Length_Nbr = null;
		}

		public void CopyFrom(ClsStenaVehicleType src)
		{
			Vehicle_Type_Cd = src._Vehicle_Type_Cd;
			Vehicle_Type_Dsc = src._Vehicle_Type_Dsc;
			Create_User_Cd = src._Create_User_Cd;
			Create_Dt = src._Create_Dt;
			Modify_User_Cd = src._Modify_User_Cd;
			Modify_Dt = src._Modify_Dt;
			Width_Nbr = src._Width_Nbr;
			Height_Nbr = src._Height_Nbr;
			Weight_Nbr = src._Weight_Nbr;
			Min_Length_Nbr = src._Min_Length_Nbr;
			Max_Length_Nbr = src._Max_Length_Nbr;
		}

		public override bool ReloadFromDB()
		{
			ClsStenaVehicleType tmp = ClsStenaVehicleType.GetUsingKey(Vehicle_Type_Cd);
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

			DbParameter[] p = new DbParameter[11];

			p[0] = Connection.GetParameter
				("@VEHICLE_TYPE_CD", Vehicle_Type_Cd);
			p[1] = Connection.GetParameter
				("@VEHICLE_TYPE_DSC", Vehicle_Type_Dsc);
			p[2] = Connection.GetParameter
				("@CREATE_USER_CD", Create_User_Cd);
			p[3] = Connection.GetParameter
				("@MODIFY_USER_CD", Modify_User_Cd);
			p[4] = Connection.GetParameter
				("@WIDTH_NBR", Width_Nbr);
			p[5] = Connection.GetParameter
				("@HEIGHT_NBR", Height_Nbr);
			p[6] = Connection.GetParameter
				("@WEIGHT_NBR", Weight_Nbr);
			p[7] = Connection.GetParameter
				("@MIN_LENGTH_NBR", Min_Length_Nbr);
			p[8] = Connection.GetParameter
				("@MAX_LENGTH_NBR", Max_Length_Nbr);
			p[9] = Connection.GetParameter
				("@CREATE_DT", Create_Dt, ParameterDirection.Output, DbType.DateTime, 0);
			p[10] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.Output, DbType.DateTime, 0);

			const string sql = @"
				INSERT INTO R_STENA_VEHICLE_TYPE
					(VEHICLE_TYPE_CD, VEHICLE_TYPE_DSC, CREATE_USER_CD,
					MODIFY_USER_CD, WIDTH_NBR, HEIGHT_NBR,
					WEIGHT_NBR, MIN_LENGTH_NBR, MAX_LENGTH_NBR)
				VALUES
					(@VEHICLE_TYPE_CD, @VEHICLE_TYPE_DSC, @CREATE_USER_CD,
					@MODIFY_USER_CD, @WIDTH_NBR, @HEIGHT_NBR,
					@WEIGHT_NBR, @MIN_LENGTH_NBR, @MAX_LENGTH_NBR)
				RETURNING
					CREATE_DT, MODIFY_DT
				INTO
					@CREATE_DT, @MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Create_Dt = ClsConvert.ToDateTimeNullable(p[9].Value);
			Modify_Dt = ClsConvert.ToDateTimeNullable(p[10].Value);
			return ret;
		}
		public override int Update()
		{
			DbParameter[] p = new DbParameter[10];

			p[0] = Connection.GetParameter
				("@VEHICLE_TYPE_DSC", Vehicle_Type_Dsc);
			p[1] = Connection.GetParameter
				("@CREATE_USER_CD", Create_User_Cd);
			p[2] = Connection.GetParameter
				("@MODIFY_USER_CD", Modify_User_Cd);
			p[3] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.InputOutput, DbType.DateTime, 0);
			p[4] = Connection.GetParameter
				("@WIDTH_NBR", Width_Nbr);
			p[5] = Connection.GetParameter
				("@HEIGHT_NBR", Height_Nbr);
			p[6] = Connection.GetParameter
				("@WEIGHT_NBR", Weight_Nbr);
			p[7] = Connection.GetParameter
				("@MIN_LENGTH_NBR", Min_Length_Nbr);
			p[8] = Connection.GetParameter
				("@MAX_LENGTH_NBR", Max_Length_Nbr);
			p[9] = Connection.GetParameter
				("@VEHICLE_TYPE_CD", Vehicle_Type_Cd);

			const string sql = @"
				UPDATE R_STENA_VEHICLE_TYPE SET
					VEHICLE_TYPE_DSC = @VEHICLE_TYPE_DSC,
					CREATE_USER_CD = @CREATE_USER_CD,
					MODIFY_USER_CD = @MODIFY_USER_CD,
					MODIFY_DT = @MODIFY_DT,
					WIDTH_NBR = @WIDTH_NBR,
					HEIGHT_NBR = @HEIGHT_NBR,
					WEIGHT_NBR = @WEIGHT_NBR,
					MIN_LENGTH_NBR = @MIN_LENGTH_NBR,
					MAX_LENGTH_NBR = @MAX_LENGTH_NBR
				WHERE
					VEHICLE_TYPE_CD = @VEHICLE_TYPE_CD
				RETURNING
					MODIFY_DT
				INTO
					@MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Modify_Dt = ClsConvert.ToDateTimeNullable(p[3].Value);
			return ret;
		}
		public override int Delete()
		{
			DbParameter[] p = new DbParameter[1];

			p[0] = Connection.GetParameter
				("@VEHICLE_TYPE_CD", Vehicle_Type_Cd);

			const string sql = @"
				DELETE FROM R_STENA_VEHICLE_TYPE WHERE
				VEHICLE_TYPE_CD=@VEHICLE_TYPE_CD";
			return Connection.RunSQL(sql, p);
		}
		#endregion		// #region Insert, Update, Delete

		#region Conversion methods

		public override void LoadFromDataReader(DbDataReader dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataReader: DataReader parameter was null");

			Vehicle_Type_Cd = ClsConvert.ToString(dr["VEHICLE_TYPE_CD"]);
			Vehicle_Type_Dsc = ClsConvert.ToString(dr["VEHICLE_TYPE_DSC"]);
			Create_User_Cd = ClsConvert.ToString(dr["CREATE_USER_CD"]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT"]);
			Modify_User_Cd = ClsConvert.ToString(dr["MODIFY_USER_CD"]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT"]);
			Width_Nbr = ClsConvert.ToDecimalNullable(dr["WIDTH_NBR"]);
			Height_Nbr = ClsConvert.ToDecimalNullable(dr["HEIGHT_NBR"]);
			Weight_Nbr = ClsConvert.ToDecimalNullable(dr["WEIGHT_NBR"]);
			Min_Length_Nbr = ClsConvert.ToDecimalNullable(dr["MIN_LENGTH_NBR"]);
			Max_Length_Nbr = ClsConvert.ToDecimalNullable(dr["MAX_LENGTH_NBR"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Vehicle_Type_Cd = ClsConvert.ToString(dr["VEHICLE_TYPE_CD", v]);
			Vehicle_Type_Dsc = ClsConvert.ToString(dr["VEHICLE_TYPE_DSC", v]);
			Create_User_Cd = ClsConvert.ToString(dr["CREATE_USER_CD", v]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT", v]);
			Modify_User_Cd = ClsConvert.ToString(dr["MODIFY_USER_CD", v]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT", v]);
			Width_Nbr = ClsConvert.ToDecimalNullable(dr["WIDTH_NBR", v]);
			Height_Nbr = ClsConvert.ToDecimalNullable(dr["HEIGHT_NBR", v]);
			Weight_Nbr = ClsConvert.ToDecimalNullable(dr["WEIGHT_NBR", v]);
			Min_Length_Nbr = ClsConvert.ToDecimalNullable(dr["MIN_LENGTH_NBR", v]);
			Max_Length_Nbr = ClsConvert.ToDecimalNullable(dr["MAX_LENGTH_NBR", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["VEHICLE_TYPE_CD"] = ClsConvert.ToDbObject(Vehicle_Type_Cd);
			dr["VEHICLE_TYPE_DSC"] = ClsConvert.ToDbObject(Vehicle_Type_Dsc);
			dr["CREATE_USER_CD"] = ClsConvert.ToDbObject(Create_User_Cd);
			dr["CREATE_DT"] = ClsConvert.ToDbObject(Create_Dt);
			dr["MODIFY_USER_CD"] = ClsConvert.ToDbObject(Modify_User_Cd);
			dr["MODIFY_DT"] = ClsConvert.ToDbObject(Modify_Dt);
			dr["WIDTH_NBR"] = ClsConvert.ToDbObject(Width_Nbr);
			dr["HEIGHT_NBR"] = ClsConvert.ToDbObject(Height_Nbr);
			dr["WEIGHT_NBR"] = ClsConvert.ToDbObject(Weight_Nbr);
			dr["MIN_LENGTH_NBR"] = ClsConvert.ToDbObject(Min_Length_Nbr);
			dr["MAX_LENGTH_NBR"] = ClsConvert.ToDbObject(Max_Length_Nbr);
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

		public static ClsStenaVehicleType GetUsingKey(string Vehicle_Type_Cd)
		{
			object[] vals = new object[] {Vehicle_Type_Cd};
			DataRow dr = Connection.GetDataRowUsingKey
				(TableName, GetPrimaryKeys(), vals);
			return ( dr == null ) ? null : new ClsStenaVehicleType(dr);
		}

		#endregion		// #region Static Methods
	}
}