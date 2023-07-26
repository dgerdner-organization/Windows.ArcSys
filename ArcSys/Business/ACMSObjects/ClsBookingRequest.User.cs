using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;
using System.Linq.Expressions;
using System.Linq;
using CS2010.ArcSys.Business;

namespace CS2010.ACMS.Business
{
	public partial class ClsBookingRequest
	{
		#region Properties
		private ClsBooking _Booking;
		public ClsBooking Booking
		{
			get
			{
				if (_Booking != null)
					return _Booking;
				_Booking = CS2010.ACMS.Business.ClsBooking.GetUsingKey(this.Partner_Cd, this.Partner_Request_Cd);
				return _Booking;
			}
			set
			{
				_Booking = value;
			}
		}
		private DataTable _BookingUnits;
		public DataTable BookingUnits
		{
			get
			{
				if (_BookingUnits != null)
					return _BookingUnits;
				_BookingUnits = ClsBookingUnit.GetUnitsForRequest(Partner_Cd, Partner_Request_Cd);
                _BookingUnits.Columns.Add("ModFlag", typeof(System.String));
                foreach (DataRow dr in _BookingUnits.Rows)
                {
                    dr["ModFlag"] = "";
                    ClsBookingUnit objBU = new ClsBookingUnit(dr);
                    ClsVwArcBookingCargo oceanBC = ClsVwArcBookingCargo.GetForBookingSerialNo(objBU.Booking_ID, objBU.Tcn);
                    if (oceanBC.IsNull())
                       dr["ModFlag"] = "A";
                }
                List<ClsVwArcBookingCargo> cList = ClsVwArcBookingCargo.GetListForBooking(_Booking_ID, false);
                foreach (ClsVwArcBookingCargo c in cList)
                {
                    // Find this cargo in ACMS
                    ClsBookingUnit bu = ClsBookingUnit.GetByTCN(c.Booking_No, c.Serial_No);
                    if (bu.IsNull())
                    {
                        DataRow drDelete = _BookingUnits.NewRow();
                        drDelete["ModFlag"] = "D";
                        drDelete["TCN"] = c.Serial_No;
                        _BookingUnits.Rows.Add(drDelete);
                    }
                }

				return _BookingUnits;
			}
			set
			{
				_BookingUnits = value;
			}
		}
		private DataTable _Parties;
		public DataTable Parties
		{
			get
			{
				if (_Parties != null)
					return _Parties;
				_Parties = GetPartiesForRequest();
				return _Parties;
			}
			set
			{
				_Parties = value;
			}
		}
		private DataTable _Correspondence;
		public DataTable Correspondence
		{
			get
			{
				if (_Correspondence == null)
					_Correspondence = ClsBookingCorrespondence.GetForRequest(this.Partner_Cd, this.Partner_Request_Cd);
				return _Correspondence;
			}
			set
			{
				_Correspondence = value;
			}
		}
		private List<ClsBookingUnit> _BookingUnitList;
		public List<ClsBookingUnit> BookingUnitList
		{
			get
			{
				if (_BookingUnitList != null)
					return _BookingUnitList;
				_BookingUnitList = new List<ClsBookingUnit>();
				foreach (DataRow dr in this.BookingUnits.Rows)
				{
					ClsBookingUnit bu = new ClsBookingUnit(dr);
					_BookingUnitList.Add(bu);
				}
				return _BookingUnitList;
			}
			set
			{
				_BookingUnitList = value;
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
		private DataTable _EDIArcSysLog;
		public DataTable EDIArcSysLog
		{
			get
			{
				if (_EDIArcSysLog == null)
					_EDIArcSysLog = GetArcSysEDILog();
				return _EDIArcSysLog;
			}
		}

		private DataTable _BookingRequestNotes;
		public DataTable BookingRequestNotes
		{
			get
			{
				if (_BookingRequestNotes != null)
					return _BookingRequestNotes;
				_BookingRequestNotes = ClsBookingRequestNote.GetForPCFN(Partner_Cd, Partner_Request_Cd);
				return _BookingRequestNotes;
			}
		}
		private DataTable _TShipment;
		public DataTable TShipment
		{
			get
			{
				if (_TShipment != null)
					return _TShipment;
				_TShipment = GetTShipmentByBooking();
				return _TShipment;
			}
			set
			{
				_TShipment = value;
			}
		}

		public string BookingNotes
		{
			get
			{
				if (BookingRequestNotes == null)
					return "";
				if (BookingRequestNotes.Rows.Count < 1)
					return "";
				DataRow drow = BookingRequestNotes.Rows[0];
				ClsBookingRequestNote s = new ClsBookingRequestNote(drow);
				return s.NotesFormatted;
			}
		}
		public bool MayResend300
		{
			// Returns true if this is a booking for which you can retransmit a 300 message
			get
			{
				if (this.Acms_Status_Cd == ClsAcmsStatus.StatusCodes.Booked ||
					this.Acms_Status_Cd == ClsAcmsStatus.StatusCodes.BookedCounter ||
					this.Acms_Status_Cd == ClsAcmsStatus.StatusCodes.PendingBooking ||
					this.Acms_Status_Cd == ClsAcmsStatus.StatusCodes.PendingBookingCounter ||
					this.Acms_Status_Cd == ClsAcmsStatus.StatusCodes.WaitListed ||
					this.Acms_Status_Cd == ClsAcmsStatus.StatusCodes.WaitListedCounter)
					return true;
				return false;
			}
		}
		public bool MayResend301
		{
			// Returns true if this is a booking for which you can retransmit a 301 message
			get
			{
				if (this.Acms_Status_Cd == ClsAcmsStatus.StatusCodes.Booked ||
					this.Acms_Status_Cd == ClsAcmsStatus.StatusCodes.BookedCounter)
					return true;
				return false;
			}
		}
		public bool MayRetransmit
		{
			// Returns true if this is a booking for which you can retransmit a 300/301 message
			get
			{
				if (this.Acms_Status_Cd == ClsAcmsStatus.StatusCodes.Canceled ||
					this.Acms_Status_Cd == ClsAcmsStatus.StatusCodes.Ammended ||
					this.Acms_Status_Cd == ClsAcmsStatus.StatusCodes.Declined)
					return false;
				return true;
			}
		}
		public bool IsAALBooking
		{
			get
			{
				if (this.Partner_Cd.StartsWith("AAL"))
					return true;
				return false;
			}
		}
		public bool MayAccept
		{
			get
			{
				if (this._Acms_Status_Cd != ClsAcmsStatus.StatusCodes.Received &&
					this.Acms_Status_Cd != ClsAcmsStatus.StatusCodes.PendingBooking)
					return false;
				foreach (ClsBookingUnit bu in BookingUnitList)
				{
					if (bu.Cargo_ID == null)
						return false;
					if (string.IsNullOrEmpty(bu.Rev_Cd))
						return false;
				}
				return true;
			}
		}
		public bool MayRequestBooking
		{
			get
			{
				if (this._Acms_Status_Cd != ClsAcmsStatus.StatusCodes.Received)
					return false;
				foreach (ClsBookingUnit bu in BookingUnitList)
				{
					if (bu.Cargo_ID == null)
						return false;
					if (string.IsNullOrEmpty(bu.Rev_Cd))
						return false;
				}
				return true;
			}
		}
		public bool MayReleaseWait
		{
			get
			{
				if (this.Acms_Status_Cd == ClsAcmsStatus.StatusCodes.WaitListed ||
					this.Acms_Status_Cd == ClsAcmsStatus.StatusCodes.WaitListedCounter)
					return true;
				return false;
			}
		}
		public bool MayDecline
		{
			get
			{
				if (this.Acms_Status_Cd == ClsAcmsStatus.StatusCodes.Received)
					return true;
				return false;
			}
		}
		public ClsLocation POL
		{
			get
			{
				ClsLocation loc = ClsLocation.GetUsingKey(this.Poe_Location_Cd);
				return loc;
			}
		}
		public ClsLocation POD
		{
			get
			{
				ClsLocation loc = ClsLocation.GetUsingKey(this.Pod_Location_Cd);
				return loc;
			}
		}
		public DateTime? ETA
		{
			get
			{
				DateTime? eta = null;
				string sVoy = this.Voyage_No;
				if (sVoy.Length < 5)
					sVoy = sVoy.Substring(0, sVoy.Length);
				else
					sVoy = sVoy.Substring(0, 5);
				string sql = string.Format(@"
					select f_get_avss_eta_dt('{0}', '{1}') as eta_dt from dual",
						sVoy, this.Booking.Pod_Terminal_Cd);
				DataRow dr = Connection.GetDataRow(sql);
				if (dr != null)
				{
					string sETA = dr["eta_dt"].ToString();
					if (string.IsNullOrEmpty(sETA))
						return ATA;
					eta = ClsConvert.ToDateTimeNullable(sETA);
				}
				if (eta.HasValue)
					return eta;
				return ATA;
			}
		}
		public DateTime? ATA
		{
			get
			{
				try
				{
					DateTime? ata = null;
					string sVoyage = this.Voyage_No;
					if (sVoyage.Length > 4)
						sVoyage = sVoyage.Substring(0, 5);
					string sql = string.Format(@"
					select f_get_avss_ata_dt('{0}', '{1}') as ata_dt from dual",
							sVoyage, this.Booking.Pod_Terminal_Cd);
					DataRow dr = Connection.GetDataRow(sql);
					if (dr != null)
					{
						string sATA = dr["ata_dt"].ToString();
						if (string.IsNullOrEmpty(sATA))
							return null;
						ata = ClsConvert.ToDateTimeNullable(sATA);
					}
					return ata;
				}
				catch (Exception ex)
				{
					ClsErrorHandler.LogException(ex);
					return null;
				}
			}
		}
		private string _Problems;
		public string Problems
		{
			get
			{
				//if (string.IsNullOrEmpty(_Problems))
				_Problems = GetProblems();
				return _Problems;
			}
			set { _Problems = value; }
		}
		public Int32 LastCargoItemNo
		{
			get
			{
				Double iLast = 0;
				foreach (ClsBookingUnit bu in BookingUnitList)
				{
					if (bu.Item_No.GetValueOrDefault() > iLast)
						iLast = bu.Item_No.GetValueOrDefault();
				}
				return (ClsConvert.ToInt32(iLast));
			}
		}
        private string _OceanSystem;
        public string OceanSystem
        {
            get
            {
                if (_OceanSystem != null)
                    return _OceanSystem;
                if (this.Voyage_No.IsNull())
                    return "OCEAN";
                if (this.Booking_ID.IsNullOrWhiteSpace())
                {
                    string sql = string.Format("select f_ocean_system_voyage('{0}') from dual", this.Voyage_No);
                    _OceanSystem = Connection.GetScalar(sql).ToString();
                    return _OceanSystem;
                }
                string s = string.Format("select ediuser.f_ocean_system('{0}') from dual", this.Booking_ID);
                _OceanSystem = Connection.GetScalar(s).ToString();
                return _OceanSystem;
            }
        }
		#endregion

		#region Object Methods
		public bool IsDoorIn
		{
			get
			{
				if (this.Move_Type_Cd == "F5" ||
					this.Move_Type_Cd == "F6" ||
					this.Move_Type_Cd == "F9")
					return true;
				return false;
			}
		}
		public bool IsDoorOut
		{
			get
			{
				if (this.Move_Type_Cd == "F8" ||
					this.Move_Type_Cd == "F7" || 
					this.Move_Type_Cd == "F9")
					return true;
				return false;
			}
		}

		public bool RequestBooking()
		{
			_Errors.Clear();
			try
			{
				// Update the status of this booking request so that a "Booking Request" will be
				// sent to our shipper (currently LINE)
				if (!this.MayRequestBooking)
				{
					string sMsg = string.Format("Cannot request booking while in {0} status.",this.Acms_Status.Acms_Status_Dsc);
					_Errors.Add("RequestBooking", sMsg);
					return false;
				}
				this.Acms_Status_Cd = ClsAcmsStatus.StatusCodes.PendingBooking;
				this.Confirm_Cd = "N";
				this.Update();
                SendRequestAudit();
				return true;
			}
			catch (Exception ex)
			{
				_Errors.Add("RequestBooking", ex.Message);
				ClsErrorHandler.LogException(ex);
				return false;
			}
		}
		public bool RequestBookingCounter()
		{
			_Errors.Clear();
			try
			{
				// Update the status of this booking request so that a "Booking Request" will be
				// sent to our shipper (currently LINE)
				if (!this.MayRequestBooking) 
				{
					string sMsg = string.Format("Cannot request booking while in {0} status.", this.Acms_Status.Acms_Status_Dsc);
					_Errors.Add("RequestBooking", sMsg);
					return false;
				}
				this.Acms_Status_Cd = ClsAcmsStatus.StatusCodes.PendingBookingCounter;
				this.Confirm_Cd = "N";
				this.Update();
                SendRequestAudit();
				return true;
			}
			catch (Exception ex)
			{
				_Errors.Add("RequestBooking", ex.Message);
				ClsErrorHandler.LogException(ex);
				return false;
			}
		}
        public void SendRequestAudit()
        {
            // Add an entry to the audit trail to indicate this booking is being sent
            // to our trading partner

            string sql = string.Format(@"
                insert into t_booking_audit
                 select '{0}', '{1}', 0, 'SEND TO OCEAN', 'na','.', sysdate, '{2}' 
                  from dual ", this.Partner_Cd, this.Partner_Request_Cd, ClsEnvironment.UserName);
            Connection.RunSQL(sql);
        }
		public bool RequestAccept(string sBookingNo)
		{
			_Errors.Clear();
			try
			{
				// Update the status of this booking request so that a "Booking Request" will be
				// sent to our shipper (currently LINE)
				if (!this.MayAccept)
				{
					string sMsg = string.Format("Cannot accept booking while in {0} status.", this.Acms_Status.Acms_Status_Dsc);
					_Errors.Add("AcceptBooking", sMsg);
					return false;
				}
				this.Acms_Status_Cd = ClsAcmsStatus.StatusCodes.Booked;
				this._Booking_ID = sBookingNo;
				this.Confirm_Cd = "N";
				this.Update();
				foreach (ClsBookingUnit bu in BookingUnitList)
				{
                    // DGERDNER Nov2019 : Only update the booking id if one hasn't already been assigned
                    if (bu.Booking_ID.IsNullOrWhiteSpace())
                    {
                        bu.Booking_ID = sBookingNo;
                        bu.Update();
                    }
				}
				return true;
			}
			catch (Exception ex)
			{
				_Errors.Add("AccpetBooking", ex.Message);
				ClsErrorHandler.LogException(ex);
				return false;
			}
		}
		public bool RequestDecline()
		{
			_Errors.Clear();
			try
			{
				this.Acms_Status_Cd = ClsAcmsStatus.StatusCodes.Declined;
				this.Confirm_Cd = "N";
				this.Update();
				return true;
			}
			catch (Exception ex)
			{
				_Errors.Add("DeclineBooking", "Decline Booking Failed");
				_Errors.Add("DeclineBooking", ex.Message);
				return false;
			}
		}
		public string GetProblems()
		{
			string sMsg = "";
			bool b_cargoid = false;
			bool b_revcd = false;
			bool b_milstamp = false;

			// Missing Cargo Informatin
			if (BookingUnitList == null)
				sMsg = "No Cargo";
			else
			{
				foreach (ClsBookingUnit bu in BookingUnitList)
				{
					if (bu.Cargo_ID == null)
						b_cargoid = true;
					if (string.IsNullOrEmpty(bu.Rev_Cd))
						b_revcd = true;
					if (bu.PODTerminal == null)
						b_milstamp = true;
					else
						if (string.IsNullOrEmpty(bu.PODTerminal.MilStamp_Cd))
							b_milstamp = true;
					if (bu.POLTerminal == null)
						b_milstamp = true;
					else
						if (string.IsNullOrEmpty(bu.POLTerminal.MilStamp_Cd))
							b_milstamp = true;

				}
			}
			if (b_cargoid)
				sMsg = sMsg + " : Missing Cargo Information";
			if (b_revcd)
				sMsg = sMsg + " : Missing Revenue Code";
			if (b_milstamp)
				sMsg = sMsg + " : Missing MilStamp";

			if (!ETA.HasValue && Acms_Status_Cd == ClsAcmsStatus.StatusCodes.Received)
			{
				sMsg = sMsg + " : Port/Berth Not on voyage ";
			}
			//if (this.POD == null)
			//    sMsg = sMsg + " : Missing/Invalid POD";

			if (this.IsDoorOut)
				if (string.IsNullOrEmpty(this.Booking.Location_Plod_Cd))
					sMsg = sMsg + " : PLOD Missing ";
			if (this.IsDoorIn)
				if (string.IsNullOrEmpty(this.Booking.Location_Plor_Cd))
					sMsg = sMsg + " : PLOR Missing ";

			ClsVessel v = ClsVessel.GetUsingKey(this.Booking.Vessel_Cd);
			if (v == null)
				sMsg = sMsg + " : Vessel not in ACMS ";

			if (this.Booking.Pod_Terminal == null)
				sMsg = sMsg + " : POD Berth not in ACMS ";
			if (this.Booking.Poe_Terminal == null)
				sMsg = sMsg + " : POL Berth not in ACMS ";

			DataTable dt = ClsACMSQueries.GetVoyage(this.Booking.Voyage_No);
			if (dt.Rows.Count < 1)
				sMsg = sMsg + " : Voyage/Vessel not in AVSS ";
			return sMsg;
		}
		private DataTable GetArcSysEDILog()
		{
			string sql = string.Format(@"
				select a.trading_partner_cd, 
					   c.archive_path || a.file_nm as table_dsc, a.isa_no as trans_ctl_no, a.isa_dt as trans_dtx, a.edi_type,
					 'Cancellation Received' as edi_type_dsc,
					 b.request_cd as partner_request_cd,
					 'Y', a.in_out, booking_no, null as rdd_dt
				  from t_isa<DBLINK>arcsys a
				  inner join t_edi303<DBLINK>arcsys b on a.isa_id = b.isa_id
				  inner join r_trading_partner_edi<DBLINK>arcsys c
					 on a.trading_partner_cd = c.trading_partner_cd
					 and a.map_nm = c.map_nm
				 where a.trading_partner_cd = 'SDDC'  
				  and a.in_out = 'I'
				  and substr(b.request_cd,0,6) = substr('{0}',0,6)
  
				union all 

				select 
				a.trading_partner_cd, 
					   c.archive_path || a.file_nm as file_nm, a.isa_no, a.isa_dt as trans_dtx, a.edi_type,
					 'Confirmation Sent Out' as edi_type_dsc,
					 b.request_cd,
					 'Y', a.in_out, booking_no, adj_rdd_dt as rdd_dt
				 from t_isa<DBLINK>arcsys a
				  inner join t_edi301<DBLINK>arcsys b on a.isa_id = b.isa_id
				  inner join r_trading_partner_edi<DBLINK>arcsys c
					 on a.trading_partner_cd = c.trading_partner_cd
					 and a.map_nm = c.map_nm
				 where a.trading_partner_cd = 'SDDC'  
				   and a.in_out = 'O'
				  and b.request_cd = '{0}'
  
				union all  

				  select 
				a.trading_partner_cd, 
					   c.archive_path || a.file_nm as file_nm, a.isa_no, a.isa_dt as trans_dtx, a.edi_type,
					 'Booking Request Received' as edi_type_dsc,
					 b.request_cd,
					 'Y', a.in_out, null as booking_no, rdd_dt
				 from t_isa<DBLINK>arcsys a
				  inner join t_edi300<DBLINK>arcsys b on a.isa_id = b.isa_id
				  inner join r_trading_partner_edi<DBLINK>arcsys c
					 on a.trading_partner_cd = c.trading_partner_cd
					 and a.map_nm = c.map_nm
				 where a.trading_partner_cd = 'SDDC'  
				  and a.in_out = 'I'
				  and b.request_cd = '{0}'
  
				union all
				  select distinct
				a.trading_partner_cd, 
					   c.archive_path || a.file_nm as file_nm, a.isa_no, a.isa_dt as trans_dtx, a.edi_type,
					 case 
						when a.in_out = 'O'
							then 'ITV Sent Out'
						else 'Delay Request Received' end
							as edi_type_dsc,
					 bu.partner_request_cd,
					 'Y', a.in_out, booking_no, null as rdd_dt
				 from t_isa<DBLINK>arcsys a
				  inner join t_edi315<DBLINK>arcsys b on a.isa_id = b.isa_id
				  inner join t_booking_unit bu 
					 on b.serial_no = bu.tcn and b.booking_no = bu.booking_id 
				  inner join r_trading_partner_edi<DBLINK>arcsys c
					 on a.trading_partner_cd = c.trading_partner_cd
					 and a.map_nm = c.map_nm
				 where a.trading_partner_cd = 'SDDC'  
				 /* and a.in_out = 'O' */
				  and bu.partner_request_cd = '{0}'   ", Partner_Request_Cd);

			DataTable dt = Connection.GetDataTable(sql);
			return dt;

		}
		private DataTable GetEDILog()
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
						  partner_request_cd like '{1}' and
						  trans_dt > sysdate - 360
					UNION ALL
							select 
						distinct f.trading_partner_cd,   
							     f.table_dsc,
								 f.trans_ctl_no,
								 f.trans_dt,
								 edi_type,
								'Shipping Instructions Sent'as edi_type_dsc, 
						         s.partner_request_cd,
								 ftp_success_cd, in_out
								from t_edi_activity_ftp f
							 left outer join t_304_sent s
							  on trim(f.trading_partner_cd) = trim(s.sendto_partner_cd)
							  and f.trans_ctl_no = s.trans_ctl_no
							 where edi_type like '304%'
							   /*and f.trading_partner_cd like '{0}'*/
							   and s.partner_request_cd = '{1}'and
						  trans_dt > sysdate - 360
	
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
						 where c.partner_request_cd = '{1}' and
						  trans_dt > sysdate - 360
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
		   select distinct c.trading_partner_cd,
				  c.table_dsc,
				  c.trans_ctl_no,
				  c.trans_dt,
				  c.edi_type,
				  'Cancel Received' as edi_type_dsc,
				  a.partner_request_cd,
				  ftp_success_cd,
				  in_out
			from t_booking_edi_activity a
			 inner join t_booking_cancel b on b.trans_ctl_no = a.out_trans_ctl_no
			 inner join t_edi_activity_ftp c on c.trans_ctl_no = b.trans_ctl_no and c.edi_type = '303IN'
			 where substr(a.partner_request_cd,0,6) like substr( '{1}',0,6)
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
						  trading_partner_cd like 'WLWH%' and
						  trans_dt > sysdate - 360
					   group by t_edi_activity_ftp.trading_partner_cd,
							 t_edi_activity_ftp.table_dsc,
						  t_edi_activity_ftp.trans_ctl_no,
						  t_edi_activity_ftp.trans_dt,
						  edi_type,
						  t_booking_edi_activity.partner_request_cd,
							ftp_success_cd, in_out
				", Partner_Cd, Partner_Request_Cd);

				DataTable dt = Connection.GetDataTable(sql);
				return dt;

		}

		public DataTable GetAuditTrail()
		{
			string prtCd = Partner_Cd.NullTrim();
			string reqCd = Partner_Request_Cd.NullTrim();
			if (string.IsNullOrWhiteSpace(prtCd) || string.IsNullOrWhiteSpace(reqCd)) return null;

			string sql = @"
			SELECT	ba.*
			FROM	t_booking_audit ba
			WHERE	ba.partner_cd = @PAR_CD AND ba.partner_request_cd = @REQ_CD
					and trim(ba.old_data) <> trim(ba.new_data)
			ORDER BY ba.partner_cd, ba.partner_request_cd, ba.audit_dt, ba.item_no, ba.column_dsc ";

			DbParameter[] p = new DbParameter[2];
			p[0] = Connection.GetParameter("@PAR_CD", prtCd);
			p[1] = Connection.GetParameter("@REQ_CD", reqCd);

			return Connection.GetDataTable(sql, p);
		}
		#endregion

		#region Methods
		public void Resend304()
		{
			try
			{
				//
				//	Flags an item to have it's 304 instructions resent.
				//
				//
				Connection.TransactionBegin();
				// Delete record of all 304's that have been sent for this item
				string sql = string.Format(@"
					delete from t_304_sent where partner_request_cd = '{0}' ", this.Partner_Request_Cd);
				Connection.RunSQL(sql);

 				// If it's already in the queue, set confirm flat to "N"
				// Otherwise insert it into the queu.
				ClsEdi304Queue queue = ClsEdi304Queue.GetUsingKey(this.Partner_Cd, this.Partner_Request_Cd);
				if (queue != null)
				{
					queue.Confirm_Flg = "N";
					queue.Update();
				}
				else
				{
					queue = new ClsEdi304Queue();
					queue.Partner_Cd = this.Partner_Cd;
					queue.Partner_Request_Cd = this.Partner_Request_Cd;
					queue.Confirm_Flg = "N";
					queue.Insert();
				}
				Connection.TransactionCommit();
			}
			catch (Exception ex)
			{
				Connection.TransactionRollback();
				throw ex;
			}
		}
		private DataTable GetTShipmentByBooking()
		{
			string sql = string.Format(@"
				select distinct leg_type, booking_no, first_ets, pol_location_cd,
				 pol_berth, pod_location_cd, pod_berth, move_type_cd, pol_ets, pod_eta, edi_voyage_no, edi_vessel_cd, edi_depart_dt, depart_actual_flg,
				  edi_arrive_dt, arrive_actual_flg
				   from v_transshipments
				 where '{0}' in (linked_booking_no, booking_no)
				 order by leg_type desc", this.Booking_ID);

			return Connection.GetDataTable(sql);
		}

		public bool SynchITV()
		{
			// Looks for ITV data that does not match this booking and cargo,
			// and updates the ITV so it matches.  This is needed when ITV is
			// not sent, because it was created with bad information (voyage, etc)
			bool bReturn = true;
			_Errors.Clear();
			try
			{
				foreach (ClsBookingUnit unit in this.BookingUnitList)
				{
					if (!ClsACMSUtil.SynchronizeITVData(this.Booking_ID, unit.Tcn))
						bReturn = false;
				}
				return bReturn;
			}
			catch (Exception ex)
			{
				_Errors.Add("SYNCH", ex.Message);
				return false;
			}
		}
		#endregion

		#region Static Methods
		public DataTable GetPartiesForRequest()
		{
			string sql = string.Format(@"
				select p.*,
				   case 
					 when party_type_cd = 'SH' then 'Shipper'
					 when party_type_cd =  'CN' then 'Receiver'
					 when party_type_cd =  'CI' then 'Requester'
					 when party_type_cd =  'IC' then 'Booker'
					 else party_type_cd
				   end as party_type_dsc 
				  from t_booking_party p
					where partner_cd = '{0}'
                      and partner_request_cd = '{1}' ",
				   Partner_Cd, Partner_Request_Cd);
			DataTable dt = Connection.GetDataTable(sql);
			return dt;
		}

		public static DataTable SearchBookingRequestsOld(
			string sPartner,
			string sVoyage,
			string sVessel,
			int iDays,
			string sPCFN,
			string sBookingNo,
			string sPOL, string sPOD,
			string sSerialNo,
			bool bJustStena,
			bool bJustUnprocessed
			)
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendFormat(@"
				  SELECT 'N' as c_check,
						 T_BOOKING_REQUEST.PARTNER_REQUEST_CD,   
						 T_BOOKING_REQUEST.REQUEST_DT,   
						 T_BOOKING_REQUEST.PROJECT_CD,   
						 T_BOOKING_REQUEST.CONTRACT_NO,   
						 T_BOOKING_REQUEST.TAC_NO,   
						 T_BOOKING_REQUEST.FMS_CASE_NO,   
						 T_BOOKING_REQUEST.VESSEL_IRCC,   
						 T_BOOKING_REQUEST.VESSEL_DSC,   
						 T_BOOKING_REQUEST.VOYAGE_NO,   
						 T_BOOKING_REQUEST.MIL_VOYAGE_NO,   
						 T_BOOKING_REQUEST.SAIL_DT,   
						 T_BOOKING_REQUEST.POE_CD,   
						 T_BOOKING_REQUEST.POE_LOCATION_CD,
						 T_BOOKING_REQUEST.POE_DSC,   
						 T_BOOKING_REQUEST.POD_CD,   
						 T_BOOKING_REQUEST.POD_LOCATION_CD,
						 T_BOOKING_REQUEST.POD_DSC,   
						 T_BOOKING_REQUEST.CARGO_AVAIL_DT,   
						 T_BOOKING_REQUEST.RDD_DT,   
						 T_BOOKING_REQUEST.DELIVERY_DSC,   
						 T_BOOKING_REQUEST.SHIP_UNITS_NBR,   
						 T_BOOKING_REQUEST.CARGO_CD,   
						 T_BOOKING_REQUEST.ISO_EQP_TYPE_CD,   
						 T_BOOKING_REQUEST.ORIG_TERMS_CD,   
						 T_BOOKING_REQUEST.DEST_TERMS_CD,   
						 T_BOOKING_REQUEST.TOTALS_STOPOFFS_NBR,   
						 T_BOOKING_REQUEST.REQ_NAME,   
						 T_BOOKING_REQUEST.REQ_ADDRESS,   
						 T_BOOKING_REQUEST.REQ_CITY,   
						 T_BOOKING_REQUEST.REQ_STATE,   
						 T_BOOKING_REQUEST.REQ_ZIP,   
						 T_BOOKING_REQUEST.SHIPPER_NAME,   
						 T_BOOKING_REQUEST.SHIPPER_ADDRESS,   
						 T_BOOKING_REQUEST.SHIPPER_CITY,   
						 T_BOOKING_REQUEST.SHIPPER_STATE,   
						 T_BOOKING_REQUEST.SHIPPER_ZIP,   
						 T_BOOKING_REQUEST.SHIPPER_CONTACT,   
						 T_BOOKING_REQUEST.SHIPPER_PHONE,   
						 T_BOOKING_REQUEST.SHIPPER_FAX,   
						 T_BOOKING_REQUEST.SHIPPER_EMAIL,   
						 T_BOOKING_REQUEST.BOOKER_NAME,   
						 T_BOOKING_REQUEST.BOOKER_ADDRESS,   
						 T_BOOKING_REQUEST.BOOKER_CITY,   
						 T_BOOKING_REQUEST.BOOKER_STATE,   
						 T_BOOKING_REQUEST.BOOKER_ZIP,   
						 T_BOOKING_REQUEST.BOOKER_PHONE,   
						 T_BOOKING_REQUEST.BOOKER_FAX,   
						 T_BOOKING_REQUEST.BOOKER_EMAIL,   
						 T_BOOKING_REQUEST.RCVR_NAME,   
						 T_BOOKING_REQUEST.RCVR_ADDRESS,   
						 T_BOOKING_REQUEST.RCVR_CITY,   
						 T_BOOKING_REQUEST.RCVR_STATE,   
						 T_BOOKING_REQUEST.RCVR_ZIP,   
						 T_BOOKING_REQUEST.RCVR_PHONE,   
						 T_BOOKING_REQUEST.RCVR_FAX,   
						 T_BOOKING_REQUEST.RCVR_EMAIL,   
						 T_BOOKING_REQUEST.ACMS_STATUS_CD,   
						 T_BOOKING_REQUEST.CONFIRM_CD,   
						 T_BOOKING_REQUEST.PARTNER_CD,   
						 T_BOOKING_REQUEST.BOOKING_ID,   
						 T_BOOKING_REQUEST.VESSEL_QUALIFIER,
						 ' ' as c_select,   
						 '              ' as c_warning,   
						 T_BOOKING_REQUEST.TRANS_CTL_NO,   
						 T_BOOKING_REQUEST.TRANS_SEQ_NO,   
						 (select count(*) from t_booking_request_error a where a.trans_ctl_no = t_booking_request.trans_ctl_no and a.trans_seq_no = t_booking_request.trans_seq_no)  as c_error,   
						 ' ' as c_dummy,   
						 R_ACMS_STATUS.PROCESSED_CD,  
						 R_ACMS_STATUS.ACMS_STATUS_DSC, 
							special_handling_cd,
							case
								when confirm_cd = 'N' then 0
								when t_booking_request.acms_status_cd like 'P%' then 0
								else 1
							end sort_key,
							(select count(*) from t_booking_unit where
									t_booking_request.partner_request_cd = t_booking_unit.partner_request_cd) c_detail_count,
						(select count(*)
						  from t_booking_itv
						  where t_booking_request.booking_id = t_booking_itv.booking_id
							  and activity_code = 'I') as ingates,
								  (select count(*)
						  from t_booking_itv
						  where t_booking_request.booking_id = t_booking_itv.booking_id
							  and activity_code = 'VD') as departs,
								  (select count(*)
						  from t_booking_itv
						  where t_booking_request.booking_id = t_booking_itv.booking_id
							  and activity_code = 'VA') as arrives,
						  t_booking_request.move_type_cd,
					  (select count(*) from t_booking_request b2
						where b2.partner_request_cd = t_booking.partner_request_cd) as pcfn_count,
						adj_rdd_dt,
						f_get_avss_eta_dt(substr(t_booking.voyage_no,1,5), t_booking.pod_terminal_cd) as est_date,
						t_booking.sea_air_flg,
						t_booking.voyage_no,
						t_booking_request.vessel_cd,
						(select max(vessel_cd) from t_voyage where t_booking.voyage_no = t_voyage.voyage_cd) as bk_vessel_cd,
						xs.final_booking_no,
						xs.voyage_no,
						xs.pol_location_cd,
						xs.pod_location_cd,
						t_booking_request.voyage_no || '-' || t_booking_request.vessel_cd as request_voyves,
					    t_booking.voyage_no || '-' || t_booking.vessel_cd as booked_voyves,
						t_booking.location_poe_cd as booked_poe_cd,
					    t_booking.location_pod_cd as booked_pod_cd,
						t_booking.location_plor_cd,
					    t_booking.location_plod_cd,
						t_booking.poe_terminal_cd,
						t_booking.pod_terminal_cd,
						t_booking.voyage_no as booked_voyage_no,
						case when xs.voyage_no is null then 'N' else 'Y' end as xs_flg,
									case when hazmat_class_cd like '%7%' then 'R!' else 'HM' end as rx_sign,
						nvl(trunc(adj_rdd_dt) - trunc(f_get_avss_eta_dt(substr(t_booking.voyage_no,1,5), t_booking.pod_terminal_cd)),0)
							as due_eta_diff

					FROM T_BOOKING_REQUEST 
						left outer join R_ACMS_STATUS on t_booking_request.acms_status_cd = r_acms_status.acms_status_cd 
						inner join t_booking on t_booking_request.partner_cd = t_booking.partner_cd and
		 							  t_booking_request.partner_request_cd = t_booking.partner_request_cd
						left outer join t_transshipment xs on t_booking_request.booking_id = xs.booking_no "
					);

			if (bJustStena)
			{
				sb.AppendFormat(@" inner join r_stena_route sr on
                                      sr.pol_location_cd = t_booking.location_poe_cd and
                                      sr.pod_location_cd = t_booking.location_pod_cd ");
			}
			sb.AppendFormat(@"
				   WHERE 
						 trim(T_BOOKING_REQUEST.PARTNER_CD) like '{0}'  AND  
						 T_BOOKING_REQUEST.PARTNER_REQUEST_CD like '{1}' and
						 t_booking_request.request_dt > sysdate - {2}  and
						 nvl(trim(t_booking_request.booking_id),'$') like '{3}' and
						 T_BOOKING_REQUEST.VOYAGE_NO like '{4}' and
						 NVL(T_BOOKING.LOCATION_POE_CD,'$') like '{5}' and
						 NVL(T_BOOKING.LOCATION_POD_CD,'$') like '{6}'
						 /*
						 (NVL(T_BOOKING_REQUEST.VESSEL_DSC,'$') like :as_vessel_cd ) AND  
						 NVL(T_BOOKING_REQUEST.POD_LOCATION_CD,'$') like :as_pod AND  
						 NVL(T_BOOKING_REQUEST.POE_LOCATION_CD,'$') like :as_poe AND  
							t_booking_request.confirm_cd like :as_confirmed AND
							t_booking.location_poe_cd like :as_booked_poe and
							t_booking.location_pod_cd like :as_booked_pod 
						  */
						 ",
						  sPartner, sPCFN, iDays, sBookingNo, sVoyage, sPOL, sPOD);

			if (sSerialNo != "%" && !string.IsNullOrEmpty(sSerialNo))
			{
				sb.AppendFormat(@"
					and exists (
						select 1 from t_booking_unit bu
							where tcn like '{0}' 
                              and bu.partner_request_cd = t_booking_request.partner_request_cd )",
					   sSerialNo);
			}

			if (bJustUnprocessed)
			{
				sb.AppendFormat(@" and 'N' in (R_ACMS_STATUS.PROCESSED_CD, t_booking_request.confirm_cd) ");
			}


			string sql = sb.ToString();
			DataTable dt = Connection.GetDataTable(sql);
			return dt;
		}

		public static DataTable SearchBookingRequests(
	string sPartner,
	string sVoyage,
    string sVoyDoc,
	string sVessel,
	int iDays,
	string sPCFN,
	string sBookingNo,
	string sPOL, string sPOD,
	string sSerialNo,
	string sMMYY,
	bool bJustStena,
	bool bJustUnprocessed,
	bool bJustBooked,
	List<string> ACMSStatusCodes,
			DateTime? dtFromDate,
			DateTime? dtToDate,
			DateTime? dtFromSailDate,
			DateTime? dtToSaileDate,
	string sTerms,
			string sPLOR, string sPLOD,
            bool bMissedRdd
			
	)
		{
			if (!string.IsNullOrEmpty(sMMYY))
				iDays = 99999;
			if (bJustBooked)
			{
				ACMSStatusCodes.Clear();
				ACMSStatusCodes.Add(ClsAcmsStatus.StatusCodes.Booked);
				ACMSStatusCodes.Add(ClsAcmsStatus.StatusCodes.BookedCounter);
			}
			StringBuilder sb = new StringBuilder();
			sb.AppendFormat(@"
				  SELECT 'N' as c_check,
						 T_BOOKING_REQUEST.*,
						 ' ' as c_select,   
						 '              ' as c_warning,   
						 (select count(*) from t_booking_request_error a where a.trans_ctl_no = t_booking_request.trans_ctl_no and a.trans_seq_no = t_booking_request.trans_seq_no)  as c_error,   
						 ' ' as c_dummy,   
						 R_ACMS_STATUS.PROCESSED_CD,  
						 R_ACMS_STATUS.ACMS_STATUS_DSC, 
						case
							when confirm_cd = 'N' then 0
							when t_booking_request.acms_status_cd like 'P%' then 0
							when t_booking_request.acms_status_cd like 'W%' then 0
							else 1
						end sort_key,
						(select count(*) from t_booking_unit where
								t_booking_request.partner_request_cd = t_booking_unit.partner_request_cd) c_detail_count,
						(select count(*)
							  from t_booking_itv
							  where t_booking_request.booking_id = t_booking_itv.booking_id
								  and activity_code = 'I') as ingates,
					    (select count(*)
							  from t_booking_itv
							  where t_booking_request.booking_id = t_booking_itv.booking_id
								  and activity_code = 'VD') as departs,
						 (select count(*)
							  from t_booking_itv
							  where t_booking_request.booking_id = t_booking_itv.booking_id
								  and activity_code = 'VA') as arrives,
					  (select count(*) from t_booking_request b2
							where trim(b2.partner_request_cd) = trim(t_booking.partner_request_cd)) as pcfn_count,
						t_booking.adj_rdd_dt,
						/*f_get_avss_eta_dt(substr(t_booking.voyage_no,1,5), t_booking.pod_terminal_cd) as est_date,*/
						f_voyage_dt(t_booking.voyage_no, t_booking.location_pod_cd, t_booking.pod_terminal_cd, 'D') as est_date, 
						f_voyage_dt(t_booking.voyage_no, t_booking.location_poe_cd, t_booking.poe_terminal_cd, 'L') as est_sail_date, 
						t_booking.sea_air_flg,
						t_booking.voyage_no,
						t_booking.voyage_no || '-' || (select max(vessel_cd) from t_voyage where t_booking.voyage_no = t_voyage.voyage_cd) as booked_voyves,
					    f_voydoc(t_booking.voyage_no) as booked_voydoc,
						xs.final_booking_no,
						xs.voyage_no,
						xs.pol_location_cd,
						xs.pod_location_cd,
						t_booking_request.voyage_no || '-' || t_booking_request.vessel_cd as request_voyves,
					    t_booking.voyage_no || '-' || t_booking.vessel_cd as booked_voyves2,
						t_booking.location_poe_cd as booked_poe_cd,
					    t_booking.location_pod_cd as booked_pod_cd,
						t_booking.location_plor_cd,
					    t_booking.location_plod_cd,
						t_booking.poe_terminal_cd,
						t_booking.pod_terminal_cd,
						t_booking.voyage_no as booked_voyage_no,
						case when xs.voyage_no is null then 'N' else 'Y' end as xs_flg,
						case when hazmat_class_cd like '%7%' then 'R!'
							 when hazmat_cd is not null and hazmat_class_cd not like '%7' then 'HM'
							 else '' end as rx_sign,
						nvl(trunc(adj_rdd_dt) - trunc(f_get_avss_eta_dt(substr(t_booking.voyage_no,1,5), t_booking.pod_terminal_cd)),0)
							as due_eta_diff,
						 
  
 (select max(party_name  || chr(13) || chr(10)|| contact_name  || chr(13) || chr(10)  || address || chr(13) || chr(10)  || city || ' '  || state || ' '  || zip_cd || chr(13) || chr(10)  || voice_phone  )
    from t_booking_party
  where partner_request_cd = t_booking_request.partner_request_cd  
    and party_type_cd = 'CN') as prcvr_name,
 
 (select max(party_name  || chr(13) || chr(10)|| contact_name  || chr(13) || chr(10)  || address || chr(13) || chr(10)  || city || ' '  || state || ' '  || zip_cd || chr(13) || chr(10)  || voice_phone  )
  from t_booking_party
  where partner_request_cd = t_booking_request.partner_request_cd 
    and party_type_cd = 'CI') as preq_name,

(select max(party_name  || chr(13) || chr(10)|| contact_name  || chr(13) || chr(10)  || address || chr(13) || chr(10)  || city || ' '  || state || ' '  || zip_cd || chr(13) || chr(10)  || voice_phone  )
	from t_booking_party
  where partner_request_cd = t_booking_request.partner_request_cd 
    and party_type_cd = 'SH') as pshipper_name,
   f_ocean_system_voyage(t_booking_request.voyage_no) as liner_system

FROM T_BOOKING_REQUEST 
						left outer join R_ACMS_STATUS on t_booking_request.acms_status_cd = r_acms_status.acms_status_cd 
						inner join t_booking on t_booking_request.partner_cd = t_booking.partner_cd and
		 							  t_booking_request.partner_request_cd = t_booking.partner_request_cd
						left outer join t_transshipment xs on t_booking_request.booking_id = xs.booking_no "
					);

			if (bJustStena)
			{
				sb.AppendFormat(@" inner join r_stena_route sr on
                                      sr.pol_location_cd = t_booking.location_poe_cd and
                                      sr.pod_location_cd = t_booking.location_pod_cd ");
			}
			sb.AppendFormat(@"
				   WHERE 
						 trim(T_BOOKING_REQUEST.PARTNER_CD) like '{0}'  AND  
						 T_BOOKING_REQUEST.PARTNER_REQUEST_CD like '{1}' and
						 t_booking_request.request_dt > sysdate - {2}  and
						 /*T_BOOKING.VOYAGE_NO like '{4}' and */
						 NVL(T_BOOKING.LOCATION_POE_CD,'$') like '{5}' and
						 NVL(T_BOOKING.LOCATION_POD_CD,'$') like '{6}' and
						 NVL(t_booking.location_plor_cd,'$') like '{7}' and
						 NVL(t_booking.location_plod_cd,'$') like '{8}'
						 ",
						  sPartner, sPCFN, iDays, sBookingNo, sVoyage, sPOL, sPOD, sPLOR, sPLOD);

			if (!string.IsNullOrEmpty(sTerms))
				sb.AppendFormat(@" and t_booking_request.move_type_cd in ( {0} ) ", sTerms);

			if (sSerialNo != "%" && !string.IsNullOrEmpty(sSerialNo))
			{
				sb.AppendFormat(@"
					and exists (
						select 1 from t_booking_unit bu
							where tcn like '{0}' 
                              and bu.partner_request_cd = t_booking_request.partner_request_cd )",
					   sSerialNo);
			}
			if (sBookingNo != "%" && !string.IsNullOrEmpty(sBookingNo))
			{
				sb.AppendFormat(@"
					and (
						nvl(trim(t_booking_request.booking_id),'$') like '{0}' 
								or
					    exists (
						select 1 from t_booking_unit bu
							where booking_id like '{0}'
							  and bu.partner_request_cd = t_booking_request.partner_request_cd )
						 )",
						sBookingNo);
			}

			if (sVessel != "%" && !string.IsNullOrEmpty(sVessel))
			{
				sb.AppendFormat(@"
					and exists (
						select 1 from t_booking_unit bu
						  inner join t_voyage v on v.voyage_cd = bu.voyage_no
							where v.vessel_cd like '{0}' 
                              and bu.partner_request_cd = t_booking_request.partner_request_cd )",
					   sVessel);
			}

			if (sVoyage != "%" && !string.IsNullOrEmpty(sVoyage))
			{
				sb.AppendFormat(@"
					and exists (
						select 1 from t_booking_unit bu
							where bu.voyage_no like '{0}' 
                              and bu.partner_request_cd = t_booking_request.partner_request_cd )",
					   sVoyage);
			}

			if (bJustUnprocessed)
			{
				sb.AppendFormat(@" and 'N' in (R_ACMS_STATUS.PROCESSED_CD, t_booking_request.confirm_cd) 
                                    and T_BOOKING_REQUEST.ACMS_STATUS_CD <> 'X' ");
			}
			if (!string.IsNullOrEmpty(sMMYY))
			{
				sb.AppendFormat(@" and to_char(request_dt, 'YY') || '-' || to_char(request_dt,'MM') = '{0}' ",
					sMMYY);
			}
			if (ACMSStatusCodes != null)
				if (ACMSStatusCodes.Count > 0)
				{
					sb.Append(@" and t_booking_request.acms_status_cd in ( ");
					int ix = 0;
					foreach (string sCode in ACMSStatusCodes)
					{
						if (ix > 0)
							sb.AppendFormat(",");
						sb.AppendFormat(@" '{0}' ", sCode);
						ix++;
					}
					sb.Append(") ");
				}
			DateRange dr = new DateRange();
			List<DbParameter> p = new List<DbParameter>();
			if (dtFromDate.HasValue || dtToDate.HasValue)
			{
				dr.From = dtFromDate;
				dr.To = dtToDate;
				Connection.AppendDateClause(sb, p, "AND", "request_dt", "@REQFROM", "@REQTO", dr);
			}
			DateRange drSail = new DateRange();
			if (dtFromSailDate.HasValue || dtToSaileDate.HasValue)
			{
				drSail.From = dtFromSailDate;
				drSail.To = dtToSaileDate;
				Connection.AppendDateClause(sb, p, "AND", "sail_dt", "@SAILFROM", "@SAILTO", drSail);
			}

            if (sVoyDoc.IsNotNull())
            {
                string s = string.Format(@" and (f_voydoc(t_booking.voyage_no) like '{0}%' or mil_voyage_no like '{1}%')", sVoyDoc, sVoyDoc);
                sb.Append(s);
            }

//            if (bMissedRdd)
//            {
//                string s = string.Format(@"
//                    and
//                        nvl(trunc(adj_rdd_dt) - trunc(f_get_avss_eta_dt(substr(t_booking.voyage_no,1,5), t_booking.pod_terminal_cd)),0) > 0 "
//                    );
//                sb.Append(s);
//            }
			string sql = sb.ToString();
			DataTable dt = Connection.GetDataTable(sql, p.ToArray());
            if (bMissedRdd)
            {
                //DataTable tblFiltered = dt.AsEnumerable()
                //                             .Where(r => r.Field<int>("due_eta_diff") < 0)
                //                             .CopyToDataTable();
                //return tblFiltered;
                //DataTable results = dt.Select("due_eta_diff < 0").CopyToDataTable();
                //return results;
                DataTable dtFilter = new DataTable();
                dtFilter = dt.Clone();
                foreach (DataRow drow in dt.Rows)
                {
                    string sD = drow["due_eta_diff"].ToString();
                    int iD = ClsConvert.ToInt32(sD);
                    if (iD < 0)
                    {
                        dtFilter.ImportRow(drow);
                    }
                }
                return dtFilter;
            }

			return dt;
		}

		/// <summary>
		/// Get's a booking request by PCFN. 
		/// !!!NOTE!!! Only for booked requets, because there could be multiple
		/// booking requests with the same PCFN.
		/// </summary>
		/// <param name="sPCFN"></param>
		/// <returns></returns>
		public static ClsBookingRequest GetByRequestCd(string sPCFN)
		{
			ClsBookingRequest br = null;
			string sql = string.Format(@"
				select * from t_booking_request
					where partner_request_cd like '{0}'
					 order by request_dt desc", sPCFN);
			DataTable dt = Connection.GetDataTable(sql);
			if (dt.Rows.Count > 0)
			{
				br = new ClsBookingRequest(dt.Rows[0]);
			}
			return br;
		}

		public static DataTable GetNewRequests()
		{
			return GetNewRequests(Connection);
		}

		public static DataTable GetNewRequests(ClsConnection conn)
		{
			string sql = string.Format(@"
				select * from t_booking_request
                   where acms_status_cd in ('R','P') 
                     and request_dt > sysdate - 180");
			return conn.GetDataTable(sql);
		}

		public static Boolean LockRequest(string sPCFN)
		{
			string sql;
			try
			{
				sql = string.Format(@"
					insert into t_booking_request_lock select '{0}', user from dual ", sPCFN);
				Connection.RunSQL(sql);
				return true;
			}
			catch (Exception ex)
			{
				return false;
			}
		}
		public static Boolean UnlockRequest(string sPCFN)
		{
			string sql;
			try
			{
				sql = string.Format(@"
					delete from t_booking_request_lock where partner_request_cd = '{0}' and user_cd = user ", sPCFN);
				Connection.RunSQL(sql);
				return true;
			}
			catch (Exception ex)
			{
				return false;
			}
		}

		public DataTable GetLocks()
		{
			string sql = string.Format(@"
				select distinct * from t_booking_request_lock 
				  where partner_request_cd = '{0}' 
                    and user_cd <> user", Partner_Request_Cd);
			DataTable dt = Connection.GetDataTable(sql);
			return dt;
		}

		#endregion
	}
}
