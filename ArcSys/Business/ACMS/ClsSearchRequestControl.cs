using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CS2010.Common;

namespace CS2010.ACMS.Business
{
	public class ClsSearchRequestControl
	{
		public ClsSearchRequestControl()
		{
			ClearErrors();
			ClearMessages();
		}

		#region Fields and Properties
		// All objects from the Search Booking Requests window
		public DataRow[] dList;
		public List<ClsBookingRequest> SelectedBookingRequests;
		public DataTable BookingRequests;
		//public DataTable dtUnits;
		//public DataSet dsResults;
		private StringBuilder _Errors;
		public string Errors
		{
			get { return _Errors.ToString();}
		}
		public bool HasErrors
		{
			get
			{
				if (Errors.Length > 1)
					return true;
				return false;
			}
		}

		private StringBuilder _Messages;
		public string Messages
		{
			get { return _Messages.ToString(); }
		}

		#endregion

		#region  Search Parms
        public bool JustUnprocessedSearch { get; set; }
		private string _VoyageNo;
		public string VoyageNo
		{
			get { return _VoyageNo; }
			set { _VoyageNo = value; }
		}
        public string VoyDoc { get; set; }
		public string PLORCd { get; set; }
		public string PLODCd { get; set; }
		private string _POLCd;
		public string POLCd
		{
			get { return _POLCd; }
			set { _POLCd = value; }
		}

		private string _PODCd;
		public string PODCd
		{
			get { return _PODCd; }
			set { _PODCd = value; }
		}

		private string _Vessel;
		public string Vessel
		{
			get { return _Vessel; }
			set { _Vessel = value; }
		}

		private string _BookingNo;
		public string BookingNo
		{
			get { return _BookingNo; }
			set { _BookingNo = value; }
		}

		private string _PCFN;
		public string PCFN
		{
			get { return _PCFN; }
			set { _PCFN = value; }
		}

		private string _SerialNo;
		public string SerialNo
		{
			get { return _SerialNo; }
			set { _SerialNo = value; }
		}

		private string _TradingPartnerCd;
		public string TradingPartnerCd
		{
			get { return _TradingPartnerCd; }
			set { _TradingPartnerCd = value; }
		}

		private int _RequestDays;
		public int RequestDays
		{
			get { return _RequestDays; }
			set { _RequestDays = value; }
		}
		private string _MMYY;
		public string MMYY
		{ get { return _MMYY; } set { _MMYY = value; } }

		private string _JustStenaFlg;
		public string JustStenaFlg
		{
			get { return _JustStenaFlg; }
			set { _JustStenaFlg = value; }
		}
		public bool JustStena
		{
			get
			{
				if (JustStenaFlg == "Y")
					return true;
				return false;
			}
		}
		private string _ACMSStatusCd;
		public string ACMSStatusCd
		{
			get { return _ACMSStatusCd; }
			set { _ACMSStatusCd = value; }
		}
		private List<string> _ACMSStatusCodes;
		public List<string> ACMSStatusCodes
		{
			get { return _ACMSStatusCodes; }
			set { _ACMSStatusCodes = value; }
		}

		private string _JustUnprocessedFlg;
		public string JustUnprocessedFlg
		{
			get { return _JustUnprocessedFlg; }
			set { _JustUnprocessedFlg = value; }
		}
		public bool JustUnprocessed
		{
			get
			{
				if (JustUnprocessedFlg == "Y")
					return true;
				return false;
			}
		}
		private string _JustBookedFlg;
		public string JustBookedFlg
		{
			get { return _JustBookedFlg; }
			set { _JustBookedFlg = value; }
		}
		public bool JustBooked
		{
			get
			{
				if (JustBookedFlg == "Y")
					return true;
				return false;
			}
		}
		private DateTime? _fromDate;
		public DateTime? fromDate
		{ get { return _fromDate; } set { _fromDate = value; } }

		private DateTime? _toDate;
		public DateTime? toDate
		{ get { return _toDate; } set { _toDate = value; } }

		private DateTime? _fromSailDt;
		public DateTime? fromSailDt
		{ get { return _fromSailDt; } set { _fromSailDt = value; } }

