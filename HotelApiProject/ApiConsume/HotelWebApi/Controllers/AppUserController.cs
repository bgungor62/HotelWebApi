using AutoMapper;
using HotelProject.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserController : ControllerBase
    {
        private readonly IAppUserService _appUserService;
        private readonly IMapper _imapper;

        public AppUserController(IAppUserService appUserService, IMapper imapper)
        {
            _appUserService = appUserService;
            _imapper = imapper;
        }

        [HttpGet] //Listeleme
        public IActionResult UserListWithWorkLocation()
        {
            var query = _appUserService.TAppUserListWithWorkLocation();
            return Ok(query);
        }
    }
}
