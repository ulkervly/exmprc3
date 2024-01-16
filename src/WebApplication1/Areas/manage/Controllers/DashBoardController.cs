using Microsoft.AspNetCore.Mvc;

namespace Hook.MVC.Areas.manage.Controllers
{
    public class DashBoardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
