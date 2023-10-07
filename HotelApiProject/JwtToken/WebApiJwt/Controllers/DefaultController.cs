using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiJwt.Models;

namespace WebApiJwt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        [HttpGet("[action]")]
        public IActionResult TokenTest()
        {
            return Ok(new CreateToken().TokenCreate());
        }

        [Authorize]
        [HttpGet("[action]")]
        public IActionResult AuthorizeTest()
        {
            return Ok("Hoşgeldiniz");
        }

        [HttpGet("[action]")]
        public IActionResult AdminTokenTest()
        {
            return Ok(new CreateToken().CreateTokenAdmin());
        }

        [Authorize(Roles ="Admin,Visitor")]
        [HttpGet("[action]")]
        public IActionResult LoginTokenTest()
        {
            return Ok("Başarılı");
        }
    }
}
