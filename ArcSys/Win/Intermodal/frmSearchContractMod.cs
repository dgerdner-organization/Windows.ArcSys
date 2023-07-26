using System;
using System.Data;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using CS2010.Common;
using CS2010.CommonWinCtrls;
using CS2010.CommonSecurity;
using CS2010.ArcSys.Business;
using Janus.Windows.GridEX;
using System.IO;

namespace CS2010.ArcSys.Win
{
	public partial class frmSearchContractMod : frmChildBase, ISearchWindow
	{
		#region Fields

		private string Mod_No;
		private string Mod_Notes;
		private string Attachment_Nm;
		private DateRange Mod_Create_Dt;

		private DataSet dsMods;

		private DataTable dtMods
		{
			get
			{
				return (dsMods != null && dsMods.Tables.Count > 0) ? dsMods.Tables[0] : null;
			}
		}

		private DataTable dtActivities
		{
			get
			{
				return (dsMods != null && dsMods.Tables.Count > 1) ? dsMods.Tables[1] : null;
			}
		}

		private DataRelation relMods
		{
			get
			{
				return (dsMods != null && dsMods.Relations.Count > 0) ? dsMods.Relations[0] : null;
			}
		}
		#endregion		// #region Fields

		#region Constructors/Initialization/Entry

		public frmSearchContractMod()
			: base()
		{
			InitializeComponent();

			AdjustForm(Program.MainWindow, true, null);

			WindowHelper.InitAllGrids(this);

			ClsSecurityMaster.SetSecurity(this, ClsEnvironment.User_Id.Value);
		}

