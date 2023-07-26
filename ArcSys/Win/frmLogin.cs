using System;
using System.Windows.Forms;
using CS2010.Common;
using CS2010.CommonWinCtrls;

namespace CS2010.ArcSys.Win
{
    public partial class frmLogin : frmLoginBase
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            Text = ClsConfig.ReadConfigValue("Title");
		}
    }
}