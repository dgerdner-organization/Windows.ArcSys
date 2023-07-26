using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
    public partial class ClsVwArcBolHeader
    {
        #region Extended Properties

        public bool IsActive
        {
            get

            {
                if (this.Status_Cd == "A")
                    return true;
                return false;
            }
        }
        private List<ClsVwArcBolCargo> _CargoList;
        public List<ClsVwArcBolCargo> CargoList
        {
            get
            {
                if (_CargoList != null)
                    return _CargoList;
                //_CargoList = ClsVwArcBolCargo.GetCargoByBOLid(this.ID.GetValueOrDefault());
                CargoList = ClsVwArcBolCargo.GetCargoByBolNo(this.Bol_No);
                return _CargoList;
            }
            set
            {
                _CargoList = value;
            }
        }

        private List<ClsVwArcBolContact> _ContactList;
        public List<ClsVwArcBolContact> ContactList
        {
            get
            {
                if (_ContactList == null)
                    _ContactList = ClsVwArcBolContact.GetContactsByBolNo(this.Bol_No);
                return _ContactList;
            }
        }

        public ClsVwArcBolContact Customer
        {
            get
            {
                ClsVwArcBolContact  customer = ContactList.Find(r => r.Typename.ToUpper() == "CUSTOMER");
                return customer;
            }
        }
        public ClsVwArcBolContact Shipper
        {
            get
            {
                ClsVwArcBolContact customer = ContactList.Find(r => r.Typename.ToUpper() == "SHIPPER");
                return customer;
            }
        }
        public ClsVwArcBolContact Consignee
        {
            get
            {
                ClsVwArcBolContact customer = ContactList.Find(r => r.Typename.ToUpper() == "CONSIGNEE");
                return customer;
            }
        }
        public ClsVwArcBolContact Consignor
        {
            get
            {
                ClsVwArcBolContact customer = ContactList.Find(r => r.Typename.ToUpper() == "CONSIGNOR");
                return customer;
            }
        }
        #endregion

        #region Static Methods
        public static List<ClsVwArcBolHeader> GetNewBols(int days)
        {
            List<ClsVwArcBolHeader> bhList = new List<ClsVwArcBolHeader>();
            string sql = string.Format(@"
                select * 
                    FROM vw_arc_bol_header
                    WHERE(CreatedDate > GETDATE() - {0} or UpdatedDate > GETDATE() - {0})", days);
            DataTable dt = Connection.GetDataTable(sql);
            foreach (DataRow drow in dt.Rows)
            {
                ClsVwArcBolHeader bh = new ClsVwArcBolHeader(drow);
                bhList.Add(bh);
            }
            return bhList;
        }

        public static ClsVwArcBolHeader GetByBolNo(string sBolNo)
        {
            string sql = string.Format(@"
                    select * from vw_arc_bol_header where bol_no = '{0}' ", sBolNo);
            DataRow drow = Connection.GetDataRow(sql);
            if (drow == null)
                return null;
            ClsVwArcBolHeader bol = new ClsVwArcBolHeader(drow);
            return bol;
        }

        //public DataRow GetShipperForWWL()
        //{
        //    string sql = string.Format(@"
        //        SELECT        BookingContact.Id AS Contact_ID, BookingContact.BookingId, Booking.Number AS Booking_No, BookingContact.TypeId AS ContactTypeID, BookingContact.AddressId, ContactType.Name AS Contact_Type, 
        //                                 BookingContact.CompanyName, BookingContact.FullName, BookingContact.FullNameDetails, BookingContact.PhoneDesk, BookingContact.PhoneMobile, BookingContact.EmailAddress, 
        //                                 BookingContact.DepartmentOfDefenseActivityAddressCode, BookingContact.Fax, BookingContact.Remarks, Address.AddressLine1, Address.AddressLine2, Address.AddressLine3, Address.City, Address.State, Address.ZipCode, 
        //                                 Country.Name AS Country_Nm, Country.Description AS Country_Dsc, Country.Iso2Code AS Country_2Cd, Country.Iso3Code AS Country_3Cd, Country.Iso5Code AS Country_5Cd
        //        FROM            BookingContact INNER JOIN
        //                                 ContactType ON BookingContact.TypeId = ContactType.Id INNER JOIN
        //                                 Address ON BookingContact.AddressId = Address.Id INNER JOIN
        //                                 Booking ON BookingContact.BookingId = Booking.Id INNER JOIN
        //                                 Country ON Address.CountryId = Country.Id
        //        where BookingID = {0} and ContactType.Name = 'Customer' ", this.Booking_Ocean_ID);
        //    DataTable dt = Connection.GetDataTable(sql);
        //    if (dt.Rows.Count > 0)
        //        return dt.Rows[0];
        //    return null;
        //}

        public static List<ClsVwArcBolHeader> SearchOceanBols(SearchOceanBookingParms parms)
        {
            string sql = string.Format(@"
                select * from vw_arc_bol_header
                    where 1 = 1
                ");

            if (parms.BolNo.IsNotNull())
                sql = string.Format(@" {0} and bol_no like '{1}' ", sql, parms.BolNo);
            if (parms.PolCd.IsNotNull())
                sql = string.Format(@" {0} and pol_cd = '{1}' ", sql, parms.PolCd);
            if (parms.PodCd.IsNotNull())
                sql = string.Format(@" {0} and pod_cd = '{1}' ", sql, parms.PodCd);
            if (parms.VoyageNo.IsNotNull())
                sql = string.Format(@" {0} and voyage_no like '{1}' ", sql, parms.VoyageNo);
            if (parms.BookingNo.IsNotNull())
                sql = string.Format(@" {0} and booking_no like '{1}' ", sql, parms.BookingNo);
            DataTable dt = Connection.GetDataTable(sql);
            List<ClsVwArcBolHeader> bols = new List<ClsVwArcBolHeader>();
            foreach (DataRow drow in dt.Rows)
            {
                ClsVwArcBolHeader bol = new ClsVwArcBolHeader(drow);
                bols.Add(bol);
            }
            return bols;
        }
        #endregion
    }
}
