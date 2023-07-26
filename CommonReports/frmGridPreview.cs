using System;
using System.Data;
using System.Windows.Forms;
using CS2010.Common;
using CS2010.CommonWinCtrls;
using CrystalDecisions.CrystalReports.Engine;
using Janus.Windows.GridEX;

namespace CS2010.CommonReports
{
	public partial class frmGridPreview : Form
	{
		#region Constants

		private int AutoResizeRowLimit = 50000;

		#endregion		// #region Constants

		#region Fields

		private bool LayoutApplied;
		private ClsReportObject theReport;
		#endregion		// #region Fields

		#region Constructors

		public frmGridPreview()
		{
			InitializeComponent();

			tbbSaveLayout.Visible = ClsEnvironment.IsDeveloper;

			try
			{
				foreach (Form f in Application.OpenForms)
				{
					if (f.IsMdiContainer)
					{
						MdiParent = f;
						break;
					}
				}
				WindowState = FormWindowState.Maximized;
			}
			catch (Exception ex)
			{
				Display.ShowError("Grid Preview", ex);
			}
		}
		#endregion		// #region Constructors

		#region Public Methods

		public void ShowData(ClsReportObject r)
		{
			try
			{
				theReport = r;
				Show();
				Activate();
			}
			catch( Exception ex )
			{
				Display.ShowError("Report", ex, null, r.ToString());
			}
		}
		#endregion		// #region Public Methods

		#region Helper Methods

		private void PreviewFormLoad()
		{
			try
			{
				AttemptGridLayout();

				FormLayout2();

				grdView.TableHeaders = InheritableBoolean.True;
				if( theReport.IsTableCaptionVisible )
				{
					grdView.RootTable.Caption = string.Format("Rows: {0}, {1}", grdView.RecordCount,
						string.IsNullOrEmpty(theReport.Parameters_Dsc) ? "ALL" : theReport.Parameters_Dsc);
				}
				if  (theReport.GetGroups() != null)
				{
					grdView.GroupMode = GroupMode.Collapsed;
				}
				Text = theReport.Title;
			}
			catch( Exception ex )
			{
				Display.ShowError("Report", ex, null, theReport.ToString());
			}
		}

