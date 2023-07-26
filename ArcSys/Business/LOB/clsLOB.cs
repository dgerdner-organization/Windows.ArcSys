using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Data;
using CS2010.Common;
using CS2010.ACMS.Business;

namespace CS2010.ArcSys.Business
{
    /// 2015-09-03 - From Discussion with DG ... 
    ///  - The ACMS Extract data will be for only 1 voyage and 1 POL.
    ///  - The PCFN + TCN combination will represent a unique key for Lob Detail 
    /// 
    /// 
    /// 
    /// So Basic Logic is:  (* * * THIS NEEDS TO BE VERIFIED * * * )
    ///     1 - User selects Booking Requests (Bookings) from the Booking Request window
    ///     2 - We Assemble the VOYAGES and PCFNS
    ///     3 - Query ArcSys for VOYAGES AND PCFNS (* * * VERIFY * * *)
    ///     4 - Query ArcSys for LobHeader and LobDetail that match the above criteria (* * * NOT SURE CRITERIA IS COMPLETE * * * )
    ///     5 - If #4 exists ...
    ///         A - If YES then Ask ... Do you want to start over?
    ///             i - if YES then 
    ///                 ia - Delete LobHeader and LobDetail from ArcSys 
    ///                 ib - Goto 5B
    ///             ii - If NO then
    ///                 iia - Load LobHeader and LobDetail from ArcSys 
    ///                 iib - Bind to Datasource
    ///                 iic - SHOW DIFFERENCES ???
    ///         B - If NO then 
    ///             i - Query data from ACMS database
    ///             ii - Insert LobHeader and LobDetail into ArcSys 
    ///             iii - Bind to Datasource


    /// <summary>
    /// This represents a single ROW of Lob data.  The data is comprised of a single LOB_HEADER, LOB_DETAIL and LOB_EXTRACT
    /// object. 
    /// </summary>
    public class clsLOB
    {

        #region Connection Manager

        protected static ClsConnection Connection
        {
            get { return ClsConMgr.Manager["ArcSys"]; }
        }
        #endregion		// #region Connection Manager

        #region Errors

        private List<string> _Errors;
        public List<string> Errors  
        { 
            get
            {
                if (_Errors.IsNull()) ErrorClear();
                return _Errors;
            }
        }

        public string ErrorMsg
        {
            get
            {
                if (_Errors.IsNull()) return "No Errors.";
                if (_Errors.Count == 0) return "No Errors.";
                StringBuilder sb = new StringBuilder();
                foreach (string s in _Errors)
                    sb.AppendLine(s);

                return sb.ToString();
            }
        }

        public bool IsError
        {
            get
            {
                return (Errors.Count > 0);
            }
        }

        public int NumberOfErrors
        {
            get
            {
                return Errors.Count;
            }
        }

        public void ErrorAdd(string err)
        {
            if (_Errors.IsNull()) ErrorClear();
            _Errors.Add(err);
        }

        public void ErrorClear()
        {
            _Errors = new List<string>();
        }

        #endregion

        public bool chx;
        public ClsLobHeader lobHeader { get; set; }
        public ClsLobDetail lobDetail { get; set; }
        public clsLobExtract lobExtract { get; set; }

                /// <summary>
        /// DataStatus is
        ///  1 = Data IN the ACMS extract and IN ArcSys
        ///  2 = Data IN the ACMS extract and NOT IN ArcSys
        ///  3 = Data NOT IN the ACMS extract and IN ArcSys
        /// </summary>
        //public int DataStatus; -- Not needed anymore ... We will interpret status from objects available.

        public string DataStatusTxt 
        { 
            get {

                if (lobExtract.IsNotNull() && lobDetail.IsNotNull()) return "In Acms - In Load List";
                if (lobExtract.IsNotNull() && lobDetail.IsNull()) return "In Acms - NOT in Load List";
                if (lobExtract.IsNull() && lobDetail.IsNotNull()) return "NOT in Acms - In Load List";
                return "Unknown";
            }
        }

