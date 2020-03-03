using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TodoItems.Entities;
using System.Linq;

namespace TodoItems.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : DbEntity
    {
        protected TodoItemsContext _DbContext;

        public BaseRepository(TodoItemsContext context)
        {
            _DbContext = context;
        }
        public async Task<T> AddAsync(T entity)
        {
            entity.CreatedDateUTC = DateTime.UtcNow;
            _DbContext.Entry(entity).State = EntityState.Added;


            await _DbContext.SaveChangesAsync();


            return entity;
        }

        public async Task<IEnumerable<T>> AddAsync(IEnumerable<T> entities)
        {
            if (entities == null || entities.Count() == 0)
            {
                return entities;
            }

            foreach (T item in entities)
            {
                item.CreatedDateUTC = DateTime.UtcNow;
                item.UpdatedDateUTC = DateTime.UtcNow;
                _DbContext.Entry(item).State = EntityState.Added;
            }

            await _DbContext.SaveChangesAsync();

            return entities;
        }

        public async Task<bool> DeleteAsync(T entity)
        {
            _DbContext.Entry(entity).State = EntityState.Deleted;

            await _DbContext.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> filter)
        {
            return await _DbContext.Set<T>().Where(filter).ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAsync()
        {
            return await _DbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(long id)
        {
            return await _DbContext.Set<T>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> filter)
        {
            return await _DbContext.Set<T>().Where(filter).FirstOrDefaultAsync();
        }

        public async Task<T> UpdateAsync(T entity)
        {
            entity.UpdatedDateUTC = DateTime.UtcNow;
            _DbContext.Entry(entity).State = EntityState.Modified;

            await _DbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<IEnumerable<T>> UpdateAsync(IEnumerable<T> entity)
        {
            if (entity == null || entity.Count() == 0)
            {
                return entity;
            }

            foreach (T item in entity)
            {
                item.UpdatedDateUTC = DateTime.UtcNow;
                _DbContext.Entry(item).State = EntityState.Modified;
            }

            await _DbContext.SaveChangesAsync();

            return entity;

        }
    }
}
