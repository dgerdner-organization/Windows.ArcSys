using System;
using System.Windows.Forms;
using System.ComponentModel;
using CS2010.CommonWinCtrls;

namespace CS2010.CommonWinCtrls
{
	public partial class frmDateTextBox : frmDialogBase
	{
		#region Fields

		protected DateTime SystemDate;
		protected bool _WarnIfFutureDate;

		#endregion		// #region Fields

		#region Properties

		public DateTime SelectedDate
		{
			get { return txtDate.Value.GetValueOrDefault(SystemDate); }
		}

		[DefaultValue(false)]
		[Description("Gets/sets whether to issue a waring if a date " +
			"in the future is selected")]
		public bool WarnIfFutureDate
		{
			get { return _WarnIfFutureDate; }
			set { _WarnIfFutureDate = value; }
		}

		public string EditFormat { get; set; }
		public string DisplayFormat { get; set; }

		#endregion		// #region Properties

		#region Constructors

		public frmDateTextBox()
		{
			InitializeComponent();
			_WarnIfFutureDate = false;
		}
		#endregion		// #region Constructors

		#region Public Methods

		public bool GetDate(DateTime? initDate, DateTime sysDate)
		{
			try
			{
				SystemDate = sysDate;
				if( initDate != null ) txtDate.Value = initDate.Value;
				return ShowDialog() == DialogResult.OK;
			}
			catch( Exception ex )
			{
				return Display.ShowError("Date Error", ex);
			}
		}

		public bool GetDate(DateTime? initDate, DateTime sysDate, DateTime maxDate)
		{
			try
			{
				SystemDate = sysDate;
				txtDate.MaxDate = maxDate;
				if( initDate != null ) txtDate.Value = initDate.Value;

				if (!string.IsNullOrWhiteSpace(EditFormat))
					txtDate.EditFormat = EditFormat;
				if (!string.IsNullOrWhiteSpace(DisplayFormat))
					txtDate.OverrideDisplayFormat = DisplayFormat;

				return ShowDialog() == DialogResult.OK;
			}
			catch( Exception ex )
			{
				return Display.ShowError("Date Error", ex);
			}
		}
		#endregion		// #region Public Methods

		#region Overrides

		protected override bool CheckChanges()
		{
			try
			{
				if( txtDate.Value == null )
					return Display.ShowError("Date Error", "Must enter a date");

				if( _WarnIfFutureDate == true )
				{
					if( SelectedDate.Date > SystemDate.Date )
						return Display.Ask("Date Confirmation",
							"You have entered a date greater than today, Continue?");
				}

				return true;
			}
			catch( Exception ex )
			{
				return Display.ShowError("Date Error", ex);
			}
		}
		#endregion		// #region Overrides
	}
}