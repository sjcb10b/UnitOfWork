using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UnitOfWork.Data.Cart;
using UnitOfWork.Data.Services;
using UnitOfWork.Models;

namespace UnitOfWork.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IProductServices _productServices;
        //private readonly ShoppingCart _shoppingcart;

        public HomeController(IProductServices productServices , ILogger<HomeController> logger)
        {
            _productServices = productServices;
             
        }


       
        public async Task<IActionResult> Index()
        {
            var result = await _productServices.GetAllProducts();
            return View(result);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}