using System;
using System.Collections.Generic;
using System.Text;
using CS2010.Common;
using System.Data;
using CS2010.ArcSys;

namespace CS2010.ArcSys.Business
{
	static public class ClsLineSQL
	{
		#region Fields and Properties
		#region Connection and DataTables
		private static ClsConnection Connection
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
		public static bool ConnectToLINE()
		{
			return ConnectToLINE("PROD");
		}
		public static bool ConnectToLINE(string sArg)
		{
			string sConnect;
			if (sArg.Contains("DEV"))
			{
				//tmp = "LineTest";
				//ClsEnvironment.ConnectionStringName = tmp;
				//ClsConfig.SectionName = ClsEnvironment.ConnectionStringName;
				sConnect = "packet size=4096;user id=line-edi-user;password=dg20100512;data source=SQLCLUSTER;persist security info=True;initial catalog=TestDB_Line_cs";
			}
			else
			{
				sConnect = "packet size=4096;user id=line-edi-user;password=dg20100512;data source=SQLCLUSTER;persist security info=True;initial catalog=Line_cs;";
			}
			ClsConnection line = new ClsConnection(sConnect, "System.Data.SqlClient");
			line.DbConnectionKey = "LINE";
			ClsConMgr.Manager.AddConnection(line);
			return true;
		}
		#endregion

		#region Select Clauses

		#endregion

		#endregion

		#region Methods
		public static string VoyageNoStripped(string VoyageNo)
		{
			if( VoyageNo.Length < 6 )
				return VoyageNo.Trim();
			VoyageNo = VoyageNo.Substring(0, 5);
			return VoyageNo;
		}

		private static string CleanSerialNo(string serialno)
		{
			//  Removes extraneous and invalid data from a serial#
			serialno = serialno.Replace("'", "");
			serialno = serialno.Replace("+", "");
			serialno = serialno.Replace("-", "");
			serialno = serialno.Replace("_", "");
			serialno = serialno.Trim();
			return serialno;
		}

