using ToDo.Kernel.Interfaces.Agregate;

namespace ToDo.Kernel.Interfaces.Repository;

public interface IRepository<T> where T : class, IAggregateRoot
{
    Task<T> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<List<T>> ListAsync(CancellationToken cancellationToken = default);
    Task<T> AddAsync(T entity, CancellationToken cancellationToken = default);
    Task UpdateAsync(T entity, CancellationToken cancellationToken = default);
    Task DeleteAsync(T entity, CancellationToken cancellationToken = default);
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
