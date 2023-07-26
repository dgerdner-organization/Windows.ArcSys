namespace CS2010.ArcSys.Win
{
    partial class frmGetUserGroup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGetUserGroup));
            Janus.Windows.GridEX.GridEXLayout gridEXLayout2 = new Janus.Windows.GridEX.GridEXLayout();
            this.comboGroup = new CS2010.CommonWinCtrls.ucMultiColumnCombo();
            this.comboUser = new CS2010.CommonWinCtrls.ucMultiColumnCombo();
            ((System.ComponentModel.ISupportInitialize)(this.comboGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboUser)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(164, 104);
            this.btnOK.TabIndex = 4;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(252, 104);
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
            this.comboGroup.Location = new System.Drawing.Point(77, 51);
            this.comboGroup.Name = "comboGroup";
            this.comboGroup.SaveSettings = false;
            this.comboGroup.SelectedIndex = -1;
            this.comboGroup.SelectedItem = null;
            this.comboGroup.Size = new System.Drawing.Size(250, 20);
            this.comboGroup.TabIndex = 1;
            this.comboGroup.ValueMember = "group_id";
            // 
            // comboUser
            // 
            gridEXLayout2.LayoutString = resources.GetString("gridEXLayout2.LayoutString");
            this.comboUser.DesignTimeLayout = gridEXLayout2;
            this.comboUser.DisplayMember = "User_nm";
            this.comboUser.LabelText = "User";
            this.comboUser.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.comboUser.Location = new System.Drawing.Point(77, 25);
            this.comboUser.Name = "comboUser";
            this.comboUser.SaveSettings = false;
            this.comboUser.SelectedIndex = -1;
            this.comboUser.SelectedItem = null;
            this.comboUser.Size = new System.Drawing.Size(250, 20);
            this.comboUser.TabIndex = 0;
            this.comboUser.ValueMember = "user_id";
            // 
            // frmGetUserGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(364, 155);
            this.Controls.Add(this.comboUser);
            this.Controls.Add(this.comboGroup);
            this.Name = "frmGetUserGroup";
            this.Text = "Get Security";
            this.Controls.SetChildIndex(this.comboGroup, 0);
            this.Controls.SetChildIndex(this.btnOK, 0);
            this.Controls.SetChildIndex(this.comboUser, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.btnApply, 0);
            ((System.ComponentModel.ISupportInitialize)(this.comboGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboUser)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CS2010.CommonWinCtrls.ucMultiColumnCombo comboGroup;
        private CS2010.CommonWinCtrls.ucMultiColumnCombo comboUser;

    }
}
