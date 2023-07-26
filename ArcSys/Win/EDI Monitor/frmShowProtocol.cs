using System;
using System.Data;
using System.Windows.Forms;
using CS2010.Common;
using Janus.Windows.GridEX;
using CS2010.ArcSys.Business;

namespace CS2010.ArcSys.Win
{
	public partial class frmShowProtocol : Form
	{
		private ScanLine theLine;
		private DataTable dtProtocol;
		private IFilterCondition grdFilter;

		public frmShowProtocol()
		{
			InitializeComponent();
		}

		public void ShowProtocol(DataTable dt, ScanLine aLine)
		{
			try
			{
				theLine = aLine;
				dtProtocol = dt;
				ShowDialog();
			}
			catch( Exception ex )
			{
				Program.ShowError(ex);
			}
		}

		public void ShowWindow(DataTable dt, ScanLine aLINE)
		{
			try
			{
				theLine = aLINE;
				dtProtocol = dt;
				AdjustForm(Program.MainWindow, true, null);

				InitializeComponent();
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		protected void AdjustForm(Form frmParent, bool fullSize, FormClosedEventHandler ev)
		{
			try
			{
				this.Show();
				MdiParent = frmParent;
				if (fullSize) WindowState = FormWindowState.Maximized;
				if (ev != null) FormClosed += new FormClosedEventHandler(ev);
			}
			catch (Exception ex)
			{
				Program.ShowError("ChildBase", ex);
			}
		}
		private void frmShowProtocol_Load(object sender, EventArgs e)
		{
			try
			{
				grdProtocol.DataSource = dtProtocol;
				grdProtocol.RootTable.TableHeader = Janus.Windows.GridEX.InheritableBoolean.True;
				grdProtocol.RootTable.Caption = string.Format("{0} Row(s) {1}",
					grdProtocol.RecordCount, (theLine != null ? theLine.FileName : null));
			}
			catch( Exception ex )
			{
				Program.ShowError(ex);
			}
		}

		private void grdProtocol_FilterApplied(object sender, EventArgs e)
		{
			try
			{
				int dtTotal = (dtProtocol != null) ? dtProtocol.Rows.Count : 0;
				int gridTotal = grdProtocol.RecordCount;
				if( dtTotal != gridTotal )
					grdProtocol.RootTable.Caption =
						string.Format("{0} Total Row(s), {1} Matching Row(s)", dtTotal, gridTotal);
				else
					grdProtocol.RootTable.Caption = string.Format("{0} Row(s) {1}",
						gridTotal, (theLine != null ? theLine.FileName : null));
			}
			catch( Exception ex )
			{
				Program.ShowError(ex);
			}
		}

		private void grdProtocol_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				if( e.KeyCode == Keys.C && e.Control )
				{
					GridEXRow r = grdProtocol.GetRow();
					GridEXColumn c = grdProtocol.CurrentColumn;
					if( r == null || c == null || string.IsNullOrEmpty(c.DataMember) ) return;

					string s = ClsConvert.ToString(r.Cells[c].Text);
					if( !string.IsNullOrEmpty(s) ) Clipboard.SetText(s);
				}
			}
			catch( Exception ex )
			{
				Program.ShowError(ex);
			}
		}

		private void grdProtocol_DoubleClick(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start(theLine.FileNameFullPath);
		}

		private void cbxShowAll_CheckedChanged(object sender, EventArgs e)
		{
			if( cbxShowAll.Checked )
			{
				grdFilter = grdProtocol.RootTable.FilterCondition;
				grdProtocol.RootTable.FilterCondition = null;
			}
			else
			{
				if( grdFilter != null )
				{
					grdProtocol.RootTable.FilterCondition = grdFilter;
				}
			}
		}

		private void grdProtocol_LinkClicked(object sender, ColumnActionEventArgs e)
		{
			try
			{
				string sBookingNo = grdProtocol.CurrentRow.Cells["booking_no_epdbunr"].Value.ToString();
				if (string.IsNullOrEmpty(sBookingNo))
				{
					Program.Show("Booking Number is empty");
					return;
				}
				ClsBookingLine bl = ClsBookingLine.GetByBookingNo(sBookingNo);
				if (bl != null)
					ViewWindowManager.View(bl);
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

	}
}