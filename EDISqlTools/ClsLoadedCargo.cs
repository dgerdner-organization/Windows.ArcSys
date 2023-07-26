using System;
using System.Collections.Generic;
using System.Text;
using CS2010.Common;

namespace ASL.ARC.EDISQLTools
{
	public class ClsLoadedCargo : ClsBaseTable
	{
		public bool isFirstLegTransshipment
		{
			get
			{
				// If this booking has a Final Booking Number
				// associated with it, then this is the first
				// leg of a transhipment.
				return !string.IsNullOrEmpty(FinalBookingNo);
			}
		}
		public bool isLastLegTransshipment
		{
			get
			{
				if( TariffCd == "RMEMO" )
					return true;
				return false;
			}
		}
		private string _BookingNo;
		public string BookingNo
		{
			get { return _BookingNo; }
			set { _BookingNo = value; }
		}	
		private string _BookingNoSub;
		public string BookingNoSub
		{
			get { return _BookingNoSub; }
			set { _BookingNoSub = value; }
		}
		private string _transInfo;
		public string transInfo
		{
			get { return _transInfo; }
			set { _transInfo = value; }
		}
		private string _FinalBookingNo;
		public string FinalBookingNo
		{
			get { return _FinalBookingNo; }
			set { _FinalBookingNo = value; }
		}
		private string _FirstBookingNo;
		public string FirstBookingNo
		{
			get { return _FirstBookingNo; }
			set { _FirstBookingNo = value; }
		}
		private string _TariffCd;
		public string TariffCd
		{
			get { return _TariffCd; }
			set { _TariffCd = value; }
		}
		private string _VoyageNo;
		public string VoyageNo
		{
			get { return _VoyageNo; }
			set { _VoyageNo = value; }
		}
		private string _VesselCd;
		public string VesselCd
		{
			get { return _VesselCd; }
			set { _VesselCd = value; }
		}
		public string VoyageVessel
		{
			get { return VoyageNo + "-" + VesselCd; }
		}
		private string _TCN;
		public string TCN
		{
			get { return _TCN; }
			set { _TCN = value; }
		}

		private DateTime _ReceivedDate;
		public DateTime ReceivedDate 
		{
			get { return _ReceivedDate; }
			set { _ReceivedDate = value; }
		}

		private DateTime? _Rdd;
		public DateTime? Rdd
		{
			get { return _Rdd; }
			set { _Rdd = value; }
		}
		// Activity Counts
		public long _eeCount;
		public long ee_Count
		{
			get { return _eeCount; }
			set { _eeCount = value; }
		}
		private long _PickupCount;
		public long W_PickupCount
		{
			get { return _PickupCount; }
			set { _PickupCount = value; }
		}

		private long _InGateCount;
		public long I_InGateCount
		{
			get { return _InGateCount; }
			set { _InGateCount = value; }
		}
		private long _LoadCount;
		public long AE_LoadCount
		{
			get { return _LoadCount; }
			set { _LoadCount = value; }
		}
		private long _DepartCount;
		public long VD_DepartCount
		{
			get { return _DepartCount; }
			set { _DepartCount = value; }
		}
		private long _ArriveCount;
		public long VA_ArriveCount
		{
			get { return _ArriveCount; }
			set { _ArriveCount = value; }
		}
		private long _DischargeCount;
		public long UV_DischargeCount
		{
			get { return _DischargeCount; }
			set { _DischargeCount = value; }
		}
		public long _OutgateCount;
		public long OA_OutgateCount
		{
			get { return _OutgateCount; }
			set { _OutgateCount = value; }
		}
		private long _AvailableCount;
		public long AV_AvailableCount
		{
			get { return _AvailableCount; }
			set { _AvailableCount = value; }
		}
		private long _DeliveredCount;
		public long X1_DeliveredCount
		{
			get { return _DeliveredCount; }
			set { _DeliveredCount = value; }
		}
		private long _ecCount;
		public long ec_Count
		{
			get { return _ecCount; }
			set { _ecCount = value; }
		}
		private long _rdCount;
		public long rd_Count
		{
			get { return _rdCount; }
			set { _rdCount = value; }
		}

		private long _hgCount;
		public long hg_Count
		{
			get { return _hgCount; }
			set { _hgCount = value; }
		}
		private long _hrCount;
		public long hr_Count
		{
			get { return _hrCount; }
			set { _hrCount = value; }
		}

		private long _sdCount;
		public long sd_Count
		{
			get { return _sdCount; }
			set { _sdCount = value; }
		}
		private long _bdCount;
		public long bd_Count
		{
			get { return _bdCount; }
			set { _bdCount = value; }
		}
		private long _StartDelayCount;
		public long StartDelayCount
		{
			get { return _StartDelayCount; }
			set { _StartDelayCount = value; }
		}

		private long _EndDelayCount;
		public long EndDelayCount
		{
			get { return _EndDelayCount; }
			set { _EndDelayCount = value; }
		}

		private string _PCFN;
		public string PCFN
		{
			get { return _PCFN; }
			set { _PCFN = value; }
		}
		private string _CargoStatus;
		public string CargoStatus
		{
			get { return _CargoStatus; }
			set { _CargoStatus = value; }
		}

		private string _POE;
		public string POE
		{
			get { return _POE; }
			set { _POE = value; }
		}
		private string _POD;
		public string POD
		{
			get { return _POD; }
			set { _POD = value; }
		}
		public string POETerminal;
		public string PODTerminal;
		public long ItemNo;

		private string _PLOR;
		public string PLOR
		{
			get { return _PLOR; }
			set { _PLOR = value; }
		}
		private string _PLOD;
		public string PLOD
		{
			get { return _PLOD; }
			set { _PLOD = value; }
		}
		private string _MoveTypeCd;
		public string MoveTypeCd
		{
			get { return _MoveTypeCd; }
			set { _MoveTypeCd = value; }
		}
		private string _ACMSVoyageNo;
		public string ACMSVoyageNo
		{
			get { return _ACMSVoyageNo; }
			set { _ACMSVoyageNo = value; }
		}
		public DateTime? ACMSDepartDt;
		private DateTime? _ACMSArriveDt;
		public DateTime? ACMSArriveDt
		{
			get { return _ACMSArriveDt; }
			set { _ACMSArriveDt = value; }
		}
		public bool IsDoorIn
		{
			get
			{
				if( MoveTypeCd == "F5" ||
					MoveTypeCd == "F6" ||
					MoveTypeCd == "F9" )
					return true;
				return false;
			}
		}
		public bool IsDoorOut
		{
			get
			{
				if( MoveTypeCd == "F7" ||
					MoveTypeCd == "F8" ||
					MoveTypeCd == "F9" )
					return true;
				return false;
			}
		}

		public override int Insert()
		{
			throw new Exception("The method or operation is not implemented.");
		}
		public override int Update()
		{
			throw new Exception("The method or operation is not implemented.");
		}
		public override int Delete()
		{
			throw new Exception("The method or operation is not implemented.");
		}
		public override void ResetColumns()
		{
			return;
		}
		public override void LoadFromDataRow(System.Data.DataRow dr)
		{
			throw new Exception("The method or operation is not implemented.");
		}
		public override void CopyToDataRow(System.Data.DataRow dr)
		{
			throw new Exception("The method or operation is not implemented.");
		}

	}
}
