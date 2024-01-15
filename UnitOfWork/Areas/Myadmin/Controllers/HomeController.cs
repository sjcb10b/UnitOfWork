using Microsoft.AspNetCore.Mvc;

namespace UnitOfWork.Areas.Myadmin.Controllers
{
    [Area("Myadmin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
