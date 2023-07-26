using System;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using CS2010.Common;
using System.Collections.Generic;

namespace CS2010.CommonWinCtrls
{
	public partial class ucContactBox : UserControl
	{
		#region Required Fields

		protected ClsBaseTable _theContact;
		/// <summary>Object that will be bound to the controls on the form and
		/// holds the contact info being entered. This propety must be set for
		/// data binding to work correctly.</summary>
		[Browsable(false), DefaultValue(null)]
		public ClsBaseTable theContact
		{
			get { return _theContact; }
			set
			{
				_theContact = value;
				BindContact();
			}
		}

		protected string _Phone1Binding;
		/// <summary>Name of the property in the business object that will be bound to the
		/// 1st phone textbox field</summary>
		[Browsable(true), DefaultValue(null),
		Description("Name of the property in the business object that will be bound to " +
			"the 1st phone textbox field")]
		public string Phone1Binding
		{
			get { return _Phone1Binding; }
			set
			{
				_Phone1Binding = value;
				BindField(txtPhone1, _Phone1Binding);
			}
		}

		protected string _Phone1ExtBinding;
		/// <summary>Name of the property in the business object that will be bound to the
		/// 1st extension textbox field</summary>
		[Browsable(true), DefaultValue(null),
		Description("Name of the property in the business object that will be bound to " +
			"the 1st extension textbox field")]
		public string Phone1ExtBinding
		{
			get { return _Phone1ExtBinding; }
			set
			{
				_Phone1ExtBinding = value;
				BindField(txtPhone1Ext, _Phone1ExtBinding);
			}
		}

		protected string _Phone2Binding;
		/// <summary>Name of the property in the business object that will be bound to the
		/// 2nd phone textbox field</summary>
		[Browsable(true), DefaultValue(null),
		Description("Name of the property in the business object that will be bound to " +
			"the 2nd phone textbox field")]
		public string Phone2Binding
		{
			get { return _Phone2Binding; }
			set
			{
				_Phone2Binding = value;
				BindField(txtPhone2, _Phone2Binding);
			}
		}

		protected string _Phone2ExtBinding;
		/// <summary>Name of the property in the business object that will be bound to the
		/// 2nd extension textbox field</summary>
		[Browsable(true), DefaultValue(null),
		Description("Name of the property in the business object that will be bound to " +
			"the 2nd extension textbox field")]
		public string Phone2ExtBinding
		{
			get { return _Phone2ExtBinding; }
			set
			{
				_Phone2ExtBinding = value;
				BindField(txtPhone2Ext, _Phone2ExtBinding);
			}
		}

		protected string _Phone3Binding;
		/// <summary>Name of the property in the business object that will be bound to the
		/// 3rd phone textbox field</summary>
		[Browsable(true), DefaultValue(null),
		Description("Name of the property in the business object that will be bound to " +
			"the 3rd phone textbox field")]
		public string Phone3Binding
		{
			get { return _Phone3Binding; }
			set
			{
				_Phone3Binding = value;
				BindField(txtPhone3, _Phone3Binding);
			}
		}

		protected string _Phone3ExtBinding;
		/// <summary>Name of the property in the business object that will be bound to the
		/// 3rd extension textbox field</summary>
		[Browsable(true), DefaultValue(null),
		Description("Name of the property in the business object that will be bound to " +
			"the 3rd extension textbox field")]
		public string Phone3ExtBinding
		{
			get { return _Phone3ExtBinding; }
			set
			{
				_Phone3ExtBinding = value;
				BindField(txtPhone3Ext, _Phone3ExtBinding);
			}
		}

		protected string _FaxBinding;
		/// <summary>Name of the property in the business object that will be bound to the
		/// fax textbox field</summary>
		[Browsable(true), DefaultValue(null),
		Description("Name of the property in the business object that will be bound to " +
			"the fax textbox field")]
		public string FaxBinding
		{
			get { return _FaxBinding; }
			set
			{
				_FaxBinding = value;
				BindField(txtFax, _FaxBinding);
			}
		}

