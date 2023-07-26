using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using Janus.Windows;
using Janus.Data;
using Janus.Windows.GridEX;
using CSAlpha.AVSS.Business;
using CS2008.AVSS.WinCtrls;
using CS2005.CommonWinCtrls;
using CS2008.Framework.Alpha;

namespace CS2008.AVSS.Win 
{
	public partial class frmUpdateVesselARC : CS2008.AVSS.Win.frmUpdateVessel
	{
		public frmUpdateVesselARC()
		{
			InitializeComponent();
		}

		public void ShowARC()
		{
			this.Show();
			ucGridToolStrip1.Visible = false;
		}

		private void tsARC_ClickAdd(object sender, EventArgs e)
		{
			AddTransshipment();
		}
		private void UpdateMilitaryVoyage()
		{
			string s = txtVoyage.Text;
			frmUpdateMilitaryVoyage frm = new frmUpdateMilitaryVoyage();
			frm.MdiParent = this.MdiParent;
			frm.UpdateVoyage(s);
		}

		private void tsARC_ClickEdit(object sender, EventArgs e)
		{
			UpdateMilitaryVoyage();
		}

		private void frmUpdateVesselARC_Load(object sender, EventArgs e)
		{

		}
	}
}

