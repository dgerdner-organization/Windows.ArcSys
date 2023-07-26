using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ACMS.Business
{
	public partial class ClsBookingItv
	{
        public long NextSeq()
        {
            string s = "select ediuser.t_booking_itv_seq.nextval  from dual";
            object Orc = Connection.GetScalar(s);
            long irc = Orc.ToLong();
            return irc;

        }
		public void DeleteITV()
		{
			bool bInTrans = Connection.IsInTransaction;
			if (!bInTrans)
				Connection.TransactionBegin();
			try
			{
				string sql = string.Format(@"
				delete from t_booking_itv where activity_id = {0} ", this.Activity_ID);
				Connection.RunSQL(sql);
				if (!bInTrans)
					Connection.TransactionCommit();
			}
			catch
			{
				if (!bInTrans)
					Connection.TransactionRollback();
				throw;
			}
		}
	}
}
