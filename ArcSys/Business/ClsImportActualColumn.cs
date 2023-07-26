using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CS2010.Common;

namespace CS2010.ArcSys.Business
{
	public class ClsImportActualColumn
	{
		public ClsImportActualColumn(string sCol)
		{
			_sColumn = sCol.ToUpper();
		}

		#region Fields and Properties
		private string _sColumn;
		public string sColumn
		{
			get { return _sColumn; }
		}

		public struct HeaderCodes
		{
			public const string Booking = "BOOKING";
			public const string TCN = "TCN";
			public const string Voyage = "VOYAGE";
			public const string Truck = "TRUCK";
			public const string LHaul = "LHAUL";
			public const string LHaulType = "LHAULTYPE";
			public const string Weight = "WEIGHT";
			public const string Length = "LENGTH";
			public const string Height = "HEIGHT";
			public const string Width = "WIDTH";
			public const string EITVTag = "EITV TAG";
			public const string PCFN = "PCFN";
			public const string Description = "DESCRIPTION";
			public const string Origin = "ORIGIN";
			public const string Destination = "DESTINATION";
			public const string Pieces = "PIECES";
			public const string FOBDate = "FOB DATE";
			public const string PODDate = "POD DATE";
			public const string DetentionDays = "DETENTION DAYS";

		}

		public bool IsValidColumn
		{
			get
			{
				if (IsHeaderColumn || IsChargeColumn)
					return true;
				return false;
			}
		}

		public bool IsDateColumn
		{
			get
			{
				switch (sColumn)
				{
					case HeaderCodes.FOBDate:
					case HeaderCodes.PODDate:
						return true;
				}
				return false;
			}
		}
		public bool IsHeaderColumn
		{
			get
			{
				// Checks to see if this is a valid Header Column
				switch (sColumn)
				{
					case HeaderCodes.Booking:
					case HeaderCodes.TCN:
					case HeaderCodes.Truck:
					case HeaderCodes.LHaul:
					case HeaderCodes.LHaulType:
					case HeaderCodes.Weight:
					case HeaderCodes.Length:
					case HeaderCodes.Height:
					case HeaderCodes.Width:
					case HeaderCodes.EITVTag:
					case HeaderCodes.PCFN:
					case HeaderCodes.Description:
					case HeaderCodes.Origin:
					case HeaderCodes.Destination:
					case HeaderCodes.Pieces:
					case HeaderCodes.Voyage:
					case HeaderCodes.FOBDate:
					case HeaderCodes.PODDate:
					case HeaderCodes.DetentionDays:
						return true;
				}
				return false;
			}
		}

		public bool IsChargeColumn
		{
			get
			{
				// Checks to see if it is a valid Charge Column
				return IsValidChargeCd(sColumn);
			}
		}

		public bool IsValidChargeCd(string s)
		{
			if (s == HeaderCodes.LHaul)
				return true;
			ClsChargeType ct = ClsChargeType.GetUsingKey(s);
			if (ct == null)
				return false;
			return true;
		}

		public DateTime DateValue(string sValue)
		{
			try
			{
				DateTime dt = ClsConvert.ToDateTime(sValue);
					return dt;
			}
			catch 
			{
				return DateTime.MinValue;
			}
		}

		public decimal? NumericValue(string sValue)
		{
			try
			{
				decimal? d = ClsConvert.ToDecimalNullable(sValue);
				return d;
			}
			catch
			{
				return null;
			}
		}
		#endregion
	}
	public class ClsImportAP
	{
		public struct importAPRow
		{
			public string TCN;
			public string BookingNo;
			public string TruckNo;
			public string EITVTag;
			public string Origin;
			public string Destination;
			public string LhaulType;
			public decimal Length;
			public decimal Width;
			public decimal Height;
			public decimal Weight;
			public DateTime FOBDate;

		}
		public static importAPRow PopulateAPRow(DataRow dr, importAPRow apRow)
		{
			apRow.EITVTag = dr[ClsImportActualColumn.HeaderCodes.EITVTag].ToString();
			apRow.BookingNo = dr[ClsImportActualColumn.HeaderCodes.Booking].ToString();
			apRow.TCN =  dr[ClsImportActualColumn.HeaderCodes.TCN].ToString();
			apRow.LhaulType = dr[ClsImportActualColumn.HeaderCodes.LHaulType].ToString();
			apRow.TruckNo = dr[ClsImportActualColumn.HeaderCodes.Truck].ToString();
			apRow.Origin = dr[ClsImportActualColumn.HeaderCodes.Origin].ToString();
			apRow.Destination = dr[ClsImportActualColumn.HeaderCodes.Destination].ToString();

			string sDec = dr[ClsImportActualColumn.HeaderCodes.Length].ToString();
			apRow.Length = ClsConvert.ToDecimal(sDec);
			sDec = dr[ClsImportActualColumn.HeaderCodes.Width].ToString();
			apRow.Width = ClsConvert.ToDecimal(sDec);
			sDec = dr[ClsImportActualColumn.HeaderCodes.Height].ToString();
			apRow.Height = ClsConvert.ToDecimal(sDec);

			string sDate = dr[ClsImportActualColumn.HeaderCodes.FOBDate].ToString();
			apRow.FOBDate = ClsConvert.ToDateTime(sDate);

			return apRow;
		}
	}
}
