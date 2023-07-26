namespace CS2010.CommonWinCtrls
{
	partial class frmDateSelector
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
			this.calDate = new System.Windows.Forms.MonthCalendar();
			this.SuspendLayout();
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(11, 164);
			this.btnOK.TabIndex = 1;
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(92, 164);
			this.btnCancel.TabIndex = 2;
			// 
			// calDate
			// 
			this.calDate.Location = new System.Drawing.Point(-2, -3);
			this.calDate.Name = "calDate";
			this.calDate.TabIndex = 0;
			// 
			// frmDateSelector
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(178, 196);
			this.Controls.Add(this.calDate);
			this.Name = "frmDateSelector";
			this.Text = "Select Date";
			this.Controls.SetChildIndex(this.btnOK, 0);
			this.Controls.SetChildIndex(this.btnCancel, 0);
			this.Controls.SetChildIndex(this.calDate, 0);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.MonthCalendar calDate;
	}
}