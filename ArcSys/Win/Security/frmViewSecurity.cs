using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using CS2010.ArcSys.Business;
using CS2010.Common;
using CS2010.CommonWinCtrls;
using CS2010.CommonSecurity;
using Janus.Windows.GridEX;
using CS2010.ArcSys.Win;

namespace CS2010.ArcSys.Win
{
    public partial class frmViewSecurity : frmChildBase
    {
		#region Static Fields

		/// <summary>Used by the static ViewSecurity method to ensure that no more than
		/// one frmViewSecurity window is visible at any given time</summary>
		private static frmViewSecurity SecurityWindow;

		#endregion		// #region Static Fields

        #region Fields
        private List<ClsSecurityUser> _users;
        private List<ClsSecurityGroup> _groups;
        private List<ClsUserGroup> _usergroup;
        private DataTable _DTsecurity;
        private DataTable _DTviewsecurity;
        private List<ClsSecurityUser> _unassigned;
        private List<ClsSecurityObject> _objects;
        private DataTable _parents;
        private bool ChangesMade;
        private const string sDupeKey = "unique constraint (SECURITY.UK_USER_GROUP_USER_ID)";

        //private List<ClsSecurityMaster.ClsObjectList> _objectlist;

        #endregion

        #region Properties
        private ClsSecurityObject CurrentSecurityObject
        {
            get
            {
                return grdObjects.GetCurrentItem<ClsSecurityObject>();
            }
        }


        #endregion

        #region Constructor

        public frmViewSecurity() : base(Program.MainWindow, true)
        {
            InitializeComponent();

			WindowHelper.InitAllGrids(this);
			ClsSecurityMaster.SetSecurity(this, ClsEnvironment.User_Id.Value);

            ChangesMade = false;
		}
        #endregion

        #region IViewWindow Members

        //public ClsBaseTable TableObject { get { return thePayment; } }

        ///// <summary>Method for viewing a business object. This method is/should
        ///// only be used by the ViewWindowManager.</summary>
        ///// <param name="bizObject">The booking object to display</param>
        //public void View(ClsBaseTable bizObject)
        //{
        //    ViewPayment(bizObject as ClsApPayment);
        //}
        //public void UpdateDisplay()
        //{
        //    txtPayment.Text = thePayment.PaymentText;
        //    grdDetail.DataSource = thePayment.PaymentDetail;
        //}
        #endregion

		#region Public Methods

		/// <summary>Main entry point into this window ensuring that no more than 1
		/// frmViewSecurity window is visible at any given time</summary>
		public static frmViewSecurity ViewSecurity()
		{
			try
			{
				bool newWindow = false;
				if( SecurityWindow == null )
				{
					SecurityWindow = new frmViewSecurity();
					newWindow = true;
				}

				WindowHelper.ShowChildWindow(SecurityWindow);

				if( newWindow )
				{
					//TODO: any code that happens when 1st opening the window
				}

				return SecurityWindow;
			}
			catch( Exception ex )
			{
				Program.ShowError(ex);
				return null;
			}
		}
		#endregion		// #region Public Methods

        #region Helper Methods
        private void FormLoad()
        {
            RefreshData();
        }

        private void RefreshData()
        {
            _users = ClsSecurityUser.GetUserList();
            _groups = ClsSecurityGroup.GetGroupList();
            //_security = ClsSecurity.GetAllList();
            _DTsecurity = ClsSecurity.GetAll(true);
            _DTviewsecurity = _DTsecurity.Copy();
            _objects = ClsSecurityObject.GetAllList();
            _unassigned = ClsSecurityUser.GetUnassignedUsers();
            _parents = ClsSecurityObject.GetDistinctParents();

            grdGroups.DataSource = _groups;

            _usergroup = ClsUserGroup.GetUserGroupList();
            grdDetail.DataSource = _usergroup;

            //grdSecurity.DataSource = _security;
            grdSecurity.DataSource = _DTsecurity;
            grdViewSecurity.DataSource = _DTviewsecurity;
            grdObjects.DataSource = _objects;
            grdUnassigned.DataSource = _unassigned;
            grdUnassigned.Enabled = false;
            grdParentDescriptions.DataSource = _parents;

            grdDetail.DropDowns["ddUser"].DataSource = _users;
            grdDetail.DropDowns["ddGroup"].DataSource = _groups;
            grdSecurity.DropDowns["ddObject"].DataSource = _objects;

            frmMain frm = new frmMain();
            //_objectlist = ClsSecurityMaster.GetSecurityObjects(frm);
            //grdObjects.DropDowns[0].DataSource = _objectlist;
        }

