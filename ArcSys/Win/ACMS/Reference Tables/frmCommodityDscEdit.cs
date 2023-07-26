using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CS2010.CommonWinCtrls;
using CS2010.ACMS.Business;

namespace CS2010.ArcSys.Win
{
	public partial class frmCommodityDscEdit : frmChildBase
	{
		protected DataTable dtMain;
		protected string currentMode = "edit";
		protected ClsCommodityDsc currentItem;
		protected void SetCurrentItem()
		{
			DataRow drow = grdMain.GetDataRow();
			if (drow == null)
				currentItem = null;
			else
			{
				currentItem = new ClsCommodityDsc(drow);
			}
		}
		public frmCommodityDscEdit()
		{
			InitializeComponent();
		}
		public void ShowWindow()
		{

			this.MdiParent = Program.MainWindow;
			this.Activate();
			this.Show();
			this.WindowState = FormWindowState.Maximized;
			InitForm();
		}

		public void InitForm()
		{
			dtMain = ClsCommodityDsc.GetAll();
			grdMain.DataSource = dtMain;
			grdMain.Row = 1;
		}

		protected void BindItem()
		{
			BindHelper.Bind(txtCode, currentItem, "Commodity_Cd");
			BindHelper.Bind(txtDescription, currentItem, "Commodity_Dsc");
			BindHelper.Bind(cbxHide, currentItem, "Delete_Fl");
		}

		private void grdMain_SelectionChanged(object sender, EventArgs e)
		{
			if (grdMain.CurrentRow.RowType != Janus.Windows.GridEX.RowType.Record)
				return;
			SetCurrentItem();
			BindItem();
			//EnableEdit();
		}

		private void EnableEdit()
		{
			currentMode = "edit";
			grpEditEmail.Enabled = true;
			grdMain.Enabled = false;
			btnEdit.Enabled = btnAdd.Enabled = btnDelete.Enabled = false;
		}
		private void btnEdit_Click(object sender, EventArgs e)
		{
			EnableEdit();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			grpEditEmail.Enabled = false;
			grdMain.Enabled = true;
			SetCurrentItem();
			BindItem();
			btnEdit.Enabled = btnAdd.Enabled = btnDelete.Enabled = true;
		}

		private void Save_Click(object sender, EventArgs e)
		{
			try
			{
				int i = grdMain.Row;
				if (currentMode == "edit")
				{
					ClsCommodityDsc cc = currentItem;
					cc.Update();
				}
				if (currentMode == "add")
				{
				    ClsCommodityDsc cm = new ClsCommodityDsc();
				    cm.Commodity_Cd = txtCode.Text;
					cm.Commodity_Dsc = txtDescription.Text;
					cm.Delete_Fl = "N";
					cm.Insert();
				    i = 1;
				}
				grdMain.Enabled = btnEdit.Enabled = btnDelete.Enabled = btnAdd.Enabled = true;

				dtMain = ClsCommodityDsc.GetAll();
				grdMain.DataSource = dtMain;
				grdMain.Row = i;
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
				return;
			}
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			grpEditEmail.Enabled = true;
			currentItem = new ClsCommodityDsc();
			BindItem();
			currentMode = "add";
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			ClsCommodityDsc cm = currentItem;
			string sMsg = string.Format("Delete {0}?", currentItem.Commodity_Cd);
			DialogResult dr = MessageBox.Show(sMsg, "Confirm", MessageBoxButtons.OKCancel);
			if (dr == DialogResult.Cancel)
			    return;

			cm.Delete();
			dtMain = ClsCommodityDsc.GetAll();
			grdMain.DataSource = dtMain;
		}

		private void frmCargoTypeEdit_Load(object sender, EventArgs e)
		{

		}

	}
}
