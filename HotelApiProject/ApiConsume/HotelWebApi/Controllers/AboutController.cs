using HotelProjecr.EntityLayer.Concrete;
using HotelProject.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace HotelWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        [HttpGet] //Listeleme
        public IActionResult AboutList()
        {
            var query = _aboutService.BGetList();
            return Ok(query);
        }

        [HttpPost]
        public IActionResult AddAbout(About about)
        {
            _aboutService.BInsert(about);
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteAbout(int id)
        {
            var query = _aboutService.BGetById(id);
            _aboutService.BDelete(query);
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult PutAbout(int id)
        {
            var query = _aboutService.BGetById(id);
            _aboutService.BUpdate(query);
            return Ok();
        }
        [HttpGet("{id}")]
        public ActionResult GetAbout(int id)
        {
            var values = _aboutService.BGetById(id);
            return Ok(values);
        }
    }
}
