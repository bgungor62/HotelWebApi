using HotelProjecr.EntityLayer.Concrete;
using HotelProject.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscribeController : ControllerBase
    {
        private readonly ISubscribeService _subscribeService;

        public SubscribeController(ISubscribeService subscribeService)
        {
            _subscribeService = subscribeService;
        }

        [HttpGet]
        public IActionResult SubscribeList()
        {
            var values = _subscribeService.BGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddSubscribe(Subscribe s)
        {
            _subscribeService.BInsert(s);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateSubscribe(Subscribe s)
        {
            _subscribeService.BUpdate(s);
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteSubscribe(int id)
        {
            var values=_subscribeService.BGetById(id);
            _subscribeService.BDelete(values);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetSubscribe(int id)
        {
            var values=_subscribeService.BGetById(id);
            return Ok(values);
        }
    }
}
