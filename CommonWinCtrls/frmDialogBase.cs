using System;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;
using CS2010.Common;
using Janus.Windows.GridEX;
using Janus.Windows.GridEX.EditControls;

namespace CS2010.CommonWinCtrls
{
	public partial class frmDialogBase : Form
	{
		#region Constants

		protected const string DefaultSaveMsg = "Changes have been saved";
		protected const string DefaultCancelMsg =
			"Changes have been made, continue and lose changes?";

		#endregion		// #region Constants

		#region Fields

		/// <summary>Storage for the <see cref="BusinessObject"/></summary>
		protected ClsBaseTable _BusinessObject;

		/// <summary>Storage for the <see cref="WarnOnCancel"/></summary>
		protected bool _WarnOnCancel;

		/// <summary>Storage for the <see cref="NotifyOnSave"/></summary>
		protected bool _NotifyOnSave;

		/// <summary>Storage for the <see cref="NotifyOnApply"/></summary>
		protected bool _NotifyOnApply;

		/// <summary>Storage for the <see cref="ShowApplyButton"/></summary>
		protected bool _ShowApplyButton;

		/// <summary>Storage for the <see cref="CancelMsg"/></summary>
		protected string _CancelMsg;

		/// <summary>Storage for the <see cref="SaveMsg"/></summary>
		protected string _SaveMsg;

		/// <summary>Storage for the <see cref="ButtonClicked"/></summary>
		protected DialogButton _ButtonClicked;

		/// <summary>This field is used to indicate the current mode of the
		/// dialog (e.g. Add vs Edit)</summary>
		/// <remarks>This would be set in the Entry method of the form
		/// (e.g. Add(), Edit(), AddClaim(), EditClaim, etc.)</remarks>
		protected DialogMode CurrentMode;

        protected bool AdminEditMode;

		#endregion		// #region Fields

		#region Properties

		/// <summary>Gets the button that triggered the click event</summary>
		public DialogButton ButtonClicked { get { return _ButtonClicked; } }

		/// <summary>Gets/Sets the business object that is being modified
		/// by the dialog</summary>
		[Browsable(false)]
		[Description("Gets/Sets the business object being modified")]
		public ClsBaseTable BusinessObject
		{
			get { return _BusinessObject; }
			set { _BusinessObject = value; }
		}

		/// <summary>Gets/Sets whether the Apply button should be displayed</summary>
		/// <remarks>False by default</remarks>
		[DefaultValue(false)]
		[Description("Gets/Sets whether the Apply button should be displayed")]
		public bool ShowApplyButton
		{
			get { return _ShowApplyButton; }
			set
			{
				_ShowApplyButton = value;
				btnApply.Enabled = btnApply.Visible = _ShowApplyButton;
			}
		}

		/// <summary>Gets/sets whether a warning should be displayed if
		/// Cancel is clicked but changes were made in the dialog</summary>
		[DefaultValue(false)]
		[Description("Gets/sets whether a warning should be displayed if " +
			"Cancel is clicked but changes were made in the dialog")]
		public bool WarnOnCancel
		{
			get { return _WarnOnCancel; }
			set { _WarnOnCancel = value; }
		}

		/// <summary>Gets/sets whether a message should be displayed when
		/// Save is clicked</summary>
		[DefaultValue(false)]
		[Description("Gets/sets whether a message should be displayed when " +
			"Save is clicked")]
		public bool NotifyOnSave
		{
			get { return _NotifyOnSave; }
			set { _NotifyOnSave = value; }
		}

		/// <summary>Gets/sets whether a message should be displayed when
		/// Apply is clicked</summary>
		[DefaultValue(false)]
		[Description("Gets/sets whether a message should be displayed when " +
			"Apply is clicked")]
		public bool NotifyOnApply
		{
			get { return _NotifyOnApply; }
			set { _NotifyOnApply = value; }
		}

		/// <summary>Gets/sets the message that is displayed when WarnOnCancel
		/// is true and the Cancel button is clicked</summary>
		[DefaultValue(frmDialogBase.DefaultCancelMsg)]
		[Description("Gets/sets the message that is displayed when " +
		   "WarnOnCancel is true and Cancel is clicked")]
		public string CancelMsg
		{
			get { return _CancelMsg; }
			set { _CancelMsg = value; }
		}

		/// <summary>Gets/sets the message that is displayed when
		/// NotifyOnApply/NotifyOnSave is true and Apply/Save is clicked</summary>
		[DefaultValue(frmDialogBase.DefaultSaveMsg)]
		[Description("Gets/sets the message that is displayed when " +
		   "NotifyOnApply/NotifyOnSave is true and Apply/Save is clicked")]
		public string SaveMsg
		{
			get { return _SaveMsg; }
			set { _SaveMsg = value; }
		}
		#endregion		// #region Properties

