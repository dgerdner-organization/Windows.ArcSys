using System;
using System.Data;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using Janus.Windows.GridEX;
using System.ComponentModel;
using CS2010.Common;
using CS2010.CommonWinCtrls;
using CS2010.ArcSys.Business;

namespace CS2010.ArcSys.WinCtrls
{
	/// <summary>ArcSys version of ucCheckedComboBox for cargo statuses</summary>
	public partial class ucCargoStatusCheckBoxCombo : ucCheckedComboBox
	{
		#region Properties

		/// <summary>Gets a list of checked cargo status codes</summary>
		[Browsable(false)]
		public List<string> CheckedCargoStatusCDs
		{
			get
			{
				List<string> lst = new List<string>();

				if( CheckedItems != null )
				{
					foreach( DataRowView drv in CheckedItems )
					{
						if( drv == null ) continue;

						string cd = ClsConvert.ToString(drv["Cargo_Status_Cd"]);
						if( string.IsNullOrEmpty(cd) == false ) lst.Add(cd);
					}
				}

				return lst;
			}
		}

		/// <summary>Gets a comma separated string of cargo status codes</summary>
		[Browsable(false)]
		public string CargoStatusCDs
		{
			get
			{
				StringBuilder sb = new StringBuilder();

				if( CheckedItems != null )
				{
					foreach( DataRowView drv in CheckedItems )
					{
						if( drv == null || drv.Row == null ) continue;

						string cd = ClsConvert.ToString(drv["Cargo_Status_Cd"]);
						if( string.IsNullOrEmpty(cd) == false )
							sb.AppendFormat("{0}'{1}'", ( sb.Length > 0 ? ", " : null ), cd);
					}
				}

				return sb.ToString();
			}
		}

		/// <summary>Gets a comma separated string of cargo status descriptions</summary>
		[Browsable(false)]
		public string CargoStatusDSCs
		{
			get
			{
				StringBuilder sb = new StringBuilder();

				if( CheckedItems != null )
				{
					foreach( DataRowView drv in CheckedItems )
					{
						if( drv == null || drv.Row == null ) continue;

						string dsc = ClsConvert.ToString(drv["Cargo_Status_Dsc"]);
						if( string.IsNullOrEmpty(dsc) == false )
							sb.AppendFormat("{0}'{1}'", (sb.Length > 0 ? ", " : null), dsc);
					}
				}

				return sb.ToString();
			}
		}
		#endregion		// #region Properties

		#region Constructors

		/// <summary>Default Constructor</summary>
		public ucCargoStatusCheckBoxCombo()
		{
			InitializeComponent();

			CreateStructure();

			InitAutoComplete();

			SetTableSource();

			DropDownList.FormattingRow += new RowLoadEventHandler(DropDownList_FormattingRow);
		}

		private void DropDownList_FormattingRow(object sender, RowLoadEventArgs e)
		{
			try
			{
				if (e.Row == null || e.Row.DataRow == null) return;

				DataRowView drv = e.Row.DataRow as DataRowView;
				DataRow dr = (drv != null) ? drv.Row : e.Row.DataRow as DataRow;
				if (dr == null || e.Row.Cells == null || e.Row.Cells.Count <= 0) return;

				string dsc = ClsConvert.ToString(dr["Extra_Dsc"]);
				e.Row.Cells["Cargo_Status_Dsc"].ToolTipText = dsc;
				e.Row.Cells["Extra_Dsc"].ToolTipText = dsc;
			}
			catch (Exception ex)
			{
				Display.ShowError("ArcSys", ex);
			}
		}
		#endregion		// #region Constructors

		#region Public Methods

		public void Reset()
		{
			if( ClsEnvironment.IsDesignMode == true ) return;

			SetTableSource();
		}
		#endregion		// #region Public Methods

		#region Helper Methods

