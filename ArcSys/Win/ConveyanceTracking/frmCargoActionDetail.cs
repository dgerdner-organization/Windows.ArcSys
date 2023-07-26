using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CS2010.CommonWinCtrls;
using CS2010.ArcSys.Business;

namespace CS2010.ArcSys.Win
{
    public partial class frmCargoActionDetail : Form
    {

        #region Fields

        //DataRow _drCargoMove;
        ClsCargoMove _CargoMove;

        #endregion

        #region Init

        public frmCargoActionDetail()
        {
            InitializeComponent();
        }        

        #endregion

        #region Public Methods

        public void ShowForm(ClsCargoMove CargoMove)
        {
            _CargoMove = CargoMove;
            Bind();
            this.ShowDialog();
        }

        #endregion

        #region Private Methods

        private void Bind()
        {
            try
            {
                txtSerialNo.DataBindings.Add("Text", _CargoMove, "Serial_No", true, DataSourceUpdateMode.OnPropertyChanged);
                txtCustomsClearanceDt.DataBindings.Add("Text", _CargoMove, "Customs_Clearance_Dt", true, DataSourceUpdateMode.OnPropertyChanged);
                txtTagNo.DataBindings.Add("Text", _CargoMove, "Tag_No", true, DataSourceUpdateMode.OnPropertyChanged);
                txtCommissionDt.DataBindings.Add("Text", _CargoMove, "Tag_Commission_Dt", true, DataSourceUpdateMode.OnPropertyChanged);
                txtDecommissionDt.DataBindings.Add("Text", _CargoMove, "Tag_Decommission_Dt", true, DataSourceUpdateMode.OnPropertyChanged);
                txtInGateDt.DataBindings.Add("Text", _CargoMove, "In_Gate_Dt", true, DataSourceUpdateMode.OnPropertyChanged);
                txtDeliveryDt.DataBindings.Add("Text", _CargoMove, "Delivery_Dt", true, DataSourceUpdateMode.OnPropertyChanged);
                txtBookingNo.DataBindings.Add("Text", _CargoMove, "Booking_No", true, DataSourceUpdateMode.OnPropertyChanged);
                txtCustomerRef.DataBindings.Add("Text", _CargoMove, "Customer_Ref", true, DataSourceUpdateMode.OnPropertyChanged);
                txtVessel.DataBindings.Add("Text", _CargoMove,"Vessel_Cd", true, DataSourceUpdateMode.OnPropertyChanged);
                txtVoyage.DataBindings.Add("Text", _CargoMove, "Voyage_No", true, DataSourceUpdateMode.OnPropertyChanged);

                grdCargo.DataSource = _CargoMove.CargoActions;
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }

        #endregion

    }
}
