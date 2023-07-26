using System;
using System.IO;
using System.Data;
using System.Text;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;
using System.Collections.Generic;
using CS2010.Common;
using CS2010.CommonWinCtrls;
using ASL.ARC.EDISQLTools;
using Janus.Windows.GridEX;
using CS2010.ArcSys.Business;
using CS2010.CommonSecurity;

namespace CS2010.ArcSys.Win
{
	public partial class frmScanFilesEDI : Form
	{
		#region Fields

		private static frmScanFilesEDI ProcessWindow;

		private List<string> Directories;
		private List<string> AvailableFiles;

		private List<ScanLine> GridData;
		private Dictionary<string, string> FileData;

		private string[] mainDelim = { "~ST*" };
		private string[] altDelim = { "TYPE:" };
		private string[] Delim303 = { "ST*" };

		private int iConfirmCounter = 0;

		private ScanLine currentLine
		{
			get
			{
				GridEXRow drow = grdScan.GetRow();
				ScanLine line = (drow != null) ? drow.DataRow as ScanLine : null;
				return line;
			}
		}

		#endregion		// #region Fields

		#region Constructors/Initialization/Entry/Cleanup

		public frmScanFilesEDI()
		{
			InitializeComponent();
		}

		public static frmScanFilesEDI ShowWindow()
		{
			try
			{
				if( ProcessWindow == null )
				{
					ProcessWindow = new frmScanFilesEDI();
					ProcessWindow.InitWindow();
				}

				ProcessWindow.Activate();
				ProcessWindow.Show();
				ProcessWindow.WindowState = FormWindowState.Maximized;
				ClsSecurityMaster.SetSecurity(ProcessWindow);
				return ProcessWindow;
			}
			catch( Exception ex )
			{
				Program.ShowError(ex);
				return null;
			}
		}

		private void InitWindow()
		{
			try
			{
				MdiParent = Program.MainWindow;

				Directories = new List<string>();
				AvailableFiles = new List<string>();

				GridData = new List<ScanLine>();
				FileData = new Dictionary<string, string>();

				InitiateScan();
			}
			catch( Exception ex )
			{
				Program.ShowError(ex);
			}
		}

		private void UpdateDisplay()
		{
			try
			{
				grdScan.DataSource = null;
				grdScan.RemoveFilters();

				grdScan.DataSource = GridData;

				grdScan.RootTable.Caption = string.Format("{0} Row(s), {1} File(s)",
					GridData.Count, FileData.Count);

				grdScan.GroupMode = GroupMode.Collapsed;
			}
			catch( Exception ex )
			{
				Program.ShowError(ex);
			}
		}

		private void frmScanFilesEDI_FormClosed(object sender, FormClosedEventArgs e)
		{
			ProcessWindow = null;
		}
		#endregion		// #region Constructors/Initialization/Entry/Cleanup

		#region Scanning Directories/Parsing Files

		private void tbbScan_Click(object sender, EventArgs e)
		{
			InitiateScan();
		}

		private void tbbShowArchive_Click(object sender, EventArgs e)
		{
			try
			{
				if( Config.EDIConfig.ShowArchive == tbbShowArchive.Checked ) return;

				Config.EDIConfig.ShowArchive = tbbShowArchive.Checked;
				Config.LoadEDIConfig();
				InitiateScan();
			}
			catch( Exception ex )
			{
				Program.ShowError(ex);
			}
		}

		private void InitiateScan()
		{
			try
			{
				iConfirmCounter = 0;
				AdjustGUI(false);

				bkgThread.RunWorkerAsync();
			}
			catch( Exception ex )
			{
				Program.ShowError(ex);
			}
		}

		private void Scan()
		{
			try
			{
				string a = "ISA*00*          *00*          *01*MTMCIBSD       *12*2015054371     *180711*1227*U*00401*100005200*0*P*:GS*RO*MTMCIBSD*2015054371*20180711*1227*100005200*X*004010ST*303*0001B1*AROF*173545**DY5*ARCA18003403SE*4*0001GE*1*100005200IEA*1*100005200";
				string[] c = a.Split(Delim303, StringSplitOptions.None);

				Directories.Clear();
				AvailableFiles.Clear();

				GridData.Clear();
				FileData.Clear();

				foreach( EDIConfigurationSection sec in Config.EDIConfig )
				{
					LoadFiles(sec, sec.ErrorSubFolder);
					if( bkgThread.CancellationPending ) return;

					if( Config.EDIConfig.ShowArchive )
						LoadFiles(sec, sec.ArchiveSubFolder);
					if( bkgThread.CancellationPending ) return;
				}
			}
			catch( Exception ex )
			{
				Program.ShowError(ex);
			}
		}

