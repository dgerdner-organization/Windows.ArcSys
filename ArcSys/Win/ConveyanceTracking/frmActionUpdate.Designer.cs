namespace CS2010.ArcSys.Win
{
    partial class frmActionUpdate
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
            Janus.Windows.GridEX.GridEXLayout cmbLocationOLD_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmActionUpdate));
            Janus.Windows.GridEX.GridEXLayout cmbLocation_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            this.dtDate = new CS2010.CommonWinCtrls.ucDateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTag = new CS2010.CommonWinCtrls.ucTextBox();
            this.cmbLocationOLD = new CS2010.ArcSys.WinCtrls.ucLocationCombo();
            this.cmbLocation = new CS2010.ArcSys.WinCtrls.ucLocationCargoTrackingCombo();
            ((System.ComponentModel.ISupportInitialize)(this.cmbLocationOLD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbLocation)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(259, 87);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(259, 116);
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(21, 401);
            this.btnApply.TabStop = true;
            this.btnApply.UseVisualStyleBackColor = false;
            // 
            // dtDate
            // 
            this.dtDate.CustomFormat = "yyyy - MM - dd";
            this.dtDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDate.Location = new System.Drawing.Point(128, 12);
            this.dtDate.Name = "dtDate";
            this.dtDate.Size = new System.Drawing.Size(206, 20);
            this.dtDate.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Date (YYYY-MM-DD):";
            // 
            // txtTag
            // 
            this.txtTag.LabelText = "EITV Tag #:";
            this.txtTag.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtTag.LinkDisabledMessage = "Link Disabled";
            this.txtTag.Location = new System.Drawing.Point(128, 61);
            this.txtTag.Name = "txtTag";
            this.txtTag.Size = new System.Drawing.Size(206, 20);
            this.txtTag.TabIndex = 24;
            // 
            // cmbLocationOLD
            // 
            this.cmbLocationOLD.CodeColumn = "Location_Cd";
            this.cmbLocationOLD.DescriptionColumn = "Location_Dsc";
            cmbLocationOLD_DesignTimeLayout.LayoutString = resources.GetString("cmbLocationOLD_DesignTimeLayout.LayoutString");
            this.cmbLocationOLD.DesignTimeLayout = cmbLocationOLD_DesignTimeLayout;
            this.cmbLocationOLD.DisplayMember = "Location_Cd";
            this.cmbLocationOLD.DisplayType = CS2010.CommonWinCtrls.ComboDisplay.DescriptionOnly;
            this.cmbLocationOLD.LabelText = "Location:";
            this.cmbLocationOLD.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.cmbLocationOLD.Location = new System.Drawing.Point(69, 213);
            this.cmbLocationOLD.Name = "cmbLocationOLD";
            this.cmbLocationOLD.SelectedIndex = -1;
            this.cmbLocationOLD.SelectedItem = null;
            this.cmbLocationOLD.Size = new System.Drawing.Size(206, 20);
            this.cmbLocationOLD.SortType = CS2010.CommonWinCtrls.ComboSortType.Description;
            this.cmbLocationOLD.TabIndex = 26;
            this.cmbLocationOLD.ValueColumn = "Location_Cd";
            this.cmbLocationOLD.ValueMember = "Location_Cd";
            // 
            // cmbLocation
            // 
            this.cmbLocation.CodeColumn = "Location_Cd";
            this.cmbLocation.DescriptionColumn = "Location_Dsc";
            cmbLocation_DesignTimeLayout.LayoutString = resources.GetString("cmbLocation_DesignTimeLayout.LayoutString");
            this.cmbLocation.DesignTimeLayout = cmbLocation_DesignTimeLayout;
            this.cmbLocation.DisplayMember = "Location_Dsc";
            this.cmbLocation.DisplayType = CS2010.CommonWinCtrls.ComboDisplay.DescriptionOnly;
            this.cmbLocation.LabelText = "Location:";
            this.cmbLocation.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.cmbLocation.Location = new System.Drawing.Point(128, 35);
            this.cmbLocation.LocationTypeDisplay = CS2010.ArcSys.WinCtrls.LocationCargoTrackingType.GeoRegion;
            this.cmbLocation.Name = "cmbLocation";
            this.cmbLocation.SelectedIndex = -1;
            this.cmbLocation.SelectedItem = null;
            this.cmbLocation.Size = new System.Drawing.Size(206, 20);
            this.cmbLocation.SortType = CS2010.CommonWinCtrls.ComboSortType.Description;
            this.cmbLocation.TabIndex = 27;
            this.cmbLocation.ValueColumn = "Location_Cd";
            this.cmbLocation.ValueMember = "Location_Cd";
            // 
            // frmActionUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 154);
            this.Controls.Add(this.cmbLocation);
            this.Controls.Add(this.cmbLocationOLD);
            this.Controls.Add(this.txtTag);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtDate);
            this.Name = "frmActionUpdate";
            this.Text = "Action Update ...";
            this.Controls.SetChildIndex(this.btnOK, 0);
            this.Controls.SetChildIndex(this.btnApply, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.dtDate, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtTag, 0);
            this.Controls.SetChildIndex(this.cmbLocationOLD, 0);
            this.Controls.SetChildIndex(this.cmbLocation, 0);
            ((System.ComponentModel.ISupportInitialize)(this.cmbLocationOLD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbLocation)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CommonWinCtrls.ucDateTimePicker dtDate;
        private System.Windows.Forms.Label label1;
        private CommonWinCtrls.ucTextBox txtTag;
        private WinCtrls.ucLocationCombo cmbLocationOLD;
        private WinCtrls.ucLocationCargoTrackingCombo cmbLocation;
    }
}