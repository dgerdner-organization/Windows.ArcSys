using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS2010.ArcSys.Business
{
    public partial class ClsOceanExportQueue
    {
        public static bool InsertWWL301(string sBooking, string sActivityCd, string sPOL, ref string sMsg)
        {
            //
            // Inserts a row for 301 Exports to WWL
            //  Only create a row if the POL matches our configuraton table
            //
            ClsOceanExportQueue q = new ClsOceanExportQueue();
            q.Activity_Cd = sActivityCd.ToUpper();
            q.Document_No_1 = sBooking;
            q.Document_Type = "301";
            q.Trading_Partner_Cd = "TOPS";
            q.Processed_Flg = "N";
            bool bConfig = ClsConfigurationTable.CheckConfig("WWL301", sPOL, ref sMsg);
            if (!bConfig)
            {
                return false;
            }
            ClsVwArcBookingHeader b = ClsVwArcBookingHeader.GetByBookingNo(sBooking);
            if (b == null)
            {
                sMsg = "Cannot find booking " + sBooking + " in OCEAN";
                return false;
            }
            if (!b.IsActive)
            {
                sMsg = "Only bookings in Confirm status can be sent to WWL";
                return false;
            }
            q.Insert();
            return true;
        }
        public static bool InsertWWL310Exp(string sBol, string sActivityCd, string sPOD, ref string sMsg)
        {
            //
            // Inserts a row for 310 Exports to WWL
            //  Only create a row if the POD matches our configuraton table
            //
            ClsOceanExportQueue q = new ClsOceanExportQueue();
            q.Activity_Cd = sActivityCd.ToUpper();
            q.Document_No_1 = sBol;
            q.Document_Type = "310";
            q.Trading_Partner_Cd = "TOPS";
            q.Processed_Flg = "N";
            bool bConfig = ClsConfigurationTable.CheckConfig("WWL310", sPOD, ref sMsg);
            if (!bConfig)
            {
                return false;
            }
            ClsVwArcBolHeader bol = ClsVwArcBolHeader.GetByBolNo(sBol);
            if (bol == null)
            {
                sMsg = "Cannot find this BOL in Ocean";
                return false;
            }
            if (!bol.IsActive)
            {
                sMsg = "You can only send Bills of Lading that are in Active status";
                return false;
            }
            q.Insert();
            return true;
        }
        public static bool InsertWWL315Exp(string sBol, string sActivityCd, string sPOD, ref string sMsg)
        {
            //
            // Inserts a row for 315 Exports to WWL
            //  Only create a row if the POD matches our configuraton table
            //
            ClsOceanExportQueue q = new ClsOceanExportQueue();
            q.Activity_Cd = sActivityCd.ToUpper();
            q.Document_No_1 = sBol;
            q.Document_Type = "315";
            q.Trading_Partner_Cd = "TOPS";
            q.Processed_Flg = "N";
            bool bConfig = ClsConfigurationTable.CheckConfig("WWL315", sPOD, ref sMsg);
            if (bConfig)
            {
                q.Insert();
                return true;
            }
            return false;
        }
    }
}
