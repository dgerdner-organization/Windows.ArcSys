using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CS2010.CommonWinCtrls;
using CS2010.ArcSys.Business;
using CS2010.Common;

namespace CS2010.ArcSys.Win
{
    public partial class frmPATLoadDecision : frmDialogBase
    {
        public frmPATLoadDecision()
        {
            InitializeComponent();
        }

        private int createLoad = 0;
        private int nextVersion = 0;

        public bool CreateNewVersion
        {
            get
            {
                return (createLoad == 1);
            }
        }

        public bool LoadVersion
        {
            get
            {
                return (createLoad ==2);
            }
        }

        public int LoadVersionNo
        {
            get
            {
                return (int)cmbLobHeader.CurrentLobHeader().Version_No;
            }
        }

        public long LoadLobHeaderId
        {
            get
            {
                return (long)cmbLobHeader.CurrentLobHeader().Lob_Header_ID;
            }

        }

        public DialogResult ShowForm(string voyageNo, string pol)
        {
            try
            {

                DataTable dt = ClsLobHeader.GetDataTableByVoyagePOL(voyageNo, pol);

                nextVersion = ClsLobHeader.NextVersion(voyageNo, pol);
                SetCreateButtonText();

                if (dt.IsNull())
                    grpLoad.Enabled = false;
                else
                    cmbLobHeader.AddDataTable(dt, "V", "LOB_HEADER_ID");

                this.ShowDialog();
                return this.DialogResult;

            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
                return DialogResult.Cancel;
            }
        }

        private void SetCreateButtonText()
        {
            btnCreate.Text = string.Format("Create Version #{0}", nextVersion);
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            createLoad = 1;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            createLoad = 2;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

    }
}
