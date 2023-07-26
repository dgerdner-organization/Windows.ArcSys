using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
    partial class ClsVwArcBookingHeader
    {
        #region Extended Attributes
        public string IsDeleted
        {
            get
            {
                if (this.Status_Cd == "X") 
                    return "Y";
                if (this.Status_Cd == "I")
                    return "Y";
                if (this.Status_Cd == "R")
                    return "Y";
                return "N";
            }
        }
        public bool IsActive
        {
            get
            {
                if (IsDeleted == "Y")
                    return false;
                return true;
            }
        }
        private ClsVVoyage _ArcVoyage;
        public ClsVVoyage ArcVoyage
        {
            get
            {
                if (_ArcVoyage == null)
                {
                    _ArcVoyage = ClsVVoyage.GetByVoyageNo(this.Voyage_No);
                }
                return _ArcVoyage;
            }
        }
        private List<ClsVwArcBookingCargo> _BookingCargo;
        public List<ClsVwArcBookingCargo> BookingCargo
        {
            get
            {
                if (_BookingCargo != null)
                    return _BookingCargo;
                _BookingCargo = ClsVwArcBookingCargo.GetListForBooking(this.Booking_No, true);
                return _BookingCargo;
            }
        }
        private List<ClsVwArcBookingCargo> _BookingCargoNoBlanks;
        public List<ClsVwArcBookingCargo> BookingCargoNoBlanks
        {
            get
            {
                if (_BookingCargo != null)
                    return _BookingCargo;
                _BookingCargo = ClsVwArcBookingCargo.GetListForBooking(this.Booking_No, false);
                return _BookingCargo;
            }
        }
        #endregion

        #region Static Methods
        public static List<ClsVwArcBookingHeader> GetNewBookings(int days)
        {
            List<ClsVwArcBookingHeader> bhList = new List<ClsVwArcBookingHeader>();
            string sql = string.Format(@"
                select * 
                    FROM vw_arc_booking_header
                    WHERE(CreatedDate > GETDATE() - {0} or UpdatedDate > GETDATE() - {0})", days);
            DataTable dt = Connection.GetDataTable(sql);
            foreach (DataRow drow in dt.Rows)
            {
                ClsVwArcBookingHeader bh = new ClsVwArcBookingHeader(drow);
                bhList.Add(bh);
            }
            return bhList;
        }

        public static ClsVwArcBookingHeader GetByBookingNo(string sBookingNo)
        {
            string sql = string.Format(@"
                    select * from vw_arc_booking_header where booking_no = '{0}' ", sBookingNo);
            DataRow drow = Connection.GetDataRow(sql);
            if (drow == null)
                return null;
            ClsVwArcBookingHeader bk = new ClsVwArcBookingHeader(drow);
            return bk;
        }

        public DataRow  GetShipperForWWL()
        {
            string sql = string.Format(@"
                SELECT        BookingContact.Id AS Contact_ID, BookingContact.BookingId, Booking.Number AS Booking_No, BookingContact.TypeId AS ContactTypeID, BookingContact.AddressId, ContactType.Name AS Contact_Type, 
                                         BookingContact.CompanyName, BookingContact.FullName, BookingContact.FullNameDetails, BookingContact.PhoneDesk, BookingContact.PhoneMobile, BookingContact.EmailAddress, 
                                         BookingContact.DepartmentOfDefenseActivityAddressCode, BookingContact.Fax, BookingContact.Remarks, Address.AddressLine1, Address.AddressLine2, Address.AddressLine3, Address.City, Address.State, Address.ZipCode, 
                                         Country.Name AS Country_Nm, Country.Description AS Country_Dsc, Country.Iso2Code AS Country_2Cd, Country.Iso3Code AS Country_3Cd, Country.Iso5Code AS Country_5Cd
                FROM            BookingContact INNER JOIN
                                         ContactType ON BookingContact.TypeId = ContactType.Id INNER JOIN
                                         Address ON BookingContact.AddressId = Address.Id INNER JOIN
                                         Booking ON BookingContact.BookingId = Booking.Id INNER JOIN
                                         Country ON Address.CountryId = Country.Id
                where BookingID = {0} and ContactType.Name = 'Customer' ", this.Booking_Ocean_ID);
            DataTable dt = Connection.GetDataTable(sql);
            if (dt.Rows.Count > 0)
                return dt.Rows[0];
            return null;
        }

        public static DataTable SearchOceanBookings(SearchOceanBookingParms parms)
        {
            string sql = string.Format(@"
                select hdr.*, dtl.*, dtl.status_code as cargo_status_code
                from vw_arc_booking_header hdr
                        inner join vw_arc_booking_cargo dtl on dtl.booking_no = hdr.booking_no
                    where 1 = 1
                ");

            if (parms.BookingNo.IsNotNull())
                sql = string.Format(@" {0} and hdr.booking_no like '{1}' ", sql, parms.BookingNo);
            if (parms.PolCd.IsNotNull())
                sql = string.Format(@" {0} and pol_cd = '{1}' ", sql, parms.PolCd);
            if (parms.PodCd.IsNotNull())
                sql = string.Format(@" {0} and pod_cd = '{1}' ", sql, parms.PodCd);
            if (!parms.SerialNo.IsNullOrWhiteSpace())
                sql = string.Format(@" {0} and serial_no like '{1}' ", sql, parms.SerialNo);
            if (!parms.VoyageNo.IsNullOrWhiteSpace())
                sql = string.Format(@" {0} and voyage_no like '{1}' ", sql, parms.VoyageNo);

            DataTable dt = Connection.GetDataTable(sql);
            return dt;
        }

        public static DataTable VINRecallsMismatched(string BookingNo, List<string> Vins)
        {
            string VinString = string.Empty;

            for (int x = 0; x < Vins.Count; x++)
                VinString = VinString + Vins[x] + ",";

            VinString = VinString.RemoveRightChar(1);

            string sql = @"
                    select booking_no, 
                    serial_no as vin, 
                    kop_cd as cargo_type
                    from vw_arc_booking_cargo
                    where kop_cd not in ('VANBD','CARBD')
				    and booking_no = '[BOOKING]'
                    and serial_no = '[VIN]'
                ".Replace("[BOOKING]", BookingNo).Replace("[VIN]", VinString);

            DataTable dt1 = Connection.GetDataTable(sql);
            int i = dt1.Rows.Count;
            return dt1;
        }
        #endregion
    }

    public class SearchOceanBookingParms
    {
        public string VoyageNo { get; set; }

        public string BookingNo { get; set; }

        public string BolNo { get; set; }

        public string SerialNo { get; set; }

        public string PolCd { get; set; }

        public string PodCd { get; set; }
    }

}
