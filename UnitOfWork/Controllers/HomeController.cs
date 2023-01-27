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
        private readonly ICategoryService _categoryService;

        //private readonly ShoppingCart _shoppingcart;

        public HomeController(IProductServices productServices , ILogger<HomeController> logger, ICategoryService categoryService)
        {
            _productServices = productServices;
            _logger = logger;
            _categoryService = categoryService;
             
        }


       
        public async Task<IActionResult> Index()
        {
            DisplayViews displayViews = new DisplayViews();

            displayViews.Products = (List<Products>) await _productServices.GetAllProducts();
            displayViews.categories = (List<Category>) await _categoryService.GetAllAsync();



            //var result = await _productServices.GetAllProducts();
            return View(displayViews);
        }



        //[HttpPost]
        //public async  Task<IActionResult> DisplayCategory(string category)
        //{
        //    DisplayViews displayViews = new DisplayViews();

        //    displayViews.categories  = (List<Category>) await _categoryService.GetByCategoriesAsync(category);  

            
        //    return View(displayViews);

        //}

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