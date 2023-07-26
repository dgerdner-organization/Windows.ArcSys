using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
    public class sql_moves : sql_base
    {
        protected override string connection_key
        {
            get { return "ArcSys"; }
        }

        /// <summary>
        ///  More to come ...
        /// </summary>
        protected override string base_query
        {
            get
            {
                return @"

                    SELECT 
                        distinct
                        m.*,
                        vm.vendor_move_id,
                        vm.vendor_cd,
                        v.vendor_nm,
                        vm.orig_location_cd,
                        orig.location_dsc AS ORIG_DSC,
                        vm.dest_location_cd,
                        dest.location_dsc AS DEST_DSC,
                        vm.allocated_qty, vm.used_qty, vm.futile_qty,
                        (SELECT COUNT(*) FROM T_CARGO_MOVE CM WHERE CM.VENDOR_MOVE_ID = VM.VENDOR_MOVE_ID AND CM.ACTIVE_FLG = 'Y') AS CARGO_ASSIGNED,
                        (SELECT COUNT(*) FROM T_CONVEYANCE CU WHERE CU.FUTILE_FLG = 'N' AND CU.VENDOR_MOVE_ID = VM.VENDOR_MOVE_ID) AS CONVEYANCES_USED,
                        (SELECT COUNT(*) FROM T_CONVEYANCE CU WHERE CU.FUTILE_FLG = 'Y' AND CU.VENDOR_MOVE_ID = VM.VENDOR_MOVE_ID) AS CONVEYANCES_FUTILE

                    FROM 
                        v_vendor_move vm
                        INNER JOIN t_move m ON m.move_id = vm.move_id
                        INNER JOIN v_vendor v ON v.vendor_cd = vm.vendor_cd
                        INNER JOIN r_location orig ON vm.orig_location_cd = orig.location_cd
                        INNER JOIN r_location dest ON vm.dest_location_cd = dest.location_cd
                        INNER JOIN t_cargo_move cm on (CM.VENDOR_MOVE_ID = VM.VENDOR_MOVE_ID AND CM.ACTIVE_FLG = 'Y')

                    WHERE 1=1
                        [WHERE]

                    ORDER BY 
                        m.create_dt";

            }
        }

        public void Run(string VendorCd, string OriginCd, string DestinationCd, string BookingNo, string SerialNo, string VoyageNo)
        {
            StringBuilder where = new StringBuilder();

            if (VendorCd.IsNotNull())
                where.AppendFormat(" AND vm.vendor_cd = '{0}'", VendorCd);

            if (OriginCd.IsNotNull())
                where.AppendFormat(" AND vm.orig_location_cd = '{0}'", OriginCd);

            if (DestinationCd.IsNotNull())
                where.AppendFormat(" AND vm.dest_location_cd = '{0}'", DestinationCd);

            if (BookingNo.IsNotNull())
                where.AppendFormat(" AND cm.booking_no = '{0}'", BookingNo.Trim());

            if (SerialNo.IsNotNull())
                where.AppendFormat(" AND cm.serial_no = '{0}'", SerialNo.Trim());

            if (VoyageNo.IsNotNull())
                where.AppendFormat(" AND cm.voyage_no = '{0}'", VoyageNo.Trim());

            RunWhere(where.ToString());
        }
    }
}
