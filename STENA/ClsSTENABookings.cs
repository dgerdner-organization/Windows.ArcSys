using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CS2010.Common;
using System.Data;
using System.Data.Common;
using CS2010.ArcSys.Business;
using CS2010.ACMS.Business;
using System.Text.RegularExpressions;

namespace STENA
{
	public static class ClsSTENABookings
	{
		#region Connection Manager

		private static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ArcSys"]; }
		}
		#endregion		// #region Connection Manager

		#region Methods
		public static bool UpdateSchedules(int iStart, int iDays)
		{
			Connection.TransactionStart();

			try
			{
				DataTable dtRoutes = ClsStenaRoute.GetAll();
				foreach (DataRow drow in dtRoutes.Rows)
				{
					ClsStenaRoute route = new ClsStenaRoute(drow);
					DateTime dtStart = DateTime.Today.AddDays(iStart);
					DateTime dtEnd = dtStart.AddDays(iDays);

					PurgeSailings(route.Route_Cd, dtStart, dtEnd);
					List<clsSTENASailings> sailings = ClsSTENAservice.GetSchedule(route.Route_Cd, dtStart, iDays);
					foreach (clsSTENASailings s in sailings)
					{
						ClsStenaRouteSailing rs = new ClsStenaRouteSailing();
						rs.Route_Cd = route.Route_Cd;
						rs.Sailing_Dt = s.DepartureDt.GetValueOrDefault();
						rs.Vessel_Nm = s.VesselNm;
						rs.Arrive_Dt = s.ArriveDt;
						rs.Status_Dsc = s.StatusDsc;
						rs.Insert();
					}
						
				}
				Connection.TransactionCommit();
				return true;
			}
			catch (Exception ex)
			{
				ClsErrorHandler.LogException(ex);
				Connection.TransactionRollback();
				throw ex;
			}
		}

