using System;
using System.Windows.Forms;
using CS2010.Common;
using CS2010.CommonWinCtrls;
using CS2010.ArcSys.Business;
using System.IO;

namespace CS2010.ArcSys.Win
{
	public partial class frmCreateContractMod : Form
	{
		#region Fields/Properties

		private ClsContractMod theMod;
		private DialogMode CurrentMode;
		private bool HasAttachmentChanged;

		#endregion		// #region Fields/Properties

		#region Constructors/Entry/Init

		public frmCreateContractMod()
		{
			InitializeComponent();
		}

		public ClsContractMod CreateMod()
		{
			try
			{
				CurrentMode = DialogMode.Add;
				theMod = new ClsContractMod();
				theMod.SetDefaults();

				HasAttachmentChanged = false;
				txtAttachmentNm.Visible = false;
				txtID.Visible = false;
				return (ShowDialog() == DialogResult.OK) ? theMod : null;
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
				return null;
			}
		}

		public bool EditMod(ClsContractMod aMod)
		{
			try
			{
				CurrentMode = DialogMode.Edit;
				theMod = (aMod != null) ? new ClsContractMod(aMod) : null;
				if (theMod != null) theMod.ReloadFromDB();
				if (theMod == null || theMod.Contract_Mod_ID == null)
					return Program.ShowError("No contract mod provided");

				HasAttachmentChanged = false;
				txtAttachmentNm.Visible = false;
				txtID.Visible = true;
				if (ShowDialog() != DialogResult.OK) return false;

				aMod.CopyFrom(theMod);
				return true;
			}
			catch (Exception ex)
			{
				return Program.ShowError(ex);
			}
		}

		private void frmCreateContractMod_Load(object sender, EventArgs e)
		{
			try
			{
				BindHelper.Bind(txtModNo, theMod, "Mod_No");
				BindHelper.Bind(rtfMemo, theMod, "Mod_Notes");
				BindHelper.Bind(txtAttachmentNm, theMod, "Attachment_Nm");
				txtFullFilePath.Text = theMod.Attachment_Nm;

				txtModNo.MaxLength = ClsContractMod.Mod_NoMax;
				rtfMemo.MaxLength = ClsContractMod.Mod_NotesMax;
				txtAttachmentNm.MaxLength = ClsContractMod.Attachment_NmMax;
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}
		#endregion		// #region Constructors

		#region Actions

		private void btnFile_Click(object sender, EventArgs e)
		{
			try
			{
				if (dlgOpen.ShowDialog() != DialogResult.OK) return;

				txtFullFilePath.Text = dlgOpen.FileName;
				theMod.Attachment_Nm = Path.GetFileName(dlgOpen.FileName);
				HasAttachmentChanged = true;
				txtAttachmentNm.Visible = true;
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}
		#endregion		// #region Actions

		#region Save

		private void btnOK_Click(object sender, EventArgs e)
		{
			try
			{
				if (HasAttachmentChanged)
				{
					if (!string.IsNullOrEmpty(txtFullFilePath.Text))
						theMod.Attachment = ClsConvert.FileToBlob(txtFullFilePath.Text);
					else
						theMod.Attachment = null;
				}

				if (CurrentMode == DialogMode.Add)
				{
					if (!theMod.ValidateInsert())
					{
						Program.ShowError(theMod.Error);
						return;
					}
				}
				else
				{
					if (!theMod.ValidateUpdate())
					{
						Program.ShowError(theMod.Error);
						return;
					}
				}

				if (string.IsNullOrEmpty(theMod.Attachment_Nm))
				{
					if (!Display.Ask("Confirm", "No attachment was selected. Continue anyway?"))
						return;
				}
				else
				{
					if (theMod.Attachment == null || theMod.Attachment.Length <= 0)
					{
						if (!Display.Ask("Confirm", "Selected file is empty. Continue anyway?"))
							return;
					}
				}

				// The caller will handle the Save: Insert() or Update();

				DialogResult = DialogResult.OK;
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}
		#endregion		// Save
	}
}