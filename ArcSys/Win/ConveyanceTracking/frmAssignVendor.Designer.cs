namespace CS2010.ArcSys.Win
{
	partial class frmAssignVendor
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
            Janus.Windows.GridEX.GridEXLayout cmbMoves_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAssignVendor));
            Janus.Windows.GridEX.GridEXLayout cmbVendor_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout grdCargo_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            this.txtShipper = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtOrigin = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtDestination = new CS2010.CommonWinCtrls.ucTextBox();
            this.pnlHeader = new CS2010.CommonWinCtrls.ucPanel();
            this.rbNew = new CS2010.CommonWinCtrls.ucRadioButton();
            this.rbExisting = new CS2010.CommonWinCtrls.ucRadioButton();
            this.txtMoveDsc = new CS2010.CommonWinCtrls.ucTextBox();
            this.cmbMoves = new CS2010.CommonWinCtrls.ucMultiColumnCombo();
            this.cmbVendor = new CS2010.ArcSys.WinCtrls.ucVendorCombo();
            this.grdCargo = new CS2010.CommonWinCtrls.ucGridEx();
            this.btnEasySelect = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbMoves)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbVendor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdCargo)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(624, 12);
            this.btnOK.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(624, 41);
            this.btnCancel.TabIndex = 2;
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(624, 70);
            this.btnApply.TabIndex = 3;
            this.btnApply.TabStop = true;
            this.btnApply.UseVisualStyleBackColor = false;
            // 
            // txtShipper
            // 
            this.txtShipper.BackColor = System.Drawing.SystemColors.Control;
            this.txtShipper.ForeColor = System.Drawing.Color.Black;
            this.txtShipper.LabelText = "Shipper";
            this.txtShipper.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtShipper.LinkDisabledMessage = "Link Disabled";
            this.txtShipper.Location = new System.Drawing.Point(67, 7);
            this.txtShipper.Name = "txtShipper";
            this.txtShipper.ReadOnly = true;
            this.txtShipper.Size = new System.Drawing.Size(268, 20);
            this.txtShipper.TabIndex = 1;
            this.txtShipper.TabStop = false;
            // 
            // txtOrigin
            // 
            this.txtOrigin.BackColor = System.Drawing.SystemColors.Control;
            this.txtOrigin.ForeColor = System.Drawing.Color.Black;
            this.txtOrigin.LabelText = "Origin";
            this.txtOrigin.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtOrigin.LinkDisabledMessage = "Link Disabled";
            this.txtOrigin.Location = new System.Drawing.Point(67, 31);
            this.txtOrigin.Name = "txtOrigin";
            this.txtOrigin.ReadOnly = true;
            this.txtOrigin.Size = new System.Drawing.Size(268, 20);
            this.txtOrigin.TabIndex = 2;
            this.txtOrigin.TabStop = false;
            // 
            // txtDestination
            // 
            this.txtDestination.BackColor = System.Drawing.SystemColors.Control;
            this.txtDestination.ForeColor = System.Drawing.Color.Black;
            this.txtDestination.LabelText = "Destination";
            this.txtDestination.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtDestination.LinkDisabledMessage = "Link Disabled";
            this.txtDestination.Location = new System.Drawing.Point(67, 56);
            this.txtDestination.Name = "txtDestination";
            this.txtDestination.ReadOnly = true;
            this.txtDestination.Size = new System.Drawing.Size(268, 20);
            this.txtDestination.TabIndex = 3;
            this.txtDestination.TabStop = false;
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.btnEasySelect);
            this.pnlHeader.Controls.Add(this.rbNew);
            this.pnlHeader.Controls.Add(this.rbExisting);
            this.pnlHeader.Controls.Add(this.txtMoveDsc);
            this.pnlHeader.Controls.Add(this.cmbMoves);
            this.pnlHeader.Controls.Add(this.txtDestination);
            this.pnlHeader.Controls.Add(this.txtOrigin);
            this.pnlHeader.Controls.Add(this.cmbVendor);
            this.pnlHeader.Controls.Add(this.txtShipper);
            this.pnlHeader.Location = new System.Drawing.Point(5, 1);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(471, 170);
            this.pnlHeader.TabIndex = 0;
            // 
            // rbNew
            // 
            this.rbNew.Location = new System.Drawing.Point(177, 85);
            this.rbNew.Name = "rbNew";
            this.rbNew.Size = new System.Drawing.Size(104, 22);
            this.rbNew.TabIndex = 5;
            this.rbNew.Text = "New Move";
            this.rbNew.UseVisualStyleBackColor = true;
            this.rbNew.CheckedChanged += new System.EventHandler(this.rbNew_CheckedChanged);
            // 
            // rbExisting
            // 
            this.rbExisting.Checked = true;
            this.rbExisting.Location = new System.Drawing.Point(67, 85);
            this.rbExisting.Name = "rbExisting";
            this.rbExisting.Size = new System.Drawing.Size(104, 22);
            this.rbExisting.TabIndex = 4;
            this.rbExisting.TabStop = true;
            this.rbExisting.Text = "Existing Move";
            this.rbExisting.UseVisualStyleBackColor = true;
            this.rbExisting.CheckedChanged += new System.EventHandler(this.rbExisting_CheckedChanged);
            // 
            // txtMoveDsc
            // 
            this.txtMoveDsc.LabelText = "Move";
            this.txtMoveDsc.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtMoveDsc.LinkDisabledMessage = "Link Disabled";
            this.txtMoveDsc.Location = new System.Drawing.Point(67, 110);
            this.txtMoveDsc.Name = "txtMoveDsc";
            this.txtMoveDsc.Size = new System.Drawing.Size(268, 20);
            this.txtMoveDsc.TabIndex = 6;
            this.txtMoveDsc.Visible = false;
            // 
            // cmbMoves
            // 
            cmbMoves_DesignTimeLayout.LayoutString = resources.GetString("cmbMoves_DesignTimeLayout.LayoutString");
            this.cmbMoves.DesignTimeLayout = cmbMoves_DesignTimeLayout;
            this.cmbMoves.DisplayMember = "move_dsc";
            this.cmbMoves.LabelText = "Move";
            this.cmbMoves.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.cmbMoves.Location = new System.Drawing.Point(67, 110);
            this.cmbMoves.Name = "cmbMoves";
            this.cmbMoves.SelectedIndex = -1;
            this.cmbMoves.SelectedItem = null;
            this.cmbMoves.Size = new System.Drawing.Size(268, 20);
            this.cmbMoves.TabIndex = 8;
            this.cmbMoves.ValueMember = "move_id";
            // 
            // cmbVendor
            // 
            this.cmbVendor.CodeColumn = "Vendor_Cd";
            this.cmbVendor.DescriptionColumn = "Vendor_Nm";
            cmbVendor_DesignTimeLayout.LayoutString = resources.GetString("cmbVendor_DesignTimeLayout.LayoutString");
            this.cmbVendor.DesignTimeLayout = cmbVendor_DesignTimeLayout;
            this.cmbVendor.DisplayMember = "Vendor_Cd";
            this.cmbVendor.LabelText = "Vendor";
            this.cmbVendor.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.cmbVendor.Location = new System.Drawing.Point(67, 135);
            this.cmbVendor.Name = "cmbVendor";
            this.cmbVendor.SelectedIndex = -1;
            this.cmbVendor.SelectedItem = null;
            this.cmbVendor.Size = new System.Drawing.Size(100, 20);
            this.cmbVendor.TabIndex = 7;
            this.cmbVendor.ValueColumn = "Vendor_Cd";
            this.cmbVendor.ValueMember = "Vendor_Cd";
            // 
            // grdCargo
            // 
            grdCargo_DesignTimeLayout.LayoutString = resources.GetString("grdCargo_DesignTimeLayout.LayoutString");
            this.grdCargo.DesignTimeLayout = grdCargo_DesignTimeLayout;
            this.grdCargo.ExportFileID = null;
            this.grdCargo.Location = new System.Drawing.Point(5, 177);
            this.grdCargo.Name = "grdCargo";
            this.grdCargo.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
            this.grdCargo.Size = new System.Drawing.Size(721, 366);
            this.grdCargo.TabIndex = 4;
            // 
            // btnEasySelect
            // 
            this.btnEasySelect.Location = new System.Drawing.Point(341, 110);
            this.btnEasySelect.Name = "btnEasySelect";
            this.btnEasySelect.Size = new System.Drawing.Size(23, 19);
            this.btnEasySelect.TabIndex = 9;
            this.btnEasySelect.Text = "...";
            this.btnEasySelect.UseVisualStyleBackColor = true;
            this.btnEasySelect.Click += new System.EventHandler(this.btnEasySelect_Click);
            // 
            // frmAssignVendor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 547);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.grdCargo);
            this.Name = "frmAssignVendor";
            this.Text = "Assign Vendor";
            this.Controls.SetChildIndex(this.grdCargo, 0);
            this.Controls.SetChildIndex(this.btnApply, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.btnOK, 0);
            this.Controls.SetChildIndex(this.pnlHeader, 0);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbMoves)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbVendor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdCargo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

		private WinCtrls.ucVendorCombo cmbVendor;
		private CommonWinCtrls.ucTextBox txtShipper;
		private CommonWinCtrls.ucTextBox txtOrigin;
		private CommonWinCtrls.ucTextBox txtDestination;
		private CommonWinCtrls.ucPanel pnlHeader;
		private CommonWinCtrls.ucGridEx grdCargo;
		private CommonWinCtrls.ucMultiColumnCombo cmbMoves;
		private CommonWinCtrls.ucRadioButton rbNew;
		private CommonWinCtrls.ucRadioButton rbExisting;
		private CommonWinCtrls.ucTextBox txtMoveDsc;
        private System.Windows.Forms.Button btnEasySelect;

	}
}