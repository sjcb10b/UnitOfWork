using UnitOfWork.Data.Base;
using UnitOfWork.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;


namespace UnitOfWork.Data.Services
{
    public class OrderedItemsService : EntityBaseRepository<OrderedItems>, IOrderedItemsService
    {
        private readonly ApplicationDbContext _context;
        
        public OrderedItemsService(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
