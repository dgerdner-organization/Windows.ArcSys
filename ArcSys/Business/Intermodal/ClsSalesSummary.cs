using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using CS2010.Common;
using CS2010.ArcSys.Business;

namespace CS2010.ArcSys.Business
{
    public class ClsSalesSummary
    {
        #region Connections
        private  ClsConnection ARCConnection
        {
            get { return ClsConMgr.Manager["ArcSys"]; }
        }
        private ClsConnection LINEConnection
        {
            get
            {
                if (ClsConMgr.Manager["LINE"] == null)
                {
                    ConnectToLINE();
                }
                return ClsConMgr.Manager["LINE"];
            }
        }

        private bool ConnectToLINE()
        {
			string sConnect = "packet size=4096;user id=line-edi-user;password=dg20100512;data source=SQLCLUSTER;persist security info=True;initial catalog=Line_cs;";
            ClsConnection line = new ClsConnection(sConnect, "System.Data.SqlClient");
            line.DbConnectionKey = "LINE";
            ClsConMgr.Manager.AddConnection(line);
            return true;
        }
        #endregion

        #region Search Parameters
        public long? Estimate_ID;
        public string csvEstimateID;

        public string Estimate_No;

        public string Booking_No;
        public string PCFN;
        public string Serial_No;

        public string PLOR_CDs;
        public string POL_CDs;
        public string POD_CDs;
        public string PLOD_CDs;

        public string Act_Orig_CDs;
        public string Act_Dest_CDs;

        public string StatusCDs;
        public string MoveTypeCDs;
        public bool IncludeNonDoor;

        public string csvBooking;
        public string csvPCFN;

        public string Vessel;
        public string VoyageNo;

        public DateRange ETD;
        public DateRange RDD;
        public DateRange Created;
        public DateRange Modified;
        public DateRange Vessel_Sail_Dt;        
        #endregion

        #region SQL Fields
        #region LINE
        private string sqlSalesSummLINE = @"
        SELECT     firma, 
                   sst_type, 
                   sst_sstmanr, 
                   sst_sstposno, 
                   sst_sstnr as booking_no, 
                   sst_service, 
                   sst_vessel as vessel_cd, 
                   sst_voyage as voyage_no, 
                   sst_rmanr, 
                   sst_plorcde as plor, 
                   sst_polcde  as pol, 
                   sst_polseqno, 
                   sst_podcde  as pod, 
                   sst_podseqno, 
                   sst_plodcde as plod, 
                   sst_statdate, 
                   sst_klammerkz, sst_agency, sst_exim, sst_kdnr, sst_kdmtc, sst_shippernr, sst_shippermtc, 
                   sst_consigneenr, sst_consigneemtc, sst_verart, sst_payable, sst_rrmanr, sst_rrklammerkz, sst_rrpos, sst_stat_curcode, sst_pos_curcode, sst_grw, 
                   sst_meas, sst_frt, sst_ntw, 
                   round(sst_length * 3.2808398917,2) as length_nbr, 
                   round(sst_width * 3.2808398917,2) as width_nbr, 
                   round(sst_height * 3.2808398917,2) as height_nbr, 
                   sst_square as sqft_nbr, 
                   sst_nrofpa, sst_kopcde, 
                   sst_per as level_unit_dsc, 
                   sst_tare, sst_noof20, sst_noof40, sst_teu, 
                   sst_conttype, 
                    sst_zuabcde as charge_type_cd,
                   sst_pos_amount, 
                   sst_stat_amount as activity_amt, 
                   sst_comcde, sst_person_incharge, sst_account, sst_notifynr, 
                    sst_vskond as move_type_cd, 
                    sst_plopcde, sst_notifymtc, sst_statkdnr, sst_statkdmtc, sst_statkdname, sst_kundeart, sst_imdgkz, sst_oogkz, rpploiragt, sst_princinv, sst_waybill, 
                    sst_polgroup, sst_podgroup, sst_polberth, sst_podberth, sst_emptykz, sst_poldate, sst_polregion, sst_podregion, sst_stat_group, 
                    sst_stat_group_kdmtc, sst_additional_region, sst_comgrp, sst_kopgroup, sst_unitmeas, sst_unitmeas40, sst_tariffcat1, 
                    sst_rate as rate_amt, 
                    sst_legno, 
                    sst_comdescr, sst_teu_so, sst_stat_amount2, sst_stat_curcode2, sst_forwardernr, sst_forwardermtc, sst_createdate
        FROM         dba.v_sales_statistic_list
        WHERE      (sst_klammerkz = 'N') ";
        #endregion

