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
    public partial class frmUnassignedCargo : frmChildBase
    {
        #region Main Region
        private ClsImportLine import;
        private DataTable dtCargo;

        public frmUnassignedCargo()
        {
            InitializeComponent();
        }

        public void ShowForm()
        {
            this.Show();
            this.WindowState = FormWindowState.Maximized;
            import = new ClsImportLine();
        }
        #endregion

        #region Searching
        private void StartSearchCargo()
        {
            ucProgressBar1.Visible = true;
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += new DoWorkEventHandler(SearchCargo);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
            worker.RunWorkerAsync(); 
        }

        private void SearchCargo(object sender, DoWorkEventArgs e)
        {
            System.Timers.Timer timer = new System.Timers.Timer(1000);  
            timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_elapsed); timer.Start();
            dtCargo = import.GetUnassignedCargo();
            grdCargo.DataSource = dtCargo;
        }
        #endregion

        #region Events
        private void tsSearchCargo_Click(object sender, EventArgs e)
        {
            StartSearchCargo();
        }
        #endregion

        #region Asynch Stuff
        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ucProgressBar1.Value = 0;
            ucProgressBar1.Visible = false;
        }

        private delegate void SetProgressBarDelegate(int currentCount, int totalCount);
        private void SetProgressBar(int currentCount, int totalCount)
        {
            if (InvokeRequired)
            {
                this.BeginInvoke
                    (new SetProgressBarDelegate(SetProgressBar), 
                        new object[] {currentCount, totalCount});
                return;
            }
            ucProgressBar1.Maximum = totalCount;
            ucProgressBar1.Value = currentCount;
        }

        private void timer_elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            // At specific intervals, set the progress bar information
            SetProgressBar(import.QueryCounter, import.QueryTotal);
        }

        #endregion


    }
}