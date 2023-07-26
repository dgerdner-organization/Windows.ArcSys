using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CS2010.Common;
using System.Reflection;
using System.IO;
using System.Data;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Configuration;
using System.Net.Mail;

namespace STENA
{
	public static class ClsSTENAservice
	{
		#region Properties
		public static string UserName
		{
			get
			{
				string s = "ECONNECT\\AMECAR";
				s = ConfigurationManager.AppSettings["STENAuserName"].ToString();
				return s;
			}
		}
		public static string UserPassword
		{
			get
			{
				string s = "Tr4u0m3sdFH";
				s = ConfigurationManager.AppSettings["STENAPassword"].ToString();
				return s;
			}
		}
		#endregion

		#region Public Methods
		public static List<clsSTENASailings> GetSchedule(string sRoute, DateTime dtStart, int iDays)
		{
			StringBuilder sb = new StringBuilder();
			List<clsSTENASailings> sailings = new List<clsSTENASailings>();
			try
			{
				System.Net.ServicePointManager.ServerCertificateValidationCallback = (senderX, certificate, chain, sslPolicyErrors) => { return true; };
				FWSReservationService.TimeTableClient px = new FWSReservationService.TimeTableClient();
				px.ClientCredentials.UserName.UserName = UserName;
				px.ClientCredentials.UserName.Password = UserPassword;
				FWSReservationService.RouteCodeCollection routes = new FWSReservationService.RouteCodeCollection();
				routes.Add(sRoute);
				sb.Clear();
				FWSReservationService.TimeTableSailing[] tts = px.SearchTimeTable(dtStart, dtStart.AddDays(iDays), routes);
				foreach (FWSReservationService.TimeTableSailing t in tts)
				{
					sb.AppendFormat("TimeTable: {0}  {1}  {2} ", t.RouteCode, t.ShipName, t.DepartureDateTime);
					sb.AppendLine();
					clsSTENASailings s = new clsSTENASailings();
					s.RouteCd = t.RouteCode;
					s.DepartureDt = t.DepartureDateTime;
					s.ArriveDt = t.ArrivalDateTime;
					if (s.ArriveDt == null)
						s.ArriveDt = t.EstimatedArrivalDateTime;
					s.Errors = sb.ToString();
					s.VesselNm = t.ShipName;
					s.StatusDsc = t.SailingStatus.ToString();
					if (t.SailingStatus.ToString().ToLower() != "open")
						s.StatusDsc = s.StatusDsc;
					sailings.Add(s);

				}

				return sailings;
			}
			catch (System.ServiceModel.FaultException mex)
			{
				if (mex.Code != null)
				{
					sb.AppendFormat("{0} {1} ", "STENA EXCEPTION", mex.Code);
				}
				else
				{
					sb.AppendFormat("{0} {1} ", "STENA EXCEPTION", mex.Message);
				}
				ClsErrorHandler.LogError(sb.ToString());
				//SendEmail("* STENA Error Getting Schedules *", sb.ToString());
				//return sailings;
				throw new Exception(mex.Message);
			}
		}

		public static StringBuilder GetRoutes()
		{
			StringBuilder sb = new StringBuilder();
			try
			{
				FWSReservationService.TimeTableClient p = new FWSReservationService.TimeTableClient();
				p.ClientCredentials.UserName.UserName = UserName;
				p.ClientCredentials.UserName.Password = UserPassword;
				FWSReservationService.CodeInfo[] rRoutes = p.ListRoutes();

				foreach (FWSReservationService.CodeInfo r in rRoutes)
				{
					string s3 = r.Type.ToString();
					string s = r.Code;
					string s2 = r.Description;
					sb.AppendFormat("route: {0} {1} ", s, s2);
					sb.AppendLine("");
				}
				return sb;
			}
			catch (System.ServiceModel.FaultException mex)
			{
				if (mex.Code != null)
				{
					sb.AppendFormat("{0} {2} ", "STENA EXCEPTION", mex.Code);
				}
				else
				{
					sb.AppendFormat("{0} {2} ", "STENA EXCEPTION", mex.Message);
				}
				return sb;
			}
			catch (Exception ex)
			{
				sb.Append(ex.Message);
				return sb;
			}
		}

		public static clsSTENABookingReturnData ConfirmBooking()
		{
			clsSTENABookingReturnData s = ConfirmBooking("ARCA001234", "1234", ClsConvert.ToDateTime("12/20/2013 9:00"), "HAHK", "TR", false, "12313");
			return s;
		}

