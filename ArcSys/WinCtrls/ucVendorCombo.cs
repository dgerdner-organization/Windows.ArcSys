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
	/// <summary>ArcSys version of ucMultiColumnCombo for vendors</summary>
	public partial class ucVendorCombo : ucMultiColumnCombo
	{
		#region Fields/Properties

		protected bool _DisplayUserVendorsOnly;
		/// <summary>Gets/Sets whether we should only bring back vendors that
		/// the user can see (true) or all vendors (false)</summary>
		[Browsable(true), DefaultValue(false),
		Description("Gets/Sets whether we should only bring back vendors that " +
			"the user can see (true) or all vendors (false)")]
		public bool DisplayUserVendorsOnly
		{
			get { return _DisplayUserVendorsOnly; }
			set
			{
				if (_DisplayUserVendorsOnly == value) return;

				_DisplayUserVendorsOnly = value;
				Reset();
			}
		}

		/// <summary>Gets the selected ClsVendor object</summary>
		[Browsable(false)]
		public ClsVendor SelectedVendor
		{
			get
			{
				DataRowView drv = SelectedItem as DataRowView;
				return (drv != null) ? new ClsVendor(drv.Row) : null;
			}
		}

		/// <summary>Gets the selected vendor code</summary>
		[Browsable(false)]
		public string SelectedVendorCD
		{
			get
			{
				ClsVendor item = SelectedVendor;
				return (item != null) ? item.Vendor_Cd : null;
			}
		}

		/// <summary>Gets the selected vendor name</summary>
		[Browsable(false)]
		public string SelectedDsc
		{
			get
			{
				ClsVendor item = SelectedVendor;
				return (item != null) ? item.Vendor_Nm : null;
			}
		}
		#endregion		// #region Fields/Properties

		#region Constructors

		/// <summary>Default Constructor</summary>
		public ucVendorCombo()
		{
			InitializeComponent();

			_DisplayUserVendorsOnly = false;

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
			GridEXColumn c = DropDownList.Columns.Add("Vendor_Cd");
			c.DataMember = "Vendor_Cd";
			c.Caption = "Vendor";

			c = DropDownList.Columns.Add("Vendor_Nm");
			c.DataMember = "Vendor_Nm";
			c.Caption = "Name";
			c.Width = 250;

			c = DropDownList.Columns.Add("Active_Flg");
			c.DataMember = "Active_Flg";
			c.Caption = "Active";
			c.Visible = false;
			c.Width = 65;
			c.HeaderAlignment = TextAlignment.Center;
			c.ColumnType = ColumnType.CheckBox;
			c.EditType = EditType.CheckBox;
			c.CheckBoxTrueValue = "Y";
			c.CheckBoxFalseValue = "N";

			DropDownList.VisibleRows = 20;
		}

		private void SetTableSource()
		{
			if( ClsEnvironment.IsDesignMode == true ) return;

			DataTable dt = ClsVendor.GetVendors(DisplayUserVendorsOnly);
			if (dt != null) ClsConnection.AddColumns(dt, "Vendor_Cd", "Vendor_Nm");

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
				if( NotInList == true )
				{
					e.Cancel = true;
					Display.ShowError("ArcSys", "Specified vendor is not in the list");
				}
				else if( DroppedDown == true )
					e.Cancel = true;
			}
			catch( Exception ex )
			{
				Display.ShowError("ArcSys", ex);
			}
			base.OnValidating(e);
		}
		#endregion		// #region Overrides
	}
}