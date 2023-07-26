using System;
using System.IO;
using System.Data;
using System.Text;
using System.Threading;
using System.Reflection;
using System.Windows.Forms;
using System.Configuration;
using System.Collections.Generic;
using CS2010.Common;
using CS2010.CommonWinCtrls;
using CS2010.CommonSecurity;
using CS2010.CommonReports;
using CS2010.ArcSys.Business;
using CS2010.ACMS.Business;


namespace CS2010.ArcSys.Win
{
	public static class Program
	{
		#region Fields/Properties

		private const byte MaxAttempts = 3;
		public static string[] NoSearchusers
		{
			get
			{
				string sUsers = ConfigurationManager.AppSettings["NoAutoSearchUsers"].ToString();
				string[] aUsers = sUsers.Trim().Split(',');
				return aUsers;
			}
		}
		//public static StreamWriter StrmFile;
		public static bool IsLoggedIntoACMS = false;
		public static bool IsACMSTest = false;
        public static bool IsARCTest = false;
		private static frmMain _MainWindow;
		public static frmMain MainWindow { get { return _MainWindow; } }

		public static DateTime CurrentDate
		{
			get { return ClsUser.CurrentUser.LocalDate; }
		}

		private static string _AppArg;
		public static string AppArg
		{
			get { return _AppArg; }
			set { _AppArg = value; }
		}

		public static string UserName
		{
			get
			{
				string winUser = Path.GetFileName(Environment.UserName);
				return winUser;

			}
		}
		public static ClsSecurityUser CurrentUser
		{
			get
			{
				ClsSecurityUser u = ClsSecurityUser.GetUsingKey(ClsEnvironment.User_Id.GetValueOrDefault());
				return u;
			}
		}
		public static ClsLinkHandlerARC LinkHandler;
		#endregion		// #region Fields/Properties

		#region Main

