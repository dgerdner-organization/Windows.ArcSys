namespace CS2010.ArcSys.Win
{
	partial class frmEditVendor
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditVendor));
			Janus.Windows.GridEX.GridEXLayout cmbCity_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			Janus.Windows.GridEX.GridEXLayout cmbCountry_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			Janus.Windows.GridEX.GridEXLayout cmbGeoRegion_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
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
			this.txtDesc = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtCode = new CS2010.CommonWinCtrls.ucTextBoxPK();
			this.grdResults = new CS2010.CommonWinCtrls.ucGridEx();
			this.pnlMain = new CS2010.CommonWinCtrls.ucSplitContainer();
			this.pnlEditBot = new CS2010.CommonWinCtrls.ucPanel();
			this.txtContactNm = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtPhone1Ext = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtFax = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtEmail = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtPhone1 = new CS2010.CommonWinCtrls.ucTextBox();
			this.btnLookup = new CS2010.CommonWinCtrls.ucButton();
			this.cmbCity = new CS2010.CommonWinCtrls.ucMultiColumnCombo();
			this.cmbCountry = new CS2010.CommonWinCtrls.ucMultiColumnCombo();
			this.txtState = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtPostalCd = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtAddr1 = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtAddr3 = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtAddr2 = new CS2010.CommonWinCtrls.ucTextBox();
			this.splEdit = new CS2010.CommonWinCtrls.ucCollapsibleSplitter();
			this.pnlEditTop = new CS2010.CommonWinCtrls.ucPanel();
			this.chkCONUS = new CS2010.CommonWinCtrls.ucCheckBox();
			this.chkActive = new CS2010.CommonWinCtrls.ucCheckBox();
			this.cmbGeoRegion = new CS2010.ArcSys.WinCtrls.ucGeoRegionCheckBoxCombo();
			this.tbrMain.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdResults)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
			this.pnlMain.Panel1.SuspendLayout();
			this.pnlMain.Panel2.SuspendLayout();
			this.pnlMain.SuspendLayout();
			this.pnlEditBot.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.cmbCity)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbCountry)).BeginInit();
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
			this.tbrMain.Size = new System.Drawing.Size(692, 25);
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
			// txtDesc
			// 
			this.txtDesc.LabelText = "Vendor Name";
			this.txtDesc.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtDesc.LinkDisabledMessage = "Link Disabled";
			this.txtDesc.Location = new System.Drawing.Point(100, 38);
			this.txtDesc.Name = "txtDesc";
			this.txtDesc.Size = new System.Drawing.Size(470, 20);
			this.txtDesc.TabIndex = 5;
			// 
			// txtCode
			// 
			this.txtCode.LabelText = "&Vendor Code";
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
			this.grdResults.Size = new System.Drawing.Size(692, 131);
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
			this.pnlMain.Size = new System.Drawing.Size(692, 592);
			this.pnlMain.SplitterDistance = 131;
			this.pnlMain.TabIndex = 1;
			// 
			// pnlEditBot
			// 
			this.pnlEditBot.AutoScroll = true;
			this.pnlEditBot.Controls.Add(this.txtContactNm);
			this.pnlEditBot.Controls.Add(this.txtPhone1Ext);
			this.pnlEditBot.Controls.Add(this.txtFax);
			this.pnlEditBot.Controls.Add(this.txtEmail);
			this.pnlEditBot.Controls.Add(this.txtPhone1);
			this.pnlEditBot.Controls.Add(this.btnLookup);
			this.pnlEditBot.Controls.Add(this.cmbCity);
			this.pnlEditBot.Controls.Add(this.cmbCountry);
			this.pnlEditBot.Controls.Add(this.txtState);
			this.pnlEditBot.Controls.Add(this.txtPostalCd);
			this.pnlEditBot.Controls.Add(this.txtAddr1);
			this.pnlEditBot.Controls.Add(this.txtAddr3);
			this.pnlEditBot.Controls.Add(this.txtAddr2);
			this.pnlEditBot.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlEditBot.Location = new System.Drawing.Point(0, 101);
			this.pnlEditBot.Name = "pnlEditBot";
			this.pnlEditBot.Size = new System.Drawing.Size(692, 356);
			this.pnlEditBot.TabIndex = 2;
			// 
			// txtContactNm
			// 
			this.txtContactNm.LabelText = "Contact Name";
			this.txtContactNm.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtContactNm.LinkDisabledMessage = "Link Disabled";
			this.txtContactNm.Location = new System.Drawing.Point(100, 214);
			this.txtContactNm.Name = "txtContactNm";
			this.txtContactNm.Size = new System.Drawing.Size(322, 20);
			this.txtContactNm.TabIndex = 16;
			// 
			// txtPhone1Ext
			// 
			this.txtPhone1Ext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtPhone1Ext.LabelText = "Ext";
			this.txtPhone1Ext.LinkDisabledMessage = "Link Disabled";
			this.txtPhone1Ext.Location = new System.Drawing.Point(529, 244);
			this.txtPhone1Ext.Name = "txtPhone1Ext";
			this.txtPhone1Ext.Size = new System.Drawing.Size(41, 20);
			this.txtPhone1Ext.TabIndex = 20;
			// 
			// txtFax
			// 
			this.txtFax.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtFax.LabelText = "&Fax";
			this.txtFax.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtFax.LinkDisabledMessage = "Link Disabled";
			this.txtFax.Location = new System.Drawing.Point(100, 274);
			this.txtFax.Name = "txtFax";
			this.txtFax.Size = new System.Drawing.Size(470, 20);
			this.txtFax.TabIndex = 22;
			// 
			// txtEmail
			// 
			this.txtEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtEmail.LabelText = "&Email";
			this.txtEmail.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtEmail.LinkDisabledMessage = "Link Disabled";
			this.txtEmail.Location = new System.Drawing.Point(100, 304);
			this.txtEmail.Name = "txtEmail";
			this.txtEmail.Size = new System.Drawing.Size(470, 20);
			this.txtEmail.TabIndex = 24;
			// 
			// txtPhone1
			// 
			this.txtPhone1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtPhone1.LabelText = "P&hone";
			this.txtPhone1.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtPhone1.LinkDisabledMessage = "Link Disabled";
			this.txtPhone1.Location = new System.Drawing.Point(100, 244);
			this.txtPhone1.Name = "txtPhone1";
			this.txtPhone1.Size = new System.Drawing.Size(426, 20);
			this.txtPhone1.TabIndex = 18;
			// 
			// btnLookup
			// 
			this.btnLookup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnLookup.Location = new System.Drawing.Point(546, 92);
			this.btnLookup.Name = "btnLookup";
			this.btnLookup.Size = new System.Drawing.Size(24, 23);
			this.btnLookup.TabIndex = 8;
			this.btnLookup.Text = "...";
			this.btnLookup.UseVisualStyleBackColor = true;
			// 
			// cmbCity
			// 
			this.cmbCity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.cmbCity.CodeColumn = "Postal_City";
			this.cmbCity.DescriptionColumn = "Postal_City";
			cmbCity_DesignTimeLayout.LayoutString = resources.GetString("cmbCity_DesignTimeLayout.LayoutString");
			this.cmbCity.DesignTimeLayout = cmbCity_DesignTimeLayout;
			this.cmbCity.DisplayMember = "Postal_City";
			this.cmbCity.LabelText = "City";
			this.cmbCity.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.cmbCity.Location = new System.Drawing.Point(100, 94);
			this.cmbCity.Name = "cmbCity";
			this.cmbCity.SelectedIndex = -1;
			this.cmbCity.SelectedItem = null;
			this.cmbCity.ShowContextMenu = false;
			this.cmbCity.Size = new System.Drawing.Size(440, 20);
			this.cmbCity.TabIndex = 7;
			this.cmbCity.ValueColumn = "Postal_City";
			this.cmbCity.ValueMember = "Postal_City";
			// 
			// cmbCountry
			// 
			this.cmbCountry.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.cmbCountry.CodeColumn = "Country_Cd";
			this.cmbCountry.DescriptionColumn = "Country_Nm";
			cmbCountry_DesignTimeLayout.LayoutString = resources.GetString("cmbCountry_DesignTimeLayout.LayoutString");
			this.cmbCountry.DesignTimeLayout = cmbCountry_DesignTimeLayout;
			this.cmbCountry.DisplayMember = "Country_Cd";
			this.cmbCountry.LabelText = "Coun&try";
			this.cmbCountry.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.cmbCountry.Location = new System.Drawing.Point(100, 184);
			this.cmbCountry.MaxLength = 10;
			this.cmbCountry.Name = "cmbCountry";
			this.cmbCountry.SelectedIndex = -1;
			this.cmbCountry.SelectedItem = null;
			this.cmbCountry.Size = new System.Drawing.Size(470, 20);
			this.cmbCountry.TabIndex = 14;
			this.cmbCountry.ValueColumn = "Country_Cd";
			this.cmbCountry.ValueMember = "Country_Cd";
			// 
			// txtState
			// 
			this.txtState.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtState.LabelText = "State";
			this.txtState.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtState.LinkDisabledMessage = "Link Disabled";
			this.txtState.Location = new System.Drawing.Point(100, 124);
			this.txtState.Name = "txtState";
			this.txtState.Size = new System.Drawing.Size(470, 20);
			this.txtState.TabIndex = 10;
			// 
			// txtPostalCd
			// 
			this.txtPostalCd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtPostalCd.LabelText = "&Postal Code";
			this.txtPostalCd.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtPostalCd.LinkDisabledMessage = "Link Disabled";
			this.txtPostalCd.Location = new System.Drawing.Point(100, 154);
			this.txtPostalCd.MaxLength = 10;
			this.txtPostalCd.Name = "txtPostalCd";
			this.txtPostalCd.Size = new System.Drawing.Size(470, 20);
			this.txtPostalCd.TabIndex = 12;
			// 
			// txtAddr1
			// 
			this.txtAddr1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtAddr1.LabelText = "Address &1";
			this.txtAddr1.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtAddr1.LinkDisabledMessage = "Link Disabled";
			this.txtAddr1.Location = new System.Drawing.Point(100, 4);
			this.txtAddr1.MaxLength = 100;
			this.txtAddr1.Name = "txtAddr1";
			this.txtAddr1.Size = new System.Drawing.Size(470, 20);
			this.txtAddr1.TabIndex = 1;
			// 
			// txtAddr3
			// 
			this.txtAddr3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtAddr3.LabelText = "Address &3";
			this.txtAddr3.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtAddr3.LinkDisabledMessage = "Link Disabled";
			this.txtAddr3.Location = new System.Drawing.Point(100, 64);
			this.txtAddr3.MaxLength = 50;
			this.txtAddr3.Name = "txtAddr3";
			this.txtAddr3.Size = new System.Drawing.Size(470, 20);
			this.txtAddr3.TabIndex = 5;
			// 
			// txtAddr2
			// 
			this.txtAddr2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtAddr2.LabelText = "Address &2";
			this.txtAddr2.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtAddr2.LinkDisabledMessage = "Link Disabled";
			this.txtAddr2.Location = new System.Drawing.Point(100, 34);
			this.txtAddr2.MaxLength = 100;
			this.txtAddr2.Name = "txtAddr2";
			this.txtAddr2.Size = new System.Drawing.Size(470, 20);
			this.txtAddr2.TabIndex = 3;
			// 
			// splEdit
			// 
			this.splEdit.ControlToHide = this.pnlEditBot;
			this.splEdit.Dock = System.Windows.Forms.DockStyle.Top;
			this.splEdit.Location = new System.Drawing.Point(0, 93);
			this.splEdit.Name = "splEdit";
			this.splEdit.Size = new System.Drawing.Size(692, 8);
			this.splEdit.TabIndex = 1;
			this.splEdit.TabStop = false;
			this.splEdit.SplitterCollapseChanged += new System.EventHandler(this.splEdit_SplitterCollapseChanged);
			// 
			// pnlEditTop
			// 
			this.pnlEditTop.AutoScroll = true;
			this.pnlEditTop.Controls.Add(this.cmbGeoRegion);
			this.pnlEditTop.Controls.Add(this.chkCONUS);
			this.pnlEditTop.Controls.Add(this.chkActive);
			this.pnlEditTop.Controls.Add(this.txtCode);
			this.pnlEditTop.Controls.Add(this.txtDesc);
			this.pnlEditTop.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlEditTop.Location = new System.Drawing.Point(0, 0);
			this.pnlEditTop.Name = "pnlEditTop";
			this.pnlEditTop.Size = new System.Drawing.Size(692, 93);
			this.pnlEditTop.TabIndex = 0;
			// 
			// chkCONUS
			// 
			this.chkCONUS.AutoSize = true;
			this.chkCONUS.Location = new System.Drawing.Point(442, 14);
			this.chkCONUS.Name = "chkCONUS";
			this.chkCONUS.Size = new System.Drawing.Size(64, 17);
			this.chkCONUS.TabIndex = 3;
			this.chkCONUS.Text = "CONUS";
			this.chkCONUS.UseVisualStyleBackColor = true;
			this.chkCONUS.YN = "N";
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
			// cmbGeoRegion
			// 
			this.cmbGeoRegion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.cmbGeoRegion.CodeColumn = "Geo_Region_Cd";
			this.cmbGeoRegion.DescriptionColumn = "Geo_Region_Dsc";
			cmbGeoRegion_DesignTimeLayout.LayoutString = resources.GetString("cmbGeoRegion_DesignTimeLayout.LayoutString");
			this.cmbGeoRegion.DesignTimeLayout = cmbGeoRegion_DesignTimeLayout;
			this.cmbGeoRegion.DropDownButtonsVisible = false;
			this.cmbGeoRegion.DropDownDisplayMember = "Geo_Region_Cd";
			this.cmbGeoRegion.DropDownValueMember = "Geo_Region_Cd";
			this.cmbGeoRegion.LabelText = "Geo Regions";
			this.cmbGeoRegion.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.cmbGeoRegion.Location = new System.Drawing.Point(100, 64);
			this.cmbGeoRegion.Name = "cmbGeoRegion";
			this.cmbGeoRegion.SaveSettings = false;
			this.cmbGeoRegion.Size = new System.Drawing.Size(240, 20);
			this.cmbGeoRegion.TabIndex = 7;
			this.cmbGeoRegion.ValueColumn = "Geo_Region_Cd";
			// 
			// frmEditVendor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(692, 617);
			this.Controls.Add(this.pnlMain);
			this.Controls.Add(this.tbrMain);
			this.KeyPreview = true;
			this.Name = "frmEditVendor";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Vendor Maintenance";
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
			((System.ComponentModel.ISupportInitialize)(this.cmbCity)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbCountry)).EndInit();
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
		private CS2010.CommonWinCtrls.ucTextBox txtDesc;
		private CS2010.CommonWinCtrls.ucTextBoxPK txtCode;
		private CS2010.CommonWinCtrls.ucGridEx grdResults;
		private CS2010.CommonWinCtrls.ucSplitContainer pnlMain;
		private CommonWinCtrls.ucCheckBox chkActive;
		private CommonWinCtrls.ucPanel pnlEditBot;
		private CommonWinCtrls.ucCollapsibleSplitter splEdit;
		private CommonWinCtrls.ucPanel pnlEditTop;
		protected CommonWinCtrls.ucButton btnLookup;
		protected CommonWinCtrls.ucMultiColumnCombo cmbCity;
		protected CommonWinCtrls.ucMultiColumnCombo cmbCountry;
		protected CommonWinCtrls.ucTextBox txtState;
		protected CommonWinCtrls.ucTextBox txtPostalCd;
		protected CommonWinCtrls.ucTextBox txtAddr1;
		protected CommonWinCtrls.ucTextBox txtAddr3;
		protected CommonWinCtrls.ucTextBox txtAddr2;
		protected CommonWinCtrls.ucTextBox txtPhone1Ext;
		protected CommonWinCtrls.ucTextBox txtFax;
		protected CommonWinCtrls.ucTextBox txtEmail;
		protected CommonWinCtrls.ucTextBox txtPhone1;
		private CommonWinCtrls.ucTextBox txtContactNm;
		private CommonWinCtrls.ucCheckBox chkCONUS;
		private WinCtrls.ucGeoRegionCheckBoxCombo cmbGeoRegion;
	}
}