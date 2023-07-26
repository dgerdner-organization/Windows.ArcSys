using System;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;
using CS2010.Common;
using CS2010.CommonWinCtrls;
using ASL.ITrack.Business;
using Janus.Windows.GridEX;

namespace ASL.ITrack.WinCtrls
{
	/// <summary>ITrack version of ucCheckedComboBox for users</summary>
	public partial class ucUserCheckboxCombo : ucCheckedComboBox
	{
		#region Properties

		/// <summary>Gets a list of checked ClsUser objects</summary>
		[Browsable(false)]
		public List<ClsUser> CheckedUsers
		{
			get
			{
				List<ClsUser> lst = new List<ClsUser>();

				if( CheckedItems != null )
				{
					foreach( DataRowView drv in CheckedItems )
						if( drv != null && drv.Row != null )
							lst.Add(new ClsUser(drv.Row));
				}

				return lst;
			}
		}

		/// <summary>Gets a list of checked User_Logins</summary>
		[Browsable(false)]
		public List<string> CheckedUserLogins
		{
			get
			{
				List<string> lst = new List<string>();

				if( CheckedItems != null )
				{
					foreach( DataRowView drv in CheckedItems )
					{
						if( drv == null || drv.Row == null ) continue;

						ClsUser item = new ClsUser(drv.Row);
						if( string.IsNullOrEmpty(item.User_Login) == false )
							lst.Add(item.User_Login);
					}
				}

				return lst;
			}
		}

		/// <summary>Gets a comma separated string of User logins</summary>
		[Browsable(false)]
		public string UserLogins
		{
			get
			{
				StringBuilder sb = new StringBuilder();

				if( CheckedItems != null )
				{
					foreach( DataRowView drv in CheckedItems )
					{
						if( drv == null || drv.Row == null ) continue;

						ClsUser item = new ClsUser(drv.Row);
						if( string.IsNullOrEmpty(item.User_Login) == false )
							sb.AppendFormat("{0}'{1}'",
								( sb.Length > 0 ? ", " : null ), item.User_Login);
					}
				}

				return ( sb.Length > 0 ) ? sb.ToString() : null;
			}
		}
		#endregion		// #region Properties

		#region Constructors

		/// <summary>Default Constructor</summary>
		public ucUserCheckboxCombo()
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
			GridEXColumn c = DropDownList.Columns.Add("Selector");
			c.DataMember = "User_Login";
			c.ActAsSelector = true;
			c.UseHeaderSelector = false;
			c.Caption = null;
			c.Width = 30;

			c = DropDownList.Columns.Add("User_Login");
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
			base.OnValidating(e);
			try
			{
				if( CheckedItems != null )
				{
					foreach( object obj in CheckedItems )
					{
						if( obj == null )
						{
							e.Cancel = true;
							Display.ShowError("ITrack", "One or more items are invalid");
							break;
						}
					}
				}
				if( e.Cancel == false && DroppedDown == true ) e.Cancel = true;
			}
			catch( Exception ex )
			{
				Display.ShowError("ITrack", ex);
			}
		}
		#endregion		// #region Overrides
	}
}