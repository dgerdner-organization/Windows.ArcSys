namespace CS2008.AVSS.Win
{
	partial class frmUpdateVesselARC
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
			if( disposing && (components != null) )
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
			Janus.Windows.GridEX.GridEXLayout grdVesselPortCalls_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUpdateVesselARC));
			Janus.Windows.GridEX.GridEXLayout gridEXLayout1 = new Janus.Windows.GridEX.GridEXLayout();
			Janus.Windows.GridEX.GridEXLayout grdBerthActivity_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			this.tsARC = new CS2005.CommonWinCtrls.ucGridToolStrip();
			this.txtFullVoyage = new CS2005.CommonWinCtrls.ucTextBox();
			this.ucButton1 = new CS2005.CommonWinCtrls.ucButton();
			((System.ComponentModel.ISupportInitialize)(this.grdVesselPortCalls)).BeginInit();
			this.ucSplitContainer2.Panel1.SuspendLayout();
			this.ucSplitContainer2.Panel2.SuspendLayout();
			this.ucSplitContainer2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.comboVessel)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grdBerthActivity)).BeginInit();
			this.SuspendLayout();
			// 
			// grdVesselPortCalls
			// 
			grdVesselPortCalls_DesignTimeLayout.LayoutString = resources.GetString("grdVesselPortCalls_DesignTimeLayout.LayoutString");
			this.grdVesselPortCalls.DesignTimeLayout = grdVesselPortCalls_DesignTimeLayout;
			this.grdVesselPortCalls.Location = new System.Drawing.Point(0, 50);
			this.grdVesselPortCalls.Size = new System.Drawing.Size(810, 254);
			// 
			// ucSplitContainer2
			// 
			// 
			// ucSplitContainer2.Panel1
			// 
			this.ucSplitContainer2.Panel1.Controls.Add(this.tsARC);
			this.ucSplitContainer2.Size = new System.Drawing.Size(810, 444);
			this.ucSplitContainer2.SplitterDistance = 304;
			// 
			// comboVessel
			// 
			gridEXLayout1.LayoutString = resources.GetString("gridEXLayout1.LayoutString");
			this.comboVessel.DesignTimeLayout = gridEXLayout1;
			this.comboVessel.Location = new System.Drawing.Point(576, 144);
			this.comboVessel.Visible = false;
			// 
			// grdBerthActivity
			// 
			grdBerthActivity_DesignTimeLayout.LayoutString = resources.GetString("grdBerthActivity_DesignTimeLayout.LayoutString");
			this.grdBerthActivity.DesignTimeLayout = grdBerthActivity_DesignTimeLayout;
			this.grdBerthActivity.Size = new System.Drawing.Size(810, 111);
			// 
			// txtFromDt
			// 
			this.txtFromDt.Location = new System.Drawing.Point(618, 144);
			this.txtFromDt.Text = "2009-08-20";
			this.txtFromDt.Value = new System.DateTime(2009, 8, 20, 0, 0, 0, 0);
			this.txtFromDt.Visible = false;
			// 
			// txtToDt
			// 
			this.txtToDt.Location = new System.Drawing.Point(618, 144);
			this.txtToDt.Visible = false;
			// 
			// txtVoyage
			// 
			this.txtVoyage.Location = new System.Drawing.Point(70, 22);
			// 
			// tsARC
			// 
			this.tsARC.GridObject = null;
			this.tsARC.HideDeleteButton = true;
			this.tsARC.HideExportMenu = true;
			this.tsARC.HidePrintMenu = true;
			this.tsARC.HideSeparator = true;
			this.tsARC.Location = new System.Drawing.Point(0, 0);
			this.tsARC.Name = "tsARC";
			this.tsARC.Size = new System.Drawing.Size(810, 25);
			this.tsARC.TabIndex = 2;
			this.tsARC.Text = "ucGridToolStrip3";
			this.tsARC.TextAddButton = "Add Transshipment";
			this.tsARC.TextEditButton = "&Update Military Voyage#";
			this.tsARC.ClickAdd += new System.EventHandler(this.tsARC_ClickAdd);
			this.tsARC.ClickEdit += new System.EventHandler(this.tsARC_ClickEdit);
			// 
			// txtFullVoyage
			// 
			this.txtFullVoyage.LabelText = "Voyage (TTvvv)";
			this.txtFullVoyage.LabelType = CS2005.CommonWinCtrls.TextLabelType.Label;
			this.txtFullVoyage.LinkDisabledMessage = "Link Disabled";
			this.txtFullVoyage.Location = new System.Drawing.Point(83, 23);
			this.txtFullVoyage.Name = "txtFullVoyage";
			this.txtFullVoyage.Size = new System.Drawing.Size(100, 20);
			this.txtFullVoyage.TabIndex = 0;
			// 
			// ucButton1
			// 
			this.ucButton1.Location = new System.Drawing.Point(190, 23);
			this.ucButton1.Name = "ucButton1";
			this.ucButton1.Size = new System.Drawing.Size(75, 23);
			this.ucButton1.TabIndex = 1;
			this.ucButton1.Text = "Search";
			this.ucButton1.UseVisualStyleBackColor = true;
			// 
			// frmUpdateVesselARC
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.ClientSize = new System.Drawing.Size(810, 511);
			this.Name = "frmUpdateVesselARC";
			this.Load += new System.EventHandler(this.frmUpdateVesselARC_Load);
			((System.ComponentModel.ISupportInitialize)(this.grdVesselPortCalls)).EndInit();
			this.ucSplitContainer2.Panel1.ResumeLayout(false);
			this.ucSplitContainer2.Panel1.PerformLayout();
			this.ucSplitContainer2.Panel2.ResumeLayout(false);
			this.ucSplitContainer2.Panel2.PerformLayout();
			this.ucSplitContainer2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.comboVessel)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grdBerthActivity)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private CS2005.CommonWinCtrls.ucGridToolStrip tsARC;
		private CS2005.CommonWinCtrls.ucTextBox txtFullVoyage;
		private CS2005.CommonWinCtrls.ucButton ucButton1;
	}
}
