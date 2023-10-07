using HotelProjecr.EntityLayer.Concrete;
using HotelProject.WebUI.Dtos.AppUserDto;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager; //Identity kütüphanesi ile gelir

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(CreateAppUserDto createAppUserDto)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var appUser = new AppUser()
            {
                Name = createAppUserDto.Name,
                Email = createAppUserDto.Mail,
                Surname = createAppUserDto.Surname,              
                UserName = createAppUserDto.UserName
            };
            var result = await _userManager.CreateAsync(appUser, createAppUserDto.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Login");
            }         
            return View();
        }
    }
}
