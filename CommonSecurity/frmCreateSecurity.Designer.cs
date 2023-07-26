namespace CS2010.CommonSecurity
{
	partial class frmCreateSecurity
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
			if( disposing && ( components != null ) )
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
            Janus.Windows.GridEX.GridEXLayout grdChoices_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCreateSecurity));
            Janus.Windows.GridEX.GridEXLayout cmbRenameNew_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout grdOrphans_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            this.ucTabControl1 = new CS2010.CommonWinCtrls.ucTabControl();
            this.tpAllObjects = new System.Windows.Forms.TabPage();
            this.grdChoices = new CS2010.CommonWinCtrls.ucGridEx();
            this.tsObjectsOptions = new CS2010.CommonWinCtrls.ucGridToolStrip();
            this.mnuOptions = new System.Windows.Forms.ToolStripDropDownButton();
            this.mnuCreateObjects = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFilter = new System.Windows.Forms.ToolStripComboBox();
            this.tpOrphans = new System.Windows.Forms.TabPage();
            this.ucPanel2 = new CS2010.CommonWinCtrls.ucPanel();
            this.txtRenameOld = new CS2010.CommonWinCtrls.ucEditBox();
            this.btnDelete = new CS2010.CommonWinCtrls.ucButton();
            this.btnRename = new CS2010.CommonWinCtrls.ucButton();
            this.cmbRenameNew = new CS2010.CommonWinCtrls.ucMultiColumnCombo();
            this.ucPanel1 = new CS2010.CommonWinCtrls.ucPanel();
            this.grdOrphans = new CS2010.CommonWinCtrls.ucGridEx();
            this.ucTabControl1.SuspendLayout();
            this.tpAllObjects.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdChoices)).BeginInit();
            this.tsObjectsOptions.SuspendLayout();
            this.tpOrphans.SuspendLayout();
            this.ucPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbRenameNew)).BeginInit();
            this.ucPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOrphans)).BeginInit();
            this.SuspendLayout();
            // 
            // ucTabControl1
            // 
            this.ucTabControl1.Controls.Add(this.tpAllObjects);
            this.ucTabControl1.Controls.Add(this.tpOrphans);
            this.ucTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucTabControl1.Location = new System.Drawing.Point(0, 0);
            this.ucTabControl1.Name = "ucTabControl1";
            this.ucTabControl1.SelectedIndex = 0;
            this.ucTabControl1.Size = new System.Drawing.Size(709, 438);
            this.ucTabControl1.TabIndex = 12;
            // 
            // tpAllObjects
            // 
            this.tpAllObjects.Controls.Add(this.grdChoices);
            this.tpAllObjects.Controls.Add(this.tsObjectsOptions);
            this.tpAllObjects.Location = new System.Drawing.Point(4, 22);
            this.tpAllObjects.Name = "tpAllObjects";
            this.tpAllObjects.Padding = new System.Windows.Forms.Padding(3);
            this.tpAllObjects.Size = new System.Drawing.Size(701, 412);
            this.tpAllObjects.TabIndex = 0;
            this.tpAllObjects.Text = "All Objects";
            this.tpAllObjects.UseVisualStyleBackColor = true;
            // 
            // grdChoices
            // 
            grdChoices_DesignTimeLayout.LayoutString = resources.GetString("grdChoices_DesignTimeLayout.LayoutString");
            this.grdChoices.DesignTimeLayout = grdChoices_DesignTimeLayout;
            this.grdChoices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdChoices.ExportFileID = null;
            this.grdChoices.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.grdChoices.GroupByBoxVisible = false;
            this.grdChoices.Location = new System.Drawing.Point(3, 28);
            this.grdChoices.Name = "grdChoices";
            this.grdChoices.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
            this.grdChoices.Size = new System.Drawing.Size(695, 381);
            this.grdChoices.TabIndex = 3;
            // 
            // tsObjectsOptions
            // 
            this.tsObjectsOptions.GridObject = null;
            this.tsObjectsOptions.HideAddButton = true;
            this.tsObjectsOptions.HideDeleteButton = true;
            this.tsObjectsOptions.HideEditButton = true;
            this.tsObjectsOptions.HideExportMenu = true;
            this.tsObjectsOptions.HidePrintMenu = true;
            this.tsObjectsOptions.HideSeparator = true;
            this.tsObjectsOptions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuOptions,
            this.mnuFilter});
            this.tsObjectsOptions.Location = new System.Drawing.Point(3, 3);
            this.tsObjectsOptions.Name = "tsObjectsOptions";
            this.tsObjectsOptions.Size = new System.Drawing.Size(695, 25);
            this.tsObjectsOptions.TabIndex = 4;
            this.tsObjectsOptions.Text = "ucGridToolStrip1";
            // 
            // mnuOptions
            // 
            this.mnuOptions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.mnuOptions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCreateObjects});
            this.mnuOptions.Image = ((System.Drawing.Image)(resources.GetObject("mnuOptions.Image")));
            this.mnuOptions.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuOptions.Name = "mnuOptions";
            this.mnuOptions.Size = new System.Drawing.Size(57, 22);
            this.mnuOptions.Text = "Options";
            // 
            // mnuCreateObjects
            // 
            this.mnuCreateObjects.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.mnuCreateObjects.Name = "mnuCreateObjects";
            this.mnuCreateObjects.Size = new System.Drawing.Size(199, 22);
            this.mnuCreateObjects.Text = "Create selected objects";
            this.mnuCreateObjects.Click += new System.EventHandler(this.mnuCreateObjects_Click);
            // 
            // mnuFilter
            // 
            this.mnuFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mnuFilter.Items.AddRange(new object[] {
            "1 All Objects",
            "2 Existing Only",
            "3 Non-Existing Only"});
            this.mnuFilter.Name = "mnuFilter";
            this.mnuFilter.Size = new System.Drawing.Size(121, 25);
            this.mnuFilter.SelectedIndexChanged += new System.EventHandler(this.mnuFilter_SelectedIndexChanged);
            // 
            // tpOrphans
            // 
            this.tpOrphans.Controls.Add(this.ucPanel2);
            this.tpOrphans.Controls.Add(this.ucPanel1);
            this.tpOrphans.Location = new System.Drawing.Point(4, 22);
            this.tpOrphans.Name = "tpOrphans";
            this.tpOrphans.Padding = new System.Windows.Forms.Padding(3);
            this.tpOrphans.Size = new System.Drawing.Size(701, 412);
            this.tpOrphans.TabIndex = 1;
            this.tpOrphans.Text = "Orphaned Objects";
            this.tpOrphans.UseVisualStyleBackColor = true;
            // 
            // ucPanel2
            // 
            this.ucPanel2.Controls.Add(this.txtRenameOld);
            this.ucPanel2.Controls.Add(this.btnDelete);
            this.ucPanel2.Controls.Add(this.btnRename);
            this.ucPanel2.Controls.Add(this.cmbRenameNew);
            this.ucPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ucPanel2.Location = new System.Drawing.Point(3, 333);
            this.ucPanel2.Name = "ucPanel2";
            this.ucPanel2.Size = new System.Drawing.Size(695, 76);
            this.ucPanel2.TabIndex = 1;
            // 
            // txtRenameOld
            // 
            this.txtRenameOld.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRenameOld.LabelText = "Rename this orphan:";
            this.txtRenameOld.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.txtRenameOld.Location = new System.Drawing.Point(403, 8);
            this.txtRenameOld.Name = "txtRenameOld";
            this.txtRenameOld.Size = new System.Drawing.Size(252, 20);
            this.txtRenameOld.TabIndex = 9;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(3, 10);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(88, 23);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnRename
            // 
            this.btnRename.Location = new System.Drawing.Point(625, 33);
            this.btnRename.Name = "btnRename";
            this.btnRename.Size = new System.Drawing.Size(30, 23);
            this.btnRename.TabIndex = 8;
            this.btnRename.Text = "OK";
            this.btnRename.UseVisualStyleBackColor = true;
            this.btnRename.Click += new System.EventHandler(this.btnRename_Click);
            // 
            // cmbRenameNew
            // 
            cmbRenameNew_DesignTimeLayout.LayoutString = resources.GetString("cmbRenameNew_DesignTimeLayout.LayoutString");
            this.cmbRenameNew.DesignTimeLayout = cmbRenameNew_DesignTimeLayout;
            this.cmbRenameNew.DisplayMember = "sName";
            this.cmbRenameNew.LabelText = "To this object:";
            this.cmbRenameNew.LabelType = CS2010.CommonWinCtrls.TextLabelType.Label;
            this.cmbRenameNew.Location = new System.Drawing.Point(403, 34);
            this.cmbRenameNew.Name = "cmbRenameNew";
            this.cmbRenameNew.SelectedIndex = -1;
            this.cmbRenameNew.SelectedItem = null;
            this.cmbRenameNew.Size = new System.Drawing.Size(216, 20);
            this.cmbRenameNew.TabIndex = 11;
            this.cmbRenameNew.ValueMember = "sName";
            // 
            // ucPanel1
            // 
            this.ucPanel1.Controls.Add(this.grdOrphans);
            this.ucPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucPanel1.Location = new System.Drawing.Point(3, 3);
            this.ucPanel1.Name = "ucPanel1";
            this.ucPanel1.Size = new System.Drawing.Size(695, 406);
            this.ucPanel1.TabIndex = 0;
            // 
            // grdOrphans
            // 
            grdOrphans_DesignTimeLayout.LayoutString = resources.GetString("grdOrphans_DesignTimeLayout.LayoutString");
            this.grdOrphans.DesignTimeLayout = grdOrphans_DesignTimeLayout;
            this.grdOrphans.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdOrphans.ExportFileID = null;
            this.grdOrphans.GroupByBoxVisible = false;
            this.grdOrphans.GroupMode = Janus.Windows.GridEX.GroupMode.Collapsed;
            this.grdOrphans.Location = new System.Drawing.Point(0, 0);
            this.grdOrphans.Name = "grdOrphans";
            this.grdOrphans.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
            this.grdOrphans.SelectOnExpand = false;
            this.grdOrphans.Size = new System.Drawing.Size(695, 406);
            this.grdOrphans.TabIndex = 4;
            this.grdOrphans.SelectionChanged += new System.EventHandler(this.grdOrphans_SelectionChanged);
            // 
            // frmCreateSecurity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 438);
            this.Controls.Add(this.ucTabControl1);
            this.Name = "frmCreateSecurity";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Create Security";
            this.ucTabControl1.ResumeLayout(false);
            this.tpAllObjects.ResumeLayout(false);
            this.tpAllObjects.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdChoices)).EndInit();
            this.tsObjectsOptions.ResumeLayout(false);
            this.tsObjectsOptions.PerformLayout();
            this.tpOrphans.ResumeLayout(false);
            this.ucPanel2.ResumeLayout(false);
            this.ucPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbRenameNew)).EndInit();
            this.ucPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdOrphans)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

        private CS2010.CommonWinCtrls.ucGridEx grdChoices;
        private CS2010.CommonWinCtrls.ucGridEx grdOrphans;
        private CS2010.CommonWinCtrls.ucButton btnDelete;
        private CS2010.CommonWinCtrls.ucButton btnRename;
        private CS2010.CommonWinCtrls.ucEditBox txtRenameOld;
        private CS2010.CommonWinCtrls.ucMultiColumnCombo cmbRenameNew;
        private CS2010.CommonWinCtrls.ucTabControl ucTabControl1;
        private System.Windows.Forms.TabPage tpAllObjects;
        private System.Windows.Forms.TabPage tpOrphans;
        private CS2010.CommonWinCtrls.ucPanel ucPanel2;
        private CS2010.CommonWinCtrls.ucPanel ucPanel1;
        private CS2010.CommonWinCtrls.ucGridToolStrip tsObjectsOptions;
        private System.Windows.Forms.ToolStripDropDownButton mnuOptions;
        private System.Windows.Forms.ToolStripMenuItem mnuCreateObjects;
        private System.Windows.Forms.ToolStripComboBox mnuFilter;
	}
}