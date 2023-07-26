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
	/// <summary>ITrack version of ucCheckedComboBox for statuses</summary>
	public partial class ucStatusCheckboxCombo : ucCheckedComboBox
	{
		#region Properties

		/// <summary>Gets a list of checked ClsStatus objects</summary>
		[Browsable(false)]
		public List<ClsStatus> CheckedStatuses
		{
			get
			{
				List<ClsStatus> lst = new List<ClsStatus>();

				if( CheckedItems != null )
				{
					foreach( DataRowView drv in CheckedItems )
						if( drv != null && drv.Row != null )
							lst.Add(new ClsStatus(drv.Row));
				}

				return lst;
			}
		}

		/// <summary>Gets a list of checked Status codes</summary>
		[Browsable(false)]
		public List<string> CheckedStatusCDs
		{
			get
			{
				List<string> lst = new List<string>();

				if( CheckedItems != null )
				{
					foreach( DataRowView drv in CheckedItems )
					{
						if( drv == null || drv.Row == null ) continue;

						ClsStatus item = new ClsStatus(drv.Row);
						if( string.IsNullOrEmpty(item.Status_Cd) == false )
							lst.Add(item.Status_Cd);
					}
				}

				return lst;
			}
		}

		/// <summary>Gets a comma separated string of Status codes</summary>
		[Browsable(false)]
		public string StatusCDs
		{
			get
			{
				StringBuilder sb = new StringBuilder();

				if( CheckedItems != null )
				{
					foreach( DataRowView drv in CheckedItems )
					{
						if( drv == null || drv.Row == null ) continue;

						ClsStatus item = new ClsStatus(drv.Row);
						if( string.IsNullOrEmpty(item.Status_Cd) == false )
							sb.AppendFormat("{0}'{1}'",
								( sb.Length > 0 ? ", " : null ), item.Status_Cd);
					}
				}

				return ( sb.Length > 0 ) ? sb.ToString() : null;
			}
		}
		#endregion		// #region Properties

		#region Constructors

		/// <summary>Default Constructor</summary>
		public ucStatusCheckboxCombo()
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
			c.DataMember = "Status_Cd";
			c.ActAsSelector = true;
			c.UseHeaderSelector = false;
			c.Caption = null;
			c.Width = 30;

			c = DropDownList.Columns.Add("Status_Cd");
			c.DataMember = "Status_Cd";
			c.Caption = "Status";
			c.Width = 150;

			c = DropDownList.Columns.Add("Status_Dsc");
			c.DataMember = "Status_Dsc";
			c.Caption = "Status Description";
			c.Width = 300;

			DropDownList.VisibleRows = 20;
		}

		private void SetTable()
		{
			if( ClsEnvironment.IsDesignMode == true ) return;

			Table = ClsStatus.GetAll(true);
			ClsConnection.AddColumns(Table, "Status_Cd", "Status_Dsc");
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