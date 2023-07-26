using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;
using CS2010.Common;

namespace CS2010.CommonWinCtrls
{
	[ProvideProperty("LabelText", typeof(Control))]
	[ProvideProperty("LabelType", typeof(Control))]
	[ProvideProperty("LabelClick", typeof(Control))]
	[ProvideProperty("LabelStyleBold", typeof(Control))]
	[ProvideProperty("LabelAlignment", typeof(Control))]
	[ToolboxItem(true), DesignTimeVisible(true), ToolboxBitmap(typeof(Component))]
	public partial class ucLabelExtender : Component, IExtenderProvider
	{
		#region Fields

		protected Dictionary<Control, bool> Bold;
		protected Dictionary<Control, Label> Labels;
		protected Dictionary<Control, Orientation> Alignments;
		protected Dictionary<Control, TextLabelType> LabelTypes;
		protected Dictionary<Control, LinkLabelLinkClickedEventHandler> Clicks;

		#endregion		// #region Fields
	
		#region Constructors

		public ucLabelExtender()
		{
			InitializeComponent();
			Labels = new Dictionary<Control, Label>();
			Alignments = new Dictionary<Control, Orientation>();
			LabelTypes = new Dictionary<Control, TextLabelType>();
			Clicks = new Dictionary<Control, LinkLabelLinkClickedEventHandler>();
			Bold = new Dictionary<Control, bool>();
		}
		#endregion		// #region Constructors

		#region IExtenderProvider Members

		public bool CanExtend(object extendee)
		{
			return ( !( extendee is ucLabelExtender ) && !( extendee is Label ) &&
				(extendee is Control) );
		}
		#endregion

		#region Event Handlers

		protected void OnMove(object sender, EventArgs e)
		{
			Control c = sender as Control;
			Label lbl = GetLabelFromDictionary(c);
			if( lbl != null ) AdjustLabel(c, lbl);
		}

		protected void OnResize(object sender, EventArgs e)
		{
			Control c = sender as Control;
			Label lbl = GetLabelFromDictionary(c);
			if( lbl != null ) AdjustLabel(c, lbl);
		}

		protected void OnParentChanged(object sender, EventArgs e)
		{
			Control c = sender as Control;
			Label lbl = GetLabelFromDictionary(c);
			if( lbl != null )
			{
				lbl.Parent = c.Parent;
				AdjustLabel(c, lbl);
			}
		}

		protected void OnVisibleChanged(object sender, EventArgs e)
		{
			Control c = sender as Control;
			Label lbl = GetLabelFromDictionary(c);
			if( lbl != null )
			{
				lbl.Visible = c.Visible;
				AdjustLabel(c, lbl);
			}
		}

		protected void OnDispose(object sender, EventArgs e)
		{
			Control c = sender as Control;
			Clicks.Remove(c);
			LabelTypes.Remove(c);
			Alignments.Remove(c);
			SetLabelText(c, null);
		}
		#endregion		// #region Event Handlers

		#region IExtenderProvider Implementation - Get Methods

		protected Label GetLabelFromDictionary(Control c)
		{
			if( c == null ) return null;

			return ( Labels.ContainsKey(c) ) ? Labels[c] : null;
		}

		[DefaultValue("")]
		public string GetLabelText(Control c)
		{
			Label lbl = GetLabelFromDictionary(c);
			return ( lbl != null ) ? lbl.Text.Trim() : string.Empty;
		}

		[DefaultValue(typeof(Orientation), "Left"),
		Description("Gets/Sets where the label text appears relative to this control")]
		public Orientation GetLabelAlignment(Control c)
		{
			if( c == null ) return Orientation.Left;

			return ( Alignments.ContainsKey(c) ) ? Alignments[c] : Orientation.Left;
		}

		[DefaultValue(typeof(TextLabelType), "Label"),
		Description("Gets/Sets the type of label (Label, LinkLabel")]
		public TextLabelType GetLabelType(Control c)
		{
			if( c == null ) return TextLabelType.Label;

			return ( LabelTypes.ContainsKey(c) ) ? LabelTypes[c] : TextLabelType.Label;
		}

		[DefaultValue(false), Description("Gets/Sets whether the label style is bold")]
		public bool GetLabelStyleBold(Control c)
		{
			if( c == null ) return false;

			return ( Bold.ContainsKey(c) ) ? Bold[c] : false;
		}

		[Browsable(true), DefaultValue(null), Category("")]
		public LinkLabelLinkClickedEventHandler GetLabelClick(Control c)
		{
			if( c == null ) return null;

			return ( Clicks.ContainsKey(c) ) ? Clicks[c] : null;
		}
		#endregion		// #region IExtenderProvider Implementation - Get Methods

		#region IExtenderProvider Implementation - Set Methods

