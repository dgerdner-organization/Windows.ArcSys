using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiDemo.Dto;

namespace WebApiDemo
{
    public interface IOceanSystemAPIService
    {
        Task<TokenDto> GetTokenAsync(string password, string address);
        Task<string> UpdateBookingAsync(string token, BookingRequestDto booking, string bookingNumber, string address);
        Task<string> CreateBookingAsync(string token, BookingRequestDto booking, string address);
    }
}
