namespace Application.Interface.Repositories.Base
{
    public interface IRepository<T> where T : class
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T?> GetByIdAsync(Guid id, Guid projectId);
        Task<T> AddAsync(T entity, object? updatedProperties = null);
        Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities, object? updatedProperties = null);
        Task UpdateAsync(T entity, object? updatedProperties = null);
        Task UpdateRangeAsync(IEnumerable<T> entities, object? updatedProperties = null);
        Task UpsertAsync(Guid id, Guid projectId, T entity, object? updatedProperties = null);
        Task DeleteAsync(T entity);
        Task DeleteRangeAsync(IEnumerable<T> entities);
    }
    }
