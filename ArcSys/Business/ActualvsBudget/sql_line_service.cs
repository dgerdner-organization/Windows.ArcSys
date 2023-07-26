using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
    public class sql_line_service : sql_base
    {
        protected override string connection_key
        {
            get { return "LINE"; }
        }

        protected override string base_query
        {
            get
            {
                return @"
                    Select  
                    s.svsrvcode as SERVICE_CD,
                    s.svbez as SERVICE_DSC 
                    from dba.service s
                    where s.firma = 'ARC'
                    order by s.svbez
                    ";            
            }
        }

        public new void Run()
        {
            Async = false;

            RunWhere();
        }

    }
}
