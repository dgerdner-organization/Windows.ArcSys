using System;
using System.Data;
using System.Text;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;
using CS2010.Common;

namespace CS2010.CommonWinCtrls
{
	public partial class frmMemo : Form
	{
		#region Constants

		private const int WindowWidth = 298;
		private const int InputWindowHeight = 99;
		private const int MemoWindowHeight = 234;

		#endregion		// #region Constants

		#region Fields

		private int? OverrideWidth;
		private int? OverrideHeight;

		private Font LargeFont;
		private Font NormalFont;

		private bool _UpperCase;

		#endregion		// #region Fields

		#region Properties

		public string InputText { get { return rtfMemo.Text; } }

		public int MaxLength
		{
			get { return rtfMemo.MaxLength; }
			set { rtfMemo.MaxLength = value; }
		}

		public bool UpperCase
		{
			get { return _UpperCase; }
			set { _UpperCase = value; }
		}

		public bool NumericOnly
		{
			get;
			set;
		}

		[DefaultValue(false), Browsable(true),
		Description("Gets/Sets whether to word wrap the contents of the textbox")]
		public bool WordWrap
		{
			get { return rtfMemo.WordWrap; }
			set { rtfMemo.WordWrap = value; }
		}
		#endregion		// #region Properties

		#region Constructors

		public frmMemo()
		{
			InitializeComponent();

			NormalFont = (Font)Font.Clone();
			LargeFont = new Font(Font.FontFamily, 12F);

			_UpperCase = false;
			rtfMemo.WordWrap = false;
		}
		#endregion		// #region Constructors

		#region Public method(s)

		public bool InputBox(string title, string initialtext)
		{
			OverrideWidth = null;
			OverrideHeight = null;
			return GetText(title, initialtext, true);
		}

		public bool InputBox(string title, string initialtext, int maxlength)
		{
			rtfMemo.MaxLength = maxlength;
			return InputBox(title, initialtext);
		}

		public bool InputBox(string initialtext)
		{
			OverrideWidth = null;
			OverrideHeight = null;
			return GetText(null, initialtext, true);
		}

		public bool AddMemo(string title, string initialtext, int? winWidth, int? winHeight)
		{
			OverrideWidth = winWidth;
			OverrideHeight = winHeight;
			return GetText(title, initialtext, false);
		}

		public bool AddMemo(string title, string initialtext)
		{
			OverrideWidth = null;
			OverrideHeight = null;
			return GetText(title, initialtext, false);
		}

		public bool AddMemo(string initialtext)
		{
			OverrideWidth = null;
			OverrideHeight = null;
			return GetText(null, initialtext, false);
		}

		public void ViewTextFull(string title, string text)
		{
			OverrideWidth = null;
			OverrideHeight = null;
			ShowText(title, text, true);
		}

		public void ViewTextFull(string title, string text, string cancelButtonText)
		{
			OverrideWidth = null;
			OverrideHeight = null;
			if( !string.IsNullOrEmpty(cancelButtonText) ) btnCancel.Text = cancelButtonText;
			ShowText(title, text, true);
		}

		public void ViewTextFull(string text)
		{
			OverrideWidth = null;
			OverrideHeight = null;
			ShowText(null, text, true);
		}

		public void ViewText(string title, string text)
		{
			OverrideWidth = null;
			OverrideHeight = null;
			ShowText(title, text, false);
		}

		public void ViewText(string text)
		{
			OverrideWidth = null;
			OverrideHeight = null;
			ShowText(null, text, false);
		}
		#endregion		// #region Public method(s)

		#region Helper Methods

		private bool GetText(string title, string initialtext, bool oneLine)
		{
			try
			{
				if( oneLine == true )
				{
					Width = WindowWidth;
					Height = InputWindowHeight;
					rtfMemo.Multiline = false;
					rtfMemo.AcceptsTab = false;

					ControlBox = false;
					FormBorderStyle = FormBorderStyle.FixedDialog;
					AcceptButton = btnSave;
				}
				else
				{
					Width = ( OverrideWidth != null ) ? OverrideWidth.Value : WindowWidth;
					Height = ( OverrideHeight != null ) ? OverrideHeight.Value : MemoWindowHeight;
					rtfMemo.Multiline = true;
					rtfMemo.AcceptsTab = true;

					ControlBox = true;
					FormBorderStyle = FormBorderStyle.Sizable;
					AcceptButton = null;
				}
				rtfMemo.Font = (Font)NormalFont.Clone();

				Text = ( string.IsNullOrEmpty(title) == true )
					? "Enter Text" : title;
				rtfMemo.ReadOnly = false;
				if( string.IsNullOrEmpty(initialtext) == true )
					rtfMemo.Text = string.Empty;
				else
					rtfMemo.Text = ( initialtext.Length > rtfMemo.MaxLength
						&& rtfMemo.MaxLength > 0 )
						? initialtext.Substring(0, rtfMemo.MaxLength)
						: initialtext;
				rtfMemo.Focus();
				ActiveControl = rtfMemo;
				btnSave.Visible = btnSave.Enabled = true;
				return ( ShowDialog() == DialogResult.OK );
			}
			catch( Exception ex )
			{
				return Display.ShowError("Error", ex);
			}
		}

