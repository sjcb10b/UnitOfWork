using Microsoft.EntityFrameworkCore;
using UnitOfWork.Data.Base;
using UnitOfWork.Models;

namespace UnitOfWork.Data.Services
{
    public class CategoryService : EntityBaseRepository<Category>, ICategoryService
    {
        private readonly ApplicationDbContext _context;

        public CategoryService(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<Category> GetCategoryAsync(int Id)
        {
          var res = await _context.categories.FirstOrDefaultAsync(c => c.Id == Id);
          return res;
        }

        public async Task AddCategoryAsync(Category data)
        {
            var newcat = new Category()
            {
                Name = data.Name,
                DisplayOrder = data.DisplayOrder,
                CreatedDate = DateTime.Now,
            };

            await _context.categories.AddAsync(data);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteCategoryAsync(int Id)
        {

            if (Id > 0)
            {
                var prod =await  _context.categories.FirstOrDefaultAsync(c => c.Id == Id);
                if (prod != null)
                {
                    _context.categories.Remove(prod);
                    await _context.SaveChangesAsync();
                    return true;
                }

            } 
                return false;
        }

        public async Task<IEnumerable<Category>> GetAllCategorys()
        {
            var allcat = await _context.categories.ToListAsync();
            return allcat;
        }

        

        public async Task UpdateProductAsync(Category data)
        {
            var result = await _context.categories.FirstOrDefaultAsync(c => c.Id == Id);
            if (result != null)
            {
                result.Name = data.Name;
                result.DisplayOrder = data.DisplayOrder;
                result.CreatedDate = DateTime.Now;
                _context.categories.Add(result);
                await _context.SaveChangesAsync();
            }
        }
    }
}
