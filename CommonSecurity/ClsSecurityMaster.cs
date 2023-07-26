using System;
using System.Data;
using System.Collections.Generic;
using WebUI = System.Web.UI;
using WebUIWC = System.Web.UI.WebControls;
using WinUI = System.Windows.Forms;
using CS2010.Common;
using CS2010.CommonWinCtrls;
using Janus.Windows.GridEX;


namespace CS2010.CommonSecurity
{
	/// <summary>Main security business class</summary>
	public static class ClsSecurityMaster
    {
        #region Fields
        public static List<ClsObjectList> _objectlist;
        public static List<ClsSecurityChoices> _choices;
        public static List<ClsSecurityObject> _orphans;
        public static string _sParent;
        private static string _sLevelPre;
        private static bool _IncludeMenu;
        private static WinUI.Form _SourceForm;

        #endregion

        #region Properties
        private static ClsConnection Connection
        {
            get { return ClsConMgr.Manager["Security"]; }
        }
        public static List<ClsSecurityObject> orphans
        {
            get 
            {
                if (_orphans == null)
                    FindOrphans();
                return _orphans; 
            }
            set
            {
                _orphans = value;
            }
        }

        #endregion

        #region Public methods

        /// <summary>
        /// This will insert rows into r_security based on all
        /// security objects that have not yet been defined for a
        /// group.  When it is complete, each security group will
        /// have an entry for each security object.
        /// </summary>
        public static void RefreshSecurityObjects()
        {
            string sql = @"
                    insert into SECURITY.r_security
                    select security_id_seq.nextval, a.group_id, b.object_id, 1,
                           'class_owner', sysdate, 'class_owner', sysdate, b.default_enabled_flg, b.default_visible_flg
                     from SECURITY.r_security_group a, SECURITY.r_security_object b
                      where not exists
                       (select * from SECURITY.r_security c
                        where c.group_id = a.group_id
                          and c.object_id = b.object_id)";

            Connection.RunSQL(sql);
        }

        public static void InitObjectList()
        {
            if (_objectlist == null)
                _objectlist = new List<ClsObjectList>();
            else
                _objectlist.Clear();
        }

        public static void SetSecurity(WinUI.Form frm, long userID,
			Dictionary<string, ClsSecurity> SecurityTable)
		{
			DataTable dt = SetSecurity(frm, userID);
			if( dt == null || dt.Rows.Count <= 0 || SecurityTable == null )
				return;

			foreach( DataRow dr in dt.Rows )
			{
				ClsSecurity sec = new ClsSecurity(dr);
				SecurityTable.Add(
					ClsConvert.ToString(dr["Object_Nm"]).ToUpper(), sec);
			}
		}


		public static DataTable SetSecurity(WinUI.Form frm, long userID)
        {
			if( frm.Controls == null || frm.Controls.Count <= 0 ) return null;

			DataTable dt = ClsSecurity.GetSecurityForUser(userID, frm.Name);
			if( dt == null || dt.Rows.Count <= 0 ) return null;

			SetSecurity(frm, dt);

			return dt;
		}

        public static void SetSecurity(WinUI.Form frm)
        {

            long userID = ClsEnvironment.User_Id.Value;
            SetSecurity(frm, userID);
        }

		public static DataTable SetSecurity(WebUI.Page pg, string parentName,
			long userID)
		{
			if( pg.HasControls() == false ) return null;

			DataTable dt = ClsSecurity.GetSecurityForUser(userID, parentName);
			if( dt == null || dt.Rows.Count <= 0 ) return null;

			SetSecurity(pg, dt);

			return dt;
		}

		public static void SetSecurity(WebUI.Page pg, string parentName,
			long userID, Dictionary<string, ClsSecurity> SecurityTable)
		{
			DataTable dt = SetSecurity(pg, parentName, userID);
			if( dt == null || dt.Rows.Count <= 0 || SecurityTable == null )
				return;

			foreach( DataRow dr in dt.Rows )
			{
				ClsSecurity sec = new ClsSecurity(dr);
				SecurityTable.Add(
					ClsConvert.ToString(dr["Object_Nm"]).ToUpper(), sec);
			}
		}

