using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Threading;
using System.Xml.Serialization;
using System.IO;

namespace JobScheduler
{
	public partial class frmMain : Form
	{
		private string sPublicMsg;
		public delegate void serviceGUIDelegate();
		public void updateGUI(string s)
		{
			sPublicMsg = s;
			this.Invoke(new serviceGUIDelegate(LogMessage));
		}
		ClsJobScheduler j
		{ get { return Program.jobSchedule; } }
		StringBuilder sbLog;
		public string sLog
		{
			get { return sbLog.ToString(); }
		}
		public frmMain()
		{
			InitializeComponent();
			sbLog = new StringBuilder();
			this.grdScanFolders.DataSource = ClsScanFolder.AllScanFolders;
			this.grdJobs.DataSource = ClsJob.GetAllRows();
		}

		public void LogMessage()
		{
			sbLog.AppendLine(sPublicMsg);
			txtLog.Text = sbLog.ToString();
		}
		public void LogMessage(string sMsg)
		{
			sbLog.AppendLine(sMsg);
			txtLog.Text = sbLog.ToString();
		}
		private void SetButtons(bool bStart)
		{
			button1.Enabled = bStart;
			button2.Enabled = !bStart;
			Program.jobSchedule.bCancel = false;
			if (!bStart)
			{
				LogMessage("All jobs are now running...");
			}
			else
			{
				LogMessage("All jobs have been stopped.");
			}
		}
		private void button1_Click(object sender, EventArgs e)
		{
			try
			{
				j.LaunchAllJobs();
				SetButtons(false);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				SetButtons(false);
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Program.jobSchedule.bCancel = true;
			SetButtons(true);
		}

		private void button3_Click(object sender, EventArgs e)
		{
			//// Create some rows
			//List<ClsScanFolder> listScan = new List<ClsScanFolder>();
			//ClsScanFolder s = new ClsScanFolder();
			//s.ID = 1;
			//s.JobID = 1;
			//s.FolderName = "\\commserver01\\in_out\\storc\\in";
			//s.ScanFrequency = 30;
			//listScan.Add(s);
			//s.ID = 2;
			//s.FolderName = "\\commserver01\\in_out";
			//s.ScanFrequency = 90;
			//listScan.Add(s);
			//XmlSerializer serialize = new XmlSerializer(typeof(List<ClsScanFolder>));
			//using (FileStream fs = new FileStream(Environment.CurrentDirectory + "\\ScanFolder.xml", FileMode.Create, FileAccess.Write))
			//{
			//    serialize.Serialize(fs,listScan);
			//    MessageBox.Show("Data created");
			//}

			// Create some rows
			List<ClsJob> lj = new List<ClsJob>();
			ClsJob j = new ClsJob();
			j.ID = 5;
			j.Name = "300 Input";
			j.JobType_Code = "EXE";
			lj.Add(j);
			XmlSerializer serialize = new XmlSerializer(typeof(List<ClsJob>));
			using (FileStream fs = new FileStream(Environment.CurrentDirectory + "\\Jobs.xml", FileMode.Create, FileAccess.Write))
			{
				serialize.Serialize(fs, lj);
				MessageBox.Show("Data created");
			}
		}
	}
}
