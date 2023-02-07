using Microsoft.EntityFrameworkCore;
using UnitOfWork.Data.Base;
using UnitOfWork.Models;

namespace UnitOfWork.Data.Services
{
    public class ProductOtionsService : EntityBaseRepository<ProductOptions>, IProductOptionsService
    {
        private readonly ApplicationDbContext _context;

        public ProductOtionsService(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ProductOptions>> GetAllProductOptions()
        {
            var alloptions = await _context.ProductOptions.ToListAsync();

            return alloptions;
        }
    }
}
