using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Reflection;
using System.Xml.Serialization;
using System.IO;
using System.Net;

namespace JobScheduler
{
	public class ClsJob : ClsObjectBase
	{
		#region Properties
		public Decimal ID	{ get; set; }
		public string Name	{ get; set; }
		public string JobType_Code { get; set; }
		public string DestinationFolder{get; set; }
		public string ArkFolder { get; set; }
		public string InputFile { get; set; }
		public string EXEFile { get; set; }
		public string INIFile { get; set; }
		public string FTPurl { get; set; }
		public string FTPuser { get; set; }
		public string FTPpassword { get; set; }
		public string LogFile
		{
			get
			{
				string sLogName = this.Name;
				string sLogFolder = Program.LogFilesFolder;
				string sLog = string.Format("{0}{1}.log", sLogFolder, sLogName);
				return sLog;
			}
		}
		#endregion

		#region Methods
		public void ProcessJob()
		{
			if (this.JobType_Code.ToUpper() == JobType.ftpPut.ToUpper())
				ProcessftpPut();
			if (this.JobType_Code == JobType.MoveFile)
			    ProcessMoveJob();
			if (this.JobType_Code == JobType.CopyFile)
				ProcessCopyJob();
			if (this.JobType_Code == JobType.ExecuteApp)
				ProcessEXEJob();

			// If there is an archive folder designated, and an input file designated, move
			// the input file to the archive folder.  Of course, if the jobtype is "MOVE" 
			// you would ignore this.
			if (this.JobType_Code.ToUpper() != JobType.MoveFile.ToUpper())
			{
				if (!string.IsNullOrEmpty(this.ArkFolder))
				{
					this.DestinationFolder = this.ArkFolder;
					ProcessMoveJob();
				}
			}
		}

		public void ProcessMoveJob()
		{
			try
			{
				string Msg = string.Format("Moving file {0}", this.InputFile);
				if (!this.DestinationFolder.EndsWith("/"))
				{
					this.DestinationFolder = DestinationFolder + "/";
				}
				Program.jobSchedule.LogMessage(Msg, LogFile, LogType.LogFileOnly);
				string sFileName = Path.GetFileName(this.InputFile);
				string sDestination = DestinationFolder + sFileName;
				if (File.Exists(sDestination))
					File.Delete(sDestination);
				File.Move(this.InputFile, sDestination);
			}
			catch (Exception ex)
			{
				string x = ex.Message;
				Program.jobSchedule.LogMessage(ex.Message, LogFile, LogType.LogFileOnly);
			}
		}

		public void ProcessCopyJob()
		{
			try
			{
				string Msg = string.Format("Copying file {0}", this.InputFile);
				Program.jobSchedule.LogMessage(Msg, LogFile, LogType.LogFileOnly);
				string sFileName = Path.GetFileName(this.InputFile);
				if (!this.DestinationFolder.EndsWith(@"/"))
					sFileName = @"\" + sFileName;
				string sDestination = DestinationFolder + sFileName;
				if (File.Exists(sDestination))
					File.Delete(sDestination);
				File.Copy(this.InputFile, sDestination);
			}
			catch (Exception ex)
			{
				string x = ex.Message;
			}
		}

		public void ProcessEXEJob()
		{
			string Msg = string.Format("Processing file {0}", this.InputFile);
			Program.jobSchedule.LogMessage(Msg, LogFile, LogType.LogFileOnly);
			string sFileName = Path.GetFileName(this.InputFile);

			string sArguments = "";
			if (!string.IsNullOrEmpty(this.INIFile))
				sArguments = string.Format(@" -ini {0}", this.INIFile);
			sArguments = string.Format(@"{0} -f {1}", sArguments, this.InputFile);
			Program.jobSchedule.LaunchCommandLineApp(this.EXEFile, sArguments);
		}

		#region FTP Up
		public void ProcessftpPut()
		{
			try
			{
				string s = this.FTPurl;
				//using (WebClient client = new WebClient())
				//{
				//    client.Credentials = new NetworkCredential(this.FTPuser, this.FTPpassword);
				//    string sDestFile = this.FTPurl + string.Format(@"/") + Path.GetFileName(this.InputFile);
				//    byte[] bResult = client.UploadFile(sDestFile, this.InputFile);
				//    string x = "1";
				//}
				FTPUpload(this.FTPurl, this.InputFile, "Uploads", this.FTPuser, this.FTPpassword);
			}
			catch (Exception ex)
			{
				Program.jobSchedule.LogMessage(ex.Message, Program.ErrorLogFile, LogType.ErrorFileOnly);
				Program.jobSchedule.LogMessage(ex.Message, this.LogFile, LogType.LogAndPanel);
			}
		}
		protected void FTPUpload(string sURL, string sFullFileName, string sUploadFolder, string sUser, string sPWD)
		{
			//FTP Server URL.
			string ftp = sURL;

			//FTP Folder name. Leave blank if you want to upload to root folder.
			string ftpFolder = sUploadFolder + "/";

			byte[] fileBytes = null;

			//Read the FileName and convert it to Byte array.
			string fileName = Path.GetFileName(sFullFileName);
			using (StreamReader fileStream = new StreamReader(sFullFileName))
			{
				fileBytes = Encoding.UTF8.GetBytes(fileStream.ReadToEnd());
				fileStream.Close();
			}

			try
			{
				//Create FTP Request
				//[FTP Address] + "/" + [Filename of file to upload]

				string sFTP = "ftp://" + this.FTPurl + "/" + ftpFolder + Path.GetFileName(this.InputFile);
				FtpWebRequest request = (FtpWebRequest)WebRequest.Create(sFTP);
				request.Method = WebRequestMethods.Ftp.UploadFile;

				//Enter FTP Server credentials.
				request.Credentials = new NetworkCredential(sUser, sPWD);
				request.ContentLength = fileBytes.Length;
				request.UsePassive = true;
				request.UseBinary = true;
				request.ServicePoint.ConnectionLimit = fileBytes.Length;
				request.EnableSsl = false;

				using (Stream requestStream = request.GetRequestStream())
				{
					requestStream.Write(fileBytes, 0, fileBytes.Length);
					requestStream.Close();
				}

				FtpWebResponse response = (FtpWebResponse)request.GetResponse();

				//lblMessage.Text += fileName + " uploaded.<br />";
				response.Close();
			}
			catch (Exception ex)
			{
				string s = ex.Message;
				Program.jobSchedule.LogMessage(ex.Message, this.LogFile, LogType.LogAndPanel);
			}
		}
		#endregion
		#endregion



		#region Static Objects and Methods


		public static ClsJob GetByID(decimal lID)
		{
			//ClsJob job = new ClsJob();
			//string sql = string.Format("select ID, name as \"Name\", jobtype_code as \"JobType_Code\" from arc_owner.job where ID = {0}", lID);
			//job = (ClsJob) GetByPrimaryKey(sql, job);
			//return job;
			List<ClsJob> lj = GetAllRows();
			foreach (ClsJob j in lj)
			{
				if (j.ID == lID)
					return j;
			}
			return null;
		}

		public static List<ClsJob> GetAllRows()
		{
			List<ClsJob> listJob = new List<ClsJob>();
			XmlSerializer serialize = new XmlSerializer(typeof(List<ClsJob>));
			using (FileStream fs = new FileStream(Program.DataFilesFolder + "Jobs.xml", FileMode.Open, FileAccess.Read))
			{
				listJob = serialize.Deserialize(fs) as List<ClsJob>;
			}
			return listJob;
		}
		#endregion


	}

}
