using HotelProject.WebUI.Dtos.AboutDto;
using HotelProject.WebUI.Dtos.ServiceDto;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Newtonsoft.Json;

namespace HotelProject.WebUI.ViewComponents.Default
{
    public class _AboutPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _AboutPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult>InvokeAsync()
        {
            var Client = _httpClientFactory.CreateClient();
            var responseMessage = await Client.GetAsync("http://localhost:5062/api/About"); 
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var Values = JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsonData);
                return View(Values);
            }
            return View();
        }
    }
}
