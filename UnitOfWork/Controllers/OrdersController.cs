using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow.CopyAnalysis;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Claims;
using UnitOfWork.Data.Cart;
using UnitOfWork.Data.Services;
using UnitOfWork.Data.ViewModels;
using UnitOfWork.Migrations;
using UnitOfWork.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace UnitOfWork.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ShoppingCart _shoppingCart;
        private readonly IProductServices _productServices;
        private readonly IOrdersCartService _ordersCartService;
        private readonly IOrdersService _ordersService;
        private readonly IOrderedItemsService _orderedItemsService;

        
        public OrdersController(ShoppingCart shoppingCart, IProductServices productServices, IOrdersCartService ordersCartService, IOrdersService ordersService, IOrderedItemsService orderedItemsService)
        {
            _shoppingCart= shoppingCart;
            _productServices = productServices;
            _ordersCartService= ordersCartService;
            _ordersService= ordersService;
            _orderedItemsService = orderedItemsService;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ShoppingCart()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.shoppingCartItems = items;
            //var sessioncart = _shoppingCart.GetShoppingCartID();
            
            var response = new ShoppingCartVM()
            {
                ShoppingCart = _shoppingCart,
               
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal(),
                GetTotalCartItems = (int)_shoppingCart.GetTotalCartItems()

            };

            return View(response);
        }

        public async Task<IActionResult> AddItemToShoppingCart(int Id )
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

            var items =  _shoppingCart.LastOrder();
             var nwDt =  DateTime.Now;


            ViewData["CategoryName"] = items;
            ViewData["nowDt"] = nwDt;
            return View();

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

        public async Task<IActionResult> FinalCheckOut([Bind("FirstName,LastName,Company,Street,City,State,ZipCode,Phone, ccc_name,ccc_number, cvv, expiration, ShoppingCartIdCustomer, TotalAmount")] OrdersCart ordersCart)
        {
             await _ordersCartService.AddAsync(ordersCart);
              //await _context.orders.AddAsync(_orders);

            var _orders = new Orders
            {
                FirstName_o = ordersCart.FirstName,
                LastName_o = ordersCart.LastName,
                Company_o = ordersCart.Company,
                Street_o = ordersCart.Street,
                City_o = ordersCart.City,
                State_o = ordersCart.State,
                ZipCode_o = ordersCart.ZipCode,
                Phone_o = ordersCart.Phone,
                ccc_name_o = ordersCart.ccc_name,
                ccc_number_o = ordersCart.ccc_number,
                expiration_o = ordersCart.expiration,
                cvv_o = ordersCart.cvv,
                ShoppingCartIdCustomer_o = ordersCart.ShoppingCartIdCustomer,
                TotalAmount = ordersCart.TotalAmount
               
            };
            // copy data to a new tab le 
            await _ordersService.AddAsync(_orders);
            // get all the items from the cart and do the entry for a new table 
            // copy all the items from the orders to ordereditems

            var items = _shoppingCart.GetShoppingCartItems();

            foreach (var item in items )
            {
                var orderItem = new OrderedItems()
                {
                    products_o = item.products,
                    Amount_o   = item.Amount,
                    Qty_o      = item.Qty,
                    ShoppingCartId_o = item.ShoppingCartId,
                    options1_o = item.options1, 
                    options2_o= item.options2,
                    options3_o= item.options3,
                    options4_o= item.options4,
                    options5_o = item.options5,
                    options6_o= item.options6

                };
                await _orderedItemsService.AddAsync(orderItem);

            }
            // remove items from the shopping cart table
            await _shoppingCart.ClearShoppingCartAsync();
            await _shoppingCart.ClearOrdersAsync();


            // here is the pending store Orders
            // await  _ordersService.

            
            return RedirectToAction(nameof(ThankYou));
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
