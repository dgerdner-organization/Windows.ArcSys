using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CS2010.Common;
using System.Configuration;

namespace CS2010.ArcSys.Business.ConveyanceTracking
{
    public class ClsCargoDetail
    {
        public delegate void FileSearchHandler(object o, FileSearchArgs fsa);
        public event FileSearchHandler FileSearch;
    
        #region Connection Props

        private ClsConnection connAcms
        {
            get
            {
                return ClsConMgr.Manager["ACMS"];
            }
        }

        public ClsConnection connArofp
        {
            get
            {
                return ClsConMgr.Manager["ArcSys"];
            }
        }

        private ClsConnection connLine
        {
            get
            {
                if (ClsConMgr.Manager["LINE"] == null)
                {
                    ConnectionStringSettings cns = ConfigurationManager.ConnectionStrings["LINE"];

                    ClsConMgr.Manager.AddConnection(
                        "LINE",
                        cns.ProviderName,
                        cns.ConnectionString,
                        "line-edi-user",
                        "dg20100512",
                        null);
                }

                return ClsConMgr.Manager["LINE"];
            }
        }

    	#endregion
        
        #region Basic Detail
		
        public DataTable getTcnLine(string tcn)
        {
            string sql = string.Empty;
            DataTable dt;
            tcn = tcn.Trim();

            #region BreakBulk

            sql = string.Format(@"SELECT  dba.bu14_itemdetail.bu14trackingref as tcn,
                    bu14lfnr as item_no,
                    dba.bu1_kopf.bu1status2 as booking_status,
                    dba.bu1_kopf.bu1kdnr as customer_no,
                    dba.bu1_kopf.bu1kdmtc as match_cd,
                    dba.kunde.kdname1 as customer_nm,
                    dba.bu1_kopf.bu1loesch as deleted_flg,
                    dba.bu1_kopf.bu1bunr as booking_no,
                    dba.bu1_kopf.bu1ediref as pcfn,
                    dba.bu1_kopf.bu1kdref as user_pcfn,
                    NULL AS bol, 
                    dba.bu1_kopf.bu1voyage as voyage_no,
                    dba.bu1_kopf.bu1vessel as vessel,
                    dba.bu1_kopf.bu1plorcde as plor,
                    dba.bu1_kopf.bu1polcde as pol,
                    dba.bu1_kopf.bu1podcde as pod,
                    dba.bu1_kopf.bu1plodcde as plod,
                    dba.bu1_kopf.bu1vskond as move_type,
                    'BREAKBULK' as cargo_type,
                    dba.bu1_kopf.bu1polbez as pol_dsc,
                    dba.bu1_kopf.bu1podbez as pod_dsc,
                    bu1plofrec as plor_dsc,
                    bu1plofdel as plod_dsc,
                    dba.bu3_item.bu3kopcde as kind_pkg,
                    dba.bu3_item.bu3comcde as commodity_cd,
                    '' as make,
                    '' as model,
                   '' as mfr_ref,
                    dba.bu3_item.bu3desofg as dogs,
                    CAST(bu14length AS numeric(13, 4)) AS length, 
                    cast(dba.bu14_itemdetail.bu14height as numeric(13,4)) as height,
                    cast(isnull(dba.bu14_itemdetail.bu14width, 0) as numeric (13,4)) as width,
                    cast(isnull(dba.bu14_itemdetail.bu14weight, 0)as numeric(13,4)) as weight,
                    '' as container_no,
                    '' as seal1, '' as seal2, '' as seal3,
                    0 as container_wt, 
                    'BREAKBULK' + CAST(dba.bu14_itemdetail.bu14_itemdetail_id AS varchar(10)) as cargo_key,
                    convert(varchar(20),dba.bu14_itemdetail.bu14cargorecvdate, 106)AS cargo_rcvd_dt
            FROM    dba.bu1_kopf INNER JOIN
                        dba.bu3_item ON dba.bu1_kopf.bu1bumanr = dba.bu3_item.bu3bumanr INNER JOIN
                        dba.bu14_itemdetail ON dba.bu3_item.bu3bumanr = dba.bu14_itemdetail.bu14manr AND 
                        dba.bu3_item.bu3bulfnr = dba.bu14_itemdetail.bu14lfnr 
                    INNER JOIN dba.kunde on dba.kunde.kdkdnr = dba.bu1_kopf.bu1kdnr AND dba.kunde.firma = dba.bu1_kopf.firma
             WHERE (dba.bu1_kopf.bu1loesch = 'N' ) 
              and (dba.bu1_kopf.bu1voyage like '%' )
              and (dba.bu1_kopf.bu1bunr like '%' )
               and dba.bu14_itemdetail.bu14trackingref = '{0}'", tcn);

            dt = connLine.GetDataTable(sql);
            if (dt.IsNotNull()) return dt;

            #endregion

            #region Container

            sql = string.Format(@"
			SELECT     dba.car_head.CR1_VIN as tcn, 
                dba.car_head.cr1_buitem as item_no,
                dba.bu1_kopf.bu1status2 as booking_status,
                dba.bu1_kopf.bu1kdnr as customer_no,
                dba.bu1_kopf.bu1kdmtc as match_cd,
                dba.kunde.kdname1 as customer_nm,
				dba.bu1_kopf.bu1loesch as deleted_flg, 
				dba.bu1_kopf.bu1bunr as booking_no, 
				dba.bu1_kopf.bu1ediref as pcfn, 
				dba.bu1_kopf.bu1kdref as user_pcfn, 
				null as bol, 
				dba.car_head.cr1_voyage as voyage_no, 
				dba.car_head.cr1_vessel as vessel, 
                    dba.bu1_kopf.bu1plorcde as plor,
                    dba.bu1_kopf.bu1polcde as pol,
                    dba.bu1_kopf.bu1podcde as pod,
                    dba.bu1_kopf.bu1plodcde as plod,
    			dba.bu1_kopf.bu1vskond as move_type,
                'RORO' as cargo_type,
                dba.bu1_kopf.bu1polbez as pol_dsc, 
                dba.bu1_kopf.bu1podbez as pod_dsc,
                bu1plofrec as plor_dsc, 
                bu1plofdel as plod_dsc,
                ' ' as kind_pkg,
                ' ' as commodity_cd,
				dba.car_head.cr1_manufacturer as make, 
				dba.car_head.cr1_model as model, 
				dba.car_head.cr1_manufactur_ref as mfr_ref, 
                dba.car_head.cr1_modelname as dogs,
				cast(dba.car_head.cr1_length as numeric(13,4)) as length, 
				cast(dba.car_head.cr1_height as numeric(13,4)) as height, 
                cast(dba.car_head.cr1_width as numeric(13,4)) as width,
				cast(dba.car_head.cr1_weight as numeric(13,4)) as weight, 
                '' as container_no,
                '' as seal1, '' as seal2, '' as seal3,
                0 as container_wt,
                'RORO' + CAST(dba.car_head.cr1_manr AS varchar(10)) as cargo_key,
                convert(varchar(20),dba.car_head.cr1_cargorecvdate,106) AS cargo_rcvd_dt
			FROM  dba.car_head LEFT OUTER JOIN
				  dba.bu1_kopf ON dba.car_head.cr1_bumanr = dba.bu1_kopf.bu1bumanr 
                  INNER JOIN dba.kunde on dba.kunde.kdkdnr = dba.bu1_kopf.bu1kdnr AND dba.kunde.firma = dba.bu1_kopf.firma
             WHERE (dba.bu1_kopf.bu1loesch = 'N' ) 
              and (dba.bu1_kopf.bu1voyage like '%' )
              and (dba.bu1_kopf.bu1bunr like '%' )
               and dba.car_head.cr1_vin = '{0}'", tcn);

            dt = connLine.GetDataTable(sql);
            if (dt.IsNotNull()) return dt;

            #endregion

            #region Roro

            sql = string.Format(@"
				SELECT 
					dba.bu4_cont.bu4remgte as tcn,
                    dba.bu4_cont.bu4bulfnr as item_no,
                    dba.bu1_kopf.bu1status2 as booking_status,
                    dba.bu1_kopf.bu1kdnr as customer_no,
                    dba.bu1_kopf.bu1kdmtc as match_cd,
                    dba.kunde.kdname1 as customer_nm,
                    dba.bu1_kopf.bu1loesch as deleted_flg,
                    dba.bu1_kopf.bu1bunr as booking_no,
                    dba.bu1_kopf.bu1ediref as pcfn,
                    dba.bu1_kopf.bu1kdref as user_pcfn,
                    NULL AS bol, 
                    dba.bu1_kopf.bu1voyage as voyage_no,
                    dba.bu1_kopf.bu1vessel as vessel,
                    dba.bu1_kopf.bu1plorcde as plor,
                    dba.bu1_kopf.bu1polcde as pol,
                    dba.bu1_kopf.bu1podcde as pod,
                    dba.bu1_kopf.bu1plodcde as plod,
                    dba.bu1_kopf.bu1vskond as move_type,
                    'CONTAINER' as cargo_type,
                    dba.bu1_kopf.bu1polbez as pol_dsc,
                    dba.bu1_kopf.bu1podbez as pod_dsc,
                    bu1plofrec as plor_dsc,
                    bu1plofdel as plod_dsc,
                    bu4kopcde as kind_pkg, 
                    bu4comcde as commodity_cd, 
                    '' as make,
                    '' as model,
                    '' as mfr_ref,
                    bu4kopbez as dogs, 
                    isnull(cast(dba.containerart.cttcontsz as numeric(14,3)),0) as length, 
                    isnull(cast(dba.containerart.cttconthg as numeric(14,3)),0) as height, 
                    isnull(cast(dba.containerart.cttcontwd as numeric(14,3)),0) as width,
                    cast(bu4unitgrw as numeric(13,4)) as weight,
                    bu4contnr as container_no,
                    bu4seal1 as seal1, bu4seal2 as seal2, bu4seal3 as seal3,
                    0 as container_wt,
                    'CONT' + CAST(bu4bumanr AS varchar(10)) + ' ' + CAST(bu4bulfnr AS varchar(5)) + ' ' + CAST(bu4cnlfnr AS varchar(5)) AS cargo_key,
                    convert(varchar(20),dba.bu4_cont.bu4cargorecvdate,106) AS cargo_rcvd_dt
					FROM dba.bu4_cont INNER JOIN
						dba.bu1_kopf ON dba.bu4_cont.bu4bumanr = dba.bu1_kopf.bu1bumanr INNER JOIN
                        dba.containerart ON dba.bu4_cont.firma = dba.containerart.firma AND 
                          dba.bu4_cont.bu4contart = dba.containerart.cttcontart 
                        INNER JOIN dba.kunde on dba.kunde.kdkdnr = dba.bu1_kopf.bu1kdnr AND dba.kunde.firma = dba.bu1_kopf.firma
             WHERE (dba.bu1_kopf.bu1loesch = 'N' ) 
              and (dba.bu1_kopf.bu1voyage like '%' )
              and (dba.bu1_kopf.bu1bunr like '%' )
               and dba.bu4_cont.bu4remgte = '{0}'", tcn);

            dt = connLine.GetDataTable(sql);
            if (dt.IsNotNull()) return dt;

            #endregion

            return null;
        }

        public DataTable getTcnAcms(string tcn)
        {
            string sql = string.Format(@"SELECT bu.*,
                'ITV' as c_click,   
                c.model_code,
                f_voydoc(bu.voyage_no) as voydoc,
                (select activity_code from t_booking_itv where activity_id = (select max(activity_id) 
                from t_booking_itv where booking_id = bu.booking_id and 
                                booking_sub = bu.booking_id_sub and item_no = bu.item_no)) 
                    as last_activity,   
                sb.stena_id,
                f_voyage_dt(bu.voyage_no, bu.poe_location_cd, bu.poe_terminal_cd, 'L') as stena_depart_dt, 
                f_voyage_dt(bu.voyage_no, bu.poe_location_cd, bu.poe_terminal_cd, 'L') as est_depart_dt, 
                f_voyage_dt(bu.voyage_no, bu.pod_location_cd, bu.pod_terminal_cd, 'D') as est_arrive_dt, 
                sr.route_cd as stena_route_cd,
                sb.trailer_no,
                sb.sailing_dt,
                rc.rev_dsc,
                nvl(pol.other1_cd, l.other1_cd) as pol_milstamp,
                nvl(pod.other1_cd, d.other1_cd) as pod_milstamp
            FROM T_BOOKING_UNIT bu
                left outer join r_cargo_code c on c.cargo_id = bu.cargo_id
            left outer join r_commodity_dsc cd on bu.commodity_cd = cd.commodity_cd
                    left outer join r_revenue_code rc on bu.rev_cd = rc.rev_cd
            left outer join v_stena_booking sb on sb.serial_no = bu.tcn
            left outer join r_location_terminal pol on pol.terminal_cd = bu.poe_terminal_cd
            left outer join r_location l on l.location_cd = pol.location_cd
            left outer join r_location_terminal pod on pod.terminal_cd = bu.pod_terminal_cd
            left outer join r_location d on d.location_cd = pod.location_cd
            left outer join r_stena_route sr on 
                sr.pol_location_cd = bu.poe_location_cd and sr.pod_location_cd = bu.pod_location_cd
            where bu.tcn = '{0}'", tcn); 

            return connAcms.GetDataTable(sql);
        }

        public DataTable getTcnArofp(string tcn)
        {
            string sql = string.Format(@"select * from t_booking_line b
                 inner join t_cargo_line c
                    on b.booking_line_id = c.booking_line_id 
                 where 1 = 1 and serial_no like '{0}'",tcn);

            return connArofp.GetDataTable(sql);
        }

	    #endregion

        #region SDDC

        public bool sddcCheckRawFolder(string tcn)
        {
            string rawFolder = @"\\GUARDIANEDGE\c$\ACMS\edi\data\sddc_in\RawFiles\";
            string archive = @"\\GUARDIANEDGE\c$\ACMS\edi\data\sddc_in\300Files\Archive\";

            if (SearchForText(rawFolder, tcn)) return true;
            if (SearchForText(archive, tcn)) return true;
            return false;

        }
        public bool sddcCheck300InFolder(string tcn)
        {
            string folder = @"\\GUARDIANEDGE\c$\ACMS\edi\data\sddc_in\300Files\";
            string archive = @"\\GUARDIANEDGE\c$\ACMS\edi\data\sddc_in\300Files\Archive\";

            if (SearchForText(folder, tcn)) return true;
            if (SearchForText(archive, tcn)) return true;
            return false;
        }


        #endregion

        #region IAL
        
        #endregion

        #region Charleston HHG
        
        #endregion

        #region NAC
        
        #endregion

        #region CAT
        
        #endregion

        #region Commercial ITV
        
        #endregion


        private bool SearchForText(string searchPath, string searchText)
        {
            string[] filesToSearch = System.IO.Directory.GetFiles(searchPath);
            System.IO.StreamReader sr;
            string line;
            FileSearchArgs fsa = new FileSearchArgs();
            
            foreach (string searchFile in filesToSearch)
            {
                fsa = new FileSearchArgs() { searchFolderNm = searchPath, searchFileNm = searchFile };
                sr = new System.IO.StreamReader(searchFile);
                while (!sr.EndOfStream)
                {
                    fsa.lineNumber++;
                    line = sr.ReadLine();
                    if (line.Contains(searchText))
                    {
                        fsa.found = fsa.finished = true;
                    }
                    FileSearch(this, fsa);
                    if (fsa.finished) return true;
                }
            }
            fsa.finished = true;
            return false;
        }
    }

    public class FileSearchArgs
    {
        public bool finished { get; set; }
        public bool found {get; set; }
        public int lineNumber { get; set;} 
        public string searchFileNm { get; set; }
        public string searchFolderNm { get; set; }

        public FileSearchArgs()
        {
            finished = false;
            found = false;
            lineNumber = 0;
            searchFileNm = string.Empty;
            searchFolderNm = string.Empty;
        }
    }

}
