using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CS2010.CommonSecurity;
using CS2010.CommonWinCtrls;
using CS2010.Common;
using CS2010.ACMS.Business;
using CS2010.ArcSys.Business;
using Janus.Data;
using Janus.Windows.GridEX;

namespace CS2010.ArcSys.Win
{
    public partial class frmCompareBooking : frmChildBase
    {
        protected string BookingNo;
        protected string SerialNo;
        protected ClsVwArcBookingCargo OceanCargo;
        protected ClsVwArcBookingHeader OceanBooking;
        protected ClsBookingLine WHBooking;
        protected ClsCargoLine WHCargo;
        protected CS2010.ArcSys.Business.ClsBooking ILMSBooking;
        protected ClsCargo ILMSCargo;
        protected ClsBookingUnit ACMSCargo;

        public frmCompareBooking(string sBooking, string sSerialNo)
        {
            BookingNo = sBooking;
            SerialNo = sSerialNo;
            InitializeComponent();
            PopulateAll();
        }

        public void PopulateAll()
        {
            // From OCEAN System
            txtBooking.Text = BookingNo;
            txtSerialNo.Text = SerialNo;
            OceanCargo = ClsVwArcBookingCargo.GetForBookingSerialNo(BookingNo, SerialNo);
            OceanBooking = ClsVwArcBookingHeader.GetByBookingNo(BookingNo);
            if (OceanBooking != null)
            {
                txtPOL.Text = OceanBooking.Pol_Berth_Cd;
                txtPOD.Text = OceanBooking.Pod_Berth_Cd;
                txtVoyage.Text = OceanBooking.Voyage_No;
                txtPLOR.Text = OceanBooking.Plor_Cd;
                txtPLOD.Text = OceanBooking.Plod_Cd;
                txtBookingStatus.Text = OceanBooking.Status_Cd;
            }
            if (OceanCargo != null)
            {
                txtOSerialNo.Text = OceanCargo.Serial_No;
                txtCargoStatus.Text = OceanCargo.Status_Code;
                txtBolNo.Text = OceanCargo.Bol_No;
            }

            // From Warehouse
            WHBooking = ClsBookingLine.GetByBookingNo(BookingNo);
            WHCargo = ClsCargoLine.GetByBookingSerialNo(BookingNo, SerialNo);
            if (WHBooking != null)
            {
                txtWHPOL.Text = WHBooking.Pol_Berth;
                txtWHPOD.Text = WHBooking.Pod_Berth;
                txtWHVoyage.Text = WHBooking.Voyage_No;
                txtWHPLOR.Text = WHBooking.Plor_Location_Cd;
                txtWHPLOD.Text = WHBooking.Plod_Location_Cd;
                txtWHStatus.Text = WHBooking.Booking_Status;
                if (WHBooking.Deleted_Flg == "Y")
                    txtWHStatus.Text = "* DELETED *";

            }
            if (WHCargo != null)
            {
                txtWHCargoStatus.Text = WHCargo.Cargo_Status;
                txtWHSerialNo.Text = WHCargo.Serial_No;
                txtWHNotes.Text = WHCargo.Import_Notes_Txt;
                txtWHBolNo.Text = WHCargo.Bol_No;
            }


            // From ILMS
            ILMSBooking = CS2010.ArcSys.Business.ClsBooking.FindByBookingNo(BookingNo);
            ILMSCargo = CS2010.ArcSys.Business.ClsCargo.GetByBookingSerialNo(BookingNo, SerialNo);

            if (ILMSBooking != null)
            {
                txtILMSPOL.Text = ILMSBooking.Pol_Location_Cd;
                txtILMSPOD.Text = ILMSBooking.Pod_Location_Cd;
                txtILMSVoyage.Text = ILMSBooking.Voyage_No;
                txtILMSPLOR.Text = ILMSBooking.Plor_Location_Cd;
                txtILMSPLOD.Text = ILMSBooking.Plod_Location_Cd;
            }
            if (ILMSCargo != null)
            {
                txtILMSCargoStatus.Text = "na";
                txtILMSSerialNo.Text = ILMSCargo.Serial_No;
            }

            // From ACMS
            ACMSCargo = ClsBookingUnit.GetByTCN(BookingNo, SerialNo);
            if (ACMSCargo != null)
            {
                txtAPLOD.Text = ACMSCargo.Booking.Location_Plod_Cd;
                txtAPLOR.Text = ACMSCargo.Booking.Location_Plor_Cd;
                txtAPOD.Text = ACMSCargo.Pod_Terminal_Cd;
                txtAPOL.Text = ACMSCargo.Poe_Terminal_Cd;
                txtASCargoStatus.Text = "na";
                txtASerialNo.Text = ACMSCargo.Tcn;
                txtASTatus.Text = ACMSCargo.BookingRequest.Acms_Status_Cd;
                txtAVoyage.Text = ACMSCargo.Voyage_No;
            }
        }

        private void ucTextBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
