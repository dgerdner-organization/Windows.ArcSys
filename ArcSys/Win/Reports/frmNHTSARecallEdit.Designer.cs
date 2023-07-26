namespace CS2010.ArcSys.Win
{
    partial class frmNHTSARecallEdit
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Janus.Windows.GridEX.GridEXLayout cmbStatus_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNHTSARecallEdit));
            Janus.Windows.GridEX.GridEXLayout grdNotes_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpRecall = new System.Windows.Forms.TabPage();
            this.lblStatus = new System.Windows.Forms.Label();
            this.txtNote = new CS2010.CommonWinCtrls.ucTextBox();
            this.cmbStatus = new CS2010.ArcSys.WinCtrls.ucRecallStatusCombo();
            this.btnSave = new System.Windows.Forms.Button();
            this.tpHistory = new System.Windows.Forms.TabPage();
            this.grdNotes = new CS2010.CommonWinCtrls.ucGridEx();
            this.tpData = new System.Windows.Forms.TabPage();
            this.txtKeyword = new CS2010.CommonWinCtrls.ucTextBox();
            this.rtWebResponse = new System.Windows.Forms.RichTextBox();
            this.tpRecallTextRaw = new System.Windows.Forms.TabPage();
            this.txtKeywordRaw = new CS2010.CommonWinCtrls.ucTextBox();
            this.rtWebResponseRaw = new System.Windows.Forms.RichTextBox();
            this.tpMisc = new System.Windows.Forms.TabPage();
            this.txtCustomer = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtYMMUrl = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtVinUrl = new CS2010.CommonWinCtrls.ucTextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tssStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControl1.SuspendLayout();
            this.tpRecall.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbStatus)).BeginInit();
            this.tpHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdNotes)).BeginInit();
            this.tpData.SuspendLayout();
            this.tpRecallTextRaw.SuspendLayout();
            this.tpMisc.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tpRecall);
            this.tabControl1.Controls.Add(this.tpHistory);
            this.tabControl1.Controls.Add(this.tpData);
            this.tabControl1.Controls.Add(this.tpRecallTextRaw);
            this.tabControl1.Controls.Add(this.tpMisc);
            this.tabControl1.Location = new System.Drawing.Point(2, 5);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(880, 496);
            this.tabControl1.TabIndex = 0;
            // 
            // tpRecall
            // 
            this.tpRecall.Controls.Add(this.lblStatus);
            this.tpRecall.Controls.Add(this.txtNote);
            this.tpRecall.Controls.Add(this.cmbStatus);
            this.tpRecall.Controls.Add(this.btnSave);
            this.tpRecall.Location = new System.Drawing.Point(4, 22);
            this.tpRecall.Name = "tpRecall";
            this.tpRecall.Padding = new System.Windows.Forms.Padding(3);
            this.tpRecall.Size = new System.Drawing.Size(872, 470);
            this.tpRecall.TabIndex = 0;
            this.tpRecall.Text = "Status / Notes";
            this.tpRecall.UseVisualStyleBackColor = true;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(345, 25);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 16);
            this.lblStatus.TabIndex = 16;
            // 
            // txtNote
            // 
            this.txtNote.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNote.LabelAlignment = CS2010.CommonWinCtrls.Orientation.Top;
            this.txtNote.LabelText = "Note";
            this.txtNote.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtNote.LinkDisabledMessage = "Link Disabled";
            this.txtNote.Location = new System.Drawing.Point(7, 67);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(856, 368);
            this.txtNote.TabIndex = 15;
            // 
            // cmbStatus
            // 
            this.cmbStatus.CodeColumn = "Recall_Status_Cd";
            this.cmbStatus.DescriptionColumn = "Recall_Status_Dsc";
            cmbStatus_DesignTimeLayout.LayoutString = resources.GetString("cmbStatus_DesignTimeLayout.LayoutString");
            this.cmbStatus.DesignTimeLayout = cmbStatus_DesignTimeLayout;
            this.cmbStatus.DisplayMember = "Recall_Status_Dsc";
            this.cmbStatus.DisplayType = CS2010.CommonWinCtrls.ComboDisplay.DescriptionOnly;
            this.cmbStatus.LabelAlignment = CS2010.CommonWinCtrls.Orientation.Top;
            this.cmbStatus.LabelText = "Status";
            this.cmbStatus.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.cmbStatus.Location = new System.Drawing.Point(7, 22);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.SelectedIndex = -1;
            this.cmbStatus.SelectedItem = null;
            this.cmbStatus.Size = new System.Drawing.Size(304, 20);
            this.cmbStatus.TabIndex = 1;
            this.cmbStatus.ValueColumn = "Recall_Status_Cd";
            this.cmbStatus.ValueMember = "Recall_Status_Cd";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(788, 441);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tpHistory
            // 
            this.tpHistory.Controls.Add(this.grdNotes);
            this.tpHistory.Location = new System.Drawing.Point(4, 22);
            this.tpHistory.Name = "tpHistory";
            this.tpHistory.Padding = new System.Windows.Forms.Padding(3);
            this.tpHistory.Size = new System.Drawing.Size(872, 470);
            this.tpHistory.TabIndex = 2;
            this.tpHistory.Text = "History";
            this.tpHistory.UseVisualStyleBackColor = true;
            // 
            // grdNotes
            // 
            grdNotes_DesignTimeLayout.LayoutString = resources.GetString("grdNotes_DesignTimeLayout.LayoutString");
            this.grdNotes.DesignTimeLayout = grdNotes_DesignTimeLayout;
            this.grdNotes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdNotes.ExportFileID = null;
            this.grdNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.grdNotes.GroupByBoxVisible = false;
            this.grdNotes.Location = new System.Drawing.Point(3, 3);
            this.grdNotes.Name = "grdNotes";
            this.grdNotes.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
            this.grdNotes.Size = new System.Drawing.Size(866, 464);
            this.grdNotes.TabIndex = 15;
            // 
            // tpData
            // 
            this.tpData.Controls.Add(this.txtKeyword);
            this.tpData.Controls.Add(this.rtWebResponse);
            this.tpData.Location = new System.Drawing.Point(4, 22);
            this.tpData.Name = "tpData";
            this.tpData.Padding = new System.Windows.Forms.Padding(3);
            this.tpData.Size = new System.Drawing.Size(872, 470);
            this.tpData.TabIndex = 1;
            this.tpData.Text = "Recall Text";
            this.tpData.UseVisualStyleBackColor = true;
            // 
            // txtKeyword
            // 
            this.txtKeyword.LabelAlignment = CS2010.CommonWinCtrls.Orientation.Top;
            this.txtKeyword.LabelText = "Keyword";
            this.txtKeyword.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtKeyword.LinkDisabledMessage = "Link Disabled";
            this.txtKeyword.Location = new System.Drawing.Point(6, 24);
            this.txtKeyword.Name = "txtKeyword";
            this.txtKeyword.Size = new System.Drawing.Size(255, 20);
            this.txtKeyword.TabIndex = 2;
            this.txtKeyword.TextChanged += new System.EventHandler(this.txtKeyword_TextChanged);
            // 
            // rtWebResponse
            // 
            this.rtWebResponse.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rtWebResponse.Location = new System.Drawing.Point(3, 50);
            this.rtWebResponse.Name = "rtWebResponse";
            this.rtWebResponse.Size = new System.Drawing.Size(861, 414);
            this.rtWebResponse.TabIndex = 0;
            this.rtWebResponse.Text = "";
            // 
            // tpRecallTextRaw
            // 
            this.tpRecallTextRaw.Controls.Add(this.txtKeywordRaw);
            this.tpRecallTextRaw.Controls.Add(this.rtWebResponseRaw);
            this.tpRecallTextRaw.Location = new System.Drawing.Point(4, 22);
            this.tpRecallTextRaw.Name = "tpRecallTextRaw";
            this.tpRecallTextRaw.Padding = new System.Windows.Forms.Padding(3);
            this.tpRecallTextRaw.Size = new System.Drawing.Size(872, 470);
            this.tpRecallTextRaw.TabIndex = 3;
            this.tpRecallTextRaw.Text = "Recall Text (Raw)";
            this.tpRecallTextRaw.UseVisualStyleBackColor = true;
            // 
            // txtKeywordRaw
            // 
            this.txtKeywordRaw.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtKeywordRaw.LabelAlignment = CS2010.CommonWinCtrls.Orientation.Top;
            this.txtKeywordRaw.LabelText = "Keyword";
            this.txtKeywordRaw.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtKeywordRaw.LinkDisabledMessage = "Link Disabled";
            this.txtKeywordRaw.Location = new System.Drawing.Point(6, 24);
            this.txtKeywordRaw.Name = "txtKeywordRaw";
            this.txtKeywordRaw.Size = new System.Drawing.Size(255, 20);
            this.txtKeywordRaw.TabIndex = 5;
            this.txtKeywordRaw.TextChanged += new System.EventHandler(this.txtKeywordRaw_TextChanged);
            // 
            // rtWebResponseRaw
            // 
            this.rtWebResponseRaw.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rtWebResponseRaw.Location = new System.Drawing.Point(3, 50);
            this.rtWebResponseRaw.Name = "rtWebResponseRaw";
            this.rtWebResponseRaw.Size = new System.Drawing.Size(861, 414);
            this.rtWebResponseRaw.TabIndex = 3;
            this.rtWebResponseRaw.Text = "";
            // 
            // tpMisc
            // 
            this.tpMisc.Controls.Add(this.txtCustomer);
            this.tpMisc.Controls.Add(this.txtYMMUrl);
            this.tpMisc.Controls.Add(this.txtVinUrl);
            this.tpMisc.Location = new System.Drawing.Point(4, 22);
            this.tpMisc.Name = "tpMisc";
            this.tpMisc.Padding = new System.Windows.Forms.Padding(3);
            this.tpMisc.Size = new System.Drawing.Size(872, 470);
            this.tpMisc.TabIndex = 4;
            this.tpMisc.Text = "Miscellaneous";
            this.tpMisc.UseVisualStyleBackColor = true;
            // 
            // txtCustomer
            // 
            this.txtCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCustomer.LabelAlignment = CS2010.CommonWinCtrls.Orientation.Top;
            this.txtCustomer.LabelText = "Customer";
            this.txtCustomer.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtCustomer.LinkDisabledMessage = "Link Disabled";
            this.txtCustomer.Location = new System.Drawing.Point(6, 103);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Size = new System.Drawing.Size(858, 20);
            this.txtCustomer.TabIndex = 5;
            // 
            // txtYMMUrl
            // 
            this.txtYMMUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtYMMUrl.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtYMMUrl.LabelAlignment = CS2010.CommonWinCtrls.Orientation.Top;
            this.txtYMMUrl.LabelText = "Year/Make/Modle Url";
            this.txtYMMUrl.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtYMMUrl.LinkDisabledMessage = "Link Disabled";
            this.txtYMMUrl.Location = new System.Drawing.Point(6, 63);
            this.txtYMMUrl.Name = "txtYMMUrl";
            this.txtYMMUrl.Size = new System.Drawing.Size(858, 20);
            this.txtYMMUrl.TabIndex = 4;
            // 
            // txtVinUrl
            // 
            this.txtVinUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtVinUrl.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtVinUrl.LabelAlignment = CS2010.CommonWinCtrls.Orientation.Top;
            this.txtVinUrl.LabelText = "Vin Url";
            this.txtVinUrl.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtVinUrl.LinkDisabledMessage = "Link Disabled";
            this.txtVinUrl.Location = new System.Drawing.Point(6, 23);
            this.txtVinUrl.Name = "txtVinUrl";
            this.txtVinUrl.Size = new System.Drawing.Size(858, 20);
            this.txtVinUrl.TabIndex = 3;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 504);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(882, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tssStatus
            // 
            this.tssStatus.Name = "tssStatus";
            this.tssStatus.Size = new System.Drawing.Size(867, 17);
            this.tssStatus.Spring = true;
            this.tssStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmNHTSARecallEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 526);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControl1);
            this.MinimizeBox = false;
            this.Name = "frmNHTSARecallEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmNHTSARecallEdit";
            this.tabControl1.ResumeLayout(false);
            this.tpRecall.ResumeLayout(false);
            this.tpRecall.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbStatus)).EndInit();
            this.tpHistory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdNotes)).EndInit();
            this.tpData.ResumeLayout(false);
            this.tpData.PerformLayout();
            this.tpRecallTextRaw.ResumeLayout(false);
            this.tpRecallTextRaw.PerformLayout();
            this.tpMisc.ResumeLayout(false);
            this.tpMisc.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpRecall;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TabPage tpData;
        private System.Windows.Forms.RichTextBox rtWebResponse;
        private WinCtrls.ucRecallStatusCombo cmbStatus;
        private CommonWinCtrls.ucTextBox txtNote;
        private CommonWinCtrls.ucTextBox txtKeyword;
        private System.Windows.Forms.TabPage tpHistory;
        private CommonWinCtrls.ucGridEx grdNotes;
        private System.Windows.Forms.TabPage tpRecallTextRaw;
        private CommonWinCtrls.ucTextBox txtKeywordRaw;
        private System.Windows.Forms.RichTextBox rtWebResponseRaw;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tssStatus;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TabPage tpMisc;
        private CommonWinCtrls.ucTextBox txtYMMUrl;
        private CommonWinCtrls.ucTextBox txtVinUrl;
        private CommonWinCtrls.ucTextBox txtCustomer;

    }
}