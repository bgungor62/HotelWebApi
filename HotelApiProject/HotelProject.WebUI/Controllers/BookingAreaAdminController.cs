using HotelProject.WebUI.Dtos.BookingDto;
using HotelProject.WebUI.MessageServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    public class BookingAreaAdminController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly INotificationService _notificationService;

        public BookingAreaAdminController(IHttpClientFactory httpClientFactory, INotificationService notificationService)
        {
            _httpClientFactory = httpClientFactory;
            _notificationService = notificationService;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5062/api/Booking");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBookingDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> BookingApproved(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5062/api/Booking/updateBookingStatusApproved{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> BookingCancel(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5062/api/Booking/updateBookingStatusCancel{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> BookingWait(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5062/api/Booking/updateBookingStatusWait{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateBooking(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5062/api/Booking/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateBookingDto>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateBooking(UpdateBookingDto bookingDto)
        {
            var client = _httpClientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(bookingDto);
            StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            var responsMessage = await client.PutAsync("http://localhost:5062/api/Booking/UpdateBooking", stringContent);
            if (responsMessage.IsSuccessStatusCode)
            {
                //_notificationService.SuccessNotification("Rezervasyon İşlemi Güncellendi");
                return RedirectToAction("Index");
            }
            return View();
            //else
            //{
            //    _notificationService.WarningNotification("Rezervasyon İşlemi Güncellenirken Bir Sorun İle Karşılaşıldı");
            //    return RedirectToAction(nameof(Index));
            //}
        }


    }
}
