using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CS2010.CommonWinCtrls;
using CS2010.Common;
using CS2010.ArcSys.Business;
using System.Net.Configuration;

namespace CS2010.ArcSys.Win
{
    public partial class frmHtmlReport : frmWebBrowser
    {
        public frmHtmlReport()
        {
            InitializeComponent();
        }

        #region Private Methods

        private void EmailIt()
        {
            try
            {
                ClsUser u = ClsUser.GetUsingLogin(ClsEnvironment.UserName);

                ClsEmail e = new ClsEmail();
                e.From = u.Email;
                e.To = u.Email;
                e.Subject = "Battery Disconnect";
                e.Body = wb.DocumentText;

                e.SMTPServer  = System.Configuration.ConfigurationManager.AppSettings["SMTPServer"].ToString();

                e.SendMail(true);

                MessageBox.Show("Email Sent to '" + e.To + "'");
            }
            catch (Exception ex)
            {
                Display.ShowError(ex);
            }
        }

        #endregion

        #region Event Handlers

        private void button2_Click(object sender, EventArgs e)
        {
            EmailIt();
        }

        #endregion
    }
}
