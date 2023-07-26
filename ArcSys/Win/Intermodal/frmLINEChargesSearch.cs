using System;
using System.Data;
using System.Text;
using System.Windows.Forms;
using CS2010.Common;
using CS2010.CommonWinCtrls;
using CS2010.CommonSecurity;
using CS2010.ArcSys.Business;

namespace CS2010.ArcSys.Win
{
	public partial class frmLINEChargesSearch : frmDialogBase
	{
		#region Vars and Props

        public string BOOKING_NO 
        {
            get
            {
                return txtBooking.Text.Trim();
            }
        }

		#endregion

		#region Init

        public frmLINEChargesSearch()
		{
			InitializeComponent();
		}

		#endregion

        #region Public Methods

        public void EntryPoint()
        {
            try
            {
                txtBooking.Focus();
                this.ShowDialog();
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
                this.DialogResult = DialogResult.Cancel;
            }
        }

        #endregion

        #region Private Methods

        private bool Validation()
        {
            try
            {
                if (txtBooking.Text.IsNull())
                {
                    Program.Show("Booking '{0}' is not valid.", txtBooking.Text);
                    return false;
                }

                if (ClsBooking.FindByBookingNo(txtBooking.Text) == null)
                {
                    Program.Show("Booking '{0}' does not exist in the Intermodal System.", txtBooking.Text);
                    return false;
                }

                return true;
            }
            catch 
            {   Program.Show("Booking '{0}' is not valid.", txtBooking.Text);
                return false;
            }
        }

        #endregion

        #region Event Handlers

        private void btnClear_Click(object sender, EventArgs e)
		{
			WindowHelper.ClearAllControls(this);
		}

		#endregion

		#region Override

        protected override bool CheckChanges()
        {
            return Validation();
        }

		#endregion
	}
}
