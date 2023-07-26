using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Timers;
using CS2010.CommonWinCtrls;
using CS2010.ArcSys.Business;


namespace CS2010.ArcSys.Win
{
    public partial class frmImportExceptions : frmChildBase
    {
        #region Main Region

        public DataTable dtExceptions;

        public frmImportExceptions()
        {
            InitializeComponent();
        }

        public void ShowForm()
        {
            this.Show();
            this.WindowState = FormWindowState.Maximized;
        }

        #endregion

        #region Searching

        public void SetDataSource(DataTable dt)
        {
            dtExceptions = dt;
            grdAudit.DataSource = dtExceptions;
        }

        public void Search()
        {
            ClsDatabaseExceptions de = new ClsDatabaseExceptions();
            dtExceptions = de.ImportNotes();
            grdAudit.DataSource = dtExceptions;
        }
        
        #endregion

        #region Events
        private void tsSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        #endregion

               

    }
}