using HotelProjecr.EntityLayer.Concrete;
using HotelProject.BusinessLayer.Concrete;
using HotelProject.WebUI.Dtos.AppUserDto;
using HotelProject.WebUI.Models.Role;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace HotelProject.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RoleAssignController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IHttpClientFactory _httpClientFactory;

        public RoleAssignController(IHttpClientFactory httpClientFactory, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _httpClientFactory = httpClientFactory;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5062/api/AppUser/AppUserList");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<UserRoleAssignList>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> AssignRole(int id)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.Id == id);
            TempData["id"] = user.Id;
            var roles = _roleManager.Roles.ToList();
            var usersRoles = await _userManager.GetRolesAsync(user);
            List<RoleAssignViewModel> roleAssignViewModels = new List<RoleAssignViewModel>();
            foreach (var item in roles)
            {
                RoleAssignViewModel model = new RoleAssignViewModel();
                model.RoleId = item.Id;
                model.RolesName = item.Name;
                model.RoleExists = usersRoles.Contains(item.Name);
                roleAssignViewModels.Add(model);
            }
            return View(roleAssignViewModels);
        }
        [HttpPost]
        public async Task<IActionResult> AssignRole(List<RoleAssignViewModel> roleAssignViews)
        {
            var userid = (int)TempData["id"];
            var user = _userManager.Users.FirstOrDefault(y => y.Id == userid);
            foreach (var item in roleAssignViews)
            {
                if (item.RoleExists)
                {
                    await _userManager.AddToRoleAsync(user, item.RolesName);
                }
                else
                    await _userManager.RemoveFromRoleAsync(user, item.RolesName);
            }
            return RedirectToAction("Index");

        }
    }
}
