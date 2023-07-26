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
	public partial class frmWebBrowser : Form
	{

		#region Fields

		private string _strURL;

		#endregion

		#region Contstructors

		public frmWebBrowser()
		{
			InitializeComponent();
		}		
		#endregion

		#region Public Methods

		public void ShowWebPage(string strTitle,string strURL, Boolean AutoPrint)
		{
			try
			{
				btnURL.Visible = ClsEnvironment.IsDeveloper;
				_strURL = strURL;
				wb.Navigate(_strURL);
				Text = strTitle;
				Show();
			}
			catch (Exception Ex)
			{
				Display.ShowError("Error", Ex);
			}
		}

		public void ShowWebPage(string strTitle,string strURL)
		{
			try
			{
				ShowWebPage(strTitle,strURL, false);			
			}
			catch (Exception Ex)
			{
				Display.ShowError("Error",Ex);
			}
		}

        public void ShowHtml(string strTitle, string strHTML)
        {
            try
            {
				btnURL.Visible = ClsEnvironment.IsDeveloper;
                wb.DocumentText = strHTML;
				Text = strTitle;
				Show();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

		#endregion

		#region Private Methods

		private void NavigateForward()
		{
			try
			{
				wb.GoForward();
			}
			catch (Exception Ex)
			{
				Display.ShowError("Error", Ex);
			}
		}

		private void NavigateBack()
		{
			try
			{
				wb.GoBack();
				wb.GoBack();
			}
			catch
			{
				// Suppress the Error
				//Display.ShowError("Error", Ex);
			}
		}

		private void ShowURL()
		{
			MessageBox.Show(_strURL);
			Clipboard.SetText(_strURL);
		}

		#endregion

		#region Event Handlers

		private void btnURL_Click(object sender, EventArgs e)
		{
			ShowURL();
		}

		private void tsbForward_Click(object sender, EventArgs e)
		{
			NavigateForward();
		}

		private void tsbBack_Click(object sender, EventArgs e)
		{
			NavigateBack();
		}

		#endregion



	}
}