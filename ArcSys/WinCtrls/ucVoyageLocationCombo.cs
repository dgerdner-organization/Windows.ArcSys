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
	public partial class ucVoyageLocationCombo : ucMultiColumnCombo
	{
		#region Properties

		private string _VoyageCd;
		/// <summary>Gets a list of checked location codes</summary>
		[Browsable(true), DefaultValue(false),
		Description("Filter for a Voyage")]
		public string VoyageCd
		{
			get { return _VoyageCd; }
			set
			{
				if (_VoyageCd == value) return;

				_VoyageCd = value;
				SetTableSource();
			}
		}

		private string _PortType;
		/// <summary>Gets a list of checked location codes</summary>
		[Browsable(true), DefaultValue(false),
		Description("Filter by Load or Discharge")]
		public string PortType
		{
			get { return _PortType; }
			set
			{
				if (_PortType == value) return;

				_PortType = value;
				SetTableSource();
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
		public ucVoyageLocationCombo()
		{
			InitializeComponent();

			_VoyageCd = "SelectVoyage";
			_PortType = "L";
			

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
			GridEXColumn c = DropDownList.Columns.Add("Location_Dsc");
			c.DataMember = "Location_Dsc";
			c.Caption = "Location";
			c.Width = 200;

			GridEXColumn c2 = DropDownList.Columns.Add("pol_pod");
			c2.DataMember = "pol_pod";
			c2.Caption = "Type";
			c2.Width = 50;

			c = DropDownList.Columns.Add("Location_Cd");
			c.DataMember = "Location_Cd";
			c.Caption = "Code";
			c.Visible = true;

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
			// Set in designer SortType = ComboSortType.Description;
			// DisplayType = ComboDisplay.DescriptionOnly;
		}

		private void SetTableSource()
		{
			if( ClsEnvironment.IsDesignMode == true ) return;
				
			DataTable dt = ClsLocation.GetVoyageLocations(VoyageCd, PortType);
			if (dt != null) ClsConnection.AddColumns(dt, "Location_Cd", "Location_Dsc");

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
}