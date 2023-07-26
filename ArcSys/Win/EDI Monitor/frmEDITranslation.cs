using System;
using System.Data;
using System.Data.Common;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using CS2010.Common;
using CS2010.CommonWinCtrls;
using CS2010.CommonSecurity;
using CS2010.ArcSys.Business;
using Janus.Windows.GridEX;
using System.IO;
using System.Collections.Generic;

namespace CS2010.ArcSys.Win
{
	public partial class frmEDITranslation: frmChildBase
	{
		#region Fields
        DataTable dtTranslation;
        ClsEdiCodeTranslation currentItem;
        protected string currentMode = "edit";
        protected DataTable dtInterfaces;
        protected DataTable dtFields;

		#endregion		// #region Fields

		#region Constructors/Initialization/Entry

		public frmEDITranslation()
			: base()
		{
			InitializeComponent();

			AdjustForm(Program.MainWindow, true, null);

			WindowHelper.InitAllGrids(this);
			ClsSecurityMaster.SetSecurity(this, ClsEnvironment.User_Id.Value);
            SetDefaults();
            dtInterfaces = ClsEdiInterface.GetAll();
            dtFields = ClsEdiField.GetAll();
            cmbField.DataSource = dtFields;
            cmbInterface.DataSource = dtInterfaces;
            cmbSelectInterface.DataSource = dtInterfaces;
		}

		public void ShowSearch(bool showOptions)
		{
			try
			{
                dtTranslation = ClsEdiCodeTranslation.GetAll(true);
                grdMain.DataSource = dtTranslation;
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void frmSearchContractMod_Load(object sender, EventArgs e)
		{
			try
			{
				btnSearch.Focus();
				ActiveControl = btnSearch;
                btnSearch.Enabled = true;
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}
		#endregion		// #region Constructors/Initialization/Entry


		#region Other Methods

        protected void SetCurrentItem()
        {
            DataRow drow = grdMain.GetDataRow();
            if (drow == null)
                currentItem = null;
            else
                currentItem = new ClsEdiCodeTranslation(drow);
        }

        protected void BindItem()
        {
            if (currentMode != "add")
                SetCurrentItem();
            BindHelper.Bind(cmbInterface, currentItem, "Edi_Interface_ID");
            BindHelper.Bind(cmbField, currentItem, "Edi_Field_ID");
            BindHelper.Bind(txtDbCode, currentItem, "Dbcode");
            BindHelper.Bind(txtImportCode, currentItem, "Importcode");
            BindHelper.Bind(txtExportCode, currentItem, "Exportcode");
            cmbField.SelectedItem = currentItem.Edi_Field_ID;
            cmbInterface.SelectedItem = currentItem.Edi_Interface_ID;
        }
		private void SetDefaults()
		{
			SetDefaults(true);
		}
		private void SetDefaults(bool bInitial)
		{
			WindowHelper.ClearAllControls(this);
			if (bInitial)
				return;
		}

        protected void EnableEdit()
        {
            grpEdit.Enabled = true;
            //grdMain.Enabled = false;
            btnEdit.Enabled = btnAdd.Enabled = btnDelete.Enabled = false;
        }
        protected void DisableEdit()
        {
            currentMode = "view";
            grpEdit.Enabled = false;
            //grdMain.Enabled = false;
            btnEdit.Enabled = btnAdd.Enabled = btnDelete.Enabled = true;
        }

        private void Search()
        {
            object id = cmbSelectInterface.SelectedItem;
            object id2= cmbSelectInterface.SelectedText;
            object id3 = cmbSelectInterface.Value;

            if (id3 == null)
            {
                Program.Show("You must first select an Interface");
                return;
            }
            
            Int64 i = ClsConvert.ToInt64(id3);
            dtTranslation = ClsEdiCodeTranslation.SearchByInterface(i);
            grdMain.DataSource = dtTranslation;
        }
		#endregion


		#region Form Event Handlers


		private void btnSearch_Click(object sender, EventArgs e)
		{
            Search();
		}

		private void btnClear_Click(object sender, EventArgs e)
		{
			SetDefaults(false);
		}

		private void grdMain_LinkClicked(object sender, ColumnActionEventArgs e)
		{
			try
			{
			}
			catch (Exception ex)
			{
				Program.ShowError(ex);
			}
		}

		private void grdMain_SelectionChanged(object sender, EventArgs e)
		{
            if (grdMain.CurrentRow.RowType != Janus.Windows.GridEX.RowType.Record)
                return;
            BindItem();
            DisableEdit();
		}

        private void Save_Click(object sender, EventArgs e)
        {
            try
            {
                int i = grdMain.Row;
                if (currentMode == "edit")
                {
                    ClsEdiCodeTranslation cc = currentItem;
                    cc.Dbcode = txtDbCode.Text;
                    cc.Importcode = txtImportCode.Text;
                    cc.Exportcode = txtExportCode.Text;
                    cc.Update();
                }
                if (currentMode == "add")
                {
                    ClsEdiCodeTranslation newTrx = new ClsEdiCodeTranslation();
                    newTrx.Edi_Interface_ID = currentItem.Edi_Interface_ID;
                    newTrx.Edi_Field_ID = currentItem.Edi_Field_ID;
                    newTrx.Dbcode = txtDbCode.Text;
                    newTrx.Exportcode = txtExportCode.Text;
                    newTrx.Importcode = txtImportCode.Text;
                    newTrx.Insert();
                    Program.Show("New Translation Added");
                }
                DisableEdit();

                dtTranslation = ClsEdiCodeTranslation.GetAll(true);
                Search();
                grdMain.Row = i;
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
                return;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            currentMode = "edit";
            EnableEdit();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DisableEdit();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            currentMode = "add";
            currentItem = new ClsEdiCodeTranslation();
            currentItem.Edi_Interface_ID = ClsConvert.ToInt64(cmbSelectInterface.Value);
            BindItem();
            EnableEdit();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (currentItem == null)
            {
                Program.Show("You must first select an item to delete");
                return;
            }
            try
            {
                ClsEdiCodeTranslation.DeleteItem(currentItem.Edi_Code_Translation_ID.GetValueOrDefault());
                Program.Show("Translation Item Deleted");
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
            finally
            {
                currentMode = "view";
                Search();
            }
        }
#endregion 

 

	}
}