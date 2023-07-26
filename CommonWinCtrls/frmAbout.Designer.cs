namespace CS2010.CommonWinCtrls
{
	partial class frmAbout
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
			this.btnOK = new System.Windows.Forms.Button();
			this.lstAssemblies = new System.Windows.Forms.ListView();
			this.hdrName = new System.Windows.Forms.ColumnHeader();
			this.hdrVersion = new System.Windows.Forms.ColumnHeader();
			this.lstDB = new System.Windows.Forms.ListView();
			this.hdrKey = new System.Windows.Forms.ColumnHeader();
			this.hdrServer = new System.Windows.Forms.ColumnHeader();
			this.hdrCatalog = new System.Windows.Forms.ColumnHeader();
			this.hdrProvider = new System.Windows.Forms.ColumnHeader();
			this.lblName = new System.Windows.Forms.Label();
			this.lblVersion = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left ) ) );
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnOK.Location = new System.Drawing.Point(197, 368);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 4;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			// 
			// lstAssemblies
			// 
			this.lstAssemblies.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.hdrName,
            this.hdrVersion});
			this.lstAssemblies.Dock = System.Windows.Forms.DockStyle.Top;
			this.lstAssemblies.FullRowSelect = true;
			this.lstAssemblies.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.lstAssemblies.Location = new System.Drawing.Point(0, 70);
			this.lstAssemblies.MultiSelect = false;
			this.lstAssemblies.Name = "lstAssemblies";
			this.lstAssemblies.Size = new System.Drawing.Size(469, 171);
			this.lstAssemblies.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.lstAssemblies.TabIndex = 2;
			this.lstAssemblies.UseCompatibleStateImageBehavior = false;
			this.lstAssemblies.View = System.Windows.Forms.View.Details;
			// 
			// hdrName
			// 
			this.hdrName.Text = "Name";
			this.hdrName.Width = 300;
			// 
			// hdrVersion
			// 
			this.hdrVersion.Text = "Version";
			this.hdrVersion.Width = 135;
			// 
			// lstDB
			// 
			this.lstDB.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.hdrKey,
            this.hdrServer,
            this.hdrCatalog,
            this.hdrProvider});
			this.lstDB.Dock = System.Windows.Forms.DockStyle.Top;
			this.lstDB.FullRowSelect = true;
			this.lstDB.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.lstDB.Location = new System.Drawing.Point(0, 241);
			this.lstDB.MultiSelect = false;
			this.lstDB.Name = "lstDB";
			this.lstDB.Size = new System.Drawing.Size(469, 115);
			this.lstDB.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.lstDB.TabIndex = 3;
			this.lstDB.UseCompatibleStateImageBehavior = false;
			this.lstDB.View = System.Windows.Forms.View.Details;
			// 
			// hdrKey
			// 
			this.hdrKey.Text = "DB Key";
			this.hdrKey.Width = 100;
			// 
			// hdrServer
			// 
			this.hdrServer.Text = "Source";
			this.hdrServer.Width = 100;
			// 
			// hdrCatalog
			// 
			this.hdrCatalog.Text = "Catalog";
			this.hdrCatalog.Width = 100;
			// 
			// hdrProvider
			// 
			this.hdrProvider.Text = "Provider";
			this.hdrProvider.Width = 135;
			// 
			// lblName
			// 
			this.lblName.Dock = System.Windows.Forms.DockStyle.Top;
			this.lblName.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ));
			this.lblName.Location = new System.Drawing.Point(0, 0);
			this.lblName.Name = "lblName";
			this.lblName.Size = new System.Drawing.Size(469, 40);
			this.lblName.TabIndex = 0;
			this.lblName.Text = "APPLICATION EXECUTABLE NAME";
			this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblVersion
			// 
			this.lblVersion.Dock = System.Windows.Forms.DockStyle.Top;
			this.lblVersion.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ));
			this.lblVersion.Location = new System.Drawing.Point(0, 40);
			this.lblVersion.Name = "lblVersion";
			this.lblVersion.Size = new System.Drawing.Size(469, 30);
			this.lblVersion.TabIndex = 1;
			this.lblVersion.Text = "Version: 0.0.0.0";
			this.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// frmAbout
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnOK;
			this.ClientSize = new System.Drawing.Size(469, 403);
			this.ControlBox = false;
			this.Controls.Add(this.lstDB);
			this.Controls.Add(this.lstAssemblies);
			this.Controls.Add(this.lblVersion);
			this.Controls.Add(this.lblName);
			this.Controls.Add(this.btnOK);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "frmAbout";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "About...";
			this.ResumeLayout(false);

		}

		#endregion

		protected System.Windows.Forms.Button btnOK;
		protected System.Windows.Forms.ListView lstAssemblies;
		protected System.Windows.Forms.ColumnHeader hdrName;
		protected System.Windows.Forms.ColumnHeader hdrVersion;
		protected System.Windows.Forms.ListView lstDB;
		protected System.Windows.Forms.ColumnHeader hdrServer;
		protected System.Windows.Forms.ColumnHeader hdrCatalog;
		protected System.Windows.Forms.ColumnHeader hdrProvider;
		protected System.Windows.Forms.Label lblName;
		protected System.Windows.Forms.Label lblVersion;
		protected System.Windows.Forms.ColumnHeader hdrKey;
	}
}