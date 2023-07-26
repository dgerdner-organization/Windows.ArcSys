using System;
using System.Data;
using System.Text;
using System.Threading;
using System.Reflection;
using System.Configuration;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Diagnostics;
using CS2010.Common;
using CS2010.ArcSys.Business;
using ASL.ARC.EDISQLTools;

namespace CS2010.ACMS.Business
{
	public class ClsMapsAndFTP
	{
		#region Connection Manager

		protected static ClsConnection Connection
		{
			get { return ClsConMgr.Manager["ACMS"]; }
		}

		#endregion		// #region Connection Manager

		#region Static Methods
		public static EdiInfo RunOutboundMap(EdiInfo edi)
		{
			return RunOutboundMap(edi,null);
		}
		public static EdiInfo RunOutboundMap(EdiInfo ediInfo, string sISA)
		{
			//
			// Expand upon this in the future to use configuration
			// setup in the db.
			//
			//ClsTradingPartner tp = ClsTradingPartner.GetUsingKey(sPartner);
			//ClsTradingPartnerEdi ediInfo =
			//    ClsTradingPartnerEdi.GetByMap(tp.Trading_Partner_Cd, sMap);
			string sMap = ediInfo.MapNickName;			
			string sMercatorEXE = "\\\\guardianedge\\acms\\edi\\mercator\\Mercator6.5\\mercnt.exe";

			if (string.IsNullOrEmpty(sISA))
				sISA = NextISANbr().ToString();
			string sScriptName = sMap + ".bat";
			ediInfo.File_Name = ediInfo.Prefix + sISA + ".txt";

			StringBuilder sbCommand = new StringBuilder();
			sbCommand.AppendFormat(@"{0} {1}{2} -B -OF1 {3}{4}",
				sMercatorEXE, ediInfo.Map_Path, ediInfo.Map_File_Nm,
				ediInfo.File_Path, ediInfo.File_Name);

			string sFullFileName =
				ediInfo.File_Path + ediInfo.File_Name;

			string sCmd = sbCommand.ToString();

			string sFullScriptPath = ediInfo.Script_Path + sScriptName;
			StreamWriter strm = new StreamWriter(sFullScriptPath, false);
			strm.WriteLine(sCmd);
			strm.Close();

			using (Process mapMaprocess = Process.Start(sFullScriptPath))
			{
				mapMaprocess.WaitForExit();
				int i = mapMaprocess.ExitCode;
			}
			return ediInfo;
		}

		public static EdiInfo RunInboundMap(EdiInfo ediInfo)
		{
			try
			{
				string sMap = ediInfo.MapNickName;
				// Establish the full path for the map executable and BAT file name
				string sMercatorEXE = "\\\\guardianedge\\acms\\edi\\mercator\\Mercator6.5\\mercnt.exe";
				string sScriptName = sMap + ".bat";

				// Loop through all files that are ready to process
				string[] fileList;
				fileList = Directory.GetFiles(ediInfo.File_Path);
				foreach (string fileNm in fileList)
				{
					string sFile = Path.GetFileName(fileNm);
					ediInfo.File_Name = sFile;

					// Build a BAT file that executes the Mercator Map
					StringBuilder sbCommand = new StringBuilder();
					sbCommand.AppendFormat(@"{0} {1}{2} -B -IF1 {3}{4}",
						sMercatorEXE, ediInfo.Map_Path, ediInfo.Map_File_Nm,
						ediInfo.File_Path, ediInfo.File_Name);

					string sFullFileName = ediInfo.File_Name;
					string sCmd = sbCommand.ToString();
					string sFullScriptPath = ediInfo.Script_Path + sScriptName;
					StreamWriter strm = new StreamWriter(sFullScriptPath, false);
					strm.WriteLine(sCmd);
					strm.Close();

					// Run the BAT file to run the map and wait for it to end
					using (Process mapMaprocess = Process.Start(sFullScriptPath))
					{
						mapMaprocess.WaitForExit();
					}

					// Log to t_ftp_history
					ClsAcmsSQL.WriteFTPLog(ediInfo.File_Name, ediInfo.FullFileName);

					// Upon successful completion, archive the file
					string sFileName = Path.GetFileName(sFullFileName);
					System.IO.File.Move(ediInfo.FullFileName, ediInfo.Ark_File_Path + sFileName);
				}
				return ediInfo;
			}
			catch (Exception ex)
			{
				ClsErrorHandler.LogException(ex);
				return null;
			}
		}

