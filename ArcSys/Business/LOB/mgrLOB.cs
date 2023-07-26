using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Data;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{

    /// <summary>
    /// Manager class that handles all bulk LOB operations
    /// </summary>
    public class mgrLOB
    {
        #region Connection Manager

        protected static ClsConnection Connection
        {
            get { return ClsConMgr.Manager["ArcSys"]; }
        }
        #endregion		// #region Connection Manager
        
        #region Public Static

//        /// <summary>
//        /// This method will populate the ACMS clsLobExtract object from a DataTable.  This DataTable
//        /// is the result of a database query based on VOYAGE and POL.
//        /// </summary>
//        /// <param name="dt">Result from ACMS query based on VOYAGE and POL</param>
//        /// <returns></returns>
//        public static BindingList<clsLOB> PopulateLOBFromExtract(DataTable dt)
//        {
//            BindingList<clsLOB> lob = new BindingList<clsLOB>();
//            clsLobExtract l;

//            try
//            {
//                foreach (DataRow dr in dt.Rows)
//                {
//                    l = new clsLobExtract();
//                    l.van_type = dr[0].ToString();
//                    l.tcn = dr[1].ToString();
//                    l.container_no = dr[2].ToString();
//                    l.consignor_dodaac = dr[3].ToString();
//                    l.voyage_no = dr[4].ToString();
//                    l.pod_location_cd = dr[5].ToString();
//                    l.booking_no = dr[6].ToString();
//                    l.pcfn = dr[7].ToString();
//                    l.vessel_status_cd = dr[8].ToString();
//                    l.consignee_dodaac = dr[9].ToString();
//                    l.cargo_dsc = dr[10].ToString();
//                    l.cube_nbr = dr[11].ToDecimal();
//                    l.length_nbr = dr[12].ToDecimal();
//                    l.width_nbr = dr[13].ToDecimal();
//                    l.height_nbr = dr[14].ToDecimal();
//                    l.weight_nbr = dr[15].ToDecimal();
//                    l.mton_nbr = dr[16].ToDecimal();
//                    l.booked_flg = dr[17].ToString();
//                    l.si_flg = dr[18].ToString();
//                    l.comment_one = dr[19].ToString();
//                    l.comment_two = dr[20].ToString();
//                    l.commodity_cd = dr[21].ToString();
//                    l.rdd_dt = dr[22].ToDateTime();
//                    l.lifton_dt = dr[23].ToDateTime();
//                    l.pcs_nbr = dr[24].ToInt();
//                    l.pol_location_cd = dr[25].ToString();
//                    l.pol_berth_cd = dr[26].ToString();
//                    l.req_pod_location_cd = dr[27].ToString();
//                    l.plod = dr[28].ToString();
//                    l.sddc_cbft = dr[29].ToString();
//                    l.move_type_cd = dr[30].ToString();
//                    l.lob_detail_id = dr[31].ToLong();
//                    l.lob_header_id = dr[32].ToLong();
//                    l.manifested_flg = dr[33].ToString();
//                    //l.create_user = dr[34].ToString();
//                    //l.create_dt = dr[35].ToDateTime();
//                    //l.modify_user = dr[36].ToString();
//                    //l.modify_dt = dr[37].ToDateTime();
//                    l.vd_flg = dr[38].ToString();
//                    l.cargo_status = dr[40].ToString();
//                    l.cargo_bol_no = dr[41].ToString();

//                    lob.Add(new clsLOB()
//                    {
//                        lobExtract = l,
//                        search_voyage_no = dr[4].ToString(),
//                        search_pol = dr[25].ToString()
//                    });
//                }
                
//                return lob;
//            }
//            catch
//            {
//                return null;
//            }
//        }

//        public static bool DoesVoyageAndPOLExist(string _voyage, string _pol, int version_no)
//        {
//            ClsLobHeader h = ClsLobHeader.GetByVoyagePOLVersion(_voyage, _pol, version_no);
//            return (h.IsNotNull());
//        }

//        public static bool DeleteHeaderDetailFromDatabase(ClsLobHeader _header)
//        {
//            string sql;
//            bool blnInTrans = Connection.IsInTransaction;

//            if (!blnInTrans) Connection.TransactionBegin();

//            try
//            {
//                sql = string.Format(@"delete from t_lob_detail where lob_header_id = {0} ", _header.Lob_Header_ID);
//                Connection.RunSQL(sql);

//                sql = string.Format(@"delete from t_lob_header where lob_header_id = {0} ", _header.Lob_Header_ID);
//                Connection.RunSQL(sql);

//                if (!blnInTrans) Connection.TransactionCommit();
//                return true;
//            }
//            catch (Exception ex)
//            {
//                if (!blnInTrans) Connection.TransactionRollback();
//                ClsErrorHandler.LogException(ex);
//                return false;
//            }
//        }

//        public static bool LoadHeaderDetailFromDatabase(BindingList<clsLOB> lob, BindingList<clsLOB> lstRemove, long? Version_No)
//        {
//            foreach (clsLOB l in lob)
//                if (!l.LoadFromDatabase(Version_No))

//                    lstRemove.Add(l);
//                    //AreThereErrors = true;

//            foreach (clsLOB r in lstRemove)
//                lob.Remove(r);

//            return true;
//        }

//        public static bool LoadHeaderDetailFromDatabaseNOTinExtract(string _voyage, string _pol, int version_no, BindingList<clsLOB> _lob)
//        {
//            StringBuilder sb = new StringBuilder();

//            try
//            {

//                foreach (clsLOB l in _lob)
//                    sb.AppendFormat("'{0}{1}',", l.lobExtract.pcfn.Trim(), l.lobExtract.tcn.Trim());

//                string sql = string.Format(@"
//                    Select d.*
//                    from t_lob_header h
//                    inner join t_lob_detail d on d.lob_header_id = h.lob_header_id
//                    where 1=1
//                    and h.voyage_no = '{0}'
//                    and h.pol_location_cd = '{1}'
//                    and h.version_no = {2}
//                    and trim(d.pcfn) || trim(d.tcn) not in ({3})
//                ", _voyage, _pol, version_no, sb.ToString().TrimEnd(','));

//                var lstlobDetail = Connection.GetList<ClsLobDetail>(sql);

//                foreach (ClsLobDetail d in lstlobDetail)
//                    _lob.Add(new clsLOB()
//                    {
//                        lobDetail = d,
//                        lobHeader = ClsLobHeader.GetUsingKey((long)d.Lob_Header_ID),
//                    });

//                return true;

//            }
//            catch
//            {
//                return false;
//            }
//        }

//        public static bool CreateHeaderDetailFromExtract(BindingList<clsLOB> lob, int version_no)
//        {
//            bool AreThereErrors = false;

//            foreach (clsLOB l in lob)
//                if (!l.CreateLOB(version_no))
//                    AreThereErrors = true;

//            return !AreThereErrors;

//        }

//        /// <summary>
//        /// Save the Data to the T_LOB_HEADER and T_LOB_DETAIL tables.  We do ask whether it is for a NEW version; if so
//        /// we make sure the header is ta
//        /// </summary>
//        /// <param name="lob"></param>
//        /// <param name="NewVersion"></param>
//        /// <returns></returns>
//        public static bool SaveHeaderDetailToDatabase(BindingList<clsLOB> lob, bool NewVersion)
//        {
//            bool AreThereErrors = false;

//            ClsLobHeader NewHeader = new ClsLobHeader();

//            foreach (clsLOB l in lob)
//            {
//                if (!l.Validate())
//                    AreThereErrors = true;
//            }

//            if (!AreThereErrors)
//            {
//                if (NewVersion) 
//                {
//                    NewHeader.CopyFrom(lob[0].lobHeader);

//                    NewHeader.Lob_Header_ID = null;
//                    NewHeader.Version_No++;

//                    if (NewHeader.Insert() != 1)
//                    {
//                        lob[0].ErrorAdd("Could not create new version of Load List.");
//                        AreThereErrors = true;
//                    }
//                }

//                if (!AreThereErrors)
//                {
//                    foreach (clsLOB l in lob)
//                    {
//                        if (NewVersion)
//                        {
//                            if (!l.SaveAsNewVersion(NewHeader))
//                                AreThereErrors = true;
//                        }
//                        else
//                        {
//                            if (!l.Save())
//                                AreThereErrors = true;
//                        }
//                    }
//                }
//            }

//            return !AreThereErrors;
//        }

//        public static bool NewHeaderDetailRecord(BindingList<clsLOB> lob)
//        {
//            try
//            {
//                var l = new clsLOB() 
//                { 
//                    lobExtract = null, 
//                    lobHeader = new ClsLobHeader(), 
//                    lobDetail = new ClsLobDetail() 
//                };

//                l.lobHeader.CopyFrom(lob[0].lobHeader);

//                l.SetNewDefaults();
//                lob.Add(l);

//                return true;
//            }
//            catch 
//            {
//                return false;
//            }
//        }

//        public static int NumberOfRowsSelected(BindingList<clsLOB> lstLob)
//        {
//            try
//            {
//                int x = 0;
//                foreach (clsLOB l in lstLob) if (l.chx) x++;
//                return x;
//            }
//            catch 
//            {
//                return 0;
//            }
//        }

//        public static bool DeleteDetail(clsLOB Lob)
//        {
//            try
//            {
//                return (Lob.lobDetail.Delete() > 0); 
//            }
//            catch 
//            {
//                return false;
//            }

//        }

//        public Boolean LoadFromDatabase(BindingList<clsLOB> lob,long? Version_no)
//        {
//            try
//            {
//                ErrorClear();

//                lobDetail = ClsLobDetail.GetByPcfnTcn(lobExtract.pcfn, lobExtract.tcn, Version_no);
//                if (lobDetail.IsNull())
//                {
//                    ErrorAdd(string.Format("Could not load detail for PCFN='{0}' and TCN='{1}'.", lobExtract.pcfn, lobExtract.tcn));
//                    return false;
//                }
//                lobDetail.New_Flg = false;

//                lobHeader = ClsLobHeader.GetUsingKey((long)lobDetail.Lob_Header_ID);

//                if (lobHeader.IsNull())
//                {
//                    ErrorAdd(string.Format("Could not load Header for PCFN='{0}' and TCN='{1}'.", lobExtract.pcfn, lobExtract.tcn));
//                    return false;
//                }
//                lobHeader.New_Flg = false;

//                return true;

//            }
//            catch (Exception ex)
//            {
//                ClsErrorHandler.LogException(ex);
//                return false;
//            }
//        }

//        // Create LOB here 
//        public bool CreateLOB(BindingList<clsLOB> lob,int version_no)
//        {
//            ErrorClear();

//            bool blnInTrans = Connection.IsInTransaction;

//            if (!blnInTrans) Connection.TransactionBegin();

//            try
//            {
//                // Does header exist?  
//                // If 'yes' then load it ... 
//                // If 'no' then insert it ... 
//                lobHeader = ClsLobHeader.GetByVoyagePOLVersion(search_voyage_no, search_pol, version_no);

//                if (lobHeader.IsNull())
//                {
//                    var v = ClsVVoyage.GetByVoyageNo(search_voyage_no);

//                    lobHeader = new ClsLobHeader()
//                    {
//                        Voyage_No = lobExtract.voyage_no,
//                        Vessel_Nm = v.Vessel.Vessel_Dsc,
//                        Military_Voyage_No = v.Military_Voyage_Cd,
//                        Pol_Location_Cd = lobExtract.pol_location_cd,
//                        Confirm_Flg = "N",
//                        Version_No = version_no
//                    };
//                    if (lobHeader.Insert() != 1)
//                    {
//                        ErrorAdd(string.Format("Could not create Header for VOYAGE='{0}', POL='{1}' and VERSION='{2}'", search_voyage_no, search_pol, version_no.ToString()));
//                        Connection.TransactionRollback();
//                        return false;
//                    }
//                    lobHeader.New_Flg = false;
//                }

//                lobDetail = new ClsLobDetail()
//                {
//                    Lob_Header_ID = lobHeader.Lob_Header_ID,
//                    Booking_No = lobExtract.booking_no,
//                    Cargo_Dsc = lobExtract.cargo_dsc,
//                    Comment_One = lobExtract.comment_one,
//                    Comment_Two = lobExtract.comment_two,
//                    Consignee_Dodaac = lobExtract.consignee_dodaac,
//                    Consignor_Dodaac = lobExtract.consignor_dodaac,
//                    Container_No = lobExtract.container_no,
//                    Cube_Nbr = lobExtract.cube_nbr,
//                    Vd_Flg = lobExtract.vd_flg,
//                    Si_Flg = lobExtract.si_flg,
//                    Booked_Flg = lobExtract.booked_flg,
//                    Manifested_Flg = lobExtract.manifested_flg,
//                    Height_Nbr = lobExtract.height_nbr,
//                    Width_Nbr = lobExtract.width_nbr,
//                    Length_Nbr = lobExtract.length_nbr,
//                    Weight_Nbr = lobExtract.weight_nbr,
//                    Mton_Nbr = lobExtract.mton_nbr,
//                    Pcfn = lobExtract.pcfn,
//                    Pod_Location_Cd = lobExtract.pod_location_cd,
//                    Tcn = lobExtract.tcn,
//                    Vessel_Status_Cd = lobExtract.vessel_status_cd,
//                    Van_Type = lobExtract.van_type,
//                    Rdd_Dt = lobExtract.rdd_dt,
//                    Commodity_Cd = lobExtract.commodity_cd,
//                    Cargo_Status = lobExtract.cargo_status
//                };

//                if (lobDetail.Insert() != 1)
//                {
//                    ErrorAdd(string.Format("Could not create Detail for VOYAGE='{0}', POL='{1}', PCFN='{2}' and TCN='{3}'.", search_voyage_no, search_pol, lobExtract.pcfn, lobExtract.tcn));
//                    Connection.TransactionRollback();
//                    return false;
//                }
//                lobDetail.New_Flg = false;

//                if (!blnInTrans) Connection.TransactionCommit();
//                return true;

//            }
//            catch (Exception ex)
//            {
//                if (!blnInTrans) Connection.TransactionRollback();
//                ClsErrorHandler.LogException(ex);
//                return false;
//            }

//        }

//        // TODO:  Need to break up the logic from 
//        public bool PopulateLoadListFromExtract()
//        {
//            return true;
//        }


        #endregion

    }
}
