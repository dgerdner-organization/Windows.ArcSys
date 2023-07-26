using System;
using System.Windows.Forms;
using System.Collections.Generic;
using CS2010.Common;
using CS2010.CommonWinCtrls;
using CS2010.ArcSys.Business;
using System.IO;
using System.Text;

namespace CS2010.ArcSys.Win
{
	public partial class frmCreateMemo : Form
	{
		#region Fields/Properties

		private ClsMemo theMemo;
		private DialogMode CurrentMode;
		private Dictionary<string, ClsMemoAttachment> FileNames;

		public List<ClsMemoAttachment> GetAttachments()
		{
			return new List<ClsMemoAttachment>(FileNames.Values);
		}
		#endregion		// #region Fields/Properties

		#region Constructors/Entry/Init

		public frmCreateMemo()
		{
			InitializeComponent();

			FileNames = new Dictionary<string, ClsMemoAttachment>();
		}

		public ClsMemo CreateMemo()
		{
			try
			{
				CurrentMode = DialogMode.Add;
				theMemo = new ClsMemo();
				theMemo.SetDefaults();

				txtID.Visible = false;
				FileNames.Clear();
				lvwFiles.Visible = btnFile.Visible = true;
				return (ShowDialog() == DialogResult.OK) ? theMemo : null;
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
				return null;
			}
		}

		public bool EditMemo(ClsMemo aMemo)
		{
			try
			{
				CurrentMode = DialogMode.Edit;
				theMemo = (aMemo != null) ? new ClsMemo(aMemo) : null;
				if (theMemo != null) theMemo.ReloadFromDB();
				if (theMemo == null || theMemo.Memo_ID == null)
					return Program.ShowError("No memo provided");

				txtID.Visible = true;
				lvwFiles.Visible = btnFile.Visible = false;
				if (ShowDialog() != DialogResult.OK) return false;

				aMemo.CopyFrom(theMemo);
				return true;
			}
			catch (Exception ex)
			{
				return Program.ShowError(ex);
			}
		}

		private void frmCreateMemo_Load(object sender, EventArgs e)
		{
			try
			{
				BindHelper.Bind(txtMemoDsc, theMemo, "Memo_Dsc");
				BindHelper.Bind(rtfMemo, theMemo, "Memo_Txt");

				txtMemoDsc.MaxLength = ClsMemo.Memo_DscMax;
				rtfMemo.MaxLength = ClsMemo.Memo_TxtMax;
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
				if (dlgOpen.ShowDialog() != DialogResult.OK ||
					dlgOpen.FileNames == null || dlgOpen.FileNames.Length <= 0) return;

				foreach (string file in dlgOpen.FileNames)
				{
					if (file == null || FileNames.ContainsKey(file)) continue;

					ClsMemoAttachment ma = new ClsMemoAttachment();
					ma.SetDefaults();
					ma.Attachment_Nm = Path.GetFileName(file);
					FileNames.Add(file, ma);
				}

				try
				{
					lvwFiles.BeginUpdate();
					lvwFiles.Items.Clear();
					foreach (string file in FileNames.Keys) lvwFiles.Items.Add(file);
				}
				finally
				{
					lvwFiles.EndUpdate();
				}
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
				if (CurrentMode == DialogMode.Add)
				{
					if (!theMemo.ValidateInsert())
					{
						Program.ShowError(theMemo.Error);
						return;
					}

					if (FileNames.Count <= 0)
					{
						if (!Display.Ask("Confirm", "No attachment was selected. Continue anyway?"))
							return;
					}
					else
					{
						StringBuilder sb = new StringBuilder();
						foreach (string file in FileNames.Keys)
						{
							ClsMemoAttachment ma = FileNames[file];
							ma.Attachment = ClsConvert.FileToBlob(file);
							if (ma.Attachment == null || ma.Attachment.Length <= 0)
								sb.AppendFormat("File {0} is empty\r\n", file);
						}
						if (sb.Length > 0)
						{
							if (!Display.Ask("Confirm", "One or more files are empty. Continue anyway?\r\n{0}",
								sb.ToString()))
								return;
						}
					}
				}
				else
				{
					if (!theMemo.ValidateUpdate())
					{
						Program.ShowError(theMemo.Error);
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

		private void lvwFiles_DoubleClick(object sender, EventArgs e)
		{
			try
			{
				if (lvwFiles.SelectedItems == null || lvwFiles.SelectedItems.Count <= 0) return;

				foreach (ListViewItem lvi in lvwFiles.SelectedItems)
				{
					if (FileNames.ContainsKey(lvi.Text))
						FileNames.Remove(lvi.Text);
				}

				try
				{
					lvwFiles.BeginUpdate();
					lvwFiles.Items.Clear();
					foreach (string file in FileNames.Keys) lvwFiles.Items.Add(file);
				}
				finally
				{
					lvwFiles.EndUpdate();
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}
	}
}