        public static string SaveAll(List<ClsUserGroup> usergroup,
                                    List<ClsSecurityGroup> group,
                                    DataTable DTsecurity,
                                    List<ClsSecurityObject> SecObj)
        {
            ClsConnection connection = ClsConMgr.Manager["Security"];
            connection.TransactionBegin();
            long iIns = 0;
            long iUpd = 0;
            try
            {
                foreach (ClsSecurityObject obj in SecObj )
                {
                    if (obj.Object_ID == null)
                    {
                        obj.Insert();
                    }
                    else
                    {
                        obj.Update();
                    }
                }
                foreach (ClsUserGroup u in usergroup)
                {
                    if (u.User_Group_ID == null)
                    {
                        u.Insert();
                    }
                    else
                    {
                        u.Update();
                    }
                }
                foreach (ClsSecurityGroup g in group)
                {
                    if (g.Create_User == null)
                    {
                        g.Insert();
                    }
                    else
                    {
                        g.Update();
                    }
                }
                // This part can take quite a while, so we only perform it
                // if there have actually been changes made.
                foreach (DataRow dr in DTsecurity.Rows)
                {
                    if (dr.RowState == DataRowState.Modified)
                    {
                        ClsSecurity s = new ClsSecurity(dr);
                        if (s.Create_User == null)
                        {
                            iIns++;
                            s.Insert();
                        }
                        else
                        {
                            s.Update();
                            iUpd++;
                        }
                    }
                }
                connection.TransactionCommit();
                if (iIns > 0 || iUpd > 0)
                    return string.Format("{0} Updates and {1} Inserts were saved on the Security by Group tab", iUpd, iIns);
                else
                    return "";
            }
            catch
            {
                connection.TransactionRollback();
                throw;
            }
        }

        public static string SaveAll(DataTable DTsecurity)
        {
            long iIns = 0;
            long iUpd = 0;
            ClsConnection connection = ClsConMgr.Manager["Security"];
            connection.TransactionBegin();
            try
            {
                foreach (DataRow dr in DTsecurity.Rows)
                {
                    if (dr.RowState == DataRowState.Modified)
                    {
                        ClsSecurity s = new ClsSecurity(dr);
                        if (s.Create_User == null)
                        {
                            s.Insert();
                            iIns++;
                        }
                        else
                        {
                            s.Update();
                            iUpd++;
                        }
                    }
                }
                connection.TransactionCommit();
                if (iIns > 0 || iUpd > 0)
                    return string.Format("{0} Updates and {1} Inserts were saved on the Security by Objects tab",iUpd, iIns);
                else
                    return "";
            }
            catch
            {
                connection.TransactionRollback();
                throw;
            }
        }


	#endregion

        #region Get Security Methods
        public static List<ClsSecurityChoices> GetObjectsOnForm (WinUI.Form frm, bool IncludeMenu)
        {
            _SourceForm = frm;
            _IncludeMenu = IncludeMenu;
            _sParent = frm.Name;
            _sLevelPre = "";
            _choices = new List<ClsSecurityChoices>();
            WinUI.Control.ControlCollection ctrls = frm.Controls;
            foreach (WinUI.Control ctrl in ctrls)
            {
                GetSecurity(ctrl);
                WinUI.ToolStrip ts = ctrl as WinUI.ToolStrip;
                if (ts != null) GetSecurity(ts);
                string sName = ctrl.Name;
            }

            WinUI.Form fMdi = frm.MdiParent;
            if (fMdi != null)
            {
                _sLevelPre = fMdi.Name;
                WinUI.Control.ControlCollection ctrlx = fMdi.Controls;
                int ix = 0;
                // Just do the first one; the rest are part of the MDI Frame
                // and don't need to be included in each individual form.
                while (ix < 1)
                {
                    WinUI.Control c = ctrlx[ix];
                    ix++;
                    GetSecurity(c);
                    WinUI.ToolStrip tsx = c as WinUI.ToolStrip;
                    if (tsx != null) GetSecurity(tsx);
                }
            }
            FindOrphans();

            return _choices;
        }

