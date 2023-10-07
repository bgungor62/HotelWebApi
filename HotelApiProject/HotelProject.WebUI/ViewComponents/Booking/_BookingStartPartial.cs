using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.ViewComponents.Booking
{
    public class _BookingStartPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
