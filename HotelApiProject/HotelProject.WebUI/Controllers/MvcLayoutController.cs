using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.Controllers
{
    public class MvcLayoutController : Controller
    {
        public IActionResult AdminLayout()
        {
            return View();
        }

        public PartialViewResult HeadPartial()
        {
            return PartialView();
        }

        public PartialViewResult ReloaderPartial()
        {
            return PartialView();
        }

        public PartialViewResult NavabarPartial()
        {
            return PartialView();
        }

        public PartialViewResult HeaderPartial()
        {
            return PartialView();
        }
        public PartialViewResult SidebarPartial()
        {
            return PartialView();
        }
        public PartialViewResult ScriptPaartial()
        {
            return PartialView();
        }
    }
}
