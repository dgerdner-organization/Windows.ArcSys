using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsJobError
	{
		#region Static Methods
		public static void LogError(string sJob, string sError)
		{
			try
			{
				ClsJobError j = new ClsJobError();
				j.Error_Msg = sError;
				j.Job_Nm = sJob;
				j.Insert();
			}
			catch (Exception ex)
			{
				ClsErrorHandler.LogException(ex);
				throw;
			}
		}
		public static void DeleteRow(ClsJobError j)
		{
			DeleteRow(j.Job_Error_ID);
		}
		public static void DeleteRow(long? lID)
		{
			string sql = string.Format("delete from t_job_error where job_error_id = {0} ",  lID);
			Connection.RunSQL(sql);
		}
		#endregion
	}
}
