namespace CS2010.ArcSys.Win
{
	partial class frmCustomsSubmission
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
			Janus.Windows.GridEX.GridEXLayout grdAvail_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCustomsSubmission));
			Janus.Windows.GridEX.GridEXLayout grdHist_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			this.tbrMain = new System.Windows.Forms.ToolStrip();
			this.tbbSearch = new System.Windows.Forms.ToolStripButton();
			this.tbbN1 = new System.Windows.Forms.ToolStripSeparator();
			this.tbbSubmit = new System.Windows.Forms.ToolStripButton();
			this.tbbN2 = new System.Windows.Forms.ToolStripSeparator();
			this.tbbIgnore = new System.Windows.Forms.ToolStripButton();
			this.sbrChild = new System.Windows.Forms.StatusStrip();
			this.sbbProgressCaption = new System.Windows.Forms.ToolStripStatusLabel();
			this.sbbProgressMeter = new System.Windows.Forms.ToolStripProgressBar();
			this.grdAvail = new CS2010.CommonWinCtrls.ucGridEx();
			this.tabMain = new System.Windows.Forms.TabControl();
			this.tpgAvail = new System.Windows.Forms.TabPage();
			this.tpgHist = new System.Windows.Forms.TabPage();
			this.grdHist = new CS2010.CommonWinCtrls.ucGridEx();
			this.tbrMain.SuspendLayout();
			this.sbrChild.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdAvail)).BeginInit();
			this.tabMain.SuspendLayout();
			this.tpgAvail.SuspendLayout();
			this.tpgHist.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdHist)).BeginInit();
			this.SuspendLayout();
			// 
			// tbrMain
			// 
			this.tbrMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbbSearch,
            this.tbbN1,
            this.tbbSubmit,
            this.tbbN2,
            this.tbbIgnore});
			this.tbrMain.Location = new System.Drawing.Point(0, 0);
			this.tbrMain.Name = "tbrMain";
			this.tbrMain.Size = new System.Drawing.Size(1006, 25);
			this.tbrMain.TabIndex = 0;
			this.tbrMain.Text = "Search Available Main Toolbar";
			// 
			// tbbSearch
			// 
			this.tbbSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tbbSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tbbSearch.Name = "tbbSearch";
			this.tbbSearch.Size = new System.Drawing.Size(52, 22);
			this.tbbSearch.Text = "&Search";
			this.tbbSearch.Click += new System.EventHandler(this.tbbSearch_Click);
			// 
			// tbbN1
			// 
			this.tbbN1.Name = "tbbN1";
			this.tbbN1.Size = new System.Drawing.Size(6, 25);
			// 
			// tbbSubmit
			// 
			this.tbbSubmit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tbbSubmit.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tbbSubmit.Name = "tbbSubmit";
			this.tbbSubmit.Size = new System.Drawing.Size(52, 22);
			this.tbbSubmit.Text = "Su&bmit";
			this.tbbSubmit.Click += new System.EventHandler(this.tbbSubmit_Click);
			// 
			// tbbN2
			// 
			this.tbbN2.Name = "tbbN2";
			this.tbbN2.Size = new System.Drawing.Size(6, 25);
			// 
			// tbbIgnore
			// 
			this.tbbIgnore.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tbbIgnore.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tbbIgnore.Name = "tbbIgnore";
			this.tbbIgnore.Size = new System.Drawing.Size(86, 22);
			this.tbbIgnore.Text = "&Not Required";
			this.tbbIgnore.Click += new System.EventHandler(this.tbbIgnore_Click);
			// 
			// sbrChild
			// 
			this.sbrChild.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sbbProgressCaption,
            this.sbbProgressMeter});
			this.sbrChild.Location = new System.Drawing.Point(0, 702);
			this.sbrChild.Name = "sbrChild";
			this.sbrChild.Size = new System.Drawing.Size(1006, 22);
			this.sbrChild.TabIndex = 1;
			this.sbrChild.Text = "Search Available Main Status Strip";
			this.sbrChild.Visible = false;
			// 
			// sbbProgressCaption
			// 
			this.sbbProgressCaption.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.sbbProgressCaption.IsLink = true;
			this.sbbProgressCaption.Name = "sbbProgressCaption";
			this.sbbProgressCaption.Size = new System.Drawing.Size(266, 17);
			this.sbbProgressCaption.Text = "Searching... (Click here to cancel the search)";
			this.sbbProgressCaption.Click += new System.EventHandler(this.sbbProgressCaption_Click);
			// 
			// sbbProgressMeter
			// 
			this.sbbProgressMeter.Name = "sbbProgressMeter";
			this.sbbProgressMeter.Size = new System.Drawing.Size(100, 16);
			this.sbbProgressMeter.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
			// 
			// grdAvail
			// 
			this.grdAvail.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
			this.grdAvail.AllowRemoveColumns = Janus.Windows.GridEX.InheritableBoolean.True;
			this.grdAvail.BorderStyle = Janus.Windows.GridEX.BorderStyle.Flat;
			grdAvail_DesignTimeLayout.LayoutString = resources.GetString("grdAvail_DesignTimeLayout.LayoutString");
			this.grdAvail.DesignTimeLayout = grdAvail_DesignTimeLayout;
			this.grdAvail.DisplayFieldChooser = true;
			this.grdAvail.DisplayFieldChooserChildren = true;
			this.grdAvail.DisplayFontSelector = true;
			this.grdAvail.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grdAvail.EnterKeyBehavior = Janus.Windows.GridEX.EnterKeyBehavior.None;
			this.grdAvail.ExportFileID = "AvailableCustoms";
			this.grdAvail.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
			this.grdAvail.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown;
			this.grdAvail.FilterRowFormatStyle.BackColor = System.Drawing.Color.AliceBlue;
			this.grdAvail.FilterRowFormatStyle.BackColorGradient = System.Drawing.Color.PowderBlue;
			this.grdAvail.FilterRowFormatStyle.BackgroundGradientMode = Janus.Windows.GridEX.BackgroundGradientMode.Vertical;
			this.grdAvail.FilterRowUpdateMode = Janus.Windows.GridEX.FilterRowUpdateMode.WhenValueChanges;
			this.grdAvail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.grdAvail.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
			this.grdAvail.HideColumnsWhenGrouped = Janus.Windows.GridEX.InheritableBoolean.True;
			this.grdAvail.Location = new System.Drawing.Point(3, 3);
			this.grdAvail.Name = "grdAvail";
			this.grdAvail.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
			this.grdAvail.RepeatHeaders = Janus.Windows.GridEX.InheritableBoolean.False;
			this.grdAvail.Size = new System.Drawing.Size(992, 665);
			this.grdAvail.TabIndex = 2;
			this.grdAvail.TabKeyBehavior = Janus.Windows.GridEX.TabKeyBehavior.ControlNavigation;
			this.grdAvail.TableHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
			this.grdAvail.UseGroupRowSelector = true;
			this.grdAvail.DoubleClick += new System.EventHandler(this.grdResults_DoubleClick);
			this.grdAvail.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdResults_KeyDown);
			// 
			// tabMain
			// 
			this.tabMain.Controls.Add(this.tpgAvail);
			this.tabMain.Controls.Add(this.tpgHist);
			this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tabMain.Location = new System.Drawing.Point(0, 25);
			this.tabMain.Name = "tabMain";
			this.tabMain.SelectedIndex = 0;
			this.tabMain.Size = new System.Drawing.Size(1006, 699);
			this.tabMain.TabIndex = 3;
			// 
			// tpgAvail
			// 
			this.tpgAvail.Controls.Add(this.grdAvail);
			this.tpgAvail.Location = new System.Drawing.Point(4, 24);
			this.tpgAvail.Name = "tpgAvail";
			this.tpgAvail.Padding = new System.Windows.Forms.Padding(3);
			this.tpgAvail.Size = new System.Drawing.Size(998, 671);
			this.tpgAvail.TabIndex = 0;
			this.tpgAvail.Text = "Available";
			this.tpgAvail.UseVisualStyleBackColor = true;
			// 
			// tpgHist
			// 
			this.tpgHist.Controls.Add(this.grdHist);
			this.tpgHist.Location = new System.Drawing.Point(4, 24);
			this.tpgHist.Name = "tpgHist";
			this.tpgHist.Padding = new System.Windows.Forms.Padding(3);
			this.tpgHist.Size = new System.Drawing.Size(998, 671);
			this.tpgHist.TabIndex = 1;
			this.tpgHist.Text = "History";
			this.tpgHist.UseVisualStyleBackColor = true;
			// 
			// grdHist
			// 
			this.grdHist.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
			this.grdHist.AllowRemoveColumns = Janus.Windows.GridEX.InheritableBoolean.True;
			this.grdHist.BorderStyle = Janus.Windows.GridEX.BorderStyle.Flat;
			grdHist_DesignTimeLayout.LayoutString = resources.GetString("grdHist_DesignTimeLayout.LayoutString");
			this.grdHist.DesignTimeLayout = grdHist_DesignTimeLayout;
			this.grdHist.DisplayFieldChooser = true;
			this.grdHist.DisplayFieldChooserChildren = true;
			this.grdHist.DisplayFontSelector = true;
			this.grdHist.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grdHist.EnterKeyBehavior = Janus.Windows.GridEX.EnterKeyBehavior.None;
			this.grdHist.ExportFileID = "CustomsHistory";
			this.grdHist.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
			this.grdHist.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown;
			this.grdHist.FilterRowFormatStyle.BackColor = System.Drawing.Color.AliceBlue;
			this.grdHist.FilterRowFormatStyle.BackColorGradient = System.Drawing.Color.PowderBlue;
			this.grdHist.FilterRowFormatStyle.BackgroundGradientMode = Janus.Windows.GridEX.BackgroundGradientMode.Vertical;
			this.grdHist.FilterRowUpdateMode = Janus.Windows.GridEX.FilterRowUpdateMode.WhenValueChanges;
			this.grdHist.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
			this.grdHist.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
			this.grdHist.HideColumnsWhenGrouped = Janus.Windows.GridEX.InheritableBoolean.True;
			this.grdHist.Location = new System.Drawing.Point(3, 3);
			this.grdHist.Name = "grdHist";
			this.grdHist.OriginalNewPosition = Janus.Windows.GridEX.NewRowPosition.Default;
			this.grdHist.RepeatHeaders = Janus.Windows.GridEX.InheritableBoolean.False;
			this.grdHist.Size = new System.Drawing.Size(992, 665);
			this.grdHist.TabIndex = 3;
			this.grdHist.TabKeyBehavior = Janus.Windows.GridEX.TabKeyBehavior.ControlNavigation;
			this.grdHist.TableHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
			this.grdHist.UseGroupRowSelector = true;
			// 
			// frmCustomsSubmission
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1006, 724);
			this.Controls.Add(this.tabMain);
			this.Controls.Add(this.sbrChild);
			this.Controls.Add(this.tbrMain);
			this.Name = "frmCustomsSubmission";
			this.Text = "Customs Submission";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCustomsSubmission_FormClosing);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmCustomsSubmission_FormClosed);
			this.Load += new System.EventHandler(this.frmCustomsSubmission_Load);
			this.tbrMain.ResumeLayout(false);
			this.tbrMain.PerformLayout();
			this.sbrChild.ResumeLayout(false);
			this.sbrChild.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdAvail)).EndInit();
			this.tabMain.ResumeLayout(false);
			this.tpgAvail.ResumeLayout(false);
			this.tpgHist.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.grdHist)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip tbrMain;
		private System.Windows.Forms.StatusStrip sbrChild;
		private System.Windows.Forms.ToolStripStatusLabel sbbProgressCaption;
		private System.Windows.Forms.ToolStripProgressBar sbbProgressMeter;
		private CommonWinCtrls.ucGridEx grdAvail;
		private System.Windows.Forms.ToolStripButton tbbSearch;
		private System.Windows.Forms.TabControl tabMain;
		private System.Windows.Forms.TabPage tpgAvail;
		private System.Windows.Forms.TabPage tpgHist;
		private CommonWinCtrls.ucGridEx grdHist;
		private System.Windows.Forms.ToolStripSeparator tbbN1;
		private System.Windows.Forms.ToolStripButton tbbSubmit;
		private System.Windows.Forms.ToolStripSeparator tbbN2;
		private System.Windows.Forms.ToolStripButton tbbIgnore;
	}
}