		protected string _EmailBinding;
		/// <summary>Name of the property in the business object that will be bound to the
		/// email textbox field</summary>
		[Browsable(true), DefaultValue(null),
		Description("Name of the property in the business object that will be bound to " +
			"the email textbox field")]
		public string EmailBinding
		{
			get { return _EmailBinding; }
			set
			{
				_EmailBinding = value;
				BindField(txtEmail, _EmailBinding);
			}
		}
		#endregion		// #region Required Fields

		#region Optional TextBox Label Fields

		/// <summary>Gets/Sets the label for the first phone number textbox</summary>
		[Browsable(true), DefaultValue("Phone 1"),
		Description("Gets/Sets the label for the first phone number textbox")]
		public string Phone1Label
		{
			get { return txtPhone1.LabelText; }
			set { txtPhone1.LabelText = value; }
		}

		/// <summary>Gets/Sets the label for the second phone number textbox</summary>
		[Browsable(true), DefaultValue("Phone 2"),
		Description("Gets/Sets the label for the second phone number textbox")]
		public string Phone2Label
		{
			get { return txtPhone2.LabelText; }
			set { txtPhone2.LabelText = value; }
		}

		/// <summary>Gets/Sets the label for the third phone number textbox</summary>
		[Browsable(true), DefaultValue("Phone 3"),
		Description("Gets/Sets the label for the third phone number textbox")]
		public string Phone3Label
		{
			get { return txtPhone3.LabelText; }
			set { txtPhone3.LabelText = value; }
		}

		/// <summary>Gets/Sets the label for the second fax number textbox</summary>
		[Browsable(true), DefaultValue("Fax"),
		Description("Gets/Sets the label for the fax number textbox")]
		public string FaxLabel
		{
			get { return txtFax.LabelText; }
			set { txtFax.LabelText = value; }
		}

		/// <summary>Gets/Sets the label for the email address textbox</summary>
		[Browsable(true), DefaultValue("Email"),
		Description("Gets/Sets the label for the email address textbox")]
		public string EmailLabel
		{
			get { return txtEmail.LabelText; }
			set { txtEmail.LabelText = value; }
		}
		#endregion		// #region Optional TextBox Label Fields

		#region Optional Control Layout Fields

		/// <summary>Gets/Sets whether to show the extension with the 1st phone #</summary>
		[Browsable(true), DefaultValue(true),
		Description("Gets/Sets whether to show the extension textbox for the 1st phone #")]
		public bool ShowExt1
		{
			get { return txtPhone1Ext.Visible; }
			set
			{
				txtPhone1Ext.Visible = value;
				AdjustLayout();
			}
		}

		/// <summary>Gets/Sets whether to show the extension with the 2nd phone #</summary>
		[Browsable(true), DefaultValue(true),
		Description("Gets/Sets whether to show the extension textbox for the 2nd phone #")]
		public bool ShowExt2
		{
			get { return txtPhone2Ext.Visible; }
			set
			{
				txtPhone2Ext.Visible = value;
				AdjustLayout();
			}
		}

		/// <summary>Gets/Sets whether to show the extension with the 3rd phone #</summary>
		[Browsable(true), DefaultValue(true),
		Description("Gets/Sets whether to show the extension textbox for the 3rd phone #")]
		public bool ShowExt3
		{
			get { return txtPhone3Ext.Visible; }
			set
			{
				txtPhone3Ext.Visible = value;
				AdjustLayout();
			}
		}

		/// <summary>Gets/Sets whether to show the 1st phone # field. Note, if the phone
		/// field is hidden, the associated extension field is also hidden.</summary>
		[Browsable(true), DefaultValue(true),
		Description("Gets/Sets whether to show the 1st phone # field. Note, if the phone" +
			"field is hidden, the associated extension field is also hidden.")]
		public bool ShowPhone1
		{
			get { return txtPhone1.Visible; }
			set
			{
				txtPhone1.Visible = value;
				if( txtPhone1.Visible == false ) txtPhone1Ext.Visible = false;
				AdjustLayout();
			}
		}

