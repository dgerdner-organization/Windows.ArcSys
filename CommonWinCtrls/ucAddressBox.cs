using System;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using CS2010.Common;
using System.Collections.Generic;

namespace CS2010.CommonWinCtrls
{
	public partial class ucAddressBox : UserControl
	{
		#region Constants

		/// <summary>Database name of the postal code table</summary>
		protected const string PostalName = "R_POSTAL";
		/// <summary>Name of the column in the <see cref="PostalTable"/>
		/// that holds the city names</summary>
		protected const string CityColumn = "Postal_City";
		/// <summary>Name of the column in the <see cref="PostalTable"/>
		/// that holds the state codes</summary>
		protected const string StateColumn = "State_Prov_Cd";
		/// <summary>Name of the column in the <see cref="PostalTable"/>
		/// that holds the postal code</summary>
		protected const string PostalCdColumn = "Postal_Cd";
		/// <summary>Name of the column in the <see cref="PostalTable"/>
		/// that holds the city type</summary>
		protected const string CityTypeColumn = "City_Type";
		/// <summary>Name of the column in the <see cref="PostalTable"/>
		/// that holds the city type</summary>
		protected const string PostalTypeColumn = "Postal_Type_Cd";

		#endregion		// #region Constants

		#region Required Fields

		protected IAddress _Address;
		/// <summary>Object that will be bound to the controls on the form and
		/// holds the address being entered. This propety must be set for
		/// data binding to work correctly.</summary>
		[Browsable(false), DefaultValue(null)]
		public IAddress theAddress
		{
			get { return _Address; }
			set
			{
				_Address = value;
				BindAddress();
				ApplyPostalCodeFilter();
				if( string.IsNullOrEmpty(PostalCd) ) PostalCd = _Address.Postal_Cd;
			}
		}
		#endregion		// #region Required Fields

		#region Optional Fields

		protected DataTable _CountryTable;
		/// <summary>Gets/Sets a table of countries/country codes</summary>
		/// <remarks>This table is bound to the country combobox control on the
		/// form which when not null, provides a list of countries that a user
		/// can select from. The user is able to enter a value directly
		/// into the combobox in the event that a country does not appear in the
		/// list (or if the table was null or empty)</remarks>
		[Browsable(false), DefaultValue(null)]
		public DataTable CountryTable
		{
			get { return _CountryTable; }
			set
			{
				_CountryTable = value;

				cmbCountry.Table = _CountryTable;
			}
		}
		#endregion		// #region Optional Fields

		#region Internal fields/properties

		protected string PostalCd;

		/// <summary>Gets/Sets a table of US city/state/zip codes</summary>
		/// <remarks>This table is bound to the city combobox control on the
		/// form which will be populated with cities that match a given postal
		/// code. The user is able to enter a value directly into the combobox
		/// in the event that a city does not appear in the list (or if the
		/// table was null or empty). This table will vary depending on the
		/// value entered into the postal code text box</remarks>
		protected DataTable PostalTable;

		protected ClsConnection Connection
		{
			get { return ClsConMgr.Manager[ClsEnvironment.ConnectionKey]; }
		}
		#endregion		// #region Internal fields/properties

		#region Public Properties

		/// <summary>Gets/Sets whether the 2nd address line is shown/hidden</summary>
		[DefaultValue(true)]
		[Description("Gets/Sets whether the 2nd address line is shown/hidden")]
		public bool ShowAddr2
		{
			get { return txtAddr2.Visible; }
			set
			{
				if( value == txtAddr2.Visible ) return;

				txtAddr2.Visible = value;
				AdjustLayout();
			}
		}

		/// <summary>Gets/Sets whether the 3rd address line is shown/hidden</summary>
		[DefaultValue(true)]
		[Description("Gets/Sets whether the 3rd address line is shown/hidden")]
		public bool ShowAddr3
		{
			get { return txtAddr3.Visible; }
			set
			{
				if( value == txtAddr3.Visible ) return;

				txtAddr3.Visible = value;
				AdjustLayout();
			}
		}
		#endregion		// #region Public Properties

		#region Error Handling

		protected StringBuilder ErrorBuilder;

		public bool HasError
		{
			get { return ErrorBuilder.Length > 0; }
		}

		public string Error
		{
			get { return ErrorBuilder.ToString(); }
		}
		#endregion		// #region Error Handling

		#region Constructors

		public ucAddressBox()
		{
			InitializeComponent();

			ErrorBuilder = new StringBuilder();
		}
		#endregion		// #region Constructors

		#region Public Validation

