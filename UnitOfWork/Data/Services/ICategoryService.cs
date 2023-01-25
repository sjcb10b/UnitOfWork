using UnitOfWork.Models;

namespace UnitOfWork.Data.Services
{
    public interface ICategoryService
    {
        Task<Category> GetCategoryAsync(int Id);
        Task AddCategoryAsync(Category data);
        Task UpdateProductAsync(Category data);
        Task<bool> DeleteCategoryAsync(int Id);
        Task<IEnumerable<Category>> GetAllCategorys();
    }
}
