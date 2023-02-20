using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using System.IO;
using System.Reflection.Emit;
using UnitOfWork.Data.Base;
using UnitOfWork.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace UnitOfWork.Data.Services
{
    public class OrdersCartService : EntityBaseRepository<OrdersCart>, IOrdersCartService
    {
        private readonly ApplicationDbContext _context;

        public OrdersCartService(ApplicationDbContext context) : base(context)
        {
            _context= context;
        }

        
    }
}
