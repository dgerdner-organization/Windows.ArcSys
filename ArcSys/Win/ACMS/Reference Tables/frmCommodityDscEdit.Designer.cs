namespace CS2010.ArcSys.Win
{
	partial class frmCommodityDscEdit
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCommodityDscEdit));
			this.grdMain = new CS2010.CommonWinCtrls.ucGridEx();
			this.ucPanel1 = new CS2010.CommonWinCtrls.ucPanel();
			this.grpEditEmail = new CS2010.CommonWinCtrls.ucGroupBox();
			this.cbxHide = new CS2010.CommonWinCtrls.ucCheckBox();
			this.txtCode = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtDescription = new CS2010.CommonWinCtrls.ucTextBox();
			this.btnCancel = new CS2010.CommonWinCtrls.ucButton();
			this.Save = new CS2010.CommonWinCtrls.ucButton();
			this.btnDelete = new CS2010.CommonWinCtrls.ucButton();
			this.btnEdit = new CS2010.CommonWinCtrls.ucButton();
			this.btnAdd = new CS2010.CommonWinCtrls.ucButton();
			((System.ComponentModel.ISupportInitialize)(this.grdMain)).BeginInit();
			this.ucPanel1.SuspendLayout();
			this.grpEditEmail.SuspendLayout();
			this.SuspendLayout();
			// 
			// grdMain
			// 
			this.grdMain.ColumnAutoResize = true;
			grdMain_DesignTimeLayout.LayoutString = resources.GetString("grdMain_DesignTimeLayout.LayoutString");
			this.grdMain.DesignTimeLayout = grdMain_DesignTimeLayout;
			this.grdMain.Dock = System.Windows.Forms.DockStyle.Left;
			this.grdMain.ExportFileID = null;
			this.grdMain.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
			this.grdMain.Location = new System.Drawing.Point(0, 0);
			this.grdMain.Name = "grdMain";
			this.grdMain.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
			this.grdMain.Size = new System.Drawing.Size(488, 597);
			this.grdMain.TabIndex = 0;
			this.grdMain.SelectionChanged += new System.EventHandler(this.grdMain_SelectionChanged);
			// 
			// ucPanel1
			// 
			this.ucPanel1.Controls.Add(this.grpEditEmail);
			this.ucPanel1.Controls.Add(this.btnDelete);
			this.ucPanel1.Controls.Add(this.btnEdit);
			this.ucPanel1.Controls.Add(this.btnAdd);
			this.ucPanel1.Location = new System.Drawing.Point(494, 12);
			this.ucPanel1.Name = "ucPanel1";
			this.ucPanel1.Size = new System.Drawing.Size(451, 164);
			this.ucPanel1.TabIndex = 1;
			// 
			// grpEditEmail
			// 
			this.grpEditEmail.Controls.Add(this.cbxHide);
			this.grpEditEmail.Controls.Add(this.txtCode);
			this.grpEditEmail.Controls.Add(this.txtDescription);
			this.grpEditEmail.Controls.Add(this.btnCancel);
			this.grpEditEmail.Controls.Add(this.Save);
			this.grpEditEmail.Enabled = false;
			this.grpEditEmail.Location = new System.Drawing.Point(10, 3);
			this.grpEditEmail.Name = "grpEditEmail";
			this.grpEditEmail.Size = new System.Drawing.Size(399, 117);
			this.grpEditEmail.TabIndex = 5;
			this.grpEditEmail.TabStop = false;
			this.grpEditEmail.Text = "Edit";
			// 
			// cbxHide
			// 
			this.cbxHide.Location = new System.Drawing.Point(73, 63);
			this.cbxHide.Name = "cbxHide";
			this.cbxHide.Size = new System.Drawing.Size(54, 24);
			this.cbxHide.TabIndex = 2;
			this.cbxHide.Text = "Hide?";
			this.cbxHide.UseVisualStyleBackColor = true;
			this.cbxHide.YN = "N";
			// 
			// txtCode
			// 
			this.txtCode.LabelText = "Code";
			this.txtCode.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtCode.LinkDisabledMessage = "Link Disabled";
			this.txtCode.Location = new System.Drawing.Point(73, 11);
			this.txtCode.Name = "txtCode";
			this.txtCode.Size = new System.Drawing.Size(81, 20);
			this.txtCode.TabIndex = 0;
			// 
			// txtDescription
			// 
			this.txtDescription.LabelText = "Description";
			this.txtDescription.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtDescription.LinkDisabledMessage = "Link Disabled";
			this.txtDescription.Location = new System.Drawing.Point(73, 34);
			this.txtDescription.Name = "txtDescription";
			this.txtDescription.Size = new System.Drawing.Size(320, 20);
			this.txtDescription.TabIndex = 1;
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(322, 60);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(71, 23);
			this.btnCancel.TabIndex = 4;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// Save
			// 
			this.Save.Location = new System.Drawing.Point(247, 60);
			this.Save.Name = "Save";
			this.Save.Size = new System.Drawing.Size(70, 23);
			this.Save.TabIndex = 3;
			this.Save.Text = "Save";
			this.Save.UseVisualStyleBackColor = true;
			this.Save.Click += new System.EventHandler(this.Save_Click);
			// 
			// btnDelete
			// 
			this.btnDelete.Location = new System.Drawing.Point(169, 125);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(75, 23);
			this.btnDelete.TabIndex = 8;
			this.btnDelete.Text = "Delete";
			this.btnDelete.UseVisualStyleBackColor = true;
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// btnEdit
			// 
			this.btnEdit.Location = new System.Drawing.Point(10, 126);
			this.btnEdit.Name = "btnEdit";
			this.btnEdit.Size = new System.Drawing.Size(75, 23);
			this.btnEdit.TabIndex = 6;
			this.btnEdit.Text = "Edit";
			this.btnEdit.UseVisualStyleBackColor = true;
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			// 
			// btnAdd
			// 
			this.btnAdd.Location = new System.Drawing.Point(89, 125);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(75, 23);
			this.btnAdd.TabIndex = 7;
			this.btnAdd.Text = "Add";
			this.btnAdd.UseVisualStyleBackColor = true;
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// frmCommodityDscEdit
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.ClientSize = new System.Drawing.Size(1064, 597);
			this.Controls.Add(this.grdMain);
			this.Controls.Add(this.ucPanel1);
			this.Name = "frmCommodityDscEdit";
			this.Text = "Commodity Codes";
			this.Load += new System.EventHandler(this.frmCargoTypeEdit_Load);
			((System.ComponentModel.ISupportInitialize)(this.grdMain)).EndInit();
			this.ucPanel1.ResumeLayout(false);
			this.grpEditEmail.ResumeLayout(false);
			this.grpEditEmail.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private CommonWinCtrls.ucGridEx grdMain;
		private CommonWinCtrls.ucPanel ucPanel1;
		private CommonWinCtrls.ucGroupBox grpEditEmail;
		private CommonWinCtrls.ucButton btnEdit;
		private CommonWinCtrls.ucButton btnCancel;
		private CommonWinCtrls.ucButton Save;
		private CommonWinCtrls.ucButton btnAdd;
		private CommonWinCtrls.ucButton btnDelete;
		private CommonWinCtrls.ucTextBox txtCode;
		private CommonWinCtrls.ucTextBox txtDescription;
		private CommonWinCtrls.ucCheckBox cbxHide;
	}
}
