using HotelProjecr.EntityLayer.Concrete;
using HotelProject.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _ıroomService;

        public RoomController(IRoomService ıroomService)
        {
            _ıroomService = ıroomService;
        }

        [HttpGet]
        public ActionResult RoomList()
        {
            var values = _ıroomService.BGetList();
            return Ok(values);
        }
        [HttpPost]
        public ActionResult AddRoom(Room room)
        {
            _ıroomService.BInsert(room);
            return Ok();

        }
        [HttpDelete]
        public ActionResult DeleteRoom(int id)
        {
            var values = _ıroomService.BGetById(id);
            _ıroomService.BDelete(values);
            return Ok();
        }
        [HttpPut]
        public ActionResult UpdateRoom(Room room)
        {
            _ıroomService.BUpdate(room);
            return Ok();
        }
        [HttpGet("{id}")]
        public ActionResult GetRoom(int id)
        {
            var values = _ıroomService.BGetById(id);
            return Ok(values);
        }

    }
}
