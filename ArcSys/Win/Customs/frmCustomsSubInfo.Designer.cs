namespace CS2010.ArcSys.Win
{
	partial class frmCustomsSubInfo
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
			this.calSubDt = new System.Windows.Forms.MonthCalendar();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.txtNotes = new System.Windows.Forms.TextBox();
			this.lblSubDt = new System.Windows.Forms.Label();
			this.lblNotes = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// calSubDt
			// 
			this.calSubDt.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.calSubDt.Location = new System.Drawing.Point(78, 6);
			this.calSubDt.MaxSelectionCount = 1;
			this.calSubDt.Name = "calSubDt";
			this.calSubDt.TabIndex = 1;
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(156, 396);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 20;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(237, 396);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 21;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// txtNotes
			// 
			this.txtNotes.Location = new System.Drawing.Point(78, 243);
			this.txtNotes.Multiline = true;
			this.txtNotes.Name = "txtNotes";
			this.txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtNotes.Size = new System.Drawing.Size(244, 141);
			this.txtNotes.TabIndex = 3;
			// 
			// lblSubDt
			// 
			this.lblSubDt.AutoSize = true;
			this.lblSubDt.Location = new System.Drawing.Point(8, 8);
			this.lblSubDt.Name = "lblSubDt";
			this.lblSubDt.Size = new System.Drawing.Size(69, 13);
			this.lblSubDt.TabIndex = 0;
			this.lblSubDt.Text = "&Submitted on";
			// 
			// lblNotes
			// 
			this.lblNotes.AutoSize = true;
			this.lblNotes.Location = new System.Drawing.Point(39, 245);
			this.lblNotes.Name = "lblNotes";
			this.lblNotes.Size = new System.Drawing.Size(35, 13);
			this.lblNotes.TabIndex = 2;
			this.lblNotes.Text = "&Notes";
			// 
			// frmCustomsSubInfo
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(340, 427);
			this.ControlBox = false;
			this.Controls.Add(this.lblNotes);
			this.Controls.Add(this.lblSubDt);
			this.Controls.Add(this.txtNotes);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.calSubDt);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "frmCustomsSubInfo";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Submitted on";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MonthCalendar calSubDt;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.TextBox txtNotes;
		private System.Windows.Forms.Label lblSubDt;
		private System.Windows.Forms.Label lblNotes;
	}
}