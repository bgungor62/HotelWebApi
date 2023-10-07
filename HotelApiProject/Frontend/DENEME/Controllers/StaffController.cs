using Microsoft.AspNetCore.Mvc;

namespace DENEME.Controllers
{
    public class StaffController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
