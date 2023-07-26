using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS2010.ArcSys.Business
{
    public class AvssMilitaryParams
    {
        public string PortCd { get; set; }
        public string BerthCd { get; set; }
        public string VesselCd { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
    }
}