		private void AttemptGridLayout()
		{
			try
			{
				if( string.IsNullOrEmpty(theReport.Grid_Layout_Key) ||
					!grdView.Layouts.Contains(theReport.Grid_Layout_Key) ) return;

				GridEXLayout layout = grdView.Layouts[theReport.Grid_Layout_Key];
				if( layout != null )
				{
					grdView.CurrentLayout = layout;
					WindowHelper.InitAllGrids(this);
					LayoutApplied = true;
				}
				else
					grdView.ClearStructure();
				grdView.DataSource = theReport.Report_Data;
			}
			catch( Exception ex )
			{
				Display.ShowError("Report", ex, null, theReport.ToString());
			}
		}
/*
		private void FormLayout()
		{
			try
			{
				if( LayoutApplied ) return;

				grdView.DataSource = theReport.Report_Data;
				grdView.RetrieveStructure();
				grdView.AllowRemoveColumns = InheritableBoolean.True;
				grdView.HideColumnsWhenGrouped = theReport.HideColumnsWhenGrouped ?
					InheritableBoolean.True : InheritableBoolean.False;

				if( theReport.GroupColumns != null )
				{
					grdView.GroupMode = GroupMode.Expanded;

					int collapseCount = theReport.CollapseCount;
					foreach( string s in theReport.GroupColumns )
					{
						GridEXColumn col = grdView.RootTable.Columns[s];
						if( grdView.RootTable.Columns.Contains(s) )
							grdView.RootTable.Groups.Add(col);

						if( grdView.RootTable.GroupHeaderTotals.Count <= 0 )
						{
							GridEXGroupHeaderTotal hdr =
								new GridEXGroupHeaderTotal(col, AggregateFunction.Count);
							hdr.Key = col.Key + "Header";
							hdr.TotalFormatString = "Count: {0}";
							grdView.RootTable.GroupHeaderTotals.Add(hdr);
						}
					}

					for( int i = grdView.RootTable.Groups.Count - 1; i >= 0 && collapseCount > 0;
						i--, collapseCount-- ) grdView.RootTable.Groups[i].Collapse();
				}

				ParseColumns();

				if( theReport.Report_Data.Rows.Count <= AutoResizeRowLimit )
					grdView.AutoSizeColumns();
				grdView.AllowEdit = InheritableBoolean.False;
				grdView.FilterMode = FilterMode.Automatic;
			}
			catch( Exception ex )
			{
				Display.ShowError("Report", ex, null, theReport.ToString());
			}
		}

		private void ParseColumns()
		{
			try
			{
				for( int i = grdView.RootTable.Columns.Count - 1; i >= 0; i-- )
				{
					GridEXColumn col = grdView.RootTable.Columns[i];
					if( ExcludeColumn(col) ) continue;

					DataColumn dc = theReport.Report_Data.Columns[col.Key];
					if( dc != null ) SetDataType(col, dc);

					SetColumnTotal(col);

					SetLink(col);
				}
			}
			catch( Exception ex )
			{
				Display.ShowError("Report", ex, null, theReport.ToString());
			}
		}

		private bool ExcludeColumn(GridEXColumn col)
		{
			try
			{
				if( !theReport.IsExcluded(col.Key) ) return false;

				grdView.RootTable.Columns.Remove(col);
				return true;
			}
			catch( Exception ex )
			{
				return Display.ShowError("Report", ex, null, theReport.ToString());
			}
		}

		private void SetDataType(GridEXColumn col, DataColumn dc)
		{
			try
			{
				switch( Type.GetTypeCode(dc.DataType) )
				{
					case TypeCode.DateTime:
						col.FormatString = ClsConfig.DateFormat;
						col.DefaultGroupInterval = GroupInterval.Date;
						break;

					case TypeCode.Single:
					case TypeCode.Double:
					case TypeCode.Decimal:
						col.TextAlignment = TextAlignment.Far;
						col.HeaderAlignment = TextAlignment.Center;
						if( IsAmount(col.Key) )
							col.FormatString = "c";
						else if( IsCount(col.Key) || IsInt(col.Key) )
							col.FormatString = "0";
						else
							col.FormatString = "0.00";
						break;

					case TypeCode.Byte:
					case TypeCode.SByte:
					case TypeCode.Int16:
					case TypeCode.Int32:
					case TypeCode.Int64:
					case TypeCode.UInt16:
					case TypeCode.UInt32:
					case TypeCode.UInt64:
						col.TextAlignment = TextAlignment.Far;
						col.HeaderAlignment = TextAlignment.Center;
						break;

					case TypeCode.Boolean:
					case TypeCode.Char:
					case TypeCode.DBNull:
					case TypeCode.Empty:
					case TypeCode.Object:
					case TypeCode.String:
					default:
						break;
				}
			}
			catch( Exception ex )
			{
				Display.ShowError("Report", ex, null, theReport.ToString());
			}
		}

		private void SetColumnTotal(GridEXColumn col)
		{
			try
			{
				string colName = col.Key;
				if( !IsAmount(colName) && !IsTotal(colName) ) return;

				if( IsAmount(colName) )
				{
					col.TotalFormatString = "c";
					col.AggregateFunction = AggregateFunction.Sum;
				}
				else
				{
					col.AggregateFunction = GetAggregateType(colName);
					col.TotalFormatString = col.FormatString;
				}

				if( grdView.RootTable.Groups.Count > 0 )
				{
					grdView.GroupTotals = GroupTotals.Always;
					grdView.TotalRow = InheritableBoolean.True;
					grdView.TotalRowPosition = TotalRowPosition.BottomFixed;
				}
			}
			catch( Exception ex )
			{
				Display.ShowError("Report", ex, null, theReport.ToString());
			}
		}

		private AggregateFunction GetAggregateType(string colName)
		{
			AggregateFunction result = AggregateFunction.Sum;
			try
			{
				string type = theReport.ColumnTotals.ContainsKey(colName)
					? theReport.ColumnTotals[colName] : null;
				result = (AggregateFunction)Enum.Parse(typeof(AggregateFunction), type, true);
			}
			catch( Exception ex )
			{
				Display.ShowError("Report", ex, null, theReport.ToString());
				result = AggregateFunction.Sum;
			}
			return result;
		}

		private void SetLink(GridEXColumn col)
		{
			try
			{
				string colName = col.Key;
				ViewMethod meth = IsNo(colName);

				if( meth != null )
				{
					//col.ColumnType = ColumnType.Link;
					col.Tag = meth;
				}
			}
			catch( Exception ex )
			{
				Display.ShowError("Report", ex, null, theReport.ToString());
			}
		}

		private bool IsAmount(string colName)
		{
			try
			{
				string tmp = string.IsNullOrEmpty(colName) ? null : colName.Trim();
				if( string.IsNullOrEmpty(tmp) ) return false;

				return tmp.EndsWith("Amt", StringComparison.InvariantCultureIgnoreCase) ||
					tmp.EndsWith("Amount", StringComparison.InvariantCultureIgnoreCase);
			}
			catch( Exception ex )
			{
				return Display.ShowError("Report", ex, null, theReport.ToString());
			}
		}

		private bool IsTotal(string colName)
		{
			try
			{
				string tmp = string.IsNullOrEmpty(colName) ? null : colName.Trim();
				if( string.IsNullOrEmpty(tmp) ) return false;

				return theReport.ColumnTotals != null && theReport.ColumnTotals.ContainsKey(tmp);
			}
			catch( Exception ex )
			{
				return Display.ShowError("Report", ex, null, theReport.ToString());
			}
		}

		private bool IsCount(string colName)
		{
			try
			{
				string tmp = string.IsNullOrEmpty(colName) ? null : colName.Trim();
				if( string.IsNullOrEmpty(tmp) ) return false;

				return tmp.EndsWith("Cnt", StringComparison.InvariantCultureIgnoreCase) ||
					tmp.EndsWith("Count", StringComparison.InvariantCultureIgnoreCase);
			}
			catch( Exception ex )
			{
				return Display.ShowError("Report", ex, null, theReport.ToString());
			}
		}

		private bool IsInt(string colName)
		{
			try
			{
				string tmp = string.IsNullOrEmpty(colName) ? null : colName.Trim();
				if( string.IsNullOrEmpty(tmp) ) return false;

				bool exists = false;
				if( theReport.IntColumns != null )
				{
					exists = theReport.IntColumns.Exists(delegate(string s)
					{ return string.Compare(s, tmp, true) == 0; });
				}
				return exists;
			}
			catch( Exception ex )
			{
				return Display.ShowError("Report", ex, null, theReport.ToString());
			}
		}

		private ViewMethod IsNo(string colName)
		{
			try
			{
				string tmp = string.IsNullOrEmpty(colName) ? null : colName.Trim();
				if( string.IsNullOrEmpty(tmp) ) return null;

				ViewMethod meth = null;
				if( tmp.EndsWith("Order_No", StringComparison.InvariantCultureIgnoreCase) ||
					tmp.EndsWith("Order_#", StringComparison.InvariantCultureIgnoreCase) )
					meth = ViewOrder;
				else if( tmp.EndsWith("Booking_No", StringComparison.InvariantCultureIgnoreCase) ||
					tmp.EndsWith("Booking_#", StringComparison.InvariantCultureIgnoreCase) )
					meth = ViewBooking;
				else if( tmp.EndsWith("Invoice_No", StringComparison.InvariantCultureIgnoreCase) |
					tmp.EndsWith("Invoice_#", StringComparison.InvariantCultureIgnoreCase) )
					meth = ViewArInvoice;
				else if( tmp.EndsWith("TBol_No", StringComparison.InvariantCultureIgnoreCase) ||
					tmp.EndsWith("TBol_#", StringComparison.InvariantCultureIgnoreCase) )
					meth = ViewTruckBOL;
				else if( tmp.EndsWith("OBol_No", StringComparison.InvariantCultureIgnoreCase) ||
					tmp.EndsWith("OBol_#", StringComparison.InvariantCultureIgnoreCase) )
					meth = ViewOceanBOL;

				return meth;
			}
			catch( Exception ex )
			{
				Display.ShowError("Report", ex, null, theReport.ToString());
				return null;
			}
		}
*/
		private void SetDataType(GridEXColumn col, DataColumn dc)
		{
			try
			{
				switch( Type.GetTypeCode(dc.DataType) )
				{
					case TypeCode.DateTime:
						col.FormatString = ClsConfig.DateFormat;
						col.DefaultGroupInterval = GroupInterval.Date;
						break;

					case TypeCode.Single:
					case TypeCode.Double:
					case TypeCode.Decimal:
						col.TextAlignment = TextAlignment.Far;
						col.HeaderAlignment = TextAlignment.Center;
						if( IsAmount(col.Key) )
							col.FormatString = "c";
						else if( IsCount(col.Key) )//|| IsInt(col.Key) )
							col.FormatString = "0";
						else
							col.FormatString = "0.00";
						break;

					case TypeCode.Byte:
					case TypeCode.SByte:
					case TypeCode.Int16:
					case TypeCode.Int32:
					case TypeCode.Int64:
					case TypeCode.UInt16:
					case TypeCode.UInt32:
					case TypeCode.UInt64:
						col.TextAlignment = TextAlignment.Far;
						col.HeaderAlignment = TextAlignment.Center;
						break;

					case TypeCode.Boolean:
					case TypeCode.Char:
					case TypeCode.DBNull:
					case TypeCode.Empty:
					case TypeCode.Object:
					case TypeCode.String:
					default:
						break;
				}
			}
			catch( Exception ex )
			{
				Display.ShowError("Report", ex, null, theReport.ToString());
			}
		}

