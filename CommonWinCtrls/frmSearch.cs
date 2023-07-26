using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CS2010.Common;
using System.Runtime.InteropServices;

namespace CS2010.CommonWinCtrls
{
    public partial class frmSearch : Form
    {

        private delegate void SearchCompleteDelegate(SearchEventArgs e, bool Success);
        private SearchCompleteDelegate searchCompleteDelegate;

        #region Properties

		private DataTable _DT = new DataTable();
		private DataRow _DR;

        private sql_base _sql_base;

        public sql_base SQL_BASE
        {
            get { return _sql_base; }
            set { _sql_base = value; }
        }

        public string WINDOW_TITLE
        {
            get { return this.Text; }
            set { this.Text = value; }
        }

		public DataTable DT
		{
			get { return _DT; }
			set { _DT = value; grdResults.DataSource = _DT; }
		}

		public DataRow DR
		{
			get { return _DR; }
		}

		public bool BUTTON_SEARCH_VISIBLE
		{
			get { return this.tsbSearch.Visible; }
			set { tsbSearch.Visible = value; }
		}

		public bool BUTTON_CLEAR_VISIBLE
		{
			get { return Visible; }
			set { tsbClear.Visible = value; }
		}

		#endregion

		#region Virtual Methods

        protected virtual bool SearchData() { return true; }
		protected virtual bool ClearData() { return true; }
		protected virtual void RowChanged(DataRow dr) {  }
        protected virtual void LinkClicked(DataRow dr, string Key) {  }
        protected virtual void ButtonClicked(DataRow dr, string Key) { } 

		#endregion

		#region Constructor

        public frmSearch()
		{
			InitializeComponent();
			grdResults.DataSource = _DT;
			FormStateNormal();
		}		

		#endregion

		#region Private Methods

		private void FormStateNormal()
		{
			tsbSearch.Enabled =
			tsbClear.Enabled =
            gbSearch.Enabled =
            gbResults.Enabled = 
            btnSearch.Enabled = 
            btnClear.Enabled = true;

            tsbCancel.Visible = tsbCancel.Enabled =
            tsProgress.Visible = tsProgress.Enabled = false;

		}

		private void FormStateSearch()
		{
			tsbSearch.Enabled =
			tsbClear.Enabled =
            gbSearch.Enabled = 
            gbResults.Enabled = 
            btnSearch.Enabled = 
            btnClear.Enabled = false;

            tsbCancel.Visible = tsbCancel.Enabled =
            tsProgress.Visible = tsProgress.Enabled = true;

		}

		private void _SelectionChanged()
		{
			DataRow DR_TEMP = grdResults.GetDataRow();

			if( DR_TEMP == null ) return;
			
			_DR = DR_TEMP;
			RowChanged(DR_TEMP);
		}

        private void _LinkClicked(string Key)
        {
            DataRow DR_TEMP = grdResults.GetDataRow();

            if (DR_TEMP == null) return;

            _DR = DR_TEMP;
            LinkClicked(DR_TEMP, Key);
        }

        private void _ButtonClicked(string Key)
        {
            DataRow DR_TEMP = grdResults.GetDataRow();

            if (DR_TEMP == null) return;

            _DR = DR_TEMP;
            ButtonClicked(DR_TEMP, Key);
        }

        private void Search()
        {
            if (SQL_BASE.IsNull()) return;

            FormStateSearch();
            _sql_base.SearchStatus += new sql_base.SearchEventHandler(SearchStatus);
            if (SearchData()) grdResults.Refresh();
        }

        private void _AbortQuery()
        {
            _sql_base.Abort();
            FormStateNormal();
        }

        private void ResizeControls()
        {
            int w = gbSearch.Width;
            int h = gbSearch.Height;

            btnSearch.Left = w - btnSearch.Width - 10;
            btnSearch.Top = h - btnSearch.Height - btnClear.Height - 10;

            btnClear.Left = w - btnClear.Width - 10;
            btnClear.Top = h - btnClear.Height - 5;

        }

        #endregion

		#region Event Handlers

		private void tsbSEARCH_Click(object sender, EventArgs e)
		{
            Search();
		}

		private void tsbCLEAR_Click(object sender, EventArgs e)
		{
			ClearData();
		}		

		private void grdResults_SelectionChanged(object sender, EventArgs e)
		{
			_SelectionChanged();
		}

        private void grdResults_LinkClicked(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
        {
            _LinkClicked(e.Column.Key);
        }

        private void grdResults_ColumnButtonClick(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
        {
            _ButtonClicked(e.Column.Key);
        }

        private void tsbCancel_Click(object sender, EventArgs e)
        {
            _AbortQuery();
        }

        private void frmSearch_Load(object sender, EventArgs e)
        {
            searchCompleteDelegate = new SearchCompleteDelegate(SearchComplete);
            
        }

        private void SearchComplete(SearchEventArgs e, bool Success)
        {
            if (Success)
                DT = e.Data;
            else
            {
                // What do I want to do on a fail ...
            }

            _sql_base.SearchStatus -= new sql_base.SearchEventHandler(SearchStatus);
            FormStateNormal();
        }

        private void SearchStatus(object o, SearchEventArgs e)
        {
            Invoke(searchCompleteDelegate, new object[] { e, (e.Status == SearchStatusCd.Complete) });
        }

        private void frmSearch_FormClosing(object sender, FormClosingEventArgs e)
        {
            // if 'CANCEL' button is enabled then we are running a search and do not want the user to close the window ...
            e.Cancel = tsbCancel.Enabled;
        }

        #endregion

        #region Protected Methods

        protected void ViewFile(string Folder, string FileNm)
        {
            string shellFileName = string.Format("{0}\\{1}", Folder, FileNm);

            frmSearch.ShellExecute(this.Handle, "open", shellFileName, "", "", 3);

            //System.Diagnostics.Process.Start(shellFileName);
        }

        protected void ReRunSearch()
        {
            Search();
        }

        #endregion

        [DllImport("Shell32.dll", CharSet = CharSet.Auto)]
        protected static extern IntPtr ShellExecute(
            IntPtr hwnd,
            string lpVerb,
            string lpFile,
            string lpParameters,
            string lpDirectory,
            int nShowCmd);

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearData();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void gbSearch_Resize(object sender, EventArgs e)
        {
            ResizeControls();
        }

    }
}
