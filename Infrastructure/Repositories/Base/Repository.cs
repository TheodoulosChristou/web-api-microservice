using Application.Interface.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data_Access;

namespace Infrastructure.Repositories.Base
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ProjectDbContext _sourceContext;

        public Repository(ProjectDbContext sourceContext)
        {
            _sourceContext = sourceContext;
        }

        public async Task<T> AddAsync(T entity, object? updatedProperties = null)
        {
            SetUpdatedProperties(entity, updatedProperties);
            await _sourceContext.Set<T>().AddAsync(entity);
            await _sourceContext.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities, object? updatedProperties = null)
        {
            foreach(var entity in entities) { SetUpdatedProperties(entity, updatedProperties); }
            await _sourceContext.Set<T>().AddRangeAsync(entities);
            await _sourceContext.SaveChangesAsync();
            return entities;
        }

        public async Task DeleteAsync(T entity)
        {
            _sourceContext.Set<T>().Remove(entity);
            await _sourceContext.SaveChangesAsync();
        }

        public async Task DeleteRangeAsync(IEnumerable<T> entities)
        {
            _sourceContext.Set<T>().RemoveRange(entities);
            await _sourceContext.SaveChangesAsync();
        }
        public async Task DeleteByIdAsync(Guid id, Guid projectId)
        {
            var entity = await GetByIdAsync(id, projectId);
            if (entity != null)
            {
                _sourceContext.Set<T>().Remove(entity);
            }
            await _sourceContext.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _sourceContext.Set<T>().ToListAsync();
        }

        public async Task<T?> GetByIdAsync(Guid id, Guid projectId)
        {
            var entity = await _sourceContext.Set<T>().FindAsync(id, projectId);
            return entity;
        }

        public async Task UpdateAsync(T entity, object? updatedProperties = null)
        {
            _sourceContext.Set<T>().Update(entity);
            SetUpdatedProperties(entity, updatedProperties);
            await _sourceContext.SaveChangesAsync();
        }

        public async Task UpdateRangeAsync(IEnumerable<T> entities, object? updatedProperties = null)
        {
            foreach (var entity in entities) { SetUpdatedProperties(entity, updatedProperties); }
            _sourceContext.Set<T>().UpdateRange(entities);
            await _sourceContext.SaveChangesAsync();
        }

        public async Task UpsertAsync(Guid id, Guid projectId, T entity, object? updatedProperties = null)
        {
            T? foundEntity = await _sourceContext.Set<T>().FindAsync(id, projectId);
            if (foundEntity == null)
            {
                await AddAsync(entity, updatedProperties);
            }
            else
            {
                _sourceContext.Entry(foundEntity).State = EntityState.Detached;
                await UpdateAsync(entity, updatedProperties);
            }
        }

        private void SetUpdatedProperties(T entity, object? updatedProperties)
        {
            if (updatedProperties != null)
            {
                var props = updatedProperties.GetType().GetProperties();
                foreach (var prop in props)
                {
                    if (prop != null)
                    {
                        var value = updatedProperties.GetType().GetProperty(prop.Name)?.GetValue(updatedProperties, null);
                        _sourceContext.Entry(entity).Property(prop.Name).CurrentValue = value;
                    }
                }
            }
        }
    }
}
