namespace CS2010.CommonWinCtrls
{
	partial class ucGridEx
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

		#region Component Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this._cnuGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.cnuExport = new System.Windows.Forms.ToolStripMenuItem();
			this.cnuExportAs = new System.Windows.Forms.ToolStripMenuItem();
			this.cnuGridN1 = new System.Windows.Forms.ToolStripSeparator();
			this.cnuPreviewPort = new System.Windows.Forms.ToolStripMenuItem();
			this.cnuPreviewLand = new System.Windows.Forms.ToolStripMenuItem();
			this.cnuGridN2 = new System.Windows.Forms.ToolStripSeparator();
			this.cnuPrintPort = new System.Windows.Forms.ToolStripMenuItem();
			this.cnuPrintLand = new System.Windows.Forms.ToolStripMenuItem();
			this.cnuGridN3 = new System.Windows.Forms.ToolStripSeparator();
			this.cnuExpandAll = new System.Windows.Forms.ToolStripMenuItem();
			this.cnuExpandGroup = new System.Windows.Forms.ToolStripMenuItem();
			this.cnuCollapseAll = new System.Windows.Forms.ToolStripMenuItem();
			this.cnuCollapseGroup = new System.Windows.Forms.ToolStripMenuItem();
			this.cnuGridN4 = new System.Windows.Forms.ToolStripSeparator();
			this.cnuFieldChooser = new System.Windows.Forms.ToolStripMenuItem();
			this.cnuGridN5 = new System.Windows.Forms.ToolStripSeparator();
			this.cnuFontSelector = new System.Windows.Forms.ToolStripMenuItem();
			this.cnuGridCopySeparator = new System.Windows.Forms.ToolStripSeparator();
			this.cnuCopyAll = new System.Windows.Forms.ToolStripMenuItem();
			this.cnuGridCopyPasteSeparator = new System.Windows.Forms.ToolStripSeparator();
			this.cnuCopyCell = new System.Windows.Forms.ToolStripMenuItem();
			this.cnuPaste = new System.Windows.Forms.ToolStripMenuItem();
			this._Exporter = new CS2010.CommonWinCtrls.ucGridEXExporter(this.components);
			this._PrintDoc = new CS2010.CommonWinCtrls.ucGridEXPrintDocument(this.components);
			this._cnuGrid.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
			this.SuspendLayout();
			// 
			// _cnuGrid
			// 
			this._cnuGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cnuExport,
            this.cnuExportAs,
            this.cnuGridN1,
            this.cnuPreviewPort,
            this.cnuPreviewLand,
            this.cnuGridN2,
            this.cnuPrintPort,
            this.cnuPrintLand,
            this.cnuGridN3,
            this.cnuExpandAll,
            this.cnuExpandGroup,
            this.cnuCollapseAll,
            this.cnuCollapseGroup,
            this.cnuGridN4,
            this.cnuFieldChooser,
            this.cnuGridN5,
            this.cnuFontSelector,
            this.cnuGridCopySeparator,
            this.cnuCopyAll,
            this.cnuGridCopyPasteSeparator,
            this.cnuCopyCell,
            this.cnuPaste});
			this._cnuGrid.Name = "contextMenuStrip1";
			this._cnuGrid.Size = new System.Drawing.Size(190, 398);
			this._cnuGrid.Closed += new System.Windows.Forms.ToolStripDropDownClosedEventHandler(this._cnuGrid_Closed);
			this._cnuGrid.Opening += new System.ComponentModel.CancelEventHandler(this._cnuGrid_Opening);
			// 
			// cnuExport
			// 
			this.cnuExport.Name = "cnuExport";
			this.cnuExport.Size = new System.Drawing.Size(189, 22);
			this.cnuExport.Text = "Export...";
			this.cnuExport.ToolTipText = "Export grid contents to a file";
			this.cnuExport.Click += new System.EventHandler(this.cnuExport_Click);
			// 
			// cnuExportAs
			// 
			this.cnuExportAs.Name = "cnuExportAs";
			this.cnuExportAs.Size = new System.Drawing.Size(189, 22);
			this.cnuExportAs.Text = "Export As...";
			this.cnuExportAs.ToolTipText = "Export grid contents to a file allowing specification of a file name";
			this.cnuExportAs.Click += new System.EventHandler(this.cnuExportAs_Click);
			// 
			// cnuGridN1
			// 
			this.cnuGridN1.Name = "cnuGridN1";
			this.cnuGridN1.Size = new System.Drawing.Size(186, 6);
			// 
			// cnuPreviewPort
			// 
			this.cnuPreviewPort.Name = "cnuPreviewPort";
			this.cnuPreviewPort.Size = new System.Drawing.Size(189, 22);
			this.cnuPreviewPort.Text = "Preview Portrait";
			this.cnuPreviewPort.ToolTipText = "Print preview (Portrait mode)";
			this.cnuPreviewPort.Click += new System.EventHandler(this.cnuPreviewPort_Click);
			// 
			// cnuPreviewLand
			// 
			this.cnuPreviewLand.Name = "cnuPreviewLand";
			this.cnuPreviewLand.Size = new System.Drawing.Size(189, 22);
			this.cnuPreviewLand.Text = "Preview Landscape";
			this.cnuPreviewLand.ToolTipText = "Print preview (Landscape mode)";
			this.cnuPreviewLand.Click += new System.EventHandler(this.cnuPreviewLand_Click);
			// 
			// cnuGridN2
			// 
			this.cnuGridN2.Name = "cnuGridN2";
			this.cnuGridN2.Size = new System.Drawing.Size(186, 6);
			// 
			// cnuPrintPort
			// 
			this.cnuPrintPort.Name = "cnuPrintPort";
			this.cnuPrintPort.Size = new System.Drawing.Size(189, 22);
			this.cnuPrintPort.Text = "Print Portrait";
			this.cnuPrintPort.ToolTipText = "Print the grid in portrait mode";
			this.cnuPrintPort.Click += new System.EventHandler(this.cnuPrintPort_Click);
			// 
			// cnuPrintLand
			// 
			this.cnuPrintLand.Name = "cnuPrintLand";
			this.cnuPrintLand.Size = new System.Drawing.Size(189, 22);
			this.cnuPrintLand.Text = "Print Landscape";
			this.cnuPrintLand.ToolTipText = "Print the grid in landscape mode";
			this.cnuPrintLand.Click += new System.EventHandler(this.cnuPrintLand_Click);
			// 
			// cnuGridN3
			// 
			this.cnuGridN3.Name = "cnuGridN3";
			this.cnuGridN3.Size = new System.Drawing.Size(186, 6);
			this.cnuGridN3.Visible = false;
			// 
			// cnuExpandAll
			// 
			this.cnuExpandAll.Name = "cnuExpandAll";
			this.cnuExpandAll.ShortcutKeyDisplayString = "";
			this.cnuExpandAll.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F11)));
			this.cnuExpandAll.Size = new System.Drawing.Size(189, 22);
			this.cnuExpandAll.Text = "Expand All";
			this.cnuExpandAll.Visible = false;
			this.cnuExpandAll.Click += new System.EventHandler(this.cnuExpandAll_Click);
			// 
			// cnuExpandGroup
			// 
			this.cnuExpandGroup.Name = "cnuExpandGroup";
			this.cnuExpandGroup.Size = new System.Drawing.Size(189, 22);
			this.cnuExpandGroup.Text = "Expand Group";
			this.cnuExpandGroup.Visible = false;
			this.cnuExpandGroup.Click += new System.EventHandler(this.cnuExpandGroup_Click);
			// 
			// cnuCollapseAll
			// 
			this.cnuCollapseAll.Name = "cnuCollapseAll";
			this.cnuCollapseAll.ShortcutKeyDisplayString = "";
			this.cnuCollapseAll.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F12)));
			this.cnuCollapseAll.Size = new System.Drawing.Size(189, 22);
			this.cnuCollapseAll.Text = "Collapse All";
			this.cnuCollapseAll.Visible = false;
			this.cnuCollapseAll.Click += new System.EventHandler(this.cnuCollapseAll_Click);
			// 
			// cnuCollapseGroup
			// 
			this.cnuCollapseGroup.Name = "cnuCollapseGroup";
			this.cnuCollapseGroup.Size = new System.Drawing.Size(189, 22);
			this.cnuCollapseGroup.Text = "Collapse Group";
			this.cnuCollapseGroup.Visible = false;
			this.cnuCollapseGroup.Click += new System.EventHandler(this.cnuCollapseGroup_Click);
			// 
			// cnuGridN4
			// 
			this.cnuGridN4.Name = "cnuGridN4";
			this.cnuGridN4.Size = new System.Drawing.Size(186, 6);
			this.cnuGridN4.Visible = false;
			// 
			// cnuFieldChooser
			// 
			this.cnuFieldChooser.Name = "cnuFieldChooser";
			this.cnuFieldChooser.Size = new System.Drawing.Size(189, 22);
			this.cnuFieldChooser.Text = "Select Columns";
			this.cnuFieldChooser.Visible = false;
			this.cnuFieldChooser.Click += new System.EventHandler(this.cnuFieldChooser_Click);
			// 
			// cnuGridN5
			// 
			this.cnuGridN5.Name = "cnuGridN5";
			this.cnuGridN5.Size = new System.Drawing.Size(186, 6);
			this.cnuGridN5.Visible = false;
			// 
			// cnuFontSelector
			// 
			this.cnuFontSelector.Name = "cnuFontSelector";
			this.cnuFontSelector.Size = new System.Drawing.Size(189, 22);
			this.cnuFontSelector.Text = "Select Font...";
			this.cnuFontSelector.Visible = false;
			this.cnuFontSelector.Click += new System.EventHandler(this.cnuFontSelector_Click);
			// 
			// cnuGridCopySeparator
			// 
			this.cnuGridCopySeparator.Name = "cnuGridCopySeparator";
			this.cnuGridCopySeparator.Size = new System.Drawing.Size(186, 6);
			// 
			// cnuCopyAll
			// 
			this.cnuCopyAll.Name = "cnuCopyAll";
			this.cnuCopyAll.Size = new System.Drawing.Size(189, 22);
			this.cnuCopyAll.Text = "Copy Entire Grid";
			this.cnuCopyAll.Click += new System.EventHandler(this.cnuCopyAll_Click);
			// 
			// cnuGridCopyPasteSeparator
			// 
			this.cnuGridCopyPasteSeparator.Name = "cnuGridCopyPasteSeparator";
			this.cnuGridCopyPasteSeparator.Size = new System.Drawing.Size(186, 6);
			// 
			// cnuCopyCell
			// 
			this.cnuCopyCell.Name = "cnuCopyCell";
			this.cnuCopyCell.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
			this.cnuCopyCell.Size = new System.Drawing.Size(189, 22);
			this.cnuCopyCell.Text = "Copy Cell";
			this.cnuCopyCell.Click += new System.EventHandler(this.cnuCopyCell_Click);
			// 
			// cnuPaste
			// 
			this.cnuPaste.Name = "cnuPaste";
			this.cnuPaste.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
			this.cnuPaste.Size = new System.Drawing.Size(189, 22);
			this.cnuPaste.Text = "Paste";
			this.cnuPaste.Click += new System.EventHandler(this.cnuPaste_Click);
			// 
			// _Exporter
			// 
			this._Exporter.GridEX = this;
			this._Exporter.IncludeChildTables = true;
			this._Exporter.IncludeFormatStyle = false;
			// 
			// _PrintDoc
			// 
			this._PrintDoc.ExpandFarColumn = false;
			this._PrintDoc.GridEX = this;
			this._PrintDoc.PrintHierarchical = true;
			// 
			// ucGridEx
			// 
			this.ContextMenuStrip = this._cnuGrid;
			this.Size = new System.Drawing.Size(200, 200);
			this._cnuGrid.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		protected ucGridEXExporter _Exporter;
		private System.Windows.Forms.ToolStripMenuItem cnuPrintPort;
		private System.Windows.Forms.ToolStripMenuItem cnuPrintLand;
		private System.Windows.Forms.ToolStripMenuItem cnuPreviewPort;
		private System.Windows.Forms.ToolStripSeparator cnuGridN1;
		private System.Windows.Forms.ToolStripMenuItem cnuPreviewLand;
		private System.Windows.Forms.ToolStripSeparator cnuGridN2;
		protected ucGridEXPrintDocument _PrintDoc;
		protected System.Windows.Forms.ContextMenuStrip _cnuGrid;
		private System.Windows.Forms.ToolStripSeparator cnuGridN3;
		private System.Windows.Forms.ToolStripMenuItem cnuExpandAll;
		private System.Windows.Forms.ToolStripMenuItem cnuCollapseAll;
		private System.Windows.Forms.ToolStripSeparator cnuGridN4;
		private System.Windows.Forms.ToolStripMenuItem cnuFieldChooser;
		private System.Windows.Forms.ToolStripSeparator cnuGridN5;
		private System.Windows.Forms.ToolStripMenuItem cnuFontSelector;
		private System.Windows.Forms.ToolStripMenuItem cnuExpandGroup;
		private System.Windows.Forms.ToolStripMenuItem cnuCollapseGroup;
		private System.Windows.Forms.ToolStripMenuItem cnuExport;
		private System.Windows.Forms.ToolStripMenuItem cnuExportAs;
		private System.Windows.Forms.ToolStripSeparator cnuGridCopySeparator;
		private System.Windows.Forms.ToolStripMenuItem cnuCopyCell;
		private System.Windows.Forms.ToolStripMenuItem cnuCopyAll;
		private System.Windows.Forms.ToolStripMenuItem cnuPaste;
		private System.Windows.Forms.ToolStripSeparator cnuGridCopyPasteSeparator;



	}
}
