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

        public DashboardWidgetController(IStaffService staffService)
        {
            _staffService = staffService;
        }

        [HttpGet("staffCount")]
        public IActionResult StaffCount()
        {
            var values = _staffService.TGetStaffCount();
            return Ok(values);
        }

    }
}
