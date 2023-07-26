namespace ASL.ITrack.WinCtrls
{
	partial class frmIssueTrackingAdd
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
			Janus.Windows.GridEX.GridEXLayout cmbBizOwner_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIssueTrackingAdd));
			Janus.Windows.GridEX.GridEXLayout cmbProject_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			this.txtDesc = new CS2010.CommonWinCtrls.ucTextBox();
			this.btnOK = new CS2010.CommonWinCtrls.ucButton();
			this.btnCancel = new CS2010.CommonWinCtrls.ucButton();
			this.lblTip = new CS2010.CommonWinCtrls.ucLabel();
			this.cmbBizOwner = new ASL.ITrack.WinCtrls.ucUserCombo();
			this.cmbProject = new ASL.ITrack.WinCtrls.ucProjectCombo();
			((System.ComponentModel.ISupportInitialize)(this.cmbBizOwner)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbProject)).BeginInit();
			this.SuspendLayout();
			// 
			// txtDesc
			// 
			this.txtDesc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtDesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
			this.txtDesc.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtDesc.LabelText = "&Description";
			this.txtDesc.LinkDisabledMessage = "Link Disabled";
			this.txtDesc.Location = new System.Drawing.Point(52, 61);
			this.txtDesc.Multiline = true;
			this.txtDesc.Name = "txtDesc";
			this.txtDesc.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtDesc.Size = new System.Drawing.Size(631, 250);
			this.txtDesc.TabIndex = 3;
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOK.Location = new System.Drawing.Point(527, 317);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 20;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(608, 317);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 21;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// lblTip
			// 
			this.lblTip.AutoSize = false;
			this.lblTip.BackColor = System.Drawing.Color.Transparent;
			this.lblTip.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblTip.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.lblTip.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTip.Location = new System.Drawing.Point(52, 38);
			this.lblTip.Name = "lblTip";
			this.lblTip.Size = new System.Drawing.Size(631, 20);
			this.lblTip.TabIndex = 2;
			this.lblTip.Text = "Describe the issue in the space below. Be sure to include reference numbers (i.e." +
				" Order #, BOL, Invoice #, etc).";
			// 
			// cmbBizOwner
			// 
			this.cmbBizOwner.CodeColumn = "User_Login";
			this.cmbBizOwner.DescriptionColumn = "User_Nm";
			cmbBizOwner_DesignTimeLayout.LayoutString = resources.GetString("cmbBizOwner_DesignTimeLayout.LayoutString");
			this.cmbBizOwner.DesignTimeLayout = cmbBizOwner_DesignTimeLayout;
			this.cmbBizOwner.DisplayMember = "User_LoginUser_Nm";
			this.cmbBizOwner.DisplayType = CS2010.CommonWinCtrls.ComboDisplay.CodePlusDescription;
			this.cmbBizOwner.LabelText = "Biz Owner";
			this.cmbBizOwner.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.cmbBizOwner.Location = new System.Drawing.Point(107, 319);
			this.cmbBizOwner.Name = "cmbBizOwner";
			this.cmbBizOwner.SelectedIndex = -1;
			this.cmbBizOwner.SelectedItem = null;
			this.cmbBizOwner.Size = new System.Drawing.Size(233, 20);
			this.cmbBizOwner.TabIndex = 5;
			this.cmbBizOwner.ValueColumn = "User_Login";
			this.cmbBizOwner.ValueMember = "User_Login";
			this.cmbBizOwner.Visible = false;
			// 
			// cmbProject
			// 
			this.cmbProject.CodeColumn = "Project_Cd";
			this.cmbProject.DescriptionColumn = "Project_Nm";
			cmbProject_DesignTimeLayout.LayoutString = resources.GetString("cmbProject_DesignTimeLayout.LayoutString");
			this.cmbProject.DesignTimeLayout = cmbProject_DesignTimeLayout;
			this.cmbProject.DisplayMember = "Project_CdProject_Nm";
			this.cmbProject.DisplayType = CS2010.CommonWinCtrls.ComboDisplay.CodePlusDescription;
			this.cmbProject.LabelText = "&Project";
			this.cmbProject.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.cmbProject.Location = new System.Drawing.Point(52, 13);
			this.cmbProject.Name = "cmbProject";
			this.cmbProject.SelectedIndex = -1;
			this.cmbProject.SelectedItem = null;
			this.cmbProject.Size = new System.Drawing.Size(631, 20);
			this.cmbProject.TabIndex = 1;
			this.cmbProject.ValueColumn = "Project_Cd";
			this.cmbProject.ValueMember = "Project_Cd";
			// 
			// frmIssueTrackingAdd
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(702, 353);
			this.Controls.Add(this.cmbBizOwner);
			this.Controls.Add(this.lblTip);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.cmbProject);
			this.Controls.Add(this.txtDesc);
			this.Name = "frmIssueTrackingAdd";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Create Issue";
			this.Load += new System.EventHandler(this.frmIssueTrackingAdd_Load);
			((System.ComponentModel.ISupportInitialize)(this.cmbBizOwner)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbProject)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private CS2010.CommonWinCtrls.ucTextBox txtDesc;
		private ASL.ITrack.WinCtrls.ucProjectCombo cmbProject;
		private CS2010.CommonWinCtrls.ucButton btnOK;
		private CS2010.CommonWinCtrls.ucButton btnCancel;
		private CS2010.CommonWinCtrls.ucLabel lblTip;
		private ASL.ITrack.WinCtrls.ucUserCombo cmbBizOwner;
	}
}