		private static void PurgeSailings(string sRouteCd, DateTime dtStart, DateTime dtEnd)
		{
			List<DbParameter> p = new List<DbParameter>();

			DateRange dr = new DateRange();
			dr.From = dtStart;
			dr.To = dtEnd;

			StringBuilder sb = new StringBuilder();
			sb.AppendFormat(@" delete from r_stena_route_sailing 
											where route_cd = '{0}' ", sRouteCd);
			Connection.AppendDateClause(sb, p, "AND", "sailing_dt", "@STARTDT", "@ENDDT", dr);

			string sql = sb.ToString();
			Connection.RunSQL(sql, p.ToArray());
		}

		public static string UpdateVehicleTypes()
		{
			// Update the vehicle
			try
			{
				FWSReservationService.BookingMetadataClient p = new FWSReservationService.BookingMetadataClient();
				p.ClientCredentials.UserName.UserName = ClsSTENAservice.UserName;
				p.ClientCredentials.UserName.Password = ClsSTENAservice.UserPassword;

				FWSReservationService.VehicleType[] vTypes = p.ListVehicleTypes();
				StringBuilder sb = new StringBuilder();
				foreach (FWSReservationService.VehicleType v in vTypes)
				{
					bool bInsert = false;
					ClsStenaVehicleType t = ClsStenaVehicleType.GetUsingKey(v.Code);
					if (t == null)
					{
						bInsert = true;
						t = new ClsStenaVehicleType();
						t.Vehicle_Type_Cd = v.Code;
					}
					t.Vehicle_Type_Dsc = v.Description;
					t.Width_Nbr = v.Width;
					t.Height_Nbr = v.Height;
					t.Max_Length_Nbr = v.MaxLength;
					t.Min_Length_Nbr = v.MinLength;
					t.Weight_Nbr = v.Weight;
					if (bInsert)
						t.Insert();
					else
						t.Update();
				}
				return "success";
			}
			catch (Exception ex)
			{
				return ex.Message;
			}

		}
		public static void UpdateTrailerNumbers()
		{
			string sql = string.Format(@"p_stena_update_trailers");

			Connection.RunSQL(sql, CommandType.StoredProcedure);
		}

		public static void GetBookingConfirmations()
		{
			// 
			// Batch run through all ACMS bookings that have not been booked by STENA
			//
			int iCount = 0;
			string sBookingNo = "";
			try
			{
				DataTable dtUnbooked = ClsVStenaUnbooked.GetAll();
				foreach (DataRow drow in dtUnbooked.Rows)
				{
					iCount++;
					//if (iCount > 5)
					//    break;
					ClsVStenaUnbooked ub = new ClsVStenaUnbooked(drow);

					// Skip this if there is no booking number yet.
					if (string.IsNullOrEmpty(ub.Booking_No))
						continue;

					// Skip this if there is no Trailer number.
					if (string.IsNullOrEmpty(ub.Trailer_No))
						continue;

					sBookingNo = ub.Booking_No;
					// Get the ACMS Booking data to find hazardous info
					bool bHzd = false;
					CS2010.ACMS.Business.ClsBooking bk =
						CS2010.ACMS.Business.ClsBooking.GetUsingKey(ub.Partner_Cd, ub.Partner_Request_Cd);
					if (bk != null)
						bHzd = bk.HazardousGoods;

					clsBookingInfo bi = ClsSTENAservice.FindBooking(ub.Booking_No, ub.Trailer_No);
					if (bi.bookingid != null)
						if (UpdateStenaBookingID(ub.Booking_No, ub.Trailer_No, ub.Serial_No))
							continue;

					clsSTENABookingReturnData StenaData =
						 ClsSTENAservice.ConfirmBooking(ub.Booking_No, ub.Trailer_No,
							ub.Depart_Dt.GetValueOrDefault(), ub.Route_Cd, ub.Vehicle_Type_Cd, bHzd, bk.Partner_Request_Cd);

					if (!StenaData.bSuccess)
					{
						// If it fails, see if this booking/tcn already had an ID
						if (StenaData.sMessage.Contains("E1017-059"))
							if (UpdateStenaBookingID(ub.Booking_No, ub.Trailer_No, ub.Serial_No))
								continue;
						// If failed, write an audit record
						ClsStenaBookingAudit ba = new ClsStenaBookingAudit();
						ba.Booking_No = ub.Booking_No;
						ba.Stena_Error_Msg = StenaData.sMessage;
						ba.Serial_No = ub.Serial_No;
						ba.Trailer_No = ub.Trailer_No;
						ba.Depart_Dt = ub.Depart_Dt;
						ba.Route_Cd = ub.Route_Cd;
						ba.Insert();
					}
					else
					{
						// Otherwise, update the stena booking ID
						ClsStenaBooking sb = ClsStenaBooking.GetUsingKey(ub.Booking_No, ub.Serial_No);
						if (sb != null)
						{
							sb.Stena_ID = StenaData.StenaBookingID;
							sb.Update();
						}
					}

				}
			}
			catch (Exception ex)
			{
				string s = ex.Message;
			}

		}

		public static bool UpdateStenaBookingID(string sBookingNo, string sTrailerNo, string sSerialNo)
		{
			//
			//   Looks to see if Stena already has a booking ID for a specific piece of cargo.
			//   If it does, update our database with it.
			//
			try
			{
				clsBookingInfo bi = ClsSTENAservice.FindBooking(sBookingNo, sTrailerNo);
				if (bi != null)
				{
					if (bi.bookingid != null)
					{
						int? i = bi.bookingid;
						ClsStenaBooking booking = ClsStenaBooking.GetUsingKey(sBookingNo, sSerialNo);
						if (booking == null)
							return false;
						booking.Stena_ID = bi.bookingid;
						booking.Update();
					}
				}
				return true;
			}
			catch (Exception ex)
			{
				string s = ex.Message;
				return false;
			}
		}

		public static string BookStenaSingle(ClsBookingUnit bu, DateTime dtSailing)
		{
			StringBuilder sbResult = new StringBuilder();
			try
			{
				ClsCargoCode cargoCd = ClsCargoCode.GetUsingKey(bu.Cargo_ID.GetValueOrDefault());

				if (bu.StenaBooking == null)
				{
					sbResult.AppendFormat("TCN {0} does not have trailer numbers.  Discuss with IT.", bu.Tcn);
					return sbResult.ToString();
				}
				// See if there is an existing Stena Booking
				clsBookingInfo bInfo = ClsSTENAservice.FindBooking(bu.StenaBooking.Booking_No, bu.StenaBooking.Trailer_No);
				if (bInfo.bookingid != null)
				{
					bu.StenaBooking.Stena_ID = bInfo.bookingid;
					bu.StenaBooking.Sailing_Dt = bInfo.SailingDt;
					bu.StenaBooking.Update();
					//bFound = true;
					return sbResult.ToString();
				}

				// Get the ACMS Booking data to find hazardous info
				CS2010.ACMS.Business.ClsBooking bk =
					CS2010.ACMS.Business.ClsBooking.GetUsingKey(bu.Partner_Cd, bu.Partner_Request_Cd);
				bool bHzd = bk.HazardousGoods;

				// If no existing booking ID exists, try to find a new one
				clsSTENABookingReturnData bReturn =
					ClsSTENAservice.ConfirmBooking(bu.StenaBooking.Booking_No, bu.StenaBooking.Trailer_No,
					 dtSailing, bu.StenaRoutecd, cargoCd.Stena_Vehicle_Type_Cd, bHzd, bk.Partner_Request_Cd);
				if (bReturn.bSuccess)
				{
					bu.StenaBooking.Stena_ID = bReturn.StenaBookingID;
					bu.StenaBooking.Sailing_Dt = dtSailing;
					bu.StenaBooking.Update();
					//bFound = true;
				}
				else
				{
					sbResult.AppendFormat("Problem with {0}  {1}", bu.Tcn, bReturn.sMessage);
					// If failed, write an audit record
					ClsStenaBookingAudit ba = new ClsStenaBookingAudit();
					ba.Booking_No = bu.Booking_ID;
					ba.Stena_Error_Msg = bReturn.sMessage;
					ba.Serial_No = bu.Tcn;
					ba.Trailer_No = bu.StenaBooking.Trailer_No;
					ba.Depart_Dt = dtSailing;
					ba.Route_Cd = bu.StenaRoutecd;
					ba.Insert();
				}
				return sbResult.ToString();
			}
			catch (Exception ex)
			{
				sbResult.AppendFormat("Error: {0} ", ex.Message);
				return sbResult.ToString();
			}
		}

		public static void UpdateStenaBookingNos()
		{
			// If the booking ID is changed in t_booking_unit, we need to cascade through all rows
			// in t_stena_booking for that TCN, changing it's booking_no to match t_booking_unit.
			// Note that we only care about very, very recent stena bookings.  Anything more than a
			// couple of weeks old are not going to show up anywhere.
			string sql = string.Format(@"
					select s.serial_no, s.booking_no, bu.booking_id
					 from t_stena_booking s
					 left outer join t_booking_unit\@acmsp bu
					  on bu.tcn = s.serial_no
					 where create_dt > sysdate - 15
					  and s.booking_no <> bu.booking_id");

			DataTable dt = Connection.GetDataTable(sql);
			foreach (DataRow drow in dt.Rows)
			{
				// !!Need ExportToExcel fill this in later
			}
		}

		public static void PopulateTrailerNos()
		{
			// March 13, 2014 : DGERDNER
			// Use this now instead of the Stored Procedure and function.  Those can
			// be deleted.

			// First, get rid of all rows in t_stena_booking that don't have a
			// tailer number.
			string sql = string.Format(@"
			 	delete from t_stena_booking
				 where trailer_no is null
				  and create_dt > sysdate - 7");

			Connection.RunSQL(sql);

			// Find all booking/tcn's that need to have a trailer# assigned
			sql = string.Format(@"
				SELECT * from v_stena_no_trailer");

			// Loop through all cargo.  Extract the Trailer# from the delivery_dsc column,
			// then add a row to t_stena_booking.
			DataTable dt = Connection.GetDataTable(sql);
			foreach (DataRow drow in dt.Rows)
			{
				try
				{
					string sText = drow["delivery_dsc"].ToString().ToUpper();
					string sBookingNo = drow["booking_id"].ToString();
					string sSerialNo = drow["tcn"].ToString();
					string sTrailerNo = GetTrailerNo(sText, sSerialNo);
					ClsStenaBooking sb = ClsStenaBooking.GetUsingKey(sBookingNo, sSerialNo);
					if (sb == null)
					{
						sb = new ClsStenaBooking();
						sb.Booking_No = sBookingNo;
						sb.Trailer_No = sTrailerNo;
						sb.Serial_No = sSerialNo;
						sb.Insert();
					}
					else
					{
						sb.Trailer_No = sTrailerNo;
						if (sb.ValidateUpdate())
							sb.Update();
					}
				}
				catch (Exception ex)
				{
					ClsErrorHandler.LogException(ex);
					string sMsg = string.Format(@"{0} : STENA Demon * Fail * ", "Trailer #'s");
					//Program.SendEmail(sMsg, ex.Message);
				}
			}
		}

		public static string GetTrailerNo(string sText, string SerialNo)
		{
			sText = sText.Replace("-", "");
			sText = sText.Replace("EX ", "EX");
			string sTrlNo = "";
			if (SerialNo.Length < 4)
				return null;
			string sLastDigt = SerialNo.Substring(SerialNo.Trim().Length - 4, 1);
			int iParenPos = sText.IndexOf("(");
			int iTrlIndx = 0;
			if (iParenPos < 0)
			{
				iTrlIndx = 1;
			}
			else
			{
				int iMatchDigitPos = sText.IndexOf(sLastDigt, iParenPos) - iParenPos;
				iTrlIndx = ((iMatchDigitPos - 1) / 2) + 1;
			}
			int iTrlPos = NthIndexOf(sText, "EX", iTrlIndx);
			sTrlNo = sText.Substring(iTrlPos + 2, 4);
			return sTrlNo;
		}

		public static int NthIndexOf(string text, string searchText, int nthindex)
		{
			int index = -1;
			try
			{
				Match m = Regex.Match(text, "((" + searchText + ").*?){" + nthindex + "}");
				if (m.Success) index = m.Groups[2].Captures[nthindex - 1].Index;
			}
			catch { }
			return index;
		}
		#endregion
	}
}
