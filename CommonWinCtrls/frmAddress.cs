using System;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;
using CS2010.Common;
using Janus.Windows.GridEX;

namespace CS2010.CommonWinCtrls
{
	public partial class frmAddress : frmDialogBase
	{
		#region Fields

		/// <summary>Object that is bound to the controls on the form and
		/// holds the address being entered</summary>
		protected IAddress _Address;

		/// <summary>Gets/Sets a table of US city/state/zip codes</summary>
		/// <remarks>This table is bound to the city combobox control on the
		/// form which will be populated with cities that match a given postal
		/// code. The user is able to enter a value directly into the combobox
		/// in the event that a city does not appear in the list (or if the
		/// table was null or empty). This table will vary depending on the
		/// value entered into the postal code text box</remarks>
		protected DataTable PostalTable;

		/// <summary>Storage for the <see cref="CountryTable"/> property</summary>
		protected DataTable _CountryTable;

		protected ClsConnection Connection;

		#endregion		// #region Fields

		#region Properties

		public string ContactLabel
		{
			get { return txtContact.LabelText; }
			set { txtContact.LabelText = value; }
		}
		
		public string ContactName	
		{
			get { return txtContact.Text ;}
			set { txtContact.Text = value;}
		}
	
		/// <summary>Gets/Sets a table of countries/country codes</summary>
		/// <remarks>This table is bound to the country combobox control on the
		/// form which when not null, provides a list of countries that a user
		/// can select from. The user is able to enter a value directly
		/// into the combobox in the event that a country does not appear in the
		/// list (or if the table was null or empty)</remarks>
		public DataTable CountryTable
		{
			get { return _CountryTable; }
			set { _CountryTable = value; }
		}

		protected bool _CityCaseUpper;
		[Browsable(true), DefaultValue(false),
		Description("Gets/Sets whether the city field is upper case or normal case")]
		public bool CityCaseUpper
		{
			get { return _CityCaseUpper; }
			set
			{
				if (value == _CityCaseUpper) return;

				_CityCaseUpper = value;
				if (_CityCaseUpper) Text = Text.ToUpper();
			}
		}
		#endregion		// #region Properties

		#region Constructors

		/// <summary>Default constructor initializes <see cref="CountryTable"/>
		/// to null. This table can still be used if it is assigned using
		/// its property before the <see cref="Add"/> or <see cref="Edit"/>
		/// methods are called.</summary>
		public frmAddress()
		{
			InitializeComponent();
			_CountryTable = null;

			if( DesignMode == false && ClsEnvironment.IsDesignMode == false )
				Connection = new ClsConnection();
		}

		/// <summary>Constructor that allows the <see cref="CountryTable"/> to
		/// be specified. This table can be accessed through its property
		/// if necessary.</summary>
		public frmAddress(DataTable countries)
		{
			InitializeComponent();
			CountryTable = countries;

			if( DesignMode == false && ClsEnvironment.IsDesignMode == false )
				Connection = new ClsConnection();
		}
		#endregion		// #region Constructors

		#region Public Methods

		public IAddress Add(bool blnShowContact)
		{
			ShowContactName(blnShowContact);
			return Add();
		}

		/// <summary>Method used to create a new address</summary>
		/// <returns>A new Address object if the OK button was clicked
		/// and the form passed validation (meaning both
		/// <see cref="CheckChanges"/> and <see cref="SaveChanges"/>
		/// returned true), null if Cancel was clicked</returns>
		public IAddress Add()
		{
			try
			{
				_Address = new Address();
				CurrentMode = DialogMode.Add;
				return ( ShowDialog() == DialogResult.OK ) ? _Address : null;
			}
			catch( Exception ex )
			{
				Display.ShowError("Address Error", ex);
				return null;
			}
		}

		public bool Edit(IAddress theAddress, bool blnShowContact)
		{
			ShowContactName(blnShowContact);
			return Edit(theAddress);
		}

		/// <summary>Method used to edit an address</summary>
		/// <returns>True if the OK button was clicked and the form passed
		/// validation (<see cref="CheckChanges"/> and <see cref="SaveChanges"/>
		/// returned true), false if Cancel was clicked</returns>
		/// <remarks>The changes are saved to the passed object</remarks>
		public bool Edit(IAddress theAddress)
		{
			try
			{
				_Address = new Address(theAddress);
				CurrentMode = DialogMode.Edit;

				if( ShowDialog() != DialogResult.OK ) return false;

				Address.Copy(_Address, theAddress); 
				return true;
			}
			catch( Exception ex )
			{
				return Display.ShowError("Address Error", ex);
			}
		}
		#endregion		// #region Public Methods

		#region Virtual Methods

