namespace CS2010.ArcSys.Win
{
    partial class frmEditVessel
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
			this.txtVesselCd = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtVesselName = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtIRCSCode = new CS2010.CommonWinCtrls.ucTextBox();
			this.ucArcVessel = new CS2010.CommonWinCtrls.ucCheckBox();
			this.ucTextBox1 = new CS2010.CommonWinCtrls.ucTextBox();
			this.SuspendLayout();
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(81, 179);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(169, 179);
			// 
			// btnApply
			// 
			this.btnApply.Location = new System.Drawing.Point(257, 179);
			this.btnApply.TabStop = true;
			this.btnApply.UseVisualStyleBackColor = false;
			// 
			// txtVesselCd
			// 
			this.txtVesselCd.LabelText = "Vessel Code";
			this.txtVesselCd.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtVesselCd.LinkDisabledMessage = "Link Disabled";
			this.txtVesselCd.Location = new System.Drawing.Point(123, 71);
			this.txtVesselCd.Name = "txtVesselCd";
			this.txtVesselCd.Size = new System.Drawing.Size(73, 20);
			this.txtVesselCd.TabIndex = 3;
			// 
			// txtVesselName
			// 
			this.txtVesselName.LabelText = "Name";
			this.txtVesselName.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtVesselName.LinkDisabledMessage = "Link Disabled";
			this.txtVesselName.Location = new System.Drawing.Point(123, 97);
			this.txtVesselName.Name = "txtVesselName";
			this.txtVesselName.Size = new System.Drawing.Size(179, 20);
			this.txtVesselName.TabIndex = 4;
			// 
			// txtIRCSCode
			// 
			this.txtIRCSCode.LabelText = "Call Signal";
			this.txtIRCSCode.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtIRCSCode.LinkDisabledMessage = "Link Disabled";
			this.txtIRCSCode.Location = new System.Drawing.Point(123, 123);
			this.txtIRCSCode.Name = "txtIRCSCode";
			this.txtIRCSCode.Size = new System.Drawing.Size(73, 20);
			this.txtIRCSCode.TabIndex = 5;
			// 
			// ucArcVessel
			// 
			this.ucArcVessel.Location = new System.Drawing.Point(123, 149);
			this.ucArcVessel.Name = "ucArcVessel";
			this.ucArcVessel.Size = new System.Drawing.Size(98, 24);
			this.ucArcVessel.TabIndex = 6;
			this.ucArcVessel.Text = "ARC Vessel ?";
			this.ucArcVessel.UseVisualStyleBackColor = true;
			this.ucArcVessel.YN = "N";
			// 
			// ucTextBox1
			// 
			this.ucTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.ucTextBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
			this.ucTextBox1.LinkDisabledMessage = "Link Disabled";
			this.ucTextBox1.Location = new System.Drawing.Point(25, 12);
			this.ucTextBox1.Multiline = true;
			this.ucTextBox1.Name = "ucTextBox1";
			this.ucTextBox1.Size = new System.Drawing.Size(377, 41);
			this.ucTextBox1.TabIndex = 7;
			this.ucTextBox1.Text = "NOTE: this only updates the AVSS database.  You should instead use the \"Vessel\" u" +
				"pdate window, because it will update all ARC databases.";
			// 
			// frmEditVessel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.ClientSize = new System.Drawing.Size(425, 223);
			this.Controls.Add(this.ucTextBox1);
			this.Controls.Add(this.ucArcVessel);
			this.Controls.Add(this.txtIRCSCode);
			this.Controls.Add(this.txtVesselName);
			this.Controls.Add(this.txtVesselCd);
			this.Name = "frmEditVessel";
			this.Text = "Edit Vessel";
			this.Load += new System.EventHandler(this.frmEditVessel_Load);
			this.Controls.SetChildIndex(this.txtVesselCd, 0);
			this.Controls.SetChildIndex(this.btnOK, 0);
			this.Controls.SetChildIndex(this.btnCancel, 0);
			this.Controls.SetChildIndex(this.btnApply, 0);
			this.Controls.SetChildIndex(this.txtVesselName, 0);
			this.Controls.SetChildIndex(this.txtIRCSCode, 0);
			this.Controls.SetChildIndex(this.ucArcVessel, 0);
			this.Controls.SetChildIndex(this.ucTextBox1, 0);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private CS2010.CommonWinCtrls.ucTextBox txtVesselCd;
        private CS2010.CommonWinCtrls.ucTextBox txtVesselName;
        private CS2010.CommonWinCtrls.ucTextBox txtIRCSCode;
		private CS2010.CommonWinCtrls.ucCheckBox ucArcVessel;
		private CommonWinCtrls.ucTextBox ucTextBox1;

    }
}
