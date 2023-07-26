using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CS2010.Common;

namespace CS2010.CommonWinCtrls
{
    public partial class frmCRUD : Form
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

        public string WINDOW_TITLE
        {
            get { return this.Text; }
            set { this.Text = value; }
        }

		public bool IS_UPDATE
		{
			get { return (InsertOrEdit == 2); }
		}

		public bool IS_INSERT
		{
			get { return (InsertOrEdit == 1); }
		}

        private bool _BUTTON_NEW_VISIBLE = true;

        [Browsable(true)]
        [DefaultValue(true)]
        [ParenthesizePropertyName(true)]
        [Description("Shows or Hides the 'New' Button.")]
        public bool BUTTON_NEW_VISIBLE
		{
            get { return _BUTTON_NEW_VISIBLE; }
            set { _BUTTON_NEW_VISIBLE = value; RefreshDisplay();  }
		}

        private bool _BUTTON_EDIT_VISIBLE = true;

        [Browsable(true)]
        [DefaultValue(true)]
        [ParenthesizePropertyName(true)]
        [Description("Shows or Hides the 'Edit' Button.")]
		public bool BUTTON_EDIT_VISIBLE
		{
            get { return _BUTTON_EDIT_VISIBLE; }
            set { _BUTTON_EDIT_VISIBLE = value; RefreshDisplay(); }
		}


        private bool _BUTTON_DELETE_VISIBLE = true;

        [Browsable(true)]
        [DefaultValue(true)]
        [ParenthesizePropertyName(true)]
        [Description("Shows or Hides the 'Delete' Button.")]
		public bool BUTTON_DELETE_VISIBLE
		{
            get { return _BUTTON_DELETE_VISIBLE; }
            set { _BUTTON_DELETE_VISIBLE = value; RefreshDisplay(); }
		}

        private bool _BUTTON_SAVE_VISIBLE = true;

        [Browsable(true)]
        [DefaultValue(true)]
        [ParenthesizePropertyName(true)]
        [Description("Shows or Hides the 'Save' Button.")]
		public bool BUTTON_SAVE_VISIBLE
		{
            get { return _BUTTON_SAVE_VISIBLE; }
            set { _BUTTON_SAVE_VISIBLE = value; RefreshDisplay();  }
		}

        private bool _BUTTON_CANCEL_VISIBLE = true;

        [Browsable(true)]
        [DefaultValue(true)]
        [ParenthesizePropertyName(true)]
        [Description("Shows or Hides the 'Cancel' Button.")]
		public bool	BUTTON_CANCEL_VISIBLE
		{
            get { return _BUTTON_CANCEL_VISIBLE; }
            set { _BUTTON_CANCEL_VISIBLE = value; RefreshDisplay(); }
		}

        private int _PANEL_RESULTS_MIN_SIZE = 100;

        [Browsable(true)]
        [ParenthesizePropertyName(true)]
        [DefaultValue(100)]
        [Description("Sets the 'minimum' height of the 'results' panel.")]
        public int PANEL_RESULTS_MIN_SIZE
        {
            get { return _PANEL_RESULTS_MIN_SIZE; }
            set { _PANEL_RESULTS_MIN_SIZE = value; RefreshDisplay(); }
        }

        private int _PANEL_DATA_MIN_SIZE = 100;

        [Browsable(true)]
        [ParenthesizePropertyName(true)]
        [DefaultValue(100)]
        [Description("Sets the 'minimum' height of the 'data' panel.")]
        public int PANEL_DATA_MIN_SIZE
        {
            get { return _PANEL_DATA_MIN_SIZE; }
            set { _PANEL_DATA_MIN_SIZE = value; RefreshDisplay();  }
        }

		#endregion

		#region Virtual Methods

        protected virtual bool NewData() { InsertOrEdit = 1; return true; }
        protected virtual bool EditData(DataRow dr) { InsertOrEdit = 2; return true; }
		protected virtual bool DeleteData(DataRow dr) { return true; }
        protected virtual bool SaveChanges() { return true; }
        protected virtual bool CancelChanges() { return true; }
		protected virtual void RowChanged(DataRow dr) {  }
        protected virtual void InsertCalled() { }
        protected virtual void UpdateCalled() { }
        protected virtual void DeleteCalled() { } 

		#endregion

		#region Constructor

        public frmCRUD()
		{
			InitializeComponent();
			grdResults.DataSource = _DT;
            RefreshDisplay();
			FormStateNormal();
		}		

		#endregion

		#region Private Methods

        private void RefreshDisplay()
        {
            tsbNew.Visible = tsSeparatorNew.Visible = _BUTTON_NEW_VISIBLE;
            tsbEdit.Visible = tsSeparatorEdit.Visible = _BUTTON_EDIT_VISIBLE;
            tsbDelete.Visible = tsSeparatorDelete.Visible = _BUTTON_DELETE_VISIBLE;
            tsbSave.Visible = tsSeparatorSave.Visible = _BUTTON_SAVE_VISIBLE;
            tsbCancel.Visible = tsSeparatorCancel.Visible = _BUTTON_CANCEL_VISIBLE;


        }

		private void FormStateNormal()
		{
            grdResults.Enabled = true;
            panel1.Enabled = false;

			tsbNew.Enabled =
			tsbEdit.Enabled =
			tsbDelete.Enabled = true;

			tsbSave.Enabled =
			tsbCancel.Enabled = false;

            if (grdResults.RecordCount > 0)
            {
                grdResults_SelectionChanged(null, new EventArgs());
            }

		}

		private void FormStateUpdate()
		{
            grdResults.Enabled = false;
            panel1.Enabled = true;

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
            InsertCalled();
			if( NewData() ) FormStateUpdate();
		}

		private void tsbEdit_Click(object sender, EventArgs e)
		{
            DataRow DR_TEMP = grdResults.GetDataRow();
            if (DR_TEMP == null) return;
            _DR = DR_TEMP;

            UpdateCalled();
            if (EditData(DR_TEMP)) FormStateUpdate();
		}

		private void tsbDelete_Click(object sender, EventArgs e)
		{
            DataRow DR_TEMP = grdResults.GetDataRow();
            if (DR_TEMP == null) return;
            _DR = DR_TEMP;

            DeleteCalled();
            DeleteData(DR_TEMP); 
		}

		private void tsbSave_Click(object sender, EventArgs e)
		{
			if( SaveChanges() ) FormStateNormal();
		}

		private void tsbCancel_Click(object sender, EventArgs e)
		{
			if( CancelChanges() ) FormStateNormal();
		}

		private void grdResults_SelectionChanged(object sender, EventArgs e)
		{
			SelectionChanged();
		}

		#endregion




    }
}
