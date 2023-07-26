using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CS2010.ArcSys.Win
{
	public partial class frmSterlingReportsHelp : Form
	{
		public frmSterlingReportsHelp()
		{
			InitializeComponent();
			string x = rtfMain.Text;
			rtfMain.Rtf = x;
		}
	}
}