		private DateTime? _toSailDt;
		public DateTime? toSailDt
		{ get { return _toSailDt; } set { _toSailDt = value; } }

		private string _Terms;
		public string Terms
		{
			get { return _Terms; }
			set { _Terms = value; }
		}
        public bool MissedRdd { get; set; }
		#endregion

		#region Methods
		public void ClearParms()
		{
			PCFN = "";
			BookingNo = "";
			VoyageNo = "";
			Vessel = "";
			SerialNo = "";
			PODCd = "";
			POLCd = "";
			RequestDays = 1;
			fromDate = null;
			toDate = null;
			ACMSStatusCodes = new List<string>();
			Terms = "";
            JustBookedFlg = JustStenaFlg = JustUnprocessedFlg = "N";
            JustUnprocessedSearch = false;
		}

		public void ClearErrors()
		{
			_Errors = new StringBuilder();
		}
		public void ClearMessages()
		{
			_Messages = new StringBuilder();
		}
		protected void AddError(string sMsg)
		{
			_Errors.AppendLine(sMsg);
		}
		protected void AddMessage(string sMsg)
		{
			_Messages.AppendLine(sMsg);
		}

		public DataTable SearchBookingRequest()
		{
			ACMSStatusCodes.Clear();
			if (!string.IsNullOrEmpty(ACMSStatusCd))
				ACMSStatusCodes.Add(ACMSStatusCd);

            // If just looking for unprocessed, 
            if (JustUnprocessedSearch)
            {
                List<string> statusCodes = new List<string>();
                BookingRequests = ClsBookingRequest.SearchBookingRequests
                    (TradingPartnerCd, "%", "%", "%", 60,
                        "%", "%",
                        "%", "%", "%", MMYY, false, true, false, statusCodes, fromDate, toDate, 
                        fromSailDt, toSailDt, Terms, "%", "%", false);
            }
            else
            {
                BookingRequests = ClsBookingRequest.SearchBookingRequests
                    (TradingPartnerCd, VoyageNo + "%", VoyDoc, Vessel + "%", RequestDays,
                        PCFN + "%", BookingNo + "%",
                        POLCd + "%", PODCd + "%", SerialNo, MMYY, JustStena, JustUnprocessed, JustBooked, ACMSStatusCodes, fromDate, toDate, fromSailDt, toSailDt, Terms,
                        PLORCd + "%", PLODCd + "%", MissedRdd);
            }
			PopulateErrorMessage();
			return BookingRequests;

			//dtUnits = ClsBookingUnit.SearchBookingUnits
			//    (TradingPartnerCd, VoyageNo + "%", RequestDays, PCFN + "%", BookingNo + "%",
			//        POLCd + "%", PODCd + "%", SerialNo, JustStena);

			//dsResults = new DataSet("results");
			//BookingRequests.TableName = "Bookings";
			//dtUnits.TableName = "Units";
			//dsResults.Tables.Add(BookingRequests);
			//dsResults.Tables.Add(dtUnits);

			//dsResults.Relations.Add(
			//    "pkey",
			//    dsResults.Tables["Bookings"].Columns["partner_request_cd"],
			//    dsResults.Tables["Units"].Columns["partner_request_cd"], false
			//    );

		}
		
		public void PopulateErrorMessage()
		{
			//	Compute warning messages as bookings become old
			string sMsg = "";
			foreach (DataRow drow in BookingRequests.Rows)
			{
				sMsg = "";
				ClsBookingRequest br = GetRequestFromDrow(drow);
				if (br.Confirm_Cd == "N")
				{
					if (br.Acms_Status_Cd == "R" || br.Acms_Status_Cd == "P")
					{
						if (DateTime.Now > br.Request_Dt.GetValueOrDefault().AddHours(12))
							sMsg = "!";
						if (DateTime.Now > br.Request_Dt.GetValueOrDefault().AddHours(24))
							sMsg = "!!";
						if (DateTime.Now > br.Request_Dt.GetValueOrDefault().AddHours(36))
							sMsg = "X";
					}
				}
				drow["c_check"] = sMsg;
			}
		}

