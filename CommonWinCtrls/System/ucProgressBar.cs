using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace CS2010.CommonWinCtrls
{
	[ToolboxItem(true)]
	[DesignTimeVisible(true)]
	[ToolboxBitmap(typeof(ProgressBar))]
	public partial class ucProgressBar : ProgressBar
	{
		#region Constructors

		public ucProgressBar()
		{
			InitializeComponent();
		}
		#endregion		// #region Constructors
	}
}