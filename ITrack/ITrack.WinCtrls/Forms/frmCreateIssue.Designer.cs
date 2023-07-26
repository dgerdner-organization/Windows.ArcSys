namespace ASL.ITrack.WinCtrls
{
	partial class frmCreateIssue
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
			Janus.Windows.GridEX.GridEXLayout gridEXLayout1 = new Janus.Windows.GridEX.GridEXLayout();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCreateIssue));
			Janus.Windows.GridEX.GridEXLayout gridEXLayout2 = new Janus.Windows.GridEX.GridEXLayout();
			this.txtDesc = new CS2010.CommonWinCtrls.ucTextBox();
			this.chkEmergency = new CS2010.CommonWinCtrls.ucCheckBox();
			this.btnOK = new CS2010.CommonWinCtrls.ucButton();
			this.btnCancel = new CS2010.CommonWinCtrls.ucButton();
			this.lblTip = new CS2010.CommonWinCtrls.ucLabel();
			this.chkDataFix = new CS2010.CommonWinCtrls.ucCheckBox();
			this.rdoReproduceNo = new CS2010.CommonWinCtrls.ucRadioButton();
			this.rdoReproduceYes = new CS2010.CommonWinCtrls.ucRadioButton();
			this.cmbProject = new ASL.ITrack.WinCtrls.ucProjectCombo();
			this.lblRep = new CS2010.CommonWinCtrls.ucLabel();
			this.ucPanel1 = new CS2010.CommonWinCtrls.ucPanel();
			this.rdoNA = new CS2010.CommonWinCtrls.ucRadioButton();
			this.cmbBizOwner = new ASL.ITrack.WinCtrls.ucUserCombo();
			((System.ComponentModel.ISupportInitialize)(this.cmbProject)).BeginInit();
			this.ucPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.cmbBizOwner)).BeginInit();
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
			this.txtDesc.Location = new System.Drawing.Point(52, 92);
			this.txtDesc.Multiline = true;
			this.txtDesc.Name = "txtDesc";
			this.txtDesc.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtDesc.Size = new System.Drawing.Size(631, 219);
			this.txtDesc.TabIndex = 6;
			// 
			// chkEmergency
			// 
			this.chkEmergency.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.chkEmergency.AutoSize = true;
			this.chkEmergency.Location = new System.Drawing.Point(52, 320);
			this.chkEmergency.Name = "chkEmergency";
			this.chkEmergency.Size = new System.Drawing.Size(79, 17);
			this.chkEmergency.TabIndex = 7;
			this.chkEmergency.Text = "&Emergency";
			this.chkEmergency.UseVisualStyleBackColor = true;
			this.chkEmergency.YN = "N";
			this.chkEmergency.CheckedChanged += new System.EventHandler(this.chkEmergency_CheckedChanged);
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOK.Location = new System.Drawing.Point(527, 317);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 9;
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
			this.btnCancel.TabIndex = 10;
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
			this.lblTip.Location = new System.Drawing.Point(52, 69);
			this.lblTip.Name = "lblTip";
			this.lblTip.Size = new System.Drawing.Size(631, 20);
			this.lblTip.TabIndex = 5;
			this.lblTip.Text = "Describe the issue in the space below. Be sure to include reference numbers (i.e." +
				" Order #, BOL, Invoice #, etc).";
			// 
			// chkDataFix
			// 
			this.chkDataFix.AutoSize = true;
			this.chkDataFix.Location = new System.Drawing.Point(396, 15);
			this.chkDataFix.Name = "chkDataFix";
			this.chkDataFix.Size = new System.Drawing.Size(65, 17);
			this.chkDataFix.TabIndex = 2;
			this.chkDataFix.Text = "Data Fi&x";
			this.chkDataFix.UseVisualStyleBackColor = true;
			this.chkDataFix.YN = "N";
			// 
			// rdoReproduceNo
			// 
			this.rdoReproduceNo.AutoSize = true;
			this.rdoReproduceNo.Location = new System.Drawing.Point(55, 4);
			this.rdoReproduceNo.Name = "rdoReproduceNo";
			this.rdoReproduceNo.Size = new System.Drawing.Size(39, 17);
			this.rdoReproduceNo.TabIndex = 1;
			this.rdoReproduceNo.TabStop = true;
			this.rdoReproduceNo.Text = "No";
			this.rdoReproduceNo.UseVisualStyleBackColor = true;
			// 
			// rdoReproduceYes
			// 
			this.rdoReproduceYes.AutoSize = true;
			this.rdoReproduceYes.Location = new System.Drawing.Point(4, 4);
			this.rdoReproduceYes.Name = "rdoReproduceYes";
			this.rdoReproduceYes.Size = new System.Drawing.Size(43, 17);
			this.rdoReproduceYes.TabIndex = 0;
			this.rdoReproduceYes.TabStop = true;
			this.rdoReproduceYes.Text = "Yes";
			this.rdoReproduceYes.UseVisualStyleBackColor = true;
			this.rdoReproduceYes.CheckedChanged += new System.EventHandler(this.rdoReproduceYes_CheckedChanged);
			// 
			// cmbProject
			// 
			this.cmbProject.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.cmbProject.CodeColumn = "Project_Cd";
			this.cmbProject.DescriptionColumn = "Project_Nm";
			gridEXLayout1.LayoutString = resources.GetString("gridEXLayout1.LayoutString");
			this.cmbProject.DesignTimeLayout = gridEXLayout1;
			this.cmbProject.DisplayMember = "Project_CdProject_Nm";
			this.cmbProject.DisplayType = CS2010.CommonWinCtrls.ComboDisplay.CodePlusDescription;
			this.cmbProject.LabelText = "&Project";
			this.cmbProject.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.cmbProject.Location = new System.Drawing.Point(52, 13);
			this.cmbProject.Name = "cmbProject";
			this.cmbProject.SaveSettings = false;
			this.cmbProject.SelectedIndex = -1;
			this.cmbProject.SelectedItem = null;
			this.cmbProject.Size = new System.Drawing.Size(328, 20);
			this.cmbProject.TabIndex = 1;
			this.cmbProject.ValueColumn = "Project_Cd";
			this.cmbProject.ValueMember = "Project_Cd";
			// 
			// lblRep
			// 
			this.lblRep.Location = new System.Drawing.Point(49, 45);
			this.lblRep.Name = "lblRep";
			this.lblRep.Size = new System.Drawing.Size(162, 13);
			this.lblRep.TabIndex = 3;
			this.lblRep.Text = "Can the problem be reproduced?";
			// 
			// ucPanel1
			// 
			this.ucPanel1.Controls.Add(this.rdoNA);
			this.ucPanel1.Controls.Add(this.rdoReproduceYes);
			this.ucPanel1.Controls.Add(this.rdoReproduceNo);
			this.ucPanel1.Location = new System.Drawing.Point(217, 39);
			this.ucPanel1.Name = "ucPanel1";
			this.ucPanel1.Size = new System.Drawing.Size(151, 24);
			this.ucPanel1.TabIndex = 4;
			// 
			// rdoNA
			// 
			this.rdoNA.AutoSize = true;
			this.rdoNA.Location = new System.Drawing.Point(100, 4);
			this.rdoNA.Name = "rdoNA";
			this.rdoNA.Size = new System.Drawing.Size(45, 17);
			this.rdoNA.TabIndex = 2;
			this.rdoNA.TabStop = true;
			this.rdoNA.Text = "N/A";
			this.rdoNA.UseVisualStyleBackColor = true;
			// 
			// cmbBizOwner
			// 
			this.cmbBizOwner.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.cmbBizOwner.CodeColumn = "User_Login";
			this.cmbBizOwner.DescriptionColumn = "User_Nm";
			gridEXLayout2.LayoutString = resources.GetString("gridEXLayout2.LayoutString");
			this.cmbBizOwner.DesignTimeLayout = gridEXLayout2;
			this.cmbBizOwner.DisplayMember = "User_LoginUser_Nm";
			this.cmbBizOwner.DisplayType = CS2010.CommonWinCtrls.ComboDisplay.CodePlusDescription;
			this.cmbBizOwner.LabelText = "Biz Owner";
			this.cmbBizOwner.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.cmbBizOwner.Location = new System.Drawing.Point(200, 318);
			this.cmbBizOwner.Name = "cmbBizOwner";
			this.cmbBizOwner.SaveSettings = false;
			this.cmbBizOwner.SelectedIndex = -1;
			this.cmbBizOwner.SelectedItem = null;
			this.cmbBizOwner.Size = new System.Drawing.Size(233, 20);
			this.cmbBizOwner.TabIndex = 8;
			this.cmbBizOwner.ValueColumn = "User_Login";
			this.cmbBizOwner.ValueMember = "User_Login";
			this.cmbBizOwner.Visible = false;
			// 
			// frmCreateIssue
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(702, 353);
			this.Controls.Add(this.cmbBizOwner);
			this.Controls.Add(this.ucPanel1);
			this.Controls.Add(this.lblRep);
			this.Controls.Add(this.chkDataFix);
			this.Controls.Add(this.lblTip);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.chkEmergency);
			this.Controls.Add(this.cmbProject);
			this.Controls.Add(this.txtDesc);
			this.Name = "frmCreateIssue";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Create Issue";
			this.Load += new System.EventHandler(this.frmCreateIssue_Load);
			((System.ComponentModel.ISupportInitialize)(this.cmbProject)).EndInit();
			this.ucPanel1.ResumeLayout(false);
			this.ucPanel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.cmbBizOwner)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private CS2010.CommonWinCtrls.ucTextBox txtDesc;
		private ASL.ITrack.WinCtrls.ucProjectCombo cmbProject;
		private CS2010.CommonWinCtrls.ucCheckBox chkEmergency;
		private CS2010.CommonWinCtrls.ucButton btnOK;
		private CS2010.CommonWinCtrls.ucButton btnCancel;
		private CS2010.CommonWinCtrls.ucLabel lblTip;
		private CS2010.CommonWinCtrls.ucCheckBox chkDataFix;
		private CS2010.CommonWinCtrls.ucRadioButton rdoReproduceNo;
		private CS2010.CommonWinCtrls.ucRadioButton rdoReproduceYes;
		private CS2010.CommonWinCtrls.ucLabel lblRep;
		private CS2010.CommonWinCtrls.ucPanel ucPanel1;
		private CS2010.CommonWinCtrls.ucRadioButton rdoNA;
		private ASL.ITrack.WinCtrls.ucUserCombo cmbBizOwner;
	}
}