		/// <summary>Gets/Sets whether to show the 2nd phone # field. Note, if the phone
		/// field is hidden, the associated extension field is also hidden.</summary>
		[Browsable(true), DefaultValue(true),
		Description("Gets/Sets whether to show the 2nd phone # field. Note, if the phone" +
			"field is hidden, the associated extension field is also hidden.")]
		public bool ShowPhone2
		{
			get { return txtPhone2.Visible; }
			set
			{
				txtPhone2.Visible = value;
				if( txtPhone2.Visible == false ) txtPhone2Ext.Visible = false;
				AdjustLayout();
			}
		}

		/// <summary>Gets/Sets whether to show the 3rd phone # field. Note, if the phone
		/// field is hidden, the associated extension field is also hidden.</summary>
		[Browsable(true), DefaultValue(true),
		Description("Gets/Sets whether to show the 3rd phone # field. Note, if the phone" +
			"field is hidden, the associated extension field is also hidden.")]
		public bool ShowPhone3
		{
			get { return txtPhone3.Visible; }
			set
			{
				txtPhone3.Visible = value;
				if( txtPhone3.Visible == false ) txtPhone3Ext.Visible = false;
				AdjustLayout();
			}
		}

		/// <summary>Gets/Sets whether to show the fax # field</summary>
		[Browsable(true), DefaultValue(true),
		Description("Gets/Sets whether to show the fax # field")]
		public bool ShowFax
		{
			get { return txtFax.Visible; }
			set
			{
				txtFax.Visible = value;
				AdjustLayout();
			}
		}

		/// <summary>Gets/Sets whether to show the email address field</summary>
		[Browsable(true), DefaultValue(true),
		Description("Gets/Sets whether to show the email address field")]
		public bool ShowEmail
		{
			get { return txtEmail.Visible; }
			set
			{
				txtEmail.Visible = value;
				AdjustLayout();
			}
		}
		#endregion		// #region Optional Control Layout Fields

		#region Error Handling

		protected StringBuilder ErrorBuilder;

		public bool HasError
		{
			get { return ErrorBuilder.Length > 0; }
		}

		public string Error
		{
			get { return ErrorBuilder.ToString(); }
		}
		#endregion		// #region Error Handling

		#region Constructors

		public ucContactBox()
		{
			InitializeComponent();

			ErrorBuilder = new StringBuilder();

			_theContact = null;
			_Phone1Binding = _Phone2Binding = _Phone3Binding = _Phone1ExtBinding =
				_Phone2ExtBinding = _Phone3ExtBinding = _FaxBinding = _EmailBinding = null;

			txtPhone1.LabelText = "Phone 1";
			txtPhone2.LabelText = "Phone 2";
			txtPhone3.LabelText = "Phone 3";
			txtFax.LabelText = "Fax";
			txtEmail.LabelText = "Email";

			txtPhone1.Visible = txtPhone1Ext.Visible = txtPhone2.Visible =
				txtPhone2Ext.Visible = txtPhone3.Visible = txtPhone3Ext.Visible =
				txtFax.Visible = txtEmail.Visible = true;

			AdjustLayout();
		}
		#endregion		// #region Constructors

		#region Public Validation

		/// <summary>Performs contact data validation</summary>
		/// <returns>True if successful, false if not</returns>
		/// <remarks>No fields are required, but the fields that have data will be validated</remarks>
		public bool CheckChanges()
		{
			try
			{
				ErrorBuilder.Length = 0;
				if( Contact.ValidatePhone(txtPhone1.Text, txtPhone1Ext.Text) == false )
					ErrorBuilder.AppendLine(Contact.Error);
				if( Contact.ValidatePhone(txtPhone2.Text, txtPhone2Ext.Text) == false )
					ErrorBuilder.AppendLine(Contact.Error);
				if( Contact.ValidatePhone(txtPhone3.Text, txtPhone3Ext.Text) == false )
					ErrorBuilder.AppendLine(Contact.Error);
				if( Contact.ValidatePhone(txtFax.Text, null) == false )
					ErrorBuilder.AppendLine(Contact.Error);
				if( Contact.ValidateEmail(txtEmail.Text) == false )
					ErrorBuilder.AppendLine(Contact.Error);

				return true;
			}
			catch( Exception ex )
			{
				return Display.ShowError("Contact Info Error", ex);
			}
		}
		#endregion		// #region Public Validation

