namespace CS2010.ArcSys.Win
{
	partial class frmDatabaseExceptions
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
			Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
			this.sbbProgressMeter = new System.Windows.Forms.ToolStripProgressBar();
			this.sbbProgressCaption = new System.Windows.Forms.ToolStripStatusLabel();
			this.sbrChild = new System.Windows.Forms.StatusStrip();
			this.btnSearch = new CS2010.CommonWinCtrls.ucButton();
			this.infOptionSet = new Infragistics.Win.UltraWinEditors.UltraOptionSet();
			this.sbrChild.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.infOptionSet)).BeginInit();
			this.SuspendLayout();
			// 
			// sbbProgressMeter
			// 
			this.sbbProgressMeter.Name = "sbbProgressMeter";
			this.sbbProgressMeter.Size = new System.Drawing.Size(100, 16);
			this.sbbProgressMeter.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
			// 
			// sbbProgressCaption
			// 
			this.sbbProgressCaption.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.sbbProgressCaption.IsLink = true;
			this.sbbProgressCaption.Name = "sbbProgressCaption";
			this.sbbProgressCaption.Size = new System.Drawing.Size(223, 17);
			this.sbbProgressCaption.Text = "Searching... (Click here to cancel the search)";
			// 
			// sbrChild
			// 
			this.sbrChild.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sbbProgressCaption,
            this.sbbProgressMeter});
			this.sbrChild.Location = new System.Drawing.Point(0, 261);
			this.sbrChild.Name = "sbrChild";
			this.sbrChild.Size = new System.Drawing.Size(654, 22);
			this.sbrChild.TabIndex = 4;
			this.sbrChild.Text = "Search Available Main Status Strip";
			this.sbrChild.Visible = false;
			// 
			// btnSearch
			// 
			this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnSearch.Location = new System.Drawing.Point(12, 253);
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Size = new System.Drawing.Size(75, 23);
			this.btnSearch.TabIndex = 1;
			this.btnSearch.Text = "Search";
			this.btnSearch.UseVisualStyleBackColor = true;
			this.btnSearch.Click += new System.EventHandler(this.tbbSearch_Click);
			// 
			// infOptionSet
			// 
			this.infOptionSet.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.infOptionSet.GlyphInfo = Infragistics.Win.UIElementDrawParams.StandardRadioButtonGlyphInfo;
			valueListItem2.DataValue = "Default Item";
			valueListItem2.DisplayText = "Default Item";
			this.infOptionSet.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem2});
			this.infOptionSet.ItemSpacingHorizontal = 10;
			this.infOptionSet.ItemSpacingVertical = 15;
			this.infOptionSet.Location = new System.Drawing.Point(2, 12);
			this.infOptionSet.Name = "infOptionSet";
			this.infOptionSet.Size = new System.Drawing.Size(630, 235);
			this.infOptionSet.TabIndex = 0;
			// 
			// frmDatabaseExceptions
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(654, 283);
			this.Controls.Add(this.btnSearch);
			this.Controls.Add(this.infOptionSet);
			this.Controls.Add(this.sbrChild);
			this.Name = "frmDatabaseExceptions";
			this.Text = "Database Exceptions";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDatabaseExceptions_FormClosing);
			this.Load += new System.EventHandler(this.frmDatabaseExceptions_Load);
			this.sbrChild.ResumeLayout(false);
			this.sbrChild.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.infOptionSet)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStripProgressBar sbbProgressMeter;
		private System.Windows.Forms.ToolStripStatusLabel sbbProgressCaption;
		private System.Windows.Forms.StatusStrip sbrChild;
		private Infragistics.Win.UltraWinEditors.UltraOptionSet infOptionSet;
		private CommonWinCtrls.ucButton btnSearch;
	}
}