        #region ARC Sales Summary
        private string sqlSalesSummSelect = @"
            select e.estimate_no, 
                   e.estimate_id,
                   finance_cd, 
                   b.booking_no, 
                   car.item_no as item_nox, 
                   case
                     when lu.level_unit_dsc = 'FLAT RATE PER PCFN' then 0
                       else car.item_no
                         end as item_no, 
                   cargo_dsc, 
                   c.charge_type_cd, 
                   ct.charge_type_dsc,
                   car.move_type_cd, voyage_no || '-' || vessel_cd as voyage_vessel,
                   lu.level_unit_dsc,
                   charge_type_dsc,
                   c.rate_amt, 
                   c.level_count, 
                   c.unit_qty, 
                   c.total_amt, 
                   c.tcn_count,
                   c.pcs_per_conveyance,
                   cast (sum(d.activity_amt) as numeric(14,2)) as activity_amt, 
                   cast (sum(d.activity_amt) / count(d.estimate_charge_dtl_id) as numeric(14,3))  as rate_per, 
                   count(d.estimate_charge_dtl_id) as cargo_count ";

        private string sqlSalesSummerSelectPCFN = @"
            select e.estimate_no, 
                   e.estimate_id,
                   finance_cd, 
                   b.booking_no, 
                   cast (1 as number(5)) as item_nox, 
                   1 as item_no, 
                   '' as cargo_dsc, 
                   c.charge_type_cd, 
                   ct.charge_type_dsc,
                   car.move_type_cd, voyage_no || '-' || vessel_cd as voyage_vessel,
                   lu.level_unit_dsc,
                   c.rate_amt, 
                   c.level_count, 
                   c.unit_qty, 
                   c.total_amt, 
                   c.tcn_count,
                   c.pcs_per_conveyance,
                   cast(c.rate_amt as numeric(14,2)) as activity_amt, 
                   cast(round(c.rate_amt / count(d.estimate_charge_dtl_id),3) as numeric(14,3)) as rate_per, 
                   count(d.estimate_charge_dtl_id) as cargo_count ";

        private string sqlSalesSummFrom = @"
             from t_estimate_charge c
             inner join t_estimate_charge_dtl d on c.estimate_charge_id = d.estimate_charge_id
             inner join t_estimate e on e.estimate_id = c.estimate_id
             inner join t_cargo_activity a on a.cargo_activity_id = d.cargo_activity_id
             inner join t_cargo car on car.cargo_id = a.cargo_id
             inner join t_booking b on b.booking_id = car.booking_id
             inner join r_charge_type ct on ct.charge_type_cd = c.charge_type_cd
             inner join r_level_unit lu on lu.level_unit_id = c.level_unit_id ";

        private string sqlSalesSummWhere = @" where finance_cd = 'AR' ";

        private string sqlSalesSummGroupBy = @"
            group by  estimate_no, finance_cd, booking_no, item_no, c.charge_type_cd, ct.charge_type_dsc, cargo_dsc,
                  level_unit_dsc, c.rate_amt, c.level_count, c.unit_qty, c.total_amt,  c.tcn_count,
                   c.pcs_per_conveyance, move_type_cd, voyage_no, vessel_cd, e.estimate_id";

		private string sqlSalesSummGroupByPCFN = @"
            group by  estimate_no, finance_cd, booking_no, c.charge_type_cd, ct.charge_type_dsc,
                  level_unit_dsc, c.rate_amt, c.level_count, c.unit_qty, c.total_amt,  c.tcn_count,
                   c.pcs_per_conveyance, move_type_cd, voyage_no, vessel_cd, e.estimate_id";


