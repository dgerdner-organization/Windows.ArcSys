using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using CS2010.Common;

namespace CS2010.CommonWinCtrls
{
	[ToolboxItem(true), DesignTimeVisible(true), ToolboxBitmap(typeof(TextBox))]
	public partial class ucTextBoxPK : ucTextBox
	{
		#region Constructors

		public ucTextBoxPK()
		{
			InitializeComponent();
		}
		#endregion		// #region Constructors

		#region Overrides

		protected override void OnKeyPress(KeyPressEventArgs e)
		{
			e.Handled = !char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != '\b';
			base.OnKeyPress(e);
		}
		#endregion		// #region Overrides
	}
}