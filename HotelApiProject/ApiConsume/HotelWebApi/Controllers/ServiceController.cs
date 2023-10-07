using HotelProjecr.EntityLayer.Concrete;
using HotelProject.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Diagnostics.CodeAnalysis;

namespace HotelWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceService _serviceService;
        private IMemoryCache _memoryCache;
        public ServiceController(IServiceService serviceService, IMemoryCache cache)
        {
            _serviceService = serviceService;
            _memoryCache = cache;
        }
        [HttpGet]
        public ActionResult ServiceList()
        {
            var values = _serviceService.BGetList();
            return Ok(values);
        }
        [HttpGet("apiMemomryCache")]
        public async Task<ActionResult> ServiceListCache()
        {
            string key;
            key = "servicesCacheKey";
            if (!_memoryCache.TryGetValue(key, out var values))
            {
                values = _serviceService.BGetList();
                //cache oluştur
                var cacheExpOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpiration = DateTime.Now.AddMinutes(30),
                    Priority = CacheItemPriority.Normal
                };
                //cache oluşturma komutu
                _memoryCache.Set(key, values, cacheExpOptions);

            }

            return Ok(values);
        }
        [HttpPost]
        public ActionResult AddService(Service s)
        {
            _serviceService.BInsert(s);
            return Ok();
        }
        [HttpPut]
        public ActionResult UpdateService(Service s)
        {
            _serviceService.BUpdate(s);
            return Ok();
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteService(int id)
        {
            var values = _serviceService.BGetById(id);
            _serviceService.BDelete(values);
            return Ok();
        }
        [HttpGet("{id}")]
        public ActionResult GetService(int id)
        {
            var values = _serviceService.BGetById(id);
            return Ok(values);
        }

       
    }
}
