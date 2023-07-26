using System;
using System.Data;
using System.Reflection;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;
using CS2010.Common;
using Janus.Windows.GridEX;
using Janus.Windows.GridEX.EditControls;

namespace CS2010.CommonWinCtrls
{
	#region Combo Enums

	/// <summary>Controls what is displayed in the combo box</summary>
	public enum ComboDisplay
	{
		// Show only the code column
		CodeOnly,
		// Show only the description column
		DescriptionOnly,
		// Show the code followed by the description
		CodePlusDescription,
		// Show the description followed by the code
		DescriptionPlusCode
	}

	/// <summary>Controls how the view in a combo box is sorted</summary>
	public enum ComboSortType
	{
		/// <summary>Sort on the code column</summary>
		Code,
		/// <summary>Sort on the description column</summary>
		Description,
		/// <summary>Sort on the value column</summary>
		Value,
		/// <summary>Do not sort, use whatever order the datasource is in</summary>
		None
	}
	#endregion		// #region Combo Enums

	#region Menu Helper

	/// <summary>Menu helper class for text box controls or controls with a text
	/// area (combo boxes)</summary>
	public class MenuHelper
	{
		#region Constants

		protected const string UndoItem = "Undo";
		protected const string CutItem = "Cut";
		protected const string CopyItem = "Copy";
		protected const string PasteItem = "Paste";
		protected const string DeleteItem = "Delete";
		protected const string SelectAllItem = "SelectAll";
		protected const string ResetListItem = "Reset";

		#endregion		// #region Constants

		#region Fields

		/// <summary>The control to associate with a context menu (the actions
		/// on the menu will be performed on this object)</summary>
		protected object Control;
		protected ContextMenuStrip _MenuStrip;	// MenuStrip property

		#endregion		// #region Fields

		#region Properties

		/// <summary>Gets the a context menu strip that can be associated with a
		/// control</summary>
		public ContextMenuStrip MenuStrip
		{
			get { return _MenuStrip; }
		}
		#endregion		// #region Properties

		#region Constructors

		/// <summary>Constructor (expects a windows forms control)</summary>
		/// <param name="aControl">The windows form control to associate
		/// the menu with</param>
		public MenuHelper(object aControl)
		{
			Control = aControl;

			_MenuStrip = new ContextMenuStrip();

			CreateMenu();
		}
		#endregion		// #region Constructors

		#region Public Methods

		/// <summary>Attempt to call Control.Undo()</summary>
		public void Undo()
		{
			RunMethod(UndoItem);
		}

		/// <summary>Attempt to call Control.Cut()</summary>
		public void Cut()
		{
			RunMethod(CutItem);
		}

		/// <summary>Attempt to call Control.Copy()</summary>
		public void Copy()
		{
			RunMethod(CopyItem);
		}

		/// <summary>Attempt to call Control.Paste()</summary>
		public void Paste()
		{
			RunMethod(PasteItem);
		}

		/// <summary>Attempt to call Control.Delete()</summary>
		public void Delete()
		{
			RunMethod(DeleteItem);
		}

		/// <summary>Attempt to call Control.SelectAll()</summary>
		public void SelectAll()
		{
			RunMethod(SelectAllItem);
		}

		/// <summary>Attempt to call Combo.Reset() method</summary>
		public void Reset()
		{
			RunMethod(ResetListItem);
		}
		#endregion		// #region Public Methods

		#region Helper Methods

		/// <summary>Assemble the context menu</summary>
		protected virtual void CreateMenu()
		{
			AddMenuStripItem(UndoItem, miUndo_Click);

			_MenuStrip.Items.Add("-");

			AddMenuStripItem(CutItem, miCut_Click);
			AddMenuStripItem(CopyItem, miCopy_Click);
			AddMenuStripItem(PasteItem, miPaste_Click);

			_MenuStrip.Items.Add("-");

			AddMenuStripItem(SelectAllItem, miSelect_Click);

			_MenuStrip.Items.Add("-");

			AddMenuStripItem(ResetListItem, miReset_Click);
		}

