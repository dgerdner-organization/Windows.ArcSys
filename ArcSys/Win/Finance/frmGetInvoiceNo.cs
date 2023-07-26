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
	public partial class frmGetInvoiceNo : Form
	{
		public string InvoiceNo
		{
			get { return txtInvoiceNo.Text; }
			set { txtInvoiceNo.Text = value; }
		}
		public frmGetInvoiceNo()
		{
			InitializeComponent();
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
