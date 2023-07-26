namespace CS2010.AVSS.Win
{
	partial class frmManageMilitaryVoyages
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
			if( disposing && (components != null) )
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
			Janus.Windows.GridEX.GridEXLayout grdUnassigned_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManageMilitaryVoyages));
			this.grdUnassigned = new CS2010.CommonWinCtrls.ucGridEx();
			this.ucLabel1 = new CS2010.CommonWinCtrls.ucLabel();
			this.rb360 = new System.Windows.Forms.RadioButton();
			this.rb720 = new System.Windows.Forms.RadioButton();
			this.rbAll = new System.Windows.Forms.RadioButton();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.rb180 = new System.Windows.Forms.RadioButton();
			((System.ComponentModel.ISupportInitialize)(this.grdUnassigned)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// grdUnassigned
			// 
			grdUnassigned_DesignTimeLayout.LayoutString = resources.GetString("grdUnassigned_DesignTimeLayout.LayoutString");
			this.grdUnassigned.DesignTimeLayout = grdUnassigned_DesignTimeLayout;
			this.grdUnassigned.Dock = System.Windows.Forms.DockStyle.Left;
			this.grdUnassigned.ExportFileID = null;
			this.grdUnassigned.GroupByBoxVisible = false;
			this.grdUnassigned.Location = new System.Drawing.Point(0, 24);
			this.grdUnassigned.Name = "grdUnassigned";
			this.grdUnassigned.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
			this.grdUnassigned.Size = new System.Drawing.Size(154, 472);
			this.grdUnassigned.TabIndex = 0;
			this.grdUnassigned.DoubleClick += new System.EventHandler(this.grdPortCalls_DoubleClick);
			// 
			// ucLabel1
			// 
			this.ucLabel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.ucLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ucLabel1.Location = new System.Drawing.Point(0, 0);
			this.ucLabel1.Name = "ucLabel1";
			this.ucLabel1.Size = new System.Drawing.Size(485, 24);
			this.ucLabel1.TabIndex = 1;
			this.ucLabel1.Text = "Voyages for which no military voyage has been assigned";
			this.ucLabel1.Click += new System.EventHandler(this.ucLabel1_Click);
			// 
			// rb360
			// 
			this.rb360.AutoSize = true;
			this.rb360.Location = new System.Drawing.Point(24, 39);
			this.rb360.Name = "rb360";
			this.rb360.Size = new System.Drawing.Size(68, 17);
			this.rb360.TabIndex = 2;
			this.rb360.Text = "One year";
			this.rb360.UseVisualStyleBackColor = true;
			this.rb360.CheckedChanged += new System.EventHandler(this.rb360_CheckedChanged);
			// 
			// rb720
			// 
			this.rb720.AutoSize = true;
			this.rb720.Location = new System.Drawing.Point(24, 58);
			this.rb720.Name = "rb720";
			this.rb720.Size = new System.Drawing.Size(74, 17);
			this.rb720.TabIndex = 3;
			this.rb720.Text = "Two years";
			this.rb720.UseVisualStyleBackColor = true;
			this.rb720.CheckedChanged += new System.EventHandler(this.rb720_CheckedChanged);
			// 
			// rbAll
			// 
			this.rbAll.AutoSize = true;
			this.rbAll.Location = new System.Drawing.Point(24, 76);
			this.rbAll.Name = "rbAll";
			this.rbAll.Size = new System.Drawing.Size(36, 17);
			this.rbAll.TabIndex = 4;
			this.rbAll.Text = "All";
			this.rbAll.UseVisualStyleBackColor = true;
			this.rbAll.CheckedChanged += new System.EventHandler(this.rbAll_CheckedChanged);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.rbAll);
			this.groupBox1.Controls.Add(this.rb180);
			this.groupBox1.Controls.Add(this.rb720);
			this.groupBox1.Controls.Add(this.rb360);
			this.groupBox1.Location = new System.Drawing.Point(160, 24);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(190, 110);
			this.groupBox1.TabIndex = 5;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Voyage departing within last";
			// 
			// rb180
			// 
			this.rb180.AutoSize = true;
			this.rb180.Checked = true;
			this.rb180.Location = new System.Drawing.Point(24, 22);
			this.rb180.Name = "rb180";
			this.rb180.Size = new System.Drawing.Size(76, 17);
			this.rb180.TabIndex = 6;
			this.rb180.TabStop = true;
			this.rb180.Text = "Six months";
			this.rb180.UseVisualStyleBackColor = true;
			this.rb180.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
			// 
			// frmManageMilitaryVoyages
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.ClientSize = new System.Drawing.Size(782, 496);
			this.Controls.Add(this.grdUnassigned);
			this.Controls.Add(this.ucLabel1);
			this.Controls.Add(this.groupBox1);
			this.Name = "frmManageMilitaryVoyages";
			this.Text = "Manage Military Voyages";
			this.Load += new System.EventHandler(this.frmUpdateMilitaryVoyage_Load);
			((System.ComponentModel.ISupportInitialize)(this.grdUnassigned)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private CS2010.CommonWinCtrls.ucGridEx grdUnassigned;
		private CS2010.CommonWinCtrls.ucLabel ucLabel1;
		private System.Windows.Forms.RadioButton rb360;
		private System.Windows.Forms.RadioButton rb720;
		private System.Windows.Forms.RadioButton rbAll;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton rb180;
	}
}