		private bool IsAmount(string colName)
		{
			try
			{
				string tmp = string.IsNullOrEmpty(colName) ? null : colName.Trim();
				if( string.IsNullOrEmpty(tmp) ) return false;

				return tmp.EndsWith("Amt", StringComparison.InvariantCultureIgnoreCase) ||
					tmp.EndsWith("Amount", StringComparison.InvariantCultureIgnoreCase);
			}
			catch( Exception ex )
			{
				return Display.ShowError("Report", ex, null, theReport.ToString());
			}
		}

		private bool IsCount(string colName)
		{
			try
			{
				string tmp = string.IsNullOrEmpty(colName) ? null : colName.Trim();
				if( string.IsNullOrEmpty(tmp) ) return false;

				return tmp.EndsWith("Cnt", StringComparison.InvariantCultureIgnoreCase) ||
					tmp.EndsWith("Count", StringComparison.InvariantCultureIgnoreCase);
			}
			catch( Exception ex )
			{
				return Display.ShowError("Report", ex, null, theReport.ToString());
			}
		}
		#endregion		// #region Helper Methods

		#region Link to View Window Section
		public void SetLinkHandlers(EventHandler e)
		{

		}
		
		#endregion		// #region Link to View Window Section

		#region Menu/Toolbar Actions

