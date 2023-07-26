using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using CS2010.Common;

namespace CS2010.CommonWinCtrls
{
	[ToolboxItem(true)]
	[DesignTimeVisible(true)]
	[ToolboxBitmap(typeof(System.Windows.Forms.DateTimePicker))]
	public partial class ucDateTimePicker : DateTimePicker
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
			if( ChangeColorOnEnter == true ) base.BackColor = ResetColor;
			if( this.Enabled == false ) base.BackColor = DisableBackGroundColor;
		}
		protected override void OnEnabledChanged(EventArgs e)
		{
			base.OnEnabledChanged(e);

			if( this.Enabled == false )
			{

				base.ForeColor = Color.Black;
				base.TabStop = false;
			}
			else
			{
				base.BackColor = ResetColor;
				base.TabStop = true;
			}
		}

		protected override void OnNotifyMessage(Message m)
		{
			base.OnNotifyMessage(m);
		}

		#endregion		// #region Overrides

		#region Private Methods
		private void SetDefaults()
		{
			ResetColor = base.BackColor;
			ChangeColorOnEnter = ClsControlConfig.ChangeColorOnEnter;
			ReadOnlyBackGroundColor = ClsControlConfig.ReadOnlyBackGroundColor;
			EnterBackGroundColor = ClsControlConfig.EnterBackGroundColor;
			DisableBackGroundColor = ClsControlConfig.DisableBackGroundColor;

			this.Format = DateTimePickerFormat.Custom;
			this.CustomFormat = "yy - MM - dd";
		}
		#endregion

		#region Constructors

		protected ucMaskedTextBox txtDate;
		public ucMaskedTextBox TextBox
		{
			get { return txtDate; }
		}
		public ucDateTimePicker()
		{
			InitializeComponent();
			SetDefaults();
			/*txtDate = new ucMaskedTextBox();
			txtDate.Mask = "0000-00-00";
			txtDate.TextMaskFormat = MaskFormat.IncludeLiterals;
			txtDate.PromptChar = ' ';
			txtDate.Text = Value.ToString("yyyy-MM-dd");
			txtDate.AllowPromptAsInput = false;
			txtDate.AsciiOnly = true;
			txtDate.CutCopyMaskFormat = MaskFormat.IncludeLiterals;
			txtDate.HidePromptOnLeave = true;
			txtDate.InsertKeyMode = InsertKeyMode.Overwrite;
			txtDate.Validating += new CancelEventHandler(txtDate_Validating);
			txtDate.Validated += new EventHandler(txtDate_Validated);
			txtDate.KeyPress += new KeyPressEventHandler(txtDate_KeyPress);*/
		}

		void txtDate_KeyPress(object sender, KeyPressEventArgs e)
		{
			int st = txtDate.SelectionStart;
			if( st >= 5 && st <= 6 )
			{
				int mm = 0;
				if( st == 5 )
				{
					mm = int.Parse(e.KeyChar.ToString()) * 10;
					mm += int.Parse(txtDate.Text[6].ToString());
					if( mm < 1 || mm > 12 ) e.KeyChar = txtDate.Text[5];
				}
				else
				{
					mm = int.Parse(txtDate.Text[5].ToString()) * 10;
					mm += int.Parse(e.KeyChar.ToString());
					if( mm < 1 || mm > 12 ) e.KeyChar = txtDate.Text[6];
				}
				if( mm < 1 || mm > 12 )	e.Handled = true;
			}
			else if( st >= 8 && st <= 9 )
			{
				int dd = 0;
				if( st == 8 )
				{
					dd = int.Parse(e.KeyChar.ToString()) * 10;
					dd += int.Parse(txtDate.Text[9].ToString());
					if( dd < 1 || dd > 31 ) e.KeyChar = txtDate.Text[8];
				}
				else
				{
					dd = int.Parse(txtDate.Text[8].ToString()) * 10;
					dd += int.Parse(e.KeyChar.ToString());
					if( dd < 1 || dd > 31 ) e.KeyChar = txtDate.Text[9];
				}
				if( dd < 1 || dd > 31 ) e.Handled = true;
			}
		}

		void txtDate_Validated(object sender, EventArgs e)
		{
			DateTime res;
			if( DateTime.TryParse(txtDate.Text, out res) == false )
				return;
			Value = res;
		}

		void txtDate_Validating(object sender, CancelEventArgs e)
		{
			DateTime res;
			if( DateTime.TryParse(txtDate.Text, out res) == false )
			{
				e.Cancel = true;
				Display.ShowError("Date Error", "Invalid date entered {0}",
					txtDate.Text);
				txtDate.Text = Value.ToString("yyyy-MM-dd");
			}
			else
				e.Cancel = false;
		}

		protected override void OnValueChanged(EventArgs eventargs)
		{
			base.OnValueChanged(eventargs);
			//txtDate.Text = Value.ToString("yyyy-MM-dd");
		}
		protected override void OnParentChanged(EventArgs e)
		{
			base.OnParentChanged(e);
			//txtDate.Parent = Parent;
			//AdjustTextBox();
		}

		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			//AdjustTextBox();
		}
		protected override void OnMove(EventArgs e)
		{
			base.OnMove(e);
			//AdjustTextBox();
		}
		private void AdjustTextBox()
		{
			txtDate.Visible = true;
			txtDate.Location = Location;
			Size sz = Size;
			sz.Width = sz.Width - 20;
			txtDate.Size = sz;
			txtDate.BringToFront();
		}
		#endregion
	}
}