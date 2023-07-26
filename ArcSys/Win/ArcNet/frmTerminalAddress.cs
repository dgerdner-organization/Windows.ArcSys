using System;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;
using CS2010.Common;
using CS2010.CommonWinCtrls;
using CS2010.ArcSys.Business;
using Janus.Windows.GridEX;

namespace CS2010.ArcSys.Win
{
	public partial class frmTerminalAddress : frmAddress
	{
		#region Fields

		private ClsTerminalAddress theAddress;
		private List<ClsTerminalAddress> AddressList;

		#endregion		// #region Fields

		#region Constructors

		public frmTerminalAddress()
		{
			InitializeComponent();
		}
		#endregion		// #region Constructors

		#region Public Methods

		public bool Edit(ClsTerminalAddress anAddress, List<ClsTerminalAddress> lst)
		{
			try
			{
				CurrentMode = DialogMode.Edit;

				// Only add unique addresses
				AddressList = new List<ClsTerminalAddress>();
				foreach (ClsTerminalAddress oa in lst)
				{
					if( AddressList.Exists(
						delegate(ClsTerminalAddress a)
						{
							if( string.Compare(a.Addr1, oa.Addr1, true) != 0 ||
								string.Compare(a.Addr2, oa.Addr2, true) != 0 ||
								string.Compare(a.Addr3, oa.Addr3, true) != 0 ||
								string.Compare(a.City, oa.City, true) != 0 ||
								string.Compare(a.State_Prov_Cd,
								oa.State_Prov_Cd, true) != 0 ||
								string.Compare(a.Postal_Cd,
								oa.Postal_Cd, true) != 0 ) return false;
							return true;
						}) == true ) continue;

					if( string.IsNullOrEmpty(oa.Addr1) == true &&
						string.IsNullOrEmpty(oa.Addr2) == true &&
						string.IsNullOrEmpty(oa.Addr3) == true &&
						string.IsNullOrEmpty(oa.City) == true &&
						string.IsNullOrEmpty(oa.State_Prov_Cd) == true &&
						string.IsNullOrEmpty(oa.Postal_Cd) == true ) continue;

					AddressList.Add(oa);
				}

				theAddress = new ClsTerminalAddress(anAddress);
				_Address = theAddress;

				if( ShowDialog() != DialogResult.OK ) return false;

				anAddress.CopyFrom(theAddress);
				return true;
			}
			catch( Exception ex )
			{
				Program.ShowError(ex);
			}
			return true;
		}
		#endregion		// #region Public Methods

		#region Helper Methods

		private void TerminalAddressLoad()
		{
			try
			{
				// Add addresses to the list that are for the given section
				grdAddr.DataSource = AddressList;

				theAddress.IsDirty = false;
				BusinessObject = theAddress;

				Text = theAddress.Terminal_Section.Terminal_Section_Dsc;
				BindHelper.Bind(txtAddressee, theAddress, "Addressee_Nm");
				BindHelper.Bind(txtContact, theAddress, "Contact_Nm");
				BindHelper.Bind(txtContactDsc, theAddress, "Contact_Dsc");
			}
			catch( Exception ex )
			{
				Program.ShowError(ex);
			}
		}

		private void CopyAddress()
		{
			try
			{
				GridArea ga = grdAddr.HitTest();
				if( ga != GridArea.Cell ) return;

				GridEXRow r = grdAddr.GetRow();
				if( r == null ) return;

				ClsTerminalAddress addr = r.DataRow as ClsTerminalAddress;
				if( addr == null ) return;

				Address.Copy(addr, theAddress);
			}
			catch( Exception ex )
			{
				Program.ShowError(ex);
			}
		}
		#endregion		// #region Helper Methods

		#region Event Handlers

		private void frmTerminalAddress_Load(object sender, EventArgs e)
		{
			TerminalAddressLoad();
		}

		private void grdAddr_DoubleClick(object sender, EventArgs e)
		{
			CopyAddress();
		}
		#endregion		// #region Event Handlers
	}
}