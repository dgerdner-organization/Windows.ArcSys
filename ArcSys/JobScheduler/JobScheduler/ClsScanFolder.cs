using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Reflection;
using System.IO;
using System.Threading;
using System.Xml.Serialization;
using System.ComponentModel;
using System.Runtime.Remoting.Messaging;

namespace JobScheduler
{
	public class ClsScanFolder : ClsObjectBase
	{
		private BackgroundWorker _BackGround;

		public Decimal ID { get; set; }
		public string FolderName { get; set; }
		public string BackupFolderName { get; set; }
		public Decimal JobID { get; set; }
		public Decimal ScanFrequency { get; set; }
		public TimeSpan SleepTime
		{
			get
			{
				Int32 seconds = Convert.ToInt32(ScanFrequency);
				TimeSpan ts = new TimeSpan(0, 0, seconds);
				return ts;
			}
		}
		public string LogFile
		{
			get
			{
				string sFolderNameOnly = this.FolderName.Replace("\\\\", ".");
				sFolderNameOnly = sFolderNameOnly.Replace("\\", ".");
				sFolderNameOnly = sFolderNameOnly.Replace("..", "");
				string sLogFolder = Program.LogFilesFolder;
				string sLog = string.Format("{0}{1}.log", sLogFolder, sFolderNameOnly);
				return sLog;
			}
		}
		private static List<ClsScanFolder> _AllScanFolders;
		public static List<ClsScanFolder> AllScanFolders
		{
			get
			{
				if (_AllScanFolders == null)
					_AllScanFolders = GetAllRows();
				return _AllScanFolders;
			}
		}
		public void ExecuteScan()
		{
			// Create a background worker thread that ReportsProgress &
			// SupportsCancellation
			// Hook up the appropriate events.
			_BackGround.DoWork += new DoWorkEventHandler(m_oWorker_DoWork);
			_BackGround.ProgressChanged += new ProgressChangedEventHandler
					(m_oWorker_ProgressChanged);
			_BackGround.RunWorkerCompleted += new RunWorkerCompletedEventHandler
					(m_oWorker_RunWorkerCompleted);
			_BackGround.WorkerReportsProgress = true;
			_BackGround.WorkerSupportsCancellation = true;

			while (true)
			{
				DoScan();
				if (Program.jobSchedule.bCancel)
					return;
				Thread.Sleep(this.SleepTime);
			}
		}
		public void ExecuteScanCallBack(IAsyncResult obj)
		{
		}

		public void DoScan()
		{
			// This is the main method
			string[] fileList = Directory.GetFiles(this.FolderName);
			string sMsg = string.Format("Found {0} files to process",  fileList.Length);
			if (fileList.Length < 1)
				return;
			try
			{
				Program.jobSchedule.LogMessage(sMsg, LogFile, LogType.LogAndPanel);
				foreach (string sFile in fileList)
				{
					if (Program.jobSchedule.bCancel)
						return;

					// Get the Job for this Scan
					ClsJob job = ClsJob.GetByID(this.JobID);

					// Get the file name, folder name, and backup folder so we can
					// a)backup the file, and b)call the associated job
					string sFileName = Path.GetFileName(sFile);
					sMsg = string.Format("  Processing Job:{0} | File:{1}", job.Name, sFileName);
					Program.jobSchedule.LogMessage(sMsg, LogFile, LogType.LogAndPanel);
					Program.jobSchedule.CopyFile(sFile, this.BackupFolderName, LogFile);
					job.InputFile = sFile;
					job.ProcessJob();
				}
			}

			catch (Exception ex)
			{
				Program.jobSchedule.LogMessage(ex.Message, Program.ErrorLogFile, LogType.ErrorFileOnly);
				throw ex;
			}
		
		}

		//public static ClsScanFolder GetByID(long? lID)
		//{
		//    ClsScanFolder ScanFolder = new ClsScanFolder();
		//    string sql = string.Format("select ID, FolderName as \"FolderName\", JobID as \"JobID\", ScanFrequency as \"ScanFrequency\" from arc_owner.scanfolder where ID = {0}", lID);
		//    ScanFolder = (ClsScanFolder)GetByPrimaryKey(sql, lID);
		//    return ScanFolder;
		//}

		public static DataTable GetAllRowsFromDB()
		{
			string sql = string.Format("select ID, FolderName as \"FolderName\", JobID as \"JobID\", ScanFrequency as \"ScanFrequency\" from arc_owner.scanfolder ");
			return GetAll(sql);
		}

		public static List<ClsScanFolder> GetAllRows()
		{
			List<ClsScanFolder> listScan = new List<ClsScanFolder>();
			XmlSerializer serialize = new XmlSerializer(typeof(List<ClsScanFolder>));
			using (FileStream fs = new FileStream(Program.DataFilesFolder + "ScanFolder.xml", FileMode.Open, FileAccess.Read))
			{
				listScan = serialize.Deserialize(fs) as List<ClsScanFolder>;
			}
			return listScan;
		}
		public ClsScanFolder FillFromDataRow(DataRow drow)
		{
			ClsScanFolder.LoadFromDataRow(drow, this);
			return this;
		}

		#region Background Worker Events
		void m_oWorker_DoWork(object sender, DoWorkEventArgs e)
		{
			// The sender is the BackgroundWorker object we need it to
			// report progress and check for cancellation.
			//NOTE : Never play with the UI thread here...
			for (int i = 0; i < 100; i++)
			{
				Thread.Sleep(100);

				// Periodically report progress to the main thread so that it can
				// update the UI.  In most cases you'll just need to send an
				// integer that will update a ProgressBar                    
				_BackGround.ReportProgress(i);
				// Periodically check if a cancellation request is pending.
				// If the user clicks cancel the line
				// m_AsyncWorker.CancelAsync(); if ran above.  This
				// sets the CancellationPending to true.
				// You must check this flag in here and react to it.
				// We react to it by setting e.Cancel to true and leaving
				if (_BackGround.CancellationPending)
				{
					// Set the e.Cancel flag so that the WorkerCompleted event
					// knows that the process was cancelled.
					e.Cancel = true;
					_BackGround.ReportProgress(0);
					return;
				}
			}

			//Report 100% completion on operation completed
			_BackGround.ReportProgress(100);
		}
		void m_oWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			// The background process is complete. We need to inspect
			// our response to see if an error occurred, a cancel was
			// requested or if we completed successfully.  
			if (e.Cancelled)
			{
				//lblStatus.Text = "Task Cancelled.";
			}

			// Check to see if an error occurred in the background process.

			else if (e.Error != null)
			{
				//lblStatus.Text = "Error while performing background operation.";
			}
			else
			{
				// Everything completed normally.
				//lblStatus.Text = "Task Completed...";
			}

			//Change the status of the buttons on the UI accordingly
			//btnStartAsyncOperation.Enabled = true;
			//btnCancel.Enabled = false;
		}
		void m_oWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{

			// This function fires on the UI thread so it's safe to edit
			// the UI control directly, no funny business with Control.Invoke :)
			// Update the progressBar with the integer supplied to us from the
			// ReportProgress() function.  

		}

		#endregion


	}

}
