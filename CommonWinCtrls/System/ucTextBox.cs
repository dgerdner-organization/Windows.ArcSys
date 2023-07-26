using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using CS2010.Common;

namespace CS2010.CommonWinCtrls
{
	[ToolboxItem(true)]
	[DesignTimeVisible(true)]
	[ToolboxBitmap(typeof(TextBox))]
	public partial class ucTextBox : TextBox
	{
		#region Fields

		protected Boolean ChangeColorOnEnter;

		protected Color ResetColor;
		protected Color EnterBackGroundColor;
		protected Color DisableBackGroundColor;
		protected Color ReadOnlyBackGroundColor;

		private bool ChangingTab;

		protected ucLabel lblText;
		protected ucLinkLabel lnkText;

		protected bool _PreventPaste;

        protected bool _LinkEnabled = true;
        protected string _LinkDisabledMessage = "Link Disabled";

		#endregion		// #region Fields

		#region Properties

		protected Orientation _LabelAlignment;
		/// <summary>Gets/Sets the alignment of the label relative to the
		/// textbox (to its left, above it, or to its right).</summary>
		[DefaultValue(typeof(Orientation), "Left")]
		[Description("Used to specify where to align the label. " +
			"Ignored if LabelType set to none.")]
		public Orientation LabelAlignment
		{
			get { return _LabelAlignment; }
			set
			{
				if( _LabelAlignment == value ) return;
				_LabelAlignment = value;
				AdjustLabel();
			}
		}

		protected string _LabelText;
		/// <summary>Gets/Sets the text for the label (ignored if LabelType
		/// is set to None).</summary>
		[DefaultValue(ucLabel.DefaultText)]
		[Description("Label for the text box when LabelType is set to " +
			"Label or Link. Ignored if LabelType set to none.")]
		public string LabelText
		{
			get { return _LabelText; }
			set
			{
				_LabelText = value;
				if( lblText != null )
					lblText.Text = value;
				else if( lnkText != null )
					lnkText.Text = value;
				AdjustLabel();
			}
		}

		protected TextLabelType _LabelType;
		/// <summary>Gets/Sets the type of label to display (None: no label is
		/// displayed, Label: uses a regular ucLabel, Link: uses a ucLinkLabel).
		/// When set to Link, the LinkClicked event is raised when the link is
		/// clicked.</summary>
		[DefaultValue(typeof(TextLabelType), "None")]
		[Description("Type of label to associate with the text box")]
		public TextLabelType LabelType
		{
			get { return _LabelType; }
			set
			{
				if( _LabelType == value ) return;
				_LabelType = value;
				AdjustLabel();
			}
		}

		protected Color _LabelColor;
		/// <summary>Gets/Sets the color of the label (if any) associated with the control
		/// (only applies to type Label, it is ignored for type Link)</summary>
		[DefaultValue(typeof(Color), "Black")]
		[Description("Color of the text label associated with the control (only applies to Label)")]
		public Color LabelColor
		{
			get { return _LabelColor; }
			set
			{
				_LabelColor = value;
				if (lblText != null)
					lblText.ForeColor = value;
				AdjustLabel();
			}
		}

		protected Color _LabelBackColor;
		/// <summary>Gets/Sets the background color of the label (if any) associated with the control
		/// (only applies to type Label, it is ignored for type Link)</summary>
		[DefaultValue(typeof(Color), "Control")]
		[Description("Gets/Sets the background color of the label associated with the control (only applies to Label)")]
		public Color LabelBackColor
		{
			get { return _LabelBackColor; }
			set
			{
				_LabelBackColor = value;
				if (lblText != null)
					lblText.BackColor = value;
				AdjustLabel();
			}
		}

		/// <summary>Gets/Sets whether to prevent pasting into this text box</summary>
		[DefaultValue(false)]
		[Description("Gets/Sets whether to prevent pasting into this text box")]
		public bool PreventPaste
		{
			get { return _PreventPaste; }
			set
			{
				if( _PreventPaste == value ) return;
				_PreventPaste = value;
			}
		}

        /// <summary>
        /// Gets/Sets whether link label is enabled
        /// </summary>
        [DefaultValue(true)]
        [Description("Gets/Sets whether the link label is enabled")]
        public bool LinkEnabled
        {
            get { return _LinkEnabled; }
            set { _LinkEnabled = value; }
        }

        [DefaultValue("Link is disabled")]
        [Description("Sets the message to display when the user tries to click a link that has been disabled")]
        public string LinkDisabledMessage
        {
            get { return _LinkDisabledMessage; }
            set { _LinkDisabledMessage = value; }
        }

		[Description("Occurs when the link label is clicked")]
		public event LinkLabelLinkClickedEventHandler LinkClicked;

		[DefaultValue(CharacterCasing.Upper)]
		public new CharacterCasing CharacterCasing
		{
			get { return base.CharacterCasing; }
			set { base.CharacterCasing = value; }
		}

		#endregion		// #region Properties

		#region Constructors

		public ucTextBox()
		{
			InitializeComponent();

			SetDefaults();

			ChangingTab = false;
			PreventPaste = false;

			_LabelType = TextLabelType.None;
			_LabelAlignment = Orientation.Left;
			_LabelText = ucLabel.DefaultText;
			_LabelColor = Color.Black;
			_LabelBackColor = SystemColors.Control;
		}
		#endregion		// #region Constructors

		#region Overrides

