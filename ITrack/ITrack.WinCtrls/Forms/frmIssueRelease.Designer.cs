namespace ASL.ITrack.WinCtrls
{
	partial class frmIssueRelease
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
			Janus.Windows.GridEX.GridEXLayout grdIssues_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIssueRelease));
			this.txtNote = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtVersion = new CS2010.CommonWinCtrls.ucTextBox();
			this.pnlMain = new CS2010.CommonWinCtrls.ucSplitContainer();
			this.grdIssues = new CS2010.CommonWinCtrls.ucGridEx();
			this.pnlMain.Panel1.SuspendLayout();
			this.pnlMain.Panel2.SuspendLayout();
			this.pnlMain.SuspendLayout();
			( (System.ComponentModel.ISupportInitialize)( this.grdIssues ) ).BeginInit();
			this.SuspendLayout();
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.btnOK.Location = new System.Drawing.Point(577, 434);
			this.btnOK.TabIndex = 1;
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.btnCancel.Location = new System.Drawing.Point(661, 434);
			this.btnCancel.TabIndex = 2;
			// 
			// btnApply
			// 
			this.btnApply.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.btnApply.Location = new System.Drawing.Point(745, 434);
			this.btnApply.TabIndex = 3;
			this.btnApply.TabStop = true;
			this.btnApply.UseVisualStyleBackColor = false;
			// 
			// txtNote
			// 
			this.txtNote.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
						| System.Windows.Forms.AnchorStyles.Left )
						| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.txtNote.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtNote.LabelText = "&Release Note";
			this.txtNote.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtNote.LinkDisabledMessage = "Link Disabled";
			this.txtNote.Location = new System.Drawing.Point(79, 42);
			this.txtNote.Multiline = true;
			this.txtNote.Name = "txtNote";
			this.txtNote.Size = new System.Drawing.Size(661, 134);
			this.txtNote.TabIndex = 3;
			// 
			// txtVersion
			// 
			this.txtVersion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtVersion.LabelText = "&Version";
			this.txtVersion.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtVersion.LinkDisabledMessage = "Link Disabled";
			this.txtVersion.Location = new System.Drawing.Point(79, 12);
			this.txtVersion.Name = "txtVersion";
			this.txtVersion.Size = new System.Drawing.Size(100, 20);
			this.txtVersion.TabIndex = 1;
			// 
			// pnlMain
			// 
			this.pnlMain.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
						| System.Windows.Forms.AnchorStyles.Left )
						| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.pnlMain.Location = new System.Drawing.Point(0, 0);
			this.pnlMain.Name = "pnlMain";
			this.pnlMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// pnlMain.Panel1
			// 
			this.pnlMain.Panel1.Controls.Add(this.grdIssues);
			// 
			// pnlMain.Panel2
			// 
			this.pnlMain.Panel2.Controls.Add(this.txtVersion);
			this.pnlMain.Panel2.Controls.Add(this.txtNote);
			this.pnlMain.Size = new System.Drawing.Size(750, 425);
			this.pnlMain.SplitterDistance = 238;
			this.pnlMain.TabIndex = 0;
			// 
			// grdIssues
			// 
			this.grdIssues.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
			this.grdIssues.AllowRemoveColumns = Janus.Windows.GridEX.InheritableBoolean.True;
			this.grdIssues.DataMember = "Issues";
			grdIssues_DesignTimeLayout.LayoutString = resources.GetString("grdIssues_DesignTimeLayout.LayoutString");
			this.grdIssues.DesignTimeLayout = grdIssues_DesignTimeLayout;
			this.grdIssues.DisplayFieldChooser = true;
			this.grdIssues.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grdIssues.ExportFileID = "Issue List";
			this.grdIssues.GroupByBoxVisible = false;
			this.grdIssues.HideColumnsWhenGrouped = Janus.Windows.GridEX.InheritableBoolean.True;
			this.grdIssues.Hierarchical = true;
			this.grdIssues.Location = new System.Drawing.Point(0, 0);
			this.grdIssues.Name = "grdIssues";
			this.grdIssues.Size = new System.Drawing.Size(750, 238);
			this.grdIssues.TabIndex = 0;
			this.grdIssues.TableHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
			this.grdIssues.UseGroupRowSelector = true;
			// 
			// frmIssueRelease
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(752, 466);
			this.Controls.Add(this.pnlMain);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
			this.Name = "frmIssueRelease";
			this.Text = "Release Issues";
			this.Load += new System.EventHandler(this.frmIssueRelease_Load);
			this.Controls.SetChildIndex(this.btnCancel, 0);
			this.Controls.SetChildIndex(this.btnOK, 0);
			this.Controls.SetChildIndex(this.btnApply, 0);
			this.Controls.SetChildIndex(this.pnlMain, 0);
			this.pnlMain.Panel1.ResumeLayout(false);
			this.pnlMain.Panel2.ResumeLayout(false);
			this.pnlMain.Panel2.PerformLayout();
			this.pnlMain.ResumeLayout(false);
			( (System.ComponentModel.ISupportInitialize)( this.grdIssues ) ).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private CS2010.CommonWinCtrls.ucTextBox txtNote;
		private CS2010.CommonWinCtrls.ucTextBox txtVersion;
		private CS2010.CommonWinCtrls.ucSplitContainer pnlMain;
		private CS2010.CommonWinCtrls.ucGridEx grdIssues;
	}
}