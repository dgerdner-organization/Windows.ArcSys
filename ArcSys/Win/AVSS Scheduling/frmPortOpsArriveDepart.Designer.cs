namespace CS2010.ArcSys.Win
{
    partial class frmPortOpsArriveDepart
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
            Janus.Windows.GridEX.GridEXLayout grdPortCalls_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPortOpsArriveDepart));
            this.btnArrive = new CS2010.CommonWinCtrls.ucButton();
            this.btnDepart = new CS2010.CommonWinCtrls.ucButton();
            this.btnCancel = new CS2010.CommonWinCtrls.ucButton();
            this.grdPortCalls = new CS2010.CommonWinCtrls.ucGridEx();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtArrive = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.pnlArrive = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlDepart = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.dtDepart = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            ((System.ComponentModel.ISupportInitialize)(this.grdPortCalls)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtArrive)).BeginInit();
            this.pnlArrive.SuspendLayout();
            this.pnlDepart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtDepart)).BeginInit();
            this.SuspendLayout();
            // 
            // btnArrive
            // 
            this.btnArrive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnArrive.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnArrive.Location = new System.Drawing.Point(456, 415);
            this.btnArrive.Name = "btnArrive";
            this.btnArrive.Size = new System.Drawing.Size(98, 51);
            this.btnArrive.TabIndex = 2;
            this.btnArrive.Text = "&Arrive";
            this.btnArrive.UseVisualStyleBackColor = true;
            this.btnArrive.Click += new System.EventHandler(this.btnArrive_Click);
            // 
            // btnDepart
            // 
            this.btnDepart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDepart.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDepart.Location = new System.Drawing.Point(560, 415);
            this.btnDepart.Name = "btnDepart";
            this.btnDepart.Size = new System.Drawing.Size(98, 51);
            this.btnDepart.TabIndex = 3;
            this.btnDepart.Text = "&Depart";
            this.btnDepart.UseVisualStyleBackColor = true;
            this.btnDepart.Click += new System.EventHandler(this.btnDepart_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(664, 415);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(99, 51);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // grdPortCalls
            // 
            this.grdPortCalls.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            grdPortCalls_DesignTimeLayout.LayoutString = resources.GetString("grdPortCalls_DesignTimeLayout.LayoutString");
            this.grdPortCalls.DesignTimeLayout = grdPortCalls_DesignTimeLayout;
            this.grdPortCalls.ExportFileID = null;
            this.grdPortCalls.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdPortCalls.Location = new System.Drawing.Point(12, 34);
            this.grdPortCalls.Name = "grdPortCalls";
            this.grdPortCalls.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
            this.grdPortCalls.Size = new System.Drawing.Size(752, 147);
            this.grdPortCalls.TabIndex = 9;
            this.grdPortCalls.SelectionChanged += new System.EventHandler(this.grdPortCalls_SelectionChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(293, 18);
            this.label1.TabIndex = 10;
            this.label1.Text = "Step 1 - Select a Port Call from below";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 209);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(607, 18);
            this.label2.TabIndex = 11;
            this.label2.Text = "Step 2 - Adjust the Date / Time if you need to .... (This can only be +/- 12 hour" +
                "s)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 379);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(250, 18);
            this.label3.TabIndex = 12;
            this.label3.Text = "Step 3 - Click \'Arrive\' or \'Depart\'";
            // 
            // dtArrive
            // 
            this.dtArrive.DateTime = new System.DateTime(2018, 2, 20, 0, 0, 0, 0);
            this.dtArrive.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Standard;
            this.dtArrive.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtArrive.Location = new System.Drawing.Point(171, 19);
            this.dtArrive.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiteralsWithPadding;
            this.dtArrive.MaskInput = "{date} {time}";
            this.dtArrive.Name = "dtArrive";
            this.dtArrive.Size = new System.Drawing.Size(316, 24);
            this.dtArrive.TabIndex = 14;
            this.dtArrive.Value = new System.DateTime(2018, 2, 20, 0, 0, 0, 0);
            // 
            // pnlArrive
            // 
            this.pnlArrive.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlArrive.Controls.Add(this.label4);
            this.pnlArrive.Controls.Add(this.dtArrive);
            this.pnlArrive.Enabled = false;
            this.pnlArrive.Location = new System.Drawing.Point(20, 242);
            this.pnlArrive.Name = "pnlArrive";
            this.pnlArrive.Size = new System.Drawing.Size(743, 53);
            this.pnlArrive.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(31, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(134, 16);
            this.label4.TabIndex = 15;
            this.label4.Text = "Arrive Date / Time";
            // 
            // pnlDepart
            // 
            this.pnlDepart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDepart.Controls.Add(this.label5);
            this.pnlDepart.Controls.Add(this.dtDepart);
            this.pnlDepart.Enabled = false;
            this.pnlDepart.Location = new System.Drawing.Point(20, 301);
            this.pnlDepart.Name = "pnlDepart";
            this.pnlDepart.Size = new System.Drawing.Size(743, 53);
            this.pnlDepart.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(33, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(140, 16);
            this.label5.TabIndex = 19;
            this.label5.Text = "Depart Date / Time";
            // 
            // dtDepart
            // 
            this.dtDepart.DateTime = new System.DateTime(2018, 2, 20, 0, 0, 0, 0);
            this.dtDepart.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Standard;
            this.dtDepart.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDepart.Location = new System.Drawing.Point(173, 16);
            this.dtDepart.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiteralsWithPadding;
            this.dtDepart.MaskInput = "{date} {time}";
            this.dtDepart.Name = "dtDepart";
            this.dtDepart.Size = new System.Drawing.Size(316, 24);
            this.dtDepart.TabIndex = 18;
            this.dtDepart.Value = new System.DateTime(2018, 2, 20, 0, 0, 0, 0);
            // 
            // frmPortOpsArriveDepart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(775, 478);
            this.ControlBox = false;
            this.Controls.Add(this.pnlDepart);
            this.Controls.Add(this.pnlArrive);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grdPortCalls);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDepart);
            this.Controls.Add(this.btnArrive);
            this.Name = "frmPortOpsArriveDepart";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Port Operations: Arrive and Depart Vessels";
            ((System.ComponentModel.ISupportInitialize)(this.grdPortCalls)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtArrive)).EndInit();
            this.pnlArrive.ResumeLayout(false);
            this.pnlArrive.PerformLayout();
            this.pnlDepart.ResumeLayout(false);
            this.pnlDepart.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtDepart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CommonWinCtrls.ucButton btnArrive;
        private CommonWinCtrls.ucButton btnDepart;
        private CommonWinCtrls.ucButton btnCancel;
        private CommonWinCtrls.ucGridEx grdPortCalls;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor dtArrive;
        private System.Windows.Forms.Panel pnlArrive;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel pnlDepart;
        private System.Windows.Forms.Label label5;
        private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor dtDepart;
    }
}