		private ClsBookingRequest GetRequestFromDrow(DataRow drow)
		{
			string sCtlNo = drow["trans_ctl_no"].ToString();
			string sSeqNo = drow["trans_seq_no"].ToString();
			long lCtlNo = ClsConvert.ToInt32(sCtlNo);
			long lSeqNo = ClsConvert.ToInt32(sSeqNo);
			ClsBookingRequest br = ClsBookingRequest.GetUsingKey(lCtlNo, lSeqNo);
			return br;
		}

		public ClsReportObject LoadList()
		{
			ClearErrors();
			if (string.IsNullOrWhiteSpace(VoyageNo))
			{
				AddError("Must include voyage in the search before attempting to run the load list");
				return null;
			}
			if (dList == null || dList.Length <= 0)
			{
				AddError("Please check one or more PCFNs before running the load list");
				return null;
			}
			string[] pcfns = dList
				.Select((s) => ClsConvert.ToString(s["partner_request_cd"]).NullTrim())
				.Where((s) => !s.IsNullOrWhiteSpace()).ToArray();

			ClsReportObject ro =  ClsBookingUnit.LoadList(VoyageNo, pcfns);
			return ro;
		}

		public ClsReportObject TenPlusTwo()
		{
			ClearErrors();
			if (dList == null || dList.Length <= 0)
			{
				AddError("Please check one or more PCFNs before running the 10 + 2 report");
				return null;
			}
			string[] pcfns = dList
				.Select((s) => ClsConvert.ToString(s["partner_request_cd"]).NullTrim())
				.Where((s) => !s.IsNullOrWhiteSpace()).ToArray();

			ClsReportObject ro = ClsBookingUnit.TenPlusTwo(pcfns);
			return ro;
		}

		public void Resend304()
		{
			ClearErrors();
			ClearMessages();
			try
			{
				if (dList == null)
				{
					AddError("You must select at least one booking request");
					//Program.Show("You must select at least one booking request");
					return;
				}
				foreach (DataRow drow in dList)
				{
					string sCtlNo = drow["trans_ctl_no"].ToString();
					string sSeqNo = drow["trans_seq_no"].ToString();
					ClsBookingRequest br = ClsBookingRequest.GetUsingKey
							(ClsConvert.ToInt64(sCtlNo), ClsConvert.ToInt64(sSeqNo));
					if (br == null)
						continue;
					br.Resend304();
				}
			}
			catch (Exception ex)
			{
				ClsErrorHandler.LogException(ex);
				AddError(ex.Message);
			}
		}
		public void SetTransmitted(string sXmit, string sCode)
		{
			ClearErrors();
			ClearMessages();
			int iUpdated = 0;
			try
			{
				if (dList == null)
				{
					AddError("You must select at least one booking request");
					//Program.Show("You must select at least one booking request");
					return;
				}
				foreach (DataRow drow in dList)
				{
					string sCtlNo = drow["trans_ctl_no"].ToString();
					string sSeqNo = drow["trans_seq_no"].ToString();
					ClsBookingRequest br = ClsBookingRequest.GetUsingKey
							(ClsConvert.ToInt64(sCtlNo), ClsConvert.ToInt64(sSeqNo));
					// Verify the request is in a valid state for retransmital
					if (sXmit == "N" && !br.MayRetransmit)
					{
						_Errors.AppendFormat("Request {0} may not be transmitted with status of {1} ",
							br.Partner_Request_Cd, br.Acms_Status.Acms_Status_Dsc);
						_Errors.AppendLine("");
						continue;
					}
					br.Confirm_Cd = sXmit;
					if (!string.IsNullOrEmpty(sCode))
						br.Acms_Status_Cd = sCode;
					br.Update();
                    if (br.Acms_Status_Cd == ClsAcmsStatus.StatusCodes.PendingBooking)
                    {
                        br.SendRequestAudit();
                    }

					drow["confirm_cd"] = br.Confirm_Cd;
					drow["acms_status_cd"] = br.Acms_Status_Cd;
					drow["acms_status_dsc"] = br.Acms_Status.Acms_Status_Dsc;
					iUpdated++;
				}

			}
			catch (Exception ex)
			{
				ClsErrorHandler.LogException(ex);
				AddError(ex.Message);
			}
			finally
			{
				_Messages.AppendFormat("{0} bookings were updated ", iUpdated);
			}
		}
		#endregion
	}


}
