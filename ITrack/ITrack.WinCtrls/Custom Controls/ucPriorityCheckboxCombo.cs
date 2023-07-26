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
	/// <summary>ITrack version of ucCheckedComboBox for priorities</summary>
	public partial class ucPriorityCheckboxCombo : ucCheckedComboBox
	{
		#region Fields

		private bool IsLoadingDataSource;

		#endregion		// #region Fields

		#region Properties

		/// <summary>Gets a list of checked priority codes</summary>
		[Browsable(false)]
		public List<string> CheckedPriorityCDs
		{
			get
			{
				List<string> lst = new List<string>();

				if( CheckedItems != null )
				{
					foreach( ComboItem ci in CheckedItems )
					{
						if( ci == null ) continue;

						if( string.IsNullOrEmpty(ci.Code) == false )
							lst.Add(ci.Code);
					}
				}

				return lst;
			}
		}

		/// <summary>Gets a comma separated string of priority codes</summary>
		[Browsable(false)]
		public string PriorityCDs
		{
			get
			{
				StringBuilder sb = new StringBuilder();

				if( CheckedItems != null )
				{
					foreach( ComboItem ci in CheckedItems )
					{
						if( ci == null ) continue;

						if( string.IsNullOrEmpty(ci.Code) == false )
							sb.AppendFormat("{0}'{1}'",
								(sb.Length > 0 ? ", " : null), ci.Code);
					}
				}

				return ( sb.Length > 0 ) ? sb.ToString() : null;
			}
		}
		#endregion		// #region Properties

		#region Constructors

		/// <summary>Default Constructor</summary>
		public ucPriorityCheckboxCombo()
		{
			InitializeComponent();

			IsLoadingDataSource = false;

			SetTable();

			CreateStructure();
		}
		#endregion		// #region Constructors

		#region Public Methods

		public void Reset()
		{
			SetTable();
		}
		#endregion		// #region Public Methods

		#region Helper Methods

		private void CreateStructure()
		{
			GridEXColumn c = DropDownList.Columns.Add("Selector");
			c.DataMember = "Code";
			c.ActAsSelector = true;
			c.UseHeaderSelector = false;
			c.Caption = null;
			c.Width = 30;

			c = DropDownList.Columns.Add("Code");
			c.DataMember = "Code";
			c.Caption = "Priority";
			c.Width = 150;

			c = DropDownList.Columns.Add("Description");
			c.DataMember = "Description";
			c.Caption = "Description";
			c.Width = 300;

			DropDownList.VisibleRows = 20;
		}

		private void SetTable()
		{
			try
			{
				IsLoadingDataSource = true;
				base.DropDownDataSource = null;
				base.DropDownDataSource = ClsIssue.GetPriorities();
			}
			finally
			{
				IsLoadingDataSource = false;
			}
		}
		#endregion		// #region Helper Methods

		#region Overrides

		protected override void SetDataSource(object aValue)
		{
			// JR: We keep track of the data source internally,
			// so do not allow it to be overwritten
			if( IsLoadingDataSource ) base.SetDataSource(aValue);
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