		public static clsSTENABookingReturnData ConfirmBooking(string sBookingNo, string sTrailer, DateTime dtDepart,
					string sRoute, string sVehicleTypeCd, bool bHazardous, string sPCFN)
		{
			clsSTENABookingReturnData StenaData = new clsSTENABookingReturnData();

			bool bFatalEx = false;
			FWSReservationService.Booking b = new FWSReservationService.Booking();
			List<FWSReservationService.Message> mx = new List<FWSReservationService.Message>();
			FWSReservationService.Message m = new FWSReservationService.Message();
			StringBuilder sb = new StringBuilder();
			try
			{
				b.CustomerNumber = 471986;
				b.CustomerReference = sBookingNo;
				b.RouteCode = sRoute;
				b.VehicleTypeCode = sVehicleTypeCd;
				//b.Length = 13.60M;  *Changed Nover 2014 per Request from Ronal Rolaff at STENA
				b.Length = 14;
				b.Width = 2.6M;
				b.Height = 4;
				b.Weight = 6500;
				b.HazardousGoods = bHazardous;
				b.VehicleRegistrationNumber = sTrailer;
				b.DepartureDateTime = dtDepart;
				b.Livestock = false;
				b.CheckinMessage = "";
				if (b.VehicleTypeCode == "FT")
				{
					b.Plugin = 1;
					b.CheckinMessage = "-25  ";
				}
				b.CheckinMessage = b.CheckinMessage + sPCFN;

				b.Addresses = new FWSReservationService.Address[0];

				b.NumberOfDrivers = 0;

				b.Drivers = new FWSReservationService.Driver[0];
				b.Goods = new FWSReservationService.Goods[0];


				FWSReservationService.BookingClient pBooking = new FWSReservationService.BookingClient();
				pBooking.ClientCredentials.UserName.UserName = UserName;
				pBooking.ClientCredentials.UserName.Password = UserPassword;
				System.Net.ServicePointManager.ServerCertificateValidationCallback = (senderX, certificate, chain, sslPolicyErrors) => { return true; };

				FWSReservationService.Message[] sMessages = pBooking.ConfirmBooking(ref b);

				StenaData.StenaBookingID = b.ID;
				StenaData.sMessage = "Success";
				StenaData.bSuccess = true;

				StringBuilder sbEmail = new StringBuilder();
				sbEmail.AppendFormat("Stena ID:  {0} ", b.ID);
				sbEmail.AppendLine("");
				sbEmail.AppendFormat("PCFN:      {0} ", sPCFN);
				sbEmail.AppendLine("");
				sbEmail.AppendFormat("ARC Booking#: {0}", sBookingNo);
				sbEmail.AppendLine("");
				sbEmail.AppendFormat("Trailer:   {0} ", sTrailer);
				sbEmail.AppendLine("");
				sbEmail.AppendFormat("Sail Date: {0} ", dtDepart);
				sbEmail.AppendLine("");
				sbEmail.AppendFormat("Route:      {0} ", sRoute);
				sbEmail.AppendLine("");
				sbEmail.AppendFormat("Type:       {0} ", sVehicleTypeCd);

				SendEmail("New Stena Booking Created", sbEmail.ToString());
				return StenaData;
			}
			catch (System.ServiceModel.FaultException mex)
			{
				System.ServiceModel.FaultException<FWSReservationService.ServiceFault>
					sf = mex as System.ServiceModel.FaultException<FWSReservationService.ServiceFault>;

				if (sf != null)
				{
					foreach (FWSReservationService.BusinessFault bf in sf.Detail.BusinessFaults)
					{
						sb.AppendFormat("Code: {0} Message: {1} ", bf.Code, bf.Description);
						sb.AppendLine("");
					}
				}
				else
				{
					if (mex.Code != null)
						sb.AppendFormat("Fault exception: {0} ", mex.Code);
					else
						sb.AppendFormat("Fault Exception {0} ", mex.Message);
				}
				ClsErrorHandler.LogError(sb.ToString());
				StenaData.StenaBookingID = b.ID;
				StenaData.SailDt = dtDepart;
				StenaData.sMessage = sb.ToString();
				StenaData.bSuccess = false;
				return StenaData;
			}
			catch (Exception ex)
			{
				bFatalEx = true;
				sb.AppendFormat("General Exception {0} ", ex.Message);

				StenaData.StenaBookingID = b.ID;
				StenaData.sMessage = sb.ToString();
				StenaData.bSuccess = false;
				return StenaData;
			}
			finally
			{
				if (!bFatalEx)
				{
					if (m.Description != null)
						sb.AppendLine(m.Description);
				}
			}
		}


