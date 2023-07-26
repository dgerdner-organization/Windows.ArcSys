using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using Janus.Windows.GridEX;

namespace CS2010.CommonWinCtrls
{
	[ToolboxItem(true)]
	[DesignTimeVisible(true)]
	[ToolboxBitmap(typeof(GridEXFieldChooserControl))]
	public partial class ucGridEXFieldChooserControl : GridEXFieldChooserControl
	{
		#region Constructors

		public ucGridEXFieldChooserControl()
		{
			InitializeComponent();
		}
		#endregion		// #region Constructors
	}
}