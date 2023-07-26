namespace CS2010.CommonWinCtrls
{
	partial class frmEmailList
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
			this.tvwAddresses = new CS2010.CommonWinCtrls.ucTreeView();
			this.btnCheckAll = new CS2010.CommonWinCtrls.ucButton();
			this.btnUncheckAll = new CS2010.CommonWinCtrls.ucButton();
			this.SuspendLayout();
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(291, 322);
			this.btnOK.TabIndex = 3;
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(375, 322);
			this.btnCancel.TabIndex = 4;
			// 
			// btnApply
			// 
			this.btnApply.Location = new System.Drawing.Point(459, 322);
			this.btnApply.TabIndex = 5;
			this.btnApply.TabStop = true;
			this.btnApply.UseVisualStyleBackColor = false;
			// 
			// tvwAddresses
			// 
			this.tvwAddresses.CheckBoxes = true;
			this.tvwAddresses.Dock = System.Windows.Forms.DockStyle.Top;
			this.tvwAddresses.Location = new System.Drawing.Point(0, 0);
			this.tvwAddresses.Name = "tvwAddresses";
			this.tvwAddresses.ShowPlusMinus = false;
			this.tvwAddresses.Size = new System.Drawing.Size(475, 310);
			this.tvwAddresses.TabIndex = 0;
			// 
			// btnCheckAll
			// 
			this.btnCheckAll.Location = new System.Drawing.Point(12, 322);
			this.btnCheckAll.Name = "btnCheckAll";
			this.btnCheckAll.Size = new System.Drawing.Size(75, 23);
			this.btnCheckAll.TabIndex = 1;
			this.btnCheckAll.Text = "Check &All";
			this.btnCheckAll.UseVisualStyleBackColor = true;
			this.btnCheckAll.Click += new System.EventHandler(this.btnCheckAll_Click);
			// 
			// btnUncheckAll
			// 
			this.btnUncheckAll.Location = new System.Drawing.Point(93, 322);
			this.btnUncheckAll.Name = "btnUncheckAll";
			this.btnUncheckAll.Size = new System.Drawing.Size(75, 23);
			this.btnUncheckAll.TabIndex = 2;
			this.btnUncheckAll.Text = "&Uncheck All";
			this.btnUncheckAll.UseVisualStyleBackColor = true;
			this.btnUncheckAll.Click += new System.EventHandler(this.btnUncheckAll_Click);
			// 
			// frmEmailList
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(475, 357);
			this.Controls.Add(this.btnUncheckAll);
			this.Controls.Add(this.btnCheckAll);
			this.Controls.Add(this.tvwAddresses);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
			this.Name = "frmEmailList";
			this.Text = "Select Email";
			this.Controls.SetChildIndex(this.btnApply, 0);
			this.Controls.SetChildIndex(this.btnCancel, 0);
			this.Controls.SetChildIndex(this.btnOK, 0);
			this.Controls.SetChildIndex(this.tvwAddresses, 0);
			this.Controls.SetChildIndex(this.btnCheckAll, 0);
			this.Controls.SetChildIndex(this.btnUncheckAll, 0);
			this.ResumeLayout(false);

		}

		#endregion

		private ucTreeView tvwAddresses;
		private ucButton btnCheckAll;
		private ucButton btnUncheckAll;
	}
}