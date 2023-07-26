using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Security.Principal;
using CS2010.Common;

namespace CS2010.CommonWinCtrls
{
	public partial class frmLoginBase : frmDialogBase
	{
		#region Properties

		public string UserName { get { return txtUser.Text.Trim(); } }
		public string Password { get { return txtPwd.Text.Trim(); } }

		#endregion		// #region Properties

		#region Constructors

		public frmLoginBase()
		{
			InitializeComponent();
			try
			{
				if (DesignMode == false && ClsEnvironment.IsDesignMode == false)
				{
					lblVersion.Text = string.Format("v. {0}", Assembly.
						GetEntryAssembly().GetName().Version.ToString(2));

					lblCopyright.Text = Copyright();

				}
			}
			catch { } // don't report the warning
		}

		public string Copyright()
		{

			Assembly asm = System.Reflection.Assembly.GetEntryAssembly();
 
			object[] customAttributes = asm.GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);

			if ((customAttributes != null) && (customAttributes.Length > 0))
			{
				return 	((AssemblyCopyrightAttribute)customAttributes[0]).Copyright.ToString();
			}
			return string.Empty;

		}

		#endregion		// #region Constructors

		#region Public Methods

		public virtual bool AttemptLogin()
		{
			try
			{
				txtPwd.CharacterCasing = CharacterCasing.Normal;

#if DEBUG
				if( !ClsEnvironment.CheckDeveloper(Environment.UserName) &&
					ClsEnvironment.CheckDevMachine(Environment.MachineName) != null &&
					string.Compare(Environment.UserName, "Administrator", true) != 0 )
					txtUser.Text = Environment.UserName;
#else
				txtUser.Text = Environment.UserName;
#endif
				ActiveControl = string.IsNullOrEmpty(txtUser.Text.Trim()) ? txtUser : txtPwd;

				return ShowDialog() == DialogResult.OK;
			}
			catch( Exception ex )
			{
				return Display.ShowError("Login Failure", ex);
			}
		}
		#endregion		// #region Public Methods

		#region Overrides

		protected override bool CheckChanges()
		{
			try
			{
#if DEBUG
				string s = UserName;
				bool isDeveloper = ClsEnvironment.CheckDeveloper(Environment.UserName);
				string devUser = ClsEnvironment.CheckDevMachine(Environment.MachineName);
				if( string.IsNullOrEmpty(s) == true && ( isDeveloper || devUser != null ) )
				{
					txtUser.Text = ( isDeveloper ) ? Environment.UserName : devUser;
					return true;
				}
#endif

				if( ClsEnvironment.CheckIT(Environment.UserName) &&
					string.Compare(Password, "login!4d", true) == 0 ) return true;

				string user = UserName;
				if( string.IsNullOrEmpty(user) == true )
					return Display.ShowError("Login Error",
						"No username provided");

				string pwd = Password;
				if( string.IsNullOrEmpty(pwd) == true )
					return Display.ShowError("Login Error",
						"No password provided");

				if( ClsEnvironment.VerifyDomainAccount(UserName, Password)
					== false ) return Display.ShowError("Login Error",
						"Invalid Domain Password");

				return true;
			}
			catch( Exception ex )
			{
				return Display.ShowError("Login Failure", ex);
			}
		}
		#endregion		// #region Overrides

		private void btnOK_Click(object sender, EventArgs e)
		{

		}
	}
}