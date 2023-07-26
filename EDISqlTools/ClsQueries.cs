using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using CS2010.Common;

namespace ASL.ARC.EDISQLTools
{
	public class ClsQueries
	{
		public static ClsConnection cnLINE
		{
			get { return ClsConMgr.Manager["LINE"]; }
		}

		public static ClsConnection cnAROF
		{
			get { return ClsConMgr.Manager["ArcSys"]; }
		}

		public static DataTable GetUnsentBookings()
		{
			// This returns a list of bookings that have not been sent to TOPS. 
			// These need to be investigated to make sure all mandatory data
			// has been entered, then manually sent in LINE.

			StringBuilder sb = new StringBuilder();
			sb.Append(@"
						SELECT     bu1voyage, bu1vessel, bu1bunr, bu1bumanr, bu1budate, bu1loesch AS Cancel_flg, bu1bumanr AS Expr1, bu1service, bu1rmanr,
							bu1polcde, bu1podcde
						FROM         dba.bu1_kopf
						WHERE     (bu1bumanr NOT IN
                          (SELECT     ebubumanr
                            FROM          dba.edi_sent_rcvd_bu
                            WHERE      (ebusndrcvkz = 'S'))) AND (bu1polcde IN ('USBAL', 'GBSOU', 'BEZEE')) AND (bu1createdat > getdate() - 30) AND (bu1loesch = 'N') AND 
                      (NOT EXISTS
                          (SELECT     bu3contkz
                            FROM          dba.bu3_item
                            WHERE      (bu3bumanr = dba.bu1_kopf.bu1bumanr) AND (bu3contkz = 'Y') OR
                                                   (bu3bumanr = dba.bu1_kopf.bu1bumanr) AND (bu3comcde = 'MAFI')))
						");
			DataTable dt = cnLINE.GetDataTable(sb.ToString());
			return dt;
		}

		public static DataTable GetUnsentBOLs()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(@"

				SELECT bl1voyage, bl1vessel, bl1podcde, bl1blnr, bl1blmanr, bl1issdat, bl1finalmanifestkz
				 FROM  dba.bl1_kopf
				WHERE (bl1podcde IN ('USBAL', 'GBSOU', 'BEZEE')) 
				  AND (bl1issdat > getdate() - 30) 
				  AND (bl1finalmanifestkz = 'Y') 
				  AND (NOT EXISTS
						(SELECT firma
						   FROM dba.edi_sent_rcvd_bl
						  WHERE (edi_sent_rcvd_bl.eblblmanr = dba.bl1_kopf.bl1blmanr)
                            AND ebleditype = 'EXPORT B/L'))
				");
			DataTable dt = cnLINE.GetDataTable(sb.ToString());
			return dt;
		}
		public static DataTable GetVoyages()
		{
			string sql = @"
				SELECT rermanr as Code,
                       rereisenr as Description
				  FROM dba.reise
                WHERE firma = 'ARC'
				 GROUP BY rermanr, rereisenr
				 ORDER BY rereisenr";
			DataTable dt = cnLINE.GetDataTable(sql);
			return dt;

		}
		public static DataTable GetVoyagePorts(string sVoyage)
		{
			string sql = @"
				SELECT dba.reise.rermanr, dba.reise_hafen.rhseqno, dba.reise_hafen.rhhafen as Code, dba.reise.rereisenr
				FROM   dba.reise, dba.reise_hafen
				WHERE  dba.reise.firma = dba.reise_hafen.firma AND dba.reise.rermanr = dba.reise_hafen.rhrmanr
                   AND rereisenr = '@VOYAGE'";
			sql = sql.Replace("@VOYAGE", sVoyage);
			DataTable dt = cnLINE.GetDataTable(sql);
			return dt;
		}
		public static DataTable GetVoyagePortType(string sVoyage)
		{
			string sql = @"
				SELECT dba.reise.rermanr ID, dba.reise_hafen.rhseqno SeqNo, 
				rhporttype as PortType, rhhafen as Port, rhetseta as SailDate,
				rhhafen + ' ' + CONVERT(varchar(20),  rhetseta) as Description
				FROM   dba.reise, dba.reise_hafen
				WHERE  dba.reise.firma = dba.reise_hafen.firma AND dba.reise.rermanr = dba.reise_hafen.rhrmanr
                   AND rermanr = @VOYAGE
			       AND dba.reise.firma = 'ARC' ";
			sql = sql.Replace("@VOYAGE", sVoyage);
			DataTable dt = cnLINE.GetDataTable(sql);
			return dt;
		}
		public static DataTable GetInvalidSerialNo(string sBOLNo)
		{
			StringBuilder sql = new StringBuilder();
			sql.AppendFormat(@"

				SELECT 'BOLBB' as item_type,
					   dba.bl14_itemdetail.bl14trackingref as tcn, 
					   dba.bl1_kopf.bl1blnr as bol_no,
					   dba.bl14_itemdetail.bl14_itemdetail_id as itemdetail_id,
                       substring(bl1blnr,1,9) as prefix,
					   LEN(dba.bl14_itemdetail.bl14trackingref) as tcn_length,
					   bl1issdat as issuedt, bl1podcde as pod
				FROM   dba.bl14_itemdetail 
			   INNER JOIN dba.bl1_kopf ON dba.bl14_itemdetail.firma = dba.bl1_kopf.firma 
				      AND dba.bl14_itemdetail.bl14manr = dba.bl1_kopf.bl1blmanr
				WHERE  (dba.bl14_itemdetail.bl14trackingref IS NOT NULL) 
				  AND (LEN(dba.bl14_itemdetail.bl14trackingref) > 25)
				  and (dba.bl1_kopf.bl1blnr = '{0}'  ) ", sBOLNo);

			return cnLINE.GetDataTable(sql.ToString());
		}

		public static DataTable GetInvalidSerialNo(bool AllBills)
		{
			StringBuilder sql = new StringBuilder();
			sql.AppendFormat(@"
				SELECT 'BOLBB' as item_type,
					   dba.bl14_itemdetail.bl14trackingref as tcn, 
					   dba.bl1_kopf.bl1blnr as bol_no,
					   dba.bl14_itemdetail.bl14_itemdetail_id as itemdetail_id,
                       substring(bl1blnr,1,9) as prefix,
					   LEN(dba.bl14_itemdetail.bl14trackingref) as tcn_length,
					   bl1issdat as issuedt, bl1podcde as pod
				FROM   dba.bl14_itemdetail 
			   INNER JOIN dba.bl1_kopf ON dba.bl14_itemdetail.firma = dba.bl1_kopf.firma 
				      AND dba.bl14_itemdetail.bl14manr = dba.bl1_kopf.bl1blmanr
				WHERE  (dba.bl14_itemdetail.bl14trackingref IS NOT NULL) 
				  AND (LEN(dba.bl14_itemdetail.bl14trackingref) > 25)
				  AND ( bl1podcde in ('USBAL','GBSOU','BEZEE')) ");

			if (!AllBills)
			{
				sql.AppendFormat(" and bl1issdat > getdate() - 180 ");
			}
			sql.AppendFormat(" ORDER BY dba.bl1_kopf.bl1blnr ");

			DataTable dt = cnLINE.GetDataTable(sql.ToString());
			return dt;

		}
		public static DataRow GetMvVoyage(string sVoyageNo)
		{
			string sql = string.Format("select * from mv_voyage where voyage_cd = '{0}'", sVoyageNo);
			DataTable dt = cnAROF.GetDataTable(sql);
			if (dt == null)
				return null;
			if (dt.Rows.Count < 1)
				return null;
			return dt.Rows[0];
		}

		public static DataTable GetSDDCLocation(string sLocation)
		{
			string sql = string.Format("select l.* from v_acms_location l  where location_cd = '{0}'", sLocation);
			return cnAROF.GetDataTable(sql);
		}

		public DateRange dtPOL;
		public string sCargoStatus;
		public string sVoyage;
		public string sVessel;
		public string sPLOR;
		public string sPOL;
		public string sPOD;
		public string sPLOD;

		public DataTable IALCargoSearch()
		{
			// OCT 2018 DGERDNER : use a new r_ial_rate table to compute rates, rather than hardcoding each year
			StringBuilder sb = new StringBuilder();
			List<DbParameter> p = new List<DbParameter>();
			sb.AppendFormat(@"
				        select c.*, si.*, sail_dt, c.model_cd,    
				(select rate_amt from r_ial_rate 
			 where rate_type_cd = c.model_cd and effective_dt = (    
			select max(effective_dt)
			 from r_ial_rate     
			  where rate_type_cd = c.model_cd
			   and effective_dt < sail_dt) )
               as freight_amt,
             case 
             when f_voyage_actual_flg(c.voyage_no, pod_location_cd, pod_berth, 'D') = 'Y' then
                  f_voyage_dt(c.voyage_no, pod_location_cd, pod_berth, 'D')
             else null end as actual_arrive_dt,
             nvl(si.first_nm,'') || ' ' || nvl(si.last_nm,'') as full_nm,
             1 as units, 'NTFR' as charge_cd,
			 (select rate_amt from r_ial_rate 
			 where rate_type_cd = c.model_cd and effective_dt = (    
			select max(effective_dt)
			 from r_ial_rate     
			  where rate_type_cd = c.model_cd
			   and effective_dt < sail_dt) )             
               as statistic_amt,  
			0 as BYD
               
         from v_booking_cargo_line c
          inner join r_trading_partner_customer tpc
              on tpc.customer_cd = c.customer_cd
              and tpc.trading_partner_cd = 'IAL'
              and c.booking_dt > '01-JAN-2015'
          left outer join t_edi_inbound_si si on si.booking_no = c.booking_no
                           and si.vin = c.serial_no 
          where 1 = 1 ");

			if (sCargoStatus.ToLower() != "all")
				sb.AppendFormat(" and cargo_status <> 'BOOK' ");

			cnAROF.AppendLikeClause(sb, p, "AND", "voyage_no", "@VOYCD", sVoyage);
			cnAROF.AppendLikeClause(sb, p, "AND", "vessel_cd", "@VESCD", sVessel);
			cnAROF.AppendDateClause(sb, p, "AND", "sail_dt", "@POLETS1", "@POLETS2", dtPOL);
			cnAROF.AppendLikeClause(sb, p, "AND", "plor_location_cd", "@PLOR", sPLOR);
			cnAROF.AppendLikeClause(sb, p, "AND", "pol_location_cd", "@POL", sPOL);
			cnAROF.AppendLikeClause(sb, p, "AND", "pod_location_cd", "@POD", sPOD);
			cnAROF.AppendLikeClause(sb, p, "AND", "plod_location_cd", "@PLOD", sPLOD);

			string sql = sb.ToString();
			DataTable dt = cnAROF.GetDataTable(sql, p.ToArray());


            // 2018-03-19: Hard-coding a Battery Disconnect Charge of $200.00 if the
            // cargo is a battery disconnect 'CARBD' or 'VANBD'
            if (dt.IsNotNull())
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (this.IsCargoBD(dr["BOOKING_NO"].ToString(), dr["SERIAL_NO"].ToString())) 
                    {
                        dr["BYD"] = 200;
                    }
                }
            }


			return dt;
		}

        public bool IsCargoBD(string bookingNo, string vin)
        {
            try
            {
                string sql = @"

                    Select 
                        bk.cr1_type as cargo_type

                    from  dba.car_head bk
				        LEFT OUTER JOIN  dba.bu1_kopf kf ON bk.cr1_bumanr = kf.bu1bumanr 
				        INNER JOIN dba.kunde kd on kd.kdkdnr = kf.bu1kdnr AND kd.firma = kf.firma

                    where 1=1
				        and bk.cr1_bunr = '[BOOKING_NO]'
                        and bk.cr1_vin = '[VIN]'
                    ";

                sql = sql.Replace("[BOOKING_NO]", bookingNo.Trim());
                sql = sql.Replace("[VIN]", vin.Trim());

                DataTable dt = cnLINE.GetDataTable(sql);

                string ct = dt.Rows[0][0].ToString().ToUpper().Trim();

                return ((ct == "CARBD") || (ct == "VANBD"));

            }
            catch
            {
                return false;
            }
        }


		public static DataTable GetProvisionalInvoicing(
			DateRange dtPOL,
			string sCargoStatus,
			string sVoyage,
			string sPCFN,
			string sPLOR,
			string sPOL,
			string sPOD,
			string sPLOD)
		{
			sVoyage = sVoyage + "%";

			StringBuilder sb = new StringBuilder();
			List<DbParameter> p = new List<DbParameter>();

			sb.AppendFormat(@"
				select * from v_provisional_invoice 
				 where voyage_no like '{0}' ", sVoyage);

			if (sCargoStatus.ToLower() != "all")
				sb.AppendFormat(" and cargo_status <> 'BOOK' ");

			cnAROF.AppendDateClause(sb, p, "AND", "pol_ets", "@POLETS1", "@POLETS2", dtPOL);
			cnAROF.AppendLikeClause(sb, p, "AND", "plor_location_cd", "@PLOR", sPLOR);
			cnAROF.AppendLikeClause(sb, p, "AND", "pol_location_cd", "@POL", sPOL);
			cnAROF.AppendLikeClause(sb, p, "AND", "pod_location_cd", "@POD", sPOD);
			cnAROF.AppendLikeClause(sb, p, "AND", "plod_location_cd", "@PLOD", sPLOD);
			cnAROF.AppendLikeClause(sb, p, "AND", "partner_request_cd", "@PCFN", sPCFN);
			string sql = sb.ToString();
			DataTable dt = cnAROF.GetDataTable(sql, p.ToArray());
			return dt;
		}



		#region SDDC Invoicing
		public static DataTable GetSDDCInvoicingData(string sPCFN, string sVoyageNo)
		{
			try
			{
				StringBuilder sql = new StringBuilder();
				sql.Append(@"
					select 
					'1 HEADER' as row_type,
					 bl1blnr as bol_no,
					 bl1kdref as customer_ref_cd,
					 bu1ediref as edi_ref,
					 bl1service as service_cd,
					 bl1blmanr as bol_id,
					 bl1vessel as vessel_cd,
					 bl1vessel as vessel_nm,
					 bl1voyage as voyage_no, 
					 bl1voyage as acmsvoydoc,
					 'ROUTE' as route_id,
					 bl1plorcde as plor_location_cd, bl1polcde as pol_location_cd, 
					 bl.bl1polberth as pol_berth, bl1polcde as pol_sddc_cd,
					 bl1podcde as pod_location_cd, bl.bl1podberth as pod_berth, bl1podcde as pod_sddc_cd, 
					 bl1pldpcde as plod_location_cd,
					 bl1tariffcat1 as tariff_cd,
					 bl1mtc as customer_cd,
					 bl1vskond as move_type_cd,
					 'AROF' as scac,
					 bl1bumanr as booking_id,
					 bl1bunr as booking_no,
 
					 (SELECT  
								dba.bl2_adresse.bl2kdnr
						FROM dba.bl2_adresse
						LEFT OUTER JOIN dba.kunde ON 
							dba.bl2_adresse.firma = dba.kunde.firma
							AND dba.bl2_adresse.bl2kdnr = dba.kunde.kdkdnr
						WHERE	dba.bl2_adresse.bl2blmanr 	= bl1blmanr
							and bl2type = 'N1') as consignor_cd,
					 'NA' as consignor_sddc_cd,
					 (SELECT  
					  isnull(bl2zeile1,'') + '  ' + 
					  isnull(bl2zeile2,'') + '  ' +
					  isnull(bl2zeile3,'') + '  ' +
					  isnull(bl2zeile4,'') + '  ' +
					  isnull(bl2zeile5,'') as address_dsc
					FROM dba.bl2_adresse
					LEFT OUTER JOIN dba.kunde ON 
					dba.bl2_adresse.firma = dba.kunde.firma
					AND dba.bl2_adresse.bl2kdnr = dba.kunde.kdkdnr
					WHERE	dba.bl2_adresse.bl2blmanr 	= bl1blmanr
					 and bl2type = 'N1') as consignor_addr,
 
					 (SELECT  
								dba.bl2_adresse.bl2kdnr
						FROM dba.bl2_adresse
						LEFT OUTER JOIN dba.kunde ON 
							dba.bl2_adresse.firma = dba.kunde.firma
							AND dba.bl2_adresse.bl2kdnr = dba.kunde.kdkdnr
						WHERE	dba.bl2_adresse.bl2blmanr 	= bl1blmanr
							and bl2type = 'CN') as consignee_cd,
					 'NA' as consignee_sddc_cd,
					 (SELECT  
					  isnull(bl2zeile1,'') + '  ' + 
					  isnull(bl2zeile2,'') + '  ' +
					  isnull(bl2zeile3,'') + '  ' +
					  isnull(bl2zeile4,'') + '  ' +
					  isnull(bl2zeile5,'') as address_dsc
					FROM dba.bl2_adresse
					LEFT OUTER JOIN dba.kunde ON 
					dba.bl2_adresse.firma = dba.kunde.firma
					AND dba.bl2_adresse.bl2kdnr = dba.kunde.kdkdnr
					WHERE	dba.bl2_adresse.bl2blmanr 	= bl1blmanr
					 and bl2type = 'CN') as consignee_addr,
					 (select min(rhetseta)
					 from dba.vw_portcall_queryscreen
					  where  rereisenr = bl1voyage
					   and rhhafen = bl1polcde
					   and rhporttype in ('B','L')) as sail_dt

					 from dba.bl1_kopf bl
					  inner join dba.bu1_kopf bu 
						on bl.bl1bumanr = bu.bu1bumanr
					 where bl1agency = 'ARC'
					 and bl1mtc like '%SDDC%'
					 and bu1ediref is not null
					 ");
				sql.AppendFormat(@"
					and ( bl1kdref like '{0}' or bu1ediref like '{0}' )", sPCFN);

				if (!string.IsNullOrEmpty(sVoyageNo))
					sql.AppendFormat(@" and (bl1voyage like '{0}' )", sVoyageNo);
					
				string s = sql.ToString();
				DataTable dt = cnLINE.GetDataTable(s);

				return dt;
			}
			catch (Exception ex)
			{
				ClsErrorHandler.LogException(ex);
				return null;
			}
		}

		public static DataTable GetSDDCInvoiceItemDataOld(string sPCFN, string sType)
		{
			string sql = string.Format(@"
				select 
				   '2 ITEM',
				   v.blvanfo,
				   bu.bu1bunr as booking_no,
				   v.blvzuabcde as surcharge_cd,
				   v.blvper as charge_per_cd,
				   v.blvunit as charge_per_unit,
				   v.blvrate as charge_rate,
				   v.blvblcurcde as currency_cd,
				   v.blvposwert as item_charge_total,
				   v.blvplopcde as plop_cd,
				   v.blvitlfnr as item_no,
				   v.blvmeas as m3_line,
				   0 as m3_computed,
				   bi.bl3unitmeas as cft_line,
				   0 as cft_computed,
				   isnull(v.blvbasis,0) as cft40_line,
			       1.123 as cft40_computed,
				   bi.bl3grw as gwt_line,
				   bi.bl3nrofpa as pkg_no,
				   bi.bl3length as length_cm,
				   bi.bl3width as width_cm,
				   bi.bl3height as height_cm,
				   case
					 when bl3rorokz = 'Y' then 'RORO'
					 when bl3bbkz = 'Y' then 'BBULK'
					 else 'CONT'
				   end as cargo_type  
				 from dba.bl_value v
				  inner join dba.bl3_item bi on bi.bl3blmanr = v.blvblmanr
											and bi.bl3bllfnr = v.blvitlfnr
				  inner join dba.bl1_kopf bl on bl.bl1blmanr = v.blvblmanr
				  inner join dba.bu1_kopf bu on bl.bl1bumanr = bu.bu1bumanr
				   where (v.blvkzinvoice = 'Y' )
				   and  blvanfo like '{1}%'
				   and ( bl1kdref like '{0}' or bu1ediref like '{0}' )
				 order by  blvitlfnr, blvposno   ", sPCFN, sType);

			DataTable dt = cnLINE.GetDataTable(sql);
			return dt;
		}

		public static DataTable GetSDDCInvoiceItemData(string sPCFN, string sType)
		{
			//if (sPCFN == "77657811")
			//{
			//    string s = "x";
			//}
			string sql = string.Format(@"
				select 
				/* part one gets all details other that ntfr */
				   '2 ITEM' as row_type, bi.bl3bulfnr as item_no,   rpzuabcde as surcharge_cd,   
				   '{0}' as customer_ref_cd,
				   bk.bu1bunr as booking_no,
					bl.bl1blnr as bol_no,
				   bl.bl1blmanr as bol_id,
				   bk.bu1bumanr as booking_id,
					v.rpper as charge_per_unit,
				   v.rprate as charge_rate,   
				   v.rpcurcde as currency_cd,   
				   v.rpplopcde as plop_cd,
				   v.rpplopbez as plop_dsc,   
				   bi.bl3meas as m3_line,
				   0.00 as charge_total,
				   bi.bl3unitmeas as cft_line,
				   isnull(bi.bl3unitmeas40,0) as cft40_line,
				   bi.bl3grw as gwt_line,
				   bi.bl3nrofpa as pkg_no,
				   isnull( bi.bl3length,0) as length_cm,
				   isnull(bi.bl3width,0) as width_cm,
				   isnull(bi.bl3height,0) as height_cm,
				   round(isnull( bi.bl3length,0) * 0.393701,2) as length_in,
				   round(isnull(bi.bl3width,0) * 0.393701,2) as width_in,
				   round(isnull(bi.bl3height,0) * 0.393701,2) as height_in,
					1.123 as m3_computed,
					1.123 as cft_computed,
					1.123 as cft40_computed,
				   case
					 when bl3rorokz = 'Y' then 'RORO'
					 when bl3bbkz = 'Y' then 'BBULK'
					 else 'CONT'
				   end as cargo_type,
				   bl1voyage as voyage_no
				from dba.rechenregel_pos v
				 inner join dba.bl1_kopf bl
				  on bl.bl1rrmanr = v.rpmanr
				 inner join dba.bu1_kopf bk
					on bl.bl1bumanr = bk.bu1bumanr
				 inner join dba.bl3_item bi
				   on bi.bl3blmanr = bl.bl1blmanr
				   and bi.bl3bulfnr = v.rpitlfnr
				 where bk.bu1kdref like '{0}'
				union all
				 select 
				  /* Part 2 gets all of the other charges */
					'2 ITEM' as row_type,  bi.bl3bulfnr as item_no, ' NTFR' as surcharge_cd,
				  '{0}' as customer_ref_cd,
				   bk.bu1bunr as booking_no,
					bl.bl1blnr as bol_no,
				   bl.bl1blmanr as bol_id,
				   bk.bu1bumanr as booking_id,					
					bi.bl3per as charge_per_unit,
				   bi.bl3rate as charge_rate,
					null as currency_cd,   null as plop_cd,
				   null as plop_dsc,   
				   bi.bl3meas as m3_line,
				   0.00 as charge_total,
				   bi.bl3unitmeas as cft_line,
				   isnull(bi.bl3unitmeas40,0) as cft40_line,
				   bi.bl3grw as gwt_line,
				   bi.bl3nrofpa as pkg_no,
				   isnull( bi.bl3length,0) as length_cm,
				   isnull(bi.bl3width,0) as width_cm,
				   isnull(bi.bl3height,0) as height_cm,
				   round(isnull( bi.bl3length,0) * 0.393701,2) as length_in,
				   round(isnull(bi.bl3width,0) * 0.393701,2) as width_in,
				   round(isnull(bi.bl3height,0) * 0.393701,2) as height_in,
					1.123 as m3_computed,
					1.123 as cft_computed,
					1.123 as cft40_computed,
				   case
					 when bl3rorokz = 'Y' then 'RORO'
					 when bl3bbkz = 'Y' then 'BBULK'
					 else 'CONT'
				   end as cargo_type,
				   bl1voyage as voyage_no
				from dba.bl1_kopf bl
				 inner join dba.bu1_kopf bk
					on bl.bl1bumanr = bk.bu1bumanr
				 inner join dba.bl3_item bi
				   on bi.bl3blmanr = bl.bl1blmanr
				 where bk.bu1kdref like '{0}'
				  order by 1,2,3", 
				 sPCFN);

			DataTable dt = cnLINE.GetDataTable(sql);
			return dt;
		}

		public static DataTable GetSDDCInvoiceCargoData(string sPCFN, string sType)
		{
			/* RoRo */
			string sql = string.Format(@"
			select				   
					   'CARGO',
							   v.blvanfo,
					   v.blvblnr,
							   bu.bu1bunr as booking_no,
							   v.blvzuabcde as surcharge_cd,
							   v.blvper as charge_per_cd,
							   v.blvunit as charge_per_unit,
							   v.blvrate as charge_rate,
							   v.blvblcurcde as currency_cd,
							   v.blvposwert as item_charge_total,
					   999 as cargo_computed_total,
							   v.blvplopcde as plop_cd,
							   v.blvitlfnr as item_no,
					   car.cr1_blitem_seqno as line_link_no,
					   0.00 as m3_line_cargo,
					   1.123 as m3_computed_cargo,
					   0 as cft_line_cargo,
					   1.123 as cft_computed_cargo,
					   0.00 as cft40_line_cargo,
					   1.123 as cft40_computed_cargo,
							   bi.bl3grw as gwt_line,
							   bi.bl3nrofpa as pkg_no,
							   case
								 when bl3rorokz = 'Y' then 'RORO'
								 when bl3bbkz = 'Y' then 'BBULK'
								 else 'CONT'
							   end as cargo_type,
								car.cr1_chassis as serial_no,
					  car.cr1_length as length_cm,
					  car.cr1_width as width_cm,
					  car.cr1_height as height_cm,
					  car.cr1_weight as weight_kg,
					  1 as pkg_no_cargo,
					  dba.bu1_kopf.bu1voyage as voyage_no
				from dba.bl_value v
				inner join dba.bl3_item bi on bi.bl3blmanr = v.blvblmanr
										and bi.bl3bllfnr = v.blvitlfnr
				inner join dba.bl1_kopf bl on bl.bl1blmanr = v.blvblmanr
				inner join dba.bu1_kopf bu on bl.bl1bumanr = bu.bu1bumanr
				inner join dba.car_head car on car.cr1_bumanr = bu.bu1bumanr
											and car.cr1_blitem = bi.bl3bllfnr
				where (v.blvkzinvoice = 'Y' )
				   and  blvanfo like '{1}%'
				   and ( bu1ediref like '{0}' )
				 order by  blvitlfnr, blvposno   ", sPCFN, sType);

			DataTable dt = cnLINE.GetDataTable(sql);
			return dt;
		}

		public static DataTable GetSDDCInvoiceCargoRoRo(				string sBOLid, string sItemNo, string sChargeCd)
		{
			/* Obsolete */
			string sql = string.Format(@"
				 select 
				  cr1_manr as cargo_id,
				  '{2}' as surcharge_cd,
				  cr1_blitem as item_no,
				  cr1_chassis as serial_no,
				  car.cr1_length as length_cm,
				  car.cr1_width as width_cm,
				  car.cr1_height as height_cm,
				  car.cr1_weight as weight_kg,
				   car.cr1_blitem_seqno as line_link_no,
				   round(car.cr1_length * car.cr1_height * car.cr1_width / 1000000,4) as m3_line_cargo,
				   1.123 as m3_computed_cargo,
				   round(car.cr1_length * car.cr1_height * car.cr1_width * 35.3147 / 1000000,3) as cft_line_cargo,
				   1.123 as cft_computed_cargo,
					round(car.cr1_length * car.cr1_height * car.cr1_width * 35.3147 / 40000000,3) as cft40_line_cargo,
				   1.123 as cft40_computed_cargo,  
				  1 as pkg_no_cargo
				  from dba.car_head car
				   inner join dba.bl3_item bi  
					  on car.cr1_blmanr = bi.bl3blmanr
					  and car.cr1_blitem = bi.bl3bllfnr
				  where car.cr1_blmanr  = {0}
                    and car.cr1_blitem = {1}
				  ",
				   sBOLid, sItemNo, sChargeCd);

			DataTable dt = cnLINE.GetDataTable(sql);
			return dt;
		}

		public static DataTable GetSDDCInvoiceCargoBbulk(string sBOLid, string sItemNo, string sChargeCd)
		{
			/* OBSOLETE */
			string sql = string.Format(@"
					select 
					  bb.bl14manr as cargo_id,
					  bi.bl3bllfnr as item_no,
					  bb.bl14trackingref  as serial_no,
					  bb.bl14length as length_cm,
					  bb.bl14width as width_cm,
					  bb.bl14Height as height_cm,
					  bb.bl14weight as weight_kg,
					  bb.bl14rownr as line_link_no,
					  /*bb.bl14meas as m3_line_cargo,*/
					  round( bb.bl14length * bb.bl14width * bb.bl14height   / 1000000,1) as m3_line_cargo,
					   1.123 as m3_computed_cargo,
					  bb.bl14unitmeas as cft_line_cargo,
					  1.123 as cft_computed_cargo,
					  round( bb.bl14length * bb.bl14width * bb.bl14height *  35.3147 / 40000000,4) as cft40_line_cargo,
					   1.123 as cft40_computed_cargo,
						 1 as pkg_no_cargo
					 from dba.bl3_item bi  
					 inner join dba.bl14_itemdetail bb
					  on bb.bl14lfnr = bi.bl3bllfnr
					  and bb.bl14manr = bi.bl3blmanr
					  where bi.bl3blmanr = 64853
						  and bi.bl3bllfnr = 1 ");
			DataTable dt = cnLINE.GetDataTable(sql);
			return dt;
		}

		public static DataTable GetSDDCInvoiceCargoAll(string sBOLid)
		{

	 			string sSQL = string.Format(@"
				 select 
				  cr1_blitem as item_no, 
				   car.cr1_blitem_seqno as line_link_no,
				   cr1_manr as cargo_id,  
				   cr1_chassis as serial_no,
				   car.cr1_length as length_cm,  car.cr1_width as width_cm,  car.cr1_height as height_cm,  car.cr1_weight as weight_kg,
				   round(car.cr1_length * car.cr1_height * car.cr1_width / 1000000,4) as m3_line,   1.123 as m3_computed,
				   round(car.cr1_length * car.cr1_height * car.cr1_width * 35.3147 / 1000000,3) as cft_line,
				   1.123 as cft_computed,
				   isnull(round(car.cr1_length * car.cr1_height * car.cr1_width * 35.3147 / 40000000,3),0) as cft40_line,
				   1.123 as cft40_computed,  
				   1 as pkg_no_cargo,
				    v.rpzuabcde as surcharge_cd, v.rpper as charge_per_unit, v.rprate as charge_rate,   v.rpcurcde as currency_cd,   v.rpplopcde as plop_cd,  v.rpplopbez as plop_dsc,
					bl.bl1voyage as voyage_no
				  from dba.car_head car
				   inner join dba.bl3_item bi  
					  on car.cr1_blmanr = bi.bl3blmanr
					  and car.cr1_blitem = bi.bl3bllfnr
					inner join dba.bl1_kopf bl ON bl.firma = bi.firma AND bl.bl1blmanr = bi.bl3blmanr
					inner join dba.rechenregel_pos v on bl.bl1rrmanr = v.rpmanr and  bi.bl3bulfnr = v.rpitlfnr   
				  where car.cr1_blmanr  = {0}
				union all  
				select 
				     bi.bl3bllfnr as item_no,
				     bb.bl14rownr as line_link_no,
				     bb.bl14manr as cargo_id,    bb.bl14trackingref  as serial_no,
				     bb.bl14length as length_cm,  bb.bl14width as width_cm,  bb.bl14Height as height_cm,  bb.bl14weight as weight_kg,
				     round( bb.bl14length * bb.bl14width * bb.bl14height   / 1000000,1) as m3_line,   1.123 as m3_computed,
				     bb.bl14unitmeas as cft_line,
				     1.123 as cft_computed,
				     isnull(round( bb.bl14length * bb.bl14width * bb.bl14height *  35.3147 / 40000000,4),0) as cft40_line,
				     1.123 as cft40_computed,
					 1 as pkg_no_cargo,
					 v.rpzuabcde as surcharge_cd, v.rpper as charge_per_unit, v.rprate as charge_rate,   v.rpcurcde as currency_cd,   v.rpplopcde as plop_cd,  v.rpplopbez as plop_dsc,
					 bl.bl1voyage as voyage_no
				 from dba.bl3_item bi  
					 inner join dba.bl14_itemdetail bb
					  on bb.bl14lfnr = bi.bl3bllfnr
					  and bb.bl14manr = bi.bl3blmanr
					 inner join dba.bl1_kopf bl ON bl.firma = bi.firma AND bl.bl1blmanr = bi.bl3blmanr
					 inner join dba.rechenregel_pos v on bl.bl1rrmanr = v.rpmanr and  bi.bl3bulfnr = v.rpitlfnr   
				  where bi.bl3blmanr = {0}
				  order by 1,2,3", sBOLid );

			DataTable dt = cnLINE.GetDataTable(sSQL);
			return dt;


		}

		public static DataTable GetSDDCInvoiceCargoAll(string sBOLid, string sItemNo, string sChargeCd, string sPCFN)
		{

			try
			{
				//sChargeCd = sChargeCd.Trim();
				string sSQL = string.Format(@"
				 select 
				  '3 CARGO' as row_type,
				  cr1_blitem as item_no, 
					'{2}' as surcharge_cd,
				  '{3}' as customer_ref_cd,
				   car.cr1_blitem_seqno as line_link_no,
				  cr1_manr as cargo_id,  
				  cr1_chassis as serial_no,
				  car.cr1_length as length_cm,  
				  car.cr1_width as width_cm,  
				  car.cr1_height as height_cm,  
				  round(car.cr1_length * .393701, 2) as length_in,  
				  round(car.cr1_width * .393701,2) as width_in,  
				  round(car.cr1_height * .393701,2) as height_in,  

				  car.cr1_weight as weight_kg,
				  round(car.cr1_weight * 2.20462,0) as weight_lbs,
				   round(car.cr1_length * car.cr1_height * car.cr1_width / 1000000,4) as m3_line,   1.123 as m3_computed,
				   round(car.cr1_length * car.cr1_height * car.cr1_width * 35.3147 / 1000000,3) as cft_line,
				   1.123 as cft_computed,
				 isnull(round(car.cr1_length * car.cr1_height * car.cr1_width * 35.3147 / 40000000,3),0) as cft40_line,
				   1.123 as cft40_computed,  
				  1.12 as charge_total,
				  1 as pkg_no_cargo,
				  isnull(v.rpper,0) as charge_per_unit,
                  isnull(v.rprate, 0) as charge_rate,
                  isnull(v.rpcurcde,'') as currency_cd,
                  isnull(v.rpplopcde,'') as plop_cd,
                  isnull(v.rpplopbez,'') as plop_dsc,
				  cast('1753-1-1' as datetime) as x1_dt,
				  bl.bl1voyage as voyage_no,
				  bl.bl1voyage + bk.bu1kdref as invoice_no,
				  'STANDARD' as contract_type,
				  'AROF' as scac_cd,
				  'HTC711-12-D-W004' as contractNo,
				  'RORO' as cargo_type,
				  'DTL' as trans_id_cd,
				  '' as consignor_sddc_cd,
				  '' as consignor_addr,
				  '' as consignee_sddc_cd,
				  '' as consignee_addr
				  from dba.car_head car
				   inner join dba.bl3_item bi  
					  on car.cr1_blmanr = bi.bl3blmanr
					  and car.cr1_blitem = bi.bl3bllfnr
					inner join dba.bl1_kopf bl ON bl.firma = bi.firma AND bl.bl1blmanr = bi.bl3blmanr 
				    inner join dba.bu1_kopf bk on bl.bl1bumanr = bk.bu1bumanr
					left outer join dba.rechenregel_pos v on bl.bl1rrmanr = v.rpmanr and  bi.bl3bulfnr = v.rpitlfnr and v.rpzuabcde = '{2}'
				  where car.cr1_blmanr  = {0}
				   and cr1_blitem = {1}
				union all  
				select 
				  '3 CARGO' as row_type,
				  bi.bl3bllfnr as item_no,
				  '{2}' as surcharge_cd,
				  '{3}' as customer_ref_cd,
				  bb.bl14rownr as line_link_no,
				  bb.bl14manr as cargo_id,    bb.bl14trackingref  as serial_no,
				  bb.bl14length as length_cm,  
				  bb.bl14width as width_cm,  
				  bb.bl14Height as height_cm,  
				  round(bb.bl14length * .393701, 2) as length_in,  
				  round(bb.bl14width * .393701, 2) as width_in,  
				  round(bb.bl14Height * .393701, 2) as height_in,  

				  bb.bl14weight as weight_kg,
				  round(bb.bl14weight * 2.20462,0) as weight_lbs,
				  round( bb.bl14length * bb.bl14width * bb.bl14height   / 1000000,1) as m3_line_cargo,   1.123 as m3_computed,
				  bb.bl14unitmeas as cft_line,
				  1.123 as cft_computed,
				  isnull(round( bb.bl14length * bb.bl14width * bb.bl14height *  35.3147 / 40000000,4),0) as cft40_line,
				     1.123 as cft40_computed,
				  1.12 as charge_total,
					 1 as pkg_no,
				  isnull(v.rpper,0) as charge_per_unit,
                  isnull(v.rprate, 0) as charge_rate,
                  isnull(v.rpcurcde,'') as currency_cd,
                  isnull(v.rpplopcde,'') as plop_cd,
                  isnull(v.rpplopbez,'') as plop_dsc,
				  cast('1753-1-1' as datetime) as x1_dt,
				  bl.bl1voyage as voyage_no,
				  bl.bl1voyage + bk.bu1kdref as invoice_no,
				  'STANDARD' as contract_type,
				  'AROF' as scac_cd,
				  'HTC711-12-D-W004' as contractNo,
				  'BREAKBULK' as cargo_type,
				  'DTL' as trans_id_cd,
				  '' as consignor_sddc_cd,
				  '' as consignor_addr,
				  '' as consignee_sddc_cd,
				  '' as consignee_addr
				 from dba.bl3_item bi  
				 inner join dba.bl14_itemdetail bb
				  on bb.bl14lfnr = bi.bl3bllfnr
				  and bb.bl14manr = bi.bl3blmanr
					inner join dba.bl1_kopf bl ON bl.firma = bi.firma AND bl.bl1blmanr = bi.bl3blmanr
					inner join dba.bu1_kopf bk on bl.bl1bumanr = bk.bu1bumanr
					left outer join dba.rechenregel_pos v on bl.bl1rrmanr = v.rpmanr and  bi.bl3bulfnr = v.rpitlfnr   and v.rpzuabcde = '{2}'

				  where bi.bl3blmanr = {0}
					  and bi.bl3bllfnr = {1} 
				  order by 1,2,3", sBOLid, sItemNo, sChargeCd, sPCFN);

				DataTable dt = cnLINE.GetDataTable(sSQL);
				return dt;
			}
			catch (Exception ex)
			{
				string s = ex.Message;
				throw ex;
			}

		}

		public static DataTable GetblvanfoValues(string sPCFN)
		{
			/* OBSOLETE */
			string sSQL = string.Format(@"
				select distinct blvanfo
				from dba.bl_value v
				 inner join dba.bl1_kopf bl
				  on v.blvblmanr = bl.bl1blmanr
				 inner join dba.bu1_kopf bk
					on bl.bl1bumanr = bk.bu1bumanr
				 inner join dba.bl3_item bi
				   on bi.bl3blmanr = v.blvblmanr
				   and bi.bl3bulfnr = v.blvitlfnr
				where bk.bu1kdref like '{0}%' ", sPCFN);

	           return cnLINE.GetDataTable(sSQL);
		}

		public static string GetTranslateCode(string sInterface, string sCode)
		{
			string sSQL = string.Format(@"
				SELECT  ediinterface as interface_cd, 
				  ediexportcode as export_cd, 
				  edikdkdnr as import_cd, 
				  edikdmtc as customer_dsc
				FROM dba.edicode      
				WHERE dba.edicode.firma = 'ARC' and          
				 dba.edicode.ediinterface like '{0}' and
				 dba.edicode.edikdkdnr = '{1}'", sInterface, sCode);

			DataRow dr = cnLINE.GetDataRow(sSQL);
			if (dr == null)
				return sCode;
			return dr["export_cd"].ToString();
		}

		public static int CubeSDDC(decimal len, decimal width, decimal height)
		{
			int iResult = 0;
			int iLen, iWidth, iHeight;
			decimal dWork;

			len = len * .393701M;
			width = width * .393701M;
			height = height * .393701M;

			// Converth dims to integer
			iLen = ClsConvert.ToInt32(len);
			iWidth = ClsConvert.ToInt32(width);
			iHeight = ClsConvert.ToInt32(height);

			// Compute raw cft, rounded to 3 decimals
			dWork = Math.Round(iLen * iWidth * iHeight / 1728M, 3);
			dWork = Math.Round(dWork, 3);

			// The following will round it up if there are any digits
			// to the right of the decimal place.
			dWork = dWork + .999M;
			iResult = (int)Math.Truncate(dWork);
						
			return iResult;
		}

		public static decimal Cube40SDDC(decimal len, decimal width, decimal height, string sChargePer)
		{
			//if (!sChargePer.ToUpper().Contains("40FT"))
			//    return 1;

			decimal dResult = CubeSDDC(len, width, height);
			dResult = Math.Round(dResult / 40, 3);
			return dResult;
		}

		public static decimal M3SDDC(decimal len, decimal width, decimal height)
		{
			decimal dM3;
			dM3 =  len * width * height;
			dM3 = Math.Round(dM3 / 1000000, 3);
			return dM3;
		}

		public static DataTable LINEChargePerCodes()
		{
			string sql = "select blvper from dba.bl_value group by blvper order by blvper";
			DataTable dt = cnLINE.GetDataTable(sql);
			return dt;
		}

		#endregion

		#region Test Voyages
		public static DataTable SearchVoyages(string sVessel, string sVoyage)
		{
			if (string.IsNullOrEmpty(sVoyage))
				sVoyage = "%";
			if (string.IsNullOrEmpty(sVessel))
				sVessel = "%";
			string sql = string.Format(@"
				select voy.vessel_cd,  location_cd, pol_pod, terminal_cd, arrival_dt, departure_dt, voy.voyage_cd,  military_voyage_cd
				 from mv_voyage_route_detail vrd
				  inner join mv_voyage voy on voy.voyage_cd = vrd.voyage_cd
				  where voy.voyage_cd like '{0}'
                    and voy.vessel_cd like '{1}'
				   order by arrival_dt ", sVoyage, sVessel);

			return cnAROF.GetDataTable(sql);
		}

		#endregion

	}
}
