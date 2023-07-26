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
	/// <summary>ArcSys version of ucMultiColumnCombo for ClsContractMod items</summary>
	public partial class ucContractModCombo : ucMultiColumnCombo
	{
		#region Properties

		/// <summary>Gets the selected ClsContractMod object</summary>
		[Browsable(false)]
		public ClsContractMod SelectedContractMod
		{
			get
			{
				DataRowView drv = SelectedItem as DataRowView;
				return (drv != null) ? new ClsContractMod(drv.Row) : null;
			}
		}

		/// <summary>Gets the selected contract mod ID</summary>
		[Browsable(false)]
		public long? SelectedContractModID
		{
			get
			{
				ClsContractMod item = SelectedContractMod;
				return (item != null) ? item.Contract_Mod_ID : null;
			}
		}

		/// <summary>Gets the selected contract mod number</summary>
		[Browsable(false)]
		public string SelectedModNo
		{
			get
			{
				ClsContractMod item = SelectedContractMod;
				return (item != null) ? item.Mod_No : null;
			}
		}
		#endregion		// #region Properties

		#region Constructors

		/// <summary>Default Constructor</summary>
		public ucContractModCombo()
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
			GridEXColumn c = DropDownList.Columns.Add("Contract_Mod_ID");
			c.DataMember = "Contract_Mod_ID";
			c.Caption = "ID";
			c.Width = 80;

			c = DropDownList.Columns.Add("Mod_No");
			c.DataMember = "Mod_No";
			c.Caption = "Mod #";
			c.Width = 150;

			c = DropDownList.Columns.Add("Attachment_Nm");
			c.DataMember = "Attachment_Nm";
			c.Caption = "File Name";
			c.Width = 200;

			c = DropDownList.Columns.Add("Mod_Notes");
			c.DataMember = "Mod_Notes";
			c.Caption = "Notes";
			c.Width = 200;

			DropDownList.VisibleRows = 20;
		}

		private void SetTableSource()
		{
			if( ClsEnvironment.IsDesignMode == true ) return;

			DataTable dt = ClsContractMod.GetAll();
			if (dt != null)
			{
				string cdCol = "Mod_No", dscCol = "Attachment_Nm";
				dt.Columns.Add(cdCol + dscCol, typeof(string),
					string.Format("{0} + ' - ' + ISNULL({1}, '<No Attachment>')", cdCol, dscCol));
				dt.Columns.Add(dscCol + cdCol, typeof(string),
					string.Format("ISNULL({1}, '<No Attachment>') + ' - ' + {0}", cdCol, dscCol));
			}

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
					Display.ShowError("ArcSys", "Specified item is not in the list");
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