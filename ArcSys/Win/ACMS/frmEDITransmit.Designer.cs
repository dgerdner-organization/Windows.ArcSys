namespace CS2010.ArcSys.Win
{
	partial class frmEDITransmit
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
			this.cbx300ToLINE = new CS2010.CommonWinCtrls.ucCheckBox();
			this.cbx301ToSDDC = new CS2010.CommonWinCtrls.ucCheckBox();
			this.cbx315ToSDDC = new CS2010.CommonWinCtrls.ucCheckBox();
			this.btnTransmit = new CS2010.CommonWinCtrls.ucButton();
			this.txt300ToLINE = new CS2010.CommonWinCtrls.ucTextBox();
			this.txt301ToSDDC = new CS2010.CommonWinCtrls.ucTextBox();
			this.txt315ToSDDC = new CS2010.CommonWinCtrls.ucTextBox();
			this.groupOther = new CS2010.CommonWinCtrls.ucGroupBox();
			this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
			this.btnLaunchSDDCEDI = new CS2010.CommonWinCtrls.ucButton();
			this.ucGroupBox1 = new CS2010.CommonWinCtrls.ucGroupBox();
			this.txtMessage = new System.Windows.Forms.TextBox();
			this.cbxAAL304 = new CS2010.CommonWinCtrls.ucCheckBox();
			this.cbxSDDC304 = new CS2010.CommonWinCtrls.ucCheckBox();
			this.txt304SDDC = new CS2010.CommonWinCtrls.ucTextBox();
			this.txt304AAL = new CS2010.CommonWinCtrls.ucTextBox();
			this.groupOther.SuspendLayout();
			this.ucGroupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// cbx300ToLINE
			// 
			this.cbx300ToLINE.Location = new System.Drawing.Point(16, 72);
			this.cbx300ToLINE.Name = "cbx300ToLINE";
			this.cbx300ToLINE.Size = new System.Drawing.Size(133, 24);
			this.cbx300ToLINE.TabIndex = 2;
			this.cbx300ToLINE.Text = "300\'s To LINE";
			this.cbx300ToLINE.UseVisualStyleBackColor = true;
			this.cbx300ToLINE.YN = "N";
			// 
			// cbx301ToSDDC
			// 
			this.cbx301ToSDDC.Location = new System.Drawing.Point(16, 97);
			this.cbx301ToSDDC.Name = "cbx301ToSDDC";
			this.cbx301ToSDDC.Size = new System.Drawing.Size(133, 24);
			this.cbx301ToSDDC.TabIndex = 3;
			this.cbx301ToSDDC.Text = "301\'s To SDDC";
			this.cbx301ToSDDC.UseVisualStyleBackColor = true;
			this.cbx301ToSDDC.YN = "N";
			// 
			// cbx315ToSDDC
			// 
			this.cbx315ToSDDC.Location = new System.Drawing.Point(16, 124);
			this.cbx315ToSDDC.Name = "cbx315ToSDDC";
			this.cbx315ToSDDC.Size = new System.Drawing.Size(133, 24);
			this.cbx315ToSDDC.TabIndex = 4;
			this.cbx315ToSDDC.Text = "315\'s To SDDC";
			this.cbx315ToSDDC.UseVisualStyleBackColor = true;
			this.cbx315ToSDDC.YN = "N";
			// 
			// btnTransmit
			// 
			this.btnTransmit.Location = new System.Drawing.Point(227, 301);
			this.btnTransmit.Name = "btnTransmit";
			this.btnTransmit.Size = new System.Drawing.Size(75, 23);
			this.btnTransmit.TabIndex = 5;
			this.btnTransmit.Text = "Transmit";
			this.btnTransmit.UseVisualStyleBackColor = true;
			this.btnTransmit.Visible = false;
			this.btnTransmit.Click += new System.EventHandler(this.btnTransmit_Click);
			// 
			// txt300ToLINE
			// 
			this.txt300ToLINE.BackColor = System.Drawing.SystemColors.Control;
			this.txt300ToLINE.ForeColor = System.Drawing.Color.Black;
			this.txt300ToLINE.LinkDisabledMessage = "Link Disabled";
			this.txt300ToLINE.Location = new System.Drawing.Point(151, 75);
			this.txt300ToLINE.Name = "txt300ToLINE";
			this.txt300ToLINE.ReadOnly = true;
			this.txt300ToLINE.Size = new System.Drawing.Size(41, 20);
			this.txt300ToLINE.TabIndex = 6;
			this.txt300ToLINE.TabStop = false;
			this.txt300ToLINE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txt301ToSDDC
			// 
			this.txt301ToSDDC.BackColor = System.Drawing.SystemColors.Control;
			this.txt301ToSDDC.ForeColor = System.Drawing.Color.Black;
			this.txt301ToSDDC.LinkDisabledMessage = "Link Disabled";
			this.txt301ToSDDC.Location = new System.Drawing.Point(151, 100);
			this.txt301ToSDDC.Name = "txt301ToSDDC";
			this.txt301ToSDDC.ReadOnly = true;
			this.txt301ToSDDC.Size = new System.Drawing.Size(41, 20);
			this.txt301ToSDDC.TabIndex = 9;
			this.txt301ToSDDC.TabStop = false;
			this.txt301ToSDDC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txt315ToSDDC
			// 
			this.txt315ToSDDC.BackColor = System.Drawing.SystemColors.Control;
			this.txt315ToSDDC.ForeColor = System.Drawing.Color.Black;
			this.txt315ToSDDC.LinkDisabledMessage = "Link Disabled";
			this.txt315ToSDDC.Location = new System.Drawing.Point(151, 125);
			this.txt315ToSDDC.Name = "txt315ToSDDC";
			this.txt315ToSDDC.ReadOnly = true;
			this.txt315ToSDDC.Size = new System.Drawing.Size(41, 20);
			this.txt315ToSDDC.TabIndex = 10;
			this.txt315ToSDDC.TabStop = false;
			this.txt315ToSDDC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// groupOther
			// 
			this.groupOther.Controls.Add(this.txt304AAL);
			this.groupOther.Controls.Add(this.txt300ToLINE);
			this.groupOther.Controls.Add(this.txt304SDDC);
			this.groupOther.Controls.Add(this.txt315ToSDDC);
			this.groupOther.Controls.Add(this.cbx300ToLINE);
			this.groupOther.Controls.Add(this.cbxSDDC304);
			this.groupOther.Controls.Add(this.cbxAAL304);
			this.groupOther.Controls.Add(this.txt301ToSDDC);
			this.groupOther.Controls.Add(this.cbx301ToSDDC);
			this.groupOther.Controls.Add(this.cbx315ToSDDC);
			this.groupOther.Location = new System.Drawing.Point(13, 111);
			this.groupOther.Name = "groupOther";
			this.groupOther.Size = new System.Drawing.Size(289, 184);
			this.groupOther.TabIndex = 11;
			this.groupOther.TabStop = false;
			this.groupOther.Text = "Bookings and ITV";
			// 
			// backgroundWorker1
			// 
			this.backgroundWorker1.WorkerReportsProgress = true;
			this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
			this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
			this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
			// 
			// progressBar1
			// 
			this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.progressBar1.Location = new System.Drawing.Point(0, 334);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(325, 23);
			this.progressBar1.TabIndex = 13;
			this.progressBar1.Visible = false;
			// 
			// backgroundWorker2
			// 
			this.backgroundWorker2.WorkerReportsProgress = true;
			this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
			this.backgroundWorker2.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker2_ProgressChanged);
			this.backgroundWorker2.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker2_RunWorkerCompleted);
			// 
			// btnLaunchSDDCEDI
			// 
			this.btnLaunchSDDCEDI.Location = new System.Drawing.Point(13, 301);
			this.btnLaunchSDDCEDI.Name = "btnLaunchSDDCEDI";
			this.btnLaunchSDDCEDI.Size = new System.Drawing.Size(75, 23);
			this.btnLaunchSDDCEDI.TabIndex = 14;
			this.btnLaunchSDDCEDI.Text = "Transmit";
			this.btnLaunchSDDCEDI.UseVisualStyleBackColor = true;
			this.btnLaunchSDDCEDI.Click += new System.EventHandler(this.ucButton1_Click);
			// 
			// ucGroupBox1
			// 
			this.ucGroupBox1.Controls.Add(this.txtMessage);
			this.ucGroupBox1.Location = new System.Drawing.Point(13, 5);
			this.ucGroupBox1.Name = "ucGroupBox1";
			this.ucGroupBox1.Size = new System.Drawing.Size(289, 100);
			this.ucGroupBox1.TabIndex = 15;
			this.ucGroupBox1.TabStop = false;
			this.ucGroupBox1.Text = "Explanation";
			// 
			// txtMessage
			// 
			this.txtMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtMessage.Location = new System.Drawing.Point(11, 20);
			this.txtMessage.Multiline = true;
			this.txtMessage.Name = "txtMessage";
			this.txtMessage.ReadOnly = true;
			this.txtMessage.Size = new System.Drawing.Size(272, 70);
			this.txtMessage.TabIndex = 0;
			// 
			// cbxAAL304
			// 
			this.cbxAAL304.Enabled = false;
			this.cbxAAL304.Location = new System.Drawing.Point(16, 45);
			this.cbxAAL304.Name = "cbxAAL304";
			this.cbxAAL304.Size = new System.Drawing.Size(133, 24);
			this.cbxAAL304.TabIndex = 1;
			this.cbxAAL304.Text = "AAL 304\'s to LINE";
			this.cbxAAL304.UseVisualStyleBackColor = true;
			this.cbxAAL304.Visible = false;
			this.cbxAAL304.YN = "N";
			// 
			// cbxSDDC304
			// 
			this.cbxSDDC304.Location = new System.Drawing.Point(16, 19);
			this.cbxSDDC304.Name = "cbxSDDC304";
			this.cbxSDDC304.Size = new System.Drawing.Size(133, 24);
			this.cbxSDDC304.TabIndex = 0;
			this.cbxSDDC304.Text = "SDDC 304\'s to LINE";
			this.cbxSDDC304.UseVisualStyleBackColor = true;
			this.cbxSDDC304.YN = "N";
			// 
			// txt304SDDC
			// 
			this.txt304SDDC.BackColor = System.Drawing.SystemColors.Control;
			this.txt304SDDC.ForeColor = System.Drawing.Color.Black;
			this.txt304SDDC.LinkDisabledMessage = "Link Disabled";
			this.txt304SDDC.Location = new System.Drawing.Point(151, 21);
			this.txt304SDDC.Name = "txt304SDDC";
			this.txt304SDDC.ReadOnly = true;
			this.txt304SDDC.Size = new System.Drawing.Size(41, 20);
			this.txt304SDDC.TabIndex = 8;
			this.txt304SDDC.TabStop = false;
			this.txt304SDDC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txt304AAL
			// 
			this.txt304AAL.BackColor = System.Drawing.SystemColors.Control;
			this.txt304AAL.ForeColor = System.Drawing.Color.Black;
			this.txt304AAL.LinkDisabledMessage = "Link Disabled";
			this.txt304AAL.Location = new System.Drawing.Point(151, 47);
			this.txt304AAL.Name = "txt304AAL";
			this.txt304AAL.ReadOnly = true;
			this.txt304AAL.Size = new System.Drawing.Size(41, 20);
			this.txt304AAL.TabIndex = 7;
			this.txt304AAL.TabStop = false;
			this.txt304AAL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txt304AAL.Visible = false;
			// 
			// frmEDITransmit
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.ClientSize = new System.Drawing.Size(325, 357);
			this.Controls.Add(this.btnLaunchSDDCEDI);
			this.Controls.Add(this.progressBar1);
			this.Controls.Add(this.groupOther);
			this.Controls.Add(this.btnTransmit);
			this.Controls.Add(this.ucGroupBox1);
			this.Name = "frmEDITransmit";
			this.Text = "EDI Transmit On Demand";
			this.groupOther.ResumeLayout(false);
			this.groupOther.PerformLayout();
			this.ucGroupBox1.ResumeLayout(false);
			this.ucGroupBox1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private CommonWinCtrls.ucCheckBox cbx300ToLINE;
		private CommonWinCtrls.ucCheckBox cbx301ToSDDC;
		private CommonWinCtrls.ucCheckBox cbx315ToSDDC;
		private CommonWinCtrls.ucButton btnTransmit;
		private CommonWinCtrls.ucTextBox txt300ToLINE;
		private CommonWinCtrls.ucTextBox txt301ToSDDC;
		private CommonWinCtrls.ucTextBox txt315ToSDDC;
		private CommonWinCtrls.ucGroupBox groupOther;
		private System.ComponentModel.BackgroundWorker backgroundWorker1;
		private System.Windows.Forms.ProgressBar progressBar1;
		private System.ComponentModel.BackgroundWorker backgroundWorker2;
		private CommonWinCtrls.ucButton btnLaunchSDDCEDI;
		private CommonWinCtrls.ucGroupBox ucGroupBox1;
		private System.Windows.Forms.TextBox txtMessage;
		private CommonWinCtrls.ucTextBox txt304AAL;
		private CommonWinCtrls.ucTextBox txt304SDDC;
		private CommonWinCtrls.ucCheckBox cbxSDDC304;
		private CommonWinCtrls.ucCheckBox cbxAAL304;
	}
}
