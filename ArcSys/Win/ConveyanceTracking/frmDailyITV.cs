using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CS2010.Common;
using CS2010.CommonWinCtrls;
using CS2010.ArcSys.Business;
using CS2010.CommonSecurity;

namespace CS2010.ArcSys.Win
{
	public partial class frmDailyITV : frmChildBase
	{
		#region Form
		protected bool bImport;


		public frmDailyITV()
		{
			InitializeComponent();
		}

		public void ShowForm(bool bimp)
		{
			bImport = bimp;
			this.Show();
			this.WindowState = FormWindowState.Maximized;
			InitForm();
		}


		public void InitForm()
		{
			try
			{
				cmbPartner.DataSource = ClsTradingPartner.GetAll();
				cmbPartner.SelectedIndex = 1;
				ClsSecurityMaster.SetSecurity(this, ClsEnvironment.User_Id.Value);
				if (bImport)
					this.Text = "Daily ITV Report - Import";
				else
					this.Text = "Daily ITV Report - Export";
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		#endregion

		private void btnSearch_Click(object sender, EventArgs e)
		{
			DataTable dtDailyITV = ClsCargoMove.GetDailyITV_AEJEA_to_AFCLN();
			grdDailyITV.DataSource = dtDailyITV;
		}

		private void grdDailyITV_FormattingRow(object sender, Janus.Windows.GridEX.RowLoadEventArgs e)
		{

		}
		


	}
}
