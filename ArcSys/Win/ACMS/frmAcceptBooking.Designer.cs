namespace CS2010.ArcSys.Win
{
	partial class frmAcceptBooking
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
			this.txtBookingNo = new CS2010.CommonWinCtrls.ucTextBox();
			this.SuspendLayout();
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(75, 82);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(163, 82);
			// 
			// btnApply
			// 
			this.btnApply.Location = new System.Drawing.Point(251, 82);
			this.btnApply.TabStop = true;
			this.btnApply.UseVisualStyleBackColor = false;
			// 
			// txtBookingNo
			// 
			this.txtBookingNo.LabelText = "Booking#";
			this.txtBookingNo.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtBookingNo.LinkDisabledMessage = "Link Disabled";
			this.txtBookingNo.Location = new System.Drawing.Point(97, 28);
			this.txtBookingNo.Name = "txtBookingNo";
			this.txtBookingNo.Size = new System.Drawing.Size(137, 20);
			this.txtBookingNo.TabIndex = 3;
			// 
			// frmAcceptBooking
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.ClientSize = new System.Drawing.Size(374, 137);
			this.Controls.Add(this.txtBookingNo);
			this.Name = "frmAcceptBooking";
			this.Text = "Confirm Booking";
			this.Controls.SetChildIndex(this.btnCancel, 0);
			this.Controls.SetChildIndex(this.btnOK, 0);
			this.Controls.SetChildIndex(this.btnApply, 0);
			this.Controls.SetChildIndex(this.txtBookingNo, 0);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private CommonWinCtrls.ucTextBox txtBookingNo;
	}
}
