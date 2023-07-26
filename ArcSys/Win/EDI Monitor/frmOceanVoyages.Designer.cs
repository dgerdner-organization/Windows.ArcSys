namespace CS2010.ArcSys.Win.EDI_Monitor
{
    partial class frmOceanVoyages
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
            Janus.Windows.GridEX.GridEXLayout ucGridEx1_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOceanVoyages));
            this.ucGridEx1 = new CS2010.CommonWinCtrls.ucGridEx();
            this.ucTextBox1 = new CS2010.CommonWinCtrls.ucTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.ucGridEx1)).BeginInit();
            this.SuspendLayout();
            // 
            // ucGridEx1
            // 
            ucGridEx1_DesignTimeLayout.LayoutString = resources.GetString("ucGridEx1_DesignTimeLayout.LayoutString");
            this.ucGridEx1.DesignTimeLayout = ucGridEx1_DesignTimeLayout;
            this.ucGridEx1.ExportFileID = null;
            this.ucGridEx1.GroupByBoxVisible = false;
            this.ucGridEx1.Location = new System.Drawing.Point(30, 85);
            this.ucGridEx1.Name = "ucGridEx1";
            this.ucGridEx1.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
            this.ucGridEx1.Size = new System.Drawing.Size(258, 333);
            this.ucGridEx1.TabIndex = 0;
            // 
            // ucTextBox1
            // 
            this.ucTextBox1.BackColor = System.Drawing.SystemColors.Info;
            this.ucTextBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.ucTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucTextBox1.LinkDisabledMessage = "Link Disabled";
            this.ucTextBox1.Location = new System.Drawing.Point(30, 13);
            this.ucTextBox1.Multiline = true;
            this.ucTextBox1.Name = "ucTextBox1";
            this.ucTextBox1.Size = new System.Drawing.Size(258, 66);
            this.ucTextBox1.TabIndex = 1;
            this.ucTextBox1.Text = "REMINDER: Bookings in the voyages listed below will be in the OCEAN system";
            // 
            // frmOceanVoyages
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 446);
            this.Controls.Add(this.ucTextBox1);
            this.Controls.Add(this.ucGridEx1);
            this.Name = "frmOceanVoyages";
            this.Text = "Ocean Voyages";
            ((System.ComponentModel.ISupportInitialize)(this.ucGridEx1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CommonWinCtrls.ucGridEx ucGridEx1;
        private CommonWinCtrls.ucTextBox ucTextBox1;
    }
}