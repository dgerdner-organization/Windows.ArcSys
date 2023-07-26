using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
    public class LobDetailExtract
    {

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
        
        #region Properties
        
        private clsLobExtract _lobExtract;
        private ClsLobDetail _lobDetail;
        //private bool _newFlg;
        //private bool _deleteFlg;

        public clsLobExtract lobExtract
        {
            get
            {
                return _lobExtract;
            }
            set
            {
                _lobExtract = value;
            }
        }

        public ClsLobDetail lobDetail
        {
            get
            {
                return _lobDetail;
            }
            set
            {
                _lobDetail = value;
            }
        }

        //public bool newFlg
        //{
        //    get
        //    {
        //        return _newFlg;
        //    }
        //    set
        //    {
        //        _newFlg = value;
        //    }
        //}

        //public bool deleteFlg
        //{
        //    get
        //    {
        //        return _deleteFlg;
        //    }
        //    set
        //    {
        //        _deleteFlg = value;
        //    }
        //}

        #endregion

        public string DataStatusTxt
        {
            get
            {
                if (_lobExtract.IsNotNull() && _lobDetail.IsNotNull()) return "In Acms and In Load List";
                if (_lobExtract.IsNotNull() && _lobDetail.IsNull()) return "In Acms but NOT in Load List";
                if (_lobExtract.IsNull() && _lobDetail.IsNotNull()) return "NOT in Acms but In Load List";
                return "Unknown";
            }
        }

        public bool Validate()
        {
            ErrorClear();

            //if (lobDetail.Cargo_Status.IsNull()) ErrorAdd("Cargo Status is not valid.");
            //if (lobDetail.Van_Type.IsNull()) ErrorAdd("Van Type is not valid.");
            if (lobDetail.Tcn.IsNull()) ErrorAdd("TCN is not valid.");
            //if (lobDetail.Container_No.IsNull()) ErrorAdd("Container is not valid.");
            //if (lobDetail.Consignor_Dodaac.IsNull()) ErrorAdd("Consignor is not valid.");
            //if (lobHeader.Voyage_No.IsNull()) ErrorAdd("Voyage is not valid.");
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

            return (!IsError);

        }

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

        public bool bol_compare
        {
            get
            {
                try
                {
                    return (StringCompare(lobExtract.cargo_bol_no, lobDetail.Bol_No));
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
                    return (StringCompare(lobExtract.cargo_dsc, lobDetail.Cargo_Dsc));
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
