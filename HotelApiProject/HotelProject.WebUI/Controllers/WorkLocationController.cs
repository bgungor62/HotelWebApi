using HotelProject.WebUI.Dtos.RoomDto;
using HotelProject.WebUI.Dtos.WorkLocationDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    public class WorkLocationController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<WorkLocationController> _logger;

        public WorkLocationController(IHttpClientFactory httpClientFactory, ILogger<WorkLocationController> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                var responseMessage = await client.GetAsync("http://localhost:5062/api/WorkLocation");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsonData = await responseMessage.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<List<ResultWorkLocationDto>>(jsonData);
                    return View(values);
                }
            }
            catch (Exception ex)
            {

                _logger.LogError(ex.Message);
            }       
            return View();
        }

        [HttpGet]
        public IActionResult AddWorkLocation()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddWorkLocation(CreateWorkLocationDto createWorkLocationDto)
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                var jsondata = JsonConvert.SerializeObject(createWorkLocationDto);
                StringContent stringContent = new StringContent(jsondata, Encoding.UTF8, "application/json");
                var responsemessage = await client.PostAsync("http://localhost:5062/api/WorkLocation", stringContent);
                if (responsemessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {

                _logger.LogError(ex.Message);
            }

            return View();

        }

        public async Task<IActionResult> DeleteWorkLocation(int id)
        {
            try
            {
                _logger.LogInformation("Oda'yı veritabından silme işlemi olan sil butonuna tıklanıldı..");
                var client = _httpClientFactory.CreateClient();
                var responseMessage = await client.DeleteAsync($"http://localhost:5062/api/WorkLocation?id={id}");
                if (responseMessage.IsSuccessStatusCode)
                {
                    _logger.LogInformation("Oda silindi..");
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {

                _logger.LogError(ex.Message);
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateWorkLocation(int id)
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                var responseMessage = await client.GetAsync($"http://localhost:5062/api/WorkLocation/{id}");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsonData = await responseMessage.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<ResultWorkLocationDto>(jsonData);
                    return View(values);
                }
            }
            catch (Exception ex)
            {

                _logger.LogError(ex.Message);
            }

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateWorkLocation(UpdateWorkLocationDto updateWork)
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(updateWork);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PutAsync("http://localhost:5062/api/UpdateWorkLocation", stringContent);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {

                _logger.LogError(ex.Message);
            }

            return View();
        }

    }

}
