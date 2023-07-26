using System;
using System.IO;
using System.Data;
using System.Text;
using System.Drawing;
using System.Configuration;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;
using Janus.Windows.GridEX;
using Janus.Windows.GridEX.Export;
using CS2010.Common;
using System.Collections;

namespace CS2010.CommonWinCtrls
{
	[ToolboxItem(true)]
	[DesignTimeVisible(true)]
	[ToolboxBitmap(typeof(GridEX))]
	public partial class ucGridEx : GridEX
	{
		#region Fields

		/// <summary>Storage for <see cref="_DisplayFontSelector"/> property</summary>
		protected bool _DisplayFontSelector;
		/// <summary>Storage for <see cref="DisplayFieldChooser"/> property</summary>
		protected bool _DisplayFieldChooser;
		/// <summary>Storage for <see cref="DisplayFieldChooser"/> property</summary>
		protected bool _DisplayFieldChooserChildren;
		/// <summary>Storage for <see cref="DisplayPrintMenu"/> property</summary>
		protected bool _DisplayPrintMenu;
		/// <summary>Storage for <see cref="DisplayPrintMenu"/> property</summary>
		protected bool _DisplayPreviewMenu;
		/// <summary>Storage for <see cref="DisplayExportMenu"/> property</summary>
		protected bool _DisplayExportMenu;
		/// <summary>Storage for <see cref="ExportFileID"/> property</summary>
		protected string _ExportFileID;

		/// <summary>Holds reference to a context menu when another menu is
		/// assigned to this grid, so we can merge/unmerge this menu with
		/// the grid's default menu</summary>
		protected ContextMenuStrip _cnuParent;

		protected GridExportOptions _ExportOptions;

		protected bool _RightClicked;
		protected GridEXColumn _RightClickColumn;
		protected GridEXColumn CopyPasteColumn
		{
			get { return (_RightClicked) ? _RightClickColumn : CurrentColumn; }
		}

		public NewRowPosition OriginalNewPosition { get; set; }

		#endregion		// #region Fields

		#region Properties

		/// <summary>Gets the GridExPrintDocument associated with this grid</summary>
		[TypeConverter(typeof(ExpandableObjectConverter))]
		[Description("The GridExPrintDocument that will handle printing/previewing")]
		public ucGridEXPrintDocument PrintDocument { get { return _PrintDoc; } }

		/// <summary>Gets the GridExExporter associated with this grid</summary>
		[TypeConverter(typeof(ExpandableObjectConverter))]
		[Description("The GridEXExporter that will handle exporting to Excel")]
		public ucGridEXExporter Exporter { get { return _Exporter; } }

		/// <summary>Gets/sets whether the grid should be printed in
		/// landscape mode</summary>
		[DefaultValue(false)]
		[Description("Determines print mode: landscape (true), portrait (false)")]
		public bool PrintLandscape
		{
			get { return _PrintDoc.DefaultPageSettings.Landscape; }
			set { _PrintDoc.DefaultPageSettings.Landscape = value; }
		}

		/// <summary>Gets/Sets whether the font selector item will appear in the menu</summary>
		[DefaultValue(false)]
		[Description("Determines whether the font selector item will appear in the menu")]
		public bool DisplayFontSelector
		{
			get { return _DisplayFontSelector; }
			set
			{
				_DisplayFontSelector = value;
				cnuFontSelector.Visible = cnuGridN5.Visible = value;
			}
		}

		/// <summary>Gets/Sets whether the field chooser item will appear in the menu</summary>
		[DefaultValue(false)]
		[Description("Determines whether the field chooser item will appear in the menu")]
		public bool DisplayFieldChooser
		{
			get { return _DisplayFieldChooser; }
			set
			{
				_DisplayFieldChooser = value;
				cnuFieldChooser.Visible = cnuGridN4.Visible = value;
			}
		}

		/// <summary>Gets/Sets whether the field chooser will display columns for child tables</summary>
		[DefaultValue(false)]
		[Description("Determines whether the field chooser will display columns for child tables")]
		public bool DisplayFieldChooserChildren
		{
			get { return _DisplayFieldChooserChildren; }
			set { _DisplayFieldChooserChildren = value; }
		}

		/// <summary>Gets/Sets whether the print items will appear in the menu</summary>
		[DefaultValue(true)]
		[Description("Determines whether print items will appear in the menu")]
		public bool DisplayPrintMenu
		{
			get { return _DisplayPrintMenu; }
			set
			{
				_DisplayPrintMenu = value;
				cnuPrintPort.Visible = cnuPrintLand.Visible = cnuGridN3.Visible = value;
			}
		}

		/// <summary>Gets/Sets whether the print preview items will appear in the menu</summary>
		[DefaultValue(true)]
		[Description("Determines whether print preview items will appear in the menu")]
		public bool DisplayPreviewMenu
		{
			get { return _DisplayPreviewMenu; }
			set
			{
				_DisplayPreviewMenu = value;
				cnuPreviewPort.Visible = cnuPreviewLand.Visible = cnuGridN2.Visible = value;
			}
		}

		/// <summary>Gets/Sets whether the export items will appear in the menu</summary>
		[DefaultValue(true)]
		[Description("Determines whether export items will appear in the menu")]
		public bool DisplayExportMenu
		{
			get { return _DisplayExportMenu; }
			set
			{
				_DisplayExportMenu = value;
				cnuExport.Visible = cnuExportAs.Visible = value;
				if( value == true ) cnuGridN1.Visible = DisplayPrintMenu || DisplayPreviewMenu;
			}
		}

		/// <summary>Gets/Sets the unique identifier for this grid</summary>
		[Description("Unique identifier for this grid that is used (along with" +
			" system date and current user) to name exported files. For" +
			" example a value of 'history' would produce something like" +
			" 2006-05-23-jroman-history. The file extension will depend on the" +
			" type of export (xls for Excel, CSV for comma delimited, etc.)")]
		public string ExportFileID
		{
			get { return _ExportFileID; }
			set
			{
				_ExportFileID = value;
				_PrintDoc.DocumentName = value;
			}
		}

