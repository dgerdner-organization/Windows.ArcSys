using System;
using System.Windows.Forms;
using CS2010.ArcSys.Business;

namespace CS2010.ArcSys.Win
{
	public partial class frmAssignContractMod : Form
	{
		#region Fields/Properties

		private ClsContractMod theMod;
		public ClsContractMod SelectedMod { get { return theMod; } }

		private bool _CreateNew;
		public bool CreateNew { get { return theMod == null && _CreateNew == true; } }

		#endregion		// #region Fields

		#region Constructors/Entry/Init

		public frmAssignContractMod()
		{
			InitializeComponent();
		}

		public bool GetContractMod()
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
		#endregion		// #region Constructors/Entry/Init

		#region Save/Close

		private void lnkNewMod_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			try
			{
				theMod = null;
				_CreateNew = true;
				DialogResult = DialogResult.OK;
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			try
			{
				theMod = cmbMod.SelectedContractMod;
				if (theMod == null)
				{
					Program.ShowError("No contract mod selected");
					return;
				}

				_CreateNew = false;
				DialogResult = DialogResult.OK;
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}
		#endregion		// #region Save/Close
	}
}
