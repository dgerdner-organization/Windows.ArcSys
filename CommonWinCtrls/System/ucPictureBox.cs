using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace CS2010.CommonWinCtrls
{
	[ToolboxItem(true)]
	[DesignTimeVisible(true)]
	[ToolboxBitmap(typeof(PictureBox))]
	public partial class ucPictureBox : PictureBox
	{
		#region Constructors

		public ucPictureBox()
		{
			InitializeComponent();
		}
		#endregion		// #region Constructors
	}
}