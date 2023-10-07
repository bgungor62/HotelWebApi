using AutoMapper;
using HotelProjecr.EntityLayer.Concrete;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.DtoLayer.Dtos.RoomDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Room2Controller : ControllerBase
    {
        private readonly IRoomService _ıroomService;
        private readonly IMapper _ımapper;

        public Room2Controller(IRoomService ıroomService, IMapper ımapper)
        {
            _ıroomService = ıroomService;
            _ımapper = ımapper;
        }

        [HttpGet]
        public IActionResult Index2()
        {
            var Values = _ıroomService.BGetList();
            return Ok(Values);
        }

        [HttpPost]
        public IActionResult AddRoom2(RoomAddDto roomAddDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var Values=_ımapper.Map<Room>(roomAddDto);
            _ıroomService.BInsert(Values);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateRoom(RoomUpdateDto roomUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var Values = _ımapper.Map<Room>(roomUpdateDto);
            _ıroomService.BUpdate(Values);
            return Ok();
        }
    }
}
