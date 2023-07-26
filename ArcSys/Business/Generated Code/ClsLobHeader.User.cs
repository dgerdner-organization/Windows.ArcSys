using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;
using CS2010.ACMS.Business;

namespace CS2010.ArcSys.Business
{
	partial class ClsLobHeader
	{

        public bool New_Flg { get; set; }

		public void PurgeLOB()
		{
			bool bIntrans = Connection.IsInTransaction;
			if (!bIntrans)
				Connection.TransactionBegin();
			try
			{
				string sql = string.Format(@"delete from t_lob_detail where lob_header_id = {0} ", this.Lob_Header_ID.GetValueOrDefault());
				Connection.RunSQL(sql);

				sql = string.Format(@"delete from t_lob_header where lob_header_id = {0} ", this.Lob_Header_ID.GetValueOrDefault());
				Connection.RunSQL(sql);

				if (!bIntrans)
					Connection.TransactionCommit();
			}
			catch (Exception ex)
			{
				if (!bIntrans)
					Connection.TransactionRollback();
				ClsErrorHandler.LogException(ex);
				throw;
			}
		}

		#region Static Methods
		public static ClsLobHeader GetByVoyagePOLVersion(string sVoyage, string sPOL, int VersionNo)
		{
            string sql = @"
                select * from t_lob_header 
                where voyage_no like @VOYAGE 
                    and pol_location_cd = @POL 
                    and version_no {2} = @VERSION_NO";

            List<DbParameter> p = new List<DbParameter>();

            p.Add( Connection.GetParameter("@VOYAGE",sVoyage));
            p.Add( Connection.GetParameter("@POL", sPOL));
            p.Add( Connection.GetParameter("@VERSION_NO", VersionNo));

            DataRow dr = Connection.GetDataRow(sql, p.ToArray());
			if (dr.IsNull()) return null;
			ClsLobHeader h = new ClsLobHeader(dr);
			return h;
		}

        public static DataTable GetDataTableByVoyagePOL(string sVoyage, string sPOL)
        {
            return GetDataTableByVoyagePOL(sVoyage, sPOL, LobVersionOrder.Ascending);
        }

        public static DataTable GetDataTableByVoyagePOL(string sVoyage, string sPOL, LobVersionOrder lobOrder)
        {
            string sql = string.Format(@"
				select h.* , case WHEN (h.transmit_dt is null) then to_char(h.version_no) else h.version_no || ' (Transmitted)' end as v
                from t_lob_header h
                where 1=1
                    and voyage_no like '{0}' 
                    and pol_location_cd = '{1}' 
                order by version_no {2}", sVoyage, sPOL, (lobOrder == LobVersionOrder.Ascending) ? "asc" : "desc");
            DataTable dt = Connection.GetDataTable(sql);
            return dt;
        }

        public static ClsLobHeader GetLatestVersion(string sVoyage, string sPOL)
        {
            DataTable dt = GetDataTableByVoyagePOL(sVoyage, sPOL, LobVersionOrder.Descending);
            if (dt.IsNull()) return null;
            if (dt.Rows.Count < 1) return null;
            return new ClsLobHeader(dt.Rows[0]);
        }
		public static ClsLobHeader GetFirstVersion(string sVoyage, string sPOL)
		{
			DataTable dt = GetDataTableByVoyagePOL(sVoyage, sPOL, LobVersionOrder.Descending);
			if (dt.IsNull()) return null;
			if (dt.Rows.Count < 1) return null;
			return new ClsLobHeader(dt.Rows[0]);
		}

        public static long GetLatestVersionNo(string sVoyage, string sPOL)
        {
            ClsLobHeader l = GetLatestVersion(sVoyage, sPOL);
            return  (l.IsNull()) ? 0 : (long)l.Version_No; 
        }

        public static int NextVersion(string sVoyage, string sPOL)
        {
            ClsLobHeader h = GetLatestVersion(sVoyage, sPOL);
            return (h.IsNull()) ? 1 : ((int)((long)h.Version_No + 1));
        }

		public static DataTable ExtractLOB(DataTable dtLOB, string sVoyage, string sPOL)
		{
			ClsLobHeader hdr = new ClsLobHeader();
			hdr.Confirm_Flg = "N";
			hdr.Voyage_No = sVoyage;
			hdr.Pol_Location_Cd = sPOL;
			CS2010.ACMS.Business.ClsVVoyage voy = CS2010.ACMS.Business.ClsVVoyage.GetByVoyageNo(sVoyage);
			hdr.Military_Voyage_No = voy.Military_Voyage_Cd;
			hdr.Vessel_Nm = voy.Vessel.Vessel_Dsc;
			hdr.Insert();
			foreach (DataRow drow in dtLOB.Rows)
			{
				ClsLobDetail lobD = new ClsLobDetail(drow);
				lobD.Lob_Header_ID = hdr.Lob_Header_ID;
				lobD.Insert();
			}
			DataTable dt = ClsLobDetail.GetByHeaderID(hdr.Lob_Header_ID.GetValueOrDefault());
			return dt;
		}
		#endregion
	}

    public enum LobVersionOrder
    {
        Ascending,
        Descending
    }
}
