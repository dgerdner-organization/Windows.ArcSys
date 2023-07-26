using System;
using System.Windows.Forms;
using System.ComponentModel;
using CS2010.Common;

namespace CS2010.CommonWinCtrls
{
	public partial class frmAddressPlus : frmDialogBase
	{
		#region Fields

		/// <summary>Object that is bound to the controls on the form and
		/// holds the address being entered</summary>
		protected IAddress _Address;

		#endregion		// #region Fields

		#region Properties

		/// <summary>Gets/Sets whether to show the code field or not</summary>
		[Browsable(true), DefaultValue(false),
		Description("Gets/Sets whether to show the code field or not")]
		public bool ShowCode
		{
			get { return txtCode.Visible; }
			set { txtCode.Visible = value; }
		}

		/// <summary>Gets/Sets whether to show the addressee field or not</summary>
		[Browsable(true), DefaultValue(false),
		Description("Gets/Sets whether to show the addressee field or not")]
		public bool ShowAddressee
		{
			get { return txtAddressee.Visible; }
			set { txtAddressee.Visible = value; }
		}

		/// <summary>Gets/Sets the addressee (which is actually the value of
		/// the addressee text box)</summary>
		[Browsable(false), DefaultValue("")]
		public string Addressee
		{
			get { return txtAddressee.Text.Trim(); }
			set
			{
				txtAddressee.Text = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
			}
		}

		/// <summary>Gets/Sets the addressee label</summary>
		[Browsable(false), DefaultValue("Addressee")]
		public string AddresseeLabel
		{
			get { return txtAddressee.LabelText; }
			set { txtAddressee.LabelText = value; }
		}

		/// <summary>Gets/Sets a code value (which is actually the value of
		/// the code text box)</summary>
		[Browsable(false), DefaultValue("")]
		public string Code
		{
			get { return txtCode.Text.Trim(); }
			set
			{
				txtCode.Text = ( string.IsNullOrEmpty(value) == false )
					? value.Trim() : null;
			}
		}

		/// <summary>Gets/Sets the code field label</summary>
		[Browsable(false), DefaultValue("Code")]
		public string CodeLabel
		{
			get { return txtCode.LabelText; }
			set { txtCode.LabelText = value; }
		}
		#endregion		// #region Properties

		#region Constructors

		public frmAddressPlus()
		{
			InitializeComponent();
		}
		#endregion		// #region Constructors

		#region Overrides

		protected override bool CheckChanges()
		{
			try
			{
				if( grpAddress.CheckChanges() == false )
				{
					if( grpAddress.Error.Length > 0 )
						Display.ShowError("Error", grpAddress.Error);
					return false;
				}

				return true;
			}
			catch( Exception ex )
			{
				return Display.ShowError("Address Error", ex);
			}
		}
		#endregion		// #region Overrides

		#region Public Methods

		/// <summary>Method used to create a new address</summary>
		/// <returns>A new Address object if the OK button was clicked
		/// and the form passed validation (meaning both
		/// <see cref="CheckChanges"/> and <see cref="SaveChanges"/>
		/// returned true), null if Cancel was clicked</returns>
		public IAddress Add()
		{
			try
			{
				_Address = new Address();
				CurrentMode = DialogMode.Add;
				grpAddress.theAddress = _Address;
				return ( ShowDialog() == DialogResult.OK ) ? _Address : null;
			}
			catch( Exception ex )
			{
				Display.ShowError("Address Error", ex);
				return null;
			}
		}

		/// <summary>Method used to edit an address</summary>
		/// <returns>True if the OK button was clicked and the form passed
		/// validation (<see cref="CheckChanges"/> and <see cref="SaveChanges"/>
		/// returned true), false if Cancel was clicked</returns>
		/// <remarks>The changes are saved to the passed object, but no changes
		/// are made to any database tables.</remarks>
		public bool Edit(IAddress addr)
		{
			try
			{
				_Address = new Address(addr);
				CurrentMode = DialogMode.Edit;
				grpAddress.theAddress = _Address;
				if( ShowDialog() != DialogResult.OK ) return false;

				Address.Copy(_Address, addr); 
				return true;
			}
			catch( Exception ex )
			{
				return Display.ShowError("Address Error", ex);
			}
		}
		#endregion		// #region Public Methods
	}
}