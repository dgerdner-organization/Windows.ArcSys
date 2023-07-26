using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CS2010.ArcSys.Business
{
    public partial class ClsRecallVin
    {
        public static DataTable GetRecallVINS()
        {
            string sql = @"
                Select rv.*, det.vehicle_year, det.make, det.model 
                from 
                r_recall_vin rv 
                inner join t_edi_inbound_detail det on rv.vin = det.vin";

            return Connection.GetDataTable(sql);
        }
    }
}
