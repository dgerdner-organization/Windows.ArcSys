using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using Janus.Windows.GridEX;

namespace CS2010.CommonWinCtrls
{
	[ToolboxItem(true)]
	[DesignTimeVisible(true)]
	[ToolboxBitmap(typeof(ToolStrip))]
	public partial class ucGridToolStrip : ToolStrip
	{
		#region Fields

		protected bool _HideAddButton;
		protected bool _HideEditButton;
		protected bool _HideDeleteButton;
		protected bool _HideSeparator;
		protected bool _HideExportMenu;
		protected bool _HidePrintMenu;

		protected bool _EnterKeyEnabled;
		protected bool _DeleteKeyEnabled;
		protected bool _EditOnDoubleClick;

		protected ucGridEx _GridEx;
		protected ToolStripButton tbbAdd;
		protected ToolStripButton tbbEdit;
		protected ToolStripButton tbbDelete;
		protected ToolStripSeparator tbbN1;
		protected ToolStripDropDownButton tbbExportMenu;
		protected ToolStripButton tbbExportGrid;
		protected ToolStripButton tbbExportGridAs;
		protected ToolStripDropDownButton tbbPrintMenu;
		protected ToolStripButton tbbPrintPreview;
		protected ToolStripButton tbbPrintPreviewLand;
		protected ToolStripButton tbbPrint;
		protected ToolStripButton tbbPrintLand;

		protected KeyEventHandler GridKeyDown;
		protected EventHandler GridDoubleClick;

		#endregion		// #region Fields

		#region Properties

		[Description("The grid that the toolstrip items will act upon")]
		public ucGridEx GridObject
		{
			get { return _GridEx; }
			set
			{
				_GridEx = value;
				UpdateGrid(_GridEx, value);
			}
		}

		/// <summary>Gets/Sets whether the enter key fires the
		/// ClickEdit event</summary>
		[DefaultValue(true)]
		[Description("Gets/Sets whether the enter key fires the ClickEdit event")]
		public bool EnterKeyEnabled
		{
			get { return _EnterKeyEnabled; }
			set { _EnterKeyEnabled = value; }
		}

		/// <summary>Gets/Sets whether the delete key fires the
		/// ClickDelete event</summary>
		[DefaultValue(true)]
		[Description("Gets/Sets whether the delete key fires the ClickDelete event")]
		public bool DeleteKeyEnabled
		{
			get { return _DeleteKeyEnabled; }
			set { _DeleteKeyEnabled = value; }
		}

		/// <summary>Gets/Sets whether a double click fires the
		/// ClickEdit event</summary>
		[DefaultValue(true)]
		[Description("Gets/Sets whether a double click fires the ClickEdit event")]
		public bool EditOnDoubleClick
		{
			get { return _EditOnDoubleClick; }
			set { _EditOnDoubleClick = value; }
		}

		[Browsable(false)]
		public bool IsAddVisible { get { return tbbAdd.Visible; } }

		[Browsable(false)]
		public bool IsEditVisible { get { return tbbEdit.Visible; } }

		[Browsable(false)]
		public bool IsDeleteVisible { get { return tbbDelete.Visible; } }