		/// <summary>Performs address data validation</summary>
		/// <returns>True if successful, false if not</returns>
		/// <remarks>Required fields: Line 1, City, State, Zip, Country</remarks>
		public bool CheckChanges()
		{
			try
			{
				ErrorBuilder.Length = 0;
				if( Address.ValidateAddress(_Address, ErrorBuilder) == false )
					return false;

				DataTable dt = cmbCity.Table;
				if( dt != null )
				{
					bool foundCity = false, foundMatch = false;
					foreach( DataRow dr in dt.Rows )
					{
						string s = ClsConvert.ToString(dr[PostalDB.CityColumn]);
						string city = s != null ? s.Trim() : null;
						if( string.IsNullOrEmpty(city) == true ) continue;

						foundCity = true;
						if( string.Compare(_Address.City, city, true) == 0 )
						{
							foundMatch = true;
							break;
						}
					}

					if( foundCity && !foundMatch && Display.Ask("Confirm",
						"City/Postal code mismatch, {0} not found in {1}. Continue?",
						_Address.City, _Address.Postal_Cd) == false ) return false;
				}

				return true;
			}
			catch( Exception ex )
			{
				return Display.ShowError("Address Error", ex);
			}
		}
		#endregion		// #region Public Validation

		#region Helper Methods

		protected void BindAddress()
		{
			if( ClsEnvironment.IsDesignMode == true ) return;

			BindHelper.Bind(txtAddr1, _Address, "Addr1");
			BindHelper.Bind(txtAddr2, _Address, "Addr2");
			BindHelper.Bind(txtAddr3, _Address, "Addr3");
			BindHelper.Bind(cmbCity, _Address, "City");
			BindHelper.Bind(txtState, _Address, "State_Prov_Cd");
			BindHelper.Bind(txtPostalCd, _Address, "Postal_Cd");
			BindHelper.Bind(cmbCountry, _Address, "Country_Cd");
		}

		protected bool ValidatePostalCode()
		{
			try
			{
				string zip = ( string.IsNullOrEmpty(_Address.Postal_Cd) == true )
					? string.Empty : _Address.Postal_Cd.Trim();
				StringBuilder sb = new StringBuilder(zip);
				sb.Replace(" ", null).Replace("-", null);
				if( string.Compare(_Address.Country_Cd, "USA", true) == 0 )
					return ( sb.Length == 5 || sb.Length == 9 );
				return ( sb.Length > 0 );
			}
			catch( Exception ex )
			{
				return Display.ShowError("Address Error", ex);
			}
		}

		/// <summary>Filters the <see cref="PostalView"/> based on postal code
		/// and sorts by City Type descending then City Name ascending</summary>
		protected void ApplyPostalCodeFilter()
		{
			try
			{
				if( DesignMode == true || ClsEnvironment.IsDesignMode == true )
					return;

				if( string.IsNullOrEmpty(_Address.Postal_Cd) == true )
				{
					PostalTable = null;
					cmbCity.Table = PostalTable;
					return;
				}

				string zip = ( _Address.Postal_Cd.Length > 5 )
					? _Address.Postal_Cd.Substring(0, 5) : _Address.Postal_Cd;

				StringBuilder sb = new StringBuilder();
				sb.AppendFormat("SELECT DISTINCT {0}, {1}, {2} FROM {3} ",
					CityColumn, StateColumn, PostalTypeColumn, PostalName);
				sb.AppendFormat(
					"WHERE {0} not in ('{1}') AND {2} like '{3}%' ORDER BY {4}",
					CityTypeColumn, CityType.NotAcceptable, PostalCdColumn,
					zip, CityColumn);

				PostalTable = Connection.GetDataTable(sb.ToString());
				cmbCity.Table = PostalTable;
			}
			catch( Exception ex )
			{
				Display.ShowError("Address Error", ex);
			}
		}

		/// <summary>Records new postal code, applies the new filter, and
		/// assigns the city and state fields when possible</summary>
		protected void UpdateCity()
		{
			try
			{
				if( string.IsNullOrEmpty(txtPostalCd.Text) == true ||
					string.Compare(PostalCd, txtPostalCd.Text, true) == 0 )
					return;

				_Address.Postal_Cd = txtPostalCd.Text;

				ApplyPostalCodeFilter();
				if( PostalTable == null || PostalTable.Rows.Count <= 0 ) return;

				DataRow dr = PostalTable.Rows[0];
				_Address.City = ClsConvert.ToString(dr[CityColumn]);
				_Address.State_Prov_Cd = ClsConvert.ToString(dr[StateColumn]);

				string postalType = ClsConvert.ToString(dr[PostalTypeColumn]);
				if( string.Compare(postalType, PostalType.Military, true) != 0 )
					_Address.Country_Cd = "USA";
			}
			catch( Exception ex )
			{
				Display.ShowError("Address Error", ex);
			}
		}