		private void CreateStructure()
		{
			DropDownList.Columns.Clear();

			GridEXColumn c = DropDownList.Columns.Add("Selector");
			c.DataMember = "Cargo_Status_Cd";
			c.ActAsSelector = true;
			c.UseHeaderSelector = false;
			c.Caption = null;
			c.Width = 30;

			c = DropDownList.Columns.Add("Cargo_Status_Dsc");
			c.DataMember = "Cargo_Status_Dsc";
			c.Caption = "Cargo Status";
			c.Width = 125;

			c = DropDownList.Columns.Add("Cargo_Status_Cd");
			c.DataMember = "Cargo_Status_Cd";
			c.Caption = "Code";
			c.Visible = false;

			c = DropDownList.Columns.Add("Sequence_Nbr");
			c.DataMember = "Sequence_Nbr";
			c.Caption = "Seq";
			c.Width = 50;

			c = DropDownList.Columns.Add("Extra_Dsc");
			c.DataMember = "Extra_Dsc";
			c.Caption = "Info";
			c.Width = 500;

			c = DropDownList.Columns.Add("Active_Flg");
			c.DataMember = "Active_Flg";
			c.Caption = "Active";
			c.Visible = false;
			c.Width = 65;
			c.HeaderAlignment = TextAlignment.Center;
			c.ColumnType = ColumnType.CheckBox;
			c.EditType = EditType.CheckBox;
			c.CheckBoxTrueValue = "Y";
			c.CheckBoxFalseValue = "N";

			DropDownList.VisibleRows = 20;
			// Set in designer
			//SortType = ComboSortType.None;
			//DisplayType = ComboDisplay.DescriptionOnly;
		}

		private void SetTableSource()
		{
			if( ClsEnvironment.IsDesignMode == true ) return;

			DataTable dt = ClsCargoStatus.GetStatuses();
			ClsConnection.AddColumns(dt, "Cargo_Status_Cd", "Cargo_Status_Dsc");

			if( Table != null )
			{
				Table.Dispose();
				Table = null;
			}
			Table = dt;
		}
		#endregion		// #region Helper Methods

		#region Overrides

		protected override void SetDataSource(object aValue)
		{
			// JR: We keep track of the data source internally,
			// so do not allow it to be overwritten
		}

		protected override void OnValidating(CancelEventArgs e)
		{
			base.OnValidating(e);
			try
			{
				if( CheckedItems != null )
				{
					foreach( object obj in CheckedItems )
					{
						if( obj == null )
						{
							e.Cancel = true;
							Display.ShowError(ClsConfig.MessageBoxTitle, "One or more statuses are invalid");
							break;
						}
					}
				}
				if( e.Cancel == false && DroppedDown == true ) e.Cancel = true;
			}
			catch( Exception ex )
			{
				Display.ShowError(ClsConfig.MessageBoxTitle, ex);
			}
		}
		#endregion		// #region Overrides

		#region AutoComplete Section

		#region AutoComplete Internal Fields/Properties

		protected bool _FilterDropDown;		// See FilterDropDown property

		/// <summary>Field used to hold characters typed during autocomplete</summary>
		protected StringBuilder sbBuffer;

		/// <summary>Get the column name used to attempt the auto complete against</summary>
		protected string AutoCompleteColName
		{
			get { return DisplayMemberName; }
		}

		/// <summary>Returns the GridEXColumn with a name that matches the AutoCompleteColName, or
		/// null if the column does not exist</summary>
		protected GridEXColumn AutoCompleteCol
		{
			get
			{
				return DropDownList.Columns.Contains(AutoCompleteColName)
					? DropDownList.Columns[AutoCompleteColName] : null;
			}
		}
		#endregion		// #region AutoComplete Fields/Internal Properties

		#region AutoComplete Public Properties

		/// <summary>Gets/Sets whether the DropDown should be filtered as text is typed when the
		/// DropDown is displayed (AutoComplete functionality)</summary>
		[DefaultValue(false)]
		[Description("Gets/Sets whether the DropDown should be filtered as text is typed when " +
			"the DropDown is displayed (AutoComplete functionality)")]
		public bool FilterDropDown
		{
			get { return _FilterDropDown; }
			set
			{
				if (value == _FilterDropDown) return;

				_FilterDropDown = value;
				if (!_FilterDropDown) DropDownList.RemoveFilters();
			}
		}
		#endregion		// #region AutoComplete Public Properties

		#region AutoComplete Event Handlers

		/// <summary>When we show the dropdown, update the checked state of all rows</summary>
		protected override void OnDropDown(EventArgs e)
		{
			base.OnDropDown(e);

			SetItemsChecked(TextBox.Text);
		}

		/// <summary>When we hide the dropdown clear the autocomplete buffer and remove any filters</summary>
		protected override void OnDropDownHide(ComboDropDownHideEventArgs e)
		{
			base.OnDropDownHide(e);

			sbBuffer.Length = 0;
			DropDownList.RemoveFilters();
		}

		/// <summary>Process each key typed in when the dropdown is visible</summary>
		protected void dd_KeyPress(object sender, KeyPressEventArgs e)
		{
			ProcessChar(e.KeyChar);
		}

