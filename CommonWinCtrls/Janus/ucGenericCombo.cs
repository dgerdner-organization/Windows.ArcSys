using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;
using Janus.Windows.GridEX;
using CS2010.Common;

namespace CS2010.CommonWinCtrls
{
	/// <summary>AAL version of the Janus MultiColumnCombo used when a combo
	/// box is needed that is not bound to a database table. Instead it is bound
	/// to a List of ComboItem objects. The type of item is specified through
	/// the ComboType property.</summary>
	public partial class ucGenericCombo : ucMultiColumnCombo
	{
		#region Fields

		protected ComboItem[] _Data;
		protected GenericComboType _ComboType;

		#endregion		// #region Fields

		private ComboDisplay _DropDownDisplay;

		[Browsable(true),
		DefaultValue(typeof(ComboDisplay), "CodePlusDescription"),
		Description("Gets/sets what is shown in the drop down area of the combo")]
		public ComboDisplay DropDownDisplay
		{
			get { return _DropDownDisplay; }
			set
			{
				if( value == _DropDownDisplay ) return;

				_DropDownDisplay = value;
				CreateStructure();
			}
		}
	
		#region Properties

		/// <summary>Gets/Sets the type of combo box (see the GenericComboType
		/// enum for more information)</summary>
		[Browsable(true),
		DefaultValue(typeof(GenericComboType), "ActiveInactive"),
		Description("Gets/Sets the type of items in the generic combo box")]
		public GenericComboType ComboType
		{
			get { return _ComboType; }
			set
			{
				if( value == _ComboType ) return;

				_ComboType = value;
				SetTable(_ComboType);
			}
		}

		/// <summary>Gets the selected ComboItem object</summary>
		[Browsable(false)]
		public ComboItem SelectedComboItem
		{
			get
			{
				return SelectedItem as ComboItem;
			}
		}

		/// <summary>Gets the selected code</summary>
		[Browsable(false)]
		public string SelectedCD
		{
			get
			{
				ComboItem item = SelectedComboItem;
				return ( item != null ) ? item.Code : null;
			}
		}

		/// <summary>Gets the selected description</summary>
		[Browsable(false)]
		public string SelectedDsc
		{
			get
			{
				ComboItem item = SelectedComboItem;
				return ( item != null ) ? item.Description : null;
			}
		}
		#endregion		// #region Properties

		#region Constructors

		public ucGenericCombo()
		{
			InitializeComponent();

			_ComboType = GenericComboType.ActiveInactive;
			SetTable(_ComboType);

			_DropDownDisplay = ComboDisplay.CodePlusDescription;

			CreateStructure();
		}
		#endregion		// #region Constructors

		#region Helper Methods

		private void CreateStructure()
		{
			DropDownList.Columns.Clear();

			if( DropDownDisplay != ComboDisplay.DescriptionOnly )
			{
				GridEXColumn c = DropDownList.Columns.Add("Code");
				c.DataMember = "Code";
				c.Caption = "Code";
				c.Width = 50;
			}

			if( DropDownDisplay != ComboDisplay.CodeOnly )
			{
				GridEXColumn c = new GridEXColumn("Description");
				c.DataMember = "Description";
				c.Caption = "Description";
				c.Width = 200;

				if( DropDownDisplay == ComboDisplay.DescriptionPlusCode )
					DropDownList.Columns.Insert(0, c);
				else
					DropDownList.Columns.Add(c);
			}

			DropDownList.VisibleRows = 20;
		}

