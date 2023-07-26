using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS2010.ArcSys.Business
{
    public class ClsGlobalMethods
    {
        public static string SystemForBooking(string sBooking)
        {
            if (sBooking.StartsWith("ARCA"))
                return "LINE";
            return "OCEAN";
        }
    }
}
