using System;
using System.Windows.Forms;
using System.ComponentModel;
using CS2010.CommonWinCtrls;

namespace CS2010.CommonWinCtrls
{
	public partial class frmDateSelector : frmDialogBase
	{
		#region Fields

		protected DateTime SystemDate;
		protected bool _WarnIfFutureDate;

		#endregion		// #region Fields

		#region Properties

		public DateTime SelectedDate
		{
			get { return calDate.SelectionStart; }
		}

		[DefaultValue(false)]
		[Description("Gets/sets whether to issue a waring if a date " +
			"in the future is selected")]
		public bool WarnIfFutureDate
		{
			get { return _WarnIfFutureDate; }
			set { _WarnIfFutureDate = value; }
		}
		#endregion		// #region Properties

		#region Constructors

		public frmDateSelector()
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
				if( initDate != null ) calDate.SetDate(initDate.Value);
				return ShowDialog() == DialogResult.OK;
			}
			catch( Exception ex )
			{
				return Display.ShowError("Date Selector Error", ex);
			}
		}

		public bool GetDate(DateTime? initDate, DateTime sysDate, DateTime maxDate)
		{
			try
			{
				SystemDate = sysDate;
				calDate.MinDate = DateTime.MinValue;
				calDate.MaxDate = maxDate;
				if( initDate != null ) calDate.SetDate(initDate.Value);
				return ShowDialog() == DialogResult.OK;
			}
			catch( Exception ex )
			{
				return Display.ShowError("Date Selector Error", ex);
			}
		}
		#endregion		// #region Public Methods

		#region Overrides

		protected override bool CheckChanges()
		{
			try
			{
				if( _WarnIfFutureDate == false ) return true;

				if( SelectedDate.Date > SystemDate.Date )
					return Display.Ask("Date Confirmation",
						"You have entered a date greater than today, Continue?");

				return true;
			}
			catch( Exception ex )
			{
				return Display.ShowError("Date Selector Error", ex);
			}
		}
		#endregion		// #region Overrides
	}
}