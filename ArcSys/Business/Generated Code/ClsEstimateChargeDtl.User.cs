using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public partial class ClsEstimateChargeDtl : ClsBaseTable
	{
		public static DataTable GetLHaulBillingExtract(string sVoyageNo,
			string sPCFN, string sSerialNo, string sPOL, string sPOD, string sOrigin, string sDestination, string ap_cd, string ar_cd)
		{
			string sFinance_cd = "%";
			if (ap_cd == "Y" && ar_cd == "N")
				sFinance_cd = "AP";
			if (ar_cd == "Y" && ap_cd == "N")
				sFinance_cd = "AR";
			string sql = string.Format(@"
  				   SELECT  
					echg.charge_type_cd,
					echg.level_count,
					echg.unit_qty as units,
					echg.memo as rate_id,
					bk.plor_location_cd as plor,
					bk.plod_location_cd as plod,
					echg.rate_amt as usc8_rate,
					lvu.level_unit_dsc as basis,
					ct.charge_type_dsc as lh_type,
					bk.customer_ref as pcfn,
					edi_ref as pcfn_b,
					cargo_dsc,
					edt.activity_amt,
					 c.length_nbr || ' x ' || c.width_nbr || ' x ' || c.height_nbr as len_wid_hgt,
					 c.cube_ft,
					c.m_tons,
					c.weight_nbr, 
					c.dim_weight_nbr,
					c.serial_no,
					c.move_type_cd,
					 NVL(cmod.attachment_nm, '<No Attachment>') AS mod_no_attachment_nm,
					 vendor_cd,
					 commodity_cd,
					 make_cd,
					 model_cd,
					 c.pkg_type_cd,
					 sail_dt,
					 vessel_load_dt,
					 c.length_nbr, c.width_nbr, c.height_nbr, 
					 activity_type_cd,
					 billable_flg,
					 bol_no,
					 customer_cd,
					 match_cd,
					 booking_no,
					 item_no,
					 vessel_cd,
					 voyage_no,
						 ca.orig_location_cd, ca.dest_location_cd,
						   decode(ca.orig_location_cd, null, 0, est.orig_location_cd, 0, 1) as mismatch_orig,
						  decode(ca.dest_location_cd, null, 0, est.dest_location_cd, 0, 1) as mismatch_dest,
						  decode(bk.voyage_no, null, 0, est.voyage_no, 0, 1) as mismatch_voy,
						  decode(estoloc.conus_flg, 'Y', 'CONUS', 'N', 'OCONUS', '?') as conus_txt,
						  echg.level_count || ' ' || lvu.level_count_dsc AS level_disp,
							  est.estimate_no,
						  echg.estimate_charge_id as charge_id,
						  echg.finance_cd
  
					  FROM  t_estimate_charge_dtl edt
						INNER JOIN t_estimate_charge echg  ON echg.estimate_charge_id = edt.estimate_charge_id
						INNER JOIN r_level_unit lvu      ON lvu.level_unit_id = echg.level_unit_id
						INNER JOIN r_unit_type ut      ON ut.unit_type_cd = lvu.unit_type_cd
						INNER JOIN t_cargo_activity ca    ON ca.cargo_activity_id = edt.cargo_activity_id
						INNER JOIN t_cargo c        ON c.cargo_id = ca.cargo_id
						INNER JOIN t_booking bk        ON bk.booking_id = c.booking_id
						INNER JOIN r_location oloc      ON oloc.location_cd = ca.orig_location_cd
						INNER JOIN r_location dloc      ON dloc.location_cd = ca.dest_location_cd
						INNER JOIN r_vessel ves        ON ves.vessel_cd = bk.vessel_cd
						LEFT OUTER JOIN t_estimate est
						  INNER JOIN r_location estoloc  ON estoloc.location_cd = est.orig_location_cd
						  INNER JOIN r_location estdloc  ON estdloc.location_cd = est.dest_location_cd
										  ON est.estimate_id = ca.estimate_id
						LEFT OUTER JOIN r_customer cust    ON cust.customer_cd = bk.customer_cd
						LEFT OUTER JOIN t_contract_mod cmod ON cmod.contract_mod_id = c.contract_mod_id
						left outer join r_charge_type ct on ct.charge_type_cd = echg.charge_type_cd
					  WHERE  edt.voyage_no like '{0}'
						AND  bk.customer_ref like '{1}'
						AND  c.serial_no like '{2}'
						AND bk.pol_location_cd like '{3}'
						and bk.pod_location_cd like '{4}'
						and ca.orig_location_cd like '{5}'
						and ca.dest_location_cd like '{6}'
                        and echg.finance_cd like '{7}'
					  ORDER BY est.estimate_id,lvu.level_cd, ct.charge_category_cd, echg.charge_type_cd,
					   c.cargo_dsc, c.serial_no", sVoyageNo, sPCFN, sSerialNo, sPOL, sPOD, sOrigin, sDestination, sFinance_cd);

			DataTable dt = Connection.GetDataTable(sql);
			return dt;

						//AND  bk.customer_ref like '{1}'
						//AND  c.serial_no like '{2}'
						//AND bk.pol_location_cd like '{3}'
						//and bk.pod_location_cd like '{4}'
						//and ca.orig_location_cd like '{5}'
						//and ca.dest_location_cd like '{6}'

		}
	}
}
