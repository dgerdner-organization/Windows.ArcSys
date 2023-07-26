using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CS2010.ArcSys.Business;
using CS2010.CommonWinCtrls;
using CS2010.ACMS.WinCtrls;

namespace CS2010.ArcSys.Win
{
    public partial class frmLOBAssembleDetail : Form
    {
        public frmLOBAssembleDetail()
        {
            InitializeComponent();
        }

        //private clsLOB _lob;
        private LobDetailExtract _de;

        public bool ShowOpen(LobDetailExtract de)
        {
            _de = de;
            Bind();
            this.ShowDialog();
            return (this.DialogResult == DialogResult.OK);
        }

        #region Private Methods

        private void Bind()
        {
            try
            {
                //LoadCommodityCode();
                
                //BindHelper.Bind(txtCargoStatus, _de.lobDetail, "Cargo_Status");
                BindHelper.Bind(txtBooking_no, _de.lobDetail, "Booking_No");
                BindHelper.Bind(txtCargo_dsc, _de.lobDetail, "Cargo_Dsc");
                BindHelper.Bind(txtComment_one, _de.lobDetail, "Comment_One");
                BindHelper.Bind(txtComment_two, _de.lobDetail, "Comment_Two");
                BindHelper.Bind(txtConsignee, _de.lobDetail, "Consignee_Dodaac");
                BindHelper.Bind(txtConsignor, _de.lobDetail, "Consignor_Dodaac");
                BindHelper.Bind(txtContainer_no, _de.lobDetail, "Container_No");
                //BindHelper.Bind(txtCube_nbr, _de.lobDetail, "Cube_Nbr");
                BindHelper.Bind(cmbVD_flg, _de.lobDetail, "Vd_Flg");
                BindHelper.Bind(cmbSI_flg, _de.lobDetail, "Si_Flg");
                BindHelper.Bind(cmbBooked, _de.lobDetail, "Booked_Flg");
                BindHelper.Bind(cmbManifested_flg, _de.lobDetail, "Manifested_Flg");
                BindHelper.Bind(txtHeight_nbr, _de.lobDetail, "Height_Nbr");
                BindHelper.Bind(txtWidth_nbr, _de.lobDetail, "Width_Nbr");
                BindHelper.Bind(txtLength_nbr, _de.lobDetail, "Length_Nbr");
                BindHelper.Bind(txtWeight_nbr, _de.lobDetail, "Weight_Nbr");
                //BindHelper.Bind(txtMTON_nbr, _de.lobDetail, "Mton_Nbr");
                BindHelper.Bind(txtPCFN, _de.lobDetail, "Pcfn");
                BindHelper.Bind(cmbPOD, _de.lobDetail, "Pod_Location_Cd");
                BindHelper.Bind(txtTCN, _de.lobDetail, "Tcn");
                cmbVessel_status_cd.DataBindings.Add("Text", _de.lobDetail, "Vessel_Status_Cd", true, DataSourceUpdateMode.OnPropertyChanged);
                //BindHelper.Bind(cmbVessel_status_cd, _de.lobDetail, "Vessel_Status_Cd");
                BindHelper.Bind(txtVan_type, _de.lobDetail, "Van_Type");
                BindHelper.Bind(cmbCommodityCode, _de.lobDetail, "Commodity_Cd");
                BindHelper.Bind(dtRdd_dt, _de.lobDetail, "Rdd_Dt");
                BindHelper.Bind(txtBOL, _de.lobDetail, "Bol_No");


            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
                this.btnOK.Enabled = false;
            }
        }

