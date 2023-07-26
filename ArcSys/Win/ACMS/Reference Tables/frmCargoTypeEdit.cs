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
	public partial class frmCargoTypeEdit : frmChildBase
	{
		protected DataTable dtMain;
		protected string currentMode = "edit";
		protected ClsCargoCode currentItem;
		protected void SetCurrentItem()
		{
			DataRow drow = grdMain.GetDataRow();
			if (drow == null)
				currentItem = null;
			else
				currentItem = new ClsCargoCode(drow);
		}
		protected List<string> cargoTypes;
		protected List<string> wwlTypes;
		public frmCargoTypeEdit()
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
			cargoTypes = new List<string>();
			cargoTypes.Add("BLK");
			cargoTypes.Add("UNT");
			cargoTypes.Add("VEH");
			cmbType.DataSource = cargoTypes;
			wwlTypes = new List<string>();
			wwlTypes.Add("CAR");
			wwlTypes.Add("HIV");
			wwlTypes.Add("MCT");
			wwlTypes.Add("PCS");
			wwlTypes.Add("UNT");
			wwlTypes.Add("VAN");
            wwlTypes.Add("TRAILER");
            wwlTypes.Add("TRACKED");
			cmbWWLType.DataSource = wwlTypes;

			dtMain = ClsCargoCode.GetAll();
			grdMain.DataSource = dtMain;
			grdMain.Row = 1;
		}

		protected void BindItem()
		{
			SetCurrentItem();
			BindHelper.Bind(txtCode, currentItem, "Cargo_Code");
			BindHelper.Bind(txtDescription, currentItem, "Cargo_Dsc");
			BindHelper.Bind(txtMake, currentItem, "Make_Code");
			BindHelper.Bind(txtModel, currentItem, "Model_Code");
			BindHelper.Bind(txtLength, currentItem, "Length");
			BindHelper.Bind(txtHeight, currentItem, "Height");
			BindHelper.Bind(txtWidth, currentItem, "Width");
			BindHelper.Bind(txtWeight, currentItem, "Weight");
			BindHelper.Bind(txtYear, currentItem, "Cargo_Year");
			BindHelper.Bind(txtStenaCd, currentItem, "Stena_Vehicle_Type_Cd");
			BindHelper.Bind(cbxHide, currentItem, "Delete_Flg");
			//BindHelper.Bind(cmbType, currentItem, "Cargo_Type");
			//BindHelper.Bind(cmbWWLType, currentItem, "External_Cargo_Type");
			cmbType.SelectedItem = currentItem.Cargo_Type;
			cmbWWLType.SelectedItem = currentItem.External_Cargo_Type;

		}

		private void grdMain_SelectionChanged(object sender, EventArgs e)
		{
			if (grdMain.CurrentRow.RowType != Janus.Windows.GridEX.RowType.Record)
				return;
			BindItem();
			EnableEdit();
		}

		private void EnableEdit()
		{
			currentMode = "edit";
			grpEditEmail.Enabled = true;
			//grdMain.Enabled = false;
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
					ClsCargoCode cc = currentItem;
					cc.Cargo_Type = cmbType.SelectedItem.ToString();
					cc.External_Cargo_Type = cmbWWLType.SelectedItem.ToString();
					cc.Update();
				}
				//if (currentMode == "add")
				//{
				//    ClsPartnerEmail em = new ClsPartnerEmail();
				//    em.Partner_Cd = currentList.Partner_Cd;
				//    em.Email_List_Cd = currentList.Email_List_Cd;
				//    em.Outlook_Name = txtName.Text;
				//    em.Outlook_Email = txtEmail.Text;
				//    em.Insert();
				//    i = 1;
				//}
				grdMain.Enabled = btnEdit.Enabled = btnDelete.Enabled = btnAdd.Enabled = true;

				dtMain = ClsCargoCode.GetAll();
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
			currentMode = "add";
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			//ClsPartnerEmail em = currentEmail;
			//string sMsg = string.Format("Delete email for {0}?", em.Outlook_Name);
			//DialogResult dr = MessageBox.Show(sMsg, "Confirm", MessageBoxButtons.OKCancel);
			//if (dr == DialogResult.Cancel)
			//    return;

			//em.Delete();
			//dtEmails = ClsPartnerEmail.GetEmailList(currentList.Email_List_Cd);
			//grdEmails.DataSource = dtEmails;
		}

		private void frmCargoTypeEdit_Load(object sender, EventArgs e)
		{

		}

	}
}