		private void DisplayReport(bool preview)
		{
			DataTable dtHold = theReport.Report_Data;
			try
			{
				string name = string.IsNullOrEmpty(theReport.Crystal_File_Nm)
					? null : theReport.Crystal_File_Nm.Trim();
				if( string.IsNullOrEmpty(name) || name.ToUpper().Contains("N/A") )
				{
					bool landscape = Display.Ask("Confirm", "Use Landscape (No for portrait)?");
					if( preview )
						grdView.Preview(landscape, true);
					else
						grdView.Print(landscape, true, false);
				}
				else
				{
					theReport.Report_Data = grdView.GetDataTableSource();
					ClsReportHandler.PresentReport(theReport, preview);
				}
			}
			catch( Exception ex )
			{
				Display.ShowError("Report", ex, null, theReport.ToString());
			}
			finally
			{
				theReport.Report_Data = dtHold;
			}
		}

		private void SaveLayout()
		{
			try
			{
				using( SaveFileDialog f = new SaveFileDialog() )
				{
					f.AddExtension = true;
					f.CheckPathExists = true;
					f.Filter = "Grid Layout Files (*.gxl)|*.gxl|All Files (*.*)|*.*";
					f.FilterIndex = 1;
					f.DefaultExt = "gxl";
					f.OverwritePrompt = true;
					f.Title = "Save Current Grid Layout";
					if( f.ShowDialog() != DialogResult.OK ) return;

					using( System.IO.FileStream fs = System.IO.File.Create(f.FileName) )
						grdView.SaveLayoutFile(fs);
				}
			}
			catch( Exception ex )
			{
				Display.ShowError("Report", ex, null, theReport.ToString());
			}
		}
		#endregion		// #region Menu/Toolbar Actions

