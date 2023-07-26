using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using Janus.Windows.GridEX.Export;

namespace CS2010.CommonWinCtrls
{
	[ToolboxItem(true)]
	[DesignTimeVisible(true)]
	[ToolboxBitmap(typeof(GridEXExporter))]
	public partial class ucGridEXExporter : GridEXExporter
	{
		#region Constructors

		public ucGridEXExporter()
		{
			InitializeComponent();
		}

		public ucGridEXExporter(IContainer container)
		{
			container.Add(this);

			InitializeComponent();
		}
		#endregion		// #region Constructors
	}
}