		public static string FTPFile(string sPartner, string sDir, string sMap)
		{
			//
			// FTP the file to our trading partner
			// (copies entire folder)
			//
			FTPInfo fi;
			string sReturn = "";
			switch (sMap.ToUpper())
			{
				case "301OUT":
					fi = GetFTPInfo_SDDC301();
					break;
				case "315OUT":
					fi = GetFTPInfor_SDDC315();
					break;
				default:
					return "";
			}
			try
			{
				FtpClient ftp = new FtpClient();
				ftp.Connect(fi.IPAddress);
				ftp.Login(fi.User, fi.Password);
				ftp.SetCurrentDirectory(fi.UploadFolder);


				// Grab list of files for later
				string[] fileList;
				fileList = Directory.GetFiles(sDir);

				//
				// FTP the entire folder
				//
				ftp.Upload(sDir, fi.ArchiveFolder);

				//
				// Update ftp flag
				//
				foreach (string s in fileList)
				{
					string sFile = Path.GetFileName(s);
					sReturn = UpdateFTPFlag(sFile);
				}
				return sReturn;
			}
			catch (Exception ex)
			{
				StringBuilder sMsg = new StringBuilder();
				sMsg.AppendFormat("There was an error uploading ITV files for SDDC. ");
				sMsg.AppendFormat("The system will try again in a few minutes, but if this error persists contact IT Helpdesk.");
				sMsg.AppendLine();
				sMsg.AppendLine();
				sMsg.AppendLine(ex.Message);
				/*throw new Exception(sMsg.ToString());*/
				return sMsg.ToString();
			}
		}

