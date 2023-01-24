using Microsoft.AspNetCore.Mvc;
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
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
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





    }
}
