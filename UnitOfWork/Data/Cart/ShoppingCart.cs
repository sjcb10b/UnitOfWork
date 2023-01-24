using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Policy;
using UnitOfWork.Migrations;
using UnitOfWork.Models;

namespace UnitOfWork.Data.Cart
{
    public class ShoppingCart
    {
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
                    Amount = 1
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

        public double GetShoppingCartTotal() => (double)context.shoppingCartItems.Where(n => n.ShoppingCartId == ShoppingCartId).Select(n => n.products.Price * n.Amount).Sum();

        public async Task ClearShoppingCartAsync()
        {
            var items = await context.shoppingCartItems.Where(n => n.ShoppingCartId == ShoppingCartId).ToListAsync();
            context.shoppingCartItems.RemoveRange(items);
            await context.SaveChangesAsync();
        }




















    }
}