		/// <summary>When we click an item clear the autocomplete buffer, remove any filters,
		/// and write out the string of checked items</summary>
		protected void dd_MouseUp(object sender, MouseEventArgs e)
		{
			sbBuffer.Length = 0;
			DropDownList.RemoveFilters();
			WriteString(string.Empty, GetItemsChecked().ToString());
		}
		#endregion		// #region AutoComplete Event Handlers

		#region AutoComplete Helper Methods

		/// <summary>Provide the initial setup needed to provide the AutoComplete</summary>
		protected void InitAutoComplete()
		{
			_FilterDropDown = false;
			DropDownButtonsVisible = false;

			sbBuffer = new StringBuilder();

			DropDownList.KeyPress += new KeyPressEventHandler(dd_KeyPress);
			DropDownList.MouseUp += new MouseEventHandler(dd_MouseUp);
		}

		/// <summary>Handles the processing of the characters typed in when the dropdown is
		/// visible. We basically keep track of the characters in the sbAutoComplete buffer, when
		/// a space or comma is typed we clear the buffer and update the string of checked items.
		/// When a backspace is typed we remove the last character from the buffer. We also
		/// attempt to filter the dropdown based on the characters typed.</summary>
		/// <param name="c">The character to process</param>
		protected void ProcessChar(char c)
		{
			switch (c)
			{
				case '\b':
					if (sbBuffer.Length > 0)
						sbBuffer.Length = sbBuffer.Length - 1;

					break;

				case ' ':
				case ',':
					sbBuffer.Length = 0;

					GridEXRow row = DropDownList.GetRow();
					if (row != null && !row.IsChecked)
						row.IsChecked = true;

					break;

				default:
					if (char.IsControl(c) || char.IsWhiteSpace(c)) return;

					sbBuffer.Append(char.ToUpper(c));
					break;
			}

			WriteString(sbBuffer.ToString(), GetItemsChecked().ToString());

			AutoCompleteFilter(sbBuffer.ToString());

			if (sbBuffer.Length > 0) GotoItem(sbBuffer.ToString());
		}

		/// <summary>Filter the DropDown to items matching the text specified</summary>
		/// <param name="txt">The text to filter the DropDown by</param>
		/// <remarks>This filtering is controlled by the FilterDropDownProperty: when set to true,
		/// the DropDown is filtered, when false, no filtering occurs.</remarks>
		protected void AutoCompleteFilter(string txt)
		{
			if (!_FilterDropDown) return;

			bool filterOK = false;
			if (!string.IsNullOrEmpty(txt))
			{
				GridEXColumn col = AutoCompleteCol;
				if (col != null)
				{
					DropDownList.ApplyFilter(
						new GridEXFilterCondition(col, ConditionOperator.BeginsWith, txt));
					filterOK = true;
				}
			}
			if (!filterOK) DropDownList.RemoveFilters();
		}

		/// <summary>Get a comma separated string of the items checked</summary>
		protected StringBuilder GetItemsChecked()
		{
			StringBuilder sb = new StringBuilder();

			DataTable dt = Table;
			if (dt != null && dt.Columns.Contains(AutoCompleteColName))
			{
				GridEXRow[] chkRows = DropDownList.GetCheckedRows();
				if (chkRows != null && chkRows.Length > 0)
				{
					foreach (GridEXRow gr in chkRows)
					{
						DataRowView drv = gr.DataRow as DataRowView;
						string cd = (drv != null)
							? ClsConvert.ToString(drv[AutoCompleteColName]) : null;
						if (!string.IsNullOrEmpty(cd))
							sb.AppendFormat("{0}{1}", sb.Length > 0 ? "," : null, cd);
					}
				}
			}

			return sb;
		}

		/// <summary>Attempts to check the rows corresponding to the items provided in the comma
		/// separated list and return the last item in the list</summary>
		/// <param name="txt">Comma separated list of codes</param>
		/// <returns>The last item specified in the string</returns>
		protected string SetItemsChecked(string txt)
		{
			DropDownList.UnCheckAllRecords();

			string s = !string.IsNullOrEmpty(txt) ? txt.Trim() : null;
			string[] items = !string.IsNullOrEmpty(s) ? s.Split(new char[] { ',' }) : null;
			if (items == null || items.Length < 1) return null;

			string lastCd = null;
			bool lastChk = false;
			foreach (string cd in items)
			{
				s = !string.IsNullOrEmpty(cd) ? cd.Trim() : null;
				if (string.IsNullOrEmpty(s)) continue;

				lastCd = s;
				lastChk = SetItemChecked(s);
			}

			sbBuffer.Length = 0;
			if (!string.IsNullOrEmpty(lastCd))
			{
				GotoItem(lastCd);
				if (!lastChk) sbBuffer.Append(lastCd);
			}

			return lastCd;
		}

