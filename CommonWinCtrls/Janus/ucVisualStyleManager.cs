using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using Janus.Windows.Common;

namespace CS2010.CommonWinCtrls
{
	[ToolboxItem(true)]
	[DesignTimeVisible(true)]
	[ToolboxBitmap(typeof(VisualStyleManager))]
	public partial class ucVisualStyleManager : VisualStyleManager
	{
		#region Constructors

		public ucVisualStyleManager()
		{
			InitializeComponent();
		}

		public ucVisualStyleManager(IContainer container)
		{
			container.Add(this);

			InitializeComponent();
		}
		#endregion		// #region Constructors
	}
}