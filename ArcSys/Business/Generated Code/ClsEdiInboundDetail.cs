using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsEdiInboundDetail : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ArcSys"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "T_EDI_INBOUND_DETAIL";
		public const int PrimaryKeyCount = 1;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] { "EDI_INBOUND_DETAIL_ID" };
		}

		public const string SelectSQL = "SELECT * FROM T_EDI_INBOUND_DETAIL";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Create_UserMax = 30;
		public const int Modify_UserMax = 30;
		public const int Booking_NoMax = 20;
		public const int Vehicle_Type_CdMax = 10;
		public const int MakeMax = 30;
		public const int ModelMax = 30;
		public const int VinMax = 30;
		public const int Customer_Order_NoMax = 20;
		public const int Processed_FlgMax = 1;
		public const int Process_MsgMax = 200;
		public const int Source_FileMax = 200;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected Int64? _Edi_Inbound_Detail_ID;
		protected string _Create_User;
		protected DateTime? _Create_Dt;
		protected string _Modify_User;
		protected DateTime? _Modify_Dt;
		protected string _Booking_No;
		protected string _Vehicle_Type_Cd;
		protected decimal? _Length_Nbr;
		protected decimal? _Width_Nbr;
		protected decimal? _Height_Nbr;
		protected decimal? _Weight_Nbr;
		protected Int16? _Vehicle_Year;
		protected string _Make;
		protected string _Model;
		protected string _Vin;
		protected string _Customer_Order_No;
		protected string _Processed_Flg;
		protected string _Process_Msg;
		protected string _Source_File;

		#endregion	// #region Column Fields

		#region Column Properties

		public Int64? Edi_Inbound_Detail_ID
		{
			get { return _Edi_Inbound_Detail_ID; }
			set
			{
				if( _Edi_Inbound_Detail_ID == value ) return;
		
				_Edi_Inbound_Detail_ID = value;
				_IsDirty = true;
				NotifyPropertyChanged("Edi_Inbound_Detail_ID");
			}
		}
		public string Create_User
		{
			get { return _Create_User; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Create_User, val, false) == 0 ) return;
		
				if( val != null && val.Length > Create_UserMax )
					_Create_User = val.Substring(0, (int)Create_UserMax);
				else
					_Create_User = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Create_User");
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
		public string Modify_User
		{
			get { return _Modify_User; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Modify_User, val, false) == 0 ) return;
		
				if( val != null && val.Length > Modify_UserMax )
					_Modify_User = val.Substring(0, (int)Modify_UserMax);
				else
					_Modify_User = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Modify_User");
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
		public decimal? Length_Nbr
		{
			get { return _Length_Nbr; }
			set
			{
				if( _Length_Nbr == value ) return;
		
				_Length_Nbr = value;
				_IsDirty = true;
				NotifyPropertyChanged("Length_Nbr");
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
		public Int16? Vehicle_Year
		{
			get { return _Vehicle_Year; }
			set
			{
				if( _Vehicle_Year == value ) return;
		
				_Vehicle_Year = value;
				_IsDirty = true;
				NotifyPropertyChanged("Vehicle_Year");
			}
		}
		public string Make
		{
			get { return _Make; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Make, val, false) == 0 ) return;
		
				if( val != null && val.Length > MakeMax )
					_Make = val.Substring(0, (int)MakeMax);
				else
					_Make = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Make");
			}
		}
		public string Model
		{
			get { return _Model; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Model, val, false) == 0 ) return;
		
				if( val != null && val.Length > ModelMax )
					_Model = val.Substring(0, (int)ModelMax);
				else
					_Model = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Model");
			}
		}
		public string Vin
		{
			get { return _Vin; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Vin, val, false) == 0 ) return;
		
				if( val != null && val.Length > VinMax )
					_Vin = val.Substring(0, (int)VinMax);
				else
					_Vin = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Vin");
			}
		}
		public string Customer_Order_No
		{
			get { return _Customer_Order_No; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Customer_Order_No, val, false) == 0 ) return;
		
				if( val != null && val.Length > Customer_Order_NoMax )
					_Customer_Order_No = val.Substring(0, (int)Customer_Order_NoMax);
				else
					_Customer_Order_No = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Customer_Order_No");
			}
		}
		public string Processed_Flg
		{
			get { return _Processed_Flg; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Processed_Flg, val, false) == 0 ) return;
		
				if( val != null && val.Length > Processed_FlgMax )
					_Processed_Flg = val.Substring(0, (int)Processed_FlgMax);
				else
					_Processed_Flg = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Processed_Flg");
			}
		}
		public string Process_Msg
		{
			get { return _Process_Msg; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Process_Msg, val, false) == 0 ) return;
		
				if( val != null && val.Length > Process_MsgMax )
					_Process_Msg = val.Substring(0, (int)Process_MsgMax);
				else
					_Process_Msg = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Process_Msg");
			}
		}
		public string Source_File
		{
			get { return _Source_File; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Source_File, val, false) == 0 ) return;
		
				if( val != null && val.Length > Source_FileMax )
					_Source_File = val.Substring(0, (int)Source_FileMax);
				else
					_Source_File = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Source_File");
			}
		}

		#endregion	// #region Column Properties

		#region Foreign Key Fields



		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties



		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsEdiInboundDetail() : base() {}
		public ClsEdiInboundDetail(DataRow dr) : base(dr) {}
		public ClsEdiInboundDetail(ClsEdiInboundDetail src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Edi_Inbound_Detail_ID = null;
			Create_User = null;
			Create_Dt = null;
			Modify_User = null;
			Modify_Dt = null;
			Booking_No = null;
			Vehicle_Type_Cd = null;
			Length_Nbr = null;
			Width_Nbr = null;
			Height_Nbr = null;
			Weight_Nbr = null;
			Vehicle_Year = null;
			Make = null;
			Model = null;
			Vin = null;
			Customer_Order_No = null;
			Processed_Flg = null;
			Process_Msg = null;
			Source_File = null;
		}

		public void CopyFrom(ClsEdiInboundDetail src)
		{
			Edi_Inbound_Detail_ID = src._Edi_Inbound_Detail_ID;
			Create_User = src._Create_User;
			Create_Dt = src._Create_Dt;
			Modify_User = src._Modify_User;
			Modify_Dt = src._Modify_Dt;
			Booking_No = src._Booking_No;
			Vehicle_Type_Cd = src._Vehicle_Type_Cd;
			Length_Nbr = src._Length_Nbr;
			Width_Nbr = src._Width_Nbr;
			Height_Nbr = src._Height_Nbr;
			Weight_Nbr = src._Weight_Nbr;
			Vehicle_Year = src._Vehicle_Year;
			Make = src._Make;
			Model = src._Model;
			Vin = src._Vin;
			Customer_Order_No = src._Customer_Order_No;
			Processed_Flg = src._Processed_Flg;
			Process_Msg = src._Process_Msg;
			Source_File = src._Source_File;
		}

		public override bool ReloadFromDB()
		{
			ClsEdiInboundDetail tmp = ClsEdiInboundDetail.GetUsingKey(Edi_Inbound_Detail_ID.Value);
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

			DbParameter[] p = new DbParameter[19];

			p[0] = Connection.GetParameter
				("@BOOKING_NO", Booking_No);
			p[1] = Connection.GetParameter
				("@VEHICLE_TYPE_CD", Vehicle_Type_Cd);
			p[2] = Connection.GetParameter
				("@LENGTH_NBR", Length_Nbr);
			p[3] = Connection.GetParameter
				("@WIDTH_NBR", Width_Nbr);
			p[4] = Connection.GetParameter
				("@HEIGHT_NBR", Height_Nbr);
			p[5] = Connection.GetParameter
				("@WEIGHT_NBR", Weight_Nbr);
			p[6] = Connection.GetParameter
				("@VEHICLE_YEAR", Vehicle_Year);
			p[7] = Connection.GetParameter
				("@MAKE", Make);
			p[8] = Connection.GetParameter
				("@MODEL", Model);
			p[9] = Connection.GetParameter
				("@VIN", Vin);
			p[10] = Connection.GetParameter
				("@CUSTOMER_ORDER_NO", Customer_Order_No);
			p[11] = Connection.GetParameter
				("@PROCESSED_FLG", Processed_Flg);
			p[12] = Connection.GetParameter
				("@PROCESS_MSG", Process_Msg);
			p[13] = Connection.GetParameter
				("@SOURCE_FILE", Source_File);
			p[14] = Connection.GetParameter
				("@EDI_INBOUND_DETAIL_ID", Edi_Inbound_Detail_ID, ParameterDirection.Output, DbType.Int64, 0);
			p[15] = Connection.GetParameter
				("@CREATE_USER", Create_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Create_UserMax);
			p[16] = Connection.GetParameter
				("@CREATE_DT", Create_Dt, ParameterDirection.Output, DbType.DateTime, 0);
			p[17] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);
			p[18] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.Output, DbType.DateTime, 0);

			const string sql = @"
				INSERT INTO T_EDI_INBOUND_DETAIL
					(EDI_INBOUND_DETAIL_ID, BOOKING_NO, VEHICLE_TYPE_CD,
					LENGTH_NBR, WIDTH_NBR, HEIGHT_NBR,
					WEIGHT_NBR, VEHICLE_YEAR, MAKE,
					MODEL, VIN, CUSTOMER_ORDER_NO,
					PROCESSED_FLG, PROCESS_MSG, SOURCE_FILE)
				VALUES
					(EDI_INBOUND_DETAIL_ID_SEQ.NEXTVAL, @BOOKING_NO, @VEHICLE_TYPE_CD,
					@LENGTH_NBR, @WIDTH_NBR, @HEIGHT_NBR,
					@WEIGHT_NBR, @VEHICLE_YEAR, @MAKE,
					@MODEL, @VIN, @CUSTOMER_ORDER_NO,
					@PROCESSED_FLG, @PROCESS_MSG, @SOURCE_FILE)
				RETURNING
					EDI_INBOUND_DETAIL_ID, CREATE_USER, CREATE_DT,
					MODIFY_USER, MODIFY_DT
				INTO
					@EDI_INBOUND_DETAIL_ID, @CREATE_USER, @CREATE_DT,
					@MODIFY_USER, @MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Edi_Inbound_Detail_ID = ClsConvert.ToInt64Nullable(p[14].Value);
			Create_User = ClsConvert.ToString(p[15].Value);
			Create_Dt = ClsConvert.ToDateTimeNullable(p[16].Value);
			Modify_User = ClsConvert.ToString(p[17].Value);
			Modify_Dt = ClsConvert.ToDateTimeNullable(p[18].Value);
			return ret;
		}
		public override int Update()
		{
			DbParameter[] p = new DbParameter[17];

			p[0] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.InputOutput, DbType.DateTime, 0);
			p[1] = Connection.GetParameter
				("@BOOKING_NO", Booking_No);
			p[2] = Connection.GetParameter
				("@VEHICLE_TYPE_CD", Vehicle_Type_Cd);
			p[3] = Connection.GetParameter
				("@LENGTH_NBR", Length_Nbr);
			p[4] = Connection.GetParameter
				("@WIDTH_NBR", Width_Nbr);
			p[5] = Connection.GetParameter
				("@HEIGHT_NBR", Height_Nbr);
			p[6] = Connection.GetParameter
				("@WEIGHT_NBR", Weight_Nbr);
			p[7] = Connection.GetParameter
				("@VEHICLE_YEAR", Vehicle_Year);
			p[8] = Connection.GetParameter
				("@MAKE", Make);
			p[9] = Connection.GetParameter
				("@MODEL", Model);
			p[10] = Connection.GetParameter
				("@VIN", Vin);
			p[11] = Connection.GetParameter
				("@CUSTOMER_ORDER_NO", Customer_Order_No);
			p[12] = Connection.GetParameter
				("@PROCESSED_FLG", Processed_Flg);
			p[13] = Connection.GetParameter
				("@PROCESS_MSG", Process_Msg);
			p[14] = Connection.GetParameter
				("@SOURCE_FILE", Source_File);
			p[15] = Connection.GetParameter
				("@EDI_INBOUND_DETAIL_ID", Edi_Inbound_Detail_ID);
			p[16] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);

			const string sql = @"
				UPDATE T_EDI_INBOUND_DETAIL SET
					MODIFY_DT = @MODIFY_DT,
					BOOKING_NO = @BOOKING_NO,
					VEHICLE_TYPE_CD = @VEHICLE_TYPE_CD,
					LENGTH_NBR = @LENGTH_NBR,
					WIDTH_NBR = @WIDTH_NBR,
					HEIGHT_NBR = @HEIGHT_NBR,
					WEIGHT_NBR = @WEIGHT_NBR,
					VEHICLE_YEAR = @VEHICLE_YEAR,
					MAKE = @MAKE,
					MODEL = @MODEL,
					VIN = @VIN,
					CUSTOMER_ORDER_NO = @CUSTOMER_ORDER_NO,
					PROCESSED_FLG = @PROCESSED_FLG,
					PROCESS_MSG = @PROCESS_MSG,
					SOURCE_FILE = @SOURCE_FILE
				WHERE
					EDI_INBOUND_DETAIL_ID = @EDI_INBOUND_DETAIL_ID
				RETURNING
					MODIFY_USER, MODIFY_DT
				INTO
					@MODIFY_USER, @MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Modify_Dt = ClsConvert.ToDateTimeNullable(p[0].Value);
			Modify_User = ClsConvert.ToString(p[16].Value);
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

			Edi_Inbound_Detail_ID = ClsConvert.ToInt64Nullable(dr["EDI_INBOUND_DETAIL_ID"]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER"]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT"]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER"]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT"]);
			Booking_No = ClsConvert.ToString(dr["BOOKING_NO"]);
			Vehicle_Type_Cd = ClsConvert.ToString(dr["VEHICLE_TYPE_CD"]);
			Length_Nbr = ClsConvert.ToDecimalNullable(dr["LENGTH_NBR"]);
			Width_Nbr = ClsConvert.ToDecimalNullable(dr["WIDTH_NBR"]);
			Height_Nbr = ClsConvert.ToDecimalNullable(dr["HEIGHT_NBR"]);
			Weight_Nbr = ClsConvert.ToDecimalNullable(dr["WEIGHT_NBR"]);
			Vehicle_Year = ClsConvert.ToInt16Nullable(dr["VEHICLE_YEAR"]);
			Make = ClsConvert.ToString(dr["MAKE"]);
			Model = ClsConvert.ToString(dr["MODEL"]);
			Vin = ClsConvert.ToString(dr["VIN"]);
			Customer_Order_No = ClsConvert.ToString(dr["CUSTOMER_ORDER_NO"]);
			Processed_Flg = ClsConvert.ToString(dr["PROCESSED_FLG"]);
			Process_Msg = ClsConvert.ToString(dr["PROCESS_MSG"]);
			Source_File = ClsConvert.ToString(dr["SOURCE_FILE"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Edi_Inbound_Detail_ID = ClsConvert.ToInt64Nullable(dr["EDI_INBOUND_DETAIL_ID", v]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER", v]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT", v]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER", v]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT", v]);
			Booking_No = ClsConvert.ToString(dr["BOOKING_NO", v]);
			Vehicle_Type_Cd = ClsConvert.ToString(dr["VEHICLE_TYPE_CD", v]);
			Length_Nbr = ClsConvert.ToDecimalNullable(dr["LENGTH_NBR", v]);
			Width_Nbr = ClsConvert.ToDecimalNullable(dr["WIDTH_NBR", v]);
			Height_Nbr = ClsConvert.ToDecimalNullable(dr["HEIGHT_NBR", v]);
			Weight_Nbr = ClsConvert.ToDecimalNullable(dr["WEIGHT_NBR", v]);
			Vehicle_Year = ClsConvert.ToInt16Nullable(dr["VEHICLE_YEAR", v]);
			Make = ClsConvert.ToString(dr["MAKE", v]);
			Model = ClsConvert.ToString(dr["MODEL", v]);
			Vin = ClsConvert.ToString(dr["VIN", v]);
			Customer_Order_No = ClsConvert.ToString(dr["CUSTOMER_ORDER_NO", v]);
			Processed_Flg = ClsConvert.ToString(dr["PROCESSED_FLG", v]);
			Process_Msg = ClsConvert.ToString(dr["PROCESS_MSG", v]);
			Source_File = ClsConvert.ToString(dr["SOURCE_FILE", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["EDI_INBOUND_DETAIL_ID"] = ClsConvert.ToDbObject(Edi_Inbound_Detail_ID);
			dr["CREATE_USER"] = ClsConvert.ToDbObject(Create_User);
			dr["CREATE_DT"] = ClsConvert.ToDbObject(Create_Dt);
			dr["MODIFY_USER"] = ClsConvert.ToDbObject(Modify_User);
			dr["MODIFY_DT"] = ClsConvert.ToDbObject(Modify_Dt);
			dr["BOOKING_NO"] = ClsConvert.ToDbObject(Booking_No);
			dr["VEHICLE_TYPE_CD"] = ClsConvert.ToDbObject(Vehicle_Type_Cd);
			dr["LENGTH_NBR"] = ClsConvert.ToDbObject(Length_Nbr);
			dr["WIDTH_NBR"] = ClsConvert.ToDbObject(Width_Nbr);
			dr["HEIGHT_NBR"] = ClsConvert.ToDbObject(Height_Nbr);
			dr["WEIGHT_NBR"] = ClsConvert.ToDbObject(Weight_Nbr);
			dr["VEHICLE_YEAR"] = ClsConvert.ToDbObject(Vehicle_Year);
			dr["MAKE"] = ClsConvert.ToDbObject(Make);
			dr["MODEL"] = ClsConvert.ToDbObject(Model);
			dr["VIN"] = ClsConvert.ToDbObject(Vin);
			dr["CUSTOMER_ORDER_NO"] = ClsConvert.ToDbObject(Customer_Order_No);
			dr["PROCESSED_FLG"] = ClsConvert.ToDbObject(Processed_Flg);
			dr["PROCESS_MSG"] = ClsConvert.ToDbObject(Process_Msg);
			dr["SOURCE_FILE"] = ClsConvert.ToDbObject(Source_File);
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

		public static ClsEdiInboundDetail GetUsingKey(Int64 Edi_Inbound_Detail_ID)
		{
			object[] vals = new object[] {Edi_Inbound_Detail_ID};
			DataRow dr = Connection.GetDataRowUsingKey
				(TableName, GetPrimaryKeys(), vals);
			return ( dr == null ) ? null : new ClsEdiInboundDetail(dr);
		}

		#endregion		// #region Static Methods
	}
}