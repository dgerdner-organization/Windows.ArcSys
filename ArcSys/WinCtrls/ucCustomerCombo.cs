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
	/// <summary>ArcSys version of ucMultiColumnCombo for customers</summary>
	public partial class ucCustomerCombo : ucMultiColumnCombo
	{
		#region Properties

		/// <summary>Gets the selected ClsCustomer object</summary>
		[Browsable(false)]
		public ClsCustomer SelectedCustomer
		{
			get
			{
				DataRowView drv = SelectedItem as DataRowView;
				return (drv != null) ? new ClsCustomer(drv.Row) : null;
			}
		}

		/// <summary>Gets the selected customer code</summary>
		[Browsable(false)]
		public string SelectedCustomerCD
		{
			get
			{
				ClsCustomer item = SelectedCustomer;
				return (item != null) ? item.Customer_Cd : null;
			}
		}

		/// <summary>Gets the selected customer name</summary>
		[Browsable(false)]
		public string SelectedDsc
		{
			get
			{
				ClsCustomer item = SelectedCustomer;
				return (item != null) ? item.Customer_Nm : null;
			}
		}
		#endregion		// #region Properties

		#region Constructors

		/// <summary>Default Constructor</summary>
		public ucCustomerCombo()
		{
			InitializeComponent();

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
			GridEXColumn c = DropDownList.Columns.Add("Customer_Cd");
			c.DataMember = "Customer_Cd";
			c.Caption = "Customer";

			c = DropDownList.Columns.Add("Customer_Nm");
			c.DataMember = "Customer_Nm";
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

			DataTable dt = ClsCustomer.GetAll();
			if (dt != null) ClsConnection.AddColumns(dt, "Customer_Cd", "Customer_Nm");

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
					Display.ShowError("ArcSys", "Specified customer is not in the list");
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