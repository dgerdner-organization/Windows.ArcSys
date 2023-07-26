using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using Janus.Windows.GridEX;

namespace CS2010.CommonWinCtrls
{
	[ToolboxItem(true)]
	[DesignTimeVisible(true)]
	[ToolboxBitmap(typeof(GridEXPrintDocument))]
	public partial class ucGridEXPrintDocument : GridEXPrintDocument
	{
		#region Constructors

		public ucGridEXPrintDocument()
		{
			InitializeComponent();
		}

		public ucGridEXPrintDocument(IContainer container)
		{
			container.Add(this);

			InitializeComponent();
		}
		#endregion		// #region Constructors
	}
}