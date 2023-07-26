namespace CS2010.ArcSys.Win
{
	partial class frmITVDiagnostics
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
			Janus.Windows.GridEX.GridEXLayout grdDiagnostics_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmITVDiagnostics));
			Janus.Windows.GridEX.GridEXLayout grdUntransmitted_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			Janus.Windows.GridEX.GridEXLayout grdEDISummary_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			this.grdDiagnostics = new CS2010.CommonWinCtrls.ucGridEx();
			this.tabDiagnostics = new CS2010.CommonWinCtrls.ucTabControl();
			this.tpWarnings = new System.Windows.Forms.TabPage();
			this.ucPanel1 = new CS2010.CommonWinCtrls.ucPanel();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.tpUntransmitted = new System.Windows.Forms.TabPage();
			this.grdUntransmitted = new CS2010.CommonWinCtrls.ucGridEx();
			this.ucPanel2 = new CS2010.CommonWinCtrls.ucPanel();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.tpEDISummary = new System.Windows.Forms.TabPage();
			this.ucSplitContainer1 = new CS2010.CommonWinCtrls.ucSplitContainer();
			this.btnSearchSummary = new CS2010.CommonWinCtrls.ucButton();
			this.grdEDISummary = new CS2010.CommonWinCtrls.ucGridEx();
			((System.ComponentModel.ISupportInitialize)(this.grdDiagnostics)).BeginInit();
			this.tabDiagnostics.SuspendLayout();
			this.tpWarnings.SuspendLayout();
			this.ucPanel1.SuspendLayout();
			this.tpUntransmitted.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdUntransmitted)).BeginInit();
			this.ucPanel2.SuspendLayout();
			this.tpEDISummary.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ucSplitContainer1)).BeginInit();
			this.ucSplitContainer1.Panel1.SuspendLayout();
			this.ucSplitContainer1.Panel2.SuspendLayout();
			this.ucSplitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdEDISummary)).BeginInit();
			this.SuspendLayout();
			// 
			// grdDiagnostics
			// 
			grdDiagnostics_DesignTimeLayout.LayoutString = resources.GetString("grdDiagnostics_DesignTimeLayout.LayoutString");
			this.grdDiagnostics.DesignTimeLayout = grdDiagnostics_DesignTimeLayout;
			this.grdDiagnostics.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grdDiagnostics.ExportFileID = null;
			this.grdDiagnostics.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
			this.grdDiagnostics.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.grdDiagnostics.Location = new System.Drawing.Point(3, 35);
			this.grdDiagnostics.Name = "grdDiagnostics";
			this.grdDiagnostics.Size = new System.Drawing.Size(642, 432);
			this.grdDiagnostics.TabIndex = 0;
			this.grdDiagnostics.LinkClicked += new Janus.Windows.GridEX.ColumnActionEventHandler(this.grdDiagnostics_LinkClicked);
			// 
			// tabDiagnostics
			// 
			this.tabDiagnostics.Controls.Add(this.tpWarnings);
			this.tabDiagnostics.Controls.Add(this.tpUntransmitted);
			this.tabDiagnostics.Controls.Add(this.tpEDISummary);
			this.tabDiagnostics.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabDiagnostics.Location = new System.Drawing.Point(0, 0);
			this.tabDiagnostics.Name = "tabDiagnostics";
			this.tabDiagnostics.SelectedIndex = 0;
			this.tabDiagnostics.Size = new System.Drawing.Size(656, 496);
			this.tabDiagnostics.TabIndex = 1;
			// 
			// tpWarnings
			// 
			this.tpWarnings.Controls.Add(this.grdDiagnostics);
			this.tpWarnings.Controls.Add(this.ucPanel1);
			this.tpWarnings.Location = new System.Drawing.Point(4, 22);
			this.tpWarnings.Name = "tpWarnings";
			this.tpWarnings.Padding = new System.Windows.Forms.Padding(3);
			this.tpWarnings.Size = new System.Drawing.Size(648, 470);
			this.tpWarnings.TabIndex = 0;
			this.tpWarnings.Text = "Warnings";
			this.tpWarnings.UseVisualStyleBackColor = true;
			// 
			// ucPanel1
			// 
			this.ucPanel1.Controls.Add(this.textBox2);
			this.ucPanel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.ucPanel1.Location = new System.Drawing.Point(3, 3);
			this.ucPanel1.Name = "ucPanel1";
			this.ucPanel1.Size = new System.Drawing.Size(642, 32);
			this.ucPanel1.TabIndex = 1;
			// 
			// textBox2
			// 
			this.textBox2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBox2.Location = new System.Drawing.Point(0, 0);
			this.textBox2.Multiline = true;
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(642, 32);
			this.textBox2.TabIndex = 1;
			this.textBox2.Text = "This cargo has some kind of data problem that will prevent ITV messages from bein" +
				"g created.";
			// 
			// tpUntransmitted
			// 
			this.tpUntransmitted.Controls.Add(this.grdUntransmitted);
			this.tpUntransmitted.Controls.Add(this.ucPanel2);
			this.tpUntransmitted.Location = new System.Drawing.Point(4, 22);
			this.tpUntransmitted.Name = "tpUntransmitted";
			this.tpUntransmitted.Padding = new System.Windows.Forms.Padding(3);
			this.tpUntransmitted.Size = new System.Drawing.Size(648, 470);
			this.tpUntransmitted.TabIndex = 1;
			this.tpUntransmitted.Text = "Untransmitted EDI";
			this.tpUntransmitted.UseVisualStyleBackColor = true;
			// 
			// grdUntransmitted
			// 
			grdUntransmitted_DesignTimeLayout.LayoutString = resources.GetString("grdUntransmitted_DesignTimeLayout.LayoutString");
			this.grdUntransmitted.DesignTimeLayout = grdUntransmitted_DesignTimeLayout;
			this.grdUntransmitted.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grdUntransmitted.ExportFileID = null;
			this.grdUntransmitted.Location = new System.Drawing.Point(3, 38);
			this.grdUntransmitted.Name = "grdUntransmitted";
			this.grdUntransmitted.Size = new System.Drawing.Size(642, 429);
			this.grdUntransmitted.TabIndex = 1;
			// 
			// ucPanel2
			// 
			this.ucPanel2.Controls.Add(this.textBox1);
			this.ucPanel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.ucPanel2.Location = new System.Drawing.Point(3, 3);
			this.ucPanel2.Name = "ucPanel2";
			this.ucPanel2.Size = new System.Drawing.Size(642, 35);
			this.ucPanel2.TabIndex = 0;
			// 
			// textBox1
			// 
			this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBox1.Location = new System.Drawing.Point(0, 0);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(642, 35);
			this.textBox1.TabIndex = 0;
			this.textBox1.Text = "These ITV messages have not been transmitted.  It could indicate a problem with t" +
				"he background mapping process that runs periodically.  If there is anything disp" +
				"layed here you should contact IT.";
			// 
			// tpEDISummary
			// 
			this.tpEDISummary.Controls.Add(this.ucSplitContainer1);
			this.tpEDISummary.Location = new System.Drawing.Point(4, 22);
			this.tpEDISummary.Name = "tpEDISummary";
			this.tpEDISummary.Padding = new System.Windows.Forms.Padding(3);
			this.tpEDISummary.Size = new System.Drawing.Size(648, 470);
			this.tpEDISummary.TabIndex = 2;
			this.tpEDISummary.Text = "ITV Summary";
			this.tpEDISummary.UseVisualStyleBackColor = true;
			// 
			// ucSplitContainer1
			// 
			this.ucSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ucSplitContainer1.Location = new System.Drawing.Point(3, 3);
			this.ucSplitContainer1.Name = "ucSplitContainer1";
			this.ucSplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// ucSplitContainer1.Panel1
			// 
			this.ucSplitContainer1.Panel1.Controls.Add(this.btnSearchSummary);
			// 
			// ucSplitContainer1.Panel2
			// 
			this.ucSplitContainer1.Panel2.Controls.Add(this.grdEDISummary);
			this.ucSplitContainer1.Size = new System.Drawing.Size(642, 464);
			this.ucSplitContainer1.SplitterDistance = 46;
			this.ucSplitContainer1.TabIndex = 1;
			// 
			// btnSearchSummary
			// 
			this.btnSearchSummary.Location = new System.Drawing.Point(7, 9);
			this.btnSearchSummary.Name = "btnSearchSummary";
			this.btnSearchSummary.Size = new System.Drawing.Size(75, 23);
			this.btnSearchSummary.TabIndex = 0;
			this.btnSearchSummary.Text = "Search";
			this.btnSearchSummary.UseVisualStyleBackColor = true;
			this.btnSearchSummary.Click += new System.EventHandler(this.btnSearchSummary_Click);
			// 
			// grdEDISummary
			// 
			grdEDISummary_DesignTimeLayout.LayoutString = resources.GetString("grdEDISummary_DesignTimeLayout.LayoutString");
			this.grdEDISummary.DesignTimeLayout = grdEDISummary_DesignTimeLayout;
			this.grdEDISummary.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grdEDISummary.ExportFileID = null;
			this.grdEDISummary.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
			this.grdEDISummary.Location = new System.Drawing.Point(0, 0);
			this.grdEDISummary.Name = "grdEDISummary";
			this.grdEDISummary.Size = new System.Drawing.Size(642, 414);
			this.grdEDISummary.TabIndex = 0;
			this.grdEDISummary.LinkClicked += new Janus.Windows.GridEX.ColumnActionEventHandler(this.grdEDISummary_LinkClicked);
			// 
			// frmITVDiagnostics
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.ClientSize = new System.Drawing.Size(656, 496);
			this.Controls.Add(this.tabDiagnostics);
			this.Name = "frmITVDiagnostics";
			this.Text = "ITV Diagnostics";
			((System.ComponentModel.ISupportInitialize)(this.grdDiagnostics)).EndInit();
			this.tabDiagnostics.ResumeLayout(false);
			this.tpWarnings.ResumeLayout(false);
			this.ucPanel1.ResumeLayout(false);
			this.ucPanel1.PerformLayout();
			this.tpUntransmitted.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.grdUntransmitted)).EndInit();
			this.ucPanel2.ResumeLayout(false);
			this.ucPanel2.PerformLayout();
			this.tpEDISummary.ResumeLayout(false);
			this.ucSplitContainer1.Panel1.ResumeLayout(false);
			this.ucSplitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.ucSplitContainer1)).EndInit();
			this.ucSplitContainer1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.grdEDISummary)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private CommonWinCtrls.ucGridEx grdDiagnostics;
		private CommonWinCtrls.ucTabControl tabDiagnostics;
		private System.Windows.Forms.TabPage tpWarnings;
		private CommonWinCtrls.ucPanel ucPanel1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.TabPage tpUntransmitted;
		private CommonWinCtrls.ucPanel ucPanel2;
		private System.Windows.Forms.TextBox textBox1;
		private CommonWinCtrls.ucGridEx grdUntransmitted;
		private System.Windows.Forms.TabPage tpEDISummary;
		private CommonWinCtrls.ucSplitContainer ucSplitContainer1;
		private CommonWinCtrls.ucButton btnSearchSummary;
		private CommonWinCtrls.ucGridEx grdEDISummary;
	}
}
