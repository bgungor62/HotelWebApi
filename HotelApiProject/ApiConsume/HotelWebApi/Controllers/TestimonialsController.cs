using HotelProjecr.EntityLayer.Concrete;
using HotelProject.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelWebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialsController : ControllerBase
    {
        private readonly ITestimonialsService _testimonialsService;

        public TestimonialsController(ITestimonialsService testimonialsService)
        {
            _testimonialsService = testimonialsService;
        }     

        [HttpGet]
        public ActionResult TestimonialsList()
        {
            var values = _testimonialsService.BGetList();
            return Ok(values);
        }
        [HttpPost]
        public ActionResult AddTestimonials(Testimonial s)
        {
            _testimonialsService.BInsert(s);
            return Ok();
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteTestimonials(int id)
        {
            var values = _testimonialsService.BGetById(id);
            _testimonialsService.BDelete(values);
            return Ok();
        }
        [HttpPut]
        public ActionResult UpdateTestimonials(Testimonial Testimonials)
        {
            _testimonialsService.BUpdate(Testimonials);
            return Ok();
        }
        [HttpGet("{id}")]
        public ActionResult GetTestimonials(int id)
        {
            var values = _testimonialsService.BGetById(id);
            return Ok(values);
        }
    }
}
