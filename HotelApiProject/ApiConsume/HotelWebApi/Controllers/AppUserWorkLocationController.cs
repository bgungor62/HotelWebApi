using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserWorkLocationController : ControllerBase
    {
        private readonly IAppUserService _appUserService;

        public AppUserWorkLocationController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }
        [HttpGet]
        public IActionResult UserListWithWorkLocation()
        {
            Context context = new Context();
            var values = context.Users.Include(x => x.WorkLocation).Select(y => new AppUserWithWorkLocationModel
            {
                Name = y.Name,
                Surname = y.Surname,
                WorkLocationName = y.WorkLocation.Name,
                WorkLocationId = y.WorkLocationId,
                Country = y.Country,
                City = y.City,
                Gender = y.Gender,
                ImageUrl = y.ImageUrl,
                Email = y.Email,
            }).ToList();

            return Ok(values);
        }
    }
}
