using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.ViewComponents.Booking
{
    public class _BookingPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}