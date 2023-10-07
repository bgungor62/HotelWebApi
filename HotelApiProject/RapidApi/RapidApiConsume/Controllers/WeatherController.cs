using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.Net.Http.Headers;
namespace RapidApiConsume.Controllers
{
    public class WeatherController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://open-weather13.p.rapidapi.com/city/%C4%B0stanbul"),
                Headers =
    {
        { "X-RapidAPI-Key", "3898023526msh4bcc18d1930d8b9p1d6a89jsned266c4cf527" },
        { "X-RapidAPI-Host", "open-weather13.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                Console.WriteLine(body);
            }
            return View();
        }
    }
}