        private static void FindOrphans()
        {
            // Now find orphans on this form
            DataTable dt = ClsSecurityObject.GetObjects(_SourceForm.Name);
            _orphans = new List<ClsSecurityObject>();
            foreach (DataRow dr in dt.Rows)
            {
                ClsSecurityObject so = new ClsSecurityObject(dr);
                if (!FindObject(so))
                    AddOrphan(so);
            }
        }

        private static bool FindObject(ClsSecurityObject obj)
        {
            foreach (ClsSecurityChoices c in _choices)
            {
                if (c.sName == obj.Object_Nm)
                    return true;
            }
            return false;
        }
        
        private static void AddOrphan(ClsSecurityObject obj)
        {
            foreach (ClsSecurityObject o in orphans)
            {
                if (o.Object_Nm == obj.Object_Nm)
                    return;
            }
            orphans.Add(obj);
        }

        private static void GetSecurity(WinUI.Control container)
        {
            if (container.Parent.Name.Length > 2)
                _sLevelPre = container.Parent.Name  ;

            string s = container.Name;
            Type typ = container.GetType();
            string sType = typ.Name;
            AddChoice(s, container.Text, container, sType);

            Janus.Windows.GridEX.GridEX grd = container as Janus.Windows.GridEX.GridEX;
            if (sType.ToLower() == "ucgridex")
                GetSecurity(grd);

            WinUI.Control.ControlCollection ctrls = container.Controls;
            if (ctrls == null || ctrls.Count <= 0) return;

            foreach (WinUI.Control c in container.Controls)
            {
                GetSecurity(c);

                // If it's a toolstrip, get security for all the items on it
                WinUI.ToolStrip ts = c as WinUI.ToolStrip;
                if (ts != null) GetSecurity(ts);

                // If it's a treeview, get the nodes
                WinUI.TreeView tv = c as WinUI.TreeView;
                if (tv != null) GetSecurity(tv);

            }
        }

        private static void GetSecurity(WinUI.TreeView tv)
        {
            if (tv.Name.Length > 2)
                _sLevelPre = tv.Name;

            foreach (WinUI.TreeNode node in tv.Nodes)
            {
                string s = node.Name;
                AddChoice(s, node.Text, node, "TreeNode");
            }
        }

        private static void GetSecurity(GridEX grd)
        {
            if (grd.Layouts.Count > 0)
            {
                GridEXLayout layout = grd.CurrentLayout;
                if (layout == null) 
                    return;
                _sLevelPre = layout.Key;
            }
            else
                _sLevelPre = grd.Name;

            foreach (GridEXTable tbl in grd.Tables )
            {
                foreach (GridEXColumn col in tbl.Columns)
                {
                    string s = "GridColumn";
                    if (col.ColumnType == ColumnType.Link)
                        s = "GridColumn(LINK)";
                    AddChoice(col.Key, col.Caption, col, s);
                }
            }
        }