		public GridExportOptions ExportOptions
		{
			get { return _ExportOptions; }
		}

		public void SetExportOptions(GridExportOptions someOptions)
		{
			_ExportOptions.CopyFrom(someOptions);
		}
		#endregion		// #region Properties

		#region Internal Properties

		/// <summary>Used to record the name of the last printer used to print a grid</summary>
		private string DocumentName
		{
			get { return !string.IsNullOrEmpty(ExportFileID) ? ExportFileID : "AGridDocument"; }
		}
		#endregion		// #region Internal Properties

		#region Constructors

		/// <summary>Default constructor</summary>
		public ucGridEx()
		{
			InitializeComponent();

			_cnuParent = null;
			_DisplayFieldChooser = _DisplayFieldChooserChildren = _DisplayFontSelector = false;
			_DisplayPrintMenu = _DisplayPreviewMenu = _DisplayExportMenu = true;

			_ExportOptions = new GridExportOptions();
		}
		#endregion		// #region Constructors

		#region Overrides

		/// <summary>Merge/Unmerge menus whenever this event occurs</summary>
		protected override void OnContextMenuStripChanged(EventArgs e)
		{
			base.OnContextMenuStripChanged(e);
			AdjustContextMenu();
		}
		#endregion		// #region Overrides

		#region Public methods

		/// <summary>
		/// CLASS EXTENSION.
		/// Returns the current DataRow that provides the datasource for this GridEXRow.
		/// </summary>
		/// <returns></returns>
		public DataRow GetDataRow()
		{
			GridEXRow gRow = this.GetRow();
			if (gRow == null) return null;
			DataRowView drv = gRow.DataRow as DataRowView;
			return (drv == null) ? null : drv.Row;
		}

		public DataRow GetDataRow(int idx)
		{
			GridEXRow gRow = this.GetRow(idx);
			if (gRow == null) return null;
			DataRowView drv = gRow.DataRow as DataRowView;
			return (drv == null) ? null : drv.Row;
		}

		public DataRow[] GetCheckedDataRows()
		{
			
			GridEXRow[] rows = GetCheckedRows();
			if( rows == null || rows.Length <= 0 ) return null;

			DataRow[] drs = new DataRow[rows.Length];
			for( int i = 0; i < rows.Length; i++ )
				drs[i] = ( (DataRowView)rows[i].DataRow ).Row;
			return drs;
		}

		public List<DataRow> GetDataRowList()
		{
			List<DataRow> lst = new List<DataRow>();
			GridEXRow[] rows = GetRows();
			if( rows != null && rows.Length > 0 )
				LoadRows(rows, lst);
			return lst;
		}

		private void LoadRows(GridEXRow[] rows, List<DataRow> lst)
		{
			if (rows == null || rows.Length <= 0) return;

			foreach (GridEXRow r in rows)
			{
				if (r.GroupValue != null)
				{
					GridEXRow[] childRows = r.GetChildRows();
					LoadRows(childRows, lst);
				}
				else
				{
					DataRowView drv = r.DataRow as DataRowView;
					if (drv != null && drv.Row != null) lst.Add(drv.Row);
				}
			}
		}

		public List<DataRow> GetSelectedDataRowList()
		{
			List<DataRow> lst = new List<DataRow>();
			if (SelectedItems == null || SelectedItems.Count <= 0) return lst;

			List<GridEXRow> lstGrows = new List<GridEXRow>();
			foreach (GridEXSelectedItem gsi in SelectedItems)
			{
				GridEXRow g = gsi.GetRow();
				if (g != null) lstGrows.Add(g);
			}

			LoadRows(lstGrows.ToArray(), lst);

			return lst;
		}

		public List<GridEXRow> GetGridExRowList()
		{
			List<GridEXRow> lst = new List<GridEXRow>();
			GridEXRow[] rows = GetRows();
			if (rows != null && rows.Length > 0)
				LoadGridExRows(rows, lst);
			return lst;
		}

		private void LoadGridExRows(GridEXRow[] rows, List<GridEXRow> lst)
		{
			if (rows == null || rows.Length <= 0) return;

			foreach (GridEXRow r in rows)
			{
				if (r.GroupValue != null)
				{
					GridEXRow[] childRows = r.GetChildRows();
					LoadGridExRows(childRows, lst);
				}
				else
				{
					if( r.RowType == RowType.Record )
						lst.Add(r);
				}
			}
		}

		/// <summary>
		/// CLASS EXTENSION. Returns a datatable of the data in the grid, in the sorted order
		/// </summary>
		/// <returns></returns>
		public DataTable GetDataTableSource()
		{
			DataTable dtA = this.DataSource as DataTable;
			if (dtA == null)
				return null;
			DataTable dtOut = dtA.Clone();
			foreach (GridEXRow grow in this.GetDataRows())
			{
				DataRowView drv = grow.DataRow as DataRowView;
				DataRow drow = drv.Row;
				DataRow dnew = dtOut.NewRow();
				dnew.ItemArray = drow.ItemArray;
				dtOut.Rows.Add(dnew);
			}
			return dtOut;
		}

		public List<T> GetCheckedList<T>() where T : ClsBaseTable, new()
		{
			List<T> lst = new List<T>();

			GridEXRow[] rows = GetCheckedRows();
			if( rows == null || rows.Length <= 0 ) return lst;

			DataTable dt = DataSource as DataTable;
			DataSet ds = DataSource as DataSet;
			foreach( GridEXRow r in rows )
			{
				T item = null;
				if( dt != null || ds != null )
				{
					DataRowView drv = r.DataRow as DataRowView;
					item = new T();
					item.LoadFromDataRow(drv.Row);
				}
				else
					item = r.DataRow as T;

				if( item != null ) lst.Add(item);
			}

			return lst;
		}