		public static string GetBookingStatus(string sBookingID, string sSerialNo)
		{
			StringBuilder sSQL = new StringBuilder();
			sSQL.AppendFormat(@"select max(etq_eventtype) 
							from dba.event_tracking_queue
                           where etq_docnr = '#DOCNO#'
                             and etq_cargoref = '#SERIAL#' ");

			sSQL = sSQL.Replace("#DOCNO#", sBookingID);
			sSQL = sSQL.Replace("#SERIAL#", sSerialNo);

			string sStatus =  Connection.GetScalar(sSQL.ToString()) as string;
			return sStatus;
		}

		public static Boolean DoesCargoExist(string sBookingNo, string sTCN)
		{
			StringBuilder sSQLBB = new StringBuilder();
			sSQLBB.AppendFormat(@"
					SELECT *
					FROM   dba.bu14_itemdetail INNER JOIN
					  		dba.bu3_item ON dba.bu14_itemdetail.bu14manr = dba.bu3_item.bu3bumanr 
						AND dba.bu14_itemdetail.bu14lfnr = dba.bu3_item.bu3bulfnr 
                      INNER JOIN dba.bu1_kopf ON dba.bu3_item.bu3bumanr = dba.bu1_kopf.bu1bumanr
					WHERE   (dba.bu1_kopf.bu1bunr = '{0}') 
					  AND (dba.bu14_itemdetail.bu14trackingref = '{1}')",
				sBookingNo, sTCN);

			DataTable dt = Connection.GetDataTable(sSQLBB.ToString());
			if (dt == null)
				return false;
			if (dt.Rows.Count < 1)
				return false;
			return true;
		}

		public static string GetCargoStatus(string sBookingId, string sSerialNo)
		{
			StringBuilder sSQLBB = new StringBuilder();
			sSQLBB.AppendFormat(@"
					SELECT dba.bu14_itemdetail.bu14status
					FROM   dba.bu14_itemdetail INNER JOIN
					  		dba.bu3_item ON dba.bu14_itemdetail.bu14manr = dba.bu3_item.bu3bumanr 
						AND dba.bu14_itemdetail.bu14lfnr = dba.bu3_item.bu3bulfnr 
                      INNER JOIN dba.bu1_kopf ON dba.bu3_item.bu3bumanr = dba.bu1_kopf.bu1bumanr
					WHERE   (dba.bu1_kopf.bu1bunr = '{0}') 
					  AND (dba.bu14_itemdetail.bu14trackingref = '{1}')",
				sBookingId, sSerialNo);

			StringBuilder sSQL = new StringBuilder();
			sSQL.AppendFormat(@"
				SELECT     cr1_ecstatus
				FROM         dba.car_head
				WHERE     (cr1_bunr = '{0}') AND (CR1_VIN LIKE '{1}')",
				sBookingId, sSerialNo);
			string sStatus = Connection.GetScalar(sSQL.ToString()) as string;

			if( string.IsNullOrEmpty(sStatus) )
			{
				sStatus = Connection.GetScalar(sSQLBB.ToString()) as string ;
			}
			return sStatus;
		}

		public static string GetCargoKOP(string sBookingNo, string sTCN)
		{
			StringBuilder sSQL = new StringBuilder();
			string sKOP = null;
			sSQL.AppendFormat(@"
					SELECT Max(bu3kopcde) as kop
					FROM   dba.bu14_itemdetail INNER JOIN
					  		dba.bu3_item ON dba.bu14_itemdetail.bu14manr = dba.bu3_item.bu3bumanr 
						AND dba.bu14_itemdetail.bu14lfnr = dba.bu3_item.bu3bulfnr 
                      INNER JOIN dba.bu1_kopf ON dba.bu3_item.bu3bumanr = dba.bu1_kopf.bu1bumanr
					WHERE   (dba.bu1_kopf.bu1bunr = '{0}') ",
				sBookingNo, sTCN);
			DataTable dt = Connection.GetDataTable(sSQL.ToString());
			if (dt.Rows.Count > 0)
			{
				sKOP = dt.Rows[0]["kop"].ToString();
			}
			return sKOP;
		}

		public static bool ResendBooking(string sBumanr, string sBookingNo, string sRmanr, string sVoyage, string sService, string sVessel)
		{
			Connection.TransactionBegin();
			try
			{
				DeleteFromEDIQueue(sBookingNo);
				UpdateETQ(sBookingNo);
				UpdateKOPF(sBookingNo);
				AddToEQIQueue(sBumanr, sBookingNo, sRmanr, sVoyage, sService, sVessel);
				Connection.TransactionCommit();
				return true;
			}
			catch( Exception ex )
			{
				ClsErrorHandler.LogException(ex);
				Connection.TransactionRollback();
				return false;
			}
		}

		public static int DeleteFromEDIQueue(string sBookingNo)
		{
			StringBuilder sSQL = new StringBuilder();
			sSQL.AppendFormat(@"
				DELETE FROM dba.edi_sent_rcvd_bu
				WHERE     (ebumsgref = '{0}')", sBookingNo);

			int i = Connection.RunSQL(sSQL.ToString());
			return i;
		}

		public static int UpdateETQ(string sBookingNo)
		{
			StringBuilder sSQL = new StringBuilder();
			sSQL.AppendFormat(@"
				Update dba.event_tracking_queue
				 set etq_status = 'S'
				 where etq_docnr = '{0}'", sBookingNo);
			return Connection.RunSQL(sSQL.ToString());
		}

		public static int UpdateKOPF(string sBookingNo)
		{
			StringBuilder sSQL = new StringBuilder();
			sSQL.AppendFormat(@"
				UPDATE dba.bu1_kopf
				SET bu1messagetype = NULL, bu1transmdat = NULL
				WHERE(bu1bunr = '{0}')", sBookingNo);
			return Connection.RunSQL(sSQL.ToString());
		}

		public static int UpdateSPSLog(string sManr, string sVoyManr, string sService)
		{
			string sql = string.Format(@"
			 insert into dba.sps_booking_change_log
			  values
			   (getdate(), 'ARC', {0}, '{2}', {1}, 'U', null, null,null, null) ", sManr, sVoyManr, sService);

			return Connection.RunSQL(sql);
		}

		public static DataTable FindSPSLog(string sManr, string sVoyManr)
		{
			string sql = string.Format(@"
				select * from dba.sps_booking_change_log
				 where sbcl_bkg_voyage_id = {0}
				  and sbcl_bkg_internal_id = {1}
				  and sbcl_transmit_action is null ", sVoyManr, sManr);
			DataTable dt = Connection.GetDataTable(sql);
			return dt;
		}

		public static int AddToEQIQueue(string sBumanr, string sBookingNo, string sRmanr, string sVoyage, string sService, string sVessel)
		{
			StringBuilder sSQL = new StringBuilder();
			sSQL.AppendFormat(@"
			insert into dba.edi_schedule 
			 select 'ARC','300_RCVR', null, null,
                    getdate(),  5, {0}, 
                    '{1}', 'S', 
                    getdate(), 'DAVGE', {2}, '{3}', 
                    '{4}', '{5}', null, 
                    null, null, null, 
                    null, null", 
				sBumanr, sBookingNo, sRmanr, sVoyage, sService, sVessel);
			return Connection.RunSQL(sSQL.ToString());
		}

		public static int Update300Schedule(long? BookingID)
		{
			// Currently hardcoded the ID that is set aside specifically for these.
			// Might need to delete then add, instead.
			string sql = string.Format(@"
				delete from dba.temp where tmpfirma = 'ARC' and tmpuser = 'DAVGE' and tmpformat = 'ANSI300E'");
			Connection.RunSQL(sql);

			sql = string.Format(@"
				insert into dba.[temp]
				 (tmpfirma, tmpagency, tmpuser, tmpspid, tmpreport, tmpformat, tmpsprache, tmpservice, tmpblmanr)
				 values ('ARC', 'ARC', 'DAVGE', 92, 'EXPORT BOOKING', 'ANSI300E', 'E','E', {0}) ", BookingID);
			int iReturn = Connection.RunSQL(sql);
			return iReturn;
		}
		public static int Update310Schedule(long? BOLID)
		{
			// Currently hardcoded the ID that is set aside specifically for these.
			// Might need to delete then add, instead.
			string sql = string.Format(@"
				delete from dba.temp where tmpfirma = 'ARC' and tmpuser = 'DAVGE' and tmpformat = 'ANSI310E'");
			Connection.RunSQL(sql);

			sql = string.Format(@"
				insert into dba.[temp]
				 (tmpfirma, tmpagency, tmpuser, tmpspid, tmpreport, tmpformat, tmpsprache, tmpservice, tmpblmanr)
				 values ('ARC', 'ARC', 'DAVGE', 92, 'EXPORT MANIFEST', 'ANSI310E', 'E','E', {0}) ", BOLID);
			int iReturn = Connection.RunSQL(sql);
			return iReturn;
		}

		public static DataRow GetVoyageDetail(string sID, string sSeqNo)
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendFormat(@"
				select * from dba.reise_hafen
                	WHERE 
						firma = 'ARC' AND 
						rhrmanr = {0} AND 
						rhseqno = {1} ",
					sID, sSeqNo);
			DataRow dr = Connection.GetDataRow(sb.ToString());
			return dr;
		}
		public static int UpdatePortType(string sID, string sSeqNo, string sType)
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendFormat(@"
					UPDATE 
							dba.reise_hafen 
					SET 
							rhporttype = '{0}' 
					WHERE 
							firma = 'ARC' AND 
							rhrmanr = {1} AND 
							rhseqno = {2} ",
					sType, sID, sSeqNo);
			int i = Connection.RunSQL(sb.ToString());
			return i;
		}

		public static int UpdateSerialNo_BL_BB(int ID, string SerialNo)
		{
			// Updates serial number in the B/L for BreakBulk
			StringBuilder sql = new StringBuilder();
			sql.AppendFormat(@"
				update dba.bl14_itemdetail
                  set bl14trackingref = '{0}'
                 where bl14_itemdetail_id = {1}",
				 SerialNo, ID);
			int iReturn = Connection.RunSQL(sql.ToString());
			return iReturn;
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

			return Connection.GetDataTable(sql.ToString());
		}

		public static DataTable GetLocations()
		{
			string sql = @"
					SELECT firma, lccode, lcname, lcland, lctype, lcdefslcode
					FROM dba.lokation
					WHERE     (firma = 'ARC') ";
			DataTable dt = Connection.GetDataTable(sql);
			return dt;
		}
		#endregion

		#region Queries
		public static DataTable GetVoyages()
		{
			string sql = @"
				SELECT rermanr as Code,
                       rereisenr as Description
				  FROM dba.reise
                WHERE firma = 'ARC'
				 GROUP BY rermanr, rereisenr
				 ORDER BY rereisenr";
			DataTable dt = Connection.GetDataTable(sql);
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
			       AND dba.reise.firma = 'ARC'
				 order by rhetseta";
			sql = sql.Replace("@VOYAGE", sVoyage);

			DataTable dt = Connection.GetDataTable(sql);
			return dt;
		}

		public static DataTable GetByBookingNo(string sBookingNo)
		{
			string sql = string.Format(@"
						select * from dba.bu1_kopf where bu1bunr = '{0}'",
							 sBookingNo);

			return Connection.GetDataTable(sql);
		}
		public static Int64? GetBookingID(string sBookingNo)
		{
			DataTable dt = GetByBookingNo(sBookingNo);

			if (dt.Rows.Count < 1)
				return null;
			string s = dt.Rows[0]["bu1bumanr"].ToString();
			Int64? i = ClsConvert.ToInt64Nullable(s);
			return i;
		}

		public static DataTable GetByBOLNo(string sBOLNo)
		{
			string sql = string.Format(@"
					select * from dba.bl1_kopf where bl1blnr like '{0}'",
							 sBOLNo);

			DataTable dt = Connection.GetDataTable(sql);
			return dt;
		}

		public static Int64? GetBOLID(string sBOLNo)
		{

			DataTable dt = GetByBOLNo(sBOLNo);
			
			if (dt.Rows.Count < 1)
				return null;
			string s = dt.Rows[0]["bl1blmanr"].ToString();
			Int64? i = ClsConvert.ToInt64Nullable(s);
			return i;
		}

		public static DataRow GetAvailableRoro(string sBooking, string sVIN, string sType)
		{
			// Gets the Roro line for the specified booking and VIN.
			// If it can't find that, get the first available blank line
			string sql = string.Format(@"
					select c.* from dba.bu1_kopf b
					 inner join dba.car_head c on c.cr1_bumanr = b.bu1bumanr
					 where bu1bunr = '{1}'
					   and cr1_vin = '{0}' ", sVIN, sBooking);
			DataTable dt = Connection.GetDataTable(sql);
			if (dt.Rows.Count > 0)
				return dt.Rows[0];
			sql = string.Format(@"
					select c.* from dba.bu1_kopf b
					 inner join dba.car_head c on c.cr1_bumanr = b.bu1bumanr
					 where bu1bunr = '{1}'
					   and (cr1_vin is null or cr1_vin = '')
					   and cr1_type = '{0}'
					 order by cr1_buitem_seqno", sType, sBooking);
			dt = Connection.GetDataTable(sql);
			if (dt.Rows.Count > 0)
				return dt.Rows[0];
			return null;
		}
		public static void UpdateRoro(DataRow drow, string sVIN, string sDogs)
		{
			int iKey = drow["cr1_manr"].ToInt();
			string sDogsShort = sDogs;
			if (sDogsShort.Length > 26)
				sDogsShort = sDogsShort.Substring(0, 26);
			string sql = string.Format(@"
				update dba.car_head 
					set cr1_vin = '{0}',
					cr1_desofg = '{3}',
					cr1_modelname = '{2}'
				where cr1_manr = {1} ", sVIN, iKey, sDogsShort, sDogsShort);
			Connection.RunSQL(sql);
		}
		public static bool UpdateRoroVin(string sBooking, string sOldVIN, string sNewVIN)
		{
			bool bInTrans = Connection.IsInTransaction;
			try
			{
				if (!bInTrans)
					Connection.TransactionBegin();
				string sql = string.Format(@"update dba.car_head set cr1_vin = '{0}', cr1_chassis = '{0}'
							where cr1_vin = '{1}' and cr1_bunr = '{2}' ", sNewVIN, sOldVIN, sBooking);
				Connection.RunSQL(sql);
				if (!bInTrans)
					Connection.TransactionCommit();
				return true;
			}
			catch (Exception ex)
			{
				if (!bInTrans)
					Connection.TransactionRollback();
				ClsErrorHandler.LogException(ex);
				return false;
			}

		}
		#endregion

		#region Transshipment stuff
		public static DataTable GetTransshipments()
		{
			string sql = string.Format(@"
			SELECT  fleg.bu1bunr AS booking_no, 
					lleg.bu1bunr AS final_booking_no, 
					lleg.bu1voyage as voyage_no, 
					lleg.bu1vessel as vessel_no, 
					lleg.bu1polcde as pol_location_cd, 
					lleg.bu1podcde as pod_location_cd, 
					lleg.bu1plodcde as plod_location_cd,
				   lleg.bu1vskond as move_type_cd,
					 lleg.bu1podberth as pod_terminal_cd

			FROM  dba.bu1_kopf AS fleg INNER JOIN
				  dba.bu1_kopf AS lleg ON fleg.bu1bunr = lleg.bu1uniquenr 
			where  (lleg.bu1loesch = 'N') ");

			DataTable dt = Connection.GetDataTable(sql);
			return dt;
		}

		#endregion

		#region Misc Reporting

        public static DataTable IncompleteBatteryDisconnects()
        {
            DataTable dtBD = ClsNhtsaRecall.GetVinsBatteryDisconnecsForLineSQL();

            string VoyVin = string.Empty;

            foreach (DataRow drBD in dtBD.Rows)
                VoyVin = VoyVin + drBD[0].ToString();

            VoyVin = VoyVin.RemoveRightChar(1);

            string sql = @"

                Select 
                    bk.cr1_bunr as booking_no,
				    bk.cr1_vin as vin,
				    bk.cr1_vessel as vessel,
                    bk.cr1_voyage as voyage,
                    bk.cr1_polcde as pol,
                    bk.cr1_podcde as pod,
				    bk.cr1_blnr as bol_no,
                    bk.cr1_bumanr as line_booking_id,
				    kd.kdname1 as customer_nm,
                    bk.cr1_type as cargo_type,
				    bk.cr1_create_date as create_dt

                from  dba.car_head bk
				    LEFT OUTER JOIN  dba.bu1_kopf kf ON bk.cr1_bumanr = kf.bu1bumanr 
				    INNER JOIN dba.kunde kd on kd.kdkdnr = kf.bu1kdnr AND kd.firma = kf.firma

                where 1=1
				    and bk.cr1_type not in ('VANBD','CARBD')
				    and bk.cr1_voyage + '.' + bk.cr1_vin in ([VOY_VIN])
                order by bk.cr1_create_date desc";

            sql = sql.Replace("[VOY_VIN]", VoyVin);

            return Connection.GetDataTable(sql);

        }

        public static DataTable VINRecallsMismatched(string BookingNo, List<string> Vins)
        {
            ClsBookingLine bl = ClsBookingLine.GetByBookingNo(BookingNo);
            if (bl.OceanSystem == "OCEAN")
                return ClsVwArcBookingHeader.VINRecallsMismatched(BookingNo, Vins);

            string VinString = string.Empty;

            for (int x = 0; x < Vins.Count; x++)
                VinString = VinString + Vins[x] + ",";

            VinString = VinString.RemoveRightChar(1);

            string sql = @"
                    Select 
                    bk.cr1_bunr as booking_no,
				    bk.cr1_vin as vin,
                    bk.cr1_type as cargo_type

                    from  dba.car_head bk
				    LEFT OUTER JOIN  dba.bu1_kopf kf ON bk.cr1_bumanr = kf.bu1bumanr 
				    INNER JOIN dba.kunde kd on kd.kdkdnr = kf.bu1kdnr AND kd.firma = kf.firma

                    where 1=1
				    and bk.cr1_type not in ('VANBD','CARBD')
				    and bk.cr1_bunr = '[BOOKING]'
                    and bk.cr1_vin = '[VIN]'
                ".Replace("[BOOKING]", BookingNo).Replace("[VIN]", VinString);

            return Connection.GetDataTable(sql);
        }

		public static DataTable GetCubeMismacth(string sVoyage)
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendFormat(@"
				SELECT  dba.car_head.cr1_bunr AS booking_no, 'RoRo' AS cargo_type, 
						dba.car_head.cr1_voyage AS voyage_no, 
						dba.car_head.cr1_buitem, 
						SUM(ROUND(dba.car_head.cr1_length, 3)) AS length, 
						SUM(ROUND(dba.car_head.cr1_width, 3)) AS width, 
						SUM(ROUND(dba.car_head.cr1_height, 3)) AS height, 
						SUM(ROUND(dba.car_head.cr1_length * dba.car_head.cr1_width * dba.car_head.cr1_height / 1000000, 3)) AS calc_cubemtr, 
						ROUND(dba.bu3_item.bu3meas, 3) AS cubemtr,
					ABS(SUM(ROUND(dba.car_head.cr1_length * dba.car_head.cr1_width * dba.car_head.cr1_height / 1000000, 3)) - ROUND(dba.bu3_item.bu3meas, 3)) as calc_diff
				FROM    dba.car_head INNER JOIN
					  dba.bu3_item ON dba.car_head.cr1_bumanr = dba.bu3_item.bu3bumanr AND dba.car_head.cr1_buitem = dba.bu3_item.bu3bulfnr
				WHERE     (dba.car_head.cr1_voyage LIKE '{0}')
				GROUP BY dba.car_head.cr1_bunr, dba.car_head.cr1_voyage, dba.bu3_item.bu3meas, dba.car_head.cr1_buitem ",
													sVoyage);

			sb.AppendFormat(@"
			 union all
				SELECT     dba.bu1_kopf.bu1bunr AS booking_no, 'BBULK' AS cargo_type, dba.bu1_kopf.bu1voyage AS voyage_no, dba.bu3_item.bu3bulfnr, 
									  SUM(ROUND(dba.bu14_itemdetail.bu14length, 3)) AS length, SUM(ROUND(dba.bu14_itemdetail.bu14width, 3)) AS width, 
									  SUM(dba.bu14_itemdetail.bu14height) AS height, 
									  SUM(ROUND(dba.bu14_itemdetail.bu14length * dba.bu14_itemdetail.bu14width * dba.bu14_itemdetail.bu14height / 1000000, 3)) AS calc_cubemtr, 
									  ROUND(dba.bu3_item.bu3meas, 3) AS cubemtr,
					ABS(SUM(ROUND(dba.bu14_itemdetail.bu14length * dba.bu14_itemdetail.bu14width * dba.bu14_itemdetail.bu14height / 1000000, 3)) - ROUND(dba.bu3_item.bu3meas, 3)) as calc_diff
				FROM         dba.bu1_kopf INNER JOIN
									  dba.bu3_item ON dba.bu1_kopf.bu1bumanr = dba.bu3_item.bu3bumanr INNER JOIN
									  dba.bu14_itemdetail ON dba.bu3_item.bu3bumanr = dba.bu14_itemdetail.bu14manr AND 
					                 dba.bu3_item.bu3bulfnr = dba.bu14_itemdetail.bu14lfnr
				WHERE     (dba.bu1_kopf.bu1voyage LIKE '{0}')
				GROUP BY dba.bu1_kopf.bu1bunr, dba.bu1_kopf.bu1voyage, dba.bu3_item.bu3bulfnr, dba.bu3_item.bu3meas ",
													sVoyage);

			DataTable dt = Connection.GetDataTable(sb.ToString());
			return dt;
		}

		public static DataTable GetCubeCalculation(string sVoyage)
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendFormat(@"
				SELECT  dba.car_head.cr1_bunr as booking_no, 
						dba.car_head.CR1_VIN as tcn, 
					    'RoRo' as cargo_type,
						dba.car_head.cr1_voyage as voyage_no, 
						dba.bu3_item.bu3nrofpa as pkgs, 
						round(dba.car_head.cr1_length,3) as length, 
						round(dba.car_head.cr1_width ,3) as width, 
						round(dba.car_head.cr1_height,3) as height, 
						round(dba.car_head.cr1_length * dba.car_head.cr1_width * dba.car_head.cr1_height / 1000000 * dba.bu3_item.bu3nrofpa ,3) AS calc_cubemtr, 
						round(dba.bu3_item.bu3meas,3) AS cubemtr, 
						round(35.3146667 * dba.car_head.cr1_length * dba.car_head.cr1_width * dba.car_head.cr1_height / 1000000 * dba.bu3_item.bu3nrofpa,3) AS calc_cubeft, 
						round(dba.bu3_item.bu3unitmeas,3) AS cubeft
				FROM    dba.car_head INNER JOIN
						dba.bu3_item ON dba.car_head.cr1_bumanr = dba.bu3_item.bu3bumanr AND dba.car_head.cr1_buitem = dba.bu3_item.bu3bulfnr
				WHERE   (dba.car_head.cr1_voyage like '{0}') ", sVoyage);

			sb.AppendFormat(@"
					union all
				SELECT  dba.bu1_kopf.bu1bunr AS booking_no, 
						dba.bu14_itemdetail.bu14trackingref AS tcn, 
						'BBULK' AS cargo_type, 
						dba.bu1_kopf.bu1voyage AS voyage_no, 
						dba.bu3_item.bu3nrofpa AS pkgs,
						round(dba.bu14_itemdetail.bu14length,3) AS length, 
						round(dba.bu14_itemdetail.bu14width,3) AS width, 
						dba.bu14_itemdetail.bu14height AS height,  
				   	    ROUND(dba.bu14_itemdetail.bu14length * dba.bu14_itemdetail.bu14width * dba.bu14_itemdetail.bu14height * dba.bu3_item.bu3nrofpa / 1000000, 3) AS calc_cubemtr, 
						ROUND(dba.bu3_item.bu3meas, 3) AS cubemtr, 
						ROUND(35.3146667 * dba.bu14_itemdetail.bu14length * dba.bu14_itemdetail.bu14width * dba.bu14_itemdetail.bu14height * dba.bu3_item.bu3nrofpa / 1000000, 3) AS calc_cubeft, 
						ROUND(dba.bu3_item.bu3unitmeas, 3) AS cubeft
				FROM         dba.bu1_kopf INNER JOIN
									  dba.bu3_item ON dba.bu1_kopf.bu1bumanr = dba.bu3_item.bu3bumanr INNER JOIN
									  dba.bu14_itemdetail ON dba.bu3_item.bu3bumanr = dba.bu14_itemdetail.bu14manr AND 
									  dba.bu3_item.bu3bulfnr = dba.bu14_itemdetail.bu14lfnr
				WHERE   (dba.bu1_kopf.bu1voyage like '{0}') ", sVoyage);

			DataTable dtAll = Connection.GetDataTable(sb.ToString());
			return dtAll;

		}

		#endregion

		#region Misc Updates
		public static void CleanupBookRcvVins()
		{
			// This looks for a very specific situation where a RoRo booking has a matching
			// row in the Booked Received table, but the VIN the booked received table is null.
			// This doesn't always happen, but when it does it makes it difficult for the port
			// to receive the vehicle because they don't see the VIN for receiving, and have to
			// manually input it -- hopefully on the correct row!  
			//
			// When it finds the situation it takes the VIN from the booking and plugs it into
			// the booked received table.
			//
////            string sql = string.Format(@"
////				update dba.bu_cgodetails_bkg_recv
////				 set bcdbr_cargoref =
////				  (select cr1_vin
////				   from dba.car_head c
////					where c.cr1_manr = dba.bu_cgodetails_bkg_recv.bcdbr_cr1manr)
////				 where dba.bu_cgodetails_bkg_recv.bcdbr_id in
////				 (
////				select dba.bu_cgodetails_bkg_recv.bcdbr_id
////				 from dba.car_head c
////				  inner join dba.bu1_kopf b ON b.bu1bumanr = c.cr1_bumanr
////				  inner join dba.bu_cgodetails_bkg_recv ON c.cr1_manr       = dba.bu_cgodetails_bkg_recv.bcdbr_cr1manr
////				 where bu1budate > getdate() - 90
////				  and c.cr1_vin is not null
////				  and bu1kdmtc = 'AAL'
////				  and dba.bu_cgodetails_bkg_recv.bcdbr_cargoref is null
////					)");
////            Connection.RunSQL(sql);
		}

		public static int CleanupMismatchRcvdVINS(string sBookingNo)
		{
			int iRows = 0;
			bool bInTrans = Connection.IsInTransaction;
			if (!bInTrans)
				Connection.TransactionBegin();
			try
			{
				string sql = string.Format(@"
				update dba.bu_cgodetails_bkg_recv
				 set bcdbr_cargoref = 
				  (select cr1_vin from dba.car_head c
				   where c.cr1_manr = dba.bu_cgodetails_bkg_recv.bcdbr_cr1manr)
				 where dba.bu_cgodetails_bkg_recv.bcdbr_id in
				 (
				select  dba.bu_cgodetails_bkg_recv.bcdbr_id
								 from dba.car_head c
								  inner join dba.bu1_kopf b ON b.bu1bumanr = c.cr1_bumanr
								  inner join dba.bu_cgodetails_bkg_recv ON c.cr1_manr       = dba.bu_cgodetails_bkg_recv.bcdbr_cr1manr
								 where bu1budate > getdate() - 360
								  and c.cr1_vin is not null
								  and dba.bu_cgodetails_bkg_recv.bcdbr_cargoref is not null
						  and c.cr1_vin <> dba.bu_cgodetails_bkg_recv.bcdbr_cargoref
					and c.cr1_bunr = '{0}') ", sBookingNo);

				iRows = Connection.RunSQL(sql);
				if (!bInTrans)
					Connection.TransactionCommit();
				return iRows;
			}
			catch (Exception ex)
			{
				if (!bInTrans)
					Connection.TransactionRollback();
				ClsErrorHandler.LogException(ex);
				throw;
				return 0;
			}
		}

		#endregion


	}
}
