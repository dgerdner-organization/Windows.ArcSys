using System;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;

namespace CS2010.CommonWinCtrls
{
	/// <summary>A custom collapsible splitter that can resize, hide and show associated form controls</summary>
	[ToolboxBitmap(typeof(System.Windows.Forms.Splitter))]
	public partial class ucCollapsibleSplitter : Splitter
	{
		#region Fields/Properties

		private bool hot;
		private int controlWidth;
		private int controlHeight;

		private SplitterState currentState;
		private Form frmParent;
		private Rectangle rr;
		private Color HotColor = CalculateColor(SystemColors.Highlight, SystemColors.Window, 70);

		/// <summary>The Control that the splitter will collapse</summary>
		[Bindable(true), Category("Collapsing Options"), DefaultValue(null),
		Description("The Control that the splitter will collapse")]
		public Control ControlToHide { get; set; }

		/// <summary>When true the entire parent form will be expanded and collapsed,
		/// otherwise just the contol to expand will be changed</summary>
		[Bindable(true), Category("Collapsing Options"), DefaultValue(false),
		Description("When true the entire parent form will be expanded and collapsed, otherwise just the contol to expand will be changed")]
		public bool ExpandParentForm { get; set; }

		private Border3DStyle _BorderStyle3D = Border3DStyle.Flat;
		/// <summary>An optional border style to paint on the control. Set to Flat for no border</summary>
		[Bindable(true), Category("Collapsing Options"),
		DefaultValue(typeof(Border3DStyle), "Flat"),
		Description("An optional border style to paint on the control. Set to Flat for no border")]
		public Border3DStyle BorderStyle3D
		{
			get { return this._BorderStyle3D; }
			set
			{
				this._BorderStyle3D = value;
				this.Invalidate();
			}
		}

		/// <summary>The initial state of the Splitter. Set to True if the control to hide is not
		/// visible by default</summary>
		[Bindable(true), Category("Collapsing Options"), DefaultValue(false), Browsable(false),
		Description("The initial state of the Splitter. Set to True if the control to hide is not visible by default")]
		public bool IsCollapsed
		{
			get { return (ControlToHide != null) ? !ControlToHide.Visible : true; }
		}

		[Category("Collapsing Options"),
		Description("Occurs when the splitter status is changed (when collapsed property is toggled)")]
		public event EventHandler SplitterCollapseChanged;

		protected void OnSplitterCollapseChanged()
		{
			if (SplitterCollapseChanged != null) SplitterCollapseChanged(this, EventArgs.Empty);
		}
		#endregion		// #region Fields/Properties

		#region Constructors

		public ucCollapsibleSplitter()
		{
			InitializeComponent();

			_BorderStyle3D = Border3DStyle.Flat;

			ExpandParentForm = false;
		}
		#endregion		// #region Constructors

		#region Overrides

		protected override void OnMouseDown(MouseEventArgs e)
		{	// if the hider control isn't hot, let the base resize action occur
			if (this.ControlToHide != null)
			{
				if (!this.hot && this.ControlToHide.Visible)
					base.OnMouseDown(e);
			}
		}

		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);

