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
    public partial class frmIALRecall : frmChildBase
    {

        private bool IsInsert = true;

        private ClsRecall _recalls;

        public frmIALRecall()
        {
            InitializeComponent();
           
        }

        public void ShowForm()
        {
            this.Show();
            FormStateNormal();
            GetRecall();
            GetRecallVin();
        }

        #region Private

        private void BindRecall()
        {
            BindHelper.Bind(txtYear, _recalls, "Vehicle_Year");
            BindHelper.Bind(txtMake, _recalls, "Vehicle_Make");
            BindHelper.Bind(txtModel, _recalls, "Vehicle_Model");
            BindHelper.Bind(cmbActive, _recalls, "Active_Flg");
        }

        private void FormStateUpdate()
        {
            try
            {
                tsbNew.Enabled = tsbEdit.Enabled = grdRecall.Enabled = false;
                tsbSave.Enabled = tsbCancel.Enabled = true;
                ((Control)tabControl.TabPages[1]).Enabled = false;
                txtYear.Enabled = txtMake.Enabled = txtModel.Enabled = cmbActive.Enabled = true;

            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }

        private void FormStateNormal()
        {
            try
            {
                tsbNew.Enabled = tsbEdit.Enabled = grdRecall.Enabled = true;
                tsbSave.Enabled = tsbCancel.Enabled = false;
                ((Control)tabControl.TabPages[1]).Enabled = true;
                txtYear.Enabled = txtMake.Enabled = txtModel.Enabled = cmbActive.Enabled = false;
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }

        private void Insert()
        {
            try
            {
                if (_recalls.Insert() == 1)
                {
                    FormStateNormal();
                    MessageBox.Show("Insert success!");
                    GetRecall();
                    BindRecall();
                }
                else
                {
                    MessageBox.Show("Insert failed!");
                }               
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }

        private new void Update()
        {
            try
            {
                if (_recalls.Update() == 1)
                {
                    FormStateNormal();
                    MessageBox.Show("Update success!");
                    GetRecall();
                    BindRecall();
                }
                else
                {
                    MessageBox.Show("Update failed!");
                }
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }

        private void GetRecall()
        {
            try
            {
                grdRecall.DataSource = ClsRecall.GetAll();
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }

        private void GetRecallVin()
        {
            try
            {
                grdRecallVin.DataSource = ClsRecallVin.GetRecallVINS();
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }

        private new bool Validate()
        {
            try
            {
                string msg;

                if (!_recalls.Validate(out msg))
                {
                    MessageBox.Show(msg);
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
                return false;
            }
        }

        private void ShowRow()
        {
            try
            {
                _recalls = grdRecall.GetCurrentItem<ClsRecall>();

                if (_recalls.IsNull()) return;

                BindRecall();
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }

        private void UnDoVIN()
        {
            try
            {
                ClsRecallVin _recallVIN = grdRecallVin.GetCurrentItem<ClsRecallVin>();

                if (_recallVIN.IsNull()) { return; }

                if (MessageBox.Show(
                        string.Format("Are you sure you want to undo VIN '{0}'?", _recallVIN.Vin),
                        "Un Do",
                        MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    if (_recallVIN.Delete() == 1)
                    {
                        MessageBox.Show("VIN Removed ... This VIN will now show in the Dashboard Query.");
                        GetRecallVin();
                    }
                }
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }
        
        #endregion

        #region Event Handlers
        
        private void tsbNew_Click(object sender, EventArgs e)
        {
            try
            {
                IsInsert = true;
                _recalls = new ClsRecall() { Active_Flg = "Y"};
                BindRecall();
                FormStateUpdate();
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }

        }

        private void tsbEdit_Click(object sender, EventArgs e)
        {
            try
            {
                IsInsert = false;
                FormStateUpdate();
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validate())
                {
                    if (IsInsert)
                        Insert();
                    else
                        Update();
                }
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }

        private void tsbCancel_Click(object sender, EventArgs e)
        {
            try
            {
                ShowRow();
                FormStateNormal();
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }

        private void grdRecall_SelectionChanged(object sender, EventArgs e)
        {
            ShowRow();
        }

        private void grdRecallVin_ColumnButtonClick(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
        {
            UnDoVIN();
        }
        
        #endregion
    }
}
