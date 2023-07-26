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
using System.Collections.Generic;

namespace CS2010.ArcSys.Win
{
	public partial class frmSearchMemo : frmChildBase, ISearchWindow
	{
		#region Fields

		private string Memo_Dsc;
		private string Memo_Txt;
		private string Attachment_Nm;
		private DateRange Memo_Create_Dt;

		private DataSet dsMemos;

		private DataTable dtMemos
		{
			get
			{
				return (dsMemos != null && dsMemos.Tables.Count > 0) ? dsMemos.Tables[0] : null;
			}
		}

		private DataTable dtAttachments
		{
			get
			{
				return (dsMemos != null && dsMemos.Tables.Count > 1) ? dsMemos.Tables[1] : null;
			}
		}

		private DataRelation relMemos
		{
			get
			{
				return (dsMemos != null && dsMemos.Relations.Count > 0) ? dsMemos.Relations[0] : null;
			}
		}
		#endregion		// #region Fields

		#region Constructors/Initialization/Entry

		public frmSearchMemo() : base()
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

		private void frmSearchMemo_Load(object sender, EventArgs e)
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
				Memo_Dsc = txtMemoDsc.Text.Trim();
				Memo_Txt = txtNotes.Text.Trim();
				Attachment_Nm = txtAttachmentNm.Text.Trim();
				Memo_Create_Dt = grpCreateDt.CheckedValueRange;

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
				DataSet ds = ClsMemo.GetMemosDS(Memo_Dsc, Memo_Txt, Attachment_Nm, Memo_Create_Dt);
				TimeSpan time = DateTime.Now - start;
				lock (grdResults)
				{
					dsMemos = ds;
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
					DataTable dt = dtMemos;
					DataRelation rel = relMemos;
					grdResults.DataSource = dsMemos;
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
					tbrMain.Enabled = btnSearch.Enabled = btnClear.Enabled =
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

		private void tbbAddMemo_Click(object sender, EventArgs e)
		{
			CreateMemo();
		}

		private void cnuGridCreateMemo_Click(object sender, EventArgs e)
		{
			CreateMemo();
		}

		private void CreateMemo()
		{
			try
			{
				ClsMemo mm = null;
				List<ClsMemoAttachment> atts = null;
				using (frmCreateMemo f = new frmCreateMemo())
				{
					mm = f.CreateMemo();
					atts = f.GetAttachments();
				}
				if (mm == null) return;

				List<ClsMemoAttachment> addedAttachments = mm.AddMemo(atts);
				if (mm.HasWarnings)
					Program.Show("Memo added but problems with attachments\r\n{0}", mm.Warning);

				if (dsMemos == null || dtMemos == null)
				{
					txtMemoDsc.Text = mm.Memo_Dsc;
					SearchParameters();
					return;
				}

				DataTable dt = dtMemos;
				DataRow drNew = dt.NewRow();
				mm.CopyToDataRow(drNew);
				drNew["Att_Count"] = ClsConvert.ToDbObject(mm.GetAttachmentCount());
				dt.Rows.Add(drNew);

				dt = dtAttachments;
				if (dt != null && addedAttachments != null && addedAttachments.Count > 0)
				{
					foreach (ClsMemoAttachment ma in addedAttachments)
					{
						drNew = dt.NewRow();
						drNew["Memo_Attachment_ID"] = ClsConvert.ToDbObject(ma.Memo_Attachment_ID);
						drNew["Memo_ID"] = ClsConvert.ToDbObject(ma.Memo_ID);
						drNew["Attachment_Nm"] = ClsConvert.ToDbObject(ma.Attachment_Nm);
						drNew["Create_Dt"] = ClsConvert.ToDbObject(ma.Create_Dt);
						drNew["Create_User"] = ClsConvert.ToDbObject(ma.Create_User);
						dt.Rows.Add(drNew);
					}
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void tbbAddAttachment_Click(object sender, EventArgs e)
		{
			try
			{
				DataRow dr = grdResults.GetDataRow();
				if (dr == null) return;
				if (dr.Table.Columns.Contains("Memo_Attachment_ID"))
					dr = dr.GetParentRow(relMemos);
				if (dr == null) return;

				long? mmID = ClsConvert.ToInt64Nullable(dr["Memo_ID"]);
				ClsMemo mm = (mmID != null) ? ClsMemo.GetUsingKey(mmID.Value) : null;
				if (mm == null) return;

				if (dlgOpen.ShowDialog() != DialogResult.OK ||
					dlgOpen.FileNames == null || dlgOpen.FileNames.Length <= 0) return;

				StringBuilder sb = new StringBuilder();
				List<ClsMemoAttachment> atts = new List<ClsMemoAttachment>();
				foreach (string file in dlgOpen.FileNames)
				{
					if (file == null) continue;

					ClsMemoAttachment ma = new ClsMemoAttachment();
					ma.SetDefaults();
					ma.Attachment_Nm = Path.GetFileName(file);
					ma.Attachment = ClsConvert.FileToBlob(file);
					if (ma.Attachment == null || ma.Attachment.Length <= 0)
						sb.AppendFormat("File {0} is empty\r\n", file);
					atts.Add(ma);
				}
				if (atts.Count <= 0)
				{
					Program.ShowError("No attachments found");
					return;
				}

				if (sb.Length > 0)
				{
					if (!Display.Ask("Confirm", "One or more files are empty. Continue anyway?\r\n{0}",
						sb.ToString()))
						return;
				}

				List<ClsMemoAttachment> addedAttachments = mm.AddAttachments(atts);
				if (mm.HasErrors)
				{
					Program.ShowError(mm.Error);
					return;
				}

				if (addedAttachments == null || addedAttachments.Count <= 0)
				{
					Program.ShowError("No attachments were added");
					return;
				}

				if (mm.HasWarnings)
					Program.Show("Problems encountered with attachments\r\n{0}", mm.Warning);

				DataTable dt = dtAttachments;
				if (dt != null)
				{
					foreach (ClsMemoAttachment ma in addedAttachments)
					{
						DataRow drNew = dt.NewRow();
						drNew["Memo_Attachment_ID"] = ClsConvert.ToDbObject(ma.Memo_Attachment_ID);
						drNew["Memo_ID"] = ClsConvert.ToDbObject(ma.Memo_ID);
						drNew["Attachment_Nm"] = ClsConvert.ToDbObject(ma.Attachment_Nm);
						drNew["Create_Dt"] = ClsConvert.ToDbObject(ma.Create_Dt);
						drNew["Create_User"] = ClsConvert.ToDbObject(ma.Create_User);
						dt.Rows.Add(drNew);
					}

					dr["Att_Count"] = ClsConvert.ToDbObject(mm.GetAttachmentCount());
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

				EditMemo();
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

					EditMemo();

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

		private void cnuGridEditMemo_Click(object sender, EventArgs e)
		{
			EditMemo();
		}

		private void EditMemo()
		{
			try
			{
				DataRow dr = grdResults.GetDataRow();
				if (dr == null) return;

				long? mmID = ClsConvert.ToInt64Nullable(dr["Memo_ID"]);
				ClsMemo mm = (mmID != null) ? ClsMemo.GetUsingKey(mmID.Value) : null;
				if (mm == null) return;
				using (frmCreateMemo f = new frmCreateMemo())
				{
					if (!f.EditMemo(mm)) return;
					mm.Update();
					mm.CopyToDataRow(dr);
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
				DataRow dr = grdResults.GetDataRow();
				if( dr == null ) return;

				if (string.Compare(e.Column.Key, "DeleteBtn", true) == 0)
				{
					DeleteMemo();
				}
				else if (string.Compare(e.Column.DataMember, "Memo_Txt", true) == 0)
				{
					ClsMemo mm = new ClsMemo(dr);
					using (frmMemo f = new frmMemo())
					{
						f.WordWrap = true;
						f.ViewText("Memo Body " + mm.Memo_ID, mm.Memo_Txt);
					}
				}
				else if (string.Compare(e.Column.Key, "DeleteAttBtn", true) == 0)
				{
					DeleteAttachment();
				}
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void cnuGridDeleteMemo_Click(object sender, EventArgs e)
		{
			DeleteMemo();
		}

		private void DeleteMemo()
		{
			try
			{
				DataRow dr = grdResults.GetDataRow();
				if (dr == null) return;

				if (!Display.Ask("Confirm", "Delete the memo?")) return;

				ClsMemo memo = new ClsMemo(dr);
				if (!memo.ValidateDelete())
				{
					Program.ShowError(memo.Error);
					return;
				}

				memo.Delete();
				dr.Delete();
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void cnuGridClearAttached_Click(object sender, EventArgs e)
		{
			DeleteAttachment();
		}

		private void DeleteAttachment()
		{
			try
			{
				DataRow dr = grdResults.GetDataRow();
				if (dr == null || !dr.Table.Columns.Contains("Memo_Attachment_ID")) return;

				long? maID = ClsConvert.ToInt64Nullable(dr["Memo_Attachment_ID"]);
				if( maID == null ) return;

				ClsMemoAttachment ma = ClsMemoAttachment.GetUsingKey(maID.Value);
				if( ma == null )
				{
					Program.ShowError("Attachment not found");
					return;
				}

				if (!Display.Ask("Confirm",
					"Are you sure you want to remove the attachment {0}: {1} from the memo?",
					ma.Memo_Attachment_ID, ma.Attachment_Nm))
					return;

				if (!ma.ValidateDelete())
				{
					Program.ShowError(ma.Error);
					return;
				}

				ma.Delete();
				dr.Delete();
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
				if (dr == null || !dr.Table.Columns.Contains("Memo_Attachment_ID")) return;

				long? maID = ClsConvert.ToInt64Nullable(dr["Memo_Attachment_ID"]);
				if( maID == null ) return;

				ClsMemoAttachment ma = ClsMemoAttachment.GetUsingKey(maID.Value);
				if( ma == null )
				{
					Program.ShowError("Attachment not found");
					return;
				}

				if ( string.IsNullOrWhiteSpace(ma.Attachment_Nm) ||
					ma.Attachment == null)
				{
					Program.ShowError("Missing Attachment");
					return;
				}

				string file = Path.Combine(Path.GetTempPath(), ma.Attachment_Nm);
				if (ClsConvert.BlobToFile(file, ma.Attachment) == false)
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
		#endregion		// #region Grid Operations/Event Handlers

		#region Form Event Handlers

		private void frmSearchMemo_FormClosing(object sender, FormClosingEventArgs e)
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
			WindowHelper.ClearControls(grpSearchPanel.Controls);
		}
		#endregion		// #region Form Event Handlers

		private void grdResults_SelectionChanged(object sender, EventArgs e)
		{
			try
			{
				DataRow dr = grdResults.GetDataRow();
				if (dr == null) return;
				if (dr.Table.Columns.Contains("Memo_Attachment_ID"))
					dr = dr.GetParentRow(relMemos);
				string info = null;
				if (dr != null)
				{
					ClsMemo mm = new ClsMemo(dr);
					info = string.Format(" {0} {1}", mm.Memo_ID, mm.Memo_Dsc);
				}

				tbbAddAttachment.Text = "Add Attachment" + info;
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}
	}
}