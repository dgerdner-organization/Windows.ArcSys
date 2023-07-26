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
	/// <summary>ArcSys version of ucMultiColumnCombo for geo regions</summary>
	public partial class ucGeoRegionCombo : ucMultiColumnCombo
	{
		#region Properties

		/// <summary>Gets the selected ClsGeoRegion object</summary>
		[Browsable(false)]
		public ClsGeoRegion SelectedGeoRegion
		{
			get
			{
				DataRowView drv = SelectedItem as DataRowView;
				return (drv != null) ? new ClsGeoRegion(drv.Row) : null;
			}
		}

		/// <summary>Gets the selected geo region code</summary>
		[Browsable(false)]
		public string SelectedGeoRegionCD
		{
			get
			{
				ClsGeoRegion item = SelectedGeoRegion;
				return (item != null) ? item.Geo_Region_Cd : null;
			}
		}

		/// <summary>Gets the selected geo region description</summary>
		[Browsable(false)]
		public string SelectedDsc
		{
			get
			{
				ClsGeoRegion item = SelectedGeoRegion;
				return (item != null) ? item.Geo_Region_Dsc : null;
			}
		}
		#endregion		// #region Properties

		#region Constructors

		/// <summary>Default Constructor</summary>
		public ucGeoRegionCombo()
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
			GridEXColumn c = DropDownList.Columns.Add("Geo_Region_Cd");
			c.DataMember = "Geo_Region_Cd";
			c.Caption = "Geographic Region";
			c.Width = 150;

			c = DropDownList.Columns.Add("Geo_Region_Dsc");
			c.DataMember = "Geo_Region_Dsc";
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

			DataTable dt = ClsGeoRegion.GetAll();
			if (dt != null) ClsConnection.AddColumns(dt, "GEO_REGION_CD", "GEO_REGION_DSC");

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
					Display.ShowError("ArcSys", "Specified region is not in the list");
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