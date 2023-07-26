namespace CS2010.CommonWinCtrls
{
	partial class frmAddressPlus
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
			this.txtCode = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtAddressee = new CS2010.CommonWinCtrls.ucTextBox();
			this.grpAddress = new CS2010.CommonWinCtrls.ucAddressBox();
			this.SuspendLayout();
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(158, 276);
			this.btnOK.TabIndex = 6;
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(242, 276);
			this.btnCancel.TabIndex = 7;
			// 
			// btnApply
			// 
			this.btnApply.Location = new System.Drawing.Point(74, 276);
			this.btnApply.TabIndex = 5;
			this.btnApply.TabStop = true;
			this.btnApply.UseVisualStyleBackColor = false;
			// 
			// txtCode
			// 
			this.txtCode.LabelText = "Code";
			this.txtCode.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtCode.Location = new System.Drawing.Point(68, 8);
			this.txtCode.Name = "txtCode";
			this.txtCode.Size = new System.Drawing.Size(250, 20);
			this.txtCode.TabIndex = 1;
			this.txtCode.Visible = false;
			// 
			// txtAddressee
			// 
			this.txtAddressee.LabelText = "Addressee";
			this.txtAddressee.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtAddressee.Location = new System.Drawing.Point(68, 38);
			this.txtAddressee.Name = "txtAddressee";
			this.txtAddressee.Size = new System.Drawing.Size(250, 20);
			this.txtAddressee.TabIndex = 3;
			this.txtAddressee.Visible = false;
			// 
			// grpAddress
			// 
			this.grpAddress.Location = new System.Drawing.Point(2, 70);
			this.grpAddress.Name = "grpAddress";
			this.grpAddress.Size = new System.Drawing.Size(317, 200);
			this.grpAddress.TabIndex = 4;
			// 
			// frmAddressPlus
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(321, 307);
			this.Controls.Add(this.txtCode);
			this.Controls.Add(this.txtAddressee);
			this.Controls.Add(this.grpAddress);
			this.Name = "frmAddressPlus";
			this.ShowInTaskbar = false;
			this.Text = "Address";
			this.Controls.SetChildIndex(this.btnApply, 0);
			this.Controls.SetChildIndex(this.btnOK, 0);
			this.Controls.SetChildIndex(this.grpAddress, 0);
			this.Controls.SetChildIndex(this.txtAddressee, 0);
			this.Controls.SetChildIndex(this.btnCancel, 0);
			this.Controls.SetChildIndex(this.txtCode, 0);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		protected ucTextBox txtCode;
		protected ucTextBox txtAddressee;
		protected ucAddressBox grpAddress;

	}
}