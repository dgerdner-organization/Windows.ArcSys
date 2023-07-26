using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CS2010.ArcSys.Win
{
	public partial class frmAcceptBooking : CS2010.CommonWinCtrls.frmDialogBase
	{
		public frmAcceptBooking()
		{
			InitializeComponent();
		}

		public string BookingNo
		{
			get { return txtBookingNo.Text; }
		}
		#region Public Methods

		public bool GetBookingNo(string sBookingNo)
		{
			try
			{
				txtBookingNo.Text = sBookingNo;
				return ShowDialog() == DialogResult.OK;
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
				return false;
			}
		}
		#endregion
	}
}
