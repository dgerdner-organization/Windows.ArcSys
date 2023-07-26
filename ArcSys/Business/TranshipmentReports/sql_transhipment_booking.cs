using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
    public class sql_transhipment_booking : sql_base
    {
        protected override string connection_key
        {
            get { return "SAGAEDI"; }
        }

        protected override string base_query
        {
            get {

                return @"

                    -- Booking Version

                    SELECT

                    bh.v101_vessel_cd AS VESSEL_CD,
                    bh.v102_vessel_nm AS VESSEL_NM,
                    bh.v104_voyage_no AS VOYAGE_NO,
                    bh.v105_carrier_cd AS CARRIER,
                    bh.r403_por_port_cd AS POR,
                    bh.r403_pol_port_cd AS POL,
                    bh.r403_pod_port_cd AS POD,
                    bh.r403_pfd_port_cd AS PFD,

                    bh.dtm_pol AS SAIL_DT,
                    bh.b102_bkg_no AS BOOKING,
                    bi.l013_item_qty AS QTY,
                    bi.l004_weight AS WEIGHT,
                    bi.l006_volume AS VOLUME,
                    bi.l008_piece_count AS PIECE_COUNT,
                    bi.l502_item_dsc AS ITEM_DSC,
                    bi.l503_commodity_cd AS COMMODITY_CD,
                    bi.l401_length AS LENGTH_NUM,
                    bi.l402_width AS WIDTH_NUM,
                    bi.l403_height AS HEIGHT_NUM,
                    bi.l009_pkg_type_cd AS PACKAGE_TYPE,

                    br.l102_rate_amt AS RATE_AMT,
                    br.l104_charge_amt AS CHARGE_AMT,
                    br.l105_advance_amt AS ADVANCE_AMT,
                    br.l106_prepaid_amt AS PREPAID_AMT,
                    br.l121_tot_amt AS TOTAL_AMT

                    FROM
                    t_booking_hdr bh
                    INNER JOIN t_booking_item bi ON bi.b102_bkg_no = bh.b102_bkg_no
                    INNER JOIN t_booking_rate br ON br.b102_bkg_no = bh.b102_bkg_no AND br.lx01_item_nbr = bi.lx01_item_nbr

                    WHERE
                    (
                    (bh.r403_por_port_cd != bh.r403_pol_port_cd) OR (bh.r403_pod_port_cd != bh.r403_pfd_port_cd)
                    )
                    
                    [WHERE]

                    ORDER BY
                    bh.dtm_pol desc

                ";
            
            
            }
        }
         
        public void Run(modTranshipmentReport tr)
        {
            StringBuilder Where = new StringBuilder();

            if (tr.sailDateFrom.IsNotNull())
                Where.AppendFormat(" and bh.dtm_pol  >= '{0:dd-MMM-yy}'", tr.sailDateFrom);

            if (tr.sailDateTo.IsNotNull())
                Where.AppendFormat(" and bh.dtm_pol  <= '{0:dd-MMM-yy}'", tr.sailDateTo);

            if (tr.vessels.IsNotNull())
                Where.AppendFormat(" and bh.v101_vessel_cd in ({0})", tr.vessels.ToUpper());

            if (tr.voyage.IsNotNull())
                Where.AppendFormat(" and bh.v104_voyage_no like '%{0}%'", tr.voyage);

            if (tr.booking.IsNotNull())
                Where.AppendFormat(" and bh.b102_bkg_no = '{0}'", tr.booking);

            Async = true;

            RunWhere(Where.ToString());
        }
    }
}
