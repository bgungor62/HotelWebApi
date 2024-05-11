using HotelProject.WebUI.Dtos.FollewersDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace HotelProject.WebUI.ViewComponents.Dashboard
{
    public class _DashboardFollowersPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();

        }

    }
}