		#region Helper Methods

		protected void BindField(Control c, string bindCol)
		{
			if( ClsEnvironment.IsDesignMode == true ) return;

			if( _theContact != null && string.IsNullOrEmpty(bindCol) == false )
				BindHelper.Bind(c, theContact, bindCol);
			else
				c.DataBindings.Clear();
		}

		protected void BindContact()
		{
			if( ClsEnvironment.IsDesignMode == true ) return;

			BindField(txtPhone1,  Phone1Binding);
			BindField(txtPhone1Ext, Phone1ExtBinding);
			BindField(txtPhone2, Phone2Binding);
			BindField(txtPhone2Ext, Phone2ExtBinding);
			BindField(txtPhone3, Phone3Binding);
			BindField(txtPhone3Ext, Phone3ExtBinding);
			BindField(txtFax, FaxBinding);
			BindField(txtEmail, EmailBinding);
		}

		private void AdjustLayout()
		{
			try
			{
				int minHgt =
					( txtPhone1.Visible ? txtPhone1.Height : 0 ) +
					( txtPhone2.Visible ? txtPhone2.Height : 0 ) +
					( txtPhone3.Visible ? txtPhone3.Height : 0 ) +
					( txtFax.Visible ? txtFax.Height : 0 ) +
					( txtEmail.Visible ? txtEmail.Height : 0 );
				int hgt = ( Height > minHgt ) ? Height : minHgt;

				int items = 0;
				if( txtPhone1.Visible ) items++;
				if( txtPhone2.Visible ) items++;
				if( txtPhone3.Visible ) items++;
				if( txtFax.Visible ) items++;
				if( txtEmail.Visible ) items++;

				int pos = 0;
				int offset = ( hgt - minHgt ) / ( items > 1 ? items - 1 : 1 );
				if( txtPhone1.Visible )
				{
					txtPhone1.Top = pos;
					txtPhone1Ext.Top = txtPhone1.Top;
					pos = txtPhone1.Top + txtPhone1.Height + offset;
				}
				if( txtPhone2.Visible )
				{
					txtPhone2.Top = pos;
					txtPhone2Ext.Top = txtPhone2.Top;
					pos = txtPhone2.Top + txtPhone2.Height + offset;
				}
				if( txtPhone3.Visible )
				{
					txtPhone3.Top = pos;
					txtPhone3Ext.Top = txtPhone3.Top;
					pos = txtPhone3.Top + txtPhone3.Height + offset;
				}
				if( txtFax.Visible )
				{
					txtFax.Top = pos;
					pos = txtFax.Top + txtFax.Height + offset;
				}
				if( txtEmail.Visible )
				{
					txtEmail.Top = pos;
					pos = txtEmail.Top + txtEmail.Height + offset;
				}

				int defWidth = 206;
				txtPhone1.Width = ( txtPhone1Ext.Visible ) ? defWidth : txtEmail.Width;
				txtPhone1Ext.Left = txtPhone1.Left + txtPhone1.Width + 2;
				txtPhone2.Width = ( txtPhone2Ext.Visible ) ? defWidth : txtEmail.Width;
				txtPhone2Ext.Left = txtPhone2.Left + txtPhone2.Width + 2;
				txtPhone3.Width = ( txtPhone3Ext.Visible ) ? defWidth : txtEmail.Width;
				txtPhone3Ext.Left = txtPhone3.Left + txtPhone3.Width + 2;
			}
			catch( Exception ex )
			{
				Display.ShowError("Address Error", ex);
			}
		}
		#endregion		// #region Helper Methods

		#region Overrides

		protected override void OnResize(EventArgs e)
		{
			AdjustLayout();
		}
		#endregion		// #region Overrides
	}
}