        private static void GetSecurity(WinUI.ToolStrip ts)
        {
            foreach (WinUI.ToolStripItem item in ts.Items)
            {
                if (ts.Name.Length > 2)
                    _sLevelPre = ts.Name;
                string s = item.Name;
                AddChoice(s, item.Text, item, "MenuItem");
                
                if (item is WinUI.ToolStripMenuItem)
                {
                    WinUI.ToolStripMenuItem tsm = (WinUI.ToolStripMenuItem)item;
                    WinUI.ToolStripDropDown ddi = tsm.DropDown;
                    _sLevelPre = item.Name;
                    GetSecurity(ddi);
                }
                if (item is WinUI.ToolStripDropDownItem)
                {
                    WinUI.ToolStripDropDownItem tsddi = (WinUI.ToolStripDropDownItem)item;
                    WinUI.ToolStripDropDown dd = tsddi.DropDown;
                    GetSecurity(dd);
                }
                if (item is WinUI.ToolStripDropDownButton)
                {
                    WinUI.ToolStripDropDownButton tsddb = (WinUI.ToolStripDropDownButton)item;
                    WinUI.ToolStripDropDown ddb = tsddb.DropDown;
                    GetSecurity(ddb);
                }
            }
        }
        
        private static void GetSecurity(WinUI.ToolStripDropDown dd)
        {
            if (dd.Name.Length > 2)
                _sLevelPre = dd.Name;
            foreach (WinUI.ToolStripItem item in dd.Items)
            {
                //if (item.GetCurrentParent() != null)
                //    if (item.GetCurrentParent().Name.Length > 1)
                //        _sLevelPre = item.GetCurrentParent().Name;
                 string cname = item.Name;
                 AddChoice(cname, item.Text, item, "MenuItem");
                 
                 if (item is WinUI.ToolStripMenuItem)
                 {
                     WinUI.ToolStripMenuItem tsm = (WinUI.ToolStripMenuItem)item;
                     WinUI.ToolStripDropDown ddi = tsm.DropDown;
                     GetSecurity(ddi);
                 }
                 if (item is WinUI.ToolStripDropDownItem)
                 {
                     WinUI.ToolStripDropDownItem tsddi = (WinUI.ToolStripDropDownItem)item;
                     WinUI.ToolStripDropDown dd2 = tsddi.DropDown;
                     GetSecurity(dd2);
                 }
            }
        }

        private static void AddChoice(string sName, string sDescr, object obj, string sType)
        {
            // Add this item as a list of security objects from which
            if (sName == null)
                return;
            if (sName.Length < 2)
                return;
            if (IsNotSecurityObject(obj))
                return;

            // Don't add if it's already in the list
            foreach (ClsSecurityChoices sc in _choices)
            {
                if (sc.sName == sName)
                    return;
            }

            ClsSecurityChoices c = new ClsSecurityChoices();
            
            ClsSecurityObject secobj = ClsSecurityObject.GetObject(_sParent, sName);
            c.sPrevLevel = _sLevelPre;
            c.sName = sName;
            c.sDescr = sDescr.Replace("&", "");
            c.sType = sType;

            if (secobj == null)
                c.bExists = false;
            else
                c.bExists = true;

            _choices.Add(c);
        }

        private static bool IsNotSecurityObject(object obj)
        {
            WinUI.TabPage tpg = obj as WinUI.TabPage;
            if (tpg != null) return false;

            WinUI.ToolStripSeparator tss = obj as WinUI.ToolStripSeparator;
            if (tss != null) return true;

            WinUI.Panel pnl = obj as WinUI.Panel;
            if (pnl != null) return true;

            WinUI.SplitContainer spc = obj as WinUI.SplitContainer;
            if (spc != null) return true;

            WinUI.StatusBar sst = obj as WinUI.StatusBar;
            if (sst != null) return true;

            WinUI.StatusStrip str = obj as WinUI.StatusStrip;
            if (str != null) return true;

            WinUI.PictureBox pcx = obj as WinUI.PictureBox;
            if (pcx != null) return true;

            return false;
        }

