using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsEdiCodeTranslation 
	{
        public static void DeleteItem(Int64 id)
        {
            string sql = string.Format(@"delete from t_edi_code_translation where edi_code_translation_id = {0} ", id);
            Connection.RunSQL(sql);
        }

        public static DataTable SearchByInterface(Int64 id)
        {
            string sql = string.Format(@"
                select t.*, i.interface_cd, f.field_nm
                 from t_edi_code_translation t
                  inner join r_edi_interface i on i.edi_interface_id = t.edi_interface_id
                  inner join r_edi_field f on f.edi_field_id = t.edi_field_id
                 where t.edi_interface_id = {0}  ", id);

            DataTable dt = Connection.GetDataTable(sql);
            return dt;
        }
    }
}
