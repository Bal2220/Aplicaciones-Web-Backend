using RetoSem9.Catalog.Domain.Models.Entities;

namespace RetoSem9.Shared.Domain.Repositories;

public interface IBaseRepository<TEntity>
{
    Task AddAsync(TEntity entity);
    Task<IEnumerable<TEntity>> ListAsync();
}