        public List<T> GetObjectList<T>() where T : ClsBaseTable, new()
        {
            List<T> lst = new List<T>();
            GridEXRow[] rows = GetDataRows();

            if (rows == null || rows.Length <= 0) return lst;

            DataTable dt = DataSource as DataTable;
            DataSet ds = DataSource as DataSet;
            foreach (GridEXRow r in rows)
            {
                T item = null;
                if (dt != null || ds != null)
                {
                    DataRowView drv = r.DataRow as DataRowView;
                    item = new T();
                    item.LoadFromDataRow(drv.Row);
                }
                else
                    item = r.DataRow as T;

                if (item != null) lst.Add(item);
            }
            return lst;
        }

		public T GetCurrentItem<T>() where T : ClsBaseTable, new()
		{
			GridEXRow r = GetRow();
			if( r == null ) return null;

			DataTable dt = DataSource as DataTable;
			DataSet ds = DataSource as DataSet;
			if( dt == null && ds == null ) return r.DataRow as T;

			DataRowView drv = r.DataRow as DataRowView;
			if( drv == null ) return null;

			T item = new T();
			item.LoadFromDataRow(drv.Row);
			return item;
		}

		public void ResetDataRowErrors()
		{
			DataSet dsGrid = DataSource as DataSet;
			DataTable dtGrid = DataSource as DataTable;

			if (dtGrid != null && dtGrid.Rows != null)
			{
				foreach (DataRow dr in dtGrid.Rows) dr.ClearErrors();
			}

			if (dsGrid != null && dsGrid.Tables != null)
			{
				foreach (DataTable dt in dsGrid.Tables)
				{
					foreach (DataRow dr in dt.Rows) dr.ClearErrors();
				}
			}
		}
		#endregion

		#region Public Special Printing Methods

		/// <summary>You would call this PrinterSetup method and then call the print or preview
		/// method that expects a print dialog as parameter</summary>
		public PrintDialog PrinterSetup(bool landscape, bool? includeChildren, bool allowRange)
		{
			bool printTree = false;
			if( Hierarchical )
			{
				if( includeChildren == null )
					printTree = Display.Ask("Confirm", "Include child rows?");
				else
					printTree = includeChildren.Value;
			}

			Cursor = Cursors.WaitCursor;
			Application.DoEvents();
			PrintDialog dlg = new PrintDialog();
			try
			{
				dlg.Reset();
				dlg.AllowPrintToFile = true;
				dlg.AllowCurrentPage = dlg.AllowSelection = dlg.AllowSomePages =
					dlg.ShowHelp = dlg.ShowNetwork = dlg.UseEXDialog = false;

				dlg.Document = _PrintDoc;
				dlg.PrinterSettings.PrinterName = ClsEnvironment.GetLastPrinter(DocumentName);

				_PrintDoc.PrintHierarchical = printTree;
				_PrintDoc.DefaultPageSettings.Landscape = landscape;
				_PrintDoc.PrinterSettings.ToPage = _PrintDoc.PrinterSettings.FromPage = 1;
				_PrintDoc.PrinterSettings.MinimumPage = _PrintDoc.PrinterSettings.MaximumPage = 0;

				_PrintDoc.PrepareDocument();
				int max = _PrintDoc.TotalPages;
				if( max > 1 )
				{
					if( allowRange ) dlg.AllowSomePages = true;
					_PrintDoc.PrinterSettings.MinimumPage = 0;
					_PrintDoc.PrinterSettings.MaximumPage = max;
					_PrintDoc.PrinterSettings.FromPage = 1;
					_PrintDoc.PrinterSettings.ToPage = max;
				}

				Cursor = Cursors.Arrow;
				Application.DoEvents();
				if( dlg.ShowDialog() != DialogResult.OK ) return null;

				ClsEnvironment.UpdateLastPrinter(DocumentName, dlg.PrinterSettings.PrinterName);
			}
			catch( Exception ex )
			{
				Display.ShowError("Grid", ex);
			}
			finally
			{
				Cursor = Cursors.Arrow;
				Application.DoEvents();
			}

			return dlg;
		}

		/// <summary>You would call this method after first calling the PrinterSetup method that
		/// returns a printdialog</summary>
		public void Print(bool landscape, bool? includeChildren, PrintDialog dlgPrint)
		{
			try
			{
				dlgPrint.Document = _PrintDoc;
				_PrintDoc.PrepareDocument();
				_PrintDoc.Print();
			}
			catch( Exception ex )
			{
				Display.ShowError("Grid", ex);
			}
		}

		/// <summary>You would call this method after first calling the PrinterSetup method that
		/// returns a printdialog</summary>
		public void Preview(bool landscape, bool? includeChildren, PrintDialog dlgPrint)
		{
			try
			{
				dlgPrint.Document = _PrintDoc;
				_PrintDoc.PrepareDocument();

				using( PrintPreviewDialog dlg = new PrintPreviewDialog() )
				{
					dlg.ShowIcon = false;
					dlg.Document = _PrintDoc;
					dlg.StartPosition = FormStartPosition.CenterParent;
					dlg.WindowState = FormWindowState.Maximized;
					dlg.PrintPreviewControl.AutoZoom = true;

					dlg.ShowDialog(this.TopLevelControl);
				}
			}
			catch( Exception ex )
			{
				Display.ShowError("Grid", ex);
			}
		}
		#endregion		// #region Public Special Printing Methods

		#region Helper methods

