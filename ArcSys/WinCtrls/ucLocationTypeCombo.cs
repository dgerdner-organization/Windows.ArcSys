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
	/// <summary>ArcSys version of ucMultiColumnCombo for location types</summary>
	public partial class ucLocationTypeCombo : ucMultiColumnCombo
	{
		#region Properties

		/// <summary>Gets the selected ClsLocationType object</summary>
		[Browsable(false)]
		public ClsLocationType SelectedLocationType
		{
			get
			{
				DataRowView drv = SelectedItem as DataRowView;
				return (drv != null) ? new ClsLocationType(drv.Row) : null;
			}
		}

		/// <summary>Gets the selected location type code</summary>
		[Browsable(false)]
		public string SelectedLocationTypeCD
		{
			get
			{
				ClsLocationType item = SelectedLocationType;
				return (item != null) ? item.Location_Type_Cd : null;
			}
		}

		/// <summary>Gets the selected Location type description</summary>
		[Browsable(false)]
		public string SelectedDsc
		{
			get
			{
				ClsLocationType item = SelectedLocationType;
				return (item != null) ? item.Location_Type_Dsc : null;
			}
		}
		#endregion		// #region Properties

		#region Constructors

		/// <summary>Default Constructor</summary>
		public ucLocationTypeCombo()
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
			GridEXColumn c = DropDownList.Columns.Add("Location_Type_Cd");
			c.DataMember = "Location_Type_Cd";
			c.Caption = "Location Type";

			c = DropDownList.Columns.Add("Location_Type_Dsc");
			c.DataMember = "Location_Type_Dsc";
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

			DataTable dt = ClsLocationType.GetAll();
			if (dt != null) ClsConnection.AddColumns(dt, "LOCATION_TYPE_CD", "LOCATION_TYPE_DSC");

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
					Display.ShowError("ArcSys", "Specified location type is not in the list");
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