		private static long NextISANbr()
		{
			long ISANbr;
			string sql = string.Format(@"
				select max(cur_ctl_no)
				  from r_edi_info ");

			object objResult = Connection.GetScalar(sql);

			ISANbr = Convert.ToInt64(objResult);
			return ISANbr;
		}

		public static MapFtpInfo ReadyToTransmitITV()
		{
			MapFtpInfo mapinfo = new MapFtpInfo();
			try
			{
				Connection.CommandTimeout = 0;
				string sql = "select * from v_itv_dod ";
				mapinfo.dtReturn = Connection.GetDataTable(sql);
				return mapinfo;
			}
			catch (Exception ex)
			{
				mapinfo.Errors = ex.Message;
				mapinfo.dtReturn = null;
				return mapinfo;
			}
		}

		public static DataTable UnSentITV()
		{
			Connection.CommandTimeout = 0;
			string sql = "select * from v_itv_not_sent ";
			return Connection.GetDataTable(sql);
		}

		public static DataTable Confirmations()
		{
			Connection.CommandTimeout = 0;
			// Gets a list of confirmations that are ready to be sent
			string sql = "select * from V_301_DOD ";
			return Connection.GetDataTable(sql);
		}

		public static DataTable BookingsForLine()
		{
			string sql = "select * from ediuser.v_300_output_wwl ";
			return Connection.GetDataTable(sql);
		}
		public static string UpdateFTPFlag(string sFile)
		{
			bool bInTrans = Connection.IsInTransaction;
			if (!bInTrans)
				Connection.TransactionBegin();
			try
			{
				string sql = string.Format(@"update t_edi_activity_ftp
							set ftp_success_cd = 'Y' 
						where trim(table_dsc) = '{0}' ", sFile.Trim());
				Connection.RunSQL(sql);
				if (!bInTrans)
				{
					Connection.TransactionCommit();
				}
				return "";
			}
			catch (Exception ex)
			{
				if (!bInTrans)
					Connection.TransactionRollback();
				ClsErrorHandler.LogException(ex);
				return ex.Message;
			}
		}
		#endregion

		#region 300/315 to LINE and 315 from LINE

		public static EdiInfo GetEDIInfo_LINE300()
		{
			//
			// Create an EDIInfo object specifically for 300 messages
			// from ACMS to LINE.  
			//
			EdiInfo ediInfo = new EdiInfo();
			string sMapPath = "\\\\guardianedge\\acms\\edi\\mercator\\maps\\";
			string sMapFile = "softship\\300outbound_ACMS2Line.mmc";
			//string sOutPath = "\\\\commserver01\\In_Out\\ANSI300_Imp\\Processing\\ACMS\\";
			string sOutPath = "\\\\commserver01\\In_Out\\ANSI300_Imp\\Processing\\ACMS\\";
			string sPrefix = "300OUT_";
			string sScriptPath = "\\\\guardianedge\\acms\\edi\\scripts\\LINE\\";
			ediInfo.Partner = "LINE";
			ediInfo.MapNickName = "300OUT";
			ediInfo.Map_Path = sMapPath;
			ediInfo.Map_File_Nm = sMapFile;
			ediInfo.File_Path = sOutPath;
			ediInfo.Prefix = sPrefix;
			ediInfo.Script_Path = sScriptPath;
			return ediInfo;
		}

		public static EdiInfo GetEDIInfo_LINE301()
		{
			//
			// Create an EDIInfo object specifically for 301 messages
			// from LINE to ACMS.  
			//
			EdiInfo ediInfo = new EdiInfo();


			string sMapPath = "\\\\guardianedge\\acms\\edi\\mercator\\maps\\";
			string sMapFile = "wwl\\301inbound_wwlarc.mmc";
			string sInPath = "\\\\commserver01\\In_Out\\ANSI301_Exp\\out\\";
			string sArkPath = "\\\\commserver01\\In_Out\\ANSI301_Exp\\archive\\";
			string sScriptPath = "\\\\guardianedge\\acms\\edi\\scripts\\LINE\\";
			ediInfo.MapNickName = "LINE301_INnew";
			ediInfo.Map_Path = sMapPath;
			ediInfo.Map_File_Nm = sMapFile;
			ediInfo.File_Path = sInPath;
			ediInfo.Ark_File_Path = sArkPath;
			ediInfo.Prefix = "";
			ediInfo.Script_Path = sScriptPath;
			ediInfo.Partner = "LINE";
			return ediInfo;
		}

		public static EdiInfo GetEDIInfo_LINE315()
		{
			//
			// Create an EDIInfo object specifically for 301 messages
			// from LINE to ACMS.  
			//
			EdiInfo ediInfo = new EdiInfo();

			string sMapPath = "\\\\guardianedge\\acms\\edi\\mercator\\maps\\";
			string sMapFile = "wwl\\315inbound_wwlarc.mmc";
			string sInPath = "\\\\commserver01\\In_Out\\ANSI315_Exp\\out\\ACMS\\";
			string sArkPath = "\\\\commserver01\\In_Out\\ANSI315_Exp\\out\\ACMS\\archive\\";
			string sScriptPath = "\\\\guardianedge\\acms\\edi\\scripts\\LINE\\";
			ediInfo.MapNickName = "LINE315_INnew";
			ediInfo.Map_Path = sMapPath;
			ediInfo.Map_File_Nm = sMapFile;
			ediInfo.File_Path = sInPath;
			ediInfo.Ark_File_Path = sArkPath;
			ediInfo.Prefix = "";
			ediInfo.Script_Path = sScriptPath;
			ediInfo.Partner = "LINE";
			return ediInfo;
		}
		
		#endregion

		#region 304 from AAL to LINE
		public static EdiInfo GetEDIInfo_LINE304()
		{
			//
			// Create an EDIInfo object specifically for 304 messages
			// from ACMS to LINE.  
			//
			EdiInfo ediInfo = new EdiInfo();
			string sMapPath = "\\\\guardianedge\\acms\\edi\\mercator\\maps\\";
			string sMapFile = "\\class\\304outbound_aal2line.mmc";
			string sOutPath = "\\\\commserver01\\In_Out\\ANSI304_Imp\\Preprocessing\\";
			string sPrefix = "304OUT_AAL_SDDCEDI_";
			string sScriptPath = "\\\\guardianedge\\acms\\edi\\scripts\\LINE\\";
			ediInfo.Partner = "LINE";
			ediInfo.MapNickName = "304AAL2LINE_OUT";
			ediInfo.Map_Path = sMapPath;
			ediInfo.Map_File_Nm = sMapFile;
			ediInfo.File_Path = sOutPath;
			ediInfo.Prefix = sPrefix;
			ediInfo.Script_Path = sScriptPath;
			return ediInfo;
		}
		#endregion

		#region 304 from IAL to LINE
		public static EdiInfo GetEDIInfo_IAL304_west()
		{
			//
			// Create an EDIInfo object specifically for 304 messages
			// from ACMS to LINE.  
			//
			EdiInfo ediInfo = new EdiInfo();
			string sMapPath = "\\\\guardianedge\\acms\\edi\\mercator\\maps\\IAL";
			string sMapFile = "\\304outbound_aal2line.mmc";
			//string sOutPath = "\\\\commserver01\\In_Out\\ANSI304_Imp\\Preprocessing\\";
			string sOutPath = "\\\\commserver01\\In_Out\\ANSI304_Imp\\Preprocessing\\";
			string sPrefix = "304OUT_IAL_SDDCEDI";
			string sScriptPath = "\\\\guardianedge\\acms\\edi\\scripts\\IAL\\";
			ediInfo.Partner = "LINE";
			ediInfo.MapNickName = "304IAL2LINE_OUT";
			ediInfo.Map_Path = sMapPath;
			ediInfo.Map_File_Nm = sMapFile;
			ediInfo.File_Path = sOutPath;
			ediInfo.Prefix = sPrefix;
			ediInfo.Script_Path = sScriptPath;
			return ediInfo;
		}
		public static EdiInfo GetEDIInfo_IAL304_east()
		{
			//
			// Create an EDIInfo object specifically for 304 messages
			// from ACMS to LINE.  
			//
			EdiInfo ediInfo = new EdiInfo();
			string sMapPath = "\\\\guardianedge\\acms\\edi\\mercator\\maps\\IAL";
			string sMapFile = "\\304outbound_aal2line_eb.mmc";
			//string sOutPath = "\\\\commserver01\\In_Out\\ANSI304_Imp\\Preprocessing\\";
			string sOutPath = "\\\\commserver01\\In_Out\\ANSI304_Imp\\Preprocessing\\";
			string sPrefix = "304OUT_IAL_SDDCEDI";
			string sScriptPath = "\\\\guardianedge\\acms\\edi\\scripts\\IAL\\";
			ediInfo.Partner = "LINE";
			ediInfo.MapNickName = "304IAL2LINE_OUT";
			ediInfo.Map_Path = sMapPath;
			ediInfo.Map_File_Nm = sMapFile;
			ediInfo.File_Path = sOutPath;
			ediInfo.Prefix = sPrefix;
			ediInfo.Script_Path = sScriptPath;
			return ediInfo;
		}
		#endregion

		#region 304 from SDDC to LINE
		public static EdiInfo GetEDIInfo_SDDC304()
		{
			//
			// Create an EDIInfo object specifically for 304 messages
			// from ACMS to LINE.  
			//
			EdiInfo ediInfo = new EdiInfo();
			string sMapPath = "\\\\guardianedge\\acms\\edi\\mercator\\maps\\";
			string sMapFile = "\\wwl\\304outbound_sddcwwl.mmc";
			string sOutPath = "\\\\commserver01\\In_Out\\ANSI304_Imp\\Preprocessing\\";
			string sPrefix = "304OUT_SDDC_SDDCEDI";
			string sScriptPath = "\\\\guardianedge\\acms\\edi\\scripts\\LINE\\";
			ediInfo.Partner = "LINE";
			ediInfo.MapNickName = "304SDDC2LINE_OUT";
			ediInfo.Map_Path = sMapPath;
			ediInfo.Map_File_Nm = sMapFile;
			ediInfo.File_Path = sOutPath;
			ediInfo.Prefix = sPrefix;
			ediInfo.Script_Path = sScriptPath;
			return ediInfo;
		}
		#endregion

		#region 301 to SDDC
		public static EdiInfo GetEDIInfo_SDDC301()
		{
			//
			// Create an EDIInfo object specificall for SDDC 301
			// messages.  Use this until we store all of this in
			// a database or config file.
			//
			EdiInfo ediInfo = new EdiInfo();
			string sMapPath = "\\\\guardianedge\\acms\\edi\\mercator\\maps\\";
			string sMapFile = "301Outbound.mmc";
			string sOutPath = "\\\\commserver01\\in_out\\SDDC_301Exp\\out\\";
			string sPrefix = "301OUT_";
			string sScriptPath = "\\\\guardianedge\\acms\\edi\\scripts\\SDDC\\";
			ediInfo.Partner = "SDDC";
			ediInfo.MapNickName = "301OUT";
			ediInfo.Map_Path = sMapPath;
			ediInfo.Map_File_Nm = sMapFile;
			ediInfo.File_Path = sOutPath;
			ediInfo.Prefix = sPrefix;
			ediInfo.Script_Path = sScriptPath;

			return ediInfo;
		}

		public static FTPInfo GetFTPInfo_SDDC301()
		{
			FTPInfo fi = new FTPInfo();
			fi.IPAddress = "209.95.224.122";
			fi.User = "SXR3HFTO";
			fi.Password = "7845905";
			fi.UploadFolder = "SXR3HFTO";
			fi.ErrorFolder = "\\\\commserver01\\in_out\\SDDC_301Exp\\error\\";
			fi.ArchiveFolder = "\\\\commserver01\\in_out\\SDDC_301Exp\\archive\\";
			return fi;
		}
		#endregion

		#region 315 to SDDC
		public static EdiInfo GetEDIInfo_SDDC315()
		{
			//
			// Create an EDIInfo object specificall for SDDC 315
			// messages.  Use this until we store all of this in
			// a database or config file.
			//
			EdiInfo ediInfo = new EdiInfo();
			string sMapPath = "\\\\guardianedge\\acms\\edi\\mercator\\maps\\";
			string sMapFile = "315Outbound.mmc";
			string sOutPath = "\\\\commserver01\\in_out\\SDDC_315Exp\\out\\";
			string sPrefix = "315OUT_";
			string sScriptPath = "\\\\guardianedge\\acms\\edi\\scripts\\SDDC\\";
			ediInfo.Partner = "SDDC";
			ediInfo.MapNickName = "315OUT";
			ediInfo.Map_Path = sMapPath;
			ediInfo.Map_File_Nm = sMapFile;
			ediInfo.File_Path = sOutPath;
			ediInfo.Prefix = sPrefix;
			ediInfo.Script_Path = sScriptPath;

			return ediInfo;
		}
		
		public static FTPInfo GetFTPInfor_SDDC315()
		{
			FTPInfo fi = new FTPInfo();
			fi.IPAddress = "209.95.224.122";
			fi.User = "SXR3HFTO";
			fi.Password = "7845905";
			fi.UploadFolder = "SXR3HFTO";
			fi.ErrorFolder = "\\\\commserver01\\in_out\\SDDC_315Exp\\error\\";
			fi.ArchiveFolder = "\\\\commserver01\\in_out\\SDDC_315Exp\\archive\\";
			return fi;
		}
		#endregion

	}

	#region EDIInfo Class
	public class EdiInfo
	{
		private string _MapNickName;
		public string MapNickName
		{
			get { return _MapNickName; }
			set { _MapNickName = value; }
		}
		private string _Partner;
		public string Partner
		{
			get { return _Partner; }
			set { _Partner = value; }
		}
		private string _Map_Path;
		public string Map_Path
		{
			get { return _Map_Path; }
			set { _Map_Path = value; }
		}

		private string _Map_File_Nm;
		public string Map_File_Nm
		{
			get { return _Map_File_Nm; }
			set { _Map_File_Nm = value; }
		}

		private string _File_Path;
		public string File_Path
		{
			get { return _File_Path; }
			set { _File_Path = value; }
		}

		private string _Ark_File_Path;
		public string Ark_File_Path
		{
			get { return _Ark_File_Path; }
			set { _Ark_File_Path = value; }
		}

		private string _Prefix;
		public string Prefix
		{
			get { return _Prefix; }
			set { _Prefix = value; }
		}

		private string _Script_Path;
		public string Script_Path
		{
			get { return _Script_Path; }
			set { _Script_Path = value; }
		}
		private string _File_Name;
		public string File_Name
		{
			get	{return _File_Name;}
			set
			{
				_File_Name = value;}
		}
		public string FullFileName
		{
			get { return File_Path + File_Name; }
		}
	}

	#endregion

	#region FTPINfo Class

	public class FTPInfo
	{
		private string _IPAddress;
		public string IPAddress
		{
			get { return _IPAddress; }
			set { _IPAddress = value; }
		}
		private string _User;
		public string User
		{
			get { return _User; }
			set { _User = value; }
		}
		private string _Password;
		public string Password
		{
			get { return _Password; }
			set { _Password = value; }
		}
		private string _UploadFolder;
		public string UploadFolder
		{
			get { return _UploadFolder; }
			set { _UploadFolder = value; }
		}

		public string _ErrorFolder;
		public string ErrorFolder
		{
			get { return _ErrorFolder; }
			set { _ErrorFolder = value; }
		}

		public string _ArchiveFolder;
		public string ArchiveFolder
		{
			get { return _ArchiveFolder; }
			set { _ArchiveFolder = value; }
		}
	}
	#endregion

	#region MapFtpInfo Class
	public class MapFtpInfo
	{
		private string _Errors;
		public string Errors { get{return _Errors;} set{_Errors = value;} }
		private DataTable _dtReturn;
		public DataTable dtReturn { get { return _dtReturn; } set { _dtReturn = value; } }
		public bool HasErrors
		{
			get { return !string.IsNullOrEmpty(Errors); }
		}
	}
	#endregion
}