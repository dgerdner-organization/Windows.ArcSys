namespace CS2010.ArcSys.Win
{
    partial class frmLOBShowCompare
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
            this.bntOK = new CS2010.CommonWinCtrls.ucButton();
            this.txtAcms = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtLoadList = new CS2010.CommonWinCtrls.ucTextBox();
            this.SuspendLayout();
            // 
            // bntOK
            // 
            this.bntOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bntOK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bntOK.Location = new System.Drawing.Point(354, 74);
            this.bntOK.Name = "bntOK";
            this.bntOK.Size = new System.Drawing.Size(75, 23);
            this.bntOK.TabIndex = 3;
            this.bntOK.Text = "&OK";
            this.bntOK.UseVisualStyleBackColor = true;
            this.bntOK.Click += new System.EventHandler(this.bntOK_Click);
            // 
            // txtAcms
            // 
            this.txtAcms.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAcms.LabelText = "ACMS";
            this.txtAcms.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtAcms.LinkDisabledMessage = "Link Disabled";
            this.txtAcms.Location = new System.Drawing.Point(83, 13);
            this.txtAcms.Name = "txtAcms";
            this.txtAcms.Size = new System.Drawing.Size(346, 20);
            this.txtAcms.TabIndex = 1;
            // 
            // txtLoadList
            // 
            this.txtLoadList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLoadList.LabelText = "Load List";
            this.txtLoadList.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtLoadList.LinkDisabledMessage = "Link Disabled";
            this.txtLoadList.Location = new System.Drawing.Point(83, 39);
            this.txtLoadList.Name = "txtLoadList";
            this.txtLoadList.Size = new System.Drawing.Size(346, 20);
            this.txtLoadList.TabIndex = 2;
            // 
            // frmLOBShowCompare
            // 
            this.AcceptButton = this.bntOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bntOK;
            this.ClientSize = new System.Drawing.Size(441, 109);
            this.ControlBox = false;
            this.Controls.Add(this.txtLoadList);
            this.Controls.Add(this.txtAcms);
            this.Controls.Add(this.bntOK);
            this.Name = "frmLOBShowCompare";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ACMS vs Load List";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CommonWinCtrls.ucButton bntOK;
        private CommonWinCtrls.ucTextBox txtAcms;
        private CommonWinCtrls.ucTextBox txtLoadList;
    }
}