using AutoMapper;
using HotelProjecr.EntityLayer.Concrete;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.DtoLayer.Dtos.Guest;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestController : ControllerBase
    {
        private readonly IGuestService _iguestService;
        private readonly IMapper _imapper;

        public GuestController(IMapper imapper, IGuestService guestService)
        {
            _imapper = imapper;
            _iguestService = guestService;
        }

        [HttpGet]
        public IActionResult GuestList()
        {
            var query = _iguestService.BGetList().OrderBy(x=>x.Status);
            return Ok(query);
        }
        [HttpPost]
        public IActionResult GuestAdd(Guest guest)
        {
            _iguestService.BInsert(guest);
            return Ok(guest);
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var query = _iguestService.BGetById(id);
            _iguestService.BDelete(query);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var query = _iguestService.BGetById(id);
            return Ok(query);
        }

        [HttpPut]
        public IActionResult PutAbout(Guest guest)
        {
            _iguestService.BUpdate(guest);
            return Ok();
        }
    }
}
