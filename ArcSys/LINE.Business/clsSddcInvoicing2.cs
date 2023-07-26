using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CS2010.Common;
using System.Data;
using System.Data.Common;

namespace CS2010.LINE.Business
{
    public class clsSddcInvoicing2
    {
        #region Connection Manager

        protected static ClsConnection Connection
        {
            get
            {
                string sConnect = "packet size=4096;user id=line-edi-user;password=dg20100512;data source=SQLCLUSTER;persist security info=True;initial catalog=Line_cs;";
                ClsConnection line = new ClsConnection(sConnect, "System.Data.SqlClient");
                return line;
            }
        }

        #endregion		// #region Connection Manager

        public DataTable GetSDDCInvoicing2(string pcfn)
        {
            try
            {
                string sql = @"
                    Select  
	                    bl.bl1ediref as PCFN,
                        bl.cargo_id as tcn,
                        ss.sst_zuabcde as charge_cd,
                        ss.sst_per as per,
                        ss.sst_stat_amount as rate_amt,
	                    bl.bu1bunr as booking_no, 
	                    bl.bl1blnr as bol, 
	                    bl.cargo_type as cargo_type,
	                    bl.bl1podberth as pod_berth,
	                    bl.bl1polberth as pol_berth,
	                    bl.bl1vessel as vessel,
	                    bl.bl1voyage as voyage,
	                    ss.sst_sstposno as item_no, 
	                    ss.sst_kopcde as cargo_type,
	                    ss.sst_nrofpa as quantity,
	                    bl.cargo_length as length,
	                    bl.cargo_widht as width, 
	                    bl.cargo_height as height,
	                    bl.cargo_weight as weight,
	                    bl.unitmeas40 as cubic_meters_40,
	                    bl.unitmeascbm as cubic_meters,
	                    bl.bl1tariffcat1 as tariff_cd,
	                    
	                    
	                    ss.sst_rate as piece_rate_amt,
	                    ss.sst_grw,
	                    ss.sst_meas,
	                    ss.sst_frt,
	                    ss.sst_ntw,
	                    ss.sst_length,
	                    ss.sst_width,
	                    ss.sst_height,
	                    ss.sst_square,
	                    ss.sst_zuabcde,
	                    ss.sst_pos_amount,
	                    ss.sst_stat_amount,
	                    ss.sst_comcde as commodity_cd,
	                    ss.sst_unitmeas,
	                    ss.sst_unitmeas40,
	                    ss.sst_tariffcat1,
	                    ss.sst_rate,
	                    ss.sst_stat_amount2,
                        bl.*,
                        ss.*

                    from dba.vw_cargo_details_bl bl
                    inner join dba.v_sales_statistic_list ss on ss.sst_sstnr = bl.bu1bunr 

                    where 
	                    bl.firma = 'ARC'
	                    and bl.bl1ediref = @PCFN 

                    order by 
	                    bl.bl1ediref, 
	                    bl.bu1bunr, 
	                    ss.sst_sstposno,
	                    bl.cargo_id

                ";

                List<DbParameter> p = new List<DbParameter>();

                p.Add (Connection.GetParameter("@PCFN",pcfn));

                return Connection.GetDataTable(sql,p.ToArray());

            }
            catch (Exception ex)
            {
                ClsErrorHandler.LogException(ex);
                return null;
            }
        }

        public DataTable GetSDDCInvoicing(string voyage)
        {
            try
            {

                string sql = @"
                    select 
                    bl1voyage as voyage,
                    bl1vessel as vessel,
                    rhetseta as sail_dt,
                    bl1ediref as pcfn,
                    bu1bunr as booking_no,
                    bl1blnr as bol,
                    cargo_id as tcn,
                    bl1plorcde as plor,
                    bl1polcde as pol,
                    bl1podcde as pod,
                    bl1ploccde as plod,
                    description_of_goods as 'desc',
                    commodity_code as commodity_cd,
                    quantity as qty_or_unit,
                    ROUND(cargo_weight,0) as wt,
                    cargo_length as l,
                    cargo_widht as w,
                    cargo_height as h,
                    bl1vskond as vsta,
                    '' as revenue_cd,
                    det.kunde_fullname as customer_nm,
                    bl1voyage + bl1ediref as invoice_no,
                    ves.vsname as vessel_full_nm,
                    rhetseta as formatted_sail_dt,

                    case 
	                    when CHARINDEX('HEAVY',description_of_goods) > 1 then 'HEAVY'
	                    when CHARINDEX('LIGHT',description_of_goods) > 1 then 'LIGHT'
	                    when CHARINDEX('HELICOPTER',description_of_goods) > 1 then 'HELICOPTER'
	                    when CHARINDEX('BREAKBULK',description_of_goods) > 1 then 'GENERAL'
	                    when CHARINDEX('20',description_of_goods) > 1 then '20 CONTAINER'
	                    when CHARINDEX('40',description_of_goods) > 1 then '40 CONTAINER'
	                    when CHARINDEX('BREAKBULK',description_of_goods) > 1 then 'GENERAL'
	                    else 'NA'
                    end as category,

                    ROUND((det.cargo_weight * 2.2046226),0) as wt_in_pounds,

                    CEILING
                    (
                        (
                            (
                                (cargo_length * .3937007) * (cargo_widht * .3937007) * (cargo_height * .3937007)
                            ) 
                            / 1728
                        )
                    ) as cubed,

                    ROUND( 
						(
							(CEILING
								(
									(
										(
											(cargo_length * .3937007) * (cargo_widht * .3937007) * (cargo_height * .3937007)
										) 
										/ 1728
									)
								)
							)	 
						/ 40
						)
                    ,3) as mtons,



                    ROUND(
                    (

                    (
                    (
                    (cargo_length * .3937007) * 
                    (cargo_widht * .3937007) * 
                    (cargo_height * .3937007)
                    ) 
                    / 1728
                    ) / 40),3) as mtons2,


                    round((cargo_length * .3937007),0) as l_in_inches,
                    round((cargo_widht * .3937007),0) as w_in_inches,
                    round((cargo_height * .3937007),0) as h_in_inches,
                    (rhetseta + 24) as arrival_dt,
                    '' as invoice_dt

                    from dba.vw_cargo_details_bl as det
                    inner join dba.schiff as ves on (ves.vscode = det.bl1vessel and ves.firma = det.firma)

                    where 1=1
                    and det.firma = 'ARC'
                    and (((det.bl1voyage = '[VOYAGE]'))) 
                    and (det.kunde_fullname like 'SURFACE%')

                    order by bl1voyage, bu1bunr, cargo_id

                    ";

                sql = sql.Replace("[VOYAGE]", voyage.Trim());

                return Connection.GetDataTable(sql);

            }
            catch (Exception ex)
            {
                ClsErrorHandler.LogException(ex);
                return null;
            }
        }

    }
}