		/// <summary>The main entry point for the application.</summary>
		[STAThread]
		static void Main(string[] args)
		{
			try
			{
                WriteAudit("Starting Application");
                System.Security.Principal.WindowsIdentity id = System.Security.Principal.WindowsIdentity.GetCurrent();
                WriteAudit("1");
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);

				//
				// Connect to ARC
				//  First argument is the AROF connection string config key
				//  Second argument is "T" or "P", indicating Test or Production for ACMS
				//
				IsACMSTest = true;
				string s = (args != null && args.Length > 0) ? args[0] : null;
                IsARCTest = true;
                if (s == "P" || s == "ARCSYSPRO")
                    IsARCTest = false;

				string s2 = (args != null && args.Length > 1) ? args[1] : null;
				if (s2 == "P" || s2 == "ACMSP")
					IsACMSTest = false;
				if (s2 == "T" || s2 == "ACMST")
					IsACMSTest = true;

				AppArg = s;
				ClsEnvironment.ConnectionStringName =
					(string.IsNullOrEmpty(s) == true) ? "ARCSYSDEV" : s;
				ClsConfig.SectionName = ClsEnvironment.ConnectionStringName;
#if DEBUG
				if (string.IsNullOrEmpty(s)) GetConnectionStringName();
#endif
				ClsEnvironment.ConnectionKey = "ArcSys";
				ClsEnvironment.Database = ClsEnvironment.ConnectionStringName.Substring(0, 7);

				if (ConfigurationManager.ConnectionStrings
					[ClsEnvironment.ConnectionStringName] == null)
				{
					Program.ShowError
						("A connection string does not exist with the name {0}",
						ClsEnvironment.ConnectionStringName);
					return;
				}

                WriteAudit("20");
				Config.LoadEDIConfig();
                WriteAudit("30");
				ClsEnvironment.Version = GetVersion();
                WriteAudit("40");
				//TestPATService();

				if (AttemptLogin(3) == false) return;

				//
				// Make a 2nd Connection for Import / Updates
				//
				ClsConnection arcImport = new ClsConnection();
				arcImport.DbConnectionKey = "ArcImport";
				ClsConMgr.Manager.AddConnection(arcImport);

                WriteAudit("50");
				ClsConnection ArcSysBG = new ClsConnection();
				arcImport.DbConnectionKey = "ArcSysBG";
				ClsConMgr.Manager.AddConnection(arcImport);

				//
				// Connect to Security
				//
                WriteAudit("60");
				ClsConnection sec = new ClsConnection();
				sec.DbConnectionKey = "Security";
				ClsConMgr.Manager.AddConnection(sec);

				if (VerifySecurity() == false) return;

				//
				//  Connect to arc-ocean
				//
                WriteAudit("70");
				if (!ConnectToOCEAN())
				{
					Show("Warning: Could not connect to Arc-Ocean database.  Functions that require it will fail.");
				}
				//TODO: JROMAN since we are not displaying any reports for now, comment out below
				// when we finally add reports, we can uncomment this, but then we have to
				// figure out what is causing the error message
				//AsyncApplicationInitialization();
                WriteAudit("80");
				InitViewWindowManager();
                WriteAudit("90");
				if (!setupConnectToAVSS())
				{
					MessageBox.Show("Warning: Could not connect to AVSS.");
				}
                WriteAudit("100");
				ConnectToCLASS();

                WriteAudit("110");
				//ConnectITrack();

                WriteAudit("120");
				ClsSecurityUser u = Program.CurrentUser;
				ClsSecurityGroup sg = u.DefaultGroup;
				bool bACMS = false;
				DataTable dtCS = ClsSecurity.GetSecurityForUserObject(CurrentUser.User_ID.GetValueOrDefault(), "mnuSDDCEDI");
				if (dtCS.Rows.Count > 0)
				    bACMS = true;
				if (sg.Group_Dsc.Contains("ACMS") ||
					u.User_Nm.Contains("DGERDNER") ||
					u.User_Nm.Contains("JROMAN") ||
					u.User_Nm.Contains("DORNEY") ||
					bACMS)
				{
					// Try logging in using their user-id, because for a lot of people that's what they use
					if (Program.ConnectToACMS(ClsEnvironment.UserName.ToLower()))
						IsLoggedIntoACMS = true;
					// Just for DGERDNER, if it still fails use my password
					if (!IsLoggedIntoACMS)
					{
						if (Program.ConnectToACMS("mojojo"))
							IsLoggedIntoACMS = true;
						else if (Program.ConnectToACMS("montvale123"))
							IsLoggedIntoACMS = true;
					}
					
					if (!IsLoggedIntoACMS)
					{
						frmACMSLogin frm = new frmACMSLogin();
						DialogResult dr = frm.ShowDialog();
						if (dr == DialogResult.Cancel)
						{
							Show("You did not log-in ACMS; some features will not be available");
						}
					}
					//IsLoggedIntoACMS = true;
				}
				//
				// Log onto LINE
				//  (No - only do this on -demand)
				//
				//ConnectToLINE();

				//
				//  Setup the LinkHandler
				//
				LinkHandler = new ClsLinkHandlerARC();

				//
				// Load the MDI window
				//
                WriteAudit("130");
				_MainWindow = new frmMain();
				string acms = "ACMSPROD";
                string avss = "AVSSProd";
				if (IsACMSTest)
					acms = "ACMSTest";
                if (IsARCTest)
                    avss = "AVSSTest";
				StringBuilder sb = new StringBuilder(_MainWindow.Tag as string);
				sb.Replace("<Title>", ClsConfig.Title).
					Replace("<user>", ClsEnvironment.UserName).
					Replace("<VER>", ClsEnvironment.Version).
					Replace("<DB>", ClsEnvironment.ConnectionStringName.Substring(6)).
					Replace("<ACMS>", acms);
                sb.Replace("<AVSS>", avss);

				_MainWindow.Text = sb.ToString();


				//
				//  Start the Application
				//
                WriteAudit("140");
				Application.Run(MainWindow);
				//if (StrmFile != null)
				//    StrmFile.Close();
			}
			catch (Exception ex)
			{
				//if (StrmFile != null)
				//    StrmFile.Close();
                WriteAudit("150");
                WriteAudit(ex.Message);
				Program.ShowError(ex);
			}
		}
		#endregion		// #region Main

