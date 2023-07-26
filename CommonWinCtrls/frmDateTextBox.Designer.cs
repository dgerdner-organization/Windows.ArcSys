namespace CS2010.CommonWinCtrls
{
	partial class frmDateTextBox
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
			this.txtDate = new CS2010.CommonWinCtrls.ucDateTextBox();
			this.SuspendLayout();
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOK.Location = new System.Drawing.Point(15, 42);
			this.btnOK.TabIndex = 2;
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.Location = new System.Drawing.Point(96, 42);
			this.btnCancel.TabIndex = 3;
			// 
			// btnApply
			// 
			this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnApply.Location = new System.Drawing.Point(178, 42);
			this.btnApply.TabIndex = 4;
			this.btnApply.TabStop = true;
			this.btnApply.UseVisualStyleBackColor = false;
			// 
			// txtDate
			// 
			this.txtDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtDate.LinkDisabledMessage = "Link Disabled";
			this.txtDate.Location = new System.Drawing.Point(12, 12);
			this.txtDate.MaxLength = 6;
			this.txtDate.Name = "txtDate";
			this.txtDate.Size = new System.Drawing.Size(158, 20);
			this.txtDate.TabIndex = 1;
			this.txtDate.Value = null;
			// 
			// frmDateTextBox
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(187, 81);
			this.Controls.Add(this.txtDate);
			this.Name = "frmDateTextBox";
			this.Text = "Select Date";
			this.Controls.SetChildIndex(this.btnCancel, 0);
			this.Controls.SetChildIndex(this.btnOK, 0);
			this.Controls.SetChildIndex(this.btnApply, 0);
			this.Controls.SetChildIndex(this.txtDate, 0);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private ucDateTextBox txtDate;

	}
}