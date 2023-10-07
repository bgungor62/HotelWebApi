using HotelProjecr.EntityLayer.Concrete;
using HotelProject.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace HotelWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public IActionResult GetContacts()
        {
            var query = _contactService.BGetList();
            return Ok(query);
        }

        [HttpPost]
        public IActionResult InsertContact(Contact contact)
        {
         
            _contactService.BInsert(contact);
            return Ok("Kayıt işlemi gerçekleşti");
        }
    }
}
