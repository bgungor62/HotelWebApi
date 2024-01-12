using HotelProjecr.EntityLayer.Concrete;
using HotelProject.WebUI.Dtos.AppUserDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace HotelProject.WebUI.Controllers
{
    [AllowAnonymous]
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
            if (ModelState.IsValid)
            {
                AppUser appUser = new AppUser
                {
                    Name = createAppUserDto.Name,
                    Email = createAppUserDto.Mail,
                    Surname = createAppUserDto.Surname,
                    UserName = createAppUserDto.UserName
                };
                IdentityResult result = await _userManager.CreateAsync(appUser, createAppUserDto.Password);
                if (result.Succeeded)
                    return RedirectToAction("/Login/Index/");
                else
                    result.Errors.ToList().ForEach(e => ModelState.AddModelError(e.Code, e.Description));
            }

            //if (!ModelState.IsValid)
            //{
            //    return View();
            //}
            //var appUser = new AppUser()
            //{
            //    Name = createAppUserDto.Name,
            //    Email = createAppUserDto.Mail,
            //    Surname = createAppUserDto.Surname,
            //    UserName = createAppUserDto.UserName
            //};
            //var result = await _userManager.CreateAsync(appUser, createAppUserDto.Password);
            //if (result.Succeeded)
            //{
            //    return RedirectToAction("Index", "Login");
            //}
            return View();
        }
    }
}
