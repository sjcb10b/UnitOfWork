using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Claims;
using UnitOfWork.Data.Cart;
using UnitOfWork.Data.Services;
using UnitOfWork.Data.ViewModels;
using UnitOfWork.Migrations;
using UnitOfWork.Models;

namespace UnitOfWork.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ShoppingCart _shoppingCart;
        private readonly IProductServices _productServices;
        private readonly IOrdersCartService _ordersCartService;

        public OrdersController(ShoppingCart shoppingCart, IProductServices productServices, IOrdersCartService ordersCartService)
        {
            _shoppingCart= shoppingCart;
            _productServices = productServices;
            _ordersCartService= ordersCartService;

        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ShoppingCart()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.shoppingCartItems = items;

            var response = new ShoppingCartVM()
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal(),
                GetTotalCartItems = (int)_shoppingCart.GetTotalCartItems()

            };

            return View(response);
        }

        public async Task<IActionResult> AddItemToShoppingCart(int Id)
        {
            var item = await _productServices.GetProductsAsync(Id);

            if (item != null)
            {
                _shoppingCart.AddItemToCart(item);
            }
            return RedirectToAction(nameof(ShoppingCart));
        }

        public async Task<IActionResult> ThankYou()
        {
            //var items = await _ordersCartService.GetAllAsync();

            //var items = await _ordersCartService.GetLastAsync();
            return View();

        }


        public async Task<IActionResult> FinalCheckOut([Bind("FirstName,LastName,Company,Street,City,State,ZipCode,Phone, ccc_name,ccc_number, cvv, expiration")] OrdersCart ordersCart)
        {

            await _ordersCartService.AddAsync(ordersCart);
            
            return RedirectToAction(nameof(ThankYou));
        } 
        




        public async Task<IActionResult> AddItemToShoppingCartA(int Id, int qty, string option1, string option2, string option3, string option4, string option5, string option6)
        {
            var item = await _productServices.GetProductsAsync(Id);

            if (item != null)
            {
               

                _shoppingCart.AddItemToCartA(item, qty, option1, option2, option3, option4, option5, option6);
            }
            return RedirectToAction(nameof(ShoppingCart));
        }






        public async Task<IActionResult> RemoveItemFromShoppingCart(int Id)
        {
            var item = await _productServices.GetByIdAsync(Id); 

            if (item != null)
            {
                _shoppingCart.RemoveItemFromCart(item);
            }
            return RedirectToAction(nameof(ShoppingCart));
        }


        public async Task<IActionResult> CheckOut()
        {

            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.shoppingCartItems = items;

            var response = new ShoppingCartVM()
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal(),
                GetTotalCartItems = (int)_shoppingCart.GetTotalCartItems()

            };

            return View(response);

            
        }



        //public async Task<IActionResult> CompleteOrder()
        //{
        //   // var items = _shoppingCart.GetShoppingCartItems();
        //   // string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        //   // string userEmailAddress = User.FindFirstValue(ClaimTypes.Email);

        //   //// await _ordersService.StoreOrderAsync(items, userId, userEmailAddress);
        //   //// await _shoppingCart.ClearShoppingCartAsync();

        //   // return View("OrderCompleted");
        //}





    }
}