		/// <summary>Attempt to add a menu item to the context menu with the
		/// specified event handler (the item will only be added if a method
		/// exists on the Control with the same name</summary>
		/// <param name="name">The name of the method/menu item</param>
		/// <param name="miHandler">The event handler to run for that item</param>
		/// <returns>Returns a MenuItem if added, or null if not</returns>
		protected ToolStripItem AddMenuStripItem(string name, EventHandler miHandler)
		{
			if( MethodExists(name) == null ) return null;

			ToolStripItem mi = _MenuStrip.Items.Add(name);
			mi.Click += new EventHandler(miHandler);
			return mi;
		}

		/// <summary>Check if a particular method exists for the Control</summary>
		/// <param name="name">The name of the method</param>
		/// <returns>A MethodInfo object with information about the method
		/// if found, or null if the method was not found</returns>
		protected MethodInfo MethodExists(string name)
		{
			try
			{
				Type t = Control.GetType();
				return t.GetMethod(name,
					System.Reflection.BindingFlags.IgnoreCase |
					System.Reflection.BindingFlags.Instance |
					System.Reflection.BindingFlags.Public);
			}
			catch( Exception ex )
			{
				Display.ShowError("Context Menu Error", ex);
				return null;
			}
		}

		/// <summary>Check if a particular property exists on the Control</summary>
		/// <param name="name">The name of the property</param>
		/// <returns>A PropertyInfo object with information about the property
		/// if found, or null if the property was not found</returns>
		protected PropertyInfo PropertyExists(string name)
		{
			try
			{
				Type t = Control.GetType();
				return t.GetProperty(name);
			}
			catch( Exception ex )
			{
				Display.ShowError("Context Menu Error", ex);
				return null;
			}
		}

		/// <summary>Attempt to run a method on the 'Control' with the
		/// passed name</summary>
		/// <param name="name">The name of the method to run</param>
		/// <returns>The return value of the method</returns>
		protected object RunMethod(string name)
		{
			try
			{
				MethodInfo mi = MethodExists(name);
				if( mi == null )
					throw new ApplicationException
						(name + " is not available for this control");

				return mi.Invoke(Control, null);
			}
			catch( Exception ex )
			{
				Display.ShowError("Error", ex.Message);
				return null;
			}
		}
		#endregion		// #region Helper Methods

		#region Event Handlers

		protected void miUndo_Click(object sender, EventArgs e)
		{
			Undo();
		}

		protected void miCut_Click(object sender, EventArgs e)
		{
			Cut();
		}

		protected void miCopy_Click(object sender, EventArgs e)
		{
			Copy();
		}

		protected void miPaste_Click(object sender, EventArgs e)
		{
			Paste();
		}

		protected void miSelect_Click(object sender, EventArgs e)
		{
			SelectAll();
		}

		protected void miReset_Click(object sender, EventArgs e)
		{
			Reset();
		}
		#endregion		// #region Event Handlers
	}
	#endregion		// #region Menu Helper Classes

	#region Combo Menu Helper Classes

	/// <summary>Menu helper class for combo box type of controls
	/// (derived from MenuHelper)</summary>
	public class ComboMenuHelper : MenuHelper
	{
		#region Constructors

		protected const string DisplayProperty = "DisplayType";

		#endregion		// #region Constructors

		#region Fields

		/// <summary>Display code only menu item</summary>
		protected ToolStripMenuItem tmiCode;
		/// <summary>Display description only menu item</summary>
		protected ToolStripMenuItem tmiDescription;
		/// <summary>Display code then description menu item</summary>
		protected ToolStripMenuItem tmiBoth;
		/// <summary>Display description then code menu item</summary>
		protected ToolStripMenuItem tmiBothReverse;

		#endregion		// #region Fields

		#region Constructors

		/// <summary>Constructor expecting a windows form control</summary>
		/// <param name="aControl"></param>
		public ComboMenuHelper(object aControl) : base(aControl) { }

		#endregion		// #region Constructors

		#region Public Methods