		public void SetLabelText(Control c, string value)
		{
			if( string.IsNullOrEmpty(value) == true )
			{
				Label lbl = GetLabelFromDictionary(c);
				if( lbl != null ) SetLabelClick(c, null);

				Labels.Remove(c);
				lbl.Dispose();

				c.Disposed -= new EventHandler(OnDispose);
				c.Move -= new EventHandler(OnMove);
				c.Resize -= new EventHandler(OnResize);
				c.ParentChanged -= new EventHandler(OnParentChanged);
				c.VisibleChanged -= new EventHandler(OnVisibleChanged);
			}
			else
			{
				TextLabelType lblType = GetLabelType(c);

				Label lbl = ( lblType == TextLabelType.Link )
					? (Label)new ucLinkLabel() : (Label)new ucLabel();
				lbl.Text = value;
				lbl.AutoSize = true;
				lbl.BackColor = Color.Transparent;
				Labels[c] = lbl;

				AdjustLabel(c, lbl);

				LinkLabel lnkLbl = lbl as LinkLabel;
				if( lnkLbl != null )
				{
					LinkLabelLinkClickedEventHandler ev = GetLabelClick(c);
					if( ev != null ) lnkLbl.LinkClicked += ev;
				}

				c.Disposed += new EventHandler(OnDispose);
				c.Move += new EventHandler(OnMove);
				c.Resize += new EventHandler(OnResize);
				c.ParentChanged += new EventHandler(OnParentChanged);
				c.VisibleChanged += new EventHandler(OnVisibleChanged);
			}
		}

		public void SetLabelType(Control c, TextLabelType value)
		{
			if( value == TextLabelType.None ) return;

			Label lbl = GetLabelFromDictionary(c);
			TextLabelType oldType = GetLabelType(c);
			if( lbl != null )
			{
				if( oldType != value )
				{
					string s = GetLabelText(c);
					SetLabelText(c, null);

					LabelTypes[c] = value;
					SetLabelText(c, s);
				}
				else
					AdjustLabel(c, lbl);
			}
			else
				LabelTypes[c] = value;
		}

		public void SetLabelAlignment(Control c, Orientation value)
		{
			Alignments[c] = value;
			Label lbl = GetLabelFromDictionary(c);
			if( lbl != null ) AdjustLabel(c, lbl);
		}

		public void SetLabelStyleBold(Control c, bool value)
		{
			Bold[c] = value;
			Label lbl = GetLabelFromDictionary(c);
			if( lbl != null ) AdjustLabel(c, lbl);
		}

		public void SetLabelClick(Control c, LinkLabelLinkClickedEventHandler value)
		{
			LinkLabel lnkLbl = GetLabelFromDictionary(c) as LinkLabel;
			LinkLabelLinkClickedEventHandler oldEv = GetLabelClick(c);

			if( lnkLbl != null )
			{
				if( oldEv != null ) lnkLbl.LinkClicked -= oldEv;
				if( value != null) lnkLbl.LinkClicked += value;
			}
			Clicks[c] = value;
		}

		private void AdjustLabel(Control c, Label lbl)
		{
			lbl.UseMnemonic = true;
			lbl.Parent = c.Parent;
			lbl.Visible = c.Visible;
			if( c.TabIndex == 0 ) c.TabIndex = 1;
			lbl.TabIndex =  c.TabIndex - 1;
			lbl.AutoSize = true;

			Orientation lblAlign = GetLabelAlignment(c);
			TextLabelType lblType = GetLabelType(c);

			LinkLabel lnkLbl = lbl as LinkLabel;
			if( lnkLbl != null )
			{
				lnkLbl.LinkVisited = false;
				lnkLbl.LinkColor = Color.Blue;
				lnkLbl.LinkBehavior = LinkBehavior.AlwaysUnderline;
			}

			bool isBold = GetLabelStyleBold(c);
			lbl.Font = new Font(lbl.Font, ( isBold ? FontStyle.Bold : FontStyle.Regular ));

			switch( lblAlign )
			{
				case Orientation.Left:
					TextBox txt = c as TextBox;
					if( txt != null && txt.Multiline == true )
						lbl.Top = c.Top + 2;
					else
						lbl.Top = c.Top + ( c.Height - lbl.Height ) / 2;
					lbl.Left = c.Left - ( lbl.Width + 2 );
					break;

				case Orientation.Top:
					lbl.Top = c.Top - ( lbl.Height + 2 );
					lbl.Left = c.Left;
					break;

				case Orientation.Right:
					lbl.Top = c.Top + ( c.Height - lbl.Height ) / 2;
					lbl.Left = c.Left + c.Width + 2;
					break;

				default: break;
			}
		}
		#endregion		// #region IExtenderProvider Implementation - Set Methods
	}
}