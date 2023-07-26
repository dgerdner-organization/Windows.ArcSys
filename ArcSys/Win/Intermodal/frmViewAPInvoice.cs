using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Timers;
using CS2010.CommonSecurity;
using CS2010.Common;
using CS2010.CommonWinCtrls;
using CS2010.ArcSys.Business;
using System.IO;
using System.Data.Common;
using Janus.Windows.GridEX;

namespace CS2010.ArcSys.Win
{
	public partial class frmViewAPInvoice: frmChildBase, IViewWindow
	{
		private ClsApInvoice theInvoice;

		public frmViewAPInvoice() : base(Program.MainWindow, true)
		{
			InitializeComponent();
			InitWindow();	
		}

		public frmViewAPInvoice(bool showModal)	: base()
		{
			InitializeComponent();

			if (showModal == true)
			{
				MergeToolbar = null;
				MaximizeBox = false;
				ShowInTaskbar = false;
				FormBorderStyle = FormBorderStyle.FixedDialog;
			}
			else
				AdjustForm(Program.MainWindow, true, null);

			InitWindow();
		}

		public void ViewAPInvoice(ClsApInvoice anInvoice)
		{
			try
			{
				theInvoice = anInvoice;

				if (theInvoice == null)
				{
					Program.ShowError("No Invoice provided");
					return;
				}
				
				//AdjustForm(Program.MainWindow, true, null);
				if (MdiParent == null)
					ShowDialog();
				else
					Show();
			}
			catch (Exception ex)
			{
				Program.ShowError(ex, theInvoice);
			}
		}

		private void InitWindow()
		{
			try
			{
				WindowHelper.InitAllGrids(this);

				ClsSecurityMaster.SetSecurity(this, ClsEnvironment.User_Id.Value);

			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}


		#region IViewWindow Interface Implementation

		public ClsBaseTable TableObject
		{
			get { return theInvoice; }
		}

		public void ViewObject(ClsBaseTable bizObject)
		{
			ViewAPInvoice(bizObject as ClsApInvoice);
		}

		public void UpdateDisplay()
		{
			txtInvoiceNo.Text = theInvoice.Invoice_No;
			txtInvoiceDt.Value = theInvoice.Invoice_Dt;
			txtVendor.Text = theInvoice.Vendor.Vendor_Nm;

			DataTable dt = ClsApChargeDtl.GetForInvoice(theInvoice);
			grdChargeDetail.DataSource = dt;
		}

		#endregion

		private void frmViewAPInvoice_Load(object sender, EventArgs e)
		{
			try
			{
				UpdateDisplay();
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}
	}
}
