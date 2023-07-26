using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS2010.ArcSys.Business
{
    public partial class ClsRecall
    {
        public bool Validate(out string msg)
        {
            msg = string.Empty;

            if ((this.Vehicle_Year < 1980) || (this.Vehicle_Year > DateTime.Now.Year))
            {
                msg = string.Format("Vehicle Year must be between the years 1980-{0}", DateTime.Now.Year);
                return false;
            }

            if (this.Vehicle_Make.IsNull())
            {
                msg = "Vehicle Make is not valid.";
                return false;
            }

            if (this.Vehicle_Model.IsNull())
            {
                msg = "Vehicle Model is not valid.";
                return false;
            }

            return true;

        }

    }
}