        public string search_voyage_no { get; set; }
        public string search_pol { get; set; }

        public bool new_flg { get; set; }

        #region Public Instance Methods

        //public Boolean LoadFromDatabase(long? Version_no)
        //{
        //    try
        //    {
        //        ErrorClear();

        //        lobDetail = ClsLobDetail.GetByPcfnTcn(lobExtract.pcfn, lobExtract.tcn, Version_no);
        //        if (lobDetail.IsNull())
        //        {
        //            ErrorAdd( string.Format("Could not load detail for PCFN='{0}' and TCN='{1}'.", lobExtract.pcfn, lobExtract.tcn));
        //            return false;
        //        }
        //        lobDetail.New_Flg = false;

        //        lobHeader = ClsLobHeader.GetUsingKey((long)lobDetail.Lob_Header_ID);
                
        //        if (lobHeader.IsNull())
        //        {
        //            ErrorAdd(string.Format("Could not load Header for PCFN='{0}' and TCN='{1}'.", lobExtract.pcfn, lobExtract.tcn));
        //            return false;
        //        }
        //        lobHeader.New_Flg = false;

        //        return true;

        //    }
        //    catch (Exception ex)
        //    {
        //        ClsErrorHandler.LogException(ex);
        //        return false;
        //    }
        //}

        //// Create LOB here 
        //public bool CreateLOB(int version_no)
        //{
        //    ErrorClear();

        //    bool blnInTrans = Connection.IsInTransaction;

        //    if (!blnInTrans) Connection.TransactionBegin();

        //    try 
        //    {
        //        // Does header exist?  
        //        // If 'yes' then load it ... 
        //        // If 'no' then insert it ... 
        //        lobHeader = ClsLobHeader.GetByVoyagePOLVersion(search_voyage_no, search_pol, version_no);

        //        if (lobHeader.IsNull())
        //        {
        //            var v = ClsVVoyage.GetByVoyageNo(search_voyage_no);

        //            lobHeader = new ClsLobHeader()
        //            {
        //                Voyage_No = lobExtract.voyage_no,
        //                Vessel_Nm = v.Vessel.Vessel_Dsc,
        //                Military_Voyage_No = v.Military_Voyage_Cd,
        //                Pol_Location_Cd = lobExtract.pol_location_cd,
        //                Confirm_Flg = "N",
        //                Version_No = version_no
        //            };
        //            if (lobHeader.Insert() != 1)
        //            {
        //                ErrorAdd(string.Format("Could not create Header for VOYAGE='{0}', POL='{1}' and VERSION='{2}'", search_voyage_no, search_pol, version_no.ToString()));
        //                Connection.TransactionRollback();
        //                return false;
        //            }
        //            lobHeader.New_Flg = false;
        //        }

        //        lobDetail = new ClsLobDetail()
        //        {
        //            Lob_Header_ID = lobHeader.Lob_Header_ID,
        //            Booking_No = lobExtract.booking_no,
        //            Cargo_Dsc = lobExtract.cargo_dsc,
        //            Comment_One = lobExtract.comment_one,
        //            Comment_Two = lobExtract.comment_two,
        //            Consignee_Dodaac = lobExtract.consignee_dodaac,
        //            Consignor_Dodaac = lobExtract.consignor_dodaac,
        //            Container_No = lobExtract.container_no,
        //            Cube_Nbr = lobExtract.cube_nbr,
        //            Vd_Flg = lobExtract.vd_flg,
        //            Si_Flg = lobExtract.si_flg,
        //            Booked_Flg = lobExtract.booked_flg,
        //            Manifested_Flg = lobExtract.manifested_flg,
        //            Height_Nbr = lobExtract.height_nbr,
        //            Width_Nbr = lobExtract.width_nbr,
        //            Length_Nbr = lobExtract.length_nbr,
        //            Weight_Nbr = lobExtract.weight_nbr,
        //            Mton_Nbr = lobExtract.mton_nbr,
        //            Pcfn = lobExtract.pcfn,
        //            Pod_Location_Cd = lobExtract.pod_location_cd,
        //            Tcn = lobExtract.tcn,
        //            Vessel_Status_Cd = lobExtract.vessel_status_cd,
        //            Van_Type = lobExtract.van_type,
        //            Rdd_Dt = lobExtract.rdd_dt,
        //            Commodity_Cd = lobExtract.commodity_cd,
        //            Cargo_Status = lobExtract.cargo_status
        //        };

