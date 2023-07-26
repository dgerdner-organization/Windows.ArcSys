using System;
using System.Data;
using System.Windows.Forms;
using System.ComponentModel;
using CS2010.Common;
using CS2010.CommonWinCtrls;
using ASL.ITrack.Business;
using Janus.Windows.GridEX;

namespace ASL.ITrack.WinCtrls
{
	/// <summary>ITrack version of ucMultiColumnCombo for users</summary>
	public partial class ucUserCombo : ucMultiColumnCombo
	{
		#region Properties

		/// <summary>Gets the selected ClsUser object</summary>
		[Browsable(false)]
		public ClsUser SelectedUser
		{
			get
			{
				DataRowView drv = SelectedItem as DataRowView;
				return ( drv != null ) ? new ClsUser(drv.Row) : null;
			}
		}

		/// <summary>Gets the selected user login</summary>
		[Browsable(false)]
		public string SelectedUserLogin
		{
			get
			{
				ClsUser item = SelectedUser;
				return ( item != null ) ? item.User_Login : null;
			}
		}
		#endregion		// #region Properties

		#region Constructors

		/// <summary>Default Constructor</summary>
		public ucUserCombo()
		{
			InitializeComponent();

			SetTable();

			CreateStructure();
		}
		#endregion		// #region Constructors

		#region Public Methods

		public void Reset()
		{
			if( ClsEnvironment.IsDesignMode == true ) return;

			SetTable();
		}
		#endregion		// #region Public Methods

		#region Helper Methods

		private void CreateStructure()
		{
			GridEXColumn c = DropDownList.Columns.Add("User_Login");
			c.DataMember = "User_Login";
			c.Caption = "User Login";
			c.Width = 150;

			c = DropDownList.Columns.Add("User_Nm");
			c.DataMember = "User_Nm";
			c.Caption = "User Name";
			c.Width = 300;

			DropDownList.VisibleRows = 20;
		}

		private void SetTable()
		{
			if( ClsEnvironment.IsDesignMode == true ) return;

			Table = ClsUser.GetAll(true);
			ClsConnection.AddColumns(Table, "User_Login", "User_Nm");
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
					Display.ShowError("ITrack", "Specified item is not in the list");
				}
				else if( DroppedDown == true )
					e.Cancel = true;
			}
			catch( Exception ex )
			{
				Display.ShowError("ITrack", ex);
			}
			base.OnValidating(e);
		}
		#endregion		// #region Overrides
	}
}