		public static void GetCountries()
		{
			FWSReservationService.BookingMetadataClient p = new FWSReservationService.BookingMetadataClient();
			p.ClientCredentials.UserName.UserName = UserName;
			p.ClientCredentials.UserName.Password = UserPassword;
			FWSReservationService.CodeInfo[] sCodes = p.ListCodes(FWSReservationService.CodeType.Country);
			LoopCodes(sCodes, "Country");
		}

		public static clsBookingInfo FindBooking(string sBookingNo, string sTrailerNo)
		{
			StringBuilder sb = new StringBuilder();
			FWSReservationService.BookingClient pBooking = new FWSReservationService.BookingClient();
			pBooking.ClientCredentials.UserName.UserName = UserName;
			pBooking.ClientCredentials.UserName.Password = UserPassword;
			FWSReservationService.BookingSearchCriteria search = new FWSReservationService.BookingSearchCriteria();

			try
			{
				search.FromDate = DateTime.Today.AddDays(-500);
				search.ToDate = DateTime.Today.AddDays(500);
				search.CustomerNumber = 471986;
				search.CustomerReference = sBookingNo;
				search.VehicleRegistrationNumber = sTrailerNo;
				FWSReservationService.Message[] msgs;
				FWSReservationService.BookingInfo[] bi = pBooking.SearchBookings(search, out msgs);
				clsBookingInfo cbi = new clsBookingInfo();
				if (bi != null)
					if (bi.Length > 0)
					{
						FWSReservationService.BookingInfo b = bi[0];
						cbi.bookingid = b.BookingID;
						cbi.SailingDt = b.DepartureDateTime;
						cbi.HazardousGoods = b.HazardousGoods.ToString();
						cbi.Height = b.Height;
						cbi.Length = b.Length;
						cbi.RouteCd = b.RouteCode;
						cbi.TrailerRegistration = b.TrailerRegistrationNumber;
						cbi.VehicleRegistration = b.VehicleRegistrationNumber;
						cbi.VehicleType = b.VehicleTypeCode;
						cbi.Weight = b.Weight;
						cbi.Width = b.Width;
						cbi.LoadStatus = b.LoadStatusDescription;
						cbi.StatusCd = b.StatusCode.ToString();
						cbi.BookingNo = b.CustomerReference;

					}
				return cbi;
			}
			catch (System.ServiceModel.FaultException mex)
			{
				System.ServiceModel.FaultException<FWSReservationService.ServiceFault>
					sf = mex as System.ServiceModel.FaultException<FWSReservationService.ServiceFault>;

				if (sf != null)
				{
					foreach (FWSReservationService.BusinessFault bf in sf.Detail.BusinessFaults)
					{
						sb.AppendFormat("Code: {0} Message: {1} ", bf.Code, bf.Description);
						sb.AppendLine("");
					}
				}
				else
				{
					if (mex.Code != null)
						sb.AppendFormat("Fault exception: {0} ", mex.Code);
					else
						sb.AppendFormat("Fault Exception {0} ", mex.Message);
				}
				return null;
			}
			catch (Exception ex)
			{
				sb.AppendFormat("General Exception {0} ", ex.Message);
				return null;
			}
		}

