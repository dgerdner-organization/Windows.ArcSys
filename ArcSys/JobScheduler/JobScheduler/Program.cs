using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Configuration;

namespace JobScheduler
{
	class Program
	{
		#region Fields
		public static string ErrorLogFile
		{
			get
			{
				string[] s = ConfigurationManager.AppSettings.GetValues("ErrorLogFile");
				return s[0];
			}
		}
		public static string LogFilesFolder
		{
			get
			{
				string[] s = ConfigurationManager.AppSettings.GetValues("LogFilesFolder");
				return s[0];
			}
		}
		public static string DataFilesFolder
		{
			get
			{
				string[] s = ConfigurationManager.AppSettings.GetValues("DataFilesFolder");
				return s[0];
			}
		}
		private static ClsJobScheduler _jobSchedule;
		public static ClsJobScheduler jobSchedule
		{ get { return _jobSchedule; } }
		private static DbConnection _ArcSysConn;
		public static DbConnection ArcSysConn
		{
			get { return _ArcSysConn; }
		}
		private static frmMain _MainWindow;
		public static frmMain MainWindow { get { return _MainWindow; } }
		#endregion

		#region Main
		static void Main(string[] Args)
		{
			try
			{
				_jobSchedule = new ClsJobScheduler();
				ConnectToDatabaseArcSys();
				_MainWindow = new frmMain();
				Application.Run(MainWindow);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		#endregion

		#region DB Connection Methods
		public static void ConnectToDatabaseArcSys()
		{
			ConnectionStringSettings cs = ConfigurationManager.ConnectionStrings["ARCSYSPRO"];
			string sConnString = cs.ConnectionString;
			sConnString = sConnString.Replace("<user>", "ARC_OWNER");
			sConnString = sConnString.Replace("<pwd>", "Tacoma42");

			DbProviderFactory dbf = DbProviderFactories.GetFactory(cs.ProviderName);
			_ArcSysConn = dbf.CreateConnection();
			_ArcSysConn.ConnectionString = sConnString;
			
			_ArcSysConn.Open();
		}
		#endregion


	}

	internal class MyAsyncContext
	{
		private readonly object _sync = new object();
		private bool _isCancelling = false;

		public bool IsCancelling
		{
			get
			{
				lock (_sync) { return _isCancelling; }
			}
		}

		public void Cancel()
		{
			lock (_sync) { _isCancelling = true; }
		}
	}
}