		/// <summary>Handles merging/unmerging of the context menus</summary>
		protected void AdjustContextMenu()
		{
			if( DesignMode == true || ClsEnvironment.IsDesignMode == true ||
				ContextMenuStrip == _cnuGrid ) return;

			if( ContextMenuStrip == null )
			{
				if (_cnuParent != null)
				{
					_cnuParent.Disposed -= new EventHandler(_cnuParent_Disposed);
					_cnuParent.Opening -= new CancelEventHandler(_cnuGrid_Opening);
					ToolStripManager.RevertMerge(_cnuParent);
				}
				ContextMenuStrip = _cnuGrid;
				_cnuParent = null;
			}
			else
			{
				_cnuParent = ContextMenuStrip;
				_cnuParent.Disposed += new EventHandler(_cnuParent_Disposed);
				_cnuParent.Opening += new CancelEventHandler(_cnuGrid_Opening);
				ToolStripManager.Merge(_cnuGrid, _cnuParent);
			}
		}
		#endregion		// #region Helper methods

		#region Menu/Toolbar Actions

		protected bool PrinterSetup(bool landscape, bool? includeChildren)
		{
			bool printTree = false;
			if( Hierarchical )
			{
				if( includeChildren == null )
					printTree = Display.Ask("Confirm", "Include child rows?");
				else
					printTree = includeChildren.Value;
			}

			Cursor = Cursors.WaitCursor;
			Application.DoEvents();
			try
			{
				using( PrintDialog dlg = new PrintDialog() )
				{
					dlg.Reset();
					dlg.AllowPrintToFile = true;
					dlg.AllowCurrentPage = dlg.AllowSelection = dlg.AllowSomePages =
						dlg.ShowHelp = dlg.ShowNetwork = dlg.UseEXDialog = false;

					dlg.Document = _PrintDoc;
					dlg.PrinterSettings.PrinterName = ClsEnvironment.GetLastPrinter(DocumentName);

					_PrintDoc.PrintHierarchical = printTree;
					_PrintDoc.DefaultPageSettings.Landscape = landscape;
					_PrintDoc.PrinterSettings.ToPage = _PrintDoc.PrinterSettings.FromPage = 1;
					_PrintDoc.PrinterSettings.MinimumPage = _PrintDoc.PrinterSettings.MaximumPage = 0;

					_PrintDoc.PrepareDocument();
					int max = _PrintDoc.TotalPages;
					if( max > 1 )
					{
						dlg.AllowSomePages = true;
						_PrintDoc.PrinterSettings.MinimumPage = 0;
						_PrintDoc.PrinterSettings.MaximumPage = max;
						_PrintDoc.PrinterSettings.FromPage = 1;
						_PrintDoc.PrinterSettings.ToPage = max;
					}

					Cursor = Cursors.Arrow;
					Application.DoEvents();
					if( dlg.ShowDialog() != DialogResult.OK ) return false;

					ClsEnvironment.UpdateLastPrinter(DocumentName,
						dlg.PrinterSettings.PrinterName);
				}
			}
			catch( Exception ex )
			{
				Display.ShowError("Grid", ex);
			}
			finally
			{
				Cursor = Cursors.Arrow;
				Application.DoEvents();
			}

			return true;
		}

		public void Print(bool landscape, bool? includeChildren, bool prompt)
		{
			try
			{
				if( prompt && Display.Ask("Print Confirmation",
					"This will print the contents of the grid. Continue?") == false )
					return;

				if( PrinterSetup(landscape, includeChildren) == false ) return;

				_PrintDoc.Print();
			}
			catch( Exception ex )
			{
				Display.ShowError("Grid", ex);
			}
		}

		public void Preview(bool landscape, bool? includeChildren)
		{
			try
			{
				if( PrinterSetup(landscape, includeChildren) == false ) return;

				using( PrintPreviewDialog dlg = new PrintPreviewDialog() )
				{
					dlg.ShowIcon = false;
					dlg.Document = _PrintDoc;
					dlg.StartPosition = FormStartPosition.CenterParent;
					dlg.WindowState = FormWindowState.Maximized;
					dlg.PrintPreviewControl.AutoZoom = true;

					dlg.ShowDialog(this.TopLevelControl);
				}
			}
			catch( Exception ex )
			{
				Display.ShowError("Grid", ex);
			}
		}

		public void Export(bool showFileDialog, GridExportOptions someOptions)
		{
			try
			{
				SetExportOptions(someOptions);
				Export(showFileDialog, false);
			}
			catch( Exception ex )
			{
				Display.ShowError("Grid", ex);
			}
		}

		public void Export(bool showFileDialog, bool showOptionsDialog)
		{
			try
			{
				if( showOptionsDialog )
				{
					using( frmExportOptions f = new frmExportOptions() )
					{
						if( !f.GetExportOptions(_ExportOptions) ) return;
					}
				}

				string ext = "txt";
				string filter =
					"Text Files (*.txt)|*.txt|CSV Files (*.csv)|*.csv|All Files (*.*)|*.*";
				if( _ExportOptions.ExportType == GridExportType.Excel )
				{
					ext = "xls";
					filter = "Excel Files (*.xls)|*.xls|All Files (*.*)|*.*";
				}
				else if( _ExportOptions.ExportType == GridExportType.CSV )
				{
					ext = "csv";
					filter = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*";
				}

				string fileName = null;

				if( showFileDialog )
				{
					using( SaveFileDialog dlg = new SaveFileDialog() )
					{
						dlg.DefaultExt = ext;
						dlg.Title = "Export File As";
						dlg.Filter = filter;
						if( dlg.ShowDialog() != DialogResult.OK ) return;

						fileName = dlg.FileName;
					}
				}
				else
				{
					fileName =
						ClsConfig.GetUniqueFileNameWithPath(ExportFileID, ext, true, true);
				}

				if( _ExportOptions.ExportType == GridExportType.Excel )
					ExportExcel(fileName);
				else if( _ExportOptions.ExportType == GridExportType.CSV )
					ExportCSV(fileName);
				else
					ExportDelimited(fileName);
			}
			catch( Exception ex )
			{
				Display.ShowError("Grid", ex);
			}
		}

