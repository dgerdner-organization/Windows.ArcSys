namespace ASL.ITrack.WinCtrls
{
	partial class frmEditIssue
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
			Janus.Windows.GridEX.GridEXLayout cmbProject_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditIssue));
			Janus.Windows.GridEX.GridEXLayout cmbCategory_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			Janus.Windows.GridEX.GridEXLayout cmbStatus_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			Janus.Windows.GridEX.GridEXLayout cmbBizOwner_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			Janus.Windows.GridEX.GridEXLayout cmbDeveloper_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			this.cmbProject = new ASL.ITrack.WinCtrls.ucProjectCombo();
			this.cmbCategory = new ASL.ITrack.WinCtrls.ucCategoryCombo();
			this.cmbStatus = new ASL.ITrack.WinCtrls.ucStatusCombo();
			this.cmbBizOwner = new ASL.ITrack.WinCtrls.ucUserCombo();
			this.txtIssueDesc = new CS2010.CommonWinCtrls.ucTextBox();
			this.dteDue = new CS2010.CommonWinCtrls.ucDateTextBox();
			this.txtNote = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtTo = new CS2010.CommonWinCtrls.ucTextBox();
			this.lblTo = new CS2010.CommonWinCtrls.ucLabel();
			this.chkEmail = new CS2010.CommonWinCtrls.ucCheckBox();
			this.pnlBottom = new CS2010.CommonWinCtrls.ucSplitContainer();
			this.dteRequest = new CS2010.CommonWinCtrls.ucDateTextBox();
			this.numPriority = new CS2010.CommonWinCtrls.ucNumericEditBox();
			this.chkRelease = new CS2010.CommonWinCtrls.ucCheckBox();
			this.chkFix = new CS2010.CommonWinCtrls.ucCheckBox();
			this.cmbDeveloper = new ASL.ITrack.WinCtrls.ucUserCombo();
			this.chkEmg = new CS2010.CommonWinCtrls.ucCheckBox();
			this.chkNewReq = new CS2010.CommonWinCtrls.ucCheckBox();
			this.chkDevAssist = new CS2010.CommonWinCtrls.ucCheckBox();
			this.chkWIP = new CS2010.CommonWinCtrls.ucCheckBox();
			((System.ComponentModel.ISupportInitialize)(this.cmbProject)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbCategory)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbStatus)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbBizOwner)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).BeginInit();
			this.pnlBottom.Panel1.SuspendLayout();
			this.pnlBottom.Panel2.SuspendLayout();
			this.pnlBottom.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.cmbDeveloper)).BeginInit();
			this.SuspendLayout();
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOK.Location = new System.Drawing.Point(550, 10);
			this.btnOK.TabIndex = 9;
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.Location = new System.Drawing.Point(550, 40);
			this.btnCancel.TabIndex = 10;
			// 
			// btnApply
			// 
			this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnApply.Location = new System.Drawing.Point(550, 70);
			this.btnApply.TabIndex = 11;
			this.btnApply.TabStop = true;
			this.btnApply.UseVisualStyleBackColor = false;
			// 
			// cmbProject
			// 
			this.cmbProject.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.cmbProject.CodeColumn = "Project_Cd";
			this.cmbProject.DescriptionColumn = "Project_Nm";
			cmbProject_DesignTimeLayout.LayoutString = resources.GetString("cmbProject_DesignTimeLayout.LayoutString");
			this.cmbProject.DesignTimeLayout = cmbProject_DesignTimeLayout;
			this.cmbProject.DisplayMember = "Project_CdProject_Nm";
			this.cmbProject.DisplayType = CS2010.CommonWinCtrls.ComboDisplay.CodePlusDescription;
			this.cmbProject.LabelText = "&Project";
			this.cmbProject.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.cmbProject.Location = new System.Drawing.Point(52, 12);
			this.cmbProject.Name = "cmbProject";
			this.cmbProject.SelectedIndex = -1;
			this.cmbProject.SelectedItem = null;
			this.cmbProject.Size = new System.Drawing.Size(480, 20);
			this.cmbProject.TabIndex = 1;
			this.cmbProject.ValueColumn = "Project_Cd";
			this.cmbProject.ValueMember = "Project_Cd";
			// 
			// cmbCategory
			// 
			this.cmbCategory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.cmbCategory.CodeColumn = "Category_Cd";
			this.cmbCategory.DescriptionColumn = "Category_Nm";
			cmbCategory_DesignTimeLayout.LayoutString = resources.GetString("cmbCategory_DesignTimeLayout.LayoutString");
			this.cmbCategory.DesignTimeLayout = cmbCategory_DesignTimeLayout;
			this.cmbCategory.DisplayMember = "Category_CdCategory_Nm";
			this.cmbCategory.DisplayType = CS2010.CommonWinCtrls.ComboDisplay.CodePlusDescription;
			this.cmbCategory.LabelText = "&Category";
			this.cmbCategory.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.cmbCategory.Location = new System.Drawing.Point(52, 96);
			this.cmbCategory.Name = "cmbCategory";
			this.cmbCategory.SelectedIndex = -1;
			this.cmbCategory.SelectedItem = null;
			this.cmbCategory.Size = new System.Drawing.Size(480, 20);
			this.cmbCategory.TabIndex = 7;
			this.cmbCategory.ValueColumn = "Category_Cd";
			this.cmbCategory.ValueMember = "Category_Cd";
			// 
			// cmbStatus
			// 
			this.cmbStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.cmbStatus.CodeColumn = "Status_Cd";
			this.cmbStatus.DescriptionColumn = "Status_Dsc";
			cmbStatus_DesignTimeLayout.LayoutString = resources.GetString("cmbStatus_DesignTimeLayout.LayoutString");
			this.cmbStatus.DesignTimeLayout = cmbStatus_DesignTimeLayout;
			this.cmbStatus.DisplayMember = "Status_CdStatus_Dsc";
			this.cmbStatus.DisplayType = CS2010.CommonWinCtrls.ComboDisplay.CodePlusDescription;
			this.cmbStatus.LabelText = "&Status";
			this.cmbStatus.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.cmbStatus.Location = new System.Drawing.Point(52, 8);
			this.cmbStatus.Name = "cmbStatus";
			this.cmbStatus.SelectedIndex = -1;
			this.cmbStatus.SelectedItem = null;
			this.cmbStatus.Size = new System.Drawing.Size(480, 20);
			this.cmbStatus.TabIndex = 1;
			this.cmbStatus.ValueColumn = "Status_Cd";
			this.cmbStatus.ValueMember = "Status_Cd";
			// 
			// cmbBizOwner
			// 
			this.cmbBizOwner.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.cmbBizOwner.CodeColumn = "User_Login";
			this.cmbBizOwner.DescriptionColumn = "User_Nm";
			cmbBizOwner_DesignTimeLayout.LayoutString = resources.GetString("cmbBizOwner_DesignTimeLayout.LayoutString");
			this.cmbBizOwner.DesignTimeLayout = cmbBizOwner_DesignTimeLayout;
			this.cmbBizOwner.DisplayMember = "User_LoginUser_Nm";
			this.cmbBizOwner.DisplayType = CS2010.CommonWinCtrls.ComboDisplay.CodePlusDescription;
			this.cmbBizOwner.LabelText = "&Owner";
			this.cmbBizOwner.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.cmbBizOwner.Location = new System.Drawing.Point(52, 40);
			this.cmbBizOwner.Name = "cmbBizOwner";
			this.cmbBizOwner.SelectedIndex = -1;
			this.cmbBizOwner.SelectedItem = null;
			this.cmbBizOwner.Size = new System.Drawing.Size(480, 20);
			this.cmbBizOwner.TabIndex = 3;
			this.cmbBizOwner.ValueColumn = "User_Login";
			this.cmbBizOwner.ValueMember = "User_Login";
			// 
			// txtIssueDesc
			// 
			this.txtIssueDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtIssueDesc.LabelText = "Title";
			this.txtIssueDesc.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtIssueDesc.LinkDisabledMessage = "Link Disabled";
			this.txtIssueDesc.Location = new System.Drawing.Point(52, 68);
			this.txtIssueDesc.Name = "txtIssueDesc";
			this.txtIssueDesc.Size = new System.Drawing.Size(480, 20);
			this.txtIssueDesc.TabIndex = 5;
			// 
			// dteDue
			// 
			this.dteDue.LabelText = "&Release";
			this.dteDue.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.dteDue.LinkDisabledMessage = "Link Disabled";
			this.dteDue.Location = new System.Drawing.Point(460, 36);
			this.dteDue.MaxLength = 10;
			this.dteDue.Name = "dteDue";
			this.dteDue.Size = new System.Drawing.Size(72, 20);
			this.dteDue.TabIndex = 9;
			this.dteDue.Value = null;
			// 
			// txtNote
			// 
			this.txtNote.AcceptsReturn = true;
			this.txtNote.AcceptsTab = true;
			this.txtNote.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtNote.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
			this.txtNote.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtNote.LabelText = "&Note";
			this.txtNote.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtNote.LinkDisabledMessage = "Link Disabled";
			this.txtNote.Location = new System.Drawing.Point(52, 8);
			this.txtNote.Multiline = true;
			this.txtNote.Name = "txtNote";
			this.txtNote.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtNote.Size = new System.Drawing.Size(480, 244);
			this.txtNote.TabIndex = 17;
			// 
			// txtTo
			// 
			this.txtTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtTo.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
			this.txtTo.LinkDisabledMessage = "Link Disabled";
			this.txtTo.Location = new System.Drawing.Point(52, 280);
			this.txtTo.Name = "txtTo";
			this.txtTo.Size = new System.Drawing.Size(480, 20);
			this.txtTo.TabIndex = 20;
			this.txtTo.Visible = false;
			// 
			// lblTo
			// 
			this.lblTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lblTo.Location = new System.Drawing.Point(18, 283);
			this.lblTo.Name = "lblTo";
			this.lblTo.Size = new System.Drawing.Size(29, 13);
			this.lblTo.TabIndex = 19;
			this.lblTo.Text = "&To...";
			this.lblTo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.lblTo.Visible = false;
			this.lblTo.Click += new System.EventHandler(this.lblTo_Click);
			this.lblTo.MouseLeave += new System.EventHandler(this.lbl_MouseLeave);
			this.lblTo.MouseHover += new System.EventHandler(this.lbl_MouseHover);
			// 
			// chkEmail
			// 
			this.chkEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.chkEmail.AutoSize = true;
			this.chkEmail.Location = new System.Drawing.Point(52, 258);
			this.chkEmail.Name = "chkEmail";
			this.chkEmail.Size = new System.Drawing.Size(79, 17);
			this.chkEmail.TabIndex = 18;
			this.chkEmail.Text = "Send &Email";
			this.chkEmail.UseVisualStyleBackColor = true;
			this.chkEmail.YN = "N";
			this.chkEmail.CheckedChanged += new System.EventHandler(this.chkEmail_CheckedChanged);
			// 
			// pnlBottom
			// 
			this.pnlBottom.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.pnlBottom.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.pnlBottom.Location = new System.Drawing.Point(0, 124);
			this.pnlBottom.Name = "pnlBottom";
			this.pnlBottom.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// pnlBottom.Panel1
			// 
			this.pnlBottom.Panel1.Controls.Add(this.dteRequest);
			this.pnlBottom.Panel1.Controls.Add(this.cmbStatus);
			this.pnlBottom.Panel1.Controls.Add(this.numPriority);
			this.pnlBottom.Panel1.Controls.Add(this.chkRelease);
			this.pnlBottom.Panel1.Controls.Add(this.chkFix);
			this.pnlBottom.Panel1.Controls.Add(this.cmbDeveloper);
			this.pnlBottom.Panel1.Controls.Add(this.chkEmg);
			this.pnlBottom.Panel1.Controls.Add(this.chkNewReq);
			this.pnlBottom.Panel1.Controls.Add(this.chkDevAssist);
			this.pnlBottom.Panel1.Controls.Add(this.dteDue);
			this.pnlBottom.Panel1.Controls.Add(this.chkWIP);
			// 
			// pnlBottom.Panel2
			// 
			this.pnlBottom.Panel2.Controls.Add(this.txtTo);
			this.pnlBottom.Panel2.Controls.Add(this.txtNote);
			this.pnlBottom.Panel2.Controls.Add(this.lblTo);
			this.pnlBottom.Panel2.Controls.Add(this.chkEmail);
			this.pnlBottom.Size = new System.Drawing.Size(543, 399);
			this.pnlBottom.SplitterDistance = 89;
			this.pnlBottom.TabIndex = 8;
			// 
			// dteRequest
			// 
			this.dteRequest.LabelText = "&Requested";
			this.dteRequest.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.dteRequest.LinkDisabledMessage = "Link Disabled";
			this.dteRequest.Location = new System.Drawing.Point(333, 36);
			this.dteRequest.MaxLength = 10;
			this.dteRequest.Name = "dteRequest";
			this.dteRequest.Size = new System.Drawing.Size(72, 20);
			this.dteRequest.TabIndex = 7;
			this.dteRequest.Value = null;
			// 
			// numPriority
			// 
			this.numPriority.AllowParentheses = Janus.Windows.GridEX.TriState.False;
			this.numPriority.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.numPriority.DecimalDigits = 0;
			this.numPriority.EditMode = Janus.Windows.GridEX.NumericEditMode.Value;
			this.numPriority.FormatString = "0";
			this.numPriority.LabelText = "Priorit&y";
			this.numPriority.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.numPriority.Location = new System.Drawing.Point(227, 36);
			this.numPriority.Name = "numPriority";
			this.numPriority.NullBehavior = Janus.Windows.GridEX.NumericEditNullBehavior.AllowNull;
			this.numPriority.Size = new System.Drawing.Size(30, 20);
			this.numPriority.TabIndex = 5;
			this.numPriority.Text = "0";
			this.numPriority.Value = ((short)(0));
			this.numPriority.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int16;
			// 
			// chkRelease
			// 
			this.chkRelease.AutoSize = true;
			this.chkRelease.Location = new System.Drawing.Point(460, 64);
			this.chkRelease.Name = "chkRelease";
			this.chkRelease.Size = new System.Drawing.Size(65, 17);
			this.chkRelease.TabIndex = 15;
			this.chkRelease.Text = "Release";
			this.chkRelease.UseVisualStyleBackColor = true;
			this.chkRelease.YN = "N";
			// 
			// chkFix
			// 
			this.chkFix.AutoSize = true;
			this.chkFix.Location = new System.Drawing.Point(389, 64);
			this.chkFix.Name = "chkFix";
			this.chkFix.Size = new System.Drawing.Size(65, 17);
			this.chkFix.TabIndex = 14;
			this.chkFix.Text = "Data Fi&x";
			this.chkFix.UseVisualStyleBackColor = true;
			this.chkFix.YN = "N";
			// 
			// cmbDeveloper
			// 
			this.cmbDeveloper.CodeColumn = "User_Login";
			this.cmbDeveloper.DescriptionColumn = "User_Nm";
			cmbDeveloper_DesignTimeLayout.LayoutString = resources.GetString("cmbDeveloper_DesignTimeLayout.LayoutString");
			this.cmbDeveloper.DesignTimeLayout = cmbDeveloper_DesignTimeLayout;
			this.cmbDeveloper.DisplayMember = "User_Login";
			this.cmbDeveloper.LabelText = "De&v";
			this.cmbDeveloper.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.cmbDeveloper.Location = new System.Drawing.Point(52, 36);
			this.cmbDeveloper.Name = "cmbDeveloper";
			this.cmbDeveloper.SelectedIndex = -1;
			this.cmbDeveloper.SelectedItem = null;
			this.cmbDeveloper.Size = new System.Drawing.Size(133, 20);
			this.cmbDeveloper.TabIndex = 3;
			this.cmbDeveloper.ValueColumn = "User_Login";
			this.cmbDeveloper.ValueMember = "User_Login";
			// 
			// chkEmg
			// 
			this.chkEmg.AutoSize = true;
			this.chkEmg.Location = new System.Drawing.Point(304, 64);
			this.chkEmg.Name = "chkEmg";
			this.chkEmg.Size = new System.Drawing.Size(79, 17);
			this.chkEmg.TabIndex = 13;
			this.chkEmg.Text = "Emer&gency";
			this.chkEmg.UseVisualStyleBackColor = true;
			this.chkEmg.YN = "N";
			// 
			// chkNewReq
			// 
			this.chkNewReq.AutoSize = true;
			this.chkNewReq.Location = new System.Drawing.Point(52, 64);
			this.chkNewReq.Name = "chkNewReq";
			this.chkNewReq.Size = new System.Drawing.Size(111, 17);
			this.chkNewReq.TabIndex = 10;
			this.chkNewReq.Text = "New Re&quirement";
			this.chkNewReq.UseVisualStyleBackColor = true;
			this.chkNewReq.YN = "N";
			// 
			// chkDevAssist
			// 
			this.chkDevAssist.AutoSize = true;
			this.chkDevAssist.Location = new System.Drawing.Point(169, 64);
			this.chkDevAssist.Name = "chkDevAssist";
			this.chkDevAssist.Size = new System.Drawing.Size(76, 17);
			this.chkDevAssist.TabIndex = 11;
			this.chkDevAssist.Text = "Dev &Assist";
			this.chkDevAssist.UseVisualStyleBackColor = true;
			this.chkDevAssist.YN = "N";
			// 
			// chkWIP
			// 
			this.chkWIP.AutoSize = true;
			this.chkWIP.Location = new System.Drawing.Point(251, 64);
			this.chkWIP.Name = "chkWIP";
			this.chkWIP.Size = new System.Drawing.Size(47, 17);
			this.chkWIP.TabIndex = 12;
			this.chkWIP.Text = "&WIP";
			this.chkWIP.UseVisualStyleBackColor = true;
			this.chkWIP.YN = "N";
			// 
			// frmEditIssue
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(644, 524);
			this.Controls.Add(this.pnlBottom);
			this.Controls.Add(this.txtIssueDesc);
			this.Controls.Add(this.cmbProject);
			this.Controls.Add(this.cmbCategory);
			this.Controls.Add(this.cmbBizOwner);
			this.Name = "frmEditIssue";
			this.Tag = "Issue";
			this.Text = "Add/Edit Issue";
			this.Load += new System.EventHandler(this.frmEditIssue_Load);
			this.Controls.SetChildIndex(this.cmbBizOwner, 0);
			this.Controls.SetChildIndex(this.btnOK, 0);
			this.Controls.SetChildIndex(this.btnCancel, 0);
			this.Controls.SetChildIndex(this.cmbCategory, 0);
			this.Controls.SetChildIndex(this.btnApply, 0);
			this.Controls.SetChildIndex(this.cmbProject, 0);
			this.Controls.SetChildIndex(this.txtIssueDesc, 0);
			this.Controls.SetChildIndex(this.pnlBottom, 0);
			((System.ComponentModel.ISupportInitialize)(this.cmbProject)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbCategory)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbStatus)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbBizOwner)).EndInit();
			this.pnlBottom.Panel1.ResumeLayout(false);
			this.pnlBottom.Panel1.PerformLayout();
			this.pnlBottom.Panel2.ResumeLayout(false);
			this.pnlBottom.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).EndInit();
			this.pnlBottom.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.cmbDeveloper)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private ASL.ITrack.WinCtrls.ucProjectCombo cmbProject;
		private ASL.ITrack.WinCtrls.ucCategoryCombo cmbCategory;
		private ASL.ITrack.WinCtrls.ucStatusCombo cmbStatus;
		private ASL.ITrack.WinCtrls.ucUserCombo cmbBizOwner;
		private CS2010.CommonWinCtrls.ucTextBox txtIssueDesc;
		private CS2010.CommonWinCtrls.ucDateTextBox dteDue;
		private CS2010.CommonWinCtrls.ucTextBox txtNote;
		private CS2010.CommonWinCtrls.ucTextBox txtTo;
		private CS2010.CommonWinCtrls.ucLabel lblTo;
		private CS2010.CommonWinCtrls.ucCheckBox chkEmail;
		private CS2010.CommonWinCtrls.ucSplitContainer pnlBottom;
		private CS2010.CommonWinCtrls.ucCheckBox chkFix;
		private CS2010.CommonWinCtrls.ucCheckBox chkEmg;
		private CS2010.CommonWinCtrls.ucCheckBox chkRelease;
		private CS2010.CommonWinCtrls.ucCheckBox chkWIP;
		private CS2010.CommonWinCtrls.ucNumericEditBox numPriority;
		private CS2010.CommonWinCtrls.ucCheckBox chkDevAssist;
		private CS2010.CommonWinCtrls.ucCheckBox chkNewReq;
		private ASL.ITrack.WinCtrls.ucUserCombo cmbDeveloper;
		private CS2010.CommonWinCtrls.ucDateTextBox dteRequest;
	}
}