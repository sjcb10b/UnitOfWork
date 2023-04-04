using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Linq;
using System.Security.Policy;
using UnitOfWork.Migrations;
using UnitOfWork.Models;

namespace UnitOfWork.Data.Cart
{
    public class ShoppingCart
    {
        private int totalItems;

        public ApplicationDbContext context { get; set; }
        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItem> shoppingCartItems { get; set; }

        public ShoppingCart(ApplicationDbContext context)
        {
            this.context = context;
        }

        public static ShoppingCart GetShoppingCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<ApplicationDbContext>();

            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", cartId);

            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }


        public void AddItemToCart(Products product)
        {
            var shoppingCartItem = context.shoppingCartItems.FirstOrDefault(n => n.products.Id == product.Id && n.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem()
                {
                    ShoppingCartId = ShoppingCartId,
                    products = product,
                    Amount = 1,
                    Qty  = 1,
                 

                };

                context.shoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }
            context.SaveChanges();
        }



        public void AddItemToCartA(Products product, int qty, string option1, string option2, string option3, string option4, string option5, string option6)
        {
            var shoppingCartItem = context.shoppingCartItems.FirstOrDefault(n => n.products.Id == product.Id && n.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem()
                {
                    ShoppingCartId = ShoppingCartId,
                    products = product,
                    Amount = qty,
                    Qty = qty,
                    options1 = option1,
                    options2 = option2,
                    options3 = option3,
                    options4 = option4,
                    options5 = option5,
                    options6 = option6,


                };

                context.shoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }
            context.SaveChanges();
        }



        public void RemoveItemFromCart(Products product)
        {
            var shoppingCartItem = context.shoppingCartItems.FirstOrDefault(n => n.products.Id == product.Id && n.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                }
                else
                {
                    context.shoppingCartItems.Remove(shoppingCartItem);
                }
            }
            context.SaveChanges();
        }



        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return shoppingCartItems ?? (shoppingCartItems = context.shoppingCartItems.Where(n => n.ShoppingCartId == ShoppingCartId).Include(n => n.products).ToList());
        }



        public double GetTotalCartItems()
        {
            var totalCartItems = context.shoppingCartItems.Where(n => n.ShoppingCartId == ShoppingCartId).Select(p => p.Amount).Sum();
            //var totalCartItems = 1;
            return totalCartItems;

        }




        public double GetShoppingCartTotal() => (double)context.shoppingCartItems.Where(n => n.ShoppingCartId == ShoppingCartId).Select(n => n.products.Price * n.Amount).Sum();

        public async Task ClearShoppingCartAsync()
        {
            var items = await context.shoppingCartItems.Where(n => n.ShoppingCartId == ShoppingCartId).ToListAsync();
            context.shoppingCartItems.RemoveRange(items);
            await context.SaveChangesAsync();
        }

         


    }
}
