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
	public partial class frmMailListEdit : frmChildBase
	{
		protected DataTable dtEmails;
		protected string currentMode = "edit";
		protected ClsPartnerEmailList currentList
		{
			get
			{
				DataRow drow = grdEmailList.GetDataRow();
				if (drow == null)
					return null;
				ClsPartnerEmailList l = new ClsPartnerEmailList(drow);
				return l;
			}
		}
		protected ClsPartnerEmail currentEmail
		{
			get
			{
				DataRow drow = grdEmails.GetDataRow();
				if (drow == null)
					return null;
				ClsPartnerEmail m = new ClsPartnerEmail(drow);
				return m;
			}
		}
		public frmMailListEdit()
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
			DataTable dt = ClsPartnerEmailList.GetAll();
			grdEmailList.DataSource = dt;
		}

		private void grdEmailList_SelectionChanged(object sender, EventArgs e)
		{
			if (currentList == null)
				return;
			dtEmails = ClsPartnerEmail.GetEmailList(currentList.Email_List_Cd);
			grdEmails.DataSource = dtEmails;
		}

		private void PopulateEmailTextBoxes()
		{
			if (currentEmail == null)
				return;
			txtEmail.Text = currentEmail.Outlook_Email;
			txtName.Text = currentEmail.Outlook_Name;
		}

		private void grdEmails_SelectionChanged(object sender, EventArgs e)
		{
			PopulateEmailTextBoxes();
		}

		private void btnEdit_Click(object sender, EventArgs e)
		{
			currentMode = "edit";
			grpEditEmail.Enabled = true;
			grdEmailList.Enabled = false;
			grdEmails.Enabled = false;
			btnEdit.Enabled = btnAdd.Enabled = btnDelete.Enabled =  false;
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			grpEditEmail.Enabled = false;
			grdEmails.Enabled = grdEmailList.Enabled = true;
			PopulateEmailTextBoxes();
			btnEdit.Enabled = btnAdd.Enabled = btnDelete.Enabled = true;
		}

		private void Save_Click(object sender, EventArgs e)
		{
			try
			{
				int i = grdEmails.Row;
				if (currentMode == "edit")
				{
					ClsPartnerEmail em = currentEmail;
					em.CustomUpdate(em, txtName.Text, txtEmail.Text);

				}
				if (currentMode == "add")
				{
					ClsPartnerEmail em = new ClsPartnerEmail();
					em.Partner_Cd = currentList.Partner_Cd;
					em.Email_List_Cd = currentList.Email_List_Cd;
					em.Outlook_Name = txtName.Text;
					em.Outlook_Email = txtEmail.Text;
					em.Insert();
					i = 1;
				}
				grpEditEmail.Enabled = false;
				grdEmails.Enabled = grdEmailList.Enabled = btnEdit.Enabled = btnDelete.Enabled = btnAdd.Enabled = true;

				dtEmails = ClsPartnerEmail.GetEmailList(currentList.Email_List_Cd);
				grdEmails.DataSource = dtEmails;
				grdEmails.Row = i;

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
			txtEmail.Text = "";
			txtName.Text = "";
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			ClsPartnerEmail em = currentEmail;
			string sMsg = string.Format("Delete email for {0}?", em.Outlook_Name);
			DialogResult dr = MessageBox.Show(sMsg, "Confirm", MessageBoxButtons.OKCancel);
			if (dr == DialogResult.Cancel)
				return;

			em.Delete();
			dtEmails = ClsPartnerEmail.GetEmailList(currentList.Email_List_Cd);
			grdEmails.DataSource = dtEmails;
		}

	}
}
