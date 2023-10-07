using HotelProjecr.EntityLayer.Concrete;
using HotelProject.WebUI.Models.Staff;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    public class StafController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private IMemoryCache _memoryCache;
        public StafController(IHttpClientFactory httpClientFactory,IMemoryCache cache)
        {
            _httpClientFactory = httpClientFactory;
            _memoryCache = cache;
        }

        public async Task<IActionResult> Index()
        {
            var cacheKey = "staffListCacheKey";
            var cachedValue = await _memoryCache.GetOrCreateAsync(cacheKey, async (entry) =>
            {
                var client = _httpClientFactory.CreateClient();
                var responMessage = await client.GetAsync("http://localhost:5062/api/Staff/staffCache");
                if (responMessage.IsSuccessStatusCode)
                {
                    var jsonData = await responMessage.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<List<StaffViewModel>>(jsonData);
                    entry.SlidingExpiration = TimeSpan.FromMinutes(3);
                    return values;
                }
                return null;
            });
            return View(cachedValue);

        }
     
        public async Task<IActionResult> Index2()
        {
            var client = _httpClientFactory.CreateClient();
            var responMessage = await client.GetFromJsonAsync<List<StaffViewModel>>("http://localhost:5062/api/Staff");
           
            return View(responMessage);
        }

        [HttpGet]
        public IActionResult AddStaff()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddStaff(AddStaffModel model)
        {
            var client = _httpClientFactory.CreateClient();
            var jsondata = JsonConvert.SerializeObject(model);
            StringContent stringContent = new StringContent(jsondata,Encoding.UTF8,"application/json");
            var responsemessage = await client.PostAsync("http://localhost:5062/api/Staff", stringContent);
            if (responsemessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult>DeleteStaff(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:5062/api/Staff{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
       
        
        [HttpGet]
        public async Task<IActionResult> UpdateStaff(int id)
        {
            var client=_httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5062/api/Staff/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsondata=await responseMessage.Content.ReadAsStringAsync(); 
                var values=JsonConvert.DeserializeObject<UpdateStaffModel>(jsondata);
                return View(values);

            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateStaff(UpdateStaffModel model)
        {
            var client = _httpClientFactory.CreateClient();
            var json=JsonConvert.SerializeObject(model);
            StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("http://localhost:5062/api/Staff",stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
