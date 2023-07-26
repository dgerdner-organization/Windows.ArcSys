using System;
using System.Reflection;
using System.Windows.Forms;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.CommonWinCtrls
{
	public partial class frmAbout : Form
	{
		#region Constructors

		public frmAbout()
		{
			InitializeComponent();
		}
		#endregion		// #region Constructors

		#region Public methods

		public void DisplayAbout(Assembly appAssembly, string appName,
			string appDesc)
		{
			try
			{
				Text = string.Format("About {0} {1}", appName, appDesc);
				LoadAssemblyInfo(appAssembly, appName);
				LoadDBInfo();
				ShowDialog();
			}
			catch( Exception ex )
			{
				Display.ShowError("About Dialog Error", ex);
			}
		}
		#endregion		// #region Public methods

		#region Helper Methods

		protected void LoadAssemblyInfo(Assembly appAssembly, string appName)
		{
			try
			{
				Dictionary<string, string> info =
					ClsEnvironment.GetModuleInfo(appAssembly);
				string name = info["Name"];
				string version = ClsEnvironment.Version;// info["Version"];
				lblName.Text = ( name == null || name == string.Empty ) ?
					"Unable to retrieve application executable name" : name;
				lblVersion.Text = ( version == null || version == string.Empty ) ?
					"Unable to retrieve version number" : version;
				foreach( KeyValuePair<string, string> kvp in info )
				{
					name = kvp.Key;
					version = kvp.Value;
					if( string.Compare(name, "Name", true) == 0 ||
						string.Compare(name, "Version", true) == 0 ) continue;
					ListViewItem li = lstAssemblies.Items.Add(name);
					li.SubItems.Add(version);
				}
			}
			catch( Exception ex )
			{
				Display.Show(ex.Message, "About Dialog Error");
			}
		}

		private void LoadDBInfo()
		{
			string[] items = ClsEnvironment.GetDbInfo();
			if( items == null || items.Length <= 0 ) return;

			lstDB.Items.Add(new ListViewItem(items));
		}
		#endregion		// #region Helper Methods
	}
}