		public void ShowSearch(bool showOptions)
		{
			try
			{
				//if (showOptions == true) SearchParameters();
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		public void RefreshResults()
		{
			throw new NotImplementedException();
		}

		private void frmSearchContractMod_Load(object sender, EventArgs e)
		{
			try
			{
				btnSearch.Focus();
				ActiveControl = btnSearch;
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}
		#endregion		// #region Constructors/Initialization/Entry

		#region Search Methods

		private void tbbSearch_Click(object sender, EventArgs e)
		{
			SearchParameters();
		}

		private void SearchParameters()
		{
			try
			{
				Mod_No = txtModNo.Text.Trim();
				Mod_Notes = txtNotes.Text.Trim();
				Attachment_Nm = txtAttachmentNm.Text.Trim();
				Mod_Create_Dt = grpCreateDt.CheckedValueRange;

				PerformSearch();
			}
			catch (Exception ex)
			{
				Program.ShowError(ex.Message);
			}
		}

		private void PerformSearch()
		{
			try
			{
				Program.MainWindow.SetMainMenuStatus(false);

				AdjustGUI(false);

				StartAsynchronousProcess(StartSearch, UpdateGrid, ResetCounter);
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private TimeSpan ElapsedTime;

		private void StartSearch()
		{
			try
			{
				DateTime start = DateTime.Now;
				DataSet ds = ClsContractMod.GetModsDS(Mod_No, Mod_Notes, Attachment_Nm, Mod_Create_Dt);
				TimeSpan time = DateTime.Now - start;
				lock (grdResults)
				{
					dsMods = ds;
					ElapsedTime = time;
				}
			}
			catch (Exception ex)
			{
				if (ex.Message.
					IndexOf("Cancel", StringComparison.InvariantCultureIgnoreCase) < 0)
					Program.ShowError(ex);
				else
					Program.ShowError("Search cancelled by user");
			}
			finally
			{
				AsynchronousProcessComplete = true;
			}
		}

		private void UpdateGrid()
		{
			try
			{
				AdjustGUI(true);

				lock (grdResults)
				{
					DataTable dt = dtMods;
					DataRelation rel = relMods;
					grdResults.DataSource = dsMods;
					if (dt != null)
					{
						if (dt.Rows.Count > 0 && rel != null)
							grdResults.RootTable.ChildTables[0].DataMember = rel.RelationName;
						grdResults.DataMember = dt.TableName;
					}

					grdResults.RootTable.FilterCondition = null;

					grdResults.Focus();
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
			finally
			{
				Program.MainWindow.SetMainMenuStatus(true);
			}
		}

		private void ResetCounter()
		{
			try
			{
				AdjustGUI(true);
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
			finally
			{
				Program.MainWindow.SetMainMenuStatus(true);
			}
		}

		private void AdjustGUI(bool state)
		{
			try
			{
				lock (grdResults)
				{
					tbbAddMod.Enabled = btnSearch.Enabled = btnClear.Enabled =
						grdResults.Enabled = state;
					sbrChild.Visible = sbbProgressCaption.Visible =
						sbbProgressMeter.Visible = !state;
					grdResults.Enabled = state;
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void sbbProgressCaption_Click(object sender, EventArgs e)
		{
			CancelAsynchronousProcess();
		}
		#endregion		// #region Search Methods

		#region Grid Operations/Event Handlers

		public static void RefreshRow()
		{
			try
			{
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void tbbAddMod_Click(object sender, EventArgs e)
		{
			CreateMod();
		}

		private void cnuGridCreateMod_Click(object sender, EventArgs e)
		{
			CreateMod();
		}

		private void CreateMod()
		{
			try
			{
				ClsContractMod mod = null;
				using (frmCreateContractMod f = new frmCreateContractMod())
				{
					mod = f.CreateMod();
				}
				if (mod == null) return;

				mod.Insert();

				DataTable dt = dtMods;
				if (dt != null)
				{
					DataRow dr = dt.NewRow();
					mod.CopyToDataRow(dr);
					dt.Rows.Add(dr);
				}
				else
				{
					txtModNo.Text = mod.Mod_No;
					SearchParameters();
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void grdResults_DoubleClick(object sender, EventArgs e)
		{
			try
			{
				GridArea ga = grdResults.HitTest();
				if (ga != GridArea.Cell) return;

				EditMod();
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void grdResults_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				if (e.KeyCode == Keys.Enter)
				{
					GridEXRow gr = grdResults.GetRow();
					if (gr == null || gr.RowType != RowType.Record) return;

					EditMod();

					e.Handled = true;
				}
				else if (e.KeyCode == Keys.C && e.Control)
				{
					GridEXRow r = grdResults.GetRow();
					GridEXColumn c = grdResults.CurrentColumn;
					if (r == null || c == null || string.IsNullOrEmpty(c.DataMember)) return;

					string s = ClsConvert.ToString(r.Cells[c].Text);
					if (!string.IsNullOrEmpty(s)) Clipboard.SetText(s);
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void cnuGridEditMod_Click(object sender, EventArgs e)
		{
			EditMod();
		}

		private void EditMod()
		{
			try
			{
				DataRow dr = grdResults.GetDataRow();
				if (dr == null) return;

				if (dr.Table.Columns.Contains("Estimate_ID"))
				{
					long? estID = ClsConvert.ToInt64Nullable(dr["Estimate_ID"]);
					ClsEstimate est = (estID != null) ? ClsEstimate.GetUsingKey(estID.Value) : null;
					if (est != null) ViewWindowManager.View(est);
				}
				else
				{
					ClsContractMod cmod = new ClsContractMod(dr);
					using (frmCreateContractMod f = new frmCreateContractMod())
					{
						if (!f.EditMod(cmod)) return;
						cmod.Update();
						cmod.CopyToDataRow(dr);
					}
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void grdResults_ColumnButtonClick(object sender, ColumnActionEventArgs e)
		{
			try
			{
				if (string.Compare(e.Column.Key, "DeleteBtn", true) == 0)
				{
					DeleteMod();
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void cnuGridDeleteMod_Click(object sender, EventArgs e)
		{
			DeleteMod();
		}

		private void DeleteMod()
		{
			try
			{
				DataRow dr = grdResults.GetDataRow();
				if (dr == null) return;

				if (!Display.Ask("Confirm", "Delete the contract mod?")) return;

				ClsContractMod cmod = new ClsContractMod(dr);
				if (!cmod.ValidateDelete())
				{
					Program.ShowError(cmod.Error);
					return;
				}

				cmod.Delete();
				dr.Delete();
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void cnuGridClearAttached_Click(object sender, EventArgs e)
		{
			ClearAttachment();
		}

		private void ClearAttachment()
		{
			try
			{
				DataRow dr = grdResults.GetDataRow();
				if (dr == null) return;

				if (!Display.Ask("Confirm",
					"Are you sure you want to remove the attachment from the contract mod?"))
					return;

				ClsContractMod cmod = new ClsContractMod(dr);
				cmod.Attachment_Nm = null;
				cmod.Attachment = null;
				if (!cmod.ValidateUpdate())
				{
					Program.ShowError(cmod.Error);
					return;
				}

				cmod.Update();
				cmod.CopyToDataRow(dr);
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void grdResults_LinkClicked(object sender, ColumnActionEventArgs e)
		{
			try
			{
				if (string.Compare(e.Column.Key, "Attachment_Nm", true) == 0)
				{
					ViewAttachment();
				}
				else if (string.Compare(e.Column.Key, "Estimate_No", true) == 0)
				{
					ViewEstimate();
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void ViewAttachment()
		{
			try
			{
				DataRow dr = grdResults.GetDataRow();
				if (dr == null) return;

				ClsContractMod cmod = new ClsContractMod(dr);
				if (cmod == null || string.IsNullOrEmpty(cmod.Attachment_Nm) ||
					cmod.Attachment == null) return;

				string file = Path.Combine(Path.GetTempPath(), cmod.Attachment_Nm);
				if (ClsConvert.BlobToFile(file, cmod.Attachment) == false)
				{
					Program.ShowError("Error viewing attachment");
					return;
				}

				ClsConvert.ViewFile(file);
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void ViewEstimate()
		{
			try
			{
				DataRow dr = grdResults.GetDataRow();
				if (dr == null || dr.Table.Columns.Contains("Estimate_ID") == false) return;

				long? estID = ClsConvert.ToInt64Nullable(dr["Estimate_ID"]);
				ClsEstimate est = ( estID != null ) ? ClsEstimate.GetUsingKey(estID.Value) : null;
				if (est != null) ViewWindowManager.View(est);
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}
		#endregion		// #region Grid Operations/Event Handlers

		#region Form Event Handlers

		private void frmSearchContractMod_FormClosing(object sender, FormClosingEventArgs e)
		{
			try
			{
				if (e.CloseReason == CloseReason.WindowsShutDown) return;

				if (IsRunning)
				{
					e.Cancel = true;
					Program.Show("Cancel the search before closing the window");
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void btnSearch_Click(object sender, EventArgs e)
		{
			SearchParameters();
		}

		private void btnClear_Click(object sender, EventArgs e)
		{
			WindowHelper.ClearAllControls(this);
		}
		#endregion		// #region Form Event Handlers
	}
}