		public void SetMenuItem(ComboDisplay dispType)
		{
			tmiCode.Checked = tmiDescription.Checked = tmiBoth.Checked =
				tmiBothReverse.Checked = false;
			switch( dispType )
			{
				case ComboDisplay.DescriptionOnly:
					tmiDescription.Checked = true;
					break;
				case ComboDisplay.CodePlusDescription:
					tmiBoth.Checked = true;
					break;
				case ComboDisplay.DescriptionPlusCode:
					tmiBothReverse.Checked = true;
					break;
				case ComboDisplay.CodeOnly:
				default:
					tmiCode.Checked = true;
					break;
			}
		}
		#endregion		// #region Public Methods

		#region Helper Methods

		/// <summary>Assemble the context menu</summary>
		protected override void CreateMenu()
		{
			base.CreateMenu();

			PropertyInfo pi = PropertyExists(DisplayProperty);
			if( pi == null ) return;

			_MenuStrip.Items.Add("-");

			tmiCode = (ToolStripMenuItem)_MenuStrip.Items.Add
				("Display Code", null, miDisplayCode_Click);
			tmiCode.Checked = true;

			tmiDescription = (ToolStripMenuItem)_MenuStrip.Items.Add
				("Display Description", null, miDisplayDesc_Click);
			tmiBoth = (ToolStripMenuItem)_MenuStrip.Items.Add
				("Display Code + Description", null, miDisplayBoth_Click);
			tmiBothReverse = (ToolStripMenuItem)_MenuStrip.Items.Add
				("Display Description + Code", null, miDisplayBothReverse_Click);
		}

		/// <summary>Set the display type to a new value</summary>
		/// <param name="dispType">The new display type</param>
		/// <param name="mi">The menu that triggered the display change</param>
		protected void SetDisplay(ComboDisplay dispType, ToolStripMenuItem mi)
		{
			PropertyInfo pi = PropertyExists(DisplayProperty);
			if( pi == null )
				throw new ApplicationException
					(DisplayProperty + " property not available for this control");
			pi.SetValue(Control, dispType, null);

			tmiCode.Checked = tmiDescription.Checked = tmiBoth.Checked =
				tmiBothReverse.Checked = false;
			mi.Checked = true;
		}
		#endregion		// #region Helper Methods

		#region Event Handlers

		protected void miDisplayCode_Click(object sender, EventArgs e)
		{
			SetDisplay(ComboDisplay.CodeOnly, tmiCode);
		}

		protected void miDisplayDesc_Click(object sender, EventArgs e)
		{
			SetDisplay(ComboDisplay.DescriptionOnly, tmiDescription);
		}

		protected void miDisplayBoth_Click(object sender, EventArgs e)
		{
			SetDisplay(ComboDisplay.CodePlusDescription, tmiBoth);
		}

		protected void miDisplayBothReverse_Click(object sender, EventArgs e)
		{
			SetDisplay(ComboDisplay.DescriptionPlusCode, tmiBothReverse);
		}
		#endregion		// #region Event Handlers
	}
	#endregion		// #region Combo Menu Helper Classes

	#region ColumnNameChanged Event

	public delegate void ColumnNameChangedEventHandler
	(object sender, ColumnNameChangedEventArgs e);

	public class ColumnNameChangedEventArgs : EventArgs
	{
		#region Fields

		protected string _OldValue;
		protected string _NewValue;
		protected string _ColumnName;

		#endregion		// #region Fields

		#region Properties

		public string OldValue { get { return _OldValue; } }
		public string NewValue { get { return _OldValue; } }
		public string ColumnName { get { return _ColumnName; } }

		#endregion		// #region Properties

		#region Constructors

		public ColumnNameChangedEventArgs(string col, string oldVal, string newVal)
		{
			_OldValue = oldVal;
			_NewValue = newVal;
			_ColumnName = col;
		}
		#endregion		// #region Constructors
	}
	#endregion		// #region ColumnNameChanged Event

	#region IComboBox Interface

	public interface IComboBox
	{
		#region Properties

