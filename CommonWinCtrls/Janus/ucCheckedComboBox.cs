using System;
using System.Data;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using Janus.Windows.GridEX.EditControls;
using CS2010.Common;

namespace CS2010.CommonWinCtrls
{
	/// <summary>AAL version of the Janus CheckedComboBox</summary>
	[ToolboxItem(true)]
	[DesignTimeVisible(true)]
	[ToolboxBitmap(typeof(CheckedComboBox))]
	public partial class ucCheckedComboBox : CheckedComboBox, IComboBox
	{
		#region Fields

		protected CharacterCasing Case;
		protected Boolean ChangeColorOnEnter;

		protected Color ResetColor;
		protected Color EnterBackGroundColor;
		protected Color DisableBackGroundColor;
		protected Color ReadOnlyBackGroundColor;

		private bool ChangingTab;

		protected ucLabel lblText;
		protected ucLinkLabel lnkText;

		#endregion		// #region Fields

		#region Properties

		protected Orientation _LabelAlignment;
		/// <summary>Gets/Sets the alignment of the label relative to the
		/// textbox (to its left, above it, or to its right).</summary>
		[DefaultValue(typeof(Orientation), "Left")]
		[Description("Used to specify where to align the label. " +
			"Ignored if LabelType set to none.")]
		public Orientation LabelAlignment
		{
			get { return _LabelAlignment; }
			set
			{
				if( _LabelAlignment == value ) return;
				_LabelAlignment = value;
				AdjustLabel();
			}
		}

		protected string _LabelText;
		/// <summary>Gets/Sets the text for the label (ignored if LabelType
		/// is set to None).</summary>
		[DefaultValue(ucLabel.DefaultText)]
		[Description("Label for the text box when LabelType is set to " +
			"Label or Link. Ignored if LabelType set to none.")]
		public string LabelText
		{
			get { return _LabelText; }
			set
			{
				_LabelText = value;
				if( lblText != null )
					lblText.Text = value;
				else if( lnkText != null )
					lnkText.Text = value;
				AdjustLabel();
			}
		}

		protected TextLabelType _LabelType;
		/// <summary>Gets/Sets the type of label to display (None: no label is
		/// displayed, Label: uses a regular ucLabel, Link: uses a ucLinkLabel).
		/// When set to Link, the LinkClicked event is raised when the link is
		/// clicked.</summary>
		[DefaultValue(typeof(TextLabelType), "None")]
		[Description("Type of label to associate with the text box")]
		public TextLabelType LabelType
		{
			get { return _LabelType; }
			set
			{
				if( _LabelType == value ) return;
				_LabelType = value;
				AdjustLabel();
			}
		}

		protected Color _LabelColor;
		/// <summary>Gets/Sets the color of the label (if any) associated with the control
		/// (only applies to type Label, it is ignored for type Link)</summary>
		[DefaultValue(typeof(Color), "ControlText")]
		[Description("Color of the text label associated with the control (only applies to Label)")]
		public Color LabelColor
		{
			get { return _LabelColor; }
			set
			{
				_LabelColor = value;
				if (lblText != null)
					lblText.ForeColor = value;
				AdjustLabel();
			}
		}

		protected Color _LabelBackColor;
		/// <summary>Gets/Sets the background color of the label (if any) associated with the control
		/// (only applies to type Label, it is ignored for type Link)</summary>
		[DefaultValue(typeof(Color), "Control")]
		[Description("Gets/Sets the background color of the label associated with the control (only applies to Label)")]
		public Color LabelBackColor
		{
			get { return _LabelBackColor; }
			set
			{
				_LabelBackColor = value;
				if (lblText != null)
					lblText.BackColor = value;
				AdjustLabel();
			}
		}

		[Description("Occurs when the link label is clicked")]
		public event LinkLabelLinkClickedEventHandler LinkClicked;

		/// <summary>Returns all selected values in a comma-delimited string,
		/// assuming the ValueColumn is of type string
		/// (i.e. ClsCarrier.Carrier_Cd)</summary>
		[Browsable(false)]
		public string SelectedValueString
		{
			get
			{
				if( CheckedValues == null ||
					( View != null && View.Count == CheckedValues.Length && View.Count > 15 ) )
					return null;

				StringBuilder sb = new StringBuilder();
				for( int i = 0; i < CheckedValues.Length; i++ )
					if( CheckedValues[i] != null )
						sb.AppendFormat("{0}'{1}'",
							( sb.Length > 0 ? ", " : null ), CheckedValues[i]);

				return ( sb.Length > 0 ) ? sb.ToString() : null;
			}
		}
		#endregion		// #region Properties

