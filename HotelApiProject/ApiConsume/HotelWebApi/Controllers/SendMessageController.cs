using HotelProjecr.EntityLayer.Concrete;
using HotelProject.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.Extensions.Caching.Memory;

namespace HotelWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendMessageController : ControllerBase
    {
        private IMemoryCache _memoryCache;
        private readonly ISendMessageService _sendMessageService;

        public SendMessageController(IMemoryCache memoryCache, ISendMessageService sendMessageService)
        {
            _memoryCache = memoryCache;
            _sendMessageService = sendMessageService;
        }

        [HttpGet]
        [EnableQuery(AllowedFunctions = AllowedFunctions.All)]
        public ActionResult SendMessageList()
        {
            var values = _sendMessageService.BGetList();
            return Ok(values);
        }
        [HttpGet("SendMessageCache")]
        public ActionResult SendMessageList2()
        {
            var cacheKey = "SendMessageListCacheKey"; //İlk önce bir key oluşturdum önbellektki veriye erişmek için kullanılır
            if (!_memoryCache.TryGetValue(cacheKey, out var values))
            //TryGetVaşues ile önbellekteki veri kontrol edilir eğer veri yoksa if bloğu çalışır
            {
                values = _sendMessageService.BGetList(); //Verimizi values değişkenine atıyoruz

                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromMinutes(5)); // Önbellekte 10 dakika kalacak

                _memoryCache.Set(cacheKey, values, cacheEntryOptions); //Veri belleğe atılır
            }

            return Ok(values);
        }
     
        [HttpPost]
        public ActionResult AddSendMessage(SendMessage s)
        {
            _sendMessageService.BInsert(s);
            return Ok();
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteSendMessage(int id)
        {
            var values = _sendMessageService.BGetById(id);
            _sendMessageService.BDelete(values);
            return Ok();
        }
        [HttpPut]
        public ActionResult UpdateSendMessage(SendMessage SendMessage)
        {
            _sendMessageService.BUpdate(SendMessage);
            return Ok();
        }
        [HttpGet("{id}")]
        public ActionResult GetSendMessage(int id)
        {
            var values = _sendMessageService.BGetById(id);
            return Ok(values);
        }
        [HttpGet("sendMessageCount")]
        public ActionResult GetSendMessageCount()
        {

            return Ok(_sendMessageService.TGetSendMessageCount());
        }
    }
}