		#region Event Handlers

		private void frmReportPreview_Load(object sender, EventArgs e)
		{
			PreviewFormLoad();
		}

		private void frmReportPreview_FormClosed(object sender, FormClosedEventArgs e)
		{
			try
			{
				if( grdView != null )
				{
					grdView.DataSource = null;
					grdView.Dispose();
				}

				if( theReport != null && theReport.Report_Data != null )
				{
					theReport.Report_Data.Clear();
					theReport.Report_Data.Dispose();
					theReport.Report_Data = null;
				}

				Dispose();
			}
			catch( Exception ex )
			{
				Display.ShowError("Report", ex, null, theReport.ToString());
			}
		}

		private void frmReportPreview_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
			}
			catch( Exception ex )
			{
				Display.ShowError("Report", ex, null, theReport.ToString());
			}
		}

		private void tbbClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void tbbPrint_Click(object sender, EventArgs e)
		{
			DisplayReport(false);
		}

		private void tbbPreview_Click(object sender, EventArgs e)
		{
			DisplayReport(true);
		}

		private void tbbSaveLayout_Click(object sender, EventArgs e)
		{
			SaveLayout();
		}
		#endregion		// #region Event Handlers

		private void FormLayout2()
		{
			try
			{
				if( LayoutApplied ) return;

				grdView.DataSource = theReport.Report_Data;
				grdView.RetrieveStructure();
				grdView.AllowRemoveColumns = InheritableBoolean.True;
				grdView.GroupMode = GroupMode.Default;

				foreach( string colName in theReport.GetGroups() )
				{
					//if( grdView.GroupMode != GroupMode.Expanded )
					//    grdView.GroupMode = GroupMode.Expanded;

					GridEXColumn col = grdView.RootTable.Columns.Contains(colName)
						? grdView.RootTable.Columns[colName] : null;
					if( col == null ) continue;

					GridEXGroup grp = grdView.RootTable.Groups.Add(col);
					ClsReportColumn ca = theReport[colName];
					if (ca.CollapseWhenGrouped)
						grp.Collapse();
					else
						grp.Expand();

					if( grdView.RootTable.GroupHeaderTotals.Count <= 0 )
					{
						GridEXGroupHeaderTotal hdr =
							new GridEXGroupHeaderTotal(col, AggregateFunction.Count);
						hdr.Key = col.Key + "Header";
						hdr.TotalFormatString = "Count: {0}";
						grdView.RootTable.GroupHeaderTotals.Add(hdr);
					}
				}

				ParseColumns2();

				ApplyFormatConditions();

				if( theReport.Report_Data.Rows.Count <= AutoResizeRowLimit )
					grdView.AutoSizeColumns();
				grdView.AllowEdit = InheritableBoolean.False;
				grdView.FilterMode = FilterMode.Automatic;
				grdView.FilterRowButtonStyle = FilterRowButtonStyle.ConditionOperatorDropDown;
				grdView.FilterRowUpdateMode = FilterRowUpdateMode.WhenValueChanges;
			}
			catch( Exception ex )
			{
				Display.ShowError("Report", ex, null, theReport.ToString());
			}
		}

		private void ApplyFormatConditions()
		{
			try
			{
				ClsFormatCondition[] fcs = theReport.GetConditions();
				if (fcs == null || fcs.Length <= 0) return;

				foreach (ClsFormatCondition fc in fcs)
				{
					GridEXColumn lcol = grdView.RootTable.Columns[fc.LeftColumn];
					if (lcol == null ) continue;

					object rcompare = null;
					GridEXColumn rcol = null;
					if (!fc.UseValue)
					{
						rcol = grdView.RootTable.Columns[fc.RightColumn];
						if (rcol == null) continue;
						rcompare = rcol;
					}
					else
						rcompare = fc.RightValue;

					ConditionOperator op;
					if (!Enum.TryParse(fc.ConditionalOperator, out op))
						op = ConditionOperator.NotEqual;

					GridEXFormatCondition gfc = new GridEXFormatCondition();
					gfc.TargetColumn = lcol;

					if (fc.IsBold)
						gfc.FormatStyle.FontBold = TriState.True;
					if (fc.IsItalic)
						gfc.FormatStyle.FontItalic = TriState.True;
					if (fc.BackColor != null)
						gfc.FormatStyle.BackColor = fc.BackColor.Value;
					if (fc.ForeColor != null)
						gfc.FormatStyle.ForeColor = fc.ForeColor.Value;

					gfc.FilterCondition = new GridEXFilterCondition(lcol, op, rcompare);

					grdView.RootTable.FormatConditions.Add(gfc);

					if (!fc.UseValue && fc.ApplyToRightCol)
					{
						gfc = new GridEXFormatCondition();
						gfc.TargetColumn = rcol;

						if (fc.IsBold)
							gfc.FormatStyle.FontBold = TriState.True;
						if (fc.IsItalic)
							gfc.FormatStyle.FontItalic = TriState.True;
						if (fc.BackColor != null)
							gfc.FormatStyle.BackColor = fc.BackColor.Value;
						if (fc.ForeColor != null)
							gfc.FormatStyle.ForeColor = fc.ForeColor.Value;

						gfc.FilterCondition = new GridEXFilterCondition(lcol, op, rcompare);
						grdView.RootTable.FormatConditions.Add(gfc);
					}
				}
			}
			catch (Exception ex)
			{
				Display.ShowError("Report", ex);
			}
		}

		private void ParseColumns2()
		{
			try
			{
				//foreach( ClsReportColumn ca in theReport.ReportOptions )
				//{
				//    if( ca.ExcludeColumn ) continue;
				//}

				//ClsReportOptions ReportOptions = new ClsReportOptions();// theReport.ReportOptions;
				for( int i = grdView.RootTable.Columns.Count - 1; i >= 0; i-- )
				{
					GridEXColumn col = grdView.RootTable.Columns[i];

					ClsReportColumn ca = theReport[col.Key];
					if( ca == null ) continue;

					if( ca.ExcludeColumn )
					{
						grdView.RootTable.Columns.Remove(col);
						continue;
					}

					DataColumn dc = theReport.Report_Data.Columns[col.Key];
					if( dc != null ) SetDataType(col, dc);

					col.HideWhenGrouped = GetJanusBool(ca.HideWhenGrouped);
					col.Visible = !ca.HideColumn;

					col.FormatString = ca.FormatString;

					if( !string.IsNullOrEmpty(ca.AggregateType) )
					{
						col.AggregateFunction = GetAggregateType2(ca.AggregateType);
						col.TotalFormatString = col.FormatString;
					}

					if( !string.IsNullOrEmpty(ca.TextAlignment) )
						col.TextAlignment = GetTextAlignment(ca.TextAlignment);

					if( !string.IsNullOrEmpty(ca.HeaderAlignment) )
						col.HeaderAlignment = GetTextAlignment(ca.HeaderAlignment);

					if( !string.IsNullOrEmpty(ca.GroupInterval) )
						col.DefaultGroupInterval = GetGroupInterval(ca.GroupInterval);

					if( !string.IsNullOrEmpty(ca.ColumnCaption) )
						col.Caption = ca.ColumnCaption;

					col.NullText = ca.NullText;

					col.ColumnType = GetColumnType(ca.ColumnType);
					if (col.ColumnType == ColumnType.CheckBox)
					{
						col.CheckBoxFalseValue = ca.CheckboxFalseValue;
						col.CheckBoxTrueValue = ca.CheckboxTrueValue;
					}

					//SetLink(col);
				}

				if( grdView.RootTable.Groups.Count > 0 )
				{
					grdView.GroupTotals = GroupTotals.Always;
					grdView.TotalRow = InheritableBoolean.True;
					grdView.TotalRowPosition = TotalRowPosition.BottomFixed;
				}
			}
			catch( Exception ex )
			{
				Display.ShowError("Report", ex, null, theReport.ToString());
			}
		}

		private AggregateFunction GetAggregateType2(string type)
		{
			AggregateFunction result = AggregateFunction.Sum;
			try
			{
				result = (AggregateFunction)Enum.Parse(typeof(AggregateFunction), type, true);
			}
			catch( Exception ex )
			{
				Display.ShowError("Report", ex, null, theReport.ToString());
				result = AggregateFunction.Sum;
			}
			return result;
		}

		private TextAlignment GetTextAlignment(string type)
		{
			TextAlignment result = TextAlignment.Empty;
			try
			{
				result = (TextAlignment)Enum.Parse(typeof(TextAlignment), type, true);
			}
			catch( Exception ex )
			{
				Display.ShowError("Report", ex, null, theReport.ToString());
				result = TextAlignment.Empty;
			}
			return result;
		}

		private ColumnType GetColumnType(string type)
		{
			ColumnType result = ColumnType.Text;
			try
			{
				result = (ColumnType)Enum.Parse(typeof(ColumnType), type, true);
			}
			catch (Exception ex)
			{
				Display.ShowError("Report", ex, null, theReport.ToString());
				result = ColumnType.Text;
			}
			return result;
		}
		private GroupInterval GetGroupInterval(string interval)
		{
			GroupInterval result = GroupInterval.Text;
			try
			{
				result = (GroupInterval)Enum.Parse(typeof(GroupInterval), interval, true);
			}
			catch( Exception ex )
			{
				Display.ShowError("Report", ex, null, theReport.ToString());
				result = GroupInterval.Text;
			}
			return result;
		}

		private InheritableBoolean GetJanusBool(bool? value)
		{
			try
			{
				if( value == null ) return InheritableBoolean.Default;
				return value.Value ? InheritableBoolean.True : InheritableBoolean.False;
			}
			catch( Exception ex )
			{
				Display.ShowError("Report", ex, null, theReport.ToString());
				return InheritableBoolean.Default;
			}
		}

		private void grdView_LinkClicked(object sender, ColumnActionEventArgs e)
		{
			if (theReport.LinkHandler != null)
			{
				ucGridEx gv = sender as ucGridEx;
				theReport.LinkHandler.HandleLink(grdView.CurrentRow, e.Column.Key);
			}
		}
	}
}