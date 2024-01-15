using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using NuGet.DependencyResolver;
using System.Diagnostics;
using UnitOfWork.Data;
using UnitOfWork.Data.Cart;
using UnitOfWork.Data.Services;
using UnitOfWork.Migrations;
using UnitOfWork.Models;

namespace UnitOfWork.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IProductServices _productServices;
        private readonly ICategoryService _categoryService;
        private readonly IProductOptionsService _productOptionsService;

        private readonly ApplicationDbContext _context;
        //private readonly ShoppingCart _shoppingcart;

        public HomeController(IProductServices productServices , ILogger<HomeController> logger, ICategoryService categoryService, IProductOptionsService productOptionsService)
        {
            _productServices = productServices;
            _logger = logger;
            _categoryService = categoryService;
            _productOptionsService = productOptionsService;


        }


       
        public async Task<IActionResult> Index()
        {
            DisplayViews displayViews = new DisplayViews();

            displayViews.Products = (List<Products>) await _productServices.MediumProducts();
            displayViews.categories = (List<Category>) await _categoryService.GetAllAsync();



            //var result = await _productServices.GetAllProducts();
            return View(displayViews);
        }

        public async Task<IActionResult> ProductDetail(int Id)
        {
            if(Id == null)
            {
                return NotFound();
            }
             var produId = await _productServices.GetByIdAsync(Id);

            ViewData["option11"] = new SelectList(await _productOptionsService.GetAllProductOptions(), "option11", "option11");
            ViewData["option22"] = new SelectList(await _productOptionsService.GetAllProductOptions(), "option22", "option22");
            ViewData["option33"] = new SelectList(await _productOptionsService.GetAllProductOptions(), "option22", "option33");
            ViewData["option44"] = new SelectList(await _productOptionsService.GetAllProductOptions(), "option22", "option44");
            ViewData["option55"] = new SelectList(await _productOptionsService.GetAllProductOptions(), "option22", "option55");
            ViewData["option66"] = new SelectList(await _productOptionsService.GetAllProductOptions(), "option22", "option66");
            return View(produId);
        }


        [AllowAnonymous]

        public async Task<IActionResult> DisplayFullCategory(int Id, string? slug)
        {
            DisplayViews displayViews = new DisplayViews();

            var oneCat = await _categoryService.GetByIdAsync(Id);

            var allProducts = await _productServices.GetAllProducts();

            if (Id == null && slug == null)
            {
                return NotFound();
            }
             
            var filteredResultNew = allProducts.Where(n => string.Equals(n.Category, slug, StringComparison.CurrentCultureIgnoreCase)).ToList();
            //var filteredResultNew =  

            displayViews.Products = filteredResultNew;
            // model display view Products product
            displayViews.singlecategory = oneCat;



            return View("DisplayCategory", displayViews);

        }






            [AllowAnonymous]
        public async Task<IActionResult> DisplayCategory(string FilterCategory)
        {
            DisplayViews displayViews = new DisplayViews();

            var allProducts = await _productServices.GetAllProducts(); //   .GetAllAsync(n => n.Category);

            if (!string.IsNullOrEmpty(FilterCategory))
            {
                //var filteredResult = allMovies.Where(n => n.Name.ToLower().Contains(searchString.ToLower()) || n.Description.ToLower().Contains(searchString.ToLower())).ToList();

                 var filteredResultNew = allProducts.Where(n => string.Equals(n.Category, FilterCategory, StringComparison.CurrentCultureIgnoreCase)).ToList();
               // var filteredResultNew = allProducts.Where(n => string.FilterCategory).ToList();

                displayViews.Products = filteredResultNew;
                displayViews.categories = (List<Category>)await _categoryService.GetAllAsync();
                return View("DisplayCategory", displayViews);
            }

                displayViews.Products = allProducts.ToList();
                displayViews.categories = (List<Category>)await _categoryService.GetAllAsync();
                return View("DisplayCategory", allProducts);

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