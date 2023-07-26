namespace CS2010.ArcSys.Win
{
	partial class frmSurchargeCodes
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
			Janus.Windows.GridEX.GridEXLayout grdCodes_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSurchargeCodes));
			this.btnNew = new CS2010.CommonWinCtrls.ucButton();
			this.grdCodes = new CS2010.CommonWinCtrls.ucGridEx();
			this.ucGroupBox1 = new CS2010.CommonWinCtrls.ucGroupBox();
			this.btnDelete = new CS2010.CommonWinCtrls.ucButton();
			this.txtSDDC = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtLINE = new CS2010.CommonWinCtrls.ucTextBox();
			this.btnSave = new CS2010.CommonWinCtrls.ucButton();
			this.btnCancel = new CS2010.CommonWinCtrls.ucButton();
			((System.ComponentModel.ISupportInitialize)(this.grdCodes)).BeginInit();
			this.ucGroupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnNew
			// 
			this.btnNew.Location = new System.Drawing.Point(282, 8);
			this.btnNew.Name = "btnNew";
			this.btnNew.Size = new System.Drawing.Size(75, 23);
			this.btnNew.TabIndex = 4;
			this.btnNew.Text = "New";
			this.btnNew.UseVisualStyleBackColor = true;
			this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
			// 
			// grdCodes
			// 
			grdCodes_DesignTimeLayout.LayoutString = resources.GetString("grdCodes_DesignTimeLayout.LayoutString");
			this.grdCodes.DesignTimeLayout = grdCodes_DesignTimeLayout;
			this.grdCodes.Dock = System.Windows.Forms.DockStyle.Left;
			this.grdCodes.ExportFileID = null;
			this.grdCodes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.grdCodes.GroupByBoxVisible = false;
			this.grdCodes.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
			this.grdCodes.Location = new System.Drawing.Point(0, 0);
			this.grdCodes.Name = "grdCodes";
			this.grdCodes.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
			this.grdCodes.Size = new System.Drawing.Size(275, 655);
			this.grdCodes.TabIndex = 0;
			this.grdCodes.SelectionChanged += new System.EventHandler(this.grdCodes_SelectionChanged);
			// 
			// ucGroupBox1
			// 
			this.ucGroupBox1.Controls.Add(this.btnCancel);
			this.ucGroupBox1.Controls.Add(this.btnDelete);
			this.ucGroupBox1.Controls.Add(this.txtSDDC);
			this.ucGroupBox1.Controls.Add(this.txtLINE);
			this.ucGroupBox1.Controls.Add(this.btnSave);
			this.ucGroupBox1.Location = new System.Drawing.Point(282, 53);
			this.ucGroupBox1.Name = "ucGroupBox1";
			this.ucGroupBox1.Size = new System.Drawing.Size(364, 129);
			this.ucGroupBox1.TabIndex = 5;
			this.ucGroupBox1.TabStop = false;
			this.ucGroupBox1.Text = "Update Translation";
			// 
			// btnDelete
			// 
			this.btnDelete.Location = new System.Drawing.Point(264, 86);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(75, 23);
			this.btnDelete.TabIndex = 4;
			this.btnDelete.Text = "Delete";
			this.btnDelete.UseVisualStyleBackColor = true;
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// txtSDDC
			// 
			this.txtSDDC.LabelText = "SDDC Code";
			this.txtSDDC.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtSDDC.LinkDisabledMessage = "Link Disabled";
			this.txtSDDC.Location = new System.Drawing.Point(97, 60);
			this.txtSDDC.Name = "txtSDDC";
			this.txtSDDC.Size = new System.Drawing.Size(71, 20);
			this.txtSDDC.TabIndex = 3;
			// 
			// txtLINE
			// 
			this.txtLINE.LabelText = "LINE Code";
			this.txtLINE.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
			this.txtLINE.LinkDisabledMessage = "Link Disabled";
			this.txtLINE.Location = new System.Drawing.Point(97, 34);
			this.txtLINE.Name = "txtLINE";
			this.txtLINE.Size = new System.Drawing.Size(71, 20);
			this.txtLINE.TabIndex = 2;
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(97, 86);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(75, 23);
			this.btnSave.TabIndex = 1;
			this.btnSave.Text = "Save";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.ucButton1_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(179, 86);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 5;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// frmSurchargeCodes
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(945, 655);
			this.Controls.Add(this.btnNew);
			this.Controls.Add(this.grdCodes);
			this.Controls.Add(this.ucGroupBox1);
			this.Name = "frmSurchargeCodes";
			this.Text = "frmSurchargeCodes";
			((System.ComponentModel.ISupportInitialize)(this.grdCodes)).EndInit();
			this.ucGroupBox1.ResumeLayout(false);
			this.ucGroupBox1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private CommonWinCtrls.ucGridEx grdCodes;
		private CommonWinCtrls.ucButton btnSave;
		private CommonWinCtrls.ucTextBox txtLINE;
		private CommonWinCtrls.ucTextBox txtSDDC;
		private CommonWinCtrls.ucButton btnNew;
		private CommonWinCtrls.ucGroupBox ucGroupBox1;
		private CommonWinCtrls.ucButton btnDelete;
		private CommonWinCtrls.ucButton btnCancel;
	}
}