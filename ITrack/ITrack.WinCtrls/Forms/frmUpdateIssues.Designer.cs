namespace ASL.ITrack.WinCtrls
{
	partial class frmUpdateIssues
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUpdateIssues));
			Janus.Windows.GridEX.GridEXLayout cmbStatus_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			Janus.Windows.GridEX.GridEXLayout cmbProject_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			this.txtNote = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtVersion = new CS2010.CommonWinCtrls.ucTextBox();
			this.pnlMain = new CS2010.CommonWinCtrls.ucSplitContainer();
			this.grdIssues = new CS2010.CommonWinCtrls.ucGridEx();
			this.cmbStatus = new ASL.ITrack.WinCtrls.ucStatusCombo();
			this.cmbProject = new ASL.ITrack.WinCtrls.ucProjectCombo();
			this.lblNote = new CS2010.CommonWinCtrls.ucLabel();
			this.pnlMain.Panel1.SuspendLayout();
			this.pnlMain.Panel2.SuspendLayout();
			this.pnlMain.SuspendLayout();
			( (System.ComponentModel.ISupportInitialize)( this.grdIssues ) ).BeginInit();
			( (System.ComponentModel.ISupportInitialize)( this.cmbStatus ) ).BeginInit();
			( (System.ComponentModel.ISupportInitialize)( this.cmbProject ) ).BeginInit();
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
			this.txtNote.LinkDisabledMessage = "Link Disabled";
			this.txtNote.Location = new System.Drawing.Point(64, 42);
			this.txtNote.Multiline = true;
			this.txtNote.Name = "txtNote";
			this.txtNote.Size = new System.Drawing.Size(676, 134);
			this.txtNote.TabIndex = 7;
			// 
			// txtVersion
			// 
			this.txtVersion.LabelText = "&Version";
			this.txtVersion.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtVersion.LinkDisabledMessage = "Link Disabled";
			this.txtVersion.Location = new System.Drawing.Point(64, 12);
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
			this.pnlMain.Panel2.Controls.Add(this.lblNote);
			this.pnlMain.Panel2.Controls.Add(this.cmbStatus);
			this.pnlMain.Panel2.Controls.Add(this.cmbProject);
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
			// cmbStatus
			// 
			this.cmbStatus.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.cmbStatus.CodeColumn = "Status_Cd";
			this.cmbStatus.DescriptionColumn = "Status_Dsc";
			cmbStatus_DesignTimeLayout.LayoutString = resources.GetString("cmbStatus_DesignTimeLayout.LayoutString");
			this.cmbStatus.DesignTimeLayout = cmbStatus_DesignTimeLayout;
			this.cmbStatus.DisplayMember = "Status_CdStatus_Dsc";
			this.cmbStatus.DisplayType = CS2010.CommonWinCtrls.ComboDisplay.CodePlusDescription;
			this.cmbStatus.LabelText = "&Status";
			this.cmbStatus.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.cmbStatus.Location = new System.Drawing.Point(492, 12);
			this.cmbStatus.Name = "cmbStatus";
			this.cmbStatus.SelectedIndex = -1;
			this.cmbStatus.SelectedItem = null;
			this.cmbStatus.Size = new System.Drawing.Size(220, 20);
			this.cmbStatus.TabIndex = 5;
			this.cmbStatus.ValueColumn = "Status_Cd";
			this.cmbStatus.ValueMember = "Status_Cd";
			// 
			// cmbProject
			// 
			this.cmbProject.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.cmbProject.CodeColumn = "Project_Cd";
			this.cmbProject.DescriptionColumn = "Project_Nm";
			cmbProject_DesignTimeLayout.LayoutString = resources.GetString("cmbProject_DesignTimeLayout.LayoutString");
			this.cmbProject.DesignTimeLayout = cmbProject_DesignTimeLayout;
			this.cmbProject.DisplayMember = "Project_CdProject_Nm";
			this.cmbProject.DisplayType = CS2010.CommonWinCtrls.ComboDisplay.CodePlusDescription;
			this.cmbProject.LabelText = "&Project";
			this.cmbProject.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.cmbProject.Location = new System.Drawing.Point(216, 12);
			this.cmbProject.Name = "cmbProject";
			this.cmbProject.SelectedIndex = -1;
			this.cmbProject.SelectedItem = null;
			this.cmbProject.Size = new System.Drawing.Size(220, 20);
			this.cmbProject.TabIndex = 3;
			this.cmbProject.ValueColumn = "Project_Cd";
			this.cmbProject.ValueMember = "Project_Cd";
			// 
			// lblNote
			// 
			this.lblNote.AutoSize = true;
			this.lblNote.Location = new System.Drawing.Point(8, 45);
			this.lblNote.Name = "lblNote";
			this.lblNote.Size = new System.Drawing.Size(52, 26);
			this.lblNote.TabIndex = 6;
			this.lblNote.Text = "&Note\r\n(Optional)";
			this.lblNote.TextAlign = System.Drawing.ContentAlignment.TopRight;
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
			( (System.ComponentModel.ISupportInitialize)( this.cmbStatus ) ).EndInit();
			( (System.ComponentModel.ISupportInitialize)( this.cmbProject ) ).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private CS2010.CommonWinCtrls.ucTextBox txtNote;
		private CS2010.CommonWinCtrls.ucTextBox txtVersion;
		private CS2010.CommonWinCtrls.ucSplitContainer pnlMain;
		private CS2010.CommonWinCtrls.ucGridEx grdIssues;
		private ASL.ITrack.WinCtrls.ucStatusCombo cmbStatus;
		private ASL.ITrack.WinCtrls.ucProjectCombo cmbProject;
		private CS2010.CommonWinCtrls.ucLabel lblNote;
	}
}