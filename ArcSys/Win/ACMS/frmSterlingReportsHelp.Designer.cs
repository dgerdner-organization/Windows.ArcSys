namespace CS2010.ArcSys.Win
{
	partial class frmSterlingReportsHelp
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSterlingReportsHelp));
			this.rtfMain = new System.Windows.Forms.RichTextBox();
			this.SuspendLayout();
			// 
			// rtfMain
			// 
			this.rtfMain.Location = new System.Drawing.Point(12, 12);
			this.rtfMain.Name = "rtfMain";
			this.rtfMain.ReadOnly = true;
			this.rtfMain.Size = new System.Drawing.Size(536, 404);
			this.rtfMain.TabIndex = 1;
			this.rtfMain.Text = resources.GetString("rtfMain.Text");
			// 
			// frmSterlingReportsHelp
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(568, 441);
			this.Controls.Add(this.rtfMain);
			this.Name = "frmSterlingReportsHelp";
			this.Text = "frmSterlingReportsHelp";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.RichTextBox rtfMain;
	}
}