		public virtual bool ValidatePostalCode()
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
		#endregion		// #region Virtual Methods

		#region Overrides

		/// <summary>Performs data validation, called automatically when OK or
		/// apply buttons are clicked. If this method succeeds (returns true),
		/// then the <see cref="SaveChanges"/> method is called. The dialog
		/// cannot be closed by the OK button if this method returns false
		/// (the Cancel button must be clicked instead).</summary>
		/// <returns>True if successful, false if not</returns>
		/// <remarks>Required fields: Line 1, City, State, Zip, Country</remarks>
		protected override bool CheckChanges()
		{
			try
			{
				StringBuilder sb = new StringBuilder();
				if( Address.ValidateAddress(_Address, sb) == false )
					return Display.ShowError("Address Error", sb.ToString());

				DataTable dt = cmbCity.DataSource as DataTable;
				if( dt != null )
				{
					bool foundCity = false, foundMatch = false ;
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
		#endregion		// #region Overrides

		#region Helper Methods

		/// <summary>Performs initialization/data binding on form load</summary>
		private void AddressFormLoad()
		{
			try
			{
				if( DesignMode == true || ClsEnvironment.IsDesignMode == true )
					return;

				ApplyPostalCodeFilter();

				cmbCountry.Table = _CountryTable;

				txtAddr1.DataBindings.Add("Text", _Address, "Addr1");
				txtAddr2.DataBindings.Add("Text", _Address, "Addr2");
				txtAddr3.DataBindings.Add("Text", _Address, "Addr3");
				cmbCity.DataBindings.Add("Text", _Address, "City");
				txtState.DataBindings.Add("Text", _Address, "State_Prov_Cd");
				txtPostalCd.DataBindings.Add("Text", _Address, "Postal_Cd");
				cmbCountry.DataBindings.Add("Value", _Address, "Country_Cd");

				Text = string.Format("{0} Address", CurrentMode.ToString());
			}
			catch( Exception ex )
			{
				Display.ShowError("Address Error", ex);
			}
		}

		private void ShowContactName(bool blnShow)
		{
			try
			{
				txtContact.Visible = blnShow;
			}
			catch( Exception ex )
			{
				Display.ShowError("Address Error", ex);
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
					cmbCity.DataSource = PostalTable;
					return;
				}

				string zip = ( _Address.Postal_Cd.Length > 5 )
					? _Address.Postal_Cd.Substring(0, 5) : _Address.Postal_Cd;

				StringBuilder sb = new StringBuilder();
				sb.AppendFormat("SELECT DISTINCT INITCAP({0}) AS {0}, {1}, {2} FROM {3} ",
					PostalDB.CityColumn, PostalDB.StateColumn,
					PostalDB.PostalTypeColumn, PostalDB.PostalName);
				sb.AppendFormat(
					"WHERE {0} not in ('{1}') AND {2} like '{3}%' ORDER BY {4}",
					PostalDB.CityTypeColumn, CityType.NotAcceptable,
					PostalDB.PostalCdColumn, zip, PostalDB.CityColumn);

				PostalTable = Connection.GetDataTable(sb.ToString());
				cmbCity.DataSource = PostalTable;
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
					string.Compare(_Address.Postal_Cd, txtPostalCd.Text, true)
					== 0 ) return;

				_Address.Postal_Cd = txtPostalCd.Text;

				ApplyPostalCodeFilter();
				if( PostalTable == null || PostalTable.Rows.Count <= 0 ) return;

				DataRow dr = PostalTable.Rows[0];
				_Address.City = ClsConvert.ToString(dr[PostalDB.CityColumn]);
				_Address.State_Prov_Cd = ClsConvert.ToString(dr[PostalDB.StateColumn]);

				string postalType = ClsConvert.ToString(dr[PostalDB.PostalTypeColumn]);
				if( string.Compare(postalType, PostalDB.APOType, true) != 0 )
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

		#region Event Handlers

		private void frmAddress_Load(object sender, EventArgs e)
		{
			AddressFormLoad();
		}

		private void txtPostalCd_Validating(object sender, CancelEventArgs e)
		{
			UpdateCity();
		}

		private void cmbCity_TextChanged(object sender, EventArgs e)
		{
			try
			{
				if (!_CityCaseUpper) return;
				ComboBox thisBox = (ComboBox)sender;
				int cursorPosition = thisBox.SelectionStart;
				thisBox.Text = thisBox.Text.ToUpper();
				thisBox.SelectionStart = cursorPosition;
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

		private void cmbCountry_Validating(object sender, CancelEventArgs e)
		{
			e.Cancel = CountryExists() == false;
		}
		#endregion		// #region Event Handlers
	}
}