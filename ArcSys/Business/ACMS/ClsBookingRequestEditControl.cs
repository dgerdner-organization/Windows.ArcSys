using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CS2010.Common;
using CS2010.ArcSys.Business;

namespace CS2010.ACMS.Business
{
	public class ClsBookingRequestEditControl : ClsBaseFormControl
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ACMS"]; }
		}
		#endregion		// #region Connection Manager

		#region Properties
		public ClsBookingRequest theBookingRequest;
		public DataTable dtMapErros;
		private DataTable _Confirmations;
		public DataTable Confirmations
		{
			get
			{
				if (_Confirmations == null)
					_Confirmations = GetConfirmations();
				return _Confirmations;
			}
		}
		private DataTable _EDILog;
		public DataTable EDILog
		{
			get
			{
				if (_EDILog == null)
					_EDILog = GetEDILog();
				return _EDILog;
			}
		}
		private string _ReleaseErrorsNotes;
		public string ReleaseErrorsNotes
		{
			get	{return _ReleaseErrorsNotes;}
			set { _ReleaseErrorsNotes = value; }
		}
		#endregion

		#region Methods
		public void UpdateRequest()
		{
			ClearErrors();
			ClearMessages();
			try
			{
				if (!theBookingRequest.ValidateUpdate())
				{
					AddError(string.Format("Validate failed. {0} ", theBookingRequest.Error));
					return;
				}
				theBookingRequest.Update();
			}
			catch (Exception ex)
			{
				ClsErrorHandler.LogException(ex);
				AddError(ex.Message);
			}
		}

		public void UpdateBooking()
		{
			ClearErrors();
			ClearMessages();
			try
			{
				// The user is allowed to change the terminal, but not the location.
				// So always go get the poe/pol from the location codes before saving.
				theBookingRequest.Booking.Location_Pod_Cd =
					theBookingRequest.Booking.Pod_Terminal.Location_Cd;
				theBookingRequest.Booking.Location_Poe_Cd =
					theBookingRequest.Booking.Poe_Terminal.Location_Cd;

				// Validate updates
				if (!theBookingRequest.Booking.ValidateUpdate())
				{
					AddError(string.Format("Validate failed. {0} ", theBookingRequest.Booking.Error));
					return;
				}
				theBookingRequest.Booking.Update();
				if (theBookingRequest.Booking.HasErrors)
					AddError(string.Format("Update failed. {0} ", theBookingRequest.Booking.Error));
			}
			catch (Exception ex)
			{
				ClsErrorHandler.LogException(ex);
				AddError(ex.Message);
			}
		}

        public void UpdateParties(string sID, string sState, string sCountry)
        {
            string sql = string.Format("update t_booking_party set state = '{0}', country_cd = '{1}' where party_id = {2} ",
                                     sState, sCountry, sID);
            Connection.RunSQL(sql);
        }
		public void AALPreFills()
		{
			if (theBookingRequest.Partner_Cd != "AAL")
				return;
			foreach (ClsBookingUnit bu in theBookingRequest.BookingUnitList)
			{
				bu.AALPreFills();
			}
		}
		public void RefreshUnits()
		{
			theBookingRequest.BookingUnits = null;
			theBookingRequest.BookingUnitList = null;
		}

		public void RefreshBooking()
		{
			theBookingRequest.Booking = null;
		}

		public bool ReleaseFromErrors()
		{
			ClearErrors();
			ClearMessages();
			if (theBookingRequest.Acms_Status_Cd != ClsAcmsStatus.StatusCodes.PendingCorrections)
			{
				AddError("Booking Request must be in Pending Corrections status to release.");
				return false;
			}
			try
			{
				ClsBookingRequestError.SetNotes(theBookingRequest.Trans_Ctl_No.GetValueOrDefault(),
					theBookingRequest.Trans_Seq_No.GetValueOrDefault(), ReleaseErrorsNotes);
				theBookingRequest.Acms_Status_Cd = ClsAcmsStatus.StatusCodes.Received;

				theBookingRequest.Update();
				dtMapErros = ClsBookingRequestError.GetByISA(theBookingRequest.Trans_Ctl_No, theBookingRequest.Trans_Seq_No);
				return true;
			}
			catch (Exception ex)
			{
				AddError(ex.Message);
				ClsErrorHandler.LogException(ex);
				return false;
			}

		}

		public bool ReleaseFromWaitList()
		{
			ClearErrors();
			ClearMessages();
			try
			{
				if (theBookingRequest.Acms_Status_Cd == ClsAcmsStatus.StatusCodes.WaitListedCounter)
					theBookingRequest.Acms_Status_Cd = ClsAcmsStatus.StatusCodes.BookedCounter;
				if (theBookingRequest.Acms_Status_Cd == ClsAcmsStatus.StatusCodes.WaitListed)
					theBookingRequest.Acms_Status_Cd = ClsAcmsStatus.StatusCodes.Booked;
                theBookingRequest.Confirm_Cd = "N";
				theBookingRequest.Update();
				return true;
			}
			catch (Exception ex)
			{
				AddError(ex.Message);
				ClsErrorHandler.LogException(ex);
				return false;
			}
		}
		public bool DeclineRequest()
		{
			ClearErrors();
			ClearMessages();
			if (!theBookingRequest.RequestDecline())
			{
				AddError(theBookingRequest.Error);
				return false;
			}
			return true;
		}
		public bool CancelRequest()
		{
			ClearErrors();
			ClearMessages();
			try
			{
				theBookingRequest.Acms_Status_Cd = ClsAcmsStatus.StatusCodes.Canceled;
				theBookingRequest.Update();
				return true;
			}
			catch (Exception ex)
			{
				AddError(ex.Message);
				ClsErrorHandler.LogException(ex);
				return false;
			}
		}
		private DataTable GetConfirmations()
		{
			string sql = string.Format(@"
				SELECT  TRANS_CTL_NO ,
						   PARTNER_CD ,
						   PARTNER_REQUEST_CD ,
						   BOOKING_ID ,
						   CONFIRM_STATUS_CD ,
						   EST_DATE ,
						   CREATE_DT ,
						   PROCESS_FLAG ,
						   CREATE_USER     
						FROM       t_booking_confirmation 
						WHERE ( PARTNER_REQUEST_CD like '{0}') ", theBookingRequest.Partner_Request_Cd);

			return Connection.GetDataTable(sql);

		}

		private DataTable GetEDILog()
		{
			try
			{
				string sql = string.Format(@"
					  SELECT distinct t_edi_activity_ftp.trading_partner_cd,   
							 t_edi_activity_ftp.table_dsc,
						  t_edi_activity_ftp.trans_ctl_no,
						  t_edi_activity_ftp.trans_dt,
						  edi_type,
						  case 
							   when edi_type = '301OUT' then 'Confirmation sent out'
								 when edi_type like '300IN%' then 'Request Received'
								   when edi_type = '300OUT' then 'Request Sent to LINE'
									when edi_type = '315OUT' then 'ITV Sent out'
								 else ''
						   end as edi_type_dsc, 
						  t_booking_edi_activity.partner_request_cd,
						  ftp_success_cd, in_out
						FROM t_booking_edi_activity,   
							 t_edi_activity_ftp  
					   WHERE ( t_booking_edi_activity.partner_cd = t_edi_activity_ftp.trading_partner_cd ) and  
							 ( t_booking_edi_activity.out_trans_ctl_no = t_edi_activity_ftp.trans_ctl_no )  and
						  in_out = 'O' and
						  partner_cd like '{0}' and
						  partner_request_cd like '{1}'
					UNION ALL
						   SELECT  
							   c.PARTNER_CD as trading_partner_cd,
							   f.table_dsc,
							   c.trans_ctl_no,
							   c.create_dt,
							   '301IN',
							   'Confirmation Received',
							   c.PARTNER_REQUEST_CD ,
							   f.ftp_success_cd,
							   f.in_out
							FROM       t_booking_confirmation c
							left outer join t_edi_activity_ftp f
							 on f.trans_ctl_no = c.trans_ctl_no
							 and f.edi_type = '301IN'
							 and f.trading_partner_cd = c.partner_cd
							 and f.trans_dt between c.create_dt - 10 and c.create_dt + 10
						 where c.partner_request_cd = '{1}'
						union all
					  SELECT
						  t_edi_activity_ftp.trading_partner_cd,   
							 t_edi_activity_ftp.table_dsc,
						  t_edi_activity_ftp.trans_ctl_no,
						  t_edi_activity_ftp.trans_dt,
						  edi_type,
						  case 
							   when edi_type = '301OUT' then 'Confirmation sent out'
								 when edi_type like '300IN%' then 'Request Received'
								   when edi_type = '300OUT' then 'Request Sent to LINE'
									when edi_type = '315OUT' then 'ITV Sent out'
								 else ''
						   end as edi_type_dsc, 
						  t_booking_request.partner_request_cd,
						  ftp_success_cd, in_out
					  FROM  t_edi_activity_ftp, t_booking_request
					 where t_edi_activity_ftp.trans_ctl_no = t_booking_request.trans_ctl_no
					  and in_out = 'I'
					  and trans_dt > sysdate - 360
					  and  partner_cd like '{0}' 
					  and  partner_request_cd like '{1}'
					UNION ALL
					 SELECT t_edi_activity_ftp.trading_partner_cd,   
							 t_edi_activity_ftp.table_dsc,
						  t_edi_activity_ftp.trans_ctl_no,
						  t_edi_activity_ftp.trans_dt,
						  edi_type,
						  case 
							   when edi_type = '301OUT' then 'Confirmation sent out'
								 when edi_type like '300IN%' then 'Request Received'
								   when edi_type = '300OUT' then 'Request Sent to LINE'
									when edi_type = '315OUT' then 'ITV Sent out'
								 else ''
						   end as edi_type_dsc,   
						  t_booking_cancel.partner_request_cd, 
						  ftp_success_cd, in_out
						FROM t_booking_cancel,
							 t_edi_activity_ftp  
					   WHERE ( t_booking_cancel.partner_cd = t_edi_activity_ftp.trading_partner_cd ) and  
							 ( t_booking_cancel.trans_ctl_no = t_edi_activity_ftp.trans_ctl_no )  and
						 in_out = 'I' and
						   edi_type = '303IN' and
						  partner_request_cd like '{1}' and
						  trading_partner_cd like '{0}'
					UNION ALL
					   SELECT t_edi_activity_ftp.trading_partner_cd,
							 t_edi_activity_ftp.table_dsc,
						  t_edi_activity_ftp.trans_ctl_no,
						  t_edi_activity_ftp.trans_dt,
						  edi_type,
						  case 
							   when edi_type = '301OUT' then 'Confirmation sent out'
								 when edi_type like '300IN%' then 'Request Received'
								   when edi_type = '300OUT' then 'Request Sent to LINE'
									when edi_type = '315OUT' then 'ITV Sent out'
								 else ''
						   end as edi_type_dsc, 
						  t_booking_edi_activity.partner_request_cd,
						  ftp_success_cd, in_out
						FROM t_booking_edi_activity,   
							 t_edi_activity_ftp  
					   WHERE 
							 ( t_booking_edi_activity.out_trans_ctl_no = t_edi_activity_ftp.trans_ctl_no )  and
						  in_out = 'O' and
								partner_request_cd like '{1}' and 
						  trading_partner_cd like 'WLWH%'
					   group by t_edi_activity_ftp.trading_partner_cd,
							 t_edi_activity_ftp.table_dsc,
						  t_edi_activity_ftp.trans_ctl_no,
						  t_edi_activity_ftp.trans_dt,
						  edi_type,
						  t_booking_edi_activity.partner_request_cd,
							ftp_success_cd, in_out
				", theBookingRequest.Partner_Cd, theBookingRequest.Partner_Request_Cd);

				DataTable dt = Connection.GetDataTable(sql);
				return dt;
			}
			catch (Exception ex)
			{
				AddError(ex.Message);
				return null;
			}

		}
		#endregion



	}
}
