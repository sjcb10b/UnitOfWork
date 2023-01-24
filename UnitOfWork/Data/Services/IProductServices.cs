﻿using UnitOfWork.Data.Base;
using UnitOfWork.Models;

namespace UnitOfWork.Data.Services
{
    public interface IProductServices : IEntityBaseRepository<Products>
    {

        Task<Products> GetProductsAsync(int id);
        Task AddProductAsync(Products data);
        Task UpdateProductAsync(Products data);
        Task<bool> DeleteProductAsync(int id);
        Task<IEnumerable<Products>> GetAllProducts();
     

    }
}
