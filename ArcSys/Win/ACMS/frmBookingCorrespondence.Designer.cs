namespace CS2010.ArcSys.Win
{
	partial class frmBookingCorrespondence
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
			Janus.Windows.GridEX.GridEXLayout cmbType_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBookingCorrespondence));
			Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
			Janus.Windows.GridEX.GridEXLayout cmbEmailList_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			Janus.Windows.GridEX.GridEXLayout grdEmails_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			this.txtCorrDate = new CS2010.CommonWinCtrls.ucTextBox();
			this.cmbType = new CS2010.CommonWinCtrls.ucMultiColumnCombo();
			this.txtEdit = new Infragistics.Win.FormattedLinkLabel.UltraFormattedTextEditor();
			this.splitMain = new CS2010.CommonWinCtrls.ucSplitContainer();
			this.splitSub = new CS2010.CommonWinCtrls.ucSplitContainer();
			this.txtUser = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtEmailFrom = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtTo = new CS2010.CommonWinCtrls.ucTextBox();
			this.ucPanel1 = new CS2010.CommonWinCtrls.ucPanel();
			this.cmbEmailList = new CS2010.CommonWinCtrls.ucMultiColumnCombo();
			this.grdEmails = new CS2010.CommonWinCtrls.ucGridEx();
			((System.ComponentModel.ISupportInitialize)(this.cmbType)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.splitMain)).BeginInit();
			this.splitMain.Panel1.SuspendLayout();
			this.splitMain.Panel2.SuspendLayout();
			this.splitMain.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitSub)).BeginInit();
			this.splitSub.Panel1.SuspendLayout();
			this.splitSub.Panel2.SuspendLayout();
			this.splitSub.SuspendLayout();
			this.ucPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.cmbEmailList)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grdEmails)).BeginInit();
			this.SuspendLayout();
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOK.Location = new System.Drawing.Point(433, 515);
			this.btnOK.Text = "Save";
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.Location = new System.Drawing.Point(514, 515);
			// 
			// btnApply
			// 
			this.btnApply.Location = new System.Drawing.Point(462, 563);
			this.btnApply.TabStop = true;
			this.btnApply.Text = "Accept";
			this.btnApply.UseVisualStyleBackColor = false;
			// 
			// txtCorrDate
			// 
			this.txtCorrDate.BackColor = System.Drawing.SystemColors.Control;
			this.txtCorrDate.ForeColor = System.Drawing.Color.Black;
			this.txtCorrDate.LabelText = "Date";
			this.txtCorrDate.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtCorrDate.LinkDisabledMessage = "Link Disabled";
			this.txtCorrDate.Location = new System.Drawing.Point(42, 14);
			this.txtCorrDate.Name = "txtCorrDate";
			this.txtCorrDate.ReadOnly = true;
			this.txtCorrDate.Size = new System.Drawing.Size(100, 20);
			this.txtCorrDate.TabIndex = 3;
			this.txtCorrDate.TabStop = false;
			// 
			// cmbType
			// 
			cmbType_DesignTimeLayout.LayoutString = resources.GetString("cmbType_DesignTimeLayout.LayoutString");
			this.cmbType.DesignTimeLayout = cmbType_DesignTimeLayout;
			this.cmbType.DisplayMember = "corr_dsc";
			this.cmbType.LabelText = "Type";
			this.cmbType.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.cmbType.Location = new System.Drawing.Point(42, 65);
			this.cmbType.Name = "cmbType";
			this.cmbType.SelectedIndex = -1;
			this.cmbType.SelectedItem = null;
			this.cmbType.Size = new System.Drawing.Size(185, 20);
			this.cmbType.TabIndex = 6;
			this.cmbType.ValueMember = "corr_cd";
			this.cmbType.ValueChanged += new System.EventHandler(this.cmbType_ValueChanged);
			// 
			// txtEdit
			// 
			appearance1.FontData.BoldAsString = "False";
			appearance1.FontData.ItalicAsString = "False";
			appearance1.FontData.Name = "Microsoft Sans Serif";
			appearance1.FontData.SizeInPoints = 8.25F;
			appearance1.FontData.StrikeoutAsString = "False";
			appearance1.FontData.UnderlineAsString = "False";
			this.txtEdit.Appearance = appearance1;
			this.txtEdit.ContextMenuItems = ((Infragistics.Win.FormattedLinkLabel.FormattedTextMenuItems)((((((((((((((((((Infragistics.Win.FormattedLinkLabel.FormattedTextMenuItems.Cut | Infragistics.Win.FormattedLinkLabel.FormattedTextMenuItems.Copy)
						| Infragistics.Win.FormattedLinkLabel.FormattedTextMenuItems.Paste)
						| Infragistics.Win.FormattedLinkLabel.FormattedTextMenuItems.Delete)
						| Infragistics.Win.FormattedLinkLabel.FormattedTextMenuItems.Undo)
						| Infragistics.Win.FormattedLinkLabel.FormattedTextMenuItems.Redo)
						| Infragistics.Win.FormattedLinkLabel.FormattedTextMenuItems.SelectAll)
						| Infragistics.Win.FormattedLinkLabel.FormattedTextMenuItems.Font)
						| Infragistics.Win.FormattedLinkLabel.FormattedTextMenuItems.Image)
						| Infragistics.Win.FormattedLinkLabel.FormattedTextMenuItems.Link)
						| Infragistics.Win.FormattedLinkLabel.FormattedTextMenuItems.LineAlignment)
						| Infragistics.Win.FormattedLinkLabel.FormattedTextMenuItems.Paragraph)
						| Infragistics.Win.FormattedLinkLabel.FormattedTextMenuItems.Bold)
						| Infragistics.Win.FormattedLinkLabel.FormattedTextMenuItems.Italics)
						| Infragistics.Win.FormattedLinkLabel.FormattedTextMenuItems.Underline)
						| Infragistics.Win.FormattedLinkLabel.FormattedTextMenuItems.SpellingSuggestions)
						| Infragistics.Win.FormattedLinkLabel.FormattedTextMenuItems.Strikeout)
						| Infragistics.Win.FormattedLinkLabel.FormattedTextMenuItems.Reserved)));
			this.txtEdit.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtEdit.Location = new System.Drawing.Point(0, 0);
			this.txtEdit.Name = "txtEdit";
			this.txtEdit.Size = new System.Drawing.Size(532, 397);
			this.txtEdit.TabIndex = 8;
			this.txtEdit.Value = "";
			// 
			// splitMain
			// 
			this.splitMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.splitMain.Location = new System.Drawing.Point(3, 3);
			this.splitMain.Name = "splitMain";
			// 
			// splitMain.Panel1
			// 
			this.splitMain.Panel1.Controls.Add(this.splitSub);
			// 
			// splitMain.Panel2
			// 
			this.splitMain.Panel2.Controls.Add(this.ucPanel1);
			this.splitMain.Panel2.Controls.Add(this.grdEmails);
			this.splitMain.Size = new System.Drawing.Size(870, 497);
			this.splitMain.SplitterDistance = 532;
			this.splitMain.TabIndex = 9;
			// 
			// splitSub
			// 
			this.splitSub.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitSub.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.splitSub.Location = new System.Drawing.Point(0, 0);
			this.splitSub.Name = "splitSub";
			this.splitSub.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitSub.Panel1
			// 
			this.splitSub.Panel1.Controls.Add(this.txtUser);
			this.splitSub.Panel1.Controls.Add(this.txtEmailFrom);
			this.splitSub.Panel1.Controls.Add(this.txtTo);
			this.splitSub.Panel1.Controls.Add(this.txtCorrDate);
			this.splitSub.Panel1.Controls.Add(this.cmbType);
			// 
			// splitSub.Panel2
			// 
			this.splitSub.Panel2.Controls.Add(this.txtEdit);
			this.splitSub.Size = new System.Drawing.Size(532, 497);
			this.splitSub.SplitterDistance = 96;
			this.splitSub.TabIndex = 7;
			// 
			// txtUser
			// 
			this.txtUser.BackColor = System.Drawing.SystemColors.Control;
			this.txtUser.ForeColor = System.Drawing.Color.Black;
			this.txtUser.LabelText = "User";
			this.txtUser.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtUser.LinkDisabledMessage = "Link Disabled";
			this.txtUser.Location = new System.Drawing.Point(42, 39);
			this.txtUser.Name = "txtUser";
			this.txtUser.ReadOnly = true;
			this.txtUser.Size = new System.Drawing.Size(100, 20);
			this.txtUser.TabIndex = 9;
			this.txtUser.TabStop = false;
			// 
			// txtEmailFrom
			// 
			this.txtEmailFrom.BackColor = System.Drawing.SystemColors.Control;
			this.txtEmailFrom.ForeColor = System.Drawing.Color.Black;
			this.txtEmailFrom.LabelText = "From:";
			this.txtEmailFrom.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtEmailFrom.LinkDisabledMessage = "Link Disabled";
			this.txtEmailFrom.Location = new System.Drawing.Point(233, 13);
			this.txtEmailFrom.Name = "txtEmailFrom";
			this.txtEmailFrom.ReadOnly = true;
			this.txtEmailFrom.Size = new System.Drawing.Size(291, 20);
			this.txtEmailFrom.TabIndex = 8;
			this.txtEmailFrom.TabStop = false;
			// 
			// txtTo
			// 
			this.txtTo.BackColor = System.Drawing.SystemColors.Control;
			this.txtTo.ForeColor = System.Drawing.Color.Black;
			this.txtTo.LabelText = "To:";
			this.txtTo.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtTo.LinkDisabledMessage = "Link Disabled";
			this.txtTo.Location = new System.Drawing.Point(233, 41);
			this.txtTo.Multiline = true;
			this.txtTo.Name = "txtTo";
			this.txtTo.ReadOnly = true;
			this.txtTo.Size = new System.Drawing.Size(291, 46);
			this.txtTo.TabIndex = 7;
			this.txtTo.TabStop = false;
			// 
			// ucPanel1
			// 
			this.ucPanel1.Controls.Add(this.cmbEmailList);
			this.ucPanel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.ucPanel1.Location = new System.Drawing.Point(0, 0);
			this.ucPanel1.Name = "ucPanel1";
			this.ucPanel1.Size = new System.Drawing.Size(334, 47);
			this.ucPanel1.TabIndex = 8;
			// 
			// cmbEmailList
			// 
			cmbEmailList_DesignTimeLayout.LayoutString = resources.GetString("cmbEmailList_DesignTimeLayout.LayoutString");
			this.cmbEmailList.DesignTimeLayout = cmbEmailList_DesignTimeLayout;
			this.cmbEmailList.DisplayMember = "list_dsc";
			this.cmbEmailList.LabelText = "Distribution";
			this.cmbEmailList.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.cmbEmailList.Location = new System.Drawing.Point(74, 14);
			this.cmbEmailList.Name = "cmbEmailList";
			this.cmbEmailList.SelectedIndex = -1;
			this.cmbEmailList.SelectedItem = null;
			this.cmbEmailList.Size = new System.Drawing.Size(177, 20);
			this.cmbEmailList.TabIndex = 7;
			this.cmbEmailList.ValueMember = "email_list_cd";
			this.cmbEmailList.TextChanged += new System.EventHandler(this.cmbEmailList_TextChanged);
			// 
			// grdEmails
			// 
			grdEmails_DesignTimeLayout.LayoutString = resources.GetString("grdEmails_DesignTimeLayout.LayoutString");
			this.grdEmails.DesignTimeLayout = grdEmails_DesignTimeLayout;
			this.grdEmails.ExportFileID = null;
			this.grdEmails.GroupByBoxVisible = false;
			this.grdEmails.Location = new System.Drawing.Point(3, 97);
			this.grdEmails.Name = "grdEmails";
			this.grdEmails.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
			this.grdEmails.Size = new System.Drawing.Size(326, 397);
			this.grdEmails.TabIndex = 0;
			// 
			// frmBookingCorrespondence
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.ClientSize = new System.Drawing.Size(934, 563);
			this.Controls.Add(this.splitMain);
			this.Name = "frmBookingCorrespondence";
			this.Text = "Correspondence";
			this.Controls.SetChildIndex(this.btnOK, 0);
			this.Controls.SetChildIndex(this.btnApply, 0);
			this.Controls.SetChildIndex(this.btnCancel, 0);
			this.Controls.SetChildIndex(this.splitMain, 0);
			((System.ComponentModel.ISupportInitialize)(this.cmbType)).EndInit();
			this.splitMain.Panel1.ResumeLayout(false);
			this.splitMain.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitMain)).EndInit();
			this.splitMain.ResumeLayout(false);
			this.splitSub.Panel1.ResumeLayout(false);
			this.splitSub.Panel1.PerformLayout();
			this.splitSub.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitSub)).EndInit();
			this.splitSub.ResumeLayout(false);
			this.ucPanel1.ResumeLayout(false);
			this.ucPanel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.cmbEmailList)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grdEmails)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private CommonWinCtrls.ucTextBox txtCorrDate;
		private CommonWinCtrls.ucMultiColumnCombo cmbType;
		private Infragistics.Win.FormattedLinkLabel.UltraFormattedTextEditor txtEdit;
		private CommonWinCtrls.ucSplitContainer splitMain;
		private CommonWinCtrls.ucSplitContainer splitSub;
		private CommonWinCtrls.ucMultiColumnCombo cmbEmailList;
		private CommonWinCtrls.ucGridEx grdEmails;
		private CommonWinCtrls.ucPanel ucPanel1;
		private CommonWinCtrls.ucTextBox txtUser;
		private CommonWinCtrls.ucTextBox txtEmailFrom;
		private CommonWinCtrls.ucTextBox txtTo;
	}
}