        private void SaveChanges()
        {
            try
            {
                grdGroups.UpdateData();
                grdObjects.UpdateData();
                string sMsg = ClsSecurityMaster.SaveAll(_usergroup, _groups, _DTsecurity, _objects);
                if (!string.IsNullOrEmpty(sMsg))
                    Program.Show(sMsg);

                grdViewSecurity.UpdateData();
                sMsg = ClsSecurityMaster.SaveAll(_DTviewsecurity);
                if (!string.IsNullOrEmpty(sMsg))
                    Program.Show(sMsg);

                grdDetail.Refresh();
                _DTsecurity = new DataTable();
                _DTsecurity = ClsSecurity.GetAll(true);
                grdSecurity.DataSource = _DTsecurity;
                _DTviewsecurity = _DTsecurity.Copy();
                grdViewSecurity.DataSource = _DTviewsecurity;
                ChangesMade = false;
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }

        private void DescriptionSelectionChanged()
        {
            DataRow dr = grdParentDescriptions.GetDataRow();
            txtOldDsc.Text = dr["parent_dsc"].ToString();
            txtNewDsc.Text = "";
        }

        #endregion

        #region UserGroup
        private void AddUserGroup()
        {
            try
            {
                frmGetUserGroup frm = new frmGetUserGroup();
                ClsUserGroup ug = frm.Add();
                if (ug == null)
                    return;
                ug.Insert();
                RefreshData();
            }
            catch (DbException ex)
            {
                if (ex.Message.Contains(sDupeKey))
                {
                    Program.ShowError("Users cannot belong to more than one group");
                    return;
                }
                Program.Show(ex.Message);
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }

        private void EditUserGroup()
        {
            try
            {
                frmGetUserGroup frm = new frmGetUserGroup();
                ClsUserGroup s = grdDetail.GetCurrentItem<ClsUserGroup>();
                if (frm.Edit(s) == true)
                {
                    int ix = grdDetail.Row;
                    s.Update();
                    _usergroup = ClsUserGroup.GetUserGroupList();
                    _usergroup[ix] = s;
                    grdDetail.Row = ix;
                    grdDetail.Refetch();
                }
                //_usergroup = ClsUserGroup.GetUserGroupList();
                //grdDetail.DataSource = _usergroup;
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }

        private void DeleteUserGroup()
        {
            try
            {
                ClsUserGroup ug = grdDetail.GetCurrentItem<ClsUserGroup>();
                ug.Delete();
                RefreshData();
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }

        private void CloneUserGroup()
        {
            ClsUserGroup ug = grdDetail.GetCurrentItem<ClsUserGroup>();
            RefreshData();
        }

        #endregion

        #region Group
        private void DeleteGroup()
        {
            try
            {
                ClsSecurityGroup g = grdGroups.GetCurrentItem<ClsSecurityGroup>();
                g.Delete();
                RefreshData();
            }
            catch  (Exception ex)
            {
                Program.Show(ex.Message);
            }
        }

        private void EditSecurityGroup()
        {
            ClsSecurityGroup s = this.grdGroups.GetCurrentItem<ClsSecurityGroup>();
            EditSecurityGroup(s);
        }

        private void EditSecurityGroup(ClsSecurityGroup s)
        {
            try
            {
                frmEditGroup frm = new frmEditGroup();
                if (frm.EditGroup(s) == true)
                {
                    int ix = grdGroups.Row;
                    s.Update();
                    _groups = ClsSecurityGroup.GetGroupList();
                    _groups[ix] = s;
                    grdGroups.Row = ix;
                    grdGroups.Refetch();
                }
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }

        private void CloneSecurityGroup()
        {
            ClsSecurityGroup oldGroup = grdGroups.GetCurrentItem<ClsSecurityGroup>();
            ClsSecurityGroup newGroup = new ClsSecurityGroup(oldGroup);
            newGroup.Group_ID = null;
            newGroup.Group_Dsc = "Clone of " + oldGroup.Group_Dsc;
            newGroup.Insert();
			List<ClsSecurity> sl = ClsSecurity.GetSecurityForGroupSimple((long)oldGroup.Group_ID);
			foreach( ClsSecurity sec in sl )
			{
				ClsSecurity newSec = new ClsSecurity(sec);
				newSec.Group_ID = newGroup.Group_ID;
				newSec.Security_ID = null;
				newSec.Insert();
			}
            EditSecurityGroup(newGroup);
        }

        private void ClearSecurityGroup()
        {
            if (Display.AskCancel("Clear Security", "This will remove all objects for this group") < 1)
                return;
            ClsSecurityGroup g = grdGroups.GetCurrentItem<ClsSecurityGroup>();
            g.ClearGroupSecurity();
        }

        #endregion

        #region Securitiy
        private void AddSecurity()
        {
            try
            {
                frmGetSecurity frm = new frmGetSecurity();
                ClsSecurity securitiy = frm.AddSecurityInfo();
                if (securitiy == null)
                    return;
                securitiy.Insert();
                RefreshData();
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }

        private void DeleteSecurity()
        {
            try
            {
                ClsSecurity s = grdSecurity.GetCurrentItem<ClsSecurity>();
                s.Delete();
                RefreshData();
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }

        private void EditSecurity()
        {
            try
            {
                frmGetSecurity frm = new frmGetSecurity();
                ClsSecurity s = grdSecurity.GetCurrentItem<ClsSecurity>();
                if (frm.EditSecurityInfo(s) == true)
                    s.Update();
                RefreshData();
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }

        private void ReInitSecurityObjects()
        {
            try
            {
                ClsSecurityMaster.RefreshSecurityObjects();
                RefreshData();
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }

        #endregion

        #region Security Object
        private void EditSecurityObject()
        {
            try
            {
                frmEditSecurityObject frm = new frmEditSecurityObject();
                ClsSecurityObject s = this.grdObjects.GetCurrentItem<ClsSecurityObject>();
                if (frm.EditSecurityObject(s) == true)
                {
                    
                    s.Update();
                    grdObjects.Refetch();
                }
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }

        private void AddSecurityObject()
        {
            try
            {
                frmEditSecurityObject frm = new frmEditSecurityObject();
                ClsSecurityObject o = frm.AddSecurityObject();
                if (o == null)
                    return;
                o.Insert();
                _objects.Add(o);
                grdObjects.Refetch();

                GridEXColumn cObject = grdObjects.RootTable.Columns["Object_Nm"];
                GridEXFilterCondition f = new GridEXFilterCondition(cObject,
                     ConditionOperator.Equal, o.Object_Nm);
                grdObjects.Find(f, 1, 1);
            }
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }

        private void DeleteObject()
        {
            try
            {
                if (MessageBox.Show("This will delete the object and all references to it.", "Confirm", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                    return;
                ClsSecurityObject o = CurrentSecurityObject;
                _objects.Remove(o);
                ClsSecurityObject.DeleteObject(o);
                MessageBox.Show("Object deleted");
				grdObjects.Refetch();
			}
            catch (Exception ex)
            {
                Program.ShowError(ex);
            }
        }

        #endregion

        #region Events

        private void frmViewSecurity_FormClosed(object sender, FormClosedEventArgs e)
		{
			SecurityWindow = null;
		}

        private void tbbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmViewSecurity_Load(object sender, EventArgs e)
        {
            FormLoad();
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveChanges();
        }

        private void ucGridToolStrip1_ClickAdd(object sender, EventArgs e)
        {
            AddUserGroup();
        }

        private void ucGridToolStrip2_ClickAdd(object sender, EventArgs e)
        {
            ClsSecurityGroup g = new ClsSecurityGroup();
            _groups.Add(g);
            grdGroups.Refetch();
        }

        private void ucGridToolStrip2_ClickDelete(object sender, EventArgs e)
        {
            DeleteGroup();
        }

        private void tsSecurity_ClickAdd(object sender, EventArgs e)
        {
            AddSecurity();
        }

        private void tsSecurity_ClickDelete(object sender, EventArgs e)
        {
            DeleteSecurity();
        }
        private void tsSecurity_ClickEdit(object sender, EventArgs e)
        {
            EditSecurity();
        }

        private void ucGridToolStrip1_ClickDelete(object sender, EventArgs e)
        {
            DeleteUserGroup();
        }

        private void ucGridToolStrip1_ClickEdit(object sender, EventArgs e)
        {
            EditUserGroup();
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ReInitSecurityObjects();
        }

        private void grdSecurity_CellValueChanged(object sender, ColumnActionEventArgs e)
        {
            ChangesMade = true;
            grdSecurity.UpdateData();
        }

        private void grdDetail_CellValueChanged(object sender, ColumnActionEventArgs e)
        {
            ChangesMade = true;
            grdDetail.UpdateData();
        }

        private void grdGroups_CellValueChanged(object sender, ColumnActionEventArgs e)
        {
            ChangesMade = true;
        }

        private void ucGridToolStrip2_ClickAdd_1(object sender, EventArgs e)
        {
            AddSecurityObject();
        }

        private void ucGridToolStrip2_ClickDelete_1(object sender, EventArgs e)
        {
            DeleteObject();
        }

        private void ucGridEx1_SelectionChanged(object sender, EventArgs e)
        {
            DescriptionSelectionChanged();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            try
            {
                string sParent = grdParentDescriptions.GetDataRow()["parent_nm"].ToString();
                ClsSecurityObject.UpdateParentDsc(sParent, txtNewDsc.Text);
                MessageBox.Show("Description changed");
                RefreshData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmViewSecurity_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ChangesMade)
            {
                DialogResult dr = MessageBox.Show("Close without saving changes?", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.Cancel)
                    e.Cancel = true;
            }
        }

        private void tsGroup_ClickEdit(object sender, EventArgs e)
        {
            EditUserGroup();
        }

        private void ucGridToolStrip2_ClickEdit(object sender, EventArgs e)
        {
            EditSecurityObject();
        }
        #endregion

        private void grdDetail_DoubleClick(object sender, EventArgs e)
        {
            EditUserGroup();
        }

        private void grdObjects_DoubleClick(object sender, EventArgs e)
        {
            EditSecurityObject();
        }

        private void tsCloneGroup_Click(object sender, EventArgs e)
        {
            CloneSecurityGroup();
        }

        private void tsGroup_ClickEdit_1(object sender, EventArgs e)
        {
            EditSecurityGroup();
        }

        private void tsClearSecurity_Click(object sender, EventArgs e)
        {
            ClearSecurityGroup();
        }







    }
}