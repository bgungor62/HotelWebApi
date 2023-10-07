using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidApiConsume.Models;
using System.Net.Http.Headers;
namespace RapidApiConsume.Controllers
{
    public class SearchLocationIDController : Controller
    {
        public async Task<IActionResult> Index(string cityName)
        {
            if (!string.IsNullOrEmpty(cityName))
            {
                List<BookingApiSearchLocationViewModel> bookingApiSearchLocationViewModels =
             new List<BookingApiSearchLocationViewModel>();
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v1/hotels/locations?name={cityName}&locale=en-gb"),
                    Headers =
    {
        { "X-RapidAPI-Key", "3898023526msh4bcc18d1930d8b9p1d6a89jsned266c4cf527" },
        { "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
    },
                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    bookingApiSearchLocationViewModels = JsonConvert.DeserializeObject<List<BookingApiSearchLocationViewModel>>(body);
                    return View(bookingApiSearchLocationViewModels.Take(1).ToList());
                }
            }
            else
            {
                  List<BookingApiSearchLocationViewModel> bookingApiSearchLocationViewModels =
             new List<BookingApiSearchLocationViewModel>();
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("https://booking-com.p.rapidapi.com/v1/hotels/locations?name=An&locale=en-gb"),
                    Headers =
    {
        { "X-RapidAPI-Key", "3898023526msh4bcc18d1930d8b9p1d6a89jsned266c4cf527" },
        { "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
    },
                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    bookingApiSearchLocationViewModels = JsonConvert.DeserializeObject<List<BookingApiSearchLocationViewModel>>(body);
                    return View(bookingApiSearchLocationViewModels.Take(1).ToList());
                }
            }
         
        }
    }
}
