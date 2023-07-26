namespace CS2010.ArcSys.Win
{
	partial class frmShowProtocol
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
			Janus.Windows.GridEX.GridEXLayout grdProtocol_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmShowProtocol));
			this.grdProtocol = new CS2010.CommonWinCtrls.ucGridEx();
			this.btnClose = new CS2010.CommonWinCtrls.ucButton();
			this.cbxShowAll = new System.Windows.Forms.CheckBox();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			((System.ComponentModel.ISupportInitialize)(this.grdProtocol)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.SuspendLayout();
			// 
			// grdProtocol
			// 
			this.grdProtocol.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
			grdProtocol_DesignTimeLayout.LayoutString = resources.GetString("grdProtocol_DesignTimeLayout.LayoutString");
			this.grdProtocol.DesignTimeLayout = grdProtocol_DesignTimeLayout;
			this.grdProtocol.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grdProtocol.ExportFileID = null;
			this.grdProtocol.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
			this.grdProtocol.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.grdProtocol.Location = new System.Drawing.Point(0, 0);
			this.grdProtocol.Name = "grdProtocol";
			this.grdProtocol.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
			this.grdProtocol.Size = new System.Drawing.Size(782, 523);
			this.grdProtocol.TabIndex = 0;
			this.grdProtocol.FilterApplied += new System.EventHandler(this.grdProtocol_FilterApplied);
			this.grdProtocol.LinkClicked += new Janus.Windows.GridEX.ColumnActionEventHandler(this.grdProtocol_LinkClicked);
			this.grdProtocol.DoubleClick += new System.EventHandler(this.grdProtocol_DoubleClick);
			this.grdProtocol.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdProtocol_KeyDown);
			// 
			// btnClose
			// 
			this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnClose.Location = new System.Drawing.Point(780, 550);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(75, 23);
			this.btnClose.TabIndex = 1;
			this.btnClose.Text = "Close";
			this.btnClose.UseVisualStyleBackColor = true;
			// 
			// cbxShowAll
			// 
			this.cbxShowAll.AutoSize = true;
			this.cbxShowAll.Location = new System.Drawing.Point(3, 6);
			this.cbxShowAll.Name = "cbxShowAll";
			this.cbxShowAll.Size = new System.Drawing.Size(117, 17);
			this.cbxShowAll.TabIndex = 2;
			this.cbxShowAll.Text = "Show all Messages";
			this.cbxShowAll.UseVisualStyleBackColor = true;
			this.cbxShowAll.CheckedChanged += new System.EventHandler(this.cbxShowAll_CheckedChanged);
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.cbxShowAll);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.grdProtocol);
			this.splitContainer1.Size = new System.Drawing.Size(782, 556);
			this.splitContainer1.SplitterDistance = 29;
			this.splitContainer1.TabIndex = 3;
			// 
			// frmShowProtocol
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(782, 556);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.btnClose);
			this.Name = "frmShowProtocol";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Protocol Detail";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmShowProtocol_Load);
			((System.ComponentModel.ISupportInitialize)(this.grdProtocol)).EndInit();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.PerformLayout();
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private CS2010.CommonWinCtrls.ucGridEx grdProtocol;
		private CS2010.CommonWinCtrls.ucButton btnClose;
		private System.Windows.Forms.CheckBox cbxShowAll;
		private System.Windows.Forms.SplitContainer splitContainer1;
	}
}