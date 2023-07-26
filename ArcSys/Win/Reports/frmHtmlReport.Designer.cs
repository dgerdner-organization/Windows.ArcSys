namespace CS2010.ArcSys.Win
{
    partial class frmHtmlReport
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
            this.btnEmailToMe = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnEmailToMe);
            this.panel1.Size = new System.Drawing.Size(792, 39);
            this.panel1.Controls.SetChildIndex(this.btnURL, 0);
            this.panel1.Controls.SetChildIndex(this.btnEmailToMe, 0);
            // 
            // btnURL
            // 
            this.btnURL.Location = new System.Drawing.Point(710, 4);
            // 
            // btnEmailToMe
            // 
            this.btnEmailToMe.Location = new System.Drawing.Point(10, 4);
            this.btnEmailToMe.Name = "btnEmailToMe";
            this.btnEmailToMe.Size = new System.Drawing.Size(115, 28);
            this.btnEmailToMe.TabIndex = 1;
            this.btnEmailToMe.Text = "Email it";
            this.btnEmailToMe.UseVisualStyleBackColor = true;
            this.btnEmailToMe.Click += new System.EventHandler(this.button2_Click);
            // 
            // frmHtmlReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Name = "frmHtmlReport";
            this.Text = "frmHtmlReport";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnEmailToMe;
    }
}