namespace CS2010.ArcSys.Win
{
    partial class frmEditSecurityObject
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
            this.cbxVisible = new CS2010.CommonWinCtrls.ucCheckBox();
            this.cbxEnabled = new CS2010.CommonWinCtrls.ucCheckBox();
            this.txtObjectNm = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtObjectDsc = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtParentDsc = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtParentNm = new CS2010.CommonWinCtrls.ucTextBox();
            this.txtCollectionDsc = new CS2010.CommonWinCtrls.ucTextBox();
            this.cbxFinanceFlg = new CS2010.CommonWinCtrls.ucCheckBox();
            this.cbxVendorFlg = new CS2010.CommonWinCtrls.ucCheckBox();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(149, 236);
            this.btnOK.TabIndex = 9;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(237, 236);
            this.btnCancel.TabIndex = 10;
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(12, 245);
            this.btnApply.TabIndex = 11;
            this.btnApply.TabStop = true;
            this.btnApply.UseVisualStyleBackColor = false;
            // 
            // cbxVisible
            // 
            this.cbxVisible.Location = new System.Drawing.Point(122, 140);
            this.cbxVisible.Name = "cbxVisible";
            this.cbxVisible.Size = new System.Drawing.Size(104, 24);
            this.cbxVisible.TabIndex = 5;
            this.cbxVisible.Text = "Visible";
            this.cbxVisible.UseVisualStyleBackColor = true;
            this.cbxVisible.YN = "N";
            // 
            // cbxEnabled
            // 
            this.cbxEnabled.Location = new System.Drawing.Point(122, 160);
            this.cbxEnabled.Name = "cbxEnabled";
            this.cbxEnabled.Size = new System.Drawing.Size(104, 24);
            this.cbxEnabled.TabIndex = 6;
            this.cbxEnabled.Text = "Enabled";
            this.cbxEnabled.UseVisualStyleBackColor = true;
            this.cbxEnabled.Visible = false;
            this.cbxEnabled.YN = "N";
            // 
            // txtObjectNm
            // 
            this.txtObjectNm.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtObjectNm.LabelText = "Object Name";
            this.txtObjectNm.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtObjectNm.LinkDisabledMessage = "Link Disabled";
            this.txtObjectNm.Location = new System.Drawing.Point(122, 12);
            this.txtObjectNm.Name = "txtObjectNm";
            this.txtObjectNm.Size = new System.Drawing.Size(190, 20);
            this.txtObjectNm.TabIndex = 0;
            // 
            // txtObjectDsc
            // 
            this.txtObjectDsc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtObjectDsc.LabelText = "Object Description";
            this.txtObjectDsc.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtObjectDsc.LinkDisabledMessage = "Link Disabled";
            this.txtObjectDsc.Location = new System.Drawing.Point(122, 38);
            this.txtObjectDsc.Name = "txtObjectDsc";
            this.txtObjectDsc.Size = new System.Drawing.Size(190, 20);
            this.txtObjectDsc.TabIndex = 1;
            // 
            // txtParentDsc
            // 
            this.txtParentDsc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtParentDsc.LabelText = "Parent Description";
            this.txtParentDsc.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtParentDsc.LinkDisabledMessage = "Link Disabled";
            this.txtParentDsc.Location = new System.Drawing.Point(122, 90);
            this.txtParentDsc.Name = "txtParentDsc";
            this.txtParentDsc.Size = new System.Drawing.Size(190, 20);
            this.txtParentDsc.TabIndex = 3;
            // 
            // txtParentNm
            // 
            this.txtParentNm.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtParentNm.LabelText = "Parent Name";
            this.txtParentNm.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtParentNm.LinkDisabledMessage = "Link Disabled";
            this.txtParentNm.Location = new System.Drawing.Point(122, 64);
            this.txtParentNm.Name = "txtParentNm";
            this.txtParentNm.Size = new System.Drawing.Size(190, 20);
            this.txtParentNm.TabIndex = 2;
            // 
            // txtCollectionDsc
            // 
            this.txtCollectionDsc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCollectionDsc.LabelText = "Collection";
            this.txtCollectionDsc.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtCollectionDsc.LinkDisabledMessage = "Link Disabled";
            this.txtCollectionDsc.Location = new System.Drawing.Point(122, 116);
            this.txtCollectionDsc.Name = "txtCollectionDsc";
            this.txtCollectionDsc.Size = new System.Drawing.Size(190, 20);
            this.txtCollectionDsc.TabIndex = 4;
            // 
            // cbxFinanceFlg
            // 
            this.cbxFinanceFlg.Location = new System.Drawing.Point(122, 182);
            this.cbxFinanceFlg.Name = "cbxFinanceFlg";
            this.cbxFinanceFlg.Size = new System.Drawing.Size(104, 24);
            this.cbxFinanceFlg.TabIndex = 7;
            this.cbxFinanceFlg.Text = "Finance Related";
            this.cbxFinanceFlg.UseVisualStyleBackColor = true;
            this.cbxFinanceFlg.YN = "N";
            // 
            // cbxVendorFlg
            // 
            this.cbxVendorFlg.Location = new System.Drawing.Point(122, 203);
            this.cbxVendorFlg.Name = "cbxVendorFlg";
            this.cbxVendorFlg.Size = new System.Drawing.Size(104, 24);
            this.cbxVendorFlg.TabIndex = 8;
            this.cbxVendorFlg.Text = "Vendor Control";
            this.cbxVendorFlg.UseVisualStyleBackColor = true;
            this.cbxVendorFlg.YN = "N";
            // 
            // frmEditSecurityObject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(355, 280);
            this.Controls.Add(this.cbxVendorFlg);
            this.Controls.Add(this.cbxFinanceFlg);
            this.Controls.Add(this.txtCollectionDsc);
            this.Controls.Add(this.txtParentDsc);
            this.Controls.Add(this.txtParentNm);
            this.Controls.Add(this.txtObjectDsc);
            this.Controls.Add(this.txtObjectNm);
            this.Controls.Add(this.cbxEnabled);
            this.Controls.Add(this.cbxVisible);
            this.Name = "frmEditSecurityObject";
            this.Text = "Add/Edit Security Object";
            this.Controls.SetChildIndex(this.btnOK, 0);
            this.Controls.SetChildIndex(this.btnApply, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.cbxVisible, 0);
            this.Controls.SetChildIndex(this.cbxEnabled, 0);
            this.Controls.SetChildIndex(this.txtObjectNm, 0);
            this.Controls.SetChildIndex(this.txtObjectDsc, 0);
            this.Controls.SetChildIndex(this.txtParentNm, 0);
            this.Controls.SetChildIndex(this.txtParentDsc, 0);
            this.Controls.SetChildIndex(this.txtCollectionDsc, 0);
            this.Controls.SetChildIndex(this.cbxFinanceFlg, 0);
            this.Controls.SetChildIndex(this.cbxVendorFlg, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CS2010.CommonWinCtrls.ucCheckBox cbxVisible;
        private CS2010.CommonWinCtrls.ucCheckBox cbxEnabled;
        private CS2010.CommonWinCtrls.ucTextBox txtObjectNm;
        private CS2010.CommonWinCtrls.ucTextBox txtObjectDsc;
        private CS2010.CommonWinCtrls.ucTextBox txtParentDsc;
        private CS2010.CommonWinCtrls.ucTextBox txtParentNm;
        private CS2010.CommonWinCtrls.ucTextBox txtCollectionDsc;
        private CS2010.CommonWinCtrls.ucCheckBox cbxFinanceFlg;
        private CS2010.CommonWinCtrls.ucCheckBox cbxVendorFlg;

    }
}
