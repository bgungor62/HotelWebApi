using HotelProject.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardWidgetController : ControllerBase
    {
        private readonly IStaffService _staffService;
        private readonly IBookingService _bookingService;
        private readonly IGuestService _guestService;
        private readonly IRoomService _roomService;

        public DashboardWidgetController(IStaffService staffService, IBookingService bookingService, IGuestService guestService,IRoomService roomService)
        {
            _staffService = staffService;
            _bookingService = bookingService;
            _guestService = guestService;
            _roomService = roomService;
        }

        [HttpGet("staffCount")]
        public IActionResult GetCountStaff()
        {
            var values = _staffService.TGetStaffCount();
            return Ok(values);
        }

        [HttpGet("bookingCount")]
        public IActionResult GetCountBooking()
        {
            var values = _bookingService.TGetCountBooking();
            return Ok(values);
        }

        [HttpGet("guestCount")]
        public IActionResult GetCountGuest()
        {
            var values = _guestService.TGetCountGuest();
            return Ok(values);
        }

        [HttpGet("roomCount")]
        public IActionResult GetCountRoom()
        {
            var values = _roomService.TGetCountRoom();
            return Ok(values);
        }

    }
}
