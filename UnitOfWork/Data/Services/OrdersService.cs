using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UnitOfWork.Data.Base;
using UnitOfWork.Models;

namespace UnitOfWork.Data.Services
{
    public class OrdersService : EntityBaseRepository<Orders>, IOrdersService
    {
        private readonly ApplicationDbContext _context;
       
       

        public OrdersService(ApplicationDbContext context) : base(context)
        {
            _context = context;
          
             
        }


        //public async Task StoreOrderAsync(OrdersCart ordersCart)
        //{
        //    var _orders = new Orders
        //    {
        //        FirstName_o = ordersCart.FirstName,
        //        LastName_o = ordersCart.LastName,
        //        Company_o = ordersCart.Company,
        //        Street_o = ordersCart.Street,
        //        City_o = ordersCart.City,
        //        State_o = ordersCart.State,
        //        ZipCode_o = ordersCart.ZipCode,
        //        Phone_o = ordersCart.Phone,
        //        ccc_name_o = ordersCart.ccc_name,
        //        ccc_number_o = ordersCart.ccc_number,
        //        expiration_o = ordersCart.expiration,
        //        cvv_o = ordersCart.cvv,
        //        ShoppingCartIdCustomer_o = ordersCart.ShoppingCartIdCustomer,
        //    };
            
        //       await _context.orders.AddAsync(_orders);
        //      await _context.SaveChangesAsync();
        //}


    }
}

 