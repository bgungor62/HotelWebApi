using HotelProjecr.EntityLayer.Concrete;
using HotelProject.WebUI.Dtos.RoomDto;
using HotelProject.WebUI.MessageServices;
using HotelProject.WebUI.Models.Settings;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.Packaging.Signing;

namespace HotelProject.WebUI.Controllers
{
    public class UserEditController : Controller
    {
        private readonly INotificationService _notificationService;
        private readonly UserManager<AppUser> _userManager;

        public UserEditController(UserManager<AppUser> userManager, INotificationService notificationService)
        {
            _userManager = userManager;
            _notificationService = notificationService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditViewModel userEditViewModel = new UserEditViewModel();
            userEditViewModel.Name = user.Name;
            userEditViewModel.Surname = user.Surname;
            userEditViewModel.Username = user.UserName;
            userEditViewModel.Email = user.Email;
            TempData["ImageUrl"] = user.ImageUrl;
            return View(userEditViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserEditViewModel userEditView, UserEditForDataViewModel userEditViewModel)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var newImageName = "";
            var extension = "";
            if (userEditViewModel.ImageUrl == null)
            {
                extension = user.ImageUrl;
                newImageName = extension;
            }
            else
            {
                extension = Path.GetExtension(userEditViewModel.ImageUrl.FileName);
                newImageName = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/", newImageName);
                var stream = new FileStream(location, FileMode.Create);
                userEditViewModel.ImageUrl.CopyTo(stream);
            }
            if (userEditView.Password == userEditView.ConfirmPassword)
            {
                user.Name = userEditView.Name;
                user.Surname = userEditView.Surname;
                user.Email = userEditView.Email;
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, userEditView.Password);
                user.ImageUrl = newImageName;
                await _userManager.UpdateAsync(user);
                return RedirectToAction("Index", "Login");
            }
            else
            {
                _notificationService.ErrorNotification("Şifreler Aynı Değil");
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
