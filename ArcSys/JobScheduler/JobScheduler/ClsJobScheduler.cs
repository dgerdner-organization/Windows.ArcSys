using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Diagnostics;
using System.Collections.Concurrent;
using System.ComponentModel;

namespace JobScheduler
{
	class ClsJobScheduler
	{
		public bool bCancel = false;

		public void LaunchAllJobs()
		{
			LaunchScanJobs();
		}

		delegate void delExecuteScan();

		public void LaunchScanJobs()
		{

			int ix = 0;

			foreach (ClsScanFolder f in ClsScanFolder.AllScanFolders)
			{
				ix++;
				if (ix > 5)
					continue;
				f.ExecuteScan();
			}

		}

		#region Log Messages
		public void LogMessage(string Msg, string LogFile, string sLogType)
		{
			StreamWriter sw = new StreamWriter(LogFile, true);
			try
			{
				string sELOg = Program.ErrorLogFile;
				Msg = string.Format("{0} {1}", DateTime.Now, Msg);
				if (sLogType == LogType.LogAndPanel || sLogType == LogType.LogFileOnly || sLogType == LogType.ErrorFileOnly)
				{
					sw.WriteLine(Msg);
				}
				sw.Close();
				sw.Dispose();
				if (sLogType == LogType.LogAndPanel)
					Program.MainWindow.updateGUI(Msg);

			}
			catch (Exception ex)
			{
				sw.Close();
				sw.Dispose();
			}
		}
		#endregion

		#region Copy File
		public void CopyFile(string sFullFileName, string sToFolderName, string sLogFile)
		{
			try
			{
				string sFileName = Path.GetFileName(sFullFileName);
				if (!sToFolderName.EndsWith(@"\"))
					sToFolderName = sToFolderName + string.Format(@"\");
				string sDestination = sToFolderName + sFileName;
				File.Copy(sFullFileName, sDestination,true);
			}
			catch (Exception ex)
			{
				LogMessage(ex.Message, sLogFile, LogType.LogAndPanel);
			}
		}
		#endregion

		#region Command Line Application launch
		/// <summary>
		/// Launch the legacy application with some options set.
		/// </summary>
		public void LaunchCommandLineApp(string sEXE, string sArgs)
		{
			// For the example

			// Use ProcessStartInfo class
			ProcessStartInfo startInfo = new ProcessStartInfo();
			startInfo.CreateNoWindow = true;
			startInfo.UseShellExecute = false;
			startInfo.FileName = sEXE;
			startInfo.Arguments = sArgs;
			startInfo.WindowStyle = ProcessWindowStyle.Hidden;
			startInfo.RedirectStandardOutput = true;
			startInfo.RedirectStandardError = true;
			startInfo.RedirectStandardInput = true;
			try
			{
				// Start the process with the info we specified.
				// Call WaitForExit and then the using statement will close.
				using (Process exeProcess = Process.Start(startInfo))
				{
					exeProcess.EnableRaisingEvents = true;
					exeProcess.OutputDataReceived += new DataReceivedEventHandler(OnOutputDataReceived);
					exeProcess.WaitForExit();
					string sOutPut = exeProcess.StandardOutput.ReadToEnd();
					string sError = exeProcess.StandardError.ReadToEnd();
					if (!String.IsNullOrEmpty(sError))
					{
						int iLength = sError.Length;
						if (iLength > 256)
							iLength = 256;
						Program.jobSchedule.LogMessage(sError.Substring(0,iLength),Program.ErrorLogFile, LogType.ErrorFileOnly);
					}
				}
			}
			catch (Exception ex)
			{
				Program.jobSchedule.LogMessage(ex.Message, Program.ErrorLogFile, LogType.ErrorFileOnly);
			}
		}
		private void OnOutputDataReceived(object sender, DataReceivedEventArgs e)
		{
			string s = e.Data;
		}
		#endregion
	}
}
