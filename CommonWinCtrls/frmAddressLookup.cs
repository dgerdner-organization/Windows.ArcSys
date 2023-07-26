using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Windows.Forms;
using System.Collections.Generic;
using CS2010.Common;
using Janus.Windows.GridEX;

namespace CS2010.CommonWinCtrls
{
	public partial class frmAddressLookup : frmDialogBase
	{
		#region Fields

		private Address theAddress;
		protected ClsConnection Connection;

		#endregion		// #region Fields

		#region Constructors

		public frmAddressLookup()
		{
			InitializeComponent();

			if( DesignMode == false && ClsEnvironment.IsDesignMode == false )
				Connection = new ClsConnection();
		}
		#endregion		// #region Constructors

		#region Public Methods

		public Address FindAddress()
		{
			try
			{
				theAddress = new Address();
				return ( ShowDialog() == DialogResult.OK ) ? theAddress : null;
			}
			catch( Exception ex )
			{
				Display.ShowError("Postal Error", ex);
				return null;
			}
		}

		public Address FindAddress(IAddress initAddress)
		{
			try
			{
				theAddress = new Address(initAddress);

				return ( ShowDialog() == DialogResult.OK ) ? theAddress : null;
			}
			catch( Exception ex )
			{
				Display.ShowError("Postal Error", ex);
				return null;
			}
		}
		#endregion		// #region Public Methods

		#region Helper Methods

		private void LookupFormLoad()
		{
			try
			{
				txtCity.Text = theAddress.City;
				txtState.Text = theAddress.State_Prov_Cd;
				txtZip.Text = theAddress.Postal_Cd;
			}
			catch( Exception ex )
			{
				Display.ShowError("Postal Error", ex);
			}
		}

		private void Lookup()
		{
			try
			{
				grdAddress.DataSource = null;

				List<DbParameter> p = new List<DbParameter>();
				StringBuilder sb = new StringBuilder();
				sb.AppendFormat("SELECT * FROM {0} WHERE 1 = 1 ", PostalDB.PostalName);

				string s = txtCity.Text.Trim();
				if( s != null && s.EndsWith("*") == false && s.EndsWith("%") == false )
					s = s + '*';
				Connection.AppendLikeClause(sb, p, "AND",
					PostalDB.CityColumn, "@CITY_NM", s);
				Connection.AppendLikeClause(sb, p, "AND",
					PostalDB.StateColumn, "@STATE_CD", txtState.Text.Trim());
				Connection.AppendLikeClause(sb, p, "AND",
					PostalDB.PostalCdColumn, "@ZIP_CD", txtZip.Text.Trim());

				DataTable dt = Connection.GetDataTable(sb.ToString(), p.ToArray());
				dt.DefaultView.Sort = string.Format
					("{0} ASC, {1} ASC, {2} ASC, {3} ASC, {4} ASC",
					PostalDB.CityColumn, PostalDB.StateColumn, PostalDB.PostalCdColumn,
					PostalDB.PostalTypeColumn, PostalDB.CityTypeColumn);
				grdAddress.DataSource = dt;
				if( dt == null || dt.Rows.Count <= 0 )
					Display.Show("Results", "No matches found");
			}
			catch( Exception ex )
			{
				Display.ShowError("Postal Error", ex);
			}
		}
		#endregion		// #region Helper Methods

		#region Overrides

		protected override bool CheckChanges()
		{
			try
			{
				DataRow dr = grdAddress.GetDataRow();
				if( dr == null )
					return Display.ShowError("Error", "No row selected");

				theAddress.City = ClsConvert.ToString(dr[PostalDB.CityColumn]);
				theAddress.State_Prov_Cd = ClsConvert.ToString(dr[PostalDB.StateColumn]);
				theAddress.Postal_Cd = ClsConvert.ToString(dr[PostalDB.PostalCdColumn]);

				string type = ClsConvert.ToString(dr[PostalDB.PostalTypeColumn]);

				theAddress.Country_Cd =
					( string.Compare(type, PostalType.Military, true) != 0 )
					? "USA" : null;

				return true;
			}
			catch( Exception ex )
			{
				return Display.ShowError("Postal Error", ex);
			}
		}
		#endregion		// #region Overrides

		#region Event Handlers

		private void frmAddressLookup_Load(object sender, EventArgs e)
		{
			LookupFormLoad();
		}

		private void btnSearch_Click(object sender, EventArgs e)
		{
			Lookup();
		}
		#endregion		// #region Event Handlers
	}
}