		public static List<clsBookingInfo> SearchBookings(ref string sMsg, string sStenaID, string sBookingNo, string sRouteCd, int iFrom, int iTo)
		{
			StringBuilder sb = new StringBuilder();
			FWSReservationService.BookingClient pBooking = new FWSReservationService.BookingClient();
			pBooking.ClientCredentials.UserName.UserName = UserName;
			pBooking.ClientCredentials.UserName.Password = UserPassword;
			FWSReservationService.BookingSearchCriteria search = new FWSReservationService.BookingSearchCriteria();

			try
			{
				search.RouteCode = sRouteCd;
				search.FromDate = DateTime.Today.AddDays(iFrom);
				search.ToDate = DateTime.Today.AddDays(iTo);
				search.CustomerNumber = 471986;
				if (!string.IsNullOrEmpty(sBookingNo))
				{
					search.CustomerReference = sBookingNo;
					search.RouteCode = null;
					search.FromDate = DateTime.Today.AddDays(-700);
					search.ToDate = DateTime.Today.AddDays(180);
					search.ToDate = DateTime.MaxValue;
				}
				if (!string.IsNullOrEmpty(sStenaID))
				{
					int? id = ClsConvert.ToInt32Nullable(sStenaID);
					search.BookingID = id.GetValueOrDefault();
					search.RouteCode = null;
					search.FromDate = DateTime.Today.AddDays(-700);
					search.ToDate = DateTime.Today.AddDays(180);
					search.ToDate = DateTime.MaxValue;
				}
				FWSReservationService.Message[] msgs;
				FWSReservationService.BookingInfo[] bi = pBooking.SearchBookings(search, out msgs);
				List<clsBookingInfo> lSB = new List<clsBookingInfo>();
				if (bi != null)
					foreach(FWSReservationService.BookingInfo b in bi)
					{
						clsBookingInfo cbi = new clsBookingInfo();
						cbi.bookingid = b.BookingID;
						cbi.SailingDt = b.DepartureDateTime;
						cbi.HazardousGoods = b.HazardousGoods.ToString();
						cbi.Height = b.Height;
						cbi.Length = b.Length;
						cbi.RouteCd = b.RouteCode;
						cbi.TrailerRegistration = b.TrailerRegistrationNumber;
						cbi.VehicleRegistration = b.VehicleRegistrationNumber;
						cbi.VehicleType = b.VehicleTypeCode;
						cbi.Weight = b.Weight;
						cbi.Width = b.Width;
						cbi.LoadStatus = b.LoadStatusDescription;
						cbi.BookingNo = b.CustomerReference;
						cbi.StatusCd = b.StatusCode.ToString();
						lSB.Add(cbi);
					}
				return lSB;
			}
			catch (System.ServiceModel.FaultException mex)
			{
				System.ServiceModel.FaultException<FWSReservationService.ServiceFault>
					sf = mex as System.ServiceModel.FaultException<FWSReservationService.ServiceFault>;

				if (sf != null)
				{
					foreach (FWSReservationService.BusinessFault bf in sf.Detail.BusinessFaults)
					{
						sb.AppendFormat("Code: {0} Message: {1} ", bf.Code, bf.Description);
						sb.AppendLine("");
					}
				}
				else
				{
					if (mex.Code != null)
						sb.AppendFormat("Fault exception: {0} ", mex.Code);
					else
						sb.AppendFormat("Fault Exception {0} ", mex.Message);
				}
				sMsg = sb.ToString();
				return null;
			}
			catch (Exception ex)
			{
				sb.AppendFormat("General Exception {0} ", ex.Message);
				sMsg = sb.ToString();
				return null;
			}
		}
		#endregion

		#region Email
		public static void SendEmail(string sSubject, string sBody)
		{

			try
			{
				SmtpClient smtp = new System.Net.Mail.SmtpClient();
				ClsEmail email = new ClsEmail();
				email.SMTPServer = smtp.Host;
				email.From = "helpdesk@amslgroup.com";
				email.To = "ssantianna@amslgroup.com";
				//email.To = "dgerdner@gmail.com";
				email.AddCC("arc-eu-csd@amslgroup.com");
				email.AddCC("arccustomerservice@amslgroup.com");
				email.AddCC("yyeufleetbookings@aafes.com");
				//email.AddCC("HoughtonD@aafes.com");
				//email.AddCC("RolphS@aafes.com");
				//email.AddCC("james.w.cotton.ln@mail.mil");
				
				email.BCC = "dgerdner@amslgroup.com";
				email.AddBCC("dgerdner@gmail.com");
				email.Subject = sSubject;

				StringBuilder sb = new StringBuilder(sBody);
				email.Body = sb.ToString();
				email.SendMail();
			}
			catch (Exception ex)
			{
				ClsErrorHandler.LogException(ex);
				return;
			}
		}
		#endregion
		#region Temporary Stuff

