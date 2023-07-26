using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Design;
using System.ComponentModel;
using System.ComponentModel.Design;
using CS2010.Common;

namespace CS2010.CommonWinCtrls
{
	[ToolboxItem(true)]
	[DesignTimeVisible(true)]
	[ToolboxBitmap(typeof(TextBox))]
	public partial class ucDateTextBox : ucTextBox
	{
		#region Fields

		/// <summary>Used to indicate that the validation was triggered because
		/// the active control on the form changed. It is set to true in the
		/// OnLeave method. It is then evaluated in the OnValidated method so we
		/// can determine whether we need to display the date using the display
		/// format (which will happen if the value is true), or if we need to
		/// continue to display the date using the EditFormat. Note: The Leave
		/// event (when it occurs), is triggered before the Validating/Validated
		/// events, so we cannot switch the display format in the OnLeave method,
		/// because the validation hasn't occurred yet.</summary>
		protected bool IsLeaving;

		protected DateTime? _Value;
		protected DateTime _MaxDate;

		protected ContextMenu cnuTextBox;
		protected ucCheckBox chkCalendar;

		protected string _EditFormat = "yyMMdd";
		protected string _DefaultFormat = "yyyy-MM-dd";

		#endregion		// #region Fields

		#region Properties

		/// <summary>Gets/Sets the default format of the date boxes</summary>
		[DefaultValue(Dates.DateFormatEdit)]
		[Description("Gets/Sets the edit format of the date boxes")]
		public string EditFormat
		{
			get { return _EditFormat; }
			set { _EditFormat = value; }
		}

		/// <summary>Gets/Sets the default format of the date boxes</summary>
		[DefaultValue(Dates.DateFormatDefault)]
		[Description("Gets/Sets the default format of the date boxes")]
		public string DefaultFormat
		{
			get { return _DefaultFormat; }
			set { _DefaultFormat = value; }
		}

		/// <summary>Gets/Sets the default format of the date boxes</summary>
		[DefaultValue(null)]
		[Description("Gets/Sets the optional format to use to display the date (overrides the format from the config file)")]
		public string OverrideDisplayFormat { get; set; }

		/// <summary>Occurs when the date (Value property) changes</summary>
		public event EventHandler ValueChanged;

		private string DisplayFormat
		{
			get
			{
				if( DesignMode ) return DefaultFormat;

				if (!string.IsNullOrWhiteSpace(OverrideDisplayFormat))
					return OverrideDisplayFormat;

				return ClsConfig.DateFormat;
			}
		}

		/// <summary>Gets/Sets the date in the text box</summary>
		[Description("Gets/Sets the date in the text box"),
		Editor(typeof(DateTimeEditor), typeof(UITypeEditor))]
		public DateTime? Value
		{
			get { return _Value; }
			set
			{
				if( _Value == value || CheckMax(value) == false ) return;

				_Value = value;
				if( _Value == null )
					base.Text = string.Empty;
				else
					base.Text = _Value.Value.ToString(
						( Focused == true && ReadOnly == false )
						? EditFormat : DisplayFormat);

				OnValueChanged(EventArgs.Empty);
			}
		}

		/// <summary>Gets/Sets the maximum date allowed in the text box</summary>
		[DefaultValue(typeof(DateTime), "1/1/3000")]
		[Description("Gets/Sets the maximum date allowed in the text box")]
		public DateTime MaxDate
		{
			get { return _MaxDate; }
			set
			{
				if( _MaxDate == value ) return;
				_MaxDate = value;
				if( _Value != null && _Value > _MaxDate ) Value = _MaxDate;
			}
		}

		/// <summary>Gets the date value as formatted string
		/// (it uses the ClsConfig.DateFormat as the format)</summary>
		[Browsable(false)]
		public string FormattedText
		{
			get { return ClsConfig.FormatDate(Value, DisplayFormat); }
		}
		#endregion		// #region Properties

		#region Constructors

		public ucDateTextBox()
		{
			InitializeComponent();

			_EditFormat = Dates.DateFormatEdit;
			_DefaultFormat = Dates.DateFormatDefault;

			CustomInitialization();
		}
		#endregion		// #region Constructors

		#region Helper Methods

		private void CustomInitialization()
		{
			base.MaxLength = DateBoxMaxLength;
			_MaxDate = new DateTime(3000, 1, 1);

			_Value = null;
			base.Text = string.Empty;

			cnuTextBox = new ContextMenu();

			MenuItem mi = cnuTextBox.MenuItems.Add("&Open Calendar");
			mi.Click += new EventHandler(miCalendar_Click);
			mi.DefaultItem = true;

			mi = cnuTextBox.MenuItems.Add("-");

			mi = cnuTextBox.MenuItems.Add("&Undo");
			mi.Click += new EventHandler(miUndo_Click);

			mi = cnuTextBox.MenuItems.Add("-");

			mi = cnuTextBox.MenuItems.Add("Cu&t");
			mi.Click += new EventHandler(miCut_Click);
			mi = cnuTextBox.MenuItems.Add("&Copy");
			mi.Click += new EventHandler(miCopy_Click);
			mi = cnuTextBox.MenuItems.Add("&Paste");
			mi.Click += new EventHandler(miPaste_Click);

			mi = cnuTextBox.MenuItems.Add("-");

			mi = cnuTextBox.MenuItems.Add("Select &All");
			mi.Click += new EventHandler(miSelect_Click);

			ContextMenu = cnuTextBox;
		}

