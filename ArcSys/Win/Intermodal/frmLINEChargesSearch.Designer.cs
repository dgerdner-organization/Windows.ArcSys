namespace CS2010.ArcSys.Win
{
    partial class frmLINEChargesSearch
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
            this.txtSerialNo = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtPCFN = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtBooking = new CS2010.CommonWinCtrls.ucTextBox();
            this.btnClear = new CS2010.CommonWinCtrls.ucButton();
            this.grpSailDt = new CS2010.CommonWinCtrls.ucDateGroupBox();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(177, 60);
            this.btnOK.TabIndex = 40;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(258, 60);
            this.btnCancel.TabIndex = 41;
            // 
            // btnApply
            // 
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApply.Location = new System.Drawing.Point(-63, 60);
            this.btnApply.TabIndex = 43;
            this.btnApply.TabStop = true;
            this.btnApply.UseVisualStyleBackColor = false;
            // 
            // txtSerialNo
            // 
            this.txtSerialNo.Enabled = false;
            this.txtSerialNo.LabelText = "Serial &No";
            this.txtSerialNo.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtSerialNo.LinkDisabledMessage = "Link Disabled";
            this.txtSerialNo.Location = new System.Drawing.Point(78, 348);
            this.txtSerialNo.Name = "txtSerialNo";
            this.txtSerialNo.Size = new System.Drawing.Size(249, 20);
            this.txtSerialNo.TabIndex = 17;
            this.txtSerialNo.Visible = false;
            // 
            // txtPCFN
            // 
            this.txtPCFN.LabelText = "&PCFN";
            this.txtPCFN.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtPCFN.LinkDisabledMessage = "Link Disabled";
            this.txtPCFN.Location = new System.Drawing.Point(78, 322);
            this.txtPCFN.Name = "txtPCFN";
            this.txtPCFN.Size = new System.Drawing.Size(249, 20);
            this.txtPCFN.TabIndex = 1;
            this.txtPCFN.Visible = false;
            // 
            // txtBooking
            // 
            this.txtBooking.LabelText = "&Booking";
            this.txtBooking.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtBooking.LinkDisabledMessage = "Link Disabled";
            this.txtBooking.Location = new System.Drawing.Point(78, 12);
            this.txtBooking.Name = "txtBooking";
            this.txtBooking.Size = new System.Drawing.Size(249, 20);
            this.txtBooking.TabIndex = 3;
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Location = new System.Drawing.Point(96, 60);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 42;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // grpSailDt
            // 
            this.grpSailDt.CheckBoxText = "Sail Date";
            this.grpSailDt.DateFormatDefault = "MM-dd-yyyy";
            this.grpSailDt.DateFormatEdit = "MMddyy";
            this.grpSailDt.Location = new System.Drawing.Point(78, 374);
            this.grpSailDt.Name = "grpSailDt";
            this.grpSailDt.Size = new System.Drawing.Size(129, 76);
            this.grpSailDt.TabIndex = 26;
            this.grpSailDt.ValueRange = ((CS2010.Common.DateRange)(new CS2010.Common.DateRange(null, null)));
            this.grpSailDt.Visible = false;
            // 
            // frmLINEChargesSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 95);
            this.Controls.Add(this.txtBooking);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.txtPCFN);
            this.Controls.Add(this.txtSerialNo);
            this.Controls.Add(this.grpSailDt);
            this.Name = "frmLINEChargesSearch";
            this.Text = "LINE Charges Search";
            this.Controls.SetChildIndex(this.grpSailDt, 0);
            this.Controls.SetChildIndex(this.txtSerialNo, 0);
            this.Controls.SetChildIndex(this.txtPCFN, 0);
            this.Controls.SetChildIndex(this.btnOK, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.btnClear, 0);
            this.Controls.SetChildIndex(this.btnApply, 0);
            this.Controls.SetChildIndex(this.txtBooking, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private CommonWinCtrls.ucTextBox txtSerialNo;
        private CommonWinCtrls.ucTextBox txtPCFN;
        private CommonWinCtrls.ucTextBox txtBooking;
        private CommonWinCtrls.ucButton btnClear;
        private CommonWinCtrls.ucDateGroupBox grpSailDt;
	}
}