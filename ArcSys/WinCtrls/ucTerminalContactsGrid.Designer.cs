namespace CS2010.ArcSys.WinCtrls
{
	partial class ucTerminalContactsGrid
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
			Janus.Windows.GridEX.GridEXLayout grdContacts_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
			Janus.Windows.Common.Layouts.JanusLayoutReference grdContacts_DesignTimeLayout_Reference_0 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column6.ButtonImage");
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucTerminalContactsGrid));
			this.grdContacts = new CS2010.CommonWinCtrls.ucGridEx();
			((System.ComponentModel.ISupportInitialize)(this.grdContacts)).BeginInit();
			this.SuspendLayout();
			// 
			// grdContacts
			// 
			this.grdContacts.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.True;
			this.grdContacts.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.True;
			grdContacts_DesignTimeLayout_Reference_0.Instance = ((object)(resources.GetObject("grdContacts_DesignTimeLayout_Reference_0.Instance")));
			grdContacts_DesignTimeLayout.LayoutReferences.AddRange(new Janus.Windows.Common.Layouts.JanusLayoutReference[] {
            grdContacts_DesignTimeLayout_Reference_0});
			grdContacts_DesignTimeLayout.LayoutString = resources.GetString("grdContacts_DesignTimeLayout.LayoutString");
			this.grdContacts.DesignTimeLayout = grdContacts_DesignTimeLayout;
			this.grdContacts.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grdContacts.ExportFileID = null;
			this.grdContacts.GroupByBoxVisible = false;
			this.grdContacts.Location = new System.Drawing.Point(0, 0);
			this.grdContacts.Name = "grdContacts";
			this.grdContacts.NewRowEnterKeyBehavior = Janus.Windows.GridEX.NewRowEnterKeyBehavior.AddRowAndMoveToFirstCellInNewRow;
			this.grdContacts.NewRowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
			this.grdContacts.Size = new System.Drawing.Size(668, 117);
			this.grdContacts.TabIndex = 2;
			this.grdContacts.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003;
			this.grdContacts.ColumnButtonClick += new Janus.Windows.GridEX.ColumnActionEventHandler(this.grdContacts_ColumnButtonClick);
			// 
			// ucTerminalContactsGrid
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.grdContacts);
			this.Name = "ucTerminalContactsGrid";
			this.Size = new System.Drawing.Size(668, 117);
			((System.ComponentModel.ISupportInitialize)(this.grdContacts)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private CS2010.CommonWinCtrls.ucGridEx grdContacts;

	}
}
