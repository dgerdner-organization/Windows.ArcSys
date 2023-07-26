using System;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;

namespace CS2010.CommonWinCtrls
{
	public partial class frmEmailList : frmDialogBase
	{
		#region Fields

		private List<string> _SelectedAddresses;
		private List<string> _AvailableAddresses;
 
		#endregion		// #region Fields

		#region Properties

		public List<string> AvailableAddresses
		{
			get { return _AvailableAddresses; }
			set { _AvailableAddresses = value; }
		}

		public List<string> SelectedAddresses
		{
			get { return _SelectedAddresses; }
			set { _SelectedAddresses = value; }
		}

		public string CommaSeparatedAddresses
		{
			get
			{
				if( _SelectedAddresses == null || _SelectedAddresses.Count <= 0 ) return null;

				StringBuilder sb = new StringBuilder();
				foreach( string s in _SelectedAddresses )
					sb.AppendFormat("{0}{1}", ( sb.Length > 0 ? ", " : null ), s);

				return sb.ToString();
			}
			set
			{
				List<string> lst = null;
				string s = string.IsNullOrEmpty(value) ? null : value.Trim();
				string[] ss = string.IsNullOrEmpty(s) ? null : s.Split(new char[] { ',' });
				if( ss != null && ss.Length > 0 )
				{
					foreach( string addr in ss )
					{
						string t = string.IsNullOrEmpty(addr) ? null : addr.Trim();
						if( string.IsNullOrEmpty(t) ) continue;

						if( lst == null ) lst = new List<string>();

						lst.Add(t);
					}
				}
				_SelectedAddresses = lst;
			}
		}
		#endregion		// #region Properties

		#region Constructors

		public frmEmailList()
		{
			InitializeComponent();
		}
		#endregion		// #region Constructors

		#region Public Methods

		public bool ShowList()
		{
			try
			{
				tvwAddresses.Nodes.Clear();

				if( _AvailableAddresses != null )
				{
					foreach( string s in _AvailableAddresses )
					{
						string s1 = string.IsNullOrEmpty(s) ? null : s.Trim();
						if( string.IsNullOrEmpty(s1) ) continue;

						TreeNode tn = tvwAddresses.Nodes.Add(s1);
						if( _SelectedAddresses != null && _SelectedAddresses.Contains(s1) )
							tn.Checked = true;
					}
				}

				if( tvwAddresses.Nodes.Count <= 0 )
					return Display.ShowError("Email List", "No addresses provided");

				return ShowDialog() == DialogResult.OK;
			}
			catch( Exception ex )
			{
				return Display.ShowError("Email List", ex);
			}
		}
		#endregion		// #region Public Methods

		#region Helper Methods

		private void SetNodeState(bool nodeChecked)
		{
			try
			{
				foreach( TreeNode tn in tvwAddresses.Nodes ) tn.Checked = nodeChecked;
			}
			catch( Exception ex )
			{
				Display.ShowError("Email List", ex);
			}
		}
		#endregion		// #region Helper Methods

		#region Overrides

		protected override bool SaveChanges()
		{
			try
			{
				_SelectedAddresses = null;
				foreach( TreeNode tn in tvwAddresses.Nodes )
				{
					if( !tn.Checked ) continue;

					if( _SelectedAddresses == null ) _SelectedAddresses = new List<string>();

					_SelectedAddresses.Add(tn.Text);
				}

				return true;
			}
			catch( Exception ex )
			{
				return Display.ShowError("Email List", ex);
			}
		}
		#endregion		// #region Overrides

		#region Event Handlers

		private void btnCheckAll_Click(object sender, EventArgs e)
		{
			SetNodeState(true);
		}

		private void btnUncheckAll_Click(object sender, EventArgs e)
		{
			SetNodeState(false);
		}
		#endregion		// #region Event Handlers
	}
}