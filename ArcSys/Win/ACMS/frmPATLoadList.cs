using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CS2010.ACMS.Business;
using CS2010.CommonSecurity;
using CS2010.CommonWinCtrls;
using System.Configuration;
using System.IO;
using CS2010.ArcSys.Business;
using CS2010.ArcSys.Business.PAT;
using Janus.Windows.GridEX;
using CS2010.Common;

namespace CS2010.ArcSys.Win
{
	public partial class frmPATLoadList : frmChildBase
	{
        private LobHeader header;
        private BindingList<clsLobExtract> extract;

		public frmPATLoadList()
		{
			InitializeComponent();
			CS2010.ArcSys.Business.PAT.UploadLOBRequest p = new UploadLOBRequest();
            FormatGrid();
		}

        /// <summary>
        /// Entry point for the window ... Decides how to load a LOB
        /// </summary>
        /// <param name="dtLOB">The ACMS data extract</param>
        public void ShowForm(DataTable dtLOB)
        {
            try
            {

                this.Activate();
                this.MdiParent = Program.MainWindow;
                this.WindowState = FormWindowState.Maximized;
                ClsSecurityMaster.SetSecurity(this);

                extract = LobHeader.PopulateLOBFromExtract(dtLOB);

                // Get the voyage and POL from the extract and see if this already exists
                string voyageNo = extract[0].voyage_no;
                string pol = extract[0].pol_location_cd;
                string vesselCd = dtLOB.Rows[0]["vessel_cd"].ToString();
                ClsLobHeader latestLobHeader = LobHeader.GetLatestVersion(voyageNo, pol);

                if (latestLobHeader.IsNull())
                {
                    header = LobHeader.CreateVersionFromExtract(extract, voyageNo, pol, vesselCd);
                    if (header.AreThereErrors)
                    {
                        Program.MouseNormal();
                        Program.Show(header.ErrorMsg);
                        this.Close();
                        return;
                    }
                    MessageBox.Show("A new version #1 has been created.");
                }
                else
                {
                    header = LobHeader.LoadVersionFromDatabase((long)latestLobHeader.Lob_Header_ID, extract);
                    if (header.AreThereErrors)
                    {
                        Program.MouseNormal();
                        Program.Show(header.ErrorMsg);
                        this.Close();
                        return;
                    }
                }

                SetForm();

                this.Show();
                Program.MouseNormal();
            }
            catch (Exception ex)
            {
                Program.MouseNormal();
                Program.ShowError(ex);
            }
        }

        #region Private Methods
        
        /// <summary>
        /// Refreshes the Grids and sets the Form Title
        /// </summary>
        private void SetForm()
        {
            this.Text = header.WindowTitle;

            lblLoadList.Text = header.Title;

            SetWindowState();

            grdLOB.DataSource = header.detailExtract; 
            grdLOB.DropDowns["dd_commodity_cd"].SetDataBinding(ACMS.Business.ClsDropDowns.CommodityDescriptions, "COMMODITY_CD");

            grdLobRemoved.DataSource = header.notOnLoadList;

            ClsGridExUtils.Setbackgroundformat(grdLOB);
        }

        /// <summary>
        /// This is NOT saving when using the Grid's property manager ... so doing it manually.
        /// </summary>
        private void FormatGrid()
        {
            grdLOB.RootTable.HideColumnsWhenGrouped = InheritableBoolean.True;
        }

        /// <summary>
        /// Package LOB data and send to SDDC webservice
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void btnSend2Pat_Click(object sender, EventArgs e)
        //{
        //    //SendToPAT(true);
        //    ClsPATLoadList pat = new ClsPATLoadList();
        //    pat.SendToPAT(true, header, header.Voyage_No);
        //    if (pat.HasErrors)
        //        Program.Show(pat.Error);
        //    else
        //        Program.Show("Success");
        //}

        /// <summary>
        /// Package LOB data and send to SDDC webservice (TEST VERSION)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void btnTest_Click(object sender, EventArgs e)
        //{
        //    //SendToPAT(false);
        //    ClsPATLoadList pat = new ClsPATLoadList();
        //    pat.SendToPAT(false, header, header.Voyage_No);
        //    if (pat.HasErrors)
        //        Program.Show(pat.Error);
        //    else
        //        Program.Show("Success");
        //}

