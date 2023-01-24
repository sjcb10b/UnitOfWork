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



    }
}
