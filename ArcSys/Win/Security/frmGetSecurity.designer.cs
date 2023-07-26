namespace CS2010.ArcSys.Win
{
    partial class frmGetSecurity
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
            Janus.Windows.GridEX.GridEXLayout gridEXLayout1 = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGetSecurity));
            Janus.Windows.GridEX.GridEXLayout gridEXLayout2 = new Janus.Windows.GridEX.GridEXLayout();
            this.comboGroup = new CS2010.CommonWinCtrls.ucMultiColumnCombo();
            this.comboObject = new CS2010.CommonWinCtrls.ucMultiColumnCombo();
            this.cbxVisible = new CS2010.CommonWinCtrls.ucCheckBox();
            this.cbxEnabled = new CS2010.CommonWinCtrls.ucCheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.comboGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboObject)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(164, 135);
            this.btnOK.TabIndex = 4;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(252, 135);
            this.btnCancel.TabIndex = 5;
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(252, 179);
            this.btnApply.TabIndex = 6;
            this.btnApply.TabStop = true;
            this.btnApply.UseVisualStyleBackColor = false;
            // 
            // comboGroup
            // 
            gridEXLayout1.LayoutString = resources.GetString("gridEXLayout1.LayoutString");
            this.comboGroup.DesignTimeLayout = gridEXLayout1;
            this.comboGroup.DisplayMember = "group_dsc";
            this.comboGroup.LabelText = "Group";
            this.comboGroup.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.comboGroup.Location = new System.Drawing.Point(77, 31);
            this.comboGroup.Name = "comboGroup";
            this.comboGroup.SaveSettings = false;
            this.comboGroup.SelectedIndex = -1;
            this.comboGroup.SelectedItem = null;
            this.comboGroup.Size = new System.Drawing.Size(250, 20);
            this.comboGroup.TabIndex = 0;
            this.comboGroup.ValueMember = "group_id";
            // 
            // comboObject
            // 
            gridEXLayout2.LayoutString = resources.GetString("gridEXLayout2.LayoutString");
            this.comboObject.DesignTimeLayout = gridEXLayout2;
            this.comboObject.DisplayMember = "Object_dsc";
            this.comboObject.LabelText = "Object";
            this.comboObject.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.comboObject.Location = new System.Drawing.Point(77, 57);
            this.comboObject.Name = "comboObject";
            this.comboObject.SaveSettings = false;
            this.comboObject.SelectedIndex = -1;
            this.comboObject.SelectedItem = null;
            this.comboObject.Size = new System.Drawing.Size(250, 20);
            this.comboObject.TabIndex = 1;
            this.comboObject.ValueMember = "object_id";
            // 
            // cbxVisible
            // 
            this.cbxVisible.Location = new System.Drawing.Point(77, 84);
            this.cbxVisible.Name = "cbxVisible";
            this.cbxVisible.Size = new System.Drawing.Size(104, 24);
            this.cbxVisible.TabIndex = 2;
            this.cbxVisible.Text = "Visible";
            this.cbxVisible.UseVisualStyleBackColor = true;
            this.cbxVisible.YN = "N";
            // 
            // cbxEnabled
            // 
            this.cbxEnabled.Location = new System.Drawing.Point(77, 109);
            this.cbxEnabled.Name = "cbxEnabled";
            this.cbxEnabled.Size = new System.Drawing.Size(104, 24);
            this.cbxEnabled.TabIndex = 3;
            this.cbxEnabled.Text = "Enabled";
            this.cbxEnabled.UseVisualStyleBackColor = true;
            this.cbxEnabled.YN = "N";
            // 
            // frmGetSecurity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(364, 175);
            this.Controls.Add(this.cbxEnabled);
            this.Controls.Add(this.cbxVisible);
            this.Controls.Add(this.comboObject);
            this.Controls.Add(this.comboGroup);
            this.Name = "frmGetSecurity";
            this.Text = "Get Security";
            this.Controls.SetChildIndex(this.btnOK, 0);
            this.Controls.SetChildIndex(this.btnApply, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.comboGroup, 0);
            this.Controls.SetChildIndex(this.comboObject, 0);
            this.Controls.SetChildIndex(this.cbxVisible, 0);
            this.Controls.SetChildIndex(this.cbxEnabled, 0);
            ((System.ComponentModel.ISupportInitialize)(this.comboGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboObject)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CS2010.CommonWinCtrls.ucMultiColumnCombo comboGroup;
        private CS2010.CommonWinCtrls.ucMultiColumnCombo comboObject;
        private CS2010.CommonWinCtrls.ucCheckBox cbxVisible;
        private CS2010.CommonWinCtrls.ucCheckBox cbxEnabled;

    }
}
