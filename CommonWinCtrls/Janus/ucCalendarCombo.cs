using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using Janus.Windows.CalendarCombo;
using CS2010.Common;

namespace CS2010.CommonWinCtrls
{
	[ToolboxItem(true)]
	[DesignTimeVisible(true)]
	[ToolboxBitmap(typeof(CalendarCombo))]
	public partial class ucCalendarCombo : CalendarCombo
	{
		#region Fields
		protected Color _ResetColor;
		protected Boolean _ChangeColorOnEnter;
		protected CharacterCasing _Case;
		protected Color _ReadOnlyBackGroundColor;
		protected Color _EnterBackGroundColor;
		protected Color _DisableBackGroundColor;
		#endregion		// #region Fields

		#region Properties
		private CharacterCasing Case
		{
			get { return _Case; }
			set { _Case = value; }
		}
		private Color ResetColor
		{
			get { return _ResetColor; }
			set { _ResetColor = value; }
		}
		private Color EnterBackGroundColor
		{
			get { return _EnterBackGroundColor; }
			set { _EnterBackGroundColor = value; }
		}
		private Boolean ChangeColorOnEnter
		{
			get { return _ChangeColorOnEnter; }
			set { _ChangeColorOnEnter = value; }
		}
		private Color ReadOnlyBackGroundColor
		{
			get { return _ReadOnlyBackGroundColor; }
			set { _ReadOnlyBackGroundColor = value; }
		}
		private Color DisableBackGroundColor
		{
			get { return _DisableBackGroundColor; }
			set { _DisableBackGroundColor = value; }
		}
		#endregion		// #region Properties

		#region Overrides
		protected override void OnEnter(EventArgs e)
		{
			base.OnEnter(e);
			if( ChangeColorOnEnter == true ) base.BackColor = EnterBackGroundColor;
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
		//protected override void OnReadOnlyChanged(EventArgs e)
		//{
		//    base.OnReadOnlyChanged(e);

		//    if (this.ReadOnly == true)
		//    {
		//        base.BackColor = ReadOnlyBackGroundColor;
		//        base.ForeColor = Color.Black;
		//        base.TabStop = false;
		//    }
		//    else
		//    {
		//        base.BackColor = ResetColor;
		//        base.TabStop = true;
		//    }
		//}

		#endregion		// #region Overrides

		#region Private Methods
		private void SetDefaults()
		{
			ResetColor = base.BackColor;
			ChangeColorOnEnter = ClsControlConfig.ChangeColorOnEnter;
			ReadOnlyBackGroundColor = ClsControlConfig.ReadOnlyBackGroundColor;
			EnterBackGroundColor = ClsControlConfig.EnterBackGroundColor;
			DisableBackGroundColor = ClsControlConfig.DisableBackGroundColor;
		}
		#endregion

		#region Constructors

		public ucCalendarCombo()
		{
			InitializeComponent();
			SetDefaults();
		}
		#endregion		// #region Constructors
	}
}