		#region Constructors

		public ucCheckedComboBox()
		{
			InitializeComponent();

			SetDefaults();

			ChangingTab = false;

			_LabelType = TextLabelType.None;
			_LabelAlignment = Orientation.Left;
			_LabelText = ucLabel.DefaultText;
			_LabelColor = SystemColors.ControlText;
			_LabelBackColor = SystemColors.Control;

			InitInterfaceItems();
		}
		#endregion		// #region Constructors

		#region Overrides

		protected override void OnEnter(EventArgs e)
		{
			base.OnEnter(e);
			if( ChangeColorOnEnter == true ) base.BackColor = EnterBackGroundColor;
		}

		protected override void OnLeave(EventArgs e)
		{
			base.OnLeave(e);
			if( ChangeColorOnEnter == true ) base.BackColor = ResetColor;
			if( ReadOnly == true ) base.BackColor = ReadOnlyBackGroundColor;
			if( Enabled == false ) base.BackColor = DisableBackGroundColor;
		}

		protected override void OnEnabledChanged(EventArgs e)
		{
			base.OnEnabledChanged(e);

			if( Enabled == false )
			{
				base.DisabledBackColor = DisableBackGroundColor;
				base.DisabledForeColor = Color.Black;
				base.ForeColor = Color.Black;
				base.TabStop = false;
			}
			else
			{
				base.BackColor = ResetColor;
				base.TabStop = true;
			}
		}

		protected override void OnReadOnlyChanged(EventArgs e)
		{
			base.OnReadOnlyChanged(e);

			if( ReadOnly == true )
			{
				base.BackColor = ReadOnlyBackGroundColor;
				base.ForeColor = Color.Black;
				base.TabStop = false;
			}
			else
			{
				base.BackColor = ResetColor;
				base.TabStop = true;
			}
		}

		protected override void OnCreateControl()
		{
			base.OnCreateControl();
			AdjustLabel();
		}

		protected override void OnParentChanged(EventArgs e)
		{
			base.OnParentChanged(e);
			if( lblText != null ) lblText.Parent = Parent;
			if( lnkText != null ) lnkText.Parent = Parent;
		}

		protected override void OnMove(EventArgs e)
		{
			base.OnMove(e);
			AdjustLabel();
		}

		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			AdjustLabel();
		}

		protected override void OnTabIndexChanged(EventArgs e)
		{
			if( ChangingTab == true ) return;
			try
			{
				ChangingTab = true;

				base.OnTabIndexChanged(e);
				if( lblText == null && lnkText == null ) return;

				int tindex = ( TabIndex > 0 ) ? TabIndex - 1 : 0;
				if( lblText != null )
					lblText.TabIndex = tindex;
				else
					lnkText.TabIndex = tindex;
			}
			finally
			{
				ChangingTab = false;
			}
		}

		protected override void SetVisibleCore(bool value)
		{
			base.SetVisibleCore(value);
			if( lblText != null ) lblText.Visible = Visible;
			if( lnkText != null ) lnkText.Visible = Visible;
		}
		#endregion		// #region Overrides

		#region Private Methods

		private void SetDefaults()
		{
			ResetColor = base.BackColor;
			ChangeColorOnEnter = ClsControlConfig.ChangeColorOnEnter;
			base.CharacterCasing = ClsControlConfig.Case;
			ReadOnlyBackGroundColor = ClsControlConfig.ReadOnlyBackGroundColor;
			EnterBackGroundColor = ClsControlConfig.EnterBackGroundColor;
			DisableBackGroundColor = ClsControlConfig.DisableBackGroundColor;
		}

