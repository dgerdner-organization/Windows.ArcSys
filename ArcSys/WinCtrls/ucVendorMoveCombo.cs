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
	/// <summary>ArcSys version of ucMultiColumnCombo for vendor moves</summary>
	public partial class ucVendorMoveCombo : ucMultiColumnCombo
	{
		#region Properties

		/// <summary>Gets the selected ClsVendorMove object</summary>
		[Browsable(false)]
		public ClsVendorMove SelectedVendorMove
		{
			get
			{
				DataRowView drv = SelectedItem as DataRowView;
				return (drv != null) ? new ClsVendorMove(drv.Row) : null;
			}
		}

		/// <summary>Gets the selected Vendor Move ID</summary>
		[Browsable(false)]
		public long? SelectedVendorMoveID
		{
			get
			{
				ClsVendorMove item = SelectedVendorMove;
				return (item != null) ? item.Vendor_Move_ID : null;
			}
		}

		private string _Vendor_Cd;
		/// <summary>Gets/Sets the vendor code for which to display vendor moves</summary>
		[Browsable(false)]
		public string Vendor_Cd
		{
			get
			{
				return _Vendor_Cd;
			}
			set
			{
				if (string.Compare(_Vendor_Cd, value, false) == 0) return;

				_Vendor_Cd = value;
				Reset();
			}
		}
		#endregion		// #region Properties

		#region Constructors

		/// <summary>Default Constructor</summary>
		public ucVendorMoveCombo()
		{
			InitializeComponent();

			_Vendor_Cd = null;

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
			
			c = DropDownList.Columns.Add("Partner_Dsc");
			c.DataMember = "Partner_Dsc";
			c.Caption = "Customer";
			c.Width = 150;

			c = DropDownList.Columns.Add("Move_Dsc");
			c.DataMember = "Move_Dsc";
			c.Caption = "Move Desc";
			c.Width = 150;

			c = DropDownList.Columns.Add("Orig_Location_Dsc");
			c.DataMember = "Orig_Location_Dsc";
			c.Caption = "Origin";
			c.Width = 170;

			c = DropDownList.Columns.Add("Dest_Location_Dsc");
			c.DataMember = "Dest_Location_Dsc";
			c.Caption = "Destination";
			c.Width = 170;

			c = DropDownList.Columns.Add("Active_Flg");
			c.DataMember = "Active_Flg";
			c.Caption = "Active";
			c.Visible = false;
			c.Width = 50;
			c.HeaderAlignment = TextAlignment.Center;
			c.ColumnType = ColumnType.CheckBox;
			c.EditType = EditType.CheckBox;
			c.CheckBoxTrueValue = "Y";
			c.CheckBoxFalseValue = "N";

			c = DropDownList.Columns.Add("Vendor_Move_ID");
			c.DataMember = "Vendor_Move_ID";
			c.Caption = "Vendor Mv ID";

			DropDownList.VisibleRows = 20;
		}

		private void SetTableSource()
		{
			if( ClsEnvironment.IsDesignMode == true ) return;

			DataTable dt = null;
			if (!string.IsNullOrWhiteSpace(_Vendor_Cd))
			{
				dt = ClsVendorMove.GetVendorMoves(_Vendor_Cd);
				if (dt != null) ClsConnection.AddColumns(dt, "VENDOR_MOVE_ID", "EXTRA_DSC");
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
				if (NotInList == true)
				{
					e.Cancel = true;
					Display.ShowError("ArcSys", "Specified move is not in the list");
				}
				else if (DroppedDown == true)
					e.Cancel = true;
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