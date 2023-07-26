using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CS2010.CommonWinCtrls
{
    public partial class ucSearchContainer : ucSplitContainer
    {

        #region Declaring Events

        public event SearchEventHandler SearchClicked;
        public delegate void SearchEventHandler(object sender, EventArgs e);

        public event ClearEventHandler ClearClicked;
        public delegate void ClearEventHandler(object sender, EventArgs e);    
    
        #endregion

        #region Initialization

        public ucSearchContainer()
        {
            InitializeComponent();
        }

        public ucSearchContainer(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }        

        #endregion

        #region Variables / Properties

        public int _SearchPanelMin = 1;
        public int _SearchPanelMax = 250;

        public int SearchPanelMin 
        {
            get
            {
                return _SearchPanelMin;
            }
        }

        public int SearchPanelMax
        {
            get
            {
                return _SearchPanelMax;
            }
            set
            {
                _SearchPanelMax = value;
            }
        }

        public Boolean SearchPanelOpen = true; 
       
        #endregion

        #region Event Handlers

        private void SearchContainer_DoubleClick(object sender, EventArgs e)
        {
            MouseEventArgs mea = (MouseEventArgs)e;

            if ((mea.X > this.SplitterDistance) && (mea.X < (this.SplitterDistance + this.SplitterWidth)))
                Action();

        }

        private void SearchContainer_SplitterMoved(object sender, SplitterEventArgs e)
        {
            if (DesignMode)
                SearchPanelMax = this.SplitterDistance;
            else
                if (this.SplitterDistance == SearchPanelMin)
                    return;
                else
                    SearchPanelMax = this.SplitterDistance;

            this.Panel1.Refresh();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearClicked(new object(), new EventArgs());
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchClicked(new object(), new EventArgs());
        }

        private void SearchContainer_Resize(object sender, EventArgs e)
        {
            SearchPanelOpen = !SearchPanelOpen;
            Panel1.Refresh();
            Panel2.Refresh();
            Action();
        }

        #endregion

        #region Private Methods

        private void Action()
        {
            if (SearchPanelOpen)
                this.SplitterDistance = SearchPanelMin;
            else
                this.SplitterDistance = SearchPanelMax;

            SearchPanelOpen = !SearchPanelOpen;

            MakeInvisible(SearchPanelOpen);
        }

        private void MakeInvisible(Boolean blnVisible)
        {
            foreach (Control c in this.Panel1.Controls)
                c.Visible = blnVisible;

            PictureBox.Visible = true;
        }        

        #endregion

    }
}
