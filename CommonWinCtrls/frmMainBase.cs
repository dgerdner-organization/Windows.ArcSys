using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CS2010.Common;

namespace CS2010.CommonWinCtrls
{
    public partial class frmMainBase : Form
    {
        public frmMainBase()
        {
            InitializeComponent();
        }

        private void frmMainBase_Load(object sender, EventArgs e)
        {

            ClsEnvironment.Version = (string.IsNullOrEmpty(ClsEnvironment.Version)) 
                ? System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString()
                : ClsEnvironment.Version;

            ClsEnvironment.Database = (string.IsNullOrEmpty(ClsEnvironment.Database))
                ? ClsEnvironment.ConnectionStringName
                : ClsEnvironment.Database;

            Text = (string.IsNullOrEmpty(ClsConfig.ReadConfigValue("Title")))
                ? Text
                : ClsConfig.ReadConfigValue("Title");

            this.Text = string.Format("{0} - [{1} - {2} - {3} - {4}]",
                this.Text,
                ClsEnvironment.UserName,
                ClsEnvironment.Database, 
                ClsEnvironment.Version,
                System.Environment.MachineName);
        }


    }
}
