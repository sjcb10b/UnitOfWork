using UnitOfWork.Data.Base;
using UnitOfWork.Models;

namespace UnitOfWork.Data.Services
{
    public interface IProductOptionsService : IEntityBaseRepository<ProductOptions>
    {
 
        Task<IEnumerable<ProductOptions>>GetAllProductOptions();
        
    }
}