        public static void CreateObjects(List<ClsSecurityChoices> choices)
        {
            bool inTrans = Connection.IsInTransaction;
            try
            {
                if (!inTrans)
                    Connection.TransactionBegin();
                foreach (ClsSecurityChoices cs in choices)
                {
                    ClsSecurityObject so = new ClsSecurityObject();
                    so.Object_ID = 0;
                    so.Object_Nm = cs.sName;
                    so.Object_Dsc = cs.sDescr;
                    so.Parent_Nm = _SourceForm.Name;
                    so.Parent_Dsc = _SourceForm.Name;
                    so.Collection_Dsc = cs.sPrevLevel;
					so.Vendor_Control_Flg = "N";
					so.Finance_Flg = "N";
					if( cs.bEnabled )
                        so.Default_Enabled_Flg = so.Default_Visible_Flg = "Y";
                    else
                        so.Default_Enabled_Flg = so.Default_Visible_Flg = "N";

                    so.Insert();
                }
                if (!inTrans)
                    Connection.TransactionCommit();
            }
            catch
            {
                if (!inTrans)
                    Connection.TransactionRollback();
                throw;
            }
        }

		#endregion		// #region Public methods

		#region Helper methods

		private static void SetSecurity(WebUI.Control container, DataTable dt)
		{
			if( dt == null || dt.Rows == null || dt.Rows.Count <= 0 ||
				container == null ) return;

			WebUI.ControlCollection ctrls = container.HasControls() == true ?
				container.Controls : null;
			if( ctrls == null || ctrls.Count <= 0 ) return;

			foreach( WebUI.Control c in ctrls )
			{
				if( c.ID == null || c.ID.Length <= 0 ) continue;

				byte priority = 0;
				foreach( DataRow dr in dt.Rows )
				{
					string name = ClsConvert.ToString(dr["Object_Nm"]);
					if( string.Compare(name, c.ID, true) != 0 ) continue;
					byte p = ClsConvert.ToByte(dr["Priority_Nbr"]);
					if( p < priority ) continue;
					priority = p;
					c.Visible = ClsConvert.StringToBool(dr["Visible_Flg"]);
                    WebUIWC.WebControl wc = c as WebUIWC.WebControl;
					if( wc != null )
						wc.Enabled = ClsConvert.StringToBool(dr["Enabled_Flg"]);
				}
				if( c.HasControls() == true ) SetSecurity(c, dt);
			}
		}

		private static void SetSecurity(WinUI.Control container, DataTable dt)
		{
			if( dt == null || dt.Rows == null || dt.Rows.Count <= 0 ||
				container == null ) return;

			WinUI.Control.ControlCollection ctrls = container.Controls;

            if (container.Name.Contains("tpg"))
            {
                string xxx = container.Name;
            }
            Janus.Windows.GridEX.GridEX grd = container as Janus.Windows.GridEX.GridEX;
            if (grd != null)
                SetSecurity(grd, dt);
			if( ctrls == null || ctrls.Count <= 0 ) return;

			//foreach( WinUI.Control c in container.Controls )
            int ix = container.Controls.Count - 1;
            while (ix > -1)
			{
                WinUI.Control c = container.Controls[ix];
                ix = ix - 1;
				byte priority = 0;
				foreach( DataRow dr in dt.Rows )
				{
                    if (c.Name.Contains("Port"))
                    {
                        string x = c.Name;

                    }

                    if (c.Name.Contains("inanc"))
                    {
                        string xxx = c.Name;
                    }
					string name = ClsConvert.ToString(dr["Object_Nm"]);
					if( string.Compare(name, c.Name, true) != 0 ) continue;
					byte p = ClsConvert.ToByte(dr["Priority_Nbr"]);
					if( p < priority ) continue;
					priority = p;
					c.Visible = ClsConvert.StringToBool(dr["Visible_Flg"]);
                    // DG - Remove disabling this for now.
					//c.Enabled = ClsConvert.StringToBool(dr["Enabled_Flg"]);
                    if (c is WinUI.TabPage)
                    {
                        if (!ClsConvert.StringToBool(dr["Visible_Flg"]))
                        {
                            //c.Parent = null;
                            c.Parent.Controls.Remove(c);
                        }
                    }
                    // DG - Removed disabling for now.
                    //if (c is ucTextBox)
                    //{
                    //    if (!c.Enabled)
                    //    {
                    //        ucTextBox txtc = c as ucTextBox;
                    //        txtc.ReadOnly = true;
                    //        txtc.Enabled = true;
                    //        if (txtc.LabelType == TextLabelType.Link)
                    //            txtc.LabelType = TextLabelType.Label;
                    //    }
                    //}
                    //if (c is ucListView)
                    //{
                    //    if (!c.Enabled)
                    //    {
                    //        ucListView lvc = c as ucListView;
                    //        lvc.ReadOnly = true;
                    //        lvc.Enabled = true;
                    //        if (lvc.LabelType == TextLabelType.Link)
                    //            lvc.LabelType = TextLabelType.Label;
                    //    }
                    //}
				}
				if( c.Controls != null && c.Controls.Count > 0 )
					SetSecurity(c, dt);
				WinUI.ToolStrip ts = c as WinUI.ToolStrip;
				if( ts != null ) SetSecurity(ts, dt);
                // If it's a treeview, get the nodes
                WinUI.TreeView tv = c as WinUI.TreeView;
                if (tv != null) SetSecurity(tv, dt);
			}
		}

