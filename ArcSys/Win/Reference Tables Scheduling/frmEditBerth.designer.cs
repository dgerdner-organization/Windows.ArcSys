namespace CS2010.ArcSys.Win
{
    partial class frmEditBerth
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
			this.components = new System.ComponentModel.Container();
			Janus.Windows.GridEX.GridEXLayout gridEXLayout1 = new Janus.Windows.GridEX.GridEXLayout();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditBerth));
			this.txtBerthCd = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtBerthName = new CS2010.CommonWinCtrls.ucTextBox();
			this.cmbEndTime = new CS2010.AVSS.WinCtrls.ucDayHourMinute();
			this.cmbPort = new CS2010.AVSS.WinCtrls.ucPortCombo();
			this.cmbStartTime = new CS2010.AVSS.WinCtrls.ucDayHourMinute();
			this.ucGroupBox1 = new CS2010.CommonWinCtrls.ucGroupBox();
			this.cbxMilitaryFlg = new CS2010.CommonWinCtrls.ucCheckBox();
			this.chkInducement = new CS2010.CommonWinCtrls.ucCheckBox();
			this.txtMilitaryCode = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtWebBerthDisplay = new CS2010.CommonWinCtrls.ucTextBox();
			((System.ComponentModel.ISupportInitialize)(this.cmbPort)).BeginInit();
			this.ucGroupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOK.Location = new System.Drawing.Point(214, 283);
			this.btnOK.TabIndex = 6;
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.Location = new System.Drawing.Point(295, 283);
			this.btnCancel.TabIndex = 7;
			// 
			// btnApply
			// 
			this.btnApply.Location = new System.Drawing.Point(12, 249);
			this.btnApply.TabIndex = 0;
			this.btnApply.TabStop = true;
			this.btnApply.UseVisualStyleBackColor = false;
			// 
			// txtBerthCd
			// 
			this.txtBerthCd.LabelText = "Berth";
			this.txtBerthCd.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtBerthCd.LinkDisabledMessage = "Link Disabled";
			this.txtBerthCd.Location = new System.Drawing.Point(144, 35);
			this.txtBerthCd.Name = "txtBerthCd";
			this.txtBerthCd.Size = new System.Drawing.Size(100, 20);
			this.txtBerthCd.TabIndex = 1;
			// 
			// txtBerthName
			// 
			this.txtBerthName.LabelText = "Berth Name";
			this.txtBerthName.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtBerthName.LinkDisabledMessage = "Link Disabled";
			this.txtBerthName.Location = new System.Drawing.Point(144, 61);
			this.txtBerthName.Name = "txtBerthName";
			this.txtBerthName.Size = new System.Drawing.Size(202, 20);
			this.txtBerthName.TabIndex = 2;
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
			// cmbPort
			// 
			this.cmbPort.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.cmbPort.CodeColumn = "PORT_CD";
			this.cmbPort.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList;
			this.cmbPort.DescriptionColumn = "PORT_NM";
			gridEXLayout1.LayoutString = resources.GetString("gridEXLayout1.LayoutString");
			this.cmbPort.DesignTimeLayout = gridEXLayout1;
			this.cmbPort.DisplayMember = "PORT_CDPORT_NM";
			this.cmbPort.DisplayType = CS2010.CommonWinCtrls.ComboDisplay.CodePlusDescription;
			this.cmbPort.LabelText = "Port";
			this.cmbPort.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.cmbPort.Location = new System.Drawing.Point(144, 9);
			this.cmbPort.Name = "cmbPort";
			this.cmbPort.SaveSettings = false;
			this.cmbPort.SelectedIndex = -1;
			this.cmbPort.SelectedItem = null;
			this.cmbPort.Size = new System.Drawing.Size(202, 20);
			this.cmbPort.TabIndex = 0;
			this.cmbPort.ValueColumn = "PORT_CD";
			this.cmbPort.ValueMember = "PORT_CD";
			this.cmbPort.WithBerths = false;
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
			// ucGroupBox1
			// 
			this.ucGroupBox1.Controls.Add(this.cmbEndTime);
			this.ucGroupBox1.Controls.Add(this.cmbStartTime);
			this.ucGroupBox1.Location = new System.Drawing.Point(144, 113);
			this.ucGroupBox1.Name = "ucGroupBox1";
			this.ucGroupBox1.Size = new System.Drawing.Size(145, 77);
			this.ucGroupBox1.TabIndex = 4;
			this.ucGroupBox1.TabStop = false;
			this.ucGroupBox1.Text = "Work Hours";
			// 
			// cbxMilitaryFlg
			// 
			this.cbxMilitaryFlg.Location = new System.Drawing.Point(144, 222);
			this.cbxMilitaryFlg.Name = "cbxMilitaryFlg";
			this.cbxMilitaryFlg.Size = new System.Drawing.Size(104, 24);
			this.cbxMilitaryFlg.TabIndex = 5;
			this.cbxMilitaryFlg.Text = "Military Berth";
			this.cbxMilitaryFlg.UseVisualStyleBackColor = true;
			this.cbxMilitaryFlg.YN = "N";
			this.cbxMilitaryFlg.CheckedChanged += new System.EventHandler(this.cbxMilitaryFlg_CheckedChanged);
			// 
			// chkInducement
			// 
			this.chkInducement.Location = new System.Drawing.Point(144, 252);
			this.chkInducement.Name = "chkInducement";
			this.chkInducement.Size = new System.Drawing.Size(104, 24);
			this.chkInducement.TabIndex = 8;
			this.chkInducement.Text = "Inducement";
			this.chkInducement.UseVisualStyleBackColor = true;
			this.chkInducement.YN = "N";
			// 
			// txtMilitaryCode
			// 
			this.txtMilitaryCode.LabelText = "Military Code:";
			this.txtMilitaryCode.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtMilitaryCode.LinkDisabledMessage = "Link Disabled";
			this.txtMilitaryCode.Location = new System.Drawing.Point(144, 196);
			this.txtMilitaryCode.Name = "txtMilitaryCode";
			this.txtMilitaryCode.Size = new System.Drawing.Size(100, 20);
			this.txtMilitaryCode.TabIndex = 9;
			// 
			// txtWebBerthDisplay
			// 
			this.txtWebBerthDisplay.LabelText = "Web Display";
			this.txtWebBerthDisplay.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtWebBerthDisplay.LinkDisabledMessage = "Link Disabled";
			this.txtWebBerthDisplay.Location = new System.Drawing.Point(144, 87);
			this.txtWebBerthDisplay.Name = "txtWebBerthDisplay";
			this.txtWebBerthDisplay.Size = new System.Drawing.Size(202, 20);
			this.txtWebBerthDisplay.TabIndex = 10;
			// 
			// frmEditBerth
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.ClientSize = new System.Drawing.Size(382, 318);
			this.Controls.Add(this.txtWebBerthDisplay);
			this.Controls.Add(this.txtMilitaryCode);
			this.Controls.Add(this.chkInducement);
			this.Controls.Add(this.cbxMilitaryFlg);
			this.Controls.Add(this.cmbPort);
			this.Controls.Add(this.txtBerthName);
			this.Controls.Add(this.txtBerthCd);
			this.Controls.Add(this.ucGroupBox1);
			this.Name = "frmEditBerth";
			this.Text = "Edit Berth";
			this.Load += new System.EventHandler(this.frmEditBerth_Load);
			this.Controls.SetChildIndex(this.ucGroupBox1, 0);
			this.Controls.SetChildIndex(this.txtBerthCd, 0);
			this.Controls.SetChildIndex(this.btnOK, 0);
			this.Controls.SetChildIndex(this.btnCancel, 0);
			this.Controls.SetChildIndex(this.btnApply, 0);
			this.Controls.SetChildIndex(this.txtBerthName, 0);
			this.Controls.SetChildIndex(this.cmbPort, 0);
			this.Controls.SetChildIndex(this.cbxMilitaryFlg, 0);
			this.Controls.SetChildIndex(this.chkInducement, 0);
			this.Controls.SetChildIndex(this.txtMilitaryCode, 0);
			this.Controls.SetChildIndex(this.txtWebBerthDisplay, 0);
			((System.ComponentModel.ISupportInitialize)(this.cmbPort)).EndInit();
			this.ucGroupBox1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private CS2010.CommonWinCtrls.ucTextBox txtBerthCd;
        private CS2010.CommonWinCtrls.ucTextBox txtBerthName;
        private CS2010.AVSS.WinCtrls.ucPortCombo cmbPort;
        private CS2010.AVSS.WinCtrls.ucDayHourMinute cmbEndTime;
        private CS2010.AVSS.WinCtrls.ucDayHourMinute cmbStartTime;
        private CS2010.CommonWinCtrls.ucGroupBox ucGroupBox1;
        private CS2010.CommonWinCtrls.ucCheckBox cbxMilitaryFlg;
		private CS2010.CommonWinCtrls.ucCheckBox chkInducement;
		private CS2010.CommonWinCtrls.ucTextBox txtMilitaryCode;
		private CS2010.CommonWinCtrls.ucTextBox txtWebBerthDisplay;


    }
}
