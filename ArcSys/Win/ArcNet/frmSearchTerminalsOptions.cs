using System;
using System.Data;
using System.Text;
using System.Windows.Forms;
using CS2010.Common;
using CS2010.CommonWinCtrls;
using CS2010.ArcSys.Business;

namespace CS2010.ArcSys.Win
{
	public partial class frmSearchTerminalsOptions : frmDialogBase
	{
		#region Fields/Properties

		private ClsTerminalSearch _Options;

		public ClsTerminalSearch Options { get { return _Options; } }

		#endregion		// #region Fields/Properties

		#region Constructors/Entry/Initialization

		public frmSearchTerminalsOptions()
		{
			InitializeComponent();

			_Options = new ClsTerminalSearch();
		}

		public bool GetSearchCriteria()
		{
			try
			{
				return ShowDialog() == DialogResult.OK;
			}
			catch (Exception ex)
			{
				return Program.ShowError(ex);
			}
		}

		private void frmSearchTerminalsOptions_Load(object sender, EventArgs e)
		{
			try
			{
				cmbPort.Filter = "Location_Type_Cd = 'PORT'";
				cmbPort.DropDownList.Columns["Location_Type_Cd"].Visible = false;
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}
		#endregion		// #region Constructors/Entry/Initialization

		#region Actions/Events

		private void btnClear_Click(object sender, EventArgs e)
		{
			WindowHelper.ClearAllControls(this);
		}

		private void frmSearchTerminalsOptions_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				if (e.Control && e.KeyCode == Keys.D) WindowHelper.ClearAllControls(this);
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void txtID_KeyPress(object sender, KeyPressEventArgs e)
		{
			try
			{
				if (char.IsLetter(e.KeyChar)) e.Handled = true;
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}
		#endregion		// #region Actions/Events

		#region Check/Save Changes

		protected override bool SaveChanges()
		{
			try
			{
				_Options.Clear();

				_Options.Port_CDs = cmbPort.LocationCDs;

				return true;
			}
			catch (Exception ex)
			{
				return Program.ShowError(ex);
			}
		}
		#endregion		// #region Check/Save Changes
	}
}