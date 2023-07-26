using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;

namespace CS2010.ArcSys.Business
{
    public partial class ClsNhtsaRecall
    {

        public bool UpdateStatus(out string msg, ClsRecallStatus status)
        {
            return UpdateStatus(out msg, status, string.Empty);
        }

        public bool UpdateStatus(out string msg, ClsRecallStatus status, string note)
        {
            try
            {
                msg = string.Empty;

                if (this.Recall_Status_Cd != status.Recall_Status_Cd)
                {
                    this.Recall_Status_Cd = status.Recall_Status_Cd;
                    if (this.Update() != 1)
                    {
                        msg = "Could not update the Recall.";
                        return false;
                    }
                    ClsNhtsaRecallHistory h = new ClsNhtsaRecallHistory();
                    h.Recall_Status_Cd = status.Recall_Status_Cd;
                    h.Note_Text = "Status Updated to '" + status.Recall_Status_Dsc + "'.";
                    h.Nhtsa_Recall_ID = this.Nhtsa_Recall_ID;
                    h.Remark_Flg = "N";

                    if (h.Insert() != 1)
                    {
                        msg = "Could not update Recall Status/Note.";
                        return false;
                    }
                }

                // Add History
                if (note.Trim().IsNotNull())
                {
                    ClsNhtsaRecallHistory h = new ClsNhtsaRecallHistory();
                    h.Recall_Status_Cd = status.Recall_Status_Cd;
                    h.Note_Text = note.Trim();
                    h.Nhtsa_Recall_ID = this.Nhtsa_Recall_ID;
                    h.Remark_Flg = "Y";

                    if (h.Insert() != 1)
                    {
                        msg = "Could not update Recall Status/Note.";
                        return false;
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                return false;
            }

        }

        public static DataTable DashboardView()
        {
            string sql = @"
                Select r.voyage, l.location_cd, l.location_dsc, r.arrive_dt, r.recall_risk_cd, rr.recall_risk_dsc, count(*) as CT
                from t_nhtsa_recall r
                inner join r_location l on l.location_cd = r.pol
                inner join r_recall_risk rr on r.recall_risk_cd = rr.recall_risk_cd
                where r.recall_status_cd in ('NEW','PEND','ERR')
                and r.arrive_dt between sysdate and (sysdate + 90)
                group by 
                r.voyage, l.location_cd, l.location_dsc, r.arrive_dt, r.recall_risk_cd, rr.recall_risk_dsc
                order by r.arrive_dt";

            return Connection.GetDataTable(sql);
        }

        public List<ClsNhtsaRecallHistory> NhtsaHistory 
        {
            get
            {
                string sql = @"
                Select * 
                from t_nhtsa_recall_history h 
                where h.nhtsa_recall_id = @RECALL_ID
                order by h.create_dt";

                List<DbParameter> p = new List<DbParameter>();

                p.Add(Connection.GetParameter("RECALL_ID", this.Nhtsa_Recall_ID));

                return Connection.GetList<ClsNhtsaRecallHistory>(sql, p.ToArray());
            }
        }

        public static DataTable GetHistory(long NhtsaRecallID)
        {
            string sql = @"
                Select * 
                from t_nhtsa_recall_history h 
                where h.nhtsa_recall_id = @RECALL_ID
                order by h.create_dt";

            List<DbParameter> p = new List<DbParameter>();

            p.Add(Connection.GetParameter("RECALL_ID", NhtsaRecallID));

            return Connection.GetDataTable(sql, p.ToArray());
        }

        public static DataRow GetHistoryLastStatusUpdate(long NhtsaRecallID)
        {
            string sql = @"
                Select * 
                from t_nhtsa_recall_history h 
                where h.nhtsa_recall_history_id = 
                    (Select max(rh.nhtsa_recall_history_id) 
                    from t_nhtsa_recall_history rh 
                    where rh.nhtsa_recall_id = @ID)
            ";

            List<DbParameter> p = new List<DbParameter>();
            p.Add(Connection.GetParameter("ID",NhtsaRecallID));

            return Connection.GetDataRow(sql, p.ToArray());

        }

        public static List<string> GetVinsBatteryDisconnects(string BookingNo)
        {
            string sql = @"
                Select r.vin
                from t_nhtsa_recall r
                where r.recall_status_cd = 'ACB'
                and r.booking_no = @BOOKING_NO";

            List<DbParameter> p = new List<DbParameter>();

            p.Add(Connection.GetParameter("BOOKING_NO", BookingNo));

            DataTable dt = Connection.GetDataTable(sql, p.ToArray());

            List<string> s = new List<string>();

            foreach (DataRow dr in dt.Rows) s.Add(dr[0].ToString());

            return s;

        }

        public static List<string> GetVinsBatteryDisconnects(string BookingNo, string CargoType)
        {
            if (BookingNo == "ARC21005266")
            {
                string x = "x";
            }
            string sql = @"
                Select r.vin
                from t_nhtsa_recall r
                inner join t_edi_inbound_detail ial on (ial.booking_no = r.booking_no and ial.vin = r.vin)
                where r.recall_status_cd = 'ACB'
                and r.booking_no = @BOOKING_NO
                and ial.vehicle_type_cd = @CARGO_TYPE";

            List<DbParameter> p = new List<DbParameter>();

            p.Add(Connection.GetParameter("BOOKING_NO", BookingNo));
            p.Add(Connection.GetParameter("CARGO_TYPE", CargoType));

            DataTable dt = Connection.GetDataTable(sql, p.ToArray());

            List<string> s = new List<string>();

            foreach (DataRow dr in dt.Rows) s.Add(dr[0].ToString());

            return s;

        }

        public static DataTable GetVinsBatteryDisconnecsForLineSQL()
        {
            string sql = @"
                Select 
                '''' || r.voyage || '.' || r.vin || '''' || ',',
                r.booking_no, 
                r.vin, 
                r.voyage 
                from t_nhtsa_recall r
                where r.recall_status_cd = 'ACB'
                   and r.create_dt > sysdate - 300
                ";

            return Connection.GetDataTable(sql);

        }



    }
}
