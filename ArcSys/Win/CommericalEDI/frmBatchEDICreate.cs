using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CS2010.ArcSys.Business;

namespace CS2010.ArcSys.Win
{
	public partial class frmBatchEDICreate : CS2010.CommonWinCtrls.frmChildBase
	{
		public frmBatchEDICreate()
		{
			InitializeComponent();
		}
		public void ShowForm()
		{
			MessagesForCAT();
			this.Show();
			this.WindowState = FormWindowState.Maximized;
		}

		#region CAT
		private void CreateCAT()
		{
			try
			{
				grdCATmsg.Visible = false;
				ClsCommercialEDICreate.CreateITV("CAT");
				MessagesForCAT();
				Program.Show("Create Complete");
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}
		private void MessagesForCAT()
		{
			DataTable dt = ClsCommercialEDIQueries.ReadyToTransmitMsg("CAT");
			grdCATmsg.DataSource = dt;
			if (dt.Rows.Count < 1)
			{
				lblCATmsg.Visible = true;
				grdCATmsg.Visible = false;
			}
			else
			{
				lblCATmsg.Visible = false;
				grdCATmsg.Visible = true;
			}
		}
		private void btnCreateCAT_Click(object sender, EventArgs e)
		{
			try
			{
				CreateCAT();
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void btnMap_Click(object sender, EventArgs e)
		{
			try
			{
				ClsCommercialEDICreate.RunMap("CAT", "ITVOUT");
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void btn323Map_Click(object sender, EventArgs e)
		{
			try
			{
				ClsCommercialEDICreate.RunMap("CAT", "323OUT");
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}
		#endregion

		#region NAC
		private void CreateNAC()
		{
			try
			{
				grdNACmsg.Visible = false;
				ClsCommercialEDICreate.CreateITV("NAC");
				MessagesForNAC();
				Program.Show("Create Complete");
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}
		private void MessagesForNAC()
		{
			DataTable dt = ClsCommercialEDIQueries.ReadyToTransmitMsg("NAC");
			grdNACmsg.DataSource = dt;
			if (dt.Rows.Count < 1)
			{
				lblNACmsg.Visible = true;
				grdNACmsg.Visible = false;
			}
			else
			{
				lblNACmsg.Visible = false;
				grdNACmsg.Visible = true;
			}
		}
		private void btnCreateNAC_Click(object sender, EventArgs e)
		{
			CreateNAC();
		}
		private void btnRunMapNAC315_Click(object sender, EventArgs e)
		{

		}
		#endregion





	}
}
