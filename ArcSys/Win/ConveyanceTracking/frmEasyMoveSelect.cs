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

namespace CS2010.ArcSys.Win
{
    public partial class frmEasyMoveSelect : Form
    {
        public frmEasyMoveSelect()
        {
            InitializeComponent();
        }

        #region Properties and Variables

        private bool blnAccept = false;

        private string _SelectedMove;
        public string SelectedMove
        {
            get
            {
                return _SelectedMove;
            }
        }

        private DataRow _SelectedRow;
        public DataRow SelectedRow
        {
            get
            {
                return _SelectedRow;
            }
        }

        #endregion

        #region Methods

        public bool ShowForm(DataTable dt)
        {
            try
            {
                grdData.DataSource = dt;
                this.ShowDialog();
                return blnAccept;
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
                return false;
            }
        }

        private void SelectRow()
        {
            try
            {
                _SelectedRow = (DataRow)grdData.GetDataRow();
                if (_SelectedRow.IsNotNull()) _SelectedMove = _SelectedRow[1].ToString();
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }

        private void CloseOK()
        {
            try
            {
                SelectRow();
                if (_SelectedRow.IsNotNull())
                {
                    blnAccept = true;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }

        private void CloseCancel()
        {
            try
            {
                _SelectedRow = null;
                _SelectedMove = string.Empty;
                blnAccept = false;
                this.Close();
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }       

        #endregion

        #region Event Handlers


        private void btnOK_Click(object sender, EventArgs e)
        {
            CloseOK();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            CloseCancel();
        }

        private void grdData_RowDoubleClick(object sender, Janus.Windows.GridEX.RowActionEventArgs e)
        {
            CloseOK();
        }

        #endregion


    }
}
