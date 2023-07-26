using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CS2010.ArcSys.Business;
using System.Dynamic;
using System.Xml.Serialization;
using System.IO;

namespace CS2010.ArcSys.Win
{
    public partial class frmNHTSARecallEdit : Form
    {
        private ClsNhtsaRecall _recall = null;
        private bool save = false;

        public frmNHTSARecallEdit()
        {
            InitializeComponent();
        }

        public bool ShowOpen(ClsNhtsaRecall recall)
        {
            _recall = recall;
            Bind();
            this.ShowDialog();
            return save;
        }

        #region Private Methods

        private void Bind()
        {
            try
            {
                this.Text = _recall.Car_Year + " " + _recall.Car_Make + " " + _recall.Car_Model;
                cmbStatus.Text = _recall.Recall_Status_Cd;
                grdNotes.DataSource = _recall.NhtsaHistory;
                rtWebResponse.Text = (_recall.Recall_Response_Formatted.IsNotNull()) ? _recall.Recall_Response_Formatted.ToUpper() : "... Recall Not Found";
                rtWebResponseRaw.Text = (_recall.Recall_Response.IsNotNull()) ? _recall.Recall_Response : "... Recall Not Found";
                lblStatus.Text = string.Format(
                    "Recall Level: {0} Keywords: {1}", 
                    _recall.Recall_Risk.Recall_Risk_Dsc, 
                    (_recall.Recall_Keywords.IsNotNull() ? _recall.Recall_Keywords : "-NA-") );

                txtVinUrl.Text = _recall.Detail_Url;
                txtYMMUrl.Text = _recall.Recall_Url;
                txtCustomer.Text = _recall.Customer_Nm;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Save()
        {
            try
            {
                tssStatus.Text = string.Empty;

                if (cmbStatus.SelectedRecallStatusCD.IsNull())
                {
                    MessageBox.Show("Please select a status and try again.");
                    return;
                }

                string msg;

                if (_recall.UpdateStatus(
                    out msg,
                    cmbStatus.SelectedRecallStatus,
                    txtNote.Text.Trim()))
                {
                    // TRUE
                    grdNotes.DataSource = _recall.NhtsaHistory;
                    tssStatus.Text = "Recall Saved ...";
                    save = true;
                    CloseForm();
                }
                else
                {
                    // FALSE
                    tssStatus.Text = "Recall Save Failed ...";
                    save = false;
                    MessageBox.Show(msg);
                }

                // Update Status
                //if (_recall.Recall_Status_Cd != cmbStatus.SelectedRecallStatusCD)
                //{
                //    _recall.Recall_Status_Cd = cmbStatus.SelectedRecallStatusCD;
                //    if (_recall.Update() != 1)
                //    {
                //        MessageBox.Show("Could not update the Recall.");
                //        return;
                //    }
                //    ClsNhtsaRecallHistory h = new ClsNhtsaRecallHistory();
                //    h.Recall_Status_Cd = cmbStatus.SelectedRecallStatusCD;
                //    h.Note_Text = "Status Updated to '" + cmbStatus.SelectedRecallStatus.Recall_Status_Dsc + "'.";
                //    h.Nhtsa_Recall_ID = _recall.Nhtsa_Recall_ID;
                //    h.Remark_Flg = "N";

                //    if (h.Insert() != 1)
                //    {
                //        MessageBox.Show("Could not update Recall Status/Note.");
                //        return;
                //    }
                //}

                //// Add History
                //if (txtNote.Text.Trim().IsNotNull())
                //{
                //    ClsNhtsaRecallHistory h = new ClsNhtsaRecallHistory();
                //    h.Recall_Status_Cd = cmbStatus.SelectedRecallStatusCD;
                //    h.Note_Text = txtNote.Text.Trim();
                //    h.Nhtsa_Recall_ID = _recall.Nhtsa_Recall_ID;
                //    h.Remark_Flg = "Y";

                //    if (h.Insert() != 1)
                //    {
                //        MessageBox.Show("Could not update Recall Status/Note.");
                //        return;
                //    }
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CloseForm()
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SearchKeyword(string word, RichTextBox rtBox)
        {
            // Clear Box
            rtBox.SelectAll();
            rtBox.SelectionBackColor = Color.White;
            
            if (word == string.Empty) return;

            // Find Selection
            int s_start = rtBox.SelectionStart, startIndex = 0, index;

            while ((index = rtBox.Text.IndexOf(word, startIndex)) != -1)
            {
                rtBox.Select(index, word.Length);
                rtBox.SelectionColor = Color.Black;
                rtBox.SelectionBackColor = Color.Yellow;
                startIndex = index + word.Length;
            }

            rtBox.SelectionStart = s_start;
            rtBox.SelectionLength = 0;
            rtBox.SelectionBackColor = Color.White;
            rtBox.SelectionColor = Color.Black;
        }

        #endregion

        #region Event Handlers


        private void btnClose_Click(object sender, EventArgs e)
        {
            CloseForm();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        #endregion
        
        private void txtKeyword_TextChanged(object sender, EventArgs e)
        {
            SearchKeyword(txtKeyword.Text, rtWebResponse);
        }

        private void txtKeywordRaw_TextChanged(object sender, EventArgs e)
        {
            SearchKeyword(txtKeywordRaw.Text, rtWebResponseRaw);
        }


 
    }

}