		/// <summary>Occurs when the Filter property changes</summary>
		[Description("Occurs when the Filter property changes")]
		event EventHandler FilterChanged;
		/// <summary>Occurs when the DisplayType property changes</summary>
		[Description("Occurs when the DisplayType property changes")]
		event EventHandler DisplayTypeChanged;
		/// <summary>Occurs when one of the "Column" properties (CodeColumn,
		/// ValueColumn, DescriptionColumn) changes</summary>
		[Description("Occurs when one of the 'Column' properties (CodeColumn, " +
		"ValueColumn, DescriptionColumn) changes")]
		event ColumnNameChangedEventHandler ColumnNameChanged;

		/// <summary>Gets/sets whether inactive items will be displayed in the
		/// combo box (inactive items have a DELETED_FLG value of Y or an ACTIVE_FLG
		/// value of "N")</summary>
		[Browsable(true), DefaultValue(false),
		Description("Gets/sets whether inactive items will be displayed in the" +
			"combo box (inactive items have a DELETED_FLG value of Y or an ACTIVE_FLG" +
			"value of N)")]
		bool ShowInactive
		{
			get;
			set;
		}

		/// <summary>Gets/sets whether the context menu that controls the combo
		/// display is displayed or not</summary>
		[Browsable(true), DefaultValue(true),
		Description("Gets/sets whether the context menu that controls the combo " +
			"display is shown or not")]
		bool ShowContextMenu
		{
			get;
			set;
		}

		/// <summary>Gets/Sets the expression used to filter the items shown
		/// in the combo box (it is applied to the DataView's RowFilter)</summary>
		[Browsable(true), DefaultValue(""),
		Description("Gets/Sets the expression used to filter the data table")]
		string Filter
		{
			get;
			set;
		}

		/// <summary>Gets/Sets the DataTable used to fill the combo box (the
		/// combo box data source will be a DataView created from this DataTable,
		/// it will not use the DataTable directly</summary>
		[Browsable(false), DefaultValue(null),
		Description("Gets/Sets the data table used to fill the combo box")]
		DataTable Table
		{
			get;
			set;
		}

		/// <summary>Gets the view that is used as the data source (it is a
		/// DataView created from the Table (DataTable) property)</summary>
		[Browsable(false)]
		DataView View
		{
			get;
		}

		/// <summary>Gets/Sets the name of the Table's code column</summary>
		[Browsable(true), DefaultValue(""),
		Description("Gets/Sets the name of the data table's code column")]
		string CodeColumn
		{
			get;
			set;
		}

		/// <summary>Gets/Sets the name of the Table's primary key column</summary>
		[Browsable(true), DefaultValue(""),
		Description("Gets/Sets the name of the data table's primary key column")]
		string ValueColumn
		{
			get;
			set;
		}

		/// <summary>Gets/Sets the name of the Table's description column</summary>
		[Browsable(true), DefaultValue(""),
		Description("Gets/Sets the name of the data table's description column")]
		string DescriptionColumn
		{
			get;
			set;
		}

		/// <summary>Gets/Sets the type displayed in the text area (see the
		/// ComboDisplay enum for more information)</summary>
		[Browsable(true),
		Description("Gets/Sets the type displayed in the text area")]
		ComboDisplay DisplayType
		{
			get;
			set;
		}

		/// <summary>Gets/Sets the column that the data should be sorted on (see
		/// the ComboSortType enum for more information)</summary>
		[Browsable(true), Description("Gets/Sets the column to sort the data on")]
		ComboSortType SortType
		{
			get;
			set;
		}

		/// <summary>Context Menu helper class (can be used to perform
		/// cut, copy, paste, etc.)</summary>
		[Browsable(false)]
		ComboMenuHelper MenuHelper
		{
			get;
		}

		/// <summary>The name of the column used as the display (it depends on
		/// the vale of the DisplayType property)</summary>
		[Browsable(false)]
		string DisplayMemberName
		{
			get;
		}

