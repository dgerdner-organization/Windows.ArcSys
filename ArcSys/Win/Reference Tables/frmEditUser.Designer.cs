namespace CS2010.ArcSys.Win
{
	partial class frmEditUser
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
			if( disposing && (components != null) )
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
			Janus.Windows.GridEX.GridEXLayout grdResults_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditUser));
			this.tbrMain = new System.Windows.Forms.ToolStrip();
			this.tbbRefresh = new System.Windows.Forms.ToolStripButton();
			this.tbbN1 = new System.Windows.Forms.ToolStripSeparator();
			this.tbbNew = new System.Windows.Forms.ToolStripButton();
			this.tbbEdit = new System.Windows.Forms.ToolStripButton();
			this.tbbDelete = new System.Windows.Forms.ToolStripButton();
			this.tbbN2 = new System.Windows.Forms.ToolStripSeparator();
			this.tbbSave = new System.Windows.Forms.ToolStripButton();
			this.tbbCancel = new System.Windows.Forms.ToolStripButton();
			this.tbbN3 = new System.Windows.Forms.ToolStripSeparator();
			this.tbbExit = new System.Windows.Forms.ToolStripButton();
			this.txtFirstNm = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtCode = new CS2010.CommonWinCtrls.ucTextBox();
			this.grdResults = new CS2010.CommonWinCtrls.ucGridEx();
			this.pnlMain = new CS2010.CommonWinCtrls.ucSplitContainer();
			this.pnlEditBot = new CS2010.CommonWinCtrls.ucPanel();
			this.txtEmail = new CS2010.CommonWinCtrls.ucTextBox();
			this.splEdit = new CS2010.CommonWinCtrls.ucCollapsibleSplitter();
			this.pnlEditTop = new CS2010.CommonWinCtrls.ucPanel();
			this.txtLastNm = new CS2010.CommonWinCtrls.ucTextBox();
			this.chkActive = new CS2010.CommonWinCtrls.ucCheckBox();
			this.txtVendorInd = new CS2010.CommonWinCtrls.ucTextBox();
			this.tbrMain.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdResults)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
			this.pnlMain.Panel1.SuspendLayout();
			this.pnlMain.Panel2.SuspendLayout();
			this.pnlMain.SuspendLayout();
			this.pnlEditBot.SuspendLayout();
			this.pnlEditTop.SuspendLayout();
			this.SuspendLayout();
			// 
			// tbrMain
			// 
			this.tbrMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbbRefresh,
            this.tbbN1,
            this.tbbNew,
            this.tbbEdit,
            this.tbbDelete,
            this.tbbN2,
            this.tbbSave,
            this.tbbCancel,
            this.tbbN3,
            this.tbbExit});
			this.tbrMain.Location = new System.Drawing.Point(0, 0);
			this.tbrMain.Name = "tbrMain";
			this.tbrMain.Size = new System.Drawing.Size(732, 25);
			this.tbrMain.TabIndex = 0;
			this.tbrMain.Text = "toolStrip1";
			// 
			// tbbRefresh
			// 
			this.tbbRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tbbRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tbbRefresh.Name = "tbbRefresh";
			this.tbbRefresh.Size = new System.Drawing.Size(49, 22);
			this.tbbRefresh.Text = "&Refresh";
			this.tbbRefresh.Click += new System.EventHandler(this.tbbRefresh_Click);
			// 
			// tbbN1
			// 
			this.tbbN1.Name = "tbbN1";
			this.tbbN1.Size = new System.Drawing.Size(6, 25);
			// 
			// tbbNew
			// 
			this.tbbNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tbbNew.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tbbNew.Name = "tbbNew";
			this.tbbNew.Size = new System.Drawing.Size(32, 22);
			this.tbbNew.Text = "&New";
			this.tbbNew.Click += new System.EventHandler(this.tbbNew_Click);
			// 
			// tbbEdit
			// 
			this.tbbEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tbbEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tbbEdit.Name = "tbbEdit";
			this.tbbEdit.Size = new System.Drawing.Size(29, 22);
			this.tbbEdit.Text = "&Edit";
			this.tbbEdit.Click += new System.EventHandler(this.tbbEdit_Click);
			// 
			// tbbDelete
			// 
			this.tbbDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tbbDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tbbDelete.Name = "tbbDelete";
			this.tbbDelete.Size = new System.Drawing.Size(42, 22);
			this.tbbDelete.Text = "&Delete";
			this.tbbDelete.Click += new System.EventHandler(this.tbbDelete_Click);
			// 
			// tbbN2
			// 
			this.tbbN2.Name = "tbbN2";
			this.tbbN2.Size = new System.Drawing.Size(6, 25);
			// 
			// tbbSave
			// 
			this.tbbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tbbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tbbSave.Name = "tbbSave";
			this.tbbSave.Size = new System.Drawing.Size(35, 22);
			this.tbbSave.Text = "&Save";
			this.tbbSave.Click += new System.EventHandler(this.tbbSave_Click);
			// 
			// tbbCancel
			// 
			this.tbbCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tbbCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tbbCancel.Name = "tbbCancel";
			this.tbbCancel.Size = new System.Drawing.Size(43, 22);
			this.tbbCancel.Text = "&Cancel";
			this.tbbCancel.Click += new System.EventHandler(this.tbbCancel_Click);
			// 
			// tbbN3
			// 
			this.tbbN3.Name = "tbbN3";
			this.tbbN3.Size = new System.Drawing.Size(6, 25);
			// 
			// tbbExit
			// 
			this.tbbExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tbbExit.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tbbExit.Name = "tbbExit";
			this.tbbExit.Size = new System.Drawing.Size(29, 22);
			this.tbbExit.Text = "E&xit";
			this.tbbExit.Click += new System.EventHandler(this.tbbExit_Click);
			// 
			// txtFirstNm
			// 
			this.txtFirstNm.LabelText = "First Name";
			this.txtFirstNm.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtFirstNm.LinkDisabledMessage = "Link Disabled";
			this.txtFirstNm.Location = new System.Drawing.Point(100, 38);
			this.txtFirstNm.Name = "txtFirstNm";
			this.txtFirstNm.Size = new System.Drawing.Size(317, 20);
			this.txtFirstNm.TabIndex = 4;
			// 
			// txtCode
			// 
			this.txtCode.LabelText = "&User Login";
			this.txtCode.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtCode.LinkDisabledMessage = "Link Disabled";
			this.txtCode.Location = new System.Drawing.Point(100, 12);
			this.txtCode.Name = "txtCode";
			this.txtCode.Size = new System.Drawing.Size(240, 20);
			this.txtCode.TabIndex = 1;
			// 
			// grdResults
			// 
			this.grdResults.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
			grdResults_DesignTimeLayout.LayoutString = resources.GetString("grdResults_DesignTimeLayout.LayoutString");
			this.grdResults.DesignTimeLayout = grdResults_DesignTimeLayout;
			this.grdResults.DisplayFieldChooser = true;
			this.grdResults.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grdResults.EnterKeyBehavior = Janus.Windows.GridEX.EnterKeyBehavior.None;
			this.grdResults.ExportFileID = null;
			this.grdResults.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
			this.grdResults.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown;
			this.grdResults.FilterRowFormatStyle.BackColor = System.Drawing.Color.AliceBlue;
			this.grdResults.FilterRowUpdateMode = Janus.Windows.GridEX.FilterRowUpdateMode.WhenValueChanges;
			this.grdResults.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.grdResults.GroupByBoxVisible = false;
			this.grdResults.HideSelection = Janus.Windows.GridEX.HideSelection.HighlightInactive;
			this.grdResults.Location = new System.Drawing.Point(0, 0);
			this.grdResults.Name = "grdResults";
			this.grdResults.Size = new System.Drawing.Size(732, 376);
			this.grdResults.TabIndex = 0;
			this.grdResults.SelectionChanged += new System.EventHandler(this.grdResults_SelectionChanged);
			this.grdResults.DoubleClick += new System.EventHandler(this.grdResults_DoubleClick);
			// 
			// pnlMain
			// 
			this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
			this.pnlMain.Location = new System.Drawing.Point(0, 25);
			this.pnlMain.Name = "pnlMain";
			this.pnlMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// pnlMain.Panel1
			// 
			this.pnlMain.Panel1.Controls.Add(this.grdResults);
			// 
			// pnlMain.Panel2
			// 
			this.pnlMain.Panel2.Controls.Add(this.pnlEditBot);
			this.pnlMain.Panel2.Controls.Add(this.splEdit);
			this.pnlMain.Panel2.Controls.Add(this.pnlEditTop);
			this.pnlMain.Size = new System.Drawing.Size(732, 546);
			this.pnlMain.SplitterDistance = 376;
			this.pnlMain.TabIndex = 1;
			// 
			// pnlEditBot
			// 
			this.pnlEditBot.AutoScroll = true;
			this.pnlEditBot.Controls.Add(this.txtEmail);
			this.pnlEditBot.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlEditBot.Location = new System.Drawing.Point(0, 128);
			this.pnlEditBot.Name = "pnlEditBot";
			this.pnlEditBot.Size = new System.Drawing.Size(732, 38);
			this.pnlEditBot.TabIndex = 2;
			// 
			// txtEmail
			// 
			this.txtEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtEmail.LabelText = "&Email";
			this.txtEmail.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtEmail.LinkDisabledMessage = "Link Disabled";
			this.txtEmail.Location = new System.Drawing.Point(100, 8);
			this.txtEmail.Name = "txtEmail";
			this.txtEmail.Size = new System.Drawing.Size(510, 20);
			this.txtEmail.TabIndex = 1;
			// 
			// splEdit
			// 
			this.splEdit.ControlToHide = this.pnlEditBot;
			this.splEdit.Dock = System.Windows.Forms.DockStyle.Top;
			this.splEdit.Location = new System.Drawing.Point(0, 120);
			this.splEdit.Name = "splEdit";
			this.splEdit.Size = new System.Drawing.Size(732, 8);
			this.splEdit.TabIndex = 1;
			this.splEdit.TabStop = false;
			this.splEdit.SplitterCollapseChanged += new System.EventHandler(this.splEdit_SplitterCollapseChanged);
			// 
			// pnlEditTop
			// 
			this.pnlEditTop.AutoScroll = true;
			this.pnlEditTop.Controls.Add(this.txtVendorInd);
			this.pnlEditTop.Controls.Add(this.txtLastNm);
			this.pnlEditTop.Controls.Add(this.chkActive);
			this.pnlEditTop.Controls.Add(this.txtCode);
			this.pnlEditTop.Controls.Add(this.txtFirstNm);
			this.pnlEditTop.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlEditTop.Location = new System.Drawing.Point(0, 0);
			this.pnlEditTop.Name = "pnlEditTop";
			this.pnlEditTop.Size = new System.Drawing.Size(732, 120);
			this.pnlEditTop.TabIndex = 0;
			// 
			// txtLastNm
			// 
			this.txtLastNm.LabelText = "Last Name";
			this.txtLastNm.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtLastNm.LinkDisabledMessage = "Link Disabled";
			this.txtLastNm.Location = new System.Drawing.Point(100, 64);
			this.txtLastNm.Name = "txtLastNm";
			this.txtLastNm.Size = new System.Drawing.Size(317, 20);
			this.txtLastNm.TabIndex = 6;
			// 
			// chkActive
			// 
			this.chkActive.AutoSize = true;
			this.chkActive.Location = new System.Drawing.Point(361, 14);
			this.chkActive.Name = "chkActive";
			this.chkActive.Size = new System.Drawing.Size(56, 17);
			this.chkActive.TabIndex = 2;
			this.chkActive.Text = "Acti&ve";
			this.chkActive.UseVisualStyleBackColor = true;
			this.chkActive.YN = "N";
			// 
			// txtVendorInd
			// 
			this.txtVendorInd.LabelText = "Visible Vendor";
			this.txtVendorInd.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtVendorInd.LinkDisabledMessage = "Link Disabled";
			this.txtVendorInd.Location = new System.Drawing.Point(100, 90);
			this.txtVendorInd.Name = "txtVendorInd";
			this.txtVendorInd.Size = new System.Drawing.Size(317, 20);
			this.txtVendorInd.TabIndex = 8;
			// 
			// frmEditUser
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(732, 571);
			this.Controls.Add(this.pnlMain);
			this.Controls.Add(this.tbrMain);
			this.KeyPreview = true;
			this.Name = "frmEditUser";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "User Maintenance";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MaintenanceWindow_FormClosing);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MaintenanceWindow_FormClosed);
			this.Load += new System.EventHandler(this.MaintenanceWindow_Load);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MaintenanceWindow_KeyDown);
			this.tbrMain.ResumeLayout(false);
			this.tbrMain.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdResults)).EndInit();
			this.pnlMain.Panel1.ResumeLayout(false);
			this.pnlMain.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
			this.pnlMain.ResumeLayout(false);
			this.pnlEditBot.ResumeLayout(false);
			this.pnlEditBot.PerformLayout();
			this.pnlEditTop.ResumeLayout(false);
			this.pnlEditTop.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip tbrMain;
		private System.Windows.Forms.ToolStripButton tbbRefresh;
		private System.Windows.Forms.ToolStripButton tbbNew;
		private System.Windows.Forms.ToolStripButton tbbEdit;
		private System.Windows.Forms.ToolStripButton tbbDelete;
		private System.Windows.Forms.ToolStripSeparator tbbN2;
		private System.Windows.Forms.ToolStripButton tbbSave;
		private System.Windows.Forms.ToolStripButton tbbCancel;
		private System.Windows.Forms.ToolStripSeparator tbbN3;
		private System.Windows.Forms.ToolStripButton tbbExit;
		private System.Windows.Forms.ToolStripSeparator tbbN1;
		private CS2010.CommonWinCtrls.ucTextBox txtFirstNm;
		private CS2010.CommonWinCtrls.ucTextBox txtCode;
		private CS2010.CommonWinCtrls.ucGridEx grdResults;
		private CS2010.CommonWinCtrls.ucSplitContainer pnlMain;
		private CommonWinCtrls.ucCheckBox chkActive;
		private CommonWinCtrls.ucPanel pnlEditBot;
		private CommonWinCtrls.ucCollapsibleSplitter splEdit;
		private CommonWinCtrls.ucPanel pnlEditTop;
		protected CommonWinCtrls.ucTextBox txtEmail;
		private CommonWinCtrls.ucTextBox txtLastNm;
		private CommonWinCtrls.ucTextBox txtVendorInd;
	}
}