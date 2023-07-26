using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using CS2010.Common;

namespace CS2010.CommonWinCtrls
{
	[ToolboxItem(true)]
	[DesignTimeVisible(true)]
	[ToolboxBitmap(typeof(ListView))]
	public partial class ucListView : ListView
	{
		#region Fields

		protected Boolean ChangeColorOnEnter;

		protected Color ResetColor;
		protected Color EnterBackGroundColor;
		protected Color DisableBackGroundColor;
		protected Color ReadOnlyBackGroundColor;

		private bool _ReadOnly;

		private bool ChangingTab;

		protected ucLabel lblText;
		protected ucLinkLabel lnkText;

		protected string _LabelText;
		protected TextLabelType _LabelType;
		protected Orientation _LabelAlignment;
        protected bool _LinkEnabled = true;
        protected string _LinkDisabledMessage = "Link Disabled";

		#endregion		// #region Fields

		#region Properties

		public ucLabel ViewLabel
		{
			get { return lblText; }
		}
		public ucLinkLabel ViewLink
		{
			get { return lnkText; }
		}

		/// <summary>Gets/Sets whether the listview is readonly or not</summary>
		[DefaultValue(false)]
		[Description("Gets/Sets whether the listview is readonly or not")]
		public bool ReadOnly
		{
			get { return _ReadOnly; }
			set
			{
				if( value == _ReadOnly ) return;

				_ReadOnly = value;
				OnReadOnlyChanged(EventArgs.Empty);
			}
		}

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

		#endregion		// #region Properties

		#region Constructors

		public ucListView()
		{
			InitializeComponent();

			SetDefaults();

			ChangingTab = false;

			_LabelType = TextLabelType.None;
			_LabelAlignment = Orientation.Left;
			_LabelText = ucLabel.DefaultText;
		}
		#endregion		// #region Constructors

		#region Overrides

		protected override void OnEnter(EventArgs e)
		{
			base.OnEnter(e);
			if( ChangeColorOnEnter == true )
				base.BackColor = EnterBackGroundColor;
		}

		protected override void OnLeave(EventArgs e)
		{
			base.OnLeave(e);
			if( ChangeColorOnEnter == true ) base.BackColor = ResetColor;

			if( ReadOnly == true )
				base.BackColor = ReadOnlyBackGroundColor;
			else if( Enabled == false )
				base.BackColor = DisableBackGroundColor;
		}

		protected override void OnEnabledChanged(EventArgs e)
		{
			base.OnEnabledChanged(e);

			if( Enabled == false )
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

		protected void OnReadOnlyChanged(EventArgs e)
		{
			if( ReadOnly == true )
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
			AdjustLabel();
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
			if( lblText != null ) lblText.Visible = Visible;
			if( lnkText != null ) lnkText.Visible = Visible;
		}
		#endregion		// #region Overrides

		#region Private Methods

		private void SetDefaults()
		{
			ResetColor = base.BackColor;
			ChangeColorOnEnter = ClsControlConfig.ChangeColorOnEnter;
			EnterBackGroundColor = ClsControlConfig.EnterBackGroundColor;
			DisableBackGroundColor = ClsControlConfig.DisableBackGroundColor;
			ReadOnlyBackGroundColor = ClsControlConfig.ReadOnlyBackGroundColor;
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
					c.Top = Top + 2;
					c.Left = Left - ( c.Width + 2 );
					break;

				case Orientation.Top:
					c.Top = Top - ( c.Height + 2 );
					c.Left = Left;
					break;

				case Orientation.Right:
					c.Top = Top + ( Height - c.Height ) / 2;
					c.Left = Left + Width + 2;
					break;

				default: break;
			}
		}
		#endregion		// #region Private Methods

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