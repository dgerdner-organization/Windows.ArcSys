namespace JobScheduler
{
	partial class frmMain
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
			this.components = new System.ComponentModel.Container();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.txtLog = new System.Windows.Forms.TextBox();
			this.button3 = new System.Windows.Forms.Button();
			this.grdScanFolders = new System.Windows.Forms.DataGridView();
			this.grdJobs = new System.Windows.Forms.DataGridView();
			this.iDDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.jobTypeCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clsJobBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.folderNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.jobIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.scanFrequencyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.logFileDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clsScanFolderBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.clsJobSchedulerBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.clsJobSchedulerBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
			this.clsJobSchedulerBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
			((System.ComponentModel.ISupportInitialize)(this.grdScanFolders)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grdJobs)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.clsJobBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.clsScanFolderBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.clsJobSchedulerBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.clsJobSchedulerBindingSource1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.clsJobSchedulerBindingSource2)).BeginInit();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(13, 23);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 0;
			this.button1.Text = "Start";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Enabled = false;
			this.button2.Location = new System.Drawing.Point(107, 23);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 1;
			this.button2.Text = "Stop";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// txtLog
			// 
			this.txtLog.Location = new System.Drawing.Point(12, 52);
			this.txtLog.Multiline = true;
			this.txtLog.Name = "txtLog";
			this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtLog.Size = new System.Drawing.Size(777, 220);
			this.txtLog.TabIndex = 5;
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(246, 23);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(75, 23);
			this.button3.TabIndex = 6;
			this.button3.Text = "button3";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// grdScanFolders
			// 
			this.grdScanFolders.AutoGenerateColumns = false;
			this.grdScanFolders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.grdScanFolders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.folderNameDataGridViewTextBoxColumn,
            this.jobIDDataGridViewTextBoxColumn,
            this.scanFrequencyDataGridViewTextBoxColumn,
            this.logFileDataGridViewTextBoxColumn});
			this.grdScanFolders.DataSource = this.clsScanFolderBindingSource;
			this.grdScanFolders.Location = new System.Drawing.Point(13, 278);
			this.grdScanFolders.Name = "grdScanFolders";
			this.grdScanFolders.Size = new System.Drawing.Size(776, 127);
			this.grdScanFolders.TabIndex = 8;
			// 
			// grdJobs
			// 
			this.grdJobs.AutoGenerateColumns = false;
			this.grdJobs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.grdJobs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn1,
            this.nameDataGridViewTextBoxColumn,
            this.jobTypeCodeDataGridViewTextBoxColumn});
			this.grdJobs.DataSource = this.clsJobBindingSource;
			this.grdJobs.Location = new System.Drawing.Point(13, 411);
			this.grdJobs.Name = "grdJobs";
			this.grdJobs.Size = new System.Drawing.Size(776, 130);
			this.grdJobs.TabIndex = 9;
			// 
			// iDDataGridViewTextBoxColumn1
			// 
			this.iDDataGridViewTextBoxColumn1.DataPropertyName = "ID";
			this.iDDataGridViewTextBoxColumn1.HeaderText = "ID";
			this.iDDataGridViewTextBoxColumn1.Name = "iDDataGridViewTextBoxColumn1";
			// 
			// nameDataGridViewTextBoxColumn
			// 
			this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
			this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
			this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
			// 
			// jobTypeCodeDataGridViewTextBoxColumn
			// 
			this.jobTypeCodeDataGridViewTextBoxColumn.DataPropertyName = "JobType_Code";
			this.jobTypeCodeDataGridViewTextBoxColumn.HeaderText = "JobType_Code";
			this.jobTypeCodeDataGridViewTextBoxColumn.Name = "jobTypeCodeDataGridViewTextBoxColumn";
			// 
			// clsJobBindingSource
			// 
			this.clsJobBindingSource.DataSource = typeof(JobScheduler.ClsJob);
			// 
			// iDDataGridViewTextBoxColumn
			// 
			this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
			this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
			this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
			this.iDDataGridViewTextBoxColumn.Width = 40;
			// 
			// folderNameDataGridViewTextBoxColumn
			// 
			this.folderNameDataGridViewTextBoxColumn.DataPropertyName = "FolderName";
			this.folderNameDataGridViewTextBoxColumn.HeaderText = "FolderName";
			this.folderNameDataGridViewTextBoxColumn.Name = "folderNameDataGridViewTextBoxColumn";
			this.folderNameDataGridViewTextBoxColumn.Width = 200;
			// 
			// jobIDDataGridViewTextBoxColumn
			// 
			this.jobIDDataGridViewTextBoxColumn.DataPropertyName = "JobID";
			this.jobIDDataGridViewTextBoxColumn.HeaderText = "JobID";
			this.jobIDDataGridViewTextBoxColumn.Name = "jobIDDataGridViewTextBoxColumn";
			this.jobIDDataGridViewTextBoxColumn.Width = 40;
			// 
			// scanFrequencyDataGridViewTextBoxColumn
			// 
			this.scanFrequencyDataGridViewTextBoxColumn.DataPropertyName = "ScanFrequency";
			this.scanFrequencyDataGridViewTextBoxColumn.HeaderText = "ScanFrequency";
			this.scanFrequencyDataGridViewTextBoxColumn.Name = "scanFrequencyDataGridViewTextBoxColumn";
			this.scanFrequencyDataGridViewTextBoxColumn.Width = 50;
			// 
			// logFileDataGridViewTextBoxColumn
			// 
			this.logFileDataGridViewTextBoxColumn.DataPropertyName = "LogFile";
			this.logFileDataGridViewTextBoxColumn.HeaderText = "LogFile";
			this.logFileDataGridViewTextBoxColumn.Name = "logFileDataGridViewTextBoxColumn";
			this.logFileDataGridViewTextBoxColumn.ReadOnly = true;
			this.logFileDataGridViewTextBoxColumn.Width = 200;
			// 
			// clsScanFolderBindingSource
			// 
			this.clsScanFolderBindingSource.DataSource = typeof(JobScheduler.ClsScanFolder);
			// 
			// clsJobSchedulerBindingSource
			// 
			this.clsJobSchedulerBindingSource.DataSource = typeof(JobScheduler.ClsJobScheduler);
			// 
			// clsJobSchedulerBindingSource1
			// 
			this.clsJobSchedulerBindingSource1.DataSource = typeof(JobScheduler.ClsJobScheduler);
			// 
			// clsJobSchedulerBindingSource2
			// 
			this.clsJobSchedulerBindingSource2.DataSource = typeof(JobScheduler.ClsJobScheduler);
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(808, 553);
			this.Controls.Add(this.grdJobs);
			this.Controls.Add(this.grdScanFolders);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.txtLog);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Name = "frmMain";
			this.Text = "Job Scheduler ";
			((System.ComponentModel.ISupportInitialize)(this.grdScanFolders)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grdJobs)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.clsJobBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.clsScanFolderBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.clsJobSchedulerBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.clsJobSchedulerBindingSource1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.clsJobSchedulerBindingSource2)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.TextBox txtLog;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.BindingSource clsJobSchedulerBindingSource;
		private System.Windows.Forms.BindingSource clsJobSchedulerBindingSource1;
		private System.Windows.Forms.DataGridView grdScanFolders;
		private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn folderNameDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn jobIDDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn scanFrequencyDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn logFileDataGridViewTextBoxColumn;
		private System.Windows.Forms.BindingSource clsScanFolderBindingSource;
		private System.Windows.Forms.BindingSource clsJobSchedulerBindingSource2;
		private System.Windows.Forms.DataGridView grdJobs;
		private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn1;
		private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn jobTypeCodeDataGridViewTextBoxColumn;
		private System.Windows.Forms.BindingSource clsJobBindingSource;
	}
}