		public static void GetAllCodesTest()
		{
			try
			{
				FWSReservationService.BookingMetadataClient p = new FWSReservationService.BookingMetadataClient();
				p.ClientCredentials.UserName.UserName = UserName;
				p.ClientCredentials.UserName.Password = UserPassword;
				FWSReservationService.CodeInfo[] sCodes = p.ListCodes(FWSReservationService.CodeType.Country);
				LoopCodes(sCodes, "Country");

				sCodes = p.ListCodes(FWSReservationService.CodeType.Goods);
				LoopCodes(sCodes, "Goods");

				sCodes = p.ListCodes(FWSReservationService.CodeType.Route);
				LoopCodes(sCodes, "Route");

				FWSReservationService.VehicleType[] vTypes = p.ListVehicleTypes();
				StringBuilder sb = new StringBuilder();
				foreach (FWSReservationService.VehicleType v in vTypes)
				{
					sb.AppendFormat("Vehicle Type H/W/mL/ML/Wt:{0}, {1}, {2}, {3}, {4}, {5}, {6} ",
						v.Code, v.Description,
						v.Height, v.Width, v.MinLength, v.MaxLength, v.Weight);
					sb.AppendLine();
				}
				//Program.Show(sb.ToString());

				DateTime dtSail = DateTime.Today.AddDays(1);

				FWSReservationService.Sailing[] sailings = p.ListSailings("HAHK", dtSail);
				sb.Clear();
				foreach (FWSReservationService.Sailing s in sailings)
				{
					sb.AppendFormat("Sailing: {0} {1}", s.DepartureDateTime, s.Ship);
					sb.AppendLine();
				}
				//Program.Show(sb.ToString());
			}
			catch (System.ServiceModel.FaultException fex)
			{
				//.Show(fex.Message, "Fault Exception");
				//HandleSTENAError(fex);
				ClsErrorHandler.LogError(fex.Message);
			}
			catch (Exception ex)
			{
				ClsErrorHandler.LogException(ex);
				//MessageBox.Show(ex.Message, "General Exception");
			}
		}
		public static string LoopCodes(FWSReservationService.CodeInfo[] sCodes, string sDsc)
		{
			StringBuilder sb = new StringBuilder();
			foreach (FWSReservationService.CodeInfo r in sCodes)
			{
				string s = r.Code;
				string s2 = r.Description;
				sb.AppendFormat("{2}: {0} {1} ", s, s2, sDsc);
				sb.AppendLine("");

				if (r.Description.ToLower().StartsWith("com"))
				{
					string abc = r.Code;
				}
			}
			return sb.ToString();
		}
		#endregion
	}

	#region STENA Business Objects
	public class clsSTENASailings
	{
		private string _Errors;
		public string Errors
		{
			get { return _Errors; }
			set { _Errors = value; }
		}
		private string _RouteCd;
		public string RouteCd
		{
			get { return _RouteCd; }
			set { _RouteCd = value; }
		}
		private DateTime? _DepartureDt;
		public DateTime? DepartureDt
		{
			get { return _DepartureDt; }
			set { _DepartureDt = value; }
		}
		private string _VesselNm;
		public string VesselNm
		{
			get { return _VesselNm; }
			set { _VesselNm = value; }
		}
		public DateTime? ArriveDt { get; set; }
		public string StatusDsc { get; set; }
	}

	public class clsSTENABookingReturnData
	{
		public int? StenaBookingID;
		public DateTime? SailDt;
		public string sMessage;
		public bool bSuccess;
	}
	public class clsBookingInfo
	{
		private int? _bookingid;
		private string _RouteCd;
		private string _VehicleRegistration;
		private string _TrailerRegistration;
		private string _VehicleType;
		private int _Weight;
		private decimal _Length;
		private decimal _Height;
		private decimal _Width;
		private string _HazardousGoods;
		private string _LoadStatus;
		private string _StatusCd;
		private string _BookingNo;

		
		public int? bookingid
		{ get { return _bookingid; } set { _bookingid = value; } }
		private DateTime? _SailingDt;
		public DateTime? SailingDt
		{ get { return _SailingDt; } set { _SailingDt = value; } }
		public string RouteCd
		{ get {return _RouteCd ;} set {_RouteCd = value;}}
		public string VehicleRegistration
		{ get {return _VehicleRegistration ;} set {_VehicleRegistration = value;}}
		public string TrailerRegistration
		{ get {return _TrailerRegistration;} set {_TrailerRegistration = value;}}
		public string VehicleType
		{ get {return  _VehicleType;} set {_VehicleType = value;}}
		public int Weight;
		public decimal Length;
		public decimal Height;
		public decimal Width;
		public string HazardousGoods
		{ get { return _HazardousGoods; } set { _HazardousGoods = value; } }
		public string LoadStatus
		{ get {return _LoadStatus ;} set {_LoadStatus = value;}}
		public string StatusCd
		{ get {return _StatusCd ;} set {_StatusCd = value;}}
		public string BookingNo
		{ get {return _BookingNo;} set {_BookingNo = value;}}
		
	}
	#endregion

}
