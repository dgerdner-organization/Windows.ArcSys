namespace CS2010.ArcSys.Win
{
    partial class frmEditTopsPorts
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditTopsPorts));
            this.grdMain = new CS2010.CommonWinCtrls.ucGridEx();
            this.btnSave = new CS2010.CommonWinCtrls.ucButton();
            this.btnAdd = new CS2010.CommonWinCtrls.ucButton();
            ((System.ComponentModel.ISupportInitialize)(this.grdMain)).BeginInit();
            this.SuspendLayout();
            // 
            // grdMain
            // 
            grdMain_DesignTimeLayout.LayoutString = resources.GetString("grdMain_DesignTimeLayout.LayoutString");
            this.grdMain.DesignTimeLayout = grdMain_DesignTimeLayout;
            this.grdMain.ExportFileID = null;
            this.grdMain.Location = new System.Drawing.Point(41, 31);
            this.grdMain.Name = "grdMain";
            this.grdMain.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
            this.grdMain.Size = new System.Drawing.Size(535, 279);
            this.grdMain.TabIndex = 0;
            this.grdMain.ColumnButtonClick += new Janus.Windows.GridEX.ColumnActionEventHandler(this.grdMain_ColumnButtonClick);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(408, 316);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(41, 316);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // frmEditTopsPorts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 496);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.grdMain);
            this.Name = "frmEditTopsPorts";
            this.Text = "frmEditTopsPorts";
            ((System.ComponentModel.ISupportInitialize)(this.grdMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CommonWinCtrls.ucGridEx grdMain;
        private CommonWinCtrls.ucButton btnSave;
        private CommonWinCtrls.ucButton btnAdd;
    }
}