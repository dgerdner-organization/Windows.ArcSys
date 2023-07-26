using System;
using System.Collections.Generic;
using System.Text;
using CS2010.Common;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Xml;
using System.Data.SqlClient;


namespace ASL.ARC.EDISQLTools
{
	static public class ClsLineSQL
	{
		#region Fields and Properties
		#region Connection and DataTables
		public static ClsConnection Connection
		{
			get 
			{
				if (ClsConMgr.Manager["LINE"] == null)
					ConnectToLINE();
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
		private static List<ClsLoadedCargo> _LoadedCargoList;
		public static List<ClsLoadedCargo> LoadedCargoList
		{
			get
			{ return _LoadedCargoList; }
			set
			{ _LoadedCargoList = value; }
		}

		private static List<ClsLoadedCargo> _DepartedCargoList;
		public static List<ClsLoadedCargo> DepartedCargoList
		{
			get
			{ return _DepartedCargoList; }
			set
			{ _DepartedCargoList = value; }
		}
		public static List<ClsLoadedCargo> _ArrivedCargoList;
		public static List<ClsLoadedCargo> ArrivedCargoList
		{
			get { return _ArrivedCargoList; }
			set { _ArrivedCargoList = value; }
		}
		public static List<ClsLoadedCargo> _PendingDoorITVList;
		public static List<ClsLoadedCargo> PendingDoorITVList
		{
			get { return _PendingDoorITVList; }
			set { _PendingDoorITVList = value; }
		}
		public static List<ClsLoadedCargo> CargoForCreateItv;
		#endregion

		#region Select Clauses
		private static string sqlSelectRoRo = @"
				SELECT  dba.car_head.CR1_VIN AS tcn, 
						dba.bu1_kopf.bu1loesch AS deleted, 
						dba.bu1_kopf.bu1vessel as vessel_cd,
						dba.bu1_kopf.bu1bunr AS booking_no, 
						ISNULL(dba.bu1_kopf.bu1ediref, dba.bu1_kopf.bu1kdref) AS pcfn, 
						ISNULL(dba.bu1_kopf.bu1ediref, 'Manual') as create_source,
						dba.bu1_kopf.bu1vskond AS move_type, 
						dba.bu1_kopf.bu1kdmtc AS customer, 
						dba.car_head.cr1_ecstatus as cargo_status,
						convert(char(10), cr1_cargorecvdate, 101) as recdate,
						'RORO' as cargo_type,
						dba.bu1_kopf.bu1createuser,
						dba.bu1_kopf.bu1voyage as voyageno,
						dba.bu1_kopf.bu1polcde as POL, 
						dba.bu1_kopf.bu1podcde as POD,
						dba.bu1_kopf.bu1plorcde as PLOR,
						dba.bu1_kopf.bu1plodcde as PLOD,
						0 as Diff_Status,
							lleg.bu1bunr + ' ' +
							lleg.bu1voyage + ' ' +
							lleg.bu1podcde as trans_info,
						lleg.bu1bunr as final_booking_no,
						dba.bu1_kopf.bu1tariffcat1 as tariff_cd,
						fleg.bu1bunr as first_booking_no
						";
		private static string sqlFromRoRo = @"
				FROM    dba.car_head LEFT OUTER JOIN
					    dba.bu1_kopf ON dba.car_head.cr1_bumanr = dba.bu1_kopf.bu1bumanr
						left outer join dba.bu1_kopf as lleg on 
                           lleg.bu1uniquenr = dba.bu1_kopf.bu1bunr 
						left outer join dba.bu1_kopf as fleg on
						   fleg.bu1bunr = dba.bu1_kopf.bu1uniquenr";

		private static string sqlSelectBreakBulk = @"
				SELECT	dba.bu14_itemdetail.bu14trackingref as tcn, 
						dba.bu1_kopf.bu1loesch AS deleted, 
						dba.bu1_kopf.bu1vessel as vessel_cd,
						dba.bu1_kopf.bu1bunr as booking_no, 
						ISNULL(dba.bu1_kopf.bu1ediref, dba.bu1_kopf.bu1kdref) AS pcfn, 
						ISNULL(dba.bu1_kopf.bu1ediref, 'Manual') as create_source,
						dba.bu1_kopf.bu1vskond AS move_type, 
						dba.bu1_kopf.bu1kdmtc AS customer, 
						dba.bu14_itemdetail.bu14status as cargo_status, 
						convert(char(10), dba.bu14_itemdetail.bu14cargorecvdate,101) as recdate,
						'BBULK' as cargo_type,
						dba.bu1_kopf.bu1createuser,
						dba.bu1_kopf.bu1voyage as voyageno,
						dba.bu1_kopf.bu1polcde as POL, 
						dba.bu1_kopf.bu1podcde as POD,
						dba.bu1_kopf.bu1plorcde as PLOR,
						dba.bu1_kopf.bu1plodcde as PLOD,
						0 as Diff_Status,
							lleg.bu1bunr + ' ' +
							lleg.bu1voyage + ' ' +
							lleg.bu1podcde as trans_info,
						lleg.bu1bunr as final_booking_no,
						dba.bu1_kopf.bu1tariffcat1 as tariff_cd,
						fleg.bu1bunr as first_booking_no
						";
		private static string sqlFromBreakBulk = @"
				 FROM   dba.bu1_kopf INNER JOIN dba.bu3_item 
                   ON   dba.bu1_kopf.bu1bumanr = dba.bu3_item.bu3bumanr 
				INNER JOIN dba.bu14_itemdetail 
				   ON   dba.bu3_item.bu3bumanr = dba.bu14_itemdetail.bu14manr 
				  AND   dba.bu3_item.bu3bulfnr = dba.bu14_itemdetail.bu14lfnr
				left outer join dba.bu1_kopf as lleg on lleg.bu1uniquenr = dba.bu1_kopf.bu1bunr 
				left outer join dba.bu1_kopf as fleg on fleg.bu1bunr = dba.bu1_kopf.bu1uniquenr";

		private static string sqlSelectContainer = @"
				SELECT dba.bu4_cont.bu4remgte as tcn,
					dba.bu1_kopf.bu1loesch AS deleted, 
					dba.bu1_kopf.bu1vessel as vessel_cd,
					dba.bu1_kopf.bu1bunr as booking_no, 
					ISNULL(dba.bu1_kopf.bu1ediref, dba.bu1_kopf.bu1kdref) AS pcfn, 
					ISNULL(dba.bu1_kopf.bu1ediref, 'Manual') as create_source,
					dba.bu1_kopf.bu1vskond AS move_type, 
					dba.bu1_kopf.bu1kdmtc AS customer, 
					bu4ecstatus as cargo_status, 
					convert(char(10), bu4cargorecvdate,101) as recdate,
					'CONTAINER' as cargo_type,
					dba.bu1_kopf.bu1createuser,
					dba.bu1_kopf.bu1voyage as voyageno,
					dba.bu1_kopf.bu1polcde as POL, dba.bu1_kopf.bu1podcde as POD,
						dba.bu1_kopf.bu1plorcde as PLOR,
						dba.bu1_kopf.bu1plodcde as PLOD,
					0 as Diff_Status,
							lleg.bu1bunr + ' ' +
							lleg.bu1voyage + ' ' +
							lleg.bu1podcde as trans_info,
						lleg.bu1bunr as final_booking_no,
					dba.bu1_kopf.bu1tariffcat1 as tariff_cd,
					fleg.bu1bunr as first_booking_no
					";
		private static string sqlFromContainer = @"
					FROM dba.bu4_cont INNER JOIN
						 dba.bu1_kopf ON dba.bu4_cont.bu4bumanr = dba.bu1_kopf.bu1bumanr
						left outer join dba.bu1_kopf as lleg on lleg.bu1uniquenr = dba.bu1_kopf.bu1bunr
						left outer join dba.bu1_kopf as fleg on fleg.bu1bunr = dba.bu1_kopf.bu1uniquenr";

		private static string sqlJoinSchedule = @"
				INNER JOIN dba.reise_hafen 
                   ON dba.bu1_kopf.bu1vessel = dba.reise_hafen.rhvessel 
				  AND dba.bu1_kopf.bu1voyage = dba.reise_hafen.rhreise 
				  AND dba.bu1_kopf.bu1polcde = dba.reise_hafen.rhhafen 
				  AND dba.bu1_kopf.bu1polseqno = dba.reise_hafen.rhseqno ";

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

		public static int PatchCargoRcvdDate(Int64? iBookingId)
		{
			string sql = string.Format(@"
			  update dba.bu14_itemdetail
			   set bu14cargorecvdate =
				(select etq_date from dba.event_tracking_queue q
				  where q.etq_bu14id = bu14_itemdetail_id
				   and q.etq_eventtype = 'EXRC')
			 where bu14manr = {0}  
			   and bu14status = 'EXRC' ", iBookingId);
			return Connection.RunSQL(sql);
		}

		public static int PatchCargoRcvdDate()
		{
			string sql = string.Format(@"
					update dba.car_head
					 set dba.car_head.cr1_ecstatus = 'EXRC',  
						dba.car_head.cr1_cargorecvdate =
					  (select MAX(bcdbr_cargorecvdate) from dba.bu_cgodetails_bkg_recv
						where bcdbr_bumanr = dba.car_head.cr1_bumanr
						and bcdbr_cargoref = dba.car_head.cr1_vin)
					where cr1_manr in    
					(
					select cr1_manr
					from dba.car_head    
					 inner join dba.bu_cgodetails_bkg_recv a on a.bcdbr_bumanr = dba.car_head.cr1_bumanr
						and a.bcdbr_cargoref = dba.car_head.cr1_vin
					where dba.car_head.cr1_cargorecvdate is null
					 and a.bcdbr_cargorecvdate is not null
					 and cr1_bunr > 'ARCA17'
					 )");
			
			return Connection.RunSQL(sql);
		}

		public static void PatchMismatchVINs()
		{
			string sql = string.Format(@"
				update dba.bu_cgodetails_bkg_recv
				 set bcdbr_cargoref =
				 (select cr1_vin from dba.car_head b where b.cr1_manr = bcdbr_cr1manr)
				 where  bcdbr_id in
				(
  
				select bcdbr_id
				 from dba.bu_cgodetails_bkg_recv a
				 inner join dba.car_head b on a.bcdbr_cr1manr = b.cr1_manr
				  where cr1_create_date > getdate() - 180
				  and ( bcdbr_cargoref <> cr1_vin or a.bcdbr_cargoref is null and cr1_vin is not null)
				  )");
			Connection.RunSQL(sql);
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

		public static DataRow GetVoyage(string sVoyageNo)
		{
			string sql = string.Format(@"
				select * from dba.reise where rereisenr = '{0}' ", sVoyageNo);
			DataTable dt = Connection.GetDataTable(sql);
			if (dt.Rows.Count > 0)
				return dt.Rows[0];
			return null;
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

		public static int UpdateWeight_BB(string ID, decimal? dWeight)
		{
			string sql = string.Format(@"update dba.bu14_itemdetail set bu14weight = {0} where bu14_itemdetail_id = {1}",
				dWeight, ID);
			int iReturn = Connection.RunSQL(sql);
			return iReturn;
		}


		#endregion

		#region ITV Reporting
		public static DataTable GatherLINEData(string tcn)
		{
			// 
			// Finds all LINE cargo as follows for a TCN
			//
			StringBuilder sb = new StringBuilder(sqlSelectRoRo);
			sb.Append(sqlFromRoRo);
			sb.AppendFormat(@" 
				WHERE  (dba.car_head.CR1_VIN = '{0}') 
                  AND (dba.bu1_kopf.bu1kdmtc LIKE '%SDDC%') 
				  AND (dba.bu1_kopf.bu1createdat > GETDATE() - 180) ", tcn);
			DataTable dt1 = Connection.GetDataTable(sb.ToString());
			if (dt1.Rows.Count > 0)
				return dt1;

			sb = new StringBuilder(sqlSelectBreakBulk);
			sb.Append(sqlFromBreakBulk);
			sb.AppendFormat(@"
				WHERE (dba.bu1_kopf.bu1loesch = 'N') 
				  AND (dba.bu14_itemdetail.bu14trackingref = '{0}' )
				  AND (dba.bu1_kopf.bu1kdmtc LIKE '%SDDC%') 
				  AND (dba.bu1_kopf.bu1createdat > GETDATE() - 180) ", tcn);
			dt1 = Connection.GetDataTable(sb.ToString());
			if (dt1.Rows.Count > 0)
				return dt1;

			sb.Length = 0;
			sb.AppendFormat(@"
				SELECT dba.bu4_cont.bu4remgte as tcn,
					dba.bu1_kopf.bu1loesch AS deleted, 
					dba.bu1_kopf.bu1bunr as booking_no, 
					ISNULL(dba.bu1_kopf.bu1ediref, dba.bu1_kopf.bu1kdref) AS pcfn, 
					ISNULL(dba.bu1_kopf.bu1ediref, 'Manual') as create_source,
					dba.bu1_kopf.bu1vskond AS move_type, 
					dba.bu1_kopf.bu1kdmtc AS customer, 
					bu4ecstatus as cargo_status, 
					convert(char(10), bu4cargorecvdate,101) as recdate,
					'CONTAINER' as cargo_type,
					bu1createuser,
					dba.bu1_kopf.bu1voyage as voyageno,
					dba.bu1_kopf.bu1polcde as POL, dba.bu1_kopf.bu1podcde as POD
					FROM dba.bu4_cont INNER JOIN
						 dba.bu1_kopf ON dba.bu4_cont.bu4bumanr = dba.bu1_kopf.bu1bumanr
					WHERE     (dba.bu4_cont.bu4remgte = '{0}')
					  AND (dba.bu1_kopf.bu1loesch = 'N') 
					  AND (dba.bu1_kopf.bu1kdmtc LIKE '%SDDC%') 
					  AND (dba.bu1_kopf.bu1createdat > GETDATE() - 120) ", tcn);
			dt1 = Connection.GetDataTable(sb.ToString());
			if (dt1.Rows.Count > 0)
				return dt1;

			return null;
		}

		public static DataTable GetDupeVIN(ClsConnection conn)
		{
			if (conn == null)
				return null;
			string sql = string.Format(@"select cr1_vin as vin, cr1_bumanr, dba.car_head.cr1_bunr as booking_no, count(cr1_vin)
						 from dba.car_head
						  where cr1_bunr > 'ARCA16001' and cr1_cargorecvdate > getdate() - 60
						  group by cr1_vin, cr1_bumanr, dba.car_head.cr1_bunr
						  having count (cr1_vin) > 1
						   order by cr1_bunr ");
			DataTable dt = conn.GetDataTable(sql);
			return dt;
		}
		public static DataTable GetUnsentInGates(int days)
		{
			DataTable dt = GetReceivedCargoSDDC(days);
			dt = LoadCargo(dt);
			return dt;
		}

		public static DataTable GetMismatchData(int days)
		{
			DataTable dt = GetReceivedCargoSDDC(days);
			dt = LoadCargoMismatch(dt);
			return dt;
		}

		public static DataTable GetReceivedListGrid(int days)
		{
			DataTable dt = GetLINEReceivedList(days);
			dt = ReceivedListExtra(dt);
			return dt;
		}

		public static DataTable ReceivedListExtra(DataTable dt)
		{
			// 
			// Places datatable into a list, and gathers ACMS
			// data
			//
			LoadedCargoList = new List<ClsLoadedCargo>();
			dt.Columns.Add("c_ingates");
			dt.Columns.Add("c_bbpickup");
			dt.Columns.Add("c_rdd");
			dt.Columns.Add("c_acms_booking_no");
			dt.Columns.Add("c_acms_pcfn");
			foreach( DataRow dr in dt.Rows )
			{
				ClsLoadedCargo cargo = new ClsLoadedCargo();
				cargo.TCN = dr["tcn"].ToString();
				cargo.CargoStatus = dr["cargo_status"].ToString();
				cargo.VoyageNo = dr["voyageno"].ToString();
				cargo.BookingNo = dr["booking_no"].ToString();
				string sType = dr["cargo_type"].ToString();
				string sRecDate = dr["recdate"].ToString();
				//if( !string.IsNullOrEmpty(sRecDate) )
				//{
				//    cargo.ReceivedDate = Convert.ToDateTime(sRecDate);
				//}

				// Gather ACMS information for this cargo
				ClsAcmsSQL.ACMSBookingData acms = ClsAcmsSQL.GetACMSData(cargo.VoyageNo, cargo.TCN);
				dr["c_rdd"] = acms.dtRDD;
				dr["c_acms_booking_no"] = acms.sBooking;
				dr["c_acms_pcfn"] = acms.sPCFN;
				cargo.BookingNo = acms.sBooking;
				cargo.BookingNoSub = acms.sBookingSub;
				cargo.PCFN = acms.sPCFN;
				cargo.POD = acms.sPODLocation;
				cargo.PODTerminal = acms.sPODTerminal;
				cargo.POE = acms.sPOELocation;
				cargo.POETerminal = acms.sPOETerminal;
				cargo.ItemNo = acms.lItemNo;
				cargo.ACMSVoyageNo = acms.sVoyageNo;

				// Looks for ITV data using the LINE voyageno and TCN.
				cargo.I_InGateCount = ClsConvert.ToInt32(ClsAcmsSQL.ActivityCount(cargo.VoyageNo, cargo.TCN, "I"));
				dr["c_ingates"] = cargo.I_InGateCount;
				cargo.W_PickupCount = ClsConvert.ToInt32(ClsAcmsSQL.ActivityCount(cargo.VoyageNo, cargo.TCN, "W"));
				dr["c_bbpickup"] = cargo.W_PickupCount;

				LoadedCargoList.Add(cargo);
			}

			return dt;
		}

		public static DataTable GetUnsentVesselDepart(int days)
		{
			DataTable dt = GetReceivedCargoSDDC(days);
			dt = LoadCargoVesselDeparted(dt);
			return dt;
		}

		public static DataTable GetUnsentVesselArrive(int days)
		{
			DataTable dt = GetReceivedCargoSDDC(days);
			dt = LoadCargoVesselArrived(dt);
			return dt;
		}

		public static DataTable GetPendingDoorITV(int days, int daysold, ProtocolParameters parms)
		{
			// Get receiveds just for Door Out Moves
			DataTable dt = GetReceivedCargoSDDC(days, true, parms.Voyage);
			dt = LoadCargoPendingDoorITV(dt, daysold);
			return dt;
		}
		public static DataTable GetPendingDoorITV(int days, int daysold, string sVoyage)
		{
			// Get receiveds just for Door Out Moves
			DataTable dt = GetReceivedCargoSDDC(days, true, sVoyage);
			dt = LoadCargoPendingDoorITV(dt, daysold);
			return dt;
		}



		public static DataTable GetCargoForCreateITV(ProtocolParameters parms)
		{
			DataTable dt = GetReceivedCargoSDDC(900, false, parms.Voyage, parms.POL_CDs, parms.POD_CDs, parms.Booking_No, parms.IncludeBooked);
			dt = LoadCargoForCreateITV(dt, parms);
			return dt;
		}

		public static DataTable GetCargoForCreateITV(string sVoyage)
		{
			DataTable dt = GetReceivedCargoSDDC(900, false, sVoyage);
			//dt = LoadCargoForCreateITV(dt);
			return dt;
		}
		public static DataTable GetLINEReceivedList(int days)
		{
			// 
			// Finds all LINE cargo as follows:
			//  -Booking was created within the last 'x' days
			//  -Cargo has a received date
			//  -It has not been deleted
			//  -Customer is SDDC
			//  -Booking is confirmed

			StringBuilder sb = new StringBuilder();
			sb.Append(@"
				SELECT  dba.car_head.CR1_VIN AS tcn, 
						dba.bu1_kopf.bu1loesch AS deleted, 
						dba.bu1_kopf.bu1bunr AS booking_no, 
						ISNULL(dba.bu1_kopf.bu1ediref, dba.bu1_kopf.bu1kdref) AS pcfn, 
						dba.bu1_kopf.bu1vskond AS move_type, 
						dba.bu1_kopf.bu1kdmtc AS customer, 
						dba.car_head.cr1_ecstatus as cargo_status,
						convert(char(10), cr1_cargorecvdate, 101) as recdate,
						'RORO' as cargo_type,
						bu1createuser,
						dba.bu1_kopf.bu1voyage as voyageno,
						0 as diff_status
				FROM    dba.car_head LEFT OUTER JOIN
					    dba.bu1_kopf ON dba.car_head.cr1_bumanr = dba.bu1_kopf.bu1bumanr
				WHERE  (dba.car_head.CR1_VIN IS NOT NULL) 
                  AND (dba.bu1_kopf.bu1kdmtc LIKE '%SDDC%') 
                  AND (dba.bu1_kopf.bu1status2 = 'C') 
				  /*AND (dba.bu1_kopf.bu1createdat > GETDATE() - 90) */
				  AND (cr1_cargorecvdate > getdate() - 14 )
				  /*AND (dba.car_head.cr1_ecstatus IN ('EXRC', 'LOAD', 'DELV', 'DISC')) */
				  AND (dba.bu1_kopf.bu1loesch = 'N')");

			DataTable dt1 = Connection.GetDataTable(sb.ToString());

			sb.Length = 0;
			sb.Append(@"
				SELECT	dba.bu14_itemdetail.bu14trackingref as tcn, 
						dba.bu1_kopf.bu1loesch AS deleted, 
						dba.bu1_kopf.bu1bunr as booking_no, 
						ISNULL(dba.bu1_kopf.bu1ediref, dba.bu1_kopf.bu1kdref) AS pcfn, 
						dba.bu1_kopf.bu1vskond AS move_type, 
						dba.bu1_kopf.bu1kdmtc AS customer, 
						dba.bu14_itemdetail.bu14status as cargo_status, 
						convert(char(10), dba.bu14_itemdetail.bu14cargorecvdate, 101) as recdate,
						'BBULK' as cargo_type,
						bu1createuser,
						dba.bu1_kopf.bu1voyage as voyageno,
						0 as diff_status
				 FROM   dba.bu1_kopf INNER JOIN dba.bu3_item 
                   ON   dba.bu1_kopf.bu1bumanr = dba.bu3_item.bu3bumanr 
				INNER JOIN dba.bu14_itemdetail 
				   ON   dba.bu3_item.bu3bumanr = dba.bu14_itemdetail.bu14manr 
				  AND   dba.bu3_item.bu3bulfnr = dba.bu14_itemdetail.bu14lfnr
				WHERE (dba.bu1_kopf.bu1loesch = 'N') 
				  AND (dba.bu1_kopf.bu1kdmtc LIKE '%SDDC%') 
				  AND (dba.bu1_kopf.bu1status2 = 'C') 
				  /*AND (dba.bu1_kopf.bu1createdat > GETDATE() - 30) */
				  AND dba.bu14_itemdetail.bu14cargorecvdate > getdate() - 14
				  /*AND (dba.bu14_itemdetail.bu14status IN ('LOAD', 'EXRC','DELV','DISC')*/
				  ");

			DataTable dt2 = Connection.GetDataTable(sb.ToString());

			DataTable dtAll = new DataTable();
			dtAll.Merge(dt1);
			dtAll.Merge(dt2);
			return dtAll;

		}

		public static DataTable GetReceivedCargoSDDC(int days)
		{
			return GetReceivedCargoSDDC(days, false, "%");
		}

		public static DataTable GetUnloadedCargoSDDC(int StartDays, int EndDays)
		{
			// Gather RoRo
			StringBuilder sb = new StringBuilder(sqlSelectRoRo);
			sb.AppendFormat(@"
				 ,dba.reise_hafen.rhetseta as ETA ");
			sb.AppendFormat(sqlFromRoRo);
			sb.Append(sqlJoinSchedule);

			sb.AppendFormat(@"
				WHERE (dba.car_head.CR1_VIN IS NOT NULL) 
				  AND (dba.bu1_kopf.bu1kdmtc LIKE '%SDDC%') 
				  AND (dba.bu1_kopf.bu1status2 = 'C') 
				  AND (dba.car_head.cr1_ecstatus IN ('BOOK')) 
				  AND (dba.bu1_kopf.bu1loesch = 'N') 
				  AND (dba.reise_hafen.rhetseta BETWEEN GETDATE() - {0} AND 
                      GETDATE() - {1} )
			   ORDER BY booking_no, tcn ",
					StartDays, EndDays);
			DataTable dtRoRo = Connection.GetDataTable(sb.ToString());

			//
			// Gather BreakBulk
			sb = new StringBuilder(sqlSelectBreakBulk);
			sb.AppendFormat(",dba.reise_hafen.rhetseta as ETA ");
			sb.Append(sqlFromBreakBulk);
			sb.Append(sqlJoinSchedule);
			sb.AppendFormat(@"
				WHERE (dba.bu1_kopf.bu1loesch = 'N') 
				  AND (dba.bu1_kopf.bu1kdmtc LIKE '%SDDC%') 
				  AND (dba.bu1_kopf.bu1status2 = 'C') 
				  AND (dba.bu14_itemdetail.bu14status IN ('BOOK'))
				  AND (dba.reise_hafen.rhetseta BETWEEN GETDATE() - {0} AND 
                      GETDATE() - {1} )",
				StartDays, EndDays);
			DataTable dtBB = Connection.GetDataTable(sb.ToString());

			//
			// Gather Containers
			//
			sb = new StringBuilder(sqlSelectContainer);
			sb.AppendFormat(",dba.reise_hafen.rhetseta as ETA ");
			sb.Append(sqlFromContainer);
			sb.Append(sqlJoinSchedule);
			sb.AppendFormat(@"
					WHERE (dba.bu4_cont.bu4remgte IS NOT NULL)
					  AND (dba.bu1_kopf.bu1loesch = 'N') 
					  and (bu4ecstatus in ('BOOK'))
					  AND (dba.bu1_kopf.bu1kdmtc LIKE '%SDDC%') 
					  AND (dba.bu1_kopf.bu1status2 = 'C') 
					  AND (dba.reise_hafen.rhetseta BETWEEN GETDATE() - {0} AND GETDATE() - {1} )",
						StartDays, EndDays);
			DataTable dtCont = Connection.GetDataTable(sb.ToString());

			//
			// Merge all data together
			//
			DataTable dtAll = new DataTable();
			dtAll.Merge(dtRoRo);
			dtAll.Merge(dtBB);
			dtAll.Merge(dtCont);
			return dtAll;
		}

		public static DataTable GetReceivedCargoSDDC(int days, bool DoorsOutOnly, string sVoyageNo)
		{
			return GetReceivedCargoSDDC(days, DoorsOutOnly, sVoyageNo, "%", "%", "%");
		}

		public static DataTable GetReceivedCargoSDDC(int days, bool DoorsOutOnly, string sVoyageNo,
				string sPOL, string sPOD, string sBookingNo)
		{
			return GetReceivedCargoSDDC(days, DoorsOutOnly, sVoyageNo, sPOL, sPOD, sBookingNo, false);
		}
		public static DataTable GetReceivedCargoSDDC(int days, bool DoorsOutOnly, string sVoyageNo, 
				string sPOL, string sPOD, string sBookingNo, bool bIncludeBooked)
		{
			// 
			// Finds all LINE cargo as follows:
			//  -Booking was created within the last 'x' days
			//  -Cargo status is at least Received ("EXRC")
			//  -It has not been deleted
			//  -Customer is SDDC
			//  -Booking is confirmed

			StringBuilder sb = new StringBuilder(sqlSelectRoRo);
			string sStatus = " ('EXRC','LOAD','DELV','DISC','BOOK') ";
			if( !bIncludeBooked )
				sStatus = sStatus.Replace(",'BOOK'", "");

			sb.Append(sqlFromRoRo);

			sb.AppendFormat(@" 
				WHERE  (dba.car_head.CR1_VIN IS NOT NULL) 
                  AND (dba.bu1_kopf.bu1kdmtc LIKE '%SDDC%') 
                  AND (dba.bu1_kopf.bu1status2 = 'C') 
				  AND (dba.bu1_kopf.bu1voyage like '{1}')
			      and (dba.bu1_kopf.bu1polcde like '{2}')
				  and (dba.bu1_kopf.bu1podcde like '{3}')
				  and (dba.bu1_kopf.bu1bunr like '{4}')
				  AND (dba.bu1_kopf.bu1createdat > GETDATE() - {0}) 
				  AND (dba.car_head.cr1_ecstatus IN {5}) 
				  AND (dba.bu1_kopf.bu1loesch = 'N')",
					days, sVoyageNo, sPOL, sPOD, sBookingNo, sStatus);
			if( DoorsOutOnly )
			{
				sb.Append(" and (dba.bu1_kopf.bu1vskond in ('F7','F8','F9')) ");
			}
			if( !bIncludeBooked )
			{
				sb.AppendFormat(@" AND (cr1_cargorecvdate > getdate() - {0} ) ", days);
			}

			DataTable dt1 = Connection.GetDataTable(sb.ToString());

			sb = new StringBuilder(sqlSelectBreakBulk);
			sb.Append(sqlFromBreakBulk);
			sb.AppendFormat(@"
				WHERE (dba.bu1_kopf.bu1loesch = 'N') 
				  AND (dba.bu1_kopf.bu1kdmtc LIKE '%SDDC%') 
				 AND (dba.bu1_kopf.bu1voyage like '{1}')
			      and (dba.bu1_kopf.bu1polcde like '{2}')
				  and (dba.bu1_kopf.bu1podcde like '{3}')
				  and (dba.bu1_kopf.bu1bunr like '{4}')
				  AND (dba.bu1_kopf.bu1status2 = 'C') 
				  AND (dba.bu1_kopf.bu1createdat > GETDATE() - {0}) 
				  AND (dba.bu14_itemdetail.bu14status IN {5})",
					days, sVoyageNo, sPOL, sPOD, sBookingNo, sStatus);
			if( DoorsOutOnly )
			{
				sb.Append(" and (dba.bu1_kopf.bu1vskond in ('F7','F8','F9')) ");
			}
			if( !bIncludeBooked )
			{
				sb.AppendFormat(@" AND dba.bu14_itemdetail.bu14cargorecvdate > getdate() - {0} ", days);

			}
			DataTable dt2 = Connection.GetDataTable(sb.ToString());

			sb.Length = 0;
			sb.AppendFormat(@"
				SELECT dba.bu4_cont.bu4remgte as tcn,
					dba.bu1_kopf.bu1loesch AS deleted, 
					dba.bu1_kopf.bu1bunr as booking_no, 
					ISNULL(dba.bu1_kopf.bu1ediref, dba.bu1_kopf.bu1kdref) AS pcfn, 
					ISNULL(dba.bu1_kopf.bu1ediref, 'Manual') as create_source,
					dba.bu1_kopf.bu1vskond AS move_type, 
					dba.bu1_kopf.bu1kdmtc AS customer, 
					bu4ecstatus as cargo_status, 
					convert(char(10), bu4cargorecvdate,101) as recdate,
					'CONTAINER' as cargo_type,
					bu1createuser,
					dba.bu1_kopf.bu1voyage as voyageno,
					dba.bu1_kopf.bu1polcde as POL, dba.bu1_kopf.bu1podcde as POD
					FROM dba.bu4_cont INNER JOIN
						 dba.bu1_kopf ON dba.bu4_cont.bu4bumanr = dba.bu1_kopf.bu1bumanr
					WHERE     (dba.bu4_cont.bu4remgte IS NOT NULL)
					  AND (dba.bu1_kopf.bu1loesch = 'N') 
					  and (bu4ecstatus in {5})
					  AND (dba.bu1_kopf.bu1kdmtc LIKE '%SDDC%') 
					  AND (bu4cargorecvdate > getdate() - {0} )
					  AND (dba.bu1_kopf.bu1voyage like '{1}')
					  and (dba.bu1_kopf.bu1polcde like '{2}')
					  and (dba.bu1_kopf.bu1podcde like '{3}')
					  and (dba.bu1_kopf.bu1bunr like '{4}')
					  AND (dba.bu1_kopf.bu1status2 = 'C') ",
						days, sVoyageNo, sPOL, sPOD, sBookingNo, sStatus);
			if( DoorsOutOnly )
			{
				sb.Append(" and (dba.bu1_kopf.bu1vskond in ('F7','F8','F9')) ");
			}
			DataTable dt3 = Connection.GetDataTable(sb.ToString());

			DataTable dtAll = new DataTable();
			dtAll.Merge(dt1);
			dtAll.Merge(dt2);
			dtAll.Merge(dt3);
			return dtAll;

		}

		public static DataTable GetCargoByVoyage(string VoyageNo, string PortNo, string ArriveDepart)
		{
			StringBuilder sb = new StringBuilder(sqlSelectRoRo);
			VoyageNo = VoyageNoStripped(VoyageNo);
			sb.AppendFormat(sqlFromRoRo);
			sb.AppendFormat(@"
				WHERE (dba.bu1_kopf.bu1kdmtc LIKE '%SDDC%') 
				  AND (dba.bu1_kopf.bu1voyage = '{0}') 
				  AND(dba.bu1_kopf.bu1loesch = 'N') 
				  AND (dba.bu1_kopf.bu1status2 = 'C') ",
				VoyageNo);

			sb = ByVoyageAddendum(sb, PortNo, ArriveDepart);
			DataTable dtRoRo = Connection.GetDataTable(sb.ToString());

			sb = new StringBuilder(sqlSelectBreakBulk);
			sb.AppendFormat(sqlFromBreakBulk);
			sb.AppendFormat(@"
				WHERE (dba.bu1_kopf.bu1kdmtc LIKE '%SDDC%') 
				  AND (dba.bu1_kopf.bu1voyage = '{0}') 
				  AND(dba.bu1_kopf.bu1loesch = 'N') 
				  AND (dba.bu1_kopf.bu1status2 = 'C') ",
				VoyageNo);

			sb = ByVoyageAddendum(sb, PortNo, ArriveDepart);
			DataTable dtBB = Connection.GetDataTable(sb.ToString());

			sb = new StringBuilder(sqlSelectContainer);
			sb.AppendFormat(sqlFromContainer);
			sb.AppendFormat(@"
				WHERE (dba.bu1_kopf.bu1kdmtc LIKE '%SDDC%') 
				  AND (dba.bu1_kopf.bu1voyage = '{0}') 
				  AND(dba.bu1_kopf.bu1loesch = 'N') 
				  AND (dba.bu1_kopf.bu1status2 = 'C') ",
				VoyageNo);
			sb = ByVoyageAddendum(sb, PortNo, ArriveDepart);
			DataTable dtContainer = Connection.GetDataTable(sb.ToString());

			DataTable dtAll = new DataTable();
			dtAll.Merge(dtRoRo);
			dtAll.Merge(dtBB);
			dtAll.Merge(dtContainer);

			// Remove extraneous characters from the TCN
			foreach( DataRow dr in dtAll.Rows )
			{
				string TCN = dr["tcn"].ToString();
				TCN = CleanSerialNo(TCN);
				dr["tcn"] = TCN;
			}

			return dtAll;
		}

		public static StringBuilder ByVoyageAddendum(StringBuilder sbSQL, string PortNo, string ArriveDepart)
		{
			if( ArriveDepart.ToLower() == "arrive" )
			{
				// For arrives 
				sbSQL.AppendFormat(@"
				  AND (bu1podcde = '{0}') ",
					 PortNo);
			}
			else
			{
				sbSQL.AppendFormat(@"
				  AND (dba.bu1_kopf.bu1polcde = '{0}') ",
					PortNo);
			}
			return sbSQL;

		}

		public static DataTable LoadCargo(DataTable dt)
		{
			// This does two things:
			//  1. It removes rows from the datatable for cargo that
			//     has already created ITV data
			//  2. It creates a LIST of cargo activity that can be used
			//     in other processing.

			LoadedCargoList = new List<ClsLoadedCargo>();
			dt.Columns.Add("c_ingates");
			dt.Columns.Add("c_bbpickup");
			dt.Columns.Add("c_rdd");
			dt.Columns.Add("c_acms_booking_no");
			dt.Columns.Add("c_acms_pcfn");
			foreach( DataRow dr in dt.Rows )
			{
				ClsLoadedCargo cargo = new ClsLoadedCargo();
				cargo.TCN = dr["tcn"].ToString();
				cargo.CargoStatus = dr["cargo_status"].ToString();
				cargo.VoyageNo = dr["voyageno"].ToString();
				cargo.BookingNo = dr["booking_no"].ToString();
				string sType = dr["cargo_type"].ToString();
				//if( cargo.TCN == "NVQCA62$0015680XX" )
				//{
				//    string x = "X";
				//}
				string sRecDate = dr["recdate"].ToString();
				if( !string.IsNullOrEmpty(sRecDate) )
				{
					cargo.ReceivedDate = Convert.ToDateTime(sRecDate);
				}

				// Gather ACMS information for this cargo
				ClsAcmsSQL.ACMSBookingData acms = ClsAcmsSQL.GetACMSData(cargo.VoyageNo, cargo.TCN);
				if( !string.IsNullOrEmpty(ClsAcmsSQL.ErrorMsg) )
				{
					//Program.Show(ClsAcmsSQL.ErrorMsg);
					ClsErrorHandler.LogWarning(ClsAcmsSQL.ErrorMsg);
					dr.Delete();
					continue;
				}
				dr["c_rdd"] = acms.dtRDD;
				dr["c_acms_booking_no"] = acms.sBooking;
				dr["c_acms_pcfn"] = acms.sPCFN;
				cargo.BookingNo = acms.sBooking;
				cargo.BookingNoSub = acms.sBookingSub;
				cargo.PCFN = acms.sPCFN;
				cargo.POD = acms.sPODLocation;
				cargo.PODTerminal = acms.sPODTerminal;
				cargo.POE = acms.sPOELocation;
				cargo.POETerminal = acms.sPOETerminal;
				cargo.ItemNo = acms.lItemNo;
				cargo.ACMSVoyageNo = acms.sVoyageNo;

				// Looks for ITV data using the LINE voyageno and TCN.
				cargo.I_InGateCount = ClsConvert.ToInt32( ClsAcmsSQL.ActivityCount(cargo.VoyageNo, cargo.TCN, "I") );
				dr["c_ingates"] = cargo.I_InGateCount;
				cargo.W_PickupCount = ClsConvert.ToInt32( ClsAcmsSQL.ActivityCount(cargo.VoyageNo, cargo.TCN, "W") );
				dr["c_bbpickup"] = cargo.W_PickupCount;
				if( cargo.W_PickupCount != 0 && cargo.I_InGateCount != 0 )
				{
					dr.Delete();
					continue;
				}
				if( string.IsNullOrEmpty(cargo.BookingNo) )
				{
					dr.Delete();
					continue;
				}

				LoadedCargoList.Add(cargo);
			}

			return dt;
		}

		public static DataTable LoadCargoMismatch(DataTable dt)
		{
			// This does two things:
			//  1. It removes rows from the datatable for cargo
			//     where the LINE data matches the ACMS data
			//  2. It creates a LIST of cargo activity that can be used
			//     in other processing.

			LoadedCargoList = new List<ClsLoadedCargo>();
			dt.Columns.Add("c_rdd");
			dt.Columns.Add("c_acms_booking_no");
			dt.Columns.Add("c_acms_pcfn");
			dt.Columns.Add("c_acms_voyageno");
			dt.Columns.Add("c_voyage_match");
			dt.Columns.Add("c_acms_pol");
			dt.Columns.Add("c_acms_pod");
			foreach( DataRow dr in dt.Rows )
			{
				ClsLoadedCargo cargo = new ClsLoadedCargo();
				cargo.TCN = dr["tcn"].ToString();

				cargo.CargoStatus = dr["cargo_status"].ToString();
				cargo.VoyageNo = dr["voyageno"].ToString();
				cargo.POD = dr["POD"].ToString();
				cargo.POE = dr["POL"].ToString();

				if (string.IsNullOrEmpty(cargo.VoyageNo))
				{
					cargo.VoyageNo = "n/a  ";
				}
				string sRecDate = dr["recdate"].ToString();
				if( !string.IsNullOrEmpty(sRecDate) )
				{
					cargo.ReceivedDate = Convert.ToDateTime(sRecDate);
				}

				// Gather ACMS information for this cargo
				ClsAcmsSQL.ACMSBookingData acms = ClsAcmsSQL.GetACMSData("%", cargo.TCN);
				if (string.IsNullOrEmpty(acms.sVoyageNo))
				{
					acms.sVoyageNo = "n/a  ";
				}
				dr["c_rdd"] = acms.dtRDD;
				dr["c_acms_booking_no"] = acms.sBooking;
				dr["c_acms_pcfn"] = acms.sPCFN;
				dr["c_acms_voyageno"] = acms.sVoyageNo;
				dr["c_voyage_match"] = "Y";
				dr["c_acms_pod"] = acms.sPODLocation;
				dr["c_acms_pol"] = acms.sPOELocation;
				int i1 = 5;
				int i2 = 5;
				if (acms.sVoyageNo.Length < i1) {i1 = acms.sVoyageNo.Length;}
				if (cargo.VoyageNo.Length < i2) {i2 = cargo.VoyageNo.Length;}
				if( acms.sVoyageNo.Substring(0,i1) != cargo.VoyageNo.Substring(0,i2) )
				{
					dr["c_voyage_match"] = "N";
				}
				cargo.BookingNo = dr["booking_no"].ToString();
				//cargo.POD = acms.sPODLocation;
				cargo.PODTerminal = acms.sPODTerminal;
				//cargo.POE = acms.sPOELocation;
				cargo.POETerminal = acms.sPOETerminal;
				cargo.ItemNo = acms.lItemNo;
				if (acms.sPOELocation != cargo.POE ||
					acms.sPODLocation != cargo.POD)
				{
					dr["c_voyage_match"] = "N";
				}

				if( dr["c_voyage_match"].ToString() == "Y")
				{
					dr.Delete();
					continue;
				}

				LoadedCargoList.Add(cargo);
			}
			return dt;
		}

		public static DataTable LoadCargoVesselDeparted(DataTable dt)
		{
			// This does the following
			//  1. It removes rows from the datatable for cargo that
			//     has already created ITV data (
			//  2. It creates a LIST of cargo activity that can be used
			//     in other processing.

			DepartedCargoList = new List<ClsLoadedCargo>();
			dt.Columns.Add("c_vd_count");
			dt.Columns.Add("c_ae_count");
			dt.Columns.Add("c_rdd");
			dt.Columns.Add("c_acms_booking_no");
			dt.Columns.Add("c_acms_pcfn");
			dt.Columns.Add("c_departdt");
			dt.Columns.Add("c_acmsvoyage");
			foreach( DataRow dr in dt.Rows )
			{
				ClsLoadedCargo cargo = new ClsLoadedCargo();
				cargo.TCN = dr["tcn"].ToString();
				cargo.CargoStatus = dr["cargo_status"].ToString();
				cargo.VoyageNo = dr["voyageno"].ToString();
				cargo.BookingNo = dr["booking_no"].ToString();
				cargo.FinalBookingNo = dr["final_booking_no"].ToString();
				cargo.FirstBookingNo = dr["first_booking_no"].ToString();
				cargo.TariffCd = dr["tariff_cd"].ToString();
				//if( cargo.BookingNo == "ARCA12004551" )
				//{
				//    string x = "x";
				//}
				string sType = dr["cargo_type"].ToString();
				string sRecDate = dr["recdate"].ToString();
				if( !string.IsNullOrEmpty(sRecDate) )
				{
					cargo.ReceivedDate = Convert.ToDateTime(sRecDate);
				}

				// Gather ACMS information for this cargo
				ClsAcmsSQL.ACMSBookingData acms = ClsAcmsSQL.GetACMSData(cargo.VoyageNo, cargo.TCN);
				dr["c_rdd"] = acms.dtRDD;
				dr["c_acms_booking_no"] = acms.sBooking;
				dr["c_acms_pcfn"] = acms.sPCFN;
				dr["c_departdt"] = acms.dtDepartureDt;
				dr["c_acmsvoyage"] = acms.sVoyageNo;
				cargo.BookingNo = acms.sBooking;
				cargo.BookingNoSub = acms.sBookingSub;
				cargo.PCFN = acms.sPCFN;
				cargo.POD = acms.sPODLocation;
				cargo.PODTerminal = acms.sPODTerminal;
				cargo.POE = acms.sPOELocation;
				cargo.POETerminal = acms.sPOETerminal;
				cargo.ItemNo = acms.lItemNo;
				cargo.ACMSVoyageNo = acms.sVoyageNo;
				cargo.ACMSDepartDt = acms.dtDepartureDt;


				// Looks for ITV data using the LINE voyageno and TCN.
				cargo.VD_DepartCount = ClsConvert.ToInt32(ClsAcmsSQL.ActivityCount(cargo.VoyageNo, cargo.TCN, "VD"));
				dr["c_vd_count"] = cargo.VD_DepartCount;
				cargo.AE_LoadCount = ClsConvert.ToInt32(ClsAcmsSQL.ActivityCount(cargo.VoyageNo, cargo.TCN, "AE"));
				dr["c_ae_count"] = cargo.AE_LoadCount;
				if( cargo.VD_DepartCount != 0 && cargo.AE_LoadCount != 0 )
				{
					dr.Delete();
					continue;
				}
				if( string.IsNullOrEmpty(cargo.BookingNo) )
				{
					dr.Delete();
					continue;
				}
				if( acms.dtDepartureDt == null )
				{
					dr.Delete();
					continue;
				}
				//if( cargo.VoyageNo != "CB105" )
				//{
				//    dr.Delete();
				//    continue;
				//}
				DepartedCargoList.Add(cargo);
			}

			return dt;
		}

		public static DataTable LoadCargoVesselArrived(DataTable dt)
		{
			// This does the following
			//  1. It removes rows from the datatable for cargo that
			//     has already created ITV data (
			//  2. It creates a LIST of cargo activity that can be used
			//     in other processing.


			ArrivedCargoList = new List<ClsLoadedCargo>();
			dt.Columns.Add("c_va_count");
			dt.Columns.Add("c_uv_count");
			dt.Columns.Add("c_oa_count");
			dt.Columns.Add("c_x1_count");
			dt.Columns.Add("c_rdd");
			dt.Columns.Add("c_acms_booking_no");
			dt.Columns.Add("c_acms_pcfn");
			dt.Columns.Add("c_arrivedt");
			dt.Columns.Add("c_acmsvoyage");
			foreach( DataRow dr in dt.Rows )
			{
				ClsLoadedCargo cargo = new ClsLoadedCargo();
				cargo.TCN = dr["tcn"].ToString();
				cargo.CargoStatus = dr["cargo_status"].ToString();
				cargo.VoyageNo = dr["voyageno"].ToString();
				cargo.BookingNo = dr["booking_no"].ToString();
				cargo.MoveTypeCd = dr["move_type"].ToString();
				cargo.FinalBookingNo = dr["final_booking_no"].ToString();
				cargo.FirstBookingNo = dr["first_booking_no"].ToString();
				cargo.transInfo = dr["trans_info"].ToString();
				cargo.TariffCd = dr["tariff_cd"].ToString();
				string sType = dr["cargo_type"].ToString();
				string sRecDate = dr["recdate"].ToString();
				if( !string.IsNullOrEmpty(sRecDate) )
				{
					cargo.ReceivedDate = Convert.ToDateTime(sRecDate);
				}
				//if( cargo.BookingNo == "ARCA12004480" )
				//{
				//    string s = "S";
				//}
				// Gather ACMS information for this cargo
				// If it's the last leg of a transhipment, there is a separate
				// routine that gets data based on the first booking number.
				ClsAcmsSQL.ACMSBookingData acms;
				if( cargo.isLastLegTransshipment )
				{
					/* Temporary: Skip these complete for now */
					acms = ClsAcmsSQL.GetACMSDataBooking(cargo.BookingNo, cargo.TCN);
					continue;
				}
				else
					acms = ClsAcmsSQL.GetACMSData(cargo.VoyageNo, cargo.TCN);

				dr["c_rdd"] = acms.dtRDD;
				dr["c_acms_booking_no"] = acms.sBooking;
				dr["c_acms_pcfn"] = acms.sPCFN;
				dr["c_arrivedt"] = acms.dtArriveDt;
				dr["c_acmsvoyage"] = acms.sVoyageNo;
				cargo.BookingNo = acms.sBooking;
				cargo.BookingNoSub = acms.sBookingSub;
				cargo.PCFN = acms.sPCFN;
				cargo.POD = acms.sPODLocation;
				cargo.PODTerminal = acms.sPODTerminal;
				cargo.POE = acms.sPOELocation;
				cargo.POETerminal = acms.sPOETerminal;
				cargo.ItemNo = acms.lItemNo;
				cargo.ACMSVoyageNo = acms.sVoyageNo;
				cargo.ACMSDepartDt = acms.dtArriveDt;
				cargo.ACMSArriveDt = acms.dtArriveDt;

				// Looks for ITV data using the LINE voyageno and TCN.
				if( cargo.isLastLegTransshipment )
				{
					cargo.VA_ArriveCount = ClsConvert.ToInt32(ClsAcmsSQL.ActivityCount (cargo.ACMSVoyageNo, cargo.TCN, "VA"));
					cargo.UV_DischargeCount = ClsConvert.ToInt32(ClsAcmsSQL.ActivityCount(cargo.ACMSVoyageNo, cargo.TCN, "UV"));
					cargo.OA_OutgateCount = ClsConvert.ToInt32(ClsAcmsSQL.ActivityCount(cargo.ACMSVoyageNo, cargo.TCN, "OA"));
					cargo.X1_DeliveredCount = ClsConvert.ToInt32(ClsAcmsSQL.ActivityCount(cargo.ACMSVoyageNo, cargo.TCN, "X1"));
				}
				else
				{
					cargo.VA_ArriveCount = ClsConvert.ToInt32(ClsAcmsSQL.ActivityCount(cargo.VoyageNo, cargo.TCN, "VA"));
					cargo.UV_DischargeCount = ClsConvert.ToInt32(ClsAcmsSQL.ActivityCount(cargo.VoyageNo, cargo.TCN, "UV"));
					cargo.OA_OutgateCount = ClsConvert.ToInt32(ClsAcmsSQL.ActivityCount(cargo.VoyageNo, cargo.TCN, "OA"));
					cargo.X1_DeliveredCount = ClsConvert.ToInt32(ClsAcmsSQL.ActivityCount(cargo.VoyageNo, cargo.TCN, "X1"));

				}

				dr["c_va_count"] = cargo.VA_ArriveCount;
				dr["c_uv_count"] = cargo.UV_DischargeCount;
				dr["c_oa_count"] = cargo.OA_OutgateCount;
				dr["c_x1_count"] = cargo.X1_DeliveredCount;


				switch( cargo.MoveTypeCd )
				{
					case "F7":
					case "F8":
					case "F9":
						if( cargo.UV_DischargeCount != 0 && cargo.VA_ArriveCount != 0 )
						{
							dr.Delete();
							continue;
						}
						break;
					default:
						if( cargo.UV_DischargeCount != 0 && cargo.VA_ArriveCount != 0 &&
							cargo.X1_DeliveredCount != 0 && cargo.OA_OutgateCount != 0)
						{
							dr.Delete();
							continue;
						}
						break;

				}

				if( string.IsNullOrEmpty(cargo.BookingNo) )
				{
					dr.Delete();
					continue;
				}
				if( acms.dtArriveDt == null )
				{
					dr.Delete();
					continue;
				}
				//if( cargo.VoyageNo != "CB105" )
				//{
				//    dr.Delete();
				//    continue;
				//}
				ArrivedCargoList.Add(cargo);
			}

			return dt;
		}

		public static DataTable LoadCargoPendingDoorITV(DataTable dt, int daysold)
		{
			// This does the following
			//  1. It removes rows from the datatable for cargo that
			//     has already created ITV data (
			//  2. It creates a LIST of cargo activity that can be used
			//     in other processing.

			PendingDoorITVList = new List<ClsLoadedCargo>();
			dt.Columns.Add("c_va_count");
			dt.Columns.Add("c_uv_count");
			dt.Columns.Add("c_oa_count");
			dt.Columns.Add("c_x1_count");
			dt.Columns.Add("c_rdd");
			dt.Columns.Add("c_acms_booking_no");
			dt.Columns.Add("c_acms_pcfn");
			dt.Columns.Add("c_arrivedt");
			dt.Columns.Add("c_acmsvoyage");
			foreach( DataRow dr in dt.Rows )
			{
				ClsLoadedCargo cargo = new ClsLoadedCargo();
				cargo.TCN = dr["tcn"].ToString();
				cargo.CargoStatus = dr["cargo_status"].ToString();
				cargo.VoyageNo = dr["voyageno"].ToString();
				cargo.BookingNo = dr["booking_no"].ToString();
				cargo.MoveTypeCd = dr["move_type"].ToString();
				cargo.PLOR = dr["plor"].ToString();
				cargo.PLOD = dr["plod"].ToString();
				string sType = dr["cargo_type"].ToString();
				string sRecDate = dr["recdate"].ToString();
				if( !string.IsNullOrEmpty(sRecDate) )
				{
					cargo.ReceivedDate = Convert.ToDateTime(sRecDate);
				}

				// Gather ACMS information for this cargo
				ClsAcmsSQL.ACMSBookingData acms = ClsAcmsSQL.GetACMSData(cargo.VoyageNo, cargo.TCN);
				dr["c_rdd"] = acms.dtRDD;
				dr["c_acms_booking_no"] = acms.sBooking;
				dr["c_acms_pcfn"] = acms.sPCFN;
				dr["c_arrivedt"] = acms.dtArriveDt;
				dr["c_acmsvoyage"] = acms.sVoyageNo;
				cargo.BookingNo = acms.sBooking;
				cargo.BookingNoSub = acms.sBookingSub;
				cargo.PCFN = acms.sPCFN;
				cargo.POD = acms.sPODLocation;
				cargo.PODTerminal = acms.sPODTerminal;
				cargo.POE = acms.sPOELocation;
				cargo.POETerminal = acms.sPOETerminal;
				cargo.ItemNo = acms.lItemNo;
				cargo.ACMSVoyageNo = acms.sVoyageNo;
				cargo.ACMSDepartDt = acms.dtArriveDt;
				cargo.ACMSArriveDt = acms.dtArriveDt;

				if( string.IsNullOrEmpty(cargo.PLOR) )
					cargo.PLOR = cargo.POE;
				if( string.IsNullOrEmpty(cargo.PLOD) )
					cargo.PLOD = cargo.POD;

				// Looks for ITV data using the LINE voyageno and TCN.
				cargo.VA_ArriveCount = ClsConvert.ToInt32(ClsAcmsSQL.ActivityCount(cargo.VoyageNo, cargo.TCN, "VA"));
				dr["c_va_count"] = cargo.VA_ArriveCount;
				cargo.UV_DischargeCount = ClsConvert.ToInt32(ClsAcmsSQL.ActivityCount(cargo.VoyageNo, cargo.TCN, "UV"));
				dr["c_uv_count"] = cargo.UV_DischargeCount;
				cargo.OA_OutgateCount = ClsConvert.ToInt32(ClsAcmsSQL.ActivityCount(cargo.VoyageNo, cargo.TCN, "OA"));
				dr["c_oa_count"] = cargo.OA_OutgateCount;
				cargo.X1_DeliveredCount = ClsConvert.ToInt32(ClsAcmsSQL.ActivityCount(cargo.VoyageNo, cargo.TCN, "X1"));
				dr["c_x1_count"] = cargo.X1_DeliveredCount;

				if( string.IsNullOrEmpty(cargo.BookingNo) )
				{
					dr.Delete();
					continue;
				}
				if( acms.dtArriveDt == null )
				{
					dr.Delete();
					continue;
				}



				if( cargo.X1_DeliveredCount != 0 && cargo.OA_OutgateCount != 0 )
				{
					dr.Delete();
					continue;
				}

				if( DateTime.Today - acms.dtArriveDt < TimeSpan.FromDays(daysold) )
				{
					dr.Delete();
					continue;
				}

				PendingDoorITVList.Add(cargo);
			}

			return dt;
		}

		public static DataTable LoadCargoForCreateITV(DataTable dt, ProtocolParameters parms)
		{
			// This does the following
			//  1. It creates a LIST of cargo activity that can be used
			//     in other processing.

			CargoForCreateItv = new List<ClsLoadedCargo>();
			dt.Columns.Add("c_ee_count");
			dt.Columns.Add("c_w_count");
			dt.Columns.Add("c_i_count");
			dt.Columns.Add("c_ae_count");
			dt.Columns.Add("c_va_count");
			dt.Columns.Add("c_vd_count");
			dt.Columns.Add("c_uv_count");
			dt.Columns.Add("c_oa_count");
			dt.Columns.Add("c_av_count");
			dt.Columns.Add("c_x1_count");
			dt.Columns.Add("c_ec_count");
			dt.Columns.Add("c_hg_count");
			dt.Columns.Add("c_hr_count");
			dt.Columns.Add("c_sd_count");
			dt.Columns.Add("c_bd_count");
			dt.Columns.Add("c_rd_count");
			dt.Columns.Add("c_rdd");
			dt.Columns.Add("c_acms_booking_no");
			dt.Columns.Add("c_acms_pcfn");
			dt.Columns.Add("c_arrivedt");
			dt.Columns.Add("c_acmsvoyage");
			dt.Columns.Add("c_start_delay_count");
			dt.Columns.Add("c_end_delay_count");
			foreach( DataRow dr in dt.Rows )
			{
				ClsLoadedCargo cargo = new ClsLoadedCargo();
				cargo.TCN = dr["tcn"].ToString();
				cargo.CargoStatus = dr["cargo_status"].ToString();
				cargo.VoyageNo = dr["voyageno"].ToString();
				cargo.BookingNo = dr["booking_no"].ToString();
				cargo.VesselCd = dr["vessel_cd"].ToString();

				cargo.MoveTypeCd = dr["move_type"].ToString();
				cargo.PCFN = dr["pcfn"].ToString();
				cargo.transInfo = dr["trans_info"].ToString();
				cargo.TariffCd = dr["tariff_cd"].ToString();
				cargo.FinalBookingNo = dr["final_booking_no"].ToString();
				string sType = dr["cargo_type"].ToString();
				string sRecDate = dr["recdate"].ToString();
				if( !string.IsNullOrEmpty(sRecDate) )
				{
					cargo.ReceivedDate = Convert.ToDateTime(sRecDate);
				}

				// Apply last-minute filters that were not included
				// in the main search
				if( !string.IsNullOrEmpty(parms.PCFN) && parms.PCFN != "%" )
				{
					if (cargo.PCFN != parms.PCFN)
					{
						dr.Delete();
						continue;
					}
				}
				if( !string.IsNullOrEmpty(parms.TCN) && parms.TCN != "%" )
				{
					if( cargo.TCN != parms.TCN )
					{
						dr.Delete();
						continue;
					}
				}
				// Gather ACMS information for this cargo
				ClsAcmsSQL.ACMSBookingData acms = ClsAcmsSQL.GetACMSData(cargo.VoyageNo, cargo.TCN);
				dr["c_rdd"] = acms.dtRDD;
				dr["c_acms_booking_no"] = acms.sBooking;
				dr["c_acms_pcfn"] = acms.sPCFN;
				dr["c_arrivedt"] = acms.dtArriveDt;
				dr["c_acmsvoyage"] = acms.sVoyageNo;
				cargo.BookingNo = acms.sBooking;
				cargo.BookingNoSub = acms.sBookingSub;
				cargo.PCFN = acms.sPCFN;
				cargo.POD = acms.sPODLocation;
				cargo.PODTerminal = acms.sPODTerminal;
				cargo.POE = acms.sPOELocation;
				cargo.POETerminal = acms.sPOETerminal;
				cargo.ItemNo = acms.lItemNo;
				cargo.ACMSVoyageNo = acms.sVoyageNo;
				cargo.ACMSDepartDt = acms.dtArriveDt;
				cargo.ACMSArriveDt = acms.dtArriveDt;
				cargo.Rdd = acms.dtRDD;


				// Looks for ITV data using the LINE voyageno and TCN.
				cargo._eeCount = ClsConvert.ToInt32(ClsAcmsSQL.ActivityCount(cargo.VoyageNo, cargo.TCN, "EE"));
				dr["c_ee_count"] = cargo._eeCount;

				cargo.W_PickupCount = ClsConvert.ToInt32(ClsAcmsSQL.ActivityCount(cargo.VoyageNo, cargo.TCN, "W"));
				dr["c_w_count"] = cargo.W_PickupCount;

				cargo.I_InGateCount = ClsConvert.ToInt32(ClsAcmsSQL.ActivityCount(cargo.VoyageNo, cargo.TCN, "I"));
				dr["c_i_count"] = cargo.UV_DischargeCount;

				cargo.AE_LoadCount = ClsConvert.ToInt32(ClsAcmsSQL.ActivityCount(cargo.VoyageNo, cargo.TCN, "AE"));
				dr["c_ae_count"] = cargo.AE_LoadCount;

				cargo.VD_DepartCount = ClsConvert.ToInt32(ClsAcmsSQL.ActivityCount(cargo.VoyageNo, cargo.TCN, "VD"));
				dr["c_vd_count"] = cargo.VD_DepartCount;

				cargo.VA_ArriveCount = ClsConvert.ToInt32(ClsAcmsSQL.ActivityCount(cargo.VoyageNo, cargo.TCN, "VA"));
				dr["c_va_count"] = cargo.VA_ArriveCount;

				cargo.UV_DischargeCount = ClsConvert.ToInt32(ClsAcmsSQL.ActivityCount(cargo.VoyageNo, cargo.TCN, "UV"));
				dr["c_uv_count"] = cargo.UV_DischargeCount;

				cargo.OA_OutgateCount = ClsConvert.ToInt32(ClsAcmsSQL.ActivityCount(cargo.VoyageNo, cargo.TCN, "OA"));
				dr["c_oa_count"] = cargo.OA_OutgateCount;
				
				cargo.AV_AvailableCount = ClsConvert.ToInt32(ClsAcmsSQL.ActivityCount(cargo.VoyageNo, cargo.TCN, "AV"));
				dr["c_av_count"] = cargo.AV_AvailableCount;

				cargo.X1_DeliveredCount = ClsConvert.ToInt32(ClsAcmsSQL.ActivityCount(cargo.VoyageNo, cargo.TCN, "X1"));
				dr["c_x1_count"] = cargo.X1_DeliveredCount;

				cargo.ec_Count = ClsConvert.ToInt32(ClsAcmsSQL.ActivityCount(cargo.VoyageNo, cargo.TCN, "EC"));
				dr["c_ec_count"] = cargo.ec_Count;

				cargo.rd_Count = ClsConvert.ToInt32(ClsAcmsSQL.ActivityCount(cargo.VoyageNo, cargo.TCN, "RD"));
				dr["c_rd_count"] = cargo.rd_Count;

				cargo.hg_Count = ClsConvert.ToInt32(ClsAcmsSQL.ActivityCount(cargo.VoyageNo, cargo.TCN, "HG"));
				dr["c_hg_count"] = cargo.hg_Count;
				cargo.hr_Count = ClsConvert.ToInt32(ClsAcmsSQL.ActivityCount(cargo.VoyageNo, cargo.TCN, "HR"));
				dr["c_hr_count"] = cargo.hr_Count;

				cargo.sd_Count = ClsConvert.ToInt32(ClsAcmsSQL.ActivityCount(cargo.VoyageNo, cargo.TCN, "SD"));
				dr["c_sd_count"] = cargo.sd_Count;
				cargo.bd_Count = ClsConvert.ToInt32(ClsAcmsSQL.ActivityCount(cargo.VoyageNo, cargo.TCN, "BD"));
				dr["c_bd_count"] = cargo.bd_Count;

				cargo.StartDelayCount = ClsConvert.ToInt32(ClsAcmsSQL.ActivityCount(cargo.VoyageNo, cargo.TCN, "A1"));
				dr["c_start_delay_cound"] = cargo.StartDelayCount;
				cargo.EndDelayCount = ClsConvert.ToInt32(ClsAcmsSQL.ActivityCount(cargo.VoyageNo, cargo.TCN, "A2"));
				dr["c_end_delay_count"] = cargo.EndDelayCount;

				if( parms.OnDelay )
				{
					/* If only looking for cargo that is currently on an 
					 * Authorized Delay, delete if the delay count is not
					 * greater than the release count */
					if(cargo.hg_Count <= cargo.hr_Count &&
						cargo.sd_Count <= cargo.bd_Count &&
						cargo.StartDelayCount <= cargo.EndDelayCount)
					{
						dr.Delete();
						continue;
					}
				}

				if( string.IsNullOrEmpty(cargo.BookingNo) )
				{
					dr.Delete();
					continue;
				}
				CargoForCreateItv.Add(cargo);
			}

			return dt;
		}

		public static DataTable GetContainerBlankTCNList(int days)
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendFormat(@"
				SELECT dba.bu4_cont.bu4remgte AS tcn, dba.bu1_kopf.bu1loesch AS deleted, dba.bu1_kopf.bu1bunr AS booking_no, ISNULL(dba.bu1_kopf.bu1ediref, 
					   dba.bu1_kopf.bu1kdref) AS pcfn, ISNULL(dba.bu1_kopf.bu1ediref, 'Manual') AS create_source, dba.bu1_kopf.bu1vskond AS move_type, 
					   dba.bu1_kopf.bu1kdmtc AS customer, dba.bu4_cont.bu4ecstatus AS cargo_status, CONVERT(char(10), dba.bu4_cont.bu4cargorecvdate, 101) AS recdate,
					   'CONTAINER' AS cargo_type, dba.bu1_kopf.bu1createuser, dba.bu1_kopf.bu1voyage AS voyageno, dba.bu1_kopf.bu1polcde AS POL, 
					  dba.bu1_kopf.bu1podcde AS POD
				FROM  dba.bu4_cont INNER JOIN
					  dba.bu1_kopf ON dba.bu4_cont.bu4bumanr = dba.bu1_kopf.bu1bumanr
				WHERE(dba.bu4_cont.bu4remgte IS NULL or rtrim(bu4remgte) = '') 
				  AND (dba.bu1_kopf.bu1loesch = 'N') 
				  AND (dba.bu4_cont.bu4ecstatus IN ('LOAD', 'EXRC', 'DELV', 'DISC')) 
				  AND (dba.bu1_kopf.bu1kdmtc LIKE '%SDDC%') 
				  AND (dba.bu1_kopf.bu1status2 = 'C') 
				  AND (dba.bu4_cont.bu4cargorecvdate > GETDATE() - {0})", days);
			DataTable dt = Connection.GetDataTable(sb.ToString());
			return dt;
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
				  dba.bu1_kopf AS lleg ON fleg.bu1bunr = lleg.bu1uniquenr ");

			DataTable dt = Connection.GetDataTable(sql);
			return dt;
		}

		#endregion

		#region Queries
		public static DataRow GetBookingByPCFN(string sPCFN)
		{
			string sql = string.Format(@"
				select * from dba.bu1_kopf b
                  where b.bu1ediref like '{0}' ", sPCFN);
			DataTable dt = Connection.GetDataTable(sql);
			if (dt.Rows.Count < 1)
				return null;
			return dt.Rows[0];
		}

		#endregion

		#region Misc Reporting

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

		public static DataTable GetLocations()
		{
			string sql = @"
					SELECT firma, lccode, lcname, lcland, lctype, lcdefslcode
					FROM dba.lokation
					WHERE     (firma = 'ARC') ";
			DataTable dt = Connection.GetDataTable(sql);
			return dt;
		}

		public static int GetLineDetailCount(string sBookingNo, string sStatus)
		{
			string sql = string.Format(@"
			SELECT COUNT(*) 
			 FROM  dba.bu1_kopf, dba.bu3_item, dba.bu14_itemdetail
			WHERE  dba.bu1_kopf.bu1bumanr = dba.bu3_item.bu3bumanr AND dba.bu3_item.bu3bumanr = dba.bu14_itemdetail.bu14manr AND 
				   dba.bu3_item.bu3bulfnr = dba.bu14_itemdetail.bu14lfnr AND (dba.bu1_kopf.bu1bunr = '{0}') 
			AND  (dba.bu14_itemdetail.bu14status like '{1}') ", sBookingNo, sStatus);

			string s = Connection.GetScalar(sql).ToString();
			int iBbulk = ClsConvert.ToInt32(s);


			sql = string.Format(@"
				SELECT     COUNT(*) 
				FROM         dba.car_head
				WHERE     (cr1_bunr = '{0}') AND (cr1_ecstatus LIKE '{1}')", sBookingNo, sStatus);
			s = Connection.GetScalar(sql).ToString();
			int iRoro = ClsConvert.ToInt32(s);
			return iBbulk + iRoro;
		}

		public static void RunSQL(string sql)
		{
			Connection.RunSQL(sql);
		}

		public static DataTable FindBB(string sID)
		{
			string sqlFindBB = string.Format(@"
			SELECT bu14_itemdetail_id
			FROM dba.bu14_itemdetail where bu14_itemdetail_id = {0} ", sID);

			DataTable dt = Connection.GetDataTable(sqlFindBB);
			return dt;
		}
		public static DataTable FindRoRo(string sID)
		{
			string sqlFindRoRo = string.Format(@"
			select dba.car_head.cr1_manr
              from dba.car_head
            where dba.car_head.cr1_manr = {0}
              and dba.car_head.cr1_bumanr is not null", sID);
			DataTable dt = Connection.GetDataTable(sqlFindRoRo);
			return dt;
		}

		#endregion



	}
	#region Create Voyages
	public class CreateVoyageData
	{
		public string Service { get; set; }
		public string TradeLane { get; set; }
		public string Direction { get; set; }
		public string VesselCd { get; set; }
		public string Voyage { get; set; }
		public string EffectiveVoyage
		{
			get
			{
				if (VesselCd == "SV")
					return "381";
				if (VesselCd == "CP")
					return "378";
				if (VesselCd == "SBR")
					return "425";
				return Voyage.Substring(2, 3);
			}
		}
		public string CurUser { get; set; }
		public string CentralPort { get; set; }

		public string POL { get; set; }
		public string POD { get; set; }
		public DateTime PreDepart { get; set; }
		public DateTime Depart { get; set; }
		public DateTime Arrive { get; set; }
		public DateTime PostArrive { get; set; }
		public string ErrorMsg { get; set; }
		private int? _VesselRouteID;
		public int? VesselRouteID
		{
			get
			{

				if (VesselCd == "SV")
					_VesselRouteID = 8307;
				if (VesselCd == "CP")
					_VesselRouteID = 8295;
				if (VesselCd == "SBR")
					_VesselRouteID = 7661;
				if (_VesselRouteID != null)
					return _VesselRouteID.GetValueOrDefault();
				return _VesselRouteID;
			}
		}
	}
	public class CreateVoyage
	{
		public CreateVoyageData voyData;
		public bool CreateLINEVoyage(CreateVoyageData vdata)
		{
			try
			{
				voyData = vdata;
				ClsLineSQL.Connection.TransactionBegin();
				if (ClsLineSQL.GetVoyage(vdata.Voyage) != null)
				{
					ClsLineSQL.Connection.TransactionCommit();
					return true;
				}
				CreateVoyageHeader();
				CreateVoyagePorts();
				ClsLineSQL.Connection.TransactionCommit();
				return true;
			}
			catch (SqlException ex)
			{
				if (ex.Message.Contains("subquery"))
				{
					ClsLineSQL.Connection.TransactionRollback();
					return true;
				}
				ClsLineSQL.Connection.TransactionCommit();
				return false;
			}
			catch (Exception ex)
			{
				ClsLineSQL.Connection.TransactionRollback();
				voyData.ErrorMsg = ex.Message;
				return false;
			}
		}

		public  void CreateVoyageHeader()
		{

			// Inserts a row to the voyage header table
			List<DbParameter> p = new List<DbParameter>();
			string sql = string.Format(@"
			insert into dba.reise
				(firma, reservice,reschiff,rereisenr,rermanr,recentralport,rei_row_state, restatus, recentralseqno, recreatebooking, recreatebl,
				recredat, rechgdat, reuser, reexim, reroute,
				redakabnr)
				values
				('ARC','{0}','{1}', '{2}', 
				(select max(rermanr) + 1 from dba.reise)
				, '{3}',  0, 'A', 1, 'N', 'N', getdate(), getdate(), '{4}', 'E', '{5}',
				(select nknr + 1 from dba.nummernkreis where firma = 'ARC' and nkname = 'VOYAGEMANO')
				) ", voyData.Service, voyData.VesselCd, voyData.Voyage, voyData.CentralPort, voyData.CurUser, voyData.TradeLane);
			ClsLineSQL.Connection.RunSQL(sql);

			// Updates the table to stores the next id for voyages
			sql = string.Format(@"
			  update dba.nummernkreis
			   set nknr = (select nknr from dba.nummernkreis where firma = 'ARC' and nkname = 'VOYAGEMANO') + 1
				where firma = 'ARC'
				 and nkname = 'VOYAGEMANO' ");

			ClsLineSQL.Connection.RunSQL(sql);
		}

		public void CreateVoyagePorts()
		{
			/* POL */
			string sqlBase = string.Format(@"
			  insert into dba.reise_hafen
			   (
			  firma,  rhservice,  rhvessel,  rhreise,
			  rhrmanr,  rhetseta,  rhhafen,  rhseqno,
			  rhstatper,  rhdslkdat,  rhvslkdat,  rhdsfdat,
			  rhfeedkz,  rhporttype,  rheta,  rhdirectiontype,
			  rhstatus,  rhcreatebooking,  rhcreatebl
			  )
			  values
			  (
			  'ARC',  'E',  @VESSEL,  @VOYAGENO,
			  (select rermanr from dba.reise where rereisenr = '{0}' and firma = 'ARC' ),
			  @DEPARTDT,  @PORT,  @SEQNO ,
			  getdate(),  getdate(),  getdate(),  getdate(),
			  'N',  @PORTTYPE,  @ARRIVEDT,  @DIRECTION,
			  'PP', 'N','N' )", voyData.Voyage);

			string sql = sqlBase;
			List<DbParameter> p = new List<DbParameter>();
			p.Add(ClsLineSQL.Connection.GetParameter("@VESSEL", voyData.VesselCd));
			p.Add(ClsLineSQL.Connection.GetParameter("@VOYAGENO", voyData.Voyage));
			p.Add(ClsLineSQL.Connection.GetParameter("@PORT", voyData.POL));
			p.Add(ClsLineSQL.Connection.GetParameter("@DIRECTION", voyData.Direction));
			p.Add(ClsLineSQL.Connection.GetParameter("@PORTTYPE", "L"));
			p.Add(ClsLineSQL.Connection.GetParameter("@SEQNO", 1));
			p.Add(ClsLineSQL.Connection.GetParameter("@DEPARTDT", voyData.Depart));
			p.Add(ClsLineSQL.Connection.GetParameter("@ARRIVEDT", voyData.PreDepart));
			ClsLineSQL.Connection.RunSQL(sql, p.ToArray());
			
			/* POD */
			p = new List<DbParameter>();
			sql = sqlBase;
			p = new List<DbParameter>();
			p.Add(ClsLineSQL.Connection.GetParameter("@VESSEL", voyData.VesselCd));
			p.Add(ClsLineSQL.Connection.GetParameter("@VOYAGENO", voyData.Voyage));
			p.Add(ClsLineSQL.Connection.GetParameter("@PORT", voyData.POD));
			p.Add(ClsLineSQL.Connection.GetParameter("@DIRECTION", voyData.Direction));
			p.Add(ClsLineSQL.Connection.GetParameter("@PORTTYPE", "D"));
			p.Add(ClsLineSQL.Connection.GetParameter("@SEQNO", 2));
			p.Add(ClsLineSQL.Connection.GetParameter("@DEPARTDT", voyData.PostArrive));
			p.Add(ClsLineSQL.Connection.GetParameter("@ARRIVEDT", voyData.Arrive));
			ClsLineSQL.Connection.RunSQL(sql, p.ToArray());

			CreateVoyageBerths(voyData.POL, 1);
			CreateVoyageBerths(voyData.POD, 2);
		}

		public void CreateVoyageBerths(string sPort, int iSeqNo)
		{
			string sberth = sPort + "1";
			string sqlBase = string.Format(@"
				 insert into dba.reise_berth
				  (firma, rbservice, rbvessel, rbrmanr,
				   rbhafen, rbseqno, rbberthcode, rbberthseqno,
				   rbuser, rblastchange)
				   values ('ARC', 'E', '{0}', 
					(select rermanr from dba.reise where rereisenr = '{4}' and firma = 'ARC' ),
					'{1}', {5}, '{2}', 1, '{3}', getdate())",
					voyData.VesselCd, sPort, sberth, voyData.CurUser, voyData.Voyage, iSeqNo);
			ClsLineSQL.Connection.RunSQL(sqlBase);
			string a  = sqlBase;
		}
	}
	#endregion
}

