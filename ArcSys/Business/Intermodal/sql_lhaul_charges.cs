using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
    public class sql_lhaul_charges : sql_base
    {
        protected override string connection_key
        {
            get { return "ArcSys"; }
        }

        protected override string base_query
        {
            get
            {
                return @" 
                    Select vlc.*,
                    vtm.*, 
                    CASE
                        WHEN (vtm.ARC_BOOKING_NO is null) THEN 'N'
                        WHEN ((vtm.ARC_BOOKING_NO = vtm.ATTACHED_BOOKING_NO) and (vtm.ARC_BOOKING_NO is not null)) THEN 'N' 
                        ELSE 'Y' 
                    END as TRANS_YN
                    from 
                    V_CS_LHAUL_CHARGES VLC
                    left outer join V_TRANSSHIPMENTS_MIN VTM on VLC.booking_no = VTM.ARC_BOOKING_NO
                    [WHERE] ";

            }
        }

        public void Run(string booking)
        {
            StringBuilder sb = new StringBuilder();

            if (booking.IsNotNull()) sb.AppendFormat(" where VTM.ATTACHED_BOOKING_NO in ('{1}')", booking.Trim(),booking.Trim());

            RunWhere(sb.ToString());
        }

    }
}