        private void LoadCommodityCode()
        {
            try
            {


                //cmbCommodityCode.DataSource = ACMS.Business.ClsDropDowns.CommodityDescriptions;
                //cmbCommodityCode.CodeColumn = "COMMODITY_CD";
                //cmbCommodityCode.DescriptionColumn = "COMMODITY_DSC";
                //cmbCommodityCode.DisplayMember = "COMMODITY_CD";
                //cmbCommodityCode.ValueColumn = "COMMODITY_CD";
                //cmbCommodityCode.ValueMember = "COMMODITY_CD";

                //cmbCommodityCode.DisplayMember = "COMMODITY_CD";
                //cmbCommodityCode.DescriptionColumn = "COMMODITY_DSC";
                //cmbCommodityCode.ValueColumn = "COMMODITY_CD";
                //cmbCommodityCode.ValueMember = "COMMODITY_CD";
                //cmbCommodityCode.DisplayType = ComboDisplay.CodeOnly;
                //DataTable dt = ACMS.Business.ClsDropDowns.CommodityDescriptions;

                //foreach (DataRow dr in dt.Rows)
                //    cmbCommodityCode.AddRow(dr[0].ToString(), dr);

            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }

        private void Validate()
        {
            try
            {

                //if (txtCargoStatus.Text.IsNull())
                //{
                //    MessageBox.Show("Cargo Status is not valid and is a required field.");
                //    return;
                //}

                if (txtTCN.Text.IsNull())
                {
                    MessageBox.Show("TCN is not valid and is a required field.");
                    return;
                }

                 if (cmbPOD.Text.IsNull())
                {
                    MessageBox.Show("POD is not valid and is a required field.");
                    return;
                }

                if (txtBooking_no.Text.IsNull())
                {
                    MessageBox.Show("Booking is not valid and is a required field.");
                    return;
                }

                if (cmbVessel_status_cd.Text.IsNull())
                {
                    MessageBox.Show("Vessel Status is not valid and is a required field.");
                    return;
                }

                if (txtCargo_dsc.Text.IsNull())
                {
                    MessageBox.Show("Cargo Description is not valid and is a required field.");
                    return;
                }

                if (txtLength_nbr.Text.IsNull())
                {
                    MessageBox.Show("Length is not valid and is a required field.");
                    return;
                }

                if (txtWidth_nbr.Text.IsNull())
                {
                    MessageBox.Show("Width is not valid and is a required field.");
                    return;
                }

                if (txtHeight_nbr.Text.IsNull())
                {
                    MessageBox.Show("Height is not valid and is a required field.");
                    return;
                }

                if (txtWeight_nbr.Text.IsNull())
                {
                    MessageBox.Show("Weight is not valid and is a required field.");
                    return;
                }

                // How can comments be required?  Leaving out for now.
                //txtComment_one.Text
                //txtComment_two.Text

                //if (cmbCommodityCode.Text.IsNull())
                //{
                //    MessageBox.Show("Commodity Code is not valid and is a required field.");
                //    return;
                //}

                if (dtRdd_dt.Text.IsNull())
                {
                    MessageBox.Show("RDD is not valid and is a required field.");
                    return;
                }

                if (cmbBooked.Text.IsNull())
                {
                    MessageBox.Show("Booked Flag is not valid and is a required field.");
                    return;
                }

                if (cmbManifested_flg.Text.IsNull())
                {
                    MessageBox.Show("Manifested Flag is not valid and is a required field.");
                    return;
                }

                if (cmbVD_flg.Text.IsNull())
                {
                    MessageBox.Show("Vessel Depart Flag is not valid and is a required field.");
                    return;
                }

                if (cmbSI_flg.Text.IsNull())
                {
                    MessageBox.Show("Shipping Instructions Flag is not valid and is a required field.");
                    return;
                }

                // The binding does not seem to work, whether I user the BindHelper or directly Data Bind ...
                _de.lobDetail.Vessel_Status_Cd = cmbVessel_status_cd.Text;

                this.DialogResult = DialogResult.OK;
                this.Close();

            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }

        private void Cancel()
        {
            try
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }

        #endregion

        #region Event Handlers

        private void btnOK_Click(object sender, EventArgs e)
        {
            Validate();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Cancel();
        }

        #endregion


    }
}
