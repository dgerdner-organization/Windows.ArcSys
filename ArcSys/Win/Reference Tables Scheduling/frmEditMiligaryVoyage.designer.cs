namespace CS2010.ArcSys.Win
{
    partial class frmEditMilitaryVoyage
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
			Janus.Windows.GridEX.GridEXLayout cmbTradeLane_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditMilitaryVoyage));
			this.txtMilVoy = new CS2010.CommonWinCtrls.ucTextBox();
			this.cmbTradeLane = new CS2010.AVSS.WinCtrls.ucTradeLaneCombo();
			this.txtVoyageNo = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtSuffix = new CS2010.CommonWinCtrls.ucTextBox();
			this.ucGroupBox1 = new CS2010.CommonWinCtrls.ucGroupBox();
			this.txtNewVoyDoc = new CS2010.CommonWinCtrls.ucTextBox();
			this.btnChange = new CS2010.CommonWinCtrls.ucButton();
			this.txtChangeMsgt = new CS2010.CommonWinCtrls.ucTextBox();
			((System.ComponentModel.ISupportInitialize)(this.cmbTradeLane)).BeginInit();
			this.ucGroupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(100, 123);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(188, 123);
			// 
			// btnApply
			// 
			this.btnApply.Location = new System.Drawing.Point(276, 123);
			this.btnApply.TabStop = true;
			this.btnApply.UseVisualStyleBackColor = false;
			// 
			// txtMilVoy
			// 
			this.txtMilVoy.LabelText = "Military Voyage#";
			this.txtMilVoy.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtMilVoy.LinkDisabledMessage = "Link Disabled";
			this.txtMilVoy.Location = new System.Drawing.Point(102, 12);
			this.txtMilVoy.Name = "txtMilVoy";
			this.txtMilVoy.Size = new System.Drawing.Size(75, 20);
			this.txtMilVoy.TabIndex = 3;
			// 
			// cmbTradeLane
			// 
			this.cmbTradeLane.CodeColumn = "TRADE_LANE_CD";
			this.cmbTradeLane.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList;
			this.cmbTradeLane.DescriptionColumn = "TRADE_LANE_NM";
			cmbTradeLane_DesignTimeLayout.LayoutString = resources.GetString("cmbTradeLane_DesignTimeLayout.LayoutString");
			this.cmbTradeLane.DesignTimeLayout = cmbTradeLane_DesignTimeLayout;
			this.cmbTradeLane.DisplayMember = "TRADE_LANE_CDTRADE_LANE_NM";
			this.cmbTradeLane.DisplayType = CS2010.CommonWinCtrls.ComboDisplay.CodePlusDescription;
			this.cmbTradeLane.LabelText = "TradeLane:";
			this.cmbTradeLane.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.cmbTradeLane.Location = new System.Drawing.Point(102, 39);
			this.cmbTradeLane.Name = "cmbTradeLane";
			this.cmbTradeLane.SelectedIndex = -1;
			this.cmbTradeLane.SelectedItem = null;
			this.cmbTradeLane.Size = new System.Drawing.Size(138, 20);
			this.cmbTradeLane.TabIndex = 4;
			this.cmbTradeLane.ValueColumn = "TRADE_LANE_CD";
			this.cmbTradeLane.ValueMember = "TRADE_LANE_CD";
			// 
			// txtVoyageNo
			// 
			this.txtVoyageNo.LabelText = "Voyage";
			this.txtVoyageNo.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtVoyageNo.LinkDisabledMessage = "Link Disabled";
			this.txtVoyageNo.Location = new System.Drawing.Point(103, 67);
			this.txtVoyageNo.MaxLength = 3;
			this.txtVoyageNo.Name = "txtVoyageNo";
			this.txtVoyageNo.Size = new System.Drawing.Size(74, 20);
			this.txtVoyageNo.TabIndex = 5;
			// 
			// txtSuffix
			// 
			this.txtSuffix.LabelText = "Suffix";
			this.txtSuffix.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtSuffix.LinkDisabledMessage = "Link Disabled";
			this.txtSuffix.Location = new System.Drawing.Point(104, 96);
			this.txtSuffix.MaxLength = 1;
			this.txtSuffix.Name = "txtSuffix";
			this.txtSuffix.Size = new System.Drawing.Size(23, 20);
			this.txtSuffix.TabIndex = 6;
			// 
			// ucGroupBox1
			// 
			this.ucGroupBox1.Controls.Add(this.txtChangeMsgt);
			this.ucGroupBox1.Controls.Add(this.btnChange);
			this.ucGroupBox1.Controls.Add(this.txtNewVoyDoc);
			this.ucGroupBox1.Location = new System.Drawing.Point(26, 152);
			this.ucGroupBox1.Name = "ucGroupBox1";
			this.ucGroupBox1.Size = new System.Drawing.Size(325, 112);
			this.ucGroupBox1.TabIndex = 7;
			this.ucGroupBox1.TabStop = false;
			this.ucGroupBox1.Text = "Change VoyDoc";
			// 
			// txtNewVoyDoc
			// 
			this.txtNewVoyDoc.LabelText = "New Mil Voyage#";
			this.txtNewVoyDoc.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtNewVoyDoc.LinkDisabledMessage = "Link Disabled";
			this.txtNewVoyDoc.Location = new System.Drawing.Point(114, 58);
			this.txtNewVoyDoc.Name = "txtNewVoyDoc";
			this.txtNewVoyDoc.Size = new System.Drawing.Size(100, 20);
			this.txtNewVoyDoc.TabIndex = 0;
			// 
			// btnChange
			// 
			this.btnChange.Location = new System.Drawing.Point(114, 81);
			this.btnChange.Name = "btnChange";
			this.btnChange.Size = new System.Drawing.Size(75, 23);
			this.btnChange.TabIndex = 1;
			this.btnChange.Text = "Change";
			this.btnChange.UseVisualStyleBackColor = true;
			this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
			// 
			// txtChangeMsgt
			// 
			this.txtChangeMsgt.BackColor = System.Drawing.SystemColors.Control;
			this.txtChangeMsgt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
			this.txtChangeMsgt.ForeColor = System.Drawing.Color.Black;
			this.txtChangeMsgt.LinkDisabledMessage = "Link Disabled";
			this.txtChangeMsgt.Location = new System.Drawing.Point(16, 16);
			this.txtChangeMsgt.Multiline = true;
			this.txtChangeMsgt.Name = "txtChangeMsgt";
			this.txtChangeMsgt.ReadOnly = true;
			this.txtChangeMsgt.Size = new System.Drawing.Size(303, 39);
			this.txtChangeMsgt.TabIndex = 2;
			this.txtChangeMsgt.TabStop = false;
			this.txtChangeMsgt.Text = "Use this to change the VoyDoc#.  It will update all voyages, bookings, etc with t" +
				"he new number.";
			// 
			// frmEditMilitaryVoyage
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.ClientSize = new System.Drawing.Size(382, 276);
			this.Controls.Add(this.ucGroupBox1);
			this.Controls.Add(this.txtSuffix);
			this.Controls.Add(this.txtMilVoy);
			this.Controls.Add(this.cmbTradeLane);
			this.Controls.Add(this.txtVoyageNo);
			this.Name = "frmEditMilitaryVoyage";
			this.Text = "Edit Military Voyage";
			this.Load += new System.EventHandler(this.frmEditMilitaryVoyage_Load);
			this.Controls.SetChildIndex(this.btnOK, 0);
			this.Controls.SetChildIndex(this.btnCancel, 0);
			this.Controls.SetChildIndex(this.txtVoyageNo, 0);
			this.Controls.SetChildIndex(this.cmbTradeLane, 0);
			this.Controls.SetChildIndex(this.btnApply, 0);
			this.Controls.SetChildIndex(this.txtMilVoy, 0);
			this.Controls.SetChildIndex(this.txtSuffix, 0);
			this.Controls.SetChildIndex(this.ucGroupBox1, 0);
			((System.ComponentModel.ISupportInitialize)(this.cmbTradeLane)).EndInit();
			this.ucGroupBox1.ResumeLayout(false);
			this.ucGroupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

		private CS2010.CommonWinCtrls.ucTextBox txtMilVoy;
		private CS2010.AVSS.WinCtrls.ucTradeLaneCombo cmbTradeLane;
		private CS2010.CommonWinCtrls.ucTextBox txtVoyageNo;
		private CS2010.CommonWinCtrls.ucTextBox txtSuffix;
		private CommonWinCtrls.ucGroupBox ucGroupBox1;
		private CommonWinCtrls.ucTextBox txtChangeMsgt;
		private CommonWinCtrls.ucButton btnChange;
		private CommonWinCtrls.ucTextBox txtNewVoyDoc;


	}
}
