namespace CS2010.ArcSys.Win
{
    partial class frmEditPort
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
			this.txtPortCd = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtPortName = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtCensusCode = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtOffset = new CS2010.CommonWinCtrls.ucTextBox();
			this.ucLabel1 = new CS2010.CommonWinCtrls.ucLabel();
			this.txtType = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtCity = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtState = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtCountry = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtMilStamp = new CS2010.CommonWinCtrls.ucTextBox();
			this.cbxDeleted = new CS2010.CommonWinCtrls.ucCheckBox();
			this.ucGroupBox1 = new CS2010.CommonWinCtrls.ucGroupBox();
			this.SuspendLayout();
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(86, 272);
			this.btnOK.TabIndex = 8;
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(174, 272);
			this.btnCancel.TabIndex = 9;
			// 
			// btnApply
			// 
			this.btnApply.Location = new System.Drawing.Point(262, 272);
			this.btnApply.TabIndex = 10;
			this.btnApply.TabStop = true;
			this.btnApply.UseVisualStyleBackColor = false;
			// 
			// txtPortCd
			// 
			this.txtPortCd.LabelText = "UNEC Code";
			this.txtPortCd.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtPortCd.LinkDisabledMessage = "Link Disabled";
			this.txtPortCd.Location = new System.Drawing.Point(96, 9);
			this.txtPortCd.Name = "txtPortCd";
			this.txtPortCd.Size = new System.Drawing.Size(100, 20);
			this.txtPortCd.TabIndex = 0;
			// 
			// txtPortName
			// 
			this.txtPortName.LabelText = "Port Name";
			this.txtPortName.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtPortName.LinkDisabledMessage = "Link Disabled";
			this.txtPortName.Location = new System.Drawing.Point(96, 31);
			this.txtPortName.Name = "txtPortName";
			this.txtPortName.Size = new System.Drawing.Size(202, 20);
			this.txtPortName.TabIndex = 1;
			// 
			// txtCensusCode
			// 
			this.txtCensusCode.LabelText = "Census Code";
			this.txtCensusCode.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtCensusCode.LinkDisabledMessage = "Link Disabled";
			this.txtCensusCode.Location = new System.Drawing.Point(96, 53);
			this.txtCensusCode.Name = "txtCensusCode";
			this.txtCensusCode.Size = new System.Drawing.Size(100, 20);
			this.txtCensusCode.TabIndex = 2;
			// 
			// txtOffset
			// 
			this.txtOffset.LabelText = "Time Offset";
			this.txtOffset.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtOffset.LinkDisabledMessage = "Link Disabled";
			this.txtOffset.Location = new System.Drawing.Point(96, 75);
			this.txtOffset.Name = "txtOffset";
			this.txtOffset.Size = new System.Drawing.Size(46, 20);
			this.txtOffset.TabIndex = 6;
			// 
			// ucLabel1
			// 
			this.ucLabel1.Location = new System.Drawing.Point(284, 57);
			this.ucLabel1.Name = "ucLabel1";
			this.ucLabel1.Size = new System.Drawing.Size(90, 13);
			this.ucLabel1.TabIndex = 10;
			this.ucLabel1.Text = "D=US; K=Foreign";
			// 
			// txtType
			// 
			this.txtType.LabelText = "Type";
			this.txtType.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtType.LinkDisabledMessage = "Link Disabled";
			this.txtType.Location = new System.Drawing.Point(246, 54);
			this.txtType.Name = "txtType";
			this.txtType.Size = new System.Drawing.Size(34, 20);
			this.txtType.TabIndex = 4;
			// 
			// txtCity
			// 
			this.txtCity.LabelText = "City";
			this.txtCity.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtCity.LinkDisabledMessage = "Link Disabled";
			this.txtCity.Location = new System.Drawing.Point(96, 126);
			this.txtCity.Name = "txtCity";
			this.txtCity.Size = new System.Drawing.Size(202, 20);
			this.txtCity.TabIndex = 11;
			// 
			// txtState
			// 
			this.txtState.LabelText = "State";
			this.txtState.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtState.LinkDisabledMessage = "Link Disabled";
			this.txtState.Location = new System.Drawing.Point(96, 149);
			this.txtState.Name = "txtState";
			this.txtState.Size = new System.Drawing.Size(100, 20);
			this.txtState.TabIndex = 12;
			// 
			// txtCountry
			// 
			this.txtCountry.LabelText = "Country";
			this.txtCountry.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtCountry.LinkDisabledMessage = "Link Disabled";
			this.txtCountry.Location = new System.Drawing.Point(96, 172);
			this.txtCountry.Name = "txtCountry";
			this.txtCountry.Size = new System.Drawing.Size(32, 20);
			this.txtCountry.TabIndex = 13;
			// 
			// txtMilStamp
			// 
			this.txtMilStamp.LabelText = "MilStamp";
			this.txtMilStamp.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtMilStamp.LinkDisabledMessage = "Link Disabled";
			this.txtMilStamp.Location = new System.Drawing.Point(96, 195);
			this.txtMilStamp.Name = "txtMilStamp";
			this.txtMilStamp.Size = new System.Drawing.Size(100, 20);
			this.txtMilStamp.TabIndex = 14;
			// 
			// cbxDeleted
			// 
			this.cbxDeleted.Location = new System.Drawing.Point(96, 217);
			this.cbxDeleted.Name = "cbxDeleted";
			this.cbxDeleted.Size = new System.Drawing.Size(104, 24);
			this.cbxDeleted.TabIndex = 15;
			this.cbxDeleted.Text = "Deleted?";
			this.cbxDeleted.UseVisualStyleBackColor = true;
			this.cbxDeleted.YN = "N";
			// 
			// ucGroupBox1
			// 
			this.ucGroupBox1.Location = new System.Drawing.Point(12, 101);
			this.ucGroupBox1.Name = "ucGroupBox1";
			this.ucGroupBox1.Size = new System.Drawing.Size(341, 160);
			this.ucGroupBox1.TabIndex = 16;
			this.ucGroupBox1.TabStop = false;
			this.ucGroupBox1.Text = "ACMS Information";
			// 
			// frmEditPort
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.ClientSize = new System.Drawing.Size(437, 358);
			this.Controls.Add(this.cbxDeleted);
			this.Controls.Add(this.txtMilStamp);
			this.Controls.Add(this.txtCountry);
			this.Controls.Add(this.txtState);
			this.Controls.Add(this.txtCity);
			this.Controls.Add(this.txtType);
			this.Controls.Add(this.ucLabel1);
			this.Controls.Add(this.txtOffset);
			this.Controls.Add(this.txtCensusCode);
			this.Controls.Add(this.txtPortName);
			this.Controls.Add(this.txtPortCd);
			this.Controls.Add(this.ucGroupBox1);
			this.Name = "frmEditPort";
			this.Text = "Edit Port";
			this.Load += new System.EventHandler(this.frmEditPort_Load);
			this.Controls.SetChildIndex(this.ucGroupBox1, 0);
			this.Controls.SetChildIndex(this.txtPortCd, 0);
			this.Controls.SetChildIndex(this.btnOK, 0);
			this.Controls.SetChildIndex(this.btnCancel, 0);
			this.Controls.SetChildIndex(this.btnApply, 0);
			this.Controls.SetChildIndex(this.txtPortName, 0);
			this.Controls.SetChildIndex(this.txtCensusCode, 0);
			this.Controls.SetChildIndex(this.txtOffset, 0);
			this.Controls.SetChildIndex(this.ucLabel1, 0);
			this.Controls.SetChildIndex(this.txtType, 0);
			this.Controls.SetChildIndex(this.txtCity, 0);
			this.Controls.SetChildIndex(this.txtState, 0);
			this.Controls.SetChildIndex(this.txtCountry, 0);
			this.Controls.SetChildIndex(this.txtMilStamp, 0);
			this.Controls.SetChildIndex(this.cbxDeleted, 0);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private CS2010.CommonWinCtrls.ucTextBox txtPortCd;
        private CS2010.CommonWinCtrls.ucTextBox txtPortName;
		private CS2010.CommonWinCtrls.ucTextBox txtCensusCode;
        private CS2010.CommonWinCtrls.ucTextBox txtOffset;
        private CS2010.CommonWinCtrls.ucLabel ucLabel1;
        private CS2010.CommonWinCtrls.ucTextBox txtType;
		private CommonWinCtrls.ucTextBox txtCity;
		private CommonWinCtrls.ucTextBox txtState;
		private CommonWinCtrls.ucTextBox txtCountry;
		private CommonWinCtrls.ucTextBox txtMilStamp;
		private CommonWinCtrls.ucCheckBox cbxDeleted;
		private CommonWinCtrls.ucGroupBox ucGroupBox1;


    }
}