		#region Application Startup

#if DEBUG
		private static void GetConnectionStringName()
		{
			try
			{
				string winUser = Path.GetFileName(ClsErrorHandler.User);
				if (!ClsEnvironment.CheckDeveloper(winUser) &&
					string.Compare(winUser, "Administrator", true) != 0) return;

				using (frmMemo f = new frmMemo())
				{
					f.UpperCase = true;
					if (f.InputBox("Enter DB connection string name", null))
					{
						string tmp = f.InputText.Trim();
							if (tmp != null && tmp.Length == 1)
						{
							char c = char.ToUpper(tmp[0]);
							switch (c)
							{
								case 'P': 
                                    tmp = "ARCSYSPRO"; 
                                    IsARCTest = false;
                                    break;
								case 'T': 
                                    tmp = "ARCSYSTEST";
                                    IsARCTest = true;
                                    break;
								case 'D': 
                                    tmp = "ARCSYSDEV";
                                    IsARCTest = true;
                                    break;
							}
						}
						AppArg = tmp.ToUpper();
						
						if (ConfigurationManager.ConnectionStrings[tmp] == null)
						{
							Program.ShowError
								("{0} does not exist defaulting to {1}",
								tmp, ClsEnvironment.ConnectionStringName);
						}
						else
						{
							ClsEnvironment.ConnectionStringName = tmp;
							ClsConfig.SectionName = ClsEnvironment.ConnectionStringName;
						}
					}
				}
				using (frmMemo f = new frmMemo())
				{
					f.UpperCase = true;
					if (f.InputBox("ACMS Test or Production (T or P)", null))
					{
						IsACMSTest = false;
						string tmp = f.InputText.Trim();
						if (!string.IsNullOrEmpty(tmp))
						{
							if (tmp == "T" || tmp == "ACMST")
								IsACMSTest = true;
							else
								IsACMSTest = false;
						}
					}
				}

			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}
#endif

		private static string GetVersion()
		{
			try
			{
				Assembly asm = Assembly.GetExecutingAssembly();
				AssemblyName asmName = asm.GetName();
				string v = asmName.Version.ToString(3);
				if (string.IsNullOrEmpty(v)) return v;

				string[] parts = v.Split(new char[] { '.' });
				if (parts == null || parts.Length < 3) return v;

				string v3 = (parts[2] != null) ? parts[2].Trim() : null;
				if (string.IsNullOrEmpty(v3)) return v;

				long? num = ClsConvert.ToInt64Nullable(v3);
				if (num == null) return v3;

				return string.Format("{0}.{1}.{2:00}", parts[0], parts[1], num);
			}
			catch
			{
				return null;
			}
		}
		#endregion		// #region Application Startup

		#region Login/Security Verification

		private static bool AttemptLogin(byte attempts)
		{
			if (attempts < 1 || attempts > MaxAttempts) attempts = MaxAttempts;

			using (frmLogin frm = new frmLogin())
			{
				for (int i = 0; i < attempts; i++)
				{
					if (frm.AttemptLogin() == false) return false;

					ClsEnvironment.UserName = frm.UserName;
					ClsEnvironment.Password = ClsConfig.DBAccess;
					ClsConMgr.Manager.AddNewConnection();

					try
					{	// attempt something in DB to see if login worked
						ClsUser.CurrentUser = ClsUser.GetUsingLogin(ClsEnvironment.UserName);
						if (ClsUser.CurrentUser != null)
						{
							//ClsEnvironment.User_Control_Cd = ClsUser.CurrentUser.Control_Cd;
							CrystalInitTable = ClsUser.GetAll();
							return true;
						}
						Program.ShowError("User {0} does not exist in database",
							ClsEnvironment.UserName);
						return true;
					}
					catch (Exception ex)
					{
						Program.ShowError(ex);
					}
				}
			}
			return false;
		}

		private static bool VerifySecurity()
		{
			ClsSecurityUser u = ClsSecurityUser.GetUsingName(ClsUser.CurrentUser.User_Login);
			if (u == null)
			{
				Program.ShowError("User {0} is not setup in the Security User table.",
					ClsUser.CurrentUser.User_Login);
				return false;
			}

			// Make sure the user is assigned to a security group
			List<ClsSecurityGroup> g = ClsSecurityGroup.GetGroupByUser(u.User_Nm);
			if (g == null || g.Count < 1)
			{
				Program.ShowError("User {0} has not been assigned to a Security Group", u.User_Nm);
				return false;
			}
			ClsEnvironment.User_Id = u.User_ID;
			return true;
		}

		public static bool ConnectToLINE()
		{
			try
			{
				string sConnect = "packet size=4096;user id=line-edi-user;password=dg20100512;data source=SQLCLUSTER;persist security info=True;initial catalog=Line_cs;";
				ClsConnection line = new ClsConnection(sConnect, "System.Data.SqlClient");
				line.DbConnectionKey = "LINE";
				ClsConMgr.Manager.AddConnection(line);
				return true;
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
				return false;
			}
		}
		public static bool ConnectToOCEAN()
		{
			try
			{
				//string sConnect = "Provider=SQLNCLI11;Data Source=ARC-SQL1.wlhinet.com;Integrated Security=SSPI;Initial Catalog=ARC_OCEANT";
				string sConnect = ConfigurationManager.ConnectionStrings["OCEAN"].ConnectionString;
                if (IsARCTest)
                    sConnect = ConfigurationManager.ConnectionStrings["OCEANTest"].ConnectionString;
				ClsConnection ocean = new ClsConnection(sConnect, "System.Data.SqlClient");
				ocean.DbConnectionKey = "OCEAN";
				ClsConMgr.Manager.AddConnection(ocean);
				return true;
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
				return false;
			}
		}
		public static bool setupConnectToAVSS()
		{
			try
			{
                string sConnect = ConfigurationManager.ConnectionStrings["AVSS"].ConnectionString;
                if (IsARCTest)
				    sConnect = ConfigurationManager.ConnectionStrings["AVSST"].ConnectionString;
                

				if (sConnect.IsNullOrWhiteSpace()) return false;

				sConnect = sConnect.Replace("<user>", "avss");
				sConnect = sConnect.Replace("<pwd>", "friday13th");

				ClsConnection avss = new ClsConnection(sConnect, "Oracle.DataAccess.Client");
				avss.DbConnectionKey = "AVSS";
				ClsConMgr.Manager.AddConnection(avss);
				return true;
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
				return false;
			}
		}

		public static bool ConnectToCLASS()
		{
			try
			{
				string sConnect = ConfigurationManager.ConnectionStrings["CLASSP"].ConnectionString;

				if (sConnect.IsNullOrWhiteSpace()) return false;

				System.Collections.Specialized.NameValueCollection settings =
						ConfigurationManager.GetSection("CLASSP") as System.Collections.Specialized.NameValueCollection;
				foreach (string sKey in settings.AllKeys)
				{
					string s = sKey;
				}
				sConnect = sConnect.Replace("<user>", ClsEnvironment.UserName);
				sConnect = sConnect.Replace("<pwd>", "mAng3n1u5");

				ClsConnection conClass = new ClsConnection(sConnect, "Oracle.DataAccess.Client");
				conClass.DbConnectionKey = "CLASS";
				ClsConMgr.Manager.AddConnection(conClass);
				return true;
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
				return false;
			}
		}
		public static bool ConnectITrack()
		{
			try
			{
				if (ClsEnvironment.UserName.StartsWith("ARCSYS", StringComparison.InvariantCultureIgnoreCase))
					return false;
				string conStr = ConfigurationManager.ConnectionStrings["ITrackPro"].ConnectionString;
				if (string.IsNullOrWhiteSpace(conStr)) return false;

				ClsConnection cn = new ClsConnection(conStr, "Oracle.DataAccess.Client",
					ClsEnvironment.UserName, "cluele55");
				cn.DbConnectionKey = "ITrack";
				ClsConMgr.Manager.AddConnection(cn);

				cn = new ClsConnection(conStr, "Oracle.DataAccess.Client",
					ClsEnvironment.UserName, "cluele55");
				cn.DbConnectionKey = "ITrackNotifier";
				ClsConMgr.Manager.AddConnection(cn);
				ASL.ITrack.Business.ClsUser.CurrentUser =
					ASL.ITrack.Business.ClsUser.GetUsingKey(ClsEnvironment.UserName);
				return true;
			}
			catch (Exception ex)
			{
				ClsErrorHandler.LogException(ex, null, "Could not connect to ITrack from ArcSys");
				return false;
			}
		}

		public static bool ConnectToACMS(string sPassword)
		{
			try
			{
				//string sConnect = "Data Source=ACMSP;Persist Security Info=True;User ID=ediuser;;password=montvale123;";
				string sConnect = ConfigurationManager.ConnectionStrings["ACMSP"].ConnectionString;
				if (IsACMSTest)
					sConnect = ConfigurationManager.ConnectionStrings["ACMST"].ConnectionString;
				
				sConnect = sConnect.Replace("<user>", ClsEnvironment.UserName.ToLower());
				sConnect = sConnect.Replace("<pwd>", sPassword);
				ClsConnection acms = new ClsConnection(sConnect, "Oracle.DataAccess.Client");
				acms.DbConnectionKey = "ACMS";
				ClsConMgr.Manager.AddConnection(acms);

				try
				{
					acms.RunSQL("select 1 from dual");
				}
				catch
				{
					return false;
				}
				// Create a Background Processing connection for ACMS
				ClsConnection acmsbg = new ClsConnection(acms.DbConnectionString, acms.DbProvider, acms.DbUserName, acms.DbPassword);
				acmsbg.DbConnectionKey = "ACMSBG";
				ClsConMgr.Manager.AddConnection(acmsbg);
				return true;
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
				return false;
			}
		}

		#endregion		// #region Login/Security Verification

		#region ViewWindowManager Initialization

		private static void InitViewWindowManager()
		{
			ViewWindowManager.AddWindowType(typeof(ClsEstimate), typeof(frmViewEstimate));
			ViewWindowManager.AddWindowType(typeof(ClsCargo), typeof(frmCargo));
			ViewWindowManager.AddWindowType(typeof(ClsApInvoice), typeof(frmViewAPInvoice));
			ViewWindowManager.AddWindowType(typeof(ClsBookingLine), typeof(frmViewBookingLINE));
			ViewWindowManager.AddWindowType(typeof(ClsBookingRequest), typeof(frmViewBookingRequest));
			ViewWindowManager.AddWindowType(typeof(ClsBookingUnit), typeof(frmViewBookingUnit));
		}
		#endregion		// #region ViewWindowManager Initialization

		#region Asynchronous Application Initialization

		private static DataTable CrystalInitTable;

		private static void AsyncApplicationInitialization()
		{
			try
			{
				ThreadStart StartDelegate = new ThreadStart(StartInitialization);
				Thread aThread = new Thread(StartDelegate);
				aThread.Start();
			}
			catch (Exception ex)
			{
				ClsErrorHandler.LogWarning(ex.Message);
			}
		}

		private static void StartInitialization()
		{
			try
			{
				ClsReportHandler.CrystalInitialization(CrystalInitTable);
			}
			catch (Exception ex)
			{
				ClsErrorHandler.LogWarning(ex.Message);
			}
		}
		#endregion		// #region Asynchronous Application Initialization

		#region Display Error/Info Messages

		public static bool ShowErrors<T>(List<T> lst) where T : ClsBaseTable
		{
			return Display.ShowErrors<T>("ARCSYS", lst);
		}

		public static bool ShowError<T>(Exception ex, List<T> lst) where T : ClsBaseTable
		{
			return Display.ShowError<T>("ARCSYS", ex, lst);
		}

		public static bool ShowError(Exception ex)
		{
			return Display.ShowError("ARCSYS", ex);
		}

		public static bool ShowError(Exception ex, ClsBaseTable obj)
		{
			return Display.ShowError("ARCSYS", ex, obj);
		}

		public static bool ShowError(Exception ex, ClsBaseTable obj, string extraInfo)
		{
			return Display.ShowError("ARCSYS", ex, obj, extraInfo);
		}

		public static bool ShowError(string msg, params object[] args)
		{
			return Display.ShowError("ARCSYS", msg, args);
		}

		public static bool Show(string msg, params object[] args)
		{
			return Display.Show("ARCSYS", msg, args);
		}

        public static void MouseBusy()
        {
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
        }

        public static void MouseNormal()
        {
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
        }

		#endregion		// #region Display Error/Info Messages

		public static void TestPATService()
		{
		}

        public static void WriteAudit(string sMsg)
        {
            // Re-enable to log the systems path in cases of extreme problems debuggin
            //using (StreamWriter writer = new StreamWriter("C:\\temp\\Audit.txt",true))
            //{
            //    writer.WriteLine(sMsg);
            //} 
        }

	}
}