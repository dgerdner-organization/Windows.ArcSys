using System;
using System.Drawing;
using System.Windows.Forms;
using Janus.Windows.GridEX;
using CS2010.Common;
using CS2010.CommonWinCtrls;
using ASL.ITrack.Business;

namespace ASL.ITrack.WinCtrls
{
	/// <summary>ITrack-Specific Config File Manager</summary>
	public static class ClsITrackConfig
	{
		#region ITrack Settings

		public static bool LimitBizDefaultSearch
		{
			get { return ClsConfig.ReadBooleanValue("LimitBizDefaultSearch", true); }
		}

		public static bool EmailEmg
		{
			get { return ClsConfig.ReadBooleanValue("EmailEmg", false); }
		}

		public static bool EmailDevNote
		{
			get { return ClsConfig.ReadBooleanValue("EmailDevNote", false); }
		}

		public static bool EmailDevNew
		{
			get { return ClsConfig.ReadBooleanValue("EmailDevNew", false); }
		}

		public static bool EmailBizNew
		{
			get { return ClsConfig.ReadBooleanValue("EmailBizNew", false); }
		}

		public static bool EmailDevPriority
		{
			get { return ClsConfig.ReadBooleanValue("EmailDevPriority", false); }
		}

		public static bool EmailBizPriority
		{
			get { return ClsConfig.ReadBooleanValue("EmailBizPriority", false); }
		}

		public static string DevDistributionList
		{
			get { return ClsConfig.ReadStringValue("DevDistributionList", "jroman@amslgroup.com"); }
		}

		public static string EmgDistributionList
		{
			get { return ClsConfig.ReadStringValue("EmgDistributionList", "jroman@amslgroup.com"); }
		}

		public static bool ShowNotifier
		{
			get { return ClsConfig.ReadBooleanValue("ShowNotifier", false); }
		}
		#endregion		// #region Search Issue Options Settings

		#region Search Issue Options Settings

		public static class IssueOptions
		{
			#region Properties

			public static string ProjectCds
			{
				get { return ClsConfig.ReadStringValue("ProjectCds", null); }
			}

			public static string CategoryCds
			{
				get { return ClsConfig.ReadStringValue("CategoryCds", null); }
			}

			public static string StatusCds
			{
				get { return ClsConfig.ReadStringValue("StatusCds", null); }
			}
			#endregion		// #region Properties

			#region Public Methods

			public static void ApplyIssueOptions(IssueParams _Options)
			{
				try
				{
					if( !ClsEnvironment.IsDeveloper ) return;

					ClsConfig.SectionName = ClsEnvironment.UserName;

					_Options.StatusCds = StatusCds;
					_Options.ProjectCds = ProjectCds;
					_Options.CategoryCds = CategoryCds;
				}
				catch( Exception ex )
				{
					ClsErrorHandler.LogException(ex);
				}
			}
			#endregion		// #region Public Methods
		}
		#endregion		// #region Search Issue Options Settings

		#region Grid Layout Settings

		public static class GridOptions
		{
			#region Properties

			public static string FontName
			{
				get { return ClsConfig.ReadStringValue("FontName", null); }
			}

			public static int FontSize
			{
				get { return ClsConfig.ReadNumeric<int>("FontSize", 0); }
			}

			public static string ColumnNames
			{
				get
				{
					return ClsConfig.ReadStringValue("ColumnNames", null);
				}
			}

			public static string ColumnWidths
			{
				get { return ClsConfig.ReadStringValue("ColumnWidths", null); }
			}

			public static string ColumnFit
			{
				get { return ClsConfig.ReadStringValue("ColumnFit", null); }
			}

			public static string GroupNames
			{
				get { return ClsConfig.ReadStringValue("GroupNames", null); }
			}

			public static string GroupMode
			{
				get { return ClsConfig.ReadStringValue("GroupMode", null); }
			}
			#endregion		// #region Properties

			#region Public Methods

			public static void ApplyOptions(ucGridEx grdIssues)
			{
				try
				{
					if( !ClsEnvironment.IsDeveloper ) return;

					ClsConfig.SectionName = ClsEnvironment.UserName;

					ApplyFontOptions(grdIssues);
					ApplyGroupOptions(grdIssues);
					ApplyColumnOptions(grdIssues);
				}
				catch( Exception ex )
				{
					ClsErrorHandler.LogException(ex);
				}
			}
			#endregion		// #region Public Methods

			#region Helper Methods

			private static void ApplyColumnOptions(ucGridEx grdIssues)
			{
				try
				{
					int[] sizes = GetInts(ColumnWidths);
					string[] columns = GetStrings(ColumnNames);
					if( columns != null && columns.Length > 0 && sizes != null &&
						columns.Length == sizes.Length )
					{
						foreach( GridEXColumn col in grdIssues.RootTable.Columns )
							if( !col.ActAsSelector ) col.Visible = false;

						for( int i = 0; i < columns.Length; i++ )
						{
							string colName = !string.IsNullOrEmpty(columns[i])
								? columns[i].Trim() : null;
							if( string.IsNullOrEmpty(colName) ) continue;

							GridEXColumn col = grdIssues.RootTable.Columns.Contains(colName) ?
								grdIssues.RootTable.Columns[colName] : null;
							if( col == null ) continue;

							col.Visible = true;
							if( sizes[i] > 0 ) col.Width = sizes[i];
						}
					}

					FitColumnsMode? fit = GetEnumValue<FitColumnsMode>(ColumnFit);
					if( fit != null ) grdIssues.PrintDocument.FitColumns = fit.Value;
				}
				catch( Exception ex )
				{
					ClsErrorHandler.LogException(ex);
				}
			}

