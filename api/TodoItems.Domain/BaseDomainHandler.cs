using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TodoItems.Entities;
using TodoItems.Repository;

namespace TodoItems.Domain
{
    public class BaseDomainHandler<T> : IDomainHandler<T> where T : DbEntity
    {
        protected readonly IRepository<T> EntityRepository;

        public BaseDomainHandler(IRepository<T> repository)
        {
            EntityRepository = repository;
        }

        public virtual async Task<T> AddAsync(T entity)
        {
            return await EntityRepository.AddAsync(entity);
        }

        public virtual async Task<IEnumerable<T>> AddAsync(IEnumerable<T> entities)
        {
            return await EntityRepository.AddAsync(entities);
        }

        public virtual async Task<bool> DeleteAsync(T entity)
        {
            return await EntityRepository.DeleteAsync(entity);
        }

        public virtual async Task<bool> DeleteAsync(long id)
        {
            var entity = await GetByIdAsync(id);
            return await DeleteAsync(entity);
        }

        public virtual async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> filter)
        {
            return await EntityRepository.GetAsync(filter);
        }

        public virtual async Task<IEnumerable<T>> GetAsync()
        {
            return await EntityRepository.GetAsync(x => !x.IsDeleted);
        }

        public virtual async Task<T> GetByIdAsync(long id)
        {
            return await EntityRepository.GetByIdAsync(id);
        }

        public virtual async Task<T> UpdateAsync(T entity)
        {
            return await EntityRepository.UpdateAsync(entity);
        }

        public virtual async Task<IEnumerable<T>> UpdateAsync(IEnumerable<T> entity)
        {
            return await EntityRepository.UpdateAsync(entity);
        }
    }
}
