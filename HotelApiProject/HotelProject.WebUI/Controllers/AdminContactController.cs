using HotelProject.WebUI.Dtos.BookingDto;
using HotelProject.WebUI.Dtos.ContactDto;
using HotelProject.WebUI.Dtos.SendMessageDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    public class AdminContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<AdminContactController> _logger;

        public AdminContactController(IHttpClientFactory httpClientFactory, ILogger<AdminContactController> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        public async Task<IActionResult> Inbox()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5062/api/Contact");
            var inboxCount = await client.GetFromJsonAsync<int>("http://localhost:5062/api/Contact/contactCount");
            var sendboxCount = await client.GetFromJsonAsync<int>("http://localhost:5062/api/SendMessage/sendMessageCount");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultContactDto>>(jsonData);
                TempData["InboxCount"] = inboxCount;
                TempData["SendboxCount"] = sendboxCount;
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> SendBox()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5062/api/SendMessage");
            var inboxCount = await client.GetFromJsonAsync<int>("http://localhost:5062/api/Contact/contactCount");
            var sendboxCount = await client.GetFromJsonAsync<int>("http://localhost:5062/api/SendMessage/sendMessageCount");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultSendMessageDto>>(jsonData);
                TempData["InboxCount"] = inboxCount;
                TempData["SendboxCount"] = sendboxCount;
                return View(values);
            }
            return View();
        }

        //SendMessage Post Crud operation
        [HttpGet]
        public IActionResult CreateSendMessage()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateSendMessage(CreateSendMessage createSendMessage)
        {
            createSendMessage.SenderMail = "deneme";
            createSendMessage.SenderName = "deneme2";
            createSendMessage.SermderDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createSendMessage);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:5062/api/SendMessage", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("SendBox");

            }
            return View();
        }
        //PartiallView
        public async Task<PartialViewResult> SideBarAdminContactPartial()
        {
            var client = _httpClientFactory.CreateClient();
                  
            return PartialView();
        }
        public PartialViewResult SideBarAdminCategoryPartial()
        {
            return PartialView();
        }

        public async Task<IActionResult> MessageDetails(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5062/api/Contact/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<GetMessageByIdDto>(jsonData);
                return View(values);
            }
            return View();
        }
        public async Task<IActionResult> MessageDetailsBySendMessage(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5062/api/SendMessage/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<GetSendMessageByIdDto>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