        //        if (lobDetail.Insert() != 1)
        //        {
        //            ErrorAdd(string.Format("Could not create Detail for VOYAGE='{0}', POL='{1}', PCFN='{2}' and TCN='{3}'.", search_voyage_no, search_pol, lobExtract.pcfn, lobExtract.tcn));
        //            Connection.TransactionRollback();
        //            return false;
        //        }
        //        lobDetail.New_Flg = false;

        //        if (!blnInTrans) Connection.TransactionCommit();
        //        return true;	        
		
        //    }
        //    catch (Exception ex)
        //    {
        //        if (!blnInTrans) Connection.TransactionRollback();
        //        ClsErrorHandler.LogException(ex);
        //        return false;
        //    }
        
        //}

        //// TODO:  Need to break up the logic from 
        //public bool PopulateLoadListFromExtract()
        //{
        //    return true;
        //}

        public void SetNewDefaults()
        {
            lobDetail.Vd_Flg = "N";
            lobDetail.Si_Flg = "N";
            lobDetail.Booked_Flg = "N";
            lobDetail.Manifested_Flg = "N";
        }

        /// <summary>
        ///  TODO:  Need to compare data.
        /// </summary>
        /// <returns></returns>
        public bool Compare()
        {
            ErrorClear();

            return true;
        }

        public bool Validate()
        {
            ErrorClear();

            //if (lobDetail.Cargo_Status.IsNull()) ErrorAdd("Cargo Status is not valid.");
            //if (lobDetail.Van_Type.IsNull()) ErrorAdd("Van Type is not valid.");
            if (lobDetail.Tcn.IsNull()) ErrorAdd("TCN is not valid.");
            //if (lobDetail.Container_No.IsNull()) ErrorAdd("Container is not valid.");
            //if (lobDetail.Consignor_Dodaac.IsNull()) ErrorAdd("Consignor is not valid.");
            if (lobHeader.Voyage_No.IsNull()) ErrorAdd("Voyage is not valid.");
            if (lobDetail.Pod_Location_Cd.IsNull()) ErrorAdd("POD is not valid.");
            if (lobDetail.Booking_No.IsNull()) ErrorAdd("Booking # is not valid.");
            //if (lobDetail.Pcfn.IsNull()) ErrorAdd("PCFN is not valid.");
            if (lobDetail.Vessel_Status_Cd.IsNull()) ErrorAdd("Vessel Status Code is not valid.");
            //if (lobDetail.Consignee_Dodaac.IsNull()) ErrorAdd("Consignee is not valid.");
            if (lobDetail.Cargo_Dsc.IsNull()) ErrorAdd("Cargo Description is not valid.");
            if (lobDetail.Length_Nbr.IsNull()) ErrorAdd("Length is not valid.");
            if (lobDetail.Width_Nbr.IsNull()) ErrorAdd("Width is not valid.");
            if (lobDetail.Height_Nbr.IsNull()) ErrorAdd("Height is not valid.");
            if (lobDetail.Weight_Nbr.IsNull()) ErrorAdd("Weight is not valid.");
            // Validate Comment 1 and 2 ?
            if (lobDetail.Commodity_Cd.IsNull()) ErrorAdd("Commodity Code is not valid.");
            if (lobDetail.Rdd_Dt.IsNull()) ErrorAdd("RDD is not valid.");
            if (lobDetail.Booked_Flg.IsNull()) ErrorAdd("Booked Flag is not valid.");
            if (lobDetail.Si_Flg.IsNull()) ErrorAdd("Shipping Instructions Flag is not valid.");
            if (lobDetail.Manifested_Flg.IsNull()) ErrorAdd("Manifested Flag is not valid.");
            if (lobDetail.Vd_Flg.IsNull()) ErrorAdd("Vessel Depart Flag is not valid.");

            return (!IsError) ;

        }

