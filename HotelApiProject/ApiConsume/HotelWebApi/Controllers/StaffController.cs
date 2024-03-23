using HotelProjecr.EntityLayer.Concrete;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.DtoLayer.Dtos.StaffDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace HotelWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {

        private IMemoryCache _memoryCache;
        private readonly IStaffService _staffService;

        public StaffController(IMemoryCache memoryCache, IStaffService staffService)
        {
            _memoryCache = memoryCache;
            _staffService = staffService;
        }

        [HttpGet]
        public ActionResult StaffList()
        {
            var values = _staffService.BGetList();
            return Ok(values);
        }
        [HttpGet("staffCache")]
        public ActionResult StaffList2()
        {
            var cacheKey = "StaffListCacheKey"; //İlk önce bir key oluşturdum önbellektki veriye erişmek için kullanılır
            if (!_memoryCache.TryGetValue(cacheKey, out var values))
            //TryGetVaşues ile önbellekteki veri kontrol edilir eğer veri yoksa if bloğu çalışır
            {
                values = _staffService.BGetList(); //Verimizi values değişkenine atıyoruz

                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromMinutes(10)); // Önbellekte 10 dakika kalacak

                _memoryCache.Set(cacheKey, values, cacheEntryOptions); //Veri belleğe atılır
            }

            return Ok(values);
        }

        [HttpGet("staffLast4List")]
        public IActionResult StaffLast4List()
        {
            var values = _staffService.TGet4StaffList();
            return Ok(values);
        }

        [HttpPost]
        public ActionResult AddStaff(Staff s)
        {
            _staffService.BInsert(s);
            return Ok();
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteStaff(int id)
        {
            var values = _staffService.BGetById(id);
            _staffService.BDelete(values);
            return Ok();
        }
        [HttpPut]
        public ActionResult UpdateStaff(Staff staff)
        {
            _staffService.BUpdate(staff);
            return Ok();
        }
        [HttpGet("{id}")]
        public ActionResult GetStaff(int id)
        {
            var values = _staffService.BGetById(id);
            return Ok(values);
        }
    }
}
