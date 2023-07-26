using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Timers;
using CS2010.Common;
using CS2010.CommonWinCtrls;
using CS2010.ArcSys.Business;
using System.IO;
using System.Data.Common;
using Janus.Windows.GridEX;

using System.Data.OleDb;
using Microsoft.Office.Interop.Excel;

namespace CS2010.ArcSys.Win
{
	public partial class frmImportActuals : frmChildBase
	{
		#region Connections
		private ClsConnection ARCConnection
		{
			get { return ClsConMgr.Manager["ArcSys"]; }
		}
		#endregion

		#region Main Region
		protected System.Data.DataTable dtAdHoc;
		protected bool bInvalidColumn = false;
		protected bool bInvalidLhaul = false;
		public frmImportActuals()
		{
			InitializeComponent();
		}

		public void ShowForm()
		{
			this.Show();
			this.WindowState = FormWindowState.Maximized;

			txtDate.Value = DateTime.Today;
		}

		private void SetTitle(string AdditionalText)
		{
			this.Text = "Import Actuals " + AdditionalText;
		}
		#endregion

		#region Searching

		public void Search()
		{
		}

		private void SaveFile()
		{
			try
			{
				
				string sql = "delete from t_import_actual_dtl where actual_id = 500";
				ARCConnection.RunSQL(sql);

//                foreach (clsImportActualList act in ImportActualList)
//                {
//                    DbParameter[] p = new DbParameter[6];

//                    p[0] = ARCConnection.GetParameter("@ID", i);
//                    p[1] = ARCConnection.GetParameter("@VOYAGE_NO", act.Voyage);
//                    p[2] = ARCConnection.GetParameter("@BOOKING_NO", act.BookingNo);
//                    p[3] = ARCConnection.GetParameter("@LHAUL_AMT", act.LHaul_Amt);
//                    p[4] = ARCConnection.GetParameter("@CUSTOMS_AMT", act.Customs_Amt);
//                    p[5] = ARCConnection.GetParameter("@ACTUAL_ID", 500);


//                    sql = string.Format(@"
//				  insert into t_import_actual_dtl 
//                   (actual_dtl_id, voyage_no, booking_no, lhaul_amt,
//					customs_amt, actual_id)
//				   values 
//					(@ID, @VOYAGE_NO, @BOOKING_NO, @LHAUL_AMT,
//						   @CUSTOMS_AMT, @ACTUAL_ID)");
//                    ARCConnection.RunSQL(sql, p);

//                    i++;
//                }
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		public void SearchCargo(ClsCargo Cargo)
		{

		}

		#endregion

		#region Importing Spreadsheet
		private void ReadExcel()
		{
			try
			{
				// Open the file
				this.openFileDialog1.FileName = "*.xls";
				this.openFileDialog1.ShowDialog();

				// Setup the spreadsheet
				Microsoft.Office.Interop.Excel.Application xlApp;
				Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
				Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
				Microsoft.Office.Interop.Excel.Range rnge;

				string str;
				int rCnt = 0;
				int cCnt = 0;

				xlApp = new Microsoft.Office.Interop.Excel.Application();
				xlWorkBook = xlApp.Workbooks.Open(openFileDialog1.FileName, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
				xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

				dtAdHoc = new System.Data.DataTable();

				rnge = xlWorkSheet.UsedRange;
				DataRow dr = dtAdHoc.NewRow();
				ClsImportActualColumn column = new ClsImportActualColumn("");
				for (rCnt = 1; rCnt <= rnge.Rows.Count; rCnt++)
				{
					for (cCnt = 1; cCnt <= rnge.Columns.Count; cCnt++)
					{
						str = ClsConvert.ToString((rnge.Cells[rCnt, cCnt] as Range).Value2);
						decimal? dec = null;
						if (rCnt == 1)
						{
							// The first row is the column header row
							CreateColumn(dtAdHoc, str, rCnt);
							continue;
						}
						else
						{
							string s = dr.Table.Columns[cCnt - 1].ColumnName;
							column = new ClsImportActualColumn(s);
						}
						if (cCnt == 1 && rCnt > 1)
						{
							dtAdHoc.Rows.Add(dr);
							dr = dtAdHoc.NewRow();
						}

						// See if this is a merged column.
						// If not, and it's null, change it to zero.
						Microsoft.Office.Interop.Excel.Range r = rnge.Cells[rCnt, cCnt];
						Microsoft.Office.Interop.Excel.Range rMergeInfo = r.MergeArea;
						int iMergeCount = rMergeInfo.Cells.Count;
						if (str == null && iMergeCount == 1)
						{
							str = "0";
						}
						// Handled a nulled-out merge column
						//  -> Just grab the value from the row above.
						if (str == null && iMergeCount > 1)
						{
							if (column.IsChargeColumn)
							{
								dec = ClsConvert.ToDecimalNullable(dtAdHoc.Rows[rCnt - 2][cCnt - 1].ToString());
								dr[cCnt - 1] = dec;
							}
							else
							{
								dr[cCnt - 1] = dtAdHoc.Rows[rCnt - 2][cCnt -1].ToString();
							}
						}
						else
						{
							dec = column.NumericValue(str);
							if (dec == null)
								dr[cCnt - 1] = str;
							else
								dr[cCnt - 1] = dec / iMergeCount;
						}
					}
				}
				dtAdHoc.Rows.Add(dr);

				dtAdHoc.Rows[0].Delete();
				grdAdHoc.DataSource = dtAdHoc;

				// Cleanup Excel
				xlWorkBook.Close(true, null, null);
				xlApp.Quit();
				releaseObject(xlWorkSheet);
				releaseObject(xlWorkBook);
				releaseObject(xlApp);

				ValidateData();

				tsSave.Enabled = true;
				if (bInvalidColumn)
				{
					Program.Show("At least one column name is invalid, and the spreadsheet cannot be imported.");
					tsSave.Enabled = false;
				}
				if (bInvalidLhaul)
				{
					Program.Show("At least one of the linehaul charge types is invalid, and the spreadsheet cannot be imported.");
					tsSave.Enabled = false;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void ValidateData()
		{
			//
			// Go through datatable looking for problems
			//
			bool bValid = true;
			int rIndx = 0;
			int cIndx = 0;
			string s = "";
			foreach (DataRow dr in dtAdHoc.Rows)
			{
				bValid = true;
				cIndx = 0;
				foreach (object item in dr.ItemArray)
				{
					if (item is string)
					{
						s = (string)item;
						bValid = ValidateString(s, cIndx);
					}

					if (!bValid)
					{
						bInvalidLhaul = true;
						dr.ItemArray[cIndx] =  s + "***";
					}
					cIndx++;
				}
				rIndx++;
			}
		}

		private bool ValidateString(string s, int cx)
		{
			string sColumn = dtAdHoc.Columns[cx].ColumnName.ToUpper();
			if (sColumn == ClsImportActualColumn.HeaderCodes.LHaulType)
			{
				ClsImportActualColumn col = new ClsImportActualColumn(sColumn);
				if (!col.IsChargeColumn)
				{
					return false;
				}
			}
			return true;
		}

		private void CreateColumn(System.Data.DataTable dt, string sCol, int rCnt)
		{
			
			ClsImportActualColumn col = new ClsImportActualColumn(sCol);
			bool bIsChargeColumn = col.IsChargeColumn;
			bool bIsValidColumn = col.IsValidColumn;
			if (!bIsValidColumn)
			{
				sCol = "*" + sCol + "*";
			}
			if (bIsChargeColumn || sCol.ToUpper() == ClsImportActualColumn.HeaderCodes.LHaul)
				dt.Columns.Add(sCol, typeof(decimal));
			else
				dt.Columns.Add(sCol);
			grdAdHoc.Tables[0].Columns.Add(sCol);
			if (bIsChargeColumn || col.sColumn.ToUpper() == ClsImportActualColumn.HeaderCodes.LHaul)
			{
				grdAdHoc.Tables[0].Columns[sCol].AggregateFunction
					= AggregateFunction.Sum;
				grdAdHoc.Tables[0].Columns[sCol].HeaderAlignment
					= TextAlignment.Far;
				grdAdHoc.Tables[0].Columns[sCol].TextAlignment
					= TextAlignment.Far;
			}

			if (!bIsValidColumn)
			{
				bInvalidColumn = true;
				grdAdHoc.Tables[0].Columns[sCol].HeaderStyle.ForeColor
					= System.Drawing.Color.Red;
			}

		}

		private void releaseObject(object obj)
		{
			try
			{
				System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
				obj = null;
			}
			catch (Exception ex)
			{
				obj = null;
				MessageBox.Show("Unable to release the Object " + ex.ToString());
			}
			finally
			{
				GC.Collect();
			}
		}

		#endregion

		#region Events
		private void tsSave_Click(object sender, EventArgs e)
		{
			SaveFile();
		}

		private void btnExcel_Click(object sender, EventArgs e)
		{

			ReadExcel();
			//ReadUsingJet();
		}

		#endregion
	}

	
}