        public bool SaveAsNewVersion(ClsLobHeader header)
        {
            ErrorClear();

            lobHeader = header;
            lobDetail.Lob_Header_ID = lobHeader.Lob_Header_ID;
            lobDetail.Lob_Detail_ID = null;

            if (lobDetail.Insert() != 1)
            {
                ErrorAdd(string.Format("Could not insert Detail PCFN='{0}' and TCN='{1}'.", lobDetail.Pcfn, lobDetail.Tcn));
            }

            return !IsError;
        }

        public bool Save()
        {
            ErrorClear();

            if (lobExtract.IsNull())
            {
                if (lobDetail.Lob_Detail_ID.IsNull())
                {
                    if (lobDetail.Insert() != 1)
                    {
                        ErrorAdd(string.Format("Could not insert Detail PCFN='{0}' and TCN='{1}'.", lobDetail.Pcfn, lobDetail.Tcn));
                    }
                }
                else
                {
                    if (lobDetail.Update() != 1)
                    {
                        ErrorAdd(string.Format("Could not update Detail PCFN='{0}' and TCN='{1}'.", lobDetail.Pcfn, lobDetail.Tcn));
                    }
                }
            }
            else
            {
                if (lobDetail.IsDirty)
                {
                    if (lobDetail.Update() != 1)
                    {
                        ErrorAdd(string.Format("Could not update Detail PCFN='{0}' and TCN='{1}'.", lobDetail.Pcfn, lobDetail.Tcn));
                    }
                }
            }

            return !IsError;

        }

        #endregion

        #region Public field Compare Properties

        private bool StringCompare(string A, string B)
        {
            try
            {
                if (string.IsNullOrEmpty(A) && string.IsNullOrEmpty(B)) return true;
                return (string.Compare(A, B) == 0);
            }
            catch
            {
                return true;
            }
        }

        public bool cargo_status_compare 
        {
            get
            {
                try
                {
                    return (StringCompare(lobExtract.cargo_status, lobDetail.Cargo_Status));
                }
                catch 
                {
                    return true;
                }

            }
        }

        public bool van_type_compare
        {
            get
            {
                try
                {
                    return (StringCompare(lobExtract.van_type, lobDetail.Van_Type));
                }
                catch
                {
                    return true;
                }
            } 
        }

        public bool tcn_compare
        {
            get
            {
                try
                {
                    return (StringCompare(lobExtract.tcn, lobDetail.Tcn));
                }
                catch 
                {

                    return true;
                }
            }
        }

        public bool container_no_compare
        {
            get
            {
                try
                {
                    return (StringCompare(lobExtract.container_no, lobDetail.Container_No));
                }
                catch
                {
                    return true;
                }
            }
        }

        public bool consignor_compare
        {
            get
            {
                try
                {
                    return (StringCompare(lobExtract.consignor_dodaac, lobDetail.Consignor_Dodaac));
                }
                catch 
                {
                    return true;
                }
            }
        }

        public bool voyage_compare
        {
            get
            {
                try
                {
                    return (StringCompare(lobExtract.voyage_no, lobHeader.Voyage_No));
                }
                catch 
                {
                    return true;
                }
            }
        }

        public bool pod_location_cd_compare
        {
            get
            {
                try
                {
                    return (StringCompare(lobExtract.pod_location_cd, lobDetail.Pod_Location_Cd));
                }
                catch 
                {
                    return true;
                }
            }
        }

