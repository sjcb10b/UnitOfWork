using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using UnitOfWork.Data.Cart;
using UnitOfWork.Data.Services;
using UnitOfWork.Data.ViewModels;

namespace UnitOfWork.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ShoppingCart _shoppingCart;
        private readonly IProductServices _productServices;

        public OrdersController(ShoppingCart shoppingCart, IProductServices productServices)
        {
            _shoppingCart= shoppingCart;
            _productServices = productServices;
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



            return View();
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
