using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using Janus.Windows.GridEX.EditControls;
using CS2010.Common;

namespace CS2010.CommonWinCtrls
{
	[ToolboxItem(true)]
	[DesignTimeVisible(true)]
	[ToolboxBitmap(typeof(IntegerUpDown))]
	public partial class ucIntegerUpDown : IntegerUpDown
	{
		#region Fields/Properties

		private bool ChangingTab;

		protected Color _ResetColor;
		private Color ResetColor
		{
			get { return _ResetColor; }
			set { _ResetColor = value; }
		}

		protected Color _EnterBackGroundColor;
		private Color EnterBackGroundColor
		{
			get { return _EnterBackGroundColor; }
			set { _EnterBackGroundColor = value; }
		}

		protected Boolean _ChangeColorOnEnter;
		private Boolean ChangeColorOnEnter
		{
			get { return _ChangeColorOnEnter; }
			set { _ChangeColorOnEnter = value; }
		}

		protected Color _ReadOnlyBackGroundColor;
		private Color ReadOnlyBackGroundColor
		{
			get { return _ReadOnlyBackGroundColor; }
			set { _ReadOnlyBackGroundColor = value; }
		}

		protected Color _DisableBackGroundColor;
		private Color DisableBackGroundColor
		{
			get { return _DisableBackGroundColor; }
			set { _DisableBackGroundColor = value; }
		}
		#endregion		// #region Fields/Properties

		#region Constructors/Initialization

		public ucIntegerUpDown()
		{
			InitializeComponent();

			SetDefaults();

			ChangingTab = false;

			_LabelType = TextLabelType.None;
			_LabelAlignment = Orientation.Left;
			_LabelText = ucLabel.DefaultText;
		}

		private void SetDefaults()
		{
			ResetColor = base.BackColor;
			ChangeColorOnEnter = ClsControlConfig.ChangeColorOnEnter;
			base.CharacterCasing = ClsControlConfig.Case;
			ReadOnlyBackGroundColor = ClsControlConfig.ReadOnlyBackGroundColor;
			EnterBackGroundColor = ClsControlConfig.EnterBackGroundColor;
			DisableBackGroundColor = ClsControlConfig.DisableBackGroundColor;
		}
		#endregion		// #region Constructors/Initialization

		#region Overrides

		protected override void OnEnter(EventArgs e)
		{
			base.OnEnter(e);
			if (ChangeColorOnEnter == true && ReadOnly == false) base.BackColor = EnterBackGroundColor;
		}

		protected override void OnLeave(EventArgs e)
		{
			base.OnLeave(e);
			if (ChangeColorOnEnter == true) base.BackColor = ResetColor;
			if (this.ReadOnly == true) base.BackColor = ReadOnlyBackGroundColor;
			if (this.Enabled == false) base.BackColor = DisableBackGroundColor;
		}
		protected override void OnEnabledChanged(EventArgs e)
		{
			base.OnEnabledChanged(e);

			if (this.Enabled == false)
			{
				base.DisabledBackColor = DisableBackGroundColor;
				base.DisabledForeColor = Color.Black;
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

		protected override void OnTabIndexChanged(EventArgs e)
		{
			if (ChangingTab == true) return;
			try
			{
				ChangingTab = true;

				base.OnTabIndexChanged(e);
				if (lblText == null && lnkText == null) return;

				int tindex = (TabIndex > 0) ? TabIndex - 1 : 0;
				if (lblText != null)
					lblText.TabIndex = tindex;
				else
					lnkText.TabIndex = tindex;
			}
			finally
			{
				ChangingTab = false;
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
			if (lblText != null) lblText.Parent = Parent;
			if (lnkText != null) lnkText.Parent = Parent;
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

		protected override void SetVisibleCore(bool value)
		{
			base.SetVisibleCore(value);
			if (lblText != null) lblText.Visible = Visible;
			if (lnkText != null) lnkText.Visible = Visible;
		}
		#endregion		// #region Overrides

		#region Label

		protected ucLabel lblText;
		protected ucLinkLabel lnkText;

		[Description("Occurs when the link label is clicked")]
		public event LinkLabelLinkClickedEventHandler LinkClicked;

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
				if (_LabelAlignment == value) return;
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
				if (lblText != null)
					lblText.Text = value;
				else if (lnkText != null)
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
				if (_LabelType == value) return;
				_LabelType = value;
				AdjustLabel();
			}
		}

		private void AdjustLabel()
		{
			Control c = null;
			switch (LabelType)
			{
				case TextLabelType.None:
					if (lnkText != null) lnkText.Dispose();
					if (lblText != null) lblText.Dispose();
					lnkText = null;
					lblText = null;
					return;

				case TextLabelType.Label:
					if (lnkText != null) lnkText.Dispose();
					lnkText = null;

					if (lblText == null)
					{
						lblText = new ucLabel();
						lblText.Parent = Parent;
						lblText.Text = LabelText;
						lblText.UseMnemonic = true;
						lblText.TabIndex = (TabIndex > 0) ? TabIndex - 1 : 0;
					}
					c = lblText;
					break;

				case TextLabelType.Link:
					if (lblText != null) lblText.Dispose();
					lblText = null;

					if (lnkText == null)
					{
						lnkText = new ucLinkLabel();
						lnkText.Parent = Parent;
						lnkText.Text = LabelText;
						lnkText.UseMnemonic = true;
						lnkText.LinkClicked +=
							new LinkLabelLinkClickedEventHandler
							(lnkText_LinkClicked);
						lnkText.TabIndex = (TabIndex > 0) ? TabIndex - 1 : 0;
					}
					c = lnkText;
					break;

				default: break;
			}
			if (c == null) return;

			c.Visible = true;
			switch (LabelAlignment)
			{
				case Orientation.Left:
					c.Top = Top + (Height - c.Height) / 2;
					c.Left = Left - (c.Width + 2);
					break;

				case Orientation.Top:
					c.Top = Top - (c.Height + 2);
					c.Left = Left;
					break;

				case Orientation.Right:
					c.Top = Top + (Height - c.Height) / 2;
					c.Left = Left + Width + 2;
					break;

				default: break;
			}
		}

		private void lnkText_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (LinkClicked != null) LinkClicked(sender, e);
		}
		#endregion		// #region Label
	}
}