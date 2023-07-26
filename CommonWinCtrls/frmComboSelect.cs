using System;
using System.Drawing;
using System.Windows.Forms;
using Janus.Windows.GridEX.EditControls;

namespace CS2010.CommonWinCtrls
{
	public partial class frmComboSelect<T> : Form where T : ComboBase, IComboBox, new()
	{
		#region Fields

		private T theControl;

		#endregion		// #region Fields

		#region Properties

		public T ComboBox
		{
			get { return theControl; }
			set
			{
				theControl = value;
				if( theControl == null ) return;

				theControl.Parent = this;
				theControl.Name = "cmbSelect";
				theControl.Size = new Size(326, 20);
				theControl.Location = new Point(12, 12);
				theControl.TabIndex = 0;

				IComboBox cmb = theControl as IComboBox;
				if( cmb != null ) cmb.DisplayType = ComboDisplay.CodePlusDescription;
			}
		}
		#endregion		// #region Properties

		#region Constructors

		protected frmComboSelect()
		{
			InitializeComponent();
		}

		public frmComboSelect(string title)
		{
			InitializeComponent();

			Text = title;
		}
		#endregion		// #region Constructors

		#region Public Methods

		public bool GetSelection()
		{
			try
			{
				return ShowDialog() == DialogResult.OK;
			}
			catch( Exception ex )
			{
				return Display.ShowError("Error", ex);
			}
		}
		#endregion		// #region Public Methods

		#region Event Handlers

		private void btnOK_Click(object sender, EventArgs e)
		{
			try
			{
				ucMultiColumnCombo cmbSingle = theControl as ucMultiColumnCombo;
				ucCheckedComboBox cmbMulti = theControl as ucCheckedComboBox;
				if( cmbSingle == null && cmbMulti == null ) return;

				if( cmbSingle != null )
				{
					if( cmbSingle.Value == null || string.IsNullOrEmpty(cmbSingle.Text) )
						return;
				}
				else
				{
					if( cmbMulti.CheckedItems == null ) return;

					foreach( object obj in cmbMulti.CheckedItems )
						if( obj == null ) return;
				}

				DialogResult = DialogResult.OK;
			}
			catch( Exception ex )
			{
				Display.ShowError("Error", ex);
			}
		}
		#endregion		// #region Event Handlers
	}
}