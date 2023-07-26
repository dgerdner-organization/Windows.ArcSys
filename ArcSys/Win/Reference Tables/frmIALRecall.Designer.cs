namespace CS2010.ArcSys.Win
{
    partial class frmIALRecall
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
            Janus.Windows.GridEX.GridEXLayout grdRecall_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIALRecall));
            Janus.Windows.GridEX.GridEXLayout cmbActive_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout grdRecallVin_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tpRecall = new System.Windows.Forms.TabPage();
            this.grdRecall = new CS2010.CommonWinCtrls.ucGridEx();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmbActive = new CS2010.CommonWinCtrls.ucGenericCombo();
            this.txtModel = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtYear = new CS2010.CommonWinCtrls.ucNumericEditBox();
            this.txtMake = new CS2010.CommonWinCtrls.ucTextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbNew = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbEdit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.tsbCancel = new System.Windows.Forms.ToolStripButton();
            this.tpRecallVin = new System.Windows.Forms.TabPage();
            this.lblRecallVin = new System.Windows.Forms.Label();
            this.grdRecallVin = new CS2010.CommonWinCtrls.ucGridEx();
            this.tabControl.SuspendLayout();
            this.tpRecall.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdRecall)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbActive)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.tpRecallVin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdRecallVin)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tpRecall);
            this.tabControl.Controls.Add(this.tpRecallVin);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(941, 561);
            this.tabControl.TabIndex = 0;
            // 
            // tpRecall
            // 
            this.tpRecall.Controls.Add(this.grdRecall);
            this.tpRecall.Controls.Add(this.panel2);
            this.tpRecall.Location = new System.Drawing.Point(4, 22);
            this.tpRecall.Name = "tpRecall";
            this.tpRecall.Padding = new System.Windows.Forms.Padding(3);
            this.tpRecall.Size = new System.Drawing.Size(933, 535);
            this.tpRecall.TabIndex = 0;
            this.tpRecall.Text = "Recalls";
            this.tpRecall.UseVisualStyleBackColor = true;
            // 
            // grdRecall
            // 
            this.grdRecall.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            grdRecall_DesignTimeLayout.LayoutString = resources.GetString("grdRecall_DesignTimeLayout.LayoutString");
            this.grdRecall.DesignTimeLayout = grdRecall_DesignTimeLayout;
            this.grdRecall.ExportFileID = null;
            this.grdRecall.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdRecall.Location = new System.Drawing.Point(6, 3);
            this.grdRecall.Name = "grdRecall";
            this.grdRecall.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
            this.grdRecall.Size = new System.Drawing.Size(924, 353);
            this.grdRecall.TabIndex = 2;
            this.grdRecall.SelectionChanged += new System.EventHandler(this.grdRecall_SelectionChanged);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.cmbActive);
            this.panel2.Controls.Add(this.txtModel);
            this.panel2.Controls.Add(this.txtYear);
            this.panel2.Controls.Add(this.txtMake);
            this.panel2.Controls.Add(this.toolStrip1);
            this.panel2.Location = new System.Drawing.Point(6, 362);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(924, 170);
            this.panel2.TabIndex = 1;
            // 
            // cmbActive
            // 
            this.cmbActive.CodeColumn = "Code";
            this.cmbActive.ComboType = CS2010.CommonWinCtrls.GenericComboType.YesNo;
            this.cmbActive.DescriptionColumn = "Description";
            cmbActive_DesignTimeLayout.LayoutString = resources.GetString("cmbActive_DesignTimeLayout.LayoutString");
            this.cmbActive.DesignTimeLayout = cmbActive_DesignTimeLayout;
            this.cmbActive.DisplayMember = "Code";
            this.cmbActive.LabelText = "Active (?)";
            this.cmbActive.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.cmbActive.Location = new System.Drawing.Point(86, 128);
            this.cmbActive.Name = "cmbActive";
            this.cmbActive.SelectedIndex = -1;
            this.cmbActive.SelectedItem = null;
            this.cmbActive.Size = new System.Drawing.Size(100, 20);
            this.cmbActive.TabIndex = 4;
            this.cmbActive.ValueColumn = "Code";
            this.cmbActive.ValueMember = "Code";
            // 
            // txtModel
            // 
            this.txtModel.LabelText = "Model";
            this.txtModel.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtModel.LinkDisabledMessage = "Link Disabled";
            this.txtModel.Location = new System.Drawing.Point(86, 102);
            this.txtModel.Name = "txtModel";
            this.txtModel.Size = new System.Drawing.Size(240, 20);
            this.txtModel.TabIndex = 3;
            // 
            // txtYear
            // 
            this.txtYear.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtYear.EditMode = Janus.Windows.GridEX.NumericEditMode.Value;
            this.txtYear.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.General;
            this.txtYear.LabelText = "Year";
            this.txtYear.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtYear.Location = new System.Drawing.Point(86, 50);
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(100, 20);
            this.txtYear.TabIndex = 1;
            this.txtYear.Text = "0";
            this.txtYear.Value = 0;
            this.txtYear.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32;
            // 
            // txtMake
            // 
            this.txtMake.LabelText = "Make";
            this.txtMake.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtMake.LinkDisabledMessage = "Link Disabled";
            this.txtMake.Location = new System.Drawing.Point(86, 76);
            this.txtMake.Name = "txtMake";
            this.txtMake.Size = new System.Drawing.Size(240, 20);
            this.txtMake.TabIndex = 2;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNew,
            this.toolStripSeparator1,
            this.tsbEdit,
            this.toolStripSeparator2,
            this.tsbSave,
            this.tsbCancel});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(924, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbNew
            // 
            this.tsbNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbNew.Image = ((System.Drawing.Image)(resources.GetObject("tsbNew.Image")));
            this.tsbNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNew.Name = "tsbNew";
            this.tsbNew.Size = new System.Drawing.Size(32, 22);
            this.tsbNew.Text = "&New";
            this.tsbNew.Click += new System.EventHandler(this.tsbNew_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbEdit
            // 
            this.tsbEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbEdit.Image = ((System.Drawing.Image)(resources.GetObject("tsbEdit.Image")));
            this.tsbEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEdit.Name = "tsbEdit";
            this.tsbEdit.Size = new System.Drawing.Size(29, 22);
            this.tsbEdit.Text = "&Edit";
            this.tsbEdit.Click += new System.EventHandler(this.tsbEdit_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbSave
            // 
            this.tsbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbSave.Image = ((System.Drawing.Image)(resources.GetObject("tsbSave.Image")));
            this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Size = new System.Drawing.Size(35, 22);
            this.tsbSave.Text = "&Save";
            this.tsbSave.Click += new System.EventHandler(this.tsbSave_Click);
            // 
            // tsbCancel
            // 
            this.tsbCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbCancel.Image = ((System.Drawing.Image)(resources.GetObject("tsbCancel.Image")));
            this.tsbCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCancel.Name = "tsbCancel";
            this.tsbCancel.Size = new System.Drawing.Size(43, 22);
            this.tsbCancel.Text = "&Cancel";
            this.tsbCancel.Click += new System.EventHandler(this.tsbCancel_Click);
            // 
            // tpRecallVin
            // 
            this.tpRecallVin.Controls.Add(this.lblRecallVin);
            this.tpRecallVin.Controls.Add(this.grdRecallVin);
            this.tpRecallVin.Location = new System.Drawing.Point(4, 22);
            this.tpRecallVin.Name = "tpRecallVin";
            this.tpRecallVin.Padding = new System.Windows.Forms.Padding(3);
            this.tpRecallVin.Size = new System.Drawing.Size(933, 535);
            this.tpRecallVin.TabIndex = 1;
            this.tpRecallVin.Text = "Reviewed VINs";
            this.tpRecallVin.UseVisualStyleBackColor = true;
            // 
            // lblRecallVin
            // 
            this.lblRecallVin.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRecallVin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecallVin.Location = new System.Drawing.Point(3, 3);
            this.lblRecallVin.Name = "lblRecallVin";
            this.lblRecallVin.Size = new System.Drawing.Size(927, 36);
            this.lblRecallVin.TabIndex = 4;
            this.lblRecallVin.Text = "The following VINS have been (1) reported in the Dashboard, (2) reviewed by Custo" +
                "mer Service and (3) tagged as \'reviewed\'.  Since they are \'reviewed\' they are ex" +
                "cluded from the Dashboard query.";
            this.lblRecallVin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grdRecallVin
            // 
            this.grdRecallVin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            grdRecallVin_DesignTimeLayout.LayoutString = resources.GetString("grdRecallVin_DesignTimeLayout.LayoutString");
            this.grdRecallVin.DesignTimeLayout = grdRecallVin_DesignTimeLayout;
            this.grdRecallVin.ExportFileID = null;
            this.grdRecallVin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdRecallVin.Location = new System.Drawing.Point(6, 42);
            this.grdRecallVin.Name = "grdRecallVin";
            this.grdRecallVin.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
            this.grdRecallVin.Size = new System.Drawing.Size(921, 490);
            this.grdRecallVin.TabIndex = 3;
            this.grdRecallVin.ColumnButtonClick += new Janus.Windows.GridEX.ColumnActionEventHandler(this.grdRecallVin_ColumnButtonClick);
            // 
            // frmIALRecall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 561);
            this.Controls.Add(this.tabControl);
            this.Name = "frmIALRecall";
            this.Text = "IAL Recalls";
            this.tabControl.ResumeLayout(false);
            this.tpRecall.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdRecall)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbActive)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tpRecallVin.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdRecallVin)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tpRecall;
        private System.Windows.Forms.TabPage tpRecallVin;
        private CommonWinCtrls.ucGridEx grdRecall;
        private System.Windows.Forms.Panel panel2;
        private CommonWinCtrls.ucGenericCombo cmbActive;
        private CommonWinCtrls.ucTextBox txtModel;
        private CommonWinCtrls.ucNumericEditBox txtYear;
        private CommonWinCtrls.ucTextBox txtMake;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbNew;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbEdit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private System.Windows.Forms.ToolStripButton tsbCancel;
        private CommonWinCtrls.ucGridEx grdRecallVin;
        private System.Windows.Forms.Label lblRecallVin;
    }
}