		protected override void OnEnter(EventArgs e)
		{
			if (ChangeColorOnEnter == true)
				if (this.ReadOnly == false) 
					base.BackColor = EnterBackGroundColor;
			base.OnEnter(e);
		}

		protected override void OnLeave(EventArgs e)
		{
			if (ChangeColorOnEnter == true) base.BackColor = ResetColor;
			if (this.ReadOnly == true) base.BackColor = ReadOnlyBackGroundColor;
			if (this.Enabled == false) base.BackColor = DisableBackGroundColor;
			base.OnLeave(e);
		}

		protected override void OnEnabledChanged(EventArgs e)
		{
			base.OnEnabledChanged(e);

			if (this.Enabled == false)
			{
				base.BackColor = DisableBackGroundColor;
				base.ForeColor = Color.Black;
				base.TabStop = false;
			}
			else
			{
				base.BackColor = ResetColor;
				base.TabStop = true;
			}
		}

		protected override void OnReadOnlyChanged(EventArgs e)
		{
			base.OnReadOnlyChanged(e);

			if (this.ReadOnly == true)
			{
				base.BackColor = ReadOnlyBackGroundColor;
				base.ForeColor = Color.Black;
				base.TabStop = false;
			}
			else
			{
				base.BackColor = ResetColor;
				base.TabStop = true;
			}
		}

		protected override void OnCreateControl()
		{
			base.OnCreateControl();
			AdjustLabel();
		}

		protected override void OnParentChanged(EventArgs e)
		{
			base.OnParentChanged(e);
			if( lblText != null ) lblText.Parent = Parent;
			if( lnkText != null ) lnkText.Parent = Parent;
		}

		protected override void OnMove(EventArgs e)
		{
			base.OnMove(e);
			AdjustLabel();
		}

		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			AdjustLabel();
		}

		protected override void OnTabIndexChanged(EventArgs e)
		{
			if( ChangingTab == true ) return;
			try
			{
				ChangingTab = true;

				base.OnTabIndexChanged(e);
				if( lblText == null && lnkText == null ) return;

				int tindex = ( TabIndex > 0 ) ? TabIndex - 1 : 0;
				if( lblText != null )
					lblText.TabIndex = tindex;
				else
					lnkText.TabIndex = tindex;
			}
			finally
			{
				ChangingTab = false;
			}
		}

		protected override void SetVisibleCore(bool value)
		{
			base.SetVisibleCore(value);
			if( lblText != null ) lblText.Visible = value;
			if( lnkText != null ) lnkText.Visible = value;
		}

		protected override void WndProc(ref Message m)
		{
			if( PreventPaste == false || m.Msg != 0x302 ) base.WndProc(ref m);
		}
		#endregion		// #region Overrides

		#region Private Methods

		private void SetDefaults()
		{
			ResetColor = base.BackColor;
			ChangeColorOnEnter = ClsControlConfig.ChangeColorOnEnter;
			base.CharacterCasing = ClsControlConfig.Case;
			ReadOnlyBackGroundColor =
				ClsControlConfig.ReadOnlyBackGroundColor;
			EnterBackGroundColor =
				ClsControlConfig.EnterBackGroundColor;
			DisableBackGroundColor =
				ClsControlConfig.DisableBackGroundColor;
		}

		private void AdjustLabel()
		{
			Control c = null;
			switch( LabelType )
			{
				case TextLabelType.None:
					if( lnkText != null ) lnkText.Dispose();
					if( lblText != null ) lblText.Dispose();
					lnkText = null;
					lblText = null;
					return;

				case TextLabelType.Label:
					if( lnkText != null ) lnkText.Dispose();
					lnkText = null;

					if( lblText == null )
					{
						lblText = new ucLabel();
						lblText.Parent = Parent;
						lblText.Text = LabelText;
						lblText.UseMnemonic = true;
						lblText.TabIndex = ( TabIndex > 0 ) ? TabIndex - 1 : 0;
						lblText.ForeColor = _LabelColor;
						lblText.BackColor = _LabelBackColor;
					}
					c = lblText;
					break;

				case TextLabelType.Link:
					if( lblText != null ) lblText.Dispose();
					lblText = null;

					if( lnkText == null )
					{
						lnkText = new ucLinkLabel();
						lnkText.Parent = Parent;
						lnkText.Text = LabelText;
						lnkText.UseMnemonic = true;
						lnkText.LinkClicked +=
							new LinkLabelLinkClickedEventHandler
							(lnkText_LinkClicked);
						lnkText.TabIndex = ( TabIndex > 0 ) ? TabIndex - 1 : 0;
					}
					c = lnkText;
					break;

				default: break;
			}
			if( c == null ) return;

			c.Visible = true;
			switch( LabelAlignment )
			{
				case Orientation.Left:
					if( Multiline == true )
						c.Top = Top + 2;
					else
						c.Top = Top + ( Height - c.Height ) / 2;
					c.Left = Left - ( c.Width + 2 );
					break;

				case Orientation.Top:
					c.Top = Top - ( c.Height + 2);
					c.Left = Left;
					break;

				case Orientation.Right:
					c.Top = Top + ( Height - c.Height ) / 2;
					c.Left = Left + Width + 2;
					break;

				default: break;
			}
		}
		#endregion

		#region Event Handlers

		void lnkText_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
            if (LinkClicked != null)
            {
                if (!LinkEnabled)
                {
                    MessageBox.Show(LinkDisabledMessage);
                    return;
                }
            }
			if( LinkClicked != null ) LinkClicked(sender, e);
		}
		#endregion		// #region Event Handlers
	}
}