		private void ShowText(string title, string text, bool fullScreen)
		{
			try
			{
				ControlBox = true;
				FormBorderStyle = FormBorderStyle.Sizable;
				rtfMemo.Multiline = true;

				if( fullScreen == true )
				{
					//Top = Screen.PrimaryScreen.WorkingArea.Top;
					//Left = Screen.PrimaryScreen.WorkingArea.Left;
					//Width = Screen.PrimaryScreen.WorkingArea.Width;
					//Height = Screen.PrimaryScreen.WorkingArea.Height;
					Width = 800;
					Height = 600;
					StartPosition = FormStartPosition.CenterParent;
					rtfMemo.Font = (Font)LargeFont.Clone();
					//rtfMemo.WordWrap = false;
				}
				else
				{
					StartPosition = FormStartPosition.CenterParent;
					Width = WindowWidth;
					Height = MemoWindowHeight;
					//rtfMemo.WordWrap = false;
					rtfMemo.Font = (Font)NormalFont.Clone();
				}
				Text = ( string.IsNullOrEmpty(title) == true )
					? "View Text" : title;
				rtfMemo.Text = text;
				rtfMemo.ReadOnly = true;
				btnSave.Visible = btnSave.Enabled = false;
				btnCancel.Focus();
				ActiveControl = btnCancel;
				ShowDialog();
			}
			catch( Exception ex )
			{
				Display.ShowError("Error", ex);
			}
		}
		#endregion		// #region Helper Methods

		#region Event Handlers

		private void btnSave_Click(object sender, System.EventArgs e)
		{
			string s = InputText;
			if( string.IsNullOrEmpty(s) == true )
			{
				Display.ShowError("Error", "Cannot save, no text entered");
				return;
			}
			if( s.Length > rtfMemo.MaxLength )
			{
				Display.ShowError("Error",
					"Maximum number of characters ({0}) exceeded",
					rtfMemo.MaxLength);
				return;
			}
			DialogResult = DialogResult.OK;
		}

		private void rtfMemo_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (UpperCase == true)
			{
				if (char.IsLetter(e.KeyChar) == true)
					e.KeyChar = char.ToUpper(e.KeyChar);
			}
			if (NumericOnly)
			{
				if (char.IsNumber(e.KeyChar) == false)
					e.Handled = true;
			}
		}
		#endregion		// #region Event Handlers

		#region Static Methods

		public static void LoadRTF(DataTable dtMemo, RichTextBox rtfMemos)
		{
			rtfMemos.Clear();
			StringBuilder sb = new StringBuilder();
			foreach( DataRow dr in dtMemo.Rows )
			{
				rtfMemos.SelectionStart = rtfMemos.TextLength;
				rtfMemos.SelectionFont = new System.Drawing.Font(
					rtfMemos.Font, System.Drawing.FontStyle.Bold |
					System.Drawing.FontStyle.Underline);
				rtfMemos.SelectedText = string.Format(
                    "{0}\t{1}\t{2}\t{3}\t{4}\r\n\r\n", dr["CORR_TYPE_DSC"], dr["ORDER_NO"], dr["CREATE_USER"],
					dr["LOCATION_CD"], ClsConfig.FormatDate(
					ClsConvert.ToDateTimeNullable(dr["CREATE_DT"]))                    );

				sb.Length = 0;
				sb.AppendFormat("\t{0}", dr["MEMO"]);
				sb.Replace("\n", "\n\t");

				rtfMemos.SelectionStart = rtfMemos.TextLength;
				rtfMemos.SelectedText = sb.ToString();

				rtfMemos.AppendText("\r\n\r\n");
			}
		}
		#endregion		// #region Static Methods
	}
}