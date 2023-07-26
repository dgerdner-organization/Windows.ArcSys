using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using CS2010.Common;

namespace CS2010.CommonWinCtrls
{
	[ToolboxItem(true)]
	[DesignTimeVisible(true)]
	[ToolboxBitmap(typeof(Label))]
	public partial class ucLabel : Label
	{
		#region Constants

		public const string DefaultText = "Label";

		#endregion		// #region Constants

		#region Fields

		protected Color ResetColor;
		protected Color DisableBackGroundColor;

		#endregion		// #region Fields

		#region Properties

		[DefaultValue(true)]
		public new bool AutoSize
		{
			get { return base.AutoSize; }
			set { base.AutoSize = value; }
		}
		#endregion		// #region Properties

		#region Constructors

		public ucLabel()
		{
			InitializeComponent();

			ResetColor = base.BackColor;
			DisableBackGroundColor = ClsControlConfig.DisableBackGroundColor;

			base.AutoSize = true;
		}
		#endregion		// #region Constructors

		#region Overrides

		protected override void OnLeave(EventArgs e)
		{
			base.OnLeave(e);
			if( this.Enabled == false ) base.BackColor = DisableBackGroundColor;
		}

		protected override void OnEnabledChanged(EventArgs e)
		{
			base.OnEnabledChanged(e);

			if( this.Enabled == false )
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
		#endregion		// #region Overrides
	}

	#region Enums

	/// <summary>Used to specify the type of "label" that can be displayed with a
	/// control (use "None" to prevent a label from appearing)</summary>
	public enum TextLabelType
	{
		/// <summary>Prevents a label/link from being displayed</summary>
		None,
		/// <summary>Used to display a ucLabel with the control</summary>
		Label,
		/// <summary>Used to display a ucLinkLabel with the control</summary>
		Link
	}

	/// <summary>Used to specify where the "label" will appear relative to the
	/// control</summary>
	public enum Orientation
	{
		/// <summary>The label/link will appear to the left of the control</summary>
		Left,
		/// <summary>The label/link will appear above the control</summary>
		Top,
		/// <summary>The label/link will appear to the right of the control</summary>
		Right
	};
	#endregion		// #region Enums
}