namespace CS2010.CommonWinCtrls
{
    partial class frmEmail
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
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.btnSend = new CS2010.CommonWinCtrls.ucButton();
			this.btnAttach = new CS2010.CommonWinCtrls.ucButton();
			this.btnCancel = new CS2010.CommonWinCtrls.ucButton();
			this.txtAttachments = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtBody = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtSubject = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtCC = new CS2010.CommonWinCtrls.ucTextBox();
			this.txtTo = new CS2010.CommonWinCtrls.ucTextBox();
			this.lblSubject = new CS2010.CommonWinCtrls.ucLabel();
			this.lblCC = new CS2010.CommonWinCtrls.ucLabel();
			this.lblTo = new CS2010.CommonWinCtrls.ucLabel();
			this.flowLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.Controls.Add(this.btnSend);
			this.flowLayoutPanel1.Controls.Add(this.btnAttach);
			this.flowLayoutPanel1.Controls.Add(this.btnCancel);
			this.flowLayoutPanel1.Location = new System.Drawing.Point(1, 3);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(467, 29);
			this.flowLayoutPanel1.TabIndex = 0;
			// 
			// btnSend
			// 
			this.btnSend.Location = new System.Drawing.Point(3, 3);
			this.btnSend.Name = "btnSend";
			this.btnSend.Size = new System.Drawing.Size(75, 23);
			this.btnSend.TabIndex = 0;
			this.btnSend.Text = "Send";
			this.btnSend.UseVisualStyleBackColor = true;
			this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
			// 
			// btnAttach
			// 
			this.btnAttach.Location = new System.Drawing.Point(84, 3);
			this.btnAttach.Name = "btnAttach";
			this.btnAttach.Size = new System.Drawing.Size(75, 23);
			this.btnAttach.TabIndex = 1;
			this.btnAttach.Text = "Attach...";
			this.btnAttach.UseVisualStyleBackColor = true;
			this.btnAttach.Click += new System.EventHandler(this.btnAttach_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(165, 3);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// txtAttachments
			// 
			this.txtAttachments.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
						| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.txtAttachments.BackColor = System.Drawing.SystemColors.Control;
			this.txtAttachments.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtAttachments.ForeColor = System.Drawing.Color.Black;
			this.txtAttachments.LinkDisabledMessage = "Link Disabled";
			this.txtAttachments.Location = new System.Drawing.Point(86, 105);
			this.txtAttachments.Name = "txtAttachments";
			this.txtAttachments.ReadOnly = true;
			this.txtAttachments.Size = new System.Drawing.Size(644, 20);
			this.txtAttachments.TabIndex = 8;
			this.txtAttachments.TabStop = false;
			// 
			// txtBody
			// 
			this.txtBody.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
						| System.Windows.Forms.AnchorStyles.Left )
						| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.txtBody.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtBody.LinkDisabledMessage = "Link Disabled";
			this.txtBody.Location = new System.Drawing.Point(86, 129);
			this.txtBody.Multiline = true;
			this.txtBody.Name = "txtBody";
			this.txtBody.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtBody.Size = new System.Drawing.Size(645, 352);
			this.txtBody.TabIndex = 7;
			// 
			// txtSubject
			// 
			this.txtSubject.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
						| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.txtSubject.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtSubject.LinkDisabledMessage = "Link Disabled";
			this.txtSubject.Location = new System.Drawing.Point(85, 82);
			this.txtSubject.Name = "txtSubject";
			this.txtSubject.Size = new System.Drawing.Size(646, 20);
			this.txtSubject.TabIndex = 6;
			// 
			// txtCC
			// 
			this.txtCC.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
						| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.txtCC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtCC.LinkDisabledMessage = "Link Disabled";
			this.txtCC.Location = new System.Drawing.Point(85, 60);
			this.txtCC.Name = "txtCC";
			this.txtCC.Size = new System.Drawing.Size(646, 20);
			this.txtCC.TabIndex = 5;
			// 
			// txtTo
			// 
			this.txtTo.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
						| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.txtTo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtTo.LinkDisabledMessage = "Link Disabled";
			this.txtTo.Location = new System.Drawing.Point(85, 38);
			this.txtTo.Name = "txtTo";
			this.txtTo.Size = new System.Drawing.Size(646, 20);
			this.txtTo.TabIndex = 4;
			// 
			// lblSubject
			// 
			this.lblSubject.AutoSize = true;
			this.lblSubject.Location = new System.Drawing.Point(9, 82);
			this.lblSubject.Name = "lblSubject";
			this.lblSubject.Size = new System.Drawing.Size(43, 13);
			this.lblSubject.TabIndex = 3;
			this.lblSubject.Text = "Subject";
			this.lblSubject.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblCC
			// 
			this.lblCC.AutoSize = true;
			this.lblCC.Location = new System.Drawing.Point(9, 60);
			this.lblCC.Name = "lblCC";
			this.lblCC.Size = new System.Drawing.Size(30, 13);
			this.lblCC.TabIndex = 2;
			this.lblCC.Text = "CC...";
			this.lblCC.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.lblCC.MouseLeave += new System.EventHandler(this.lbl_MouseLeave);
			this.lblCC.Click += new System.EventHandler(this.lblCC_Click);
			this.lblCC.MouseHover += new System.EventHandler(this.lbl_MouseHover);
			// 
			// lblTo
			// 
			this.lblTo.AutoSize = true;
			this.lblTo.Location = new System.Drawing.Point(9, 38);
			this.lblTo.Name = "lblTo";
			this.lblTo.Size = new System.Drawing.Size(29, 13);
			this.lblTo.TabIndex = 1;
			this.lblTo.Text = "To...";
			this.lblTo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.lblTo.MouseLeave += new System.EventHandler(this.lbl_MouseLeave);
			this.lblTo.Click += new System.EventHandler(this.lblTo_Click);
			this.lblTo.MouseHover += new System.EventHandler(this.lbl_MouseHover);
			// 
			// frmEmail
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(762, 486);
			this.Controls.Add(this.txtAttachments);
			this.Controls.Add(this.txtBody);
			this.Controls.Add(this.txtSubject);
			this.Controls.Add(this.txtCC);
			this.Controls.Add(this.txtTo);
			this.Controls.Add(this.lblSubject);
			this.Controls.Add(this.lblCC);
			this.Controls.Add(this.lblTo);
			this.Controls.Add(this.flowLayoutPanel1);
			this.Name = "frmEmail";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Email";
			this.Load += new System.EventHandler(this.frmEmail_Load);
			this.flowLayoutPanel1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private ucButton btnSend;
        private ucButton btnAttach;
        private CS2010.CommonWinCtrls.ucLabel lblTo;
        private CS2010.CommonWinCtrls.ucLabel lblCC;
        private CS2010.CommonWinCtrls.ucLabel lblSubject;
        private ucTextBox txtTo;
        private ucTextBox txtCC;
        private ucTextBox txtSubject;
        private ucTextBox txtBody;
        private ucTextBox txtAttachments;
		private ucButton btnCancel;
    }
}