			private static void ApplyGroupOptions(ucGridEx grdIssues)
			{
				try
				{
					string[] groups = GetStrings(GroupNames);
					if( groups == null || groups.Length <= 0 ) return;

					grdIssues.RootTable.Groups.Clear();
					for( int i = 0; i < groups.Length; i++ )
					{
						string grpName = !string.IsNullOrEmpty(groups[i])
							? groups[i].Trim() : null;
						if( string.IsNullOrEmpty(grpName) ) continue;

						GridEXColumn col = grdIssues.RootTable.Columns.Contains(grpName) ?
							grdIssues.RootTable.Columns[grpName] : null;
						if( col != null ) grdIssues.RootTable.Groups.Add(col);
					}

					GroupMode? mode = GetEnumValue<GroupMode>(GroupMode);
					if( mode != null ) grdIssues.RootTable.GroupMode = mode.Value;
				}
				catch( Exception ex )
				{
					ClsErrorHandler.LogException(ex);
				}
			}

			private static void ApplyFontOptions(ucGridEx grdIssues)
			{
				try
				{
					string fontName = FontName;
					if( string.IsNullOrEmpty(fontName) ) fontName = grdIssues.Font.Name;

					float fontSize = FontSize;
					if( fontSize < 2 ) fontSize = grdIssues.Font.Size;

					grdIssues.Font = new Font(fontName, fontSize);
				}
				catch( Exception ex )
				{
					ClsErrorHandler.LogException(ex);
				}
			}
			#endregion		// #region Helper Methods
		}
		#endregion		// #region Grid Layout Settings

		#region Window Size Settings

		public static class WindowOptions
		{
			#region Properties

			public static int WindowHeight
			{
				get { return ClsConfig.ReadNumeric<int>("WindowHeight", 0); }
			}

			public static int WindowWidth
			{
				get { return ClsConfig.ReadNumeric<int>("WindowWidth", 0); }
			}

			public static string WindowStart
			{
				get { return ClsConfig.ReadStringValue("WindowStart", null); }
			}
			#endregion		// #region Properties

			#region Public Methods

			public static void ApplyOptions(Form mainWindow)
			{
				try
				{
					if( !ClsEnvironment.IsDeveloper ) return;

					ClsConfig.SectionName = ClsEnvironment.UserName;

					int hgt = WindowHeight;
					if( hgt < 0 )
						mainWindow.Height = Screen.PrimaryScreen.WorkingArea.Height;
					else if( hgt > 0 )
						mainWindow.Height = hgt;

					if( hgt != 0 )
					{
						int top =
							( Screen.PrimaryScreen.WorkingArea.Height - mainWindow.Height ) / 2;
						mainWindow.Top = ( top > 0 ) ? top : 0;
					}

					int wid = WindowWidth;
					if( wid < 0 )
						mainWindow.Width = Screen.PrimaryScreen.WorkingArea.Width;
					else if( wid > 0 )
						mainWindow.Width = wid;

					if( wid != 0 )
					{
						int left =
							( Screen.PrimaryScreen.WorkingArea.Width - mainWindow.Width ) / 2;
						mainWindow.Left = ( left > 0 ) ? left : 0;
					}

					FormWindowState? state = GetEnumValue<FormWindowState>(WindowStart);
					if( state != null ) mainWindow.WindowState = state.Value;
				}
				catch( Exception ex )
				{
					ClsErrorHandler.LogException(ex);
				}
			}
			#endregion		// #region Public Methods
		}
		#endregion		// #region Window Size Settings

		#region Helper Methods

		private static string[] GetStrings(string csv)
		{
			string s = !string.IsNullOrEmpty(csv) ? csv.Trim() : null;
			return !string.IsNullOrEmpty(s) ? s.Split(new char[] { ',' }) : null;
		}

		private static int[] GetInts(string csv)
		{
			string s = !string.IsNullOrEmpty(csv) ? csv.Trim() : null;
			string[] items = !string.IsNullOrEmpty(s) ? s.Split(new char[] { ',' }) : null;
			if( items == null || items.Length <= 0 ) return null;

			int[] values = new int[items.Length];
			for( int i = 0; i < items.Length; i++ )
			{
				string t = !string.IsNullOrEmpty(items[i]) ? items[i].Trim() : null;

				int? val = null;
				try { val = ClsConvert.ToInt32Nullable(t); }
				catch { val = null; }

				values[i] = val.GetValueOrDefault(0);
			}

			return values;
		}

		private static T? GetEnumValue<T>(string value) where T : struct
		{
			T? result = null;
			try
			{
				string s = !string.IsNullOrEmpty(value) ? value.Trim() : null;
				if( !string.IsNullOrEmpty(s) ) result = (T)Enum.Parse(typeof(T), s);
			}
			catch
			{
				result = null;
			}
			return result;
		}
		#endregion		// #region Helper Methods

		public static DateTime SystemDate
		{
			get
			{
				if (ClsConMgr.Manager["ITrack"] == null) return DateTime.Now;
				return ClsConMgr.Manager["ITrack"].GetSystemDate();
			}
		}
	}
}