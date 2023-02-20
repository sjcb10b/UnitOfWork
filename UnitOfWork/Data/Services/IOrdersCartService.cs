using UnitOfWork.Data.Base;
using UnitOfWork.Models;

namespace UnitOfWork.Data.Services
{
    public interface IOrdersCartService : IEntityBaseRepository<OrdersCart>
    {
        //Task<OrdersCart> GetOrderCartAsync(int Id);
        //Task AddOrdersCartAsync(OrdersCart data);
        //Task UpdateOrdersCartAsync(OrdersCart data);
        //Task<bool> DeleteOrdersCartAsync(int id);
        //Task<IEnumerable<OrdersCart>> GetAllOrdersCart();
    }
}
