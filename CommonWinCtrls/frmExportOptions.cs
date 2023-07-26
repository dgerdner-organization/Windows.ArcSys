using System;
using System.Windows.Forms;
using CS2010.Common;
using Janus.Windows.GridEX;

namespace CS2010.CommonWinCtrls
{
	public partial class frmExportOptions : Form
	{
		#region Fields

		private GridExportOptions theOptions;

		#endregion		// #region Fields

		#region Constructors

		public frmExportOptions()
		{
			InitializeComponent();
		}
		#endregion		// #region Constructors

		#region Public Methods

		public bool GetExportOptions(GridExportOptions someOptions)
		{
			try
			{
				theOptions = new GridExportOptions(someOptions);
				rdoAllRows.Checked = rdoCheckedRows.Checked = false;
				rdoExcel.Checked = rdoCSV.Checked = rdoDelimited.Checked = false;
				txtDelim.Text = null;
				txtDelim.Enabled = false;

				if( theOptions.ExportType == GridExportType.Delimited )
				{
					rdoDelimited.Checked = true;
					txtDelim.Text = theOptions.Delimiter.ToString();
					txtDelim.Enabled = true;
				}
				else if( theOptions.ExportType == GridExportType.CSV )
					rdoCSV.Checked = true;
				else
					rdoExcel.Checked = true;

				if( theOptions.RowType == ExportMode.CheckedRows )
					rdoCheckedRows.Checked = true;
				else
					rdoAllRows.Checked = true;

				chkIncludeChild.Checked = theOptions.IncludeChildTables;
				chkIncludeColHeaders.Checked = theOptions.IncludeColumnHeaders;
				chkIncludeSelectorColumn.Checked = theOptions.IncludeSelectorRow;

				if( ShowDialog() != DialogResult.OK ) return false;

				someOptions.CopyFrom(theOptions);
				return true;
			}
			catch( Exception ex )
			{
				return Display.ShowError("Export", ex);
			}
		}
		#endregion		// #region Public Methods

		#region Event Handlers

		private void rdoType_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				txtDelim.Enabled = rdoDelimited.Checked;
				if( !rdoDelimited.Checked ) txtDelim.Text = null;
			}
			catch( Exception ex )
			{
				Display.ShowError("Export", ex);
			}
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			try
			{
				theOptions.Delimiter = (char)0;
				if( rdoDelimited.Checked )
				{
					theOptions.ExportType = GridExportType.Delimited;
					string s = txtDelim.Text.Trim();
					if( s.Length != 1 )
					{
						Display.ShowError("Export", "A single character must be specified when the delimited option is chosen");
						return;
					}
					theOptions.Delimiter = s[0];
				}
				else if( rdoCSV.Checked )
					theOptions.ExportType = GridExportType.CSV;
				else if( rdoExcel.Checked )
					theOptions.ExportType = GridExportType.Excel;
				else
				{
					Display.ShowError("Export", "An export type must be specified");
					return;
				}

				if( rdoCheckedRows.Checked )
					theOptions.RowType = ExportMode.CheckedRows;
				else if( rdoAllRows.Checked )
					theOptions.RowType = ExportMode.AllRows;
				else
				{
					Display.ShowError("Export", "A value must be selected for the rows to export");
					return;
				}

				theOptions.IncludeChildTables = chkIncludeChild.Checked;
				theOptions.IncludeColumnHeaders = chkIncludeColHeaders.Checked;
				theOptions.IncludeSelectorRow = chkIncludeSelectorColumn.Checked;

				DialogResult = DialogResult.OK;
			}
			catch( Exception ex )
			{
				Display.ShowError("Export", ex);
			}
		}
		#endregion		// #region Event Handlers
	}

	#region Grid Export Options

	public enum GridExportType { Excel, CSV, Delimited }

	public class GridExportOptions
	{
		#region Fields

		public GridExportType ExportType;
		public ExportMode RowType;

		public bool IncludeChildTables;
		public bool IncludeSelectorRow;
		public bool IncludeColumnHeaders;

		public char Delimiter;

		#endregion		// #region Fields

		#region Constructors/Initialization

		public GridExportOptions()
		{
			ExportType = GridExportType.Excel;
			RowType = ExportMode.AllRows;

			IncludeChildTables = true;
			IncludeSelectorRow = false;
			IncludeColumnHeaders = true;

			Delimiter = '|';
		}

		public GridExportOptions(GridExportOptions src)
		{
			CopyFrom(src);
		}

		public void CopyFrom(GridExportOptions src)
		{
			RowType = src.RowType;
			IncludeChildTables = src.IncludeChildTables;
			IncludeSelectorRow = src.IncludeSelectorRow;
			IncludeColumnHeaders = src.IncludeColumnHeaders;
			ExportType = src.ExportType;
			Delimiter = src.Delimiter;
		}
		#endregion		// #region Constructors/Initialization
	}
	#endregion		// #region Grid Export Options
}