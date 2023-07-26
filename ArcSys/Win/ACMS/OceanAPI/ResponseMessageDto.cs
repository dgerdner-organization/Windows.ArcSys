namespace WebApiDemo.Dto
{
    public class ResponseMessageDto
    {

      
            /// <summary>
            ///     Booking Number
            /// </summary>
            public string Number { get; set; }

            /// <summary>
            ///     Booking Status e.g "Confirmed"
            /// </summary>
            public string BookingStatus { get; set; }

            /// <summary>
            ///     Success Code e.g "Success"
            /// </summary>
            public string SuccessCode { get; set; }

            /// <summary>
            ///     Message Object
            /// </summary>
            public MessageDto Message { get; set; }
        
    }
}