		private void LoadFiles(EDIConfigurationSection sec, string dir)
		{
			try
			{
				string scanPath = string.IsNullOrEmpty(dir) ? null : dir.ToLower().Trim();
				if( string.IsNullOrEmpty(scanPath) ) return;

				Directories.Add(dir);

				string[] files = Directory.GetFiles(scanPath);
				if( files == null || files.Length <= 0 ) return;

				int count = 0;
				InitProgress(dir, files.Length);
				foreach( string file in files )
				{
					count++;
					if( CheckAndReportProgress(dir, count, files.Length) == false ) return;

					string tmp = string.IsNullOrEmpty(file) ? null : file.ToLower().Trim();
					string fullName = Path.GetFullPath(tmp);

					//Ignore system and hidden files
					FileInfo fi = new FileInfo(fullName);
					if( (fi.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden ||
						(fi.Attributes & FileAttributes.System) == FileAttributes.System ) continue;

					if( AvailableFiles.Contains(fullName) ) continue;

					AvailableFiles.Add(fullName);
					ParseFile(sec, fullName, fi);
				}
			}
			catch( Exception ex )
			{
				Program.ShowError(ex);
			}
			finally
			{
				EndProgress(dir);
			}
		}

		private void ParseFile(EDIConfigurationSection sec, string file, FileInfo fi)
		{
			try
			{
				string fullName = string.IsNullOrEmpty(file) ? null : file.Trim();
				if( string.IsNullOrEmpty(fullName) ) return;

				string tmp = null;
				string[] fieldDelim = { "*" };
				using( StreamReader sr = new StreamReader(File.OpenRead(fullName)) )
				{
					tmp = sr.ReadToEnd();
				}

				string allText = string.IsNullOrEmpty(tmp) ? null : tmp.Trim();
				allText = allText.Replace("\r", "");
				allText = allText.Replace("\n", "");
				if( string.IsNullOrEmpty(allText) ) return;

				string[] mainSections = allText.Split(mainDelim, StringSplitOptions.None);
				if( sec.MessageNo == "USCRWHHG" )
					mainSections = allText.Split(altDelim, StringSplitOptions.None);
				if(sec.MessageNo == "303IN")
					mainSections = allText.Split(Delim303, StringSplitOptions.None);

				if( mainSections == null ) return;

				for( int iMain = 1; iMain < mainSections.Length; iMain++ )
				{
					string ifield = mainSections[iMain];
					string iText = string.IsNullOrEmpty(ifield) ? null : ifield.Trim();
					if( string.IsNullOrEmpty(iText) ) continue;

					string action = ParseAction(iText, sec.ActionDelimiter, sec.ActionPosition);

					ParseMessage(sec, fullName, allText, iText, action, fi);
				}
			}
			catch( Exception ex )
			{
				Program.ShowError(ex);
			}
		}

		private void ParseMessage(EDIConfigurationSection sec, string fullName, string fileTxt,
			string iText, string action, FileInfo fi)
		{
			try
			{
				if( string.IsNullOrEmpty(iText) ) return;

				string[] fieldDelim = { "*", "~" };

				// Get POL, if available
				string sPOL = "na";
				if( sec.POLDelimiter != null )
				{
					int ix = iText.IndexOf(sec.POLDelimiter);
					if( ix > 0 )
					{
						ix = ix + sec.POLDelimiter.Length + sec.POLPosition - 1;
						sPOL = iText.Substring(ix, 5);
					}
				}
				foreach( EDIDelimiter edelim in sec.Delimiters )
				{
					string delimiter = edelim.Delimiter;
					string fieldName = edelim.FieldName;
					int pos = edelim.Position;

					string[] subSections = iText.Split(new string[] { delimiter },
						StringSplitOptions.None);
					if( subSections == null || subSections.Length <= 0 ) return;

					for( int jSub = 1; jSub < subSections.Length; jSub++ )
					{
						string jfield = subSections[jSub];

						string jText = string.IsNullOrEmpty(jfield) ? null : jfield.Trim();
						if( string.IsNullOrEmpty(jText) ) continue;

						string[] fields = jText.Split(fieldDelim, StringSplitOptions.None);
						if( fields == null || pos >= fields.Length ) continue;

						string field = fields[pos];
						string fieldVal = string.IsNullOrEmpty(field) ? string.Empty : field.Trim();

						List<string> childFields =
							ParseDelimitedString(jfield, sec.SerialDelimiter, sec.SerialPosition);


						int countSubValues = 0;
						if( childFields != null && childFields.Count > 0 )
						{
							foreach( string child in childFields )
							{
								string subValue = string.IsNullOrEmpty(child) ? null : child.Trim();
								if( string.IsNullOrEmpty(subValue) ) continue;
								countSubValues++;

								if( GridData.Exists(delegate(ScanLine scl)
								{
									return (
										string.Compare(scl.FileNameFullPath, fullName, true) == 0 &&
										string.Compare(scl.FieldValue, fieldVal, true) == 0 &&
										string.Compare(scl.FieldSubValue, subValue, true) == 0 
										);
								}) ) continue;

								string sCurrStat = CS2010.ArcSys.Business.ClsLineSQL.GetBookingStatus(fieldVal, subValue);
								ScanLine line = new ScanLine(fieldVal, subValue, action,
									fieldName, delimiter, sec, fullName, fi, sCurrStat, sPOL);

								GridData.Add(line);
							}
						}

						if( countSubValues < 1 )
						{	// If no sub values were found (count < 1), we may have not added the
							// main field value yet, so check if it exists, and add it if not found
							if( GridData.Exists(delegate(ScanLine scl)
							{
								return (string.Compare(scl.FileNameFullPath, fullName, true) == 0 &&
									string.Compare(scl.FieldValue, fieldVal, true) == 0);
							}) ) continue;

							ScanLine line = new ScanLine(fieldVal, string.Empty, action,
								fieldName, delimiter, sec, fullName, fi, "", sPOL);

							GridData.Add(line);
						}

						if( !FileData.ContainsKey(fullName) ) FileData.Add(fullName, fileTxt);
					}
				}
			}
			catch( Exception ex )
			{
				Program.ShowError(ex);
				Program.Show(fullName);
			}
		}



		private List<string> ParseDelimitedString(string aText, string delim, int pos)
		{
			if( string.IsNullOrEmpty(aText) || string.IsNullOrEmpty(delim) || pos < 0 )
				return null;

			string[] subItems = aText.Split(new string[] { delim },
				StringSplitOptions.None);
			if( subItems == null || subItems.Length <= 1 ) return null;

			string[] fieldDelim = { "*" };
			List<string> result = new List<string>();
			for( int iSub = 1; iSub < subItems.Length; iSub++ )
			{
				string ifield = subItems[iSub];

				string iText = string.IsNullOrEmpty(ifield) ? null : ifield.Trim();
				if( string.IsNullOrEmpty(iText) ) continue;

				string[] fields = iText.Split(fieldDelim, StringSplitOptions.None);
				if( fields == null || pos >= fields.Length ) continue;

				string field = fields[pos];
				string fieldVal = string.IsNullOrEmpty(field) ? string.Empty : field.Trim();
				if( string.IsNullOrEmpty(fieldVal) ) continue;

				if( result.Exists(delegate(string sFind)
				{ return (string.Compare(sFind, fieldVal, true) == 0); }) ) continue;

				result.Add(fieldVal);
			}

			return result;
		}

		private string ParseAction(string aText, string delim, int pos)
		{
			if( string.IsNullOrEmpty(aText) || string.IsNullOrEmpty(delim) || pos < 0 )
				return null;

			string[] subItems = aText.Split(new string[] { delim },
				StringSplitOptions.None);
			if( subItems == null || subItems.Length <= 1 ) return null;

			string ifield = subItems[1];
			string iText = string.IsNullOrEmpty(ifield) ? null : ifield.Trim();
			if( string.IsNullOrEmpty(iText) ) return null;


			string[] fieldDelim = { "*" };
			string[] fields = iText.Split(fieldDelim, StringSplitOptions.None);
			if( fields == null || pos >= fields.Length ) return null;

			string field = fields[pos];
			string fieldVal = string.IsNullOrEmpty(field) ? string.Empty : field.Trim();
			if( string.IsNullOrEmpty(fieldVal) ) return null;

			return fieldVal;
		}
		#endregion		// #region Scanning Directories/Parsing Files

		#region Displaying/Formatting RTF

		private void grdScan_SelectionChanged(object sender, EventArgs e)
		{
			try
			{
				rtfContents.Clear();

				GridEXRow row = grdScan.GetRow();
				if( row == null || row.RowType != RowType.Record ) return;

				ScanLine line = row.DataRow as ScanLine;
				if( line == null ) return;

				string txt = null;
				FileData.TryGetValue(line.FileNameFullPath, out txt);

				rtfContents.AppendText(txt);

				FormatFileContents();

				MakeReadable();
			}
			catch( Exception ex )
			{
				Program.ShowError(ex);
			}
		}

		private void FormatFileContents()
		{
			try
			{
				int firstOccur = -1;
				HandleFormat(mainDelim[0], Color.Red, out firstOccur);

				List<string> delims = Config.EDIConfig.GetUniqueDelimiters();
				if( delims != null )
				{
					foreach( string delim in delims )
					{
						if( string.IsNullOrEmpty(delim) ) continue;
						HandleFormat(delim, Color.Yellow, out firstOccur);
					}
				}
			}
			catch( Exception ex )
			{
				Program.ShowError(ex);
			}
		}

		private void ResetFormat()
		{
			try
			{
				rtfContents.SelectAll();
				rtfContents.SelectionBackColor = rtfContents.BackColor;
				FormatFileContents();
			}
			catch( Exception ex )
			{
				Program.ShowError(ex);
			}
		}

		private int HandleFormat(string delim, Color delimColor, out int firstOccur)
		{
			firstOccur = -1;
			try
			{
				if( string.IsNullOrEmpty(delim) ) return -1;

				string allText = rtfContents.Text;
				int i = 0;
				int count = 0;
				while( i < allText.Length - 1 )
				{
					int index = allText.IndexOf(delim, i);
					if( index < 0 ) return count;

					rtfContents.SelectionStart = index;
					rtfContents.SelectionLength = delim.Length;
					rtfContents.SelectionBackColor = delimColor;

					count++;
					i = index + delim.Length;

					if( firstOccur < 0 ) firstOccur = index;
				}
				return count;
			}
			catch( Exception ex )
			{
				Program.ShowError(ex);
				return -1;
			}
		}

		private void btnReadable_Click(object sender, EventArgs e)
		{
			if( btnReadable.Checked )
				MakeReadable();
			else
				grdScan_SelectionChanged(grdScan, EventArgs.Empty);
		}

		private string MakeReadable()
		{
			string delim = "~";
			try
			{
				string allText = rtfContents.Text;
				StringBuilder sb = new StringBuilder();
				int iStart = 0;
				int iEnd = 0;
				int iLength = 0;
				int i = 0;
				while( i < allText.Length - 1 )
				{
					int index = allText.IndexOf(delim, i);
					if( index < 0 ) return sb.ToString();
					iEnd = index;
					iLength = iEnd - iStart;
					sb.AppendLine(allText.Substring(iStart, iLength));
					iStart = iEnd + 1;
					i = iStart;
				}
				rtfContents.Text = sb.ToString();
				return sb.ToString();
			}
			catch( Exception ex )
			{
				Program.ShowError(ex);
				return rtfContents.Text;
			}
		}
		#endregion		// #region Displaying/Formatting RTF

		#region Moving/Processing Files

		private void MoveFiles(string sPath)
		{
			try
			{
				GridEXRow[] rows = grdScan.GetCheckedRows();
				if( rows == null || rows.Length <= 0 )
				{
					Program.ShowError("No rows checked");
					return;
				}

				if( MessageBox.Show("Move Selected Files?", "Confirm", MessageBoxButtons.YesNo)
					!= DialogResult.Yes ) return;

				int countOK = 0, countError = 0;
				List<string> FilesMoved = new List<string>();
				StringBuilder sbGood = new StringBuilder(), sbError = new StringBuilder();
				foreach( GridEXRow row in rows )
				{
					ScanLine line = (row != null) ? row.DataRow as ScanLine : null;
					if( line == null ) continue;

					string fullName = line.FileNameFullPath;
					if( string.IsNullOrEmpty(fullName) || FilesMoved.Contains(fullName) )
						continue;

					string newPath = sPath;
					switch( sPath )
					{
						case "Process":
							newPath = line.MessageInfo.ProcessSubFolder;
							break;
						case "Archive":
							newPath = line.MessageInfo.ArchiveSubFolder;
							break;
					}
					string name = Path.GetFileName(fullName);

					// If this file already exists in the Archive folder, delete it first
					string arkPath = line.MessageInfo.ArchiveSubFolder;
					string arkFile = Path.Combine(arkPath, name);
					if (File.Exists(arkFile))
						File.Delete(arkFile);

					// Move file to new location
					string newname = Path.Combine(newPath, name);
					try
					{
						// Delete the file if it alread exists;
						if (File.Exists(newname))
							File.Delete(newname);
						File.Move(fullName, newname);

						countOK++;
						FilesMoved.Add(fullName);

						sbGood.AppendFormat("Moved {0} to {1}\r\n",
							line.FileName, newname);
					}
					catch( Exception ex )
					{
						countError++;
						sbError.AppendFormat("Error moving file {0}\r\n{1}\r\n",
							fullName, ex.Message);
					}
				}

				sbGood.Insert(0, string.Format("Files moved: {0}, Errors: {1}\r\n\r\n",
					countOK, countError));
				sbGood.Append("\r\n" + sbError.ToString());

				using( frmMemo f = new frmMemo() )
				{
					f.ViewTextFull("Process Information", sbGood.ToString(), "Close");
				}
			}
			catch( Exception ex )
			{
				Program.ShowError(ex);
			}
		}
		private void btnProcess_Click(object sender, EventArgs e)
		{
			MoveFiles("Process");
			InitiateScan();
		}
		private void tbbArchiveFiles_Click(object sender, EventArgs e)
		{
			MoveFiles("Archive");
			InitiateScan();
		}

		#endregion		// #region Moving/Processing Files

		#region Find in Files

		private void frmScanFilesEDI_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				try
				{
					if( (e.KeyCode == Keys.F && e.Control && !e.Alt) || e.KeyCode == Keys.F3 )
					{
						tbrFind.Visible = true;
						ActiveControl = tbrMain;// tbbFindText;
						tbbFindText.Focus();
						e.Handled = true;
					}
					else if( e.KeyCode == Keys.Escape )
					{
						tbrFind.Visible = false;
						ResetFormat();
						e.Handled = true;
					}
				}
				catch( Exception ex )
				{
					Program.ShowError(ex);
				}
			}
			catch( Exception ex )
			{
				Program.ShowError(ex);
			}
		}

