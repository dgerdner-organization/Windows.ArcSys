using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
    public partial class ClsApiLog
    {
        public void DeleteRow()
        {
            string sql = string.Format(@"delete from t_api_log where api_log_id = {0} ", this.Api_Log_ID);
            Connection.RunSQL(sql);
        }
        public static void ClearLog()
        {
            string sql = "delete from t_api_log where upper(success_cd) = 'FAIL' or create_dt < sysdate - 360 ";
            Connection.RunSQL(sql);
        }

        public static DataTable GetForDocument(string sDocumentNo)
        {
            string sql = string.Format(@"
                select t.* , 
				 case 
					when api_nm = 'api/BillOfLadings/add' then 'Send Shipping Instructions' 
					when api_nm like 'api/bookings/CargoStatusUpdate%' then 'Cargo Status Update'
					when api_nm = 'api/bookings/add' then 'Create Booking'
					when api_nm like 'api/bookings/update%' then 'Update Booking' 
						else api_nm 
						  end as api_type , t.create_dt as create_dtx
					from t_api_log t
					where document_no like '{0}%' ", sDocumentNo);
            DataTable dt = Connection.GetDataTable(sql);
            return dt;
        }

        public static DataTable GetPartnersDropdown()
        {
            string sql = string.Format(@"
                select trading_partner_cd, trading_partner_cd
                 from t_api_log
                  group by trading_partner_cd ");
            return Connection.GetDataTable(sql);
        }

        public static DataTable GetAPINameDropdown()
        {
//            string sql = string.Format(@"
//             select f_format_apinm (api_nm) as api_nm
//             from t_api_log
//              group by f_format_apinm(api_nm)");

            string sql =string.Format(@"select config_01 as api_nm, config_02 as api_dsc from r_configuration  where purpose_cd = 'APINM'");

            return Connection.GetDataTable(sql);
        }

        public static DataTable SearchApiLog(APILogSearchParms parms)
        {
//            string sql = string.Format(@"
//                select l.*, l.create_dt as log_date_long,
//                    f_format_apinm(l.api_nm) as api_nm_stripped from t_api_log l
//                  where 1 =  1 ");

            string sqlGroup = string.Format(@"
                  group by 
                  l.create_user, l.modify_user, 
                    batch_no, trading_partner_cd, api_nm, success_cd, api_msg, json_sent, message_cd, document_no, serial_no, action_cd, parameters, caller_id,
                  f_format_apinm(l.api_nm) ");

            string sql = string.Format(@"
                select max(l.api_log_id) as api_log_id, max(l.create_dt) as create_dt, l.create_user, max(l.modify_dt) as modify_dt, l.modify_user, max(l.create_dt) as log_date_long,
                    batch_no, trading_partner_cd, api_nm, success_cd, api_msg, json_sent, message_cd, document_no, serial_no, action_cd, parameters, caller_id,
                    f_format_apinm(l.api_nm) as api_nm_stripped , count(l.api_log_id) as attempts
                  from t_api_log l
                  where 1 =  1 ");

            if (parms.APIName.IsNotNull())
                sql = sql + string.Format(@" and f_format_apinm (api_nm) = '{0}' ", parms.APIName);
            if (parms.DocumentNo.IsNotNull())
                sql = sql + string.Format(" and document_no = '{0}' ", parms.DocumentNo);
            if (parms.SerialNo.IsNotNull())
                sql = sql + string.Format(" and serial_no = '{0}' ", parms.SerialNo);
            if (parms.JustFails)
                sql = sql + string.Format( " and upper(success_cd) = 'FAIL' ");
            sql = sql + string.Format(" and create_dt > sysdate - {0} ", parms.DaysHistory);

            sql = sql + sqlGroup;

            sql = sql + " order by create_dt ";

            DataTable dt = Connection.GetDataTable(sql);
            return dt;

        }
    }

    public class APILogSearchParms
    {
        public string APIName { get; set; }
        public string DocumentNo { get; set; }
        public string TradingPartner { get; set; }
        public string SerialNo { get; set; }
        public bool JustFails { get; set; }
        public Int32 DaysHistory { get; set; }
    }
}
