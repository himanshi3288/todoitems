using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TodoItems.Repository
{
    public interface IRepository<T>
    {
        /// <summary>
        /// Add an Entity.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<T> AddAsync(T entity);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<bool> DeleteAsync(T entity);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T> GetByIdAsync(long id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> filter);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        Task<T> GetSingleAsync(Expression<Func<T, bool>> filter);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<T>> GetAsync();


        Task<T> UpdateAsync(T entity);

        Task<IEnumerable<T>> UpdateAsync(IEnumerable<T> entities);

        /// <summary>
        /// Add an Entity.
        /// </summary>
        ///  <param name="entity"></param> 
        /// <returns></returns>
        Task<IEnumerable<T>> AddAsync(IEnumerable<T> entities);
    }
}
