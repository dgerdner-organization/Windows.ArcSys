using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
    public class clsLobExtract
    {
        public string van_type { get; set; }
        public string tcn { get; set; }
        public string container_no { get; set; }
        public string consignor_dodaac { get; set; }
        public string voyage_no { get; set; }
        public string pod_location_cd { get; set; }
        public string booking_no { get; set; }
        public string pcfn { get; set; }
        public string vessel_status_cd { get; set; }
        public string consignee_dodaac { get; set; }
        public string cargo_dsc { get; set; }
        public decimal cube_nbr { get; set; }
        public decimal length_nbr { get; set; }
        public decimal width_nbr { get; set; }
        public decimal height_nbr { get; set; }
        public decimal weight_nbr { get; set; }
        public decimal mton_nbr { get; set; }
        public string booked_flg { get; set; }
        public string si_flg { get; set; }
        public string comment_one { get; set; }
        public string comment_two { get; set; }
        public string commodity_cd { get; set; }
        public DateTime rdd_dt { get; set; }
        public DateTime lifton_dt { get; set; }
        public int pcs_nbr { get; set; }
        public string pol_location_cd { get; set; }
        public string pol_berth_cd { get; set; }
        public string req_pod_location_cd { get; set; }
        public string plod { get; set; }
        public decimal sddc_cbft { get; set; }
        public string move_type_cd { get; set; }
        public long lob_detail_id { get; set; }
        public long lob_header_id { get; set; }
        public string manifested_flg { get; set; }
        public string create_user { get; set; }
        public DateTime create_dt { get; set; }
        public string modify_user { get; set; }
        public DateTime modify_dt { get; set; }
        public string vd_flg { get; set; }
		public string cargo_status { get; set; }
		public string cargo_bol_no { get; set; }
        //public string vessel_status_cd { get; set; }

        public static clsLobExtract Populate(DataRow dr)
        {
            clsLobExtract l = new clsLobExtract();            
            
            try
            {
                l.van_type = dr[0].ToString();
                l.tcn = dr[1].ToString();
                l.container_no = dr[2].ToString();
                l.consignor_dodaac = dr[3].ToString();
                l.voyage_no = dr[4].ToString();
                l.pod_location_cd = dr[5].ToString();
                l.booking_no = dr[6].ToString();
                l.pcfn = dr[7].ToString();
                l.vessel_status_cd = dr[8].ToString();
                l.consignee_dodaac = dr[9].ToString();
                l.cargo_dsc = dr[10].ToString();
                l.cube_nbr = dr[11].ToDecimal();
                l.length_nbr = dr[12].ToDecimal();
                l.width_nbr = dr[13].ToDecimal();
                l.height_nbr = dr[14].ToDecimal();
                l.weight_nbr = dr[15].ToDecimal();
                l.mton_nbr = dr[16].ToDecimal();
                l.booked_flg = dr[17].ToString();
                l.si_flg = dr[18].ToString();
                l.comment_one = dr[19].ToString();
                l.comment_two = dr[20].ToString();
                l.commodity_cd = dr[21].ToString();
                l.rdd_dt = dr[22].ToDateTime();
                l.lifton_dt = dr[23].ToDateTime();
                l.pcs_nbr = dr[24].ToInt();
                l.pol_location_cd = dr[25].ToString();
                l.pol_berth_cd = dr[26].ToString();
                l.req_pod_location_cd = dr[27].ToString();
                l.plod = dr[28].ToString();
                l.sddc_cbft = dr[29].ToDecimal();
                l.move_type_cd = dr[30].ToString();
                l.lob_detail_id = dr[31].ToLong();
                l.lob_header_id = dr[32].ToLong();
                l.manifested_flg = dr[33].ToString();
                //l.create_user = dr[34].ToString();
                //l.create_dt = dr[35].ToDateTime();
                //l.modify_user = dr[36].ToString();
                //l.modify_dt = dr[37].ToDateTime();
                l.vd_flg = dr[38].ToString();
                l.cargo_status = dr[40].ToString();
                l.cargo_bol_no = dr[41].ToString();

            }
            catch (Exception ex)
            {
                ClsErrorHandler.LogException(ex);
                l = new clsLobExtract();
            }

            return l;

        }

    }
}
