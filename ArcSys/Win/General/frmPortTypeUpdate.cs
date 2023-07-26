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
	public partial class frmPortTypeUpdate : Form
	{
		#region Properties
		private static frmPortTypeUpdate PortTypeUpdateWindow;
		protected string sVoyageID
		{
			get
			{
				string sVoyage = cmbVoyage.Value.ToString();
				return sVoyage;
			}
		}

		protected string sSeqNo
		{
			get
			{
				if( cmbPortType.Value == null )
					return "";
				string sPort = cmbPortType.Value.ToString();
				return sPort;
			}
		}
		protected string sType
		{
			get
			{
				string sType = cmbPortType.SelectedText;
				return sType;
			}
		}
		#endregion

		#region Init Methods
		public frmPortTypeUpdate()
		{
			InitializeComponent();
		}
		public static frmPortTypeUpdate ShowWindow()
		{
			try
			{
				if( PortTypeUpdateWindow == null )
				{
					PortTypeUpdateWindow = new frmPortTypeUpdate();
					PortTypeUpdateWindow.MdiParent = Program.MainWindow;
				}

				PortTypeUpdateWindow.Activate();
				PortTypeUpdateWindow.Show();
				PortTypeUpdateWindow.WindowState = FormWindowState.Maximized;

				PortTypeUpdateWindow.cmbVoyage.DataSource = ClsLineSQL.GetVoyages();
				PortTypeUpdateWindow.grdAudit.DataSource = ClsDatabaseExceptions.GetPortChangeLog();

				// Pass the application argument to connect to LINE
				ClsLineSQL.ConnectToLINE(Program.AppArg);
				return PortTypeUpdateWindow;
			}
			catch( Exception ex )
			{
				Program.ShowError(ex);
				return null;
			}
		}
		#endregion

		#region Helper Methods
		protected void RefreshData()
		{
			try
			{
				txtID.Text = sVoyageID;
				txtSeqNo.Text = sSeqNo;
			}
			catch( Exception ex )
			{
				Program.ShowError(ex);
			}

		}
		protected void UpdateDate()
		{
			try
			{
				string sPrevVoyage;
				string sPrevPort;
				string sPrevType;
				string sNewVoyage;
				string sNewPort;
				string sNewType = "B";

				// Get this voyage detail row information as it is
				// before the change
				DataRow dr = ClsLineSQL.GetVoyageDetail(sVoyageID, sSeqNo);
				sPrevVoyage = dr.ItemArray[3].ToString();
				sPrevPort = dr.ItemArray[6].ToString();
				sPrevType = dr.ItemArray[40].ToString();
				string sUser = ClsUser.CurrentUser.User_Login;

				//  Update the voyage detail row
				int iRC = ClsLineSQL.UpdatePortType(sVoyageID, sSeqNo, "B");
				cmbPortType.DataSource = ClsLineSQL.GetVoyagePortType(sVoyageID);
				if( iRC > 0 )
				{
					MessageBox.Show("Port has been updated");
				}
				else
				{
					MessageBox.Show("Update failed");
					return;
				}

				// Get this voyage detail row information as it is
				// AFTER the change
				dr = ClsLineSQL.GetVoyageDetail(sVoyageID, sSeqNo);
				sNewVoyage = dr.ItemArray[3].ToString();
				sNewPort = dr.ItemArray[6].ToString();
				sNewType = dr.ItemArray[40].ToString();
				ClsDatabaseExceptions.LogPortTypeChange(
					txtID.Text, txtSeqNo.Text, 
					sPrevVoyage,sPrevPort, sPrevType,
					sNewVoyage, sNewPort, sNewType,
					sUser);

				grdAudit.DataSource = ClsDatabaseExceptions.GetPortChangeLog();
			}
			catch( Exception ex )
			{
				MessageBox.Show(ex.Message);
			}
		}
		#endregion

		#region Events
		private void btnUpdate_Click(object sender, EventArgs e)
		{
			DialogResult dr =
				MessageBox.Show(@"This will change the selected port to type 'Both' and cannot be undone","Warning",
					MessageBoxButtons.OKCancel);
			if( dr == DialogResult.OK )
				UpdateDate();
			else
				MessageBox.Show("Action cancelled by user");
						
		}
		private void frmPortTypeUpdate_FormClosed(object sender, FormClosedEventArgs e)
		{
			PortTypeUpdateWindow = null;
		}

		private void cmbVoyages_ValueChanged(object sender, EventArgs e)
		{
			PortTypeUpdateWindow.cmbPortType.DataSource = ClsLineSQL.GetVoyagePortType(sVoyageID);
			PortTypeUpdateWindow.cmbPortType.SelectedIndex = -1;
			RefreshData();
			btnUpdate.Enabled = false;
		}

		private void cmbPortType_ValueChanged(object sender, EventArgs e)
		{
			RefreshData();
			btnUpdate.Enabled = true;
		}
		#endregion
	}
}