using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.AVSS.Business
{
	public partial class ClsCustomsSubmission
	{
		#region Constructors/Initialization

		public override void SetDefaults()
		{
			ResetColumns();

		}
		#endregion		// #region Constructors/Initialization

		#region ToString Overrides

		public override string ToString()
		{
			return string.Format("{0}: {1}-{2}-{3}-{4} Req: {5} By {6} on {7}",
				Vessel_Berth_Activity_ID, Vessel_Cd, Voyage_No, Port_Cd, Berth_Cd, Customs_Req_Flg,
				Submitted_User, ClsConfig.FormatDate(Submitted_Dt, "MMMM dd, yyyy"));
		}
		#endregion		// #region ToString Overrides

		#region Validation

		public override bool ValidateInsert()
		{
			_Errors.Clear();

			CommonValidation();

			return _Errors.Count == 0;
		}

		public override bool ValidateUpdate()
		{
			_Errors.Clear();

			CommonValidation();

			return _Errors.Count == 0;
		}

		private void CommonValidation()
		{
			if( Vessel_Berth_Activity_ID.GetValueOrDefault(0) <= 0 )
				_Errors["Vessel_Berth_Activity_ID"] = "Missing or invalid berth activity ID";
			if (string.IsNullOrEmpty(Vessel_Cd) == true)
				_Errors["Vessel_Cd"] = "Missing vessel code";
			if (string.IsNullOrEmpty(Voyage_No) == true)
				_Errors["Voyage_No"] = "Missing voyage number";
			if (string.IsNullOrEmpty(Port_Cd) == true)
				_Errors["Port_Cd"] = "Missing port code";
			if (string.IsNullOrEmpty(Berth_Cd) == true)
				_Errors["Berth_Cd"] = "Missing berth code";
			if (string.IsNullOrEmpty(Submitted_User) == true)
				_Errors["Submitted_User"] = "Missing user";
			if (!ClsConvert.ValidateYN(Customs_Req_Flg))
				_Errors["Customs_Req_Flg"] = "Missing or invalid customs required flag";
			else
			{
				if (ClsConvert.YNToBool(Customs_Req_Flg))
				{	// If customs required, date is required
					if (Submitted_Dt == null)
						_Errors["Submitted_Dt"] = "Missing submission date";
				}
			}
		}
		#endregion		// #region Validation

		public static ClsCustomsSubmission GetUsingVessBerthActID(long vbaID)
		{
			string sql = @"
			SELECT	c.*
			FROM	t_customs_submission c
			WHERE	c.vessel_berth_activity_id = @VBTHID ";

			DbParameter[] p = new DbParameter[1];
			p[0] = Connection.GetParameter("@VBTHID", vbaID);

			DataRow dr = Connection.GetDataRow(sql, p);
			return (dr != null) ? new ClsCustomsSubmission(dr) : null;
		}
	}

	#region Customs Manager

	public class CustomsMgr
	{
		#region Fields/Properties

		public ClsConnection Connection
		{
			get
			{
				return ClsConMgr.Manager["AVSS"];
			}
		}

		private StringBuilder sbError;
		public string Error { get { return sbError.ToString(); } }

		#endregion		// #region Fields/Properties

		#region Constructors

		public CustomsMgr()
		{
			sbError = new StringBuilder();
		}
		#endregion		// #region Constructors

		#region Helper Methods

		private bool AddError(string msg, params object[] args)
		{
			sbError.AppendFormat(msg, args);
			return false;
		}
		#endregion		// #region Helper Methods

		#region Search


		public DataTable SearchAvailable()
		{
			string sql = @"
				SELECT	vi.vessel_berth_activity_id, vi.vessel, vi.voyage, vi.port, vi.berth,
						vi.port_dt, vi.vessel_nm, vi.port_nm, vi.berth_nm,
						'US Import' AS customs_type
				FROM	v_customs_us_import vi
			UNION ALL
				SELECT	vx.vessel_berth_activity_id, vx.vessel, vx.voyage, vx.port, vx.berth,
						vx.port_dt, vx.vessel_nm, vx.port_nm, vx.berth_nm,
						'US Export' AS customs_type
				FROM	v_customs_us_export vx
			UNION ALL
				SELECT	veu.vessel_berth_activity_id, veu.vessel, veu.voyage, veu.port, veu.berth,
						veu.port_dt, veu.vessel_nm, veu.port_nm, veu.berth_nm,
						'Europe' AS customs_type
				FROM	v_customs_europe veu
			ORDER BY customs_type, port_dt ";

			DataTable dt = Connection.GetDataTable(sql);
			if (dt != null) dt.TableName = "AvailableCustoms";
			return dt;
		}

		public DataTable SearchHistory()
		{
			string sql = @"
				SELECT	*
				FROM	t_customs_submission c
				ORDER BY
					c.customs_category, c.port_dt ";

			DataTable dt = Connection.GetDataTable(sql);
			if (dt != null) dt.TableName = "CustomsHistory";
			return dt;
		}
		#endregion		// #region Search

		#region Submit

		public bool Submit(DataRow[] rows, string subUser, DateTime? subDt, bool custReqFlg, string notes)
		{
			sbError.Length = 0;
			if (rows == null || rows.Length <= 0)
				return AddError("No rows provided");

			List<ClsCustomsSubmission> subList = new List<ClsCustomsSubmission>();
			foreach (DataRow dr in rows)
			{
				long? vbaID = ClsConvert.ToInt64Nullable(dr["Vessel_Berth_Activity_ID"]);
				ClsCustomsSubmission csub = (vbaID != null)
					? ClsCustomsSubmission.GetUsingVessBerthActID(vbaID.Value) : null;
				if (csub != null)
				{
					AddError("Already submitted: {0}\r\n", csub.ToString());
					continue;
				}

				csub = new ClsCustomsSubmission();
				csub.Vessel_Berth_Activity_ID = vbaID;
				csub.Vessel_Cd = ClsConvert.ToString(dr["Vessel"]);
				csub.Voyage_No = ClsConvert.ToString(dr["Voyage"]);
				csub.Port_Cd = ClsConvert.ToString(dr["Port"]);
				csub.Berth_Cd = ClsConvert.ToString(dr["Berth"]);
				csub.Port_Dt = ClsConvert.ToDateTimeNullable(dr["Port_Dt"]);
				csub.Customs_Category = ClsConvert.ToString(dr["customs_type"]);
				csub.Submitted_User = subUser;
				csub.Submitted_Dt = subDt;
				csub.Customs_Req_Flg = ClsConvert.BoolToYN(custReqFlg);
				csub.Notes = notes;

				if (!csub.ValidateInsert())
				{
					AddError(csub.Error);
					dr.SetColumnError("Vessel_Nm", csub.Error);
				}
				else
					subList.Add(csub);
			}

			if (sbError.Length > 0) return false;

			bool newTx = !Connection.IsInTransaction;
			try
			{
				if (newTx == true) Connection.TransactionBegin();

				foreach (ClsCustomsSubmission csub in subList)
					csub.Insert();

				if (newTx == true) Connection.TransactionCommit();

				return true;
			}
			catch( Exception ex )
			{
				if (newTx == true) Connection.TransactionRollback();
				ClsErrorHandler.LogException(ex);
				AddError(ex.Message);
			}

			return false;
		}
		#endregion		// #region Submit

		#region Ignore

		public bool Ignore(DataRow[] rows, string subUser, string notes)
		{
			sbError.Length = 0;
			if (rows == null || rows.Length <= 0)
				return AddError("No rows provided");

			List<ClsCustomsSubmission> subList = new List<ClsCustomsSubmission>();
			foreach (DataRow dr in rows)
			{
				long? vbaID = ClsConvert.ToInt64Nullable(dr["Vessel_Berth_Activity_ID"]);
				ClsCustomsSubmission csub = (vbaID != null)
					? ClsCustomsSubmission.GetUsingVessBerthActID(vbaID.Value) : null;
				if (csub != null)
				{
					AddError("Already submitted: {0}\r\n", csub.ToString());
					continue;
				}

				csub = new ClsCustomsSubmission();
				csub.Vessel_Berth_Activity_ID = vbaID;
				csub.Vessel_Cd = ClsConvert.ToString(dr["Vessel"]);
				csub.Voyage_No = ClsConvert.ToString(dr["Voyage"]);
				csub.Port_Cd = ClsConvert.ToString(dr["Port"]);
				csub.Berth_Cd = ClsConvert.ToString(dr["Berth"]);
				csub.Port_Dt = ClsConvert.ToDateTimeNullable(dr["Port_Dt"]);
				csub.Customs_Category = ClsConvert.ToString(dr["customs_type"]);
				csub.Submitted_User = subUser;
				csub.Submitted_Dt = null;
				csub.Customs_Req_Flg = "N";
				csub.Notes = notes;

				if (!csub.ValidateInsert())
				{
					AddError(csub.Error);
					dr.SetColumnError("Vessel_Nm", csub.Error);
				}
				else
					subList.Add(csub);
			}

			if (sbError.Length > 0) return false;

			bool newTx = !Connection.IsInTransaction;
			try
			{
				if (newTx == true) Connection.TransactionBegin();

				foreach (ClsCustomsSubmission csub in subList)
					csub.Insert();

				if (newTx == true) Connection.TransactionCommit();

				return true;
			}
			catch (Exception ex)
			{
				if (newTx == true) Connection.TransactionRollback();
				ClsErrorHandler.LogException(ex);
				AddError(ex.Message);
			}

			return false;
		}
		#endregion		// #region Ignore
	}
	#endregion		// #region Customs Manager
}