		private bool CheckMax(DateTime? aDate)
		{
			if( aDate == null ) return true;

			if( aDate.Value.Date > _MaxDate.Date )
				return Display.ShowError("Maximum date exceeded",
					"Specified date ({0}) cannot be greater than {1}",
					aDate.Value.ToString(DefaultFormat),
					_MaxDate.ToString(DefaultFormat));

			return true;
		}

		private void AdjustButton()
		{
		}
		#endregion		// #region Helper Methods

		#region Virtual Methods

		protected virtual void OnValueChanged(EventArgs e)
		{
			if( ValueChanged != null ) ValueChanged(this, e);
		}

		private int DateBoxMaxLength
		{
			get { return System.Math.Max(EditFormat.Length, DefaultFormat.Length); }
		}
		#endregion		// #region Virtual Methods

		#region Overrides

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override int MaxLength { get { return DateBoxMaxLength; } }

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override string Text { get { return base.Text; } }

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override bool Multiline
		{
			get { return base.Multiline; }
		}

		protected override void OnKeyPress(KeyPressEventArgs e)
		{
			base.OnKeyPress(e);
			e.Handled = ( char.IsDigit(e.KeyChar) == false && e.KeyChar != '\b' );
		}

		protected override void OnEnter(EventArgs e)
		{
			base.OnEnter(e);

			if( _Value == null )
				base.Text = string.Empty;
			else
				base.Text = _Value.Value.ToString
					(ReadOnly == true ? DefaultFormat : EditFormat);
			MaxLength = DateBoxMaxLength;
		}

		protected override void OnLeave(EventArgs e)
		{
			IsLeaving = true;
			base.OnLeave(e);
		}

		protected override void OnValidating(CancelEventArgs e)
		{
			try
			{
				if( ReadOnly == true )
				{
					e.Cancel = false;
					return;
				}

				string s = base.Text.Trim();
				if( string.IsNullOrEmpty(s) == true )
				{
					e.Cancel = false;
					Value = null;
					return;
				}

				DateTime dtNew;
				DateTime? dtHold = _Value;
				string[] formats = { EditFormat, DefaultFormat };
				if( DateTime.TryParseExact(s, formats,
					System.Globalization.CultureInfo.InvariantCulture,
					System.Globalization.DateTimeStyles.NoCurrentDateDefault,
					out dtNew) == false )
				{
					Display.ShowError("Invalid Format", "Invalid date specified");
					e.Cancel = true;
					Value = dtHold;
				}
				else
				{
					if( CheckMax(dtNew) == false )
					{
						e.Cancel = true;
						return;
					}

					e.Cancel = false;
					Value = dtNew;
				}
			}
			finally
			{
				base.OnValidating(e);
			}
		}

		protected override void OnValidated(EventArgs e)
		{
			base.OnValidated(e);

			if( IsLeaving == true )
			{
				IsLeaving = false;
				base.Text = ClsConfig.FormatDate(_Value, DisplayFormat);
			}
		}

		public bool AttemptTextToValue()
		{
			CancelEventArgs e = new CancelEventArgs();
			OnValidating(e);
			return !e.Cancel;
		}

		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			AdjustButton();
		}

		protected override void OnMove(EventArgs e)
		{
			base.OnMove(e);
			AdjustButton();
		}
		#endregion		// #region Overrides

		#region Event Handlers

		void miUndo_Click(object sender, EventArgs e)
		{
			Undo();
		}

		void miCut_Click(object sender, EventArgs e)
		{
			Cut();
		}

		void miCopy_Click(object sender, EventArgs e)
		{
			Copy();
		}

		void miPaste_Click(object sender, EventArgs e)
		{
			Paste();
		}

		void miSelect_Click(object sender, EventArgs e)
		{
			SelectAll();
		}

		void miCalendar_Click(object sender, EventArgs e)
		{
			using( frmDateSelector frm = new frmDateSelector() )
			{
				bool ret = frm.GetDate(_Value, DateTime.Now, MaxDate);
				Focus();
				if( ret == false ) return;

				_Value = frm.SelectedDate;
				base.Text = _Value.Value.ToString(EditFormat);
				OnValueChanged(EventArgs.Empty);
			}
		}
		#endregion		// #region Event Handlers
	}
}