		protected void ExportDelimited(string name)
		{
			try
			{
				using( StreamWriter sw = new StreamWriter(name) )
				{
					WriteColumns(RootTable, sw, _ExportOptions.Delimiter);

					WriteRows(GetRows(), sw, _ExportOptions.Delimiter);

					if( TotalRow == InheritableBoolean.True )
					{
						GridEXRow totalRow = GetTotalRow();
						if( totalRow != null ) WriteCells(totalRow, sw, _ExportOptions.Delimiter);
					}

					sw.Flush();
				}
				Display.Show("Export", "Grid exported to {0}", name);
			}
			catch( Exception ex )
			{
				Display.ShowError("Grid", ex);
			}
		}

		public void ExportCSV(string name)
		{
			try
			{
				using( StreamWriter sw = new StreamWriter(name) )
				{
					WriteColumns(RootTable, sw, ',');

					WriteRows(GetRows(), sw, ',');

					if( TotalRow == InheritableBoolean.True )
					{
						GridEXRow totalRow = GetTotalRow();
						if( totalRow != null ) WriteCells(totalRow, sw, ',');
					}

					sw.Flush();
				}
				Display.Show("Export", "Grid exported to {0}", name);
			}
			catch( Exception ex )
			{
				Display.ShowError("Grid", ex);
			}
		}

		public void ExportExcel(string name)
		{
			GridEXColumn sel = null;
			try
			{
				//_Exporter.ExportMode = _ExportOptions.RowType;
				_Exporter.IncludeChildTables = _ExportOptions.IncludeChildTables;
				_Exporter.IncludeHeaders = _ExportOptions.IncludeColumnHeaders;
				if( !_ExportOptions.IncludeSelectorRow )
				{
					foreach( GridEXColumn col in RootTable.Columns )
					{
						if( col.ActAsSelector )
						{
							if( col.Visible )
							{
								sel = col;
								sel.Visible = false;
							}
							break;
						}
					}
				}
				using( Stream s = File.OpenWrite(name) )
					_Exporter.Export(s);
				Display.Show("Export", "Grid exported to {0}", name);
			}
			catch( Exception ex )
			{
				Display.ShowError("Grid", ex);
			}
			finally
			{
				if( sel != null ) sel.Visible = true;
			}
		}

		private void OpenFieldChooser()
		{
			try
			{
				Form f = TopLevelControl as Form;
				ShowFieldChooser(f, "Drag Columns to Grid", RootTable, _DisplayFieldChooserChildren);
			}
			catch( Exception ex )
			{
				Display.ShowError("Grid", ex);
			}
		}

		private void OpenFontSelector()
		{
			try
			{
				Form f = TopLevelControl as Form;
				using( FontDialog dlg = new FontDialog() )
				{
					dlg.Font = Font.Clone() as Font;
					dlg.AllowScriptChange = dlg.FixedPitchOnly = dlg.ScriptsOnly = dlg.ShowApply =
						dlg.ShowHelp = dlg.ShowColor = dlg.ShowEffects = false;
					dlg.AllowSimulations = dlg.AllowVectorFonts = dlg.AllowVerticalFonts =
						dlg.FontMustExist = true;
					if( dlg.ShowDialog() != DialogResult.OK ) return;
					Font = dlg.Font.Clone() as Font;
				}
			}
			catch( Exception ex )
			{
				Display.ShowError("Grid", ex);
			}
		}
		#endregion		// #region Menu/Toolbar Actions

		#region Export CSV Helper Methods

		/// <summary>Recursive method for printing rows in a group</summary>
		/// <param name="rows">An array of grid rows</param>
		/// <param name="sw">The stream to write the text to</param>
		protected void WriteRows(GridEXRow[] rows, TextWriter sw, char delim)
		{
			if( rows == null ) return;

			if( delim == 0 ) delim = ',';

			bool first = true;
			foreach( GridEXRow r in rows )
			{
				if( first )
				{
					first = false;
					if( r.Parent != null && r.Parent.GroupValue == null )
						WriteColumns(r.Table, sw, delim);
				}

				bool foundSelector = false;
				foreach( GridEXColumn col in r.Table.Columns )
				{
					if( col.ActAsSelector )
					{
						foundSelector = true;
						break;
					}
				}

				GridEXRow[] childRows = r.GetChildRows();
				if( r.GroupValue != null )
				{	// Handle group rows: write out group info then call WriteRows
					// recursively to handle the children of the group (Note: child rows of a
					// group are not the same as the rows of a child table. The child table
					// rows would be handled by the else section when GroupValue is null)

					bool exportGroup = true;
					if( _ExportOptions.RowType == ExportMode.CheckedRows )
					{	// Then, if we are concerned with checked rows
						if( r.CheckState == RowCheckState.Unchecked )
							exportGroup = false;
					}

					if( exportGroup )
					{
						sw.WriteLine("{0} {1}", r.Group.GroupPrefix, r.GroupCaption);
						WriteRows(childRows, sw, delim);
					}
				}
				else
				{	// Only write the data if we are exporting all rows (type != checkedRows) or
					// if we are exporting checked rows and the row is checked. The problem is
					// that the IsChecked property needs to be ignored if the row does not have a
					// selector column because the concept of a checked row would not apply. This
					// is especially true for child tables which typically do not have a selector
					// column.
					bool exportRow = true;		// Default to true (row will be exported)
					if( _ExportOptions.RowType == ExportMode.CheckedRows )
					{	// Then, if we are concerned with checked rows, and if we found
						// the selector column, and the row is not checked, do not export it
						if( foundSelector && !r.IsChecked ) exportRow = false;
					}

					if( exportRow )
					{
						if( r.Table == RootTable && RootTable.FilterApplied != null )
						{
							exportRow = RootTable.FilterApplied.EvaluateRow(r);
						}
					}

					if( exportRow )
					{
						WriteCells(r, sw, delim);	// Write out the row
						// Then write out rows of the child table if any
						// but only if the IncludeChildTables property was selected
						if( childRows != null && _ExportOptions.IncludeChildTables )
							WriteRows(childRows, sw, delim);
					}
				}
			}
		}

