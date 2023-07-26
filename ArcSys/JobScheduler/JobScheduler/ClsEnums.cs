using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JobScheduler
{
	public static class LogType
	{
		public const string LogFileOnly = "1";
		public const string LogAndPanel = "5";
		public const string ErrorFileOnly = "9";
	}

	public static class JobType
	{
		public const string MoveFile = "MOVE";
		public const string ExecuteApp = "EXE";
		public const string Pop3Download = "POP3";
		public const string ftpGet = "FTPGET";
		public const string ftpPut = "FTPPUT";
		public const string SendEmail = "SENDMAIL";
		public const string CopyFile = "COPY";
	}
}