        public bool booking_no_compare
        {
            get
            {
                try
                {
                    return (StringCompare(lobExtract.booking_no, lobDetail.Booking_No));
                }
                catch 
                {
                    return true;
                }
            }
        }

        public bool pcfn_compare
        {
            get
            {
                try
                {
                    return (StringCompare(lobExtract.pcfn, lobDetail.Pcfn));
                }
                catch 
                {
                    return true;
                }
            }
        }

        public bool vessel_status_cd_compare
        {
            get
            {
                try
                {
                    return (StringCompare(lobExtract.vessel_status_cd, lobDetail.Vessel_Status_Cd));
                }
                catch
                {
                    return true;
                }
            }
        }

        public bool consignee_compare
        {
            get
            {
                try
                {
                    return (StringCompare(lobExtract.consignee_dodaac, lobDetail.Consignee_Dodaac));
                }
                catch 
                {
                    return true;
                }
            }
        }

        public bool cargo_dsc_compare
        {
            get
            {
                try
                {
                    return ( StringCompare(lobExtract.cargo_dsc, lobDetail.Cargo_Dsc));
                }
                catch
                {
                    return true;
                }
            }
        }

        public bool cube_nbr_compare
        {
            get { try { return (lobExtract.cube_nbr == lobDetail.Cube_Nbr); } catch { return true; } }
        }

        public bool length_compare
        {
            get
            {
                try
                {
                    return (lobExtract.length_nbr == lobDetail.Length_Nbr);
                }
                catch 
                {
                    return true;
                }
            }
        }

        public bool width_compare
        {
            get
            {
                try
                {
                    return (lobExtract.width_nbr == lobDetail.Width_Nbr);
                }
                catch 
                {
                    return true;
                }
            }
        }

        public bool height_compare
        {
            get
            {
                try
                {
                    return (lobExtract.height_nbr == lobDetail.Height_Nbr);
                }
                catch 
                {
                    return true;
                }
            }
        }

        public bool weight_compare
        {
            get
            {
                try
                {
                    return (lobExtract.weight_nbr == lobDetail.Weight_Nbr);
                }
                catch 
                {
                    return true;
                }
            }
        }

        public bool booked_flg_compare
        {
            get
            {
                try
                {
                    return (StringCompare(lobExtract.booked_flg, lobDetail.Booked_Flg));
                }
                catch
                {
                    return true;
                }
            }
        }

        public bool si_flg_compare
        {
            get
            {
                try
                {
                    return (StringCompare(lobExtract.si_flg, lobDetail.Si_Flg));
                }
                catch
                {
                    return true;
                }
            }
        }

        public bool comment_one_compare
        {
            get
            {
                try
                {
                    return (StringCompare(lobExtract.comment_one, lobDetail.Comment_One));
                }
                catch
                {
                    return true;
                }
            }
        }

        public bool comment_two_compare
        {
            get
            {
                try
                {
                    return (StringCompare(lobExtract.comment_two, lobDetail.Comment_Two));
                }
                catch
                {
                    return true;
                }
            }
        }

        public bool commodity_cd_compare
        {
            get
            {
                try
                {
                    return (StringCompare(lobExtract.commodity_cd, lobDetail.Commodity_Cd));
                }
                catch 
                {
                    return true;
                }
            }
        }

        public bool manifested_flg_compare
        {
            get
            {
                try
                {
                    return (StringCompare(lobExtract.manifested_flg, lobDetail.Manifested_Flg));
                }
                catch
                {
                    return true;
                }
            }
        }

        public bool vd_flg_compare
        {
            get
            {
                try
                {
                    return (StringCompare(lobExtract.vd_flg, lobDetail.Vd_Flg));
                }
                catch
                {
                    return true;
                }
            }
        }

        public bool rdd_compare
        {
            get
            {
                try
                {
                    return (lobExtract.rdd_dt == lobDetail.Rdd_Dt);
                }
                catch 
                {
                    return true;
                }
            }
        }

        #endregion

    }
}
