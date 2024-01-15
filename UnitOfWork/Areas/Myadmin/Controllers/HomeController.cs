using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UnitOfWork.Areas.Myadmin.Controllers
{
    [Area("Myadmin")]
    [Authorize]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