        private static void SetSecurity(WinUI.TreeView tv, DataTable dt)
        {
            //foreach (WinUI.TreeNode node in tv.Nodes)
            int ix = tv.Nodes.Count - 1;
            while (ix > -1)
            {
                WinUI.TreeNode node = tv.Nodes[ix];
                byte priority = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    string cname = node.Name;
                    string name = ClsConvert.ToString(dr["Object_Nm"]);
                    if (string.Compare(name, node.Name, true) != 0) continue;
                    byte p = ClsConvert.ToByte(dr["Priority_Nbr"]);
                    if (p < priority) continue;
                    priority = p;
                    if (ClsConvert.StringToBool(dr["Visible_Flg"]) == false)
                        node.Remove();
                }
                ix = ix - 1;
            }
        }

        private static void SetSecurity(GridEX grd, DataTable dt)
        {
            foreach (GridEXTable tbl in grd.Tables)
            {
                foreach (GridEXColumn col in tbl.Columns)
                {
                    byte priority = 0;
                    string xname = col.Key;
                    foreach (DataRow dr in dt.Rows)
                    {
                        string cname = col.Key;
                        string name = ClsConvert.ToString(dr["Object_Nm"]);
                        if (string.Compare(name, cname, true) != 0) continue;
                        byte p = ClsConvert.ToByte(dr["Priority_Nbr"]);
                        if (p < priority) continue;
                        priority = p;
                        bool bVisible = ClsConvert.StringToBool(dr["Visible_Flg"]);
                        if (ClsConvert.StringToBool(dr["Visible_Flg"]) == false)
                        {
                            col.Visible = false;
                        }
                        // DG - Remove disabling for now
                        //if (ClsConvert.StringToBool(dr["Enabled_Flg"]) == false)
                        //{
                        //    if (col.ColumnType == ColumnType.Link)
                        //        col.ColumnType = ColumnType.Text;
                        //}
                            
                    }
                }
            }
        }

		private static void SetSecurity(WinUI.ToolStrip ts, DataTable dt)
		{
			foreach( WinUI.ToolStripItem item in ts.Items )
			{
				byte priority = 0;
				foreach( DataRow dr in dt.Rows )
				{
					string cname = item.Name;
					string name = ClsConvert.ToString(dr["Object_Nm"]);
					if( string.Compare(name, item.Name, true) != 0 ) continue;
					byte p = ClsConvert.ToByte(dr["Priority_Nbr"]);
					if( p < priority ) continue;
					priority = p;
					item.Visible = ClsConvert.StringToBool(dr["Visible_Flg"]);
                    // DG - Remove disabling for now
					//item.Enabled = ClsConvert.StringToBool(dr["Enabled_Flg"]);
				}
				if( item is WinUI.ToolStripDropDownItem )
				{
					WinUI.ToolStripDropDownItem tsddi = (WinUI.ToolStripDropDownItem)item;
					WinUI.ToolStripDropDown dd = tsddi.DropDown;
					SetSecurity(dd, dt);
				}
				else if( item is WinUI.ToolStripMenuItem )
				{
					WinUI.ToolStripMenuItem tsm = (WinUI.ToolStripMenuItem)item;
					WinUI.ToolStripDropDown dd = tsm.DropDown;
					SetSecurity(dd, dt);
				}
			}
		}

