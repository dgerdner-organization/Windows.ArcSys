namespace CS2010.ArcSys.Win
{
	partial class frmCargoTypeEdit
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCargoTypeEdit));
			this.grdMain = new CS2010.CommonWinCtrls.ucGridEx();
			this.ucPanel1 = new CS2010.CommonWinCtrls.ucPanel();
			this.grpEditEmail = new CS2010.CommonWinCtrls.ucGroupBox();
			this.txtStenaCd = new CS2010.CommonWinCtrls.ucTextBox();
			this.cmbWWLType = new CS2010.CommonWinCtrls.ucComboBox();
			this.cmbType = new CS2010.CommonWinCtrls.ucComboBox();
			this.ucLabel1 = new CS2010.CommonWinCtrls.ucLabel();
			this.txtYear = new CS2010.CommonWinCtrls.ucNumericEditBox();
			this.txtWeight = new CS2010.CommonWinCtrls.ucNumericEditBox();
			this.txtWidth = new CS2010.CommonWinCtrls.ucNumericEditBox();
			this.txtHeight = new CS2010.CommonWinCtrls.ucNumericEditBox();
			this.txtLength = new CS2010.CommonWinCtrls.ucNumericEditBox();
			this.txtModel = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtMake = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtCode = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtDescription = new CS2010.CommonWinCtrls.ucTextBox();
			this.btnCancel = new CS2010.CommonWinCtrls.ucButton();
			this.Save = new CS2010.CommonWinCtrls.ucButton();
			this.btnDelete = new CS2010.CommonWinCtrls.ucButton();
			this.btnEdit = new CS2010.CommonWinCtrls.ucButton();
			this.btnAdd = new CS2010.CommonWinCtrls.ucButton();
			this.cbxHide = new CS2010.CommonWinCtrls.ucCheckBox();
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
			this.grdMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grdMain.ExportFileID = null;
			this.grdMain.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
			this.grdMain.Location = new System.Drawing.Point(0, 0);
			this.grdMain.Name = "grdMain";
			this.grdMain.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
			this.grdMain.Size = new System.Drawing.Size(1064, 433);
			this.grdMain.TabIndex = 0;
			this.grdMain.SelectionChanged += new System.EventHandler(this.grdMain_SelectionChanged);
			// 
			// ucPanel1
			// 
			this.ucPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.ucPanel1.Controls.Add(this.grpEditEmail);
			this.ucPanel1.Controls.Add(this.btnDelete);
			this.ucPanel1.Controls.Add(this.btnEdit);
			this.ucPanel1.Controls.Add(this.btnAdd);
			this.ucPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.ucPanel1.Location = new System.Drawing.Point(0, 433);
			this.ucPanel1.Name = "ucPanel1";
			this.ucPanel1.Size = new System.Drawing.Size(1064, 164);
			this.ucPanel1.TabIndex = 1;
			// 
			// grpEditEmail
			// 
			this.grpEditEmail.Controls.Add(this.cbxHide);
			this.grpEditEmail.Controls.Add(this.txtStenaCd);
			this.grpEditEmail.Controls.Add(this.cmbWWLType);
			this.grpEditEmail.Controls.Add(this.cmbType);
			this.grpEditEmail.Controls.Add(this.ucLabel1);
			this.grpEditEmail.Controls.Add(this.txtYear);
			this.grpEditEmail.Controls.Add(this.txtWeight);
			this.grpEditEmail.Controls.Add(this.txtWidth);
			this.grpEditEmail.Controls.Add(this.txtHeight);
			this.grpEditEmail.Controls.Add(this.txtLength);
			this.grpEditEmail.Controls.Add(this.txtModel);
			this.grpEditEmail.Controls.Add(this.txtMake);
			this.grpEditEmail.Controls.Add(this.txtCode);
			this.grpEditEmail.Controls.Add(this.txtDescription);
			this.grpEditEmail.Controls.Add(this.btnCancel);
			this.grpEditEmail.Controls.Add(this.Save);
			this.grpEditEmail.Enabled = false;
			this.grpEditEmail.Location = new System.Drawing.Point(10, 3);
			this.grpEditEmail.Name = "grpEditEmail";
			this.grpEditEmail.Size = new System.Drawing.Size(753, 117);
			this.grpEditEmail.TabIndex = 5;
			this.grpEditEmail.TabStop = false;
			this.grpEditEmail.Text = "Edit";
			// 
			// txtStenaCd
			// 
			this.txtStenaCd.LabelText = "STENA Code";
			this.txtStenaCd.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtStenaCd.LinkDisabledMessage = "Link Disabled";
			this.txtStenaCd.Location = new System.Drawing.Point(491, 83);
			this.txtStenaCd.MaxLength = 8;
			this.txtStenaCd.Name = "txtStenaCd";
			this.txtStenaCd.Size = new System.Drawing.Size(59, 20);
			this.txtStenaCd.TabIndex = 19;
			// 
			// cmbWWLType
			// 
			this.cmbWWLType.FormattingEnabled = true;
			this.cmbWWLType.Items.AddRange(new object[] {
            "BLK",
            "UNT",
            "VEH"});
			this.cmbWWLType.LabelText = "WWL Type";
			this.cmbWWLType.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.cmbWWLType.Location = new System.Drawing.Point(491, 60);
			this.cmbWWLType.Name = "cmbWWLType";
			this.cmbWWLType.Size = new System.Drawing.Size(59, 21);
			this.cmbWWLType.TabIndex = 18;
			// 
			// cmbType
			// 
			this.cmbType.FormattingEnabled = true;
			this.cmbType.LabelText = "Cargo Type";
			this.cmbType.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.cmbType.Location = new System.Drawing.Point(491, 37);
			this.cmbType.Name = "cmbType";
			this.cmbType.Size = new System.Drawing.Size(59, 21);
			this.cmbType.TabIndex = 17;
			// 
			// ucLabel1
			// 
			this.ucLabel1.Location = new System.Drawing.Point(158, 84);
			this.ucLabel1.Name = "ucLabel1";
			this.ucLabel1.Size = new System.Drawing.Size(116, 13);
			this.ucLabel1.TabIndex = 16;
			this.ucLabel1.Text = "(Max 8-chars per LINE)";
			// 
			// txtYear
			// 
			this.txtYear.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtYear.FormatString = "#0";
			this.txtYear.LabelText = "Year";
			this.txtYear.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtYear.Location = new System.Drawing.Point(491, 15);
			this.txtYear.MaxLength = 4;
			this.txtYear.Name = "txtYear";
			this.txtYear.Size = new System.Drawing.Size(59, 20);
			this.txtYear.TabIndex = 15;
			this.txtYear.Text = "0";
			this.txtYear.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
			// 
			// txtWeight
			// 
			this.txtWeight.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtWeight.LabelText = "Weight";
			this.txtWeight.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtWeight.Location = new System.Drawing.Point(347, 81);
			this.txtWeight.Name = "txtWeight";
			this.txtWeight.Size = new System.Drawing.Size(59, 20);
			this.txtWeight.TabIndex = 14;
			this.txtWeight.Text = "0.00";
			this.txtWeight.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
			// 
			// txtWidth
			// 
			this.txtWidth.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtWidth.LabelText = "Width";
			this.txtWidth.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtWidth.Location = new System.Drawing.Point(347, 59);
			this.txtWidth.Name = "txtWidth";
			this.txtWidth.Size = new System.Drawing.Size(59, 20);
			this.txtWidth.TabIndex = 13;
			this.txtWidth.Text = "0.00";
			this.txtWidth.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
			// 
			// txtHeight
			// 
			this.txtHeight.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtHeight.LabelText = "Height";
			this.txtHeight.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtHeight.Location = new System.Drawing.Point(347, 37);
			this.txtHeight.Name = "txtHeight";
			this.txtHeight.Size = new System.Drawing.Size(59, 20);
			this.txtHeight.TabIndex = 12;
			this.txtHeight.Text = "0.00";
			this.txtHeight.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
			// 
			// txtLength
			// 
			this.txtLength.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtLength.LabelText = "Length";
			this.txtLength.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtLength.Location = new System.Drawing.Point(347, 15);
			this.txtLength.Name = "txtLength";
			this.txtLength.Size = new System.Drawing.Size(59, 20);
			this.txtLength.TabIndex = 11;
			this.txtLength.Text = "0.00";
			this.txtLength.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
			// 
			// txtModel
			// 
			this.txtModel.LabelText = "Model";
			this.txtModel.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtModel.LinkDisabledMessage = "Link Disabled";
			this.txtModel.Location = new System.Drawing.Point(73, 81);
			this.txtModel.MaxLength = 8;
			this.txtModel.Name = "txtModel";
			this.txtModel.Size = new System.Drawing.Size(81, 20);
			this.txtModel.TabIndex = 10;
			// 
			// txtMake
			// 
			this.txtMake.LabelText = "Make";
			this.txtMake.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtMake.LinkDisabledMessage = "Link Disabled";
			this.txtMake.Location = new System.Drawing.Point(73, 59);
			this.txtMake.Name = "txtMake";
			this.txtMake.Size = new System.Drawing.Size(205, 20);
			this.txtMake.TabIndex = 9;
			// 
			// txtCode
			// 
			this.txtCode.LabelText = "Code";
			this.txtCode.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtCode.LinkDisabledMessage = "Link Disabled";
			this.txtCode.Location = new System.Drawing.Point(73, 37);
			this.txtCode.Name = "txtCode";
			this.txtCode.Size = new System.Drawing.Size(205, 20);
			this.txtCode.TabIndex = 8;
			// 
			// txtDescription
			// 
			this.txtDescription.LabelText = "Description";
			this.txtDescription.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtDescription.LinkDisabledMessage = "Link Disabled";
			this.txtDescription.Location = new System.Drawing.Point(73, 15);
			this.txtDescription.Name = "txtDescription";
			this.txtDescription.Size = new System.Drawing.Size(205, 20);
			this.txtDescription.TabIndex = 7;
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(664, 80);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 6;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// Save
			// 
			this.Save.Location = new System.Drawing.Point(586, 80);
			this.Save.Name = "Save";
			this.Save.Size = new System.Drawing.Size(75, 23);
			this.Save.TabIndex = 5;
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
			// cbxHide
			// 
			this.cbxHide.Location = new System.Drawing.Point(586, 13);
			this.cbxHide.Name = "cbxHide";
			this.cbxHide.Size = new System.Drawing.Size(104, 24);
			this.cbxHide.TabIndex = 20;
			this.cbxHide.Text = "Hide?";
			this.cbxHide.UseVisualStyleBackColor = true;
			this.cbxHide.YN = "N";
			// 
			// frmCargoTypeEdit
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.ClientSize = new System.Drawing.Size(1064, 597);
			this.Controls.Add(this.grdMain);
			this.Controls.Add(this.ucPanel1);
			this.Name = "frmCargoTypeEdit";
			this.Text = "Cargo Types";
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
		private CommonWinCtrls.ucTextBox txtModel;
		private CommonWinCtrls.ucTextBox txtMake;
		private CommonWinCtrls.ucTextBox txtCode;
		private CommonWinCtrls.ucTextBox txtDescription;
		private CommonWinCtrls.ucNumericEditBox txtYear;
		private CommonWinCtrls.ucNumericEditBox txtWeight;
		private CommonWinCtrls.ucNumericEditBox txtWidth;
		private CommonWinCtrls.ucNumericEditBox txtHeight;
		private CommonWinCtrls.ucNumericEditBox txtLength;
		private CommonWinCtrls.ucTextBox txtStenaCd;
		private CommonWinCtrls.ucComboBox cmbWWLType;
		private CommonWinCtrls.ucComboBox cmbType;
		private CommonWinCtrls.ucLabel ucLabel1;
		private CommonWinCtrls.ucCheckBox cbxHide;
	}
}