		#region Constructors

		/// <summary>Default (and only) constructor</summary>
		public frmDialogBase()
		{
			InitializeComponent();
			_ShowApplyButton = _WarnOnCancel = _NotifyOnSave = _NotifyOnApply =
				false;
			_CancelMsg = DefaultCancelMsg;
			_SaveMsg = DefaultSaveMsg;
			_ButtonClicked = DialogButton.Other;
		}
		#endregion		// #region Constructors

		#region Helper Methods

        protected void ActionOK(DialogResult dr)
        {
			try
			{
				_ButtonClicked = DialogButton.Save;
				if( CheckChanges() == false ) return;
				if( SaveChanges() == false ) return;

				DialogResult = DialogResult.OK;
				if( _NotifyOnSave == true &&
					string.IsNullOrEmpty(_SaveMsg) == false )
					Display.Show("Save", _SaveMsg);
			}
			catch( Exception ex )
			{
				Display.ShowError("DialogBase", ex);
			}
		}

		#endregion		// #region Helper Methods

		#region Virtual methods

		/// <summary>This method will be called automatically when the OK or
		/// apply buttons are clicked. If this method succeeds (returns true),
		/// then the <see cref="SaveChanges"/> method is called. The dialog
		/// cannot be closed by the OK button if this method returns false
		/// (the Cancel button must be clicked instead).</summary>
		/// <returns>True if successful, false if not</returns>
		/// <remarks>This method can be overriden by derived forms. It should
		/// return true if it is ok to save changes made to the dialog, false
		/// if the changes should not be saved</remarks>
		protected virtual bool CheckChanges() { return true; }
		/// <summary>This method will be called automatically when the OK or
		/// apply buttons are clicked, but only if <see cref="CheckChanges"/>
		/// returned true.</summary>
		/// <returns>True if changes were saved successfully, false if not</returns>
		/// <remarks>This method can be overriden by derived forms. It should
		/// return true if all changes were saved, or false if
		/// an error occurred.</remarks>
		protected virtual bool SaveChanges() { return true; }

		#endregion		// #region Virtual methods

		#region Event Handlers

		/// <summary>OK click event handler (closes the Dialog if
		/// <see cref="SaveChanges"/> returns true)</summary>
		/// <remarks>There is no event handler for the Cancel button</remarks>
		private void btnOK_Click(object sender, EventArgs e)
		{
            ActionOK(DialogResult.OK);
		}

		/// <summary>Apply click event handler (does not close the Dialog even
		/// if <see cref="SaveChanges"/> returns true)</summary>
		/// <remarks>There is no event handler for the Cancel button</remarks>
		private void btnApply_Click(object sender, EventArgs e)
		{
			try
			{
				_ButtonClicked = DialogButton.Apply;
				if( CheckChanges() == false ) return;
				SaveChanges();
				// Don't set DialogResult

				if( _NotifyOnApply == true &&
					string.IsNullOrEmpty(_SaveMsg) == false )
					Display.Show("Apply", _SaveMsg);
			}
			catch( Exception ex )
			{
				Display.ShowError("DialogBase", ex);
			}
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			try
			{
				_ButtonClicked = DialogButton.Cancel;
				if( _WarnOnCancel == false ||
					( _BusinessObject != null && _BusinessObject.IsDirty == false ) )
				{	// If WarnOnCancel is false or there were no changes made
					// on the form, don't display warning, just cancel
					DialogResult = DialogResult.Cancel;
					return;
				}

				if( Display.Ask("Cancel Confirmation", _CancelMsg) == true )
					DialogResult = DialogResult.Cancel;
				else
					DialogResult = DialogResult.None;
			}
			catch( Exception ex )
			{
				Display.ShowError("DialogBase", ex);
			}
		}
		#endregion		// #region Event Handlers
	}

	#region Dialog Mode Enum

	/// <summary>Represents the modes that a dialog window can be in</summary>
	public enum DialogMode
	{
		/// <summary>Add Mode</summary>
		Add,
		/// <summary>Edit Mode</summary>
		Edit,
        /// <summary>View Mode</summary>
        View
	};

	/// <summary>Represents the buttons on the dialog base form</summary>
	public enum DialogButton
	{
		/// <summary>Save/OK button</summary>
		Save,
		/// <summary>Apply button</summary>
		Apply,
		/// <summary>Cancel button</summary>
		Cancel,
		/// <summary>Some other button that may be on a derived form</summary>
		Other
	};
	#endregion		// #region Dialog Mode Enum
}