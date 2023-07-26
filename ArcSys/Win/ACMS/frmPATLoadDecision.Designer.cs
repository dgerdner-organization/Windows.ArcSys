namespace CS2010.ArcSys.Win
{
    partial class frmPATLoadDecision
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
            this.grpCreate = new System.Windows.Forms.GroupBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.grpLoad = new System.Windows.Forms.GroupBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.cmbLobHeader = new CS2010.ArcSys.WinCtrls.ucLobHeader(this.components);
            this.grpCreate.SuspendLayout();
            this.grpLoad.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(93, 306);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(324, 91);
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(12, 306);
            this.btnApply.TabStop = true;
            this.btnApply.UseVisualStyleBackColor = false;
            // 
            // grpCreate
            // 
            this.grpCreate.Controls.Add(this.btnCreate);
            this.grpCreate.Location = new System.Drawing.Point(184, 287);
            this.grpCreate.Name = "grpCreate";
            this.grpCreate.Size = new System.Drawing.Size(387, 64);
            this.grpCreate.TabIndex = 0;
            this.grpCreate.TabStop = false;
            this.grpCreate.Text = "Create a new version ...";
            this.grpCreate.Visible = false;
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(212, 19);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(158, 30);
            this.btnCreate.TabIndex = 0;
            this.btnCreate.Text = "Create Version #N";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // grpLoad
            // 
            this.grpLoad.Controls.Add(this.btnLoad);
            this.grpLoad.Controls.Add(this.cmbLobHeader);
            this.grpLoad.Location = new System.Drawing.Point(12, 12);
            this.grpLoad.Name = "grpLoad";
            this.grpLoad.Size = new System.Drawing.Size(387, 73);
            this.grpLoad.TabIndex = 1;
            this.grpLoad.TabStop = false;
            this.grpLoad.Text = "Load a previously saved version ...";
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(212, 23);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(158, 30);
            this.btnLoad.TabIndex = 1;
            this.btnLoad.Text = "Load Version";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // cmbLobHeader
            // 
            this.cmbLobHeader.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLobHeader.FormattingEnabled = true;
            this.cmbLobHeader.LabelText = "Version";
            this.cmbLobHeader.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.cmbLobHeader.Location = new System.Drawing.Point(67, 29);
            this.cmbLobHeader.Name = "cmbLobHeader";
            this.cmbLobHeader.Size = new System.Drawing.Size(121, 21);
            this.cmbLobHeader.TabIndex = 0;
            // 
            // frmPATLoadDecision
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 128);
            this.Controls.Add(this.grpLoad);
            this.Controls.Add(this.grpCreate);
            this.Name = "frmPATLoadDecision";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Load Load List ";
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.grpCreate, 0);
            this.Controls.SetChildIndex(this.btnApply, 0);
            this.Controls.SetChildIndex(this.btnOK, 0);
            this.Controls.SetChildIndex(this.grpLoad, 0);
            this.grpCreate.ResumeLayout(false);
            this.grpLoad.ResumeLayout(false);
            this.grpLoad.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpCreate;
        private System.Windows.Forms.GroupBox grpLoad;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnLoad;
        private WinCtrls.ucLobHeader cmbLobHeader;
    }
}