			this.Invalidate();
		}

		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
			// check to see if the mouse cursor position is within the bounds of our control
			if (e.X >= rr.X && e.X <= rr.X + rr.Width && e.Y >= rr.Y && e.Y <= rr.Y + rr.Height)
			{
				if (!this.hot)
				{
					this.hot = true;
					this.Cursor = Cursors.Hand;
					this.Invalidate();
				}
			}
			else
			{
				if (this.hot)
				{
					this.hot = false;
					this.Invalidate();
				}


				if (ControlToHide != null)
				{
					if (!ControlToHide.Visible)
						this.Cursor = Cursors.Default;
					else
					{
						this.Cursor = (this.Dock == DockStyle.Left || this.Dock == DockStyle.Right)
							? Cursors.VSplit : Cursors.HSplit;
					}
				}
				else
					this.Cursor = Cursors.Default;
			}
		}

		protected override void OnMouseLeave(EventArgs e)
		{
			base.OnMouseLeave(e);
			// ensure that the hot state is removed
			this.hot = false;
			this.Invalidate();
		}

		protected override void OnClick(EventArgs e)
		{
			base.OnClick(e);
			if (ControlToHide != null && hot && currentState != SplitterState.Collapsing &&
				currentState != SplitterState.Expanding)
				ToggleSplitter();
		}

		protected override void OnMouseHover(EventArgs e)
		{
			//base.OnMouseHover(e);
			//if (ControlToHide != null && hot && currentState != SplitterState.Collapsing &&
//				currentState != SplitterState.Expanding && ControlToHide.Visible == false )
				//ToggleSplitter();
		}

		public void CollapseSplitter()
		{
			if (ControlToHide != null && ControlToHide.Visible == true)
			{
				ToggleSplitter();
			}
		}
		public void ExpandSplitter()
		{
			if (ControlToHide != null && ControlToHide.Visible == false)
			{
				ToggleSplitter();
			}
		}

		public void ToggleSplitter()
		{	// if in progress for this control, drop out
			if (currentState == SplitterState.Collapsing || currentState == SplitterState.Expanding)
				return;

			try
			{
				controlWidth = ControlToHide.Width;
				controlHeight = ControlToHide.Height;

				if (ControlToHide.Visible)
				{
					currentState = SplitterState.Collapsed;
					ControlToHide.Visible = false;
					if (ExpandParentForm && frmParent != null)
					{
						if (this.Dock == DockStyle.Left || this.Dock == DockStyle.Right)
							frmParent.Width -= ControlToHide.Width;
						else
							frmParent.Height -= ControlToHide.Height;
					}
				}
				else
				{	// control to hide is collapsed, just toggle the visible state
					currentState = SplitterState.Expanded;
					ControlToHide.Visible = true;
					if (ExpandParentForm && frmParent != null)
					{
						if (this.Dock == DockStyle.Left || this.Dock == DockStyle.Right)
							frmParent.Width += ControlToHide.Width;
						else
							frmParent.Height += ControlToHide.Height;
					}
				}
			}
			finally
			{
				OnSplitterCollapseChanged();
			}
		}

		protected override void OnHandleCreated(EventArgs e)
		{
			base.OnHandleCreated(e);
			this.frmParent = this.FindForm();

			if (this.ControlToHide != null) // set the current state
				this.currentState = (this.ControlToHide.Visible)
					? SplitterState.Expanded : SplitterState.Collapsed;
		}

		protected override void OnEnabledChanged(System.EventArgs e)
		{
			base.OnEnabledChanged(e);
			this.Invalidate();
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			Graphics g = null;
			Pen imageOutline = null, imageDots = null;
			SolidBrush imageBackColor = null, clientRectBrush = null, arrowColor = null;
			try
			{
				g = e.Graphics;

				Color ctrlBackColor = (hot) ? HotColor : this.BackColor;
				imageBackColor = new SolidBrush(ctrlBackColor);
				imageOutline = new Pen(SystemColors.ControlDark, 1);
				imageDots = new Pen(SystemColors.ControlDark);
				arrowColor = new SolidBrush(SystemColors.ControlDarkDark);

				// find the rectangle for the splitter and paint it
				Rectangle r = this.ClientRectangle;
				clientRectBrush = new SolidBrush(this.BackColor);
				g.FillRectangle(clientRectBrush, r);

				#region Vertical Splitter

				// Check the docking style and create the control rectangle accordingly
				if (this.Dock == DockStyle.Left || this.Dock == DockStyle.Right)
				{	// create a new rectangle in the vertical center of the splitter for our collapse control button
					rr = new Rectangle(r.X, (int)r.Y + ((r.Height - 115) / 2), 8, 115);
					this.Width = 8;		// force the width to 8px so that everything always draws correctly

					// draw the background color for our control image
					g.FillRectangle(imageBackColor, new Rectangle(rr.X + 1, rr.Y, 6, 115));

					// draw the top & bottom lines for our control image
					g.DrawLine(imageOutline, rr.X + 1, rr.Y, rr.X + rr.Width - 2, rr.Y);
					g.DrawLine(imageOutline, rr.X + 1, rr.Y + rr.Height, rr.X + rr.Width - 2, rr.Y + rr.Height);

					if (this.Enabled)	// draw the arrows for our control image
					{		// the ArrowPointArray is a point array that defines an arrow shaped polygon
						g.FillPolygon(arrowColor, ArrowPointArray(rr.X + 2, rr.Y + 3));
						g.FillPolygon(arrowColor, ArrowPointArray(rr.X + 2, rr.Y + rr.Height - 9));
					}

					int x = rr.X + 3;
					int y = rr.Y + 14;
					for (int i = 0; i < 44; i++)
					{	// draw the dots for our control image using a loop
						g.DrawLine(imageDots, x, y + (i * 2), x + 2, y + (i * 2));
					}

					if (this._BorderStyle3D != System.Windows.Forms.Border3DStyle.Flat)
					{	// Paint the control border
						ControlPaint.DrawBorder3D(e.Graphics, this.ClientRectangle, this._BorderStyle3D, Border3DSide.Left);
						ControlPaint.DrawBorder3D(e.Graphics, this.ClientRectangle, this._BorderStyle3D, Border3DSide.Right);
					}
				}
				#endregion		// #region Vertical Splitter

				#region Horizontal Splitter

				else if (this.Dock == DockStyle.Top || this.Dock == DockStyle.Bottom)
				{	// create a new rectangle in the horizontal center of the splitter for our collapse control button
					rr = new Rectangle((int)r.X + ((r.Width - 115) / 2), r.Y, 115, 8);
					this.Height = 8;		// force the height to 8px

					g.FillRectangle(imageBackColor, new Rectangle(rr.X, rr.Y + 1, 115, 6));

					// draw the left & right lines for our control image
					g.DrawLine(imageOutline, rr.X, rr.Y + 1, rr.X, rr.Y + rr.Height - 2);
					g.DrawLine(imageOutline, rr.X + rr.Width, rr.Y + 1, rr.X + rr.Width, rr.Y + rr.Height - 2);

					if (this.Enabled)	// draw the arrows for our control image
					{	// the ArrowPointArray is a point array that defines an arrow shaped polygon
						g.FillPolygon(arrowColor, ArrowPointArray(rr.X + 3, rr.Y + 2));
						g.FillPolygon(arrowColor, ArrowPointArray(rr.X + rr.Width - 9, rr.Y + 2));
					}

					int x = rr.X + 14;
					int y = rr.Y + 3;
					for (int i = 0; i < 44; i++)
					{	// draw the dots for our control image using a loop
						g.DrawLine(imageDots, x + (i * 2), y, x + (i * 2), y + 2);
					}

					if (this._BorderStyle3D != System.Windows.Forms.Border3DStyle.Flat)
					{	// Paint the control border
						ControlPaint.DrawBorder3D(e.Graphics, this.ClientRectangle, this._BorderStyle3D, Border3DSide.Top);
						ControlPaint.DrawBorder3D(e.Graphics, this.ClientRectangle, this._BorderStyle3D, Border3DSide.Bottom);
					}
				}
				#endregion		// #region Horizontal Splitter

				else
				{
					throw new Exception("The Collapsible Splitter control cannot have the Filled or None Dockstyle property");
				}
			}
			finally
			{
				try
				{
					if (g != null) g.Dispose();
					if (clientRectBrush != null) clientRectBrush.Dispose();
					if (imageBackColor != null) imageBackColor.Dispose();
					if (imageOutline != null) imageOutline.Dispose();
					if (arrowColor != null) arrowColor.Dispose();
					if (imageDots != null) imageDots.Dispose();
				}
				catch (Exception ex)
				{
					MessageBox.Show("Error cleaning up graphics resources\r\n" + ex.ToString());
				}
			}
		}
		#endregion		// #region Overrides

		#region Helper Methods

		// This creates a point array to draw a arrow-like polygon
		private Point[] ArrowPointArray(int x, int y)
		{
			Point[] point = new Point[3];

			if (ControlToHide != null)
			{	// decide which direction the arrow will point
				if ((this.Dock == DockStyle.Right && ControlToHide.Visible) ||
					(this.Dock == DockStyle.Left && !ControlToHide.Visible) )
				{	// right arrow
					point[0] = new Point(x, y);
					point[1] = new Point(x + 3, y + 3);
					point[2] = new Point(x, y + 6);
				}
				else if ( (this.Dock == DockStyle.Right && !ControlToHide.Visible) ||
					(this.Dock == DockStyle.Left && ControlToHide.Visible) )
				{	// left arrow
					point[0] = new Point(x + 3, y);
					point[1] = new Point(x, y + 3);
					point[2] = new Point(x + 3, y + 6);
				}
				else if ((this.Dock == DockStyle.Top && ControlToHide.Visible) ||
					(this.Dock == DockStyle.Bottom && !ControlToHide.Visible) )
				{	// up arrow
					point[0] = new Point(x + 3, y);
					point[1] = new Point(x + 6, y + 4);
					point[2] = new Point(x, y + 4);
				}
				else if ( (this.Dock == DockStyle.Top && !ControlToHide.Visible) ||
					(this.Dock == DockStyle.Bottom && ControlToHide.Visible) )
				{	// down arrow
					point[0] = new Point(x, y);
					point[1] = new Point(x + 6, y);
					point[2] = new Point(x + 3, y + 3);
				}
			}

			return point;
		}

		private static Color CalculateColor(Color front, Color back, int alpha)
		{	// solid color obtained as a result of alpha-blending
			Color frontColor = Color.FromArgb(255, front);
			Color backColor = Color.FromArgb(255, back);

			float frontRed = frontColor.R;
			float frontGreen = frontColor.G;
			float frontBlue = frontColor.B;
			float backRed = backColor.R;
			float backGreen = backColor.G;
			float backBlue = backColor.B;

			float fRed = frontRed * alpha / 255 + backRed * ((float)(255 - alpha) / 255);
			byte newRed = (byte)fRed;
			float fGreen = frontGreen * alpha / 255 + backGreen * ((float)(255 - alpha) / 255);
			byte newGreen = (byte)fGreen;
			float fBlue = frontBlue * alpha / 255 + backBlue * ((float)(255 - alpha) / 255);
			byte newBlue = (byte)fBlue;

			return Color.FromArgb(255, newRed, newGreen, newBlue);
		}
		#endregion		// #region Helper Methods
	}

	#region Enums

	/// <summary>Enumeration to specify the current animation state of the control.</summary>
	public enum SplitterState
	{
		Collapsed = 0,
		Expanding,
		Expanded,
		Collapsing
	}
	#endregion		// #region Enums
}