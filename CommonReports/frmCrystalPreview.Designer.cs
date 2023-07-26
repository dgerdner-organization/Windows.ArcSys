namespace CS2010.CommonReports
{
	partial class frmCrystalPreview
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
			this.MainViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
			this.btnCollapse = new CS2010.CommonWinCtrls.ucButton();
			this.SuspendLayout();
			// 
			// MainViewer
			// 
			this.MainViewer.ActiveViewIndex = -1;
			this.MainViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.MainViewer.Cursor = System.Windows.Forms.Cursors.Default;
			this.MainViewer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.MainViewer.Location = new System.Drawing.Point(0, 0);
			this.MainViewer.Name = "MainViewer";
			this.MainViewer.SelectionFormula = "";
			this.MainViewer.ShowCloseButton = false;
			this.MainViewer.ShowGroupTreeButton = false;
			this.MainViewer.ShowParameterPanelButton = false;
			this.MainViewer.ShowRefreshButton = false;
			this.MainViewer.Size = new System.Drawing.Size(822, 645);
			this.MainViewer.TabIndex = 0;
			this.MainViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
			this.MainViewer.ViewTimeSelectionFormula = "";
			// 
			// btnCollapse
			// 
			this.btnCollapse.BackColor = System.Drawing.Color.LightGray;
			this.btnCollapse.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
			this.btnCollapse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnCollapse.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnCollapse.Location = new System.Drawing.Point(384, 3);
			this.btnCollapse.Name = "btnCollapse";
			this.btnCollapse.Size = new System.Drawing.Size(75, 24);
			this.btnCollapse.TabIndex = 1;
			this.btnCollapse.Text = "Collapse";
			this.btnCollapse.UseVisualStyleBackColor = false;
			this.btnCollapse.Click += new System.EventHandler(this.btnCollapse_Click);
			// 
			// frmCrystalPreview
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(822, 645);
			this.Controls.Add(this.btnCollapse);
			this.Controls.Add(this.MainViewer);
			this.Name = "frmCrystalPreview";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Crystal Report Preview";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmReportViewer_FormClosed);
			this.Load += new System.EventHandler(this.frmReportViewer_Load);
			this.ResumeLayout(false);

		}

		#endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer MainViewer;
		private CS2010.CommonWinCtrls.ucButton btnCollapse;

	}
}