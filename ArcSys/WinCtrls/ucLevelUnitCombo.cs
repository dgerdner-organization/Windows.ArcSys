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
	/// <summary>ArcSys version of ucMultiColumnCombo for ClsLevelUnit items</summary>
	public partial class ucLevelUnitCombo : ucMultiColumnCombo
	{
		#region Properties

		/// <summary>Gets the selected ClsLevelUnit object</summary>
		[Browsable(false)]
		public ClsLevelUnit SelectedLevelUnit
		{
			get
			{
				DataRowView drv = SelectedItem as DataRowView;
				return (drv != null) ? new ClsLevelUnit(drv.Row) : null;
			}
		}

		/// <summary>Gets the selected level unit ID</summary>
		[Browsable(false)]
		public long? SelectedLevelUnitID
		{
			get
			{
				ClsLevelUnit item = SelectedLevelUnit;
				return (item != null) ? item.Level_Unit_ID : null;
			}
		}

		/// <summary>Gets the selected level unit description</summary>
		[Browsable(false)]
		public string SelectedDsc
		{
			get
			{
				ClsLevelUnit item = SelectedLevelUnit;
				return (item != null) ? item.Level_Unit_Dsc : null;
			}
		}
		#endregion		// #region Properties

		#region Constructors

		/// <summary>Default Constructor</summary>
		public ucLevelUnitCombo()
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
			GridEXColumn c = DropDownList.Columns.Add("Level_Unit_ID");
			c.DataMember = "Level_Unit_ID";
			c.Caption = "ID";
			c.Visible = false;

			c = DropDownList.Columns.Add("Level_Unit_Dsc");
			c.DataMember = "Level_Unit_Dsc";
			c.Caption = "Basis";
			c.Width = 250;

			c = DropDownList.Columns.Add("Level_Cd");
			c.DataMember = "Level_Cd";
			c.Caption = "Level";
			c.Width = 150;
			c.Visible = false;

			c = DropDownList.Columns.Add("Unit_Type_Cd");
			c.DataMember = "Unit_Type_Cd";
			c.Caption = "Unit Type";
			c.Width = 150;
			c.Visible = false;

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

			DataTable dt = ClsLevelUnit.GetAll();
			if (dt != null) ClsConnection.AddColumns(dt, "Level_Unit_ID", "Level_Unit_Dsc");

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
					Display.ShowError("ArcSys", "Specified item is not in the list");
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