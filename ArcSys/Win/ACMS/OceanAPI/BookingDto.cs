namespace WebApiDemo.Dto
{
    public class BookingDto
    {
        /// <summary>
        ///     Booking Number
        /// </summary>

        public string Number { get; set; }

        /// <summary>
        ///     Port Call File Number e.g "1"
        /// </summary>
        /// <example>
        ///     1
        /// </example>

        public string PortCallFileNumber { get; set; }

        /// <summary>
        ///     Customer Number e.g "000001"
        /// </summary>

        public string CustomerNumber { get; set; }

        /// <summary>
        ///     Voyage Number e.g "CB12345"
        /// </summary>

        public string VoyageNumber { get; set; }


        /// <summary>
        ///     Shipment Condition Code e.g "F1"
        /// </summary>

        public string ShipmentConditionCode { get; set; }

        /// <summary>
        ///     Place Of Receipt e.g "BEANR"
        /// </summary>

        public string PlaceOfReceipt { get; set; }

        /// <summary>
        ///     Place Of Delivery e.g "ITLIV"
        /// </summary>
  
        public string PlaceOfDelivery { get; set; }

        /// <summary>
        ///     Port Of Load e.g "USBAL1"
        /// </summary>

        public string PortOfLoad { get; set; }

        /// <summary>
        ///     Port Of Discharge e.g "DEBRH2"
        /// </summary>

        public string PortOfDischarge { get; set; }

        /// <summary>
        ///     Revenue Code e.g "RDOS"
        /// </summary>

        public string RevenueCode { get; set; }

        /// <summary>
        ///     Standard Carrier Alpha Code e.g "AROF"
        /// </summary>

        public string ScacCode { get; set; }

        /// <summary>
        ///     Required Delivery Date in the format MM/DD/YYYY e.g "10/2/2018"
        /// </summary>

        public string RequiredDeliveryDate { get; set; }
    }
}