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
    /// <summary>
    /// The LOB Header is inherited from the ClsLobHeader and it contains all of the static methods needed for the LOB screen.  It contains several Lists being:
    ///     detailExtract - This is a list of detailExtract objects.  This object holds one (1) clsLobDetail object and one (1) extract object ... This is useful for comparisons
    /// </summary>
    public class LobHeader : ClsLobHeader
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

        public bool AreThereErrors
        {
            get
            {
                return (NumberOfErrors > 0);
            }
        }

        #endregion

        #region Properties
       
        private BindingList<LobDetailExtract> _detailExtract;

        public BindingList<LobDetailExtract> detailExtract
        {
            get
            {
                return _detailExtract;
            }
            set
            {
                _detailExtract = value;
            }
        }

        private BindingList<LobDetailExtract> _notOnLoadList;

        public BindingList<LobDetailExtract> notOnLoadList
        {
            get
            {
                return _notOnLoadList;
            }
            set
            {
                _notOnLoadList = value;
            }
        }

        private BindingList<LobDetailExtract> _toBeDeleted;

        public BindingList<LobDetailExtract> toBeDeleted
        {
            get 
            {
                return _toBeDeleted;
            }
            set
            {
                _toBeDeleted = value;
            }
        }

        public string Title 
        {
            get
            {
                return string.Format("Vessel: {0} ... Voyage: {1} ... POL: {2} ... Version: {3} ... [{4}]", 
                    Vessel_Nm, 
                    Voyage_No,
                    Pol_Location_Cd,
                    Version_No.ToString(),
                    LobStateText
                    );
            }
        }

        public string WindowTitle
        {
            get
            {
                return string.Format(" Load List - {0} - {1} - v{2}",
                    Voyage_No,
                    Pol_Location_Cd,
                    Version_No.ToString());
            }

        }

        private string LobStateText
        {
            get
            {
                switch (LobState)
                {
                    case 1:
                        return "Read Only";
                    case 2:
                        return "Current Version - Transmitted";
                    case 3:
                        return "Current Version - Not Transmitted";
                }
                return "NA";
            }
        }

        /// <summary>
        /// Determines the state of the current version of the LOB
        /// 1 = Read-Only
        /// 2 = Current-Transmitted
        /// 3 = Current-Not-Transmitted
        /// </summary>
        public int LobState
        {
            get
            {
                long latestVersion = LobHeader.GetLatestVersionNo(Voyage_No, Pol_Location_Cd);

                if (latestVersion == Version_No)
                    return (Transmit_Dt.IsNull()) ? 3 : 2;
                return 1;
            }
        }

        #endregion

		#region Methods
		public bool UpdateTransmitDate(DateTime dtSailDt)
		{
			bool bInTrans = Connection.IsInTransaction;
			if (!bInTrans)
				Connection.TransactionBegin();
			try
			{
				ClsLobHeader lobOriginal = ClsLobHeader.GetFirstVersion(Voyage_No, Pol_Location_Cd);
				Sail_Dt = dtSailDt;
				if (lobOriginal != null)
					if (lobOriginal.Sail_Dt != null)
						Sail_Dt = lobOriginal.Sail_Dt;
				Transmit_Dt = DateTime.Today;
				this.Update();
				if (!bInTrans)
					Connection.TransactionCommit();
				return true;
			}
			catch (Exception ex)
			{
				if (!bInTrans)
					Connection.TransactionRollback();
				ClsErrorHandler.LogException(ex);
				return false;
			}
		}
		#endregion

		#region Public Static Methods

		/// <summary>
        /// Load Header/Detail from the database based upon a version.  Do we pass in the extract (DataTable) and load that for comparison?
        /// </summary>
        /// <param name="version"></param>
        /// <returns></returns>
        public static LobHeader LoadVersionFromDatabase(long lobHeaderID,BindingList<clsLobExtract> extract)
        {
            LobHeader h = new LobHeader();
            LobDetailExtract de;

            try
            {
                h.CopyFrom(ClsLobHeader.GetUsingKey(lobHeaderID));

                if (h.IsNull())
                {
                    h.ErrorAdd("Could not load Lob Header record.");
                    return h;
                }

                h.detailExtract = new BindingList<LobDetailExtract>();
                BindingList<ClsLobDetail> ld = ClsLobDetail.GetBindingListByHeaderID((long)h.Lob_Header_ID);

                foreach (ClsLobDetail l in ld)
                {
                    de = new LobDetailExtract() { lobDetail = l, lobExtract = FindExtractRow(l, extract) };
                    h.detailExtract.Add(de);
                }

                h.notOnLoadList = IdentifyDeletedExtract(h.detailExtract, extract);

                return h;

            }
            catch (Exception ex)
            {
                ClsErrorHandler.LogException(ex);
                h.ErrorAdd(ex.Message);
                return h;
            }

        }

        /// <summary>
        /// Deletes the 'Current-Not-Transmitted' version of the LOB
        /// </summary>
        /// <param name="lob"></param>
        /// <returns></returns>
        public static bool DeleteVersionFromDatabase(LobHeader lob)
        {

            bool blnInTrans = Connection.IsInTransaction;
            if (!blnInTrans) Connection.TransactionBegin();

            try
            {

                foreach (LobDetailExtract de in lob.detailExtract)
                {
                    if (de.lobDetail.Delete() != 1)
                    {
                        de.ErrorAdd("Could not delete detail.");
                        Connection.TransactionRollback();
                        return false;
                    }
                }

                if (lob.Delete() != 1)
                {
                    lob.ErrorAdd("Could not delete detail.");
                    Connection.TransactionRollback();
                    return false;
                }

                Connection.TransactionCommit();
                return true;
            }
            catch (Exception ex)
            {
                ClsErrorHandler.LogException(ex);
                Connection.TransactionRollback();
                return false;
            }
        }

        /// <summary>
        /// Create a new version of the Header and Detail based upon the data extract alone.
        /// </summary>
        /// <param name="extract"></param>
        /// <returns></returns>
        public static LobHeader CreateVersionFromExtract(BindingList<clsLobExtract> extract, string voyageNo, string pol, string vesselCd)
        {

            LobHeader newH = new LobHeader(); ;

            bool blnInTrans = Connection.IsInTransaction;
            if (!blnInTrans) Connection.TransactionBegin();

            try
            {

                CS2010.ACMS.Business.ClsVVoyage v = CS2010.ACMS.Business.ClsVVoyage.GetByVoyageNo(voyageNo);
                if (v.IsNull())
                {
                    newH = new LobHeader();
                    newH.ErrorAdd( string.Format("Could not find voyage '{0}'", voyageNo));
                    if (!blnInTrans) Connection.TransactionRollback();
                    return newH;
                }

                long versionNo = 1;

                ClsLobHeader currentH = ClsLobHeader.GetLatestVersion(voyageNo, pol);

                if (currentH.IsNotNull()) versionNo = ((long)currentH.Version_No) + 1;

                // Create New Header record ... It is either a brand new version 1 or the next version in the sequence ...
                newH = new LobHeader()
                {
                    Voyage_No = voyageNo,
                    Vessel_Nm = v.Vessel.Vessel_Dsc,
                    Military_Voyage_No = v.Military_Voyage_Cd,
                    Pol_Location_Cd = pol,
                    Confirm_Flg = "N",
                    Version_No = versionNo,
					Sail_Dt = v.Sail_Dt
                };

                if (newH.Insert() != 1)
                {
                    newH.ErrorAdd(string.Format("Could not create Header for VOYAGE='{0}', POL='{1}' and VERSION='{2}'", voyageNo, pol, versionNo.ToString()));
                    Connection.TransactionRollback();
                    return newH;
                }

                newH.detailExtract = new BindingList<LobDetailExtract>();

                // Create the detailExtract record which represents a single row in the grid.
                foreach (clsLobExtract le in extract)
                    newH.detailExtract.Add(new LobDetailExtract() { lobExtract = le });

                if (newH.detailExtract.IsNull())
                {
                    newH.ErrorAdd(string.Format("Could not populate data extract."));
                    Connection.TransactionRollback();
                    return newH;
                }

                foreach (LobDetailExtract de in newH.detailExtract)
                {

                    de.lobDetail = new ClsLobDetail()
                    {
                        Lob_Header_ID = newH.Lob_Header_ID,
                        Booking_No = de.lobExtract.booking_no,
                        Cargo_Dsc = de.lobExtract.cargo_dsc,
                        Comment_One = de.lobExtract.comment_one,
                        Comment_Two = de.lobExtract.comment_two,
                        Consignee_Dodaac = de.lobExtract.consignee_dodaac,
                        Consignor_Dodaac = de.lobExtract.consignor_dodaac,
                        Container_No = de.lobExtract.container_no,
                        Cube_Nbr = de.lobExtract.cube_nbr,
                        Vd_Flg = de.lobExtract.vd_flg,
                        Si_Flg = de.lobExtract.si_flg,
                        Booked_Flg = de.lobExtract.booked_flg,
                        Manifested_Flg = de.lobExtract.manifested_flg,
                        Height_Nbr = de.lobExtract.height_nbr,
                        Width_Nbr = de.lobExtract.width_nbr,
                        Length_Nbr = de.lobExtract.length_nbr,
                        Weight_Nbr = de.lobExtract.weight_nbr,
                        Mton_Nbr = de.lobExtract.mton_nbr,
                        Pcfn = de.lobExtract.pcfn,
                        Pod_Location_Cd = de.lobExtract.pod_location_cd,
                        Tcn = de.lobExtract.tcn,
                        Vessel_Status_Cd = de.lobExtract.vessel_status_cd,
                        Van_Type = de.lobExtract.van_type,
                        Rdd_Dt = de.lobExtract.rdd_dt,
                        Commodity_Cd = de.lobExtract.commodity_cd,
                        Cargo_Status = de.lobExtract.cargo_status,
                        Bol_No = de.lobExtract.cargo_bol_no
                    };

                    if (de.lobDetail.Insert() != 1)
                    {
                        newH.ErrorAdd(string.Format("Could not create Detail for VOYAGE='{0}', POL='{1}', PCFN='{2}' and TCN='{3}'.", voyageNo, pol, de.lobDetail.Pcfn, de.lobDetail.Tcn));
                        Connection.TransactionRollback();
                        return newH;
                    }
                
                }
                
                if (!blnInTrans) Connection.TransactionCommit();
                return newH;

            }
            catch (Exception ex)
            {
                if (!blnInTrans) Connection.TransactionRollback();
                ClsErrorHandler.LogException(ex);
                newH.ErrorAdd(ex.Message);
                return newH;
            }
        }

        /// <summary>
        /// Save the current Header/Detail to the datebase (UPDATES).  Inserts for any record tagged with a newFlg.  Deletes for any records tagged with a deleteFlg.
        /// </summary>
        /// <param name="lob"></param>
        /// <returns></returns>
        public static bool SaveCurrentVersion(LobHeader lob)
        {

            bool blnInTrans = Connection.IsInTransaction;
            if (!blnInTrans) Connection.TransactionBegin();

            try
            {
                lob.ErrorClear();

                foreach (LobDetailExtract de in lob.detailExtract)
                {

                    if (de.lobDetail.New_Flg) // or do I just check the lob_detail_id ???
                    {
                        // Insert ...
                        de.lobDetail.Lob_Header_ID = lob.Lob_Header_ID;
                        if (de.lobDetail.Insert() != 1)
                        {
                            lob.ErrorAdd(string.Format("Could not insert detail for TCN '{0}'.", de.lobDetail.Tcn));
                            if (!blnInTrans) Connection.TransactionRollback();
                            return false;
                        }
                        de.lobDetail.New_Flg = false; // Setting the flag to false so we do not insert on a second 'Save' operation
                    }
                    else
                    {
                        // Update ...
                        if (de.lobDetail.Update() != 1)
                        {
                            lob.ErrorAdd(string.Format("Could not update detail for TCN '{0}'.", de.lobDetail.Tcn));
                            if (!blnInTrans) Connection.TransactionRollback();
                            return false;
                        }
                    }
                }

                // Delete any records tagged for delete
                if (lob.toBeDeleted.IsNotNull())
                {
                    foreach (LobDetailExtract de in lob.toBeDeleted)
                    {
                        if (de.lobDetail.IsNotNull())
                        {
                            if (de.lobDetail.Lob_Detail_ID.IsNotNull())
                            {
                                // Delete ...
                                if (de.lobDetail.Delete() != 1)
                                {
                                    lob.ErrorAdd(string.Format("Could not delete detail for TCN '{0}'.", de.lobDetail.Tcn));
                                    if (!blnInTrans) Connection.TransactionRollback();
                                    return false;
                                }
                            }
                        }
                    }
                }

                //Update ACMS detail data ...

                // JD - I DO NOT want to do this yet.   There is no TEST platform, so lets make sure all of the other changes work and then we
                // can focus on this.

                foreach (LobDetailExtract de in lob.detailExtract)
                {
                    if (!de.lobDetail.UpdateACMS())
                    {
                        de.ErrorAdd("Could not update ACMS");
                        if (!blnInTrans) Connection.TransactionRollback();
                        return false;
                    }
                }

                if (!blnInTrans) Connection.TransactionCommit();
                return true;

            }
            catch (Exception ex)
            {
                if (!blnInTrans) Connection.TransactionRollback();
                ClsErrorHandler.LogException(ex);
                lob.ErrorAdd(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Save the current Header/Detail to the database (INSERT).    Inserts for any record tagged with a 'newFlg'.  Deletes for any records tagged with a 'deleteFlg'.
        /// </summary>
        /// <param name="lob"></param>
        /// <returns></returns>
        public static bool SaveNewVersion(LobHeader lob)
        {
            bool blnInTrans = Connection.IsInTransaction;
            if (!blnInTrans) Connection.TransactionBegin();

            try
            {
                lob.ErrorClear();

                ClsLobHeader latestH = ClsLobHeader.GetLatestVersion(lob.Voyage_No, lob.Pol_Location_Cd);
                if (latestH.IsNull())
                {
                    lob.ErrorAdd("Could not get the latest version.");
                    if (!blnInTrans) Connection.TransactionRollback();
                    return false;
                }

                lob.Lob_Header_ID = null;
                lob.Version_No = latestH.Version_No + 1;

                if (lob.Insert() != 1)
                {
                    lob.ErrorAdd("Could not create a new version of the LOB.");
                    if (!blnInTrans) Connection.TransactionRollback();
                    return false;
                }

                foreach (LobDetailExtract de in lob.detailExtract)
                {
                    // Insert ...
                    de.lobDetail.Lob_Header_ID = lob.Lob_Header_ID;
                    if (de.lobDetail.Insert() != 1)
                    {
                        lob.ErrorAdd(string.Format("Could not insert detail for TCN '{0}'.", de.lobDetail.Tcn));
                        if (!blnInTrans) Connection.TransactionRollback();
                        return false;
                    }
                }

                if (!blnInTrans) Connection.TransactionCommit();
                return true;

            }
            catch (Exception ex)
            {
                if (!blnInTrans) Connection.TransactionRollback();
                ClsErrorHandler.LogException(ex);
                lob.ErrorAdd(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Add a detailExtract to the BindingList.  Set the 'newFlg' to true for the detailExtract record.
        /// </summary>
        /// <param name="lob"></param>
        /// <param name="detailExtract"></param>
        /// <returns></returns>
        public static bool AddDetail(LobHeader lob, LobDetailExtract detailExtract)
        {
            try
            {
                detailExtract.lobDetail.New_Flg = true;
                lob.detailExtract.Add(detailExtract);
                return true;
            }
            catch (Exception ex)
            {
                ClsErrorHandler.LogException(ex);
                return false;
            }
        }

        /// <summary>
        /// Set the 'deleteFlg' to true for the detailExtract record in the Binding List.
        /// </summary>
        /// <param name="lob"></param>
        /// <param name="detailExtract"></param>
        /// <returns></returns>
        public static bool RemoveDetail(LobHeader lob, LobDetailExtract detailExtract)
        {
            try
            {

                if (lob.toBeDeleted.IsNull())
                    lob.toBeDeleted = new BindingList<LobDetailExtract>();

                lob.toBeDeleted.Add(detailExtract);
                
                lob.detailExtract.Remove(detailExtract);

                return true;
            }
            catch (Exception ex)
            {
                ClsErrorHandler.LogException(ex);
                return false;
            }

        }

        /// <summary>
        /// Adds the deleted LOB detail back onto an LOB ... If the TCN already exists then overwrite it.
        /// </summary>
        /// <param name="lob"></param>
        /// <param name="detailExtract"></param>
        /// <returns></returns>
        public static bool AddDeletedDetail(LobHeader lob, LobDetailExtract detailExtract)
        {

            bool blnInTrans = Connection.IsInTransaction;
            if (!blnInTrans) Connection.TransactionBegin();

            try
            {
                ClsLobDetail ld;

                ld = ClsLobDetail.GetByTcn(detailExtract.lobExtract.tcn, lob.Version_No);

                
                if (ld.IsNotNull())
                {
                    // if exists then update it ...
                    ld.PopulateFromExtract(detailExtract.lobExtract);
                    ld.New_Flg = false;
                    detailExtract.lobDetail = ld;
                }
                else
                {
                    // If does NOT exist then insert it ...
                    ld = new ClsLobDetail();
                    ld.PopulateFromExtract(detailExtract.lobExtract);
                    
                    ld.Lob_Header_ID = lob.Lob_Header_ID;
                    ld.New_Flg = true;
                    detailExtract.lobDetail = ld;

                }

                // Add to the Detail Extract List but it is NOT saved to the database at this point ...
                lob.detailExtract.Add(detailExtract);

                // Remove the detail from the Deleted List/Grid ... once again changes have NOT hit the database at this point
                lob.notOnLoadList.Remove(detailExtract);

                Connection.TransactionCommit();
                return true;
            }
            catch (Exception ex)
            {
                ClsErrorHandler.LogException(ex);
                Connection.TransactionRollback();
                return false;
            }
        }

        /// <summary>
        /// Takes the ACMS extract DataTable and loads into a List of clsLobExtract objects.
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static BindingList<clsLobExtract> PopulateLOBFromExtract(DataTable dt)
        {
            BindingList<clsLobExtract> e = new BindingList<clsLobExtract>();

            try
            {
                foreach(DataRow dr in dt.Rows)
                    e.Add( clsLobExtract.Populate(dr));

                return e;
            }
            catch (Exception ex)
            {
                ClsErrorHandler.LogException(ex);
                return null;
            }
        }

        /// <summary>
        /// Finds the extract row from the ACMS data extract DataTable, using the tcn from the T_LOB_DETAIL (ClsLobDetail) for the source.
        /// </summary>
        /// <param name="de"></param>
        /// <param name="dt"></param>
        public static clsLobExtract FindExtractRow(ClsLobDetail ld, BindingList<clsLobExtract> extract)
        {
            try
            {

                clsLobExtract[] x =
                    (from e in extract
                     where e.pcfn == ld.Pcfn && e.tcn == ld.Tcn
                     select e).ToArray<clsLobExtract>();

                return x[0];

            }
            catch (Exception ex)
            {
                ClsErrorHandler.LogException(ex);
                return null;
            }
        }

        /// <summary>
        ///  This identifies any of the ACMS extract rows that have been removed from a saved version of the LOB.  This will then be displayed for informational purposes.
        /// </summary>
        /// <param name="de"></param>
        /// <param name="extract"></param>
        /// <returns></returns>
        public static BindingList<LobDetailExtract> IdentifyDeletedExtract(BindingList<LobDetailExtract> de, BindingList<clsLobExtract> extract)
        {
            try
            {

                BindingList<LobDetailExtract> lstDE = new BindingList<LobDetailExtract>();

                //var x = extract.Where(e => !de.Any(d => (d.lobDetail.Pcfn + d.lobDetail.Tcn) == (e.pcfn + e.tcn) ));

                //var x = extract.Where(e => !de.Any(d => ((d.lobDetail.Pcfn == e.pcfn ) && (d.lobDetail.Tcn == e.tcn)) ));

                //var x = 
                //    from e in extract
                //    where !(from d in de
                //            select ( d.lobDetail.Tcn)).Contains( e.tcn )                       
                //    select e;

                var x =
                    from e in extract
                    where !(from d in de
                            select (
                                string.Format("{0}{1}",d.lobDetail.Pcfn, d.lobDetail.Tcn))).Contains(string.Format("{0}{1}",e.pcfn, e.tcn)
                                )
                    select e;

                foreach (clsLobExtract z in x)
                    lstDE.Add(new LobDetailExtract() { lobExtract = z });

                return lstDE;

            }
            catch (Exception ex)
            {
                ClsErrorHandler.LogException(ex);
                return null;
            }
        } 

        #endregion

    }
}