		private void AdjustLabel()
		{
			Control c = null;
			switch( LabelType )
			{
				case TextLabelType.None:
					if( lnkText != null ) lnkText.Dispose();
					if( lblText != null ) lblText.Dispose();
					lnkText = null;
					lblText = null;
					return;

				case TextLabelType.Label:
					if( lnkText != null ) lnkText.Dispose();
					lnkText = null;

					if( lblText == null )
					{
						lblText = new ucLabel();
						lblText.Parent = Parent;
						lblText.Text = LabelText;
						lblText.UseMnemonic = true;
						lblText.TabIndex = ( TabIndex > 0 ) ? TabIndex - 1 : 0;
						lblText.ForeColor = _LabelColor;
						lblText.BackColor = _LabelBackColor;
					}
					c = lblText;
					break;

				case TextLabelType.Link:
					if( lblText != null ) lblText.Dispose();
					lblText = null;

					if( lnkText == null )
					{
						lnkText = new ucLinkLabel();
						lnkText.Parent = Parent;
						lnkText.Text = LabelText;
						lnkText.UseMnemonic = true;
						lnkText.LinkClicked +=
							new LinkLabelLinkClickedEventHandler
							(lnkText_LinkClicked);
						lnkText.TabIndex = ( TabIndex > 0 ) ? TabIndex - 1 : 0;
					}
					c = lnkText;
					break;

				default: break;
			}
			if( c == null ) return;

			c.Visible = true;
			switch( LabelAlignment )
			{
				case Orientation.Left:
					c.Top = Top + ( Height - c.Height ) / 2;
					c.Left = Left - ( c.Width + 2 );
					break;

				case Orientation.Top:
					c.Top = Top - ( c.Height + 2 );
					c.Left = Left;
					break;

				case Orientation.Right:
					c.Top = Top + ( Height - c.Height ) / 2;
					c.Left = Left + Width + 2;
					break;

				default: break;
			}
		}
		#endregion

		#region Public Methods

		public void AddRow(string displayText, object rowValue)
		{
			DataTable dt = ValuesDataSource as DataTable;
			if( dt == null ) return;

			DataRow dr = dt.NewRow();
			dr[DropDownDisplayMember] = displayText;
			dr[DropDownValueMember] = rowValue;
			dt.Rows.Add(dr);
		}
		#endregion		// #region Public Methods

		#region Event Handlers

