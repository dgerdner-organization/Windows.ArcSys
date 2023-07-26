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
	/// <summary>ArcSys version of ucMultiColumnCombo for unit type codes</summary>
	public partial class ucUnitTypeCombo : ucMultiColumnCombo
	{
		#region Properties

		/// <summary>Gets the selected ClsUnitType object</summary>
		[Browsable(false)]
		public ClsUnitType SelectedUnitType
		{
			get
			{
				DataRowView drv = SelectedItem as DataRowView;
				return (drv != null) ? new ClsUnitType(drv.Row) : null;
			}
		}

		/// <summary>Gets the selected unit type code</summary>
		[Browsable(false)]
		public string SelectedUnitTypeCD
		{
			get
			{
				ClsUnitType item = SelectedUnitType;
				return (item != null) ? item.Unit_Type_Cd : null;
			}
		}

		/// <summary>Gets the selected unit type description</summary>
		[Browsable(false)]
		public string SelectedDsc
		{
			get
			{
				ClsUnitType item = SelectedUnitType;
				return (item != null) ? item.Unit_Type_Dsc : null;
			}
		}
		#endregion		// #region Properties

		#region Constructors

		/// <summary>Default Constructor</summary>
		public ucUnitTypeCombo()
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
			GridEXColumn c = DropDownList.Columns.Add("Unit_Type_Cd");
			c.DataMember = "Unit_Type_Cd";
			c.Caption = "Unit Type";

			c = DropDownList.Columns.Add("Unit_Type_Dsc");
			c.DataMember = "Unit_Type_Dsc";
			c.Caption = "Description";
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

			DataTable dt = ClsUnitType.GetAll();
			if (dt != null) ClsConnection.AddColumns(dt, "Unit_Type_Cd", "Unit_Type_Dsc");

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
					Display.ShowError("ArcSys", "Specified unit type is not in the list");
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