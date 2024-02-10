using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.ViewComponents.Dashboard
{
    public class _DashboardWidgetPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DashboardWidgetPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var staffCount = await client.GetFromJsonAsync<int>("http://localhost:5062/api/DashboardWidget/staffCount");
            var bookingCount = await client.GetFromJsonAsync<int>("http://localhost:5062/api/DashboardWidget/bookingCount");
            var guestCount = await client.GetFromJsonAsync<int>("http://localhost:5062/api/DashboardWidget/guestCount");
            var roomCount = await client.GetFromJsonAsync<int>("http://localhost:5062/api/DashboardWidget/roomCount");


            ViewBag.staffcount = staffCount;
            ViewBag.bookingcount = bookingCount;
            ViewBag.guestcount = guestCount;
            ViewBag.roomcount = roomCount;
            return View();
        }
    }
}
