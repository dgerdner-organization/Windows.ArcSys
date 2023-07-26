namespace CS2010.ArcSys.Win
{
	partial class frmEditStenaRoutes
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
			Janus.Windows.GridEX.GridEXLayout grdMain_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			Janus.Windows.GridEX.GridEXLayout cmbPOL_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			Janus.Windows.GridEX.GridEXLayout cmbPOD_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditStenaRoutes));
			this.ucPanel1 = new CS2010.CommonWinCtrls.ucPanel();
			this.grdMain = new CS2010.CommonWinCtrls.ucGridEx();
			this.cmbPOL = new CS2010.ArcSys.WinCtrls.ucLocationCombo();
			this.cmbPOD = new CS2010.ArcSys.WinCtrls.ucLocationCombo();
			this.txtRouteCd = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtDescription = new CS2010.CommonWinCtrls.ucTextBox();
			this.btnEdit = new CS2010.CommonWinCtrls.ucButton();
			this.btnSave = new CS2010.CommonWinCtrls.ucButton();
			this.btnCancel = new CS2010.CommonWinCtrls.ucButton();
			this.btnNew = new CS2010.CommonWinCtrls.ucButton();
			this.ucPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdMain)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbPOL)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbPOD)).BeginInit();
			this.SuspendLayout();
			// 
			// ucPanel1
			// 
			this.ucPanel1.Controls.Add(this.btnNew);
			this.ucPanel1.Controls.Add(this.btnCancel);
			this.ucPanel1.Controls.Add(this.btnSave);
			this.ucPanel1.Controls.Add(this.btnEdit);
			this.ucPanel1.Controls.Add(this.txtDescription);
			this.ucPanel1.Controls.Add(this.txtRouteCd);
			this.ucPanel1.Controls.Add(this.cmbPOD);
			this.ucPanel1.Controls.Add(this.cmbPOL);
			this.ucPanel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.ucPanel1.Location = new System.Drawing.Point(0, 0);
			this.ucPanel1.Name = "ucPanel1";
			this.ucPanel1.Size = new System.Drawing.Size(782, 150);
			this.ucPanel1.TabIndex = 0;
			// 
			// grdMain
			// 
			grdMain_DesignTimeLayout.LayoutString = resources.GetString("grdMain_DesignTimeLayout.LayoutString");
			this.grdMain.DesignTimeLayout = grdMain_DesignTimeLayout;
			this.grdMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grdMain.ExportFileID = null;
			this.grdMain.Location = new System.Drawing.Point(0, 150);
			this.grdMain.Name = "grdMain";
			this.grdMain.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
			this.grdMain.Size = new System.Drawing.Size(782, 346);
			this.grdMain.TabIndex = 1;
			this.grdMain.SelectionChanged += new System.EventHandler(this.grdMain_SelectionChanged);
			// 
			// cmbPOL
			// 
			this.cmbPOL.CodeColumn = "Location_Cd";
			this.cmbPOL.DescriptionColumn = "Location_Dsc";
			cmbPOL_DesignTimeLayout.LayoutString = resources.GetString("cmbPOL_DesignTimeLayout.LayoutString");
			this.cmbPOL.DesignTimeLayout = cmbPOL_DesignTimeLayout;
			this.cmbPOL.DisplayMember = "Location_Dsc";
			this.cmbPOL.DisplayType = CS2010.CommonWinCtrls.ComboDisplay.DescriptionOnly;
			this.cmbPOL.LabelText = "POL";
			this.cmbPOL.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.cmbPOL.Location = new System.Drawing.Point(100, 13);
			this.cmbPOL.Name = "cmbPOL";
			this.cmbPOL.SelectedIndex = -1;
			this.cmbPOL.SelectedItem = null;
			this.cmbPOL.Size = new System.Drawing.Size(178, 20);
			this.cmbPOL.SortType = CS2010.CommonWinCtrls.ComboSortType.Description;
			this.cmbPOL.TabIndex = 0;
			this.cmbPOL.ValueColumn = "Location_Cd";
			this.cmbPOL.ValueMember = "Location_Cd";
			// 
			// cmbPOD
			// 
			this.cmbPOD.CodeColumn = "Location_Cd";
			this.cmbPOD.DescriptionColumn = "Location_Dsc";
			cmbPOD_DesignTimeLayout.LayoutString = resources.GetString("cmbPOD_DesignTimeLayout.LayoutString");
			this.cmbPOD.DesignTimeLayout = cmbPOD_DesignTimeLayout;
			this.cmbPOD.DisplayMember = "Location_Dsc";
			this.cmbPOD.DisplayType = CS2010.CommonWinCtrls.ComboDisplay.DescriptionOnly;
			this.cmbPOD.LabelText = "POD";
			this.cmbPOD.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.cmbPOD.Location = new System.Drawing.Point(100, 39);
			this.cmbPOD.Name = "cmbPOD";
			this.cmbPOD.SelectedIndex = -1;
			this.cmbPOD.SelectedItem = null;
			this.cmbPOD.Size = new System.Drawing.Size(178, 20);
			this.cmbPOD.SortType = CS2010.CommonWinCtrls.ComboSortType.Description;
			this.cmbPOD.TabIndex = 1;
			this.cmbPOD.ValueColumn = "Location_Cd";
			this.cmbPOD.ValueMember = "Location_Cd";
			// 
			// txtRouteCd
			// 
			this.txtRouteCd.LabelText = "Stena Route Code";
			this.txtRouteCd.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtRouteCd.LinkDisabledMessage = "Link Disabled";
			this.txtRouteCd.Location = new System.Drawing.Point(100, 66);
			this.txtRouteCd.Name = "txtRouteCd";
			this.txtRouteCd.Size = new System.Drawing.Size(77, 20);
			this.txtRouteCd.TabIndex = 2;
			// 
			// txtDescription
			// 
			this.txtDescription.LabelText = "Description";
			this.txtDescription.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtDescription.LinkDisabledMessage = "Link Disabled";
			this.txtDescription.Location = new System.Drawing.Point(100, 92);
			this.txtDescription.Name = "txtDescription";
			this.txtDescription.Size = new System.Drawing.Size(178, 20);
			this.txtDescription.TabIndex = 3;
			// 
			// btnEdit
			// 
			this.btnEdit.Location = new System.Drawing.Point(100, 119);
			this.btnEdit.Name = "btnEdit";
			this.btnEdit.Size = new System.Drawing.Size(75, 23);
			this.btnEdit.TabIndex = 4;
			this.btnEdit.Text = "Edit";
			this.btnEdit.UseVisualStyleBackColor = true;
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(182, 119);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(75, 23);
			this.btnSave.TabIndex = 5;
			this.btnSave.Text = "Save";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(264, 119);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 6;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnNew
			// 
			this.btnNew.Location = new System.Drawing.Point(699, 118);
			this.btnNew.Name = "btnNew";
			this.btnNew.Size = new System.Drawing.Size(75, 23);
			this.btnNew.TabIndex = 7;
			this.btnNew.Text = "New";
			this.btnNew.UseVisualStyleBackColor = true;
			this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
			// 
			// frmEditStenaRoutes
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.ClientSize = new System.Drawing.Size(782, 496);
			this.Controls.Add(this.grdMain);
			this.Controls.Add(this.ucPanel1);
			this.Name = "frmEditStenaRoutes";
			this.Text = "Edit Stena Routes";
			this.ucPanel1.ResumeLayout(false);
			this.ucPanel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdMain)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbPOL)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cmbPOD)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private CommonWinCtrls.ucPanel ucPanel1;
		private CommonWinCtrls.ucGridEx grdMain;
		private CommonWinCtrls.ucTextBox txtDescription;
		private CommonWinCtrls.ucTextBox txtRouteCd;
		private WinCtrls.ucLocationCombo cmbPOD;
		private WinCtrls.ucLocationCombo cmbPOL;
		private CommonWinCtrls.ucButton btnNew;
		private CommonWinCtrls.ucButton btnCancel;
		private CommonWinCtrls.ucButton btnSave;
		private CommonWinCtrls.ucButton btnEdit;
	}
}