		[DefaultValue(false)]
		[Description("Gets/Sets whether to hide the add button")]
		public bool HideAddButton
		{
			get { return _HideAddButton; }
			set { _HideAddButton = value; tbbAdd.Visible = !_HideAddButton; }
		}
		[DefaultValue(false)]
		[Description("Gets/Sets whether to hide the edit button")]
		public bool HideEditButton
		{
			get { return _HideEditButton; }
			set { _HideEditButton = value; tbbEdit.Visible = !_HideEditButton; }
		}
		[DefaultValue(false)]
		[Description("Gets/Sets whether to hide the delete button")]
		public bool HideDeleteButton
		{
			get { return _HideDeleteButton; }
			set { _HideDeleteButton = value; tbbDelete.Visible = !_HideDeleteButton; }
		}
		[DefaultValue(false)]
		[Description("Gets/Sets whether to hide the separator")]
		public bool HideSeparator
		{
			get { return _HideSeparator; }
			set { _HideSeparator = value; tbbN1.Visible = !_HideSeparator; }
		}
		[DefaultValue(false)]
		[Description("Gets/Sets whether to hide the export menu")]
		public bool HideExportMenu
		{
			get { return _HideExportMenu; }
			set { _HideExportMenu = value; tbbExportMenu.Visible = !_HideExportMenu; }
		}
		[DefaultValue(false)]
		[Description("Gets/Sets whether to hide the print menu")]
		public bool HidePrintMenu
		{
			get { return _HidePrintMenu; }
			set { _HidePrintMenu = value; tbbPrintMenu.Visible = !_HidePrintMenu; }
		}

		[DefaultValue("&Add")]
		[Description("Gets/Sets the add button's label text")]
		public string TextAddButton
		{
			get { return tbbAdd.Text; }
			set { tbbAdd.Text = value; }
		}

		[DefaultValue("&Edit")]
		[Description("Gets/Sets the edit button's label text")]
		public string TextEditButton
		{
			get { return tbbEdit.Text; }
			set { tbbEdit.Text = value; }
		}

		[DefaultValue("&Delete")]
		[Description("Gets/Sets the delete button's label text")]
		public string TextDeleteButton
		{
			get { return tbbDelete.Text; }
			set { tbbDelete.Text = value; }
		}

		[Description("Occurs when the add item is clicked")]
		public event EventHandler ClickAdd;
		[Description("Occurs when the edit item is clicked")]
		public event EventHandler ClickEdit;
		[Description("Occurs when the delete item is clicked")]
		public event EventHandler ClickDelete;

		#endregion		// #region Properties

		#region Constructors

		public ucGridToolStrip()
		{
			InitializeComponent();

			_HideAddButton = false;
			_HideEditButton = false;
			_HideDeleteButton = false;
			_HideSeparator = false;
			_HideExportMenu = false;
			_HidePrintMenu = false;

			_EnterKeyEnabled = true;
			_DeleteKeyEnabled = true;
			_EditOnDoubleClick = true;

			CreateToolStripItems();
			GridKeyDown = new KeyEventHandler(grid_KeyDown);
			GridDoubleClick = new EventHandler(grid_DoubleClick);
		}
		#endregion		// #region Constructors

		#region Helper Methods

		protected void CreateToolStripItems()
		{
			tbbAdd = new ToolStripButton("&Add");
			tbbEdit = new ToolStripButton("&Edit");
			tbbDelete = new ToolStripButton("&Delete");
			tbbN1 = new ToolStripSeparator();
			tbbAdd.Click += new EventHandler(tbbAdd_Click);
			tbbEdit.Click += new EventHandler(tbbEdit_Click);
			tbbDelete.Click += new EventHandler(tbbDelete_Click);
			tbbAdd.ToolTipText = "Add an item to the grid";
			tbbEdit.ToolTipText = "Edit the selected item";
			tbbDelete.ToolTipText = "Delete the selected item from the grid";

			tbbExportMenu = new ToolStripDropDownButton("Export");
			tbbExportGrid = new ToolStripButton("Export...");
			tbbExportGridAs = new ToolStripButton("Export As...");
			tbbExportGrid.Click += new EventHandler(tbbExportGrid_Click);
			tbbExportGridAs.Click += new EventHandler(tbbExportGridAs_Click);

			tbbPrintMenu = new ToolStripDropDownButton("Print");
			tbbPrint = new ToolStripButton("Print Portrait");
			tbbPrintLand = new ToolStripButton("Print Landscape");
			tbbPrintPreview = new ToolStripButton("Preview Portrait");
			tbbPrintPreviewLand = new ToolStripButton("Preview Landscape");
			tbbPrint.Click += new EventHandler(tbbPrint_Click);
			tbbPrintLand.Click += new EventHandler(tbbPrintLand_Click);
			tbbPrintPreview.Click += new EventHandler(tbbPrintPreview_Click);
			tbbPrintPreviewLand.Click +=
				new EventHandler(tbbPrintPreviewLand_Click);

			Items.Add(tbbAdd);
			Items.Add(tbbEdit);
			Items.Add(tbbDelete);
			Items.Add(tbbN1);
			Items.Add(tbbExportMenu);
			Items.Add(tbbPrintMenu);

			tbbExportMenu.DropDownItems.Add(tbbExportGrid);
			tbbExportMenu.DropDownItems.Add(tbbExportGridAs);
			tbbPrintMenu.DropDownItems.Add(tbbPrint);
			tbbPrintMenu.DropDownItems.Add(tbbPrintLand);
			tbbPrintMenu.DropDownItems.Add(new ToolStripSeparator());
			tbbPrintMenu.DropDownItems.Add(tbbPrintPreview);
			tbbPrintMenu.DropDownItems.Add(tbbPrintPreviewLand);
		}