		private void tbbFindText_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				if( e.KeyCode == Keys.Enter )
				{
					e.Handled = true;
					ResetFormat();
					string fnd = tbbFindText.Text;
					if( string.IsNullOrEmpty(fnd) ) return;

					int firstOccur = -1;
					int count = HandleFormat(fnd, Color.LightSalmon, out firstOccur);
					if( count > 0 )
					{
						if( firstOccur > 0 && firstOccur < rtfContents.TextLength )
						{
							rtfContents.SelectionStart = firstOccur;
							rtfContents.ScrollToCaret();
						}
						Program.Show("{0} result(s) found for {1}", count, fnd);
					}
					else if( count == 0 )
						Program.Show("{0} not found (reminder: search is case sensitive)", fnd);
				}
				else if( e.KeyCode == Keys.Escape )
				{
					tbrFind.Visible = false;
					ResetFormat();
					e.Handled = true;
				}
			}
			catch( Exception ex )
			{
				Program.ShowError(ex);
			}
		}

		private void tbbFind_Click(object sender, EventArgs e)
		{
			try
			{
				ResetFormat();
				string fnd = tbbFindText.Text;
				if( string.IsNullOrEmpty(fnd) ) return;

				int firstOccur = -1;
				int count = HandleFormat(fnd, Color.LightSalmon, out firstOccur);
				if( count > 0 )
				{
					if( firstOccur > 0 && firstOccur < rtfContents.TextLength )
					{
						rtfContents.SelectionStart = firstOccur;
						rtfContents.ScrollToCaret();
					}
					Program.Show("{0} result(s) found for {1}", count, fnd);
				}
				else if( count == 0 )
					Program.Show("{0} not found (reminder: search is case sensitive)", fnd);
			}
			catch( Exception ex )
			{
				Program.ShowError(ex);
			}
		}

		private void tbbHideFind_Click(object sender, EventArgs e)
		{
			try
			{
				tbrFind.Visible = false;
				ResetFormat();
			}
			catch( Exception ex )
			{
				Program.ShowError(ex);
			}
		}
		#endregion		// #region Find in Files

		#region Asynchronous Section

		private void AdjustGUI(bool enabled)
		{
			try
			{
				Program.MainWindow.SetMainMenuStatus(enabled);
				tbrMain.Enabled = tbrFind.Enabled = pnlMain.Enabled = enabled;
				sbrMain.Visible = !enabled;
				sbbCaption.Enabled = true;	// Clicking cancel disables, so re-enable
			}
			catch( Exception ex )
			{
				Program.ShowError(ex);
			}
		}

		private void bkgThread_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
		{
			try
			{
				Scan();
			}
			catch( Exception ex )
			{
				Program.ShowError(ex);
			}
		}

		private void sbbCaption_Click(object sender, EventArgs e)
		{
			try
			{
				bkgThread.CancelAsync();
				sbbCaption.Enabled = false;
			}
			catch( Exception ex )
			{
				Program.ShowError(ex);
			}
		}

		private void InitProgress(string dir, int total)
		{
			try
			{
				KeyValuePair<string, int> kvp = new KeyValuePair<string, int>(dir, total);
				bkgThread.ReportProgress(0, kvp);
			}
			catch( Exception ex )
			{
				Program.ShowError(ex);
			}
		}

		private bool CheckAndReportProgress(string dir, int count, int total)
		{
			try
			{
				if( bkgThread.CancellationPending ) return false;

				KeyValuePair<string, int> kvp = new KeyValuePair<string, int>(dir, total);
				double comp = ((double)count / (double)total) * 100;
				bkgThread.ReportProgress((int)comp, kvp);

				return true;
			}
			catch( Exception ex )
			{
				return Program.ShowError(ex);
			}
		}

		private void EndProgress(string dir)
		{
			try
			{
				bkgThread.ReportProgress(100, new KeyValuePair<string, int>(dir, 0));
			}
			catch( Exception ex )
			{
				Program.ShowError(ex);
			}
		}

		private void bkgThread_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
		{
			try
			{
				KeyValuePair<string, int> kvp = (KeyValuePair<string, int>)e.UserState;

				string s = string.Format("Path: {0}, Files: {1} (Click here to cancel) {2}%",
					kvp.Key, kvp.Value, e.ProgressPercentage);
				sbbCaption.Text = s;
				sbbProgress.Value = e.ProgressPercentage;
			}
			catch( Exception ex )
			{
				Program.ShowError(ex);
			}
		}

		private void bkgThread_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
		{
			try
			{
				AdjustGUI(true);

				UpdateDisplay();
			}
			catch( Exception ex )
			{
				Program.ShowError(ex);
			}
		}

		private void frmScanFilesEDI_FormClosing(object sender, FormClosingEventArgs e)
		{
			try
			{
				if( e.CloseReason == CloseReason.WindowsShutDown ) return;

				if( bkgThread.IsBusy )
				{
					e.Cancel = true;
					Program.Show("Cancel the scan before closing the window");
				}
			}
			catch( Exception ex )
			{
				Program.ShowError(ex);
			}
		}
		#endregion		// #region Asynchronous Section



		#region Protocol

		private void grdScan_DoubleClick(object sender, EventArgs e)
		{
			try
			{
				GridArea ga = grdScan.HitTest();
				if( ga != GridArea.Cell ) return;

				GridEXRow row = grdScan.GetRow();
				ScanLine ln = (row != null) ? row.DataRow as ScanLine : null;
				if( ln == null ) return;

				if (ln.MessageInfo.MessageNo == "USCRWHHG")
				{
					ShowHHGLog(ln.FileName);
					return;
				}
				ProtocolParameters pps = new ProtocolParameters();
				pps.Filename = ln.FileNameDbParam;
				pps.Protocol_Type = "'E','I', 'W'";
				DataTable dt = ClsProtocol.GetProtocol(pps);
				if( dt == null || dt.Rows.Count <= 0 )
				{
					Program.Show("Nothing found");
					return;
				}

				using (frmShowProtocol f = new frmShowProtocol())
				{
					f.ShowProtocol(dt, ln);
					//f.ShowWindow(dt, ln);
				}
				//frmShowProtocol f = new frmShowProtocol();
				//f.ShowWindow(dt, ln);
			}
			catch( Exception ex )
			{
				Program.ShowError(ex);
			}
		}

		protected void ShowHHGLog(string sText)
		{
			//string sText = "ahg50hhg.5231453.2014512120.txt_1".ToUpper();
			sText = sText.ToUpper();
			StringBuilder strMsg = new StringBuilder();
			string[] sFiles = Directory.GetFiles("\\\\commserver01\\in_out\\USCRW_HHG_RECEIVING_Imp\\Logs");
			foreach (string s in sFiles)
			{
				string line;
				using (StreamReader file = new StreamReader(s))
				{
					while ((line = file.ReadLine()) != null)
					{
						line = line.ToUpper();
						if (line.Contains(sText))
						{
							strMsg.AppendLine(line);
							line = file.ReadLine();
							strMsg.AppendLine(line);
						}
					}
				}
			}
			Program.Show(strMsg.ToString());
		}
		#endregion		// #region Protocol

		#region Event Handlers

		private void grdScan_FilterApplied(object sender, EventArgs e)
		{
			try
			{
				int listTotal = (GridData != null) ? GridData.Count : 0;
				int gridTotal = grdScan.RecordCount;
				if( listTotal != gridTotal )
				{
					grdScan.RootTable.Caption = string.Format("{0} Row(s), {1} File(s), {2} Matching Rows(s)",
						listTotal, FileData.Count, gridTotal);
				}
				else
					grdScan.RootTable.Caption = string.Format("{0} Row(s), {1} File(s)",
						gridTotal, FileData.Count);
			}
			catch( Exception ex )
			{
				Program.ShowError(ex);
			}
		}

		private void grdScan_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				if( e.KeyCode == Keys.C && e.Control )
				{
					GridEXRow r = grdScan.GetRow();
					GridEXColumn c = grdScan.CurrentColumn;
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

		private void btnShowFile_Click(object sender, EventArgs e)
		{
			if( pnlMain.Panel2Collapsed )
				pnlMain.Panel2Collapsed = false;
			else
				pnlMain.Panel2Collapsed = true;
			MakeReadable();
		}


		private void ucButton1_Click(object sender, EventArgs e)
		{
		}

		private void btnDOD_Click(object sender, EventArgs e)
		{
			// Goes through all 322's with no Description of Goods
			// and plugs in "L5*1*DOD HOUSEHOLD GOODS**"
			int iCount = 0;
			string[] sFiles = Directory.GetFiles("\\\\commserver01\\in_out\\ANSI322_IMP\\Error");
			foreach (string s in sFiles)
			{
				string sText = File.ReadAllText(s);
				int i = sText.IndexOf("L5*1***");
				sText = sText.Replace("L5*1***", "L5*1*DOD HOUSEHOLD GOODS**");
				if (i > 0)
				{
					//Program.Show(s);
					File.WriteAllText(s, sText);
					iCount++;
				}
				int i2 = sText.IndexOf("HOUSEHOLD GOOD*");
				sText = sText.Replace("HOUSEHOLD GOOD*", "HOUSEHOLD GOODS*");
				if (i2 > 0)
				{
					//Program.Show(s);
					File.WriteAllText(s, sText);
					if (i < 1)
						iCount++;
				}
			}
			Program.Show("{0} files updated ", iCount);
		}

		private void grdScan_ColumnButtonClick(object sender, ColumnActionEventArgs e)
		{
			string sCol = e.Column.DataMember.ToLower();
			if (sCol.IsNullOrWhiteSpace())
			{
				sCol = e.Column.Key.ToLower();
			}
			GridEXRow drow = grdScan.GetRow();
			ScanLine line = (drow != null) ? drow.DataRow as ScanLine : null;
			if (line == null) return;
			string sFullName = line.PathName + "\\" + line.FileName;

			if (sCol == "filename")
			{
				ClsOpenEDIFile.OpenFileWithFullName(sFullName);
				return;
			}
			if (sCol == "updatekop")
			{
				iConfirmCounter++;
				string sKOP = CS2010.ArcSys.Business.ClsLineSQL.GetCargoKOP(line.FieldValue, line.FieldSubValue);
				if (string.IsNullOrEmpty(sKOP))
				{
					Program.Show("Could not find the Kind of Package for this piece of cargo");
					return;
				}
				if (iConfirmCounter < 5)
				{
					string sMsg = string.Format("Change the Kind of Package to {0} so this cargo can process?", sKOP);
					DialogResult dr = MessageBox.Show(sMsg, "Confirm", MessageBoxButtons.OKCancel);
					if (dr != DialogResult.OK)
						return;
				}
				StreamReader strR = new StreamReader(sFullName);
				string sText = strR.ReadToEnd();
				strR.Close();
				strR.Dispose();

				string sNewText = GetKOPfrom322(sText, sKOP);
				StreamWriter strW = new StreamWriter(sFullName, false);
				strW.Write(sNewText);
				strW.Close();
				strW.Dispose();
			}

		}

		private string GetKOPfrom322(string sText, string sNewKOP)
		{
			int iPos = sText.IndexOf("~L0*");
			if (iPos < 5)
				return null;
			int ix = 0;
			string sKOP = "";
			try
			{
				while (ix < 14)
				{
					int iNextPos = sText.IndexOf("*", iPos + 1);
					ix++;
					iPos = iNextPos;
					string a = sText.Substring(iPos + 1);
				}
				sKOP = sText.Substring(iPos + 1, 3);
				sText = sText.Remove(iPos + 1, 3).Insert(iPos + 1, sNewKOP);
				return sText;
			}
			catch (Exception ex)
			{
				return null;
			}

		}
		private void grdScan_LinkClicked(object sender, ColumnActionEventArgs e)
		{
			ScanLine line = currentLine;
			GridEXColumn col = e.Column;
			try
			{
				frmLINEQuery frm = new frmLINEQuery(line.FieldValue);
				frm.MdiParent = Program.MainWindow;
				frm.Show();
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}

		}
		#endregion		// #region Event Handlers

	}

	#region ScanLine Class

	/// <summary>Class used to display data in the grid</summary>
	public class ScanLine
	{
		#region Fields/Properties

		private string _FieldName;
		public string FieldName
		{
			get { return _FieldName; }
			set { _FieldName = value; }
		}

		private string _FieldDelim;
		public string FieldDelim
		{
			get { return _FieldDelim; }
			set { _FieldDelim = value; }
		}

		private string _FieldValue;
		public string FieldValue
		{
			get { return _FieldValue; }
			set { _FieldValue = value; }
		}

		private string _FieldSubValue;
		public string FieldSubValue
		{
			get { return _FieldSubValue; }
			set { _FieldSubValue = value; }
		}

		private string _FieldSub2Value;
		public string FieldSub2Value
		{
			get { return _FieldSub2Value; }
			set { _FieldSub2Value = value; }
		}
		private string _FieldSub3Value;
		public string FieldSub3Value
		{
			get { return _FieldSub3Value; }
			set { _FieldSub3Value = value; }
		}

		private string _FileNameFullPath;
		public string FileNameFullPath
		{
			get { return _FileNameFullPath; }
			set { _FileNameFullPath = value; }
		}

		public string FileName { get { return Path.GetFileName(FileNameFullPath); }	}
		public string PathName { get { return Path.GetDirectoryName(FileNameFullPath); } }

		public string FieldValueDbParam
		{
			get
			{
				if( string.IsNullOrEmpty(FieldValue) ) return null;
				return string.Format("%{0}%", FieldValue);
			}
		}

		public string FileNameDbParam
		{
			get
			{
				if( string.IsNullOrEmpty(FileName) ) return null;
				return string.Format("%{0}%", FileName);
			}
		}

		private string _CurrentStatus;
		public string CurrentStatus
		{
			get
			{
				return _CurrentStatus;
			}
			set
			{
				_CurrentStatus = value;
			}
		}
		private FileInfo _FileData;
		public FileInfo FileData { get { return _FileData; } set { _FileData = value; } }
	
		private EDIConfigurationSection _MessageInfo;
		public EDIConfigurationSection MessageInfo
		{
			get { return _MessageInfo; }
			set { _MessageInfo = value; }
		}
		#endregion		// #region Fields/Properties

		#region Constructors

		public ScanLine(string foundValue, string foundSubValue, string fSub2Val,  string fieldNm,
			string delim, EDIConfigurationSection secInfo, string fullName, FileInfo fi, string currentStatus, string fSub3Val)
		{
			FieldValue = foundValue;
			FieldSubValue = foundSubValue;
			FieldSub2Value = fSub2Val;
			FieldSub3Value = fSub3Val;
			FieldName = fieldNm;
			FieldDelim = delim;
			FileNameFullPath = fullName;
			FileData = fi;
			MessageInfo = secInfo;
			CurrentStatus = currentStatus;
		}
		#endregion		// #region Constructors
	}
	#endregion		// #region ScanLine Class
}