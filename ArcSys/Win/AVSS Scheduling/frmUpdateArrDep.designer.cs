namespace CS2010.AVSS.Win
{
	partial class frmUpdateArrDep
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
			Janus.Windows.GridEX.GridEXLayout grdData_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUpdateArrDep));
			this.panel1 = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.btnFont = new CS2010.CommonWinCtrls.ucButton();
			this.btnCancel = new CS2010.CommonWinCtrls.ucButton();
			this.btnSave = new CS2010.CommonWinCtrls.ucButton();
			this.grdData = new CS2010.CommonWinCtrls.ucGridEx();
			this.fontDialog = new System.Windows.Forms.FontDialog();
			this.txtArriveDt = new CS2010.CommonWinCtrls.ucDateTimePicker();
			this.txtDepartDt = new CS2010.CommonWinCtrls.ucDateTimePicker();
			this.cbxDepart = new CS2010.CommonWinCtrls.ucCheckBox();
			this.cbxArrive = new CS2010.CommonWinCtrls.ucCheckBox();
			this.pnlAD = new System.Windows.Forms.Panel();
			this.lblDepart = new System.Windows.Forms.Label();
			this.lblArrive = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
			this.pnlAD.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.btnFont);
			this.panel1.Controls.Add(this.btnCancel);
			this.panel1.Controls.Add(this.btnSave);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 500);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1251, 57);
			this.panel1.TabIndex = 0;
			this.panel1.Enter += new System.EventHandler(this.panel1_Enter);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(10, 20);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(445, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "NOTE: The vessels \'Capucine\' and \'Severine\' have been intentionally removed from " +
				"this Grid.";
			// 
			// btnFont
			// 
			this.btnFont.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnFont.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnFont.Location = new System.Drawing.Point(990, 10);
			this.btnFont.Name = "btnFont";
			this.btnFont.Size = new System.Drawing.Size(75, 40);
			this.btnFont.TabIndex = 2;
			this.btnFont.Text = "&Fonts";
			this.btnFont.UseVisualStyleBackColor = true;
			this.btnFont.Click += new System.EventHandler(this.btnFont_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnCancel.Location = new System.Drawing.Point(1155, 10);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(85, 40);
			this.btnCancel.TabIndex = 1;
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnSave
			// 
			this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnSave.Location = new System.Drawing.Point(1075, 10);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(75, 40);
			this.btnSave.TabIndex = 0;
			this.btnSave.Text = "&Save";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// grdData
			// 
			grdData_DesignTimeLayout.LayoutString = resources.GetString("grdData_DesignTimeLayout.LayoutString");
			this.grdData.DesignTimeLayout = grdData_DesignTimeLayout;
			this.grdData.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grdData.ExportFileID = null;
			this.grdData.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
			this.grdData.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.grdData.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
			this.grdData.Location = new System.Drawing.Point(0, 0);
			this.grdData.Name = "grdData";
			this.grdData.SelectedInactiveFormatStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
			this.grdData.SelectedInactiveFormatStyle.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.grdData.Size = new System.Drawing.Size(1251, 500);
			this.grdData.TabIndex = 1;
			this.grdData.Click += new System.EventHandler(this.grdData_Click);
			this.grdData.Enter += new System.EventHandler(this.grdData_Enter);
			// 
			// txtArriveDt
			// 
			this.txtArriveDt.CustomFormat = "MM-dd-yyyy HH:mm";
			this.txtArriveDt.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtArriveDt.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.txtArriveDt.Location = new System.Drawing.Point(30, 50);
			this.txtArriveDt.MaxDate = new System.DateTime(2020, 12, 31, 0, 0, 0, 0);
			this.txtArriveDt.MinDate = new System.DateTime(2009, 1, 1, 0, 0, 0, 0);
			this.txtArriveDt.Name = "txtArriveDt";
			this.txtArriveDt.Size = new System.Drawing.Size(220, 31);
			this.txtArriveDt.TabIndex = 20;
			// 
			// txtDepartDt
			// 
			this.txtDepartDt.CustomFormat = "MM-dd-yyyy HH:mm";
			this.txtDepartDt.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtDepartDt.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.txtDepartDt.Location = new System.Drawing.Point(30, 220);
			this.txtDepartDt.MaxDate = new System.DateTime(2020, 12, 31, 0, 0, 0, 0);
			this.txtDepartDt.MinDate = new System.DateTime(2009, 1, 1, 0, 0, 0, 0);
			this.txtDepartDt.Name = "txtDepartDt";
			this.txtDepartDt.Size = new System.Drawing.Size(220, 31);
			this.txtDepartDt.TabIndex = 22;
			// 
			// cbxDepart
			// 
			this.cbxDepart.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cbxDepart.Location = new System.Drawing.Point(140, 260);
			this.cbxDepart.Name = "cbxDepart";
			this.cbxDepart.Size = new System.Drawing.Size(110, 24);
			this.cbxDepart.TabIndex = 21;
			this.cbxDepart.Text = "Actual";
			this.cbxDepart.UseVisualStyleBackColor = true;
			this.cbxDepart.YN = "N";
			// 
			// cbxArrive
			// 
			this.cbxArrive.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cbxArrive.Location = new System.Drawing.Point(130, 90);
			this.cbxArrive.Name = "cbxArrive";
			this.cbxArrive.Size = new System.Drawing.Size(110, 24);
			this.cbxArrive.TabIndex = 19;
			this.cbxArrive.Text = "Actual";
			this.cbxArrive.UseVisualStyleBackColor = true;
			this.cbxArrive.YN = "N";
			// 
			// pnlAD
			// 
			this.pnlAD.Controls.Add(this.lblDepart);
			this.pnlAD.Controls.Add(this.lblArrive);
			this.pnlAD.Controls.Add(this.cbxDepart);
			this.pnlAD.Controls.Add(this.txtDepartDt);
			this.pnlAD.Controls.Add(this.cbxArrive);
			this.pnlAD.Controls.Add(this.txtArriveDt);
			this.pnlAD.Dock = System.Windows.Forms.DockStyle.Right;
			this.pnlAD.Location = new System.Drawing.Point(972, 0);
			this.pnlAD.Name = "pnlAD";
			this.pnlAD.Size = new System.Drawing.Size(279, 500);
			this.pnlAD.TabIndex = 2;
			// 
			// lblDepart
			// 
			this.lblDepart.AutoSize = true;
			this.lblDepart.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
			this.lblDepart.Location = new System.Drawing.Point(30, 190);
			this.lblDepart.Name = "lblDepart";
			this.lblDepart.Size = new System.Drawing.Size(76, 25);
			this.lblDepart.TabIndex = 24;
			this.lblDepart.Text = "Depart";
			// 
			// lblArrive
			// 
			this.lblArrive.AutoSize = true;
			this.lblArrive.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
			this.lblArrive.Location = new System.Drawing.Point(30, 20);
			this.lblArrive.Name = "lblArrive";
			this.lblArrive.Size = new System.Drawing.Size(73, 25);
			this.lblArrive.TabIndex = 23;
			this.lblArrive.Text = "Arrival";
			// 
			// frmUpdateArrDep
			// 
			this.AcceptButton = this.btnSave;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(1251, 557);
			this.Controls.Add(this.pnlAD);
			this.Controls.Add(this.grdData);
			this.Controls.Add(this.panel1);
			this.MinimizeBox = false;
			this.Name = "frmUpdateArrDep";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Arrive / Depart Update";
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
			this.pnlAD.ResumeLayout(false);
			this.pnlAD.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private CS2010.CommonWinCtrls.ucButton btnCancel;
		private CS2010.CommonWinCtrls.ucButton btnSave;
		private CS2010.CommonWinCtrls.ucGridEx grdData;
		private CS2010.CommonWinCtrls.ucButton btnFont;
		private System.Windows.Forms.FontDialog fontDialog;
		private System.Windows.Forms.Label label1;
		private CS2010.CommonWinCtrls.ucDateTimePicker txtArriveDt;
		private CS2010.CommonWinCtrls.ucDateTimePicker txtDepartDt;
		private CS2010.CommonWinCtrls.ucCheckBox cbxDepart;
		private CS2010.CommonWinCtrls.ucCheckBox cbxArrive;
		private System.Windows.Forms.Panel pnlAD;
		private System.Windows.Forms.Label lblArrive;
		private System.Windows.Forms.Label lblDepart;
	}
}