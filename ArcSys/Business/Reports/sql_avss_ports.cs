using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
    public class sql_avss_ports : sql_base
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
                    Select distinct p.port_nm, p.port_cd 
                    from r_port p
                    inner join t_vessel_port_call vpc on vpc.port_cd = p.port_cd
                    inner join t_vessel_berth_activity vba on vba.vessel_port_call_id = vpc.vessel_port_call_id
                    where 
                    vba.trade_lane_cd in ('W4','E4')
                    and vba.berth_activity_cd = 'L'
                    order by p.port_nm";
            }
        }

        public void Run()
        {
            Async = false;

            RunWhere();
        }

    }
}
