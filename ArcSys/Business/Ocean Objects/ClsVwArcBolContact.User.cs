using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;


namespace CS2010.ArcSys.Business
{
    public partial class ClsVwArcBolContact
    {
        #region Extended Attributes
        public string EffectiveName
        {
            get
            {
                if (Companyname.IsNotNull())
                    return Companyname;
                return this.Name;
            }
        }
        #endregion

        #region Static Methods
        public static List<ClsVwArcBolContact> GetContactsByBolNo(string sBolNo)
        {
            string sql = string.Format(@"
                select * from vw_arc_bol_contact where bol_no = '{0}'", sBolNo);

            DataTable dt = Connection.GetDataTable(sql);
            List<ClsVwArcBolContact> cList = new List<ClsVwArcBolContact>();
            foreach (DataRow drow in dt.Rows)
            {
                ClsVwArcBolContact c = new ClsVwArcBolContact(drow);
                cList.Add(c);
            }
            return cList;
        }
        #endregion

    }
}
