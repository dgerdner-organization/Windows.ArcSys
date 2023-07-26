using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CS2010.CommonWinCtrls
{
	public partial class frmSearchEdit : frmChildBase
	{

		#region Properties

		private DataTable _DT = new DataTable();
		private DataRow _DR;
		private int InsertOrEdit = 0;

		public DataTable DT
		{
			get { return _DT; }
			set { _DT = value; grdResults.DataSource = _DT; }
		}

		public DataRow DR
		{
			get { return _DR; }
		}

		public bool IS_UPDATE
		{
			get { return (InsertOrEdit == 2); }
		}

		public bool IS_INSERT
		{
			get { return (InsertOrEdit == 1); }
		}

		public bool BUTTON_SEARCH_VISIBLE
		{
			get { return this.tsbSearch.Visible; }
			set { tsbSearch.Visible = value; }
		}

		public bool BUTTON_CLEAR_VISIBLE
		{
			get { return Visible; }
			set { tsbClear.Visible = value; }
		}

		public bool BUTTON_NEW_VISIBLE
		{
			get { return tsbNew.Visible; }
			set { tsbNew.Visible = value; }
		}

		public bool BUTTON_EDIT_VISIBLE
		{
			get { return tsbEdit.Visible; }
			set { tsbEdit.Visible = value; }
		}
	
		public bool BUTTON_DELETE_VISIBLE
		{
			get { return tsbDelete.Visible	; }
			set { tsbDelete.Visible = value; }
		}

		public bool BUTTON_SAVE_VISIBLE
		{
			get { return tsbSave.Visible; }
			set { tsbSave.Visible = value; }
		}
	
		public bool	BUTTON_CANCEL_VISIBLE
		{
			get { return tsbCancel.Visible; }
			set { tsbCancel.Visible = value; }
		}

        private int SearchHeight = 0;

        public bool SEARCH_SECTION_VISIBLE
        {
            get { return gbSearch.Visible; }
            set
            {

                if (splitContainerMain.Panel1.Height > 0) SearchHeight = splitContainerMain.Panel1.Height;

                splitContainerMain.Panel1.Enabled = 
                gbSearch.Visible = value;

                if (gbSearch.Visible)
                {
                    splitContainerMain.Panel1.Height = SearchHeight;
                }
                else
                {
                    splitContainerMain.Panel1.Height = 0;
                }

                // May need further modification to search section ...
            }
        }

		#endregion

		#region Virtual Methods

		protected virtual bool SearchData() { return true; }
		protected virtual bool ClearData() { return true; }
		protected virtual bool NewData() { InsertOrEdit = 1;  return true; }
		protected virtual bool EditData() { InsertOrEdit = 2; return true; }
		protected virtual bool DeleteData() { return true; }
		protected virtual bool SaveChanges() { return true; }
		protected virtual bool CancelChanges() { return true; }
		protected virtual void RowChanged(DataRow dr) {  }

		#endregion

		#region Constructor

		public frmSearchEdit()
		{
			InitializeComponent();
			grdResults.DataSource = _DT;
			FormStateNormal();
		}		

		#endregion

		#region Private Methods

		private void FormStateNormal()
		{
			splitContainerMain.Panel1.Enabled = true;
			splitContainerSub.Panel1.Enabled = true;
			splitContainerSub.Panel2.Enabled = false;

			tsbSearch.Enabled =
			tsbClear.Enabled =
			tsbNew.Enabled =
			tsbEdit.Enabled =
			tsbDelete.Enabled = true;

			tsbSave.Enabled =
			tsbCancel.Enabled = false;
		}

		private void FormStateUpdate()
		{
			splitContainerMain.Panel1.Enabled = false;
			splitContainerSub.Panel1.Enabled = false;
			splitContainerSub.Panel2.Enabled = true;

			tsbSearch.Enabled =
			tsbClear.Enabled =
			tsbNew.Enabled =
			tsbEdit.Enabled =
			tsbDelete.Enabled = false;

			tsbSave.Enabled =
			tsbCancel.Enabled = true;
		}

		private void SelectionChanged()
		{
			DataRow DR_TEMP = grdResults.GetDataRow();

			if( DR_TEMP == null ) return;
			
			_DR = DR_TEMP;
			RowChanged(DR_TEMP);
		}

		#endregion

		#region Event Handlers

		private void tsbNew_Click(object sender, EventArgs e)
		{
			if( NewData() ) FormStateUpdate();
		}

		private void tsbEdit_Click(object sender, EventArgs e)
		{
			if( EditData() ) FormStateUpdate();
		}

		private void tsbDelete_Click(object sender, EventArgs e)
		{
			DeleteData(); 
		}

		private void tsbSave_Click(object sender, EventArgs e)
		{
			if( SaveChanges() ) FormStateNormal();
		}

		private void tsbCancel_Click(object sender, EventArgs e)
		{
			if( CancelChanges() ) FormStateNormal();
		}

		private void tsbSEARCH_Click(object sender, EventArgs e)
		{
			if( SearchData() ) grdResults.Refresh();
		}

		private void tsbCLEAR_Click(object sender, EventArgs e)
		{
			ClearData();
		}		

		private void grdResults_SelectionChanged(object sender, EventArgs e)
		{
			SelectionChanged();
		}

		#endregion


	}
}