        private string sqlSalesSummOrderBy = @"
            order by estimate_no, finance_cd, booking_no, item_no, charge_type_cd, cargo_dsc,
                  level_unit_dsc";
        #endregion
        #endregion

        #region Sales Summary ARC Methods
        public DataTable GetSalesSummaryARC()
        {
            List<DbParameter> p = new List<DbParameter>();

            // First, get PCFN
            StringBuilder sql = new StringBuilder(sqlSalesSummerSelectPCFN);
            sql.AppendFormat(sqlSalesSummFrom);
            sql.AppendFormat(sqlSalesSummWhere);
            sql = BuildARCWhereClause(sql, p);
            sql.AppendFormat(" and lu.level_unit_dsc = 'FLAT RATE PER PCFN' ");
            sql.AppendFormat(sqlSalesSummGroupByPCFN);
            sql.AppendFormat(sqlSalesSummOrderBy);
            string s = sql.ToString();
            DataTable dtPCFN = ARCConnection.GetDataTable(s, p.ToArray());

            // Next, get non-PCFN
            p = new List<DbParameter>();
            sql = new StringBuilder(sqlSalesSummSelect);
            sql.AppendFormat(sqlSalesSummFrom);
            sql.AppendFormat(sqlSalesSummWhere);
            sql = BuildARCWhereClause(sql, p);
            sql.AppendFormat(" and lu.level_unit_dsc <> 'FLAT RATE PER PCFN' ");
            sql.AppendFormat(sqlSalesSummGroupBy);
            //sql.AppendFormat(", d.activity_amt");
            sql.AppendFormat(sqlSalesSummOrderBy);
            s = sql.ToString();
            DataTable dtARC = ARCConnection.GetDataTable(s, p.ToArray());

            // Merge the two together
            dtPCFN.Merge(dtARC);
            return dtPCFN;
        }

        public StringBuilder BuildARCWhereClause(StringBuilder sb, List<DbParameter> p)
        {
            ARCConnection.AppendLikeClause(sb, p, "AND",
                "b.customer_ref", "@PCFN", PCFN);
            ARCConnection.AppendLikeClause(sb, p, "AND",
                "b.booking_no", "@BK_NO", Booking_No);
            ARCConnection.AppendInClause(sb, p, "AND",
                "b.customer_ref", "@PCSV", ClsConvert.AddQuotes(csvPCFN));
            ARCConnection.AppendInClause(sb, p, "AND",
                "b.booking_no", "@BK_CSV", ClsConvert.AddQuotes(csvBooking));
            ARCConnection.AppendDateClause(sb, p, "AND",
                "b.sail_dt", "@SAIL_FR", "@SAIL_TO", Vessel_Sail_Dt);

            ARCConnection.AppendInClause(sb, p, "AND",
                "b.plor_location_cd", "@PLOR_CD", ClsConvert.AddQuotes(PLOR_CDs));
            ARCConnection.AppendInClause(sb, p, "AND",
                "b.pol_location_cd", "@POL_CD", ClsConvert.AddQuotes(POL_CDs));
            ARCConnection.AppendInClause(sb, p, "AND",
                "b.pod_location_cd", "@POD_CD", ClsConvert.AddQuotes(POD_CDs));
            ARCConnection.AppendInClause(sb, p, "AND",
                "b.plod_location_cd", "@PLOD_CD", ClsConvert.AddQuotes(PLOD_CDs));

            ARCConnection.AppendInClause(sb, p, "AND",
               "move_type_cd", "@MV_TP", ClsConvert.AddQuotes(MoveTypeCDs));
            ARCConnection.AppendInClause(sb, p, "AND",
                "vessel_cd", "@VES_CD", ClsConvert.AddQuotes(Vessel));
            ARCConnection.AppendLikeClause(sb, p, "AND",
                "voyage_no", "@VOY_NO", VoyageNo);

            ARCConnection.AppendInClause(sb, p, "AND",
                "a.orig_location_cd", "@ACT_ORIG_CD", ClsConvert.AddQuotes(Act_Orig_CDs));
            ARCConnection.AppendInClause(sb, p, "AND",
                "a.dest_location_cd", "@ACT_DEST_CD", ClsConvert.AddQuotes(Act_Dest_CDs));

            if (!string.IsNullOrEmpty(Estimate_No))
            {
                ARCConnection.AppendEqualClause(sb, p, "AND",
                    "estimate_no", "@ESTNO", Estimate_No);
            }

            return sb;
        }

