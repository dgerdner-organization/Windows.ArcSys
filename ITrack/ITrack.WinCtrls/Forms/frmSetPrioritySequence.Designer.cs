namespace ASL.ITrack.WinCtrls
{
	partial class frmSetPrioritySequence
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
			this.components = new System.ComponentModel.Container();
			Janus.Windows.GridEX.GridEXLayout grdIssues_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSetPrioritySequence));
			this.tbrMain = new System.Windows.Forms.ToolStrip();
			this.tbbSave = new System.Windows.Forms.ToolStripButton();
			this.tbbMainN1 = new System.Windows.Forms.ToolStripSeparator();
			this.tbbClose = new System.Windows.Forms.ToolStripButton();
			this.grdIssues = new CS2010.CommonWinCtrls.ucGridEx();
			this.tbrMain.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdIssues)).BeginInit();
			this.SuspendLayout();
			// 
			// tbrMain
			// 
			this.tbrMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbbSave,
            this.tbbMainN1,
            this.tbbClose});
			this.tbrMain.Location = new System.Drawing.Point(0, 0);
			this.tbrMain.Name = "tbrMain";
			this.tbrMain.Size = new System.Drawing.Size(782, 25);
			this.tbrMain.TabIndex = 0;
			this.tbrMain.Visible = false;
			// 
			// tbbSave
			// 
			this.tbbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tbbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tbbSave.Name = "tbbSave";
			this.tbbSave.Size = new System.Drawing.Size(35, 22);
			this.tbbSave.Text = "Save";
			this.tbbSave.Click += new System.EventHandler(this.tbbSave_Click);
			// 
			// tbbMainN1
			// 
			this.tbbMainN1.Name = "tbbMainN1";
			this.tbbMainN1.Size = new System.Drawing.Size(6, 25);
			// 
			// tbbClose
			// 
			this.tbbClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tbbClose.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tbbClose.Name = "tbbClose";
			this.tbbClose.Size = new System.Drawing.Size(37, 22);
			this.tbbClose.Text = "Close";
			this.tbbClose.Click += new System.EventHandler(this.tbbClose_Click);
			// 
			// grdIssues
			// 
			this.grdIssues.AutoEdit = true;
			grdIssues_DesignTimeLayout.LayoutString = resources.GetString("grdIssues_DesignTimeLayout.LayoutString");
			this.grdIssues.DesignTimeLayout = grdIssues_DesignTimeLayout;
			this.grdIssues.DisplayFieldChooser = true;
			this.grdIssues.DisplayFontSelector = true;
			this.grdIssues.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grdIssues.ExportFileID = "Issue List";
			this.grdIssues.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.grdIssues.GroupByBoxInfoFormatStyle.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			this.grdIssues.HideColumnsWhenGrouped = Janus.Windows.GridEX.InheritableBoolean.True;
			this.grdIssues.Location = new System.Drawing.Point(0, 0);
			this.grdIssues.Name = "grdIssues";
			this.grdIssues.Size = new System.Drawing.Size(782, 496);
			this.grdIssues.TabIndex = 7;
			this.grdIssues.UpdateMode = Janus.Windows.GridEX.UpdateMode.CellUpdate;
			// 
			// frmSetPrioritySequence
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(782, 496);
			this.Controls.Add(this.grdIssues);
			this.Controls.Add(this.tbrMain);
			this.MergeToolbar = this.tbrMain;
			this.Name = "frmSetPrioritySequence";
			this.Text = "Set Priority Sequence";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmSetPrioritySequence_FormClosed);
			this.tbrMain.ResumeLayout(false);
			this.tbrMain.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdIssues)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip tbrMain;
		private System.Windows.Forms.ToolStripButton tbbSave;
		private System.Windows.Forms.ToolStripSeparator tbbMainN1;
		private System.Windows.Forms.ToolStripButton tbbClose;
		private CS2010.CommonWinCtrls.ucGridEx grdIssues;
	}
}