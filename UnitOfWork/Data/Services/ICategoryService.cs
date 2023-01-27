using UnitOfWork.Data.Base;
using UnitOfWork.Models;

namespace UnitOfWork.Data.Services
{
    public interface ICategoryService : IEntityBaseRepository<Category>
    {
        Task<Category> GetCategoryAsync(int Id);

        Task AddCategoryAsync(Category data);
        Task UpdateProductAsync(Category data);
        Task<bool> DeleteCategoryAsync(int Id);
        Task<IEnumerable<Category>> GetAllCategorys();
        //Task<List<Category>> GetCategorybyName(string category);
        Task<IEnumerable<Category>> GetByCategoriesAsync(string categoryname);

    }
}
