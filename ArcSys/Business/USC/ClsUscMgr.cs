using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public class ClsUscMgr
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ArcSys"]; }
		}
		#endregion		// #region Connection Manager

		#region Get Data

		public static DataTable GetRatesLinehaulP2P()
		{
			string sql = @"SELECT v.* FROM v_usc_linehaul_p2p v ";

			return Connection.GetDataTable(sql);
		}

		public static DataTable GetRatesLinehaulMileage()
		{
			string sql = @"SELECT v.* FROM v_usc_linehaul_mile v ";

			return Connection.GetDataTable(sql);
		}

		public static DataTable GetRatesAssessorial()
		{
			string sql = @"SELECT v.* FROM v_usc_assessorial v ";

			return Connection.GetDataTable(sql);
		}

		public static DataTable GetRatesOceanBB()
		{
			string sql = @"SELECT v.* FROM v_usc_ocean_bb v ";

			return Connection.GetDataTable(sql);
		}

		public static DataTable GetRatesOceanContainer()
		{
			string sql = @"SELECT v.* FROM v_usc_ocean_ctr v ";

			return Connection.GetDataTable(sql);
		}

		public static DataTable GetRatesOceanRoute()
		{
			string sql = @"SELECT v.* FROM v_usc_ocean_route v ";

			return Connection.GetDataTable(sql);
		}

		public static DataTable GetDistinctData(string tabName, string colName)
		{
			string viewName = null;
			if (tabName == ClsUscInlandBb.TableName)
				viewName = "v_usc_linehaul_p2p";
			else if (tabName == ClsUscMileage.TableName)
				viewName = "v_usc_linehaul_mile";
			else if (tabName == ClsUscAssessorial.TableName)
				viewName = "v_usc_assessorial";
			else
				return null;

			string sql = string.Format("SELECT DISTINCT {0} AS col_data FROM {1}",
				colName, viewName);
			return Connection.GetDataTable(sql);
		}
		#endregion		// #region Get Data

		#region Rate Basis/Conveyance Types

		public static ClsLevelUnit ComputeRateBasis(string unitTypeDsc)
		{
			string sql = @"
			SELECT	lvu.*
			FROM	r_usc_level usl
					INNER JOIN r_level_unit lvu		ON lvu.level_unit_id = usl.level_unit_id
			WHERE	UPPER(TRIM(usl.usc_level_dsc)) = @LEV_DSC ";

			DbParameter[] p = new DbParameter[1];
			string ut = (unitTypeDsc != null) ? unitTypeDsc.ToUpper().Trim() : null;
			p[0] = Connection.GetParameter("@LEV_DSC", ut);
			DataRow dr = Connection.GetDataRow(sql, p);
			return (dr != null) ? new ClsLevelUnit(dr) : null;
		}

		public static void ComputeConveyanceType(string fb_dd_field, string oog_field,
			out string fb_flg, out string dd_flg, out string o_flg)
		{
			string cnt = (fb_dd_field != null) ? fb_dd_field.ToUpper().Trim() : null;
			if (string.IsNullOrWhiteSpace(cnt) || cnt.Contains("FLAT") == true ||
				cnt.Contains("DOUB") == false)
				fb_flg = "Y";
			else
				fb_flg = "N";

			if (string.IsNullOrWhiteSpace(cnt) || cnt.Contains("DOUB") == true ||
				cnt.Contains("FLAT") == false)
				dd_flg = "Y";
			else
				dd_flg = "N";

			string comm = (oog_field != null) ? oog_field.ToUpper().Trim() : null;
			if (!string.IsNullOrWhiteSpace(comm) && comm.Contains("OOG"))
				o_flg = "Y";
			else
				o_flg = "N";
		}
		#endregion		// #region Rate Basis/Conveyance Types

		#region Add/Update Rates

		public static bool SaveAll(DataTable dtChangesP2P, DataTable dtChangesMile,
			DataTable dtChangesAss, out string errMsg, out string infoMsg)
		{
			errMsg = null;
			infoMsg = null;
			Dictionary<ClsUscInlandBb, DataRowState> p2pChanges = null;
			Dictionary<ClsUscMileage, DataRowState> mileChanges = null;
			Dictionary<ClsUscAssessorial, DataRowState> assChanges = null;

			string err = null;
			StringBuilder sbErr = new StringBuilder();
			if (dtChangesP2P != null && dtChangesP2P.Rows.Count > 0)
			{
				p2pChanges = CheckChanges<ClsUscInlandBb>(dtChangesP2P, out err);
				if (p2pChanges == null) sbErr.AppendLine(err);
			}

			if (dtChangesMile != null && dtChangesMile.Rows.Count > 0)
			{
				mileChanges = CheckChanges<ClsUscMileage>(dtChangesMile, out err);
				if (mileChanges == null) sbErr.AppendLine(err);
			}

			if (dtChangesAss != null && dtChangesAss.Rows.Count > 0)
			{
				assChanges = CheckChanges<ClsUscAssessorial>(dtChangesAss, out err);
				if (assChanges == null) sbErr.AppendLine(err);
			}

			if (sbErr.Length > 0)
			{
				errMsg = sbErr.ToString();
				return false;
			}

			if ((p2pChanges == null || p2pChanges.Count <= 0) &&
				(mileChanges == null || mileChanges.Count <= 0) &&
				(assChanges == null || assChanges.Count <= 0))
			{
				errMsg = "No changes found";
				return false;
			}

			bool newTx = !Connection.IsInTransaction;
			try
			{
				if (newTx == true) Connection.TransactionBegin();

				string sinfo = null;
				StringBuilder sbInfo = new StringBuilder();

				if (p2pChanges != null && p2pChanges.Count > 0)
				{
					SaveData<ClsUscInlandBb>(p2pChanges, out sinfo);
					if (!string.IsNullOrWhiteSpace(sinfo))
						sbInfo.AppendLine(sinfo);
				}

				if (mileChanges != null && mileChanges.Count > 0)
				{
					SaveData<ClsUscMileage>(mileChanges, out sinfo);
					if (!string.IsNullOrWhiteSpace(sinfo))
						sbInfo.AppendLine(sinfo);
				}

				if (assChanges != null && assChanges.Count > 0)
				{
					SaveData<ClsUscAssessorial>(assChanges, out sinfo);
					if (!string.IsNullOrWhiteSpace(sinfo))
						sbInfo.AppendLine(sinfo);
				}

				Connection.TransactionCommit();
				newTx = false;

				if (sbInfo.Length > 0) infoMsg = sbInfo.ToString();

				return true;
			}
			catch
			{
				if (newTx == true) Connection.TransactionRollback();
				throw;
			}
		}

		protected static Dictionary<T, DataRowState> CheckChanges<T>(DataTable dtChanges,
			out string errMsg) where T : ClsBaseTable, new()
		{
			errMsg = null;
			if (dtChanges == null || dtChanges.Rows.Count <= 0)
			{
				ClsErrorHandler.LogError("ClsUscMgr.CheckChanges: No rows provided");
				errMsg = "No rows provided";
				return null;
			}

			Type t = typeof(T);
			if (t != typeof(ClsUscInlandBb) && t != typeof(ClsUscMileage) &&
				t != typeof(ClsUscAssessorial))
			{
				ClsErrorHandler.LogError("ClsUscMgr.CheckChanges: Method cannot be used with given object type");
				errMsg = "Method cannot be used with given object type";
				return null;
			}

			int errors = 0;
			Dictionary<T, DataRowState> Changes = new Dictionary<T, DataRowState>();
			foreach (DataRow dr in dtChanges.Rows)
			{
				if (dr.RowState == DataRowState.Detached || dr.RowState == DataRowState.Unchanged ||
					dr.RowState == DataRowState.Deleted)	// We do not allow deletes
					continue;

				dr.ClearErrors();
				T item = null;
				if (dr.RowState == DataRowState.Modified)
				{
					item = new T();
					item.LoadFromDataRow(dr);
					if (!item.ValidateUpdate())
					{
						errors++;
						item.FillError(dr);
						dr.RowError = item.Error;
					}
				}
				else
				{
					item = new T();
					item.LoadFromDataRow(dr);
					if (!item.ValidateInsert())
					{
						errors++;
						item.FillError(dr);
						dr.RowError = item.Error;
					}
				}
				if (!dr.HasErrors) Changes.Add(item, dr.RowState);
			}

			if (errors > 0)
			{
				errMsg = "Error in one or more rows";
				return null;
			}

			return Changes;
		}

		protected static void SaveData<T>(Dictionary<T, DataRowState> Changes, out string extraInfo)
			where T : ClsBaseTable, new()
		{
			extraInfo = null;
			if (Changes == null || Changes.Count <= 0)
				throw new ClsException(true, "No rows provided");

			Type t = typeof(T);
			if( t != typeof(ClsUscInlandBb) && t!= typeof(ClsUscMileage) &&
				t != typeof(ClsUscAssessorial) )
				throw new ClsException(true, "Method cannot be used with given object type");

			bool newTx = !Connection.IsInTransaction;
			try
			{
				if (newTx == true) Connection.TransactionBegin();

				StringBuilder sb = new StringBuilder();
				foreach (T item in Changes.Keys)
				{
					DataRowState state = Changes[item];
					if (state == DataRowState.Modified)
						item.Update();
					else if (state == DataRowState.Added)
						item.Insert();
					sb.AppendFormat("{0} - {1}\r\n", state, item);
				}
				if (newTx == true) Connection.TransactionCommit();
				newTx = false;

				extraInfo = sb.ToString();
			}
			catch
			{
				if (newTx == true) Connection.TransactionRollback();
				throw;
			}
		}
		#endregion		// #region Add/Update Rates
	}
}