		protected void SetTable(GenericComboType type)
		{
			if( ClsEnvironment.IsDesignMode == true ) return;

			Text = null;
			base.DataSource = null;
			switch( type )
			{
				case GenericComboType.SysUser:
					_Data = new ComboItem[2];
					_Data[0] = new ComboItem("S", "SYSTEM");
					_Data[1] = new ComboItem("U", "USER");
					break;

				case GenericComboType.RoroContainer:
					_Data = new ComboItem[2];
					_Data[0] = new ComboItem("RORO", "RORO");
					_Data[1] = new ComboItem("CONT", "CONTAINER");
					break;

				case GenericComboType.EmptyFull:
					_Data = new ComboItem[2];
					_Data[0] = new ComboItem("E", "EMPTY");
					_Data[1] = new ComboItem("F", "FULL");
					break;

				case GenericComboType.YesNo:
					_Data = new ComboItem[2];
					_Data[0] = new ComboItem("Y", "YES");
					_Data[1] = new ComboItem("N", "NO");
					break;

				case GenericComboType.Month:
					_Data = new ComboItem[12];
					_Data[0] = new ComboItem("01", "January");
					_Data[1] = new ComboItem("02", "February");
					_Data[2] = new ComboItem("03", "March");
					_Data[3] = new ComboItem("04", "April");
					_Data[4] = new ComboItem("05", "May");
					_Data[5] = new ComboItem("06", "June");
					_Data[6] = new ComboItem("07", "July");
					_Data[7] = new ComboItem("08", "August");
					_Data[8] = new ComboItem("09", "September");
					_Data[9] = new ComboItem("10", "October");
					_Data[10] = new ComboItem("11", "November");
					_Data[11] = new ComboItem("12", "December");
					break;

				case GenericComboType.Year:
					_Data = new ComboItem[10];
					_Data[0] = new ComboItem("2006", "2006");
					_Data[1] = new ComboItem("2007", "2007");
					_Data[2] = new ComboItem("2008", "2008");
					_Data[3] = new ComboItem("2009", "2009");
					_Data[4] = new ComboItem("2010", "2010");
					_Data[5] = new ComboItem("2011", "2011");
					_Data[6] = new ComboItem("2012", "2012");
					_Data[7] = new ComboItem("2013", "2013");
					_Data[8] = new ComboItem("2014", "2014");
					_Data[9] = new ComboItem("2015", "2015");
					break;

				case GenericComboType.EastWest:
					_Data = new ComboItem[2];
					_Data[0] = new ComboItem("E", "EAST");
					_Data[1] = new ComboItem("W", "WEST");
					break;

				case GenericComboType.DrayageTerms:
					_Data = new ComboItem[2];
					_Data[0] = new ComboItem("K", "Carrier Not Responsible");
					_Data[1] = new ComboItem("L", "Carrier Responsible");
					break;

				case GenericComboType.ActiveInactive:
				default:
					_Data = new ComboItem[2];
					_Data[0] = new ComboItem("A", "ACTIVE");
					_Data[1] = new ComboItem("I", "INACTIVE");
					break;
			}
			base.DataSource = _Data;
		}
		#endregion		// #region Helper Methods

		#region Overrides

		protected override void OnValidating(CancelEventArgs e)
		{
			try
			{
				if( NotInList == true )
				{
					e.Cancel = true;
					Display.ShowError("Error", "Specified item is not in the list");
				}
				else if( DroppedDown == true )
					e.Cancel = true;
			}
			catch( Exception ex )
			{
				Display.ShowError("Error", ex);
			}
			base.OnValidating(e);
		}
		#endregion		// #region Overrides
	}

	#region GenericComboType enum

	/// <summary>The type of list used to fill a GenericCombo</summary>
	public enum GenericComboType
	{
		/// <summary>A list with two ComboItem objects: A (Active) and
		/// I (Inactive)</summary>
		ActiveInactive,
		/// <summary>A list with two ComboItem objects: E (Empty) and
		/// F (Full)</summary>
		EmptyFull,
		/// <summary>A list with two ComboItem objects: Y (Yes) and
		/// N (No)</summary>
		YesNo,
		/// <summary>A list with two ComboItem objects: RORO and
		/// CONT (Container)</summary>
		RoroContainer,
		/// <summary>Drayage Terms: A list with two ComboItem objects: K (ocean carrier
		/// is not responsible for the dray), L (ocean carrier is responsible)</summary>
		DrayageTerms,
		/// <summary>A list with two ComboItem objects: U (User) and
		/// S (System)</summary>
		SysUser,
		Month,
		Year,
		EastWest
	}
	#endregion		// #region GenericComboType enum
}