		/// <summary>Attempts to check the row corresponding to the item provided and returns
		/// true if the item is found and checked, or false otherwise</summary>
		/// <param name="item">The item to attempt to check</param>
		/// <returns>True if item found and checked, false if not</returns>
		protected bool SetItemChecked(string item)
		{
			GridEXRow gr = GetFirstMatchingRow(item, true);
			if (gr != null) gr.IsChecked = true;
			return (gr != null);
		}

		/// <summary>Attempt to go to the row corresponding to the item provided (i.e. make the
		/// corresponding row the current row) and return true if found, false if not</summary>
		/// <param name="item">The item to go to</param>
		/// <returns>True if the corresponding row was made current, false if not</returns>
		protected bool GotoItem(string item)
		{
			GridEXRow gr = GetFirstMatchingRow(item, false);
			if (gr == null || gr.Position < 0) return false;

			DropDownList.Row = gr.Position;
			DropDownList.EnsureVisible();
			return true;
		}

		/// <summary>Find the first GridEXRow matching the item specified. The second parameter
		/// controls how the matching is performed: either true, match exactly using the equal
		/// operator, or false, match using the like operator</summary>
		/// <param name="item">The item to search for</param>
		/// <param name="matchExactly">True: match using equal, false: match using LIKE</param>
		/// <returns>The first GridEXRow found, or null if not found</returns>
		protected GridEXRow GetFirstMatchingRow(string item, bool matchExactly)
		{
			DataTable dt = Table;
			if (dt == null || !dt.Columns.Contains(AutoCompleteColName) ||
				string.IsNullOrEmpty(item)) return null;

			string op = (matchExactly) ? "=" : "LIKE";
			string suffix = (matchExactly) ? null : "%";
			string f = string.Format("{0} {1} '{2}{3}'", AutoCompleteColName, op, item, suffix);
			DataRow[] rows = dt.Select(f, AutoCompleteColName);
			if (rows == null || rows.Length < 1) return null;

			return DropDownList.GetRow(rows[0]);
		}
		#endregion		// #region AutoComplete Helper Methods

		#region AutoComplete Drawing Methods

		/// <summary>Handles echoing the characters typed during AutoComplete back on the screen
		/// in the TextBox area, so users can see what they are typing, along with displaying
		/// the items that have been checked</summary>
		/// <param name="s1">The characters typed by the user</param>
		/// <param name="s2">The string of checked items</param>
		/// <remarks>Creates 2 boxed areas: the first box will display the first string and the
		/// second box will display the other string of checked items</remarks>
		protected void WriteString(string s1, string s2)
		{
			using (Graphics g = Graphics.FromHwnd(TextBox.Handle))
			{
				g.Clear(TextBox.BackColor);

				int s1Wid = 39;
				int s2Start = s1Wid + 2;

				int hgt = TextBox.Height - 1;
				int s2Wid = TextBox.Width - (s2Start + 1);

				Rectangle[] rects = new Rectangle[] {
					new Rectangle(0, 0, s1Wid, hgt), new Rectangle(s2Start, 0, s2Wid, hgt)};
				g.DrawRectangles(Pens.Gray, rects);

				DrawText(g, s1, TextBox.Font, SystemBrushes.ControlText, 1, 1,
					rects[0].Size);
				DrawText(g, s2, TextBox.Font, SystemBrushes.ControlText, s2Start + 1, 1,
					rects[1].Size);
			}
		}

		/// <summary>The actual method used to display the text</summary>
		/// <remarks>This method first measures the string to determine how much can actually
		/// be displayed in the given area. If the text does not completely fit in the space
		/// provided, the text is "scrolled" to the right.</remarks>
		protected void DrawText(Graphics g, string s, Font f, Brush b, int x, int y, Size sz)
		{
			int chars = 0, lines = 0;
			g.MeasureString(s, f, sz, null, out chars, out lines);

			// We will display the rightmost characters if all the text does not fit
			string txt = (s != null && s.Length > chars) ? s.Substring(s.Length - chars) : s;
			g.DrawString(txt, f, b, x, y);
		}
		#endregion		// #region AutoComplete Drawing Methods

		#endregion		// #region AutoComplete Section
	}
}