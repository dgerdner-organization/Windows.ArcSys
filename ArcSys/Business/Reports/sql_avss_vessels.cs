using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
    public class sql_avss_vessels : sql_base
    {
        protected override string connection_key
        {
            get { return "AVSS"; }
        }

        protected override string base_query
        {
            get { return @"
                    Select distinct v.vessel_nm, v.vessel_cd 
                    from r_vessel v
                    inner join t_vessel_route vr on vr.vessel_cd = v.vessel_cd
                    inner join t_vessel_port_call vpc on vpc.vessel_route_id = vr.vessel_route_id
                    inner join t_vessel_berth_activity vba on vba.vessel_port_call_id = vpc.vessel_port_call_id
                    where 
                    vba.trade_lane_cd in ('W4','E4')
                    and vba.berth_activity_cd = 'L'
                    order by v.vessel_nm"; 
            }
        }

        public void Run()
        {
            Async = false;

            RunWhere();
        }

    }
}
