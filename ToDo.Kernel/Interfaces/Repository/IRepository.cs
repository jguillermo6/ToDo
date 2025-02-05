using ToDo.Kernel.Interfaces.Agregate;

namespace ToDo.Kernel.Interfaces.Repository;

public interface IRepository<T> where T : class, IAggregateRoot
{
    Task<T> GetByIdAsync(int id);
    Task<List<T>> ListAsync();
    Task<T> AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}
