using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Timers;
using CS2010.CommonWinCtrls;
using CS2010.ArcSys.Business;
using CS2010.Common;



namespace CS2010.ArcSys.Win
{
	public partial class frmViewBookingLINE : frmChildBase, IViewWindow
    {
        #region Main Region
		private ClsBookingLine theBooking;

        public frmViewBookingLINE(bool showModal) : base()
        {
			if (showModal == true)
			{
				MergeToolbar = null;
				MaximizeBox = false;
				ShowInTaskbar = false;
				FormBorderStyle = FormBorderStyle.FixedDialog;
			}
			else
				AdjustForm(Program.MainWindow, true, null);

			InitWindow();
            InitializeComponent();
        }

		private void InitWindow()
		{
			try
			{
				WindowHelper.InitAllGrids(this);
				//ClsSecurityMaster.SetSecurity(this, ClsEnvironment.User_Id.Value);

			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

        private void SetTitle(string AdditionalText)
        {
			this.Text = "Booking " + AdditionalText;
        }
        #endregion

        #region Searching
		private void ViewObject(ClsBookingLine aBooking)
		{
			try
			{
				theBooking = aBooking;
				if (theBooking == null)
				{
					Program.ShowError("No booking provided");
					return;
				}

				if (MdiParent == null)
				{
					Show();
					//ShowDialog();
				}
				else
					Show();
				SetTitle(theBooking.Booking_No);

				BindHelper.Bind(txtVesselNo, theBooking, "Vessel_Cd");
				BindHelper.Bind(txtVoyageNo, theBooking, "Voyage_No");
				BindHelper.Bind(txtDate, theBooking, "Booking_Dt");
				BindHelper.Bind(txtPLOR, theBooking, "Plor_Dsc");
				BindHelper.Bind(txtBookingRef, theBooking, "Booking_Ref");
				BindHelper.Bind(txtCustomerRef, theBooking, "Customer_Ref");
				BindHelper.Bind(txtEdIREF, theBooking, "Edi_Ref");
				BindHelper.Bind(txtPLOD, theBooking, "Plod_Dsc");
				BindHelper.Bind(txtPOD, theBooking, "Pod_Dsc");
				BindHelper.Bind(txtPOL, theBooking, "Pol_Dsc");
				BindHelper.Bind(txtRDD, theBooking, "Rdd_Dt");
				BindHelper.Bind(txtSailDt, theBooking, "Sail_Dt");
				BindHelper.Bind(txtCustomerNm, theBooking, "Customer_Nm");
				BindHelper.Bind(txtBookingStatus, theBooking, "Booking_Status");
				BindHelper.Bind(txtTariff, theBooking, "Tariff_Cd");
				BindHelper.Bind(txtMoveType, theBooking, "Move_Type_Cd");
				BindHelper.Bind(txtPOLBerth, theBooking, "Pol_Berth");
				BindHelper.Bind(txtPODBerth, theBooking, "Pod_Berth");

				if (string.IsNullOrEmpty(theBooking.Booking_No))
					lblNotFound.Visible = true;
				else
					lblNotFound.Visible = false;

				if (theBooking.Deleted_Flg == "Y")
					lblDeleted.Visible = true;
				else
					lblDeleted.Visible = false;

				grdDetail.DataSource = theBooking.BookingCargo;
				SearchLINEdb();
			}
			catch (Exception ex)
			{
				Program.ShowError(ex, theBooking);
			}
		}

        public void SearchCargo(ClsCargo Cargo)
        {

        }

		public void SearchLINEdb()
		{
            //
            // April 2020 : This now looks for Ocean Data instead of LINE
            //
            //Program.ConnectToLINE();
            //DataRow drow = ASL.ARC.EDISQLTools.ClsLineSQL.GetBookingByPCFN(theBooking.Customer_Ref);
            //if (drow == null)
            //{
            //    txtLINEEDIRef.Text = "Not found in LINE";
            //    return;
            //}
            //txtLineBookingNo.Text = drow["bu1bunr"].ToString();
            //txtLINEStatus.Text = drow["bu1status2"].ToString();
            //txtLINEEDIRef.Text = drow["bu1ediref"].ToString();
            //txtLINECustREf.Text = drow["bu1kdref"].ToString();

            ClsVwArcBookingHeader obk = ClsVwArcBookingHeader.GetByBookingNo(theBooking.Booking_No);
            if (obk.IsNull())
            {
                txtLINECustREf.Text = "Not found in OCEAN";
                return;
            }
            txtLineBookingNo.Text = obk.Booking_No;
            txtLINEStatus.Text = obk.Status_Cd;
            txtLINEEDIRef.Text = obk.Pcfn;
            txtLINECustREf.Text = obk.Customer_Name;
		}

        #endregion


		#region IViewWindow Interface Implementation

		public ClsBaseTable TableObject
		{
			get { return theBooking; }
		}

		public void ViewObject(ClsBaseTable bizObject)
		{
			ViewObject(bizObject as ClsBookingLine);
		}

		public void UpdateDisplay()
		{
		}

		#endregion		// #region IViewWindow Interface Implementation

        private void btnOceanView_Click(object sender, EventArgs e)
        {
            frmLINEQuery frm = new frmLINEQuery(theBooking.Booking_No);
            frm.MdiParent = Program.MainWindow;
            frm.Show();
        }
        #region Events

        #endregion

               

    }
}