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
        public DbSet<ApplicationUser> ApplicationUser { get; set; }

        public DbSet<Products> products { get; set; }
        public DbSet<ShoppingCartItem> shoppingCartItems { get; set;}
        public DbSet<Category> categories { get; set; }
        public DbSet<OrdersCart> ordersCarts { get; set; }
        public DbSet<ProductOptions> ProductOptions { get; set; }
        public DbSet<Orders> orders { get; set; }
        public DbSet<OrderedItems> orderedItems { get; set; }
        public DbSet<DisplayYesNo> displayYesNo { get; set; }

        public DbSet<Merchandise>  merchandise { get; set; }

        public DbSet<Items> items { get; set; }

        public DbSet<Country> countries { get; set; }


        public  DbSet<City> cities { get; set; }

        public DbSet<Customer> customers { get; set; }

        public DbSet<ArtLicencingModel> ArtLicencingModel { get; set; }




        







    }
}
