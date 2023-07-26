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
    public partial class frmViewAudit : frmChildBase
    {
        #region Main Region
        private string TableName;

        public frmViewAudit()
        {
            InitializeComponent();
        }

        public void ShowForm(string tableNm)
        {
            //
            // You can use this window by calling ShowForm with a string
            // for the table name.
            //
            // Or, you can call ShowForm with no parameter, then add a
            // Searchxxx() method and call it, passing it alternative info.
            //
            TableName = tableNm;
            SetTitle(tableNm);
            ShowForm();
            Search();
        }
        public void ShowForm()
        {
            this.Show();
            this.WindowState = FormWindowState.Maximized;
        }

        private void SetTitle(string AdditionalText)
        {
            this.Text = "Change History " + AdditionalText;
        }
        #endregion

        #region Searching

        public void Search()
        {
            DataTable dt = ClsAuditTrail.GetForTable(TableName);
            grdAudit.DataSource = dt;
        }

        public void SearchCargo(ClsCargo Cargo)
        {
            grdAudit.DataSource = Cargo.dtCargoChanges;
            SetTitle("Serial# " + Cargo.Serial_No);
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