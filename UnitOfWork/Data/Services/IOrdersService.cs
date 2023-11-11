using UnitOfWork.Data.Base;
using UnitOfWork.Models;

namespace UnitOfWork.Data.Services
{
    public interface IOrdersService : IEntityBaseRepository<Orders>
    {
        
    }
}