		private void UpdateGrid(ucGridEx grdOld, ucGridEx grdNew)
		{
			if( grdOld != null )
			{
				grdOld.KeyDown -= GridKeyDown;
				grdOld.DoubleClick -= GridDoubleClick;
			}
			if( grdNew != null )
			{
				grdNew.KeyDown += GridKeyDown;
				grdNew.DoubleClick += GridDoubleClick;
			}
		}
		#endregion		// #region Helper Methods

		#region ToolStripItem Event Handlers

		private void tbbAdd_Click(object sender, EventArgs e)
		{
			if( ClickAdd != null ) ClickAdd(sender, e);
		}

		private void tbbEdit_Click(object sender, EventArgs e)
		{
			if( ClickEdit != null ) ClickEdit(sender, e);
		}

		private void tbbDelete_Click(object sender, EventArgs e)
		{
			if( ClickDelete != null ) ClickDelete(sender, e);
		}

		private void tbbExportGrid_Click(object sender, EventArgs e)
		{
			if( GridObject != null ) GridObject.Export(false, true);
		}

		private void tbbExportGridAs_Click(object sender, EventArgs e)
		{
			if( GridObject != null ) GridObject.Export(true, true);
		}

		private void tbbPrint_Click(object sender, EventArgs e)
		{
			if( GridObject != null ) GridObject.Print(false, null, true);
		}

		private void tbbPrintLand_Click(object sender, EventArgs e)
		{
			if( GridObject != null ) GridObject.Print(true, null, true);
		}

		private void tbbPrintPreview_Click(object sender, EventArgs e)
		{
			if( GridObject != null ) GridObject.Preview(false, null);
		}

		private void tbbPrintPreviewLand_Click(object sender, EventArgs e)
		{
			if( GridObject != null ) GridObject.Preview(true, null);
		}
		#endregion		// #region ToolStripItem Event Handlers

		#region Grid Event Handlers

		private void grid_KeyDown(object sender, KeyEventArgs e)
		{
			if( e.KeyCode == Keys.Enter && _EnterKeyEnabled == true &&
				ClickEdit != null )
			{
				e.Handled = true;
				ClickEdit(sender, EventArgs.Empty);
			}
			else if( e.KeyCode == Keys.Delete && _DeleteKeyEnabled == true &&
				ClickDelete != null )
			{
				e.Handled = true;
				ClickDelete(sender, EventArgs.Empty);
			}
		}

		private void grid_DoubleClick(object sender, EventArgs e)
		{
			GridArea ga = GridObject.HitTest();
			if( ga != GridArea.Cell ) return;

			if( _EditOnDoubleClick == true && ClickEdit != null )
				ClickEdit(sender, EventArgs.Empty);
		}
		#endregion		// #region Grid Event Handlers
	}
}