namespace ASL.ITrack.WinCtrls
{
	partial class frmViewIssue
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
			if( disposing && ( components != null ) )
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
			Janus.Windows.GridEX.GridEXLayout grdAttachments_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmViewIssue));
			this.txtNotes = new CS2010.CommonWinCtrls.ucTextBox();
			this.grdAttachments = new CS2010.CommonWinCtrls.ucGridEx();
			this.pnlMain = new CS2010.CommonWinCtrls.ucSplitContainer();
			this.chkAddToIssues = new CS2010.CommonWinCtrls.ucCheckBox();
			this.chkDismissIssue = new CS2010.CommonWinCtrls.ucCheckBox();
			( (System.ComponentModel.ISupportInitialize)( this.grdAttachments ) ).BeginInit();
			this.pnlMain.Panel1.SuspendLayout();
			this.pnlMain.Panel2.SuspendLayout();
			this.pnlMain.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(586, 433);
			this.btnOK.TabIndex = 3;
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(670, 433);
			this.btnCancel.TabIndex = 4;
			// 
			// btnApply
			// 
			this.btnApply.Location = new System.Drawing.Point(754, 433);
			this.btnApply.TabIndex = 5;
			this.btnApply.TabStop = true;
			this.btnApply.UseVisualStyleBackColor = false;
			// 
			// txtNotes
			// 
			this.txtNotes.BackColor = System.Drawing.SystemColors.Control;
			this.txtNotes.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtNotes.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtNotes.ForeColor = System.Drawing.Color.Black;
			this.txtNotes.LinkDisabledMessage = "Link Disabled";
			this.txtNotes.Location = new System.Drawing.Point(0, 0);
			this.txtNotes.Multiline = true;
			this.txtNotes.Name = "txtNotes";
			this.txtNotes.ReadOnly = true;
			this.txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtNotes.Size = new System.Drawing.Size(432, 427);
			this.txtNotes.TabIndex = 0;
			this.txtNotes.TabStop = false;
			// 
			// grdAttachments
			// 
			this.grdAttachments.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
			this.grdAttachments.BuiltInTextsData = "<LocalizableData ID=\"LocalizableStrings\" Collection=\"true\"><EmptyGridInfo>No Atta" +
				"chments Provided</EmptyGridInfo></LocalizableData>";
			grdAttachments_DesignTimeLayout.LayoutString = resources.GetString("grdAttachments_DesignTimeLayout.LayoutString");
			this.grdAttachments.DesignTimeLayout = grdAttachments_DesignTimeLayout;
			this.grdAttachments.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grdAttachments.ExportFileID = null;
			this.grdAttachments.GroupByBoxVisible = false;
			this.grdAttachments.Location = new System.Drawing.Point(0, 0);
			this.grdAttachments.Name = "grdAttachments";
			this.grdAttachments.Size = new System.Drawing.Size(328, 427);
			this.grdAttachments.TabIndex = 1;
			this.grdAttachments.TabKeyBehavior = Janus.Windows.GridEX.TabKeyBehavior.ControlNavigation;
			this.grdAttachments.LinkClicked += new Janus.Windows.GridEX.ColumnActionEventHandler(this.grdAttachments_LinkClicked);
			// 
			// pnlMain
			// 
			this.pnlMain.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlMain.Location = new System.Drawing.Point(0, 0);
			this.pnlMain.Name = "pnlMain";
			// 
			// pnlMain.Panel1
			// 
			this.pnlMain.Panel1.Controls.Add(this.txtNotes);
			// 
			// pnlMain.Panel2
			// 
			this.pnlMain.Panel2.Controls.Add(this.grdAttachments);
			this.pnlMain.Size = new System.Drawing.Size(764, 427);
			this.pnlMain.SplitterDistance = 432;
			this.pnlMain.TabIndex = 0;
			// 
			// chkAddToIssues
			// 
			this.chkAddToIssues.AutoSize = true;
			this.chkAddToIssues.Location = new System.Drawing.Point(436, 436);
			this.chkAddToIssues.Name = "chkAddToIssues";
			this.chkAddToIssues.Size = new System.Drawing.Size(127, 17);
			this.chkAddToIssues.TabIndex = 2;
			this.chkAddToIssues.Text = "Add To Issue Results";
			this.chkAddToIssues.UseVisualStyleBackColor = true;
			this.chkAddToIssues.YN = "N";
			this.chkAddToIssues.CheckedChanged += new System.EventHandler(this.chkAddToIssues_CheckedChanged);
			// 
			// chkDismissIssue
			// 
			this.chkDismissIssue.AutoSize = true;
			this.chkDismissIssue.Location = new System.Drawing.Point(341, 436);
			this.chkDismissIssue.Name = "chkDismissIssue";
			this.chkDismissIssue.Size = new System.Drawing.Size(89, 17);
			this.chkDismissIssue.TabIndex = 1;
			this.chkDismissIssue.Text = "Dismiss Issue";
			this.chkDismissIssue.UseVisualStyleBackColor = true;
			this.chkDismissIssue.YN = "N";
			// 
			// frmViewIssue
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(764, 462);
			this.Controls.Add(this.chkDismissIssue);
			this.Controls.Add(this.chkAddToIssues);
			this.Controls.Add(this.pnlMain);
			this.Name = "frmViewIssue";
			this.ShowInTaskbar = false;
			this.Text = "Issue";
			this.Load += new System.EventHandler(this.frmViewIssue_Load);
			this.Controls.SetChildIndex(this.btnCancel, 0);
			this.Controls.SetChildIndex(this.btnOK, 0);
			this.Controls.SetChildIndex(this.btnApply, 0);
			this.Controls.SetChildIndex(this.pnlMain, 0);
			this.Controls.SetChildIndex(this.chkAddToIssues, 0);
			this.Controls.SetChildIndex(this.chkDismissIssue, 0);
			( (System.ComponentModel.ISupportInitialize)( this.grdAttachments ) ).EndInit();
			this.pnlMain.Panel1.ResumeLayout(false);
			this.pnlMain.Panel1.PerformLayout();
			this.pnlMain.Panel2.ResumeLayout(false);
			this.pnlMain.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private CS2010.CommonWinCtrls.ucTextBox txtNotes;
		private CS2010.CommonWinCtrls.ucGridEx grdAttachments;
		private CS2010.CommonWinCtrls.ucSplitContainer pnlMain;
		private CS2010.CommonWinCtrls.ucCheckBox chkAddToIssues;
		private CS2010.CommonWinCtrls.ucCheckBox chkDismissIssue;
	}
}