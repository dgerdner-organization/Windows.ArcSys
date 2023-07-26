using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using CS2010.Common;
using CS2010.CommonWinCtrls;
using ASL.ITrack.Business;
using Janus.Windows.GridEX;
using Janus.Windows.GridEX.EditControls;

namespace ASL.ITrack.WinCtrls
{
	/// <summary>ITrack version of ucMultiColumnCombo for available release dates</summary>
	[ToolboxBitmap(typeof(MultiColumnCombo))]
	public partial class ucReleaseCombo : ucMultiColumnCombo
	{
		#region Fields

		private DateTime? _StartingPoint;
		private bool IsLoadingDataSource;

		private ComboItem[] ReleaseDates;

		#endregion		// #region Fields

		#region Properties

		[Browsable(false)]
		public DateTime? StartingPoint
		{
			get { return _StartingPoint; }
			set
			{
				if( _StartingPoint == value ) return;

				_StartingPoint = value;
			}
		}

		/// <summary>Gets the selected release date</summary>
		[Browsable(false)]
		public DateTime? SelectedDate
		{
			get
			{
				string due = Value as string;
				return ClsConvert.ToDateTimeNullable(due);
			}
		}

		/// <summary>Gets the selected item as a ComboItem</summary>
		[Browsable(false)]
		public ComboItem SelectedRow
		{
			get
			{
				return SelectedItem as ComboItem;
			}
		}

		[DefaultValue(CharacterCasing.Normal)]
		public new CharacterCasing CharacterCasing
		{
			get { return base.CharacterCasing; }
			set
			{
				base.CharacterCasing = value;
			}
		}
		#endregion		// #region Properties

		#region Constructors

		/// <summary>Default Constructor</summary>
		public ucReleaseCombo()
		{
			InitializeComponent();

			_StartingPoint = null;

			IsLoadingDataSource = false;

			ReleaseDates = new ComboItem[12];	// 12 months of release dates

			SetTable();

			CreateStructure();

			base.CharacterCasing = CharacterCasing.Normal;
		}
		#endregion		// #region Constructors

		#region Public Methods

		public void Reset()
		{
			SetTable();
		}

		public bool ValidateReleaseDate(DateTime? reqDt)
		{
			if( reqDt == null ) return true;

			DateTime dtRequest = reqDt.Value.Date;
			for( int i = 0; i < ReleaseDates.Length; i++ )
			{
				ComboItem ci = ReleaseDates[i];
				DateTime? dtVal = ClsConvert.ToDateTimeNullable(ci.Description);
				if( dtVal == null ) continue;

				DateTime dtRelease = dtVal.Value.Date;
				if( dtRequest <= dtRelease ) return true;
			}

			return false;
		}

		public bool SetReleaseDate(DateTime? reqDt)
		{
			if( reqDt == null )
			{
				Value = null;
				Text = null;
				return true;
			}

			DateTime dtRequest = reqDt.Value.Date;
			for( int i = 0; i < ReleaseDates.Length; i++ )
			{
				ComboItem ci = ReleaseDates[i];
				DateTime? dtVal = ClsConvert.ToDateTimeNullable(ci.Description);
				if( dtVal == null ) continue;

				DateTime dtRelease = dtVal.Value.Date;
				if( dtRequest <= dtRelease )
				{
					Value = ci.Description;
					return true;
				}
			}

			return false;
		}
		#endregion		// #region Public Methods

		#region Helper Methods

		private void CreateStructure()
		{
			GridEXColumn c = DropDownList.Columns.Add("Code");
			c.DataMember = "Code";
			c.Caption = "Release Month";
			c.Width = 150;

			c = DropDownList.Columns.Add("Description");
			c.DataMember = "Description";
			c.Caption = "Release Date";
			c.Width = 300;

			DropDownList.VisibleRows = 20;
		}

		private void SetTable()
		{
			try
			{
				for( int i = 0; i < 12; i++ ) ReleaseDates[i] = null;

				DateTime dt = DateTime.Now;
				for( int i = 0; i < 12; i++ )
				{
					int nextMo = dt.Month + 1;
					int year = dt.Year;
					if( nextMo > 12 )
					{
						year++;
						nextMo = 1;
					}
					dt = new DateTime(year, nextMo, 1);

					DateTime dueDt = dt;
					if( dueDt.DayOfWeek != DayOfWeek.Monday )
					{
						int valMonday = (int)DayOfWeek.Monday;
						int valDaySel = (int)dueDt.DayOfWeek;
						DateTime monday = dueDt.AddDays(valMonday - valDaySel);
						if( monday < dueDt ) monday = monday.AddDays(7);
						dueDt = monday;
					}

					ReleaseDates[i] = new ComboItem(dueDt.ToString("MMMM yyyy"), dueDt.ToString("MM/dd/yyyy"));
				}

				try
				{
					IsLoadingDataSource = true;
					base.DataSource = null;
					base.DataSource = ReleaseDates;
				}
				finally
				{
					IsLoadingDataSource = false;
				}
			}
			catch( Exception ex )
			{
				Display.ShowError("ITrack", ex);
			}
		}
		#endregion		// #region Helper Methods

		#region Overrides

		protected override void SetDataSource(object aValue)
		{
			// JR: We keep track of the data source internally,
			// so do not allow it to be overwritten
			if( IsLoadingDataSource ) base.SetDataSource(aValue);
		}

		protected override void OnValidating(CancelEventArgs e)
		{
			try
			{
				if( NotInList == true )
				{
					e.Cancel = true;
					Display.ShowError("ITrack", "Specified item is not in the list");
				}
				else if( DroppedDown == true )
					e.Cancel = true;
			}
			catch( Exception ex )
			{
				Display.ShowError("ITrack", ex);
			}
			base.OnValidating(e);
		}
		#endregion		// #region Overrides
	}
}