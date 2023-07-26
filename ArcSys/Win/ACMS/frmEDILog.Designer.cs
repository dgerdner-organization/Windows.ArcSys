namespace CS2010.ArcSys.Win
{
	partial class frmEDILog
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
			Janus.Windows.GridEX.GridEXLayout cmbPartnerz_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEDILog));
			Janus.Windows.GridEX.GridEXLayout grdLog_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			this.splitMain = new CS2010.CommonWinCtrls.ucSplitContainer();
			this.ucGroupBox1 = new CS2010.CommonWinCtrls.ucGroupBox();
			this.rbAll = new CS2010.CommonWinCtrls.ucRadioButton();
			this.rb360 = new CS2010.CommonWinCtrls.ucRadioButton();
			this.cmbInOut = new CS2010.CommonWinCtrls.ucComboBox();
			this.btnSearch = new CS2010.CommonWinCtrls.ucButton();
			this.cmbPartnerz = new CS2010.CommonWinCtrls.ucMultiColumnCombo();
			this.grdLog = new CS2010.CommonWinCtrls.ucGridEx();
			((System.ComponentModel.ISupportInitialize)(this.splitMain)).BeginInit();
			this.splitMain.Panel1.SuspendLayout();
			this.splitMain.Panel2.SuspendLayout();
			this.splitMain.SuspendLayout();
			this.ucGroupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.cmbPartnerz)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grdLog)).BeginInit();
			this.SuspendLayout();
			// 
			// splitMain
			// 
			this.splitMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.splitMain.Location = new System.Drawing.Point(0, 0);
			this.splitMain.Name = "splitMain";
			this.splitMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitMain.Panel1
			// 
			this.splitMain.Panel1.Controls.Add(this.ucGroupBox1);
			this.splitMain.Panel1.Controls.Add(this.cmbInOut);
			this.splitMain.Panel1.Controls.Add(this.btnSearch);
			this.splitMain.Panel1.Controls.Add(this.cmbPartnerz);
			// 
			// splitMain.Panel2
			// 
			this.splitMain.Panel2.Controls.Add(this.grdLog);
			this.splitMain.Size = new System.Drawing.Size(960, 592);
			this.splitMain.SplitterDistance = 102;
			this.splitMain.TabIndex = 16;
			// 
			// ucGroupBox1
			// 
			this.ucGroupBox1.Controls.Add(this.rbAll);
			this.ucGroupBox1.Controls.Add(this.rb360);
			this.ucGroupBox1.Location = new System.Drawing.Point(332, 3);
			this.ucGroupBox1.Name = "ucGroupBox1";
			this.ucGroupBox1.Size = new System.Drawing.Size(199, 88);
			this.ucGroupBox1.TabIndex = 3;
			this.ucGroupBox1.TabStop = false;
			this.ucGroupBox1.Text = "Age";
			// 
			// rbAll
			// 
			this.rbAll.Location = new System.Drawing.Point(16, 45);
			this.rbAll.Name = "rbAll";
			this.rbAll.Size = new System.Drawing.Size(104, 24);
			this.rbAll.TabIndex = 1;
			this.rbAll.TabStop = true;
			this.rbAll.Text = "All";
			this.rbAll.UseVisualStyleBackColor = true;
			// 
			// rb360
			// 
			this.rb360.Checked = true;
			this.rb360.Location = new System.Drawing.Point(16, 20);
			this.rb360.Name = "rb360";
			this.rb360.Size = new System.Drawing.Size(104, 24);
			this.rb360.TabIndex = 0;
			this.rb360.TabStop = true;
			this.rb360.Text = "360 Days";
			this.rb360.UseVisualStyleBackColor = true;
			// 
			// cmbInOut
			// 
			this.cmbInOut.FormattingEnabled = true;
			this.cmbInOut.Items.AddRange(new object[] {
            "All",
            "Incoming",
            "Outgoing"});
			this.cmbInOut.LabelText = "In/Out";
			this.cmbInOut.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.cmbInOut.Location = new System.Drawing.Point(65, 42);
			this.cmbInOut.Name = "cmbInOut";
			this.cmbInOut.Size = new System.Drawing.Size(121, 21);
			this.cmbInOut.TabIndex = 2;
			// 
			// btnSearch
			// 
			this.btnSearch.Location = new System.Drawing.Point(561, 12);
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Size = new System.Drawing.Size(75, 23);
			this.btnSearch.TabIndex = 1;
			this.btnSearch.Text = "Search";
			this.btnSearch.UseVisualStyleBackColor = true;
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			// 
			// cmbPartnerz
			// 
			cmbPartnerz_DesignTimeLayout.LayoutString = resources.GetString("cmbPartnerz_DesignTimeLayout.LayoutString");
			this.cmbPartnerz.DesignTimeLayout = cmbPartnerz_DesignTimeLayout;
			this.cmbPartnerz.DisplayType = CS2010.CommonWinCtrls.ComboDisplay.CodePlusDescription;
			this.cmbPartnerz.LabelText = "Partner";
			this.cmbPartnerz.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.cmbPartnerz.Location = new System.Drawing.Point(65, 16);
			this.cmbPartnerz.Name = "cmbPartnerz";
			this.cmbPartnerz.SelectedIndex = -1;
			this.cmbPartnerz.SelectedItem = null;
			this.cmbPartnerz.Size = new System.Drawing.Size(248, 20);
			this.cmbPartnerz.TabIndex = 0;
			this.cmbPartnerz.ValueColumn = "partner_cd";
			this.cmbPartnerz.ValueMember = "partner_cd";
			// 
			// grdLog
			// 
			grdLog_DesignTimeLayout.LayoutString = resources.GetString("grdLog_DesignTimeLayout.LayoutString");
			this.grdLog.DesignTimeLayout = grdLog_DesignTimeLayout;
			this.grdLog.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grdLog.ExportFileID = null;
			this.grdLog.Location = new System.Drawing.Point(0, 0);
			this.grdLog.Name = "grdLog";
			this.grdLog.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
			this.grdLog.Size = new System.Drawing.Size(960, 486);
			this.grdLog.TabIndex = 0;
			this.grdLog.SortKeysChanged += new System.EventHandler(this.grdLog_SortKeysChanged);
			this.grdLog.ColumnButtonClick += new Janus.Windows.GridEX.ColumnActionEventHandler(this.grdLog_ColumnButtonClick);
			this.grdLog.LinkClicked += new Janus.Windows.GridEX.ColumnActionEventHandler(this.grdLog_LinkClicked);
			// 
			// frmEDILog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.ClientSize = new System.Drawing.Size(960, 592);
			this.Controls.Add(this.splitMain);
			this.Name = "frmEDILog";
			this.Text = "EDI History";
			this.splitMain.Panel1.ResumeLayout(false);
			this.splitMain.Panel1.PerformLayout();
			this.splitMain.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitMain)).EndInit();
			this.splitMain.ResumeLayout(false);
			this.ucGroupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.cmbPartnerz)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grdLog)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private CommonWinCtrls.ucSplitContainer splitMain;
		private CommonWinCtrls.ucMultiColumnCombo cmbPartnerz;
		private CommonWinCtrls.ucButton btnSearch;
		private CommonWinCtrls.ucGridEx grdLog;
		private CommonWinCtrls.ucComboBox cmbInOut;
		private CommonWinCtrls.ucGroupBox ucGroupBox1;
		private CommonWinCtrls.ucRadioButton rb360;
		private CommonWinCtrls.ucRadioButton rbAll;
	}
}
