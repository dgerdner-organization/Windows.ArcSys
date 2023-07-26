namespace CS2010.ArcSys.Win
{
	partial class frmEditIALDetail
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
            Janus.Windows.GridEX.GridEXLayout cmbTypeDtl_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditIALDetail));
            this.txtVIN = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtBookingNo = new CS2010.CommonWinCtrls.ucTextBox();
            this.cbxProcessed = new CS2010.CommonWinCtrls.ucCheckBox();
            this.ucGroupBox1 = new CS2010.CommonWinCtrls.ucGroupBox();
            this.txtHeight = new CS2010.CommonWinCtrls.ucTextBox();
            this.cmbTypeDtl = new CS2010.CommonWinCtrls.ucMultiColumnCombo();
            this.txtVINSI = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtBookingNoSI = new CS2010.CommonWinCtrls.ucTextBox();
            this.ucGroupBox2 = new CS2010.CommonWinCtrls.ucGroupBox();
            this.txtLastNm = new CS2010.CommonWinCtrls.ucTextBox();
            this.cbxProcessedSI = new CS2010.CommonWinCtrls.ucCheckBox();
            this.btnDelete = new CS2010.CommonWinCtrls.ucButton();
            this.txtYear = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtMake = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtModel = new CS2010.CommonWinCtrls.ucTextBox();
            this.ucGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTypeDtl)).BeginInit();
            this.ucGroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(21, 363);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(111, 363);
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(242, 363);
            this.btnApply.TabStop = true;
            this.btnApply.UseVisualStyleBackColor = false;
            // 
            // txtVIN
            // 
            this.txtVIN.LabelText = "VIN";
            this.txtVIN.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtVIN.LinkDisabledMessage = "Link Disabled";
            this.txtVIN.Location = new System.Drawing.Point(76, 17);
            this.txtVIN.Name = "txtVIN";
            this.txtVIN.Size = new System.Drawing.Size(177, 20);
            this.txtVIN.TabIndex = 3;
            this.txtVIN.TextChanged += new System.EventHandler(this.txtVIN_TextChanged);
            // 
            // txtBookingNo
            // 
            this.txtBookingNo.LabelText = "Booking#";
            this.txtBookingNo.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtBookingNo.LinkDisabledMessage = "Link Disabled";
            this.txtBookingNo.Location = new System.Drawing.Point(76, 40);
            this.txtBookingNo.Name = "txtBookingNo";
            this.txtBookingNo.Size = new System.Drawing.Size(177, 20);
            this.txtBookingNo.TabIndex = 4;
            this.txtBookingNo.TextChanged += new System.EventHandler(this.txtBookingNo_TextChanged);
            // 
            // cbxProcessed
            // 
            this.cbxProcessed.Location = new System.Drawing.Point(76, 181);
            this.cbxProcessed.Name = "cbxProcessed";
            this.cbxProcessed.Size = new System.Drawing.Size(104, 24);
            this.cbxProcessed.TabIndex = 5;
            this.cbxProcessed.Text = "Processed?";
            this.cbxProcessed.UseVisualStyleBackColor = true;
            this.cbxProcessed.YN = "N";
            // 
            // ucGroupBox1
            // 
            this.ucGroupBox1.Controls.Add(this.txtModel);
            this.ucGroupBox1.Controls.Add(this.txtMake);
            this.ucGroupBox1.Controls.Add(this.txtYear);
            this.ucGroupBox1.Controls.Add(this.txtHeight);
            this.ucGroupBox1.Controls.Add(this.cbxProcessed);
            this.ucGroupBox1.Controls.Add(this.cmbTypeDtl);
            this.ucGroupBox1.Controls.Add(this.txtBookingNo);
            this.ucGroupBox1.Controls.Add(this.txtVIN);
            this.ucGroupBox1.Location = new System.Drawing.Point(6, 0);
            this.ucGroupBox1.Name = "ucGroupBox1";
            this.ucGroupBox1.Size = new System.Drawing.Size(298, 215);
            this.ucGroupBox1.TabIndex = 6;
            this.ucGroupBox1.TabStop = false;
            this.ucGroupBox1.Text = "Cargo Detail Data";
            // 
            // txtHeight
            // 
            this.txtHeight.LabelText = "Height";
            this.txtHeight.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtHeight.LinkDisabledMessage = "Link Disabled";
            this.txtHeight.Location = new System.Drawing.Point(76, 86);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(100, 20);
            this.txtHeight.TabIndex = 10;
            // 
            // cmbTypeDtl
            // 
            cmbTypeDtl_DesignTimeLayout.LayoutString = resources.GetString("cmbTypeDtl_DesignTimeLayout.LayoutString");
            this.cmbTypeDtl.DesignTimeLayout = cmbTypeDtl_DesignTimeLayout;
            this.cmbTypeDtl.DisplayMember = "vehicle_type_cd";
            this.cmbTypeDtl.LabelText = "Type";
            this.cmbTypeDtl.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.cmbTypeDtl.Location = new System.Drawing.Point(76, 63);
            this.cmbTypeDtl.Name = "cmbTypeDtl";
            this.cmbTypeDtl.SelectedIndex = -1;
            this.cmbTypeDtl.SelectedItem = null;
            this.cmbTypeDtl.Size = new System.Drawing.Size(100, 20);
            this.cmbTypeDtl.TabIndex = 0;
            this.cmbTypeDtl.ValueMember = "vehicle_type_cd";
            // 
            // txtVINSI
            // 
            this.txtVINSI.BackColor = System.Drawing.SystemColors.Control;
            this.txtVINSI.ForeColor = System.Drawing.Color.Black;
            this.txtVINSI.LabelText = "VIN";
            this.txtVINSI.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtVINSI.LinkDisabledMessage = "Link Disabled";
            this.txtVINSI.Location = new System.Drawing.Point(76, 18);
            this.txtVINSI.Name = "txtVINSI";
            this.txtVINSI.ReadOnly = true;
            this.txtVINSI.Size = new System.Drawing.Size(177, 20);
            this.txtVINSI.TabIndex = 7;
            this.txtVINSI.TabStop = false;
            // 
            // txtBookingNoSI
            // 
            this.txtBookingNoSI.BackColor = System.Drawing.SystemColors.Control;
            this.txtBookingNoSI.ForeColor = System.Drawing.Color.Black;
            this.txtBookingNoSI.LabelText = "Booking#";
            this.txtBookingNoSI.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtBookingNoSI.LinkDisabledMessage = "Link Disabled";
            this.txtBookingNoSI.Location = new System.Drawing.Point(76, 44);
            this.txtBookingNoSI.Name = "txtBookingNoSI";
            this.txtBookingNoSI.ReadOnly = true;
            this.txtBookingNoSI.Size = new System.Drawing.Size(177, 20);
            this.txtBookingNoSI.TabIndex = 8;
            this.txtBookingNoSI.TabStop = false;
            // 
            // ucGroupBox2
            // 
            this.ucGroupBox2.Controls.Add(this.txtVINSI);
            this.ucGroupBox2.Controls.Add(this.txtLastNm);
            this.ucGroupBox2.Controls.Add(this.cbxProcessedSI);
            this.ucGroupBox2.Controls.Add(this.txtBookingNoSI);
            this.ucGroupBox2.Location = new System.Drawing.Point(6, 221);
            this.ucGroupBox2.Name = "ucGroupBox2";
            this.ucGroupBox2.Size = new System.Drawing.Size(298, 133);
            this.ucGroupBox2.TabIndex = 9;
            this.ucGroupBox2.TabStop = false;
            this.ucGroupBox2.Text = "Shipping Instructions";
            // 
            // txtLastNm
            // 
            this.txtLastNm.BackColor = System.Drawing.SystemColors.Control;
            this.txtLastNm.ForeColor = System.Drawing.Color.Black;
            this.txtLastNm.LabelText = "LastName";
            this.txtLastNm.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtLastNm.LinkDisabledMessage = "Link Disabled";
            this.txtLastNm.Location = new System.Drawing.Point(76, 68);
            this.txtLastNm.Name = "txtLastNm";
            this.txtLastNm.ReadOnly = true;
            this.txtLastNm.Size = new System.Drawing.Size(177, 20);
            this.txtLastNm.TabIndex = 11;
            this.txtLastNm.TabStop = false;
            // 
            // cbxProcessedSI
            // 
            this.cbxProcessedSI.Location = new System.Drawing.Point(76, 107);
            this.cbxProcessedSI.Name = "cbxProcessedSI";
            this.cbxProcessedSI.Size = new System.Drawing.Size(104, 20);
            this.cbxProcessedSI.TabIndex = 10;
            this.cbxProcessedSI.Text = "Processed?";
            this.cbxProcessedSI.UseVisualStyleBackColor = true;
            this.cbxProcessedSI.YN = "N";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(229, 363);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 10;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // txtYear
            // 
            this.txtYear.LabelText = "Year";
            this.txtYear.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtYear.LinkDisabledMessage = "Link Disabled";
            this.txtYear.Location = new System.Drawing.Point(76, 109);
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(50, 20);
            this.txtYear.TabIndex = 11;
            // 
            // txtMake
            // 
            this.txtMake.LabelText = "Make";
            this.txtMake.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtMake.LinkDisabledMessage = "Link Disabled";
            this.txtMake.Location = new System.Drawing.Point(76, 132);
            this.txtMake.Name = "txtMake";
            this.txtMake.Size = new System.Drawing.Size(177, 20);
            this.txtMake.TabIndex = 12;
            // 
            // txtModel
            // 
            this.txtModel.LabelText = "Model";
            this.txtModel.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtModel.LinkDisabledMessage = "Link Disabled";
            this.txtModel.Location = new System.Drawing.Point(76, 155);
            this.txtModel.Name = "txtModel";
            this.txtModel.Size = new System.Drawing.Size(177, 20);
            this.txtModel.TabIndex = 13;
            // 
            // frmEditIALDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(327, 429);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.ucGroupBox1);
            this.Controls.Add(this.ucGroupBox2);
            this.Name = "frmEditIALDetail";
            this.Text = "Edit EDI Detail";
            this.Load += new System.EventHandler(this.frmEditIALDetail_Load);
            this.Controls.SetChildIndex(this.ucGroupBox2, 0);
            this.Controls.SetChildIndex(this.ucGroupBox1, 0);
            this.Controls.SetChildIndex(this.btnOK, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.btnApply, 0);
            this.Controls.SetChildIndex(this.btnDelete, 0);
            this.ucGroupBox1.ResumeLayout(false);
            this.ucGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTypeDtl)).EndInit();
            this.ucGroupBox2.ResumeLayout(false);
            this.ucGroupBox2.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private CommonWinCtrls.ucTextBox txtVIN;
		private CommonWinCtrls.ucTextBox txtBookingNo;
		private CommonWinCtrls.ucCheckBox cbxProcessed;
		private CommonWinCtrls.ucGroupBox ucGroupBox1;
		private CommonWinCtrls.ucMultiColumnCombo cmbTypeDtl;
		private CommonWinCtrls.ucTextBox txtVINSI;
		private CommonWinCtrls.ucTextBox txtBookingNoSI;
		private CommonWinCtrls.ucGroupBox ucGroupBox2;
		private CommonWinCtrls.ucCheckBox cbxProcessedSI;
		private CommonWinCtrls.ucTextBox txtLastNm;
		private CommonWinCtrls.ucButton btnDelete;
		private CommonWinCtrls.ucTextBox txtHeight;
        private CommonWinCtrls.ucTextBox txtYear;
        private CommonWinCtrls.ucTextBox txtModel;
        private CommonWinCtrls.ucTextBox txtMake;
	}
}
