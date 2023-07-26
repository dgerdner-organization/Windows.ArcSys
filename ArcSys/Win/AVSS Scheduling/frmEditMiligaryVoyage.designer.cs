namespace CS2010.AVSS.Win
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
			this.components = new System.ComponentModel.Container();
			Janus.Windows.GridEX.GridEXLayout gridEXLayout1 = new Janus.Windows.GridEX.GridEXLayout();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditMilitaryVoyage));
			this.txtMilVoy = new CS2010.CommonWinCtrls.ucTextBox();
			this.cmbTradeLane = new CS2010.AVSS.WinCtrls.ucTradeLaneCombo();
			this.txtVoyageNo = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtSuffix = new CS2010.CommonWinCtrls.ucTextBox();
			((System.ComponentModel.ISupportInitialize)(this.cmbTradeLane)).BeginInit();
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
			this.cmbTradeLane.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.cmbTradeLane.CodeColumn = "TRADE_LANE_CD";
			this.cmbTradeLane.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList;
			this.cmbTradeLane.DescriptionColumn = "TRADE_LANE_NM";
			gridEXLayout1.LayoutString = resources.GetString("gridEXLayout1.LayoutString");
			this.cmbTradeLane.DesignTimeLayout = gridEXLayout1;
			this.cmbTradeLane.DisplayMember = "TRADE_LANE_CDTRADE_LANE_NM";
			this.cmbTradeLane.DisplayType = CS2010.CommonWinCtrls.ComboDisplay.CodePlusDescription;
			this.cmbTradeLane.LabelText = "TradeLane:";
			this.cmbTradeLane.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.cmbTradeLane.Location = new System.Drawing.Point(102, 39);
			this.cmbTradeLane.Name = "cmbTradeLane";
			this.cmbTradeLane.SaveSettings = false;
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
			// frmEditMilitaryVoyage
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.ClientSize = new System.Drawing.Size(382, 158);
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
			((System.ComponentModel.ISupportInitialize)(this.cmbTradeLane)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

		private CS2010.CommonWinCtrls.ucTextBox txtMilVoy;
		private CS2010.AVSS.WinCtrls.ucTradeLaneCombo cmbTradeLane;
		private CS2010.CommonWinCtrls.ucTextBox txtVoyageNo;
		private CS2010.CommonWinCtrls.ucTextBox txtSuffix;


	}
}
