namespace CS2010.ArcSys.Win
{
	partial class frmACMSLogin
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
			this.txtPassword = new CS2010.CommonWinCtrls.ucTextBox();
			this.SuspendLayout();
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(121, 118);
			this.btnOK.TabIndex = 1;
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(209, 118);
			this.btnCancel.TabIndex = 2;
			// 
			// btnApply
			// 
			this.btnApply.Location = new System.Drawing.Point(297, 118);
			this.btnApply.TabStop = true;
			this.btnApply.UseVisualStyleBackColor = false;
			// 
			// txtPassword
			// 
			this.txtPassword.LabelText = "ACMS Password";
			this.txtPassword.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtPassword.LinkDisabledMessage = "Link Disabled";
			this.txtPassword.Location = new System.Drawing.Point(121, 49);
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.PasswordChar = '*';
			this.txtPassword.Size = new System.Drawing.Size(134, 20);
			this.txtPassword.TabIndex = 0;
			// 
			// frmACMSLogin
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.ClientSize = new System.Drawing.Size(293, 152);
			this.Controls.Add(this.txtPassword);
			this.Name = "frmACMSLogin";
			this.Text = "ACMS Login";
			this.Controls.SetChildIndex(this.txtPassword, 0);
			this.Controls.SetChildIndex(this.btnApply, 0);
			this.Controls.SetChildIndex(this.btnCancel, 0);
			this.Controls.SetChildIndex(this.btnOK, 0);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private CommonWinCtrls.ucTextBox txtPassword;
	}
}
