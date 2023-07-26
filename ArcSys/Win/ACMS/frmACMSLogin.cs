using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CS2010.Common;
using CS2010.CommonWinCtrls;
using CS2010.ACMS.Business;

namespace CS2010.ArcSys.Win
{
	public partial class frmACMSLogin : frmDialogBase
	{
		public frmACMSLogin()
		{
			InitializeComponent();
			txtPassword.CharacterCasing = CharacterCasing.Normal;
			this.AcceptButton = null;

		}

		protected override bool CheckChanges()
		{
			try
			{
				string sPassword = txtPassword.Text;
				if (!Program.ConnectToACMS(sPassword))
				{
					Program.Show("Incorrect User Name or Password");
					return false;
				}
				// Try getting an ACMS object to make sure log was successful
				ClsBookingRequest.GetUsingKey(999, 999);
				Program.IsLoggedIntoACMS = true;
				return true;

			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
				return false;
			}
		}
		protected override bool SaveChanges()
		{
			if (!CheckChanges())
				return false;
			return true;
		}

	}
}
