using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
    public partial class ClsVwArcBolCargo
    {
        #region Extended Attributes

        public double Volume
        {
            get
            {
                return Math.Round(Length.GetValueOrDefault() * Width.GetValueOrDefault() * Height.GetValueOrDefault(), 0);
            }
        }

        public string Commodity_Cd
        {
            get { return this.Cargo_Commodity_Cd; }
            set { this.Cargo_Commodity_Cd = value; }
        }
        #endregion

        #region Static Methods
        public static List<ClsVwArcBolCargo> GetCargoByBOLid (long lBolID)
        {
            string sql = string.Format(@"
                select * from vw_arc_bol_cargo where bol_id = {0}", lBolID);

            DataTable dt = Connection.GetDataTable(sql);
            List<ClsVwArcBolCargo> cList = new List<ClsVwArcBolCargo>();
            foreach(DataRow drow in dt.Rows)
            {
                ClsVwArcBolCargo c = new ClsVwArcBolCargo(drow);
                cList.Add(c);
            }
            return cList;
        }

        public static List<ClsVwArcBolCargo> GetCargoByBolNo(string sBolNo)
        {
            string sql = string.Format(@"
                select * from vw_arc_bol_cargo  where bol_no = '{0}' and bol_no is not null", sBolNo);

            DataTable dt = Connection.GetDataTable(sql);
            List<ClsVwArcBolCargo> cList = new List<ClsVwArcBolCargo>();
            foreach (DataRow drow in dt.Rows)
            {
                ClsVwArcBolCargo c = new ClsVwArcBolCargo(drow);
                cList.Add(c);
            }
            return cList;
        }
        #endregion
    }
}
