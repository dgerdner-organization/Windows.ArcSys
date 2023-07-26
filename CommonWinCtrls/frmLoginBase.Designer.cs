namespace CS2010.CommonWinCtrls
{
	partial class frmLoginBase
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
			this.lblUser = new System.Windows.Forms.Label();
			this.lblPwd = new System.Windows.Forms.Label();
			this.txtUser = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtPwd = new CS2010.CommonWinCtrls.ucTextBox();
			this.lblVersion = new CS2010.CommonWinCtrls.ucLabel();
			this.lblCopyright = new CS2010.CommonWinCtrls.ucLabel();
			this.SuspendLayout();
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnOK.Location = new System.Drawing.Point(79, 109);
			this.btnOK.TabIndex = 4;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnCancel.Location = new System.Drawing.Point(167, 109);
			this.btnCancel.TabIndex = 5;
			// 
			// btnApply
			// 
			this.btnApply.TabStop = true;
			this.btnApply.UseVisualStyleBackColor = false;
			// 
			// lblUser
			// 
			this.lblUser.AutoSize = true;
			this.lblUser.Location = new System.Drawing.Point(12, 16);
			this.lblUser.Name = "lblUser";
			this.lblUser.Size = new System.Drawing.Size(60, 13);
			this.lblUser.TabIndex = 0;
			this.lblUser.Text = "&User Name";
			this.lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblPwd
			// 
			this.lblPwd.AutoSize = true;
			this.lblPwd.Location = new System.Drawing.Point(19, 42);
			this.lblPwd.Name = "lblPwd";
			this.lblPwd.Size = new System.Drawing.Size(53, 13);
			this.lblPwd.TabIndex = 2;
			this.lblPwd.Text = "&Password";
			this.lblPwd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtUser
			// 
			this.txtUser.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtUser.LinkDisabledMessage = "Link Disabled";
			this.txtUser.Location = new System.Drawing.Point(78, 12);
			this.txtUser.Name = "txtUser";
			this.txtUser.Size = new System.Drawing.Size(164, 20);
			this.txtUser.TabIndex = 1;
			// 
			// txtPwd
			// 
			this.txtPwd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtPwd.LinkDisabledMessage = "Link Disabled";
			this.txtPwd.Location = new System.Drawing.Point(78, 38);
			this.txtPwd.Name = "txtPwd";
			this.txtPwd.PasswordChar = '*';
			this.txtPwd.Size = new System.Drawing.Size(164, 20);
			this.txtPwd.TabIndex = 3;
			// 
			// lblVersion
			// 
			this.lblVersion.AutoSize = true;
			this.lblVersion.Location = new System.Drawing.Point(24, 74);
			this.lblVersion.Name = "lblVersion";
			this.lblVersion.Size = new System.Drawing.Size(0, 13);
			this.lblVersion.TabIndex = 6;
			this.lblVersion.Visible = false;
			// 
			// lblCopyright
			// 
			this.lblCopyright.AutoSize = true;
			this.lblCopyright.Location = new System.Drawing.Point(24, 90);
			this.lblCopyright.Name = "lblCopyright";
			this.lblCopyright.Size = new System.Drawing.Size(0, 13);
			this.lblCopyright.TabIndex = 8;
			this.lblCopyright.Visible = false;
			// 
			// frmLoginBase
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(258, 144);
			this.Controls.Add(this.lblCopyright);
			this.Controls.Add(this.lblVersion);
			this.Controls.Add(this.lblUser);
			this.Controls.Add(this.txtUser);
			this.Controls.Add(this.lblPwd);
			this.Controls.Add(this.txtPwd);
			this.Name = "frmLoginBase";
			this.Text = "Login";
			this.Controls.SetChildIndex(this.btnApply, 0);
			this.Controls.SetChildIndex(this.txtPwd, 0);
			this.Controls.SetChildIndex(this.lblPwd, 0);
			this.Controls.SetChildIndex(this.btnOK, 0);
			this.Controls.SetChildIndex(this.txtUser, 0);
			this.Controls.SetChildIndex(this.btnCancel, 0);
			this.Controls.SetChildIndex(this.lblUser, 0);
			this.Controls.SetChildIndex(this.lblVersion, 0);
			this.Controls.SetChildIndex(this.lblCopyright, 0);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

        protected CS2010.CommonWinCtrls.ucTextBox txtUser;
        protected CS2010.CommonWinCtrls.ucTextBox txtPwd;
        public System.Windows.Forms.Label lblUser;
        public System.Windows.Forms.Label lblPwd;
        public ucLabel lblVersion;
        public ucLabel lblCopyright;
	}
}