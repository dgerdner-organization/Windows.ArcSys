using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace CS2010.CommonWinCtrls
{
	[ToolboxItem(true)]
	[DesignTimeVisible(true)]
	[ToolboxBitmap(typeof(RadioButton))]
	public partial class ucRadioButton : RadioButton
	{
		#region Constructors

		public ucRadioButton()
		{
			InitializeComponent();
		}
		#endregion		// #region Constructors
	}
}