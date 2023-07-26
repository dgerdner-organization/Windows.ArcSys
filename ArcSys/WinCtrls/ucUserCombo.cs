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
	/// <summary>ArcSys version of ucMultiColumnCombo for user logins</summary>
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
				return (drv != null) ? new ClsUser(drv.Row) : null;
			}
		}

		/// <summary>Gets the selected user logins</summary>
		[Browsable(false)]
		public string SelectedUserLogin
		{
			get
			{
				ClsUser item = SelectedUser;
				return (item != null) ? item.User_Login : null;
			}
		}
		#endregion		// #region Properties

		#region Constructors

		/// <summary>Default Constructor</summary>
		public ucUserCombo()
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
			GridEXColumn c = DropDownList.Columns.Add("User_Login");
			c.DataMember = "User_Login";
			c.Caption = "Username";

			c = DropDownList.Columns.Add("First_Nm");
			c.DataMember = "First_Nm";
			c.Caption = "First Name";
			c.Width = 150;

			c = DropDownList.Columns.Add("Last_Nm");
			c.DataMember = "Last_Nm";
			c.Caption = "Last Name";
			c.Width = 200;

			c = DropDownList.Columns.Add("Email");
			c.DataMember = "Email";
			c.Caption = "Email";
			c.Width = 200;

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

			DataTable dt = ClsUser.GetAll();

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
					Display.ShowError("ArcSys", "Specified user is not in the list");
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