		/// <summary>The name of the column used as the Value member</summary>
		[Browsable(false)]
		string ValueMemberName
		{
			get;
		}
		#endregion		// #region Properties
	}
	#endregion		// #region IComboBox Interface

	public static class BindHelper
	{
		public static void Bind(Control c, object src, string colName)
		{
			try
			{
				string controlColumn = null;
				if( c is MultiColumnCombo || c is CheckedComboBox ||
					c is ucDateTextBox || c is NumericEditBox )
					controlColumn = "Value";
				else if( c is ComboBox || c is ucComboBox )
					controlColumn = "SelectedValue";
				else if( c is ucCheckBox )
					controlColumn = "YN";
				else
					controlColumn = "Text";		// default to Text (i.e. TextBox)

				if( c.DataBindings[controlColumn] != null )
					c.DataBindings.Remove(c.DataBindings[controlColumn]);
				c.DataBindings.Add(controlColumn, src, colName, true,
					DataSourceUpdateMode.OnPropertyChanged);
			}
			catch( Exception ex )
			{
				Display.ShowError("Binding Error", ex);
			}
		}
	}

	public static class WindowHelper
	{
		#region Window Display

		static public void ShowChildWindow(frmChildBase f)
		{
			f.Show();
			f.Activate();
			if( f.WindowState == FormWindowState.Minimized )
				f.WindowState = FormWindowState.Maximized;
		}

		static public bool ShowModalWindow(frmDialogBase f)
		{
			return ( f.ShowDialog() == DialogResult.OK );
		}

		public static Form MDIParent
		{
			get
			{
				foreach (Form f in Application.OpenForms)
				{
					if (f.IsMdiContainer) return f;
				}
				return null;
			}
		}

		public static void SetMainMenuStatus(bool enabled)
		{
			IMdiParent f = MDIParent as IMdiParent;
			if (f != null) f.SetMainMenuStatus(enabled);
		}
		#endregion		// #region Window Display

		#region GridEx Initialization

		static public void InitAllGrids(Form f)
		{
			// By deault do not disable "selectable" on all columns
			InitAllGrids(f, false);
		}
		static public void InitAllGrids(Form f, bool bDisableSelect)
		{
			try
			{
				InitGrids(f.Controls, bDisableSelect);
			}
			catch( Exception ex )
			{
				Display.ShowError("Form Init Grid", ex);
			}
		}

		static public void InitGrids(Control.ControlCollection ctrls)
		{
			InitGrids(ctrls, false);
		}
		static public void InitGrids(Control.ControlCollection ctrls, bool bDisableSelect)
		{
			try
			{
				if( ctrls == null ) return;

				foreach( Control c in ctrls )
				{
					GridEX grd = c as GridEX;
					if( grd != null )
					{
						if( grd.RootTable != null )
						{
							InitGridTable(grd.RootTable, bDisableSelect);

							foreach( GridEXTable t in grd.RootTable.ChildTables )
								InitGridTable(t, bDisableSelect);
						}
					}
					else
					{
						if( c.Controls != null && c.Controls.Count > 0 )
							InitGrids(c.Controls, bDisableSelect );
					}
				}
			}
			catch( Exception ex )
			{
				Display.ShowError("Control Init Grid", ex);
			}
		}

		static public void InitGridTable(GridEXTable grdTab)
		{
			InitGridTable(grdTab, false);
		}
		static public void InitGridTable(GridEXTable grdTab, bool bDisableSelect)
		{
			try
			{
				if( grdTab == null ) return;

				foreach( GridEXColumn col in grdTab.Columns )
				{
					string dataMember = string.IsNullOrWhiteSpace(col.DataMember)
						? string.Empty : col.DataMember;
					if( col.Key.EndsWith("Dt",
						StringComparison.InvariantCultureIgnoreCase) == true ||
						col.Key.EndsWith("Date",
						StringComparison.InvariantCultureIgnoreCase) == true ||
						dataMember.EndsWith("Dt",
						StringComparison.InvariantCultureIgnoreCase) == true ||
						dataMember.EndsWith("Date",
						StringComparison.InvariantCultureIgnoreCase) == true )
					{
						col.FormatString = ClsConfig.DateFormat;
						col.DefaultGroupInterval = GroupInterval.Date;
					}
                    if ( col.Key.ToLower().EndsWith("_nbr") ||
						dataMember.ToLower().EndsWith("_nbr") )
                    {
                        col.TextAlignment = TextAlignment.Far;
                    }
                    if (col.FormatString == "c")
                        col.TextAlignment = TextAlignment.Far;
					if (bDisableSelect)
						col.Selectable = false;
				}
			}
			catch( Exception ex )
			{
				Display.ShowError("Grid Table Init", ex);
			}
		}
		#endregion		// #region GridEx Initialization

