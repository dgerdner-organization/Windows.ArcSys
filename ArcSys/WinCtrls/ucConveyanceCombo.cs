using System;
using System.Data;
using System.Windows.Forms;
using System.ComponentModel;
using CS2010.Common;
using CS2010.CommonWinCtrls;
using CS2010.ArcSys.Business;
using Janus.Windows.GridEX;

namespace CS2010.ArcSys.WinCtrls
{
	/// <summary>ArcSys version of ucMultiColumnCombo for conveyances</summary>
	public partial class ucConveyanceCombo : ucMultiColumnCombo
	{
		#region Properties

		public bool _DisplayFutile;
		/// <summary>Gets the selected ClsConveyance object</summary>
		[Browsable(true), DefaultValue(false),
		Description("Gets/Sets whether we will show futile conveyances in the dropdown")]
		public bool DisplayFutile
		{
			get { return _DisplayFutile; }
			set { _DisplayFutile = value; }
		}

		public bool _ValidateConveyanceExists;
		/// <summary>Gets/Sets whether we should validate that the conveyance exists in the dropdown before exiting the field</summary>
		[Browsable(true), DefaultValue(false),
		Description("Gets/Sets whether we should validate that the conveyance exists in the dropdown before exiting the field")]
		public bool ValidateConveyanceExists
		{
			get { return _ValidateConveyanceExists; }
			set { _ValidateConveyanceExists = value; }
		}

		/// <summary>Gets the selected ClsConveyance object</summary>
		[Browsable(false)]
		public ClsConveyance SelectedConveyance
		{
			get
			{
				DataRowView drv = SelectedItem as DataRowView;
				return (drv != null) ? new ClsConveyance(drv.Row) : null;
			}
		}

		/// <summary>Gets the selected conveyance ID</summary>
		[Browsable(false)]
		public long? SelectedConveyanceID
		{
			get
			{
				ClsConveyance item = SelectedConveyance;
				return (item != null) ? item.Conveyance_ID : null;
			}
		}

		/// <summary>Gets the selected conveyance number</summary>
		[Browsable(false)]
		public string SelectedConveyanceNo
		{
			get
			{
				ClsConveyance item = SelectedConveyance;
				return (item != null) ? item.Conveyance_No : null;
			}
		}

		private long? _Vendor_Move_ID;
		/// <summary>Gets/Sets the vendor move ID for which to display conveyances</summary>
		[Browsable(false)]
		public long? Vendor_Move_ID
		{
			get
			{
				return _Vendor_Move_ID;
			}
			set
			{
				if (_Vendor_Move_ID == value) return;

				_Vendor_Move_ID = value;
				Reset();
			}
		}
		#endregion		// #region Properties

		#region Constructors

		/// <summary>Default Constructor</summary>
		public ucConveyanceCombo()
		{
			InitializeComponent();

			_Vendor_Move_ID = null;
			_ValidateConveyanceExists = false;

			SetTableSource();

			CreateStructure();
		}
		#endregion		// #region Constructors

		#region Public Methods

		public void Reset()
		{
			if( ClsEnvironment.IsDesignMode == true ) return;

			SetTableSource();
		}
		#endregion		// #region Public Methods

		#region Helper Methods

		private void CreateStructure()
		{
			GridEXColumn c = null;
			
			c = DropDownList.Columns.Add("Conveyance_No");
			c.DataMember = "Conveyance_No";
			c.Caption = "BOL/Job #";
			c.Width = 150;

			c = DropDownList.Columns.Add("Partner_Dsc");
			c.DataMember = "Partner_Dsc";
			c.Caption = "Customer";
			c.Width = 120;

			c = DropDownList.Columns.Add("Truck_No");
			c.DataMember = "Truck_No";
			c.Caption = "Truck #";
			c.Width = 90;

			c = DropDownList.Columns.Add("Move_Dsc");
			c.DataMember = "Move_Dsc";
			c.Caption = "Move Desc";
			c.Width = 125;

			c = DropDownList.Columns.Add("Orig_Location_Dsc");
			c.DataMember = "Orig_Location_Dsc";
			c.Caption = "Origin";
			c.Width = 150;

			c = DropDownList.Columns.Add("Dest_Location_Dsc");
			c.DataMember = "Dest_Location_Dsc";
			c.Caption = "Destination";
			c.Width = 150;

			c = DropDownList.Columns.Add("Conveyance_Type_Cd");
			c.DataMember = "Conveyance_Type_Cd";
			c.Caption = "Type";
			c.Width = 60;
			c.Visible = false;

			c = DropDownList.Columns.Add("Futile_Flg");
			c.DataMember = "Futile_Flg";
			c.Caption = "Futile";
			c.Width = 50;
			c.HeaderAlignment = TextAlignment.Center;
			c.ColumnType = ColumnType.CheckBox;
			c.EditType = EditType.CheckBox;
			c.CheckBoxTrueValue = "Y";
			c.CheckBoxFalseValue = "N";
			c.Width = 60;

			c = DropDownList.Columns.Add("Conveyance_ID");
			c.DataMember = "Conveyance_ID";
			c.Caption = "ID";
			c.Visible = false;

			c = DropDownList.Columns.Add("Driver");
			c.DataMember = "Driver";
			c.Caption = "Driver";
			c.Width = 120;

			DropDownList.VisibleRows = 20;
			// Set in designer
			//SortType = ComboSortType.Description;
			//DisplayType = ComboDisplay.DescriptionOnly;
		}

		private void SetTableSource()
		{
			if( ClsEnvironment.IsDesignMode == true ) return;

			DataTable dt = null;
			if (Vendor_Move_ID != null)
			{
				string futileFlg = (DisplayFutile) ? null : "N";
				dt = ClsConveyance.GetVendorMoveConveyances(Vendor_Move_ID.Value, futileFlg);
				if (dt != null) ClsConnection.AddColumns(dt, "CONVEYANCE_ID", "CONVEYANCE_NO");
			}

			if (Table != null)
			{
				Table.Dispose();
				Table = null;
			}

			Table = dt;
		}
		#endregion		// #region Helper Methods

		#region Overrides

		protected override void SetDataSource(object aValue)
		{
			// JR: We keep track of the data source internally,
			// so do not allow it to be overwritten
		}

		protected override void OnValidating(CancelEventArgs e)
		{
			try
			{
				if (ValidateConveyanceExists)
				{
					if (NotInList == true)
					{
						e.Cancel = true;
						Display.ShowError("ArcSys", "Specified conveyance is not in the list");
					}
					else if (DroppedDown == true)
						e.Cancel = true;
				}
			}
			catch (Exception ex)
			{
				Display.ShowError("ArcSys", ex);
			}
			base.OnValidating(e);
		}
		#endregion		// #region Overrides
	}
}