namespace CS2010.AVSS.Win
{
	partial class frmEditVesselMilitaryVoyage
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
			this.components = new System.ComponentModel.Container();
			Janus.Windows.GridEX.GridEXLayout grdMilitaryVoyages_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditVesselMilitaryVoyage));
			this.grdMilitaryVoyages = new CS2010.CommonWinCtrls.ucGridEx();
			this.txtVoyage = new CS2010.CommonWinCtrls.ucLabel();
			this.txtPort = new CS2010.CommonWinCtrls.ucLabel();
			this.txtActivity = new CS2010.CommonWinCtrls.ucLabel();
			this.cmbMilVoy = new CS2010.CommonWinCtrls.ucComboBox();
			this.btnAdd = new CS2010.CommonWinCtrls.ucButton();
			this.btnAddAll = new CS2010.CommonWinCtrls.ucButton();
			((System.ComponentModel.ISupportInitialize)(this.grdMilitaryVoyages)).BeginInit();
			this.SuspendLayout();
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(55, 206);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(143, 206);
			// 
			// btnApply
			// 
			this.btnApply.Location = new System.Drawing.Point(231, 206);
			this.btnApply.TabStop = true;
			this.btnApply.UseVisualStyleBackColor = false;
			// 
			// grdMilitaryVoyages
			// 
			grdMilitaryVoyages_DesignTimeLayout.LayoutString = resources.GetString("grdMilitaryVoyages_DesignTimeLayout.LayoutString");
			this.grdMilitaryVoyages.DesignTimeLayout = grdMilitaryVoyages_DesignTimeLayout;
			this.grdMilitaryVoyages.ExportFileID = null;
			this.grdMilitaryVoyages.GroupByBoxVisible = false;
			this.grdMilitaryVoyages.Location = new System.Drawing.Point(57, 111);
			this.grdMilitaryVoyages.Name = "grdMilitaryVoyages";
			this.grdMilitaryVoyages.Size = new System.Drawing.Size(161, 86);
			this.grdMilitaryVoyages.TabIndex = 6;
			this.grdMilitaryVoyages.ColumnButtonClick += new Janus.Windows.GridEX.ColumnActionEventHandler(this.grdMilitaryVoyages_ColumnButtonClick);
			// 
			// txtVoyage
			// 
			this.txtVoyage.Location = new System.Drawing.Point(58, 13);
			this.txtVoyage.Name = "txtVoyage";
			this.txtVoyage.Size = new System.Drawing.Size(51, 13);
			this.txtVoyage.TabIndex = 7;
			this.txtVoyage.Text = "ucLabel1";
			// 
			// txtPort
			// 
			this.txtPort.Location = new System.Drawing.Point(58, 30);
			this.txtPort.Name = "txtPort";
			this.txtPort.Size = new System.Drawing.Size(51, 13);
			this.txtPort.TabIndex = 8;
			this.txtPort.Text = "ucLabel1";
			// 
			// txtActivity
			// 
			this.txtActivity.Location = new System.Drawing.Point(58, 47);
			this.txtActivity.Name = "txtActivity";
			this.txtActivity.Size = new System.Drawing.Size(51, 13);
			this.txtActivity.TabIndex = 9;
			this.txtActivity.Text = "ucLabel2";
			// 
			// cmbMilVoy
			// 
			this.cmbMilVoy.DisplayMember = "military_voyage_no";
			this.cmbMilVoy.FormattingEnabled = true;
			this.cmbMilVoy.Location = new System.Drawing.Point(58, 81);
			this.cmbMilVoy.Name = "cmbMilVoy";
			this.cmbMilVoy.Size = new System.Drawing.Size(97, 21);
			this.cmbMilVoy.TabIndex = 10;
			this.cmbMilVoy.ValueMember = "military_voyage_no";
			// 
			// btnAdd
			// 
			this.btnAdd.Location = new System.Drawing.Point(163, 81);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(55, 23);
			this.btnAdd.TabIndex = 11;
			this.btnAdd.Text = "Add";
			this.btnAdd.UseVisualStyleBackColor = true;
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// btnAddAll
			// 
			this.btnAddAll.Location = new System.Drawing.Point(224, 81);
			this.btnAddAll.Name = "btnAddAll";
			this.btnAddAll.Size = new System.Drawing.Size(75, 23);
			this.btnAddAll.TabIndex = 12;
			this.btnAddAll.Text = "Add All";
			this.btnAddAll.UseVisualStyleBackColor = true;
			this.btnAddAll.Click += new System.EventHandler(this.btnAddAll_Click);
			// 
			// frmEditVesselMilitaryVoyage
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.ClientSize = new System.Drawing.Size(397, 260);
			this.Controls.Add(this.btnAddAll);
			this.Controls.Add(this.btnAdd);
			this.Controls.Add(this.cmbMilVoy);
			this.Controls.Add(this.txtActivity);
			this.Controls.Add(this.txtPort);
			this.Controls.Add(this.txtVoyage);
			this.Controls.Add(this.grdMilitaryVoyages);
			this.Name = "frmEditVesselMilitaryVoyage";
			this.Text = "Edit Vessel Military Voyage";
			this.Load += new System.EventHandler(this.frmEditActivity_Load);
			this.Controls.SetChildIndex(this.btnCancel, 0);
			this.Controls.SetChildIndex(this.btnOK, 0);
			this.Controls.SetChildIndex(this.btnApply, 0);
			this.Controls.SetChildIndex(this.grdMilitaryVoyages, 0);
			this.Controls.SetChildIndex(this.txtVoyage, 0);
			this.Controls.SetChildIndex(this.txtPort, 0);
			this.Controls.SetChildIndex(this.txtActivity, 0);
			this.Controls.SetChildIndex(this.cmbMilVoy, 0);
			this.Controls.SetChildIndex(this.btnAdd, 0);
			this.Controls.SetChildIndex(this.btnAddAll, 0);
			((System.ComponentModel.ISupportInitialize)(this.grdMilitaryVoyages)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

		private CS2010.CommonWinCtrls.ucGridEx grdMilitaryVoyages;
		private CS2010.CommonWinCtrls.ucLabel txtVoyage;
		private CS2010.CommonWinCtrls.ucLabel txtPort;
		private CS2010.CommonWinCtrls.ucLabel txtActivity;
		private CS2010.CommonWinCtrls.ucComboBox cmbMilVoy;
		private CS2010.CommonWinCtrls.ucButton btnAdd;
		private CS2010.CommonWinCtrls.ucButton btnAddAll;




	}
}
