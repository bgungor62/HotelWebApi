using HotelProjecr.EntityLayer.Concrete;
using HotelProject.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
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
        [EnableQuery(AllowedFunctions =AllowedFunctions.All)]
        public IActionResult GetContacts()
        {
            var query = _contactService.BGetList();
            return Ok(query.AsQueryable());
        }
        [HttpGet("contactCount")]
        public IActionResult GetContactsCount()
        {
            return Ok(_contactService.TGetContactCount());
        }
        [HttpGet("{id}")]
        public IActionResult GetContact(int id)
        {
            return Ok(_contactService.BGetById(id));
        }

        [HttpPost]
        public IActionResult InsertContact(Contact contact)
        {
            _contactService.BInsert(contact);
            return Ok("Kayıt işlemi gerçekleşti");
        }
    }
}
