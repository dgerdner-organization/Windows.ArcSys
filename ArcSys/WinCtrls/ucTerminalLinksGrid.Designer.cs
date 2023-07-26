namespace CS2010.ArcSys.WinCtrls
{
	partial class ucTerminalLinksGrid
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			Janus.Windows.GridEX.GridEXLayout grdLinks_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			Janus.Windows.Common.Layouts.JanusLayoutReference grdLinks_DesignTimeLayout_Reference_0 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column4.ButtonImage");
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucTerminalLinksGrid));
			this.grdLinks = new CS2010.CommonWinCtrls.ucGridEx();
			((System.ComponentModel.ISupportInitialize)(this.grdLinks)).BeginInit();
			this.SuspendLayout();
			// 
			// grdLinks
			// 
			this.grdLinks.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.True;
			this.grdLinks.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.True;
			grdLinks_DesignTimeLayout_Reference_0.Instance = ((object)(resources.GetObject("grdLinks_DesignTimeLayout_Reference_0.Instance")));
			grdLinks_DesignTimeLayout.LayoutReferences.AddRange(new Janus.Windows.Common.Layouts.JanusLayoutReference[] {
            grdLinks_DesignTimeLayout_Reference_0});
			grdLinks_DesignTimeLayout.LayoutString = resources.GetString("grdLinks_DesignTimeLayout.LayoutString");
			this.grdLinks.DesignTimeLayout = grdLinks_DesignTimeLayout;
			this.grdLinks.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grdLinks.ExportFileID = null;
			this.grdLinks.GroupByBoxVisible = false;
			this.grdLinks.Location = new System.Drawing.Point(0, 0);
			this.grdLinks.Name = "grdLinks";
			this.grdLinks.NewRowEnterKeyBehavior = Janus.Windows.GridEX.NewRowEnterKeyBehavior.AddRowAndMoveToFirstCellInNewRow;
			this.grdLinks.Size = new System.Drawing.Size(668, 117);
			this.grdLinks.TabIndex = 3;
			this.grdLinks.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003;
			this.grdLinks.ColumnButtonClick += new Janus.Windows.GridEX.ColumnActionEventHandler(this.grdLinks_ColumnButtonClick);
			// 
			// ucTerminalLinksGrid
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.grdLinks);
			this.Name = "ucTerminalLinksGrid";
			this.Size = new System.Drawing.Size(668, 117);
			((System.ComponentModel.ISupportInitialize)(this.grdLinks)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private CS2010.CommonWinCtrls.ucGridEx grdLinks;
	}
}
