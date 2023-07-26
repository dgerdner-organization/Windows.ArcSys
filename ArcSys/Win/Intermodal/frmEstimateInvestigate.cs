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


namespace CS2010.ArcSys.Win
{
    public partial class frmEstimateInvestigate : frmChildBase
    {
        #region Main Region
		protected string BookingNo
		{
			get
			{
				return txtBookingNo.Text;
			}
		}
		protected string InOut
		{
			get
			{
				if (rbInbound.Checked)
					return "I";
				return "O";
			}
		}
        public frmEstimateInvestigate()
        {
            InitializeComponent();
        }

        public void ShowForm()
        {
            this.Show();
            this.WindowState = FormWindowState.Maximized;
        }

        private void SetTitle(string AdditionalText)
        {
			this.Text = "Why don't I see my booking?";
        }
        #endregion

        #region Searching

        public void Search()
        {
			ClsEstimateSearch s = new ClsEstimateSearch();
			string sReason = s.EstimateInvestigate(BookingNo, InOut);
			Program.Show(sReason);
			if (s.dtCargoErrors != null)
				grdDetail.DataSource = s.dtCargoErrors;
        }


        #endregion

        #region Events
        private void tsSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        #endregion

		private void btnSearch_Click(object sender, EventArgs e)
		{
			Search();
		}

        private void btnUpdateSailDt_Click(object sender, EventArgs e)
        {
            //
            // Added this December 2021 so users (or support) can quickly
            // fix this common problem.
            //
            string sBooking = txtBookingNo.Text;
            try
            {
                if (string.IsNullOrWhiteSpace(sBooking))
                {
                    Program.Show("Enter a Booking Number First");
                    return;
                }
                ClsBookingLine bl = ClsBookingLine.GetByBookingNo(sBooking);
                if (bl == null)
                {
                    Program.Show("Booking number not found in t_booking_line");
                    return;
                }
                ClsVVoyage v = ClsVVoyage.GetByVoyageNo(bl.Voyage_No, false);
                if (v == null)
                {
                    string a = string.Format("Could not find voyage {0} ", bl.Voyage_No);
                    Program.Show(a);
                    return;
                }
                if (v.Sail_Dt == null)
                {
                    string a = string.Format("Cannot find a Sail Date for Voyage {0} ", bl.Voyage_No);
                    return;
                }
                bl.Sail_Dt = v.Sail_Dt;
                bl.Update();
                ClsBooking b = ClsBooking.FindByBookingNo(sBooking);
                if (b == null)
                {
                    Program.Show("Booking number not found in Intermodal system (t_booking)");
                    return;
                }
                b.Sail_Dt = v.Sail_Dt;
                b.Update();
                string bk = string.Format("Sail Date was updated to {0}. This booking should now be okay.", v.Sail_Dt);
                Program.Show(bk);
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }

    }
}