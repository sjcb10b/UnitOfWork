﻿using System.Linq.Expressions;

namespace UnitOfWork.Data.Base
{
    public interface IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {

        Task<IEnumerable<T>> GetAllAsync();

        Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includeProperties);

        Task<T> GetByIdAsync(int Id);

        Task<T> GetByIdAsync(int Id, params Expression<Func<T, object>>[] includeProperties);

        Task AddAsync(T entity);

        Task UpdateAsync(int Id, T entity);

        Task DeleteAsync(int Id);

    }
}
