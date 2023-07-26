using System.Collections.Generic;

namespace WebApiDemo.Dto
{
    /// <summary>
    ///     Booking Request
    /// </summary>
    public class BookingRequestDto
    {
        /// <summary>
        ///     Booking Object
        /// </summary>
        public BookingDto BookingDto { get; set; }

        /// <summary>
        ///     List of Address items
        /// </summary>
        public List<AddressDto> AddressDtos { get; set; }

        /// <summary>
        ///     List of Cargo Details
        /// </summary>
        public List<CargoDto> CargoDtos { get; set; }
    }
}