		protected bool CountryExists()
		{
			try
			{
				if( _CountryTable == null || _CountryTable.Rows.Count <= 0 )
					return true;

				return ( cmbCountry.NotInList == true )
					? Display.ShowError("Address Error", "Country not in list")
					: true;
			}
			catch( Exception ex )
			{
				return Display.ShowError("Address Error", ex);
			}
		}

		private void AdjustLayout()
		{
			try
			{
				int minHgt = txtAddr1.Height +
					(txtAddr2.Visible ? txtAddr2.Height : 0) +
					(txtAddr3.Visible ? txtAddr3.Height : 0) +
					cmbCity.Height + txtState.Height +
					txtPostalCd.Height + cmbCountry.Height;
				int hgt = ( Height > minHgt ) ? Height : minHgt;

				int num = 6;
				if( !txtAddr2.Visible ) num--;
				if( !txtAddr3.Visible ) num--;

				int offset = ( hgt - minHgt ) / num;
				txtAddr1.Top = 0;
				Control prevControl = txtAddr1;
				if( txtAddr2.Visible )
				{
					txtAddr2.Top = prevControl.Top + prevControl.Height + offset;
					prevControl = txtAddr2;
				}
				else
				{
					txtAddr2.Top = -txtAddr2.Height;
					txtAddr2.Left = -txtAddr2.Width;
				}
				if( txtAddr3.Visible )
				{
					txtAddr3.Top = prevControl.Top + prevControl.Height + offset;
					prevControl = txtAddr3;
				}
				else
				{
					txtAddr3.Top = -txtAddr3.Height;
					txtAddr3.Left = -txtAddr3.Width;
				}
				cmbCity.Top = prevControl.Top + prevControl.Height + offset;
				txtState.Top = cmbCity.Top + cmbCity.Height + offset;
				txtPostalCd.Top = txtState.Top + txtState.Height + offset;
				cmbCountry.Top = txtPostalCd.Top + txtPostalCd.Height + offset;
				btnLookup.Top = cmbCity.Top - 2;

				int wid = Width - txtAddr1.Left - 2;
				if( wid < 0 ) wid = 0;
				txtAddr1.Width = wid;
				txtAddr2.Width = wid;
				txtAddr3.Width = wid;
				cmbCity.Width = wid - btnLookup.Width - 2;
				txtState.Width = wid;
				txtPostalCd.Width = wid;
				cmbCountry.Width = wid;
			}
			catch( Exception ex )
			{
				Display.ShowError("Address Error", ex);
			}
		}

		private void Lookup()
		{
			try
			{
				using( frmAddressLookup frm = new frmAddressLookup() )
				{
					Address a = frm.FindAddress(_Address);
					if( a == null ) return;

					txtPostalCd.Text = a.Postal_Cd;
					_Address.Postal_Cd = a.Postal_Cd;

					cmbCity.Text = a.City;
					_Address.City = a.City;

					txtState.Text = a.State_Prov_Cd;
					_Address.State_Prov_Cd = a.State_Prov_Cd;

					cmbCountry.Text = a.Country_Cd;
					_Address.Country_Cd = a.Country_Cd;
				}
			}
			catch( Exception ex )
			{
				Display.ShowError("Address Error", ex);
			}
		}
		#endregion		// #region Helper Methods

		#region Overrides

		protected override void OnResize(EventArgs e)
		{
			AdjustLayout();
		}
		#endregion		// #region Overrides

		#region Event Handlers

		private void txtPostalCd_Validating(object sender, CancelEventArgs e)
		{
			UpdateCity();
		}

		private void txtPostalCd_Validated(object sender, EventArgs e)
		{
			try
			{
				PostalCd = txtPostalCd.Text.Trim();
			}
			catch( Exception ex )
			{
				Display.ShowError("Address Error", ex);
			}
		}

		private void cmbCountry_Validating(object sender, CancelEventArgs e)
		{
			e.Cancel = CountryExists() == false;
		}

		private void cmbCity_TextChanged(object sender, EventArgs e)
		{
			try
			{
				int pos = cmbCity.SelectionStart;
				cmbCity.Text = cmbCity.Text.ToUpper();
				cmbCity.SelectionStart = pos;
			}
			catch( Exception ex )
			{
				Display.ShowError("Address Error", ex);
			}
		}

		private void btnLookup_Click(object sender, EventArgs e)
		{
			Lookup();
		}
		#endregion		// #region Event Handlers
	}
}