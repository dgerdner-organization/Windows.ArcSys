using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using CS2010.Common;

namespace CS2010.CommonWinCtrls
{
	/// <summary>DateRange composite control consisting of a group box with
	/// a checkbox and two ucDateText controls (used to allow a range of dates
	/// to be entered on a form)</summary>
	[ToolboxItem(true)]
	[DesignTimeVisible(true)]
	[ToolboxBitmap(typeof(GroupBox))]
	public partial class ucDateGroupBoxMMddyy : UserControl
	{
		#region Fields

		/// <summary>Data storage for the ValueRange property</summary>
		protected DateRange _ValueRange;

		#endregion		// #region Fields

		#region Properties

		/// <summary>Gets/Sets the text of the groupbox container</summary>
		[DefaultValue("")]
		[Description("Gets/Sets the text of the groupbox container")]
		public string GroupBoxText
		{
			get { return grpDates.Text; }
			set { grpDates.Text = value; }
		}

		/// <summary>Gets/Sets the text of the checkbox control</summary>
		[DefaultValue("Dates")]
		[Description("Gets/Sets the text of the checkbox control")]
		public string CheckBoxText
		{
			get { return chkDates.Text; }
			set { chkDates.Text = value; }
		}

		/// <summary>Gets/Sets the value of the date checkbox</summary>
		[DefaultValue(false)]
		[Description("Gets/Sets the value of the date checkbox")]
		public bool CheckBoxChecked
		{
			get { return chkDates.Checked; }
			set { chkDates.Checked = value; }
		}

		/// <summary>Gets/Sets the "From" date</summary>
		[DefaultValue(null), Browsable(false)]
		public DateTime? FromDate
		{
			get { return _ValueRange.From; }
			set
			{
				_ValueRange.From = value;
				dteFrom.Value = value;
			}
		}

		/// <summary>Gets/Sets the "To" date</summary>
		[DefaultValue(null), Browsable(false)]
		public DateTime? ToDate
		{
			get { return _ValueRange.To; }
			set
			{
				_ValueRange.To = value;
				dteTo.Value = value;
			}
		}

		/// <summary>Gets/Sets the from and to date range</summary>
		[DefaultValue(typeof(DateRange), ""),
		Description("Gets/Sets the from and to date range")]
		public DateRange ValueRange
		{
			get { return _ValueRange; }
			set
			{
				if( _ValueRange == value ) return;

				_ValueRange = value;

				dteFrom.Value = value.From;
				dteTo.Value = value.To;
			}
		}

		/// <summary>Returns the value range if checked, or the empty range if not checked</summary>
		[DefaultValue(null), Browsable(false)]
		public DateRange CheckedValueRange
		{
			get { return ( CheckBoxChecked ) ? ValueRange : DateRange.Empty; }
		}

		[Description("Occurs when the from or to dates change")]
		public event EventHandler ValueRangeChanged;

		#endregion		// #region Properties

		#region Constructors

		/// <summary>Default Constructor</summary>
		public ucDateGroupBoxMMddyy()
		{
			InitializeComponent();

			grpDates.Text = "";

			chkDates.Text = "Dates";
			chkDates.Checked = false;

			dteFrom.Value = null;
			dteTo.Value = null;

			_ValueRange = new DateRange();
		}
		#endregion		// #region Constructors

		#region Helper Methods

		/// <summary>Updates the enabled property of the date controls to reflect
		/// the value of chkDates Checked property (when the checkbox is checked
		/// the date controls are enabled, when the checkbox is not checked, the
		/// date controls are disabled</summary>
		private void UpdateEnabledProperty()
		{
			try
			{
				dteFrom.Enabled = chkDates.Checked;
				dteTo.Enabled = dteFrom.Enabled;
			}
			catch( Exception ex )
			{
				Display.ShowError("DateBox", ex);
			}
		}
		#endregion		// #region Helper Methods

		#region Public Methods

		/// <summary>Reset the checkbox and clear the dates</summary>
		public void Clear()
		{
			CheckBoxChecked = false;
			dteFrom.Value = null;
			dteTo.Value = null;
		}
		#endregion		// #region Public Methods

		#region Virtual Methods

		protected virtual void OnValueRangeChanged(EventArgs e)
		{
			if( ValueRangeChanged != null ) ValueRangeChanged(this, e);
		}
		#endregion		// #region Virtual Methods

		#region Event Handlers

		private void chkDates_CheckedChanged(object sender, EventArgs e)
		{
			UpdateEnabledProperty();
		}

		private void dteFrom_ValueChanged(object sender, EventArgs e)
		{
			_ValueRange.From = dteFrom.Value;
			OnValueRangeChanged(EventArgs.Empty);
		}

		private void dteTo_ValueChanged(object sender, EventArgs e)
		{
			_ValueRange.To = dteTo.Value;
			OnValueRangeChanged(EventArgs.Empty);
		}
		#endregion		// #region Event Handlers
	}
}