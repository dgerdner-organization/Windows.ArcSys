using System;
using System.IO;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ACMS.Business
{
	public partial class ClsEdiActivityFtp
	{
		public static DataTable Search(string sPartnerCd, string sInOut, string sType, int iDays)
		{
			string sql = string.Format(@"
				select trim(table_dsc) as table_dsc,
				 in_out, trading_partner_cd, trans_dt, ftp_success_cd, map_success_cd,
				  trans_ctl_no, edi_type
				from t_edi_activity_ftp
                     where 1 = 1 ");

			if (!string.IsNullOrEmpty(sPartnerCd))
				sql = sql + string.Format(" and trading_partner_cd = '{0}' ", sPartnerCd);

			if (!string.IsNullOrEmpty(sInOut))
				sql = sql + string.Format(" and in_out = '{0}' ", sInOut);

			if (iDays > 0)
				sql = sql + "and trans_dt > sysdate - " + iDays.ToString();

			DataTable dt = Connection.GetDataTable(sql);
			return dt;
		}

		public static DataTable GetISAGaps(ClsConnection conn, string sPartnerCd, string sInOut, int iDays)
		{
			string sql = string.Format(@"
				  select (select nvl(max(trans_ctl_no)+1,1) 
					  from t_edi_activity_ftp 
					  where trans_ctl_no < md.trans_ctl_no and trunc(md.trans_dt) > trunc(sysdate) - {0}
						and in_out = 'I' 
						and trading_partner_cd like 'MTM%') as from_isa,
				   md.trans_ctl_no - 1 as to_isa
				  from t_edi_activity_ftp md
				  where md.trans_ctl_no != 1 and not exists (
					select 1 
					  from t_edi_activity_ftp md2 where md2.trans_ctl_no = md.trans_ctl_no - 1 
					   and trunc(md2.trans_dt) > trunc(sysdate - {0}) and in_out = 'I' and trading_partner_cd like 'MTM%')
				  and trunc(md.trans_dt) > trunc(sysdate - {0}) and in_out = 'I' and trading_partner_cd like 'MTM%' 
				  and trans_ctl_no <>
				   (select min(trans_ctl_no) 
				  from t_edi_activity_ftp min where min.in_out = 'I' 
				   and trunc(trans_dt) > trunc(sysdate) - {0} and trading_partner_cd like 'MTM%')",
						iDays);
			DataTable dt = conn.GetDataTable(sql);
			return dt;
		}

        //public static DataTable GetFTPerrors()
        //{
        //    return null;
            //string sDir = @"\\\\commserver01\\in_out\\ANSI300_Exp\\Error\\";
            //string[] array1 = Directory.GetFiles(sDir);

            //sDir = @"\\\\commserver01\\in_out\\ANSI310_Exp\\Error\\";
            //string[] array2 = Directory.GetFiles(sDir);

            //sDir = @"\\\\commserver01\\in_out\\CAT315_Exp\\Error\\";
            //string[] array3 = Directory.GetFiles(sDir);

            //int iCount = array1.Length + array2.Length + array3.Length;
            //DataTable dt = new DataTable();
            //dt.Columns.Add("file_count");
            //dt.Columns.Add("hyperlink");
            //if (iCount > 0)
            //{
            //    dt.Rows.Add(iCount.ToString(), "EDI Monitor");
            //}
            //return dt;
        //}
	}
}
