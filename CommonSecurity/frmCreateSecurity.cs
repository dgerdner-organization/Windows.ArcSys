using System;
using System.Data;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;
using System.Collections.Generic;
using Janus.Windows.GridEX;
using CS2010.Common;
using CS2010.CommonWinCtrls;

namespace CS2010.CommonSecurity
{
	public partial class frmCreateSecurity : Form
	{

		#region Fields
        private List<ClsSecurityMaster.ClsSecurityChoices> _choices;

		#endregion		// #region Fields

		#region Properties

 		#endregion		// #region Properties

		#region Constructors

		public frmCreateSecurity()
		{
			InitializeComponent();
            mnuFilter.SelectedIndex = 0;

		}
		#endregion		// #region Constructors

		#region Public method(s)


		public void CreateSecurity(List<ClsSecurityMaster.ClsSecurityChoices> choices)
		{
            _choices = choices;
            ShowChoices(false);
		}

		#endregion		// #region Public method(s)

		#region Helper Methods

		private void ShowChoices(bool fullScreen)
		{
            RefreshForm();
			ShowDialog();
		}

        private void RefreshForm()
        {
            
            grdChoices.DataSource = _choices;
            ClsSecurityMaster.orphans = null;
            grdOrphans.DataSource = ClsSecurityMaster.orphans;
            cmbRenameNew.DataSource = _choices;
        }

        private void SelectShowOptions()
        {
            try
            {
                string sChoice =  mnuFilter.SelectedItem.ToString();
                bool bExisting = false;
                switch (sChoice.Substring(0, 1))
                {
                    case "2":
                        bExisting = true;
                        break;
                    case "3":
                        bExisting = false;
                        break;
                }
                GridEXFilterCondition fc = new GridEXFilterCondition(grdChoices.Tables[0].Columns["bExists"], ConditionOperator.Equal, bExisting);
                if (sChoice.Substring(0, 1) == "1")
                    fc.Clear();
                grdChoices.Tables[0].ApplyFilter(fc);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DeleteOrphan()
        {
            foreach (ClsSecurityObject obj in grdOrphans.GetCheckedList<ClsSecurityObject>())
            {
                ClsSecurityObject.DeleteObject(obj);                
            }
            MessageBox.Show(grdOrphans.GetCheckedList<ClsSecurityObject>().Count.ToString() + " Orphans Deleted");
        }

        private void RenameObject()
        {
            try
            {
                ClsSecurityObject obj = grdOrphans.GetCurrentItem<ClsSecurityObject>();
                obj.RenameObject(cmbRenameNew.Value.ToString());
                RefreshForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

		#endregion		// #region Helper Methods

		#region Event Handlers

		private void CreateObjects()
		{
            try
            {
                List<ClsSecurityMaster.ClsSecurityChoices> c = new List<ClsSecurityMaster.ClsSecurityChoices>();
                Janus.Windows.GridEX.GridEXRow[] grows = grdChoices.GetCheckedRows();
                foreach (GridEXRow grow in grows)
                {
                    ClsSecurityMaster.ClsSecurityChoices obj =
                        new ClsSecurityMaster.ClsSecurityChoices();
                    obj.sDescr = (grow.Cells["sDescr"].Text.IsNullOrWhiteSpace()) ? grow.Cells["sName"].Text : grow.Cells["sDescr"].Text;
                    obj.sName = grow.Cells["sName"].Text;
                    obj.sPrevLevel = grow.Cells["sPrevLevel"].Text;
                    obj.sType = grow.Cells["sType"].Text;
                    c.Add(obj);
                }
                ClsSecurityMaster.CreateObjects(c);
                MessageBox.Show(grows.Length.ToString() + " New Objects Created");
                DialogResult = DialogResult.OK;
                //RefreshForm();
            }
            catch (Exception ex)
            {
                ClsErrorHandler.LogException(ex);
                MessageBox.Show(ex.Message);
            }
		}

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteOrphan();
        }

        private void grdOrphans_SelectionChanged(object sender, EventArgs e)
        {
            if (grdOrphans.GetCurrentItem<ClsSecurityObject>() == null)
                txtRenameOld.Text = "";
            else
                txtRenameOld.Text = grdOrphans.GetCurrentItem<ClsSecurityObject>().Object_Nm;
        }

        private void btnRename_Click(object sender, EventArgs e)
        {
            RenameObject();
        }

        private void mnuFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectShowOptions();
        }
		#endregion		// #region Event Handlers

        private void mnuCreateObjects_Click(object sender, EventArgs e)
        {
            CreateObjects();
        }


		#region Static Methods

		#endregion		// #region Static Methods
	}
}