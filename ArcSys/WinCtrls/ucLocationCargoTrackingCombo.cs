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
	/// <summary>ArcSys version of ucMultiColumnCombo for locations</summary>
	public partial class ucLocationCargoTrackingCombo : ucMultiColumnCombo
	{
		#region Properties

		protected LocationCargoTrackingType _LocationTypeDisplay;

		#endregion		// #region Fields

		#region Properties

		/// <summary>Gets/Sets the type of locations to display (see the
		/// LocationType enum for more information)</summary>
		[Browsable(true), DefaultValue(typeof(LocationCargoTrackingType), "All"),
		Description("Gets/Sets the type of locations to display")]
		public LocationCargoTrackingType LocationTypeDisplay
		{
			get { return _LocationTypeDisplay; }
			set
			{
				if (value == _LocationTypeDisplay) return;

				_LocationTypeDisplay = value;
				SetTableType(_LocationTypeDisplay);
			}
		}

		/// <summary>Gets the selected ClsLocation object</summary>
		[Browsable(false)]
		public ClsLocation SelectedLocation
		{
			get
			{
				DataRowView drv = SelectedItem as DataRowView;
				return (drv != null) ? new ClsLocation(drv.Row) : null;
			}
		}

		/// <summary>Gets the selected location code</summary>
		[Browsable(false)]
		public string SelectedLocationCD
		{
			get
			{
				ClsLocation item = SelectedLocation;
				return (item != null) ? item.Location_Cd : null;
			}
		}

		/// <summary>Gets the selected location description</summary>
		[Browsable(false)]
		public string SelectedDsc
		{
			get
			{
				ClsLocation item = SelectedLocation;
				return (item != null) ? item.Location_Dsc : null;
			}
		}
		#endregion		// #region Properties

		#region Constructors

		/// <summary>Default Constructor</summary>
		public ucLocationCargoTrackingCombo()
		{
			InitializeComponent();

			SetTableType(LocationCargoTrackingType.All);

			CreateStructure();
		}
		#endregion		// #region Constructors

		#region Public Methods

		public void Reset()
		{
			if( ClsEnvironment.IsDesignMode == true ) return;

			SetTableType(_LocationTypeDisplay);

			//SetTableSource();
		}
		#endregion		// #region Public Methods

		#region Helper Methods

		private void CreateStructure()
		{
			GridEXColumn c = DropDownList.Columns.Add("Location_Dsc");
			c.DataMember = "Location_Dsc";
			c.Caption = "Location";
			c.Width = 250;

			c = DropDownList.Columns.Add("Location_Type_Cd");
			c.DataMember = "Location_Type_Cd";
			c.Caption = "Type";
			c.Width = 100;

			c = DropDownList.Columns.Add("Location_Cd");
			c.DataMember = "Location_Cd";
			c.Caption = "Code";

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
			// Set in designer
			//SortType = ComboSortType.Description;
			//DisplayType = ComboDisplay.DescriptionOnly;
		}

		private void SetTableType(LocationCargoTrackingType locType)
		{
			if (ClsEnvironment.IsDesignMode == true) return;

			switch (locType)
			{
				case LocationCargoTrackingType.All:
					Table = ClsLocation.GetAll();
					break;
				case LocationCargoTrackingType.Conus:
					Table = ClsLocation.GetCargoTracking("Y",null);
					break;
				case LocationCargoTrackingType.OConus:
					Table = ClsLocation.GetCargoTracking("N",null);
					break;
				case LocationCargoTrackingType.Ports:
					Table = ClsLocation.GetCargoTracking(null,"PORT");
					break;
				case LocationCargoTrackingType.Land:
					Table = ClsLocation.GetCargoTracking(null,"LAND");
					break;
				case LocationCargoTrackingType.ConusPorts:
					Table = ClsLocation.GetCargoTracking("Y", "PORT");
					break;
				case LocationCargoTrackingType.OConusPorts:
					Table = ClsLocation.GetCargoTracking("N", "PORT");
					break;
				case LocationCargoTrackingType.ConusLand:
					Table = ClsLocation.GetCargoTracking("Y", "LAND");
					break;
				case LocationCargoTrackingType.OConusLand:
					Table = ClsLocation.GetCargoTracking("N", "LAND");
					break;
                case LocationCargoTrackingType.GeoRegion:
                    Table = ClsLocation.GetGeoRegionLocations(null);
                    break;
                case LocationCargoTrackingType.GeoRegionLand:
                    Table = ClsLocation.GetGeoRegionLocations("LAND");
                    break;
                case LocationCargoTrackingType.GeoRegionPort:
                    Table = ClsLocation.GetGeoRegionLocations("PORT");
                    break;
				default:
					Table = null;
					break;

			}
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
					Display.ShowError("ArcSys", "Specified location is not in the list");
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

	public enum LocationCargoTrackingType
	{
		All,
		Conus,
		OConus,
		Ports,
		Land,
		ConusPorts,
		OConusPorts,
		ConusLand,
		OConusLand,
        GeoRegion,
        GeoRegionLand,
        GeoRegionPort
	};

}