		/// <summary>Write out the columns of the given table</summary>
		/// <param name="r">The table to write</param>
		/// <param name="sw">The stream to write to</param>
		protected void WriteColumns(GridEXTable tab, TextWriter sw, char delim)
		{
			if( !_ExportOptions.IncludeColumnHeaders ) return;

			if( tab.ColumnHeaders == InheritableBoolean.False ||
				( tab.ColumnHeaders == InheritableBoolean.Default &&
				tab.GridEX.ColumnHeaders == InheritableBoolean.False ) ) return;

			if( delim == 0 ) delim = ',';

			if( tab.ParentTable != null ) sw.Write(delim);

			if( tab.CellLayoutMode == CellLayoutMode.UseColumnSets )
			{
				int setCount = 0;
				for( int i = 0; i < tab.ColumnSets.Count; i++ )
				{
					GridEXColumnSet colset = tab.ColumnSets.GetColumnSetInPosition(i);
					if( colset.Visible == false ) continue;

					sw.Write("{0}{1}", ( setCount > 0 ? delim.ToString() : null ), colset.Caption);
					if( colset.ColumnCount > 1 ) sw.Write(new string(delim, colset.ColumnCount - 1));

					setCount++;
				}
				sw.WriteLine();
			}

			int count = 0;
			for( int i = 0; i < tab.Columns.Count; i++ )
			{
				GridEXColumn col = tab.Columns.GetColumnInPosition(i);
				if( col.Visible == false ) continue;

				if( col.ActAsSelector == true && !_ExportOptions.IncludeSelectorRow ) continue;

				sw.Write("{0}{1}", ( count > 0 ? delim.ToString() : null ), col.Caption);
				count++;
			}
			sw.WriteLine();
		}

		/// <summary>Write out the cells of the given row</summary>
		/// <param name="r">The row to write</param>
		/// <param name="sw">The stream to write to</param>
		protected void WriteCells(GridEXRow r, TextWriter sw, char delim)
		{
			if( delim == 0 ) delim = ',';

			if( r.Parent != null && r.Parent.GroupValue == null ) sw.Write(delim);

			int count = 0;
			foreach( GridEXCell c in r.Cells )
			{
				if( c.Column.Visible == false ) continue;
				if( c.Column.ActAsSelector == true && !_ExportOptions.IncludeSelectorRow ) continue;
				if( c.Value is string )
				{
					StringBuilder txt = new StringBuilder(c.Value as string);
					if( txt.Length > 0 )
					{
						txt.Replace("\r\n", " ");
						txt.Replace("\r", " ");
						txt.Replace("\n", " ");
					}
					sw.Write("{0}{1}", (count > 0 ? delim.ToString() : null), txt.ToString());
				}
				else
				{
					sw.Write("{0}{1}", (count > 0 ? delim.ToString() : null), c.Value);
				}
				count++;
			}
			sw.WriteLine();
		}
		#endregion		// #region Export CSV Helper Methods

		#region Copy/Paste

		private void cnuCopyAll_Click(object sender, EventArgs e)
		{
			try
			{
				StringBuilder sb = new StringBuilder();
				using (StringWriter sw = new StringWriter(sb))
				{
					WriteColumns(RootTable, sw, '|');

					WriteRows(GetRows(), sw, '|');

					if (TotalRow == InheritableBoolean.True)
					{
						GridEXRow totalRow = GetTotalRow();
						if (totalRow != null) WriteCells(totalRow, sw, '|');
					}

					sw.Flush();
				}
				Clipboard.SetDataObject(sb.ToString(), true);
			}
			catch (Exception ex)
			{
				Display.ShowError("Grid", ex);
			}
		}

		protected override void OnGroupsChanged(GroupsChangedEventArgs e)
		{
			try
			{
				base.OnGroupsChanged(e);
				// We can return immediately if: we cannot add a new row, the root table is null,
				// or if the original NewRowPosition was TopRow
				if (!AllowAddNew.HasFlag(InheritableBoolean.True) || RootTable == null ||
					OriginalNewPosition.HasFlag(NewRowPosition.TopRow)) return;

				this.NewRowPosition = (RootTable.Groups.Count > 0)
					? Janus.Windows.GridEX.NewRowPosition.TopRow
					: this.NewRowPosition = OriginalNewPosition;
			}
			catch (Exception ex)
			{
				ClsErrorHandler.LogException(ex);	// Log, but do not display
			}
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			try
			{
				base.OnMouseDown(e);
				if (e.Button == MouseButtons.Right)
				{
					_RightClicked = true;
					_RightClickColumn = ColumnFromPoint();
				}
			}
			catch (Exception ex)
			{
				ClsErrorHandler.LogException(ex);	// Log, but do not display
			}
		}
		private void cnuCopyCell_Click(object sender, EventArgs e)
		{
			AttemptCopy();
		}

		private void cnuPaste_Click(object sender, EventArgs e)
		{
			AttemptPaste();
		}

