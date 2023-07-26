using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business 
{
    public partial class ClsEdiiftmcs
    {
       public static List<ClsEdiiftmcs> GetUnProcessed()
       {
         List<ClsEdiiftmcs> list = new List<ClsEdiiftmcs>();
         string sql = "select * from T_EDIIFTMCS where processed_flg='N'";
         DataTable dt = Connection.GetTable(sql);
         foreach (DataRow row in dt.Rows)
         {
               list.Add(new ClsEdiiftmcs(row));
         }
         return list;
       }
    }
}
