using HotelProjecr.EntityLayer.Concrete;
using HotelProject.WebUI.Dtos.LoginDto;
using HotelProject.WebUI.MessageServices;
using HotelProject.WebUI.Models.Login;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.Controllers
{
    [AllowAnonymous] //Burada giriş için Authorization devre dışı bırakıyoruz
    public class LoginController : Controller
    {
        private readonly INotificationService _notificationService;
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(SignInManager<AppUser> signInManager, INotificationService notificationService)
        {
            _signInManager = signInManager;
            _notificationService = notificationService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel LoginViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(LoginViewModel.Username, LoginViewModel.Password, false, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    _notificationService.ErrorNotification("Yanlış Şifre Veya Kullanıcı Adı girdiniz.");
                    return RedirectToAction("Index","Login");
                }
            }

            return View();
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