        #endregion

        #region Sales Summary LINE Methods
        public DataTable GetSalesSummaryLINE(string BookingList)
        {
            List<DbParameter> p = new List<DbParameter>();
            StringBuilder sql = new StringBuilder(sqlSalesSummLINE);
            sql = BuildLINEWhereClause(sql, p, BookingList);

            string s = sql.ToString();
            DataTable dt = LINEConnection.GetDataTable(s, p.ToArray());
            return dt;
        }
        public StringBuilder BuildLINEWhereClause(StringBuilder sb, List<DbParameter> p, string BookingList)
        {
            //LINEConnection.AppendLikeClause(sb, p, "AND", "sst_sstnr", "@BOOKKNO", Booking_No);

            LINEConnection.AppendInClause(sb, p, "AND", "sst_sstnr", "@BOOKNO",
                ClsConvert.AddQuotes(BookingList));
            //LINEConnection.AppendLikeClause(sb, p, "AND",
            //    "bk.customer_ref", "@PCFN", PCFN);
            //LINEConnection.AppendInClause(sb, p, "AND",
            //    "bk.customer_ref", "@PCSV", ClsConvert.AddQuotes(csvPCFN));
            //LINEConnection.AppendInClause(sb, p, "AND",
            //    "bk.booking_no", "@BK_CSV", ClsConvert.AddQuotes(csvBooking));
            //LINEConnection.AppendDateClause(sb, p, "AND",
            //    "sst_poldate", "@SAIL_FR", "@SAIL_TO", Vessel_Sail_Dt);

            //LINEConnection.AppendInClause(sb, p, "AND",
            //    "sst_plorcde", "@PLOR_CD", ClsConvert.AddQuotes(PLOR_CDs));
            //LINEConnection.AppendInClause(sb, p, "AND",
            //    "sst_polcde", "@POL_CD", ClsConvert.AddQuotes(POL_CDs));
            //LINEConnection.AppendInClause(sb, p, "AND",
            //    "sst_podcde", "@POD_CD", ClsConvert.AddQuotes(POD_CDs));
            //LINEConnection.AppendInClause(sb, p, "AND",
            //    "sst_plodcde", "@PLOD_CD", ClsConvert.AddQuotes(PLOD_CDs));

            //LINEConnection.AppendInClause(sb, p, "AND",
            //      "sst_vskond", "@MV_TP", ClsConvert.AddQuotes(MoveTypeCDs));
            //LINEConnection.AppendInClause(sb, p, "AND",
            //    "sst_vessel", "@VES_CD", ClsConvert.AddQuotes(Vessel));
            //LINEConnection.AppendLikeClause(sb, p, "AND",
            //    "sst_voyage", "@VOY_NO", VoyageNo);

            //LINEConnection.AppendInClause(sb, p, "AND",
            //    "ca.orig_location_cd", "@ACT_ORIG_CD", ClsConvert.AddQuotes(Act_Orig_CDs));
            //LINEConnection.AppendInClause(sb, p, "AND",
            //    "ca.dest_location_cd", "@ACT_DEST_CD", ClsConvert.AddQuotes(Act_Dest_CDs));

            return sb;
        }

        #endregion

        #region Help Methods
        public void Clear()
        {
            Booking_No = Estimate_No = PCFN = csvPCFN = csvBooking = Vessel = VoyageNo = StatusCDs =
                MoveTypeCDs = POL_CDs = POD_CDs = PLOR_CDs = PLOD_CDs = Act_Orig_CDs =
                Act_Dest_CDs = Serial_No = csvEstimateID = null;

            IncludeNonDoor = false;
            Estimate_ID = null;

            ETD.Clear();
            RDD.Clear();
            Created.Clear();
            Modified.Clear();
            Vessel_Sail_Dt.Clear();
        }
        #endregion
    }
}