        /// <summary>
        /// Saves the current version of the LobHeader and LobDetail 
        /// </summary>
        private void SaveCurrent()
        {
            try
            {
                Program.MouseBusy();

                if (!LobHeader.SaveCurrentVersion(header))
                {
                    Program.MouseNormal();
                    MessageBox.Show(header.ErrorMsg);
                }
                Program.MouseNormal();
                MessageBox.Show("Success");
            }
            catch (Exception ex)
            {
                Program.MouseNormal();
                Program.ShowError(ex);
            }
        }

        /// <summary>
        /// Save the current version of the LobHeader and LobDetail as a brand NEW version.
        /// </summary>
        private void SaveNew()
        {
            try
            {
                Program.MouseBusy();

                if (!LobHeader.SaveNewVersion(header))
                {
                    Program.MouseNormal();
                    MessageBox.Show(header.ErrorMsg);
                }
                SetForm();
                Program.MouseNormal();
                MessageBox.Show("Success");
            }
            catch (Exception ex)
            {
                Program.MouseNormal();
                Program.ShowError(ex);
            }
        }

        /// <summary>
        /// Presents the user the option to Load a new LobHeader or Create a new one based on the current version.
        /// </summary>
        private void LoadCreate()
        {
            try
            {

                frmPATLoadDecision decision = new frmPATLoadDecision();

                if (decision.ShowForm(header.Voyage_No, header.Pol_Location_Cd) == DialogResult.Cancel)
                {
                    return;
                }

                Program.MouseBusy();

                if (decision.CreateNewVersion)
                {
                    if (!LobHeader.SaveNewVersion(header))
                    {
                        Program.MouseNormal();
                        Program.Show(header.ErrorMsg);
                        this.Close();
                        return;
                    }
                }
                else
                {
                    header = LobHeader.LoadVersionFromDatabase(decision.LoadLobHeaderId, extract);

                    if (header.AreThereErrors)
                    {
                        Program.MouseNormal();
                        MessageBox.Show(header.ErrorMsg);
                        return;
                    }

                }
                SetForm();
                Program.MouseNormal();
                MessageBox.Show("Success");
            }
            catch (Exception ex)
            {
                Program.MouseNormal();
                Program.ShowError(ex);
            }
        }

        /// <summary>
        /// Enables a user to add a new LobDetail row to the current LOB version.
        /// </summary>
        private void New()
        {
            try
            {
                LobDetailExtract de = new LobDetailExtract();

                de.lobDetail = new ClsLobDetail();
                de.lobDetail.Lob_Header_ID = header.Lob_Header_ID;
                de.lobDetail.SetDefaults();

                frmLOBAssembleDetail frmLob = new frmLOBAssembleDetail();

                if (frmLob.ShowOpen(de))
                {
                    Program.MouseBusy();
                    de.lobDetail.New_Flg = true;
                    LobHeader.AddDetail(header, de);
                    grdLOB.Refresh();
                    MessageBox.Show("Success");
                }

                Program.MouseNormal();
                
            }
            catch (Exception ex)
            {
                Program.MouseNormal();
                Program.ShowError(ex);
            }
        }

        /// <summary>
        ///  Delete row(s) from the LobDetails 
        /// </summary>
        private void Delete()
        {
            try
            {
                var araG = grdLOB.GetCheckedRows();
                LobDetailExtract de;
                if (araG.Length < 1)
                {
                    MessageBox.Show("Please select a row to delete.");
                    return;
                }

                Program.MouseBusy();

                foreach (GridEXRow g in araG)
                {
                    de = (LobDetailExtract)g.DataRow;

                    LobHeader.RemoveDetail(header, de);
                }

                //TODO: Check to see if all detail has been deleted ... If so, do I delete the header?
                grdLOB.Refresh();
                //grdLobRemoved.Refresh();
                Program.MouseNormal();
                MessageBox.Show("Success");
           
            }
            catch (Exception ex)
            {
                Program.MouseNormal();
                Program.ShowError(ex);
            }
        }

        private void SendToPat()
        {

            // Save Current Version before sending to PAT
            if (!LobHeader.SaveCurrentVersion(header))
            {
                MessageBox.Show(header.ErrorMsg);
                return;
            }

            //SendToPAT(true);
            ClsPATLoadList pat = new ClsPATLoadList();
            pat.SendToPAT(true, header, header.Voyage_No);
            if (pat.HasErrors)
                Program.Show(pat.Error);
            else
                Program.Show("Success");
        }

        private void TestPat()
        {
            //SendToPAT(false);
            ClsPATLoadList pat = new ClsPATLoadList();
            pat.SendToPAT(false, header, header.Voyage_No);
            if (pat.HasErrors)
                Program.Show(pat.Error);
            else
                Program.Show("Success");
        }

