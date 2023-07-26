namespace CS2010.ArcSys.Win
{
	partial class frmLHaulBillingExgtract
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
            Janus.Windows.GridEX.GridEXLayout cmbDestination_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLHaulBillingExgtract));
            Janus.Windows.GridEX.GridEXLayout cmbOrigin_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout cmbPOD_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout cmbPOL_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout grdResults_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            this.sbbProgressMeter = new System.Windows.Forms.ToolStripProgressBar();
            this.sbbProgressCaption = new System.Windows.Forms.ToolStripStatusLabel();
            this.sbrChild = new System.Windows.Forms.StatusStrip();
            this.cbxAR = new CS2010.CommonWinCtrls.ucCheckBox();
            this.cbxAP = new CS2010.CommonWinCtrls.ucCheckBox();
            this.cmbDestination = new CS2010.ArcSys.WinCtrls.ucLocationCombo();
            this.cmbOrigin = new CS2010.ArcSys.WinCtrls.ucLocationCombo();
            this.cmbPOD = new CS2010.ArcSys.WinCtrls.ucLocationCombo();
            this.cmbPOL = new CS2010.ArcSys.WinCtrls.ucLocationCombo();
            this.txtSerialNo = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtVoyageNo = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtPCFN = new CS2010.CommonWinCtrls.ucTextBox();
            this.btnClear = new Infragistics.Win.Misc.UltraButton();
            this.btnSearch = new Infragistics.Win.Misc.UltraButton();
            this.grdResults = new CS2010.CommonWinCtrls.ucGridEx();
            this.tbrMain = new System.Windows.Forms.ToolStrip();
            this.ucPanel1 = new CS2010.CommonWinCtrls.ucPanel();
            this.sbrChild.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDestination)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbOrigin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPOD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPOL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdResults)).BeginInit();
            this.ucPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // sbbProgressMeter
            // 
            this.sbbProgressMeter.Name = "sbbProgressMeter";
            this.sbbProgressMeter.Size = new System.Drawing.Size(100, 16);
            this.sbbProgressMeter.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            // 
            // sbbProgressCaption
            // 
            this.sbbProgressCaption.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.sbbProgressCaption.IsLink = true;
            this.sbbProgressCaption.Name = "sbbProgressCaption";
            this.sbbProgressCaption.Size = new System.Drawing.Size(223, 17);
            this.sbbProgressCaption.Text = "Searching... (Click here to cancel the search)";
            this.sbbProgressCaption.Click += new System.EventHandler(this.sbbProgressCaption_Click);
            // 
            // sbrChild
            // 
            this.sbrChild.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sbbProgressCaption,
            this.sbbProgressMeter});
            this.sbrChild.Location = new System.Drawing.Point(0, 694);
            this.sbrChild.Name = "sbrChild";
            this.sbrChild.Size = new System.Drawing.Size(992, 22);
            this.sbrChild.TabIndex = 4;
            this.sbrChild.Text = "Search Available Main Status Strip";
            this.sbrChild.Visible = false;
            // 
            // cbxAR
            // 
            this.cbxAR.Checked = true;
            this.cbxAR.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxAR.Location = new System.Drawing.Point(583, 9);
            this.cbxAR.Name = "cbxAR";
            this.cbxAR.Size = new System.Drawing.Size(104, 24);
            this.cbxAR.TabIndex = 31;
            this.cbxAR.Text = "Include AR";
            this.cbxAR.UseVisualStyleBackColor = true;
            this.cbxAR.YN = "Y";
            // 
            // cbxAP
            // 
            this.cbxAP.Location = new System.Drawing.Point(583, 30);
            this.cbxAP.Name = "cbxAP";
            this.cbxAP.Size = new System.Drawing.Size(104, 24);
            this.cbxAP.TabIndex = 30;
            this.cbxAP.Text = "Include AP";
            this.cbxAP.UseVisualStyleBackColor = true;
            this.cbxAP.YN = "N";
            // 
            // cmbDestination
            // 
            this.cmbDestination.CodeColumn = "Location_Cd";
            this.cmbDestination.DescriptionColumn = "Location_Dsc";
            cmbDestination_DesignTimeLayout.LayoutString = resources.GetString("cmbDestination_DesignTimeLayout.LayoutString");
            this.cmbDestination.DesignTimeLayout = cmbDestination_DesignTimeLayout;
            this.cmbDestination.DisplayMember = "Location_Dsc";
            this.cmbDestination.DisplayType = CS2010.CommonWinCtrls.ComboDisplay.DescriptionOnly;
            this.cmbDestination.LabelText = "Destination";
            this.cmbDestination.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.cmbDestination.Location = new System.Drawing.Point(329, 73);
            this.cmbDestination.Name = "cmbDestination";
            this.cmbDestination.SelectedIndex = -1;
            this.cmbDestination.SelectedItem = null;
            this.cmbDestination.Size = new System.Drawing.Size(207, 20);
            this.cmbDestination.SortType = CS2010.CommonWinCtrls.ComboSortType.Description;
            this.cmbDestination.TabIndex = 29;
            this.cmbDestination.ValueColumn = "Location_Cd";
            this.cmbDestination.ValueMember = "Location_Cd";
            // 
            // cmbOrigin
            // 
            this.cmbOrigin.CodeColumn = "Location_Cd";
            this.cmbOrigin.DescriptionColumn = "Location_Dsc";
            cmbOrigin_DesignTimeLayout.LayoutString = resources.GetString("cmbOrigin_DesignTimeLayout.LayoutString");
            this.cmbOrigin.DesignTimeLayout = cmbOrigin_DesignTimeLayout;
            this.cmbOrigin.DisplayMember = "Location_Dsc";
            this.cmbOrigin.DisplayType = CS2010.CommonWinCtrls.ComboDisplay.DescriptionOnly;
            this.cmbOrigin.LabelText = "Origin";
            this.cmbOrigin.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.cmbOrigin.Location = new System.Drawing.Point(329, 50);
            this.cmbOrigin.Name = "cmbOrigin";
            this.cmbOrigin.SelectedIndex = -1;
            this.cmbOrigin.SelectedItem = null;
            this.cmbOrigin.Size = new System.Drawing.Size(207, 20);
            this.cmbOrigin.SortType = CS2010.CommonWinCtrls.ComboSortType.Description;
            this.cmbOrigin.TabIndex = 28;
            this.cmbOrigin.ValueColumn = "Location_Cd";
            this.cmbOrigin.ValueMember = "Location_Cd";
            // 
            // cmbPOD
            // 
            this.cmbPOD.CodeColumn = "Location_Cd";
            this.cmbPOD.DescriptionColumn = "Location_Dsc";
            cmbPOD_DesignTimeLayout.LayoutString = resources.GetString("cmbPOD_DesignTimeLayout.LayoutString");
            this.cmbPOD.DesignTimeLayout = cmbPOD_DesignTimeLayout;
            this.cmbPOD.DisplayMember = "Location_Dsc";
            this.cmbPOD.DisplayType = CS2010.CommonWinCtrls.ComboDisplay.DescriptionOnly;
            this.cmbPOD.LabelText = "POD";
            this.cmbPOD.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.cmbPOD.Location = new System.Drawing.Point(329, 29);
            this.cmbPOD.Name = "cmbPOD";
            this.cmbPOD.PortsOnly = true;
            this.cmbPOD.SelectedIndex = -1;
            this.cmbPOD.SelectedItem = null;
            this.cmbPOD.Size = new System.Drawing.Size(207, 20);
            this.cmbPOD.SortType = CS2010.CommonWinCtrls.ComboSortType.Description;
            this.cmbPOD.TabIndex = 27;
            this.cmbPOD.ValueColumn = "Location_Cd";
            this.cmbPOD.ValueMember = "Location_Cd";
            // 
            // cmbPOL
            // 
            this.cmbPOL.CodeColumn = "Location_Cd";
            this.cmbPOL.DescriptionColumn = "Location_Dsc";
            cmbPOL_DesignTimeLayout.LayoutString = resources.GetString("cmbPOL_DesignTimeLayout.LayoutString");
            this.cmbPOL.DesignTimeLayout = cmbPOL_DesignTimeLayout;
            this.cmbPOL.DisplayMember = "Location_Dsc";
            this.cmbPOL.DisplayType = CS2010.CommonWinCtrls.ComboDisplay.DescriptionOnly;
            this.cmbPOL.LabelText = "POL";
            this.cmbPOL.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.cmbPOL.Location = new System.Drawing.Point(329, 7);
            this.cmbPOL.Name = "cmbPOL";
            this.cmbPOL.PortsOnly = true;
            this.cmbPOL.SelectedIndex = -1;
            this.cmbPOL.SelectedItem = null;
            this.cmbPOL.Size = new System.Drawing.Size(207, 20);
            this.cmbPOL.SortType = CS2010.CommonWinCtrls.ComboSortType.Description;
            this.cmbPOL.TabIndex = 26;
            this.cmbPOL.ValueColumn = "Location_Cd";
            this.cmbPOL.ValueMember = "Location_Cd";
            // 
            // txtSerialNo
            // 
            this.txtSerialNo.LabelBackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.txtSerialNo.LabelText = "Serial#";
            this.txtSerialNo.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtSerialNo.LinkDisabledMessage = "Link Disabled";
            this.txtSerialNo.Location = new System.Drawing.Point(69, 51);
            this.txtSerialNo.Name = "txtSerialNo";
            this.txtSerialNo.Size = new System.Drawing.Size(153, 20);
            this.txtSerialNo.TabIndex = 25;
            // 
            // txtVoyageNo
            // 
            this.txtVoyageNo.LabelBackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.txtVoyageNo.LabelText = "Voyage";
            this.txtVoyageNo.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtVoyageNo.LinkDisabledMessage = "Link Disabled";
            this.txtVoyageNo.Location = new System.Drawing.Point(69, 7);
            this.txtVoyageNo.Name = "txtVoyageNo";
            this.txtVoyageNo.Size = new System.Drawing.Size(153, 20);
            this.txtVoyageNo.TabIndex = 24;
            // 
            // txtPCFN
            // 
            this.txtPCFN.LabelBackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.txtPCFN.LabelText = "PCFN";
            this.txtPCFN.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtPCFN.LinkDisabledMessage = "Link Disabled";
            this.txtPCFN.Location = new System.Drawing.Point(69, 29);
            this.txtPCFN.Name = "txtPCFN";
            this.txtPCFN.Size = new System.Drawing.Size(153, 20);
            this.txtPCFN.TabIndex = 23;
            // 
            // btnClear
            // 
            this.btnClear.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2007RibbonButton;
            this.btnClear.Location = new System.Drawing.Point(729, 34);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 21;
            this.btnClear.Text = "Clear";
            this.btnClear.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.btnClear.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(729, 10);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 20;
            this.btnSearch.Text = "&Search";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // grdResults
            // 
            this.grdResults.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.grdResults.AllowRemoveColumns = Janus.Windows.GridEX.InheritableBoolean.True;
            grdResults_DesignTimeLayout.LayoutString = resources.GetString("grdResults_DesignTimeLayout.LayoutString");
            this.grdResults.DesignTimeLayout = grdResults_DesignTimeLayout;
            this.grdResults.DisplayFieldChooser = true;
            this.grdResults.DisplayFieldChooserChildren = true;
            this.grdResults.DisplayFontSelector = true;
            this.grdResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdResults.ExportFileID = null;
            this.grdResults.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.grdResults.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown;
            this.grdResults.FilterRowFormatStyle.BackColor = System.Drawing.Color.AliceBlue;
            this.grdResults.FilterRowFormatStyle.BackColorGradient = System.Drawing.Color.PowderBlue;
            this.grdResults.FilterRowFormatStyle.BackgroundGradientMode = Janus.Windows.GridEX.BackgroundGradientMode.Vertical;
            this.grdResults.FilterRowUpdateMode = Janus.Windows.GridEX.FilterRowUpdateMode.WhenValueChanges;
            this.grdResults.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.grdResults.Hierarchical = true;
            this.grdResults.Location = new System.Drawing.Point(0, 135);
            this.grdResults.Name = "grdResults";
            this.grdResults.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
            this.grdResults.Size = new System.Drawing.Size(992, 581);
            this.grdResults.TabIndex = 1;
            this.grdResults.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
            this.grdResults.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
            this.grdResults.ColumnButtonClick += new Janus.Windows.GridEX.ColumnActionEventHandler(this.grdResults_ColumnButtonClick);
            this.grdResults.DoubleClick += new System.EventHandler(this.grdResults_DoubleClick);
            this.grdResults.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdResults_KeyDown);
            // 
            // tbrMain
            // 
            this.tbrMain.Location = new System.Drawing.Point(0, 0);
            this.tbrMain.Name = "tbrMain";
            this.tbrMain.Size = new System.Drawing.Size(992, 25);
            this.tbrMain.TabIndex = 5;
            this.tbrMain.Text = "toolStrip1";
            // 
            // ucPanel1
            // 
            this.ucPanel1.Controls.Add(this.txtPCFN);
            this.ucPanel1.Controls.Add(this.cbxAR);
            this.ucPanel1.Controls.Add(this.cmbDestination);
            this.ucPanel1.Controls.Add(this.btnClear);
            this.ucPanel1.Controls.Add(this.cbxAP);
            this.ucPanel1.Controls.Add(this.btnSearch);
            this.ucPanel1.Controls.Add(this.txtSerialNo);
            this.ucPanel1.Controls.Add(this.txtVoyageNo);
            this.ucPanel1.Controls.Add(this.cmbOrigin);
            this.ucPanel1.Controls.Add(this.cmbPOD);
            this.ucPanel1.Controls.Add(this.cmbPOL);
            this.ucPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucPanel1.Location = new System.Drawing.Point(0, 25);
            this.ucPanel1.Name = "ucPanel1";
            this.ucPanel1.Size = new System.Drawing.Size(992, 110);
            this.ucPanel1.TabIndex = 32;
            // 
            // frmLHaulBillingExgtract
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 716);
            this.Controls.Add(this.grdResults);
            this.Controls.Add(this.ucPanel1);
            this.Controls.Add(this.sbrChild);
            this.Controls.Add(this.tbrMain);
            this.Name = "frmLHaulBillingExgtract";
            this.Text = "Linehaul Billing Extract";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSearchContractMod_FormClosing);
            this.Load += new System.EventHandler(this.frmSearchContractMod_Load);
            this.sbrChild.ResumeLayout(false);
            this.sbrChild.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDestination)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbOrigin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPOD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPOL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdResults)).EndInit();
            this.ucPanel1.ResumeLayout(false);
            this.ucPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStripProgressBar sbbProgressMeter;
		private System.Windows.Forms.ToolStripStatusLabel sbbProgressCaption;
        private System.Windows.Forms.StatusStrip sbrChild;
		private CommonWinCtrls.ucGridEx grdResults;
		private Infragistics.Win.Misc.UltraButton btnClear;
		private Infragistics.Win.Misc.UltraButton btnSearch;
		private System.Windows.Forms.ToolStrip tbrMain;
		private CommonWinCtrls.ucTextBox txtPCFN;
		private WinCtrls.ucLocationCombo cmbDestination;
		private WinCtrls.ucLocationCombo cmbOrigin;
		private WinCtrls.ucLocationCombo cmbPOD;
		private WinCtrls.ucLocationCombo cmbPOL;
		private CommonWinCtrls.ucTextBox txtSerialNo;
		private CommonWinCtrls.ucTextBox txtVoyageNo;
		private CommonWinCtrls.ucCheckBox cbxAR;
		private CommonWinCtrls.ucCheckBox cbxAP;
        private CommonWinCtrls.ucPanel ucPanel1;
	}
}