namespace CS2010.ArcSys.Win
{
    partial class frmLogin
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
			this.SuspendLayout();
			// 
			// txtUser
			// 
			this.txtUser.Location = new System.Drawing.Point(315, 48);
			// 
			// txtPwd
			// 
			this.txtPwd.Location = new System.Drawing.Point(315, 74);
			// 
			// lblUser
			// 
			this.lblUser.BackColor = System.Drawing.Color.Transparent;
			this.lblUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblUser.ForeColor = System.Drawing.Color.Black;
			this.lblUser.Location = new System.Drawing.Point(240, 51);
			this.lblUser.Size = new System.Drawing.Size(69, 13);
			// 
			// lblPwd
			// 
			this.lblPwd.BackColor = System.Drawing.Color.Transparent;
			this.lblPwd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblPwd.ForeColor = System.Drawing.Color.Black;
			this.lblPwd.Location = new System.Drawing.Point(248, 77);
			this.lblPwd.Size = new System.Drawing.Size(61, 13);
			// 
			// lblVersion
			// 
			this.lblVersion.BackColor = System.Drawing.Color.Transparent;
			this.lblVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblVersion.ForeColor = System.Drawing.Color.Black;
			this.lblVersion.Location = new System.Drawing.Point(248, 115);
			// 
			// lblCopyright
			// 
			this.lblCopyright.BackColor = System.Drawing.Color.Transparent;
			this.lblCopyright.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblCopyright.ForeColor = System.Drawing.Color.Black;
			this.lblCopyright.Location = new System.Drawing.Point(248, 131);
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(323, 165);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(404, 165);
			// 
			// frmLogin
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
			this.ClientSize = new System.Drawing.Size(499, 200);
			this.Name = "frmLogin";
			this.Text = "frmLogin";
			this.Load += new System.EventHandler(this.frmLogin_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion


    }
}