using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
    public class sql_nhtsa_recall : sql_base
    {
        protected override string connection_key
        {
            get { return "ArcSys"; }
        }

        protected override string base_query
        {
            get
            {
                return @"
                Select 
                    r.nhtsa_recall_id,
                    v.vessel_nm,
                    r.voyage,
                    r.pol,
                    r.arrive_dt,
                    r.booking_no, 
                    r.vin,
                    r.car_year || ' ' || r.car_make || ' ' || r.car_model as car_dsc,
                    status.recall_status_dsc,                    
                    risk.recall_risk_dsc,
                    r.recall_keywords,
                    /*  DGERDNER MARC2019 fixed performance issues
					h.create_dt as last_status_update,*/
                    (
                    select create_dt from t_nhtsa_recall_history
                     where t_nhtsa_recall_history.nhtsa_recall_history_id =
                    (Select max(rh.nhtsa_recall_history_id) from t_nhtsa_recall_history rh where rh.nhtsa_recall_id = r.nhtsa_recall_id)
                    ) as last_status_update,

                    r.pod,
                    r.recall_status_cd,
                    l.location_dsc,
                    v.vessel_cd

                from t_nhtsa_recall r
                inner join r_recall_risk risk on r.recall_risk_cd = risk.recall_risk_cd
                inner join r_recall_status status on r.recall_status_cd = status.recall_status_cd
                inner join r_vessel v on v.vessel_cd = r.vessel
                inner join r_location l on l.location_cd = r.pol
                /*inner join t_nhtsa_recall_history h on h.nhtsa_recall_history_id = (Select max(rh.nhtsa_recall_history_id) from t_nhtsa_recall_history rh where rh.nhtsa_recall_id = r.nhtsa_recall_id)*/

                where 1=1
                [WHERE]
                ";
            }
        }

        public void Run(mNhtsaParameters p)
        {
            StringBuilder sb = new StringBuilder();

            p.lstErrors = new List<string>();

            if (p.Voyage.IsNotNull())
                sb.AppendFormat(" and r.voyage = '{0}'", p.Voyage.Trim());

            if (p.Vessel_Cd.IsNotNull())
                sb.AppendFormat(" and v.vessel_cd = '{0}'", p.Vessel_Cd.Trim());

            if (p.Pol_Cd.IsNotNull())
                sb.AppendFormat(" and r.pol = '{0}'", p.Pol_Cd.Trim());

            if (p.SailDateFrom.IsNotNull())
                sb.AppendFormat(" and r.arrive_dt >= '{0:dd-MMM-yy}'", p.SailDateFrom);

            if (p.SailDateTo.IsNotNull())
                sb.AppendFormat(" and r.arrive_dt <= '{0:dd-MMM-yy}'", p.SailDateTo);

            if (p.RiskCd.IsNotNull())
                sb.AppendFormat(" and r.recall_risk_cd = '{0}'", p.RiskCd.Trim());

            if (p.StatusCd.IsNotNull())
                sb.AppendFormat(" and r.recall_status_cd = '{0}'", p.StatusCd.Trim());
            
            if (p.Vin.IsNotNull())
                sb.AppendFormat(" and r.vin = '{0}'", p.Vin.Trim().ToUpper());

            Async = true;

            RunWhere(sb.ToString());
        }

    }

    public class mNhtsaParameters
    {
        public string Vessel_Cd { get; set; }
        public string Voyage { get; set; }
        public string Pol_Cd { get; set; }
        public DateTime? SailDateFrom { get; set; }
        public DateTime? SailDateTo { get; set; }
        public string RiskCd { get; set; }
        public string StatusCd { get; set; }
        public string Vin { get; set; }

        public List<String> lstErrors { get; set; }
    }
}
