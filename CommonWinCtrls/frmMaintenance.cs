using System;
using System.Windows.Forms;
using CS2010.Common;

namespace CS2010.CommonWinCtrls
{
	public partial class frmMaintenance : Form
	{
		#region Properties

		private IMaintenance _OBJ;

		public IMaintenance OBJ
		{
			get { return _OBJ; }
			set
			{
				_OBJ = value;
			}
		}

		private string _Operation;

		public string Operation
		{
			get
			{
				return _Operation;
			}
			set
			{
				if( value == "I" ) _Operation = value;
				if( value == "U" ) _Operation = value;
			}
		}
		#endregion

		#region Constructors/Initialization

		public frmMaintenance()
		{
			InitializeComponent();
		}

		protected void MaintenanceFormLoad()
		{
			try
			{
				SetObject();

				if( OBJ != null )
				{
					lstBox.DisplayMember = OBJ.DisplayField();
					lstBox.ValueMember = OBJ.KeyField();
					lstBox.DataSource = OBJ.GetList();
				}

				FormStateNormal();
			}
			catch( Exception ex )
			{
				Display.ShowError("Maintenance Error", ex);
			}
		}
		#endregion		// #region Constructors/Initialization

		#region Virtual Methods

		protected virtual void Bind() { }
		public virtual void GetObject() { }
		public virtual void LoadObject() { }

		public virtual void SetObject()
		{
			Bind();
		}

		protected virtual void FormStateNormal()
		{
			try
			{
				ClsError.ResetAll();
				btnNew.Enabled =
					btnEdit.Enabled =
					btnDelete.Enabled =
					btnExit.Enabled =
					lstBox.Enabled = true;

				btnSave.Enabled =
					btnCancel.Enabled = false;
			}
			catch( Exception ex )
			{
				ClsError.AddError(ex.Message);
			}
			finally
			{
				if( ClsError.HasErrors ) Display.ShowError("Error", ClsError.ErrorMsg);
			}
		}

		protected virtual void FormStateEdit()
		{
			try
			{
				ClsError.ResetAll();
				btnNew.Enabled =
					btnEdit.Enabled =
					btnDelete.Enabled =
					btnExit.Enabled =
					lstBox.Enabled = false;

				btnSave.Enabled =
					btnCancel.Enabled = true;
			}
			catch( Exception ex )
			{
				ClsError.AddError(ex.Message);
			}
			finally
			{
				if( ClsError.HasErrors ) Display.ShowError("Error", ClsError.ErrorMsg);
			}
		}
		#endregion		// #region Virtual Methods

		#region Button Actions

		private void New()
		{
			try
			{
				Operation = "I";
				SetObject();
				FormStateEdit();
			}
			catch( Exception ex )
			{
				Display.ShowError("Maintenance Error", ex);
			}
		}

		private void Edit()
		{
			try
			{
				Operation = "U";
				FormStateEdit();
			}
			catch( Exception ex )
			{
				Display.ShowError("Maintenance Error", ex);
			}
		}

		private void Delete()
		{

			try
			{
				ClsError.ResetAll();

				if( Display.Ask("Confirm Delete",
					"Are you sure you want to DELETE the selected item?\r\n{0}", OBJ.ToString()) )
				{

					OBJ.CheckDelete();
					if( ClsError.HasErrors ) return;
					OBJ.Delete();
				}
				MaintenanceFormLoad();
			}
			catch( Exception ex )
			{
				ClsError.AddError(ex.Message);
			}
			finally
			{
				if( ClsError.HasErrors ) Display.ShowError("Error", ClsError.ErrorMsg);
			}
		}

		private void Save()
		{

			try
			{
				ClsError.ResetAll();

				GetObject();

				if( Operation == "I" )
				{
					OBJ.CheckInsert();
					if( ClsError.HasErrors ) return;
					OBJ.Insert();
				}
				else
				{
					OBJ.CheckUpdate();
					if( ClsError.HasErrors ) return;
					OBJ.Update();
				}
				MaintenanceFormLoad();
			}
			catch( Exception ex )
			{
				ClsError.AddError(ex.Message);
			}
			finally
			{
				if( ClsError.HasErrors ) Display.ShowError("Error", ClsError.ErrorMsg);
			}
		}

		private void Cancel()
		{
			try
			{
				LoadObject();
				FormStateNormal();
			}
			catch( Exception ex )
			{
				Display.ShowError("Maintenance Error", ex);
			}
		}
		#endregion		// #region Button Actions

		#region Event Handlers

		private void frmMaintenance_Load(object sender, EventArgs e)
		{
			MaintenanceFormLoad();
		}

		private void lstBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			LoadObject();
		}

		private void btnNew_Click(object sender, EventArgs e)
		{
			New();
		}

		private void btnEdit_Click(object sender, EventArgs e)
		{
			Edit();
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			Delete();
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			Save();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Cancel();
		}

		private void btnExit_Click(object sender, EventArgs e)
		{
			Close();
		}
		#endregion		// #region Event Handlers
	}
}