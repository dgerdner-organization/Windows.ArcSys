using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace WebApiDemo
{
    public class OceanSystemAPIService : IOceanSystemAPIService
    {
        public async Task<TokenDto> GetTokenAsync(string password, string address)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri(address)
            };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));


            var tokenModel = new Dictionary<string, string>
            {
                {"grant_type", "password"},
                {"username", ""},
                {"password", password}
            };

            var response = await client.PostAsync("/token", new FormUrlEncodedContent(tokenModel));

            response.EnsureSuccessStatusCode();
            var token = await response.Content.ReadAsAsync<TokenDto>(new[] { new JsonMediaTypeFormatter() });

            return token;
        }

        public async Task<string> UpdateBookingAsync(string token, BookingRequestDto booking, string bookingNumber, string address)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri(address)
            };
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);

            var outputJson = "";

            var responseMessageDto = new ResponseMessageDto();

           
            try
            {
                var content = new StringContent(JsonConvert.SerializeObject(booking), Encoding.UTF8,
                    "application/json");
                var response = await client.PostAsync("api/bookings/update?bookingNumber=" + bookingNumber, content);

                var responseString = response.Content.ReadAsStringAsync();
                outputJson = await responseString;
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    MessageBox.Show(ex.InnerException.Message, ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show(ex.Message, ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);

                responseMessageDto.Message = new MessageDto
                {
                    Description = "Error" + ex.Message
                };
            }

            return outputJson;
        }
        

        public async Task<string> CreateBookingAsync(string token, BookingRequestDto booking, string address)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri(address)
            };

            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);
            var outputJson = "";

            var responseMessageDto = new ResponseMessageDto();
            try
            {
                var content = new StringContent(JsonConvert.SerializeObject(booking), Encoding.UTF8,
                    "application/json");
                var response = await client.PostAsync(
                    "api/bookings/add", content);

                var responseString = response.Content.ReadAsStringAsync();
                outputJson = await responseString;
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    MessageBox.Show(ex.InnerException.Message, ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show(ex.Message, ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);

                responseMessageDto.Message = new MessageDto
                {
                    Description = "Error" + ex.Message
                };
            }

            return outputJson;
        }
    }
}
