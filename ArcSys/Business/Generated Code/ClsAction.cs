using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsAction : ClsBaseTable
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ArcSys"]; }
		}
		#endregion		// #region Connection Manager

		#region Table Constants

		public const string TableName = "R_ACTION";
		public const int PrimaryKeyCount = 1;
		public static bool HasPrimaryKey
		{
			get { return PrimaryKeyCount > 0; }
		}
		public static string[] GetPrimaryKeys()
		{
			return new string[PrimaryKeyCount] { "ACTION_CD" };
		}

		public const string SelectSQL = "SELECT * FROM R_ACTION";

		#endregion	// #region Table Constants

		#region Column Length Constants
	
		public const int Action_CdMax = 10;
		public const int Action_DscMax = 50;
		public const int Create_UserMax = 30;
		public const int Modify_UserMax = 30;
		public const int Active_FlgMax = 1;
		public const int Start_FlgMax = 1;
		public const int End_FlgMax = 1;
		public const int Exception_FlgMax = 1;
		public const int Itv_FlgMax = 1;
		public const int Logistics_FlgMax = 1;
		public const int Edi_Status_CdMax = 10;

		#endregion	// #region Column Length Constants

		#region Column Fields

		protected string _Action_Cd;
		protected string _Action_Dsc;
		protected string _Create_User;
		protected DateTime? _Create_Dt;
		protected string _Modify_User;
		protected DateTime? _Modify_Dt;
		protected string _Active_Flg;
		protected string _Start_Flg;
		protected string _End_Flg;
		protected string _Exception_Flg;
		protected string _Itv_Flg;
		protected string _Logistics_Flg;
		protected SByte? _Max_Occurences;
		protected string _Edi_Status_Cd;

		#endregion	// #region Column Fields

		#region Column Properties

		public string Action_Cd
		{
			get { return _Action_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Action_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Action_CdMax )
					_Action_Cd = val.Substring(0, (int)Action_CdMax);
				else
					_Action_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Action_Cd");
			}
		}
		public string Action_Dsc
		{
			get { return _Action_Dsc; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Action_Dsc, val, false) == 0 ) return;
		
				if( val != null && val.Length > Action_DscMax )
					_Action_Dsc = val.Substring(0, (int)Action_DscMax);
				else
					_Action_Dsc = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Action_Dsc");
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
		public string Start_Flg
		{
			get { return _Start_Flg; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Start_Flg, val, false) == 0 ) return;
		
				if( val != null && val.Length > Start_FlgMax )
					_Start_Flg = val.Substring(0, (int)Start_FlgMax);
				else
					_Start_Flg = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Start_Flg");
			}
		}
		public string End_Flg
		{
			get { return _End_Flg; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_End_Flg, val, false) == 0 ) return;
		
				if( val != null && val.Length > End_FlgMax )
					_End_Flg = val.Substring(0, (int)End_FlgMax);
				else
					_End_Flg = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("End_Flg");
			}
		}
		public string Exception_Flg
		{
			get { return _Exception_Flg; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Exception_Flg, val, false) == 0 ) return;
		
				if( val != null && val.Length > Exception_FlgMax )
					_Exception_Flg = val.Substring(0, (int)Exception_FlgMax);
				else
					_Exception_Flg = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Exception_Flg");
			}
		}
		public string Itv_Flg
		{
			get { return _Itv_Flg; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Itv_Flg, val, false) == 0 ) return;
		
				if( val != null && val.Length > Itv_FlgMax )
					_Itv_Flg = val.Substring(0, (int)Itv_FlgMax);
				else
					_Itv_Flg = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Itv_Flg");
			}
		}
		public string Logistics_Flg
		{
			get { return _Logistics_Flg; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Logistics_Flg, val, false) == 0 ) return;
		
				if( val != null && val.Length > Logistics_FlgMax )
					_Logistics_Flg = val.Substring(0, (int)Logistics_FlgMax);
				else
					_Logistics_Flg = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Logistics_Flg");
			}
		}
		public SByte? Max_Occurences
		{
			get { return _Max_Occurences; }
			set
			{
				if( _Max_Occurences == value ) return;
		
				_Max_Occurences = value;
				_IsDirty = true;
				NotifyPropertyChanged("Max_Occurences");
			}
		}
		public string Edi_Status_Cd
		{
			get { return _Edi_Status_Cd; }
			set
			{
				string val = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
		
				if( string.IsNullOrEmpty(val) == true ) val = null;
		
				if( string.Compare(_Edi_Status_Cd, val, false) == 0 ) return;
		
				if( val != null && val.Length > Edi_Status_CdMax )
					_Edi_Status_Cd = val.Substring(0, (int)Edi_Status_CdMax);
				else
					_Edi_Status_Cd = val;
		
				_IsDirty = true;
				NotifyPropertyChanged("Edi_Status_Cd");
			}
		}

		#endregion	// #region Column Properties

		#region Foreign Key Fields



		#endregion	// #region Foreign Key Fields

		#region Foreign Key Properties



		#endregion	// #region Foreign Key Properties

		#region Constructors

		public ClsAction() : base() {}
		public ClsAction(DataRow dr) : base(dr) {}
		public ClsAction(ClsAction src) { CopyFrom(src); }

		#endregion		// #region Constructors

		#region Init methods

		public override void ResetColumns()
		{
			Action_Cd = null;
			Action_Dsc = null;
			Create_User = null;
			Create_Dt = null;
			Modify_User = null;
			Modify_Dt = null;
			Active_Flg = null;
			Start_Flg = null;
			End_Flg = null;
			Exception_Flg = null;
			Itv_Flg = null;
			Logistics_Flg = null;
			Max_Occurences = null;
			Edi_Status_Cd = null;
		}

		public void CopyFrom(ClsAction src)
		{
			Action_Cd = src._Action_Cd;
			Action_Dsc = src._Action_Dsc;
			Create_User = src._Create_User;
			Create_Dt = src._Create_Dt;
			Modify_User = src._Modify_User;
			Modify_Dt = src._Modify_Dt;
			Active_Flg = src._Active_Flg;
			Start_Flg = src._Start_Flg;
			End_Flg = src._End_Flg;
			Exception_Flg = src._Exception_Flg;
			Itv_Flg = src._Itv_Flg;
			Logistics_Flg = src._Logistics_Flg;
			Max_Occurences = src._Max_Occurences;
			Edi_Status_Cd = src._Edi_Status_Cd;
		}

		public override bool ReloadFromDB()
		{
			ClsAction tmp = ClsAction.GetUsingKey(Action_Cd);
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
				("@ACTION_CD", Action_Cd);
			p[1] = Connection.GetParameter
				("@ACTION_DSC", Action_Dsc);
			p[2] = Connection.GetParameter
				("@ACTIVE_FLG", Active_Flg);
			p[3] = Connection.GetParameter
				("@START_FLG", Start_Flg);
			p[4] = Connection.GetParameter
				("@END_FLG", End_Flg);
			p[5] = Connection.GetParameter
				("@EXCEPTION_FLG", Exception_Flg);
			p[6] = Connection.GetParameter
				("@ITV_FLG", Itv_Flg);
			p[7] = Connection.GetParameter
				("@LOGISTICS_FLG", Logistics_Flg);
			p[8] = Connection.GetParameter
				("@MAX_OCCURENCES", Max_Occurences);
			p[9] = Connection.GetParameter
				("@EDI_STATUS_CD", Edi_Status_Cd);
			p[10] = Connection.GetParameter
				("@CREATE_USER", Create_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Create_UserMax);
			p[11] = Connection.GetParameter
				("@CREATE_DT", Create_Dt, ParameterDirection.Output, DbType.DateTime, 0);
			p[12] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);
			p[13] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.Output, DbType.DateTime, 0);

			const string sql = @"
				INSERT INTO R_ACTION
					(ACTION_CD, ACTION_DSC, ACTIVE_FLG,
					START_FLG, END_FLG, EXCEPTION_FLG,
					ITV_FLG, LOGISTICS_FLG, MAX_OCCURENCES,
					EDI_STATUS_CD)
				VALUES
					(@ACTION_CD, @ACTION_DSC, @ACTIVE_FLG,
					@START_FLG, @END_FLG, @EXCEPTION_FLG,
					@ITV_FLG, @LOGISTICS_FLG, @MAX_OCCURENCES,
					@EDI_STATUS_CD)
				RETURNING
					CREATE_USER, CREATE_DT, MODIFY_USER,
					MODIFY_DT
				INTO
					@CREATE_USER, @CREATE_DT, @MODIFY_USER,
					@MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Create_User = ClsConvert.ToString(p[10].Value);
			Create_Dt = ClsConvert.ToDateTimeNullable(p[11].Value);
			Modify_User = ClsConvert.ToString(p[12].Value);
			Modify_Dt = ClsConvert.ToDateTimeNullable(p[13].Value);
			return ret;
		}
		public override int Update()
		{
			DbParameter[] p = new DbParameter[12];

			p[0] = Connection.GetParameter
				("@ACTION_DSC", Action_Dsc);
			p[1] = Connection.GetParameter
				("@MODIFY_DT", Modify_Dt, ParameterDirection.InputOutput, DbType.DateTime, 0);
			p[2] = Connection.GetParameter
				("@ACTIVE_FLG", Active_Flg);
			p[3] = Connection.GetParameter
				("@START_FLG", Start_Flg);
			p[4] = Connection.GetParameter
				("@END_FLG", End_Flg);
			p[5] = Connection.GetParameter
				("@EXCEPTION_FLG", Exception_Flg);
			p[6] = Connection.GetParameter
				("@ITV_FLG", Itv_Flg);
			p[7] = Connection.GetParameter
				("@LOGISTICS_FLG", Logistics_Flg);
			p[8] = Connection.GetParameter
				("@MAX_OCCURENCES", Max_Occurences);
			p[9] = Connection.GetParameter
				("@EDI_STATUS_CD", Edi_Status_Cd);
			p[10] = Connection.GetParameter
				("@ACTION_CD", Action_Cd);
			p[11] = Connection.GetParameter
				("@MODIFY_USER", Modify_User, ParameterDirection.Output, DbType.AnsiStringFixedLength, Modify_UserMax);

			const string sql = @"
				UPDATE R_ACTION SET
					ACTION_DSC = @ACTION_DSC,
					MODIFY_DT = @MODIFY_DT,
					ACTIVE_FLG = @ACTIVE_FLG,
					START_FLG = @START_FLG,
					END_FLG = @END_FLG,
					EXCEPTION_FLG = @EXCEPTION_FLG,
					ITV_FLG = @ITV_FLG,
					LOGISTICS_FLG = @LOGISTICS_FLG,
					MAX_OCCURENCES = @MAX_OCCURENCES,
					EDI_STATUS_CD = @EDI_STATUS_CD
				WHERE
					ACTION_CD = @ACTION_CD
				RETURNING
					MODIFY_USER, MODIFY_DT
				INTO
					@MODIFY_USER, @MODIFY_DT";
			int ret = Connection.RunSQL(sql, p);

			Modify_Dt = ClsConvert.ToDateTimeNullable(p[1].Value);
			Modify_User = ClsConvert.ToString(p[11].Value);
			return ret;
		}
		public override int Delete()
		{
			DbParameter[] p = new DbParameter[1];

			p[0] = Connection.GetParameter
				("@ACTION_CD", Action_Cd);

			const string sql = @"
				DELETE FROM R_ACTION WHERE
				ACTION_CD=@ACTION_CD";
			return Connection.RunSQL(sql, p);
		}
		#endregion		// #region Insert, Update, Delete

		#region Conversion methods

		public override void LoadFromDataReader(DbDataReader dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataReader: DataReader parameter was null");

			Action_Cd = ClsConvert.ToString(dr["ACTION_CD"]);
			Action_Dsc = ClsConvert.ToString(dr["ACTION_DSC"]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER"]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT"]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER"]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT"]);
			Active_Flg = ClsConvert.ToString(dr["ACTIVE_FLG"]);
			Start_Flg = ClsConvert.ToString(dr["START_FLG"]);
			End_Flg = ClsConvert.ToString(dr["END_FLG"]);
			Exception_Flg = ClsConvert.ToString(dr["EXCEPTION_FLG"]);
			Itv_Flg = ClsConvert.ToString(dr["ITV_FLG"]);
			Logistics_Flg = ClsConvert.ToString(dr["LOGISTICS_FLG"]);
			Max_Occurences = ClsConvert.ToSByteNullable(dr["MAX_OCCURENCES"]);
			Edi_Status_Cd = ClsConvert.ToString(dr["EDI_STATUS_CD"]);
		}

		public override void LoadFromDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("LoadFromDataRow: DataRow parameter was null");

			DataRowVersion v = ( dr.RowState == DataRowState.Deleted )
				? DataRowVersion.Original : DataRowVersion.Current;

			Action_Cd = ClsConvert.ToString(dr["ACTION_CD", v]);
			Action_Dsc = ClsConvert.ToString(dr["ACTION_DSC", v]);
			Create_User = ClsConvert.ToString(dr["CREATE_USER", v]);
			Create_Dt = ClsConvert.ToDateTimeNullable(dr["CREATE_DT", v]);
			Modify_User = ClsConvert.ToString(dr["MODIFY_USER", v]);
			Modify_Dt = ClsConvert.ToDateTimeNullable(dr["MODIFY_DT", v]);
			Active_Flg = ClsConvert.ToString(dr["ACTIVE_FLG", v]);
			Start_Flg = ClsConvert.ToString(dr["START_FLG", v]);
			End_Flg = ClsConvert.ToString(dr["END_FLG", v]);
			Exception_Flg = ClsConvert.ToString(dr["EXCEPTION_FLG", v]);
			Itv_Flg = ClsConvert.ToString(dr["ITV_FLG", v]);
			Logistics_Flg = ClsConvert.ToString(dr["LOGISTICS_FLG", v]);
			Max_Occurences = ClsConvert.ToSByteNullable(dr["MAX_OCCURENCES", v]);
			Edi_Status_Cd = ClsConvert.ToString(dr["EDI_STATUS_CD", v]);
		}

		public override void CopyToDataRow(DataRow dr)
		{
			if( dr == null )
				throw new ArgumentException
					("CopyToDataRow: DataRow parameter was null");

			dr["ACTION_CD"] = ClsConvert.ToDbObject(Action_Cd);
			dr["ACTION_DSC"] = ClsConvert.ToDbObject(Action_Dsc);
			dr["CREATE_USER"] = ClsConvert.ToDbObject(Create_User);
			dr["CREATE_DT"] = ClsConvert.ToDbObject(Create_Dt);
			dr["MODIFY_USER"] = ClsConvert.ToDbObject(Modify_User);
			dr["MODIFY_DT"] = ClsConvert.ToDbObject(Modify_Dt);
			dr["ACTIVE_FLG"] = ClsConvert.ToDbObject(Active_Flg);
			dr["START_FLG"] = ClsConvert.ToDbObject(Start_Flg);
			dr["END_FLG"] = ClsConvert.ToDbObject(End_Flg);
			dr["EXCEPTION_FLG"] = ClsConvert.ToDbObject(Exception_Flg);
			dr["ITV_FLG"] = ClsConvert.ToDbObject(Itv_Flg);
			dr["LOGISTICS_FLG"] = ClsConvert.ToDbObject(Logistics_Flg);
			dr["MAX_OCCURENCES"] = ClsConvert.ToDbObject(Max_Occurences);
			dr["EDI_STATUS_CD"] = ClsConvert.ToDbObject(Edi_Status_Cd);
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

		public static ClsAction GetUsingKey(string Action_Cd)
		{
			object[] vals = new object[] {Action_Cd};
			DataRow dr = Connection.GetDataRowUsingKey
				(TableName, GetPrimaryKeys(), vals);
			return ( dr == null ) ? null : new ClsAction(dr);
		}

		#endregion		// #region Static Methods
	}
}