namespace CS2010.ArcSys.Win
{
	partial class frmBatchEDICreate
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
			Janus.Windows.GridEX.GridEXLayout grdCATmsg_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBatchEDICreate));
			Janus.Windows.GridEX.GridEXLayout grdNACmsg_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			this.btnCreateCAT = new CS2010.CommonWinCtrls.ucButton();
			this.ucCAT = new CS2010.CommonWinCtrls.ucGroupBox();
			this.btn323Map = new CS2010.CommonWinCtrls.ucButton();
			this.btnMap = new CS2010.CommonWinCtrls.ucButton();
			this.grdCATmsg = new CS2010.CommonWinCtrls.ucGridEx();
			this.lblCATmsg = new CS2010.CommonWinCtrls.ucLabel();
			this.ucGroupBox1 = new CS2010.CommonWinCtrls.ucGroupBox();
			this.btnRunMapNAC315 = new CS2010.CommonWinCtrls.ucButton();
			this.grdNACmsg = new CS2010.CommonWinCtrls.ucGridEx();
			this.lblNACmsg = new CS2010.CommonWinCtrls.ucLabel();
			this.btnCreateNAC = new CS2010.CommonWinCtrls.ucButton();
			this.ucCAT.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdCATmsg)).BeginInit();
			this.ucGroupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdNACmsg)).BeginInit();
			this.SuspendLayout();
			// 
			// btnCreateCAT
			// 
			this.btnCreateCAT.Location = new System.Drawing.Point(9, 19);
			this.btnCreateCAT.Name = "btnCreateCAT";
			this.btnCreateCAT.Size = new System.Drawing.Size(75, 23);
			this.btnCreateCAT.TabIndex = 0;
			this.btnCreateCAT.Text = "Create ITV";
			this.btnCreateCAT.UseVisualStyleBackColor = true;
			this.btnCreateCAT.Click += new System.EventHandler(this.btnCreateCAT_Click);
			// 
			// ucCAT
			// 
			this.ucCAT.Controls.Add(this.btn323Map);
			this.ucCAT.Controls.Add(this.btnMap);
			this.ucCAT.Controls.Add(this.grdCATmsg);
			this.ucCAT.Controls.Add(this.lblCATmsg);
			this.ucCAT.Controls.Add(this.btnCreateCAT);
			this.ucCAT.Location = new System.Drawing.Point(12, 12);
			this.ucCAT.Name = "ucCAT";
			this.ucCAT.Size = new System.Drawing.Size(346, 279);
			this.ucCAT.TabIndex = 1;
			this.ucCAT.TabStop = false;
			this.ucCAT.Text = "Caterpillar";
			// 
			// btn323Map
			// 
			this.btn323Map.Location = new System.Drawing.Point(9, 189);
			this.btn323Map.Name = "btn323Map";
			this.btn323Map.Size = new System.Drawing.Size(112, 23);
			this.btn323Map.TabIndex = 4;
			this.btn323Map.Text = "Run 323 Map";
			this.btn323Map.UseVisualStyleBackColor = true;
			this.btn323Map.Click += new System.EventHandler(this.btn323Map_Click);
			// 
			// btnMap
			// 
			this.btnMap.Location = new System.Drawing.Point(7, 160);
			this.btnMap.Name = "btnMap";
			this.btnMap.Size = new System.Drawing.Size(114, 23);
			this.btnMap.TabIndex = 3;
			this.btnMap.Text = "Run ITV Map";
			this.btnMap.UseVisualStyleBackColor = true;
			this.btnMap.Click += new System.EventHandler(this.btnMap_Click);
			// 
			// grdCATmsg
			// 
			this.grdCATmsg.AllowColumnDrag = false;
			this.grdCATmsg.ColumnHeaders = Janus.Windows.GridEX.InheritableBoolean.False;
			grdCATmsg_DesignTimeLayout.LayoutString = resources.GetString("grdCATmsg_DesignTimeLayout.LayoutString");
			this.grdCATmsg.DesignTimeLayout = grdCATmsg_DesignTimeLayout;
			this.grdCATmsg.ExportFileID = null;
			this.grdCATmsg.GroupByBoxVisible = false;
			this.grdCATmsg.Location = new System.Drawing.Point(6, 65);
			this.grdCATmsg.Name = "grdCATmsg";
			this.grdCATmsg.Size = new System.Drawing.Size(322, 88);
			this.grdCATmsg.TabIndex = 2;
			this.grdCATmsg.Visible = false;
			// 
			// lblCATmsg
			// 
			this.lblCATmsg.Location = new System.Drawing.Point(7, 49);
			this.lblCATmsg.Name = "lblCATmsg";
			this.lblCATmsg.Size = new System.Drawing.Size(114, 13);
			this.lblCATmsg.TabIndex = 1;
			this.lblCATmsg.Text = "No new ITV messages";
			// 
			// ucGroupBox1
			// 
			this.ucGroupBox1.Controls.Add(this.btnRunMapNAC315);
			this.ucGroupBox1.Controls.Add(this.grdNACmsg);
			this.ucGroupBox1.Controls.Add(this.lblNACmsg);
			this.ucGroupBox1.Controls.Add(this.btnCreateNAC);
			this.ucGroupBox1.Location = new System.Drawing.Point(364, 12);
			this.ucGroupBox1.Name = "ucGroupBox1";
			this.ucGroupBox1.Size = new System.Drawing.Size(346, 279);
			this.ucGroupBox1.TabIndex = 2;
			this.ucGroupBox1.TabStop = false;
			this.ucGroupBox1.Text = "NAC";
			// 
			// btnRunMapNAC315
			// 
			this.btnRunMapNAC315.Enabled = false;
			this.btnRunMapNAC315.Location = new System.Drawing.Point(7, 160);
			this.btnRunMapNAC315.Name = "btnRunMapNAC315";
			this.btnRunMapNAC315.Size = new System.Drawing.Size(89, 23);
			this.btnRunMapNAC315.TabIndex = 3;
			this.btnRunMapNAC315.Text = "Run 315 Map";
			this.btnRunMapNAC315.UseVisualStyleBackColor = true;
			this.btnRunMapNAC315.Click += new System.EventHandler(this.btnRunMapNAC315_Click);
			// 
			// grdNACmsg
			// 
			this.grdNACmsg.AllowColumnDrag = false;
			this.grdNACmsg.ColumnHeaders = Janus.Windows.GridEX.InheritableBoolean.False;
			grdNACmsg_DesignTimeLayout.LayoutString = resources.GetString("grdNACmsg_DesignTimeLayout.LayoutString");
			this.grdNACmsg.DesignTimeLayout = grdNACmsg_DesignTimeLayout;
			this.grdNACmsg.ExportFileID = null;
			this.grdNACmsg.GroupByBoxVisible = false;
			this.grdNACmsg.Location = new System.Drawing.Point(6, 65);
			this.grdNACmsg.Name = "grdNACmsg";
			this.grdNACmsg.Size = new System.Drawing.Size(322, 88);
			this.grdNACmsg.TabIndex = 2;
			this.grdNACmsg.Visible = false;
			// 
			// lblNACmsg
			// 
			this.lblNACmsg.Location = new System.Drawing.Point(7, 49);
			this.lblNACmsg.Name = "lblNACmsg";
			this.lblNACmsg.Size = new System.Drawing.Size(114, 13);
			this.lblNACmsg.TabIndex = 1;
			this.lblNACmsg.Text = "No new ITV messages";
			// 
			// btnCreateNAC
			// 
			this.btnCreateNAC.Location = new System.Drawing.Point(9, 19);
			this.btnCreateNAC.Name = "btnCreateNAC";
			this.btnCreateNAC.Size = new System.Drawing.Size(73, 23);
			this.btnCreateNAC.TabIndex = 0;
			this.btnCreateNAC.Text = "Create ITV";
			this.btnCreateNAC.UseVisualStyleBackColor = true;
			this.btnCreateNAC.Click += new System.EventHandler(this.btnCreateNAC_Click);
			// 
			// frmBatchEDICreate
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.ClientSize = new System.Drawing.Size(782, 496);
			this.Controls.Add(this.ucGroupBox1);
			this.Controls.Add(this.ucCAT);
			this.Name = "frmBatchEDICreate";
			this.Text = "Batch Create EDI";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.ucCAT.ResumeLayout(false);
			this.ucCAT.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdCATmsg)).EndInit();
			this.ucGroupBox1.ResumeLayout(false);
			this.ucGroupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdNACmsg)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private CommonWinCtrls.ucButton btnCreateCAT;
		private CommonWinCtrls.ucGroupBox ucCAT;
		private CommonWinCtrls.ucGridEx grdCATmsg;
		private CommonWinCtrls.ucLabel lblCATmsg;
		private CommonWinCtrls.ucButton btnMap;
		private CommonWinCtrls.ucButton btn323Map;
		private CommonWinCtrls.ucGroupBox ucGroupBox1;
		private CommonWinCtrls.ucButton btnRunMapNAC315;
		private CommonWinCtrls.ucGridEx grdNACmsg;
		private CommonWinCtrls.ucLabel lblNACmsg;
		private CommonWinCtrls.ucButton btnCreateNAC;
	}
}
