using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace CS2010.ArcSys.Win
{
	public partial class frmSterlingReports : CS2010.CommonWinCtrls.frmChildBase
	{
		public frmSterlingReports()
		{
			InitializeComponent();
		}

		#region Fields
		protected const string ReportsFolder = @"\\Guardianedge\\acms\\edi\\data\\reports";

		protected string ReportType(string sCode)
		{
			switch (sCode)
			{
				case "020":
					return "Transmission Confirmation";
				case "030":
					return "Transmission Error";
				case "031":
					return "AudoDial Fail";
				case "070":
					return "Daily Summary";
				default:
					return sCode;
			}
		}
		protected string MonthYear(string sDate)
		{
			if (sDate.Length < 8)
				return "";
			string sMMYY = sDate.Substring(0, 3);
			sMMYY = sMMYY + sDate.Substring(6, 2);
			return sMMYY;
		}
		#endregion

		#region Methods
		public void ShowWindow()
		{

			this.MdiParent = Program.MainWindow;
			this.Activate();
			this.Show();
			this.WindowState = FormWindowState.Maximized;


		}

		public void PopulateGrid()
		{
				string[] dirs = Directory.GetFiles(ReportsFolder);
				string sFind = txtFind.Text;
				decimal iCounter = 0;
				decimal iLen = dirs.Length;

				DataTable dtList = new DataTable();
				dtList.Columns.Add("FileName");
				dtList.Columns.Add("ReportType");
				dtList.Columns.Add("ReportDate");
				dtList.Columns.Add("FullFileName");
				dtList.Columns.Add("MonthYear");
				dtList.Columns.Add("DownloadDate");
				try
				{
					foreach (string s in dirs)
					{
						iCounter++;

						string x = s.Replace(ReportsFolder, "");
						string sText = "";
						string sType = "undefined";
						string sDate = "";
						FileInfo info = new FileInfo(s);
						sText = File.ReadAllText(s);
						if (sText.Length > 8)
						{
							sType = sText.Substring(4, 3);
						}
						if (sText.Length > 90)
						{
							sDate = sText.Substring(82, 8);
						}
						if (x.Contains(".scr"))
							continue;
						if (x.Contains(".bat"))
							continue;
						if (x.Contains(".log"))
							continue;

						int iPos = 999;
						if (!string.IsNullOrEmpty(sFind))
							iPos = sText.IndexOf(sFind);

						if (iPos > -1)
							dtList.Rows.Add(x, ReportType(sType), sDate, s, MonthYear(sDate),
								info.CreationTime.ToShortDateString());

						decimal dPct = iCounter / iLen;

						dPct = dPct * 100M;

						int iPct = (int)dPct;
						backgroundWorker1.ReportProgress(iPct);
					}
					grdList.DataSource = dtList;
				}
				catch (Exception ex)
				{
					Program.ShowError(ex);
					return;
				}
		}


		private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			// Change the value of the ProgressBar to the BackgroundWorker progress.
			progressMain.Value = e.ProgressPercentage;
		}

		#endregion

		#region Events
		private void grdList_SelectionChanged(object sender, EventArgs e)
		{
			DataRow drow = grdList.GetDataRow();
			if (drow == null)
				return;
			string s = drow["FullFileName"].ToString();
			string sContent = File.ReadAllText(s);
			txtContent.Text = sContent;
		}

		private void btnEdit_Click(object sender, EventArgs e)
		{
			System.IO.File.WriteAllText(@"C:\test.txt", txtContent.Text);
			System.Diagnostics.Process.Start(@"C:\test.txt");
		}

		private void ucButton1_Click(object sender, EventArgs e)
		{
			frmSterlingReportsHelp frm = new frmSterlingReportsHelp();
			frm.ShowDialog();

		}

		private void frmSterlingReports_Load(object sender, EventArgs e)
		{
			progressMain.Visible = true;
			backgroundWorker1.RunWorkerAsync();
		}

		private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
		{
			PopulateGrid();
		}

		private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			progressMain.Visible = false;
		}

		private void btnFind_Click(object sender, EventArgs e)
		{
			backgroundWorker1.RunWorkerAsync();
		}
		#endregion




	}
}
