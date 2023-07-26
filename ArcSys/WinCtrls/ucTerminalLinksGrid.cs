using System;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Windows.Forms;
using System.Collections.Generic;
using CS2010.Common;
using CS2010.CommonWinCtrls;
using CS2010.ArcSys.Business;

namespace CS2010.ArcSys.WinCtrls
{
	public partial class ucTerminalLinksGrid : UserControl
	{
		#region Fields/Properties

		protected ClsConnection Connection { get { return ClsConMgr.Manager["ArcSys"]; } }

		private string _Terminal_Cd;
		public string Terminal_Cd
		{
			get { return _Terminal_Cd; }
			set
			{
				if (string.Compare(_Terminal_Cd, value, true) == 0) return;

				bool resetSource = !string.IsNullOrWhiteSpace(_Terminal_Cd);

				_Terminal_Cd = value;

				if (resetSource) SetGridSource();
			}
		}

		private string _Terminal_Section_Cd;
		public string Terminal_Section_Cd
		{
			get { return _Terminal_Section_Cd; }
			set
			{
				if( string.Compare(_Terminal_Section_Cd, value, true) == 0 ) return;

				bool resetSource = !string.IsNullOrWhiteSpace(_Terminal_Section_Cd);

				_Terminal_Section_Cd = value;

				if( resetSource ) SetGridSource();
			}
		}

		private StringBuilder sbError;
		public string Errors { get { return sbError != null ? sbError.ToString() : null; } }

		#endregion		// #region Fields/Properties

		#region Constructors/Initialization/Cleanup

		public ucTerminalLinksGrid()
		{
			InitializeComponent();

			sbError = new StringBuilder();
		}

		public void SetGridSource()
		{
			try
			{
				if (ClsEnvironment.IsDesignMode == true) return;

				DisposeGrid();
				LoadData();
			}
			catch (Exception ex)
			{
				Display.ShowError("ArcSys", ex);
			}
		}

		public void SetGridSource(string termCd, string termSection)
		{
			try
			{
				Terminal_Cd = termCd;
				Terminal_Section_Cd = termSection;

				if (ClsEnvironment.IsDesignMode == true) return;

				DisposeGrid();
				LoadData();
			}
			catch (Exception ex)
			{
				Display.ShowError("ArcSys", ex);
			}
		}

		private void LoadData()
		{
			ClsConnection cn = Connection;

			StringBuilder sb = new StringBuilder(@"
			SELECT	tl.*
			FROM	R_TERMINAL_LINK tl
			WHERE	1 = 1 ");

			List<DbParameter> p = new List<DbParameter>();
			cn.AppendEqualClause(sb, p, "AND", "tl.terminal_cd", "@TERM_CD", Terminal_Cd);
			cn.AppendEqualClause(sb, p, "AND", "tl.terminal_section_cd", "@SECT_CD", Terminal_Section_Cd);

			DataTable dtGrid = cn.GetDataTable(sb.ToString(), p.ToArray());
			grdLinks.DataSource = dtGrid;

			DataTable dtDropDown =
				cn.GetDataTable("select distinct link_dsc as link_dsc from r_terminal_link");
			grdLinks.DropDowns[0].DataSource = dtDropDown;
		}

		private void DisposeGrid()
		{
			try
			{
				DataTable dt1 = grdLinks.DataSource as DataTable;
				grdLinks.DataSource = null;
				if (dt1 != null)
				{
					dt1.Dispose();
					dt1 = null;
				}
			}
			catch (Exception ex)
			{
				Display.ShowError("ArcSys", ex);
			}
		}
		#endregion		// #region Constructors/Initialization/Cleanup

		public bool SaveChanges()
		{
			try
			{
				sbError.Length = 0;

				DataTable dtSource = grdLinks.DataSource as DataTable;
				DataTable dtChanges = dtSource.GetChanges();
				if (dtChanges == null) return true;	// OK: no changes, return true

				List<ClsTerminalLink> lstAdd = new List<ClsTerminalLink>(),
					lstEdit = new List<ClsTerminalLink>(),
					lstDelete = new List<ClsTerminalLink>();
				foreach (DataRow dr in dtChanges.Rows)
				{
					ClsTerminalLink tl = new ClsTerminalLink(dr);
					if (dr.RowState == DataRowState.Added)
					{
						tl.Terminal_Section_Cd = Terminal_Section_Cd;
						tl.Terminal_Cd = Terminal_Cd;
						if (!tl.ValidateInsert())
							sbError.Append(tl.Description + " Errors\r\n" + tl.Error);
						else
							lstAdd.Add(tl);
					}
					else if (dr.RowState == DataRowState.Modified)
					{
						if (!tl.ValidateUpdate())
							sbError.Append(tl.Description + " Errors\r\n" + tl.Error);
						else
							lstEdit.Add(tl);
					}
					else if (dr.RowState == DataRowState.Deleted)
					{
						if (tl.Terminal_Link_ID != null)
						{
							if (!tl.ValidateDelete())
								sbError.Append(tl.Description + " Errors\r\n" + tl.Error);
							else
								lstDelete.Add(tl);
						}
					}
				}

				if (sbError.Length > 0) return false;

				ClsConnection cn = Connection;
				bool newTx = !cn.IsInTransaction;
				try
				{
					if (newTx == true) cn.TransactionBegin();

					foreach (ClsTerminalLink tl in lstAdd) tl.Insert();
					foreach (ClsTerminalLink tl in lstEdit) tl.Update();
					foreach (ClsTerminalLink tl in lstDelete) tl.Delete();

					if (newTx == true) cn.TransactionCommit();

					dtSource.AcceptChanges();

					return true;
				}
				catch
				{
					if (newTx == true) cn.TransactionRollback();
					throw;
				}
			}
			catch (Exception ex)
			{
				return Display.ShowError("ArcSys", ex);
			}
		}

		private void grdLinks_ColumnButtonClick(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
		{
			try
			{
				if (string.Compare(e.Column.Key, "DeleteBtn", true) == 0)
				{
					DataRow dr = grdLinks.GetDataRow();
					if( dr != null ) dr.Delete();
				}
			}
			catch (Exception ex)
			{
				Display.ShowError("ArcSys", ex);
			}
		}
	}
}