        private static void SetSecurity(WinUI.ToolStripDropDown dd, DataTable dt)
        {
            foreach (WinUI.ToolStripItem item in dd.Items)
            {
                byte priority = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    string cname = item.Name;
                    string name = ClsConvert.ToString(dr["Object_Nm"]);
                    if (string.Compare(name, item.Name, true) != 0) continue;
                    byte p = ClsConvert.ToByte(dr["Priority_Nbr"]);
                    if (p < priority) continue;
                    priority = p;
                    item.Visible = ClsConvert.StringToBool(dr["Visible_Flg"]);
                    // DG - Remove disabling for now
                    //item.Enabled = ClsConvert.StringToBool(dr["Enabled_Flg"]);
                }
                if (item is WinUI.ToolStripMenuItem)
                {
                    WinUI.ToolStripMenuItem tsm = (WinUI.ToolStripMenuItem)item;
                    WinUI.ToolStripDropDown ddi = tsm.DropDown;
                    SetSecurity(ddi, dt);
                }
            }
        }

        /// <summary>
        /// Finds all objects within the application and returns them
        /// as a Dictionary
        /// </summary>
        /// <param name="container"></param>
        /// <returns></returns>
        public static List<ClsObjectList> GetSecurityObjects(WinUI.Control container)
        {
            InitObjectList();
            PopulateSecurityObjects(container);
            return _objectlist;
        }

        private static void PopulateSecurityObjects(WinUI.Control container)
        {
            if (container == null) return;

            WinUI.Control.ControlCollection ctrls = container.Controls;
            if (ctrls == null || ctrls.Count <= 0) return;
            
            foreach (WinUI.Control c in container.Controls)
            {
                if (c.Name.Length > 1)
                {
                    ClsObjectList o = new ClsObjectList();
                    o.key = c.Name;
                    o.keyvalue = c.Name;
                    if (!_objectlist.Contains(o))
                        _objectlist.Add(o);
                }
                if (c.Controls != null && c.Controls.Count > 0)
                    PopulateSecurityObjects(c);

                WinUI.ToolStrip ts = c as WinUI.ToolStrip;
                if (ts != null) PopulateSecurityObjects(ts);
            }
        }
		#endregion		// #region Helper methods

        #region Structures
        public class ClsObjectList
        {
            private string _key;
            private string _keyvalue;

            public string key
            {
                get { return _key; }
                set { _key = value; }
            }
            public string keyvalue
            {
                get { return _keyvalue; }
                set { _keyvalue = value; }
                }
        }

        public class ClsSecurityChoices 
        {
            private string _sPrevLevel;
            private string _sName;
            private string _sDescr;
            private string _sType;
            private bool _bExists;
            private bool _bEnabled;
            public string sPrevLevel
            {
                get { return _sPrevLevel; }
                set { _sPrevLevel = value; }
            }
            public string sName
            {
                get { return _sName; }
                set { _sName = value; }
            }
            public string sDescr
            {
                get { return _sDescr; }
                set { _sDescr = value; }
            }
            public string sType
            {
                get { return _sType; }
                set { _sType = value; }
            }
            public bool bExists
            {
                get { return _bExists; }
                set { _bExists = value; }
            }
            public bool bEnabled
            {
                get { return _bEnabled; }
                set { _bEnabled = value; }
            }

        }

        #endregion
    }
}