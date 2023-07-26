using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CS2010.Common;
using CS2010.ArcSys.Business;

namespace CS2010.ACMS.Business
{
	public class ClsACMSUtil
	{
		#region Connection Manager

		private static ClsConnection Connection
		{
			get
			{
				return ClsConMgr.Manager["ACMS"];
			}
		}
		#endregion		// #region Connection Manager
		public static void SetLogFTPSuccess(DataRow drow, string sFlag)
		{
			string sTableDsc = drow["table_dsc"].ToString();
			string sTransCtlNo = drow["trans_ctl_no"].ToString();
			string sql = string.Format(@"
				update t_edi_activity_ftp
				 set ftp_success_cd = '{0}'
				  where table_dsc = '{1}'
				   and trans_ctl_no = {2} ", sFlag, sTableDsc, sTransCtlNo);

			Connection.RunSQL(sql);
		}

		public static void Update304DeleteFlag()
		{
			//
			// The delete flag is currently defaulting to null.  Until this is 
			// corrected at the database level, we need to occassionally update
			// those rows.  This should be done immediately before searchign
			// for Shipping Instructions that are ready to be sent.
			//
			string sql = string.Format(@"
					update t_304_sent
					 set delete_fl = 'N'
					  where delete_fl is null ");
			Connection.RunSQL(sql);
		}

		public static bool SynchronizeITVData(string sBookingNo, string sTCN)
		{
			bool bInTrans = Connection.IsInTransaction;

			Connection.TransactionStart();
			try
			{
				// First, find the cargo row
				ClsBookingUnit bu = ClsBookingUnit.GetByTCN(sBookingNo, sTCN);
				if (bu == null)
					return false;

				// Find all ITV for this piece of cargo that has not yet been sent
				// (Ignore stuff that has already been sent, because it doesn't matter 
				// now.
				DataTable dtITV = ClsACMSQueries.GetITVNotSent();
				foreach (DataRow drow in dtITV.Rows)
				{
					ClsBookingItv itv = new ClsBookingItv(drow);
					if (itv.Booking_ID != sBookingNo || itv.Item_No != bu.Item_No)
						continue;

					if (itv.Voyage_No == bu.Voyage_No)
						continue;
					itv.Voyage_No = bu.Voyage_No;
					//switch (itv.Activity_Code)
					//{
					//    case "X1":
					//        itv.Location_Cd = bu.Pod_Location_Cd;
					//        itv.Terminal_Cd = bu.Pod_Terminal_Cd;
					//        break;
					//}
					itv.Update();
				}
				string sql = string.Format(@"
						update t_booking_itv set booking_sub = ' '
                          where booking_sub is null
                            and booking_id = '{0}'
                            and item_no = {1} ", sBookingNo, bu.Item_No);
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

		public static void SynchronizeLocations()
		{
			//
			// Synchronize locations between ACMS Database and ArcSys
			//
			DataTable dtACMS = CS2010.ACMS.Business.ClsLocation.GetAll();
			foreach (DataRow drow in dtACMS.Rows)
			{
				CS2010.ACMS.Business.ClsLocation aLoc = new ACMS.Business.ClsLocation(drow);
				CS2010.ArcSys.Business.ClsLocation bLoc = CS2010.ArcSys.Business.ClsLocation.GetUsingKey(aLoc.Location_Cd);
				if (bLoc != null)
					continue;
				if (aLoc.Delete_Fl == "Y")
					continue;
				bLoc = new CS2010.ArcSys.Business.ClsLocation();
				bLoc.Location_Cd = aLoc.Location_Cd;
				bLoc.Location_Dsc = aLoc.Location_Dsc;
				bLoc.Location_Type_Cd = "NA";
				bLoc.Active_Flg = "Y";
				bLoc.Border_Flg = bLoc.Checkpoint_Flg = bLoc.Gate_Flg =  bLoc.Hold_Area_Flg = "N";
				bLoc.Conus_Flg = "N";
				switch (aLoc.Country_Cd)
				{
					case "US":
					case "USA":
						bLoc.Geo_Region_Cd = "US";
						bLoc.Conus_Flg = "Y";
						break;
					case "UK":
					case "DE":
					case "FR":
						bLoc.Geo_Region_Cd = "EU";
						break;
				}
				bLoc.Insert();
			}

		}
	}
}
