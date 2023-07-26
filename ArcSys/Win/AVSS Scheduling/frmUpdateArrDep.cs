using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CS2010.AVSS.Business;
using CS2010.Common;
using CS2010.CommonWinCtrls;
using Janus.Windows.GridEX;

namespace CS2010.AVSS.Win 
{
	public partial class frmUpdateArrDep : Form
	{
		private BindingList<mConvenientArrDep> _lstCAD;

		public frmUpdateArrDep()
		{
			InitializeComponent();
		}

		public void ShowOpen(BindingList<mConvenientArrDep> lstCAD)
		{
			_lstCAD = lstCAD;
			grdData.DataSource = _lstCAD;
			Font f = new Font("Verdana",14);
			SetFont(f);
			ShowPanel(false);
			this.ShowDialog();
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			Save();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			FormClose();
		}

		private void btnFont_Click(object sender, EventArgs e)
		{
			Fonts();
		}

		private void FormClose()
		{
			this.Close();
		}

		#region Private Methods

		private void Save()
		{
			try
			{
				int x = 0;

				grdData.UpdateData();

				foreach( mConvenientArrDep cad in _lstCAD )
				{
					if( cad.IsDirty )
					{
						cad.Update();
						x++;
					}
				}
				MessageBox.Show(string.Format("Update complete! {0} rows updated.", x)); 
			
			}
			catch( Exception ex )
			{
                Display.ShowError(ex);
			}
		}

		private void Fonts()
		{
			try
			{
				if( fontDialog.ShowDialog() == DialogResult.OK )
				{
					SetFont(fontDialog.Font);
				}
				grdData.Row = 0;
			}
			catch( Exception ex )
			{
				Display.ShowError(ex);
			}
		}

		private void SetFont(Font f)
		{
			grdData.Font = txtArriveDt.Font = cbxArrive.Font = txtDepartDt.Font = cbxDepart.Font = lblArrive.Font = lblDepart.Font = f;
		}

		private void ShowPanel(bool show)
		{
			pnlAD.Visible = show;
            txtArriveDt.MaxDate = DateTime.Today.AddYears(2);
            txtDepartDt.MaxDate = DateTime.Today.AddYears(2);
            txtArriveDt.MinDate = DateTime.Today.AddYears(-5);
            txtDepartDt.MinDate = DateTime.Today.AddYears(-5);
            
		}

		private void ClearGridStyle()
		{
			GridEXFormatStyle NormalStyle = new GridEXFormatStyle();
			NormalStyle.BackColor = Color.White;
			NormalStyle.ForeColor = Color.Black;

			foreach( GridEXRow g in grdData.GetRows() ) g.RowStyle = NormalStyle;

			grdData.Refresh();
		}

		#endregion

		private void grdData_Click(object sender, EventArgs e)
		{
			if( grdData.CurrentRow == null )
			{
				txtArriveDt.Enabled = txtDepartDt.Enabled = cbxArrive.Enabled = cbxDepart.Enabled = false;
				return;
			}
			if( grdData.CurrentRow.RowType.ToString() == "FilterRow" ) return;

			mConvenientArrDep current = (mConvenientArrDep)grdData.CurrentRow.DataRow;

			try
			{
				// Remove any previous bindings 
				txtArriveDt.DataBindings.RemoveAt(0);
				cbxArrive.DataBindings.RemoveAt(0);
				txtDepartDt.DataBindings.RemoveAt(0);
				cbxDepart.DataBindings.RemoveAt(0);
			}
			catch
			{
				// ... Continue ...
			}

			// Add New Bindings
			BindHelper.Bind(txtArriveDt, current, "Arrive_Dt");
			BindHelper.Bind(cbxArrive, current, "Act_Arrive_Flg");
			BindHelper.Bind(txtDepartDt, current, "Depart_Dt");
			BindHelper.Bind(cbxDepart, current, "Act_Depart_Flg");
			ShowPanel(true);
		}

		private void grdData_Enter(object sender, EventArgs e)
		{
			ShowPanel(true);
		}

		private void panel1_Enter(object sender, EventArgs e)
		{
			ShowPanel(false);
		}
	}
}