using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
    public class sql_avss_military_voyages : sql_base
    {
        protected override string connection_key
        {
            get { return "AVSS"; }
        }

        protected override string base_query
        {

            get
            {
                return @"
                    Select 
                    v.vessel_nm, 
                    p.port_nm,
                    b.berth_nm,
                    vpc.depart_dt,
                    vba.trade_lane_cd || vba.voyage_no as COMMERCIAL_VOYAGE,
                    vmv.military_voyage_no as MILITARY_VOYAGE,
                    mv.suffix,
					vba.trade_lane_cd
                    from t_vessel_berth_activity vba 
                    inner join t_vessel_port_call vpc on vba.vessel_port_call_id = vpc.vessel_port_call_id
                    inner join r_port p on p.port_cd = vpc.port_cd
                    inner join r_berth b on b.berth_cd = vpc.berth_cd
                    inner join t_vessel_route vr on vr.vessel_route_id = vpc.vessel_route_id
                    inner join r_vessel v on v.vessel_cd = vr.vessel_cd
                    left outer join t_vessel_military_voyage vmv on vmv.vessel_berth_activity_id = vba.vessel_berth_activity_id
                    left outer join t_military_voyage mv on mv.military_voyage_no = vmv.military_voyage_no
                    where vba.trade_lane_cd in ('W4','E4','W5','W6','E6','E5','E7','W7')
                    and vba.berth_activity_cd = 'L'

                    [WHERE]

                    order by vpc.depart_dt
                ";
            }

        }

        public void Run(AvssMilitaryParams p)
        {
            StringBuilder Where = new StringBuilder();

            if (p.PortCd.IsNotNull())
                Where.AppendFormat(" and p.port_cd = '{0}'", p.PortCd);

            if (p.BerthCd.IsNotNull())
                Where.AppendFormat(" and b.berth_cd = '{0}'", p.BerthCd);

            if (p.VesselCd.IsNotNull())
                Where.AppendFormat(" and v.vessel_cd = '{0}'", p.VesselCd);

            if (p.DateFrom.IsNotNull())
                Where.AppendFormat(" and vpc.depart_dt >= '{0:dd-MMM-yy}'", p.DateFrom);

            if (p.DateTo.IsNotNull())
                Where.AppendFormat(" and vpc.depart_dt <= '{0:dd-MMM-yy}'", p.DateTo);

            Async = false;

            RunWhere(Where.ToString());
        }

    }
}
