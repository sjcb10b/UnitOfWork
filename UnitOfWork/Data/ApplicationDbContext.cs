using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UnitOfWork.Models;

namespace UnitOfWork.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions  options) : base(options)
        {

        }

        public DbSet<Products> products { get; set; }
        public DbSet<ShoppingCartItem> shoppingCartItems { get; set;}
        public DbSet<Category> categories { get; set; }
        public DbSet<OrdersCart> ordersCarts { get; set; }
        public DbSet<ProductOptions> ProductOptions { get; set; }

        public DbSet<DisplayYesNo> displayYesNo { get; set; }






    }
}
