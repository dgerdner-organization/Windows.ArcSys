using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CS2010.Common;
using System.Data;

namespace CS2010.ArcSys.Business
{
    partial class ClsVwArcBookingCargo
    {
        #region Extended Attributes

        public decimal lengthInches
        {
            get
            {
                return inchesToMeters(this.Length);
            }
        }
        public decimal widthInches
        { get { return inchesToMeters(this.Width); }  }
        public decimal heightInches
        { get { return inchesToMeters(this.Height); } }

        public decimal CubicFeet
        {
            get
            { return lengthInches * widthInches * heightInches / 144; }
        }

        public double Volume
        {
            get
            {
                return Math.Round( Length.GetValueOrDefault() * Width.GetValueOrDefault() * Height.GetValueOrDefault(), 0);
            }
        }
        public DateTime? ReceivedDate
        {

            get
            {
                DateTime? dt = ClsConvert.ToDateTimeNullable(this.Received_Date);
                return dt;
            }
        }
        public DateTime? StatusDate
        {
            get
            {
                DateTime? dt = ClsConvert.ToDateTimeNullable(this.Status_Date);
                return dt;
            }
        }

        public DateTime? Rdd
        {
            get
            {
                DateTime? dt = ClsConvert.ToDateTime(this.Requireddeliverydate);
                return dt;
            }
        }
        private ClsVwArcBookingHeader _BookingHeader;
        public ClsVwArcBookingHeader BookingHeader
        {
            get
            {
                if (_BookingHeader != null)
                    return _BookingHeader;
                string sql = string.Format(@"
                    SELECT vw_arc_booking_header.*
                    FROM   vw_arc_booking_cargo AS vw INNER JOIN
                           BookingCargo ON vw.Id = BookingCargo.Id INNER JOIN
                           BookingItem ON BookingCargo.BookingItemId = BookingItem.Id LEFT OUTER JOIN
                           vw_arc_booking_header ON BookingItem.BookingId = vw_arc_booking_header.booking_ocean_id
                    where vw.id = {0}", this.ID);
                DataTable dt = Connection.GetDataTable(sql);
                if (dt.Rows.Count > 0)
                {
                    _BookingHeader = new ClsVwArcBookingHeader(dt.Rows[0]);
                }
                return _BookingHeader;
            }
        }


        //private List<ClsCargoStatusEvent> _CargoStatusEvents;

        //public List<ClsCargoStatusEvent> CargoStatusEvents
        //{
        //    get
        //    {
        //        if (_CargoStatusEvents != null)
        //            return _CargoStatusEvents;
        //        string sql = string.Format(@"
        //            SELECT Booking.Number, BookingCargo.CargoId, BookingCargoStatusEvent.UpdatedDateLocal, BookingCargoStatus.Code, BookingCargoStatus.Name, BookingCargoStatusEvent.Id
        //            FROM BookingCargo INNER JOIN
        //                 BookingCargoStatusEvent ON BookingCargo.Id = BookingCargoStatusEvent.BookingCargoId INNER JOIN
        //                 BookingCargoStatus ON BookingCargoStatusEvent.BookingCargoStatusId = BookingCargoStatus.Id INNER JOIN
        //                 BookingItem ON BookingCargo.BookingItemId = BookingItem.Id INNER JOIN
        //                 Booking ON BookingItem.BookingId = Booking.Id
        //                 where BookingCargo.ID = {0} order by BookingCargoStatusEvent.ID", this.ID);

        //        _CargoStatusEvents = new List<ClsCargoStatusEvent>();
        //        DataTable dt = Connection.GetDataTable(sql);
        //        foreach (DataRow drow in dt.Rows)
        //        {
        //            ClsCargoStatusEvent e = new ClsCargoStatusEvent();
        //            e.booking_no = drow[0].ToString();
        //            e.serial_no = drow[1].ToString();
        //            e.status_dt = drow[2].ToString();
        //            e.status_cd = drow[3].ToString();
        //            e.event_id = drow[4].ToString();
        //            _CargoStatusEvents.Add(e);
        //        }
        //        return _CargoStatusEvents;
        //    }
        //}
        public string ArcStatusCode
        {
            get
            {
                switch (this.Status_Code)
                {
                    case CargoStatusCodes.ReceivedOceanCode:
                        return CargoStatusCodes.ReceivedArcCode;
                    case CargoStatusCodes.LoadedOceanCode:
                        return CargoStatusCodes.LoadedArcCode;
                    case CargoStatusCodes.BookedOceanCode:
                        return CargoStatusCodes.BookedArcCode;
                    default:
                        return this.Status_Code;
                }
            }
        }
        #endregion

        #region Helper Methods
        public decimal inchesToMeters(double? meters)
        {
            decimal inches = Convert.ToDecimal( meters.GetValueOrDefault()) * 39.3701M;
            inches = Math.Round(inches, 6);
            return inches;
        }
        public decimal weightPounds
        { get { return kgToPounds(this.Weight); } }

        public decimal kgToPounds(double? kg)
        {
            decimal pounds = Convert.ToDecimal(kg.GetValueOrDefault()) * 2.2046M;
            pounds = Math.Round(pounds, 2);
            return pounds;
        }
        #endregion

        #region Static Classes
        public static DataTable GetUpdatedCargo(int iDays)
        {
            // Get recently added or updated cargo
            // Skip anything that does not have a cargo id (serial number)
            string sql = string.Format(@"
                select * from vw_arc_booking_cargo
                   where (CreatedDate > GetDate() - {0} or UpdatedDate > Getdate() - {0})  and serial_no is not null", iDays);
            DataTable dt = Connection.GetDataTable(sql);
            return dt;
        }

        public static DataTable GetForBooking(string sBookingNo, bool bIncludeBlanks)
        {
            string sql = string.Format(@"
                select * from vw_arc_booking_cargo
                   where booking_no = '{0}' ", sBookingNo);
            if (!bIncludeBlanks)
                sql = sql + " and serial_no is not null ";
            DataTable dt = Connection.GetDataTable(sql);
            return dt;
        }

        public static List<ClsVwArcBookingCargo> GetListForBooking(string sBookingNo, bool bIncludeBlanks)
        {
            DataTable dt = GetForBooking(sBookingNo, bIncludeBlanks);
            List<ClsVwArcBookingCargo> cList = new List<ClsVwArcBookingCargo>();
            foreach (DataRow drow in dt.Rows)
            {
                ClsVwArcBookingCargo c = new ClsVwArcBookingCargo(drow);
                cList.Add(c);
            }
            return cList;
        }

        public static ClsVwArcBookingCargo GetForBookingSerialNo (string sBookingNo, string sSerialNo)
        {
            string sql = string.Format(@"
                select * from vw_arc_booking_cargo
                where booking_no = '{0}' and serial_no = '{1}'",
                    sBookingNo, sSerialNo);
            DataTable dt = Connection.GetDataTable(sql);
            if (dt.Rows.Count > 0)
            {
                ClsVwArcBookingCargo cargo = new ClsVwArcBookingCargo(dt.Rows[0]);
                return cargo;
            }
            return null; 
        }

        public static DataTable GetCargoListForVAD(string sBooking, string sVoyage,
                string sVessel, string sTCN, string sPCFN, string sPOL, string sPOD, string sAD)
        {
            // Copies this from LINE logic.  This is used in the Vessel Arrive / Depart window.
            if (string.IsNullOrEmpty(sBooking))
                sBooking = "%";
            if (string.IsNullOrEmpty(sVoyage))
                sVoyage = "%";
            else
            {
                sVoyage = sVoyage.Substring(0, Math.Min(sVoyage.Length, 5)) + "%";
                //sVoyage = sVoyage.Trim() + "%";
            }
            if (string.IsNullOrEmpty(sVessel))
                sVessel = "%";
            if (string.IsNullOrEmpty(sTCN))
                sTCN = "%";
            if (string.IsNullOrEmpty(sPCFN))
                sPCFN = "%";
            if (string.IsNullOrEmpty(sPOL))
                sPOL = "%";
            if (string.IsNullOrEmpty(sPOD))
                sPOD = "%";
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat(@"
                select a.voyage_no, a.booking_no, vessel_cd, pol_cd as pol_location_cd,
                   pod_cd as pod_location_cd, c.serial_no as tcn, c.cargo_type, c.status_code as cargo_status,
                   isnull(a.pcfn,'MANUAL') as create_source,
                   '' as diff_status, a.plor_cd as plor_location_cd, a.plod_cd as plod_location_cd,
                   pol_berth_cd as pol_berth, pod_berth_cd as pod_berth, a.pcfn as partner_request_cd, a.TranshipmentType as trans_info,
                   @DIRBERTH, a.status_cd as booking_status,
                   a.customer_name
                 from vw_arc_booking_header a
                  inner join vw_arc_booking_cargo c on c.booking_no = a.booking_no
                  where a.status_cd in ('C')
                    and a.voyage_no like '{0}'
                    and c.serial_no like '{1}'
                    and customer_name like '%SDDC%'
                    and a.pol_cd like '{2}'",
                            sVoyage, sTCN, sPOL);

//            sb.AppendFormat(@"
//					select a.voyage_no, a.booking_id as booking_no,
//					vessel_cd, pol_location_cd, pod_location_cd,
//						tcn, cargo_type_cd, cargo_status,
//					nvl(partner_request_cd,'Manual') as create_source,
//					'' as diff_status,
//					plor_location_cd, plod_location_cd,
//					pol_berth, pod_berth, partner_request_cd, trans_info,
//					@DIRBERTH, booking_status
//					 from v_sddc_itv_presummary a
//					 where a.voyage_no like '{0}'
//	                     and vessel_cd like '{1}'
//						 and tcn like '{2}'
//						 and booking_id like '{3}'
//						 and nvl(partner_request_cd,'A') like '{4}'
//						 and pol_location_cd like '{5}'
//						 and pod_location_cd like '{6}'",
//                      sVoyage, sVessel, sTCN, sBooking, sPCFN, sPOL, sPOD);
//            sb.AppendFormat("	order by voyage_no, booking_id, tcn ");
            switch (sAD.ToLower())
            {
                case "arrive":
                    sb.Replace("@DIRBERTH", "pod_berth_cd as itv_berth ");
                    break;
                case "depart":
                    sb.Replace("@DIRBERTH", "pol_berth_cd as itv_berth ");
                    break;
                default:
                    sb.Replace("@DIRBERTH", " ' ' as itv_berth ");
                    break;
            }

            string sql = sb.ToString();
            DataTable dt = Connection.GetDataTable(sql);
            return dt;
        }
        #endregion
    }

    #region Other Classes
    public class ClsCargoStatusEvent
    {
        public string booking_no { get; set; }
        public string serial_no { get; set; }
        public string status_dt { get; set; }
        public string status_cd { get; set; }
        public string event_id { get; set; }

        public DateTime statusDate
        {
            get
            {
                return ClsConvert.ToDateTime(status_dt);
            }
        }
        public Int64 eventID
        {
            get { return ClsConvert.ToInt64(event_id); }
        }

    }

    public class CargoStatusCodes
    {
        public const string ReceivedOceanCode = "RE";
        public const string ReceivedArcCode = "I";
        public const string LoadedOceanCode = "LO";
        public const string LoadedArcCode = "AE";
        public const string BookedOceanCode = "BO";
        public const string BookedArcCode = "C";

        public static string TranslateCode(string sCode)
        {
            switch (sCode)
            {
                case CargoStatusCodes.ReceivedOceanCode:
                    return CargoStatusCodes.ReceivedArcCode;
                case CargoStatusCodes.LoadedOceanCode:
                    return CargoStatusCodes.LoadedArcCode;
                case CargoStatusCodes.BookedOceanCode:
                    return CargoStatusCodes.BookedArcCode;
                default:
                    return sCode;
            }
        }
    }
    #endregion
}
