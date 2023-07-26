namespace CS2010.ArcSys.Win
{
	partial class frmMailListEdit
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
			Janus.Windows.GridEX.GridEXLayout grdEmailList_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMailListEdit));
			Janus.Windows.GridEX.GridEXLayout grdEmails_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			this.grdEmailList = new CS2010.CommonWinCtrls.ucGridEx();
			this.ucPanel1 = new CS2010.CommonWinCtrls.ucPanel();
			this.grdEmails = new CS2010.CommonWinCtrls.ucGridEx();
			this.txtName = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtEmail = new CS2010.CommonWinCtrls.ucTextBox();
			this.grpEditEmail = new CS2010.CommonWinCtrls.ucGroupBox();
			this.btnEdit = new CS2010.CommonWinCtrls.ucButton();
			this.Save = new CS2010.CommonWinCtrls.ucButton();
			this.btnCancel = new CS2010.CommonWinCtrls.ucButton();
			this.btnAdd = new CS2010.CommonWinCtrls.ucButton();
			this.btnDelete = new CS2010.CommonWinCtrls.ucButton();
			((System.ComponentModel.ISupportInitialize)(this.grdEmailList)).BeginInit();
			this.ucPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdEmails)).BeginInit();
			this.grpEditEmail.SuspendLayout();
			this.SuspendLayout();
			// 
			// grdEmailList
			// 
			grdEmailList_DesignTimeLayout.LayoutString = resources.GetString("grdEmailList_DesignTimeLayout.LayoutString");
			this.grdEmailList.DesignTimeLayout = grdEmailList_DesignTimeLayout;
			this.grdEmailList.Dock = System.Windows.Forms.DockStyle.Left;
			this.grdEmailList.ExportFileID = null;
			this.grdEmailList.GroupByBoxVisible = false;
			this.grdEmailList.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
			this.grdEmailList.Location = new System.Drawing.Point(0, 0);
			this.grdEmailList.Name = "grdEmailList";
			this.grdEmailList.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
			this.grdEmailList.Size = new System.Drawing.Size(566, 99);
			this.grdEmailList.TabIndex = 0;
			this.grdEmailList.SelectionChanged += new System.EventHandler(this.grdEmailList_SelectionChanged);
			// 
			// ucPanel1
			// 
			this.ucPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.ucPanel1.Controls.Add(this.grdEmailList);
			this.ucPanel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.ucPanel1.Location = new System.Drawing.Point(0, 0);
			this.ucPanel1.Name = "ucPanel1";
			this.ucPanel1.Size = new System.Drawing.Size(1141, 103);
			this.ucPanel1.TabIndex = 1;
			// 
			// grdEmails
			// 
			grdEmails_DesignTimeLayout.LayoutString = resources.GetString("grdEmails_DesignTimeLayout.LayoutString");
			this.grdEmails.DesignTimeLayout = grdEmails_DesignTimeLayout;
			this.grdEmails.Dock = System.Windows.Forms.DockStyle.Left;
			this.grdEmails.ExportFileID = null;
			this.grdEmails.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.grdEmails.GroupByBoxVisible = false;
			this.grdEmails.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
			this.grdEmails.Location = new System.Drawing.Point(0, 103);
			this.grdEmails.Name = "grdEmails";
			this.grdEmails.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
			this.grdEmails.Size = new System.Drawing.Size(568, 393);
			this.grdEmails.TabIndex = 2;
			this.grdEmails.SelectionChanged += new System.EventHandler(this.grdEmails_SelectionChanged);
			// 
			// txtName
			// 
			this.txtName.LabelText = "Outlook Name";
			this.txtName.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtName.LinkDisabledMessage = "Link Disabled";
			this.txtName.Location = new System.Drawing.Point(90, 29);
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(432, 20);
			this.txtName.TabIndex = 3;
			// 
			// txtEmail
			// 
			this.txtEmail.LabelText = "Email Address";
			this.txtEmail.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtEmail.LinkDisabledMessage = "Link Disabled";
			this.txtEmail.Location = new System.Drawing.Point(90, 51);
			this.txtEmail.Name = "txtEmail";
			this.txtEmail.Size = new System.Drawing.Size(432, 20);
			this.txtEmail.TabIndex = 4;
			// 
			// grpEditEmail
			// 
			this.grpEditEmail.Controls.Add(this.btnCancel);
			this.grpEditEmail.Controls.Add(this.txtEmail);
			this.grpEditEmail.Controls.Add(this.Save);
			this.grpEditEmail.Controls.Add(this.txtName);
			this.grpEditEmail.Enabled = false;
			this.grpEditEmail.Location = new System.Drawing.Point(574, 109);
			this.grpEditEmail.Name = "grpEditEmail";
			this.grpEditEmail.Size = new System.Drawing.Size(528, 117);
			this.grpEditEmail.TabIndex = 5;
			this.grpEditEmail.TabStop = false;
			this.grpEditEmail.Text = "Edit Email";
			// 
			// btnEdit
			// 
			this.btnEdit.Location = new System.Drawing.Point(581, 233);
			this.btnEdit.Name = "btnEdit";
			this.btnEdit.Size = new System.Drawing.Size(75, 23);
			this.btnEdit.TabIndex = 6;
			this.btnEdit.Text = "Edit";
			this.btnEdit.UseVisualStyleBackColor = true;
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			// 
			// Save
			// 
			this.Save.Location = new System.Drawing.Point(368, 74);
			this.Save.Name = "Save";
			this.Save.Size = new System.Drawing.Size(75, 23);
			this.Save.TabIndex = 5;
			this.Save.Text = "Save";
			this.Save.UseVisualStyleBackColor = true;
			this.Save.Click += new System.EventHandler(this.Save_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(446, 74);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 6;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnAdd
			// 
			this.btnAdd.Location = new System.Drawing.Point(660, 232);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(75, 23);
			this.btnAdd.TabIndex = 7;
			this.btnAdd.Text = "Add";
			this.btnAdd.UseVisualStyleBackColor = true;
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// btnDelete
			// 
			this.btnDelete.Location = new System.Drawing.Point(740, 232);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(75, 23);
			this.btnDelete.TabIndex = 8;
			this.btnDelete.Text = "Delete";
			this.btnDelete.UseVisualStyleBackColor = true;
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// frmMailListEdit
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.ClientSize = new System.Drawing.Size(1141, 496);
			this.Controls.Add(this.btnDelete);
			this.Controls.Add(this.btnAdd);
			this.Controls.Add(this.btnEdit);
			this.Controls.Add(this.grdEmails);
			this.Controls.Add(this.ucPanel1);
			this.Controls.Add(this.grpEditEmail);
			this.Name = "frmMailListEdit";
			this.Text = "Maintain Mailing Lists";
			((System.ComponentModel.ISupportInitialize)(this.grdEmailList)).EndInit();
			this.ucPanel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.grdEmails)).EndInit();
			this.grpEditEmail.ResumeLayout(false);
			this.grpEditEmail.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private CommonWinCtrls.ucGridEx grdEmailList;
		private CommonWinCtrls.ucPanel ucPanel1;
		private CommonWinCtrls.ucGridEx grdEmails;
		private CommonWinCtrls.ucTextBox txtName;
		private CommonWinCtrls.ucTextBox txtEmail;
		private CommonWinCtrls.ucGroupBox grpEditEmail;
		private CommonWinCtrls.ucButton btnEdit;
		private CommonWinCtrls.ucButton btnCancel;
		private CommonWinCtrls.ucButton Save;
		private CommonWinCtrls.ucButton btnAdd;
		private CommonWinCtrls.ucButton btnDelete;
	}
}
