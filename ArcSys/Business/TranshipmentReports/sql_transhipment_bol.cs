using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
    public class sql_transhipment_bol : sql_base
    {
        protected override string connection_key
        {
            get { return "SAGAEDI"; }
        }

        protected override string base_query
        {
            get {

                return @"

                    -- Bill of Lading Version

                    SELECT

                    bl.v101_vessel_cd AS VESSEL_CD,
                    bl.v102_vessel_nm AS VESSEL_NM,
                    bl.v104_voyage_no AS VOYAGE,
                    bl.v105_carrier_cd AS CARRIER,
                    bl.r403_por_port_cd AS POR,
                    bl.r403_pol_port_cd AS POL,
                    bl.r403_pod_port_cd AS POD,
                    bl.r403_pfd_port_cd AS PFD,

                    bl.dtm_pol AS SAIL_DT,
                    bli.b302_bl_no AS BOL,
                    bli.l004_weight AS WEIGHT_NUM,
                    bli.l006_volume AS VOLUME_NUM,
                    bli.l008_piece_count AS PIECE_CNT,
                    bli.l502_item_dsc AS ITEM_DSC,
                    bli.l503_commodity_cd AS COMMODITY_CD,
                    bli.l009_pkg_type_cd AS PACKAGE_TYPE,
                    bli.l506_marks_and_nbr_dsc AS TCN,


                    blr.l102_rate_amt * 1 AS RATE_AMT,
                    blr.l104_charge_amt * 1 AS CHARGE_AMT,
                    blr.l105_advance_amt * 1 AS ADVANCE_AMT,
                    blr.l106_prepaid_amt * 1 AS PREPAID_AMT,
                    blr.l121_tot_amt * 1 AS TOTAL_AMT

                    FROM
                    t_bl_hdr bl
                    INNER JOIN t_bl_item bli ON bli.b302_bl_no = bl.b302_bl_no
                    INNER JOIN t_bl_rate blr ON blr.b302_bl_no = bli.b302_bl_no AND blr.lx01_item_nbr = bli.lx01_item_nbr

                    WHERE
                    (
                    (bl.r403_por_port_cd != bl.r403_pol_port_cd) OR (bl.r403_pod_port_cd != bl.r403_pfd_port_cd)
                    )

                    [WHERE]

                    ORDER BY 

                    bl.dtm_pol

                ";
            
            }
        }

        public void Run(modTranshipmentReport tr)
        {
            StringBuilder Where = new StringBuilder();

            if (tr.sailDateFrom.IsNotNull())
                Where.AppendFormat(" and bl.dtm_pol  >= '{0:dd-MMM-yy}'", tr.sailDateFrom);

            if (tr.sailDateTo.IsNotNull())
                Where.AppendFormat(" and bl.dtm_pol <= '{0:dd-MMM-yy}'", tr.sailDateTo);

            if (tr.vessels.IsNotNull())
                Where.AppendFormat(" and bl.v101_vessel_cd in ({0})", tr.vessels.ToUpper());

            if (tr.voyage.IsNotNull())
                Where.AppendFormat(" and bl.v104_voyage_no like '%{0}%'", tr.voyage);

            if (tr.bol.IsNotNull())
                Where.AppendFormat(" and bli.b302_bl_no = '{0}'", tr.bol);

            Async = true;

            RunWhere(Where.ToString());
        }

    }
}
