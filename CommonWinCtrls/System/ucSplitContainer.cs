using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace CS2010.CommonWinCtrls
{
	[ToolboxItem(true)]
	[DesignTimeVisible(true)]
	[ToolboxBitmap(typeof(SplitContainer))]
	public partial class ucSplitContainer : SplitContainer
	{
		#region Constructors

		public ucSplitContainer()
		{
			InitializeComponent();
		}
		#endregion		// #region Constructors
	}
}