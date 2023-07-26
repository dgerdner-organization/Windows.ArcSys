namespace CS2010.AVSS.Win
{
	partial class frmUpdateMilitaryVoyage
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
			this.components = new System.ComponentModel.Container();
			Janus.Windows.GridEX.GridEXLayout grdPortCalls_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUpdateMilitaryVoyage));
			this.splitContainerMain = new CS2010.CommonWinCtrls.ucSplitContainer();
			this.ucGroupBox2 = new CS2010.CommonWinCtrls.ucGroupBox();
			this.txtFullVoyage = new CS2010.CommonWinCtrls.ucTextBox();
			this.btnSearch = new CS2010.CommonWinCtrls.ucButton();
			this.ucGroupBox1 = new CS2010.CommonWinCtrls.ucGroupBox();
			this.cmbMilVoy = new CS2010.CommonWinCtrls.ucComboBox();
			this.btnAddMilVoy = new CS2010.CommonWinCtrls.ucButton();
			this.btnAssignAll = new CS2010.CommonWinCtrls.ucButton();
			this.btnRemoveAll = new CS2010.CommonWinCtrls.ucButton();
			this.grdPortCalls = new CS2010.CommonWinCtrls.ucGridEx();
			this.btnDeleteMilitaryVoyage = new CS2010.CommonWinCtrls.ucButton();
			this.splitContainerMain.Panel1.SuspendLayout();
			this.splitContainerMain.Panel2.SuspendLayout();
			this.splitContainerMain.SuspendLayout();
			this.ucGroupBox2.SuspendLayout();
			this.ucGroupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdPortCalls)).BeginInit();
			this.SuspendLayout();
			// 
			// splitContainerMain
			// 
			this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainerMain.Location = new System.Drawing.Point(0, 0);
			this.splitContainerMain.Name = "splitContainerMain";
			this.splitContainerMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainerMain.Panel1
			// 
			this.splitContainerMain.Panel1.Controls.Add(this.ucGroupBox2);
			this.splitContainerMain.Panel1.Controls.Add(this.ucGroupBox1);
			// 
			// splitContainerMain.Panel2
			// 
			this.splitContainerMain.Panel2.Controls.Add(this.grdPortCalls);
			this.splitContainerMain.Size = new System.Drawing.Size(744, 509);
			this.splitContainerMain.SplitterDistance = 144;
			this.splitContainerMain.TabIndex = 0;
			// 
			// ucGroupBox2
			// 
			this.ucGroupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.ucGroupBox2.Controls.Add(this.txtFullVoyage);
			this.ucGroupBox2.Controls.Add(this.btnSearch);
			this.ucGroupBox2.Location = new System.Drawing.Point(5, 12);
			this.ucGroupBox2.Name = "ucGroupBox2";
			this.ucGroupBox2.Size = new System.Drawing.Size(727, 61);
			this.ucGroupBox2.TabIndex = 15;
			this.ucGroupBox2.TabStop = false;
			this.ucGroupBox2.Text = "Find Voyage";
			// 
			// txtFullVoyage
			// 
			this.txtFullVoyage.LabelText = "Voyage (TTvvv)";
			this.txtFullVoyage.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtFullVoyage.LinkDisabledMessage = "Link Disabled";
			this.txtFullVoyage.Location = new System.Drawing.Point(111, 23);
			this.txtFullVoyage.Name = "txtFullVoyage";
			this.txtFullVoyage.Size = new System.Drawing.Size(100, 20);
			this.txtFullVoyage.TabIndex = 0;
			// 
			// btnSearch
			// 
			this.btnSearch.Location = new System.Drawing.Point(217, 23);
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Size = new System.Drawing.Size(75, 23);
			this.btnSearch.TabIndex = 1;
			this.btnSearch.Text = "Search";
			this.btnSearch.UseVisualStyleBackColor = true;
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			// 
			// ucGroupBox1
			// 
			this.ucGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.ucGroupBox1.Controls.Add(this.btnDeleteMilitaryVoyage);
			this.ucGroupBox1.Controls.Add(this.cmbMilVoy);
			this.ucGroupBox1.Controls.Add(this.btnAddMilVoy);
			this.ucGroupBox1.Controls.Add(this.btnAssignAll);
			this.ucGroupBox1.Controls.Add(this.btnRemoveAll);
			this.ucGroupBox1.Location = new System.Drawing.Point(5, 76);
			this.ucGroupBox1.Name = "ucGroupBox1";
			this.ucGroupBox1.Size = new System.Drawing.Size(727, 59);
			this.ucGroupBox1.TabIndex = 14;
			this.ucGroupBox1.TabStop = false;
			// 
			// cmbMilVoy
			// 
			this.cmbMilVoy.DisplayMember = "military_voyage_no";
			this.cmbMilVoy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbMilVoy.FormattingEnabled = true;
			this.cmbMilVoy.LabelText = "Military Voyage";
			this.cmbMilVoy.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.cmbMilVoy.Location = new System.Drawing.Point(113, 21);
			this.cmbMilVoy.Name = "cmbMilVoy";
			this.cmbMilVoy.Size = new System.Drawing.Size(98, 21);
			this.cmbMilVoy.TabIndex = 11;
			this.cmbMilVoy.ValueMember = "military_voyage_no";
			// 
			// btnAddMilVoy
			// 
			this.btnAddMilVoy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAddMilVoy.Location = new System.Drawing.Point(437, 21);
			this.btnAddMilVoy.Name = "btnAddMilVoy";
			this.btnAddMilVoy.Size = new System.Drawing.Size(129, 23);
			this.btnAddMilVoy.TabIndex = 13;
			this.btnAddMilVoy.Text = "New Military Voyage...";
			this.btnAddMilVoy.UseVisualStyleBackColor = true;
			this.btnAddMilVoy.Click += new System.EventHandler(this.btnAddMilVoy_Click);
			// 
			// btnAssignAll
			// 
			this.btnAssignAll.Location = new System.Drawing.Point(217, 20);
			this.btnAssignAll.Name = "btnAssignAll";
			this.btnAssignAll.Size = new System.Drawing.Size(75, 23);
			this.btnAssignAll.TabIndex = 12;
			this.btnAssignAll.Text = "Assign";
			this.btnAssignAll.UseVisualStyleBackColor = true;
			this.btnAssignAll.Click += new System.EventHandler(this.btnAssignAll_Click);
			// 
			// btnRemoveAll
			// 
			this.btnRemoveAll.Location = new System.Drawing.Point(298, 20);
			this.btnRemoveAll.Name = "btnRemoveAll";
			this.btnRemoveAll.Size = new System.Drawing.Size(76, 23);
			this.btnRemoveAll.TabIndex = 2;
			this.btnRemoveAll.Text = "Remove";
			this.btnRemoveAll.UseVisualStyleBackColor = true;
			this.btnRemoveAll.Click += new System.EventHandler(this.btnRemoveAll_Click);
			// 
			// grdPortCalls
			// 
			grdPortCalls_DesignTimeLayout.LayoutString = resources.GetString("grdPortCalls_DesignTimeLayout.LayoutString");
			this.grdPortCalls.DesignTimeLayout = grdPortCalls_DesignTimeLayout;
			this.grdPortCalls.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grdPortCalls.ExportFileID = null;
			this.grdPortCalls.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.grdPortCalls.GroupByBoxVisible = false;
			this.grdPortCalls.Location = new System.Drawing.Point(0, 0);
			this.grdPortCalls.Name = "grdPortCalls";
			this.grdPortCalls.SelectionMode = Janus.Windows.GridEX.SelectionMode.MultipleSelection;
			this.grdPortCalls.Size = new System.Drawing.Size(744, 361);
			this.grdPortCalls.TabIndex = 0;
			this.grdPortCalls.DoubleClick += new System.EventHandler(this.grdPortCalls_DoubleClick);
			// 
			// btnDeleteMilitaryVoyage
			// 
			this.btnDeleteMilitaryVoyage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnDeleteMilitaryVoyage.Location = new System.Drawing.Point(572, 21);
			this.btnDeleteMilitaryVoyage.Name = "btnDeleteMilitaryVoyage";
			this.btnDeleteMilitaryVoyage.Size = new System.Drawing.Size(149, 23);
			this.btnDeleteMilitaryVoyage.TabIndex = 14;
			this.btnDeleteMilitaryVoyage.Text = "Delete Military Voyage...";
			this.btnDeleteMilitaryVoyage.UseVisualStyleBackColor = true;
			this.btnDeleteMilitaryVoyage.Click += new System.EventHandler(this.btnDeleteMilitaryVoyage_Click);
			// 
			// frmUpdateMilitaryVoyage
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.ClientSize = new System.Drawing.Size(744, 509);
			this.Controls.Add(this.splitContainerMain);
			this.Name = "frmUpdateMilitaryVoyage";
			this.Text = "Update Military Voyage Info";
			this.Load += new System.EventHandler(this.frmUpdateMilitaryVoyage_Load);
			this.splitContainerMain.Panel1.ResumeLayout(false);
			this.splitContainerMain.Panel2.ResumeLayout(false);
			this.splitContainerMain.ResumeLayout(false);
			this.ucGroupBox2.ResumeLayout(false);
			this.ucGroupBox2.PerformLayout();
			this.ucGroupBox1.ResumeLayout(false);
			this.ucGroupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdPortCalls)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private CS2010.CommonWinCtrls.ucSplitContainer splitContainerMain;
		private CS2010.CommonWinCtrls.ucButton btnSearch;
		private CS2010.CommonWinCtrls.ucTextBox txtFullVoyage;
		private CS2010.CommonWinCtrls.ucGridEx grdPortCalls;
		private CS2010.CommonWinCtrls.ucButton btnAssignAll;
		private CS2010.CommonWinCtrls.ucComboBox cmbMilVoy;
		private CS2010.CommonWinCtrls.ucButton btnRemoveAll;
		private CS2010.CommonWinCtrls.ucButton btnAddMilVoy;
		private CS2010.CommonWinCtrls.ucGroupBox ucGroupBox1;
		private CS2010.CommonWinCtrls.ucGroupBox ucGroupBox2;
		private CS2010.CommonWinCtrls.ucButton btnDeleteMilitaryVoyage;
	}
}
