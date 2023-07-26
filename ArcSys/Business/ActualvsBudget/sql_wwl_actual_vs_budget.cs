using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
    public class sql_wwl_actual_vs_budget : sql_base
    {
        protected override string connection_key
        {
            get { return "ODS"; }
        }

        protected override string base_query
        {
            get {

                return @"
                      WITH
                    W_VOYAGE AS
                    (
                            SELECT DISTINCT
                            VH.VOYAGE_NUMBER, 
                            VD.VESSEL_CODE, 
                            VD.VESSEL_NAME, 
                            VD.PORT_CODE,
                            VD.BERTH_CODE,
                            VH.ROUTE_CODE,
                            VD.ETD,
                            CASE
                                   WHEN INSTR(VH.ROUTE_CODE, 'ME') > 0 THEN 'MIDDLE EAST SERVICE'
                                   WHEN INSTR(VH.ROUTE_CODE, 'EU') > 0 THEN 'EUROPE SERVICE'
                                   ELSE 'OTHER'
                            END AS SERVICE,
                            CASE
                                    WHEN UPPER(SUBSTR(VH.VOYAGE_NUMBER, 1, 2)) IN ('MU', 'CB') THEN 'WESTBOUND'
                                    WHEN UPPER(SUBSTR(VH.VOYAGE_NUMBER, 1, 2)) IN ('UM', 'UB') THEN 'EASTBOUND'
                                    ELSE 'OTHER'
                                END AS DIRECTION
                          FROM SC_VOYAGE_HEADER VH
                          INNER JOIN SC_VOYAGE_DETAIL VD ON (VD.VOYAGE_NUMBER = VH.VOYAGE_NUMBER)
                          WHERE VH.CARRIER_CODE IN ('WLHN', 'WJKS')
                          AND VD.VESSEL_CODE IN ('COG','FRE','HON','ITG','INC','RES')
                          --AND VH.F_INACTIVE = 'N'    
                    ),
                    W_BOL AS
                    (
                          SELECT B.BILL_OF_LADING_NUMBER,B.BILL_OF_LADING_NO, SUM(BC.QUANTITY) AS QUANTITY
                        FROM T_BILL_OF_LADING B
                          INNER JOIN T_BILL_OF_LADING_CARGO BC ON BC.BILL_OF_LADING_NO = B.BILL_OF_LADING_NO
                          GROUP BY B.BILL_OF_LADING_NUMBER, B.BILL_OF_LADING_NO
                    )

                    SELECT distinct

                    CASE
                      WHEN BF.CHARGE_CODE IN ('BAF','EBS','SRC') THEN '42-COMMERICIAL-BAF'
                      WHEN BF.CHARGE_CODE IN ('IHD','IHL') THEN '43-COMMERCIAL-LINEHAUL'
                      WHEN BC.CARGO_CLASS = 'AUTO' THEN '39-COMMERCIAL-AUTO'
                      WHEN BC.CARGO_CLASS = 'RORO' THEN '40-COMMERCIAL-RORO'
                      WHEN BC.CARGO_CLASS = 'BREAKBULK' THEN '41-COMMERCIAL-BREAKBULK'

                      ELSE 'OTHER'
                    END AS CATEGORY,

                    VOY.DIRECTION,
                    B.VOYAGE_NUMBER AS VOYAGE,
                    BF.CHARGE_CODE AS CHARGE_CD,
                    ' ' AS TARIFF_CD,
                    ' ' AS COMMODITY_CD,
                    CASE WHEN BF.CHARGE_CODE = 'ORA' THEN SUM(NVL(BC.WEIGHT_TOTAL,0)) ELSE 0 END AS WEIGHT,
                    CASE WHEN BF.CHARGE_CODE = 'ORA' THEN SUM(NVL(BC.QUANTITY,0)) ELSE 0 END AS NUMBER_OF_PACKAGES,
                    NVL(BF.CHARGES_USD,0) AS RATE,
                    CASE WHEN BF.CHARGE_CODE = 'ORA' THEN SUM(NVL(BC.CUBIC_DIMENSIONS_TOTAL,0)) ELSE 0 END AS CUBIC_METERS,
                    'COMMERCIAL' AS CATEGORY_PARENT,

                    CASE  
                      WHEN BF.CHARGE_CODE IN ('BAF','EBS','SRC') THEN 'BAF'
                      WHEN BF.CHARGE_CODE IN ('IHD','IHL') THEN 'LINEHAUL'
                      ELSE BC.CARGO_CLASS 
                    END AS CATEGORY_CHILD,

                    6 AS PARENT_SORT,
                    CASE
                      WHEN BF.CHARGE_CODE IN ('BAF','EBS','SRC') THEN 42
                      WHEN BF.CHARGE_CODE IN ('IHD','IHL') THEN 43
                    WHEN BC.CARGO_CLASS = 'AUTO' THEN 39
                      WHEN BC.CARGO_CLASS = 'RORO' THEN 40
                      WHEN BC.CARGO_CLASS = 'BREAKBULK' THEN 41
                    END AS CHILD_SORT,
       
                    VOY.SERVICE,
                    
                    B.BILL_OF_LADING_NUMBER AS BILL_OF_LADING,
                    VOY.VESSEL_CODE AS VESSEL,
                    ' ' AS SHIPPER,
                    ' ' AS KIND_OF_PACKAGE,
                    ' ' AS CUSTOMER_NAME,
                    ' ' AS COMMODITY_DSC,
                    voy.etd AS SAIL_DT,
                    BC.COMMODITY_DESCRIPTION,
                    B.Port_Code_Pol AS POL,
                    B.Port_Code_Pod AS POD,

                    to_char(voy.etd, 'YYYY-MM') as YEAR_MON,

                  CASE
                    WHEN to_char(voy.etd, 'MM') IN ('01','02','03') THEN to_char(voy.etd, 'YYYY') || '-1st'
                    WHEN to_char(voy.etd, 'MM') IN ('04','05','06') THEN to_char(voy.etd, 'YYYY') || '-2nd'
                    WHEN to_char(voy.etd, 'MM') IN ('07','08','09') THEN to_char(voy.etd, 'YYYY') || '-3rd'
                    WHEN to_char(voy.etd, 'MM') IN ('10','11','12') THEN to_char(voy.etd, 'YYYY') || '-4th'
                  END AS YEAR_QTR

                    FROM T_BILL_OF_LADING B
                    INNER JOIN T_BILL_FREIGHT BF ON BF.BILL_OF_LADING_NO = B.BILL_OF_LADING_NO 
                    LEFT OUTER JOIN T_BILL_OF_LADING_CARGO BC ON (BC.BILL_OF_LADING_NO = BF.BILL_OF_LADING_NO AND BC.ITEM_NUMBER  = BF.ITEM_NUMBER)
                    INNER JOIN W_VOYAGE VOY ON (VOY.VOYAGE_NUMBER = B.VOYAGE_NUMBER AND B.PORT_CODE_POL = VOY.PORT_CODE AND B.POL_BERTH = VOY.BERTH_CODE)
                    INNER JOIN W_BOL BOL ON B.BILL_OF_LADING_NO = BOL.BILL_OF_LADING_NO

                    WHERE 1=1

                    [WHERE]

                    GROUP BY

                    CASE
                      WHEN BF.CHARGE_CODE IN ('BAF','EBS','SRC') THEN '42-COMMERICIAL-BAF'
                      WHEN BF.CHARGE_CODE IN ('IHD','IHL') THEN '43-COMMERCIAL-LINEHAUL'
                        WHEN BC.CARGO_CLASS = 'AUTO' THEN '39-COMMERCIAL-AUTO'
                      WHEN BC.CARGO_CLASS = 'RORO' THEN '40-COMMERCIAL-RORO'
                      WHEN BC.CARGO_CLASS = 'BREAKBULK' THEN '41-COMMERCIAL-BREAKBULK'

                      ELSE 'OTHER'
                    END,

                    VOY.DIRECTION,
                    B.VOYAGE_NUMBER,
                    BF.CHARGE_CODE,
                    BF.CHARGES_USD,
                    BOL.QUANTITY,
                    'COMMERCIAL',
                    
                    CASE  
                      WHEN BF.CHARGE_CODE IN ('BAF','EBS','SRC') THEN 'BAF'
                      WHEN BF.CHARGE_CODE IN ('IHD','IHL') THEN 'LINEHAUL'
                      ELSE BC.CARGO_CLASS 
                    END ,

                    6,
                    CASE
                      WHEN BF.CHARGE_CODE IN ('BAF','EBS','SRC') THEN 42
                      WHEN BF.CHARGE_CODE IN ('IHD','IHL') THEN 43
                        WHEN BC.CARGO_CLASS = 'AUTO' THEN 39
                      WHEN BC.CARGO_CLASS = 'RORO' THEN 40
                      WHEN BC.CARGO_CLASS = 'BREAKBULK' THEN 41

                    END,
       
                    VOY.SERVICE,
                    B.BILL_OF_LADING_NUMBER,
                    VOY.VESSEL_CODE,voy.etd,
                    BC.COMMODITY_DESCRIPTION,
                    B.Port_Code_Pol,
                    B.Port_Code_Pod";
                
            }
        }

        public void Run(ActualVsBudgetParams p)
        {
            StringBuilder Where = new StringBuilder();

            if (p.StartDt.IsNotNull())
                Where.AppendFormat(" and voy.etd >= '{0:dd-MMM-yy}'", p.StartDt);

            if (p.EndDt.IsNotNull())
                Where.AppendFormat(" and voy.etd <= '{0:dd-MMM-yy}'", p.EndDt);

            if (p.DirectionInd == "W")
                Where.AppendFormat(" and UPPER(SUBSTR(voy.voyage_number,1,2)) IN ('MU','CB')");

            if (p.DirectionInd == "E")
                Where.AppendFormat(" and UPPER(SUBSTR(voy.voyage_number,1,2)) IN ('UM','UB')");

            if (p.DirectionInd == "B")
                Where.AppendFormat(" and UPPER(SUBSTR(voy.voyage_number,1,2)) IN ('MU','CB','UM','UB')");

            if (p.DirectionInd == "O")
                Where.AppendFormat(" and UPPER(SUBSTR(voy.voyage_number,1,2)) NOT IN ('MU','CB','UM','UB')");

            if (p.ServiceInd.IsNotNull())
                Where.AppendFormat(@" and 
                    CASE 
                        WHEN INSTR(VOY.ROUTE_CODE, 'ME') > 0 THEN 'MIDDLE EAST'
                        WHEN INSTR(VOY.ROUTE_CODE, 'EU') > 0 THEN 'EUROPE'
                        ELSE 'OTHER'
                    END = '{0}'", p.ServiceText);

            if (p.Voyage.IsNotNull())
                Where.AppendFormat(" and voy.voyage_number like '%{0}%'", p.Voyage);

            if (p.Bol.IsNotNull())
                Where.AppendFormat(" and B.BILL_OF_LADING_NUMBER = '{0}'", p.Bol);

            Async = true;

            RunWhere(Where.ToString());
        }
    }
}