		void lnkText_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if( LinkClicked != null ) LinkClicked(sender, e);
		}
		#endregion		// #region Event Handlers

		#region IComboBox Interface Implementation

		#region Fields

		protected bool _ShowInactive;			// ShowInactive
		/// <summary>This filter will be appended to any filter and is related
		/// to the ShowInactive property (see SetInactiveFilter())</summary>
		protected string _InactiveFilter;

		protected DataView _View;				// View property
		protected DataTable _Table;				// Table property

		protected bool _ShowContextMenu;		// ShowContextMenu

		protected string _Filter;				// Filter property
		protected string _CodeColumn;			// CodeColumn property
		protected string _ValueColumn;			// ValueColumn property
		protected string _DescriptionColumn;	// DescriptionColumn property

		protected ComboSortType _SortType;		// SortType property
		protected ComboDisplay _DisplayType;	// DisplayType property
		protected ComboMenuHelper _MenuHelper;	// MenuHelper property

		#endregion		// #region Fields

		#region Properties

		/// <summary>Occurs when the Filter property changes</summary>
		[Description("Occurs when the Filter property changes")]
		public event EventHandler FilterChanged;
		/// <summary>Occurs when the DisplayType property changes</summary>
		[Description("Occurs when the DisplayType property changes")]
		public event EventHandler DisplayTypeChanged;
		/// <summary>Occurs when one of the "Column" properties (CodeColumn,
		/// ValueColumn, DescriptionColumn) changes</summary>
		[Description("Occurs when one of the 'Column' properties (CodeColumn, " +
		"ValueColumn, DescriptionColumn) changes")]
		public event ColumnNameChangedEventHandler ColumnNameChanged;

		/// <summary>Gets/sets whether inactive items will be displayed in the combo box
		/// (inactive items have either DELETED_FLG = Y or ACTIVE_FLG = N)</summary>
		[Browsable(true), DefaultValue(false),
		Description("Gets/sets whether inactive items will be displayed in the combo box" +
		   "(inactive items have either DELETED_FLG = Y or ACTIVE_FLG = N)")]
		public bool ShowInactive
		{
			get { return _ShowInactive; }
			set
			{
				if( value == _ShowInactive ) return;

				_ShowInactive = value;

				SetFilter();
			}
		}

		/// <summary>Gets/sets whether the context menu that controls the combo
		/// display is displayed or not</summary>
		[Browsable(true), DefaultValue(true),
		Description("Gets/sets whether the context menu that controls the combo " +
			"display is shown or not")]
		public bool ShowContextMenu
		{
			get { return _ShowContextMenu; }
			set
			{
				if( value == _ShowContextMenu ) return;

				_ShowContextMenu = value;

				HandleContextMenu();
			}
		}

		/// <summary>Gets/Sets the expression used to filter the items shown
		/// in the combo box (it is applied to the DataView's RowFilter)</summary>
		[Browsable(true), DefaultValue(""),
		Description("Gets/Sets the expression used to filter the data table")]
		public string Filter
		{
			get { return _Filter; }
			set
			{
				if( value == _Filter ) return;

				_Filter = value;

				SetFilter();

				OnFilterChanged();
			}
		}

		/// <summary>Gets/Sets the DataTable used to fill the combo box (the
		/// combo box data source will be a DataView created from this DataTable,
		/// it will not use the DataTable directly</summary>
		[Browsable(false), DefaultValue(null),
		Description("Gets/Sets the data table used to fill the combo box")]
		public DataTable Table
		{
			get { return _Table; }
			set
			{
				if( value == _Table ) return;

				_Table = value;
				if( _Table == null )
				{
					if( _View != null )
					{
						_View.Dispose();
						_View = null;
						base.DropDownDataSource = null;
					}
				}
				else
				{
					_View = new DataView(_Table);
					SortChanged();
					SetFilter();
					base.DropDownDataSource = _View;
				}
			}
		}

		/// <summary>Gets the view that is used as the data source (it is a
		/// DataView created from the Table (DataTable) property)</summary>
		[Browsable(false)]
		public DataView View
		{
			get { return _View; }
		}

		/// <summary>Gets/Sets the name of the Table's code column</summary>
		[Browsable(true), DefaultValue(""),
		Description("Gets/Sets the name of the data table's code column")]
		public string CodeColumn
		{
			get { return _CodeColumn; }
			set
			{
				if( string.Compare(value, _CodeColumn, true) == 0 ) return;

				string hold = _CodeColumn;
				_CodeColumn = value;

				DispayChanged();

				OnColumnNameChanged("Code", hold, _CodeColumn);
			}
		}

		/// <summary>Gets/Sets the name of the Table's primary key column</summary>
		[Browsable(true), DefaultValue(""),
		Description("Gets/Sets the name of the data table's primary key column")]
		public string ValueColumn
		{
			get { return _ValueColumn; }
			set
			{
				if( string.Compare(value, _ValueColumn, true) == 0 ) return;

				string hold = _ValueColumn;
				_ValueColumn = value;

				DispayChanged();

				OnColumnNameChanged("Value", hold, _ValueColumn);
			}
		}

		/// <summary>Gets/Sets the name of the Table's description column</summary>
		[Browsable(true), DefaultValue(""),
		Description("Gets/Sets the name of the data table's description column")]
		public string DescriptionColumn
		{
			get { return _DescriptionColumn; }
			set
			{
				if( string.Compare(value, _DescriptionColumn, true) == 0 ) return;

				string hold = _DescriptionColumn;
				_DescriptionColumn = value;

				DispayChanged();

				OnColumnNameChanged("Description", hold, _DescriptionColumn);
			}
		}

		/// <summary>Gets/Sets the type displayed in the text area (see the
		/// ComboDisplay enum for more information)</summary>
		[Browsable(true), DefaultValue(typeof(ComboDisplay), "CodeOnly"),
		Description("Gets/Sets the type displayed in the text area")]
		public ComboDisplay DisplayType
		{
			get { return _DisplayType; }
			set
			{
				if( value == _DisplayType ) return;

				_DisplayType = value;

				DispayChanged();
				if( MenuHelper != null ) MenuHelper.SetMenuItem(_DisplayType);

				OnDisplayTypeChanged();
			}
		}

		/// <summary>Gets/Sets the column that the data should be sorted on (see
		/// the ComboSortType enum for more information)</summary>
		[Browsable(true), DefaultValue(typeof(ComboSortType), "Code"),
		Description("Gets/Sets the column that the data should be sorted on")]
		public ComboSortType SortType
		{
			get { return _SortType; }
			set
			{
				if( value == _SortType ) return;

				_SortType = value;

				SortChanged();
			}
		}

		/// <summary>Context Menu helper class (can be used to perform
		/// cut, copy, paste, etc.)</summary>
		[Browsable(false)]
		public ComboMenuHelper MenuHelper
		{
			get { return _MenuHelper; }
		}

		/// <summary>The name of the column used as the display (it depends on
		/// the vale of the DisplayType property)</summary>
		[Browsable(false)]
		public string DisplayMemberName
		{
			get
			{
				switch( _DisplayType )
				{
					case ComboDisplay.DescriptionOnly: return DescriptionColumn;

					case ComboDisplay.CodePlusDescription:
						return CodeColumn + DescriptionColumn;

					case ComboDisplay.DescriptionPlusCode:
						return DescriptionColumn + CodeColumn;

					case ComboDisplay.CodeOnly:
					default: return CodeColumn;
				}
			}
		}

		/// <summary>The name of the column used as the Value member</summary>
		[Browsable(false)]
		public string ValueMemberName
		{
			get { return ValueColumn; }
		}

		/// <summary>Gets/Sets the base.DropDownDataSource property. The
		/// recommended practice is to use the Table property to set the data
		/// source unless the data source is not a DataTable or DataView. This is
		/// needed so we can update the Table property if the data source is
		/// set through this property.</summary>
		[Browsable(false)]
		public new object DropDownDataSource
		{
			get
			{
				return base.DropDownDataSource;
			}
			set
			{
				SetDataSource(value);
			}
		}
		#endregion		// #region Properties

		#region Helper Methods

		/// <summary>Initialize items related to the IComboBox interface</summary>
		protected void InitInterfaceItems()
		{
			_View = null;
			_Table = null;
			_Filter = string.Empty;
			_InactiveFilter = null;
			_CodeColumn = string.Empty;
			_ValueColumn = string.Empty;
			_DescriptionColumn = string.Empty;
			_DisplayType = ComboDisplay.CodeOnly;
			_SortType = ComboSortType.Code;

			_ShowContextMenu = true;
			_MenuHelper = new ComboMenuHelper(this);
			ContextMenuStrip = _MenuHelper.MenuStrip;
		}

		protected virtual void SetDataSource(object aValue)
		{
			DataTable dt = aValue as DataTable;
			if( dt != null )
				Table = dt;
			else
			{
				DataView dv = aValue as DataView;
				if( dv != null )
					Table = dv.Table;
				else
					base.DropDownDataSource = aValue;
			}
		}

		protected void HandleContextMenu()
		{
			ContextMenuStrip = ( _ShowContextMenu == true )
				? _MenuHelper.MenuStrip : null;
		}

		protected void DispayChanged()
		{
			DropDownValueMember = ValueMemberName;
			DropDownDisplayMember = DisplayMemberName;

			object[] hold = CheckedItems;
			CheckedItems = null;
			CheckedItems = hold;
		}

		protected void SortChanged()
		{
			if( _View == null ) return;

			string sortColumn;
			switch( _SortType )
			{
				case ComboSortType.Description:
					sortColumn = DescriptionColumn;
					break;
				case ComboSortType.Value:
					sortColumn = ValueColumn;
					break;

				case ComboSortType.Code:
					sortColumn = CodeColumn;
					break;

				case ComboSortType.None:
				default:
					sortColumn = null;
					break;
			}
			if( string.IsNullOrEmpty(sortColumn) == false )
				_View.Sort = string.Format("{0} ASC", sortColumn);
		}

		protected void SetInactiveFilter()
		{
			if( _View == null ) return;

			_InactiveFilter = null;		// Set to no filter
			if( _ShowInactive == false )	// If not showing inactive, we have to filter
			{								// based on the active or delete column
				string colName = null, activeValue = null;
				if( View.Table.Columns.Contains("ACTIVE_FLG") )
				{
					colName = "ACTIVE_FLG";
					activeValue = "Y";
				}
				else if( View.Table.Columns.Contains("DELETED_FLG") )
				{
					colName = "DELETED_FLG";
					activeValue = "N";
				}

				// if we have either the active or delete column, create the filter
				if( string.IsNullOrEmpty(colName) == false )
					_InactiveFilter = string.Format("{0} = '{1}'", colName, activeValue);
			}
		}

		protected void SetFilter()
		{
			if( _View == null ) return;

			SetInactiveFilter();
			_View.RowFilter = ( string.IsNullOrEmpty(_Filter) == false )
				? string.Format("{0} {1}", _Filter,
				string.IsNullOrEmpty(_InactiveFilter) ? null : " AND " + _InactiveFilter)
				: _InactiveFilter;
		}

		protected virtual void OnFilterChanged()
		{
			if( FilterChanged != null ) FilterChanged(this, EventArgs.Empty);
		}

		protected virtual void OnDisplayTypeChanged()
		{
			if( DisplayTypeChanged != null )
				DisplayTypeChanged(this, EventArgs.Empty);
		}

		protected virtual void OnColumnNameChanged
			(string colName, string oldVal, string newVal)
		{
			if( ColumnNameChanged != null )
				ColumnNameChanged(this,
					new ColumnNameChangedEventArgs(colName, oldVal, newVal));
		}
		#endregion		// #region Helper Methods

		#endregion		// #region IComboBox Interface Implementation
	}
}