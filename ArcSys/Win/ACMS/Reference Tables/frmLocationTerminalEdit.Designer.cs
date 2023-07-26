namespace CS2010.ArcSys.Win
{
	partial class frmLocationTerminalEdit
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
			this.txtLocationCd = new CS2010.CommonWinCtrls.ucTextBoxPK();
			this.chkDeleted = new CS2010.CommonWinCtrls.ucCheckBox();
			this.txtTerminalDsc = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtOther1 = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtTerminalCd = new CS2010.CommonWinCtrls.ucTextBox();
			this.btnOK = new CS2010.CommonWinCtrls.ucButton();
			this.btnCancel = new CS2010.CommonWinCtrls.ucButton();
			this.chkDefault = new CS2010.CommonWinCtrls.ucCheckBox();
			this.txtWebBerthDisplay = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtMilitaryCode = new CS2010.CommonWinCtrls.ucTextBox();
			this.chkInducement = new CS2010.CommonWinCtrls.ucCheckBox();
			this.cbxMilitaryFlg = new CS2010.CommonWinCtrls.ucCheckBox();
			this.ucGroupBox1 = new CS2010.CommonWinCtrls.ucGroupBox();
			this.cmbEndTime = new CS2010.AVSS.WinCtrls.ucDayHourMinute();
			this.cmbStartTime = new CS2010.AVSS.WinCtrls.ucDayHourMinute();
			this.ucGroupBox2 = new CS2010.CommonWinCtrls.ucGroupBox();
			this.txtBerthCd = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtBerthName = new CS2010.CommonWinCtrls.ucTextBox();
			this.ucGroupBox1.SuspendLayout();
			this.ucGroupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// txtLocationCd
			// 
			this.txtLocationCd.BackColor = System.Drawing.SystemColors.Control;
			this.txtLocationCd.ForeColor = System.Drawing.Color.Black;
			this.txtLocationCd.LabelText = "Location Code";
			this.txtLocationCd.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtLocationCd.LinkDisabledMessage = "Link Disabled";
			this.txtLocationCd.Location = new System.Drawing.Point(86, 12);
			this.txtLocationCd.Name = "txtLocationCd";
			this.txtLocationCd.ReadOnly = true;
			this.txtLocationCd.Size = new System.Drawing.Size(104, 20);
			this.txtLocationCd.TabIndex = 1;
			this.txtLocationCd.TabStop = false;
			// 
			// chkDeleted
			// 
			this.chkDeleted.AutoSize = true;
			this.chkDeleted.Location = new System.Drawing.Point(170, 117);
			this.chkDeleted.Name = "chkDeleted";
			this.chkDeleted.Size = new System.Drawing.Size(69, 17);
			this.chkDeleted.TabIndex = 9;
			this.chkDeleted.Text = "Deleted?";
			this.chkDeleted.UseVisualStyleBackColor = true;
			this.chkDeleted.YN = "N";
			// 
			// txtTerminalDsc
			// 
			this.txtTerminalDsc.LabelText = "Description";
			this.txtTerminalDsc.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtTerminalDsc.LinkDisabledMessage = "Link Disabled";
			this.txtTerminalDsc.Location = new System.Drawing.Point(86, 65);
			this.txtTerminalDsc.Name = "txtTerminalDsc";
			this.txtTerminalDsc.Size = new System.Drawing.Size(265, 20);
			this.txtTerminalDsc.TabIndex = 5;
			this.txtTerminalDsc.TextChanged += new System.EventHandler(this.txtTerminalDsc_TextChanged);
			// 
			// txtOther1
			// 
			this.txtOther1.LabelText = "MilStamp";
			this.txtOther1.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtOther1.LinkDisabledMessage = "Link Disabled";
			this.txtOther1.Location = new System.Drawing.Point(86, 91);
			this.txtOther1.Name = "txtOther1";
			this.txtOther1.Size = new System.Drawing.Size(108, 20);
			this.txtOther1.TabIndex = 7;
			this.txtOther1.TextChanged += new System.EventHandler(this.txtOther1_TextChanged);
			// 
			// txtTerminalCd
			// 
			this.txtTerminalCd.LabelText = "Terminal Code";
			this.txtTerminalCd.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtTerminalCd.LinkDisabledMessage = "Link Disabled";
			this.txtTerminalCd.Location = new System.Drawing.Point(86, 38);
			this.txtTerminalCd.Name = "txtTerminalCd";
			this.txtTerminalCd.Size = new System.Drawing.Size(104, 20);
			this.txtTerminalCd.TabIndex = 3;
			this.txtTerminalCd.TextChanged += new System.EventHandler(this.txtTerminalCd_TextChanged);
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(217, 397);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 30;
			this.btnOK.Text = "Save";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(298, 397);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 31;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// chkDefault
			// 
			this.chkDefault.AutoSize = true;
			this.chkDefault.Location = new System.Drawing.Point(86, 117);
			this.chkDefault.Name = "chkDefault";
			this.chkDefault.Size = new System.Drawing.Size(60, 17);
			this.chkDefault.TabIndex = 8;
			this.chkDefault.Text = "Default";
			this.chkDefault.UseVisualStyleBackColor = true;
			this.chkDefault.YN = "N";
			// 
			// txtWebBerthDisplay
			// 
			this.txtWebBerthDisplay.LabelText = "Web Display";
			this.txtWebBerthDisplay.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtWebBerthDisplay.LinkDisabledMessage = "Link Disabled";
			this.txtWebBerthDisplay.Location = new System.Drawing.Point(90, 229);
			this.txtWebBerthDisplay.Name = "txtWebBerthDisplay";
			this.txtWebBerthDisplay.Size = new System.Drawing.Size(202, 20);
			this.txtWebBerthDisplay.TabIndex = 36;
			// 
			// txtMilitaryCode
			// 
			this.txtMilitaryCode.BackColor = System.Drawing.SystemColors.Control;
			this.txtMilitaryCode.ForeColor = System.Drawing.Color.Black;
			this.txtMilitaryCode.LabelText = "MilStamp";
			this.txtMilitaryCode.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtMilitaryCode.LinkDisabledMessage = "Link Disabled";
			this.txtMilitaryCode.Location = new System.Drawing.Point(87, 67);
			this.txtMilitaryCode.Name = "txtMilitaryCode";
			this.txtMilitaryCode.ReadOnly = true;
			this.txtMilitaryCode.Size = new System.Drawing.Size(100, 20);
			this.txtMilitaryCode.TabIndex = 35;
			this.txtMilitaryCode.TabStop = false;
			// 
			// chkInducement
			// 
			this.chkInducement.Location = new System.Drawing.Point(90, 356);
			this.chkInducement.Name = "chkInducement";
			this.chkInducement.Size = new System.Drawing.Size(104, 24);
			this.chkInducement.TabIndex = 34;
			this.chkInducement.Text = "Inducement";
			this.chkInducement.UseVisualStyleBackColor = true;
			this.chkInducement.YN = "N";
			// 
			// cbxMilitaryFlg
			// 
			this.cbxMilitaryFlg.Location = new System.Drawing.Point(90, 334);
			this.cbxMilitaryFlg.Name = "cbxMilitaryFlg";
			this.cbxMilitaryFlg.Size = new System.Drawing.Size(104, 24);
			this.cbxMilitaryFlg.TabIndex = 33;
			this.cbxMilitaryFlg.Text = "Military Berth";
			this.cbxMilitaryFlg.UseVisualStyleBackColor = true;
			this.cbxMilitaryFlg.YN = "N";
			// 
			// ucGroupBox1
			// 
			this.ucGroupBox1.Controls.Add(this.cmbEndTime);
			this.ucGroupBox1.Controls.Add(this.cmbStartTime);
			this.ucGroupBox1.Location = new System.Drawing.Point(90, 255);
			this.ucGroupBox1.Name = "ucGroupBox1";
			this.ucGroupBox1.Size = new System.Drawing.Size(145, 77);
			this.ucGroupBox1.TabIndex = 32;
			this.ucGroupBox1.TabStop = false;
			this.ucGroupBox1.Text = "Work Hours";
			// 
			// cmbEndTime
			// 
			this.cmbEndTime.DayEnabled = false;
			this.cmbEndTime.DayLabel = "Day";
			this.cmbEndTime.Location = new System.Drawing.Point(19, 43);
			this.cmbEndTime.Name = "cmbEndTime";
			this.cmbEndTime.Size = new System.Drawing.Size(104, 28);
			this.cmbEndTime.TabIndex = 4;
			this.cmbEndTime.TimeLabel = "End";
			this.cmbEndTime.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
			// 
			// cmbStartTime
			// 
			this.cmbStartTime.DayEnabled = false;
			this.cmbStartTime.DayLabel = "Day";
			this.cmbStartTime.Location = new System.Drawing.Point(19, 19);
			this.cmbStartTime.Name = "cmbStartTime";
			this.cmbStartTime.Size = new System.Drawing.Size(120, 27);
			this.cmbStartTime.TabIndex = 3;
			this.cmbStartTime.TimeLabel = "Start";
			this.cmbStartTime.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
			// 
			// ucGroupBox2
			// 
			this.ucGroupBox2.Controls.Add(this.txtBerthName);
			this.ucGroupBox2.Controls.Add(this.txtBerthCd);
			this.ucGroupBox2.Controls.Add(this.txtMilitaryCode);
			this.ucGroupBox2.Location = new System.Drawing.Point(4, 137);
			this.ucGroupBox2.Name = "ucGroupBox2";
			this.ucGroupBox2.Size = new System.Drawing.Size(369, 247);
			this.ucGroupBox2.TabIndex = 37;
			this.ucGroupBox2.TabStop = false;
			this.ucGroupBox2.Text = "AVSS Information";
			// 
			// txtBerthCd
			// 
			this.txtBerthCd.BackColor = System.Drawing.SystemColors.Control;
			this.txtBerthCd.ForeColor = System.Drawing.Color.Black;
			this.txtBerthCd.LabelText = "Terminal Code";
			this.txtBerthCd.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtBerthCd.LinkDisabledMessage = "Link Disabled";
			this.txtBerthCd.Location = new System.Drawing.Point(86, 19);
			this.txtBerthCd.Name = "txtBerthCd";
			this.txtBerthCd.ReadOnly = true;
			this.txtBerthCd.Size = new System.Drawing.Size(100, 20);
			this.txtBerthCd.TabIndex = 38;
			this.txtBerthCd.TabStop = false;
			// 
			// txtBerthName
			// 
			this.txtBerthName.BackColor = System.Drawing.SystemColors.Control;
			this.txtBerthName.ForeColor = System.Drawing.Color.Black;
			this.txtBerthName.LabelText = "Description";
			this.txtBerthName.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtBerthName.LinkDisabledMessage = "Link Disabled";
			this.txtBerthName.Location = new System.Drawing.Point(87, 43);
			this.txtBerthName.Name = "txtBerthName";
			this.txtBerthName.ReadOnly = true;
			this.txtBerthName.Size = new System.Drawing.Size(265, 20);
			this.txtBerthName.TabIndex = 38;
			this.txtBerthName.TabStop = false;
			// 
			// frmLocationTerminalEdit
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(396, 432);
			this.Controls.Add(this.txtWebBerthDisplay);
			this.Controls.Add(this.chkInducement);
			this.Controls.Add(this.cbxMilitaryFlg);
			this.Controls.Add(this.ucGroupBox1);
			this.Controls.Add(this.chkDefault);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.txtTerminalCd);
			this.Controls.Add(this.txtOther1);
			this.Controls.Add(this.txtTerminalDsc);
			this.Controls.Add(this.chkDeleted);
			this.Controls.Add(this.txtLocationCd);
			this.Controls.Add(this.ucGroupBox2);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmLocationTerminalEdit";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Add/Edit Terminal";
			this.Load += new System.EventHandler(this.frmLocationTerminalEdit_Load);
			this.ucGroupBox1.ResumeLayout(false);
			this.ucGroupBox2.ResumeLayout(false);
			this.ucGroupBox2.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private CommonWinCtrls.ucTextBoxPK txtLocationCd;
		private CommonWinCtrls.ucCheckBox chkDeleted;
		private CommonWinCtrls.ucTextBox txtTerminalDsc;
		private CommonWinCtrls.ucTextBox txtOther1;
		private CommonWinCtrls.ucTextBox txtTerminalCd;
		private CommonWinCtrls.ucButton btnOK;
		private CommonWinCtrls.ucButton btnCancel;
		private CommonWinCtrls.ucCheckBox chkDefault;
		private CommonWinCtrls.ucTextBox txtWebBerthDisplay;
		private CommonWinCtrls.ucTextBox txtMilitaryCode;
		private CommonWinCtrls.ucCheckBox chkInducement;
		private CommonWinCtrls.ucCheckBox cbxMilitaryFlg;
		private CommonWinCtrls.ucGroupBox ucGroupBox1;
		private AVSS.WinCtrls.ucDayHourMinute cmbEndTime;
		private AVSS.WinCtrls.ucDayHourMinute cmbStartTime;
		private CommonWinCtrls.ucGroupBox ucGroupBox2;
		private CommonWinCtrls.ucTextBox txtBerthName;
		private CommonWinCtrls.ucTextBox txtBerthCd;
	}
}