		#region Info Display

		static public void FillListView(ListView lvw, Dictionary<string, string> info)
		{
			try
			{
				lvw.HeaderStyle = ColumnHeaderStyle.None;
				lvw.MultiSelect = false;
				lvw.View = System.Windows.Forms.View.Details;
				lvw.Columns.Clear();
				lvw.Columns.Add("Key");
				lvw.Columns.Add("Value");
				lvw.Items.Clear();
				foreach( string key in info.Keys )
				{
					ListViewItem lvi = lvw.Items.Add(key);
					lvi.SubItems.Add(info[key]);
				}
			}
			catch( Exception ex )
			{
				Display.ShowError("ListView display error", ex);
			}
			finally
			{
				lvw.AutoResizeColumns
					(ColumnHeaderAutoResizeStyle.None);
				lvw.AutoResizeColumns
					(ColumnHeaderAutoResizeStyle.ColumnContent);
			}
		}
		#endregion		// #region Info Display

		#region Control Clearing

		static public void ClearAllControls(Form f)
		{
			ClearControls(f.Controls);
		}

		static public void ClearControls(Control.ControlCollection ctrls)
		{
			try
			{
				foreach( Control c in ctrls )
				{
					if( c is Button || c is Label || c is LinkLabel ) continue;

					if( c is ucDateGroupBox )
					{
						ucDateGroupBox grp = c as ucDateGroupBox;
						grp.Clear();
					}
					else if( c is CheckBox )
					{
						CheckBox cb = c as CheckBox;
						if( cb != null ) cb.Checked = false;
					}
					else if( c is CheckedComboBox )
					{
						CheckedComboBox cmb = c as CheckedComboBox;
						if( cmb != null )
						{
							cmb.CheckedItems = null;
							cmb.Text = string.Empty;
						}
					}
					else if( c is ucDateTextBox )
					{
						ucDateTextBox dtxt = c as ucDateTextBox;
						if( dtxt != null ) dtxt.Value = null;
					}
					else if( c is IntegerUpDown )
					{
						IntegerUpDown ud = c as IntegerUpDown;
						if( ud != null ) ud.Value = 0;
					}
					else if( c is NumericEditBox )
					{
						NumericEditBox num = c as NumericEditBox;
						if( num != null ) num.Value = 0;
					}
					else if( c is MultiColumnCombo || c is TextBoxBase || c is EditBox ||
						c is MaskedEditBox || c is ucValueListUpDown || c is ComboBox )
					{
						c.Text = null;
					}
					else if( c is TabControl )
					{
						TabControl tc = c as TabControl;
						if( tc != null )
							foreach( TabPage pg in tc.TabPages )
								ClearControls(pg.Controls);
					}
                    else if (c is ucComboBox)
                    {
                        ucComboBox ucCB = c as ucComboBox;
                        ucCB.SelectedValue = "";
                    }
                    else if ((c is GroupBox || c is Panel) &&
                        c.Controls.Count > 0) ClearControls(c.Controls);
				}
			}
			catch( Exception ex )
			{
				Display.ShowError("Clear Fields", ex);
			}
		}
		#endregion		// #region Control Clearing
	}

	public interface IMdiParent
	{
		void SetMainMenuStatus(bool enabled);
	}

	public static class ControlHelper
	{
	}
}