		protected void AttemptCopy()
		{
			try
			{
				if (SelectedItems == null || SelectedItems.Count <= 0) return;

				GridEXColumn col = CopyPasteColumn;
				_RightClickColumn = null;
				_RightClicked = false;

				StringBuilder sbCopy = new StringBuilder();
				foreach (GridEXSelectedItem gsi in SelectedItems)
				{
					GridEXRow grow = gsi.GetRow();
					if (grow.RowType == RowType.GroupHeader)
					{
						if (col == null)
							sbCopy.AppendLine(grow.GroupCaption);
					}
					else if (grow.RowType == RowType.Record || grow.RowType == RowType.NewRecord ||
						grow.RowType == RowType.FilterRow || grow.RowType == RowType.TotalRow)
					{
						if (col == null)
						{
							StringBuilder sbCells = new StringBuilder();
							for (int i = 0; i < grow.Cells.Count; i++)
								sbCells.AppendFormat("{0}{1}", (sbCells.Length > 0 ? "\t" : null),
									grow.Cells[i].Text);
							sbCopy.AppendLine(sbCells.ToString());
						}
						else
						{
							GridEXCell gcell = grow.Cells[col];
							sbCopy.AppendLine(gcell.Text);
						}
					}
				}

				Clipboard.SetText(sbCopy.ToString());
			}
			catch (Exception ex)
			{
				Display.ShowError("Grid", ex);
			}
		}

		private void AttemptPaste()
		{
			try
			{
				if (!(DataSource is DataTable || DataSource is DataSet)) return;

				bool result = Clipboard.ContainsText();
				if (!result) return;

				string clipText = Clipboard.GetText();
				if (string.IsNullOrEmpty(clipText)) return;

				int colCount = 0;
				char[] splitter = { '\t' };
				List<string[]> lst2 = new List<string[]>();
				using (StringReader sr = new StringReader(clipText))
				{
					string clipLine = null;
					while ((clipLine = sr.ReadLine()) != null)
					{
						string[] colvals = clipLine.Split(splitter);
						if (colvals != null && colvals.Length > colCount) colCount = colvals.Length;
						lst2.Add(colvals);
					}
				}

				GridEXColumn pasteCol = CopyPasteColumn;
				_RightClickColumn = null;
				_RightClicked = false;

				GridEXColumn[] pasteCols = new GridEXColumn[colCount];
				pasteCols[0] = pasteCol;
				int startPos = pasteCol.Position + 1;
				for (int i = 1; i < pasteCols.Length; i++)
				{
					pasteCols[i] = pasteCol.Table.Columns.GetColumnInPosition(startPos);
					startPos++;
				}

				GridEXRow currRow = GetRow();
				int selCount = (SelectedItems != null) ? SelectedItems.Count : 0;
				if (currRow.RowType == RowType.FilterRow && selCount <= 1)
				{
					string[] vals = (lst2.Count > 0) ? lst2[0] : null;
					string txt = (vals != null && vals.Length > 0) ? vals[0] : null;
					if (!string.IsNullOrWhiteSpace(txt)) SetValue(pasteCol, txt);
					return;
				}

				bool canEdit = AllowEdit.HasFlag(InheritableBoolean.True);
				bool canAdd = AllowAddNew.HasFlag(InheritableBoolean.True);
				if (!canEdit && !canAdd) return;

				if (pasteCol == null)
				{
					Display.ShowError("Paste Error", "No column selected");
					return;
				}

				if (pasteCol.EditType == EditType.NoEdit)
				{
					Display.ShowError("Paste Error", "Cannot paste into selected column, it is read-only");
					return;
				}

				List<DataRow> selDataRows = GetSelectedDataRowList();
				if (selDataRows.Count > 0)	// If more than 1 data row is selected,
				{							// we do not add rows (overwrite instead)
					if (!canEdit)
					{
						Display.ShowError("Paste Error", "Cannot paste, grid does not allow editing");
						return;
					}

					if (selDataRows.Count != lst2.Count)
					{
						Display.ShowError("Paste Error",
							"Number of rows selected {0} does not match number of rows copied {1}",
							selDataRows.Count, lst2.Count);
						return;
					}

					for (int i = 0; i < selDataRows.Count; i++)
					{
						DataRow dr = selDataRows[i];
						string[] colVals = lst2[i];
						for (int jCol = 0; jCol < colVals.Length; jCol++)
						{
							string s = colVals[jCol];
							if (jCol < pasteCols.Length)
							{
								GridEXColumn gCol = pasteCols[jCol];
								if( gCol != null && gCol.EditType != EditType.NoEdit)
									dr[gCol.DataMember] = ClsConvert.ToDbObject(s);
							}
						}
					}
					DataRow drDisplay = selDataRows[selDataRows.Count - 1];
					GridEXRow grow = this.GetRow(drDisplay);
					if (grow != null)
						this.EnsureVisible(grow.Position, pasteCol);
				}
				else	// Otherwise, no data rows selected, so we add. Note, selected DataRows are not the same as selected GridExRows.
				{		// So even if user has multiple grid rows selected, we can still wind up here (Group rows, filter row, new row, etc.)
					if (!canAdd)
					{
						Display.ShowError("Paste Error", "Cannot paste, grid does not allow new rows");
						return;
					}

					DataRow drDisplay = null;
					DataTable dt = this.DataSource as DataTable;
					foreach (string[] colVals in lst2)
					{
						DataRow dr = dt.NewRow();

						for (int jCol = 0; jCol < colVals.Length; jCol++)
						{
							string s = colVals[jCol];
							if (jCol < pasteCols.Length)
							{
								GridEXColumn gCol = pasteCols[jCol];
								if (gCol != null && gCol.EditType != EditType.NoEdit)
									dr[gCol.DataMember] = ClsConvert.ToDbObject(s);
							}
						}

						SetOtherColumnDefaults(dr, pasteCol.Table.Columns, pasteCols);

						dt.Rows.Add(dr);
						drDisplay = dr;		// get last one for display
					}

					GridEXRow grow = (drDisplay!=null) ? this.GetRow(drDisplay) : null;
					if (grow != null)
					{
						this.EnsureVisible(grow.Position, pasteCol);
						this.Row = grow.Position;
					}
				}
			}
			catch (Exception ex)
			{
				Display.ShowError("Paste Error", ex);
			}
		}

