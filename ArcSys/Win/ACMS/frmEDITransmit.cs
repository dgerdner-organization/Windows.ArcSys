using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CS2010.ACMS.Business;
using ASL.ARC.EDISQLTools;
using System.Diagnostics;

namespace CS2010.ArcSys.Win
{
	public partial class frmEDITransmit : CS2010.CommonWinCtrls.frmChildBase
	{
		DataTable dt300ToLine;
		DataTable dt301ToSDDC;
		DataTable dt315ToSDDC;

		//DataTable dt304AAL;
		DataTable dt304SDDC;

		public frmEDITransmit()
		{
			InitializeComponent();
			FormLoad();

		}
		
		protected StringBuilder sMsg;
		protected DataTable dtCheck;
		protected bool bErrors;

		#region Methods

		#endregion

		#region Transmit Methods
		private void btnTransmit_Click(object sender, EventArgs e)
		{
			TransmitAll();
		}
		private void TransmitAll()
		{
			// OBSOLETE
			//
			// This didn't work, because when we try to launch BAT files on guardianedge it will not
			// allow us to use the name of a server (ex: \\guardianedge\script.bat).  So now we just
			// launch the SDDCEDI.exe application, which looks for any EDI message that need to be
			// sent from ACMS and sends them.
			//
			 
			sMsg = new StringBuilder("Recap");
			try
			{
				if (cbx300ToLINE.Checked)
					Xmt300ACMS2LINE();
				if (cbx301ToSDDC.Checked)
					Xmt301ACMS2SDDC();
				if (cbx315ToSDDC.Checked)
					Xmt315ACMS2SDDC();
				if (cbxSDDC304.Checked)
					Xmt304SDDC2LINE();
				if (cbxAAL304.Checked)
					Xmt304AAL2LINE();
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
			finally
			{
				Program.Show(sMsg.ToString());
			}

		}

		private void LaunchSddcEDI()
		{
			int exitCode = 99;
			// Prepare the process to run
			ProcessStartInfo start = new ProcessStartInfo();
			// Enter the executable to run, including the complete path
			start.Arguments = "N Y";
			start.FileName = "\\\\guardianedge\\SDDCEDI\\CurrentVers\\SDDCEdi.exe";
			// Do you want to show a console window?
			start.WindowStyle = ProcessWindowStyle.Normal;
			start.CreateNoWindow = true;

			// Run the external process & wait for it to finish
			using (Process proc = Process.Start(start))
			{
				proc.WaitForExit();

				// Retrieve the app's exit code
				exitCode = proc.ExitCode;
			}
			Program.Show("Transmission Complete");
			this.Close();
		}
		private void Xmt300ACMS2LINE()
		{
			DataTable dt = ClsMapsAndFTP.BookingsForLine();
			sMsg.AppendLine("");
			sMsg.AppendLine("");
			sMsg.AppendFormat("{0} Bookings sent to LINE", dt.Rows.Count);
			EdiInfo edi = ClsMapsAndFTP.GetEDIInfo_LINE300();
			//if (dt.Rows.Count > 0)
			//{
				EdiInfo ediResult = ClsMapsAndFTP.RunOutboundMap(edi);
				string s = ediResult.File_Name;
			//}
		}

		private void Xmt304SDDC2LINE()
		{
			DataTable dt304Sddc = ClsAcmsSQL.Get304s();
			sMsg.AppendLine("");
			sMsg.AppendLine("");
			sMsg.AppendFormat("{0} SDDC Shipping Instructions sent to LINE", dt304Sddc.Rows.Count);
			if (dt304Sddc.Rows.Count > 0)
			{
			    EdiInfo edi = ClsMapsAndFTP.GetEDIInfo_SDDC304();
			    ClsMapsAndFTP.RunOutboundMap(edi);
			}
		}

		private void Xmt304AAL2LINE()
		{
			DataTable dt304AAL = clsClassSQL.Get304s();
			sMsg.AppendLine("");
			sMsg.AppendLine("");
			sMsg.AppendFormat("{0} AAL Shipping Instructions  transmitted", dt304AAL.Rows.Count);
			if (dt304AAL.Rows.Count > 0)
			{
				EdiInfo edi = ClsMapsAndFTP.GetEDIInfo_LINE304();
				ClsMapsAndFTP.RunOutboundMap(edi);
			}

		}

		private void Xmt301ACMS2SDDC()
		{
			// Find all Confirmations ready to transmit
			DataTable dt2 = ClsMapsAndFTP.Confirmations();
			sMsg.AppendLine("");
			sMsg.AppendLine("");
			sMsg.AppendFormat("{0} Confirmations transmitted to SDDC", dt2.Rows.Count);
			EdiInfo edi = ClsMapsAndFTP.GetEDIInfo_SDDC301();
			if (dt2.Rows.Count > 0)
			{
				edi = ClsMapsAndFTP.RunOutboundMap(edi);
				dtCheck = ClsMapsAndFTP.Confirmations();
				if (dtCheck.Rows.Count > 0)
				{
					bErrors = true;
				}

			}
			// Run the FTP no matter what (to sweep up any that might have
			// failed from an earlier run
			//
			ClsMapsAndFTP.FTPFile("SDDC", edi.File_Path, "301OUT");
		}

		private void Xmt315ACMS2SDDC()
		{
			// Find all ITV ready to transmit
			//
			System.Console.WriteLine(sMsg.ToString());
			
			MapFtpInfo mapinfo = ClsMapsAndFTP.ReadyToTransmitITV();
			DataTable dt1 = mapinfo.dtReturn;
			if (dt1 != null)
			{
				sMsg.AppendLine("");
				sMsg.AppendFormat("{0} EDI ITV messages transmitted to SDDC", dt1.Rows.Count);
			}

			// If any are found, run the MAP
			EdiInfo edi = ClsMapsAndFTP.GetEDIInfo_SDDC315();
			if (dt1.Rows.Count > 0)
			{
				edi = ClsMapsAndFTP.RunOutboundMap(edi);
			}

		}

		#endregion
		
		#region Background 1

		private void CheckOthers()
		{
			try
			{
				progressBar1.Visible = true;
				groupOther.Enabled = btnTransmit.Enabled =  false;
				backgroundWorker1.RunWorkerAsync();
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
		{
			GetBookingsCount();
		}
		private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			progressBar1.Visible = false;
			progressBar1.Value = 0;
			groupOther.Enabled = btnTransmit.Enabled =  true;
			txt300ToLINE.Text = dt300ToLine.Rows.Count.ToString();
			txt301ToSDDC.Text = dt301ToSDDC.Rows.Count.ToString();
			txt315ToSDDC.Text = dt315ToSDDC.Rows.Count.ToString();
		}
		private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			progressBar1.Value = e.ProgressPercentage;
		}
		void GetBookingsCount()
		{
			dt300ToLine = ClsMapsAndFTP.BookingsForLine();
			backgroundWorker1.ReportProgress(33);
			dt301ToSDDC = ClsMapsAndFTP.Confirmations();
			backgroundWorker1.ReportProgress(66);
			dt315ToSDDC = ClsMapsAndFTP.ReadyToTransmitITV().dtReturn;
			backgroundWorker1.ReportProgress(100);
		}
		#endregion

		#region Background 2
		private void FormLoad()
		{
			string sMsg = string.Format(@"We send and receive EDI transmissions between ACMS and our trading partners automatically every 10 minutes.  This window allows you to automatically send and receive all EDI messages that are ready without waiting for the next scheduled run.");
			txtMessage.Text = sMsg;
			try
			{
				progressBar1.Visible = true;
				backgroundWorker2.RunWorkerAsync();
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}
		private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
		{
			backgroundWorker2.ReportProgress(25);
			//dt304AAL = clsClassSQL.Get304s();
			backgroundWorker2.ReportProgress(50);
			dt304SDDC = ClsAcmsSQL.Get304s();

			backgroundWorker2.ReportProgress(75);
		}
		private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			//txt304AAL.Text = dt304AAL.Rows.Count.ToString();
			txt304SDDC.Text = dt304SDDC.Rows.Count.ToString();
			progressBar1.Visible = false;
			progressBar1.Value = 0;
			groupOther.Enabled = btnTransmit.Enabled = true;
			CheckOthers();
		}

		private void backgroundWorker2_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			progressBar1.Value = e.ProgressPercentage;
		}
		#endregion

		#region Events
		private void ucButton1_Click(object sender, EventArgs e)
		{
			LaunchSddcEDI();
		}

		private void txtMessage_TextChanged(object sender, EventArgs e)
		{

		}
		#endregion
	}
}
