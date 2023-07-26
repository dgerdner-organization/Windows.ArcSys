namespace CS2010.CommonWinCtrls
{
	partial class ucDateGroupBox
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.grpDates = new CS2010.CommonWinCtrls.ucGroupBox();
			this.chkDates = new System.Windows.Forms.CheckBox();
			this.dteTo = new CS2010.CommonWinCtrls.ucDateTextBox();
			this.dteFrom = new CS2010.CommonWinCtrls.ucDateTextBox();
			this.grpDates.SuspendLayout();
			this.SuspendLayout();
			// 
			// grpDates
			// 
			this.grpDates.Controls.Add(this.dteTo);
			this.grpDates.Controls.Add(this.dteFrom);
			this.grpDates.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grpDates.Location = new System.Drawing.Point(0, 0);
			this.grpDates.Name = "grpDates";
			this.grpDates.Size = new System.Drawing.Size(129, 76);
			this.grpDates.TabIndex = 0;
			this.grpDates.TabStop = false;
			// 
			// chkDates
			// 
			this.chkDates.AutoSize = true;
			this.chkDates.Location = new System.Drawing.Point(8, 0);
			this.chkDates.Name = "chkDates";
			this.chkDates.Size = new System.Drawing.Size(54, 17);
			this.chkDates.TabIndex = 0;
			this.chkDates.Text = "Dates";
			this.chkDates.UseVisualStyleBackColor = true;
			this.chkDates.CheckedChanged += new System.EventHandler(this.chkDates_CheckedChanged);
			// 
			// dteTo
			// 
			this.dteTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.dteTo.Enabled = false;
			this.dteTo.LabelText = "To";
			this.dteTo.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.dteTo.LinkDisabledMessage = "Link Disabled";
			this.dteTo.Location = new System.Drawing.Point(40, 48);
			this.dteTo.MaxLength = 10;
			this.dteTo.Name = "dteTo";
			this.dteTo.Size = new System.Drawing.Size(84, 20);
			this.dteTo.TabIndex = 2;
			this.dteTo.Value = null;
			this.dteTo.ValueChanged += new System.EventHandler(this.dteTo_ValueChanged);
			// 
			// dteFrom
			// 
			this.dteFrom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.dteFrom.Enabled = false;
			this.dteFrom.LabelText = "From";
			this.dteFrom.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.dteFrom.LinkDisabledMessage = "Link Disabled";
			this.dteFrom.Location = new System.Drawing.Point(40, 22);
			this.dteFrom.MaxLength = 10;
			this.dteFrom.Name = "dteFrom";
			this.dteFrom.Size = new System.Drawing.Size(84, 20);
			this.dteFrom.TabIndex = 1;
			this.dteFrom.Value = null;
			this.dteFrom.ValueChanged += new System.EventHandler(this.dteFrom_ValueChanged);
			// 
			// ucDateGroupBox
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.chkDates);
			this.Controls.Add(this.grpDates);
			this.Name = "ucDateGroupBox";
			this.Size = new System.Drawing.Size(129, 76);
			this.grpDates.ResumeLayout(false);
			this.grpDates.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private ucGroupBox grpDates;
		private System.Windows.Forms.CheckBox chkDates;
		private ucDateTextBox dteTo;
		private ucDateTextBox dteFrom;
	}
}
