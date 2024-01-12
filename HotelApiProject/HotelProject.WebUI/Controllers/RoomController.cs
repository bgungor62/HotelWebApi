using HotelProject.WebUI.Dtos.RoomDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    public class RoomController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<RoomController> _logger;

        public RoomController(IHttpClientFactory httpClientFactory, ILogger<RoomController> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5062/api/Room");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultRoomDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult AddRoom()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddRoom(CreateRoomDto createRoomDto, CreateRoomDto2 createRoomDto2)
        {
            try
            {
                var extension = Path.GetExtension(createRoomDto2.CoverImage.FileName);
                var newImageName = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/", newImageName);
                var stream = new FileStream(location, FileMode.Create);
                createRoomDto2.CoverImage.CopyTo(stream);
                if (newImageName is not null)
                {
                    createRoomDto.CoverImage = newImageName;
                    var client = _httpClientFactory.CreateClient();
                    var jsonData = JsonConvert.SerializeObject(createRoomDto);
                    StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                    var responseMessage = await client.PostAsync("http://localhost:5062/api/Room", stringContent);
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        ViewBag.success = true;
                    }

                }
                else
                {
                    ViewBag.success = false;
                    _logger.LogInformation("Dosya boş seçildiği için hata alındı!");

                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                ViewBag.success = false;
            }
            return View();

        }

        public async Task<IActionResult> DeleteRoom(int id)
        {
            try
            {
                _logger.LogInformation("Oda'yı veritabından silme işlemine olan sil butonuna tıklanıldı..");
                var client = _httpClientFactory.CreateClient();
                var responseMessage = await client.DeleteAsync($"http://localhost:5062/api/Room?id={id}");
                if (responseMessage.IsSuccessStatusCode)
                {
                    _logger.LogInformation("Oda silindi..");
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {

                _logger.LogInformation(ex.Message);
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateRoom(int id)
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                var responseMessage = await client.GetAsync($"http://localhost:5062/api/Room/{id}");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsonData = await responseMessage.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<UpdateRoomDto>(jsonData);
                    return View(values);
                }
            }
            catch (Exception ex)
            {

                _logger.LogInformation(ex.Message);
            }

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateRoom(UpdateRoomDto roomDto, CreateRoomDto2 createRoomDto)
        {
            try
            {
                var extension = Path.GetExtension(createRoomDto.CoverImage.FileName);
                var newImageName = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/", newImageName);
                var stream = new FileStream(location, FileMode.Create);
                createRoomDto.CoverImage.CopyTo(stream);
                if (newImageName is not null)
                {
                    roomDto.CoverImage = newImageName;
                    var client = _httpClientFactory.CreateClient();
                    var jsonData = JsonConvert.SerializeObject(roomDto);
                    StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                    var responseMessage = await client.PutAsync("http://localhost:5062/api/Room", stringContent);
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }

            }
            catch (Exception ex)
            {

                _logger.LogInformation(ex.Message);
            }

            return View();
        }

    }
}
