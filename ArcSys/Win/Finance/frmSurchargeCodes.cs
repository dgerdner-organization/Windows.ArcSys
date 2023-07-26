using System;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;
using CS2010.Common;
using CS2010.CommonWinCtrls;
using ASL.ARC.EDISQLTools;
using Janus.Windows.GridEX;
using System.Reflection;
using CS2010.ArcSys.Business;

namespace CS2010.ArcSys.Win
{
	public partial class frmSurchargeCodes : Form
	{
		#region Fields and Properties
		private DataTable dtCodes;
		private string CurrentMode = UpdateMode;

		private const string UpdateMode = "Update";
		private const string AddMode = "Add";

		private ClsSddcSurcharge CurrentItem
		{
			get
			{
				DataRow dr = grdCodes.GetDataRow();
				string s = dr["line_charge_cd"].ToString();
				ClsSddcSurcharge lc = ClsSddcSurcharge.GetUsingKey(s);
				return lc;
			}
		}
		#endregion

		#region Main Methods
		public frmSurchargeCodes()
		{
			InitializeComponent();
			this.Activate();
			this.MdiParent = Program.MainWindow;
			this.WindowState = FormWindowState.Maximized;

			dtCodes = ClsSddcSurcharge.GetAll();

			grdCodes.DataSource = dtCodes;
		}

		private void RefreshGrid()
		{
			dtCodes = ClsSddcSurcharge.GetAll();
			grdCodes.DataSource = dtCodes;
		}

		#endregion

		#region Insert and Update
		private void UpdateItem()
		{
			ClsSddcSurcharge lc = CurrentItem;
			lc.Sddc_Charge_Cd = txtSDDC.Text;
			lc.Update();
			RefreshGrid();
			CurrentMode = UpdateMode;
			grdCodes.Enabled = true;
		}

		private void InsertItem()
		{
			ClsSddcSurcharge lc = new ClsSddcSurcharge();
			lc.Line_Charge_Cd = txtLINE.Text;
			lc.Sddc_Charge_Cd = txtSDDC.Text;
			lc.Insert();
		}

		private void ucButton1_Click(object sender, EventArgs e)
		{
			try
			{
				if (CurrentMode == UpdateMode)
					UpdateItem();
				else
					InsertItem();

				RefreshGrid();
				grdCodes.Enabled = true;
				CurrentMode = UpdateMode;
				btnDelete.Enabled = true;
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void btnNew_Click(object sender, EventArgs e)
		{
			CurrentMode = AddMode;
			grdCodes.Enabled = false;
			txtSDDC.Text = "";
			txtLINE.Text = "";
			btnDelete.Enabled = false;
		}

		#endregion

		#region Events
		private void grdCodes_SelectionChanged(object sender, EventArgs e)
		{
			txtLINE.Text = CurrentItem.Line_Charge_Cd;
			txtSDDC.Text = CurrentItem.Sddc_Charge_Cd;
		}
		#endregion

		private void btnDelete_Click(object sender, EventArgs e)
		{
			if (CurrentMode == AddMode)
				return;

			ClsSddcSurcharge lc = CurrentItem;
			string sMsg = string.Format("Delete Code {0}?", lc.Line_Charge_Cd);
			DialogResult dr = MessageBox.Show(sMsg, "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
			if (dr == DialogResult.OK)
			{
				lc.Delete();
				RefreshGrid();
			}
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			RefreshGrid();
			CurrentMode = UpdateMode;
		}

	}
}
