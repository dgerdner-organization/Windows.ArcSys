using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CS2010.Common;
using CS2010.ArcSys.Business;

namespace CS2010.ArcSys.Business
{
	public class ClsEDIUtilities
	{
		#region Connections
		private static ClsConnection Connection
		{
			get
			{
				// "ArcSys" is the normal connecton string.  However, at least
				// one of our applications (SDDCEDI) uses "AROF" instead.
				if (ClsConMgr.Manager["AROF"] == null)
					return ClsConMgr.Manager["ArcSys"];
				return ClsConMgr.Manager["AROF"];
			}
		}
		#endregion

		#region Attributes
		public string BookingNo { get; set; }
		public string PartnerCd { get; set; }
		public string SerialNo { get; set; }
		public string VoyageNo { get; set; }
		public long? Days { get; set; }
		public string ActionCd { get; set; }
		public string PCFN { get; set; }
		public string MapType { get; set; }
		public string PolCd { get; set; }
		public string PodCd { get; set; }
        public bool UnprocessedOnly { get; set; }

		#endregion

		#region Methods

		public DataTable EDIMainQuery()
		{
			StringBuilder sql = new StringBuilder();
			sql.AppendFormat(@"select isa_id, isa_no, in_out, trading_partner_cd, map_nm, edi_type, file_nm, folder_nm, error_flg, error_msg,
                                count(isa_id) as isa_count, isa_dt as isa_fulldd, detail_error_msg, processed_flg, serial_no, booking_no
							 from v_edi_all
							  where isa_dt > sysdate - {0}
                                and isa_dt < sysdate - .00", Days);

			if (!string.IsNullOrEmpty(PartnerCd))
				sql.AppendFormat(" and trading_partner_cd like '{0}' ", PartnerCd);
			if (!string.IsNullOrEmpty(BookingNo))
				sql.AppendFormat(" and booking_no = '{0}'", BookingNo);
			if (!string.IsNullOrEmpty(SerialNo))
				sql.AppendFormat(" and serial_no = '{0}'", SerialNo);
			if (!string.IsNullOrEmpty(PCFN))
				sql.AppendFormat(" and request_cd = '{0}'", PCFN);
			if (!string.IsNullOrEmpty(ActionCd))
				sql.AppendFormat(" and action_cd = '{0}'", ActionCd);
			if (!string.IsNullOrEmpty(MapType))
				sql.AppendFormat(" and '{0}' in (edi_type, '(All)') ", MapType);
			if (!string.IsNullOrEmpty(PolCd))
				sql.AppendFormat(" and pol_cd = '{0}' ", PolCd);
			if (!string.IsNullOrEmpty(PodCd))
				sql.AppendFormat(" and pod_cd = '{0}' ", PodCd);
            if (UnprocessedOnly)
                sql.AppendFormat(" and processed_flg = 'N' ");

            sql.Append(" group by isa_id, isa_dt, isa_no, in_out, trading_partner_cd, map_nm, edi_type, file_nm, folder_nm, error_flg, error_msg, detail_error_msg, processed_flg, serial_no, booking_no");

			string s = sql.ToString();
			DataTable dt = Connection.GetDataTable(s);
			return dt;
		}

		public DataTable EDIisaQuery(ClsIsa isa)
		{
			StringBuilder SBsql = new StringBuilder();
			if (isa.Edi_Type == "315")
				return EDI315Query(isa);
            //if (isa.Edi_Type == "310")
            //    return EDI310Query(isa);
            if (isa.Edi_Type == "301")
                return EDI301Query(isa);
			SBsql.AppendFormat(@"select v.* from v_edi_all v where isa_id = {0} and v.edi_type = '{1}'", isa.Isa_ID, isa.Edi_Type);
			DataTable dt = Connection.GetDataTable(SBsql.ToString());
			return dt;
		}

        public DataTable EDIisaIALQuery(string sFile)
        {
            string sql = string.Format(@"
                select i.isa_nbr, booking_no, serial_no, pol_location_cd as pol_cd, pod_location_cd as pod_cd,activity_cd as action_cd      
                    from t_itv i
                      inner join t_edi_outbound_log log on log.trading_partner_cd = i.trading_partner_cd
                       and log.isa_nbr = i.isa_nbr
                       and log.log_dt > sysdate - 360
                       and i.trading_partner_cd = 'IAL'
                  where f_get_filename(log.file_nm) = '{0}' ", sFile);

            DataTable dt = Connection.GetDataTable(sql);
            return dt;
        }

        public DataTable EDIIALCargoDetail(string sFile)
        {
            string sql = string.Format(@"
               select d.*, f_get_filename(source_file) as file_nm
                 from t_edi_inbound_detail d
                  where source_file is not null
                   and create_dt > sysdate - 360
                    and f_get_filename(source_file) = '{0}' ", sFile);
            DataTable dt = Connection.GetDataTable(sql);
            return dt;
        }

		public DataTable EDI315Query(ClsIsa isa)
		{
			string dblink = "ACMSP";
			if (Connection.DbConnectionString.Contains("AROFD") ||
				Connection.DbConnectionString.Contains("AROFT"))
				dblink = "ACMS";
			string sql = string.Format(@" 
				select isa_no, t_edi315.activity_cd, t_edi315.activity_dt, t_edi315.serial_no, 
						  case
							when i.create_dt is null then  t_edi315.create_dt 
							else i.create_dt end as itv_create_dt,
						  t_edi315.booking_no, t_edi315.pcfn, t_edi315.location_cd, t_edi315.voyage_no, t_edi315.military_voyage_no, vessel_nm, msg, t_edi315.processed_flg,
						  i.create_dt as trx_dt,
						  trunc(i.create_dt) - trunc(t_edi315.activity_dt) as trx_delay,
						  trunc(t_edi315.create_dt) - trunc(t_edi315.activity_dt) as create_delay
				   from t_edi315 
					inner join t_isa on t_edi315.isa_id = t_isa.isa_id
					left outer join t_booking_itv<DBLINK>{1} i on i.activity_id = t_edi315.itv_id
				 where t_edi315.isa_id = {0} ", isa.Isa_ID, dblink);
			DataTable dt = Connection.GetDataTable(sql);
			return dt;
		}
        public DataTable EDI310Query(ClsIsa isa)
        {
            string dblink = "ACMSP";
            if (Connection.DbConnectionString.Contains("AROFD") ||
                Connection.DbConnectionString.Contains("AROFT"))
                dblink = "ACMS";
            string sql = string.Format(@" 
				select isa_no, null as activity_cd, null as activity_dt,  null as serial_no, t.create_dt,
                    t.booking_no, null as pcfn, t.pod_cd as location_cd, t.voyage_no, null as military_voyage_no, vessel_dsc as vessel_nm, '' as msg, t.processed_flg
                   from t_edi310 t
                  inner join t_isa on t.isa_id = t_isa.isa_id
				 where t.isa_id = {0} ", isa.Isa_ID, dblink);
            DataTable dt = Connection.GetDataTable(sql);
            return dt;
        }
        public DataTable EDI301Query(ClsIsa isa)
        {
            string sql = string.Format(@"
                    select t_isa.isa_id, isa_no, c.tcn as serial_no, t_edi301.action_cd,
                          t_edi301.booking_no,  t_edi301.pol_cd, t_edi301.pod_cd, t_edi301.voyage_no,   
                          t_edi301.processed_flg, item_no, type_pack_cd,
                          commodity_cd, packaging_form_cd, t_edi301.request_cd, t_edi301.adj_rdd_dt as rdd_dt
                       from t_edi301 
                      inner join t_isa  on t_edi301.isa_id = t_isa.isa_id
                      left outer join t_edi301_cargo c on c.edi301_id = t_edi301.edi301_id
                     where t_edi301.isa_id = {0}", isa.Isa_ID);
            DataTable dt = Connection.GetDataTable(sql);
            return dt;

        }
		#endregion

	}

}