        private void AddDeletedToLob()
        {
            try
            {
                var araD = grdLobRemoved.GetCheckedRows();
                LobDetailExtract de;
                if (araD.Length < 1)
                {
                    MessageBox.Show("Please select a row to add to Load-on-board-list.");
                    return;
                }

                foreach (GridEXRow d in araD)
                {
                    de = (LobDetailExtract)d.DataRow;

                    LobHeader.AddDeletedDetail(header, de);
                }

                // It is probably best just to load it again from the database ...
                //header = LobHeader.LoadVersionFromDatabase((long)header.Lob_Header_ID, extract);

                grdLOB.Refresh();
                grdLobRemoved.Refresh();

                SetForm();
                
                MessageBox.Show("Success");

            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }

        /// <summary>
        /// Shows the difference between the ACMS data extract and ArcSys LobDetail
        /// </summary>
        /// <param name="acms"></param>
        /// <param name="arcsys"></param>
        private void ShowCompare(string acms, string arcsys)
        {
            using (frmLOBShowCompare sc = new frmLOBShowCompare())
            {
                sc.ShowOpen(acms, arcsys);
            }
        }

        private void SetWindowState()
        {

            switch (header.LobState)
            {
                case 1:
                    tsbNewRow.Enabled = tsbDeleteRow.Enabled = tsbSave.Enabled = tsbCreateNew.Enabled = tsbDelete.Enabled = tsbSentToPat.Enabled = tsbTestPat.Enabled = tsbAddtoLoadList.Enabled  = false;
                    tsbLoad.Enabled = true;
                    break;
                case 2:
                    tsbNewRow.Enabled = tsbDeleteRow.Enabled = tsbSave.Enabled = tsbDelete.Enabled = tsbSentToPat.Enabled = tsbTestPat.Enabled = tsbAddtoLoadList.Enabled= false;
                    tsbCreateNew.Enabled = tsbLoad.Enabled = true;
                    break;
                case 3:
                    tsbCreateNew.Enabled = false;
                    tsbNewRow.Enabled = tsbDeleteRow.Enabled = tsbSave.Enabled = tsbLoad.Enabled = tsbDelete.Enabled = tsbSentToPat.Enabled = tsbTestPat.Enabled = tsbAddtoLoadList.Enabled = true;
                    break;
            }
			tsbSentToPat.Enabled = tsbTestPat.Enabled = true;
        }

        private void DeleteVersion()
        {
            string v = header.Title;

            if (LobHeader.DeleteVersionFromDatabase(header))
            {
                MessageBox.Show( string.Format("Load-on-Board-List '{0}' has been deleted.", v));
                this.Close();
            }
            else
            {
                MessageBox.Show( string.Format("Could not delete Load-on-board-list '{0}' ... {1}", v, header.ErrorMsg));
            }
        }

        #endregion

        #region Event Handlers

        private void grdLOB_LinkClicked(object sender, ColumnActionEventArgs e)
        {
            if (e.Column.Key == "NumberOfErrors")
            {
                var de = (LobDetailExtract)grdLOB.CurrentRow.DataRow;
                MessageBox.Show(de.ErrorMsg);
            }
        }

        private void grdLOB_FormattingRow(object sender, RowLoadEventArgs e)
        {
            GridEXFormatStyle ErrorStyle = new GridEXFormatStyle() { BackColor = Color.Red, ForeColor = Color.White };
            GridEXFormatStyle NormalStyle = new GridEXFormatStyle() { BackColor = Color.White, ForeColor = Color.Black };

            var de = (LobDetailExtract)e.Row.DataRow;

            if (de.IsNotNull())
            {
                e.Row.Cells["NumberOfErrors"].FormatStyle = ( de.NumberOfErrors > 0) ? ErrorStyle : NormalStyle;
                //e.Row.Cells["lobDetail.cargo_status"].FormatStyle = (l.cargo_status_compare) ? NormalStyle : ErrorStyle;
                //e.Row.Cells["lobDetail.van_type"].FormatStyle = (l.van_type_compare) ? NormalStyle : ErrorStyle;
                e.Row.Cells["lobDetail.tcn"].FormatStyle = (de.tcn_compare) ? NormalStyle : ErrorStyle;
                e.Row.Cells["lobDetail.container_no"].FormatStyle = (de.container_no_compare) ? NormalStyle : ErrorStyle;
                //e.Row.Cells["lobDetail.consignor_dodaac"].FormatStyle = (de.consignor_compare) ? NormalStyle : ErrorStyle;
                //e.Row.Cells["lobHeader.voyage_no"].FormatStyle = (de.voyage_compare) ? NormalStyle : ErrorStyle;
                e.Row.Cells["lobDetail.pod_location_cd"].FormatStyle = (de.pod_location_cd_compare) ? NormalStyle : ErrorStyle;
                //e.Row.Cells["lobDetail.booking_no"].FormatStyle = (de.booking_no_compare) ? NormalStyle : ErrorStyle;
                //e.Row.Cells["lobDetail.pcfn"].FormatStyle = (de.pcfn_compare) ? NormalStyle : ErrorStyle;
                e.Row.Cells["lobDetail.vessel_status_cd"].FormatStyle = (de.vessel_status_cd_compare) ? NormalStyle : ErrorStyle;
                //e.Row.Cells["lobDetail.consignee_dodaac"].FormatStyle = (de.consignee_compare) ? NormalStyle : ErrorStyle;
                //e.Row.Cells["lobDetail.cargo_dsc"].FormatStyle = (de.cargo_dsc_compare) ? NormalStyle : ErrorStyle;
                e.Row.Cells["lobDetail.length_nbr"].FormatStyle = (de.length_compare) ? NormalStyle : ErrorStyle;
                e.Row.Cells["lobDetail.width_nbr"].FormatStyle = (de.width_compare) ? NormalStyle : ErrorStyle;
                e.Row.Cells["lobDetail.height_nbr"].FormatStyle = (de.height_compare) ? NormalStyle : ErrorStyle;
                e.Row.Cells["lobDetail.weight_nbr"].FormatStyle = (de.weight_compare) ? NormalStyle : ErrorStyle;
                e.Row.Cells["lobDetail.comment_one"].FormatStyle = (de.comment_one_compare) ? NormalStyle : ErrorStyle;
                e.Row.Cells["lobDetail.comment_two"].FormatStyle = (de.comment_two_compare) ? NormalStyle : ErrorStyle;
                //e.Row.Cells["lobDetail.commodity_cd"].FormatStyle = (de.commodity_cd_compare) ? NormalStyle : ErrorStyle;
                //e.Row.Cells["lobDetail.rdd_dt"].FormatStyle = (de.rdd_compare) ? NormalStyle : ErrorStyle;                
                //e.Row.Cells["lobDetail.booked_flg"].FormatStyle = (de.booked_flg_compare) ? NormalStyle : ErrorStyle;
                //e.Row.Cells["lobDetail.si_flg"].FormatStyle = (de.si_flg_compare) ? NormalStyle : ErrorStyle;
                //e.Row.Cells["lobDetail.manifested_flg"].FormatStyle = (de.manifested_flg_compare) ? NormalStyle : ErrorStyle;
                //e.Row.Cells["lobDetail.vd_flg"].FormatStyle = (de.vd_flg_compare) ? NormalStyle : ErrorStyle;
                e.Row.Cells["lobDetail.bol_no"].FormatStyle = (de.bol_compare) ? NormalStyle : ErrorStyle;
           }

        }

        private void grdLOB_ColumnButtonClick(object sender, ColumnActionEventArgs e)
        {
            string s = string.Empty;
            var de = (LobDetailExtract)grdLOB.CurrentRow.DataRow;

            if (de.IsNotNull())
            {
                if (e.Column.Key == "NumberOfErrors")
                {
                    MessageBox.Show(de.ErrorMsg);
                    return;
                }
                
                if (de.lobExtract.IsNull())
                {
                    MessageBox.Show("Acms data extract does not exist ... can't compare.");
                    return;
                }

                if (de.lobDetail.IsNull())
                {
                    MessageBox.Show("ArcSys data does not exist ... can't compare.");
                    return;
                }

                switch (e.Column.Key)
                {
                    case "lobDetail.cargo_status":
                        ShowCompare(de.lobExtract.cargo_status, de.lobDetail.Cargo_Status);
                        break;
                    case "lobDetail.van_type":
                        ShowCompare(de.lobExtract.van_type, de.lobDetail.Van_Type);
                        break;
                    case "lobDetail.tcn":
                        ShowCompare(de.lobExtract.tcn, de.lobDetail.Tcn);
                        break;
                    case "lobDetail.container_no":
                        ShowCompare(de.lobExtract.container_no, de.lobDetail.Container_No);
                        break;
                    case "lobDetail.consignor_dodaac":
                        ShowCompare(de.lobExtract.consignor_dodaac, de.lobDetail.Consignor_Dodaac);
                        break;
                    case "lobDetail.pod_location_cd":
                        ShowCompare(de.lobExtract.pod_location_cd, de.lobDetail.Pod_Location_Cd);
                        break;
                    case "lobDetail.booking_no":
                        ShowCompare(de.lobExtract.booking_no, de.lobDetail.Booking_No);
                        break;
                    case "lobDetail.pcfn":
                        ShowCompare(de.lobExtract.pcfn, de.lobDetail.Pcfn);
                        break;
                    case "lobDetail.vessel_status_cd":
                        ShowCompare(de.lobExtract.vessel_status_cd, de.lobDetail.Vessel_Status_Cd);
                        break;
                    case "lobDetail.consignee_dodaac":
                        ShowCompare(de.lobExtract.consignee_dodaac, de.lobDetail.Consignee_Dodaac);
                        break;
                    case "lobDetail.cargo_dsc":
                        ShowCompare(de.lobExtract.cargo_dsc, de.lobDetail.Cargo_Dsc);
                        break;
                    case "lobDetail.length_nbr":
                        ShowCompare(de.lobExtract.length_nbr.ToString(), de.lobDetail.Length_Nbr.ToString());
                        break;
                    case "lobDetail.width_nbr":
                        ShowCompare(de.lobExtract.width_nbr.ToString(), de.lobDetail.Width_Nbr.ToString());
                        break;
                    case "lobDetail.height_nbr":
                        ShowCompare(de.lobExtract.height_nbr.ToString(), de.lobDetail.Height_Nbr.ToString());
                        break;
                    case "lobDetail.weight_nbr":
                        ShowCompare(de.lobExtract.weight_nbr.ToString(), de.lobDetail.Weight_Nbr.ToString());
                        break;
                    case "lobDetail.comment_one":
                        ShowCompare(de.lobExtract.comment_one, de.lobDetail.Comment_One);
                        break;
                    case "lobDetail.comment_two":
                        ShowCompare(de.lobExtract.comment_two, de.lobDetail.Comment_Two);
                        break;
                    case "lobDetail.commodity_cd":
                        ShowCompare(de.lobExtract.commodity_cd, de.lobDetail.Commodity_Cd);
                        break;
                    case "lobDetail.rdd_dt":
                        ShowCompare(de.lobExtract.rdd_dt.ToString(), de.lobDetail.Rdd_Dt.ToString());
                        break;
                    case "lobDetail.booked_flg":
                        ShowCompare(de.lobExtract.booked_flg, de.lobDetail.Booked_Flg);
                        break;
                    case "lobDetail.si_flg":
                        ShowCompare(de.lobExtract.si_flg, de.lobDetail.Si_Flg);
                        break;
                    case "lobDetail.manifested_flg":
                        ShowCompare(de.lobExtract.manifested_flg, de.lobDetail.Manifested_Flg);
                        break;
                    case "lobDetail.vd_flg":
                        ShowCompare(de.lobExtract.vd_flg, de.lobDetail.Vd_Flg);
                        break;
                    case "lobDetail.bol_no":
                        ShowCompare(de.lobExtract.cargo_bol_no, de.lobDetail.Bol_No);
                        break;
                }
            }
        }

        private void tsbNewRow_Click(object sender, EventArgs e)
        {
            New();
        }

        private void tsbDeleteRow_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            SaveCurrent();
        }

        private void tsbCreateNew_Click(object sender, EventArgs e)
        {
            SaveNew();
        }

        private void tsbLoad_Click(object sender, EventArgs e)
        {
            LoadCreate();
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            DeleteVersion();
        }

        private void tsbSentToPat_Click(object sender, EventArgs e)
        {
            SendToPat();
        }

        private void tsbTestPat_Click(object sender, EventArgs e)
        {
            TestPat();
        }

        private void tsbAddtoLoadList_Click(object sender, EventArgs e)
        {
            AddDeletedToLob();
        }

        /// <summary>
        /// This will handle Copy and Pasting from the Keyboard - Ctrl-C and Ctrl-V
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdLOB_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.Control) && (e.KeyCode == Keys.C))
                if (grdLOB.CurrentColumn.IsNotNull())
                {
                    Clipboard.SetDataObject(grdLOB.GetRow().Cells[grdLOB.CurrentColumn].Text);
                    return;
                }

            if ((e.Control) && (e.KeyCode == Keys.V))
            {
                grdLOB.GetRow().Cells[grdLOB.CurrentColumn].Value = Clipboard.GetText().Trim();
                return;
            }

        }

        #endregion
    }
}
