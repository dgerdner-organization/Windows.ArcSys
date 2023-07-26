namespace CS2010.ArcSys.Win
{
    partial class frmEditGroup
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
            this.txtDsc = new CS2010.CommonWinCtrls.ucTextBox();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(149, 92);
            this.btnOK.TabIndex = 4;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(237, 92);
            this.btnCancel.TabIndex = 5;
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(252, 179);
            this.btnApply.TabIndex = 6;
            this.btnApply.TabStop = true;
            this.btnApply.UseVisualStyleBackColor = false;
            // 
            // txtDsc
            // 
            this.txtDsc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDsc.LabelText = "Group Description";
            this.txtDsc.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtDsc.LinkDisabledMessage = "Link Disabled";
            this.txtDsc.Location = new System.Drawing.Point(97, 36);
            this.txtDsc.Name = "txtDsc";
            this.txtDsc.Size = new System.Drawing.Size(245, 20);
            this.txtDsc.TabIndex = 7;
            // 
            // frmEditGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(364, 152);
            this.Controls.Add(this.txtDsc);
            this.Name = "frmEditGroup";
            this.Text = "Add/Edit Group";
            this.Controls.SetChildIndex(this.txtDsc, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.btnOK, 0);
            this.Controls.SetChildIndex(this.btnApply, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CS2010.CommonWinCtrls.ucTextBox txtDsc;


    }
}
