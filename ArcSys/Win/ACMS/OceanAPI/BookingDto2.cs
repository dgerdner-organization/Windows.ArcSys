using System.ComponentModel.DataAnnotations;

namespace Arc.Stork.WebApi.Dto
{
    public class BookingDto
    {
        /// <summary>
        ///     Port Call File Number e.g "1"
        /// </summary>
        [Required]
        [StringLength(8)]
        public string PortCallFileNumber { get; set; }

        /// <summary>
        ///     Customer Number e.g "000001"
        /// </summary>
        [Required]
        [StringLength(6)]
        public string CustomerNumber { get; set; }

        /// <summary>
        ///     Voyage Number e.g "CB12345"
        /// </summary>
        [Required]
        [StringLength(10)]
        public string VoyageNumber { get; set; }

        /// <summary>
        ///     Shipment Condition Code e.g "F1"
        /// </summary>
        [Required]
        [StringLength(8)]
        public string ShipmentConditionCode { get; set; }

        /// <summary>
        ///     Place Of Receipt e.g "BEANR"
        /// </summary>
        [Required]
        [StringLength(5)]
        public string PlaceOfReceipt { get; set; }

        /// <summary>
        ///     Place Of Delivery e.g "ITLIV"
        /// </summary>
        [Required]
        [StringLength(5)]
        public string PlaceOfDelivery { get; set; }

        /// <summary>
        ///     Port Of Load e.g "USBAL1"
        /// </summary>
        [Required]
        [StringLength(7)]
        public string PortOfLoad { get; set; }

        /// <summary>
        ///     Port Of Discharge e.g "DEBRH2"
        /// </summary>
        [Required]
        [StringLength(7)]
        public string PortOfDischarge { get; set; }

        /// <summary>
        ///     Revenue Code e.g "RDOS"
        /// </summary>
        [Required]
        [StringLength(8)]
        public string RevenueCode { get; set; }

        /// <summary>
        ///     Standard Carrier Alpha Code e.g "AROF"
        /// </summary>
        [Required]
        [StringLength(4)]
        public string ScacCode { get; set; }
    }
}