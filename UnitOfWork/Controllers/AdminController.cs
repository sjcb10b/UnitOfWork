using Microsoft.AspNetCore.Mvc;

namespace UnitOfWork.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
