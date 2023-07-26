namespace ASL.ITrack.WinCtrls
{
	partial class frmIssueTrackingOptions
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
			Janus.Windows.GridEX.GridEXLayout cmbCreator_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIssueTrackingOptions));
			Janus.Windows.GridEX.GridEXLayout cmbITUser_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			Janus.Windows.GridEX.GridEXLayout cmbBizUser_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			Janus.Windows.GridEX.GridEXLayout cmbProject_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			Janus.Windows.GridEX.GridEXLayout cmbStatus_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			this.txtIssueNotes = new CS2010.CommonWinCtrls.ucTextBox();
			this.btnClear = new CS2010.CommonWinCtrls.ucButton();
			this.txtIssueTitle = new CS2010.CommonWinCtrls.ucTextBox();
			this.grpCreated = new CS2010.CommonWinCtrls.ucDateGroupBox();
			this.grpIssueRange = new CS2010.CommonWinCtrls.ucGroupBox();
			this.numToIssue = new CS2010.CommonWinCtrls.ucNumericEditBox();
			this.numFromIssue = new CS2010.CommonWinCtrls.ucNumericEditBox();
			this.chkIssueRange = new CS2010.CommonWinCtrls.ucCheckBox();
			this.grpModified = new CS2010.CommonWinCtrls.ucDateGroupBox();
			this.txtMultipleIssues = new CS2010.CommonWinCtrls.ucTextBox();
			this.grpLastAttachDt = new CS2010.CommonWinCtrls.ucDateGroupBox();
			this.grpLastNoteDt = new CS2010.CommonWinCtrls.ucDateGroupBox();
			this.cmbCreator = new ASL.ITrack.WinCtrls.ucUserCheckboxCombo();
			this.cmbITUser = new ASL.ITrack.WinCtrls.ucUserCheckboxCombo();
			this.cmbBizUser = new ASL.ITrack.WinCtrls.ucUserCheckboxCombo();
			this.cmbProject = new ASL.ITrack.WinCtrls.ucProjectCheckboxCombo();
			this.cmbStatus = new ASL.ITrack.WinCtrls.ucStatusCheckboxCombo();
			this.chkIncludeClosed = new CS2010.CommonWinCtrls.ucCheckBox();
			this.chkIncludeHold = new CS2010.CommonWinCtrls.ucCheckBox();
			this.grpIssueRange.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOK.Location = new System.Drawing.Point(595, 10);
			this.btnOK.TabIndex = 50;
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.Location = new System.Drawing.Point(595, 70);
			this.btnCancel.TabIndex = 52;
			// 
			// btnApply
			// 
			this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnApply.Location = new System.Drawing.Point(595, 100);
			this.btnApply.TabIndex = 53;
			this.btnApply.TabStop = true;
			this.btnApply.UseVisualStyleBackColor = false;
			// 
			// txtIssueNotes
			// 
			this.txtIssueNotes.LabelText = "Issue &Notes";
			this.txtIssueNotes.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtIssueNotes.LinkDisabledMessage = "Link Disabled";
			this.txtIssueNotes.Location = new System.Drawing.Point(92, 246);
			this.txtIssueNotes.Name = "txtIssueNotes";
			this.txtIssueNotes.Size = new System.Drawing.Size(357, 20);
			this.txtIssueNotes.TabIndex = 19;
			// 
			// btnClear
			// 
			this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnClear.CausesValidation = false;
			this.btnClear.Location = new System.Drawing.Point(595, 40);
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new System.Drawing.Size(75, 23);
			this.btnClear.TabIndex = 51;
			this.btnClear.Text = "Clear";
			this.btnClear.UseVisualStyleBackColor = true;
			this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
			// 
			// txtIssueTitle
			// 
			this.txtIssueTitle.LabelText = "Issue Title";
			this.txtIssueTitle.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtIssueTitle.LinkDisabledMessage = "Link Disabled";
			this.txtIssueTitle.Location = new System.Drawing.Point(92, 216);
			this.txtIssueTitle.Name = "txtIssueTitle";
			this.txtIssueTitle.Size = new System.Drawing.Size(357, 20);
			this.txtIssueTitle.TabIndex = 17;
			// 
			// grpCreated
			// 
			this.grpCreated.CheckBoxText = "Issue Cr&eated";
			this.grpCreated.Location = new System.Drawing.Point(91, 272);
			this.grpCreated.Name = "grpCreated";
			this.grpCreated.Size = new System.Drawing.Size(115, 76);
			this.grpCreated.TabIndex = 20;
			// 
			// grpIssueRange
			// 
			this.grpIssueRange.Controls.Add(this.numToIssue);
			this.grpIssueRange.Controls.Add(this.numFromIssue);
			this.grpIssueRange.Controls.Add(this.chkIssueRange);
			this.grpIssueRange.Location = new System.Drawing.Point(334, 272);
			this.grpIssueRange.Name = "grpIssueRange";
			this.grpIssueRange.Size = new System.Drawing.Size(115, 76);
			this.grpIssueRange.TabIndex = 22;
			this.grpIssueRange.TabStop = false;
			// 
			// numToIssue
			// 
			this.numToIssue.AllowParentheses = Janus.Windows.GridEX.TriState.False;
			this.numToIssue.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.numToIssue.DecimalDigits = 0;
			this.numToIssue.Enabled = false;
			this.numToIssue.ForeColor = System.Drawing.Color.Black;
			this.numToIssue.FormatString = "#";
			this.numToIssue.LabelText = "To";
			this.numToIssue.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.numToIssue.Location = new System.Drawing.Point(40, 48);
			this.numToIssue.Name = "numToIssue";
			this.numToIssue.NullBehavior = Janus.Windows.GridEX.NumericEditNullBehavior.AllowNull;
			this.numToIssue.Size = new System.Drawing.Size(69, 20);
			this.numToIssue.TabIndex = 4;
			this.numToIssue.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near;
			this.numToIssue.Value = ((long)(0));
			this.numToIssue.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int64;
			// 
			// numFromIssue
			// 
			this.numFromIssue.AllowParentheses = Janus.Windows.GridEX.TriState.False;
			this.numFromIssue.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.numFromIssue.DecimalDigits = 0;
			this.numFromIssue.Enabled = false;
			this.numFromIssue.ForeColor = System.Drawing.Color.Black;
			this.numFromIssue.FormatString = "#";
			this.numFromIssue.LabelText = "From";
			this.numFromIssue.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.numFromIssue.Location = new System.Drawing.Point(40, 22);
			this.numFromIssue.Name = "numFromIssue";
			this.numFromIssue.NullBehavior = Janus.Windows.GridEX.NumericEditNullBehavior.AllowNull;
			this.numFromIssue.Size = new System.Drawing.Size(69, 20);
			this.numFromIssue.TabIndex = 2;
			this.numFromIssue.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near;
			this.numFromIssue.Value = ((long)(0));
			this.numFromIssue.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int64;
			// 
			// chkIssueRange
			// 
			this.chkIssueRange.AutoSize = true;
			this.chkIssueRange.Location = new System.Drawing.Point(7, -1);
			this.chkIssueRange.Name = "chkIssueRange";
			this.chkIssueRange.Size = new System.Drawing.Size(86, 17);
			this.chkIssueRange.TabIndex = 0;
			this.chkIssueRange.Text = "Issue &Range";
			this.chkIssueRange.UseVisualStyleBackColor = true;
			this.chkIssueRange.YN = "N";
			this.chkIssueRange.CheckedChanged += new System.EventHandler(this.chkIssueRange_CheckedChanged);
			// 
			// grpModified
			// 
			this.grpModified.CheckBoxText = "Issue &Modified";
			this.grpModified.Location = new System.Drawing.Point(212, 272);
			this.grpModified.Name = "grpModified";
			this.grpModified.Size = new System.Drawing.Size(115, 76);
			this.grpModified.TabIndex = 21;
			// 
			// txtMultipleIssues
			// 
			this.txtMultipleIssues.LabelText = "Issue #";
			this.txtMultipleIssues.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtMultipleIssues.LinkDisabledMessage = "Link Disabled";
			this.txtMultipleIssues.Location = new System.Drawing.Point(92, 12);
			this.txtMultipleIssues.Name = "txtMultipleIssues";
			this.txtMultipleIssues.Size = new System.Drawing.Size(357, 20);
			this.txtMultipleIssues.TabIndex = 1;
			this.txtMultipleIssues.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMultipleIssues_KeyPress);
			// 
			// grpLastAttachDt
			// 
			this.grpLastAttachDt.CheckBoxText = "Last Attachment";
			this.grpLastAttachDt.Location = new System.Drawing.Point(466, 11);
			this.grpLastAttachDt.Name = "grpLastAttachDt";
			this.grpLastAttachDt.Size = new System.Drawing.Size(115, 76);
			this.grpLastAttachDt.TabIndex = 23;
			// 
			// grpLastNoteDt
			// 
			this.grpLastNoteDt.CheckBoxText = "Last Note";
			this.grpLastNoteDt.Location = new System.Drawing.Point(466, 93);
			this.grpLastNoteDt.Name = "grpLastNoteDt";
			this.grpLastNoteDt.Size = new System.Drawing.Size(115, 76);
			this.grpLastNoteDt.TabIndex = 24;
			// 
			// cmbCreator
			// 
			this.cmbCreator.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.cmbCreator.CodeColumn = "User_Login";
			this.cmbCreator.DescriptionColumn = "User_Nm";
			cmbCreator_DesignTimeLayout.LayoutString = resources.GetString("cmbCreator_DesignTimeLayout.LayoutString");
			this.cmbCreator.DesignTimeLayout = cmbCreator_DesignTimeLayout;
			this.cmbCreator.DropDownDisplayMember = "User_Login";
			this.cmbCreator.DropDownValueMember = "User_Login";
			this.cmbCreator.Filter = "USER_LOGIN <> \'ITRACK_OWNER\'";
			this.cmbCreator.LabelText = "Created &by";
			this.cmbCreator.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.cmbCreator.Location = new System.Drawing.Point(92, 186);
			this.cmbCreator.Name = "cmbCreator";
			this.cmbCreator.SaveSettings = false;
			this.cmbCreator.Size = new System.Drawing.Size(357, 20);
			this.cmbCreator.TabIndex = 15;
			this.cmbCreator.ValueColumn = "User_Login";
			this.cmbCreator.ValuesDataMember = null;
			// 
			// cmbITUser
			// 
			this.cmbITUser.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.cmbITUser.CodeColumn = "User_Login";
			this.cmbITUser.DescriptionColumn = "User_Nm";
			cmbITUser_DesignTimeLayout.LayoutString = resources.GetString("cmbITUser_DesignTimeLayout.LayoutString");
			this.cmbITUser.DesignTimeLayout = cmbITUser_DesignTimeLayout;
			this.cmbITUser.DropDownDisplayMember = "User_Login";
			this.cmbITUser.DropDownValueMember = "User_Login";
			this.cmbITUser.LabelText = "De&veloper";
			this.cmbITUser.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.cmbITUser.Location = new System.Drawing.Point(92, 156);
			this.cmbITUser.Name = "cmbITUser";
			this.cmbITUser.SaveSettings = false;
			this.cmbITUser.Size = new System.Drawing.Size(357, 20);
			this.cmbITUser.TabIndex = 13;
			this.cmbITUser.ValueColumn = "User_Login";
			this.cmbITUser.ValuesDataMember = null;
			// 
			// cmbBizUser
			// 
			this.cmbBizUser.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.cmbBizUser.CodeColumn = "User_Login";
			this.cmbBizUser.DescriptionColumn = "User_Nm";
			cmbBizUser_DesignTimeLayout.LayoutString = resources.GetString("cmbBizUser_DesignTimeLayout.LayoutString");
			this.cmbBizUser.DesignTimeLayout = cmbBizUser_DesignTimeLayout;
			this.cmbBizUser.DropDownDisplayMember = "User_Login";
			this.cmbBizUser.DropDownValueMember = "User_Login";
			this.cmbBizUser.LabelText = "Business &Owner";
			this.cmbBizUser.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.cmbBizUser.Location = new System.Drawing.Point(92, 126);
			this.cmbBizUser.Name = "cmbBizUser";
			this.cmbBizUser.SaveSettings = false;
			this.cmbBizUser.Size = new System.Drawing.Size(357, 20);
			this.cmbBizUser.TabIndex = 11;
			this.cmbBizUser.ValueColumn = "User_Login";
			this.cmbBizUser.ValuesDataMember = null;
			// 
			// cmbProject
			// 
			this.cmbProject.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.cmbProject.CodeColumn = "Project_Cd";
			this.cmbProject.DescriptionColumn = "Project_Nm";
			cmbProject_DesignTimeLayout.LayoutString = resources.GetString("cmbProject_DesignTimeLayout.LayoutString");
			this.cmbProject.DesignTimeLayout = cmbProject_DesignTimeLayout;
			this.cmbProject.DropDownDisplayMember = "Project_Cd";
			this.cmbProject.DropDownValueMember = "Project_Cd";
			this.cmbProject.LabelText = "&Project";
			this.cmbProject.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.cmbProject.Location = new System.Drawing.Point(92, 42);
			this.cmbProject.Name = "cmbProject";
			this.cmbProject.SaveSettings = false;
			this.cmbProject.Size = new System.Drawing.Size(357, 20);
			this.cmbProject.TabIndex = 3;
			this.cmbProject.ValueColumn = "Project_Cd";
			this.cmbProject.ValuesDataMember = null;
			// 
			// cmbStatus
			// 
			this.cmbStatus.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.cmbStatus.CodeColumn = "Status_Cd";
			this.cmbStatus.DescriptionColumn = "Status_Nm";
			cmbStatus_DesignTimeLayout.LayoutString = resources.GetString("cmbStatus_DesignTimeLayout.LayoutString");
			this.cmbStatus.DesignTimeLayout = cmbStatus_DesignTimeLayout;
			this.cmbStatus.DropDownDisplayMember = "Status_Cd";
			this.cmbStatus.DropDownValueMember = "Status_Cd";
			this.cmbStatus.LabelText = "&Status";
			this.cmbStatus.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.cmbStatus.Location = new System.Drawing.Point(92, 72);
			this.cmbStatus.Name = "cmbStatus";
			this.cmbStatus.SaveSettings = false;
			this.cmbStatus.Size = new System.Drawing.Size(357, 20);
			this.cmbStatus.TabIndex = 5;
			this.cmbStatus.ValueColumn = "Status_Cd";
			this.cmbStatus.ValuesDataMember = null;
			this.cmbStatus.Validated += new System.EventHandler(this.cmbStatus_Validated);
			// 
			// chkIncludeClosed
			// 
			this.chkIncludeClosed.AutoSize = true;
			this.chkIncludeClosed.Location = new System.Drawing.Point(110, 100);
			this.chkIncludeClosed.Name = "chkIncludeClosed";
			this.chkIncludeClosed.Size = new System.Drawing.Size(96, 17);
			this.chkIncludeClosed.TabIndex = 6;
			this.chkIncludeClosed.Text = "Include Closed";
			this.chkIncludeClosed.UseVisualStyleBackColor = true;
			this.chkIncludeClosed.YN = "N";
			this.chkIncludeClosed.CheckedChanged += new System.EventHandler(this.chkIncludeClosed_CheckedChanged);
			// 
			// chkIncludeHold
			// 
			this.chkIncludeHold.AutoSize = true;
			this.chkIncludeHold.Location = new System.Drawing.Point(210, 100);
			this.chkIncludeHold.Name = "chkIncludeHold";
			this.chkIncludeHold.Size = new System.Drawing.Size(103, 17);
			this.chkIncludeHold.TabIndex = 7;
			this.chkIncludeHold.Text = "Include On Hold";
			this.chkIncludeHold.UseVisualStyleBackColor = true;
			this.chkIncludeHold.YN = "N";
			this.chkIncludeHold.CheckedChanged += new System.EventHandler(this.chkIncludeHold_CheckedChanged);
			// 
			// frmIssueTrackingOptions
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(682, 357);
			this.Controls.Add(this.chkIncludeHold);
			this.Controls.Add(this.txtMultipleIssues);
			this.Controls.Add(this.cmbCreator);
			this.Controls.Add(this.cmbITUser);
			this.Controls.Add(this.cmbProject);
			this.Controls.Add(this.txtIssueTitle);
			this.Controls.Add(this.cmbBizUser);
			this.Controls.Add(this.cmbStatus);
			this.Controls.Add(this.txtIssueNotes);
			this.Controls.Add(this.chkIncludeClosed);
			this.Controls.Add(this.grpModified);
			this.Controls.Add(this.btnClear);
			this.Controls.Add(this.grpCreated);
			this.Controls.Add(this.grpIssueRange);
			this.Controls.Add(this.grpLastAttachDt);
			this.Controls.Add(this.grpLastNoteDt);
			this.KeyPreview = true;
			this.Name = "frmIssueTrackingOptions";
			this.Text = "Search Options";
			this.Load += new System.EventHandler(this.frmIssueTrackingOptions_Load);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmIssueTrackingOptions_KeyDown);
			this.Controls.SetChildIndex(this.grpLastNoteDt, 0);
			this.Controls.SetChildIndex(this.grpLastAttachDt, 0);
			this.Controls.SetChildIndex(this.grpIssueRange, 0);
			this.Controls.SetChildIndex(this.grpCreated, 0);
			this.Controls.SetChildIndex(this.btnClear, 0);
			this.Controls.SetChildIndex(this.grpModified, 0);
			this.Controls.SetChildIndex(this.chkIncludeClosed, 0);
			this.Controls.SetChildIndex(this.txtIssueNotes, 0);
			this.Controls.SetChildIndex(this.cmbStatus, 0);
			this.Controls.SetChildIndex(this.cmbBizUser, 0);
			this.Controls.SetChildIndex(this.txtIssueTitle, 0);
			this.Controls.SetChildIndex(this.cmbProject, 0);
			this.Controls.SetChildIndex(this.cmbITUser, 0);
			this.Controls.SetChildIndex(this.btnApply, 0);
			this.Controls.SetChildIndex(this.btnCancel, 0);
			this.Controls.SetChildIndex(this.cmbCreator, 0);
			this.Controls.SetChildIndex(this.txtMultipleIssues, 0);
			this.Controls.SetChildIndex(this.btnOK, 0);
			this.Controls.SetChildIndex(this.chkIncludeHold, 0);
			this.grpIssueRange.ResumeLayout(false);
			this.grpIssueRange.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private ASL.ITrack.WinCtrls.ucProjectCheckboxCombo cmbProject;
		private ASL.ITrack.WinCtrls.ucStatusCheckboxCombo cmbStatus;
		private ASL.ITrack.WinCtrls.ucUserCheckboxCombo cmbBizUser;
		private CS2010.CommonWinCtrls.ucTextBox txtIssueNotes;
		private CS2010.CommonWinCtrls.ucButton btnClear;
		private CS2010.CommonWinCtrls.ucTextBox txtIssueTitle;
		private ASL.ITrack.WinCtrls.ucUserCheckboxCombo cmbITUser;
		private CS2010.CommonWinCtrls.ucDateGroupBox grpCreated;
		private ASL.ITrack.WinCtrls.ucUserCheckboxCombo cmbCreator;
		private CS2010.CommonWinCtrls.ucGroupBox grpIssueRange;
		private CS2010.CommonWinCtrls.ucNumericEditBox numToIssue;
		private CS2010.CommonWinCtrls.ucNumericEditBox numFromIssue;
		private CS2010.CommonWinCtrls.ucCheckBox chkIssueRange;
		private CS2010.CommonWinCtrls.ucDateGroupBox grpModified;
		private CS2010.CommonWinCtrls.ucTextBox txtMultipleIssues;
		private CS2010.CommonWinCtrls.ucDateGroupBox grpLastAttachDt;
		private CS2010.CommonWinCtrls.ucDateGroupBox grpLastNoteDt;
		private CS2010.CommonWinCtrls.ucCheckBox chkIncludeClosed;
		private CS2010.CommonWinCtrls.ucCheckBox chkIncludeHold;
	}
}