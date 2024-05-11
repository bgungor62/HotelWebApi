using AutoMapper;
using HotelProjecr.EntityLayer.Concrete;
using HotelProject.WebUI.Dtos.AppUserDto;
using HotelProject.WebUI.Dtos.RoomDto;
using HotelProject.WebUI.MessageServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace HotelProject.WebUI.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager; //Identity kütüphanesi ile gelir

        public RegisterController(UserManager<AppUser> userManager, IMapper mapper, INotificationService notificationService)
        {
            _userManager = userManager;
            _mapper = mapper;
            _notificationService = notificationService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(CreateAppUserDto createAppUserDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var extension = Path.GetExtension(createAppUserDto.ImageUrl.FileName);
                    var newImageName = Guid.NewGuid() + extension;
                    var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/", newImageName);
                    var stream = new FileStream(location, FileMode.Create);
                    createAppUserDto.ImageUrl.CopyTo(stream);
                    AppUser appUser = new()
                    {

                        Name = createAppUserDto.Name,
                        Email = createAppUserDto.Mail,
                        Surname = createAppUserDto.Surname,
                        UserName = createAppUserDto.UserName,
                        ImageUrl = newImageName,
                        WorkLocationId = 1,
                        Country = "",
                        City = "",
                        Gender = "",
                    };
                    IdentityResult result = await _userManager.CreateAsync(appUser, createAppUserDto.Password);
                    if (result.Succeeded)
                        return RedirectToAction("Index", "Login");
                    else
                        result.Errors.ToList().ForEach(e => ModelState.AddModelError(e.Code, e.Description));
                }
            }
            catch (Exception exception)
            {
                _notificationService.ErrorNotification(exception);

            }

            return View();
        }
    }
}
