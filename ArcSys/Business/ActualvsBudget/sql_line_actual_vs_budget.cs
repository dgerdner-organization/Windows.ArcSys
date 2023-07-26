using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
    public class sql_line_actual_vs_budget : sql_base
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
                SELECT

                CASE

                /* --- SDDC --- */

	                WHEN ss.sst_tariffcat1 IN ('RSUST','RUNIT','RAAL','RTACT') 
		                 AND ss.sst_zuabcde IN ('NTFR')
		                 AND ss.sst_comcde IN ('870300')
	                THEN '01-SDDC-AAL'
	
	                WHEN ss.sst_tariffcat1 IN ('RSUST','RUNIT','RAAL','RTACT') 
		                 AND ss.sst_zuabcde IN ('NTFR')
		                 AND 
		                 ((ss.sst_comcde IN ('LIGHT VEHI','100000','8703000'))
			                or
		                 (ss.sst_comcde IN ('860600','8704','871680','8701','VEH') AND (ss.sst_grw / ss.sst_nrofpa) <= 4.99997))
	                THEN '02-SDDC-LIGHT'

	                WHEN ss.sst_tariffcat1 IN ('RSUST','RUNIT','RAAL','RTACT') 
		                 AND ss.sst_zuabcde IN ('NTFR')
		                 AND 
		                 ((ss.sst_comcde IN ('8702000','HEAVY TRUC','100001','100008','871000','871610','9804000'))
			                or
		                 (ss.sst_comcde IN ('860600','8704','871680','8701','VEH') AND (ss.sst_grw / ss.sst_nrofpa) > 4.99997))
	                THEN '03-SDDC-HEAVY'

	                WHEN ss.sst_tariffcat1 IN ('RSUST','RUNIT','RAAL','RTACT') 
		                 AND ss.sst_zuabcde IN ('NTFR')
		                 AND (ss.sst_comcde IN ('BOLS','100010','BBFORK','BBNFORK','780000','860950','860960','MAFI','100002','100005'))
	                THEN '04-SDDC-NOS'

	                WHEN ss.sst_tariffcat1 IN ('RSUST','RUNIT','RAAL','RTACT') 
		                 AND ss.sst_zuabcde IN ('NTFR')
		                 AND (ss.sst_comcde IN ('100006','880212'))
	                THEN '05-SDDC-HELOS'

	                WHEN ss.sst_tariffcat1 IN ('RSUST','RUNIT','RAAL','RTACT') 
		                 AND ss.sst_zuabcde IN ('NTFR')
		                 AND (ss.sst_comcde IN ('860900','860901','100007','100004','100003','860910','860930','860920','860940','860970','860980') )
	                THEN '06-SDDC-CONTAINERS'

					WHEN ss.sst_tariffcat1 IN ('RSUST','RUNIT','RAAL','RTACT') 
		                 AND ss.sst_zuabcde NOT IN ('NTFR','BAF','SRC','EBS','CCD','CCL','CVS','DITV','EITV','EPYS','ESS','FAF','IHD','IHL','NTFR','OHGT','OWGT','SLC','TRP','TRPD','TRPO','WSH')
		                 AND ss.sst_comcde is null
	                THEN '07-SDDC-PORT AND LINER'

	                WHEN ss.sst_tariffcat1 IN ('RSUST','RUNIT','RAAL','RTACT') 
		                 AND ss.sst_zuabcde IN ('BAF','SRC','EBS')
		                 AND ss.sst_comcde is null
	                THEN '08-SDDC-BAF'
	                
					WHEN ss.sst_tariffcat1 IN ('RSUST','RUNIT','RAAL','RTACT') 
		                 AND ss.sst_zuabcde IN ('CCD','CCL','CVS','DITV','EITV','EPYS','ESS','FAF','IHD','IHL','NTFR','OHGT','OWGT','SLC','TRP','TRPD','TRPO','WSH')
		                 AND ss.sst_comcde is null
	                THEN '09-SDDC-LINEHAUL'

	                /* --- 07-SDDC-PNL --- Do not know where to get */

                /* --- FMS --- */
	
	                WHEN ss.sst_zuabcde IN ('NTFR')
		                 AND ss.sst_tariffcat1 IN ('RSFMS','RFMS','REPO')
		                 AND 
		                 ((ss.sst_comcde IN ('LIGHT VEHI','100000','8703000'))
			                or
		                 (ss.sst_comcde IN ('860600','8704','871680','8701','VEH') AND (ss.sst_grw / ss.sst_nrofpa) <= 4.99997))
	                THEN '10-FMS-LIGHT'
	
	                WHEN ss.sst_zuabcde IN ('NTFR')
		                 AND ss.sst_tariffcat1 IN ('RSFMS','RFMS','REPO')
		                 AND 
		                 ((ss.sst_comcde IN ('8702000','HEAVY TRUC','100001','100008','871000','871610','9804000'))
			                or
		                 (ss.sst_comcde IN ('860600','8704','871680','8701','VEH') AND (ss.sst_grw / ss.sst_nrofpa) > 4.99997))
	                THEN '11-FMS-HEAVY'
	
	                WHEN ss.sst_zuabcde IN ('NTFR')
		                 AND ss.sst_tariffcat1 IN ('RSFMS','RFMS','REPO')
 		                 AND (ss.sst_comcde IN ('BOLS','100010','BBFORK','BBNFORK','780000','860950','860960','MAFI','100002','100005'))
	                THEN '12-FMS-NOS'
	
	                WHEN ss.sst_zuabcde IN ('NTFR')
		                 AND ss.sst_tariffcat1 IN ('RSFMS','RFMS','REPO')
		                 AND (ss.sst_comcde IN ('100006','880212'))
	                THEN '13-FMS-HELOS'
	
	                WHEN ss.sst_zuabcde IN ('NTFR')
		                 AND ss.sst_tariffcat1 IN ('RSFMS','RFMS','REPO')
		                 AND (ss.sst_comcde IN ('860900','860901','100007','100004','100003','860910','860930','860920','860940','860970','860980'))
	                THEN '14-FMS-CONTAINERS'
	
					WHEN ss.sst_tariffcat1 IN ('RSFMS','RFMS','REPO') 
						AND ss.sst_zuabcde NOT IN ('NTFR','BAF','SRC','EBS','CCD','CCL','CVS','DITV','EITV','EPYS','ESS','FAF','IHD','IHL','NTFR','OHGT','OWGT','SLC','TRP','TRPD','TRPO','WSH')
		                 AND ss.sst_comcde is null
	                THEN '15-FMS-PORT AND LINER'

	                WHEN ss.sst_tariffcat1 IN ('RSFMS','RFMS','REPO') 
		                 AND ss.sst_zuabcde IN ('BAF','SRC','EBS')
		                 AND ss.sst_comcde is null
	                THEN '16-FMS-BAF'
	                
					WHEN ss.sst_tariffcat1 IN ('RSFMS','RFMS','REPO') 
		                 AND ss.sst_zuabcde IN ('CCD','CCL','CVS','DITV','EITV','EPYS','ESS','FAF','IHD','IHL','NTFR','OHGT','OWGT','SLC','TRP','TRPD','TRPO','WSH')
		                 AND ss.sst_comcde is null
	                THEN '17-FMS-LINEHAUL'
	
	
                /* --- CONTAINERS --- */	
	
	                WHEN ss.sst_zuabcde IN ('NTFR')
		                 AND ss.sst_tariffcat1 IN ('RSOEF','RMOEF','ROEFI','ROEFC','RMM')
		                 AND 
		                 ((ss.sst_comcde IN ('LIGHT VEHI','100000','8703000'))
			                or
		                 (ss.sst_comcde IN ('860600','8704','871680','8701','VEH') AND (ss.sst_grw / ss.sst_nrofpa) <= 4.99997))
	                THEN '18-OEF-LIGHT'

	                WHEN ss.sst_zuabcde IN ('NTFR')
		                 AND ss.sst_tariffcat1 IN ('RSOEF','RMOEF','ROEFI','ROEFC','RMM')
		                 AND 
		                 ((ss.sst_comcde IN ('8702000','HEAVY TRUC','100001','100008','871000','871610','9804000'))
			                or
		                 (ss.sst_comcde IN ('860600','8704','871680','8701','VEH') AND (ss.sst_grw / ss.sst_nrofpa) > 4.99997))
	                THEN '19-OEF-HEAVY'
	
	                WHEN ss.sst_zuabcde IN ('NTFR')
		                 AND ss.sst_tariffcat1 IN ('RSOEF','RMOEF','ROEFI','ROEFC','RMM')
  		                 AND (ss.sst_comcde IN ('BOLS','100010','BBFORK','BBNFORK','780000','860950','860960','MAFI','100002','100005'))
	                THEN '20-OEF-NOS'
	
	                WHEN ss.sst_zuabcde IN ('NTFR')
		                 AND ss.sst_tariffcat1 IN ('RSOEF','RMOEF','ROEFI','ROEFC','RMM')
		                 AND (ss.sst_comcde IN ('100006','880212'))
	                THEN '21-OEF-HELOS'
	
	                WHEN ss.sst_zuabcde IN ('NTFR')
		                 AND ss.sst_tariffcat1 IN ('RSOEF','RMOEF','ROEFI','ROEFC','RMM')
		                 AND (ss.sst_comcde IN ('860900','860901','100007','100004','100003','860910','860930','860920','860940','860970','860980'))
	                THEN '22-OEF-CONTAINERS'
	
					WHEN ss.sst_tariffcat1 IN ('RSOEF','ROEFI','ROEFC','RMM') 
						AND ss.sst_zuabcde NOT IN ('NTFR','BAF','SRC','EBS','CCD','CCL','CVS','DITV','EITV','EPYS','ESS','FAF','IHD','IHL','NTFR','OHGT','OWGT','SLC','TRP','TRPD','TRPO','WSH')
		                 AND ss.sst_comcde is null
	                THEN '23-OEF-PORT AND LINER'

	                WHEN ss.sst_tariffcat1 IN ('RSOEF','RMOEF','ROEFI','ROEFC','RMM') 
		                 AND ss.sst_zuabcde IN ('BAF','SRC','EBS')
		                 AND ss.sst_comcde is null
	                THEN '24-OEF-BAF'
	                
					WHEN ss.sst_tariffcat1 IN ('RSOEF','RMOEF','ROEFI','ROEFC','RMM') 
		                 AND ss.sst_zuabcde IN ('CCD','CCL','CVS','DITV','EITV','EPYS','ESS','FAF','IHD','IHL','NTFR','OHGT','OWGT','SLC','TRP','TRPD','TRPO','WSH')
		                 AND ss.sst_comcde is null
	                THEN '25-OEF-LINEHAUL'
	
					WHEN ss.sst_tariffcat1 IN ('RMOEF','RMM') 
		                 AND ss.sst_zuabcde NOT IN ('NTFR','BAF','SRC','EBS','CCD','CCL','CVS','DITV','EITV','EPYS','ESS','FAF','IHD','IHL','NTFR','OHGT','OWGT','SLC','TRP','TRPD','TRPO','WSH')
		                 AND ss.sst_comcde is null
	                THEN '26-OEF-AIR'
	
	                /* --- 19-OEF-PNL --- Do not know where to get */
	
                /* --- HOUSE HOLD GOODS --- */	
	
	                WHEN ss.sst_zuabcde IN ('NTFR')
		                 AND ss.sst_tariffcat1 IN ('RMHHG')
		                 /* --- AND ss.sst_comcde is null */
	                THEN '27-HHG-HHG'
	                
	                WHEN ss.sst_tariffcat1 IN ('RMHHG') 
						 AND ss.sst_zuabcde NOT IN ('NTFR','BAF','SRC','EBS','CCD','CCL','CVS','DITV','EITV','EPYS','ESS','FAF','IHD','IHL','NTFR','OHGT','OWGT','SLC','TRP','TRPD','TRPO','WSH')
		                 AND ss.sst_comcde is null
	                THEN '28-HHG-PORT AND LINER'

	                WHEN ss.sst_tariffcat1 IN ('RMHHG') 
		                 AND ss.sst_zuabcde IN ('BAF','SRC','EBS')
		                 AND ss.sst_comcde is null
	                THEN '29-HHG-BAF'
	                
					WHEN ss.sst_tariffcat1 IN ('RMHHG') 
		                 AND ss.sst_zuabcde IN ('CCD','CCL','CVS','DITV','EITV','EPYS','ESS','FAF','IHD','IHL','NTFR','OHGT','OWGT','SLC','TRP','TRPD','TRPO','WSH')
		                 AND ss.sst_comcde is null
	                THEN '30-HHG-LINEHAUL'
	
                /* --- FLAG --- */	
	
	                WHEN ss.sst_zuabcde IN ('NTFR')
		                 AND ss.sst_tariffcat1 IN ('RDOS','ROTHR','RDOSHHG','ROTHER','RCAT','RTSHIP')
		                 AND (ss.sst_comcde IN ('870300','8703000'))
	                THEN '31-FLAG-CARS'

	                WHEN ss.sst_zuabcde IN ('NTFR')
		                 AND ss.sst_tariffcat1 IN ('RDOS','ROTHR','RDOSHHG','ROTHER','RCAT','RTSHIP')
		                 AND (ss.sst_comcde IN ('8702000','LIGHT VEHI','100001','100000','100008','860600','8704','SUPER','871000','871680','8701','871610','VEH','9804000'))
	                THEN '32-FLAG-RORO'
	
	                WHEN ss.sst_zuabcde IN ('NTFR')
		                 AND ss.sst_tariffcat1 IN ('RDOS','ROTHR','RDOSHHG','ROTHER','RCAT','RTSHIP','RIAL')
		                 AND (ss.sst_comcde IN ('100006','BOLS','860900','860901','100010','100007','BBFORK','BBNFORK','880212','860950','860960','MAFI','100004','100003','100002','100005','860910','860930','860920','860940','860970','860980'))
	                THEN '33-FLAG-OTHER'
	
	                WHEN ss.sst_zuabcde IN ('NTFR')
		                 AND ss.sst_tariffcat1 IN ('RDOS','ROTHR','RDOSHHG','ROTHER','RCAT','RTSHIP')
		                 AND (ss.sst_comcde IN ('9802002','9802003','HEAVY TRUC','780000'))
	                THEN '34-FLAG-HHG'
	
		            WHEN ss.sst_tariffcat1 IN ('RDOS','ROTHR','RDOSHHG','ROTHER','RCAT','RTSHIP')
						 AND ss.sst_zuabcde NOT IN ('NTFR','BAF','SRC','EBS','CCD','CCL','CVS','DITV','EITV','EPYS','ESS','FAF','IHD','IHL','NTFR','OHGT','OWGT','SLC','TRP','TRPD','TRPO','WSH')
		                 AND ss.sst_comcde is null
	                THEN '35-FLAG-PORT AND LINER'

	                WHEN ss.sst_tariffcat1 IN ('RDOS','ROTHR','RDOSHHG','ROTHER','RCAT','RTSHIP') 
		                 AND ss.sst_zuabcde IN ('BAF','SRC','EBS')
		                 AND ss.sst_comcde is null
	                THEN '36-FLAG-BAF'
	                
					WHEN ss.sst_tariffcat1 IN ('RDOS','ROTHR','RDOSHHG','ROTHER','RCAT','RTSHIP')
		                 AND ss.sst_zuabcde IN ('CCD','CCL','CVS','DITV','EITV','EPYS','ESS','FAF','IHD','IHL','NTFR','OHGT','OWGT','SLC','TRP','TRPD','TRPO','WSH')
		                 AND ss.sst_comcde is null
	                THEN '37-FLAG-LINEHAUL'
	
                    WHEN ss.sst_tariffcat1 IN ('RCMML')
                    THEN '44-ARC-COMMERCIAL'

                    WHEN ss.sst_tariffcat1 IN ('RSSS')
                    THEN '45-SDDC-SHORTSEA'

                    WHEN UPPER(SUBSTRING(ss.sst_voyage,1,2)) NOT IN ('MU','CB','UM','UB') 
                        AND ss.sst_tariffcat1 NOT IN ('RSSS','RAAL')
                    THEN '46-SDDC-OTO'

                    WHEN ss.sst_tariffcat1 IN ('ROTO')
                    THEN '46-SDDC-OTO'                    

	                ELSE '99-UNKNOWN'
                END AS CATEGORY,

                CASE 
	                WHEN UPPER(SUBSTRING(ss.sst_voyage,1,2)) IN ('MU','CB') THEN 'WESTBOUND'
	                WHEN UPPER(SUBSTRING(ss.sst_voyage,1,2)) IN ('UM','UB') THEN 'EASTBOUND'
	                ELSE 'OTHER'
                END AS DIRECTION,

                ss.sst_voyage AS VOYAGE,
                SS.sst_zuabcde as CHARGE_CD,
                ss.sst_tariffcat1 as TARIFF_CD,
                ss.sst_comcde as COMMODITY_CD,
                ss.sst_grw as WEIGHT,
                ss.sst_nrofpa as NUMBER_OF_PACKAGES,
                ss.sst_stat_amount as RATE,
                ss.sst_meas AS CUBIC_METERS,
                ' ' as CATEGORY_PARENT,
                ' ' as CATEGORY_CHILD,
                0 as PARENT_SORT,
                0 as CHILD_SORT,
				
                s.svbez as SERVICE,                 

                /* -- CASE
					WHEN (ss.sst_service = 'E') THEN 'EUROPE'
					WHEN (ss.sst_service = 'M') THEN 'MIDDLE EAST'
					ELSE 'OTHER'
				END AS SERVICE, --*/
                
                SS.sst_sstnr AS BILL_OF_LADING,
                ss.sst_vessel as VESSEL,
                ss.sst_shippermtc as SHIPPER,
                ss.sst_kopcde as KIND_OF_PACKAGE,
                ss.sst_statkdname as CUSTOMER_NAME,
                ss.sst_comdescr as COMMODITY_DSC,
                ss.sst_poldate as SAIL_DT,
				ss.sst_polcde AS POL,
				ss.sst_podcde AS POD,

                cast(YEAR(ss.sst_poldate) As varchar) + '-' +
                CASE
                WHEN MONTH(ss.sst_poldate) IN (10,11,12) THEN cast(MONTH(ss.sst_poldate) As varchar)  
                ELSE '0' + cast(MONTH(ss.sst_poldate) as varchar)
                END as YEAR_MON,

              CASE
                WHEN MONTH(ss.sst_poldate) IN (1,2,3) THEN cast(YEAR(ss.sst_poldate) As varchar) + '-1st'
                WHEN MONTH(ss.sst_poldate) IN (4,5,6)  THEN cast(YEAR(ss.sst_poldate) As varchar) + '-2nd'
                WHEN MONTH(ss.sst_poldate) IN (7,8,9) THEN cast(YEAR(ss.sst_poldate) As varchar)+ '-3rd'
                WHEN MONTH(ss.sst_poldate) IN (10,11,12) THEN cast(YEAR(ss.sst_poldate) As varchar) + '-4th'
              END AS YEAR_QTR


                FROM

                dba.v_sales_statistic_list ss
                inner join dba.service s on ((s.svsrvcode = ss.sst_service) AND (s.firma = 'ARC'))
					
                WHERE	1 = 1
	                and ss.sst_klammerkz = 'N' -- Not sure what it is but it is in the LINE query
	                and ss.sst_type = 'BL' -- Booking (BU) or Bill of Lading (BL)
                    and ss.sst_tariffcat1 NOT IN ('RMEMO')
	                
	                [WHERE]
	
                ORDER BY
                1,2,3,4,5,6"; 
            
            
            
            }
        }

        public void Run(ActualVsBudgetParams p)
        {
            StringBuilder Where = new StringBuilder();

            if (p.StartDt.IsNotNull())
                Where.AppendFormat(" and ss.sst_poldate >= '{0:MM/dd/yyyy}'", p.StartDt);

            if (p.EndDt.IsNotNull())
                Where.AppendFormat(" and ss.sst_poldate <= '{0:MM/dd/yyyy}'", p.EndDt);

            if (p.DirectionInd == "W")
                Where.AppendFormat(" and UPPER(SUBSTRING(ss.sst_voyage,1,2)) IN ('MU','CB')");

            if (p.DirectionInd == "E")
                Where.AppendFormat(" and UPPER(SUBSTRING(ss.sst_voyage,1,2)) IN ('UM','UB')");

            if (p.DirectionInd == "B")
                Where.AppendFormat(" and UPPER(SUBSTRING(ss.sst_voyage,1,2)) IN ('MU','CB','UM','UB')");

            if (p.DirectionInd == "O")
                Where.AppendFormat(" and UPPER(SUBSTRING(ss.sst_voyage,1,2)) NOT IN ('MU','CB','UM','UB')");

            if (p.LineService.IsNotNull())
                Where.AppendFormat(" and ss.sst_service in ({0}) ",p.LineService);

            if (p.Voyage.IsNotNull())
                Where.AppendFormat(" and ss.sst_voyage = '{0}'", p.Voyage);

            if (p.Bol.IsNotNull())
                Where.AppendFormat(" and SS.sst_sstnr = '{0}'", p.Bol);

            Async = true;
            
            RunWhere(Where.ToString());
        }
    }
}
