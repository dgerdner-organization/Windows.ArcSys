namespace CS2010.AVSS.Win
{
	partial class frmEditVesselBerthActivity
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditVesselBerthActivity));
			this.comboActivity = new CS2010.CommonWinCtrls.ucComboBox();
			this.comboTradeLane = new CS2010.AVSS.WinCtrls.ucTradeLaneCombo();
			this.txtVoyageNo = new CS2010.CommonWinCtrls.ucTextBox();
			((System.ComponentModel.ISupportInitialize)(this.comboTradeLane)).BeginInit();
			this.SuspendLayout();
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(81, 123);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(169, 123);
			// 
			// btnApply
			// 
			this.btnApply.Location = new System.Drawing.Point(257, 123);
			this.btnApply.TabStop = true;
			this.btnApply.UseVisualStyleBackColor = false;
			// 
			// comboActivity
			// 
			this.comboActivity.DisplayMember = "berth_activity_dsc";
			this.comboActivity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboActivity.FormattingEnabled = true;
			this.comboActivity.LabelText = "Activity";
			this.comboActivity.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.comboActivity.Location = new System.Drawing.Point(123, 26);
			this.comboActivity.Name = "comboActivity";
			this.comboActivity.Size = new System.Drawing.Size(209, 21);
			this.comboActivity.TabIndex = 3;
			this.comboActivity.ValueMember = "berth_activity_cd";
			this.comboActivity.Validated += new System.EventHandler(this.comboActivity_Validated);
			// 
			// comboTradeLane
			// 
			this.comboTradeLane.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.comboTradeLane.CodeColumn = "TRADE_LANE_CD";
			this.comboTradeLane.ComboStyle = Janus.Windows.GridEX.ComboStyle.DropDownList;
			this.comboTradeLane.DescriptionColumn = "TRADE_LANE_NM";
			gridEXLayout1.LayoutString = resources.GetString("gridEXLayout1.LayoutString");
			this.comboTradeLane.DesignTimeLayout = gridEXLayout1;
			this.comboTradeLane.DisplayMember = "TRADE_LANE_CDTRADE_LANE_NM";
			this.comboTradeLane.DisplayType = CS2010.CommonWinCtrls.ComboDisplay.CodePlusDescription;
			this.comboTradeLane.ForeColor = System.Drawing.Color.Black;
			this.comboTradeLane.LabelText = "TradeLane:";
			this.comboTradeLane.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.comboTradeLane.Location = new System.Drawing.Point(123, 53);
			this.comboTradeLane.Name = "comboTradeLane";
			this.comboTradeLane.SaveSettings = false;
			this.comboTradeLane.SelectedIndex = -1;
			this.comboTradeLane.SelectedItem = null;
			this.comboTradeLane.Size = new System.Drawing.Size(209, 20);
			this.comboTradeLane.TabIndex = 4;
			this.comboTradeLane.ValueColumn = "TRADE_LANE_CD";
			this.comboTradeLane.ValueMember = "TRADE_LANE_CD";
			// 
			// txtVoyageNo
			// 
			this.txtVoyageNo.LabelText = "Voyage";
			this.txtVoyageNo.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtVoyageNo.LinkDisabledMessage = "Link Disabled";
			this.txtVoyageNo.Location = new System.Drawing.Point(123, 80);
			this.txtVoyageNo.MaxLength = 3;
			this.txtVoyageNo.Name = "txtVoyageNo";
			this.txtVoyageNo.Size = new System.Drawing.Size(100, 20);
			this.txtVoyageNo.TabIndex = 5;
			// 
			// frmEditVesselBerthActivity
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.ClientSize = new System.Drawing.Size(382, 193);
			this.Controls.Add(this.txtVoyageNo);
			this.Controls.Add(this.comboTradeLane);
			this.Controls.Add(this.comboActivity);
			this.Name = "frmEditVesselBerthActivity";
			this.Text = "Edit Vessel Berth Activity";
			this.Load += new System.EventHandler(this.frmEditActivity_Load);
			this.Controls.SetChildIndex(this.comboActivity, 0);
			this.Controls.SetChildIndex(this.comboTradeLane, 0);
			this.Controls.SetChildIndex(this.txtVoyageNo, 0);
			this.Controls.SetChildIndex(this.btnCancel, 0);
			this.Controls.SetChildIndex(this.btnOK, 0);
			this.Controls.SetChildIndex(this.btnApply, 0);
			((System.ComponentModel.ISupportInitialize)(this.comboTradeLane)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

		private CS2010.CommonWinCtrls.ucComboBox comboActivity;
		private CS2010.AVSS.WinCtrls.ucTradeLaneCombo comboTradeLane;
		private CS2010.CommonWinCtrls.ucTextBox txtVoyageNo;



	}
}