		private void SetOtherColumnDefaults(DataRow dr, GridEXColumnCollection allCols, GridEXColumn[] pastedCols)
		{
			try
			{
				foreach (GridEXColumn gcol in allCols)
				{
					if (!dr.Table.Columns.Contains(gcol.DataMember)) continue;

					bool wasPasted = false;
					foreach (GridEXColumn pcol in pastedCols)
					{
						if (pcol == gcol)
						{
							wasPasted = true;
							break;
						}
					}

					if (wasPasted) continue;

					dr[gcol.DataMember] = ClsConvert.ToDbObject(gcol.DefaultValue);
				}
			}
			catch (Exception ex)
			{
				ClsErrorHandler.LogException(ex);
			}
		}
		#endregion		// #region Copy/Paste

		#region Event Handlers

		protected void cnuFontSelector_Click(object sender, EventArgs e)
		{
			OpenFontSelector();
		}

		protected void cnuFieldChooser_Click(object sender, EventArgs e)
		{
			OpenFieldChooser();
		}

		protected void cnuPrintPort_Click(object sender, EventArgs e)
		{
			Print(false, null, true);
		}

		protected void cnuPrintLand_Click(object sender, EventArgs e)
		{
			Print(true, null, true);
		}

		protected void cnuPreviewPort_Click(object sender, EventArgs e)
		{
			Preview(false, null);
		}

		protected void cnuPreviewLand_Click(object sender, EventArgs e)
		{
			Preview(true, null);
		}

		protected void cnuExportAs_Click(object sender, EventArgs e)
		{
			Export(true, true);
		}

		protected void cnuExport_Click(object sender, EventArgs e)
		{
			Export(false, true);
		}

		protected void cnuExpandAll_Click(object sender, EventArgs e)
		{
			try
			{
				if( Hierarchical ) ExpandRecords();
				ExpandGroups();
			}
			catch( Exception ex )
			{
				Display.ShowError("Grid", ex);
			}
		}

		protected void cnuExpandGroup_Click(object sender, EventArgs e)
		{
			try
			{
				GridEXRow gr = GetRow();
				if( gr != null && gr.Group != null ) gr.Group.Expand();
			}
			catch( Exception ex )
			{
				Display.ShowError("Grid", ex);
			}
		}

		protected void cnuCollapseAll_Click(object sender, EventArgs e)
		{
			try
			{
				CollapseRecords();
				CollapseGroups();
				EnsureVisible(0);
			}
			catch( Exception ex )
			{
				Display.ShowError("Grid", ex);
			}
		}

		protected void cnuCollapseGroup_Click(object sender, EventArgs e)
		{
			try
			{
				GridEXRow gr = GetRow();
				if( gr != null && gr.Group != null ) gr.Group.Collapse();
			}
			catch( Exception ex )
			{
				Display.ShowError("Grid", ex);
			}
		}

		protected void _cnuParent_Disposed(object sender, EventArgs e)
		{
			try
			{
				if( _cnuParent != null ) _cnuParent = null;
				if( ContextMenuStrip != _cnuGrid ) ContextMenuStrip = _cnuGrid;
			}
			catch( Exception ex )
			{
				Display.ShowError("Grid", ex);
			}
		}

		protected void _cnuGrid_Opening(object sender, CancelEventArgs e)
		{
			try
			{
				cnuCollapseAll.Visible = cnuExpandAll.Visible =
					cnuGridN3.Visible = ( Hierarchical == true ||
					( RootTable != null && RootTable.Groups.Count > 0 ) );

				cnuCollapseGroup.Visible = cnuExpandGroup.Visible = false;

				GridArea ga = HitTest();
				if (ga == GridArea.GroupRow)
				{
					cnuCollapseGroup.Visible = cnuExpandGroup.Visible = true;
					GridEXRow gr = GetRow();
					if( gr != null && gr.Group != null )
					{
						cnuCollapseGroup.Text =
							string.Format("Collapse \"{0}\" Group", gr.Group.HeaderCaption);
						cnuExpandGroup.Text =
							string.Format("Expand \"{0}\" Group", gr.Group.HeaderCaption);
					}
				}

				GridEXColumn col = CopyPasteColumn;

				bool canEdit = AllowEdit.HasFlag(InheritableBoolean.True);
				bool canAdd = AllowAddNew.HasFlag(InheritableBoolean.True);
				cnuPaste.Visible = (canEdit || canAdd);
				cnuPaste.Enabled = (col != null && col.EditType != EditType.NoEdit);

				int selCount = (SelectedItems != null) ? SelectedItems.Count : 0;
				if (selCount <= 0)
				{
					cnuCopyCell.Enabled = false;
					cnuCopyCell.Text = "Copy Cells";
				}
				else
				{
					cnuCopyCell.Enabled = true;
					if (selCount == 1)
						cnuCopyCell.Text = "Copy " + (col != null ? "Cell" : "Row");
					else
					{
						if (col != null)
							cnuCopyCell.Text = string.Format("Copy ({0} Cells from {1})",
								selCount, col.Caption);
						else
							cnuCopyCell.Text = string.Format("Copy ({0} Rows)", selCount);
					}
				}
			}
			catch( Exception ex )
			{
				Display.ShowError("Grid", ex);
			}
		}

		private void _cnuGrid_Closed(object sender, ToolStripDropDownClosedEventArgs e)
		{
			try
			{
				if (e.CloseReason != ToolStripDropDownCloseReason.ItemClicked)
				{
					_RightClickColumn = null;
					_RightClicked = false;
				}
			}
			catch (Exception ex)
			{
				Display.ShowError("Grid", ex);
			}
		}
		#endregion		// #region Event Handlers
	}

	public enum ExportMode { AllRows, CheckedRows }
}